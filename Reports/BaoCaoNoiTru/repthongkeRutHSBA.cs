using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace NamDinh_QLBN.Reports.BaoCaoNoiTru
{
    /// <summary>
    /// Summary description for repDSBNNhapVien.
    /// </summary>
    public partial class repthongkeRutHSBA : DataDynamics.ActiveReports.ActiveReport3
    {
        private String _s;
        public repthongkeRutHSBA(string s)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            _s = s;


        }

        private void repDSBNNhapVien_ReportStart(object sender, EventArgs e)
        {
            this.Document.Name = "Danh sách bệnh nhân nhập viên";
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.PageSettings.Orientation = PageOrientation.Landscape;

            this.PageSettings.Margins.Left = (float)0.2;
            this.PageSettings.Margins.Right = (float)0.0;
            this.PageSettings.Margins.Top = (float)0.25;
            this.PageSettings.Margins.Bottom = (float)0.2;
        }

        private void repDSBNNhapVien_DataInitialize(object sender, EventArgs e)
        {
             DataDynamics.ActiveReports.DataSources.SqlDBDataSource _ds = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            _ds.ConnectionString = GlobalModuls.Global.glbConnectionString;
            _ds.SQL = String.Format("select a.SoHSBA ,a.SoLuuTru AS A,HoTen,Namsinh,NgayRaVien,TenKhoa,b.Soluutru,ThoigianThanhtoan FROM BENHNHAN_CHITIET  a inner join NAMDINH_VIENPHI.DBO.tblTHANHTOANBHYT B ON A.MaVaoVien = B.MaKhambenh"
                    + " WHERE TrangThai=1 "
                    + " and b.Phieuhuy = 0 and b.MAKHOA != 'NV120101' AND convert(varchar,ngayravien, 103)  IN ({0})"
                    + " ORDER BY A.SoLuuTru,TenKhoa", _s);
            this.DataSource = _ds;
        }

        private void detail_BeforePrint(object sender, EventArgs e)
        {
            //textBox1.Height = textBox2.Height = textBox3.Height = textBox4.Height = textBox5.Height = textBox6.Height = textBox7.Height
            //= textBox8.Height = textBox9.Height = textBox10.Height= detail.Height;
        }

        private void detail_Format(object sender, EventArgs e)
        {
            //textBox1.Text = String.Format("{0}", int.Parse(textBox1.Text) + 1);
        }

        private void pageFooter_Format(object sender, EventArgs e)
        {
            lbPage.Text = String.Format("{0}", int.Parse(lbPage.Text) + 1);
        }
    }
}
