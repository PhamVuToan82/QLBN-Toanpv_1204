using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace NamDinh_QLBN.Reports
{
    /// <summary>
    /// Summary description for repPhieuChiDinh.
    /// </summary>
    public partial class repPhieuGiaoThuoc : DataDynamics.ActiveReports.ActiveReport3
    {
        private String _SoPhieu;
        public string _dieuduong;
        private int STT = 0;
        int page = 0;
        public repPhieuGiaoThuoc(String HoTen, int Tuoi, String GioiTinh, String ChanDoan, String NoiChiDinh, int CapCuu, String SoPhieu, object NgayChiDinh,string dieuduong, string BacSyDT, string SoHSBA, string MaVaoVien,string TenBuong, string TenGiuong)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            lblTenBN.Text = HoTen;
            lblTuoi.Text = "Tuổi: " + Tuoi.ToString();
            lblGioi.Text = "Giới tính: " + GioiTinh;
            lblChanDoan.Text = "Chẩn đoán: " + ChanDoan;
            lblNoiChiDinh.Text = NoiChiDinh.ToUpper();
            label27.Text = String.Format("Ngày {0:dd} tháng {0:MM} năm {0:yyyy}", NgayChiDinh);
            Barcode1.Text = SoPhieu;
            _SoPhieu = SoPhieu;
            //txtNongDoCon.Text = "Lưu ý: \n" + "- Không sát trùng chỗ lấy máu bằng cồn; \n" + "- Ghi rõ giờ, ngày lấy mẫu xét nghiệm;\n" + "- Chuyển ngay mẫu đến Khoa Hóa sinh.";
            _dieuduong = dieuduong;
            lblBacSy.Text = BacSyDT;
            barcode2.Text = MaVaoVien;
            label10.Text = TenBuong;
            label17.Text = TenGiuong;
        }


        private void repPhieuChiDinh_DataInitialize(object sender, EventArgs e)
        {
             DataDynamics.ActiveReports.DataSources.SqlDBDataSource _ds = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
             _ds.ConnectionString = GlobalModuls.Global.glbConnectionString;
             _ds.SQL = string.Format("select  g.TenThuocYLenh, g.DonViTinh, f.SoLuong, f.GhiChu from NAMDINH_QLBN.dbo.BENHNHAN_PHIEUDIEUTRI e "
                                      +"  inner join NAMDINH_QLBN.dbo.PHIEUDIEUTRI_CHITIET f on f.SoPhieu = e.SoPhieu and f.loaidichvu  = 'D01' "
                                      + "  inner join NAMDINH_DUOC.dbo.DanhMucThuoc g on g.ThuocID = f.MaDichVu "
                                      + "  where e.sophieu = '{0}'", _SoPhieu);
                                                     this.DataSource = _ds;
        }

        private void detail_BeforePrint(object sender, EventArgs e)
        {
            foreach (TextBox txt in detail.Controls)
            {
                txt.Height = detail.Height;
            }
        }
        private void groupHeader1_Format(object sender, EventArgs e)
        {
            
        }

        private void detail_Format(object sender, EventArgs e)
        {
            STT++;
            lblSTT.Text = STT.ToString();
            //if (txtMadichvu.Text == "C50314" || txtMadichvu.Text == "C50323")
            //{
            //    txtNongDoCon.Visible = true; 
            //}
        }

        private void repPhieuChiDinh_ReportStart(object sender, EventArgs e)
        {
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A5;
            this.PageSettings.Orientation = PageOrientation.Portrait;
            this.PageSettings.Margins.Top = (float)0.2;
            this.PageSettings.Margins.Left = (float)0.4;
            this.PageSettings.Margins.Right = (float)0.0;
            this.PageSettings.Margins.Bottom = (float)0.0;
        }

        private void pageHeader_Format(object sender, EventArgs e)
        {

        }

        private void repPhieuChiDinh_ketqua_PageStart(object sender, EventArgs e)
        {
            page += 1;
            txtPage.Text = "Trang " + page.ToString();
        }

        private void groupHeader2_Format(object sender, EventArgs e)
        {

            STT = 0;
        }

        private void groupFooter3_Format(object sender, EventArgs e)
        {
            label12.Text = "Số khoản " + lblSTT.Text;
            //if (lbNoiChiDinh.Text == "Khoa Hóa sinh" || lbNoiChiDinh.Text == "Khoa Huyết học" || lbNoiChiDinh.Text == "Khoa Huyết học")
            //{
            label24.Text = "ĐIỀU DƯỠNG";
            //}
            //else { label24.Text = ""; }
        }
    }
}
