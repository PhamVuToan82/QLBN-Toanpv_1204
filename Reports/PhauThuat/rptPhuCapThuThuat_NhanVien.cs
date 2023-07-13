using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace NamDinh_QLBN.Reports.PhauThuat
{
    /// <summary>
    /// Summary description for rptChiNganSach.
    /// </summary>
    public partial class rptPhuCapThuThuat_NhanVien : DataDynamics.ActiveReports.ActiveReport3
    {
        private object _ThangBC;
        private object _TuNgay;
        private object _DenNgay;
        private string _Makhoa;
        private string _Tenkhoa;
        string temp_khoa = "";
        public rptPhuCapThuThuat_NhanVien(object ThangBaoCao, string Makhoa, string Tenkhoa, object Tu,object Den )
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            _ThangBC = ThangBaoCao;
            _TuNgay = Tu;
            _DenNgay = Den;
            _Makhoa = Makhoa;
            _Tenkhoa = Tenkhoa;
            //lblThangBC.Text = String.Format("THÁNG {0:MM} NĂM {0:yyyy}", ThangBaoCao);
            lblThangBC.Text = String.Format("Từ {0:dd/MM/yyyy} đến {1:dd/MM/yyyy}", Tu, Den);
            lbKhoa.Text = _Tenkhoa.ToUpper();
            
            if (_Makhoa != "")
            {
                temp_khoa = " and DMKHOAPHONG.Makhoa = '" + _Makhoa +"'";
            }
        }
        private void rptPhuCapThuThuat_ReportStart(object sender, EventArgs e)
        {
            this.PageSettings.Orientation = PageOrientation.Landscape;
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.PageSettings.Margins.Left = (float)0.4;
            this.PageSettings.Margins.Right = (float)0.0;
            this.PageSettings.Margins.Top = (float)0.7;
            this.PageSettings.Margins.Bottom = (float)0.7;                        
        }

        private void rptPhuCapThuThuat_DataInitialize(object sender, EventArgs e)
        {
            DataDynamics.ActiveReports.DataSources.SqlDBDataSource _ds = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            //_ds.ConnectionString = GlobalModuls.Global.glbConnectionString;
            //_ds.SQL = String.Format("Select * from ("
            //+ "  SELECT DMPHAUTHUAT.LOAIPHAUTHUAT,DMPHAUTHUAT.KYTHUATCAO,B.VITRI,DMBACSY.MABS,DMBACSY.MAKHOA,DMKHOAPHONG.Tentat as TenKhoa, Upper(DMBACSY.TENBS) AS TENBS "
            //+ "  FROM (Thongtin_Thuthuat A INNER JOIN BENHNHAN_PT_KIPMO B ON A.MAVAOVIEN = B.MAVAOVIEN AND A.MaPHIEUCD = B.SOPHIEUCD "
            //+ "  AND A.Madichvu = B.MAPT)"
            //+ "  INNER JOIN PHIEUDIEUTRI_CHITIET P ON P.SOPHIEU = A.MaPHIEUCD AND P.MADICHVU = A.Madichvu " // AND P.DATHUCHIEN =1
            //+ "  LEFT JOIN DMPHAUTHUAT ON DMPHAUTHUAT.MADICHVU = A.Madichvu "
            //+ "  INNER JOIN DMBACSY ON DMBACSY.MABS = B.MABS AND DMBACSY.MAKHOA = B.MAKHOA"
            //+ "  INNER JOIN DMKHOAPHONG ON DMBACSY.MAKHOA = DMKHOAPHONG.MAKHOA"
            //+ "  WHERE DATEDIFF(MM,A.Ngaymo,'{0:MM/dd/yyyy}') = 0 "
            //+ "  and isnull(DMPHAUTHUAT.LOAIPHAUTHUAT,'') <> '' {1} "
            //+ "  Union all "
            //+ "  SELECT DMPHAUTHUAT.LOAIPHAUTHUAT,DMPHAUTHUAT.KYTHUATCAO,B.VITRI,DMBACSY.MABS,DMBACSY.MAKHOA,DMKHOAPHONG.Tentat as TenKhoa,"
            //+ "  Upper(DMBACSY.TENBS) AS TENBS  FROM "
            //+ "  (NAMDINH_KHAMBENH.dbo.Thongtin_Thuthuat A INNER JOIN BENHNHAN_PT_KIPMO B ON A.Makhambenh = B.MAVAOVIEN AND A.MaPHIEUCD = B.SOPHIEUCD   AND A.Madichvu = B.MAPT)  "
            //+ "  INNER JOIN NAMDINH_KHAMBENH.dbo.tblKhambenh_Dichvu P ON P.MaPHIEUCD = A.MaPHIEUCD AND P.MADICHVU = A.Madichvu AND P.DATHUCHIEN =1  "
            //+ "  LEFT JOIN DMPHAUTHUAT ON DMPHAUTHUAT.MADICHVU = A.Madichvu  "
            //+ "  INNER JOIN DMBACSY ON DMBACSY.MABS = B.MABS AND DMBACSY.MAKHOA = B.MAKHOA  "
            //+ "  INNER JOIN DMKHOAPHONG ON DMBACSY.MAKHOA = DMKHOAPHONG.MAKHOA "
            //+ "  WHERE DATEDIFF(MM,A.Ngaymo,'{0:MM/dd/yyyy}') = 0 "
            //+ "  and isnull(DMPHAUTHUAT.LOAIPHAUTHUAT,'') <> '' {1} "
            //+ "  ) X"
            //+ "   ORDER BY TENKHOA, MaBS ", _ThangBC, temp_khoa);

            _ds.ConnectionString = GlobalModuls.Global.glbConnectionString;
            _ds.SQL = String.Format("Select * from ("
            + "  SELECT DMPHAUTHUAT.LOAIPHAUTHUAT,DMPHAUTHUAT.KYTHUATCAO,B.VITRI,B.Ma_BHXH as MABS,DMKHOAPHONG.MAKHOA,DMKHOAPHONG.Tentat as TenKhoa, Upper(DMBACSY.TENBS) AS TENBS "
            + "  FROM (Thongtin_Thuthuat A INNER JOIN BENHNHAN_PT_KIPMO B ON A.MAVAOVIEN = B.MAVAOVIEN AND A.MaPHIEUCD = B.SOPHIEUCD "
            + "  AND A.Madichvu = B.MAPT)"
            + "  INNER JOIN PHIEUDIEUTRI_CHITIET P ON P.SOPHIEU = A.MaPHIEUCD AND P.MADICHVU = A.Madichvu " // AND P.DATHUCHIEN =1
            + "  INNER JOIN DMPHAUTHUAT ON DMPHAUTHUAT.MADICHVU = A.Madichvu "
            + "  INNER JOIN DMBACSY ON DMBACSY.MA_BHXH = B.Ma_BHXH and DMBACSY.Is_khoaphucap = 1"
            + "  INNER JOIN DMKHOAPHONG ON DMBACSY.MAKHOA = DMKHOAPHONG.MAKHOA"
            + "  WHERE  A.Ngaymo >= '{2:MM/dd/yyyy 00:00:01}' and  A.Ngaymo <= '{3:MM/dd/yyyy 23:59:59}'  and  DMBACSY.MA_BHXH != ''"
            + "  and DMPHAUTHUAT.LoaiPhauThuat in (5, 51, 52, 53) {1} "
            + "  Union all "
            + "  SELECT DMPHAUTHUAT.LOAIPHAUTHUAT,DMPHAUTHUAT.KYTHUATCAO,B.VITRI,B.Ma_BHXH as MABS,DMKHOAPHONG.MAKHOA,DMKHOAPHONG.Tentat as TenKhoa,"
            + "  Upper(DMBACSY.TENBS) AS TENBS  FROM "
            + "  (NAMDINH_KHAMBENH.dbo.Thongtin_Thuthuat A INNER JOIN BENHNHAN_PT_KIPMO B ON A.Makhambenh = B.MAVAOVIEN AND A.MaPHIEUCD = B.SOPHIEUCD   AND A.Madichvu = B.MAPT)  "
            + "  INNER JOIN NAMDINH_KHAMBENH.dbo.tblKhambenh_Dichvu P ON P.MaPHIEUCD = A.MaPHIEUCD AND P.MADICHVU = A.Madichvu AND P.DATHUCHIEN =1  "
            + "  INNER JOIN DMPHAUTHUAT ON DMPHAUTHUAT.MADICHVU = A.Madichvu  "
            + "  INNER JOIN DMBACSY ON DMBACSY.MA_BHXH = B.Ma_BHXH  and DMBACSY.Is_khoaphucap  = 1"
            + "  INNER JOIN DMKHOAPHONG ON DMBACSY.MAKHOA = DMKHOAPHONG.MAKHOA "
            + "  WHERE  A.Ngaymo >= '{2:MM/dd/yyyy 00:00:01}' and  A.Ngaymo <= '{3:MM/dd/yyyy 23:59:59}'  and  DMBACSY.MA_BHXH != '' "
            + "  and DMPHAUTHUAT.LoaiPhauThuat in (5, 51, 52, 53) {1} "
                + "  Union all"
                + "  SELECT DMPHAUTHUAT.LOAIPHAUTHUAT, DMPHAUTHUAT.KYTHUATCAO, B.VITRI, B.Ma_BHXH as MABS, DMKHOAPHONG.MAKHOA, DMKHOAPHONG.Tentat as TenKhoa, Upper(DMBACSY.TENBS) AS TENBS"
                + "  FROM(BENHNHAN_PHAUTHUAT A INNER JOIN BENHNHAN_PT_KIPMO B ON A.MAVAOVIEN = B.MAVAOVIEN AND A.SoPhieuCD = B.SOPHIEUCD   AND A.MaPT = B.MAPT)"
                + "  INNER JOIN PHIEUDIEUTRI_CHITIET P ON P.SOPHIEU = A.SoPhieuCD AND P.MADICHVU = A.MaPT"
                + "  INNER JOIN DMPHAUTHUAT ON DMPHAUTHUAT.MADICHVU = A.MaPT   INNER JOIN DMBACSY ON DMBACSY.MA_BHXH = B.Ma_BHXH"
                + "  INNER JOIN DMKHOAPHONG ON DMBACSY.MAKHOA = DMKHOAPHONG.MAKHOA  and DMBACSY.Is_khoaphucap  = 1"
                + "  WHERE  A.ThoiGianBD >=  '{2:MM/dd/yyyy 00:00:01}' and  A.ThoiGianBD <= '{3:MM/dd/yyyy 23:59:59}' and  DMBACSY.MA_BHXH != ''"
                + "  and DMPHAUTHUAT.LoaiPhauThuat in (5, 51, 52, 53) {1}"
               + "  ) X"
            + "   ORDER BY TENKHOA, MaBS ", _ThangBC, temp_khoa, _TuNgay, _DenNgay);

            this.DataSource = _ds;
            foreach (DataDynamics.ActiveReports.TextBox txt in groupHeader1.Controls)
                if (!Fields.Contains(Fields[txt.DataField]))
                    Fields.Add(txt.DataField);
        }

        private void rptPhuCapThuThuat_FetchData(object sender, FetchEventArgs eArgs)
        {
            if (eArgs.EOF)
            {
            }
            else
            {
                Fields["C_DB"].Value = (Fields["VITRI"].Value.ToString() == "1" || Fields["VITRI"].Value.ToString() == "3") && Fields["LOAIPHAUTHUAT"].Value.ToString() == "5" ? 1 : 0;
                Fields["C_LOAI1"].Value = (Fields["VITRI"].Value.ToString() == "1" || Fields["VITRI"].Value.ToString() == "3") && Fields["LOAIPHAUTHUAT"].Value.ToString() == "51" ? 1 : 0;
                Fields["C_LOAI2"].Value = (Fields["VITRI"].Value.ToString() == "1" || Fields["VITRI"].Value.ToString() == "3") && Fields["LOAIPHAUTHUAT"].Value.ToString() == "52" ? 1 : 0;
                Fields["C_LOAI3"].Value = (Fields["VITRI"].Value.ToString() == "1" || Fields["VITRI"].Value.ToString() == "3") && Fields["LOAIPHAUTHUAT"].Value.ToString() == "53" ? 1 : 0;

                Fields["P_DB"].Value = (Fields["VITRI"].Value.ToString() == "2" || Fields["VITRI"].Value.ToString() == "4") && Fields["LOAIPHAUTHUAT"].Value.ToString() == "5" ? 1 : 0;
                Fields["P_LOAI1"].Value = (Fields["VITRI"].Value.ToString() == "2" || Fields["VITRI"].Value.ToString() == "4") && Fields["LOAIPHAUTHUAT"].Value.ToString() == "51" ? 1 : 0;
                Fields["P_LOAI2"].Value = (Fields["VITRI"].Value.ToString() == "2" || Fields["VITRI"].Value.ToString() == "4") && Fields["LOAIPHAUTHUAT"].Value.ToString() == "52" ? 1 : 0;
                Fields["P_LOAI3"].Value = (Fields["VITRI"].Value.ToString() == "2" || Fields["VITRI"].Value.ToString() == "4") && Fields["LOAIPHAUTHUAT"].Value.ToString() == "53" ? 1 : 0;

                Fields["GV_DB"].Value = (Fields["VITRI"].Value.ToString() == "5" || Fields["VITRI"].Value.ToString() == "6" || Fields["VITRI"].Value.ToString() == "7") && Fields["LOAIPHAUTHUAT"].Value.ToString() == "5" ? 1 : 0;
                Fields["GV_LOAI1"].Value = (Fields["VITRI"].Value.ToString() == "5" || Fields["VITRI"].Value.ToString() == "6" || Fields["VITRI"].Value.ToString() == "7") && Fields["LOAIPHAUTHUAT"].Value.ToString() == "51" ? 1 : 0;
                Fields["GV_LOAI2"].Value = (Fields["VITRI"].Value.ToString() == "5" || Fields["VITRI"].Value.ToString() == "6" || Fields["VITRI"].Value.ToString() == "7") && Fields["LOAIPHAUTHUAT"].Value.ToString() == "52" ? 1 : 0;
                Fields["GV_LOAI3"].Value = (Fields["VITRI"].Value.ToString() == "5" || Fields["VITRI"].Value.ToString() == "6" || Fields["VITRI"].Value.ToString() == "7") && Fields["LOAIPHAUTHUAT"].Value.ToString() == "53" ? 1 : 0;
            }
        }

        private void groupHeader1_BeforePrint(object sender, EventArgs e)
        {
            foreach (TextBox txt in groupHeader1.Controls)
                txt.Height = groupHeader1.Height;
        }

        private void groupHeader1_Format(object sender, EventArgs e)
        {
            STT.Text = string.Format("{0}", int.Parse(STT.Text) + 1);
        }
    }
}
