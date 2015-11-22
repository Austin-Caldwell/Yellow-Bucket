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
            this.rENTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rETURNToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rEVIEWToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBOUTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.qUITToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listBoxOfAllMovies = new System.Windows.Forms.ListBox();
            this.lblAllMoviesList = new System.Windows.Forms.Label();
            this.buttonToAddMovie = new System.Windows.Forms.Button();
            this.buttonToEditMovieInfo = new System.Windows.Forms.Button();
            this.buttonToDeleteMovie = new System.Windows.Forms.Button();
            this.buttonToViewMovieDetails = new System.Windows.Forms.Button();
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
            this.rENTToolStripMenuItem,
            this.rETURNToolStripMenuItem,
            this.rEVIEWToolStripMenuItem,
            this.aBOUTToolStripMenuItem,
            this.qUITToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(118, 729);
            this.mainMenuStrip.TabIndex = 1;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // hOMEToolStripMenuItem
            // 
            this.hOMEToolStripMenuItem.Name = "hOMEToolStripMenuItem";
            this.hOMEToolStripMenuItem.Padding = new System.Windows.Forms.Padding(4, 0, 4, 2);
            this.hOMEToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.H)));
            this.hOMEToolStripMenuItem.Size = new System.Drawing.Size(105, 27);
            this.hOMEToolStripMenuItem.Text = "HOME";
            this.hOMEToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.hOMEToolStripMenuItem.Click += new System.EventHandler(this.hOMEToolStripMenuItem_Click);
            // 
            // cUSTOMERSToolStripMenuItem
            // 
            this.cUSTOMERSToolStripMenuItem.Name = "cUSTOMERSToolStripMenuItem";
            this.cUSTOMERSToolStripMenuItem.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.cUSTOMERSToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.C)));
            this.cUSTOMERSToolStripMenuItem.Size = new System.Drawing.Size(105, 29);
            this.cUSTOMERSToolStripMenuItem.Text = "CUSTOMERS";
            this.cUSTOMERSToolStripMenuItem.Click += new System.EventHandler(this.cUSTOMERSToolStripMenuItem_Click);
            // 
            // kIOSKSToolStripMenuItem
            // 
            this.kIOSKSToolStripMenuItem.Name = "kIOSKSToolStripMenuItem";
            this.kIOSKSToolStripMenuItem.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.kIOSKSToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.K)));
            this.kIOSKSToolStripMenuItem.Size = new System.Drawing.Size(105, 29);
            this.kIOSKSToolStripMenuItem.Text = "KIOSKS";
            this.kIOSKSToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.kIOSKSToolStripMenuItem.Click += new System.EventHandler(this.kIOSKSToolStripMenuItem_Click);
            // 
            // mOVIESToolStripMenuItem
            // 
            this.mOVIESToolStripMenuItem.Name = "mOVIESToolStripMenuItem";
            this.mOVIESToolStripMenuItem.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.mOVIESToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.M)));
            this.mOVIESToolStripMenuItem.Size = new System.Drawing.Size(105, 29);
            this.mOVIESToolStripMenuItem.Text = "MOVIES";
            this.mOVIESToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mOVIESToolStripMenuItem.Click += new System.EventHandler(this.mOVIESToolStripMenuItem_Click);
            // 
            // rENTToolStripMenuItem
            // 
            this.rENTToolStripMenuItem.Name = "rENTToolStripMenuItem";
            this.rENTToolStripMenuItem.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.rENTToolStripMenuItem.Size = new System.Drawing.Size(105, 29);
            this.rENTToolStripMenuItem.Text = "RENT";
            this.rENTToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rENTToolStripMenuItem.Click += new System.EventHandler(this.rENTToolStripMenuItem_Click);
            // 
            // rETURNToolStripMenuItem
            // 
            this.rETURNToolStripMenuItem.Name = "rETURNToolStripMenuItem";
            this.rETURNToolStripMenuItem.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.rETURNToolStripMenuItem.Size = new System.Drawing.Size(105, 29);
            this.rETURNToolStripMenuItem.Text = "RETURN";
            this.rETURNToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rETURNToolStripMenuItem.Click += new System.EventHandler(this.rETURNToolStripMenuItem_Click);
            // 
            // rEVIEWToolStripMenuItem
            // 
            this.rEVIEWToolStripMenuItem.Name = "rEVIEWToolStripMenuItem";
            this.rEVIEWToolStripMenuItem.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.rEVIEWToolStripMenuItem.Size = new System.Drawing.Size(105, 29);
            this.rEVIEWToolStripMenuItem.Text = "REVIEW";
            this.rEVIEWToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rEVIEWToolStripMenuItem.Click += new System.EventHandler(this.rEVIEWToolStripMenuItem_Click);
            // 
            // aBOUTToolStripMenuItem
            // 
            this.aBOUTToolStripMenuItem.Name = "aBOUTToolStripMenuItem";
            this.aBOUTToolStripMenuItem.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.aBOUTToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.A)));
            this.aBOUTToolStripMenuItem.Size = new System.Drawing.Size(105, 29);
            this.aBOUTToolStripMenuItem.Text = "ABOUT";
            this.aBOUTToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.aBOUTToolStripMenuItem.Click += new System.EventHandler(this.aBOUTToolStripMenuItem_Click);
            // 
            // qUITToolStripMenuItem
            // 
            this.qUITToolStripMenuItem.Name = "qUITToolStripMenuItem";
            this.qUITToolStripMenuItem.Padding = new System.Windows.Forms.Padding(4, 2, 4, 0);
            this.qUITToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.Q)));
            this.qUITToolStripMenuItem.Size = new System.Drawing.Size(105, 27);
            this.qUITToolStripMenuItem.Text = "QUIT";
            this.qUITToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.qUITToolStripMenuItem.Click += new System.EventHandler(this.qUITToolStripMenuItem_Click);
            // 
            // listBoxOfAllMovies
            // 
            this.listBoxOfAllMovies.BackColor = System.Drawing.SystemColors.Window;
            this.listBoxOfAllMovies.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.listBoxOfAllMovies.FormattingEnabled = true;
            this.listBoxOfAllMovies.ItemHeight = 16;
            this.listBoxOfAllMovies.Location = new System.Drawing.Point(125, 52);
            this.listBoxOfAllMovies.Name = "listBoxOfAllMovies";
            this.listBoxOfAllMovies.Size = new System.Drawing.Size(871, 660);
            this.listBoxOfAllMovies.TabIndex = 0;
            // 
            // lblAllMoviesList
            // 
            this.lblAllMoviesList.AutoSize = true;
            this.lblAllMoviesList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblAllMoviesList.Location = new System.Drawing.Point(121, 19);
            this.lblAllMoviesList.Name = "lblAllMoviesList";
            this.lblAllMoviesList.Size = new System.Drawing.Size(261, 20);
            this.lblAllMoviesList.TabIndex = 3;
            this.lblAllMoviesList.Text = "All Movies Offered by Yellow Bucket";
            // 
            // buttonToAddMovie
            // 
            this.buttonToAddMovie.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonToAddMovie.Location = new System.Drawing.Point(435, 16);
            this.buttonToAddMovie.Name = "buttonToAddMovie";
            this.buttonToAddMovie.Size = new System.Drawing.Size(124, 23);
            this.buttonToAddMovie.TabIndex = 1;
            this.buttonToAddMovie.Text = "Add A Movie";
            this.buttonToAddMovie.UseVisualStyleBackColor = true;
            this.buttonToAddMovie.Click += new System.EventHandler(this.buttonToAddMovie_Click);
            // 
            // buttonToEditMovieInfo
            // 
            this.buttonToEditMovieInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonToEditMovieInfo.Location = new System.Drawing.Point(565, 15);
            this.buttonToEditMovieInfo.Name = "buttonToEditMovieInfo";
            this.buttonToEditMovieInfo.Size = new System.Drawing.Size(124, 23);
            this.buttonToEditMovieInfo.TabIndex = 2;
            this.buttonToEditMovieInfo.Text = "Edit Movie Info";
            this.buttonToEditMovieInfo.UseVisualStyleBackColor = true;
            this.buttonToEditMovieInfo.Click += new System.EventHandler(this.buttonToEditMovieInfo_Click);
            // 
            // buttonToDeleteMovie
            // 
            this.buttonToDeleteMovie.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonToDeleteMovie.Location = new System.Drawing.Point(851, 15);
            this.buttonToDeleteMovie.Name = "buttonToDeleteMovie";
            this.buttonToDeleteMovie.Size = new System.Drawing.Size(124, 23);
            this.buttonToDeleteMovie.TabIndex = 4;
            this.buttonToDeleteMovie.Text = "Delete A Movie";
            this.buttonToDeleteMovie.UseVisualStyleBackColor = true;
            this.buttonToDeleteMovie.Click += new System.EventHandler(this.buttonToDeleteMovie_Click);
            // 
            // buttonToViewMovieDetails
            // 
            this.buttonToViewMovieDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonToViewMovieDetails.Location = new System.Drawing.Point(695, 15);
            this.buttonToViewMovieDetails.Name = "buttonToViewMovieDetails";
            this.buttonToViewMovieDetails.Size = new System.Drawing.Size(150, 23);
            this.buttonToViewMovieDetails.TabIndex = 3;
            this.buttonToViewMovieDetails.Text = "View Movie Details";
            this.buttonToViewMovieDetails.UseVisualStyleBackColor = true;
            // 
            // Movies
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.buttonToViewMovieDetails);
            this.Controls.Add(this.buttonToDeleteMovie);
            this.Controls.Add(this.buttonToEditMovieInfo);
            this.Controls.Add(this.buttonToAddMovie);
            this.Controls.Add(this.lblAllMoviesList);
            this.Controls.Add(this.listBoxOfAllMovies);
            this.Controls.Add(this.mainMenuStrip);
            this.MainMenuStrip = this.mainMenuStrip;
            this.Name = "Movies";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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
        private System.Windows.Forms.Label lblAllMoviesList;
        private System.Windows.Forms.ToolStripMenuItem cUSTOMERSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mOVIESToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kIOSKSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rENTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rETURNToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rEVIEWToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBOUTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem qUITToolStripMenuItem;
        private System.Windows.Forms.Button buttonToAddMovie;
        private System.Windows.Forms.Button buttonToEditMovieInfo;
        private System.Windows.Forms.Button buttonToDeleteMovie;
        private System.Windows.Forms.Button buttonToViewMovieDetails;
    }
}