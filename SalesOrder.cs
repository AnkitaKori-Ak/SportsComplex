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
using System.Xml.Linq;
using System.Drawing.Printing;
using System.Text.RegularExpressions;
using CrystalDecisions.Shared;

namespace SportsComplex
{
    public partial class SalesOrder : Form
    {
        public SalesOrder()
        {
            InitializeComponent();
            CustomizeDataGridView(ProductGV);
            CustomizeDataGridView(orderGridView2);
        }
        public class Order
        {
            // The Order class represents the details of a single order in the sales system.
            public int Num { get; set; }
            public string Product { get; set; }
            public int Quantity { get; set; }
            public decimal UnitPrice { get; set; }
            public decimal TotalPrice { get; set; }
        }
        public void DisplayProdDetails()
        {
            // Displays products from AccessoriesTab in the ProductGV
            this.accessoriesTabTableAdapter.Fill(this.sportsComplexdbDataSet.AccessoriesTab);
            //Establishing Connection
            SqlConnection conn = new SqlConnection(@"Data Source=ADARSH\SQLEXPRESS;Initial Catalog=SportsComplexdb;Integrated Security=True;Encrypt=False;TrustServerCertificate=True");
            conn.Open(); //opening Connection
            //SQl Command to Display All product data in Gried View
            SqlCommand cmd = new SqlCommand("Select * from AccessoriesTab", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ProductGV.DataSource = dt;//Storing fetched row in data Gridview
        }
        public void UpdateProdDetails()
        {
            //Establishing Connecton
            SqlConnection conn = new SqlConnection(@"Data Source=ADARSH\SQLEXPRESS;Initial Catalog=SportsComplexdb;Integrated Security=True;Encrypt=False;TrustServerCertificate=True");
            conn.Open();//Opening Connection
            //SQL Command to update the Quantity in Accessories Table
            SqlCommand cmd = new SqlCommand("update AccessoriesTab set Quantity = Quantity - @OrderQty Where AccessoriesId=@AccessoriesId", conn);
            cmd.Parameters.AddWithValue("@AccessoriesId", productID);
            cmd.Parameters.AddWithValue("OrderQty", qty);
            cmd.ExecuteNonQuery();
            conn.Close();//closing connection
            MessageBox.Show("Records Updated Successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SalesOrder_Load(object sender, EventArgs e)
        {
            AutoGenerateCustId();//on load ofform function is Called to Auto Generate Customer ID
            AutoGenerateOrderId();//on load ofform function is Called to Auto generate Order ID
        }

        private BindingList<Order> orderList = new BindingList<Order>();
        private int num = 0;
        private string product;
        private int uprice;
        private int StockQTY;
        private int productID;
        private int qty;
        private int totprice;
        private int flag = 0;
        private int sum = 0;
        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            // int sum = 0;
            if (string.IsNullOrWhiteSpace(txtQuantity.Text))// Quantity Validation
            {
                MessageBox.Show("Enter The Quantity Of Products");
                return;
            }

            if (flag == 0)
            {
                MessageBox.Show("Select The Product");
                return;
            }

            try
            {
                qty = Convert.ToInt32(txtQuantity.Text);    //Converting Quantity into Integer


                if (qty > StockQTY || qty <= 0)     //Checking if Stock is Available or not
                {
                    MessageBox.Show("Insufficient stock. You have left: " + StockQTY + ". Please refill stock.");
                    return; // Exit if quantity is not valid
                }

                totprice = qty * uprice;
                MessageBox.Show("Total price is: " + totprice); //Calculating total price of item
                num++;

                orderList.Add(new Order
                {
                    //order list item which neet to be display in DataGridView
                    Num = num,
                    Product = product,
                    Quantity = qty,
                    UnitPrice = uprice,
                    TotalPrice = totprice
                });
                orderGridView2.DataSource = orderList;
                flag = 0;
                sum = sum + totprice;
                txtTotalAmt.Text = sum.ToString();
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid number for quantity.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
            UpdateProdDetails();
            DisplayProdDetails();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //Establishing Connection
            SqlConnection conn = new SqlConnection(@"Data Source=ADARSH\SQLEXPRESS;Initial Catalog=SportsComplexdb;Integrated Security=True;Encrypt=False;TrustServerCertificate=True");
            conn.Open();//opening Connection
            //SQL Command for Searching from databAse
            SqlCommand cmd = new SqlCommand("select * from AccessoriesTab where Category like @Category +'%'", conn);
            cmd.Parameters.AddWithValue("@Category", txtcategories.Text.Trim());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)//Checking if the Search element is Found
            {
                ProductGV.DataSource = dt;//if Found store it in DataGridView
            }
            else
            {
                MessageBox.Show("No Record Found!!!");//message box if not found
                ProductGV.DataSource = null;
            }
        }

        private void ProductGV_MouseClick(object sender, MouseEventArgs e)//Event on mouse Click
        {

            if (ProductGV.SelectedRows.Count > 0) // Ensure a row is actually selected
            {
                productID = Convert.ToInt32(ProductGV.SelectedRows[0].Cells[0].Value.ToString());
                product = ProductGV.SelectedRows[0].Cells[1].Value.ToString();
                uprice = Convert.ToInt32(ProductGV.SelectedRows[0].Cells[3].Value.ToString());
                StockQTY = Convert.ToInt32(ProductGV.SelectedRows[0].Cells[2].Value.ToString());

                flag = 1; // Mark product as selected
            }
            else
            {
                MessageBox.Show("Please select a product.");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            AutoGenerateCustId();
            if (string.IsNullOrEmpty(txtCustomerID.Text.Trim())) //Customer ID validation
            {
                errorProvider1.SetError(txtCustomerID, " Customer id is required");
                return;
            }
            else
            {
                errorProvider1.SetError(txtCustomerID, string.Empty);
            }

            if (string.IsNullOrEmpty(txtCustomerName.Text.Trim())) //Customer Name Validation
            {
                errorProvider2.SetError(txtCustomerName, "Customer name is required");
                return;
            }
            else
            {
                errorProvider2.SetError(txtCustomerName, string.Empty);
            }
            if (string.IsNullOrEmpty(txtPhoneNo.Text.Trim()))   //Phoneno Validation
            {
                errorProvider3.SetError(txtPhoneNo, "Mobile number is required");
                return;
            }
            else
            {
                errorProvider3.SetError(txtPhoneNo, string.Empty);
            }

            string mobilePattern = @"^\d{10}$";
            if (!Regex.IsMatch(txtPhoneNo.Text.Trim(), mobilePattern))  //Checkimng if phone no having 10 Digit ot not
            {
                errorProvider3.SetError(txtPhoneNo, "Mobile number must be 10 digits");
                return;
            }
            else
            {
                errorProvider3.SetError(txtPhoneNo, string.Empty);
            }

            if (string.IsNullOrEmpty(txtcategories.Text.Trim()))    //Categories Validation
            {
                errorProvider4.SetError(txtcategories, "Categories is required");
                return;
            }
            else
            {
                errorProvider4.SetError(txtcategories, string.Empty);
            }

            //Esatblishing Connection
            SqlConnection conn = new SqlConnection(@"Data Source=ADARSH\SQLEXPRESS;Initial Catalog=SportsComplexdb;Integrated Security=True;Encrypt=False;TrustServerCertificate=True");
            conn.Open();//opening Connection
            //SQl command for insert Values in Customer Table
            SqlCommand cmd = new SqlCommand("insert into CustomerTab values(@CustomerId,@CustomerName,@PhoneNo)", conn);
            cmd.Parameters.AddWithValue("@CustomerId", int.Parse(txtCustomerID.Text));
            cmd.Parameters.AddWithValue("@CustomerName", txtCustomerName.Text);
            cmd.Parameters.AddWithValue("@PhoneNo", txtPhoneNo.Text);
            cmd.ExecuteNonQuery();
            conn.Close();//closing Connection
            MessageBox.Show("Records Saved Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCustomerID.Text.Trim())) //Customer ID validation
            {
                errorProvider1.SetError(txtCustomerID, " Customer id is required");
                return;
            }
            else
            {
                errorProvider1.SetError(txtCustomerID, string.Empty);
            }

            if (string.IsNullOrEmpty(txtCustomerName.Text.Trim())) //Customer Name Validation
            {
                errorProvider2.SetError(txtCustomerName, "Customer name is required");
                return;
            }
            else
            {
                errorProvider2.SetError(txtCustomerName, string.Empty);
            }
            if (string.IsNullOrEmpty(txtPhoneNo.Text.Trim()))   //Phoneno Validation
            {
                errorProvider3.SetError(txtPhoneNo, "Mobile number is required");
                return;
            }
            else
            {
                errorProvider3.SetError(txtPhoneNo, string.Empty);
            }

            string mobilePattern = @"^\d{10}$";
            if (!Regex.IsMatch(txtPhoneNo.Text.Trim(), mobilePattern))  //Checkimng if phone no having 10 Digit ot not
            {
                errorProvider3.SetError(txtPhoneNo, "Mobile number must be 10 digits");
                return;
            }
            else
            {
                errorProvider3.SetError(txtPhoneNo, string.Empty);
            }

            if (string.IsNullOrEmpty(txtcategories.Text.Trim()))    //Categories Validation
            {
                errorProvider4.SetError(txtcategories, "Categories is required");
                return;
            }
            else
            {
                errorProvider4.SetError(txtcategories, string.Empty);
            }
            //Establishing Connection
            SqlConnection conn = new SqlConnection(@"Data Source=ADARSH\SQLEXPRESS;Initial Catalog=SportsComplexdb;Integrated Security=True;Encrypt=False;TrustServerCertificate=True");
            conn.Open();//opening connection
            //SQl Command For Updating data in Customer Table
            SqlCommand cmd = new SqlCommand("update CustomerTab set CustomerName=@CustomerName,PhoneNo=@PhoneNo where CustomerId=@CustomerId", conn);
            cmd.Parameters.AddWithValue("@CustomerId", int.Parse(txtCustomerID.Text));
            cmd.Parameters.AddWithValue("@CustomerName", txtCustomerName.Text);
            cmd.Parameters.AddWithValue("@PhoneNo", txtPhoneNo.Text);
            cmd.ExecuteNonQuery();
            conn.Close();//Closing Connection
            MessageBox.Show("Records Updated Successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnsaveOrder_Click(object sender, EventArgs e)
        {
            AutoGenerateOrderId();
            if (string.IsNullOrEmpty(txtQuantity.Text.Trim())) //Quantity Validation
            {
                errorProvider5.SetError(txtQuantity, "Quantity id is required");
                return;
            }
            else
            {
                errorProvider5.SetError(txtQuantity, string.Empty);
            }

            if (string.IsNullOrEmpty(txtOrderID.Text.Trim()))   //Order ID VAlidation
            {
                errorProvider6.SetError(txtOrderID, "Order is required");
                return;
            }
            else
            {
                errorProvider6.SetError(txtOrderID, string.Empty);
            }
            if (string.IsNullOrEmpty(txtTotalAmt.Text.Trim()))  //Total Amount VAlidation
            {
                errorProvider7.SetError(txtTotalAmt, "Total Amount is required");
                return;
            }
            else
            {
                errorProvider7.SetError(txtTotalAmt, string.Empty);
            }
            //Establishing Connection
            SqlConnection conn = new SqlConnection(@"Data Source=ADARSH\SQLEXPRESS;Initial Catalog=SportsComplexdb;Integrated Security=True;Encrypt=False;TrustServerCertificate=True");
            conn.Open();//opening Connection
            //SQL Command for insert Values in SalesOrder
            SqlCommand cmd = new SqlCommand("insert into SalesOrderTab values(@OrderId,@product,@OrderDate,@Quantity,@Uprice,@TotalPrice)", conn);
            cmd.Parameters.AddWithValue("@OrderId", int.Parse(txtOrderID.Text));
            cmd.Parameters.AddWithValue("@product", product);
            cmd.Parameters.AddWithValue("@OrderDate", orderDate.Value);
            cmd.Parameters.AddWithValue("@Quantity", qty);
            cmd.Parameters.AddWithValue("@Uprice", uprice);
            cmd.Parameters.AddWithValue("@TotalPrice", totprice);
            cmd.ExecuteNonQuery();
            conn.Close();//Closing Connection
            MessageBox.Show("Records Saved Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void orderDate_VisibleChanged_1(object sender, EventArgs e)
        {
            orderDate.CustomFormat = "dd/MM/yyyy"; //Formate Date
        }

        private void orderDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                orderDate.CustomFormat = " "; // Bacpase key to empty DateField
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Main mm = new Main();//Button Redirect to main Pagee
            mm.Show();
        }

        private void btnPrint_Click(object sender, EventArgs e)//To print the Order Bill
        {
            PrintPreviewDialog previewDialog = new PrintPreviewDialog();
            previewDialog.Document = printDocument1;//printing in Document in 
            previewDialog.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        { 
            
                Bitmap backgroundImage = Properties.Resources.Invoice;
                e.Graphics.DrawImage(backgroundImage, 0, 0, e.PageBounds.Width, e.PageBounds.Height);

                Font font = new Font("Microsoft Sans Serif", 18);
                Brush brush = Brushes.Black;

                int startX = 10;
                int startY = 240;
                int lineHeight = 50;

                startY += lineHeight;
                e.Graphics.DrawString("                                           ORDER RECEIPT                                    ", font, brush, startX, startY);
                startY += lineHeight;
                e.Graphics.DrawString("******************************************************************************************", font, brush, startX, startY);

                startY += lineHeight;
                e.Graphics.DrawString("Date: " + DateTime.Now.ToString(), font, brush, startX, startY);
                startY += lineHeight;
                e.Graphics.DrawString("Order No: " + txtOrderID.Text, font, brush, startX, startY);
                startY += lineHeight;
                e.Graphics.DrawString("******************************************************************************************", font, brush, startX, startY);
                startY += lineHeight;

                Font headerFont = new Font("Microsoft Sans Serif", 14, FontStyle.Bold);
                int headerHeight = 30;
                int columnWidth = e.PageBounds.Width / 4;

                e.Graphics.DrawString("Product Name", headerFont, brush, startX, startY);
                e.Graphics.DrawString("Quantity", headerFont, brush, startX + columnWidth, startY);
                e.Graphics.DrawString("Unit Price", headerFont, brush, startX + 2 * columnWidth, startY);
                e.Graphics.DrawString("Total Amount", headerFont, brush, startX + 3 * columnWidth, startY);

                startY += headerHeight;
                e.Graphics.DrawString("******************************************************************************************", font, brush, startX, startY);

                startY += lineHeight;

                decimal grandTotal = 0; // Initialize grand total

                foreach (DataGridViewRow row in orderGridView2.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        string productName = row.Cells["Product"].Value.ToString();
                        int quantity = Convert.ToInt32(row.Cells["Quantity"].Value);
                        decimal unitPrice = Convert.ToDecimal(row.Cells["UnitPrice"].Value);

                        decimal totalAmount = quantity * unitPrice;
                        grandTotal += totalAmount; // Accumulate to grand total

                        e.Graphics.DrawString(productName, font, brush, startX, startY);
                        e.Graphics.DrawString(quantity.ToString(), font, brush, startX + columnWidth, startY);
                        e.Graphics.DrawString(unitPrice.ToString("C"), font, brush, startX + 2 * columnWidth, startY);
                        e.Graphics.DrawString(totalAmount.ToString("C"), font, brush, startX + 3 * columnWidth, startY);
                        startY += lineHeight;
                    }
                }

                startY += lineHeight; // Move down for Grand Total
                float grandTotalX = e.PageBounds.Width - 370; // Adjust as needed for right positioning
                Font boldFont = new Font("Microsoft Sans Serif", 18, FontStyle.Bold);
                e.Graphics.DrawString("GRAND TOTAL: " + grandTotal.ToString("C"), boldFont, brush, grandTotalX, startY);

               // e.Graphics.DrawString("Grand Total:" + grandTotal.ToString("C"), font, brush, grandTotalX, startY);
                startY += lineHeight;
                e.Graphics.DrawString("******************************************************************************************", font, brush, startX, startY);
                startY += lineHeight;
                e.Graphics.DrawString("Signature:", font, brush, startX, startY);
            


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
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        public void AutoGenerateCustId()//Function to auto generate the Customer ID
        {
            SqlConnection conn = new SqlConnection(@"Data Source=ADARSH\SQLEXPRESS;Initial Catalog=SportsComplexdb;Integrated Security=True;Encrypt=False;TrustServerCertificate=True");
            SqlDataAdapter adp = new SqlDataAdapter("select isnull(max(cast(CustomerID as int)),0)+1 from CustomerTab", conn);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            txtCustomerID.Text= dt.Rows[0][0].ToString();
        }
        public void AutoGenerateOrderId()//Function to Auto generate the Order ID
        {
            SqlConnection conn = new SqlConnection(@"Data Source=ADARSH\SQLEXPRESS;Initial Catalog=SportsComplexdb;Integrated Security=True;Encrypt=False;TrustServerCertificate=True");
            SqlDataAdapter adp = new SqlDataAdapter("select isnull(max(cast(OrderId as int)),0)+1 from SalesOrderTab", conn);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            txtOrderID.Text = dt.Rows[0][0].ToString();
        }
    }

    
}



