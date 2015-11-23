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
    public partial class UpdateCustomerRecord : Form
    {
        static byte[] bytes = ASCIIEncoding.ASCII.GetBytes("HideWord");

        protected SqlConnection YellowBucketConnection;
        // Austin Caldwell's Connection String:
        //protected string connectionString = "Server=AUSTINC-LAPTOP\\SQLEXPRESS;Database=YellowBucketCSC365;Trusted_Connection=True;";
        protected string connectionString = "Server=HP\\SQLEXPRESS;Database=YellowBucketCSC365;Trusted_Connection=True;";
        // Evan Wehr's Connection String:
        // Jacob Girvin's Connection String:
        //protected string connectionString = "Server=COLLEGECOMPUTER\\SQLEXPRESS;Database=YellowBucketCSC365;Trusted_Connection=True;";

        private string selectedCustomerUserName;    // Variable to hold the username of the customer selected in the comboBoxOfCustomers

        public UpdateCustomerRecord()
        {
            InitializeComponent();
        }

        private void UpdateCustomerRecord_Load(object sender, EventArgs e)
        {
            fillCustomerComboBox();
        }

        private void fillCustomerComboBox() // comboBoxOfCustomers is filled with customer firstnames, lastnames, and usernames
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

        private void comboBoxOfCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            char[] delimiterChars = {' '};

            lblSaveStatus.Text = ""; // Reset status message when selected customer is changed
            lblErrorMessage.Text = "";

            string[] customerName = comboBoxOfCustomers.Text.Split(delimiterChars); // Parse text from comboBoxOfCustomers to separate customer first name from last name
            selectedCustomerUserName = customerName[3];

            using (YellowBucketConnection = new SqlConnection(connectionString))
            {
                try
                {
                    YellowBucketConnection.Open();
                    SqlDataReader readCustomerInfo = null;
                    SqlCommand populateCustomerFields = new SqlCommand("SELECT * FROM dbo.Customer, dbo.CustomerAddress WHERE userName = @userName AND Customer.customerAddressID = CustomerAddress.customerAddressID;", YellowBucketConnection);
                    // SELECTing firstName, lastName, email, alternateEmail, userName, userPassword, creditCard, addressLine1, addressLine2, city, stateProvince, postalCode FROM dbo.Customer, dbo.CustomerAddress
                    populateCustomerFields.Parameters.Add("@userName", SqlDbType.VarChar);
                    populateCustomerFields.Parameters["@userName"].Value = selectedCustomerUserName;

                    readCustomerInfo = populateCustomerFields.ExecuteReader();

                    while(readCustomerInfo.Read())
                    {
                        // Populate Customer Fields
                        lblCustomerFirstName.Text = readCustomerInfo["firstName"].ToString();
                        lblCustomerLastName.Text = readCustomerInfo["lastName"].ToString();
                        textBoxEmail.Text = readCustomerInfo["email"].ToString();
                        textBoxAlternateEmail.Text = readCustomerInfo["alternateEmail"].ToString();
                        lblCustomerUsername.Text = readCustomerInfo["userName"].ToString();
                        textBoxPassword.Text = Decryptor(readCustomerInfo["userPassword"].ToString());
                        textBoxConfirmPassword.Text = Decryptor(readCustomerInfo["userPassword"].ToString());
                        maskedTextBoxCreditCardNumber.Text = Decryptor(readCustomerInfo["creditCard"].ToString());

                        // Populate Customer Address Fields
                        textBoxAddressLine1.Text = readCustomerInfo["addressLine1"].ToString();
                        textBoxAddressLine2.Text = readCustomerInfo["addressLine2"].ToString();
                        textBoxCity.Text = readCustomerInfo["city"].ToString();
                        textBoxState.Text = readCustomerInfo["stateProvince"].ToString();
                        textBoxZipCode.Text = readCustomerInfo["postalCode"].ToString();
                    }

                    YellowBucketConnection.Close();
                }

                catch (Exception ex)
                {
                    lblErrorMessage.Text = "Error populating customer information: " + ex.ToString();
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        private void buttonToUpdateCustomer_Click(object sender, EventArgs e)
        {
            if (testPasswordValidity() && testTextBoxInputValidity())
            {
                using (YellowBucketConnection = new SqlConnection(connectionString))
                {
                    try
                    {
                        YellowBucketConnection.Open();

                        // Discover if Address Already Exists in Database
                        SqlDataReader doesCustomerAddressExist = null;
                        SqlCommand findExistingAddress = new SqlCommand("SELECT customerAddressID FROM dbo.CustomerAddress WHERE addressLine1 = @addressLine1 AND addressLine2 = @addressLine2 AND city = @city AND stateProvince = @stateProvince AND postalCode = @postalCode;", YellowBucketConnection);

                        findExistingAddress.Parameters.Add("@addressLine1", SqlDbType.VarChar);
                        findExistingAddress.Parameters.Add("@addressLine2", SqlDbType.VarChar);
                        findExistingAddress.Parameters.Add("@city", SqlDbType.VarChar);
                        findExistingAddress.Parameters.Add("@stateProvince", SqlDbType.VarChar);
                        findExistingAddress.Parameters.Add("@postalCode", SqlDbType.VarChar);

                        findExistingAddress.Parameters["@addressLine1"].Value = textBoxAddressLine1.Text;
                        findExistingAddress.Parameters["@addressLine2"].Value = textBoxAddressLine2.Text;
                        findExistingAddress.Parameters["@city"].Value = textBoxCity.Text;
                        findExistingAddress.Parameters["@stateProvince"].Value = textBoxState.Text;
                        findExistingAddress.Parameters["@postalCode"].Value = textBoxZipCode.Text;

                        doesCustomerAddressExist = findExistingAddress.ExecuteReader();

                        DataTable existingAddress = new DataTable();    // Data table to hold rows returned if address is found to exist

                        existingAddress.Load(doesCustomerAddressExist);

                        YellowBucketConnection.Close();

                        if (existingAddress.Rows.Count == 1) // If the address does already exist in the database
                        {
                            // FIRST: Update Customer
                            YellowBucketConnection.Open();
                            SqlCommand updateCustomerRecord = new SqlCommand("UPDATE dbo.Customer SET email = @email, alternateEmail = @alternateEmail, userPassword = @userPassword, creditCard = @creditCard WHERE userName = @userName;", YellowBucketConnection);

                            updateCustomerRecord.Parameters.Add("@email", SqlDbType.VarChar);
                            updateCustomerRecord.Parameters.Add("@alternateEmail", SqlDbType.VarChar);
                            updateCustomerRecord.Parameters.Add("@userName", SqlDbType.VarChar);
                            updateCustomerRecord.Parameters.Add("@userPassword", SqlDbType.VarChar);
                            updateCustomerRecord.Parameters.Add("@creditCard", SqlDbType.VarChar);

                            updateCustomerRecord.Parameters["@email"].Value = textBoxEmail.Text;
                            updateCustomerRecord.Parameters["@alternateEmail"].Value = textBoxAlternateEmail.Text;

                            updateCustomerRecord.Parameters["@userName"].Value = lblCustomerUsername.Text;
                            updateCustomerRecord.Parameters["@userPassword"].Value = Encryptor(textBoxPassword.Text);
                            updateCustomerRecord.Parameters["@creditCard"].Value = Encryptor(maskedTextBoxCreditCardNumber.Text);

                            updateCustomerRecord.ExecuteNonQuery();
                            YellowBucketConnection.Close();

                            // SECOND: Find AddressID of Address Already in Database
                            DataRow addressIDTableRow = existingAddress.Rows[0];

                            // THIRD: Connect New Customer to Address Already in Database
                            YellowBucketConnection.Open();
                            SqlCommand updateCustomerWithAddressID = new SqlCommand("UPDATE dbo.Customer SET customerAddressID = @addressID WHERE userName = @userName;", YellowBucketConnection);
                            updateCustomerWithAddressID.Parameters.Add("@addressID", SqlDbType.Int);
                            updateCustomerWithAddressID.Parameters["@addressID"].Value = addressIDTableRow["customerAddressID"];
                            updateCustomerWithAddressID.Parameters.Add("@userName", SqlDbType.VarChar);
                            updateCustomerWithAddressID.Parameters["@userName"].Value = lblCustomerUsername.Text;

                            updateCustomerWithAddressID.ExecuteNonQuery();
                            YellowBucketConnection.Close();
                        }
                        else
                        {
                            // FIRST: Add New Address
                            YellowBucketConnection.Open();
                            SqlCommand addCustomerAddress = new SqlCommand("INSERT INTO dbo.CustomerAddress(addressLine1, addressLine2, city, stateProvince, postalCode) VALUES (@addressLine1, @addressLine2, @city, @stateProvince, @postalCode);", YellowBucketConnection);

                            addCustomerAddress.Parameters.Add("@addressLine1", SqlDbType.VarChar);
                            addCustomerAddress.Parameters.Add("@addressLine2", SqlDbType.VarChar);
                            addCustomerAddress.Parameters.Add("@city", SqlDbType.VarChar);
                            addCustomerAddress.Parameters.Add("@stateProvince", SqlDbType.VarChar);
                            addCustomerAddress.Parameters.Add("@postalCode", SqlDbType.VarChar);

                            addCustomerAddress.Parameters["@addressLine1"].Value = textBoxAddressLine1.Text;
                            addCustomerAddress.Parameters["@addressLine2"].Value = textBoxAddressLine2.Text;
                            addCustomerAddress.Parameters["@city"].Value = textBoxCity.Text;
                            addCustomerAddress.Parameters["@stateProvince"].Value = textBoxState.Text;
                            addCustomerAddress.Parameters["@postalCode"].Value = textBoxZipCode.Text;

                            addCustomerAddress.ExecuteNonQuery();
                            YellowBucketConnection.Close();

                            // SECOND: Add New Customer
                            YellowBucketConnection.Open();
                            SqlCommand updateCustomerRecord = new SqlCommand("UPDATE dbo.Customer SET email = @email, alternateEmail = @alternateEmail, userPassword = @userPassword, creditCard = @creditCard WHERE userName = @userName;", YellowBucketConnection);

                            updateCustomerRecord.Parameters.Add("@email", SqlDbType.VarChar);
                            updateCustomerRecord.Parameters.Add("@alternateEmail", SqlDbType.VarChar);
                            updateCustomerRecord.Parameters.Add("@userName", SqlDbType.VarChar);
                            updateCustomerRecord.Parameters.Add("@userPassword", SqlDbType.VarChar);
                            updateCustomerRecord.Parameters.Add("@creditCard", SqlDbType.VarChar);

                            updateCustomerRecord.Parameters["@email"].Value = textBoxEmail.Text;
                            updateCustomerRecord.Parameters["@alternateEmail"].Value = textBoxAlternateEmail.Text;

                            updateCustomerRecord.Parameters["@userName"].Value = lblCustomerUsername.Text;
                            updateCustomerRecord.Parameters["@userPassword"].Value = Encryptor(textBoxPassword.Text);
                            updateCustomerRecord.Parameters["@creditCard"].Value = Encryptor(maskedTextBoxCreditCardNumber.Text);

                            updateCustomerRecord.ExecuteNonQuery();
                            YellowBucketConnection.Close();

                            // THIRD: Find AddressID of Address Just Added to Database
                            YellowBucketConnection.Open();
                            SqlDataReader findCustomerAddressID = null;
                            SqlCommand findAddressID = new SqlCommand("SELECT customerAddressID FROM dbo.CustomerAddress WHERE addressLine1 = @addressLine1 AND addressLine2 = @addressLine2 AND city = @city AND stateProvince = @stateProvince AND postalCode = @postalCode;", YellowBucketConnection);

                            findAddressID.Parameters.Add("@addressLine1", SqlDbType.VarChar);
                            findAddressID.Parameters.Add("@addressLine2", SqlDbType.VarChar);
                            findAddressID.Parameters.Add("@city", SqlDbType.VarChar);
                            findAddressID.Parameters.Add("@stateProvince", SqlDbType.VarChar);
                            findAddressID.Parameters.Add("@postalCode", SqlDbType.VarChar);

                            findAddressID.Parameters["@addressLine1"].Value = textBoxAddressLine1.Text;
                            findAddressID.Parameters["@addressLine2"].Value = textBoxAddressLine2.Text;
                            
                            findAddressID.Parameters["@city"].Value = textBoxCity.Text;
                            findAddressID.Parameters["@stateProvince"].Value = textBoxState.Text;
                            findAddressID.Parameters["@postalCode"].Value = textBoxZipCode.Text;

                            findCustomerAddressID = findAddressID.ExecuteReader();
                            existingAddress.Load(findCustomerAddressID);
                            DataRow newAddressIDTableRow = existingAddress.Rows[0];

                            YellowBucketConnection.Close();

                            // FOURTH: Connect New Customer to New Address
                            YellowBucketConnection.Open();
                            SqlCommand updateCustomerWithAddressID = new SqlCommand("UPDATE dbo.Customer SET customerAddressID = @addressID WHERE userName = @userName;", YellowBucketConnection);
                            updateCustomerWithAddressID.Parameters.Add("@addressID", SqlDbType.Int);
                            updateCustomerWithAddressID.Parameters["@addressID"].Value = newAddressIDTableRow["customerAddressID"];
                            updateCustomerWithAddressID.Parameters.Add("@userName", SqlDbType.VarChar);
                            updateCustomerWithAddressID.Parameters["@userName"].Value = lblCustomerUsername.Text;

                            updateCustomerWithAddressID.ExecuteNonQuery();
                            YellowBucketConnection.Close();
                        }

                        lblSaveStatus.Text = "SUCCESS: New Customer Information Saved!";
                    }

                    catch (Exception ex)
                    {
                        lblErrorMessage.Text = "Unable to save new customer information: " + ex.ToString();
                        Console.WriteLine(ex.ToString());
                    }
                }
            }
            else
            {
                return;
            }
        }

        private bool testPasswordValidity() // Test to be sure that passwords are not null, too short, or too long
        {
            string password1 = textBoxPassword.Text;
            string password2 = textBoxConfirmPassword.Text;

            lblPasswordInfoMessage.Text = "";
            lblPasswordNull.Text = "";
            lblPasswordLengthWarning.Text = "";
            lblPasswordsMatch.Text = "";

            if (password1 == "" || password2 == "")
            {
                lblPasswordNull.Text = "Password must not be empty!";
                lblSaveStatus.Text = "Unable to save new customer information.  Password Error";
                return false;
            }
            else
            {
                if (password1.Length < 8)
                {
                    lblPasswordLengthWarning.Text = "Password too short!";
                    lblSaveStatus.Text = "Unable to save new customer information.  Password Error";
                    return false;
                }
                else
                {
                    if (password1.Length > 24)
                    {
                        lblPasswordLengthWarning.Text = "Password too long!";
                        lblSaveStatus.Text = "Unable to save new customer information.  Password Error";
                        return false;
                    }
                    else
                    {
                        if (password1 == password2)
                        {
                            lblSaveStatus.Text = "";
                            lblPasswordsMatch.Text = "Passwords Match!";
                            return true;
                        }
                        else
                        {
                            lblPasswordsMatch.Text = "Passwords Must Match!";
                            lblSaveStatus.Text = "Unable to save new customer information.  Password Error";
                            return false;
                        }
                    }
                }
            }
        }

        private bool testTextBoxInputValidity() // Test to be sure that no required field is null
        {
            string email = textBoxEmail.Text;
            string password = textBoxPassword.Text;
            string confirmPassword = textBoxConfirmPassword.Text;
            string address1 = textBoxAddressLine1.Text;
            string city = textBoxCity.Text;
            string state = textBoxState.Text;
            string zip = textBoxZipCode.Text;

            if (email == "" || password == "" || confirmPassword == "" || address1 == "" || city == "" || state == "" || zip == "")
            {
                lblSaveStatus.Text = "Unable to save new customer information.  Required Fields Must Not Be Empty";
                return false;
            }
            else
            {
                return true;
            }
        }

        private string Encryptor(string stringToEncrypt)  // Code Copied From: http://www.codeproject.com/Articles/19538/Encrypt-Decrypt-String-using-DES-in-C
        {
            if (String.IsNullOrEmpty(stringToEncrypt))
            {
                throw new ArgumentNullException("The string to be encrypted can not be null.");
            }

            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoProvider.CreateEncryptor(bytes, bytes), CryptoStreamMode.Write);

            StreamWriter writer = new StreamWriter(cryptoStream);
            writer.Write(stringToEncrypt);
            writer.Flush();
            cryptoStream.FlushFinalBlock();
            writer.Flush();
            return Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
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
