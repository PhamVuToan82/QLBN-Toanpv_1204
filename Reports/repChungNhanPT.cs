using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace NamDinh_QLBN.Reports
{
    /// <summary>
    /// Summary description for repPhieuChuyenVien.
    /// </summary>
    public partial class repChungNhanPT : DataDynamics.ActiveReports.ActiveReport3
    {
        private String _MaVaoVien;
        private String _NgayRaVien;
        private String _CachThuc;

        public repChungNhanPT(String MaVaoVien,string NgayRaVien)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            _MaVaoVien = MaVaoVien;
            _NgayRaVien = NgayRaVien;
            string[] subString = _NgayRaVien.Split('/');
            //lblNgaythang.Text = "Ngày " + subString[0] + " Tháng " + subString[1] + " Năm " + subString[2].Substring(0,4);           
            //lblNgaythang.Text = "Ngày " + GlobalModuls.Global.NgayLV.Day.ToString() + " tháng " + GlobalModuls.Global.NgayLV.Month.ToString() + " năm " + GlobalModuls.Global.NgayLV.Year.ToString();
        }

        private void repChungNhanPT_ReportStart(object sender, EventArgs e)
        {
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A5;
            DataDynamics.ActiveReports.DataSources.SqlDBDataSource _ds = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            _ds.ConnectionString = GlobalModuls.Global.glbConnectionString;
            _ds.SQL = string.Format("declare @BSphu nvarchar(30),@NhomMau varchar(3),@RhD nvarchar(20) "
           //   + " select @BSphu=TenBS from benhnhan_phauthuat pt inner join BENHNHAN_PT_KIPMO kip on pt.MaVaoVien=kip.MaVaoVien and pt.SoPhieuCD=kip.SoPhieuCD "
           //   +" inner join namdinh_sysdb.dbo.DMBacSy bs on kip.MaBS=bs.MaBS and kip.MaKhoa=bs.MaKhoa "
           //   + " where pt.MaVaoVien='{0}' and vitri=2 ";
           + " select @NhomMau=KetQua from BENHNHAN_PHIEUDIEUTRI pdt inner join NAMDINH_CLS.dbo.KETQUAXETNGHIEM kq "
               + " on pdt.sophieu=kq.maphieucd where mavaovien='{0}' and machiso ='C51077'"
               + " select @Rhd=KetQua from BENHNHAN_PHIEUDIEUTRI pdt inner join NAMDINH_CLS.dbo.KETQUAXETNGHIEM kq"
               + " on pdt.sophieu=kq.maphieucd where mavaovien='{0}' and machiso ='C51083'"
               + " select SoHSBA,HoTen,DiaChi,NamSinh,case GioiTinh when 1 then N'Nam' else N'Nữ' end as GioiTinh,ViewKHOAHIENTAI.ngaychuyendau as NgayVaoVien,NgayRaVien,bs.TenBS as BSChinh,@BSphu as BSPhu,"
               + " PhuongPhapPT_Text as CachThuc,ThoiGianBD,@NhomMau as NhomMau,@Rhd as Rhd,case GioiTinh when 1 then N'Ông' else N'Bà' end as Ong_Ba,TenVoCam as PPVoCam,ChanDoan_KhoaDT,kip.MaKhoa"
               + " from BenhNhan bn inner join BenhNhan_ChiTiet bnct on bn.MaBenhNhan=bnct.MaBenhNhan"
               + " inner join benhnhan_phauthuat pt on bnct.MaVaoVien=pt.MaVaoVien"
               + " inner join BENHNHAN_PT_KIPMO kip on pt.MaVaoVien=kip.MaVaoVien and pt.SoPhieuCD=kip.SoPhieuCD"
               + " inner join namdinh_sysdb.dbo.dmdichvu dm on dm.MaDichVu= pt.MaPT"
               + " inner join dmVoCam vc on vc.MaVoCam= pt.PPVoCam"
               + " inner join namdinh_sysdb.dbo.DMBacSy bs on kip.MaBS=bs.MaBS and kip.MaKhoa=bs.MaKhoa"
               + " INNer join ViewKHOAHIENTAI on ViewKHOAHIENTAI.mavaovien = bnct.mavaovien"
               + " where bnct.MaVaoVien='{0}' and vitri =1", _MaVaoVien);
            this.DataSource = _ds;
        }
        string s = "";
        private void repChungNhanPT_FetchData(object sender, FetchEventArgs eArgs)
        {
            if(Fields["CachThuc"].Value != null)
            {
                string cachthuc = Fields["CachThuc"].Value.ToString();
                if (s != cachthuc)
                {
                    _CachThuc = s + " ; " + cachthuc;
                    s = cachthuc;
                }
                textBox9.Text = _CachThuc;
            }
          
            //if (Fields["MaKhoa"].Value != null)
            //{
            //    if (Fields["MaKhoa"].Value.ToString() == "NV1211")
            //    {
            //        Label25.Text = "GIÁM ĐỐC TRUNG TÂM";
            //    }
            //}
        }

        private void repChungNhanPT_ReportEnd(object sender, EventArgs e)
        {
           
        }
    }
}

