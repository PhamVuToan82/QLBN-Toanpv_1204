using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using GlobalModuls;
namespace NamDinh_QLBN.Reports.PhauThuat
{
    /// <summary>
    /// Summary description for rptChiNganSach.
    /// </summary>
    public partial class rptCaPhauThuat : DataDynamics.ActiveReports.ActiveReport3
    {
        private object _ThangBC;
        public rptCaPhauThuat(object ThangBC)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            _ThangBC = ThangBC;
            lblThang.Text = String.Format("Tháng {0:MM} năm {0:yyyy}", ThangBC);
        }
        private void rptPhauThuat_ReportStart(object sender, EventArgs e)
        {
            this.PageSettings.Orientation = PageOrientation.Landscape;
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.PageSettings.Margins.Left = (float)0.4;
            this.PageSettings.Margins.Right = (float)0.0;
            this.PageSettings.Margins.Top = (float)0.5;
            this.PageSettings.Margins.Bottom = (float)0.7;                        
        }

        private void detail_Format(object sender, EventArgs e)
        {
            if (textBox7.Text == "4") textBox7.Text = "ĐB";
            textBox3.Text = string.Format("{0}",int.Parse(textBox3.Text) + 1);
        }

        private void detail_BeforePrint(object sender, EventArgs e)
        {
            foreach (TextBox txt in detail.Controls)
                txt.Height = detail.Height;
        }

        private void rptCaPhauThuat_DataInitialize(object sender, EventArgs e)
        {
            DataDynamics.ActiveReports.DataSources.SqlDBDataSource _ds = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            _ds.ConnectionString = GlobalModuls.Global.glbConnectionString;
            _ds.SQL = String.Format("SELECT a.SoBLVP,a.MaVaoVien,a.SoPhieuCD,a.LoaiDichVu,a.MaPT,Hoten,ThoiGianBD,TenTat as tentat1,ChanDoan_SauPT as ChanDoan_TruocPT,PhuongPhapPT_Text,Left(LoaiPhauThuat,1) As LoaiPT,b.SoHSBA,"
                + " CASE WHEN G.DOITUONG = 1 THEN G.MANOICAP ELSE '' END AS SOTHE, case P.Dathanhtoan when 1 then '' else 'X' end as Dathanhtoan "
                + " FROM ((((BENHNHAN_PHAUTHUAT a INNER JOIN BENHNHAN_CHITIET b ON a.MaVaoVien=b.MaVaoVien)"
                + " INNER JOIN BENHNHAN c ON b.MaBenhNhan=c.MaBenhNhan)"
                + " INNER JOIN BENHNHAN_PHIEUDIEUTRI d ON a.SoPhieuCD=d.SoPhieu)"
                + " INNER JOIN PHIEUDIEUTRI_CHITIET P ON P.SOPHIEU = D.SOPHIEU AND P.MADICHVU = A.MaPT And P.LOAIDICHVU = A.LOAIDICHVU AND P.DATHUCHIEN =1"
                + " INNER JOIN DMKHOAPHONG e ON d.MaKhoa=e.MaKhoa)"
                + " INNER JOIN DMPHAUTHUAT f ON a.LoaiDichVu=f.LoaiDichVu AND a.MaPT=f.MaDichVu"
                + " INNER JOIN VIEWDOITUONGHIENTAI g ON g.MAVAOVIEN = B.MAVAOVIEN"
                + " WHERE DateDiff(mm,ThoiGianBD,'{0:MM/dd/yyyy}')=0 and f.LoaiPhauThuat in (11,21,3,4) ORDER BY Left(LoaiPhauThuat,1) , ThoiGianBD ", _ThangBC);
            this.DataSource = _ds;
            foreach (DataDynamics.ActiveReports.TextBox txt in detail.Controls)
                if (!Fields.Contains(Fields[txt.DataField]))
                    Fields.Add(txt.DataField);
        }

        private void rptCaPhauThuat_FetchData(object sender, FetchEventArgs eArgs)
        {
            int SN = 0;
            if (eArgs.EOF)
            {
            }
            else
            {
                String MoChinh = "", PhuMo = "", GMChinh = "", PhuGM = "", GiupViec1 = "", GiupViec2 = "", GiupViec3="";
                System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
                SQLCmd.CommandText = string.Format("SELECT TenTat,ViTri FROM BENHNHAN_PT_KIPMO a INNER JOIN DMBACSY b ON a.MaBS=b.MaBS and a.MaKhoa = B.MaKhoa "
                    + " WHERE MaVaoVien='{0}' AND SoPhieuCD='{1}' AND LoaiDichVu='{2}' AND maPT='{3}'", 
                    Fields["MaVaoVien"].Value.ToString(),
                    Fields["SoPhieuCD"].Value.ToString(),
                    Fields["LoaiDichVu"].Value.ToString(),
                    Fields["MaPT"].Value.ToString());
                System.Data.SqlClient.SqlDataReader dr = SQLCmd.ExecuteReader();
                if (eArgs.EOF)
                {
                }
                else
                {
                    while (dr.Read())
                    {
                        switch (dr["ViTri"].ToString())
                        {
                            case "1":
                                MoChinh += dr["Tentat"].ToString() + ", "; SN += 1; break;
                                
                            case "2":
                                PhuMo += dr["Tentat"].ToString() + ", "; SN += 1; break;
                                
                            case "3":
                                GMChinh += dr["Tentat"].ToString() + ", "; SN += 1; break;
                                 
                            case "4":
                                PhuGM += dr["Tentat"].ToString() + ", "; SN += 1; break;
                                 
                            case "5":
                                GiupViec1 += dr["Tentat"].ToString() + ", "; SN += 1; break;
                                
                            case "6":
                                GiupViec2 += dr["Tentat"].ToString() + ", "; SN += 1; break;
                                 
                            case "7":
                                GiupViec3 += dr["Tentat"].ToString() + ", "; SN += 1; break;
                                 
                        }
                    }
                    dr.Close();
                    SQLCmd.Dispose();
                    textBox8.Text =  SN.ToString() ;
                    Fields["MoChinh"].Value = MoChinh;
                    Fields["GMChinh"].Value = GMChinh;
                    Fields["PhuMo"].Value = PhuMo;
                    Fields["PhuGM"].Value = PhuGM;
                    Fields["GiupViec1"].Value = GiupViec1;
                    //Fields["GiupViec2"].Value = GiupViec2;
                    //Fields["GiupViec3"].Value = GiupViec3;
                }
            }
        }
    }
}
