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
    public partial class PlayerPayment : Form
    {
        public PlayerPayment()
        {
            InitializeComponent();
            CustomizeDataGridView(dataGridView1);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            AutoGenerate();//Calling Auto Generate Id Function
            if (string.IsNullOrEmpty(txtBillingNo.Text.Trim()))// Bill No Validation
            {
                errorProvider1.SetError(txtBillingNo, "Billing number is required");
                return;
            }
            else
            {
                errorProvider1.SetError(txtBillingNo, string.Empty);
            }

            if (string.IsNullOrEmpty(txtName.Text.Trim())) // Name Validation
            {
                errorProvider2.SetError(txtName, "Name is required");
                return;
            }
            else
            {
                errorProvider2.SetError(txtName, string.Empty);
            }

            if (string.IsNullOrEmpty(txtRegNo.Text.Trim())) //Phone No Validation
            {
                errorProvider3.SetError(txtRegNo, "Registration number is required");
                return;
            }
            else
            {
                errorProvider3.SetError(txtRegNo, string.Empty);
            }

            if (string.IsNullOrEmpty(txtSports.Text.Trim())) //Sport Validation
            {
                errorProvider4.SetError(txtSports, "Selection of sports is required");
                return;
            }
            else
            {
                errorProvider4.SetError(txtSports, string.Empty);
            }

            if (string.IsNullOrEmpty(txtAmount.Text.Trim())) //Amount validation
            {
                errorProvider5.SetError(txtAmount, "Amount is required");
                return;
            }
            else
            {
                errorProvider5.SetError(txtAmount, string.Empty);
            }

            if (string.IsNullOrEmpty(txtPaymentMethods.Text.Trim()))  //Palyment Method VAlidation
            {
                errorProvider6.SetError(txtPaymentMethods, "Selection of payment method is required");
                return;
            }
            else
            {
                errorProvider6.SetError(txtPaymentMethods, string.Empty);
            }

            //Establishing Connection
            SqlConnection conn = new SqlConnection(@"Data Source=ADARSH\SQLEXPRESS;Initial Catalog=SportsComplexdb;Integrated Security=True;Encrypt=False;TrustServerCertificate=True");
            conn.Open(); //Opening Connection
            //SQL Command for Inserting VAlues in dataBase
            SqlCommand cmd = new SqlCommand("insert into PlayerPaymentTab values(@BillingNo,@PlayerName,@RegNo,@Sports,@Amount,@PaymentMethod)", conn);
            cmd.Parameters.AddWithValue("@BillingNo", int.Parse(txtBillingNo.Text));
            cmd.Parameters.AddWithValue("@PlayerName", txtName.Text);
            cmd.Parameters.AddWithValue("@RegNo", txtRegNo.Text);
            cmd.Parameters.AddWithValue("@Sports", txtSports.Text);
            cmd.Parameters.AddWithValue("@Amount", txtAmount.Text);
            cmd.Parameters.AddWithValue("@PaymentMethod", txtPaymentMethods.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Records Saved Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadLatestRow(int.Parse(txtBillingNo.Text));
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBillingNo.Text.Trim()))// Bill No Validation
            {
                errorProvider1.SetError(txtBillingNo, "Billing number is required");
                return;
            }
            else
            {
                errorProvider1.SetError(txtBillingNo, string.Empty);
            }

            if (string.IsNullOrEmpty(txtName.Text.Trim())) // Name Validation
            {
                errorProvider2.SetError(txtName, "Name is required");
                return;
            }
            else
            {
                errorProvider2.SetError(txtName, string.Empty);
            }

            if (string.IsNullOrEmpty(txtRegNo.Text.Trim())) //Phone No Validation
            {
                errorProvider3.SetError(txtRegNo, "Registration number is required");
                return;
            }
            else
            {
                errorProvider3.SetError(txtRegNo, string.Empty);
            }

            if (string.IsNullOrEmpty(txtSports.Text.Trim())) //Sport Validation
            {
                errorProvider4.SetError(txtSports, "Selection of sports is required");
                return;
            }
            else
            {
                errorProvider4.SetError(txtSports, string.Empty);
            }

            if (string.IsNullOrEmpty(txtAmount.Text.Trim())) //Amount validation
            {
                errorProvider5.SetError(txtAmount, "Amount is required");
                return;
            }
            else
            {
                errorProvider5.SetError(txtAmount, string.Empty);
            }

            if (string.IsNullOrEmpty(txtPaymentMethods.Text.Trim()))  //Palyment Method VAlidation
            {
                errorProvider6.SetError(txtPaymentMethods, "Selection of payment method is required");
                return;
            }
            else
            {
                errorProvider6.SetError(txtPaymentMethods, string.Empty);
            }

            //Establishing connection
            //SQl Command For Updating database Table
            SqlConnection conn = new SqlConnection(@"Data Source=ADARSH\SQLEXPRESS;Initial Catalog=SportsComplexdb;Integrated Security=True;Encrypt=False;TrustServerCertificate=True");
            conn.Open();//Opening Connection
            SqlCommand cmd = new SqlCommand("update PlayerPaymentTab set PlayerName=@PlayerName,RegNo=@RegNo,Sports=@Sports,Amount=@Amount,PaymentMethod=@PaymentMethod where BillingNo=@BillingNo", conn);
            cmd.Parameters.AddWithValue("@BillingNo", int.Parse(txtBillingNo.Text));
            cmd.Parameters.AddWithValue("@PlayerName", txtName.Text);
            cmd.Parameters.AddWithValue("@RegNo", txtRegNo.Text);
            cmd.Parameters.AddWithValue("@Sports", txtSports.Text);
            cmd.Parameters.AddWithValue("@Amount", txtAmount.Text);
            cmd.Parameters.AddWithValue("@PaymentMethod", txtPaymentMethods.Text);
            cmd.ExecuteNonQuery();
            conn.Close();//Clossing Connection
            MessageBox.Show("Records Updated Successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadLatestRow(int.Parse(txtBillingNo.Text));
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            //Button for reset TextFields To empty
            txtBillingNo.Text = "";
            txtName.Text = "";
            txtRegNo.Text = "";
            txtAmount.Text = "";
            txtPaymentMethods.Text = "";
        }
        private void PlayerPayment_Load(object sender, EventArgs e)
        {
            AutoGenerate();//Function Called In Load of form
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //Formating Styling Bill in Rich Text box
            Bitmap backgroundImage = Properties.Resources.Invoice;
            e.Graphics.DrawImage(backgroundImage, 0, 0, e.PageBounds.Width, e.PageBounds.Height);

            Font font = new Font("Microsoft Sans Serif", 18);
            Brush brush = Brushes.Black;

            int startX = 10;
            int startY = 240;
            int lineHeight = 50;

            startY += lineHeight;
            e.Graphics.DrawString("                                       PAYMENT RECEIEPT                                    ", font, brush, startX, startY);
            startY += lineHeight;
            e.Graphics.DrawString("******************************************************************************************", font, brush, startX, startY);

            startY += lineHeight;
            e.Graphics.DrawString("Date: " + DateTime.Now.ToString(), font, brush, startX, startY);
            startY += lineHeight;


            e.Graphics.DrawString("Bill No: " + txtBillingNo.Text, font, brush, startX, startY);
            startY += lineHeight;
            e.Graphics.DrawString("Registration No: " + txtRegNo.Text, font, brush, startX, startY);
            startY += lineHeight;
            e.Graphics.DrawString("Player Name: " + txtName.Text, font, brush, startX, startY);
            startY += lineHeight;
            e.Graphics.DrawString("Sports: " + txtSports.Text, font, brush, startX, startY);
            startY += lineHeight;
            e.Graphics.DrawString("Payment Method: " + txtPaymentMethods.Text, font, brush, startX, startY);
            startY += lineHeight;
            e.Graphics.DrawString("Amount: " + txtAmount.Text, font, brush, startX, startY);
            startY += lineHeight;
            
            e.Graphics.DrawString("Signature:", font, brush, startX, startY);
        }

        private void btnGenBill_Click(object sender, EventArgs e)
        {
            //Button TO Format bill and GEnerate bill
            txtResult.Clear();
            txtResult.Text += "***************************************************************************\n";
            txtResult.Text += "                               PAYMENT RECEIEPT                            \n";
            txtResult.Text += "***************************************************************************\n";
            txtResult.Text += "Date:"+ DateTime.Now+"\n\n";


            txtResult.Text += "Bill No: " + txtBillingNo.Text + "\n\n";
            txtResult.Text += "Registration No: " + txtRegNo.Text + "\n\n";
            txtResult.Text += "Player Name: " + txtName.Text + "\n\n";
            txtResult.Text += "Sports: " + txtSports.Text + "\n\n";
            txtResult.Text += "Payment Method: " + txtPaymentMethods.Text + "\n\n";
            txtResult.Text += "Amount: " + txtAmount.Text + "\n\n";

            txtResult.Text += "\n                 Signature:";
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //button To print bill in documentation format
            PrintPreviewDialog previewDialog = new PrintPreviewDialog();
            previewDialog.Document = printDocument1;
            previewDialog.ShowDialog();
        }
        public void AutoGenerate()//function to Auto generate Billno 
        {
            //Establishing Connection
            SqlConnection conn = new SqlConnection(@"Data Source=ADARSH\SQLEXPRESS;Initial Catalog=SportsComplexdb;Integrated Security=True;Encrypt=False;TrustServerCertificate=True");
            // If no records exist, it defaults to 1 (using ISNULL to handle null values)
            SqlDataAdapter adp = new SqlDataAdapter("select isnull(max(cast(BillingNo as int)),0)+1 from PlayerPaymentTab", conn);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            txtBillingNo.Text = dt.Rows[0][0].ToString();//Assinging Auto Generated Data to text box
        }

        private void btnSearch_Click(object sender, EventArgs e)//button to search from database 
        {
            //Establishing connection
            SqlConnection conn = new SqlConnection(@"Data Source=ADARSH\SQLEXPRESS;Initial Catalog=SportsComplexdb;Integrated Security=True;Encrypt=False;TrustServerCertificate=True");
            conn.Open();//opening connection
            //SQL Command for Search Player Name for database
            SqlCommand cmd = new SqlCommand("select * from PlayerPaymentTab where PlayerName like @PlayerName +'%'", conn);
            cmd.Parameters.AddWithValue("@PlayerName", txtSearch.Text.Trim());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)// Check if any search is found or not
            {
                dataGridView1.DataSource = dt;
            }
            else
            {
                MessageBox.Show("No Record Found!!!");
                dataGridView1.DataSource = null;
            }
        }
        private void LoadLatestRow(int BillingNo)//function to displaying latest Row in dataGrid View
        {
            //Establishing connection
            using (SqlConnection conn = new SqlConnection(@"Data Source=ADARSH\SQLEXPRESS;Initial Catalog=SportsComplexdb;Integrated Security=True;Encrypt=False;TrustServerCertificate=True"))
            {
                conn.Open();//opening connection
                //SQl Command for Accessing latest updated row
                SqlCommand cmd = new SqlCommand("SELECT * FROM PlayerPaymentTab Where BillingNo = @BillingNo", conn);
                cmd.Parameters.AddWithValue("@BillingNo", BillingNo);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();//Clearing DataGridview
                dataGridView1.DataSource = dt;//Storing in DataGrid View
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Main mm = new Main();// Redirecting to Main page
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
