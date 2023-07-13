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
    public partial class repPhieuChiDinh_ketquaA5 : DataDynamics.ActiveReports.ActiveReport3
    {
        private String _SoPhieu;
        public string _dieuduong;
        private int STT = 0;
        int page = 0;
        public repPhieuChiDinh_ketquaA5(String HoTen, int Tuoi, String GioiTinh, String ChanDoan, String NoiChiDinh, int CapCuu, String SoPhieu, object NgayChiDinh,string dieuduong)
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
            txtNongDoCon.Text = "Lưu ý: \n" + "- Không sát trùng chỗ lấy máu bằng cồn; \n" + "- Ghi rõ giờ, ngày lấy mẫu xét nghiệm;\n" + "- Chuyển ngay mẫu đến Khoa Hóa sinh.";
            _dieuduong = dieuduong;
        }


        private void repPhieuChiDinh_DataInitialize(object sender, EventArgs e)
        {
             DataDynamics.ActiveReports.DataSources.SqlDBDataSource _ds = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
             _ds.ConnectionString = GlobalModuls.Global.glbConnectionString;
             _ds.SQL = string.Format("SELECT BB.DATHUCHIEN,CASE WHEN BB.DATHUCHIEN = 0 THEN '' ELSE N'BẢN SAO' END AS BANSAO,CASE WHEN DMGIUONGBENH.TenGiuong IS NULL THEN N'Giường:' else DMGIUONGBENH.TenGiuong end as Giuong,case when DMBUONGBENH.TenBuong is null then N'Buồng:' else DMBUONGBENH.TenBuong end as Buong,bb.GhiChu,N'Số phiếu: ' + AA.SOPHIEU as SoPhieu, AA.MAVAOVIEN,DMDICHVU.DVT,"
               + " CASE when AA.CapCuu = 0 THEN 'X' else ''  end as Thuong,"
               + " case phong.makhoa when 'NV2502' then N'Thời gian lấy bệnh phẩm:.......................' when 'NV2501' then N'Thời gian lấy bệnh phẩm:.......................' when 'NV2503' then N'Thời gian lấy bệnh phẩm:.......................' else '' end as TG2,"
               + " case phong.makhoa when 'NV2502' then N'Thời gian bàn giao bệnh phẩm:..............' when 'NV2501' then N'Thời gian bàn giao bệnh phẩm:..............' when 'NV2503' then N'Thời gian bàn giao bệnh phẩm:..............' else '' end as TG1,"
               + " CASE when AA.CapCuu = 1 THEN 'X' else ''  end as CauCuu,BB.DONGIA,BB.MADICHVU,BB.SOLUONG,bb.Soluong* bb.dongia as ThanhTien,"
               + " CASE WHEN DMDOITUONGBN.MADT = 1 THEN N'Đối tượng: ' + DMDOITUONGBN.TENDT + N'. Số thẻ: ' + V.MaDoiTuongBHXH + V.SOTHE ELSE N'Đối tượng: ' + DMDOITUONGBN.TENDT END as SOTHE,CASE WHEN DMDOITUONGBN.MADT = 1 THEN N'Hạn thẻ: ' + convert(nvarchar(10),v.GTriDen,103) ELSE '' END as HanThe, N'Địa chỉ: ' +  CC.DIACHI as DIACHI,DMDICHVU.TENDICHVU,L.TENLOAIDICHVU,"
               + " L.MALOAIDICHVU,V.GTriDen,phong.tenkhoa,isnull(tblThietLapDichVu.NhomPhieu,100) as NhomPhieu,dmbacsy.tenbs,case when cc.SoHSBA is null then N'Số bệnh án:............' else N'Số bệnh án: ' + CC.SoHSBA end SoHSBA,AA.MAVAOVIEN, N'Địa điểm: ' + phong.Diadiem as DiaDiem FROM"
               + " (SELECT * FROM BENHNHAN_PHIEUDIEUTRI WHERE SOPHIEU='{0}') AA"
               + " INNER JOIN PHIEUDIEUTRI_CHITIET BB ON AA.SOPHIEU = BB.SOPHIEU "
               + " INNER JOIN BENHNHAN_CHITIET CC ON CC.MAVAOVIEN = AA.MAVAOVIEN "
               + " INNER JOIN VIEWDOITUONGHIENTAI V ON V.MAVAOVIEN = AA.MAVAOVIEN"
               + " LEFT JOIN DMDOITUONGBN ON DMDOITUONGBN.MADT = BB.DOITUONGBN"
               + " INNER JOIN DMDICHVU ON DMDICHVU.MADICHVU = BB.MADICHVU "
               + " LEFT JOIN DMBUONGBENH ON DMBUONGBENH.ID_BUONG = CC.BUONG AND DMBUONGBENH.MAKHOA = AA.MAKHOA"
               + " LEFT JOIN DMGIUONGBENH ON DMGIUONGBENH.ID_BUONG = CC.BUONG AND DMGIUONGBENH.ID_GIUONG  = CC.GIUONG AND DMGIUONGBENH.MAKHOA = AA.MAKHOA"
               + " INNER JOIN [" + GlobalModuls.Global.glbSysDB + "].DBO.DMLOAIDICHVU L ON L.MALOAIDICHVU = BB.LOAIDICHVU "
               + " LEFT join [" + GlobalModuls.Global.glbSysDB + "].dbo.DMDICHVU_KHOA q on q.madichvu = bb.madichvu "
               + " LEFT join dmkhoaphong phong on phong.makhoa = q.makhoa "
               + " left join tblThietLapDichVu on tblThietLapDichVu.madichvu = bb.madichvu and tblThietLapDichVu.makhoa = aa.makhoa"
               + " left join dmbacsy on dmbacsy.makhoa = aa.makhoa and dmbacsy.MaBS = aa.mabs "
               + " WHERE (BB.LOAIDICHVU LIKE 'C[5-6]%' or BB.LOAIDICHVU = 'C02' or bb.Loaidichvu = 'E01') AND TINHPHI = 0 order by L.MALOAIDICHVU,NhomPhieu,BB.DATHUCHIEN,DMDICHVU.thutuchondichvu", _SoPhieu);
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
            if (txtMadichvu.Text == "C50314" || txtMadichvu.Text == "C50323")
            {
                txtNongDoCon.Visible = true; 
            }
        }

        private void repPhieuChiDinh_ReportStart(object sender, EventArgs e)
        {
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A5;
            this.PageSettings.Orientation = PageOrientation.Portrait;
            this.PageSettings.Margins.Top = (float)0.2;
            this.PageSettings.Margins.Left = (float)0.2;
            this.PageSettings.Margins.Right = (float)0.0;
            this.PageSettings.Margins.Bottom = (float)0.0;
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

        private void groupFooter3_Format(object sender, EventArgs e)
        {
            if (lbNoiChiDinh.Text == "Khoa Hóa sinh" || lbNoiChiDinh.Text == "Khoa Huyết học" || lbNoiChiDinh.Text == "Khoa Huyết học")
            {
                label24.Text = "Điều dưỡng : " + _dieuduong;
            }
            else { label24.Text = ""; }
        }
    }
}
