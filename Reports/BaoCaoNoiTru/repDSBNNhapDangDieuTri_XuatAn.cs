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
    public partial class repDSBNNhapDangDieuTri_XuatAn : DataDynamics.ActiveReports.ActiveReport3
    {
        private String _MaKhoa;
        public repDSBNNhapDangDieuTri_XuatAn(String MaKhoa, String TenKhoa)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            _MaKhoa = MaKhoa;
            lbKhoa.Text = TenKhoa;
            lblNgayThang.Text = string.Format("DANH SÁCH XUẤT ĂN BỆNH NHÂN ĐANG ĐIỀU TRỊ");
            
        }

        private void repDSBNNhapVien_ReportStart(object sender, EventArgs e)
        {
            this.Document.Name = "Danh sách bệnh nhân nhập viên";
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.PageSettings.Orientation = PageOrientation.Portrait;

            this.PageSettings.Margins.Left = (float)0.3;
            this.PageSettings.Margins.Right = (float)0.0;
            this.PageSettings.Margins.Top = (float)0.25;
            this.PageSettings.Margins.Bottom = (float)0.2;
        }

        private void repDSBNNhapVien_DataInitialize(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("GetDSBNDangDieuTri_XuatAn");
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            System.Data.SqlClient.SqlDataReader dt;
            SQLCmd.CommandType = System.Data.CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            //SQLCmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TuNgay", _TNgay));
            //SQLCmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DenNgay", _DNgay));
            SQLCmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MaKhoa", _MaKhoa));
            dt = SQLCmd.ExecuteReader();
            this.DataSource = dt;
        }

        private void detail_BeforePrint(object sender, EventArgs e)
        {
            textBox1.Height = textBox2.Height = textBox3.Height = textBox4.Height = textBox5.Height = textBox6.Height = textBox7.Height
            = textBox8.Height = textBox9.Height = textBox10.Height= textBox11.Height= detail.Height;
        }

        private void detail_Format(object sender, EventArgs e)
        {
            textBox1.Text = String.Format("{0}", int.Parse(textBox1.Text) + 1);
        }

        private void pageFooter_Format(object sender, EventArgs e)
        {
            lbPage.Text = String.Format("{0}", int.Parse(lbPage.Text) + 1);
        }
    }
}
