using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GlobalModuls;
using System.Data.SqlClient;
using System.Net;
using C1.C1Excel;
using System.Collections.Specialized;
using System.IO;
using System.Data.OleDb;


namespace NamDinh_QLBN.Forms.DuLieu
{
    public partial class frmLocHosoBA : Form
    {
        public frmLocHosoBA()
        {
            InitializeComponent();
            fgDichVu.Enabled = false;
            btn_.Enabled = false;
            cmbLoaiDV.Enabled = false;
            label1.Enabled = false;
        }
        private string s = "";
        public C1.C1Excel.C1XLBook _book;
        private void btn_ChonNgay_Click(object sender, EventArgs e)
        {
            string ss = string.Format("{0:dd/MM/yyyy}", txtNgayChiDinh.Text);
            s = "'" + ss + "'," + s;
            textBox2.Text = s;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            if (chk_Ngay.Checked == false)
            {
                SQLCmd.CommandText = "select a.SoHSBA ,a.SoLuuTru as SLT_KH,HoTen,Namsinh,NgayRaVien,TenKhoa,b.Soluutru as SLT_KT,b.ThoigianThanhtoan FROM BENHNHAN_CHITIET  a inner join NAMDINH_VIENPHI.DBO.tblTHANHTOANBHYT B ON A.MaVaoVien = B.MaKhambenh"
                + " WHERE TrangThai=1 ";

                SQLCmd.CommandText += string.Format("and b.Phieuhuy = 0 and b.MAKHOA != 'NV120101' AND convert(varchar,ngayravien, 103)  IN ({0})", textBox2.Text.Substring(0, textBox2.Text.Length - 1));
                SQLCmd.CommandText += " ORDER BY A.SoLuuTru,TenKhoa";
            }
            else
            {
                SQLCmd.CommandText = string.Format("SET DATEFORMAT DMY "
                                        + " select a.SoHSBA ,a.SoLuuTru as SLT_KH,HoTen,Namsinh,NgayRaVien,TenKhoa,'' as SLT_KT,'' as ThoigianThanhtoan FROM BENHNHAN_CHITIET  a inner join NAMDINH_QLBN.dbo.ViewKHOAHIENTAI b ON a.MaVaoVien = b.MaVaoVien"
                                        + " INNER JOIN   NAMDINH_QLBN.dbo.DMKHOAPHONG c ON c.MaKhoa = b.MaKhoa"
                                        + " INNER JOIN NAMDINH_QLBN.dbo.BENHNHAN d ON d.MaBenhNhan = a.MaBenhNhan"
                                        + " WHERE a.DaRaVien = 1 AND a.NgayRaVien > '01/01/2023' AND a.NgayRaVien <  '{0:dd/MM/yyyy}'  AND((a.SoLuuTru IS NULL) OR(RTRIM(a.SoLuuTru)) = '') AND b.MaKhoa ! = 'NV120101'"
                                        + " ORDER BY c.TenKhoa,a.NgayRaVien", txtNgayChiDinh.Value);
            }
            dr = SQLCmd.ExecuteReader();
            fgDanhSach.Tag = "0";
            fgDanhSach.Rows.Count = 1;
            fgDanhSach.ClipSeparators = "|;";
            while (dr.Read())
            {
                fgDanhSach.AddItem(string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}", fgDanhSach.Rows.Count,
                    dr["SoHSBA"],
                    dr["SLT_KH"],
                    dr["HoTen"],
                    dr["Namsinh"],
                    dr["NgayRaVien"],
                    dr["TenKhoa"],
                    dr["SLT_KT"],
                    dr["ThoigianThanhtoan"]));
            }
            dr.Close();
            fgDanhSach.AutoSizeCols();
            fgDanhSach.Tag = "1";
            SQLCmd.Dispose();

        }

        private void fg_ngay_CellChanged(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {


            string TenFile;
            System.Windows.Forms.SaveFileDialog dg = new SaveFileDialog();
            dg.Filter = "Xuất số liệu ra file Excel (*.xls)|*.xls";
            dg.FilterIndex = 0;
            dg.CheckFileExists = false;
            dg.Title = "Nhập tên file để kết xuất số liệu.";
            if (dg.ShowDialog() == DialogResult.OK)
                TenFile = dg.FileName;
            else
                return;
            if (TenFile.Split(".".ToCharArray()).Length < 2)
                TenFile = TenFile + ".xls";
            fgDanhSach.SaveExcel(TenFile, "BaoCao", C1.Win.C1FlexGrid.FileFlags.IncludeFixedCells);
            MessageBox.Show("Bạn đã lưu thành công file " + TenFile + " !");
        }

        private void button3_Click(object sender, EventArgs e)
        {

            NamDinh_QLBN.Reports.BaoCaoNoiTru.repthongkeRutHSBA rep = new NamDinh_QLBN.Reports.BaoCaoNoiTru.repthongkeRutHSBA(textBox2.Text.Substring(0, textBox2.Text.Length - 1));
            rep.Show();
        }

        private void btn_Click(object sender, EventArgs e)
        {

            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            string s = fgDichVu.GetDataDisplay(fgDichVu.Row, "MaDichVu");
            SQLCmd.CommandText = "select distinct a.SoHSBA ,a.SoLuuTru as SLT_KH,HoTen,Namsinh,NgayRaVien,TenKhoa,b.Soluutru as SLT_KT,b.ThoigianThanhtoan FROM BENHNHAN_CHITIET  a inner join NAMDINH_VIENPHI.DBO.tblTHANHTOANBHYT B ON A.MaVaoVien = B.MaKhambenh inner join NAMDINH_VIENPHI.dbo.tblTHANHTOANBHYT_CT  ct on ct.ID =  b.ID"
                + " Inner join temp_hosoba c on c.madichvu = ct.madichvu "
                + " WHERE TrangThai=1 ";
            SQLCmd.CommandText += string.Format("and b.Phieuhuy = 0 and b.MAKHOA != 'NV120101'  AND convert(varchar,ngayravien, 103)  IN ({0}) Union all select distinct A.MaKhambenh AS SoHSBA , 'KHOAKB' as SLT_KH,HoTen,Namsinh,A.THOIGIANDANGKY AS NgayRaVien,b.TenKhoa,b.Soluutru as SLT_KT,b.ThoigianThanhtoan FROM NAMDINH_KHAMBENH.DBO.tblKHAMBENH  a inner join NAMDINH_VIENPHI.DBO.tblTHANHTOANBHYT B ON A.MaKhambenh = B.MaKhambenh  join NAMDINH_VIENPHI.dbo.tblTHANHTOANBHYT_CT  ct on ct.ID =  b.ID  Inner join temp_hosoba c on c.madichvu = ct.madichvu   WHERE b.Phieuhuy = 0 and b.MAKHOA != 'NV120101'  AND convert(varchar,b.ThoigianThanhtoan, 103) IN ({0})", textBox2.Text.Substring(0, textBox2.Text.Length - 1));
            SQLCmd.CommandText += string.Format(" ");
            SQLCmd.CommandText += " ORDER BY A.SoLuuTru,TenKhoa  delete from [temp_hosoba] ";
            dr = SQLCmd.ExecuteReader();
            fgDanhSach.Tag = "0";
            fgDanhSach.Rows.Count = 1;
            fgDanhSach.ClipSeparators = "|;";
            while (dr.Read())
            {
                fgDanhSach.AddItem(string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}", fgDanhSach.Rows.Count,
                    dr["SoHSBA"],
                    dr["SLT_KH"],
                    dr["HoTen"],
                    dr["Namsinh"],
                    dr["NgayRaVien"],
                    dr["TenKhoa"],
                    dr["SLT_KT"],
                    dr["ThoigianThanhtoan"]));
            }
            dr.Close();
            fgDanhSach.AutoSizeCols();
            fgDanhSach.Tag = "1";
            SQLCmd.Dispose();
            //string ss = string.Format("{0:dd/MM/yyyy}", txtNgayChiDinh.Text);
            //Form frm = new frmNhapChiDinhChiPhi(fgDanhSach,"1", "CN2", DateTime.Parse("01/01/2001"));
            //frm.Show();
        }

        private void cmbLoaiDV_TextChanged(object sender, EventArgs e)
        {
            if (cmbLoaiDV.Tag.ToString() == "0" || cmbLoaiDV.SelectedIndex == -1) return;
            //txtTenDV.Text = "";
            fgDichVu.Rows.Count = 1;
            Load_DMDichVu();
        }

        private void Load_DMDichVu()
        {
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
            SQLCmd.CommandText = string.Format("select 0 As Chọn,Madichvu,TenDichvu,dvt from NAMDINH_QLBN.DBO.DMLENCHIPHI_BYKHOID where Khongsudung = 0 and LoaiDichvu = '{0}'", Global.GetCode(cmbLoaiDV));
            System.Data.SqlClient.SqlDataReader dr = SQLCmd.ExecuteReader();
            //fgDichVu.Tag = "0";
            Global.BindDataReaderToFlex(dr, fgDichVu);
            fgDichVu.Styles.Normal.WordWrap = true;
            //fgDichVu.Cols[3].Width = 350;
            //fgDichVu.AutoSizeRows();
            fgDichVu.Cols[1].DataType = typeof(bool);
            //fgDichVu.Cols[2].Visible = false;
            //fgDichVu.Cols[3].AllowEditing = fgDichVu.Cols[4].AllowEditing = fgDichVu.Cols[6].AllowEditing = false;
            //fgDichVu.Cols[fgDichVu.Cols.Count - 5].Visible = false;
            //fgDichVu.Cols[fgDichVu.Cols.Count - 4].Visible = false;
            ////fgDichVu.Cols[fgDichVu.Cols["is_tinhphi"].Index].Visible = false;
            //fgDichVu.Cols[fgDichVu.Cols.Count - 3].Caption = "SL Tồn";
            //fgDichVu.Tag = "1";
            dr.Close();
            SQLCmd.Dispose();
        }

        private void frmLocHosoBA_Load(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
            SQLCmd.CommandText = "SELECT a.* FROM DMLOAIDICHVU a INNER JOIN KHOA_LOAIDICHVU b ON a.MaLoaiDichVu=b.LoaiDichVu WHERE NoiTru_NgoaiTru in (1,3)  AND b.MaKhoa= 'CN2' order by a.thutuchonchidinh";
            System.Data.SqlClient.SqlDataReader dr = SQLCmd.ExecuteReader();
            cmbLoaiDV.Tag = "0";
            while (dr.Read())
            {
                cmbLoaiDV.AddItem(string.Format("{0};{1}", dr["MaLoaiDichVu"], dr["TenLoaiDichVu"]));
            }
            dr.Close();
            cmbLoaiDV.SelectedIndex = -1;
            cmbLoaiDV.Tag = "1";
        }

        private void txtTenDV_TextChanged(object sender, EventArgs e)
        {
            //Load_DMDichVu(txtTenDV.Text.Trim());
        }


        private void fgDichVu_AfterEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {

        }

        private void fgDichVu_Click(object sender, EventArgs e)
        {
            //System.Data.SqlClient.SqlDataReader dr1;
            System.Data.SqlClient.SqlCommand SQLCmd1 = new System.Data.SqlClient.SqlCommand();
            SQLCmd1.Connection = GlobalModuls.Global.ConnectSQL;
            try
            {
                //SQLCmd1.CommandText = String.Format("CREATE TABLE [dbo].[temp_hosoba]([madichvu] [nvarchar](50) NULL,	[NgayChiDinh] [nvarchar](50) NULL,) ON [PRIMARY]");
                for (int i = 1; i < fgDichVu.Rows.Count; i++)
                {
                    if (fgDichVu.GetCellCheck(i, 1) == C1.Win.C1FlexGrid.CheckEnum.Checked)
                    {
                        string madichvu = fgDichVu[i, "MadichVu"].ToString();
                        SQLCmd1.CommandText = String.Format("if(exists(select MADICHVU from temp_hosoba where MaDichVu = '{0}'))"
                            + " update tblSoTaydichvu_CT set MaDichVu = '{0}' where MaDichVu = '{0}'"
                            + " else"
                            + " insert into temp_hosoba(MaDichVu) values('{0}')", madichvu);
                        SQLCmd1.ExecuteNonQuery();
                    }
                    else
                    {
                        string madichvu = fgDichVu[i, "MadichVu"].ToString();
                        SQLCmd1.CommandText = String.Format("delete from temp_hosoba where MaDichVu = '{0}'", madichvu);
                        SQLCmd1.ExecuteNonQuery();
                    }
                }

            }
            catch { MessageBox.Show("sdasd"); }
            finally
            {
                SQLCmd1.Dispose();
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlCommand SQLCmd1 = new System.Data.SqlClient.SqlCommand();
            SQLCmd1.Connection = GlobalModuls.Global.ConnectSQL;
            SQLCmd1.CommandText = String.Format("delete from temp_hosoba");
            SQLCmd1.ExecuteNonQuery();
            SQLCmd1.Dispose();
            btn_.Enabled = true;
            fgDichVu.Enabled = true;
            cmbLoaiDV.Enabled = true;
            label1.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection cnn = new OleDbConnection();
                cnn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=C:\Rutbenhnhan_mavaovien\ImportExcel1.xls" +
                    @"; Extended Properties=""Excel 8.0; HDR=Yes; IMEX=1; ImportMixedTypes=Text; TypeGuessRows=1""";
                OleDbCommand cmd = new OleDbCommand
                (
                    "SELECT * FROM [SHEET1$]", cnn
                );
                OleDbDataAdapter adt = new OleDbDataAdapter(cmd);
                DataSet ds = new DataSet();
                adt.Fill(ds);
                fgDichVu.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error!" + ex.Message);
            }
            string s = "";
            for (int i = 1; i < fgDichVu.Rows.Count; i++)
            {
                s = s + "'"+fgDichVu[i, "MA_BN"].ToString() + "',";
            }
            textBox2.Text = s;

            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            SQLCmd.CommandText = "select distinct a.SoHSBA ,a.SoLuuTru as SLT_KH,HoTen,Namsinh,NgayRaVien,TenKhoa,b.Soluutru as SLT_KT,b.ThoigianThanhtoan,a.MaVaoVien FROM BENHNHAN_CHITIET  a inner join NAMDINH_VIENPHI.DBO.tblTHANHTOANBHYT B ON A.MaVaoVien = B.MaKhambenh"
                + " WHERE a.TrangThai=1 and b.Phieuhuy = 0 ";
            SQLCmd.CommandText += string.Format("and b.Phieuhuy = 0 and b.MAKHOA != 'NV120101'  AND b.makhambenh  IN ({0}) Union all select distinct A.MaKhambenh AS SoHSBA , 'KHOAKB' as SLT_KH,HoTen,Namsinh,A.THOIGIANDANGKY AS NgayRaVien,b.TenKhoa,b.Soluutru as SLT_KT,b.ThoigianThanhtoan, '' as MaVaoVien FROM NAMDINH_KHAMBENH.DBO.tblKHAMBENH  a inner join NAMDINH_VIENPHI.DBO.tblTHANHTOANBHYT B ON A.MaKhambenh = B.MaKhambenh WHERE b.Phieuhuy = 0 and b.MAKHOA != 'NV120101'  AND b.makhambenh IN ({0})", textBox2.Text.Substring(0, textBox2.Text.Length - 1));
            SQLCmd.CommandText += " ORDER BY A.SoLuuTru,TenKhoa";
            dr = SQLCmd.ExecuteReader();
            fgDanhSach.Redraw = true;
            fgDanhSach.Tag = "0";
            fgDanhSach.Rows.Count = 1;
            fgDanhSach.ClipSeparators = "|;";
            while (dr.Read())
            {
                fgDanhSach.AddItem(string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}", fgDanhSach.Rows.Count,
                    dr["SoHSBA"],
                    dr["SLT_KH"],
                    dr["HoTen"],
                    dr["Namsinh"],
                    dr["NgayRaVien"],
                    dr["TenKhoa"],
                    dr["SLT_KT"],
                    dr["ThoigianThanhtoan"],
                    dr["MaVaoVien"]));
            }
            dr.Close();
            fgDanhSach.AutoSizeCols();
            fgDanhSach.Tag = "1";
            SQLCmd.Dispose();
        }
    
    }
}
