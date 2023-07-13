using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NamDinh_QLBN.Forms.In
{
    public partial class frmHuyLanGui : Form
    {
        public frmHuyLanGui()
        {
            InitializeComponent();
        }

        private void cmdNo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            if (cmbLanGui.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn chọn lần gửi.", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void lbThongBao_Click(object sender, EventArgs e)
        {

        }
    }
}