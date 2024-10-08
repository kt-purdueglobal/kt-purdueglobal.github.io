using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace BookSmart
{
    public partial class InventoryManagement : Form
    {
        private void InventoryManagement_Load(object sender, EventArgs e)
        {
            System.Drawing.Rectangle workingRectangle = Screen.PrimaryScreen.WorkingArea;
            this.Size = new System.Drawing.Size(Convert.ToInt32(1 * workingRectangle.Width),
                Convert.ToInt32(1 * workingRectangle.Height));

            this.Location = new System.Drawing.Point(0, 0);
        }
        public InventoryManagement()
        {
            InitializeComponent();
        }

        private string connectionString = "Server=KORRI-ACER\\SQLEXPRESS;Database=Booksmart;Trusted_Connection=True;";

        private void returnHome_Click(object sender, EventArgs e)
        {
            MainMenu menu_form = new MainMenu();
            this.Hide();
            menu_form.Show();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            AddBook();


            if (string.IsNullOrEmpty(textBox1.Text))
            {

                MessageBox.Show("Please enter Title of book.");
            }
            else
            {

                MessageBox.Show("Book Added Successfully!");
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            RemoveBook();


            if (string.IsNullOrEmpty(textBox1.Text))
            {

                MessageBox.Show("Please enter Title of book to remove.");
            }


        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            UpdateBook();

            if (string.IsNullOrEmpty(textBox1.Text))
            {

                MessageBox.Show("Please enter Title to update.");
            }
            else
            {


                MessageBox.Show("Book Successfully Updated!");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void UpdateBook()
        {

            string title = textBox1.Text;
            string genre = textBox2.Text;
            string author = textBox3.Text;
            string stock = textBox4.Text;
            string price = textBox5.Text;
            string isbn = textBox6.Text;
            string series = textBox7.Text;
            string averagerating = textBox8.Text;
            string publisherId = textBox9.Text;
            string published = textBox10.Text;


            string updateQuery = "UPDATE Book SET Title = @Title, Genre = @Genre, Price = @Price, ISBN = @ISBN, Series = @Series, AverageRating = @AverageRating, PublisherID = @PublisherID, Published = @Published WHERE Title = @Title";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {


                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {


                    command.Parameters.Add("@Title", SqlDbType.NVarChar).Value = title;
                    command.Parameters.Add("@Genre", SqlDbType.NVarChar).Value = genre;
                    command.Parameters.Add("@Price", SqlDbType.NVarChar).Value = price;
                    command.Parameters.Add("@ISBN", SqlDbType.NVarChar).Value = isbn;
                    command.Parameters.Add("@Series", SqlDbType.NVarChar).Value = series;
                    command.Parameters.Add("@AverageRating", SqlDbType.NVarChar).Value = averagerating;
                    command.Parameters.Add("@PublisherID", SqlDbType.Int).Value = int.Parse(publisherId);
                    command.Parameters.Add("@Published", SqlDbType.NVarChar).Value = published;


                    try
                    {


                        connection.Open();


                        int rowsAffected = command.ExecuteNonQuery();


                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Database Updated!");
                        }
                        else if (rowsAffected == 0)
                        {
                            MessageBox.Show("Information not updated.");
                        }
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
            }
        }

        private void RemoveBook()
        {

            string title = textBox1.Text;



            string removeQuery = "DELETE FROM Book WHERE Title = @Title";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {


                using (SqlCommand command = new SqlCommand(removeQuery, connection))
                {


                    command.Parameters.Add("@Title", SqlDbType.NVarChar).Value = title;



                    try
                    {

                        connection.Open();

                        int rowsAffected = command.ExecuteNonQuery();


                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Database Updated After Removing Information!");
                        }
                        else if (rowsAffected == 0)
                        {
                            MessageBox.Show("Information not removed.");
                        }
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
            }
        }

        private void AddBook()
        {

            string title = textBox1.Text;
            string genre = textBox2.Text;
            string author = textBox3.Text;
            string stock = textBox4.Text;
            string price = textBox5.Text;
            string isbn = textBox6.Text;
            string series = textBox7.Text;
            string averagerating = textBox8.Text;
            string publisherId = textBox9.Text;
            string published = textBox10.Text;


            if (string.IsNullOrWhiteSpace(title) ||
                string.IsNullOrWhiteSpace(genre) ||
                string.IsNullOrWhiteSpace(author) ||
                string.IsNullOrWhiteSpace(stock) ||
                string.IsNullOrWhiteSpace(price) ||
                string.IsNullOrWhiteSpace(isbn) ||
                string.IsNullOrWhiteSpace(series) ||
                string.IsNullOrWhiteSpace(averagerating) ||
                string.IsNullOrWhiteSpace(publisherId) ||
                string.IsNullOrWhiteSpace(published))
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }

            if (!int.TryParse(publisherId, out int parsedPublisherId))
            {
                MessageBox.Show("Please enter a valid numeric value for PublisherID.");
                return;
            }

            if (!IsPublisherIDValid(parsedPublisherId))
            {
                DialogResult result = MessageBox.Show("The PublisherID does not exist. Would you like to add a new publisher?",
                                                       "Invalid PublisherID",
                                                       MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {

                    string newPublisherName = PromptForPublisherDetails();
                    if (string.IsNullOrEmpty(newPublisherName))
                    {
                        MessageBox.Show("Publisher name cannot be empty.");
                        return;
                    }


                    parsedPublisherId = AddNewPublisher(newPublisherName);
                    if (parsedPublisherId == -1)
                    {
                        MessageBox.Show("Failed to add new publisher.");
                        return;
                    }
                }
                else
                {
                    return; //User chose not to add a new publisher
                }
            }


            string query = "INSERT INTO Book (Title, Genre, Price, ISBN, Series, AverageRating, PublisherID, Published) VALUES (@Title, @Genre, @Price, @ISBN, @Series, @AverageRating, @PublisherID, @Published)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.Add("@Title", SqlDbType.NVarChar).Value = title;
                    command.Parameters.Add("@Genre", SqlDbType.NVarChar).Value = genre;
                    command.Parameters.Add("@Author", SqlDbType.NVarChar).Value = author;
                    command.Parameters.Add("@Stock", SqlDbType.NVarChar).Value = stock;
                    command.Parameters.Add("@Price", SqlDbType.NVarChar).Value = price;
                    command.Parameters.Add("@ISBN", SqlDbType.NVarChar).Value = isbn;
                    command.Parameters.Add("@Series", SqlDbType.NVarChar).Value = series;
                    command.Parameters.Add("@AverageRating", SqlDbType.NVarChar).Value = averagerating;
                    command.Parameters.Add("@PublisherID", SqlDbType.Int).Value = parsedPublisherId;
                    command.Parameters.Add("@Published", SqlDbType.NVarChar).Value = published;


                    try
                    {

                        connection.Open();


                        command.ExecuteNonQuery();
                    }

                    catch (Exception ex)
                    {

                        MessageBox.Show($"Error: {ex.Message}");
                    }
                }
            }
        }

        private bool IsPublisherIDValid(int publisherId)
        {
            string query = "SELECT COUNT(1) FROM Publisher WHERE PublisherID = @PublisherID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@PublisherID", SqlDbType.Int).Value = publisherId;

                    try
                    {
                        connection.Open();
                        int count = (int)command.ExecuteScalar();
                        return count > 0; // Return true if the Publisher ID exists
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error checking PublisherID: {ex.Message}");
                        return false; // Return false if there's an error
                    }
                }
            }
        }

        private string PromptForPublisherDetails()
        {
            string newPublisherName = Microsoft.VisualBasic.Interaction.InputBox("Enter new Publisher Name:", "Add New Publisher", "", -1, -1);
            return newPublisherName;
        }

        private int AddNewPublisher(string publisherName)
        {
            string query = "INSERT INTO Publisher (PublisherName) OUTPUT INSERTED.PublisherID VALUES (@PublisherName)";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@PublisherName", SqlDbType.NVarChar).Value = publisherName;

                    try
                    {
                        connection.Open();
                        int newPublisherId = (int)command.ExecuteScalar();
                        return newPublisherId;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error adding publisher: {ex.Message}");
                        return -1;
                    }
                }
            }
        }
    }
}