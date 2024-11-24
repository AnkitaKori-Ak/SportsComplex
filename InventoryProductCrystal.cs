using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace SportsComplex
{
    public partial class InventoryProductCrystal : Form
    {
        public InventoryProductCrystal()
        {
            InitializeComponent();
        }

        private void InventoryProductCrystal_Load(object sender, EventArgs e)
        {
            InventoryProductCry1.Refresh();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
