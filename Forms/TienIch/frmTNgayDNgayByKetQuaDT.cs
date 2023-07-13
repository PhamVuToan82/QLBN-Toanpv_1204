using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NamDinh_QLBN.Forms.Tien_ich
{
    public partial class  frmTNgayDNgayByKetQuaDT : Form
    {
        public DateTime _TNgay, _DNgay;
        public string _MaKhoa,_KetQDT;
        public string _TenKhoa;
        public bool _isRaVien =false,_isNgayVV = false;

        public frmTNgayDNgayByKetQuaDT()
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
                if (txtDNgay.ValueIsDbNull == true || txtTNgay.ValueIsDbNull == true)
                {
                    MessageBox.Show("Chọn ngày", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.Retry;
                }
                else
                {
                    _TNgay = (DateTime)txtTNgay.Value;
                    _DNgay = (DateTime)txtDNgay.Value;
                    _MaKhoa = GlobalModuls.Global.GetCode(cmbKhoa);
                    _TenKhoa = cmbKhoa.Text;
                    _KetQDT = GlobalModuls.Global.GetCode(cmbKetQDT);
                    _isRaVien = raRaVien.Checked;
                    _isNgayVV = raNgayVV.Checked;
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
                cmbKhoa.Tag = "1";
                SQLCmd.CommandText = "SELECT * FROM DMKETQUADT";
                dr = SQLCmd.ExecuteReader();
                cmbKetQDT.Tag = "0";
                cmbKetQDT.ClearItems();
                cmbKetQDT.AddItem("0;---------------- TẤT CẢ ----------------");
                while (dr.Read())
                {
                    cmbKetQDT.AddItem(string.Format("{0};{1}", dr["MaKQDT"], dr["TenKQDT"]));
                }
                cmbKetQDT.SelectedIndex = 0;
                dr.Close();
                cmbKetQDT.Tag = "1";
                txtTNgay.Value = txtDNgay.Value = GlobalModuls.Global.GetNgayLV();
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
            raDangDT_CheckedChanged(null, null);
        }

        private void raDangDT_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void raRaVien_CheckedChanged(object sender, EventArgs e)
        {
            raDangDT_CheckedChanged(null, null);
        }

        private void raNgayVV_CheckedChanged(object sender, EventArgs e)
        {
            raDangDT_CheckedChanged(null, null);
        }
    }
}