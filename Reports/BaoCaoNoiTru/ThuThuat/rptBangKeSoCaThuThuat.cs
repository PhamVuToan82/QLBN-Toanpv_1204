using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace NamDinh_QLBN.Reports.BaoCaoNoiTru.ThuThuat
{
    /// <summary>
    /// Summary description for repCLS_ByBS.
    /// </summary>
    public partial class  rptBangKeSoCaThuThuat : DataDynamics.ActiveReports.ActiveReport3
    {
        private System.DateTime _TNgay, _DNgay;
        private String _MaKhoa, _TenKhoa;
        public rptBangKeSoCaThuThuat(System.DateTime TNgay, System.DateTime DNgay, String MaKhoa, String TenKhoa)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent(); 
            _TNgay = TNgay;
            _DNgay = DNgay;
            _MaKhoa = MaKhoa;
            _TenKhoa = TenKhoa;
            lblNgayThang.Text = string.Format("Từ ngày {0:dd/MM/yyyy} đến ngày {1:dd/MM/yyyy}", TNgay, DNgay);
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
            //DataDynamics.ActiveReports.DataSources.SqlDBDataSource _ds = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            //_ds.ConnectionString = GlobalModuls.Global.glbConnectionString;
            //_ds.SQL = String.Format("select * from (SELECT Hoten,Namsinh,dt.TenDT, e.Tentat as KhoaCD, a.MaPhieuCD, d.Chandoan, dv.Tendichvu, Left(LoaiPhauThuat,1) as LoaiPT, Ngaymo, Nguoithuchien, Gayme, Nguoiphu, TPKhac, "
            //+ " case P.Dathanhtoan when 1 then '' else 'X' end as Dathanhtoan  "
            //+ " FROM ((((THONGTIN_THUTHUAT a INNER JOIN BENHNHAN_CHITIET b ON a.MaVaoVien=b.MaVaoVien) "
            //+ " INNER JOIN BENHNHAN c ON b.MaBenhNhan=c.MaBenhNhan) "
            //+ " INNER JOIN BENHNHAN_PHIEUDIEUTRI d ON a.MaPhieuCD=d.SoPhieu) "
            //+ " INNER JOIN PHIEUDIEUTRI_CHITIET P ON P.SOPHIEU = D.SOPHIEU AND P.MADICHVU = A.Madichvu AND P.DATHUCHIEN =1 "
            //+ " INNER JOIN DMKHOAPHONG e ON d.MaKhoa=e.MaKhoa) "
            //+ " INNER JOIN DMPHAUTHUAT f ON a.Madichvu=f.MaDichVu "
            //+ " INNER JOIN VIEWDOITUONGHIENTAI g ON g.MAVAOVIEN = B.MAVAOVIEN "
            //+ " INNER JOIN DMDOITUONGBN dt ON g.Doituong = dt.MaDT "
            //+ " INNER JOIN NAMDINH_SYSDB.dbo.DMDICHVU dv ON a.Madichvu = dv.Madichvu  "
            //+ " WHERE NgayMo >= '{1:MM/dd/yyy 00:00:01}' and NgayMo <= '{2:MM/dd/yyy 23:59:59}' and a.KhoaTH = '{0}'"
            //+ " Union all "
            //+ " SELECT Tenbenhnhan as Hoten,Namsinh,dt.TenDT, e.Tentat as KhoaCD, a.MaPhieuCD, '' as Chandoan, dv.Tendichvu, Left(LoaiPhauThuat,1) as LoaiPT, Ngaymo, Nguoithuchien, Gayme, Nguoiphu, TPKhac, '' as Dathanhtoan  "
            //+ " FROM ((((Namdinh_Khambenh.dbo.THONGTIN_THUTHUAT a "
            //+ " INNER JOIN Namdinh_Khambenh.dbo.tblKhambenh b ON a.Makhambenh=b.Makhambenh) "
            //+ " INNER JOIN Namdinh_Khambenh.dbo.tblBenhnhan c ON b.MaBenhNhan=c.MaBenhNhan) "
            //+ " INNER JOIN Namdinh_Khambenh.dbo.tblKhambenh_Chidinh d ON a.MaPhieuCD=d.MaphieuCD) "
            //+ " INNER JOIN Namdinh_Khambenh.dbo.tblKhambenh_dichvu P ON P.MaphieuCD = D.MaphieuCD AND P.MADICHVU = A.Madichvu AND P.DATHUCHIEN =1 "
            //+ " INNER JOIN DMKHOAPHONG e ON d.KhoaCD=e.MaKhoa) "
            //+ " INNER JOIN DMPHAUTHUAT f ON a.Madichvu=f.MaDichVu" 
            //+ " INNER JOIN DMDOITUONGBN dt ON b.Doituong = dt.MaDT" 
            //+ " INNER JOIN NAMDINH_SYSDB.dbo.DMDICHVU dv ON a.Madichvu = dv.Madichvu  "
            //+ " WHERE NgayMo >= '{1:MM/dd/yyy 00:00:01}' and NgayMo <= '{2:MM/dd/yyy 23:59:59}' and a.KhoaTH = '{0}') X"
            //+ " ORDER BY LoaiPT, NgayMo ", _MaKhoa, _TNgay, _DNgay);
            //this.DataSource = _ds;
            DataDynamics.ActiveReports.DataSources.SqlDBDataSource _ds = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            _ds.ConnectionString = GlobalModuls.Global.glbConnectionString;
            _ds.SQL = String.Format("select * from (SELECT  LoaiPhauThuat as MaLoaiPT, LoaiPT, Hoten,Namsinh,dt.TenDT, e.Tentat as KhoaCD, a.MaPhieuCD, d.Chandoan, dv.Tendichvu, right(LoaiPT,2) as TenTat_LoaiPT, Ngaymo, Nguoithuchien, Gayme, Nguoiphu, TPKhac, "
            + " case P.Dathanhtoan when 1 then '' else 'X' end as Dathanhtoan  "
            + " FROM ((((THONGTIN_THUTHUAT a INNER JOIN BENHNHAN_CHITIET b ON a.MaVaoVien=b.MaVaoVien) "
            + " INNER JOIN BENHNHAN c ON b.MaBenhNhan=c.MaBenhNhan) "
            + " INNER JOIN BENHNHAN_PHIEUDIEUTRI d ON a.MaPhieuCD=d.SoPhieu) "
            + " INNER JOIN PHIEUDIEUTRI_CHITIET P ON P.SOPHIEU = D.SOPHIEU AND P.MADICHVU = A.Madichvu " //AND P.DATHUCHIEN =1 
            + " INNER JOIN DMKHOAPHONG e ON d.MaKhoa=e.MaKhoa) "
            + " INNER JOIN DMPHAUTHUAT f ON a.Madichvu=f.MaDichVu "
            + " INNER JOIN VIEWDOITUONGHIENTAI g ON g.MAVAOVIEN = B.MAVAOVIEN "
            + " INNER JOIN DMDOITUONGBN dt ON g.Doituong = dt.MaDT "
            + " INNER JOIN NAMDINH_SYSDB.dbo.DMDICHVU dv ON a.Madichvu = dv.Madichvu  "
            + " WHERE NgayMo >= '{1:MM/dd/yyy 00:00:01}' and NgayMo <= '{2:MM/dd/yyy 23:59:59}' and a.KhoaTH = '{0}'"
            + " Union all "
            + " SELECT LoaiPhauThuat as MaLoaiPT,LoaiTT as LoaiPT, Tenbenhnhan as Hoten,Namsinh,dt.TenDT, e.Tentat as KhoaCD, a.MaPhieuCD,kqdvkham.Chandoan , dv.Tendichvu, right(LoaiTT,2) as TenTat_LoaiPT, Ngaymo, Nguoithuchien, Gayme, Nguoiphu, TPKhac,case b.DaTinhPhi when 1 then '' else 'X' end as Dathanhtoan  "
            + " FROM ((((Namdinh_Khambenh.dbo.THONGTIN_THUTHUAT a "
            + " INNER JOIN Namdinh_Khambenh.dbo.tblKhambenh b ON a.Makhambenh=b.Makhambenh) "
            + " INNER JOIN Namdinh_Khambenh.dbo.tblBenhnhan c ON b.MaBenhNhan=c.MaBenhNhan) "
            + " INNER JOIN Namdinh_Khambenh.dbo.tblKhambenh_Chidinh d ON a.MaPhieuCD=d.MaphieuCD) "
            + " INNER JOIN Namdinh_Khambenh.dbo.tblKhambenh_dichvu P ON P.MaphieuCD = D.MaphieuCD AND P.MADICHVU = A.Madichvu AND P.DATHUCHIEN =1 "
            + " INNER JOIN DMKHOAPHONG e ON d.KhoaCD=e.MaKhoa) "
            + " INNER JOIN DMPHAUTHUAT f ON a.Madichvu=f.MaDichVu"
            + " INNER JOIN DMDOITUONGBN dt ON b.Doituong = dt.MaDT"
            + " INNER JOIN NAMDINH_SYSDB.dbo.DMDICHVU dv ON a.Madichvu = dv.Madichvu  "
            + " inner join NAMDINH_QLBN.dbo.tblkhambenh_kqdvkham_Max kqdvkham on kqdvkham.MaKhambenh =  b.MaKhambenh "
            + " WHERE NgayMo >= '{1:MM/dd/yyy 00:00:01}' and NgayMo <= '{2:MM/dd/yyy 23:59:59}' and a.KhoaTH = '{0}') X"
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
