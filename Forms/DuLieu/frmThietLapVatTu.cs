using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using GlobalModuls;

namespace NamDinh_QLBN.Forms.DuLieu
{
    public partial class frmThietLapVatTu : Form
    {
        public frmThietLapVatTu()
        {
            InitializeComponent();
        }

        private void LoatDanhMuc()
        {
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            SQLCmd.CommandTimeout = 0;
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
                SQLCmd.CommandText = "select * from DMLENCHIPHI_BYKHOID where loaidichvu in ('D02','D06') order by tendichvu";
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
                //string strcmb = "0-In trên sổ y lệnh|1-Không in";
                //fg.Cols["isVatTu"].ComboList = strcmb;
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
                Str = string.Format(" SELECT vt.MACHIPHI,vt.MAKHOA,dm.TenDichVu,dm.DVT,dm.LoaiDichVu,vt.Nhom "
                     + " FROM VATTU vt inner join DMLENCHIPHI_BYKHOID dm on vt.MaChiPhi=dm.MaDichVu "
                     + " WHERE vt.MAKHOA ='{0}' ", Global.GetCode(cmbKhoa));
                SQLCmd.CommandText = Str;
                SQLCmd.CommandTimeout = 0;
                dr = SQLCmd.ExecuteReader();
                fg.Rows.Fixed = 0;
                fg.Rows.Count = 1;
                fg.Rows.Fixed = 1;
                while (dr.Read())
                {
                    fg.Rows.Add();
                    fg[fg.Rows.Count - 1, "STT"] = fg.Rows.Count-1;
                    fg[fg.Rows.Count - 1, "MaVatTu"] = dr["MaChiPhi"];
                    fg[fg.Rows.Count - 1, "TenVatTu"] = dr["Tendichvu"];
                    fg[fg.Rows.Count - 1, "DVT"] = dr["dvt"];
                    fg[fg.Rows.Count - 1, "LoaiDichVu"] = dr["LoaiDichVu"];
                    fg[fg.Rows.Count - 1, "Nhom"] = dr["Nhom"];
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
            LoatDanhMuc();
            fg.Cols["MaVatTu"].AllowEditing = fg.Cols["TenVatTu"].AllowEditing = fg.Cols["DVT"].AllowEditing = fg.Cols["LoaiDichVu"].AllowEditing = false;
            fg.Cols["MaVatTu"].Visible = false;
            LoatData();
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
                if (cmbVatTu.Columns[2].CellText(cmbVatTu.SelectedIndex) == fg.GetDataDisplay(i, "MaVatTu"))
                {
                    MessageBox.Show("Vật tư này đã có.", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            String Str = "";
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            try
            {
                Str += String.Format(" INSERT INTO VATTU(MAKHOA,MACHIPHI,Nhom,LoaiDichVu) VALUES('{0}','{1}',{2},'{3}')",
                    Global.GetCode(cmbKhoa),cmbVatTu.Columns[2].CellValue(cmbVatTu.SelectedIndex),0,cmbVatTu.Columns[3].CellValue(cmbVatTu.SelectedIndex));
                SQLCmd.CommandText = Str;
                SQLCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.ToString(), "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SQLCmd.Dispose();
                fg.Rows.Add();
                fg[fg.Rows.Count - 1, "STT"] = fg.Rows.Count - 1;
                fg[fg.Rows.Count - 1, "MaVatTu"] = cmbVatTu.Columns[2].CellValue(cmbVatTu.SelectedIndex);
                fg[fg.Rows.Count - 1, "TenVatTu"] = cmbVatTu.Columns[0].CellValue(cmbVatTu.SelectedIndex);
                fg[fg.Rows.Count - 1, "DVT"] = cmbVatTu.Columns[1].CellValue(cmbVatTu.SelectedIndex);
                fg[fg.Rows.Count - 1, "LoaiDichVu"] = cmbVatTu.Columns[3].CellValue(cmbVatTu.SelectedIndex);
                fg[fg.Rows.Count - 1, "Nhom"] = 0;
                fg.Select(fg.Rows.Count - 1, 2);
            }
            
        }
        private void frmVatTu_KeyDown(object sender, KeyEventArgs e)
        {
            if (cmbVatTu.Enabled == false) return;
            if (e.KeyCode == Keys.F5)
            {
                simpleButton1_Click(sender, e);
            }
        }
        private void fg_AfterEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            String Str = "";
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            try
            {
                Str += String.Format(" Update VATTU set Nhom={0} where MaKhoa='{1}' and MaChiPhi='{2}'",
                    fg.GetDataDisplay(e.Row, "Nhom"), Global.GetCode(cmbKhoa), fg.GetDataDisplay(e.Row, "MaVatTu"));
                SQLCmd.CommandText = Str;
                SQLCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Global.nowait();
                MessageBox.Show("Lỗi: " + ex.ToString(), "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SQLCmd.Dispose();
            }
        }


        private void fg_BeforeDeleteRow(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa không.", "Thông báo.", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                String Str = "";
                System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
                SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
                try
                {
                    Str += String.Format(" delete from VATTU where MaKhoa='{0}' and MaChiPhi='{1}'",
                        Global.GetCode(cmbKhoa), fg.GetDataDisplay(e.Row, "MaVatTu"));
                    SQLCmd.CommandText = Str;
                    SQLCmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.ToString(), "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    SQLCmd.Dispose();
                }
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}