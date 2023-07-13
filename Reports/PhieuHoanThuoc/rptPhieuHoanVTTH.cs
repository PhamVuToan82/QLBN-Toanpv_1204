using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace NamDinh_QLBN.Reports.PhieuHoanThuoc
{
    /// <summary>
    /// Summary description for rptPhieuLinhThuoc.
    /// </summary>
    public partial class rptPhieuHoanVTTH : DataDynamics.ActiveReports.ActiveReport3
    {
        int page = 0;
        public rptPhieuHoanVTTH(string TenKhoa, string Ngay, string SoLuuTru,string title)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            lblKhoa.Text = TenKhoa;
            lblNgayThang.Text = Ngay;
            lblSo.Text = "Số: " + SoLuuTru;
            lblTitle.Text = title;
            if (title.Contains("VẬT TƯ")) lblTrgKhoa.Text = "TRƯỞNG PHÒNG VT";
            else lblTrgKhoa.Text = "TRƯỞNG KHOA DƯỢC";
        }

        private void rptPhieuLinhThuoc_ReportStart(object sender, EventArgs e)
        {
            this.Document.Name = "Phiếu hoàn thuốc";
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.PageSettings.Orientation = PageOrientation.Portrait;

            this.PageSettings.Margins.Left = (float)0.4;
            this.PageSettings.Margins.Right = (float)0.25;
            this.PageSettings.Margins.Top = (float)1;
            this.PageSettings.Margins.Bottom = (float)0.10;

            lblNgayIn.Text = string.Format("In ngày {0:dd} tháng {0:MM} năm {0:yyyy}", GlobalModuls.Global.NgayLV);
        }

        private void detail_Format(object sender, EventArgs e)
        {
            STT.Text = string.Format("{0}", int.Parse(STT.Text) + 1);

            txtCongKhoan.Text = STT.Text+" khoản";
            if (int.Parse(STT.Text) == 26)
            {
                t1.Visible = t2.Visible = t3.Visible = t4.Visible = t5.Visible = true;
                pageBreak1.Enabled = true;
                STT.Text = "1";
            }
            else
            {
                pageBreak1.Enabled = false;
                t1.Visible = t2.Visible = t3.Visible = t4.Visible = t5.Visible = false;
            }
        }

        private void detail_BeforePrint(object sender, EventArgs e)
        {
            STT.Height = textBox1.Height = textBox2.Height = textBox3.Height = textBox4.Height = txtDonGia.Height = txtThanhTien.Height = detail.Height;
        }


        private void reportFooter1_Format(object sender, EventArgs e)
        {
        }

        private void groupHeader1_Format(object sender, EventArgs e)
        {
            page = 0;
            STT.Text = "0";
        }

        private void rptPhieulinhThuoc_PageStart(object sender, EventArgs e)
        {
            page += 1;
            txtPage.Text = "Trang " + page.ToString() + "/";
        }

        private void groupHeader1_BeforePrint(object sender, EventArgs e)
        {
            lblMaPhieuHoan.Text = txtTenKho.Text == null ? "0" : txtTenKho.Text;
        }

        private void pageFooter_Format(object sender, EventArgs e)
        {
        }

        private void rptPhieuLinhThuoc_Sua_FetchData(object sender, FetchEventArgs eArgs)
        {
        }

        private void rptPhieuLinhThuoc_Sua_ReportEnd(object sender, EventArgs e)
        {
        }
    }
}
