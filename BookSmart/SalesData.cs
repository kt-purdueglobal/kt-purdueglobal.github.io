using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookSmart
{
    public partial class SalesData : Form
    {
        private Size formOriginalSize;
        private Rectangle recTxt1;
        private Rectangle recChart1;
        private Rectangle recGrid1;
        private Rectangle recBut1;
        private Rectangle recHome1;
        public SalesData()
        {
            InitializeComponent();
            this.Resize += SalesData_Resiz;
            formOriginalSize = this.Size;
            recBut1 = new Rectangle(button1.Location, button1.Size);
            recTxt1 = new Rectangle(textBox1.Location, textBox1.Size);
            recChart1 = new Rectangle(chart1.Location, chart1.Size);
            recGrid1 = new Rectangle(dataGridView1.Location, dataGridView1.Size);
            recHome1 = new Rectangle(returnHome.Location, returnHome.Size);
            textBox1.Multiline = true;
        }


        private void SalesData_Resiz(object sender, EventArgs e)
        {
            resize_Control(button1, recBut1);
            resize_Control(textBox1, recTxt1);
            resize_Control(chart1, recChart1);
            resize_Control(dataGridView1, recGrid1);
            resize_Control(returnHome, recHome1);
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

        private void SalesData_Load(object sender, EventArgs e)
        {

        }

        private void returnHome_Click(object sender, EventArgs e)
        {
            MainMenu menu_form = new MainMenu();
            this.Hide();
            menu_form.Show();
        }
    }
}
