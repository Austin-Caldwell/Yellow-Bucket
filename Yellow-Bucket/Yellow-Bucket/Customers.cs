﻿// CSC 365 -- Austin Caldwell, Evan Wehr, Jacob Girvin -- 2015
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
    public partial class Customers : Form
    {
        public Customers()
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

        private void buttonToListAllCustomers_Click(object sender, EventArgs e)
        {
            this.Hide();
            ListAllCustomers listAllCustomersForm = new ListAllCustomers();
            listAllCustomersForm.Show();
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
