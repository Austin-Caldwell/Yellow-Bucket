using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;    // To access database

namespace Yellow_Bucket
{
    public partial class YELLOW_BUCKET____DELETE_A_CUSTOMER : Form
    {
        protected SqlConnection YellowBucketConnection;
        // Austin Caldwell's Connection String:
        protected string connectionString = "Server=AUSTINC-LAPTOP\\SQLEXPRESS;Database=YellowBucketCSC365;Trusted_Connection=True;";
        // Evan Wehr's Connection String:
        // Jacob Girvin's Connection String:
        //protected string connectionString = "Server=COLLEGECOMPUTER\\SQLEXPRESS;Database=YellowBucketCSC365;Trusted_Connection=True;";

        // Variables to hold the firstname, lastname, and username of the customer selected in the comboBoxOfCustomers
        private string selectedCustomerFirstName;
        private string selectedCustomerLastName;
        private string selectedCustomerUserName;

        public YELLOW_BUCKET____DELETE_A_CUSTOMER()
        {
            InitializeComponent();
        }

        private void YELLOW_BUCKET____DELETE_A_CUSTOMER_Load(object sender, EventArgs e)
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

        private void comboBoxOfCustomers_SelectedIndexChanged(object sender, EventArgs e) // Setting the selected customer's firstnames, lastnames, and usernames based on comboBoxOfCustomers selection
        {
            char[] delimiterChars = {' '};

            lblDeletionStatus.Text = "";    // Reset status message when selected customer is changed

            string[] customerName = comboBoxOfCustomers.Text.Split(delimiterChars); // Parse text from comboBoxOfCustomers to separate customer first name from last name
            selectedCustomerFirstName = customerName[0];
            selectedCustomerLastName = customerName[1];
            selectedCustomerUserName = customerName[3];
        }

        private void buttonToDeleteCustomer_Click(object sender, EventArgs e)   // Delete customer record based on the selected customer's username; Will also delete customer's address on record
        {
            using (YellowBucketConnection = new SqlConnection(connectionString))
            {
                try
                {
                    YellowBucketConnection.Open();
                    SqlCommand deleteCustomer = new SqlCommand("DELETE FROM dbo.Customer WHERE userName = @userName;", YellowBucketConnection);
                    deleteCustomer.Parameters.Add("@userName", SqlDbType.VarChar);
                    deleteCustomer.Parameters["@userName"].Value = selectedCustomerUserName;

                    deleteCustomer.ExecuteNonQuery();

                    YellowBucketConnection.Close();
                    fillCustomerComboBox();
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Customer Deletion of " + selectedCustomerFirstName + " " + selectedCustomerLastName + " with Username: " + selectedCustomerUserName + " FAILED!\n" + ex.ToString());
                }
            }
        }
    }
}
