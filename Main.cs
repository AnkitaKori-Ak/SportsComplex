using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SportsComplex
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            SetButtonStyles();
        }
            private void SetButtonStyles() //Styling buttion to Flat
            {
                SetButtonFlatStyle(button1);
                SetButtonFlatStyle(button2);
                SetButtonFlatStyle(button3);
                SetButtonFlatStyle(button4);
                SetButtonFlatStyle(button5);
                SetButtonFlatStyle(button6);
                SetButtonFlatStyle(button7);
                SetButtonFlatStyle(button8);
                SetButtonFlatStyle(button9);
                SetButtonFlatStyle(button10);
                SetButtonFlatStyle(button11);
                SetButtonFlatStyle(button12);
                SetButtonFlatStyle(button13);
                SetButtonFlatStyle(button14);
            }

            private void SetButtonFlatStyle(Button button)
            {
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderSize = 0;
                button.BackColor = Color.FromArgb(240, 240, 240); // Change to your desired background color
                button.ForeColor = Color.Black; // Change to your desired text color
                button.BackColor = button.Name == "button11" || button.Name == "button14" ? Color.MediumBlue : Color.Turquoise;
                button.ForeColor = button.Name == "button11" || button.Name == "button14" ? Color.White : Color.Black;
        }


        private void button1_Click(object sender, EventArgs e)
            {
                Sports_Admission SA = new Sports_Admission();
                SA.Show();  //Button which direct to SportS Admission form
                this.Close();
            }

            private void button2_Click(object sender, EventArgs e)
            {
                PlayerPayment PP = new PlayerPayment();
                PP.Show();  //Button which direct to Player Playment form
                this.Close();
            }

            private void button3_Click(object sender, EventArgs e)
            {
                SupplierDetails SD = new SupplierDetails();
                SD.Show();  //Button which direct to Supplier Details form
                this.Close();
            }

            private void button4_Click(object sender, EventArgs e)
            {
                SupplierPayment SP = new SupplierPayment();
                SP.Show();  //Button which direct to Supplier Payment form
                this.Close();
            }

            private void button5_Click(object sender, EventArgs e)
            {
                ProductInventory PI = new ProductInventory();
                PI.Show();  //Button which direct to Inventory form
                this.Close();
            }

            private void button6_Click(object sender, EventArgs e)
            {
                BatchDetails BD = new BatchDetails();
                BD.Show();  //Button which direct to Batch form
            this.Close();
            }

            private void button7_Click(object sender, EventArgs e)
            {
                SportsFaculty SF = new SportsFaculty();
                SF.Show();  //Button which direct to SportS Facutly form
            this.Close();
            }

            private void button8_Click(object sender, EventArgs e)
            {
                Events EV = new Events();
                EV.Show();  // button Which Direct to Event Form
                this.Close();
            }

            private void button9_Click(object sender, EventArgs e)
            {
                SalesOrder SO = new SalesOrder();
                SO.Show();  //Button which direct to SaleOrder form
            this.Close();
            }

            private void button10_Click(object sender, EventArgs e)
            {
                Maintenace_Repair MR = new Maintenace_Repair();
                MR.Show();  //Button which direct to Maintenance & Repair form
            this.Close();
            }

            private void button11_Click(object sender, EventArgs e)
            {
                Application.Exit(); //Button which log out Exit from Application
        }

            private void button12_Click(object sender, EventArgs e)
            {
                Reports IN = new Reports();
                IN.Show();  //Button which direct to Reports form
            this.Close();
            }

            private void button13_Click(object sender, EventArgs e)
            {
                SportsClubs SC = new SportsClubs();
                SC.Show();  //Button which direct to Sports Club form
            this.Close();
            }
        private void button14_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();  //Button which Redirect to Login form
            this.Close();
        }
    }

    }
