using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using GlobalModuls;
using System.Net;
using System.Collections.Specialized;
namespace NamDinh_QLBN.Forms.DuLieu
{
    public partial class frmChuyenDien : Form
    {
        private bool Add, Edit;
        public string MaBN;
        public int LanVV, CapCuu;
        public SqlCommand SQLcmd = new SqlCommand("", GlobalModuls.Global.ConnectSQL);
        public SqlDataReader dr;
        public string Makhambenh, maloi = "";
        public string Access_Token;
        public string IDToken;
        public string MaKetQua;
        public string Ho_Ten = "";
        public string Nam_Sinh= "";
        public string Gioi_Tinh= "";
        public string Noi_DKCBBD= "";
        public string SotheBHYT = "";
        public string MaQuyenLoi = "";
        public frmChuyenDien()
        {
            InitializeComponent();
            //Global.GetSession();
            //string s = Global.IDToken;
        }

        private void EnableEdit(bool Flag)
        {
            txtNgayThayDoi.ReadOnly = !Flag;
            cmbDoiTuongBN.ReadOnly = !Flag;
            cmbTuyen.ReadOnly = !Flag;
            dtBHTu.ReadOnly = !Flag;
            dtBHDen.ReadOnly = !Flag;
            txtSoTheBHYT.ReadOnly = !Flag;
            txtTenDT.ReadOnly = !Flag;
            txtTennoicap.ReadOnly = !Flag;
            txtMaDT.ReadOnly = !Flag;
            txtManoicap.ReadOnly = !Flag;
            txtTenBHYTTinh.ReadOnly = !Flag;
            txtbarcode.Enabled = Flag;
            txtMaKhamBenh.ReadOnly = Flag;
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
        }

        private void LoadDoiTuongBN()
        {
            String Str = "SELECT * FROM DMDOITUONGBN where MaDT in (1,3)";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(Str, GlobalModuls.Global.ConnectSQL);
            System.Data.DataSet ds = new DataSet();
            System.Data.SqlClient.SqlDataAdapter ad = new System.Data.SqlClient.SqlDataAdapter(cmd);
            ad.Fill(ds);

            cmbDoiTuongBN.AddItemSeparator = '|';
            foreach (System.Data.DataRow Row in ds.Tables[0].Rows)
            {
                cmbDoiTuongBN.AddItem(String.Format("{0}|{1}", Row["MaDT"], Row["TenDT"]));
            }
            cmbDoiTuongBN.SelectedIndex = -1;
            ds.Dispose();
            ad.Dispose();
            cmd.Dispose();
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

            cmbTenNoiChuyen.ClearItems();
            SQLCmd.CommandText = "select Tennoicap,MaNoiCap from NAMDINH_SYSDB.dbo.DMNOIDKKCBBD_BHYT where isNoiChuyen = 1";
            SqlDataReader reader = SQLCmd.ExecuteReader();
            while (reader.Read())
            {
                this.cmbTenNoiChuyen.AddItem(string.Format("{0};{1}", reader["MaNoiCap"], reader["Tennoicap"]));
            }
            reader.Close();
            cmbTenNoiChuyen.Tag = "1";
            cmbTenNoiChuyen.SelectedIndex = -1;

            cmbDoituongBN1.ClearItems();
            cmbDoituongBN1.AddItem(String.Format("{1}|{0}", "", "------ Tất cả các đối tượng ------"));
            SQLcmd.CommandText = "Select MaDT, TenDT from DMDoiTuongBN order by MaDT";
            dr = SQLcmd.ExecuteReader();
            while (dr.Read())
            {
                cmbDoituongBN1.AddItem(String.Format("{1}|{0}", dr["MaDT"], dr["TenDT"]));
            }
            dr.Close();
            cmbDoituongBN1.SelectedIndex = 0;

            cmbDTBHXH.ClearItems();
            cmbDTBHXH.AddItem(String.Format("{1}|{0}", "", "------ Tất cả các đối tượng BHXH ------"));
            SQLcmd.CommandText = "Select MaDT, MaDT + ' - ' + TenDT as TenDT from DMDTTHE_BHYT order by MaDT";
            dr = SQLcmd.ExecuteReader();
            cmbDTBHXH.Tag = "1";
            while (dr.Read())
            {
                cmbDTBHXH.AddItem(String.Format("{1}|{0}", dr["MaDT"], dr["TenDT"]));
            }
            dr.Close();
            cmbDTBHXH.SelectedIndex = 0;
            dtNgayRVDen.Value = Global.NgayLV.AddDays(1);
            dtNgayRVTu.Value = new DateTime(Global.NgayLV.Year, Global.NgayLV.Month, 1);//Tuyen
            cmbTuyen.ClearItems();
            cmbTuyen.AddItem(String.Format("0;Đúng tuyến"));
            cmbTuyen.AddItem(String.Format("1;-----------"));
            cmbTuyen.AddItem(String.Format("2;Cấp Cứu"));
            cmbTuyen.AddItem(String.Format("3;Trái tuyến"));

        }

        private void frmChuyenDien_Load(object sender, EventArgs e)
        {
            LoadDM();
            LoadDoiTuongBN();
            EnableEdit(false);
            dtBHDen.Value = dtBHTu.Value = GlobalModuls.Global.NgayLV;
            Add = Edit = false;
            dtNgayRVDen.Enabled = dtNgayRVTu.Enabled = false;
            //cmdTimKiem_Click(sender, e);
        }

        private void Load_DSBenhNhan()
        {
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            string MaKhoa = cmbKhoa.Columns[1].CellText(cmbKhoa.SelectedIndex);
            string MaDT = cmbDoituongBN1.Columns[1].CellText(cmbDoituongBN1.SelectedIndex);
            string MaDTBHXH = cmbDTBHXH.Columns[1].CellText(cmbDTBHXH.SelectedIndex);
            SQLCmd.CommandText = string.Format("SELECT a.MaBenhNhan,b.MaVaoVien,HoTen,NamSinh As Tuoi,case when GioiTinh = 1 "
                                        + " then N'Nam' else N'Nữ' end Gioi,CASE GioiTinh WHEN 1 THEN 'Nam' ELSE N'Nữ' END As TenGT,d.DoiTuong,"
                                        + " TenDT,SoHSBA,NgayVaoVien,b.MaKhamBenh,F.Noigioithieu, b.NgayKham,B.Is_covid "
                                        + " FROM (((BENHNHAN a INNER JOIN BENHNHAN_CHITIET b ON a.MaBenhNhan=b.MaBenhNhan)"
                                        + " INNER JOIN ViewKHOAHIENTAI c ON b.MaVaoVien=c.MaVaoVien)"
                                        + " INNER JOIN ViewDOITUONGHIENTAI d ON b.MaVaoVien=d.MaVaoVien)"
                                        + " INNER JOIN NAMDINH_KHAMBENH.dbo.tblKHAMBENH F ON F.MaKhambenh = b.MaKhamBenh"
                                        + " INNER JOIN DMDOITUONGBN e ON d.DoiTuong=e.MaDT ");
            //+ " WHERE C.MaKhoa LIKE '{0}%' "
            //+ " AND B.MaBenhNhan LIKE '{1}%' AND SOHSBA LIKE '{2}%'"
            //+ " AND E.MaDT LIKE '{3}%' AND B.MaDTBHYT LIKE '{4}%'"
            //+ " AND A.HOTEN LIKE N'%{5}%' ", MaKhoa,
            //txtMaBNTK.Text.Replace(" ", ""), txtSoHSBA1.Text, MaDT, MaDTBHXH, txtHoTenTK.Text,Global.glbUName);
            dtNgayRVDen.ReadOnly = dtNgayRVTu.ReadOnly = false;
            if (rdChuaRV.Checked)
            {
                SQLCmd.CommandText += string.Format(" where DaRaVien= 0 and B.MaKhamBenh = '{0}' order by HoTen", txtMaKhamBenh.Text);
            }
            dr = SQLCmd.ExecuteReader();
            fgDanhSach.Tag = "0";
            fgDanhSach.Rows.Count = 1;
            fgDanhSach.ClipSeparators = "|;";
            fgDanhSach.Redraw = false;
            txtTuoi.Text = "";
            while (dr.Read())
            {
                fgDanhSach.AddItem(String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}",
                     fgDanhSach.Rows.Count,
                     dr["MaVaoVien"],
                     dr["Hoten"],
                     dr["Tuoi"],
                     dr["Ngayvaovien"],
                     dr["MaKhamBenh"], dr["Noigioithieu"], dr["NgayKham"],dr["Is_covid"]));
                   txtTuoi.Text = dr["Tuoi"].ToString();
            }
            dr.Close();
            fgDanhSach.AutoSizeCols();
            fgDanhSach.Redraw = true;
            fgDanhSach.Tag = "1";
            SQLCmd.Dispose();
        }
        private void cmdThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoatDoiTuongCT()
        {
            if (fgDanhSach.Row <= 0) return;
            if (fgDanhSach.Rows.Count <= 1) return;
            string Str = " SELECT BB.*,DMDOITUONGBN.TENDT AS 'TENDTBH',BENHNHAN_CHITIET.SOHSBA,NAMSINH "
                        + " AS 'TUOI',DMTINH_TP.TENTINH,BENHNHAN_CHITIET.DiaChi,bhyt.TenNoiCap AS 'TenNoiCapBHYT'  "
                        + " FROM (SELECT AA.MABENHNHAN,AA.HOTEN,AA.NAMSINH,DMDANTOC.TENDT, CASE AA.GIOITINH"
                        + " WHEN 1 THEN N'Nam' ELSE N'Nữ' END AS 'GIOITINH', AA.MaVaoVien,"
                        + " BENHNHAN_DOITUONG.LANCHUYENDT,BENHNHAN_DOITUONG.DOITUONG,DMDANTOC.MADT AS 'MADANTOC',BENHNHAN_DOITUONG.Tuyen,BENHNHAN_DOITUONG.CapCuu, "
                        + " BENHNHAN_DOITUONG.NGAYCHUYEN,DMDANTOC.TENDT AS 'TENDANTOC',BENHNHAN_DOITUONG.SoThe As 'SOTHEBHYT'"
                        + " ,BENHNHAN_DOITUONG.MaDoiTuongBHXH AS 'MaDTBHYT', DMDTTHE_BHYT.TENDT AS 'TenDTBHYT', BENHNHAN_DOITUONG.MaNoiCap "
                        + " AS 'MaNoiCapBHYT', BENHNHAN_DOITUONG.GTriTu AS 'BHYTGTriTu'"
                        + " ,BENHNHAN_DOITUONG.GTriDen AS 'BHYTGtriDen',BENHNHAN_DOITUONG.TENBHYTCAP  "
                        + " FROM   (SELECT a.*,b.MaVaoVien FROM BENHNHAN a inner join BENHNHAN_CHITIET b on a.MaBenhNhan = b.MaBenhNhan"
                        + " WHERE b.MaVaoVien = '" + fgDanhSach.GetDataDisplay(fgDanhSach.Row, "MaVaoVien") + "') AA  "
                        + " INNER JOIN BENHNHAN_DOITUONG ON BENHNHAN_DOITUONG.MAVAOVIEN = AA.MAVAOVIEN"
                        + " LEFT JOIN DMDANTOC "
                        + " ON DMDANTOC.MADT = AA.MADANTOC  LEFT JOIN DMDTTHE_BHYT on DMDTTHE_BHYT.MADT = BENHNHAN_DOITUONG.MaDoiTuongBHXH) BB  "
                        + " INNER JOIN DMDOITUONGBN ON DMDOITUONGBN.MADT = BB.DOITUONG  INNER JOIN BENHNHAN_CHITIET "
                        + " ON BENHNHAN_CHITIET.MaVaoVien = BB.MAVaoVien "
                        + " LEFT JOIN DMTINH_TP ON DMTINH_TP.MATINH = BENHNHAN_CHITIET.MATINH_TP "
                        + " left join [" + Global.glbSysDB + "].dbo.DMNOIDKKCBBD_BHYT bhyt on bhyt.MaNoiCap = BB.MaNoiCapBHYT order by NgayChuyen ";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(Str, GlobalModuls.Global.ConnectSQL);
            System.Data.DataSet ds = new DataSet();
            System.Data.SqlClient.SqlDataAdapter ad = new System.Data.SqlClient.SqlDataAdapter(cmd);
            ad.Fill(ds);
            fgDoiTuong.Rows.Fixed = 0;
            fgDoiTuong.Rows.Count = 1;
            fgDoiTuong.Rows.Fixed = 1;
            fgDoiTuong.ClipSeparators = "|;";
            txtMaBenNhan1.Text = "";
            txtHoTen.Text = "";
            txtDanToc.Text = "";
            txtGoiTinh.Text = "";
            txtHuyenTinh.Text = "";
            txtSoHSBA.Text = "";
            //txtTuoi.Text = "";
            txtXa.Text = "";
            foreach (System.Data.DataRow Row in ds.Tables[0].Rows)
            {
                txtMaBenNhan1.Text = Row["MaVaoVien"].ToString();
                txtHoTen.Text = Row["HoTen"].ToString();
                txtDanToc.Text = Row["TenDanToc"].ToString();
                txtGoiTinh.Text = Row["GioiTinh"].ToString();
                txtHuyenTinh.Text = Row["TenTinh"].ToString();
                txtSoHSBA.Text = Row["SoHSBA"].ToString();
                //txtTuoi.Text = Row["NAMSINH"].ToString();
                txtXa.Text = Row["DiaChi"].ToString();
                txtTenBHYTTinh.Text = Row["TENBHYTCAP"].ToString();
                cmbTenNoiChuyen.Text = fgDanhSach.GetDataDisplay(fgDanhSach.Row, "Noigioithieu");
                fgDoiTuong.AddItem(String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}|{12}|{13}|{14}|",
                    Row["LanChuyenDT"],
                    Row["NGAYCHUYEN"],
                    Row["TENDTBH"],
                    "",
                    Row["DoiTuong"],
                    Row["SOTHEBHYT"],
                    Row["MaNoiCapBHYT"],
                    Row["TenNoiCapBHYT"],
                    Row["BHYTGTriTu"].ToString() == "" ? "'" : Row["BHYTGTriTu"],
                    Row["BHYTGtriDen"].ToString() == "" ? "'" : Row["BHYTGtriDen"],
                    Row["MaDTBHYT"],
                    Row["TenDTBHYT"],
                    Row["TENBHYTCAP"],
                    Row["Tuyen"], Row["CapCuu"]));
            }

            txtNgayThayDoi.Value = null;
            cmbDoiTuongBN.SelectedIndex = -1;
            ds.Dispose();
            ad.Dispose();
            cmd.Dispose();
        }

        private void fgDanhSach_Click(object sender, EventArgs e)
        {

        }

        private void fgDoiTuong_Click(object sender, EventArgs e)
        {
            if (fgDoiTuong.Row <= 0) return;
            if (fgDoiTuong.Rows.Count <= 1) return;
            txtNgayThayDoi.Value = fgDoiTuong.GetData(fgDoiTuong.Row, "NgayChuyen");
            cmbDoiTuongBN.SelectedIndex = cmbDoiTuongBN.FindStringExact(fgDoiTuong.GetDataDisplay(fgDoiTuong.Row, "MaDT"), 0, 0);
            txtTennoicap.Text = fgDoiTuong.GetDataDisplay(fgDoiTuong.Row, "TenNoiCap").Trim();
            txtManoicap.Text = fgDoiTuong.GetDataDisplay(fgDoiTuong.Row, "MaNoiCap").Trim();
            dtBHDen.Value = fgDoiTuong.GetDataDisplay(fgDoiTuong.Row, "GiaTriDen").ToString() == "" ? null : fgDoiTuong.GetData(fgDoiTuong.Row, "GiaTriDen");
            dtBHTu.Value = fgDoiTuong.GetDataDisplay(fgDoiTuong.Row, "GiaTriTu").ToString() == "" ? null : fgDoiTuong.GetData(fgDoiTuong.Row, "GiaTriTu");
            txtMaDT.Text = fgDoiTuong.GetDataDisplay(fgDoiTuong.Row, "MaDTBH").Trim();
            txtTenDT.Text = fgDoiTuong.GetDataDisplay(fgDoiTuong.Row, "TenDTBH");
            txtSoTheBHYT.Text = fgDoiTuong.GetDataDisplay(fgDoiTuong.Row, "SoThe").Trim();
            txtTenBHYTTinh.Text = fgDoiTuong.GetDataDisplay(fgDoiTuong.Row, "NoiCap");
            if (fgDoiTuong.GetDataDisplay(fgDoiTuong.Row, "CapCuu") == "1")
            {
                cmbTuyen.SelectedIndex = 2;
            }
            else
            {
                cmbTuyen.SelectedIndex = cmbTuyen.FindStringExact(fgDoiTuong.GetDataDisplay(fgDoiTuong.Row, "Tuyen"), 0, 0);
            }
            if ((txtMaDT.Text.Length + txtSoTheBHYT.Text.Length) == 15)
            {
                CheckTheBHYT(txtMaDT.Text + txtSoTheBHYT.Text, txtHoTen.Text, txtTuoi.Text);
            }
            else
            {
                CheckTheBHYT(txtSoTheBHYT.Text, txtHoTen.Text, txtTuoi.Text);
            }

        }

        private void cmdThemMoi_Click(object sender, EventArgs e)
        {
            if (txtHoTen.Text == "") return;
            Add = true;
            Edit = false;
            EnableEdit(true);
            txtNgayThayDoi.Value = GlobalModuls.Global.NgayLV;
            txtSoTheBHYT.Text = txtMaDT.Text = txtTenDT.Text = txtManoicap.Text = txtTennoicap.Text = txtTenBHYTTinh.Text = "";
            dtBHTu.Value = dtBHDen.Value = null;
            txtNgayThayDoi.Focus();
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

            if (txtNgayThayDoi.ValueIsDbNull == true || cmbDoiTuongBN.SelectedIndex == -1)
            {
                MessageBox.Show("Chưa chọn lần thay đổi để sửa!!", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Add = false;
            Edit = true;
            EnableEdit(true);
            txtNgayThayDoi.Value = fgDoiTuong.GetData(fgDoiTuong.Row, "NgayChuyen");
            cmbDoiTuongBN.SelectedIndex = cmbDoiTuongBN.FindStringExact(fgDoiTuong.GetDataDisplay(fgDoiTuong.Row, "MaDT"), 0, 0);

        }

        private void cmdKhongGhi_Click(object sender, EventArgs e)
        {
            Edit = Add = false;
            EnableEdit(false);
            txtNgayThayDoi.Value = null;
            cmbDoiTuongBN.SelectedIndex = -1;
        }
        private void cmdGhi_Click(object sender, EventArgs e)
        {
            int tuyen;

            if (GlobalModuls.Global.GetCode(cmbDoiTuongBN) == "1")//Bao hiem y te
            {
                if (txtSoTheBHYT.Text.Trim() == "")
                {
                    MessageBox.Show("Nhập số thẻ BHYT!!", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSoTheBHYT.Focus();
                    return;
                }
                if(txtMaDT.Text.Trim() != "QN" && txtMaDT.Text.Trim() != "TE" && txtMaDT.Text.Trim() != "CA" && txtSoTheBHYT.Text.Substring(1, 2) != "97")
                {
                    if (txtSoTheBHYT.Text.Length != 13)
                    {
                        MessageBox.Show("Nhập thiếu số thẻ", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtSoTheBHYT.Focus();
                        return;
                    }
                }
                if (dtBHTu.ValueIsDbNull == true)
                {
                    MessageBox.Show("Nhập hạn thẻ BHYT!!", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dtBHTu.Focus();
                    return;
                }
                if (dtBHDen.ValueIsDbNull == true)
                {
                    MessageBox.Show("Nhập hạn thẻ BHYT!!", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dtBHDen.Focus();
                    return;
                }
                if (txtMaDT.Text.Trim() == "")
                {
                    MessageBox.Show("Nhập Mã ĐTBHYT!!", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMaDT.Focus();
                    return;
                }
                if (txtManoicap.Text.Trim() == "")
                {
                    MessageBox.Show("Nhập Mã nơi cấp thẻ BHYT!!", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtManoicap.Focus();
                    return;
                }
               
                if ((cmbTuyen.SelectedIndex == 0 || cmbTuyen.SelectedIndex == -1) && txtManoicap.Text.Trim().Replace(" ", "") != "36001" && cmbTenNoiChuyen.Text == "")
                {
                    MessageBox.Show("Chưa có nơi giới thiệu");
                    cmbTenNoiChuyen.Focus();
                    return;
                }
                if (cmbTuyen.SelectedIndex == 1)
                {
                    MessageBox.Show("Sai Tuyến");
                    cmbTuyen.Focus();
                    return;
                }
                if ((cmbTuyen.SelectedIndex == 3) && txtManoicap.Text.Trim().Replace(" ", "") == "36001")
                {
                    MessageBox.Show("Sai Tuyến");
                    cmbTuyen.Focus();
                    return;
                }
                
                if (DateTime.Parse(fgDanhSach.GetDataDisplay(fgDanhSach.Row, "NgayKham").ToString()) < DateTime.Parse(dtBHTu.Value.ToString()))
                {
                    if (MessageBox.Show("Bệnh nhân đến khám trước khi có thẻ có giá trị \nBạn có muốn sửa ngày thay đổi không", "Thông báo.", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                        return;
                    else
                    {
                        if (DateTime.Parse(txtNgayThayDoi.Value.ToString()).Date != DateTime.Parse(dtBHTu.Value.ToString()).Date)
                        {
                            MessageBox.Show("Ngày thay đổi phải = giá trị từ của thẻ", "Thông báo.", MessageBoxButtons.OK);
                            return;
                        }
                    }
                }

                if (txtMaDT.Text.Trim() != "QN" && txtMaDT.Text.Trim() != "TE" && txtMaDT.Text.Trim() != "CA" && txtSoTheBHYT.Text.Substring(1, 2) != "97")
                {
                    TimeSpan span = DateTime.Parse(Global.GetNgayLV().ToString()) - Convert.ToDateTime(dtBHDen.Value);

                    if (span.Days >= 15)
                    {
                        if (DateTime.Parse(fgDanhSach.GetDataDisplay(fgDanhSach.Row, "NgayKham").ToString()) > DateTime.Parse(dtBHDen.Value.ToString()))
                        {
                            MessageBox.Show("Thẻ không còn giá trị sử dụng, bạn có muốn tiếp tục không ?", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    if (txtHoTen.Text.ToUpper() != Ho_Ten.ToUpper())
                    {
                        var mes = MessageBox.Show("Họ tên thẻ không đúng, bạn có muốn tiếp tục không ?", "Thông báo.", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (mes == DialogResult.No)
                            return;
                    }
                    if (txtTuoi.Text != Nam_Sinh)
                    {
                        var mes = MessageBox.Show("Năm sinh không chính xác, bạn có muốn tiếp tục không ?", "Thông báo.", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (mes == DialogResult.No)
                            return;

                    }
                    if (txtGoiTinh.Text != Gioi_Tinh)
                    {
                            var mes = MessageBox.Show("Giới tính không chính xác, bạn có muốn tiếp tục không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if (mes == DialogResult.No)
                                return;
                    }
                    if (txtManoicap.Text != Noi_DKCBBD)
                    {
                            var mes = MessageBox.Show("Nơi đăng ký KCBBD không chính xác, bạn có muốn tiếp tục không ?", "Thông báo.", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if (mes == DialogResult.No)
                                return;
                    }

                }
                if(cmbTuyen.SelectedIndex == 1)
                {
                    MessageBox.Show("Chuyển tuyến chưa đúng ", "Thông báo.");
                    cmbTuyen.Focus();
                    return;
                }

            }
            if ((txtSoTheBHYT.Text.Trim().Length > 0) && (GlobalModuls.Global.GetCode(cmbDoiTuongBN) == "3"))
            {
                MessageBox.Show("Kiểm tra lại đối tượng");
                cmbDoiTuongBN.Focus();
                return;
            }
            if (cmbTuyen.SelectedIndex == 2)
            {
                tuyen = 0; CapCuu = 1;
            }
            else
            {
                tuyen = cmbTuyen.SelectedIndex;
                CapCuu = 0;
            }
            String Str = "";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlTransaction tra;
            tra = GlobalModuls.Global.ConnectSQL.BeginTransaction();
            cmd.Transaction = tra;
            cmd.Connection = GlobalModuls.Global.ConnectSQL;
            System.Data.SqlClient.SqlDataReader dr;

            if (txtNgayThayDoi.ValueIsDbNull)
            {
                MessageBox.Show("Nhập ngày thay đổi.", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cmbDoiTuongBN.SelectedIndex == -1)
            {
                MessageBox.Show("Chọn đối tượng bệnh nhân.", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cmbTuyen.SelectedIndex == -1)
            {
                MessageBox.Show("Chọn tuyến!.", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbTuyen.Focus();
                return;
            }

            try
            {
                System.TimeSpan span = new TimeSpan();
                if (GlobalModuls.Global.GetCode(cmbDoiTuongBN) == "1")//Bao hiem y te
                {
                    Str = String.Format("SELECT * FROM DMDTTHE_BHYT A WHERE A.MADT ='{0}'", txtMaDT.Text.Trim());
                    cmd.CommandText = Str;
                    dr = cmd.ExecuteReader();

                    if (!dr.HasRows)
                    {
                        MessageBox.Show("Nhập chưa đúng!.", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtMaDT.Text = "";
                        txtMaDT.Focus();
                        dr.Close();
                        tra.Rollback();
                        tra.Dispose();
                        cmd.Dispose();
                        return;
                    }
                    dr.Close();

                    Str = String.Format("SELECT * FROM NAMDINH_SYSDB.DBO.DMNOIDKKCBBD_BHYT A WHERE A.Manoicap ='{0}'", txtManoicap.Text.Trim().Replace(" ", ""));
                    cmd.CommandText = Str;
                    dr = cmd.ExecuteReader();

                    if (!dr.HasRows)
                    {
                        MessageBox.Show("Nhập chưa đúng!.", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtManoicap.Text = "";
                        txtManoicap.Focus();
                        dr.Close();
                        tra.Rollback();
                        tra.Dispose();
                        cmd.Dispose();
                        return;
                    }
                    dr.Close();
                }
                if (Add)
                {
                    Str = String.Format("SELECT * FROM BENHNHAN_DOITUONG WHERE MaVaoVien='{0}' AND LANCHUYENDT={1}",
                           fgDanhSach.GetDataDisplay(fgDanhSach.Row, "MaVaoVien"),
                           fgDoiTuong.GetDataDisplay(fgDoiTuong.Rows.Count - 1, "Lan"));

                    cmd.CommandText = Str;
                    dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            span = Convert.ToDateTime(txtNgayThayDoi.Value) - Convert.ToDateTime(dr["NgayChuyen"]);
                            if (span.Days < 0)
                            {
                                MessageBox.Show("Xem lại ngày thay đổi.", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txtNgayThayDoi.Focus();
                                dr.Close();
                                tra.Rollback();
                                tra.Dispose();
                                cmd.Dispose();
                                return;
                            }
                        }
                    }
                    dr.Close();
                    if (dtBHDen.ValueIsDbNull || dtBHTu.ValueIsDbNull)
                    {
                        Str = String.Format("INSERT INTO BENHNHAN_DOITUONG (MaVaoVien,LanChuyenDT,Ngaychuyen,DoiTuong,"
                            + "SoThe,MaDoiTuongBHXH,MaNoiCap,TenNoiCap,TENBHYTCAP,UserName,Tuyen,CapCuu)"
                            + " VALUES ('{0}',{1},'{2:dd/MM/yyyy HH:mm}','{3}',"
                            + "'{4}','{5}','{6}',N'{7}',N'{8}',N'{9}',{10},{11})"
                            //+ " update BENHNHAN_CHITIET set SoTheBHYT = '{4}', MaDTBHYT = '{5}', MaNoiCapBHYT = '{6}', HanTheBHYT_Tu = null, HanTheBHYT_Den = null    where MaVaoVien = '{0}' "
                            //+ " update NAMDINH_KHAMBENH.DBO.tblKHAMBENH SET Doituong = '{3}', SotheBHYT= '{4}', Doituongthe = '{5}', NoidangkyKCBBD = '{6}', HantheBHYT_Tu = null, HantheBHYT_Den = null,Noigioithieu = N'{12}' FROM NAMDINH_KHAMBENH.DBO.tblKHAMBENH A INNER Join  BENHNHAN_CHITIET b on a.MaKhambenh = b.MaKhamBenh  where  b.MaVaoVien ='{0}' ",
                            + " update NAMDINH_KHAMBENH.DBO.tblKHAMBENH SET Noigioithieu = N'{12}' FROM NAMDINH_KHAMBENH.DBO.tblKHAMBENH A INNER Join  BENHNHAN_CHITIET b on a.MaKhambenh = b.MaKhamBenh  where  b.MaVaoVien ='{0}' "
                            , fgDanhSach.GetDataDisplay(fgDanhSach.Row, "MaVaoVien"),
                            Convert.ToInt32(fgDoiTuong.GetData(fgDoiTuong.Rows.Count - 1, "Lan")) + 1,
                            txtNgayThayDoi.Value,
                            GlobalModuls.Global.GetCode(cmbDoiTuongBN),
                            txtSoTheBHYT.Text.Trim(),
                            txtMaDT.Text.Trim(),
                            txtManoicap.Text.Trim(),
                            txtTennoicap.Text.Trim(),
                            txtTenBHYTTinh.Text.Trim(),
                            GlobalModuls.Global.glbUName,
                            tuyen, CapCuu, cmbTenNoiChuyen.Text);
                    }
                    else
                    {
                        Str = String.Format("INSERT INTO BENHNHAN_DOITUONG (MaVaoVien,LanChuyenDT,Ngaychuyen,DoiTuong,"
                            + "SoThe,MaDoiTuongBHXH,MaNoiCap,TenNoiCap,GTriTu,GTriDen,TENBHYTCAP,UserName,Tuyen,CapCuu)"
                            + " VALUES ('{0}',{1},'{2:dd/MM/yyyy HH:mm}','{3}',"
                            + "'{4}','{5}','{6}',N'{7}','{8:dd/MM/yyyy}','{9:dd/MM/yyyy}',N'{10}',N'{11}',{12},{13}) "
                            //+ " update BENHNHAN_CHITIET set SoTheBHYT = '{4}', MaDTBHYT = '{5}', MaNoiCapBHYT = '{6}', HanTheBHYT_Tu = '{8:dd/MM/yyyy}', HanTheBHYT_Den = '{9:dd/MM/yyyy}'    where MaVaoVien = '{0}' "
                            //+ " update NAMDINH_KHAMBENH.DBO.tblKHAMBENH SET Doituong = '{3}', SotheBHYT= '{4}', Doituongthe = '{5}', NoidangkyKCBBD = '{6}', HantheBHYT_Tu = '{8:dd/MM/yyyy}', HantheBHYT_Den = '{9:dd/MM/yyyy}',Noigioithieu = N'{14}' FROM NAMDINH_KHAMBENH.DBO.tblKHAMBENH A INNER Join  BENHNHAN_CHITIET b on a.MaKhambenh = b.MaKhamBenh  where  b.MaVaoVien ='{0}' ",
                            + " update NAMDINH_KHAMBENH.DBO.tblKHAMBENH SET Noigioithieu = N'{14}' FROM NAMDINH_KHAMBENH.DBO.tblKHAMBENH A INNER Join  BENHNHAN_CHITIET b on a.MaKhambenh = b.MaKhamBenh  where  b.MaVaoVien ='{0}' "
                            , fgDanhSach.GetDataDisplay(fgDanhSach.Row, "MaVaoVien"),
                            Convert.ToInt32(fgDoiTuong.GetData(fgDoiTuong.Rows.Count - 1, "Lan")) + 1,
                            txtNgayThayDoi.Value,
                            GlobalModuls.Global.GetCode(cmbDoiTuongBN),
                            txtSoTheBHYT.Text.Trim(),
                            txtMaDT.Text.Trim(),
                            txtManoicap.Text.Trim(),
                            txtTennoicap.Text.Trim(),
                            dtBHTu.Value,
                            dtBHDen.Value,
                            txtTenBHYTTinh.Text.Trim(),
                            GlobalModuls.Global.glbUName,
                            tuyen, CapCuu, cmbTenNoiChuyen.Text);
                    }
                    cmd.CommandText = Str;
                    cmd.ExecuteNonQuery();
                }
                if (Edit)
                {
                    if (fgDoiTuong.Rows.Count > 2)
                    {
                        span = Convert.ToDateTime(txtNgayThayDoi.Value) - Convert.ToDateTime(fgDoiTuong.GetData(fgDoiTuong.Rows.Count - 2, "NgayChuyen"));
                        if (span.Days < 0)
                        {
                            MessageBox.Show("Xem lại ngày thay đổi.", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtNgayThayDoi.Focus();
                            tra.Rollback();
                            tra.Dispose();
                            cmd.Dispose();
                            return;
                        }
                    }
                    if (fgDoiTuong.Rows.Count <= 2)
                    {
                        if (dtBHDen.ValueIsDbNull || dtBHTu.ValueIsDbNull)
                        {
                            Str = String.Format("UPDATE BENHNHAN_DOITUONG SET NGAYCHUYEN ='{0:dd/MM/yyyy HH:mm}',DOITUONG='{1}',"
                               + " SoThe='{4}',MaDoiTuongBHXH='{5}',MaNoiCap='{6}',TenNoiCap=N'{7}',Gtritu = null ,gtriden = null,"
                               + " TENBHYTCAP=N'{8}',UserName=N'{9}',Tuyen={10}, CapCuu = {11}"
                               + " WHERE MaVaoVien='{2}' AND LANCHUYENDT={3} "
                               + " update BENHNHAN_CHITIET set SoTheBHYT = '{4}', MaDTBHYT = '{5}', MaNoiCapBHYT = '{6}', HanTheBHYT_Tu = null, HanTheBHYT_Den = null    where MaVaoVien = '{2}'"
                               + " update NAMDINH_KHAMBENH.DBO.tblKHAMBENH SET Doituong = '{1}', SotheBHYT= '{4}', Doituongthe = '{5}', NoidangkyKCBBD = '{6}', HantheBHYT_Tu = null, HantheBHYT_Den = null,Noigioithieu = N'{12}' "
                               + " FROM NAMDINH_KHAMBENH.DBO.tblKHAMBENH A INNER Join  BENHNHAN_CHITIET b on a.MaKhambenh = b.MaKhamBenh  where  b.MaVaoVien ='{2}' "
                                   , txtNgayThayDoi.Value,
                                   GlobalModuls.Global.GetCode(cmbDoiTuongBN),
                                   fgDanhSach.GetDataDisplay(fgDanhSach.Row, "MaVaoVien"),
                                   fgDoiTuong.GetDataDisplay(fgDoiTuong.Row, "LAN"),
                                   txtSoTheBHYT.Text.Trim(), txtMaDT.Text.Trim(),
                                   txtManoicap.Text.Trim(),
                                   txtTennoicap.Text.Trim(),
                                   txtTenBHYTTinh.Text,
                                   GlobalModuls.Global.glbUName, tuyen, CapCuu, cmbTenNoiChuyen.Text);
                        }
                        else
                        {
                            Str = String.Format("UPDATE BENHNHAN_DOITUONG SET NGAYCHUYEN ='{0:dd/MM/yyyy HH:mm}',DOITUONG='{1}',"
                               + " SoThe='{4}',MaDoiTuongBHXH='{5}',MaNoiCap='{6}',TenNoiCap=N'{7}',GTriTu='{8:dd/MM/yyyy}',"
                               + " GTriDen='{9:dd/MM/yyyy}',TENBHYTCAP=N'{10}',UserName=N'{11}',Tuyen={12},CapCuu={13}"
                               + " WHERE MaVaoVien='{2}' AND LANCHUYENDT={3}"
                               + " update BENHNHAN_CHITIET set SoTheBHYT = '{4}', MaDTBHYT = '{5}', MaNoiCapBHYT = '{6}', HanTheBHYT_Tu = '{8:dd/MM/yyyy}', HanTheBHYT_Den = '{9:dd/MM/yyyy}'    where MaVaoVien = '{2}'"
                               + " update NAMDINH_KHAMBENH.DBO.tblKHAMBENH SET Doituong = '{1}', SotheBHYT= '{4}', Doituongthe = '{5}', NoidangkyKCBBD = '{6}', HantheBHYT_Tu = '{8:dd/MM/yyyy}', HantheBHYT_Den = '{9:dd/MM/yyyy}',Noigioithieu = N'{14}' FROM NAMDINH_KHAMBENH.DBO.tblKHAMBENH A INNER Join  BENHNHAN_CHITIET b on a.MaKhambenh = b.MaKhamBenh  where  b.MaVaoVien ='{2}' "
                               , txtNgayThayDoi.Value,
                                   GlobalModuls.Global.GetCode(cmbDoiTuongBN),
                                   fgDanhSach.GetDataDisplay(fgDanhSach.Row, "MaVaoVien"),
                                   fgDoiTuong.GetDataDisplay(fgDoiTuong.Row, "LAN"),
                                   txtSoTheBHYT.Text.Trim(), txtMaDT.Text.Trim(),
                                   txtManoicap.Text.Trim(),
                                   txtTennoicap.Text.Trim(),
                                   dtBHTu.Value,
                                   dtBHDen.Value,
                                   txtTenBHYTTinh.Text.Trim(),
                                   GlobalModuls.Global.glbUName, tuyen, CapCuu, cmbTenNoiChuyen.Text);
                        }
                        cmd.CommandText = Str;
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        if (dtBHDen.ValueIsDbNull || dtBHTu.ValueIsDbNull)
                        {
                            Str = String.Format("UPDATE BENHNHAN_DOITUONG SET NGAYCHUYEN ='{0:dd/MM/yyyy HH:mm}',DOITUONG='{1}',"
                               + " SoThe='{4}',MaDoiTuongBHXH='{5}',MaNoiCap='{6}',TenNoiCap=N'{7}',Gtritu = null ,gtriden = null,"
                               + " TENBHYTCAP=N'{8}',UserName=N'{9}',Tuyen={10}, CapCuu = {11}"
                               + " WHERE MaVaoVien='{2}' AND LANCHUYENDT={3} "
                               //+ " update BENHNHAN_CHITIET set SoTheBHYT = '{4}', MaDTBHYT = '{5}', MaNoiCapBHYT = '{6}', HanTheBHYT_Tu = null, HanTheBHYT_Den = null    where MaVaoVien = '{2}'"
                               //+ " update NAMDINH_KHAMBENH.DBO.tblKHAMBENH SET Doituong = '{1}', SotheBHYT= '{4}', Doituongthe = '{5}', NoidangkyKCBBD = '{6}', HantheBHYT_Tu = null, HantheBHYT_Den = null,Noigioithieu = N'{12}' FROM NAMDINH_KHAMBENH.DBO.tblKHAMBENH A INNER Join  BENHNHAN_CHITIET b on a.MaKhambenh = b.MaKhamBenh  where  b.MaVaoVien ='{2}' "
                               , txtNgayThayDoi.Value,
                               GlobalModuls.Global.GetCode(cmbDoiTuongBN),
                               fgDanhSach.GetDataDisplay(fgDanhSach.Row, "MaVaoVien"),
                               fgDoiTuong.GetDataDisplay(fgDoiTuong.Row, "LAN"),
                               txtSoTheBHYT.Text.Trim(), txtMaDT.Text.Trim(),
                               txtManoicap.Text.Trim(),
                               txtTennoicap.Text.Trim(),
                               txtTenBHYTTinh.Text.Trim(),
                               GlobalModuls.Global.glbUName, tuyen, CapCuu, cmbTenNoiChuyen.Text);
                        }
                        else
                        {
                            Str = String.Format("UPDATE BENHNHAN_DOITUONG SET NGAYCHUYEN ='{0:dd/MM/yyyy HH:mm}',DOITUONG='{1}',"
                               + " SoThe='{4}',MaDoiTuongBHXH='{5}',MaNoiCap='{6}',TenNoiCap=N'{7}',GTriTu='{8:dd/MM/yyyy}',"
                               + " GTriDen='{9:dd/MM/yyyy}',TENBHYTCAP=N'{10}',UserName=N'{11}',Tuyen={12},CapCuu={13}"
                               + " WHERE MaVaoVien='{2}' AND LANCHUYENDT={3}"
                               //+ " update BENHNHAN_CHITIET set SoTheBHYT = '{4}', MaDTBHYT = '{5}', MaNoiCapBHYT = '{6}', HanTheBHYT_Tu = '{8:dd/MM/yyyy}', HanTheBHYT_Den = '{9:dd/MM/yyyy}'    where MaVaoVien = '{2}'"
                               //+ " update NAMDINH_KHAMBENH.DBO.tblKHAMBENH SET Doituong = '{1}', SotheBHYT= '{4}', Doituongthe = '{5}', NoidangkyKCBBD = '{6}', HantheBHYT_Tu = '{8:dd/MM/yyyy}', HantheBHYT_Den = '{9:dd/MM/yyyy}',Noigioithieu = N'{14}' FROM NAMDINH_KHAMBENH.DBO.tblKHAMBENH A INNER Join  BENHNHAN_CHITIET b on a.MaKhambenh = b.MaKhamBenh  where  b.MaVaoVien ='{2}' "
                               , txtNgayThayDoi.Value,
                               GlobalModuls.Global.GetCode(cmbDoiTuongBN),
                               fgDanhSach.GetDataDisplay(fgDanhSach.Row, "MaVaoVien"),
                               fgDoiTuong.GetDataDisplay(fgDoiTuong.Row, "LAN"),
                               txtSoTheBHYT.Text.Trim(), txtMaDT.Text.Trim(),
                               txtManoicap.Text.Trim(),
                               txtTennoicap.Text.Trim(),
                               dtBHTu.Value,
                               dtBHDen.Value,
                               txtTenBHYTTinh.Text.Trim(),
                               GlobalModuls.Global.glbUName, tuyen, CapCuu, cmbTenNoiChuyen.Text);
                        }
                        cmd.CommandText = Str;
                        cmd.ExecuteNonQuery();
                    }
                }
                tra.Commit();
                tra.Dispose();
                EnableEdit(false);
                cmd.Dispose();
                LoatDoiTuongCT();
                Edit = Add = false;
                string doituong1, lanchuyen1;
                DateTime ngaychuyen1;
                for (int i = 1; i <= fgDoiTuong.Rows.Count - 1; i++)
                {
                    //if(fgDanhSach.GetDataDisplay(fgDanhSach.Row,"Is_covid").ToString() != "1")
                    //{
                        if (i <= 1)
                        {
                            doituong1 = fgDoiTuong[i, "MaDT"].ToString();
                            ngaychuyen1 = DateTime.Parse(fgDoiTuong[i, "NgayChuyen"].ToString());
                            lanchuyen1 = fgDoiTuong[i, "Lan"].ToString();

                            //chuyển chi phí nội trú PHIEUDIEUTRI_CHITIET
                            Str = "";
                            Str = String.Format(" UPDATE PHIEUDIEUTRI_CHITIET set DonGia = ");
                            if (doituong1 == "1")
                            { Str += String.Format(" CASE when (d.DongiaBHYT is NULL and c.LoaiDichVu not in('D01','D02','D06','D05')) then 0.00 when (d.MaDichvu is NULL and c.LoaiDichVu in('D01','D02','D06','D05')) then c.DonGia else  d.DongiaBHYT end ,DoiTuongBN = 1,LanChuyenDT = {0}", lanchuyen1); };
                            if (doituong1 == "3")
                            {
                                Str += String.Format(" CASE when (d.Dongia is NULL and  c.LoaiDichVu not in('D01','D02','D06','D05')) then 0.00 when (d.MaDichvu is NULL and c.LoaiDichVu in('D01','D02','D06','D05')) then c.DonGia else  d.Dongia end, DoiTuongBN = 3,LanChuyenDT = {0}", lanchuyen1);
                            };
                            Str += String.Format(" from NAMDINH_QLBN.dbo.BENHNHAN_CHITIET a inner join NAMDINH_QLBN.dbo.BENHNHAN_PHIEUDIEUTRI b on a.MaVaoVien = b.MaVaoVien inner join NAMDINH_QLBN.dbo.PHIEUDIEUTRI_CHITIET c on c.SoPhieu = b.SoPhieu left join NAMDINH_QLBN.dbo.DMLENCHIPHI_BYKHOID d on d.MaDichvu = c.MaDichVu where a.MaVaoVien = '{0}' ", fgDanhSach.GetDataDisplay(fgDanhSach.Row, "MaVaoVien"), ngaychuyen1, lanchuyen1);
                            cmd.CommandText = Str;
                            cmd.ExecuteNonQuery();

                            // chuyển chi phí phòng mổ
                            Str = "";
                            Str += String.Format(" UPDATE BENHNHAN_PT_CHIPHI set DonGia = ");
                            if (doituong1 == "1")
                            { Str += String.Format("CASE when (d.DongiaBHYT is NULL and a.LoaiChiPhi not in('D01','D02','D06','D05'))  then 0.00  when (d.MaDichvu is NULL and a.LoaiChiPhi in('D01','D02','D06','D05')) then a.DonGia else  d.DongiaBHYT end ,MaDTBN = 1,LanChuyenDT = {0}", lanchuyen1); };
                            if (doituong1 == "3")
                            {
                                Str += String.Format(" CASE when (d.Dongia is NULL and a.LoaiChiPhi not in('D01','D02','D06','D05'))  then 0.00 when (d.MaDichvu is NULL and a.LoaiChiPhi in('D01','D02','D06','D05')) then a.DonGia else  d.Dongia end, MaDTBN = 3,LanChuyenDT = {0}", lanchuyen1);
                            };
                            Str += String.Format(" from NAMDINH_QLBN.dbo.BENHNHAN_PT_CHIPHI a inner join NAMDINH_QLBN.dbo.BENHNHAN_PHIEUDIEUTRI b on a.MaVaoVien = b.MaVaoVien and a.SoPhieuCD = b.SoPhieu  left join NAMDINH_QLBN.dbo.DMLENCHIPHI_BYKHOID d on d.MaDichvu = a.MaDichVu where a.MaVaoVien = '{0}' and a.TinhPhi = 1 ", fgDanhSach.GetDataDisplay(fgDanhSach.Row, "MaVaoVien"), ngaychuyen1, lanchuyen1);
                            cmd.CommandText = Str;
                            cmd.ExecuteNonQuery();

                            // chuyển chi phí phòng khám

                            Str = "";
                            Str += String.Format(" UPDATE NAMDINH_KHAMBENH.dbo.tblCHIPHI_DICHVU set DonGia = ");
                            if (doituong1 == "1")
                            { Str += String.Format(" CASE when (d.DongiaBHYT is NULL and a.LoaiChiPhi not in('D01','D02','D06','D05')) then 0.00 when (d.MaDichvu is NULL and a.LoaiChiPhi in('D01','D02','D06','D05')) then a.DonGia else  d.DongiaBHYT end "); };
                            if (doituong1 == "3")
                            {
                                Str += String.Format(" CASE when (d.Dongia is NULL and a.LoaiChiPhi not in('D01','D02','D06','D05')) then 0.00 when (d.MaDichvu is NULL and a.LoaiChiPhi in('D01','D02','D06','D05')) then a.DonGia  else  d.Dongia end ");
                            };
                            Str += String.Format(" from NAMDINH_KHAMBENH.dbo.tblCHIPHI_DICHVU a inner join namdinh_qlbn.dbo.BENHNHAN_CHITIET b on a.makhambenh = b.makhambenh  left join NAMDINH_QLBN.dbo.DMLENCHIPHI_BYKHOID d on d.MaDichvu = a.MaChiPhi where b.MaVaoVien = '{0}' and a.TinhPhi = 1 ", fgDanhSach.GetDataDisplay(fgDanhSach.Row, "MaVaoVien"), ngaychuyen1, lanchuyen1);
                            cmd.CommandText = Str;
                            cmd.ExecuteNonQuery();

                            // chuyen tuyen phong kham
                            Str = "";
                            if (fgDoiTuong[i, "CapCuu"].ToString() == "1")
                            {
                                Str += String.Format(" update NAMDINH_KHAMBENH.DBO.tblKHAMBENH SET Tuyen = '2' "
                                   + "FROM NAMDINH_KHAMBENH.DBO.tblKHAMBENH A INNER Join  BENHNHAN_CHITIET b on a.MaKhambenh = b.MaKhamBenh  where  b.MaVaoVien ='{0}' "
                                   , fgDanhSach.GetDataDisplay(fgDanhSach.Row, "MaVaoVien"), fgDoiTuong[i, "Tuyen"].ToString());
                            }
                            else
                            {
                                if (fgDoiTuong[i, "Tuyen"].ToString() == "3")
                                {
                                    Str += String.Format(" update NAMDINH_KHAMBENH.DBO.tblKHAMBENH SET Tuyen = '1' "
                                       + "FROM NAMDINH_KHAMBENH.DBO.tblKHAMBENH A INNER Join  BENHNHAN_CHITIET b on a.MaKhambenh = b.MaKhamBenh  where  b.MaVaoVien ='{0}' "
                                       , fgDanhSach.GetDataDisplay(fgDanhSach.Row, "MaVaoVien"), fgDoiTuong[i, "Tuyen"].ToString());
                                }
                                else
                                {
                                    Str += String.Format(" update NAMDINH_KHAMBENH.DBO.tblKHAMBENH SET Tuyen = '{1}' "
                                        + "FROM NAMDINH_KHAMBENH.DBO.tblKHAMBENH A INNER Join  BENHNHAN_CHITIET b on a.MaKhambenh = b.MaKhamBenh  where  b.MaVaoVien ='{0}' "
                                        , fgDanhSach.GetDataDisplay(fgDanhSach.Row, "MaVaoVien"), fgDoiTuong[i, "Tuyen"].ToString());
                                }
                            }


                            cmd.CommandText = Str;
                            cmd.ExecuteNonQuery();
                        }
                        else
                        {
                            doituong1 = fgDoiTuong[i, "MaDT"].ToString();
                            ngaychuyen1 = DateTime.Parse(fgDoiTuong[i, "NgayChuyen"].ToString());
                            lanchuyen1 = fgDoiTuong[i, "Lan"].ToString();

                            //chuyển chi phí nội trú PHIEUDIEUTRI_CHITIET
                            Str = "";
                            Str = String.Format(" UPDATE PHIEUDIEUTRI_CHITIET set DonGia = ");
                            if (doituong1 == "1")
                            { Str += String.Format(" CASE when (d.DongiaBHYT is NULL and c.LoaiDichVu not in('D01','D02','D06','D05')) then 0.00 when (d.MaDichvu is NULL and c.LoaiDichVu in('D01','D02','D06','D05')) then c.DonGia else  d.DongiaBHYT end ,DoiTuongBN = 1,LanChuyenDT = {0}", lanchuyen1); };
                            if (doituong1 == "3")
                            {
                                Str += String.Format(" CASE when (d.Dongia is NULL and c.LoaiDichVu not in('D01','D02','D06','D05')) then 0.00   when (d.MaDichvu is NULL and c.LoaiDichVu in('D01','D02','D06','D05')) then c.DonGia else  d.Dongia end, DoiTuongBN = 3,LanChuyenDT = {0}", lanchuyen1);
                            };
                            Str += String.Format(" from NAMDINH_QLBN.dbo.BENHNHAN_CHITIET a inner join NAMDINH_QLBN.dbo.BENHNHAN_PHIEUDIEUTRI b on a.MaVaoVien = b.MaVaoVien inner join NAMDINH_QLBN.dbo.PHIEUDIEUTRI_CHITIET c on c.SoPhieu = b.SoPhieu left join NAMDINH_QLBN.dbo.DMLENCHIPHI_BYKHOID d on d.MaDichvu = c.MaDichVu where a.MaVaoVien = '{0}' and b.NgayChiDinh >= '{1:dd/MM/yyyy HH:mm}'", fgDanhSach.GetDataDisplay(fgDanhSach.Row, "MaVaoVien"), ngaychuyen1, lanchuyen1);
                            cmd.CommandText = Str;
                            cmd.ExecuteNonQuery();

                            // chuyển chi phí phòng mổ
                            Str = "";
                            Str += String.Format(" UPDATE BENHNHAN_PT_CHIPHI set DonGia = ");
                            if (doituong1 == "1")
                            { Str += String.Format("  CASE when (d.DongiaBHYT is NULL and a.LoaiChiPhi not in('D01','D02','D06','D05'))  then 0.00  when (d.MaDichvu is NULL and a.LoaiChiPhi in('D01','D02','D06','D05')) then a.DonGia else  d.DongiaBHYT end ,MaDTBN = 1,LanChuyenDT = {0}", lanchuyen1); };
                            if (doituong1 == "3")
                            {
                                Str += String.Format(" CASE when (d.Dongia is NULL and a.LoaiChiPhi not in('D01','D02','D06','D05'))  then 0.00 when (d.MaDichvu is NULL and a.LoaiChiPhi in('D01','D02','D06','D05')) then a.DonGia else  d.Dongia end, MaDTBN = 3,LanChuyenDT = {0}", lanchuyen1);
                            };
                            Str += String.Format(" from NAMDINH_QLBN.dbo.BENHNHAN_PT_CHIPHI a inner join NAMDINH_QLBN.dbo.BENHNHAN_PHIEUDIEUTRI b on a.MaVaoVien = b.MaVaoVien and a.SoPhieuCD = b.SoPhieu  left join NAMDINH_QLBN.dbo.DMLENCHIPHI_BYKHOID d on d.MaDichvu = a.MaDichVu where a.MaVaoVien = '{0}' and a.TinhPhi = 1 and b.NgayChiDinh >= '{1:dd/MM/yyyy HH:mm}'", fgDanhSach.GetDataDisplay(fgDanhSach.Row, "MaVaoVien"), ngaychuyen1, lanchuyen1);
                            cmd.CommandText = Str;
                            cmd.ExecuteNonQuery();
                        }

                    }

                //}

            }
            catch (Exception ex)
            {
                MessageBox.Show("Chưa thực hiện được.\n " + ex.ToString(), "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tra.Rollback();
                tra.Dispose();
                cmd.Dispose();
            }
            finally
            {
                tra.Dispose();
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void txtSoTheBHYT_Validated(object sender, EventArgs e)
        {
            //if (txtSoTheBHYT.Text == "") return;
            //if (fgDanhSach.Row <= 0) return;
            //String Str = "";
            //System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            //cmd.Connection = GlobalModuls.Global.ConnectSQL;
            //System.Data.SqlClient.SqlDataReader dr;

            //Str = "Select * from benhnhan_chitiet where SoTheBHYT='" + txtSoTheBHYT.Text.Trim() + "'";
            //cmd.CommandText = Str;
            //dr = cmd.ExecuteReader();
            //if (dr.HasRows)
            //{
            //    dr.Read();
            //    dtBHTu.Value = dr["HanTheBHYT_Tu"];
            //    dtBHDen.Value = dr["HanTheBHYT_Den"];
            //    txtMaDT.Text = dr["MaDTBHYT"].ToString();
            //    txtManoicap.Text = dr["MaNoiCapBHYT"].ToString();
            //}
            //dr.Close();
            //dr.Dispose();
            //cmd.Dispose();
        }

        private void txtMaDT_Validating(object sender, CancelEventArgs e)
        {

        }

        private void txtMaDT_Validated(object sender, EventArgs e)
        {
            //if (txtSoTheBHYT.Text == "") return;
            //if (fgDanhSach.Row <= 0) return;
            //String Str = "";
            //System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            //cmd.Connection = GlobalModuls.Global.ConnectSQL;
            //System.Data.SqlClient.SqlDataReader dr;

            //Str = "Select * from DMDTTHE_BHYT where MaDT='" + txtMaDT.Text + "'";
            //cmd.CommandText = Str;
            //dr = cmd.ExecuteReader();
            //if (dr.HasRows)
            //{
            //    dr.Read();
            //    txtMaDT.Text = dr["MaDT"].ToString();
            //    txtTenDT.Text = dr["TenDT"].ToString();
            //}
            //dr.Close();
            //dr.Dispose();
            //cmd.Dispose();
        }

        private void txtManoicap_Validating(object sender, CancelEventArgs e)
        {

        }

        private void cmbDoiTuongBN_Validated(object sender, EventArgs e)
        {
            if (cmbDoiTuongBN.SelectedIndex != 0 || cmbDoiTuongBN.SelectedIndex != 1)
            {
                txtSoTheBHYT.Text = txtMaDT.Text = txtTenDT.Text = txtManoicap.Text = txtTennoicap.Text = txtTenBHYTTinh.Text = "";
                dtBHTu.Value = dtBHDen.Value = null;
            }
        }

        private void cmdTimKiem_Click(object sender, EventArgs e)
        {
            txtbarcode_KeyUp(null, null);
            //if (txtbarcode.Text.Substring(txtbarcode.Text.Length - 1) == "$")
            //{
            //    const char Comma = '|';
            //    char[] delimiters = new char[] { Comma };
            //    StringBuilder output = new StringBuilder();
            //    string[] subString = txtbarcode.Text.Split(delimiters);

            //    if (subString[0].Length == 15)
            //    {
            //        txtMaDT.Text = subString[0].Substring(0, 2);
            //        txtSoTheBHYT.Text = subString[0].Substring(2);
            //    }
            //    string a = subString[5].Remove(2, 3);
            //    txtManoicap.Text = a;
            //    txtHoTen.Text = ConvertHexStrToUnicode(subString[1].ToString()).ToUpper();
            //    if (subString[3].ToString() == "2") { txtGoiTinh.Text = "Nữ"; } else { txtGoiTinh.Text = "Nam"; }
            //}
            //if (txtHoTen.Text == fgDanhSach.GetDataDisplay(fgDanhSach.Row, "TenBN"))
            //{
            //    if ((txtMaDT.Text.Length + txtSoTheBHYT.Text.Length) == 15)
            //    {
            //        CheckTheBHYT(txtMaDT.Text + txtSoTheBHYT.Text, txtHoTen.Text, txtTuoi.Text);
            //    }
            //    else
            //    {
            //        CheckTheBHYT(txtSoTheBHYT.Text, txtHoTen.Text, txtTuoi.Text);
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Quyét nhầm nhẻ");
            //    Edit = Add = false;
            //    EnableEdit(false);
            //    txtNgayThayDoi.Value = null;
            //    cmbDoiTuongBN.SelectedIndex = -1;
            //    fgDoiTuong.Rows.Count = 1;
            //    //ResetTT();
            //    txtbarcode.Text = "";
            //    txtLichSuKCB.Text = "";
            //    fgDanhSach_AfterRowColChange(null, null);
            //    return;
            //}
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
        }

        private void cmdXoa_Click(object sender, EventArgs e)
        {
            String Str = "";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.Connection = GlobalModuls.Global.ConnectSQL;
            int LanChuyen = 0;
            if ((fgDoiTuong.Rows.Count <= 2) || (fgDoiTuong.Row == 1))
            {
                MessageBox.Show("Không thể xóa.", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (fgDoiTuong.Row < fgDoiTuong.Rows.Count - 1)
            {
                MessageBox.Show("Bạn phải xóa lần chuyển trước đó mới xóa được", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Bạn có muốn xóa không.", "Thông báo.", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    Str = String.Format("DELETE FROM BENHNHAN_DOITUONG WHERE "
                        + "MaVaoVien= '{0}' AND LANCHUYENDT = {1} ",
                                fgDanhSach.GetDataDisplay(fgDanhSach.Row, "MaVaoVien"),
                               fgDoiTuong.GetDataDisplay(fgDoiTuong.Row, "Lan"));

                    for (int i = 1; i < fgDoiTuong.Rows.Count; i++)
                    {
                        if (fgDoiTuong.Row == i) continue;
                        Str += String.Format("UPDATE BENHNHAN_DOITUONG SET LANCHUYENDT = {2} WHERE MaVaoVien= '{0}' and LANCHUYENDT = {1} ",
                             fgDanhSach.GetDataDisplay(fgDanhSach.Row, "MaVaoVien"),
                              fgDoiTuong.GetDataDisplay(i, "Lan"),
                              LanChuyen);
                        LanChuyen += 1;
                    }
                    cmd.CommandText = Str;
                    cmd.ExecuteNonQuery();
                    LoatDoiTuongCT();
                    string doituong1, lanchuyen1;
                    DateTime ngaychuyen1;
                    for (int i = 1; i <= fgDoiTuong.Rows.Count - 1; i++)
                    {
                        //if (fgDanhSach.GetDataDisplay(fgDanhSach.Row, "Is_covid").ToString() != "1")
                        //{
                            if (i <= 1)
                            {
                                doituong1 = fgDoiTuong[i, "MaDT"].ToString();
                                ngaychuyen1 = DateTime.Parse(fgDoiTuong[i, "NgayChuyen"].ToString());
                                lanchuyen1 = fgDoiTuong[i, "Lan"].ToString();

                                //chuyển chi phí nội trú PHIEUDIEUTRI_CHITIET
                                Str = "";
                                Str = String.Format(" UPDATE PHIEUDIEUTRI_CHITIET set DonGia = ");
                                if (doituong1 == "1")
                                { Str += String.Format(" CASE when d.DongiaBHYT is NULL then 0.00 else  d.DongiaBHYT end ,DoiTuongBN = 1,LanChuyenDT = {0}", lanchuyen1); };
                                if (doituong1 == "3")
                                {
                                    Str += String.Format(" CASE when d.Dongia is NULL then 0.00 else  d.Dongia end, DoiTuongBN = 3,LanChuyenDT = {0}", lanchuyen1);
                                };
                                Str += String.Format(" from NAMDINH_QLBN.dbo.BENHNHAN_CHITIET a inner join NAMDINH_QLBN.dbo.BENHNHAN_PHIEUDIEUTRI b on a.MaVaoVien = b.MaVaoVien inner join NAMDINH_QLBN.dbo.PHIEUDIEUTRI_CHITIET c on c.SoPhieu = b.SoPhieu inner join NAMDINH_QLBN.dbo.DMLENCHIPHI_BYKHOID d on d.MaDichvu = c.MaDichVu where a.MaVaoVien = '{0}' ", fgDanhSach.GetDataDisplay(fgDanhSach.Row, "MaVaoVien"), ngaychuyen1, lanchuyen1);
                                cmd.CommandText = Str;
                                cmd.ExecuteNonQuery();

                                // chuyển chi phí phòng mổ
                                Str = "";
                                Str += String.Format(" UPDATE BENHNHAN_PT_CHIPHI set DonGia = ");
                                if (doituong1 == "1")
                                { Str += String.Format(" CASE when d.DongiaBHYT is NULL then 0.00 else  d.DongiaBHYT end ,MaDTBN = 1,LanChuyenDT = {0}", lanchuyen1); };
                                if (doituong1 == "3")
                                {
                                    Str += String.Format(" CASE when d.Dongia is NULL then 0.00 else  d.Dongia end, MaDTBN = 3,LanChuyenDT = {0}", lanchuyen1);
                                };
                                Str += String.Format(" from NAMDINH_QLBN.dbo.BENHNHAN_PT_CHIPHI a inner join NAMDINH_QLBN.dbo.BENHNHAN_PHIEUDIEUTRI b on a.MaVaoVien = b.MaVaoVien and a.SoPhieuCD = b.SoPhieu  inner join NAMDINH_QLBN.dbo.DMLENCHIPHI_BYKHOID d on d.MaDichvu = a.MaDichVu where a.MaVaoVien = '{0}' and a.TinhPhi = 1 ", fgDanhSach.GetDataDisplay(fgDanhSach.Row, "MaVaoVien"), ngaychuyen1, lanchuyen1);
                                cmd.CommandText = Str;
                                cmd.ExecuteNonQuery();

                                // chuyển chi phí phòng khám

                                Str = "";
                                Str += String.Format(" UPDATE NAMDINH_KHAMBENH.dbo.tblCHIPHI_DICHVU set DonGia = ");
                                if (doituong1 == "1")
                                { Str += String.Format(" CASE when d.DongiaBHYT is NULL then 0.00 else  d.DongiaBHYT end "); };
                                if (doituong1 == "3")
                                {
                                    Str += String.Format(" CASE when d.Dongia is NULL then 0.00 else  d.Dongia end ");
                                };
                                Str += String.Format(" from NAMDINH_KHAMBENH.dbo.tblCHIPHI_DICHVU a inner join namdinh_qlbn.dbo.BENHNHAN_CHITIET b on a.makhambenh = b.makhambenh  inner join NAMDINH_QLBN.dbo.DMLENCHIPHI_BYKHOID d on d.MaDichvu = a.MaChiPhi where b.MaVaoVien = '{0}' and a.TinhPhi = 1 ", fgDanhSach.GetDataDisplay(fgDanhSach.Row, "MaVaoVien"), ngaychuyen1, lanchuyen1);
                                cmd.CommandText = Str;
                                cmd.ExecuteNonQuery();
                            }
                            else
                            {
                                doituong1 = fgDoiTuong[i, "MaDT"].ToString();
                                //doituong2 = fgDoiTuong[2, "MaDT"].ToString();
                                ngaychuyen1 = DateTime.Parse(fgDoiTuong[i, "NgayChuyen"].ToString());
                                //ngaychuyen2 = DateTime.Parse(fgDoiTuong[2, "NgayChuyen"].ToString());
                                lanchuyen1 = fgDoiTuong[i, "Lan"].ToString();
                                //lanchuyen2 = fgDoiTuong[2, "Lan"].ToString();

                                //chuyển chi phí nội trú PHIEUDIEUTRI_CHITIET
                                Str = "";
                                Str = String.Format(" UPDATE PHIEUDIEUTRI_CHITIET set DonGia = ");
                                if (doituong1 == "1")
                                { Str += String.Format(" CASE when d.DongiaBHYT is NULL then 0.00 else  d.DongiaBHYT end ,DoiTuongBN = 1,LanChuyenDT = {0}", lanchuyen1); };
                                if (doituong1 == "3")
                                {
                                    Str += String.Format(" CASE when d.Dongia is NULL then 0.00 else  d.Dongia end, DoiTuongBN = 3,LanChuyenDT = {0}", lanchuyen1);
                                };
                                Str += String.Format(" from NAMDINH_QLBN.dbo.BENHNHAN_CHITIET a inner join NAMDINH_QLBN.dbo.BENHNHAN_PHIEUDIEUTRI b on a.MaVaoVien = b.MaVaoVien inner join NAMDINH_QLBN.dbo.PHIEUDIEUTRI_CHITIET c on c.SoPhieu = b.SoPhieu inner join NAMDINH_QLBN.dbo.DMLENCHIPHI_BYKHOID d on d.MaDichvu = c.MaDichVu where a.MaVaoVien = '{0}' and b.NgayChiDinh >= '{1:dd/MM/yyyy HH:mm}'", fgDanhSach.GetDataDisplay(fgDanhSach.Row, "MaVaoVien"), ngaychuyen1, lanchuyen1);
                                cmd.CommandText = Str;
                                cmd.ExecuteNonQuery();

                                // chuyển chi phí phòng mổ
                                Str = "";
                                Str += String.Format(" UPDATE BENHNHAN_PT_CHIPHI set DonGia = ");
                                if (doituong1 == "1")
                                { Str += String.Format(" CASE when d.DongiaBHYT is NULL then 0.00 else  d.DongiaBHYT end ,MaDTBN = 1,LanChuyenDT = {0}", lanchuyen1); };
                                if (doituong1 == "3")
                                {
                                    Str += String.Format(" CASE when d.Dongia is NULL then 0.00 else  d.Dongia end, MaDTBN = 3,LanChuyenDT = {0}", lanchuyen1);
                                };
                                Str += String.Format(" from NAMDINH_QLBN.dbo.BENHNHAN_PT_CHIPHI a inner join NAMDINH_QLBN.dbo.BENHNHAN_PHIEUDIEUTRI b on a.MaVaoVien = b.MaVaoVien and a.SoPhieuCD = b.SoPhieu  inner join NAMDINH_QLBN.dbo.DMLENCHIPHI_BYKHOID d on d.MaDichvu = a.MaDichVu where a.MaVaoVien = '{0}' and a.TinhPhi = 1 and b.NgayChiDinh >= '{1:dd/MM/yyyy HH:mm}'", fgDanhSach.GetDataDisplay(fgDanhSach.Row, "MaVaoVien"), ngaychuyen1, lanchuyen1);
                                cmd.CommandText = Str;
                                cmd.ExecuteNonQuery();
                            }

                        }
                    //}
                }
                catch
                {
                    MessageBox.Show("Chưa thực hiện được.", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                finally
                {
                    cmd.Dispose();
                }

            }
        }

        private void fgDanhSach_AfterRowColChange(object sender, C1.Win.C1FlexGrid.RangeEventArgs e)
        {
            ResetTT();
            if (fgDanhSach.Tag.ToString() == "0") return;
            if (fgDoiTuong.Tag.ToString() == "0") return;
            LoatDoiTuongCT();

        }
        public void ResetTT()
        {
            txtNgayThayDoi.Value = null;
            cmbDoiTuongBN.SelectedIndex = -1;
            txtSoTheBHYT.Text = "";
            dtBHTu.Value = null;
            dtBHDen.Value = null;
            txtTenBHYTTinh.Text = "";
            cmbTuyen.SelectedIndex = -1;
            txtMaDT.Text = "";
            txtTenDT.Text = "";
            txtManoicap.Text = "";
            txtTennoicap.Text = "";
            lblMaLoi.Text = rtbThongBao.Text = "";
            txtHoTen.Text = "";
            txtSoHSBA1.Text = txtSoHSBA.Text = "";
            txtMaBenNhan1.Text = txtGoiTinh.Text = "";
            fgDoiTuong.Rows.Count = 1;
            //fgDanhSach.Rows.Count = 1;
        }

        private void txtManoicap_Validated(object sender, EventArgs e)
        {
            if (txtSoTheBHYT.Text == "") return;
            if (fgDanhSach.Row <= 0) return;
            String Str = "";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.Connection = GlobalModuls.Global.ConnectSQL;
            System.Data.SqlClient.SqlDataReader dr;

            Str = "Select * from [" + Global.glbSysDB + "].dbo.DMNOIDKKCBBD_BHYT where MaNoiCap='" + txtManoicap.Text.Replace(" ", "") + "'";
            cmd.CommandText = Str;
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                txtManoicap.Text = dr["MaNoiCap"].ToString();
                txtTennoicap.Text = dr["TenNoiCap"].ToString();
            }
            dr.Close();
            dr.Dispose();
            cmd.Dispose();

        }

        private void txtMaDT_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtMaDT_Validated(null, null);
            }
        }

        private void txtManoicap_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtManoicap_Validated(null, null);
            }
        }

        private void cmdTimKiemDoiTuongBHYT_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.DanhMuc.frmFindDoiTuongBHYT frm = new NamDinh_QLBN.Forms.DanhMuc.frmFindDoiTuongBHYT();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtMaDT.Text = frm.Ma;
                txtTenDT.Text = frm.Ten;
            }
        }

        private void cmdTimNoiDangKy_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.DanhMuc.frmFindNoiDangKy frm = new NamDinh_QLBN.Forms.DanhMuc.frmFindNoiDangKy();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtManoicap.Text = frm.Ma;
                txtTennoicap.Text = frm.Ten;
            }
        }
        public bool GetSession()
        {
            if (MaKetQua != "200")
            {
                WebClient client = new WebClient();
                NameValueCollection values = new NameValueCollection();
                values.Add("username", "36001_BV");
                values.Add("password", "e10adc3949ba59abbe56e057f20f883e");
                byte[] bytes = client.UploadValues("https://egw.baohiemxahoi.gov.vn/api/token/take", values);
                string str = Encoding.UTF8.GetString(bytes);
                string[] separator = new string[] { "\"maKetQua\"", "\"APIKey\"", "\"access_token\"", "\"id_token\"", "\"token_type\"" };
                string[] strArray2 = str.Split(separator, StringSplitOptions.None);
                MaKetQua = strArray2[1].Substring(2, 3);
                Access_Token = strArray2[3].Substring(0, strArray2[3].Length - 2).Substring(2, strArray2[3].Length - 4);
                IDToken = strArray2[4].Substring(0, strArray2[4].Length - 2).Substring(2, strArray2[4].Length - 4);
                return false;
            }
            else
            {
                return true;
            }
        }
        public void CheckTheBHYT(string MaThe, string HoTen, string NgaySinh)
        {
            try
            {
                if(txtSoTheBHYT.Text.Length == 13 || txtSoTheBHYT.Text.Length == 10)
                {
                    //Lấy phiên làm việc--------------------------------------
                    WebClient client1 = new WebClient();
                    NameValueCollection values1 = new NameValueCollection();
                    values1.Add("username", "36001_BV");
                    values1.Add("password", "e10adc3949ba59abbe56e057f20f883e");
                    byte[] bytes1 = client1.UploadValues("https://egw.baohiemxahoi.gov.vn/api/token/take", values1);
                    string str1 = Encoding.UTF8.GetString(bytes1);
                    string[] separator1 = new string[] { "\"maKetQua\"", "\"APIKey\"", "\"access_token\"", "\"id_token\"", "\"token_type\"" };
                    string[] strArray2 = str1.Split(separator1, StringSplitOptions.None);
                    MaKetQua = strArray2[1].Substring(2, 3);
                    Access_Token = strArray2[3].Substring(0, strArray2[3].Length - 2).Substring(2, strArray2[3].Length - 4);
                    IDToken = strArray2[4].Substring(0, strArray2[4].Length - 2).Substring(2, strArray2[4].Length - 4);
                    // Kiểm tra lịch sử ---------------------------------------
                    txtLichSuKCB.Text = "";
                    rtbThongBao.Text = "";
                    lblMaLoi.Text = "";
                    System.Net.WebClient client = new System.Net.WebClient();
                    NameValueCollection values = new NameValueCollection();
                    values.Add("maThe", MaThe);
                    values.Add("hoTen", HoTen);
                    values.Add("ngaySinh", NgaySinh);
                    byte[] bytes = client.UploadValues(string.Format(" http://egw.baohiemxahoi.gov.vn/api/egw/KQNhanLichSuKCB2019?token={0}&id_token={1}&username={2}&password={3}", new object[] { Access_Token, IDToken, "36001_BV", "e10adc3949ba59abbe56e057f20f883e" }), values);
                    string str = Encoding.UTF8.GetString(bytes);
                    string[] separator = new string[] { "{\"maKetQua\":\"", "\",\"ghiChu\":\"", "\",\"maThe\":\"", "\",\"hoTen\":\"", };
                    string[] gtThe = new string[] { "\"gtTheTu\":\"", "\",\"gtTheDen\":\"", "\",\"maKV\":\"" };
                    string[] LSKCB = new string[] { "\"", ",", ":" };
                    string[] ThongTinBenhNhan_str = new string[] { "\"hoTen\":\"", "\",\"ngaySinh\":\"", "\",\"gioiTinh\":\"", "\",\"diaChi\":\"", "\",\"maDKBD\":\"", "\",\"cqBHXH\":\"" };

                    string[] returnThongBao = str.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                    if (returnThongBao[0].ToString() == "000" || returnThongBao[0].ToString() == "003" || returnThongBao[0].ToString() == "004")
                        //|| returnThongBao[0].ToString() == "003" || returnThongBao[0].ToString() == "001" || returnThongBao[0].ToString() == "002" || returnThongBao[0].ToString() == "004")
                    {
                        string[] ThongTinBenhNhan_split = str.Split(ThongTinBenhNhan_str, StringSplitOptions.RemoveEmptyEntries);
                        MaQuyenLoi = returnThongBao[2].ToString().Substring(0,2);
                        SotheBHYT = returnThongBao[2].ToString().Substring(2, returnThongBao[2].Length - 2);
                        Ho_Ten = ThongTinBenhNhan_split[1];
                        Nam_Sinh = ThongTinBenhNhan_split[2].Substring(ThongTinBenhNhan_split[2].Length - 4, 4);
                        Gioi_Tinh = ThongTinBenhNhan_split[3];
                        Noi_DKCBBD = ThongTinBenhNhan_split[5];
                        string[] HanThe = returnThongBao[3].Split(gtThe, StringSplitOptions.RemoveEmptyEntries);
                        string gtTheTu = HanThe[1].ToString();
                        string gtTheDen = HanThe[2].ToString();
                        dtBHTu.Value = DateTime.Parse(gtTheTu);
                        dtBHDen.Value = DateTime.Parse(gtTheDen);
                        if(txtSoTheBHYT.Text.Length == 10)
                        {
                            txtSoTheBHYT.Text = returnThongBao[2].ToString().Substring(2, returnThongBao[2].Length - 2);
                            txtMaDT.Text = returnThongBao[2].ToString().Substring(0, 2);
                            txtManoicap.Text = ThongTinBenhNhan_split[5].ToString();
                        }
                        string[] LichSuKCB = returnThongBao[3].Split(LSKCB, StringSplitOptions.RemoveEmptyEntries);
                        for (int i = 0; i < LichSuKCB.Length - 1; i++)
                        {
                            if (LichSuKCB[i] == "maHoSo")
                            {
                                string hoso = "";
                                hoso = LichSuKCB[i + 1];
                                string cskcb = "";
                                cskcb = LichSuKCB[i + 3];
                                string NgayVao = "";
                                NgayVao = LichSuKCB[i + 5];
                                string NgayRa = "";
                                NgayRa = LichSuKCB[i + 7];
                                string TinhTrang = "";
                                if (LichSuKCB[i + 10] == "1") TinhTrang = "Ra viện";
                                if (LichSuKCB[i + 10] == "2") TinhTrang = "Chuyển viện";
                                if (LichSuKCB[i + 10] == "3") TinhTrang = "Trốn viện";
                                if (LichSuKCB[i + 10] == "4") TinhTrang = "Xin ra viện";
                                string KQDT = "";
                                KQDT = LichSuKCB[i + 12];
                                if (LichSuKCB[i + 12] == "1") KQDT = "Khỏi";
                                if (LichSuKCB[i + 12] == "2") KQDT = "Đỡ";
                                if (LichSuKCB[i + 12] == "3") KQDT = "Không thay đổi";
                                if (LichSuKCB[i + 12] == "4") KQDT = "Nặng hơn";
                                if (LichSuKCB[i + 12] == "5") KQDT = "Tử vong";
                                txtLichSuKCB.Text += "Mã Hồ Sơ: " + hoso + " - Từ Ngày: " + NgayVao.Substring(8, 2) + ":" + NgayVao.Substring(10, 2) + " " + NgayVao.Substring(6, 2) + "/" + NgayVao.Substring(4, 2) + "/" + NgayVao.Substring(0, 4) + " - Đến Ngày: " + NgayRa.Substring(8, 2) + ":" + NgayRa.Substring(10, 2) + " " + NgayRa.Substring(6, 2) + "/" + NgayRa.Substring(4, 2) + "/" + NgayRa.Substring(0, 4) + " - Cơ Sở khám Chữa Bệnh: " + cskcb + " - Tình trạng :" + TinhTrang + " - Kết quả ĐT: " + KQDT + "\r\n";
                            }
                        }
                    }
                    maloi = returnThongBao[0].ToString();
                    if (maloi == "000")
                    { lblMaLoi.Text = "Thông tin thẻ chính xác "; };
                    if (maloi == "001")
                    { lblMaLoi.Text = "Thẻ do BHXH Bộ quốc phòng quản lý, đề nghị kiểm tra thẻ và thông tin giấy tờ tùy thân"; };
                    if (maloi == "002")
                    { lblMaLoi.Text = "Thẻ do BHXH Bộ Công an quản lý, đề nghị kiểm tra thẻ và thông tin giấy tờ tùy thân"; };
                    if (maloi == "003")
                    { lblMaLoi.Text = "Thẻ cũ hết giá trị sử dụng, được cấp thẻ mới"; };
                    if (maloi == "004")
                    { lblMaLoi.Text = "Thẻ cũ còn giá rị sử dụng, được cấp thẻ mới"; };
                    if (maloi == "010")
                    { lblMaLoi.Text = "Thẻ hết giá trị sử dụng"; return; };
                    if (maloi == "051")
                    { lblMaLoi.Text = "Mã thẻ không đúng"; return; };
                    if (maloi == "052")
                    { lblMaLoi.Text = "Mã tỉnh cấp thẻ (ký tự thứ 4,5 của mã thẻ) không đúng"; return; };
                    if (maloi == "053")
                    { lblMaLoi.Text = "Mã quyền lợi thẻ(Ký tự thứ 3 của mã thẻ) không đúng"; return; };
                    if (maloi == "050")
                    { lblMaLoi.Text = "Không thấy thông tin thẻ BHYT"; return; };
                    if (maloi == "060")
                    { lblMaLoi.Text = "Thẻ sai họ tên "; return; };
                    if (maloi == "061")
                    { lblMaLoi.Text = "Thẻ sai họ tên đúng ký tự đầu"; return; };
                    if (maloi == "070")
                    { lblMaLoi.Text = "Thẻ sai ngày sinh "; return; };
                    if (maloi == "080")
                    { lblMaLoi.Text = "Thẻ sai giới tính "; return; };
                    if (maloi == "090")
                    { lblMaLoi.Text = "Thẻ sai nơi đăng ký KCBBĐ "; return; };
                    if (maloi == "100")
                    { lblMaLoi.Text = "Lỗi khi lấy dữ liệu số thẻ "; return; };
                    if (maloi == "101")
                    { lblMaLoi.Text = "Lỗi server "; return; };
                    if (maloi == "110")
                    { lblMaLoi.Text = "Thẻ đã thu hồi "; return; };
                    if (maloi == "120")
                    { lblMaLoi.Text = "Thẻ đã báo giảm "; return; };
                    if (maloi == "121")
                    { lblMaLoi.Text = "Thẻ đã báo giảm. Giảm chuyển ngoại tỉnh "; return; };
                    if (maloi == "122")
                    { lblMaLoi.Text = "Thẻ đã báo giảm. Giảm chuyển nội tỉnh "; return; };
                    if (maloi == "123")
                    { lblMaLoi.Text = "Thẻ đã báo giảm. Thu hồi do tăng lại cùng đơn vị "; return; };
                    if (maloi == "124")
                    { lblMaLoi.Text = "Thẻ đã báo giảm. Ngừng tham gia "; return; };
                    if (maloi == "130")
                    { lblMaLoi.Text = "Trẻ em không xuất trình thẻ "; return; };
                    if (maloi == "205")
                    {
                        rtbThongBao.Text = "";
                    }
                    else
                    {
                        rtbThongBao.Text = returnThongBao[1].ToString();
                    }
                }
                
            }
            catch
            {
                MessageBox.Show("Lỗi");
                return;
            }
        }
        private string ConvertHexStrToUnicode(string hexString)
        {
            int length = hexString.Length;
            byte[] bytes = new byte[length / 2];

            for (int i = 0; i < length; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hexString.Substring(i, 2), 16);
            }
            return Encoding.UTF8.GetString(bytes);
        }
        private void cmbTuyen_TextChanged(object sender, EventArgs e)
        {
            CapCuu = 0;
            if (cmbTuyen.SelectedIndex == 2)
            {
                CapCuu = 1;
            }
            else
            {
                CapCuu = 0;
            }
        }

        private void txtbarcode_Validated(object sender, EventArgs e)
        {

        }

        private void txtbarcode_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtbarcode.Text.Trim() == "") return;
            if (txtbarcode.Text.Substring(txtbarcode.Text.Length - 1) == "$")
            {

                const char Comma = '|';
                // mảng các dấu cách
                char[] delimiters = new char[] { Comma };
                // dùng StringBuilder để  tạo một chuỗi
                StringBuilder output = new StringBuilder();
                // tách chuỗi, sau đó ghép lại theo dang mong muốn
                // tách chuỗi theo các dấu phân cách trong delimiter
                string[] subString = txtbarcode.Text.Split(delimiters);
                if (subString[0].Length == 10)
                {
                    txtMaDT.Text = "";
                    txtSoTheBHYT.Text = subString[0].ToString();
                    txtHoTen.Text = ConvertHexStrToUnicode(subString[1].ToString()).ToUpper();
                    txtManoicap.Text = subString[5].Remove(2, 3);
                    //DiaChi = ConvertHexStrToUnicode(subString[4].ToString());
                    //HoTenChaMe = ConvertHexStrToUnicode(subString[10].ToString());
                    //txtTuoi.Text = subString[2].Substring(0);
                    if (subString[3].ToString() == "2") { txtGoiTinh.Text = "Nữ"; } else { txtGoiTinh.Text = "Nam"; }
                    if (txtHoTen.Text == fgDanhSach.GetDataDisplay(fgDanhSach.Row, "TenBN"))
                    {
                        CheckTheBHYT(txtMaDT.Text + txtSoTheBHYT.Text, txtHoTen.Text, txtTuoi.Text);
                    }
                    else
                    {
                        MessageBox.Show("Quyét nhầm nhẻ");
                        Edit = Add = false;
                        EnableEdit(false);
                        txtNgayThayDoi.Value = null;
                        cmbDoiTuongBN.SelectedIndex = -1;
                        fgDoiTuong.Rows.Count = 1;
                        //ResetTT();
                        txtbarcode.Text = "";
                        txtLichSuKCB.Text = "";
                        fgDanhSach_AfterRowColChange(null, null);
                        return;
                    }
            }
                if (subString[0].Length == 15)
                {
                    txtMaDT.Text = subString[0].Substring(0, 2);
                    txtSoTheBHYT.Text = subString[0].Substring(2);
                    string a = subString[5].Remove(2, 3);
                    txtManoicap.Text = a;
                    txtHoTen.Text = ConvertHexStrToUnicode(subString[1].ToString()).ToUpper();
                    //DiaChi = ConvertHexStrToUnicode(subString[4].ToString());
                    //HoTenChaMe = ConvertHexStrToUnicode(subString[10].ToString());
                    //txtTuoi.Text = subString[2].Substring(0);
                    if (subString[3].ToString() == "2") { txtGoiTinh.Text = "Nữ"; } else { txtGoiTinh.Text = "Nam"; }
                    if (txtHoTen.Text == fgDanhSach.GetDataDisplay(fgDanhSach.Row, "TenBN"))
                    {
                        CheckTheBHYT(txtMaDT.Text + txtSoTheBHYT.Text, txtHoTen.Text, txtTuoi.Text);
                    }
                    else
                    {
                        MessageBox.Show("Quyét nhầm nhẻ");
                        Edit = Add = false;
                        EnableEdit(false);
                        txtNgayThayDoi.Value = null;
                        cmbDoiTuongBN.SelectedIndex = -1;
                        fgDoiTuong.Rows.Count = 1;
                        //ResetTT();
                        txtbarcode.Text = "";
                        txtLichSuKCB.Text = "";
                        fgDanhSach_AfterRowColChange(null, null);
                        return;
                    }
                }
                
            }
        }

        private void bntKCBBD_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.DanhMuc.frmFindNoiDangKy frm = new NamDinh_QLBN.Forms.DanhMuc.frmFindNoiDangKy();
            frm.Show();
        }

        private void txtMaKhamBenh_TextChanged(object sender, EventArgs e)
        {
            ResetTT();
            txtbarcode.Text = "";
            txtLichSuKCB.Text = "";
            if (txtMaKhamBenh.Text.Length != 10)
            {
                txtMaKhamBenh.Focus();
            }
            else
            {
                ResetTT();
                fgDanhSach.Tag = 0;
                fgDoiTuong.Tag = 0;
                Load_DSBenhNhan();
                fgDanhSach.Tag = 1;
                fgDoiTuong.Tag = 1;

                if (fgDanhSach.Tag.ToString() == "0") return;
                if (fgDoiTuong.Tag.ToString() == "0") return;
                LoatDoiTuongCT();
                fgDoiTuong_Click(null, null);
                txtbarcode.Focus();
            }

       } 

        private void txtSoTheBHYT_KeyUp(object sender, KeyEventArgs e)
        {

            if((txtMaDT.Text.Length + txtSoTheBHYT.Text.Length) == 15)
            {
                CheckTheBHYT(txtMaDT.Text + txtSoTheBHYT.Text, txtHoTen.Text, txtTuoi.Text);
            }
            else
            {
                CheckTheBHYT(txtSoTheBHYT.Text, txtHoTen.Text, txtTuoi.Text);
            }
            
        }

        public void Docbarcode()
        {
            string Chuoibarcode = "HS7790900400931|4E677579E1BB856E204E67E1BB8D63205068C6B0C6A16E67205468616E68|01/08/2006|2|5472C6B0E1BB9D6E67205469E1BB83752068E1BB8D63204368C3AD204C696E68|79 - 032|01/10/2012|30/09/2013|06/09/2013|790900200883|4CC3AA205468E1BB8B204E67E1BB8D6320517579C3AA6E205068E1BAA16D2056C4836E2044C6B0E1BBA16E67|1|01/01/2014|3CCF511358E91762-0101|$";
            //string MaDoiTuong, SoTheBHYt, MaNoiCap, GtriTu, GtriDen, HoTen, DiaChi, NamSinh, GioiTinh, HoTenChaMe = "";
            if (Chuoibarcode.Substring(Chuoibarcode.Length - 1) == "$")
            {
                
                const char Comma = '|';
                // mảng các dấu cách
                char[] delimiters = new char[] { Comma };
                // dùng StringBuilder để  tạo một chuỗi
                StringBuilder output = new StringBuilder();
                // tách chuỗi, sau đó ghép lại theo dang mong muốn
                // tách chuỗi theo các dấu phân cách trong delimiter
                string[] subString = Chuoibarcode.Split(delimiters);

                if (subString[0].Length == 15)
                {
                    txtMaDT.Text = subString[0].Substring(0, 2);
                    txtSoTheBHYT.Text = subString[0].Substring(2);
                }
                string a = subString[5].Remove(2, 3);
                txtManoicap.Text = a;
                txtHoTen.Text = ConvertHexStrToUnicode(subString[1].ToString()).ToUpper();
                //DiaChi = ConvertHexStrToUnicode(subString[4].ToString());
                //HoTenChaMe = ConvertHexStrToUnicode(subString[10].ToString());
                if(subString[2].Length<6)
                {
                    txtTuoi.Text = subString[2].Substring(0);
                }
                else
                { txtTuoi.Text = subString[2].Substring(6, 4); }
                if (subString[3].ToString() == "2") { txtGoiTinh.Text = "Nữ"; } else { txtGoiTinh.Text = "Nam"; }
            }
        }
    }
}