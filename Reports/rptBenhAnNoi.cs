using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace NamDinh_QLBN.Reports
{
    /// <summary>
    /// Summary description for rptBenhAnNoi.
    /// </summary>
    public partial class rptBenhAnNoi : DataDynamics.ActiveReports.ActiveReport3
    {
        private string MaBenhNhan = "";
        private string LanVaoVien = "0";

        public rptBenhAnNoi(string _MaBenhNhan, string _LanVaoVien, string TenKhoa)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            MaBenhNhan = _MaBenhNhan;
            LanVaoVien = _LanVaoVien;
            lblKhoa.Text = "Khoa: " + TenKhoa + "  Giường:..............";
            lblVaoKhoa.Text = TenKhoa;
        }

        private void rptBenhAnNoi_ReportStart(object sender, EventArgs e)
        {
            this.Document.Name = label4.Text;
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.PageSettings.Orientation = PageOrientation.Portrait;

            this.PageSettings.Margins.Left = (float)0.25;
            this.PageSettings.Margins.Right = (float)0.25;
            this.PageSettings.Margins.Top = (float)0.40;
            this.PageSettings.Margins.Bottom = (float)0.10;
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            SQLCmd.CommandText = string.Format("SELECT BENHNHAN.HoTen," + GlobalModuls.Global.NgayLV.Year + "-NamSinh As Tuoi,GioiTinh,MaDanToc,DMDANTOC.TenDT,TenDonVi,DonVi_ChiTiet, "
                                + " TenQH,NoiO,TenTinh,SoTheBHYT,DMDOITUONGBN.TenDT As TenDoiTuong,LienHe,NgayVaoVien, "
                                + " BacSyKham,NgayKham,BENHNHAN_CHITIET.SoHSBA ,TrieuChung_VV,MaNoiCapBHYT,MaDTBHYT "
                                + " FROM ((((((BENHNHAN INNER JOIN BENHNHAN_CHITIET ON BENHNHAN.MaBenhNhan=BENHNHAN_CHITIET.MaBenhNhan) "
                                + " LEFT JOIN DMDANTOC ON BENHNHAN.MaDanToc=DMDANTOC.MaDT) "
                                + " LEFT JOIN DMQUANHAM ON CapBac=MaQH) "
                                + " LEFT JOIN DMDONVI ON DonVi=MaDonVi) "
                                + " LEFT JOIN DMTINH_TP ON MaTinh_TP = MaTinh) "
                                + " INNER JOIN ViewDOITUONGHIENTAI ON BENHNHAN_CHITIET.MaBenhNhan = ViewDOITUONGHIENTAI.MaBenhNhan AND BENHNHAN_CHITIET.LanVaoVien=ViewDOITUONGHIENTAI.LanVaoVien) "
                                + " INNER JOIN DMDOITUONGBN ON ViewDOITUONGHIENTAI.DoiTuong=DMDOITUONGBN.MaDT "
                                + " WHERE BENHNHAN_CHITIET.MaBenhNhan ='{0}' AND BENHNHAN_CHITIET.LanVaoVien={1}", MaBenhNhan, LanVaoVien);
            dr = SQLCmd.ExecuteReader();
            while (dr.Read())
            {
                label6.Text = "Số vào viện: " + dr["SoHSBA"].ToString();
                lblHoTen.Text = dr["HoTen"].ToString().ToUpper();
                lblTuoi.Text = "2. Tuổi: " + dr["Tuoi"].ToString();
                if (dr["Tuoi"].ToString() != "")
                {
                    lblTuoi1.Text = string.Format("{0:#}", byte.Parse(dr["Tuoi"].ToString()) / 10);
                    lblTuoi2.Text = string.Format("{0:0}", byte.Parse(dr["Tuoi"].ToString()) % 10);
                }
                if (dr["GioiTinh"].ToString() == "1") { chkNam.Checked = true; }
                else { chkNu.Checked = true; }
                if (dr["TenDT"].ToString() != "")
                {
                    lblDanToc.Text = "4. Dân tộc: " + dr["tenDT"].ToString();
                    lblDT1.Text = dr["MaDanToc"].ToString().Substring(0, 1);
                    lblDT2.Text = dr["MaDanToc"].ToString().Substring(1, 1);
                }
                if (dr["TrieuChung_VV"].ToString().Trim() != "")
                {
                    label46.Text = "23. KKB, Cấp cứu: " + dr["TrieuChung_VV"];
                }
                lblQuanHam.Text = "6. Quân hàm: " + dr["TenQH"];
                lblDonVi.Text = "8. Đơn vị: " + dr["DonVi_ChiTiet"].ToString() + " - " + dr["TenDonVi"].ToString();
                lblDiaChi.Text = "11. Địa chỉ thường trú: " + dr["NoiO"].ToString() + " - " + dr["TenTinh"];
                lblDoiTuong.Text = dr["TenDoiTuong"].ToString().ToUpper();
                lblSoThe.Text = (dr["SoTheBHYT"].ToString() == "") ? ("") : (string.Format("Số thẻ BHYT: {0}-{1}-{2}", dr["SoTheBHYT"], dr["MaDTBHYT"], dr["MaNoiCapBHYT"]));
                lblLienHe.Text = "13. Họ tên, địa chỉ khi cần báo tin: " + dr["LienHe"].ToString();
                lblNgayGiovaoVien.Text = string.Format("14. Vào viện {0:HH} giờ {0:mm}   ngày {0:dd/MM/yyyy}", dr["NgayVaoVien"]);
                lblLanVaoVien.Text = "- Vào viện do bệnh này lần thứ: " + LanVaoVien.ToString();
                lblBacSyKham.Text = (dr["BacSyKham"].ToString() == "") ? ("Bác sỹ (Họ tên):......................................................................") : ("Bác sỹ (Họ tên): " + dr["BacSyKham"].ToString());
                lblNgayKham.Text = ".............. giờ ..... ngày " + ((dr["NgayKham"].ToString() == "") ? ("...../...../...............") : (string.Format("{0:dd/MM/yyyy}", dr["NgayKham"])));
            }
            dr.Close();
            SQLCmd.Dispose();
        }
    }
}
