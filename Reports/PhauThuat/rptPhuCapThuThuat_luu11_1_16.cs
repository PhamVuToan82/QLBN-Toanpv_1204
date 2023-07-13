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
    public partial class rptPhuCapThuThuat_luu11_1_16 : DataDynamics.ActiveReports.ActiveReport3
    {
        private object _ThangBC;
        private string _Makhoa;
        private string _Tenkhoa;
        string temp_khoa = "";
        public rptPhuCapThuThuat_luu11_1_16(object ThangBaoCao, string Makhoa, string Tenkhoa)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            _ThangBC = ThangBaoCao;
            _Makhoa = Makhoa;
            _Tenkhoa = Tenkhoa;
            lblThangBC.Text = String.Format("THÁNG {0:MM} NĂM {0:yyyy}", ThangBaoCao);
            lbKhoa.Text = _Tenkhoa.ToUpper();
            
            if (_Makhoa != "")
            {
                temp_khoa = " and B.Makhoa = '"+ _Makhoa +"'";
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
            _ds.ConnectionString = "Data Source='" + GlobalModuls.Global.glbServerName + "';Initial Catalog='" + GlobalModuls.Global.glbNoiTru + "'; User ID=sa; Password=";
            //_ds.SQL = String.Format("SELECT DMPHAUTHUAT.LOAIPHAUTHUAT,DMPHAUTHUAT.KYTHUATCAO,B.VITRI,DMBACSY.MABS,DMBACSY.MAKHOA,Upper(DMBACSY.TENBS) AS TENBS FROM"
            //    + " (BENHNHAN_PHAUTHUAT A INNER JOIN BENHNHAN_PT_KIPMO B ON A.MAVAOVIEN = B.MAVAOVIEN AND A.SOPHIEUCD = "
            //    + " B.SOPHIEUCD AND A.LOAIDICHVU = B.LOAIDICHVU AND A.MAPT = B.MAPT)"
            //    + " INNER JOIN PHIEUDIEUTRI_CHITIET P ON P.SOPHIEU = A.SOPHIEUCD AND P.MADICHVU = A.MaPT And P.LOAIDICHVU = A.LOAIDICHVU AND P.DATHUCHIEN =1"
            //    + " LEFT JOIN DMPHAUTHUAT ON DMPHAUTHUAT.MADICHVU = A.MAPT AND DMPHAUTHUAT.LOAIDICHVU = A.LOAIDICHVU"
            //    + " INNER JOIN DMBACSY ON DMBACSY.MABS = B.MABS AND DMBACSY.MAKHOA = B.MAKHOA"
            //    + "  WHERE DATEDIFF(MM,A.THOIGIANBD,'{0:MM/dd/yyyy}') = 0 and isnull(DMPHAUTHUAT.LOAIPHAUTHUAT,'') <> '' ORDER BY DMBACSY.TENBS", _ThangBC);
            _ds.SQL = String.Format("Select * from ("
            + "  SELECT DMPHAUTHUAT.LOAIPHAUTHUAT,DMPHAUTHUAT.KYTHUATCAO,B.VITRI,DMBACSY.MABS,DMBACSY.MAKHOA,DMKHOAPHONG.Tentat as TenKhoa, Upper(DMBACSY.TENBS) AS TENBS "
            + "  FROM (Thongtin_Thuthuat A INNER JOIN BENHNHAN_PT_KIPMO B ON A.MAVAOVIEN = B.MAVAOVIEN AND A.MaPHIEUCD = B.SOPHIEUCD "
            + "  AND A.Madichvu = B.MAPT)"
            + "  INNER JOIN PHIEUDIEUTRI_CHITIET P ON P.SOPHIEU = A.MaPHIEUCD AND P.MADICHVU = A.Madichvu AND P.DATHUCHIEN =1"
            + "  LEFT JOIN DMPHAUTHUAT ON DMPHAUTHUAT.MADICHVU = A.Madichvu "
            + "  INNER JOIN DMBACSY ON DMBACSY.MABS = B.MABS AND DMBACSY.MAKHOA = B.MAKHOA"
            + "  INNER JOIN DMKHOAPHONG ON DMBACSY.MAKHOA = DMKHOAPHONG.MAKHOA"
            + "  WHERE DATEDIFF(MM,A.Ngaymo,'{0:MM/dd/yyyy}') = 0 "
            + "  and isnull(DMPHAUTHUAT.LOAIPHAUTHUAT,'') <> '' {1} "
            + "  Union all "
            + "  SELECT DMPHAUTHUAT.LOAIPHAUTHUAT,DMPHAUTHUAT.KYTHUATCAO,B.VITRI,DMBACSY.MABS,DMBACSY.MAKHOA,DMKHOAPHONG.Tentat as TenKhoa,"
            + "  Upper(DMBACSY.TENBS) AS TENBS  FROM "
            + "  (NAMDINH_KHAMBENH.dbo.Thongtin_Thuthuat A INNER JOIN BENHNHAN_PT_KIPMO B ON A.Makhambenh = B.MAVAOVIEN AND A.MaPHIEUCD = B.SOPHIEUCD   AND A.Madichvu = B.MAPT)  "
            + "  INNER JOIN NAMDINH_KHAMBENH.dbo.tblKhambenh_Dichvu P ON P.MaPHIEUCD = A.MaPHIEUCD AND P.MADICHVU = A.Madichvu AND P.DATHUCHIEN =1  "
            + "  LEFT JOIN DMPHAUTHUAT ON DMPHAUTHUAT.MADICHVU = A.Madichvu  "
            + "  INNER JOIN DMBACSY ON DMBACSY.MABS = B.MABS AND DMBACSY.MAKHOA = B.MAKHOA  "
            + "  INNER JOIN DMKHOAPHONG ON DMBACSY.MAKHOA = DMKHOAPHONG.MAKHOA "
            + "  WHERE DATEDIFF(MM,A.Ngaymo,'{0:MM/dd/yyyy}') = 0 "
            + "  and isnull(DMPHAUTHUAT.LOAIPHAUTHUAT,'') <> '' {1} "
            + "  ) X"
            + "   ORDER BY TENKHOA, MaBS ", _ThangBC, temp_khoa);
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
                Fields["C_DB"].Value = (Fields["VITRI"].Value.ToString() == "1" || Fields["VITRI"].Value.ToString() == "3") && Fields["LOAIPHAUTHUAT"].Value.ToString() == "4" ? 1 : 0;
                Fields["C_LOAI1"].Value = (Fields["VITRI"].Value.ToString() == "1" || Fields["VITRI"].Value.ToString() == "3") && Fields["LOAIPHAUTHUAT"].Value.ToString().Substring(0, 1) == "1" ? 1 : 0;
                Fields["C_LOAI2"].Value = (Fields["VITRI"].Value.ToString() == "1" || Fields["VITRI"].Value.ToString() == "3") && Fields["LOAIPHAUTHUAT"].Value.ToString().Substring(0, 1) == "2" ? 1 : 0;
                Fields["C_LOAI3"].Value = (Fields["VITRI"].Value.ToString() == "1" || Fields["VITRI"].Value.ToString() == "3") && Fields["LOAIPHAUTHUAT"].Value.ToString().Substring(0, 1) == "3" ? 1 : 0;

                Fields["P_DB"].Value = (Fields["VITRI"].Value.ToString() == "2" || Fields["VITRI"].Value.ToString() == "4") && Fields["LOAIPHAUTHUAT"].Value.ToString() == "4" ? 1 : 0;
                Fields["P_LOAI1"].Value = (Fields["VITRI"].Value.ToString() == "2" || Fields["VITRI"].Value.ToString() == "4") && Fields["LOAIPHAUTHUAT"].Value.ToString().Substring(0, 1) == "1" ? 1 : 0;
                Fields["P_LOAI2"].Value = (Fields["VITRI"].Value.ToString() == "2" || Fields["VITRI"].Value.ToString() == "4") && Fields["LOAIPHAUTHUAT"].Value.ToString().Substring(0, 1) == "2" ? 1 : 0;
                Fields["P_LOAI3"].Value = (Fields["VITRI"].Value.ToString() == "2" || Fields["VITRI"].Value.ToString() == "4") && Fields["LOAIPHAUTHUAT"].Value.ToString().Substring(0, 1) == "3" ? 1 : 0;

                Fields["GV_DB"].Value = (Fields["VITRI"].Value.ToString() == "5" || Fields["VITRI"].Value.ToString() == "6" || Fields["VITRI"].Value.ToString() == "7") && Fields["LOAIPHAUTHUAT"].Value.ToString() == "4" ? 1 : 0;
                Fields["GV_LOAI1"].Value = (Fields["VITRI"].Value.ToString() == "5" || Fields["VITRI"].Value.ToString() == "6" || Fields["VITRI"].Value.ToString() == "7") && Fields["LOAIPHAUTHUAT"].Value.ToString().Substring(0, 1) == "1" ? 1 : 0;
                Fields["GV_LOAI2"].Value = (Fields["VITRI"].Value.ToString() == "5" || Fields["VITRI"].Value.ToString() == "6" || Fields["VITRI"].Value.ToString() == "7") && Fields["LOAIPHAUTHUAT"].Value.ToString().Substring(0, 1) == "2" ? 1 : 0;
                Fields["GV_LOAI3"].Value = (Fields["VITRI"].Value.ToString() == "5" || Fields["VITRI"].Value.ToString() == "6" || Fields["VITRI"].Value.ToString() == "7") && Fields["LOAIPHAUTHUAT"].Value.ToString().Substring(0, 1) == "3" ? 1 : 0;
            }
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
                txt.Height = detail.Height;
        }

        private void groupHeader1_Format(object sender, EventArgs e)
        {
            STT.Text = string.Format("{0}", int.Parse(STT.Text) + 1);
        }
    }
}
