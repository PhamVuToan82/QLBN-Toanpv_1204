using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using System.Data.SqlClient;
using System.Data;
namespace NamDinh_QLBN.Reports.DuyetPhieuCD
{
    
    /// <summary>
    /// Summary description for rptNcTieu10TS.
    /// </summary>
    public partial class rptSoDuyetXN : DataDynamics.ActiveReports.ActiveReport3
    {
        SqlDataAdapter da = new SqlDataAdapter("", GlobalModuls.Global.ConnectSQL);
        DataSet ds = new DataSet();
        DataTable dtLuotXN, dtDMChiSo;
        SqlCommand SQLcmd = new SqlCommand("", GlobalModuls.Global.ConnectSQL);
        SqlDataReader dr;
        public int intSTT = 0;
        public int curRow = 0;
        public DateTime TuNgay ;
        public DateTime ToiNgay ;
        public string MaDT;
        public string TenDT;
        public string NoiCD;
        public string TenNoiCD;
        public int Nhom;
        public int MaSo;
        public int IsTruc;
        private String _MaLoaiCLS;
          public rptSoDuyetXN(object Tu,object Den,String MaLoaiCLS)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            TuNgay = DateTime.Parse(Tu.ToString());
            ToiNgay = DateTime.Parse(Den.ToString());
            _MaLoaiCLS = MaLoaiCLS;
            //lbltenSo.Text = "SỔ " + TenS.ToUpper();
            //MaSo = MaS;
        }

        private void rptNcTieu10TS_DataInitialize(object sender, EventArgs e)
        {
            lblTitle.Text = "Từ ngày: " + string.Format("{0:dd/MM/yyyy}", TuNgay) + " đến ngày: " + string.Format("{0:dd/MM/yyyy}", ToiNgay);
            lblNgayBC.Text = "Ngày " + GlobalModuls.Global.GetNgayLV().Day + " tháng " + GlobalModuls.Global.GetNgayLV().Month + " năm " + GlobalModuls.Global.GetNgayLV().Year;
            string Sql;
            Sql = " SELECT d6.TenLoaiDichVu,d6.MaLoaiDichVu,pk.MaDichVu,d5.TenDichvu,b2.HoTen AS TenBenhNhan,bc.DiaChi,Year(GetDate())-NamSinh as Tuoi,"
                 +" CASE GioiTInh WHEN 1 THEN N'Nữ' ELSE 'Nam'  END AS GioiTinh,"
                 +" case when a.chandoan <> '' then a.chandoan else  viewkhoahientai.ChanDoan end ChanDoan "
                 +" ,b.TenKhoa as KhoaCD,a.NgayChiDinh as NgayCD,pk.SoLuong,d5.DVT,dmbacsy.TenBS AS BacsiCD,(vd.maDoiTuongBHXH + '-' + vd.Sothe + '-' + vd.MaNoiCap)AS SoTheBHYT,"
                 +" TenDu as NguoiDuyet,bc.SoHSBA"
                 +" FROM BENHNHAN_PHIEUDIEUTRI a INNER JOIN DMKHOAPHONG b ON a.MaKhoa=b.MaKhoa  "
                 +" inner join viewkhoahientai on viewkhoahientai.mavaovien = a.mavaovien   "
                 +" inner JOIN ViewDOITUONGHIENTAI vd on vd.mavaovien = a.mavaovien   "
                 +" INNER JOIN DMDOITUONGBN d3 ON vd.DoiTuong = d3.MaDT "
                 +" INNER JOIN BENHNHAN_CHITIET bc ON a.MaVaoVien = bc.MaVaoVien "
                 +" INNER JOIN BENHNHAN b2 ON b2.MaBenhNhan = bc.MaBenhNhan "
                 +" INNER JOIN PHIEUDIEUTRI_CHITIET pk on LoaiDichVu like 'C5%'  AND pk.SoPhieu= a.SoPhieu"
                 +" INNER JOIN DMDICHVU d5 ON d5.MaDichVu = pk.MaDichVu"
                 +" INNER JOIN DMLOAIDICHVU d6 ON d6.MaLoaiDichVu = d5.LoaiDichVu"
                 +" INNER JOIN SYSUSER ON SYSUSER.UNAME = PK.USEDUYETBHYT "
                 +" left join dmbacsy on dmbacsy.makhoa = a.makhoa and dmbacsy.mabs = a.mabs  "
                 +" WHERE pk.NgayDuyetBHYT BETWEEN '" + string.Format("{0:MM/dd/yyyy 00:00}", TuNgay) + "' and '" + string.Format("{0:MM/dd/yyyy 23:59}", ToiNgay) + "'  AND a.SoPhieu LIKE 'NT%'  AND pk.DuyetBHYT =1";
            if (_MaLoaiCLS != "0")
                Sql += String.Format(" and pk.LoaiDichVu ='{0}'", _MaLoaiCLS);

             Sql += " ORDER BY d6.MaLoaiDichVu,d6.TenLoaiDichVu, pk.MaDichVu,pk.NgayDuyetBHYT DESC,b2.HoTen";
            da.SelectCommand.CommandText = Sql;
            da.Fill(ds);
            dtLuotXN = ds.Tables[0];
            this.DataSource = dtLuotXN;
        }

        private void rptNcTieu10TS_FetchData(object sender, FetchEventArgs eArgs)
        {
          
            
        }
       
        private void rptNcTieu10TS_ReportStart(object sender, EventArgs e)
        {
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.PageSettings.Orientation = PageOrientation.Landscape;
            this.PageSettings.Margins.Left = (float)0.6;
            this.PageSettings.Margins.Top = (float)0.5;
            this.PageSettings.Margins.Right = (float)0.1;
            this.PageSettings.Margins.Bottom = (float)0.4;
        }

        private void detail_BeforePrint(object sender, EventArgs e)
        {
            foreach (TextBox txt in detail.Controls)
            {
                txt.Height = detail.Height;
            }
        }

        private void detail_Format(object sender, EventArgs e)
        {
            
            intSTT++;
            txtSTT.Text = intSTT.ToString();
           
        }
        //int STT = 0;
        private void groupHeader1_Format(object sender, EventArgs e)
        {
            intSTT = 0;
         
        }

        private void groupHeader1_BeforePrint(object sender, EventArgs e)
        {
            
        }
    }
}
