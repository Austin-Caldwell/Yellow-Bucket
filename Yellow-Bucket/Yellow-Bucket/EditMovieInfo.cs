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
    public partial class EditMovieInfo : Form
    {
        protected SqlConnection YellowBucketConnection;
        // Austin Caldwell's Connection String:
        // protected string connectionString = "Server=AUSTINC-LAPTOP\\SQLEXPRESS;Database=YellowBucketCSC365;Trusted_Connection=True;";
        // Evan Wehr's Connection String:
        protected string connectionString = "Server=HP\\SQLEXPRESS;Database=YellowBucketCSC365;Trusted_Connection=True;";
        public string selectedMovie;
        public EditMovieInfo()
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

            comboBoxParentalRating.Items.Add("NR");
            comboBoxParentalRating.Items.Add("G");
            comboBoxParentalRating.Items.Add("PG");
            comboBoxParentalRating.Items.Add("PG-13");
            comboBoxParentalRating.Items.Add("M");
            comboBoxParentalRating.Items.Add("MA 15+");
            comboBoxParentalRating.Items.Add("R");
            comboBoxParentalRating.Items.Add("X");
            comboBoxParentalRating.Items.Add("XXX");
            comboBoxParentalRating.Items.Add("SCOTT!");


            comboBoxGenre.Items.Add("Action");
            comboBoxGenre.Items.Add("Adventure");
            comboBoxGenre.Items.Add("Animation");
            comboBoxGenre.Items.Add("Biography");
            comboBoxGenre.Items.Add("Comedy");
            comboBoxGenre.Items.Add("Crime");
            comboBoxGenre.Items.Add("Documentary");
            comboBoxGenre.Items.Add("Drama");
            comboBoxGenre.Items.Add("Family");
            comboBoxGenre.Items.Add("Fantasy");
            comboBoxGenre.Items.Add("Film-Noir");
            comboBoxGenre.Items.Add("History");
            comboBoxGenre.Items.Add("Horror");
            comboBoxGenre.Items.Add("Kids");
            comboBoxGenre.Items.Add("Music");
            comboBoxGenre.Items.Add("Musical");
            comboBoxGenre.Items.Add("Mystery");
            comboBoxGenre.Items.Add("Romance");
            comboBoxGenre.Items.Add("Sci-Fi");
            comboBoxGenre.Items.Add("Sport");
            comboBoxGenre.Items.Add("Thriller");
            comboBoxGenre.Items.Add("War");
            comboBoxGenre.Items.Add("Western");
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

        private void rePopulate(object sender, EventArgs e)
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
                        // Populate Customer Fields
                        textTitle.Text = readMovieInfo["title"].ToString();
                        textMovieDescription.Text = readMovieInfo["movieDescription"].ToString();
                        textDirector.Text = readMovieInfo["director"].ToString();
                        textStudio.Text = readMovieInfo["studio"].ToString();
                        textRunTime.Text = readMovieInfo["runTime"].ToString();

                        textReleaseDate.Text = readMovieInfo["releaseDate"].ToString();
                        comboBoxParentalRating.Text  = readMovieInfo["parentalRating"].ToString();
                        comboBoxGenre.Text = readMovieInfo["genre"].ToString();
                    }
                    YellowBucketConnection.Close();
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error populating movie data to fields" + ex.ToString());
                }
            }
        }

        private void buttonUpdateMovie_Click(object sender, EventArgs e)
        {
            if (testTextBoxInputValidity())
            {
                char[] delimiterChars = { ')' };
                string[] movieAddress = comboBoxOfMovies.Text.Split(delimiterChars);
                selectedMovie = movieAddress[0];

                using (YellowBucketConnection = new SqlConnection(connectionString))
                {
                    try
                    {
                        YellowBucketConnection.Open();

                        SqlCommand updateMovie= new SqlCommand("UPDATE dbo.Movie SET title = @title, movieDescription = @movieDescription, director = @director, studio = @studio, runTime = @runTime, genre = @genre, parentalRating = @parentalRating, releaseDate = @releaseDate  WHERE movieID = @movieID;", YellowBucketConnection);

                        updateMovie.Parameters.Add("@movieID", SqlDbType.Int);
                        updateMovie.Parameters["@movieID"].Value = selectedMovie;

                        updateMovie.Parameters.Add("@movieDescription", SqlDbType.VarChar);
                        updateMovie.Parameters["@movieDescription"].Value = textMovieDescription.Text;

                        updateMovie.Parameters.Add("@director", SqlDbType.VarChar);
                        updateMovie.Parameters["@director"].Value = textDirector.Text;

                        updateMovie.Parameters.Add("@studio", SqlDbType.VarChar);
                        updateMovie.Parameters["@studio"].Value = textStudio.Text;

                        updateMovie.Parameters.Add("@runTime", SqlDbType.Int);
                        updateMovie.Parameters["@runTime"].Value = textRunTime.Text;

                        updateMovie.Parameters.Add("@title", SqlDbType.VarChar);
                        updateMovie.Parameters["@title"].Value = textTitle.Text;

                        updateMovie.Parameters.Add("@genre", SqlDbType.VarChar); //genre
                        updateMovie.Parameters["@genre"].Value = comboBoxGenre.Text;

                        updateMovie.Parameters.Add("@parentalRating", SqlDbType.VarChar); //parentalRating
                        updateMovie.Parameters["@parentalRating"].Value = comboBoxParentalRating.Text;

                        updateMovie.Parameters.Add("@releaseDate", SqlDbType.Date); //releaseDate
                        updateMovie.Parameters["@releaseDate"].Value = textReleaseDate.Text;

                        updateMovie.ExecuteNonQuery();
                        YellowBucketConnection.Close();
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show("Error Updating movie" + ex.ToString());
                    }

                }
            }
            else
                return;

            fillListOfAllMovies();
        }



        
         private bool testTextBoxInputValidity() // Test to be sure that no required field is null
         {

            string title = textTitle.Text;
            string movieDescription = textMovieDescription.Text;
            string director = textDirector.Text;
            string studio = textStudio.Text;
            string runTime = textRunTime.Text;

            if (title == "" || movieDescription == "" || director == "" || studio == "" || runTime == "")
            {
                MessageBox.Show("equired Fields Must Not Be Empty");
                return false;
            }
            else
            {
                return true;
            }
        }
        }
    }

           