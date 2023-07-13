using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace NamDinh_QLBN.Reports.BaoCaoNoiTru.CheDoChamSoc
{
    /// <summary>
    /// Summary description for repCLS_TongHopByBS.
    /// </summary>
    public partial class repCS_TongHopByDoiTuongBN : DataDynamics.ActiveReports.ActiveReport3
    {
        private System.DateTime _TNgay, _DNgay;
        private String _MaKhoa;
        private int _CheDoChamSoc;
        private bool _NgayChiDinh, _NgayVaoVien, _NgayRaVien, _DangDieuTri;

        public repCS_TongHopByDoiTuongBN(System.DateTime TNgay, System.DateTime DNgay, String MaKhoa, String TenKhoa,int CheDoChamSoc,
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
            _ds.SQL = String.Format("SELECT A.MAVAOVIEN,SOC.MACDCHAMSOC,CASE WHEN SOC.TENCDCHAMSOC IS NULL THEN N'Không chọn' ELSE SOC.TENCDCHAMSOC END AS TENCDCHAMSOC,"
                + " E.DOITUONG,E.MADOITUONGBHXH,B.NGAYCHIDINH,CASE WHEN YEAR(B.NGAYCHIDINH) - YEAR(BENHNHAN.NAMSINH) <= 6 THEN 'TE6' ELSE 'NL' END AS TUOI"
                + " FROM"
                + " (BENHNHAN_CHITIET A INNER JOIN BENHNHAN_PHIEUDIEUTRI B ON A.MAVAOVIEN = B.MAVAOVIEN AND B.SOPHIEU IN "
                + " ( SELECT MAX(RIGHT(SOPHIEU,15)) FROM BENHNHAN_PHIEUDIEUTRI WHERE BENHNHAN_PHIEUDIEUTRI.MAVAOVIEN= A.MAVAOVIEN))"
                + " INNER JOIN BENHNHAN ON BENHNHAN.MABENHNHAN = A.MABENHNHAN"
                + " INNER JOIN PHIEUDIEUTRI_CHITIET C ON C.SOPHIEU = B.SOPHIEU "
                + " INNER JOIN DMDOITUONGBN D ON D.MADT = C.DOITUONGBN"
                + " INNER JOIN VIEWKHOAHIENTAI V ON V.MAVAOVIEN = A.MAVAOVIEN AND V.MAKHOA = B.MAKHOA"
                + " INNER JOIN VIEWDOITUONGHIENTAI E ON E.MAVAOVIEN = A.MAVAOVIEN"
                + " LEFT JOIN DMCHEDOCHAMSOC SOC ON SOC.MACDCHAMSOC = B.CDCHAMSOC"
                + " WHERE B.MAKHOA ='{0}'", _MaKhoa);

            if (_NgayChiDinh)
                _ds.SQL += string.Format(" AND DATEDIFF(DD,B.NGAYCHIDINH,'{0:MM/dd/yyyy}') <= 0 AND DATEDIFF(DD,B.NGAYCHIDINH,'{1:MM/dd/yyyy}') >= 0",_TNgay, _DNgay);
            if(_NgayRaVien)
                _ds.SQL += string.Format(" AND DATEDIFF(DD,A.NGAYRAVIEN,'{0:MM/dd/yyyy}') <= 0 AND DATEDIFF(DD,A.NGAYRAVIEN,'{1:MM/dd/yyyy}') >= 0 AND V.VDARAVIEN = 1", _TNgay, _DNgay);
            if(_NgayVaoVien)
                _ds.SQL += string.Format(" AND DATEDIFF(DD,V.NGAYCHUYEN,'{0:MM/dd/yyyy}') <= 0 AND DATEDIFF(DD,V.NGAYCHUYEN,'{1:MM/dd/yyyy}') >= 0", _TNgay, _DNgay);
            if (_CheDoChamSoc != 0)
                _ds.SQL += string.Format(" AND B.CDCHAMSOC = {0}", _CheDoChamSoc.ToString());
            if(_DangDieuTri)
                _ds.SQL += string.Format(" AND V.VTRANGTHAI = 1 AND V.VDARAVIEN = 0");
            _ds.SQL += " GROUP BY A.MAVAOVIEN,SOC.MACDCHAMSOC,SOC.TENCDCHAMSOC,E.DOITUONG,E.MADOITUONGBHXH,B.NGAYCHIDINH,BENHNHAN.NAMSINH";

            //Chuyen khoa
            if (!_DangDieuTri)
            {
                _ds.SQL += " UNION ALL";
                _ds.SQL = String.Format(" SELECT A.MAVAOVIEN,SOC.MACDCHAMSOC,CASE WHEN SOC.TENCDCHAMSOC IS NULL THEN N'Không chọn' ELSE SOC.TENCDCHAMSOC END AS TENCDCHAMSOC,"
                    + " E.DOITUONG,E.MADOITUONGBHXH,B.NGAYCHIDINH,CASE WHEN YEAR(B.NGAYCHIDINH) - YEAR(BENHNHAN.NAMSINH) <= 6 THEN 'TE6' ELSE 'NL' END AS TUOI"
                    + " FROM"
                    + " (BENHNHAN_CHITIET A INNER JOIN BENHNHAN_PHIEUDIEUTRI B ON A.MAVAOVIEN = B.MAVAOVIEN AND B.SOPHIEU IN "
                    + " ( SELECT MAX(RIGHT(SOPHIEU,15)) FROM BENHNHAN_PHIEUDIEUTRI WHERE BENHNHAN_PHIEUDIEUTRI.MAVAOVIEN= A.MAVAOVIEN))"
                    + " INNER JOIN BENHNHAN ON BENHNHAN.MABENHNHAN = A.MABENHNHAN"
                    + " INNER JOIN PHIEUDIEUTRI_CHITIET C ON C.SOPHIEU = B.SOPHIEU"
                    + " INNER JOIN DMDOITUONGBN D ON D.MADT = C.DOITUONGBN"
                    + " INNER JOIN BENHNHAN_KHOA V ON V.MAVAOVIEN = A.MAVAOVIEN AND V.MAKHOACD = B.MAKHOA"
                    + " INNER JOIN BENHNHAN_KHOA VV ON VV.MAVAOVIEN = A.MAVAOVIEN AND VV.LANCHUYENKHOA = V.LANCHUYENKHOA - 1"
                    + " INNER JOIN BENHNHAN_DOITUONG E ON E.MAVAOVIEN = A.MAVAOVIEN AND E.LANCHUYENDT = "
                    + " (SELECT MAX(LANCHUYENDT) FROM BENHNHAN_DOITUONG WHERE BENHNHAN_DOITUONG.MAVAOVIEN = A.MAVAOVIEN AND BENHNHAN_DOITUONG.DOITUONG = E.DOITUONG)"
                    + " LEFT JOIN DMCHEDOCHAMSOC SOC ON SOC.MACDCHAMSOC = B.CDCHAMSOC"
                    + " WHERE B.MAKHOA ='{0}'", _MaKhoa);

                if (_NgayChiDinh)
                    _ds.SQL += string.Format(" AND DATEDIFF(DD,B.NGAYCHIDINH,'{0:MM/dd/yyyy}') <= 0 AND DATEDIFF(DD,B.NGAYCHIDINH,'{1:MM/dd/yyyy}') >= 0", _TNgay, _DNgay);
                if (_NgayRaVien)
                    _ds.SQL += string.Format(" AND DATEDIFF(DD,V.NGAYCHUYEN,'{0:MM/dd/yyyy}') <= 0 AND DATEDIFF(DD,V.NGAYCHUYEN,'{1:MM/dd/yyyy}') >= 0", _TNgay, _DNgay);
                if (_NgayVaoVien)
                    _ds.SQL += string.Format(" AND DATEDIFF(DD,VV.NGAYCHUYEN,'{0:MM/dd/yyyy}') <= 0 AND DATEDIFF(DD,VV.NGAYCHUYEN,'{1:MM/dd/yyyy}') >= 0", _TNgay, _DNgay);
                if (_CheDoChamSoc != 0)
                    _ds.SQL += string.Format(" AND B.CDCHAMSOC = {0}", _CheDoChamSoc.ToString());
                _ds.SQL += " GROUP BY A.MAVAOVIEN,SOC.MACDCHAMSOC,SOC.TENCDCHAMSOC,E.DOITUONG,E.MADOITUONGBHXH,B.NGAYCHIDINH,BENHNHAN.NAMSINH";
            }
            _ds.SQL += " ORDER BY SOC.TENCDCHAMSOC";
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
