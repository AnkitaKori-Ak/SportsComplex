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
    public partial class EventCrystal : Form
    {
        public EventCrystal()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            EventCry1.Refresh(); // Refeshing Cristal Reports For updated Data
        }
    }
}
