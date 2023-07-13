using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace NamDinh_QLBN.Reports
{
    /// <summary>
    /// Summary description for rptBCTonKho.
    /// </summary>
    public partial class rptBCSDTaiKhoaTongHop : DataDynamics.ActiveReports.ActiveReport3
    {
        public int intSTT = 0;
        public rptBCSDTaiKhoaTongHop()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
        }

        private void detail_BeforePrint(object sender, EventArgs e)
        {
            intSTT++;
            txtSTT.Text = intSTT.ToString();
            foreach (TextBox txt in detail.Controls)
            {
                detail.Height = txt.Height = txtTenThuoc.Height;
            }
        }
    }
}
