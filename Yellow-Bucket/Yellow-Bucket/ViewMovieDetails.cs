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
    public partial class ViewMovieDetails : Form
    {
        protected SqlConnection YellowBucketConnection;
        // Austin Caldwell's Connection String:
        protected string connectionString = "Server=AUSTINC-LAPTOP\\SQLEXPRESS;Database=YellowBucketCSC365;Trusted_Connection=True;";
        // Evan Wehr's Connection String:
        //protected string connectionString = "Server=HP\\SQLEXPRESS;Database=YellowBucketCSC365;Trusted_Connection=True;";
        public string selectedMovie;
        private double averageRating = 0;
        private double sum = 0;
        private double count = 0;
        
        public ViewMovieDetails()
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

        private void populate(object sender, EventArgs e)
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

        private void display(object sender, EventArgs e)
        {
            char[] delimiterChars = { ')' };
            string[] movieAddress = comboBoxOfMovies.Text.Split(delimiterChars);
            selectedMovie = movieAddress[0];

            using (YellowBucketConnection = new SqlConnection(connectionString))
            {
                try
                {
                    YellowBucketConnection.Open();
                    SqlDataReader readMovieInfo = null;
                    SqlCommand populateMovieFields = new SqlCommand("SELECT * FROM dbo.Movie WHERE movieID = @selectedMovie;", YellowBucketConnection);
                    populateMovieFields.Parameters.Add("@selectedMovie", SqlDbType.VarChar);
                    populateMovieFields.Parameters["@selectedMovie"].Value = selectedMovie;

                    readMovieInfo = populateMovieFields.ExecuteReader();

                    while (readMovieInfo.Read())
                    {
                        // Populate Movie Fields
                        labelTitle.Text = readMovieInfo["title"].ToString();
                        labelMovieDescription.Text = readMovieInfo["movieDescription"].ToString();
                        labelDirector.Text = readMovieInfo["director"].ToString();
                        labelStudio.Text = readMovieInfo["studio"].ToString();
                        labelRunTime.Text = readMovieInfo["runTime"].ToString();

                        labelReleaseDate.Text = readMovieInfo["releaseDate"].ToString();
                        labelParentalRating.Text = readMovieInfo["parentalRating"].ToString();
                        labelGenre.Text = readMovieInfo["genre"].ToString();
                    }
                    YellowBucketConnection.Close();
                    getRating();
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error populating movie data to fields" + ex.ToString());
                }
            }
        }
        private void getRating()
        {
            char[] delimiterChars = { ')' };
            string[] movieAddress = comboBoxOfMovies.Text.Split(delimiterChars);
            selectedMovie = movieAddress[0];
            
            int counter = 0;

            using (YellowBucketConnection = new SqlConnection(connectionString))
            {
                try
                {
                    YellowBucketConnection.Open();
                    SqlDataReader readReview = null;
                    SqlCommand readReviewCommand = new SqlCommand("SELECT rating FROM dbo.MovieReview WHERE movieID = @selectedMovie;", YellowBucketConnection);
                    readReviewCommand.Parameters.Add("@selectedMovie", SqlDbType.VarChar);
                    readReviewCommand.Parameters["@selectedMovie"].Value = selectedMovie;

                    readReview = readReviewCommand.ExecuteReader();

                    //get count
                    DataTable movieRatings = new DataTable();
                    movieRatings.Load(readReview);
                    count = movieRatings.Rows.Count;
                    //public int counter = count;

                    //get sum
                    DataTable getSum = new DataTable();
                    SqlDataReader readSumRatings = null;
                    SqlCommand sumRatingsCommand = new SqlCommand("SELECT SUM(rating) as rating FROM dbo.MovieReview WHERE movieID = @selectedMovie;", YellowBucketConnection);
                    sumRatingsCommand.Parameters.Add("@selectedMovie", SqlDbType.VarChar);
                    sumRatingsCommand.Parameters["@selectedMovie"].Value = selectedMovie;

                    readSumRatings  = readReviewCommand.ExecuteReader();
                    getSum.Load(readSumRatings);
                    DataRow rowData = getSum.Rows[0];
                    sum = Convert.ToInt32(rowData["rating"]);


                    //get average rating
                    averageRating = sum / count;

                    // Populate Movie Fields
                    labelRating.Text = averageRating.ToString();

                    

                    YellowBucketConnection.Close();
                    
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error getting average rating!" + ex.ToString());
                }
            }

        }

    }
}
