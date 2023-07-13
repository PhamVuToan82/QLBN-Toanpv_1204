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
    public partial class repPhieuMuonVai : DataDynamics.ActiveReports.ActiveReport3
    {
        private String _MaKhamBenh;
        private int STT = 0;
        int page = 0;
        public repPhieuMuonVai(String MaKhamBenh)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            _MaKhamBenh = MaKhamBenh;
            //lblTenBN.Text = HoTen;
            //lblTuoi.Text = "Tuổi: " + Tuoi.ToString();
            //lblGioi.Text = "Giới tính: " + GioiTinh;
            //lblChanDoan.Text = "Chẩn đoán: " + ChanDoan;
            //lblNgayThang.Text = String.Format("{0:HH} giờ {0:mm} - Ngày {0:dd} tháng {0:MM} năm {0:yyyy}", NgayChiDinh);
            barcode1.Text = MaKhamBenh;
            //_dieuduong = dieuduong;
        }


        private void repPhieuChiDinh_DataInitialize(object sender, EventArgs e)
        {
             DataDynamics.ActiveReports.DataSources.SqlDBDataSource _ds = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
             _ds.ConnectionString = GlobalModuls.Global.glbConnectionString;
             _ds.SQL = string.Format(" select a.TenBenhnhan,a.Namsinh,a.Gioitinh,b.MaPhieuMuon,b.TenDoVai,b.Soluong,d.Dvt,b.GhiChu,isnull(b.NgayMuon,'2000-05-27 16:46:00.000') as NgayMuon,a.Diachi,a.TenKhoa,convert(numeric(18,2), isnull(c.KyQuy,0)) as KyQuy, Upper(c.NguoiNhaBN_Kq) as NguoiNhaBn,case when b.HoanTien_M = 1 Then N'ĐÃ HOÀN' else '' end as inHoan  from NAMDINH_QLBN.dbo.tblbenhnhan_muonvai a inner join NAMDINH_QLBN.dbo.tblPhieuMuon_Vai b on a.MaKhambenh = b.MaKhamBenh "
                                    + " inner join NAMDINH_QLBN.dbo.tblDoVai d on d.MaDoVai = b.MaDoVai"
                                    + " left join NAMDINH_QLBN.dbo.tblbenhnhan_Vai_KyQuy c on c.MaKhamBenh = a.MaKhambenh and b.MaPhieuMuon = c.MaPhieuMuon"
                                    + " where a.MaKhambenh = '{0}' order by b.MaPhieuMuon", _MaKhamBenh);
             this.DataSource = _ds;
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
            
        }

        private void detail_Format(object sender, EventArgs e)
        {
            STT++;
            lblSTT.Text = STT.ToString();
            //if (txtMadichvu.Text == "C50314" || txtMadichvu.Text == "C50323")
            //{
            //    txtNongDoCon.Visible = true; 
            //}
        }

        private void repPhieuChiDinh_ReportStart(object sender, EventArgs e)
        {
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A5;
            this.PageSettings.Orientation = PageOrientation.Portrait;
            this.PageSettings.Margins.Top = (float)0.2;
            this.PageSettings.Margins.Left = (float)0.2;
            this.PageSettings.Margins.Right = (float)0.0;
            this.PageSettings.Margins.Bottom = (float)0.0;
        }

        private void pageHeader_Format(object sender, EventArgs e)
        {
            STT = 0;
            //barcode2.Text = label20.Text;
        }

        private void repPhieuChiDinh_ketqua_PageStart(object sender, EventArgs e)
        {
            //page += 1;
            //txtPage.Text = "Trang " + page.ToString();
        }

        private void groupHeader2_Format(object sender, EventArgs e)
        {
            //STT = 0;
        }

        private void groupFooter3_Format(object sender, EventArgs e)
        {
        }

        private void groupFooter1_Format(object sender, EventArgs e)
        {

            if (textBox5.Text != "0" && textBox5.Text != "")
            {
                textBox7.Text = "- Số tiền đặt cọc: " + textBox5.Text + "đ";
                textBox4.Text = "- Bằng chữ: ( " + GlobalModuls.Global.WriteNum(long.Parse(textBox5.Text.Replace(".", ""))) + " đồng)";
            }
            else
            {
                textBox7.Text = "";
                textBox4.Text = "";
                textBox5.Text = "0.00";
            }
        }

        private void pageFooter_Format(object sender, EventArgs e)
        {
          
        }

        private void groupHeader2_BeforePrint(object sender, EventArgs e)
        {
            DateTime NgayMuon = DateTime.Parse(Fields["NgayMuon"].Value.ToString());
            //String.Format("{0:HH} giờ {0:mm} - Ngày {0:dd} tháng {0:MM} năm {0:yyyy}", NgayChiDinh);
            label20.Text = "Nam định: " + String.Format("Ngày {0:dd} tháng {0:MM} năm {0:yyyy}", NgayMuon);
        }
    }
}
