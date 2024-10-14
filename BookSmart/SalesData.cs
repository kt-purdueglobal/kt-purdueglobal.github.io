using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace BookSmart
{
    public partial class SalesData : Form
    {
        private string connectionString = "Server=DESKTOP-1UT63KC\\SQLEXPRESS;Database=BookSmart;Trusted_Connection=True;";
        private const int DesiredInventoryLevel = 10; // Set this to your desired inventory level

        public SalesData()
        {
            InitializeComponent();
            LoadBookTitles();
        }

        private void SalesData_Load(object sender, EventArgs e)
        {
            // Initialization code can go here if needed
        }

        private void LoadBookTitles()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT Title FROM Book";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            comboBoxBookTitle.Items.Add(reader["Title"].ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading book titles: " + ex.Message);
                }
            }
        }

        private void comboBoxBookTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            // No longer need to load years, as we are assuming all time
        }

        private void btnFetchData_Click(object sender, EventArgs e)
        {
            FetchData();
        }

        private void returnHome_Click(object sender, EventArgs e)
        {
            MainMenu menu_form = new MainMenu();
            this.Hide();
            menu_form.Show();
        }

        private void FetchData()
        {
            string selectedBookTitle = comboBoxBookTitle.SelectedItem?.ToString();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = @"
                SELECT 
                    DATEPART(QUARTER, T.TransactionDate) AS Quarter,
                    YEAR(T.TransactionDate) AS Year,
                    ISNULL(SUM(S.Quantity), 0) AS TotalSold,
                    ISNULL(I.QuantityInStock, 0) AS CurrentInventory,
                    ISNULL(AVG(S.Quantity), 0) AS AverageSales,
                    (ISNULL(AVG(S.Quantity), 0) * 1.1) AS NextQuarterPrediction,
                    CEILING(
                        CASE 
                            WHEN ISNULL(I.QuantityInStock, 0) - (ISNULL(AVG(S.Quantity), 0) * 1.1) < @DesiredInventoryLevel 
                            THEN @DesiredInventoryLevel - (ISNULL(I.QuantityInStock, 0) - (ISNULL(AVG(S.Quantity), 0) * 1.1))
                            ELSE 0 
                        END
                    ) AS BooksToOrder
                FROM 
                    Transactions T
                JOIN 
                    Sales S ON T.TransactionID = S.TransactionID
                JOIN 
                    Book B ON S.BookID = B.BookID
                LEFT JOIN 
                    Inventory I ON B.BookID = I.BookID
                WHERE 
                    B.Title = @BookTitle
                GROUP BY 
                    DATEPART(QUARTER, T.TransactionDate), YEAR(T.TransactionDate), I.QuantityInStock
                ORDER BY 
                    Year DESC, Quarter ASC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@BookTitle", selectedBookTitle);
                        cmd.Parameters.AddWithValue("@DesiredInventoryLevel", DesiredInventoryLevel);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        if (dataTable.Rows.Count == 0)
                        {
                            MessageBox.Show("No data found for the selected book.");
                        }
                        else
                        {
                            dataGridViewResults.DataSource = dataTable;
                            UpdateChart(dataTable); // Call the method to update the chart
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }


        private void UpdateChart(DataTable dataTable)
        {
            // Clear previous series
            salesChart.Series.Clear();
            salesChart.ChartAreas.Clear();

            // Create a new chart area
            ChartArea chartArea = new ChartArea("MainChartArea");
            salesChart.ChartAreas.Add(chartArea);

            // Create a new series for Total Sold
            Series salesSeries = new Series
            {
                Name = "Total Sold",
                ChartType = SeriesChartType.Column,
                XValueType = ChartValueType.String,
                YValueType = ChartValueType.Int32
            };

            // Loop through the DataTable and add points to the series
            foreach (DataRow row in dataTable.Rows)
            {
                string quarterLabel = "Q" + row["Quarter"] + " " + row["Year"];
                salesSeries.Points.AddXY(quarterLabel, row["TotalSold"]);
            }

            // Add the series to the chart
            salesChart.Series.Add(salesSeries);

            // Optional: Set chart title
            salesChart.Titles.Clear();
            salesChart.Titles.Add("Sales by Quarter for " + comboBoxBookTitle.SelectedItem?.ToString());
        }

        private double GetCurrentInventory(string selectedBookTitle)
        {
            double currentInventory = 0;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT ISNULL(QuantityInStock, 0) FROM Inventory WHERE BookID = (SELECT BookID FROM Book WHERE Title = @Title)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Title", selectedBookTitle);
                        currentInventory = (double)cmd.ExecuteScalar();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error getting current inventory: " + ex.Message);
                }
            }

            return currentInventory;
        }

        private void btnTop50Sold_Click(object sender, EventArgs e)
        {
            DisplayTop50Sold();
        }

        private void DisplayTop50Sold()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = @"
                SELECT TOP 50 
                    B.BookID,
                    B.Title,
                    ISNULL(SUM(S.Quantity), 0) AS TotalSold,
                    ISNULL(I.QuantityInStock, 0) AS CurrentInventory,
                    ISNULL(AVG(S.Quantity), 0) AS AverageSales,
                    (ISNULL(AVG(S.Quantity), 0) * 1.1) AS NextQuarterPrediction,
                    CEILING(
                        CASE 
                            WHEN ISNULL(I.QuantityInStock, 0) - (ISNULL(AVG(S.Quantity), 0) * 1.1) < @DesiredInventoryLevel 
                            THEN @DesiredInventoryLevel - (ISNULL(I.QuantityInStock, 0) - (ISNULL(AVG(S.Quantity), 0) * 1.1))
                            ELSE 0 
                        END
                    ) AS BooksToOrder
                FROM 
                    Book B
                LEFT JOIN 
                    Sales S ON B.BookID = S.BookID
                LEFT JOIN 
                    Inventory I ON B.BookID = I.BookID
                GROUP BY 
                    B.BookID, B.Title, I.QuantityInStock
                ORDER BY 
                    TotalSold DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Add parameter for DesiredInventoryLevel
                        cmd.Parameters.AddWithValue("@DesiredInventoryLevel", DesiredInventoryLevel);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Bind data to DataGridView
                        dataGridViewResults.DataSource = dataTable;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading top 50 sold books: " + ex.Message);
                }
            }
        }


        private void SalesData_Resize(object sender, EventArgs e)
        {
            dataGridViewResults.Width = this.ClientSize.Width - 24; // Adjust for padding
            dataGridViewResults.Height = this.ClientSize.Height - 120; // Adjust for button heights
        }
    }
}
