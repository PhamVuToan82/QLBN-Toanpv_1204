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
    public partial class Subrpt_BenhAn_TongKet_NoiKhoa : DataDynamics.ActiveReports.ActiveReport3
    {
        string _MaVaoVien;
        public Subrpt_BenhAn_TongKet_NoiKhoa(string MaVaoVien)
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
            _ds.SQL = string.Format("select [MaVaoVien], [TongKet_BenhLyDienBien], [TongKet_XetNghiemMau], [TongKet_XetNghiemTeBao], [TongKet_XetNghiemBLGP], [TongKet_XetNghiemXQuang], [TongKet_XetNghiemSieuAm], [TongKet_XetNghiemKhac], [TongKet_PhuongPhapDieuTri], [TongKet_PhuongPhapDieuTri_SoDot], [TongKet_PhuongPhapDieuTri_DapUng], [TongKet_PhuongPhapDieuTri_Khac], [TongKet_RaVien], [TongKet_RaVien_HuongDieuTriTiep], [TongKet_PhuongPhapDieuTri_TienPhauU], [TongKet_PhuongPhapDieuTri_TienPhauHach], [TongKet_PhuongPhapDieuTri_PhauThuat], [TongKet_PhuongPhapDieuTri_HauphauU], [TongKet_PhuongPhapDieuTri_HauPhauHach], [TongKet_PhuongPhapDieuTri_Hoachat], [TongKet_PhuongPhapDieuTri_DonThuanU], [TongKet_PhuongPhapDieuTri_DonThuanHach], [TongKet_PhuongPhapDieuTri_DapUngText],TongKet_PhuongPhapDieuTri_NoiNgoai_Text,TongKet_KetQuaCLS_NoiNgoai from BenhAn_TongKet where mavaovien = '{0}'", _MaVaoVien);
            this.DataSource = _ds;     
        }

        private void groupHeader1_Format(object sender, EventArgs e)
        {
            Subrpt_BenhAn_ChanDoan rptCls = new Subrpt_BenhAn_ChanDoan(_MaVaoVien);
            subReport1.Report = rptCls;
        }
    }
}
