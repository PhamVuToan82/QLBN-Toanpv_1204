using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;
using GlobalModuls;
using System.Data.SqlClient;
using Microsoft.VisualBasic;
using NamDinh_QLBN.Reports;

namespace NamDinh_QLBN.Reports.PhauThuat
{
    /// <summary>
    /// Summary description for rptChiPhiPT.
    /// </summary>
    public partial class rptChiPhiPT_Mau02 : DataDynamics.ActiveReports.ActiveReport3
    {
        int STT_Loai = 0;
        int _MucHuong = 0;
        public rptChiPhiPT_Mau02(string MaVaoVien, string TenBN, string Tuoi, string GioiTinh, string DoiTuong, object NgayVaoVien, object NgayPT, string DiaChi, string HanTheTu, string HanTheDen, string SoThe, string NoiCap, string Buong, string Giuong, object NgayRaVien, string ChanDoan, string NoiGioiThieu, String SoHSBA, string MaKhoa, string LoaiBenhAn, string Tuyen, string MaBenh, int MucHuong)
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
             
            txtNgayThang.Text = string.Format("Ngày {0:dd} tháng {0:MM} năm {0:yyyy}",  Convert.ToDateTime(NgayPT));  
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
            _MucHuong = MucHuong; 
        }

        private void rptChiPhiPT_ReportStart(object sender, EventArgs e)
        {
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.PageSettings.Margins.Top = (float)0.5;
            this.PageSettings.Margins.Left = (float)0.4;
            this.PageSettings.Margins.Right = (float)0.1;
            this.PageSettings.Margins.Bottom = (float)0.5;
            this.Document.Name = "Phiếu thống kê chi phí phẫu thuật";
            STT_Loai = 0;
        }

        private void detail_Format(object sender, EventArgs e)
        {
            STT.Text = string.Format("{0}", int.Parse(STT.Text) + 1);

        }

        private void groupHeader1_Format(object sender, EventArgs e)
        {
            STT.Text = "0";
            STT_Loai += 1;
            txtSoTT_Loai.Text = STT_Loai.ToString();
        }

        private void detail_BeforePrint(object sender, EventArgs e)
        {
            STT.Height = textBox2.Height = textBox3.Height = textBox4.Height = textBox5.Height = txtBNTra_Detail.Height = txtThanhtien_Detail.Height = detail.Height;
        }

        private void groupHeader2_Format(object sender, EventArgs e)
        {
            STT_Loai +=0;
        }

        private void groupFooter2_BeforePrint(object sender, EventArgs e)
        {
            //if (txtTongTien.Text != "0") txt1.Text = GlobalModuls.Global.WriteNum(long.Parse(textBox60.Text.Replace(".", "")) + long.Parse(textBox61.Text.Replace(".", "")) + long.Parse(textBox62.Text.Replace(".", ""))) + " đồng";
            //else txt1.Text = "";
            //MessageBox.Show(txt1.Text.Replace(".", "").Replace(",", "."));
            //txtBangChu.Text = "Số tiền ghi bằng chữ: " + GlobalModuls.Global.WriteNum((int)Math.Round(Convert.ToDouble(txt1.Text))).Replace(".", "") + " đồng";
            //if(txt1.Text.Trim()=="") txt1.Text="0";
            ////MessageBox.Show(txt1.Text);
            //if (txt1.Text != "0") txtBangChu.Text = "Số tiền ghi bằng chữ: " + GlobalModuls.Global.WriteNum((int)Math.Round(Convert.ToDouble(txt1.Text))).Replace(".", "") + " đồng";
            //else txtBangChu.Text = "Số tiền ghi bằng chữ: ";
            // MessageBox.Show("đến 1");
            if ((int)Math.Round(Convert.ToDouble(txt1.Text)) > 45 * GlobalModuls.Global.LuongCB)
            {
                //MessageBox.Show("Lớn hơn 45 tháng");
                //MessageBox.Show(Convert.ToString((GlobalModuls.Global.LuongCB)));
                ////txtBHTra.Text = Convert.ToString(45 * GlobalModuls.Global.LuongCB * _MucHuong / 100);
                ////txtBNTra.Text = Convert.ToString(((int)Math.Round(Convert.ToDouble(txt1.Text)) - (45 * GlobalModuls.Global.LuongCB * _MucHuong / 100)));

                //MessageBox.Show(Convert.ToString(  _MucHuong / 100));
                //MessageBox.Show(Convert.ToString(45 * GlobalModuls.Global.LuongCB * _MucHuong));
            }
            else
            {
                //MessageBox.Show("Nhỏ hơn 45 tháng");
                //MessageBox.Show(txt1.Text);
                //MessageBox.Show(Convert.ToString(_MucHuong) );
                //long temp = (long)Math.Round(Convert.ToDouble(txt1.Text.Replace(".", "")));
                //MessageBox.Show(Convert.ToString(temp));
                //temp = temp * 90;
                //MessageBox.Show(Convert.ToString(temp));
                //txtBHTra.Text = Convert.ToString(((long)Math.Round(Convert.ToDouble(txt1.Text.Replace(".", ""))) * _MucHuong / 100));
                //txtBNTra.Text = Convert.ToString(((long)Math.Round(Convert.ToDouble(txt1.Text)) - (((long)Math.Round(Convert.ToDouble(txt1.Text)) * _MucHuong / 100))));
                //MessageBox.Show(txtBHTra.Text);
                //MessageBox.Show(txtBNTra.Text);
            }
            //MessageBox.Show("đến 2");
            //txt2.Text = string.Format("{0:#,##0}", (int)Math.Round(Convert.ToDouble(txtBHTra.Text)));
            //txt3.Text = string.Format("{0:#,##0}", (int)Math.Round(Convert.ToDouble(txtBNTra.Text)));
            ////txtBHTra.Text = string.Format("{0:#,##0}", (int)Math.Round(Convert.ToDouble(txtBHTra.Text)));
            //txtBNTra.Text = string.Format("{0:#,##0}", (int)Math.Round(Convert.ToDouble(txtBNTra.Text)));
        }

        private void reportFooter1_Format(object sender, EventArgs e)
        {

        }

        private void reportFooter1_BeforePrint(object sender, EventArgs e)
        {
            
        }
        
    }
}
