using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NamDinh_QLBN.Forms.DuLieu
{
    public partial class frmChuanDoan : Form
    {
        public bool Flag = false;

        public frmChuanDoan()
        {
            InitializeComponent();
        }

        private void cmdGhi_Click(object sender, EventArgs e)
        {
            Flag = false;
            if (txtICD_KhoaDT.Text == "")
            {
                MessageBox.Show("Nhập chẩn đoán đi câm lâm sàn", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Flag = true;
            this.Close();
        }

        private void frmChuanDoan_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void frmChuanDoan_Load(object sender, EventArgs e)
        {
            Flag = false;
            txtICD_KhoaDT.Focus();
        }
    }
}