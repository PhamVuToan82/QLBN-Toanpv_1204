using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace NamDinh_QLBN.Reports.BaoCaoNoiTru.NoiDKKCB_BanDau
{
    /// <summary>
    /// Summary description for repCLS_ByBS.
    /// </summary>
    public partial class  repDS_BN_DKKCBBD_ByNoiDKAndChuyenVien : DataDynamics.ActiveReports.ActiveReport3
    {
        private System.DateTime _TNgay, _DNgay;
        private String _MaKhoa,_MaTu,_MaDen,_MaBV;
        private bool _NgayVaoVien, _NgayRaVien,_TatCa;

        public repDS_BN_DKKCBBD_ByNoiDKAndChuyenVien(System.DateTime TNgay, System.DateTime DNgay, String MaKhoa, String TenKhoa, string MaTu, string MaDen,string MaBV,
            bool NgayVaoVien, bool NgayRaVien,bool TatCa)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            _TNgay = TNgay;
            _DNgay = DNgay;
            _MaKhoa = MaKhoa;
            _NgayRaVien = NgayRaVien;
            _NgayVaoVien = NgayVaoVien;
            _TatCa = TatCa;
            lbKhoa.Text = TenKhoa;
            _MaBV = MaBV;
            _MaTu = MaTu;
            _MaDen = MaDen;
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

        private void repCLS_ByBS_ReportStart(object sender, EventArgs e)
        {
            this.Document.Name = "Danh sách bệnh nhân";
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.PageSettings.Orientation = PageOrientation.Landscape;

            this.PageSettings.Margins.Left = (float)0.2;
            this.PageSettings.Margins.Right = (float)0.0;
            this.PageSettings.Margins.Top = (float)0.25;
            this.PageSettings.Margins.Bottom = (float)0.2;
        }

        private void repCLS_ByBS_DataInitialize(object sender, EventArgs e)
        {
            DataDynamics.ActiveReports.DataSources.SqlDBDataSource _ds = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            _ds.ConnectionString = GlobalModuls.Global.glbConnectionString;
            _ds.SQL = String.Format("SELECT B.SOHSBA,A.HOTEN,YEAR(F.NGAYCHUYEN) - A.NAMSINH AS TUOI,CASE WHEN A.GIOITINH = 0 THEN N'Nữ' ELSE N'Nam' END AS GIOITINH,"
                + " DMDOITUONGBN.TENDT,ISNULL(D.MADOITUONGBHXH,'')+ISNULL(D.MANOICAP,'') + ISNULL(D.SOTHE,'') AS SOTHE,"
                + " C.NGAYCHUYEN,LOWER(C.CHANDOAN) AS CHANDOAN,CASE WHEN C.VDARAVIEN = 0 THEN N'Đang điều trị' ELSE N'Đã ra viện' END AS TRANGTHAI,B.DIACHI,"
                + " E.MANOICAP,E.TENNOICAP,ViewDSBENHVIEN.MABV,CASE WHEN ViewDSBENHVIEN.TENBV IS NULL THEN N'Chưa chọn BV' ELSE ViewDSBENHVIEN.TENBV END AS TENBV FROM"
                + " (BENHNHAN A INNER JOIN BENHNHAN_CHITIET B ON A.MABENHNHAN = B.MABENHNHAN)"
                + " INNER JOIN VIEWKHOAHIENTAI C ON C.MAVAOVIEN = B.MAVAOVIEN"
                + " INNER JOIN VIEWDOITUONGHIENTAI D ON D.MAVAOVIEN = B.MAVAOVIEN"
                + " INNER JOIN NAMDINH_SYSDB.DBO.DMNOIDKKCBBD_BHYT E ON E.MANOICAP = D.MANOICAP "
                + " INNER JOIN BENHNHAN_KHOA F ON F.MAVAOVIEN = B.MAVAOVIEN AND F.LANCHUYENKHOA = 0"
                + " INNER JOIN DMDOITUONGBN ON DMDOITUONGBN.MADT = D.DOITUONG"
                + " LEFT JOIN ViewDSBENHVIEN ON ViewDSBENHVIEN.MABV = B.MABV"
                + " WHERE D.DOITUONG = 1 AND C.MAKHOA = '{0}' AND C.VDARAVIEN = 1 AND B.NOIRAVIEN = 4",_MaKhoa);
            if (_NgayRaVien)
                _ds.SQL += string.Format(" AND DATEDIFF(DD,B.NGAYRAVIEN,'{0:MM/dd/yyyy}') <= 0 AND DATEDIFF(DD,B.NGAYRAVIEN,'{1:MM/dd/yyyy}') >= 0", _TNgay, _DNgay);
            if(_NgayVaoVien)
                _ds.SQL += String.Format(" AND DATEDIFF(DD,C.NGAYCHUYEN,'{0:MM/dd/yyyy}') <= 0 AND DATEDIFF(DD,C.NGAYCHUYEN,'{1:MM/dd/yyyy}') >= 0", _TNgay, _DNgay);
            if(!_TatCa)
                _ds.SQL += String.Format(" AND E.MANOICAP BETWEEN '{0}' AND '{1}'", _MaTu, _MaDen);
            if (_MaBV != "0")
                _ds.SQL += String.Format(" AND B.MABV ={0}", _MaBV);

            _ds.SQL += " ORDER BY E.MANOICAP,E.TENNOICAP,ViewDSBENHVIEN.TENBV,A.HOTEN";
            this.DataSource = _ds;
        }

        private void detail_BeforePrint(object sender, EventArgs e)
        {
            foreach (TextBox txt in detail.Controls)
                txt.Height = detail.Height;
        }

        private void detail_Format(object sender, EventArgs e)
        {
            textBox1.Text = string.Format("{0}", int.Parse(textBox1.Text) + 1);
        }

        private void pageFooter_Format(object sender, EventArgs e)
        {
            lbPage.Text = String.Format("{0}", int.Parse(lbPage.Text) + 1);
        }

        private void groupHeader1_Format(object sender, EventArgs e)
        {
            textBox1.Text = "0";
        }
    }
}
