namespace Yellow_Bucket
{
    partial class Customers
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.hOMEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cUSTOMERSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kIOSKSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mOVIESToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBOUTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.qUITToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Gold;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hOMEToolStripMenuItem,
            this.cUSTOMERSToolStripMenuItem,
            this.kIOSKSToolStripMenuItem,
            this.mOVIESToolStripMenuItem,
            this.aBOUTToolStripMenuItem,
            this.qUITToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(118, 261);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // hOMEToolStripMenuItem
            // 
            this.hOMEToolStripMenuItem.Name = "hOMEToolStripMenuItem";
            this.hOMEToolStripMenuItem.Size = new System.Drawing.Size(105, 25);
            this.hOMEToolStripMenuItem.Text = "HOME";
            this.hOMEToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.hOMEToolStripMenuItem.Click += new System.EventHandler(this.hOMEToolStripMenuItem_Click);
            // 
            // cUSTOMERSToolStripMenuItem
            // 
            this.cUSTOMERSToolStripMenuItem.Name = "cUSTOMERSToolStripMenuItem";
            this.cUSTOMERSToolStripMenuItem.Size = new System.Drawing.Size(105, 25);
            this.cUSTOMERSToolStripMenuItem.Text = "CUSTOMERS";
            this.cUSTOMERSToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cUSTOMERSToolStripMenuItem.Click += new System.EventHandler(this.cUSTOMERSToolStripMenuItem_Click);
            // 
            // kIOSKSToolStripMenuItem
            // 
            this.kIOSKSToolStripMenuItem.Name = "kIOSKSToolStripMenuItem";
            this.kIOSKSToolStripMenuItem.Size = new System.Drawing.Size(105, 25);
            this.kIOSKSToolStripMenuItem.Text = "KIOSKS";
            this.kIOSKSToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.kIOSKSToolStripMenuItem.Click += new System.EventHandler(this.kIOSKSToolStripMenuItem_Click);
            // 
            // mOVIESToolStripMenuItem
            // 
            this.mOVIESToolStripMenuItem.Name = "mOVIESToolStripMenuItem";
            this.mOVIESToolStripMenuItem.Size = new System.Drawing.Size(105, 25);
            this.mOVIESToolStripMenuItem.Text = "MOVIES";
            this.mOVIESToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mOVIESToolStripMenuItem.Click += new System.EventHandler(this.mOVIESToolStripMenuItem_Click);
            // 
            // aBOUTToolStripMenuItem
            // 
            this.aBOUTToolStripMenuItem.Name = "aBOUTToolStripMenuItem";
            this.aBOUTToolStripMenuItem.Size = new System.Drawing.Size(105, 25);
            this.aBOUTToolStripMenuItem.Text = "ABOUT";
            this.aBOUTToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.aBOUTToolStripMenuItem.Click += new System.EventHandler(this.aBOUTToolStripMenuItem_Click);
            // 
            // qUITToolStripMenuItem
            // 
            this.qUITToolStripMenuItem.Name = "qUITToolStripMenuItem";
            this.qUITToolStripMenuItem.Size = new System.Drawing.Size(105, 25);
            this.qUITToolStripMenuItem.Text = "QUIT";
            this.qUITToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.qUITToolStripMenuItem.Click += new System.EventHandler(this.qUITToolStripMenuItem_Click);
            // 
            // Customers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 261);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Customers";
            this.Text = "YELLOW BUCKET -- CUSTOMERS";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem hOMEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cUSTOMERSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBOUTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mOVIESToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kIOSKSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem qUITToolStripMenuItem;


    }
}