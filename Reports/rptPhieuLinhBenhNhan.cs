using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace QLDuoc2009.Reports
{
    /// <summary>
    /// Summary description for rptPhieuLinh.
    /// </summary>
    public partial class rptPhieuLinhBenhNhan : DataDynamics.ActiveReports.ActiveReport3
    {
        private int STT = 1;
        int page = 0;
        private int STT_nguoi = 1;
        private int stt_dong = 1;
        public string TruongKhoa;
        public string TruongKho;
        public string NguoiLinh;
        public string NguoiPhat;
        public string KhoThuoc;
        public string So;
        public bool isKhoaDongY = false;
        public rptPhieuLinhBenhNhan(string Khoa, DateTime Ngay,DateTime NgayHT)
        {
            //
            // Required for Windows Form Designer support
            //
            //DateTime NgayHT = Global.GlobalModules.GetNgayLV();
            InitializeComponent();
            lblKhoa.Text = Khoa.ToUpper() ;
            txtNgay1.Text = "Ngày " + Ngay.Day.ToString() + " tháng " + Ngay.Month.ToString() + " năm "+ Ngay.Year.ToString();
            txtngay2.Text = "Ngày " + NgayHT.Day.ToString() + " tháng " + NgayHT.Month.ToString() + " năm " + NgayHT.Year.ToString();
            
        }

        private void rptPhieuLinh_ReportStart(object sender, EventArgs e)
        {
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.PageSettings.Orientation = PageOrientation.Portrait;

            this.PageSettings.Margins.Left = (float)0.80;
            this.PageSettings.Margins.Right = (float)0.50;
            this.PageSettings.Margins.Top = (float)0.50;
            this.PageSettings.Margins.Bottom = (float)0.50;
            lblTruongKho.Text = TruongKho;
            lblTruongKhoa.Text = TruongKhoa;
            lblNguoiPhat.Text = NguoiPhat;
            lblNguoiLinh.Text = NguoiLinh;
            //pageBreak1.Enabled = isKhoaDongY;
            //pageBreak1.Enabled = false;
            pageBreak1.Height = 0;
            if (isKhoaDongY) { textBox9.DataField = "GhiChu"; }
            txtSo.Text = "Số: " + So;
            pageBreak1.Enabled = false;
        }

        private void detail_Format(object sender, EventArgs e)
        {
            //pageBreak1.Enabled = false;
            //if (((System.Data.SqlClient.SqlDataReader)this.DataSource). = false) { pageBreak1.Enabled = false; }
            label9.Text = STT.ToString();
            STT++;
            //stt_dong += 1;
            //if ((stt_dong % 35) == 0) 
            //{ 
            //    pageBreak2.Enabled = true; 
            //} 
            //else { pageBreak2.Enabled = false; }
        }

        private void detail_BeforePrint(object sender, EventArgs e)
        {
            label9.Height = textBox2.Height = textBox6.Height = textBox7.Height =textBox9.Height = detail.Height ;
        }

        private void groupHeader1_Format(object sender, EventArgs e)
        {
            STT = 1;
            textBox11.Text = STT_nguoi.ToString() + ". " + textBox11.Text;
            STT_nguoi += 1;
            //if (STT_nguoi > 2) { pageBreak1.Enabled = false; } else { pageBreak1.Enabled = true; }
            //pageBreak1.Enabled = true;
            //if (textBox11.Text == "1")
            //    textBox11.Text = "Thuốc";
            //else
            //    textBox11.Text = "Vật tư tiêu hao";
        }

        private void groupHeader1_BeforePrint(object sender, EventArgs e)
        {
            textBox11.Height = groupHeader1.Height+pageBreak1.Height;
            //pageBreak1.Enabled = true;
        }

        private void rptPhieuLinhBenhNhan_PageStart(object sender, EventArgs e)
        {
            page += 1;
            txtPage.Text = "Trang " + page.ToString() ;
        }
    }
}
