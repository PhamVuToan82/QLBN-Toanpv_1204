using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace NamDinh_QLBN.Reports.BaoCaoNoiTru.DoiTuongBN
{
    /// <summary>
    /// Summary description for repDanhSachBNByDoiTuong.
    /// </summary>
    public partial class repDanhSachBNByDoiTuong : DataDynamics.ActiveReports.ActiveReport3
    {
        private System.DateTime _TNgay, _DNgay;
        private String _MaKhoa,_MaDT;
        private bool _isDangDR, _isDaRaVien;

        public repDanhSachBNByDoiTuong(System.DateTime TNgay, System.DateTime DNgay, String MaKhoa, String TenKhoa, bool isRaVien, bool isDangDT,string MaDT)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            _TNgay = TNgay;
            _DNgay = DNgay;
            _MaKhoa = MaKhoa;
            lbKhoa.Text = TenKhoa;
            System.TimeSpan Ngay1 = TNgay - DNgay;
            _isDangDR = isDangDT;
            _isDaRaVien = isRaVien;
            _MaDT = MaDT;
            if (Ngay1.Days == 0)
            {
                lblNgayThang.Text = string.Format("Ngày {0:dd} tháng {0:MM} năm {0:yyyy}", TNgay);
            }
            else
            {
                lblNgayThang.Text = string.Format("Từ ngày {0:dd/MM/yyyy} đến ngày {1:dd/MM/yyyy}", TNgay, DNgay);
            }
        }

        private void repDanhSachBNByDoiTuong_DataInitialize(object sender, EventArgs e)
        {
            DataDynamics.ActiveReports.DataSources.SqlDBDataSource _ds = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            _ds.ConnectionString = GlobalModuls.Global.glbConnectionString;
            _ds.SQL = String.Format("SELECT B.SOHSBA,A.HOTEN,YEAR(C.NGAYCHUYEN) - A.NAMSINH AS TUOI,CASE WHEN A.GIOITINH = 0 THEN N'Nữ' ELSE N'Nam' END AS GIOITINH,"
                + " E.TENDT,F.TENDT AS TENDTTHE,CASE WHEN DARAVIEN = 1 THEN N'đã ra viện' ELSE N'đang điều trị' END AS TRANGTHAI,B.DIACHI,"
                + " CASE WHEN E.MADT <> 3 THEN F.MADT + ISNULL(D.MANOICAP,'') + D.SOTHE ELSE '' END AS SOTHE,"
                + " C.NGAYCHUYEN FROM"
                + " (BENHNHAN A INNER JOIN BENHNHAN_CHITIET B ON A.MABENHNHAN = B.MABENHNHAN)"
                + " INNER JOIN VIEWKHOAHIENTAI C ON C.MAVAOVIEN = B.MAVAOVIEN"
                + " INNER JOIN VIEWDOITUONGHIENTAI D ON D.MAVAOVIEN = B.MAVAOVIEN"
                + " LEFT JOIN DMDOITUONGBN E ON E.MADT = D.DOITUONG"
                + " LEFT JOIN DMDTTHE_BHYT F ON F.MADT = D.MADOITUONGBHXH"
                + " WHERE C.MAKHOA='{0}' ", _MaKhoa);
            if (_isDangDR)
            {
                _ds.SQL += " AND TRANGTHAI = 1 AND DARAVIEN = 0";
            }
            if (_isDaRaVien)
            {
                _ds.SQL += string.Format(" AND DARAVIEN = 1 AND DATEDIFF(dd,B.NGAYRAVIEN,'{0:MM/dd/yyyy}') <= 0 AND DATEDIFF(dd,B.NGAYRAVIEN,'{1:MM/dd/yyyy}') >= 0", _TNgay, _DNgay);
            }
            if (_MaDT != "0")
            {
                _ds.SQL += string.Format(" AND E.MADT = {0}",_MaDT);
            }
            _ds.SQL += " ORDER BY A.HOTEN";
            this.DataSource = _ds;
        }

        private void detail_Format(object sender, EventArgs e)
        {
            textBox1.Text = String.Format("{0}", int.Parse(textBox1.Text) + 1);
        }

        private void detail_BeforePrint(object sender, EventArgs e)
        {
            textBox1.Height = textBox10.Height = textBox2.Height = textBox3.Height = textBox4.Height =
                textBox5.Height = textBox6.Height = textBox7.Height = textBox8.Height = textBox9.Height = detail.Height;
        }

        private void repDanhSachBNByDoiTuong_ReportStart(object sender, EventArgs e)
        {
            this.Document.Name = "Danh sách bệnh nhân nhập viên";
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.PageSettings.Orientation = PageOrientation.Landscape;

            this.PageSettings.Margins.Left = (float)0.2;
            this.PageSettings.Margins.Right = (float)0.0;
            this.PageSettings.Margins.Top = (float)0.25;
            this.PageSettings.Margins.Bottom = (float)0.2;
        }

        private void pageFooter_Format(object sender, EventArgs e)
        {
            lbPage.Text = string.Format("{0}", int.Parse(lbPage.Text) + 1);
        }
    }
}
