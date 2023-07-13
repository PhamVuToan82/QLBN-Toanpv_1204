using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace NamDinh_QLBN.Reports.BaoCaoNoiTru
{
    /// <summary>
    /// Summary description for repDSBNNhapVien.
    /// </summary>
    public partial class repDSBNNhapRaVien_ICDTonghop : DataDynamics.ActiveReports.ActiveReport3
    {
        private System.DateTime _TNgay, _DNgay;
        private String _MaKhoa;
        public repDSBNNhapRaVien_ICDTonghop(System.DateTime TNgay, System.DateTime DNgay, String MaKhoa, String TenKhoa)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            _TNgay = TNgay;
            _DNgay = DNgay;
            _MaKhoa = MaKhoa;
            lbKhoa.Text = TenKhoa;
            System.TimeSpan Ngay1 = TNgay - DNgay;
            if (Ngay1.Days == 0)
            {
                lblNgayThang.Text = string.Format("Ngày {0:dd} tháng {0:MM} năm {0:yyyy}", TNgay);
            }
            else
            {
                lblNgayThang.Text = string.Format("Từ ngày {0:dd/MM/yyyy} đến ngày {1:dd/MM/yyyy}", TNgay, DNgay);
            }
        }

        private void repDSBNNhapVien_ReportStart(object sender, EventArgs e)
        {
            this.Document.Name = "Tổng hợp ICD10";
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.PageSettings.Orientation = PageOrientation.Portrait;

            this.PageSettings.Margins.Left = (float)0.2;
            this.PageSettings.Margins.Right = (float)0.0;
            this.PageSettings.Margins.Top = (float)0.25;
            this.PageSettings.Margins.Bottom = (float)0.2;
        }

        private void repDSBNNhapVien_DataInitialize(object sender, EventArgs e)
        {
             DataDynamics.ActiveReports.DataSources.SqlDBDataSource _ds = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            _ds.ConnectionString = GlobalModuls.Global.glbConnectionString;
            _ds.SQL = String.Format("set dateformat dmy "
                                + " select  c.CICD10,c.VVIET,Count(*) as Soluong"
                                + " from namdinh_qlbn.dbo.benhnhan_chitiet a , NAMDINH_QLBN.dbo.ViewKHOAHIENTAI b, NAMDINH_SYSDB.DBO.DMICD10 C, namdinh_qlbn.dbo.BenhNHAN"
                                + " WHERE A.MAVAOVIEN = B.MAVAOVIEN AND B.MAICD_BC = c.CICD10 AND BenhNHAN.MABENHNHAN = A.MABENHNHAN"
                                + " and  a.ngayravien between '{1:dd/MM/yyyy}' and '{2:dd/MM/yyyy}' and b.MaKhoa = N'{0}' and a.DaRaVien = 1"
                + " group by c.CICD10,c.VVIET order by CICD10", _MaKhoa,_TNgay,_DNgay);
            this.DataSource = _ds;
        }

        private void detail_BeforePrint(object sender, EventArgs e)
        {
            textBox1.Height = textBox2.Height = textBox4.Height  = textBox7.Height = detail.Height;
        }

        private void detail_Format(object sender, EventArgs e)
        {
            textBox1.Text = String.Format("{0}", int.Parse(textBox1.Text) + 1);
        }

        private void pageFooter_Format(object sender, EventArgs e)
        {
            lbPage.Text = String.Format("{0}", int.Parse(lbPage.Text) + 1);
        }
    }
}
