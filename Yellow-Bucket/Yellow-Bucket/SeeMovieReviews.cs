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
    public partial class SeeMovieReviews : Form
    {
        protected SqlConnection YellowBucketConnection;
        // Austin Caldwell's Connection String:
        //protected string connectionString = "Server=AUSTINC-LAPTOP\\SQLEXPRESS;Database=YellowBucketCSC365;Trusted_Connection=True;";
        // Evan Wehr's Connection String:
        // Jacob Girvin's Connection String:
        protected string connectionString = "Server=COLLEGECOMPUTER\\SQLEXPRESS;Database=YellowBucketCSC365;Trusted_Connection=True;";
        private object selectedmoviereview;
        private string selectedMovie;

        public SeeMovieReviews()
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
            RentAMovie rentMovieForm = new RentAMovie();
            rentMovieForm.Show();
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

        private void fillwithmovies()
        {
            DataTable allmovies = new DataTable();

            using (YellowBucketConnection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT concat(movieID, ') ', title) AS listing FROM dbo.Movie;", YellowBucketConnection);
                    adapter.Fill(allmovies);

                    comboBoxMovies.ValueMember = "id";

                    comboBoxMovies.DisplayMember = "listing";

                    comboBoxMovies.DataSource = allmovies;

                    YellowBucketConnection.Close();
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error populating customer information: " + ex.ToString());
                }
            }
        }

        //private void comboBoxMovies_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    char[] delimiterChars = { ' ' };

        //    string[] moviereviews = lstBoxReview.Text.Split(delimiterChars); // Parse text from comboBoxOfCustomers to separate customer first name from last name
        //    selectedmoviereview = moviereviews[0];

        //    using (YellowBucketConnection = new SqlConnection(connectionString))
        //    {
        //        try
        //        {
        //            YellowBucketConnection.Open();
        //            SqlDataReader readmoviereviews = null;
        //            SqlCommand fillmoviereviews = new SqlCommand("SELECT reviewID, reviewDescription FROM dbo.MovieReview, dbo.CustomerAddress WHERE userName = @userName AND Customer.customerAddressID = CustomerAddress.customerAddressID;", YellowBucketConnection);
        //            fillmoviereviews.Parameters.Add("@userName", SqlDbType.VarChar);
        //            fillmoviereviews.Parameters["@userName"].Value = selectedmoviereview;

        //            readmoviereviews = fillmoviereviews.ExecuteReader();

        //            while (readmoviereviews.Read())
        //            {

        //            }

        //            YellowBucketConnection.Close();
        //        }

        //        catch (Exception ex)
        //        {
        //            lblErrorMessage.Text = "Error populating customer information: " + ex.ToString();
        //            Console.WriteLine(ex.ToString());
        //        }
        //    }

        //}

        private void SeeMovieReviews_Load(object sender, EventArgs e)
        {
            fillwithmovies();
        }

        private void comboBoxMovies_SelectedIndexChanged(object sender, EventArgs e)
        {
            char[] delimiterChars = { ')' };

            string[] movieID = comboBoxMovies.Text.Split(delimiterChars);

            selectedMovie = movieID[0];

            DataTable inventory = new DataTable();

            using (YellowBucketConnection = new SqlConnection(connectionString))
            {
                try
                {

                    YellowBucketConnection.Open();

                    SqlDataReader ReadListing = null;

                    //declare the command

                    SqlCommand findReview = new SqlCommand("SELECT concat('(', datePosted, '), ', 'Description: ', reviewDescription) AS listing FROM dbo.MovieReview WHERE movieID = @selectedMovie;", YellowBucketConnection);

                    //declare the varialbe type

                    findReview.Parameters.Add("@selectedMovie", SqlDbType.Int);

                    //declare the definition of the variable (the definition is delcared about 10 lines up)

                    findReview.Parameters["@selectedMovie"].Value = selectedMovie;

                    //declares the execution trigger

                    ReadListing = findReview.ExecuteReader();

                    //pulls trigger

                    inventory.Load(ReadListing);




                    lstBoxReview.ValueMember = "id";

                    lstBoxReview.DisplayMember = "listing";

                    lstBoxReview.DataSource = inventory;

                    YellowBucketConnection.Close();

                }

                catch (Exception ex)

                {
                    MessageBox.Show("Error populating kiosk inventory" + ex.ToString());
                }

                YellowBucketConnection.Close();
            }
        }
    }
}
