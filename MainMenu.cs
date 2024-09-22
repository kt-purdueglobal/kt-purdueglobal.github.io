using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookSmart
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void SearchWindowButton_Click(object sender, EventArgs e)
        {
            SearchForm search_form = new SearchForm();
            this.Hide();
            search_form.Show();

        }

        private void ManageInventoryButton_Click(object sender, EventArgs e)
        {
            InventoryManagement inventory_management = new InventoryManagement();
            this.Hide();
            inventory_management.Show();
        }

        private void SalesDataButton_Click(object sender, EventArgs e)
        {
            SalesData sales_form = new SalesData();
            this.Hide();
            sales_form.Show();
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
