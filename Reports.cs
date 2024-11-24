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
    public partial class Reports : Form
    {
        public Reports()
        {
            InitializeComponent();
        }

        private void btnSalesOrdCry_Click(object sender, EventArgs e)
        {
            SalesOrderCrystal SOC = new SalesOrderCrystal();
            SOC.Show(); // Button directing to SalesOrderCrystal Report
        }

        private void btnStudCry_Click(object sender, EventArgs e)
        {
            Platerscrystal PCR = new Platerscrystal();
            PCR.Show();// Button directing to Player Crystal Report
        }

        private void btnInvenCry_Click(object sender, EventArgs e)
        {
            InventoryProductCrystal IPC = new InventoryProductCrystal();
            IPC.Show();// Button directing to InventoryCrystal Report
        }

        private void btnFacuCry_Click(object sender, EventArgs e)
        {
            FacultyCrystal FC  = new FacultyCrystal();
            FC.Show(); // Button directing to FacultyCrystal Report
        }

        private void btnSuppCry_Click(object sender, EventArgs e)
        {
            SupplierCrystal SC = new SupplierCrystal();
            SC.Show();// Button directing to SupplierCrystal Report
        }

        private void btnStudPayCry_Click(object sender, EventArgs e)
        {
            PlayerPaymentCrystal PPC = new PlayerPaymentCrystal();
            PPC.Show();// Button directing to PlayerPAYMENTCrystal Report

        }

        private void BtnEveCry_Click(object sender, EventArgs e)
        {
            EventCrystal ECY = new EventCrystal();
            ECY.Show();// Button directing to EventCrystal Report
        }

        private void btnSuppPayCry_Click(object sender, EventArgs e)
        {
            SuppPaymentCrystal SPC = new SuppPaymentCrystal();
            SPC.Show();// Button directing to SalesPaymentCrystal Report
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Main mm = new Main();//Button Redirecting to Main page
            mm.Show();
        }
    }
}
