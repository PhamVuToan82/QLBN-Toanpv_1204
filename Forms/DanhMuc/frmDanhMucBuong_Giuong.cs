using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GlobalModuls;

namespace NamDinh_QLBN.Forms.DanhMuc
{
    public partial class frmDanhMucBuong_Giuong : Form
    {
        private bool bAdd = false;        
        private string[] arLoaiGiuong;
        public frmDanhMucBuong_Giuong()
        {
            InitializeComponent();
        }

        private void frmDanhMucBuong_Giuong_Load(object sender, EventArgs e)
        {
            cmbKhoa.Tag = "0";
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
            SQLCmd.Dispose();
            cmbKhoa.SelectedIndex = 0;
            cmbKhoa.Tag = "1";
            fgDanhSach.ClipSeparators = "|;";
            fgGiuong.ClipSeparators = "|;";
            fgGiuong.Cols[1].Visible = fgGiuong.Cols[2].Visible = fgGiuong.Cols[3].Visible = false;
            cmbKhoa_TextChanged(sender,null);
        }
        private void cmbKhoa_TextChanged(object sender, EventArgs e)
        {
            if (cmbKhoa.Tag.ToString() == "0") { return; }
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            SQLCmd.CommandText = "SELECT * FROM DMDICHVU INNER JOIN DMGIUONG_KHOA ON MaDichVu=MaGiuong WHERE DMGIUONG_KHOA.MaKhoa='" + Global.GetCode(cmbKhoa) + "' ORDER BY MaGiuong";
            string strcmb = "";
            dr = SQLCmd.ExecuteReader();
            while (dr.Read())
            {
                strcmb += string.Format("{0}-{1}|", dr["MaDichVu"], dr["TenDichVu"]);
            }
            dr.Close();
            fgGiuong.Cols[5].ComboList = strcmb;
            string[] sp = new string[1];
            sp.SetValue("|", 0);
            arLoaiGiuong = strcmb.Split(sp, StringSplitOptions.None);
            SQLCmd.CommandText = "SELECT * FROM DMBUONGBENH WHERE MaKhoa='" + Global.GetCode(cmbKhoa) + "'";
            dr = SQLCmd.ExecuteReader();
            fgDanhSach.Tag = "0";
            fgDanhSach.Rows.Count = 1;
            while (dr.Read())
            {
                fgDanhSach.AddItem(string.Format("{0}|{1}|{2}|{3}|{4}",fgDanhSach.Rows.Count, dr["ID_Buong"],dr["TenBuong"],dr["ghiChu"],dr["SuDung"]));
            }
            dr.Close();
            SQLCmd.Dispose();
            fgDanhSach.Cols[1].Visible = false;
            fgDanhSach.Row = 0;
            fgGiuong.Rows.Count = 1;
            fgDanhSach.Tag = "1";            
        }

        private void cmdThemBuong_Click(object sender, EventArgs e)
        {
            if (Global.GetCode(cmbKhoa) == null)
            {
                MessageBox.Show("Chưa chọn khoa điều trị!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbKhoa.Focus();
                return;
            }
            fgDanhSach.Tag = "0";
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();            
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            System.Data.SqlClient.SqlDataReader dr;
            int IDBuongMax = fgDanhSach.Rows.Count;
            SQLCmd.CommandText = "Select isnull(Max(ID_Buong),1) as IDMax from DMBUONGBENH where MaKhoa = '" + Global.GetCode(cmbKhoa) + "' ";
            dr = SQLCmd.ExecuteReader();
            if (dr.Read())
            {
                IDBuongMax = int.Parse(dr["IDMax"].ToString()) +1;
            }
            dr.Close();
            int MaBuong = IDBuongMax;
            fgDanhSach.AddItem(string.Format("{0}|{1}|||{2}|",fgDanhSach.Rows.Count,MaBuong,1));
            bAdd = true;            
            fgDanhSach.Row = fgDanhSach.Rows.Count - 1;
            fgDanhSach.Col = 2;
            fgDanhSach.Focus();
            fgDanhSach.Tag = "1";
        }

        private void fgDanhSach_AfterEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            if (fgDanhSach.Tag.ToString() == "0" || fgDanhSach.Row < 1) { return; }            
            string MaKhoa = GlobalModuls.Global.GetCode(cmbKhoa);
            int ID_Buong = int.Parse(fgDanhSach[fgDanhSach.Row, 1].ToString());
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();            
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            System.Data.SqlClient.SqlDataReader dr;
            if (bAdd) //Them moi
            {
                int IDBuongMax = fgDanhSach.Rows.Count;
                SQLCmd.CommandText = "Select isnull(Max(ID_Buong),1) as IDMax from DMBUONGBENH where MaKhoa = '"+ MaKhoa +"' ";
                dr = SQLCmd.ExecuteReader();
                if (dr.Read())
                {
                    IDBuongMax = int.Parse(dr["IDMax"].ToString()) +1;
                }
                dr.Close();
                SQLCmd.CommandText = string.Format("INSERT INTO DMBUONGBENH (MaKhoa,ID_Buong,TenBuong,GhiChu,SuDung) VALUES ('{0}',{1},N'{2}',N'{3}',{4})", MaKhoa,IDBuongMax, fgDanhSach[fgDanhSach.Row, 2], fgDanhSach[fgDanhSach.Row, 3], (fgDanhSach[fgDanhSach.Row, 4].ToString().ToLower() == "true") ? 1 : 0);
            }
            else
            {
                SQLCmd.CommandText =string.Format("UPDATE DMBUONGBENH SET TenBuong=N'{0}',GhiChu=N'{1}',SuDung=N'{4}' WHERE ID_Buong={2} AND MaKhoa='{3}'", fgDanhSach[fgDanhSach.Row,2],fgDanhSach[fgDanhSach.Row,3],ID_Buong,MaKhoa, (fgDanhSach[fgDanhSach.Row, 4].ToString().ToLower() == "true") ? 1 : 0);
            }
            try
            {
                SQLCmd.ExecuteNonQuery();
                bAdd = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi ghi dữ liệu!\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SQLCmd.Dispose();
            }
        }

        private void fgDanhSach_RowColChange(object sender, EventArgs e)
        {
            if (fgDanhSach.Tag.ToString() == "0") return;
            lblGiuong.Text = string.Format("{0} - {1}", cmbKhoa.Text, fgDanhSach[fgDanhSach.Row, 2]);
            if (fgDanhSach.Tag.ToString() == "0") { return; }
            int MaBuong = int.Parse(fgDanhSach[fgDanhSach.Row, 1].ToString());
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlDataReader dr;
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            SQLCmd.CommandText = "SELECT *,bs.mabs + '-' + bs.tenbs as bacsy1,y.mabs + '-' + y.tenbs as yta1, DMGIUONGBENH.SunDung as SuDung_Giuong FROM DMGIUONGBENH LEFT JOIN DMDICHVU ON DMGIUONGBENH.LoaiGiuong=DMDICHVU.MaDichVu AND LoaiDichVu='B01' "
                + " left join dmbacsy bs on bs.mabs = dmgiuongbenh.mabs and bs.makhoa = DMGIUONGBENH.MaKhoa"
                + " left join dmbacsy y on y.mabs = dmgiuongbenh.mayt and y.makhoa = DMGIUONGBENH.MaKhoa"
                + " WHERE DMGIUONGBENH.MaKhoa='" + Global.GetCode(cmbKhoa) + "' AND ID_Buong=" + MaBuong;
            dr = SQLCmd.ExecuteReader();
            fgGiuong.Tag = "0";
            fgGiuong.Rows.Count = 1;
            while (dr.Read())
            {
                fgGiuong.AddItem(string.Format("{0}|{1}|{2}|{3}|{4}|{5}{6}|{7}|{8}|{9}",
                    fgGiuong.Rows.Count,
                    Global.GetCode(cmbKhoa),
                    MaBuong,
                    dr["ID_Giuong"],
                    dr["TenGiuong"],
                    (dr["MaDichVu"].ToString() =="")?(""):(dr["MaDichVu"].ToString() + "-" +dr["TenCP"].ToString()),
                    dr["bacsy1"],
                    dr["yta1"], dr["SuDung_Giuong"], dr["MaGiuongYT"]));
            }
            dr.Close();

            SQLCmd.CommandText = String.Format("Select * from DMBACSY where DMBACSY.makhoa='{0}' order by TenBS", Global.GetCode(cmbKhoa));
            dr = SQLCmd.ExecuteReader();
            String Str;
            if (fgGiuong.Rows.Count > 1)
            {
                Str = "";
                while (dr.Read())
                {
                    Str += String.Format("{0}-{1}|", dr["MaBS"], dr["Tenbs"]);
                }
                dr.Close();
                fgGiuong.Cols["bacsy"].ComboList = Str;
                fgGiuong.Cols["yta"].ComboList = Str;
            }
            dr.Close();
            SQLCmd.Dispose();
            fgGiuong.Tag = "1";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void cmbThemGiuong_Click(object sender, EventArgs e)
        {
            if (Global.GetCode(cmbKhoa) == null)
            {
                MessageBox.Show("Chưa chọn khoa điều trị!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbKhoa.Focus();
                return;            
            }
            if (fgDanhSach.Row<1)
            {
                MessageBox.Show("Chưa chọn buồng điều trị!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                fgDanhSach.Focus();
                return;
            }
            int MaBuong = int.Parse(fgDanhSach[fgDanhSach.Row, 1].ToString());
            int MaGiuong = (fgGiuong.Rows.Count == 1) ? (1) : (int.Parse(fgGiuong[fgGiuong.Rows.Count - 1, 3].ToString()) + 1);
            //int MaGiuong = (fgGiuong.Rows.Count == 1) ? (1) : (fgGiuong.Rows.Count);
            
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            SQLCmd.CommandText =string.Format("INSERT INTO DMGIUONGBENH (MaKhoa,ID_Buong,ID_Giuong) VALUES ('{0}',{1},{2})",Global.GetCode(cmbKhoa),MaBuong,MaGiuong);
            try
            { SQLCmd.ExecuteNonQuery(); }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi thêm dữ liệu!\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally { SQLCmd.Dispose(); }
            fgGiuong.AddItem(string.Format("{0}|{1}|{2}|{3}||||{4}|{5}|", fgGiuong.Rows.Count, GlobalModuls.Global.GetCode(cmbKhoa), MaBuong, MaGiuong,1,""));           
            fgGiuong.Row = fgGiuong.Rows.Count - 1;
            fgGiuong.Col =4;
            fgGiuong.Focus();
        }

        private void fgGiuong_AfterEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            string MaKhoa = fgGiuong[fgGiuong.Row,1].ToString();
            int MaBuong = int.Parse(fgGiuong[fgGiuong.Row,2].ToString());
            int MaGiuong = int.Parse(fgGiuong[fgGiuong.Row,3].ToString());
            String MaBS = "", MaYT = "";
            if (fgGiuong.GetDataDisplay(fgGiuong.Row, "BacSy") == "")
            {
                MaBS = "null";
            }
            else
            {
                MaBS = fgGiuong.GetDataDisplay(fgGiuong.Row, "BacSy").Substring(0, fgGiuong.GetDataDisplay(fgGiuong.Row, "bacsy").IndexOf("-"));
            }

            if (fgGiuong.GetDataDisplay(fgGiuong.Row, "Yta") == "")
            {
                MaYT = "null";
            }
            else
            {
                MaYT = fgGiuong.GetDataDisplay(fgGiuong.Row, "Yta").Substring(0, fgGiuong.GetDataDisplay(fgGiuong.Row, "Yta").IndexOf("-"));
            }

            string LoaiGiuong = "";
            if (fgGiuong.GetDataDisplay(fgGiuong.Row, 5) != "")
            {    
                LoaiGiuong = fgGiuong[fgGiuong.Row, 5].ToString().Substring(0,3);
            }
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            SQLCmd.CommandText = string.Format("UPDATE DMGIUONGBENH SET TenGiuong=N'{3}',LoaiGiuong={4},MaBS={5},MaYT={6},SunDung = {7}, MaGiuongYT= N'{8}' WHERE MaKhoa='{0}' AND ID_Buong={1} AND ID_Giuong={2}",
                MaKhoa , MaBuong, MaGiuong,
                fgGiuong[fgGiuong.Row,4],(LoaiGiuong=="")?("null"):("'" + LoaiGiuong.ToString() + "'"),
                MaBS,
                MaYT, (fgGiuong[fgGiuong.Row, 7].ToString().ToLower() == "true") ? 1 : 0,
                fgGiuong[fgGiuong.Row, 8].ToString().ToUpper().Trim());
                
            try
            { SQLCmd.ExecuteNonQuery(); }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi ghi dữ liệu!\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally { SQLCmd.Dispose(); }
            fgGiuong[fgGiuong.Row, 8] = fgGiuong[fgGiuong.Row, 8].ToString().ToUpper().Trim();
        }

        private void cmdXoaBuong_Click(object sender, EventArgs e)
        {
            if (fgDanhSach.Rows.Count <= 1) return;
            string MaKhoa = GlobalModuls.Global.GetCode(cmbKhoa);
            int ID_Buong = int.Parse(fgDanhSach[fgDanhSach.Row, 1].ToString());
            if (MessageBox.Show("Bạn có thực sự muốn xóa buồng hay không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                String Str = "Delete from DMBUONGBENH Where MaKhoa='" + MaKhoa + "' And ID_Buong=" + ID_Buong.ToString()
                        + ";Delete from DMGIUONGBENH WHERE MaKhoa='" + MaKhoa + "' And ID_Buong=" + ID_Buong.ToString();
                System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
                SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
                SQLCmd.CommandText = Str;
                SQLCmd.ExecuteNonQuery();
                fgDanhSach.Rows.Remove(fgDanhSach.Row);
                fgDanhSach.Row = fgDanhSach.Rows.Count - 1;
                fgDanhSach.Col = 2;
                fgDanhSach.Focus();
                fgDanhSach.Tag = "1";
            }
        }

        private void cmdXoaGiuong_Click(object sender, EventArgs e)
        {
            if (fgGiuong.Rows.Count <= 1) return;
            if (MessageBox.Show("Bạn có thực sự muốn xóa buồng hay không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                string MaKhoa = GlobalModuls.Global.GetCode(cmbKhoa);
                int ID_Buong = int.Parse(fgDanhSach[fgDanhSach.Row, 1].ToString());
                int MaGiuong = int.Parse(fgGiuong[fgGiuong.Row, 3].ToString());
                String Str = "Delete from DMGIUONGBENH WHERE MaKhoa='" + MaKhoa + "' And ID_Buong=" + ID_Buong.ToString() + " And ID_Giuong=" + MaGiuong.ToString();
                System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
                SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
                SQLCmd.CommandText = Str;
                SQLCmd.ExecuteNonQuery();
                fgGiuong.Rows.Remove(fgGiuong.Row);
            }
        }
    }
}