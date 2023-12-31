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

namespace NamDinh_QLBN.Forms.DuLieu.PhongMo
{
    public partial class frmBenhNhan_PhauThuat : Form
    {
        private string DaThanhToan;
        public frmBenhNhan_PhauThuat()
        {
            InitializeComponent();
        }

        private void frmBenhNhan_PhauThuat_Load(object sender, EventArgs e)
        {
            for (int i =0;i<tabControl1.TabCount;i++) tabControl1.TabPages[i].Tag = "";
            txtLocNgayPhauThuat.Enabled = txtLocNgayChiDinhPT.Enabled = false;
            fgKipMo.ClipSeparators = "|;";
            fgDichVu.ClipSeparators = "|;";
            fgDichVu.Tree.Column = 4;
            Load_CacDM();
            Load_DMPhauThuat();
            Lock_Edit(true);
        }
        private void Load_DMPhauThuat()
        {
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.Connection = GlobalModuls.Global.ConnectSQL;
            cmbSoSanh.AddItem("1;Đúng");
            cmbSoSanh.AddItem("2;Sai một phần");
            cmbSoSanh.AddItem("3;Sai hoàn toàn");
            cmd.CommandText = "SELECT * FROM DMLOAIPT";
            dr = cmd.ExecuteReader();
            cmbLoaiPT.ClearItems();
            while (dr.Read())
            {
                cmbLoaiPT.AddItem(string.Format("{0};{1}", dr["MaLoaiPT"], dr["TenLoaiPT"]));
            }
            dr.Close();
            cmd.CommandText = "SELECT * FROM DMPHUONGPHAPPT";
            dr = cmd.ExecuteReader();
            cmbPhuongPhapPT_Ma.ClearItems();
            while (dr.Read())
            {
                cmbPhuongPhapPT_Ma.AddItem(string.Format("{0};{1}", dr["MaPPPT"], dr["TenPPPT"]));
            }
            dr.Close();
            cmd.CommandText = "SELECT * FROM DMVOCAM";
            dr = cmd.ExecuteReader();
            cmbVoCam.ClearItems();
            while (dr.Read())
            {
                cmbVoCam.AddItem(string.Format("{0};{1}", dr["MaVoCam"], dr["TenVoCam"]));
            }
            dr.Close();
            cmd.CommandText = "SELECT * FROM DMTAIBIEN WHERE Loai=1";
            dr = cmd.ExecuteReader();
            cmbTaiBien.ClearItems();
            while (dr.Read())
            {
                cmbTaiBien.AddItem(string.Format("{0};{1}", dr["MaTaiBien"], dr["TenTaiBien"]));
            }
            dr.Close();
            cmd.CommandText = "SELECT * FROM DMTAIBIEN WHERE Loai=2";
            dr = cmd.ExecuteReader();
            cmbBienChung.ClearItems();
            while (dr.Read())
            {
                cmbBienChung.AddItem(string.Format("{0};{1}", dr["MaTaiBien"], dr["TenTaiBien"]));
            }
            dr.Close();
            //cmd.CommandText = "SELECT * FROM DMVITRI_PT";
            //dr = cmd.ExecuteReader();
            //string tmps = "";
            //while (dr.Read())
            //{
            //    tmps += dr["TenVT"].ToString() + "|";
            //}
            //fgKipMo.Cols[2].ComboList = tmps;
            //dr.Close();
            cmd.Dispose();
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
            dr.Close();
            cmbKhoa.SelectedIndex = 0;
            cmbKhoa.Tag = "1";
            if (cmbKhoa.ListCount > 0) cmbKhoa.SelectedIndex = 0;
            SQLCmd.CommandText = "SELECT * FROM DMKHOAPHONG";
            dr = SQLCmd.ExecuteReader();
            System.Collections.Hashtable KhoaMap = new System.Collections.Hashtable();
            while (dr.Read())
            {
                KhoaMap.Add(dr["maKhoa"], dr["TenKhoa"]);
            }
            dr.Close();
            fgKipMo.Cols["Khoa"].DataMap = KhoaMap;
            SQLCmd.CommandText = "SELECT MaBS+MaKhoa As MaBS,Tentat as TenBS FROM DMBACSY";
            dr = SQLCmd.ExecuteReader();
            System.Collections.Hashtable BacSyMap = new System.Collections.Hashtable();
            while (dr.Read())
            {
                BacSyMap.Add(dr["MaBS"], dr["tenBS"]);
            }
            dr.Close();
            fgKipMo.Cols["TenBacSy"].DataMap = BacSyMap;

            cmbBSGayMeKy.Tag = "0";
            cmbBSGayMeKy.ClearItems();
            SQLCmd.CommandText = "SELECT * FROM DMBACSY WHERE Khongsudung = 0  and (SoChungChiHanhNghe != ''and SoChungChiHanhNghe != '1' and SoChungChiHanhNghe != 'NULL') and MaChucVu in (1,2,3,4,5)  and  MaKhoa IN " + Global.glbKhoa_CapNhat + "order by Thutu";
            dr = SQLCmd.ExecuteReader();
            while (dr.Read())
            {
                cmbBSGayMeKy.AddItem(string.Format("{0};{1}", dr["MaBS"], dr["TenBS"]));
            }
            dr.Close();
            cmbBSGayMeKy.SelectedIndex = 0;
            cmbBSGayMeKy.Tag = "1";

            cmbDieuDuongKy.Tag = "0";
            cmbDieuDuongKy.ClearItems();
            SQLCmd.CommandText = "SELECT * FROM DMBACSY WHERE Khongsudung = 0  and (SoChungChiHanhNghe != ''and SoChungChiHanhNghe != '1' and SoChungChiHanhNghe != 'NULL') and MaChucVu in (6,7)  and  MaKhoa IN " + Global.glbKhoa_CapNhat + "order by Thutu";
            dr = SQLCmd.ExecuteReader();
            while (dr.Read())
            {
                cmbDieuDuongKy.AddItem(string.Format("{0};{1}", dr["MaBS"], dr["TenBS"]));
            }
            dr.Close();
            cmbDieuDuongKy.SelectedIndex = 0;
            cmbDieuDuongKy.Tag = "1";

            cmbNhom.Tag = "0";
            cmbNhom.ClearItems();
            SQLCmd.CommandText = "SELECT * FROM Khoa_Nhom WHERE  MaKhoa  =  " + Global.glbKhoa_CapNhat ;
            dr = SQLCmd.ExecuteReader();
            while (dr.Read())
            {
                cmbNhom.AddItem(string.Format("{0};{1}", dr["MaNhom"], dr["TenNhom"]));
            }
            dr.Close();
            cmbNhom.SelectedIndex = -1;
            cmbNhom.Tag = "1";

            SQLCmd.Dispose();
        }
        private void Lock_Edit(bool isLocked)
        {
        }
        private void Load_DSBenhNhan(string MaKhoa, object NgayChiDinh, object NgayPT,string SoPhieu)
        {
            string SQLStr = string.Format("SELECT DISTINCT b.MaVaoVien,b.MaBenhNhan,HoTen,Year(E.NgayChiDinh) - NamSinh As Tuoi, Case GioiTinh WHEN 1 THEN N'Nam' ELSE N'Nữ' END As GT," 
                        + " NgayVaoVien,TenDT,G.DoiTuongBN as MaDT,e.MaKhoa,TenKhoa,ChanDoan_KhoaDT, c.MaDoituongBHXH+c.Sothe+c.MaNoiCap as SoThe,c.GtriTu, c.GTriDen, "
                        + " c.Tuyen, b.DiaChi, DMNOICAP.TenNoiCap as NoiCap, case isnull(b.ICD_KhoaDT,'') when '' then isnull(b.ICD_KKB,'') else isnull(b.ICD_KhoaDT,'') end as MaBenh, "
                        + " case G.DoiTuongBN when '1' then case when c.tuyen = 0 or c.Tuyen = 2 then QL.PhantramDuocHuong else 0.6 * QL.PhantramDuocHuong end else 0 end as PhantramDuocHuong,g.LanChuyenDT,b.DaTinhPhi"
                        + " FROM (((((((((BENHNHAN a INNER JOIN BENHNHAN_CHITIET b ON a.MaBenhNhan=b.mabenhNhan) "
                        + " INNER JOIN Benhnhan_doituong c ON b.MaVaoVien=c.MaVaoVien) "
                        + " INNER JOIN DMDOITUONGBN d ON c.DoiTuong=d.MaDT) "
                        + " LEFT JOIN NAMDINH_SYSDB.dbo.DMQUYENLOI QL ON  Ltrim(QL.MaQuyenLoi)=left(LTRIM(c.sothe),1)) "
                        + " INNER JOIN BENHNHAN_PHIEUDIEUTRI e ON b.MaVaoVien=e.MaVaoVien) "
                        + " INNER JOIN DMKHOAPHONG f ON e.MaKhoa=f.MaKhoa) "
                        + " INNER JOIN PHIEUDIEUTRI_CHITIET g ON e.SoPhieu=g.SoPhieu and g.LanChuyenDT = c.LanChuyenDT) "
                        + " INNER JOIN DMPHAUTHUAT i ON g.LoaiDichVu=i.LoaiDichVu AND g.MaDichVu=i.MaDichVu)"
                        + " LEFT JOIN NAMDINH_SYSDB.dbo.DMNOIDKKCBBD_BHYT DMNOICAP ON DMNOICAP.MaNoiCap = c.ManoiCap)"
                        + " INNER JOIN DMDICHVU_KHOA  ON DMDICHVU_KHOA.MADICHVU = I.MADICHVU ");
            if (NgayPT != null)
                SQLStr += String.Format(" INNER JOIN BENHNHAN_PHAUTHUAT H ON H.MAVAOVIEN = B.MAVAOVIEN");
            SQLStr += String.Format(" WHERE  DMDICHVU_KHOA.MAKHOA = '{0}'",MaKhoa);
            if (SoPhieu != "")
                SQLStr += string.Format("  AND g.SoPhieu='{0}' ", SoPhieu); //Global.glbMaKhoaPhong,
            if (NgayChiDinh != null)
                SQLStr += string.Format(" AND NgayChiDinh >= '{0:yyyyMMdd}' and NgayChiDinh < '{1:yyyyMMdd}'", NgayChiDinh, ((DateTime)NgayChiDinh).AddDays((1)));
            if (NgayPT != null)
                SQLStr += string.Format(" And H.ThoiGianBD >= '{0:yyyyMMdd}' And H.ThoiGianBD < '{1:yyyyMMdd}'", NgayPT, ((DateTime)NgayPT).AddDays((1)));
            
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand(SQLStr, Global.ConnectSQL);
            System.Data.SqlClient.SqlDataReader dr=SQLCmd.ExecuteReader();
            SQLCmd.CommandTimeout = 0;
            fg.Tag = "0";
            fg.Redraw = false;
            fg.Rows.Count = 1;
            while (dr.Read())
            {
                fg.Rows.Add();
                for (int i = 0; i < dr.FieldCount; i++)
                    fg[fg.Rows.Count - 1, i + 1] = dr.GetValue(i);
            }
            dr.Close();
            SQLCmd.Dispose();
            fg.Tag="1";
            fg.Redraw = true;
            for (int i = 1; i < fg.Rows.Count; i++)
            {
                if(fg.GetDataDisplay(i, "DaTinhPhi") == "1")
                {
                    fg.Rows[i].StyleNew.BackColor = Color.YellowGreen;
                }
                if (fg.GetDataDisplay(i, "DaTinhPhi") == "0")
                {
                    fg.Rows[i].StyleNew.BackColor = Color.White;
                }
            }
        }

        private void cmdLoad_Click(object sender, EventArgs e)
        {
            object NgayChiDinh = null;
            object NgayPT = null;
            string SoPhieu = "";
            if (chkNgayChiDinh.Checked && !txtLocNgayChiDinhPT.ValueIsDbNull) NgayChiDinh = txtLocNgayChiDinhPT.Value;
            if (chkNgayPhauThuat.Checked && ! txtLocNgayPhauThuat.ValueIsDbNull) NgayPT = txtLocNgayPhauThuat.Value;
            if (txtSoPhieu.Text.Replace(" ", "").Trim() != "NT" && chSoPhieu.Checked == true) SoPhieu = txtSoPhieu.Text.Replace(" ", "").Trim();
            Load_DSBenhNhan(Global.GetCode(cmbKhoa), NgayChiDinh, NgayPT,SoPhieu);
        }

        private void chkNgayChiDinh_CheckedChanged(object sender, EventArgs e)
        {
            txtLocNgayChiDinhPT.Enabled = chkNgayChiDinh.Checked;
            if (chkNgayChiDinh.Checked) txtLocNgayChiDinhPT.Value = Global.NgayLV; 
        }

        private void chkNgayPhauThuat_CheckedChanged(object sender, EventArgs e)
        {
            txtLocNgayPhauThuat.Enabled = chkNgayPhauThuat.Checked;
            if (chkNgayPhauThuat.Checked) txtLocNgayPhauThuat.Value = Global.NgayLV; 
        }

        private void fg_AfterSelChange(object sender, C1.Win.C1FlexGrid.RangeEventArgs e)
        {
            
            if (fg.Tag.ToString()=="0"||e.NewRange.r1<1) return;
            int _row = e.NewRange.r1;
            if (fg[_row, "DaTinhPhi"].ToString() == "1")
            {
                MessageBox.Show("Bệnh nhân đã thanh toán", "Thông Báo");
                cmdChiDinh.Enabled = false;
                cmdChiDinhTheoMatBenh.Enabled = false;
                cmdGhi.Enabled = false;
            }
            else
            {
                cmdChiDinh.Enabled = true;
                cmdChiDinhTheoMatBenh.Enabled = true;
                cmdGhi.Enabled = true;
            }
            txtMaVaoVien.Text = fg[_row, "MaVaoVien"].ToString();
            txtHoTen.Text = fg[_row, "hoten"].ToString();
            txtGioi.Text = fg[_row, "GT"].ToString();
            txtTuoi.Text = fg[_row, "Tuoi"].ToString();
            txtNgayVaoVien.Text = fg[_row, "NgayVaoVien"].ToString();
            txtDoiTuong.Text = fg[_row, "TenDT"].ToString();
            txtDoiTuong.Tag = fg[_row, "MaDTBN"];
            txtChanDoan_KDT.Text = fg[_row, "ChanDoan_KDT"].ToString();
            txtLanChuyenDT.Text = fg[_row, "LanChuyenDT"].ToString();
        }

        private void fg_DoubleClick(object sender, EventArgs e)
        {
            if (fg.Tag.ToString() == "0" || fg.Row < 1) return;
            int _row = fg.Row ;
            if(fg[_row, "DaTinhPhi"].ToString() == "1")
            {
                MessageBox.Show("Bệnh nhân đã thanh toán","Thông Báo"); 
                cmdChiDinh.Enabled = false;
                cmdChiDinhTheoMatBenh.Enabled = false;
                cmdGhi.Enabled = false;
            }
            else
            {
                cmdChiDinh.Enabled = true;
                cmdChiDinhTheoMatBenh.Enabled = true;
                cmdGhi.Enabled = true;
            }
            txtMaVaoVien.Text = fg[_row, "MaVaoVien"].ToString();
            txtHoTen.Text = fg[_row, "hoten"].ToString();
            txtGioi.Text = fg[_row, "GT"].ToString();
            txtTuoi.Text = fg[_row, "Tuoi"].ToString();
            txtNgayVaoVien.Text = fg[_row, "NgayVaoVien"].ToString();
            txtDoiTuong.Text = fg[_row, "TenDT"].ToString();
            txtDoiTuong.Tag = fg[_row, "MaDTBN"];
            txtChanDoan_KDT.Text = fg[_row, "ChanDoan_KDT"].ToString();
            txtLanChuyenDT.Text = fg[_row, "LanChuyenDT"].ToString();
            tabControl1.SelectedIndex = 1;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex != 0 && txtMaVaoVien.Text == "")
            {
                MessageBox.Show("Chưa chọn bệnh nhân!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tabControl1.SelectedIndex = 0;
                return;
            }
            tabControl1.TabPages[tabControl1.SelectedIndex].Tag = txtMaVaoVien.Text;
            switch (tabControl1.SelectedIndex)
            {
                case 1:
                    Load_ChiDinhPhauThuat(txtMaVaoVien.Text,fg.GetDataDisplay(fg.Row,"MaKhoa"));
                    break;
                case 2:
                    Load_PhauThuatDaThucHien(txtMaVaoVien.Text, fg.GetDataDisplay(fg.Row, "MaKhoa"));
                    break;
                case 3:
                    break;
            }
            txtNgayChiDinh.Value = null;
            txtDienGiai.Text ="";
            lblSoPhieuCD.Text ="";
            label4.Text = "";
            lblMasoBYT.Text = "";

        }
        private void Load_ChiDinhPhauThuat(string MaVaoVien,string MaKhoa)
        {
            Clear_Data_PhauThuat();
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            SQLCmd.CommandText = string.Format("SELECT distinct b.MaDichVu,TenDichVu,NgayChiDinh,TenKhoa,b.DaThucHien,b.LoaiDichVu,b.SoPhieu,b.TyLe,e.ThoiGianBD,a.Makhoa,case when f.LoaiPhauThuat in(51,52,53) then 1 when f.LoaiPhauThuat in (11,21,3,4) then 0 WHEN f.LoaiPhauThuat = 5 THEN 2 end as isphauthuat, c.MasoBYT  "
                                + " FROM "
                                + " ((((BENHNHAN_PHIEUDIEUTRI a INNER JOIN PHIEUDIEUTRI_CHITIET b ON a.SoPhieu=b.SoPhieu) "
                                + " INNER JOIN DMDICHVU c ON b.MaDichVu=c.MaDichVu AND b.LoaiDichVu=c.LoaiDichVu Inner JOIN DMDICHVU_KHOA dv on dv.MaDichVu = b.MaDichVu and dv.MaKhoa in {2}) "
                                + " INNER JOIN DMKHOAPHONG d ON a.MaKhoa=d.MaKhoa) "
                                + " INNER JOIN DMPHAUTHUAT f ON b.MaDichVu=f.maDichVu AND b.LoaiDichVu=f.LoaiDichVu)"
                                + " LEFT JOIN BENHNHAN_PHAUTHUAT e ON a.MaVaoVien=e.MaVaoVien AND b.MaDichVu=e.MaPT AND b.LoaiDichVu=e.LoaiDichVu"
                                + " WHERE a.MaVaoVien='{0}' and a.MaKhoa ='{1}' ", MaVaoVien,MaKhoa,Global.glbKhoa_CapNhat);
            dr = SQLCmd.ExecuteReader();
            fgPhauThuat.Tag = "0";
            fgChiDinhPT.Tag = "0";
            fgPhauThuat.Rows.Count = 1;            
            while (dr.Read())
            {
                fgPhauThuat.Rows.Add();
                fgChiDinhPT.Rows.Add();
                for (int i = 1; i < fgPhauThuat.Cols.Count; i++)
                {
                    fgPhauThuat[fgPhauThuat.Rows.Count - 1, i] = dr.GetValue(i-1);                    
                }
                //fgPhauThuat.AddItem(string.Format("{0}|{1}|{2:dd/MM/yyyy}|{3}|{4}|{5}|{6}|{7}|{8}", fgPhauThuat.Rows.Count, dr["TenPP"], dr["NgayYeuCau"], dr["TenLH"], dr["TenKhoa"], dr["DaPhauThuat"],dr["LanPT"],dr["LoaiHinhPhauThuat"],dr["YeuCauPhauThuat"]));
            }
            dr.Close();
            SQLCmd.Dispose();
            fgPhauThuat.Tag = "1";            
            fgPhauThuat.AutoSizeCols();            
        }
        private void Load_PhauThuatDaThucHien(string MaVaoVien,string MaKhoa)
        {
            fgDichVu.Rows.Count = 1;
            txtNgayChiDinh.Text = "";
            txtDienGiai.Text = "";
            lblSoPhieuCD.Text = "";
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            SQLCmd.CommandText = string.Format("set dateformat dmy SELECT a.SoPhieuCD,a.LoaiDichVu,a.MaPT,TenDichVu,ThoiGianBD,ChanDoan_TruocPT,d.MasoBYT "
                                    + " FROM ((BENHNHAN_PHAUTHUAT a INNER JOIN BENHNHAN_PHIEUDIEUTRI b ON a.MaVaoVien=b.MaVaoVien) "
                                    + " INNER JOIN PHIEUDIEUTRI_CHITIET c ON b.SoPhieu=c.SoPhieu AND a.LoaiDichVu=c.LoaiDichVu AND a.MaPT=c.MaDichVu) "
                                    + " INNER JOIN DMDICHVU d ON a.LoaiDichVu=d.LoaiDichVu AND a.maPT=d.MaDichVu"
                                    + " WHERE a.MaVaoVien='{0}' AND c.DaThucHien=1 and b.MaKhoa = '{1}'", MaVaoVien,MaKhoa);
            dr = SQLCmd.ExecuteReader();            
            fgChiDinhPT.Tag = "0";            
            fgChiDinhPT.Rows.Count = 1;
            while (dr.Read())
            {
                fgChiDinhPT.Rows.Add();
                for (int i = 1; i < fgChiDinhPT.Cols.Count; i++)
                {                
                    fgChiDinhPT[fgChiDinhPT.Rows.Count - 1, i] = dr.GetValue(i - 1);
                }
                //fgPhauThuat.AddItem(string.Format("{0}|{1}|{2:dd/MM/yyyy}|{3}|{4}|{5}|{6}|{7}|{8}", fgPhauThuat.Rows.Count, dr["TenPP"], dr["NgayYeuCau"], dr["TenLH"], dr["TenKhoa"], dr["DaPhauThuat"],dr["LanPT"],dr["LoaiHinhPhauThuat"],dr["YeuCauPhauThuat"]));
            }
            dr.Close();
            SQLCmd.Dispose();            
            fgChiDinhPT.Tag = "1";
            fgChiDinhPT.AutoSizeCols();

        }
        private void Clear_Data_PhauThuat()
        {
            lblChiDinh.Text = "";
            lblChiDinh.Tag = "";
            lblSoPhieuCDPT.Text = "";
            cmbLoaiPT.SelectedIndex = -1;
            rdPhien.Checked = false;
            rdCapCuu.Checked = false;
            cmbVoCam.SelectedIndex = -1;
            txtChanDoan_TruocPT.Text = txtChanDoan_SauPT.Text = "";
            txtThoiGianBD.Value = txtThoiGianKT.Value = txtThoiGianRutDanLuu.Value = txtThoiGianCatChi.Value = null;
            cmbSoSanh.SelectedIndex = -1;
            cmbTaiBien.SelectedIndex = -1;
            cmbBienChung.SelectedIndex = -1;
            txtMoTaKT.Text = "";
            txtKQGiaiPhauBenh.Text = "";
            txtTrinhTuMo.Text = "";
            fgKipMo.Rows.Count = 1;
            txtChoMau.Text = "";
            chkHoanHoi.Checked = chkChoMau.Checked = false;
        }
        private void Load_PhauThuat_ChiTiet(string MaVaoVien, string SoPhieuCD, string LoaiChiPhi, string MaPT)
        {
            if (SoPhieuCD == "0") return;
            //chkDaPT.Checked = (fgPhauThuat.GetCellCheck(fgPhauThuat.Row, fgPhauThuat.Cols["DaThucHien"].Index) == C1.Win.C1FlexGrid.CheckEnum.Checked);
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            SQLCmd.CommandText = string.Format("SELECT A.*, case when b.LoaiPhauThuat in(51,52,53) then 1 when b.LoaiPhauThuat in (11,21,3,4) then 0 when b.LoaiPhauThuat =5  then 2  end as isphauthuat FROM BENHNHAN_PHAUTHUAT A INNER JOIN NAMDINH_QLBN.dbo.DMPHAUTHUAT b ON a.MaPT = b.MaDichVu  "
                               + " WHERE A.MaVaoVien='{0}' AND A.SoPhieuCD='{1}' AND A.LoaiDichVu='{2}' AND A.MaPT='{3}'", MaVaoVien, SoPhieuCD, LoaiChiPhi, MaPT);
            dr = SQLCmd.ExecuteReader();

            while (dr.Read())
            {
                lblChiDinh.Tag = dr["MaPT"].ToString();
                Global.SetCmb(cmbLoaiPT, dr["LoaiPT"].ToString());
                rdPhien.Checked = (dr["Phien_CapCuu"].ToString() == "1") ? (true) : (false);
                rdCapCuu.Checked = (dr["Phien_CapCuu"].ToString() == "2") ? (true) : (false);
                Global.SetCmb(cmbVoCam, dr["PPVoCam"].ToString());
                txtChanDoan_TruocPT.Text = dr["ChanDoan_TruocPT"].ToString();
                txtChanDoan_SauPT.Text = dr["ChanDoan_SauPT"].ToString();
                Global.SetCmb(cmbPhuongPhapPT_Ma, "0" + dr["PhuongPhapPT_Ma"].ToString());
                txtPhuongPhapPT_Text.Text = dr["PhuongPhapPT_Text"].ToString();
                txtThoiGianBD.Value = dr["ThoiGianBD"];
                txtThoiGianKT.Value = dr["ThoiGianKT"];
                txtThoiGianRutDanLuu.Value = dr["ThoiGianRutDanLuu"];
                txtThoiGianCatChi.Value = dr["ThoiGianCatChi"];
                Global.SetCmb(cmbSoSanh, dr["SoSanhCD"].ToString());
                Global.SetCmb(cmbTaiBien, dr["taiBien"].ToString());
                Global.SetCmb(cmbBienChung, dr["BienChung"].ToString());
                txtMoTaKT.Text = dr["MotaKT"].ToString();
                txtKQGiaiPhauBenh.Text = dr["KQGiaiPhaubenh"].ToString();
                int TruyenMau=(dr["TruyenMau"].ToString()=="")?(0):(int.Parse(dr["TruyenMau"].ToString()));
                chkHoanHoi.Checked = ((TruyenMau & 1) == 1);
                chkChoMau.Checked = ((TruyenMau & 2) == 2);
                txtChoMau.Text = dr["TenNguoiChoMau"].ToString();
                txtSoBLVP.Text = dr["SoBLVP"].ToString();
                txtTrinhTuMo.Text = dr["TrinhTuPT"].ToString();
                fgPhauThuat[fgPhauThuat.Row, "ThoiGianBD"] = dr["ThoiGianBD"];
                txtisphauthuat.Text = dr["isphauthuat"].ToString();
            }
            dr.Close();
            fgKipMo.Rows.Count = 1;
            if (txtChanDoan_TruocPT.Text.Trim() == "")
                txtChanDoan_TruocPT.Text = fg.GetDataDisplay(fg.Row, "ChanDoan_KDT");
            SQLCmd.CommandText = string.Format("SELECT MaBS+MaKhoa As MaBS1,* FROM BENHNHAN_PT_KIPMO a INNER JOIN DMVITRI_PT b ON a.Vitri=b.MaVT WHERE MaVaoVien={0} AND SoPhieuCD='{1}' AND LoaiDichVu='{2}' AND MaPT='{3}' ORDER BY SoTTBS", MaVaoVien, SoPhieuCD, LoaiChiPhi, MaPT);
            dr = SQLCmd.ExecuteReader();
            while (dr.Read())
            {
                fgKipMo.AddItem(string.Format("{0}|{1}|{2}|{3}|{4}|{5}", dr["soTTBS"], dr["maBS1"],dr["MaKhoa"], dr["TenVT"], dr["ViTri"], dr["MA_BHXH"]));
            }
            dr.Close();

            SQLCmd.Dispose();
        }
        private void Load_PhauThuat_ChiPhi(string MaVaoVien, string SoPhieuCD, string LoaiChiPhi, string MaPT)
        {
            System.Data.SqlClient.SqlCommand SQLCmd= new System.Data.SqlClient.SqlCommand("",Global.ConnectSQL);
            SQLCmd.CommandText = string.Format("set dateformat dmy SELECT MaLoaiDichVu,TenLoaiDichVu,a.MaDichVu,TenDichVu,DVT,a.SoLuong,a.DonGia,a.KhoID,a.MaPhieuDuyet,a.NgayChiDinh,a.DaThucHien,a.TinhPhi,a.GhiChu,a.Chot,a.NgayChot,a.BSGayMe_Ky,a.DieuDuong_Ky, a.TyLe,isnull(a.TyLeBHYT,c.TyLeBH) as TyleBH,a.TTThau,a.NhomLenChiPhi,a.ThuocGayTe,a.MasoBYT "
                                            + " FROM (BENHNHAN_PT_CHIPHI a INNER JOIN DMLOAIDICHVU b ON a.LoaiChiPhi=b.MaLoaiDichVu) "
                                            + " INNER JOIN DMDICHVU c ON a.LoaiChiPhi=c.LoaiDichVu AND a.MaDichVu=c.MaDichVu "
                                            + " WHERE a.MaVaoVien='{0}' AND a.SoPhieuCD='{1}' AND a.LoaiDichVu='{2}' AND a.MaPT='{3}'",MaVaoVien,SoPhieuCD,LoaiChiPhi,MaPT);
            System.Data.SqlClient.SqlDataReader dr = SQLCmd.ExecuteReader();
            string MaCP="";
            string TenCP ="";
            string DVTinh="";
            decimal SoLuong=0;
            int DaThucHien = 0,TinhPhi = 0,Chot;
            decimal DonGia = 0;
            decimal TyLe = 100;  
            string LoaiDichVu="";
            string TenLoaiDV="",GhiChu ="";
            fgDichVu.Rows.Count = 1;
            fgDichVu.Redraw = false;
            string KhoID, MaPhieuDuyet;
            string NgayChot = "";
            string TyLeBH = "";
            string TTThau = "";
            string MasoBYT = "";
            string ThuocGayTe = "";
            while (dr.Read())
            {
                LoaiDichVu = dr["maLoaiDichVu"].ToString();
                TenLoaiDV = dr["TenLoaiDichVu"].ToString();
                MaCP = dr["MaDichVu"].ToString();
                TenCP = dr["tenDichVu"].ToString();
                DVTinh = dr["DVT"].ToString();
                SoLuong = decimal.Parse(dr["SoLuong"].ToString());
                DonGia = decimal.Parse(dr["DonGia"].ToString());
                KhoID = dr["KhoID"].ToString();
                MaPhieuDuyet = dr["MaPhieuDuyet"].ToString();
                txtNgayChiDinh.Value = dr["NgayChiDinh"];
                DaThucHien = int.Parse(dr["DaThucHien"].ToString());
                TinhPhi = int.Parse(dr["TinhPhi"].ToString() == "0" ? "0" : "1");
                GhiChu = dr["GhiChu"].ToString();
                NgayChot = dr["NgayChot"].ToString();
                Chot = int.Parse(dr["Chot"].ToString());
                TyLe = decimal.Parse(dr["TyLe"].ToString());
                TyLeBH = dr["TyleBH"].ToString();
                TTThau = dr["TTThau"].ToString();
                MasoBYT = dr["MasoBYT"].ToString();
                ThuocGayTe = dr["ThuocGayTe"].ToString();
                Global.SetCmb(cmbNhom, dr["NhomLenChiPhi"].ToString().Trim()); 
                fgDichVu.AddItem(string.Format("|{0}|{1}|{2}|{3}|{4}|{5:#,##0.##}|{6:#,##0.##}|{7}|{8:#,##0.##}|{9}|{12}|{13}|||{10}|{11}||||{14}|{15}|||||{17}|{16}|{18}|{19}",
                    LoaiDichVu,
                    TenLoaiDV,
                    MaCP,
                    TenCP,
                    DVTinh,
                    SoLuong,
                    DonGia,
                    TyLe,
                    SoLuong * DonGia * TyLe / 100,
                    GhiChu,
                    KhoID,
                    MaPhieuDuyet,
                    TinhPhi,
                    DaThucHien,
                    Chot,
                    NgayChot, TyLeBH, TTThau,ThuocGayTe, MasoBYT));
                 Global.SetCmb(cmbBSGayMeKy, dr["BsGayMe_Ky"].ToString().Trim());
                 Global.SetCmb(cmbDieuDuongKy, dr["DieuDuong_Ky"].ToString().Trim());
            }
            dr.Close();
            SQLCmd.Dispose();
            fgDichVu.Redraw = true;
            Format_Grid(fgDichVu);
        }
        private void Format_Grid(C1.Win.C1FlexGrid.C1FlexGrid fg)
        {
            fg.Redraw = false;
            fg.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.Clear, 0, 0, 0);
            fg.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.Sum, 0, 2, fg.Cols["ThanhTien"].Index, "{0}");
            int TT = 1;
            for (int i = 1; i < fg.Rows.Count; i++)
            {
                if (fg.Rows[i].IsNode) TT = 1;
                else
                {
                    fg[i, 0] = TT;
                    TT++;
                }
            }
            fg.AutoSizeCols();
            fg.Redraw = true;
            if (fg.Rows.Count <= 1) return;
            fg.Row = fg.Rows.Count - 1;
        }
        private void fgPhauThuat_AfterSelChange(object sender, C1.Win.C1FlexGrid.RangeEventArgs e)
        {
            if (fgPhauThuat.Tag.ToString() == "0" || e.NewRange.r1 < 1) { return; }
            Clear_Data_PhauThuat();
            lblSoPhieuCDPT.Text = fgPhauThuat[fgPhauThuat.Row, "SoPhieuCD"].ToString();
            lblChiDinh.Text = fgPhauThuat[fgPhauThuat.Row, "TenPT"].ToString();
            lblChiDinh.Tag = fgPhauThuat[fgPhauThuat.Row, "MaChiPhi"].ToString();
            lblLoaiChiPhi.Text = fgPhauThuat[fgPhauThuat.Row, "LoaiChiPhi"].ToString();
            chkDaPT.Checked = (fgPhauThuat.GetCellCheck(fgPhauThuat.Row, fgPhauThuat.Cols["DaThucHien"].Index) == C1.Win.C1FlexGrid.CheckEnum.Checked);
            txtNgaychidinh_PT.Value = Convert.ToDateTime(fgPhauThuat[fgPhauThuat.Row, "NgayCD"]);
            txtisphauthuat.Text = fgPhauThuat[fgPhauThuat.Row, "isphauthuat"].ToString();
            Load_PhauThuat_ChiTiet(txtMaVaoVien.Text, lblSoPhieuCDPT.Text, lblLoaiChiPhi.Text, lblChiDinh.Tag.ToString());

        }

        private void cmdTongketPT_Click(object sender, EventArgs e)
        {
            if (fgPhauThuat.Row < 1 || lblSoPhieuCDPT.Text == "") return;
            if (rdCapCuu.Checked == false && rdPhien.Checked == false)
            {
                MessageBox.Show("Phải chọn mổ phiên hoặc mổ cấp cứu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cmbVoCam.SelectedIndex == -1)
            {
                cmbVoCam.Focus();
                MessageBox.Show("Nhập phương pháp Vô cảm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtChanDoan_TruocPT.Text.Trim() == "")
            {
                txtChanDoan_TruocPT.Focus();
                MessageBox.Show("Nhập chẩn đoán trước phẫu thuật", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (txtChanDoan_SauPT.Text.Trim() == "")
            {
                txtChanDoan_SauPT.Focus();
                MessageBox.Show("Nhập chẩn đoán sau phẫu thuật", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (txtThoiGianBD.ValueIsDbNull || txtThoiGianKT.ValueIsDbNull)
            {
                MessageBox.Show("Nhập thời gian bắt đầu hoặc kết thúc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
       


            //string time1 = DateTime.Parse("1:30 PM").ToString("t");
            //string time2 = DateTime.Now.ToString("t");
            //if (DateTime.Compare(DateTime.Parse(time1), DateTime.Parse(time2)) < 0)
            //{
            //    Response.Write("time1 is less than time2");
            //}
            //else
            //{
            //    Response.Write("time1 is greater than time2");
            //}
            //DateTime xx = (DateTime)txtThoiGianBD.Value;
            
            //DateTime tgBD = DateTime.Parse(string.Format("{0:dd/MM/yyyy HH:mm}", txtThoiGianBD.Value));
            //DateTime tgCD = DateTime.Parse(string.Format("{0:dd/MM/yyyy HH:mm}", txtNgaychidinh_PT.Value));  

            if (DateTime.Compare((DateTime)txtThoiGianBD.Value, (DateTime)txtNgaychidinh_PT.Value) < 0)  
            {
                MessageBox.Show("Thời gian bắt đầu phẫu thuật phải sau thời gian chỉ định.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cmbPhuongPhapPT_Ma.SelectedIndex == -1)
            {
                cmbPhuongPhapPT_Ma.Focus();
                MessageBox.Show("Nhập cách mổ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtPhuongPhapPT_Text.Text.Trim() == "")
            {
                txtPhuongPhapPT_Text.Focus();
                MessageBox.Show("Nhập cách mổ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTrinhTuMo.Text.Trim() == "")
            {
                txtTrinhTuMo.Focus();
                MessageBox.Show("Nhập trình tự mổ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (lblChiDinh.Tag.ToString() == "") return;
            string Mochinh = "";
            string Phumo = "";
            string Gaymechinh = "";
            string Phugayme = "";
            string Giupviec = "";
            string Gayme = ""; // = Gaymechinh + Phugayme

            int SL_Mochinh = 0;
            int SL_Phumo = 0;
            int SL_Gaymechinh = 0;
            int SL_Phugayme = 0;
            int SL_Giupviec = 0;

            //đoạn này kiểm tra tính hợp lệ kíp mổ
            if (fgKipMo.Rows.Count > 1 )
            {
                if(txtisphauthuat.Text == "0" && Global.GetCode(cmbKhoa) == "NV1103")
                {
                    for (int i = 1; i < fgKipMo.Rows.Count; i++)
                    {
                        if (fgKipMo.GetDataDisplay(i, 3) == "Mổ chính")
                        {
                            SL_Mochinh = SL_Mochinh + 1;
                        }
                        if (fgKipMo.GetDataDisplay(i, 3) == "Phụ mổ")
                        {
                            SL_Phumo = SL_Phumo + 1;
                        }
                        if (fgKipMo.GetDataDisplay(i, 3) == "Gây mê chính")
                        {
                            SL_Gaymechinh = SL_Gaymechinh + 1;
                        }
                        if (fgKipMo.GetDataDisplay(i, 3) == "Phụ gây mê")
                        {
                            SL_Phugayme = SL_Phugayme + 1;
                        }
                        if (fgKipMo.GetDataDisplay(i, 3) == "Giúp việc")
                        {
                            SL_Giupviec = SL_Giupviec + 1;
                        }

                    }
                    if (SL_Mochinh < 1 || SL_Mochinh > 2 || SL_Phumo > 4 || SL_Gaymechinh != 1 || SL_Phugayme > 2 || SL_Giupviec > 1)
                    {
                        MessageBox.Show("Số lượng người tham gia kíp mổ chưa đúng.\n\nMổ chính: bắt buộc phải nhập, ≤ 2 người khác nhau\nPhụ mổ: ≤ 4 người khác nhau\nGây mê chính: bắt buộc phải nhập, chỉ được nhập 1 người.\nPhụ gây mê: ≤ 2 người khác nhau\nGiúp việc: ≤ 1 người.\n\nĐề nghị nhập lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                }
                if (txtisphauthuat.Text == "1" && Global.GetCode(cmbKhoa) == "NV1103")
                {
                    if(fgKipMo.Rows.Count -1 > 4 )
                    {
                        MessageBox.Show("Số lượng người tham gia kíp mổ phẫu thuật loại 1,2 chưa đúng. \nĐề nghị nhập lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                if (txtisphauthuat.Text == "2" && Global.GetCode(cmbKhoa) == "NV1103")
                {
                    if (fgKipMo.Rows.Count -1 > 6)
                    {
                        MessageBox.Show("Số lượng người tham gia kíp mổ phẫu thuật đặc biệt chưa đúng.\nĐề nghị nhập lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

            }
            //------------------------------------
            if (fgKipMo.Rows.Count > 1)
            {
                for (int i = 1; i < fgKipMo.Rows.Count; i++)
                {
                    if (fgKipMo.GetDataDisplay(i, 3) == "Mổ chính")
                    {
                        Mochinh = Mochinh + fgKipMo.GetDataDisplay(i, 1) + ", ";
                    }
                    if (fgKipMo.GetDataDisplay(i, 3) == "Phụ mổ")
                    {
                        Phumo = Phumo + fgKipMo.GetDataDisplay(i, 1) + ", ";
                    }
                    if (fgKipMo.GetDataDisplay(i, 3) == "Gây mê chính")
                    {
                        Gaymechinh = Gaymechinh + fgKipMo.GetDataDisplay(i, 1) + ", ";
                    }
                    if (fgKipMo.GetDataDisplay(i, 3) == "Phụ gây mê")
                    {
                        Phugayme = Phugayme + fgKipMo.GetDataDisplay(i, 1) + ", ";
                    }
                    if (fgKipMo.GetDataDisplay(i, 3) == "Giúp việc")
                    {
                        Giupviec = Giupviec + fgKipMo.GetDataDisplay(i, 1) + ", ";
                    }

                }
                if (Mochinh != "")
                {
                    Mochinh = Mochinh.Substring(0, Mochinh.Length - 2);
                }
                if (Phumo != "")
                {
                    Phumo = Phumo.Substring(0, Phumo.Length - 2);
                }
                if (Gaymechinh != "")
                {
                    Gaymechinh = Gaymechinh.Substring(0, Gaymechinh.Length - 2);
                    Gayme = Gayme + Gaymechinh;
                }
                if (Phugayme != "")
                {
                    Phugayme = Phugayme.Substring(0, Phugayme.Length - 2);
                    if (Gayme != "")
                    {
                        Gayme = Gayme + ", " + Phugayme;
                    }
                    else
                    {
                        Gayme = Gayme + Phugayme;
                    }

                }
                if (Giupviec != "")
                {
                    Giupviec = Giupviec.Substring(0, Giupviec.Length - 2);
                }

            }

            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
            System.Data.SqlClient.SqlTransaction trn = Global.ConnectSQL.BeginTransaction();
            SQLCmd.Transaction = trn;            
            try
            {
                SQLCmd.CommandText = string.Format("set dateformat dmy DELETE FROM BENHNHAN_PHAUTHUAT WHERE MaVaoVien='{0}' AND SoPhieuCD='{1}' AND LoaiDichVu='{2}' AND MaPT='{3}'", txtMaVaoVien.Text,lblSoPhieuCDPT.Text, lblLoaiChiPhi.Text, lblChiDinh.Tag);
                SQLCmd.ExecuteNonQuery();
                int TruyenMau = 0;
                if (chkHoanHoi.Checked) TruyenMau = TruyenMau | 1;
                if (chkChoMau.Checked) TruyenMau = TruyenMau | 2;
                SQLCmd.CommandText = string.Format("INSERT INTO BENHNHAN_PHAUTHUAT (MaVaoVien,MaPT,LoaiPT,Phien_CapCuu,PPVoCam,ChanDoan_TruocPT,"
                        + " ChanDoan_SauPT,PhuongPhapPT_Ma,PhuongPhapPT_Text,ThoiGianBD,ThoiGianKT,ThoiGianRutDanLuu,ThoigianCatChi,"
                        + " SoSanhCD,TaiBien,BienChung,MoTaKT,KQGiaiPhauBenh,LoaiDichVu,SoPhieuCD,TruyenMau,TenNguoiChoMau,SoBLVP,TrinhTuPT) "
                        + " VALUES ('{0}','{1}',{2},{3},{4},N'{5}',N'{6}',{7},N'{8}',{9},{10},{11},{12},{13},{14},{15},N'{16}',N'{17}','{18}','{19}',{20},N'{21}','{22}',N'{23}')",
                        txtMaVaoVien.Text, 
                        lblChiDinh.Tag,
                        (cmbLoaiPT.SelectedIndex == -1) ? ("Null") : ("'" + Global.GetCode(cmbLoaiPT) + "'"),
                        (rdPhien.Checked) ? (1) : (2),
                        (cmbVoCam.SelectedIndex == -1) ? ("Null") : ("'" + Global.GetCode(cmbVoCam) + "'"),
                        txtChanDoan_TruocPT.Text.Replace("'", "''"),
                        txtChanDoan_SauPT.Text.Replace("'", "''"),
                        (cmbPhuongPhapPT_Ma.SelectedIndex == -1) ? ("Null") : ("'" + Global.GetCode(cmbPhuongPhapPT_Ma) + "'"),
                        txtPhuongPhapPT_Text.Text.Replace("'", "''"),
                        (txtThoiGianBD.ValueIsDbNull) ? ("null") : (string.Format("'{0:dd/MM/yyyy HH:mm}'", txtThoiGianBD.Value)),
                        (txtThoiGianKT.ValueIsDbNull) ? ("null") : (string.Format("'{0:dd/MM/yyyy HH:mm}'", txtThoiGianKT.Value)),
                        (txtThoiGianRutDanLuu.ValueIsDbNull) ? ("null") : (string.Format("'{0:dd/MM/yyyy HH:mm}'", txtThoiGianRutDanLuu.Value)),
                        (txtThoiGianCatChi.ValueIsDbNull) ? ("null") : (string.Format("'{0:dd/MM/yyyy HH:mm}'", txtThoiGianCatChi.Value)),
                        (cmbSoSanh.SelectedIndex == -1) ? ("Null") : (Global.GetCode(cmbSoSanh)),
                        (cmbTaiBien.SelectedIndex == -1) ? ("Null") : (Global.GetCode(cmbTaiBien)),
                        (cmbBienChung.SelectedIndex == -1) ? ("Null") : (Global.GetCode(cmbBienChung)),
                        txtMoTaKT.Text.Replace("'", "''"),
                        txtKQGiaiPhauBenh.Text.Replace("'", "''"),
                        lblLoaiChiPhi.Text,
                        lblSoPhieuCDPT.Text,
                        TruyenMau,
                        txtChoMau.Text,
                        txtSoBLVP.Text,txtTrinhTuMo.Text);
                SQLCmd.ExecuteNonQuery();
                int DaThucHien = (chkDaPT.Checked) ? (1) : (0);
                SQLCmd.CommandText = string.Format("UPDATE PHIEUDIEUTRI_CHITIET SET DaThucHien={0}, MaKhoaThucHien = 'NV1103' WHERE SoPhieu='{1}' AND LoaiDichVu='{2}' AND MaDichVu='{3}'", DaThucHien, lblSoPhieuCDPT.Text, lblLoaiChiPhi.Text, lblChiDinh.Tag);
                SQLCmd.ExecuteNonQuery();

                SQLCmd.CommandText = String.Format("if(exists(select NguoiThucHien from thongtin_phauthuat where mavaovien ='{0}'))"
                    + " begin"
                    + " update thongtin_phauthuat set  NguoiThucHien=N'{1}',NguoiPhu=N'{2}', GayMe=N'{3}',TPKhac = N'{4}',PhuGayMe = N'{5}', PhuongPhapDK = N'{6}' where mavaovien='{0}'"
                    + " end", txtMaVaoVien.Text, Mochinh, Phumo, Gaymechinh, Giupviec, Phugayme, txtPhuongPhapPT_Text.Text.Replace("'", "''"));
                SQLCmd.ExecuteNonQuery();

                SQLCmd.CommandText = string.Format("DELETE FROM BENHNHAN_PT_KIPMO WHERE MaVaoVien='{0}' AND SoPhieuCD='{1}' AND LoaiDichVu='{2}' AND MaPT='{3}'", txtMaVaoVien.Text, lblSoPhieuCDPT.Text, lblLoaiChiPhi.Text, lblChiDinh.Tag);
                SQLCmd.ExecuteNonQuery();
                int SoTT_BS = 1;
                string StrSQL = "";
                for (int i = 1; i < fgKipMo.Rows.Count; i++)
                {
                    if (fgKipMo.GetDataDisplay(i, 1) != "" && fgKipMo.GetDataDisplay(i, 2) != "")
                    {
                        StrSQL = string.Format("INSERT INTO BENHNHAN_PT_KIPMO (MaVaoVien,SoPhieuCD,LoaiDichVu,MaPT,SoTTBS,MaBS,ViTri,MaKhoa,MA_BHXH) VALUES ('{0}','{1}','{2}','{3}',{4},N'{5}',{6},'{7}','{8}')",
                            txtMaVaoVien.Text,
                            lblSoPhieuCDPT.Text, lblLoaiChiPhi.Text, lblChiDinh.Tag,
                            SoTT_BS,
                            fgKipMo.GetData(i,"TenBacSy").ToString().Substring(0,2),
                            fgKipMo.GetData(i, "MaVT"),
                            fgKipMo.GetData(i,"Khoa"),
                            fgKipMo.GetData(i, "MA_BHXH"));
                        SQLCmd.CommandText = StrSQL;
                        SQLCmd.ExecuteNonQuery();
                        SoTT_BS += 1;
                    }
                }
                trn.Commit();
                fgPhauThuat[fgPhauThuat.Row, "DaThucHien"] = DaThucHien;                
                MessageBox.Show("Đã cập nhật biên bản phẫu thuật vào CSDL", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

            if (fgPhauThuat.Rows.Count > 1)
            {
                System.Data.SqlClient.SqlCommand SQLCmd1 = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
                SqlDataReader dr1;
                int a = 0;
                string s = "";
                for (int i = 0; i < fgPhauThuat.Rows.Count; i++)
                {
                    if (fgPhauThuat.GetDataDisplay(i, "TyLe") == "100")
                    {
                        a++;
                        s = fgPhauThuat.GetDataDisplay(i, "ThoiGianBD");
                    }
                    if (a > 1)
                    {
                        SQLCmd1.CommandText = string.Format("set dateformat DMY select count(*) as SL from NAMDINH_QLBN.dbo.BENHNHAN_PHAUTHUAT where mavaovien = '{0}' and convert(varchar(10),ThoiGianBD,103)  = N'{1:dd/MM/yyyy}'", txtMaVaoVien.Text, DateTime.Parse(s));
                        dr1 = SQLCmd1.ExecuteReader();
                        while (dr1.Read())
                        {
                            if (int.Parse(dr1["Sl"].ToString()) >= 2)
                            {
                                MessageBox.Show("Trong cùng 1 ngày, bạn đang thanh toán 2 phẫu thuật có “Tỷ lệ TT” là 100%. Bạn xem lại, nếu trong 1 cuộc phẫu thuật:" + Environment.NewLine + "+ Phẫu thuật cao tiền nhất Tỷ lệ TT là 100" + Environment.NewLine + "+ Từ phẫu thuật thứ 2 trở đi Tỷ lệ TT  là 50 (nếu cùng 1 ekip) là 80% nếu khác ekip" + Environment.NewLine + "+ Thủ thuật Tỷ lệ TT là 80");
                            }
                        }
                        dr1.Close();
                    }
                }
            }
        }

        private void fgKipMo_DoubleClick(object sender, EventArgs e)
        {
            if (fgPhauThuat.Rows.Count <= 1) return;
            if (fgPhauThuat.Row <= 0) return;

            //System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
            ////System.Data.SqlClient.SqlTransaction trn = Global.ConnectSQL.BeginTransaction();
            ////SQLCmd.Transaction = trn;
            //string SoPhieu = fgPhauThuat.GetDataDisplay(fgPhauThuat.Row, "SoPhieuCD"); //lblSoPhieuCD.Text;
            //string LoaiDichVu = fgPhauThuat.GetDataDisplay(fgPhauThuat.Row, "LoaiChiPhi"); //fgChiDinhPT[fgChiDinhPT.Row, "LoaiDichVu"].ToString();
            //string MaPT = fgPhauThuat.GetDataDisplay(fgPhauThuat.Row, "Machiphi"); //fgChiDinhPT[fgChiDinhPT.Row, "MaPT"].ToString();
            //SQLCmd.CommandText = string.Format("Select MaVaoVien FROM BENHNHAN_PT_CHIPHI WHERE MaVaoVien='{0}' AND SoPhieuCD='{1}' AND LoaiDichVu='{2}' AND MaPT='{3}'", txtMaVaoVien.Text, SoPhieu, LoaiDichVu, MaPT);
            //System.Data.SqlClient.SqlDataReader dr = SQLCmd.ExecuteReader();
            //if (dr.HasRows)
            //{
            //    MessageBox.Show("Đã nhập chi phí trong mổ.\nKhông cho phép sửa ca kíp phẫu thuật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    dr.Close();
            //    return;
            //}
            //dr.Close();
            //SQLCmd.Dispose();   
            if(txtThoiGianBD.ValueIsDbNull && txtThoiGianKT.ValueIsDbNull)
            {
                MessageBox.Show("Nhập thời gian phẫu thuật trước khi nhập kíp", "Thông Báo", MessageBoxButtons.OK);
                return;
            }
            else
            {
                NamDinh_QLBN.Forms.DuLieu.frmCapNhatKipMo_PhongMo fr = new frmCapNhatKipMo_PhongMo(fgKipMo, "0", DateTime.Parse(txtThoiGianBD.Value.ToString()), DateTime.Parse(txtThoiGianKT.Value.ToString()));
                fr.ShowDialog();
            }

        }

        private void cmdChiDinh_Click(object sender, EventArgs e)
        {
            if (lblSoPhieuCD.Text == "")
            {
                MessageBox.Show("Chưa chọn phẫu thuật.\nĐề nghị nhập lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                fgChiDinhPT.Focus();
                return;
            }
            if (fgKipMo.Rows.Count <2)
            {
                MessageBox.Show("Chưa nhập kíp phẫu thuật.\nĐề nghị nhập trước khi nhập chi phí!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string MaDoiTuongBN = txtDoiTuong.Tag.ToString();
            NamDinh_QLBN.Forms.DuLieu.frmNhapChiDinhChiPhi fr = new frmNhapChiDinhChiPhi(fgDichVu, MaDoiTuongBN, Global.glbMaKhoaPhong, DateTime.Parse(txtNgayVaoVien.Text));
            fr.ShowDialog();
        }

        private void cmdGhi_Click(object sender, EventArgs e)
        {
            string DonGia = "";
            if (lblSoPhieuCD.Text =="")
            {
                MessageBox.Show("Chưa chọn phẫu thuật.\nĐề nghị nhập lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                fgChiDinhPT.Focus();
                return;
            }

            if(cmbNhom.SelectedIndex == -1)
            {
                MessageBox.Show("Chưa Nhập Phòng Mổ.\nĐề nghị nhập lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbNhom.Focus();
                return;
            }
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
            System.Data.SqlClient.SqlTransaction trn = Global.ConnectSQL.BeginTransaction();
            SQLCmd.Transaction = trn;
            string SoPhieu = lblSoPhieuCD.Text;
            string LoaiDichVu = fgChiDinhPT[fgChiDinhPT.Row, "LoaiDichVu"].ToString();
            string MaPT = fgChiDinhPT[fgChiDinhPT.Row, "MaPT"].ToString();
            try
            {
                SQLCmd.CommandText = string.Format("DELETE FROM BENHNHAN_PT_CHIPHI WHERE MaVaoVien='{0}' AND SoPhieuCD='{1}' AND LoaiDichVu='{2}' AND MaPT='{3}'",txtMaVaoVien.Text, SoPhieu,LoaiDichVu,MaPT);
                SQLCmd.ExecuteNonQuery();
               
                for (int i = 1; i < fgDichVu.Rows.Count; i++)
                {
                    if (!fgDichVu.Rows[i].IsNode)
                    {
                        if (fgDichVu[i, "LoaiDichVu"].ToString() == "D01" && lblMasoBYT.Text.Substring(lblMasoBYT.Text.Length - 3, 3) == "_GT")
                        {
                            //if(fgDichVu[i, "KhongTinhPhi"].ToString().ToLower() == "false")
                            //{
                                fgDichVu[i, "KhongTinhPhi"] = "true";
                                fgDichVu[i, "ThuocGayTe"] = "1";
                                fgDichVu[i, "MasoBYT"] = lblMasoBYT.Text;
                            //}
                            //else
                            ////{
                            //    fgDichVu[i, "KhongTinhPhi"] = "true";
                            //    fgDichVu[i, "ThuocGayTe"] = "1";
                            //    fgDichVu[i, "MasoBYT"] = lblMasoBYT.Text;
                            //}

                        }
                        DonGia = string.Format("{0}",fgDichVu[i, "DonGia"].ToString() == "" ? 0 : fgDichVu[i, "DonGia"]);
                        SQLCmd.CommandText = string.Format("INSERT INTO BENHNHAN_PT_CHIPHI (MaVaoVien,SoPhieuCD,LoaiDichVu,MaPT,LoaiChiPhi,MaDichVu,SoLuong,DonGia,MaDTBN,KhoID,MaPhieuDuyet,NgayChiDinh,DaThucHien,TinhPhi,GhiChu,Chot,NgayChot,BsGayMe_Ky,DieuDuong_Ky, TyLe,LanChuyenDT,TyLeBHYT,TTThau,NhomLenChiPhi,ThuocGayTe,MasoBYT)"
                            + " VALUES ('{0}','{1}','{2}','{3}','{4}','{5}',{6},{7:#.##},'{8}',{9},'{10}','{11:dd/MM/yyyy}',{12},{13},'{14}',{15},{16},'{17}','{18}',{19},{20},{21},'{22}','{23}','{24}','{25}')",
                                                    txtMaVaoVien.Text,SoPhieu,LoaiDichVu,MaPT,
                                                    fgDichVu[i, "LoaiDichVu"],
                                                    fgDichVu[i, "MaDichVu"],
                                                    fgDichVu[i, "SoLuong"].ToString().Replace(",","."),DonGia.Replace(",","."),
                                                    //fgDichVu[i, "DonGia"].ToString() == "" ? 0 : fgDichVu[i, "DonGia"],
                                                    txtDoiTuong.Tag.ToString(),
                                                    fgDichVu[i, "KhoID"].ToString() == "" ? "null" : fgDichVu[i, "KhoID"].ToString(),
                                                    fgDichVu.GetDataDisplay(i, "MaPhieuDuyet").ToString().Trim() == "" ? "null" : fgDichVu.GetDataDisplay(i, "MaPhieuDuyet").ToString().Trim(),
                                                    txtNgayChiDinh.Value,
                                                    fgDichVu.GetData(i,"DaThucHien").ToString().ToLower() == "true" ? "1" :"0",
                                                    fgDichVu.GetData(i, "KhongTinhPhi").ToString().ToLower() == "true" ? "1" : "0",
                                                    fgDichVu.GetDataDisplay(i,"GhiChu").ToString(),
                                                    fgDichVu.GetDataDisplay(i, "Chot").ToString() == "" ? "0" : fgDichVu.GetData(i, "Chot").ToString(),
                                                    fgDichVu.GetDataDisplay(i, "NgayChot").ToString() == "01/01/0001" ? "null" : string.Format("'{0:dd/MM/yyyy}'", fgDichVu.GetData(i, "NgayChot")),
                                                    Global.GetCode(cmbBSGayMeKy), Global.GetCode(cmbDieuDuongKy), fgDichVu.GetDataDisplay(i, "TyLe"),txtLanChuyenDT.Text, fgDichVu.GetDataDisplay(i, "TyLeBH").ToString(), fgDichVu.GetDataDisplay(i, "TTThau").ToString(), Global.GetCode(cmbNhom), fgDichVu.GetDataDisplay(i, "ThuocGayTe").ToString(), fgDichVu.GetDataDisplay(i, "MasoBYT").ToString());
                        SQLCmd.ExecuteNonQuery();
                    }
                }
                trn.Commit();
                MessageBox.Show("đã cập nhật chi phí phẫu thuật của bệnh nhân!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void fgChiDinhPT_AfterSelChange(object sender, C1.Win.C1FlexGrid.RangeEventArgs e)
        {
            if (fgChiDinhPT.Tag.ToString() == "0" || fgChiDinhPT.Row<1) return;
            int _row = fgChiDinhPT.Row;
            txtNgayChiDinh.Value = fgChiDinhPT[_row, "NgayPT"];
            txtDienGiai.Text = fgChiDinhPT[_row, "ChanDoan_TruocPT"].ToString();
            lblSoPhieuCD.Text = fgChiDinhPT[_row,"SoPhieuCD"].ToString();
            label4.Text = fgChiDinhPT[_row,"TenDichVu"].ToString();
            lblMasoBYT.Text = fgChiDinhPT[_row, "MasoBYT"].ToString();
            Load_PhauThuat_ChiPhi(txtMaVaoVien.Text, fgChiDinhPT[_row, "SoPhieuCD"].ToString(), fgChiDinhPT[_row, "LoaiDichVu"].ToString(), fgChiDinhPT[_row, "MaPT"].ToString());
        }

        private void chkChoMau_CheckedChanged(object sender, EventArgs e)
        {
            txtChoMau.Visible = chkChoMau.Checked;            
        }

        private void cmdIn_Click(object sender, EventArgs e)
        {
            if (fgChiDinhPT.Row < 0 || lblSoPhieuCD.Text == "") return;
            //NamDinh_QLBN.Reports.PhauThuat.rptChiPhiPT rpt = new NamDinh_QLBN.Reports.PhauThuat.rptChiPhiPT(txtMaVaoVien.Text, txtHoTen.Text, txtTuoi.Text, txtDoiTuong.Text, txtNgayVaoVien.Text, txtNgayChiDinh.Text, txtDienGiai.Text, label4.Text,cmbBSGayMeKy.Text,cmbDieuDuongKy.Text);
            NamDinh_QLBN.Reports.PhauThuat.rptChiPhiPT_Mau02 rpt = new NamDinh_QLBN.Reports.PhauThuat.rptChiPhiPT_Mau02(txtMaVaoVien.Text, txtHoTen.Text, txtTuoi.Text, txtGioi.Text, txtDoiTuong.Text, txtNgayVaoVien.Text,  txtNgayChiDinh.Text, fg[fg.Row, "DiaChi"].ToString(), fg[fg.Row, "GTriTu"].ToString(), fg[fg.Row, "GTriDen"].ToString(), fg[fg.Row, "SoThe"].ToString(), fg[fg.Row, "NoiCap"].ToString(), "", "", "", txtDienGiai.Text, "", "", "", "", fg[fg.Row, "Tuyen"].ToString(), fg[fg.Row, "MaBenh"].ToString(), (int)fg[fg.Row, "PhantramDuocHuong"] );
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
            int _row = fgChiDinhPT.Row;
            SQLCmd.CommandText = string.Format("SELECT a.TinhPhi,b.TenLoaiDichvu as TenLoaiDichVu,TenDichVu,DVT,Sum(SoLuong) As SoLuong, a.DonGia as DonGia,case when a.TinhPhi = 0 then Sum(SoLuong)*a.DonGia end  As ThanhTienKhongTinhPhi, "
                        + " case when a.TinhPhi = 1 then Sum(SoLuong)*a.DonGia end  As ThanhTienTinhPhi "
                        + " FROM (BENHNHAN_PT_CHIPHI a INNER JOIN DMLOAIDICHVU b ON a.LoaiChiPhi=b.MaLoaiDichVu) "
                        + " INNER JOIN (select distinct madichvu,TenDichvu,DVT from NAMDINH_QLBN.dbo.DM_INPHIEUTHANHTOAN) c ON a.MaDichVu=c.MaDichVu "
                        // + " INNER JOIN DMNHOMDICHVU_BHYT d ON d.MaNhom = c.NhomBHYT " 
                        + " WHERE MaVaoVien='{0}' AND SoPhieuCD='{1}' AND a.LoaiDichVu='{2}' AND MaPT='{3}' "
                        + " GROUP BY a.TinhPhi,b.TenLoaiDichvu,TenDichVu,DVT,a.DonGia Order by a.TinhPhi,b.TenLoaiDichvu", txtMaVaoVien.Text, lblSoPhieuCD.Text, fgChiDinhPT[_row, "LoaiDichVu"].ToString(), fgChiDinhPT[_row, "MaPT"].ToString(), (int)fg[fg.Row, "PhantramDuocHuong"]);
            System.Data.SqlClient.SqlDataReader dr = SQLCmd.ExecuteReader();
            rpt.DataSource = dr;
            rpt.Show();
            dr.Close();
            //MessageBox.Show("đến 1");
            //if (txtDoiTuong.Text == "Bảo hiểm y tế")
            //{
            //    NamDinh_QLBN.Reports.PhauThuat.rptChiPhiPT_ChenhLech rptCL = new NamDinh_QLBN.Reports.PhauThuat.rptChiPhiPT_ChenhLech(txtMaVaoVien.Text, txtHoTen.Text, txtTuoi.Text, txtDoiTuong.Text, txtNgayVaoVien.Text, txtNgayChiDinh.Text, txtDienGiai.Text, label4.Text, cmbBSGayMeKy.Text, cmbDieuDuongKy.Text);
            //    SQLCmd.CommandText = string.Format("SELECT a.TinhPhi,TenLoaiDichVu,TenDichVu,DVT,Sum(SoLuong) As SoLuong,c.DonGiaChenh as DonGia,Sum(SoLuong)*c.DonGiaChenh As ThanhTien "
            //    + " FROM (BENHNHAN_PT_CHIPHI a INNER JOIN DMLOAIDICHVU b ON a.LoaiChiPhi=b.MaLoaiDichVu) "
            //    + " INNER JOIN (Select * from DMDICHVU where is_chenh = 1 and Khongsudung = 0) c ON a.MaDichVu=c.MaDichVu "
            //    + " WHERE MaVaoVien='{0}' AND SoPhieuCD='{1}' AND a.LoaiDichVu='{2}' AND MaPT='{3}' "
            //    + " GROUP BY a.TinhPhi,TenLoaiDichVu,TenDichVu,DVT,c.DonGiaChenh Order by a.TinhPhi,TenLoaiDichVu", txtMaVaoVien.Text, lblSoPhieuCD.Text, fgChiDinhPT[_row, "LoaiDichVu"].ToString(), fgChiDinhPT[_row, "MaPT"].ToString());
            //    dr = SQLCmd.ExecuteReader();
            //    //MessageBox.Show("đến 2");
            //    if (dr.HasRows)
            //    {
            //        rptCL.DataSource = dr;
            //        rptCL.Show();
            //    }
            //    dr.Close();
            //}
            SQLCmd.Dispose();            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void chSoPhieu_CheckedChanged(object sender, EventArgs e)
        {
            txtSoPhieu.Enabled = chSoPhieu.Checked;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

        }

        private void cmdMau_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.In.PhauThuat.frmXinMau frm = new NamDinh_QLBN.Forms.In.PhauThuat.frmXinMau(txtMaVaoVien.Text,lblSoPhieuCD.Text.Trim(),String.Format("{0:dd/MM/yyyy}",txtNgayChiDinh.Value));
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (fgPhauThuat.Rows.Count <= 1) return;
            if (fgPhauThuat.Row <= 0) return;
            String SoPhieu,MaVaoVien,LoaiDichVu,MaPT;
            SoPhieu = fgPhauThuat.GetDataDisplay(fgPhauThuat.Row, "SoPhieuCD");
            MaVaoVien = txtMaVaoVien.Text;
            LoaiDichVu = fgPhauThuat.GetDataDisplay(fgPhauThuat.Row, "LoaiChiPhi");
            MaPT = fgPhauThuat.GetDataDisplay(fgPhauThuat.Row, "MaChiPhi");
            NamDinh_QLBN.Reports.PhauThuat.repPhieuPT_TT rep = new NamDinh_QLBN.Reports.PhauThuat.repPhieuPT_TT(SoPhieu, MaVaoVien, LoaiDichVu, MaPT);
            rep.Show();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Reports.repDuyetPhauThuat repDPT = new NamDinh_QLBN.Reports.repDuyetPhauThuat(txtMaVaoVien.Text.Trim(), txtNgaychidinh_PT.Value, lblSoPhieuCDPT.Text.Trim(), fgPhauThuat.GetDataDisplay(fgPhauThuat.Row, "MaKhoa"), fgPhauThuat.GetDataDisplay(fgPhauThuat.Row, "KhoaCD"));
            repDPT.Show();
        }

        private void mnuSua_Click(object sender, EventArgs e)
        {
            if (fgDichVu.Rows.Count <2) return;
            string Ten = Microsoft.VisualBasic.Interaction.InputBox("Tên phẫu thuật:", "Nhập tên phẫu thuật",fgChiDinhPT.GetDataDisplay(fgChiDinhPT.Row,"TenDichVu"),100,100);
            if (Ten == "") return;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            System.Data.SqlClient.SqlTransaction trn = Global.ConnectSQL.BeginTransaction();
            SQLCmd.Transaction = trn;
            
            try
            {
                //Kiểm tra xem có tên chưa?
                SQLCmd.CommandText = String.Format("Select count(*) as SL from tblSoTayDonThuoc where MatBenh = N'{0}'", Ten);
                if (SQLCmd.ExecuteScalar().ToString() != "0")
                {
                    MessageBox.Show("Trong danh sách của Sổ tay đã có chi phí cho phẫu thuật này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    trn.Commit();
                    return;
                }
                //Thêm vào bảng tblSoTayDonThuoc
                SQLCmd.CommandText = String.Format("Insert into tblSoTayDonThuoc(MaKhoa,MatBenh) values('{0}',N'{1}') select @@IDENTITY ", Global.glbMaKhoaPhong, Ten);
                int id = (int)Convert.ChangeType(SQLCmd.ExecuteScalar(), typeof(int));
                //Thêm vào bảng tblSoTayDonThuoc_CT
                for (int i = 1; i < fgDichVu.Rows.Count; i++)
                {
                    if (!fgDichVu.Rows[i].IsNode)
                    {
                        SQLCmd.CommandText = String.Format("insert into tblSoTayDonThuoc_CT(id_sotaydonthuoc,MaThuoc,SoLuong,LoaiDichVu) values({0},'{1}',{2},'{3}')",
                        id,
                        fgDichVu.GetDataDisplay(i, "MaDichVu"),
                        fgDichVu.GetDataDisplay(i, "SoLuong").ToString().Replace(",","."),
                        fgDichVu.GetDataDisplay(i, "LoaiDichVu"));
                        SQLCmd.ExecuteNonQuery();
                    }
                }
                trn.Commit();
                MessageBox.Show("Đã lưu vào Sổ tay chi phí phẫu thuật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void cmdChiDinhTheoMatBenh_Click(object sender, EventArgs e)
        {
            new frmChiPhiTheoMatBenh_PT(this.fgDichVu, this.txtDoiTuong.Tag.ToString(), Global.glbMaKhoaPhong.ToString(), fgChiDinhPT.GetDataDisplay(fgChiDinhPT.Row, "TenDichVu")).ShowDialog();
            
        }

        private void fgDichVu_AfterEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            if (e.Col != fgDichVu.Cols["SoLuong"].Index) return;
            decimal SL = decimal.Parse(fgDichVu.GetData(e.Row, "SoLuong").ToString());
            decimal DonGia = decimal.Parse(fgDichVu.GetData(e.Row, "DonGia").ToString());
            fgDichVu[e.Row, "ThanhTien"] = SL * DonGia;
            fgDichVu.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.Clear, 0, 0, 0);
            fgDichVu.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.Sum, 0, 2, fgDichVu.Cols["ThanhTien"].Index, "{0}");
            for (int i = 1; i < fgDichVu.Rows.Count; i++)
            {
                if (!fgDichVu.Rows[i].IsNode)
                {
                    if ((fgDichVu.GetData(i, "DaThucHien").ToString().ToLower() == "true"))//&& fgDichVu.GetData(i, "LoaiDichVu").ToString() == "D01") && fgDichVu.GetData(i, "MaDichVu").ToString() != "DN-KH-0001")
                    {
                        fgDichVu.Rows[i].AllowEditing = false;
                    }
                    return;
                }
            }
        }

        private void sửaTỷLệBHYTToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (fgDichVu.Rows.Count <= 1) return;
            fgDichVu.StartEditing(fgDichVu.Row, fgDichVu.Cols["TyleBH"].Index);
        }

        private void txtThoiGianBD_DropDownClosed(object sender, EventArgs e)
        {
            if (fgPhauThuat.Rows.Count > 1)
            {
                System.Data.SqlClient.SqlCommand SQLCmd1 = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
                SqlDataReader dr1;
                int a = 0;
                string s = "";

                SQLCmd1.CommandText = string.Format("select Count(*) as SL from NAMDINH_QLBN.dbo.BENHNHAN_PHIEUDIEUTRI a inner join NAMDINH_QLBN.dbo.PHIEUDIEUTRI_CHITIET b on a.SoPhieu = b.SoPhieu inner join NAMDINH_QLBN.dbo.DMDICHVU_KHOA c on b.MaDichVu = c.MaDichVu where a.MaVaoVien = '{0}' and b.TyLe = 100  and c.MaKhoa = 'NV1103' and c.Madichvu != 'C14426'", txtMaVaoVien.Text);
                dr1 = SQLCmd1.ExecuteReader();
                while(dr1.Read())
                {
                    a = int.Parse(dr1["SL"].ToString());
                }
                dr1.Close();
                if (a > 1)
                {
                    s = txtThoiGianBD.Text;
                    SQLCmd1.CommandText = string.Format("set dateformat DMY select count(*) as SL from NAMDINH_QLBN.dbo.BENHNHAN_PHAUTHUAT where mavaovien = '{0}' and convert(varchar(10),ThoiGianBD,103)  = N'{1:dd/MM/yyyy}'", txtMaVaoVien.Text, DateTime.Parse(s));
                    dr1 = SQLCmd1.ExecuteReader();
                    while (dr1.Read())
                    {
                        if (int.Parse(dr1["Sl"].ToString()) >= 1)
                        {
                            MessageBox.Show("Trong cùng 1 ngày, bạn đang thanh toán 2 phẫu thuật có “Tỷ lệ TT” là 100%. Bạn xem lại, nếu trong 1 cuộc phẫu thuật:" + Environment.NewLine + "+ Phẫu thuật cao tiền nhất Tỷ lệ TT là 100" + Environment.NewLine + "+ Từ phẫu thuật thứ 2 trở đi Tỷ lệ TT  là 50 (nếu cùng 1 ekip) là 80% nếu khác ekip" + Environment.NewLine + "+ Thủ thuật Tỷ lệ TT là 80","Cảnh báo!",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        }
                    }
                    dr1.Close();
                }

            }
        }

        private void fgDichVu_BeforeEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            for (int i = 1; i < fgDichVu.Rows.Count; i++)
            {
                if (!fgDichVu.Rows[i].IsNode)
                {
                    if ((fgDichVu.GetData(i, "DaThucHien").ToString().ToLower() == "true" ))//&& fgDichVu.GetData(i, "LoaiDichVu").ToString() == "D01") && fgDichVu.GetData(i, "MaDichVu").ToString() != "DN-KH-0001")
                    {
                        fgDichVu.Rows[i].AllowEditing = false;
                    }
                    return;
                }
            }
        }

        private void fgDichVu_Click(object sender, EventArgs e)
        {
            for (int i = 1; i < fgDichVu.Rows.Count; i++)
            {
                if (!fgDichVu.Rows[i].IsNode)
                {
                    if ((fgDichVu.GetData(i, "DaThucHien").ToString().ToLower() == "true") && Global.glbUName.ToUpper() != "KHÁ PM")//&& fgDichVu.GetData(i, "LoaiDichVu").ToString() == "D01") && fgDichVu.GetData(i, "MaDichVu").ToString() != "DN-KH-0001")
                    {
                        fgDichVu.Rows[i].AllowEditing = false;
                        cmdChiDinh.Enabled = false;
                        cmdGhi.Enabled = false;
                        cmdChiDinhTheoMatBenh.Enabled = false;
                    }
                    return;
                }
            }
        }
    }
}