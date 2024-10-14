namespace BookSmart
{
    partial class SalesData
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.comboBoxBookTitle = new System.Windows.Forms.ComboBox();
            this.btnFetchData = new System.Windows.Forms.Button();
            this.dataGridViewResults = new System.Windows.Forms.DataGridView();
            this.salesChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.returnHome = new System.Windows.Forms.Button();
            this.btnTop50Sold = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salesChart)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxBookTitle
            // 
            this.comboBoxBookTitle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBookTitle.FormattingEnabled = true;
            this.comboBoxBookTitle.Location = new System.Drawing.Point(12, 12);
            this.comboBoxBookTitle.Name = "comboBoxBookTitle";
            this.comboBoxBookTitle.Size = new System.Drawing.Size(200, 21);
            this.comboBoxBookTitle.TabIndex = 0;
            this.comboBoxBookTitle.SelectedIndexChanged += new System.EventHandler(this.comboBoxBookTitle_SelectedIndexChanged);
            // 
            // btnFetchData
            // 
            this.btnFetchData.Location = new System.Drawing.Point(218, 10);
            this.btnFetchData.Name = "btnFetchData";
            this.btnFetchData.Size = new System.Drawing.Size(75, 23);
            this.btnFetchData.TabIndex = 2;
            this.btnFetchData.Text = "Fetch Data";
            this.btnFetchData.UseVisualStyleBackColor = true;
            this.btnFetchData.Click += new System.EventHandler(this.btnFetchData_Click);
            // 
            // dataGridViewResults
            // 
            this.dataGridViewResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewResults.Location = new System.Drawing.Point(12, 39);
            this.dataGridViewResults.Name = "dataGridViewResults";
            this.dataGridViewResults.Size = new System.Drawing.Size(760, 300);
            this.dataGridViewResults.TabIndex = 3;
            // 
            // salesChart
            // 
            this.salesChart.Location = new System.Drawing.Point(12, 345);
            this.salesChart.Name = "salesChart";
            this.salesChart.Size = new System.Drawing.Size(760, 300);
            this.salesChart.TabIndex = 4;
            this.salesChart.Text = "chart1";
            // 
            // returnHome
            // 
            this.returnHome.Location = new System.Drawing.Point(12, 660);
            this.returnHome.Name = "returnHome";
            this.returnHome.Size = new System.Drawing.Size(75, 23);
            this.returnHome.TabIndex = 5;
            this.returnHome.Text = "Home";
            this.returnHome.UseVisualStyleBackColor = true;
            this.returnHome.Click += new System.EventHandler(this.returnHome_Click);
            // 
            // btnTop50Sold
            // 
            this.btnTop50Sold.Location = new System.Drawing.Point(100, 660);
            this.btnTop50Sold.Name = "btnTop50Sold";
            this.btnTop50Sold.Size = new System.Drawing.Size(75, 23);
            this.btnTop50Sold.TabIndex = 6;
            this.btnTop50Sold.Text = "Top 50 Sold";
            this.btnTop50Sold.UseVisualStyleBackColor = true;
            this.btnTop50Sold.Click += new System.EventHandler(this.btnTop50Sold_Click);
            // 
            // SalesData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 711);
            this.Controls.Add(this.btnTop50Sold);
            this.Controls.Add(this.returnHome);
            this.Controls.Add(this.salesChart);
            this.Controls.Add(this.dataGridViewResults);
            this.Controls.Add(this.btnFetchData);
            this.Controls.Add(this.comboBoxBookTitle);
            this.Name = "SalesData";
            this.Text = "Sales Data";
            this.Load += new System.EventHandler(this.SalesData_Load);
            this.Resize += new System.EventHandler(this.SalesData_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salesChart)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.ComboBox comboBoxBookTitle;
        private System.Windows.Forms.Button btnFetchData;
        private System.Windows.Forms.DataGridView dataGridViewResults;
        private System.Windows.Forms.DataVisualization.Charting.Chart salesChart;
        private System.Windows.Forms.Button returnHome;
        private System.Windows.Forms.Button btnTop50Sold;
    }
}
