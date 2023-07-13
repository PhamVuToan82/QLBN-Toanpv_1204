using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace NamDinh_QLBN.Reports
{
    /// <summary>
    /// Summary description for repKiemKeVT.
    /// </summary>
    public partial class repKiemKeVT : DataDynamics.ActiveReports.ActiveReport3
    {
        private String _TenKhoa, _MaKhoa;
        private int STT = 0;
        private object _NgayChot;
        public repKiemKeVT(String TenKhoa,String MaKhoa,object NgayChot)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            _TenKhoa = TenKhoa;
            _MaKhoa = MaKhoa;
            _NgayChot = NgayChot;
            lblNgayThang.Text = String.Format("Ngày {0:dd} tháng {0:MM} năm {0:yyyy}", GlobalModuls.Global.GetNgayLV());
        }

        private void repKiemKeVT_DataInitialize(object sender, EventArgs e)
        {
            lblKhoa.Text = _TenKhoa;
            lbTon.Text = String.Format("Kiễm kê đến ngày {0:dd} tháng {0:MM} năm {0:yyyy}", _NgayChot); 
            DataDynamics.ActiveReports.DataSources.SqlDBDataSource _ds = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
             _ds.ConnectionString = GlobalModuls.Global.glbConnectionString;
             _ds.SQL = string.Format(" select AA.MAKHOA,AA.SOLUONGDK,AA.SOLUONGTK,AA.NGAYCHOT,DMDICHVU.TENDICHVU,AA.SOLUONGDSD,dmdichvu.DVT"
                + ",AA.SOLUONGDK + AA.SOLUONGTK - AA.SOLUONGDSD as SoLuongCL from"
                 + " (select * from vetvattu where DATEDIFF(DD,NGAYCHOT,'{0:MM/dd/yyyy}') = 0 and MaKhoa ='{1}') AA"
                 + " Inner join dmdichvu on dmdichvu.madichvu = AA.machiphi",_NgayChot, _MaKhoa);
             this.DataSource = _ds;
        }

        private void repKiemKeVT_FetchData(object sender, FetchEventArgs eArgs)
        {
            STT++;
            lblSTT.Text = STT.ToString();
        }

        private void repKiemKeVT_ReportStart(object sender, EventArgs e)
        {
            this.PageSettings.Margins.Top = (float)0.7;
            this.PageSettings.Margins.Left = (float)0.5;
            this.PageSettings.Margins.Right = (float)0.0;
            this.PageSettings.Margins.Bottom = (float)0.5;
        }
    }
}
