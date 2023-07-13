using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using System.Data.SqlClient;
using System.Data;
using System.Data.SqlTypes;

namespace NamDinh_QLBN.Reports
{
    /// <summary>
    /// Summary description for repPhieuChiDinh.
    /// </summary>
    public partial class repPhieuChiDinh : DataDynamics.ActiveReports.ActiveReport3
    {

        private String _SoPhieu;
        private String _MaVaoVien;
        private int STT = 0;
        public repPhieuChiDinh(string MaVaoVien,String HoTen,int Tuoi,String GioiTinh,String ChanDoan,String NoiChiDinh)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            lblTenBN.Text = HoTen;
            lblTuoi.Text = "Tuổi: " + Tuoi.ToString();
            lblGioi.Text = "Giới tính: " + GioiTinh;
            lblChanDoan.Text = "Chân đoán: " + ChanDoan;
            lblNoiChiDinh.Text = "Nơi chỉ định: " + NoiChiDinh;
            _MaVaoVien = MaVaoVien;
        }


        private void repPhieuChiDinh_DataInitialize(object sender, EventArgs e)
        {
            DataDynamics.ActiveReports.DataSources.SqlDBDataSource _ds = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            _ds.ConnectionString = GlobalModuls.Global.glbConnectionString;
            _ds.SQL = string.Format("select   CONVERT(DATE,NGAYCHIDINH) as NGAYCHIDINH,DienBienBenh,thuoc+' x '+ sl1 + ' '+ DVT_Thuoc + ' '+ GhiChu as TenThuoc,"
           + "(case when Thuoc is null then '0.00' else sl1 end)  SL_Thuoc, "
           + " case when thuoc is null then ' ' else DVT_Thuoc end  DVT_Thuoc,Case when Dichvu is null then DienBienBenh else Dichvu +' x '+  sl2  + ' '+ DVT_dichvu end AS Tendichvu,"
           + " (case when Dichvu is null then'0.00' else sl2 end) SL_dichvu,"
           + " case when Dichvu is null then ' ' else DVT_dichvu end DVT_dichvu "
           + "  from ( select B.SOHSBA,A.HoTen,A.NamSinh,B.Buong,B.Giuong,KHOA.ChanDoan,C.NGAYCHIDINH,C.DienBienBenh,"
           + "     (case when e.LoaiDichvu = 'D01' then TenDichVu end ) as Thuoc,convert(varchar(12),D.SoLuong) as sl1,e.DVT as DVT_Thuoc,d.ghichu,"
           + "     case when e.LoaiDichvu like N'%C%' then TenDichVu end as Dichvu,convert(varchar(12),D.SoLuong) as  sl2,e.DVT as DVT_dichvu"
           + "  from NAMDINH_QLBN.DBO.BENHNHAN A INNER JOIN NAMDINH_QLBN.DBO.BENHNHAN_CHITIET B ON A.MaBenhNhan= B.MaBenhNhan "
           + "  INNER JOIN NAMDINH_QLBN.DBO.ViewKHOAHIENTAI KHOA ON KHOA.MaVaoVien = B.MAVAOVIEN  "
           + "  INNER JOIN NAMDINH_QLBN.DBO.BENHNHAN_PHIEUDIEUTRI C ON C.MaVaoVien = B.MAVAOVIEN AND C.MAKHOA = KHOA.MaKhoa "
           + "  INNER JOIN NAMDINH_QLBN.DBO.PHIEUDIEUTRI_CHITIET D ON D.SOPHIEU = C.SOPHIEU  "
           + "  INNER JOIN NAMDINH_QLBN.DBO.DMLENCHIPHI E ON E.MaDichvu = d.MaDichVu and (e.LoaiDichvu in ('D01') or (e.LoaiDichvu like N'C%')) "
           + " where b.MaVaoVien = {0} ) x", _MaVaoVien)
           + " Order by NGAYCHIDINH";
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
            STT = 0;
        }

        //private void detail_Format(object sender, EventArgs e)
        //{
        //    STT++;
        //    lblSTT.Text = STT.ToString();
        //}

        private void repPhieuChiDinh_ReportStart(object sender, EventArgs e)
        {
            this.PageSettings.Margins.Top = (float)0.7;
            this.PageSettings.Margins.Left = (float)0.5;
            this.PageSettings.Margins.Right = (float)0.4;
            this.PageSettings.Margins.Bottom = (float)0.5;
        }

        private void pageHeader_Format(object sender, EventArgs e)
        {

        }
    }
}
