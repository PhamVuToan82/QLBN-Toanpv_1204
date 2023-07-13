using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace NamDinh_QLBN.Reports
{
    /// <summary>
    /// Summary description for repPhieuChuyenVien_BHYT.
    /// </summary>
    public partial class repPhieuChuyenVien_BHYT : DataDynamics.ActiveReports.ActiveReport3
    {
        private String _MaVaoVien,_TruongKhoa;
        public repPhieuChuyenVien_BHYT(String MaVaoVien, string TruongKhoa,string hosochuyenvien )
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            _MaVaoVien = MaVaoVien;
            _TruongKhoa = TruongKhoa;
            lblMaso.Text = "Mã số vào viện: " + MaVaoVien;
            label32.Text = "Vào sổ chuyển tuyến số: " + hosochuyenvien;
            //lblPhongkham.Text = "+ Tại: Bệnh viện đa khoa tỉnh Nam định (Tuyến 2)";
            //label25.Text = "+ Tại:" + GlobalModuls.Global.glbTenKhoaPhong + " - BV Đa khoa tỉnh Nam Định (Tuyến 2)";
            System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand();
            command.Connection = GlobalModuls.Global.ConnectSQL;
            command.CommandText = string.Format("SELECT isnull(ChuyenVien_LyDoChuyen,' ') FROM  BENHNHAN_CHITIET where MAVAOVIEN ='{0}'", MaVaoVien);
            string s= command.ExecuteScalar().ToString();
            if(s.Contains("1")) chk1.Visible=true;
            if(s.Contains("2")) chk2.Visible=true;
            System.Data.SqlClient.SqlCommand command1 = new System.Data.SqlClient.SqlCommand();
            command1.Connection = GlobalModuls.Global.ConnectSQL;
            command1.CommandText = string.Format("select NgayChuyen from NAMDINH_QLBN.dbo.BENHNHAN_KHOA where Mavaovien = '{0}' and LanChuyenKhoa =0", MaVaoVien);
            textBox3.Text = string.Format("{0:dd/MM/yyyy}",DateTime.Parse(command1.ExecuteScalar().ToString()));
            label52.Text = _TruongKhoa;
        }

        private void repPhieuChuyenVien_BHYT_ReportStart(object sender, EventArgs e)
        {
            DataDynamics.ActiveReports.DataSources.SqlDBDataSource _ds = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
             _ds.ConnectionString = GlobalModuls.Global.glbConnectionString;
             _ds.SQL = string.Format("select bnct.*,dt.TENDT,bs.TENBS,MaDoiTuongBHXH,SUBSTRING(Sothe,1,1) as Sothe1, SUBSTRING(Sothe,2,2) as Sothe2, SUBSTRING(Sothe,4,11) as Sothe3,bn.HoTen,bn.NgaySinh,bn.ThangSinh,"
                    + " YEAR(BNCT.NGAYRAVIEN) - bn.NAMSINH AS NAMSINH,Getdate() as NgayIn, CASE WHEN bn.GIOITINH = 0 THEN N'Nữ' ELSE N'Nam' END AS GIOITINH,ChuyenVien_LyDoChuyen,kb.Noigioithieu  as Noigioithieu,khoaht.MaKhoa "
                    + " from Benhnhan_Chitiet bnct inner join BenhNhan bn on bn.mabenhnhan=bnct.MaBenhNhan"
                    + " inner join ViewDoiTuongHienTai dtht on dtht.MaVaoVien=bnct.MaVaoVien"
                    + " INNER JOIN VIEWKHOAHIENTAI khoaht ON khoaht.MAVAOVIEN = bnct.MAVAOVIEN"
                    + " LEFT JOIN DMDANTOC dt ON dt.MADT = bn.MADANTOC "
                    + " LEFT JOIN DMBACSY bs ON bs.MABS = bnct.MABS AND bs.MAKHOA = khoaht.MAKHOA inner join NAMDINH_KHAMBENH.dbo.tblKHAMBENH kb on kb.MaKhambenh = bnct.MaKhamBenh"
                    + " WHERE bnct.MAVAOVIEN = '{0}'", _MaVaoVien);
             this.DataSource = _ds;
        }

        private void repPhieuChuyenVien_BHYT_FetchData(object sender, FetchEventArgs eArgs)
        {
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            String Noigioithieu;
            Noigioithieu = Fields["Noigioithieu"].Value.ToString();
            if(Fields["MaKhoa"].Value.ToString() == "NV1211")
            {
                label25.Text = "GIÁM ĐỐC TRUNG TÂM";
            }
            SQLCmd.CommandText = string.Format("select convert(nvarchar(3),Tuyen_BV) as Tuyenbv from NAMDINH_SYSDB.dbo.DMNOIDKKCBBD_BHYT where tennoicap = N'{0}'", Noigioithieu);
            dr = SQLCmd.ExecuteReader();
            //label25.Text = "";
            //textBox3.Text = string.Format("{0:dd/MM/yyyy}", _NgayVaoVien);
            while(dr.Read())
            {
                label46.Text= dr["Tuyenbv"].ToString();
            }
            dr.Close();
            //string sothe1, sothe2, sothe3 = "";

        }
    }
}
