namespace Yellow_Bucket
{
    partial class ListAllMovies
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
            this.listBoxOfAllMovies = new System.Windows.Forms.ListBox();
            this.buttonToSearchByMovieTitle = new System.Windows.Forms.Button();
            this.mainMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.BackColor = System.Drawing.Color.Gold;
            this.mainMenuStrip.Dock = System.Windows.Forms.DockStyle.Left;
            this.mainMenuStrip.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hOMEToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(73, 497);
            this.mainMenuStrip.TabIndex = 1;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // hOMEToolStripMenuItem
            // 
            this.hOMEToolStripMenuItem.Name = "hOMEToolStripMenuItem";
            this.hOMEToolStripMenuItem.Size = new System.Drawing.Size(60, 25);
            this.hOMEToolStripMenuItem.Text = "HOME";
            this.hOMEToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.hOMEToolStripMenuItem.Click += new System.EventHandler(this.hOMEToolStripMenuItem_Click);
            // 
            // listBoxOfAllMovies
            // 
            this.listBoxOfAllMovies.FormattingEnabled = true;
            this.listBoxOfAllMovies.Location = new System.Drawing.Point(145, 78);
            this.listBoxOfAllMovies.Name = "listBoxOfAllMovies";
            this.listBoxOfAllMovies.Size = new System.Drawing.Size(555, 407);
            this.listBoxOfAllMovies.TabIndex = 2;
            // 
            // buttonToSearchByMovieTitle
            // 
            this.buttonToSearchByMovieTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonToSearchByMovieTitle.Location = new System.Drawing.Point(288, 12);
            this.buttonToSearchByMovieTitle.Name = "buttonToSearchByMovieTitle";
            this.buttonToSearchByMovieTitle.Size = new System.Drawing.Size(168, 23);
            this.buttonToSearchByMovieTitle.TabIndex = 3;
            this.buttonToSearchByMovieTitle.Text = "Search By Movie Title";
            this.buttonToSearchByMovieTitle.UseVisualStyleBackColor = true;
            this.buttonToSearchByMovieTitle.Click += new System.EventHandler(this.buttonToSearchByMovieTitle_Click);
            // 
            // ListAllMovies
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 497);
            this.Controls.Add(this.buttonToSearchByMovieTitle);
            this.Controls.Add(this.listBoxOfAllMovies);
            this.Controls.Add(this.mainMenuStrip);
            this.MainMenuStrip = this.mainMenuStrip;
            this.Name = "ListAllMovies";
            this.Text = "YELLOW BUCKET -- LIST ALL MOVIES";
            this.Load += new System.EventHandler(this.ListAllMovies_Load);
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem hOMEToolStripMenuItem;
        private System.Windows.Forms.ListBox listBoxOfAllMovies;
        private System.Windows.Forms.Button buttonToSearchByMovieTitle;
    }
}