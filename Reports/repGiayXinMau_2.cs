using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace NamDinh_QLBN.Reports
{
    /// <summary>
    /// Summary description for repGiayXinMau_2.
    /// </summary>
    public partial class repGiayXinMau_2 : DataDynamics.ActiveReports.ActiveReport3
    {
        private string _MaVaoVien, _SoPhieu, _khoa;
        private object _NgayTH;
        public repGiayXinMau_2(String MaVaoVien,String SoPhieu,object NgayTH, string khoa)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            _MaVaoVien = MaVaoVien;
            _NgayTH = NgayTH;
            _SoPhieu = SoPhieu;
            _khoa = khoa;
            if (khoa == "Trung tâm Ung bướu")
            {
                label13.Text = "GIÁM ĐỐC TRUNG TÂM";
            }
        }

        private void repGiayXinMau_2_ReportStart(object sender, EventArgs e)
        {
            this.PageSettings.Orientation = PageOrientation.Portrait;
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A5;
            this.PageSettings.Margins.Top = (float)0.1;
            this.PageSettings.Margins.Left = (float)0.2;
            this.PageSettings.Margins.Right = (float)0.1;
            this.PageSettings.Margins.Bottom = (float)0.1;
            label9.Text = String.Format("{0:HH} giờ {0:mm} - Ngày {0:dd} tháng {0:MM} năm {0:yyyy}", _NgayTH);
        }

  
        private void repGiayXinMau_2_DataInitialize(object sender, EventArgs e)
        {
            DataDynamics.ActiveReports.DataSources.SqlDBDataSource _ds = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            _ds.ConnectionString = GlobalModuls.Global.glbConnectionString;
            label19.Text = _khoa;
            label4.Text = _MaVaoVien;
            _ds.SQL = string.Format("set dateformat mdy DECLARE @SoPhieu nvarchar(50)"
                           + " DECLARE @SoLan int"
                           + " DECLARE Cur CURSOR"
                           + " FOR"
                           + " select benhnhan_phieudieutri.sophieu from benhnhan_phieudieutri "
                           + " inner join phieudieutri_chitiet on benhnhan_phieudieutri.sophieu = phieudieutri_chitiet.sophieu "
                           + " where mavaovien ='{0}' and datediff(dd,NgayChiDinh,'{1:MM/dd/yyyy HH:mm}') >= 0 and phieudieutri_chitiet.loaidichvu='D03'  and PHIEUDIEUTRI_CHITIET.MaDichVu not in ('MAU-MA-0065',' MAU-MA-0075',' MAU-MA-0076')"
                           + " group by benhnhan_phieudieutri.sophieu "
                           + " OPEN Cur"
                           + " FETCH NEXT FROM Cur INTO @SoPhieu"
                           + " WHILE @@FETCH_STATUS = 0"
                           + " begin"
                           + " if(@SoPhieu = '{2}')"
                           + " begin"
                           + " set @SoLan = isnull(@SoLan,1) "
                           + " break"
                           + " end"
                           + " else "
                           + " begin "
                           + " Set @SoLan = isnull(@SoLan,1) + 1"
                           + " end "
                           + " FETCH NEXT FROM Cur INTO @SoPhieu"
                           + " end"
                           + " CLOSE Cur"
                           + " DEALLOCATE  Cur"
                           + " select *,case when b.ABO != '' then b.ABO else NhomMau end as Mau from (Select benhnhan_chitiet.mavaovien, convert(int,SoLuong) as SoLuong,dmdichvu.tendichvu,phieudieutri_chitiet.madichvu,N'Số vào viện: ' + benhnhan_chitiet.SoHSBA as SoVaoVien,"
                           + " @SoLan as LanTruyenMau,HoTen,Year(aa.NgayChiDinh)-NamSinh as Tuoi, case when GioiTinh = 0 "
                           + " then N'Nữ' else N'Nam' end as GioiTinh,TenGiuong,TenBuong, case when NhomMau = 1 then 'A' "
                           + " when NhomMau = 2 then 'AB' when NhomMau = 3 then 'B' when NhomMau = 4 then 'O' else '' end as NhomMau, aa.ChanDoan,aa.BacSyDT from  "
                           + " (Select * from benhnhan_phieudieutri where sophieu ='{2}') aa inner join phieudieutri_chitiet on phieudieutri_chitiet.sophieu = aa.sophieu "
                           + " inner join dmdichvu on dmdichvu.madichvu = phieudieutri_chitiet.madichvu "
                           + " inner join benhnhan_chitiet on benhnhan_chitiet.mavaovien = aa.mavaovien "
                           + " inner join benhnhan on benhnhan.mabenhnhan = benhnhan_chitiet.mabenhnhan "
                           + " left join dmgiuongbenh on dmgiuongbenh.id_buong = benhnhan_chitiet.buong and "
                           + " dmgiuongbenh.id_giuong = benhnhan_chitiet.giuong  and dmgiuongbenh.makhoa = aa.makhoa "
                           + " left join dmbuongbenh on dmbuongbenh.id_buong = benhnhan_chitiet.buong and dmbuongbenh.makhoa = aa.makhoa"
                           + " where phieudieutri_chitiet.LoaiDichVu in ('D03') and  PHIEUDIEUTRI_CHITIET.MaDichVu not in ('MAU-MA-0065',' MAU-MA-0075',' MAU-MA-0076'))A left join (select top 1 xx.MaVaoVien, xx.ABO,yy.RH from (select top 1 ct.MaVaoVien,ct.MaKhamBenh,a.KetQua as ABO,'' RH from NAMDINH_CLS.dbo.KETQUAXETNGHIEM a inner join NAMDINH_CLS.dbo.DMDICHVU_CHISO b on a.MaChiSo = b.MaChiSo inner join NAMDINH_CLS.dbo.tblBENHNHAN_XETNGHIEM c on c.MaPhieuCD = a.MaPhieuCD and c.MaDichVu = b.MaDichVu inner join NAMDINH_QLBN.dbo.BENHNHAN_CHITIET ct on ct.MaKhamBenh = c.MaKhamBenh where ct.MaVaoVien = '{0}' and b.MaDichVu in ('C51006','C51075','C51076','C51077','C51078','C51079','C51080','C51101','C51106','C51115','C51125','C51128','C51130','C51136','C51140','C51141','C51164'))XX Full outer join (select top 1 ct.MaVaoVien,ct.MaKhamBenh,'' as ABO,a.KetQua as RH from NAMDINH_CLS.dbo.KETQUAXETNGHIEM a inner join NAMDINH_CLS.dbo.DMDICHVU_CHISO b on a.MaChiSo = b.MaChiSo inner join NAMDINH_CLS.dbo.tblBENHNHAN_XETNGHIEM c on c.MaPhieuCD = a.MaPhieuCD and c.MaDichVu = b.MaDichVu inner join NAMDINH_QLBN.dbo.BENHNHAN_CHITIET ct on ct.MaKhamBenh = c.MaKhamBenh where ct.MaVaoVien = '{0}' and b.MaDichVu in ('C51068','C51078','C51081','C51101','C51116','C51137','C51167'))YY on XX.makhambenh = yy.makhambenh) B on a.MaVaoVien = b.mavaovien", _MaVaoVien, _NgayTH, _SoPhieu);
            this.DataSource = _ds;
        }
    }
}
