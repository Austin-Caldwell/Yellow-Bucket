namespace Yellow_Bucket
{
    partial class Movies
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
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.hOMEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cUSTOMERSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kIOSKSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mOVIESToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBOUTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.qUITToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.genreLabel = new System.Windows.Forms.Label();
            this.movieTitleComboBox = new System.Windows.Forms.ComboBox();
            this.movieTitleLabel = new System.Windows.Forms.Label();
            this.genreComboBox = new System.Windows.Forms.ComboBox();
            this.mainMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.BackColor = System.Drawing.Color.Gold;
            this.mainMenuStrip.Dock = System.Windows.Forms.DockStyle.Left;
            this.mainMenuStrip.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hOMEToolStripMenuItem,
            this.cUSTOMERSToolStripMenuItem,
            this.kIOSKSToolStripMenuItem,
            this.mOVIESToolStripMenuItem,
            this.aBOUTToolStripMenuItem,
            this.qUITToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(118, 447);
            this.mainMenuStrip.TabIndex = 0;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // hOMEToolStripMenuItem
            // 
            this.hOMEToolStripMenuItem.Name = "hOMEToolStripMenuItem";
            this.hOMEToolStripMenuItem.Padding = new System.Windows.Forms.Padding(4, 0, 4, 2);
            this.hOMEToolStripMenuItem.Size = new System.Drawing.Size(105, 27);
            this.hOMEToolStripMenuItem.Text = "HOME";
            this.hOMEToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.hOMEToolStripMenuItem.Click += new System.EventHandler(this.hOMEToolStripMenuItem_Click);
            // 
            // cUSTOMERSToolStripMenuItem
            // 
            this.cUSTOMERSToolStripMenuItem.Name = "cUSTOMERSToolStripMenuItem";
            this.cUSTOMERSToolStripMenuItem.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.cUSTOMERSToolStripMenuItem.Size = new System.Drawing.Size(105, 29);
            this.cUSTOMERSToolStripMenuItem.Text = "CUSTOMERS";
            this.cUSTOMERSToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cUSTOMERSToolStripMenuItem.Click += new System.EventHandler(this.cUSTOMERSToolStripMenuItem_Click);
            // 
            // kIOSKSToolStripMenuItem
            // 
            this.kIOSKSToolStripMenuItem.Name = "kIOSKSToolStripMenuItem";
            this.kIOSKSToolStripMenuItem.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.kIOSKSToolStripMenuItem.Size = new System.Drawing.Size(105, 29);
            this.kIOSKSToolStripMenuItem.Text = "KIOSKS";
            this.kIOSKSToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.kIOSKSToolStripMenuItem.Click += new System.EventHandler(this.kIOSKSToolStripMenuItem_Click);
            // 
            // mOVIESToolStripMenuItem
            // 
            this.mOVIESToolStripMenuItem.Name = "mOVIESToolStripMenuItem";
            this.mOVIESToolStripMenuItem.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.mOVIESToolStripMenuItem.Size = new System.Drawing.Size(105, 29);
            this.mOVIESToolStripMenuItem.Text = "MOVIES";
            this.mOVIESToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mOVIESToolStripMenuItem.Click += new System.EventHandler(this.mOVIESToolStripMenuItem_Click);
            // 
            // aBOUTToolStripMenuItem
            // 
            this.aBOUTToolStripMenuItem.Name = "aBOUTToolStripMenuItem";
            this.aBOUTToolStripMenuItem.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.aBOUTToolStripMenuItem.Size = new System.Drawing.Size(105, 29);
            this.aBOUTToolStripMenuItem.Text = "ABOUT";
            this.aBOUTToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.aBOUTToolStripMenuItem.Click += new System.EventHandler(this.aBOUTToolStripMenuItem_Click);
            // 
            // qUITToolStripMenuItem
            // 
            this.qUITToolStripMenuItem.Name = "qUITToolStripMenuItem";
            this.qUITToolStripMenuItem.Padding = new System.Windows.Forms.Padding(4, 2, 4, 0);
            this.qUITToolStripMenuItem.Size = new System.Drawing.Size(105, 27);
            this.qUITToolStripMenuItem.Text = "QUIT";
            this.qUITToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.qUITToolStripMenuItem.Click += new System.EventHandler(this.qUITToolStripMenuItem_Click);
            // 
            // genreLabel
            // 
            this.genreLabel.AutoSize = true;
            this.genreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.genreLabel.Location = new System.Drawing.Point(162, 92);
            this.genreLabel.Name = "genreLabel";
            this.genreLabel.Size = new System.Drawing.Size(58, 20);
            this.genreLabel.TabIndex = 1;
            this.genreLabel.Text = "Genre:";
            // 
            // movieTitleComboBox
            // 
            this.movieTitleComboBox.FormattingEnabled = true;
            this.movieTitleComboBox.Location = new System.Drawing.Point(226, 55);
            this.movieTitleComboBox.Name = "movieTitleComboBox";
            this.movieTitleComboBox.Size = new System.Drawing.Size(121, 21);
            this.movieTitleComboBox.TabIndex = 3;
            // 
            // movieTitleLabel
            // 
            this.movieTitleLabel.AutoSize = true;
            this.movieTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.movieTitleLabel.Location = new System.Drawing.Point(133, 56);
            this.movieTitleLabel.Name = "movieTitleLabel";
            this.movieTitleLabel.Size = new System.Drawing.Size(87, 20);
            this.movieTitleLabel.TabIndex = 4;
            this.movieTitleLabel.Text = "Movie Title:";
            // 
            // genreComboBox
            // 
            this.genreComboBox.FormattingEnabled = true;
            this.genreComboBox.Location = new System.Drawing.Point(226, 91);
            this.genreComboBox.Name = "genreComboBox";
            this.genreComboBox.Size = new System.Drawing.Size(121, 21);
            this.genreComboBox.TabIndex = 5;
            // 
            // Movies
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 447);
            this.Controls.Add(this.genreComboBox);
            this.Controls.Add(this.movieTitleLabel);
            this.Controls.Add(this.movieTitleComboBox);
            this.Controls.Add(this.genreLabel);
            this.Controls.Add(this.mainMenuStrip);
            this.MainMenuStrip = this.mainMenuStrip;
            this.Name = "Movies";
            this.Text = "Movies";
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem hOMEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cUSTOMERSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kIOSKSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mOVIESToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBOUTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem qUITToolStripMenuItem;
        private System.Windows.Forms.Label genreLabel;
        private System.Windows.Forms.ComboBox movieTitleComboBox;
        private System.Windows.Forms.Label movieTitleLabel;
        private System.Windows.Forms.ComboBox genreComboBox;
    }
}