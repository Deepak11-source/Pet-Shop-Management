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
    public partial class Billings : Form
    {
        public Billings()
        {
            InitializeComponent();
            DisplayProduct();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=PetShopDb;Integrated Security=True;Pooling=False");
        private void DisplayProduct()
        {
            Con.Open();
            string Query = "select * from ProductTb1";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ProductsDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void Clear()
        {
            CustIdTb.Text = " ";
            CustNameTb.Text = " ";
            PrNameTb.Text = " ";
            PrQtyTb.Text = " ";
            PrPriceTb.Text = " ";
        }
        private void DisplayBillings()
        {
            Con.Open();
            string Query = "Select * from BillTb1";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            BillDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            double Total ,qty, price;
            qty = Convert.ToDouble(PrQtyTb.Text);
            price = Convert.ToDouble(PrPriceTb.Text);
            Total = qty * price;
            if (CustIdTb.Text == "" || CustNameTb.Text == "" || PrNameTb.Text == "" || PrPriceTb.Text == "" || PrQtyTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string insertQuery = "insert into BillTb1 (BDate, CustId, CustName, PrName, Amt) values('" + BillDate.Text+ "',  '" + CustIdTb.Text + "',  '" + CustNameTb.Text + "', '" + PrNameTb.Text + "',  '" + Total + "'  )";
                    SqlCommand cmd = new SqlCommand(insertQuery, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Bill Generated!!!!!");

                    string query2 = "update ProductTb1 set PrQty = PrQty-'"+ PrQtyTb .Text+ "' ";
                    SqlCommand cmd1 = new SqlCommand(query2, Con);
                    cmd1.ExecuteNonQuery();

                    Con.Close();
                    DisplayBillings();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        private void Reset_Click(object sender, EventArgs e)
        {
            Clear();
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
        private void label4_Click(object sender, EventArgs e)
        {
            Customers obj = new Customers();
            obj.Show();
            this.Hide();
        }
        private void label6_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Con.Open();
            string query = "select CustName from CustomerTb1 where CustId = '"+ CustIdTb.Text + "' ";
            SqlCommand cmd = new SqlCommand(query, Con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                CustNameTb.Text = reader["CustName"].ToString();
            }
            Con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Con.Open();
            string query = "select PrName, PrPrice from ProductTb1 where PrId = '" + PrIdTb.Text + "' ";
            SqlCommand cmd = new SqlCommand(query, Con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                PrNameTb.Text = reader["PrName"].ToString();
                PrPriceTb.Text = reader["PrPrice"].ToString();
            }
            Con.Close();
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void BillDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}