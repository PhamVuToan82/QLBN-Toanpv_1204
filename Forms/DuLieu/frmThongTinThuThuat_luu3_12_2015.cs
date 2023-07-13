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
    public partial class frmThongTinThuThuat_luu3_12_2015 : Form
    {
        public frmThongTinThuThuat_luu3_12_2015()
        {
            InitializeComponent();
        }

        private void cmdThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void LoadDM()
        {
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            try
            {
                cmbKhoa.ClearItems();
                SQLCmd.CommandText = "SELECT * FROM DMKHOAPHONG WHERE MaKhoa IN " + Global.glbKhoa_CapNhat;
                dr = SQLCmd.ExecuteReader();
                cmbKhoa.Tag = "0";
                cmbKhoa.ClearItems();
                while (dr.Read())
                {
                    cmbKhoa.AddItem(string.Format("{0}|{1}", dr["TenKhoa"], dr["MaKhoa"]));
                }
                dr.Close();
                cmbKhoa.SelectedIndex = 0;
                cmbKhoa.Tag = "1";

                cmbDoituongBN1.ClearItems();
                cmbDoituongBN1.AddItem(String.Format("{1}|{0}", "", "------ Tất cả các đối tượng ------"));
                SQLCmd.CommandText = "Select MaDT, TenDT from DMDoiTuongBN order by MaDT";
                dr = SQLCmd.ExecuteReader();
                while (dr.Read())
                {
                    cmbDoituongBN1.AddItem(String.Format("{1}|{0}", dr["MaDT"], dr["TenDT"]));
                }
                dr.Close();
                cmbDoituongBN1.SelectedIndex = 0;

                cmbDTBHXH.ClearItems();
                cmbDTBHXH.AddItem(String.Format("{1}|{0}", "", "------ Tất cả các đối tượng BHXH ------"));
                SQLCmd.CommandText = "Select MaDT, MaDT + ' - ' + TenDT as TenDT from DMDTTHE_BHYT order by MaDT";
                dr = SQLCmd.ExecuteReader();
                cmbDTBHXH.Tag = "1";
                while (dr.Read())
                {
                    cmbDTBHXH.AddItem(String.Format("{1}|{0}", dr["MaDT"], dr["TenDT"]));
                }
                dr.Close();
                cmbDTBHXH.SelectedIndex = 0;
                dtNgayRVDen.Value = Global.NgayLV.AddDays(1);
                txtNgayThucHien.Value = Global.NgayLV;
                dtNgayRVTu.Value = new DateTime(Global.NgayLV.Year, Global.NgayLV.Month, 1);
            }
            catch
            {
            }
            finally
            {
                SQLCmd.Dispose();
            }
        }

        private void frmThongTinThuThuat_Load(object sender, EventArgs e)
        {
            fgDanhSach.Tag = 0;
            fgDichVu.Tag = 0;
            fgDichVu.Tree.Column = 4;
            fgDichVu.ClipSeparators = "|;";
            fgDichVu.Cols["LoaiDichVu"].Visible = fgDichVu.Cols["MaDichVu"].Visible = fgDichVu.Cols["TenLoaiDV"].Visible = false;
            C1.Win.C1FlexGrid.CellStyle cs = fgDichVu.Styles[C1.Win.C1FlexGrid.CellStyleEnum.Subtotal0];
            cs.BackColor = Color.LightBlue;
            cs.ForeColor = Color.DarkBlue;
            LoadDM();
            cmdTimKiem_Click(sender, e);
            fgDanhSach.Tag = 1;
            fgDichVu.Tag = 1;
        }

        private void Format_Grid()
        {
            fgDichVu.Redraw = false;
            fgDichVu.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.Clear, 0, 0, 0);
            fgDichVu.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.Sum, 0, 2, fgDichVu.Cols["ThanhTien"].Index, "{0}");
            int TT = 1;
            int SoKhoan = 0;
            for (int i = 1; i < fgDichVu.Rows.Count; i++)
            {
                if (fgDichVu.Rows[i].IsNode) TT = 1;
                else
                {
                    fgDichVu[i, 0] = TT;
                    TT++;
                    SoKhoan++;
                }
            }
            fgDichVu.AutoSizeCols();
            fgDichVu.Redraw = true;
            lblDichVu.Text = "Dịch vụ y tế chỉ định ( " + SoKhoan.ToString() + " ) khoản";
        }

        private void rdTatCa_CheckedChanged(object sender, EventArgs e)
        {
            if (rdTatCa.Checked)
            {
                dtNgayRVDen.Enabled = dtNgayRVTu.Enabled = false;
            }
            else
            {
                dtNgayRVDen.Enabled = dtNgayRVTu.Enabled = true;
            }
        }

        private void cmdTimKiem_Click(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            try
            {
                SQLCmd.CommandText = String.Format("SELECT AA.*,CT.LOAIDICHVU,CT.DOITUONGBN FROM "
                    + " (SELECT A.HOTEN,YEAR(GETDATE()) - A.NAMSINH AS TUOI,B.MAVAOVIEN,V.NGAYCHUYEN AS NGAYVAOKHOA,"
                    + " C.SOPHIEU,B.MADTBHYT,VV.DOITUONG,C.NgayChiDinh,C.Nhom FROM"
                    + " (BENHNHAN A INNER JOIN BENHNHAN_CHITIET B ON B.MABENHNHAN = A.MABENHNHAN )"
                    + " INNER JOIN BENHNHAN_PHIEUDIEUTRI C ON C.MAVAOVIEN = B.MAVAOVIEN"
                    + " INNER JOIN VIEWKHOAHIENTAI V ON V.MAVAOVIEN = B.MAVAOVIEN and v.user_name = N'{4}' INNER "
                    + " JOIN VIEWDOITUONGHIENTAI VV ON VV.MAVAOVIEN = B.MAVAOVIEN "
                    + " WHERE B.SOHSBA LIKE '%{0}%' AND B.MAVAOVIEN LIKE '%{1}%' AND C.MAKHOA='{3}') AA"
                    + " INNER JOIN PHIEUDIEUTRI_CHITIET CT ON CT.SOPHIEU = AA.SOPHIEU"
                    + " INNER JOIN THUTHUAT_KHOA ON THUTHUAT_KHOA.LOAIDICHVU = CT.LOAIDICHVU AND THUTHUAT_KHOA.MAKHOA='{3}'"
                    + " WHERE AA.HOTEN LIKE '%{2}%'",
                    txtSoHSBA1.Text.Trim(),
                    txtMaBNTK.Text.Trim(),
                    txtHoTenTK.Text.Trim(),
                    cmbKhoa.Columns[1].CellText(cmbKhoa.SelectedIndex),
                    Global.glbUName);
                if (rdNgayCD.Checked)
                {
                    SQLCmd.CommandText += String.Format(" And Datediff(dd,aa.NgayChiDinh,'{0:MM/dd/yyyy}') <= 0 And Datediff(dd,aa.NgayChiDinh,'{1:MM/dd/yyyy}') >= 0", dtNgayRVTu.Value, dtNgayRVDen.Value);
                }
                if (cmbDoituongBN1.SelectedIndex > 0)
                {
                    SQLCmd.CommandText += String.Format(" And aa.DoiTuong = '{0}'", cmbDoituongBN1.Columns[1].CellText(cmbDoituongBN1.SelectedIndex)); 
                }
                if (cmbDTBHXH.SelectedIndex > 0)
                {
                    SQLCmd.CommandText += String.Format(" And aa.MADTBHYT = '{0}'", cmbDTBHXH.Columns[1].CellText(cmbDTBHXH.SelectedIndex)); 
                }

                SQLCmd.CommandText += " GROUP BY HOTEN,TUOI,MAVAOVIEN,NGAYVAOKHOA,AA.SOPHIEU,MADTBHYT,DOITUONG,NGAYCHIDINH,CT.LOAIDICHVU,CT.DOITUONGBN,NHOM";
                dr = SQLCmd.ExecuteReader();
                fgDanhSach.Rows.Count = 1;
                cmbTenThuThuat.ClearItems();
                while (dr.Read())
                {
                    fgDanhSach.Rows.Add();
                    fgDanhSach[fgDanhSach.Rows.Count - 1, "STT"] = fgDanhSach.Rows.Count - 1;
                    fgDanhSach[fgDanhSach.Rows.Count - 1, "MaVaoVien"] = dr["MaVaoVien"];
                    fgDanhSach[fgDanhSach.Rows.Count - 1, "TenBN"] = dr["HoTen"];
                    fgDanhSach[fgDanhSach.Rows.Count - 1, "Tuoi"] = dr["Tuoi"];
                    fgDanhSach[fgDanhSach.Rows.Count - 1, "NgayVaoVien"] = dr["NgayVaoKhoa"];
                    fgDanhSach[fgDanhSach.Rows.Count - 1, "SoPhieu"] = dr["SoPhieu"];
                    fgDanhSach[fgDanhSach.Rows.Count - 1, "DoiTuong"] = dr["DoiTuongBN"];
                    fgDanhSach[fgDanhSach.Rows.Count - 1, "Nhom"] = dr["Nhom"];
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

        private void fgDanhSach_AfterRowColChange(object sender, C1.Win.C1FlexGrid.RangeEventArgs e)
        {
            if (fgDanhSach.Tag.ToString() == "0") return;
            if (fgDichVu.Tag.ToString() == "0") return;
            if (fgDanhSach.Row < 0) return;
            cmbTenThuThuat.Tag = 0;
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            try
            {
                SQLCmd.CommandText = String.Format("Select phieudieutri_chitiet.madichvu,dmdichvu.tendichvu from phieudieutri_chitiet inner join thuthuat_khoa on "
                    + " thuthuat_khoa.loaidichvu = phieudieutri_chitiet.loaidichvu "
                    + " inner join dmdichvu on dmdichvu.madichvu = phieudieutri_chitiet.madichvu where thuthuat_khoa.makhoa='{0}' "
                    + " and phieudieutri_chitiet.sophieu ='{1}'",
                    cmbKhoa.Columns[1].CellText(cmbKhoa.SelectedIndex),
                    fgDanhSach.GetDataDisplay(fgDanhSach.Row,"SoPhieu"));
                cmbTenThuThuat.ClearItems();
                dr = SQLCmd.ExecuteReader();
                while (dr.Read())
                {
                    cmbTenThuThuat.AddItem(String.Format("{0};{1}", dr["madichVu"], dr["tendichvu"]));
                }
                dr.Close();
                cmbTenThuThuat.Tag = 1;
                cmbTenThuThuat_TextChanged(sender,e);
            }
            catch
            {
            }
            finally
            {
                SQLCmd.Dispose();
            }
        }

        private void cmdChiDinh_Click(object sender, EventArgs e)
        {
            if (cmbTenThuThuat.SelectedIndex < 0)
            {
                MessageBox.Show("Chọn thủ thuật!", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            NamDinh_QLBN.Forms.DuLieu.frmNhapChiDinhChiPhi fr = new frmNhapChiDinhChiPhi(fgDichVu, fgDanhSach.GetDataDisplay(fgDanhSach.Row,"DoiTuong"), cmbKhoa.Columns[1].CellText(cmbKhoa.SelectedIndex));
            fr.ShowDialog();
        }

        private void cmbTenThuThuat_TextChanged(object sender, EventArgs e)
        {
            if (cmbTenThuThuat.Tag.ToString() == "0") return;
            if (cmbTenThuThuat.SelectedIndex < 0) return;
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            try
            {
                SQLCmd.CommandText = String.Format("Select DMLOAIDICHVU.TenLoaiDichVu,DMLOAIDICHVU.MaLoaiDichVu,"
                    + "a.MaDichVu as MaChiPhi,a.TenDichVu as 'TenChiPhi',b.MaDichVu as MaThuThuat,b.TenDichVu as 'TenThuThuat',"
                    + "aa.*,aa.SoLuong * aa.Dongia as ThanhTien,a.DVT from "
                    + " (Select * from ChiPhi_ThuThuat Where So_Phieu='{0}' And MaDichVu='{1}') AA"
                    + " Inner join dmDichVu a on a.MaDichVu = AA.MaChiPhi "
                    + " Inner join dmDichVu b on b.MaDichVu = AA.MaDichVu "
                    + " Inner join DMLOAIDICHVU on DMLOAIDICHVU.MaLoaiDichVu = aa.LoaiDichVu",
                    fgDanhSach.GetDataDisplay(fgDanhSach.Row, "SoPhieu"), 
                    Global.GetCode(cmbTenThuThuat));
                dr = SQLCmd.ExecuteReader();
                fgDichVu.Rows.Count = 1;
                while (dr.Read())
                {
                    fgDichVu.Rows.Add();
                    txtGhiChu.Text = dr["GhiChu"].ToString();
                    txtNgayThucHien.Value = dr["NgayThucHien"];
                    fgDichVu[fgDichVu.Rows.Count - 1, "LoaiDichVu"] = dr["MaloaiDichVu"];
                    fgDichVu[fgDichVu.Rows.Count - 1, "TenLoaiDV"] = dr["TenloaiDichVu"];
                    fgDichVu[fgDichVu.Rows.Count - 1, "MaDichVu"] = dr["MaChiPhi"];
                    fgDichVu[fgDichVu.Rows.Count - 1, "TenDichVu"] = dr["TenChiPhi"];
                    fgDichVu[fgDichVu.Rows.Count - 1, "DVTinh"] = dr["DVT"];
                    fgDichVu[fgDichVu.Rows.Count - 1, "SoLuong"] = dr["SoLuong"];
                    fgDichVu[fgDichVu.Rows.Count - 1, "DonGia"] = dr["DonGia"];
                    fgDichVu[fgDichVu.Rows.Count - 1, "ThanhTien"] = dr["ThanhTien"];
                    fgDichVu[fgDichVu.Rows.Count - 1, "GhiChu"] = "";
                    fgDichVu[fgDichVu.Rows.Count - 1, "DaThucHien"] = dr["DaThucHien"];
                    fgDichVu[fgDichVu.Rows.Count - 1, "KhongTinhPhi"] = dr["TinhPhi"];
                    fgDichVu[fgDichVu.Rows.Count - 1, "KhongTinhPhi"] = dr["luotIn"].ToString();
                }
                dr.Close();
                Format_Grid();
            }
            catch
            {
            }
            finally
            {
                SQLCmd.Dispose();
            }
        }

        private void GhiData()
        {
            string DonGia = "";
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            System.Data.SqlClient.SqlTransaction trn = Global.ConnectSQL.BeginTransaction();
            SQLCmd.Transaction = trn;
            try
            {
                Global.wait("Đang thực hiện ...");
                SQLCmd.CommandText = "Select MaNhom from phieudieutri_chitiet where SoPhieu ='" + fgDanhSach.GetDataDisplay(fgDanhSach.Row, "SoPhieu") + "'";
                String MaNhom = SQLCmd.ExecuteScalar().ToString();
                SQLCmd.CommandText = String.Format(" Delete from ChiPhi_ThuThuat Where So_Phieu ='{0}' And MaDichVu='{1}'",
                    fgDanhSach.GetDataDisplay(fgDanhSach.Row, "SoPhieu"),
                    Global.GetCode(cmbTenThuThuat));
                for (int i = 1; i < fgDichVu.Rows.Count; i++)
                {
                    if (fgDichVu.Rows[i].IsNode) continue;
                    DonGia = fgDichVu.GetData(i, "DonGia").ToString().Replace(",", ".");
                    SQLCmd.CommandText += String.Format(" Insert into ChiPhi_ThuThuat(So_Phieu,MaVaoVien,MaDichVu,MaChiPhi,SoLuong,GhiChu,"
                        + "DonGia,NgayThucHien,TinhPhi,DoiTuongBN,LoaiDichVu,MaKhoa,DaThucHien,Nhom,LuotIn,UserName,MaNhom,KhoID) Values("
                    + "'{0}','{1}','{2}','{3}',{4},N'{5}',{6},'{7:MM/dd/yyyy}',{8},'{9}','{10}','{11}',{12},{13},{14},'{15}',{16},{17})",
                    fgDanhSach.GetDataDisplay(fgDanhSach.Row, "SoPhieu"),
                    fgDanhSach.GetDataDisplay(fgDanhSach.Row, "MaVaoVien"),
                    Global.GetCode(cmbTenThuThuat),
                    fgDichVu.GetDataDisplay(i, "MaDichVu"),
                    fgDichVu.GetData(i, "SoLuong"),
                    txtGhiChu.Text.Trim(),
                    DonGia,
                    txtNgayThucHien.Value,
                    (fgDichVu.GetData(i, "KhongTinhPhi").ToString().ToLower() == "true") ? (1) : (0),
                    fgDanhSach.GetDataDisplay(fgDanhSach.Row, "doituong"),
                    fgDichVu.GetDataDisplay(i, "LoaiDichVu"),
                    cmbKhoa.Columns[1].CellText(cmbKhoa.SelectedIndex),
                    (fgDichVu.GetData(i, "DaThucHien").ToString().ToLower() == "false") ? (0) : (1),
                    fgDanhSach.GetDataDisplay(fgDanhSach.Row, "Nhom"),
                    fgDichVu.GetDataDisplay(i, "LuotIn") == "" ? "null" : fgDichVu.GetDataDisplay(i, "LuotIn"),
                    Global.glbUName,
                    MaNhom,
                    fgDichVu.GetData(i, "KhoID").ToString() == "" ? "null" : fgDichVu.GetData(i, "KhoID").ToString());
                }
                if (fgDichVu.Rows.Count <= 1)
                {
                    SQLCmd.CommandText += String.Format(" update phieudieutri_chitiet set dathuchien = 0 where SoPhieu ='{0}' and MaDichVu='{1}'",
                        fgDanhSach.GetDataDisplay(fgDanhSach.Row, "SoPhieu"),
                        Global.GetCode(cmbTenThuThuat));
                }
                else
                {
                    SQLCmd.CommandText += String.Format(" update phieudieutri_chitiet set dathuchien = 1 where SoPhieu ='{0}' and MaDichVu='{1}'",
                        fgDanhSach.GetDataDisplay(fgDanhSach.Row, "SoPhieu"),
                        Global.GetCode(cmbTenThuThuat));
                }
                SQLCmd.ExecuteNonQuery();
                trn.Commit();
            }
            catch
            {
                trn.Rollback();
            }
            finally
            {
                Global.nowait();
                trn.Dispose();
                SQLCmd.Dispose();
            }
        }

        private void cmdGhi_Click(object sender, EventArgs e)
        {
            try
            {
                GhiData();
                cmbTenThuThuat_TextChanged(sender, e);
            }
            catch
            { }
        }

        private void frmThongTinThuThuat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {
                if (cmbTenThuThuat.SelectedIndex < 0)
                {
                    MessageBox.Show("Chọn thủ thuật!", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                NamDinh_QLBN.Forms.DuLieu.frmNhapChiDinhChiPhi fr = new frmNhapChiDinhChiPhi(fgDichVu, fgDanhSach.GetDataDisplay(fgDanhSach.Row, "DoiTuong"), cmbKhoa.Columns[1].CellText(cmbKhoa.SelectedIndex));
                fr.ShowDialog();
            }
            if (e.KeyCode == Keys.F5)
            {
                GhiData();
            }
        }

        private void fgDichVu_AfterEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            try
            {
                int SL = int.Parse(fgDichVu.GetData(e.Row, "SoLuong").ToString());
                double DonGia = double.Parse(fgDichVu.GetData(e.Row, "DonGia").ToString());
                fgDichVu[e.Row, "ThanhTien"] = SL * DonGia;
                fgDichVu.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.Clear, 0, 0, 0);
                fgDichVu.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.Sum, 0, 2, fgDichVu.Cols["ThanhTien"].Index, "{0}");
            }
            catch
            {
            }
        }

        private void fgDichVu_BeforeEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            if ((fgDichVu.Rows[e.Row].IsNode) || (fgDichVu.GetDataDisplay(e.Row,"DaThucHien").ToLower() == "true"))
            {
                e.Cancel = true;
                return;
            }
        }

        private void cmdInPhieu_Click(object sender, EventArgs e)
        {
            if (fgDanhSach.Rows.Count <= 1) return;

            Global.wait("Đang chuẩn bị dữ liệu...!");
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            SQLCmd.CommandText = string.Format("Select aa.*,dmdichvu.tendichvu,dmdichvu.dvt,dmloaidichvu.TenLoaiDichVu, "
                + " DMDOITUONGBN.tendt,dmkhoaphong.tenkhoa,a.tendichvu as tenthuthuat"
                + " from (Select *,SoLuong as sl,soluong * dongia as thanhtien from chiphi_thuthuat "
                + " Where mavaovien = '{0}' and makhoa ='{1}' and  datediff(dd,ngaythuchien,'{2:MM/dd/yyyy} 00:00:00.000') = 0 and madichvu='{3}') aa"
                + " inner join dmdichvu on dmdichvu.madichvu = aa.machiphi"
                + " inner join dmdichvu a on a.madichvu = aa.madichvu"
                + " inner join dmloaidichvu on dmloaidichvu.maloaidichvu = aa.loaidichvu"
                + " inner join dmkhoaphong on dmkhoaphong.makhoa = aa.makhoa"
                + " inner join DMDOITUONGBN on DMDOITUONGBN.madt = aa.doituongbn",
                fgDanhSach.GetDataDisplay(fgDanhSach.Row,"maVaovien"),
                cmbKhoa.Columns[1].CellText(cmbKhoa.SelectedIndex),
                txtNgayThucHien.Value,
                Global.GetCode(cmbTenThuThuat));
            dr = SQLCmd.ExecuteReader();
            NamDinh_QLBN.Reports.rptChiPhi_ThuThuat rpt = new NamDinh_QLBN.Reports.rptChiPhi_ThuThuat
                (fgDanhSach.GetDataDisplay(fgDanhSach.Row, "maVaovien"),
                fgDanhSach.GetDataDisplay(fgDanhSach.Row, "TenBN"),
                fgDanhSach.GetDataDisplay(fgDanhSach.Row, "Tuoi"),
                fgDanhSach.GetDataDisplay(fgDanhSach.Row, "DoiTuong"),
                fgDanhSach.GetDataDisplay(fgDanhSach.Row, "NgayVaoVien"));
            rpt.DataSource = dr;
            rpt.Show();
            dr.Close();
            SQLCmd.Dispose();
            Global.nowait();
        }
    }
}