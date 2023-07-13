using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace NamDinh_QLBN.Reports.BaoCaoNoiTru.CheDoChamSoc
{
    /// <summary>
    /// Summary description for repDanhSachBNChuyenVien.
    /// </summary>
    public partial class repCS_DanhSachBN : DataDynamics.ActiveReports.ActiveReport3
    {
        private System.DateTime _TNgay, _DNgay;
        private String _MaKhoa;
        private int _CheDoChamSoc;
        private bool _NgayChiDinh, _NgayVaoVien, _NgayRaVien, _DangDieuTri;

        public repCS_DanhSachBN(System.DateTime TNgay, System.DateTime DNgay, String MaKhoa, String TenKhoa,int CheDoChamSoc,
            bool NgayChiDinh,bool NgayVaoVien,bool NgayRaVien,bool DangDieuTri)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            _TNgay = TNgay;
            _DNgay = DNgay;
            _MaKhoa = MaKhoa;
            _CheDoChamSoc = CheDoChamSoc;
            _NgayRaVien = NgayRaVien;
            _NgayVaoVien = NgayVaoVien;
            _NgayChiDinh = NgayChiDinh;
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
            _ds.SQL = String.Format("SELECT B.SOHSBA,A.HOTEN, YEAR(C.NGAYCHIDINH) - A.NAMSINH AS TUOI,CASE WHEN A.GIOITINH = 0 THEN N'Nữ' ELSE N'Nam' END AS GIOITINH,"
                + " B.DIACHI,DMDOITUONGBN.TENDT,CASE WHEN V.DOITUONG <> 1 THEN '' ELSE V.MADOITUONGBHXH + V.MANOICAP + V.SOTHE END AS SOTHE,"
                + " KHOA.NGAYCHUYEN,C.NGAYCHIDINH,CASE WHEN CHAM.TENCDCHAMSOC IS NULL THEN N'Không chọn' ELSE CHAM.TENCDCHAMSOC END TENCDCHAMSOC,"
                + " CASE WHEN B.DARAVIEN = 1 THEN N'Đã ra viện' ELSE N'Đang điều trị' END AS TRANGTHAI FROM"
                + " (BENHNHAN A INNER JOIN BENHNHAN_CHITIET B ON A.MABENHNHAN = B.MABENHNHAN)"
                + " INNER JOIN BENHNHAN_PHIEUDIEUTRI C ON C.MAVAOVIEN = B.MAVAOVIEN AND C.SOPHIEU IN "
                + " ( SELECT MAX(RIGHT(SOPHIEU,15)) FROM BENHNHAN_PHIEUDIEUTRI WHERE BENHNHAN_PHIEUDIEUTRI.MAVAOVIEN= B.MAVAOVIEN)"
                + " INNER JOIN BENHNHAN_KHOA KHOA ON KHOA.MAVAOVIEN = B.MAVAOVIEN AND KHOA.LANCHUYENKHOA = 0"
                + " INNER JOIN VIEWDOITUONGHIENTAI V ON V.MAVAOVIEN = B.MAVAOVIEN "
                + " INNER JOIN DMDOITUONGBN ON DMDOITUONGBN.MADT = V.DOITUONG"
                + " INNER JOIN VIEWKHOAHIENTAI VV ON VV.MAVAOVIEN = B.MAVAOVIEN AND VV.MAKHOA = C.MAKHOA"
                + " LEFT JOIN DMCHEDOCHAMSOC CHAM ON CHAM.MACDCHAMSOC = C.CDCHAMSOC"
                + " WHERE C.MAKHOA ='{0}'", _MaKhoa);
            if (_NgayChiDinh)
                _ds.SQL += string.Format(" AND DATEDIFF(DD,C.NGAYCHIDINH,'{0:MM/dd/yyyy}') <= 0 AND DATEDIFF(DD,C.NGAYCHIDINH,'{1:MM/dd/yyyy}') >= 0",_TNgay, _DNgay);
            if(_NgayRaVien)
                _ds.SQL += string.Format(" AND DATEDIFF(DD,B.NGAYRAVIEN,'{0:MM/dd/yyyy}') <= 0 AND DATEDIFF(DD,B.NGAYRAVIEN,'{1:MM/dd/yyyy}') >= 0"
                    + " AND VV.VDARAVIEN = 1 ", _TNgay, _DNgay);
            if(_NgayVaoVien)
                _ds.SQL += string.Format(" AND DATEDIFF(DD,KHOA.NGAYCHUYEN,'{0:MM/dd/yyyy}') <= 0 AND DATEDIFF(DD,KHOA.NGAYCHUYEN,'{1:MM/dd/yyyy}') >= 0", _TNgay, _DNgay);
            if (_CheDoChamSoc != 0)
                _ds.SQL += string.Format(" AND C.CDCHAMSOC = {0}", _CheDoChamSoc.ToString());
            if(_DangDieuTri)
                _ds.SQL += string.Format(" AND VV.VTRANGTHAI = 1 AND VV.VDARAVIEN = 0");

            _ds.SQL += " GROUP BY B.SOHSBA,A.HOTEN,C.NGAYCHIDINH,A.NAMSINH,A.GIOITINH,B.DIACHI,DMDOITUONGBN.TENDT,"
                    + " V.DOITUONG,V.MADOITUONGBHXH, V.MANOICAP,V.SOTHE,KHOA.NGAYCHUYEN,C.NGAYCHIDINH,CHAM.TENCDCHAMSOC,B.DARAVIEN"
                    + " ORDER BY KHOA.NGAYCHUYEN,A.HOTEN";
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
