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
using System.Text.RegularExpressions;

namespace SportsComplex
{
    public partial class SupplierDetails : Form
    {
        public SupplierDetails()
        {
            InitializeComponent();
            CustomizeDataGridView(dataGridView1);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            AutoGenerate();
            if (string.IsNullOrEmpty(txtSuppID.Text.Trim()))//Supplier ID Validation
            {
                errorProvider1.SetError(txtSuppID, "Supplier id is required");
                return;
            }
            else
            {
                errorProvider1.SetError(txtSuppID, string.Empty);
            }

            if (string.IsNullOrEmpty(txtSuppName.Text.Trim()))//Supplier Name VAlidation
            {
                errorProvider2.SetError(txtSuppName, "Supplier name is required");
                return;
            }
            else
            {
                errorProvider2.SetError(txtSuppName, string.Empty);
            }

            if (string.IsNullOrEmpty(txtGender.Text.Trim())) // gender Avlidation
            {
                errorProvider3.SetError(txtGender, "Gender is required");
                return;
            }
            else
            {
                errorProvider3.SetError(txtGender, string.Empty);
            }

            if (string.IsNullOrEmpty(txtContact.Text.Trim())) // COntact validation
            {
                errorProvider4.SetError(txtContact, "Mobile number is required");
                return;
            }
            else
            {
                errorProvider4.SetError(txtContact, string.Empty);
            }

            string mobilePattern = @"^\d{10}$";
            if (!Regex.IsMatch(txtContact.Text.Trim(), mobilePattern)) //Checking if contact no is of 10 digits 
            {
                errorProvider4.SetError(txtContact, "Mobile number must be 10 digits");
                return;
            }
            else
            {
                errorProvider4.SetError(txtContact, string.Empty);
            }

            if (string.IsNullOrEmpty(txtEmail.Text.Trim())) //  email Validation
            {
                errorProvider5.SetError(txtEmail, "Email is required");
                return;
            }
            else
            {
                errorProvider5.SetError(txtEmail, string.Empty);
            }

            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(txtEmail.Text.Trim(), emailPattern))     //Validation email checing @
            {
                errorProvider5.SetError(txtEmail, "Invalid email format");
                return;
            }
            else
            {
                errorProvider5.SetError(txtEmail, string.Empty);
            }

            if (string.IsNullOrEmpty(dateContract.Text.Trim())) // DateContract validation
            {
                errorProvider6.SetError(dateContract, "Date is  required");
                return;
            }
            else
            {
                errorProvider6.SetError(dateContract, string.Empty);
            }

            if (string.IsNullOrEmpty(txtDuration.Text.Trim()))  //Duration validation
            {
                errorProvider7.SetError(txtDuration, "Duration is required");
                return;
            }
            else
            {
                errorProvider7.SetError(txtDuration, string.Empty);
            }
            //Eshtabliishing Connection
            SqlConnection conn = new SqlConnection(@"Data Source=ADARSH\SQLEXPRESS;Initial Catalog=SportsComplexdb;Integrated Security=True;Encrypt=False;TrustServerCertificate=True");
            conn.Open();//opening connection
            //Sel Command for Inserting values in supplier table
            SqlCommand cmd = new SqlCommand("insert into SupplierTab values(@SupplierId,@SupplierName,@Gender,@Contact,@Email,@ContractDate,@Duration)", conn);
            cmd.Parameters.AddWithValue("@SupplierId", int.Parse(txtSuppID.Text));
            cmd.Parameters.AddWithValue("@SupplierName",txtSuppName.Text);
            cmd.Parameters.AddWithValue("@Gender", txtGender.Text);
            cmd.Parameters.AddWithValue("@Contact", txtContact.Text);
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
            cmd.Parameters.AddWithValue("@ContractDate", dateContract.Value);
            cmd.Parameters.AddWithValue("@Duration", txtDuration.Text);
            cmd.ExecuteNonQuery();
            conn.Close();//closing connection
            MessageBox.Show("Records Saved Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadLatestRow(int.Parse(txtSuppID.Text));
        }

        private void dateContract_ValueChanged(object sender, EventArgs e)
        {
            dateContract.CustomFormat = "dd/MM/yyyy";   //formate date
        }

        private void dateContract_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                dateContract.CustomFormat = " ";    //backspace ey to date field
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            //button to rest the text field to empty
            txtSuppID.Text = "";
            txtSuppName.Text = "";
            txtGender.Text = "";
            txtContact.Text = "";
            txtEmail.Text = "";
            dateContract.Text = "";
            txtDuration.Text = "";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSuppID.Text.Trim()))//Supplier ID Validation
            {
                errorProvider1.SetError(txtSuppID, "Supplier id is required");
                return;
            }
            else
            {
                errorProvider1.SetError(txtSuppID, string.Empty);
            }

            if (string.IsNullOrEmpty(txtSuppName.Text.Trim()))//Supplier Name VAlidation
            {
                errorProvider2.SetError(txtSuppName, "Supplier name is required");
                return;
            }
            else
            {
                errorProvider2.SetError(txtSuppName, string.Empty);
            }

            if (string.IsNullOrEmpty(txtGender.Text.Trim())) // gender Avlidation
            {
                errorProvider3.SetError(txtGender, "Gender is required");
                return;
            }
            else
            {
                errorProvider3.SetError(txtGender, string.Empty);
            }

            if (string.IsNullOrEmpty(txtContact.Text.Trim())) // COntact validation
            {
                errorProvider4.SetError(txtContact, "Mobile number is required");
                return;
            }
            else
            {
                errorProvider4.SetError(txtContact, string.Empty);
            }

            string mobilePattern = @"^\d{10}$";
            if (!Regex.IsMatch(txtContact.Text.Trim(), mobilePattern)) //Checking if contact no is of 10 digits 
            {
                errorProvider4.SetError(txtContact, "Mobile number must be 10 digits");
                return;
            }
            else
            {
                errorProvider4.SetError(txtContact, string.Empty);
            }

            if (string.IsNullOrEmpty(txtEmail.Text.Trim())) //  email Validation
            {
                errorProvider5.SetError(txtEmail, "Email is required");
                return;
            }
            else
            {
                errorProvider5.SetError(txtEmail, string.Empty);
            }

            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(txtEmail.Text.Trim(), emailPattern))     //Validation email checing @
            {
                errorProvider5.SetError(txtEmail, "Invalid email format");
                return;
            }
            else
            {
                errorProvider5.SetError(txtEmail, string.Empty);
            }

            if (string.IsNullOrEmpty(dateContract.Text.Trim())) // DateContract validation
            {
                errorProvider6.SetError(dateContract, "Date is  required");
                return;
            }
            else
            {
                errorProvider6.SetError(dateContract, string.Empty);
            }

            if (string.IsNullOrEmpty(txtDuration.Text.Trim()))  //Duration validation
            {
                errorProvider7.SetError(txtDuration, "Duration is required");
                return;
            }
            else
            {
                errorProvider7.SetError(txtDuration, string.Empty);
            }
            //Eshtablishing Connection
            SqlConnection conn = new SqlConnection(@"Data Source=ADARSH\SQLEXPRESS;Initial Catalog=SportsComplexdb;Integrated Security=True;Encrypt=False;TrustServerCertificate=True");
            conn.Open();//opening connection
            //sql Command for Update the Supplier Deatils in table
            SqlCommand cmd = new SqlCommand("Update SupplierTab set SupplierName=@SupplierName,Gender=@Gender,Contact=@Contact,Email=@Email,Contract_Date=@Contract_Date,Duration=@Duration where SupplierId=@SupplierId", conn);
            cmd.Parameters.AddWithValue("@SupplierId", int.Parse(txtSuppID.Text));
            cmd.Parameters.AddWithValue("@SupplierName", txtSuppName.Text);
            cmd.Parameters.AddWithValue("@Gender", txtGender.Text);
            cmd.Parameters.AddWithValue("@Contact", txtContact.Text);
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
            cmd.Parameters.AddWithValue("@Contract_Date", dateContract.Value);
            cmd.Parameters.AddWithValue("@Duration", txtDuration.Text);
            cmd.ExecuteNonQuery();
            conn.Close();//closing COnnection
            MessageBox.Show("Records Updated Successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadLatestRow(int.Parse(txtSuppID.Text));
        }
        private void SupplierDetails_Load(object sender, EventArgs e)
        {
            AutoGenerate();//Function call at time or load of form
        }
        public void AutoGenerate()//function to Auto generate Supplier Id
        {
            //Eshtablishing Connection
            SqlConnection conn = new SqlConnection(@"Data Source=ADARSH\SQLEXPRESS;Initial Catalog=SportsComplexdb;Integrated Security=True;Encrypt=False;TrustServerCertificate=True");
            // If no records exist, it defaults to 1 (using ISNULL to handle null values)
            SqlDataAdapter adp = new SqlDataAdapter("select isnull(max(cast(SupplierID as int)),0)+1 from SupplierTab", conn);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            txtSuppID.Text = dt.Rows[0][0].ToString();//Storing latest Auto generated to text fields Suppier id
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //Eshtablish Connection
            SqlConnection conn = new SqlConnection(@"Data Source=ADARSH\SQLEXPRESS;Initial Catalog=SportsComplexdb;Integrated Security=True;Encrypt=False;TrustServerCertificate=True");
            conn.Open();//opening Connection
            //Sql Command for Searching item in table
            SqlCommand cmd = new SqlCommand("select * from SupplierTab where SupplierName like @SupplierName +'%'", conn);
            cmd.Parameters.AddWithValue("@SupplierName", txtSearch.Text.Trim());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)//checking if found the search element
            {
                dataGridView1.DataSource = dt;//storing element in Data gridView
            }
            else
            {
                MessageBox.Show("No Record Found!!!");
                dataGridView1.DataSource = null;
            }
        }
        private void LoadLatestRow(int SupplierId)//function to load the latest updated row
        {
            //Eshatblishing Connection
            using (SqlConnection conn = new SqlConnection(@"Data Source=ADARSH\SQLEXPRESS;Initial Catalog=SportsComplexdb;Integrated Security=True;Encrypt=False;TrustServerCertificate=True"))
            {
                conn.Open();//Opeing Connection
                //Accessing Updated Row 
                SqlCommand cmd = new SqlCommand("SELECT * FROM SupplierTab Where SupplierId = @SupplierId", conn);
                cmd.Parameters.AddWithValue("@SupplierId", SupplierId);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();//Clearing datagridview
                dataGridView1.DataSource = dt;//storing in data GridView
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Main mm = new Main();//button redirect to main page
            mm.Show();
        }
        private void CustomizeDataGridView(DataGridView dgv)
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
