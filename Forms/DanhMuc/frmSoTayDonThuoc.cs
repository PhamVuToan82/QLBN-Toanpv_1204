﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GlobalModuls;

namespace NamDinh_QLBN.Forms.DanhMuc
{
    public partial class frmSoTayDonThuoc : Form
    {
        private bool Add = false;
        public frmSoTayDonThuoc()
        {
            InitializeComponent();
        }

        private void LoatDanhMuc()
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
                    cmbKhoa.AddItem(string.Format("{0};{1}", dr["MaKhoa"], dr["TenKhoa"]));
                }
                cmbKhoa.SelectedIndex = 0;
                dr.Close();
                cmbKhoa.Tag = "1";
            }
            catch
            {
            }
            finally
            {
                SQLCmd.Dispose();
            }
        }

        private void ChonThuoc()
        {
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            try
            {
                SQLCmd.CommandText = String.Format("if(exists(select * from tblSoTayDonThuoc_CT where id_sotaydonthuoc = {0} and mathuoc = '{1}'))"
                    + " update tblSoTayDonThuoc_CT set soluong = {2} where id_sotaydonthuoc = {0} and mathuoc = '{1}'"
                    + " else"
                    + " insert into tblSoTayDonThuoc_CT(id_sotaydonthuoc,MaThuoc,SoLuong,LoaiDichVu, Is_tinhphi) values({0},'{1}',{2},'{3}',{4})",
                    fgDonThuoc.GetDataDisplay(fgDonThuoc.Row, "id"),
                    fgdmThuoc.GetDataDisplay(1, "MaDichVu"),
                    txtSoLuong.Value,
                    fgdmThuoc.GetDataDisplay(1, "LoaiDichVu"),
                    fgdmThuoc.GetDataDisplay(1, "Is_tinhphi"));
                SQLCmd.ExecuteNonQuery();
                LoatDonThuocCT();
                txtTenDV.Focus();
            }
            catch
            {
            }
            finally
            {
                SQLCmd.Dispose();
            }
        }

        private void LoatDSThuoc(String Key)
        {
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            try
            {
                SQLCmd.CommandText = "Select dmdichvu.madichvu,dmdichvu.tendichvu,dmdichvu.dvt,dmdichvu.loaidichvu,dmdichvu.is_Tinhphi from DMLENCHIPHI_BYKHOID as dmdichvu ";
                if (raThuoc.Checked)
                {
                    SQLCmd.CommandText += String.Format(" where loaidichvu ='d01' and dmdichvu.khongsudung = 0  and tendichvu like N'{0}%'", Key);
                }
                else
                {
                    SQLCmd.CommandText += String.Format(" inner join vattu on vattu.makhoa ='{0}' and vattu.machiphi = dmdichvu.madichvu and dmdichvu.tendichvu like N'{1}%'",
                        Global.GetCode(cmbKhoa), Key);
                }

                dr = SQLCmd.ExecuteReader();
                fgdmThuoc.ClipSeparators = "|;";
                fgdmThuoc.Rows.Count = 1;
                while (dr.Read())
                {
                    fgdmThuoc.AddItem(String.Format("{0}|{1}|{2}|{3}|{4}|{5}", fgdmThuoc.Rows.Count, dr["MaDichVu"], dr["TenDichVu"], dr["DVT"],dr["LoaiDichVu"], dr["is_Tinhphi"]));   
                }
                if (fgdmThuoc.Rows.Count > 1)
                {
                    fgdmThuoc.Select(1, fgdmThuoc.Cols["TenDichVu"].Index);
                    fgdmThuoc.Visible = true;
                }
                else
                {
                    fgdmThuoc.Visible = false;
                }
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

        private void LoatDonThuoc()
        {
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            try
            {
                SQLCmd.CommandText = String.Format(" select * from tblSoTayDonThuoc where makhoa = '{0}'", GlobalModuls.Global.GetCode(cmbKhoa));
                dr = SQLCmd.ExecuteReader();
                fgDonThuoc.Rows.Count = 1;
                while (dr.Read())
                {
                    fgDonThuoc.Rows.Add();
                    fgDonThuoc[fgDonThuoc.Rows.Count - 1, "STT"] = fgDonThuoc.Rows.Count - 1;
                    fgDonThuoc[fgDonThuoc.Rows.Count - 1, "ID"] = dr["id_sotaydonthuoc"];
                    fgDonThuoc[fgDonThuoc.Rows.Count - 1, "Ten"] = dr["MatBenh"];
                }
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

        private void LoatDonThuocCT()
        {
            C1.Win.C1FlexGrid.CellStyle cs = fgThuoc.Styles[C1.Win.C1FlexGrid.CellStyleEnum.Subtotal0];
            cs.BackColor = Color.LightBlue;
            cs.ForeColor = Color.DarkBlue;
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            try
            {
                fgThuoc.Redraw = false;
                fgThuoc.Tree.Column = fgThuoc.Cols["TenDichVu"].Index;
                SQLCmd.CommandText = String.Format("Select distinct dmloaidichvu.TenLoaiDichvu,dmdichvu.madichvu, dmdichvu.tendichvu,dmdichvu.dvt,tblSoTayDonThuoc_CT.SoLuong,dmdichvu.Is_tinhphi from tblsotaydonthuoc_ct "
                    + " inner join DMLENCHIPHI_BYKHOID dmdichvu on dmdichvu.madichvu = tblsotaydonthuoc_ct.mathuoc and dmdichvu.khongsudung = 0 "
                    + " inner join dmloaidichvu on dmloaidichvu.maloaidichvu = tblsotaydonthuoc_ct.loaidichvu "
                    + " where tblsotaydonthuoc_ct.id_SoTayDonThuoc = {0}", fgDonThuoc.GetDataDisplay(fgDonThuoc.Row, "id"));
                dr = SQLCmd.ExecuteReader();
                fgThuoc.Rows.Count = 1;
                fgThuoc.ClipSeparators = "|;";
                while (dr.Read())
                {
                    fgThuoc.AddItem(String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}", fgThuoc.Rows.Count,
                        dr["TenLoaiDichVu"],
                        dr["madichvu"],
                        dr["tendichvu"],
                        dr["dvt"],
                        dr["soluong"],
                        dr["Is_tinhphi"]));
                }
                dr.Close();
                fgThuoc.Redraw = true;
                fgThuoc.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.Clear, 0, 0, 0);
                fgThuoc.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.None, 0, 1, 0, "{0}");
                fgThuoc.AutoSizeCols(0);
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
            cmdCancel.Visible = cmdOK.Visible = Flag;
            cmdChon.Visible = cmdSua.Visible = cmdThem.Visible = cmdXoa.Visible = !Flag;
            txtSoLuong.Enabled = txtTenDV.Enabled = !Flag;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSoTayDonThuoc_Load(object sender, EventArgs e)
        {
            fgDonThuoc.Tag = 0;
            fgThuoc.Tag = 0;
            LoatDanhMuc();
            LoatDonThuoc();
            AllowEdit(false);
            fgDonThuoc.Tag = 1;
            fgThuoc.Tag = 1;
            LoatDonThuocCT();
        }

        private void cmdThem_Click(object sender, EventArgs e)
        {
            AllowEdit(true);
            Add = true;
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            AllowEdit(false);
            txtTenDonThuoc.Text = "";
            Add = false;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdSua_Click(object sender, EventArgs e)
        {
            if (fgDonThuoc.Rows.Count <= 1)
                return;
            txtTenDonThuoc.Text = fgDonThuoc.GetDataDisplay(fgDonThuoc.Row, "Ten");
            AllowEdit(true);
            Add = false;
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            try
            {
                if (Add)
                {
                    SQLCmd.CommandText = String.Format("Insert into tblSoTayDonThuoc(MaKhoa,MatBenh) values('{0}',N'{1}')",
                        Global.GetCode(cmbKhoa),
                        txtTenDonThuoc.Text.Trim());
                }
                else
                {
                    SQLCmd.CommandText = String.Format("update tblSoTayDonThuoc set MatBenh=N'{0}' where id_sotaydonthuoc= {1}",
                        txtTenDonThuoc.Text.Trim(),fgDonThuoc.GetDataDisplay(fgDonThuoc.Row,"id"));
                }
                SQLCmd.ExecuteNonQuery();
                fgDonThuoc.Tag = 0;
                LoatDonThuoc();
                AllowEdit(false);
                fgDonThuoc.Tag = 1;
            }
            catch
            {
            }
            finally
            {
                Add = false;
                SQLCmd.Dispose();
            }
        }

        private void txtTenDV_TextChanged(object sender, EventArgs e)
        {
            if (fgDonThuoc.Rows.Count < 1)
            {
                MessageBox.Show("Thêm mặt bệnh...", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (fgDonThuoc.Row < 0)
            {
                MessageBox.Show("Hảy chọn mặt bệnh..", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            fgdmThuoc.Tag = 0;
            LoatDSThuoc(txtTenDV.Text);
            fgdmThuoc.Tag = 1;
        }

        private void fgdmThuoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (fgdmThuoc.Rows.Count <= 1) return;
            if (e.KeyCode == Keys.Enter)
            {
                txtTenDV.Text = fgdmThuoc.GetDataDisplay(fgdmThuoc.Row, "TenDichVu");
                fgdmThuoc.Visible = false;
                txtSoLuong.Focus();
            }
            if (e.KeyCode == Keys.Escape)
            {
                fgdmThuoc.Visible = false;
            }
        }

        private void frmSoTayDonThuoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                ChonThuoc();
            }
        }

        private void cmdChon_Click(object sender, EventArgs e)
        {
            ChonThuoc();
            fgdmThuoc.Visible = false;
        }

        private void fgDonThuoc_AfterRowColChange(object sender, C1.Win.C1FlexGrid.RangeEventArgs e)
        {
            if (fgDonThuoc.Tag.ToString() == "0") return;
            LoatDonThuocCT();
        }

        private void fgdmThuoc_AfterRowColChange(object sender, C1.Win.C1FlexGrid.RangeEventArgs e)
        {
        }

        private void cmdXoa_Click(object sender, EventArgs e)
        {
            if (fgDonThuoc.Rows.Count < 1) return;
            if (fgDonThuoc.Row < 0) return;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            try
            {
                if (MessageBox.Show("Bạn có muốn xóa không.", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No) return;
                SQLCmd.CommandText = " delete from tblSoTayDonThuoc where ID_SoTayDonThuoc = " + fgDonThuoc.GetDataDisplay(fgDonThuoc.Row, "id");
                SQLCmd.ExecuteNonQuery();
                fgDonThuoc.Tag = 0;
                LoatDonThuoc();
                fgDonThuoc.Tag = 1;
            }
            catch
            {
            }
            finally
            {
                SQLCmd.Dispose();
            }
        }

        private void fgThuoc_BeforeDeleteRow(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            if (fgDonThuoc.Row < 0)
            {
                MessageBox.Show("Hảy chọn mặt bệnh..", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (fgThuoc.Rows.Count < 1) return;
            try
            {
                fgThuoc.Redraw = true;
                if (MessageBox.Show("Bạn có muốn xóa không ... ", "Thông báo.", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
                    SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
                    SQLCmd.CommandText = String.Format("delete from tblSoTayDonThuoc_CT where id_SoTayDonThuoc ={0} and MaThuoc='{1}'",
                        fgDonThuoc.GetDataDisplay(fgDonThuoc.Row, "id"),
                        fgThuoc.GetDataDisplay(fgThuoc.Row, "MaDichVU"));
                    SQLCmd.ExecuteNonQuery();
                }
                else
                {
                    e.Cancel = true;
                }
            }
            catch
            {
            }
            finally
            {
            }
        }

        private void fgThuoc_AfterDeleteRow(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            fgThuoc.Tag = 0;
            LoatDonThuocCT();
            fgThuoc.Tag = 1;
        }

        private void txtTenDV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                if (fgdmThuoc.Visible == true)
                {
                    fgdmThuoc.Focus();
                }
            }
            if (e.KeyCode == Keys.Escape)
            {
                fgdmThuoc.Visible = false;
            }
        }

        private void fgdmThuoc_DoubleClick(object sender, EventArgs e)
        {
            if (fgdmThuoc.Rows.Count <= 1) return;
            txtTenDV.Text = fgdmThuoc.GetDataDisplay(fgdmThuoc.Row, "TenDichVu");
            fgdmThuoc.Visible = false;
            txtSoLuong.Focus();
        }
    }
}