using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using GlobalModuls;
namespace NamDinh_QLBN.Reports
{
    /// <summary>
    /// Summary description for repHoiChan.
    /// </summary>
    public partial class rptCNThuongTich : DataDynamics.ActiveReports.ActiveReport3
    {
        private String _MaVaoVien = "";
        public rptCNThuongTich(String MaVaoVien)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            _MaVaoVien = MaVaoVien;
            //   lblNgayIn.Text = string.Format("In ngày {0:dd} tháng {0:MM} năm {0:yyyy}", GlobalModuls.Global.GetNgayLV());
            label27.Text = string.Format("Nam Định, ngày {0:dd} tháng {0:MM} năm {0:yyyy}", GlobalModuls.Global.GetNgayLV());
        }

        private void repHoiChan_ReportStart(object sender, EventArgs e)
        {
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.PageSettings.Orientation = PageOrientation.Portrait;
            this.PageSettings.Margins.Left = (float)0.6;
            this.PageSettings.Margins.Right = (float)0.0;
            this.PageSettings.Margins.Top = (float)0.5;
            this.PageSettings.Margins.Bottom = (float)0.0;

            DataDynamics.ActiveReports.DataSources.SqlDBDataSource _ds = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            _ds.ConnectionString = GlobalModuls.Global.glbConnectionString;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
            SQLCmd.CommandText = String.Format("select HoTen,NamSinh,Case when NgaySinh = 0 Then '' end as NgaySinh,Case when Thangsinh = 0 then '' end as Thangsinh,NamSinh,case when GioiTinh = 0 then N'Giới tính: Nữ' else N'Giới tính: Nam' end as GT,aa.NoiCongTac,aa.NgheNghiep,'' as  CMTND,'' AS NgayCap,'' as NoiCap,"
                + " aa.DiaChi,Convert(datetime,v.NgayChuyenDau) as NgayVaoVien,Convert(datetime,aa.NgayRaVien) as NgayRaVien ,'' as LydoVaoVien,aa.ChanDoanRaVien,'' as DieuTri,'' as Tinhtranglucvao, '' as Tinhtranglucra,N'Số vào viện: '+ aa.SoHSBA as SoHSBA,aa.CachDT,aa.TaiNan_Truoc,aa.TaiNan_Sau,kq.Nhapvien_Lydo,v.makhoa "
                + " from benhnhan_chitiet aa inner join benhnhan on benhnhan.mabenhnhan = aa.mabenhnhan inner join viewkhoahientai v on v.mavaovien = aa.mavaovien  inner join dmkhoaphong on dmkhoaphong.makhoa = v.makhoa Inner Join NAMDINH_KHAMBENH.dbo.tblKHAMBENH_KQDVKHAM kq on kq.MakhamBenh = aa.MaKhamBenh and kq.HuongGQ = 5"
                + " where aa.MaVaoVien = '{0}'", _MaVaoVien);
            System.Data.SqlClient.SqlDataReader dr = SQLCmd.ExecuteReader();
            if (dr.Read())
            {
                //lblKhoa.Text = dr["TenKhoa"].ToString();
                label33.Text = dr["HoTen"].ToString(); label43.Text = dr["NgaySinh"].ToString(); label45.Text = dr["Thangsinh"].ToString();
                label48.Text = dr["NamSinh"].ToString();
                label12.Text = dr["GT"].ToString();
                label51.Text = dr["NgheNghiep"].ToString(); label61.Text = dr["NoiCongTac"].ToString();
                label63.Text = dr["DiaChi"].ToString();
                label64.Text = string.Format("{0:HH} giờ {0:mm} phút, ngày {0:dd} tháng {0:MM} năm {0:yyyy}", dr["NgayVaoVien"]);
                label67.Text = string.Format("{0:HH} giờ {0:mm} phút, ngày {0:dd} tháng {0:MM} năm {0:yyyy}", dr["NgayRaVien"]);
                
                label17.Text = dr["ChanDoanRaVien"].ToString();
                label23.Text = dr["CachDT"].ToString();
                label56.Text = dr["Sohsba"].ToString();
                label34.Text = dr["TaiNan_Truoc"].ToString();
                label38.Text = dr["TaiNan_Sau"].ToString();label30.Text = dr["Nhapvien_Lydo"].ToString();
                if (dr["MaKhoa"].ToString() == "NV1211")
                {
                    label39.Text = "GIÁM ĐỐC TRUNG TÂM";
                }
            }
            dr.Close();
            SQLCmd.Dispose();
        }
    }
}
