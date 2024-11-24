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

namespace SportsComplex
{
    public partial class SportsClubs : Form
    {
        public SportsClubs()
        {
            InitializeComponent();
            CustomizeDataGridView(dataGridView1);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            AutoGenerate();
            if (string.IsNullOrEmpty(txtClubId.Text.Trim()))    //Club ID Validation
            {
                errorProvider1.SetError(txtClubId, "Club id is required");
                return;
            }
            else
            {
                errorProvider1.SetError(txtClubId, string.Empty);   
            }

            if (string.IsNullOrEmpty(txtClubName.Text.Trim()))  //Club Name Validation
            {
                errorProvider2.SetError(txtClubName, "Club name is required");
                return;
            }
            else
            {
                errorProvider2.SetError(txtClubName, string.Empty);
            }

            if (string.IsNullOrEmpty(txtClubType.Text.Trim()))  //Club type Validation
            {
                errorProvider3.SetError(txtClubType, "Club type is required");
                return;
            }
            else
            {
                errorProvider3.SetError(txtClubType, string.Empty);
            }

            if (string.IsNullOrEmpty(txtClubManager.Text.Trim()))   //Manager Validation
            {
                errorProvider4.SetError(txtClubManager, "Club manager name is required");
                return;
            }
            else
            {
                errorProvider4.SetError(txtClubManager, string.Empty);
            }

            if (string.IsNullOrEmpty(txtManagerContact.Text.Trim()))    //Contact Validation
            {
                errorProvider4.SetError(txtManagerContact, "Mobile number is required");
                return;
            }
            else
            {
                errorProvider4.SetError(txtManagerContact, string.Empty);
            }

            string mobilePattern = @"^\d{10}$";
            if (!Regex.IsMatch(txtManagerContact.Text.Trim(), mobilePattern))   //Checking if number is of 10 Digits
            {
                errorProvider4.SetError(txtManagerContact, "Mobile number must be 10 digits");
                return;
            }
            else
            {
                errorProvider4.SetError(txtManagerContact, string.Empty);
            }

            if (string.IsNullOrEmpty(txtMembershipFees.Text.Trim()))    //Membership fees Validation
            {
                errorProvider6.SetError(txtMembershipFees, "Fees is required");
                return;
            }
            else
            {
                errorProvider6.SetError(txtMembershipFees, string.Empty);
            }

            //Establishing Connection
            SqlConnection conn = new SqlConnection(@"Data Source=ADARSH\SQLEXPRESS;Initial Catalog=SportsComplexdb;Integrated Security=True;Encrypt=False;TrustServerCertificate=True");
            conn.Open();//Opening Connection
            SqlCommand cmd = new SqlCommand("insert into SportsClubTAb values(@ClubId,@ClubName,@ClubType,@ClubManager,@ManagerContact,@MembershipFees)", conn);
            cmd.Parameters.AddWithValue("@ClubId", int.Parse(txtClubId.Text));
            cmd.Parameters.AddWithValue("@ClubName", txtClubName.Text);
            cmd.Parameters.AddWithValue("@ClubType", txtClubType.Text);
            cmd.Parameters.AddWithValue("@ClubManager", txtClubManager.Text);
            cmd.Parameters.AddWithValue("@ManagerContact", txtManagerContact.Text);
            cmd.Parameters.AddWithValue("@MembershipFees", txtMembershipFees.Text);
            cmd.ExecuteNonQuery();
            conn.Close();//Closing COnnection
            MessageBox.Show("Records Saved Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadLatestRow(int.Parse(txtClubId.Text));
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtClubId.Text.Trim()))    //Club ID Validation
            {
                errorProvider1.SetError(txtClubId, "Club id is required");
                return;
            }
            else
            {
                errorProvider1.SetError(txtClubId, string.Empty);
            }

            if (string.IsNullOrEmpty(txtClubName.Text.Trim()))  //Club Name Validation
            {
                errorProvider2.SetError(txtClubName, "Club name is required");
                return;
            }
            else
            {
                errorProvider2.SetError(txtClubName, string.Empty);
            }

            if (string.IsNullOrEmpty(txtClubType.Text.Trim()))  //Club type Validation
            {
                errorProvider3.SetError(txtClubType, "Club type is required");
                return;
            }
            else
            {
                errorProvider3.SetError(txtClubType, string.Empty);
            }

            if (string.IsNullOrEmpty(txtClubManager.Text.Trim()))   //Manager Validation
            {
                errorProvider4.SetError(txtClubManager, "Club manager name is required");
                return;
            }
            else
            {
                errorProvider4.SetError(txtClubManager, string.Empty);
            }

            if (string.IsNullOrEmpty(txtManagerContact.Text.Trim()))    //Contact Validation
            {
                errorProvider4.SetError(txtManagerContact, "Mobile number is required");
                return;
            }
            else
            {
                errorProvider4.SetError(txtManagerContact, string.Empty);
            }

            string mobilePattern = @"^\d{10}$";
            if (!Regex.IsMatch(txtManagerContact.Text.Trim(), mobilePattern))   //Checking if number is of 10 Digits
            {
                errorProvider4.SetError(txtManagerContact, "Mobile number must be 10 digits");
                return;
            }
            else
            {
                errorProvider4.SetError(txtManagerContact, string.Empty);
            }

            if (string.IsNullOrEmpty(txtMembershipFees.Text.Trim()))    //Membership fees Validation
            {
                errorProvider6.SetError(txtMembershipFees, "Fees is required");
                return;
            }
            else
            {
                errorProvider6.SetError(txtMembershipFees, string.Empty);
            }

            //Eshtablishing Connection
            SqlConnection conn = new SqlConnection(@"Data Source=ADARSH\SQLEXPRESS;Initial Catalog=SportsComplexdb;Integrated Security=True;Encrypt=False;TrustServerCertificate=True");
            conn.Open();//Connection open
            //SQL Command for Updating Sports Club in database
            SqlCommand cmd = new SqlCommand("update SportsClubTAb set ClubName=@ClubName,ClubType=@ClubType,ClubManager=@ClubManager,ManagerContact=@ManagerContact,MembershipFees=@MembershipFees where ClubId=@ClubId", conn);
            cmd.Parameters.AddWithValue("@ClubId", int.Parse(txtClubId.Text));
            cmd.Parameters.AddWithValue("@ClubName", txtClubName.Text);
            cmd.Parameters.AddWithValue("@ClubType", txtClubType.Text);
            cmd.Parameters.AddWithValue("@ClubManager", txtClubManager.Text);
            cmd.Parameters.AddWithValue("@ManagerContact", txtManagerContact.Text);
            cmd.Parameters.AddWithValue("@MembershipFees", txtMembershipFees.Text);
            cmd.ExecuteNonQuery();
            conn.Close();//Connection close
            MessageBox.Show("Records Updated Successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadLatestRow(int.Parse(txtClubId.Text));
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            // button to reset all the Text filed to empty
            txtClubId.Text = "";
            txtClubName.Text = "";
            txtClubType.Text = "";
            txtClubManager.Text = "";
            txtManagerContact.Text = "";
            txtMembershipFees.Text = "";
        }
        private void SportsClubs_Load(object sender, EventArgs e)
        {
            AutoGenerate();//Function call at the load of form
        }
        public void AutoGenerate()//function to Auto Generate the Club id 
        {
            //Eshtablish COnnection
            SqlConnection conn = new SqlConnection(@"Data Source=ADARSH\SQLEXPRESS;Initial Catalog=SportsComplexdb;Integrated Security=True;Encrypt=False;TrustServerCertificate=True");
            // If no records exist, it defaults to 1 (using ISNULL to handle null values)
            SqlDataAdapter adp = new SqlDataAdapter("select isnull(max(cast(ClubId as int)),0)+1 from SportsClubTab", conn);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            txtClubId.Text = dt.Rows[0][0].ToString();//Storing Updated Row
        }

        private void btnSearch_Click(object sender, EventArgs e)//Button to Search
        {
            //Eshtablishing Connection
            SqlConnection conn = new SqlConnection(@"Data Source=ADARSH\SQLEXPRESS;Initial Catalog=SportsComplexdb;Integrated Security=True;Encrypt=False;TrustServerCertificate=True");
            conn.Open();//Opening Connection
            //SQL Command For Searching
            SqlCommand cmd = new SqlCommand("select * from SportsClubTab where ClubName like @ClubName +'%'", conn);
            cmd.Parameters.AddWithValue("@ClubName", txtSearch.Text.Trim());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)//Checking if the Search Element is found or not
            {
                dataGridView1.DataSource = dt;//If found Displaying on database
            }
            else
            {
                MessageBox.Show("No Record Found!!!");
                dataGridView1.DataSource = null;
            }
        }
        private void LoadLatestRow(int ClubId)
        {
            //Eshtablishing Connection
            using (SqlConnection conn = new SqlConnection(@"Data Source=ADARSH\SQLEXPRESS;Initial Catalog=SportsComplexdb;Integrated Security=True;Encrypt=False;TrustServerCertificate=True")) 
            {
                conn.Open();//opening connection
                //Sql Command for Select latest Row
                SqlCommand cmd = new SqlCommand("SELECT * FROM SportsClubTab Where ClubId = @ClubId", conn);
                cmd.Parameters.AddWithValue("@ClubId", ClubId);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();//Clearing the DadaGridView
                dataGridView1.DataSource = dt;//Storing DataGrid View
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Main mm = new Main();//Button which redirect to main page
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
