using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace SportsComplex
{
    public partial class Events : Form
    {
        public Events()
        {
            InitializeComponent();
            CustomizeDataGridView(dataGridView1);
        }

       
        private void btnSave_Click(object sender, EventArgs e)
        {

            AutoGenerate(); //Calling AutotGenerate Function for Event ID
            if (string.IsNullOrEmpty(txtEventId.Text.Trim())) //Event ID Validation
            {
                errorProvider1.SetError(txtEventId, "Event id is required");
                return;
            }
            else
            {
                errorProvider1.SetError(txtEventId, string.Empty);
            }

            if (string.IsNullOrEmpty(txtEventName.Text.Trim())) //Event Name Validation
            {
                errorProvider2.SetError(txtEventName, "Event name is required");
                return;
            }
            else
            {
                errorProvider2.SetError(txtEventName, string.Empty);
            }

            if (string.IsNullOrEmpty(dateEvent.Text.Trim()))    //Event Date validation
            {
                errorProvider3.SetError(dateEvent, "Event date is required");
                return;
            }
            else
            {
                errorProvider3.SetError(dateEvent, string.Empty);
            }

            if (string.IsNullOrEmpty(txtConcernedFaculty.Text.Trim())) //Event Faculty validation
            {
                errorProvider4.SetError(txtConcernedFaculty, "Faculty name is required");
                return;
            }
            else
            {
                errorProvider4.SetError(txtConcernedFaculty, string.Empty);
            }

            if (string.IsNullOrEmpty(txtNoOfParticipants.Text.Trim()))  //Event No of participants Validation
            {
                errorProvider5.SetError(txtNoOfParticipants, "Participants number is required");
                return;
            }
            else
            {
                errorProvider5.SetError(txtNoOfParticipants, string.Empty);
            }

           
            if (string.IsNullOrEmpty(txtContact.Text.Trim()))   //Event Contact no Validation
            {
                errorProvider6.SetError(txtContact, "Contact number is required");
                return;
            }
            else
            {
                errorProvider6.SetError(txtContact, string.Empty);
            }

            string pattern = @"^\d{10}$";
            if (!Regex.IsMatch(txtContact.Text.Trim(), pattern)) //Phone No Validation 10 Digits
            {
                errorProvider6.SetError(txtContact, "Contact number must be 10 digits");
                return;
            }
            else
            {
                errorProvider6.SetError(txtContact, string.Empty);
            }

            //Establishing Connection
            SqlConnection conn = new SqlConnection(@"Data Source=ADARSH\SQLEXPRESS;Initial Catalog=SportsComplexdb;Integrated Security=True;Encrypt=False;TrustServerCertificate=True");
            conn.Open(); //Opening Connection

            // SQL Command for Insert values in database 
            SqlCommand cmd = new SqlCommand("insert into EventTab values(@EventID,@EventName,@EventDate,@ConcernedFaculty,@ParticipantsNo,@ContactNo)", conn);
            //Accessing values form textbox
            cmd.Parameters.AddWithValue("@EventID", int.Parse(txtEventId.Text));
            cmd.Parameters.AddWithValue("@EventName", txtEventName.Text);
            cmd.Parameters.AddWithValue("@EventDate", dateEvent.Value);
            cmd.Parameters.AddWithValue("@ConcernedFaculty", txtConcernedFaculty.Text);
            cmd.Parameters.AddWithValue("@ParticipantsNo", txtNoOfParticipants.Text);
            cmd.Parameters.AddWithValue("@ContactNo", txtContact.Text);
            cmd.ExecuteNonQuery();
            conn.Close();// closing Connection
            MessageBox.Show("Records Saved Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadLatestRow(int.Parse(txtEventId.Text));
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEventId.Text.Trim())) //Event ID Validation
            {
                errorProvider1.SetError(txtEventId, "Event id is required");
                return;
            }
            else
            {
                errorProvider1.SetError(txtEventId, string.Empty);
            }

            if (string.IsNullOrEmpty(txtEventName.Text.Trim())) //Event Name Validation
            {
                errorProvider2.SetError(txtEventName, "Event name is required");
                return;
            }
            else
            {
                errorProvider2.SetError(txtEventName, string.Empty);
            }

            if (string.IsNullOrEmpty(dateEvent.Text.Trim()))    //Event Date validation
            {
                errorProvider3.SetError(dateEvent, "Event date is required");
                return;
            }
            else
            {
                errorProvider3.SetError(dateEvent, string.Empty);
            }

            if (string.IsNullOrEmpty(txtConcernedFaculty.Text.Trim())) //Event Faculty validation
            {
                errorProvider4.SetError(txtConcernedFaculty, "Faculty name is required");
                return;
            }
            else
            {
                errorProvider4.SetError(txtConcernedFaculty, string.Empty);
            }

            if (string.IsNullOrEmpty(txtNoOfParticipants.Text.Trim()))  //Event No of participants Validation
            {
                errorProvider5.SetError(txtNoOfParticipants, "Participants number is required");
                return;
            }
            else
            {
                errorProvider5.SetError(txtNoOfParticipants, string.Empty);
            }


            if (string.IsNullOrEmpty(txtContact.Text.Trim()))   //Event Contact no Validation
            {
                errorProvider6.SetError(txtContact, "Contact number is required");
                return;
            }
            else
            {
                errorProvider6.SetError(txtContact, string.Empty);
            }

            string pattern = @"^\d{10}$";
            if (!Regex.IsMatch(txtContact.Text.Trim(), pattern)) //Phone No Validation 10 Digits
            {
                errorProvider6.SetError(txtContact, "Contact number must be 10 digits");
                return;
            }
            else
            {
                errorProvider6.SetError(txtContact, string.Empty);
            }

            //Establishing Connection
            SqlConnection conn = new SqlConnection(@"Data Source=ADARSH\SQLEXPRESS;Initial Catalog=SportsComplexdb;Integrated Security=True;Encrypt=False;TrustServerCertificate=True");
            conn.Open(); //Opening Conection
            //SQL Command for Update Row in database
            SqlCommand cmd = new SqlCommand("update EventTab set EventName=@EventName,EventDate=@EventDate,ConcernedFaculty=@ConcernedFaculty,ParticipantsNo=@ParticipantsNo,ContactNo=@ContactNo where EventID=@EventID ", conn);
            cmd.Parameters.AddWithValue("@EventID", int.Parse(txtEventId.Text));
            cmd.Parameters.AddWithValue("@EventName", txtEventName.Text);
            cmd.Parameters.AddWithValue("@EventDate", dateEvent.Value);
            cmd.Parameters.AddWithValue("@ConcernedFaculty", txtConcernedFaculty.Text);
            cmd.Parameters.AddWithValue("@ParticipantsNo", txtNoOfParticipants.Text);
            cmd.Parameters.AddWithValue("@ContactNo", txtContact.Text);
            cmd.ExecuteNonQuery();
            conn.Close(); //Closing Connection
            MessageBox.Show("Records Updated Successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadLatestRow(int.Parse(txtEventId.Text));
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            //Reseting button to reset all text fill to empty
            txtEventId.Text = "";
            txtEventName.Text = "";
            dateEvent.Text = "";
            txtConcernedFaculty.Text = "";
            txtNoOfParticipants.Text = "";
            txtContact.Text = "";
        }

        private void Events_Load(object sender, EventArgs e)
        {
            AutoGenerate(); //Calling Autogenerate ID on load of Form
        }
        public void AutoGenerate()// Fucntion to Auto Generate Event ID
        {
            //Establishing Connection
            SqlConnection conn = new SqlConnection(@"Data Source=ADARSH\SQLEXPRESS;Initial Catalog=SportsComplexdb;Integrated Security=True;Encrypt=False;TrustServerCertificate=True");

            // If no records exist, it defaults to 1 (using ISNULL to handle null values)
            SqlDataAdapter adp = new SqlDataAdapter("select isnull(max(cast(EventID as int)),0)+1 from EventTab", conn);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            txtEventId.Text = dt.Rows[0][0].ToString(); // Assign the resulting BatchId to the Batch ID text box
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //Establishing Connection
            SqlConnection conn = new SqlConnection(@"Data Source=ADARSH\SQLEXPRESS;Initial Catalog=SportsComplexdb;Integrated Security=True;Encrypt=False;TrustServerCertificate=True");
            conn.Open(); //opening Connection

            //SQL Command For Search Event name form database
            SqlCommand cmd = new SqlCommand("select * from EventTab where EventName like @EventName +'%'", conn);
            cmd.Parameters.AddWithValue("@EventName", txtSearch.Text.Trim());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0) //Checking is Search Item is Found
            {
                dataGridView1.DataSource = dt; // if found Display in in DataGridView  
            }
            else
            {
                MessageBox.Show("No Record Found!!!");
                dataGridView1.DataSource = null;
            }
        }
        private void LoadLatestRow(int EventID)// Function to display Updated Latest Row In dataGridView
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=ADARSH\SQLEXPRESS;Initial Catalog=SportsComplexdb;Integrated Security=True;Encrypt=False;TrustServerCertificate=True"))
            {
                conn.Open(); //Opeing Connection
                //SQl Command for Selecting Updated Id
                SqlCommand cmd = new SqlCommand("SELECT * FROM EventTab Where EventID = @EventID", conn);
                cmd.Parameters.AddWithValue("@EventID", EventID);//Accessing Event id from txtEvent
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear(); //Clearing DataGridView view
                dataGridView1.DataSource = dt; // Display Updated Row
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Main mm = new Main(); //Button Redirect to Main Page
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
