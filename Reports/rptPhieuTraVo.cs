using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace NamDinh_QLBN.Reports
{
    /// <summary>
    /// Summary description for rptPhieuLinhThuoc.
    /// </summary>
    public partial class rptPhieuTraVo : DataDynamics.ActiveReports.ActiveReport3
    {
        private object _Ngay;
        private String _MaKhoa;
        private int STT = 1;
        public rptPhieuTraVo(string TenKhoa,object Ngay,String MaKhoa)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            lblKhoa.Text = TenKhoa;
            lblNgayThang.Text = String.Format("Trả ngày {0:dd} tháng {0:MM} năm {0:yyyy}", Ngay); ;
            _Ngay = Ngay;
            _MaKhoa = MaKhoa;
        }

        private void rptPhieuLinhThuoc_ReportStart(object sender, EventArgs e)
        {
            this.Document.Name = "Phiếu lĩnh thuốc";
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.PageSettings.Orientation = PageOrientation.Portrait;

            this.PageSettings.Margins.Left = (float)0.4;
            this.PageSettings.Margins.Right = (float)0.25;
            this.PageSettings.Margins.Top = (float)0.40;
            this.PageSettings.Margins.Bottom = (float)0.10;

            lblNgayIn.Text = string.Format("In ngày {0:dd} tháng {0:MM} năm {0:yyyy}", GlobalModuls.Global.NgayLV);
        }

        private void detail_Format(object sender, EventArgs e)
        {
            txtSTT.Text = STT.ToString();
            STT++;
        }

        private void detail_BeforePrint(object sender, EventArgs e)
        {
            txtSTT.Height = textBox1.Height = textBox2.Height = textBox3.Height = textBox4.Height = textBox5.Height = this.detail.Height;
        }

        private void reportFooter1_Format(object sender, EventArgs e)
        {
        }

        private void groupHeader1_Format(object sender, EventArgs e)
        {

        }

        private void rptPhieuTraVo_DataInitialize(object sender, EventArgs e)
        {
             DataDynamics.ActiveReports.DataSources.SqlDBDataSource _ds = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            _ds.ConnectionString = GlobalModuls.Global.glbConnectionString;
            _ds.SQL = string.Format("select * from "
                + " (Select * from benhnhan_travo where makhoa='{0}') aa "
                + " inner join dmdichvu on dmdichvu.madichvu = aa.mathuoc",_MaKhoa);
            this.DataSource = _ds;
        }
    }
}
