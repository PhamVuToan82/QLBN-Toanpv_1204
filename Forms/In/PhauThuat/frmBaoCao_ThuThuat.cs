using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using C1.Win.C1FlexGrid;

namespace NamDinh_QLBN.Forms.In.PhauThuat
{
    public partial class frmBaoCao_ThuThuat : Form
    {
        private string prvTuNgay = "";
        public frmBaoCao_ThuThuat()
        {
            InitializeComponent();
        }

        private void frmBaoCao_Load(object sender, EventArgs e)
        {
            fg.Tag = "0";
            fg.ClipSeparators = "|;";
            fg.Rows.Count = 1;
            fg.AddItem("1|Báo cáo tình hình thủ thuật|1");
            fg.AddItem("2|Bảng thanh toán phụ cấp thủ thuật|2");
            fg.AddItem("3|Bảng kê số ca thủ thuật|3");
            fg.Row = 0;
            fg.Cols[2].Visible = false;
            fg.Tag = "1";
            txtTuNgay.Value = GlobalModuls.Global.NgayLV;            
        }

        private void fg_AfterSelChange(object sender, C1.Win.C1FlexGrid.RangeEventArgs e)
        {
            int TabIndex=-1;
            if (fg.Tag.ToString() == "0"|| fg.Row<1) return;
            DataDynamics.ActiveReports.ActiveReport3 rpt = null;
            for (int i = 0; i < tabBaoCao.TabPages.Count; i++)
            {
                if (tabBaoCao.TabPages[i].Name == fg[fg.Row, 0].ToString()) TabIndex = i;
            }
            if (TabIndex == -1)
            {                
                AddTabBaoCao(fg[e.NewRange.r1, 2].ToString(), fg[fg.Row, 1].ToString());
                TabIndex = tabBaoCao.TabPages.Count - 1;
            }            
            tabBaoCao.SelectedIndex = TabIndex;
            DataDynamics.ActiveReports.Viewer.Viewer aview = (DataDynamics.ActiveReports.Viewer.Viewer)tabBaoCao.TabPages[TabIndex].Controls["view" + fg[fg.Row, 2].ToString()];
            string newDK = txtTuNgay.Text;
            if (aview.Tag.ToString() !=newDK)
            {
                rpt = TongHopBaoCao(fg[fg.Row, 2].ToString());                
                aview.Document.Dispose();
                aview.Document = rpt.Document;
                aview.Tag= newDK;
            }
        }
        private DataDynamics.ActiveReports.ActiveReport3 TongHopBaoCao(string LoaiBaoCao)
        {
            DataDynamics.ActiveReports.ActiveReport3 rpt=null;           
            switch (LoaiBaoCao )
            {
                case "1":
                    rpt = new NamDinh_QLBN.Reports.PhauThuat.rptTH_PhuThuat(txtTuNgay.Value);
                    break;
                case "2":
                    rpt = new NamDinh_QLBN.Reports.PhauThuat.rptPhuCapPhauThuat(txtTuNgay.Value);
                    break;
                case "3":
                    rpt = new NamDinh_QLBN.Reports.PhauThuat.rptCaPhauThuat(txtTuNgay.Value);
                    break;
                case "4":
                    rpt = new NamDinh_QLBN.Reports.PhauThuat.repPhauThuatKyThuatCao((DateTime)txtTuNgay.Value);
                    break;
            }
            rpt.Run(); 
            prvTuNgay=txtTuNgay.Text;            
            return (rpt);
        }
        private void AddTabBaoCao(string tabKey, string tabText)
        {
            tabBaoCao.TabPages.Add(tabKey, tabText);
            //Labell title
            Label lblTite = new Label();
            lblTite.Name = "lbl" + tabKey;
            lblTite.Height = 20;
            lblTite.Dock = DockStyle.Top;
            lblTite.Text =string.Format("{0} - Tháng {1:MM} năm {1:yyyy}", tabText,txtTuNgay.Value);
            lblTite.BackColor = Color.FromArgb(156, 186, 239);
            lblTite.TextAlign = ContentAlignment.MiddleCenter;

            DataDynamics.ActiveReports.Viewer.Viewer viewBaoCao = new DataDynamics.ActiveReports.Viewer.Viewer();
            viewBaoCao.Name = "view" + tabKey;
            viewBaoCao.Dock = DockStyle.Fill;
            viewBaoCao.Tag = "";
            tabBaoCao.TabPages[tabKey].Controls.Add(viewBaoCao);

            //Command button dong tab
            System.Windows.Forms.Button cmdClose = new Button();
            cmdClose.Name = "cmd" + tabKey;
            cmdClose.Text = "X";
            cmdClose.BackColor = Color.FromArgb(156, 186, 239);
            cmdClose.ForeColor = Color.Red;
            cmdClose.Anchor = AnchorStyles.Right;
            cmdClose.Width = cmdClose.Height = lblTite.Height;
            cmdClose.Left = tabBaoCao.TabPages[tabKey].Width - cmdClose.Width - 2;
            cmdClose.Top = lblTite.Top;
            cmdClose.FlatStyle = FlatStyle.Popup;

            cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            //cmdClose
            tabBaoCao.TabPages[tabKey].Controls.Add(cmdClose);
            tabBaoCao.TabPages[tabKey].Controls.Add(viewBaoCao);
            tabBaoCao.TabPages[tabKey].Controls.Add(lblTite);

        }
        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void aView_AfterResizeColumn(object sender, RowColEventArgs e)
        {
            C1.Win.C1FlexGrid.C1FlexGrid fg = (C1.Win.C1FlexGrid.C1FlexGrid)sender;
            fg.AutoSizeRows(0, 0, fg.Rows.Count - 1, fg.Cols.Count - 1, 1, AutoSizeFlags.None);
        }
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void cmdClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn đóng báo cáo này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            tabBaoCao.TabPages.RemoveByKey(((Button)sender).Parent.Name);
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            fg_AfterSelChange(null, null);
        }

        private void cmdXuatFile_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.Tien_ich.ExportForm frm = new NamDinh_QLBN.Forms.Tien_ich.ExportForm(TongHopBaoCao(fg[fg.Row, 2].ToString()).Document);
            frm.ShowDialog();
        }
    }
}