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
    public partial class rptTH_PhuThuat : DataDynamics.ActiveReports.ActiveReport3
    {
        private object _ThangBC;
        public rptTH_PhuThuat(object ThangBC)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            _ThangBC = ThangBC;
            lblThangBC.Text = String.Format("Tháng {0:MM} năm {0:yyyy}",ThangBC);
        }
        private void rptTH_PhuThuat_ReportStart(object sender, EventArgs e)
        {
            this.PageSettings.Orientation = PageOrientation.Portrait;
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.PageSettings.Margins.Left = (float)0.5;
            this.PageSettings.Margins.Right = (float)0.3;
            this.PageSettings.Margins.Top = (float)0.7;
            this.PageSettings.Margins.Bottom = (float)0.7;                        
        }

        private void detail_Format(object sender, EventArgs e)
        {
           
            
        }

        private void detail_BeforePrint(object sender, EventArgs e)
        {
           
        }

        private void reportHeader1_Format(object sender, EventArgs e)
        {

        }

        private void pageHeader_Format(object sender, EventArgs e)
        {

        }

        private void rptTH_PhuThuat_DataInitialize(object sender, EventArgs e)
        {
            DataDynamics.ActiveReports.DataSources.SqlDBDataSource _ds = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            _ds.ConnectionString = GlobalModuls.Global.glbConnectionString;
            _ds.SQL = String.Format("SELECT DMKHOAPHONG.MAKHOA,DMKHOAPHONG.TENKHOA,B.PHIEN_CAPCUU,B.MAPT,C.LOAIPHAUTHUAT FROM "
                + " (BENHNHAN_PHIEUDIEUTRI A INNER JOIN BENHNHAN_PHAUTHUAT B ON A.SOPHIEU = B.SOPHIEUCD AND A.MAVAOVIEN = B.MAVAOVIEN)"
                + " INNER JOIN DMPHAUTHUAT C ON C.MADICHVU = B.MAPT INNER JOIN PHIEUDIEUTRI_CHITIET P ON P.SOPHIEU = A.SOPHIEU AND P.MADICHVU = C.MADICHVU AND P.DATHUCHIEN =1"
                + " LEFT JOIN DMKHOAPHONG ON DMKHOAPHONG.MAKHOA = A.MAKHOA"
                + "  WHERE DATEDIFF(MM,B.THOIGIANBD,'{0:MM/dd/yyyy}') = 0  and C.LOAIPHAUTHUAT in(11,21,3,4)  ORDER BY DMKHOAPHONG.MAKHOA,DMKHOAPHONG.TENKHOA", _ThangBC);
            this.DataSource = _ds;
            foreach (DataDynamics.ActiveReports.TextBox txt in groupHeader1.Controls)
                if (!Fields.Contains(Fields[txt.DataField]))
                    Fields.Add(txt.DataField);
        }

        private void rptTH_PhuThuat_FetchData(object sender, FetchEventArgs eArgs)
        {
            if (eArgs.EOF)
            {
            }
            else
            {
                //Fields["TongPhien"].Value = Fields["PHIEN_CAPCUU"].Value.ToString().Trim() == "1" ? 1 : 0;
                //Fields["TongCC"].Value = Fields["PHIEN_CAPCUU"].Value.ToString().Trim() == "2" ? 1 : 0;
                //Fields["Tong"].Value = Fields["TongPhien"].Value.ToString() == "1" || Fields["TongCC"].Value.ToString() == "1" ? 1 : 0;

                Fields["PTDB_P"].Value = Fields["PHIEN_CAPCUU"].Value.ToString() == "1" && Fields["LOAIPHAUTHUAT"].Value.ToString() == "4" ? 1 : 0;
                Fields["PTDB_CC"].Value = Fields["PHIEN_CAPCUU"].Value.ToString() == "2" && Fields["LOAIPHAUTHUAT"].Value.ToString() == "4" ? 1 : 0;

                Fields["PT1A_P"].Value = Fields["PHIEN_CAPCUU"].Value.ToString() == "1" && Fields["LOAIPHAUTHUAT"].Value.ToString() == "11" ? 1 : 0;
                Fields["PT1A_CC"].Value = Fields["PHIEN_CAPCUU"].Value.ToString() == "2" && Fields["LOAIPHAUTHUAT"].Value.ToString() == "11" ? 1 : 0;
                Fields["PT1B_P"].Value = Fields["PHIEN_CAPCUU"].Value.ToString() == "1" && Fields["LOAIPHAUTHUAT"].Value.ToString() == "12" ? 1 : 0;
                Fields["PT1B_CC"].Value = Fields["PHIEN_CAPCUU"].Value.ToString() == "2" && Fields["LOAIPHAUTHUAT"].Value.ToString() == "12" ? 1 : 0;
                Fields["PT1C_P"].Value = Fields["PHIEN_CAPCUU"].Value.ToString() == "1" && Fields["LOAIPHAUTHUAT"].Value.ToString() == "13" ? 1 : 0;
                Fields["PT1C_CC"].Value = Fields["PHIEN_CAPCUU"].Value.ToString() == "2" && Fields["LOAIPHAUTHUAT"].Value.ToString() == "13" ? 1 : 0;

                Fields["PT2A_P"].Value = Fields["PHIEN_CAPCUU"].Value.ToString() == "1" && Fields["LOAIPHAUTHUAT"].Value.ToString() == "21" ? 1 : 0;
                Fields["PT2A_CC"].Value = Fields["PHIEN_CAPCUU"].Value.ToString() == "2" && Fields["LOAIPHAUTHUAT"].Value.ToString() == "21" ? 1 : 0;
                Fields["PT2B_P"].Value = Fields["PHIEN_CAPCUU"].Value.ToString() == "1" && Fields["LOAIPHAUTHUAT"].Value.ToString() == "22" ? 1 : 0;
                Fields["PT2B_CC"].Value = Fields["PHIEN_CAPCUU"].Value.ToString() == "2" && Fields["LOAIPHAUTHUAT"].Value.ToString() == "22" ? 1 : 0;
                Fields["PT2C_P"].Value = Fields["PHIEN_CAPCUU"].Value.ToString() == "1" && Fields["LOAIPHAUTHUAT"].Value.ToString() == "23" ? 1 : 0;
                Fields["PT2C_CC"].Value = Fields["PHIEN_CAPCUU"].Value.ToString() == "2" && Fields["LOAIPHAUTHUAT"].Value.ToString() == "23" ? 1 : 0;

                Fields["PT3_P"].Value = Fields["PHIEN_CAPCUU"].Value.ToString() == "1" && Fields["LOAIPHAUTHUAT"].Value.ToString() == "3" ? 1 : 0;
                Fields["PT3_CC"].Value = Fields["PHIEN_CAPCUU"].Value.ToString() == "2" && Fields["LOAIPHAUTHUAT"].Value.ToString() == "3" ? 1 : 0;

                Fields["TongPhien"].Value = Int32.Parse(Fields["PTDB_P"].Value.ToString()) + Int32.Parse(Fields["PT1A_P"].Value.ToString()) + Int32.Parse(Fields["PT1B_P"].Value.ToString()) + Int32.Parse(Fields["PT1C_P"].Value.ToString()) + Int32.Parse(Fields["PT2A_P"].Value.ToString()) + Int32.Parse(Fields["PT2B_P"].Value.ToString()) + Int32.Parse(Fields["PT2C_P"].Value.ToString()) + Int32.Parse(Fields["PT3_P"].Value.ToString());
                Fields["TongCC"].Value = Int32.Parse(Fields["PTDB_CC"].Value.ToString()) + Int32.Parse(Fields["PT1A_CC"].Value.ToString()) + Int32.Parse(Fields["PT1B_CC"].Value.ToString()) + Int32.Parse(Fields["PT1C_CC"].Value.ToString()) + Int32.Parse(Fields["PT2A_CC"].Value.ToString()) + Int32.Parse(Fields["PT2B_CC"].Value.ToString()) + Int32.Parse(Fields["PT2C_CC"].Value.ToString()) + Int32.Parse(Fields["PT3_CC"].Value.ToString());
                Fields["Tong"].Value = Int32.Parse(Fields["TongPhien"].Value.ToString()) + Int32.Parse(Fields["TongCC"].Value.ToString());

            }
        }

        private void groupHeader1_BeforePrint(object sender, EventArgs e)
        {
            foreach(TextBox txt in groupHeader1.Controls)
            {
                txt.Height = groupHeader1.Height;
            }
        }
    }
}
