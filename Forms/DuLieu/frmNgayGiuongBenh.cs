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
        public partial class frmNgayGiuongBenh : Form
        {
            private bool Add, Edit;
            public string MaBN;
            public int LanVV;
            public string NgayBatDau;
        
            public frmNgayGiuongBenh()
            {
                InitializeComponent();
            }

            private void EnableEdit(bool Flag)
            {
                txtNgayChuyen.ReadOnly = !Flag;
                cmdGhi.Visible = Flag;
                cmdKhongGhi.Visible = Flag;
                cmdThemMoi.Visible = !Flag;
                //cmdXoa.Visible = !Flag;
                //cmdSua.Visible = !Flag;
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
                //txtMaBNTK.ReadOnly = Flag;
                //txtSoHSBA1.ReadOnly = Flag;
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
                    String Str = String.Format("SELECT * FROM DMKHOAPHONG WHERE IS_KHOADIEUTRI = 1 AND MAKHOA NOT IN ('{0}')", GlobalModuls.Global.glbMaKhoaPhong);
                    System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(Str, GlobalModuls.Global.ConnectSQL);
                    System.Data.DataSet ds = new DataSet();
                    System.Data.SqlClient.SqlDataAdapter ad = new System.Data.SqlClient.SqlDataAdapter(cmd);
                    ad.Fill(ds);

                    cmbChuyenDenKhoa.AddItemSeparator = '|';
                    foreach (System.Data.DataRow Row in ds.Tables[0].Rows)
                    {
                        cmbChuyenDenKhoa.AddItem(String.Format("{0}|{1}", Row["MaKhoa"], Row["TenKhoa"]));
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

            System.Data.SqlClient.SqlDataReader reader;
            System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand();
            command.Connection = GlobalModuls.Global.ConnectSQL;
            command.CommandText = string.Format("SELECT ID_Buong,TenBuong FROM NAMDINH_QLBN.DBO.DMBUONGBENH WHERE MaKhoa= {0}", Global.glbKhoa_CapNhat);
            reader = command.ExecuteReader();
            cmbBuong.Tag = "0";
            cmbBuong.ClearItems();
            while (reader.Read())
            {
                cmbBuong.AddItem(string.Format("{0};{1}", reader["ID_Buong"], reader["TenBuong"]));
            }
            reader.Close();
            cmbBuong.Tag = "1";
            cmbBuong.SelectedIndex = -1;

            command.CommandText = string.Format("select A.MaDichvu,A.TenDichvu,A.Dongia,A.DongiaBHYT,A.DonGiaTuNguyen,A.TT37, A.TyLe from NAMDINH_SYSDB.DBO.DMDICHVU A INNER JOIN NAMDINH_SYSDB.DBO.DMDICHVU_KHOA B ON A.MaDichvu = B.MaDichvu WHERE LoaiDichvu = 'B01' AND B.MaKhoa = {0} and DongiaBHYT != 0", Global.glbKhoa_CapNhat);
            reader = command.ExecuteReader();
            this.cmbLoaiGiuong.ClearItems();
            while (reader.Read())
            {
                this.cmbLoaiGiuong.AddItem(string.Format("{0};{1}",
                    reader["MaDichvu"],
                    reader["TenDichvu"]));
            }
            reader.Close();
            cmbLoaiGiuong.Tag = "1";
            cmbLoaiGiuong.SelectedIndex = -1;
            command.CommandText = "SELECT * FROM DMCHEDOCHAMSOC";
            reader = command.ExecuteReader();
            this.cmbCheDoChamSoc.ClearItems();
            while (reader.Read())
            {
                this.cmbCheDoChamSoc.AddItem(string.Format("{0};{1}", reader["MaCDChamSoc"], reader["tenCDChamSoc"]));
            }
            this.cmbCheDoChamSoc.SelectedIndex = -1;
            reader.Close();
            command.CommandText = "SELECT * FROM DMDOITUONGBN";
            reader = command.ExecuteReader();
            this.cmbdoituong.AddItem("0;----- Theo đối tượng hiện tại -----");
            while (reader.Read())
            {
                this.cmbdoituong.AddItem(string.Format("{0};{1}", reader["MaDT"], reader["TenDT"]));
            }
            reader.Close();
            command.CommandText = "SELECT * FROM DMCHEDODINHDUONG";
            reader = command.ExecuteReader();
            this.cmbCheDoDinhDuong.ClearItems();
            while (reader.Read())
            {
                this.cmbCheDoDinhDuong.AddItem(string.Format("{0};{1}", reader["MaCDDinhDuong"], reader["TenCDDinhDuong"]));
            }
            this.cmbCheDoDinhDuong.SelectedIndex = -1;
            reader.Close();
            command.CommandText = "Select * from dmbacsy where SoChungChiHanhNghe is not null and SoChungChiHanhNghe <> '' and Khongsudung = 0 and MaChucVu <=5 and MaChucVu <> '' and makhoa  in " + Global.glbKhoa_CapNhat + " order by Thutu";
            //command.CommandText = "Select * from dmbacsy where Khongsudung = 0 and makhoa  in " + Global.glbKhoa_CapNhat + " order by Thutu";
            reader = command.ExecuteReader();
            this.cmbBacSyDT.ClearItems();
            while (reader.Read())
            {
                this.cmbBacSyDT.AddItem(string.Format("{0};{1}", reader["MaBS"], reader["TenBS"]));
            }
            reader.Close();
            this.cmbNhomMau.AddItem("0;Chưa x\x00e1c định");
            this.cmbNhomMau.AddItem("1;A");
            this.cmbNhomMau.AddItem("2;AB");
            this.cmbNhomMau.AddItem("3;B");
            this.cmbNhomMau.AddItem("4;O");

            //command.CommandText = string.Format("select Ngaychuyen from benhnhan_khoa where mavaovien = '{0}' and lanchuyenkhoa = 0", txtMaBenNhan1.Text.Trim());
            //reader = command.ExecuteReader();
            //while (reader.Read())
            //{
            //    NgayBatDau = string.Format("{0:dd/MM/yyyy HH:mm}", dr["NgayChuyen"]);
            //}
            //reader.Close();
            command.Dispose();
            SQLCmd.Dispose();
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
                SQLCmd.CommandText = string.Format("SELECT bnct.MaVaoVien,HoTen,Year(getDate())-NamSinh As Tuoi,NgayVaoVien "
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
                    SQLCmd.CommandText += " AND DaRaVien=1 AND NgayRaVien between '" + string.Format("{0:dd/MM/yyyy}", dtNgayRVTu.Value) + "' and '" + string.Format("{0:dd/MM/yyyy}", dtNgayRVDen.Value) + "' order by HoTen";
                }
                if (raChuyenKhoa.Checked)
                {
                    SQLCmd.CommandText = string.Format(" SELECT bnct.MaVaoVien,HoTen,Year(getDate())-NamSinh As Tuoi,NgayVaoVien "
                                                + " FROM BENHNHAN bn INNER JOIN BENHNHAN_CHITIET bnct ON bn.MaBenhNhan=bnct.MaBenhNhan"
                                                + " INNER JOIN BenhNhan_Khoa bnk ON bnct.MaVaoVien=bnk.MaVaoVien"
                                                + " INNER JOIN ViewDOITUONGHIENTAI dtht ON bnct.MaVaoVien=dtht.MaVaoVien"
                                                + " INNER JOIN DMDOITUONGBN dt ON dtht.DoiTuong=dt.MaDT"
                                                + " WHERE bnk.MaKhoaCD='{0}' AND bnk.NgayChuyen BETWEEN '{1:dd/MM/yyyy}' AND '{2:dd/MM/yyyy}' "
                                                + " AND bnct.MaBenhNhan LIKE '{3}%' AND SOHSBA LIKE '{4}%' AND dt.MaDT LIKE '{5}%'  "
                                                + " AND bnct.MaDTBHYT LIKE '{6}%' AND bn.HOTEN LIKE N'%{7}%' order by HoTen", cmbKhoa.Columns[1].CellText(cmbKhoa.SelectedIndex), dtNgayRVTu.Value, dtNgayRVDen.Value, txtMaBNTK.Text.Replace(" ", ""),
                                                txtSoHSBA1.Text, MaDT, MaDTBHXH, txtHoTenTK.Text);
                }
                dr = SQLCmd.ExecuteReader();
                fgDanhSach.Tag = "0";
                fgDanhSach.Rows.Count = 1;
                fgDanhSach.ClipSeparators = "|;";
                fgDanhSach.Redraw = false;
                while (dr.Read())
                {
                    fgDanhSach.AddItem(String.Format("{0}|{1}|{2}|{3}|{4}",
                         fgDanhSach.Rows.Count,
                         dr["MaVaoVien"],
                         dr["Hoten"],
                         dr["Tuoi"],
                         dr["Ngayvaovien"]));
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
                if (fgDanhSach.Rows.Count <= 1) return;
                if (fgDanhSach.Row == -1) return;
    
            //    String Str1 = "";
            //    System.Data.SqlClient.SqlDataReader dr1;
            //    System.Data.SqlClient.SqlCommand SQLCmd1 = new System.Data.SqlClient.SqlCommand();
            //    SQLCmd1.Connection = GlobalModuls.Global.ConnectSQL;
            //    Str1 = String.Format("select bnct.MAVAOVIEN,bnct.SOHSBA,bnct.DIACHI ,YEAR(GETDATE()) - NAMSINH AS TUOI,LanChuyenKhoa,kp.TenKhoa,kp2.TenDichvu as TenDichvu, bn.MABENHNHAN,bn.HOTEN,bn.NAMSINH,bn.MADANTOC,CASE WHEN bn.GIOITINH = 1 THEN N'Nam' ELSE N'Nữ' END AS GIOITINH,NgayChuyen,TenDT,KP.MaKhoa,BB.ID_Buong,BB.TenBuong,GB.ID_Giuong, GB.TenGiuong"
            //        + " FROM BENHNHAN bn INNER JOIN BENHNHAN_CHITIET bnct ON bn.MABENHNHAN = bnct.MABENHNHAN "
            //        + " INNER JOIN BENHNHAN_KHOA_NGAYGIUONG_CT bnk ON bnk.MAVAOVIEN = bnct.MAVAOVIEN "
            //        + " INNER JOIN DMKHOAPHONG KP ON KP.MAKHOA = bnk.MAKHOA "
            //        + " INNER JOIN NAMDINH_SYSDB.DBO.DMDICHVU kp2 ON kp2.MaDichvu = BNK.MaDichVu "
            //        + " INNER JOIN NAMDINH_QLBN.DBO.DMBUONGBENH BB ON BB.MaKhoa = bnk.MaKhoa and bnk.ID_Buong = bb.ID_Buong "
            //        + " INNER JOIN NAMDINH_QLBN.DBO.DMGIUONGBENH GB ON GB.ID_Buong = BB.ID_Buong AND GB.MaKhoa = bnk.MaKhoa and bnk.ID_Giuong = gb.ID_Giuong "
            //        + " LEFT JOIN DMDANTOC dtoc ON dtoc.MADT = bn.MADANTOC"
            //        + " WHERE bnct.MAVAOVIEN = '{0}'", fgDanhSach.GetDataDisplay(fgDanhSach.Row, "MaVaoVien"));
            //    SQLCmd1.CommandText = Str1;
            //    dr1 = SQLCmd1.ExecuteReader();

            ////,BB.ID_Buong,BB.TenBuong,GB.ID_Giuong, GB.TenGiuong
  
            //    if (dr1.HasRows)
            //    {
            //        fgDoiTuong.Rows.Count = 1;
            //        while (dr1.Read())
            //        {
            //            txtMaBenNhan1.Text = dr1["MaVaoVien"].ToString();
            //            txtHoTen.Text = dr1["HoTen"].ToString();
            //            txtTuoi.Text = dr1["Tuoi"].ToString();
            //            txtSoHSBA.Text = dr1["SoHSBA"].ToString();
            //            txtDanToc.Text = dr1["TenDT"].ToString();
            //            txtGoiTinh.Text = dr1["GioiTinh"].ToString();
            //            txtDiaChi.Text = dr1["DiaChi"].ToString();
            //            fgDoiTuong.Rows.Add();
            //            fgDoiTuong[fgDoiTuong.Rows.Count - 1, "Lan"] = dr1["LANCHUYENKHOA"];
            //            fgDoiTuong[fgDoiTuong.Rows.Count - 1, "NgayChuyen"] = dr1["NgayChuyen"];
            //            fgDoiTuong[fgDoiTuong.Rows.Count - 1, "MaKhoa"] = dr1["MaKhoa"];
            //            fgDoiTuong[fgDoiTuong.Rows.Count - 1, "TenKhoa"] = dr1["TenKhoa"];
            //            fgDoiTuong[fgDoiTuong.Rows.Count - 1, "TenDichvu"] = dr1["TenDichvu"];
            //            fgDoiTuong[fgDoiTuong.Rows.Count - 1, "TenBuong"] = dr1["TenBuong"];
            //            fgDoiTuong[fgDoiTuong.Rows.Count - 1, "TenGiuong"] = dr1["TenGiuong"];
            //            fgDoiTuong[fgDoiTuong.Rows.Count - 1, "ID_Buong"] = dr1["ID_Buong"];
            //            fgDoiTuong[fgDoiTuong.Rows.Count - 1, "ID_Giuong"] = dr1["ID_Giuong"];
            //        }
            //        dr1.Close();
            //        SQLCmd1.Dispose();
            //       }
            //    else
            //    {

                String Str = "";
                System.Data.SqlClient.SqlDataReader dr;
                System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
                SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            cmbdoituong.ClearItems();
               Str = String.Format("select bnct.MAVAOVIEN,bnct.SOHSBA,bnct.DIACHI ,YEAR(GETDATE()) - NAMSINH AS TUOI,0 AS LANCHUYENKHOA,kp.TenKhoa,'' as TenDichvu, bn.MABENHNHAN,bn.HOTEN,bn.NAMSINH,bn.MADANTOC,CASE WHEN bn.GIOITINH = 1 THEN N'Nam' ELSE N'Nữ' END AS GIOITINH,NgayChuyen,DTBN.TenDT,KP.MaKhoa,'' as ID_Buong,'' as TenBuong,'' as ID_Giuong,'' as TenGiuong,bnct.NgayVaoVien,DTBN.MADT"
                          + " FROM BENHNHAN bn INNER JOIN BENHNHAN_CHITIET bnct ON bn.MABENHNHAN = bnct.MABENHNHAN "
                          + " INNER JOIN ViewKHOAHIENTAI bnk ON bnk.MAVAOVIEN = bnct.MAVAOVIEN "
                          + " INNER JOIN DMKHOAPHONG KP ON KP.MAKHOA = bnk.MAKHOA "
                          + " INNER JOIN ViewDOITUONGHIENTAI DTHT ON DTHT.MAVAOVIEN = bnct.MAVAOVIEN "
                          + " INNER JOIN DMDOITUONGBN DTBN ON DTBN.MADT = DTHT.DOITUONG"
                          //+ " INNER JOIN NAMDINH_SYSDB.DBO.DMDICHVU kp2 ON kp2.MaDichvu = BNK.MaDichVu "
                          //+ " INNER JOIN NAMDINH_QLBN.DBO.DMBUONGBENH BB ON BB.MaKhoa = bnk.MaKhoa and bnct.Buong = bb.ID_Buong "
                          //+ " INNER JOIN NAMDINH_QLBN.DBO.DMGIUONGBENH GB ON GB.ID_Buong = BB.ID_Buong AND GB.MaKhoa = bnk.MaKhoa and bnct.Giuong = gb.ID_Giuong "
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
                    cmbdoituong.AddItem(string.Format("{0};{1}", dr["MaDT"], dr["TenDT"]));
                    fgDoiTuong.Rows.Add();
                    fgDoiTuong[fgDoiTuong.Rows.Count - 1, "Lan"] = dr["LANCHUYENKHOA"];
                    fgDoiTuong[fgDoiTuong.Rows.Count - 1, "NgayChuyen"] = dr["NgayChuyen"];
                    fgDoiTuong[fgDoiTuong.Rows.Count - 1, "MaKhoa"] = dr["MaKhoa"];
                    fgDoiTuong[fgDoiTuong.Rows.Count - 1, "TenKhoa"] = dr["TenKhoa"];
                    fgDoiTuong[fgDoiTuong.Rows.Count - 1, "TenDichvu"] = dr["TenDichvu"];
                    fgDoiTuong[fgDoiTuong.Rows.Count - 1, "TenBuong"] = dr["TenBuong"];
                    fgDoiTuong[fgDoiTuong.Rows.Count - 1, "TenGiuong"] = dr["TenGiuong"];
                    fgDoiTuong[fgDoiTuong.Rows.Count - 1, "ID_Buong"] = dr["ID_Buong"];
                    fgDoiTuong[fgDoiTuong.Rows.Count - 1, "ID_Giuong"] = dr["ID_Giuong"];
                    fgDoiTuong[fgDoiTuong.Rows.Count - 1, "NgayBatDau"] = dr["NgayVaoVien"];
            }

                cmbdoituong.SelectedIndex = 0;
                dr.Close();
                SQLCmd.Dispose();
            }
        private void BENHNHAN_GIUOGNBENH()
        {
            if (fgDanhSach.Rows.Count <= 1) return;
            if (fgDanhSach.Row == -1) return;
            String Str = "";
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            try
            {
                
                Str = String.Format("select bnct.MAVAOVIEN,bnct.SOHSBA,bnct.DIACHI ,YEAR(GETDATE()) - NAMSINH AS TUOI,bnk.Lan,kp.TenKhoa,kp2.TenDichvu as TenDichvu, bn.MABENHNHAN,bn.HOTEN,bn.NAMSINH,bn.MADANTOC,CASE WHEN bn.GIOITINH = 1 THEN N'Nam' ELSE N'Nữ' END AS GIOITINH,NgayChuyen,TenDT,KP.MaKhoa,BB.ID_Buong,BB.TenBuong,GB.ID_Giuong, GB.TenGiuong, bnk.NgayBatDau,TrangThaiGiuong"
                                + " FROM BENHNHAN bn INNER JOIN BENHNHAN_CHITIET bnct ON bn.MABENHNHAN = bnct.MABENHNHAN "
                                + " INNER JOIN BENHNHAN_KHOA_NGAYGIUONG_CT bnk ON bnk.MAVAOVIEN = bnct.MAVAOVIEN "
                                + " INNER JOIN DMKHOAPHONG KP ON KP.MAKHOA = bnk.MAKHOA "
                                + " INNER JOIN NAMDINH_SYSDB.DBO.DMDICHVU kp2 ON kp2.MaDichvu = BNK.MaDichVu "
                                + " INNER JOIN NAMDINH_QLBN.DBO.DMBUONGBENH BB ON BB.MaKhoa = bnk.MaKhoa and bnk.ID_Buong = bb.ID_Buong "
                                + " INNER JOIN NAMDINH_QLBN.DBO.DMGIUONGBENH GB ON GB.ID_Buong = BB.ID_Buong AND GB.MaKhoa = bnk.MaKhoa and bnk.ID_Giuong = gb.ID_Giuong "
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
                    fgDoiTuong[fgDoiTuong.Rows.Count - 1, "Lan"] = dr["Lan"];
                    fgDoiTuong[fgDoiTuong.Rows.Count - 1, "NgayChuyen"] = dr["NgayChuyen"];
                    fgDoiTuong[fgDoiTuong.Rows.Count - 1, "MaKhoa"] = dr["MaKhoa"];
                    fgDoiTuong[fgDoiTuong.Rows.Count - 1, "TenKhoa"] = dr["TenKhoa"];
                    fgDoiTuong[fgDoiTuong.Rows.Count - 1, "TenDichvu"] = dr["TenDichvu"];
                    fgDoiTuong[fgDoiTuong.Rows.Count - 1, "TenBuong"] = dr["TenBuong"];
                    fgDoiTuong[fgDoiTuong.Rows.Count - 1, "TenGiuong"] = dr["TenGiuong"];
                    fgDoiTuong[fgDoiTuong.Rows.Count - 1, "ID_Buong"] = dr["ID_Buong"];
                    fgDoiTuong[fgDoiTuong.Rows.Count - 1, "ID_Giuong"] = dr["ID_Giuong"];
                    fgDoiTuong[fgDoiTuong.Rows.Count - 1, "ID_Giuong"] = dr["ID_Giuong"];
                    fgDoiTuong[fgDoiTuong.Rows.Count - 1, "NgayBatDau"] = dr["NgayBatDau"];
                    TxtNamGhep.Value = int.Parse(dr["TrangThaiGiuong"].ToString());
                }
                dr.Close();
                this.fgDoiTuong.AutoSizeCols();
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
                cmbBuong.Text = fgDoiTuong.GetData(fgDoiTuong.Row, "TenBuong").ToString();
                cmbGiuong.Text = fgDoiTuong.GetData(fgDoiTuong.Row, "TenGiuong").ToString();
                cmbLoaiGiuong.Text = fgDoiTuong.GetData(fgDoiTuong.Row, "TenDichVu").ToString();
                cmbChuyenDenKhoa.Text = fgDoiTuong.GetData(fgDoiTuong.Row, "TenKhoa").ToString();
                 soluongbn();
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
            try
            {
                string text = "";
                System.Data.SqlClient.SqlDataReader dr;
                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand();
                command.Connection = GlobalModuls.Global.ConnectSQL;
                command.CommandText = "SELECT COUNT(*) AS SL FROM BENHNHAN bn INNER JOIN BENHNHAN_CHITIET bnct ON bn.MABENHNHAN = bnct.MABENHNHAN "
                     + " INNER JOIN BENHNHAN_KHOA_NGAYGIUONG_CT KHOA ON KHOA.MaVaoVien = bnct.MAVAOVIEN and khoa.TrangThaiBN = 0"
                     + " INNER JOIN DMKHOAPHONG KP ON KP.MAKHOA = KHOA.MAKHOA"
                     + " INNER JOIN NAMDINH_QLBN.DBO.DMBUONGBENH BB ON BB.MaKhoa = KHOA.MaKhoa"
                     + " INNER JOIN NAMDINH_QLBN.DBO.DMGIUONGBENH GB ON GB.ID_Buong = BB.ID_Buong AND GB.MaKhoa = KHOA.MaKhoa and BNCT.Giuong = gb.ID_Giuong  AND bnct.Buong = BB.ID_Buong "
                     + "WHERE KHOA.ID_Buong=" + Global.GetCode(cmbBuong) + " and KHOA.makhoa = " + Global.glbKhoa_CapNhat + " and KHOA.ID_Giuong = " + Global.GetCode(cmbGiuong) + " and KHOA.TrangThaiBN = 0";
                dr = command.ExecuteReader();
                while (dr.Read())
                {
                    TxtNamGhep.Value = int.Parse(dr["SL"].ToString());
                }
                dr.Close();

                command.CommandText = string.Format("select * from BENHNHAN_KHOA_NGAYGIUONG_CT where mavaovien = {0} and makhoa = {1}", txtMaBenNhan1.Text.Trim(), Global.glbKhoa_CapNhat);
                dr = command.ExecuteReader();
                while (dr.Read())
                {
                    txtNgayVaoVien.Value = dr["NgayChuyen"];
                }
                dr.Close();

                command.CommandText = string.Format("update BENHNHAN_KHOA_NGAYGIUONG_CT set  NgayChuyen = '{2:dd/MM/yyyy HH:mm}' where MaKhoa = {3} and ID_Buong = '{7}' and id_giuong = '{8}' and TrangThaiBN = 0 ",
                    this.txtMaBenNhan1.Text.Trim(), 0, this.txtNgayChuyen.Value, Global.glbKhoa_CapNhat, txtNgayVaoVien.Value, "B01", (this.cmbLoaiGiuong.SelectedIndex == -1) ? "null" : Global.GetCode(this.cmbLoaiGiuong), (this.cmbBuong.SelectedIndex == -1) ? "null" : Global.GetCode(this.cmbBuong), (this.cmbGiuong.SelectedIndex == -1) ? "null" : Global.GetCode(this.cmbGiuong), text, fgDoiTuong.Rows.Count - 1, Global.GetCode(cmbdoituong), 0, TxtNamGhep.Value + 1, Global.GetCode(cmbBacSyDT));
                command.ExecuteNonQuery();

                command.CommandText = string.Format("insert into BENHNHAN_KHOA_NGAYGIUONG_CT (MaVaoVien, LanChuyenKhoa, NgayChuyen, MaKhoa, NgayBatDau, Loaidichvu, MaDichVu, TenDichVu, ID_Buong, ID_Giuong, TenGiuong, LoaiGiuong, MaBS, SoPhieu, Lan, DoiTuong, TrangThaiBN, TrangThaiGiuong, Tyle, BacSyDT)"
                                + " select MaVaoVien, LanChuyenKhoa, '{2:dd/MM/yyyy HH:mm}', MaKhoa, '{2:dd/MM/yyyy HH:mm}', Loaidichvu, MaDichVu, TenDichVu, ID_Buong, ID_Giuong, TenGiuong, LoaiGiuong, MaBS, SoPhieu, Lan, DoiTuong, TrangThaiBN, TrangThaiGiuong, Tyle, BacSyDT"
                                + " from BENHNHAN_KHOA_NGAYGIUONG_CT where MaKhoa = {3} and ID_Buong = '{7}' and id_giuong = '{8}' and TrangThaiBN = 0 ",
                this.txtMaBenNhan1.Text.Trim(), 0, this.txtNgayChuyen.Value, Global.glbKhoa_CapNhat, txtNgayVaoVien.Value, "B01", (this.cmbLoaiGiuong.SelectedIndex == -1) ? "null" : Global.GetCode(this.cmbLoaiGiuong), (this.cmbBuong.SelectedIndex == -1) ? "null" : Global.GetCode(this.cmbBuong), (this.cmbGiuong.SelectedIndex == -1) ? "null" : Global.GetCode(this.cmbGiuong), text, fgDoiTuong.Rows.Count - 1, Global.GetCode(cmbdoituong), 0, TxtNamGhep.Value + 1, Global.GetCode(cmbBacSyDT));
                command.ExecuteNonQuery();

                command.CommandText = string.Format("select dbo.LaySoPhieu(Right(Convert(nvarchar(8),'{0:yyyyMMdd}',112),6)) As SoPhieu", this.txtNgayChuyen.Value);
                text = command.ExecuteScalar().ToString();
                command.CommandText = string.Format("if(exists(select * from BENHNHAN_KHOA_NGAYGIUONG_CT where MaVaoVien = '{0}' and MaKhoa = {3} and madichvu = '{6}' and ID_Buong = '{7}' and id_giuong = '{8}' )) update BENHNHAN_KHOA_NGAYGIUONG_CT set  NgayBatDau = '{2:dd/MM/yyyy HH:mm}' where MaVaoVien = '{0}' and MaKhoa = {3} and madichvu = '{6}' and ID_Buong = '{7}' and id_giuong = '{8}' and TrangThaiBN = 0 else INSERT INTO BENHNHAN_KHOA_NGAYGIUONG_CT(MaVaoVien, LanChuyenKhoa, NgayChuyen, MaKhoa, NgayBatDau, Loaidichvu, MaDichVu, ID_Buong, ID_Giuong,Sophieu,Lan,DoiTuong,TrangThaiBN,TrangThaiGiuong,BacSyDT)"
                                 + " values('{0}',{1},'{2:dd/MM/yyyy HH:mm}',{3},'{4:dd/MM/yyyy HH:mm}','{5}','{6}',{7},{8},'{9}',{10},{11},{12},{13},'{14}') ",
                                  new object[] { this.txtMaBenNhan1.Text.Trim(), 0, this.txtNgayChuyen.Value, Global.glbKhoa_CapNhat, txtNgayVaoVien.Value, "B01", (this.cmbLoaiGiuong.SelectedIndex == -1) ? "null" : Global.GetCode(this.cmbLoaiGiuong), (this.cmbBuong.SelectedIndex == -1) ? "null" : Global.GetCode(this.cmbBuong), (this.cmbGiuong.SelectedIndex == -1) ? "null" : Global.GetCode(this.cmbGiuong), text, fgDoiTuong.Rows.Count - 1, Global.GetCode(cmbdoituong), 0, TxtNamGhep.Value +1,Global.GetCode(cmbBacSyDT)});
                command.ExecuteNonQuery();
                //command.CommandText = string.Format("INSERT INTO BENHNHAN_PHIEUDIEUTRI  (SoPhieu,MaVaovien,NgayChiDinh,LoaiDT,bacSyDT,DienBienBenh,YLenh,CDChamSoc,CDDinhDuong,MaKhoa,Nhom,ChanDoan,CapCuu,MaBS,NhomMau,UserName1) VALUES ('{0}','{1}','{2:dd/MM/yyyy HH:mm}',{3},N'{4}',N'{5}',N'{6}',{7},{8},{9},{10},N'{11}',{12},{13},{14},N'{15}')", new object[] { text, this.txtMaBenNhan1.Text, this.txtNgayChuyen.Value, "null", this.cmbBacSyDT.Columns[1].CellText(this.cmbBacSyDT.SelectedIndex), this.txtDienBienBenh.Text, this.txtYLenh.Text, (this.cmbCheDoChamSoc.SelectedIndex == -1) ? "null" : Global.GetCode(this.cmbCheDoChamSoc), (this.cmbCheDoDinhDuong.SelectedIndex == -1) ? "null" : Global.GetCode(this.cmbCheDoDinhDuong), Global.glbKhoa_CapNhat, 0, this.txtChanDoan.Text.Trim().Replace("|", " "), 0, (Global.GetCode(this.cmbBacSyDT) == null) ? "null" : Global.GetCode(this.cmbBacSyDT), this.cmbNhomMau.SelectedIndex, Global.glbUName });
                //command.ExecuteNonQuery();
                BENHNHAN_GIUOGNBENH();
                EnableEdit(false);
                command.Dispose();
            }
                catch(Exception ex)
                {
                    MessageBox.Show("", ex.ToString());
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
                    dtNgayRVDen.Enabled = dtNgayRVTu.Enabled = true;
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
                        fgDoiTuong.GetDataDisplay(fgDoiTuong.Row, "Lan"));
                    Str += String.Format(" update benhnhan_chitiet set trangthai = 1 where mavaovien ='{0}'", fgDanhSach.GetDataDisplay(fgDanhSach.Row, "MaVaoVien"));
                    for (int i = 1; i < fgDoiTuong.Rows.Count; i++)
                    {
                        if (i == fgDoiTuong.Row) continue;
                        Str += String.Format(" UPDATE BENHNHAN_KHOA SET LANCHUYENKHOA={0} WHERE MAVAOVIEN='{1}' AND LANCHUYENKHOA={2}",
                            LanChuyen.ToString(),
                            fgDanhSach.GetDataDisplay(fgDanhSach.Row, "MaVaoVien"),
                            fgDoiTuong.GetDataDisplay(i, "Lan"));
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

        private void cmbBuong_TextChanged(object sender, EventArgs e)
        {
            if (cmbBuong.Tag.ToString() == "0") return;
            if (cmbBuong.SelectedIndex == -1) { cmbGiuong.ClearItems(); return; }
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
            SQLCmd.CommandText = "SELECT * FROM DMGIUONGBENH WHERE ID_Buong=" + Global.GetCode(cmbBuong) + " and makhoa = " + Global.glbKhoa_CapNhat;
            System.Data.SqlClient.SqlDataReader dr = SQLCmd.ExecuteReader();
            cmbGiuong.ClearItems();
            while (dr.Read())
            {
                cmbGiuong.AddItem(string.Format("{0};{1}", dr["ID_Giuong"], dr["TenGiuong"]));
            }
            dr.Close();
            cmbGiuong.SelectedIndex = -1;
            SQLCmd.Dispose();
        }

        private void soluongbn()
        {
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
            SQLCmd.CommandText = "SELECT COUNT(*) AS SL FROM BENHNHAN bn INNER JOIN BENHNHAN_CHITIET bnct ON bn.MABENHNHAN = bnct.MABENHNHAN "
                + " INNER JOIN BENHNHAN_KHOA_NGAYGIUONG_CT KHOA ON KHOA.MaVaoVien = bnct.MAVAOVIEN and khoa.TrangThaiBN = 0"
                + " INNER JOIN DMKHOAPHONG KP ON KP.MAKHOA = KHOA.MAKHOA"
                + " INNER JOIN NAMDINH_QLBN.DBO.DMBUONGBENH BB ON BB.MaKhoa = KHOA.MaKhoa"
                + " INNER JOIN NAMDINH_QLBN.DBO.DMGIUONGBENH GB ON GB.ID_Buong = BB.ID_Buong AND GB.MaKhoa = KHOA.MaKhoa and BNCT.Giuong = gb.ID_Giuong  AND bnct.Buong = BB.ID_Buong "
                + "WHERE KHOA.ID_Buong=" + fgDoiTuong.GetDataDisplay(fgDoiTuong.Row, "ID_Buong").ToString() + " and KHOA.makhoa = " + Global.glbKhoa_CapNhat + " and KHOA.ID_Giuong = " + fgDoiTuong.GetDataDisplay(fgDoiTuong.Row, "ID_Giuong").ToString() + " and KHOA.TrangThaiBN = 0";
            System.Data.SqlClient.SqlDataReader dr = SQLCmd.ExecuteReader();
            cmbGiuong.ClearItems();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    TxtNamGhep.Value = int.Parse(dr["SL"].ToString());
                }
                dr.Close();
                //                cmbGiuong.SelectedIndex = -1;
                SQLCmd.Dispose();
            }
            else
            {
                TxtNamGhep.Value = int.Parse(dr["SL"].ToString());
            }


        }

        private void btnGiuongBenh_Click(object sender, EventArgs e)
        {
            if (fgDanhSach.Tag.ToString() == "0") return;
            BENHNHAN_GIUOGNBENH();
        }

        private void cmbGiuong_TextChanged(object sender, EventArgs e)
        {
            try
            {
                System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
                SQLCmd.CommandText = "SELECT count(*) as SL FROM BENHNHAN_KHOA_NGAYGIUONG_CT WHERE TrangThaiBN  = 0 and MaKhoa = " + Global.glbKhoa_CapNhat  + " and ID_Buong = '" + Global.GetCode(cmbBuong) + "'" + " and ID_Giuong = '" + Global.GetCode(cmbGiuong) + "'";
                System.Data.SqlClient.SqlDataReader dr = SQLCmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        TxtNamGhep.Text = dr["SL"].ToString();
                    }
                    dr.Close(); SQLCmd.Dispose();
                }

            }
            catch
            {

            }
            finally
            {

            }
        }


        private void simpleButton1_Click(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlCommand SQLCmd1 = new System.Data.SqlClient.SqlCommand();
            SQLCmd1.Connection = GlobalModuls.Global.ConnectSQL;
            System.Data.SqlClient.SqlDataReader dr1;
            int LanChuyenKhoa = 0;
            SQLCmd1.CommandText = string.Format("select distinct a.MaVaoVien, a.NgayChuyen, a.MaKhoa, a.NgayBatDau, a.Loaidichvu, a.MaDichVu, a.TenDichVu, a.LoaiGiuong, a.TrangThaiBN,b.lanchuyenkhoa, b.MakhoaCD, b.NgayChuyen as NgayVaoVien from BENHNHAN_KHOA_NGAYGIUONG_CT a inner join benhnhan_khoa b on a.mavaovien = b.mavaovien and a.makhoa = b.makhoa where a.mavaovien = '" + txtMaBenNhan1.Text.Trim() + "'");
            dr1 = SQLCmd1.ExecuteReader();
            while (dr1.Read())
            {
                if(dr1["LanChuyenKhoa"].ToString() == "0")
                {
                    txtNgayVaoVien.Value = DateTime.Parse(dr1["NgayVaoVien"].ToString());
                }
                TimeSpan span1 = DateTime.Parse(dr1["NgayChuyen"].ToString()) - DateTime.Parse(dr1["NgayBatDau"].ToString());
                if (dr1["MaKhoaCD"].ToString() == "NV12011" && int.Parse(dr1["LanChuyenKhoa"].ToString()) == 1 && (span1.Hours <= 4 && span1.Days <= 0 && span1.Minutes <= 0))
                {
                    LanChuyenKhoa = int.Parse(dr1["LanChuyenKhoa"].ToString()) - 1;
                }
                else LanChuyenKhoa = 0;

            }
            dr1.Close();
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            System.Data.SqlClient.SqlDataReader dr;
            SQLCmd.CommandText = string.Format("select distinct a.MaVaoVien, a.NgayChuyen, a.MaKhoa, a.NgayBatDau, a.Loaidichvu, a.MaDichVu, a.TenDichVu, a.LoaiGiuong, a.TrangThaiBN,b.lanchuyenkhoa, b.MakhoaCD from BENHNHAN_KHOA_NGAYGIUONG_CT a inner join benhnhan_khoa b on a.mavaovien = b.mavaovien and a.makhoa = b.makhoa where a.mavaovien = '" + txtMaBenNhan1.Text.Trim() + "'" + " and a.Makhoa = " + Global.glbKhoa_CapNhat);
            dr = SQLCmd.ExecuteReader();
            while (dr.Read())
            {

                TimeSpan timeOfDay = DateTime.Parse(dr["NgayChuyen"].ToString()).TimeOfDay;
                DateTime NgayBatDau = DateTime.Parse(dr["NgayBatDau"].ToString()); NgayBatDau.ToString("dd/MM/yyyy HH:mm");
                DateTime NgayChuyen = DateTime.Parse(dr["NgayChuyen"].ToString()); NgayChuyen.ToString("dd/MM/yyyy HH:mm");
                DateTime NgayBatDau_12 = DateTime.Parse(NgayBatDau.ToString("dd/MM/yyyy 11:59"));
                DateTime NgayChuyen_12 = DateTime.Parse(NgayChuyen.ToString("dd/MM/yyyy 11:59"));
                DateTime NgayVaoVien_12 = DateTime.Parse(string.Format("{0:dd/MM/yyyy 11:59}", txtNgayVaoVien.Value.ToString()));
                TimeSpan span1 = DateTime.Parse(dr["NgayChuyen"].ToString()) - DateTime.Parse(dr["NgayBatDau"].ToString());
                TimeSpan span2 = DateTime.Parse(NgayChuyen_12.ToString()) - DateTime.Parse(NgayBatDau_12.ToString());
               
                if (dr["TrangThaiBN"].ToString() == "2" && LanChuyenKhoa  == 0)
                {
                    if ((span1.Hours <= 4 && span1.Days == 0 && span1.Minutes <= 0))
                    {
                        MessageBox.Show("" + (0.0));
                    }
                    //if (span1.Days == 0 && span1.Hours > 4)
                    //{
                    //    MessageBox.Show("" + (1.0));
                    //}
                    else if ((span1.Hours >= 4) && (span1.Days == 0) && (span1.Hours <= 24))
                    {
                        MessageBox.Show("" + (1.0));
                    }
                    else if (span1.Days > 0)
                    {
                        //Vào viện trước 12 giờ, ra viện trước 12 giờ 
                        if ((DateTime.Compare(NgayBatDau, NgayBatDau_12) < 0) && (DateTime.Compare(NgayChuyen, NgayChuyen_12) < 0))
                        {
                            // TimeSpan span1 = DateTime.Parse(dr["NgayChuyen"].ToString()) - DateTime.Parse(dr["NgayBatDau"].ToString());
                            MessageBox.Show("" + (0.7 + span2.Days - 1 + 0.5));
                        }
                        //Vào trước 12 giờ, ra sau 12 giờ 
                        if ((DateTime.Compare(NgayBatDau, NgayBatDau_12) < 0) && (DateTime.Compare(NgayChuyen, NgayChuyen_12) > 0))
                        {
                            // TimeSpan span1 = DateTime.Parse(dr["NgayChuyen"].ToString()) - DateTime.Parse(dr["NgayBatDau"].ToString());
                            MessageBox.Show("" + (0.7 + span2.Days - 1 + 0.7));
                        }
                        //Vào sau 12 giờ, ra trước 12 giờ 
                        if ((DateTime.Compare(NgayBatDau, NgayBatDau_12) > 0) && (DateTime.Compare(NgayChuyen, NgayChuyen_12) < 0))
                        {
                            // TimeSpan span1 = DateTime.Parse(dr["NgayChuyen"].ToString()) - DateTime.Parse(dr["NgayBatDau"].ToString());
                            MessageBox.Show("" + (0.5 + span2.Days - 1 + 0.5));
                        }
                        //Vào sau 12 giờ, ra sau 12 giờ 
                        if ((DateTime.Compare(NgayBatDau, NgayBatDau_12) > 0) && (DateTime.Compare(NgayChuyen, NgayChuyen_12) > 0))
                        {
                            // TimeSpan span1 = DateTime.Parse(dr["NgayChuyen"].ToString()) - DateTime.Parse(dr["NgayBatDau"].ToString());
                            MessageBox.Show("" + (0.5 + span2.Days - 1 + 0.7));
                        }
                    }
                }
                //Nếu bệnh nhân vào viện từ Khoa Khám bệnh, sau đó chuyển khoa
                if (dr["TrangThaiBN"].ToString() == "1" && LanChuyenKhoa == 0)
                {
                    if ((span1.Hours < 4 && span1.Days == 0 && span1.Minutes >= 0 && Global.glbKhoa_CapNhat == "('NV12011')"))
                    {
                        MessageBox.Show("" + (0.0));
                    }
                    if (NgayBatDau.Day == NgayChuyen.Day && span1.Hours >= 4)
                    {
                        MessageBox.Show("" + (0.5));
                    }

                    if (NgayBatDau.Day < NgayChuyen.Day)
                    {
                        //Vào viện trước 12 giờ
                        if ((DateTime.Compare(NgayBatDau, NgayBatDau_12) < 0))
                        {
                            // TimeSpan span1 = DateTime.Parse(dr["NgayChuyen"].ToString()) - DateTime.Parse(dr["NgayBatDau"].ToString());
                            MessageBox.Show("" + (0.7 + span2.Days - 1 + 0.5));
                        }
                        //Vào sau 12 giờ
                        if ((DateTime.Compare(NgayBatDau, NgayBatDau_12) > 0))
                        {
                            // TimeSpan span1 = DateTime.Parse(dr["NgayChuyen"].ToString()) - DateTime.Parse(dr["NgayBatDau"].ToString());
                            MessageBox.Show("" + (0.5 + span2.Days - 1 + 0.5));
                        }
                    }

                }
                // Khoa Thứ 2
                if (dr["TrangThaiBN"].ToString() == "2" && LanChuyenKhoa == 1)
                {
                    if ((DateTime.Compare(NgayBatDau_12.Date, NgayChuyen_12.Date) == 0) && (DateTime.Compare(NgayVaoVien_12.Date, NgayChuyen_12.Date) == 0))
                    {
                        MessageBox.Show("" + (0.5));
                    }
                    // ra viện trước 12 giờ 
                    if ((DateTime.Compare(NgayBatDau_12, NgayChuyen_12) == 0) && (DateTime.Compare(NgayChuyen, NgayChuyen_12) < 0) && (DateTime.Compare(NgayVaoVien_12.Date, NgayBatDau_12.Date) < 0))
                    {
                        MessageBox.Show("" + (0.0));
                    }
                    //ra sau 12 giờ 
                    if ((DateTime.Compare(NgayBatDau_12, NgayChuyen_12) == 0) && (DateTime.Compare(NgayChuyen, NgayChuyen_12) > 0) && (DateTime.Compare(NgayVaoVien_12.Date, NgayBatDau_12.Date) < 0))
                    {
                        MessageBox.Show("" + (0.2));
                    }

                    if ((DateTime.Compare(NgayBatDau.Date, NgayChuyen.Date) < 0) && (DateTime.Compare(NgayVaoVien_12.Date, NgayBatDau_12.Date) == 0))
                    {
                        //Vào viện trước 12 giờ, ra viện trước 12 giờ 
                        if ((DateTime.Compare(NgayBatDau, NgayBatDau_12) < 0) && (DateTime.Compare(NgayChuyen, NgayChuyen_12) < 0))
                        {
                            // TimeSpan span1 = DateTime.Parse(dr["NgayChuyen"].ToString()) - DateTime.Parse(dr["NgayBatDau"].ToString());
                            MessageBox.Show("" + (0.2 + span2.Days - 1 + 0.5));
                        }
                        //Vào trước 12 giờ, ra sau 12 giờ 
                        if ((DateTime.Compare(NgayBatDau, NgayBatDau_12) < 0) && (DateTime.Compare(NgayChuyen, NgayChuyen_12) > 0))
                        {
                            // TimeSpan span1 = DateTime.Parse(dr["NgayChuyen"].ToString()) - DateTime.Parse(dr["NgayBatDau"].ToString());
                            MessageBox.Show("" + (0.2 + span2.Days - 1 + 0.7));
                        }
                        //Vào sau 12 giờ, ra trước 12 giờ 
                        if ((DateTime.Compare(NgayBatDau, NgayBatDau_12) > 0) && (DateTime.Compare(NgayChuyen, NgayChuyen_12) < 0))
                        {
                            // TimeSpan span1 = DateTime.Parse(dr["NgayChuyen"].ToString()) - DateTime.Parse(dr["NgayBatDau"].ToString());
                            MessageBox.Show("" + (span2.Days - 1 + 0.5));
                        }
                        //Vào sau 12 giờ, ra sau 12 giờ 
                        if ((DateTime.Compare(NgayBatDau, NgayBatDau_12) > 0) && (DateTime.Compare(NgayChuyen, NgayChuyen_12) > 0))
                        {
                            // TimeSpan span1 = DateTime.Parse(dr["NgayChuyen"].ToString()) - DateTime.Parse(dr["NgayBatDau"].ToString());
                            MessageBox.Show("" + (span2.Days - 1 + 0.7));
                        }
                    }

                    if ((DateTime.Compare(NgayBatDau.Date, NgayChuyen.Date) < 0) && (DateTime.Compare(NgayVaoVien_12.Date, NgayChuyen_12.Date) < 0))
                    {
                        if ((DateTime.Compare(NgayChuyen, NgayChuyen_12) < 0))
                        {
                            // TimeSpan span1 = DateTime.Parse(dr["NgayChuyen"].ToString()) - DateTime.Parse(dr["NgayBatDau"].ToString());
                            MessageBox.Show("" + (0.5 + span2.Days - 1 + 0.5));
                        }
                        //Vào sau 12 giờ
                        if ((DateTime.Compare(NgayChuyen, NgayChuyen_12) > 0) && (DateTime.Compare(NgayVaoVien_12.Date, NgayChuyen_12.Date) < 0))
                        {
                            // TimeSpan span1 = DateTime.Parse(dr["NgayChuyen"].ToString()) - DateTime.Parse(dr["NgayBatDau"].ToString());
                            MessageBox.Show("" + (0.5 + span2.Days - 1 + 0.7));
                        }
                    }
                }
                //Sau đó bệnh nhân chuyển khoa thứ 3
                if (dr["TrangThaiBN"].ToString() == "1" && LanChuyenKhoa == 1)
                {
                    if ((DateTime.Compare(NgayBatDau_12.Date, NgayChuyen_12.Date) == 0) && (DateTime.Compare(NgayVaoVien_12.Date, NgayChuyen_12.Date) == 0))
                    {
                        MessageBox.Show("" + (0.5));
                    }
                    // ra viện trước 12 giờ 
                    if ((DateTime.Compare(NgayBatDau_12, NgayChuyen_12) == 0) && (DateTime.Compare(NgayChuyen, NgayChuyen_12) < 0) && (DateTime.Compare(NgayVaoVien_12.Date, NgayBatDau_12.Date) < 0))
                    {
                        MessageBox.Show("" + (0.0));
                    }
                    //ra sau 12 giờ 
                    if ((DateTime.Compare(NgayBatDau_12, NgayChuyen_12) == 0) && (DateTime.Compare(NgayChuyen, NgayChuyen_12) > 0) && (DateTime.Compare(NgayVaoVien_12.Date, NgayBatDau_12.Date) < 0))
                    {
                        MessageBox.Show("" + (0.2));
                    }

                    if (NgayBatDau.Date < NgayChuyen.Date)
                    {
                        //Chuyển viện trước 12 giờ
                        if ((DateTime.Compare(NgayChuyen, NgayChuyen_12) < 0))
                        {
                            // TimeSpan span1 = DateTime.Parse(dr["NgayChuyen"].ToString()) - DateTime.Parse(dr["NgayBatDau"].ToString());
                            MessageBox.Show("" + (0.5 + span2.Days - 1 + 0.5));
                        }
                        //Chuyển sau 12 giờ
                        if ((DateTime.Compare(NgayChuyen, NgayChuyen_12) > 0))
                        {
                            // TimeSpan span1 = DateTime.Parse(dr["NgayChuyen"].ToString()) - DateTime.Parse(dr["NgayBatDau"].ToString());
                            MessageBox.Show("" + (0.7 + span2.Days - 1 + 0.5));
                        }
                    }
                }
                if (dr["TrangThaiBN"].ToString() == "2" && LanChuyenKhoa > 1)
                {
                    if ((DateTime.Compare(NgayChuyen, NgayChuyen_12) < 0))
                    {
                        // TimeSpan span1 = DateTime.Parse(dr["NgayChuyen"].ToString()) - DateTime.Parse(dr["NgayBatDau"].ToString());
                        MessageBox.Show("" + (span2.Days - 1 + 0.5));
                    }
                    //Vào sau 12 giờ
                    if ((DateTime.Compare(NgayChuyen, NgayChuyen_12) > 0))
                    {
                        // TimeSpan span1 = DateTime.Parse(dr["NgayChuyen"].ToString()) - DateTime.Parse(dr["NgayBatDau"].ToString());
                        MessageBox.Show("" + (span2.Days - 1 + 0.7));
                    }

                    // ra viện trước 12 giờ 
                    if ((DateTime.Compare(NgayBatDau_12, NgayChuyen_12) == 0) && (DateTime.Compare(NgayChuyen, NgayChuyen_12) < 0) && (DateTime.Compare(NgayVaoVien_12.Date, NgayChuyen_12.Date) < 0))
                    {
                        MessageBox.Show("" + (0.0));
                    }
                    //ra sau 12 giờ 
                    if ((DateTime.Compare(NgayBatDau_12, NgayChuyen_12) == 0) && (DateTime.Compare(NgayChuyen, NgayChuyen_12) > 0) && (DateTime.Compare(NgayVaoVien_12.Date, NgayChuyen_12.Date) < 0))
                    {
                        MessageBox.Show("" + (0.2));
                    }
                }

            }

            dr1.Close();
            SQLCmd1.Dispose();
            dr.Close();
            SQLCmd.Dispose();
        }

        private void fgDanhSach_AfterRowColChange(object sender, C1.Win.C1FlexGrid.RangeEventArgs e)
            {
                if (fgDanhSach.Tag.ToString() == "0") return;
                BENHNHAN_GIUOGNBENH();
           // LoatTongTinhCT();
                txtNgayVaoVien.Value = string.Format("{0:dd/MM/yyy HH:mm}", fgDanhSach.GetDataDisplay(fgDanhSach.Row, "LanVaoVien"));
            }



        }
}
