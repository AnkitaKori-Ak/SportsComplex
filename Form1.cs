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

namespace SportsComplex
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text.Trim()))
            {
                errorProvider1.SetError(txtUsername, "Username is required");
                return;
            }
            else
            {
                errorProvider1.SetError(txtUsername, string.Empty);
            }

            if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                errorProvider2.SetError(txtPassword, "Password is required");
                return;
            }
            else
            {
                errorProvider2.SetError(txtPassword, string.Empty);
            }

            string connectionString = @"Data Source=ADARSH\SQLEXPRESS;Initial Catalog=SportsComplexdb;Integrated Security=True;Encrypt=False;TrustServerCertificate=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string username = txtUsername.Text;
                string password = txtPassword.Text;

               
                using (SqlCommand cmd = new SqlCommand("SELECT Username, Password FROM Logintab WHERE Username = @Username AND Password = @Password", conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                          
                            Main nm = new Main();
                            nm.Show();
                            this.Hide(); 
                        }
                        else
                        {
                            MessageBox.Show("Invalid Username Or Password");
                        }
                    }
                }
            }
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
        }
    }
}
