using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using GlobalModuls;
using System.Data;
using System.Data.SqlClient;

namespace NamDinh_QLBN.Reports
{
    /// <summary>
    /// Summary description for rptPhieuLinh.
    /// </summary>
    public partial class rptPhieuMuonVai : DataDynamics.ActiveReports.ActiveReport3
    {
        private int STT = 1;
        int page = 0;
        private int STT_nguoi = 1;
        private int stt_dong = 1;
        public string TruongKhoa;
        public string TruongKho;
        public string NguoiLinh;
        public string NguoiPhat;
        public string KhoThuoc;
        public string _TenKhoa;
        DateTime _TuNgay,_DenNgay;
        public string So;
        public bool isKhoaDongY = false;
        private int TongSo = 0;
        private int TongSoKhoa = 0;
        private int TongSoQuan = 0;
        private int TongSoAo = 0;
        private int TongSoGa = 0;
        private int TongSoChan = 0;
        private int TongSoThe = 0;
        private int TongSoMan = 0;
        public rptPhieuMuonVai(DateTime Ngay,DateTime NgayHT, string Khoa)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            txtNgay1.Text = "Từ Ngày " + Ngay.Day.ToString() + " tháng " + Ngay.Month.ToString() + " năm "+ Ngay.Year.ToString();
            textBox5.Text = "Đến Ngày " + NgayHT.Day.ToString() + " tháng " + NgayHT.Month.ToString() + " năm " + NgayHT.Year.ToString();
            txtngay2.Text = String.Format("In ngày {0:dd} tháng {0:MM} năm {0:yyyy}", Global.NgayLV);
            _TenKhoa = Khoa;
            _TuNgay = Ngay;
            _DenNgay = NgayHT;
            
        }
        private void rptPhieuLinh_ReportStart(object sender, EventArgs e)
        {
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.PageSettings.Orientation = PageOrientation.Portrait;

            this.PageSettings.Margins.Left = (float)0.80;
            this.PageSettings.Margins.Right = (float)0.50;
            this.PageSettings.Margins.Top = (float)0.50;
            this.PageSettings.Margins.Bottom = (float)0.50;
            pageBreak1.Height = 0;
            if (isKhoaDongY) { textBox9.DataField = "GhiChu"; }
            pageBreak1.Enabled = false;
        }

        private void detail_Format(object sender, EventArgs e)
        {
            label9.Text = STT.ToString();
            STT++;
            if (textBox2.Text != null)
            {
                if (textBox2.Text.Trim() == "Quần")
                {
                    TongSoQuan = TongSoQuan + int.Parse(textBox7.Text);
                }
                if (textBox2.Text.Trim() == "Áo")
                {
                    TongSoAo = TongSoAo + int.Parse(textBox7.Text);
                }
                if (textBox2.Text.Trim() == "Chăn")
                {
                    TongSoChan = TongSoChan + int.Parse(textBox7.Text);
                }
                if (textBox2.Text.Trim() == "Ga trải giường")
                {
                    TongSoGa = TongSoGa + int.Parse(textBox7.Text);
                }
                if (textBox2.Text.Trim() == "Thẻ Chăm Sóc")
                {
                    TongSoThe = TongSoThe + int.Parse(textBox7.Text);
                }
                if (textBox2.Text.Trim() == "Màn Tuyn")
                {
                    TongSoMan = TongSoMan + int.Parse(textBox7.Text);
                }
            }
        }

        private void detail_BeforePrint(object sender, EventArgs e)
        {
            label9.Height = textBox2.Height = textBox6.Height = textBox7.Height =textBox9.Height = detail.Height ;
        }

        private void groupHeader1_Format(object sender, EventArgs e)
        {
            STT = 1;
            textBox11.Text = STT_nguoi.ToString() + ". " + textBox11.Text;
            STT_nguoi += 1;
        }

        private void groupHeader1_BeforePrint(object sender, EventArgs e)
        {
            textBox8.Text = textBox8.Text + " : " + textBox1.Text;
            //textBox11.Height = groupHeader1.Height+pageBreak1.Height;
        }

        private void rptPhieuMuonVai_PageStart(object sender, EventArgs e)
        {
            page += 1;
            txtPage.Text = "Trang " + page.ToString() ;
        }

        private void reportFooter1_Format(object sender, EventArgs e)
        {
            //textBox4.Text = TongSo.ToString();
            textBox10.Text = "Quần :" + TongSoQuan.ToString() + "\nÁo : " + TongSoAo.ToString() + "\nChăn : " + TongSoChan.ToString() + "\nGa trải giường : " + TongSoGa.ToString() + "\nMàn Tuyn : " + TongSoMan.ToString() + "\nThẻ Chăm Sóc : " + TongSoThe.ToString();
        }
        private void rptPhieuMuonVai_DataInitialize(object sender, EventArgs e)
        {
            DataDynamics.ActiveReports.DataSources.SqlDBDataSource _ds = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            _ds.ConnectionString = GlobalModuls.Global.glbConnectionString;
            _ds.SQL = string.Format("set dateformat dmy SELECT  b.TenDoVai,c.Dvt,SUM(b.soluong) as SoLuong,a.TenKhoa FROM NAMDINH_QLBN.dbo.tblbenhnhan_muonvai a inner join NAMDINH_QLBN.dbo.tblPhieuMuon_Vai b on a.MaKhambenh = b.MaKhamBenh "
            + " inner join NAMDINH_QLBN.dbo.tblDoVai c on c.MaDoVai = b.MaDoVai") ;
            if (_TenKhoa != "Tất Cả")
                _ds.SQL = _ds.SQL + string.Format(" where a.TenKhoa = N'{0}' and a.ThoigianDangky between '{1:dd/MM/yyyy HH:mm}' and '{2:dd/MM/yyyy HH:mm}'", _TenKhoa, _TuNgay, _DenNgay);
            else
            {
                _ds.SQL = _ds.SQL + string.Format(" where a.ThoigianDangky between '{0:dd/MM/yyyy HH:mm}' and '{1:dd/MM/yyyy HH:mm}'",_TuNgay, _DenNgay);
            }
            _ds.SQL = _ds.SQL + "group by b.tendovai, c.Dvt, a.TenKhoa  order by a.TenKhoa";
            this.DataSource = _ds;
        }
    }
}
