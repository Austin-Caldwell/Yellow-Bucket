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
    public partial class ListAllMovies : Form
    {
        protected SqlConnection YellowBucketConnection;
        protected string connectionString = "Server=AUSTINC-LAPTOP\\SQLEXPRESS;Database=YellowBucketCSC365;Trusted_Connection=True;";
        // Use YellowBucketConnection = new SqlConnection(connectionString); when you need to open a connection

        public ListAllMovies()
        {
            InitializeComponent();
        }

        private void ListAllMovies_Load(object sender, EventArgs e)
        {
            fillListOfAllMovies();
        }

        private void listViewOfAllMovies_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void hOMEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            YellowBucketHome home = new YellowBucketHome();
            home.Show();
        }

        private void fillListOfAllMovies()
        {
            DataTable allMovies = new DataTable();

            using (YellowBucketConnection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT title FROM dbo.Movie", YellowBucketConnection);
                    adapter.Fill(allMovies);

                    listBoxOfAllMovies.ValueMember = "id";
                    listBoxOfAllMovies.DisplayMember = "title";
                    listBoxOfAllMovies.DataSource = allMovies;
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        private void buttonToSearchByMovieTitle_Click(object sender, EventArgs e)
        {
            this.Hide();
            Movies movies = new Movies();
            movies.Show();
        }
    }
}
