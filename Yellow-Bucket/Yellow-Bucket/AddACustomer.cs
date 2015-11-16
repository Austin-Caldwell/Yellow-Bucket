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
            if(testPasswordValidity() && testTextBoxInputValidity())
            {
                try
                {


                    lblSaveStatus.Text = "SUCCESS: New Customer Information Saved!";
                }

                catch (Exception ex)
                {
                    lblSaveStatus.Text = "Unable to save new customer information: " + ex.ToString();
                    Console.WriteLine(ex.ToString());
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
                    if (password1.Length > 32)
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
    }
}
