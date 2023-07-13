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
    public partial class  frmChiSoSoThuoc_sua : Form
    {
        public frmChiSoSoThuoc_sua()
        {
            InitializeComponent();
        }

        private void LoatDanhMuc()
        {
            String Str = "";
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

                Str = String.Format("SELECT ThuocID,TenThuoc,DonViTinh,a.LoaiThuoc,TenLoai FROM [" + Global.glbDuoc + "].dbo.DanhMucThuoc A"
                    + " Inner join [" + Global.glbDuoc + "].dbo.LoaiThuoc B on b.LoaiThuoc = A.LoaiThuoc where a.loaithuoc in (2,3,4,5,6,7,9) and a.SuDung=1"
                    + " order by TenThuoc",Global.GetCode(cmbKhoa));

                SQLCmd.CommandText = Str;
                dr = SQLCmd.ExecuteReader();
                fgChonThuoc.Rows.Count = 1;
                while (dr.Read())
                {
                    fgChonThuoc.Rows.Add();
                    fgChonThuoc[fgChonThuoc.Rows.Count - 1, "STT"] = fgChonThuoc.Rows.Count - 1;
                    fgChonThuoc[fgChonThuoc.Rows.Count - 1, "MaThuoc"] = dr["ThuocID"];
                    fgChonThuoc[fgChonThuoc.Rows.Count - 1, "TenThuoc"] = dr["TenThuoc"];
                    fgChonThuoc[fgChonThuoc.Rows.Count - 1, "DVT"] = dr["DonViTinh"];
                    fgChonThuoc[fgChonThuoc.Rows.Count - 1, "MaNhom"] = dr["LoaiThuoc"];
                    fgChonThuoc[fgChonThuoc.Rows.Count - 1, "TenNhom"] = dr["TenLoai"];
                }
                dr.Close();
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

        private void LoatData()
        {
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            try
            {
                SQLCmd.CommandText = String.Format("Select * from SoThuoc inner join [" + Global.glbDuoc + "].dbo.DanhMucThuoc aa on aa.ThuocID = SoThuoc.MaThuoc "
                    + " inner join [" + Global.glbDuoc + "].dbo.LoaiThuoc bb on bb.LoaiThuoc = SoThuoc.LoaiThuoc "
                    + " where sothuoc.makhoa='{0}' and aa.SuDung=1 order by SoThuoc.STT", Global.GetCode(cmbKhoa));
                dr = SQLCmd.ExecuteReader();
                fg.Rows.Count = 1;
                while (dr.Read())
                {
                    fg.Rows.Add();
                    fg[fg.Rows.Count - 1, "STT"] = fg.Rows.Count-1;
                    fg[fg.Rows.Count - 1, "MaThuoc"] = dr["MaThuoc"];
                    fg[fg.Rows.Count - 1, "TenThuoc"] = dr["TenThuoc"];
                    fg[fg.Rows.Count - 1, "DVT"] = dr["DonViTinh"];
                    fg[fg.Rows.Count - 1, "MaNhom"] = dr["LoaiThuoc"];
                    fg[fg.Rows.Count - 1, "TenNhom"] = dr["TenLoai"];
                }
                dr.Close();
                fg.AutoSizeCols(0);
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

        private void frmChiSoSoThuoc_Load(object sender, EventArgs e)
        {
            fg.Tag = 0;
            LoatDanhMuc();
            LoatData();
            fg.Tag = 1;
        }

        private void cmdThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdGhi_Click(object sender, EventArgs e)
        {
            String Str = "";
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            try
            {
                Str = String.Format(" Delete from SoThuoc Where MaKhoa = '{0}'", Global.GetCode(cmbKhoa));
                for (int i = 1; i < fg.Rows.Count; i++)
                {
                    Str += string.Format(" INSERT INTO SOTHUOC(MAKHOA,MATHUOC,LOAITHUOC,STT) VALUES('{0}','{1}','{2}',{3})",
                        Global.GetCode(cmbKhoa),
                        fg.GetDataDisplay(i,"MaThuoc"),
                        fg.GetDataDisplay(i,"MaNhom"),
                        i.ToString());
                }
                SQLCmd.CommandText = Str;
                SQLCmd.ExecuteNonQuery();
                fg.Tag = 0;
                LoatData();
                fg.Tag = 1;
                MessageBox.Show("Cập nhật thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.ToString(), "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                SQLCmd.Dispose();
            }
        }

        private void fg_BeforeDeleteRow(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            fg.Redraw = true;
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo.", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        

        private void cmdTop_Click(object sender, EventArgs e)
        {
            if (fg.Rows.Count == 1) return;
            if (fg.Row == 1) return;
            C1.Win.C1FlexGrid.CellRange cell = fg.Selection;
            for (int i = cell.r1; i <= cell.r2; i++)
            {
                if (i == 1) continue;
                fg.Rows[i].Move(i - 1);
                fg.Rows[i-1].StyleNew.BackColor = System.Drawing.Color.CadetBlue;
            }
        }

        private void cmdButton_Click(object sender, EventArgs e)
        {
            if (fg.Rows.Count == 1) return;
            if (fg.Row == fg.Rows.Count - 1) return;
            C1.Win.C1FlexGrid.CellRange cell = fg.Selection;
            for (int i = cell.r2; i >= cell.r1; i--)
            {
                if (i == fg.Rows.Count -1) continue;
                fg.Rows[i].Move(i + 1);
                fg.Rows[i + 1].StyleNew.BackColor = System.Drawing.Color.Cyan;
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            fgChonThuoc.Select(fgChonThuoc.FindRow(txtTimKiem.Text, 1, fgChonThuoc.Cols["TenThuoc"].Index, false, false, false), fgChonThuoc.Cols["TenThuoc"].Index);
        }

        private void fgChonThuoc_DoubleClick(object sender, EventArgs e)
        {
            if (fgChonThuoc.Rows.Count <= 1) return;
            if (fg.Tag.ToString() == "0") return;
            for (int i = 1; i < fg.Rows.Count; i++)
            {
                if (fg.GetDataDisplay(i, "MaThuoc") == fgChonThuoc.GetDataDisplay(fgChonThuoc.Row, "MaThuoc"))
                {
                    MessageBox.Show("Thuốc này đã có.", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            fg.Rows.Add();
            fg[fg.Rows.Count - 1, "STT"] = fg.Rows.Count - 1;
            fg[fg.Rows.Count - 1, "MaThuoc"] = fgChonThuoc.GetDataDisplay(fgChonThuoc.Row, "MaThuoc");
            fg[fg.Rows.Count - 1, "TenThuoc"] = fgChonThuoc.GetDataDisplay(fgChonThuoc.Row, "TenThuoc");
            fg[fg.Rows.Count - 1, "DVT"] = fgChonThuoc.GetDataDisplay(fgChonThuoc.Row, "DVT");
            fg[fg.Rows.Count - 1, "MaNhom"] = fgChonThuoc.GetDataDisplay(fgChonThuoc.Row, "MaNhom");
            fg[fg.Rows.Count - 1, "TenNhom"] = fgChonThuoc.GetDataDisplay(fgChonThuoc.Row, "TenNhom");
            fg.Select(fg.Rows.Count - 1, fg.Cols["TenThuoc"].Index);
        }
    }
}