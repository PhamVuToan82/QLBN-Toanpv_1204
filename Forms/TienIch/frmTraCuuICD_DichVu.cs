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
    public partial class frmTraCuuICD_DichVu : Form
    {
        public String  _MaICD,_TenICD,_MaDichVu,_KiemTraICD;
        public frmTraCuuICD_DichVu(string MaDichVu,string KiemTraICD)
        {
            InitializeComponent();
            _MaDichVu = MaDichVu;
            _KiemTraICD = KiemTraICD;
            if(_KiemTraICD == "1")
            {
                button1.Enabled = false;
            }
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
                SQLCmd.CommandText = "select  a.CICD10 as [Mã ICD],a.VViet as [Tên ICD] from NAMDINH_SYSDB.dbo.DMICD10 a  inner join NAMDINH_QLBN.dbo.tblICD_DichVu b on a.CICD10 = b.ICD10 where MaDichVu = '"+ _MaDichVu + "' and VViet Like N'%" + txtTenICD.Text + "%'";
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
            if (fgICD.Tag.ToString() == "0") return;
            if (fgICD.Rows.Count <= 1) return;
            if (fgICD.Row <= 0) return;
            txtTenICD.Text = fgICD[fgICD.Row, 2].ToString();
            txtMaICD.Text = fgICD[fgICD.Row, 1].ToString();
        }

        private void cmdChon_Click(object sender, EventArgs e)
        {
            if(txtMaICD.Text == "")
            {
                return;
            }
            else
            {
                System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
                SQLCmd.CommandText = "select  a.CICD10 as [Mã ICD],a.VViet as [Tên ICD] from NAMDINH_SYSDB.dbo.DMICD10 a  inner join NAMDINH_QLBN.dbo.tblICD_DichVu b on a.CICD10 = b.ICD10 where CICD10 = '" + txtMaICD.Text + "'";
                System.Data.SqlClient.SqlDataReader dr = SQLCmd.ExecuteReader();
                if(!dr.HasRows)
                {
                    MessageBox.Show("Chọn mã bệnh trong danh sách ", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    dr.Close();
                    return;
                }
                dr.Close();
            }
            if (fgICD.Row > 0)
            {
                _MaICD = txtMaICD.Text.ToUpper();
                _TenICD = txtTenICD.Text;
                if(_MaICD == null)
                { return; }
                else
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
                SQLCmd.CommandText = "select  a.CICD10 as [Mã ICD],a.VViet as [Tên ICD] from NAMDINH_SYSDB.dbo.DMICD10 a  inner join NAMDINH_QLBN.dbo.tblICD_DichVu b on a.CICD10 = b.ICD10 where MaDichVu = '" + _MaDichVu + "' and VViet Like N'%" + txtTenICD.Text + "%'";
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
            //if(fgICD.Row >0)
            //{
            //    txtMaICD.Text = fgICD[fgICD.Row, "MaICD"].ToString();
            //    txtTenICD.Text = fgICD[fgICD.Row, "tenICD"].ToString();
            //}
            cmdChon_Click(null,null);
        }

        private void txtMaICD_TextChanged(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
            SQLCmd.CommandText = "select  a.CICD10 as [Mã ICD],a.VViet as [Tên ICD] from NAMDINH_SYSDB.dbo.DMICD10 a  inner join NAMDINH_QLBN.dbo.tblICD_DichVu b on a.CICD10 = b.ICD10 where MaDichVu = '" + _MaDichVu + "' and VViet Like N'%" + txtTenICD.Text + "%'";
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
            SQLCmd.CommandText = "select  a.CICD10 as [Mã ICD],a.VViet as [Tên ICD] from NAMDINH_SYSDB.dbo.DMICD10 a  inner join NAMDINH_QLBN.dbo.tblICD_DichVu b on a.CICD10 = b.ICD10 where MaDichVu = '" + _MaDichVu + "' and VViet Like N'%" + txtTenICD.Text + "%'";
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