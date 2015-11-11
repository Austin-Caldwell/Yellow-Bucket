﻿// CSC 365 -- Austin Caldwell, Evan Wehr, Jacob Girvin -- 2015
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;    // To Access Database

namespace Yellow_Bucket
{
    public partial class ListAllMovies : Form
    {
        protected SqlConnection YellowBucketConnection;
        protected string connectionString = "Server=AUSTINC-LAPTOP\\SQLEXPRESS;Database=YellowBucketCSC365;Trusted_Connection=True;";
        // Evan Wehr's Connection String = 
        // Jacob Girvin's Connection String = 
        // Use YellowBucketConnection = new SqlConnection(connectionString); when you need to open a connection

        public ListAllMovies()
        {
            InitializeComponent();
        }

        private void ListAllMovies_Load(object sender, EventArgs e)
        {
            fillListOfAllMovies();
        }

        private void fillListOfAllMovies()
        {
            DataTable allMovies = new DataTable();

            using (YellowBucketConnection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT title FROM dbo.Movie", YellowBucketConnection);
                    adapter.Fill(allMovies);

                    listBoxOfAllMovies.ValueMember = "id";
                    listBoxOfAllMovies.DisplayMember = "title";
                    listBoxOfAllMovies.DataSource = allMovies;

                    YellowBucketConnection.Close();
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        private void hOMEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            YellowBucketHome homeForm = new YellowBucketHome();
            homeForm.Show();
        }

        private void cUSTOMERSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Customers customerForm = new Customers();
            customerForm.Show();
        }

        private void kIOSKSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Kiosks kioskForm = new Kiosks();
            kioskForm.Show();
        }

        private void mOVIESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Movies movieForm = new Movies();
            movieForm.Show();
        }

        private void aBOUTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            About aboutForm = new About();
            aboutForm.Show();
        }

        private void qUITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}