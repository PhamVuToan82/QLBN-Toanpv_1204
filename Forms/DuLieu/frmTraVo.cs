using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GlobalModuls;

namespace NamDinh_QLBN.Forms.DuLieu
{
    public partial class frmTraVo : Form
    {
        private Boolean Add = false;
        public frmTraVo()
        {
            InitializeComponent();
        }

        private void LoatDM()
        {
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            try
            {
                SQLCmd.CommandText = "SELECT * FROM DMKHOAPHONG WHERE MaKhoa IN " + Global.glbKhoa_CapNhat;
                dr = SQLCmd.ExecuteReader();
                cmbKhoa.Tag = "0";
                cmbKhoa.ClearItems();
                while (dr.Read())
                {
                    cmbKhoa.AddItem(string.Format("{0};{1}", dr["TenKhoa"], dr["MaKhoa"]));
                }
                cmbKhoa.SelectedIndex = 0;
                dr.Close();
            }
            catch
            {
            }
            finally
            {
                SQLCmd.Dispose();
            }
        }

        private void AllowEdit(bool Flag)
        {
            cmdGhi.Visible = cmbKhongGhi.Visible = Flag;
            cmdSua.Visible = cmdThem.Visible = cmdThoat.Visible = !Flag;
            cmbKhoa.Enabled = !Flag;
            fgDanhSach.Cols["SoVoHoan"].AllowEditing = Flag;
        }

        private void LoatData()
        {
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            fgDanhSach.Rows.Count = 1;
            try
            {
                Global.wait("Đang tổng hợp dữ liệu ...");
                SQLCmd.CommandText = String.Format("select aa.makhoa,aa.soluongdsd,aa.soluongdt,dm.* from"
                    + " (select * from benhnhan_travo where makhoa='{0}') aa"
                    + " inner join dmdichvu dm on dm.madichvu = aa.mathuoc",cmbKhoa.Columns[1].CellText(cmbKhoa.SelectedIndex));
                dr = SQLCmd.ExecuteReader();
                while (dr.Read())
                {
                    fgDanhSach.Rows.Add();
                    fgDanhSach[fgDanhSach.Rows.Count - 1, 0] = fgDanhSach.Rows.Count - 1;
                    fgDanhSach[fgDanhSach.Rows.Count - 1, "MaDichVu"] = dr["MaDichVu"];
                    fgDanhSach[fgDanhSach.Rows.Count - 1, "TenDichVu"] = dr["TenDichVu"];
                    fgDanhSach[fgDanhSach.Rows.Count - 1, "DVT"] = dr["DVT"];
                    fgDanhSach[fgDanhSach.Rows.Count - 1, "SoLuongDSD"] = dr["SoLuongDSD"];
                    fgDanhSach[fgDanhSach.Rows.Count - 1, "SoVoDHT"] = dr["SoLuongdt"];
                    fgDanhSach[fgDanhSach.Rows.Count - 1, "SoVoHoan"] = 0;
                }
                dr.Close();
                fgDanhSach.AutoSizeCols(0);
            }
            catch
            {
                Global.nowait();
            }
            finally
            {
                Add = false;
                Global.nowait();
                SQLCmd.Dispose();
            }
        }

        private void cmdThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTraVo_Load(object sender, EventArgs e)
        {
            fgDanhSach.Tag = 0;
            AllowEdit(false);
            txtTuNgay.Value = Global.NgayLV;
            LoatDM();
            LoatData();
            fgDanhSach.Tag = 1;
        }

        private void GhiData()
        {
            if (fgDanhSach.Rows.Count <= 1) return;
            for (int i = 1; i < fgDanhSach.Rows.Count; i++)
            {
                if (decimal.Parse(fgDanhSach.GetDataDisplay(i, "SoVoHoan")) < 0)
                {
                    MessageBox.Show("Số lượng không hợp lệ.", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fgDanhSach.Focus();
                    fgDanhSach.Select(i, fgDanhSach.Cols["SoVoHoan"].Index);
                    return;
                }
                if (Add)
                {
                    if (decimal.Parse(fgDanhSach.GetDataDisplay(i, "SoLuongDSD")) < decimal.Parse(fgDanhSach.GetDataDisplay(i, "SoVoHoan")))
                    {
                        MessageBox.Show("Số lượng không hợp lệ.", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        fgDanhSach.Focus();
                        fgDanhSach.Select(i, fgDanhSach.Cols["SoVoHoan"].Index);
                        return;
                    }
                }
                else
                {
                    if ((decimal.Parse(fgDanhSach.GetDataDisplay(i, "SoLuongDSD")) - decimal.Parse(fgDanhSach.GetDataDisplay(i, "SoVoHoan")) + decimal.Parse(fgDanhSach.GetDataDisplay(i, "SoVoDHT"))) < 0)
                    {
                        MessageBox.Show("Số lượng không hợp lệ.", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        fgDanhSach.Focus();
                        fgDanhSach.Select(i, fgDanhSach.Cols["SoVoHoan"].Index);
                        return;
                    }
                }
                
            }
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            System.Data.SqlClient.SqlTransaction tra;
            tra = Global.ConnectSQL.BeginTransaction();
            SQLCmd.Transaction = tra;
            try
            {
                Global.wait("Đang tông hợp dữ liệu...");
                if (Add)
                {
                    for (int i = 1; i < fgDanhSach.Rows.Count; i++)
                    {
                        SQLCmd.CommandText += String.Format(" update benhnhan_travo set soluongdt={0},SoLuongDSD={3} where makhoa='{2}' and MaThuoc='{1}'",
                            decimal.Parse(fgDanhSach.GetDataDisplay(i, "SoVoHoan")).ToString().Replace(",","."),
                            fgDanhSach.GetDataDisplay(i, "MaDichVu"),
                            cmbKhoa.Columns[1].CellText(cmbKhoa.SelectedIndex),
                            ((decimal.Parse(fgDanhSach.GetDataDisplay(i, "SoLuongDSD")) - decimal.Parse(fgDanhSach.GetDataDisplay(i, "SoVoHoan")))).ToString().Replace(",","."));
                    }
                }
                else
                {
                    for (int i = 1; i < fgDanhSach.Rows.Count; i++)
                    {
                        SQLCmd.CommandText += String.Format(" update benhnhan_travo set soluongdt={0},SoLuongDSD={3} where makhoa='{2}' and MaThuoc='{1}'",
                            fgDanhSach.GetDataDisplay(i, "SoVoHoan").Replace(",","."),
                            fgDanhSach.GetDataDisplay(i, "MaDichVu").Replace(",", "."),
                            cmbKhoa.Columns[1].CellText(cmbKhoa.SelectedIndex),
                            ((decimal.Parse(fgDanhSach.GetDataDisplay(i, "SoLuongDSD")) - decimal.Parse(fgDanhSach.GetDataDisplay(i, "SoVoHoan")) + decimal.Parse(fgDanhSach.GetDataDisplay(i, "SoVoDHT")))).ToString().Replace(",", "."));
                    }
                }
                
                SQLCmd.ExecuteNonQuery();
                tra.Commit();
                fgDanhSach.Tag = 0;
                LoatData();
                AllowEdit(false);
                fgDanhSach.Tag = 1;
            }
            catch (Exception ex)
            {
                tra.Rollback();
                Global.nowait();
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                Global.nowait();
                SQLCmd.Dispose();
            }
        }

        private void cmdGhi_Click(object sender, EventArgs e)
        {
            GhiData();
        }

        private void cmbKhongGhi_Click(object sender, EventArgs e)
        {
            fgDanhSach.Tag = 0;
            LoatData();
            AllowEdit(false);
            fgDanhSach.Tag = 1;
        }

        private void frmTraVo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                GhiData();
            }
            if (e.KeyCode == Keys.F4)
            {
                fgDanhSach.Tag = 0;
                LoatData();
                fgDanhSach.Tag = 1;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (fgDanhSach.Rows.Count <= 1) return;
            NamDinh_QLBN.Reports.rptPhieuTraVo rpt = new NamDinh_QLBN.Reports.rptPhieuTraVo(cmbKhoa.Text, txtTuNgay.Value, cmbKhoa.Columns[1].CellText(cmbKhoa.SelectedIndex));
            rpt.Show();
        }

        private void cmdSua_Click(object sender, EventArgs e)
        {
            if (fgDanhSach.Rows.Count <= 1) return;
            AllowEdit(true);
            fgDanhSach.Focus();
            fgDanhSach.Select(fgDanhSach.Row, fgDanhSach.Cols["SoVoHoan"].Index);
            for (int i = 1; i < fgDanhSach.Rows.Count; i++)
            {
                fgDanhSach[i, "SoVoHoan"] = fgDanhSach[i, "SoVoDHT"];
            }
            Add = false;
        }

        private void cmdThem_Click(object sender, EventArgs e)
        {
            if (fgDanhSach.Rows.Count <= 1) return;
            AllowEdit(true);
            fgDanhSach.Focus();
            fgDanhSach.Select(fgDanhSach.Row, fgDanhSach.Cols["SoVoHoan"].Index);
            Add = true;
        }
    }
}