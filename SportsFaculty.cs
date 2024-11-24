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
    public partial class SportsFaculty : Form
    {
        public SportsFaculty()
        {
            InitializeComponent();
            CustomizeDataGridView(dataGridView1);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            AutoGenerate();
            if (string.IsNullOrEmpty(txtEmpID.Text.Trim())) //Employee ID Validation
            {
                errorProvider1.SetError(txtEmpID, "Employee id is required");
                return;
            }
            else
            {
                errorProvider1.SetError(txtEmpID, string.Empty);
            }

            if (string.IsNullOrEmpty(txtEmpName.Text.Trim()))   //Employee name validation
            {
                errorProvider2.SetError(txtEmpName, "Employee name is required");
                return;
            }
            else
            {
                errorProvider2.SetError(txtEmpName, string.Empty);
            }

            if (string.IsNullOrEmpty(txtGender.Text.Trim()))    //Gender Validation
            {
                errorProvider3.SetError(txtGender, "Gender is required");
                return;
            }
            else
            {
                errorProvider3.SetError(txtGender, string.Empty);
            }

            if (string.IsNullOrEmpty(txtContact.Text.Trim()))   //Contact VAlidation
            {
                errorProvider4.SetError(txtContact, "Mobile number is required");
                return;
            }
            else
            {
                errorProvider4.SetError(txtContact, string.Empty);
            }

            string mobilePattern = @"^\d{10}$";
            if (!Regex.IsMatch(txtContact.Text.Trim(), mobilePattern))  //Conatct Check Digits 10
            {
                errorProvider4.SetError(txtContact, "Mobile number must be 10 digits");
                return;
            }
            else
            {
                errorProvider4.SetError(txtContact, string.Empty);
            }

            if (string.IsNullOrEmpty(txtEmail.Text.Trim())) //  Email Validation
            {
                errorProvider3.SetError(txtEmail, "Email is required");
                return;
            }
            else
            {
                errorProvider3.SetError(txtEmail, string.Empty);
            }

            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(txtEmail.Text.Trim(), emailPattern)) //Validating Email Checking @ 
            {
                errorProvider3.SetError(txtEmail, "Invalid email format");
                return;
            }
            else
            {
                errorProvider3.SetError(txtEmail, string.Empty);
            }

            if (string.IsNullOrEmpty(DOBPicker.Text.Trim()))        //Validate Date of birth
            {
                errorProvider6.SetError(DOBPicker, "DOB is required");
                return;
            }
            else
            {
                errorProvider6.SetError(DOBPicker, string.Empty);
            }

            if (string.IsNullOrEmpty(txtAddress.Text.Trim()))  //Address validation
            {
                errorProvider7.SetError(txtAddress, "Address is required");
                return;
            }
            else
            {
                errorProvider7.SetError(txtAddress, string.Empty);
            }

            if (string.IsNullOrEmpty(txtRole.Text.Trim()))  //Role Validation
            {
                errorProvider8.SetError(txtRole, "Role is required");
                return;
            }
            else
            {
                errorProvider8.SetError(txtRole, string.Empty);
            }

            if (string.IsNullOrEmpty(txtDepartment.Text.Trim()))    //Department Validation
            {
                errorProvider9.SetError(txtDepartment, "Department is required");
                return;
            }
            else
            {
                errorProvider9.SetError(txtDepartment, string.Empty);
            }
            //Eshtablishing connection
            SqlConnection conn = new SqlConnection(@"Data Source=ADARSH\SQLEXPRESS;Initial Catalog=SportsComplexdb;Integrated Security=True;Encrypt=False;TrustServerCertificate=True");
            conn.Open();//opening Connection
            //SQL Command for inserting values
            SqlCommand cmd = new SqlCommand("insert into FacultyTab values(@FacultyId,@FacultyName,@Gender,@Contact,@Email,@DOB,@Address,@Role,@Department)", conn);
            cmd.Parameters.AddWithValue("@FacultyId", int.Parse(txtEmpID.Text));
            cmd.Parameters.AddWithValue("@FacultyName", txtEmpName.Text);
            cmd.Parameters.AddWithValue("@Gender", txtGender.Text);
            cmd.Parameters.AddWithValue("@Contact", txtContact.Text);
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
            cmd.Parameters.AddWithValue("@DOB", DOBPicker.Value);
            cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
            cmd.Parameters.AddWithValue("@Role", txtRole.Text);
            cmd.Parameters.AddWithValue("@Department", txtDepartment.Text);
            cmd.ExecuteNonQuery();
            conn.Close();//closing connection
            MessageBox.Show("Records Saved Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadLatestRow(int.Parse(txtEmpID.Text));
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmpID.Text.Trim())) //Employee ID Validation
            {
                errorProvider1.SetError(txtEmpID, "Employee id is required");
                return;
            }
            else
            {
                errorProvider1.SetError(txtEmpID, string.Empty);
            }

            if (string.IsNullOrEmpty(txtEmpName.Text.Trim()))   //Employee name validation
            {
                errorProvider2.SetError(txtEmpName, "Employee name is required");
                return;
            }
            else
            {
                errorProvider2.SetError(txtEmpName, string.Empty);
            }

            if (string.IsNullOrEmpty(txtGender.Text.Trim()))    //Gender Validation
            {
                errorProvider3.SetError(txtGender, "Gender is required");
                return;
            }
            else
            {
                errorProvider3.SetError(txtGender, string.Empty);
            }

            if (string.IsNullOrEmpty(txtContact.Text.Trim()))   //Contact VAlidation
            {
                errorProvider4.SetError(txtContact, "Mobile number is required");
                return;
            }
            else
            {
                errorProvider4.SetError(txtContact, string.Empty);
            }

            string mobilePattern = @"^\d{10}$";
            if (!Regex.IsMatch(txtContact.Text.Trim(), mobilePattern))  //Conatct Check Digits 10
            {
                errorProvider4.SetError(txtContact, "Mobile number must be 10 digits");
                return;
            }
            else
            {
                errorProvider4.SetError(txtContact, string.Empty);
            }

            if (string.IsNullOrEmpty(txtEmail.Text.Trim())) //  Email Validation
            {
                errorProvider3.SetError(txtEmail, "Email is required");
                return;
            }
            else
            {
                errorProvider3.SetError(txtEmail, string.Empty);
            }

            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(txtEmail.Text.Trim(), emailPattern)) //Validating Email Checking @ 
            {
                errorProvider3.SetError(txtEmail, "Invalid email format");
                return;
            }
            else
            {
                errorProvider3.SetError(txtEmail, string.Empty);
            }

            if (string.IsNullOrEmpty(DOBPicker.Text.Trim()))        //Validate Date of birth
            {
                errorProvider6.SetError(DOBPicker, "DOB is required");
                return;
            }
            else
            {
                errorProvider6.SetError(DOBPicker, string.Empty);
            }

            if (string.IsNullOrEmpty(txtAddress.Text.Trim()))  //Address validation
            {
                errorProvider7.SetError(txtAddress, "Address is required");
                return;
            }
            else
            {
                errorProvider7.SetError(txtAddress, string.Empty);
            }

            if (string.IsNullOrEmpty(txtRole.Text.Trim()))  //Role Validation
            {
                errorProvider8.SetError(txtRole, "Role is required");
                return;
            }
            else
            {
                errorProvider8.SetError(txtRole, string.Empty);
            }

            if (string.IsNullOrEmpty(txtDepartment.Text.Trim()))    //Department Validation
            {
                errorProvider9.SetError(txtDepartment, "Department is required");
                return;
            }
            else
            {
                errorProvider9.SetError(txtDepartment, string.Empty);
            }
            //Eshtablishing Connection
            SqlConnection conn = new SqlConnection(@"Data Source=ADARSH\SQLEXPRESS;Initial Catalog=SportsComplexdb;Integrated Security=True;Encrypt=False;TrustServerCertificate=True");
            conn.Open();//opening Connection
            //SQL Command for Updating Faculty table in database
            SqlCommand cmd = new SqlCommand("update FacultyTab set FacultyName=@FacultyName,Gender=@Gender,Contact=@Contact,Email=@Email,DOB=@DOB,Address=@Address,Role=@Role,Department=@Department where FacultyId=@FacultyId", conn);
            cmd.Parameters.AddWithValue("@FacultyId", int.Parse(txtEmpID.Text));
            cmd.Parameters.AddWithValue("@FacultyName", txtEmpName.Text);
            cmd.Parameters.AddWithValue("@Gender", txtGender.Text);
            cmd.Parameters.AddWithValue("@Contact", txtContact.Text);
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
            cmd.Parameters.AddWithValue("@DOB", DOBPicker.Value);
            cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
            cmd.Parameters.AddWithValue("@Role", txtRole.Text);
            cmd.Parameters.AddWithValue("@Department", txtDepartment.Text);
            cmd.ExecuteNonQuery();
            conn.Close();//Closing Connection
            MessageBox.Show("Records Update Successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadLatestRow(int.Parse(txtEmpID.Text));
        }

        private void SportsFaculty_Load(object sender, EventArgs e)
        {
            AutoGenerate();//Function call at the time of load of form
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            //Button to reset the Textfield to emtpy
            txtEmpID.Text = "";
            txtEmpName.Text = "";
            txtGender.Text = "";
            txtEmail.Text = "";
            DOBPicker.Text = "";
            txtAddress.Text = "";
            txtContact.Text = "";
            txtRole.Text = "Choose Your Role";
            txtDepartment.Text = "Choose Your Department";
        }

        private void DOBPicker_ValueChanged(object sender, EventArgs e)
        {
            DOBPicker.CustomFormat = "dd/MM/yyyy";  //Declaring Date Format
        }

        private void DOBPicker_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                DOBPicker.CustomFormat = " ";   //BackSpace Button to empty the Date Field
            }
        }
        public void AutoGenerate()//Function to Auto Generate the function
        {
            //Eshtablishing Connection
            SqlConnection conn = new SqlConnection(@"Data Source=ADARSH\SQLEXPRESS;Initial Catalog=SportsComplexdb;Integrated Security=True;Encrypt=False;TrustServerCertificate=True");
            // If no records exist, it defaults to 1 (using ISNULL to handle null values)
            SqlDataAdapter adp = new SqlDataAdapter("select isnull(max(cast(FacultyId as int)),0)+1 from FacultyTab", conn);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            txtEmpID.Text = dt.Rows[0][0].ToString();//Storing Auto Generated row to text box
        }

        private void btnSearch_Click(object sender, EventArgs e)//biton to search Item from table
        {
            //Eshtablishing Connection
            SqlConnection conn = new SqlConnection(@"Data Source=ADARSH\SQLEXPRESS;Initial Catalog=SportsComplexdb;Integrated Security=True;Encrypt=False;TrustServerCertificate=True");
            conn.Open();//opening connection
            //SQL Command for Search ing from Faculty table
            SqlCommand cmd = new SqlCommand("select * from FacultyTab where FacultyName like @FacultyName +'%'", conn);
            cmd.Parameters.AddWithValue("@FacultyName", txtSearch.Text.Trim());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)//Checking if the Search elemnt is available in table
            {
                dataGridView1.DataSource = dt;//Display in DataGridView
            }
            else
            {
                MessageBox.Show("No Record Found!!!");
                dataGridView1.DataSource = null;
            }
        }
        private void LoadLatestRow(int FacultyId)//Function to display latest updated Row in DataGridView
        {
            //Eshtablishing Connection
            using (SqlConnection conn = new SqlConnection(@"Data Source=ADARSH\SQLEXPRESS;Initial Catalog=SportsComplexdb;Integrated Security=True;Encrypt=False;TrustServerCertificate=True"))
            {
                conn.Open();//Open Connection
                //Sql Command for Fetch latest Updated Row
                SqlCommand cmd = new SqlCommand("SELECT * FROM FacultyTab Where FacultyId = @FacultyId", conn);
                cmd.Parameters.AddWithValue("@FacultyId", FacultyId);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();//Clearing DataGridView
                dataGridView1.DataSource = dt;//Storing Datagrid View
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Main mm = new Main();//button to redirect to main page
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