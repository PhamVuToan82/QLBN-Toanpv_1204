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
    public partial class frmTT54 : Form
    {
        public frmTT54()
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
            SQLCmd.CommandText = "select Id_BenhVien,TenBenhVien from NAMDINH_QLBN.dbo.tbl_TT54_DsBenhVien";
            dr = SQLCmd.ExecuteReader();
            cmbKhoa.Tag = "0";
            cmbKhoa.ClearItems();
           
            while (dr.Read())
            {
                cmbKhoa.AddItem(string.Format("{0};{1}", dr["Id_BenhVien"], dr["TenBenhVien"]));
            }
            dr.Close();
            cmbKhoa.SelectedIndex = -1;
        }

        private void Load_TieuChi()
        {
            fgLoaiDichVu.Redraw = false;
            fgLoaiDichVu.ClipSeparators = "|;";
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            SQLCmd.CommandText = "select b.TenNhom,c.TenMuc,a.Id_TieuChi,a.TenTieuChi,d.Id_TieuChi_CT,d.TenTieuChiChiTiet,0 as Chon,b.Id_Nhom,c.Muc"
                     + " from NAMDINH_QLBN.dbo.tbl_TT54_DanhMuc a inner join NAMDINH_QLBN.dbo.tbl_NhomTT54 b on a.Id_Nhom = b.Id_Nhom inner join NAMDINH_QLBN.dbo.Tbl_TT54_Muc c on c.Muc = a.Muc "
                     + " left join NAMDINH_QLBN.dbo.tbl_TT54_DanhMuch_CT d on d.Id_Tieuchi = a.Id_TieuChi"
                     + " order by a.Id_Nhom,a.Id_TieuChi";
            dr = SQLCmd.ExecuteReader();
            fgLoaiDichVu.Rows.Count = 1;
            while (dr.Read())
            {
                fgLoaiDichVu.AddItem(string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|", fgLoaiDichVu.Rows.Count, dr["TenNhom"], dr["TenMuc"], dr["Id_TieuChi"], dr["TenTieuChi"], dr["Id_TieuChi_CT"], dr["TenTieuChiChiTiet"], dr["Chon"], dr["Id_Nhom"], dr["Muc"]));
            }
            dr.Close();
            fgLoaiDichVu.Redraw = true;
            SQLCmd.Dispose();
            cmbKhoa.Tag = "1";
            fgLoaiDichVu.AutoSizeCols();
            fgLoaiDichVu.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictCols;
            fgLoaiDichVu.Cols[0].AllowMerging = true;
            fgLoaiDichVu.Cols[1].AllowMerging = true;
            fgLoaiDichVu.Cols[2].AllowMerging = true;
            fgLoaiDichVu.Cols[3].AllowMerging = true;
            fgLoaiDichVu.Cols[4].AllowMerging = true;
        }
        private void frmTT54_Load(object sender, EventArgs e)
        {
            
            Load_CacDM();
            Load_TieuChi();
        }

        private void cmbKhoa_TextChanged(object sender, EventArgs e)
        {
            if (cmbKhoa.Tag.ToString() == "0" || cmbKhoa.SelectedIndex == -1) return;
            fgLoaiDichVu.Redraw = false;
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            SQLCmd.CommandText = string.Format("select * from(select distinct TenNhom,TenMuc,a.Id_TieuChi,a.TenTieuChi,a.Id_TieuChi_CT,ct.TenTieuChiChiTiet,a.DanhGia as Chon,a.Id_Nhom,a.Muc from ( "
                                                + " select b.TenNhom,c.TenMuc,a.Id_TieuChi,a.TenTieuChi,a.Id_TieuChi_CT,a.DanhGia,a.Id_Nhom,a.Muc"
                                                + " from NAMDINH_QLBN.dbo.Tbl_TT54 a inner join NAMDINH_QLBN.dbo.tbl_NhomTT54 b on a.Id_Nhom = b.Id_Nhom"
                                                + " inner join NAMDINH_QLBN.dbo.Tbl_TT54_Muc c on c.Muc = a.Muc"
                                                + " where a.Id_BenhVien = {0}) A left join NAMDINH_QLBN.dbo.tbl_TT54_DanhMuch_CT ct on ct.Id_TieuChi_CT = a.Id_TieuChi_CT)B"
                                                + " order  by Id_Nhom,Id_TieuChi", Global.GetCode(cmbKhoa));
            dr = SQLCmd.ExecuteReader();
            if (dr.HasRows)
            {
                fgLoaiDichVu.Rows.Count = 1;
                while (dr.Read())
                {
                    fgLoaiDichVu.AddItem(string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|", fgLoaiDichVu.Rows.Count, dr["TenNhom"], dr["TenMuc"], dr["Id_TieuChi"], dr["TenTieuChi"], dr["Id_TieuChi_CT"], dr["TenTieuChiChiTiet"], dr["Chon"], dr["Id_Nhom"], dr["Muc"]));
                }
                dr.Close();
                fgLoaiDichVu.Redraw = true;
                SQLCmd.Dispose();
                cmbKhoa.Tag = "1";
                fgLoaiDichVu.AutoSizeCols();
                fgLoaiDichVu.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictCols;
                fgLoaiDichVu.Cols[0].AllowMerging = true;
                fgLoaiDichVu.Cols[1].AllowMerging = true;
                fgLoaiDichVu.Cols[2].AllowMerging = true;
                fgLoaiDichVu.Cols[3].AllowMerging = true;
                fgLoaiDichVu.Cols[4].AllowMerging = true;
                for (int i = 0; i <= fgLoaiDichVu.Rows.Count - 3; i++)
                {
                    if (fgLoaiDichVu.GetCellCheck(i, fgLoaiDichVu.Cols["Chon"].Index) == C1.Win.C1FlexGrid.CheckEnum.Checked)
                    {
                        fgLoaiDichVu.Rows[i].StyleNew.BackColor = Color.LightSeaGreen;
                    }

                }
            }
            else
            {
                dr.Close();
                Load_TieuChi();
            }
            txtTongHop.Text = "";

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
                SQLCmd.CommandText = "DELETE FROM NAMDINH_QLBN.DBO.Tbl_TT54 WHERE Id_BenhVien='" + Global.GetCode(cmbKhoa).ToString() + "'";
                SQLCmd.ExecuteNonQuery();
                for (int i=1;i<fgLoaiDichVu.Rows.Count;i++)
                    if (fgLoaiDichVu.GetCellCheck(i, fgLoaiDichVu.Cols["Chon"].Index) == C1.Win.C1FlexGrid.CheckEnum.Checked)
                    {
                        SQLCmd.CommandText =string.Format("INSERT INTO NAMDINH_QLBN.DBO.Tbl_TT54 (Id_TieuChi, TenTieuChi, DanhGia, NgayDanhGia, Id_BenhVien, Id_Nhom, Muc, Id_TieuChi_CT) VALUES ('{0}',N'{1}','{2}','{3:dd/MM/yyyy}','{4}','{5}','{6}','{7}')",
                            fgLoaiDichVu[i, "Id_TieuChi"], fgLoaiDichVu[i, "TenTieuChi"],1, txtNgayChiDinh.Value, Global.GetCode(cmbKhoa).ToString(), fgLoaiDichVu[i, "Id_Nhom"], fgLoaiDichVu[i, "Muc"],fgLoaiDichVu[i,"Id_TieuChi_CT"]);
                        SQLCmd.ExecuteNonQuery();
                    }
                    else
                    {
                        SQLCmd.CommandText = string.Format("INSERT INTO NAMDINH_QLBN.DBO.Tbl_TT54 (Id_TieuChi, TenTieuChi, DanhGia, NgayDanhGia, Id_BenhVien, Id_Nhom, Muc, Id_TieuChi_CT) VALUES ('{0}',N'{1}','{2}','{3:dd/MM/yyyy}','{4}','{5}','{6}','{7}')",
                        fgLoaiDichVu[i, "Id_TieuChi"], fgLoaiDichVu[i, "TenTieuChi"], 0, txtNgayChiDinh.Value, Global.GetCode(cmbKhoa).ToString(), fgLoaiDichVu[i, "Id_Nhom"], fgLoaiDichVu[i, "Muc"], fgLoaiDichVu[i, "Id_TieuChi_CT"]);
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
            fgLoaiDichVu.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictCols;
            fgLoaiDichVu.Cols[0].AllowMerging = true;
            fgLoaiDichVu.Cols[1].AllowMerging = true;
            fgLoaiDichVu.Cols[2].AllowMerging = true;
            fgLoaiDichVu.Cols[3].AllowMerging = true;
            fgLoaiDichVu.Cols[4].AllowMerging = true;
            for (int i = 0; i <= fgLoaiDichVu.Rows.Count - 3; i++)
            {
                if (fgLoaiDichVu.GetCellCheck(i, fgLoaiDichVu.Cols["Chon"].Index) == C1.Win.C1FlexGrid.CheckEnum.Checked)
                {
                    fgLoaiDichVu.Rows[i].StyleNew.BackColor = Color.LightSeaGreen;
                }

            }

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cmbKhoa.SelectedIndex == -1) return;
            //if (tabControl1.SelectedIndex == 1)
            //{
            //    string MaKhoa = Global.GetCode(cmbKhoa);
            //    System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
            //    SQLCmd.CommandText = "SELECT a.* FROM DMLOAIDICHVU a INNER JOIN KHOA_LOAIDICHVU b ON a.MaLoaiDichVu=b.LoaiDichVu WHERE (NoiTru_NgoaiTru = 1 OR NoiTru_NgoaiTru = 3) AND b.MaKhoa='" + MaKhoa + "'";
            //    System.Data.SqlClient.SqlDataReader dr = SQLCmd.ExecuteReader();
            //    cmbLoaiDichVu.Tag = "0";
            //    cmbLoaiDichVu.ClearItems();
            //    while (dr.Read())
            //    {
            //        cmbLoaiDichVu.AddItem(string.Format("{0};{1}", dr["MaLoaiDichVu"], dr["TenLoaiDichVu"]));
            //    }
            //    cmbLoaiDichVu.SelectedIndex = -1;
            //    dr.Close();
            //    SQLCmd.Dispose();
            //    cmbLoaiDichVu.Tag = "1";
            //}
        }

        private void cmbLoaiDichVu_TextChanged(object sender, EventArgs e)
        {
            //if (cmbLoaiDichVu.Tag.ToString() == "0" || cmbLoaiDichVu.SelectedIndex == -1) return;
            //System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
            //SQLCmd.CommandText = "select a.MaDichVu As [Mã],TenDichVu as [Tên dịch vụ],CASE WHEN b.MaDichVu is null Then 0 ELSE 1 END as [Chọn] FROM DMDICHVU a Left Join KHOA_DICHVU b ON a.MaDichVu=b.MaDichVu AND a.LoaiDichVu=b.LoaiDIchVu and b.makhoa ='" + Global.GetCode(cmbKhoa) +"' WHERE a.LoaiDichVu='" + Global.GetCode(cmbLoaiDichVu) + "'";
            //System.Data.SqlClient.SqlDataReader dr = SQLCmd.ExecuteReader();
            //Global.BindDataReaderToFlex(dr, fgDichVu);
            //fgDichVu.Cols[3].DataType = typeof(bool);
            //dr.Close();
            //SQLCmd.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if (cmbKhoa.SelectedIndex == -1 || cmbLoaiDichVu.SelectedIndex == -1) return;
            //System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
            //System.Data.SqlClient.SqlTransaction trn = Global.ConnectSQL.BeginTransaction();
            //SQLCmd.Transaction = trn;
            //string MaKhoa = Global.GetCode(cmbKhoa);
            //string LoaiDichVu = Global.GetCode(cmbLoaiDichVu);
            //try
            //{
            //    SQLCmd.CommandText = "DELETE FROM KHOA_DICHVU WHERE MaKhoa='" + MaKhoa + "' AND LoaiDichVu='" + LoaiDichVu + "'";
            //    SQLCmd.ExecuteNonQuery();
            //    for (int i = 1; i < fgDichVu.Rows.Count; i++)
            //        if (fgDichVu.GetCellCheck(i,3) == C1.Win.C1FlexGrid.CheckEnum.Checked)
            //        {
            //            SQLCmd.CommandText = string.Format("INSERT INTO KHOA_DICHVU (MaKhoa,LoaiDichVu,MaDichVu) VALUES ('{0}','{1}','{2}')", MaKhoa,LoaiDichVu, fgDichVu[i,1]);
            //            SQLCmd.ExecuteNonQuery();
            //        }
            //    trn.Commit();
            //    MessageBox.Show("Cập nhật thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //catch (Exception ex)
            //{
            //    trn.Rollback();
            //    MessageBox.Show("Có lỗi khi ghi dữ liệu\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //finally
            //{
            //    SQLCmd.Dispose();
            //    trn.Dispose();
            //}
        }

        private void fgLoaiDichVu_Click(object sender, EventArgs e)
        {
            fgLoaiDichVu.Redraw = false;
            if (fgLoaiDichVu.GetDataDisplay(fgLoaiDichVu.Row, "TenTieuChiChiTiet").ToString() != "")
            {
                txtTieuChi.Text = fgLoaiDichVu.GetDataDisplay(fgLoaiDichVu.Row, "TenTieuChiChiTiet").ToString();
            }
            else
            {
                txtTieuChi.Text = fgLoaiDichVu.GetDataDisplay(fgLoaiDichVu.Row, "TenTieuChi").ToString();
            }
            fgLoaiDichVu.Redraw = true;
            fgLoaiDichVu.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictCols;
            fgLoaiDichVu.Cols[0].AllowMerging = true;
            fgLoaiDichVu.Cols[1].AllowMerging = true;
            fgLoaiDichVu.Cols[2].AllowMerging = true;
            fgLoaiDichVu.Cols[3].AllowMerging = true;
            fgLoaiDichVu.Cols[4].AllowMerging = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            fgLoaiDichVu.Redraw = false;
            txtTongHop.Text = "";
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            SQLCmd.CommandText = string.Format("select ('- '+ A.TenNhom + ' ' + convert(nvarchar(3),sum(thucte)) + ' / ' + Convert(nvarchar(3),count(sl)) + CHAR(13) ) as Tonghop"
                                + " from(select Id_TieuChi as sl, case when Soluong_Thucte = sl_Mau then 1 else 0 end as thucte, TenNhom from"
                                + " (select a.Id_Nhom, a.Id_TieuChi, a.TenTieuChi, a.Muc, count(a.Id_TieuChi_CT) as sl_Mau, (select count(Tbl_TT54.DanhGia) From NAMDINH_QLBN.dbo.Tbl_TT54  where NAMDINH_QLBN.dbo.Tbl_TT54.DanhGia = 1 and Tbl_TT54.Id_TieuChi = a.Id_Tieuchi and Tbl_TT54.Id_BenhVien = {0} group by Tbl_TT54.Id_TieuChi) as Soluong_Thucte from NAMDINH_QLBN.dbo.Tbl_TT54 a"
                                + " where a.Id_BenhVien = {0}"
                                + " group by a.Id_Nhom, a.Id_TieuChi, a.TenTieuChi, a.Muc) tonghop"
                                + " inner join NAMDINH_QLBN.dbo.tbl_NhomTT54 nhom on nhom.Id_Nhom = tonghop.Id_Nhom ) A"
                                + " group by A.TenNhom", Global.GetCode(cmbKhoa));
            dr = SQLCmd.ExecuteReader();
            while (dr.Read())
            {
                txtTongHop.Text += dr["Tonghop"].ToString();
            }
            dr.Close();
            SQLCmd.Dispose();
            fgLoaiDichVu.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictCols;
            fgLoaiDichVu.Cols[0].AllowMerging = true;
            fgLoaiDichVu.Cols[1].AllowMerging = true;
            fgLoaiDichVu.Cols[2].AllowMerging = true;
            fgLoaiDichVu.Cols[3].AllowMerging = true;
            fgLoaiDichVu.Cols[4].AllowMerging = true;
        }
    }
}