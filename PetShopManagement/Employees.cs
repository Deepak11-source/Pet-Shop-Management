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
    public partial class Employees : Form
    {
        public Employees()
        {
            InitializeComponent();
            DisplayEmployees();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=PetShopDb;Integrated Security=True;Pooling=False");
        private void DisplayEmployees()
        {
            Con.Open();
            string Query = "Select * from EmployeeTb1";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            EmployeesDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void Clear()
        {
            EmpNameTb.Text = " ";
            EmpAddTb.Text = " ";
            EmpPhoneTb.Text = " ";
            EmpPassTb.Text = " ";
        }
        private void Savebtn_Click(object sender, EventArgs e)
        {
            if (EmpNameTb.Text == "" || EmpAddTb.Text == "" || EmpPhoneTb.Text == "" || EmpPassTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string insertQuery = "insert into EmployeeTb1 (EmpName, EmpAdd, EmpDOB, EmpPhone, EmpPass) values('" + EmpNameTb.Text + "',  '" + EmpAddTb.Text + "',  '" + EmpDOB.Text + "',  '" + EmpPhoneTb.Text + "',  '" + EmpPassTb.Text + "' )";
                    SqlCommand cmd = new SqlCommand(insertQuery, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Added");
                    Con.Close();
                    DisplayEmployees();
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
            if (EmpNameTb.Text == " " || EmpAddTb.Text == " " || EmpPhoneTb.Text == " " || EmpPassTb.Text == " ")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string updateQuery = "update EmployeeTb1 Set  EmpName = ' " + EmpNameTb.Text + " ',  EmpAdd =  '" + EmpAddTb.Text + "',  EmpDOB = '" + EmpDOB.Text + "',  EmpPhone = '" + EmpPhoneTb.Text + "', EmpPass= '" + EmpPassTb.Text + "' Where EmpNum= '" + int.Parse(EmpIdTb.Text) + "' ";
                    SqlCommand cmd = new SqlCommand(updateQuery, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Updated!!!");
                    Con.Close();
                    DisplayEmployees();
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
                string deleteQuery = "delete from EmployeeTb1 WHERE EmpNum= '" + int.Parse(EmpIdTb.Text) + "' ";
                SqlCommand cmd = new SqlCommand(deleteQuery, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Employee Deleted");
                Con.Close();
                DisplayEmployees();
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