using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using GlobalModuls;
namespace NamDinh_QLBN.Reports
{
    /// <summary>
    /// Summary description for rptGiayRaVien.
    /// </summary>
    public partial class rptGiayHenKhamLai : DataDynamics.ActiveReports.ActiveReport3
    {
        //private string MaVaoVien;
        public rptGiayHenKhamLai()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            //MaVaoVien = _MaVaoVien;
        }

        private void rptrptGiayHenKhamLai_ReportStart(object sender, EventArgs e) 
        {
            this.Document.Name = "Giấy hẹn khám lại";
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.PageSettings.Orientation = PageOrientation.Portrait;
            this.PageSettings.Margins.Left = (float)0.2;
            this.PageSettings.Margins.Right = (float)0.0;
            this.PageSettings.Margins.Top = (float)0.40;
            this.PageSettings.Margins.Bottom = (float)0.10;
        }
    }
}
