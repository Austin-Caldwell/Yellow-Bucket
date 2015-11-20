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
        //protected string connectionString = "Server=COLLEGECOMPUTER\\SQLEXPRESS;Database=YellowBucketCSC365;Trusted_Connection=True;";

        private string selectedCustomerUserName;    // Variable to hold the username of the customer selected in the comboBoxOfCustomers
        private int selectedCustomerID;             // Variable to hold the customer ID of the customer selected in the comboBoxOfCustomers

        public ViewCustomerDetails()
        {
            InitializeComponent();
        }

        private void ViewCustomerDetails_Load(object sender, EventArgs e)
        {
            FillComboBoxOfCustomers();
        }

        private void FillComboBoxOfCustomers()
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
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        private void comboBoxOfCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            char[] delimiterChars = { ' ' };

            lblErrorMessage.Text = "";

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
                        lblCreditCardNumber.Text = Decryptor(readCustomerDetails["creditCard"].ToString());

                        // Populate Customer Address Fields
                        lblAddressLine1.Text = readCustomerDetails["addressLine1"].ToString();
                        lblAddressLine2.Text = readCustomerDetails["addressLine2"].ToString();
                        lblCity.Text = readCustomerDetails["city"].ToString();
                        lblState.Text = readCustomerDetails["stateProvince"].ToString();
                        lblZipCode.Text = readCustomerDetails["postalCode"].ToString();
                    }

                    YellowBucketConnection.Close();
                }

                catch (Exception ex)
                {
                    lblErrorMessage.Text = ex.ToString();
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
