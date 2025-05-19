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
    public partial class FacultyCrystal : Form
    {
        public FacultyCrystal()
        {
            InitializeComponent();
        }

        private void FacultyCrystal_Load(object sender, EventArgs e)
        {
            FacultyCry1.Refresh();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
