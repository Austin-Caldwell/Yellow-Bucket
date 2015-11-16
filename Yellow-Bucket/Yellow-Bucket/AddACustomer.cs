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
    public partial class AddACustomer : Form
    {
        protected SqlConnection YellowBucketConnection;
        // Austin Caldwell's Connection String:
        protected string connectionString = "Server=AUSTINC-LAPTOP\\SQLEXPRESS;Database=YellowBucketCSC365;Trusted_Connection=True;";
        // Evan Wehr's Connection String:
        // Jacob Girvin's Connection String: 
        // Use YellowBucketConnection = new SqlConnection(connectionString); when you need to open a connection

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
            if(testPasswordValidity(textBoxPassword.Text, textBoxConfirmPassword.Text))
            {
                try
                {
                    //testIfAddressAlreadyExists(textBoxAddressLine1.Text, textBoxCity.Text, textBoxState.Text, maskedTextBoxPostalCode.Text);
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            else
            {
                return;
            }
        }

        private bool testPasswordValidity(string password1, string password2)
        {
            if (password1 == "" || password2 == "")
            {
                lblPasswordNull.Text = "Password must not be empty!";
                return false;
            }
            else
            {
                lblPasswordNull.Text = "";

                if (password1 == password2)
                {
                    lblPasswordsMatch.Text = "Passwords Match!";
                    return true;
                }
                else
                {
                    lblPasswordsMatch.Text = "Passwords Must Match!";
                    lblSaveStatus.Text = "Unable to save new customer information.  Passwords do not match.";
                    return false;
                }
            }
        }

        //private bool testIfAddressAlreadyExists(string addressLine1, string city, string state, string zipCode)
        //{
        //    int doesAddressExist = 0;

        //    using (YellowBucketConnection = new SqlConnection(connectionString))
        //    {
        //        try
        //        {
        //            YellowBucketConnection.Open();
        //            SqlCommand addressCheck = new SqlCommand("SELECT * FROM dbo.CustomerAddress WHERE addressLine1 = @addressLine1 AND city = @city AND stateProvince = @stateProvince AND postalCode = @postalCode", YellowBucketConnection);
        //            addressCheck.Parameters.Add("@addressLine1", SqlDbType.VarChar);
        //            addressCheck.Parameters.Add("@city", SqlDbType.VarChar);
        //            addressCheck.Parameters.Add("@stateProvince", SqlDbType.VarChar);
        //            addressCheck.Parameters.Add("@postalCode", SqlDbType.VarChar);

        //            addressCheck.Parameters["@addressLine1"].Value = textBoxAddressLine1.Text;
        //            addressCheck.Parameters["@city"].Value = textBoxCity.Text;
        //            addressCheck.Parameters["@stateProvince"].Value = textBoxState.Text;
        //            addressCheck.Parameters["@postalCode"].Value = maskedTextBoxPostalCode.Text;

        //            doesAddressExist = addressCheck.ExecuteNonQuery();

        //            if (doesAddressExist == 1)
        //            {
        //                lblSaveStatus.Text = "Yes, the address already exists.";
        //                YellowBucketConnection.Close();
        //                return true;
        //            }
        //            else
        //            {
        //                lblSaveStatus.Text = "No, the address did not already exist.";
        //                YellowBucketConnection.Close();
        //                return false;
        //            }
        //        }

        //        catch (Exception ex)
        //        {
        //            Console.WriteLine(ex.ToString());
        //            return false;
        //        }
        //    }
        //}
    }
}
