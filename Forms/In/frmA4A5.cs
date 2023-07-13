using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NamDinh_QLBN.Forms.In
{
    public partial class frmA4A5 : Form
    {
        public bool A4 ;
        public frmA4A5()
        {
            InitializeComponent();
        }

        private void cmdThoat_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void cmbChon_Click(object sender, EventArgs e)
        {
            if (raA4.Checked == true)
            {
                A4 = true;
            }
            else
            {
                A4 = false;
            }
            this.DialogResult = DialogResult.Yes;
        }
    }
}