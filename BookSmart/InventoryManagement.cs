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

        private string connectionString = "Server=DESKTOP-1UT63KC\\SQLEXPRESS;Database=BookSmart;Trusted_Connection=True;";

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
            string authorId = textBox3.Text;
            string price = textBox5.Text;
            string isbn = textBox6.Text;
            string series = textBox7.Text;
            string averagerating = textBox8.Text;
            string publisherId = textBox9.Text;
            string published = textBox10.Text;

            int quantityInStock = Convert.ToInt32(textBox4.Text);
            string aisleNumber = textBox12.Text;
            string shelfNumber = textBox13.Text;


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

                            UpdateInventory(title, quantityInStock, aisleNumber, shelfNumber);
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

        private void UpdateInventory(string title, int quantityInStock, string aisleNumber, string shelfNumber)
        {
            string updateInventoryQuery = "UPDATE Inventory SET QuantityInStock = @QuantityInStock, AisleNumber = @AisleNumber, ShelfNumber = @ShelfNumber WHERE BookID = (SELECT BookID FROM Book WHERE Title = @Title)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(updateInventoryQuery, connection))
                {
                    command.Parameters.Add("@QuantityInStock", SqlDbType.Int).Value = quantityInStock;
                    command.Parameters.Add("@AisleNumber", SqlDbType.NVarChar).Value = aisleNumber;
                    command.Parameters.Add("@ShelfNumber", SqlDbType.NVarChar).Value = shelfNumber;
                    command.Parameters.Add("@Title", SqlDbType.NVarChar).Value = title;

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Inventory updated successfully!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error updating inventory: {ex.Message}");
                    }
                }
            }
        }


        private void RemoveBook()
        {

            string title = textBox1.Text;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();


                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {

                        string removeInventoryQuery = "DELETE FROM Inventory WHERE BookID In (SELECT BookID FROM Book WHERE Title = @Title)";
                        using (SqlCommand command = new SqlCommand(removeInventoryQuery, connection, transaction))
                        {
                            command.Parameters.Add("@Title", SqlDbType.NVarChar).Value = title;
                            command.ExecuteNonQuery();
                        }

                        string removeBookQuery = "DELETE FROM Book WHERE Title = @Title";
                        using (SqlCommand command = new SqlCommand(removeBookQuery, connection, transaction))
                        {
                            command.Parameters.Add("@Title", SqlDbType.NVarChar).Value = title;

                            int rowsAffected = command.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Book and related records removed successfully.");
                            }
                            else
                            {
                                MessageBox.Show("No book found with that title.");
                            }
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"Error: {ex.Message}");
                    }
                }
            }
        }



        private void AddBook()
        {

            string title = textBox1.Text;
            string genre = textBox2.Text;
            string authorId = textBox3.Text;
            string price = textBox5.Text;
            string isbn = textBox6.Text;
            string series = textBox7.Text;
            string averagerating = textBox8.Text;
            string publisherId = textBox9.Text;
            string published = textBox10.Text;

            int quantityInStock = Convert.ToInt32(textBox4.Text);
            string aisleNumber = textBox12.Text;
            string shelfNumber = textBox13.Text;



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


            if (!int.TryParse(authorId, out int parsedAuthorId))
            {
                MessageBox.Show("Please enter a valid numeric value for AuthorID.");
                return;
            }


            if (!IsAuthorIDValid(parsedAuthorId))
            {
                DialogResult result = MessageBox.Show("The AuthorID does not exist. Would you like to add a new author?", "Invalid AuthorID", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    string newAuthorName = PromptForAuthorDetails();
                    if (string.IsNullOrEmpty(newAuthorName))
                    {
                        MessageBox.Show("Author name cannot be empty.");
                        return;
                    }


                    parsedAuthorId = AddNewAuthor(newAuthorName);
                    if (parsedAuthorId == -1)
                    {
                        MessageBox.Show("Failed to add new author.");
                        return;
                    }
                }
                else
                {
                    return;
                }
            }


            string query = "INSERT INTO Book (Title, Genre, AuthorID, Price, ISBN, Series, AverageRating, PublisherID, Published) VALUES (@Title, @Genre, @AuthorID, @Price, @ISBN, @Series, @AverageRating, @PublisherID, @Published)" + "SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.Add("@Title", SqlDbType.NVarChar).Value = title;
                    command.Parameters.Add("@Genre", SqlDbType.NVarChar).Value = genre;
                    command.Parameters.Add("@AuthorID", SqlDbType.Int).Value = parsedAuthorId;
                    command.Parameters.Add("@Price", SqlDbType.NVarChar).Value = price;
                    command.Parameters.Add("@ISBN", SqlDbType.NVarChar).Value = isbn;
                    command.Parameters.Add("@Series", SqlDbType.NVarChar).Value = series;
                    command.Parameters.Add("@AverageRating", SqlDbType.NVarChar).Value = averagerating;
                    command.Parameters.Add("@PublisherID", SqlDbType.Int).Value = parsedPublisherId;
                    command.Parameters.Add("@Published", SqlDbType.NVarChar).Value = published;


                    try
                    {

                        connection.Open();

                        int newBookId = Convert.ToInt32(command.ExecuteScalar());

                        MessageBox.Show("Book Added Successfully! BookID: " + newBookId);

                        AddInventory(newBookId, quantityInStock, aisleNumber, shelfNumber);

                    }

                    catch (Exception ex)
                    {

                        MessageBox.Show($"Error: {ex.Message}");
                    }
                }
            }
        }

        private void AddInventory(int bookId, int quantityInStock, string aisleNumber, string shelfNumber)
        {
            string query = "INSERT INTO Inventory (BookID, QuantityInStock, AisleNumber, ShelfNumber) VALUES (@BookID, @QuantityInStock, @AisleNumber, @ShelfNumber)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.Add("@BookID", SqlDbType.Int).Value = bookId;
                    command.Parameters.Add("@QuantityInStock", SqlDbType.Int).Value = quantityInStock;
                    command.Parameters.Add("@AisleNumber", SqlDbType.NVarChar).Value = aisleNumber;
                    command.Parameters.Add("@ShelfNumber", SqlDbType.NVarChar).Value = shelfNumber;

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Inventory entry added successfully for BookID: " + bookId);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}");
                    }
                }
            }
        }

        private bool IsAuthorIDValid(int authorId)
        {
            string query = "SELECT COUNT (1) FROM Author WHERE AuthorID = @AuthorID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@AuthorID", SqlDbType.Int).Value = authorId;

                    try
                    {
                        connection.Open();
                        int count = (int)command.ExecuteScalar();
                        return count > 0;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error checking AuthorID: {ex.Message}");
                        return false;
                    }
                }
            }
        }

        private string PromptForAuthorDetails()
        {
            string newAuthorName = Microsoft.VisualBasic.Interaction.InputBox("Enter new Author Name:", "Add New Author", "", -1, -1);
            return newAuthorName;
        }


        private int AddNewAuthor(string authorName)
        {
            string query = "INSERT INTO Author (AuthorName) OUTPUT INSERTED.AuthorID VALUES (@AuthorName)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@AuthorName", SqlDbType.NVarChar).Value = authorName;


                    try
                    {
                        connection.Open();
                        int newAuthorId = (int)command.ExecuteScalar();
                        return newAuthorId;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error adding author: {ex.Message}");
                        return -1;
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