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
    public partial class frmChuyenKhoa : Form
    {
        private bool Add, Edit;
        public string MaBN;
        public int LanVV;

        public frmChuyenKhoa()
        {
            InitializeComponent();
        }

        private void EnableEdit(bool Flag)
        {
            txtNgayChuyen.ReadOnly = !Flag;
            cmbChuyenDenKhoa.ReadOnly = !Flag;

            cmdGhi.Visible = Flag;
            cmdKhongGhi.Visible = Flag;
            cmdThemMoi.Visible = !Flag;
            cmdXoa.Visible = !Flag;
            cmdSua.Visible = !Flag;
            cmdThoat.Visible = !Flag;
            fgDanhSach.Enabled = !Flag;
            fgDoiTuong.Enabled = !Flag;

            cmbKhoa.ReadOnly = Flag;
            rdChuaRV.Enabled = !Flag;
            rdDaRV.Enabled = !Flag;
            rdTatCa.Enabled = !Flag;
            raChuyenKhoa.Enabled = !Flag;
            dtNgayRVDen.ReadOnly = Flag;
            dtNgayRVTu.ReadOnly = Flag;
            txtMaBNTK.ReadOnly = Flag;
            txtSoHSBA1.ReadOnly = Flag;
            txtHoTenTK.ReadOnly = Flag;
            cmbDoituongBN1.ReadOnly = Flag;
            cmbDTBHXH.ReadOnly = Flag;
            cmdTimKiem.Enabled = !Flag;

            if (Flag)
            {
                AcceptButton = cmdGhi;
                CancelButton = cmdKhongGhi;
            }
            else
            {
                AcceptButton = cmdThemMoi;
                CancelButton = cmdThoat;
            }
        }

        private void LoadDoiTuongBN()
        {
            try
            {
                String Str = String.Format("SELECT * FROM DMKHOAPHONG WHERE IS_KHOADIEUTRI = 1 AND MAKHOA NOT IN ('{0}')",GlobalModuls.Global.glbMaKhoaPhong);
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(Str, GlobalModuls.Global.ConnectSQL);
                System.Data.DataSet ds = new DataSet();
                System.Data.SqlClient.SqlDataAdapter ad = new System.Data.SqlClient.SqlDataAdapter(cmd);
                ad.Fill(ds);

                cmbChuyenDenKhoa.AddItemSeparator = '|';
                foreach (System.Data.DataRow Row in ds.Tables[0].Rows)
                {
                    cmbChuyenDenKhoa.AddItem(String.Format("{0}|{1}", Row["MaKhoa"],Row["TenKhoa"]));
                }
                cmbChuyenDenKhoa.SelectedIndex = -1;
                ds.Dispose();
                ad.Dispose();
                cmd.Dispose();
            }
            catch
            {
            }
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
            dtNgayRVTu.Value = new DateTime(Global.NgayLV.Year, Global.NgayLV.Month, 1);
        }

        private void frmChuyenDien_Load(object sender, EventArgs e)
        {
            LoadDM();
            LoadDoiTuongBN();
            EnableEdit(false);
            Add = Edit = false;
            dtNgayRVDen.Enabled = dtNgayRVTu.Enabled = false;
            Load_DSBenhNhan();
        }

        private void Load_DSBenhNhan()
        {
            ClearText();
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            string MaKhoa = cmbKhoa.Columns[1].CellText(cmbKhoa.SelectedIndex);
            string MaDT = cmbDoituongBN1.Columns[1].CellText(cmbDoituongBN1.SelectedIndex);
            string MaDTBHXH = cmbDTBHXH.Columns[1].CellText(cmbDTBHXH.SelectedIndex);
            SQLCmd.CommandText = string.Format("set dateformat mdy SELECT bnct.MaVaoVien,HoTen,Year(getDate())-NamSinh As Tuoi,NgayVaoVien,khoaht.MAICD_BC,khoaht.MAICD_BP_1,bnct.buong, bnct.giuong "
                                        + " FROM BENHNHAN bn INNER JOIN BENHNHAN_CHITIET bnct ON bn.MaBenhNhan=bnct.MaBenhNhan"
                                        + " INNER JOIN ViewKHOAHIENTAI khoaht ON bnct.MaVaoVien=khoaht.MaVaoVien"
                                        + " INNER JOIN ViewDOITUONGHIENTAI dtht ON bnct.MaVaoVien=dtht.MaVaoVien"
                                        + " INNER JOIN DMDOITUONGBN dt ON dtht.DoiTuong=dt.MaDT"
                                        + " WHERE khoaht.MaKhoa = '{0}' and khoaht.vTrangThai=1"
                                        + " AND bnct.MaBenhNhan LIKE '{1}%' AND SOHSBA LIKE '{2}%'"
                                        + " AND dt.MaDT like '{3}%' AND bnct.MaDTBHYT like '{4}%'"
                                        + " AND bn.HOTEN LIKE N'%{5}%' ", MaKhoa,
                                        txtMaBNTK.Text.Replace(" ", ""), txtSoHSBA1.Text, MaDT, MaDTBHXH, txtHoTenTK.Text);
            dtNgayRVDen.ReadOnly = dtNgayRVTu.ReadOnly = false;
            if (rdTatCa.Checked)
            {
                dtNgayRVDen.ReadOnly = dtNgayRVTu.ReadOnly = true;
                SQLCmd.CommandText += " order by HoTen";
            }
            if (rdChuaRV.Checked)
            {
                SQLCmd.CommandText += " AND DaRaVien=0 order by HoTen";
            }
            if (rdDaRV.Checked)
            {
                SQLCmd.CommandText += " AND DaRaVien=1 AND NgayRaVien between '" + string.Format("{0:MM/dd/yyyy}", dtNgayRVTu.Value) + "' and '" + string.Format("{0:MM/dd/yyyy}", dtNgayRVDen.Value) + "' order by HoTen";
            }
            if (raChuyenKhoa.Checked)
            {
                SQLCmd.CommandText = string.Format("set dateformat mdy SELECT bnct.MaVaoVien,HoTen,Year(getDate())-NamSinh As Tuoi,NgayVaoVien,bnk.MAICD_BC,bnk.MAICD_BP_1,bnct.buong,bnct.giuong "
                                            + " FROM BENHNHAN bn INNER JOIN BENHNHAN_CHITIET bnct ON bn.MaBenhNhan=bnct.MaBenhNhan"
                                            + " INNER JOIN BenhNhan_Khoa bnk ON bnct.MaVaoVien=bnk.MaVaoVien"
                                            + " INNER JOIN ViewDOITUONGHIENTAI dtht ON bnct.MaVaoVien=dtht.MaVaoVien"
                                            + " INNER JOIN DMDOITUONGBN dt ON dtht.DoiTuong=dt.MaDT"
                                            +" WHERE bnk.MaKhoaCD='{0}' AND bnk.NgayChuyen BETWEEN '{1:MM/dd/yyyy}' AND '{2:MM/dd/yyyy}' "
                                            +" AND bnct.MaBenhNhan LIKE '{3}%' AND SOHSBA LIKE '{4}%' AND dt.MaDT LIKE '{5}%'  "
                                            +" AND bnct.MaDTBHYT LIKE '{6}%' AND bn.HOTEN LIKE N'%{7}%' order by HoTen", cmbKhoa.Columns[1].CellText(cmbKhoa.SelectedIndex), dtNgayRVTu.Value, dtNgayRVDen.Value, txtMaBNTK.Text.Replace(" ", ""),
                                            txtSoHSBA1.Text, MaDT, MaDTBHXH, txtHoTenTK.Text);
            }
            dr = SQLCmd.ExecuteReader();
            fgDanhSach.Tag = "0";
            fgDanhSach.Rows.Count = 1;
            fgDanhSach.ClipSeparators = "|;";
            fgDanhSach.Redraw = false;
            while (dr.Read())
            {
               fgDanhSach.AddItem(String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}",
                    fgDanhSach.Rows.Count,
                    dr["MaVaoVien"],
                    dr["Hoten"],
                    dr["Tuoi"],
                    dr["Ngayvaovien"], dr["MAICD_BC"], dr["MAICD_BP_1"], dr["buong"], dr["giuong"]));  
            }
            dr.Close();
            fgDanhSach.AutoSizeCols();
            fgDanhSach.Redraw = true;
            fgDanhSach.Tag = "1";
            SQLCmd.Dispose();
        }
        public void ClearText()
        {
            txtMaBenNhan1.Text = "";
            txtHoTen.Text = "";
            txtTuoi.Text = "";
            txtSoHSBA.Text = "";
            txtDanToc.Text = "";
            txtGoiTinh.Text = "";
            txtDiaChi.Text = "";
            fgDoiTuong.Rows.Count = 1;
        }
        private void LoatTongTinhCT()
        {
            if (fgDanhSach.Rows.Count <= 1 ) return;
            if (fgDanhSach.Row == -1) return;
            String Str = "";
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            try
            {
                Str = String.Format("SELECT bnct.MAVAOVIEN,bnct.SOHSBA,bnct.DIACHI ,YEAR(GETDATE()) - NAMSINH AS TUOI,LanChuyenKhoa,kp.TenKhoa,kp2.TenKhoa as TenKhoaCD,"
	                            + " bn.MABENHNHAN,bn.HOTEN,bn.NAMSINH,bn.MADANTOC,CASE WHEN bn.GIOITINH = 1 THEN N'Nam' ELSE N'Nữ' END AS GIOITINH,NgayChuyen,TenDT,KP.MaKhoa,bnk.MAICD_BC,bnk.MAICD_BP_1,IDBuong_Khoa,IDGiuong_Khoa "
                                + " FROM BENHNHAN bn INNER JOIN BENHNHAN_CHITIET bnct ON bn.MABENHNHAN = bnct.MABENHNHAN "
	                            + " INNER JOIN BENHNHAN_KHOA bnk ON bnk.MAVAOVIEN = bnct.MAVAOVIEN "
	                            + " INNER JOIN DMKHOAPHONG KP ON KP.MAKHOA = bnk.MAKHOA "
	                            + " INNER JOIN DMKHOAPHONG KP2 ON KP2.MAKHOA = bnk.MAKHOACD "
	                            + " LEFT JOIN DMDANTOC dtoc ON dtoc.MADT = bn.MADANTOC"
                                + " WHERE bnct.MAVAOVIEN = '{0}'", fgDanhSach.GetDataDisplay(fgDanhSach.Row, "MaVaoVien"));
                SQLCmd.CommandText = Str;
                dr = SQLCmd.ExecuteReader();
                fgDoiTuong.Rows.Count = 1;
                while (dr.Read())
                {
                    txtMaBenNhan1.Text = dr["MaVaoVien"].ToString();
                    txtHoTen.Text = dr["HoTen"].ToString();
                    txtTuoi.Text = dr["Tuoi"].ToString();
                    txtSoHSBA.Text = dr["SoHSBA"].ToString();
                    txtDanToc.Text = dr["TenDT"].ToString();
                    txtGoiTinh.Text = dr["GioiTinh"].ToString();
                    txtDiaChi.Text = dr["DiaChi"].ToString();
                    fgDoiTuong.Rows.Add();
                    fgDoiTuong[fgDoiTuong.Rows.Count - 1, "Lan"] = dr["LANCHUYENKHOA"];
                    fgDoiTuong[fgDoiTuong.Rows.Count - 1, "NgayChuyen"] = dr["NgayChuyen"];
                    fgDoiTuong[fgDoiTuong.Rows.Count - 1, "MaKhoa"] = dr["MaKhoa"];
                    fgDoiTuong[fgDoiTuong.Rows.Count - 1, "TenKhoa"] = dr["TenKhoa"];
                    fgDoiTuong[fgDoiTuong.Rows.Count - 1, "KhoaCD"] = dr["TenKhoaCD"];
                    fgDoiTuong[fgDoiTuong.Rows.Count - 1, "MAICD_BC"] = dr["MAICD_BC"];
                    fgDoiTuong[fgDoiTuong.Rows.Count - 1, "MAICD_BP_1"] = dr["MAICD_BP_1"];
                    fgDoiTuong[fgDoiTuong.Rows.Count - 1, "IDBuong_Khoa"] = dr["IDBuong_Khoa"];
                    fgDoiTuong[fgDoiTuong.Rows.Count - 1, "IDGiuong_Khoa"] = dr["IDGiuong_Khoa"];
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                SQLCmd.Dispose();
            }
        }

        private void cmdThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fgDanhSach_Click(object sender, EventArgs e)
        {
            
        }

        private void fgDoiTuong_Click(object sender, EventArgs e)
        {
            if (fgDoiTuong.Row <= 0) return;
            if (fgDoiTuong.Rows.Count <= 1) return;

            txtNgayChuyen.Value = fgDoiTuong.GetData(fgDoiTuong.Row, "NgayChuyen");
        }

        private void cmdThemMoi_Click(object sender, EventArgs e)
        {
            if (txtHoTen.Text == "" || rdChuaRV.Checked == false) return;
            Add = true;
            Edit = false;
            EnableEdit(true);
            txtNgayChuyen.Value = GlobalModuls.Global.NgayLV;
            txtNgayChuyen.Focus();
         
        }

        private void cmdSua_Click(object sender, EventArgs e)
        {
            if (fgDoiTuong.Row <= 0) return;
            if (fgDoiTuong.Rows.Count <= 1) return;
            if (fgDoiTuong.Row < fgDoiTuong.Rows.Count - 1)
            {
                MessageBox.Show("Bạn phải xóa lần chuyển trước đó mới sửa được", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // SON THEM
            String Str = "";
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlDataReader dr;
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            Str = String.Format("select * from benhnhan_chitiet where mavaovien ='{0}' and trangthai = 1 ", fgDanhSach.GetDataDisplay(fgDanhSach.Row, "MaVaoVien"));
            SQLCmd.CommandText = Str;
            dr = SQLCmd.ExecuteReader();
            if (dr.HasRows)
            {
                MessageBox.Show("Bệnh nhân này đang điều trị. Bạn không thể sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dr.Close();
                return;
            }
            dr.Close();
            // HET
            Add = false;
            Edit = true;
            EnableEdit(true);

            txtNgayChuyen.Value = fgDoiTuong.GetData(fgDoiTuong.Row, "NgayChuyen");
            cmbChuyenDenKhoa.SelectedIndex = cmbChuyenDenKhoa.FindStringExact(fgDoiTuong.GetDataDisplay(fgDoiTuong.Row, "MaKhoa"), 0, 0);
        }
        private void cmdKhongGhi_Click(object sender, EventArgs e)
        {
            Edit = Add = false;
            EnableEdit(false);
            txtNgayChuyen.Value = null;
            cmbChuyenDenKhoa.SelectedIndex = -1;
        }

        private void cmdGhi_Click(object sender, EventArgs e)
        {
            String Str = "";
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SqlDataReader dr;
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            string Benhchinh_benhphu = "";
            if (fgDanhSach.GetDataDisplay(fgDanhSach.Row, "MAICD_BC") != "" && fgDanhSach.GetDataDisplay(fgDanhSach.Row, "MAICD_BP_1") == "")
            {
                Benhchinh_benhphu = fgDanhSach.GetDataDisplay(fgDanhSach.Row, "MAICD_BC");
            }
            if (fgDanhSach.GetDataDisplay(fgDanhSach.Row, "MAICD_BC") != "" && fgDanhSach.GetDataDisplay(fgDanhSach.Row, "MAICD_BP_1") != "")
            {
                Benhchinh_benhphu = fgDanhSach.GetDataDisplay(fgDanhSach.Row, "MAICD_BC") + ";" + fgDanhSach.GetDataDisplay(fgDanhSach.Row, "MAICD_BP_1");
            }
            if (fgDanhSach.GetDataDisplay(fgDanhSach.Row, "MAICD_BC") == "" && fgDanhSach.GetDataDisplay(fgDanhSach.Row, "MAICD_BP_1") != "")
            {
                Benhchinh_benhphu = fgDanhSach.GetDataDisplay(fgDanhSach.Row, "MAICD_BP_1");
            }
            if (fgDanhSach.GetDataDisplay(fgDanhSach.Row, "MAICD_BC") == "" && fgDanhSach.GetDataDisplay(fgDanhSach.Row, "MAICD_BP_1") == "")
            {
                Benhchinh_benhphu = "";
            }

            if (cmbChuyenDenKhoa.SelectedIndex == -1)
            {
                MessageBox.Show("Chọn khoa chuyển đến.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            SQLCmd.CommandText = String.Format("set dateformat dmy select Ngaychuyen from BENHNHAN_KHOA WHERE MAVAOVIEN = '{0}' and lanchuyenkhoa = (select max(lanchuyenkhoa) from BENHNHAN_KHOA where mavaovien = '{0}')", fgDanhSach.GetDataDisplay(fgDanhSach.Row, "MaVaoVien"));
            dr = SQLCmd.ExecuteReader();
            while(dr.Read())
            {
                if (DateTime.Compare((DateTime)DateTime.Parse(dr["Ngaychuyen"].ToString()), (DateTime)txtNgayChuyen.Value) >= 0)
                {
                    MessageBox.Show("Chú ý: Thời gian chuyển khoa phải sau " + string.Format("{0:dd/MM/yyy HH:mm}",DateTime.Parse(dr["Ngaychuyen"].ToString())),  "Thông báo!");
                    txtNgayChuyen.Focus();
                    dr.Close();
                    return;
                }
            }
            dr.Close();
            try
            {
                if (Add)
                {

                    SQLCmd.CommandText = String.Format("set dateformat mdy  If EXISTS(select * from BENHNHAN_KHOA_NGAYGIUONG_CT where mavaovien = '{0}' and Makhoa = '{6}')"
                        + " update BENHNHAN_KHOA_NGAYGIUONG_CT set  NgayChuyen = '{2:MM/dd/yyyy HH:mm}',lanchuyenkhoa = {5},TrangThaiBN = 1 where mavaovien ='{0}' and Makhoa = '{6}'", 
                        fgDanhSach.GetDataDisplay(fgDanhSach.Row, "MaVaoVien"),
                        fgDoiTuong.Rows.Count - 1,
                        txtNgayChuyen.Value,
                        Global.GetCode(cmbChuyenDenKhoa),
                        cmbKhoa.Columns[1].CellText(cmbKhoa.SelectedIndex),
                        fgDoiTuong.GetDataDisplay(fgDoiTuong.Row, "Lan"),
                        cmbKhoa.Columns[1].CellText(cmbKhoa.SelectedIndex));
                         SQLCmd.ExecuteNonQuery();
                    SQLCmd.CommandText = String.Format("INSERT INTO BENHNHAN_KHOA(MAVAOVIEN,LANCHUYENKHOA,NGAYCHUYEN,MAKHOA,MAKHOACD,MAICD_BC,MAICD_BP_1) "
                        + " VALUES('{0}',{1},'{2:MM/dd/yyyy HH:mm}','{3}','{4}',N'{7}',N'{8}')",
                        fgDanhSach.GetDataDisplay(fgDanhSach.Row, "MaVaoVien"),
                        fgDoiTuong.Rows.Count - 1,
                        txtNgayChuyen.Value,
                        Global.GetCode(cmbChuyenDenKhoa),
                        cmbKhoa.Columns[1].CellText(cmbKhoa.SelectedIndex),
                        fgDoiTuong.GetDataDisplay(fgDoiTuong.Row, "Lan"),
                        cmbKhoa.Columns[1].CellText(cmbKhoa.SelectedIndex),"",Benhchinh_benhphu);
                    SQLCmd.CommandText += String.Format(" update benhnhan_chitiet set trangthai = 2 where mavaovien ='{0}'", fgDanhSach.GetDataDisplay(fgDanhSach.Row, "MaVaoVien"));
                    SQLCmd.ExecuteNonQuery();
                }
                else
                {
                    Str = String.Format("set dateformat mdy UPDATE BENHNHAN_KHOA SET NGAYCHUYEN='{0:MM/dd/yyyy HH:mm}',MAKHOA='{1}',MAICD_BC = N'{4}' ,MAICD_BP_1 = N'{5}'"
                        + " WHERE MAVAOVIEN='{2}' AND LANCHUYENKHOA ={3}",
                        txtNgayChuyen.Value,
                        Global.GetCode(cmbChuyenDenKhoa),
                        fgDanhSach.GetDataDisplay(fgDanhSach.Row, "MaVaoVien"),
                        fgDoiTuong.GetDataDisplay(fgDoiTuong.Row, "Lan"), fgDanhSach.GetDataDisplay(fgDanhSach.Row, "MAICD_BC"),Benhchinh_benhphu);
                    if (Str == "") return;
                    SQLCmd.CommandText = Str;
                    SQLCmd.ExecuteNonQuery();
                }
                Load_DSBenhNhan();
                LoatTongTinhCT();
                EnableEdit(false);
            }
            catch
            {
            }
            finally
            {
                SQLCmd.Dispose();
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void txtSoTheBHYT_Validated(object sender, EventArgs e)
        {
            
        }

        private void txtMaDT_Validating(object sender, CancelEventArgs e)
        {

        }

        private void txtMaDT_Validated(object sender, EventArgs e)
        {
            
        }

        private void txtManoicap_Validating(object sender, CancelEventArgs e)
        {
            
        }

        private void cmbDoiTuongBN_Validated(object sender, EventArgs e)
        {
        }

        private void cmdTimKiem_Click(object sender, EventArgs e)
        {
            Load_DSBenhNhan();
        }

        private void rdTatCa_CheckedChanged(object sender, EventArgs e)
        {
            if (rdTatCa.Checked)
            {
                dtNgayRVDen.Enabled = dtNgayRVTu.Enabled = false;
            }
            else
            {
                dtNgayRVDen.Enabled= dtNgayRVTu.Enabled = true;
            }
            Load_DSBenhNhan();
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
            Load_DSBenhNhan();
        }

        private void rdDaRV_CheckedChanged(object sender, EventArgs e)
        {
            if (rdTatCa.Checked)
            {
                dtNgayRVDen.Enabled = dtNgayRVTu.Enabled = false;
            }
            else
            {
                dtNgayRVDen.Enabled = dtNgayRVTu.Enabled = true;
            }
            Load_DSBenhNhan();
        }

        private void raChuyenKhoa_CheckedChanged(object sender, EventArgs e)
        {
            if (rdTatCa.Checked)
            {
                dtNgayRVDen.Enabled = dtNgayRVTu.Enabled = false;
            }
            else
            {
                dtNgayRVDen.Enabled = dtNgayRVTu.Enabled = true;
            }
            Load_DSBenhNhan();
        }

        private void cmdXoa_Click(object sender, EventArgs e)
        {
            if (txtHoTen.Text == "") return;
            if (fgDoiTuong.Row < 0) return;
            if (fgDoiTuong.Rows.Count <= 1) return;
            String Str = "";
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlDataReader dr;
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            Str = String.Format("select * from benhnhan_chitiet where mavaovien ='{0}' and trangthai = 1 ", fgDanhSach.GetDataDisplay(fgDanhSach.Row, "MaVaoVien"));
            SQLCmd.CommandText = Str;
            dr = SQLCmd.ExecuteReader();
            if (dr.HasRows)
            {
                MessageBox.Show("Bệnh nhân này đã được tiếp nhận. Bạn không thể xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dr.Close();
                return;
            }
            dr.Close();
            if (fgDoiTuong.Row == 1)
            {
                MessageBox.Show("Bạn không thể xóa.", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo.", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                return;
           
            try
            {
                int LanChuyen = 0;
                
                Str = String.Format(" DELETE FROM BENHNHAN_KHOA WHERE MAVAOVIEN='{0}' AND LANCHUYENKHOA={1}", 
                    fgDanhSach.GetDataDisplay(fgDanhSach.Row, "MaVaoVien"),
                    fgDoiTuong.GetDataDisplay(fgDoiTuong.Row,"Lan"));
                Str += String.Format(" update benhnhan_chitiet set trangthai = 1 where mavaovien ='{0}'", fgDanhSach.GetDataDisplay(fgDanhSach.Row, "MaVaoVien"));
                for (int i = 1; i < fgDoiTuong.Rows.Count; i++)
                {
                    if (i == fgDoiTuong.Row) continue;
                    Str += String.Format(" UPDATE BENHNHAN_KHOA SET LANCHUYENKHOA={0} WHERE MAVAOVIEN='{1}' AND LANCHUYENKHOA={2}",
                        LanChuyen.ToString(),
                        fgDanhSach.GetDataDisplay(fgDanhSach.Row,"MaVaoVien"),
                        fgDoiTuong.GetDataDisplay(i,"Lan"));
                    LanChuyen++;
                }
                SQLCmd.CommandText = Str;
                SQLCmd.ExecuteNonQuery();
                LoatTongTinhCT();
            }
            catch (Exception ex)
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
            LoatTongTinhCT();
        }
    }
}