using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;    // To Access Database

namespace Yellow_Bucket
{
    public partial class ShowKioskInventory : Form
    {

        protected SqlConnection YellowBucketConnection;
        // Austin Caldwell's Connection String:
        // protected string connectionString = "Server=AUSTINC-LAPTOP\\SQLEXPRESS;Database=YellowBucketCSC365;Trusted_Connection=True;";
        // Evan Wehr's Connection String:
        protected string connectionString = "Server=HP\\SQLEXPRESS;Database=YellowBucketCSC365;Trusted_Connection=True;";

        // Jacob Girvin's Connection String: 
        // Use YellowBucketConnection = new SqlConnection(connectionString); when you need to open a connection

        private string selectedKiosk;

        public ShowKioskInventory()
        {
            InitializeComponent();

        }
        private void ListAllKiosks_Load(object sender, EventArgs e)
        {
            fillListOfAllKiosks();
        }

        private void fillListOfAllKiosks()
        {
            DataTable allKiosks = new DataTable();
            filldropdownOfAllKiosks();
        }
        private void filldropdownOfAllKiosks()
        {
            DataTable allKiosks = new DataTable();

            using (YellowBucketConnection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT concat(kioskID, ') ', location, ': ', addressLine1, addressLine2, ', ', city, ', ', stateProvince, ', ', postalCode) AS fulladdress FROM dbo.Kiosk", YellowBucketConnection);
                    adapter.Fill(allKiosks);

                    comboBoxOfKiosks.ValueMember = "id";
                    comboBoxOfKiosks.DisplayMember = "fulladdress";
                    comboBoxOfKiosks.DataSource = allKiosks;
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

        private void comboBoxOfKiosk_SelectedIndexChanged(object sender, EventArgs e)
        {
            char[] delimiterChars = { ')' };
            string[] kioskAddress = comboBoxOfKiosks.Text.Split(delimiterChars); 
            selectedKiosk = kioskAddress[0];

            DataTable inventory = new DataTable();
            using (YellowBucketConnection = new SqlConnection(connectionString))
            {
                try
                {
                    YellowBucketConnection.Open();
                    SqlDataReader ReadListing = null;
                    //declare the command          
                    SqlCommand findListing = new SqlCommand("SELECT concat(title, ' (', releaseDate, ') - ', quantityAtKiosk, ' copies in the form of ', dvdBluRay) AS listing FROM dbo.Movie, dbo.Inventory WHERE kioskID = @selectedKiosk AND Movie.movieID = Inventory.movieID ORDER BY title;", YellowBucketConnection);
                        //declare the varialbe type
                    findListing.Parameters.Add("@selectedKiosk", SqlDbType.Int);
                        //declare the definition of the variable (the definition is delcared about 10 lines up)
                    findListing.Parameters["@selectedKiosk"].Value = selectedKiosk;
                        //declares the execution trigger
                    ReadListing = findListing.ExecuteReader();
                        //pulls trigger
                    inventory.Load(ReadListing);

                    listBoxOfMovies.ValueMember = "id";
                    listBoxOfMovies.DisplayMember = "listing";
                    listBoxOfMovies.DataSource = inventory;
                    YellowBucketConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error populating kiosk inventory" + ex.ToString());
                    Console.WriteLine(ex.ToString());
                }
                YellowBucketConnection.Close();
            }
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


    }
}