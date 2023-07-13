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
    public partial class rpt_ylenh_PHCN : DataDynamics.ActiveReports.ActiveReport3
    {
        string _MaVaoVien, _MaKhoa,_TenBuong,_TenGiuong, _SoHSBA;
        DateTime _TuNgay, _DenNgay, _NgayChiDinh;
        bool _Chon;
        string _Ylenh = "";

        private void rpt_ylenh_PHCN_DataInitialize(object sender, EventArgs e)
        {
            DataDynamics.ActiveReports.DataSources.SqlDBDataSource _ds = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            _ds.ConnectionString = GlobalModuls.Global.glbConnectionString;
            _ds.SQL = string.Format("set dateformat dmy select B.NgayChiDinh,B.DienBienBenh as OSTag1 ,B.YLenh + CHAR(10)  + CHAR(10) + N'              Chế độ chăm sóc: '+ e.TenCDChamSoc + CHAR(10) +  N'              Chế độ dinh dưỡng: '+ISNULL(f.TenCDDinhDuong,' ') + CHAR(10) + CHAR(10)+  CHAR(10) +'              '+ d.TenBS  as  OSTag2,b.Nhom from NAMDINH_QLBN.dbo.BENHNHAN_CHITIET A INNER JOIN NAMDINH_QLBN.dbo.BENHNHAN_PHIEUDIEUTRI B ON A.MaVaoVien =  B.MAVAOVIEN "
                                   + " left join NAMDINH_QLBN.dbo.DMBACSY d on d.SoChungChiHanhNghe = B.CCHN_NT "
                                   + "  left join NAMDINH_QLBN.dbo.DMCHEDOCHAMSOC e on e.MaCDChamSoc = B.CDChamSoc"
                                   + " left join NAMDINH_QLBN.dbo.DMCHEDODINHDUONG f on f.MaCDDinhDuong = B.CDDinhDuong"
                                   + " where B.MaKhoa = '{1}' and A.MaVaoVien = '{0}'", _MaVaoVien, _MaKhoa);
            if (_Chon == true)
            {
                _ds.SQL += string.Format("And B.NgayChidinh between '{0:dd/MM/yyyy HH:mm:ss}' and '{1:dd/MM/yyyy HH:mm:ss}' order by B.NgayChiDinh ", _TuNgay, _DenNgay);
            }
            else
            {
                _ds.SQL += string.Format(" order by b.NgayChiDinh");
            }
            this.DataSource = _ds;
        }

        //Subrpt_ylenh_DienBien rpt;
        public rpt_ylenh_PHCN(string MaVaoVien, string MaKhoa,DateTime TuNgay, DateTime DenNgay,bool Chon,string HoTen,string Khoa, string gioi, string chandoan, string tuoi, string TenBuong, string TenGiuong, string SoHSBA)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            _MaVaoVien = MaVaoVien;
            _MaKhoa = MaKhoa;
            _TuNgay = TuNgay;
            _DenNgay = DenNgay;
            _Chon = Chon;
            _SoHSBA = SoHSBA;
            _TenBuong = TenBuong;
            _TenGiuong = TenGiuong;
            textBox4.Text = Khoa;
            label13.Text = _SoHSBA;
            textBox1.Text = HoTen;
            textBox2.Text = tuoi;
            textBox10.Text = gioi;
            textBox5.Text = chandoan;
            textBox13.Text = TenBuong;
            textBox14.Text = TenGiuong;
            //_NgayChiDinh = NgayChiDinh;
        }

        private void rpt_ylenh_ReportStart(object sender, EventArgs e)
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
            
            if (Fields["Nhom"].Value.ToString() == "0")
            {
                textBox7.Text = string.Format("{0:dd/MM/yyyy}", textBox7.Text);
            }
            else
            {
                textBox7.Text = string.Format("{0:dd/MM/yyyy HH:mm}", textBox7.Text);
            }
         
        }

        private void detail_BeforePrint(object sender, EventArgs e)
        {
            //textBox6.Style = "font-weight: bold; font-size: 15.75pt;";
            if (textBox8.Text == "0")
            {
                textBox7.Value = string.Format("{0:dd/MM/yyyy}", textBox7.Value);
            }
            else
            {
                textBox7.Value = string.Format("{0:dd/MM/yyyy HH:mm}", textBox7.Value);
            }

            textBox6.Height = textBox3.Height = textBox7.Height = detail.Height;


        }

        private void rpt_ylenh_FetchData(object sender, FetchEventArgs eArgs)
        {
            if (Fields["Nhom"].Value.ToString() == "0")
            {
                textBox8.Text = "0";
            }
            else
            {
                textBox8.Text = "1";
            }

        }

         private void pageFooter_Format(object sender, EventArgs e)
        {
            label19.Text = String.Format("{0}", int.Parse(label19.Text) + 1);
        }
    
    }
}
