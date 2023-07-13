using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace NamDinh_QLBN.Reports
{
    /// <summary>
    /// Summary description for repHoiChan.
    /// </summary>
    public partial class repPhieuHoiChan : DataDynamics.ActiveReports.ActiveReport3
    {
        private String _MaVaoVien = "";
        String _Loai="";
        public repPhieuHoiChan(String MaVaoVien,String Loai)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            _MaVaoVien = MaVaoVien;
            _Loai = Loai;
        }

        private void repHoiChan_ReportStart(object sender, EventArgs e)
        {
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.PageSettings.Orientation = PageOrientation.Portrait;

            this.PageSettings.Margins.Left = (float)0.3;
            this.PageSettings.Margins.Right = (float)0.0;
            this.PageSettings.Margins.Top = (float)0.5;
            this.PageSettings.Margins.Bottom = (float)0.0;
        }

        private void repHoiChan_DataInitialize(object sender, EventArgs e)
        {
            DataDynamics.ActiveReports.DataSources.SqlDBDataSource _ds = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            _ds.ConnectionString = GlobalModuls.Global.glbConnectionString;
            _ds.CommandTimeout = 0;
            _ds.SQL = String.Format("select HoTen,Year(getdate()) - NamSinh as tuoi,case when GioiTinh = 0 then N'Nữ' else N'Nam' end as GioiTinh,bnhc.*,"
                + " isnull(Lower(TenGiuong),'') + '  ' + N'.       ' + isnull(TenBuong,'') + N' .         ' + dmkhoaphong.tenkhoa as BuongGiuong,isnull(Lower(bnhc.ChanDoan),'') as ChanDoan,"
                + " Upper(dmkhoaphong.tenkhoa) as tenkhoa,SoHSBA,DiaChi,NoiCongTac,NgayVaoVien,NgheNghiep,SoTheBHYT,TenDT"
                + " ,dbo.ConvertDate(NgayVaoVien) as NgayVaoVien,N'3.Hôm nay, '+ dbo.ConvertDate(NgayHoiChan) as NgayHienTai from "
                + " benhnhan_chitiet bnct inner join benhnhan bn on bn.mabenhnhan = bnct.mabenhnhan"
                + " inner join namdinh_sysdb.dbo.DMDanToc dt on bn.MaDanToc=dt.MaDT"
                + " inner join BENHNHAN_HOICHAN bnhc on bnhc.mavaovien = bnct.mavaovien"
                + " inner join viewkhoahientai v on v.mavaovien = bnct.mavaovien"
                + " left join dmgiuongbenh giuong on giuong.makhoa = v.makhoa and giuong.id_buong = bnct.buong and giuong.id_giuong = bnct.giuong"
                + " left join dmbuongbenh buong on buong.makhoa = v.makhoa and buong.id_buong = bnct.buong"
                + " inner join dmkhoaphong on dmkhoaphong.makhoa = v.makhoa where bnct.mavaovien ='{0}' and Loai={1}", _MaVaoVien,_Loai);
            this.DataSource = _ds;
        }

    }
}
