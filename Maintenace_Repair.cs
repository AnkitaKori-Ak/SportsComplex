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
    public partial class Maintenace_Repair : Form
    {
        public Maintenace_Repair()
        {
            InitializeComponent();
            CustomizeDataGridView(dataGridView1);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            AutoGenerate();
            if (string.IsNullOrEmpty(txtEquipmentId.Text.Trim()))//Equipment ID Validation
            {
                errorProvider1.SetError(txtEquipmentId, "Equipment id is required");
                return;
            }
            else
            {
                errorProvider1.SetError(txtEquipmentId, string.Empty);
            }

            if (string.IsNullOrEmpty(txtEquipmentName.Text.Trim())) //Equipment Name validation
            {
                errorProvider2.SetError(txtEquipmentName, "Maintenance area is required");
                return;
            }
            else
            {
                errorProvider2.SetError(txtEquipmentName, string.Empty);
            }

            if (string.IsNullOrEmpty(txtInfrastructure.Text.Trim())) // Infrastructure Validation
            {
                errorProvider3.SetError(txtInfrastructure, "Selection of infrasturture is required");
                return;
            }
            else
            {
                errorProvider3.SetError(txtInfrastructure, string.Empty);
            }

            if (string.IsNullOrEmpty(dateReported.Text.Trim())) //Reported Date Validation
            {
                errorProvider4.SetError(dateReported, "Date is required");
                return;
            }
            else
            {
                errorProvider4.SetError(dateReported, string.Empty);
            }

            if (string.IsNullOrEmpty(txtStatus.Text.Trim())) //Status Validation
            {
                errorProvider5.SetError(txtStatus, "Status is required");
                return;
            }
            else
            {
                errorProvider5.SetError(txtStatus, string.Empty);
            }

            if (string.IsNullOrEmpty(txtIssueDescription.Text.Trim()))  //Issue Description validation
            {
                errorProvider6.SetError(txtIssueDescription, "Description is required");
                return;
            }
            else
            {
                errorProvider6.SetError(txtIssueDescription, string.Empty);
            }

            if (string.IsNullOrEmpty(txtCost.Text.Trim())) //Cost Validation
            {
                errorProvider7.SetError(txtCost, "Cost is required");
                return;
            }
            else
            {
                errorProvider7.SetError(txtCost, string.Empty);
            }
            //Establish Connection
            SqlConnection conn = new SqlConnection(@"Data Source=ADARSH\SQLEXPRESS;Initial Catalog=SportsComplexdb;Integrated Security=True;Encrypt=False;TrustServerCertificate=True");
            conn.Open(); //Open Connection
            //SQl Command For Inserting Values
            SqlCommand cmd = new SqlCommand("insert into MaintenaceTab values(@EquipmentId,@MaintanaceRepairs,@Infrastructure,@DateReported,@Status,@IssueDescription,@Cost)", conn);
            cmd.Parameters.AddWithValue("@EquipmentId", int.Parse(txtEquipmentId.Text));
            cmd.Parameters.AddWithValue("@MaintanaceRepairs", txtEquipmentName.Text);
            cmd.Parameters.AddWithValue("@Infrastructure", txtInfrastructure.Text);
            cmd.Parameters.AddWithValue("@DateReported", dateReported.Value);
            cmd.Parameters.AddWithValue("@Status", txtStatus.Text);
            cmd.Parameters.AddWithValue("@IssueDescription", txtIssueDescription.Text);
            cmd.Parameters.AddWithValue("@Cost", txtCost.Text);
            cmd.ExecuteNonQuery();
            conn.Close(); //Closing Connection
            MessageBox.Show("Records Saved Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadLatestRow(int.Parse(txtEquipmentId.Text)); // Calling Display latest Row
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEquipmentId.Text.Trim()))//Equipment ID Validation
            {
                errorProvider1.SetError(txtEquipmentId, "Equipment id is required");
                return;
            }
            else
            {
                errorProvider1.SetError(txtEquipmentId, string.Empty);
            }

            if (string.IsNullOrEmpty(txtEquipmentName.Text.Trim())) //Equipment Name validation
            {
                errorProvider2.SetError(txtEquipmentName, "Maintenance area is required");
                return;
            }
            else
            {
                errorProvider2.SetError(txtEquipmentName, string.Empty);
            }

            if (string.IsNullOrEmpty(txtInfrastructure.Text.Trim())) // Infrastructure Validation
            {
                errorProvider3.SetError(txtInfrastructure, "Selection of infrasturture is required");
                return;
            }
            else
            {
                errorProvider3.SetError(txtInfrastructure, string.Empty);
            }

            if (string.IsNullOrEmpty(dateReported.Text.Trim())) //Reported Date Validation
            {
                errorProvider4.SetError(dateReported, "Date is required");
                return;
            }
            else
            {
                errorProvider4.SetError(dateReported, string.Empty);
            }

            if (string.IsNullOrEmpty(txtStatus.Text.Trim())) //Status Validation
            {
                errorProvider5.SetError(txtStatus, "Status is required");
                return;
            }
            else
            {
                errorProvider5.SetError(txtStatus, string.Empty);
            }

            if (string.IsNullOrEmpty(txtIssueDescription.Text.Trim()))  //Issue Description validation
            {
                errorProvider6.SetError(txtIssueDescription, "Description is required");
                return;
            }
            else
            {
                errorProvider6.SetError(txtIssueDescription, string.Empty);
            }

            if (string.IsNullOrEmpty(txtCost.Text.Trim())) //Cost Validation
            {
                errorProvider7.SetError(txtCost, "Cost is required");
                return;
            }
            else
            {
                errorProvider7.SetError(txtCost, string.Empty);
            }

            //Establish COnnection
            SqlConnection conn = new SqlConnection(@"Data Source=ADARSH\SQLEXPRESS;Initial Catalog=SportsComplexdb;Integrated Security=True;Encrypt=False;TrustServerCertificate=True");
            conn.Open();// Connection Open
            //Sql Command for updating Databse
            SqlCommand cmd = new SqlCommand("update MaintenaceTab set MaintanaceRepairs=@MaintanaceRepairs,Infrastructure=@Infrastructure,DateReported=@DateReported,Status=@Status,IsssueDescription=@IsssueDescription,Cost=@Cost where EquipmentId=@EquipmentId", conn);
            // Add parameter values to prevent SQL injection
            cmd.Parameters.AddWithValue("@EquipmentId", int.Parse(txtEquipmentId.Text));
            cmd.Parameters.AddWithValue("@MaintanaceRepairs", txtEquipmentName.Text);
            cmd.Parameters.AddWithValue("@Infrastructure", txtInfrastructure.Text);
            cmd.Parameters.AddWithValue("@DateReported", dateReported.Value);
            cmd.Parameters.AddWithValue("@Status", txtStatus.Text);
            cmd.Parameters.AddWithValue("@IsssueDescription", txtIssueDescription.Text);
            cmd.Parameters.AddWithValue("@Cost", txtCost.Text);
            cmd.ExecuteNonQuery();
            conn.Close(); //Closing Connection
            MessageBox.Show("Records Updated Successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadLatestRow(int.Parse(txtEquipmentId.Text)); // Calling updated Row Display on GridView
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            //Button for Reset the TextField to Empty
            txtEquipmentId.Text = "";
            txtEquipmentName.Text = "";
            txtInfrastructure.Text = "";
            dateReported.Text = "";
            txtStatus.Text = "";
            txtIssueDescription.Text = "";
            txtCost.Text = "";
        }
        private void Maintenace_Repair_Load(object sender, EventArgs e)
        {
            AutoGenerate(); //Function Call on load of the page
        }

        private void dateReported_ValueChanged(object sender, EventArgs e)
        {
            dateReported.CustomFormat = "dd/MM/yyyy"; //FOrmate the date
        }

        private void dateReported_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                dateReported.CustomFormat = " "; //Empty Date Field on BackSpace
            }
        }
        public void AutoGenerate()//function to Auto Generate Equipment ID
        {
            //Establish Connection
            SqlConnection conn = new SqlConnection(@"Data Source=ADARSH\SQLEXPRESS;Initial Catalog=SportsComplexdb;Integrated Security=True;Encrypt=False;TrustServerCertificate=True");
            // If no records exist, it defaults to 1 (using ISNULL to handle null values)
            SqlDataAdapter adp = new SqlDataAdapter("select isnull(max(cast(EquipmentId as int)),0)+1 from MaintenaceTab", conn);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            txtEquipmentId.Text = dt.Rows[0][0].ToString();// Assign the resulting Equipment Id to the Equypment ID text box
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //Establish Connection
            SqlConnection conn = new SqlConnection(@"Data Source=ADARSH\SQLEXPRESS;Initial Catalog=SportsComplexdb;Integrated Security=True;Encrypt=False;TrustServerCertificate=True");
            conn.Open();//Opening Connection
            //SQl Command to search
            SqlCommand cmd = new SqlCommand("select * from MaintenaceTab where MaintanaceRepairs like @MaintanaceRepairs +'%'", conn);
            cmd.Parameters.AddWithValue("@MaintanaceRepairs", txtSearch.Text.Trim());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)  //if found display it to DataGridView
            {
                dataGridView1.DataSource = dt;
            }
            else
            {
                MessageBox.Show("No Record Found!!!");
                dataGridView1.DataSource = null;
            }
        }
        private void LoadLatestRow(int EquipmentId)//Function for Displaying Latest updated Row
        {
            //Establishing Connection
            using (SqlConnection conn = new SqlConnection(@"Data Source=ADARSH\SQLEXPRESS;Initial Catalog=SportsComplexdb;Integrated Security=True;Encrypt=False;TrustServerCertificate=True"))
            {
                conn.Open();//Connectio open

                //SQL Command to Select updated row
                SqlCommand cmd = new SqlCommand("SELECT * FROM MaintenaceTab  Where EquipmentId = @EquipmentId", conn);
                cmd.Parameters.AddWithValue("@EquipmentId", EquipmentId);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();// Clearing DataGridView
                dataGridView1.DataSource = dt; //Displaying Updated Row in DataGridView
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Main mm = new Main();//Button TO Redirect to Main page 
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
