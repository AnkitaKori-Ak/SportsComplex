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
    public partial class SuppPaymentCrystal : Form
    {
        public SuppPaymentCrystal()
        {
            InitializeComponent();
        }

        private void SuppPaymentCrystal_Load(object sender, EventArgs e)
        {
            SupplierPaymentCry1.Refresh();
        }
    }
}
