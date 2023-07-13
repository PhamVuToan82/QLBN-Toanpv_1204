using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace NamDinh_QLBN.Reports
{
    /// <summary>
    /// Summary description for repDonThuoc.
    /// </summary>
    public partial class rptDonThuocRV : DataDynamics.ActiveReports.ActiveReport3
    {
        private object _NgayChiDinh;
        private String _BacSy = "";
        int SoKhoan = 0;
        public rptDonThuocRV(object NgayChiDinh, String BacSy,string LoiDan)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            _NgayChiDinh = NgayChiDinh;
            _BacSy = BacSy;
            txtLoidan.Text = LoiDan;
            lblKhoa.Text = GlobalModuls.Global.glbTenKhoaPhong;
        }

        private void repDonThuoc_ReportStart(object sender, EventArgs e)
        {
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A5;
            this.PageSettings.Orientation = PageOrientation.Portrait;
            this.PageSettings.Margins.Top = (float)0.3;
            this.PageSettings.Margins.Left = (float)0.15;
            this.PageSettings.Margins.Right = (float)0.0;
            this.PageSettings.Margins.Bottom = (float)0.3;
            lblNgayThang.Text = String.Format("Ngày {0:dd} tháng {0:MM} năm {0:yyyy}", _NgayChiDinh);
            lblBacSy.Text = _BacSy;
        }

        private void repDonThuoc_DataInitialize(object sender, EventArgs e)
        {
            
        }

        private void detail_Format(object sender, EventArgs e)
        {
            lblSTT.Text = string.Format("{0}", int.Parse(lblSTT.Text) + 1);
            SoKhoan += 1;
        }

        private void rptDonThuocRV_ReportEnd(object sender, EventArgs e)
        {
            
        }

        private void detail_BeforePrint(object sender, EventArgs e)
        {
             Single h= detail.Height;
           lblSTT.Height = h;
           TextBox1.Height = h;
           TextBox2.Height = h;
           TextBox3.Height = h;
           TextBox6.Height = h;
       
        }

        private void reportFooter1_Format(object sender, EventArgs e)
        {
            txtSoKhoan.Text = SoKhoan.ToString();
        }
    }
}
