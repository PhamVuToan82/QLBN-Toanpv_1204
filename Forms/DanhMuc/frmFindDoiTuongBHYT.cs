using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NamDinh_QLBN.Forms.DanhMuc
{
    public partial class  frmFindDoiTuongBHYT : Form
    {
        public string Ma, Ten;
        public frmFindDoiTuongBHYT()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }

        private void cmdChon_Click(object sender, EventArgs e)
        {
            if (fgNoiDK.Rows.Count <= 1) return;
            if (fgNoiDK.Row <= 0) return;
            Ma = fgNoiDK.GetDataDisplay(fgNoiDK.Row, "Ma");
            Ten = fgNoiDK.GetDataDisplay(fgNoiDK.Row, "Ten");
            this.DialogResult = DialogResult.OK;
        }

        private void LoatDM(String Find)
        {
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("",GlobalModuls.Global.ConnectSQL);
            SQLCmd.CommandText = String.Format("SELECT * FROM NAMDINH_SYSDB.DBO.DMDTTHE_BHYT A WHERE A.TenDT LIKE N'%{0}%'", Find);
            try
            {
                System.Data.SqlClient.SqlDataReader dr = SQLCmd.ExecuteReader();
                fgNoiDK.Rows.Count = 1;
                fgNoiDK.Redraw = false;
                while (dr.Read())
                {
                    fgNoiDK.Rows.Add();
                    fgNoiDK[fgNoiDK.Rows.Count - 1, "STT"] = String.Format("{0}",fgNoiDK.Rows.Count - 1);
                    fgNoiDK[fgNoiDK.Rows.Count - 1, "Ma"] = dr["MaDT"].ToString();
                    fgNoiDK[fgNoiDK.Rows.Count - 1, "TEN"] = dr["TenDT"].ToString();
                }
                fgNoiDK.Redraw = true;
                fgNoiDK.AutoSizeCols();
                dr.Close();
                dr.Dispose();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
            }
        }

        private void frmFindNoiDangKy_Load(object sender, EventArgs e)
        {
            
        }

        private void cmdFind_Click(object sender, EventArgs e)
        {
            LoatDM(txtFind.Text.Trim());
        }

        private void fgNoiDK_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            cmdChon_Click(null, null);
        }

        private void txtFind_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmdFind_Click(null, null);
        }
    }
}