using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using System.Data.SqlClient;
using System.Data;
using GlobalModuls;

namespace NamDinh_QLBN.Reports
{
    /// <summary>
    /// Summary description for repDuyetPhauThuat.
    /// </summary>
    public partial class rptTichKeXN : DataDynamics.ActiveReports.ActiveReport3
    {
        public rptTichKeXN()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            
        }

        private void repDuyetPhauThuat_ReportStart(object sender, EventArgs e)
        {
            this.PageSettings.Orientation = PageOrientation.Landscape;
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A5;
            this.PageSettings.Margins.Top = (float)0.1;
            this.PageSettings.Margins.Left = (float)0.4;
            this.PageSettings.Margins.Right = (float)0.0;
            this.PageSettings.Margins.Bottom = (float)0.0;
            
        }

        private void repDuyetPhauThuat_DataInitialize(object sender, EventArgs e)
        {
            
        }

        private void rptTichKeXN_PrintProgress(object sender, EventArgs e)
        {
            //System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
            //string Str = String.Format("if not exists (select * from NAMDINH_VIENPHI.DBO.tblTichKeXetNghiem717 where SoTichKe = @MaKB and datediff(s,ThoiGianIn,getdate())=0 ) Insert into NAMDINH_VIENPHI.DBO.tblTichKeXetNghiem717 (SoTichKe,TenBenhNhan,Khoa,SoTien,ThoiGianIn,NguoiIn,DaDuyet) values ( @MaKB,@TenBN, @Khoa, @Sotien, getdate(), @NguoiIn,@DaDuyet)");
            //SQLCmd.CommandText = Str;
            //SqlParameter MaKB = new SqlParameter("@MaKB", SqlDbType.VarChar, 11);
            //MaKB.Value = Barcode1.Text;
            //SQLCmd.Parameters.Add(MaKB);
            //SqlParameter TenBN = new SqlParameter("@TenBN", SqlDbType.NVarChar, 20);
            //TenBN.Value = lblTenBN.Text;
            //SQLCmd.Parameters.Add(TenBN);
            //SqlParameter TenKhoa = new SqlParameter("@Khoa", SqlDbType.NVarChar, 20);
            //TenKhoa.Value = lblTenKhoa.Text;
            //SQLCmd.Parameters.Add(TenKhoa);
            //SqlParameter Sotien = new SqlParameter("@Sotien", SqlDbType.Decimal);
            //Sotien.Value = double.Parse(txtTongTien.Text);
            //SQLCmd.Parameters.Add(Sotien);
            //SqlParameter NguoiIn = new SqlParameter("@NguoiIn", SqlDbType.NVarChar, 20);
            //if (lblBacSiCD.Text != null) NguoiIn.Value = lblBacSiCD.Text;
            //else NguoiIn.Value = "";
            //SQLCmd.Parameters.Add(NguoiIn);
            //SqlParameter DaDuyet = new SqlParameter("@DaDuyet", SqlDbType.Bit);
            //DaDuyet.Value = 0;
            //SQLCmd.Parameters.Add(DaDuyet);
            //SQLCmd.CommandTimeout = 0;
            //SQLCmd.ExecuteNonQuery();
        }

        private void pageHeader_Format(object sender, EventArgs e)
        {

        }
    }
}
