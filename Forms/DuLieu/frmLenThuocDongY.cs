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
    public partial class frmLenThuocDongY : Form
    {
        private string MaDoiTuongBN = "";
        private string MaNhom = "";
        private bool IsAddnew = false;
        private int LanChuyenDT = 0;
        private string str_TruyenMau = "";
        DateTime NgayKham;
        public frmLenThuocDongY()
        {
            InitializeComponent();
        }

        private void SoTienConLai()
        {
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            try
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
                    + " GROUP BY AA.SOTIEN", txtMaVaoVien.Text);
                dr = SQLCmd.ExecuteReader();
                while (dr.Read())
                {
                    lbSoTienCL.Text = String.Format("Số tiền còn lại: {0:#,##0}",dr["SoTienCL"]) + " VNĐ";
                    lbSoTienKQ.Text = String.Format("Số tiền ký quỹ: {0:#,##0}",dr["SoTienkQ"]) + " VNĐ";
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

        private void frmChiDinhDieuTri_Load(object sender, EventArgs e)
        {
            fgPhieuChiDinh.ClipSeparators = "|;";
            fgDichVu.Tree.Column = 4;
            fgDichVu.ClipSeparators = "|;";
            fgPhieuChiDinh.Cols["LoaiDT"].Visible =fgPhieuChiDinh.Cols["MaKhoa"].Visible = false;
            fgDichVu.Cols["LoaiDichVu"].Visible = fgDichVu.Cols["MaDichVu"].Visible = fgDichVu.Cols["TenLoaiDV"].Visible = false;
            fgDichVu.Cols["SoLuong"].Format = "#,##0.##";
            fgDichVu.Cols["DonGia"].Format = "#,##0.##";
            fgDichVu.Cols["SoLuongCu"].DataType = typeof(decimal);
            fgDichVu.Cols["SoLuongCu"].Format = "#,##0.##";
            for (int i = 0; i < fgDichVu.Cols.Count; i++)
            {
                if (fgDichVu.Cols[i].Name != "SoLuong" && fgDichVu.Cols[i].Name != "GhiChu" && fgDichVu.Cols[i].Name != "TyLe") fgDichVu.Cols[i].AllowEditing = false;
            }
            for (int i = 1; i < fgDichVu.Cols.Count; i++)
                if (i != 4 && i != 5 && i != 6 && i != 7 && i != 8 && i != 9 && i != 10 && i != 11 && i != 12)
                    fgDichVu.Cols[i].Visible = false;
            C1.Win.C1FlexGrid.CellStyle cs = fgDichVu.Styles[C1.Win.C1FlexGrid.CellStyleEnum.Subtotal0];
            cs.BackColor = Color.LightBlue;
            cs.ForeColor = Color.DarkBlue;
            Load_CacDM();
            Lock_Edit(true);
            fgDichVu.Cols["MaPhieuDuyet"].Visible = true;
            fgDichVu.Cols["TyleBH"].Visible = true;
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
            dr= SQLCmd.ExecuteReader();
            cmbDoiTuong.AddItem("0;----- Theo đối tượng hiện tại -----");
            while(dr.Read())
            {
                cmbDoiTuong.AddItem(String.Format("{0};{1}",dr["MaDT"],dr["TenDT"]));
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

            SQLCmd.CommandText = "Select * from dmbacsy where SoChungChiHanhNghe is not null and SoChungChiHanhNghe <> '' and Khongsudung = 0 and MaChucVu <=5 and MaChucVu <> '' and  makhoa  in " + Global.glbKhoa_CapNhat;
            dr = SQLCmd.ExecuteReader();
            cmbBacSyDT.ClearItems();
            while (dr.Read())
            {
                cmbBacSyDT.AddItem(String.Format("{0};{1}", dr["MaBS"], dr["TenBS"]));
            }
            dr.Close();
            SQLCmd.CommandText = "select Madichvu from DMDICHVU where tendichvu like N'%Viện HHTMTW%' and DongiaBHYT > 0";
            dr = SQLCmd.ExecuteReader();
            while (dr.Read())
            {
                str_TruyenMau += dr["Madichvu"] + "; ";
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

            cmbNhomMau.AddItem("0;Chưa xác định");
            cmbNhomMau.AddItem("1;A");
            cmbNhomMau.AddItem("2;AB");
            cmbNhomMau.AddItem("3;B");
            cmbNhomMau.AddItem("4;O");
            SQLCmd.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int covid = 0;
            if (cmbKhoa.SelectedIndex == -1)
            {
                MessageBox.Show("Chưa chọn khoa điều trị!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbKhoa.Focus();
                return;
            }
            NamDinh_QLBN.Forms.DuLieu.frmShowDSBenhNhan fr = new frmShowDSBenhNhan("", Global.GetCode(cmbKhoa), "", 1, 0,MaNhom, covid);
            fr.ShowDialog();
            if (fr.DialogResult == DialogResult.OK)
            {
                txtMaBenhAn.Text = fr.SoHSBAReturn;
                txtMaVaoVien.Text = fr.MaVaoVienReturn;
                txtHoTen.Text = fr.HoTenReturn;
                txtTuoi.Text = fr.TuoiReturn;
                txtGioi.Text = fr.GioiReturn;
                txtDoiTuong.Text = fr.TenDoiTuongReturn;
                txtNgayVaoVien.Text = fr.NgayVaoVienReturn;
                MaDoiTuongBN = fr.MaDoiTuongReturn;
                NgayKham = fr.NgayKhamReturn;
                MaNhom = fr.MaNhom;
                cmbBacSyDT.SelectedIndex = cmbBacSyDT.FindStringExact("0" + fr.MabacSY, 0, 0);
                Load_PhieuChiDinh(txtMaVaoVien.Text);
                LanChuyenDT = Global.GetLanChuyenDTHT(txtMaVaoVien.Text);
                lblBuong.Text = fr.TenBuongReturn;lblGiuong.Text = fr.TenGiuongReturn;lblMaGiuongYT.Text = fr.MaGiuongYTReturn;
            }
        }
        private void Load_PhieuChiDinh(string MaVaoVien)
        {
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("",Global.ConnectSQL);
            SQLCmd.CommandText = "Set dateformat mdy SELECT SoPhieu, a.NgayChiDinh, LoaiDT, BacSyDT, DienBienBenh, YLenh, CDChamSoc, CDDinhDuong,b.MaKhoa,tenKhoa,Nhom,a.Chandoan,isnull(CapCuu,0) as CapCuu ,case when a.Nhom = 0 then N'Trong ngày' else N'Bất thường' end as Nhom1 ,NhomMau,SoThang,ChuThich,USerName1 FROM BENHNHAN_PHIEUDIEUTRI a INNER JOIN DMKHOAPHONG b ON a.MaKhoa=b.MaKhoa "
                + " inner join viewkhoahientai on viewkhoahientai.mavaovien = a.mavaovien "
                + " left join dmbacsy on dmbacsy.makhoa = a.makhoa and dmbacsy.mabs = a.mabs "
                + " WHERE a.MaVaoVien='" + MaVaoVien + "' order by NgayChiDinh";
            System.Data.SqlClient.SqlDataReader dr = SQLCmd.ExecuteReader();
            fgPhieuChiDinh.Tag = "0";
            fgPhieuChiDinh.Rows.Count = 1;
            while (dr.Read())
            {
                fgPhieuChiDinh.AddItem(string.Format("{0}|{1}|{2:dd/MM/yyyy HH:mm}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}|{12}|{13}|{14}|{15}|{16}|{17}|{18}|", 
                    fgPhieuChiDinh.Rows.Count, 
                    dr["SoPhieu"], 
                    dr["NgayChiDinh"], 
                    dr["LoaiDT"], 
                    dr["BacSyDT"], 
                    dr["DienBienBenh"], 
                    dr["YLenh"], 
                    dr["CDChamSoc"], 
                    dr["CDDinhDuong"],
                    dr["MaKhoa"],
                    dr["tenKhoa"],
                    dr["Nhom"],
                    dr["Chandoan"],
                    dr["CapCuu"],
                    dr["Nhom1"],
                    dr["NhomMau"],
                    dr["SoThang"],
                    dr["ChuThich"],
                    dr["USerName1"]));
            }
            fgPhieuChiDinh.Row = 0;
            //fgPhieuChiDinh.AutoSizeCols(1);
            Empty_Data();
            //fgPhieuChiDinh.AutoSizeCols();
            fgPhieuChiDinh.Tag = "1";
            //fgPhieuChiDinh.AutoSizeCols();
            dr.Close();
            SQLCmd.Dispose();
            SoTienConLai();
        }

        private void cmdThoat_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
        private void Lock_Edit(bool IsLocked)
        {
            this.cmdThuThuat.Visible = cmdTichKe.Visible = cmdKetQuaXN.Visible = cmdMau.Visible = cmdDonThuoc.Visible = cmdKhamChuyenKhoa.Visible = cmdThem.Visible = cmdSua.Visible = cmdXoa.Visible = cmdThoat.Visible = cmdInPhieu.Visible = IsLocked;
            cmdChiDinhTheoMatBenh.Visible = cmdGhi.Visible = cmdHuy.Visible = cmdChiDinh.Visible = cmdCopy.Visible = !IsLocked;
            cmdDanhSachBN.Enabled = IsLocked;
            raChiPhiHN.Enabled = raChiPhiTT.Enabled = IsLocked;
            chCapCuu.Enabled = IsLocked;
            fgPhieuChiDinh.Enabled = IsLocked;
            fgDichVu.Cols["SoLuong"].AllowEditing = !IsLocked;
            fgDichVu.Cols["KhongTinhPhi"].AllowEditing = !IsLocked;
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
            txtChuThich.ReadOnly = cmbNhomMau.ReadOnly = cmbBacSyDT.ReadOnly = txtDienBienBenh.ReadOnly = txtYLenh.ReadOnly = cmbDoiTuong.ReadOnly =txtChanDoan.ReadOnly= IsLocked;
            txtSoThang.Enabled = !IsLocked;
        }
        private void Empty_Data()
        {
            txtNgayChiDinh.Value = null;
            cmbCheDoChamSoc.SelectedIndex = cmbCheDoDinhDuong.SelectedIndex = -1;
            txtDienBienBenh.Text = txtYLenh.Text = txtChanDoan.Text = "";
            fgDichVu.Rows.Count = 1;
            cmbDieuduong.SelectedIndex = -1;
        }
        private void cmdThem_Click(object sender, EventArgs e)
        {
            if (txtMaVaoVien.Text == "") return;
            if (raChiPhiHN.Checked == false && raChiPhiTT.Checked == false)
            {
                MessageBox.Show("Chọn lên chí phí trong ngày hay trong trực.", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            IsAddnew = true;
            Lock_Edit(false);
            Empty_Data();
            txtNgayChiDinh.Value = Global.NgayLV;
            lblKhoa.Text = cmbKhoa.Text;
            cmbDoiTuong.SelectedIndex = 0; 
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
            System.Data.SqlClient.SqlDataReader dr;
            cmd.CommandText = String.Format("select v.chandoan,c.CDChamSoc from viewkhoahientai v"
                + " left join benhnhan_phieudieutri c on c.mavaovien = v.mavaovien and right(c.sophieu,10) = "
                + " (select max(right(sophieu,10)) from benhnhan_phieudieutri where mavaovien = v.mavaovien)"
                + " where v.mavaovien = '{0}'", txtMaVaoVien.Text);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                txtChanDoan.Text = dr["ChanDoan"].ToString();
                cmbCheDoChamSoc.SelectedIndex = cmbCheDoChamSoc.FindStringExact(dr["CDChamSoc"].ToString(), 0, 0);
            }
            dr.Close();
            cmd.Dispose();
            txtSoThang.Value = 1;
        }

        private void cmdHuy_Click(object sender, EventArgs e)
        {
            Lock_Edit(true);
            if (fgPhieuChiDinh.Row < 1) Empty_Data(); else Load_PhieuDieutri_ChiTiet(fgPhieuChiDinh.Row);
        }

        private void cmdGhi_Click(object sender, EventArgs e)
        {
            if (this.cmbBacSyDT.SelectedIndex == -1)
            {
                MessageBox.Show("Chưa nhập bác sĩ điều trị.\nĐề nghị nhập lại!", "Th\x00f4ng b\x00e1o", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                this.cmbBacSyDT.Focus();
                return;
            }
            if (txtNgayChiDinh.ValueIsDbNull)
            {
                MessageBox.Show("Chưa nhập ngày giờ.\nĐề nghị nhập lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNgayChiDinh.Focus();
                return;
            }
            if (cmbDoiTuong.SelectedIndex == -1)
            {
                MessageBox.Show("Chọn đối tượng tính phí!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDoiTuong.Focus();
                return;
            }
            if (cmbCheDoChamSoc.SelectedIndex == -1)
            {
                MessageBox.Show("Chọn chế độ chăm sóc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbCheDoChamSoc.Focus();
                return;
            }
            // SON THEM
            for (int i = 1; i < fgDichVu.Rows.Count; i++)
            {
                if (fgDichVu.GetDataDisplay(i, "MaDichVu") == "C56011" && fgDichVu.GetDataDisplay(i, "GhiChu").Trim() == "")
                {
                    MessageBox.Show("Phải nhập bộ phận cần sinh thiết vào phần ghi chú của chỉ định: " + Environment.NewLine + fgDichVu.GetDataDisplay(i, "TenDichVu"), "Thông báo", MessageBoxButtons.OK);
                    return;
                }
            }
            //Kiểm tra vấn đề truyền máu xem đúng = nhau giữa số lượng đơn vị máu và đơn vị vận chuyển chưa
            for (int i = 2; i < this.fgDichVu.Rows.Count; i++)
            {
                if ((str_TruyenMau.Contains((string)this.fgDichVu.GetDataDisplay(i, "MaDichVu"))) && !fgDichVu.Rows[i].IsNode)
                {
                    //Có truyền máu viện HHTMTW
                    //MessageBox.Show( fgDichVu.GetDataDisplay(2, "SoLuong"));
                    //MessageBox.Show(fgDichVu.GetDataDisplay(3, "SoLuong"));
                    if (fgDichVu.GetDataDisplay(2, "SoLuong") != fgDichVu.GetDataDisplay(3, "SoLuong"))
                    {
                        MessageBox.Show("Số lượng đơn vị vận chuyển phải bằng số lượng đơn vị máu!", "Thông báo!");
                        return;
                    }
                }
                int OK = 0;
                if (!fgDichVu.Rows[i].IsNode)
                {
                    if (int.TryParse(fgDichVu.GetDataDisplay(i, "SoLuong"), out OK))
                    { }
                    if (OK == 0 && fgDichVu.GetData(i, "LoaiDichVu").ToString().Substring(0, 1) == "C" && fgDichVu.GetData(i, "TenDichVu").ToString().ToLower().IndexOf("thông khí") < 0)
                    {
                        MessageBox.Show("Số lượng dịch vụ phải là số tự nhiên >= 1!", "Thông báo!");
                        return;
                    }
                }
            }
            // Het
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
            System.Data.SqlClient.SqlTransaction trn = Global.ConnectSQL.BeginTransaction();
            SQLCmd.Transaction = trn;
            String SoPhieu = lblSoPhieu.Text;
            try
            {
                if (IsAddnew)
                {
                    SQLCmd.CommandText = string.Format("select dbo.LaySoPhieu(Right(Convert(nvarchar(8),'{0:yyyyMMdd}',112),6)) As SoPhieu", txtNgayChiDinh.Value);
                    SoPhieu = SQLCmd.ExecuteScalar().ToString();
                    SQLCmd.CommandText = string.Format("INSERT INTO BENHNHAN_PHIEUDIEUTRI "
                        + " (SoPhieu,MaVaovien,NgayChiDinh,LoaiDT,bacSyDT,DienBienBenh,YLenh,CDChamSoc,CDDinhDuong,MaKhoa,Nhom,ChanDoan,CapCuu,MaBS,NhomMau,SoThang,ChuThich,USerName1,MaGiuongYT)"
                        + " VALUES ('{0}','{1}','{2:MM/dd/yyyy HH:mm}',{3},N'{4}',N'{5}',N'{6}',{7},{8},'{9}',{10},N'{11}',{12},{13},{14},{15},N'{16}','{17}',N'{18}')",
                            SoPhieu, txtMaVaoVien.Text, txtNgayChiDinh.Value,
                            "null",
                            cmbBacSyDT.Columns[1].CellText(cmbBacSyDT.SelectedIndex), txtDienBienBenh.Text, txtYLenh.Text,
                            (cmbCheDoChamSoc.SelectedIndex == -1) ? ("null") : (Global.GetCode(cmbCheDoChamSoc)),
                            (cmbCheDoDinhDuong.SelectedIndex == -1) ? ("null") : (Global.GetCode(cmbCheDoDinhDuong)),
                            Global.GetCode(cmbKhoa),
                            raChiPhiTT.Checked == true ? 1 : 0,
                            txtChanDoan.Text.Trim(),
                            chCapCuu.Checked == true ? 1:0,
                            Global.GetCode(cmbBacSyDT) == null ? "null" : Global.GetCode(cmbBacSyDT),
                            cmbNhomMau.SelectedIndex,
                            txtSoThang.Value,txtChuThich.Text.Trim(),
                            Global.glbUName,lblMaGiuongYT.Text);
                }
                else
                {
                    SQLCmd.CommandText = string.Format("UPDATE BENHNHAN_PHIEUDIEUTRI SET NgayChiDinh='{1:MM/dd/yyyy HH:mm}',LoaiDT={2},bacSyDT=N'{3}',DienBienBenh=N'{4}',YLenh=N'{5}',CDChamSoc={6},CDDinhDuong={7},ChanDoan=N'{8}',CapCuu ={9},MaBS={10},NhomMau={11},SoThang={12},ChuThich=N'{13}',MaGiuongYT=N'{14}' WHERE SoPhieu ='{0}'",
                            SoPhieu, txtNgayChiDinh.Value,
                            "null",
                            cmbBacSyDT.Columns[1].CellText(cmbBacSyDT.SelectedIndex), txtDienBienBenh.Text, txtYLenh.Text,
                            (cmbCheDoChamSoc.SelectedIndex == -1) ? ("null") : (Global.GetCode(cmbCheDoChamSoc)),
                            (cmbCheDoDinhDuong.SelectedIndex == -1) ? ("null") : (Global.GetCode(cmbCheDoDinhDuong)),
                            txtChanDoan.Text.Trim(), chCapCuu.Checked == true ? 1 : 0,
                            Global.GetCode(cmbBacSyDT) == null ? "null" : Global.GetCode(cmbBacSyDT),
                            cmbNhomMau.SelectedIndex,txtSoThang.Value,txtChuThich.Text.Trim(),lblMaGiuongYT.Text);
                }
                SQLCmd.ExecuteNonQuery();
                SQLCmd.CommandText = string.Format(" DELETE FROM PHIEUDIEUTRI_CHITIET WHERE SoPhieu='{0}'", SoPhieu);
                SQLCmd.ExecuteNonQuery();
                double DonGia, SoLuong,SoLuongHT,SoLuongDuyet, TyLe;
                int LanChuyenHT;
                for (int i = 1; i < fgDichVu.Rows.Count; i++)
                {
                    if (!fgDichVu.Rows[i].IsNode)
                    {
                        string MaphieuCQ = "";
                        DonGia = fgDichVu[i, "DonGia"].ToString() == "" ? 0 : double.Parse(fgDichVu[i, "DonGia"].ToString());
                        SoLuong = double.Parse(fgDichVu[i, "SoLuong"].ToString());
                        TyLe = int.Parse(this.fgDichVu[i, "TyLe"].ToString());
                        if (TyLe == 0) TyLe = 100;
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
                        SQLCmd.CommandText += string.Format(" INSERT INTO PHIEUDIEUTRI_CHITIET (SoPhieu,LoaiDichVu,MaDichVu,SoLuong,DonGia,GhiChu,DoiTuongBN,DaThucHien,TinhPhi,UserName,ChonDT,DuyetBHYT,MaNhom,KhoID,MaPhieuDuyet,DaDuyet,DaThanhToan,LanInTT,Chot,NgayChot,SoLuongHT,SoLuongDuyet,LanChuyenDT,TyLe,MaPhieuCanQuang,TTThau,TyLeBHYT,MaKhoaThucHien)"
                            + " VALUES ('{0}','{1}','{2}',{3:#,##0.##},{4:#,##0.##},N'{5}','{6}',{7},{8},N'{9}',{10},{11},{12},{13},'{14}',{15},{16},{17},{18},{19},{20},{21},{22},{23},'{24}','{25}','{26}','{27}')",
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
                                                     MaNhom,
                                                     fgDichVu.GetDataDisplay(i, "KhoID") == "" ? "null" : fgDichVu[i, "KhoID"].ToString(),
                                                     fgDichVu.GetDataDisplay(i, "MaPhieuDuyet"),
                                                     fgDichVu.GetDataDisplay(i, "DaDuyet").ToString() == "" ? "0" : fgDichVu.GetDataDisplay(i, "DaDuyet"),
                                                     fgDichVu.GetDataDisplay(i, "DaThanhToan").ToString() == "" ? "0" : fgDichVu.GetDataDisplay(i, "DaThanhToan"),
                                                     fgDichVu.GetDataDisplay(i, "LanInTT").ToString() == "" ? "null" : fgDichVu.GetDataDisplay(i, "LanInTT"),
                                                     fgDichVu.GetDataDisplay(i, "Chot").ToString() == "" ? "0" : fgDichVu.GetDataDisplay(i, "Chot"),
                                                     fgDichVu.GetDataDisplay(i, "NgayChot").ToString() == "" ? "null" : String.Format("'{0:MM/dd/yyyy}'", fgDichVu.GetData(i, "NgayChot")),
                                                     //"null",
                                                     SoLuongHT.ToString().Replace(",","."),
                                                     SoLuong.ToString().Replace(",","."),LanChuyenHT,TyLe, 
                                                     MaphieuCQ, fgDichVu.GetDataDisplay(i, "TTThau").ToString(), fgDichVu.GetDataDisplay(i, "TyleBH"), fgDichVu.GetDataDisplay(i, "MaKhoaThucHien"));


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
                                + " where makhoa='{0}'  and mathuoc ='{1}'", Global.GetCode(cmbKhoa), fgDichVu[i, "MaDichVu"], fgDichVu[i, "SoLuong"].ToString().Replace(",","."));
                         }
                         else
                         {
                             SQLCmd.CommandText += String.Format(" (select SoLuongDSD + {2} - {3} from benhnhan_travo where makhoa='{0}' and mathuoc ='{1}')"
                                + " where makhoa='{0}' and mathuoc ='{1}'", Global.GetCode(cmbKhoa), fgDichVu[i, "MaDichVu"], fgDichVu[i, "SoLuong"].ToString().Replace(".", "").Replace(",", "."), fgDichVu[i, "SoLuongCu"].ToString().Replace(".", "").Replace(",", "."));
                         }
                        SQLCmd.CommandText += String.Format(" end"
                                + " else"
                                + " begin"
                                + " insert into benhnhan_travo(makhoa,mathuoc,soluongdsd,soluongdt)"
                                + " values('{0}','{1}',{2},0)"
                                + " end end", Global.GetCode(cmbKhoa),fgDichVu[i, "MaDichVu"], fgDichVu[i, "SoLuong"].ToString().Replace(",","."));
                    }
                }
                SQLCmd.ExecuteNonQuery();
                trn.Commit();
                if (IsAddnew)
                {
                    fgPhieuChiDinh.Tag = "0";
                    fgPhieuChiDinh.AddItem(string.Format("|||||||||{0}|{1}",Global.GetCode(cmbKhoa),cmbKhoa.Text));                    
                    fgPhieuChiDinh.Row = fgPhieuChiDinh.Rows.Count - 1;
                    fgPhieuChiDinh.Tag = "1";
                }
                
                fgPhieuChiDinh[fgPhieuChiDinh.Row, 0] = fgPhieuChiDinh.Rows.Count - 1;
                fgPhieuChiDinh[fgPhieuChiDinh.Row, 1] = SoPhieu;
                fgPhieuChiDinh[fgPhieuChiDinh.Row, 2] = string.Format("{0:dd/MM/yyyy HH:mm}", txtNgayChiDinh.Value);
                fgPhieuChiDinh[fgPhieuChiDinh.Row, 3] ="";
                fgPhieuChiDinh[fgPhieuChiDinh.Row, 4] = cmbBacSyDT.Columns[1].CellText(cmbBacSyDT.SelectedIndex);
                fgPhieuChiDinh[fgPhieuChiDinh.Row, 5] = txtDienBienBenh.Text;
                fgPhieuChiDinh[fgPhieuChiDinh.Row, 6] = txtYLenh.Text;
                fgPhieuChiDinh[fgPhieuChiDinh.Row, 7] =(cmbCheDoChamSoc.SelectedIndex==-1)?(""):(Global.GetCode(cmbCheDoChamSoc));
                fgPhieuChiDinh[fgPhieuChiDinh.Row, 8] =(cmbCheDoDinhDuong.SelectedIndex ==-1)?(""):(Global.GetCode(cmbCheDoDinhDuong));
                fgPhieuChiDinh[fgPhieuChiDinh.Row, 11] = raChiPhiTT.Checked == true ? 1 : 0;
                fgPhieuChiDinh[fgPhieuChiDinh.Row, 13] = chCapCuu.Checked == true ? 1 : 0;
                fgPhieuChiDinh[fgPhieuChiDinh.Row, 14] = raChiPhiHN.Checked == true ? "Trong ngày" : "Bất thường";
                fgPhieuChiDinh[fgPhieuChiDinh.Row, 15] = chCapCuu.Checked == true ? 1 : 0;
                fgPhieuChiDinh[fgPhieuChiDinh.Row, 16] = cmbNhomMau.SelectedIndex;
                fgPhieuChiDinh[fgPhieuChiDinh.Row, "SoThang"] = txtSoThang.Value;
                fgPhieuChiDinh[fgPhieuChiDinh.Row, "ChanDoan"] = txtChanDoan.Text.Trim();
                fgPhieuChiDinh[fgPhieuChiDinh.Row, "ChuThich"] = txtChuThich.Text.Trim();
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
                lblKhoa.Text = fgPhieuChiDinh[r, "TenKhoa"] == null ? "" : fgPhieuChiDinh[r, "TenKhoa"].ToString();
                cmbNhomMau.SelectedIndex = int.Parse(fgPhieuChiDinh[r, "NhomMau"].ToString());
                txtSoThang.Value = fgPhieuChiDinh.GetDataDisplay(r, "SoThang") == "-1" ? 0: int.Parse(fgPhieuChiDinh.GetDataDisplay(r, "SoThang"));
                txtChuThich.Text = fgPhieuChiDinh[r, "ChuThich"] == null ? "" : fgPhieuChiDinh[r, "ChuThich"].ToString();
                if (Global.GetCode(cmbKhoa) != fgPhieuChiDinh[r, "MaKhoa"].ToString())
                {
                    cmdSua.Enabled = false;
                    cmdXoa.Enabled = false;
                }
                else
                {
                    cmdSua.Enabled = true;
                    cmdXoa.Enabled = true;
                }
                if (Global.glbUName.ToLower() != fgPhieuChiDinh[r, "USerName1"].ToString().ToLower())
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
                SQLCmd.CommandText = string.Format("SELECT a.ChonDT,a.LoaiDichVu,TenLoaiDichVu,a.MaDichVu,a.TinhPhi,a.DaThucHien,TenDichVu,DVT,SoLuong,a.TyLe,a.DonGia,SoLuong*a.DonGia*a.TyLe/100 as ThanhTien,a.GhiChu,a.DuyetBHYT,a.KhoID,a.MaPhieuDuyet,a.DaDuyet,a.DaThanhToan,a.LanInTT,a.Chot,a.NgayChot,SoLuongHT,SoLuongDuyet,LanChuyenDT,MaPhieuCanQuang,a.TTThau,isnull(a.TyLeBHYT,c.TyLeBH) as TyLeBH,a.MaKhoaThucHien FROM "
                                    + " (PHIEUDIEUTRI_CHITIET a INNER JOIN DMLOAIDICHVU b ON a.LoaiDichVu=b.MaLoaiDichVu) "
                                    + " INNER JOIN DMDICHVU c ON a.LoaiDichVu=c.LoaiDichVu AND a.MaDichVu=c.MaDichVu WHERE SoPhieu='{0}' Order By a.LoaiDichVu,TenDichVu", SoPhieu);
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
                    fgDichVu[row, "KhongTinhPhi"] = dr["TinhPhi"];
                    fgDichVu[row, "LuotIn"] = dr["DuyetBHYT"].ToString();
                    fgDichVu[row, "SoLuongCu"] = dr["SoLuong"];
                    // SON SUA
                    fgDichVu[row, "SoLuongHT"] = dr["SoLuongHT"];
                    fgDichVu[row, "SoLuongDuyet"] = dr["SoLuongDuyet"];
                    // HET
                    fgDichVu[row, "KhoID"] = dr["KhoID"];
                    fgDichVu[row, "MaPhieuDuyet"] = dr["MaPhieuDuyet"];
                    fgDichVu[row, "DaDuyet"] = dr["DaDuyet"];
                    fgDichVu[row, "DaThanhToan"] = dr["DaThanhToan"];
                    fgDichVu[row, "LanInTT"] = dr["LanInTT"];
                    fgDichVu[row, "Chot"] = dr["Chot"];
                    fgDichVu[row, "NgayChot"] = dr["NgayChot"];
                    fgDichVu[row, "LanChuyenDT"] = dr["LanChuyenDT"];
                    fgDichVu[row, "Chot"] = dr["Chot"];
                    fgDichVu[row, "NgayChot"] = dr["NgayChot"];
                    fgDichVu[row, "MaPhieuCanQuang"] = dr["MaPhieuCanQuang"];
                    fgDichVu[row, "TTThau"] = dr["TTThau"];
                    fgDichVu[row, "TyleBH"] = dr["TyleBH"];
                    cmbDoiTuong.SelectedIndex = cmbDoiTuong.FindStringExact(dr["ChonDT"].ToString(), 0, 0);
                    fgDichVu[row, "MaKhoaThucHien"] = dr["MaKhoaThucHien"];
                    row++;
                }
                Format_Grid();
                fgDichVu.Redraw = true;
                dr.Close();
                SQLCmd.Dispose();
            }
            catch(Exception ex)
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
        private void fgPhieuChiDinh_AfterSelChange(object sender, C1.Win.C1FlexGrid.RangeEventArgs e)
        {
            cmdThuThuat.Enabled = false;
        }

        private void cmdSua_Click(object sender, EventArgs e)
        {
            if (lblSoPhieu.Text == "0") return;
            if (raChiPhiHN.Checked == false && raChiPhiTT.Checked == false)
            {
                MessageBox.Show("Chọn lên chí phí trong ngày hay trong trực.", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (fgPhieuChiDinh.GetDataDisplay(fgPhieuChiDinh.Row, "Nhom").ToLower() == "0")
            {
                if (raChiPhiHN.Checked == false)
                {
                    MessageBox.Show("Phiếu này được lên điều trị trong ngày.\nKhông thể thêm chi phí trong trực vào.", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else
            {
                if (raChiPhiHN.Checked == true)
                {
                    MessageBox.Show("Phiếu này được lên trong trực.\nKhông thể thêm chi phí trong ngày vào.", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            if (fgPhieuChiDinh.GetDataDisplay(fgPhieuChiDinh.Row, "MaKhoa") != Global.GetCode(cmbKhoa))
            {
                MessageBox.Show("Phiếu này được lập bởi khoa khác.\nBạn không thể sửa.","Thông báo.",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            Lock_Edit(false);
            IsAddnew = false;
        }

        private void cmdChiDinh_Click(object sender, EventArgs e)
        {
            //NamDinh_QLBN.Forms.DuLieu.frmNhapChiDinhChiPhi fr = new frmNhapChiDinhChiPhi(fgDichVu, MaDoiTuongBN, Global.GetCode(cmbKhoa), DateTime.Parse(txtNgayVaoVien.Text));   
            NamDinh_QLBN.Forms.DuLieu.frmNhapChiDinhChiPhi fr = new frmNhapChiDinhChiPhi(fgDichVu, MaDoiTuongBN, Global.GetCode(cmbKhoa), NgayKham);
            fr.ShowDialog();
        }

        private void fgDichVu_AfterDeleteRow(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            Format_Grid();
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

        private void fgDichVu_AfterEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            if (e.Col != fgDichVu.Cols["SoLuong"].Index && e.Col != fgDichVu.Cols["TyLe"].Index) return;
            decimal SL = decimal.Parse(fgDichVu.GetData(e.Row, "SoLuong").ToString());
            decimal DonGia = decimal.Parse(fgDichVu.GetData(e.Row, "DonGia").ToString());
            decimal TyLe = decimal.Parse(fgDichVu.GetData(e.Row, "TyLe").ToString());
            if (TyLe == 0) TyLe = 100;
            fgDichVu[e.Row, "ThanhTien"] = SL * DonGia*TyLe/100;
            fgDichVu.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.Clear, 0, 0, 0);
            fgDichVu.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.Sum, 0, 2, fgDichVu.Cols["ThanhTien"].Index, "{0}");
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
                if (MessageBox.Show("Đã có thuốc trong Phiếu điều trị, nếu copy đơn thuốc sẽ xóa hết thuốc đã có trong phiếu.\nBạn có chắc muốn copy không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
                
            }

            fgDichVu.Redraw = false;
            if (DaCoThuoc)
                fgDichVu.Rows.Count = 1;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
            SQLCmd.CommandText = "SELECT a.TyLe, a.LoaiDichVu,c.TenLoaiDichVu,a.MaDichVu,d.TenDichVu,d.DVT,a.SoLuong,a.GhiChu,a.TinhPhi,";
            if (MaDoiTuongBN == "1") SQLCmd.CommandText += "isNull(d.DonGiaBHYT,0) As DonGia,isNull(a.SoLuong*d.DonGiaBHYT*a.TyLe/100,0) As ThanhTien,d.KhoID,isnull(a.TyLeBHYT,d.TyLeBHYT) as TyleBH,a.TTThau ";
            else SQLCmd.CommandText += "isNull(d.DonGia,0) As DonGia,isNull(a.SoLuong*d.DonGia*a.TyLe/100,0) As ThanhTien,d.KhoID,isnull(a.TyLeBHYT,d.TyLeBHYT) as TyleBH, a.TTThau ";
            SQLCmd.CommandText += string.Format(" FROM ((PHIEUDIEUTRI_CHITIET a INNER JOIN BENHNHAN_PHIEUDIEUTRI b ON a.SoPhieu=b.SoPhieu)"
                               + " INNER JOIN DMLOAIDICHVU c ON a.LoaiDichVu=c.MaLoaiDichVu)"
                               + " INNER JOIN DMLENCHIPHI_BYKHOID d ON a.MaDichVu=d.maDichVu AND a.LoaiDichVu=d.LoaiDichVu and d.khongsudung = 0 ");
            if (IsAddnew)
            {
                SQLCmd.CommandText += String.Format(" where a.sophieu = '{0}' AND a.LoaiDichVu in ('D05','D02','B01','B02','D01','D06')", lblSoPhieu.Text); 
            }
            else
            {
                SQLCmd.CommandText += String.Format( " WHERE a.SoPhieu = (SELECT max(SoPhieu) FROM BENHNHAN_PHIEUDIEUTRI WHERE  MaVaoVien='{0}' and SoPhieu <> '{1}')"
                                + " AND a.LoaiDichVu in ('D05','D02','B01','B02','D06') ", txtMaVaoVien.Text, lblSoPhieu.Text);
            }

            SQLCmd.CommandText += " Group by a.LoaiDichVu,c.TenLoaiDichVu,a.MaDIchVu,d.TenDichVu,d.DVT,a.TinhPhi,"
                                + " a.SoLuong,a.GhiChu,d.DonGia,d.DonGiaBHYT,d.KhoID,a.TyLe,d.TyLeBHYT,a.TyLeBHYT,a.TTThau Order By a.LoaiDichVu,TenDichVu";
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
                    0,dr["KhoID"], dr["TyleBH"], dr["TTThau"] ));
            }
            Format_Grid();
            fgDichVu.Redraw = true;
            dr.Close();
            SQLCmd.Dispose();
        }
        private void cmdCopy_Click(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
            //Kiem tra xem da in chua
            SQLCmd.CommandText = String.Format("Select Is_In from BenhNHan_PhieuDieutri where sophieu='{0}'", lblSoPhieu.Text.Trim());
            if (SQLCmd.ExecuteScalar().ToString() == "1")
            {
                MessageBox.Show("Phiếu này đã được in. Bạn không thể copy đè lên!.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Copy();
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
            SQLCmd.CommandText = String.Format("Select Is_In from BenhNHan_PhieuDieutri where sophieu='{0}'", lblSoPhieu.Text.Trim());
            if (SQLCmd.ExecuteScalar().ToString() == "1")
            {
                MessageBox.Show("Phiếu này đã được in. Bạn không thể xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
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
                SQLCmd.CommandText = string.Format("DELETE FROM BENHNHAN_PHIEUDIEUTRI WHERE SoPhieu='{0}' AND MaVaoVien='{1}'", lblSoPhieu.Text,txtMaVaoVien.Text);
                SQLCmd.ExecuteNonQuery();
                trn.Commit();
                fgPhieuChiDinh.RemoveItem(fgPhieuChiDinh.Row);
                if (fgPhieuChiDinh.Rows.Count == 1) Empty_Data();
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
                    SQLCmd.CommandText += String.Format(" if(exists(select * from dstravo where makhoa='{0}' and mathuoc = '{1}')) "
                           + " begin if(exists(select * from benhnhan_travo inner join dstravo on dstravo.makhoa = "
                           + " benhnhan_travo.makhoa and dstravo.makhoa ='{0}' "
                           + "	where benhnhan_travo.makhoa='{0}' and benhnhan_travo.mathuoc='{1}'))"
                           + " begin"
                           + " update benhnhan_travo set soluongdsd = ", Global.GetCode(cmbKhoa), fgDichVu[fgDichVu.Row, "MaDichVu"]);

                    SQLCmd.CommandText += String.Format(" (select SoLuongDSD - {2} from benhnhan_travo where makhoa='{0}' and mathuoc ='{1}')"
                           + " where makhoa='{0}' and mathuoc ='{1}'",
                           Global.GetCode(cmbKhoa),
                           fgDichVu[fgDichVu.Row, "MaDichVu"],
                           fgDichVu[fgDichVu.Row, "SoLuongCu"].ToString().Replace(",","."));
                    SQLCmd.CommandText += String.Format(" end end");
                    SQLCmd.ExecuteNonQuery();
                    trn.Commit();
                }
            }
            catch(Exception ex)
            {
                trn.Rollback();
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                SQLCmd.Dispose();
            }
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

        private void mnuDichVu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void mnuXoa_Click(object sender, EventArgs e)
        {
            if (fgDichVu.Rows.Count <= 1) return;
            if (!AllowEditDele())
            {
                MessageBox.Show("Đã thực hiện. Không thể thay đổi.", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không.", "Thông báo.", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                TruLaiSoVo();
                fgDichVu.RemoveItem(fgDichVu.Row);
                Format_Grid();
            }
        }

        private void mnuSua_Click(object sender, EventArgs e)
        {
            if (fgDichVu.Rows.Count <= 1) return;
            if (!AllowEditDele())
            {
                MessageBox.Show("Đã thực hiện. Không thể thay đổi.", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            fgDichVu.StartEditing(fgDichVu.Row,  fgDichVu.Cols["SoLuong"].Index);
        }
        private bool AllowEditDele()
        {
            bool Flag = true;
            if ((this.fgDichVu.Cols[this.fgDichVu.Col].Index == this.fgDichVu.Cols["TyLe"].Index))
            {
                Flag = true;
            }
            if (fgDichVu.Cols[fgDichVu.Col].Index == fgDichVu.Cols["KhongTinhPhi"].Index || fgDichVu.GetDataDisplay(fgDichVu.Row, "LoaiDichVu") == "D06")
            {
                Flag = true;
            }
            else
            {
                if (fgDichVu.GetDataDisplay(fgDichVu.Row, "DaThucHien").ToLower() == "true")
                {
                    Flag = false;
                }
                else
                    if (fgDichVu.GetDataDisplay(fgDichVu.Row, "LuotIn").ToLower() == "1")
                        Flag = false;
            }
            return Flag;
        }

        private void mnuThem_Click(object sender, EventArgs e)
        {
            cmdChiDinh_Click(sender,e);
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
                NamDinh_QLBN.Reports.repPhieuChiDinh_ketquaA5 rep = new NamDinh_QLBN.Reports.repPhieuChiDinh_ketquaA5(txtHoTen.Text.Trim(),
                    int.Parse(txtTuoi.Text.Trim()), txtGioi.Text, txtChanDoan.Text.Trim(), cmbKhoa.Text, 
                    int.Parse(fgPhieuChiDinh.GetDataDisplay(fgPhieuChiDinh.Row,"Nhom")),lblSoPhieu.Text.Trim(),txtNgayChiDinh.Value,cmbDieuduong.Text);
                rep.Show();
                //Bat truong hop da in khong duoc xoa
                System.Data.SqlClient.SqlCommand Cmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
                Cmd.CommandText = String.Format("Update benhnhan_phieudieutri set Is_In = 1 where sophieu ='{0}'", lblSoPhieu.Text);
                Cmd.ExecuteNonQuery();
                Cmd.Dispose();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
            }
        }

        private void frmChiDinhDieuTri_KeyDown(object sender, KeyEventArgs e)
        {
            int covid = 0;
            
            if (e.KeyCode == Keys.F5)
            {
                if (cmdDanhSachBN.Enabled == false) return;
                if (cmbKhoa.SelectedIndex == -1)
                {
                    MessageBox.Show("Chưa chọn khoa điều trị!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbKhoa.Focus();
                    return;
                }
                NamDinh_QLBN.Forms.DuLieu.frmShowDSBenhNhan fr = new frmShowDSBenhNhan("", Global.GetCode(cmbKhoa), "", 1, 0,"0",covid);
                fr.ShowDialog();
                if (fr.DialogResult == DialogResult.OK)
                {
                    txtMaBenhAn.Text = fr.SoHSBAReturn;
                    txtMaVaoVien.Text = fr.MaVaoVienReturn;
                    txtHoTen.Text = fr.HoTenReturn;
                    txtTuoi.Text = fr.TuoiReturn;
                    txtGioi.Text = fr.GioiReturn;
                    txtDoiTuong.Text = fr.TenDoiTuongReturn;
                    txtNgayVaoVien.Text = fr.NgayVaoVienReturn;
                    MaDoiTuongBN = fr.MaDoiTuongReturn;
                    NgayKham = fr.NgayKhamReturn;
                    Load_PhieuChiDinh(txtMaVaoVien.Text);
                }
            }
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
                    MessageBox.Show("fdfs");
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.DuLieu.frmThongTinKQ frm = new frmThongTinKQ();
            frm._MaVaoVien = txtMaVaoVien.Text;
            frm.ShowDialog();
        }

        private void fgPhieuChiDinh_AfterRowColChange(object sender, C1.Win.C1FlexGrid.RangeEventArgs e)
        {
            cmdThuThuat.Enabled = false;
            Global.wait("Đang tổng hợp dữ liệu ....");
            if (fgPhieuChiDinh.Tag.ToString() == "0" || fgPhieuChiDinh.Row < 1)
            {
                Global.nowait();
                return;
            }
            Load_PhieuDieutri_ChiTiet(fgPhieuChiDinh.Row);
            Global.nowait();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaVaoVien.Text.Trim() == "") return;
                NamDinh_QLBN.Forms.DuLieu.frmKhamChuyenKhoa frm = new frmKhamChuyenKhoa(Global.GetCode(cmbKhoa),txtMaVaoVien.Text.Trim());
                if (frm.ShowDialog() == DialogResult.Yes)
                {
                    //NamDinh_QLBN.Reports.rptPhieuKhamChuyenKhoa rpt = new NamDinh_QLBN.Reports.rptPhieuKhamChuyenKhoa(txtMaVaoVien.Text.Trim(),Global.GetCode(cmbKhoa));
                    //rpt.Run();
                    //rpt.Show();

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
            }
        }

        private void cmdChiDinhTheoMatBenh_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.DuLieu.frmChiPhiTheoMatBenh frm = new frmChiPhiTheoMatBenh(fgDichVu, MaDoiTuongBN, Global.GetCode(cmbKhoa),NgayKham,"0");
            frm.ShowDialog();
        }

        private void fgDichVu_Click(object sender, EventArgs e)
        {
            if (fgDichVu.Rows.Count >= 1)
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

        private void button3_Click(object sender, EventArgs e)
        {
            //if (lblSoPhieu.Text.Trim() == "") return;
            //NamDinh_QLBN.Reports.repDonThuoc rpt = new NamDinh_QLBN.Reports.repDonThuoc(fgPhieuChiDinh.GetData(fgPhieuChiDinh.Row,"NgayChiDinh"),fgPhieuChiDinh.GetDataDisplay(fgPhieuChiDinh.Row,"BacSyDT"));
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
            if (txtMaVaoVien.Text.Trim() == "") return;
            frmSoKet15 frm = new frmSoKet15(txtMaVaoVien.Text);
            frm.ShowDialog();
        }

        private void cmdMau_Click(object sender, EventArgs e)
        {
            String Khoa = cmbKhoa.Text;
            String NgayIn = String.Format("In ngày {0:dd} tháng {0:MM} năm {0:yyyy}", Global.NgayLV);
            String NgaySD = String.Format("Ngày {0:dd} tháng {0:MM} năm {0:yyyy}", txtNgayChiDinh.Value);
            //NamDinh_QLBN.Reports.repPhieuLinhMau rep = new NamDinh_QLBN.Reports.repPhieuLinhMau(Khoa,NgayIn,NgaySD);
            NamDinh_QLBN.Reports.repGiayXinMau rep1 = new NamDinh_QLBN.Reports.repGiayXinMau(txtMaVaoVien.Text, lblSoPhieu.Text, txtNgayChiDinh.Value,Khoa);
            //DataDynamics.ActiveReports.DataSources.SqlDBDataSource _ds = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            //_ds.ConnectionString = GlobalModuls.Global.glbConnectionString;
            //_ds.SQL = string.Format("DECLARE @SoPhieu nvarchar(50)"
            //    + " DECLARE @SoLan int"
            //    + " DECLARE Cur CURSOR"
            //    + " FOR"
            //     + " select benhnhan_phieudieutri.sophieu from benhnhan_phieudieutri "
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
            //    + " where phieudieutri_chitiet.LoaiDichVu in ('D03')", txtMaVaoVien.Text, txtNgayChiDinh.Value, lblSoPhieu.Text);
            //rep.DataSource = _ds;
            //rep.Show();
            rep1.Show();
        }

        private void cmbNhomMau_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmdHoiChan_Click(object sender, EventArgs e)
        {
            if (txtMaVaoVien.Text.Trim() == "")
            {
                MessageBox.Show("Chọn bệnh nhân.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            NamDinh_QLBN.Forms.DuLieu.frmHoiChan frm = new frmHoiChan(txtMaVaoVien.Text);
            frm.ShowDialog();
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

        private void cmdTichKe_Click(object sender, EventArgs e)
        {
            //NamDinh_QLBN.Reports.repToDieuTri rep = new NamDinh_QLBN.Reports.repToDieuTri(txtMaVaoVien.Text.Trim(),Global.GetCode(cmbKhoa));
            //rep.Show();
            if (MaDoiTuongBN != "1")
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
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            try
            {
                SQLCmd.CommandText = "SELECT TenDichVu,vd.maDoiTuongBHXH +' - '+ SoThe + ' - ' + vd.MaNoiCap AS SoThe,isnull(pc.SoLuong,0)* isnull(pc.DonGia,0) as ThanhTien  FROM "
                                    + " ((((PHIEUDIEUTRI_CHITIET pc INNER JOIN DMDICHVU d ON d.MaDichVu = pc.MaDichVu )"
                                    + " INNER JOIN NAMDINH_CLS.dbo.DMDICHVU_CHISO dc ON dc.MaDichVu = d.MaDichVu)"
                                    + " INNER JOIN NAMDINH_CLS.dbo.DMCHISO d1 ON d1.MaChiSo=dc.MaChiSo)"
                                    + " INNER JOIN BENHNHAN_PHIEUDIEUTRI bp ON bp.SoPhieu = pc.SoPhieu)"
                                    + " INNER JOIN ViewDOITUONGHIENTAI vd ON vd.MaVaoVien = bp.MaVaoVien"
                                    + " WHERE pc.SoPhieu ='" + fgPhieuChiDinh.GetDataDisplay(fgPhieuChiDinh.Row, "SoPhieu") + "' AND (d1.MaMay = 2 OR d1.MaMay = 4 OR (d1.MaMay = 3  and d.tendichvu like N'%CT Scanner (Liên kết%'))";
                dr = SQLCmd.ExecuteReader();
                while (dr.Read())
                {
                    XetNghiem += dr["TenDichVu"].ToString() + ", ";
                    SoTheBHYT = dr["SoThe"].ToString();
                    TongTien += decimal.Parse(dr["ThanhTien"].ToString());
                }
                dr.Close();
                XetNghiem = XetNghiem.Substring(0, XetNghiem.Length - 2);
                NamDinh_QLBN.Reports.rptTichKeXN rpt = new NamDinh_QLBN.Reports.rptTichKeXN();
                rpt.Barcode1.Text = fgPhieuChiDinh.GetDataDisplay(fgPhieuChiDinh.Row, "SoPhieu");
                rpt.lblTenBN.Text = txtHoTen.Text.ToUpper();
                rpt.lblTenKhoa.Text = Global.glbTenKhoaPhong;
                rpt.lblSoThe.Text = SoTheBHYT;
                rpt.lblXetNghiem.Text = XetNghiem;
                rpt.txtTongTien.Value = TongTien;
                rpt.lblBacSiCD.Text = fgPhieuChiDinh.GetDataDisplay(fgPhieuChiDinh.Row, "BacSyDT");
                rpt.lblNgayThang.Text = string.Format("{0:HH} giờ {0:mm} - Ngày {0:dd} tháng {0:MM} năm {0:yyyy}", txtNgayChiDinh.Value);
                rpt.Show();
            }
            catch
            {
            }
            finally
            {
                SQLCmd.Dispose();
            }
        }

        private void cmdThuThuat_Click(object sender, EventArgs e)
        {
            if (txtMaVaoVien.Text.Trim() == "")
            {
                MessageBox.Show("Chọn bệnh nhân.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            NamDinh_QLBN.Forms.DuLieu.frmThongTinTT_KipTT frm = new frmThongTinTT_KipTT(txtMaVaoVien.Text.Trim(), lblSoPhieu.Text, fgDichVu.GetDataDisplay(fgDichVu.Row, "LoaiDichVu"), fgDichVu.GetDataDisplay(fgDichVu.Row, "MaDichVu"), txtNgayChiDinh.Text);
            //NamDinh_QLBN.Forms.DuLieu.frmThongTinTT frm = new frmThongTinTT(txtMaVaoVien.Text.Trim() );
            if (frm.ShowDialog() == DialogResult.Yes)
            {
                NamDinh_QLBN.Reports.repDuyetThuThuat rep = new NamDinh_QLBN.Reports.repDuyetThuThuat(txtMaVaoVien.Text.Trim(), lblSoPhieu.Text, fgDichVu.GetDataDisplay(fgDichVu.Row, "MaDichVu"), txtNgayChiDinh.Value);
                rep.Show();
            }
        }

        private void fgDichVu_RowColChange(object sender, EventArgs e)
        {

        }
    }
}