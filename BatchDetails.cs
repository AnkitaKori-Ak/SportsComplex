using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SportsComplex
{
    public partial class BatchDetails : Form
    {
        public BatchDetails()
        {
            InitializeComponent();
            CustomizeDataGridView(dataGridView1);
        }

        private void dateStart_ValueChanged(object sender, EventArgs e)
        {
            dateStart.CustomFormat = "dd/MM/yyyy"; //defining Start date Format
        }

        private void dateStart_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                dateStart.CustomFormat = " "; //Empty date Field by back button
            }
        }

        private void dateEnd_ValueChanged(object sender, EventArgs e)
        {
            dateEnd.CustomFormat = "dd/MM/yyyy";     //defining Start date Format
        }

        private void dateEnd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                dateEnd.CustomFormat = " ";     //Empty date Field by back button
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            AutoGenerate(); //Calling Autogenerate code for BatchID
            // Validate if the Batch ID field is not empty
            if (string.IsNullOrEmpty(txtbatchId.Text.Trim())) // ID Validation
            {
                errorProvider1.SetError(txtbatchId, "Batch id is required");
                return;
            }
            else
            {
                errorProvider1.SetError(txtbatchId, string.Empty);
            }

            if (string.IsNullOrEmpty(txtBatchName.Text.Trim())) // Batch Name Validation
            {
                errorProvider2.SetError(txtBatchName, "Batch name is required");
                return;
            }
            else
            {
                errorProvider2.SetError(txtBatchName, string.Empty);
            }

            if (string.IsNullOrEmpty(txtActivity_Sports.Text.Trim())) //Batch Activity Validation
            {
                errorProvider3.SetError(txtActivity_Sports, "Selection of sports is required");
                return;
            }
            else
            {
                errorProvider3.SetError(txtActivity_Sports, string.Empty);
            }

            if (string.IsNullOrEmpty(txtInstructor.Text.Trim()))    //Batch Instructor Validation
            {
                errorProvider4.SetError(txtInstructor, "Instructor name is required");
                return;
            }
            else
            {
                errorProvider4.SetError(txtInstructor, string.Empty);
            }

            if (string.IsNullOrEmpty(dateStart.Text.Trim()))    // Batch Start Date Validation
            {
                errorProvider5.SetError(dateStart, "Start date is required");
                return;
            }
            else
            {
                errorProvider5.SetError(dateStart, string.Empty);
            }

            if (string.IsNullOrEmpty(dateEnd.Text.Trim()))   //Batch End Date Validation
            {
                errorProvider6.SetError(dateEnd, "End date is required");
                return;
            }
            else
            {
                errorProvider6.SetError(dateEnd, string.Empty);
            }
            // Additional validation: Ensure End Date is greater than Start Date
            if (!string.IsNullOrEmpty(dateStart.Text.Trim()) &&
                !string.IsNullOrEmpty(dateEnd.Text.Trim()))
            {
                if (DateTime.TryParse(dateStart.Text.Trim(), out DateTime startDate) &&
                    DateTime.TryParse(dateEnd.Text.Trim(), out DateTime endDate))
                {
                    if (endDate <= startDate)
                    {
                        errorProvider6.SetError(dateEnd, "End date must be greater than the start date");
                        return;
                    }
                    else
                    {
                        errorProvider6.SetError(dateEnd, string.Empty);
                    }
                }
                else
                {
                    if (!DateTime.TryParse(dateStart.Text.Trim(), out _))
                    {
                        errorProvider5.SetError(dateStart, "Invalid start date format");
                    }
                    if (!DateTime.TryParse(dateEnd.Text.Trim(), out _))
                    {
                        errorProvider6.SetError(dateEnd, "Invalid end date format");
                    }
                    return;
                }
            }

            // The rest of your code continues here, if any.

            // Establish a connection to the database
            SqlConnection conn = new SqlConnection(@"Data Source=ADARSH\SQLEXPRESS;Initial Catalog=SportsComplexdb;Integrated Security=True;Encrypt=False;TrustServerCertificate=True");
            conn.Open();// Open the connection to the database

            // Create an SQL command to insert the record in the database
            SqlCommand cmd = new SqlCommand("insert into BatchTab values(@BatchId,@BatchName,@Sports,@Instructor,@StartDate,@EndDate)", conn);
            // Add parameter values to prevent SQL injection
            cmd.Parameters.AddWithValue("@BatchId", int.Parse(txtbatchId.Text));
            cmd.Parameters.AddWithValue("@BatchName", txtBatchName.Text);
            cmd.Parameters.AddWithValue("@Sports", txtActivity_Sports.Text);
            cmd.Parameters.AddWithValue("@Instructor", txtInstructor.Text);
            cmd.Parameters.AddWithValue("@StartDate", dateStart.Value);
            cmd.Parameters.AddWithValue("@EndDate", dateEnd.Value);
            cmd.ExecuteNonQuery();
            conn.Close();//Closing Connection
            MessageBox.Show("Records Saved Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadLatestRow(int.Parse(txtbatchId.Text));//Calling latest updated Row for dataBase
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Validate if the Batch ID field is not empty
            if (string.IsNullOrEmpty(txtbatchId.Text.Trim()))   //ID Validation
            {
                errorProvider1.SetError(txtbatchId, "Batch id is required");
                return;
            }
            else
            {
                errorProvider1.SetError(txtbatchId, string.Empty);
            }

            if (string.IsNullOrEmpty(txtBatchName.Text.Trim())) //Batch Name Validation
            {
                errorProvider2.SetError(txtBatchName, "Batch name is required");
                return;
            }
            else
            {
                errorProvider2.SetError(txtBatchName, string.Empty);   
            }

            if (string.IsNullOrEmpty(txtActivity_Sports.Text.Trim()))   //Batch Activity Validation
            {
                errorProvider3.SetError(txtActivity_Sports, "Selection of sports is required");
                return;
            }
            else
            {
                errorProvider3.SetError(txtActivity_Sports, string.Empty);
            }

            if (string.IsNullOrEmpty(txtInstructor.Text.Trim()))    //Batch Instructor Validation
            {
                errorProvider4.SetError(txtInstructor, "Instructor name is required");
                return;
            }
            else
            {
                errorProvider4.SetError(txtInstructor, string.Empty);
            }

            if (string.IsNullOrEmpty(dateStart.Text.Trim()))    //Batch Start Date Validation
            {
                errorProvider5.SetError(dateStart, "Start date is required");
                return;
            }
            else
            {
                errorProvider5.SetError(dateStart, string.Empty);
            }

            if (string.IsNullOrEmpty(dateEnd.Text.Trim()))  //Batch End Date Validation
            {
                errorProvider6.SetError(dateEnd, "End date is required");
                return;
            }
            else
            {
                errorProvider6.SetError(dateEnd, string.Empty);
            }
            // Additional validation: Ensure End Date is greater than Start Date
            if (!string.IsNullOrEmpty(dateStart.Text.Trim()) &&
                !string.IsNullOrEmpty(dateEnd.Text.Trim()))
            {
                if (DateTime.TryParse(dateStart.Text.Trim(), out DateTime startDate) &&
                    DateTime.TryParse(dateEnd.Text.Trim(), out DateTime endDate))
                {
                    if (endDate <= startDate)
                    {
                        errorProvider6.SetError(dateEnd, "End date must be greater than the start date");
                        return;
                    }
                    else
                    {
                        errorProvider6.SetError(dateEnd, string.Empty);
                    }
                }
                else
                {
                    if (!DateTime.TryParse(dateStart.Text.Trim(), out _))
                    {
                        errorProvider5.SetError(dateStart, "Invalid start date format");
                    }
                    if (!DateTime.TryParse(dateEnd.Text.Trim(), out _))
                    {
                        errorProvider6.SetError(dateEnd, "Invalid end date format");
                    }
                    return;
                }
            }

            // Establish a connection to the database
            SqlConnection conn = new SqlConnection(@"Data Source=ADARSH\SQLEXPRESS;Initial Catalog=SportsComplexdb;Integrated Security=True;Encrypt=False;TrustServerCertificate=True");
            conn.Open(); // Open the connection to the database

            // Create an SQL command to update the record in the database
            SqlCommand cmd = new SqlCommand("update BatchTab set BatchName=@BatchName,Sports=@Sports,Instructor=@Instructor,StartDate=@StartDate,EndDate=@EndDate where BatchId=@BatchId", conn);

            // Add parameter values to prevent SQL injection
            cmd.Parameters.AddWithValue("@BatchId", int.Parse(txtbatchId.Text));
            cmd.Parameters.AddWithValue("@BatchName", txtBatchName.Text);
            cmd.Parameters.AddWithValue("@Sports", txtActivity_Sports.Text);
            cmd.Parameters.AddWithValue("@Instructor", txtInstructor.Text);
            cmd.Parameters.AddWithValue("@StartDate", dateStart.Value);
            cmd.Parameters.AddWithValue("@EndDate", dateEnd.Value);
            cmd.ExecuteNonQuery();
            conn.Close(); //Closing Connection
            MessageBox.Show("Records Updated Successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadLatestRow(int.Parse(txtbatchId.Text)); 
        }

        private void btnNew_Click(object sender, EventArgs e) 
        {
            //Reseting the Values of TextFields to empty
            txtbatchId.Text = "";
            txtBatchName.Text = "";
            txtActivity_Sports.Text = "";
            txtInstructor.Text = "";
            txtInstructor.Text = "";
            dateStart.Text = "";
            dateEnd.Text = "";
        }

        private void BatchDetails_Load(object sender, EventArgs e)
        {
            AutoGenerate(); //Function Called on load of batchform
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
        public void AutoGenerate()
        {
            // Establish a connection to the database
            SqlConnection conn = new SqlConnection(@"Data Source=ADARSH\SQLEXPRESS;Initial Catalog=SportsComplexdb;Integrated Security=True;Encrypt=False;TrustServerCertificate=True");

      
            // The query retrieves the next available BatchId by finding the maximum value in the BatchTab table
            // If no records exist, it defaults to 1 (using ISNULL to handle null values)
            SqlDataAdapter adp = new SqlDataAdapter("select isnull(max(cast(BatchId as int)),0)+1 from BatchTab", conn);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            txtbatchId.Text = dt.Rows[0][0].ToString(); // Assign the resulting BatchId to the Batch ID text box
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //Establish Database Connection
            SqlConnection conn = new SqlConnection(@"Data Source=ADARSH\SQLEXPRESS;Initial Catalog=SportsComplexdb;Integrated Security=True;Encrypt=False;TrustServerCertificate=True");
            conn.Open();// opening Connection 

            // Create an SQL command to Search the record in the database
            SqlCommand cmd = new SqlCommand("select * from BatchTab where BatchName like @BatchName +'%'", conn);
            cmd.Parameters.AddWithValue("@BatchName", txtSearch.Text.Trim());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)// Check if any records were found
            {
                dataGridView1.DataSource = dt; // if Found, Display in data GridView
            }
            else
            {
                MessageBox.Show("No Record Found!!!");// message box if not found
                dataGridView1.DataSource = null;
            }

        }
        private void LoadLatestRow(int BatchId) // Function to display Updated row in dataGridView 
        {
           // Connection Establish
            using (SqlConnection conn = new SqlConnection(@"Data Source=ADARSH\SQLEXPRESS;Initial Catalog=SportsComplexdb;Integrated Security=True;Encrypt=False;TrustServerCertificate=True"))
            {
                conn.Open(); //opening connection
                SqlCommand cmd = new SqlCommand("SELECT * FROM BatchTab Where BatchId = @BatchId", conn); // Command for to display latest updated row
                cmd.Parameters.AddWithValue("@BatchId", BatchId);//Accessing Batch id from textbox
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();// clearing datagridview
                dataGridView1.DataSource = dt;// storing updated row in dataGridview
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Main mm = new Main();// button redirect to main page
            mm.Show();
        }
    }
}
