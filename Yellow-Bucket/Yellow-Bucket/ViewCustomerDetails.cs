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
using System.Security.Cryptography;
using System.IO;

namespace Yellow_Bucket
{
    public partial class ViewCustomerDetails : Form
    {
        static byte[] bytes = ASCIIEncoding.ASCII.GetBytes("HideWord");

        protected SqlConnection YellowBucketConnection;
        // Austin Caldwell's Connection String:
           protected string connectionString = "Server=AUSTINC-LAPTOP\\SQLEXPRESS;Database=YellowBucketCSC365;Trusted_Connection=True;";
        // Evan Wehr's Connection String:
        // Jacob Girvin's Connection String:
        // protected string connectionString = "Server=COLLEGECOMPUTER\\SQLEXPRESS;Database=YellowBucketCSC365;Trusted_Connection=True;";

        private string selectedCustomerUserName;    // Variable to hold the username of the customer selected in the comboBoxOfCustomers
        private int selectedCustomerID;             // Variable to hold the customer ID of the customer selected in the comboBoxOfCustomers

        public ViewCustomerDetails()
        {
            InitializeComponent();
        }

        private void ViewCustomerDetails_Load(object sender, EventArgs e)
        {
            fillComboBoxOfCustomers();
        }

        private void fillComboBoxOfCustomers()
        {
            DataTable customers = new DataTable();

            using (YellowBucketConnection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT concat(firstName, ' ', lastName, ' - ', userName) AS fullname FROM dbo.Customer", YellowBucketConnection);
                    adapter.Fill(customers);

                    comboBoxOfCustomers.ValueMember = "id";
                    comboBoxOfCustomers.DisplayMember = "fullname";
                    comboBoxOfCustomers.DataSource = customers;

                    YellowBucketConnection.Close();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void comboBoxOfCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            char[] delimiterChars = { ' ' };

            DataTable customerID = new DataTable();

            string[] customerName = comboBoxOfCustomers.Text.Split(delimiterChars); // Parse text from comboBoxOfCustomers to separate customer first name from last name
            selectedCustomerUserName = customerName[3];

            using (YellowBucketConnection = new SqlConnection(connectionString))
            {
                try
                {
                    YellowBucketConnection.Open();
                    SqlDataReader readCustomerDetails = null;
                    SqlCommand populateCustomerFields = new SqlCommand("SELECT firstName, lastName, email, alternateEmail, userName, userPassword, creditCard, addressLine1, addressLine2, city, stateProvince, postalCode FROM dbo.Customer, dbo.CustomerAddress WHERE userName = @userName AND Customer.customerAddressID = CustomerAddress.customerAddressID;", YellowBucketConnection);

                    populateCustomerFields.Parameters.Add("@userName", SqlDbType.VarChar);
                    populateCustomerFields.Parameters["@userName"].Value = selectedCustomerUserName;
                    readCustomerDetails = populateCustomerFields.ExecuteReader();

                    while (readCustomerDetails.Read())
                    {
                        // Populate Customer Fields
                        lblFirstName.Text = readCustomerDetails["firstName"].ToString();
                        lblLastName.Text = readCustomerDetails["lastName"].ToString();
                        lblEmail.Text = readCustomerDetails["email"].ToString();
                        lblAlternateEmail.Text = readCustomerDetails["alternateEmail"].ToString();
                        lblUsername.Text = readCustomerDetails["userName"].ToString();
                        lblPassword.Text = Decryptor(readCustomerDetails["userPassword"].ToString());
                        //lblPassword.Text = readCustomerDetails["userPassword"].ToString();
                        lblCreditCardNumber.Text = Decryptor(readCustomerDetails["creditCard"].ToString());
                        //lblCreditCardNumber.Text = readCustomerDetails["creditCard"].ToString();

                        // Populate Customer Address Fields
                        lblAddressLine1.Text = readCustomerDetails["addressLine1"].ToString();
                        lblAddressLine2.Text = readCustomerDetails["addressLine2"].ToString();
                        lblCity.Text = readCustomerDetails["city"].ToString();
                        lblState.Text = readCustomerDetails["stateProvince"].ToString();
                        lblZipCode.Text = readCustomerDetails["postalCode"].ToString();
                    }

                    YellowBucketConnection.Close();
                    YellowBucketConnection.Open();

                    SqlDataReader readCustomerID = null;
                    SqlCommand findCustomerID = new SqlCommand("SELECT customerID FROM dbo.Customer WHERE userName = @userName;", YellowBucketConnection);

                    findCustomerID.Parameters.Add("@userName", SqlDbType.VarChar);
                    findCustomerID.Parameters["@userName"].Value = selectedCustomerUserName;
                    readCustomerID = findCustomerID.ExecuteReader();

                    customerID.Load(readCustomerID);
                    DataRow customerIDTableRow = customerID.Rows[0];
                    selectedCustomerID = Convert.ToInt32(customerIDTableRow["customerID"]);
                    YellowBucketConnection.Close();

                    fillLstBoxCurrentRentals();     // Fill List Box of Customer's Current Rentals
                    fillLstBoxRentalHistory();      // Fill List Box of Customer's Rental History
                    fillLstBoxReviews();            // Fill List Box of Customer's Posted Reviews
                    fillLstBoxRatings();            // Fill List Box of Customer's Movie Ratings
                    YellowBucketConnection.Close();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
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

        private void rENTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            RentAMovie rentAMovieForm = new RentAMovie();
            rentAMovieForm.Show();
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

        private void buttonToEditCustomerInfo_Click(object sender, EventArgs e)
        {
            this.Hide();
            UpdateCustomerRecord updateCustomerRecordForm = new UpdateCustomerRecord();
            updateCustomerRecordForm.Show();
        }

        private void fillLstBoxCurrentRentals()
        {
            using (YellowBucketConnection = new SqlConnection(connectionString))
            {
                try
                {
                    YellowBucketConnection.Open();

                    DataTable currentRentalTable = new DataTable();

                    // Find Movies Currently Rented By Customer
                    SqlDataReader readCurrentRentals = null;
                    SqlCommand findCurrentRentals = new SqlCommand("SELECT concat(title, ' -- Rented: ', dateRented, ' -- Disc Type: ', dvdBluRay) AS currentRental FROM dbo.Rental, dbo.Inventory, dbo.Movie WHERE customerID = @customerID AND Rental.stockID = Inventory.stockID AND Inventory.movieID = Movie.movieID;", YellowBucketConnection);
                    findCurrentRentals.Parameters.Add("@customerID", SqlDbType.Int);
                    findCurrentRentals.Parameters["@customerID"].Value = selectedCustomerID;

                    readCurrentRentals = findCurrentRentals.ExecuteReader();

                    currentRentalTable.Load(readCurrentRentals);

                    lstBoxCurrentRentals.ValueMember = "rentalID";
                    lstBoxCurrentRentals.DisplayMember = "currentRental";
                    lstBoxCurrentRentals.DataSource = currentRentalTable;

                    YellowBucketConnection.Close();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void fillLstBoxRentalHistory()
        {
            using (YellowBucketConnection = new SqlConnection(connectionString))
            {
                try
                {
                    YellowBucketConnection.Open();

                    DataTable rentalHistoryTable = new DataTable();

                    // Find Historic Rentals for Customer
                    SqlDataReader readRentalHistory = null;
                    SqlCommand findRentalHistory = new SqlCommand("SELECT DISTINCT concat(title, ' -- Rented: ', outDate, ' -- Returned: ', inDate) AS historicRental FROM dbo.RentalHistory, dbo.Customer, dbo.Movie WHERE RentalHistory.customerID = @customerID AND RentalHistory.movieID = Movie.movieID;", YellowBucketConnection);
                    findRentalHistory.Parameters.Add("@customerID", SqlDbType.Int);
                    findRentalHistory.Parameters["@customerID"].Value = selectedCustomerID;

                    readRentalHistory = findRentalHistory.ExecuteReader();

                    rentalHistoryTable.Load(readRentalHistory);

                    lstBoxRentalHistory.ValueMember = "historyID";
                    lstBoxRentalHistory.DisplayMember = "historicRental";
                    lstBoxRentalHistory.DataSource = rentalHistoryTable;

                    YellowBucketConnection.Close();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void fillLstBoxReviews()
        {
            using (YellowBucketConnection = new SqlConnection(connectionString))
            {
                try
                {
                    YellowBucketConnection.Open();

                    DataTable customerReviewsTable = new DataTable();

                    // Find Reviews Posted by Customer
                    SqlDataReader readCustomerReviews = null;
                    SqlCommand findCustomerReviews = new SqlCommand("SELECT concat(title, ' -- Date Posted: ', datePosted, ' -- Review: ', reviewDescription) AS postedReview FROM dbo.MovieReview, dbo.Movie WHERE customerID = @customerID AND MovieReview.movieID = Movie.movieID;", YellowBucketConnection);
                    findCustomerReviews.Parameters.Add("@customerID", SqlDbType.Int);
                    findCustomerReviews.Parameters["@customerID"].Value = selectedCustomerID;

                    readCustomerReviews = findCustomerReviews.ExecuteReader();

                    customerReviewsTable.Load(readCustomerReviews);

                    lstBoxReviews.ValueMember = "reviewID";
                    lstBoxReviews.DisplayMember = "postedReview";
                    lstBoxReviews.DataSource = customerReviewsTable;

                    YellowBucketConnection.Close();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void fillLstBoxRatings()
        {
            using (YellowBucketConnection = new SqlConnection(connectionString))
            {
                try
                {
                    YellowBucketConnection.Open();

                    DataTable customerRatingTable = new DataTable();

                    // Find All Movie Ratings Posted by Customer
                    SqlDataReader readCustomerRatings = null;
                    SqlCommand findCustomerRatings = new SqlCommand("SELECT concat(title, ' -- Rating: ', rating, ' -- Date Rated: ', datePosted) AS ratingRecord FROM dbo.MovieReview, dbo.Movie WHERE customerID = @customerID AND MovieReview.movieID = Movie.movieID;", YellowBucketConnection);
                    findCustomerRatings.Parameters.Add("@customerID", SqlDbType.Int);
                    findCustomerRatings.Parameters["@customerID"].Value = selectedCustomerID;

                    readCustomerRatings = findCustomerRatings.ExecuteReader();

                    customerRatingTable.Load(readCustomerRatings);

                    lstBoxRatings.ValueMember = "reviewID";
                    lstBoxRatings.DisplayMember = "ratingRecord";
                    lstBoxRatings.DataSource = customerRatingTable;

                    YellowBucketConnection.Close();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private string Decryptor(string stringToDecrypt)    // Code Copied From: http://www.codeproject.com/Articles/19538/Encrypt-Decrypt-String-using-DES-in-C
        {
            if (String.IsNullOrEmpty(stringToDecrypt))
            {
                throw new ArgumentNullException
                   ("The string to be decrypted can not be null.");
            }
            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream memoryStream = new MemoryStream
                    (Convert.FromBase64String(stringToDecrypt));
            CryptoStream cryptoStream = new CryptoStream(memoryStream,
                cryptoProvider.CreateDecryptor(bytes, bytes), CryptoStreamMode.Read);
            StreamReader reader = new StreamReader(cryptoStream);
            return reader.ReadToEnd();
        }
    }
}
