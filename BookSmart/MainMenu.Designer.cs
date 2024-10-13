namespace BookSmart
{
    partial class MainMenu
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
            this.label1 = new System.Windows.Forms.Label();
            this.ManageInventoryButton = new System.Windows.Forms.Button();
            this.SalesDataButton = new System.Windows.Forms.Button();
            this.SearchWindowButton = new System.Windows.Forms.Button();
            this.QuitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.label1.Location = new System.Drawing.Point(217, 52);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "BookSmart Home";
            // 
            // ManageInventoryButton
            // 
            this.ManageInventoryButton.Location = new System.Drawing.Point(197, 144);
            this.ManageInventoryButton.Margin = new System.Windows.Forms.Padding(2);
            this.ManageInventoryButton.Name = "ManageInventoryButton";
            this.ManageInventoryButton.Size = new System.Drawing.Size(189, 34);
            this.ManageInventoryButton.TabIndex = 2;
            this.ManageInventoryButton.Text = "Manage Inventory";
            this.ManageInventoryButton.UseVisualStyleBackColor = true;
            this.ManageInventoryButton.Click += new System.EventHandler(this.ManageInventoryButton_Click);
            // 
            // SalesDataButton
            // 
            this.SalesDataButton.Location = new System.Drawing.Point(197, 183);
            this.SalesDataButton.Margin = new System.Windows.Forms.Padding(2);
            this.SalesDataButton.Name = "SalesDataButton";
            this.SalesDataButton.Size = new System.Drawing.Size(189, 34);
            this.SalesDataButton.TabIndex = 3;
            this.SalesDataButton.Text = "View Sales Data";
            this.SalesDataButton.UseVisualStyleBackColor = true;
            this.SalesDataButton.Click += new System.EventHandler(this.SalesDataButton_Click);
            // 
            // SearchWindowButton
            // 
            this.SearchWindowButton.Location = new System.Drawing.Point(197, 105);
            this.SearchWindowButton.Margin = new System.Windows.Forms.Padding(2);
            this.SearchWindowButton.Name = "SearchWindowButton";
            this.SearchWindowButton.Size = new System.Drawing.Size(189, 34);
            this.SearchWindowButton.TabIndex = 7;
            this.SearchWindowButton.Text = "Search and Browse";
            this.SearchWindowButton.UseVisualStyleBackColor = true;
            this.SearchWindowButton.Click += new System.EventHandler(this.SearchWindowButton_Click);
            // 
            // QuitButton
            // 
            this.QuitButton.Location = new System.Drawing.Point(197, 222);
            this.QuitButton.Name = "QuitButton";
            this.QuitButton.Size = new System.Drawing.Size(189, 31);
            this.QuitButton.TabIndex = 8;
            this.QuitButton.Text = "Quit BookSmart";
            this.QuitButton.UseVisualStyleBackColor = true;
            this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.QuitButton);
            this.Controls.Add(this.SearchWindowButton);
            this.Controls.Add(this.SalesDataButton);
            this.Controls.Add(this.ManageInventoryButton);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainMenu";
            this.Text = "BookSmart - Home";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ManageInventoryButton;
        private System.Windows.Forms.Button SalesDataButton;
        private System.Windows.Forms.Button SearchWindowButton;
        private System.Windows.Forms.Button QuitButton;
    }
}

