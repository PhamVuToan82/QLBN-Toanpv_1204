using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace NamDinh_QLBN.Reports
{
    /// <summary>
    /// Summary description for rptPhieuLinhThuoc.
    /// </summary>
    public partial class rptPhieuLinhVT: DataDynamics.ActiveReports.ActiveReport3
    {
        string _MaPhieu, _Ngay,_MaKhoa;
        public rptPhieuLinhVT(string TenKhoa,string MaKhoa,string MaPhieuDuTru,string Ngay)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            _MaPhieu = MaPhieuDuTru;
            _Ngay = Ngay;
            _MaKhoa = MaKhoa;
            lblMaPhieu.Text = "Số: " + MaPhieuDuTru;
            lblKhoa.Text = TenKhoa;
            lbNgay.Text = Ngay;
            if(TenKhoa == "Trung tâm Ung bướu")
            {
                label14.Text = "GIÁM ĐỐC TRUNG TÂM";
            }
        }

        private void detail_Format(object sender, EventArgs e)
        {
            STT.Text =string.Format("{0}", int.Parse(STT.Text) + 1);
        }

        private void detail_BeforePrint(object sender, EventArgs e)
        {
            STT.Height = textBox2.Height = textBox3.Height = textBox4.Height = textBox5.Height = textBox12.Height = this.detail.Height = textBox1.Height;
        }

        private void reportFooter1_Format(object sender, EventArgs e)
        {
            //textBox8.Text = "Cộng khoản: " + textBox8.Text;
        }

        private void groupHeader1_Format(object sender, EventArgs e)
        {
            STT.Text = "0";
            if (lblLoaiDV.Text == "D02") lblKhoaKho.Text = "TRƯỞNG PHÒNG VT";
            else lblKhoaKho.Text = "TRƯỞNG KHOA DƯỢC";
        }

        private void rptPhieulinhThuoc_DataInitialize(object sender, EventArgs e)
        {
            DataDynamics.ActiveReports.DataSources.SqlDBDataSource _ds = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            _ds.ConnectionString = GlobalModuls.Global.glbConnectionString;
            _ds.SQL = String.Format("select KhoID,TenKho,SoLuongYC,MaChiPhi,TenDichVu,DVT,LoaiDichVu,Nhom, "
                + "case HinhThuc when 0 then N'Hình thức: Lĩnh mới' when 1 then N'Hình thức: Đổi trả' end as HinhThuc "
                +"from ( "
                + "SELECT isnull(dt.KhoID,'') as KhoID,isnull(dmkho.tenkho,N'Khoa Dược') as TenKho,dt.SoLuongYC,dt.machiphi,dmdichvu.tendichvu,dmdichvu.dvt,vt.Nhom,dt.HinhThuc,"
	            +" dmdichvu.LoaiDichVu  FROM    DuTruVatTu  dt inner JOIN DMDICHVU ON DMDICHVU.MADICHVU = dt.MACHIPHI "
                +"inner JOIN VATTU vt ON vt.MACHIPHI = dt.MACHIPHI AND vt.MAKHOA = dt.MaKhoa "
	            +"left join NamDinh_Duoc.dbo.danhmuckho dmkho on dmkho.khoid = dt.khoid "
	            +"WHERE MaPhieuDuTru='{0}' and SoLuongYC >0 and dt.LoaiDichVu='D06' "
	            +"union all "
	            +"SELECT isnull(dt.KhoID,'') as KhoID,isnull(dmkho.tenkho,N'Phòng Vật tư') as TenKho,dt.SoLuongYC,dt.machiphi,dmdichvu.tendichvu,dmdichvu.dvt,vt.Nhom,dt.HinhThuc,"
	            +"dmdichvu.LoaiDichVu  FROM   DuTruVatTu  dt left JOIN DMDICHVU ON DMDICHVU.MADICHVU = dt.MACHIPHI "
                + "inner JOIN VATTU vt ON vt.MACHIPHI = dt.MACHIPHI AND vt.MAKHOA = dt.MaKhoa "
	            +"left join NamDinh_qlvtth.dbo.danhmuckho dmkho on dmkho.khoid = dt.khoid "
                + "WHERE MaPhieuDuTru='{0}' and SoLuongYC >0 and dmdichvu.LoaiDichVu='D02' ) x "
                +"order by Nhom,tenkho,tendichvu", _MaPhieu);
            this.DataSource = _ds;
        }

        private void rptPhieuLinhVT_ReportStart(object sender, EventArgs e)
        {
            this.Document.Name = "Phiếu lĩnh vật tư";
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.PageSettings.Orientation = PageOrientation.Portrait;

            this.PageSettings.Margins.Left = (float)0.5;
            this.PageSettings.Margins.Top = (float)1.0;
            this.PageSettings.Margins.Bottom = (float)0.10;
            this.PageSettings.Margins.Right = (float)0.2;

            //lblNgayIn.Text = string.Format("In ngày {0:dd/MM/yyyy}", GlobalModuls.Global.NgayLV);
            lblNgayIn.Text = string.Format("Ngày {0:dd/MM/yyyy}", _Ngay);
            lbNgay.Text = string.Format("Ngày {0:dd/MM/yyyy}", _Ngay);
        }
    }
}
