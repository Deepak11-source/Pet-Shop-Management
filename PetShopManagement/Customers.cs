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

namespace PetShopManagement
{
    public partial class Customers : Form
    {
        public Customers()
        {
            InitializeComponent();
            DisplayCustomers();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=PetShopDb;Integrated Security=True;Pooling=False");

        private void DisplayCustomers()
        {
            Con.Open();
            string Query = "Select * from CustomerTb1";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            CustomersDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void Clear()
        {
            CustNameTb.Text = " ";
            CustAddTb.Text = " ";
            CustPhoneTb.Text = " ";
        }

        private void Savebtn_Click(object sender, EventArgs e)
        {
            if (CustNameTb.Text == "" || CustAddTb.Text == "" || CustPhoneTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string insertQuery = "insert into CustomerTb1 (CustName, CustAdd, CustPhone) values('" + CustNameTb.Text + "',  '" + CustAddTb.Text + "',  '" + CustPhoneTb.Text + "')";
                    SqlCommand cmd = new SqlCommand(insertQuery, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer Added");
                    Con.Close();
                    DisplayCustomers();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void Editbtn_Click(object sender, EventArgs e)
        {
            if (CustNameTb.Text == "" || CustAddTb.Text == "" || CustPhoneTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string updateQuery = "update CustomerTb1 Set  CustName = ' " + CustNameTb.Text + " ',  CustAdd =  '" + CustAddTb.Text + "', CustPhone = '" + CustPhoneTb.Text + "'  Where CustId= '" + int.Parse(CustIdTb.Text) + "' ";
                    SqlCommand cmd = new SqlCommand(updateQuery, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer Updated!!!");
                    Con.Close();
                    DisplayCustomers();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void Deletebtn_Click(object sender, EventArgs e)
        {
            try
            {
                Con.Open();
                string deleteQuery = "delete from CustomerTb1 WHERE CustId= '" + int.Parse(CustIdTb.Text) + "' ";
                SqlCommand cmd = new SqlCommand(deleteQuery, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Customer Deleted");
                Con.Close();
                DisplayCustomers();
                Clear();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Homes obj = new Homes();
            obj.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Products obj = new Products();
            obj.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
           Employees obj = new Employees();
            obj.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Billings obj = new Billings();
            obj.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }
    }
}
