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
    /// Summary description for rptGiayRaVien.
    /// </summary>
    public partial class rptGiayRaVien : DataDynamics.ActiveReports.ActiveReport3
    {
        private string MaVaoVien;
        public rptGiayRaVien(string _MaVaoVien)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            MaVaoVien = _MaVaoVien;
        }

        private void rptGiayRaVien_ReportStart(object sender, EventArgs e)
        {
            this.Document.Name = "Giấy ra viện";
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A5;
            this.PageSettings.Orientation = PageOrientation.Landscape;

            this.PageSettings.Margins.Left = (float)0.3;
            this.PageSettings.Margins.Right = (float)0.00;
            this.PageSettings.Margins.Top = (float)0.2;
            this.PageSettings.Margins.Bottom = (float)0.10;
            
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);            
            try
            {
                SQLCmd.CommandText = "SELECT a.TenBenhNhan, a.NamSinh,b.*,isnull(NGHE.TenNgheNghiep,b.NgheNghiep) as TenNgheNghiep,c.TenDT,ee.NgayChuyen as NgayChuyen1,CASE GioiTinh WHEN 1 THEN N'Nam' ELSE N'Nữ' END As GT, CASE when CONVERT(CHAR(2),a.NgaySinh) != '0' THEN CONVERT(CHAR(2),a.NgaySinh) + ' / ' ELSE '/ ' END AS NgaySinh ,CASE WHEN CONVERT(CHAR(2),a.ThangSinh) != '0' THEN  CONVERT(CHAR(2),a.ThangSinh)  + ' / ' ELSE ' / ' end as ThangSinh, CONVERT(CHAR(3),(YEAR(NgayRaVien) - a.NamSinh)) + ' ) ' AS Tuoi,b.CachDT,f.TenKhoa  ,ThongTinThe.GTTu GtriTu, ThongTinthe.GTden GTriDen, ThongTinThe.TheBHYT as SoThe,v.MaNoiCap,v.MaDoiTuongBHXH,rv.MAICD_BC,rv.MAICD_BP,rv.MAICD_BP_1,b.SoLuuTru"
                + " FROM(((namdinh_khambenh.dbo.tblbenhnhan a INNER JOIN BENHNHAN_CHITIET b ON a.MaBenhNhan = b.MaBenhNhan INNER JOIN namdinh_khambenh.DBO.TBLKHAMBENH BN ON BN.MAKHAMBENH = b.MAKHAMBENH )  LEFT JOIN DMDANTOC c ON BN.Ma_DanToc = c.MaDT LEFT JOIN NAMDINH_SYSDB.DBO.DMNGHENGHIEP NGHE ON NGHE.MaNghenghiep = B.NgheNghiep)"
                + " INNER JOIN BenhNhan_Khoa ee ON b.MaVaoVien = ee.MaVaoVien and ee.LanChuyenKhoa = 0) "
                + " inner join ViewKHOAHIENTAI rv on rv.MaVaoVien = ee.MaVaoVien"
                + " INNER JOIN DMKHOAPHONG f ON rv.MaKhoa = f.MaKhoa"
                + " inner join viewdoituonghientai v on v.mavaovien = b.mavaovien"
                + " inner join(SELECT T1.MaVaoVien , STUFF((SELECT  ',' + t2.maDoiTuongBHXH + T2.SoThe  FROM BENHNHAN_DOITUONG T2 WHERE   T1.MaVaoVien = T2.MaVaoVien FOR XML PATH('')), 1, 1, '') AS TheBHYT,"
                + " STUFF((SELECT  ',' + convert(varchar, T3.GtriTu, 103) FROM    BENHNHAN_DOITUONG T3 WHERE   T1.MaVaoVien = T3.MaVaoVien FOR XML PATH('')), 1, 1, '') AS GTTu,"
                + " STUFF((SELECT  ',' + convert(varchar, T4.GtriDen, 103) FROM    BENHNHAN_DOITUONG T4 WHERE   T1.MaVaoVien = T4.MaVaoVien FOR XML PATH('')), 1, 1, '') AS GTden"
                + " FROM NAMDINH_QLBN.dbo.BENHNHAN_DOITUONG T1"
                + " GROUP BY T1.MaVaoVien) ThongTinThe on ThongTinThe.MaVaoVien = b.MaVaoVien"
                + " WHERE b.MaVaoVien = " + MaVaoVien + " order by ee.ngaychuyen desc";
                System.Data.SqlClient.SqlDataReader dr = SQLCmd.ExecuteReader();
                if (dr.Read())
                {
                    lblKhoa.Text = dr["TenKhoa"].ToString();
                    lblHoTen.Text = dr["TenBenhNhan"].ToString();
                    lblTuoi.Text ="( Tuổi: " +  dr["Tuoi"].ToString();
                    lblGioiTinh.Text = dr["GT"].ToString();
                    lblDanToc.Text = dr["TenDT"].ToString();
                    lblNgheNghiep.Text = dr["TenNgheNghiep"].ToString();
                    lblDiaChi.Text = dr["DiaChi"].ToString();
                    lblBHYT_GTri_Tu.Text = string.Format("{0:dd/MM/yyyy}", dr["GtriTu"]);
                    lblBHYT_GTri_Den.Text = string.Format("{0:dd/MM/yyyy}", dr["GTriDen"]);
                    lblSoTheBHYT.Text = dr["SoThe"].ToString();
                    lblNgayVaoVien.Text = string.Format("{0:HH} giờ {0:mm} phút, ngày {0:dd} tháng {0:MM} năm {0:yyyy}", dr["NgayChuyen1"]);
                    lblNgayRaVien.Text = string.Format("{0:HH} giờ {0:mm} phút, ngày {0:dd} tháng {0:MM} năm {0:yyyy}", dr["NgayRaVien"]);
                    lblNgayKyRaVien.Text =lblNgay_GiamDoc.Text = string.Format("Ngày {0:dd} tháng {0:MM} năm {0:yyyy}", dr["NgayRaVien"]);
                    lblChanDoan.Text = String.Format("{0}               Mã ICD: {1}, {2}, {3}", dr["ChanDoanRaVien"], dr["MAICD_BC"], dr["MAICD_BP"], dr["MAICD_BP_1"]);
                    lblCachDT.Value = "Phương pháp điều trị: "+ dr["CachDT"].ToString();
                    lblLoiDan.Text ="Ghi chú: "+ dr["LoiDan_raVien"].ToString();
                    lblSoHSBA.Text = dr["SoHSBA"].ToString();
                    if(dr["TenKhoa"].ToString() == "Trung tâm Ung bướu") { label24.Text = "Giám đốc trung tâm"; }
                    label20.Text = dr["SoLuuTru"].ToString();
                    label27.Text = dr["NgaySinh"].ToString();
                    label28.Text = dr["ThangSinh"].ToString();
                    label29.Text = dr["NamSinh"].ToString();

                }
                dr.Close();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông báo");
            }
            finally
            {
                SQLCmd.Dispose();
            }
        }

        private void detail_Format(object sender, EventArgs e)
        {

        }
    }
}
