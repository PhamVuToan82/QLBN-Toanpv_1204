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
using System.IO;
using C1.Win.C1FlexGrid;
namespace NamDinh_QLBN.Forms.DuLieu
{
    public partial class frmBenhnhan_Dovai : Form
    {
        public frmBenhnhan_Dovai()
        {
            InitializeComponent();
        }
        bool themmoi = false;
        bool Flag = false;
        bool doitra = false;
        bool sua = false;
        int hoantien = 0;
        DateTime ngay = Global.GetNgayLV();
        private void frmBenhnhan_Dovai_Load(object sender, EventArgs e)
        {
            txtTuNgay.Value = DateNgayKham.Value = Global.GetNgayLV();
            txtDenNgay.Value =  Global.GetNgayLV().AddDays(1);
            fgDichVu.ClipSeparators = "|;";
            Load_BenhNhan();
            
        }
        private void Load_BenhNhan()
        {
            fgDanhSach.Redraw = false;
            fgDanhSach.Rows.Count = 1;
            fgDanhSach.ClipSeparators = "|;";
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
            SQLCmd.CommandTimeout = 0;
            SQLCmd.CommandText = string.Format("set dateformat dmy select a.MaKhambenh, C.TenBenhnhan,a.ThoigianDangky, D.TenKhoa, C.Namsinh,case when C.Gioitinh = 0 then N'Nữ' else N'Nam' end as Gioitinh, a.Diachi,isnull(E.HoanTien,0) as HoanTien,isNull(E.NguoiNhaBn,'') as NguoiNhaBn from NAMDINH_KHAMBENH.dbo.tblKHAMBENH a inner join NAMDINH_KHAMBENH.dbo.tblKHAMBENH_KQDVKHAM B ON a.MaKhambenh = B.MaKhambenh "
                                                + " INNER JOIN NAMDINH_KHAMBENH.dbo.tblbenhnhan  C ON C.MaBenhnhan = A.MaBenhnhan"
                                                + " INNER JOIN NAMDINH_SYSDB.dbo.DMKHOAPHONG D ON D.MaKhoa = B.Nhapvien_Khoa"
                                                + " Left Join tblbenhnhan_muonvai E on E.MaKhamBenh = a.MaKhamBenh"
                                                + " where datediff(day, a.ThoigianDangky,'{0:dd/MM/yyyy}') = 0 AND B.HuongGQ = 5 order by c.tenbenhnhan", DateNgayKham.Value);
            System.Data.SqlClient.SqlDataReader dr = SQLCmd.ExecuteReader();
            while (dr.Read())
            {
                fgDanhSach.AddItem(string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|", fgDanhSach.Rows.Count,
                                    dr["MaKhambenh"],
                                    dr["TenBenhnhan"],
                                    dr["ThoigianDangky"],
                                    dr["TenKhoa"], dr["Namsinh"], dr["Gioitinh"], dr["Diachi"], dr["HoanTien"],dr["NguoiNhaBn"]));
                fgDanhSach.Styles.Normal.WordWrap = true;
            }
            dr.Close();
            SQLCmd.Dispose();
            fgDanhSach.Redraw = true;
        }
        private void DateNgayKham_ValueChanged(object sender, EventArgs e)
        {
            Load_BenhNhan();
        }
        private void fgDanhSach_Click(object sender, EventArgs e)
        {
            txtMaKhamBenh.Text = fgDanhSach.GetDataDisplay(fgDanhSach.Row, "MaKhambenh");
            txtHoTen.Text = fgDanhSach.GetDataDisplay(fgDanhSach.Row, "TenBenhnhan");
            txtTuoi.Text = fgDanhSach.GetDataDisplay(fgDanhSach.Row, "Namsinh");
            txtGioi.Text = fgDanhSach.GetDataDisplay(fgDanhSach.Row, "Gioitinh");
            txtKhoa.Text = fgDanhSach.GetDataDisplay(fgDanhSach.Row, "TenKhoa");
            txtDiaChi.Text = fgDanhSach.GetDataDisplay(fgDanhSach.Row, "Diachi");
            dateThoiGiangDangKy.Value = fgDanhSach.GetDataDisplay(fgDanhSach.Row, "ThoigianDangky");
            txtNguoiNha.Text = fgDanhSach.GetDataDisplay(fgDanhSach.Row, "NguoiNhaBn");
            LoadBenhNhan_MuonVai(fgDanhSach.GetDataDisplay(fgDanhSach.Row, "MaKhambenh"));
            if (fgDanhSach.GetDataDisplay(fgDanhSach.Row, "HoanTien") == "1")
            {
                Item_lock(false);
            }
            else
            {
                Item_lock(true);
            }
            btnGhi.Enabled = false;
            fgDichVu.Enabled = false;
            sua = false;
            themmoi = false;
            doitra = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fgDanhSach.Rows.Count = 1;
            fgDanhSach.ClipSeparators = "|;";
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
            SQLCmd.CommandTimeout = 0;
            SQLCmd.CommandText = string.Format("set dateformat dmy select a.MaKhambenh, C.TenBenhnhan,a.ThoigianDangky, D.TenKhoa, C.Namsinh,case when C.Gioitinh = 0 then N'Nữ' else N'Nam' end as Gioitinh, a.Diachi,isnull(E.HoanTien,0) as HoanTien, isNull(E.NguoiNhaBn,'') as NguoiNhaBn from NAMDINH_KHAMBENH.dbo.tblKHAMBENH a inner join NAMDINH_KHAMBENH.dbo.tblKHAMBENH_KQDVKHAM B ON a.MaKhambenh = B.MaKhambenh "
                                                + " INNER JOIN NAMDINH_KHAMBENH.dbo.tblbenhnhan  C ON C.MaBenhnhan = A.MaBenhnhan"
                                                + " INNER JOIN NAMDINH_SYSDB.dbo.DMKHOAPHONG D ON D.MaKhoa = B.Nhapvien_Khoa"
                                                + " Left Join tblbenhnhan_muonvai E on E.MaKhamBenh = a.MaKhamBenh"
                                                + " where  a.ThoigianDangky between '{0:dd/MM/yyyy}' and '{1:dd/MM/yyyy}' AND B.HuongGQ = 5 order by c.tenbenhnhan", txtTuNgay.Value,txtDenNgay.Value);
            System.Data.SqlClient.SqlDataReader dr = SQLCmd.ExecuteReader();
            while (dr.Read())
            {
                fgDanhSach.AddItem(string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|", fgDanhSach.Rows.Count,
                                    dr["MaKhambenh"],
                                    dr["TenBenhnhan"],
                                    dr["ThoigianDangky"],
                                    dr["TenKhoa"], dr["Namsinh"], dr["Gioitinh"], dr["Diachi"], dr["HoanTien"],dr["NguoiNhaBn"]));
                fgDanhSach.Styles.Normal.WordWrap = true;
            }
            dr.Close();
            SQLCmd.Dispose();
        }
        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            fgDichVu.Enabled = true;
            btn_sua.Enabled = false;
            button2.Enabled = false;
            btnThemMoi.Enabled = false;
            btnGhi.Enabled = true;
            themmoi = true;
            checkBox1.Checked =  true;
            fgDichVu.Rows.Count = 1;
            DateTime NgayLV = Global.GetNgayLV();
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
            SQLCmd.CommandText = string.Format("select [MaDoVai], [TenDoVai], [GhiChu], [MaLoaiDoVai], [Dvt] from NAMDINH_QLBN.dbo.tblDoVai");
            System.Data.SqlClient.SqlDataReader dr = SQLCmd.ExecuteReader();
            while (dr.Read())
            {
                fgDichVu.AddItem(string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6:dd/MM/yyyy HH:mm}|{7}|{8}|", fgDichVu.Rows.Count,
                                    dr["MaDoVai"],
                                    dr["TenDoVai"],1,
                                    dr["Dvt"],1,NgayLV,
                                    dr["GhiChu"], dr["MaLoaiDoVai"]));
                fgDichVu.Styles.Normal.WordWrap = true;
            }
            dr.Close();
            SQLCmd.Dispose();
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            button2.Enabled = true;
            btn_sua.Enabled = true;
            btnThemMoi.Enabled = true;
            btnGhi.Enabled = false;
            fgDichVu.Enabled = false;
            int dakyquy;
            // Thêm mới phiếu
                if (themmoi == true)
                {
                    System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
                    SQLCmd.CommandText = string.Format("select dbo.LaySoPhieu_MuonVai(Right(Convert(nvarchar(8),'{0:yyyyMMdd}',112),6)) As SoPhieu", ngay);
                    string maphieumuon = SQLCmd.ExecuteScalar().ToString();
                    SQLCmd.CommandText = string.Format("If EXISTS (SELECT MaKhambenh FROM tblbenhnhan_muonvai WHERE MaKhambenh='{0}') "
                                                + " UPDATE tblbenhnhan_muonvai SET TenBenhnhan=N'{1}',Namsinh='{2}',Gioitinh=N'{3}',TenKhoa=N'{4}',Diachi=N'{5}',ThoigianDangky='{6:dd/MM/yyyy HH:mm}' ,NguoiNhaBn = N'{7}' WHERE MaKhambenh='{0}'"
                                                + " ELSE "
                                                + " INSERT INTO tblbenhnhan_muonvai (MaKhambenh,TenBenhnhan,Namsinh,Gioitinh,TenKhoa,Diachi,ThoigianDangky,NguoiNhaBn) VALUES ('{0}',N'{1}','{2}',N'{3}',N'{4}',N'{5}','{6:dd/MM/yyyy HH:mm}',N'{7}')",
                                                txtMaKhamBenh.Text, txtHoTen.Text.Replace("'", "''"),
                                                int.Parse(txtTuoi.Text), txtGioi.Text, txtKhoa.Text, txtDiaChi.Text, dateThoiGiangDangKy.Value,txtNguoiNha.Text);
                    SQLCmd.CommandText = SQLCmd.CommandText + string.Format("INSERT INTO tblMaPhieuMuon_Vai(MaPhieuMuon,NgayMuon) VALUES('{0}','{1:dd/MM/yyyy HH:mm}')", maphieumuon,ngay);
                    if (checkBox1.Checked == true)
                    {
                        SQLCmd.CommandText = SQLCmd.CommandText + string.Format(" INSERT INTO tblbenhnhan_Vai_KyQuy (MaPhieuMuon,KyQuy,NgayKy,MaKhamBenh,NguoiNhaBn_Kq) VALUES ('{0}',N'{1}','{2:dd/MM/yyyy HH:mm}','{3}',N'{4}')", maphieumuon, decimal.Parse(txtkyquy.Text), ngay, txtMaKhamBenh.Text,txtNguoiNha.Text);
                         dakyquy = 1;
                    }
                    else
                    {
                        dakyquy = 0;
                    }
                    for (int num = 1; num < this.fgDichVu.Rows.Count; num++)
                    {
                        if(kiemtra() == false && checkBox1.Checked == true)
                        {
                            MessageBox.Show("Bệnh nhân không mượn đồ vải nào không ký được qũy");
                            btn_sua.Enabled = false;
                            themmoi = false;
                            LoadBenhNhan_MuonVai(txtMaKhamBenh.Text);
                            return;
                        }
                        if (!this.fgDichVu.Rows[num].IsNode)
                        {
                            if (fgDichVu[num, "Chon"].ToString().ToLower() == "true")
                            {
                                SQLCmd.CommandText = SQLCmd.CommandText + string.Format(" INSERT INTO tblPhieuMuon_Vai (MaKhamBenh,MaLoaiDoVai,MaDoVai,NgayMuon,Soluong,KhoaDT,TenDoVai,MaPhieuMuon,GhiChu,Dadoi,DaKyQuy) VALUES ('{0}',N'{1}',N'{2}','{3:dd/MM/yyyy HH:mm}',N'{4}',N'{5}',N'{6}',N'{7}',N'{8}','{9}','{10}')", new object[] {
                                                txtMaKhamBenh.Text,this.fgDichVu[num, "MaLoaiDoVai"], this.fgDichVu[num, "MaDoVai"],this.fgDichVu[num, "ngay"],this.fgDichVu[num, "SoLuong"],txtKhoa.Text,this.fgDichVu[num, "TenDoVai"],maphieumuon,this.fgDichVu[num, "GhiChu"],0,dakyquy });
                            }
                        }
                    }
                    SQLCmd.ExecuteNonQuery();
                themmoi = false;
            }
                // Sửa phiếu
                if(sua == true)
                {
                    System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
                    SQLCmd.CommandText = string.Format("delete FROM tblPhieuMuon_Vai WHERE MaKhambenh='{0}'", txtMaKhamBenh.Text);
                    for (int num = 1; num < this.fgDichVu.Rows.Count; num++)
                    {
                        if (!this.fgDichVu.Rows[num].IsNode)
                        {
                            if (fgDichVu[num, "Chon"].ToString().ToLower() == "true")
                            {
                                SQLCmd.CommandText = SQLCmd.CommandText + string.Format(" INSERT INTO tblPhieuMuon_Vai (MaKhamBenh,MaLoaiDoVai,MaDoVai,NgayMuon,Soluong,KhoaDT,TenDoVai,MaPhieuMuon,GhiChu,Dadoi,DaKyQuy) VALUES ('{0}',N'{1}',N'{2}','{3:dd/MM/yyyy HH:mm}',N'{4}',N'{5}',N'{6}',N'{7}',N'{8}','{9}','{10}')", new object[] {
                                                txtMaKhamBenh.Text,this.fgDichVu[num, "MaLoaiDoVai"], this.fgDichVu[num, "MaDoVai"],this.fgDichVu[num, "ngay"],this.fgDichVu[num, "SoLuong"],txtKhoa.Text,this.fgDichVu[num, "TenDoVai"],this.fgDichVu[num, "MaPhieuMuon"],this.fgDichVu[num, "GhiChu"],fgDichVu[num, "Dadoi"],fgDichVu[num, "DaKyQuy"] });
                            }
                        }
                    }
                    SQLCmd.ExecuteNonQuery();
                sua = false;
            }
                // Đổi đồ vải
            if(doitra == true)
            {
                System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
                SQLCmd.CommandText = string.Format("Select  isnull(NgayDoi,'2000-00-00') as NgayDoiGanNhat, MaDoVai,MaPhieuMuon from tblPhieuDoi_Vai where Makhambenh = '{0}'and NgayDoi = (select MAX(NgayDoi) from tblPhieuDoi_Vai b  where MakhamBenh = '{0}' and tblPhieuDoi_Vai.MaDoVai = b.MaDoVai and tblPhieuDoi_Vai.MaPhieuMuon = b.MaPhieuMuon) ", txtMaKhamBenh.Text);
                System.Data.SqlClient.SqlDataReader dr = SQLCmd.ExecuteReader();
                while (dr.Read())
               { 
                    for (int num = 1; num < this.fgDichVu.Rows.Count; num++)
                    {
                        if ((fgDichVu[num, "Chon"].ToString().ToLower() == "true") && (fgDichVu[num, "MaDoVai"].ToString() == dr["MaDoVai"].ToString()) && (fgDichVu[num, "MaPhieuMuon"].ToString() == dr["MaPhieuMuon"].ToString()))
                        {
                            TimeSpan Time = (DateTime.Parse(fgDichVu[num, "ngay"].ToString()) - DateTime.Parse(dr["NgayDoiGanNhat"].ToString()));
                            if (Time.TotalHours <= 24)
                            {
                                MessageBox.Show("Bệnh nhân đã đổi " + fgDichVu[num, "TenDoVai"].ToString() + " Thời gian gần nhất là: " + dr["NgayDoiGanNhat"].ToString());
                                dr.Close();
                                doitra = false;
                                LoadBenhNhan_MuonVai(txtMaKhamBenh.Text);
                                return;
                            }
                        }
                    }
                }
                dr.Close();
                SQLCmd.CommandText = "";
                SQLCmd.CommandText = string.Format("select dbo.LaySoPhieu_TRAVAI(Right(Convert(nvarchar(8),'{0:yyyyMMdd}',112),6)) As SoPhieu", ngay);
                string MaPhieuDoi = SQLCmd.ExecuteScalar().ToString();
                //SQLCmd.CommandText = string.Format("delete FROM tblPhieuMuon_Vai WHERE MaKhambenh='{0}'", txtMaKhamBenh.Text);
                for (int num = 1; num < this.fgDichVu.Rows.Count; num++)
                {

                    if (!this.fgDichVu.Rows[num].IsNode)
                    {
                        if (fgDichVu[num, "Chon"].ToString().ToLower() == "true")
                        {
                            SQLCmd.CommandText = SQLCmd.CommandText + string.Format(" Update tblPhieuMuon_Vai set DaDoi = '1' where MaDoVai = '{0}' and MaPhieuMuon = '{1}'", this.fgDichVu[num, "MaDoVai"], this.fgDichVu[num, "MaPhieuMuon"]);
                            SQLCmd.CommandText = SQLCmd.CommandText + string.Format(" INSERT INTO tblPhieuDoi_Vai ([MakhamBenh], [MaPhieuDoi], [MaDoVai], [MaLoaiDoVai], [TenDoVai], [Soluong_doi], [NgayDoi], [KhoaDoi],[MaPhieuMuon]) VALUES ('{0}',N'{1}',N'{2}',N'{3}',N'{4}',N'{5}',N'{6:dd/MM/yyyy HH:mm}',N'{7}','{8}')", new object[] {
                                                txtMaKhamBenh.Text,MaPhieuDoi,this.fgDichVu[num, "MaDoVai"], this.fgDichVu[num, "MaLoaiDoVai"],this.fgDichVu[num, "TenDoVai"],this.fgDichVu[num, "SoLuong"],this.fgDichVu[num, "ngay"],txtKhoa.Text, this.fgDichVu[num, "MaPhieuMuon"] });
                        }
                    }
                }
                SQLCmd.ExecuteNonQuery();
                doitra = false;
            }
            LoadBenhNhan_MuonVai(txtMaKhamBenh.Text);
            themmoi = false;
            sua = false;
            doitra = false;
        }

        private void LoadBenhNhan_MuonVai(string MakhamBenh)
        {
            fgDichVu.Rows.Count = 1;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
            SQLCmd.CommandText = string.Format("select a.MaKhamBenh,a.MaLoaiDoVai,a.MaDoVai,a.NgayMuon,a.Soluong,a.KhoaDT,a.TenDoVai,a.MaPhieuMuon,b.GhiChu,b.dvt,a.Dadoi,a.DaKyQuy from NAMDINH_QLBN.dbo.tblPhieuMuon_Vai a inner join  NAMDINH_QLBN.dbo.tblDoVai b on a.MaDoVai = b.MaDoVai and a.MaLoaiDoVai = b.MaLoaiDoVai where MaKhamBenh = '{0}'", MakhamBenh);
            System.Data.SqlClient.SqlDataReader dr = SQLCmd.ExecuteReader();
            while (dr.Read())
            {
                fgDichVu.AddItem(string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6:dd/MM/yyyy HH:mm}|{7}|{8}|{9}|{10}|{11}|", fgDichVu.Rows.Count,
                                    dr["MaDoVai"],
                                    dr["TenDoVai"], dr["Soluong"],
                                    dr["Dvt"], 1, dr["NgayMuon"],
                                    dr["GhiChu"], dr["MaLoaiDoVai"],dr["MaPhieuMuon"], dr["Dadoi"], dr["DaKyQuy"]));
                fgDichVu.Styles.Normal.WordWrap = true;
            }
            dr.Close();
            SQLCmd.Dispose();

        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            sua = true;
            btnThemMoi.Enabled = false;
            button2.Enabled = false;
            fgDichVu.Enabled = true;
            btnGhi.Enabled = true;
            btn_sua.Enabled = false;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            doitra = true;
            fgDichVu.Enabled = true;
            btnGhi.Enabled = true;
            btnThemMoi.Enabled = false;
            btn_sua.Enabled = false;
            button2.Enabled = false;
            DateTime NgayDoi = Global.GetNgayLV();
            for (int num = 1; num < this.fgDichVu.Rows.Count; num++)
            {
                if (!this.fgDichVu.Rows[num].IsNode)
                {
                    fgDichVu[num, "ngay"] = string.Format("{0:dd/MM/yyyy HH:mm}", NgayDoi);
                }
            }
        }

        private void fgDichVu_BeforeDeleteRow(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            if (fgDichVu.GetDataDisplay(this.fgDichVu.Row, "Dadoi").ToLower() == "1")
            {
                MessageBox.Show("Bệnh nhân đã đổi ");
                e.Cancel = true;
                return;
            }
            if (fgDichVu.GetDataDisplay(this.fgDichVu.Row, "DaKyQuy").ToLower() == "1")
            {
                MessageBox.Show("Bệnh nhân đã Ký Quỹ");
                e.Cancel = true;
                return;
            }
        }

        private void btnHoanTien_Click(object sender, EventArgs e)
        {
            FrmHoanTien frm = new FrmHoanTien(txtMaKhamBenh.Text,txtHoTen.Text,txtTuoi.Text,txtGioi.Text,txtDiaChi.Text,txtKhoa.Text,this.fgDanhSach);
            frm.Show();
        }
        public void Item_lock(bool Dong)
        {
            if(!Dong)
            {
                btnGhi.Enabled = false;
                btnThemMoi.Enabled = false;
                //btnHoanTien.Enabled = false;
                btn_sua.Enabled = false;
                button2.Enabled = false;
                fgDichVu.Enabled = false;
            }
            else
            { 
                btnGhi.Enabled = true;
                btnThemMoi.Enabled = true;
                //btnHoanTien.Enabled = true;
                btn_sua.Enabled = true;
                button2.Enabled = true;
                fgDichVu.Enabled = true;
            }
        }

        private bool kiemtra()
        {
            for (int num = 1; num < this.fgDichVu.Rows.Count; num++)
            {
                if (fgDichVu[num, "Chon"].ToString().ToLower() == "true")
                {
                    return true;
                    break;
                }
            }
                return false;
        }
        private void btn_In_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Reports.repPhieuMuonVai rpt = new Reports.repPhieuMuonVai(txtMaKhamBenh.Text);
            NamDinh_QLBN.Reports.repPhieuMuonVai_2 rpt_2 = new Reports.repPhieuMuonVai_2(txtMaKhamBenh.Text);
            rpt.Show();
            rpt_2.Show();
        }
  
        private void fgDichVu_AfterEdit(object sender, RowColEventArgs e)
        {
            if (sua == true)
            {
                if (fgDichVu.GetDataDisplay(this.fgDichVu.Row, "Dadoi").ToLower() == "1")
                {
                    MessageBox.Show("Bệnh nhân đã đổi ");
                    fgDichVu[fgDichVu.Row, "Chon"] = "True";
                    btnThemMoi.Enabled = false;
                    button2.Enabled = false;
                    e.Cancel = true;
                    return;
                }
                if (fgDichVu.GetDataDisplay(this.fgDichVu.Row, "DaKyQuy").ToLower() == "1")
                {
                    MessageBox.Show("Bệnh nhân đã Ký Quỹ");
                    e.Cancel = true;
                    fgDichVu[fgDichVu.Row, "Chon"] = "True";
                    return;
                }
            }
        }

        private void fgDanhSach_AfterEdit(object sender, RowColEventArgs e)
        {
            //if (fgDanhSach.GetDataDisplay(fgDanhSach.Row, "HoanTien") == "1")
            //{
            //    Item_lock(true);
            //}
            //else
            //{
            //    Item_lock(false);
            //}
            if (fgDanhSach[fgDanhSach.Row,"HoanTien"].ToString() == "1")
            {
                Item_lock(true);
            }
            else
            {
                Item_lock(false);
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if(txtMaKhamBenh.Text == "")
            {
                MessageBox.Show("Mã khám bệnh không được để trống","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                return;
            }
            fgDanhSach.Rows.Count = 1;
            fgDanhSach.ClipSeparators = "|;";
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
            SQLCmd.CommandTimeout = 0;
            SQLCmd.CommandText = string.Format("set dateformat dmy select a.MaKhambenh, C.TenBenhnhan,a.ThoigianDangky, D.TenKhoa, C.Namsinh,case when C.Gioitinh = 0 then N'Nữ' else N'Nam' end as Gioitinh, a.Diachi,isnull(E.HoanTien,0) as HoanTien, isNull(E.NguoiNhaBn,'') as NguoiNhaBn from NAMDINH_KHAMBENH.dbo.tblKHAMBENH a inner join NAMDINH_KHAMBENH.dbo.tblKHAMBENH_KQDVKHAM B ON a.MaKhambenh = B.MaKhambenh "
                                                + " INNER JOIN NAMDINH_KHAMBENH.dbo.tblbenhnhan  C ON C.MaBenhnhan = A.MaBenhnhan"
                                                + " INNER JOIN NAMDINH_SYSDB.dbo.DMKHOAPHONG D ON D.MaKhoa = B.Nhapvien_Khoa"
                                                + " Left Join tblbenhnhan_muonvai E on E.MaKhamBenh = a.MaKhamBenh"
                                                + " where a.MaKhamBenh = '{0}' AND B.HuongGQ = 5 order by c.tenbenhnhan", txtMaKhamBenh.Text);
            System.Data.SqlClient.SqlDataReader dr = SQLCmd.ExecuteReader();
            while (dr.Read())
            {
                fgDanhSach.AddItem(string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|", fgDanhSach.Rows.Count,
                                    dr["MaKhambenh"],
                                    dr["TenBenhnhan"],
                                    dr["ThoigianDangky"],
                                    dr["TenKhoa"], dr["Namsinh"], dr["Gioitinh"], dr["Diachi"], dr["HoanTien"],dr["NguoiNhaBn"]));
                fgDanhSach.Styles.Normal.WordWrap = true;
            }
            dr.Close();
            SQLCmd.Dispose();
            LoadBenhNhan_MuonVai(txtMaKhamBenh.Text);
            fgDanhSach_Click(sender,e);
        }

        private void DateNgayKham_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void btnSoTongHop_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.Tien_ich.frmTNgayDNgay_Vai frm = new Tien_ich.frmTNgayDNgay_Vai();
            frm.Show();
            //if(frm._MuonVai == true)
            //{
            //    NamDinh_QLBN.Reports.repSoVai rpt = new NamDinh_QLBN.Reports.repSoVai(frm._TNgay, frm._DNgay, frm._TenKhoa);
            //    rpt.Show();
            //}
        }

        private void fgDanhSach_ChangeEdit(object sender, EventArgs e)
        {
            if (fgDanhSach.GetDataDisplay(fgDanhSach.Row, "HoanTien") == "1")
            {
                Item_lock(true);
            }
            else
            {
                Item_lock(false);
            }

        }

    }
}
