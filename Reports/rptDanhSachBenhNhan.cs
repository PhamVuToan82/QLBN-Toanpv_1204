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
    public partial class rptDanhSachBenhNhan : DataDynamics.ActiveReports.ActiveReport3
    {
        public double KyQuy = 0;
        public double DaThanhToan = 0;
        private int STT = 1;
        private bool KoData = false;
        public rptDanhSachBenhNhan(string TenKhoa,String NgayRaVien)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            lblTenKhoa.Text ="Khoa: " + TenKhoa;
            if (NgayRaVien != "")
            {
                label12.Text = "DANH SÁCH BỆNH NHÂN RA VIỆN NGÀY " + NgayRaVien;
            }
            else
            {
                label12.Text = "DANH SÁCH BỆNH NHÂN ĐANG ĐIỀU TRỊ";
            }
        }

        private void rptBenhNhan_ChiPhi_ReportStart(object sender, EventArgs e)
        {
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.PageSettings.Orientation = PageOrientation.Landscape;            
            this.PageSettings.Margins.Left =(float) 0.80;
            this.PageSettings.Margins.Right = (float)0.50;
            this.PageSettings.Margins.Top = (float)0.50;
            this.PageSettings.Margins.Bottom = (float)0.50;
        }

        private void detail_Format(object sender, EventArgs e)
        {
            txtSTT.Text = STT.ToString();
            STT++;
            if (KoData) return;
            textBox7.Text = (textBox7.Value.ToString() == "1") ? ("Nam") : ("Nữ");
        }
       
        private void reportFooter1_BeforePrint(object sender, EventArgs e)
        {
           
        }

        private void reportFooter1_Format(object sender, EventArgs e)
        {
            lblTongSo.Text = string.Format("{0:#,###}", STT - 1);
        }

        private void rptDanhSachBenhNhan_NoData(object sender, EventArgs e)
        {
            KoData = true;
        }
       
    }
}
