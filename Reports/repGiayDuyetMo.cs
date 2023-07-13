using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace NamDinh_QLBN.Reports
{
    /// <summary>
    /// Summary description for repGiayDuyetMo.
    /// </summary>
    public partial class repGiayDuyetMo : DataDynamics.ActiveReports.ActiveReport3
    {
        private string _MaVaoVien = "";
        private object _NgayChiDinh;
        public repGiayDuyetMo(String MaVaoVien,object NgayChiDinh,string SoPhieu)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            _MaVaoVien = MaVaoVien;
            _NgayChiDinh = NgayChiDinh;
            barcode1.Text = "Số phiếu: " + SoPhieu;
            lblKhoa.Text = GlobalModuls.Global.glbTenKhoaPhong;
            if(lblKhoa.Text == "Trung tâm Ung bướu")
            {
                label49.Text = "GIÁM ĐỐC TRUNG TÂM";
            }
        }

        private void repGiayDuyetMo_ReportStart(object sender, EventArgs e)
        {
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.PageSettings.Orientation = PageOrientation.Portrait;
            this.PageSettings.Margins.Top = (float)0.25;
            this.PageSettings.Margins.Left = (float)0.6;
            this.PageSettings.Margins.Right = (float)0.175;
            this.PageSettings.Margins.Bottom = (float)0.0;
            lblNgayThang.Text = string.Format("{0:HH} giờ {0:mm} - Ngày {0:dd} tháng {0:MM} năm {0:yyyy}", _NgayChiDinh);
        }

        private void repGiayDuyetMo_DataInitialize(object sender, EventArgs e)
        {
             DataDynamics.ActiveReports.DataSources.SqlDBDataSource _ds = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            _ds.ConnectionString = GlobalModuls.Global.glbConnectionString;
            _ds.SQL = string.Format("set dateformat mdy select aa.MaVaoVien,N'Số HSBA: ' + aa.SoHSBA as SoHSBA,N'(Lần thứ ' + LanMo +')' as LanMo,HoTen,year(getdate()) - NamSinh as Tuoi,case when gioitinh = 0 then N'Giới tính: Nữ' else N'Giới tính: Nam' end as GioiTinh,"
                + " Lower(nghenghiep) as nghenghiep,DiaChi,QuaTrinhBL,benhnhan_khoa.ngaychuyen as NgayVaoVien,N'* Chẩn đoán vào viện  ' + benhnhan_khoa.ChanDoan as ChanDoanVaoVien,"
                + " N'* Chẩn đoán trước mổ:  ' + benhnhan_phieudieutri.ChanDoan as ChanDoanTruocMo,NgayMo as NgayTienHanh,lanhDaoDuyet,thongtin_phauthuat.PhuongPhapDK,"
                + " N'* Phẫu thuật viên chính:  ' + nguoithuchien as nguoithuchien,N'* Người phụ:  ' + nguoiphu as nguoiphu,ChuanBi,N'* Phương pháp vô cảm:  ' + VoCam as VoCam,N'* Người gây mê:  ' + GayMe as GayMe,N'* Dự trù máu:  ' + DuTruMau as DuTruMau,"
                + " KhoKhan,benhnhan_phieudieutri.BacSyDT,dmbacsy.tenbs as truongKhoa from"
                + " (select * from benhnhan_chitiet where mavaovien='{0}') aa"
                + " inner join benhnhan on benhnhan.mabenhnhan = aa.mabenhnhan"
                + " inner join thongtin_phauthuat on thongtin_phauthuat.mavaovien = aa.mavaovien"
                + " inner join viewkhoahientai v on v.mavaovien = aa.mavaovien"
                + " inner join benhnhan_phieudieutri on datediff(dd,benhnhan_phieudieutri.ngaychidinh,'{1:MM/dd/yyyy}') = 0 and benhnhan_phieudieutri.makhoa in {2} AND benhnhan_phieudieutri.MaVaoVien=thongtin_phauthuat.MaVaoVien"
                + " inner join phieudieutri_chitiet on phieudieutri_chitiet.sophieu = benhnhan_phieudieutri.sophieu  and phieudieutri_chitiet.loaidichvu between 'C01' and 'C24'"
                + " inner join benhnhan_khoa on benhnhan_khoa.mavaovien = aa.mavaovien and lanchuyenkhoa = 0"
                + " left join dmbacsy on dmbacsy.makhoa = v.makhoa and dmbacsy.machucvu = 3 ",_MaVaoVien,_NgayChiDinh,GlobalModuls.Global.glbKhoa_CapNhat);
            this.DataSource = _ds;
        }

        //private void repGiayDuyetMo_FetchData(object sender, FetchEventArgs eArgs)
        //{
        //    if  if (Fields["MaKhoa"].Value.ToString() == "NV1211")
        //        {
        //            label25.Text = "GIÁM ĐỐC TRUNG TÂM";
        //        }
        //}
    }
}
