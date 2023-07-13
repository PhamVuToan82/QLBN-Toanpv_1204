using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace NamDinh_QLBN.Reports.BaoCaoNoiTru.PhauThuat
{
    /// <summary>
    /// Summary description for repCLS_TongHopByLoaiCLS.
    /// </summary>
    public partial class repTHPhauThuat_ByBS : DataDynamics.ActiveReports.ActiveReport3
    {
        private System.DateTime _TNgay, _DNgay;
        private String _MaKhoa, _MaLoaiPT, _MaBS;
        public int intSTT = 0;
        private bool _isTatCa = false, _isBatThuong = false, _isTrongNgay = false;

        public repTHPhauThuat_ByBS(System.DateTime TNgay, System.DateTime DNgay, String MaKhoa, String TenKhoa, bool isTatCa,
            bool isBatThuong, bool isTrongNgay, string MaLoaiPT, string MaBS)
        {
            //
            // Required for Windows Form Designer support
            //

            InitializeComponent();
            _TNgay = TNgay;
            _DNgay = DNgay;
            _MaKhoa = MaKhoa;
            _MaLoaiPT = MaLoaiPT;
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

        private void repTHPhauThuat_ByBS_FetchData(object sender, FetchEventArgs eArgs)
        {
            if (eArgs.EOF)
            {
            }
            else
            {
                Fields["1A_BH"].Value = ((Fields["DOITUONG"].Value.ToString() == "1") && (Fields["LOAIPHAUTHUAT"].Value.ToString() == "11")) ? 1 : 0;
                Fields["1A_VP"].Value = ((Fields["DOITUONG"].Value.ToString() == "3") && (Fields["LOAIPHAUTHUAT"].Value.ToString() == "11")) ? 1 : 0;
                Fields["1A_TN"].Value = ((Fields["DOITUONG"].Value.ToString() == "4") && (Fields["LOAIPHAUTHUAT"].Value.ToString() == "11")) ? 1 : 0;
                Fields["1A_KHAC"].Value = ((Fields["LOAIPHAUTHUAT"].Value.ToString() == "11") && (Fields["DOITUONG"].Value.ToString() != "1") && (Fields["DOITUONG"].Value.ToString() != "3") && (Fields["DOITUONG"].Value.ToString() != "4")) ? 1 : 0;

                Fields["1B_BH"].Value = ((Fields["DOITUONG"].Value.ToString() == "1") && (Fields["LOAIPHAUTHUAT"].Value.ToString() == "12")) ? 1 : 0;
                Fields["1B_VP"].Value = ((Fields["DOITUONG"].Value.ToString() == "3") && (Fields["LOAIPHAUTHUAT"].Value.ToString() == "12")) ? 1 : 0;
                Fields["1B_TN"].Value = ((Fields["DOITUONG"].Value.ToString() == "4") && (Fields["LOAIPHAUTHUAT"].Value.ToString() == "12")) ? 1 : 0;
                Fields["1B_KHAC"].Value = ((Fields["LOAIPHAUTHUAT"].Value.ToString() == "12") && (Fields["DOITUONG"].Value.ToString() != "1") && (Fields["DOITUONG"].Value.ToString() != "3") && (Fields["DOITUONG"].Value.ToString() != "4")) ? 1 : 0;

                Fields["1C_BH"].Value = ((Fields["DOITUONG"].Value.ToString() == "1") && (Fields["LOAIPHAUTHUAT"].Value.ToString() == "13")) ? 1 : 0;
                Fields["1C_VP"].Value = ((Fields["DOITUONG"].Value.ToString() == "3") && (Fields["LOAIPHAUTHUAT"].Value.ToString() == "13")) ? 1 : 0;
                Fields["1C_TN"].Value = ((Fields["DOITUONG"].Value.ToString() == "4") && (Fields["LOAIPHAUTHUAT"].Value.ToString() == "13")) ? 1 : 0;
                Fields["1C_KHAC"].Value = ((Fields["LOAIPHAUTHUAT"].Value.ToString() == "13") && (Fields["DOITUONG"].Value.ToString() != "1") && (Fields["DOITUONG"].Value.ToString() != "3") && (Fields["DOITUONG"].Value.ToString() != "4")) ? 1 : 0;

                Fields["1_TONG"].Value = ((Fields["LOAIPHAUTHUAT"].Value.ToString() == "11") || (Fields["LOAIPHAUTHUAT"].Value.ToString() == "12") || (Fields["LOAIPHAUTHUAT"].Value.ToString() == "13")) ? 1 : 0;
                // DAY
                Fields["2A_BH"].Value = ((Fields["DOITUONG"].Value.ToString() == "1") && (Fields["LOAIPHAUTHUAT"].Value.ToString() == "21")) ? 1 : 0;
                Fields["2A_VP"].Value = ((Fields["DOITUONG"].Value.ToString() == "3") && (Fields["LOAIPHAUTHUAT"].Value.ToString() == "21")) ? 1 : 0;
                Fields["2A_TN"].Value = ((Fields["DOITUONG"].Value.ToString() == "4") && (Fields["LOAIPHAUTHUAT"].Value.ToString() == "21")) ? 1 : 0;
                Fields["2A_KHAC"].Value = ((Fields["LOAIPHAUTHUAT"].Value.ToString() == "21") && (Fields["DOITUONG"].Value.ToString() != "1") && (Fields["DOITUONG"].Value.ToString() != "3") && (Fields["DOITUONG"].Value.ToString() != "4")) ? 1 : 0;

                Fields["2B_BH"].Value = ((Fields["DOITUONG"].Value.ToString() == "1") && (Fields["LOAIPHAUTHUAT"].Value.ToString() == "22")) ? 1 : 0;
                Fields["2B_VP"].Value = ((Fields["DOITUONG"].Value.ToString() == "3") && (Fields["LOAIPHAUTHUAT"].Value.ToString() == "22")) ? 1 : 0;
                Fields["2B_TN"].Value = ((Fields["DOITUONG"].Value.ToString() == "4") && (Fields["LOAIPHAUTHUAT"].Value.ToString() == "22")) ? 1 : 0;
                Fields["2B_KHAC"].Value = ((Fields["LOAIPHAUTHUAT"].Value.ToString() == "22") && (Fields["DOITUONG"].Value.ToString() != "1") && (Fields["DOITUONG"].Value.ToString() != "3") && (Fields["DOITUONG"].Value.ToString() != "4")) ? 1 : 0;

                Fields["2C_BH"].Value = ((Fields["DOITUONG"].Value.ToString() == "1") && (Fields["LOAIPHAUTHUAT"].Value.ToString() == "23")) ? 1 : 0;
                Fields["2C_VP"].Value = ((Fields["DOITUONG"].Value.ToString() == "3") && (Fields["LOAIPHAUTHUAT"].Value.ToString() == "23")) ? 1 : 0;
                Fields["2C_TN"].Value = ((Fields["DOITUONG"].Value.ToString() == "4") && (Fields["LOAIPHAUTHUAT"].Value.ToString() == "23")) ? 1 : 0;
                Fields["2C_KHAC"].Value = ((Fields["LOAIPHAUTHUAT"].Value.ToString() == "23") && (Fields["DOITUONG"].Value.ToString() != "1") && (Fields["DOITUONG"].Value.ToString() != "3") && (Fields["DOITUONG"].Value.ToString() != "4")) ? 1 : 0;

                Fields["2_TONG"].Value = ((Fields["LOAIPHAUTHUAT"].Value.ToString() == "21") || (Fields["LOAIPHAUTHUAT"].Value.ToString() == "22") || (Fields["LOAIPHAUTHUAT"].Value.ToString() == "23")) ? 1 : 0;

                Fields["3_BH"].Value = ((Fields["DOITUONG"].Value.ToString() == "1") && (Fields["LOAIPHAUTHUAT"].Value.ToString() == "3")) ? 1 : 0;
                Fields["3_VP"].Value = ((Fields["DOITUONG"].Value.ToString() == "3") && (Fields["LOAIPHAUTHUAT"].Value.ToString() == "3")) ? 1 : 0;
                Fields["3_TN"].Value = ((Fields["DOITUONG"].Value.ToString() == "4") && (Fields["LOAIPHAUTHUAT"].Value.ToString() == "3")) ? 1 : 0;
                Fields["3_KHAC"].Value = ((Fields["LOAIPHAUTHUAT"].Value.ToString() == "3") && (Fields["DOITUONG"].Value.ToString() != "1") && (Fields["DOITUONG"].Value.ToString() != "3") && (Fields["DOITUONG"].Value.ToString() != "4")) ? 1 : 0;
                Fields["3_TONG"].Value = (Fields["LOAIPHAUTHUAT"].Value.ToString() == "3") ? 1 : 0;

                Fields["DB_BH"].Value = ((Fields["DOITUONG"].Value.ToString() == "1") && (Fields["LOAIPHAUTHUAT"].Value.ToString() == "4")) ? 1 : 0;
                Fields["DB_VP"].Value = ((Fields["DOITUONG"].Value.ToString() == "3") && (Fields["LOAIPHAUTHUAT"].Value.ToString() == "4")) ? 1 : 0;
                Fields["DB_TN"].Value = ((Fields["DOITUONG"].Value.ToString() == "4") && (Fields["LOAIPHAUTHUAT"].Value.ToString() == "4")) ? 1 : 0;
                Fields["DB_KHAC"].Value = ((Fields["LOAIPHAUTHUAT"].Value.ToString() == "4") && (Fields["DOITUONG"].Value.ToString() != "1") && (Fields["DOITUONG"].Value.ToString() != "3") && (Fields["DOITUONG"].Value.ToString() != "4")) ? 1 : 0;
                Fields["DB_TONG"].Value = (Fields["LOAIPHAUTHUAT"].Value.ToString() == "4") ? 1 : 0;

                Fields["TONG"].Value = (Fields["1_TONG"].Value.ToString() == "1" || Fields["2_TONG"].Value.ToString() == "1" ||Fields["3_TONG"].Value.ToString() == "1" || Fields["DB_TONG"].Value.ToString() == "1") ? 1 : 0;



            }
        }

        private void repTHPhauThuat_ByBS_DataInitialize(object sender, EventArgs e)
        {
            DataDynamics.ActiveReports.DataSources.SqlDBDataSource _ds = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            _ds.ConnectionString = GlobalModuls.Global.glbConnectionString;
            _ds.SQL = String.Format("SELECT CASE WHEN DMBACSY.TENBS IS NULL THEN N'Không có BS chỉ định' ELSE DMBACSY.TENBS END AS TENBS,DMBACSY.MABS,C.DOITUONG,A.NHOM,"
                + " LOAIPHAUTHUAT, "
                + " D.TRANGTHAI,D.DARAVIEN,D.NOIRAVIEN FROM "
                + " (BENHNHAN_PHIEUDIEUTRI A INNER JOIN PHIEUDIEUTRI_CHITIET B ON A.SOPHIEU = B.SOPHIEU)"
                + " INNER JOIN BENHNHAN_DOITUONG C ON C.DOITUONG = B.DOITUONGBN AND C.MAVAOVIEN = A.MAVAOVIEN"
                + " INNER JOIN DMPHAUTHUAT PT ON PT.MADICHVU = B.MADICHVU AND PT.LOAIDICHVU = B.LOAIDICHVU AND (PT.LAPHAUTHUAT =1 or PT.LAPHAUTHUAT =3 )"
                + " INNER JOIN BENHNHAN_CHITIET D ON D.MAVAOVIEN = A.MAVAOVIEN"
                + " INNER JOIN BENHNHAN E ON E.MABENHNHAN = D.MABENHNHAN"
                //+ " INNER JOIN thongtin_phauthuat f on f.mavaovien = d.mavaovien"
                + " LEFT JOIN DMBACSY ON DMBACSY.MABS = A.MABS AND DMBACSY.MAKHOA = A.MAKHOA"
                + " WHERE A.MAKHOA ='{0}' AND DATEDIFF(DD,NGAYCHIDINH,'{1:MM/dd/yyyy}') <= 0 AND DATEDIFF(DD,NGAYCHIDINH,'{2:MM/dd/yyyy}') >= 0", _MaKhoa, _TNgay, _DNgay);

            if (_isBatThuong)
                _ds.SQL += " AND A.NHOM = 1";
            if (_isTrongNgay)
                _ds.SQL += " AND A.NHOM = 0";
            if (_MaBS != "0")
                _ds.SQL += string.Format(" AND DMBACSY.MABS ={0}", _MaBS);
            if (_MaLoaiPT == "0")
                _ds.SQL += " AND LEFT(PT.LOAIPHAUTHUAT,1) <> '5'";
            else
                _ds.SQL += string.Format(" AND PT.LOAIPHAUTHUAT = '{0}'", _MaLoaiPT);
            _ds.SQL += " ORDER BY DMBACSY.TENBS";
            this.DataSource = _ds;
            foreach (DataDynamics.ActiveReports.TextBox txt in groupHeader1.Controls)
                if (!Fields.Contains(Fields[txt.DataField]))
                    Fields.Add(txt.DataField);
        }

        private void repTHPhauThuat_ByBS_ReportStart(object sender, EventArgs e)
        {
            this.Document.Name = "Danh sách thống kê";
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.PageSettings.Orientation = PageOrientation.Landscape;

            this.PageSettings.Margins.Left = (float)0.2;
            this.PageSettings.Margins.Right = (float)0.0;
            this.PageSettings.Margins.Top = (float)0.25;
            this.PageSettings.Margins.Bottom = (float)0.2;
        }

        private void groupHeader1_BeforePrint(object sender, EventArgs e)
        {
            foreach(TextBox txt in groupHeader1.Controls)
            {
                txt.Height = groupHeader1.Height;
            }
        }

        private void groupHeader1_Format(object sender, EventArgs e)
        {
            intSTT++;
            TT.Text = intSTT.ToString();
        }
    }
}
