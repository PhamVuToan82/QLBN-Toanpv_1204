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
    public partial class repPhieuChiDinh_ketqua : DataDynamics.ActiveReports.ActiveReport3
    {
        private String _SoPhieu;
        private int STT = 0;
        int page = 0;
        public repPhieuChiDinh_ketqua(String HoTen, int Tuoi, String GioiTinh, String ChanDoan, String NoiChiDinh, int CapCuu, String SoPhieu, object NgayChiDinh)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            lblTenBN.Text = HoTen;
            lblTuoi.Text = "Tuổi: " + Tuoi.ToString();
            lblGioi.Text = "Giới tính: " + GioiTinh;
            lblChanDoan.Text = "Chẩn đoán: " + ChanDoan;
            lblNoiChiDinh.Text = "Nơi chỉ định: " + NoiChiDinh;
            lblNgayThang.Text = String.Format("{0:HH} giờ {0:mm} - Ngày {0:dd} tháng {0:MM} năm {0:yyyy}", NgayChiDinh);
            Barcode1.Text = SoPhieu;
            _SoPhieu = SoPhieu;
        }


        private void repPhieuChiDinh_DataInitialize(object sender, EventArgs e)
        {
             DataDynamics.ActiveReports.DataSources.SqlDBDataSource _ds = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
             _ds.ConnectionString = GlobalModuls.Global.glbConnectionString;
             _ds.SQL = string.Format("SELECT CASE WHEN DMGIUONGBENH.TenGiuong IS NULL THEN N'Giường:' else DMGIUONGBENH.TenGiuong end as Giuong,case when DMBUONGBENH.TenBuong is null then N'Buồng:' else DMBUONGBENH.TenBuong end as Buong,bb.GhiChu,N'Số phiếu: ' + AA.SOPHIEU as SoPhieu, AA.MAVAOVIEN,DMDICHVU.DVT,"
                + " CASE when AA.CapCuu = 0 THEN 'X' else ''  end as Thuong,"
                + " CASE when AA.CapCuu = 1 THEN 'X' else ''  end as CauCuu,BB.DONGIA,BB.MADICHVU,BB.SOLUONG,bb.Soluong* bb.dongia as ThanhTien,"
                + " N'Đối tượng: ' + DMDOITUONGBN.TENDT + N'. Số thẻ: ' + V.MaDoiTuongBHXH + V.SOTHE as SOTHE,N'Hạn thẻ: ' + convert(nvarchar(10),v.GTriDen,103) as HanThe, N'Địa chỉ: ' +  CC.DIACHI as DIACHI,DMDICHVU.TENDICHVU,L.TENLOAIDICHVU,"
                + " L.MALOAIDICHVU,V.GTriDen,phong.tenkhoa,isnull(tblThietLapDichVu.NhomPhieu,100) as NhomPhieu,dmbacsy.tenbs  FROM"
                + " (SELECT * FROM BENHNHAN_PHIEUDIEUTRI WHERE SOPHIEU='{0}') AA"
                + " INNER JOIN PHIEUDIEUTRI_CHITIET BB ON AA.SOPHIEU = BB.SOPHIEU "
                + " INNER JOIN BENHNHAN_CHITIET CC ON CC.MAVAOVIEN = AA.MAVAOVIEN "
                + " INNER JOIN VIEWDOITUONGHIENTAI V ON V.MAVAOVIEN = AA.MAVAOVIEN"
                + " LEFT JOIN DMDOITUONGBN ON DMDOITUONGBN.MADT = BB.DOITUONGBN"
                + " INNER JOIN DMDICHVU ON DMDICHVU.MADICHVU = BB.MADICHVU "
                + " LEFT JOIN DMBUONGBENH ON DMBUONGBENH.ID_BUONG = CC.BUONG AND DMBUONGBENH.MAKHOA = AA.MAKHOA"
                + " LEFT JOIN DMGIUONGBENH ON DMGIUONGBENH.ID_BUONG = CC.BUONG AND DMGIUONGBENH.ID_GIUONG  = CC.GIUONG AND DMGIUONGBENH.MAKHOA = AA.MAKHOA"
                + " INNER JOIN ["+ GlobalModuls.Global.glbSysDB +"].DBO.DMLOAIDICHVU L ON L.MALOAIDICHVU = BB.LOAIDICHVU "
                + " inner join [" + GlobalModuls.Global.glbSysDB + "].dbo.DMDICHVU_KHOA q on q.madichvu = bb.madichvu "
                + " inner join dmkhoaphong phong on phong.makhoa = q.makhoa "
                + " left join tblThietLapDichVu on tblThietLapDichVu.madichvu = bb.madichvu and tblThietLapDichVu.makhoa = aa.makhoa"
                + " left join dmbacsy on dmbacsy.makhoa = aa.makhoa and dmbacsy.MaBS = aa.mabs "
                + " WHERE BB.LOAIDICHVU LIKE 'C5%' AND BB.DATHUCHIEN = 0 AND TINHPHI = 0 order by L.MALOAIDICHVU,NhomPhieu,DMDICHVU.thutuchondichvu", _SoPhieu);
             this.DataSource = _ds;
        }

        private void detail_BeforePrint(object sender, EventArgs e)
        {
            foreach (TextBox txt in detail.Controls)
            {
                txt.Height = detail.Height;
            }
        }
        private void groupHeader1_Format(object sender, EventArgs e)
        {
            
        }

        private void detail_Format(object sender, EventArgs e)
        {
            STT++;
            lblSTT.Text = STT.ToString();
        }

        private void repPhieuChiDinh_ReportStart(object sender, EventArgs e)
        {
            this.PageSettings.Margins.Top = (float)0.7;
            this.PageSettings.Margins.Left = (float)0.25;
            this.PageSettings.Margins.Right = (float)0.0;
            this.PageSettings.Margins.Bottom = (float)0.5;
        }

        private void pageHeader_Format(object sender, EventArgs e)
        {

        }

        private void repPhieuChiDinh_ketqua_PageStart(object sender, EventArgs e)
        {
            page += 1;
            txtPage.Text = "Trang " + page.ToString();
        }

        private void groupHeader2_Format(object sender, EventArgs e)
        {
            STT = 0;
        }
    }
}
