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
    public partial class repPhieuChiDinh : DataDynamics.ActiveReports.ActiveReport3
    {

        private String _SoPhieu;
        private String _MaVaoVien;
        private int STT = 0;
        public repPhieuChiDinh(string MaVaoVien, String HoTen, int Tuoi, String GioiTinh, String ChanDoan, String NoiChiDinh)
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
            //TextBox1.Text = TenDichVu;
            //TextBox6.Text = TenThuoc;
            //TextBox7.Text = NgayChiDinh;
            _MaVaoVien = MaVaoVien;

        }


        private void repPhieuChiDinh_DataInitialize(object sender, EventArgs e)
        {
            DataDynamics.ActiveReports.DataSources.SqlDBDataSource _ds = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            _ds.ConnectionString = GlobalModuls.Global.glbConnectionString;
            _ds.SQL = string.Format("Select CONVERT(DATE,NGAYCHIDINH) as NGAYCHIDINH,thuoc+' x '+ sl1 + ' '+ DVT_Thuoc + ' '+ GhiChu as TenThuoc,"
            + "Case when Dichvu is null then DienBienBenh else Dichvu +' x '+  sl2  + ' '+ DVT_dichvu end AS Tendichvu,LoaiDichvu "
            + "  from ( select B.SOHSBA,A.HoTen,A.NamSinh,B.Buong,B.Giuong,KHOA.ChanDoan,C.NGAYCHIDINH,C.DienBienBenh,"
            + "     (case when e.LoaiDichvu = 'D01' then TenDichVu end ) as Thuoc,convert(varchar(12),D.SoLuong) as sl1,e.DVT as DVT_Thuoc,d.ghichu,"
            + "     case when e.LoaiDichvu like N'%C%' then TenDichVu end as Dichvu,convert(varchar(12),D.SoLuong) as  sl2,e.DVT as DVT_dichvu,e.LoaiDichvu"
            + "  from NAMDINH_QLBN.DBO.BENHNHAN A INNER JOIN NAMDINH_QLBN.DBO.BENHNHAN_CHITIET B ON A.MaBenhNhan= B.MaBenhNhan "
            + "  INNER JOIN NAMDINH_QLBN.DBO.ViewKHOAHIENTAI KHOA ON KHOA.MaVaoVien = B.MAVAOVIEN  "
            + "  INNER JOIN NAMDINH_QLBN.DBO.BENHNHAN_PHIEUDIEUTRI C ON C.MaVaoVien = B.MAVAOVIEN AND C.MAKHOA = KHOA.MaKhoa "
            + "  INNER JOIN NAMDINH_QLBN.DBO.PHIEUDIEUTRI_CHITIET D ON D.SOPHIEU = C.SOPHIEU  "
            + "  INNER JOIN NAMDINH_QLBN.DBO.DMLENCHIPHI_BYKHOID E ON E.MaDichvu = d.MaDichVu and (e.LoaiDichvu in ('D01') or (e.LoaiDichvu like N'C%')) "
            + " where b.MaVaoVien = {0}) x ", _MaVaoVien)
            + " Order by NGAYCHIDINH";
            this.DataSource = _ds;

            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            SQLCmd.CommandText = string.Format("Select CONVERT(DATE,NGAYCHIDINH) as NGAYCHIDINH,thuoc+' x '+ sl1 + ' '+ DVT_Thuoc + ' '+ GhiChu as TenThuoc,"
            + "Case when Dichvu is null then DienBienBenh else Dichvu +' x '+  sl2  + ' '+ DVT_dichvu end AS Tendichvu,LoaiDichvu "
            + "  from ( select B.SOHSBA,A.HoTen,A.NamSinh,B.Buong,B.Giuong,KHOA.ChanDoan,C.NGAYCHIDINH,C.DienBienBenh,"
            + "     (case when e.LoaiDichvu = 'D01' then TenDichVu end ) as Thuoc,convert(varchar(12),D.SoLuong) as sl1,e.DVT as DVT_Thuoc,d.ghichu,"
            + "     case when e.LoaiDichvu like N'%C%' then TenDichVu end as Dichvu,convert(varchar(12),D.SoLuong) as  sl2,e.DVT as DVT_dichvu,e.LoaiDichvu"
            + "  from NAMDINH_QLBN.DBO.BENHNHAN A INNER JOIN NAMDINH_QLBN.DBO.BENHNHAN_CHITIET B ON A.MaBenhNhan= B.MaBenhNhan "
            + "  INNER JOIN NAMDINH_QLBN.DBO.ViewKHOAHIENTAI KHOA ON KHOA.MaVaoVien = B.MAVAOVIEN  "
            + "  INNER JOIN NAMDINH_QLBN.DBO.BENHNHAN_PHIEUDIEUTRI C ON C.MaVaoVien = B.MAVAOVIEN AND C.MAKHOA = KHOA.MaKhoa "
            + "  INNER JOIN NAMDINH_QLBN.DBO.PHIEUDIEUTRI_CHITIET D ON D.SOPHIEU = C.SOPHIEU  "
            + "  INNER JOIN NAMDINH_QLBN.DBO.DMLENCHIPHI_BYKHOID E ON E.MaDichvu = d.MaDichVu and (e.LoaiDichvu in ('D01') or (e.LoaiDichvu like N'C%')) "
            + " where b.MaVaoVien = {0}) x ", _MaVaoVien)
            + " Order by NGAYCHIDINH";
            dr = SQLCmd.ExecuteReader();
            string TenThuoc = "";
            string Tendichvu = "";
            //string NgayChidinh = "";
            bool DaCo = false;
            while (dr.Read())
            {
                foreach (DataDynamics.ActiveReports.TextBox lb in groupHeader1.Controls)
                {
                    if(lb.Value == dr["NgayChiDinh"].ToString())
                    {
                            TextBox6.Text += dr["Tendichvu"].ToString();
                        
                    }
                }
                //foreach (DataDynamics.ActiveReports.TextBox lb in detail.Controls)
                //{
                //    Fields[dr["Tendichvu"].ToString()].Value += dr["Tendichvu"].ToString();
                //}
                //Tendichvu = dr["Tendichvu"].ToString();
                //TextBox1.Text = Tendichvu + dr["Tendichvu"].ToString();

                    //TenThuoc = dr["TenThuoc"].ToString();
                    //TextBox6.Text = TenThuoc + dr["TenThuoc"].ToString(); ;
                    //NgayChidinh = dr["NgayChiDinh"].ToString();
                    //TextBox7.Text = NgayChidinh + dr["NgayChiDinh"].ToString();

                    //foreach (DataDynamics.ActiveReports.TextBox lb in groupHeader1.Controls)
                    //{
                    //    if (lb.Text == TextBox7.Text && dr["LoaiDichVu"].ToString() == "D01")
                    //    {

                    //    }
                    //    else

                    //}
            }
            dr.Close();
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
            //STT = 0;
        }

        private void detail_Format(object sender, EventArgs e)
        {
            //STT++;
            //lblSTT.Text = STT.ToString();
        }

        private void repPhieuChiDinh_ReportStart(object sender, EventArgs e)
        {
            this.PageSettings.Margins.Top = (float)0.7;
            this.PageSettings.Margins.Left = (float)0.5;
            this.PageSettings.Margins.Right = (float)0.4;
            this.PageSettings.Margins.Bottom = (float)0.5;
        }
    }
}
