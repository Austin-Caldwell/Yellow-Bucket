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
        private string selectedKiosk;
        private string selectedMovie;
        private string selectedtype;
        private int quantity;

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
            fillwithlocations();
            fillwithmovietypes();
        }
        private void fillwithmovietypes()
        {
            DataTable alltypes = new DataTable();
            using (YellowBucketConnection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT concat(stockID, ') ', dvdBluRay) AS listing FROM dbo.Inventory;", YellowBucketConnection);
                    adapter.Fill(alltypes);

                    comboBox1.ValueMember = "id";

                    comboBox1.DisplayMember = "listing";

                    comboBox1.DataSource = alltypes;

                    YellowBucketConnection.Close();
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error populating customer information: " + ex.ToString());
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
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT concat(movieID, ') ', title) AS listing FROM dbo.Movie;", YellowBucketConnection);
                    adapter.Fill(allmovies);

                    comboBoxMovie.ValueMember = "id";

                    comboBoxMovie.DisplayMember = "listing";

                    comboBoxMovie.DataSource = allmovies;

                    YellowBucketConnection.Close();
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error populating customer information: " + ex.ToString());
                }
            }
        }
        private void fillwithlocations()
        {
            DataTable allKiosks = new DataTable();

            using (YellowBucketConnection = new SqlConnection(connectionString))
            {
                try
                {

                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT concat(kioskID, ') ', location, ': ', addressLine1, addressLine2, ', ', city, ', ', stateProvince, ', ', postalCode) AS fulladdress FROM dbo.Kiosk", YellowBucketConnection);

                    adapter.Fill(allKiosks);

                    comboBoxKiosk.ValueMember = "id";
                    
                    comboBoxKiosk.DisplayMember = "fulladdress";

                    comboBoxKiosk.DataSource = allKiosks;

                    YellowBucketConnection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

            }

        }

        //private void btnRent_Click(object sender, EventArgs e)

        //{

        //    char[] delimiterChars = { ')' };




        //    string[] kioskAddress = comboBoxKiosk.Text.Split(delimiterChars);

        //    string[] movieAddress = comboBoxMovie.Text.Split(delimiterChars);

        //    string[] TypeAddress = comboBox1.Text.Split(delimiterChars);




        //    selectedKiosk = kioskAddress[0];

        //    selectedMovie = movieAddress[0];

        //    selectedtype = TypeAddress[0];






        //    DataTable inventory = new DataTable();

        //    using (YellowBucketConnection = new SqlConnection(connectionString))

        //        try //try to update a movie if it already exists

        //        {



        //            //GET QUANTITY AND INCREMENT

        //            YellowBucketConnection.Open();

        //            SqlDataReader ReadInventory = null;




        //            //declare the command

        //            //SqlCommand findMovie = new SqlCommand("Select quantityAtKiosk FROM dbo.Inventory WHERE kioskID = @selectedKiosk AND movieID = @selectedMovie AND dvdBluRay = @movieType;", YellowBucketConnection);
        //            SqlCommand findListing = new SqlCommand("SELECT concat(stockID, ') ', title, ' (', releaseDate, ') - ', quantityAtKiosk, ' copies in the form of ', dvdBluRay) AS listing FROM dbo.Movie, dbo.Inventory WHERE kioskID = @selectedKiosk AND Movie.movieID = Inventory.movieID ORDER BY title;", YellowBucketConnection);




        //            //declare the varialbe type

        //            findListing.Parameters.Add("@selectedKiosk", SqlDbType.Int);

        //            findListing.Parameters.Add("@selectedMovie", SqlDbType.Int);

        //            findListing.Parameters.Add("@movieType", SqlDbType.VarChar);




        //            //declare the definition of the variable (the definition is delcared about 10 lines up)

        //            findListing.Parameters["@selectedKiosk"].Value = selectedKiosk;

        //            findListing.Parameters["@selectedMovie"].Value = selectedMovie;

        //            findListing.Parameters["@movieType"].Value = selectedtype;




        //            //declares the execution trigger

        //            ReadInventory = findListing.ExecuteReader();



        //            //pulls trigger and increments quantity

        //            inventory.Load(ReadInventory);

        //            DataRow inventoryRow = inventory.Rows[0];

        //            quantity = Convert.ToInt32(inventoryRow["quantityAtKiosk"]);

        //            quantity += 1;

        //            MessageBox.Show("New quantity: " + quantity.ToString());




        //            //UPDATE

        //            SqlCommand updateQuantity = new SqlCommand("UPDATE dbo.Inventory SET quantityAtKiosk = @quantity WHERE kioskID = @selectedKiosk AND movieID = @selectedMovie AND dvdBluRay = @movieType;", YellowBucketConnection);



        //            //declare the varialbe type         

        //            updateQuantity.Parameters.Add("@selectedKiosk", SqlDbType.Int);

        //            updateQuantity.Parameters.Add("@selectedMovie", SqlDbType.Int);

        //            updateQuantity.Parameters.Add("@movieType", SqlDbType.VarChar);

        //            updateQuantity.Parameters.Add("@quantity", SqlDbType.Int);



        //            //declare the definition of the variable (the definition is delcared about 10 lines up)

        //            updateQuantity.Parameters["@selectedKiosk"].Value = selectedKiosk;

        //            updateQuantity.Parameters["@selectedMovie"].Value = selectedMovie;

        //            updateQuantity.Parameters["@movieType"].Value = selectedtype;

        //            updateQuantity.Parameters["@quantity"].Value = quantity;




        //            //runs update

        //            updateQuantity.ExecuteNonQuery();




        //            YellowBucketConnection.Close();




        //            MessageBox.Show("Add Successful");



        //        } //inserts a new movie of quantitity = 1;

        //        catch (Exception ex)

        //        {

        //            MessageBox.Show("Add Unsucsessfull" + ex.ToString());

        //        }

        //}
    //}

        private void btnRent_Click_1(object sender, EventArgs e)
        {
            char[] delimiterChars = { ')' };




            string[] kioskAddress = comboBoxKiosk.Text.Split(delimiterChars);

            string[] movieAddress = comboBoxMovie.Text.Split(delimiterChars);

            string[] TypeAddress = comboBox1.Text.Split(delimiterChars);




            selectedKiosk = kioskAddress[0];

            selectedMovie = movieAddress[0];

            selectedtype = TypeAddress[0];






            DataTable inventory = new DataTable();

            using (YellowBucketConnection = new SqlConnection(connectionString))

                try //try to update a movie if it already exists

                {



                    //GET QUANTITY AND INCREMENT

                    YellowBucketConnection.Open();

                    SqlDataReader ReadInventory = null;




                    //declare the command

                    //SqlCommand findMovie = new SqlCommand("Select quantityAtKiosk FROM dbo.Inventory WHERE kioskID = @selectedKiosk AND movieID = @selectedMovie AND dvdBluRay = @movieType;", YellowBucketConnection);
                    SqlCommand findListing = new SqlCommand("SELECT quantityAtKiosk, concat(stockID, ') ', title, ' (', releaseDate, ') - ', quantityAtKiosk, ' copies in the form of ', dvdBluRay) AS listing FROM dbo.Movie, dbo.Inventory WHERE kioskID = @selectedKiosk AND Movie.movieID = Inventory.movieID ORDER BY title;", YellowBucketConnection);




                    //declare the varialbe type

                    findListing.Parameters.Add("@selectedKiosk", SqlDbType.Int);

                    findListing.Parameters.Add("@selectedMovie", SqlDbType.Int);

                    findListing.Parameters.Add("@movieType", SqlDbType.VarChar);




                    //declare the definition of the variable (the definition is delcared about 10 lines up)

                    findListing.Parameters["@selectedKiosk"].Value = selectedKiosk;

                    findListing.Parameters["@selectedMovie"].Value = selectedMovie;

                    findListing.Parameters["@movieType"].Value = selectedtype;




                    //declares the execution trigger

                    ReadInventory = findListing.ExecuteReader();



                    //pulls trigger and increments quantity

                    inventory.Load(ReadInventory);

                    DataRow inventoryRow = inventory.Rows[0];

                    quantity = Convert.ToInt32(inventoryRow["quantityAtKiosk"]);

                    quantity = quantity - 1;

                    MessageBox.Show("New quantity: " + quantity.ToString());




                    //UPDATE

                    SqlCommand updateQuantity = new SqlCommand("UPDATE dbo.Inventory SET quantityAtKiosk = @quantity WHERE kioskID = @selectedKiosk AND movieID = @selectedMovie AND dvdBluRay = @movieType;", YellowBucketConnection);



                    //declare the varialbe type         

                    updateQuantity.Parameters.Add("@selectedKiosk", SqlDbType.Int);

                    updateQuantity.Parameters.Add("@selectedMovie", SqlDbType.Int);

                    updateQuantity.Parameters.Add("@movieType", SqlDbType.VarChar);

                    updateQuantity.Parameters.Add("@quantity", SqlDbType.Int);



                    //declare the definition of the variable (the definition is delcared about 10 lines up)

                    updateQuantity.Parameters["@selectedKiosk"].Value = selectedKiosk;

                    updateQuantity.Parameters["@selectedMovie"].Value = selectedMovie;

                    updateQuantity.Parameters["@movieType"].Value = selectedtype;

                    updateQuantity.Parameters["@quantity"].Value = quantity;




                    //runs update

                    updateQuantity.ExecuteNonQuery();




                    YellowBucketConnection.Close();




                    MessageBox.Show("Add Successful");



                } //inserts a new movie of quantitity = 1;

                catch (Exception ex)

                {

                    MessageBox.Show("Add Unsucsessfull" + ex.ToString());

                }

        }
    }
    }





