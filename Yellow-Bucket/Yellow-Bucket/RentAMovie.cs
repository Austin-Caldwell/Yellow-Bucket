using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Yellow_Bucket
{
    public partial class RentAMovie : Form
    {
        protected SqlConnection YellowBucketConnection;
        // Austin Caldwell's Connection String:

        //protected string connectionString = "Server=AUSTINC-LAPTOP\\SQLEXPRESS;Database=YellowBucketCSC365;Trusted_Connection=True;";
        // Evan Wehr's Connection String:
        protected string connectionString = "Server=COLLEGECOMPUTER\\SQLEXPRESS;Database=YellowBucketCSC365;Trusted_Connection=True;";

        //protected string connectionString = "Server=AUSTINC-LAPTOP\\SQLEXPRESS;Database=YellowBucketCSC365;Trusted_Connection=True;";
        // Evan Wehr's Connection String:
        // Jacob Girvin's Connection String:

        //protected string connectionString = "Server=COLLEGECOMPUTER\\SQLEXPRESS;Database=YellowBucketCSC365;Trusted_Connection=True;";

        public RentAMovie()
        {
            InitializeComponent();
        }

        private void RentAMovie_Load(object sender, EventArgs e)
        {
            fillRentAMovie();
        }

        private void fillRentAMovie()
        {
            DataTable allMovies = new DataTable();

            using (YellowBucketConnection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT concat(title) AS fullname FROM dbo.Movies", YellowBucketConnection);
                    adapter.Fill(allMovies);

                    lstboxMovies.ValueMember = "id";
                    lstboxMovies.DisplayMember = "fullname";
                    lstboxMovies.DataSource = allMovies;

                    YellowBucketConnection.Close();
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        private void rENTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            RentAMovie RentAMovieForm = new RentAMovie();
            RentAMovieForm.Show();
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
            Kiosks kioskForm = new Kiosks();
            kioskForm.Show();
        }

        private void rETURNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            ReturnMovie returnMovieForm = new ReturnMovie();
            returnMovieForm.Show();
        }

        private void rEVIEWToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Review reviewForm = new Review();
            reviewForm.Show();
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
