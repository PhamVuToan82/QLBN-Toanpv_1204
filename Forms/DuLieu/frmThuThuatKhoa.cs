using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GlobalModuls;

namespace NamDinh_QLBN.Forms.DuLieu
{
    public partial class frmThuThuatKhoa : Form
    {
        public frmThuThuatKhoa()
        {
            InitializeComponent();
        }

        public void LoadDM()
        {
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            cmbKhoa.ClearItems();
            SQLCmd.CommandText = "SELECT * FROM DMKHOAPHONG WHERE MaKhoa IN " + Global.glbKhoa_CapNhat;
            dr = SQLCmd.ExecuteReader();
            cmbKhoa.Tag = "0";
            cmbKhoa.ClearItems();
            cmbKhoa.AddItemSeparator = '|';
            while (dr.Read())
            {
                cmbKhoa.AddItem(string.Format("{0}|{1}", dr["MaKhoa"], dr["TenKhoa"]));
            }
            dr.Close();
            cmbKhoa.SelectedIndex = 0;
            cmbKhoa.Tag = "1";
        }

        private void cmdThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoatData()
        {
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            try
            {
                SQLCmd.CommandText = String.Format("select dm.*,aa.GhiChu,case when aa.loaidichvu is null then 0 else 1 end as chon from"
                    + " (select * from ThuThuat_Khoa tt where tt.makhoa ='{0}') aa"
                    + " right join ["+ Global.glbSysDB +"].dbo.dmloaidichvu dm on dm.maloaidichvu = aa.loaidichvu",
                    Global.GetCode(cmbKhoa));
                dr = SQLCmd.ExecuteReader();
                fgDichVu.Rows.Count = 1;
                while (dr.Read())
                {
                    fgDichVu.Rows.Add();
                    fgDichVu[fgDichVu.Rows.Count - 1, "STT"] = fgDichVu.Rows.Count - 1;
                    fgDichVu[fgDichVu.Rows.Count - 1, "MaLoaiDichVu"] = dr["MaLoaiDichVu"];
                    fgDichVu[fgDichVu.Rows.Count - 1, "TenLoaiDichVu"] = dr["TenLoaiDichVu"];
                    fgDichVu[fgDichVu.Rows.Count - 1, "Chon"] = dr["Chon"];
                    fgDichVu[fgDichVu.Rows.Count - 1, "GhiChu"] = dr["GhiChu"];
                }
                dr.Close();
                fgDichVu.AutoSizeCols(1);
            }
            catch
            {
            }
            finally
            {
                SQLCmd.Dispose();
            }
        }

        private void frmThuThuatKhoa_Load(object sender, EventArgs e)
        {
            fgDichVu.Tag = 0;
            LoadDM();
            LoatData();
            fgDichVu.Tag = 1;
        }

        private void cmdGhi_Click(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            try
            {
                SQLCmd.CommandText = String.Format(" delete from THUTHUAT_KHOA Where makhoa='{0}'", cmbKhoa.Columns[0].CellText(cmbKhoa.SelectedIndex));
                for (int i = 1; i < fgDichVu.Rows.Count; i++)
                {
                    if (bool.Parse(fgDichVu.GetDataDisplay(i, "Chon")) == false) continue;
                    SQLCmd.CommandText += String.Format(" Insert into THUTHUAT_KHOA(MaKhoa,LoaiDichVu,TenLoaiDichVu,GhiChu) Values "
                        + " ('{0}','{1}',N'{2}',N'{3}')",
                    cmbKhoa.Columns[0].CellText(cmbKhoa.SelectedIndex),
                    fgDichVu.GetDataDisplay(i, "MaLoaiDichVu"),
                    fgDichVu.GetDataDisplay(i, "TenLoaiDichVu"),
                    fgDichVu.GetDataDisplay(i, "GhiChu"));
                }
                SQLCmd.ExecuteNonQuery();
                LoatData();
                MessageBox.Show("Cập nhật thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            { 
            }
            finally
            {
                SQLCmd.Dispose();
            }
        }
    }
}