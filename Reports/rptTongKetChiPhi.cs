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
    public partial class rptTongKetChiPhi : DataDynamics.ActiveReports.ActiveReport3
    {
        public double KyQuy = 0;
        public double DaThanhToan = 0;
        private int STT = 1,Page = 0;
        string CacMuc = "";
        public rptTongKetChiPhi(string MaBenhNhan, string TenBN, string Tuoi, string GioiTinh, string DoiTuong, object NgayVaoVien, string DiaChi, string HanTheTu, string HanTheDen, string SoThe, string NoiCap, string Buong, string Giuong, object NgayRaVien, string ChanDoan, string NoiGioiThieu,String SoHSBA)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            CacMuc = "";
            lblSoVaoVien.Text = "Mã vào viện: " + MaBenhNhan;
            lbSoHSBA.Text = "Số vào viện: " + SoHSBA;
            lblHoTen.Text = TenBN;
            lblTuoi.Text = Tuoi;
            lblGioiTinh.Text = GioiTinh;
            lblDiaChi.Text = DiaChi;
            lblChanDoan.Text = ChanDoan;
            lblBuong.Text = Buong;
            lblGiuong.Text = Giuong;
            lblNoiGioiThieu.Text = "- Nơi giới thiệu: " + NoiGioiThieu;
            lblNgayThang.Text = string.Format("Ngày {0:dd} tháng {0:MM} năm {0:yyyy}", GlobalModuls.Global.NgayLV);
        }

        private void rptBenhNhan_ChiPhi_ReportStart(object sender, EventArgs e)
        {
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.PageSettings.Orientation = PageOrientation.Portrait;
            
            this.PageSettings.Margins.Left =(float) 0.50;
            this.PageSettings.Margins.Right = (float)0.30;
            this.PageSettings.Margins.Top = (float)0.70;
            this.PageSettings.Margins.Bottom = (float)0.50;
        } 


        private void detail_BeforePrint(object sender, EventArgs e)
        {
            textBox2.Height = textBox3.Height = textBox4.Height = textBox5.Height = textBox6.Height = txtSTT1.Height = detail.Height;
        }

        private void rptTongKetChiPhi_PageStart(object sender, EventArgs e)
        {
            Page++;
            txtPage.Text = string.Format("Trang: {0}/",Page);
        }

        private void groupFooter2_Format(object sender, EventArgs e)
        {

            Page = 0;
        }

        private void groupHeader5_Format(object sender, EventArgs e)
        {
            txtSTT.Text = STT.ToString();
            CacMuc += STT.ToString() + " + ";
            STT += 1;
        }

        private void groupFooter5_Format(object sender, EventArgs e)
        {
            txtCong.Text = "Cộng (" + txtSTT.Text + ")";
        }

        private void groupFooter4_BeforePrint(object sender, EventArgs e)
        {
            txtBangChu.Text = "(Bằng chữ: " + GlobalModuls.Global.WriteNum(long.Parse(txtTongTien.Text.Replace(".", "")));
        }

        private void groupHeader4_Format(object sender, EventArgs e)
        {
            txtSTT.Text = "0";
            STT = 1;
            CacMuc = "";
        }

        private void groupFooter4_Format(object sender, EventArgs e)
        {
            CacMuc = CacMuc.Substring(0, CacMuc.Length - 3);
            txtTongCong.Text = "(Cộng: " + CacMuc + ")";
        }

        private void rptTongKetChiPhi_FetchData(object sender, FetchEventArgs eArgs)
        {
            if (eArgs.EOF)
            {
            }
            else
            {
                Fields["Tuyen"].Value = Fields["Tuyen"].Value.ToString() == "0" ? "(Đúng tuyến)" : "Trái tuyến";
            }
        }
    }
}
