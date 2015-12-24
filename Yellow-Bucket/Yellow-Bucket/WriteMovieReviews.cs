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
    public partial class WriteMovieReviews : Form
    {
        protected SqlConnection YellowBucketConnection;
        protected string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        // private string selectedRating;
        private string selectedMovie;
        private string selectedcustomer;
        // private string NewReview;
        // private int quantity;

        public WriteMovieReviews()
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
            Kiosks kioskForm = new Kiosks();
            kioskForm.Show();
        }

        private void rENTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            RentAMovie RentAMovieForm = new RentAMovie();
            RentAMovieForm.Show();
        }

        private void rETURNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            ReturnMovie ReturnMovieForm = new ReturnMovie();
            ReturnMovieForm.Show();
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

        private void WriteMovieReviews_Load(object sender, EventArgs e)
        {
            fillwithmovies();
            fillwithcustomers();
        }
        private void fillwithcustomers()
        {
            DataTable allcustomers = new DataTable();

            using (YellowBucketConnection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT concat(customerID, ') ', firstName, ' ', lastName, ' - ', userName) AS listing FROM dbo.Customer;", YellowBucketConnection);
                    adapter.Fill(allcustomers);

                    comboBoxCustomer.ValueMember = "id";

                    comboBoxCustomer.DisplayMember = "listing";

                    comboBoxCustomer.DataSource = allcustomers;

                    YellowBucketConnection.Close();
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
        private void fillwithmovies()
        {
            DataTable allmovies = new DataTable();

            using (YellowBucketConnection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT concat(movieID, ') ', title) AS listing FROM dbo.Movie;", YellowBucketConnection);
                    adapter.Fill(allmovies);

                    comboBoxMovie.ValueMember = "id";

                    comboBoxMovie.DisplayMember = "listing";

                    comboBoxMovie.DataSource = allmovies;

                    YellowBucketConnection.Close();
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            char[] delimiterChars = { ')' };
            string[] movieAddress = comboBoxMovie.Text.Split(delimiterChars);
            string[] customername = comboBoxCustomer.Text.Split(delimiterChars);
            selectedMovie = movieAddress[0];
            selectedcustomer = customername[0];


            using (YellowBucketConnection = new SqlConnection(connectionString))

                try 
                {
                    //GET QUANTITY AND INCREMENT

                    YellowBucketConnection.Open();

                    SqlDataReader doesReviewExist = null;

                    //declare the command

                    SqlCommand findExistingReview = new SqlCommand("Select reviewID FROM dbo.MovieReview WHERE reviewDescription = @reviewDescription AND movieID = @movieId AND rating = @rating AND datePosted = @datePosted AND customerID = @customerID;", YellowBucketConnection);

                    findExistingReview.Parameters.Add("@reviewDesription", SqlDbType.VarChar);
                    findExistingReview.Parameters.Add("@movieID", SqlDbType.Int);
                    findExistingReview.Parameters.Add("@rating", SqlDbType.Int);
                    findExistingReview.Parameters.Add("@datePosted", SqlDbType.Date);
                    findExistingReview.Parameters.Add("@customerID", SqlDbType.Int);
                    findExistingReview.Parameters["@reviewDescription"].Value = textBox1.Text;
                    findExistingReview.Parameters["@movieID"].Value = selectedMovie;
                    findExistingReview.Parameters["@rating"].Value = comboBoxRating.Text;
                    findExistingReview.Parameters["@datePosted"].Value = textBox2.Text;
                    findExistingReview.Parameters["@customerID"].Value = selectedcustomer;


                    doesReviewExist = findExistingReview.ExecuteReader();

                    DataTable existingReview = new DataTable();

                    existingReview.Load(doesReviewExist);

                    if(existingReview.Rows.Count==1)
                    {
                        MessageBox.Show("Review already exists");
                    }
                }
                catch
                {
                    using (YellowBucketConnection = new SqlConnection(connectionString))
                        try
                        {
                            YellowBucketConnection.Open();
                            //INSERT
                            SqlCommand addReview = new SqlCommand("INSERT INTO dbo.MovieReview(reviewDescription, movieID, rating, datePosted, customerID) VALUES(@reviewDescription, @movieID, @rating, @datePosted, @customerID);", YellowBucketConnection);

                            addReview.Parameters.Add("@reviewDescription", SqlDbType.VarChar);
                            addReview.Parameters.Add("@movieID", SqlDbType.Int);
                            addReview.Parameters.Add("@rating", SqlDbType.Int);
                            addReview.Parameters.Add("@datePosted", SqlDbType.Date);
                            addReview.Parameters.Add("@customerID", SqlDbType.Int);
                            addReview.Parameters["@reviewDescription"].Value = textBox1.Text;
                            addReview.Parameters["@movieID"].Value = selectedMovie;
                            addReview.Parameters["@rating"].Value = comboBoxRating.Text;
                            addReview.Parameters["@datePosted"].Value = textBox2.Text;
                            addReview.Parameters["@customerID"].Value = selectedcustomer;

                            addReview.ExecuteNonQuery();

                            MessageBox.Show("Add Successful");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Add Unsuccessfull" + ex.ToString());
                        }
                }
        }

    }
    
}
