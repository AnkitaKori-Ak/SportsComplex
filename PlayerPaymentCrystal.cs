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
    public partial class PlayerPaymentCrystal : Form
    {
        public PlayerPaymentCrystal()
        {
            InitializeComponent();
        }

        private void PlayerPaymentCrystal_Load(object sender, EventArgs e)
        {
            PlayerPaymentCry1.Refresh();
        }
    }
}
