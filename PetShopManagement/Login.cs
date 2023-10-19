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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=PetShopDb;Integrated Security=True;Pooling=False");
        
        public static string Employee;
        private void label4_Click(object sender, EventArgs e)
        {
            Employees Obj = new Employees();
            Obj.Show();
            this.Hide();
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (UnameTb.Text == "" || PasswordTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter("Select count(*) from EmployeeTb1 where EmpName='" + UnameTb.Text + "' and EmpPass='" + PasswordTb.Text + "'", Con);
                    DataTable d = new DataTable();
                    sda.Fill(d);
                    if (d.Rows[0][0].ToString() == "1")
                    {
                        Employee = UnameTb.Text;

                        Homes Obj = new Homes();
                        Obj.Show();
                        this.Hide();
                    }
                    Con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}