﻿using System;
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
    public partial class SalesOrderCrystal : Form
    {
        public SalesOrderCrystal()
        {
            InitializeComponent();
        }

        private void crystalReportViewer2_Load(object sender, EventArgs e)
        {

        }

        private void SalesOrderCrystal_Load(object sender, EventArgs e)
        {
            SalesOrderCry1.Refresh();
        }
    }
}