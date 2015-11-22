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
    public partial class RentAMovie : Form
    {
        protected SqlConnection YellowBucketConnection;
        // Austin Caldwell's Connection String:
        //protected string connectionString = "Server=AUSTINC-LAPTOP\\SQLEXPRESS;Database=YellowBucketCSC365;Trusted_Connection=True;";
        // Evan Wehr's Connection String:
        // Jacob Girvin's Connection String:
        protected string connectionString = "Server=COLLEGECOMPUTER\\SQLEXPRESS;Database=YellowBucketCSC365;Trusted_Connection=True;";
        private string selectedkiosklocation;
        private int selectedkioskID;

        public RentAMovie()
        {
            InitializeComponent();
        }

        private void rENTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            RentAMovie RentAMovieForm = new RentAMovie();
            RentAMovieForm.Show();
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
            Kiosks kioskForm = new Kiosks();
            kioskForm.Show();
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

        private void RentAMovie_Load(object sender, EventArgs e)
        {
            fillwithmovies();
        }

        private void fillkiosklocations()
        {
            using (YellowBucketConnection = new SqlConnection(connectionString))
            {
                try
                {
                    YellowBucketConnection.Open();

                    DataTable KioskTable = new DataTable();

                    SqlDataReader readKioskLocations = null;
                    SqlCommand findkiosklocations = new SqlCommand("SELECT concat(location, ' --addressline1, ' --city, ' --stateProvince, ' --postalCode, ' --movieID, ' --kioskID) AS KioskLocations From dbo.Kiosk, dbo.Inventory,dbo.Kiosk WHERE KioskLocations.movieID = @movieID and KioskLocations.kioskID = @kioskID;", YellowBucketConnection);
                    findkiosklocations.Parameters.Add("@movieID", SqlDbType.Int);
                    findkiosklocations.Parameters.Add("@kioskID", SqlDbType.Int);
                    findkiosklocations.Parameters["@movieID"].Value = selectedkioskID;
                    findkiosklocations.Parameters["kioskID"].Value = selectedkioskID;

                    readKioskLocations = findkiosklocations.ExecuteReader();

                    KioskTable.Load(readKioskLocations);

                    lstBoxFillKiosk.ValueMember = "stockID";
                    lstBoxFillKiosk.DisplayMember = "KioskLocations";
                    lstBoxFillKiosk.DataSource = KioskTable;

                    YellowBucketConnection.Close();
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        private void fillwithmovies()
        {
            DataTable allmovies = new DataTable();

            using (YellowBucketConnection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT title FROM dbo.Movie;", YellowBucketConnection);
                    adapter.Fill(allmovies);

                    lstBoxFillMovie.ValueMember = "id";
                    lstBoxFillMovie.DisplayMember = "title";
                    lstBoxFillMovie.DataSource = allmovies;

                    YellowBucketConnection.Close();
                }

                catch (Exception ex)
                {
                    lblErrorMessage.Text = ex.ToString();
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        //private void lstBoxFillKiosk_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    char[] delimiterChars = { ' ' };

        //    string[] kiosklocation = lstBoxFillKiosk.Text.Split(delimiterChars); // Parse text from comboBoxOfCustomers to separate customer first name from last name
        //    selectedkiosklocation = kiosklocation[3];

        //    using (YellowBucketConnection = new SqlConnection(connectionString))
        //    {
        //        try
        //        {
        //            YellowBucketConnection.Open();
        //            SqlDataReader readkiosklocations = null;
        //            SqlCommand populatekiosklocations = new SqlCommand("SELECT  movieID FROM dbo.Inventory, dbo.Kiosk WHERE movieID = @movieID AND Inventory.KioskID = Kiosk.KioskID;", YellowBucketConnection);
        //            populatekiosklocations.Parameters.Add("@movieID", SqlDbType.Int);
        //            populatekiosklocations.Parameters["@movieID"].Value = selectedkiosklocation;

        //            readkiosklocations = populatekiosklocations.ExecuteReader();

        //            while (readkiosklocations.Read())
        //            {
                        
        //                lstBoxFillKiosk.Text = readkiosklocations["movieID"].ToString();
                        

        //                YellowBucketConnection.Close();
        //            }
        //            }

        //        catch (Exception ex)
        //        {
        //            Console.WriteLine(ex.ToString());
        //        }
        //    }
       
        }
    }

    


