using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Linq.Expressions;

namespace BookSmart
{
    public partial class SearchForm : Form
    {

        public SearchForm()
        {
            InitializeComponent();
        }

        // This connects the GUI to your database
        //private string connectionString = "Server=DESKTOP-0K4N3E2\\SQLEXPRESS;Database=Booksmart;Trusted_Connection=True;"; //replace 'DESKTOP-1U63KC' with your server

        private string connectionString = "Server=KORRI-ACER\\SQLEXPRESS;Database=Booksmart;Trusted_Connection=True;";



        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Get the search term from the text box
            string searchTerm = txtboxSearch.Text.Trim();

            // Call the method to search the database and populate the DataGridView
            SearchBooks(searchTerm);
        }

        private void SearchBooks(string searchTerm)
        {
            // SQL query with JOINs to search in multiple tables (Author, Publisher, Book, Inventory) 
            string query = @"
        SELECT 
            Book.ISBN, 
            Book.Title, 
            Book.Series, 
            Book.Genre, 
            Book.AverageRating, 
            Author.FirstName + ' ' + Author.LastName AS AuthorName, 
            Publisher.PublisherName, 
            Book.Published, 
            Book.Price,
            CONCAT(Inventory.AisleNumber , '-', Inventory.ShelfNumber) AS ShelfLocation,
            Inventory.QuantityInStock -- Include quantity in stock
        FROM 
            Book
        INNER JOIN 
            Author ON Book.AuthorID = Author.AuthorID
        INNER JOIN 
            Publisher ON Book.PublisherID = Publisher.PublisherID
        INNER JOIN
            Inventory ON Book.BookID = Inventory.BookID
        WHERE 
            (Author.FirstName LIKE @searchTerm OR Author.LastName LIKE @searchTerm)
            OR (Publisher.PublisherName LIKE @searchTerm)
            OR (Book.ISBN LIKE @searchTerm)
            OR (Book.Title LIKE @searchTerm)
            OR (Book.Series LIKE @searchTerm)
            OR (Book.Genre LIKE @searchTerm)
            OR (Inventory.AisleNumber LIKE @searchTerm OR Inventory.ShelfNumber LIKE @searchTerm)";

            // Connect to the database using the provided connection string
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Add parameter to prevent SQL injection
                        cmd.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%");

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable results = new DataTable();

                        // Fill the DataTable with the results from the query
                        adapter.Fill(results);

                        if (results.Rows.Count == 0)
                        {
                            // If no results, create a temporary table with a message
                            DataTable noResultsTable = new DataTable();
                            noResultsTable.Columns.Add("Message");
                            noResultsTable.Rows.Add("No results were found for your search.");

                            // Set the DataGridView to display the message
                            dataGridViewBooksResult.DataSource = noResultsTable;
                        }
                        else
                        {
                            // Bind the actual results to the DataGridView
                            dataGridViewBooksResult.DataSource = results;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }


        private void btnBestSellers_Click(object sender, EventArgs e)
        {
            DisplayBestSellers();
        }

        private void DisplayBestSellers()
        {
            // SQL query to get the top 10 best-selling books with text column conversion
            string query = @"
        SELECT TOP 10 
            Book.ISBN, 
            Book.Title, 
            Book.Series, 
            CONVERT(varchar(max), Book.Genre) AS Genre, -- Convert text to varchar(max)
            Book.AverageRating, 
            Author.FirstName + ' ' + Author.LastName AS AuthorName, 
            Publisher.PublisherName, 
            Book.Published, 
            Book.Price, 
            SUM(Sales.Quantity) AS TotalSold
        FROM 
            Sales
        INNER JOIN 
            Book ON Sales.BookID = Book.BookID
        INNER JOIN 
            Author ON Book.AuthorID = Author.AuthorID
        INNER JOIN 
            Publisher ON Book.PublisherID = Publisher.PublisherID
        GROUP BY 
            Book.ISBN, 
            Book.Title, 
            Book.Series, 
            CONVERT(varchar(max), Book.Genre), -- Convert text to varchar(max)
            Book.AverageRating, 
            Author.FirstName, 
            Author.LastName, 
            Publisher.PublisherName, 
            Book.Published, 
            Book.Price
        ORDER BY 
            TotalSold DESC;
    ";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable bestSellers = new DataTable();

                        adapter.Fill(bestSellers);

                        if (bestSellers.Rows.Count == 0)
                        {
                            DataTable noResultsTable = new DataTable();
                            noResultsTable.Columns.Add("Message");
                            noResultsTable.Rows.Add("No best sellers found.");
                            dataGridViewBooksResult.DataSource = noResultsTable;
                            dataGridViewBooksResult.ColumnHeadersVisible = false;
                        }
                        else
                        {
                            dataGridViewBooksResult.DataSource = bestSellers;
                            dataGridViewBooksResult.ColumnHeadersVisible = true;
                            dataGridViewBooksResult.AutoResizeColumns();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnTopRated_Click(object sender, EventArgs e)
        {
            DisplayTopRatedBooks();
        }

        private void DisplayTopRatedBooks()
        {
            // SQL query to get the top 10 highest-rated books
            string query = @"
        SELECT TOP 10 
            Book.ISBN, 
            Book.Title, 
            Book.Series, 
            CONVERT(varchar(max), Book.Genre) AS Genre, -- Convert text to varchar(max) if needed
            Book.AverageRating, 
            Author.FirstName + ' ' + Author.LastName AS AuthorName, 
            Publisher.PublisherName, 
            Book.Published, 
            Book.Price
        FROM 
            Book
        INNER JOIN 
            Author ON Book.AuthorID = Author.AuthorID
        INNER JOIN 
            Publisher ON Book.PublisherID = Publisher.PublisherID
        ORDER BY 
            Book.AverageRating DESC;
    ";

            // Connect to the database
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable topRatedBooks = new DataTable();

                        // Fill the DataTable with the results from the query
                        adapter.Fill(topRatedBooks);

                        if (topRatedBooks.Rows.Count == 0)
                        {
                            // If no top-rated books found, display a message
                            DataTable noResultsTable = new DataTable();
                            noResultsTable.Columns.Add("Message");
                            noResultsTable.Rows.Add("No top-rated books found.");
                            dataGridViewBooksResult.DataSource = noResultsTable;
                            dataGridViewBooksResult.ColumnHeadersVisible = false;
                        }
                        else
                        {
                            // Display the top-rated books in the DataGridView
                            dataGridViewBooksResult.DataSource = topRatedBooks;
                            dataGridViewBooksResult.ColumnHeadersVisible = true;

                            // Auto-resize columns
                            dataGridViewBooksResult.AutoResizeColumns();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }




        private void returnHome_Click(object sender, EventArgs e)
        {
            MainMenu menu_form = new MainMenu();
            this.Hide();
            menu_form.Show();
        }

        private void btnRecentlyPublished_Click(object sender, EventArgs e)
        {
            DisplayRecentlyPublishedBooks();
        }

        private void DisplayRecentlyPublishedBooks()
        {
            // SQL query to get the top 10 most recently published books
            string query = @"
        SELECT TOP 10 
            Book.ISBN, 
            Book.Title, 
            Book.Series, 
            CONVERT(varchar(max), Book.Genre) AS Genre, -- Convert text to varchar(max) if needed
            Book.AverageRating, 
            Author.FirstName + ' ' + Author.LastName AS AuthorName, 
            Publisher.PublisherName, 
            Book.Published, 
            Book.Price
        FROM 
            Book
        INNER JOIN 
            Author ON Book.AuthorID = Author.AuthorID
        INNER JOIN 
            Publisher ON Book.PublisherID = Publisher.PublisherID
        ORDER BY 
            Book.Published DESC;
    ";

            // Connect to the database
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable recentlyPublishedBooks = new DataTable();

                        // Fill the DataTable with the results from the query
                        adapter.Fill(recentlyPublishedBooks);

                        if (recentlyPublishedBooks.Rows.Count == 0)
                        {
                            // If no recently added books found, display a message
                            DataTable noResultsTable = new DataTable();
                            noResultsTable.Columns.Add("Message");
                            noResultsTable.Rows.Add("No recently added books found.");
                            dataGridViewBooksResult.DataSource = noResultsTable;
                            dataGridViewBooksResult.ColumnHeadersVisible = false;
                        }
                        else
                        {
                            // Display the recently added books in the DataGridView
                            dataGridViewBooksResult.DataSource = recentlyPublishedBooks;
                            dataGridViewBooksResult.ColumnHeadersVisible = true;

                            // Auto-resize columns
                            dataGridViewBooksResult.AutoResizeColumns();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void bbtnViewAll_Click(object sender, EventArgs e)
        {
            DisplayAllBooks();
        }

        private void DisplayAllBooks()
        {
            // SQL query to get all books
            string query = @"
        SELECT 
            Book.ISBN, 
            Book.Title, 
            Book.Series, 
            CONVERT(varchar(max), Book.Genre) AS Genre, -- Convert text to varchar(max) if needed
            Book.AverageRating, 
            Author.FirstName + ' ' + Author.LastName AS AuthorName, 
            Publisher.PublisherName, 
            Book.Published, 
            Book.Price
        FROM 
            Book
        INNER JOIN 
            Author ON Book.AuthorID = Author.AuthorID
        INNER JOIN 
            Publisher ON Book.PublisherID = Publisher.PublisherID;
    ";

            // Connect to the database
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable allBooks = new DataTable();

                        // Fill the DataTable with the results from the query
                        adapter.Fill(allBooks);

                        if (allBooks.Rows.Count == 0)
                        {
                            // If no books are found, display a message
                            DataTable noResultsTable = new DataTable();
                            noResultsTable.Columns.Add("Message");
                            noResultsTable.Rows.Add("No books found.");
                            dataGridViewBooksResult.DataSource = noResultsTable;
                            dataGridViewBooksResult.ColumnHeadersVisible = false;
                        }
                        else
                        {
                            // Display all books in the DataGridView
                            dataGridViewBooksResult.DataSource = allBooks;
                            dataGridViewBooksResult.ColumnHeadersVisible = true;

                            // Auto-resize columns
                            dataGridViewBooksResult.AutoResizeColumns();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
}
