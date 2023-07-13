using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace NamDinh_QLBN.Reports.PhauThuat
{
    /// <summary>
    /// Summary description for rptChiPhiPT.
    /// </summary>
    public partial class rptChiPhiPT_Mau02_Luu : DataDynamics.ActiveReports.ActiveReport3
    {

        public rptChiPhiPT_Mau02_Luu(string MaVaoVien, string TenBN, string Tuoi, string GioiTinh, string DoiTuong, object NgayVaoVien, object NgayPT, string DiaChi, string HanTheTu, string HanTheDen, string SoThe, string NoiCap, string Buong, string Giuong, object NgayRaVien, string ChanDoan, string NoiGioiThieu, String SoHSBA, string MaKhoa, string LoaiBenhAn, string Tuyen, string MaBenh)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            lblSoVaoVien.Text = MaVaoVien;
            lblHoTen.Text = TenBN.ToUpper();
            txtTuoi.Text = Tuoi;
            if (GioiTinh.ToUpper() == "NAM")
            {
                txtNam.Text = "X";
                txtNu.Text = "";
            }
            else
            {
                txtNam.Text = "";
                txtNu.Text = "X";
            }
            txtDiaChi.Text = DiaChi; 
            txtTuNgay_Gio.Text = string.Format("{0:HH}", NgayVaoVien);
            txtTuNgay_Phut.Text = string.Format("{0:mm}", NgayVaoVien);
            txtTuNgay.Text = string.Format( "{0:dd/MM/yyyy}", NgayVaoVien);
            txtNoiDKKCBBD.Text = NoiCap;
            txtMaBC.Text = MaBenh;
            txtNgayThang.Text = string.Format("Ngày {0:dd/MM/yyyy}", NgayPT);  
            txtChanDoan.Text = ChanDoan.ToUpper();
            //lblChiDinh.Text = ChiDinh;
            //lblTenTK.Text = BsGayMe;
            //lblDieuDuong.Text = DieuDuong;
            if (SoThe.Length == 20)
            {
                txtBH1.Text = SoThe.Substring(0, 2);
                txtBH2.Text = SoThe.Substring(2, 1);
                txtBH3.Text = SoThe.Substring(3, 2);
                txtBH4.Text = SoThe.Substring(5, 2);
                txtBH5.Text = SoThe.Substring(7, 3);
                txtBH6.Text = SoThe.Substring(10, 5);
                txtMaNoiKhamCB.Text = SoThe.Substring(15, 5);
            }
            if (DoiTuong.ToUpper() == "BẢO HIỂM Y TẾ")
            {
                textBox21.Text = "X";
                textBox22.Text = "";
            }
            else
            {
                textBox21.Text = "";
                textBox22.Text = "X";
                txtBH1.Text = "";
                txtBH2.Text = "";
                txtBH3.Text = "";
                txtBH4.Text = "";
                txtBH5.Text = "";
                txtBH6.Text = "";
                txtMaNoiKhamCB.Text = "";
            }
            if (HanTheTu != "")
            {
                txtGiaTriTu.Text = HanTheTu;
            }
            else
            {
                txtGiaTriTu.Text = "";
            }
            if (HanTheDen != "")
            {
                txtGiaTriDen.Text = HanTheDen;
            }
            else
            {
                txtGiaTriDen.Text = "";
            }
            if (Tuyen == "0")
            {
                txtDungTuyen.Text = "X";
                txtTraiTuyen.Text = "";
            }
            else
            {
                txtDungTuyen.Text = "";
                txtTraiTuyen.Text = "X";
            }
        }

        private void rptChiPhiPT_ReportStart(object sender, EventArgs e)
        {
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.PageSettings.Margins.Top = (float)0.5;
            this.PageSettings.Margins.Left = (float)0.4;
            this.PageSettings.Margins.Right = (float)0.1;
            this.PageSettings.Margins.Bottom = (float)0.5;
            this.Document.Name = "Phiếu thống kê chi phí phẫu thuật";
        }

        private void detail_Format(object sender, EventArgs e)
        {
            STT.Text = string.Format("{0}", int.Parse(STT.Text) + 1);
        }

        private void groupHeader1_Format(object sender, EventArgs e)
        {
            STT.Text = "0";
        }

        private void detail_BeforePrint(object sender, EventArgs e)
        {
            STT.Height = textBox2.Height = textBox3.Height = textBox4.Height = textBox5.Height = textBox6.Height = detail.Height;
        }
    }
}
