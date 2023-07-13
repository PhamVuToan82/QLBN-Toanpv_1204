using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using System.Data.SqlClient;
using System.Data;
using System.Data.SqlTypes;
namespace NamDinh_QLBN.Reports
{
    /// <summary>
    /// Summary description for NewActiveReport1.
    /// </summary>
    public partial class rptTongKetChiPhi_Mau02 : DataDynamics.ActiveReports.ActiveReport3
    {
        public double KyQuy = 0;
        public double DaThanhToan = 0;
        private int STT = 1,Page = 0,STT_Con = 0,STT_Sub = 0;
        string CacMuc = "";
        private object _TNgay, _DNgay;
        private string _MaLoaiThuoc_BHYT = "";
        private string _MaKhoa;
        public rptTongKetChiPhi_Mau02(string MaBenhNhan, string TenBN, string Tuoi, string GioiTinh, string DoiTuong, object NgayVaoVien, string DiaChi, string HanTheTu, string HanTheDen, string SoThe, string NoiCap, string Buong, string Giuong, object NgayRaVien, string ChanDoan, string NoiGioiThieu, String SoHSBA, string MaKhoa, string LoaiBenhAn, string Tuyen)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            _TNgay = NgayVaoVien;
            _DNgay = NgayRaVien;
            txtTuNgay.Value = _TNgay;
            txtTuNgay_Gio.Value = _TNgay;
            txtTuNgay_Phut.Value = _TNgay;
            txtDNgay.Value = txtDNgay_Gio.Value = txtDNgay_Phut.Value = _DNgay;
            DateTime _TNgay1 = new DateTime(((DateTime)_TNgay).Year, ((DateTime)_TNgay).Month, ((DateTime)_TNgay).Day);
            DateTime _DNgay1 = new DateTime(((DateTime)_DNgay).Year, ((DateTime)_DNgay).Month, ((DateTime)_DNgay).Day);
            System.TimeSpan NgayDT = (DateTime)_DNgay1 - (DateTime)_TNgay1;
            txtTongSoNgay.Value = NgayDT.Days == 0 ? 1 : NgayDT.Days;
            System.TimeSpan SoGioNamVien = (DateTime)NgayRaVien - (DateTime)NgayVaoVien;
            if (SoGioNamVien.TotalHours < 24)
            {
                txtTongSoNgay.Value = 1;
            }
            else
            {
                txtTongSoNgay.Value = NgayDT.Days + 1;
            }
            

            CacMuc = "";
            lblSoVaoVien.Text = MaBenhNhan; //"Mã vào viện: " +
            lbSoHSBA.Text = "Số vào viện: " + SoHSBA;
            lblHoTen.Text = TenBN;
            txtTuoi.Text = Tuoi;
            if (GioiTinh == "Nam") txtNam.Text = "X";
            else txtNu.Text = "X";
            txtDiaChi.Text = DiaChi;
            txtChanDoan.Text = ChanDoan;
            //lblBuong.Text = Buong;
            //lblGiuong.Text = Giuong;
            lbNoiChuyenDen.Text = "- Nơi giới thiệu: " + NoiGioiThieu;
            //_TNgay = _DNgay = GlobalModuls.Global.NgayLV;
            _TNgay = _DNgay = txtDNgay.Value;
            textBox19.Text = string.Format("Ngày {0:dd} tháng {0:MM} năm {0:yyyy}", _TNgay);
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
            if (HanTheTu   != "")
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
            if (Tuyen ==  "0")
            {
                txtDungTuyen.Text = "X";
                txtTraiTuyen.Text = "";
            }
            else
            {
                txtDungTuyen.Text = "";
                txtTraiTuyen.Text = "X";
            }

            _MaKhoa = MaKhoa;

            if (LoaiBenhAn == "1")
            {
                lbTieuDe.Text = "BẢNG KÊ CHI PHÍ KHÁM BỆNH, CHỮA BỆNH NGOẠI TRÚ";
                lbMauSo.Text = "Mẫu số: 01/BV";
            }
            else
            {
                lbTieuDe.Text = "BẢNG KÊ CHI PHÍ KHÁM, CHỮA BỆNH NỘI TRÚ";
                lbMauSo.Text = "Mẫu số 02/BV";
            }
        }

        private void rptBenhNhan_ChiPhi_ReportStart(object sender, EventArgs e)
        {
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.PageSettings.Orientation = PageOrientation.Portrait;
            
            this.PageSettings.Margins.Left =(float) 0.25;
            this.PageSettings.Margins.Right = (float)0;
            this.PageSettings.Margins.Top = (float)0.50;
            this.PageSettings.Margins.Bottom = (float)0.20;
            this.Fields.Add("TNgay1");
        } 


        private void detail_BeforePrint(object sender, EventArgs e)
        {
            foreach (TextBox txt in detail.Controls)
                txt.Height = detail.Height;
        }

        private void rptTongKetChiPhi_PageStart(object sender, EventArgs e)
        {
            //Page++;
            //txtPage.Text = string.Format("Trang: {0}/",Page);
        }

        private void groupFooter2_Format(object sender, EventArgs e)
        {

            //Page = 0;
        }

        private void groupHeader5_Format(object sender, EventArgs e)
        {
            //txtSTT.Text = STT.ToString();
            //CacMuc += STT.ToString() + " + ";
            //STT += 1;
            //STT_Sub = 0;
        }

        private void groupFooter5_Format(object sender, EventArgs e)
        {
            //txtCong.Text = "Cộng (" + txtSTT.Text + ")";
        }

        private void groupFooter4_BeforePrint(object sender, EventArgs e)
        {
            ////txtBangChu.Text += GlobalModuls.Global.WriteNum(long.Parse(txtTongTien.Text.Replace(".", "")));
            txtTongTien.Text = string.Format("{0:#,##0}", long.Parse(textBox60.Text.Replace(".", "")) + long.Parse(textBox61.Text.Replace(".", "")) + long.Parse(textBox62.Text.Replace(".", "")));
            if (txtTongTien.Text != "0") txt1.Text = GlobalModuls.Global.WriteNum(long.Parse(textBox60.Text.Replace(".", "")) + long.Parse(textBox61.Text.Replace(".", "")) + long.Parse(textBox62.Text.Replace(".", ""))) + " đồng";
            else txt1.Text = "";
            if (textBox60.Text != "0") txt2.Text = GlobalModuls.Global.WriteNum(long.Parse(textBox60.Text.Replace(".", ""))) + " đồng";
            else txt2.Text = "";
            if (textBox62.Text != "0") txt3.Text = GlobalModuls.Global.WriteNum(long.Parse(textBox62.Text.Replace(".", ""))) + " đồng";
            else txt3.Text = "";
            if (textBox61.Text != "0") txt4.Text = GlobalModuls.Global.WriteNum(long.Parse(textBox61.Text.Replace(".", ""))) + " đồng";
            else txt4.Text = "";
        }

        private void groupHeader4_Format(object sender, EventArgs e)
        {
            //txtSTT.Text = "0";
            //STT = 1;
            //CacMuc = "";
            //STT_Con = 0;
        }

        private void groupFooter4_Format(object sender, EventArgs e)
        {
            //CacMuc = CacMuc.Substring(0, CacMuc.Length - 3);
             
        }

        private void groupHeader1_Format(object sender, EventArgs e)
        {
            //if (Fields["MaLoaiDichVu_BHYT"].Value != null && Fields["DOITUONGBN"].Value.ToString() == "1"
            //    && (Fields["MaLoaiDichVu_BHYT"].Value.ToString() == "THUOC" || Fields["MaLoaiDichVu_BHYT"].Value.ToString() == "VATTU"))
            //{
            //    if (_MaLoaiThuoc_BHYT != Fields["MaLoaiDichVu_BHYT"].Value.ToString())
            //    {
            //        _MaLoaiThuoc_BHYT = Fields["MaLoaiDichVu_BHYT"].Value.ToString();
            //        STT_Con = 1;
            //    }
            //    else STT_Con += 1;
            //    txtSTT_Con.Text = string.Format("{0}.{1}", txtSTT.Text, STT_Con.ToString());
            //    groupHeader1.Visible = true;
            //}
            //else
            //{
            //    STT_Con = 0;
            //    groupHeader1.Visible = false;
            //}
        }

        private void rptTongKetChiPhi_NhomTheoLoaiBHYT_FetchData(object sender, FetchEventArgs eArgs)
        {
            //if (eArgs.EOF)
            //{
            //}
            //else
            //{
            //    if (Fields["SoThe"].Value.ToString().Length == 15)
            //    {
            //        txtBH1.Text = Fields["SoThe"].Value.ToString().Substring(0, 2);
            //        txtBH2.Text = Fields["SoThe"].Value.ToString().Substring(2, 1);
            //        txtBH3.Text = Fields["SoThe"].Value.ToString().Substring(3, 2);
            //        txtBH4.Text = Fields["SoThe"].Value.ToString().Substring(5, 2);
            //        txtBH5.Text = Fields["SoThe"].Value.ToString().Substring(7, 3);
            //        txtBH6.Text = Fields["SoThe"].Value.ToString().Substring(10, 5);
            //    }
            //    if (Fields["DOITUONGBN"].Value.ToString() == "1")
            //    {
            //        textBox21.Text = "X";
            //        textBox22.Text = "";
            //    }
            //    else
            //    {
            //        textBox21.Text = "";
            //        textBox22.Text = "X";
            //        txtBH1.Text = "";
            //        txtBH2.Text = "";
            //        txtBH3.Text = "";
            //        txtBH4.Text = "";
            //        txtBH5.Text = "";
            //        txtBH6.Text = "";
            //    }
            //    if (Fields["tuyen"].Value.ToString() == "0" || Fields["tuyen"].Value.ToString().ToUpper() == "false")
            //    {
            //        txtDungTuyen.Text = "X";
            //        txtTraiTuyen.Text = "";
            //    }
            //    else
            //    {
            //        txtDungTuyen.Text = "";
            //        txtTraiTuyen.Text = "X";
            //    }


                //if (Fields["MaLoaiDichVu_BHYT"].Value.ToString() == "THUOC" || Fields["MaLoaiDichVu_BHYT"].Value.ToString() == "VATTU" || Fields["TENLOAIDICHVU"].Value.ToString() == "")
                //{
                //    groupHeader6.Visible = false;
                //}
                //else
                //{
                //    groupHeader6.Visible = true;
                //}
            //}
        }

        private void groupHeader3_Format(object sender, EventArgs e)
        {
            //STT_Con = 0;
        }

        private void groupHeader2_Format(object sender, EventArgs e)
        {
            //STT_Con = 0;
        }

        private void groupHeader6_Format(object sender, EventArgs e)
        {
            //STT_Sub += 1;
            //txtSTT_Sub.Text = string.Format("{0}.{1}", txtSTT.Text, STT_Sub);
        }
    }
}
