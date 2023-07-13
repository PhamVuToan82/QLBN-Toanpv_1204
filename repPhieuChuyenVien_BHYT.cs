using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace NamDinh_QLBN.Reports
{
    /// <summary>
    /// Summary description for repPhieuChuyenVien.
    /// </summary>
    public partial class repPhieuChuyenVien : DataDynamics.ActiveReports.ActiveReport3
    {
        private String _MaVaoVien;
        public repPhieuChuyenVien(String MaVaoVien)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            _MaVaoVien = MaVaoVien;
            lblMaso.Text = "Mã số vào viện: " + MaVaoVien;
            lblPhongkham.Text = "Đã được điều trị tại: " + GlobalModuls.Global.glbTenKhoaPhong + " - BV Đa khoa tỉnh Nam Định (Tuyến 2)";
            System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand();
            command.Connection = GlobalModuls.Global.ConnectSQL;
            command.CommandText = string.Format("SELECT isnull(ChuyenVien_LyDoChuyen,' ') FROM  BENHNHAN_CHITIET where MAVAOVIEN ='{0}'", MaVaoVien);
            string s= command.ExecuteScalar().ToString();
            if(s.Contains("1")) chk1.Visible=true;
            if(s.Contains("2")) chk2.Visible=true;
        }

        private void repPhieuChuyenVien_ReportStart(object sender, EventArgs e)
        {
            DataDynamics.ActiveReports.DataSources.SqlDBDataSource _ds = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
             _ds.ConnectionString = GlobalModuls.Global.glbConnectionString;
             _ds.SQL = string.Format("select bnct.*,dt.TENDT,bs.TENBS,MaDoiTuongBHXH+'-'+SoThe+'-'+MaNoiCap as SoThe,bn.HoTen,bn.NgaySinh,bn.ThangSinh,"
                    + " bn.NAMSINH AS NAMSINH,Getdate() as NgayIn, CASE WHEN bn.GIOITINH = 0 THEN N'Nữ' ELSE N'Nam' END AS GIOITINH,ChuyenVien_LyDoChuyen"
                    + " from Benhnhan_Chitiet bnct inner join BenhNhan bn on bn.mabenhnhan=bnct.MaBenhNhan"
                    + " inner join ViewDoiTuongHienTai dtht on dtht.MaVaoVien=bnct.MaVaoVien"
                    + " INNER JOIN VIEWKHOAHIENTAI khoaht ON khoaht.MAVAOVIEN = bnct.MAVAOVIEN"
                    + " LEFT JOIN DMDANTOC dt ON dt.MADT = bn.MADANTOC "
                    + " LEFT JOIN DMBACSY bs ON bs.MABS = bnct.MABS AND bs.MAKHOA = khoaht.MAKHOA"
                    + " WHERE bnct.MAVAOVIEN = '{0}'", _MaVaoVien);
             this.DataSource = _ds;
        }
    }
}
