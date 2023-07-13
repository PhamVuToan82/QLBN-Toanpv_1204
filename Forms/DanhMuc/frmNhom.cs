using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NamDinh_QLBN.Forms.DanhMuc
{
    public partial class frmNhom : Form
    {
        private bool _Edit, _Add;
        public frmNhom()
        {
            InitializeComponent();
        }
        private void Load_DM()
        {
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            SQLCmd.CommandText = "SELECT * FROM DMKHOAPHONG WHERE MaKhoa IN " + GlobalModuls.Global.glbKhoa_CapNhat;
            dr = SQLCmd.ExecuteReader();
            cmbKhoa.Tag = "0";
            cmbKhoa.ClearItems();
            while (dr.Read())
            {
                cmbKhoa.AddItem(string.Format("{0};{1}", dr["MaKhoa"], dr["TenKhoa"]));
            }
            dr.Close();
            SQLCmd.Dispose();
            cmbKhoa.SelectedIndex = -1;
            cmbKhoa.Tag = "1";
            if (cmbKhoa.ListCount > 0) cmbKhoa.SelectedIndex = 0;
            SQLCmd.CommandText = "SELECT * FROM Khoa_Nhom where makhoa in " + GlobalModuls.Global.glbKhoa_CapNhat;
            dr = SQLCmd.ExecuteReader();
            fg.Rows.Count = 1;
            while (dr.Read())
            {
                fg.Rows.Add();
                fg[fg.Rows.Count - 1, 0] = fg.Rows.Count - 1;
                fg[fg.Rows.Count - 1, 1] = dr["MaNhom"].ToString();
                fg[fg.Rows.Count - 1, 2] = dr["TenNhom"].ToString();
            }
            dr.Close();
            SQLCmd.Dispose();
        }

        private void Edit(bool Flag)
        {
            cmdCancel.Visible = cmdOK.Visible = Flag;
            button1.Visible = cmdSua.Visible = cmdThem.Visible = cmdXoa.Visible = !Flag;
            txtTen.Enabled = Flag;
            txtTen.Text = "";
        }

        private void frmNhom_Load(object sender, EventArgs e)
        {
            Edit(false);
            Load_DM();
            _Add = _Edit = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdThem_Click(object sender, EventArgs e)
        {
            Edit(true);
            _Add = true;
            _Edit = false;
        }

        private void cmdSua_Click(object sender, EventArgs e)
        {
            if (fg.Rows.Count <= 1)
            {
                MessageBox.Show("Chọn tên nhóm để sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (fg.Row < 0)
            {
                MessageBox.Show("Chọn tên nhóm để sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Edit(true);
            txtTen.Text = fg.GetDataDisplay(fg.Row, "TenNhom");

            _Add = false;
            _Edit = true;
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Edit(false); 
            _Add = _Edit = false;
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            try
            {
                if (_Add)
                {
                    SQLCmd.CommandText = String.Format("Insert into Khoa_Nhom(MaKhoa,MaNhom,TenNhom) values('{0}',{1},N'{2}')",
                        GlobalModuls.Global.GetCode(cmbKhoa),
                        fg.Rows.Count,
                        txtTen.Text.Trim());
                }
                if (_Edit)
                {
                    SQLCmd.CommandText = String.Format("Update Khoa_Nhom set TenNhom = N'{1}' where MaKhoa='{0}' and MaNhom={2}",
                        GlobalModuls.Global.GetCode(cmbKhoa),
                        txtTen.Text.Trim(),
                        fg.GetDataDisplay(fg.Row,"MaNhom"));
                }
                SQLCmd.ExecuteNonQuery();
                Load_DM();
                Edit(false);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                SQLCmd.Dispose();
                _Edit = _Add = false;
            }
        }

        private void cmdXoa_Click(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            try
            {
                if (fg.Rows.Count <= 1) return;
                if (fg.Row < 0)
                {
                    MessageBox.Show("Chọn tên nhóm cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Bạn có muốn xóa không?.", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    SQLCmd.CommandText = String.Format("Delete from Khoa_Nhom where maKhoa='{0}' and MaNhom={1}",
                        GlobalModuls.Global.GetCode(cmbKhoa),
                        fg.GetDataDisplay(fg.Row, "MaNhom"));
                    SQLCmd.ExecuteNonQuery();
                    Load_DM();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                SQLCmd.Dispose();
            }
        }
    }
}