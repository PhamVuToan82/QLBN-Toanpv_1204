using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GlobalModuls;
using System.Data.SqlClient;
using Microsoft.VisualBasic;
using NamDinh_QLBN.Reports;
using NamDinh_QLBN.Forms.DuLieu.KetQuaCLS;

namespace NamDinh_QLBN.Forms.DuLieu
{
    public partial class frmLenChiPhiKhoaCC : Form
    {
        private string MaDoiTuongBN = "";
        private string MaNhom = "";
        private bool IsAddnew = false;
        private int LanChuyenDT = 0;
        private string str_TruyenMau = "";
        private string _DaTinhPhi = "";
        private string _Daravien = "";
        DateTime NgayKham;

        public frmLenChiPhiKhoaCC()
        {
            InitializeComponent();
        }

        private void cmdThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLenChiPhiKhoaCC_Load(object sender, EventArgs e)
        {
            GlobalModuls.Global.wait("Đang tổng hợp dữ liệu");
            cmbKhoa.Tag = 0;
            cmbLoaiDS.Tag = 0;
            cmbPhongKham.Tag = 0;
            fg.Tag = 0;
            fgDichVu.Tag = 0;
            fgPhieuChiDinh.Tag = 0;
            txttuNgay.Tag = 0;
            txtToingay.Tag = 0;
            txtNgayKham.Tag = 0;
            cmbNhom.Tag = 0;

            Load_CacDM();
            cmbBacSyDT.SelectedIndex = -1;
            Load_DSBN();
            Lock_Edit(true);

            cmbNhom.Tag = 1;
            cmbKhoa.Tag = 1;
            cmbLoaiDS.Tag = 1;
            fg.Tag = 1;
            fgDichVu.Tag = 1;
            fgPhieuChiDinh.Tag = 1;
            txttuNgay.Tag = 1;
            txtToingay.Tag = 1;
            txtNgayKham.Tag = 1;
            cmbPhongKham.Tag = 1;
            GlobalModuls.Global.nowait();
            fgDichVu.Tree.Column = 4;
            fgDichVu.ClipSeparators = "|;";
            fgPhieuChiDinh.Cols["SoPhieu"].Visible = fgPhieuChiDinh.Cols["LoaiDT"].Visible = fgPhieuChiDinh.Cols["MaKhoa"].Visible = false;
            fgDichVu.Cols["LoaiDichVu"].Visible = fgDichVu.Cols["MaDichVu"].Visible = fgDichVu.Cols["TenLoaiDV"].Visible = false;
            fgDichVu.Cols["SoLuong"].Format = "#,##0.##";
            fgDichVu.Cols["DonGia"].Format = "#,##0.##";
            fgDichVu.Cols["ThanhTien"].Format = "#,##0.##";
            fgDichVu.Cols["SoLuongCu"].DataType = typeof(Decimal);
            fgDichVu.Cols["SoLuongCu"].Format = "#,##0.##";
            for (int i = 0; i < fgDichVu.Cols.Count; i++)
            {
                if (fgDichVu.Cols[i].Name != "SoLuong" && fgDichVu.Cols[i].Name != "GhiChu" && fgDichVu.Cols[i].Name != "TyLe") fgDichVu.Cols[i].AllowEditing = false;
            }
            for (int i = 1; i < fgDichVu.Cols.Count; i++)
                if (i != 4 && i != 5 && i != 6 && i != 7 && i != 8 && i != 9 && i != 10 && i != 11 && i != 12)
            fgDichVu.Cols[i].Visible = false;
            fgDichVu.Cols["TyleBH"].Visible = true;
            fgDichVu.Cols["MaPhieuDuyet"].Visible = true;
            C1.Win.C1FlexGrid.CellStyle cs = fgDichVu.Styles[C1.Win.C1FlexGrid.CellStyleEnum.Subtotal0];
            cs.BackColor = Color.LightBlue;
            cs.ForeColor = Color.DarkBlue;
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
            cmbKhoa.Tag = "1";
            if (cmbKhoa.ListCount > 0) cmbKhoa.SelectedIndex = 0;
            dr.Close();
            SQLCmd.CommandText = "SELECT * FROM DMCHEDOCHAMSOC";
            dr = SQLCmd.ExecuteReader();
            cmbCheDoChamSoc.ClearItems();
            while (dr.Read())
            {
                cmbCheDoChamSoc.AddItem(string.Format("{0};{1}", dr["MaCDChamSoc"], dr["tenCDChamSoc"]));
            }
            cmbCheDoChamSoc.SelectedIndex = -1;
            dr.Close();

            SQLCmd.CommandText = "SELECT * FROM DMDOITUONGBN";
            dr = SQLCmd.ExecuteReader();
            cmbDoiTuong.AddItem("0;----- Theo đối tượng hiện tại -----");
            while (dr.Read())
            {
                cmbDoiTuong.AddItem(String.Format("{0};{1}", dr["MaDT"], dr["TenDT"]));
            }
            dr.Close();
            SQLCmd.CommandText = "SELECT * FROM DMCHEDODINHDUONG";
            dr = SQLCmd.ExecuteReader();
            cmbCheDoDinhDuong.ClearItems();
            while (dr.Read())
            {
                cmbCheDoDinhDuong.AddItem(string.Format("{0};{1}", dr["MaCDDinhDuong"], dr["TenCDDinhDuong"]));
            }
            cmbCheDoDinhDuong.SelectedIndex = -1;
            dr.Close();

            SQLCmd.CommandText = "Select * from dmbacsy where SoChungChiHanhNghe is not null and SoChungChiHanhNghe <> '' and Khongsudung = 0 and MaChucVu <=5 and MaChucVu <> '' and makhoa  in " + Global.glbKhoa_CapNhat;
            dr = SQLCmd.ExecuteReader();
            cmbBacSyDT.ClearItems();
            while (dr.Read())
            {
                cmbBacSyDT.AddItem(String.Format("{0};{1};{2};{3}", dr["MaBS"], dr["TenBS"], dr["SoChungChiHanhNghe"], dr["TenBS"]));
            }
            dr.Close();

            SQLCmd.CommandText = "Select * from dmbacsy where Machucvu in('6','7') and Khongsudung = 0 and makhoa  in " + Global.glbKhoa_CapNhat + " order by Thutu";
            //command.CommandText = "Select * from dmbacsy where Khongsudung = 0 and makhoa  in " + Global.glbKhoa_CapNhat + " order by Thutu";
            dr = SQLCmd.ExecuteReader();
            this.cmbDieuduong.ClearItems();
            while (dr.Read())
            {
                this.cmbDieuduong.AddItem(string.Format("{0};{1}", dr["MaBS"], dr["TenBS"]));
            }
            cmbDieuduong.SelectedIndex = -1;
            dr.Close();

            SQLCmd.CommandText = "SELECT * FROM Khoa_Nhom where MaKhoa='" + Global.GetCode(cmbKhoa) + "' ORDER BY TenNhom";
            dr = SQLCmd.ExecuteReader();
            cmbNhom.Tag = "0";
            cmbNhom.ClearItems();
            while (dr.Read())
            {
                cmbNhom.AddItem(string.Format("{0};{1}", dr["MANhom"], dr["TenNhom"]));
            }
            cmbNhom.SelectedIndex = 0;
            cmbNhom.Tag = "1";
            dr.Close();

            SQLCmd.CommandText = "SELECT * FROM DMKHOAPHONG WHERE is_KhamOKhoaKhac = 1";
            dr = SQLCmd.ExecuteReader();
            cmbPhongKham.Tag = "0";
            cmbPhongKham.ClearItems();
            while (dr.Read())
            {
                cmbPhongKham.AddItem(string.Format("{0};{1}", dr["MaKhoa"], dr["TenKhoa"]));
            }
            cmbPhongKham.SelectedIndex = 0;
            cmbPhongKham.Tag = "1";

            dr.Close();

            SQLCmd.CommandText = "select Madichvu from DMDICHVU where tendichvu like N'%Viện HHTMTW%' and DongiaBHYT > 0";
            dr = SQLCmd.ExecuteReader();
            while (dr.Read())
            {
                str_TruyenMau += dr["Madichvu"] + "; ";
            }
            dr.Close();

            cmbNhomMau.AddItem("0;Chưa xác định");
            cmbNhomMau.AddItem("1;A");
            cmbNhomMau.AddItem("2;AB");
            cmbNhomMau.AddItem("3;B");
            cmbNhomMau.AddItem("4;O");
            cmbLoaiDS.AddItem("0;Đang điều trị trong khoa nội trú");
            cmbLoaiDS.AddItem("1;Danh sách bệnh nhân ở phòng khám");
            cmbLoaiDS.AddItem("2;Chuyển khoa");
            cmbLoaiDS.AddItem("3;Ra viện");
            cmbLoaiDS.AddItem("4;Bệnh nhân ở khoa khác");
            txttuNgay.Value = txtToingay.Value = txtNgayChiDinh.Value = txtNgayKham.Value = GlobalModuls.Global.NgayLV;
            SQLCmd.Dispose();
        }

        private void Load_DSBN()
        {
            clear_ttbenhnhan();
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            try
            {
                if (cmbLoaiDS.SelectedIndex == -1) return;
                SQLCmd.CommandText = String.Format("set dateformat mdy select b.MaVaoVien,a.HoTen,Year(getdate()) - a.NamSinh as Tuoi,case when a.GioiTinh = 0 then N'Nữ' else 'Nam' end as GioiTinh,"
                    + " v.NgayChuyen,tendt,vv.doituong,TenBuong,TenGiuong,NgayRaVien,'' as TenKhoa, B.NgayVaovien,B.DaTinhPhi,B.DaRaVien,B.NgayKham,dmGiuongBenh.MaGiuongYT from "
                    + " (benhnhan a inner join benhnhan_chitiet b on a.mabenhnhan = b.mabenhnhan)"
                    + " inner join viewkhoahientai v on v.mavaovien = b.mavaovien and v.makhoa ='{0}'"
                    + " inner join viewdoituonghientai vv on vv.mavaovien = b.mavaovien"
                    + " inner join dmdoituongbn on dmdoituongbn.madt = vv.doituong"
                    + " left join dmBuongBenh on dmBuongBenh.ID_Buong = b.Buong and dmBuongBenh.MaKhoa= v.MaKhoa"
                    + " left join dmGiuongBenh on dmGiuongBenh.ID_Buong = b.Buong and dmGiuongBenh.ID_Giuong = b.Giuong and dmGiuongBenh.MaKhoa =v.MaKhoa",Global.GetCode(cmbKhoa));
                if (cmbLoaiDS.SelectedIndex == 0)
                {
                    SQLCmd.CommandText += " where b.DaRaVien = 0 and b.TrangThai=1 and b.MaNhom = "+ Global.GetCode(cmbNhom) +" order by a.HoTen";
                }
                if (cmbLoaiDS.SelectedIndex == 3)
                {
                    SQLCmd.CommandText += String.Format(" where b.DaRaVien = 1 and datediff(dd,b.NgayRaVien,'{0:MM/dd/yyyy}')  <= 0 and datediff(dd,b.NgayRaVien,'{1:MM/dd/yyyy}')  >= 0 order by a.HoTen",
                        txttuNgay.Value,txtToingay.Value);
                }
                if (cmbLoaiDS.SelectedIndex == 2)
                {
                    SQLCmd.CommandText = String.Format("select b.MaVaoVien,a.HoTen,Year(getdate()) - a.NamSinh as Tuoi,case when a.GioiTinh = 0 then N'Nữ' else 'Nam' end as GioiTinh,"
                        + " KhoaChuyenDi.NgayChuyen,tendt,vv.doituong,TenBuong,TenGiuong,KhoaChuyenDen.NgayChuyen as NgayRaVien,TenKhoaChuyenDen.TenKhoa, B.NgayVaovien,B.DaTinhPhi,B.DaRaVien,B.NgayKham,dmGiuongBenh.MaGiuongYT from "
                        + " (benhnhan a inner join benhnhan_chitiet b on a.mabenhnhan = b.mabenhnhan)"
                        + " inner join BenhNhan_Khoa KhoaChuyenDi on KhoaChuyenDi.MaVaoVien = b.MaVaoVien And KhoaChuyenDi.MaKhoa= '{0}'"
                        + " inner join BenhNhan_Khoa KhoaChuyenDen on KhoaChuyenDen.MaVaoVien = b.MaVaoVien and KhoaChuyenDen.LanChuyenKhoa = KhoaChuyenDi.LanChuyenKhoa + 1"
                        + " inner join viewdoituonghientai vv on vv.mavaovien = b.mavaovien"
                        + " inner join dmdoituongbn on dmdoituongbn.madt = vv.doituong"
                        + " left join dmBuongBenh on dmBuongBenh.ID_Buong = KhoaChuyenDi.IDBuong_Khoa and dmBuongBenh.MaKhoa= '{0}'"
                        + " left join dmGiuongBenh on dmGiuongBenh.ID_Buong = KhoaChuyenDi.IDBuong_Khoa and dmGiuongBenh.ID_Giuong = KhoaChuyenDi.IDGiuong_Khoa and dmGiuongBenh.MaKhoa = '{0}'"
                        + " left join dmkhoaphong TenKhoaChuyenDen on TenKhoaChuyenDen.MaKhoa = '{0}'"
                        + " where datediff(dd,KhoaChuyenDen.NgayChuyen,'{1:MM/dd/yyyy}') <= 0 and datediff(dd,KhoaChuyenDen.NgayChuyen,'{2:MM/dd/yyyy}') >= 0 ",
                        Global.GetCode(cmbKhoa),
                        txttuNgay.Value,
                        txtToingay.Value);
                }
                if (cmbLoaiDS.SelectedIndex == 1)
                {
                    SQLCmd.CommandText = String.Format("Select b.MaKhamBenh as MaVaoVien,a.TenBenhNhan as HoTen,Year(Getdate()) - NamSinh as Tuoi,case when a.GioiTinh = 0 then N'Nữ' else N'Nam' end as GioiTinh,"
                        + " b.ThoiGianDangKy as NgayChuyen,dmDoiTuongBN.TenDT,dmDoiTuongBN.MaDT as DoiTuong,'' as TenBuong,'' as TenGiuong,KQDVKham.ThoiGianKhamXong as NgayRaVien,dmKhoaPhong.TenKhoa,  B.ThoiGianDangKy as NgayVaovien,B.DaTinhPhi,B.DaTinhPhi as DaRaVien,B.ThoiGianDangKy as NgayKham,'' as MaGiuongYT from"
                        + " ([" + Global.glbKhamBenh + "].dbo.tblBenhNhan a inner join [" + Global.glbKhamBenh + "].dbo.tblKhamBenh b on a.MaBenhNhan = b.MaBenhNhan)"
                        + " inner join [" + Global.glbKhamBenh + "].dbo.tblKhamBenh_KQDVKham KQDVKham on KQDVKham.MaKhamBenh = b.MaKhamBenh "
                        + " inner join dmDoiTuongBN on dmDoiTuongBN.MaDT = b.DoiTuong"
                        + " inner join dmKhoaPhong on dmKhoaPhong.MaKhoa = KhoaThucHien"
                        + " Where KhoaThucHien = '{1}' and b.ThoiGianDangKy between '{0:MM/dd/yyyy} 00:00:00' and '{0:MM/dd/yyyy} 23:59:59'", txtNgayKham.Value, GlobalModuls.Global.GetCode(cmbPhongKham));
                }

                if (cmbLoaiDS.SelectedIndex == 4)
                {
                    SQLCmd.CommandText = string.Format("SELECT B.MAVAOVIEN,A.HOTEN,YEAR(GETDATE()) - A.NAMSINH AS TUOI,"
                        + " CASE WHEN A.GIOITINH = 0 THEN N'Nữ' ELSE N'Nam' END AS GIOITINH,DM.TENDT,"
                        + " V.DOITUONG,DMBUONGBENH.TENBUONG,DMGIUONGBENH.TENGIUONG,BENHNHAN_KHOA.NGAYCHUYEN,"
                        + " '' AS NGAYRAVIEN,DMKHOAPHONG.TENKHOA, B.NgayVaovien,B.DaTinhPhi,B.DaRaVien,B.NgayKham,''as MaGiuongYT FROM "
                        + " (BENHNHAN A INNER JOIN BENHNHAN_CHITIET B ON A.MABENHNHAN = B.MABENHNHAN)"
                        + " INNER JOIN BENHNHAN_PHIEUDIEUTRI PDT ON PDT.MAVAOVIEN = B.MAVAOVIEN"
                        + " INNER JOIN PHIEUDIEUTRI_CHITIET PDT_CT ON PDT_CT.SOPHIEU = PDT.SOPHIEU"
                        + " INNER JOIN VIEWDOITUONGHIENTAI V ON V.MAVAOVIEN = B.MAVAOVIEN"
                        + " INNER JOIN DMDOITUONGBN DM ON DM.MADT = V.DOITUONG"
                        + " INNER JOIN DMKHOAPHONG ON DMKHOAPHONG.MAKHOA = PDT.MAKHOA"
                        + " INNER JOIN BENHNHAN_KHOA ON BENHNHAN_KHOA.MAVAOVIEN = B.MAVAOVIEN AND BENHNHAN_KHOA.LANCHUYENKHOA = 0"
                        + " INNER JOIN DMDICHVU_KHOA ON DMDICHVU_KHOA.MADICHVU = PDT_CT.MADICHVU"
                        + " LEFT JOIN DMBUONGBENH ON DMBUONGBENH.ID_BUONG = B.BUONG AND DMBUONGBENH.MAKHOA = PDT.MAKHOA"
                        + " LEFT JOIN DMGIUONGBENH ON DMGIUONGBENH.ID_GIUONG = B.GIUONG AND DMGIUONGBENH.ID_BUONG = B.BUONG AND DMGIUONGBENH.MAKHOA = PDT.MAKHOA "
                        + " WHERE PDT_CT.LOAIDICHVU ='E02'  AND DMDICHVU_KHOA.MAKHOA ='{0}' AND DATEDIFF(DD,PDT.NGAYCHIDINH,'{1:MM/dd/yyyy}') = 0", GlobalModuls.Global.GetCode(cmbKhoa),txtNgayChiDinh.Value);
                }

                dr = SQLCmd.ExecuteReader();
                fg.Tag = "0";
                fg.Rows.Count = 1;
                while (dr.Read())
                {
                    fg.Rows.Add();
                    fg[fg.Rows.Count-1, "STT"] = fg.Rows.Count -1;
                    fg[fg.Rows.Count-1, "MaVaoVien"] = dr["MaVaoVien"].ToString();
                    fg[fg.Rows.Count-1, "HoTen"] = dr["HoTen"].ToString();
                    fg[fg.Rows.Count-1, "Tuoi"] = dr["Tuoi"].ToString();
                    fg[fg.Rows.Count-1, "GioiTinh"] = dr["GioiTinh"].ToString();
                    fg[fg.Rows.Count-1, "NgayVaoKhoa"] = dr["NgayChuyen"].ToString();
                    fg[fg.Rows.Count-1, "DoiTuong"] = dr["TenDT"].ToString();
                    fg[fg.Rows.Count-1, "MaDoiTuong"] = dr["DoiTuong"].ToString();
                    fg[fg.Rows.Count-1, "Buong"] = dr["TenBuong"].ToString();
                    fg[fg.Rows.Count-1, "Giuong"] = dr["TenGiuong"].ToString();
                    fg[fg.Rows.Count-1, "NgayRaVien"] = dr["NgayRaVien"].ToString();
                    fg[fg.Rows.Count-1, "ChuyenDenKhoa"] = dr["TenKhoa"].ToString();
                    fg[fg.Rows.Count - 1, "NgayVaoVien"] = dr["NgayVaoVien"].ToString();
                    fg[fg.Rows.Count - 1, "DaTinhPHi"] = dr["DaTinhPHi"].ToString();
                    fg[fg.Rows.Count - 1, "DaRaVien"] = dr["DaRaVien"].ToString();
                    fg[fg.Rows.Count - 1, "NgayKham"] = dr["NgayKham"].ToString();
                    fg[fg.Rows.Count - 1, "MaGiuongYT"] = dr["MaGiuongYT"].ToString();
                }
                dr.Close();
                fg.AutoSizeCols();
                fg.Tag = "1";
                if (cmbLoaiDS.SelectedIndex == 2) fg.Cols["ChuyenDenKhoa"].Visible = true;
                else fg.Cols["ChuyenDenKhoa"].Visible = false;
                if (cmbLoaiDS.SelectedIndex == 2) fg.Cols["NgayRaVien"].Caption = "Ngày vào khám";

                for(int num = 1; num<=fg.Rows.Count -1; num++ )
                {
                    if (fg[num, "DaTinhPHi"].ToString() == "1" && Global.GetCode(cmbLoaiDS) == "1" )
                    {
                        fg.Rows[num].Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                SQLCmd.Dispose();
            }
        }

        private void cmbLoaiDS_TextChanged(object sender, EventArgs e)
        {
            if (cmbLoaiDS.Tag.ToString() == "0") return;
            if (cmbLoaiDS.SelectedIndex == -1)
            {
                MessageBox.Show("Chọn lại");
                cmbLoaiDS.Focus();
            }
            if (cmbLoaiDS.SelectedIndex == 0) groNhom.Visible = true;
            else groNhom.Visible = false;
            if (cmbLoaiDS.SelectedIndex == 1) grNgayKham.Visible = true;
            else grNgayKham.Visible = false;
            if (cmbLoaiDS.SelectedIndex == 2 || cmbLoaiDS.SelectedIndex == 3 || cmbLoaiDS.SelectedIndex == 4) grpNgay.Visible = true;
            else grpNgay.Visible = false;
            Load_DSBN();
        }

        private void txtNgayKham_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void cmdLoad_Click(object sender, EventArgs e)
        {
            Load_DSBN();
        }

        private void fg_AfterRowColChange(object sender, C1.Win.C1FlexGrid.RangeEventArgs e)
        {
            if (fg.Tag.ToString() == "0") return;
            if (fg.Rows.Count <= 1) return;
            txtMaBN.Text = fg.GetDataDisplay(fg.Row, "MaVaoVien");
            txtHoTen.Text = fg.GetDataDisplay(fg.Row, "HoTen");
            txtGioi.Text = fg.GetDataDisplay(fg.Row, "GioiTinh");
            txtDoiTuong.Text = fg.GetDataDisplay(fg.Row, "DoiTuong");
            txtTuoi.Text = fg.GetDataDisplay(fg.Row, "Tuoi");
            MaDoiTuongBN = fg.GetDataDisplay(fg.Row, "MaDoiTuong");
            MaNhom = Global.GetCode(cmbNhom);
            MaDoiTuongBN = fg.GetDataDisplay(fg.Row, "MaDoiTuong");
            LanChuyenDT = Global.GetLanChuyenDTHT(txtMaBN.Text.Trim());
            txtNgayVaoVien.Text = fg.GetDataDisplay(fg.Row, "NgayVaoVien");
            _DaTinhPhi = fg.GetDataDisplay(fg.Row, "DaTinhPhi");
            _Daravien = fg.GetDataDisplay(fg.Row, "DaRaVien");
            NgayKham = DateTime.Parse(fg.GetDataDisplay(fg.Row, "NgayKham"));
        }

        private void tabControl1_TabIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblSoPhieu.Text = "";
            if (tabControl1.SelectedIndex != 0)
            {
                if (txtMaBN.Text.Trim() == "")
                {
                    MessageBox.Show("Chọn bệnh nhân!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tabControl1.SelectTab(0);
                    return;
                }
                else
                {
                    if (_DaTinhPhi != "1"|| _Daravien != "1")
                    {
                        fg.Enabled = false;
                        Load_PhieuChiDinh(txtMaBN.Text.Trim());
                        fg.Enabled = true;
                        cmdXoa.Enabled = true;
                        cmdThem.Enabled = true;
                        cmdSua.Enabled = true;
                    }
                    else
                    {
                        fg.Enabled = false;
                        Load_PhieuChiDinh(txtMaBN.Text.Trim());
                        fg.Enabled = true;
                        cmdXoa.Enabled = false;
                        cmdThem.Enabled = false;
                        cmdSua.Enabled = false;
                    }
                }
            }
            else
            {
                Lock_Edit(true);
            }
        }

        private void Empty_Data()
        {
            txtNgayChiDinh.Value = null;
            cmbCheDoChamSoc.SelectedIndex = cmbCheDoDinhDuong.SelectedIndex = -1;
            txtDienBienBenh.Text = txtYLenh.Text = txtChanDoan.Text = "";
            fgDichVu.Rows.Count = 1;
            cmbDieuduong.SelectedIndex = -1;
        }
         private void clear_ttbenhnhan()
        {
            if (fg.Tag.ToString() == "0") return;
            if (fg.Rows.Count <= 1) return;
            txtMaBN.Text = "";
            txtHoTen.Text = "";
            txtGioi.Text = "";
            txtDoiTuong.Text = "";
            txtTuoi.Text = "";
            txtNgayVaoVien.Text = "";
        }
        

        private void SoTienConLai()
        {
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            lbSoTienCL.Text = "0" ;
            lbSoTienKQ.Text = "0";
            try
            {
                if (cmbLoaiDS.SelectedIndex != 1)//Nếu là bn nội viện-------
                {
                    SQLCmd.CommandText = String.Format("SELECT SUM(ISNULL(C.SOLUONG,0) * ISNULL(C.DONGIA,0)) AS SOTIENDSD,AA.SOTIEN AS SOTIENKQ,"
                        + " ISNULL(AA.SOTIEN,0) - SUM(ISNULL(C.SOLUONG,0) * ISNULL(C.DONGIA,0)) AS SOTIENCL FROM "
                        + " (BENHNHAN_CHITIET A INNER JOIN BENHNHAN_PHIEUDIEUTRI B ON A.MAVAOVIEN = B.MAVAOVIEN)"
                        + " INNER JOIN PHIEUDIEUTRI_CHITIET C ON B.SOPHIEU = C.SOPHIEU"
                        + " LEFT JOIN "
                        + " (SELECT KQ_NT.MAVAOVIEN,SUM(KQ_NT.SOTIEN) AS SOTIEN FROM [" + Global.glbVienPhi + "].DBO.TBLTHUKYQUY KQ_NT WHERE KQ_NT.MAVAOVIEN = '{0}'"
                        + " GROUP BY MAVAOVIEN) AA"
                        + " ON AA.MAVAOVIEN = A.MAVAOVIEN"
                        + " WHERE A.MAVAOVIEN ='{0}'"
                        + " GROUP BY AA.SOTIEN", txtMaBN.Text);
                    dr = SQLCmd.ExecuteReader();
                    while (dr.Read())
                    {
                        lbSoTienCL.Text = String.Format("Số tiền còn lại: {0:#,##0}", dr["SoTienCL"]) + " VNĐ";
                        lbSoTienKQ.Text = String.Format("Số tiền ký quỹ: {0:#,##0}", dr["SoTienkQ"]) + " VNĐ";
                    }
                    dr.Close();
                }
                else  //Nếu là bn phòng khám-------
                {
                         SQLCmd.CommandText = String.Format("select DV.Makhambenh, isnull(TienDV,0) + isnull(TienCPDV,0) as Tongtien,isnull( KQ.SoTienKQ,0) -  isnull(TienDV,0) - isnull(TienCPDV,0) as SotienCL, isnull( KQ.SoTienKQ,0) as SoTienKQ from "
                           + " (select tblKhambenh_Dichvu.Makhambenh, isnull(sum(tblKhambenh_Dichvu.Soluong * DMDichvu.Dongia*tblKhambenh_Dichvu.TyLe/100),0) as TienDV "
                           + " from NAMDINH_KHAMBENH.dbo.tblKhambenh_Dichvu  "
                           + " inner join DMDichvu on tblKhambenh_Dichvu.MaDichvu = DMDichvu.MaDichvu  "
                           + " inner join NAMDINH_KHAMBENH.dbo.tblKhambenh_Chidinh on tblKhambenh_Dichvu.maphieucd = tblKhambenh_Chidinh.maphieucd and  tblKhambenh_Chidinh.makhambenh = tblkhambenh_dichvu.makhambenh and tblKhambenh_Chidinh.isDeleted = 0   "
                           + " where tblKhambenh_Dichvu.Makhambenh = '{0}' and left(tblkhambenh_dichvu.Maphieucd,2) <> 'DT' "
                           + " group by tblkhambenh_dichvu.Makhambenh ) DV"
                           + " left join "
                           + " (select  makhambenh, isnull(sum(tblCHIPHI_DICHVU.Soluong * tblCHIPHI_DICHVU.Dongia),0)   as TienCPDV"
                           + " from NAMDINH_KHAMBENH.dbo.tblCHIPHI_DICHVU  "
                           + " where tblCHIPHI_DICHVU.Makhambenh = '{0}' and tblCHIPHI_DICHVU.TinhPhi = 1"
                           + " group by Makhambenh ) CPDV on DV.MaKhambenh = CPDV.MaKhamBenh"
                           + " left join "
                           + " (SELECT Masokham, sum(ISNULL(SoTien, 0))  AS SoTienKQ FROM  "
                           + " NAMDINH_VIENPHI.dbo.tblThukyquy WHERE (Masokham = '{0}') and dahoantien<>1 and dahuy<>1"
                           + " group by Masokham ) KQ on DV.MaKhambenh = KQ.Masokham", txtMaBN.Text);
                        dr = SQLCmd.ExecuteReader();
                        while (dr.Read())
                        {
                            lbSoTienCL.Text = String.Format("Số tiền còn lại: {0:#,##0}", dr["SotienCL"]) + " VNĐ";
                            lbSoTienKQ.Text = String.Format("Số tiền ký quỹ: {0:#,##0}", dr["SoTienKQ"]) + " VNĐ";
                            if(Convert.ToInt32(dr["SotienCL"])<= 0 && Global.GetCode(cmbDoiTuong) == "3")
                            {
                                MessageBox.Show("Tổng chi phí của bệnh nhân đã vượt quá số tiền ký quỹ. Đề nghị bệnh nhân đóng thêm tiền ký quỹ!");
                                dr.Close();
                                return;
                            }
                        }
                        dr.Close();
                }
            }
            catch
            {
            }
            finally
            {
                SQLCmd.Dispose();
            }
        }
        private void Lock_Edit(bool IsLocked)
        {
            cmdThuThuat.Visible = cmdKetQuaXN.Visible = cmdTichKe.Visible = cmdMo.Visible = cmdHoiChan.Visible = cmdMau.Visible = cmdDonThuoc.Visible = cmdKhamChuyenKhoa.Visible = cmdThem.Visible = cmdSua.Visible = cmdXoa.Visible = cmdThoat.Visible = cmdInPhieu.Visible = IsLocked;
            cmdChiDinhTheoMatBenh.Visible = cmdGhi.Visible = cmdHuy.Visible = cmdChiDinh.Visible = cmdCopy.Visible = !IsLocked;
            
            raChiPhiHN.Enabled = raChiPhiTT.Enabled = IsLocked;
            chCapCuu.Enabled = IsLocked;
            fgPhieuChiDinh.Enabled = IsLocked;
            fgDichVu.Cols["SoLuong"].AllowEditing = !IsLocked;
            //fgDichVu.Cols["KhongTinhPhi"].AllowEditing = !IsLocked;
            cmbBacSyDT.Enabled = !IsLocked;
            if (!IsLocked)
            {
                fgDichVu.ContextMenuStrip = contextMenuNhapLieu;
            }
            else
            {
                fgDichVu.ContextMenuStrip = null;
            }
            fgDichVu.AllowDelete = !IsLocked;
            cmbCheDoChamSoc.ReadOnly = cmbCheDoDinhDuong.ReadOnly = IsLocked;
            txtNgayChiDinh.ReadOnly = IsLocked;
            txtNgayChiDinh.Enabled = !IsLocked;
            cmbNhomMau.ReadOnly = cmbBacSyDT.ReadOnly = txtDienBienBenh.ReadOnly = txtYLenh.ReadOnly = cmbDoiTuong.ReadOnly = txtChanDoan.ReadOnly = IsLocked;
        }

        private void Load_PhieuChiDinh(string MaVaoVien)
        {
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
            if (cmbLoaiDS.SelectedIndex != 1)
            {
                SQLCmd.CommandText = "SELECT a.*,a.UserName1 ,case when a.Nhom = 0 then N'Trong ngày' else N'Bất thường' end as Nhom1,a.CapCuu as CapCuu1,tenKhoa,dmbacsy.TenBS,case when a.chandoan <> '' then a.chandoan else  viewkhoahientai.ChanDoan end doan, a.isPhieudieutri_Covid FROM BENHNHAN_PHIEUDIEUTRI a INNER JOIN DMKHOAPHONG b ON a.MaKhoa=b.MaKhoa "
                    + " inner join viewkhoahientai on viewkhoahientai.mavaovien = a.mavaovien "
                    + " left join dmbacsy on dmbacsy.makhoa = a.makhoa and dmbacsy.mabs = a.mabs "
                    + " WHERE a.MaVaoVien='" + MaVaoVien + "' and isDelete is null order by NgayChiDinh";
            }
            else
            {
                SQLCmd.CommandText = String.Format("select distinct DichVu.MaPhieuCD as SoPhieu,DichVu.NgayThucHien as NgayChiDinh,DichVu.MaDichVu as LoaiDT,'' as DienBienBenh,'' as YLenh,"
                    + " '' as CDChamSoc,'' as CDDinhDuong,MaKhoaThucHien as MaKhoa,'' as tenKhoa,N'Trong ngày' as Nhom1,0 as Nhom,'' as ChanDoan,0 as CapCuu,"
                    + " 0 as NhomMau,0 as CapCuu1,'{0}' as UserName1,bs.TenBS as TenBS,0 as isPhieudieutri_Covid from [" + Global.glbKhamBenh + "].dbo.tblChiPhi_DichVu DichVu"
                    + " inner join dmdichvu on dmdichvu.madichvu = dichvu.MaChiPhi"
                    + " inner join namdinh_sysdb.dbo.dmbacsy bs on bs.SoChungChiHanhNghe = DichVu.Mabs"
                    + " where MaKhoaThucHien in ('"+ Global.GetCode(cmbKhoa) +"') and DichVu.MaKhamBenh='{1}'",Global.glbUName,txtMaBN.Text.Trim());
            }
            System.Data.SqlClient.SqlDataReader dr = SQLCmd.ExecuteReader();
            fgPhieuChiDinh.Tag = "0";
            fgPhieuChiDinh.Rows.Count = 1;
            fgPhieuChiDinh.ClipSeparators = "|;";
            while (dr.Read())
            {
            //    fgPhieuChiDinh.AddItem(string.Format("{0}|{1}|{2:dd/MM/yyyy HH:mm}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}|{12}|{13}|{14}|{15}|{16}|{17}|", new object[] {
            //    fgPhieuChiDinh.Rows.Count, reader["SoPhieu"], reader["NgayChiDinh"], reader["LoaiDT"], reader["BacSyDT"], reader["DienBienBenh"], reader["YLenh"], reader["CDChamSoc"], reader["CDDinhDuong"], reader["MaKhoa"], reader["tenKhoa"], reader["Nhom"], reader["Doan"], reader["CapCuu"], reader["Nhom1"],
            //reader["NhomMau"], reader["UN"],reader["isPhieudieutri_Covid"]
            //}));
                fgPhieuChiDinh.AddItem(string.Format("{0}|{1}|{2:dd/MM/yyyy HH:mm}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}|{12}|{13}|{14}|{15}|{16}|{17}|{18}",
                    fgPhieuChiDinh.Rows.Count,
                    dr["SoPhieu"],
                    dr["NgayChiDinh"],
                    dr["LoaiDT"],
                    dr["TenBS"],
                    dr["DienBienBenh"],
                    dr["YLenh"],
                    dr["CDChamSoc"],
                    dr["CDDinhDuong"],
                    dr["MaKhoa"],
                    dr["tenKhoa"],
                    dr["Nhom"],
                    dr["ChanDoan"],
                    dr["CapCuu"],
                    dr["Nhom1"],
                    dr["Capcuu1"],
                    dr["NhomMau"],
                    dr["UserName1"], dr["isPhieudieutri_Covid"]));
            }
            fgPhieuChiDinh.Row = 0;
            fgPhieuChiDinh.AutoSizeCols(1);
            Empty_Data();
            fgPhieuChiDinh.AutoSizeCols();
            fgPhieuChiDinh.Tag = "1";
            fgPhieuChiDinh.AutoSizeCols();
            dr.Close();
            SQLCmd.Dispose();
            SoTienConLai();
        }

        private void fg_DoubleClick(object sender, EventArgs e)
        {
            if (_DaTinhPhi != "1" ||_Daravien != "1")
            {
                fg.Enabled = false;
                Load_PhieuChiDinh(txtMaBN.Text.Trim());
                tabControl1.SelectTab(1);
                fg.Enabled = true;
                cmdSua.Enabled = true;
                cmdThem.Enabled = true;
                cmdXoa.Enabled = true;
                lblMaGiuongYT.Text = fg[fg.Row, "MaGiuongYT"].ToString();
            }
            else
            {
                fg.Enabled = false;
                Load_PhieuChiDinh(txtMaBN.Text.Trim());
                tabControl1.SelectTab(1);
                fg.Enabled = true;
                cmdSua.Enabled = false;
                cmdThem.Enabled = false;
                cmdXoa.Enabled = false;
                lblMaGiuongYT.Text = fg[fg.Row, "MaGiuongYT"].ToString();
            }
        }

        private void Load_PhieuDieutri_ChiTiet(int r)
        {
            try
            {
                string SoPhieu = fgPhieuChiDinh[r, "SoPhieu"].ToString();
                lblSoPhieu.Text = SoPhieu;
                txtNgayChiDinh.Value = fgPhieuChiDinh[r, "NgayChiDinh"] == null ? "" : fgPhieuChiDinh[r, "NgayChiDinh"];
                //string BacSy = fgPhieuChiDinh[r, "BacSyDT"] == null ? "" : fgPhieuChiDinh[r, "BacSyDT"].ToString();
                //cmbBacSyDT.SelectedIndex = cmbBacSyDT.FindStringExact(BacSy, 0, 1);
                txtDienBienBenh.Text = fgPhieuChiDinh[r, "DienBienBenh"] == null ? "" : fgPhieuChiDinh[r, "DienBienBenh"].ToString();
                txtChanDoan.Text = fgPhieuChiDinh[r, "ChanDoan"] == null ? "" : fgPhieuChiDinh[r, "ChanDoan"].ToString();
                txtYLenh.Text = fgPhieuChiDinh[r, "YLenh"] == null ? "" : fgPhieuChiDinh[r, "YLenh"].ToString();
                Global.SetCmb(cmbCheDoChamSoc, fgPhieuChiDinh[r, "CDChamSoc"].ToString());
                Global.SetCmb(cmbCheDoDinhDuong, fgPhieuChiDinh[r, "CDDinhDuong"].ToString());
                chCapCuu.Checked = fgPhieuChiDinh.GetDataDisplay(r, "CapCuu") == "0" ? false : true;
                //lblKhoa.Text = fgPhieuChiDinh[r, "TenKhoa"] == null ? "" : fgPhieuChiDinh[r, "TenKhoa"].ToString();
                cmbNhomMau.SelectedIndex = int.Parse(fgPhieuChiDinh[r, "NhomMau"].ToString());
                if (Global.GetCode(cmbKhoa) != fgPhieuChiDinh[r, "MaKhoa"].ToString() && (_DaTinhPhi != "1" || _Daravien != "1"))
                {
                    cmdSua.Enabled = false;
                    cmdXoa.Enabled = false;
                }
                else
                {
                    cmdSua.Enabled = true;
                    cmdXoa.Enabled = true;
                }
                if (Global.glbUName.ToLower() != fgPhieuChiDinh[r, "UserName1"].ToString().ToLower() && (_DaTinhPhi != "1" || _Daravien != "1"))
                {
                    cmdSua.Enabled = false;
                    cmdXoa.Enabled = false;
                }
                else
                {
                    cmdSua.Enabled = true;
                    cmdXoa.Enabled = true;
                }
                System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
                if (cmbLoaiDS.SelectedIndex != 1)
                {
                    SQLCmd.CommandText = string.Format("SELECT a.DoiTuongBN,a.LoaiDichVu,TenLoaiDichVu,a.MaDichVu,a.TinhPhi,a.DaThucHien,TenDichVu,DVT,SoLuong,a.DonGia,SoLuong*a.DonGia*a.TyLe/100 as ThanhTien,a.GhiChu,DuyetBHYT as LuotIn,a.KhoID,a.MaPhieuDuyet,a.DaDuyet,a.DaThanhToan,a.LanInTT,a.Chot,a.NgayChot,SoLuongHT,SoLuongDuyet,LanChuyenDT, a.TyLe,MaPhieuCanQuang,a.TTThau,isnull(a.TyLeBHYT,c.TyLeBH) as TyLeBH,MaPhieuHoan,DuyetHoan,MaDichVuDuyet, a.MaKhoaThucHien, c.DonGia as GiaVP, C.DonGiaBHYT as GiaBHYT FROM "
                                        + " (PHIEUDIEUTRI_CHITIET a INNER JOIN DMLOAIDICHVU b ON a.LoaiDichVu=b.MaLoaiDichVu) "
                                        + " INNER JOIN DMDICHVU c ON a.LoaiDichVu=c.LoaiDichVu AND a.MaDichVu=c.MaDichVu WHERE SoPhieu='{0}' Order By a.LoaiDichVu,TenDichVu", SoPhieu);
                }
                else
                {
                    SQLCmd.CommandText = String.Format("select dmLoaiDichVu.MaLoaiDichVu as LoaiDichVu,dmLoaiDichVu.TenLoaiDichVu,DichVu.MaChiPhi as MaDichVu,dmDichVu.TenDichVu,"
                        + " dmdichvu.DVT,DichVu.SoLuong,DichVu.DonGia,DichVu.DonGia*DichVu.SoLuong*Dichvu.TyLe/100 as ThanhTien,Dichvu.Lieudung as GhiChu,case when DichVu.TinhPhi = 0 then 1 else 0 end as TinhPhi,DichVu.DaThucHien,"
                        + " '' as LuotIn,DichVu.KhoID,c.doituong as DoiTuongBN,MaPhieuDuyet,0 as DaDuyet,0 as DaThanhToan,'' as lanInTT,0 as Chot,'' as NgayChot,0 as SoLuongHT,SoLuongDuyet,0 as LanChuyenDT, DichVu.TyLe, '' as MaPhieuCanQuang, DichVu.TTThau,isnull(DichVu.TyLeBH,dmdichvu.TyLeBH) as TyLeBH,MaPhieuHoan,DuyetHoan,MaChiPhiDuyet as MaDichVuDuyet,'' as MaKhoaThucHien, dmdichvu.DonGia as GiaVP, dmdichvu.DongiaBHYT as GiaBHYT"
                        + " from [" + Global.glbKhamBenh + "].dbo.tblChiPhi_DichVu DichVu"
                        + " inner join dmdichvu on dmdichvu.madichvu = DichVu.MaChiPhi"
                        + " inner join dmLoaiDichVu on dmLoaiDichVu.MaLoaiDichVu = DichVu.LoaiChiPhi"
                        + " inner join NAMDINH_KHAMBENH.dbo.tblKHAMBENH c on c.MaKhambenh = DichVu.MaKhamBenh "
                        + " Where DichVu.MaPhieuCD='{0}'",SoPhieu);
                }
                System.Data.SqlClient.SqlDataReader dr = SQLCmd.ExecuteReader();
                fgDichVu.Redraw = false;
                fgDichVu.Rows.Count = 1;
                int row = 1;
                while (dr.Read())
                {
                    fgDichVu.Rows.Add();
                    fgDichVu[row, "LoaiDichVu"] = dr["LoaiDichVu"];
                    fgDichVu[row, "TenLoaiDV"] = dr["TenLoaiDichVu"];
                    fgDichVu[row, "MaDichVu"] = dr["MaDichVu"];
                    fgDichVu[row, "TenDichVu"] = dr["TenDichVu"];
                    fgDichVu[row, "DVTinh"] = dr["DVT"];
                    fgDichVu[row, "SoLuong"] = dr["SoLuong"];
                    fgDichVu[row, "DonGia"] = dr["DonGia"];
                    fgDichVu[row, "TyLe"] = dr["TyLe"];
                    fgDichVu[row, "ThanhTien"] = dr["ThanhTien"];
                    fgDichVu[row, "GhiChu"] = dr["GhiChu"];
                    fgDichVu[row, "DaThucHien"] = dr["DaThucHien"];
                    if (lblSoPhieu.Text.Substring(0, 2) == "CD")
                    {
                        this.cmdSua.Enabled = true;
                    }
                    fgDichVu[row, "KhongTinhPhi"] = dr["TinhPhi"];
                    fgDichVu[row, "LuotIn"] = dr["LuotIn"].ToString();
                    fgDichVu[row, "SoLuongCu"] = dr["SoLuong"];
                    fgDichVu[row, "SoLuongHT"] = dr["SoLuongHT"];
                    fgDichVu[row, "SoLuongDuyet"] = dr["SoLuongDuyet"];
                    fgDichVu[row, "KhoID"] = dr["KhoID"];
                    fgDichVu[row, "MaPhieuDuyet"] = dr["MaPhieuDuyet"];
                    fgDichVu[row, "DaDuyet"] = dr["DaDuyet"];
                    fgDichVu[row, "DaThanhToan"] = dr["DaThanhToan"];
                    fgDichVu[row, "LanInTT"] = dr["LanInTT"];
                    fgDichVu[row, "Chot"] = dr["Chot"];
                    fgDichVu[row, "NgayChot"] = dr["NgayChot"];
                    fgDichVu[row, "LanChuyenDT"] = dr["LanChuyenDT"];
                    fgDichVu[row, "MaPhieuCanQuang"] = dr["MaPhieuCanQuang"];
                    fgDichVu[row, "TTThau"] = dr["TTThau"];
                    fgDichVu[row, "TyleBH"] = dr["TyleBH"];
                    cmbDoiTuong.SelectedIndex = cmbDoiTuong.FindStringExact(dr["DoiTuongBN"].ToString(), 0, 0);
                    this.fgDichVu[row, "MaPhieuHoan"] = dr["MaPhieuHoan"];
                    this.fgDichVu[row, "DuyetHoan"] = dr["DuyetHoan"];
                    this.fgDichVu[row, "MaDichVuDuyet"] = dr["MaDichVuDuyet"];
                    this.fgDichVu[row, "MaKhoaThucHien"] = dr["MaKhoaThucHien"];
                    fgDichVu[row, "GiaVP"] = dr["GiaVP"];
                    fgDichVu[row, "GiaBHYT"] = dr["GiaBHYT"];
                    row++;
                }
                Format_Grid();
                fgDichVu.Redraw = true;
                dr.Close();
                SQLCmd.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
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
            fgDichVu.Styles.Normal.WordWrap = true;
            fgDichVu.Cols[fgDichVu.Cols["TenDichVu"].Index].Width = 300;
            fgDichVu.AutoSizeRows();
            fgDichVu.Redraw = true;
            lblDichVu.Text = "Dịch vụ y tế chỉ định ( " + SoKhoan.ToString() + " ) khoản";
        }
        private void fgPhieuChiDinh_AfterRowColChange(object sender, C1.Win.C1FlexGrid.RangeEventArgs e)
        {
            cmdThuThuat.Enabled = false;
            Global.wait("Đang tổng hợp dữ liệu ....");
            if (_DaTinhPhi != "1" || _Daravien != "1")
            {
                if (fgPhieuChiDinh.Tag.ToString() == "0" || fgPhieuChiDinh.Row < 1)
                {
                    Global.nowait();
                    return;
                }
                Load_PhieuDieutri_ChiTiet(fgPhieuChiDinh.Row);
                Global.nowait();
            }
            else
            {
                if (fgPhieuChiDinh.Tag.ToString() == "0" || fgPhieuChiDinh.Row < 1)
                {
                    Global.nowait();
                    cmdXoa.Enabled = false;
                    cmdThem.Enabled = false;
                    cmdSua.Enabled = false;
                    return;
                }
                Load_PhieuDieutri_ChiTiet(fgPhieuChiDinh.Row);
                cmdXoa.Enabled = false;
                cmdThem.Enabled = false;
                cmdSua.Enabled = false;
                Global.nowait();
            }
      
        }

        private void cmdThem_Click(object sender, EventArgs e)
        {
            if (txtMaBN.Text == "") return;
            if (raChiPhiHN.Checked == false && raChiPhiTT.Checked == false)
            {
                MessageBox.Show("Chọn lên chí phí trong ngày hay trong trực.", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            IsAddnew = true;
            Lock_Edit(false);
            Empty_Data();
            txtNgayChiDinh.Value = Global.NgayLV;
            //lblKhoa.Text = cmbKhoa.Text;
            cmbDoiTuong.SelectedIndex = 0;
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
            System.Data.SqlClient.SqlDataReader dr;
            cmd.CommandText = String.Format("select v.chandoan,c.CDChamSoc from viewkhoahientai v"
                + " left join benhnhan_phieudieutri c on c.mavaovien = v.mavaovien and right(c.sophieu,10) = "
                + " (select max(right(sophieu,10)) from benhnhan_phieudieutri where mavaovien = v.mavaovien)"
                + " where v.mavaovien = '{0}'", txtMaBN.Text);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                txtChanDoan.Text = dr["ChanDoan"].ToString();
                cmbCheDoChamSoc.SelectedIndex = cmbCheDoChamSoc.FindStringExact(dr["CDChamSoc"].ToString(), 0, 0);
            }
            dr.Close();
            cmd.Dispose();
        }

        private void cmdSua_Click(object sender, EventArgs e)
        {
            if (lblSoPhieu.Text == "0") return;
            if (raChiPhiHN.Checked == false && raChiPhiTT.Checked == false)
            {
                MessageBox.Show("Chọn lên chí phí trong ngày hay trong trực.", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (fgPhieuChiDinh.GetDataDisplay(fgPhieuChiDinh.Row, "MaKhoa") != Global.GetCode(cmbKhoa))
            {
                MessageBox.Show("Phiếu này được lập bởi khoa khác.\nBạn không thể sửa.", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Lock_Edit(false);
            IsAddnew = false;
        }

        private void cmdXoa_Click(object sender, EventArgs e)
        {
            if (fgPhieuChiDinh.Row < 1)
            {
                MessageBox.Show("Chưa chọn phiếu điều trị để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (fgPhieuChiDinh.GetDataDisplay(fgPhieuChiDinh.Row, "MaKhoa") != Global.GetCode(cmbKhoa))
            {
                MessageBox.Show("Bạn không thể xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            for (int i = 1; i < fgDichVu.Rows.Count; i++)
            {

                if (!fgDichVu.Rows[i].IsNode && fgDichVu[i, "DaThucHien"].ToString().ToLower() == "true")
                {
                    MessageBox.Show("đã có chí phí thực hiện. Bạn không thể xóa", "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            if (MessageBox.Show("Bạn có chắc muốn xóa phiếu điều trị này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
            //Kiem tra xem da in chua
            if (cmbLoaiDS.SelectedIndex != 1)
            {
                SQLCmd.CommandText = String.Format("Select Is_In from BenhNHan_PhieuDieutri where sophieu='{0}'", lblSoPhieu.Text.Trim());
                if (SQLCmd.ExecuteScalar().ToString() == "1")
                {
                    MessageBox.Show("Phiếu này đã được in. Bạn không thể xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            System.Data.SqlClient.SqlTransaction trn = Global.ConnectSQL.BeginTransaction();
            SQLCmd.Transaction = trn;
            try
            {
                SQLCmd.CommandText = string.Format("DECLARE @MaDichVu nvarchar(40)"
                    + " DECLARE @SoLuong DECIMAL(9,2)"
                    + " DECLARE MaDichVu CURSOR"
                    + " FOR"
                    + " SELECT MaDichVu,SoLuong from"
                    + " (Select * from phieudieutri_chitiet where sophieu='{0}') aa"
                    + " inner join dstravo on dstravo.mathuoc = aa.madichvu and dstravo.makhoa ='{1}'"
                    + " OPEN MaDichVu"
                    + " FETCH NEXT FROM MaDichVu INTO @MaDichVu,@SoLuong"
                    + " WHILE @@FETCH_STATUS = 0 "
                    + " BEGIN "
                    + " update BenhNhan_TraVo set soluongdsd = (select SoLuongdsd - @SoLuong from BenhNhan_TraVo where makhoa ='{1}' and mathuoc = @MaDichVu) "
                    + " where mathuoc = @MaDichVu and makhoa = '{1}'"
                    + " FETCH NEXT FROM MaDichVu INTO @MaDichVu,@SoLuong"
                    + " end"
                    + " CLOSE MaDichVu"
                    + " DEALLOCATE  MaDichVu",lblSoPhieu.Text,Global.GetCode(cmbKhoa));
                SQLCmd.ExecuteNonQuery();
                SQLCmd.CommandText = string.Format("DELETE FROM PHIEUDIEUTRI_CHITIET WHERE SoPhieu='{0}'", lblSoPhieu.Text);
                SQLCmd.ExecuteNonQuery();
                //SQLCmd.CommandText = string.Format("DELETE FROM BENHNHAN_PHIEUDIEUTRI WHERE SoPhieu='{0}' AND MaVaoVien='{1}'", lblSoPhieu.Text,txtMaBN.Text);
                //SQLCmd.ExecuteNonQuery();
                SQLCmd.CommandText = string.Format("delete from namdinh_khambenh.dbo.tblCHIPHI_DICHVU where MaPhieuCD = N'{0}'", lblSoPhieu.Text.Trim());
                SQLCmd.ExecuteNonQuery();
                trn.Commit();
                //if (fgPhieuChiDinh.Row == 1) Empty_Data();
                fgDichVu.Rows.Count = 1;
                Empty_Data();
            }
            catch (Exception ex)
            {
                trn.Rollback();
                MessageBox.Show("Có lỗi khi xóa dữ liệu\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SQLCmd.Dispose();
                trn.Dispose();
            }
            SQLCmd.CommandText = string.Format(" update  BENHNHAN_PHIEUDIEUTRI SET isDelete = 1, IsDateDelete = '{2:dd/MM/yyyy HH:mm}' WHERE SoPhieu='{0}' AND MaVaoVien='{1}'", fgPhieuChiDinh[fgPhieuChiDinh.Row, "SoPhieu"].ToString(), txtMaBN.Text, Global.GetNgayLV());
            SQLCmd.ExecuteNonQuery();
            fgPhieuChiDinh.RemoveItem(fgPhieuChiDinh.Row);
            SQLCmd.Dispose();
        }
        bool KiemTraDaCoHbA1C()
        {
            SqlCommand command = new SqlCommand();
            command.Connection = Global.ConnectSQL;
            try
            {
                command.CommandText = string.Format("select * from PHIEUDIEUTRI_CHITIET CT inner join BENHNHAN_PHIEUDIEUTRI PDT on CT.Sophieu = pdt.Sophieu where PDT.MAVAOVIEN  = '{0}' AND (CT.Madichvu = 'C50115' or CT.Madichvu = 'C50005')", this.txtMaBN.Text);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Close();
                    return true;
                }
                reader.Close();
                return false;
            }
            catch
            {
                return false;
            }
            finally
            {
                command.Dispose();
            }
        }

        private void cmdGhi_Click(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlCommand cmd1 = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
            System.Data.SqlClient.SqlDataReader dr1;
            bool SGOT_SGPT = false;
            bool CHOTP_TRI = false;
            bool HDL_LDL = false;
            bool BILTP_BILTT = false;
            bool SinhHoaMau = false;
            bool SinhHoaNuocTieu = false;
            bool MienDich = false;
            string DichVuKhongCapCuu = "C50012,C50013,C50014,C50015,C50115,C50005,C50029,C50030,C50031,C50032,C50033,C50026,C50075,C50076,C50078,C50080,C50097,C50028,C50077,C50027,C50079";
            string DichVuSinhHoaMau = "C50001,C50002,C50004,C50008,C50009,C50003,C50130,C50012,C50013,C50014,C50015,C50010,C50011,C50113,C50073,C50006,C50072,C50018,C50020,C50021,C50022,C50023,C50025,C50095,C50096,C50115,C50005,C50119,C50313,C50138,C50314";
            string DichVuSinhHoaNuocTieu = "C50042,C50081,C50082,C50085,C50088,C50089,C50090,C50091,C50092,C50098,C50052,C50064,C50065,C50069,C50070";
            string DichVuMienDich = "C50075,C50026,C50027,C50028,C50029,C50030,C50031,C50032,C50033,C50078,C50080,C50133,C50134,C50135,C50137,C58000,C58001,C50136";
            string Gioitinh = "";
            string NhomDichVu = "";
            if (this.txtNgayChiDinh.ValueIsDbNull)
            {
                MessageBox.Show("Chưa nhập ng\x00e0y giờ.\nĐề nghị nhập lại!", "Th\x00f4ng b\x00e1o", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                this.txtNgayChiDinh.Focus();
                return;
            }
            if (cmbLoaiDS.SelectedIndex == 1)
            {
                if (fg.GetDataDisplay(fg.Row, "NgayRaVien").ToString() == "")
                {
                    MessageBox.Show("Bệnh nhân đang ở trạng thái CHƯA KHÁM \n Không cập nhật được dịch vụ");
                    return;
                }
                string s1 = string.Format("{0:dd/MM/yyyy HH:mm}", DateTime.Parse(fg.GetDataDisplay(fg.Row, "NgayKham").ToString()));
                string s2 = string.Format("{0:dd/MM/yyyy HH:mm}", DateTime.Parse(fg.GetDataDisplay(fg.Row, "NgayRaVien").ToString()));
                if ((DateTime.Parse(txtNgayChiDinh.Text) >=  DateTime.Parse(s2)) || (DateTime.Parse(txtNgayChiDinh.Text) <= DateTime.Parse(s1)))
                {
                    MessageBox.Show(string.Format("Thời gian vào khám ({1}) <= Thời gian chỉ định <= Thời gian khám xong ({0}).\n Đề nghị nhập lại Thời gian chỉ định nằm trong khoảng thời gian trên!",s2,s1), "Th\x00f4ng b\x00e1o", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    txtNgayChiDinh.Focus();
                    return;
                }

                if (IsAddnew)
                {
                    cmd1.CommandText = String.Format("set dateformat dmy select NgayThucHien as Max_NgayCD,MaChiPhi,MaPhieuCD from NAMDINH_KHAMBENH.dbo.tblCHIPHI_DICHVU where MaKhamBenh = '{0}' and MaChiPhi IN('C03891', 'C03895', 'C03894', 'C03893', 'C03892')", txtMaBN.Text);
                    dr1 = cmd1.ExecuteReader();
                    while (dr1.Read())
                    {
                        string s = dr1["Max_NgayCD"].ToString();
                        string ss = dr1["MaChiPhi"].ToString();
                        for (int i = 0; i < this.fgDichVu.Rows.Count; i++)
                        {
                            if (dr1["Max_NgayCD"].ToString() != "")
                            {
                                if ((DateTime.Parse(txtNgayChiDinh.Text) == DateTime.Parse(dr1["Max_NgayCD"].ToString())) && (fgDichVu.GetDataDisplay(i, "Madichvu") == dr1["MaChiPhi"].ToString()))
                                {
                                    MessageBox.Show(string.Format("Chỉ định dịch vụ tiêm, truyền trùng thời gian {0:dd/MM/yyyy HH:mm}", DateTime.Parse(dr1["Max_NgayCD"].ToString())), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                    dr1.Close();
                                    cmd1.Dispose();
                                    return;
                                }
                            }
                        }
                    }
                    dr1.Close();
                    cmd1.Dispose();
                }

                if (!IsAddnew)
                {
                    cmd1.CommandText = String.Format("set dateformat dmy select NgayThucHien as Max_NgayCD,MaChiPhi,MaPhieuCD from NAMDINH_KHAMBENH.dbo.tblCHIPHI_DICHVU where MaKhamBenh = '{0}' and MaChiPhi IN('C03891', 'C03895', 'C03894', 'C03893', 'C03892') and MaPhieuCD != '{1}'", txtMaBN.Text,lblSoPhieu.Text);
                    dr1 = cmd1.ExecuteReader();
                    while (dr1.Read())
                    {
                        string s = dr1["Max_NgayCD"].ToString();
                        string ss = dr1["MaChiPhi"].ToString();
                        for (int i = 0; i < this.fgDichVu.Rows.Count; i++)
                        {
                            if (dr1["Max_NgayCD"].ToString() != "")
                            {
                                if ((DateTime.Parse(txtNgayChiDinh.Text) == DateTime.Parse(dr1["Max_NgayCD"].ToString())) && (fgDichVu.GetDataDisplay(i, "Madichvu") == dr1["MaChiPhi"].ToString()))
                                {
                                    MessageBox.Show(string.Format("Chỉ định dịch vụ tiêm, truyền trùng thời gian {0:dd/MM/yyyy HH:mm}", DateTime.Parse(dr1["Max_NgayCD"].ToString())), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                    dr1.Close();
                                    cmd1.Dispose();
                                    return;
                                }
                            }
                        }
                    }
                    dr1.Close();
                    cmd1.Dispose();
                }

            }

            cmd1.CommandText = String.Format("select b.thoigiandangky,a.DaRaVien from BENHNHAN_CHITIET a inner join NAMDINH_KHAMBENH.DBO.tblKHAMBENH B ON b.MaKhamBenh = A.MaKhamBenh"
           + " where a.mavaovien = '{0}'", txtMaBN.Text);
            dr1 = cmd1.ExecuteReader();
            while (dr1.Read())
            {
                DateTime thoigiandt = DateTime.Parse(dr1["ThoiGianDangKy"].ToString());
                if (this.txtNgayChiDinh.ValueIsDbNull || DateTime.Compare((DateTime)DateTime.Parse(txtNgayChiDinh.Text), (DateTime)thoigiandt) <= 0)
                {
                    MessageBox.Show(string.Format("Ngày giờ chỉ định >= Thời gian đăng ký({0}).\nĐề nghị nhập lại!", DateTime.Parse(dr1["ThoiGianDangKy"].ToString())), "Th\x00f4ng b\x00e1o", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    txtNgayChiDinh.Focus();
                    dr1.Close();
                    cmd1.Dispose();
                    return;
                }
                if (dr1["DaRaVien"].ToString() == "1")
                {
                    MessageBox.Show("Bệnh nhân đã ra viện không được chỉ định thêm");
                    dr1.Close();
                    cmd1.Dispose();
                    return;
                }
            }
            dr1.Close();
            cmd1.Dispose();

            if (this.cmbBacSyDT.SelectedIndex == -1)
            {
                MessageBox.Show("Chưa nhập bác sĩ điều trị.\nĐề nghị nhập lại!", "Th\x00f4ng b\x00e1o", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                this.cmbBacSyDT.Focus();
                return;
            }

            else if (this.cmbDoiTuong.SelectedIndex == -1)
            {
                MessageBox.Show("Chọn đối tượng t\x00ednh ph\x00ed!", "Th\x00f4ng b\x00e1o", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                this.txtDoiTuong.Focus();
            }
            else if (this.cmbCheDoChamSoc.SelectedIndex == -1)
            {
                MessageBox.Show("Chọn chế độ chăm s\x00f3c", "Th\x00f4ng b\x00e1o", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.cmbCheDoChamSoc.Focus();
            }
            else
            {
                int num;
                for (num = 1; num < this.fgDichVu.Rows.Count; num++)
                {
                    if (((this.fgDichVu.GetDataDisplay(num, "Madichvu") == "C03891") || (this.fgDichVu.GetDataDisplay(num, "Madichvu") == "C03895") || (this.fgDichVu.GetDataDisplay(num, "Madichvu") == "C03894") || (this.fgDichVu.GetDataDisplay(num, "Madichvu") == "C03893") || (this.fgDichVu.GetDataDisplay(num, "Madichvu") == "C03892")) && (this.fgDichVu.GetDataDisplay(num, "SoLuong").Trim() != "1"))
                    {
                        MessageBox.Show("Phải nhập số lượng = 1 " + Environment.NewLine + this.fgDichVu.GetDataDisplay(num, "TenDichVu"), "Th\x00f4ng b\x00e1o", MessageBoxButtons.OK);
                        return;
                    }
                    //Xét nghiệm giải phẫu phải có ghi chú
                    if ((this.fgDichVu.GetDataDisplay(num, "LoaiDichVu") == "C56") && (this.fgDichVu.GetDataDisplay(num, "GhiChu").Trim() == ""))
                    {
                        MessageBox.Show("Phải nhập bộ phận cần sinh thiết v\x00e0o phần ghi ch\x00fa của chỉ định: " + Environment.NewLine + this.fgDichVu.GetDataDisplay(num, "TenDichVu"), "Th\x00f4ng b\x00e1o", MessageBoxButtons.OK);
                        return;
                    }

                    if ((this.fgDichVu.GetDataDisplay(num, "LoaiDichVu") == "D01") && (this.fgDichVu[num, "KhongTinhPhi"].ToString().ToLower() == "false") && (this.fgDichVu.GetDataDisplay(num, "GhiChu").Trim() == ""))
                    {
                        MessageBox.Show("Phải nhập liều dùng của thuốc: " + Environment.NewLine + this.fgDichVu.GetDataDisplay(num, "TenDichVu"), "Th\x00f4ng b\x00e1o", MessageBoxButtons.OK);
                        return;
                    }
                    //Tạm bỏ cái này lại vì In phiếu tổng kết ko ra HIV..... do ko chuyển đối tượng mà chỉ chuyển đt tính phí
                    //Kiểm tra các dịch vụ BHYT ko thanh toán yêu cầu chuyển sang đối tượng Viện phí
                    //if ((((this.cmbDoiTuong.SelectedIndex == 0) ? this.MaDoiTuongBN : Global.GetCode(this.cmbDoiTuong)) == "1") && ((this.fgDichVu.GetDataDisplay(num, "MaDichVu") == "C50025") || (this.fgDichVu.GetDataDisplay(num, "MaDichVu") == "C50081") || (this.fgDichVu.GetDataDisplay(num, "MaDichVu") == "C51018") || (this.fgDichVu.GetDataDisplay(num, "MaDichVu") == "C51015") || (this.fgDichVu.GetDataDisplay(num, "MaDichVu") == "C51063") || (this.fgDichVu.GetDataDisplay(num, "MaDichVu") == "C52127") || (this.fgDichVu.GetDataDisplay(num, "MaDichVu") == "C52126") ))
                    //{
                    //    MessageBox.Show("Bạn phải tách các dịch vụ: " + this.fgDichVu.GetDataDisplay(num, "TenDichVu") + " sang một phiếu riêng và chuyển “Đối tượng tính phí” thành “Viện phí”." + Environment.NewLine + "(Do BHYT không thanh toán các dịch vụ này)", "Th\x00f4ng b\x00e1o", MessageBoxButtons.OK);
                    //    return;
                    //}

                    //Kiểm tra xem nếu là  HbA1C thì xem đã chỉ định trước đó chưa, nếu có thì cảnh báo 
                    if ((this.fgDichVu.GetDataDisplay(num, "MaDichVu") == "C50115") || (this.fgDichVu.GetDataDisplay(num, "MaDichVu") == "C50005"))
                    {
                        if (KiemTraDaCoHbA1C())
                        {
                            MessageBox.Show("Bệnh nhân này đã làm xét nghiệm HbA1C, đề nghị bạn xem lại.", "Th\x00f4ng b\x00e1o", MessageBoxButtons.OK);
                        }
                    }
                    //Kiểm tra xem nếu là  Rửa chấm thuốc điều trị viêm loét niêm mạc (1 lần) (C07096) 
                    if ((this.fgDichVu.GetDataDisplay(num, "MaDichVu") == "C07096") && (decimal.Parse(txtTuoi.Text) >= 16) && (txtDoiTuong.Text.Trim() == "Bảo hiểm y tế"))
                    {
                        MessageBox.Show("Thủ thuật: 'Rửa chấm thuốc điều trị viêm loét niêm mạc (1 lần)' chỉ thanh toán cho bệnh nhân ≤ 15 tuổi.", "Th\x00f4ng b\x00e1o", MessageBoxButtons.OK);
                    }
                    //Kiểm tra các xét nghiệm phải đi cùng nhau
                    if ((this.fgDichVu.GetDataDisplay(num, "MaDichVu") == "C50008") || (this.fgDichVu.GetDataDisplay(num, "MaDichVu") == "C50009")) SGOT_SGPT = !SGOT_SGPT;  // Nếu có SGOT, SGPT
                    if ((this.fgDichVu.GetDataDisplay(num, "MaDichVu") == "C50012") || (this.fgDichVu.GetDataDisplay(num, "MaDichVu") == "C50013")) CHOTP_TRI = !CHOTP_TRI; //Nếu có Chole, tri
                    if ((this.fgDichVu.GetDataDisplay(num, "MaDichVu") == "C50014") || (this.fgDichVu.GetDataDisplay(num, "MaDichVu") == "C50015")) HDL_LDL = !HDL_LDL; //Nếu có HDLC, LDLC
                    if ((this.fgDichVu.GetDataDisplay(num, "MaDichVu") == "C50006") || (this.fgDichVu.GetDataDisplay(num, "MaDichVu") == "C50072")) BILTP_BILTT = !BILTP_BILTT; // Nếu có BilTP, BilTT
                    //------------------------------------------
                    //Kiểm tra các xét nghiệm có nằm trong nhóm ko dùng cho Cấp cứu không (chưa làm)
                    if (!this.fgDichVu.Rows[num].IsNode && DichVuKhongCapCuu.IndexOf(this.fgDichVu.GetDataDisplay(num, "MaDichVu")) > -1 && chCapCuu.Checked)
                    {
                        MessageBox.Show("Dịch vụ: " + this.fgDichVu.GetDataDisplay(num, "TenDichVu") + " không xét nghiệm Cấp cứu.", "Th\x00f4ng b\x00e1o", MessageBoxButtons.OK);
                        return;
                    }
                    //Kiểm tra xét nghiệm có nằm trong nhóm Sinh hóa máu không?
                    if (!this.fgDichVu.Rows[num].IsNode && DichVuSinhHoaMau.IndexOf(this.fgDichVu.GetDataDisplay(num, "MaDichVu")) > -1)
                    {
                        SinhHoaMau = true;
                    }
                    //Kiểm tra xét nghiệm có nằm trong nhóm Sinh hóa nước tiểu không?
                    if (!this.fgDichVu.Rows[num].IsNode && DichVuSinhHoaNuocTieu.IndexOf(this.fgDichVu.GetDataDisplay(num, "MaDichVu")) > -1)
                    {
                        SinhHoaNuocTieu = true;
                    }
                    //Kiểm tra xét nghiệm có nằm trong nhóm Miễn dịch không?
                    if (!this.fgDichVu.Rows[num].IsNode && DichVuMienDich.IndexOf(this.fgDichVu.GetDataDisplay(num, "MaDichVu")) > -1)
                    {
                        MienDich = true;
                    }
                }
                if (SinhHoaMau && SinhHoaNuocTieu)
                {
                    MessageBox.Show("Không được chỉ định Sinh hóa máu và Sinh hóa nước tiểu trong cùng một phiếu chỉ định", "Thông báo!");
                    return;
                }
                if (SinhHoaMau && MienDich)
                {
                    MessageBox.Show("Không được chỉ định Sinh hóa máu và Miễn dịch trong cùng một phiếu chỉ định", "Thông báo!");
                    return;
                }
                if (MienDich && SinhHoaNuocTieu)
                {
                    MessageBox.Show("Không được chỉ định Miễn dịch và Sinh hóa nước tiểu trong cùng một phiếu chỉ định", "Thông báo!");
                    return;
                }
                if (SGOT_SGPT)
                {
                    MessageBox.Show("Bạn phải chỉ định cả SGOT và SGPT", "Thông báo!");
                    return;
                }
                if (CHOTP_TRI)
                {
                    MessageBox.Show("Bạn phải chỉ định cả Cholestrol toàn phần (máu) và Triglycerid (máu) ", "Thông báo!");
                    return;
                }
                if (HDL_LDL)
                {
                    MessageBox.Show("Bạn phải chỉ định cả HDL Cholestrol (máu) và LDL Cholestrol (máu)", "Thông báo!");
                    return;
                }
                if (BILTP_BILTT)
                {
                    MessageBox.Show("Bạn phải chỉ định cả Bilirubin toàn phần (máu) và Bilirubin trực tiếp (máu)", "Thông báo!");
                    return;
                }
                if (this.IsAddnew && (DateTime.Compare((DateTime)DateAndTime.DateAdd(DateInterval.Day, 7, (DateTime)txtNgayChiDinh.Value), Global.GetNgayLV()) < 0 || DateTime.Compare((DateTime)DateAndTime.DateAdd(DateInterval.Day, -7, (DateTime)txtNgayChiDinh.Value), Global.GetNgayLV()) > 0))
                {
                    MessageBox.Show("Ngày, giờ chỉ định chưa đúng!", "Thông báo!");
                    return;
                }
                //Kiểm tra vấn đề truyền máu xem đúng = nhau giữa số lượng đơn vị máu và đơn vị vận chuyển chưa

                for (num = 2; num < this.fgDichVu.Rows.Count; num++)
                {
                    if ((str_TruyenMau.Contains((string)this.fgDichVu.GetDataDisplay(num, "MaDichVu"))) && !fgDichVu.Rows[num].IsNode)
                    {
                        //Có truyền máu viện HHTMTW
                        //MessageBox.Show(str_TruyenMau);
                        //MessageBox.Show((string)this.fgDichVu.GetDataDisplay(num, "MaDichVu"));
                        if (fgDichVu.GetDataDisplay(2, "SoLuong") != fgDichVu.GetDataDisplay(3, "SoLuong"))
                        {
                            MessageBox.Show("Số lượng đơn vị vận chuyển phải bằng số lượng đơn vị máu!", "Thông báo!");
                            return;
                        }
                    }
                    int OK = 0;
                    if (!fgDichVu.Rows[num].IsNode)
                    {
                        if (int.TryParse(fgDichVu.GetDataDisplay(num, "SoLuong"), out OK))
                        {
                        }
                        if (OK == 0 && fgDichVu.GetData(num, "LoaiDichVu").ToString().Substring(0, 1) == "C" && fgDichVu.GetData(num, "TenDichVu").ToString().ToLower().IndexOf("thông khí") < 0)
                        {
                            MessageBox.Show("Số lượng dịch vụ phải là số tự nhiên >= 1!", "Thông báo!");
                            return;
                        }
                    }
                }

                /*--------Kiểm tra tiền trước khi ghi dữ liệu*/
                if (cmbLoaiDS.SelectedIndex == 1 && txtDoiTuong.Text == "Viện phí")
                {
                    double TongTienDaThucHien = 0;
                    double TienKyQuy = 0;
                    cmd1.CommandText = String.Format("select DV.Makhambenh, isnull(TienDV,0) + isnull(TienCPDV,0) as Tongtien,isnull( KQ.SoTienKQ,0) -  isnull(TienDV,0) - isnull(TienCPDV,0) as SotienCL, isnull( KQ.SoTienKQ,0) as SoTienKQ from "
                           + " (select tblKhambenh_Dichvu.Makhambenh, isnull(sum(tblKhambenh_Dichvu.Soluong * DMDichvu.Dongia*tblKhambenh_Dichvu.TyLe/100),0) as TienDV "
                           + " from NAMDINH_KHAMBENH.dbo.tblKhambenh_Dichvu  "
                           + " inner join DMDichvu on tblKhambenh_Dichvu.MaDichvu = DMDichvu.MaDichvu  "
                           + " inner join NAMDINH_KHAMBENH.dbo.tblKHAMBENH_CHIDINH kbcd on kbcd.MaKhambenh = tblKHAMBENH_DICHVU.MaKhambenh and kbcd.MaphieuCD = tblKHAMBENH_DICHVU.MaphieuCD and kbcd.isDeleted = 0"
                           + " where tblKhambenh_Dichvu.Makhambenh = '{0}' and left(tblKhambenh_Dichvu.Maphieucd,2) <> 'DT' "
                           + " group by tblKhambenh_Dichvu.Makhambenh ) DV"
                           + " left join "
                           + " (select  makhambenh, isnull(sum(tblCHIPHI_DICHVU.Soluong * tblCHIPHI_DICHVU.Dongia),0)   as TienCPDV"
                           + " from NAMDINH_KHAMBENH.dbo.tblCHIPHI_DICHVU  "
                           + " where tblCHIPHI_DICHVU.Makhambenh = '{0}' and tblCHIPHI_DICHVU.TinhPhi = 1"
                           + " group by Makhambenh ) CPDV on DV.MaKhambenh = CPDV.MaKhamBenh"
                           + " left join "
                           + " (SELECT Masokham, sum(ISNULL(SoTien, 0))  AS SoTienKQ FROM  "
                           + " NAMDINH_VIENPHI.dbo.tblThukyquy WHERE (Masokham = '{0}') and dahoantien<>1 and dahuy<>1"
                           + " group by Masokham ) KQ on DV.MaKhambenh = KQ.Masokham", txtMaBN.Text);
                    dr1 = cmd1.ExecuteReader();
                    while (dr1.Read())
                    {
                        TongTienDaThucHien = double.Parse(dr1["Tongtien"].ToString());
                        TienKyQuy = double.Parse(dr1["SoTienKQ"].ToString());
                    }
                    dr1.Close();

                    double TongTien = 0;
                    for (num = 1; num < this.fgDichVu.Rows.Count; num++)
                    {
                        if (fgDichVu.Rows[num].IsNode)
                        {
                            TongTien = TongTien + double.Parse(this.fgDichVu[num, "ThanhTien"].ToString());
                        }
                    }
                    if(TongTien+TongTienDaThucHien >= TienKyQuy)
                    {
                        MessageBox.Show("Số tiền đã vượt ký quỹ " + ((TongTien + TongTienDaThucHien) - TienKyQuy).ToString() + "\nĐề nghị bệnh nhân nộp thêm ký quỹ");
                        return;
                    }
                }

                // Het
                System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
                System.Data.SqlClient.SqlTransaction trn = Global.ConnectSQL.BeginTransaction();
                SQLCmd.Transaction = trn;
                String SoPhieu = lblSoPhieu.Text;
                int ID_Sophieu_EDIT = 0;
                try
                {
                    if (cmbLoaiDS.SelectedIndex != 1)
                    {
                        //Truong hop len chi phi cho nhung benh nhan o trong noi tru

                        //Đoạn code phục vụ khoa Hóa sinh thống kê các phiếu chỉ đinh bị sửa
                        if (!this.IsAddnew) // Nếu sửa phiếu
                        {
                            // Lưu lại phiếu cũ và chỉ định cũ
                            SQLCmd.CommandText = string.Format("INSERT INTO NAMDINH_CLS.dbo.BENHNHAN_PHIEUDIEUTRI_EDIT SELECT SoPhieu, MaVaoVien, NgayChiDinh, LoaiDT, BacSyDT, DienBienBenh, YLenh, CDChamSoc, CDDinhDuong, MaKhoa, Nhom, ChanDoan, CapCuu, mabs, NhomMau, SoThang, ChuThich, UserName1, Is_In, DaThucHien FROM BENHNHAN_PHIEUDIEUTRI WHERE SoPhieu='{0}' Select @@IDENTITY", SoPhieu);
                            ID_Sophieu_EDIT = (int)Convert.ChangeType(SQLCmd.ExecuteScalar(), typeof(int));
                            SQLCmd.CommandText = string.Format("INSERT INTO NAMDINH_CLS.dbo.PHIEUDIEUTRI_CHITIET_EDIT SELECT " + ID_Sophieu_EDIT + " as ID, a.SoPhieu, a.LoaiDichVu, a.MaDichVu, a.SoLuong, a.DonGia, a.GhiChu, a.DoiTuongBN, a.DaThucHien, a.LuotIn, a.TinhPhi, a.SoLuongHT, a.LyDo, a.Chot, a.NgayChot, a.UserName, a.KetQua, a.DaThanhToan, a.ChonDt, a.MaDichVuDuyet, a.SoLuongDuyet, a.DaDuyet, a.MaPhieuDuyet, a.MaNhom, a.KhoID, a.NgayIn, a.DuyetBHYT, a.UseDuyetBHYT, a.NgayduyetBHYT, a.SoBLTC, a.IDVIENPHI, a.LanInTT, a.LanChuyenDT, a.MaPhieuHoan, a.DuyetHoan, a.MaMay, a.SID, a.TyLe,a.TTThau FROM PHIEUDIEUTRI_CHITIET a WHERE a.SoPhieu='{0}'", SoPhieu);
                            SQLCmd.ExecuteNonQuery();
                            // Lưu lại phiếu chỉ định mới
                            SQLCmd.CommandText = string.Format("INSERT INTO NAMDINH_CLS.dbo.BENHNHAN_PHIEUDIEUTRI_EDIT (SoPhieu,MaVaovien,NgayChiDinh,LoaiDT,bacSyDT,DienBienBenh,YLenh,CDChamSoc,CDDinhDuong,MaKhoa,Nhom,ChanDoan,CapCuu,MaBS,NhomMau,UserName1) VALUES ('{0}','{1}',getdate(),{2},N'{3}',N'{4}',N'{5}',{6},{7},'{8}',{9},N'{10}',{11},{12},{13},N'{14}') Select @@IDENTITY ", new object[] { SoPhieu, this.txtMaBN.Text, "null", this.cmbBacSyDT.Columns[1].CellText(this.cmbBacSyDT.SelectedIndex), this.txtDienBienBenh.Text, this.txtYLenh.Text, (this.cmbCheDoChamSoc.SelectedIndex == -1) ? "null" : Global.GetCode(this.cmbCheDoChamSoc), (this.cmbCheDoDinhDuong.SelectedIndex == -1) ? "null" : Global.GetCode(this.cmbCheDoDinhDuong), Global.GetCode(this.cmbKhoa), this.raChiPhiTT.Checked ? 1 : 0, this.txtChanDoan.Text.Trim(), this.chCapCuu.Checked ? 1 : 0, (Global.GetCode(this.cmbBacSyDT) == null) ? "null" : Global.GetCode(this.cmbBacSyDT), this.cmbNhomMau.SelectedIndex, Global.glbUName });
                            ID_Sophieu_EDIT = (int)Convert.ChangeType(SQLCmd.ExecuteScalar(), typeof(int));
                            SQLCmd.CommandText = "";
                            for (int i = 1; i < this.fgDichVu.Rows.Count; i++)
                            {
                                if (!this.fgDichVu.Rows[i].IsNode)
                                {
                                    double num4;
                                    double num5;
                                    int lanChuyenDT;
                                    double num2 = (this.fgDichVu[i, "DonGia"].ToString() == "") ? 0.0 : double.Parse(this.fgDichVu[i, "DonGia"].ToString());
                                    double num3 = double.Parse(this.fgDichVu[i, "SoLuong"].ToString());
                                    if (this.fgDichVu.GetDataDisplay(i, "SoLuongHT") == "")
                                    {
                                        num4 = 0.0;
                                    }
                                    else
                                    {
                                        num4 = double.Parse(this.fgDichVu[i, "SoLuongHT"].ToString());
                                    }
                                    if (this.fgDichVu.GetDataDisplay(i, "SoLuongDuyet") == "")
                                    {
                                        num5 = 0.0;
                                    }
                                    else
                                    {
                                        num5 = double.Parse(this.fgDichVu[i, "SoLuongDuyet"].ToString());
                                    }
                                    if (this.fgDichVu.GetDataDisplay(i, "LanChuyenDT") == "")
                                    {
                                        lanChuyenDT = this.LanChuyenDT;
                                    }
                                    else
                                    {
                                        lanChuyenDT = int.Parse(this.fgDichVu[i, "LanChuyenDT"].ToString());
                                    }
                                    SQLCmd.CommandText = SQLCmd.CommandText + string.Format(" INSERT INTO NAMDINH_CLS.dbo.PHIEUDIEUTRI_CHITIET_EDIT (SoPhieu,LoaiDichVu,MaDichVu,SoLuong,DonGia,GhiChu,DoiTuongBN,DaThucHien,TinhPhi,UserName,ChonDT,DuyetBHYT,MaNhom,KhoID,MaPhieuDuyet,DaThanhToan,DaDuyet,LanInTT,Chot,NgayChot,SoLuongHT,SoLuongDuyet,LanChuyenDT, ID) VALUES ('{0}','{1}','{2}',{3},{4},N'{5}','{6}',{7},{8},N'{9}',{10},{11},{12},{13},'{14}',{15},{16},{17},{18},{19},{20},{21},{22},{23})", new object[] {
                                SoPhieu, this.fgDichVu[i, "LoaiDichVu"], this.fgDichVu[i, "MaDichVu"], num3.ToString().Replace(",", "."), num2.ToString().Replace(",", "."), this.fgDichVu[i, "GhiChu"], (this.cmbDoiTuong.SelectedIndex == 0) ? this.MaDoiTuongBN : Global.GetCode(this.cmbDoiTuong), (this.fgDichVu[i, "DaThucHien"].ToString().ToLower() == "true") ? 1 : 0, (this.fgDichVu[i, "KhongTinhPhi"].ToString().ToLower() == "true") ? 1 : 0, Global.glbUName, this.cmbDoiTuong.SelectedIndex, (this.fgDichVu.GetDataDisplay(i, "LuotIn") == "") ? "null" : this.fgDichVu[i, "Luotin"].ToString(), this.MaNhom, (this.fgDichVu[i, "KhoID"].ToString() == "") ? "null" : this.fgDichVu[i, "KhoID"].ToString(), this.fgDichVu.GetDataDisplay(i, "MaPhieuDuyet"), (this.fgDichVu.GetDataDisplay(i, "DaThanhToan").ToString() == "") ? "0" : this.fgDichVu.GetDataDisplay(i, "DaThanhToan"),
                                (this.fgDichVu.GetDataDisplay(i, "DaDuyet").ToString() == "") ? "0" : this.fgDichVu.GetDataDisplay(i, "DaDuyet"), (this.fgDichVu.GetDataDisplay(i, "LanInTT").ToString() == "") ? "null" : this.fgDichVu.GetDataDisplay(i, "LanInTT"), (this.fgDichVu.GetDataDisplay(i, "Chot").ToString() == "") ? "0" : this.fgDichVu.GetDataDisplay(i, "Chot"),
                                        (this.fgDichVu.GetDataDisplay(i, "NgayChot").ToString() == "") ? "null" : string.Format("'{0:dd/MM/yyyy}'", this.fgDichVu.GetData(i, "NgayChot")), num4.ToString().Replace(",", "."), num5.ToString().Replace(",", "."), lanChuyenDT, ID_Sophieu_EDIT});
                                }
                            }
                            SQLCmd.ExecuteNonQuery();
                        }
                        //-------------------------------------------------------------------

                        if (IsAddnew)
                        {
                            SQLCmd.CommandText = string.Format("select dbo.LaySoPhieu(Right(Convert(nvarchar(8),'{0:yyyyMMdd}',112),6)) As SoPhieu", txtNgayChiDinh.Value);
                            SoPhieu = SQLCmd.ExecuteScalar().ToString();
                            SQLCmd.CommandText = string.Format("set dateformat dmy INSERT INTO BENHNHAN_PHIEUDIEUTRI "
                                + " (SoPhieu,MaVaovien,NgayChiDinh,LoaiDT,bacSyDT,DienBienBenh,YLenh,CDChamSoc,CDDinhDuong,MaKhoa,Nhom,ChanDoan,CapCuu,CCHN_NT,NhomMau,UserName1,MaPhieuCanQuang,MaGiuongYT,mabs)"
                                + " VALUES ('{0}','{1}','{2:dd/MM/yyyy HH:mm}',{3},N'{4}',N'{5}',N'{6}',{7},{8},'{9}',{10},N'{11}',{12},N'{13}',{14},N'{15}','{0}',N'{16}',{17})",
                                    SoPhieu,
                                    txtMaBN.Text,
                                    txtNgayChiDinh.Value,
                                    "null",
                                    cmbBacSyDT.Columns[1].CellText(cmbBacSyDT.SelectedIndex),
                                    txtDienBienBenh.Text,
                                    txtYLenh.Text,
                                    (cmbCheDoChamSoc.SelectedIndex == -1) ? ("null") : (Global.GetCode(cmbCheDoChamSoc)),
                                    (cmbCheDoDinhDuong.SelectedIndex == -1) ? ("null") : (Global.GetCode(cmbCheDoDinhDuong)),
                                    Global.GetCode(cmbKhoa),
                                    raChiPhiTT.Checked == true ? 1 : 0,
                                    txtChanDoan.Text.Trim(),
                                    chCapCuu.Checked == true ? 1 : 0,
                                    this.cmbBacSyDT.Columns[2].CellText(this.cmbBacSyDT.SelectedIndex),
                                    //Global.GetCode(cmbBacSyDT) == null ? "null" : Global.GetCode(cmbBacSyDT),
                                    cmbNhomMau.SelectedIndex,
                                    Global.glbUName,lblMaGiuongYT.Text, cmbBacSyDT.Columns[0].CellText(cmbBacSyDT.SelectedIndex));
                        }
                        else
                        {
                            SQLCmd.CommandText = string.Format("set dateformat dmy  UPDATE BENHNHAN_PHIEUDIEUTRI SET NgayChiDinh='{1:dd/MM/yyyy HH:mm}',LoaiDT={2},bacSyDT=N'{3}',DienBienBenh=N'{4}',YLenh=N'{5}',CDChamSoc={6},CDDinhDuong={7},ChanDoan=N'{8}',CapCuu ={9},CCHN_NT=N'{10}',NhomMau={11},Nhom={12},MaPhieuCanQuang = '{0}',MaGiuongYT = N'{13}',mabs ={14} WHERE SoPhieu ='{0}'",
                                    SoPhieu, txtNgayChiDinh.Value,
                                    "null",
                                    cmbBacSyDT.Columns[1].CellText(cmbBacSyDT.SelectedIndex), txtDienBienBenh.Text, txtYLenh.Text,
                                    (cmbCheDoChamSoc.SelectedIndex == -1) ? ("null") : (Global.GetCode(cmbCheDoChamSoc)),
                                    (cmbCheDoDinhDuong.SelectedIndex == -1) ? ("null") : (Global.GetCode(cmbCheDoDinhDuong)),
                                    txtChanDoan.Text.Trim(), chCapCuu.Checked == true ? 1 : 0,
                                    this.cmbBacSyDT.Columns[2].CellText(this.cmbBacSyDT.SelectedIndex),
                                    //Global.GetCode(cmbBacSyDT) == null ? "null" : Global.GetCode(cmbBacSyDT),
                                    cmbNhomMau.SelectedIndex,
                                    raChiPhiHN.Checked == true ? "0" : "1",lblMaGiuongYT.Text, cmbBacSyDT.Columns[0].CellText(cmbBacSyDT.SelectedIndex));
                        }
                        SQLCmd.ExecuteNonQuery();
                        SQLCmd.CommandText = string.Format("DELETE FROM PHIEUDIEUTRI_CHITIET WHERE SoPhieu='{0}'", SoPhieu);
                        SQLCmd.ExecuteNonQuery();
                        double DonGia, SoLuong, SoLuongHT, SoLuongDuyet, TyLe;
                        int LanChuyenHT;
                        for (int i = 1; i < fgDichVu.Rows.Count; i++)
                        {
                            string MaphieuCQ = "";
                            if (!fgDichVu.Rows[i].IsNode)
                            {
                                DonGia = fgDichVu[i, "DonGia"].ToString() == "" ? 0 : double.Parse(fgDichVu[i, "DonGia"].ToString());
                                SoLuong = double.Parse(fgDichVu[i, "SoLuong"].ToString());
                                TyLe = int.Parse(this.fgDichVu[i, "TyLe"].ToString());
                                if (fgDichVu.GetDataDisplay(i, "SoLuongHT") == "")
                                {
                                    SoLuongHT = 0;
                                }
                                else
                                {
                                    SoLuongHT = double.Parse(fgDichVu[i, "SoLuongHT"].ToString());
                                }
                                if (fgDichVu.GetDataDisplay(i, "SoLuongDuyet") == "")
                                {
                                    SoLuongDuyet = 0;
                                }
                                else
                                {
                                    SoLuongDuyet = double.Parse(fgDichVu[i, "SoLuongDuyet"].ToString());
                                }
                                if (fgDichVu.GetDataDisplay(i, "LanChuyenDT") == "")
                                {
                                    LanChuyenHT = LanChuyenDT;
                                }
                                else
                                {
                                    LanChuyenHT = int.Parse(fgDichVu[i, "LanChuyenDT"].ToString());
                                }
                                if (this.fgDichVu.GetDataDisplay(i, "MaDichVu") == "T00000000000013" || this.fgDichVu.GetDataDisplay(i, "MaDichVu") == "T00000000000061" || this.fgDichVu.GetDataDisplay(i, "MaDichVu") == "T00000000000359" || this.fgDichVu.GetDataDisplay(i, "MaDichVu") == "T00000000000625" || this.fgDichVu.GetDataDisplay(i, "MaDichVu") == "T00000000000730" || this.fgDichVu.GetDataDisplay(i, "MaDichVu") == "T00000000001199" || this.fgDichVu.GetDataDisplay(i, "MaDichVu").Contains("TCQ"))
                                {
                                    MaphieuCQ = SoPhieu;
                                }
                                if (this.fgDichVu.GetDataDisplay(i, "LoaiDichVu") == "C54" || this.fgDichVu.GetDataDisplay(i, "LoaiDichVu") == "C57" || this.fgDichVu.GetDataDisplay(i, "LoaiDichVu") == "C59" || this.fgDichVu.GetDataDisplay(i, "LoaiDichVu") == "C60" || this.fgDichVu.GetDataDisplay(i, "LoaiDichVu") == "C61" || this.fgDichVu.GetDataDisplay(i, "LoaiDichVu") == "C62")
                                {
                                    if (txtGioi.Text == "Nữ")
                                    { Gioitinh = "F"; }
                                    else { Gioitinh = "M"; }
                                    if (fgDichVu.GetDataDisplay(i, "LoaiDichVu") == "C54") NhomDichVu = "XQ";
                                    if (fgDichVu.GetDataDisplay(i, "LoaiDichVu") == "C57") NhomDichVu = "CT64";
                                    if (fgDichVu.GetDataDisplay(i, "LoaiDichVu") == "C59") NhomDichVu = "MR";
                                    if (fgDichVu.GetDataDisplay(i, "LoaiDichVu") == "C60") NhomDichVu = "CT64";
                                    if (fgDichVu.GetDataDisplay(i, "LoaiDichVu") == "C61") NhomDichVu = "CT20";
                                    if (fgDichVu.GetDataDisplay(i, "LoaiDichVu") == "C62") NhomDichVu = "CT2";
                                    string s = fgDichVu.GetDataDisplay(i, "LoaiDichVu");
                                }
                                SQLCmd.CommandText += string.Format(" INSERT INTO PHIEUDIEUTRI_CHITIET (SoPhieu,LoaiDichVu,MaDichVu,SoLuong,DonGia,GhiChu,DoiTuongBN,DaThucHien,TinhPhi,UserName,ChonDT,DuyetBHYT,MaNhom,KhoID,MaPhieuDuyet,DaThanhToan,DaDuyet,LanInTT,Chot,NgayChot,SoLuongHT,SoLuongDuyet,LanChuyenDT, TyLe,maphieucanquang,TTThau,TyLeBHYT,MaPhieuHoan,DuyetHoan,MaDichVuDuyet,MaKhoaThucHien)"
                                    + " VALUES ('{0}','{1}','{2}',{3:#,##0.##},{4:#,##0.##},N'{5}','{6}',{7},{8},N'{9}',{10},{11},{12},{13},'{14}',{15},{16},{17},{18},{19},{20},{21},{22},{23},'{24}','{25}','{26}','{27}','{28}','{29}','{30}')",
                                                            SoPhieu,
                                                            fgDichVu[i, "LoaiDichVu"],
                                                            fgDichVu[i, "MaDichVu"],
                                                            SoLuong.ToString().Replace(",", "."),
                                                            DonGia.ToString().Replace(",", "."),
                                                            fgDichVu[i, "GhiChu"],
                                                            (cmbDoiTuong.SelectedIndex == 0) ? (MaDoiTuongBN) : (Global.GetCode(cmbDoiTuong)),
                                                            fgDichVu[i, "DaThucHien"].ToString().ToLower() == "true" ? 1 : 0,
                                                             fgDichVu[i, "KhongTinhPhi"].ToString().ToLower() == "true" ? 1 : 0,
                                                             Global.glbUName,
                                                             cmbDoiTuong.SelectedIndex,
                                                             fgDichVu.GetDataDisplay(i, "LuotIn") == "" ? "null" : fgDichVu[i, "Luotin"].ToString(),
                                                             MaNhom, fgDichVu[i, "KhoID"].ToString() == "" ? "null" : fgDichVu[i, "KhoID"].ToString(),
                                                             fgDichVu.GetDataDisplay(i, "MaPhieuDuyet"),
                                                             fgDichVu.GetDataDisplay(i, "DaThanhToan").ToString() == "" ? "0" : fgDichVu.GetDataDisplay(i, "DaThanhToan"),
                                                             fgDichVu.GetDataDisplay(i, "DaDuyet").ToString() == "" ? "0" : fgDichVu.GetDataDisplay(i, "DaDuyet"),
                                                             fgDichVu.GetDataDisplay(i, "LanInTT").ToString() == "" ? "null" : fgDichVu.GetDataDisplay(i, "LanInTT"),
                                                             fgDichVu.GetDataDisplay(i, "Chot").ToString() == "" ? "0" : fgDichVu.GetDataDisplay(i, "Chot"),
                                                             fgDichVu.GetDataDisplay(i, "NgayChot").ToString() == "" ? "null" : string.Format("'{0:dd/MM/yyyy}'", fgDichVu.GetData(i, "NgayChot")),
                                                             //(this.fgDichVu.GetDataDisplay(i, "NgayChot").ToString() == "") ? "null" : string.Format("'{0:MM/dd/yyyy}'", this.fgDichVu.GetData(i, "NgayChot")),
                                                             SoLuongHT.ToString().Replace(",", "."),
                                                             SoLuong.ToString().Replace(",", "."), 
                                                             LanChuyenHT, 
                                                             TyLe, 
                                                             MaphieuCQ, 
                                                             fgDichVu.GetDataDisplay(i, "TTThau"), 
                                                             fgDichVu.GetDataDisplay(i,"TyleBH"),
                                                             this.fgDichVu[i, "MaPhieuHoan"],
                                                            (this.fgDichVu.GetDataDisplay(i, "DuyetHoan").ToString() == "") ? "0" : this.fgDichVu.GetDataDisplay(i, "DuyetHoan"),
                                                            fgDichVu.GetDataDisplay(i, "MaDichVuDuyet"), fgDichVu.GetDataDisplay(i, "MaKhoaThucHien"));
                                if (this.fgDichVu.GetDataDisplay(i, "LoaiDichVu") == "C54" || this.fgDichVu.GetDataDisplay(i, "LoaiDichVu") == "C57" || this.fgDichVu.GetDataDisplay(i, "LoaiDichVu") == "C59" || this.fgDichVu.GetDataDisplay(i, "LoaiDichVu") == "C60" || this.fgDichVu.GetDataDisplay(i, "LoaiDichVu") == "C61" || this.fgDichVu.GetDataDisplay(i, "LoaiDichVu") == "C62")
                                {
                                    SQLCmd.CommandText = SQLCmd.CommandText + string.Format(" Begin if NOT EXISTS (select  * from NAMDINH_CLS.dbo.pacstest where MaChiDinh = N'{0}' AND MADICHVU = N'{11}') BEGIN  INSERT INTO NAMDINH_CLS.dbo.pacstest(MaChiDinh, ThoiGianChiDinh, MaBenhNhan, TenBenhNhan, NgaySinh, GioiTinh, DiaChi, SDT, NoiChiDinh, MaBacSiChiDinh, TenBacSiChiDinh, MaDichVu, TenDichVu, NhomDichVu, ChanDoan, TrangThai,DaGui)VALUES (N'{0}',N'{1:yyyyMMddHHmmss}',N'{2}',N'{3}',N'{4}',N'{5}',N'{6}',N'{7}',N'{8}','{9}',N'{10}',N'{11}',N'{12}',N'{13}',N'{14}',N'{15}','{16}') End else begin update NAMDINH_CLS.dbo.pacstest set  ThoiGianChiDinh = N'{1:yyyyMMddHHmmss}', MaBacSiChiDinh = N'{9}', TenBacSiChiDinh = N'{10}', MaDichVu = N'{11}', TenDichVu = N'{12}', NhomDichVu = N'{13}' where MaChiDinh  = N'{0}' AND MaDichVu = N'{11}' END END ", new object[]
                                    { SoPhieu, this.txtNgayChiDinh.Value, this.txtMaBN.Text, txtHoTen.Text, DateTime.Parse(txtNgayChiDinh.Text).Year - int.Parse(txtTuoi.Text) + "0101", Gioitinh, ".", "123456789", Global.GetCode(cmbKhoa), Global.GetCode(cmbBacSyDT), cmbBacSyDT.Text, this.fgDichVu[i, "MaDichVu"], this.fgDichVu[i, "TenDichVu"],NhomDichVu, ".", "NW","0" });

                                }

                                //Them so luong nhung thuoc phai tra vo
                                SQLCmd.CommandText += String.Format(" if(exists(select * from dstravo where makhoa='{0}' and mathuoc = '{1}')) "
                                       + " begin if(exists(select * from benhnhan_travo inner join dstravo on dstravo.makhoa = "
                                       + " benhnhan_travo.makhoa and dstravo.makhoa ='{0}' "
                                       + "	where benhnhan_travo.makhoa='{0}' and benhnhan_travo.mathuoc='{1}'))"
                                       + " begin"
                                       + " update benhnhan_travo set soluongdsd = ", Global.GetCode(cmbKhoa), fgDichVu[i, "MaDichVu"]);
                                if (IsAddnew)
                                {
                                    SQLCmd.CommandText += String.Format(" (select SoLuongDSD + {2} from benhnhan_travo where makhoa='{0}'  and mathuoc ='{1}')"
                                       + " where makhoa='{0}'  and mathuoc ='{1}'", Global.GetCode(cmbKhoa), fgDichVu[i, "MaDichVu"], fgDichVu[i, "SoLuong"].ToString().Replace(",", "."));
                                }
                                else
                                {
                                    SQLCmd.CommandText += String.Format(" (select SoLuongDSD + {2} - {3} from benhnhan_travo where makhoa='{0}' and mathuoc ='{1}')"
                                       + " where makhoa='{0}' and mathuoc ='{1}'", Global.GetCode(cmbKhoa), fgDichVu[i, "MaDichVu"], fgDichVu[i, "SoLuong"].ToString().Replace(",", "."), fgDichVu[i, "SoLuongCu"].ToString().Replace(",", "."));
                                }
                                SQLCmd.CommandText += String.Format(" end"
                                        + " else"
                                        + " begin"
                                        + " insert into benhnhan_travo(makhoa,mathuoc,soluongdsd,soluongdt)"
                                        + " values('{0}','{1}',{2},0)"
                                        + " end end", Global.GetCode(cmbKhoa), fgDichVu[i, "MaDichVu"], fgDichVu[i, "SoLuong"].ToString().Replace(",", "."));
                            }
                        }
                    }
                    else
                    {

                        //Truong hop len chi phi cho nhung benh nhan o phong kham
                        //SQLCmd.CommandText = string.Format("select dbo.LaySoPhieuNoiNgoai(Right(Convert(nvarchar(8),'{0:yyyyMMdd}',112),6)) As SoPhieu", txtNgayChiDinh.Value);
                        //SoPhieu = SQLCmd.ExecuteScalar().ToString();
                        if (IsAddnew)
                        {
                            SoPhieu = "";
                            SQLCmd.CommandText = string.Format("select dbo.LaySoPhieuNoiNgoai(Right(Convert(nvarchar(8),'{0:yyyyMMdd}',112),6)) As SoPhieu", txtNgayChiDinh.Value);
                            SoPhieu = SQLCmd.ExecuteScalar().ToString();
                        }
                        else
                        {
                            SQLCmd.CommandText = string.Format("DELETE FROM [" + Global.glbKhamBenh + "].dbo.tblChiPhi_DichVu WHERE MaPhieuCD='{0}'", lblSoPhieu.Text.Trim());
                            SoPhieu = lblSoPhieu.Text.Trim();
                        }
                        SQLCmd.ExecuteNonQuery();
                        // Lay Max thoi gian chi dinh
                        //DateTime Max_ThoiGianCd;
                        //SQLCmd.CommandText = string.Format("set dateformat dmy select max(ThoigianCD) as Max_ThoiGianCd from NAMDINH_KHAMBENH.dbo.tblKHAMBENH_CHIDINH where MaKhamBenh = '{0}'", txtMaBN.Text);
                        //Max_ThoiGianCd =  DateTime.Parse(SQLCmd.ExecuteScalar().ToString());
                        double DonGia, SoLuong, TyLe;
                        for (int i = 1; i < fgDichVu.Rows.Count; i++)
                        {
                           
                            if (!fgDichVu.Rows[i].IsNode)
                            {

                                DonGia = fgDichVu[i, "DonGia"].ToString() == "" ? 0 : double.Parse(fgDichVu[i, "DonGia"].ToString());
                                SoLuong = double.Parse(fgDichVu[i, "SoLuong"].ToString());
                                TyLe = double.Parse(fgDichVu[i, "TyLe"].ToString());
                                SQLCmd.CommandText += string.Format(" INSERT INTO [" + Global.glbKhamBenh + "].dbo.tblChiPhi_DichVu (MaPhieuCD,LoaiChiPhi,MaChiPhi,SoLuong,DonGia,"
                                    + "DaThucHien,TinhPhi,"
                                    + "UserName,MaNhom,KhoID,MaKhamBenh,MaKhoaThucHien,MaDichVu,NgayThucHien,MaPhieuDuyet, TyLe,TTThau,LieuDung,TyLeBH,MaPhieuHoan,DuyetHoan,MaChiPhiDuyet)"
                                    + " VALUES ('{0}','{1}','{2}',{3:#,##0.##},{4:#,##0.##},'{5}',{6},N'{7}',{8},{9},'{10}','{11}','{12}','{13:dd/MM/yyyy HH:mm}','{14}',{15},'{16}','{17}','{18}','{19}','{20}','{21}')",
                                                            SoPhieu,
                                                            fgDichVu[i, "LoaiDichVu"],
                                                            fgDichVu[i, "MaDichVu"],
                                                            SoLuong.ToString().Replace(",", "."),
                                                            DonGia.ToString().Replace(",", "."),
                                                            fgDichVu[i, "DaThucHien"].ToString().ToLower() == "true" ? 1 : 0,
                                                             fgDichVu[i, "KhongTinhPhi"].ToString().ToLower() == "true" ? 0 : 1,
                                                             Global.GetCode(cmbBacSyDT) == null ? "null" : Global.GetCode(cmbBacSyDT),
                                                             MaNhom,
                                                             fgDichVu[i, "KhoID"].ToString() == "" ? "null" : fgDichVu[i, "KhoID"].ToString(),
                                                             txtMaBN.Text.Trim(),
                                                             Global.GetCode(cmbKhoa),
                                                             fgPhieuChiDinh.GetDataDisplay(fgPhieuChiDinh.Row, "LoaiDT"),
                                                              //Max_ThoiGianCd,
                                                             txtNgayChiDinh.Value,
                                                             fgDichVu.GetDataDisplay(i, "MaPhieuDuyet"), 
                                                             TyLe, 
                                                             fgDichVu.GetDataDisplay(i, "TTThau"), 
                                                             fgDichVu.GetDataDisplay(i, "GhiChu"), 
                                                             fgDichVu.GetDataDisplay(i, "TyleBH"),
                                                             fgDichVu.GetDataDisplay(i, "MaPhieuHoan"),
                                                            (this.fgDichVu.GetDataDisplay(i, "DuyetHoan").ToString() == "") ? "0" : this.fgDichVu.GetDataDisplay(i, "DuyetHoan"),
                                                            fgDichVu.GetDataDisplay(i, "MaDichVuDuyet"));


                                //Them so luong nhung thuoc phai tra vo
                                SQLCmd.CommandText += String.Format(" if(exists(select * from dstravo where makhoa='{0}' and mathuoc = '{1}')) "
                                       + " begin if(exists(select * from benhnhan_travo inner join dstravo on dstravo.makhoa = "
                                       + " benhnhan_travo.makhoa and dstravo.makhoa ='{0}' "
                                       + "	where benhnhan_travo.makhoa='{0}' and benhnhan_travo.mathuoc='{1}'))"
                                       + " begin"
                                       + " update benhnhan_travo set soluongdsd = ", Global.GetCode(cmbKhoa), fgDichVu[i, "MaDichVu"]);
                                if (IsAddnew)
                                {
                                    SQLCmd.CommandText += String.Format(" (select SoLuongDSD + {2} from benhnhan_travo where makhoa='{0}'  and mathuoc ='{1}')"
                                       + " where makhoa='{0}'  and mathuoc ='{1}'", Global.GetCode(cmbKhoa), fgDichVu[i, "MaDichVu"], fgDichVu[i, "SoLuong"].ToString().Replace(",", "."));
                                }
                                else
                                {
                                    SQLCmd.CommandText += String.Format(" (select SoLuongDSD + {2} - {3} from benhnhan_travo where makhoa='{0}' and mathuoc ='{1}')"
                                       + " where makhoa='{0}' and mathuoc ='{1}'", Global.GetCode(cmbKhoa), fgDichVu[i, "MaDichVu"], fgDichVu[i, "SoLuong"].ToString().Replace(",", "."), fgDichVu[i, "SoLuongCu"].ToString().Replace(",", "."));
                                }
                                SQLCmd.CommandText += String.Format(" end"
                                        + " else"
                                        + " begin"
                                        + " insert into benhnhan_travo(makhoa,mathuoc,soluongdsd,soluongdt)"
                                        + " values('{0}','{1}',{2},0)"
                                        + " end end", Global.GetCode(cmbKhoa), fgDichVu[i, "MaDichVu"], fgDichVu[i, "SoLuong"].ToString().Replace(",", "."));
                            }
                        }
                    }

                    SQLCmd.ExecuteNonQuery();
                    trn.Commit();
                    if (IsAddnew)
                    {
                        fgPhieuChiDinh.Tag = "0";
                        fgPhieuChiDinh.AddItem(string.Format("|||||||||{0}|{1}", Global.GetCode(cmbKhoa), cmbKhoa.Text));
                        fgPhieuChiDinh.Row = fgPhieuChiDinh.Rows.Count - 1;
                        fgPhieuChiDinh.Tag = "1";
                    }

                    fgPhieuChiDinh[fgPhieuChiDinh.Row, 0] = fgPhieuChiDinh.Rows.Count - 1;
                    fgPhieuChiDinh[fgPhieuChiDinh.Row, 1] = SoPhieu;
                    fgPhieuChiDinh[fgPhieuChiDinh.Row, 2] = string.Format("{0:dd/MM/yyyy HH:mm}", txtNgayChiDinh.Value);
                    fgPhieuChiDinh[fgPhieuChiDinh.Row, 3] = "";
                    fgPhieuChiDinh[fgPhieuChiDinh.Row, 4] = cmbBacSyDT.Columns[1].CellText(cmbBacSyDT.SelectedIndex);
                    fgPhieuChiDinh[fgPhieuChiDinh.Row, 5] = txtDienBienBenh.Text;
                    fgPhieuChiDinh[fgPhieuChiDinh.Row, 6] = txtYLenh.Text;
                    fgPhieuChiDinh[fgPhieuChiDinh.Row, 7] = (cmbCheDoChamSoc.SelectedIndex == -1) ? ("") : (Global.GetCode(cmbCheDoChamSoc));
                    fgPhieuChiDinh[fgPhieuChiDinh.Row, 8] = (cmbCheDoDinhDuong.SelectedIndex == -1) ? ("") : (Global.GetCode(cmbCheDoDinhDuong));
                    fgPhieuChiDinh[fgPhieuChiDinh.Row, 11] = raChiPhiTT.Checked == true ? 1 : 0;
                    fgPhieuChiDinh[fgPhieuChiDinh.Row, 13] = chCapCuu.Checked == true ? 1 : 0;
                    fgPhieuChiDinh[fgPhieuChiDinh.Row, 14] = raChiPhiHN.Checked == true ? "Trong ngày" : "Bất thường";
                    fgPhieuChiDinh[fgPhieuChiDinh.Row, 15] = chCapCuu.Checked == true ? 1 : 0;
                    fgPhieuChiDinh[fgPhieuChiDinh.Row, 16] = cmbNhomMau.SelectedIndex;
                    fgPhieuChiDinh[fgPhieuChiDinh.Row, "ChanDoan"] = txtChanDoan.Text.Trim();
                    fgPhieuChiDinh[fgPhieuChiDinh.Row, "USerName1"] = Global.glbUName;
                    Lock_Edit(true);
                    SoTienConLai();
                    if (fgPhieuChiDinh.Rows.Count - 1 > 0)
                    {
                        Load_PhieuDieutri_ChiTiet(fgPhieuChiDinh.Rows.Count - 1);
                    }
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
            }
        }
        
        private void cmbNhom_TextChanged(object sender, EventArgs e)
        {
            if (cmbNhom.Tag.ToString() == "0") return;
            Load_DSBN();
        }

        private void cmdChiDinhTheoMatBenh_Click(object sender, EventArgs e)
        {
            if (lblSoPhieu.Text.Substring(0, 2) == "CD")
            {
                MessageBox.Show("Chỉ định không được thêm mới", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            NamDinh_QLBN.Forms.DuLieu.frmChiPhiTheoMatBenh frm = new frmChiPhiTheoMatBenh(fgDichVu, MaDoiTuongBN, Global.GetCode(cmbKhoa),NgayKham,"0");
            frm.ShowDialog();
        }

        private void Copy()
        {
            bool DaCoThuoc = false;

            for (int i = 1; i < fgDichVu.Rows.Count; i++)
            {

                if (!fgDichVu.Rows[i].IsNode && fgDichVu[i, "DaThucHien"].ToString().ToLower() == "true")
                {
                    MessageBox.Show("đã có chí phí thực hiện. Bạn không thể copy đè lên", "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            if (fgDichVu.Rows.Count > 1)
            {
                DaCoThuoc = true;
                if (MessageBox.Show("đã có thuốc trong Phiếu điều trị, nếu copy đơn thuốc sẽ xóa hết thuốc đã có trong phiếu.\nBạn có chắc muốn copy không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

            }

            fgDichVu.Redraw = false;
            if (DaCoThuoc)
                fgDichVu.Rows.Count = 1;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
            SQLCmd.CommandText = "SELECT a.TyLe, a.LoaiDichVu,c.TenLoaiDichVu,a.MaDichVu,d.TenDichVu,d.DVT,a.SoLuong,a.GhiChu,a.TinhPhi,";
            if (MaDoiTuongBN == "1") SQLCmd.CommandText += "isNull(d.DonGiaBHYT,0) As DonGia,isNull(a.SoLuong*d.DonGiaBHYT*a.TyLe/100,0) As ThanhTien,d.KhoID,isnull(a.TyLeBHYT,d.TyLeBHYT) as TyleBH,a.TTThau ";
            else SQLCmd.CommandText += "isNull(d.DonGia,0) As DonGia,isNull(a.SoLuong*d.DonGia*a.TyLe/100,0) As ThanhTien,d.KhoID,isnull(a.TyLeBHYT,d.TyLeBHYT) as TyleBH,a.TTThau ";
            SQLCmd.CommandText += string.Format(" FROM ((PHIEUDIEUTRI_CHITIET a INNER JOIN BENHNHAN_PHIEUDIEUTRI b ON a.SoPhieu=b.SoPhieu)"
                               + " INNER JOIN DMLOAIDICHVU c ON a.LoaiDichVu=c.MaLoaiDichVu)"
                               + " INNER JOIN DMLENCHIPHI_BYKHOID d ON a.MaDichVu=d.maDichVu AND a.LoaiDichVu=d.LoaiDichVu and d.khongsudung = 0 ");
            if (IsAddnew)
            {
                SQLCmd.CommandText += String.Format(" where a.sophieu = '{0}' AND a.LoaiDichVu in ('D01','D02','B01','B02','D06','E04')", lblSoPhieu.Text);
            }
            else
            {
                SQLCmd.CommandText += String.Format(" WHERE a.SoPhieu = (SELECT max(SoPhieu) FROM BENHNHAN_PHIEUDIEUTRI WHERE  MaVaoVien='{0}' and SoPhieu <> '{1}')"
                                + " AND a.LoaiDichVu in ('D01','D02','B01','B02','D06','E04') ", txtMaBN.Text, lblSoPhieu.Text);
            }

            SQLCmd.CommandText += " Group by a.LoaiDichVu,c.TenLoaiDichVu,a.MaDIchVu,d.TenDichVu,d.DVT,a.TinhPhi,"
                                + " a.SoLuong,a.GhiChu,d.DonGia,d.DonGiaBHYT,d.KhoID, a.TyLe,a.TyLeBHYT,d.TyLeBHYT,a.TTThau Order By a.LoaiDichVu,TenDichVu";
            System.Data.SqlClient.SqlDataReader dr = SQLCmd.ExecuteReader();
            while (dr.Read())
            {
                fgDichVu.AddItem(string.Format("|{0}|{1}|{2}|{3}|{4}|{5:#,##0.##}|{6:#,##0.##}|{7}|{8:#,##0.##}|{9}|{10}|{11}||{12}|{13}|||||||||||{15}|{14}|",
                    dr["LoaiDichVu"],
                    dr["tenLoaiDichVu"],
                    dr["MaDichVu"],
                    dr["tenDichVu"],
                    dr["DVT"],
                    dr["SoLuong"],
                    dr["DonGia"],
                    dr["TyLe"],
                    dr["ThanhTien"],
                    dr["GhiChu"],
                    dr["TinhPhi"], 0,
                     0,
                    dr["KhoID"], dr["TyleBH"], dr["TTThau"]));
            }
            Format_Grid();
            fgDichVu.Redraw = true;
            dr.Close();
            SQLCmd.Dispose();
        }

        private void cmdCopy_Click(object sender, EventArgs e)
        {
            if (lblSoPhieu.Text.Substring(0, 2) == "CD")
            {
                MessageBox.Show("Chỉ định không được thêm mới", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
            //Kiem tra xem da in chua
            SQLCmd.CommandText = String.Format("Select Is_In from Namdinh_qlbn.dbo.BenhNHan_PhieuDieutri where sophieu='{0}'", lblSoPhieu.Text.Trim());
            if (SQLCmd.ExecuteScalar().ToString() == "1")
            {
                MessageBox.Show("Phiếu này đã được in. Bạn không thể copy đè lên!.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Copy();
        }

        private void cmdHuy_Click(object sender, EventArgs e)
        {
            Lock_Edit(true);
            if (fgPhieuChiDinh.Row < 1) Empty_Data(); else Load_PhieuDieutri_ChiTiet(fgPhieuChiDinh.Row);
        }

        private void cmdInPhieu_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblSoPhieu.Text == "0")
                {
                    MessageBox.Show("Chọn phiếu điều trị", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                string[] arrListStr = lbSoTienCL.Text.Split(' ');
                if ((float.Parse(arrListStr[4]) <= 0.00) && (Global.GetCode(cmbDoiTuong) == "3"))
                    //Toan sua
                {
                    MessageBox.Show("Tổng chi phí của bệnh nhân đã vượt quá số tiền ký quỹ. Đề nghị bệnh nhân đóng thêm tiền ký quỹ!");
                   
                }
                NamDinh_QLBN.Reports.repPhieuChiDinh_ketquaA5 rep = new NamDinh_QLBN.Reports.repPhieuChiDinh_ketquaA5(txtHoTen.Text.Trim(),
                            int.Parse(txtTuoi.Text.Trim()), txtGioi.Text, txtChanDoan.Text.Trim(), cmbKhoa.Text,
                            int.Parse(fgPhieuChiDinh.GetDataDisplay(fgPhieuChiDinh.Row, "Nhom")), lblSoPhieu.Text.Trim(), txtNgayChiDinh.Value,cmbDieuduong.Text);
                rep.Show();
                //Bat truong hop da in khong duoc xoa
                System.Data.SqlClient.SqlCommand Cmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
                Cmd.CommandText = String.Format("Update benhnhan_phieudieutri set Is_In = 1 where sophieu ='{0}'", lblSoPhieu.Text);
                Cmd.ExecuteNonQuery();
                Cmd.Dispose();
                cmdToDieuTri_Click(sender, e);
            }
            catch
            {
            }
            finally
            {
            }
        }

        private void cmdDonThuoc_Click(object sender, EventArgs e)
        {
            //if (lblSoPhieu.Text.Trim() == "") return;
            //NamDinh_QLBN.Reports.repDonThuoc rpt = new NamDinh_QLBN.Reports.repDonThuoc(fgPhieuChiDinh.GetData(fgPhieuChiDinh.Row, "NgayChiDinh"), fgPhieuChiDinh.GetDataDisplay(fgPhieuChiDinh.Row, "BacSyDT"));
            //DataDynamics.ActiveReports.DataSources.SqlDBDataSource _ds = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            //_ds.ConnectionString = GlobalModuls.Global.glbConnectionString;
            //_ds.SQL = string.Format("Select aa.*,dmkhoaphong.tenkhoa,benhnhan.hoten,year(getdate()) - benhnhan.namsinh as tuoi,"
            //   + " case when benhnhan.gioitinh = 0 then N'Giới tinh: Nữ' else N'Giới tinh: Nam' end as GioiTinh,"
            //   + " N'Đối tượng: ' + dmdoituongbn.tendt + N'. Số thẻ: ' + viewdoituonghientai.SoThe as DoiTuong1,benhnhan_chitiet.diachi,viewdoituonghientai.GtriTu,viewdoituonghientai.GtriDen,"
            //   + " viewdoituonghientai.SoThe,phieudieutri_chitiet.madichvu,phieudieutri_chitiet.soluong,dmdichvu.tendichvu,dmdichvu.dvt,phieudieutri_chitiet.ghichu from "
            //   + " (Select MaVaoVien,NgayChiDinh,BacSyDT,makhoa,chandoan,sophieu from benhnhan_phieudieutri where sophieu ='{0}') aa"
            //   + " inner join benhnhan_chitiet on benhnhan_chitiet.mavaovien =  aa.mavaovien"
            //   + " inner join benhnhan on benhnhan.mabenhnhan = benhnhan_chitiet.mabenhnhan"
            //   + " inner join dmkhoaphong on dmkhoaphong.makhoa = aa.makhoa"
            //   + " left join viewdoituonghientai on viewdoituonghientai.mavaovien = aa.mavaovien"
            //   + " left join dmdoituongbn on dmdoituongbn.madt = viewdoituonghientai.doituong"
            //   + " inner join phieudieutri_chitiet on phieudieutri_chitiet.sophieu = aa.sophieu"
            //   + " inner join dmdichvu on dmdichvu.madichvu = phieudieutri_chitiet.madichvu"
            //   + " where phieudieutri_chitiet.loaidichvu ='d01'", lblSoPhieu.Text.Trim());
            //rpt.DataSource = _ds;
            //rpt.Show();
            if (txtMaBN.Text.Trim() == "") return;
            frmSoKet15 frm = new frmSoKet15(txtMaBN.Text);
            frm.ShowDialog();
        }

        private void cmdKhamChuyenKhoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaBN.Text.Trim() == "") return;
                NamDinh_QLBN.Forms.DuLieu.frmKhamChuyenKhoa frm = new frmKhamChuyenKhoa(Global.GetCode(cmbKhoa), txtMaBN.Text.Trim());
                if (frm.ShowDialog() == DialogResult.Yes)
                {
                    //NamDinh_QLBN.Reports.rptPhieuKhamChuyenKhoa rpt = new NamDinh_QLBN.Reports.rptPhieuKhamChuyenKhoa(txtMaBN.Text.Trim(), Global.GetCode(cmbKhoa));
                    //rpt.Run();
                    //rpt.Show();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
            }
        }

        private void cmdMau_Click(object sender, EventArgs e)
        {
            String Khoa = cmbKhoa.Text;
            String NgayIn = String.Format("In ngày {0:dd} tháng {0:MM} năm {0:yyyy}", Global.NgayLV);
            String NgaySD = String.Format("Ngày {0:dd} tháng {0:MM} năm {0:yyyy}", txtNgayChiDinh.Value);
            //NamDinh_QLBN.Reports.repPhieuLinhMau rep = new NamDinh_QLBN.Reports.repPhieuLinhMau(Khoa, NgayIn, NgaySD);
            NamDinh_QLBN.Reports.repGiayXinMau rep1 = new NamDinh_QLBN.Reports.repGiayXinMau(txtMaBN.Text, lblSoPhieu.Text, txtNgayChiDinh.Value,Khoa);
            //DataDynamics.ActiveReports.DataSources.SqlDBDataSource _ds = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            //_ds.ConnectionString = GlobalModuls.Global.glbConnectionString;
            //_ds.SQL = string.Format("DECLARE @SoPhieu nvarchar(50)"
            //    + " DECLARE @SoLan int"
            //    + " DECLARE Cur CURSOR"
            //    + " FOR"
            //    + " select benhnhan_phieudieutri.sophieu from benhnhan_phieudieutri "
            //    + " inner join phieudieutri_chitiet on benhnhan_phieudieutri.sophieu = phieudieutri_chitiet.sophieu "
            //    + " where mavaovien ='{0}' and datediff(dd,NgayChiDinh,'{1:MM/dd/yyyy}') >= 0 and phieudieutri_chitiet.loaidichvu='D03'"
            //    + " group by benhnhan_phieudieutri.sophieu "
            //    + " OPEN Cur"
            //    + " FETCH NEXT FROM Cur INTO @SoPhieu"
            //    + " WHILE @@FETCH_STATUS = 0"
            //    + " begin"
            //    + " if(@SoPhieu = '{2}')"
            //    + " begin"
            //    + " set @SoLan = isnull(@SoLan,1) "
            //    + " break"
            //    + " end"
            //    + " else "
            //    + " begin "
            //    + " Set @SoLan = isnull(@SoLan,1) + 1"
            //    + " end "
            //    + " FETCH NEXT FROM Cur INTO @SoPhieu"
            //    + " end"
            //    + " CLOSE Cur"
            //    + " DEALLOCATE  Cur"
            //    + " Select SoLuong,dmdichvu.tendichvu,phieudieutri_chitiet.madichvu,N'Số vào viện: ' + benhnhan_chitiet.SoHSBA as SoVaoVien,"
            //    + " @SoLan as LanTruyenMau,HoTen,Year(Getdate())-NamSinh as Tuoi, case when GioiTinh = 0 "
            //    + " then N'Giới tính: Nữ' else N'Giới tính: Nam' end as GioiTinh,TenGiuong,TenBuong, case when NhomMau = 1 then 'A' "
            //    + " when NhomMau = 2 then 'AB' when NhomMau = 3 then 'B' when NhomMau = 4 then 'O' else '' end as NhomMau, aa.ChanDoan,aa.BacSyDT from  "
            //    + " (Select * from benhnhan_phieudieutri where sophieu ='{2}') aa inner join phieudieutri_chitiet on phieudieutri_chitiet.sophieu = aa.sophieu "
            //    + " inner join dmdichvu on dmdichvu.madichvu = phieudieutri_chitiet.madichvu "
            //    + " inner join benhnhan_chitiet on benhnhan_chitiet.mavaovien = aa.mavaovien "
            //    + " inner join benhnhan on benhnhan.mabenhnhan = benhnhan_chitiet.mabenhnhan "
            //    + " left join dmgiuongbenh on dmgiuongbenh.id_buong = benhnhan_chitiet.buong and "
            //    + " dmgiuongbenh.id_giuong = benhnhan_chitiet.giuong  and dmgiuongbenh.makhoa = aa.makhoa "
            //    + " left join dmbuongbenh on dmbuongbenh.id_buong = benhnhan_chitiet.buong and dmbuongbenh.makhoa = aa.makhoa"
            //    + " where phieudieutri_chitiet.LoaiDichVu in ('D03')", txtMaBN.Text, txtNgayChiDinh.Value, lblSoPhieu.Text);
            //rep.DataSource = _ds;
            //rep.Show();
            rep1.Show();
        }

        private void cmdHoiChan_Click(object sender, EventArgs e)
        {
            if (txtMaBN.Text.Trim() == "")
            {
                MessageBox.Show("Chọn bệnh nhân.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            NamDinh_QLBN.Forms.DuLieu.frmHoiChan frm = new frmHoiChan(txtMaBN.Text);
            frm.Show();
        }

        private void cmdMo_Click(object sender, EventArgs e)
        {
            if (txtMaBN.Text.Trim() == "")
            {
                MessageBox.Show("Chọn bệnh nhân.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if ((fgDichVu.GetDataDisplay(fgDichVu.Row, "LoaiDichVu").CompareTo("C03") <= 0) || (fgDichVu.GetDataDisplay(fgDichVu.Row, "LoaiDichVu").CompareTo("C24") >= 0))
            {
                MessageBox.Show("Phải chọn dịch vụ nhóm phẫu thuật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            NamDinh_QLBN.Forms.DuLieu.frmThongTinMo_Kipmo frm = new frmThongTinMo_Kipmo(txtMaBN.Text.Trim(), lblSoPhieu.Text, fgDichVu.GetDataDisplay(fgDichVu.Row, "LoaiDichVu"), fgDichVu.GetDataDisplay(fgDichVu.Row, "MaDichVu"), Global.GetCode(cmbKhoa).ToString());
            if (frm.ShowDialog() == DialogResult.Yes)
            {
                NamDinh_QLBN.Reports.repGiayDuyetMo rep = new NamDinh_QLBN.Reports.repGiayDuyetMo(txtMaBN.Text.Trim(), txtNgayChiDinh.Value,lblSoPhieu.Text.Trim());
                rep.Show();
                NamDinh_QLBN.Reports.repDuyetPhauThuat repDPT = new NamDinh_QLBN.Reports.repDuyetPhauThuat(txtMaBN.Text.Trim(), txtNgayChiDinh.Value, lblSoPhieu.Text.Trim(), GlobalModuls.Global.glbKhoa_CapNhat, GlobalModuls.Global.glbTenKhoaPhong);
                repDPT.Show();
            }
        }

        private void frmLenChiPhiKhoaCC_KeyDown(object sender, KeyEventArgs e)
        {
            if (cmdChiDinh.Visible == false)
            {
                return;
            }
            else
            {
                if (e.KeyCode == Keys.F4)
                {
                    if (!cmdChiDinh.Visible) return;
                    //NamDinh_QLBN.Forms.DuLieu.frmNhapChiDinhChiPhi fr = new frmNhapChiDinhChiPhi(fgDichVu, MaDoiTuongBN, Global.GetCode(cmbKhoa), DateTime.Parse(txtNgayVaoVien.Text));
                    NamDinh_QLBN.Forms.DuLieu.frmNhapChiDinhChiPhi fr = new frmNhapChiDinhChiPhi(fgDichVu, MaDoiTuongBN, Global.GetCode(cmbKhoa), NgayKham);
                    fr.ShowDialog();
                }
                if (e.KeyCode == Keys.F3)
                {
                    if (!cmdCopy.Visible) return;
                    Copy();
                }
                if (e.KeyCode == Keys.F6)
                {
                    NamDinh_QLBN.Forms.DuLieu.frmChiPhiTheoMatBenh frm = new frmChiPhiTheoMatBenh(fgDichVu, MaDoiTuongBN, Global.GetCode(cmbKhoa),NgayKham,"0");
                    frm.ShowDialog();
                }
            }
        }
        private bool AllowEditDele()
        {

            bool flag = true;
            if ((this.fgDichVu.Cols[this.fgDichVu.Col].Index == this.fgDichVu.Cols["DonGia"].Index) || (this.fgDichVu.GetDataDisplay(this.fgDichVu.Row, "LoaiDichVu") == "D06"))
            {
                return true;
            }
            if (this.fgDichVu.GetDataDisplay(this.fgDichVu.Row, "DaThucHien").ToLower() == "true")
            {
                if (fgDichVu.GetDataDisplay(this.fgDichVu.Row, "LoaiDichVu") == "D01" && (this.fgDichVu[this.fgDichVu.Row, "DaDuyet"].ToString() == "0"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            if (this.fgDichVu.GetDataDisplay(this.fgDichVu.Row, "LuotIn").ToLower() == "1")
            {
                flag = false;
            }
            return flag;
        }

        private void TruLaiSoVo()
        {
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
            System.Data.SqlClient.SqlTransaction trn = Global.ConnectSQL.BeginTransaction();
            SQLCmd.Transaction = trn;
            try
            {
                //Them so luong nhung thuoc phai tra vo
                if (fgDichVu.Rows.Count > 1)
                {
                    SQLCmd.CommandText = SQLCmd.CommandText + string.Format(" if(exists(select * from dstravo where makhoa='{0}' and mathuoc = '{1}'))  begin if(exists(select * from benhnhan_travo inner join dstravo on dstravo.makhoa =  benhnhan_travo.makhoa and dstravo.makhoa ='{0}' where benhnhan_travo.makhoa='{0}' and benhnhan_travo.mathuoc='{1}')) begin update benhnhan_travo set soluongdsd = ", Global.GetCode(this.cmbKhoa), this.fgDichVu[this.fgDichVu.Row, "MaDichVu"]);
                    SQLCmd.CommandText = SQLCmd.CommandText + string.Format(" (select SoLuongDSD - {2} from benhnhan_travo where makhoa='{0}' and mathuoc ='{1}') where makhoa='{0}' and mathuoc ='{1}'", Global.GetCode(this.cmbKhoa), this.fgDichVu[this.fgDichVu.Row, "MaDichVu"], this.fgDichVu[this.fgDichVu.Row, "SoLuongCu"].ToString().Replace(",", "."));
                    SQLCmd.CommandText = SQLCmd.CommandText + string.Format(" end end", new object[0]);
                    SQLCmd.ExecuteNonQuery();
                    trn.Commit();
                }
            }
            catch (Exception ex)
            {
                trn.Rollback();
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                SQLCmd.Dispose();
            }
        }

        private void mnuSua_Click(object sender, EventArgs e)
        {
            if (fgDichVu.Rows.Count <= 1) return;
            if (!AllowEditDele())
            {
                MessageBox.Show("đã thực hiện. Không thể thay đổi.", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            fgDichVu.StartEditing(fgDichVu.Row, fgDichVu.Cols["SoLuong"].Index);
        }

        private void mnuThem_Click(object sender, EventArgs e)
        {
            cmdChiDinh_Click(sender, e);
        }

        private void mnuXoa_Click(object sender, EventArgs e)
        {
            if (fgDichVu.Rows.Count <= 1) return;
            if (!AllowEditDele())
            {
                MessageBox.Show("đã thực hiện. Không thể thay đổi.", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không.", "Thông báo.", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                TruLaiSoVo();
                fgDichVu.RemoveItem(fgDichVu.Row);
                Format_Grid();
            }
        }

        //private void cmdToDieuTri_Click(object sender, EventArgs e)
        //{
        //    if (MaDoiTuongBN != "1")
        //    {
        //        MessageBox.Show("Bệnh nhân không phải đối tượng bảo hiểm y tế!!", "Thông báo",MessageBoxButtons.OK);
        //        return;
        //    }
        //    if (fgDichVu.Rows.Count <2)
        //    {
        //        MessageBox.Show("Chưa có dịch vụ để in tích kê!!", "Thông báo", MessageBoxButtons.OK);
        //        return;
        //    }
        //    string XetNghiem = "";
        //    string SoTheBHYT ="";
        //    decimal TongTien = 0;
        //    System.Data.SqlClient.SqlDataReader dr;
        //    System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
        //    SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
        //    try
        //    {
        //        SQLCmd.CommandText = "SELECT TenDichVu,vd.maDoiTuongBHXH +' - '+ SoThe + ' - ' + vd.MaNoiCap AS SoThe,isnull(pc.SoLuong,0)* isnull(pc.DonGia,0) as ThanhTien FROM "
        //                            + " ((((PHIEUDIEUTRI_CHITIET pc INNER JOIN DMDICHVU d ON d.MaDichVu = pc.MaDichVu )"
        //                            + " INNER JOIN NAMDINH_CLS.dbo.DMDICHVU_CHISO dc ON dc.MaDichVu = d.MaDichVu)"
        //                            + " INNER JOIN NAMDINH_CLS.dbo.DMCHISO d1 ON d1.MaChiSo=dc.MaChiSo)"
        //                            + " INNER JOIN BENHNHAN_PHIEUDIEUTRI bp ON bp.SoPhieu = pc.SoPhieu)"
        //                            + " INNER JOIN ViewDOITUONGHIENTAI vd ON vd.MaVaoVien = bp.MaVaoVien"
        //                            + " WHERE pc.SoPhieu ='" + fgPhieuChiDinh.GetDataDisplay(fgPhieuChiDinh.Row, "SoPhieu") + "' AND (d1.MaMay = 2 OR d1.MaMay = 4 OR (d1.MaMay = 3  and d.tendichvu like N'%CT Scanner (Liên kết%'))";
        //        dr = SQLCmd.ExecuteReader();
        //        while (dr.Read())
        //        {
        //            XetNghiem += dr["TenDichVu"].ToString() + ", ";
        //            SoTheBHYT = dr["SoThe"].ToString();
        //            try
        //            {
        //                TongTien += decimal.Parse(dr["ThanhTien"].ToString());
        //            }
        //            catch (Exception ex)
        //            {
        //                MessageBox.Show(ex.Message);
        //            }
        //        }
        //        dr.Close();
        //        XetNghiem = XetNghiem.Substring(0, XetNghiem.Length - 2);
        //        NamDinh_QLBN.Reports.rptTichKeXN rpt = new NamDinh_QLBN.Reports.rptTichKeXN();
        //        rpt.Barcode1.Text = fgPhieuChiDinh.GetDataDisplay(fgPhieuChiDinh.Row, "SoPhieu");
        //        rpt.lblTenBN.Text = txtHoTen.Text.ToUpper();
        //        rpt.lblTenKhoa.Text = Global.glbTenKhoaPhong;
        //        rpt.lblSoThe.Text = SoTheBHYT;
        //        rpt.lblXetNghiem.Text = XetNghiem;
        //        rpt.lblBacSiCD.Text = fgPhieuChiDinh.GetDataDisplay(fgPhieuChiDinh.Row, "BacSyDT");
        //        rpt.txtTongTien.Value = TongTien;
        //        rpt.lblNgayThang.Text = string.Format("{0:HH} giờ {0:mm} - Ngày {0:dd} tháng {0:MM} năm {0:yyyy}", txtNgayChiDinh.Value);
        //        rpt.Show();
        //    }
        //    catch
        //    {
        //    }
        //    finally
        //    {
        //        SQLCmd.Dispose();
        //    }
        //}


        private void cmdToDieuTri_Click(object sender, EventArgs e)
        {
            //NamDinh_QLBN.Reports.repToDieuTri rep = new NamDinh_QLBN.Reports.repToDieuTri(txtMaVaoVien.Text.Trim(),Global.GetCode(cmbKhoa));
            //rep.Show();
            //MessageBox.Show(fgDichVu.GetDataDisplay(1, 4));

            bool MienDich = false;
            string DichVuMienDich = "C50075,C50026,C50027,C50028,C50029,C50030,C50031,C50032,C50033,C50078,C50080,C50133,C50134,C50135,C50137,C58000,C58001,C50136";
            bool SinhHoaMau = false;
            string DichVuSinhHoaMau = "C50001,C50002,C50004,C50008,C50009,C50003,C50130,C50012,C50013,C50014,C50015,C50010,C50011,C50113,C50073,C50006,C50072,C50018,C50020,C50021,C50022,C50023,C50025,C50095,C50096,C50115,C50005,C50119,C50313,C50138,C50314";

            for (int Dong = 1; Dong < fgDichVu.Rows.Count - 1; Dong++)
            {
                if (this.fgDichVu.Rows[Dong].IsNode)
                {
                    //Kiểm tra xét nghiệm có nằm trong nhóm Miễn dịch không?
                    if (DichVuMienDich.IndexOf(this.fgDichVu.GetDataDisplay(2, "MaDichVu")) > -1)
                    {
                        MienDich = true;
                    }
                    //Kiểm tra xét nghiệm có nằm trong nhóm Sinh hóa máu không?
                    if (DichVuSinhHoaMau.IndexOf(this.fgDichVu.GetDataDisplay(2, "MaDichVu")) > -1)
                    {
                        SinhHoaMau = true;
                    }
                    if ((MaDoiTuongBN != "1") && (fgDichVu.GetDataDisplay(1, 4) != "Chụp CT") && (fgDichVu.GetDataDisplay(1, 4) != "Ct Scanner 64 dãy") && (!MienDich) && (!SinhHoaMau))
                    {
                        MessageBox.Show("Bệnh nhân không phải đối tượng bảo hiểm y tế!!", "Thông báo", MessageBoxButtons.OK);
                        return;
                    }
                    if (fgDichVu.Rows.Count < 2)
                    {
                        MessageBox.Show("Chưa có dịch vụ để in tích kê!!", "Thông báo", MessageBoxButtons.OK);
                        return;
                    }
                    string XetNghiem = "";
                    string SoTheBHYT = "";
                    decimal TongTien = 0;
                    decimal SoKhoan = 0;
                    System.Data.SqlClient.SqlDataReader dr;
                    System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
                    SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
                    SQLCmd.CommandText = "SELECT TenDichVu,vd.maDoiTuongBHXH +' - '+ SoThe + ' - ' + vd.MaNoiCap AS SoThe,isnull(pc.SoLuong,0)* isnull(pc.DonGia,0) as ThanhTien FROM "
                                        + " ((((PHIEUDIEUTRI_CHITIET pc INNER JOIN DMDICHVU d ON d.MaDichVu = pc.MaDichVu )"
                                        + " INNER JOIN NAMDINH_CLS.dbo.DMDICHVU_CHISO dc ON dc.MaDichVu = d.MaDichVu)"
                                        + " INNER JOIN NAMDINH_CLS.dbo.DMCHISO d1 ON d1.MaChiSo=dc.MaChiSo)"
                                        + " INNER JOIN BENHNHAN_PHIEUDIEUTRI bp ON bp.SoPhieu = pc.SoPhieu)"
                                        + " INNER JOIN ViewDOITUONGHIENTAI vd ON vd.MaVaoVien = bp.MaVaoVien"
                                        + " WHERE pc.SoPhieu ='" + fgPhieuChiDinh.GetDataDisplay(fgPhieuChiDinh.Row, "SoPhieu") + "' And pc.Loaidichvu = '" + fgDichVu.GetDataDisplay(Dong + 1, "LoaiDichVu") + "' "
                                        + " AND (d1.MaMay = 2 OR d1.MaMay = 4 OR (d1.MaMay = 3  and d.tendichvu like N'%CT Scanner (Liên kết%') OR (d1.MaMay = 3  and d.tendichvu like N'%64 dãy%') OR (d1.Machiso = 'C55080')  OR (d1.Machiso = 'C55081') OR (d1.Machiso = '001') OR (d1.Machiso = '001002')) ";
                    dr = SQLCmd.ExecuteReader();
                    while (dr.Read())
                    {
                        XetNghiem += dr["TenDichVu"].ToString() + ", ";
                        SoTheBHYT = dr["SoThe"].ToString();
                        SoKhoan += 1;
                        try
                        {
                            TongTien += decimal.Parse(dr["ThanhTien"].ToString());
                        }
                        catch { }
                    }
                    dr.Close();
                    dr.Dispose();
                    SQLCmd.Dispose();
                    // SON THEM
                    if (XetNghiem.Length >= 2)
                    {
                        XetNghiem = XetNghiem.Substring(0, XetNghiem.Length - 2);
                        NamDinh_QLBN.Reports.rptTichKeXN rpt = new NamDinh_QLBN.Reports.rptTichKeXN();
                        rpt.Barcode1.Text = fgPhieuChiDinh.GetDataDisplay(fgPhieuChiDinh.Row, "SoPhieu");
                        rpt.lblTenBN.Text = txtHoTen.Text.ToUpper();
                        rpt.lblTenKhoa.Text = Global.glbTenKhoaPhong;
                        rpt.lblDoiTuong.Text = txtDoiTuong.Text;
                        rpt.lbTon.Text = "Dùng cho ĐT " + txtDoiTuong.Text;
                        rpt.lblSoThe.Text = SoTheBHYT;
                        rpt.lblXetNghiem.Text = XetNghiem;
                        rpt.txtCongKhoan.Value = SoKhoan;
                        rpt.txtTongTien.Value = TongTien;
                        rpt.lblBacSiCD.Text = fgPhieuChiDinh.GetDataDisplay(fgPhieuChiDinh.Row, "BacSyDT");
                        rpt.lblNgayThang.Text = string.Format("{0:HH} giờ {0:mm} - Ngày {0:dd} tháng {0:MM} năm {0:yyyy}", txtNgayChiDinh.Value);
                        rpt.Show();
                    }
                }
            }

        }

        private void cmbPhongKham_TextChanged(object sender, EventArgs e)
        {
            if (cmbPhongKham.Tag.ToString() == "0") return;
            if (cmbLoaiDS.Tag.ToString() == "0") return;
            if (cmbLoaiDS.SelectedIndex == 0) groNhom.Visible = true;
            else groNhom.Visible = false;
            if (cmbLoaiDS.SelectedIndex == 1) grNgayKham.Visible = true;
            else grNgayKham.Visible = false;
            if (cmbLoaiDS.SelectedIndex == 2 || cmbLoaiDS.SelectedIndex == 3) grpNgay.Visible = true;
            else grpNgay.Visible = false;
            Load_DSBN();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void cmbNhom_TextChanged_1(object sender, EventArgs e)
        {
            if (cmbNhom.Tag.ToString() == "0") return;
            Load_DSBN();
        }

        private void cmdKetQuaXN_Click(object sender, EventArgs e)
        {
            if (fgPhieuChiDinh.Rows.Count <= 0) return;
            if (fgPhieuChiDinh.Row < 0) return;
            if (lblSoPhieu.Text.Trim() == "")
            {
                MessageBox.Show("Chọn phiếu cần xem", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            NamDinh_QLBN.Forms.DuLieu.KetQuaCLS.FrmKetQuaXetNghiem frm = new NamDinh_QLBN.Forms.DuLieu.KetQuaCLS.FrmKetQuaXetNghiem(lblSoPhieu.Text.Trim());
            frm.ShowDialog();
        }

        private void cmdThuThuat_Click(object sender, EventArgs e)
        {
            if (txtMaBN.Text.Trim() == "")
            {
                MessageBox.Show("Chọn bệnh nhân.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (lblSoPhieu.Text.Trim() == "")
            {
                MessageBox.Show("Chưa chọn phiếu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //Kiểm tra xem nếu có nơi thực hiện mà khác nơi chỉ định thì ko cho nhập thủ thuật
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            SQLCmd.CommandText = "select Makhoa from DMDICHVU_Khoa where madichvu = @MaDV";
            SQLCmd.Parameters.Clear();
            SQLCmd.Parameters.AddWithValue("@MaDV", fgDichVu.GetDataDisplay(fgDichVu.Row, "MaDichVu"));
            dr = SQLCmd.ExecuteReader();
            while (dr.Read())
            {
                if (GlobalModuls.Global.glbMaKhoaPhong != dr["Makhoa"].ToString())
                {
                    MessageBox.Show("Không cho phép nhập thủ thuật khi Khoa thực hiện khác Khoa chỉ định.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dr.Close();
                    dr.Dispose();
                    SQLCmd.Dispose();
                    return;
                }
            }
            dr.Close();
            dr.Dispose();
            SQLCmd.Dispose();
            //NamDinh_QLBN.Forms.DuLieu.frmThongTinTT frm = new frmThongTinTT(txtMaBN.Text.Trim());
            //if (frm.ShowDialog() == DialogResult.Yes)
            //{
            //    NamDinh_QLBN.Reports.repDuyetThuThuat rep = new NamDinh_QLBN.Reports.repDuyetThuThuat(txtMaBN.Text.Trim(), txtNgayChiDinh.Value);
            //    rep.Show();
            //}
            NamDinh_QLBN.Forms.DuLieu.frmThongTinTT_KipTT frm = new frmThongTinTT_KipTT(txtMaBN.Text.Trim(), lblSoPhieu.Text, fgDichVu.GetDataDisplay(fgDichVu.Row, "LoaiDichVu"), fgDichVu.GetDataDisplay(fgDichVu.Row, "MaDichVu"),txtNgayChiDinh.Text);
            //NamDinh_QLBN.Forms.DuLieu.frmThongTinTT frm = new frmThongTinTT(txtMaVaoVien.Text.Trim() );
            if (frm.ShowDialog() == DialogResult.Yes)
            {
                NamDinh_QLBN.Reports.repDuyetThuThuat rep = new NamDinh_QLBN.Reports.repDuyetThuThuat(txtMaBN.Text.Trim(), lblSoPhieu.Text, fgDichVu.GetDataDisplay(fgDichVu.Row, "MaDichVu"), txtNgayChiDinh.Value);
                rep.Show();
            }
        }

        private void txtNgayKham_ValueChanged(object sender, EventArgs e)
        {
            if (txtNgayKham.Tag.ToString() == "0") return;
            Load_DSBN();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.DuLieu.frmThongTinKQ frm = new frmThongTinKQ();
            frm._MaVaoVien = txtMaBN.Text;
            frm.ShowDialog();
        }

        private void fgDichVu_BeforeDeleteRow(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            if (fgDichVu.Rows.Count <= 1)
            {
                e.Cancel = true;
                return;
            }
            if (!AllowEditDele())
            {
                e.Cancel = true;
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không.", "Thông báo.", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }
            else
            {
                TruLaiSoVo();
            }
        }

        private void fgDichVu_BeforeEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            if (fgDichVu.Rows[e.Row].IsNode) e.Cancel = true;
            if (!AllowEditDele())
            {
                e.Cancel = true;
            }
            // SON THEM
            if ((fgDichVu.GetDataDisplay(fgDichVu.Row, "DonGia") != "0" || fgDichVu.GetDataDisplay(fgDichVu.Row, "DonGia") != "") && fgDichVu.Cols[fgDichVu.Col].Name.Trim().ToLower() == "dongia")
            {
                e.Cancel = true;
            }
        }

        private void cmdChiDinh_Click(object sender, EventArgs e)
        {
            if(lblSoPhieu.Text != "")
            {
                if (lblSoPhieu.Text.Substring(0, 2) == "CD")
                {
                    MessageBox.Show("Chỉ định không được thêm mới", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            NamDinh_QLBN.Forms.DuLieu.frmNhapChiDinhChiPhi fr = new frmNhapChiDinhChiPhi(fgDichVu, MaDoiTuongBN, Global.GetCode(cmbKhoa), NgayKham);
            fr.ShowDialog();
        }

        private void fgDichVu_AfterEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            //Huy thêm ngày 8/5/2015 bên Chỉ định, thêm ở đây ngày 10/4/2017: Không cho đánh dấu Không tính phí các dịch vụ không phải là: 
            SqlCommand command = new SqlCommand("", Global.ConnectSQL);
            command.CommandText = string.Format("SELECT distinct  MADICHVU,TyleBHYT FROM DM_INPHIEUTHANHTOAN WHERE MADICHVU = '{0}'", fgDichVu.GetDataDisplay(fgDichVu.Row, "MaDichVu").ToString());
            SqlDataReader reader = command.ExecuteReader();
            string TyleBHYT = "";
            while (reader.Read())
            {
                TyleBHYT = reader["TyleBHYT"].ToString();
            }
            reader.Close();
            command.Dispose();
            if (!((fgDichVu.GetDataDisplay(fgDichVu.Row, "TyleBH").ToString() == "0") || (fgDichVu.GetDataDisplay(fgDichVu.Row, "TyleBH").ToString() == "100") || (fgDichVu.GetDataDisplay(fgDichVu.Row, "TyleBH").ToString() == TyleBHYT)))
            {
                MessageBox.Show("Tỷ lệ BHYT Sai", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmdGhi.Enabled = false;
                return;
            }
            if (!((this.fgDichVu.GetDataDisplay(this.fgDichVu.Row, "LoaiDichVu") == "D01") || (this.fgDichVu.GetDataDisplay(this.fgDichVu.Row, "LoaiDichVu") == "D02") || (this.fgDichVu.GetDataDisplay(this.fgDichVu.Row, "LoaiDichVu") == "D04") || (this.fgDichVu.GetDataDisplay(this.fgDichVu.Row, "LoaiDichVu") == "D06") || (this.fgDichVu.GetDataDisplay(this.fgDichVu.Row, "LoaiDichVu") == "C01") || (this.fgDichVu.GetDataDisplay(this.fgDichVu.Row, "LoaiDichVu") == "C03")) && fgDichVu.Cols[fgDichVu.Col].Name.Trim().ToLower() == "khongtinhphi")
            {
                fgDichVu[fgDichVu.Row, "KhongTinhPhi"] = false;
                MessageBox.Show("Dịch vụ này có tính phí, nếu không dùng thì bạn phải xóa đi.");
                return;

            }
            if (e.Col != fgDichVu.Cols["SoLuong"].Index && e.Col != fgDichVu.Cols["TyLe"].Index) return;
            decimal SL = decimal.Parse(fgDichVu.GetData(e.Row, "SoLuong").ToString());
            decimal DonGia = decimal.Parse(fgDichVu.GetData(e.Row, "DonGia").ToString());
            decimal TyLe = decimal.Parse(fgDichVu.GetData(e.Row, "TyLe").ToString());
            if (TyLe == 0) TyLe = 100;
            fgDichVu[e.Row, "ThanhTien"] = SL * DonGia* TyLe/100;
            fgDichVu.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.Clear, 0, 0, 0);
            fgDichVu.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.Sum, 0, 2, fgDichVu.Cols["ThanhTien"].Index, "{0}");
        }

        private void mnuSua_TLBH_Click(object sender, EventArgs e)
        {
            if (fgDichVu.Rows.Count <= 1) return;
            fgDichVu.StartEditing(fgDichVu.Row, fgDichVu.Cols["TyleBH"].Index);
        }

        private void fgDichVu_RowColChange(object sender, EventArgs e)
        {

        }

        private void fg_Click(object sender, EventArgs e)
        {

        }

        private void fgDichVu_Click(object sender, EventArgs e)
        {
            if (fgDichVu.Rows.Count > 1)
            {
                System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
                SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
                SQLCmd.CommandText = string.Format("select * from NAMDINH_QLBN.dbo.PHIEUDIEUTRI_CHITIET  xx inner join NAMDINH_QLBN.dbo.DMPHAUTHUAT yy on xx.MaDichVu = yy.MaDichVu where SoPhieu = '{0}' and xx.MaDichVu = '{1}'", lblSoPhieu.Text, fgDichVu[fgDichVu.Row, "MaDichVu"]);
                System.Data.SqlClient.SqlDataReader dr = SQLCmd.ExecuteReader();
                if (dr.HasRows)
                {
                    cmdThuThuat.Enabled = true;
                }
                else
                {
                    cmdThuThuat.Enabled = false;
                }
                dr.Close();
            }
        }
    }
}