using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace NamDinh_QLBN.Reports.BaoCaoNoiTru.CanLamSang
{
    /// <summary>
    /// Summary description for repCLS_TongHopByLoaiCLS.
    /// </summary>
    public partial class repCLS_TongHopByLoaiCLS : DataDynamics.ActiveReports.ActiveReport3
    {
        private System.DateTime _TNgay, _DNgay;
        private String _MaKhoa, _Like, _MaCLS, _MaBS;
        private bool _isTatCa = false, _isBatThuong = false, _isTrongNgay = false;

        public repCLS_TongHopByLoaiCLS(System.DateTime TNgay, System.DateTime DNgay, String MaKhoa, String TenKhoa, bool isTatCa,
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

        private void repCLS_TongHopByLoaiCLS_ReportStart(object sender, EventArgs e)
        {
            this.Document.Name = "Danh sách bệnh nhân";
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.PageSettings.Orientation = PageOrientation.Landscape;

            this.PageSettings.Margins.Left = (float)0.2;
            this.PageSettings.Margins.Right = (float)0.0;
            this.PageSettings.Margins.Top = (float)0.25;
            this.PageSettings.Margins.Bottom = (float)0.2;
        }

        private void repCLS_TongHopByLoaiCLS_DataInitialize(object sender, EventArgs e)
        {
            DataDynamics.ActiveReports.DataSources.SqlDBDataSource _ds = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            _ds.ConnectionString = GlobalModuls.Global.glbConnectionString;
            _ds.SQL = String.Format("SELECT B.MAVAOVIEN,DMBACSY.MABS,CASE WHEN DMBACSY.TENBS IS NULL THEN N'Không có tên' ELSE DMBACSY.TENBS END TENBS,YEAR(C.NGAYCHIDINH) - A.NAMSINH AS TUOI,"
                + " D.DOITUONGBN,B.TRANGTHAI,B.DARAVIEN,D.LOAIDICHVU,B.NOIRAVIEN FROM "
                + " (BENHNHAN A INNER JOIN BENHNHAN_CHITIET B ON A.MABENHNHAN = B.MABENHNHAN)"
                + " INNER JOIN BENHNHAN_PHIEUDIEUTRI C ON C.MAVAOVIEN = B.MAVAOVIEN"
                + " INNER JOIN PHIEUDIEUTRI_CHITIET D ON D.SOPHIEU = C.SOPHIEU"
                + " LEFT JOIN DMBACSY ON DMBACSY.MABS = C.MABS  AND DMBACSY.MAKHOA = '{0}'"
                + " WHERE C.MAKHOA ='{0}' AND DATEDIFF(DD,C.NGAYCHIDINH,'{1:MM/dd/yyyy}') <= 0 AND DATEDIFF(DD,C.NGAYCHIDINH,'{2:MM/dd/yyyy}') >= 0",
                _MaKhoa,
                _TNgay,
                _DNgay);
            if (_isBatThuong)
                _ds.SQL += " AND C.NHOM = 1";
            if (_isTrongNgay)
                _ds.SQL += " AND C.NHOM = 0";
            if (_MaBS != "0")
                _ds.SQL += string.Format(" AND DMBACSY.MABS ={0}", _MaBS);
            if (_MaCLS == "0")
                _ds.SQL += string.Format(" AND D.MADICHVU LIKE '{0}'", _Like);
            else
                _ds.SQL += string.Format(" AND D.LOAIDICHVU = '{0}'", _MaCLS);
            _ds.SQL += " ORDER BY DMBACSY.TENBS";
            this.DataSource = _ds;
            foreach (DataDynamics.ActiveReports.TextBox txt in groupHeader1.Controls)
                if (!Fields.Contains(Fields[txt.DataField]))
                    Fields.Add(txt.DataField);
        }

        private void repCLS_TongHopByLoaiCLS_FetchData(object sender, FetchEventArgs eArgs)
        {
            if (eArgs.EOF)
            {
            }
            else
            {
                Fields["HS_BHYT"].Value = Fields["DoiTuongBN"].Value.ToString() == "1" && Fields["LoaiDichVu"].Value.ToString() == "C50" ? 1 : 0;
                Fields["HS_VIENPHI"].Value = Fields["DoiTuongBN"].Value.ToString() == "3" && Fields["LoaiDichVu"].Value.ToString() == "C50" ? 1 : 0;
                Fields["HS_TUNGHUYEN"].Value = Fields["DoiTuongBN"].Value.ToString() == "4" && Fields["LoaiDichVu"].Value.ToString() == "C50" ? 1 : 0;
                Fields["HS_KHAC"].Value = Fields["DOITUONGBN"].Value.ToString() != "1" && Fields["DOITUONGBN"].Value.ToString() != "3" && Fields["DOITUONGBN"].Value.ToString() != "4" && Fields["LoaiDichVu"].Value.ToString() == "C50" ? 1 : 0;
                Fields["HS_TONG"].Value = Fields["HS_BHYT"].Value.ToString() == "1" || Fields["HS_VIENPHI"].Value.ToString() == "1" || Fields["HS_TUNGHUYEN"].Value.ToString() == "1" || Fields["HS_KHAC"].Value .ToString() == "1"? 1 : 0;

                Fields["HH_BHYT"].Value = Fields["DoiTuongBN"].Value.ToString() == "1" && Fields["LoaiDichVu"].Value.ToString() == "C51" ? 1 : 0;
                Fields["HH_VIENPHI"].Value = Fields["DoiTuongBN"].Value.ToString() == "3" && Fields["LoaiDichVu"].Value.ToString() == "C51" ? 1 : 0;
                Fields["HH_TUNGHUYEN"].Value = Fields["DoiTuongBN"].Value.ToString() == "4" && Fields["LoaiDichVu"].Value.ToString() == "C51" ? 1 : 0;
                Fields["HH_KHAC"].Value = Fields["DOITUONGBN"].Value.ToString() != "1" && Fields["DOITUONGBN"].Value.ToString() != "3" && Fields["DOITUONGBN"].Value.ToString() != "4" && Fields["LoaiDichVu"].Value.ToString() == "C51" ? 1 : 0;
                Fields["HH_TONG"].Value = Fields["HH_BHYT"].Value.ToString() == "1" || Fields["HH_VIENPHI"].Value.ToString() == "1" || Fields["HH_TUNGHUYEN"].Value.ToString() == "1" || Fields["HH_KHAC"].Value.ToString() == "1" ? 1 : 0;

                Fields["SA_BHYT"].Value = Fields["DoiTuongBN"].Value.ToString() == "1" && Fields["LoaiDichVu"].Value.ToString() == "C53" ? 1 : 0;
                Fields["SA_VIENPHI"].Value = Fields["DoiTuongBN"].Value.ToString() == "3" && Fields["LoaiDichVu"].Value.ToString() == "C53" ? 1 : 0;
                Fields["SA_TUNGHUYEN"].Value = Fields["DoiTuongBN"].Value.ToString() == "4" && Fields["LoaiDichVu"].Value.ToString() == "C53" ? 1 : 0;
                Fields["SA_KHAC"].Value = Fields["DOITUONGBN"].Value.ToString() != "1" && Fields["DOITUONGBN"].Value.ToString() != "3" && Fields["DOITUONGBN"].Value.ToString() != "4" && Fields["LoaiDichVu"].Value.ToString() == "C53" ? 1 : 0;
                Fields["SA_TONG"].Value = Fields["SA_BHYT"].Value.ToString() == "1" || Fields["SA_VIENPHI"].Value.ToString() == "1" || Fields["SA_TUNGHUYEN"].Value.ToString() == "1" || Fields["SA_KHAC"].Value.ToString() == "1" ? 1 : 0;

                Fields["VS_BHYT"].Value = Fields["DoiTuongBN"].Value.ToString() == "1" && Fields["LoaiDichVu"].Value.ToString() == "C52" ? 1 : 0;
                Fields["VS_VIENPHI"].Value = Fields["DoiTuongBN"].Value.ToString() == "3" && Fields["LoaiDichVu"].Value.ToString() == "C52" ? 1 : 0;
                Fields["VS_TUNGHUYEN"].Value = Fields["DoiTuongBN"].Value.ToString() == "4" && Fields["LoaiDichVu"].Value.ToString() == "C52" ? 1 : 0;
                Fields["VS_KHAC"].Value = Fields["DOITUONGBN"].Value.ToString() != "1" && Fields["DOITUONGBN"].Value.ToString() != "3" && Fields["DOITUONGBN"].Value.ToString() != "4" && Fields["LoaiDichVu"].Value.ToString() == "C52" ? 1 : 0;
                Fields["VS_TONG"].Value = Fields["VS_BHYT"].Value.ToString() == "1" || Fields["VS_VIENPHI"].Value.ToString() == "1" || Fields["VS_TUNGHUYEN"].Value.ToString() == "1" || Fields["VS_KHAC"].Value.ToString() == "1" ? 1 : 0;

                Fields["CT_BHYT"].Value = Fields["DoiTuongBN"].Value.ToString() == "1" && Fields["LoaiDichVu"].Value.ToString() == "C57" ? 1 : 0;
                Fields["CT_VIENPHI"].Value = Fields["DoiTuongBN"].Value.ToString() == "3" && Fields["LoaiDichVu"].Value.ToString() == "C57" ? 1 : 0;
                Fields["CT_TUNGHUYEN"].Value = Fields["DoiTuongBN"].Value.ToString() == "4" && Fields["LoaiDichVu"].Value.ToString() == "C57" ? 1 : 0;
                Fields["CT_KHAC"].Value = Fields["DOITUONGBN"].Value.ToString() != "1" && Fields["DOITUONGBN"].Value.ToString() != "3" && Fields["DOITUONGBN"].Value.ToString() != "4" && Fields["LoaiDichVu"].Value.ToString() == "C57" ? 1 : 0;
                Fields["CT_TONG"].Value = Fields["CT_BHYT"].Value.ToString() == "1" || Fields["CT_VIENPHI"].Value.ToString() == "1" || Fields["CT_TUNGHUYEN"].Value.ToString() == "1" || Fields["CT_KHAC"].Value.ToString() == "1" ? 1 : 0;

                Fields["TONG"].Value = Fields["HS_TONG"].Value.ToString() == "1" || Fields["HH_TONG"].Value.ToString() == "1" || Fields["SA_TONG"].Value.ToString() == "1" || Fields["VS_TONG"].Value.ToString() == "1" || Fields["CT_TONG"].Value.ToString() == "1" ? 1 : 0;
                Fields["DANG_DT"].Value = Fields["TONG"].Value.ToString() == "1" && Fields["TRANGTHAI"].Value.ToString() == "1" && Fields["DARAVIEN"].Value.ToString() == "0" ? 1 : 0;
                Fields["RA_VIEN"].Value = Fields["TONG"].Value.ToString() == "1" && Fields["DARAVIEN"].Value.ToString() == "1" ? 1 : 0;
                Fields["CHUYEN_VIEN"].Value = Fields["TONG"].Value.ToString() == "1" && Fields["DARAVIEN"].Value.ToString() == "1" && Fields["NOIRAVIEN"].Value.ToString() == "4" ? 1 : 0;
            }
        }

        private void groupHeader1_Format(object sender, EventArgs e)
        {
            TT.Text = string.Format("{0}", int.Parse(TT.Text.Trim()) + 1);
        }

        private void groupHeader1_BeforePrint(object sender, EventArgs e)
        {
            TT.Height = txt1.Height = txt10.Height = txt11.Height = txt12.Height = txt13.Height = txt14.Height = txt15.Height =
                txt16.Height = txt17.Height = txt18.Height = txt19.Height = txt2.Height = txt20.Height = txt21.Height = txt22.Height = txt23.Height =
                txt24.Height = txt3.Height = txt4.Height = txt5.Height = txt6.Height = txt7.Height = txt8.Height = txt9.Height = txt25.Height = 
                txt26.Height = txt27.Height = txt28.Height =txt29.Height = txt30.Height = groupHeader1.Height;
        }
    }
}
