using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace NamDinh_QLBN.Reports
{
    /// <summary>
    /// Summary description for rptPhieuLinhThuoc.
    /// </summary>
    public partial class rptPhieuLinhVatTu : DataDynamics.ActiveReports.ActiveReport3
    {
        int page = 0, stt = 0;
        public rptPhieuLinhVatTu(string TenKhoa, string SoLuuTru, string title, string NhomKhoa)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            lblKhoa.Text = TenKhoa;
            lblSo.Text = "Số: " + SoLuuTru;
            lblTitle.Text = title;
            label10.Text = NhomKhoa;
            if (title.Contains("VẬT TƯ")) label11.Text = "TRƯỞNG PHÒNG VT";
            else label11.Text = "TRƯỞNG KHOA DƯỢC";
            this.Document.Name = "Phiếu lĩnh vật tư - thuốc dùng chung";
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.PageSettings.Orientation = PageOrientation.Portrait;
            this.PageSettings.Margins.Left = (float)0.4;
            this.PageSettings.Margins.Right = (float)0.25;
            this.PageSettings.Margins.Top = (float)0.25;
            this.PageSettings.Margins.Bottom = (float)0.10;
            label15.Text = string.Format("In ngày {0:dd} tháng {0:MM} năm {0:yyyy}", GlobalModuls.Global.NgayLV);
            if(TenKhoa== "Trung tâm Ung bướu")
            {
                label14.Text = "GIÁM ĐỐC TRUNG TÂM";
            }
        }

        private void rptPhieuLinhThuoc_ReportStart(object sender, EventArgs e)
        {

        }

        private void rptPhieulinhThuoc_PageStart(object sender, EventArgs e)
        {
            page += 1;
            txtPage.Text = "Trang " + page.ToString(); //+ "/";
        }

        private void groupHeader1_BeforePrint(object sender, EventArgs e)
        {

        }

        private void groupHeader1_Format(object sender, EventArgs e)
        {
            if (page > 1) page = 0;
            stt = 0;
            barcode1.Text = txtTenKho.Text == null ? "0" : txtTenKho.Text;
            lblBanSao.Text = txtBSao.Text;
        }

        private void detail_BeforePrint(object sender, EventArgs e)
        {
            STT.Text = string.Format("{0}", stt + 1);
            txtCongKhoan.Text = STT.Text;
            STT.Height = textBox1.Height = textBox2.Height = textBox3.Height = textBox4.Height = textBox5.Height = detail.Height;
            stt++;
        }
    }
}
