
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using System.Data.SqlClient;
using DataDynamics.ActiveReports.Viewer;
using System.Data;
using System.Data.SqlTypes;
namespace NamDinh_QLBN.Reports
{
    /// <summary>
    /// Summary description for NewActiveReport1.
    /// </summary>
    public partial class rptTongKetChiPhi_NhomTheoLoaiBHYT_6556_Covid : DataDynamics.ActiveReports.ActiveReport3
    {
        public double KyQuy = 0;
        public double DaThanhToan = 0;
        public double ThanhTienBHYT,BHYTtra,Benhnhantra, Tutra,TongTien;
        public double Chenh_ThanhTienBHYT, Chenh_BHYTtra, Chenh_Benhnhantra, Chenh_Tutra;
        private int STT = 1,Page = 0,STT_Con = 0,STT_Sub = 0;
        string CacMuc = "";
        private object _TNgay, _DNgay, _NGAYKHAM;
        private string _MaLoaiThuoc_BHYT = "";
        private string _MaKhoa;
        string _capcuu = "";
        string tuyen = "";
        DateTime TgDu5Nam;
        DateTime ThoiDiemMienChiTraTrongNam;
        public rptTongKetChiPhi_NhomTheoLoaiBHYT_6556_Covid(string MaBenhNhan, string TenBN, string Tuoi, string GioiTinh, string DoiTuong, object NgayVaoVien, string DiaChi, string HanTheTu, string HanTheDen, string SoThe, string NoiCap, string Buong, string Giuong, DateTime NgayRaVien, string ChanDoan, string NoiGioiThieu, String SoHSBA,string MaKhoa,string LoaiBenhAn,string CapCuu, DateTime NGAYKHAM)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            _TNgay = NgayVaoVien;
            _DNgay = NgayRaVien;
            _NGAYKHAM = NGAYKHAM;
            textBox92.Value = _TNgay;
            textBox90.Value = _TNgay;
            textBox37.Value = _TNgay;

            _capcuu = CapCuu;
            textBox93.Value = textBox95.Value = textBox97.Value = _DNgay;
            textBox104.Value = textBox105.Value = textBox101.Value = _NGAYKHAM;
            DateTime _TNgay1 = new DateTime(((DateTime)_TNgay).Year, ((DateTime)_TNgay).Month, ((DateTime)_TNgay).Day);
            DateTime _DNgay1 = new DateTime(((DateTime)_DNgay).Year, ((DateTime)_DNgay).Month, ((DateTime)_DNgay).Day);
            System.TimeSpan NgayDT = (DateTime)_DNgay1 - (DateTime)_TNgay1;
            textBox45.Value = NgayDT.Days == 0 ? 1 : NgayDT.Days;
            System.TimeSpan SoGioNamVien = (DateTime)NgayRaVien - (DateTime)NgayVaoVien;
            if (SoGioNamVien.TotalHours < 24)
            {
                textBox45.Value = 1;
            }
            else
            {
                textBox45.Value = NgayDT.Days + 1;
            }
            

            CacMuc = "";
            barcode1.Text = MaBenhNhan; //"Mã vào viện: " +
            label10.Text = "Số vào viện: " + SoHSBA;
            textBox21.Text = TenBN;
            textBox22.Text = Tuoi;
            if (GioiTinh == "Nam") textBox41.Text = "Nam";
            else textBox41.Text = "Nữ";
            textBox24.Text = DiaChi;
            textBox38.Text = ChanDoan;
            textBox35.Text = NoiGioiThieu;
            _TNgay = _DNgay = textBox93.Value;
            textBox116.Text = string.Format("Ngày {0:dd} tháng {0:MM} năm {0:yyyy}", _TNgay);
            _MaKhoa = MaKhoa;

            if (LoaiBenhAn == "1")
            {
                label41.Text = "BẢNG KÊ CHI PHÍ ĐIỀU TRỊ NGOẠI TRÚ";
                textBox98.Text = "2";
            }
            else
            {
                label41.Text = "BẢNG KÊ CHI PHÍ ĐIỀU TRỊ NỘI TRÚ";
                textBox98.Text = "3";
            }
            if(SoThe.Length == 7|| SoThe.Length == 0)
            {
                textBox70.Text = "";textBox84.Text = "";textBox85.Text = "";textBox86.Text = "";
            }
            else
            {
                textBox70.Text = SoThe.Substring(0, 2).ToString(); textBox84.Text = SoThe.Substring(2, 1).ToString(); textBox85.Text = SoThe.Substring(3, 2).ToString(); textBox86.Text = SoThe.Substring(5, 10).ToString();textBox100.Text = SoThe.Substring(15,5).ToString() ;
/*                textBox48.Text = Fields["TheBHYT"].Value.ToString().Substring(0, 2).ToString(); textBox49.Text = Fields["TheBHYT"].Value.ToString().Substring(2, 1).ToString(); textBox50.Text = Fields["TheBHYT"].Value.ToString().Substring(3, 2).ToString(); textBox51.Text = Fields["TheBHYT"].Value.ToString().Substring(5, 10).ToString();*/// textBox100.Text = SoThe.Substring(10, 5).ToString();
            }
            textBox25.Text = HanTheTu;
            textBox27.Text = HanTheDen;textBox33.Text = HanTheTu;textBox46.Text = HanTheDen;

        }

        private void rptBenhNhan_ChiPhi_ReportStart(object sender, EventArgs e)
        {
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.PageSettings.Orientation = PageOrientation.Landscape;
            this.PageSettings.Margins.Left =(float) 0.25;
            this.PageSettings.Margins.Right = (float)0;
            this.PageSettings.Margins.Top = (float)0.50;
            this.PageSettings.Margins.Bottom = (float)0.20;
            //this.Fields.Add("TNgay1");
        } 


        private void detail_BeforePrint(object sender, EventArgs e)
        {
            foreach (TextBox txt in detail.Controls)
                txt.Height = detail.Height;
            //if(Fields["isPhieudieutri_chitiet_covid"].Value.ToString() == "1")
            //{
            //    textBox47.Text = textBox56.Text;
            //}
            //else
            //{
            //    textBox56.Text = Fields["ct_NBTutra"].Value.ToString();
            //}
        }

        private void rptTongKetChiPhi_PageStart(object sender, EventArgs e)
        {
            Page++;
            txtPage.Text = string.Format("Trang: {0}", Page);
        }

        private void groupFooter2_Format(object sender, EventArgs e)
        {

            Page = 0;
        }

        private void groupHeader5_Format(object sender, EventArgs e)
        {
            ////txtSTT.Text = STT.ToString();
            ////CacMuc += STT.ToString() + " + ";
            ////STT += 1;
            ////STT_Sub = 0;
        }

        private void groupFooter5_Format(object sender, EventArgs e)
        {
            ////txtCong.Text = "Cộng (" + txtSTT.Text + ")";
        }

        private void groupFooter4_BeforePrint(object sender, EventArgs e)
        {
     
        }

        private void groupHeader4_BeforePrint(object sender, EventArgs e)
        {
        }
        private void groupHeader4_Format(object sender, EventArgs e)
        {
            if (Fields["DoiTuongBN"].Value.ToString() == "3")
            {
                textBox48.Text = textBox49.Text = textBox50.Text = textBox51.Text = textBox117.Text = "";
                textBox33.Text = textBox46.Text = "";
            }
            else
            {
                textBox48.Text = Fields["TheBHYT"].Value.ToString();
                textBox48.Text = Fields["TheBHYT"].Value.ToString().Substring(0, 2).ToString(); textBox49.Text = Fields["TheBHYT"].Value.ToString().Substring(2, 1).ToString(); textBox50.Text = Fields["TheBHYT"].Value.ToString().Substring(3, 2).ToString(); textBox51.Text = Fields["TheBHYT"].Value.ToString().Substring(5, 10).ToString();
            }
        }

        private void reportFooter1_AfterPrint(object sender, EventArgs e)
        {
            double TongThanhTienBHYT, TongBHYT, TongBNCC, TongBNTutra;
            double TT = Convert.ToDouble(textBox118.Text);
            TongThanhTienBHYT = TT - (Chenh_ThanhTienBHYT - ThanhTienBHYT);
            textBox118.Text = string.Format("{0:#,##0.##}", TongThanhTienBHYT);
            double TTBHYT = Convert.ToDouble(textBox62.Text);
            TongBHYT = TTBHYT - (Chenh_BHYTtra - BHYTtra);
            textBox62.Text = string.Format("{0:#,##0.##}", TongBHYT);
            double TTBNCCT = Convert.ToDouble(textBox119.Text);
            TongBNCC = TTBNCCT - (Chenh_Benhnhantra - Benhnhantra);
            textBox119.Text = string.Format("{0:#,##0.##}", TongBNCC);
            TongBNTutra = Convert.ToDouble(textBox82.Text) + Tutra;
            //textBox82.Text = string.Format("{0:#,##0.##}", Convert.ToDouble(textBox60.Text) - Convert.ToDouble(textBox118.Text)); ;
            textBox153.Text = " " + textBox60.Text + " Đồng";
            string s1 = textBox60.Text.Substring(0, textBox60.Text.Length); // Tiền BV
            string s3 = textBox119.Text.Substring(0, textBox119.Text.Length); // BN CCT
            string s2 = textBox62.Text.Substring(0, textBox62.Text.Length); //BHYT CCT
            string s4 = textBox82.Text.Substring(0, textBox82.Text.Length); //BNTT
            if (textBox60.Text != "0")
            {
                textBox8.Text = GlobalModuls.Global.WriteNum(long.Parse(s1.Replace(".", ""))) + " đồng";
            }
            else textBox8.Text = "";
            if (textBox60.Text != "0")
            {
                if (s2 == "0")
                {
                    textBox19.Text = "";
                }
                else textBox19.Text = GlobalModuls.Global.WriteNum(long.Parse(s2.Replace(".", ""))) + " đồng";
            }
            if (textBox60.Text != "0")
            {
                long a = (long.Parse(s3.Replace(".", "")) + long.Parse(s4.Replace(".", "")));
                if (a == 0)
                {
                    textBox30.Text = "";
                }
                else textBox30.Text = GlobalModuls.Global.WriteNum(long.Parse(s3.Replace(".", "")) + long.Parse(s4.Replace(".", ""))) + " đồng";
            }
            if (textBox60.Text != "0")
            {
                if (s4 == "0")
                {
                    textBox158.Text = "";
                }
                else textBox158.Text = GlobalModuls.Global.WriteNum(long.Parse(string.Format("{0:#,##0.##}", Convert.ToDouble(textBox60.Text) - Convert.ToDouble(textBox118.Text)).Replace(".", ""))) + " đồng";
            }

            if (textBox60.Text != "0")
            {
                if (s3 == "0")
                {
                    textBox156.Text = "";
                }
                else textBox156.Text = GlobalModuls.Global.WriteNum(long.Parse(s3.Replace(".", ""))) + " đồng";
            }
        }

        private void groupFooter4_Format(object sender, EventArgs e)
        {
            //CacMuc = CacMuc.Substring(0, CacMuc.Length - 3);
        }

        private void groupHeader1_Format(object sender, EventArgs e)
        {
            string sothutumuc = Fields["ThuTuIn_DichVu"].Value.ToString();
                if (Fields["MaLoaiDichVu_BHYT"].Value != null )
                {
                        STT_Con += 1;
                        textBox123.Text = string.Format("{0}.{1}", sothutumuc, STT_Con);
                    if (Fields["TenLoaiDichvu"].Value.ToString() == "Thăm dò chức năng" || Fields["TenLoaiDichvu"].Value.ToString() == "Khám bệnh và KTSK" || Fields["TenLoaiDichvu"].Value.ToString() == "Thuốc, hóa chất, vật tư,Oxy" || Fields["TenLoaiDichvu"].Value.ToString() == "Ngày giường bệnh" || Fields["TenLoaiDichvu"].Value.ToString() == "Máu và các chế phẩm máu")
                    {
                        groupHeader1.Visible = false;
          
                    }
                    else groupHeader1.Visible = true;
                }
                else
                {
                    
                    STT_Con = 0;
                }
        }
        private void groupHeader5_BeforePrint(object sender, EventArgs e)
        {
            if (textBox120.Text == "Khoa gây mê hồi sức")
            {
                if ((int)Math.Round(Convert.ToDouble(textBox161.Text)) > 45 * GlobalModuls.Global.LuongCB)
                {
                    textBox161.Text = string.Format("{0:#,##0.##}", (45 * GlobalModuls.Global.LuongCB));
                    textBox162.Text = string.Format("{0:#,##0.##}", (45 * GlobalModuls.Global.LuongCB) * Convert.ToDouble(textBox117.Text) / 100);
                    textBox163.Text = string.Format("{0:#,##0.##}", Convert.ToDouble(textBox161.Text) - Convert.ToDouble(textBox162.Text));
                    textBox165.Text = string.Format("{0:#,##0.##}", Convert.ToDouble(textBox159.Text) - Convert.ToDouble(textBox161.Text));
                }

            }

        }
        private void groupHeader6_BeforePrint(object sender, EventArgs e)
        {

            if (textBox121.Text == "Gói vật tư y tế")
            {
                if ((int)Math.Round(Convert.ToDouble(textBox146.Text)) > 45 * GlobalModuls.Global.LuongCB)
                {
                    textBox146.Text = string.Format("{0:#,##0.##}", (45 * GlobalModuls.Global.LuongCB));
                    textBox147.Text = string.Format("{0:#,##0.##}", (45 * GlobalModuls.Global.LuongCB) * Convert.ToDouble(textBox117.Text) / 100);
                    textBox148.Text = string.Format("{0:#,##0.##}", Convert.ToDouble(textBox146.Text) - Convert.ToDouble(textBox147.Text));
                    textBox150.Text = string.Format("{0:#,##0.##}", Convert.ToDouble(textBox144.Text) - Convert.ToDouble(textBox146.Text));
                    ThanhTienBHYT = Convert.ToDouble(textBox146.Text);
                    BHYTtra = Convert.ToDouble(textBox147.Text); 
                    Benhnhantra = Convert.ToDouble(textBox148.Text);
                }

            }
        }
        private void groupHeader1_BeforePrint(object sender, EventArgs e)
        {
            if ((int)Math.Round(Convert.ToDouble(textBox139.Text)) > 45 * GlobalModuls.Global.LuongCB)
            {
                Chenh_ThanhTienBHYT = Convert.ToDouble(textBox139.Text);
                Chenh_BHYTtra = Convert.ToDouble(textBox140.Text);
                Chenh_Benhnhantra = Convert.ToDouble(textBox141.Text);
            }

        }
        private void reportFooter1_BeforePrint(object sender, EventArgs e)
        {

            double TongThanhTienBHYT, TongBHYT, TongBNCC, TongBNTutra;
            double TT = Convert.ToDouble(textBox118.Text);
            TongThanhTienBHYT = TT - (Chenh_ThanhTienBHYT - ThanhTienBHYT);
            textBox118.Text = string.Format("{0:#,##0.##}", TongThanhTienBHYT);
            double TTBHYT = Convert.ToDouble(textBox62.Text);
            TongBHYT = TTBHYT - (Chenh_BHYTtra - BHYTtra);

            double TTBNCCT = Convert.ToDouble(textBox119.Text);
            TongBNCC = TTBNCCT - (Chenh_Benhnhantra - Benhnhantra);
            //textBox119.Text = string.Format("{0:#,##0.##}", TongBNCC);
            if (TT <= GlobalModuls.Global.LuongCB * 0.15 && (tuyen == "0"|| tuyen == "3"))
            {
                textBox62.Text = string.Format("{0:#,##0.##}", TT);
                textBox119.Text = "0";
            }
            else
            {
                textBox62.Text = string.Format("{0:#,##0.##}", TongBHYT);
                textBox119.Text = string.Format("{0:#,##0.##}", TongBNCC);
            }

            TongBNTutra = Convert.ToDouble(textBox82.Text) + Tutra;
            //textBox82.Text = string.Format("{0:#,##0.##}", Convert.ToDouble(textBox60.Text) - Convert.ToDouble(textBox118.Text)); ;
            textBox153.Text = " " + textBox60.Text + " Đồng";
            string s1 = textBox60.Text.Substring(0, textBox60.Text.Length); // Tiền BV
            string s3 = textBox119.Text.Substring(0, textBox119.Text.Length); // BN CCT
            string s2 = textBox62.Text.Substring(0, textBox62.Text.Length); //BHYT CCT
            string s4 = textBox82.Text.Substring(0, textBox82.Text.Length); //BNTT
            string s5 = textBox81.Text.Substring(0, textBox81.Text.Length); //Tiền Khác
            if (textBox60.Text != "0")
            {
                textBox8.Text = GlobalModuls.Global.WriteNum(long.Parse(s1.Replace(".", ""))) + " đồng";
            }
            else textBox8.Text = "";
            if (textBox60.Text != "0")
            {
                if (s2 == "0")
                {
                    textBox19.Text = "";
                }
                else textBox19.Text = GlobalModuls.Global.WriteNum(long.Parse(s2.Replace(".", ""))) + " đồng";
            }
            if (textBox60.Text != "0")
            {
                long a = (long.Parse(s3.Replace(".", "")) + long.Parse(s4.Replace(".", "")));
                if (a == 0)
                {
                    textBox30.Text = "";
                }
                else textBox30.Text = GlobalModuls.Global.WriteNum(long.Parse(s3.Replace(".", "")) + long.Parse(s4.Replace(".", ""))) + " đồng";
            }
            if (textBox82.Text != "0")
            {
                if (s4 == "0")
                {
                    textBox158.Text = "";
                }
                else textBox158.Text = GlobalModuls.Global.WriteNum(long.Parse(string.Format("{0:#,##0.##}", Convert.ToDouble(textBox82.Text)).Replace(".", ""))) + " đồng";
                //textBox158.Text = GlobalModuls.Global.WriteNum(long.Parse(string.Format("{0:#,##0.##}", Convert.ToDouble(textBox60.Text) - Convert.ToDouble(textBox118.Text)).Replace(".", ""))) + " đồng";
            }

            if (textBox60.Text != "0")
            {
                if (s3 == "0")
                {
                    textBox156.Text = "";
                }
                else textBox156.Text = GlobalModuls.Global.WriteNum(long.Parse(s3.Replace(".", ""))) + " đồng";
            }
            textBox174.Text = textBox81.Text + " đồng"; 
            if(textBox81.Text != "0")
            {
                if(s5 == "0")
                {
                    textBox9.Text = "";
                }
                else
                textBox9.Text = GlobalModuls.Global.WriteNum(long.Parse(string.Format("{0:#,##0.##}", Convert.ToDouble(textBox81.Text)).Replace(".", ""))) + " đồng";
            }
            textBox67.Text = textBox81.Text + " đồng";
            if (textBox81.Text != "0")
            {
                if (s5 == "0")
                {
                    textBox167.Text = "";
                }
                else
                    textBox167.Text = GlobalModuls.Global.WriteNum(long.Parse(string.Format("{0:#,##0.##}", Convert.ToDouble(textBox81.Text)).Replace(".", ""))) + " đồng";
            }
        }
 
 
        private void rptTongKetChiPhi_NhomTheoLoaiBHYT_6556_FetchData(object sender, FetchEventArgs eArgs)
        {
            if (eArgs.EOF)
            {
            }
            else
            {
              
                tuyen = Fields["tuyen"].Value.ToString();
                if (Fields["tuyen"].Value.ToString() == "0" && _capcuu == "0")
                {
                    textBox112.Text = "X";
                    textBox111.Text = "";
                    textBox65.Text = "";
                    textBox68.Text = "";
                }
                if (Fields["tuyen"].Value.ToString() == "1" && _capcuu == "0" )//|| Fields["tuyen"].Value.ToString().ToUpper() == "false")
                {
                    textBox112.Text = "";
                    textBox111.Text = "X";
                    textBox65.Text = "";
                    textBox68.Text = "";
                }
                if (Fields["tuyen"].Value.ToString() == "3" && _capcuu == "0")//|| Fields["tuyen"].Value.ToString().ToUpper() == "false")
                {
                    textBox112.Text = "";
                    textBox111.Text = "X";
                    textBox65.Text = "";
                    textBox68.Text = "";
                }
                if (_capcuu == "1")//|| Fields["tuyen"].Value.ToString().ToUpper() == "false")
                {
                    textBox112.Text = "";
                    textBox111.Text = "";
                    textBox65.Text = "X";
                    textBox68.Text = "";
                }
            }
        }

        private void groupHeader3_Format(object sender, EventArgs e)
        {
        }

        private void groupHeader2_Format(object sender, EventArgs e)
        {
        }

        private void groupHeader6_Format(object sender, EventArgs e)
        {
            STT_Con = 0;
        }

    }
}
