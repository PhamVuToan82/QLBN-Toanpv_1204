using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using System.Drawing.Printing;
using DataDynamics.ActiveReports.DataSources;
using GlobalModuls;

namespace NamDinh_QLBN.Reports
{
    /// <summary>
    /// Summary description for repDuyetPhauThuat.
    /// </summary>
    public partial class repDuyetThuThuat : DataDynamics.ActiveReports.ActiveReport3
    {
        private string _MaVaoVien = "";
        private string _MaphieuCD = "";
        private string _Madichvu = "";
        private object _NgayChiDinh;
        public repDuyetThuThuat(String MaVaoVien, String MaphieuCD, String Madichvu, object NgayChiDinh)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            _MaVaoVien = MaVaoVien;
            _MaphieuCD = MaphieuCD;
            _Madichvu = Madichvu;
            _NgayChiDinh = NgayChiDinh;
            lbTon.Text = GlobalModuls.Global.glbTenKhoaPhong;
            lblKhoa.Text = GlobalModuls.Global.glbTenKhoaPhong;
        }

        private void repDuyetPhauThuat_ReportStart(object sender, EventArgs e)
        {
            base.PageSettings.Orientation = PageOrientation.Landscape;
            base.PageSettings.PaperKind = PaperKind.A5;
            base.PageSettings.Margins.Top = 0.1f;
            base.PageSettings.Margins.Left = 0.4f;
            base.PageSettings.Margins.Right = 0f;
            base.PageSettings.Margins.Bottom = 0f;
            //this.lblNgayThang.Text = string.Format("{0:HH} giờ {0:mm} - Ng\x00e0y {0:dd} th\x00e1ng {0:MM} năm {0:yyyy}", Global.GetNgayLV());
            this.lblNgayThang.Text = string.Format("{0:HH} giờ {0:mm} - Ng\x00e0y {0:dd} th\x00e1ng {0:MM} năm {0:yyyy}", _NgayChiDinh);
        }
        private void repDuyetPhauThuat_DataInitialize(object sender, EventArgs e)
        {
            SqlDBDataSource source = new SqlDBDataSource();
            source.ConnectionString = GlobalModuls.Global.glbConnectionString;
            source.SQL = string.Format("set dateformat mdy select aa.MaVaoVien,N'Số HSBA: ' + aa.SoHSBA as SoHSBA,N'(Lần thứ   ' + LanMo +')' as LanMo,HoTen,"
            + " year(getdate()) - NamSinh as Tuoi,case when gioitinh = 0 then N'Giới t\x00ednh: Nữ' else N'Giới t\x00ednh: Nam' end as GioiTinh, "
            + " Lower(nghenghiep) as nghenghiep,DiaChi,QuaTrinhBL,benhnhan_khoa.ngaychuyen as NgayVaoVien,N'Chẩn đo\x00e1n v\x00e0o viện  ' + "
            + " benhnhan_khoa.ChanDoan as ChanDoanVaoVien, N'Chẩn đo\x00e1n:  ' + benhnhan_phieudieutri.ChanDoan as ChanDoanTruocMo,NgayMo as NgayTienHanh,"
            + " lanhDaoDuyet,THONGTIN_THUTHUAT.PhuongPhapDK, N'- Người ch\x00ednh:  ' + nguoithuchien as nguoithuchien,N'- Người phụ:  ' + nguoiphu as nguoiphu,"
            + " ChuanBi,N'Phương ph\x00e1p v\x00f4 cảm:  ' + VoCam as VoCam,N'G\x00e2y m\x00ea:  ' + GayMe as GayMe,N'Dự tr\x00f9 m\x00e1u:  ' + DuTruMau as DuTruMau,"
            + " KhoKhan,benhnhan_phieudieutri.BacSyDT,dmbacsy.tenbs as truongKhoa,N'- BHYT (số thẻ): '+ aa.MaDTBHYT+ SoTheBHYT as ChinhSach,SoTien,"
            + " N'- Bi\x00ean lai số: ' + SoBienLai as SoBienLai,N'Loại: '+LoaiPT as LoaiPhauThuat,N'Giúp việc: '+TPKhac as ThanhPhanKhac "
            + " from (select * from benhnhan_chitiet where mavaovien='{0}') aa inner join benhnhan on benhnhan.mabenhnhan = aa.mabenhnhan "
            + " inner join THONGTIN_THUTHUAT on THONGTIN_THUTHUAT.mavaovien = aa.mavaovien and THONGTIN_THUTHUAT.MaphieuCD = '{3}' and THONGTIN_THUTHUAT.Madichvu = '{4}' "
            + " inner join viewkhoahientai v on v.mavaovien = aa.mavaovien "
            + " inner join benhnhan_phieudieutri on datediff(dd,benhnhan_phieudieutri.ngaychidinh,'{1:MM/dd/yyyy}') = 0 "
            + " and benhnhan_phieudieutri.makhoa in {2} AND benhnhan_phieudieutri.MaVaoVien=THONGTIN_THUTHUAT.MaVaoVien "
            + " inner join phieudieutri_chitiet on phieudieutri_chitiet.sophieu = benhnhan_phieudieutri.sophieu and  PHIEUDIEUTRI_CHITIET.MaDichVu = THONGTIN_THUTHUAT.Madichvu"
            + " inner join benhnhan_khoa on benhnhan_khoa.mavaovien = aa.mavaovien and lanchuyenkhoa = 0 "
            + " left join dmbacsy on dmbacsy.makhoa = v.makhoa and dmbacsy.machucvu = 3  "
            + " inner join viewdoituonghientai on viewdoituonghientai.mavaovien = aa.mavaovien "
            + " inner join dmdoituongbn on viewdoituonghientai.doituong = dmdoituongbn.madt", this._MaVaoVien, this._NgayChiDinh, Global.glbKhoa_CapNhat, this._MaphieuCD, this._Madichvu);
            base.DataSource = source;
        }
    }
}
