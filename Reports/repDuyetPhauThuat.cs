using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace NamDinh_QLBN.Reports
{
    /// <summary>
    /// Summary description for repDuyetPhauThuat.
    /// </summary>
    public partial class repDuyetPhauThuat : DataDynamics.ActiveReports.ActiveReport3
    {
        private string _MaVaoVien = "";
        private string _MaKhoa = "";
        private object _NgayChiDinh;

        public repDuyetPhauThuat(String MaVaoVien, object NgayChiDinh,String SoPhieu, string MaKhoa, string TenKhoa)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            _MaVaoVien = MaVaoVien;
            _MaKhoa = MaKhoa;
            _NgayChiDinh = NgayChiDinh;
            lbTon.Text = TenKhoa; // GlobalModuls.Global.glbTenKhoaPhong;
            barcode1.Text = "Số phiếu: " + SoPhieu;
            lblKhoa.Text = TenKhoa; //GlobalModuls.Global.glbTenKhoaPhong;
        }

        private void repDuyetPhauThuat_ReportStart(object sender, EventArgs e)
        {
            this.PageSettings.Orientation = PageOrientation.Landscape;
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A5;
            this.PageSettings.Margins.Top = (float)0.1;
            this.PageSettings.Margins.Left = (float)0.7;
            this.PageSettings.Margins.Right = (float)0.0;
            this.PageSettings.Margins.Bottom = (float)0.0;
            //lblNgayThang.Text = string.Format("{0:HH} giờ {0:mm} - Ngày {0:dd} tháng {0:MM} năm {0:yyyy}", GlobalModuls.Global.GetNgayLV());
            lblNgayThang.Text = string.Format("{0:HH} giờ {0:mm} - Ngày {0:dd} tháng {0:MM} năm {0:yyyy}", _NgayChiDinh);
        }

        private void repDuyetPhauThuat_DataInitialize(object sender, EventArgs e)
        {
            DataDynamics.ActiveReports.DataSources.SqlDBDataSource _ds = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            _ds.ConnectionString = GlobalModuls.Global.glbConnectionString;
            _ds.SQL = string.Format("set dateformat mdy  select XX.*, 'BS: ' + DMBACSY.TenBS as BsGayMeChinh from (select aa.MaVaoVien,N'Số HSBA: ' + aa.SoHSBA as SoHSBA,N'(Lần thứ   ' + LanMo +')' as LanMo,HoTen,year(getdate()) - NamSinh as Tuoi,case when gioitinh = 0 then N'Giới tính: Nữ' else N'Giới tính: Nam' end as GioiTinh,"
                + " Lower(nghenghiep) as nghenghiep,DiaChi,QuaTrinhBL,benhnhan_khoa.ngaychuyen as NgayVaoVien,N'Chẩn đoán vào viện  ' + benhnhan_khoa.ChanDoan as ChanDoanVaoVien,"
                + " N'Chẩn đoán phẫu thuật:  ' + benhnhan_phieudieutri.ChanDoan as ChanDoanTruocMo,NgayMo as NgayTienHanh,lanhDaoDuyet,thongtin_phauthuat.PhuongPhapDK,"
                + " N'- PTV chính:  ' + nguoithuchien as nguoithuchien,N'- Phụ mổ:  ' + nguoiphu as nguoiphu,ChuanBi,N'Phương pháp vô cảm:  ' + VoCam as VoCam,N'Gây mê chính:  ' + GayMe as GayMe,N'Phụ gây mê:  ' + PhuGayMe as PhuGayMe,N'Dự trù máu:  ' + DuTruMau as DuTruMau,"
                + " KhoKhan,benhnhan_phieudieutri.BacSyDT,dmbacsy.tenbs as truongKhoa,N'- Chính sách: ' + dmdoituongbn.TenDT +' - '+ aa.MaDTBHYT+ SoTheBHYT as ChinhSach,SoTien,N'- Biên lai số: ' + SoBienLai as SoBienLai,N'Loại: '+LoaiPT as LoaiPhauThuat,N'Giúp việc: ' + TPKhac as ThanhPhanKhac,PHIEUDIEUTRI_CHITIET.MaDichVu,PHIEUDIEUTRI_CHITIET.SoPhieu from"
                + " (select * from benhnhan_chitiet where mavaovien='{0}') aa"
                + " inner join benhnhan on benhnhan.mabenhnhan = aa.mabenhnhan"
                + " inner join thongtin_phauthuat on thongtin_phauthuat.mavaovien = aa.mavaovien"
                + " inner join viewkhoahientai v on v.mavaovien = aa.mavaovien"
                + " inner join benhnhan_phieudieutri on datediff(dd,benhnhan_phieudieutri.ngaychidinh,'{1:MM/dd/yyyy}') = 0 and benhnhan_phieudieutri.makhoa = '{2}' AND benhnhan_phieudieutri.MaVaoVien=thongtin_phauthuat.MaVaoVien"
                + " inner join phieudieutri_chitiet on phieudieutri_chitiet.sophieu = benhnhan_phieudieutri.sophieu and phieudieutri_chitiet.loaidichvu between 'C01' and 'C24'"
                + " inner join benhnhan_khoa on benhnhan_khoa.mavaovien = aa.mavaovien and lanchuyenkhoa = 0"
                + " left join dmbacsy on dmbacsy.makhoa = v.makhoa and dmbacsy.machucvu = 3 "
                + " inner join viewdoituonghientai on viewdoituonghientai.mavaovien = aa.mavaovien"
                + " inner join dmdoituongbn on viewdoituonghientai.doituong = dmdoituongbn.madt ) XX left join NAMDINH_QLBN.dbo.BENHNHAN_PT_KIPMO pt on pt.MaVaoVien = XX.MaVaoVien and pt.MaKhoa = 'NV1103' and ViTri = 3 left join NAMDINH_SYSDB.dbo.DMBACSY on DMBACSY.MaKhoa = pt.MaKhoa and pt.MaBS = DMBACSY.MaBS  and pt.SoPhieuCD = XX.SoPhieu and XX.MaDichVu = pt.MaPT ", _MaVaoVien, _NgayChiDinh,_MaKhoa); //GlobalModuls.Global.glbKhoa_CapNhat
            //_ds.SQL = string.Format("select aa.MaVaoVien,N'Số HSBA: ' + aa.SoHSBA as SoHSBA,N'(Lần thứ   ' + LanMo +')' as LanMo,HoTen,year(getdate()) - NamSinh as Tuoi,case when gioitinh = 0 then N'Giới tính: Nữ' else N'Giới tính: Nam' end as GioiTinh,"
            //    + " Lower(nghenghiep) as nghenghiep,DiaChi,QuaTrinhBL,benhnhan_khoa.ngaychuyen as NgayVaoVien,N'Chẩn đoán vào viện  ' + benhnhan_khoa.ChanDoan as ChanDoanVaoVien,"
            //    + " N'Chẩn đoán trước mổ:  ' + benhnhan_phieudieutri.ChanDoan as ChanDoanTruocMo,NgayMo as NgayTienHanh,lanhDaoDuyet,thongtin_phauthuat.PhuongPhapDK,"
            //    + " N'- PTV chính:  ' + nguoithuchien as nguoithuchien,N'- Phụ mổ:  ' + nguoiphu as nguoiphu,ChuanBi,N'Phương pháp vô cảm:  ' + VoCam as VoCam,N'Gây mê chính:  ' + GayMe as GayMe,N'Phụ gây mê:  ' + PhuGayMe as PhuGayMe,N'Dự trù máu:  ' + DuTruMau as DuTruMau,"
            //    + " KhoKhan,benhnhan_phieudieutri.BacSyDT,dmbacsy.tenbs as truongKhoa,N'- Chính sách: ' + dmdoituongbn.TenDT +' - '+ aa.MaDTBHYT+ SoTheBHYT as ChinhSach,SoTien,N'- Biên lai số: ' + SoBienLai as SoBienLai,N'Loại: '+LoaiPT as LoaiPhauThuat,N'Giúp việc: ' + TPKhac as ThanhPhanKhac from"
            //    + " (select * from benhnhan_chitiet where mavaovien='{0}') aa"
            //    + " inner join benhnhan on benhnhan.mabenhnhan = aa.mabenhnhan"
            //    + " inner join thongtin_phauthuat on thongtin_phauthuat.mavaovien = aa.mavaovien"
            //    + " inner join viewkhoahientai v on v.mavaovien = aa.mavaovien"
            //    + " inner join benhnhan_phieudieutri on datediff(dd,benhnhan_phieudieutri.ngaychidinh,'{1:MM/dd/yyyy}') = 0  AND benhnhan_phieudieutri.MaVaoVien=thongtin_phauthuat.MaVaoVien"
            //    + " inner join phieudieutri_chitiet on phieudieutri_chitiet.sophieu = benhnhan_phieudieutri.sophieu and phieudieutri_chitiet.loaidichvu between 'C01' and 'C24'"
            //    + " inner join benhnhan_khoa on benhnhan_khoa.mavaovien = aa.mavaovien and lanchuyenkhoa = 0"
            //    + " left join dmbacsy on dmbacsy.makhoa = v.makhoa and dmbacsy.machucvu = 3 "
            //    + " inner join viewdoituonghientai on viewdoituonghientai.mavaovien = aa.mavaovien"
            //    + " inner join dmdoituongbn on viewdoituonghientai.doituong = dmdoituongbn.madt", _MaVaoVien, _NgayChiDinh, GlobalModuls.Global.glbKhoa_CapNhat);
            this.DataSource = _ds;
        }
    }
}
