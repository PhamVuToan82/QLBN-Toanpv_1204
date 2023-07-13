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
    public partial class rptSoKet15 : DataDynamics.ActiveReports.ActiveReport3
    {
        public rptSoKet15()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
        }

        private void repHoiChan_ReportStart(object sender, EventArgs e)
        {

            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.PageSettings.Orientation = PageOrientation.Portrait;

            this.PageSettings.Margins.Left = (float)0.6;
            this.PageSettings.Margins.Right = (float)0.0;
            this.PageSettings.Margins.Top = (float)0.5;
            this.PageSettings.Margins.Bottom = (float)0.0;
        }

        private void repHoiChan_DataInitialize(object sender, EventArgs e)
        {

            //DataDynamics.ActiveReports.DataSources.SqlDBDataSource _ds = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            //_ds.ConnectionString = GlobalModuls.Global.glbConnectionString;
            //_ds.SQL = String.Format("select HoTen,Year(getdate()) - NamSinh as tuoi,case when GioiTinh = 0 then N'Giới tính: Nữ' else N'Giới tính: Nam' end as GT,DieutriTNgay,DieuTriDNgay,"
            //    + " N'- Tại ' + isnull(Lower(TenGiuong),'') + '  ' + N'.       ' + isnull(TenBuong,'') + N' .         Khoa:    ' + dmkhoaphong.tenkhoa as BuongGiuong,N'- Chẩn đoán: ' + isnull(Lower(BENHNHAN_HOICHAN.ChanDoan),'') as ChanDoan,"
            //    + " BENHNHAN_HOICHAN.DieuTriTNgay,Upper(N'trích biên bản hội chẩn ' + BENHNHAN_HOICHAN.BienbanHC) as BienBanHC,BENHNHAN_HOICHAN.DieuTriDNgay,"
            //    + "  BENHNHAN_HOICHAN.ThuKy, BENHNHAN_HOICHAN.ChuToa,N'- Chủ tọa: ' + BENHNHAN_HOICHAN.ChuToa as ChuToa1,N'- Thư ký: ' + BENHNHAN_HOICHAN.ThuKy as ThuKy1,BENHNHAN_HOICHAN.ThanhVienTG,"
            //    + " BENHNHAN_HOICHAN.TomTat,BENHNHAN_HOICHAN.KetLuan,BENHNHAN_HOICHAN.HuongDT,Upper(dmkhoaphong.tenkhoa) as tenkhoa,benhnhan_hoichan.NgayHoiChan,aa.SoHSBA"
            //    + " from "
            //    + " (select Mabenhnhan,mavaovien,Buong,Giuong,N'Số vào viện: ' + SoHSBA as SoHSBA from benhnhan_chitiet where mavaovien ='{0}') aa"
            //    + " inner join benhnhan on benhnhan.mabenhnhan = aa.mabenhnhan"
            //    + " inner join BENHNHAN_HOICHAN on BENHNHAN_HOICHAN.mavaovien = aa.mavaovien"
            //    + " inner join viewkhoahientai v on v.mavaovien = aa.mavaovien"
            //    + " left join dmgiuongbenh on dmgiuongbenh.makhoa = v.makhoa and dmgiuongbenh.id_buong = aa.buong and dmgiuongbenh.id_giuong = aa.giuong"
            //    + " left join dmbuongbenh on dmbuongbenh.makhoa = v.makhoa and dmbuongbenh.id_buong = aa.buong"
            //    + " inner join dmkhoaphong on dmkhoaphong.makhoa = v.makhoa", _MaVaoVien);
            //this.DataSource = _ds;
        }

        private void rptSoKet15_FetchData(object sender, FetchEventArgs eArgs)
        {
            if (lblKhoa.Text == "ĐƠN VỊ: TRUNG TÂM UNG BƯỚU")
            {
                label65.Text = "GIÁM ĐỐC TRUNG TÂM";
            }
        }
    }
}
