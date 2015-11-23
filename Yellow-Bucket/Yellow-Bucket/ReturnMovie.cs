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
    public partial class ReturnMovie : Form
    {
        protected SqlConnection YellowBucketConnection;
        // Austin Caldwell's Connection String:
        protected string connectionString = "Server=AUSTINC-LAPTOP\\SQLEXPRESS;Database=YellowBucketCSC365;Trusted_Connection=True;";
        // Evan Wehr's Connection String:
        // Jacob Girvin's Connection String:
        //protected string connectionString = "Server=COLLEGECOMPUTER\\SQLEXPRESS;Database=YellowBucketCSC365;Trusted_Connection=True;";

        private int selectedCustomerID;
        private string selectedCustomerUsername;
        private int selectedStockID;
        private int selectedKioskID;
        private string selectedMovie;
        private int selectedMovieID;
        private int quantity;

        public ReturnMovie()
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
            Kiosks kioskForm = new Kiosks();
            kioskForm.Show();
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
            ReturnMovie returnMovieForm = new ReturnMovie();
            returnMovieForm.Show();
        }

        private void rENTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            RentAMovie rentMovieForm = new RentAMovie();
            rentMovieForm.Show();
        }

        private void ReturnMovie_Load(object sender, EventArgs e)
        {
            fillwithCustomers();    // FIRST: Fill list of customers, and have user select one
            fillwithLocations();
        }

        private void fillwithCustomers()    // Populate list of customers
        {
            DataTable allCustomers = new DataTable();

            using (YellowBucketConnection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT concat(firstName, ' ', lastName, ' - ', userName) AS fullname FROM dbo.Customer", YellowBucketConnection);
                    adapter.Fill(allCustomers);

                    comboBoxCustomers.ValueMember = "id";
                    comboBoxCustomers.DisplayMember = "fullname";
                    comboBoxCustomers.DataSource = allCustomers;

                    YellowBucketConnection.Close();
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Unable to populate list of customers: " + ex.ToString());
                }
            }
        }

        private void fillwithmovies()   // Populate list of movies currently held as rentals by the selected customer
        {
            DataTable allmovies = new DataTable();

            using (YellowBucketConnection = new SqlConnection(connectionString))
            {
                try
                {
                    YellowBucketConnection.Open();

                    SqlCommand findCustomerRentals = new SqlCommand("SELECT concat(Movie.movieID, ') ', title) AS listing FROM dbo.Rental, dbo.Inventory, dbo.Movie WHERE Rental.customerID = @customerID AND Rental.stockID = Inventory.stockID AND Inventory.movieID = Movie.movieID AND dateReturned IS NULL;", YellowBucketConnection);
                    findCustomerRentals.Parameters.Add("@customerID", SqlDbType.Int);
                    findCustomerRentals.Parameters["@customerID"].Value = selectedCustomerID;
                    
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = findCustomerRentals;

                    adapter.Fill(allmovies);

                    comboBoxMovies.ValueMember = "id";

                    comboBoxMovies.DisplayMember = "listing";

                    comboBoxMovies.DataSource = allmovies;

                    YellowBucketConnection.Close();
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Unable to populate list of movies: " + ex.ToString());
                }
            }

        }

        private string findDiscType()   // Find and return the disc type (DVD or BluRay) of the inventory stockID movie selected to be returned
        {
            DataTable typeOfDisc = new DataTable();
            string returnedMovieDiscType = "";

            using (YellowBucketConnection = new SqlConnection(connectionString))
            {
                try
                {
                    YellowBucketConnection.Open();

                    SqlCommand discTypeFinder = new SqlCommand("SELECT dvdBluRay FROM dbo.Inventory WHERE stockID = @stockID;", YellowBucketConnection);
                    discTypeFinder.Parameters.Add("@stockID", SqlDbType.Int);
                    discTypeFinder.Parameters["stockID"].Value = selectedStockID;
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = discTypeFinder;

                    adapter.Fill(typeOfDisc);

                    DataRow discTypeRow = typeOfDisc.Rows[0];

                    returnedMovieDiscType = discTypeRow["dvdBluRay"].ToString();

                    YellowBucketConnection.Close();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }

            return returnedMovieDiscType;
        }

        private void fillwithLocations()    // Fill comboBoxKiosk with list of all kiosk locations
        {
            DataTable allKiosks = new DataTable();

            using (YellowBucketConnection = new SqlConnection(connectionString))
            {
                try
                {
                    YellowBucketConnection.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT concat(kioskID, ') ', location, ': ', addressLine1, addressLine2, ', ', city, ', ', stateProvince, ', ', postalCode) AS fulladdress FROM dbo.Kiosk", YellowBucketConnection);

                    adapter.Fill(allKiosks);

                    comboBoxKiosk.ValueMember = "id";

                    comboBoxKiosk.DisplayMember = "fulladdress";

                    comboBoxKiosk.DataSource = allKiosks;

                    YellowBucketConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error populating list of kiosk locations: " + ex.ToString());
                }
            }
        }

        private void comboBoxCustomers_SelectedIndexChanged(object sender, EventArgs e)     // Find customerID of customer returning movie and fill comboBoxMovies based on selected customer
        {
            DataTable customerIDs = new DataTable();
            char[] delimiterChars = { ' ' };

            string[] customerName = comboBoxCustomers.Text.Split(delimiterChars); // Parse text from comboBoxOfCustomers to separate customer first name from last name
            selectedCustomerUsername = customerName[3];

            using (YellowBucketConnection = new SqlConnection(connectionString))
            {
                try
                {
                    YellowBucketConnection.Open();

                    SqlDataReader readCustomerID = null;
                    SqlCommand findCustomerID = new SqlCommand("SELECT customerID FROM dbo.Customer WHERE userName = @userName;", YellowBucketConnection);
                    findCustomerID.Parameters.Add("@userName", SqlDbType.VarChar);
                    findCustomerID.Parameters["@userName"].Value = selectedCustomerUsername;

                    readCustomerID = findCustomerID.ExecuteReader();

                    customerIDs.Load(readCustomerID);

                    DataRow customerIDRow = customerIDs.Rows[0];
                    selectedCustomerID = Convert.ToInt32(customerIDRow["customerID"]);

                    YellowBucketConnection.Close();
                }
                
                catch (Exception ex)
                {
                    MessageBox.Show("Unable to select Customer ID: " + ex.ToString());
                }
            }
            comboBoxMovies.Text = "";
            fillwithmovies();
        }

        private void comboBoxKiosk_SelectedIndexChanged(object sender, EventArgs e) // Find kioskID where the movie will be returned to
        {
            DataTable kioskIDs = new DataTable();
            char[] delimiterChars = { ')' };
            string[] kioskLocation = comboBoxKiosk.Text.Split(delimiterChars);
            selectedKioskID = Convert.ToInt32(kioskLocation[0]);
        }

        private void btnReturnMovie_Click(object sender, EventArgs e)   // UPDATE RENTAL table to show that the movie was returned (WHERE Rental.customerID = @customerID AND Rental.stockID = @stockID), then UPDATE RENTALHISTORY table, then INSERT new entry INTO INVENTORY Table
        {
            using (YellowBucketConnection = new SqlConnection(connectionString))

                try
                {
                    YellowBucketConnection.Open();

                    // UPDATE RENTAL Table
                    SqlCommand updateRentalRecord = new SqlCommand("UPDATE dbo.Rental SET dateReturned = @dateReturned WHERE customerID = @customerID AND Rental.stockID = @stockID;", YellowBucketConnection);
                    updateRentalRecord.Parameters.Add("@dateReturned", SqlDbType.DateTime);
                    updateRentalRecord.Parameters.Add("@customerID", SqlDbType.Int);
                    updateRentalRecord.Parameters.Add("@stockID", SqlDbType.Int);

                    updateRentalRecord.Parameters["@dateReturned"].Value = DateTime.Now;
                    updateRentalRecord.Parameters["@customerID"].Value = selectedCustomerID;
                    updateRentalRecord.Parameters["@stockID"].Value = selectedStockID;

                    updateRentalRecord.ExecuteNonQuery();

                    // INSERT new record INTO INVENTORY Table
                    SqlCommand insertNewInventoryRecord = new SqlCommand("INSERT INTO dbo.Inventory(dvdBluRay, quantityAtKiosk, inStock, movieID, kioskID) VALUES(@discType, @quantity, @inStock, @movieID, @kioskID);", YellowBucketConnection);

                }

                catch (Exception ex)
                {
                    MessageBox.Show("Return UNSUCCESSFUL: " + ex.ToString());
                }
        }

        private void comboBoxMovies_SelectedIndexChanged(object sender, EventArgs e)    // Find stockID of movie selected for return
        {
            DataTable stockIDs = new DataTable();
            char[] delimiterChars = { ')' };

            string[] movieSelected = comboBoxMovies.Text.Split(delimiterChars);
            selectedMovieID = Convert.ToInt32(movieSelected[0]);

            using(YellowBucketConnection = new SqlConnection(connectionString))
            {
                try
                {
                    YellowBucketConnection.Open();

                    SqlDataReader readRentalID = null;
                    SqlCommand findRentalID = new SqlCommand("SELECT Rental.stockID FROM dbo.Rental, dbo.Inventory WHERE Rental.customerID = @customerID AND Rental.stockID = Inventory.stockID AND Inventory.movieID = @movieID AND dateReturned IS NULL;", YellowBucketConnection);
                    findRentalID.Parameters.Add("@customerID", SqlDbType.Int);
                    findRentalID.Parameters.Add("@movieID", SqlDbType.Int);

                    findRentalID.Parameters["@customerID"].Value = selectedCustomerID;
                    findRentalID.Parameters["@movieID"].Value = selectedMovieID;

                    readRentalID = findRentalID.ExecuteReader();

                    stockIDs.Load(readRentalID);

                    DataRow stockIDRow = stockIDs.Rows[0];
                    selectedStockID = Convert.ToInt32(stockIDRow["stockID"]);

                    //MessageBox.Show("Selected StockID is: " + selectedStockID.ToString());

                    YellowBucketConnection.Close();
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Unable to obtain rented movie's stockID: " + ex.ToString());
                }
            }
        }   // Get Stock
    }
}
