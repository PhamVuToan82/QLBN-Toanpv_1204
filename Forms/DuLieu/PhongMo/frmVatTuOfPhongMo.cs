using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using GlobalModuls;

namespace NamDinh_QLBN.Forms.DuLieu.PhongMo
{
    public partial class frmVatTuOfPhongMo : Form
    {
        public frmVatTuOfPhongMo()
        {
            InitializeComponent();
        }

        private void AllowEdit(bool Flag)
        {
            cmdChot.Enabled = !Flag;
            cmdGhi.Visible = Flag;
            cmbKhongGhi.Visible = Flag;
            cmdSua.Visible = !Flag;
            cmdChonVT.Enabled = Flag;
            cmdThoat.Visible = !Flag;
            fg.AllowDelete = Flag;
            fg.AllowEditing = Flag;
            cmbVatTu.Enabled = Flag;
            cmdInPhieuLinh.Enabled = !Flag;
            cmdInPhieuLinh.Enabled = !Flag;
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

                SQLCmd.CommandText = "select * from dmdichvu where loaidichvu in ('D02','D06') order by tendichvu";
                dr = SQLCmd.ExecuteReader();
                cmbVatTu.AddItemSeparator = '|';
                while (dr.Read())
                {
                    cmbVatTu.AddItem(String.Format("{0}|{1}|{2}|{3}",
                         dr["TenDichVu"],
                         dr["DVT"],
                         dr["MaDichVu"],
                         dr["LoaiDichVu"]));
                }
                dr.Close();
                string strcmb = "0-In trên sổ y lệnh|1-Không in";
                fg.Cols["isVatTu"].ComboList = strcmb;
            }
            catch
            {
            }
            finally
            {
                SQLCmd.Dispose();
            }
        }

        private void LoatData()
        {
            String Str = "";
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            try
            {
                fg.Redraw = false;
                Str = String.Format("SELECT BB.*,ISNULL(EE.SOLUONGDSD2,0) AS SOLUONGDSD FROM"
                    + " (SELECT VATTU.MACHIPHI,VATTU.MAKHOA,SUM(VATTU.SOLUONGDK) AS SOLUONGDK,SUM(VATTU.SOLUONGTK) "
                    + " AS SOLUONGTK,A.tendichvu,A.dvt,CASE WHEN VATTU.ISVATTU = 0 THEN N'0-In trên sổ y lệnh' ELSE N'1-Không in' END AS ISVATTU FROM VATTU"
                    + " INNER JOIN dmdichvu A ON A.madichvu = VATTU.MACHIPHI WHERE VATTU.MAKHOA ='{0}'"
                    + " GROUP BY MAKHOA,MACHIPHI,A.tendichvu,A.DVT,VATTU.ISVATTU) BB"
                    + " LEFT JOIN "
                    + " (SELECT SUM(SOLUONG) AS SOLUONGDSD2,MADICHVU AS MADICHVU FROM BENHNHAN_PT_CHIPHI WHERE CHOT = 0 AND DATEDIFF(DD,NGAYCHIDINH,'{1:MM/dd/yyyy}') >= 0 GROUP BY MADICHVU ) EE"
                    + " ON EE.MADICHVU = BB.MACHIPHI", Global.GetCode(cmbKhoa),txtNgayChot.Value);
                SQLCmd.CommandText = Str;
                dr = SQLCmd.ExecuteReader();
                fg.Rows.Fixed = 0;
                fg.Rows.Count = 1;
                fg.Rows.Fixed = 1;
                while (dr.Read())
                {
                    fg.Rows.Add();
                    fg[fg.Rows.Count - 1, "STT"] = fg.Rows.Count-1;
                    fg[fg.Rows.Count - 1, "MaVT"] = dr["MaChiPhi"];
                    fg[fg.Rows.Count - 1, "TenVT"] = dr["Tendichvu"];
                    fg[fg.Rows.Count - 1, "DVT"] = dr["dvt"];
                    fg[fg.Rows.Count - 1, "SoLuongDK"] = dr["SoLuongDK"];
                    fg[fg.Rows.Count - 1, "SoLuongTK"] = dr["SoLuongTK"];
                    fg[fg.Rows.Count - 1, "TongSL"] = decimal.Parse(dr["SoLuongDK"].ToString()) + decimal.Parse(dr["SoLuongTK"].ToString()) - decimal.Parse(dr["SoLuongDSD"].ToString());
                    fg[fg.Rows.Count - 1, "SoLuongDSD"] = dr["SoLuongDSD"];
                    fg[fg.Rows.Count - 1, "IsVatTu"] = dr["IsVatTu"];
                }
                dr.Close();

                Str = String.Format("Select max(NgayChot) as NgayChot from VetVatTu where makhoa ='{0}'", 
                    Global.GetCode(cmbKhoa));
                SQLCmd.CommandText = Str;
                dr = SQLCmd.ExecuteReader();
                txtNgayChot.ReadOnly = false;
                cmdChot.Text = "Chốt";
                cmdPrint.Enabled = false;
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        if (dr["NgayChot"].ToString() == "") continue;
                        DateTime NgayChot = DateTime.Parse(dr["NgayChot"].ToString());
                        DateTime NgayChot1 = DateTime.Parse(txtNgayChot.Value.ToString());
                        System.TimeSpan NgayDT = NgayChot - NgayChot1;
                        if (NgayDT.Days >= 0)
                        {
                            txtNgayChot.ReadOnly = true;
                            cmdChot.Text = "Hủy chốt";
                            cmdPrint.Enabled = true;
                        }
                    }
                }
                dr.Close();
            }
            catch(Exception e)
            {
                MessageBox.Show("Lỗi: " + e.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                fg.Redraw = true;
                SQLCmd.Dispose();
            }
        }

        private void frmVatTu_Load(object sender, EventArgs e)
        {
            Global.wait("Đang tổng hợp dữ liệu.");
            fg.Tag = 0;
            LoatDanhMuc();
            fg.Cols["MaVT"].AllowEditing = fg.Cols["TenVT"].AllowEditing = fg.Cols["DVT"].AllowEditing =
                fg.Cols["TongSL"].AllowEditing = fg.Cols["SoLuongDK"].AllowEditing = fg.Cols["SoLuongDSD"].AllowEditing = false;
            txtNgayChot.Value = Global.NgayLV;
            LoatData();
            fg.Tag = 1;
            AllowEdit(false);
            Global.nowait();
        }

        private void cmdThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (cmbVatTu.SelectedIndex == -1)
            {
                MessageBox.Show("Chọn vật tư.", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbVatTu.Focus();
                return;
            }
            for (int i = 1; i < fg.Rows.Count; i++)
            {
                if (cmbVatTu.Columns[2].CellText(cmbVatTu.SelectedIndex) == fg.GetDataDisplay(i, "MaVT"))
                {
                    MessageBox.Show("Vật tư này đã có.", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            fg.Tag = 0;
            fg.Rows.Add();
            fg[fg.Rows.Count - 1, "MaVT"] = cmbVatTu.Columns[2].CellValue(cmbVatTu.SelectedIndex);
            fg[fg.Rows.Count - 1, "TenVT"] = cmbVatTu.Columns[0].CellValue(cmbVatTu.SelectedIndex);
            fg[fg.Rows.Count - 1, "DVT"] = cmbVatTu.Columns[1].CellValue(cmbVatTu.SelectedIndex);
            fg[fg.Rows.Count - 1, "SoLuongTK"] = 0;
            fg[fg.Rows.Count - 1, "SoLuongDK"] = 0;
            fg[fg.Rows.Count - 1, "SoLuongTK"] = 0;
            fg[fg.Rows.Count - 1, "SoLuongDSD"] = 0;
            fg[fg.Rows.Count - 1, "TongSL"] = 0;
            fg.Tag = 1;
        }

        private void cmdGhi_Click(object sender, EventArgs e)
        {
            String Str = "";
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            try
            {
                Global.wait("Đang tổng hợp dữ liệu");
                Str = String.Format(" DELETE FROM VATTU WHERE MAKHOA='{0}'", Global.GetCode(cmbKhoa));
                for (int i = 1; i < fg.Rows.Count; i++)
                {
                    Str += String.Format(" INSERT INTO VATTU(MAKHOA,SOLUONGDK,SOLUONGTK,MACHIPHI,NGAYCHOT,ISVATTU) "
                        + " VALUES('{1}',{2},{3},'{0}','{4:MM/dd/yyyy}',{5})",
                        fg.GetDataDisplay(i,"MaVT"),
                        Global.GetCode(cmbKhoa),
                        (fg.GetDataDisplay(i,"SoLuongDK") == "") ? ("0") : (fg.GetData(i,"SoLuongDK").ToString().Replace(",",".")),
                        (fg.GetDataDisplay(i, "SoLuongTK") == "") ? ("0") : (fg.GetData(i, "SoLuongTK").ToString().Replace(".", "").Replace(",", ".")),
                        txtNgayChot.Value,
                        fg.GetDataDisplay(i,"IsVatTu") == "" ? "1" : fg.GetDataDisplay(i,"IsVatTu").Substring(0,1));
                }
                if (Str == "") return;
                SQLCmd.CommandText = Str;
                SQLCmd.ExecuteNonQuery();
                fg.Tag = 0;
                LoatData();
                fg.Tag = 1;
                AllowEdit(false);
                Global.nowait();
            }
            catch(Exception ex)
            {
                Global.nowait();
                MessageBox.Show("Lỗi: " + ex.ToString(), "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SQLCmd.Dispose();
            }
        }

        private void cmdChot_Click(object sender, EventArgs e)
        {
            String Str = "";
            System.Data.SqlClient.SqlTransaction tr;
            tr = Global.ConnectSQL.BeginTransaction();
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            SQLCmd.Transaction = tr;
            try
            {
                if (fg.Rows.Count <= 1) return;
                if (cmdChot.Text == "Chốt")
                {
                    for (int i = 1; i < fg.Rows.Count; i++)
                    {
                        Str += String.Format(" UPDATE VATTU SET SOLUONGDK = {0},SOLUONGTK = 0,NGAYCHOT='{3:MM/dd/yyyy}' WHERE MAKHOA ='{1}' AND MACHIPHI ='{2}' ",
                            fg.GetDataDisplay(i, "TongSL").ToString().Replace(",",".") == "0" ? "0" : fg.GetData(i, "TongSL").ToString().Replace(",","."),
                            Global.GetCode(cmbKhoa),
                            fg.GetDataDisplay(i, "MaVT"),
                            txtNgayChot.Value);

                        Str += String.Format(" INSERT INTO VETVATTU(MAKHOA,SOLUONGDK,SOLUONGTK,MACHIPHI,NGAYCHOT,SOLUONGDSD)"
                            + " VALUES('{0}',{1},{2},'{3}','{4:MM/dd/yyyy}',{5})",
                            Global.GetCode(cmbKhoa),
                            fg.GetDataDisplay(i, "SoLuongDK").ToString().Replace(",", ".") == "0" ? "0" : fg.GetData(i, "SoLuongDK").ToString().Replace(",", "."),
                            fg.GetDataDisplay(i, "SoLuongTK").ToString().Replace(",", ".") == "0" ? "0" : fg.GetData(i, "SoLuongTK").ToString().Replace(",", "."),
                            fg.GetDataDisplay(i, "MaVT"),
                            txtNgayChot.Value,
                            fg.GetDataDisplay(i, "SoLuongDSD").ToString().Replace(",", ".") == "0" ? "0" : fg.GetData(i, "SoLuongDSD").ToString().Replace(",", "."));
                    }
                    // Chua bat truong hop chuyen khoa
                    Str += String.Format(" UPDATE BENHNHAN_PT_CHIPHI SET CHOT = 1,DATHUCHIEN = 1,NGAYCHOT ='{0:MM/dd/yyyy}' WHERE LOAICHIPHI IN ('D02','D06') AND Chot = 0 And "
                        + " datediff(dd,NgayChiDinh,'{0:MM/dd/yyyy}') >= 0 ",
                        txtNgayChot.Value);
                }
                else
                {
                    //Huy chot
                    Str += String.Format(" DELETE FROM VATTU WHERE MAKHOA ='{0}'"
                        + " INSERT INTO VATTU(MAKHOA,SOLUONGDK,SOLUONGTK,MACHIPHI,NGAYCHOT)"
                        + " SELECT MAKHOA,SOLUONGDK,SOLUONGTK,MACHIPHI,NGAYCHOT FROM VETVATTU WHERE MAKHOA ='{0}' AND DATEDIFF(DD,NGAYCHOT,'{1:MM/dd/yyyy}') = 0 ",
                            Global.GetCode(cmbKhoa),
                            txtNgayChot.Value);

                    Str += String.Format(" DELETE FROM VETVATTU WHERE MAKHOA ='{0}' AND DATEDIFF(DD,NGAYCHOT,'{1:MM/dd/yyyy}') = 0 ",
                        Global.GetCode(cmbKhoa),
                        txtNgayChot.Value);
                    Str += String.Format(" UPDATE BENHNHAN_PT_CHIPHI SET CHOT = 0,NGAYCHOT = NULL,DATHUCHIEN = 0 WHERE LOAICHIPHI IN ('D02','D06') AND DATEDIFF(DD,NGAYCHOT,'{0:MM/dd/yyyy}') = 0",
                        txtNgayChot.Value);
                }
                if (Str == "") return;
                SQLCmd.CommandText = Str;
                SQLCmd.ExecuteNonQuery();
                tr.Commit();
                fg.Tag = 0;
                LoatData();
                fg.Tag = 1;
            }
            catch(Exception ex)
            {
                tr.Rollback();
                MessageBox.Show("Lỗi: " + ex.ToString(), "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                tr.Dispose();
                SQLCmd.Dispose();
            }
        }

        private void fg_AfterEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            if (fg.Tag.ToString() == "0") return;
            fg[e.Row, "TongSL"] = decimal.Parse(fg.GetDataDisplay(e.Row,"SoLuongDK")) + decimal.Parse(fg.GetDataDisplay(e.Row,"SoLuongTK")) - decimal.Parse(fg.GetDataDisplay(e.Row,"SoLuongDSD"));
        }

        private void fg_AfterRowColChange(object sender, C1.Win.C1FlexGrid.RangeEventArgs e)
        {
            if (fg.Tag.ToString() == "0") return;
            if (cmdGhi.Visible == true) return;
            if(e.OldRange.c2 != fg.Cols["SoLuongTK"].Index) return;
            if (decimal.Parse(fg.GetDataDisplay(e.OldRange.r2, "SoLuongTK")) < 0)
            {
                MessageBox.Show("Số lượng không lợp lệ.", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                fg.Select(e.OldRange.r2, e.OldRange.c2);
                e.Cancel = true;
            }
        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Reports.repKiemKeVT rpt = new NamDinh_QLBN.Reports.repKiemKeVT(cmbKhoa.Text, Global.GetCode(cmbKhoa), txtNgayChot.Value);
            rpt.Show();
        }

        private void fg_AfterDeleteRow(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            
        }

        private void fg_BeforeDeleteRow(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            fg.Redraw = true;
            if (cmdChot.Text == "Hũy chốt")
            {
                MessageBox.Show("đã chốt bạn không được xóa.", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                fg.Tag = 1;
                e.Cancel = true;
            }
            if (MessageBox.Show("Bạn có muốn xóa không.", "Thông báo.", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                fg.Tag = 0;
            }
            else
            {
                fg.Tag = 1;
                e.Cancel = true;
            }
        }

        private void cmdSua_Click(object sender, EventArgs e)
        {
            AllowEdit(true);
        }

        private void cmdInPhieuLinh_Click(object sender, EventArgs e)
        {
            //NamDinh_QLBN.Reports.rptPhieuLinhVT rpt = new NamDinh_QLBN.Reports.rptPhieuLinhVT(cmbKhoa.Text,Global.GetCode(cmbKhoa),txtNgayChot.Value);
            //rpt.Show();
        }

        private void txtNgayChot_ValueChanged(object sender, EventArgs e)
        {
            if (fg.Tag.ToString() == "0") return;
            String Str = "";
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            Global.wait("Đang tổng hợp dữ liệu ...!");
            try
            {
                Str = String.Format("Select max(NgayChot) as NgayChot from VetVatTu where makhoa ='{0}'",
                        Global.GetCode(cmbKhoa));
                SQLCmd.CommandText = Str;
                dr = SQLCmd.ExecuteReader();
                txtNgayChot.ReadOnly = false;
                cmdChot.Text = "Chốt";
                cmdPrint.Enabled = false;
                DateTime NgayChot = DateTime.Parse(txtNgayChot.Value.ToString());
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        if (dr["NgayChot"].ToString() == "") continue;
                        DateTime NgayChot1 = DateTime.Parse(dr["NgayChot"].ToString());
                        System.TimeSpan NgayDT = NgayChot1 - NgayChot;
                        if (NgayDT.Days >= 0)
                        {
                            txtNgayChot.Value = dr["NgayChot"];
                            txtNgayChot.ReadOnly = true;
                            cmdChot.Text = "Hủy chốt";
                            cmdPrint.Enabled = true;
                        }
                    }
                }
                dr.Close();
                fg.Tag = 0;
                LoatData();
                fg.Tag = 1;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                Global.nowait();
                SQLCmd.Dispose();
            }
        }

        private void frmVatTu_KeyDown(object sender, KeyEventArgs e)
        {
            if (cmbVatTu.Enabled == false) return;
            if (e.KeyCode == Keys.F5)
            {
                if (cmbVatTu.SelectedIndex == -1)
                {
                    MessageBox.Show("Chọn vật tư.", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbVatTu.Focus();
                    return;
                }
                for (int i = 1; i < fg.Rows.Count; i++)
                {
                    if (cmbVatTu.Columns[2].CellText(cmbVatTu.SelectedIndex) == fg.GetDataDisplay(i, "MaVT"))
                    {
                        MessageBox.Show("Vật tư này đã có.", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                fg.Tag = 0;
                fg.Rows.Add();
                fg[fg.Rows.Count - 1, "MaVT"] = cmbVatTu.Columns[2].CellValue(cmbVatTu.SelectedIndex);
                fg[fg.Rows.Count - 1, "TenVT"] = cmbVatTu.Columns[0].CellValue(cmbVatTu.SelectedIndex);
                fg[fg.Rows.Count - 1, "DVT"] = cmbVatTu.Columns[1].CellValue(cmbVatTu.SelectedIndex);
                fg[fg.Rows.Count - 1, "SoLuongTK"] = 0;
                fg[fg.Rows.Count - 1, "SoLuongDK"] = 0;
                fg[fg.Rows.Count - 1, "SoLuongTK"] = 0;
                fg[fg.Rows.Count - 1, "SoLuongDSD"] = 0;
                fg[fg.Rows.Count - 1, "TongSL"] = 0;
                fg.Tag = 1;
            }
        }

        private void cmbKhongGhi_Click(object sender, EventArgs e)
        {
            LoatData();
            AllowEdit(false);
        }

        private void txtNgayChot_TextChanged(object sender, EventArgs e)
        {

        }
    }
}