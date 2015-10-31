using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yellow_Bucket
{
    public partial class YellowBucketHome : Form
    {
        public YellowBucketHome()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void hOMEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            YellowBucketHome home = new YellowBucketHome();
            home.Show();
        }

        private void cUSTOMERSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Customers customers = new Customers();
            customers.Show();
        }
    }
}
