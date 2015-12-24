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
    public partial class AddMovie : Form
    {
        protected SqlConnection YellowBucketConnection;
        protected string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        public AddMovie()
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

        private void populate_load(object sender, EventArgs e)
        {
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

        private void buttonAddMovie_Click(object sender, EventArgs e)
        {
            using (YellowBucketConnection = new SqlConnection(connectionString))
            {
                
                    YellowBucketConnection.Open();

                    // Discover if Address Already Exists in Database
                    SqlDataReader doesMovieExist = null;
                    SqlCommand findExistingMovie = new SqlCommand("SELECT movieID FROM dbo.Movie WHERE title = @title AND movieDescription = @movieDescription AND director = @director AND studio = @studio AND runTime = @runTime AND parentalRating = @parentalRating AND genre = @genre AND releaseDate = @releaseDate", YellowBucketConnection);

                    findExistingMovie.Parameters.Add("@title", SqlDbType.VarChar);
                    findExistingMovie.Parameters["@title"].Value = textTitle.Text;

                    findExistingMovie.Parameters.Add("@movieDescription", SqlDbType.VarChar);
                    findExistingMovie.Parameters["@movieDescription"].Value = textMovieDescription.Text;

                    findExistingMovie.Parameters.Add("@director", SqlDbType.VarChar);
                    findExistingMovie.Parameters["@director"].Value = textDirector.Text;

                    findExistingMovie.Parameters.Add("@studio", SqlDbType.VarChar);
                    findExistingMovie.Parameters["@studio"].Value = textStudio.Text;

                    findExistingMovie.Parameters.Add("@runTime", SqlDbType.Int);
                    findExistingMovie.Parameters["@runTime"].Value = textRunTime.Text;

                    findExistingMovie.Parameters.Add("@releaseDate", SqlDbType.Date);
                    findExistingMovie.Parameters["@releaseDate"].Value = textReleaseDate.Text;

                    findExistingMovie.Parameters.Add("@parentalRating", SqlDbType.VarChar);
                    findExistingMovie.Parameters["@parentalRating"].Value = comboBoxParentalRating.Text;

                    findExistingMovie.Parameters.Add("@genre", SqlDbType.VarChar);
                    findExistingMovie.Parameters["@genre"].Value = comboBoxGenre.Text;

                    doesMovieExist = findExistingMovie.ExecuteReader();

                    DataTable existingMovie = new DataTable();    // Data table to hold rows returned if address is found to exist
                    
                    existingMovie.Load(doesMovieExist);


                    if (existingMovie.Rows.Count == 1)
                    {
                        MessageBox.Show("Movie already exists!");
                    }
                    else
                    {
                        using (YellowBucketConnection = new SqlConnection(connectionString))

                            try
                            {
                                YellowBucketConnection.Open();
                                //INSERT
                                SqlCommand addMovie = new SqlCommand("INSERT INTO dbo.Movie(title, movieDescription, director, studio, runTime, parentalRating, genre, releaseDate) VALUES(@title, @movieDescription, @director, @studio, @runTime, @parentalRating, @genre, @releaseDate);", YellowBucketConnection);

                                addMovie.Parameters.Add("@title", SqlDbType.VarChar);
                                addMovie.Parameters["@title"].Value = textTitle.Text;

                                addMovie.Parameters.Add("@movieDescription", SqlDbType.VarChar);
                                addMovie.Parameters["@movieDescription"].Value = textMovieDescription.Text;

                                addMovie.Parameters.Add("@director", SqlDbType.VarChar);
                                addMovie.Parameters["@director"].Value = textDirector.Text;

                                addMovie.Parameters.Add("@studio", SqlDbType.VarChar);
                                addMovie.Parameters["@studio"].Value = textStudio.Text;

                                addMovie.Parameters.Add("@releaseDate", SqlDbType.Date);
                                addMovie.Parameters["@releaseDate"].Value = textReleaseDate.Text;

                                addMovie.Parameters.Add("@runTime", SqlDbType.Int);
                                addMovie.Parameters["@runTime"].Value = textRunTime.Text;

                                addMovie.Parameters.Add("@parentalRating", SqlDbType.VarChar);
                                addMovie.Parameters["@parentalRating"].Value = comboBoxParentalRating.Text;

                                addMovie.Parameters.Add("@genre", SqlDbType.VarChar);
                                addMovie.Parameters["@genre"].Value = comboBoxGenre.Text;
                                
                                //runs insert
                                addMovie.ExecuteNonQuery();
                                MessageBox.Show("Add Successful");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Add Unsucsessfull" + ex.ToString());
                            }
                    }
                    YellowBucketConnection.Close();
            }
            
        }
    }
}
