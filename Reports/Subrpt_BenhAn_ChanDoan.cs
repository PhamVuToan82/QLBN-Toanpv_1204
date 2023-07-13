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
    public partial class Subrpt_BenhAn_ChanDoan : DataDynamics.ActiveReports.ActiveReport3
    {
        string _MaVaoVien;

        public Subrpt_BenhAn_ChanDoan(string MaVaoVien)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            _MaVaoVien = MaVaoVien;
        }
        private void Subrpt_BenhAn_ChanDoan_DataInitialize(object sender, EventArgs e)
        {
            DataDynamics.ActiveReports.DataSources.SqlDBDataSource _ds = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            _ds.ConnectionString = GlobalModuls.Global.glbConnectionString;
            _ds.SQL = string.Format("select (select sum(SoLuong) as slxquang from NAMDINH_QLBN.dbo.BENHNHAN_PHIEUDIEUTRI a inner join NAMDINH_QLBN.dbo.PHIEUDIEUTRI_CHITIET b on a.SoPhieu = b.SoPhieu WHEre a.MaVaoVien = '{0}'"
                                + " and b.LoaiDichVu = 'C54') as Xquang,"
                                + " (select sum(SoLuong) as xn from NAMDINH_QLBN.dbo.BENHNHAN_PHIEUDIEUTRI a inner join NAMDINH_QLBN.dbo.PHIEUDIEUTRI_CHITIET b on a.SoPhieu = b.SoPhieu WHEre a.MaVaoVien = '{0}'"
                                + " and b.LoaiDichVu = 'C53') as Sieuam,"
                                + " (select sum(SoLuong) as xn from NAMDINH_QLBN.dbo.BENHNHAN_PHIEUDIEUTRI a inner join NAMDINH_QLBN.dbo.PHIEUDIEUTRI_CHITIET b on a.SoPhieu = b.SoPhieu WHEre a.MaVaoVien = '{0}'"
                                + " and b.LoaiDichVu in('C57','C60', 'C61', 'C62','C59') ) as CtScanner,"
                                + " (select sum(SoLuong) as xn from NAMDINH_QLBN.dbo.BENHNHAN_PHIEUDIEUTRI a inner join NAMDINH_QLBN.dbo.PHIEUDIEUTRI_CHITIET b on a.SoPhieu = b.SoPhieu WHEre a.MaVaoVien = '{0}'"
                                + " and b.LoaiDichVu in('C50', 'C51', 'C52', 'C55', 'C56', 'C58', 'C63')) as xetnghiem", _MaVaoVien);
            this.DataSource = _ds;
        }
    }
}
