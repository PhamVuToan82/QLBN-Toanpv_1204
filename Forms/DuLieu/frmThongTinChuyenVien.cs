using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NamDinh_QLBN.Forms.DuLieu
{
    public partial class frmThongTienChuyenVien : Form
    {
        frmBenhNhanRaVien _frm;
        string lamsang = "";
        string ChanDoan = "";
        string NguoiChuyen = "";
        string PhuongTien = "";
        string Thuoc = "";
        string TinhTrangBN = "";
        string XetNghiem = "";
        string DuDK = "";
        string ChuyenTheoYC = "";

        public frmThongTienChuyenVien(frmBenhNhanRaVien frm)
        {
            InitializeComponent();
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            SQLCmd.CommandText = "SELECT * FROM viewDSBenhVien order by TenBV";
            dr = SQLCmd.ExecuteReader();
            cmbDSBenhVien.ClearItems();
            while (dr.Read())
            {
                cmbDSBenhVien.AddItem(string.Format("{0};{1}", dr["MaBV"], dr["TenBV"]));
            }
            dr.Close();
            SQLCmd.CommandText = string.Format("SELECT * FROM DMBACSY WHERE DMBACSY.MAKHOA in {0} and Khongsudung = 0 order by TenBS", GlobalModuls.Global.glbKhoa_CapNhat);
            dr = SQLCmd.ExecuteReader();
            cmbBS.ClearItems();
            while (dr.Read())
            {
                cmbBS.AddItem(string.Format("{0};{1}", dr["MaBS"], dr["TenBS"]));
            }
            dr.Close();
            SQLCmd.Dispose();
            cmbDSBenhVien.SelectedIndex = 0;
            //_frm = new frmBenhNhanRaVien();
            _frm = frm;
            
        }

        private void cmdThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdGhi_Click(object sender, EventArgs e)
        {
            //frmBenhNhanRaVien _frmravien = new frmBenhNhanRaVien();
            _frm.txtLamSang.Text = this.txtLamSang.Text;
            _frm.txtChanDoan.Text = this.txtChanDoan.Text;
            _frm.txtNguoiChuyen.Text= this.txtNguoiChuyen.Text;
            _frm.txtNguoiChuyen.Text=this.txtPhuongTien.Text;
            _frm.txtThuoc.Text=this.txtThuoc.Text;
            _frm.txtTinhTrangBN.Text=this.txtTinhTrangBN.Text;
            _frm.txtXetNghiem.Text=this.txtXetNghiem.Text;
            if (this.rdDuDK.Checked) _frm.txtLyDo.Text = this.rdDuDK.Text;
            else _frm.txtLyDo.Text = this.rdChuyenTheoYC.Text;
            _frm.cmbDSBenhVien.SelectedIndex = this.cmbDSBenhVien.SelectedIndex;
            _frm.cmbBS.SelectedIndex = this.cmbBS.SelectedIndex;
            this.Close();
        }

    }
}