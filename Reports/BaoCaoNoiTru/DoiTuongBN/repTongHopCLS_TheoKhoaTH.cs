using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace NamDinh_QLBN.Reports.BaoCaoNoiTru.DoiTuongBN
{
    /// <summary>
    /// Summary description for repTongHopCLS_TheoKhoaTH.
    /// </summary>
    public partial class repTongHopCLS_TheoKhoaTH : DataDynamics.ActiveReports.ActiveReport3
    {
        private DateTime _TNgay, _DNgay;
        private bool _DaThucHien = true;

        public repTongHopCLS_TheoKhoaTH(DateTime TNgay,DateTime DNgay,bool DaThucHien)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            _TNgay = TNgay;
            _DNgay = DNgay;
        }

        private void repTongHopCLS_TheoKhoaTH_ReportStart(object sender, EventArgs e)
        {
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.PageSettings.Orientation = PageOrientation.Landscape;
            this.PageSettings.Margins.Left = (float)0.25;
            this.PageSettings.Margins.Top = (float)0.5;
            this.PageSettings.Margins.Right = (float)0;
        }

        private void repTongHopCLS_TheoKhoaTH_DataInitialize(object sender, EventArgs e)
        {
            DataDynamics.ActiveReports.DataSources.SqlDBDataSource _ds = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            //HeThong.clsConnectionProvider Conn = new HeThong.clsConnectionProvider();
            //_ds.ConnectionString = Conn.scoDBConnection.ConnectionString;
            _ds.SQL = String.Format("SELECT B.DOITUONG,B.DOITUONGTHE,DMKHOAPHONG.TENKHOA,DMKHOAPHONG.MAKHOA,YEAR(B.THOIGIANDANGKY) - A.NAMSINH AS TUOI,B.HuongGQ FROM "
                + " (BENHNHAN A INNER JOIN KB_KHAMBENH B ON A.MABENHNHAN = B.MABENHNHAN)"
                + " INNER JOIN KB_PHIEUCHIDINH PHIEUCHIDINH ON PHIEUCHIDINH.MAKHAMBENH = B.MAKHAMBENH"
                + " INNER JOIN KB_CLS ON KB_CLS.MAPHIEUCHIDINH = PHIEUCHIDINH.MAPHIEUCHIDINH"
                + " INNER JOIN DMKHOAPHONG ON DMKHOAPHONG.MAKHOA = KB_CLS.KhoaThucHien"
                + " WHERE PHIEUCHIDINH.LOAIPHIEUCHIDINH = 1 ");
            if(_DaThucHien)
                _ds.SQL += string.Format(" AND KB_CLS.DATHUCHIEN = 1");
            _ds.SQL += string.Format(" AND DBO.NGAY(PHIEUCHIDINH.THOIGIANCD) BETWEEN '{0:MM/dd/yyyy}' AND '{1:MM/dd/yyyy}'  ORDER BY MAKHOA", 
            _TNgay, 
            _DNgay);
            this.DataSource = _ds;
            foreach (DataDynamics.ActiveReports.TextBox txt in groupHeader1.Controls)
                if (!Fields.Contains(Fields[txt.DataField]))
                    Fields.Add(txt.DataField);
        }

        private void groupHeader1_Format(object sender, EventArgs e)
        {
            TT.Text = String.Format("{0}", int.Parse(TT.Text) + 1);
        }

        private void repTongHopCLS_TheoKhoaTH_FetchData(object sender, FetchEventArgs eArgs)
        {
            if (eArgs.EOF)
            {
            }
            else
            {
                Fields["BHYT_NG_NL"].Value = ((Fields["DoiTuong"].Value.ToString() == "1") && (int.Parse(Fields["Tuoi"].Value.ToString()) > 6) && (Fields["DoiTuongThe"].Value.ToString() == "HN")) ? 1 : 0;
                Fields["BHYT_NG_TE"].Value = ((Fields["DoiTuong"].Value.ToString() == "1") && (int.Parse(Fields["Tuoi"].Value.ToString()) <= 6) && (Fields["DoiTuongThe"].Value.ToString() == "HN")) ? 1 : 0;
                Fields["BHYT_NG_TONG"].Value = ((int.Parse(Fields["BHYT_NG_NL"].Value.ToString()) == 1) || (int.Parse(Fields["BHYT_NG_TE"].Value.ToString()) == 1)) ? 1 : 0;

                Fields["BHYT_KHAC_NL"].Value = ((Fields["DoiTuong"].Value.ToString() == "1") && (int.Parse(Fields["Tuoi"].Value.ToString()) > 6) && (Fields["DoiTuongThe"].Value.ToString() != "HN")) ? 1 : 0;
                Fields["BHYT_KHAC_TE"].Value = ((Fields["DoiTuong"].Value.ToString() == "1") && (int.Parse(Fields["Tuoi"].Value.ToString()) <= 6) && (Fields["DoiTuongThe"].Value.ToString() != "HN")) ? 1 : 0;
                Fields["BHYT_KHAC_TONG"].Value = ((int.Parse(Fields["BHYT_KHAC_NL"].Value.ToString()) == 1) || (int.Parse(Fields["BHYT_KHAC_TE"].Value.ToString()) == 1)) ? 1 : 0;

                Fields["BHYT_TONG"].Value = Fields["BHYT_NG_TONG"].Value.ToString() == "1" || Fields["BHYT_KHAC_TONG"].Value.ToString() == "1" ? 1 : 0;

                Fields["VP_NL"].Value = ((Fields["Doituong"].Value.ToString() == "2") && (int.Parse(Fields["Tuoi"].Value.ToString()) > 6)) ? 1 : 0;
                Fields["VP_TE"].Value = ((Fields["Doituong"].Value.ToString() == "2") && (int.Parse(Fields["Tuoi"].Value.ToString()) <= 6)) ? 1 : 0;
                Fields["VP_TONG"].Value = ((int.Parse(Fields["VP_NL"].Value.ToString()) == 1) || (int.Parse(Fields["VP_TE"].Value.ToString()) == 1)) ? 1 : 0;

                Fields["TE6"].Value = ((Fields["DoiTuong"].Value.ToString() == "1") && (Fields["DoiTuongThe"].Value.ToString() == "TE")) ? 1 : 0;

                Fields["TongKBenh"].Value = Fields["BHYT_TONG"].Value.ToString() == "1" || Fields["VP_TONG"].Value.ToString() == "1" ? 1 : 0;

                Fields["TongNV"].Value = (Fields["TongKBenh"].Value.ToString() == "1") && (Fields["HuongGQ"].Value.ToString() == "2") ? 1 : 0;
                Fields["TongCV"].Value = (Fields["TongKBenh"].Value.ToString() == "1") && (Fields["HuongGQ"].Value.ToString() == "3") ? 1 : 0;
            }
        }

        private void groupHeader1_BeforePrint(object sender, EventArgs e)
        {
            txtBHYT_KHAC_NL.Height = txtBHYT_KHAC_TE.Height = txtBHYT_KHAC_TONG.Height = txtBHYT_NG_NL.Height = txtBHYT_NG_TE.Height = txtBHYT_NG_TONG.Height =
                txtBHYT_TONG.Height = txtTE6.Height = txtTenPhong.Height = txtTongCV.Height = txtTongKBenh.Height = txtTongNV.Height = txtVP_NL.Height =
                txtVP_TE.Height = txtVP_TONG.Height = TT.Height= groupHeader1.Height;
        }
    }
}
