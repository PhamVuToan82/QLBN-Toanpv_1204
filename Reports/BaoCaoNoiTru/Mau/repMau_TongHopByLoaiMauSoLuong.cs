using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace NamDinh_QLBN.Reports.BaoCaoNoiTru.Mau
{
    /// <summary>
    /// Summary description for repCLS_TongHopByLoaiCLS.
    /// </summary>
    public partial class  repMau_TongHopByLoaiMauSoLuong : DataDynamics.ActiveReports.ActiveReport3
    {
        private System.DateTime _TNgay, _DNgay;
        private String _MaKhoa, _Like, _MaCLS, _MaBS;
        private bool _isTatCa = false, _isBatThuong = false, _isTrongNgay = false;

        public repMau_TongHopByLoaiMauSoLuong(System.DateTime TNgay, System.DateTime DNgay, String MaKhoa, String TenKhoa, bool isTatCa,
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
                + " D.DOITUONGBN,B.TRANGTHAI,B.DARAVIEN,D.LOAIDICHVU,B.NOIRAVIEN,D.MADICHVU,D.SOLUONG FROM "
                + " (BENHNHAN A INNER JOIN BENHNHAN_CHITIET B ON A.MABENHNHAN = B.MABENHNHAN)"
                + " INNER JOIN BENHNHAN_PHIEUDIEUTRI C ON C.MAVAOVIEN = B.MAVAOVIEN"
                + " INNER JOIN PHIEUDIEUTRI_CHITIET D ON D.SOPHIEU = C.SOPHIEU"
                + " LEFT JOIN DMBACSY ON DMBACSY.MABS = C.MABS AND DMBACSY.MAKHOA = '{0}' "
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
                //_ds.SQL += string.Format(" AND D.MADICHVU LIKE '{0}'", _Like);
                _ds.SQL += string.Format(" AND D.LOAIDICHVU LIKE '{0}'", _Like);
            else
                _ds.SQL += string.Format(" AND D.LOAIDICHVU LIKE '{0}'", _MaCLS);
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
                Fields["TPA_BHYT"].Value = Fields["DoiTuongBN"].Value.ToString() == "1" && Fields["MaDichVu"].Value.ToString() == "MAU-MA-0002" ? Fields["SoLuong"].Value : 0;
                Fields["TPA_VIENPHI"].Value = Fields["DoiTuongBN"].Value.ToString() == "3" && Fields["MaDichVu"].Value.ToString() == "MAU-MA-0002" ? Fields["SoLuong"].Value : 0;
                Fields["TPA_TUNGHUYEN"].Value = Fields["DoiTuongBN"].Value.ToString() == "4" && Fields["MaDichVu"].Value.ToString() == "MAU-MA-0002" ? Fields["SoLuong"].Value : 0;
                Fields["TPA_KHAC"].Value = Fields["DoiTuongBN"].Value.ToString() != "1" && Fields["DoiTuongBN"].Value.ToString() != "3" && Fields["DoiTuongBN"].Value.ToString() != "4" && Fields["MaDichVu"].Value.ToString() == "MAU-MA-0002" ? Fields["SoLuong"].Value : 0;

                Fields["TPB_BHYT"].Value = Fields["DoiTuongBN"].Value.ToString() == "1" && Fields["MaDichVu"].Value.ToString() == "MAU-MA-0003" ? Fields["SoLuong"].Value : 0;
                Fields["TPB_VIENPHI"].Value = Fields["DoiTuongBN"].Value.ToString() == "3" && Fields["MaDichVu"].Value.ToString() == "MAU-MA-0003" ? Fields["SoLuong"].Value : 0;
                Fields["TPB_TUNGHUYEN"].Value = Fields["DoiTuongBN"].Value.ToString() == "4" && Fields["MaDichVu"].Value.ToString() == "MAU-MA-0003" ? Fields["SoLuong"].Value : 0;
                Fields["TPB_KHAC"].Value = Fields["DoiTuongBN"].Value.ToString() != "1" && Fields["DoiTuongBN"].Value.ToString() != "3" && Fields["DoiTuongBN"].Value.ToString() != "4" && Fields["MaDichVu"].Value.ToString() == "MAU-MA-0003" ? Fields["SoLuong"].Value : 0;

                Fields["TPO_BHYT"].Value = Fields["DoiTuongBN"].Value.ToString() == "1" && Fields["MaDichVu"].Value.ToString() == "MAU-MA-0004" ? Fields["SoLuong"].Value : 0;
                Fields["TPO_VIENPHI"].Value = Fields["DoiTuongBN"].Value.ToString() == "3" && Fields["MaDichVu"].Value.ToString() == "MAU-MA-0004" ? Fields["SoLuong"].Value : 0;
                Fields["TPO_TUNGHUYEN"].Value = Fields["DoiTuongBN"].Value.ToString() == "4" && Fields["MaDichVu"].Value.ToString() == "MAU-MA-0004" ? Fields["SoLuong"].Value : 0;
                Fields["TPO_KHAC"].Value = Fields["DoiTuongBN"].Value.ToString() != "1" && Fields["DoiTuongBN"].Value.ToString() != "3" && Fields["DoiTuongBN"].Value.ToString() != "4" && Fields["MaDichVu"].Value.ToString() == "MAU-MA-0004" ? Fields["SoLuong"].Value : 0;

                Fields["TPAB_BHYT"].Value = Fields["DoiTuongBN"].Value.ToString() == "1" && Fields["MaDichVu"].Value.ToString() == "MAU-MA-0005" ? Fields["SoLuong"].Value : 0;
                Fields["TPAB_VIENPHI"].Value = Fields["DoiTuongBN"].Value.ToString() == "3" && Fields["MaDichVu"].Value.ToString() == "MAU-MA-0005" ? Fields["SoLuong"].Value : 0;
                Fields["TPAB_TUNGHUYEN"].Value = Fields["DoiTuongBN"].Value.ToString() == "4" && Fields["MaDichVu"].Value.ToString() == "MAU-MA-0005" ? Fields["SoLuong"].Value : 0;
                Fields["TPAB_KHAC"].Value = Fields["DoiTuongBN"].Value.ToString() != "1" && Fields["DoiTuongBN"].Value.ToString() != "3" && Fields["DoiTuongBN"].Value.ToString() != "4" && Fields["MaDichVu"].Value.ToString() == "MAU-MA-0005" ? Fields["SoLuong"].Value : 0;

                Fields["TP_TONG"].Value = Fields["TPA_BHYT"].Value.ToString() != "0" || Fields["TPA_VIENPHI"].Value.ToString() != "0" || Fields["TPA_TUNGHUYEN"].Value.ToString() != "0" ||
                    Fields["TPB_BHYT"].Value.ToString() != "0" || Fields["TPB_VIENPHI"].Value.ToString() != "0" || Fields["TPB_TUNGHUYEN"].Value.ToString() != "0" ||
                    Fields["TPO_BHYT"].Value.ToString() != "0" || Fields["TPO_VIENPHI"].Value.ToString() != "0" || Fields["TPO_TUNGHUYEN"].Value.ToString() != "0" ||
                    Fields["TPAB_BHYT"].Value.ToString() != "0" || Fields["TPAB_VIENPHI"].Value.ToString() != "0" || Fields["TPAB_TUNGHUYEN"].Value.ToString() != "0" ||
                    Fields["TPA_KHAC"].Value.ToString() != "0" || Fields["TPB_KHAC"].Value.ToString() != "0" || Fields["TPO_KHAC"].Value.ToString() != "0" || Fields["TPAB_KHAC"].Value.ToString() != "0" ? Fields["SoLuong"].Value : 0;

                Fields["HCA_BHYT"].Value = Fields["DoiTuongBN"].Value.ToString() == "1" && Fields["MaDichVu"].Value.ToString() == "MAU-MA-0006" ? Fields["SoLuong"].Value : 0;
                Fields["HCA_VIENPHI"].Value = Fields["DoiTuongBN"].Value.ToString() == "3" && Fields["MaDichVu"].Value.ToString() == "MAU-MA-0006" ? Fields["SoLuong"].Value : 0;
                Fields["HCA_TUNGHUYEN"].Value = Fields["DoiTuongBN"].Value.ToString() == "4" && Fields["MaDichVu"].Value.ToString() == "MAU-MA-0006" ? Fields["SoLuong"].Value : 0;
                Fields["HCA_KHAC"].Value = Fields["DoiTuongBN"].Value.ToString() != "1" && Fields["DoiTuongBN"].Value.ToString() != "3" && Fields["DoiTuongBN"].Value.ToString() != "4" && Fields["MaDichVu"].Value.ToString() == "MAU-MA-0006" ? Fields["SoLuong"].Value : 0;

                Fields["HCB_BHYT"].Value = Fields["DoiTuongBN"].Value.ToString() == "1" && Fields["MaDichVu"].Value.ToString() == "MAU-MA-0007" ? Fields["SoLuong"].Value : 0;
                Fields["HCB_VIENPHI"].Value = Fields["DoiTuongBN"].Value.ToString() == "3" && Fields["MaDichVu"].Value.ToString() == "MAU-MA-0007" ? Fields["SoLuong"].Value : 0;
                Fields["HCB_TUNGHUYEN"].Value = Fields["DoiTuongBN"].Value.ToString() == "4" && Fields["MaDichVu"].Value.ToString() == "MAU-MA-0007" ? Fields["SoLuong"].Value : 0;
                Fields["HCB_KHAC"].Value = Fields["DoiTuongBN"].Value.ToString() != "1" && Fields["DoiTuongBN"].Value.ToString() != "3" && Fields["DoiTuongBN"].Value.ToString() != "4" && Fields["MaDichVu"].Value.ToString() == "MAU-MA-0007" ? Fields["SoLuong"].Value : 0;

                Fields["HCO_BHYT"].Value = Fields["DoiTuongBN"].Value.ToString() == "1" && Fields["MaDichVu"].Value.ToString() == "MAU-MA-0008" ? Fields["SoLuong"].Value : 0;
                Fields["HCO_VIENPHI"].Value = Fields["DoiTuongBN"].Value.ToString() == "3" && Fields["MaDichVu"].Value.ToString() == "MAU-MA-0008" ? Fields["SoLuong"].Value : 0;
                Fields["HCO_TUNGHUYEN"].Value = Fields["DoiTuongBN"].Value.ToString() == "4" && Fields["MaDichVu"].Value.ToString() == "MAU-MA-0008" ? Fields["SoLuong"].Value : 0;
                Fields["HCO_KHAC"].Value = Fields["DoiTuongBN"].Value.ToString() != "1" && Fields["DoiTuongBN"].Value.ToString() != "3" && Fields["DoiTuongBN"].Value.ToString() != "4" && Fields["MaDichVu"].Value.ToString() == "MAU-MA-0008" ? Fields["SoLuong"].Value : 0;

                Fields["HCAB_BHYT"].Value = Fields["DoiTuongBN"].Value.ToString() == "1" && Fields["MaDichVu"].Value.ToString() == "MAU-MA-0009" ? Fields["SoLuong"].Value : 0;
                Fields["HCAB_VIENPHI"].Value = Fields["DoiTuongBN"].Value.ToString() == "3" && Fields["MaDichVu"].Value.ToString() == "MAU-MA-0009" ? Fields["SoLuong"].Value : 0;
                Fields["HCAB_TUNGHUYEN"].Value = Fields["DoiTuongBN"].Value.ToString() == "4" && Fields["MaDichVu"].Value.ToString() == "MAU-MA-0009" ? Fields["SoLuong"].Value : 0;
                Fields["HCAB_KHAC"].Value = Fields["DoiTuongBN"].Value.ToString() != "1" && Fields["DoiTuongBN"].Value.ToString() != "3" && Fields["DoiTuongBN"].Value.ToString() != "4" && Fields["MaDichVu"].Value.ToString() == "MAU-MA-0009" ? Fields["SoLuong"].Value : 0;

                Fields["HC_TONG"].Value = Fields["HCA_BHYT"].Value.ToString() != "0" || Fields["HCA_VIENPHI"].Value.ToString() != "0" || Fields["HCA_TUNGHUYEN"].Value.ToString() != "0" ||
                    Fields["HCB_BHYT"].Value.ToString() != "0" || Fields["HCB_VIENPHI"].Value.ToString() != "0" || Fields["HCB_TUNGHUYEN"].Value.ToString() != "0" ||
                    Fields["HCO_BHYT"].Value.ToString() != "0" || Fields["HCO_VIENPHI"].Value.ToString() != "0" || Fields["HCO_TUNGHUYEN"].Value.ToString() != "0" ||
                    Fields["HCAB_BHYT"].Value.ToString() != "0" || Fields["HCAB_VIENPHI"].Value.ToString() != "0" || Fields["HCAB_TUNGHUYEN"].Value.ToString() != "0" ||
                    Fields["HCA_KHAC"].Value.ToString() != "0" || Fields["HCB_KHAC"].Value.ToString() != "0" || Fields["HCO_KHAC"].Value.ToString() != "0" || Fields["HCAB_KHAC"].Value.ToString() != "0" ? Fields["SoLuong"].Value : 0;

                Fields["TONG"].Value = Fields["TP_TONG"].Value.ToString() != "0" || Fields["HC_TONG"].Value.ToString() != "0" ? Fields["SoLuong"].Value : 0;
            }
        }

        private void groupHeader1_Format(object sender, EventArgs e)
        {
            TT.Text = string.Format("{0}", int.Parse(TT.Text.Trim()) + 1);
        }

        private void groupHeader1_BeforePrint(object sender, EventArgs e)
        {
            TT.Height = txt1.Height = txt10.Height = txt11.Height = txt12.Height = txt13.Height = txt14.Height = txt15.Height =
                txt16.Height = txt17.Height = txt18.Height = txt19.Height = txt2.Height = txt20.Height = txt21.Height = txt22.Height = 
                txt3.Height = txt4.Height = txt5.Height = txt6.Height = txt7.Height = txt8.Height = txt9.Height = groupHeader1.Height;
        }
    }
}
