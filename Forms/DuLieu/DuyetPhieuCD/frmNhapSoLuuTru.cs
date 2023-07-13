using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GlobalModuls;

namespace NamDinh_QLBN.Forms.DuLieu.DuyetPhieuCD
{
    public partial class frmNhapSoLuuTru : Form
    {
        public frmNhapSoLuuTru()
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
            cmbKhoa.ClearItems();
            SQLCmd.CommandText = "SELECT * FROM DMKHOAPHONG WHERE IS_KHOADIEUTRI = 1";
            dr = SQLCmd.ExecuteReader();
            cmbKhoa.Tag = "0";
            cmbKhoa.ClearItems();
            cmbKhoa.AddItem(String.Format("{0}|{1}","------ Tất cả các đối tượng ------","0"));
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

            cmbTrangThai.ClearItems();
            cmbTrangThai.AddItem(String.Format("{1}|{0}", "0", "---------Tất cả---------"));
            cmbTrangThai.AddItem(String.Format("{1}|{0}", "1", "Đã nhập số lưu trữ"));
            cmbTrangThai.AddItem(String.Format("{1}|{0}", "2", "Chưa nhập số lưu trữ"));
            cmbTrangThai.SelectedIndex = 0;
            dtNgayRVDen.Value = Global.NgayLV.AddDays(1);
            dtNgayRVTu.Value = new DateTime(Global.NgayLV.Year, Global.NgayLV.Month, 1);
        }

        private void Load_DSBenhNhan()
        {
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            string MaKhoa = cmbKhoa.Columns[1].CellText(cmbKhoa.SelectedIndex);
            string MaDT = cmbDoituongBN1.Columns[1].CellText(cmbDoituongBN1.SelectedIndex);
            string MaDTBHXH = cmbDTBHXH.Columns[1].CellText(cmbDTBHXH.SelectedIndex);
            SQLCmd.CommandText = string.Format("set dateformat dmy SELECT CASE WHEN THANHTOAN.PHIEUHUY = 0 THEN 1 WHEN THANHTOAN_VIENPHI.PHIEUHUY = 0  THEN 1 ELSE 0 END AS DaTinhPhi, B.MAVAOVIEN,A.HOTEN,YEAR(C.NGAYCHUYEN) - A.NAMSINH AS TUOI,CASE WHEN A.GIOITINH = 0 THEN N'Nữ' ELSE N'Nam' END AS GIOI,"
                + " DMDOITUONGBN.TENDT,C.NGAYCHUYEN AS NGAYVAOVIEN,B.DIACHI,E.GTRITU,E.GTRIDEN,E.MADOITUONGBHXH + E.SOTHE + E.MANOICAP AS SOTHE,NAMDINH_SYSDB.dbo.DMNOIDKKCBBD_BHYT.TENNOICAP AS NOIGIOITHIEU,"
                + " BUONG.TENBUONG,GIUONG.TENGIUONG,B.NGAYRAVIEN,D.CHANDOAN,A.MABENHNHAN,E.TENBHYTCAP AS NOICAPTHE,B.SOHSBA,B.SOLUUTRU,KP.TENKHOA, KP.Makhoa, KP.TENTAT_LUUTRU, B.KetquaDT FROM "
                + " (BENHNHAN A INNER JOIN BENHNHAN_CHITIET B ON A.MABENHNHAN = B.MABENHNHAN)"
                + " INNER JOIN BENHNHAN_KHOA C ON C.MAVAOVIEN = B.MAVAOVIEN AND C.LANCHUYENKHOA = 0"
                + " INNER JOIN VIEWKHOAHIENTAI D ON D.MAVAOVIEN = B.MAVAOVIEN"
                + " INNER JOIN NAMDINH_SYSDB.DBO.DMKHOAPHONG KP ON D.MAKHOA=KP.MAKHOA"
                + " INNER JOIN VIEWDOITUONGHIENTAI E ON E.MAVAOVIEN = B.MAVAOVIEN"
                + " INNER JOIN DMDOITUONGBN ON DMDOITUONGBN.MADT = E.DOITUONG"
                + " LEFT JOIN DMBUONGBENH BUONG ON BUONG.MAKHOA = D.MAKHOA AND BUONG.ID_BUONG = B.BUONG"
                + " LEFT JOIN DMGIUONGBENH GIUONG ON GIUONG.MAKHOA = D.MAKHOA AND GIUONG.ID_GIUONG = B.GIUONG AND GIUONG.ID_BUONG = B.BUONG"
                + " LEFT JOIN NAMDINH_SYSDB.dbo.DMNOIDKKCBBD_BHYT ON E.MANOICAP=NAMDINH_SYSDB.dbo.DMNOIDKKCBBD_BHYT.MANOICAP"
                + " LEFT JOIN NAMDINH_VIENPHI.DBO.tblTHANHTOANBHYT THANHTOAN ON THANHTOAN.MaKhambenh = B.MaVaoVien"
                + " Left join NAMDINH_VIENPHI.DBO.tblPHIEUTHANHTOAN THANHTOAN_VIENPHI ON  THANHTOAN_VIENPHI.Nguoinop_Maso = B.MaVaoVien"
                + " WHERE B.MAVAOVIEN LIKE '{0}%' AND B.SOHSBA LIKE '{1}%'"
                + " AND E.DOITUONG LIKE '{2}%' AND E.MADOITUONGBHXH LIKE '{3}%'"
                + " AND A.HOTEN LIKE N'%{4}%' and B.SoLuuTru like N'%{5}%' ",
                txtMaBNTK.Text.Replace(" ", ""), 
                txtSoHSBA1.Text.Trim(), 
                MaDT, 
                MaDTBHXH,
                txtHoTenTK.Text.Trim(), txtSoLuuTru_TK.Text.Trim());
            if (MaKhoa != "0")
                SQLCmd.CommandText += String.Format(" AND D.MAKHOA='{0}'", MaKhoa);
            dtNgayRVDen.ReadOnly = dtNgayRVTu.ReadOnly = false;
            if (rdTatCa.Checked)
            {
                dtNgayRVDen.ReadOnly = dtNgayRVTu.ReadOnly = true;
                SQLCmd.CommandText += string.Format(" Order by A.HoTen");
            }
            if (rdChuaRV.Checked)
            {
                SQLCmd.CommandText += string.Format(" AND B.DARAVIEN = 0 order by A.HoTen");
            }
            if (rdDaRV.Checked)
            {
                SQLCmd.CommandText += " AND B.DaRaVien=1 AND B.NgayRaVien between '" + string.Format("{0:dd/MM/yyyy}", dtNgayRVTu.Value) + "' and '" + string.Format("{0:dd/MM/yyyy}", dtNgayRVDen.Value) + "' order by A.HoTen";
            }
            dr = SQLCmd.ExecuteReader();
            fgDanhSach.Tag = "0";
            fgDanhSach.Rows.Count = 1;
            fgDanhSach.ClipSeparators = "|;";
            fgDanhSach.Redraw = false;
            while (dr.Read())
            {
                fgDanhSach.AddItem(string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6:dd/MM/yyyy HH:mm}|{7}|{8:dd/MM/yyyy}|{9:dd/MM/yyyy}|{10}|{11}|{12}|{13}|{14:dd/MM/yyyy HH:mm}|{15}|{16}|{17}|{18}|{19}|{20}|{21}|{22}|{23}|{24}", fgDanhSach.Rows.Count,
                    dr["MaVaoVien"],
                    dr["HoTen"],
                    dr["Tuoi"],
                    dr["Gioi"].ToString(),
                    dr["TenDT"],
                    dr["NgayVaoVien"],
                    dr["DiaChi"],
                    dr["GtriTu"],
                    dr["GTriDen"],
                    dr["SoThe"],
                    dr["NoiGioiThieu"],
                    dr["Tenbuong"],
                    dr["TenGiuong"],
                    dr["NgayRaVien"],
                    dr["ChanDoan"],
                    dr["MaBenhNhan"],
                    dr["NoiCapThe"],
                    dr["TenKhoa"],
                    dr["SoHSBA"],
                    dr["SoLuuTru"],
                    Iif(dr["Datinhphi"].ToString() == "1", true , false),
                    dr["Makhoa"],
                    dr["TENTAT_LUUTRU"],
                    dr["KetquaDT"]));
            }
            dr.Close();
            fgDanhSach.AutoSizeCols();
            fgDanhSach.Redraw = true;
            fgDanhSach.Tag = "1";
            if (fgDanhSach.Row >0)
            {
                fgDanhSach_AfterRowColChange(null,null);
            }
            lbTong.Text = "Tổng số bệnh nhân: " + String.Format("{0}", fgDanhSach.Rows.Count - 1);
            
            SQLCmd.Dispose();
        }
                
        public static object Iif(bool cond, object left, object right)
        {
            return cond ? left : right;
        }

        private void frmThongTinCTBN_Load(object sender, EventArgs e)
        {
            
            Global.wait("Đang tổng hợp dữ liệu");
            fgDanhSach.Tag = 0;
            LoadDM();
            fgDanhSach.Tag = 1;
            cdTuNgayIN.Value = Global.GetNgayLV();
            cdDenNgayIn.Value = Global.GetNgayLV();
            Global.nowait();
            groupBox1.Focus();
            txtSoHSBA1.Focus();
        }

        private void rdChuaRV_CheckedChanged(object sender, EventArgs e)
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

        private void rdTatCa_CheckedChanged(object sender, EventArgs e)
        {
            rdChuaRV_CheckedChanged(sender, e);
        }

        private void rdDaRV_CheckedChanged(object sender, EventArgs e)
        {
            rdChuaRV_CheckedChanged(sender, e);
        }

        private void raChuyenKhoa_CheckedChanged(object sender, EventArgs e)
        {
            rdChuaRV_CheckedChanged(sender, e);
        }

        private void cmdTimKiem_Click(object sender, EventArgs e)
        {
            Global.wait("Đang tổng hợp dữ liệu");
            Load_DSBenhNhan();
            Global.nowait();
        }

        private void fgDanhSach_AfterRowColChange(object sender, C1.Win.C1FlexGrid.RangeEventArgs e)
        {
            if (fgDanhSach.Tag.ToString() == "0") return;
            if (fgDanhSach.Rows.Count <= 1) return;
            txtSoHSBA.Text = fgDanhSach.GetDataDisplay(fgDanhSach.Row,"SoHSBA");
            txtNgayRaVien.Value = fgDanhSach.GetDataDisplay(fgDanhSach.Row, "NgayRaVien");
            txtSoLuuTru.Text = fgDanhSach.GetDataDisplay(fgDanhSach.Row, "SoLuuTru");
            
            txtSoLuuTru.Focus();
            tabControl1_SelectedIndexChanged(sender, e);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void raNhomTN_CheckedChanged(object sender, EventArgs e)
        {
            tabControl1_SelectedIndexChanged(sender,e);
        }

        private void cmbLanVaoVien_TextChanged(object sender, EventArgs e)
        {
            
            tabControl1_SelectedIndexChanged(sender, e);
        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            if (txtMaBN.Text == "0") { return; }
            if (fgDanhSach.Rows.Count <= 1) return;
            string MaVaoVien = txtMaBN.Text;

            Global.wait("Đang chuẩn bị dữ liệu...!");
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            SQLCmd.CommandText = string.Format("SELECT a.DoiTuongBN,d.TenDT,e.MaKhoa,f.TenKhoa,a.LoaiDichVu,b.TenLoaiDichVu,a.MaDichVu,c.TenDichVu,c.DVT,Sum(SoLuong * SoThang) As SL,case when a.TinhPhi = 0 then a.DonGia else 0 end as DonGia,Sum(SoLuong * SoThang * (case when a.tinhphi = 0 then a.DonGia else 0 end)) as ThanhTien "
                                        + " FROM ((((PHIEUDIEUTRI_CHITIET a INNER JOIN DMLOAIDICHVU b ON a.LoaiDichVu=b.MaLoaiDichVu) "
                                        + " INNER JOIN DMDICHVU c ON a.MaDichVu=c.MaDichVu) "
                                        + " INNER JOIN DMDOITUONGBN d ON a.DoiTuongBN = d.MaDT) "
                                        + " INNER JOIN BENHNHAN_PHIEUDIEUTRI e ON a.SoPhieu=e.SoPhieu AND e.MaVaoVien='{0}'  ) "
                                        + " INNER JOIN DMKHOAPHONG f ON e.MaKhoa=f.MaKhoa "
                                        + " GROUP BY a.DoiTuongBN,d.TenDT,e.MaKhoa,f.tenKhoa,a.LoaiDichVu,b.TenLoaiDichVu,a.MaDichVu,c.TenDichVu,c.DVT,a.DonGia,a.tinhphi  ", MaVaoVien);
            dr = SQLCmd.ExecuteReader();
            //NamDinh_QLBN.Reports.rptBenhNhan_ChiPhi rpt = new NamDinh_QLBN.Reports.rptBenhNhan_ChiPhi(MaVaoVien, fgDanhSach[fgDanhSach.Row, 2].ToString(), fgDanhSach[fgDanhSach.Row, 3].ToString(), fgDanhSach[fgDanhSach.Row,4].ToString(), fgDanhSach[fgDanhSach.Row, 5].ToString(), fgDanhSach.GetData(fgDanhSach.Row, 6), fgDanhSach[fgDanhSach.Row, "DiaChi"].ToString(), fgDanhSach[fgDanhSach.Row, "HanTheTu"].ToString(), fgDanhSach[fgDanhSach.Row, "HanTheDen"].ToString(), fgDanhSach[fgDanhSach.Row, "SoTheBHYT"].ToString(), fgDanhSach[fgDanhSach.Row, "NoiCapThe"].ToString(), fgDanhSach[fgDanhSach.Row, "Buong"].ToString(), fgDanhSach[fgDanhSach.Row, "Giuong"].ToString(), fgDanhSach.GetData(fgDanhSach.Row, "NgayRaVien"), fgDanhSach[fgDanhSach.Row, "ChanDoan"].ToString(),fgDanhSach.GetDataDisplay(fgDanhSach.Row,"NoiGioiThieu"));
            //rpt.DataSource = dr;
            //rpt.Show();
            //dr.Close();
            //SQLCmd.Dispose();
            //Global.nowait();
        }

        private void txtMaBenhNhan_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void cmdGiayRaVien_Click(object sender, EventArgs e)
        {
            //NamDinh_QLBN.Reports.rptGiayRaVien rpt = new NamDinh_QLBN.Reports.rptGiayRaVien(txtMaBN.Text);
            //rpt.Show();
        }

        private void cmdGiayChuyenVien_Click(object sender, EventArgs e)
        {
            //NamDinh_QLBN.Reports.repPhieuChuyenVien rep = new NamDinh_QLBN.Reports.repPhieuChuyenVien(txtMaBN.Text);
            //rep.Show();
        }

        private void txtSoHSBA1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmdTimKiem_Click(null, null);
            }
        }

        private void txtSoLuuTru_TK_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmdTimKiem_Click(null, null);
            }
        }

        //private void cmdGhi_Click(object sender, EventArgs e)
        //{
        //    if (fgDanhSach.GetDataDisplay(fgDanhSach.Row, "DaThanhToan") == "False")
        //    {
        //        MessageBox.Show("Bệnh nhân chưa thanh toán, không thể nhập số lưu trữ", "Thông báo", MessageBoxButtons.OK);
        //        return;
        //    }
        //    if (txtSoHSBA.Text.Trim() == "")
        //    {
        //        MessageBox.Show("Bệnh nhân chưa có số HSBA, không thể nhập số lưu trữ", "Thông báo",MessageBoxButtons.OK);
        //    }
        //    else
        //    {
        //        if (txtSoLuuTru.Text.Trim() != "")
        //        {
        //            System.Data.SqlClient.SqlDataReader dr;
        //            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
        //            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
        //            SQLCmd.CommandText = "Select SoLuuTru from BenhNhan_ChiTiet where SoLuuTru = '" + txtSoLuuTru.Text.Trim() + "' and MaVaoVien <> '" + fgDanhSach.GetDataDisplay(fgDanhSach.Row, "MaVaoVien") + "'";
        //            dr = SQLCmd.ExecuteReader();
        //            if (dr.Read())
        //            {
        //                MessageBox.Show("Đã có số lưu trữ này, Hãy nhập lại!!", "Thông báo", MessageBoxButtons.OK);
        //                dr.Close();
        //                txtSoLuuTru.Focus();
        //                return;
        //            }
        //            dr.Close();
        //            SQLCmd.CommandText = "Update BENHNHAN_CHITIET set SoLuuTru = '" + txtSoLuuTru.Text.Trim() + "' where MaVaoVien = '" + fgDanhSach.GetDataDisplay(fgDanhSach.Row, "MaVaoVien") + "'";
        //            SQLCmd.ExecuteNonQuery();
        //            fgDanhSach[fgDanhSach.Row, "SoLuuTru"] = txtSoLuuTru.Text.Trim();
        //            MessageBox.Show("Cập nhật thành công!!", "Thông báo", MessageBoxButtons.OK);
        //        }
        //        else
        //        {
        //            MessageBox.Show("Chưa nhập số lưu trữ.", "Thông báo", MessageBoxButtons.OK);
        //        }
        //    }
        //    //label24.Focus();
        //    //txtMaBNTK.Focus();
        //    txtSoHSBA1.Focus();
        //}
        private void cmdGhi_Click(object sender, EventArgs e)
        {
            //if (fgDanhSach.GetDataDisplay(fgDanhSach.Row, "DaThanhToan") == "False")
            //{
            //    MessageBox.Show("Bệnh nhân chưa thanh toán, không thể nhập số lưu trữ", "Thông báo", MessageBoxButtons.OK);
            //    return;
            //}
            //if (txtSoHSBA.Text.Trim() == "")
            //{
            //    MessageBox.Show("Bệnh nhân chưa có số HSBA, không thể nhập số lưu trữ", "Thông báo", MessageBoxButtons.OK);
            //}
            //else
            //{
            //    if (txtSoLuuTru.Text.Trim() == "")
            //    {
                    
            //        int DoDai = 2 + fgDanhSach.GetDataDisplay(fgDanhSach.Row, "TENTAT_LUUTRU").ToString().Trim().Length;
            //        int Nam = Convert.ToInt16(fgDanhSach.GetDataDisplay(fgDanhSach.Row, "NGAYVAOVIEN").Substring(6));
            //        string TiepDauNgu = fgDanhSach.GetDataDisplay(fgDanhSach.Row, "NGAYVAOVIEN").Substring(8) + fgDanhSach.GetDataDisplay(fgDanhSach.Row, "TENTAT_LUUTRU").ToString().Trim();
            //        if (fgDanhSach.GetDataDisplay(fgDanhSach.Row, "KETQUADT").ToString().Trim() == "5" || fgDanhSach.GetDataDisplay(fgDanhSach.Row, "KETQUADT").ToString().Trim() == "6") //Tử vong
            //        {
            //             DoDai = 4;
            //             TiepDauNgu = fgDanhSach.GetDataDisplay(fgDanhSach.Row, "NGAYVAOVIEN").Substring(8) + "TV";
            //        }
            //        System.Data.SqlClient.SqlDataReader dr;
            //        System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            //        SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            //        SQLCmd.CommandType = CommandType.Text; 
            //        //SQLCmd.CommandText = "Select max(SoLuuTru) as Max_LuuTru from BenhNhan_ChiTiet where left(SoLuuTru,@DoDai) = @TiepDauNgu and year(NgayVaoVien) = @Nam";
            //        //SQLCmd.Parameters.Clear();
            //        //SQLCmd.Parameters.AddWithValue("@DoDai",DoDai );
            //        //SQLCmd.Parameters.AddWithValue("@TiepDauNgu",TiepDauNgu );
            //        //SQLCmd.Parameters.AddWithValue("@Nam", Nam);
            //        SQLCmd.CommandText = " Select max(SoLuuTru) as Max_LuuTru from BenhNhan_ChiTiet where left(SoLuuTru,"+ DoDai +") = '"+ TiepDauNgu +"' and year(NgayVaoVien) = "+ Nam +" ";
            //        dr = SQLCmd.ExecuteReader();
            //        if (dr.Read())
            //        {
            //            int temp = 1;
            //            if (dr["Max_LuuTru"].ToString() != "")
            //            {
            //                temp = Convert.ToInt16(dr["Max_LuuTru"].ToString().Substring(DoDai) )+ 1;
            //            }
                          
            //            txtSoLuuTru.Text = TiepDauNgu + temp.ToString() ;
            //        }
            //        dr.Close();
            //        SQLCmd.CommandText = "Update BENHNHAN_CHITIET set SoLuuTru = '" + txtSoLuuTru.Text.Trim() + "' where MaVaoVien = '" + fgDanhSach.GetDataDisplay(fgDanhSach.Row, "MaVaoVien") + "'";
            //        SQLCmd.ExecuteNonQuery();
            //        fgDanhSach[fgDanhSach.Row, "SoLuuTru"] = txtSoLuuTru.Text.Trim();
            //        MessageBox.Show("Cập nhật thành công!!", "Thông báo", MessageBoxButtons.OK);
            //    }
            //    //else
            //    //{
            //    //    MessageBox.Show("Chưa nhập số lưu trữ.", "Thông báo", MessageBoxButtons.OK);
            //    //}
            //}
            ////label24.Focus();
            ////txtMaBNTK.Focus();
            //txtSoHSBA1.Focus();

            if (fgDanhSach.GetDataDisplay(fgDanhSach.Row, "DaThanhToan") == "False")
            {
                MessageBox.Show("Bệnh nhân chưa thanh toán, không thể nhập số lưu trữ", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            if (txtSoHSBA.Text.Trim() == "")
            {
                MessageBox.Show("Bệnh nhân chưa có số HSBA, không thể nhập số lưu trữ", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                System.Data.SqlClient.SqlDataReader dr;
                System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
                SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
                SQLCmd.CommandType = CommandType.Text;
                if (txtSoLuuTru.Text.Trim() == "")
                {
                    int DoDai = 2 + fgDanhSach.GetDataDisplay(fgDanhSach.Row, "TENTAT_LUUTRU").ToString().Trim().Length;
                    int Nam = Convert.ToInt16(fgDanhSach.GetDataDisplay(fgDanhSach.Row, "NGAYVAOVIEN").Substring(6));
                    string TiepDauNgu = fgDanhSach.GetDataDisplay(fgDanhSach.Row, "NGAYVAOVIEN").Substring(8) + fgDanhSach.GetDataDisplay(fgDanhSach.Row, "TENTAT_LUUTRU").ToString().Trim();
                    if (fgDanhSach.GetDataDisplay(fgDanhSach.Row, "KETQUADT").ToString().Trim() == "5" || fgDanhSach.GetDataDisplay(fgDanhSach.Row, "KETQUADT").ToString().Trim() == "6") //Tử vong
                    {
                        DoDai = 4;
                        TiepDauNgu = fgDanhSach.GetDataDisplay(fgDanhSach.Row, "NGAYVAOVIEN").Substring(8) + "TV";
                    }
                    if (Nam >= 2016)
                    {
                        SQLCmd.CommandText = " Select  max(cast(right(SoLuuTru,len(SoLuuTru)-" + DoDai + ") as int)) as Max_LuuTru from BenhNhan_ChiTiet where left(SoLuuTru," + DoDai + ") = '" + TiepDauNgu + "' and year(NgayVaoVien) = " + Nam + " ";
                        dr = SQLCmd.ExecuteReader();
                        if (dr.Read())
                        {
                            int temp = 1;
                            if (dr["Max_LuuTru"].ToString() != "")
                            {
                                //temp = Convert.ToInt16(dr["Max_LuuTru"].ToString().Substring(DoDai)) + 1;
                                temp = Convert.ToInt16(dr["Max_LuuTru"].ToString()) + 1;
                            }

                            txtSoLuuTru.Text = TiepDauNgu + temp.ToString();
                        }
                        dr.Close();
                    }
                }
                SQLCmd.CommandText = "Update BENHNHAN_CHITIET set SoLuuTru = '" + txtSoLuuTru.Text.Trim() + "' where MaVaoVien = '" + fgDanhSach.GetDataDisplay(fgDanhSach.Row, "MaVaoVien") + "'";
                SQLCmd.ExecuteNonQuery();
                fgDanhSach[fgDanhSach.Row, "SoLuuTru"] = txtSoLuuTru.Text.Trim();
                MessageBox.Show("Cập nhật thành công!!", "Thông báo", MessageBoxButtons.OK);
            }
            txtSoHSBA1.Focus();
        }
        private void frmNhapSoLuuTru_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                cmdGhi_Click(null,null);
            }
        }

        private void cmdTK_Click(object sender, EventArgs e)
        {
            Global.wait("Đang tổng hợp số liệu...");
            NamDinh_QLBN.Forms.DuLieu.DuyetPhieuCD.repDSBNRaVien_LT rpt = new repDSBNRaVien_LT((DateTime)cdTuNgayIN.Value, (DateTime)cdDenNgayIn.Value, cmbKhoa.Columns[1].CellText(cmbKhoa.SelectedIndex), "", cmbTrangThai.Columns[1].CellText(cmbTrangThai.SelectedIndex));
            arvMain.Document = rpt.Document;
            rpt.Run();
            Global.nowait();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Form frm = new frmLocHosoBA();
            frm.Show();
        }
    }
}