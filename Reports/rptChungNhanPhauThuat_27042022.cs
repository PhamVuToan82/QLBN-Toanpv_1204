using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace NamDinh_QLBN.Reports
{
    /// <summary>
    /// Summary description for repPhieuChiDinh.
    /// </summary>
    public partial class rptChungNhanPhauThuat_27042022 : DataDynamics.ActiveReports.ActiveReport3
    {
        private String _MaVaoVien;
        private DateTime _NgayRaVien;
        public rptChungNhanPhauThuat_27042022(string MaVaoVien, DateTime NgayRaVien)
        {
            InitializeComponent();
            _MaVaoVien = MaVaoVien;
            _NgayRaVien = NgayRaVien;
            label7.Text = String.Format("Ngày {0:dd} tháng {0:MM} năm {0:yyyy}", _NgayRaVien);
        }
        private void repPhieuChiDinh_DataInitialize(object sender, EventArgs e)
        {
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A5;
            DataDynamics.ActiveReports.DataSources.SqlDBDataSource _ds = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            _ds.ConnectionString = GlobalModuls.Global.glbConnectionString;
            _ds.SQL = string.Format("declare @BSphu nvarchar(30),@NhomMau varchar(3),@RhD nvarchar(20) "
           + " select @NhomMau=KetQua from BENHNHAN_PHIEUDIEUTRI pdt inner join NAMDINH_CLS.dbo.KETQUAXETNGHIEM kq "
               + " on pdt.sophieu=kq.maphieucd where mavaovien='{0}' and machiso ='C51077'"
               + " select @Rhd=KetQua from BENHNHAN_PHIEUDIEUTRI pdt inner join NAMDINH_CLS.dbo.KETQUAXETNGHIEM kq"
               + " on pdt.sophieu=kq.maphieucd where mavaovien='{0}' and machiso ='C51083'"
               + " select distinct SoHSBA,UPPER(HoTen) HoTen,DiaChi,NamSinh,case GioiTinh when 1 then N'Nam' else N'Nữ' end as GioiTinh,ViewKHOAHIENTAI.ngaychuyendau as NgayVaoVien,NgayRaVien,bs.TenBS as BSChinh,@BSphu as BSPhu,"
               + " PhuongPhapPT_Text as CachThuc,ThoiGianBD,@NhomMau as NhomMau,@Rhd as Rhd,case GioiTinh when 1 then N'Ông' else N'Bà' end as Ong_Ba,TenVoCam as PPVoCam,bnct.ChanDoanRaVien ChanDoan_KhoaDT,kip.MaKhoa,TenDichvu "
               + " from BenhNhan bn inner join BenhNhan_ChiTiet bnct on bn.MaBenhNhan=bnct.MaBenhNhan"
               + " inner join benhnhan_phauthuat pt on bnct.MaVaoVien=pt.MaVaoVien"
               + " inner join BENHNHAN_PT_KIPMO kip on pt.MaVaoVien=kip.MaVaoVien and pt.SoPhieuCD=kip.SoPhieuCD"
               + " INNER JOIN NAMDINH_QLBN.dbo.DMPHAUTHUAT phauthuat ON phauthuat.LoaiDichVu = pt.LoaiDichVu AND phauthuat.MaDichVu = pt.MaPT AND phauthuat.LoaiPhauThuat IN (11,21,3,4)"
               + " inner join namdinh_sysdb.dbo.dmdichvu dm on dm.MaDichVu= pt.MaPT"
               + " inner join dmVoCam vc on vc.MaVoCam= pt.PPVoCam"
               + " inner join namdinh_sysdb.dbo.DMBacSy bs on kip.MaBS=bs.MaBS and kip.MaKhoa=bs.MaKhoa"
               + " INNer join ViewKHOAHIENTAI on ViewKHOAHIENTAI.mavaovien = bnct.mavaovien"
               + " where bnct.MaVaoVien='{0}' and vitri =1", _MaVaoVien);
            this.DataSource = _ds;
        }

        private void detail_BeforePrint(object sender, EventArgs e)
        {
           
        }
        private void detail_Format(object sender, EventArgs e)
        {
            //TextBox6.Height = line18.Height = line19.Height = detail.Height;
        }

        private void repPhieuChiDinh_ReportStart(object sender, EventArgs e)
        {
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A5;
            this.PageSettings.Orientation = PageOrientation.Portrait;
            this.PageSettings.Margins.Top = (float)0.2;
            this.PageSettings.Margins.Left = (float)0.2;
            this.PageSettings.Margins.Right = (float)0.2;
            this.PageSettings.Margins.Bottom = (float)0.0;
        }

        private void groupHeader3_Format(object sender, EventArgs e)
        {
            //groupFooter3.Height = line16.Height = line17.Height = label5.Height + label23.Height ;
        }
    }
}
