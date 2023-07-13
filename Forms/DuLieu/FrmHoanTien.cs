using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GlobalModuls;
using System.Data.SqlClient;
using System.Net;
using C1.Win.C1FlexGrid;

namespace NamDinh_QLBN.Forms.DuLieu
{
    public partial class FrmHoanTien : Form
    {
        string _MaKhamBenh,_Hoten, _Tuoi, _Gioi, _diachi,_Khoa;
        C1FlexGrid _fg;
        public int _hoanTien = 0;
        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void fgDichVu_AfterEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            decimal TongTien = 0;
            for (int num = 1; num < this.fgDichVu.Rows.Count; num++)
            {
                if ((fgDichVu[num, "Chon"].ToString().ToLower() == "true"))
                {
                    TongTien = TongTien + decimal.Parse(fgDichVu[num, "KyQuy"].ToString());
                }
            }
            txtTienHoan.Text = TongTien.ToString();
        }

        private void btnHoanTien_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận trả tiền", "Thông báo.", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
            {
                return;
            }
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
            decimal TongTien = 0;
            for (int num = 1; num < this.fgDichVu.Rows.Count; num++)
            {
                if ((fgDichVu[num, "Chon"].ToString().ToLower() == "true"))
                {
                    TongTien = TongTien + decimal.Parse(fgDichVu[num, "KyQuy"].ToString());
                    SQLCmd.CommandText = SQLCmd.CommandText + string.Format("  Update tblPhieuMuon_Vai set HoanTien_M = 1, NgayHoan_M = '{1:dd/MM/yyyy HH:mm}' where makhambenh = '{0}' and MaPhieuMuon = N'{2}'", _MaKhamBenh,DateNgayHoan.Value, fgDichVu[num, "MaPhieuMuon"].ToString());
                }
                else
                {
                    SQLCmd.CommandText = SQLCmd.CommandText + string.Format("  Update tblPhieuMuon_Vai set HoanTien_M = NULL, NgayHoan_M = NULL where makhambenh = '{0}' and MaPhieuMuon = N'{2}'", _MaKhamBenh, DateNgayHoan.Value, fgDichVu[num, "MaPhieuMuon"].ToString());
                }
            }
            
            SQLCmd.CommandText = SQLCmd.CommandText + string.Format(" update tblbenhnhan_muonvai set HoanTien =1, NgayHoan = '{1:dd/MM/yyyy HH:mm}', TongTien = '{2}' where MaKhamBenh = '{0}'", _MaKhamBenh, DateNgayHoan.Value, TongTien);
            for (int num = 1; num < this._fg.Rows.Count; num++)
            {
                if ((_fg[num, "MaKhamBenh"].ToString()== _MaKhamBenh))
                {
                    _fg[num, "HoanTien"] = 1;
                }
            }
            SQLCmd.ExecuteNonQuery();
            SQLCmd.Dispose();
            txtTienHoan.Text = TongTien.ToString();
            _hoanTien = 1;
        }
        public FrmHoanTien(String Makhambenh, String Hoten, String Tuoi, String Gioi, String diachi, String Khoa,C1FlexGrid fg)
        {
            InitializeComponent();
            _MaKhamBenh = Makhambenh;
            _Hoten = Hoten;
            _Tuoi = Tuoi;
            _Gioi = Gioi;
            _diachi = diachi;
            _Khoa = Khoa;
            _fg = fg;
            DateNgayHoan.Value = Global.GetNgayLV();
        }

        private void FrmHoanTien_Load(object sender, EventArgs e)
        {
            txtTienHoan.Text = "";
            txtHoTen.Text = _Hoten;
            txtGioi.Text = _Gioi;
            txtTuoi.Text = _Tuoi;
            txtKhoa.Text = _Khoa;
            txtDiaChi.Text = _diachi;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
            SQLCmd.CommandText = string.Format("select distinct x.MaPhieuMuon,c.NgayKy,isnull(c.KyQuy,0) as KyQuy ,1 as Chon,isnull(NguoiNhaBN_Kq,'') as NguoiNhaBN_Kq from (select a.*,b.MaPhieuMuon from tblbenhnhan_muonvai a inner join NAMDINH_QLBN.dbo.tblPhieuMuon_Vai b on a.MaKhambenh = b.MaKhamBenh) x left join tblbenhnhan_Vai_KyQuy c on  x.MaKhambenh = c.makhambenh and x.MaPhieuMuon = c.MaPhieuMuon where x.MaKhambenh = '{0}'", _MaKhamBenh);
            System.Data.SqlClient.SqlDataReader dr = SQLCmd.ExecuteReader();
            fgDichVu.Rows.Count = 1;
            fgDichVu.ClipSeparators = "|;";
            int tongtien = 0;
            while (dr.Read())
            {
                fgDichVu.AddItem(string.Format("|{0}|{1}|{2}|{3}|{4}|{5}|)", fgDichVu.Rows.Count,
                                    dr["MaPhieuMuon"], dr["Chon"], dr["NgayKy"], dr["KyQuy"],dr["NguoiNhaBN_Kq"]));
                tongtien = tongtien + int.Parse(dr["KyQuy"].ToString());
            }
            txtTienHoan.Text = tongtien.ToString();
            dr.Close();
            SQLCmd.Dispose();
        }
    }
}
