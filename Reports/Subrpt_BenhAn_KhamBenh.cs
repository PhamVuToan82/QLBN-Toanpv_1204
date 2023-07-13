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
    public partial class Subrpt_BenhAn_KhamBenh : DataDynamics.ActiveReports.ActiveReport3
    {
        string _MaVaoVien;
        public Subrpt_BenhAn_KhamBenh(string MaVaoVien)
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
            if ((Fields["ChanDoan_TaiBien"].Value.ToString()) == "1")
            {
                textBox12.Text = "X";
            } else textBox12.Text = "";
            if ((Fields["ChanDoan_BienChung"].Value.ToString()) == "1")
            {
                textBox13.Text = "X";
            }else textBox13.Text = "";
            if ((Fields["ChanDoan_DoPhauThuat"].Value.ToString()) == "1")
            {
                textBox15.Text = "X";
            }
            else textBox15.Text = "";
            if ((Fields["ChanDoan_DoGayMe"].Value.ToString()) == "1")
            {
                textBox14.Text = "X";
            }
            else textBox14.Text = "";
            if ((Fields["ChanDoan_DoNhiemKhuan"].Value.ToString()) == "1")
            {
                textBox16.Text = "X";
            }
            else textBox16.Text = "";
            if ((Fields["ChanDoan_Khac"].Value.ToString()) == "1")
            {
                textBox17.Text = "X";
            }
            else textBox17.Text = "";
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
            _ds.SQL = string.Format("select [MaVaoVien], [ChanDoan_NoiChuyenDen], [ChanDoan_KKB], [ChanDoan_KhoaDieuTri], [MaBenhICD_NoiChuyenDen], [MaBenhICD_KKB], [MaBenhICD_KhoaDieuTri], [GhiChu_ChanDoanKhoaDieutri], [ChanDoan_TaiBien], [ChanDoan_BienChung], [ChanDoan_DoPhauThuat], [ChanDoan_DoGayMe], [ChanDoan_DoNhiemKhuan], [ChanDoan_Khac], [ChanDoan_SoNgayDieuTriSauPT], [ChanDoan_SoLanPhauThuat], [ChanDoan_BenhChinhRaVien], [ChanDoan_ICDBenhChinhRaVien], [ChanDoan_BenhKemTheoRaVien], [ChanDoan_ICDBenhKemTheo], [ChanDoan_TruocPhauThuat], [ChanDoan_ICDTruocPhauThuat], [ChanDoan_SauPhauThuat], [ChanDoan_ICDSauPhauThuat] from NAMDINH_QLBN.dbo.BenhAn_ChanDoan where Mavaovien = '{0}'", _MaVaoVien);
            this.DataSource = _ds;     
        }
    }
}
