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
    public partial class SupplierPayment : Form
    {
        public SupplierPayment()
        {
            InitializeComponent();
            CustomizeDataGridView(dataGridView1);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            AutoGenerate();
            if (string.IsNullOrEmpty(txtSuppID.Text.Trim())) //Validation SupplierID
            {
                errorProvider1.SetError(txtSuppID, "Supplier id is required");
                return;
            }
            else
            {
                errorProvider1.SetError(txtSuppID, string.Empty);
            }

            if (string.IsNullOrEmpty(txtSuppName.Text.Trim()))  //SupplierName Validation
            {
                errorProvider2.SetError(txtSuppName, "Supplier name is required");
                return;
            }
            else
            {
                errorProvider2.SetError(txtSuppName, string.Empty);
            }

            if (string.IsNullOrEmpty(txtcompanyName.Text.Trim()))   //Comapany Name Validation
            {
                errorProvider3.SetError(txtcompanyName, "Company name is required");
                return;
            }
            else
            {
                errorProvider3.SetError(txtcompanyName, string.Empty);
            }

            if (string.IsNullOrEmpty(txtAddress.Text.Trim()))   //Address Validation
            {
                errorProvider4.SetError(txtAddress, "Address is required");
                return;
            }
            else
            {
                errorProvider4.SetError(txtAddress, string.Empty);
            }

            if (string.IsNullOrEmpty(txtEmail.Text.Trim())) //Email Validation
            {
                errorProvider5.SetError(txtEmail, "Email is required");
                return;
            }
            else
            {
                errorProvider5.SetError(txtEmail, string.Empty);
            }

            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(txtEmail.Text.Trim(), emailPattern)) //Validate Email Checking @
            {
                errorProvider5.SetError(txtEmail, "Invalid email format");
                return;
            }
            else
            {
                errorProvider5.SetError(txtEmail, string.Empty);
            }

            if (string.IsNullOrEmpty(txtPaymentMethod.Text.Trim())) //Payment Method Validation
            {
                errorProvider6.SetError(txtPaymentMethod, "Selection of payment method is required");
                return;
            }
            else
            {
                errorProvider6.SetError(txtPaymentMethod, string.Empty);
            }

            if (string.IsNullOrEmpty(txtPaymentAmount.Text.Trim())) //Payment Amount validation
            {
                errorProvider7.SetError(txtPaymentAmount, "Amount is required");
                return;
            }
            else
            {
                errorProvider7.SetError(txtPaymentAmount, string.Empty);
            }
            //Eshtablish Connection
            SqlConnection conn = new SqlConnection(@"Data Source=ADARSH\SQLEXPRESS;Initial Catalog=SportsComplexdb;Integrated Security=True;Encrypt=False;TrustServerCertificate=True");
            conn.Open();//Connection open
            //Sql Commmand to insert value in table
            SqlCommand cmd = new SqlCommand("insert into SupplierPaymentTab values(@SupplierId,@SupplierName,@CompanyName,@Address,@Email,@PaymentMethods,@PaymentAmount)", conn);
            cmd.Parameters.AddWithValue("@SupplierId", int.Parse(txtSuppID.Text));
            cmd.Parameters.AddWithValue("@SupplierName", txtSuppName.Text);
            cmd.Parameters.AddWithValue("@CompanyName", txtcompanyName.Text);
            cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
            cmd.Parameters.AddWithValue("@PaymentMethods", txtPaymentMethod.Text);
            cmd.Parameters.AddWithValue("@PaymentAmount", txtPaymentAmount.Text);
            cmd.ExecuteNonQuery();
            conn.Close();//Closing Connection
            MessageBox.Show("Records Saved Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadLatestRow(int.Parse(txtSuppID.Text));
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSuppID.Text.Trim())) //Validation SupplierID
            {
                errorProvider1.SetError(txtSuppID, "Supplier id is required");
                return;
            }
            else
            {
                errorProvider1.SetError(txtSuppID, string.Empty);
            }

            if (string.IsNullOrEmpty(txtSuppName.Text.Trim()))  //SupplierName Validation
            {
                errorProvider2.SetError(txtSuppName, "Supplier name is required");
                return;
            }
            else
            {
                errorProvider2.SetError(txtSuppName, string.Empty);
            }

            if (string.IsNullOrEmpty(txtcompanyName.Text.Trim()))   //Comapany Name Validation
            {
                errorProvider3.SetError(txtcompanyName, "Company name is required");
                return;
            }
            else
            {
                errorProvider3.SetError(txtcompanyName, string.Empty);
            }

            if (string.IsNullOrEmpty(txtAddress.Text.Trim()))   //Address Validation
            {
                errorProvider4.SetError(txtAddress, "Address is required");
                return;
            }
            else
            {
                errorProvider4.SetError(txtAddress, string.Empty);
            }

            if (string.IsNullOrEmpty(txtEmail.Text.Trim())) //Email Validation
            {
                errorProvider5.SetError(txtEmail, "Email is required");
                return;
            }
            else
            {
                errorProvider5.SetError(txtEmail, string.Empty);
            }

            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(txtEmail.Text.Trim(), emailPattern)) //Validate Email Checking @
            {
                errorProvider5.SetError(txtEmail, "Invalid email format");
                return;
            }
            else
            {
                errorProvider5.SetError(txtEmail, string.Empty);
            }

            if (string.IsNullOrEmpty(txtPaymentMethod.Text.Trim())) //Payment Method Validation
            {
                errorProvider6.SetError(txtPaymentMethod, "Selection of payment method is required");
                return;
            }
            else
            {
                errorProvider6.SetError(txtPaymentMethod, string.Empty);
            }

            if (string.IsNullOrEmpty(txtPaymentAmount.Text.Trim())) //Payment Amount validation
            {
                errorProvider7.SetError(txtPaymentAmount, "Amount is required");
                return;
            }
            else
            {
                errorProvider7.SetError(txtPaymentAmount, string.Empty);
            }
            //Eshtablish COnnection
            SqlConnection conn = new SqlConnection(@"Data Source=ADARSH\SQLEXPRESS;Initial Catalog=SportsComplexdb;Integrated Security=True;Encrypt=False;TrustServerCertificate=True");
            conn.Open();//Connection open
            //Sql Command to update in table of Supplier Payment
            SqlCommand cmd = new SqlCommand("update SupplierPaymentTab set SupplierName=@SupplierName,CompanyName=@CompanyName,Address=@Address,Email=@Email,PaymentAmount=@PaymentAmount,PaymentMethods=@PaymentMethods where SupplierId=@SupplierId", conn);
            cmd.Parameters.AddWithValue("@SupplierId", int.Parse(txtSuppID.Text));
            cmd.Parameters.AddWithValue("@SupplierName", txtSuppName.Text);
            cmd.Parameters.AddWithValue("@CompanyName", txtcompanyName.Text);
            cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
            cmd.Parameters.AddWithValue("@PaymentMethods", txtPaymentMethod.Text);
            cmd.Parameters.AddWithValue("@PaymentAmount", txtPaymentAmount.Text);
            cmd.ExecuteNonQuery();
            conn.Close();//Closing Connection
            MessageBox.Show("Records Updated Successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadLatestRow(int.Parse(txtSuppID.Text));
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            //Reset button to empty all the textfields
            txtSuppID.Text = "";
            txtSuppName.Text = "";
            txtcompanyName.Text = "";
            txtAddress.Text = "";
            txtEmail.Text = "";
            txtPaymentMethod.Text = "";
            txtPaymentAmount.Text = "";

        }

        private void SupplierPayment_Load(object sender, EventArgs e)
        {
            AutoGenerate();//function call at time of load of Form
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            
            Bitmap backgroundImage = Properties.Resources.Invoice; 
            e.Graphics.DrawImage(backgroundImage, 0, 0, e.PageBounds.Width, e.PageBounds.Height);

            Font font = new Font("Microsoft Sans Serif", 18);
            Brush brush = Brushes.Black;

            int startX = 10;
            int startY = 240;
            int lineHeight = 50; 

            startY += lineHeight;
            e.Graphics.DrawString("                                         SUPPLIER INVOICE                                     ", font, brush, startX, startY);
            startY += lineHeight;
            e.Graphics.DrawString("******************************************************************************************", font, brush, startX, startY);
            
            startY += lineHeight;
            e.Graphics.DrawString("Date: " + DateTime.Now.ToString(), font, brush, startX, startY);
            startY += lineHeight;

           
            e.Graphics.DrawString("Supplier Id: " + txtSuppID.Text, font, brush, startX, startY);
            startY += lineHeight;
            e.Graphics.DrawString("Supplier Name: " + txtSuppName.Text, font, brush, startX, startY);
            startY += lineHeight;
            e.Graphics.DrawString("Company Name: " + txtcompanyName.Text, font, brush, startX, startY);
            startY += lineHeight;
            e.Graphics.DrawString("Address: " + txtAddress.Text, font, brush, startX, startY);
            startY += lineHeight;
            startY += lineHeight;
            e.Graphics.DrawString("Email: " + txtEmail.Text, font, brush, startX, startY);
            startY += lineHeight;
            e.Graphics.DrawString("Payment Method: " + txtPaymentMethod.Text, font, brush, startX, startY);
            startY += lineHeight;
            e.Graphics.DrawString("Amount: " + txtPaymentAmount.Text, font, brush, startX, startY);
            startY += lineHeight;

            e.Graphics.DrawString("Signature:", font, brush, startX, startY);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            
            PrintPreviewDialog previewDialog = new PrintPreviewDialog();
            previewDialog.Document = printDocument1;//printing the bill in document form
            previewDialog.ShowDialog();
        }

        private void btnGenerateBill_Click(object sender, EventArgs e)//button to format and generate the bill
        {
            txtResult.Clear();
            txtResult.Text += "***************************************************************************\n";
            txtResult.Text += "                                 SUPPLIER INVOICE                            \n";
            txtResult.Text += "***************************************************************************\n";
            txtResult.Text += "Date:" + DateTime.Now + "\n\n";

            txtResult.Text += "Supplier Id: " + txtSuppID.Text + "\n\n";
            txtResult.Text += "Supplier Name: " + txtSuppName.Text + "\n\n";
            txtResult.Text += "Company Name: " + txtcompanyName.Text + "\n\n";
            txtResult.Text += "Address: " + txtAddress.Text + "\n\n";
            txtResult.Text += "Email: " + txtEmail.Text + "\n\n";
            txtResult.Text += "Payment Method: " + txtPaymentMethod.Text + "\n\n";
            txtResult.Text += "Amount: " + txtPaymentAmount.Text + "\n\n";


            txtResult.Text += "\n                 Signature:";

        }
        public void AutoGenerate()//function to auto generate the Supplier Id
        {
            //Establish Connection
            SqlConnection conn = new SqlConnection(@"Data Source=ADARSH\SQLEXPRESS;Initial Catalog=SportsComplexdb;Integrated Security=True;Encrypt=False;TrustServerCertificate=True");
            // If no records exist, it defaults to 1 (using ISNULL to handle null values)
            SqlDataAdapter adp = new SqlDataAdapter("select isnull(max(cast(SupplierId as int)),0)+1 from SupplierPaymentTab", conn);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            txtSuppID.Text = dt.Rows[0][0].ToString();//storing auto generated to Text box 
        }

        private void btnSearch_Click(object sender, EventArgs e)//function to search elemnet
        {
            //Eshtablish connection
            SqlConnection conn = new SqlConnection(@"Data Source=ADARSH\SQLEXPRESS;Initial Catalog=SportsComplexdb;Integrated Security=True;Encrypt=False;TrustServerCertificate=True");
            conn.Open();//connection open
            //sql Command for searching form database
            SqlCommand cmd = new SqlCommand("select * from SupplierPaymentTab where SupplierName like @SupplierName +'%'", conn);
            cmd.Parameters.AddWithValue("@SupplierName", txtSearch.Text.Trim());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)//cheking if search is available or not 
            {
                dataGridView1.DataSource = dt;//storing found item in data gridview
            }
            else
            {
                MessageBox.Show("No Record Found!!!");
                dataGridView1.DataSource = null;
            }
        }
        private void LoadLatestRow(int SupplierId)//Function to display latest updated row in datagrid View
        {
            //Eshtablishing connection
            using (SqlConnection conn = new SqlConnection(@"Data Source=ADARSH\SQLEXPRESS;Initial Catalog=SportsComplexdb;Integrated Security=True;Encrypt=False;TrustServerCertificate=True"))
            {
                conn.Open();//connection open
                SqlCommand cmd = new SqlCommand("SELECT * FROM SupplierPaymentTab Where SupplierId = @SupplierId", conn);
                cmd.Parameters.AddWithValue("@SupplierId", SupplierId);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();//Clearing dataGridview
                dataGridView1.DataSource = dt;//storing updated Row in datagridview
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Main mm = new Main();//button which redirect to main page
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
