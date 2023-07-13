using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace NamDinh_QLBN.Reports.BaoCaoVeThuoc
{
    /// <summary>
    /// Summary description for rptPhieuLinh.
    /// </summary>
    public partial class rptPhieuLinhThuocHuongThan : DataDynamics.ActiveReports.ActiveReport3
    {
        private int STT = 0;
        private int page = 0;
        public string TruongKhoa;
        public string TruongKho;
        public string NguoiLinh;
        public string NguoiPhat;
        public string KhoThuoc;
        public string So;
        public rptPhieuLinhThuocHuongThan(string Khoa,String Ngay)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            lblKhoa.Text = Khoa.ToUpper() ;
            //txtNgaySD.Text = Ngay;
        }

        private void rptPhieuLinh_ReportStart(object sender, EventArgs e)
        {
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.PageSettings.Orientation = PageOrientation.Portrait;

            this.PageSettings.Margins.Left = (float)0.80;
            this.PageSettings.Margins.Right = (float)0.50;
            this.PageSettings.Margins.Top = (float)1;
            this.PageSettings.Margins.Bottom = (float)0.50;
            lblTruongKho.Text = TruongKho;
            lblTruongKhoa.Text = TruongKhoa;
            lblNguoiPhat.Text = NguoiPhat;
            lblNguoiLinh.Text = NguoiLinh;
            //txtSo.Text = So;
            txtNgay1.Text = "In ngày " + GlobalModuls.Global.NgayLV.Day.ToString() + " /" + GlobalModuls.Global.NgayLV.Month.ToString() + " /" + GlobalModuls.Global.NgayLV.Year.ToString();
        }

        private void detail_Format(object sender, EventArgs e)
        {
            STT++;
            label2.Text = STT.ToString();           
        }

        private void detail_BeforePrint(object sender, EventArgs e)
        {
            label2.Height = textBox2.Height = textBox3.Height = textBox4.Height = textBox5.Height = detail.Height;
        }


        private void reportFooter1_Format(object sender, EventArgs e)
        {
            txtTongKhoan.Text = "Tổng số: " + STT.ToString() + " khoản";
        }

        private void rptPhieuLinh_PageStart(object sender, EventArgs e)
        {
            page += 1;
           // txtPage.Text = "Trang " + page.ToString() ;
        }
    }
}
