using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Windows.Forms.DataVisualization.Charting;

namespace BookSmart
{
    public partial class MainMenu : Form
    {
        private Size formOriginalSize;
        private Rectangle recTxt2;
        private Rectangle recBut2;
        private Rectangle recBut3;
        private Rectangle recBut4;
        private Rectangle recBut5;
        public MainMenu()
        {
            InitializeComponent();
            this.Resize += MainMenu_Resiz;
            formOriginalSize = this.Size;
            recBut2 = new Rectangle(SearchWindowButton.Location, SearchWindowButton.Size);
            recTxt2 = new Rectangle(label1.Location, label1.Size);
            recBut3 = new Rectangle(ManageInventoryButton.Location, ManageInventoryButton.Size);
            recBut4 = new Rectangle(SalesDataButton.Location, SalesDataButton.Size);
            recBut5 = new Rectangle(QuitButton.Location, QuitButton.Size);
        }


        private void MainMenu_Resiz(object sender, EventArgs e)
        {
            resize_Control(SearchWindowButton, recBut2);
            resize_Control(label1, recTxt2);
            resize_Control(ManageInventoryButton, recBut3);
            resize_Control(SalesDataButton, recBut4);
            resize_Control(QuitButton, recBut5);
        }

        private void resize_Control(Control c, Rectangle r)
        {
            float xRatio = (float)(this.Width) / (float)(formOriginalSize.Width);
            float yRatio = (float)(this.Height) / (float)(formOriginalSize.Height);
            int newX = (int)(r.X * xRatio);
            int newY = (int)(r.Y * yRatio);

            int newWidth = (int)(r.Width * xRatio);
            int newHeight = (int)(r.Height * yRatio);

            c.Location = new Point(newX, newY);
            c.Size = new Size(newWidth, newHeight);
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

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
