﻿using System;
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
    public partial class InventoryManagement : Form
    {
        public InventoryManagement()
        {
            InitializeComponent();
        }

        private void returnHome_Click(object sender, EventArgs e)
        {
            MainMenu menu_form = new MainMenu();
            this.Hide();
            menu_form.Show();
        }
    }
}
