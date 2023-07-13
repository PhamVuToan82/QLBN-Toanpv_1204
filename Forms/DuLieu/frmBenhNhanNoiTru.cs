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
    public partial class frmBenhNhanNoiTru : Form
    {
        private int MucGiaApDung =0;
        private string prvMaBenhNhan ="";
        private string prvLanVaoVien = "0";
        public frmBenhNhanNoiTru(string MaBN,string LanVaoVien)
        {
            InitializeComponent();
            prvMaBenhNhan = MaBN;
            prvLanVaoVien = LanVaoVien;
        }

        private void frmBenhNhanNoiTru_Load(object sender, EventArgs e)
        {
            txttuNgay.Value = Global.NgayLV;
            txtToingay.Value = Global.NgayLV;
            txtNgayCP.Tag = "0";
            txtNgayCP.Value = GlobalModuls.Global.NgayLV;
            txtNgayCP.Tag = "1";
            cmbLoaiDS.Tag = "0";
            cmbLoaiDS.AddItem("1;Đang điều trị tại khoa");
            cmbLoaiDS.AddItem("2;đã ra viện");
            cmbLoaiDS.AddItem("3;Đã chuyển Khoa");
            cmbLoaiDS.Tag = "1";
            fg.ClipSeparators = "|;";
            fgPhauThuat.ClipSeparators = "|;";
            fgPhauThuat.Cols[6].Visible = false;
            fgPhauThuat.Cols[7].Visible = false;
            fgPhauThuat.Cols[8].Visible = false;            
            fgKipMo.ClipSeparators = "|;";            
            fgDoiTuong.ClipSeparators = "|;";
            fgKhoaPhong.ClipSeparators = "|;";
            fgDoiTuong.Cols[3].Visible = false;
            fgKhoaPhong.Cols[3].Visible = false;
            Load_CacDM();
            Format_Grid();
            fgChiTiet.ContextMenuStrip = contextMenuNhapLieu;
            if (prvMaBenhNhan != "")
            {
                System.Data.SqlClient.SqlDataReader dr;
                System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
                SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
                SQLCmd.CommandText = string.Format("SELECT BENHNHAN_CHITIET.MaBenhNhan,BENHNHAN_CHITIET.LanVaoVien,MaKhoa FROM BENHNHAN_CHITIET INNER JOIN ViewKHOAHIENTAI ON BENHNHAN_CHITIET.MaBenhNhan = ViewKHOAHIENTAI.MaBenhNhan AND BENHNHAN_CHITIET.LanVaoVien=ViewKHOAHIENTAI.LanVaoVien "
                                    + " WHERE BENHNHAN_CHITIET.MaBenhNhan = '{0}' AND BENHNHAN_CHITIET.LanVaoVien ={1}", prvMaBenhNhan, prvLanVaoVien);
                dr = SQLCmd.ExecuteReader();
                string MaKhoa = "";
                while (dr.Read())
                {
                    MaKhoa = dr["MaKhoa"].ToString();
                }
                dr.Close();
                SQLCmd.Dispose();
                Global.SetCmb(cmbKhoa, MaKhoa);
                fg.Row = -1;
                for (int i = 1; i < fg.Rows.Count; i++)
                {
                    if (fg[i, 1].ToString() == prvMaBenhNhan)
                    {
                        fg.Select(i, 1);
                        break;
                    }
                }
                this.tabControl1.SelectedIndex = 0;
            }
            else
            {
                Global.SetCmb(cmbKhoa, Global.glbMaKhoaPhong);
            }
            Global.SetGridStyles(fgChiTiet);
            Global.SetGridStyles(fg);
            
        }

        private void fgChiTiet_AfterEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {   
            if (fgChiTiet.GetDataDisplay(e.Row, "SoLuong") == "")
            {
                MessageBox.Show("Số lượng nhập vào không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;                
            }
            if (fgChiTiet.GetData(e.Row, "DonGia")!= null) { fgChiTiet[e.Row, "ThanhTien"] = int.Parse(fgChiTiet.GetData(e.Row, "SoLuong").ToString()) * int.Parse(fgChiTiet.GetData(e.Row, "DonGia").ToString()); }
            if (fgChiTiet.GetData(e.Row, "DonGiaQT") != null) { fgChiTiet[e.Row, "ThanhTienQT"] = int.Parse(fgChiTiet.GetData(e.Row, "SoLuong").ToString()) * int.Parse(fgChiTiet.GetData(e.Row, "DonGiaQT").ToString()); }
            Tinh_Tien();
        }
               
        private void cmdThoat_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void Load_DSBN(string MaKhoa)
        {
            if (cmbLoaiDS.SelectedIndex == -1) return;
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            SQLCmd.CommandText = string.Format("select BENHNHAN.*,BENHNHAN_CHITIET.*,ViewKHOAHIENTAI.MaKhoa,TenDT,Year(VIEWKHOAHIENTAI.NgayChuyen)-namSinh As Tuoi,MucGia,ViewDOITUONGHIENTAI.DoiTuong As DoiTUongBN,TenBuong,TenGiuong,NgayRaVien As NgayRV,'' As TenTat"
                                            + " FROM (((((BENHNHAN INNER JOIN BENHNHAN_CHITIET ON BENHNHAN.MaBenhNhan=BENHNHAN_CHITIET.MaBenhNhan) "
                                            + " LEFT JOIN DMBUONGBENH ON BENHNHAN_CHITIET.Buong=DMBUONGBENH.ID_Buong AND MaKhoa='{0}') "
                                            + " LEFT JOIN DMGIUONGBENH ON BENHNHAN_CHITIET.Buong=DMGIUONGBENH.ID_Buong AND BENHNHAN_CHITIET.Giuong=DMGIUONGBENH.ID_Giuong  AND DMGIUONGBENH.MaKhoa='{0}') "
                                            + " INNER JOIN VIEWKHOAHIENTAI ON BENHNHAN_CHITIET.MaBenhNhan=VIEWKHOAHIENTAI.MaBenhNhan AND BENHNHAN_CHITIET.LanVaoVien=VIEWKHOAHIENTAI.LanVaoVien) "
                                            + " INNER JOIN VIEWDOITUONGHIENTAI ON BENHNHAN_CHITIET.MaBenhNhan= VIEWDOITUONGHIENTAI.MaBenhNhan AND BENHNHAN_CHITIET.LanVaoVien=VIEWDOITUONGHIENTAI.LanVaoVien)"
                                            + " INNER JOIN DMDOITUONGBN ON VIEWDOITUONGHIENTAI.DoiTuong=MaDT",MaKhoa);
            if (cmbLoaiDS.SelectedIndex==0)
            {
                SQLCmd.CommandText += string.Format(" WHERE viewKHOAHIENTAI.MaKhoa='{0}' AND TrangThai=1 AND viewKHOAHIENTAI.vDaRaVien=0", MaKhoa);
                fg[0, "NgayRaVien"] = "Ngày ra viện";
                fg.Cols["TenTat"].Visible = false;
            }
            else if (cmbLoaiDS.SelectedIndex ==1)
            {
                SQLCmd.CommandText += string.Format(" WHERE viewKHOAHIENTAI.MaKhoa='{0}' AND viewKHOAHIENTAI.vDaRaVien=1 AND NgayRaVien BETWEEN '{1:MM/dd/yyyy}' AND '{2:MM/dd/yyyy}'", MaKhoa,txttuNgay.Value,txtToingay.Value);
                fg[0, "NgayRaVien"] = "Ngày ra viện";
                fg.Cols["TenTat"].Visible = false;
            }
            else
            {
                SQLCmd.CommandText = string.Format("select BENHNHAN.*,BENHNHAN_CHITIET.*,Q2.KhoaDi as MaKhoa,TenDT,Year(Q1.NGAYCHUYEN)-namSinh As Tuoi,MucGia,ViewDOITUONGHIENTAI.DoiTuong As DoiTUongBN,'' As TenBuong,'' As TenGiuong,Q2.NgayChuyenDi as NgayRV,DMKHOAPHONG.TenTat "
                                + " FROM ((((BENHNHAN INNER JOIN BENHNHAN_CHITIET ON BENHNHAN.MaBenhNhan=BENHNHAN_CHITIET.MaBenhNhan) "
                                + " INNER JOIN VIEWDOITUONGHIENTAI ON BENHNHAN_CHITIET.MaBenhNhan= VIEWDOITUONGHIENTAI.MaBenhNhan AND BENHNHAN_CHITIET.LanVaoVien=VIEWDOITUONGHIENTAI.LanVaoVien)"
                                + " INNER JOIN DMDOITUONGBN ON VIEWDOITUONGHIENTAI.DoiTuong=MaDT)"
                                + " INNER JOIN (SELECT BENHNHAN_KHOA.MaBenhNhan,BENHNHAN_KHOA.LanVaoVien,Q1.MaKhoa As KhoaDi,BENHNHAN_KHOA.MaKhoa As KhoaDen,BENHNHAN_KHOA.NgayChuyen AS NgayChuyenDi FROM BENHNHAN_KHOA INNER JOIN (SELECT BENHNHAN_KHOA.* FROM BENHNHAN_KHOA)Q1 "
                                + " ON BENHNHAN_KHOA.MaBenhNhan=Q1.MaBenhNhan AND BENHNHAN_KHOA.LanVaoVien=Q1.LanVaoVien AND BENHNHAN_KHOA.LanChuyenKhoa=Q1.LanChuyenKhoa+1) Q2 "
                                + " ON BENHNHAN_CHITIET.MaBenhNhan=Q2.MaBenhNHan AND BENHNHAN_CHITIET.LanVaoVien=Q2.LanVaoVien) "
                                + " INNER JOIN DMKHOAPHONG ON Q2.KhoaDen=DMKHOAPHONG.MaKhoa "
                                + " WHERE Q2.KHoaDi='{0}' AND Q2.NgayChuyenDi BETWEEN '{1:MM/dd/yyyy}' AND '{2:MM/dd/yyyy}'", MaKhoa, txttuNgay.Value, txtToingay.Value);
                fg[0, "NgayRaVien"] = "Ngày chuyển đi";
                fg.Cols["TenTat"].Visible = true;
            }
            dr = SQLCmd.ExecuteReader();
            fg.Tag = "0";
            fg.Rows.Count = 1;
            while (dr.Read())
            {
                fg.AddItem(string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7:dd/MM/yyyy}|{8}|{9}|{10}|{11}|{12}|{13:dd/MM/yyyy}|{14}",
                        fg.Rows.Count,
                        dr["MaBenhNhan"],
                        dr["SoHSBA"],
                        dr["HoTen"],
                        dr["Tuoi"],
                        (dr["GioiTinh"].ToString() == "1") ? ("Nam") : ("Nữ"),
                        dr["LanVaoVien"],
                        dr["NgayVaoVien"],
                        dr["TenDT"], dr["MucGia"], dr["DoiTuongBN"], dr["TenBuong"], dr["TenGiuong"], dr["NgayRV"], dr["TenTat"]));
            }
            dr.Close();
            SQLCmd.Dispose();
            fg.Tag = "1";
            fg.AutoSizeCols();
        }

        private void cmbKhoa_TextChanged(object sender, EventArgs e)
        {
            if (cmbKhoa.Tag.ToString() == "0") { return; }
            Load_DSBN(GlobalModuls.Global.GetCode(cmbKhoa));
        }

        private void fg_DoubleClick(object sender, EventArgs e)
        {
            if (fg.Row < 1) { return; }
            txtMaBN.Text = fg.GetDataDisplay(fg.Row, 1);
            txtHoTen.Text = fg.GetDataDisplay(fg.Row, 3);
            txtTuoi.Text = fg.GetDataDisplay(fg.Row, 4);
            txtGioi.Text = fg.GetDataDisplay(fg.Row, 5);
            txtLanVaoVien.Text = fg.GetDataDisplay(fg.Row, 6);
            txtDoiTuong.Text = fg.GetDataDisplay(fg.Row, 8);
            txtDoiTuong.Tag = fg.GetDataDisplay(fg.Row, 10);
            MucGiaApDung =(int) fg.GetData(fg.Row, 9);
            this.tabControl1.SelectedTab = tabControl1.TabPages[1];
        }
        private void fg_SelChange(object sender, EventArgs e)
        {
            if (fg.Row < 1 || fg.Tag.ToString() =="0") { return; }
            txtMaBN.Text = fg.GetDataDisplay(fg.Row, 1);
            txtHoTen.Text = fg.GetDataDisplay(fg.Row, 3);
            txtTuoi.Text = fg.GetDataDisplay(fg.Row, 4);
            txtGioi.Text = fg.GetDataDisplay(fg.Row, 5);
            txtLanVaoVien.Text = fg.GetDataDisplay(fg.Row, 6);
            txtDoiTuong.Text = fg.GetDataDisplay(fg.Row, 8);
            MucGiaApDung = (int)fg.GetData(fg.Row, 9);
            txtDoiTuong.Tag = fg.GetDataDisplay(fg.Row, 10);
            txtNgayVaoVien.Text = fg.GetDataDisplay(fg.Row, 7);
            Clear_ChiTiet();
            LayThongTinBN(txtMaBN.Text, txtLanVaoVien.Text);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ( tabControl1.SelectedIndex !=0)
            {
                if (txtMaBN.Text == "")
                {
                    MessageBox.Show("Chưa chọn bệnh nhân!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tabControl1.SelectedIndex = 0;
                    return;
                }
                else
                {
                    LoadData_ChiTiet(txtMaBN.Text);
                    cmbLoaiDT.SelectedIndex = 0;
                }

            }           
            if (tabControl1.SelectedIndex == 2)
            {
                Load_DoiTuong(txtMaBN.Text,txtLanVaoVien.Text);
            }
            if (tabControl1.SelectedIndex == 3)
            {
                Load_PhauThuat(txtMaBN.Text, txtLanVaoVien.Text);
            }
            if (tabControl1.SelectedIndex == 4)
            {
                Load_ThongTinDieuTri(txtMaBN.Text, txtLanVaoVien.Text);
            }

        }
                
        private void Format_Grid()
        {
            fgChiTiet.Cols.Fixed = 0;
            fgChiTiet.Rows.Count = 2;
            C1.Win.C1FlexGrid.CellStyle s = fgChiTiet.Styles[C1.Win.C1FlexGrid.CellStyleEnum.Subtotal0];
            s.BackColor = Color.SkyBlue;
            s.ForeColor = Color.Blue;
            Font f = new Font(s.Font.FontFamily, 10, FontStyle.Regular);
            s.Font = f;
            s = fgChiTiet.Styles[C1.Win.C1FlexGrid.CellStyleEnum.Subtotal1];
            s.BackColor = Color.White;
            s.ForeColor = Color.Gray;
            f = new Font(s.Font.FontFamily, 9, FontStyle.Bold);
            
            s.Font = f;


            fgChiTiet.ClipSeparators = "|;";
            fgChiTiet.Cols["TenPPDT"].Visible = false;
            fgChiTiet.Cols["TenLoai"].Visible = false;
            fgChiTiet.Cols["MaCP"].Visible = false;
            fgChiTiet.Cols["DonGiaQT"].Visible = false;
            fgChiTiet.Cols["ThanhTienQT"].Visible = false;
            fgChiTiet.Cols["LoaiCP"].Visible = false;
            fgChiTiet.Cols["LanChiDinh"].Visible = false;
            fgChiTiet.Cols["LoaiDT"].Visible = false;
            fgChiTiet.Cols["MaDTTG"].Visible = false;
            fgChiTiet.Cols["MaKhoa"].Visible = false;

            fgChiTiet.Tree.Column = fgChiTiet.Cols["TenCP"].Index;
            fgChiTiet.Tree.Style = C1.Win.C1FlexGrid.TreeStyleFlags.SimpleLeaf;
            fgChiTiet.Cols[0].AllowEditing = false;
            fgChiTiet.Cols[1].AllowEditing = false;
            fgChiTiet.Cols[2].AllowEditing = false;
            fgChiTiet.Cols[3].AllowEditing = false;
            fgChiTiet.Cols[4].AllowEditing = false;
            fgChiTiet.Cols[5].AllowEditing = false;
            
            fgChiTiet.Cols[7].AllowEditing = false;
            fgChiTiet.Cols[8].AllowEditing = false;
            fgChiTiet.Cols[9].AllowEditing = false;
            fgChiTiet.Cols[11].AllowEditing = false;
            fgChiTiet.Cols[12].AllowEditing = false;
            fgChiTiet.Cols[13].AllowEditing = false;
            fgChiTiet.Cols["TenTat"].AllowEditing = false;

            fgChiTiet.Cols["SoLuong"].Format = "#,###";
            fgChiTiet.Cols["DonGia"].Format = "#,###";
            fgChiTiet.Cols["DonGiaQT"].Format = "#,###";
            fgChiTiet.Cols["ThanhTien"].Format = "#,###";
            fgChiTiet.Cols["ThanhTienQT"].Format = "#,###";

            fgChiTiet[0, "STT"] = fgChiTiet[1, "STT"] = "STT";
            fgChiTiet[0, "TenCP"] = fgChiTiet[1, "TenCP"] = "Tên chi phí";
            fgChiTiet[0, "DVTinh"] = fgChiTiet[1, "DVTinh"] = "ĐVT";
            fgChiTiet[0, "SoLuong"] = fgChiTiet[1, "SoLuong"] = "Số lượng";
            //fgChiTiet[0, 7] = fgChiTiet[0, 8] = "Đơn giá";
            //fgChiTiet[0, 9] = fgChiTiet[0, 10] = "Thành tiền";

            fgChiTiet[0, "DonGia"] = fgChiTiet[1, "DonGia"] = "Đơn giá";
            fgChiTiet[0, "DonGiaQT"] = fgChiTiet[1, "DonGiaQT"] = "Đơn giá QT";
            fgChiTiet[0, "ThanhTienQT"] = fgChiTiet[1, "ThanhTienQT"] = "Thành tiền QT";
            fgChiTiet[0, "ThanhTien"] = fgChiTiet[1, "ThanhTien"] = "Thành tiền";

            fgChiTiet[0, 12] = fgChiTiet[1, 12] = "Đã thực hiện";
            fgChiTiet[0, 13] = fgChiTiet[1, 13] = "Ghi chú";
            fgChiTiet[0, "tenTat"] = fgChiTiet[1, "tenTat"] = "Khoa nhập";
            
            fgChiTiet.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.FixedOnly;
            fgChiTiet.Cols[2].AllowMerging = fgChiTiet.Cols[4].AllowMerging = fgChiTiet.Cols[5].AllowMerging = fgChiTiet.Cols[6].AllowMerging = fgChiTiet.Cols[7].AllowMerging = fgChiTiet.Cols[8].AllowMerging = fgChiTiet.Cols[9].AllowMerging = fgChiTiet.Cols[12].AllowMerging = fgChiTiet.Cols[13].AllowMerging = fgChiTiet.Cols[15].AllowMerging = fgChiTiet.Cols["TenTat"].AllowMerging = true;
            fgChiTiet.Rows[0].AllowMerging = true;
            fgChiTiet.Rows[0].TextAlign = fgChiTiet.Rows[1].TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;

            fgTienCPNgay.Cols[2].Format = "#,###";

            fg.Cols[9].Visible = fg.Cols[10].Visible = false;
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
            cmbKhoa.SelectedIndex = -1;
            cmbKhoa.Tag = "1";
            dr.Close();
            SQLCmd.CommandText = "SELECT * FROM DMLOAIHINHDT";
            dr = SQLCmd.ExecuteReader();
            cmbLoaiDT.Tag = "0";
            cmbLoaiDT.ClearItems();
            while (dr.Read())
            {
                cmbLoaiDT.AddItem(string.Format("{0};{1}", dr["MaLH"], dr["TenLH"]));
            }
            cmbLoaiDT.SelectedIndex = -1;
            cmbLoaiDT.Tag = "1";
            dr.Close();
            SQLCmd.CommandText = "SELECT * FROM DMLOAICHIPHI";
            dr = SQLCmd.ExecuteReader();
            fgTienCPNgay.Rows.Count = 1;
            fgTienCPNgay.ClipSeparators = "|;";
            while (dr.Read())
            {
                fgTienCPNgay.AddItem(string.Format("{0}|{1}",dr["MaLoai"],dr["TenLoai"]));
            }            
            dr.Close();
            SQLCmd.Dispose();
        }
        private void Tinh_Tien()
        {
            fgChiTiet.Redraw = false;
            fgChiTiet.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.Clear);
            int CotThanhTien = fgChiTiet.Cols["ThanhTien"].Index;
            int CotThanhTienQT = fgChiTiet.Cols["ThanhTienQT"].Index;
            fgChiTiet.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.Sum, 1, 0, CotThanhTien, "{0}");
            fgChiTiet.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.Sum, 2, 1, CotThanhTien, "{0}");
            fgChiTiet.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.Sum, 1, 0, CotThanhTienQT, "{0}");
            fgChiTiet.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.Sum, 2, 1, CotThanhTienQT, "{0}");
            fgChiTiet.Redraw = true;
            for (int j = 1; j < fgTienCPNgay.Rows.Count; j++)
            {
                fgTienCPNgay[j, 2] = "0";
            }
            for (int i = 1; i < fgChiTiet.Rows.Count; i++)
            {
                if (fgChiTiet.Rows[i].IsNode && fgChiTiet.Rows[i].Node.Level ==2)
                {
                    for (int j=1;j<fgTienCPNgay.Rows.Count;j++)
                    {
                        if (fgTienCPNgay[j,1].ToString()==fgChiTiet.GetData(i, "TenCP").ToString() )
                        {
                            fgTienCPNgay[j, 2] =double.Parse(fgTienCPNgay[j, 2].ToString()) +double.Parse(fgChiTiet.GetData(i, "ThanhTien").ToString());
                        }                    
                    }
                }
            }
            double TongTrongNgay = 0;
            for (int j = 1; j < fgTienCPNgay.Rows.Count; j++)
            {
                TongTrongNgay += double.Parse(fgTienCPNgay[j, 2].ToString());
            }
            lblTongNgay.Text = string.Format("{0:#,###}", TongTrongNgay);
            TongTrongNgay += double.Parse(lblLuyKe.Tag.ToString());
            lblTong.Text = string.Format("{0:#,###}", TongTrongNgay);
            double ThuaThieu = 0;
            ThuaThieu = double.Parse(lblTongThanhToan.Tag.ToString()) + double.Parse(lblTongKyQuy.Tag.ToString()) + double.Parse(lblTongMienGiam.Tag.ToString()) - TongTrongNgay;
            //lblThuaThieu.Text = (ThuaThieu < 0) ? ("Thiếu") : ("Thừa");
            lblThuaThieu.Text = "Còn lại";
            lblTienThuaThieu.Text = string.Format("{0:#,###}", ThuaThieu);
            if (ThuaThieu < 0)
            {
                lblTienThuaThieu.ForeColor  = Color.Red;
            }
            else
            {
                lblTienThuaThieu.ForeColor = Color.Blue;
            }
        }
        private void Save_Data()
        {
            string MaBN = txtMaBN.Text,  LoaiDT = Global.GetCode(cmbLoaiDT),MaKhoa = Global.glbMaKhoaPhong;
            string LanVV=txtLanVaoVien.Text;
            string MaDTTG = ""; //null;
            bool DaCoGiuong = false;
            bool DaCoAn = false;
            for (int i = 2; i < fgChiTiet.Rows.Count; i++)
            {
                if (fgChiTiet.GetDataDisplay(i, "LoaiCP") == "4") { DaCoGiuong = true; break; }
            }
            for (int i = 2; i < fgChiTiet.Rows.Count; i++)
            {
                if (fgChiTiet.GetDataDisplay(i, "LoaiCP") == "5") { DaCoAn = true; break; }
            }
            if (!DaCoGiuong)
            {
                ThemTienMacDinh(4, "Tiền giường điều trị");
            }
            if (!DaCoAn)
            {
                ThemTienAn();
            }
            if (!DaCoGiuong || !DaCoAn) { Tinh_Tien(); }
            if (fgChiTiet.Rows.Count == 2)
            {
                if (MessageBox.Show("Chưa có chi phí của bệnh nhân, bạn có chắc muốn ghi dữ liệu không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) { return; }
            }
            System.Data.SqlClient.SqlTransaction trn;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = Global.ConnectSQL;
            trn = Global.ConnectSQL.BeginTransaction();
            try
            {
                SQLCmd.CommandText = string.Format("DELETE FROM BENHNHAN_CHIPHI WHERE MaBenhNhan='{0}' AND LanVaoVien={1} AND MaKhoa='{2}' AND NgayCP='{3:MM/dd/yyyy}'",MaBN,LanVV,MaKhoa,txtNgayCP.Value);
                SQLCmd.Transaction = trn;
                SQLCmd.ExecuteNonQuery();
                for (int i = 2; i<fgChiTiet.Rows.Count;i++)
                {
                    if (! fgChiTiet.Rows[i].IsNode && fgChiTiet.GetDataDisplay(i,"MaKhoa")==MaKhoa)
                    {
                        LoaiDT = fgChiTiet.GetDataDisplay(i, "LoaiDT");
                        MaDTTG = (fgChiTiet.GetDataDisplay(i, "MaDTTG") == "") ? ("null") : ("'" + fgChiTiet.GetDataDisplay(i, "MaDTTG")+"'");
                        SQLCmd.CommandText = string.Format("INSERT INTO BENHNHAN_CHIPHI (MaBenhNhan,LanVaoVien,MaKhoa,LoaiChiPhi,MaCP,LoaiDT,NgayCP,SoLuong,DonGia,DonGia_QT,MaDTTG,DaThucHien,LanChiDinh,KetQua,DoiTuongBN) VALUES ("
                            + "'{0}',{1},'{2}',{3},'{4}',{5},'{6:MM/dd/yyyy}',{7:0},{8:0},{9:0},{10},{11},{12},N'{13}','{14}')",
                                        MaBN,LanVV,MaKhoa,fgChiTiet[i,"LoaiCP"],fgChiTiet[i,"MaCP"],
                                        LoaiDT,txtNgayCP.Value,
                                        fgChiTiet[i,"SoLuong"],
                                        (fgChiTiet[i, "DonGia"] == null) ? (0) : (fgChiTiet[i, "DonGia"]),
                                        (fgChiTiet[i, "DonGiaQT"] == null) ? (0) : (fgChiTiet[i, "DonGiaQT"]),
                                        MaDTTG,(fgChiTiet[i,"DaThucHien"].ToString().ToLower() == "false")?(0):(1),
                                        (fgChiTiet[i, "LanChiDinh"].ToString() == "") ? (0) : (fgChiTiet[i, "LanChiDinh"]),
                                        fgChiTiet[i, "GhiChu"],
                                        txtDoiTuong.Tag);
                        SQLCmd.ExecuteNonQuery();
                    }
                }
                trn.Commit();
                MessageBox.Show("Đã ghi dữ liệu của bệnh nhân!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);                
            }
            catch (Exception ex)
            {
                trn.Rollback();
                MessageBox.Show("Có lỗi khi ghi dữ liệu!\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }
            finally
            {
                SQLCmd.Dispose();
            }
        }

        private void cmdGhiChiTiet_Click(object sender, EventArgs e)
        {
            
            Save_Data();
        }

        private void cmbLoaiDT_TextChanged(object sender, EventArgs e)
        {            
            if (cmbLoaiDT.Tag.ToString() == "0" || cmbLoaiDT.SelectedIndex ==-1) { return; }
            string LoaiHinhDT = Global.GetCode(cmbLoaiDT);
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            SQLCmd.CommandText = "SELECT DMPHUONGPHAPDIEUTRI.MaPP,TenPP FROM DMPHUONGPHAPDIEUTRI INNER JOIN PHUONGPHAPDT_LOAIHINHDT ON DMPHUONGPHAPDIEUTRI.MaPP=PHUONGPHAPDT_LOAIHINHDT.MaPP WHERE MaLoaiHinh=" + LoaiHinhDT + " AND NgoaiTru_NoiTru>1 AND Len(DMPHUONGPHAPDIEUTRI.MaPP)=5 AND (DMPHUONGPHAPDIEUTRI.MaKHoa='" + Global.GetCode(cmbKhoa) + "' OR DMPHUONGPHAPDIEUTRI.MaKhoa Is NULL)";
            dr = SQLCmd.ExecuteReader();
            cmbPhuongPhapDT.Tag = "0";
            cmbPhuongPhapDT.ClearItems();
            while (dr.Read())
            {
                cmbPhuongPhapDT.AddItem(string.Format("{0};{1}", dr["MaPP"], dr["TenPP"]));
            }
            dr.Close();
            SQLCmd.Dispose();
            cmbPhuongPhapDT.SelectedIndex = -1;
            cmbPhuongPhapDT.Tag = "1";
        }

        private void fgChiTiet_AfterDeleteRow(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            Tinh_Tien();
        }
        private void LoadData_ChiTiet(string MaBN)
        {
            lblLuyKe.Tag = "0";
            lblTongNgay.Text = "0";
            lblTongNgay.Tag = "0";
            lblTong.Tag = "0";
            lblTong.Text = "0";
            for (int i = 1; i < fgTienCPNgay.Rows.Count; i++)
            {
                fgTienCPNgay[i, 2] = 0;
            }
            if (txtMaBN.Text == "" || txtNgayCP.ValueIsDbNull || cmbKhoa.SelectedIndex == -1) { return; }
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            SQLCmd.CommandText = string.Format("SELECT TenLH,TenPP,TenLoai,BENHNHAN_CHIPHI.MaCP,TenCP,DVTinh,BENHNHAN_CHIPHI.SoLuong,BENHNHAN_CHIPHI.DonGia_QT,BENHNHAN_CHIPHI.DonGia,"
                                    + " BENHNHAN_CHIPHI.LoaiDT,BENHNHAN_CHIPHI.MaDTTG, BENHNHAN_CHIPHI.LoaiChiPhi,DaThucHien,SoLuong*DonGia_QT As ThanhTien_QT,SoLuong*DonGia As ThanhTien,LanChiDinh,KetQua,TenTat,BENHNHAN_CHIPHI.MaKhoa "
                                    + " FROM ((((BENHNHAN_CHIPHI INNER JOIN ViewDMCHIPHI ON BENHNHAN_CHIPHI.MaCP=ViewDMCHIPHI.MaCP AND BENHNHAN_CHIPHI.LoaiChiPhi = ViewDMCHIPHI.LoaiCP) "
                                    + " INNER JOIN DMLOAICHIPHI ON BENHNHAN_CHIPHI.LoaiChiPhi=DMLOAICHIPHI.MaLoai) "                                   
                                    + " INNER JOIN DMLOAIHINHDT ON BENHNHAN_CHIPHI.LoaiDT=DMLOAIHINHDT.MaLH) "
                                    + " INNER JOIN DMKHOAPHONG ON BENHNHAN_CHIPHI.MaKhoa = DMKHOAPHONG.MaKhoa) "
                                    + " LEFT JOIN DMPHUONGPHAPDIEUTRI ON MaDTTG=MaPP "
                                    + " WHERE BENHNHAN_CHIPHI.MaBenhNhan='{0}' AND BENHNHAN_CHIPHI.LanVaoVien={1} AND BENHNHAN_CHIPHI.NgayCP='{2:MM/dd/yyyy}' "
                                    + " ORDER BY LoaiDT,MaDTTG,BENHNHAN_CHIPHI.LoaiChiPhi",
                                    MaBN,txtLanVaoVien.Text,txtNgayCP.Value);
            dr = SQLCmd.ExecuteReader();
            fgChiTiet.Tag = "0";
            fgChiTiet.Redraw = false; 
            fgChiTiet.Rows.Count = 2;
            int STT=1;
            string TenLoai = "";
            string TenPPDT = "";
            while (dr.Read())
            {
                if (TenLoai != dr["tenLoai"].ToString())
                {
                    STT = 1;
                    TenLoai = dr["tenLoai"].ToString();
                }
                TenPPDT = string.Format("{0} ({1})", dr["TenPP"], dr["TenLH"]);
                fgChiTiet.AddItem(string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6:#,###}|{7:#,###}|{8:#,###}|{9:#,###}|{10}|{11}|{12}|{13}|{14}|{15}|{16}|{17}|{18}",
                    TenPPDT, dr["TenLoai"], STT, dr["MaCP"], dr["TenCP"], dr["DVTinh"], dr["SoLuong"],
                    dr["DonGia"], dr["DonGia_QT"], dr["ThanhTien"], dr["ThanhTien_QT"], dr["LoaiChiPhi"], dr["DaThucHien"], dr["KetQua"], dr["LanChiDinh"], dr["LoaiDT"], dr["MaDTTG"],dr["TenTat"],dr["MaKhoa"]));
                //if (dr["LoaiChiPhi"].ToString() == "2")
                //{
                //    fgChiTiet[fgChiTiet.Rows.Count - 1, 12] = "Lần chỉ định: " + dr["LanChiDinh"].ToString();
                //}
                STT += 1;
            }
            dr.Close();
            SQLCmd.CommandText = string.Format("SELECT SUM(SoLuong*DonGia) AS TongLuyKe FROM BENHNHAN_CHIPHI WHERE MaBenhNhan='{0}' AND LanVaoVien={1} AND DaThucHien=1 AND (MaKhoa <> '{2}' OR NgayCP<>'{3:MM/dd/yyyy}')", MaBN, txtLanVaoVien.Text, Global.GetCode(cmbKhoa), txtNgayCP.Value);
            dr = SQLCmd.ExecuteReader();
            dr.Read();
            lblLuyKe.Text =string.Format("{0:#,###}",dr["TongLuyKe"]);
            lblLuyKe.Tag = (dr["TongLuyKe"].ToString() =="" )?("0"):(dr["TongLuyKe"].ToString());
            dr.Close();
            SQLCmd.Dispose();

            fgChiTiet.Tag = "1";
            fgChiTiet.Redraw = true; 
            Tinh_Tien();
        }

        private void txtNgayCP_ValueChanged(object sender, EventArgs e)
        {
            if (txtNgayCP.Tag.ToString() == "0") { return; }
            //tabControl1.TabPages["CPDT"].Select();
            this.tabControl1.SelectedTab = tabControl1.TabPages["CPDT"];
            LoadData_ChiTiet(txtMaBN.Text);
        }
        private void LayThongTinBN(string MaBN,string LanVV)
        {
            double TongTien = 0;            
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            SQLCmd.CommandText = "SELECT SUM(SoTien) As TongKyQuy FROM BENHNHAN_KYQUY WHERE MaBenhNhan='" + MaBN +"' AND LanVaoVien=" + LanVV;
            dr = SQLCmd.ExecuteReader();
            lblTongKyQuy.Tag = "0";
            while (dr.Read())
            {
                TongTien = (dr["TongKyQuy"].ToString() == "") ? (0) : (double.Parse(dr["TongKyQuy"].ToString()));
                lblTongKyQuy.Text = string.Format("{0:#,###}",TongTien);
                lblTongKyQuy.Tag = TongTien;
            }
            dr.Close();
            SQLCmd.CommandText = "SELECT SUM(TienTT) As TongThanhToan FROM BENHNHAN_THANHTOAN WHERE MaBenhNhan='" + MaBN + "' AND LanVaoVien=" + LanVV + " AND TrangThai=0";
            dr = SQLCmd.ExecuteReader();
            while (dr.Read())
            {
                TongTien = (dr["TongThanhToan"].ToString() == "") ? (0) : (double.Parse(dr["TongThanhToan"].ToString()));
                lblTongThanhToan.Text = string.Format("{0:#,###}", TongTien);
                lblTongThanhToan.Tag = TongTien;
            }
            dr.Close();
            SQLCmd.CommandText = "SELECT SUM(SoTien) As TongMienGiam FROM BENHNHAN_MIENGIAM WHERE MaBenhNhan='" + MaBN + "' AND LanVaoVien=" + LanVV + "";
            dr = SQLCmd.ExecuteReader();
            while (dr.Read())
            {
                TongTien = (dr["TongMienGiam"].ToString() == "") ? (0) : (double.Parse(dr["TongMienGiam"].ToString()));
                lblTongMienGiam.Text = string.Format("{0:#,###}", TongTien);
                lblTongMienGiam.Tag = TongTien;
            }
            dr.Close();
            SQLCmd.Dispose();
        }
        private void Clear_ChiTiet()
        {
            for (int i = 1; i < fgTienCPNgay.Rows.Count; i++)
            {
                fgTienCPNgay[i, 2] = 0;
            }
            lblTongNgay.Text = "0";
            lblLuyKe.Tag = "0";
            lblLuyKe.Text = "0";
            lblTong.Text = "0";
            lblTong.Tag = "0";
            lblTongKyQuy.Tag = "0";
            lblTongKyQuy.Text = "0";
            lblTongThanhToan.Tag = "0";
            lblTongThanhToan.Text = "0";
            lblTienThuaThieu.Text = "0";
            lblThuaThieu.Text = "Thừa, thiếu";
            lblTongMienGiam.Text = "0";
            lblTongMienGiam.Tag = "0";
            lblTienThuaThieu.BackColor = Color.White;
            cmbLoaiDT.SelectedIndex = -1;
            fgChiTiet.Rows.Count = 2;
        }

        private void frmBenhNhanNoiTru_KeyUp(object sender, KeyEventArgs e)
        {
            if (!cmdNhap.Enabled) { return; }
            if (e.KeyCode == Keys.F3)
            {
                if (cmbLoaiDT.SelectedIndex == -1)
                {
                    MessageBox.Show("Chưa chọn loại hình điều trị!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbLoaiDT.Focus();
                    return;
                }
                //if (cmbPhuongPhapDT.SelectedIndex == -1)
                //{
                //    MessageBox.Show("Chưa chọn phương pháp điều trị!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    cmbPhuongPhapDT.Focus();
                //    return;
                //}
                NamDinh_QLBN.Forms.DuLieu.frmNhapCacChiPhi fr = new frmNhapCacChiPhi();
                fr.fg = this.fgChiTiet;
                fr.Left = this.Left;
                fr.MucGiaApDung = MucGiaApDung;
                fr.MaKhoaNhapLieu = Global.GetCode(cmbKhoa);
                fr.TenPhuongPhapDT = cmbPhuongPhapDT.Text + " (" + cmbLoaiDT.Text + ")";
                fr.MaPPDT = (Global.GetCode(cmbPhuongPhapDT) == null) ? ("") : (Global.GetCode(cmbPhuongPhapDT));
                fr.MaLoaiDT = Global.GetCode(cmbLoaiDT);
                fr.ShowDialog();
                fgChiTiet.Focus();
                Tinh_Tien();
            }
            if (e.KeyCode == Keys.F5)
            {
                if (fgChiTiet.Rows.Count == 2)
                {
                    if (MessageBox.Show("Chưa có chi phí của bệnh nhân, bạn có chắc muốn ghi dữ liệu không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) { return; }
                }
                Save_Data();
            }
            if (e.KeyCode == Keys.F7)
            {
                CopyDuLieu();
            }
        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlDataReader dr;
			System.Data.SqlClient.SqlCommand SQLCmd= new System.Data.SqlClient.SqlCommand();
			SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;

            SQLCmd.CommandText = "SELECT BENHNHAN_CHIPHI.MaKhoa,TenKhoa,BENHNHAN_CHIPHI.LoaiDT,TenLH,LoaiChiPhi,TenLoai,BENHNHAN_CHIPHI.MaCP,TenCP,Sum(SoLuong) as SoLuong,DVTinh,DonGia,Sum(SoLuong)*DonGia as ThanhTien "
                                    + " FROM (((BENHNHAN_CHIPHI INNER JOIN DMKHOAPHONG ON BENHNHAN_CHIPHI.MaKhoa=DMKHOAPHONG.MaKhoa) "
                                    + " INNER JOIN DMLOAIHINHDT ON LoaiDT=MaLH) "
                                    + " INNER JOIN DMLOAICHIPHI ON LoaiChiPhi=MaLoai) "
                                    + " INNER JOIN ViewDMChiPhi ON BENHNHAN_CHIPHI.maCP=ViewDMCHIPHI.MaCP AND BENHNHAN_CHIPHI.LoaiChiPhi=ViewDMCHIPHI.LoaiCP "
                                    + " WHERE MaBenhNhan='" + txtMaBN.Text + "' AND LanVaoVien=" + txtLanVaoVien.Text + " AND DaThucHien=1"
                                    + " GROUP BY BENHNHAN_CHIPHI.MaKhoa,TenKhoa,BENHNHAN_CHIPHI.LoaiDT,TenLH,LoaiChiPhi,TenLoai,BENHNHAN_CHIPHI.MaCP,TenCP,DVTinh,DonGia "
                                    + " ORDER BY BENHNHAN_CHIPHI.MaKhoa,BENHNHAN_CHIPHI.LoaiDT,LoaiChiPhi";
            dr = SQLCmd.ExecuteReader();
            // Son sua
            //NamDinh_QLBN.Reports.rptBenhNhan_ChiPhi rpt = new NamDinh_QLBN.Reports.rptBenhNhan_ChiPhi(txtMaBN.Text,txtHoTen.Text,txtTuoi.Text,txtDoiTuong.Text,txtNgayVaoVien.Text);
            //rpt.DaThanhToan = double.Parse(lblTongThanhToan.Tag.ToString());
            //rpt.KyQuy = double.Parse(lblTongKyQuy.Tag.ToString());
            //rpt.DataSource = dr;
            //rpt.Run();
            ////rpt.Document.Printer.PrinterSettings.
            ////rpt.Document.Print(false,false,false);
            //NamDinh_QLBN.Forms.In.PreviewForm fr = new NamDinh_QLBN.Forms.In.PreviewForm(rpt.Document,this.MdiParent);
            //fr.Show();
			dr.Close();
			SQLCmd.Dispose();
        }
        private void Load_DoiTuong(string MaBenhNhan, string LanVaoVien)
        {
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            SQLCmd.CommandText = "SELECT BENHNHAN_DOITUONG.*,TenDT FROM BENHNHAN_DOITUONG INNER JOIN DMDOITUONGBN ON DoiTuong=MaDT WHERE MaBenhNhan='" + MaBenhNhan + "' AND LanVaoVien=" + LanVaoVien + " ORDER BY LanChuyenDT";
            dr = SQLCmd.ExecuteReader();
            fgDoiTuong.Rows.Count = 1;
            while (dr.Read())
            {
                fgDoiTuong.AddItem(string.Format("{0}|{1:dd/MM/yyyy}|{2}|{3}", dr["LanChuyenDT"], dr["NgayChuyen"], dr["TenDT"], dr["DoiTuong"]));
            }
            dr.Close();
            SQLCmd.CommandText = "SELECT BENHNHAN_KHOA.*,TenKhoa FROM BENHNHAN_KHOA INNER JOIN DMKHOAPHONG ON BENHNHAN_KHOA.MaKhoa=DMKHOAPHONG.MaKhoa WHERE MaBenhNhan='" + MaBenhNhan + "' AND LanVaoVien=" + LanVaoVien + " ORDER BY LanChuyenKhoa";
            dr = SQLCmd.ExecuteReader();
            fgKhoaPhong.Rows.Count = 1;
            while (dr.Read())
            {
                fgKhoaPhong.AddItem(string.Format("{0}|{1:dd/MM/yyyy}|{2}|{3}", dr["LanChuyenKhoa"], dr["NgayChuyen"], dr["TenKhoa"], dr["maKhoa"]));
            }
            dr.Close();
            SQLCmd.Dispose();
            fgPhauThuat.Tag = "1";
            fgPhauThuat.AutoSizeCols();
        }
        private void Load_PhauThuat(string MaBenhNhan,string LanVaoVien)
        {
            Clear_Data_PhauThuat();
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            SQLCmd.CommandText = "SELECT *,TenPP,TenLH FROM ((BENHNHAN_PHAUTHUAT INNER JOIN DMPHUONGPHAPDIEUTRI ON YeuCauPhauThuat = MaPP) "
                               + " INNER JOIN DMLOAIHINHDT ON LoaiHinhPhauThuat = MaLH) "
                               + " INNER JOIN DMKHOAPHONG ON BENHNHAN_PHAUTHUAT.MaKhoa=DMKHOAPHONG.MaKhoa "
                               + " WHERE MaBenhNhan='" + MaBenhNhan + "' AND LanVaoVien=" + LanVaoVien ;
            dr = SQLCmd.ExecuteReader();
            fgPhauThuat.Tag = "0";
            fgPhauThuat.Rows.Count = 1;            
            while (dr.Read())
            {
                fgPhauThuat.AddItem(string.Format("{0}|{1}|{2:dd/MM/yyyy}|{3}|{4}|{5}|{6}|{7}|{8}", fgPhauThuat.Rows.Count, dr["TenPP"], dr["NgayYeuCau"], dr["TenLH"], dr["TenKhoa"], dr["DaPhauThuat"],dr["LanPT"],dr["LoaiHinhPhauThuat"],dr["YeuCauPhauThuat"]));
            }
            dr.Close();
            SQLCmd.Dispose();
            fgPhauThuat.Tag = "1";
            fgPhauThuat.AutoSizeCols();
            cmbXoaPhauThuat.Enabled = (fgPhauThuat.Rows.Count > 1);
            
        }
        private void Load_PhauThuat_ChiTiet(string MaBenhNhan, string LanVaoVien,byte LanPT)
        {
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            SQLCmd.CommandText = "SELECT *,TenLoaiPT,TenTCPT,TenVoCam,TenTaiBien,TenPPPT FROM (((((BENHNHAN_PHAUTHUAT LEFT JOIN DMLOAIPT ON BENHNHAN_PHAUTHUAT.LoaiPT=DMLOAIPT.MaLoaiPT)"
                               + " LEFT JOIN DMTINHCHATMO ON BENHNHAN_PHAUTHUAT.TinhChatPT=DMTINHCHATMO.MaTCPT) "
                               + " LEFT JOIN DMVOCAM ON BENHNHAN_PHAUTHUAT.VoCam=DMVOCAM.MaVoCam) "
                               + " LEFT JOIN DMTAIBIEN ON BENHNHAN_PHAUTHUAT.TaiBien=DMTAIBIEN.MaTaiBien) "
                               + " LEFT JOIN DMPHUONGPHAPPT ON BENHNHAN_PHAUTHUAT.PhuongPhapPT=DMPHUONGPHAPPT.MaPPPT) "
                               + " WHERE MaBenhNhan='" + MaBenhNhan + "' AND LanVaoVien=" + LanVaoVien + " AND LanPT=" + LanPT.ToString();
            dr = SQLCmd.ExecuteReader();
            Clear_Data_PhauThuat();
            while (dr.Read())
            {
                lblNgayPT.Text = string.Format("{0:dd/MM/yyyy}", dr["NgayPhauThuat"]);
                lblLoaiPT.Text = dr["TenLoaiPT"].ToString();
                lblTinhChatMo.Text = dr["TenTCPT"].ToString();
                lblPhuongPhapPT.Text = dr["TenPPPT"].ToString();
                lblPPVoCam.Text = dr["TenVoCam"].ToString();
                lblTaiBien.Text = dr["TenTaiBien"].ToString();                
                lblSoSanhCD.Text = "";
                switch (dr["SoSanh"].ToString())
                {
                    case "1":
                        lblSoSanhCD.Text = "Đúng";
                        break;
                    case "2":
                        lblSoSanhCD.Text = "Sai một phần";
                        break;
                    case "3":
                        lblSoSanhCD.Text = "Sai hoàn toàn";
                        break;                    
                }
            }
            dr.Close();
            SQLCmd.CommandText = string.Format("SELECT * FROM BENHNHAN_PT_KIPMO WHERE MaBenhNhan='{0}' AND LanVaoVien={1} AND LanPT={2} ORDER BY SoTTBS", MaBenhNhan, LanVaoVien, LanPT);
            fgKipMo.Rows.Count = 1;
            dr = SQLCmd.ExecuteReader();
            while (dr.Read())
            {
                fgKipMo.AddItem(string.Format("{0}|{1}|{2}",dr["soTTBS"],dr["TenBacSy"],dr["ViTri"]));
            }
            dr.Close();
            SQLCmd.Dispose();            
        }
        private void Load_ThongTinDieuTri(string MaBenhNhan, string LanVaoVien)
        {
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            SQLCmd.CommandText = string.Format("SELECT * FROM BENHNHAN_DIEUTRI "
                               + " WHERE MaBenhNhan='{0}' AND LanVaoVien={1} AND NgayThang='{2:MM/dd/yyyy}' AND MaKhoa='{3}'", MaBenhNhan, LanVaoVien, txtNgayCP.Value, Global.GetCode(cmbKhoa));
            dr = SQLCmd.ExecuteReader();
            txtMach_S.Value = txtMach_C.Value = null;
            txtHuyetAp1_S.Value = txtHuyetAp2_S.Value = txtHuyetAp1_C.Value = txtHuyetAp2_C.Value = null;
            txtNhietDo_S.Value = txtNhietDo_C.Value = null;
            txtThongTin_S.Text = txtThongTin_C.Text = "";
            while (dr.Read())
            {
                txtMach_S.Value = dr["Mach_S"];
                txtMach_C.Value = dr["Mach_C"];
                txtHuyetAp1_S.Value = dr["HuyetAp1_S"];
                txtHuyetAp2_S.Value = dr["HuyetAp2_S"];
                txtHuyetAp1_C.Value = dr["HuyetAp1_C"];
                txtHuyetAp2_C.Value = dr["HuyetAp2_C"];
                txtNhietDo_S.Value = dr["NhietDo_S"];
                txtNhietDo_C.Value = dr["NhietDo_C"];
                txtThongTin_S.Text = dr["ThongTin_S"].ToString();
                txtThongTin_C.Text = dr["ThongTin_C"].ToString();
            }
            dr.Close();
            SQLCmd.Dispose();            
        }
        private void Clear_Data_PhauThuat()
        {
            lblNgayPT.Text = "";
            lblLoaiPT.Text = "";
            lblTinhChatMo.Text = "";
            lblPPVoCam.Text = "";
            lblTaiBien.Text = "";
            lblSoSanhCD.Text = "";
            fgKipMo.Rows.Count = 1;
        }
        private void cmdPhauThuat_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.DuLieu.frmChiDinhPT fr = new frmChiDinhPT(txtMaBN.Text, txtHoTen.Text, txtLanVaoVien.Text, txtGioi.Text, txtDoiTuong.Text, txtNgayVaoVien.Text,0,null,"","");            
            fr.ShowDialog();
            if (fr.DialogResult == DialogResult.OK) { Load_PhauThuat(txtMaBN.Text, txtLanVaoVien.Text); }
        }

        private void fgPhauThuat_DoubleClick(object sender, EventArgs e)
        {
            if (fgPhauThuat.Row < 1 || fgPhauThuat.GetDataDisplay(fgPhauThuat.Row, 5).ToUpper() == "TRUE" ||!cmdPhauThuat.Enabled) { return; }
            byte LanPT = byte.Parse(fgPhauThuat.GetDataDisplay(fgPhauThuat.Row, 6));
            NamDinh_QLBN.Forms.DuLieu.frmChiDinhPT fr = new frmChiDinhPT(txtMaBN.Text, txtHoTen.Text, txtLanVaoVien.Text, txtGioi.Text, txtDoiTuong.Text, txtNgayVaoVien.Text, LanPT, fgPhauThuat[fgPhauThuat.Row, 2], fgPhauThuat.GetDataDisplay(fgPhauThuat.Row, 7), fgPhauThuat.GetDataDisplay(fgPhauThuat.Row, 8));           
            fr.ShowDialog();
            if (fr.DialogResult == DialogResult.OK) { Load_PhauThuat(txtMaBN.Text, txtLanVaoVien.Text); }
        }

        private void fgPhauThuat_AfterSelChange(object sender, C1.Win.C1FlexGrid.RangeEventArgs e)
        {
            if (fgPhauThuat.Tag.ToString() == "0" || e.NewRange.r1 <1) {return;}
            byte LanPT = byte.Parse(fgPhauThuat.GetDataDisplay(fgPhauThuat.Row, 6));
            Load_PhauThuat_ChiTiet(txtMaBN.Text, txtLanVaoVien.Text, LanPT);
            if (fgPhauThuat.Row > 0 && fgPhauThuat[fgPhauThuat.Row, 5].ToString().ToUpper() == "TRUE")
            {
                //panelPhauThuat_ChiTiet.Enabled = true;                
                label11.Text = "ĐÃ THỰC HIỆN PHẪU THUẬT";
                cmdTongketPT.Enabled = true;
            }
            else
            {
                label11.Text = "CHƯA THỰC HIỆN PHẪU THUẬT";
                //Clear_Data_PhauThuat();
            }
            if (fgPhauThuat.GetCellCheck(e.NewRange.r1,fgPhauThuat.Cols["DaThucHien"].Index) == C1.Win.C1FlexGrid.CheckEnum.Checked)
            {
                cmbXoaPhauThuat.Enabled = false;
            }
            else
            {
                cmbXoaPhauThuat.Enabled = true;
            }
        }

        private void fgChiTiet_BeforeEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            if (fgChiTiet.GetDataDisplay(e.Row,"LoaiCP") == "2" || fgChiTiet.GetDataDisplay(e.Row,"LoaiCP") =="") 
            { 
                e.Cancel = true; 
            }
            if ((fgChiTiet.GetCellCheck(e.Row, fgChiTiet.Cols["DaThucHien"].Index) == C1.Win.C1FlexGrid.CheckEnum.Checked) && (fgChiTiet.GetDataDisplay(e.Row, "LoaiCP") == "2" || fgChiTiet.GetDataDisplay(e.Row, "LoaiCP") == "1" || fgChiTiet.GetDataDisplay(e.Row, "LoaiCP") == "3" || fgChiTiet.GetDataDisplay(e.Row, "LoaiCP") == "")) 
            {
                e.Cancel = true;
            }
            if (fgChiTiet.GetDataDisplay(e.Row, "MaKhoa") != GlobalModuls.Global.glbMaKhoaPhong)
            {
                e.Cancel = true;
            }

        }

        private void fgChiTiet_BeforeDeleteRow(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            if (fgChiTiet.GetDataDisplay(e.Row, "LoaiCP") == "2" || fgChiTiet.GetDataDisplay(e.Row, "LoaiCP") == "")
            {
                e.Cancel = true;
            }
            if ((fgChiTiet.GetCellCheck(e.Row, fgChiTiet.Cols["DaThucHien"].Index) == C1.Win.C1FlexGrid.CheckEnum.Checked) && (fgChiTiet.GetDataDisplay(e.Row, "LoaiCP") == "2" || fgChiTiet.GetDataDisplay(e.Row, "LoaiCP") == "1" || fgChiTiet.GetDataDisplay(e.Row, "LoaiCP") == "3" || fgChiTiet.GetDataDisplay(e.Row, "LoaiCP") == ""))
            {
                e.Cancel = true;
            }
            if (fgChiTiet.GetDataDisplay(e.Row, "MaKhoa") != GlobalModuls.Global.glbMaKhoaPhong)
            {
                e.Cancel = true;
            }
        }

        private void cmdCopy_Click(object sender, EventArgs e)
        {
            CopyDuLieu();
        }
        private void CopyDuLieu()
        {
            try
            {
                string TenLoai = "";
                if (fgChiTiet.Rows.Count > 2)
                {
                    if (MessageBox.Show("Đã có dữ liệu ngày hiện tại,\nnếu copy dữ liệu từ ngày gần nhất thì dữ liệu hiện tại sẽ bị ghi đè\nBạn có chắc muốn copy không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) { return; }
                }
                System.Data.SqlClient.SqlDataReader dr;
                System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
                SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
                SQLCmd.CommandText = string.Format("SELECT TenLH,TenPP,TenLoai,BENHNHAN_CHIPHI.MaCP,TenCP,DVTinh,BENHNHAN_CHIPHI.SoLuong,BENHNHAN_CHIPHI.DonGia_QT,BENHNHAN_CHIPHI.DonGia,"
                        + " BENHNHAN_CHIPHI.LoaiDT,BENHNHAN_CHIPHI.MaDTTG, BENHNHAN_CHIPHI.LoaiChiPhi,DaThucHien,SoLuong*DonGia_QT As ThanhTien_QT,SoLuong*DonGia As ThanhTien,LanChiDinh,KetQua "
                        + " FROM (((BENHNHAN_CHIPHI INNER JOIN ViewDMCHIPHI ON BENHNHAN_CHIPHI.MaCP=ViewDMCHIPHI.MaCP AND BENHNHAN_CHIPHI.LoaiChiPhi = ViewDMCHIPHI.LoaiCP) "
                        + " INNER JOIN DMLOAICHIPHI ON BENHNHAN_CHIPHI.LoaiChiPhi=DMLOAICHIPHI.MaLoai) "
                        + " INNER JOIN DMLOAIHINHDT ON BENHNHAN_CHIPHI.LoaiDT=DMLOAIHINHDT.MaLH) "
                        + " LEFT JOIN DMPHUONGPHAPDIEUTRI ON MaDTTG=MaPP "
                        + " WHERE BENHNHAN_CHIPHI.MaBenhNhan='{0}' AND BENHNHAN_CHIPHI.LanVaoVien={1} AND BENHNHAN_CHIPHI.MaKhoa='{2}' "
                        + " AND BENHNHAN_CHIPHI.NgayCP=(SELECT Max(NgayCP) FROM BENHNHAN_CHIPHI WHERE MaBenhNhan='{0}' AND LanVaoVien={1} AND MaKhoa='{2}' AND NgayCP<'{3:MM/dd/yyyy}')"
                        + " AND LoaiChiPhi IN (SELECT ConfigValue FROM CONFIGS WHERE UName='{4}' AND ConfigName='LoaiChiPhi' AND Chon=1) "
                        + " ORDER BY LoaiDT,MaDTTG,BENHNHAN_CHIPHI.LoaiChiPhi",
                        txtMaBN.Text , txtLanVaoVien.Text, Global.GetCode(cmbKhoa), txtNgayCP.Value,Global.glbUName);

                dr = SQLCmd.ExecuteReader();
                fgChiTiet.Redraw = false;
                fgChiTiet.Rows.Count = 2;
                int STT = 1;
                string TenPPDT = "";
                while (dr.Read())
                {
                    if (TenLoai != dr["tenLoai"].ToString())
                    {
                        STT = 1;
                        TenLoai = dr["tenLoai"].ToString();
                    }
                    TenPPDT = string.Format("{0} ({1})", dr["TenPP"], dr["TenLH"]);
                    fgChiTiet.AddItem(string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6:#,###}|{7:#,###}|{8:#,###}|{9:#,###}|{10}|{11}|{12}|{13}|{14}|{15}|{16}",
                        TenPPDT, dr["TenLoai"], STT, dr["MaCP"], dr["TenCP"], dr["DVTinh"], dr["SoLuong"],
                        dr["DonGia"], dr["DonGia_QT"], dr["ThanhTien"], dr["ThanhTien_QT"], dr["LoaiChiPhi"], dr["DaThucHien"], dr["KetQua"], dr["LanChiDinh"], dr["LoaiDT"], dr["MaDTTG"]));
                    STT += 1;
                }
                dr.Close();
                SQLCmd.CommandText = string.Format("SELECT SUM(SoLuong*DonGia) AS TongLuyKe FROM BENHNHAN_CHIPHI WHERE MaBenhNhan='{0}' AND LanVaoVien={1} AND DaThucHien=1 AND (MaKhoa <> '{2}' OR NgayCP<>'{3:MM/dd/yyyy}')", txtMaBN.Text, txtLanVaoVien.Text, Global.GetCode(cmbKhoa), txtNgayCP.Value);
                dr = SQLCmd.ExecuteReader();
                dr.Read();
                lblLuyKe.Text = string.Format("{0:#,###}", dr["TongLuyKe"]);
                lblLuyKe.Tag = (dr["TongLuyKe"].ToString() == "") ? ("0") : (dr["TongLuyKe"].ToString());
                dr.Close();
                SQLCmd.Dispose();
                fgChiTiet.Tag = "1";
                fgChiTiet.Redraw = true;
                Tinh_Tien();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi copy dữ liệu\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void ThemTienMacDinh(int LoaiCP,string TenLoai)
        {
            string TenPPDT = cmbPhuongPhapDT.Text + " (" + cmbLoaiDT.Text + ")";
            try
            {
                string strAddItem = "";               
                System.Data.SqlClient.SqlDataReader dr;
                System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
                SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
                SQLCmd.CommandText = string.Format("SELECT * FROM "
                                                + " ((BENHNHAN_CHITIET INNER JOIN DMGIUONGBENH ON (BENHNHAN_CHITIET.Giuong=DMGIUONGBENH.ID_Giuong AND BENHNHAN_CHITIET.Buong=DMGIUONGBENH.ID_Buong AND maKhoa='{3}')) "
                                                + " INNER JOIN ViewDMCHIPHI ON DMGIUONGBENH.LoaiGiuong=MaCP AND LoaiCP={4}) "
                                                + " INNER JOIN DMCHIPHI_GIA ON ViewDMCHIPHI.MaCP=DMCHIPHI_GIA.MaCP AND DMCHIPHI_GIA.LoaiCP={4} "
                                                + " WHERE MucGia={0} AND MaBenhNhan='{1}' AND LanVaoVien={2}",
                                                MucGiaApDung,
                                                txtMaBN.Text,
                                                txtLanVaoVien.Text,
                                                Global.GetCode(cmbKhoa),LoaiCP);
                dr = SQLCmd.ExecuteReader();
                int STT = 1;
                while (dr.Read())
                {
                    strAddItem = string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}|{12}|{13}|{14}|{15}|{16}|{17}|{18}",
                                TenPPDT,TenLoai, STT, dr["MaCP"], dr["TenCP"], dr["DVTinh"],
                                1, dr["DonGia"], dr["DonGia_QT"], dr["DonGia"], dr["DonGia_QT"], LoaiCP, 1, "", 1,Global.GetCode(cmbLoaiDT),Global.GetCode(cmbPhuongPhapDT),Global.glbTenTatKhoaPhong,Global.glbMaKhoaPhong);

                    fgChiTiet.AddItem(strAddItem);                    
                }
                dr.Close();
                SQLCmd.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi thêm dữ liệu " + TenLoai + "\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void ThemTienAn()
        {
            int LoaiCP = 5;
            string TenPPDT = cmbPhuongPhapDT.Text + " (" + cmbLoaiDT.Text + ")";
            try
            {
                string strAddItem = "";
                System.Data.SqlClient.SqlDataReader dr;
                System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
                SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
                SQLCmd.CommandText = string.Format("SELECT * FROM  (BENHNHAN_CHITIET INNER JOIN ViewDMCHIPHI ON BENHNHAN_CHITIET.MucAn=ViewDMCHIPHI.MaCP AND ViewDMCHIPHI.LoaiCP=5) "
                                                + " INNER JOIN DMCHIPHI_GIA ON ViewDMCHIPHI.MaCp=DMCHIPHI_GIA.MaCP AND DMCHIPHI_GIA.LoaiCP=5 "
                                                + " WHERE MucGia={0} AND MaBenhNhan='{1}' AND LanVaoVien={2}",
                                                MucGiaApDung,
                                                txtMaBN.Text,
                                                txtLanVaoVien.Text);
                dr = SQLCmd.ExecuteReader();
                int STT = 1;
                while (dr.Read())
                {
                    strAddItem = string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6:#,###}|{7:#,###}|{8:#,###}|{9:#,###}|{10}|{11}|{12}|{13}|{14}|{15}|{16}|{17}|{18}",
                                TenPPDT,"Tiền ăn", STT, dr["MaCP"], dr["TenCP"], dr["DVTinh"],
                                1, dr["DonGia_QT"], dr["DonGia"], dr["DonGia_QT"], dr["DonGia"], LoaiCP, 1, "", 1, Global.GetCode(cmbLoaiDT), Global.GetCode(cmbPhuongPhapDT),Global.glbTenTatKhoaPhong,Global.glbMaKhoaPhong);

                    fgChiTiet.AddItem(strAddItem);
                }
                dr.Close();
                SQLCmd.Dispose();                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi thêm dữ liệu tiền ăn hàng ngày\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void cmbPhuongPhapDT_TextChanged(object sender, EventArgs e)
        {
            if (cmbPhuongPhapDT.Tag.ToString() == "0") { return; }
            string MaPPDT = Global.GetCode(cmbPhuongPhapDT);
            for (int i = 1; i < fgChiTiet.Rows.Count; i++)
            {
                if (fgChiTiet.GetDataDisplay(i, "LoaiDT") == Global.GetCode(cmbLoaiDT) && fgChiTiet.GetDataDisplay(i, "MaDTTG") == MaPPDT) { return; }
            }
            
            string strAddItem = "";
            string TenPPDT = cmbPhuongPhapDT.Text + " (" + cmbLoaiDT.Text + ")";
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            SQLCmd.CommandText = string.Format("SELECT TenLoai,ViewDMCHIPHI.MaCP,ViewDMCHIPHI.TenCP,ViewDMCHIPHI.DVTinh,PHUONGPHAPDT_CHIPHI.SoLuong,DMCHIPHI_GIA.DonGia,DMCHIPHI_GIA.DonGia_QT, "
                                            + " PHUONGPHAPDT_CHIPHI.SoLuong*DMCHIPHI_GIA.DonGia As ThanhTien,PHUONGPHAPDT_CHIPHI.SoLuong*DMCHIPHI_GIA.DonGia_QT As ThanhTien_QT,  PHUONGPHAPDT_CHIPHI.LoaiChiPhi "
                                            + " FROM  ((PHUONGPHAPDT_CHIPHI INNER JOIN ViewDMCHIPHI ON PHUONGPHAPDT_CHIPHI.MaChiPhi=ViewDMCHIPHI.MaCP AND PHUONGPHAPDT_CHIPHI.LoaiChiPhi=ViewDMCHIPHI.LoaiCP) "                                            
                                            + " INNER JOIN DMLOAICHIPHI ON PHUONGPHAPDT_CHIPHI.LoaiChiPhi=DMLOAICHIPHI.maLoai )"
                                            + " LEFT JOIN DMCHIPHI_GIA ON ViewDMCHIPHI.MaCp=DMCHIPHI_GIA.MaCP AND ViewDMCHIPHI.LoaiCP=DMCHIPHI_GIA.LoaiCP AND MucGia={0} "
                                            + " WHERE PHUONGPHAPDT_CHIPHI.MaPP='{1}'",
                                            MucGiaApDung,
                                            MaPPDT);
            dr = SQLCmd.ExecuteReader();
            fgChiTiet.Redraw = false;
            int STT = 1;
            int DaThucHien = 1;
            while (dr.Read())
            {
                if (cmbLoaiDT.SelectedIndex == 0 || cmbLoaiDT.SelectedIndex == 2 || cmbLoaiDT.SelectedIndex == 4)
                    DaThucHien = (dr["LoaiChiPhi"].ToString().CompareTo("4") == -1) ? (0) : (1);
                strAddItem = string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}|{12}|{13}|{14}|{15}|{16}|{17}|{18}",
                             TenPPDT, dr["TenLoai"], STT, dr["MaCP"], dr["TenCP"], dr["DVTinh"],
                            dr["SoLuong"], dr["DonGia"], dr["DonGia_QT"], dr["ThanhTien"], dr["ThanhTien_QT"], dr["LoaiChiPhi"], DaThucHien , "", 1, Global.GetCode(cmbLoaiDT), MaPPDT, Global.glbTenTatKhoaPhong, Global.glbMaKhoaPhong);
                fgChiTiet.AddItem(strAddItem);                
            }
            dr.Close();
            SQLCmd.Dispose();         
            fgChiTiet.Redraw = true;
            Tinh_Tien();
        }

        private void cmdNhap_Click(object sender, EventArgs e)
        {
            if (cmbLoaiDT.SelectedIndex == -1)
            {
                MessageBox.Show("Chưa chọn loại hình điều trị!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbLoaiDT.Focus();
                return;
            }
            //if (cmbPhuongPhapDT.SelectedIndex == -1)
            //{
            //    MessageBox.Show("Chưa chọn phương pháp điều trị!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    cmbPhuongPhapDT.Focus();
            //    return;
            //}
            fgChiTiet.Focus();
            NamDinh_QLBN.Forms.DuLieu.frmNhapCacChiPhi fr = new frmNhapCacChiPhi();
            fr.fg = this.fgChiTiet;
            fr.Left = this.Left;
            fr.MucGiaApDung = MucGiaApDung;
            fr.MaKhoaNhapLieu = Global.GetCode(cmbKhoa);
            fr.TenPhuongPhapDT = cmbPhuongPhapDT.Text + " (" + cmbLoaiDT.Text + ")";
            fr.MaPPDT = (Global.GetCode(cmbPhuongPhapDT) == null) ? ("") : (Global.GetCode(cmbPhuongPhapDT));
            fr.MaLoaiDT = Global.GetCode(cmbLoaiDT);
            fr.ShowDialog();
            fgChiTiet.Focus();
            Tinh_Tien();
        }

        private void sửaSốLượngChiPhíToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fgChiTiet.Row < 2) return;
            if (fgChiTiet.Rows[fgChiTiet.Row].IsNode) return;
            fgChiTiet.StartEditing(fgChiTiet.Row, fgChiTiet.Cols["SoLuong"].Index);
        }

        private void mnuXoa_Click(object sender, EventArgs e)
        {
            if ( fgChiTiet.Row < 2) return;
            if (fgChiTiet.Rows[fgChiTiet.Row].IsNode || (fgChiTiet.GetDataDisplay(fgChiTiet.Row, "LoaiCP") == "2" && fgChiTiet.GetDataDisplay(fgChiTiet.Row, "DaThucHien").ToLower() == "true")) return;
            fgChiTiet.RemoveItem(fgChiTiet.Row);
            Tinh_Tien();
        }

        private void fgChiTiet_MouseUp(object sender, MouseEventArgs e)
        {
            mnuSua.Enabled = false;
            mnuXoa.Enabled = false;
            if (e.Button == MouseButtons.Right)
            {
                if (fgChiTiet.MouseRow > 1)
                {
                    fgChiTiet.Row = fgChiTiet.MouseRow;
                    if (!fgChiTiet.Rows[fgChiTiet.Row].IsNode)
                    {
                        mnuSua.Enabled = true;
                        mnuXoa.Enabled = true;
                    }
                    if (fgChiTiet.GetDataDisplay(fgChiTiet.Row, "LoaiCP") == "2") { mnuSua.Enabled = false; }
                }
            }
        }

        private void cmbLoaiDS_TextChanged(object sender, EventArgs e)
        {
            if (cmbLoaiDS.Tag.ToString() == "0") return;
            cmdNhap.Enabled =
            cmdGhiChiTiet.Enabled =
            cmdCopy.Enabled =
            cmdPhauThuat.Enabled = (cmbLoaiDS.SelectedIndex == 0);
            grpNgay.Visible = !(cmbLoaiDS.SelectedIndex ==0);
            
            //if (rdDaRaVien.Checked) { grpNgay.Text = "Ngày ra viện"; }
            //grpNgay.Text = (cmbLoaiDS.SelectedIndex == 1) ? ("Ngày ra viện") : ("Ngày chuyển khoa");
            Load_DSBN(GlobalModuls.Global.GetCode(cmbKhoa));
        }

        private void fgDoiTuong_DoubleClick(object sender, EventArgs e)
        {
            //string MaCu = fgDoiTuong.GetDataDisplay(fgDoiTuong.Rows.Count - 1, 3);
            //string LanThayDoi = "0";
            //if (fgDoiTuong.Rows.Count > 1) { LanThayDoi = fgDoiTuong.GetDataDisplay(fgDoiTuong.Rows.Count - 1, 0); }
            //NamDinh_QLBN.Forms.DuLieu.frmCapNhatThongTinQuanLy fr = new frmCapNhatThongTinQuanLy(txtMaBN.Text,txtHoTen.Text, 1, MaCu, LanThayDoi, string.Format("{0:dd/MM/yyyy}", Global.NgayLV.Date), txtLanVaoVien.Text);
            //if (fr.ShowDialog()==DialogResult.OK)
            //{
            //    MessageBox.Show("Đã cập nhật vào hồ sơ bệnh nhân!\nBấm [OK] để đọc lại dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    this.tabControl1.SelectedTab = tabControl1.TabPages[0];
            //    Load_DSBN(Global.GetCode(cmbKhoa));
            //}
            
        }

        private void fgKhoaPhong_DoubleClick(object sender, EventArgs e)
        {
            //string MaCu = fgKhoaPhong.GetDataDisplay(fgKhoaPhong.Rows.Count - 1, 3);
            //string LanThayDoi = "0";
            //if (fgKhoaPhong.Rows.Count > 1) { LanThayDoi = fgKhoaPhong.GetDataDisplay(fgKhoaPhong.Rows.Count - 1, 0); }
            //NamDinh_QLBN.Forms.DuLieu.frmCapNhatThongTinQuanLy fr = new frmCapNhatThongTinQuanLy(txtMaBN.Text, txtHoTen.Text, 2, MaCu, LanThayDoi, string.Format("{0:dd/MM/yyyy}", Global.NgayLV.Date), txtLanVaoVien.Text);
            //if (fr.ShowDialog() == DialogResult.OK)
            //{
            //    MessageBox.Show("Đã cập nhật vào hồ sơ bệnh nhân!\nBấm [OK] để đọc lại dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    this.tabControl1.SelectedTab = tabControl1.TabPages[0];
            //    Load_DSBN(Global.GetCode(cmbKhoa));
            //}
        }

        private void cmdLoad_Click(object sender, EventArgs e)
        {
            Load_DSBN(Global.GetCode(cmbKhoa));
        }

        private void cmbXoaPhauThuat_Click(object sender, EventArgs e)
        {
            if (fgPhauThuat.Row < 1)
            {
                MessageBox.Show("Chưa chọn lần phẫu thuật của bệnh nhân", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("Bạn có chắc muốn xóa lần chỉ định phẫu thuật này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            string MaBN = txtMaBN.Text;
            string LanPT = fgPhauThuat[fgPhauThuat.Row, "LanPT"].ToString();
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
            System.Data.SqlClient.SqlTransaction trn;
            trn = Global.ConnectSQL.BeginTransaction();
            SQLCmd.Transaction = trn;
            try
            {
                SQLCmd.CommandText =string.Format("DELETE FROM BENHNHAN_PT_KIPMO WHERE MaBenhNhan='{0}' AND LanVaoVien={1} AND LanPT={2}",txtMaBN.Text,txtLanVaoVien.Text,LanPT);
                SQLCmd.ExecuteNonQuery();
                SQLCmd.CommandText = string.Format("DELETE FROM BENHNHAN_PHAUTHUAT WHERE MaBenhNhan='{0}' AND LanVaoVien={1} AND LanPT={2}", txtMaBN.Text, txtLanVaoVien.Text, LanPT);
                SQLCmd.ExecuteNonQuery();
                trn.Commit();
                fgPhauThuat.RemoveItem(fgPhauThuat.Row);
                MessageBox.Show("Đã xóa dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);                
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

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
            System.Data.SqlClient.SqlTransaction trn;
            trn = Global.ConnectSQL.BeginTransaction();
            SQLCmd.Transaction = trn;
            try
            {
                SQLCmd.CommandText = string.Format("DELETE FROM BENHNHAN_DIEUTRI WHERE MaBenhNhan='{0}' AND LanVaoVien={1} AND NgayThang='{2:MM/dd/yyyy}' AND MaKhoa='{3}'",txtMaBN.Text,txtLanVaoVien.Text,txtNgayCP.Value,Global.GetCode(cmbKhoa));
                SQLCmd.ExecuteNonQuery();
                SQLCmd.CommandText = string.Format("INSERT INTO BENHNHAN_DIEUTRI (MaBenhNhan,LanVaoVien,NgayThang,MaKhoa,Mach_S,Mach_C,HuyetAp1_S,HuyetAp1_C,HuyetAp2_S,HuyetAp2_C,NhietDo_S,NhietDo_C,ThongTin_S,ThongTin_C) " 
                                                    + " VALUES ('{0}',{1},'{2:MM/dd/yyyy}','{3}',{4},{5},{6},{7},{8},{9},{10},{11},N'{12}',N'{13}')",
                                                    txtMaBN.Text,txtLanVaoVien.Text,txtNgayCP.Value,Global.GetCode(cmbKhoa),
                                                    (txtMach_S.ValueIsDbNull)?("null"):(txtMach_S.Value),
                                                    (txtMach_C.ValueIsDbNull)?("null"):(txtMach_C.Value),
                                                    (txtHuyetAp1_S.ValueIsDbNull)?("null"):(txtHuyetAp1_S.Value),
                                                    (txtHuyetAp1_C.ValueIsDbNull)?("null"):(txtHuyetAp1_C.Value),
                                                    (txtHuyetAp2_S.ValueIsDbNull)?("null"):(txtHuyetAp2_S.Value),
                                                    (txtHuyetAp2_C.ValueIsDbNull)?("null"):(txtHuyetAp2_C.Value),
                                                    (txtNhietDo_S.ValueIsDbNull)?("null"):(txtNhietDo_S.Value),
                                                    (txtNhietDo_C.ValueIsDbNull)?("null"):(txtNhietDo_C.Value),
                                                    txtThongTin_S.Text,
                                                    txtThongTin_C.Text);
                SQLCmd.ExecuteNonQuery();
                trn.Commit();
                MessageBox.Show("Đã ghi dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (fgPhauThuat.Rows.Count ==1 || lblNgayPT.Text =="") return;
            byte LanPT = byte.Parse(fgPhauThuat.GetDataDisplay(fgPhauThuat.Row, 6));
            NamDinh_QLBN.Forms.DuLieu.frmXacNhanPhauThuat_ChiTiet fr = new frmXacNhanPhauThuat_ChiTiet(txtMaBN.Text,LanPT,byte.Parse(txtLanVaoVien.Text));
            fr.ShowDialog();           
            Load_PhauThuat_ChiTiet(txtMaBN.Text, txtLanVaoVien.Text, LanPT);
        }

        private void fgDoiTuong_Click(object sender, EventArgs e)
        {

        }
    }
}