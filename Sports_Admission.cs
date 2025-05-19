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
    public partial class Sports_Admission : Form
    {
        public Sports_Admission()
        {
            InitializeComponent();
            CustomizeDataGridView(dataGridView1);
        }
        private void datePlayerPicker_VisibleChanged(object sender, EventArgs e)
        {
            datePlayerPicker.CustomFormat = "dd/MM/yyyy";//formating Date
        }

        private void datePlayerPicker_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Back)
            {
                datePlayerPicker.CustomFormat = " ";//Empty date Filed from backspace
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            AutoGenerate();
            if (string.IsNullOrEmpty(txtRegNo.Text.Trim())) //Regustration No Validation
            {
                errorProvider1.SetError(txtRegNo, "Registration number is required");
                return;
            }
            else
            {
                errorProvider1.SetError(txtRegNo, string.Empty);
            }

            if (string.IsNullOrEmpty(txtPlayerName.Text.Trim()))    //Player Name Validation
            {
                errorProvider2.SetError(txtPlayerName, "Name is required");
                return;
            }
            else
            {
                errorProvider2.SetError(txtPlayerName, string.Empty);
            }

            if (string.IsNullOrEmpty(txtPlayerEmail.Text.Trim()))   //Email Validation
            {
                errorProvider3.SetError(txtPlayerEmail, "Email is required");
                return;
            }
            else
            {
                errorProvider3.SetError(txtPlayerEmail, string.Empty);
            }

            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$"; 
            if (!Regex.IsMatch(txtPlayerEmail.Text.Trim(), emailPattern))   // Checking AVlidation of email @ sign
            {
                errorProvider3.SetError(txtPlayerEmail, "Invalid email format");
                return;
            }
            else
            {
                errorProvider3.SetError(txtPlayerEmail, string.Empty);
            }

            if (string.IsNullOrEmpty(txtPlayerMobile.Text.Trim()))  //Phone No validation
            {
                errorProvider4.SetError(txtPlayerMobile, "Mobile number is required");
                return;
            }
            else
            {
                errorProvider4.SetError(txtPlayerMobile, string.Empty);
            }

            string mobilePattern = @"^\d{10}$"; 
            if (!Regex.IsMatch(txtPlayerMobile.Text.Trim(), mobilePattern))// Checking if phono having 10 digits
            {
                errorProvider4.SetError(txtPlayerMobile, "Mobile number must be 10 digits");
                return;
            }
            else
            {
                errorProvider4.SetError(txtPlayerMobile, string.Empty);
            }

            if (string.IsNullOrEmpty(txtPlayerAddr.Text.Trim()))    //Addrees Validation
            {
                errorProvider5.SetError(txtPlayerAddr, "Address is required");
                return;
            }
            else
            {
                errorProvider5.SetError(txtPlayerAddr, string.Empty);
            }

            if (string.IsNullOrEmpty(txtSelectSports.Text.Trim()))  //Sports Validation
            {
                errorProvider6.SetError(txtSelectSports, "Selection of sports is required");
                return;
            }
            else
            {
                errorProvider6.SetError(txtSelectSports, string.Empty);
            }

            if (string.IsNullOrEmpty(txtPlayerFees.Text.Trim()))    //Player Fees validation
            {
                errorProvider7.SetError(txtPlayerFees, "Fees is required");
                return;
            }
            else
            {
                errorProvider7.SetError(txtPlayerFees, string.Empty);
            }

            if (string.IsNullOrEmpty(datePlayerPicker.Text.Trim())) //Date validation
            {
                errorProvider8.SetError(datePlayerPicker, "Date is required");
                return;
            }
            else
            {
                errorProvider8.SetError(datePlayerPicker, string.Empty);
            }

            if (string.IsNullOrEmpty(txtPlayerGender.Text.Trim()))   //Gender VAlidation
            {
                errorProvider9.SetError(txtPlayerGender, "Gender is required");
                return;
            }
            else
            {
                errorProvider9.SetError(txtPlayerGender, string.Empty);
            }

            //Establishing Connection
            SqlConnection conn = new SqlConnection(@"Data Source=ADARSH\SQLEXPRESS;Initial Catalog=SportsComplexdb;Integrated Security=True;Encrypt=False;TrustServerCertificate=True");
            conn.Open();//opening Connection
            //SQL command for inserting avlues in database 
            SqlCommand cmd = new SqlCommand("insert into Admissiondb values(@RegistrationNo,@playerName,@Email,@Mobile,@Address,@Sports,@Fees,@DOB,@Gender)",conn);
            cmd.Parameters.AddWithValue("@RegistrationNo", int.Parse(txtRegNo.Text));
            cmd.Parameters.AddWithValue("@PlayerName", txtPlayerName.Text);
            cmd.Parameters.AddWithValue("@Email", txtPlayerEmail.Text);
            cmd.Parameters.AddWithValue("@Mobile", txtPlayerMobile.Text);
            cmd.Parameters.AddWithValue("@Address", txtPlayerAddr.Text);
            cmd.Parameters.AddWithValue("@Sports", txtSelectSports.Text);
            cmd.Parameters.AddWithValue("@Fees", txtPlayerFees.Text);
            cmd.Parameters.AddWithValue("@DOB", datePlayerPicker.Value);
            cmd.Parameters.AddWithValue("@Gender", txtPlayerGender.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Records Saved Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadLatestRow(int.Parse(txtRegNo.Text)); // Call to load the latest updated row
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRegNo.Text.Trim())) //Regustration No Validation
            {
                errorProvider1.SetError(txtRegNo, "Registration number is required");
                return;
            }
            else
            {
                errorProvider1.SetError(txtRegNo, string.Empty);
            }

            if (string.IsNullOrEmpty(txtPlayerName.Text.Trim()))    //Player Name Validation
            {
                errorProvider2.SetError(txtPlayerName, "Name is required");
                return;
            }
            else
            {
                errorProvider2.SetError(txtPlayerName, string.Empty);
            }

            if (string.IsNullOrEmpty(txtPlayerEmail.Text.Trim()))   //Email Validation
            {
                errorProvider3.SetError(txtPlayerEmail, "Email is required");
                return;
            }
            else
            {
                errorProvider3.SetError(txtPlayerEmail, string.Empty);
            }

            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(txtPlayerEmail.Text.Trim(), emailPattern))   // Checking AVlidation of email @ sign
            {
                errorProvider3.SetError(txtPlayerEmail, "Invalid email format");
                return;
            }
            else
            {
                errorProvider3.SetError(txtPlayerEmail, string.Empty);
            }

            if (string.IsNullOrEmpty(txtPlayerMobile.Text.Trim()))  //Phone No validation
            {
                errorProvider4.SetError(txtPlayerMobile, "Mobile number is required");
                return;
            }
            else
            {
                errorProvider4.SetError(txtPlayerMobile, string.Empty);
            }

            string mobilePattern = @"^\d{10}$";
            if (!Regex.IsMatch(txtPlayerMobile.Text.Trim(), mobilePattern))// Checking if phono having 10 digits
            {
                errorProvider4.SetError(txtPlayerMobile, "Mobile number must be 10 digits");
                return;
            }
            else
            {
                errorProvider4.SetError(txtPlayerMobile, string.Empty);
            }

            if (string.IsNullOrEmpty(txtPlayerAddr.Text.Trim()))    //Addrees Validation
            {
                errorProvider5.SetError(txtPlayerAddr, "Address is required");
                return;
            }
            else
            {
                errorProvider5.SetError(txtPlayerAddr, string.Empty);
            }

            if (string.IsNullOrEmpty(txtSelectSports.Text.Trim()))  //Sports Validation
            {
                errorProvider6.SetError(txtSelectSports, "Selection of sports is required");
                return;
            }
            else
            {
                errorProvider6.SetError(txtSelectSports, string.Empty);
            }

            if (string.IsNullOrEmpty(txtPlayerFees.Text.Trim()))    //Player Fees validation
            {
                errorProvider7.SetError(txtPlayerFees, "Fees is required");
                return;
            }
            else
            {
                errorProvider7.SetError(txtPlayerFees, string.Empty);
            }

            if (string.IsNullOrEmpty(datePlayerPicker.Text.Trim())) //Date validation
            {
                errorProvider8.SetError(datePlayerPicker, "Date is required");
                return;
            }
            else
            {
                errorProvider8.SetError(datePlayerPicker, string.Empty);
            }

            if (string.IsNullOrEmpty(txtPlayerGender.Text.Trim()))   //Gender VAlidation
            {
                errorProvider9.SetError(txtPlayerGender, "Gender is required");
                return;
            }
            else
            {
                errorProvider9.SetError(txtPlayerGender, string.Empty);
            }
            //Establishing Connection
            SqlConnection conn = new SqlConnection(@"Data Source=ADARSH\SQLEXPRESS;Initial Catalog=SportsComplexdb;Integrated Security=True;Encrypt=False;TrustServerCertificate=True");
            conn.Open();//opening Connection
            //SQL COmmand for Updating Values in Player table
            SqlCommand cmd = new SqlCommand("update Admissiondb set playerName=@playerName,email=@email,mobile=@mobile,address=@address,sports=@sports,fees=@fees,dob=@dob,gender=@gender where RegistrationNo=@RegistrationNo", conn);
            cmd.Parameters.AddWithValue("@RegistrationNo", int.Parse(txtRegNo.Text));
            cmd.Parameters.AddWithValue("@PlayerName", txtPlayerName.Text);
            cmd.Parameters.AddWithValue("@Email", txtPlayerEmail.Text);
            cmd.Parameters.AddWithValue("@Mobile", txtPlayerMobile.Text);
            cmd.Parameters.AddWithValue("@Address", txtPlayerAddr.Text);
            cmd.Parameters.AddWithValue("@Sports", txtSelectSports.Text);
            cmd.Parameters.AddWithValue("@Fees", txtPlayerFees.Text);
            cmd.Parameters.AddWithValue("@DOB", datePlayerPicker.Value);
            cmd.Parameters.AddWithValue("@Gender", txtPlayerGender.Text);
            cmd.ExecuteNonQuery();
            conn.Close();//Closing  Connection
            
            MessageBox.Show("Records Updated Successfully", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadLatestRow(int.Parse(txtRegNo.Text)); // Call to load the latest updated row
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            //Button to display in empty the textFields
            txtRegNo.Text= "";
            txtPlayerName.Text = "";
            txtPlayerMobile.Text = "";
            txtPlayerEmail.Text= "";
            txtPlayerAddr.Text= "";
            txtPlayerFees.Text= "";
            txtPlayerGender.Text = "";
            txtSelectSports.Text = "";
            datePlayerPicker.Text = "";
        }
        public void AutoGenerate()//function to auto generate the function
        {
            //Establishing Connection
            SqlConnection conn = new SqlConnection(@"Data Source=ADARSH\SQLEXPRESS;Initial Catalog=SportsComplexdb;Integrated Security=True;Encrypt=False;TrustServerCertificate=True");
            // If no records exist, it defaults to 1 (using ISNULL to handle null values)
            SqlDataAdapter adp = new SqlDataAdapter("select isnull(max(cast(RegistrationNo as int)),0)+1 from Admissiondb",conn);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            txtRegNo.Text = dt.Rows[0][0].ToString();
        }

        private void LoadLatestRow(int RegistrationNo)//function to Display latest updated Row
        {
            //Eshtablishing Connection
            using (SqlConnection conn = new SqlConnection(@"Data Source=ADARSH\SQLEXPRESS;Initial Catalog=SportsComplexdb;Integrated Security=True;Encrypt=False;TrustServerCertificate=True"))
            {
                conn.Open();//opening connection 
                SqlCommand cmd = new SqlCommand("SELECT * FROM Admissiondb Where RegistrationNo = @RegistrationNo", conn);
                cmd.Parameters.AddWithValue("@RegistrationNo", RegistrationNo);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();//Clearing DataGridView Content
                dataGridView1.DataSource = dt;//Storing DataGridview
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {   
            //Eshtablishing Connection
            SqlConnection conn = new SqlConnection(@"Data Source=ADARSH\SQLEXPRESS;Initial Catalog=SportsComplexdb;Integrated Security=True;Encrypt=False;TrustServerCertificate=True");
            conn.Open();//opening Connection
            //SQL Command for Searching data
            SqlCommand cmd = new SqlCommand("select * from Admissiondb where PlayerName like @PlayerName +'%'", conn);
            cmd.Parameters.AddWithValue("@PlayerName",txtSearch.Text.Trim());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)//Checking if the Search is found or not
            {
                dataGridView1.DataSource = dt;
            }
            else
            {
                MessageBox.Show("No Record Found!!!");
                dataGridView1.DataSource=null;
            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Main mm = new Main();//button to Redirect ro main page
            mm.Show();
        }

        private void Sports_Admission_Load(object sender, EventArgs e)
        {
            AutoGenerate();
        }
    }
}
