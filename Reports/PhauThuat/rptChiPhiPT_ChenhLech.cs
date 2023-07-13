using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace NamDinh_QLBN.Reports.PhauThuat
{
    /// <summary>
    /// Summary description for rptChiPhiPT.
    /// </summary>
    public partial class rptChiPhiPT_ChenhLech : DataDynamics.ActiveReports.ActiveReport3
    {

        public rptChiPhiPT_ChenhLech(string MaVaoVien,string HoTen,string Tuoi,string DoiTuong,string NgayVaoVien,string NgayPT,string ChanDoan,string ChiDinh,string BsGayMe,string DieuDuong)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            barcode1.Text = MaVaoVien;
            lblHoTen.Text = HoTen.ToUpper();
            lblTuoi.Text = Tuoi;
            lblNgayVaoVien.Text = NgayVaoVien;
            lblDoiTuong.Text = DoiTuong;
            lblNgayPT.Text = NgayPT;
            lblChanDoan.Text = ChanDoan;
            lblChiDinh.Text = ChiDinh;
            lblTenTK.Text = BsGayMe;
            lblDieuDuong.Text = DieuDuong;
        }

        private void rptChiPhiPT_ReportStart(object sender, EventArgs e)
        {
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.PageSettings.Margins.Top = (float)0.5;
            this.PageSettings.Margins.Left = (float)0.5;
            this.PageSettings.Margins.Right = (float)0.5;
            this.PageSettings.Margins.Bottom = (float)0.5;
            this.Document.Name = "Phiếu thống kê chi phí phẫu thuật phần chênh lệch";
        }

        private void detail_Format(object sender, EventArgs e)
        {
            STT.Text = string.Format("{0}", int.Parse(STT.Text) + 1);
        }

        private void groupHeader1_Format(object sender, EventArgs e)
        {
            STT.Text = "0";
        }

        private void detail_BeforePrint(object sender, EventArgs e)
        {
            STT.Height = textBox2.Height = textBox3.Height = textBox4.Height = textBox5.Height = textBox6.Height = detail.Height;
        }
    }
}
