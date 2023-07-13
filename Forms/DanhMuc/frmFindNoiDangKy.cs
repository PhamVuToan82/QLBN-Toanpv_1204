using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NamDinh_QLBN.Forms.DanhMuc
{
    public partial class frmFindNoiDangKy : Form
    {
        public string Ma, Ten, Ma_huyen, Tuyen_BV, Hang_BV, Dia_chi,  isNoiChuyen,  isNoiChuyenDi;
        public frmFindNoiDangKy()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void cmdChon_Click(object sender, EventArgs e)
        {
            if (fgNoiDK.Rows.Count <= 1) return;
            if (fgNoiDK.Row <= 0) return;
            Ma = fgNoiDK.GetDataDisplay(fgNoiDK.Row, "Ma");
            Ten = fgNoiDK.GetDataDisplay(fgNoiDK.Row, "Ten");
            Ma_huyen = fgNoiDK.GetDataDisplay(fgNoiDK.Row, "Ma_huyen");
            Tuyen_BV = fgNoiDK.GetDataDisplay(fgNoiDK.Row, "Tuyen_BV");
            Hang_BV = fgNoiDK.GetDataDisplay(fgNoiDK.Row, "Hang_BV");
            Dia_chi = fgNoiDK.GetDataDisplay(fgNoiDK.Row, "Dia_chi");
            isNoiChuyen = fgNoiDK.GetDataDisplay(fgNoiDK.Row, "isNoiChuyen");
            isNoiChuyenDi = fgNoiDK.GetDataDisplay(fgNoiDK.Row, "isNoiChuyenDi");
            this.DialogResult = DialogResult.OK;
        }

        private void LoatDM(String Find)
        {
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("",GlobalModuls.Global.ConnectSQL);
            SQLCmd.CommandText = String.Format("SELECT * FROM NAMDINH_SYSDB.DBO.DMNOIDKKCBBD_BHYT A WHERE  a.tennoicap like N'%{0}%' ",Find);
            try
            {
                System.Data.SqlClient.SqlDataReader dr = SQLCmd.ExecuteReader();
                fgNoiDK.Rows.Count = 1;
                fgNoiDK.Redraw = false;
                while (dr.Read())
                {
                    fgNoiDK.Rows.Add();
                    fgNoiDK[fgNoiDK.Rows.Count - 1, "STT"] = String.Format("{0}",fgNoiDK.Rows.Count - 1);
                    fgNoiDK[fgNoiDK.Rows.Count - 1, "Ma"] = dr["MANOICAP"].ToString();
                    fgNoiDK[fgNoiDK.Rows.Count - 1, "TEN"] = dr["TENNOICAP"].ToString();
                    fgNoiDK[fgNoiDK.Rows.Count - 1, "Ma_huyen"] = dr["Ma_huyen"].ToString();
                    fgNoiDK[fgNoiDK.Rows.Count - 1, "Tuyen_BV"] = dr["Tuyen_BV"].ToString();
                    fgNoiDK[fgNoiDK.Rows.Count - 1, "Hang_BV"] = dr["Hang_BV"].ToString();
                    fgNoiDK[fgNoiDK.Rows.Count - 1, "Dia_chi"] = dr["Dia_chi"].ToString();
                    fgNoiDK[fgNoiDK.Rows.Count - 1, "isNoiChuyen"] = dr["isNoiChuyen"].ToString();
                    fgNoiDK[fgNoiDK.Rows.Count - 1, "isNoiChuyenDi"] = dr["isNoiChuyenDi"].ToString();

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

        private void btn_Ghi_Click(object sender, EventArgs e)
        {
            //fgNoiDK.AllowAddNew = false;
            fgNoiDK.Rows.Count = 1;
            fgNoiDK.Rows.Add();
            button2.Visible = true;
            btn_Ghi.Visible = false;
            //System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", GlobalModuls.Global.ConnectSQL);
            //SQLCmd.CommandText = String.Format("SELECT * FROM NAMDINH_SYSDB.DBO.DMNOIDKKCBBD_BHYT A WHERE A.TENNOICAP LIKE N'%{0}%'", Find);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Visible = false;
            btn_Ghi.Visible = true;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            string s =  fgNoiDK.GetCellCheck(fgNoiDK.Row, 7).ToString();
            string s1 = fgNoiDK.GetCellCheck(fgNoiDK.Row, 8).ToString();
            SQLCmd.CommandText = string.Format("Begin if NOT EXISTS (select MaNoiCap from NAMDINH_SYSDB.dbo.DMNOIDKKCBBD_BHYT where MaNoiCap='{0}') " +
                " begin  INSERT INTO NAMDINH_SYSDB.dbo.DMNOIDKKCBBD_BHYT(Manoicap, Tennoicap, Ma_huyen, Tuyen_BV, Hang_BV, Dia_chi, isNoiChuyen, isNoiChuyenDi) " +
                " VALUES ('{0}',N'{1}','{2}','{3}','{4}',N'{5}',{6},{7}) End " +
                " else begin update NAMDINH_SYSDB.dbo.DMNOIDKKCBBD_BHYT set TenNoiCap  = N'{1}', Ma_huyen = '{2}', Tuyen_BV = '{3}', Hang_BV= '{4}', Dia_chi= N'{5}',  isNoiChuyen= {6}, isNoiChuyenDi = {7} " +
                "where MaNoiCap = '{0}' END END", 
                fgNoiDK[fgNoiDK.Row, "Ma"], fgNoiDK[fgNoiDK.Row, "Ten"], fgNoiDK[fgNoiDK.Row, "Ma_huyen"], fgNoiDK[fgNoiDK.Row, "Tuyen_BV"], fgNoiDK[fgNoiDK.Row, "Hang_BV"], fgNoiDK[fgNoiDK.Row, "Dia_chi"], fgNoiDK.GetCellCheck(fgNoiDK.Row, 7).ToString() == "Checked" ? 1 : 0, fgNoiDK.GetCellCheck(fgNoiDK.Row, 8).ToString() == "Checked" ? 1 : 0);
            try
            { SQLCmd.ExecuteNonQuery(); }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi thêm dữ liệu!\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally { SQLCmd.Dispose(); }
        }

        private void txtFind_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmdFind_Click(null, null);
        }
    }
}