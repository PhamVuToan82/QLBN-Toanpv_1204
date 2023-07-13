using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GlobalModuls;

namespace NamDinh_QLBN.Forms.In
{
    public partial class frmDanhSachBenhNhanVaoVien : Form
    {
        private string prvSQLCommandText = "";
        public frmDanhSachBenhNhanVaoVien()
        {
            InitializeComponent();
        }

        private void frmDanhSachBenhNhanVaoVien_Load(object sender, EventArgs e)
        {
            cmbKhoa.Tag = "0";
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            SQLCmd.CommandText = "SELECT * FROM DMKHOAPHONG WHERE Len(MaKHoa)>1 AND MaKhoa IN " + Global.glbKhoa_CapNhat;
            dr = SQLCmd.ExecuteReader();
            cmbKhoa.Tag = "0";
            cmbKhoa.ClearItems();
            while (dr.Read())
            {
                cmbKhoa.AddItem(string.Format("{0};{1}", dr["MaKhoa"], dr["TenKhoa"]));
            }
            dr.Close();
            SQLCmd.Dispose();
            cmbKhoa.SelectedIndex = 0;
            cmbKhoa.Tag = "1";
            txtTuNgay.Tag = "0";
            txtDenNgay.Tag = 0;
            txtTuNgay.Value = txtDenNgay.Value = Global.NgayLV;
            txtTuNgay.Tag = "1";
            txtDenNgay.Tag = 1;
            fgDanhSach.ClipSeparators = "|;";
            GlobalModuls.Global.SetCmb(cmbKhoa, Global.glbMaKhoaPhong);
            fgDanhSach.Tag = 0;
            Load_DSBenhNhan();
            fgDanhSach.Tag = 1;
        }
        private void Load_DSBenhNhan()
        {
            if (cmbKhoa.SelectedIndex == -1 || cmbKhoa.Tag.ToString() == "0") { return; }
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            string MaKhoa = Global.GetCode(cmbKhoa);
            SQLCmd.CommandText = string.Format("select BENHNHAN.MaBenhNhan,BENHNHAN.HoTen As TenBenhNhan,Year(GetDate())-NamSinh as Tuoi,GioiTinh,TenDT,NgayVaoVien"
                + " ,DMBUONGBENH.TENBUONG,DMGIUONGBENH.TENGIUONG,NgayRaVien,SoHSBA  "
                + " FROM (((BENHNHAN INNER JOIN BENHNHAN_CHITIET ON BENHNHAN.MaBenhNhan=BENHNHAN_CHITIET.MaBenhNhan) "
                + " INNER JOIN ViewDOITUONGHIENTAI ON BENHNHAN_CHITIET.mavaovien=ViewDOITUONGHIENTAI.mavaovien)  "
                + " INNER JOIN DMDOITUONGBN ON ViewDOITUONGHIENTAI.DoiTuong=DMDOITUONGBN.MaDT) "
                + " INNER JOIN ViewKHOAHIENTAI ON BENHNHAN_CHITIET.MaVaoVien=ViewKHOAHIENTAI.MaVaoVien"
                + " LEFT JOIN DMGIUONGBENH ON DMGIUONGBENH.ID_GIUONG = BENHNHAN_CHITIET.GIUONG AND DMGIUONGBENH.ID_BUONG = BENHNHAN_CHITIET.BUONG AND DMGIUONGBENH.MAKHOA ='{0}'"
                + " LEFT JOIN DMBUONGBENH ON DMBUONGBENH.ID_BUONG = BENHNHAN_CHITIET.BUONG AND DMBUONGBENH.MAKHOA ='{0}'"
                + " WHERE TrangThai=1  AND ViewKHOAHIENTAI.MaKhoa='{0}' AND DateDiff(dd,NgayVaoVien,'{1:MM/dd/yyyy}')<=0 AND DateDiff(dd,NgayVaoVien,'{2:MM/dd/yyyy}')>=0",MaKhoa, txtTuNgay.Value,txtDenNgay.Value);
           
            dr = SQLCmd.ExecuteReader();
            prvSQLCommandText = SQLCmd.CommandText;
            fgDanhSach.Tag = "0";
            fgDanhSach.Rows.Count = 1;
            while (dr.Read())
            {
                fgDanhSach.AddItem(string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7:dd/MM/yyyy}|{8}|{9}|{10:dd/MM/yyyy}|{11}", fgDanhSach.Rows.Count,
                    dr["MaBenhNhan"],
                    dr["SoHSBA"],
                    dr["TenBenhNhan"],
                    dr["Tuoi"],
                    (dr["GioiTinh"].ToString() == "1") ? ("Nam") : ("Nữ"),
                    dr["TenDT"],
                    dr["NgayVaoVien"],
                    dr["TenBuong"], dr["TenGiuong"], dr["NgayRaVien"], ""));
            }
            dr.Close();
            fgDanhSach.AutoSizeCols();
            fgDanhSach.Tag = "1";
            SQLCmd.Dispose();
        }

        private void txtDKNgayRV_TextChanged(object sender, EventArgs e)
        {
            if (txtTuNgay.Tag.ToString() == "0") { return; }
            Load_DSBenhNhan();
        }

        private void cmbKhoa_TextChanged(object sender, EventArgs e)
        {
            if (cmbKhoa.Tag.ToString() == "0") return;
            Load_DSBenhNhan();
        }

        private void cmdThoat_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void cmdGhi_Click(object sender, EventArgs e)
        {

        }

        private void txtDenNgay_ValueChanged(object sender, EventArgs e)
        {
            if (txtDenNgay.Tag.ToString() == "0") return;
            Load_DSBenhNhan();
        }
    }
}