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


namespace Yellow_Bucket
{
    public partial class AddMovieToKiosk : Form
    {
        protected SqlConnection YellowBucketConnection;
        protected string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        private string selectedKiosk;
        private string selectedMovie;
        private string movieType;
        private int quantity;

        public AddMovieToKiosk()
        {
            InitializeComponent();
        }
        private void ListAllKiosks_Load(object sender, EventArgs e)
        {
            fillListOfAllKiosks();
            fillListOfAllMovies();

            comboBoxOfTypeOfDisk.Items.Add("DVD");
            comboBoxOfTypeOfDisk.Items.Add("BluRay");
        }
        private void fillListOfAllKiosks()
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
        private void fillListOfAllMovies()
        {
            DataTable allMovies = new DataTable();

            using (YellowBucketConnection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT concat(movieID, ') ', title, ' (', releaseDate, ')') AS listing FROM dbo.Movie", YellowBucketConnection);
                    adapter.Fill(allMovies);
                    comboBoxOfMovies.ValueMember = "id";
                    comboBoxOfMovies.DisplayMember = "listing";
                    comboBoxOfMovies.DataSource = allMovies;
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

        private void addMovie_Click(object sender, EventArgs e)
        {
            char[] delimiterChars = { ')' };

            string[] kioskAddress = comboBoxOfKiosks.Text.Split(delimiterChars);
            string[] movieAddress = comboBoxOfMovies.Text.Split(delimiterChars);
            string[] TypeAddress = comboBoxOfTypeOfDisk.Text.Split(delimiterChars);

           
            
            selectedKiosk = kioskAddress[0];
            selectedMovie = movieAddress[0];
            movieType = TypeAddress[0];
          

            DataTable inventory = new DataTable();
            using (YellowBucketConnection = new SqlConnection(connectionString))
                
            try //try to update a movie if it already exists
            {
                   
                //GET QUANTITY AND INCREMENT
                YellowBucketConnection.Open();
                   SqlDataReader ReadInventory = null;

                   //declare the command
                   SqlCommand findMovie = new SqlCommand("Select quantityAtKiosk FROM dbo.Inventory WHERE kioskID = @selectedKiosk AND movieID = @selectedMovie AND dvdBluRay = @movieType;", YellowBucketConnection);

                   //declare the varialbe type
                   findMovie.Parameters.Add("@selectedKiosk", SqlDbType.Int);
                   findMovie.Parameters.Add("@selectedMovie", SqlDbType.Int);
                   findMovie.Parameters.Add("@movieType", SqlDbType.VarChar);

                   //declare the definition of the variable (the definition is delcared about 10 lines up)
                   findMovie.Parameters["@selectedKiosk"].Value = selectedKiosk;
                   findMovie.Parameters["@selectedMovie"].Value = selectedMovie;
                   findMovie.Parameters["@movieType"].Value = movieType;

                   //declares the execution trigger
                   ReadInventory = findMovie.ExecuteReader();
      
                   //pulls trigger and increments quantity
                   inventory.Load(ReadInventory);
                   DataRow inventoryRow = inventory.Rows[0];
                   int currentQuantity;
                   currentQuantity = Convert.ToInt32(inventoryRow["quantityAtKiosk"]);
                   string stringQuantity = textQuantity.Text;
                   int addQuantity = Convert.ToInt32(stringQuantity);
                   quantity = currentQuantity + addQuantity;
                   
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
                             updateQuantity.Parameters["@movieType"].Value = movieType;
                             updateQuantity.Parameters["@quantity"].Value = quantity;

                             //runs update
                             updateQuantity.ExecuteNonQuery();

                             MessageBox.Show("Add Successful");
 
               } //inserts a new movie of quantitity = 1;
               catch 
               {
                   using (YellowBucketConnection = new SqlConnection(connectionString))
                   
                   try
                   {
                       YellowBucketConnection.Open();
                       //INSERT

                       //gets quanity to add
                       string stringQuantity = textQuantity.Text;
                       int addQuantity = Convert.ToInt32(stringQuantity);
                       quantity = addQuantity;

                       SqlCommand addMovie = new SqlCommand("INSERT INTO dbo.Inventory(dvdBluRay, quantityAtKiosk, inStock, movieID, kioskID) VALUES(@movieType, @quantity, 1, @selectedMovie, @selectedKiosk);", YellowBucketConnection);

                           //declare the varialbe type         
                           addMovie.Parameters.Add("@selectedKiosk", SqlDbType.Int);
                           addMovie.Parameters.Add("@selectedMovie", SqlDbType.Int);
                           addMovie.Parameters.Add("@movieType", SqlDbType.VarChar);
                           addMovie.Parameters.Add("@quantity", SqlDbType.Int);

                           //declare the definition of the variable (the definition is delcared about 10 lines up)
                           addMovie.Parameters["@selectedKiosk"].Value = selectedKiosk;
                           addMovie.Parameters["@selectedMovie"].Value = selectedMovie;
                           addMovie.Parameters["@movieType"].Value = movieType;
                           addMovie.Parameters["@quantity"].Value = quantity;

                           //runs insert
                           addMovie.ExecuteNonQuery();

                           MessageBox.Show("Add Successful");

                   }
                   catch (Exception ex)
                   {
                       MessageBox.Show("Add Unsucsessfull" + ex.ToString());
                   }
               }
            YellowBucketConnection.Close();
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

