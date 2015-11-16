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
    public partial class ListAllCustomers : Form
    {
        protected SqlConnection YellowBucketConnection;
        // Austin Caldwell's Connection String:
        protected string connectionString = "Server=AUSTINC-LAPTOP\\SQLEXPRESS;Database=YellowBucketCSC365;Trusted_Connection=True;";
        // Evan Wehr's Connection String:
        // Jacob Girvin's Connection String: 
        // Use YellowBucketConnection = new SqlConnection(connectionString); when you need to open a connection

        public ListAllCustomers()
        {
            InitializeComponent();
        }

        private void ListAllCustomers_Load(object sender, EventArgs e)
        {
            fillListOfAllCustomers();
        }

        private void fillListOfAllCustomers()
        {
            DataTable allCustomers = new DataTable();

            using (YellowBucketConnection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT concat(lastname, ', ', firstname, ' - ', userName) AS fullname FROM dbo.Customer", YellowBucketConnection);
                    adapter.Fill(allCustomers);

                    listBoxOfAllCustomers.ValueMember = "id";
                    listBoxOfAllCustomers.DisplayMember = "fullname";
                    listBoxOfAllCustomers.DataSource = allCustomers;

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

        private void buttonToAddCustomer_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddACustomer addCustomerForm = new AddACustomer();
            addCustomerForm.Show();
        }

        private void buttonToDeleteCustomer_Click(object sender, EventArgs e)
        {
            this.Hide();
            YELLOW_BUCKET____DELETE_A_CUSTOMER deleteCustomerForm = new YELLOW_BUCKET____DELETE_A_CUSTOMER();
            deleteCustomerForm.Show();
        }
    }
}
