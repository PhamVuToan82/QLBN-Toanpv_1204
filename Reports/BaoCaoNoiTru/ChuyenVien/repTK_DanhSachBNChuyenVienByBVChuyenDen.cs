using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace NamDinh_QLBN.Reports.BaoCaoNoiTru.ChuyenVien
{
    /// <summary>
    /// Summary description for repDanhSachBNChuyenVien.
    /// </summary>
    public partial class repTK_DanhSachBNChuyenVienByBVChuyenDen : DataDynamics.ActiveReports.ActiveReport3
    {
        private System.DateTime _TNgay, _DNgay;
        private String _MaKhoa,_MaBV;

        public repTK_DanhSachBNChuyenVienByBVChuyenDen(System.DateTime TNgay, System.DateTime DNgay, String MaKhoa, String TenKhoa,string MaBV)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            _TNgay = TNgay;
            _DNgay = DNgay;
            _MaKhoa = MaKhoa;
            lbKhoa.Text = TenKhoa;
            _MaBV = MaBV;
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
            _ds.SQL = String.Format("SELECT B.SOHSBA,A.HOTEN,YEAR(B.NGAYRAVIEN) - A.NAMSINH AS TUOI,CASE WHEN A.GIOITINH = 0 THEN N'Nữ' ELSE N'Nam' END AS GIOITINH,"
                + " B.DIACHI,DMDOITUONGBN.TENDT,CASE WHEN V.DOITUONG = 3 THEN '' ELSE V.MADOITUONGBHXH + V.MANOICAP + V.SOTHE END AS SOTHE,"
                + " BENHNHAN_KHOA.NGAYCHUYEN,B.NGAYRAVIEN,B.CHUYENVIEN_CHUYENDENBV,B.MABV,CASE WHEN B.MABV IS NULL THEN N'Không chọn BV' ELSE VV.TENBV END AS TENBV,DMBACSY.TENBS FROM"
                + " (BENHNHAN A INNER JOIN BENHNHAN_CHITIET B ON A.MABENHNHAN = B.MABENHNHAN)"
                + " INNER JOIN VIEWKHOAHIENTAI C ON C.MAVAOVIEN = B.MAVAOVIEN"
                + " INNER JOIN BENHNHAN_KHOA ON BENHNHAN_KHOA.MAVAOVIEN = B.MAVAOVIEN AND BENHNHAN_KHOA.LANCHUYENKHOA = 0"
                + " INNER JOIN VIEWDOITUONGHIENTAI V ON V.MAVAOVIEN = B.MAVAOVIEN"
                + " LEFT JOIN DMDOITUONGBN ON DMDOITUONGBN.MADT = V.DOITUONG"
                + " LEFT JOIN viewDSBenhVien VV ON VV.MABV = B.MABV"
                + " LEFT JOIN DMBACSY ON DMBACSY.MABS = B.MABS AND DMBACSY.MAKHOA = '{0}'"
                + " WHERE C.MAKHOA ='{0}' AND DATEDIFF(DD,B.NGAYRAVIEN,'{1:MM/dd/yyyy}') <= 0 AND DATEDIFF(DD,B.NGAYRAVIEN,'{2:MM/dd/yyyy}') >= 0"
                + " AND B.DARAVIEN = 1 AND B.NOIRAVIEN = 4 ", _MaKhoa, _TNgay, _DNgay);
            if (_MaBV != "0")
                _ds.SQL += string.Format(" AND B.MABV = {0}", _MaBV);

            _ds.SQL += " ORDER BY VV.TENBV,B.NGAYRAVIEN";
            this.DataSource = _ds;
        }

        private void repDanhSachBNChuyenVien_ReportStart(object sender, EventArgs e)
        {
            this.Document.Name = "Danh sách bệnh nhân chuyển viện";
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.PageSettings.Orientation = PageOrientation.Landscape;

            this.PageSettings.Margins.Left = (float)0.15;
            this.PageSettings.Margins.Right = (float)0.0;
            this.PageSettings.Margins.Top = (float)0.25;
            this.PageSettings.Margins.Bottom = (float)0.2;
        }
    }
}
