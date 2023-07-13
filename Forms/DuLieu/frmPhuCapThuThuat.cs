using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using C1.Win.C1FlexGrid;

namespace NamDinh_QLBN.Forms.DuLieu
{
    public partial class frmPhuCapThuThuat : Form
    {
        private string prvTuNgay = "";
        DataDynamics.ActiveReports.Viewer.Viewer aview;
        public frmPhuCapThuThuat()
        {
            InitializeComponent();
        }

        //private void fg_AfterSelChange(object sender, C1.Win.C1FlexGrid.RangeEventArgs e)
        //{
        //    int TabIndex=-1;
        //    if (fg.Tag.ToString() == "0"|| fg.Row<1) return;
        //    DataDynamics.ActiveReports.ActiveReport3 rpt = null;
        //    for (int i = 0; i < tabBaoCao.TabPages.Count; i++)
        //    {
        //        if (tabBaoCao.TabPages[i].Name == fg[fg.Row, 0].ToString()) TabIndex = i;
        //    }
        //    if (TabIndex == -1)
        //    {                
        //        AddTabBaoCao(fg[e.NewRange.r1, 2].ToString(), fg[fg.Row, 1].ToString());
        //        TabIndex = tabBaoCao.TabPages.Count - 1;
        //    }            
        //    tabBaoCao.SelectedIndex = TabIndex;
        //    DataDynamics.ActiveReports.Viewer.Viewer aview = (DataDynamics.ActiveReports.Viewer.Viewer)tabBaoCao.TabPages[TabIndex].Controls["view" + fg[fg.Row, 2].ToString()];
        //    string newDK = txtTuNgay.Text;
        //    if (aview.Tag.ToString() !=newDK)
        //    {
        //        rpt = TongHopBaoCao(fg[fg.Row, 2].ToString());                
        //        aview.Document.Dispose();
        //        aview.Document = rpt.Document;
        //        aview.Tag= newDK;
        //    }
        //}
        //private DataDynamics.ActiveReports.ActiveReport3 TongHopBaoCao(string LoaiBaoCao)
        //{
        //    DataDynamics.ActiveReports.ActiveReport3 rpt=null;           
        //    switch (LoaiBaoCao )
        //    {
        //        case "1":
        //            rpt = new NamDinh_QLBN.Reports.PhauThuat.rptTH_PhuThuat(txtTuNgay.Value);
        //            break;
        //        case "2":
        //            rpt = new NamDinh_QLBN.Reports.PhauThuat.rptPhuCapPhauThuat(txtTuNgay.Value);
        //            break;
        //        case "3":
        //            rpt = new NamDinh_QLBN.Reports.PhauThuat.rptCaPhauThuat(txtTuNgay.Value);
        //            break;
        //        case "4":
        //            rpt = new NamDinh_QLBN.Reports.PhauThuat.repPhauThuatKyThuatCao((DateTime)txtTuNgay.Value);
        //            break;
        //    }
        //    rpt.Run(); 
        //    prvTuNgay=txtTuNgay.Text;            
        //    return (rpt);
        //}
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void cmdOK_Click(object sender, EventArgs e)
        {

            DataDynamics.ActiveReports.Viewer.Viewer viewBaoCao = new DataDynamics.ActiveReports.Viewer.Viewer();
            viewBaoCao.Name = "view";
            viewBaoCao.Dock = DockStyle.Fill;
            viewBaoCao.Tag = "";
            panel1.Controls.Add(viewBaoCao);
            DataDynamics.ActiveReports.ActiveReport3 rpt = null;
             aview = (DataDynamics.ActiveReports.Viewer.Viewer)panel1.Controls["view"];
            rpt = new NamDinh_QLBN.Reports.PhauThuat.rptPhuCapThuThuat(txtTuNgay.Value, GlobalModuls.Global.GetCode(cmbKhoa), cmbKhoa.Text, txtTu.Value, txtDen.Value);
            aview.Document.Dispose();
            rpt.Run();
            aview.Document = rpt.Document;
         }

        private void cmdXuatFile_Click(object sender, EventArgs e)
        {

            DataDynamics.ActiveReports.ActiveReport3 rpt = null;
            //DataDynamics.ActiveReports.Viewer.Viewer aview = (DataDynamics.ActiveReports.Viewer.Viewer)panel1.Controls["view"];
            //rpt = new NamDinh_QLBN.Reports.PhauThuat.rptPhuCapThuThuat(txtTuNgay.Value, GlobalModuls.Global.GetCode(cmbKhoa), cmbKhoa.Text, txtTu.Value, txtDen.Value);
            //rpt.Run();
            NamDinh_QLBN.Forms.Tien_ich.ExportForm frm = new NamDinh_QLBN.Forms.Tien_ich.ExportForm(aview.Document);
            frm.ShowDialog();

            //NamDinh_QLBN.Forms.Tien_ich.ExportForm frm = new NamDinh_QLBN.Forms.Tien_ich.ExportForm(TongHopBaoCao(fg[fg.Row, 2].ToString()).Document);
            //frm.ShowDialog();
        }

        private void frmPhuCapThuThuat_Load(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlDataReader dr;
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            SQLCmd.CommandText = "SELECT * FROM DMKHOAPHONG WHERE IS_KHOADIEUTRI = 1";
            dr = SQLCmd.ExecuteReader();
            cmbKhoa.Tag = "0";
            cmbKhoa.ClearItems();
            while (dr.Read())
            {
                cmbKhoa.AddItem(string.Format("{0};{1}", dr["MaKhoa"], dr["TenKhoa"]));
            }
            dr.Close();
            cmbKhoa.Tag = "1";
            if (cmbKhoa.ListCount > 0)
            {
                GlobalModuls.Global.SetCmb(cmbKhoa, GlobalModuls.Global.glbMaKhoaPhong);
            }
            SQLCmd.Dispose();
            txtTuNgay.Value = GlobalModuls.Global.NgayLV;            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataDynamics.ActiveReports.Viewer.Viewer viewBaoCao = new DataDynamics.ActiveReports.Viewer.Viewer();
            viewBaoCao.Name = "view";
            viewBaoCao.Dock = DockStyle.Fill;
            viewBaoCao.Tag = "";
            panel1.Controls.Add(viewBaoCao);
            DataDynamics.ActiveReports.ActiveReport3 rpt = null;
            aview = (DataDynamics.ActiveReports.Viewer.Viewer)panel1.Controls["view"];
            rpt = new NamDinh_QLBN.Reports.PhauThuat.rptPhuCapThuThuat_NhanVien(txtTuNgay.Value, GlobalModuls.Global.GetCode(cmbKhoa), cmbKhoa.Text, txtTu.Value, txtDen.Value);
            aview.Document.Dispose();
            rpt.Run();
            aview.Document = rpt.Document;
        }
    }
}