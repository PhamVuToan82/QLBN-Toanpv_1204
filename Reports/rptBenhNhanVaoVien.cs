using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace NamDinh_QLBN.Reports
{
    /// <summary>
    /// Summary description for rptBenhNhanVaoVien.
    /// </summary>
    public partial class rptBenhNhanVaoVien : DataDynamics.ActiveReports.ActiveReport3
    {
        private int STT = 1;
        public rptBenhNhanVaoVien(string TuNgay,string DenNgay,string TenKhoa)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            lblNgayThang.Text = (TuNgay == DenNgay) ? ("Ngày " + TuNgay) : ("Từ ngày " + TuNgay + " đến ngày " + DenNgay);
            label12.Text = "DANH SÁCH BỆNH NHÂN " + ((TenKhoa =="")?(""):(" VÀO KHOA " + TenKhoa.ToUpper()));

        }

        private void rptBenhNhanVaoVien_ReportStart(object sender, EventArgs e)
        {
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.PageSettings.Orientation = PageOrientation.Portrait;

            this.PageSettings.Margins.Left = (float)0.60;
            this.PageSettings.Margins.Right = (float)0.10;
            this.PageSettings.Margins.Top = (float)0.50;
            this.PageSettings.Margins.Bottom = (float)0.50;
        }

        private void detail_Format(object sender, EventArgs e)
        {
            txtSTT.Text = STT.ToString();
            STT++;
        }
    }
}
