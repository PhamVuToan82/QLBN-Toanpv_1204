using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace NamDinh_QLBN.Reports
{
    /// <summary>
    /// Summary description for rptPhieuKhamChuyenKhoa.
    /// </summary>
    public partial class rptPhieuKhamChuyenKhoa : DataDynamics.ActiveReports.ActiveReport3
    {
        private String _MaVaoVien = "",_MaKhoa = "", _NgayIn = "";
        public rptPhieuKhamChuyenKhoa(String MaVaoVien,String MaKhoa, String NgayIn)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            _MaVaoVien = MaVaoVien;
            _MaKhoa = MaKhoa;
            _NgayIn = NgayIn;
        }

        private void rptPhieuKhamChuyenKhoa_ReportStart(object sender, EventArgs e)
        {
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.PageSettings.Orientation = PageOrientation.Portrait;

            this.PageSettings.Margins.Left = (float)0.6;
            this.PageSettings.Margins.Right = (float)0.0;
            this.PageSettings.Margins.Top = (float)0.5;
            this.PageSettings.Margins.Bottom = (float)0.50;

        }

        private void rptPhieuKhamChuyenKhoa_DataInitialize(object sender, EventArgs e)
        {
            if (_MaVaoVien == "") return;
            //   lblNgayIn.Text = string.Format("In ngày {0:dd} tháng {0:MM} năm {0:yyyy}", _NgayKham);
            DataDynamics.ActiveReports.DataSources.SqlDBDataSource _ds = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            _ds.ConnectionString = GlobalModuls.Global.glbConnectionString;
            _ds.SQL = string.Format("select KinhGui,HoTen,BacSiYeuCau,year(getdate()) - benhnhan.namsinh as tuoi,case when gioitinh = 0 then N'Nữ' else N'Nam' end as GioiTinh,dmkhoaphong.tenkhoa,"
                + " dmgiuongbenh.tengiuong,dmbuongbenh.tenbuong,benhnhan_khamck.chandoan,benhnhan_khamck.yeucaukham from  "
                + " (Select * from benhnhan_chitiet where mavaovien ='{0}') aa "
                + " inner join benhnhan on benhnhan.mabenhnhan = aa.mabenhnhan"
                + " inner join BenhNhan_KhamCK on BenhNhan_KhamCK.makhoa = '{1}' and BenhNhan_KhamCK.mavaovien = aa.mavaovien and "
                + " BenhNhan_KhamCK.lankham = (select max(lankham) from BenhNhan_KhamCK where BenhNhan_KhamCK.mavaovien='{0}' and BenhNhan_KhamCK.makhoa='{1}')"
                + " left join dmgiuongbenh on dmgiuongbenh.id_giuong = aa.giuong and dmgiuongbenh.id_buong = aa.buong and dmgiuongbenh.makhoa = '{1}'"
                + " left join dmbuongbenh on dmbuongbenh.id_buong = aa.buong and dmbuongbenh.makhoa = '{1}'"
                + " inner join dmkhoaphong on dmkhoaphong.makhoa = '{1}'", _MaVaoVien, _MaKhoa);
            this.DataSource = _ds;
            lblNgayIn.Text = string.Format("In ngày {0:dd} tháng {0:MM} năm {0:yyyy}", DateTime.Parse(_NgayIn));
        }
    }
}
