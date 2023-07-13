using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using System.Data.SqlClient;
namespace NamDinh_QLBN.Reports
{
    /// <summary>
    /// Summary description for NewActiveReport1.
    /// </summary>
    public partial class rptBenhNhan_ChiPhi : DataDynamics.ActiveReports.ActiveReport3
    {
        public double KyQuy = 0;
        public double DaThanhToan = 0;
        private int STT = 1;
        public rptBenhNhan_ChiPhi(string MaBenhNhan,string TenBN,string Tuoi,string GioiTinh,string DoiTuong,object NgayVaoVien,string DiaChi,string HanTheTu,string HanTheDen,string SoThe, string NoiCap,string Buong,string Giuong,object NgayRaVien,string ChanDoan,string NoiGioiThieu)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            barcode1.Text = MaBenhNhan;
            lblHoTen.Text = TenBN;
            lblTuoi.Text = Tuoi;
            lblGioiTinh.Text = GioiTinh;
            lblDiaChi.Text = DiaChi;
            if (HanTheTu !="" && HanTheDen !="")
            {
                lblGTBH.Text = "- BHYT: giá trị từ " + HanTheTu + " đến " + HanTheDen;
            }
            lblSoThe.Text = "Số: " + SoThe;
            lblNoiCap.Text = "Nơi cấp BHYT: " + NoiCap;
            lblNgayVaoVien.Text = string.Format("{0:HH} giờ ngày {0:dd/MM/yyyy}",DateTime.Parse(NgayVaoVien.ToString()));
            if (NgayRaVien == null || NgayRaVien.ToString().Trim() =="")
            {
                lblNgayRaVien.Text = "";
            }
            else
            {
                lblNgayRaVien.Text = string.Format("{0:HH} giờ ngày {0:dd/MM/yyyy}", DateTime.Parse(NgayRaVien.ToString()));
            }
            lblKhoa.Text = GlobalModuls.Global.glbTenKhoaPhong;
            lblBuong.Text = Buong;
            lblGiuong.Text = Giuong;
            lblNoiGioiThieu.Text = "- Nơi giới thiệu: " + NoiGioiThieu;
            lblNgayThang.Text = string.Format("Ngày {0:dd} tháng {0:MM} năm {0:yyyy}", GlobalModuls.Global.NgayLV);
            //lblTruongKhoa.Text = "TRƯỞNG " + GlobalModuls.Global.glbTenKhoaPhong.ToUpper();
            //lblTenTK.Text = GlobalModuls.Global.glbTenTruongKhoa;
       

        }

        private void rptBenhNhan_ChiPhi_ReportStart(object sender, EventArgs e)
        {
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.PageSettings.Orientation = PageOrientation.Portrait;
            
            this.PageSettings.Margins.Left =(float) 0.50;
            this.PageSettings.Margins.Right = (float)0.30;
            this.PageSettings.Margins.Top = (float)0.50;
            this.PageSettings.Margins.Bottom = (float)0.50;
        }

        private void detail_Format(object sender, EventArgs e)
        {
            txtSTT.Text = STT.ToString();
            STT++;
        }

        private void groupHeader3_Format(object sender, EventArgs e)
        {
            STT = 1;
        }

        private void reportFooter1_BeforePrint(object sender, EventArgs e)
        {
       }

        private void reportFooter1_Format(object sender, EventArgs e)
        {

        }

        private void detail_BeforePrint(object sender, EventArgs e)
        {
            textBox2.Height = textBox3.Height = textBox4.Height = textBox5.Height = textBox6.Height = txtSTT.Height = detail.Height;
        }
    }
}
