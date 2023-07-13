using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GlobalModuls;

namespace NamDinh_QLBN.Forms.Tien_ich
{
    public partial class frmTraCuuICD : Form
    {
        public String  _MaICD,_TenICD;
        public frmTraCuuICD()
        {
            InitializeComponent();
        }

        private void txtTenICD_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtTenICD.Text == "")
            {
                fgICD.Rows.Count = 1;
                return;
            }
            if (e.KeyCode == Keys.Space||e.KeyCode ==Keys.Enter)
            {
                System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
                SQLCmd.CommandText = "SELECT CICD10 as [Mã ICD],VViet as [Tên ICD] FROM DMICD10 WHERE VViet Like N'%" + txtTenICD.Text + "%'";
                System.Data.SqlClient.SqlDataReader dr = SQLCmd.ExecuteReader();
                fgICD.Tag = "0";
                Global.BindDataReaderToFlex(dr, fgICD);
                fgICD.Tag = "1";
                dr.Close();
                SQLCmd.Dispose();
                for (int i = 1; i < fgICD.Rows.Count; i++)
                    fgICD[i, "STT"] = i.ToString();
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }

        private void fgICD_AfterSelChange(object sender, C1.Win.C1FlexGrid.RangeEventArgs e)
        {
            //if (fgICD.Tag.ToString() == "0") return;
            //if (fgICD.Rows.Count <= 1) return;
            //if (fgICD.Row <= 0) return;
            //txtTenICD.Text = fgICD[fgICD.Row, 2].ToString();
            //txtMaICD.Text = fgICD[fgICD.Row, 1].ToString();
        }

        private void cmdChon_Click(object sender, EventArgs e)
        {
            if (fgICD.Row > 0)
            {
                //for(int i = 1; i<=fgICD.Rows.Count-1; i++)
                //{
                //    string macha = "";
                //    if ( fgICD[i, 1].ToString().Length <= 3)
                //    {
                //         macha = fgICD[i, 1].ToString();
                //    }
                //    for(int j = i+1;  j <= fgICD.Rows.Count-1;j++ )
                //    {
                //        string macon = fgICD[j, 1].ToString();
                //        if (macon.Substring(0,3) == macha.Substring(0,3) && macon.Length >= macha.Length)
                //        {
                //            MessageBox.Show("có mã con");
                //            return;
                //        }
                //        else
                //        {
                //            MessageBox.Show("Không có mã con");
                //            return;
                //        }
                //    }
                    
                //}
                _MaICD = fgICD[fgICD.Row, 1].ToString();
                _TenICD = fgICD[fgICD.Row, 2].ToString();
                this.DialogResult = DialogResult.OK;

            }
        }

        private void txtMaICD_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtMaICD.Text == "")
            {
                fgICD.Rows.Count = 1;
                return;
            }
            if (e.KeyCode == Keys.Space || e.KeyCode == Keys.Enter)
            {
                System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
                SQLCmd.CommandText = "SELECT CICD10 as [Mã ICD],VViet as [Tên ICD] FROM DMICD10 WHERE CICD10 Like N'%" + txtMaICD.Text + "%'";
                System.Data.SqlClient.SqlDataReader dr = SQLCmd.ExecuteReader();
                fgICD.Tag = "0";
                Global.BindDataReaderToFlex(dr, fgICD);
                fgICD.Tag = "1";
                dr.Close();
                SQLCmd.Dispose();
                for (int i = 1; i < fgICD.Rows.Count; i++)
                 fgICD[i, "STT"] = i.ToString();
            }
        }

        private void fgICD_DoubleClick(object sender, EventArgs e)
        {
            cmdChon_Click(null,null);
        }

        private void txtMaICD_TextChanged(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
            SQLCmd.CommandText = "SELECT CICD10 as [Mã ICD],VViet as [Tên ICD] FROM DMICD10 WHERE  CICD10 Like N'%" + txtMaICD.Text + "%'";
            System.Data.SqlClient.SqlDataReader dr = SQLCmd.ExecuteReader();
            fgICD.Tag = "0";
            Global.BindDataReaderToFlex(dr, fgICD);
            fgICD.Styles.Normal.WordWrap = true;
            fgICD.Tag = "1";
            dr.Close();
            SQLCmd.Dispose();
            for (int i = 1; i < fgICD.Rows.Count; i++)
                fgICD[i, "STT"] = i.ToString();
        }

        private void cmdFind_Click(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
            SQLCmd.CommandText = "SELECT CICD10 as [Mã ICD],VViet as [Tên ICD] FROM DMICD10 WHERE  VViet Like N'%" + txtTenICD.Text + "%'";
            System.Data.SqlClient.SqlDataReader dr = SQLCmd.ExecuteReader();
            fgICD.Tag = "0";
            Global.BindDataReaderToFlex(dr, fgICD);
            fgICD.Styles.Normal.WordWrap = true;
            fgICD.Tag = "1";
            dr.Close();
            SQLCmd.Dispose();
            for (int i = 1; i < fgICD.Rows.Count; i++)
                fgICD[i, "STT"] = i.ToString();
        }
    }
}