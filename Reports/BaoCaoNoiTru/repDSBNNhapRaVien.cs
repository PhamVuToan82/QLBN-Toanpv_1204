using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace NamDinh_QLBN.Reports.BaoCaoNoiTru
{
    /// <summary>
    /// Summary description for repDSBNNhapVien.
    /// </summary>
    public partial class repDSBNNhapRaVien : DataDynamics.ActiveReports.ActiveReport3
    {
        private System.DateTime _TNgay, _DNgay;
        private String _MaKhoa;
        public repDSBNNhapRaVien(System.DateTime TNgay, System.DateTime DNgay, String MaKhoa, String TenKhoa)
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
            if (Ngay1.Days == 0)
            {
                lblNgayThang.Text = string.Format("Ngày {0:dd} tháng {0:MM} năm {0:yyyy}", TNgay);
            }
            else
            {
                lblNgayThang.Text = string.Format("Từ ngày {0:dd/MM/yyyy} đến ngày {1:dd/MM/yyyy}", TNgay, DNgay);
            }
        }

        private void repDSBNNhapVien_ReportStart(object sender, EventArgs e)
        {
            this.Document.Name = "Danh sách bệnh nhân nhập viên";
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.PageSettings.Orientation = PageOrientation.Landscape;

            this.PageSettings.Margins.Left = (float)0.2;
            this.PageSettings.Margins.Right = (float)0.0;
            this.PageSettings.Margins.Top = (float)0.25;
            this.PageSettings.Margins.Bottom = (float)0.2;
        }

        private void repDSBNNhapVien_DataInitialize(object sender, EventArgs e)
        {
             DataDynamics.ActiveReports.DataSources.SqlDBDataSource _ds = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            _ds.ConnectionString = GlobalModuls.Global.glbConnectionString;
            _ds.SQL = String.Format("SELECT B.SOHSBA,A.HOTEN,YEAR(C.NGAYCHUYEN) - A.NAMSINH AS TUOI,CASE WHEN A.GIOITINH = 0 THEN N'Nữ' ELSE N'Nam' END AS GIOITINH,"
                + " DMDOITUONGBN.TENDT,B.CHANDOANRAVIEN,ISNULL(DMBUONGBENH.TENBUONG,'') + '-' + ISNULL(DMGIUONGBENH.TENGIUONG,'') AS BUONGGIUONG,B.DIACHI,C.NGAYCHUYEN AS NGAYVAOKHOA,B.NGAYRAVIEN,B.LIENHE FROM"
                + " (BENHNHAN A INNER JOIN BENHNHAN_CHITIET B ON A.MABENHNHAN = B.MABENHNHAN)"
                + " INNER JOIN VIEWKHOAHIENTAI C ON C.MAVAOVIEN = B.MAVAOVIEN"
                + " INNER JOIN VIEWDOITUONGHIENTAI D ON D.MAVAOVIEN = B.MAVAOVIEN"
                + " INNER JOIN DMDOITUONGBN ON DMDOITUONGBN.MADT = D.DOITUONG"
                + " LEFT JOIN DMBUONGBENH ON DMBUONGBENH.MAKHOA = C.MAKHOA AND DMBUONGBENH.ID_BUONG = B.BUONG"
                + " LEFT JOIN DMGIUONGBENH ON DMGIUONGBENH.MAKHOA = C.MAKHOA AND DMGIUONGBENH.ID_BUONG = B.BUONG AND DMGIUONGBENH.ID_GIUONG = B.GIUONG"
                + " WHERE (C.MAKHOA = '{0}') AND DATEDIFF(dd,B.NGAYRAVIEN,'{1:MM/dd/yyyy}') <= 0 AND DATEDIFF(dd,B.NGAYRAVIEN,'{2:MM/dd/yyyy}') >= 0 AND B.DARAVIEN = 1"
                //+ " UNION ALL" // Danh sach benh nhan chuyen khoa
                //+ " SELECT B.SOHSBA,A.HOTEN,YEAR(C.NGAYCHUYEN) - A.NAMSINH AS TUOI,CASE WHEN A.GIOITINH = 0 THEN N'Nữ' ELSE N'Nam' END AS GIOITINH,"
                //+ " DMDOITUONGBN.TENDT,B.CHANDOANRAVIEN,ISNULL(DMBUONGBENH.TENBUONG,'') + '-' + ISNULL(DMGIUONGBENH.TENGIUONG,'') AS BUONGGIUONG,B.DIACHI,F.NGAYCHUYEN AS NGAYVAOKHOA,C.NGAYCHUYEN AS NGAYRAVIEN FROM"
                //+ " (BENHNHAN A INNER JOIN BENHNHAN_CHITIET B ON A.MABENHNHAN = B.MABENHNHAN)"
                //+ " INNER JOIN BENHNHAN_KHOA C ON C.MAVAOVIEN = B.MAVAOVIEN"
                //+ " INNER JOIN BENHNHAN_KHOA F ON F.MAVAOVIEN = B.MAVAOVIEN"
                //+ " INNER JOIN VIEWDOITUONGHIENTAI D ON D.MAVAOVIEN = B.MAVAOVIEN"
                //+ " INNER JOIN DMDOITUONGBN ON DMDOITUONGBN.MADT = D.DOITUONG"
                //+ " LEFT JOIN DMBUONGBENH ON DMBUONGBENH.MAKHOA = C.MAKHOA AND DMBUONGBENH.ID_BUONG = B.BUONG"
                //+ " LEFT JOIN DMGIUONGBENH ON DMGIUONGBENH.MAKHOA = C.MAKHOA AND DMGIUONGBENH.ID_BUONG = B.BUONG AND DMGIUONGBENH.ID_GIUONG = B.GIUONG"
                //+ " WHERE C.MAKHOACD = '{0}' AND F.MAKHOA = '{0}' AND DATEDIFF(dd,C.NGAYCHUYEN,'{1:MM/dd/yyyy}') <= 0 AND DATEDIFF(dd,C.NGAYCHUYEN,'{2:MM/dd/yyyy}') >= 0 "
                + " ORDER BY NGAYRAVIEN",_MaKhoa,_TNgay,_DNgay);
            this.DataSource = _ds;
        }

        private void detail_BeforePrint(object sender, EventArgs e)
        {
            textBox1.Height = textBox2.Height = textBox3.Height = textBox4.Height = textBox5.Height = textBox6.Height = textBox7.Height
            = textBox8.Height = textBox9.Height = textBox10.Height = textBox11.Height= detail.Height;
        }

        private void detail_Format(object sender, EventArgs e)
        {
            textBox1.Text = String.Format("{0}", int.Parse(textBox1.Text) + 1);
        }

        private void pageFooter_Format(object sender, EventArgs e)
        {
            lbPage.Text = String.Format("{0}", int.Parse(lbPage.Text) + 1);
        }
    }
}
