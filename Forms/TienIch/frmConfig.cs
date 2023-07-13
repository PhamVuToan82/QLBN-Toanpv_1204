using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GlobalModuls;
using C1.Win.C1FlexGrid;

namespace NamDinh_QLBN.Forms.Tien_ich
{
    public partial class frmConfig : Form
    {
        private CellStyle pStyle=null;
        
        public frmConfig()
        {
            InitializeComponent();
        }

        private void frmConfig_Load(object sender, EventArgs e)
        {
            lblUName.Text = GlobalModuls.Global.glbUName;
            fgDanhMuc.Cols[0].AllowEditing = false;
            fgDanhMuc.Cols[1].AllowEditing = false;
            fgDanhMuc.Cols[2].AllowEditing = false;
            
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            SQLCmd.CommandText = "SELECT * FROM DMLOAICHIPHI WHERE MaLoai>3 ORDER BY MaLoai";
            dr = SQLCmd.ExecuteReader();
            fgDanhMuc.Rows.Count = 1;
            fgDanhMuc.ClipSeparators = "|;";
            fgDanhMuc.AddItem("1|1|Thuốc|0");
            fgDanhMuc.AddItem("2|2|Xét nghiệm|0");
            fgDanhMuc.AddItem("3|3|Vật tư tiêu hao|0");
            while (dr.Read())
            {
                fgDanhMuc.AddItem(string.Format("{0}|{1}|{2}|0", fgDanhMuc.Rows.Count, dr["MaLoai"], dr["TenLoai"]));
            }
            dr.Close();
            int i = 0;
            SQLCmd.CommandText = "SELECT * FROM CONFIGS WHERE UName='" + Global.glbUName + "' AND ConfigName='LoaiChiPhi'";
            dr = SQLCmd.ExecuteReader();
            while (dr.Read())
            {
                for (i = 1; i < fgDanhMuc.Rows.Count; i++)
                {
                    if (fgDanhMuc[i, 1].ToString() == dr["ConfigValue"].ToString())
                    {
                        fgDanhMuc[i, 3] = dr["Chon"];
                    }
                }
            }
            dr.Close();
            SQLCmd.CommandText = "SELECT * FROM DMDOITUONGBN";
            dr = SQLCmd.ExecuteReader();
            cmbDoiTuong.Tag = "0";
            cmbDoiTuong.SelectedIndex = -1;
            while (dr.Read())
            {
                cmbDoiTuong.AddItem(string.Format("{0};{1}", dr["MaDT"], dr["TenDT"]));
            }
            dr.Close();
            cmbDoiTuong.SelectedIndex = -1;
            cmbDoiTuong.Tag = "1";
            
            SQLCmd.Dispose();
            SetGridHSBA();
            SetGridPreview();
            fgPreview.ContextMenuStrip = this.contextMenuStrip1;
        }

        private void cmdGhiChiTiet_Click(object sender, EventArgs e)
        {            
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            System.Data.SqlClient.SqlTransaction trn;
            trn = Global.ConnectSQL.BeginTransaction();
            SQLCmd.Transaction = trn;
            try
            {
                SQLCmd.CommandText = "DELETE FROM CONFIGS WHERE UName='" + lblUName.Text + "' AND ConfigName='LoaiChiPhi'";
                SQLCmd.ExecuteNonQuery();
                for (int i = 1; i < fgDanhMuc.Rows.Count; i++)
                {
                    SQLCmd.CommandText = string.Format("INSERT INTO CONFIGS (UName,ConfigName,ConfigValue,Chon) VALUES ('{0}','LoaiChiPhi',{1},{2})", lblUName.Text, fgDanhMuc[i, 1], (fgDanhMuc[i, 3].ToString().ToLower() == "true") ? (1) : (0));
                    SQLCmd.ExecuteNonQuery();
                }
                trn.Commit();
            }
            catch (Exception ex)
            {
                trn.Rollback();
                MessageBox.Show("Có lỗi khi ghi dữ liệu!\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;            
            }
            finally
            {
                SQLCmd.Dispose();
                trn.Dispose();
            }
        }
        private void SetGridHSBA()
        {
            fgHSBA.Cols[0].AllowEditing = false;
            fgHSBA.Cols[1].AllowEditing = false;
            fgHSBA.Cols[2].AllowEditing = false;
            fgHSBA.Rows.Count = 1;
            fgHSBA.ClipSeparators = "|;";
            fgHSBA.AddItem(string.Format("{0}|{1}|{2}",fgHSBA.Rows.Count,"cmbCapBac","Quân hàm"));
            fgHSBA.AddItem(string.Format("{0}|{1}|{2}", fgHSBA.Rows.Count, "txtChucVu", "Chức vụ"));
            fgHSBA.AddItem(string.Format("{0}|{1}|{2}", fgHSBA.Rows.Count, "cmbDonVi", "Đơn vị"));
            fgHSBA.AddItem(string.Format("{0}|{1}|{2}", fgHSBA.Rows.Count, "txtDiaChi", "Địa chỉ"));
            fgHSBA.AddItem(string.Format("{0}|{1}|{2}", fgHSBA.Rows.Count, "cmbTinh_TP", "Tỉnh, thành phố"));
            fgHSBA.AddItem(string.Format("{0}|{1}|{2}", fgHSBA.Rows.Count, "txtSoTheBHYT", "Số thẻ BHYT"));
            fgHSBA.AddItem(string.Format("{0}|{1}|{2}", fgHSBA.Rows.Count, "txtLienHe", "Địa chỉ liên hệ"));
            fgHSBA.AddItem(string.Format("{0}|{1}|{2}", fgHSBA.Rows.Count, "cmbHinhThucVV", "Hình thức vào viện"));
            fgHSBA.AddItem(string.Format("{0}|{1}|{2}", fgHSBA.Rows.Count, "txtICD_NoiChuyen", "Chẩn đoán nơi chuyển đến"));
            fgHSBA.AddItem(string.Format("{0}|{1}|{2}", fgHSBA.Rows.Count, "txtChanDoan_PK", "Triệu chứng khi vào viện"));
            fgHSBA.AddItem(string.Format("{0}|{1}|{2}", fgHSBA.Rows.Count, "txtICD_PK", "Chẩn đoán của KKB, cấp cứu"));            
            fgHSBA.Cols[1].Visible = false;
        }
        private void LoadOptionHSBA(string UName, string DoiTuong)
        {
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            SQLCmd.CommandText = "SELECT * FROM CONFIGS WHERE UName='" + UName + "' AND ConfigName='NhapHSBA' AND GhiChu='" + DoiTuong + "'";
            dr = SQLCmd.ExecuteReader();
            for (int i = 1; i < fgHSBA.Rows.Count; i++)
            {
                fgHSBA[i, 3] = "0";
            }
            while (dr.Read())
            {
                for (int i = 1; i < fgHSBA.Rows.Count; i++)
                {
                    if (fgHSBA[i, 1].ToString() == dr["ConfigValue"].ToString())
                    {
                        fgHSBA[i, 3] = dr["Chon"];
                    }
                }
            }
            dr.Close();
            SQLCmd.Dispose();
        }
        private void cnbGhiOptionHSBA_Click(object sender, EventArgs e)
        {
            if (cmbDoiTuong.SelectedIndex == -1)
            {
                MessageBox.Show("Phải chọn đối tượng bệnh nhân!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbDoiTuong.Focus();
                return;
            }
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            System.Data.SqlClient.SqlTransaction trn;
            trn = Global.ConnectSQL.BeginTransaction();
            SQLCmd.Transaction = trn;
            try
            {
                SQLCmd.CommandText = "DELETE FROM CONFIGS WHERE UName='" + lblUName.Text + "' AND ConfigName='NhapHSBA' AND GhiChu='" + Global.GetCode(cmbDoiTuong) + "'";
                SQLCmd.ExecuteNonQuery();
                for (int i = 1; i < fgHSBA.Rows.Count; i++)
                {
                    SQLCmd.CommandText = string.Format("INSERT INTO CONFIGS (UName,ConfigName,ConfigValue,Chon,GhiChu) VALUES ('{0}','NhapHSBA','{1}',{2},'{3}')", lblUName.Text, fgHSBA[i, 1], (fgHSBA[i, 3].ToString().ToLower() == "true") ? (1) : (0),Global.GetCode(cmbDoiTuong));
                    SQLCmd.ExecuteNonQuery();
                }
                trn.Commit();
            }
            catch (Exception ex)
            {
                trn.Rollback();
                MessageBox.Show("Có lỗi khi ghi dữ liệu!\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                SQLCmd.Dispose();
                trn.Dispose();
            }
        }

        private void cmbDoiTuong_TextChanged(object sender, EventArgs e)
        {
            if (cmbDoiTuong.Tag.ToString() == "0" || cmbDoiTuong.SelectedIndex == -1) { return; }
            LoadOptionHSBA(Global.glbUName, Global.GetCode(cmbDoiTuong));
        }        
        private void SetGridPreview()
        {
            
            fgPreview.ClipSeparators = "|;";
            fgPreview.Tree.Column = 4;
            fgPreview.AddItem("|Mức 1|Mức 2|Mức 3|Dữ liệu thử");
            fgPreview.AddItem("|Mức 1|Mức 2|Mức 3|Dữ liệu thử");
            fgPreview.AddItem("|Mức 1|Mức 2|Mức 3|Dữ liệu thử");
            fgPreview.AddItem("|Mức 1|Mức 2|Mức 3|Dữ liệu thử");
            fgPreview.AddItem("|Mức 1|Mức 2|Mức 3|Dữ liệu thử");
            fgPreview.AddItem("|Mức 1|Mức 2|Mức 3|Dữ liệu thử");
            fgPreview.Subtotal(AggregateEnum.Clear);
            fgPreview.Subtotal(AggregateEnum.Sum, 1, 1, 4, "{0}");
            fgPreview.Subtotal(AggregateEnum.Sum, 2, 2, 4, "{0}");
            fgPreview.Subtotal(AggregateEnum.Sum, 3, 3, 4, "{0}");
            fgPreview.Cols[1].Visible = fgPreview.Cols[2].Visible=fgPreview.Cols[3].Visible = false;
            Global.SetGridStyles(fgPreview);

        }

        private void simpleButton10_Click(object sender, EventArgs e)
        {
            Global.gStyleFixed = fgPreview.Styles.Fixed;
            Global.gStyleSubtotal1 = fgPreview.Styles["Subtotal1"];
            Global.gStyleSubtotal2 = fgPreview.Styles["Subtotal2"];
            Global.gStyleSubtotal3 = fgPreview.Styles["Subtotal3"];
            //Ghi du lieu vao database
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            System.Data.SqlClient.SqlTransaction trn;
            trn = Global.ConnectSQL.BeginTransaction();
            SQLCmd.Transaction = trn;
            CellStyle s = fgPreview.Styles.Fixed;
            try
            {
                SQLCmd.CommandText = string.Format("DELETE FROM CONFIGS WHERE UName='{0}' AND ConfigName IN ('Fixed','SubTotal1','SubTotal2','SubTotal3')", lblUName.Text);
                SQLCmd.ExecuteNonQuery();
                
                SQLCmd.CommandText = string.Format("INSERT INTO CONFIGS (Uname,ConfigName,GhiChu,ConfigValue) VALUES  ('{0}','{1}','BackColor',{2})", lblUName.Text,s.Name, s.BackColor.ToArgb());
                SQLCmd.CommandText += string.Format(" INSERT INTO CONFIGS (Uname,ConfigName,GhiChu,ConfigValue) VALUES  ('{0}','{1}','ForeColor',{2})", lblUName.Text, s.Name, s.ForeColor.ToArgb());
                SQLCmd.CommandText += string.Format(" INSERT INTO CONFIGS (Uname,ConfigName,GhiChu,ConfigValue) VALUES  ('{0}','{1}','FontName','{2}')", lblUName.Text, s.Name, s.Font.Name);
                SQLCmd.CommandText += string.Format(" INSERT INTO CONFIGS (Uname,ConfigName,GhiChu,ConfigValue) VALUES  ('{0}','{1}','FontSize',{2})", lblUName.Text, s.Name, Math.Round(s.Font.Size, 0));
                SQLCmd.CommandText += string.Format(" INSERT INTO CONFIGS (Uname,ConfigName,GhiChu,ConfigValue) VALUES  ('{0}','{1}','FontBold','{2}')", lblUName.Text, s.Name, s.Font.Bold.ToString());
                s = fgPreview.Styles["SubTotal1"];
                SQLCmd.CommandText += string.Format(" INSERT INTO CONFIGS (Uname,ConfigName,GhiChu,ConfigValue) VALUES  ('{0}','{1}','BackColor',{2})", lblUName.Text, s.Name, s.BackColor.ToArgb());
                SQLCmd.CommandText += string.Format(" INSERT INTO CONFIGS (Uname,ConfigName,GhiChu,ConfigValue) VALUES  ('{0}','{1}','ForeColor',{2})", lblUName.Text, s.Name, s.ForeColor.ToArgb());
                SQLCmd.CommandText += string.Format(" INSERT INTO CONFIGS (Uname,ConfigName,GhiChu,ConfigValue) VALUES  ('{0}','{1}','FontName','{2}')", lblUName.Text, s.Name, s.Font.Name);
                SQLCmd.CommandText += string.Format(" INSERT INTO CONFIGS (Uname,ConfigName,GhiChu,ConfigValue) VALUES  ('{0}','{1}','FontSize',{2})", lblUName.Text, s.Name, Math.Round(s.Font.Size, 0));
                SQLCmd.CommandText += string.Format(" INSERT INTO CONFIGS (Uname,ConfigName,GhiChu,ConfigValue) VALUES  ('{0}','{1}','FontBold','{2}')", lblUName.Text, s.Name, s.Font.Bold.ToString());
                s = fgPreview.Styles["SubTotal2"];
                SQLCmd.CommandText += string.Format(" INSERT INTO CONFIGS (Uname,ConfigName,GhiChu,ConfigValue) VALUES  ('{0}','{1}','BackColor',{2})", lblUName.Text, s.Name, s.BackColor.ToArgb());
                SQLCmd.CommandText += string.Format(" INSERT INTO CONFIGS (Uname,ConfigName,GhiChu,ConfigValue) VALUES  ('{0}','{1}','ForeColor',{2})", lblUName.Text, s.Name, s.ForeColor.ToArgb());
                SQLCmd.CommandText += string.Format(" INSERT INTO CONFIGS (Uname,ConfigName,GhiChu,ConfigValue) VALUES  ('{0}','{1}','FontName','{2}')", lblUName.Text, s.Name, s.Font.Name);
                SQLCmd.CommandText += string.Format(" INSERT INTO CONFIGS (Uname,ConfigName,GhiChu,ConfigValue) VALUES  ('{0}','{1}','FontSize',{2})", lblUName.Text, s.Name, Math.Round(s.Font.Size, 0));
                SQLCmd.CommandText += string.Format(" INSERT INTO CONFIGS (Uname,ConfigName,GhiChu,ConfigValue) VALUES  ('{0}','{1}','FontBold','{2}')", lblUName.Text, s.Name, s.Font.Bold.ToString());
                s = fgPreview.Styles["SubTotal3"];
                SQLCmd.CommandText += string.Format(" INSERT INTO CONFIGS (Uname,ConfigName,GhiChu,ConfigValue) VALUES  ('{0}','{1}','BackColor',{2})", lblUName.Text, s.Name, s.BackColor.ToArgb());
                SQLCmd.CommandText += string.Format(" INSERT INTO CONFIGS (Uname,ConfigName,GhiChu,ConfigValue) VALUES  ('{0}','{1}','ForeColor',{2})", lblUName.Text, s.Name, s.ForeColor.ToArgb());
                SQLCmd.CommandText += string.Format(" INSERT INTO CONFIGS (Uname,ConfigName,GhiChu,ConfigValue) VALUES  ('{0}','{1}','FontName','{2}')", lblUName.Text, s.Name, s.Font.Name);
                SQLCmd.CommandText += string.Format(" INSERT INTO CONFIGS (Uname,ConfigName,GhiChu,ConfigValue) VALUES  ('{0}','{1}','FontSize',{2})", lblUName.Text, s.Name, Math.Round(s.Font.Size, 0));
                SQLCmd.CommandText += string.Format(" INSERT INTO CONFIGS (Uname,ConfigName,GhiChu,ConfigValue) VALUES  ('{0}','{1}','FontBold','{2}')", lblUName.Text, s.Name, s.Font.Bold.ToString());
                
                SQLCmd.ExecuteNonQuery();                
                trn.Commit();
            }
            catch (Exception ex)
            {
                trn.Rollback();
                MessageBox.Show("Có lỗi khi ghi dữ liệu!\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SQLCmd.Dispose();
                trn.Dispose();
            }
        }

        private void fgPreview_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                mnuBackground.Enabled = false;
                mnuForeColor.Enabled = false;
                mnuFont.Enabled = false;                
                fgPreview.Row = fgPreview.MouseRow;                    
                if (fgPreview.Row == 0)
                {
                    mnuBackground.Enabled = true;
                    mnuForeColor.Enabled = true;
                    mnuFont.Enabled = true;
                    pStyle = fgPreview.Styles.Fixed;
                }
                else if (fgPreview.Row > 0 && fgPreview.Rows[fgPreview.Row].IsNode)
                {
                    mnuBackground.Enabled = true;
                    mnuForeColor.Enabled = true;
                    mnuFont.Enabled = true;
                    pStyle = fgPreview.Styles["Subtotal" + fgPreview.Rows[fgPreview.Row].Node.Level.ToString()];
                }                
            }
        }

        private void mnuBackground_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pStyle.BackColor = colorDialog1.Color;
            }            
        }

        private void mnuForeColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pStyle.ForeColor = colorDialog1.Color;
            }  
        }

        private void mnuFont_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                pStyle.Font = fontDialog1.Font;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Global.Load_GridConfig("Admin");
            Global.SetGridStyles(fgPreview);
        }
    }
}