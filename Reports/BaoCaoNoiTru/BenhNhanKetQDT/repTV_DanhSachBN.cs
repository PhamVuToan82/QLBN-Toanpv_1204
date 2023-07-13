using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace NamDinh_QLBN.Reports.BaoCaoNoiTru.BenhNhanKetQDT
{
    /// <summary>
    /// Summary description for repDanhSachBNChuyenVien.
    /// </summary>
    public partial class repTV_DanhSachBN : DataDynamics.ActiveReports.ActiveReport3
    {
        private System.DateTime _TNgay, _DNgay;
        private String _MaKhoa;
        private string _KetQDT;
        private bool _NgayVaoVien, _NgayRaVien;

        public repTV_DanhSachBN(System.DateTime TNgay, System.DateTime DNgay, String MaKhoa, String TenKhoa, String KetQDT,
            bool NgayVaoVien,bool NgayRaVien)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            _TNgay = TNgay;
            _DNgay = DNgay;
            _MaKhoa = MaKhoa;
            _KetQDT = KetQDT;
            _NgayRaVien = NgayRaVien;
            _NgayVaoVien = NgayVaoVien;
            lbKhoa.Text = TenKhoa;
            System.TimeSpan Ngay1 = TNgay - DNgay;
            if (Ngay1.Days == 0)
            {
                lblNgayThang.Text = string.Format("Ngày {0:dd} tháng {0:MM} năm {0:yyyy}", TNgay);
            }
            else
            {
                lblNgayThang.Text = string.Format("Từ ngày {0:dd/MM/yyyy} đến ngày {1:dd/MM/yyyy}", TNgay, DNgay);
            }
        }

        private void detail_BeforePrint(object sender, EventArgs e)
        {
            foreach (TextBox txt in detail.Controls)
                txt.Height = detail.Height;
        }

        private void detail_Format(object sender, EventArgs e)
        {
            TT.Text = string.Format("{0}", int.Parse(TT.Text.Trim()) + 1);
        }

        private void pageFooter_Format(object sender, EventArgs e)
        {
            lbPage.Text = string.Format("{0}", int.Parse(lbPage.Text) + 1);
        }

        private void repDanhSachBNChuyenVien_DataInitialize(object sender, EventArgs e)
        {
             DataDynamics.ActiveReports.DataSources.SqlDBDataSource _ds = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            _ds.ConnectionString = GlobalModuls.Global.glbConnectionString;
            _ds.SQL = String.Format("SELECT B.SOHSBA,A.HOTEN,YEAR(C.NGAYCHUYEN) - A.NAMSINH AS TUOI,CASE WHEN A.GIOITINH = 0 THEN N'Nữ' ELSE N'Nam' END AS GIOITINH,"
                + " B.DIACHI,DMDOITUONGBN.TENDT,CASE WHEN E.DOITUONG = 1 THEN E.MADOITUONGBHXH + E.SOTHE + E.MANOICAP ELSE '' END AS SOTHE,"
                + " C.NGAYCHUYEN,B.NGAYRAVIEN,D.MAKQDT,D.TENKQDT FROM"
                + " (BENHNHAN A INNER JOIN BENHNHAN_CHITIET B ON A.MABENHNHAN = B.MABENHNHAN)"
                + " INNER JOIN VIEWKHOAHIENTAI C ON C.MAVAOVIEN = B.MAVAOVIEN"
                + " INNER JOIN DMKETQUADT D ON D.MAKQDT = B.KETQUADT"
                + " INNER JOIN VIEWDOITUONGHIENTAI E ON E.MAVAOVIEN = B.MAVAOVIEN"
                + " INNER JOIN DMDOITUONGBN ON DMDOITUONGBN.MADT = E.DOITUONG  WHERE C.MAKHOA ='{0}'", _MaKhoa);
            if(_NgayRaVien)
                _ds.SQL += string.Format(" AND DATEDIFF(DD,B.NGAYRAVIEN,'{0:MM/dd/yyyy}') <= 0 AND DATEDIFF(DD,B.NGAYRAVIEN,'{1:MM/dd/yyyy}') >= 0", _TNgay, _DNgay);
            if(_NgayVaoVien)
                _ds.SQL += string.Format(" AND DATEDIFF(DD,C.NGAYCHUYEN,'{0:MM/dd/yyyy}') <= 0 AND DATEDIFF(DD,C.NGAYCHUYEN,'{1:MM/dd/yyyy}') >= 0", _TNgay, _DNgay);
            if (_KetQDT != "0")
                _ds.SQL += string.Format(" AND B.KETQUADT = {0}", _KetQDT);
            _ds.SQL += String.Format(" ORDER BY D.TENKQDT,A.HOTEN");
            this.DataSource = _ds;
        }

        private void repDanhSachBNChuyenVien_ReportStart(object sender, EventArgs e)
        {
            this.Document.Name = "Danh sách bệnh nhân";
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.PageSettings.Orientation = PageOrientation.Landscape;

            this.PageSettings.Margins.Left = (float)0.15;
            this.PageSettings.Margins.Right = (float)0.0;
            this.PageSettings.Margins.Top = (float)0.25;
            this.PageSettings.Margins.Bottom = (float)0.2;
        }
    }
}
