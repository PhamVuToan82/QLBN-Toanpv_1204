using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace NamDinh_QLBN.Reports.BaoCaoNoiTru.PhauThuat
{
    /// <summary>
    /// Summary description for repCLS_ByBS.
    /// </summary>
    public partial class  rptBangKeSoCaPhauThuat_ThanhToan : DataDynamics.ActiveReports.ActiveReport3
    {
        private System.DateTime _TNgay, _DNgay;
        private String _MaKhoa, _TenKhoa;
        public rptBangKeSoCaPhauThuat_ThanhToan(System.DateTime TNgay, System.DateTime DNgay, String MaKhoa, String TenKhoa)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent(); 
            _TNgay = TNgay;
            _DNgay = DNgay;
            _MaKhoa = MaKhoa;
            _TenKhoa = TenKhoa;
            lblNgayThang.Text = string.Format("Thời gian thanh toán Từ ngày {0:dd/MM/yyyy} đến ngày {1:dd/MM/yyyy}", TNgay, DNgay);
            lbKhoa.Text = _TenKhoa.ToUpper();
        }

        private void repCLS_ByBS_ReportStart(object sender, EventArgs e)
        {
            this.Document.Name = "Bảng kê số ca thủ thuật";
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.PageSettings.Orientation = PageOrientation.Landscape;

            this.PageSettings.Margins.Left = (float)0.2;
            this.PageSettings.Margins.Right = (float)0.0;
            this.PageSettings.Margins.Top = (float)0.25;
            this.PageSettings.Margins.Bottom = (float)0.2;
        }

        private void repCLS_ByBS_DataInitialize(object sender, EventArgs e)
        {
            DataDynamics.ActiveReports.DataSources.SqlDBDataSource _ds = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            _ds.ConnectionString = GlobalModuls.Global.glbConnectionString;
            _ds.SQL = String.Format("set dateformat dmy SELECT  LoaiPhauThuat as MaLoaiPT, bnpt.LoaiPT, Hoten,Namsinh,dt.TenDT, e.Tentat as KhoaCD, a.SoPhieuCD as MaPhieuCD, d.Chandoan, dv.Tendichvu, right(bnpt.LoaiPT, 2) as TenTat_LoaiPT,Ngaymo, Nguoithuchien, Gayme, Nguoiphu, TPKhac,  case P.Dathanhtoan when 1 then '' else 'X' end as Dathanhtoan"
                                                            + " FROM((((BENHNHAN_PHAUTHUAT a INNER JOIN BENHNHAN_CHITIET b ON a.MaVaoVien = b.MaVaoVien)  INNER JOIN BENHNHAN c ON b.MaBenhNhan = c.MaBenhNhan)"
                                                            + " INNER JOIN BENHNHAN_PHIEUDIEUTRI d ON a.SoPhieuCD = d.SoPhieu and d.MaVaoVien = a.MaVaoVien)"
                                                            + " INNER JOIN PHIEUDIEUTRI_CHITIET P ON P.SOPHIEU = D.SOPHIEU  INNER JOIN DMKHOAPHONG e ON d.MaKhoa = e.MaKhoa and p.MaDichVu = a.MaPT)"
                                                            + " INNER JOIN DMPHAUTHUAT f ON p.Madichvu = f.MaDichVu  INNER JOIN VIEWDOITUONGHIENTAI g ON g.MAVAOVIEN = B.MAVAOVIEN"
                                                            + " INNER JOIN DMDOITUONGBN dt ON g.Doituong = dt.MaDT  INNER JOIN NAMDINH_SYSDB.dbo.DMDICHVU dv ON a.MaPT = dv.Madichvu"
                                                            + " INNER JOIN NAMDINH_QLBN.DBO.THONGTIN_PHAUTHUAT bnpt on bnpt.MaVaoVien = b.MaVaoVien"
                                                            + " INNER JOIN NAMDINH_QLBN.DBO.DMDICHVU_KHOA ON DMDICHVU_KHOA.MaDichVu = a.MaPT"
                                                            + " WHERE NgayMo >= '01/05/2022 00:00:01' and DMDICHVU_KHOA.MAKHOA = '{0}' and b.thoigianthanhtoan  >= '{1:dd/MM/yyyy 00:00:01}' and b.thoigianthanhtoan <= '{2:dd/MM/yyyy 23:59:59}' and f.LoaiPhauThuat in (11,21,3,4) "
                                                            + " ORDER BY LoaiPT, NgayMo ", _MaKhoa, _TNgay, _DNgay);
            this.DataSource = _ds;
        }
        private void detail_BeforePrint(object sender, EventArgs e)
        {
            foreach (TextBox txt in detail.Controls)
                txt.Height = detail.Height;
        }

        private void detail_Format(object sender, EventArgs e)
        {
            textBox1.Text = string.Format("{0}", int.Parse(textBox1.Text) + 1);
        }

        private void pageFooter_Format(object sender, EventArgs e)
        {
            lbPage.Text = String.Format("{0}", int.Parse(lbPage.Text) + 1);
        }
    }
}
