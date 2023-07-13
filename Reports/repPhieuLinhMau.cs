using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace NamDinh_QLBN.Reports
{
    /// <summary>
    /// Summary description for repPhieuLinhMau.
    /// </summary>
    public partial class repPhieuLinhMau : DataDynamics.ActiveReports.ActiveReport3
    {
        public repPhieuLinhMau(String Khoa,String InNgay,String NgaySD)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            lblKhoa.Text = Khoa;
            lblNgayThang.Text = InNgay;
            txtNgaySD.Text = NgaySD;
        }

        private void repPhieuLinhMau_ReportStart(object sender, EventArgs e)
        {
            this.PageSettings.Margins.Top = (float)0.7;
            this.PageSettings.Margins.Left = (float)0.8;
            this.PageSettings.Margins.Right = (float)0.0;
            this.PageSettings.Margins.Bottom = (float)0.5;
        }
    }
}
