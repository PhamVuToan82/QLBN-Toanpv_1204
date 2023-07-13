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
    public partial class Subrpt_BenhAn_ChuyenKhoa : DataDynamics.ActiveReports.ActiveReport3
    {
        string _MaVaoVien,_TenKhoa,_NgayChuyen ,_NgayDt;
        int Stt = 1;
        public Subrpt_BenhAn_ChuyenKhoa(string MaVaoVien, string TenKhoaDau, string NgayChuyenDau, string NgayDt)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            _MaVaoVien = MaVaoVien;
            _NgayChuyen = NgayChuyenDau;
            _TenKhoa = TenKhoaDau;
            _NgayDt = NgayDt;
        }

        private void rptChiPhiPT_ReportStart(object sender, EventArgs e)
        {
            //this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            //this.PageSettings.Margins.Top = (float)0.5;
            this.PageSettings.Margins.Left = (float)0.0;
            this.PageSettings.Margins.Right = (float)0.0;
            //this.PageSettings.Margins.Bottom = (float)0.5;
            //this.Document.Name = "Y lệnh";
        }

        private void detail_Format(object sender, EventArgs e)
        {
            textBox5.Text = Stt.ToString();
            Stt++;
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
            //if ((Fields["BatThuong"].Value.ToString()) != "BT")
            //{
            //    textBox8.OutputFormat = "dd/MM/yyyy HH:mm:ss";
            //}
            //else
            //{
            //    textBox8.OutputFormat = "dd/MM/yyyy";
            //}
            if (Fields["NgayChuyen"].Value != null)
            {
                textBox7.Text = String.Format("{0:HH} giờ {0:mm} phút ngày {0:dd/MM/yyyy}", DateTime.Parse(Fields["NgayChuyen"].Value.ToString()));
            }
            else textBox7.Text = "";




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
            _ds.SQL = string.Format("set dateformat dmy HH:MM:SS: select  b.TenKhoa, A.NgayChuyen,'' AS NgayDT from NAMDINH_QLBN.dbo.BENHNHAN_KHOA A inner join NAMDINH_QLBN.dbo.DMKHOAPHONG b on a.makhoa = b.makhoa where Mavaovien = '{0}' and lanchuyenkhoa !=0 order by NgayChuyen", _MaVaoVien);
            this.DataSource = _ds;
        }

        private void groupHeader2_Format(object sender, EventArgs e)
        {
            textBox12.Text = String.Format("{0:HH} giờ {0:mm} phút ngày {0:dd/MM/yyyy}",DateTime.Parse(_NgayChuyen.ToString()));
            textBox10.Text = _TenKhoa;
            textBox13.Text = _NgayDt;

        }
    }
}
