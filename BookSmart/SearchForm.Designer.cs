namespace BookSmart
{
    partial class SearchForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtboxSearch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.dataGridViewBooksResult = new System.Windows.Forms.DataGridView();
            this.button6 = new System.Windows.Forms.Button();
            this.returnHome = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBooksResult)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(9, 84);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(162, 19);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtboxSearch
            // 
            this.txtboxSearch.Location = new System.Drawing.Point(9, 61);
            this.txtboxSearch.Margin = new System.Windows.Forms.Padding(2);
            this.txtboxSearch.Name = "txtboxSearch";
            this.txtboxSearch.Size = new System.Drawing.Size(163, 20);
            this.txtboxSearch.TabIndex = 2;
            this.txtboxSearch.Text = "Input Search Here";
            this.txtboxSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.label2.Location = new System.Drawing.Point(64, 42);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Search";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.label1.Location = new System.Drawing.Point(64, 136);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Browse";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(9, 166);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(162, 19);
            this.button3.TabIndex = 8;
            this.button3.Text = "Browse Best Sellers";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.btnBestSellers_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(9, 189);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(162, 19);
            this.button4.TabIndex = 9;
            this.button4.Text = "Browse Top Rated";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.btnTopRated_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(9, 213);
            this.button5.Margin = new System.Windows.Forms.Padding(2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(162, 19);
            this.button5.TabIndex = 10;
            this.button5.Text = "Browse Recently Added";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.btnRecentlyAdded_Click);
            // 
            // dataGridViewBooksResult
            // 
            this.dataGridViewBooksResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewBooksResult.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewBooksResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBooksResult.Location = new System.Drawing.Point(242, 23);
            this.dataGridViewBooksResult.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewBooksResult.Name = "dataGridViewBooksResult";
            this.dataGridViewBooksResult.RowHeadersWidth = 51;
            this.dataGridViewBooksResult.RowTemplate.Height = 24;
            this.dataGridViewBooksResult.Size = new System.Drawing.Size(882, 306);
            this.dataGridViewBooksResult.TabIndex = 11;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(10, 266);
            this.button6.Margin = new System.Windows.Forms.Padding(2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(161, 19);
            this.button6.TabIndex = 12;
            this.button6.Text = "View All";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.bbtnViewAll_Click);
            // 
            // returnHome
            // 
            this.returnHome.Location = new System.Drawing.Point(9, 290);
            this.returnHome.Margin = new System.Windows.Forms.Padding(2);
            this.returnHome.Name = "returnHome";
            this.returnHome.Size = new System.Drawing.Size(161, 19);
            this.returnHome.TabIndex = 13;
            this.returnHome.Text = "Return Home";
            this.returnHome.UseVisualStyleBackColor = true;
            this.returnHome.Click += new System.EventHandler(this.returnHome_Click);
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1135, 371);
            this.Controls.Add(this.returnHome);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.dataGridViewBooksResult);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtboxSearch);
            this.Controls.Add(this.btnSearch);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "SearchForm";
            this.Text = "BookSmart - Search & Browse";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBooksResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtboxSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.DataGridView dataGridViewBooksResult;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button returnHome;
    }
}