using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NamDinh_QLBN.Forms.Tien_ich
{
    public partial class   frmTNgayDNgayBySoPhieu : Form
    {
        public string _MaKhoa,_SoPhieuTu,_SoPhieuDen;
        public string _TenKhoa;

        public frmTNgayDNgayBySoPhieu()
        {
            InitializeComponent();
        }

        private void cmdThoat_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void cmbKhongGhi_Click(object sender, EventArgs e)
        {
            if (cmbKhoa.SelectedIndex == -1)
            {
                MessageBox.Show("Chọn khoa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbKhoa.Focus();
                this.DialogResult = DialogResult.Retry;
            }
            else
            {
                if (txtSoPhieuTu.Text.Trim().Replace("/","") == "D" || txtSoPhieuDen.Text.Trim().Replace("/","") == "D")
                {
                    MessageBox.Show("Nhập số phiếu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.Retry;
                }
                else
                {
                    _SoPhieuTu = txtSoPhieuTu.Text.Trim().Replace("/","").Substring(1, txtSoPhieuTu.Text.Trim().Replace("/","").Length -1);
                    _SoPhieuDen = txtSoPhieuDen.Text.Trim().Replace("/", "").Substring(1, txtSoPhieuDen.Text.Trim().Replace("/", "").Length - 1);
                    _MaKhoa = GlobalModuls.Global.GetCode(cmbKhoa);
                    _TenKhoa = cmbKhoa.Text;
                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        private void LoatDanhMuc()
        {
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            try
            {
                SQLCmd.CommandText = "SELECT * FROM DMKHOAPHONG WHERE MaKhoa IN " + GlobalModuls.Global.glbKhoa_CapNhat;
                dr = SQLCmd.ExecuteReader();
                cmbKhoa.Tag = "0";
                cmbKhoa.ClearItems();
                while (dr.Read())
                {
                    cmbKhoa.AddItem(string.Format("{0};{1}", dr["MaKhoa"], dr["TenKhoa"]));
                }
                cmbKhoa.SelectedIndex = 0;
                dr.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                SQLCmd.Dispose();
            }
        }

        private void frmTNgayDNgay_Load(object sender, EventArgs e)
        {
            LoatDanhMuc();
        }
    }
}