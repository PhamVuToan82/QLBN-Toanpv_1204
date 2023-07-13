using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace NamDinh_QLBN.Reports
{
    /// <summary>
    /// Summary description for NewActiveReport1.
    /// </summary>
    public partial class  rptChiPhi_ThuThuat : DataDynamics.ActiveReports.ActiveReport3
    {
        public double KyQuy = 0;
        public double DaThanhToan = 0;
        private int STT = 1;
        public rptChiPhi_ThuThuat(string MaBenhNhan, string TenBN, string Tuoi, string DoiTuong, string NgayVaoVien)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            barcode1.Text = MaBenhNhan;
            lblHoTen.Text = TenBN;
            lblTuoi.Text = Tuoi;
            lblDoiTuong.Text = DoiTuong;
            lblNgayVaoVien.Text = NgayVaoVien;
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
