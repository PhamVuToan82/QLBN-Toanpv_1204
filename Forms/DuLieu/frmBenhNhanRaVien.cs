
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GlobalModuls;
using System.Net;
using System.Collections.Specialized;
namespace NamDinh_QLBN.Forms.DuLieu
{
    public partial class frmBenhNhanRaVien : Form
    {
        private string SoTheBHYT = "";
        //private DateTime? HanTheTu = null;
        //private DateTime? HanTheDen = null;
        private string HanTheTu = "";
        private string HanTheDen = "";
        private string Diachi;
        private string Namsinh;
        private static string Access_Token;
        private static string IDToken;
        public static string MaKetQua;
        public static string Mes;
        public static object password;
        public const string username = "36001_BV";
        DateTime NgayVaoVien;
        DateTime NgayRaVien;
        DateTime NgayKham;
        private double SoLuongNgayDT;
        bool xacnhan = false;
        string ThoigianDK;
        public string SOHOSOCHUYENVIEN = "";
        public static bool GetSession()
        {
            try
            {

                WebClient client = new WebClient();
                NameValueCollection values = new NameValueCollection();
                values.Add("username", "36001_BV");
                values.Add("password", "e10adc3949ba59abbe56e057f20f883e");

                byte[] bytes = client.UploadValues("https://egw.baohiemxahoi.gov.vn/api/token/take", values);
                string str = Encoding.UTF8.GetString(bytes);
                string[] separator = new string[] { "\"maKetQua\"", "\"APIKey\"", "\"access_token\"", "\"id_token\"", "\"token_type\"" };
                string[] strArray2 = str.Split(separator, StringSplitOptions.None);
                string MaKetQua = strArray2[1].Substring(2, 3);
                bool flag2 = true;
                if (MaKetQua == "200")
                {
                    Access_Token = strArray2[3].Substring(0, strArray2[3].Length - 2).Substring(2, strArray2[3].Length - 4);
                    IDToken = strArray2[4].Substring(0, strArray2[4].Length - 2).Substring(2, strArray2[4].Length - 4);
                    return flag2;
                }
                if (MaKetQua == "401")
                {
                    MessageBox.Show("Lỗi xác thực Được với cơ quan BHYT");
                }
                if (MaKetQua == "500")
                {
                    MessageBox.Show("Lỗi khi kết nối tới cổng BHXH");
                }
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
            return false;
        }
        public  void CheckTheBHYT(string MaThe, string HoTen, string NgaySinh, string GioiTinh, string MaCSKCB, string NgayBD, string NgayKT)
        {
            //if (GetSession())
            //{
            WebClient client = new WebClient();
            NameValueCollection values = new NameValueCollection();
            values.Add("maThe", MaThe);
            values.Add("hoTen", HoTen);
            values.Add("ngaySinh", NgaySinh);
            values.Add("gioiTinh", GioiTinh);
            values.Add("maCSKCB", MaCSKCB);
            values.Add("ngayBD", NgayBD);
            values.Add("ngayKT", NgayKT);
            //byte[] bytes = client.UploadValues(string.Format("https://egw.baohiemxahoi.gov.vn/api/egw/KQnhanLichSuKCB595?token={0}&id_token={1}&username={2}&password={3}", new object[] { Access_Token, IDToken, "36001_BV", "e10adc3949ba59abbe56e057f20f883e" }), values);
            byte[] bytes = client.UploadValues(string.Format("https://egw.baohiemxahoi.gov.vn/api/egw/KQNhanLichSuKCB2019?token={0}&id_token={1}&username={2}&password={3}", new object[] { Access_Token, IDToken, "36001_BV", "e10adc3949ba59abbe56e057f20f883e" }), values);
            string str = Encoding.UTF8.GetString(bytes);
            string[] separator = new string[] { "{\"maKetQua\":", ",\"dsLichSuKCB\":" };
            string[] strArray4 = str.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            MaKetQua = strArray4[0].Substring(0, strArray4[0].Length - 1).Substring(1, strArray4[0].Length - 2);
            //strArray4[1] = strArray4[1].Substring(0, strArray4[1].Length - 1).Substring(1, strArray4[1].Length - 2);
            string[] strArray = new string[] { "{", "\"maCSKCB\":", "\"tuNgay\":", ",\"denNgay\":", "\"tenBenh\":", ",\"tinhTrang\":", "\"kqDieuTri\":" };
            string[] MaHS = new string[] { "{\"maHoSo\":" };
            string[] MaHs_ct = str.Split(MaHS, StringSplitOptions.RemoveEmptyEntries);
            string[] maCSKCB = new string[] { "\"maCSKCB\":" };
            string[] maCSKCB_ct = str.Split(maCSKCB, StringSplitOptions.RemoveEmptyEntries);
            string[] tenBenh = new string[] { "\"tenBenh\":" };
            string[] tenBenh_ct = str.Split(tenBenh, StringSplitOptions.RemoveEmptyEntries);
            string[] tuNgay = new string[] { "\"ngayVao\":" };
            string[] tuNgay_ct = str.Split(tuNgay, StringSplitOptions.RemoveEmptyEntries);
            string[] denNgay = new string[] { "\"ngayRa\":" };
            string[] denNgay_ct = str.Split(denNgay, StringSplitOptions.RemoveEmptyEntries);
            //string[] strArray3 = strArray4[1].Split(strArray, StringSplitOptions.RemoveEmptyEntries);
            const char x2 = ',';
            const char x3 = '"';
            const char x4 = '}';
            const char x5 = '{';
            //   const char x6 = '';
            //char[] delimiters = new char[] { x3, x4, x5 };
            //string[] strArray3 = strArray4[1].Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            //for (int j = 0; j <= strArray3.Length - 1; j++)
            //{
            //    if (strArray3[j] == "maHoSo")
            //    {
            //        string maHoSo = strArray3[j + 1];

            //    }
            //}
            string maKetQua = MaKetQua;
            string[] subString = maKetQua.Split('"');
            string str3 = maKetQua.Substring(0, 3);
            //if (str3 == "000")
            //{ string t3 = "Thông tin thẻ chính xác "; MessageBox.Show("KHÔNG CHUYỂN ĐƯỢC ĐỐI TƯỢNG CHO BỆNH NHÂN DO " + t3); };
            //if (str3 == "001")
            //{ str3 = "Thẻ do BHXH Bộ quốc phòng quản lý, đề nghị kiểm tra thẻ và thông tin giấy tờ tùy thân"; };
            //if (str3 == "002")
            //{ string t3 = "Thẻ do BHXH Bộ Công an quản lý, đề nghị kiểm tra thẻ và thông tin giấy tờ tùy thân"; };
            if (str3 == "010")
            { string t3 = "Thẻ hết giá trị sử dụng"; MessageBox.Show(t3); return; };
            if (str3 == "051")
            { string t3 = "Mã thẻ không đúng"; MessageBox.Show(t3); return; };
            if (str3 == "052")
            { string t3 = "Mã tỉnh cấp thẻ (ký tự thứ 4,5 của mã thẻ) không đúng"; MessageBox.Show(t3); return; };
            if (str3 == "053")
            { string t3 = "Mã quyền lợi thẻ(Ký tự thứ 3 của mã thẻ) không đúng"; MessageBox.Show(t3); return; };
            if (str3 == "050")
            { string t3 = "Không thấy thông tin thẻ BHYT"; MessageBox.Show(t3); return; };
            if (str3 == "060")
            { string t3 = "Thẻ sai họ tên "; MessageBox.Show(t3); return; };
            if (str3 == "061")
            { string t3 = "Thẻ sai họ tên đúng ký tự đầu"; MessageBox.Show(t3); return; };
            if (str3 == "070")
            { string t3 = "Thẻ sai ngày sinh "; MessageBox.Show(t3); return; };
            if (str3 == "080")
            { string t3 = "Thẻ sai giới tính "; MessageBox.Show(t3); return; };
            if (str3 == "090")
            { string t3 = "Thẻ sai nơi đăng ký KCBBĐ "; MessageBox.Show(t3); return; };
            if (str3 == "100")
            { string t3 = "Lỗi khi lấy dữ liệu số thẻ "; MessageBox.Show(t3); return; };
            if (str3 == "101")
            { string t3 = "Lỗi server "; MessageBox.Show(t3); return; };
            if (str3 == "110")
            { string t3 = "Thẻ đã thu hồi "; MessageBox.Show(t3); return; };
            if (str3 == "120")
            { string t3 = "Thẻ đã báo giảm "; MessageBox.Show(t3); return; };
            if (str3 == "121")
            { string t3 = "Thẻ đã báo giảm. Giảm chuyển ngoại tỉnh "; MessageBox.Show(t3); return; };
            if (str3 == "122")
            { string t3 = "Thẻ đã báo giảm. Giảm chuyển nội tỉnh "; MessageBox.Show(t3); return; };
            if (str3 == "123")
            { string t3 = "Thẻ đã báo giảm. Thu hồi do tăng lại cùng đơn vị "; MessageBox.Show(t3); return; };
            if (str3 == "124")
            { string t3 = "Thẻ đã báo giảm. Ngừng tham gia "; MessageBox.Show(t3); return; };
            //if (str3 == "130")
            //{ string t3 = "Trẻ em không xuất trình thẻ "; MessageBox.Show(t3);};
            //}

        }

        public void Guihosogiamdinh_4210()
        {
        }


        public frmBenhNhanRaVien()
        {
            InitializeComponent();
            GetSession();
        }

        private void frmBenhNhanRaVien_Load(object sender, EventArgs e)
        {
            cmbKhoa.Tag = "0";
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

            SQLCmd.CommandText = "SELECT * FROM viewDSBenhVien order by TenBV";
            dr = SQLCmd.ExecuteReader();
            cmbDSBenhVien.Tag = "0";
            cmbDSBenhVien.ClearItems();
            while (dr.Read())
            {
                cmbDSBenhVien.AddItem(string.Format("{0};{1}", dr["MaBV"], dr["TenBV"]));
            }
            dr.Close();

            SQLCmd.CommandText = string.Format("SELECT * FROM DMBACSY WHERE DMBACSY.MAKHOA in {0}  and Khongsudung = 0  order by TenBS", Global.glbKhoa_CapNhat);
            dr = SQLCmd.ExecuteReader();
            cmbBS.Tag = "0";
            cmbBS.ClearItems();
            while (dr.Read())
            {
                cmbBS.AddItem(string.Format("{0};{1}", dr["MaBS"], dr["TenBS"]));
            }
            dr.Close();


            SQLCmd.CommandText = string.Format("SELECT * FROM DMBACSY WHERE DMBACSY.MAKHOA in {0}  and Khongsudung = 0 and MaChucVu in(3,4) order by MaChucVu", Global.glbKhoa_CapNhat);
            dr = SQLCmd.ExecuteReader();
            CmbTruongPho.Tag = "0";
            CmbTruongPho.ClearItems();
            while (dr.Read())
            {
                CmbTruongPho.AddItem(string.Format("{0};{1}", dr["MaBS"], dr["TenBS"]));
            }
            CmbTruongPho.SelectedIndex = 0;
            dr.Close();
            SQLCmd.Dispose();

            cmbDSBenhVien.SelectedIndex = -1;
            cmbNoiRaVien.Tag = 0;
            GlobalModuls.Global.Set_Combo_Fileds(cmbKQDT, "DMKETQUADT", "MaKQDT", "TenKQDT");
            GlobalModuls.Global.Set_Combo_Fileds(cmbNoiRaVien, "DMNOIRAVIEN", "MaNoiRa", "TenNoiRa");
            GlobalModuls.Global.Set_Combo_Fileds(cmbKhaNangLD, "DMKHANANGLD", "MaKNLD", "TenKNLD");
            cmbNoiRaVien.Tag = 1;
            cmbKhoa.Tag = "1";
            cmbDSBenhVien.Tag = "1";
            cmbBS.Tag = "1";
            txtDKNgayRV.Tag = "0";
            txtDKNgayRV.Value = Global.NgayLV;
            txtDKNgayRV.Tag = "1";
            fgDanhSach.ClipSeparators = "|;";
            Global.SetCmb(cmbKhoa, Global.glbMaKhoaPhong);
            GlobalModuls.Global.SetCmb(cmbKhoa, Global.glbMaKhoaPhong);
            Load_DSBenhNhan();
            EnabledChuyenVien(false);
        }
        private void Load_DSBenhNhan()
        {
            if (cmbKhoa.SelectedIndex == -1 || cmbKhoa.Tag.ToString() == "0") { return; }
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.CommandTimeout = 0;
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            string MaKhoa = Global.GetCode(cmbKhoa);
            SQLCmd.CommandText = "set dateformat dmy select BENHNHAN_CHITIET.MaVaoVien,BENHNHAN.HoTen As TenBenhNhan, NamSinh as Tuoi,"
                + " GioiTinh,TenDT,ViewKHOAHIENTAI.NgayChuyenDau as NgayVaoVien,case when benhnhan_chitiet.ChanDoanRaVien is null then viewkhoahientai.ChanDoan else benhnhan_chitiet.ChanDoanRaVien end as ChanDoanRaVien,"
                + " BENHNHAN_CHITIET.Diachi, isnull(ViewDOITUONGHIENTAI.MadoituongBHXH,'') + ' - ' + isnull(ViewDOITUONGHIENTAI.Sothe,'') + ' - '  + isnull(ViewDOITUONGHIENTAI.Manoicap,'') as SotheBHYT, "
                + " isnull(ViewDOITUONGHIENTAI.GtriTu,'') as GiatriTu, isnull(ViewDOITUONGHIENTAI.GtriDen,'') as GiatriDen,  NamSinh,benhnhan_chitiet.NgayKham,benhnhan_chitiet.HO_TEN_CHA,benhnhan_chitiet.HO_TEN_ME,BENHNHAN_CHITIET.datinhphi,ViewDOITUONGHIENTAI.Tuyen,BENHNHAN_CHITIET.SOHOSOCHUYENVIEN  AS SOHOSOCHUYENVIEN, NgayKham,SoHSBA,SoLuuTru,In_BenhAn,(YEAR(getdate()) - NamSinh) as tuoi1, Benhnhan_chiTiet.IDBo,Benhnhan_chiTiet.IDMe"
                + " FROM (((BENHNHAN INNER JOIN BENHNHAN_CHITIET ON BENHNHAN.MaBenhNhan=BENHNHAN_CHITIET.MaBenhNhan)"
                + " INNER JOIN ViewDOITUONGHIENTAI ON BENHNHAN_CHITIET.MaVaoVien=ViewDOITUONGHIENTAI.MaVaoVien)"
                + " INNER JOIN DMDOITUONGBN ON ViewDOITUONGHIENTAI.DoiTuong=DMDOITUONGBN.MaDT)"
                + " INNER JOIN ViewKHOAHIENTAI ON BENHNHAN_CHITIET.MaVaoVien=ViewKHOAHIENTAI.MaVaoVien "
                + " WHERE MaKhoa ='" + MaKhoa + "'  AND TrangThai=1 ";

            if (rdChuaRV.Checked)
            {
                SQLCmd.CommandText += " AND ViewKHOAHIENTAI.vDaRaVien=0";
                cmdICD_KhoaDieuTri_BP_1.Enabled = true;
            }
            else
            {
                SQLCmd.CommandText += " AND ViewKHOAHIENTAI.vDaRaVien=1";
                SQLCmd.CommandText += string.Format(" AND DateDiff(dd,NgayRaVien,'{0:dd/MM/yyyy}')=0", txtDKNgayRV.Value);
            }
            dr = SQLCmd.ExecuteReader();
            fgDanhSach.Tag = "0";
            fgDanhSach.Rows.Count = 1;
            while (dr.Read())
            {
                fgDanhSach.AddItem(string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6:dd/MM/yyyy HH:mm}|{7}|{8}|{9}|{10:dd/MM/yyyy}|{11:dd/MM/yyyy}|{12}|{13:dd/MM/yyyy HH:mm}|{14}|{15}|{16}|{17}|{18}|{19:dd/MM/yyyy HH:mm}|{20}|{21}|{22}|{23}|{24}|{25}", fgDanhSach.Rows.Count,
                    dr["MaVaoVien"],
                    dr["TenBenhNhan"],
                    dr["Tuoi"],
                    (dr["GioiTinh"].ToString() == "1") ? ("Nam") : ("Nữ"),
                    dr["TenDT"],
                    dr["NgayVaoVien"],
                    dr["ChanDoanRaVien"],
                    dr["Diachi"],
                    dr["SotheBHYT"],
                    dr["GiatriTu"],
                    dr["GiatriDen"],
                    dr["Namsinh"], dr["NgayKham"],dr["HO_TEN_CHA"],dr["HO_TEN_ME"], dr["datinhphi"],dr["Tuyen"], dr["SOHOSOCHUYENVIEN"], dr["NgayKham"],dr["SoHSBA"],dr["SoLuuTru"], dr["In_BenhAn"], dr["tuoi1"],dr["IDBo"],dr["IDMe"]));
            }
            dr.Close();
            fgDanhSach.AutoSizeCols();
            fgDanhSach.Tag = "1";
            SQLCmd.Dispose();
            if (rdChuaRV.Checked)
            {
                txtNgayRaVien.Value = Global.NgayLV;
            }
            if (cmbNoiRaVien.Text == "Chuyển viện")
            {
                EnabledChuyenVien(true);
            }
            else
            {
                EnabledChuyenVien(false);
            }

            for(int i = 1; i<= fgDanhSach.Rows.Count -1; i++ )
            {
                if(Global.GetNgayLV() >= DateTime.Parse("01/01/2021") &&  (DateTime.Parse(fgDanhSach[i, "NgayKham"].ToString()) <= DateTime.Parse("01/01/2021")) && (fgDanhSach[i,"datinhphi"].ToString() == "0" && fgDanhSach[i, "tuyen"].ToString() == "1" && fgDanhSach[i, 5].ToString() == "Bảo hiểm y tế"))
                {
                    fgDanhSach.Rows[i].StyleNew.BackColor = Color.YellowGreen;
                }
            }
            Clear_Data();
        }
        private void Clear_Data()
        {
            txtCachDieuTri.Text = "";
            cmbKQDT.SelectedIndex = -1;
            cmbNoiRaVien.SelectedIndex = -1;
            cmbKhaNangLD.SelectedIndex = -1;
            cmbDSBenhVien.SelectedIndex = -1;
            cmbBS.SelectedIndex = -1;
            txtTenBC.Text = "";
            txtTenBP.Text = "";
            txtGhiChu.Text = "";
            lblMaVaoVien.Text = lblTenBN.Text = lblTuoi.Text = lblGioi.Text = txtDiaChi.Text = txtChanDoanRaVien.Text = "";
            txtTenICD_KhoaDieuTri_BC.Text = txtTenICD_KhoaDieuTri_BP.Text = txtMaICD_BenhChinh.Text = txtMaICD_BenhPhu.Text = txtNguoiChuyen.Text = txtPhuongTien.Text = txtThuoc.Text = txtTinhTrangBN.Text = txtXetNghiem.Text = txtChanDoan.Text =
            txtLamSang.Text = txtLyDo.Text = txtMaICD_BenhPhu_1.Text = txtTenICD_KhoaDieuTri_BP_1.Text = txtMe.Text = txtBo.Text = txtIDBo.Text  =txtIDMe.Text = lblHosoCV.Text = "";
            chXacNhanRV.Checked = false;
            txtNgayHenKhamLai.Clear();

        }

        private void cmbKhoa_TextChanged(object sender, EventArgs e)
        {
            Load_DSBenhNhan();
        }
        private void Load_BenhNhan()
        {
            if (fgDanhSach.Row < 1) { return; }
            Clear_Data();
            string MaBN = fgDanhSach.GetDataDisplay(fgDanhSach.Row, 1);
            lblMaVaoVien.Text = MaBN;
            lblTenBN.Text = fgDanhSach.GetDataDisplay(fgDanhSach.Row, 2);
            lblTuoi.Text = fgDanhSach.GetDataDisplay(fgDanhSach.Row, 3);
            lblGioi.Text = fgDanhSach.GetDataDisplay(fgDanhSach.Row, 4);
            lblDoiTuong.Text = fgDanhSach.GetDataDisplay(fgDanhSach.Row, 5);
            lblNgayVaoVien.Text = fgDanhSach.GetDataDisplay(fgDanhSach.Row, 6);
            txtDiaChi.Text = fgDanhSach.GetDataDisplay(fgDanhSach.Row, 8);
            txtChanDoanRaVien.Text = fgDanhSach.GetDataDisplay(fgDanhSach.Row, "ChanDoanRaVien");
            NgayKham = DateTime.Parse(fgDanhSach.GetDataDisplay(fgDanhSach.Row, "NgayKham").ToString());
            txtBo.Text = fgDanhSach.GetDataDisplay(fgDanhSach.Row, "HO_TEN_CHA");
            txtIDBo.Text = fgDanhSach.GetDataDisplay(fgDanhSach.Row, "IDBo");
            txtMe.Text = fgDanhSach.GetDataDisplay(fgDanhSach.Row, "HO_TEN_ME");
            txtIDMe.Text = fgDanhSach.GetDataDisplay(fgDanhSach.Row, "IDMe");
            lblHosoCV.Text = fgDanhSach.GetDataDisplay(fgDanhSach.Row, "SOHOSOCHUYENVIEN");
            if (cmbNoiRaVien.Text == "Chuyển viện")
            {
                EnabledChuyenVien(true);
            }
            else
            {
                EnabledChuyenVien(false);
            }
            cmdICD_KhoaDieuTri_BP_1.Enabled = true;
                System.Data.SqlClient.SqlDataReader dr;
                System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
                SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
                SQLCmd.CommandText = string.Format("SELECT BENHNHAN_CHITIET.*,BENHCHINH.CICD10 AS MABC,BENHCHINH.VVIET AS TENBC,VIEWKHOAHIENTAI.MAICD_BP AS MABP,BENHPHU.VVIET AS TENBP,VIEWKHOAHIENTAI.MAICD_BP_1 AS MABP_1,BENHPHU_1.VVIET AS TENBP_1 FROM BENHNHAN_CHITIET "
                + " INNER JOIN VIEWKHOAHIENTAI ON VIEWKHOAHIENTAI.MAVAOVIEN = BENHNHAN_CHITIET.MAVAOVIEN"
                + " LEFT JOIN DMICD10 BENHCHINH ON BENHCHINH.CICD10 = VIEWKHOAHIENTAI.MAICD_BC"
                + " LEFT JOIN DMICD10 BENHPHU ON BENHPHU.CICD10 = VIEWKHOAHIENTAI.MAICD_BP"
                + " LEFT JOIN DMICD10 BENHPHU_1 ON BENHPHU_1.CICD10 = VIEWKHOAHIENTAI.MAICD_BP_1"
                    + " WHERE BENHNHAN_CHITIET.MaVaoVien='{0}'", lblMaVaoVien.Text);
                dr = SQLCmd.ExecuteReader();
                while (dr.Read())
                {
                txtNgayRaVien.Value = dr["NgayRaVien"];
                //txtNgayRaVien.Value = Global.NgayLV;
                txtNgayHenKhamLai.Value = dr["NgayHenKhamLai"];
                    txtCachDieuTri.Text = dr["CachDT"].ToString();
                    Global.SetCmb(cmbKQDT, dr["KetQuaDT"].ToString());
                    Global.SetCmb(cmbNoiRaVien, dr["NoiRaVien"].ToString());
                    Global.SetCmb(cmbKhaNangLD, dr["KhaNangLD"].ToString());
                    txtTenBC.Text = dr["BenhChinh_RaVien"].ToString();
                    txtTenBP.Text = dr["BenhPhu_RaVien"].ToString();
                    txtLoiDan.Text = dr["LoiDan_RaVien"].ToString();
                    txtGhiChu.Text = dr["GhiChu"].ToString();
                    txtLamSang.Text = dr["ChuyenVien_DauHieuLS"].ToString();
                    txtXetNghiem.Text = dr["ChuyenVien_CacXN"].ToString();
                    txtChanDoan.Text = dr["ChuyenVien_ChanDoan"].ToString();
                    txtThuoc.Text = dr["ChuyenVien_Thuoc"].ToString();
                    txtTinhTrangBN.Text = dr["ChuyenVien_TinhTrangBN"].ToString();
                    txtLyDo.Text = dr["ChuyenVien_LyDoChuyen"].ToString();
                    txtPhuongTien.Text = dr["CHuyenVien_PhuongTien"].ToString();
                    cmbBS.SelectedIndex = cmbBS.FindStringExact(dr["MABS"].ToString(), 0, 0);
                    cmbDSBenhVien.SelectedIndex = cmbDSBenhVien.FindStringExact(dr["ChuyenVien_ChuyenDenBV"].ToString(), 0, 1);
                    chXacNhanRV.Checked = true;
                    txtTenICD_KhoaDieuTri_BC.Text = dr["TenBC"].ToString();
                    txtTenICD_KhoaDieuTri_BP.Text = dr["TenBP"].ToString();
                    txtMaICD_BenhChinh.Text = dr["MaBC"].ToString();
                    txtMaICD_BenhPhu.Text = dr["MABP"].ToString();
                    txtMaICD_BenhPhu_1.Text = dr["MABP_1"].ToString();
                    txtTenICD_KhoaDieuTri_BP_1.Text = dr["TenBP_1"].ToString();
                    SoTheBHYT = dr["MaDTBHYT"].ToString() + " - " + dr["SoTheBHYT"].ToString() + " - " + dr["MaNoiCapBHYT"].ToString();
                    txtDiaChi.Text = dr["DiaChi"].ToString();
                }
                dr.Close();
                SQLCmd.Dispose();
            //}
        }
        private void rdChuaRV_CheckedChanged(object sender, EventArgs e)
        {
            if (rdChuaRV.Checked)
            {
                txtDKNgayRV.Visible = false;
                txtNgayRaVien.Enabled = true;
                cmbKQDT.Enabled = cmbNoiRaVien.Enabled = true;
            }
            else
            {
                txtDKNgayRV.Visible = true;
                txtNgayRaVien.Enabled = false;
                cmbKQDT.Enabled = cmbNoiRaVien.Enabled = false;
            }
            Load_DSBenhNhan();
            //Clear_Data();
        }

        private void cmdThoat_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void cmbBrowseBC_Click(object sender, EventArgs e)
        {
            //NamDinh_QLBN.Forms.DanhMuc.frmShowICD10 fr = new NamDinh_QLBN.Forms.DanhMuc.frmShowICD10(txtTenBC.Text, txtTenBC);
            //fr.ShowDialog();
            //if (fr.TextReturn != "") { txtMaBC.Text = txtTenBC.Tag.ToString(); }
        }

        private void cmbBrowseBP_Click(object sender, EventArgs e)
        {
            //NamDinh_QLBN.Forms.DanhMuc.frmShowICD10 fr = new NamDinh_QLBN.Forms.DanhMuc.frmShowICD10(txtTenBP.Text, txtTenBP);
            //fr.ShowDialog();
            //if (fr.TextReturn != "") { txtMaBP.Text = txtTenBP.Tag.ToString(); }
        }

        private void cmdGhi_Click(object sender, EventArgs e)
        {
            if (txtNgayRaVien.ValueIsDbNull)
            {
                MessageBox.Show("Chọn ngày ra viện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNgayRaVien.Focus();
                return;
            }
            if(fgDanhSach[fgDanhSach.Row, "tuyen"].ToString() == "1" && fgDanhSach.GetDataDisplay(fgDanhSach.Row, 5)== "Bảo hiểm y tế")
            {
                MessageBox.Show("CHUYỂN TUYẾN CỦA BỆNH NHÂN CHƯA ĐÚNG \nĐỀ NGHỊ CHUYỂN TUYẾN CHO BỆNH NHÂN", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            if (fgDanhSach.GetDataDisplay(fgDanhSach.Row, "SotheBHYT").Length >= 9)
            {
                    if (DateTime.Parse(txtNgayRaVien.Value.ToString()).Year - int.Parse(lblTuoi.Text.Trim()) <= 16)
                    {
                        if ((txtBo.Text == "" || txtIDBo.Text == "") && (txtMe.Text == "" || txtIDMe.Text == ""))
                        {
                            MessageBox.Show("Nhập họ tên và mã BHXH của Bố hoặc họ tên và mã BHXH  của mẹ cho trẻ em dưới 16 tuổi", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //return;
                        }
                    }
            }

            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd1 = new System.Data.SqlClient.SqlCommand();
            SQLCmd1.Connection = GlobalModuls.Global.ConnectSQL;
            System.Data.SqlClient.SqlDataReader dr1;
            string s = txtMaICD_BenhChinh.Text;
            string benhphu = txtMaICD_BenhPhu.Text;
            string benhphu1 = "";
            TimeSpan Time = new TimeSpan();
            Time = DateTime.Parse(txtNgayRaVien.Value.ToString()) - DateTime.Parse(lblNgayVaoVien.Text.ToString());
            if (txtChanDoanRaVien.Text != "")
            {
                string s1 = txtChanDoanRaVien.Text;
                if ((s1.IndexOf("1/2") == -1)&& (s1.IndexOf("1/3") == -1)&& (s1.IndexOf("1/4") == -1) && (s1.IndexOf("b/c") == -1))
                {
                    if (txtMaICD_BenhPhu_1.Text == "")
                    {
                        if(s1.IndexOf("/") != -1)
                        {
                            MessageBox.Show("Mã ICD bệnh phụ để trống, bạn rà soát lại.Bạn có thể nhập 1 hoặc nhiều mã ICD phụ", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            return;
                        }
                        if (s1.IndexOf("|") != -1)
                        {
                            MessageBox.Show("Mã ICD bệnh phụ để trống, bạn rà soát lại.Bạn có thể nhập 1 hoặc nhiều mã ICD phụ", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            return;
                        }
                        if (s1.IndexOf("&") != -1)
                        {
                            MessageBox.Show("Mã ICD bệnh phụ để trống, bạn rà soát lại.Bạn có thể nhập 1 hoặc nhiều mã ICD phụ", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            return;
                        }
                        if (s1.IndexOf(";") != -1)
                        {
                            MessageBox.Show("Mã ICD bệnh phụ để trống, bạn rà soát lại.Bạn có thể nhập 1 hoặc nhiều mã ICD phụ", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            return;
                        }
                        if (s1.IndexOf("_") != -1)
                        {
                            MessageBox.Show("Mã ICD bệnh phụ để trống, bạn rà soát lại.Bạn có thể nhập 1 hoặc nhiều mã ICD phụ", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            return;
                        }
                        if (s1.IndexOf("-") != -1)
                        {
                            MessageBox.Show("Mã ICD bệnh phụ để trống, bạn rà soát lại.Bạn có thể nhập 1 hoặc nhiều mã ICD phụ", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            return;
                        }
                        if (s1.IndexOf("+") != -1)
                        {
                            MessageBox.Show("Mã ICD bệnh phụ để trống, bạn rà soát lại.Bạn có thể nhập 1 hoặc nhiều mã ICD phụ", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            return;
                        }
                    }
                }
                /*ghép mã bệnh---------------------------------------------------------*/
                if (!String.IsNullOrEmpty(txtMaICD_BenhPhu_1.Text))
                {
                    string[] s2 = txtMaICD_BenhPhu_1.Text.Split(';');
                    string Catchuoi = "";
                    for (int i = 0; i <= s2.Length - 1; i++)
                    {
                        for (int j = i + 1; j <= s2.Length - 1; j++)
                        {
                            if (s2[i].Contains(s2[j]) == true)
                            {
                                s2[j] = "";
                            }
                        }
                    }
                    for (int k = 0; k <= s2.Length - 1; k++)
                    {
                        if (s2[k] != "" && txtMaICD_BenhChinh.Text != s2[k])
                        {
                            Catchuoi += s2[k] + ";";
                        }
                    }
                    if(!String.IsNullOrEmpty(Catchuoi))
                    {
                        txtMaICD_BenhPhu_1.Text = "";
                        txtMaICD_BenhPhu_1.Text = Catchuoi.Substring(0, Catchuoi.Length - 1);
                    }
                    else
                    {
                        txtMaICD_BenhPhu_1.Text = "";
                    }
                }
                /*------------------------------------------------------------------------------------*/
                if (txtMaICD_BenhChinh.Text.Trim() != "")
                {
                    string icdKiemTra = "";
                    if (txtMaICD_BenhPhu_1.Text == "")
                    {
                        icdKiemTra = "'" +  txtMaICD_BenhChinh.Text + "'";
                    }
                    else
                    {
                        icdKiemTra = "'" + txtMaICD_BenhChinh.Text + "','" + txtMaICD_BenhPhu_1.Text.Replace(";", "','") + "'";
                    }
                        if(lblGioi.Text == "Nữ")
                        {
                            SQLCmd.CommandText = String.Format("select ICD10 from NAMDINH_QLBN.dbo.tblICD_DichVu where ICD10 in ({0})", icdKiemTra) + " and MaDichVu = 'KT1001'";
                            dr = SQLCmd.ExecuteReader();
                            while(dr.Read())
                            {
                               MessageBox.Show(String.Format("Mã bệnh {0} Không phù hợp với giới tính nữ", dr["ICD10"].ToString()));
                            }
                            dr.Close();
                        }
                        if(lblGioi.Text == "Nam")
                        {
                            SQLCmd.CommandText = String.Format("select ICD10 from NAMDINH_QLBN.dbo.tblICD_DichVu where ICD10 in ({0})", icdKiemTra) + " and MaDichVu = 'KT1019'";
                            dr = SQLCmd.ExecuteReader();
                            while (dr.Read())
                            {
                                MessageBox.Show(String.Format("Mã bệnh {0} Không phù hợp với giới tính Nam", dr["ICD10"].ToString()));
                            }
                            dr.Close();
                        }
                        if(Int16.Parse(fgDanhSach.GetDataDisplay(fgDanhSach.Row,"tuoi1").ToString()) <= 15)
                        {
                            SQLCmd.CommandText = String.Format("select ICD10 from NAMDINH_QLBN.dbo.tblICD_DichVu where ICD10 in ({0})", icdKiemTra) + " and MaDichVu = 'KT1004'";
                            dr = SQLCmd.ExecuteReader();
                            while (dr.Read())
                            {
                                MessageBox.Show(String.Format("Mã bệnh {0} Không phù hợp với độ tuổi trên 15", dr["ICD10"].ToString()));
                            }
                            dr.Close();
                        }
                        if (Int16.Parse(fgDanhSach.GetDataDisplay(fgDanhSach.Row, "tuoi1").ToString()) <= 30)
                        {
                            SQLCmd.CommandText = String.Format("select ICD10 from NAMDINH_QLBN.dbo.tblICD_DichVu where ICD10 in ({0})", icdKiemTra) + " and MaDichVu = 'KT1007'";
                            dr = SQLCmd.ExecuteReader();
                            while (dr.Read())
                            {
                                MessageBox.Show(String.Format("Mã bệnh {0} Không phù hợp với độ tuổi trên 30", dr["ICD10"].ToString()));
                            }
                            dr.Close();
                        }
                        if (Int16.Parse(fgDanhSach.GetDataDisplay(fgDanhSach.Row, "tuoi1").ToString()) <= 8 || Int16.Parse(fgDanhSach.GetDataDisplay(fgDanhSach.Row, "tuoi1").ToString()) >= 19)
                        {
                            SQLCmd.CommandText = String.Format("select ICD10 from NAMDINH_QLBN.dbo.tblICD_DichVu where ICD10 in ({0})", icdKiemTra) + " and MaDichVu = 'KT1010'";
                            dr = SQLCmd.ExecuteReader();
                            while (dr.Read())
                            {
                                 MessageBox.Show(String.Format("Mã bệnh {0} Không phù hợp với độ tuổi từ 8 đến 19", dr["ICD10"].ToString()));
                            }
                            dr.Close();
                        }
                        if (Int16.Parse(fgDanhSach.GetDataDisplay(fgDanhSach.Row, "tuoi1").ToString()) <= 9 || Int16.Parse(fgDanhSach.GetDataDisplay(fgDanhSach.Row, "tuoi1").ToString()) >= 60)
                        {
                            SQLCmd.CommandText = String.Format("select ICD10 from NAMDINH_QLBN.dbo.tblICD_DichVu where ICD10 in ({0})", icdKiemTra) + " and MaDichVu = 'KT1013'";
                            dr = SQLCmd.ExecuteReader();
                            while (dr.Read())
                            {
                                MessageBox.Show(String.Format("Mã bệnh {0} Không phù hợp với độ tuổi từ 9 đến 60", dr["ICD10"].ToString()));
                            }
                            dr.Close();
                        }
                    SQLCmd.Dispose();
                    SQLCmd.CommandText = String.Format("SELECT * FROM NAMDINH_SYSDB.dbo.DMICD10 WHERE CICD10 = '{0}' ", txtMaICD_BenhChinh.Text.Trim());
                    dr = SQLCmd.ExecuteReader();
                    if (!dr.HasRows)
                    {
                        MessageBox.Show("Chú ý: Mã bệnh chính ICD 10  chưa đúng.\n Đề nghị kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dr.Close();
                        return;
                    }
                    dr.Close();
                    int count = 0;
                    SQLCmd.CommandText = String.Format("SELECT * FROM NAMDINH_SYSDB.dbo.DMICD10 WHERE CICD10 like N'%{0}%' ", txtMaICD_BenhChinh.Text.Trim());
                    dr = SQLCmd.ExecuteReader();
                    while(dr.Read())
                    {
                        count++;
                    }
                    if(count>1)
                    {
                        MessageBox.Show("Chú ý: Nhập mã bệnh chi tiết.\n Đề nghị kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dr.Close();
                        return;
                    }
                    dr.Close();
                }
            }

            if (rdChuaRV.Checked)
            {
                //bool Ngaygiuong = NgayGiuong();
                //if(Ngaygiuong == false)
                //{
                //    return;
                //}
                bool XetNguyem = XetNghiemTienPhau();
                if (XetNguyem == true)
                {
                    SQLCmd.CommandText = String.Format("select * from namdinh_QLBN.DBO.BENHNHAN_PHAUTHUAT where MaVaoVien = '{0}'", lblMaVaoVien.Text);
                    dr = SQLCmd.ExecuteReader();
                    if((dr.HasRows) == false)
                    {
                        MessageBox.Show("Bạn đã chỉ định bộ xét nghiệm tiền phẫu nhưng không phẫu thuật, có thể BHYT sẽ xuất toán các xét nghiệm đó. Bạn hãy ghi cụ thể vào bệnh án lý do tại sao không phẫu thuật", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dr.Close();
                    }
                    dr.Close();

                }

                if (chXacNhanRV.Checked == false)
                {
                    MessageBox.Show("Chọn xác nhận ra viện.", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (txtCachDieuTri.Text.Trim() == "")
                {
                    MessageBox.Show(String.Format("Cách điều trị Không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information));
                    txtDiaChi.Focus();
                    return;
                }

                if ((GetSession()))
                {
                    SQLCmd.CommandText = String.Format("set dateformat dmy  SELECT DT.maDoiTuongBHXH+ DT.SoThe AS BHYT, a.HoTen, a.NamSinh,CASE a.GioiTinh WHEN  0 THEN 2 ELSE 1 END AS GT,dt.MaNoiCap,KB.THOIGIANDANGKY "
                     + " FROM (BENHNHAN A INNER JOIN BENHNHAN_CHITIET B ON A.MABENHNHAN = B.MABENHNHAN) "
                     + " INNER JOIN BENHNHAN_DOITUONG DT ON dt.MaVaoVien = b.MaVaoVien and DT.DoiTuong = 1 "
                     + " INNER JOIN NAMDINH_KHAMBENH.DBO.TBLKHAMBENH KB ON KB.MAKHAMBENH = B.MAKHAMBENH "
                     + " where B.MaVaoVien = '{0}'", lblMaVaoVien.Text);
                    dr = SQLCmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            string ngayra = string.Format("{0:dd/MM/yyyy}", txtNgayRaVien.Value);
                            string ngayvao = string.Format("{0:dd/MM/yyyy}", DateTime.Parse(dr["THOIGIANDANGKY"].ToString()));
                            ThoigianDK = string.Format("{0:dd/MM/yyyy}", DateTime.Parse(dr["THOIGIANDANGKY"].ToString())); 
                            CheckTheBHYT(dr["BHYT"].ToString(), dr["HoTen"].ToString(), dr["NamSinh"].ToString(), dr["GT"].ToString(), dr["MaNoiCap"].ToString(), ngayra, ngayvao);
                        }
                    }
                    
                    dr.Close();
                }
                SQLCmd1.CommandText = string.Format("set dateformat dmy select a.MavaoVien,b.NgayChuyen, convert(numeric(18,2),sum(d.soluong)) as TongSoNgayGiuong  from Benhnhan_chitiet a inner join benhnhan_khoa b on a.mavaovien = b.mavaovien "
                    + " inner join Benhnhan_phieudieutri c on c.MaVaoVien = a.MaVaoVien "
                    + " inner join Phieudieutri_chitiet d on d.sophieu = c.SoPhieu "
                    + " where d.loaidichvu = 'B01' and d.MaDichVu not in ('B01042','B01043')  and a.mavaovien = '{0}' and b.lanchuyenkhoa = 0"
                    + " group by a.MavaoVien,b.NgayChuyen", lblMaVaoVien.Text);
                dr1 = SQLCmd1.ExecuteReader();
                if((cmbKhoa.Text == "Đơn nguyên Thận nhân tạo" || cmbKhoa.Text == "Khoa Phục hồi chức năng"))
                {

                }
                else
                {
                    if (dr1.HasRows == false && Time.TotalMinutes >= 241)
                    {
                        MessageBox.Show("Bệnh nhân điều trị > 4 giờ Phải có ngày giường bệnh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dr1.Close();
                        return;
                    }
                }
                
                while (dr1.Read())
                {
                    NgayVaoVien = DateTime.Parse(dr1["NgayChuyen"].ToString());
                    NgayRaVien = DateTime.Parse(txtNgayRaVien.Value.ToString());
                    SoLuongNgayDT = double.Parse(dr1["TongSoNgayGiuong"].ToString());
                    DateTime NgayVaoVien_12 = DateTime.Parse(NgayVaoVien.ToString("dd/MM/yyyy 11:59"));
                    DateTime NgayRaVien_12 = DateTime.Parse(NgayRaVien.ToString("dd/MM/yyyy 11:59"));
                    TimeSpan span2 = NgayRaVien - NgayVaoVien;
                    TimeSpan span3 = NgayRaVien_12 - NgayVaoVien_12;
                    if (cmbKhoa.Text != "Đơn nguyên Thận nhân tạo" || cmbKhoa.Text != "Khoa Phục hồi chức năng")
                    {
                        //if (lblDoiTuong.Text == "Viện phí")
                        //{
                        //    if (NgayVaoVien < DateTime.Parse("14/07/2018 23:59:59"))
                        //    {
                        //        if (span2.Hours <= 4 && span2.Days == 0 && span2.Minutes <= 00 && SoLuongNgayDT > 0)
                        //        {
                        //            MessageBox.Show("Bạn tính số ngày giường không chính xác. Bệnh nhân điều trị nội trú ≤ 4 giờ thì không tính tiền giường", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //            txtNgayRaVien.Focus();
                        //            dr1.Close();
                        //            return;
                        //        }
                        //        if (span2.Hours >= 4 && span2.Days == 0 && span2.Hours <= 24 && span2.Minutes > 00 && SoLuongNgayDT != 1)
                        //        {
                        //            MessageBox.Show("Bạn tính số ngày giường không chính xác. Bệnh nhân điều trị nội trú trên 4 giờ đến dưới 24 giờ thì số ngày giường = 01", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //            txtNgayRaVien.Focus();
                        //            dr1.Close();
                        //            return;
                        //        }
                        //        if (span2.Days >= 1 && SoLuongNgayDT != span3.Days + 1)
                        //        {
                        //            MessageBox.Show(String.Format("Bạn tính số ngày giường chưa chính xác. Tổng số ngày giường là ngày ra - ngày vào + 1 (Số Lượng {0})", span3.Days + 1), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //            txtNgayRaVien.Focus();
                        //            dr1.Close();
                        //            return;
                        //        }
                        //    }
                        //}
                        //else
                        //{
                            if (span2.Days == 0 && span2.Hours <= 23)
                            {
                                if (span2.Hours <= 3 && span2.Minutes <=59 && SoLuongNgayDT !=0)
                                {
                                    MessageBox.Show("Bạn tính số ngày giường không chính xác. Bệnh nhân điều trị nội trú ≤ 4 giờ thì không tính tiền giường", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    txtNgayRaVien.Focus();
                                    dr1.Close();
                                    return;
                                }
                                if (span2.Hours == 4 && span2.Minutes == 00 && SoLuongNgayDT != 0)
                                {
                                    MessageBox.Show("Bạn tính số ngày giường không chính xác. Bệnh nhân điều trị nội trú ≤ 4 giờ thì không tính tiền giường", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    txtNgayRaVien.Focus();
                                    dr1.Close();
                                    return;
                                }
                                if (span2.Hours >= 4 && SoLuongNgayDT != 1)
                                {
                                    MessageBox.Show("Bạn tính số ngày giường không chính xác. Bệnh nhân điều trị nội trú trên 4 giờ đến dưới 24 giờ thì số ngày giường = 01", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    txtNgayRaVien.Focus();
                                    dr1.Close();
                                    return;
                                }
                            }
                            else
                            {
                                if ((cmbNoiRaVien.Text == "Chuyển viện" || cmbNoiRaVien.Text == "Tử vong" || cmbKQDT.Text == "Nặng hơn" || cmbKQDT.Text == "Tử vong trong vòng 24h đầu nhập viện" || cmbKQDT.Text == "Tử vong sau 24h đầu nhập viện" || cmbKQDT.Text == "Bệnh nhân nặng xin về"))
                                {
                                    if (SoLuongNgayDT != span3.Days + 1)
                                    {
                                        MessageBox.Show(String.Format("Bạn tính Tổng số ngày giường không chính xác. Bệnh nhân nặng hơn xin về hoặc tử vong hoặc chuyển viện, Tổng số ngày giường là {0}", span3.Days + 1), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        txtNgayRaVien.Focus();
                                        dr1.Close();
                                        return;
                                    }
                                }
                                else
                                {
                                    if (SoLuongNgayDT != span3.Days)
                                    {
                                        MessageBox.Show(String.Format("Bạn tính Tổng số ngày giường không chính xác. Bệnh nhân đỡ hoặc khỏi ra viện,  Tổng số ngày giường là {0}", span3.Days), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        txtNgayRaVien.Focus();
                                        dr1.Close();
                                        return;
                                    }
                                }

                            //}
                        }
                    }
                }
                dr1.Close();
                if (cmbKQDT.SelectedIndex == -1)
                {
                    MessageBox.Show("Chọn kết quả điều trị.", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbKQDT.Focus();
                    return;
                }
                if (cmbNoiRaVien.SelectedIndex == -1)
                {
                    MessageBox.Show("Chọn nơi ra viện.", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbNoiRaVien.Focus();
                    return;
                }
                if (Global.GetCode(cmbNoiRaVien).ToString() == "5")
                {
                    if ((Global.GetCode(cmbKQDT).ToString() == "5") || (Global.GetCode(cmbKQDT).ToString() == "6"))
                    {

                    }
                    else
                    {
                        MessageBox.Show("Nhập sai nơi ra viện hoặc kết quả điều trị", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtNgayRaVien.Focus();
                        return;
                    }
                }
                if ((Global.GetCode(cmbKQDT).ToString() == "5") || (Global.GetCode(cmbKQDT).ToString() == "6"))
                {
                    if (Global.GetCode(cmbNoiRaVien).ToString() != "5")
                    {
                        MessageBox.Show("Nhập sai nơi ra viện hoặc kết quả điều trị", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtNgayRaVien.Focus();
                        return;
                    }
                }
                if (txtTenICD_KhoaDieuTri_BC.Text.Trim() == "")
                {
                    MessageBox.Show("Nhập chẩn đoán ICD bệnh chính!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMaICD_BenhChinh.Text = "";
                    txtMaICD_BenhChinh.Focus();
                    return;
                }
                if (Global.GetCode(cmbNoiRaVien).ToString() == "4")
                {
                    if (cmbDSBenhVien.SelectedIndex == -1)
                    {
                        MessageBox.Show("Chọn BV chuyển đến", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cmbDSBenhVien.Focus();
                        return;
                    }
                    if (cmbBS.SelectedIndex == -1)
                    {
                        MessageBox.Show("Chọn BS chỉ định", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cmbBS.Focus();
                        return;
                    }
                }
                if (txtDiaChi.Text.Trim() == "")
                {
                    MessageBox.Show(String.Format("Địa chỉ Không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information));
                    txtDiaChi.Focus();
                    return;
                }
                if (txtMaICD_BenhPhu_1.Text.Length > 1)
                {
                    if (txtMaICD_BenhPhu_1.Text.Substring(txtMaICD_BenhPhu_1.Text.Length - 1) == ";")
                    {
                        benhphu1 = txtMaICD_BenhPhu_1.Text.Substring(0, txtMaICD_BenhPhu_1.Text.Length - 1);
                    }
                    else
                    {
                        benhphu1 = txtMaICD_BenhPhu_1.Text;
                    }
                }
                else benhphu1 = "";
                SQLCmd.CommandText = String.Format("set dateformat dmy SELECT DISTINCT A.sophieu FROM BENHNHAN_PHIEUDIEUTRI A "
                                              + " INNER JOIN PHIEUDIEUTRI_CHITIET B ON A.SoPhieu = B.SoPhieu "
                                              + " WHERE MAVAOVIEN ='{0}' AND B.SOLUONG != 0 AND NGAYCHIDINH  >= '{1:dd/MM/yyyy HH:mm:ss}'", lblMaVaoVien.Text, txtNgayRaVien.Value);
                dr = SQLCmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MessageBox.Show("Chú ý: Có phiếu chỉ định sau thời gian ra viện.\n Đề nghị kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dr.Close();
                    return;
                    //toan sua
                }
                dr.Close();

                
                if (DateTime.Compare((DateTime)DateTime.Parse(lblNgayVaoVien.Text), (DateTime)txtNgayRaVien.Value) > 0)
                {
                    MessageBox.Show("Chú ý: Thời gian ra viện phải sau thời gian vào viện.\n Đề nghị kiểm tra lại!", "Thông báo!");
                    txtNgayRaVien.Focus();
                    return;
                }

                string benhphu2 = benhphu1.Replace(";", "','");
                SQLCmd.CommandText = string.Format("select isNull(dv.MaDichVu,'ABCD') as MaDichVu,dv.ICD10,dv.LoaiPT,dmdv.TenDichvu  from (select DISTINCT c.MaDichVu from NAMDINH_QLBN.DBO.BENHNHAN_PHIEUDIEUTRI A INNER JOIN NAMDINH_QLBN.DBO.PHIEUDIEUTRI_CHITIET B ON A.SOPHIEU = B.SOPHIEU  and a.MaVaoVien = N'{0}' Inner JOIN NAMDINH_QLBN.dbo.tblICD_DichVu c on c.MaDichVu = b.MaDichVu  and b.SoLuong != 0 and b.TinhPhi = 0 inner join namdinh_sysdb.dbo.dmdichvu dm on dm.madichvu = c.MaDichVu) X left join tblICD_DichVu  dv on dv.MaDichVu = x.MaDichVu and dv.ICD10 in ('{1}','{2}','{3}') left join NAMDINH_SYSDB.dbo.DMDICHVU dmdv on  dmdv.MaDichvu= x.MaDichVu ", lblMaVaoVien.Text, s, benhphu, benhphu2);
                string tendichvu1 = "";
                dr = SQLCmd.ExecuteReader();
                while (dr.Read())
                {
                    if (dr["MaDichVu"].ToString() == "ABCD")
                    {
                        tendichvu1 = dr["tendichvu"].ToString();
                        MessageBox.Show(String.Format("Mã bệnh Không phù hợp với dịch vụ {0})", tendichvu1), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                dr.Close();
                SQLCmd.CommandText = string.Format("select a.MaVaoVien,b.MaDichVu from BENHNHAN_PHIEUDIEUTRI a Inner join PHIEUDIEUTRI_CHITIET b on a.SoPhieu = b.SoPhieu and MaVaoVien = '{0}' and MaDichVu = 'C51086'", lblMaVaoVien.Text);
                dr = SQLCmd.ExecuteReader();
                string mavaovien = "";
                while (dr.Read())
                {
                    if (dr.HasRows == true)
                    {
                        mavaovien = dr["MaVaoVien"].ToString();
                    }
                }
                dr.Close();
                if (mavaovien != "")
                {
                    SQLCmd.CommandText = string.Format("select a.mavaovien from BENHNHAN_PHIEUDIEUTRI a Inner join PHIEUDIEUTRI_CHITIET b on a.SoPhieu = b.SoPhieu inner join NAMDINH_SYSDB.dbo.DMPHAUTHUAT pt on pt.MaDichVu = b.MaDichVu and pt.LaPhauThuat =1 and mavaovien =  '{0}'", mavaovien);
                    dr = SQLCmd.ExecuteReader();
                    if (dr.HasRows == false)
                    {
                        MessageBox.Show(String.Format("Dịch vụ 'Định lượng Fibrinogen phương pháp trực tiếp, bằng máy tự động' áp dụng cho các trường hợp có phẫu thuật)"), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dr.Close();
                    }
                    dr.Close();
                }
            }

            else
            {
                
                if (txtMaICD_BenhPhu_1.Text.Length > 1)
                {
                    if (txtMaICD_BenhPhu_1.Text.Substring(txtMaICD_BenhPhu_1.Text.Length - 1) == ";")
                    {
                        benhphu1 = txtMaICD_BenhPhu_1.Text.Substring(0, txtMaICD_BenhPhu_1.Text.Length - 1);
                    }
                    else
                    {
                        benhphu1 = txtMaICD_BenhPhu_1.Text;
                    }

                }
                else benhphu1 = "";
                if (chXacNhanRV.Checked == false)
                {
                    SQLCmd.CommandText = String.Format("DECLARE @MABENHNHAN NVARCHAR(20)"
                        + " SELECT @MABENHNHAN = A.MABENHNHAN FROM "
                        + " (BENHNHAN A INNER JOIN BENHNHAN_CHITIET B ON A.MABENHNHAN = B.MABENHNHAN)"
                        + " WHERE MAVAOVIEN ='{0}'"
                        + " SELECT BENHNHAN_CHITIET.MAVAOVIEN,BENHNHAN_CHITIET.DARAVIEN FROM BENHNHAN_CHITIET "
                        + " INNER JOIN VIEWKHOAHIENTAI ON VIEWKHOAHIENTAI.MAVAOVIEN = BENHNHAN_CHITIET.MAVAOVIEN"
                        + " INNER JOIN DMKHOAPHONG ON DMKHOAPHONG.MAKHOA = VIEWKHOAHIENTAI.MAKHOA"
                        + " WHERE BENHNHAN_CHITIET.MABENHNHAN = @MABENHNHAN AND "
                        + " BENHNHAN_CHITIET.MAVAOVIEN != '{0}' AND BENHNHAN_CHITIET.DARAVIEN = 0 AND DMKHOAPHONG.is_NoitruNgoaitru != 1", lblMaVaoVien.Text);
                    dr = SQLCmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        MessageBox.Show("Bệnh nhân này đang được điều trị", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dr.Close();
                        return;
                    }
                    dr.Close();

                    SQLCmd.CommandText = String.Format("SELECT * FROM BENHNHAN_CHITIET WHERE MAVAOVIEN ='{0}' AND DATINHPHI = 1", lblMaVaoVien.Text);
                    dr = SQLCmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        MessageBox.Show("Bệnh nhân này đã được thanh toán.\n Không được điều trị tiếp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dr.Close();
                        return;
                    }
                    dr.Close();

                    if (MessageBox.Show("Bạn có muốn tiếp nhận lại bệnh nhân hay không.", "Thông báo.", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                    {
                        return;
                    }
                    //Clear_Data();
                    //txtNgayRaVien.Text = "";
                }

            }
            if (this.rdDuDK.Checked) txtLyDo.Text = this.rdDuDK.Text;
            else txtLyDo.Text = this.rdChuyenTheoYC.Text;
            if(cmbNoiRaVien.Text == "Chuyển viện")
            {
                if(lblHosoCV.Text == "")
                {
                    SQLCmd.CommandText = string.Format("DECLARE @MaxSOHOSOCHUYENVIEN nvarchar(5) DECLARE @Nam Nvarchar(4) "
                                    + "BEGIN SELECT @MaxSOHOSOCHUYENVIEN = SOHOSOCHUYENVIEN, @Nam = Nam FROM  SOHOSOCHUYENVIEN IF @Nam <> SUBSTRING(CAST(YEAR(GETDATE()) as nvarchar(5)), 3, 2) + 'NT' BEGIN UPDATE  SOHOSOCHUYENVIEN SET  SOHOSOCHUYENVIEN = '00000', NAM = SUBSTRING(CAST(YEAR(GETDATE()) as nvarchar(5)), 3, 2) + 'NT' SET @MaxSOHOSOCHUYENVIEN = '00000' END DECLARE @Ma int SET @Ma = Cast(@MaxSOHOSOCHUYENVIEN  As Int) + 1 SET @MaxSOHOSOCHUYENVIEN = Cast(@Ma as nvarChar(5)) WHILE Len(@MaxSOHOSOCHUYENVIEN) < 5 BEGIN SET @MaxSOHOSOCHUYENVIEN = '0' + @MaxSOHOSOCHUYENVIEN END UPDATE  SOHOSOCHUYENVIEN SET  SOHOSOCHUYENVIEN = @MAXSOHOSOCHUYENVIEN END select NAM + SOHOSOCHUYENVIEN from SOHOSOCHUYENVIEN ");
                    lblHosoCV.Text = SQLCmd.ExecuteScalar().ToString();

                }
                else
                {
                    lblHosoCV.Text = fgDanhSach.GetDataDisplay(fgDanhSach.Row, "SOHOSOCHUYENVIEN");
                }
            }
            else
            {
                lblHosoCV.Text = "";
            }
            //string mabenhvien = "";
            //if (Convert.ToString(Global.GetCode(cmbDSBenhVien)) == null)
            //{
            //    mabenhvien = "NULL";
            //}
            //else
            //{
            //    mabenhvien = Global.GetCode(cmbDSBenhVien);
            //}
            SQLCmd.CommandText = string.Format("set dateformat dmy UPDATE BENHNHAN_CHITIET SET " + (chXacNhanRV.Checked == true ? string.Format(" NgayRaVien='{0:dd/MM/yyyy HH:mm}',", txtNgayRaVien.Value) : "NgayRaVien = null,") + (txtNgayHenKhamLai.ValueIsDbNull == true ? "NgayHenKhamLai = null" : string.Format(" NgayHenKhamLai='{0:dd/MM/yyyy}'", txtNgayHenKhamLai.Value)) + ",CachDT=N'{1}',KetQuaDT={2},"
                    + " NoiRaVien={3},KhaNangLD={4},BenhChinh_RaVien={5},BenhPhu_RaVien={6},GhiChu=N'{7}',DaRaVien={8},LoiDan_RaVien=N'{9}',"
                    + " ChuyenVien_DauHieuLS=N'{10}',ChuyenVien_CacXN=N'{11}',ChuyenVien_ChanDoan=N'{12}',ChuyenVien_Thuoc=N'{13}',"
                    + " ChuyenVien_TinhTrangBN=N'{14}',ChuyenVien_LyDoChuyen=N'{15}',CHuyenVien_PhuongTien=N'{16}',CHuyenVien_NguoiChuyen=N'{17}',"
                    + " ChuyenVien_ChuyenDenBV=N'{18}',ChanDoanRaVien=N'{19}',MaBV='{20}',MaBS={21},DiaChi=N'{22}',HO_TEN_CHA = N'{23}',HO_TEN_ME = N'{24}', SOHOSOCHUYENVIEN = N'{25}',IDBo = {26},IDMe = {27} "
                    + " WHERE MaVaoVien='{0}'",
                    lblMaVaoVien.Text,
                    txtCachDieuTri.Text.Trim(),
                    (Global.GetCode(cmbKQDT) == null) ? ("Null") : (Global.GetCode(cmbKQDT)),
                    (Global.GetCode(cmbNoiRaVien) == null) ? ("Null") : (Global.GetCode(cmbNoiRaVien)),
                    (Global.GetCode(cmbKhaNangLD) == null) ? ("Null") : (Global.GetCode(cmbKhaNangLD)),
                    (txtTenBC.Text == "") ? ("Null") : ("N'" + txtTenBC.Text + "'"),
                    (txtTenBP.Text == "") ? ("Null") : ("N'" + txtTenBP.Text + "'"),
                    txtGhiChu.Text,
                    (chXacNhanRV.Checked) ? (1) : (0),
                    txtLoiDan.Text,
                    txtLamSang.Text.Trim(),
                    txtXetNghiem.Text.Trim(),
                    txtChanDoan.Text.Trim(),
                    txtThuoc.Text.Trim(),
                    txtTinhTrangBN.Text.Trim(),
                    txtLyDo.Text.Trim(),
                    txtPhuongTien.Text.Trim(),
                    txtNguoiChuyen.Text.Trim(),
                    cmbDSBenhVien.Text.Trim(),
                    txtChanDoanRaVien.Text.Trim(),
                    ( Global.GetCode(cmbDSBenhVien) == null) ? ("null") : (Global.GetCode(cmbDSBenhVien)),
                    (Global.GetCode(cmbBS) == null) ? ("null") : (Global.GetCode(cmbBS)),txtDiaChi.Text.Trim(),txtBo.Text.Trim(), txtMe.Text.Trim(),lblHosoCV.Text.Trim(),(txtIDBo.Text == "") ? ("Null"):txtIDBo.Text.Trim(),(txtIDMe.Text == "") ? ("Null"):txtIDMe.Text.Trim());
            //string ss = lblMaVaoVien.Text, txtMaICD_BenhPhu.Text.Trim();
            SQLCmd.CommandText += String.Format(" UPDATE BENHNHAN_KHOA SET MAICD_BC='{0}',MAICD_BP='{1}',MAICD_BP_1='{3}' WHERE MAVAOVIEN ='{2}' AND LANCHUYENKHOA ="
                + " (SELECT MAX(LANCHUYENKHOA) FROM BENHNHAN_KHOA WHERE BENHNHAN_KHOA.MAVAOVIEN='{2}')", txtMaICD_BenhChinh.Text.Trim(),
                txtMaICD_BenhPhu.Text.Trim(),
                lblMaVaoVien.Text,benhphu1);
            //txtMaICD_BenhPhu_1.Text.Trim());
            SQLCmd.CommandText += string.Format("if(exists(select * from BENHNHAN_KHOA_NGAYGIUONG_CT where MaVaoVien = '{0}' and MaKhoa = '{1}' ))"
                + " update BENHNHAN_KHOA_NGAYGIUONG_CT set  NgayChuyen = '{2:dd/MM/yyyy HH:mm}',TrangThaiBN = 2 where MaVaoVien = '{0}' and MaKhoa = '{1}' and ngaychuyen = (select MAX(ngaychuyen)  from NAMDINH_QLBN.DBO.BENHNHAN_KHOA_NGAYGIUONG_CT WHERE MaVaoVien = '{0}' and MaKhoa = '{1}')",
                   lblMaVaoVien.Text,Global.GetCode(cmbKhoa),txtNgayRaVien.Value);
            if(Global.GetCode(cmbKhoa)== "NV120101")
            {
                SQLCmd.CommandText += string.Format(" update Namdinh_qlbn.dbo.benhnhan_chitiet set ngaykham = B.NgayChuyen,NgayVaoVien = B.NgayChuyen from Namdinh_qlbn.dbo.benhnhan_chitiet a inner jOIN NAMDINH_QLBN.DBO.BENHNHAN_KHOA B ON A.MaVaoVien = B.MaVaoVien WHERE A.MaVaoVien = '{0}' and b.LanChuyenKhoa = (select Min(LanChuyenKhoa) from NAMDINH_QLBN.DBO.BENHNHAN_KHOA WHERE MaVaoVien = '{0}')", lblMaVaoVien.Text);
            }
            SQLCmd.CommandText += string.Format("if(exists(select MA_LK from tblXML5_NoiTru where MA_LK = '{0}'))"
                                          + " delete from tblXML5_NoiTru where MA_LK = '{0}'"
                                          + " insert into tblXML5_NoiTru select * from("
                                          + " select Mavaovien as Ma_LK, TomTat AS DienBien, N'Chủ Toạ: ' + ChuToa + ', ' + N'Thư ký: ' + ThuKy + ', ' + 'Thành viên: ' + ', ' + ThanhVienTG + ' ' + KetLuan + HuongDT as HoiChan, '' PhauThuat, replace(replace(replace(CONVERT(nchar(16), NgayHoiChan, 120), '-', ''), ' ', ''), ':', '') as NgayYLenh FROM NAMDINH_QLBN.DBO.BENHNHAN_HOICHAN WHERE MaVaoVien = '{0}'"
                                          + " union all"
                                          + " SELECT   MaVaoVien as Ma_LK, TrinhTuPT as DienBien, '' as HoiChan, PhuongPhapPT_Text as PhauThuat, replace(replace(replace(CONVERT(nchar(16), ThoiGianKT, 120), '-', ''), ' ', ''), ':', '') as NgayYLenh FROM NAMDINH_QLBN.dbo.BENHNHAN_PHAUTHUAT where MaVaoVien = '{0}'"
                                          + " union all"
                                          + " select  MaVaoVien as Ma_LK, DienBienBenh as DienBien, '' as HoiChan, '' as PhauThau, replace(replace(replace(CONVERT(nchar(16), NgayChiDinh, 120), '-', ''), ' ', ''), ':', '') as NgayYLenh  from NAMDINH_QLBN.dbo.BENHNHAN_PHIEUDIEUTRI where MaVaoVien = '{0}' and REPLACE(REPLACE(REPLACE(REPLACE(DienBienBenh, CHAR(10), ''), '.', ''), ' ', ''), CHAR(13), '') != '') A", lblMaVaoVien.Text);
            try
            {
                SQLCmd.ExecuteNonQuery();
                Load_DSBenhNhan();
                //Load_BenhNhan();
                txtMaICD_BenhPhu_1.Text = "";
                txtTenICD_KhoaDieuTri_BP_1.Text = "";
                MessageBox.Show("Đã cập nhật dữ liệu của bệnh nhân!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi ghi dữ liệu!\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SQLCmd.Dispose();
            }
        }
        private void txtNgayRaVien_TextChanged(object sender, EventArgs e)
        {
            //if (lblNgayVaoVien.Text == "" || txtNgayRaVien.ValueIsDbNull) return;
            //DateTime NgayRaVien = DateTime.Parse(txtNgayRaVien.Text);
            //DateTime NgayVaoVien = DateTime.Parse(lblNgayVaoVien.Text);
            //System.TimeSpan NgayDT = NgayRaVien - NgayVaoVien;
            //lblNgayDT.Text = string.Format("Số ngày điều trị: {0}", NgayDT.Days + 1);
        }

        private void txtNgayRaVien_ValueChanged(object sender, EventArgs e)
        {
            //if (lblNgayVaoVien.Text == "" || txtNgayRaVien.Text == "")
            //{
            //    lblNgayDT.Text = "Số ngày điều trị:";
            //    return;
            //}
            //DateTime NgayRaVien = DateTime.Parse(txtNgayRaVien.Text);
            //DateTime NgayVaoVien = DateTime.Parse(lblNgayVaoVien.Text);
            //System.TimeSpan NgayDT = NgayRaVien - NgayVaoVien;
            //lblNgayDT.Text = string.Format("Số ngày điều trị: {0}", NgayDT.Days + 1);

        }



        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if(lblMaVaoVien.Text == "")
            {
                MessageBox.Show("Chưa chọn bệnh nhân ra viện","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                return;
            }
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            SQLCmd.CommandText = string.Format("set dateformat dmy UPDATE BENHNHAN_CHITIET SET "
                   + " GhiChu=N'{1}',LoiDan_RaVien=N'{2}', DiaChi = N'{3}'"
                   + " WHERE MaVaoVien='{0}'",
                   lblMaVaoVien.Text,
                   txtGhiChu.Text,
                   txtLoiDan.Text,txtDiaChi.Text);

            SQLCmd.CommandText += string.Format("if(exists(select MA_LK from tblXML5_NoiTru where MA_LK = '{0}'))"
                                          + " delete from tblXML5_NoiTru where MA_LK = '{0}'"
                                          + " insert into tblXML5_NoiTru select * from("
                                          + " select Mavaovien as Ma_LK, TomTat AS DienBien, N'Chủ Toạ: ' + ChuToa + ', ' + N'Thư ký: ' + ThuKy + ', ' + 'Thành viên: ' + ', ' + ThanhVienTG + ' ' + KetLuan + HuongDT as HoiChan, '' PhauThuat, replace(replace(replace(CONVERT(nchar(16), NgayHoiChan, 120), '-', ''), ' ', ''), ':', '') as NgayYLenh FROM NAMDINH_QLBN.DBO.BENHNHAN_HOICHAN WHERE MaVaoVien = '{0}'"
                                          + " union all"
                                          + " SELECT   MaVaoVien as Ma_LK, ChanDoan_SauPT as DienBien, '' as HoiChan, PhuongPhapPT_Text as PhauThuat, replace(replace(replace(CONVERT(nchar(16), ThoiGianKT, 120), '-', ''), ' ', ''), ':', '') as NgayYLenh FROM NAMDINH_QLBN.dbo.BENHNHAN_PHAUTHUAT where MaVaoVien = '{0}'"
                                          + " union all"
                                          + " select  MaVaoVien as Ma_LK, DienBienBenh as DienBien, '' as HoiChan, '' as PhauThau, replace(replace(replace(CONVERT(nchar(16), NgayChiDinh, 120), '-', ''), ' ', ''), ':', '') as NgayYLenh  from NAMDINH_QLBN.dbo.BENHNHAN_PHIEUDIEUTRI where MaVaoVien = '{0}' and REPLACE(REPLACE(REPLACE(REPLACE(DienBienBenh, CHAR(10), ''), '.', ''), ' ', ''), CHAR(13), '') != '') A", lblMaVaoVien.Text);
            SQLCmd.ExecuteNonQuery();
            NamDinh_QLBN.Reports.rptGiayRaVien rpt = new NamDinh_QLBN.Reports.rptGiayRaVien(lblMaVaoVien.Text);
            rpt.Show();
        }



        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (cmbNoiRaVien.Text == "Chuyển viện")
            {
                if (lblDoiTuong.Text == "Bảo hiểm y tế")
                {
                    NamDinh_QLBN.Reports.repPhieuChuyenVien_BHYT rep = new NamDinh_QLBN.Reports.repPhieuChuyenVien_BHYT(lblMaVaoVien.Text,CmbTruongPho.Text,lblHosoCV.Text);
                    rep.Show();
                }
                else
                {
                    NamDinh_QLBN.Reports.repPhieuChuyenVien rep = new NamDinh_QLBN.Reports.repPhieuChuyenVien(lblMaVaoVien.Text);
                    rep.Show();
                }
            }
            else
            {
                MessageBox.Show("Chọn nơi ra viện không phù hợp", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           
        }

        private void EnabledChuyenVien(bool Flag)
        {
            txtLamSang.Enabled = txtXetNghiem.Enabled = txtChanDoan.Enabled = txtThuoc.Enabled = txtTinhTrangBN.Enabled =
                    txtLyDo.Enabled = txtPhuongTien.Enabled = cmbDSBenhVien.Enabled = cmbBS.Enabled = txtNguoiChuyen.Enabled = Flag;
        }
        private bool XetNghiemTienPhau()
        {
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            System.Data.SqlClient.SqlDataReader dr;
            SQLCmd.CommandText = string.Format("select * from benhnhan_phieudieutri a inner join phieudieutri_chitiet b on a.sophieu = b.sophieu where a.mavaovien = '{0}' and b.MaDichVu in('C51086','C51075','C51081','C51014','C51013')", lblMaVaoVien.Text);
            dr = SQLCmd.ExecuteReader();
            int rowCount = 0;
            //if (dr.HasRows)
            //{
                while (dr.Read())
                {
                    rowCount++;
                }
            dr.Close();
            if (rowCount == 5)
                {
                    return true;
                }
                else return false;
            //}
            
        }
        private string NgayGiuongPhauThuat()
        {
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            System.Data.SqlClient.SqlDataReader dr;
            string s = "";
            SQLCmd.CommandText = string.Format("select Top (1) case when LoaiPhauThuat = 3 then 31 else LoaiPhauThuat end as LoaiPhauThuat from namdinh_qlbn.dbo.BENHNHAN_PHIEUDIEUTRI  a inner join NAMDINH_QLBN.dbo.PHIEUDIEUTRI_CHITIET b on a.sophieu = b.sophieu"
            + " inner join NAMDINH_QLBN.dbo.BENHNHAN_CHITIET c on c.MaVaoVien = a.MaVaoVien"
            + " inner join NAMDINH_SYSDB.dbo.DMPHAUTHUAT d on d.MaDichVu = b.MaDichVu and LaPhauThuat = 1"
            + " inner join NAMDINH_SYSDB.dbo.DMDICHVU e on e.MaDichvu = d.MaDichVu and is_chenh = 0 "
            + " where c.MaVaoVien = '{0}'and LoaiphauThuat in ('11','21','3','4') order by LoaiPhauThuat ASC", lblMaVaoVien.Text);
            //s = SQLCmd.ExecuteScalar().ToString();
            //return s;
            dr = SQLCmd.ExecuteReader();
            while (dr.Read())
            {
                s = dr["LoaiPhauThuat"].ToString();
            }
            SQLCmd.Dispose();
            dr.Close();
            return s;

        }
        private bool NgayGiuong()
        {
            System.Data.SqlClient.SqlCommand SQLCmd1 = new System.Data.SqlClient.SqlCommand();
            SQLCmd1.Connection = GlobalModuls.Global.ConnectSQL;
            System.Data.SqlClient.SqlDataReader dr1;
            if (NgayGiuongPhauThuat() == "11")
            {
                SQLCmd1.CommandText = string.Format("select Right(MasoBYT,4) as MaGiuong,IsPhauThuat from namdinh_qlbn.dbo.BENHNHAN_PHIEUDIEUTRI  a inner join NAMDINH_QLBN.dbo.PHIEUDIEUTRI_CHITIET b on a.sophieu = b.sophieu inner join NAMDINH_QLBN.dbo.BENHNHAN_CHITIET c on c.MaVaoVien = a.MaVaoVien inner join NAMDINH_SYSDB.dbo.DMDICHVU d on d.MaDichVu = b.MaDichVu where c.MaVaoVien = '{0}'  and D.loaidichvu = 'B01'", lblMaVaoVien.Text);
                dr1 = SQLCmd1.ExecuteReader();
                if (dr1.HasRows)
                {
                    while (dr1.Read())
                    {
                        if (dr1["MaGiuong"].ToString() != "1931" && dr1["IsPhauThuat"].ToString() == "1")
                        {
                            MessageBox.Show("Bệnh nhân có phẫu Thuật loại 1\n\n\nBạn nhập loại giường bệnh không đúng");
                            dr1.Close();
                            return false;
                        }
                    }
                    dr1.Close();
                }
                else
                {
                    MessageBox.Show("Bệnh nhân chưa có ngày giường bệnh");
                    dr1.Close();
                    return false;
                }

            }
            if (NgayGiuongPhauThuat() == "21")
            {
                SQLCmd1.CommandText = string.Format("select Right(MasoBYT,4) as MaGiuong,IsPhauThuat from namdinh_qlbn.dbo.BENHNHAN_PHIEUDIEUTRI  a inner join NAMDINH_QLBN.dbo.PHIEUDIEUTRI_CHITIET b on a.sophieu = b.sophieu inner join NAMDINH_QLBN.dbo.BENHNHAN_CHITIET c on c.MaVaoVien = a.MaVaoVien inner join NAMDINH_SYSDB.dbo.DMDICHVU d on d.MaDichVu = b.MaDichVu where c.MaVaoVien = '{0}'  and D.loaidichvu = 'B01'", lblMaVaoVien.Text);
                dr1 = SQLCmd1.ExecuteReader();
                if (dr1.HasRows)
                {
                    while (dr1.Read())
                    {
                        if (dr1["MaGiuong"].ToString() != "1937" && dr1["IsPhauThuat"].ToString() == "1")
                        {
                            MessageBox.Show("Bệnh nhân có phẫu Thuật loại 2\n\n\nBạn nhập loại giường bệnh không đúng");
                            dr1.Close();
                            return false;
                        }
                    }
                    dr1.Close();
                }
                else
                {
                    MessageBox.Show("Bệnh nhân chưa có ngày giường bệnh");
                    dr1.Close();
                    return false;
                }
            }
            if (NgayGiuongPhauThuat() == "31")
            {
                SQLCmd1.CommandText = string.Format("select Right(MasoBYT,4) as MaGiuong,IsPhauThuat from namdinh_qlbn.dbo.BENHNHAN_PHIEUDIEUTRI  a inner join NAMDINH_QLBN.dbo.PHIEUDIEUTRI_CHITIET b on a.sophieu = b.sophieu inner join NAMDINH_QLBN.dbo.BENHNHAN_CHITIET c on c.MaVaoVien = a.MaVaoVien inner join NAMDINH_SYSDB.dbo.DMDICHVU d on d.MaDichVu = b.MaDichVu where c.MaVaoVien = '{0}'  and D.loaidichvu = 'B01'", lblMaVaoVien.Text);
                dr1 = SQLCmd1.ExecuteReader();
                if (dr1.HasRows)
                {
                    while (dr1.Read())
                    {
                        if (dr1["MaGiuong"].ToString() != "1943" && dr1["IsPhauThuat"].ToString() == "1")
                        {
                            MessageBox.Show("Bệnh nhân có phẫu Thuật loại 3\n\n\nBạn nhập loại giường bệnh không đúng");
                            dr1.Close();
                            return false;
                        }
                    }
                    dr1.Close();
                }
                else
                {
                    MessageBox.Show("Bệnh nhân chưa có ngày giường bệnh");
                    dr1.Close();
                    return false;
                }
            }
            if (NgayGiuongPhauThuat() == "4")
            {
                SQLCmd1.CommandText = string.Format("select Right(MasoBYT,4) as MaGiuong,IsPhauThuat from namdinh_qlbn.dbo.BENHNHAN_PHIEUDIEUTRI  a inner join NAMDINH_QLBN.dbo.PHIEUDIEUTRI_CHITIET b on a.sophieu = b.sophieu inner join NAMDINH_QLBN.dbo.BENHNHAN_CHITIET c on c.MaVaoVien = a.MaVaoVien inner join NAMDINH_SYSDB.dbo.DMDICHVU d on d.MaDichVu = b.MaDichVu where c.MaVaoVien = '{0}'  and D.loaidichvu = 'B01'", lblMaVaoVien.Text);
                dr1 = SQLCmd1.ExecuteReader();
                if (dr1.HasRows)
                {
                    while (dr1.Read())
                    {
                        if (dr1["MaGiuong"].ToString() != "1927" && dr1["IsPhauThuat"].ToString() == "1")
                        {
                            MessageBox.Show("Bệnh nhân có phẫu Thuật loại đặc biệt\n\n\nBạn nhập loại giường bệnh không đúng");
                            dr1.Close();
                            return false;
                        }
                    }
                    dr1.Close();
                }
                else
                {
                    MessageBox.Show("Bệnh nhân chưa có ngày giường bệnh");
                    dr1.Close();
                    return false;
                }
            }

            if (NgayGiuongPhauThuat() == "")
            {
                SQLCmd1.CommandText = string.Format("select * from namdinh_qlbn.dbo.BENHNHAN_PHIEUDIEUTRI  a inner join NAMDINH_QLBN.dbo.PHIEUDIEUTRI_CHITIET b on a.sophieu = b.sophieu inner join NAMDINH_QLBN.dbo.BENHNHAN_CHITIET c on c.MaVaoVien = a.MaVaoVien inner join NAMDINH_SYSDB.dbo.DMDICHVU d on d.MaDichVu = b.MaDichVu where c.MaVaoVien = '{0}' and d.IsphauThuat = 1 and D.loaidichvu = 'B01' and a.MaKhoa != 'NV1108'", lblMaVaoVien.Text);
                dr1 = SQLCmd1.ExecuteReader();
                if (dr1.HasRows)
                {
                    MessageBox.Show("Bệnh nhân không phẫu thuật \n\n\nBạn nhập loại giường bệnh không đúng");
                    dr1.Close();
                    return false;
                }
                dr1.Close();
            }
            return true;
        }
      
        private void cmbNoiRaVien_TextChanged(object sender, EventArgs e)
        {
            if (cmbNoiRaVien.Tag.ToString() == "0") return;
            if (Global.GetCode(cmbNoiRaVien) == null) return;
            if (Global.GetCode(cmbNoiRaVien).ToString() == "4")
            {
                EnabledChuyenVien(true);
                //frmThongTienChuyenVien frm = new frmThongTienChuyenVien(this);
                //frm.ShowDialog();
            }
            else
            {
                EnabledChuyenVien(false);
                cmbDSBenhVien.SelectedIndex = -1;
            }
        }

        private void fgDanhSach_AfterRowColChange(object sender, C1.Win.C1FlexGrid.RangeEventArgs e)
        {
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            System.Data.SqlClient.SqlDataReader dr;
            if (fgDanhSach.Tag.ToString() == "0") { return; }
            Load_BenhNhan();
            if (lblNgayVaoVien.Text == "" || txtNgayRaVien.Text == "")
            {
                lblNgayDT.Text = "Số ngày điều trị:";
                return;
            }

            //SQLCmd.CommandText = string.Format("select tendichvu,NgayChi from PHIEUDIEUTRI_CHITIET CT inner join BENHNHAN_PHIEUDIEUTRI PDT on CT.Sophieu = pdt.Sophieu  inner join DMDICHVU DV on CT.Madichvu = DV.Madichvu "
            //         + " where PDT.MAVAOVIEN  = '{0}'  and CT.dathuchien = 0 and CT.Loaidichvu >'B99'  and CT.Loaidichvu <'D'", this.fgDanhSach.GetDataDisplay(this.fgDanhSach.Row, 1));
            //SQLCmd.CommandTimeout = 0;
            //dr = SQLCmd.ExecuteReader();
            //string ChuaThucHien = "";
            //while (dr.Read())
            //{
            //    ChuaThucHien = ChuaThucHien + Environment.NewLine + "     - " + dr["tendichvu"] + "---" + dr["NgayChiDinh"];
            //}
            //dr.Close();
            //if (ChuaThucHien != "")
            //{
            //    //ChuaThucHien = ChuaThucHien.Substring(0, ChuaThucHien.Length - 2);
            //    MessageBox.Show("Dịch vụ: " + ChuaThucHien + Environment.NewLine + "chưa thực hiện, đề nghị bạn kiểm tra lại.", "Cảnh báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            //}
            DateTime NgayRaVien = DateTime.Parse(txtNgayRaVien.Text);
            DateTime NgayVaoVien = DateTime.Parse(lblNgayVaoVien.Text);
            System.TimeSpan NgayDT = NgayRaVien - NgayVaoVien;
            lblNgayDT.Text = string.Format("Số ngày điều trị: {0}", NgayDT.Days + 1);
            txtChanDoanRaVien.Text = fgDanhSach.GetDataDisplay(fgDanhSach.Row, "ChanDoanRaVien");
            Diachi = fgDanhSach.GetDataDisplay(fgDanhSach.Row, "Diachi");
            SoTheBHYT = fgDanhSach.GetDataDisplay(fgDanhSach.Row, "SotheBHYT");
            HanTheTu = fgDanhSach.GetDataDisplay(fgDanhSach.Row, "GiatriTu");
            HanTheDen = fgDanhSach.GetDataDisplay(fgDanhSach.Row, "GiatriDen");
            Namsinh = fgDanhSach.GetDataDisplay(fgDanhSach.Row, "Namsinh");
            if(rdChuaRV.Checked == true)
            {
                cmbNoiRaVien.Enabled = cmbKQDT.Enabled= cmbDSBenhVien.Enabled = true;
            }
            else
            {
                cmbNoiRaVien.Enabled = cmbKQDT.Enabled = cmbDSBenhVien.Enabled = false;
            }
            
            if ((GetSession()))
            {
                SQLCmd.CommandText = String.Format("set dateformat dmy SELECT DT.maDoiTuongBHXH+ DT.SoThe AS BHYT, a.HoTen, a.NamSinh,CASE a.GioiTinh WHEN  0 THEN 2 ELSE 1 END AS GT,dt.MaNoiCap,KB.THOIGIANDANGKY "
                 + " FROM (BENHNHAN A INNER JOIN BENHNHAN_CHITIET B ON A.MABENHNHAN = B.MABENHNHAN) "
                 + " INNER JOIN BENHNHAN_DOITUONG DT ON dt.MaVaoVien = b.MaVaoVien and DT.DoiTuong = 1 "
                 + " INNER JOIN NAMDINH_KHAMBENH.DBO.TBLKHAMBENH KB ON KB.MAKHAMBENH = B.MAKHAMBENH "
                 + " where B.MaVaoVien = '{0}'", lblMaVaoVien.Text);
                dr = SQLCmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        string ngayra = string.Format("{0:dd/MM/yyyy}", txtNgayRaVien.Value);
                        string ngayvao = string.Format("{0:dd/MM/yyyy}", DateTime.Parse(dr["THOIGIANDANGKY"].ToString()));
                        
                        CheckTheBHYT(dr["BHYT"].ToString(), dr["HoTen"].ToString(), dr["NamSinh"].ToString(), dr["GT"].ToString(), dr["MaNoiCap"].ToString(), ngayra, ngayvao);
                    }
                }

                dr.Close();
                dr.Dispose();
                //Guihosogiamdinh_4210();
            }
        }
        private void cmdDonThuoc_Click(object sender, EventArgs e)
        {
            if (lblMaVaoVien.Text.Trim() == "")
            {
                MessageBox.Show("Chưa chọn bệnh nhân để kê đơn!!");
                return;
            }
            NamDinh_QLBN.Forms.DuLieu.FrmDonThuocRaVien frm = new FrmDonThuocRaVien(lblMaVaoVien.Text);
            frm.ShowDialog();
        }

        private void txtMaICD_BenhChinh_KeyUp(object sender, KeyEventArgs e)
        {
            if (e == null || e.KeyCode == Keys.Enter || e.KeyCode == Keys.Separator || e.KeyCode == Keys.Escape)
            {
                txtMaICD_BenhChinh.Text = txtMaICD_BenhChinh.Text.ToUpper();
                System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
                SQLCmd.CommandText = "SELECT CICD10,VViet FROM DMICD10 WHERE  CICD10 = '" + txtMaICD_BenhChinh.Text + "'";
                System.Data.SqlClient.SqlDataReader dr = SQLCmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        txtTenICD_KhoaDieuTri_BC.Text = dr["VViet"].ToString();
                    }
                }
                dr.Close();
                SQLCmd.Dispose();
            }
        }

        private void txtMaICD_BenhChinh_Validated(object sender, EventArgs e)
        {
            txtMaICD_BenhChinh_KeyUp(null, null);
        }

        private void txtMaICD_BenhPhu_KeyUp(object sender, KeyEventArgs e)
        {
            if (e == null || e.KeyCode == Keys.Enter || e.KeyCode == Keys.Separator || e.KeyCode == Keys.Escape)
            {
                txtMaICD_BenhPhu.Text = txtMaICD_BenhPhu.Text.ToUpper();
                System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
                SQLCmd.CommandText = "SELECT CICD10,VViet FROM DMICD10 WHERE CICD10 = '" + txtMaICD_BenhPhu.Text + "'";
                System.Data.SqlClient.SqlDataReader dr = SQLCmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        txtTenICD_KhoaDieuTri_BP.Text = dr["VViet"].ToString();
                    }
                }
                //else
                //{
                //    txtTenICD_KhoaDieuTri_BP.Text = txtMaICD_BenhPhu.Text = "";
                //    MessageBox.Show("Không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
                dr.Close();
                SQLCmd.Dispose();
            }
        }

        private void txtMaICD_BenhPhu_Validated(object sender, EventArgs e)
        {
            txtMaICD_BenhPhu_KeyUp(null, null);
        }

        private void cmdICD_KhoaDieuTri_BC_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.Tien_ich.frmTraCuuICD fr = new NamDinh_QLBN.Forms.Tien_ich.frmTraCuuICD();
            if (fr.ShowDialog() == DialogResult.OK)
            {
                txtMaICD_BenhChinh.Text = fr._MaICD;
                txtTenICD_KhoaDieuTri_BC.Text = fr._TenICD;
            }
        }

        private void cmdICD_KhoaDieuTri_BP_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.Tien_ich.frmTraCuuICD fr = new NamDinh_QLBN.Forms.Tien_ich.frmTraCuuICD();
            //string MaICD = "";
            //string TenICD = "";
            if (fr.ShowDialog() == DialogResult.OK)
            {
                //MaICD = "'"+fr._MaICD+"'";
                txtMaICD_BenhPhu.Text = fr._MaICD;// txtMaICD_BenhPhu.Text + MaICD +",";
                //TenICD = fr._TenICD + ";";
                txtTenICD_KhoaDieuTri_BP.Text = fr._TenICD;//TenICDtxtTenICD_KhoaDieuTri_BP.Text + TenICD;
            }
        }
        private void btnChungNhanPT_Click(object sender, EventArgs e)
        {
            if (lblMaVaoVien.Text.Trim() == "")
            {
                MessageBox.Show("Chưa chọn bệnh nhân để in!!");
                return;
            }
            NamDinh_QLBN.Reports.rptChungNhanPhauThuat_27042022 rep = new NamDinh_QLBN.Reports.rptChungNhanPhauThuat_27042022(lblMaVaoVien.Text, DateTime.Parse(txtNgayRaVien.Text));
            rep.Show();
        }

        private void cmdGiayHenKhamLai_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblMaVaoVien.Text))
                return;
            if (txtNgayHenKhamLai.ValueIsDbNull)
            {
                MessageBox.Show("Chưa nhập ngày hẹn khám!", "Thông báo!");
                txtNgayHenKhamLai.Focus();
                return;
            }
            if (DateTime.Compare((DateTime)txtNgayHenKhamLai.Value, (DateTime)txtNgayRaVien.Value) < 0)
            {
                MessageBox.Show("Ngày hẹn khám lại phải sau ngày ra viện!", "Thông báo!");
                txtNgayHenKhamLai.Focus();
                return;
            }
            if (DateTime.Compare((DateTime)txtNgayHenKhamLai.Value, (DateTime)fgDanhSach.GetData(fgDanhSach.Row, "GiatriDen")) > 0)
            {
                MessageBox.Show("Ngày hẹn khám lại phải trước ngày hết hạn thẻ BHYT!", "Thông báo!");
                txtNgayHenKhamLai.Focus();
                return;
            }
            NamDinh_QLBN.Reports.rptGiayHenKhamLai rpt = new NamDinh_QLBN.Reports.rptGiayHenKhamLai();
            rpt.txtMaphieukham.Text = "Số: " + lblMaVaoVien.Text;
            rpt.txtTenbenhnhan.Text = fgDanhSach.GetDataDisplay(fgDanhSach.Row, "TenBenhNhan");
            rpt.txtNamsinh.Text = fgDanhSach.GetDataDisplay(fgDanhSach.Row, "Tuoi"); // lblTuoi.Text;
            rpt.txtGioitinh.Text = fgDanhSach.GetDataDisplay(fgDanhSach.Row, "GioiTinh");
            rpt.txtDiachi.Text = fgDanhSach.GetDataDisplay(fgDanhSach.Row, "Diachi");
            rpt.txtSotheBHYT.Text = fgDanhSach.GetDataDisplay(fgDanhSach.Row, "SotheBHYT");
            rpt.txtGiatritu.Text = (HanTheTu == null ? "" : string.Format("{0:dd/MM/yyyy}", fgDanhSach.GetDataDisplay(fgDanhSach.Row, "GiatriTu")));
            rpt.txtGiaTriden.Text = (HanTheDen == null ? "" : string.Format("{0:dd/MM/yyyy}", fgDanhSach.GetDataDisplay(fgDanhSach.Row, "GiatriDen")));
            rpt.txtThoigianVV.Text = lblNgayVaoVien.Text;
            rpt.txtThoigianRV.Text = string.Format("{0:dd/MM/yyyy}", txtNgayRaVien.Value);
            rpt.txtChandoan.Text = txtChanDoanRaVien.Text;
            rpt.lblNgayThang.Text = "Nam Định, " + string.Format("ngày {0:dd} tháng {0:MM} năm {0:yyyy}", txtNgayRaVien.Value);
            //rpt.txtNgayhen.Text = "          Hẹn khám lại vào " + string.Format("ngày {0:dd} tháng {0:MM} năm {0:yyyy}", txtNgayHenKhamLai.Value) + ", hoặc đến bất kỳ thời gian nào trước ngày được hẹn khám lại nếu có dấu hiệu (triệu chứng) bất thường.";
            rpt.txtNgayhen.Text = string.Format("ngày {0:dd} tháng {0:MM} năm {0:yyyy}", txtNgayHenKhamLai.Value);
            rpt.txtThoigiankham.Text = fgDanhSach.GetDataDisplay(fgDanhSach.Row,"NgayKham").ToString();
            rpt.Show();
        }
        private void simpleButton1_Click_1(object sender, EventArgs e)
        {

        }

        private void cmdICD_KhoaDieuTri_BP_1_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.Tien_ich.frmTraCuuICD fr = new NamDinh_QLBN.Forms.Tien_ich.frmTraCuuICD();
            if (fr.ShowDialog() == DialogResult.OK)
            {
                    string benhkhac = "";
                    benhkhac = fr._MaICD;
                    txtMaICD_BenhPhu_1.Text = benhkhac + ";" + txtMaICD_BenhPhu_1.Text;
                    txtTenICD_KhoaDieuTri_BP_1.Text = fr._TenICD;
            }
        }

        private void txtMaICD_BenhPhu_1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e == null || e.KeyCode == Keys.Enter || e.KeyCode == Keys.Separator || e.KeyCode == Keys.Escape)
            {
                txtMaICD_BenhPhu_1.Text = txtMaICD_BenhPhu_1.Text.ToUpper();
                System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
                SQLCmd.CommandText = "SELECT CICD10,VViet FROM DMICD10 WHERE CICD10 = '" + txtMaICD_BenhPhu_1.Text + "'";
                System.Data.SqlClient.SqlDataReader dr = SQLCmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        txtTenICD_KhoaDieuTri_BP_1.Text = dr["VViet"].ToString();
                    }
                }
                dr.Close();
                SQLCmd.Dispose();
            }
        }
        private void txtMaICD_BenhPhu_1_Validated(object sender, EventArgs e)
        {
            txtMaICD_BenhPhu_1_KeyUp(null, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            System.Data.SqlClient.SqlDataReader dr;
            SQLCmd.CommandText = string.Format("select * from BENHNHAN_KHOA_NGAYGIUONG_CT where mavaovien = '" + lblMaVaoVien.Text.Trim()+ "'" + " and Makhoa = '" + Global.GetCode(cmbKhoa) + "'");
            dr = SQLCmd.ExecuteReader();

            while (dr.Read())
            {
                TimeSpan timeOfDay = DateTime.Parse(dr["NgayChuyen"].ToString()).TimeOfDay;
                DateTime NgayBatDau = DateTime.Parse(dr["NgayBatDau"].ToString()); NgayBatDau.ToString("dd/MM/yyyy HH:mm");
                DateTime NgayChuyen = DateTime.Parse(dr["NgayChuyen"].ToString()); NgayChuyen.ToString("dd/MM/yyyy HH:mm");
                DateTime NgayBatDau_12 = DateTime.Parse(NgayBatDau.ToString("dd/MM/yyyy 11:59"));
                DateTime NgayChuyen_12 = DateTime.Parse(NgayChuyen.ToString("dd/MM/yyyy 11:59"));
                if (dr["TrangThaiBN"].ToString() == "2")
                {
                    if ((NgayChuyen.Hour - NgayBatDau.Hour) < 4 && ((NgayBatDau.Day == NgayChuyen.Day) || (NgayBatDau.Day + 1 == NgayChuyen.Day)))
                    {
                        MessageBox.Show("" + (0.0));
                    }
                    if ((NgayChuyen.Hour - NgayBatDau.Hour) > 4 && ((NgayBatDau.Day + 1 == NgayChuyen.Day) && (NgayChuyen.Hour - NgayBatDau.Hour) <= 24))
                    {
                        MessageBox.Show("" + (1.0));
                    }
                    if ((NgayChuyen.Hour - NgayBatDau.Hour) > 4 && ((NgayBatDau.Day == NgayChuyen.Day) && (NgayChuyen.Hour - NgayBatDau.Hour) <= 24))
                    {
                        MessageBox.Show("" + (1.0));
                    }
                    if ((NgayBatDau.Day < NgayChuyen.Day))
                    {
                        //Vào viện trước 12 giờ, ra viện trước 12 giờ 
                        if ((DateTime.Compare(NgayBatDau, NgayBatDau_12) < 0) && (DateTime.Compare(NgayChuyen, NgayChuyen_12) < 0))
                        {
                            TimeSpan span1 = DateTime.Parse(dr["NgayChuyen"].ToString()) - DateTime.Parse(dr["NgayBatDau"].ToString());
                            MessageBox.Show("" + (0.7 + Double.Parse(span1.Days.ToString()) - 1 + 0.5));
                        }
                        //Vào trước 12 giờ, ra sau 12 giờ 
                        if ((DateTime.Compare(NgayBatDau, NgayBatDau_12) < 0) && (DateTime.Compare(NgayChuyen, NgayChuyen_12) > 0))
                        {
                            TimeSpan span1 = DateTime.Parse(dr["NgayChuyen"].ToString()) - DateTime.Parse(dr["NgayBatDau"].ToString());
                            MessageBox.Show("" + (0.7 + Double.Parse(span1.Days.ToString()) - 1 + 0.7));
                        }
                        //Vào sau 12 giờ, ra trước 12 giờ 
                        if ((DateTime.Compare(NgayBatDau, NgayBatDau_12) > 0) && (DateTime.Compare(NgayChuyen, NgayChuyen_12) < 0))
                        {
                            TimeSpan span1 = DateTime.Parse(dr["NgayChuyen"].ToString()) - DateTime.Parse(dr["NgayBatDau"].ToString());
                            MessageBox.Show("" + (0.5 + Double.Parse(span1.Days.ToString()) - 1 + 0.5));
                        }
                        //Vào sau 12 giờ, ra sau 12 giờ 
                        if ((DateTime.Compare(NgayBatDau, NgayBatDau_12) > 0) && (DateTime.Compare(NgayChuyen, NgayChuyen_12) > 0))
                        {
                            TimeSpan span1 = DateTime.Parse(dr["NgayChuyen"].ToString()) - DateTime.Parse(dr["NgayBatDau"].ToString());
                            MessageBox.Show("" + (0.5 + Double.Parse(span1.Days.ToString()) - 1 + 0.7));
                        }
                    }
                }
                    //Nếu bệnh nhân vào viện từ Khoa Khám bệnh, sau đó chuyển khoa
                    if (dr["TrangThaiBN"].ToString() == "1")
                    {
                        if ((NgayChuyen.Hour - NgayBatDau.Hour) < 4 && (NgayBatDau.Day == NgayChuyen.Day))
                        {
                            MessageBox.Show("" + (0.5));
                        }
                       
                        if ((NgayBatDau.Day < NgayChuyen.Day))
                        {
                            //Vào viện trước 12 giờ
                            if ((DateTime.Compare(NgayBatDau, NgayBatDau_12) < 0))
                            {
                                TimeSpan span1 = DateTime.Parse(dr["NgayChuyen"].ToString()) - DateTime.Parse(dr["NgayBatDau"].ToString());
                                MessageBox.Show("" + (0.7 + Double.Parse(span1.Days.ToString()) - 1 + 0.5));
                            }
                            //Vào sau 12 giờ
                            if ((DateTime.Compare(NgayBatDau, NgayBatDau_12) > 0))
                            {
                                TimeSpan span1 = DateTime.Parse(dr["NgayChuyen"].ToString()) - DateTime.Parse(dr["NgayBatDau"].ToString());
                                MessageBox.Show("" + (0.5 + Double.Parse(span1.Days.ToString()) - 1 + 0.5));
                            }
                        }

                    }
            }
            dr.Close();
            SQLCmd.Dispose();
        }

        private void chXacNhanRV_CheckedChanged(object sender, EventArgs e)
        {
          
        }
        private void chXacNhanRV_Click(object sender, EventArgs e)
        {

            //if (chXacNhanRV.Checked == true )
            //{
            //    //cmdICD_KhoaDieuTri_BP_1.Enabled = false;
            //    cmdICD_KhoaDieuTri_BP_1.Enabled = false;
            //    if (txtMaICD_BenhPhu_1.Text.Length > 1)
            //    { 
            //        if (txtMaICD_BenhPhu_1.Text.Substring(txtMaICD_BenhPhu_1.Text.Length - 1) == ";")
            //        {
            //            txtMaICD_BenhPhu_1.Text = txtMaICD_BenhPhu_1.Text.Substring(0, txtMaICD_BenhPhu_1.Text.Length - 1);
            //        }   
            //    }
            //}
            //else
            //{
            //    cmdICD_KhoaDieuTri_BP_1.Enabled = true;
            //}
        }

        private void simpleButton1_Click_2(object sender, EventArgs e)
        {
            if (lblMaVaoVien.Text.Trim() == "")
            {
                MessageBox.Show("Chưa chọn bệnh nhân để in!!");
                return;
            }
            NamDinh_QLBN.Forms.DuLieu.DuyetPhieuCD.frmThemThongTinThuongTich frm = new DuyetPhieuCD.frmThemThongTinThuongTich(lblMaVaoVien.Text);
            frm.Show();
        }

        private void txtDKNgayRV_Calendar_VisibleChanged(object sender, EventArgs e)
        {
            //            if (txtDKNgayRV.Tag.ToString() == "0") { return; }
            //Load_DSBenhNhan();
        }

        private void txtChanDoan_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtChanDoan.Text != "")
            {
                txtChanDoanRaVien.Text = txtChanDoan.Text;
            }
        }

        private void fgDanhSach_Click(object sender, EventArgs e)
        {
            if (Global.GetNgayLV()  >= DateTime.Parse("01/01/2021") && (DateTime.Parse(fgDanhSach[fgDanhSach.Row, "NgayKham"].ToString()) <= DateTime.Parse("01/01/2021")) && (fgDanhSach[fgDanhSach.Row, "datinhphi"].ToString() == "0" && fgDanhSach[fgDanhSach.Row, "tuyen"].ToString() == "1" && fgDanhSach[fgDanhSach.Row, 5].ToString() == "Bảo hiểm y tế"))
            {
                MessageBox.Show("Bệnh nhân được hưởng mức hưởng BHYT như đúng tuyến (Từ ngày 01/01/2021) \nĐỀ NGHỊ CHUYỂN MỨC HƯỞNG CHO BỆNH NHÂN", "Cảnh Báo",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                return;
            }
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            System.Data.SqlClient.SqlDataReader dr;
            CmbTruongPho.SelectedIndex = 0;
            if (fgDanhSach.Tag.ToString() == "0") { return; }
            if(fgDanhSach.GetData(fgDanhSach.Row,"datinhphi").ToString() == "1")
            {
                cmdGhi.Enabled = cmdGiayHenKhamLai.Enabled = false;

            }
            else
            {
                cmdGhi.Enabled = cmdGiayHenKhamLai.Enabled = true;
            }
            SQLCmd.CommandText = string.Format("select tendichvu,NgayChiDinh from PHIEUDIEUTRI_CHITIET CT inner join BENHNHAN_PHIEUDIEUTRI PDT on CT.Sophieu = pdt.Sophieu  inner join DMDICHVU DV on CT.Madichvu = DV.Madichvu "
                     + " where PDT.MAVAOVIEN  = '{0}'  and CT.dathuchien = 0 and CT.Loaidichvu >'B99'  and CT.Loaidichvu <'D' and ct.loaidichvu not in ('C55','B01','E03','C01','C03','E01')", lblMaVaoVien.Text);
            SQLCmd.CommandTimeout = 0;
            dr = SQLCmd.ExecuteReader();
            string ChuaThucHien = "";
            while (dr.Read())
            {
                ChuaThucHien = ChuaThucHien + Environment.NewLine + "     - " + dr["tendichvu"] + "   Ngày: " + string.Format("{0:dd/MM/yyyy}", dr["NgayChiDinh"]);
                    
            }
            dr.Close();
            if (ChuaThucHien != "")
            {
                //ChuaThucHien = ChuaThucHien.Substring(0, ChuaThucHien.Length - 2);
                MessageBox.Show("Dịch vụ: " + ChuaThucHien + Environment.NewLine + "chưa thực hiện, đề nghị bạn kiểm tra lại.", "Cảnh báo!");
            }

            SQLCmd.CommandText = string.Format("select top 1 Mavaovien, GtriTu,GtriDen,NgayChuyen from NAMDINH_QLBN.dbo.BENHNHAN_DOITUONG where mavaovien = N'{0}' and  DoiTuong = 1 ", lblMaVaoVien.Text);
            dr = SQLCmd.ExecuteReader();
            while(dr.Read())
            {
                DateTime d = DateTime.Parse(dr["NgayChuyen"].ToString()).Date;
                DateTime d1 = DateTime.Parse(dr["GtriDen"].ToString()).Date;
                if ((DateTime.Parse(dr["GtriTu"].ToString()) > DateTime.Parse(dr["NgayChuyen"].ToString()))|| (DateTime.Parse(dr["GtriDen"].ToString()).Date < DateTime.Parse(dr["NgayChuyen"].ToString()).Date))
                {
                    MessageBox.Show(string.Format("Kiểm tra lại hạn thẻ BHYT của bệnh nhân" + Environment.NewLine + "- Có giá trị từ ngày '{0:dd/MM/yyyy}' đến ngày '{1:dd/MM/yyyy}'" + Environment.NewLine + "- Thời gian vào viện {2:dd/MM/yyyy HH:mm} không nằm trong giới hạn thẻ ", DateTime.Parse(dr["GtriTu"].ToString()), DateTime.Parse(dr["GtriDen"].ToString()), DateTime.Parse(dr["NgayChuyen"].ToString())), "Cảnh báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            dr.Close();
        }

        private void txtDKNgayRV_DropDownClosed(object sender, EventArgs e)
        {
            Load_DSBenhNhan();
            if (txtDKNgayRV.Tag.ToString() == "0") { return; }
        }

        private void rdDaRV_CheckedChanged(object sender, EventArgs e)
        {
            Clear_Data();
        }

        private void txtMaICD_BenhPhu_1_DoubleClick(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.TienIch.frmICDPhu_RaVien fr = new NamDinh_QLBN.Forms.TienIch.frmICDPhu_RaVien(txtMaICD_BenhPhu_1.Text);
            if (fr.ShowDialog() == DialogResult.OK)
            {
                fr.TopMost = true;
                txtMaICD_BenhPhu_1.Text = fr.benhphu;
            }
        }

        private void txtMaICD_BenhPhu_1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            txtMaICD_BenhPhu_1_DoubleClick(null, null);
        }

        private void btnBenhAn_Click(object sender, EventArgs e)
        {
            if(lblMaVaoVien.Text == "")
            {
                MessageBox.Show("Chưa chọn bệnh nhân làm bệnh án");
                return;
            }
            else
            {
                frmBenhAn frm = new frmBenhAn(lblMaVaoVien.Text, fgDanhSach.GetDataDisplay(fgDanhSach.Row, "NgayKham"), fgDanhSach.GetDataDisplay(fgDanhSach.Row, "SoHSBA"), fgDanhSach.GetDataDisplay(fgDanhSach.Row, "SoLuuTru"),fgDanhSach);
                frm.Show();
            }
        }

        private void txtIDBo_TextChanged(object sender, EventArgs e)
        {
                if (System.Text.RegularExpressions.Regex.IsMatch(txtIDBo.Text, "[^0-9]"))
                {
                    MessageBox.Show("Please enter only numbers.");
                    txtIDBo.Text = txtIDBo.Text.Remove(txtIDBo.Text.Length - 1);
                }
        }

        private void txtIDMe_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtIDMe.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                txtIDMe.Text = txtIDMe.Text.Remove(txtIDMe.Text.Length - 1);
            }

        }
        //public static byte[] ReadFile(string filePath)
        //{
        //    byte[] buffer;
        //    FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
        //    try
        //    {
        //        int length = (int)fileStream.Length;  // get file length
        //        buffer = new byte[length];            // create buffer
        //        int count;                            // actual number of bytes read
        //        int sum = 0;                          // total number of bytes read

        //        // read until Read method returns 0 (end of the stream has been reached)
        //        while ((count = fileStream.Read(buffer, sum, length - sum)) > 0)
        //            sum += count;  // sum is a buffer offset for next reading
        //    }
        //    finally
        //    {
        //        fileStream.Close();
        //    }
        //    return buffer;
        //}
    }
}