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
using System.Security.Cryptography;
using System.IO;

namespace Yellow_Bucket
{
    public partial class AddACustomer : Form
    {
        static byte[] bytes = ASCIIEncoding.ASCII.GetBytes("HideWord");

        protected SqlConnection YellowBucketConnection;
        protected string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        public AddACustomer()
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

        private void buttonSaveNewCustomer_Click(object sender, EventArgs e)
        {
            if(testPasswordValidity() && testTextBoxInputValidity() && testUsernameUniqueness())
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

                        if(existingAddress.Rows.Count == 1) // If the address does already exist in the database
                        {
                            // FIRST: Create New Customer
                            YellowBucketConnection.Open();
                            SqlCommand addCustomerRecord = new SqlCommand("INSERT INTO Customer(firstName, lastName, email, alternateEmail, userName, userPassword, creditCard) VALUES (@firstName, @lastName, @email, @alternateEmail, @userName, @userPassword, @creditCard);", YellowBucketConnection);

                            addCustomerRecord.Parameters.Add("@firstName", SqlDbType.VarChar);
                            addCustomerRecord.Parameters.Add("@lastName", SqlDbType.VarChar);
                            addCustomerRecord.Parameters.Add("@email", SqlDbType.VarChar);
                            addCustomerRecord.Parameters.Add("@alternateEmail", SqlDbType.VarChar);
                            addCustomerRecord.Parameters.Add("@userName", SqlDbType.VarChar);
                            addCustomerRecord.Parameters.Add("@userPassword", SqlDbType.VarChar);
                            addCustomerRecord.Parameters.Add("@creditCard", SqlDbType.VarChar);

                            addCustomerRecord.Parameters["@firstName"].Value = textBoxFirstName.Text;
                            addCustomerRecord.Parameters["@lastName"].Value = textBoxLastName.Text;
                            addCustomerRecord.Parameters["@email"].Value = textBoxEmail.Text;
                            addCustomerRecord.Parameters["@alternateEmail"].Value = textBoxAlternateEmail.Text;

                            addCustomerRecord.Parameters["@userName"].Value = textBoxUsername.Text;
                            addCustomerRecord.Parameters["@userPassword"].Value = Encryptor(textBoxPassword.Text);
                            addCustomerRecord.Parameters["@creditCard"].Value = Encryptor(maskedTextBoxCreditCardNumber.Text);

                            addCustomerRecord.ExecuteNonQuery();
                            YellowBucketConnection.Close();

                            // SECOND: Find AddressID of Address Already in Database
                            DataRow addressIDTableRow = existingAddress.Rows[0];

                            // THIRD: Connect New Customer to Address Already in Database
                            YellowBucketConnection.Open();
                            SqlCommand updateCustomerWithAddressID = new SqlCommand("UPDATE dbo.Customer SET customerAddressID = @addressID WHERE userName = @userName;", YellowBucketConnection);
                            updateCustomerWithAddressID.Parameters.Add("@addressID", SqlDbType.Int);
                            updateCustomerWithAddressID.Parameters["@addressID"].Value = addressIDTableRow["customerAddressID"];
                            updateCustomerWithAddressID.Parameters.Add("@userName", SqlDbType.VarChar);
                            updateCustomerWithAddressID.Parameters["@userName"].Value = textBoxUsername.Text;

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
                            SqlCommand addCustomerRecord = new SqlCommand("INSERT INTO Customer(firstName, lastName, email, alternateEmail, userName, userPassword, creditCard) VALUES (@firstName, @lastName, @email, @alternateEmail, @userName, @userPassword, @creditCard);", YellowBucketConnection);

                            addCustomerRecord.Parameters.Add("@firstName", SqlDbType.VarChar);
                            addCustomerRecord.Parameters.Add("@lastName", SqlDbType.VarChar);
                            addCustomerRecord.Parameters.Add("@email", SqlDbType.VarChar);
                            addCustomerRecord.Parameters.Add("@alternateEmail", SqlDbType.VarChar);
                            addCustomerRecord.Parameters.Add("@userName", SqlDbType.VarChar);
                            addCustomerRecord.Parameters.Add("@userPassword", SqlDbType.VarChar);
                            addCustomerRecord.Parameters.Add("@creditCard", SqlDbType.VarChar);

                            addCustomerRecord.Parameters["@firstName"].Value = textBoxFirstName.Text;
                            addCustomerRecord.Parameters["@lastName"].Value = textBoxLastName.Text;
                            addCustomerRecord.Parameters["@email"].Value = textBoxEmail.Text;
                            addCustomerRecord.Parameters["@alternateEmail"].Value = textBoxAlternateEmail.Text;

                            addCustomerRecord.Parameters["@userName"].Value = textBoxUsername.Text;
                            addCustomerRecord.Parameters["@userPassword"].Value = Encryptor(textBoxPassword.Text);
                            addCustomerRecord.Parameters["@creditCard"].Value = Encryptor(maskedTextBoxCreditCardNumber.Text);

                            addCustomerRecord.ExecuteNonQuery();
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
                            updateCustomerWithAddressID.Parameters["@userName"].Value = textBoxUsername.Text;

                            updateCustomerWithAddressID.ExecuteNonQuery();
                            YellowBucketConnection.Close();
                        }

                        lblSaveStatus.Text = "SUCCESS: New Customer Information Saved!";
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show("Unable to save new customer information: " + ex.ToString());
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
            string firstName = textBoxFirstName.Text;
            string lastName = textBoxLastName.Text;
            string email = textBoxEmail.Text;
            string userName = textBoxUsername.Text;
            string password = textBoxPassword.Text;
            string confirmPassword = textBoxConfirmPassword.Text;
            string address1 = textBoxAddressLine1.Text;
            string city = textBoxCity.Text;
            string state = textBoxState.Text;
            string zip = textBoxZipCode.Text;

            if (firstName == "" || lastName == "" || email == "" || userName == "" || password == "" || confirmPassword == "" || address1 == "" || city == "" || state == "" || zip == "")
            {
                lblSaveStatus.Text = "Unable to save new customer information.  Required Fields Must Not Be Empty";
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool testUsernameUniqueness()
        {
            using (YellowBucketConnection = new SqlConnection(connectionString))
            {
                try
                {
                    YellowBucketConnection.Open();
                    DataTable userNames = new DataTable();

                    SqlDataReader findUsername = null;
                    SqlCommand findUsernameCommand = new SqlCommand("SELECT userName FROM dbo.Customer WHERE userName = @userName;", YellowBucketConnection);
                    findUsernameCommand.Parameters.Add("@userName", SqlDbType.VarChar);
                    findUsernameCommand.Parameters["@userName"].Value = textBoxUsername.Text;

                    findUsername = findUsernameCommand.ExecuteReader();

                    userNames.Load(findUsername);

                    if (userNames.Rows.Count == 1)
                    {
                        lblSaveStatus.Text = "Username already exists.  Change username.";
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Unable to verify username uniqueness: " + ex.ToString());
                    YellowBucketConnection.Close();
                    return false;
                }
            }
        }

        private string Encryptor(string stringToEncrypt)  // Code Copied From: http://www.codeproject.com/Articles/19538/Encrypt-Decrypt-String-using-DES-in-C
        {
            if(String.IsNullOrEmpty(stringToEncrypt))
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
    }
}
