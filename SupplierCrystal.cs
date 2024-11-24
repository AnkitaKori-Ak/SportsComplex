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
    public partial class SupplierCrystal : Form
    {
        public SupplierCrystal()
        {
            InitializeComponent();
        }

        private void SupplierCrystal_Load(object sender, EventArgs e)
        {
            SupplierCry1.Refresh();
        }
    }
}
