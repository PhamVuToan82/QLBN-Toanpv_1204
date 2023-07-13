using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace NamDinh_QLBN.Reports.BaoCaoNoiTru.BuongGiuong
{
    /// <summary>
    /// Summary description for repCLS_TongHopByBS.
    /// </summary>
    public partial class repBuongGiuong_TongHop : DataDynamics.ActiveReports.ActiveReport3
    {
        private System.DateTime _TNgay, _DNgay;
        private String _MaKhoa;
        private int _Buong, _Giuong;
        private bool _NgayVaoVien, _NgayRaVien, _DangDieuTri;

        public repBuongGiuong_TongHop(System.DateTime TNgay, System.DateTime DNgay, String MaKhoa, String TenKhoa, int Buong, int Giuong,
            bool NgayVaoVien, bool NgayRaVien, bool DangDieuTri)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            _TNgay = TNgay;
            _DNgay = DNgay;
            _MaKhoa = MaKhoa;
            _Buong = Buong;
            _Giuong = Giuong;
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

        private void repCLS_TongHopByBS_ReportStart(object sender, EventArgs e)
        {
            this.Document.Name = "Danh sách bệnh nhân";
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.PageSettings.Orientation = PageOrientation.Landscape;

            this.PageSettings.Margins.Left = (float)0.2;
            this.PageSettings.Margins.Right = (float)0.0;
            this.PageSettings.Margins.Top = (float)0.25;
            this.PageSettings.Margins.Bottom = (float)0.2;
        }

        private void repCLS_TongHopByBS_DataInitialize(object sender, EventArgs e)
        {
             DataDynamics.ActiveReports.DataSources.SqlDBDataSource _ds = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            _ds.ConnectionString = GlobalModuls.Global.glbConnectionString;
            _ds.SQL = String.Format("SELECT B.SOHSBA,A.HOTEN, CASE WHEN YEAR(C.NGAYCHUYEN) - A.NAMSINH <= 6 THEN N'TE6' ELSE N'NL' END AS TUOI,"
                + " V.DOITUONG,V.MADOITUONGBHXH,B.TRANGTHAI,DMBUONGBENH.TENBUONG,DMGIUONGBENH.TENGIUONG,B.BUONG,B.GIUONG,B.DARAVIEN,B.NOIRAVIEN FROM"
                + " (BENHNHAN A INNER JOIN BENHNHAN_CHITIET B ON A.MABENHNHAN = B.MABENHNHAN) "
                + " INNER JOIN VIEWKHOAHIENTAI C ON C.MAVAOVIEN = B.MAVAOVIEN"
                + " INNER JOIN VIEWDOITUONGHIENTAI V ON V.MAVAOVIEN = B.MAVAOVIEN"
                + " INNER JOIN DMDOITUONGBN ON DMDOITUONGBN.MADT = V.DOITUONG"
                + " LEFT JOIN DMBUONGBENH ON DMBUONGBENH.MAKHOA = C.MAKHOA AND DMBUONGBENH.ID_BUONG = B.BUONG"
                + " LEFT JOIN DMGIUONGBENH ON DMGIUONGBENH.MAKHOA = C.MAKHOA AND DMGIUONGBENH.ID_BUONG = B.BUONG AND DMGIUONGBENH.ID_GIUONG = B.GIUONG"
                + " WHERE C.MAKHOA ='{0}' ",_MaKhoa);
            if (_NgayRaVien)
                _ds.SQL += string.Format(" AND DATEDIFF(DD,B.NGAYRAVIEN,'{0:MM/dd/yyyy}') <= 0 AND DATEDIFF(DD,B.NGAYRAVIEN,'{1:MM/dd/yyyy}') >= 0"
                    + " AND C.VDARAVIEN = 1 ", _TNgay, _DNgay);
            if (_NgayVaoVien)
                _ds.SQL += string.Format(" AND DATEDIFF(DD,C.NGAYCHUYEN,'{0:MM/dd/yyyy}') <= 0 AND DATEDIFF(DD,C.NGAYCHUYEN,'{1:MM/dd/yyyy}') >= 0", _TNgay, _DNgay);
            if (_DangDieuTri)
                _ds.SQL += string.Format(" AND C.VTRANGTHAI = 1 AND C.VDARAVIEN = 0");
            if (_Giuong != 0)
                _ds.SQL += string.Format(" AND B.GIUONG ={0}", _Giuong);
            if (_Buong != 0)
                _ds.SQL += String.Format(" AND B.BUONG ={0}", _Buong);
            _ds.SQL += " ORDER BY B.BUONG,B.GIUONG";
            this.DataSource = _ds;
            foreach (DataDynamics.ActiveReports.TextBox txt in groupHeader1.Controls)
                if (!Fields.Contains(Fields[txt.DataField]))
                    Fields.Add(txt.DataField);
        }

        private void repCLS_TongHopByBS_FetchData(object sender, FetchEventArgs eArgs)
        {
            if (eArgs.EOF)
            {
            }
            else
            {
                Fields["BHYT_TE"].Value = ((Fields["DOITUONG"].Value.ToString() == "1") && (Fields["MaDoiTuongBHXH"].Value.ToString() == "TE")) ? 1 : 0;
                Fields["BHYT_NNGHEO"].Value = ((Fields["DOITUONG"].Value.ToString() == "1") && (Fields["MaDoiTuongBHXH"].Value.ToString() == "HN")) ? 1 : 0;
                Fields["BHYT_KHAC"].Value = ((Fields["DOITUONG"].Value.ToString() == "1") && (Fields["MaDoiTuongBHXH"].Value.ToString() != "HN") && (Fields["MaDoiTuongBHXH"].Value.ToString() != "TE")) ? 1 : 0;
                Fields["BHYT_TONG"].Value = (Fields["BHYT_TE"].Value.ToString() == "1" || Fields["BHYT_NNGHEO"].Value.ToString() == "1" || Fields["BHYT_KHAC"].Value.ToString() == "1") ? 1 : 0;

                Fields["VP_TE"].Value = ((Fields["DOITUONG"].Value.ToString() == "3") && (Fields["TUOI"].Value.ToString() == "TE6")) ? 1 : 0;
                Fields["VP_KHAC"].Value = ((Fields["DOITUONG"].Value.ToString() == "3") && (Fields["TUOI"].Value.ToString() == "NL")) ? 1 : 0;
                Fields["VP_TONG"].Value = (Fields["VP_KHAC"].Value.ToString() == "1" || Fields["VP_TE"].Value.ToString() == "1") ? 1 : 0;

                Fields["TN_TE"].Value = ((Fields["DOITUONG"].Value.ToString() == "4") && (Fields["TUOI"].Value.ToString() == "TE6")) ? 1 : 0;
                Fields["TN_KHAC"].Value = ((Fields["DOITUONG"].Value.ToString() == "4") && (Fields["TUOI"].Value.ToString() == "NL")) ? 1 : 0;
                Fields["TN_TONG"].Value = (Fields["TN_TE"].Value.ToString() == "1" || Fields["TN_KHAC"].Value.ToString() == "1") ? 1 : 0;

                Fields["KHAC"].Value = Fields["DOITUONG"].Value.ToString() != "1" && Fields["DOITUONG"].Value.ToString() != "3" && Fields["DOITUONG"].Value.ToString() != "4" ? 1 : 0;

                Fields["TONG"].Value = (Fields["BHYT_TONG"].Value.ToString() == "1" || Fields["VP_TONG"].Value.ToString() == "1" || Fields["TN_TONG"].Value.ToString() == "1" && Fields["KHAC"].Value.ToString() == "1") ? 1 : 0;

                Fields["DANG_DT"].Value = (Fields["TONG"].Value.ToString() == "1" && Fields["TrangThai"].Value.ToString() == "1" && Fields["DaRaVien"].Value.ToString() == "0") ? 1 : 0;

                Fields["RA_VIEN"].Value = (Fields["TONG"].Value.ToString() == "1" && Fields["DaRaVien"].Value.ToString() == "1") ? 1 : 0;

                Fields["CHUYEN_VIEN"].Value = (Fields["TONG"].Value.ToString() == "1" && Fields["DaRaVien"].Value.ToString() == "1" && Fields["NoiRaVien"].Value.ToString() == "4") ? 1 : 0;
            }
        }

        private void groupHeader1_Format(object sender, EventArgs e)
        {
            TT.Text = string.Format("{0}", int.Parse(TT.Text.Trim()) + 1);
        }

        private void groupHeader1_BeforePrint(object sender, EventArgs e)
        {
            foreach (TextBox txt in groupHeader1.Controls)
                txt.Height = groupHeader1.Height;
        }
    }
}
