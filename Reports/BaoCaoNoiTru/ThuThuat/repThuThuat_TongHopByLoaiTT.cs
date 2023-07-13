using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace NamDinh_QLBN.Reports.BaoCaoNoiTru.ThuThuat   
{
    /// <summary>
    /// Summary description for repCLS_TongHopByBS.
    /// </summary>
    public partial class repThuThuat_TongHopByLoaiTT : DataDynamics.ActiveReports.ActiveReport3
    {
        private System.DateTime _TNgay, _DNgay;
        private String _MaKhoa, _MaLoaiTT, _MaBS;
        public int intSTT = 0;
        private bool _isTatCa = false, _isBatThuong = false, _isTrongNgay = false;

        public repThuThuat_TongHopByLoaiTT(System.DateTime TNgay, System.DateTime DNgay, String MaKhoa, String TenKhoa, bool isTatCa,
            bool isBatThuong, bool isTrongNgay, string MaLoaiTT, string MaBS)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent(); 
            _TNgay = TNgay;
            _DNgay = DNgay;
            _MaKhoa = MaKhoa;
            _MaLoaiTT = MaLoaiTT;
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
            _ds.SQL = String.Format("Select LoaiPhauThuat,TenLoaiPT,C.DOITUONG,A.NHOM,"
                + " CASE WHEN YEAR(A.NGAYCHIDINH) - E.NAMSINH <= 15 THEN N'TE15' ELSE N'NL' END AS TUOI, "
                + " D.TRANGTHAI,D.DARAVIEN,D.NOIRAVIEN FROM "
                + " (BENHNHAN_PHIEUDIEUTRI A INNER JOIN PHIEUDIEUTRI_CHITIET B ON A.SOPHIEU = B.SOPHIEU)"
                + " INNER JOIN BENHNHAN_DOITUONG C ON C.DOITUONG = B.DOITUONGBN AND C.MAVAOVIEN = A.MAVAOVIEN"
                + " INNER JOIN BENHNHAN_CHITIET D ON D.MAVAOVIEN = A.MAVAOVIEN"
                + " INNER JOIN DMPHAUTHUAT PT ON PT.MADICHVU = B.MADICHVU AND PT.LOAIDICHVU = B.LOAIDICHVU AND (PT.LAPHAUTHUAT =2 OR PT.LAPHAUTHUAT =3)"
                + " INNER JOIN DMLOAIPHAUTHUAT LPT ON LPT.MALOAIPT = PT.LOAIPHAUTHUAT AND LEFT(LPT.MALOAIPT,1) = '5'"
                + " INNER JOIN BENHNHAN E ON E.MABENHNHAN = D.MABENHNHAN"
                + " LEFT JOIN DMBACSY ON DMBACSY.MABS = A.MABS AND DMBACSY.MAKHOA = A.MAKHOA"
                + " WHERE A.MAKHOA ='{0}' AND DATEDIFF(DD,NGAYCHIDINH,'{1:MM/dd/yyyy}') <= 0 AND DATEDIFF(DD,NGAYCHIDINH,'{2:MM/dd/yyyy}') >= 0",_MaKhoa,_TNgay,_DNgay);

            if (_isBatThuong) 
                _ds.SQL += " AND A.NHOM = 1";
            if (_isTrongNgay)
                _ds.SQL += " AND A.NHOM = 0";
            if (_MaBS != "0")
                _ds.SQL += string.Format(" AND DMBACSY.MABS ={0}", _MaBS);
            if (_MaLoaiTT == "0")
                _ds.SQL += "";
            else
                _ds.SQL += string.Format(" AND B.LOAIDICHVU = '{0}'", _MaLoaiTT);
            _ds.SQL += " ORDER BY LOAIPHAUTHUAT";
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
                Fields["BH"].Value = (Fields["DOITUONG"].Value.ToString() == "1")  ? 1 : 0;
                Fields["VP"].Value = (Fields["DOITUONG"].Value.ToString() == "3") ? 1 : 0;
                Fields["TN"].Value = (Fields["DOITUONG"].Value.ToString() == "4") ? 1 : 0;
                Fields["HIV"].Value = (Fields["DOITUONG"].Value.ToString() == "6") ? 1 : 0;
                Fields["KHAC"].Value = (Fields["DOITUONG"].Value.ToString() == "5") ? 1 : 0;
                Fields["TONG"].Value = (Fields["BH"].Value.ToString() == "1" || Fields["VP"].Value.ToString() == "1" || Fields["TN"].Value.ToString() == "1" || Fields["HIV"].Value.ToString() == "1" || Fields["KHAC"].Value.ToString() == "1") ? 1 : 0;

                Fields["DANGDT"].Value = (Fields["TONG"].Value.ToString() == "1" && Fields["TrangThai"].Value.ToString() == "1" && Fields["DaRaVien"].Value.ToString() == "0") ? 1 : 0;

                Fields["RAVIEN"].Value = (Fields["TONG"].Value.ToString() == "1" && Fields["DaRaVien"].Value.ToString() == "1") ? 1 : 0;

                Fields["CHUYENVIEN"].Value = (Fields["TONG"].Value.ToString() == "1" && Fields["DaRaVien"].Value.ToString() == "1" && Fields["NoiRaVien"].Value.ToString() == "4") ? 1 : 0;
            }
        }

        private void groupHeader1_BeforePrint(object sender, EventArgs e)
        {
            foreach (TextBox txt in groupHeader1.Controls)
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
