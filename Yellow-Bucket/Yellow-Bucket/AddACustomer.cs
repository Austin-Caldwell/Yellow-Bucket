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
    public partial class AddACustomer : Form
    {
        static byte[] bytes = ASCIIEncoding.ASCII.GetBytes("HideWord");

        protected SqlConnection YellowBucketConnection;
        // Austin Caldwell's Connection String:
        protected string connectionString = "Server=AUSTINC-LAPTOP\\SQLEXPRESS;Database=YellowBucketCSC365;Trusted_Connection=True;";
        // Evan Wehr's Connection String:
        // Jacob Girvin's Connection String:
        //protected string connectionString = "Server=COLLEGECOMPUTER\\SQLEXPRESS;Database=YellowBucketCSC365;Trusted_Connection=True;";

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
            if(testPasswordValidity() && testTextBoxInputValidity())
            {
                using (YellowBucketConnection = new SqlConnection(connectionString))
                {
                    try
                    {
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
                        if (textBoxAlterateEmail.Text == "")
                        {
                            addCustomerRecord.Parameters["@alternateEmail"].Value = "";
                        }
                        else
                        {
                            addCustomerRecord.Parameters["@alternateEmail"].Value = textBoxAlterateEmail.Text;
                        }
                        addCustomerRecord.Parameters["@userName"].Value = textBoxUsername.Text;
                        addCustomerRecord.Parameters["@userPassword"].Value = EncryptPassword(textBoxPassword.Text);
                        if (maskedTextBoxCreditCardNumber.Text == "")
                        {
                            addCustomerRecord.Parameters["@creditCard"].Value = "";
                        }
                        else
                        {
                            addCustomerRecord.Parameters["@creditCard"].Value = maskedTextBoxCreditCardNumber.Text;
                        }

                        addCustomerRecord.ExecuteNonQuery();

                        lblSaveStatus.Text = "SUCCESS: New Customer Information Saved!";

                    }

                    catch (Exception ex)
                    {
                        label1.Text = "Unable to save new customer information: " + ex.ToString();
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

        //private bool testUsernameUniqueness()
        //{
        //    using (YellowBucketConnection = new SqlConnection(connectionString))
        //    {
        //        try
        //        {
        //            YellowBucketConnection.Open();
        //            SqlCommand findUsernameCommand = new SqlCommand("SELECT userName FROM dbo.Customer WHERE userName = @userName;", YellowBucketConnection);
        //            findUsernameCommand.Parameters.Add("@userName", SqlDbType.VarChar);
        //            findUsernameCommand.Parameters["@userName"].Value = textBoxUsername.Text;
                    
        //            SqlDataAdapter findUsername = new SqlDataAdapter(findUsernameCommand);

        //            if (findUsername.Equals(textBoxUsername.Text))
        //            {
        //                lblSaveStatus.Text = "Username " + textBoxUsername.Text + "already exists.  Username must be unique.";
        //                YellowBucketConnection.Close();
        //                return false;
        //            }
        //            else
        //            {
        //                YellowBucketConnection.Close();
        //                return true;
        //            }
        //        }

        //        catch (Exception ex)
        //        {
        //            lblSaveStatus.Text = "Unable to verify username uniqueness: " + ex.ToString();
        //            YellowBucketConnection.Close();
        //            return false;
        //        }
        //    }
        //}

        private string EncryptPassword(string stringToEncrypt)  // Code Copied From: http://www.codeproject.com/Articles/19538/Encrypt-Decrypt-String-using-DES-in-C
        {
            if(String.IsNullOrEmpty(stringToEncrypt))
            {
                throw new ArgumentNullException("The password to be encrypted cannot be blank.");
            }

            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoProvider.CreateEncryptor(bytes, bytes), CryptoStreamMode.Write);

            StreamWriter writer = new StreamWriter(cryptoStream);
            writer.Write(stringToEncrypt);
            writer.Flush();
            cryptoStream.FlushFinalBlock();
            writer.Flush();
            label1.Text = Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
            return Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
        }
    }
}
