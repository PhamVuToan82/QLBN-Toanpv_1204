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
    public partial class frmChonKho : Form
    {
        public frmChonKho()
        {
            InitializeComponent();
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
            cmbKhoa.SelectedIndex = 0;
            dr.Close();
            cmbKhoa.Tag = "1";
            SQLCmd.CommandText = "SELECT SACLAPPHIEU.LoaiThuoc,SACLAPPHIEU.KhoID,SACLAPPHIEU.Nhom,SACLAPPHIEU.NhomSo,SACLAPPHIEU.MaKhoa,LT.TenLoai,Kho.TenKho "
                + " FROM SACLAPPHIEU INNER JOIN [" + Global.glbDuoc + "].dbo.LoaiThuoc LT ON SACLAPPHIEU.loaithuoc = LT.LoaiThuoc "
                +" LEFT join [" + Global.glbDuoc + "].dbo.danhmuckho kho on kho.khoid = SACLAPPHIEU.KhoID Where SaclapPhieu.MaKhoa='"+ Global.GetCode(cmbKhoa) +"'";
            dr = SQLCmd.ExecuteReader();
            fg.ClipSeparators = "|;";
            fg.Rows.Count = 1;
            String Str = "";
            while (dr.Read())
            {
                Str = String.Format("{0}|{1}", fg.Rows.Count, dr["TenLoai"]);
                if (dr["KhoID"].ToString() == "")
                {

                }
                else
                {
                    Str += String.Format("|{0}-{1}|{2}|{3}", 
                        dr["KhoID"].ToString(), 
                        dr["TenKho"].ToString(),
                        dr["Nhom"],
                        (dr["NhomSo"].ToString() == "-1") ? ("") : (dr["NhomSo"].ToString()));
                }
                fg.AddItem(Str);
                   
                fg.Rows[fg.Rows.Count - 1].UserData = dr["LoaiThuoc"];
            }
            dr.Close();

            if (fg.Rows.Count > 1)
            {
                Str = "";
                SQLCmd.CommandText = "Select * from [" + Global.glbDuoc + "].dbo.DanhMucKho order by TenKho";
                dr = SQLCmd.ExecuteReader();
                while (dr.Read())
                {
                    Str += String.Format("{0}-{1}|", dr["KhoID"], dr["TenKho"]);
                }
                dr.Close();
                fg.Cols["Kho"].ComboList = Str;
            }
        }
        private void frmChonKho_Load(object sender, EventArgs e)
        {
            Load_CacDM();
        }

        private void cmdThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fg_AfterEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            
        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            try
            {
                System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
                SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
                String Str = string.Format("DELETE FROM SACLAPPHIEU WHERE MAKHOA ='{0}'" 
                    + " INSERT INTO SACLAPPHIEU(LOAITHUOC,MAKHOA) SELECT LOAITHUOC,'{0}' FROM [" + Global.glbDuoc + "].DBO.LOAITHUOC",Global.GetCode(cmbKhoa));
                SQLCmd.CommandText = Str;
                SQLCmd.ExecuteNonQuery();
                SQLCmd.Dispose();
                Load_CacDM();
            }
            catch
            {
                MessageBox.Show("Chưa thực hiện được", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void fg_BeforeEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            if (fg.Rows.Count <= 1)
            {
                e.Cancel = true;
                return;
            }
            if ((e.Col != fg.Cols["Kho"].Index) && (e.Col != fg.Cols["Nhom"].Index &&(e.Col != fg.Cols["NhomSo"].Index)))
            {
                e.Cancel = true;
                return;
            }
        }

        private void cmdGhi_Click(object sender, EventArgs e)
        {
            try
            {
                String Str = ""; 
               
                System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
                SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
                
                for (int i = 1; i < fg.Rows.Count; i++)
                {
                    Str += " UPDATE SACLAPPHIEU SET KHOID = ";
                    if ((fg.GetDataDisplay(i, "Kho").ToString() == "") || (fg.GetDataDisplay(i,"Nhom") == ""))
                    {
                        Str += "null,Nhom = null,NhomSo= null ";
                    }
                    else
                    {
                        Str += fg.GetDataDisplay(i, "Kho").ToString().Substring(0, fg.GetDataDisplay(i, "Kho").IndexOf("-")) +
                            ",Nhom= " + fg.GetDataDisplay(i, "Nhom").Trim() + ",NhomSo= " + ((fg.GetDataDisplay(i, "NhomSo").Trim() == "") ? ("-1") : (fg.GetDataDisplay(i, "NhomSo").Trim()));
                    }
                    Str += " WHERE MAKHOA='" + Global.GetCode(cmbKhoa) + "' AND LOAITHUOC ='" + fg.Rows[i].UserData.ToString() + "'";
                }
                SQLCmd.CommandText = Str;
                SQLCmd.ExecuteNonQuery();
                Load_CacDM();
                MessageBox.Show("Ghi dữ liệu thành công.", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Sác lập chưa đúng.", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}