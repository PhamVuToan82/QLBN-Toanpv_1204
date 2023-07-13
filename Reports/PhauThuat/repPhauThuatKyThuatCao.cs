using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace NamDinh_QLBN.Reports.PhauThuat
{
    /// <summary>
    /// Summary description for repPhauThuatKyThuatCao.
    /// </summary>
    public partial class repPhauThuatKyThuatCao : DataDynamics.ActiveReports.ActiveReport3
    {
        private DateTime _Ngay;
        public repPhauThuatKyThuatCao(DateTime Ngay)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            _Ngay = Ngay;
        }

        private void repPhauThuatKyThuatCao_DataInitialize(object sender, EventArgs e)
        {
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.PageSettings.Orientation = PageOrientation.Portrait;

            this.PageSettings.Margins.Left = (float)0.4;
            this.PageSettings.Margins.Right = (float)0.25;
            this.PageSettings.Margins.Top = (float)1;
            this.PageSettings.Margins.Bottom = (float)0.10;

            DataDynamics.ActiveReports.DataSources.SqlDBDataSource _ds = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();

            _ds.ConnectionString = GlobalModuls.Global.glbConnectionString;

            _ds.SQL = String.Format("SELECT DMDICHVU.TENDICHVU,A.MAPT,A.LOAIDICHVU,DMKHOAPHONG.KHOI,A.MAVAOVIEN,"
                + " CASE WHEN DMKHOAPHONG.KHOI = 0 THEN N'Khối ngoại' ELSE N'Các khoa khác' END AS TENKHOI FROM"
                + " (BENHNHAN_PHAUTHUAT A INNER JOIN DMPHAUTHUAT B ON A.MAPT = B.MADICHVU AND A.LOAIDICHVU = B.LOAIDICHVU)"
                + " INNER JOIN DMDICHVU ON DMDICHVU.MADICHVU = A.MAPT AND DMDICHVU.LOAIDICHVU = A.LOAIDICHVU"
                + " INNER JOIN BENHNHAN_PHIEUDIEUTRI C ON C.MAVAOVIEN = A.MAVAOVIEN AND C.SOPHIEU = A.SOPHIEUCD"
                + " LEFT JOIN DMKHOAPHONG ON DMKHOAPHONG.MAKHOA = C.MAKHOA"
                + " WHERE B.KyThuatCao = 1 AND DATEDIFF(MM,A.ThoiGianBD,'{0:MM/dd/yyyy}') = 0   "
                + " ORDER BY DMKHOAPHONG.KHOI,A.MAPT,A.LOAIDICHVU,A.MAVAOVIEN", _Ngay);
            this.DataSource = _ds;
            foreach (DataDynamics.ActiveReports.TextBox _lb in groupHeader2.Controls)
            {
                if (!Fields.Contains(Fields[_lb.DataField]))
                    Fields.Add(_lb.DataField);
            }
        }

        private void groupHeader2_Format(object sender, EventArgs e)
        {
            STT.Text = string.Format("{0}", int.Parse(STT.Text) + 1);
        }

        private void groupHeader1_Format(object sender, EventArgs e)
        {
            STT.Text = "0";
        }
    }
}
