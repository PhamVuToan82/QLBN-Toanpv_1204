using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace NamDinh_QLBN.Reports.BaoCaoNoiTru.ChuyenVien
{
    /// <summary>
    /// Summary description for repCLS_TongHopByBS.
    /// </summary>
    public partial class repTH_ChuyenVienByBV : DataDynamics.ActiveReports.ActiveReport3
    {
        private System.DateTime _TNgay, _DNgay;
        private String _MaKhoa,_MaBS,_MaBV;

        public repTH_ChuyenVienByBV(System.DateTime TNgay, System.DateTime DNgay, String MaKhoa, String TenKhoa, string MaBS, string MaBV)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent(); 
            _TNgay = TNgay;
            _DNgay = DNgay;
            _MaKhoa = MaKhoa;
            lbKhoa.Text = TenKhoa;
            _MaBS = MaBS;
            _MaBV = MaBV;
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
            _ds.SQL = String.Format("SELECT DMBACSY.MABS,V.DOITUONG,CASE WHEN DMBACSY.MABS IS NULL THEN N'Không có tên BS' ELSE DMBACSY.TENBS END AS TENBS,"
                + " V.MADOITUONGBHXH,CASE WHEN YEAR(B.NGAYRAVIEN) - A.NAMSINH < 6 THEN 1 ELSE 0 END AS TE6,"
                + " VIEWDSBENHVIEN.MABV,CASE WHEN VIEWDSBENHVIEN.MABV IS NULL THEN N'Không chọn BV chuyển đến' ELSE VIEWDSBENHVIEN.TENBV END AS TENBV FROM"
                + " (BENHNHAN A INNER JOIN BENHNHAN_CHITIET B ON A.MABENHNHAN = B.MABENHNHAN)"
                + " INNER JOIN VIEWDOITUONGHIENTAI V ON V.MAVAOVIEN = B.MAVAOVIEN"
                + " INNER JOIN VIEWKHOAHIENTAI VV ON VV.MAVAOVIEN = B.MAVAOVIEN"
                + " LEFT JOIN DMDOITUONGBN ON DMDOITUONGBN.MADT = V.DOITUONG"
                + " LEFT JOIN DMBACSY ON DMBACSY.MABS = B.MABS AND DMBACSY.MAKHOA = VV.MAKHOA"
                + " LEFT JOIN VIEWDSBENHVIEN ON VIEWDSBENHVIEN.MABV = B.MABV"
                + " WHERE B.NOIRAVIEN = 4 AND VV.MAKHOA ='{0}' AND DATEDIFF(DD,B.NGAYRAVIEN,'{1:MM/dd/yyyy}') <= 0 AND DATEDIFF(DD,B.NGAYRAVIEN,'{2:MM/dd/yyyy}') >= 0"
                ,_MaKhoa,_TNgay,_DNgay);
            if (_MaBS != "0")
                _ds.SQL += string.Format(" AND B.MABS ={0}", _MaBS);
            if (_MaBV != "0")
                _ds.SQL += string.Format(" AND B.MABV = {0}", _MaBV);
            _ds.SQL += " ORDER BY VIEWDSBENHVIEN.TENBV";
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
                Fields["BHYT_TE"].Value = Fields["DOITUONG"].Value.ToString() == "1" && Fields["MADOITUONGBHXH"].Value.ToString() == "TE" ? 1 : 0;
                Fields["BHYT_NNGHEO"].Value = Fields["DOITUONG"].Value.ToString() == "1" && Fields["MADOITUONGBHXH"].Value.ToString() == "HN" ? 1 : 0;
                Fields["BHYT_KHAC"].Value = Fields["DOITUONG"].Value.ToString() == "1" && Fields["MADOITUONGBHXH"].Value.ToString() != "TE" && Fields["MADOITUONGBHXH"].Value.ToString() != "HN" ? 1 : 0;
                Fields["BHYT_TONG"].Value = Fields["BHYT_TE"].Value.ToString() == "1" || Fields["BHYT_NNGHEO"].Value.ToString() == "1" || Fields["BHYT_KHAC"].Value.ToString() == "1" ? 1 : 0;

                Fields["VP_TE"].Value = Fields["DOITUONG"].Value.ToString() == "3" && Fields["TE6"].Value.ToString() == "1" ? 1 : 0;
                Fields["VP_KHAC"].Value = Fields["DOITUONG"].Value.ToString() == "3" && Fields["TE6"].Value.ToString() == "0" ? 1 : 0;
                Fields["VP_TONG"].Value = Fields["VP_TE"].Value.ToString() == "1" || Fields["VP_KHAC"].Value.ToString() == "1" ? 1 : 0;

                Fields["TN_TE"].Value = Fields["DOITUONG"].Value.ToString() == "4" && Fields["TE6"].Value.ToString() == "1" ? 1 : 0;
                Fields["TN_KHAC"].Value = Fields["DOITUONG"].Value.ToString() == "4" && Fields["TE6"].Value.ToString() == "0" ? 1 : 0;
                Fields["TN_TONG"].Value = Fields["TN_TE"].Value.ToString() == "1" || Fields["TN_KHAC"].Value.ToString() == "1" ? 1 : 0;

                Fields["KHAC"].Value = Fields["DOITUONG"].Value.ToString() != "1" && Fields["DOITUONG"].Value.ToString() != "3" && Fields["DOITUONG"].Value.ToString() != "4" ? 1 : 0;

                Fields["TONG"].Value = Fields["BHYT_TONG"].Value.ToString() == "1" || Fields["VP_TONG"].Value.ToString() == "1" || Fields["TN_TONG"].Value.ToString() == "1" || Fields["KHAC"].Value.ToString() == "1" ? 1 : 0;
            }
        }

        private void groupHeader1_Format(object sender, EventArgs e)
        {
            TT.Text = string.Format("{0}", int.Parse(TT.Text.Trim()) + 1);
        }
    }
}
