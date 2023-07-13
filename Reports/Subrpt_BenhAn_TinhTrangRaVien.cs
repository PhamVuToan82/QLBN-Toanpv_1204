using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace NamDinh_QLBN.Reports
{
    /// <summary>
    /// Summary description for rptChiPhiPT.
    /// </summary>
    public partial class Subrpt_BenhAn_TinhTrangRaVien : DataDynamics.ActiveReports.ActiveReport3
    {
        string _MaVaoVien;
        public Subrpt_BenhAn_TinhTrangRaVien(string MaVaoVien)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            _MaVaoVien = MaVaoVien;
        }

        private void rptChiPhiPT_ReportStart(object sender, EventArgs e)
        {
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.PageSettings.Margins.Top = (float)0.5;
            this.PageSettings.Margins.Left = (float)0.4;
            this.PageSettings.Margins.Right = (float)0.1;
            this.PageSettings.Margins.Bottom = (float)0.5;
            this.Document.Name = "Y lệnh";
        }

        private void detail_Format(object sender, EventArgs e)
        {
            //_Ylenh = _Ylenh + Fields["Ylenh"].Value.ToString();
            //textBox3.Height = textBox15.Height = textBox16.Height = line1.Height = line2.Height = line4.Height = detail.Height;
            //if (textBox15.Text == "D01")
            //{
            //    textBox16.Text = Fields["DienBienBenh"].Value.ToString();
            //    textBox3.Text = "";
            //}
            //else
            //{
            //    textBox3.Text = Fields["DienBienBenh"].Value.ToString();
            //    textBox16.Text = "";
            //}
        }

        private void detail_BeforePrint(object sender, EventArgs e)
        {
            //textBox3.Height = textBox15.Height = textBox16.Height = line1.Height = line2.Height = line4.Height = detail.Height;
            //if (Fields["LoaiDichvu"].Value.ToString() == "D01")
            //{
            //    textBox16.Text = Fields["DienBienBenh"].Value.ToString();

            //}
            //else
            //{
            //    textBox3.Text = Fields["DienBienBenh"].Value.ToString();

            //}

        }
        private void Subrpt_ylenh_dieutri_FetchData(object sender, FetchEventArgs eArgs)
        {
            if ((Fields["RaVien_KetQuaDieuTri"].Value.ToString()) == "Khỏi")
            {
                textBox15.Text = "X";
            } else textBox15.Text = "";
            if ((Fields["RaVien_KetQuaDieuTri"].Value.ToString()) == "Đỡ, giảm")
            {
                textBox16.Text = "X";
            }else textBox16.Text = "";
            if ((Fields["RaVien_KetQuaDieuTri"].Value.ToString()) == "Không thay đổi")
            {
                textBox14.Text = "X";
            }
            else textBox14.Text = "";
            if ((Fields["RaVien_KetQuaDieuTri"].Value.ToString()) == "Nặng hơn")
            {
                textBox17.Text = "X";
            }
            else textBox17.Text = "";
            if ((Fields["RaVien_KetQuaDieuTri"].Value.ToString()) == "Tử vong")
            {
                textBox3.Text = "X";
            }
            else textBox3.Text = "";
            if ((Fields["RaVien_GiaiPhauBenh"].Value.ToString()) == "Lành tính")
            {
                textBox4.Text = "X";
            }
            else textBox4.Text = "";
            if ((Fields["RaVien_GiaiPhauBenh"].Value.ToString()) == "Nghi ngờ")
            {
                textBox5.Text = "X";
            }
            else textBox5.Text = "";
            if ((Fields["RaVien_KetQuaDieuTri"].Value.ToString()) == "Ác tính")
            {
                textBox6.Text = "X";
            }
            else textBox6.Text = "";

            if ((Fields["RaVien_LoaiTuVong"].Value.ToString()) == "Do bệnh")
            {
                textBox7.Text = "X";
            }
            else textBox7.Text = "";

            if ((Fields["RaVien_LoaiTuVong"].Value.ToString()) == "Do tai biến điều trị")
            {
                textBox8.Text = "X";
            }
            else textBox8.Text = "";

            if ((Fields["RaVien_LoaiTuVong"].Value.ToString()) == "Khác")
            {
                textBox9.Text = "X";
            }
            else textBox9.Text = "";

            if ((Fields["RaVien_Sau24GioTuVong"].Value.ToString()) == "1")
            {
                textBox12.Text = "X";
            }
            else textBox12.Text = "";
            if ((Fields["RaVien_24GioTuVong"].Value.ToString()) == "1")
            {
                textBox10.Text = "X";
            }
            else textBox10.Text = "";
            if ((Fields["RaVien_KhamTuThi"].Value.ToString()) == "1")
            {
                textBox13.Text = "X";
            }
            else textBox13.Text = "";
            if(Fields["RaVien_NgayTuVong"].Value.ToString() != "01/01/1900 12:00:00 SA")
            {
                label17.Text = string.Format(" {0:HH} giờ {0:mm} phút   ngày {0:dd} tháng {0:MM} năm {0:yyyy} ", DateTime.Parse(Fields["RaVien_NgayTuVong"].Value.ToString()));
            } else
            label17.Text = string.Format(".....giờ.....phút......, ngày.....tháng.....năm.......... ");
        }

        private void groupHeader1_BeforePrint(object sender, EventArgs e)
        {
            //    line10.Height = line3.Height = line6.Height = groupHeader1.Height;
            //    if (textBox13.Text == "Thuốc, hóa chất, vật tư,Oxy")
            //    {
            //        textBox13.Text = "";
            //        textBox17.Text = "Thuốc, hóa chất, vật tư,Oxy";
            //    }
            //    else
            //    {
            //        textBox17.Text = "";
            //    }

        }

        private void groupHeader2_BeforePrint(object sender, EventArgs e)
        {
            //richTextBox4.Text = _Ylenh ;
            //line5.Height = line7.Height = line8.Height= richTextBox4.Height = groupFooter2.Height = richTextBox3.Height + textBox6.Height;
        }

        private void groupFooter2_BeforePrint(object sender, EventArgs e)
        {

        }

        private void groupFooter2_Format(object sender, EventArgs e)
        {
            //if(_Ylenh == "")
            //{
            //    textBox14.Text = "";
               
            //}
            //else
            //{
            //    textBox14.Text = Fields["BacSyDT"].Value.ToString(); _Ylenh = "";
            //}
        }

        private void pageFooter_Format(object sender, EventArgs e)
        {
            //label19.Text = String.Format("{0}", int.Parse(label19.Text) + 1);
        }
        private void Subrpt_ylenh_dieutri_DataInitialize(object sender, EventArgs e)
        {
            DataDynamics.ActiveReports.DataSources.SqlDBDataSource _ds = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            _ds.ConnectionString = GlobalModuls.Global.glbConnectionString;
            _ds.SQL = string.Format("select [MaVaoVien], [RaVien_KetQuaDieuTri], [RaVien_GiaiPhauBenh], [RaVien_NgayTuVong], [RaVien_LoaiTuVong], [RaVien_24GioTuVong], [RaVien_NguyeNhanTuVong], [RaVien_ICDNguyeNhanTuVong], [RaVien_KhamTuThi], [RaVien_ChanDoanGiaiPhauTuThi], [RaVien_ICDChanDoanGiaiPhauTuThi], [RaVien_Sau24GioTuVong] from NAMDINH_QLBN.dbo.BenhAn_RaVien where Mavaovien = '{0}'", _MaVaoVien);
            this.DataSource = _ds;     
        }
    }
}
