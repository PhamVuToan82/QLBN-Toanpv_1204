using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace NamDinh_QLBN.Reports.BaoCaoNoiTru.BenhAnNoiNgoai
{
    /// <summary>
    /// Summary description for repDanhSachBNChuyenVien.
    /// </summary>
    public partial class repBA_DanhSachBN : DataDynamics.ActiveReports.ActiveReport3
    {
        private System.DateTime _TNgay, _DNgay;
        private String _MaKhoa;
        private string _LoaiBA;
        private bool _NgayVaoVien, _NgayRaVien, _DangDieuTri;

        public repBA_DanhSachBN(System.DateTime TNgay, System.DateTime DNgay, String MaKhoa, String TenKhoa, String LoaiBA,
            bool NgayVaoVien,bool NgayRaVien,bool DangDieuTri)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            _TNgay = TNgay;
            _DNgay = DNgay;
            _MaKhoa = MaKhoa;
            _LoaiBA = LoaiBA;
            _NgayRaVien = NgayRaVien;
            _NgayVaoVien = NgayVaoVien;
            _DangDieuTri = DangDieuTri;
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
            _ds.SQL = String.Format("SELECT B.SOHSBA,A.HOTEN,YEAR(D.NGAYCHUYEN) - A.NAMSINH AS TUOI,CASE WHEN A.GIOITINH = 0 THEN N'Nữ' ELSE N'Nam' END AS GIOITINH,"
                + " B.DIACHI,DMDOITUONGBN.TENDT,CASE WHEN C.DOITUONG = 1 THEN C.MADOITUONGBHXH + C.SOTHE + C.MANOICAP ELSE '' END AS SOTHE,B.BA_NOINGOAI,"
                + " CASE WHEN B.BA_NOINGOAI = 0 THEN N'Bệnh án nội trú' ELSE N'Bệnh án ngoại trú' END AS TEN_BA_NOINGOAI,D.NGAYCHUYEN AS NGAYVAOVIEN,"
                + " CASE WHEN E.MAKHOACD IS NOT NULL THEN E.NGAYCHUYEN ELSE B.NGAYRAVIEN END AS NGAYRAVIEN,"
                + " CASE WHEN B.DARAVIEN = 0 THEN N'Đang điều trị' ELSE N'Đã ra viện' END AS TRANGTHAI"
                + " FROM"
                + " (BENHNHAN A INNER JOIN BENHNHAN_CHITIET B ON A.MABENHNHAN = B.MABENHNHAN)"
                + " INNER JOIN VIEWDOITUONGHIENTAI C ON C.MAVAOVIEN = B.MAVAOVIEN"
                + " INNER JOIN BENHNHAN_KHOA D ON D.MAVAOVIEN = B.MAVAOVIEN"
                + " INNER JOIN DMDOITUONGBN ON DMDOITUONGBN.MADT = C.DOITUONG"
                + " LEFT JOIN BENHNHAN_KHOA E ON E.MAKHOACD = D.MAKHOA AND E.MAVAOVIEN = B.MAVAOVIEN AND E.LANCHUYENKHOA = D.LANCHUYENKHOA +1");
            if(_DangDieuTri)
                _ds.SQL += " INNER JOIN VIEWKHOAHIENTAI V ON V.MAVAOVIEN = B.MAVAOVIEN AND V.MAKHOA = D.MAKHOA";

            _ds.SQL += String.Format(" WHERE D.MAKHOA ='{0}'", _MaKhoa);

            if(_NgayRaVien)
                _ds.SQL += string.Format(" AND ((E.MAKHOACD IS NOT NULL AND DATEDIFF(DD,E.NGAYCHUYEN,'{0:MM/dd/yyyy}') <= 0 AND DATEDIFF(DD,E.NGAYCHUYEN,'{1:MM/dd/yyyy}') >= 0)"
                        + " OR (E.MAKHOACD IS NULL AND DATEDIFF(DD,B.NGAYRAVIEN,'{0:MM/dd/yyyy}') <= 0 AND DATEDIFF(DD,B.NGAYRAVIEN,'{1:MM/dd/yyyy}') >= 0 AND B.DARAVIEN = 1))", _TNgay, _DNgay);
            if(_NgayVaoVien)
                _ds.SQL += string.Format(" AND DATEDIFF(DD,D.NGAYCHUYEN,'{0:MM/dd/yyyy}') <= 0 AND DATEDIFF(DD,D.NGAYCHUYEN,'{1:MM/dd/yyyy}') >= 0", _TNgay, _DNgay);
            if (_LoaiBA != "-1")
                _ds.SQL += string.Format(" AND B.BA_NOINGOAI = {0}", _LoaiBA);
            if(_DangDieuTri)
                _ds.SQL += string.Format(" AND V.VTRANGTHAI = 1 AND V.VDARAVIEN = 0");
            _ds.SQL += " ORDER BY B.BA_NOINGOAI,A.HOTEN";
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
