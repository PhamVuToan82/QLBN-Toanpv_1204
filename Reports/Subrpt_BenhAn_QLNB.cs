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
    public partial class Subrpt_BenhAn_QLNB : DataDynamics.ActiveReports.ActiveReport3
    {
        string _MaVaoVien, _TenKhoa, _NgayChuyen,_NgayDT;
        public Subrpt_BenhAn_QLNB(string MaVaoVien, string TenKhoa, string NgayChuyen,string NgayDT)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            _MaVaoVien = MaVaoVien;
            _TenKhoa = TenKhoa;
            _NgayChuyen = NgayChuyen;
            _NgayDT = NgayDT;
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
            if ((Fields["TrucTiepVao"].Value.ToString()) == "Cấp cứu")
            {
                checkBox1.Checked = true;
            }
            else checkBox1.Checked = false;
            if ((Fields["TrucTiepVao"].Value.ToString()) == "KKB")
            {
                checkBox2.Checked = true;
            }
            else checkBox2.Checked = false;
            if ((Fields["TrucTiepVao"].Value.ToString()) == "Khoa điều trị")
            {
                checkBox3.Checked = true;
            }
            else checkBox3.Checked = false;
            if ((Fields["NoiGioiThieu"].Value.ToString()) == "Cơ quan y tế")
            {
                checkBox4.Checked = true;
            }
            else checkBox4.Checked = false;
            if ((Fields["NoiGioiThieu"].Value.ToString()) == "Tự đến")
            {
                checkBox5.Checked = true;
            }
            else checkBox5.Checked = false;
            if ((Fields["NoiGioiThieu"].Value.ToString()) == "Khác")
            {
                checkBox6.Checked = true;
            }
            else checkBox6.Checked = false;
            if (Fields["NgayRaVien"].Value.ToString() != "01/01/1900 12:00:00 SA")
            {
                label10.Text = String.Format("{0:HH} giờ {0:mm} phút ngày {0:dd/MM/yyyy}", DateTime.Parse(Fields["NgayRaVien"].Value.ToString()));
            }
            else
                label10.Text = string.Format("....giờ....phút........ngày..../...../.........   ");
            label2.Text = String.Format("{0:HH} giờ {0:mm} phút ngày {0:dd/MM/yyyy}", DateTime.Parse(Fields["NgayVaoVien"].Value.ToString()));
            if((Fields["ChuyenVien"].Value.ToString()) == "Tuyến trên")
            {
                checkBox7.Checked = true;
            } else checkBox7.Checked = false;
            if ((Fields["ChuyenVien"].Value.ToString()) == "CK")
            {
                checkBox9.Checked = true;
            }
            else checkBox9.Checked = false;
            if ((Fields["ChuyenVien"].Value.ToString()) == "Tuyến dưới")
            {
                checkBox8.Checked = true;
            }
            else checkBox8.Checked = false;

            if ((Fields["NoiRaVien"].Value.ToString()) == "RaViện")
            {
                checkBox13.Checked = true;
            }
            else checkBox13.Checked = false;

            if ((Fields["NoiRaVien"].Value.ToString()) == "Xin về")
            {
                checkBox12.Checked = true;
            }
            else checkBox12.Checked = false;
            if ((Fields["NoiRaVien"].Value.ToString()) == "Bỏ về")
            {
                checkBox11.Checked = true;
            }
            else checkBox11.Checked = false;
            if ((Fields["NoiRaVien"].Value.ToString()) == "Đưa về")
            {
                checkBox10.Checked = true;
            }
            else checkBox10.Checked = false;
        }

        private void groupHeader1_BeforePrint(object sender, EventArgs e)
        {
      
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

        }

        private void pageFooter_Format(object sender, EventArgs e)
        {
            //label19.Text = String.Format("{0}", int.Parse(label19.Text) + 1);
        }
        private void Subrpt_ylenh_dieutri_DataInitialize(object sender, EventArgs e)
        {
            DataDynamics.ActiveReports.DataSources.SqlDBDataSource _ds = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            _ds.ConnectionString = GlobalModuls.Global.glbConnectionString;
            _ds.SQL = string.Format("set dateformat dmy HH:MM:SS: select [MaVaoVien], [NgayVaoVien], [TrucTiepVao], [NoiGioiThieu], [LanNhapVien], [KhoaNhapVien], [NgayNhapVien], [ChuyenVien], [NoiChuyenVien], [NgayRaVien], [NoiRaVien], [SoNgayDieuTri], [SoNgayDTKhoa], [TonSoNgayDT_Text] from NAMDINH_QLBN.dbo.BenhAn_QuanLyNguoiBenh  where Mavaovien = '{0}'", _MaVaoVien);
            this.DataSource = _ds;
        }

        private void groupHeader1_Format(object sender, EventArgs e)
        {
            Subrpt_BenhAn_ChuyenKhoa subchuyenkhoa = new Subrpt_BenhAn_ChuyenKhoa(_MaVaoVien,_TenKhoa,_NgayChuyen,_NgayDT);
            subReport1.Report = subchuyenkhoa;
        }
    }
}
