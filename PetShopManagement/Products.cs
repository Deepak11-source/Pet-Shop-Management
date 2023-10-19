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
    public partial class Products : Form
    {
        public Products()
        {
            InitializeComponent();
            DisplayProducts();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=PetShopDb;Integrated Security=True;Pooling=False");
        private void DisplayProducts()
        {
            Con.Open();
            string Query = "Select * from ProductTb1";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ProductsDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void Clear()
        {
            PrNameTb.Text = " ";
            PrQtyTb.Text = " ";
            PrPriceTb.Text = " ";
            PrCatTb.SelectedIndex = 0;
        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (PrNameTb.Text == "" || PrQtyTb.Text == "" || PrPriceTb.Text == "" || PrCatTb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string insertQuery = "insert into ProductTb1 (PrName, PrCat, PrQty, PrPrice) values('" + PrNameTb.Text + "',  '" + PrCatTb.SelectedItem.ToString() + "',  '" + PrQtyTb.Text + "',  '" + PrPriceTb.Text + "')";
                    SqlCommand cmd = new SqlCommand(insertQuery, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Product Added");
                    Con.Close();
                    DisplayProducts();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (PrNameTb.Text == "" || PrQtyTb.Text == "" || PrPriceTb.Text == "" || PrCatTb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string updateQuery = "update ProductTb1 Set  PrName = ' " + PrNameTb.Text + " ',  PrQty =  '" + PrQtyTb.Text + "', PrPrice= '" + PrPriceTb.Text + "', PrCat = '" + PrCatTb.SelectedItem.ToString() + "'  Where PrId= '" + int.Parse(PrIdTb.Text) + "' ";
                    SqlCommand cmd = new SqlCommand(updateQuery, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Product Updated!!!");
                    Con.Close();
                    DisplayProducts();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Con.Open();
                string deleteQuery = "delete from ProductTb1 WHERE PrId= '" + int.Parse(PrIdTb.Text) + "' ";
                SqlCommand cmd = new SqlCommand(deleteQuery, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Product" +
                    " Deleted");
                Con.Close();
                DisplayProducts();
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
