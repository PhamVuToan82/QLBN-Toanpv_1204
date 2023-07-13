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
    public partial class frmDatChiPhi_Khoa : Form
    {
        public frmDatChiPhi_Khoa()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void Load_CacDM()
        {
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            SQLCmd.CommandText = "SELECT * FROM DMKHOAPHONG WHERE MaKhoa IN " + Global.glbKhoa_CapNhat;
            dr = SQLCmd.ExecuteReader();
            cmbKhoa.Tag = "0";
            cmbKhoa.ClearItems();
            while (dr.Read())
            {
                cmbKhoa.AddItem(string.Format("{0};{1}", dr["MaKhoa"], dr["TenKhoa"]));
            }
            dr.Close();
            cmbKhoa.SelectedIndex = -1;
            if (cmbKhoa.ListCount > 0) cmbKhoa.SelectedIndex = 0;

            SQLCmd.CommandText = "SELECT * FROM DMLOAIDICHVU WHERE NoiTru_NgoaiTru = 1 OR NoiTru_NgoaiTru = 3";
            dr = SQLCmd.ExecuteReader();
            fgLoaiDichVu.Rows.Count = 1;
            while (dr.Read())
            {
                fgLoaiDichVu.AddItem(string.Format("{0}|{1}|{2}|0", fgLoaiDichVu.Rows.Count, dr["MaLoaiDichVu"], dr["TenLoaiDichVu"]));
            }
            dr.Close();
            SQLCmd.Dispose();
            cmbKhoa.Tag = "1";
        }

        private void frmDatChiPhi_Khoa_Load(object sender, EventArgs e)
        {
            fgLoaiDichVu.ClipSeparators = "|;";
            fgLoaiDichVu.Cols[1].AllowEditing = fgLoaiDichVu.Cols[2].AllowEditing = false;
            Load_CacDM();
            cmbKhoa_TextChanged(sender, e);
        }

        private void cmbKhoa_TextChanged(object sender, EventArgs e)
        {
            if (cmbKhoa.Tag.ToString() == "0" || cmbKhoa.SelectedIndex == -1) return;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
            SQLCmd.CommandText = "SELECT * FROM KHOA_LOAIDICHVU WHERE MaKhoa='" + Global.GetCode(cmbKhoa) +"'";
            System.Data.SqlClient.SqlDataReader dr = SQLCmd.ExecuteReader();
            for (int i = 1; i < fgLoaiDichVu.Rows.Count; i++)
            {
                fgLoaiDichVu[i, "Chon"] = 0;
            }
            while (dr.Read())
            {
                for (int i = 1; i < fgLoaiDichVu.Rows.Count; i++)
                {
                    if (fgLoaiDichVu[i, "LoaiDichVu"].ToString() == dr["LoaiDichVu"].ToString()) fgLoaiDichVu[i, "Chon"] = 1;
                }
            }
            dr.Close();
            SQLCmd.CommandText = "SELECT a.* FROM DMLOAIDICHVU a INNER JOIN KHOA_LOAIDICHVU b ON a.MaLoaiDichVu=b.LoaiDichVu WHERE (NoiTru_NgoaiTru = 1 OR NoiTru_NgoaiTru = 3) AND b.MaKhoa='" + Global.GetCode(cmbKhoa) + "'";
            dr = SQLCmd.ExecuteReader();
            cmbLoaiDichVu.Tag = "0";
            cmbLoaiDichVu.ClearItems();
            while (dr.Read())
            {
                cmbLoaiDichVu.AddItem(string.Format("{0};{1}", dr["MaLoaiDichVu"], dr["TenLoaiDichVu"]));
            }
            cmbLoaiDichVu.SelectedIndex = -1;
            dr.Close();
            SQLCmd.Dispose();
            cmbLoaiDichVu.Tag = "1";
        }

        private void cmdGhiLoaiDichVu_Click(object sender, EventArgs e)
        {
            if (cmbKhoa.SelectedIndex==-1) return;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
            System.Data.SqlClient.SqlTransaction trn = Global.ConnectSQL.BeginTransaction();
            SQLCmd.Transaction = trn;
            string MaKhoa=Global.GetCode(cmbKhoa);
            try
            {
                SQLCmd.CommandText = "DELETE FROM KHOA_LOAIDICHVU WHERE MaKhoa='" + MaKhoa  + "'";
                SQLCmd.ExecuteNonQuery();
                for (int i=1;i<fgLoaiDichVu.Rows.Count;i++)
                    if (fgLoaiDichVu.GetCellCheck(i, fgLoaiDichVu.Cols["Chon"].Index) == C1.Win.C1FlexGrid.CheckEnum.Checked)
                    {
                        SQLCmd.CommandText =string.Format("INSERT INTO KHOA_LOAIDICHVU (MaKhoa,LoaiDichVu) VALUES ('{0}','{1}')",MaKhoa,fgLoaiDichVu[i,"LoaiDichVu"]);
                        SQLCmd.ExecuteNonQuery();
                    }
                trn.Commit();
            }
            catch (Exception ex)
            {
                trn.Rollback();
                MessageBox.Show("Có lỗi khi ghi dữ liệu\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SQLCmd.Dispose();
                trn.Dispose();
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbKhoa.SelectedIndex == -1) return;
            if (tabControl1.SelectedIndex == 1)
            {
                string MaKhoa = Global.GetCode(cmbKhoa);
                System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
                SQLCmd.CommandText = "SELECT a.* FROM DMLOAIDICHVU a INNER JOIN KHOA_LOAIDICHVU b ON a.MaLoaiDichVu=b.LoaiDichVu WHERE (NoiTru_NgoaiTru = 1 OR NoiTru_NgoaiTru = 3) AND b.MaKhoa='" + MaKhoa + "'";
                System.Data.SqlClient.SqlDataReader dr = SQLCmd.ExecuteReader();
                cmbLoaiDichVu.Tag = "0";
                cmbLoaiDichVu.ClearItems();
                while (dr.Read())
                {
                    cmbLoaiDichVu.AddItem(string.Format("{0};{1}", dr["MaLoaiDichVu"], dr["TenLoaiDichVu"]));
                }
                cmbLoaiDichVu.SelectedIndex = -1;
                dr.Close();
                SQLCmd.Dispose();
                cmbLoaiDichVu.Tag = "1";
            }
        }

        private void cmbLoaiDichVu_TextChanged(object sender, EventArgs e)
        {
            if (cmbLoaiDichVu.Tag.ToString() == "0" || cmbLoaiDichVu.SelectedIndex == -1) return;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
            SQLCmd.CommandText = "select a.MaDichVu As [Mã],TenDichVu as [Tên dịch vụ],CASE WHEN b.MaDichVu is null Then 0 ELSE 1 END as [Chọn] FROM DMDICHVU a Left Join KHOA_DICHVU b ON a.MaDichVu=b.MaDichVu AND a.LoaiDichVu=b.LoaiDIchVu and b.makhoa ='" + Global.GetCode(cmbKhoa) +"' WHERE a.LoaiDichVu='" + Global.GetCode(cmbLoaiDichVu) + "' and a.KhongSuDung=0";
            System.Data.SqlClient.SqlDataReader dr = SQLCmd.ExecuteReader();
            Global.BindDataReaderToFlex(dr, fgDichVu);
            fgDichVu.Cols[3].DataType = typeof(bool);
            dr.Close();
            SQLCmd.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cmbKhoa.SelectedIndex == -1 || cmbLoaiDichVu.SelectedIndex == -1) return;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
            System.Data.SqlClient.SqlTransaction trn = Global.ConnectSQL.BeginTransaction();
            SQLCmd.Transaction = trn;
            string MaKhoa = Global.GetCode(cmbKhoa);
            string LoaiDichVu = Global.GetCode(cmbLoaiDichVu);
            try
            {
                SQLCmd.CommandText = "DELETE FROM KHOA_DICHVU WHERE MaKhoa='" + MaKhoa + "' AND LoaiDichVu='" + LoaiDichVu + "'";
                SQLCmd.ExecuteNonQuery();
                for (int i = 1; i < fgDichVu.Rows.Count; i++)
                    if (fgDichVu.GetCellCheck(i,3) == C1.Win.C1FlexGrid.CheckEnum.Checked)
                    {
                        SQLCmd.CommandText = string.Format("INSERT INTO KHOA_DICHVU (MaKhoa,LoaiDichVu,MaDichVu) VALUES ('{0}','{1}','{2}')", MaKhoa,LoaiDichVu, fgDichVu[i,1]);
                        SQLCmd.ExecuteNonQuery();
                    }
                trn.Commit();
                MessageBox.Show("Cập nhật thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                trn.Rollback();
                MessageBox.Show("Có lỗi khi ghi dữ liệu\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SQLCmd.Dispose();
                trn.Dispose();
            }
        }
    }
}