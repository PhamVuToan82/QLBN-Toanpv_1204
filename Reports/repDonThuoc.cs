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
    public partial class repDonThuoc : DataDynamics.ActiveReports.ActiveReport3
    {
        private object _NgayChiDinh;
        private String _BacSy = "";
        public repDonThuoc(object NgayChiDinh,String BacSy)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            _NgayChiDinh = NgayChiDinh;
            _BacSy = BacSy;
        }

        private void repDonThuoc_ReportStart(object sender, EventArgs e)
        {
            this.PageSettings.Margins.Top = (float)0.7;
            this.PageSettings.Margins.Left = (float)0.5;
            this.PageSettings.Margins.Right = (float)0.4;
            this.PageSettings.Margins.Bottom = (float)0.5;
            lblNgayThang.Text = String.Format("Ngày {0:dd} tháng {0:MM} năm {0:yyyy}", _NgayChiDinh);
            lblBacSy.Text = _BacSy;
        }

        private void repDonThuoc_DataInitialize(object sender, EventArgs e)
        {
            
        }

        private void detail_Format(object sender, EventArgs e)
        {
            lblSTT.Text = string.Format("{0}", int.Parse(lblSTT.Text) + 1);
        }
    }
}
