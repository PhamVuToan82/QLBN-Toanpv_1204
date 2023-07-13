using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NamDinh_QLBN.Forms.Tien_ich
{
    public partial class  frmTNgayDNgayByNoiKCBBDAndChuyenBV : Form
    {
        public DateTime _TNgay, _DNgay;
        public string _MaKhoa,_MaBV;
        public string _TenKhoa,_isMaTu,_isMaDen,_TenBV;
        public bool _isNgayVaoVien, _isNgayRaVien,_isTatCa;

        public frmTNgayDNgayByNoiKCBBDAndChuyenBV()
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
                    _MaBV = GlobalModuls.Global.GetCode(cmbBV);
                    _TenKhoa = cmbKhoa.Text;
                    _TenBV = cmbBV.Text.Trim();
                    _isNgayRaVien = raRaVien.Checked;
                    _isNgayVaoVien = raVaoVien.Checked;
                    _isMaTu = txtTu.Text.Replace(" ", "").Trim();
                    _isMaDen = txtDen.Text.Replace(" ", "").Trim();
                    _isTatCa = raTatCa.Checked;
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

                SQLCmd.CommandText = "SELECT * FROM viewDSBenhVien ORDER BY TENBV";
                dr = SQLCmd.ExecuteReader();
                cmbBV.Tag = "0";
                cmbBV.ClearItems();
                cmbBV.AddItem("0;---------------- TẤT CẢ ----------------");
                while (dr.Read())
                {
                    cmbBV.AddItem(string.Format("{0};{1}", dr["MaBV"], dr["TenBV"]));
                }
                cmbBV.SelectedIndex = 0;
                cmbBV.Tag = "1";
                dr.Close();
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
            raBVTinh_CheckedChanged(null, null);
        }

        private void raChiDinh_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void raBVTinh_CheckedChanged(object sender, EventArgs e)
        {
            txtTu.Enabled = txtDen.Enabled = raBVTinh.Checked == true != raTatCa.Checked == true != raTrongHuyen.Checked == true ? false : true;
            if (raBVTinh.Checked)
                txtTu.Text = txtDen.Text = "36001";
            if (raTrongHuyen.Checked)
            {
                txtTu.Text = "36002";
                txtDen.Text = "36999";
            }
        }

        private void raTrongHuyen_CheckedChanged(object sender, EventArgs e)
        {
            raBVTinh_CheckedChanged(null, null);
        }

        private void raTrongKhoang_CheckedChanged(object sender, EventArgs e)
        {
            raBVTinh_CheckedChanged(null, null);
        }

        private void raTatCa_CheckedChanged(object sender, EventArgs e)
        {
            raBVTinh_CheckedChanged(null, null);
        }
    }
}