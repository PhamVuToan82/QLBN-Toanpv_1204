using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace NamDinh_QLBN.Reports.BaoCaoVeThuoc
{
    /// <summary>
    /// Summary description for rptPhieuLinhThuocDongY.
    /// </summary>
    public partial class rptPhieuLinhThuocDongY : DataDynamics.ActiveReports.ActiveReport3
    {

        int page = 0;
        public rptPhieuLinhThuocDongY(string TenKhoa, string Ngay)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            lblKhoa.Text = TenKhoa;
            lblNgayThang.Text = Ngay;
        }

        private void rptPhieuLinhThuocDongY_ReportStart(object sender, EventArgs e)
        {
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.PageSettings.Orientation = PageOrientation.Portrait;

            this.PageSettings.Margins.Left = (float)0.4;
            this.PageSettings.Margins.Right = (float)0.25;
            this.PageSettings.Margins.Top = (float)0.2;
            this.PageSettings.Margins.Bottom = (float)0.10;

            lblNgayIn.Text = string.Format("In ngày {0:dd} tháng {0:MM} năm {0:yyyy}", GlobalModuls.Global.NgayLV);
        }

        private void detail_Format(object sender, EventArgs e)
        {
            STT.Text = string.Format("{0}", int.Parse(STT.Text) + 1);
            if (textBox8.Text != textBox9.Text)
            {
                textBox8.Text = textBox9.Text;
                STT.Text = "1";
            }
        }

        private void pageFooter_Format(object sender, EventArgs e)
        {
        }

        private void rptPhieuLinhThuocDongY_PageStart(object sender, EventArgs e)
        {
            page += 1;
            txtPage.Text = "Trang " + page.ToString();
        }
    }
}
