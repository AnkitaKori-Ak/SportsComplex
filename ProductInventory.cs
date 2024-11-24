using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SportsComplex
{
    public partial class ProductInventory : Form
    {
        public ProductInventory()
        {
            InitializeComponent();
            GridviewCustom(ProductGV);
        }

        private void ProductInventory_Load(object sender, EventArgs e)
        {
            AutoGenerate();//Calling Updating Accessories ID

        }
        public void AutoGenerate()//Function to Auto Generate Accessories ID
        {

            //Establishing Connection
            SqlConnection conn = new SqlConnection(@"Data Source=ADARSH\SQLEXPRESS;Initial Catalog=SportsComplexdb;Integrated Security=True;Encrypt=False;TrustServerCertificate=True");
            // If no records exist, it defaults to 1 (using ISNULL to handle null values)
            SqlDataAdapter adp = new SqlDataAdapter("select isnull(max(cast(AccessoriesId as int)),0)+1 from AccessoriesTab", conn);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            txtAccesoriesId.Text = dt.Rows[0][0].ToString();//Storing it to Auto Generated Value to Accessories ID to textbox
        }
        private void LoadLatestRow(int AccessoriesId)//Function to Displaying Updated Row in GridView
        {
            //Establishing Connection
            using (SqlConnection conn = new SqlConnection(@"Data Source=ADARSH\SQLEXPRESS;Initial Catalog=SportsComplexdb;Integrated Security=True;Encrypt=False;TrustServerCertificate=True"))
            {
                conn.Open();//opening connection
                //SQl Command to Accessing Latest Updated Row
                SqlCommand cmd = new SqlCommand("SELECT * FROM Accessories Where AccessoriesId = @AccessoriesId", conn);
                cmd.Parameters.AddWithValue("@AccessoriesId", AccessoriesId);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                ProductGV.DataSource = null;
                ProductGV.Rows.Clear();//Clearing Data GridView
                ProductGV.DataSource = dt;//Storing Updated Row in Data Grid View
            }
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            AutoGenerate();

            if (string.IsNullOrEmpty(txtAccesoriesId.Text.Trim()))//Accessories ID Validation
            {
                errorProvider1.SetError(txtAccesoriesId, "Accessories id is required");
                return;
            }
            else
            {
                errorProvider1.SetError(txtAccesoriesId, string.Empty);
            }

            if (string.IsNullOrEmpty(txtProductName.Text.Trim()))   //Accessories Name Validation
            {
                errorProvider2.SetError(txtProductName, "Product name is required");
                return;
            }
            else
            {
                errorProvider2.SetError(txtProductName, string.Empty);
            }
            if (string.IsNullOrEmpty(txtQuantity.Text.Trim()))  //Accessories Quantity Validation
            {
                errorProvider3.SetError(txtQuantity, "Quantity is required");
                return;
            }
            else
            {
                errorProvider3.SetError(txtQuantity, string.Empty);
            }

          
            if (string.IsNullOrEmpty(txtPrice.Text.Trim())) //Accessories Price Validation
            {
                errorProvider4.SetError(txtPrice, "Price is required");
                return;
            }
            else
            {
                errorProvider4.SetError(txtPrice, string.Empty);
            }

            if (string.IsNullOrEmpty(txtDescription.Text.Trim()))   //Accessories Description Validation
            {
                errorProvider5.SetError(txtDescription, "Selection of features is required");
                return;
            }
            else
            {
                errorProvider5.SetError(txtDescription, string.Empty);
            }
            if (string.IsNullOrEmpty(txtcategories.Text.Trim()))    //Accessories Categories Validation
            {
                errorProvider6.SetError(txtcategories, "Selection of category is required");
                return;
            }
            else
            {
                errorProvider6.SetError(txtcategories, string.Empty);
            }
               
            //Establishing Connection
            SqlConnection conn = new SqlConnection(@"Data Source=ADARSH\SQLEXPRESS;Initial Catalog=SportsComplexdb;Integrated Security=True;Encrypt=False;TrustServerCertificate=True");
            conn.Open();//Opeing Connection
            //SQL Command for Inserting values in data Base
            SqlCommand cmd = new SqlCommand("insert into AccessoriesTab values(@AccessoriesId,@ProductName,@Quantity,@Price,@Description,@Category)", conn);
            cmd.Parameters.AddWithValue("@AccessoriesId", int.Parse(txtAccesoriesId.Text));
            cmd.Parameters.AddWithValue("@ProductName", txtProductName.Text);
            cmd.Parameters.AddWithValue("@Quantity", txtQuantity.Text);
            cmd.Parameters.AddWithValue("@Price", txtPrice.Text);
            cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
            cmd.Parameters.AddWithValue("@Category", txtcategories.Text);
            cmd.ExecuteNonQuery();
            conn.Close();//Clossing Connection
            MessageBox.Show("Records Saved Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            AutoGenerate();// calling auto generate Function 


            if (string.IsNullOrEmpty(txtAccesoriesId.Text.Trim()))//Accessories ID Validation
            {
                errorProvider1.SetError(txtAccesoriesId, "Accessories id is required");
                return;
            }
            else
            {
                errorProvider1.SetError(txtAccesoriesId, string.Empty);
            }

            if (string.IsNullOrEmpty(txtProductName.Text.Trim()))   //Accessories Name Validation
            {
                errorProvider2.SetError(txtProductName, "Product name is required");
                return;
            }
            else
            {
                errorProvider2.SetError(txtProductName, string.Empty);
            }
            if (string.IsNullOrEmpty(txtQuantity.Text.Trim()))  //Accessories Quantity Validation
            {
                errorProvider3.SetError(txtQuantity, "Quantity is required");
                return;
            }
            else
            {
                errorProvider3.SetError(txtQuantity, string.Empty);
            }


            if (string.IsNullOrEmpty(txtPrice.Text.Trim())) //Accessories Price Validation
            {
                errorProvider4.SetError(txtPrice, "Price is required");
                return;
            }
            else
            {
                errorProvider4.SetError(txtPrice, string.Empty);
            }

            if (string.IsNullOrEmpty(txtDescription.Text.Trim()))   //Accessories Description Validation
            {
                errorProvider5.SetError(txtDescription, "Selection of features is required");
                return;
            }
            else
            {
                errorProvider5.SetError(txtDescription, string.Empty);
            }
            if (string.IsNullOrEmpty(txtcategories.Text.Trim()))    //Accessories Categories Validation
            {
                errorProvider6.SetError(txtcategories, "Selection of category is required");
                return;
            }
            else
            {
                errorProvider6.SetError(txtcategories, string.Empty);
            }

            //Establishing Connection
            SqlConnection conn = new SqlConnection(@"Data Source=ADARSH\SQLEXPRESS;Initial Catalog=SportsComplexdb;Integrated Security=True;Encrypt=False;TrustServerCertificate=True");
            conn.Open();//Opening Connection
            //SQL Command for Updating Accesories in database
            SqlCommand cmd = new SqlCommand("update AccessoriesTab set ProductName=@ProductName,Quantity=@Quantity,Price=@Price,Description=@Description, Category=@Category where AccessoriesId=@AccessoriesId", conn);
            cmd.Parameters.AddWithValue("@AccessoriesId", int.Parse(txtAccesoriesId.Text));
            cmd.Parameters.AddWithValue("@ProductName", txtProductName.Text);
            cmd.Parameters.AddWithValue("@Quantity", txtQuantity.Text);
            cmd.Parameters.AddWithValue("@Price", txtPrice.Text);
            cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
            cmd.Parameters.AddWithValue("@Category", txtcategories.Text);
            cmd.ExecuteNonQuery();
            conn.Close();// Closing Connection
            MessageBox.Show("Records Updated Successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            //Button to reset values to empty
            txtAccesoriesId.Text = "";
            txtProductName.Text = "";
            txtQuantity.Text = "";
            txtcategories.Text = "";
            txtPrice.Text = "";
            txtDescription.Text = "";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //Establishing Connection
            SqlConnection conn = new SqlConnection(@"Data Source=ADARSH\SQLEXPRESS;Initial Catalog=SportsComplexdb;Integrated Security=True;Encrypt=False;TrustServerCertificate=True");
            conn.Open();//Opening Connection
            //SQl Command for Searching Accessories
            SqlCommand cmd = new SqlCommand("select * from AccessoriesTab where ProductName like @ProductName +'%'", conn);
            cmd.Parameters.AddWithValue("@ProductName", txtSearch.Text.Trim());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)//Check If the Search is Found or not
            {
                ProductGV.DataSource = dt;//Soring in data GridView
            }
            else
            {
                MessageBox.Show("No Record Found!!!");
                ProductGV.DataSource = null;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Main mm = new Main();//button Redirect to Main page
            mm.Show();
        }
        private void GridviewCustom(DataGridView dgv)
        {
            // Set the header background color
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(201, 104, 104);
            // Set the header text color
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // Optional: Set the font style of the header
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
            dgv.EnableHeadersVisualStyles = false;
            // Refresh to apply changes
            dgv.Refresh();
        }

    }

}
