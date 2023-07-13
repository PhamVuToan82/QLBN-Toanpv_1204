using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace NamDinh_QLBN.Reports.BaoCaoNoiTru.CanLamSang
{
    /// <summary>
    /// Summary description for repCLS_TongHopByBS.
    /// </summary>
    public partial class repCLS_TongHopByBS : DataDynamics.ActiveReports.ActiveReport3
    {
        private System.DateTime _TNgay, _DNgay;
        private String _MaKhoa, _Like, _MaCLS, _MaBS;
        private bool _isTatCa = false, _isBatThuong = false, _isTrongNgay = false;

        public repCLS_TongHopByBS(System.DateTime TNgay, System.DateTime DNgay, String MaKhoa, String TenKhoa, bool isTatCa,
            bool isBatThuong, bool isTrongNgay, string Like, string MaCLS, string MaBS)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent(); 
            _TNgay = TNgay;
            _DNgay = DNgay;
            _MaKhoa = MaKhoa;
            _Like = Like;
            _MaCLS = MaCLS;
            _isBatThuong = isBatThuong;
            _isTatCa = isTatCa;
            _isTrongNgay = isTrongNgay;
            lbKhoa.Text = TenKhoa;
            _MaBS = MaBS;
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
            _ds.SQL = String.Format("SELECT CASE WHEN DMBACSY.TENBS IS NULL THEN N'Không có BS chỉ định' ELSE DMBACSY.TENBS END AS TENBS,DMBACSY.MABS,C.DOITUONG,C.MADOITUONGBHXH,A.NHOM,"
                + " CASE WHEN YEAR(A.NGAYCHIDINH) - E.NAMSINH <= 6 THEN N'TE6' ELSE N'NL' END AS TUOI, "
                + " D.TRANGTHAI,D.DARAVIEN,D.NOIRAVIEN FROM "
                + " (BENHNHAN_PHIEUDIEUTRI A INNER JOIN PHIEUDIEUTRI_CHITIET B ON A.SOPHIEU = B.SOPHIEU)"
                + " INNER JOIN BENHNHAN_DOITUONG C ON C.MAVAOVIEN = A.MAVAOVIEN AND"
                + " C.LANCHUYENDT = (SELECT MAX(BENHNHAN_DOITUONG.LANCHUYENDT) FROM BENHNHAN_DOITUONG WHERE MAVAOVIEN = A.MAVAOVIEN AND DOITUONG = B.DOITUONGBN)"
                + " INNER JOIN BENHNHAN_CHITIET D ON D.MAVAOVIEN = A.MAVAOVIEN"
                + " INNER JOIN BENHNHAN E ON E.MABENHNHAN = D.MABENHNHAN"
                + " LEFT JOIN DMBACSY ON DMBACSY.MABS = A.MABS AND DMBACSY.MAKHOA = A.MAKHOA"
                + " WHERE A.MAKHOA ='{0}' AND DATEDIFF(DD,NGAYCHIDINH,'{1:MM/dd/yyyy}') <= 0 AND DATEDIFF(DD,NGAYCHIDINH,'{2:MM/dd/yyyy}') >= 0",_MaKhoa,_TNgay,_DNgay);

            if (_isBatThuong) 
                _ds.SQL += " AND A.NHOM = 1";
            if (_isTrongNgay)
                _ds.SQL += " AND A.NHOM = 0";
            if (_MaBS != "0")
                _ds.SQL += string.Format(" AND DMBACSY.MABS ={0}", _MaBS);
            if (_MaCLS == "0")
                _ds.SQL += string.Format(" AND B.MADICHVU LIKE '{0}'", _Like);
            else
                _ds.SQL += string.Format(" AND B.LOAIDICHVU = '{0}'", _MaCLS);
            _ds.SQL += " ORDER BY DMBACSY.TENBS";
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
