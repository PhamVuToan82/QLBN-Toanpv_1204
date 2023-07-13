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
    public partial class Subrpt_BenhAn_TongKetPhauThuat : DataDynamics.ActiveReports.ActiveReport3
    {
        string _MaVaoVien;
        public Subrpt_BenhAn_TongKetPhauThuat(string MaVaoVien)
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
            if (Fields["ThoiGianKT"].Value != null)
            { textBox5.Text = string.Format("{0:HH}" + " giờ, Ngày " + "{0:dd/MM/yyyy}", DateTime.Parse(Fields["ThoiGianKT"].Value.ToString())); }
            else
            {
                textBox5.Text = string.Format("........" + " giờ, Ngày " + "..../..../.....");
            }
            
        }

        private void detail_BeforePrint(object sender, EventArgs e)
        {
             textBox5.Height = textBox6.Height = textBox7.Height = textBox8.Height = detail.Height ;
        }

        private void Subrpt_ylenh_dieutri_FetchData(object sender, FetchEventArgs eArgs)
        {
           
        }

        private void groupHeader1_BeforePrint(object sender, EventArgs e)
        {
         
        }

        private void groupHeader2_BeforePrint(object sender, EventArgs e)
        {
            
        }

        private void groupFooter2_BeforePrint(object sender, EventArgs e)
        {

        }

        private void groupFooter2_Format(object sender, EventArgs e)
        {

        }

        private void pageFooter_Format(object sender, EventArgs e)
        {
          
        }
        private void Subrpt_ylenh_dieutri_DataInitialize(object sender, EventArgs e)
        {
            DataDynamics.ActiveReports.DataSources.SqlDBDataSource _ds = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            _ds.ConnectionString = GlobalModuls.Global.glbConnectionString;
            _ds.SQL = string.Format("select X.*, Y.BSGayMe from"
                                + " (select distinct ThoiGianKT, PhuongPhapPT_Text + ' / ' + TenPPPT as PhuongPhapPT, TenBS as BSMo, a.MaPT, ViTri, a.SoPhieuCD"
                                + " from NAMDINH_QLBN.dbo.BENHNHAN_PHAUTHUAT a inner"
                                + " join NAMDINH_QLBN.dbo.DMPHUONGPHAPPT b on a.PhuongPhapPT_Ma = b.MaPPPT"
                                + " inner join NAMDINH_QLBN.dbo.BENHNHAN_PT_KIPMO c on c.MaVaoVien = a.MaVaoVien  and a.MaPT = c.MaPT"
                                + " inner join DMVITRI_PT d on d.MaVT = c.ViTri"
                                + " inner join NAMDINH_SYSDB.dbo.DMBACSY E ON E.MaBS = c.MaBS AND E.MaKhoa = c.MaKhoa AND c.ViTri IN(1)"
                                + " where a.Mavaovien = '{0}') X "
                                + " inner join"
                                + " (select distinct ThoiGianKT, PhuongPhapPT_Text + ' / ' + TenPPPT as PhuongPhapPT,TenBS as BSGayMe, a.MaPT, ViTri, a.SoPhieuCD"
                                + " from NAMDINH_QLBN.dbo.BENHNHAN_PHAUTHUAT a inner"
                                + " join NAMDINH_QLBN.dbo.DMPHUONGPHAPPT b on a.PhuongPhapPT_Ma = b.MaPPPT"
                                + " inner join NAMDINH_QLBN.dbo.BENHNHAN_PT_KIPMO c on c.MaVaoVien = a.MaVaoVien  and a.MaPT = c.MaPT"
                                + " inner join DMVITRI_PT d on d.MaVT = c.ViTri"
                                + " inner join NAMDINH_SYSDB.dbo.DMBACSY E ON E.MaBS = c.MaBS AND E.MaKhoa = c.MaKhoa AND c.ViTri IN(3)"
                                + " where a.Mavaovien = '{0}') Y on X.SoPhieuCD = Y.SoPhieuCD and X.MaPT = Y.MaPT ", _MaVaoVien);
            this.DataSource = _ds;     
        }
    }
}
