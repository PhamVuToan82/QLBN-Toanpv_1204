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
    public partial class Subrpt_BenhAn_BA_CoQuan_NoiNgoai : DataDynamics.ActiveReports.ActiveReport3
    {
        string _MaVaoVien;
        public Subrpt_BenhAn_BA_CoQuan_NoiNgoai(string MaVaoVien)
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
        private void Subrpt_ylenh_dieutri_DataInitialize(object sender, EventArgs e)
        {
            DataDynamics.ActiveReports.DataSources.SqlDBDataSource _ds = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            _ds.ConnectionString = GlobalModuls.Global.glbConnectionString;
            _ds.SQL = string.Format("select BenhAn_CoQuanThanKinh,BenhAn_CoQuanTuanHoan,BenhAn_CoQuanHoHap,BenhAn_CoQuanTieuHoa,BenhAn_CoQuanCoXuongKhop,BenhAn_ThanTietNieuSinhDuc,BenhAn_TaiMuiHong,BenhAn_CoQuanKhac,BenhAn_RangHamMat,BenhAn_Mat from NAMDINH_QLBN.dbo.BenhAn_ChiTiet where Mavaovien =  '{0}'", _MaVaoVien);
            this.DataSource = _ds;     
        }
    }
}
