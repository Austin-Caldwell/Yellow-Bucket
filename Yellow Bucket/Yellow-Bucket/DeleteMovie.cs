using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;    // To Access Database
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yellow_Bucket
{
    public partial class DeleteMovieForm : Form
    {
        protected SqlConnection YellowBucketConnection;
        protected string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        private string selectedMovie;
        public DeleteMovieForm()
        {
            InitializeComponent();
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

        private void rEVIEWToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Review reviewForm = new Review();
            reviewForm.Show();
        }

        private void rETURNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            ReturnMovie ReturnMovieForm = new ReturnMovie();
            ReturnMovieForm.Show();
        }

        private void rENTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            RentAMovie RentAMovieForm = new RentAMovie();
            RentAMovieForm.Show();
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
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT concat(movieID, ') ', title, ' (', releaseDate, ')') AS listing FROM dbo.Movie", YellowBucketConnection);
                    adapter.Fill(allMovies);
                    comboBoxOfMovies.ValueMember = "id";
                    comboBoxOfMovies.DisplayMember = "listing";
                    comboBoxOfMovies.DataSource = allMovies;
                    YellowBucketConnection.Close();
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        private void deleteMovie_Click(object sender, EventArgs e)
        {
            char[] delimiterChars = { ')' };
            string[] movieAddress = comboBoxOfMovies.Text.Split(delimiterChars);
            selectedMovie = movieAddress[0];

            using (YellowBucketConnection = new SqlConnection(connectionString))
            
                try //delete
                {
                    
                    YellowBucketConnection.Open();
                    SqlCommand deleteMovieFromInventory = new SqlCommand("DELETE FROM dbo.Inventory WHERE movieID = @movieAddress;", YellowBucketConnection);
                    deleteMovieFromInventory.Parameters.Add("@movieAddress", SqlDbType.Int);
                    deleteMovieFromInventory.Parameters["@movieAddress"].Value = selectedMovie;
                    deleteMovieFromInventory.ExecuteNonQuery();

                    SqlCommand deleteMovieFromMovie = new SqlCommand("DELETE FROM dbo.Movie WHERE movieID = @movieAddress;", YellowBucketConnection);
                    deleteMovieFromMovie.Parameters.Add("@movieAddress", SqlDbType.Int);
                    deleteMovieFromMovie.Parameters["@movieAddress"].Value = selectedMovie;
                    deleteMovieFromMovie.ExecuteNonQuery();

                    MessageBox.Show("Delete Successfull");
                    fillListOfAllMovies();
                    YellowBucketConnection.Close();
                    
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    MessageBox.Show("Delete Unsuccessful" + ex.ToString());
                }


            //delete movie works! These delete removes it from just dbo.Inventory and dbo.Movies by the movieID, so the reviews and stuff that list the review atatched, for example, still exist, but will reference to nothing.
        }
    }
}
