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
using System.Collections.Specialized;

namespace NamDinh_QLBN.Forms.DuLieu
{
    public partial class frmLichSuDieuTri : Form
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
        public static bool GetSession()
        {
            
            WebClient client = new WebClient();
            NameValueCollection values = new NameValueCollection();
            values.Add("username", "36001_BV");
            values.Add("password", "e10adc3949ba59abbe56e057f20f883e");

            byte[] bytes = client.UploadValues("Https://egw.baohiemxahoi.gov.vn/api/token/take", values);
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

            //string Mes = "Lỗi kh\x00f4ng x\x00e1c định";
            return false;
        }

        public void CheckTheBHYT(string MaThe, string HoTen, string NgaySinh, string GioiTinh, string MaCSKCB, string NgayBD, string NgayKT)
        {

            if (GetSession())
            {
                string str = "";
                WebClient client = new WebClient();
                NameValueCollection values = new NameValueCollection();
                values.Add("maThe", MaThe);
                values.Add("hoTen", HoTen);
                values.Add("ngaySinh", NgaySinh);
                values.Add("gioiTinh", GioiTinh);
                values.Add("maCSKCB", MaCSKCB);
                values.Add("ngayBD", NgayBD);
                values.Add("ngayKT", NgayKT);
                byte[] bytes = client.UploadValues(string.Format("Https://egw.baohiemxahoi.gov.vn/api/egw/KQnhanLichSuKCB2019?token={0}&id_token={1}&username={2}&password={3}", new object[] { Access_Token, IDToken, "36001_BV", "e10adc3949ba59abbe56e057f20f883e" }), values);
                str = Encoding.UTF8.GetString(bytes);
                txtTenBP.Text = str;
            }
        }
        //string[] separator = new string[] { "{\"maKetQua\":", ",\"dsLichSuKCB\":" };
        //string[] strArray4 = str.Split(separator, StringSplitOptions.RemoveEmptyEntries);
        //MaKetQua = strArray4[0].Substring(0, strArray4[0].Length - 1).Substring(1, strArray4[0].Length - 2);
        //strArray4[1] = strArray4[1].Substring(0, strArray4[1].Length - 1).Substring(1, strArray4[1].Length - 2);

        //    string[] strArray = new string[] { "{", "\"maCSKCB\":", "\"tuNgay\":", ",\"denNgay\":", "\"tenBenh\":", ",\"tinhTrang\":", "\"kqDieuTri\":" };
        //    string[] MaHS = new string[] { "{\"maHoSo\":" };
        //    string[] MaHs_ct = str.Split(MaHS, StringSplitOptions.RemoveEmptyEntries);
        //    string[] maCSKCB = new string[] { "\"maCSKCB\":" };
        //    string[] maCSKCB_ct = str.Split(maCSKCB, StringSplitOptions.RemoveEmptyEntries);
        //    string[] tenBenh = new string[] { "\"tenBenh\":" };
        //    string[] tenBenh_ct = str.Split(tenBenh, StringSplitOptions.RemoveEmptyEntries);
        //    string[] tuNgay = new string[] { "\"tuNgay\":" };
        //    string[] tuNgay_ct = str.Split(tuNgay, StringSplitOptions.RemoveEmptyEntries);
        //    string[] denNgay = new string[] { "\"denNgay\":" };
        //    string[] denNgay_ct = str.Split(denNgay, StringSplitOptions.RemoveEmptyEntries);
        //    fg_ChiPhi.Tag = "0";

        //    System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
        //    SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
        //    //string makcb = maCSKCB_ct[i].Substring(0, maCSKCB_ct[i].IndexOf(','));
        //    //string makcb_trim = makcb.Replace('"', ' ');
        //    //string makcb_chitiet = makcb_trim.Trim();
        //    //SQLCmd.CommandText = String.Format("select  Manoicap,Tennoicap from NAMDINH_SYSDB.DBO.DMNOIDKKCBBD_BHYT WHERE  Manoicap== '" + MaVaoVien + "'");
        //    //SqlDataReader reader = SQLCmd.ExecuteReader();
        //    SQLCmd.CommandText = String.Format("select  Manoicap,Tennoicap from NAMDINH_SYSDB.DBO.DMNOIDKKCBBD_BHYT WHERE  Manoicap = '36001'");//+ makcb_chitiet + "'");
        //    SqlDataReader reader = SQLCmd.ExecuteReader();
        //    while (reader.Read())
        //    {


        //        fg_ChiPhi[fg_ChiPhi.Rows.Count - 1, 4] = reader["Tennoicap"];
        //    }

        //    reader.Close();
        //    SQLCmd.Dispose();

        //    for (int i = 1; i <= MaHs_ct.Length - 1; i++)
        //    {

        //        fg_ChiPhi.Rows.Add();
        //        fg_ChiPhi[fg_ChiPhi.Rows.Count - 1, 0] = MaHs_ct[i].Substring(0, MaHs_ct[i].IndexOf(','));
        //        fg_ChiPhi[fg_ChiPhi.Rows.Count - 1, 1] = tenBenh_ct[i].Substring(0, tenBenh_ct[i].IndexOf(','));
        //        fg_ChiPhi[fg_ChiPhi.Rows.Count - 1, 2] = tuNgay_ct[i].Substring(0, tuNgay_ct[i].IndexOf(','));
        //        fg_ChiPhi[fg_ChiPhi.Rows.Count - 1, 3] = denNgay_ct[i].Substring(0, denNgay_ct[i].IndexOf(','));

        //        string makcb = maCSKCB_ct[i].Substring(0, maCSKCB_ct[i].IndexOf(','));
        //        string makcb_trim = makcb.Replace('"', ' ');
        //        string makcb_chitiet = makcb_trim.Trim();
        //        fg_ChiPhi[fg_ChiPhi.Rows.Count - 1, 4] = makcb_chitiet;


        //    }
        //}

        //    //   

        //    //maCSKCB_ct[i].Substring(0, maCSKCB_ct[i].IndexOf(','));


        //    //fg_ChiPhi[fg_ChiPhi.Rows.Count - 1, 5] = TBnttn_ct[i].Substring(0, TBnttn_ct[i].IndexOf(','));
        //    //fg_ChiPhi[fg_ChiPhi.Rows.Count - 1, 6] = TBhtt_ct[i].Substring(0, TBhtt_ct[i].IndexOf(','));

        //    fg_ChiPhi[0, 0] = "MÃ HỒ SƠ";
        //    fg_ChiPhi[0, 1] = "CHẨN ĐOÁN";
        //    fg_ChiPhi[0, 2] = "TỪ NGÀY";
        //    fg_ChiPhi[0, 3] = "ĐẾN NGÀY";
        //    fg_ChiPhi[0, 4] = "MÃ CSKCB";
        //    fg_ChiPhi.AutoSizeCols(0);
        //    fg_ChiPhi.Tag = "1";
        //fg_ChiPhi.Redraw = true;

        //string[] strArray3 = strArray4[1].Split(strArray, StringSplitOptions.RemoveEmptyEntries);
        ////const char x2 = ',';
        ////const char x3 = '"';
        ////const char x4 = '}';
        ////const char x5 = '{';
        //////   const char x6 = '';
        ////char[] delimiters = new char[] { x3, x4, x5 };
        ////string[] strArray3 = strArray4[1].Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
        ////for (int j = 0; j <= strArray3.Length - 1; j++)
        ////{
        ////    if (strArray3[j] == "maHoSo")
        ////    {
        ////        string maHoSo = strArray3[j + 1];

        ////    }
        ////}
        ////string maKetQua = MaKetQua;
        ////string[] subString = maKetQua.Split('"');
        ////string str3 = maKetQua.Substring(0, 3);
        //////if (str3 == "000")
        //////{ string t3 = "Thông tin thẻ chính xác "; MessageBox.Show("KHÔNG CHUYỂN ĐƯỢC ĐỐI TƯỢNG CHO BỆNH NHÂN DO " + t3); };
        //////if (str3 == "001")
        //////{ str3 = "Thẻ do BHXH Bộ quốc phòng quản lý, đề nghị kiểm tra thẻ và thông tin giấy tờ tùy thân"; };
        //////if (str3 == "002")
        //////{ string t3 = "Thẻ do BHXH Bộ Công an quản lý, đề nghị kiểm tra thẻ và thông tin giấy tờ tùy thân"; };
        ////if (str3 == "010")
        ////{ string t3 = "Thẻ hết giá trị sử dụng"; MessageBox.Show(t3); return; };
        ////if (str3 == "051")
        ////{ string t3 = "Mã thẻ không đúng"; MessageBox.Show(t3); return; };
        ////if (str3 == "052")
        ////{ string t3 = "Mã tỉnh cấp thẻ (ký tự thứ 4,5 của mã thẻ) không đúng"; MessageBox.Show(t3); return; };
        ////if (str3 == "053")
        ////{ string t3 = "Mã quyền lợi thẻ(Ký tự thứ 3 của mã thẻ) không đúng"; MessageBox.Show(t3); return; };
        ////if (str3 == "050")
        ////{ string t3 = "Không thấy thông tin thẻ BHYT"; MessageBox.Show(t3); return; };
        ////if (str3 == "060")
        ////{ string t3 = "Thẻ sai họ tên "; MessageBox.Show(t3); return; };
        ////if (str3 == "061")
        ////{ string t3 = "Thẻ sai họ tên đúng ký tự đầu"; MessageBox.Show(t3); return; };
        ////if (str3 == "070")
        ////{ string t3 = "Thẻ sai ngày sinh "; MessageBox.Show(t3); return; };
        ////if (str3 == "080")
        ////{ string t3 = "Thẻ sai giới tính "; MessageBox.Show(t3); return; };
        ////if (str3 == "090")
        ////{ string t3 = "Thẻ sai nơi đăng ký KCBBĐ "; MessageBox.Show(t3); return; };
        ////if (str3 == "100")
        ////{ string t3 = "Lỗi khi lấy dữ liệu số thẻ "; MessageBox.Show(t3); return; };
        ////if (str3 == "101")
        ////{ string t3 = "Lỗi server "; MessageBox.Show(t3); return; };
        ////if (str3 == "110")
        ////{ string t3 = "Thẻ đã thu hồi "; MessageBox.Show(t3); return; };
        ////if (str3 == "120")
        ////{ string t3 = "Thẻ đã báo giảm "; MessageBox.Show(t3); return; };
        ////if (str3 == "121")
        ////{ string t3 = "Thẻ đã báo giảm. Giảm chuyển ngoại tỉnh "; MessageBox.Show(t3); return; };
        ////if (str3 == "122")
        ////{ string t3 = "Thẻ đã báo giảm. Giảm chuyển nội tỉnh "; MessageBox.Show(t3); return; };
        ////if (str3 == "123")
        ////{ string t3 = "Thẻ đã báo giảm. Thu hồi do tăng lại cùng đơn vị "; MessageBox.Show(t3); return; };
        ////if (str3 == "124")
        ////{ string t3 = "Thẻ đã báo giảm. Ngừng tham gia "; MessageBox.Show(t3); return; };
        //////if (str3 == "130")
        //////{ string t3 = "Trẻ em không xuất trình thẻ "; MessageBox.Show(t3);};
        //////}
        //  }

        public frmLichSuDieuTri()
        {
            InitializeComponent();
            //GetSession();

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
            cmbKhoa.Tag = "1";
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
            SQLCmd.CommandText = "select BENHNHAN_CHITIET.MaVaoVien,BENHNHAN.HoTen As TenBenhNhan, NamSinh as Tuoi,"
                + " GioiTinh,TenDT,NgayVaoVien,case when benhnhan_chitiet.ChanDoanRaVien is null then viewkhoahientai.ChanDoan else benhnhan_chitiet.ChanDoanRaVien end as ChanDoanRaVien,"
                + " BENHNHAN_CHITIET.Diachi, isnull(ViewDOITUONGHIENTAI.MadoituongBHXH,'') + ' - ' + isnull(ViewDOITUONGHIENTAI.Sothe,'') + ' - '  + isnull(ViewDOITUONGHIENTAI.Manoicap,'') as SotheBHYT, "
                + " isnull(ViewDOITUONGHIENTAI.GtriTu,'') as GiatriTu, isnull(ViewDOITUONGHIENTAI.GtriDen,'') as GiatriDen, NamSinh  "
                + " FROM (((BENHNHAN INNER JOIN BENHNHAN_CHITIET ON BENHNHAN.MaBenhNhan=BENHNHAN_CHITIET.MaBenhNhan)"
                + " INNER JOIN ViewDOITUONGHIENTAI ON BENHNHAN_CHITIET.MaVaoVien=ViewDOITUONGHIENTAI.MaVaoVien)"
                + " INNER JOIN DMDOITUONGBN ON ViewDOITUONGHIENTAI.DoiTuong=DMDOITUONGBN.MaDT)"
                + " INNER JOIN ViewKHOAHIENTAI ON BENHNHAN_CHITIET.MaVaoVien=ViewKHOAHIENTAI.MaVaoVien "
                + " WHERE MaKhoa ='" + MaKhoa + "'  AND TrangThai=1 ";

            if (rdChuaRV.Checked)
            {
                SQLCmd.CommandText += " AND ViewKHOAHIENTAI.vDaRaVien=0";
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
                fgDanhSach.AddItem(string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6:dd/MM/yyyy}|{7}|{8}|{9}|{10:dd/MM/yyyy}|{11:dd/MM/yyyy}|{12}", fgDanhSach.Rows.Count,
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
                    dr["Namsinh"]));
            }
            dr.Close();
            fgDanhSach.AutoSizeCols();
            fgDanhSach.Tag = "1";
            SQLCmd.Dispose();
            Clear_Data();
            if (rdChuaRV.Checked)
            {
                txtNgayRaVien.Value = Global.NgayLV;
            }
        }
        private void Clear_Data()
        {

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
            if (rdDaRV.Checked)
            {
                System.Data.SqlClient.SqlDataReader dr;
                System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
                SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;

                SQLCmd.CommandText = string.Format("SELECT BENHNHAN_CHITIET.*,BENHCHINH.CICD10 AS MABC,BENHCHINH.VVIET AS TENBC,BENHPHU.CICD10 AS MABP,BENHPHU.VVIET AS TENBP FROM BENHNHAN_CHITIET "
                + " INNER JOIN VIEWKHOAHIENTAI ON VIEWKHOAHIENTAI.MAVAOVIEN = BENHNHAN_CHITIET.MAVAOVIEN"
                + " LEFT JOIN DMICD10 BENHCHINH ON BENHCHINH.CICD10 = VIEWKHOAHIENTAI.MAICD_BC"
                + " LEFT JOIN DMICD10 BENHPHU ON BENHPHU.CICD10 = VIEWKHOAHIENTAI.MAICD_BP"
                    + " WHERE BENHNHAN_CHITIET.MaVaoVien='{0}'", lblMaVaoVien.Text);
                dr = SQLCmd.ExecuteReader();
                while (dr.Read())
                {
                    txtNgayRaVien.Value = dr["NgayRaVien"];
                    txtNgayHenKhamLai.Value = dr["NgayHenKhamLai"];
                    Global.SetCmb(cmbKhaNangLD, dr["KhaNangLD"].ToString());
                    txtTenBC.Text = dr["BenhChinh_RaVien"].ToString();
                    SoTheBHYT = dr["MaDTBHYT"].ToString() + " - " + dr["SoTheBHYT"].ToString() + " - " + dr["MaNoiCapBHYT"].ToString();
                }

                dr.Close();
                SQLCmd.Dispose();

            }
        }


        private void rdChuaRV_CheckedChanged(object sender, EventArgs e)
        {
            if (rdChuaRV.Checked)
            {
                txtDKNgayRV.Visible = false;
            }
            else
            {
                txtDKNgayRV.Visible = true;
            }
            Load_DSBenhNhan();
        }

        private void txtDKNgayRV_ValueChanged(object sender, EventArgs e)
        {
            if (txtDKNgayRV.Tag.ToString() == "0") { return; }
            Load_DSBenhNhan();
        }

        private void cmdThoat_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void cmbBrowseBC_Click(object sender, EventArgs e)
        {

        }

        private void cmbBrowseBP_Click(object sender, EventArgs e)
        {

        }
        private void cmdGhi_Click(object sender, EventArgs e)
        {

        }
        private void txtNgayRaVien_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtNgayRaVien_ValueChanged(object sender, EventArgs e)
        {
            if (txtDKNgayRV.Tag.ToString() == "0") { return; }
            Load_DSBenhNhan();
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Reports.rptGiayRaVien rpt = new NamDinh_QLBN.Reports.rptGiayRaVien(lblMaVaoVien.Text);
            rpt.Show();
        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Reports.repPhieuChuyenVien rep = new NamDinh_QLBN.Reports.repPhieuChuyenVien(lblMaVaoVien.Text);
            rep.Show();
        }
        private void EnabledChuyenVien(bool Flag)
        {

        }
        private void cmbNoiRaVien_TextChanged(object sender, EventArgs e)
        {
        }
        private void fgDanhSach_AfterRowColChange(object sender, C1.Win.C1FlexGrid.RangeEventArgs e)
        {

            int numRows1 = fg_ChiPhi_1.Rows.Count;
            for (int i = 0; i < numRows1 - 1; i++)
            {
                int max = fg_ChiPhi_1.Rows.Count - 1;
                fg_ChiPhi_1.Rows.Remove(fg_ChiPhi_1.Rows[max]);

            }
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            System.Data.SqlClient.SqlDataReader dr;

            if (fgDanhSach.Tag.ToString() == "0") { return; }
            Load_BenhNhan();
            DateTime NgayRaVien = DateTime.Parse(txtNgayRaVien.Text);
            DateTime NgayVaoVien = DateTime.Parse(lblNgayVaoVien.Text);
            System.TimeSpan NgayDT = NgayRaVien - NgayVaoVien;
            Diachi = fgDanhSach.GetDataDisplay(fgDanhSach.Row, "Diachi");
            SoTheBHYT = fgDanhSach.GetDataDisplay(fgDanhSach.Row, "SotheBHYT");
            HanTheTu = fgDanhSach.GetDataDisplay(fgDanhSach.Row, "GiatriTu");
            HanTheDen = fgDanhSach.GetDataDisplay(fgDanhSach.Row, "GiatriDen");
            Namsinh = fgDanhSach.GetDataDisplay(fgDanhSach.Row, "Namsinh");
            if ((GetSession()))
            {
                SQLCmd.CommandText = String.Format(" SELECT DT.maDoiTuongBHXH+ DT.SoThe AS BHYT, a.HoTen, a.NamSinh,CASE a.GioiTinh WHEN  0 THEN 2 ELSE 1 END AS GT,dt.MaNoiCap,KB.THOIGIANDANGKY "
                 + " FROM (BENHNHAN A INNER JOIN BENHNHAN_CHITIET B ON A.MABENHNHAN = B.MABENHNHAN) "
                 + " INNER JOIN BENHNHAN_DOITUONG DT ON dt.MaVaoVien = b.MaVaoVien and DT.DoiTuong = 1 "
                 + " INNER JOIN NAMDINH_KHAMBENH.DBO.TBLKHAMBENH KB ON KB.MAKHAMBENH = B.MAKHAMBENH "
                 + " where B.MaVaoVien = '{0}'", lblMaVaoVien.Text);
                dr = SQLCmd.ExecuteReader();
                fg_ChiPhi.Clear();
                int numRows = fg_ChiPhi.Rows.Count;
                for (int i = 0; i < numRows - 1; i++)
                {
                    int max = fg_ChiPhi.Rows.Count - 1;
                    fg_ChiPhi.Rows.Remove(fg_ChiPhi.Rows[max]);

                }

                while (dr.Read())
                {
                    string ngayra = string.Format("{0:dd/MM/yyyy}", txtNgayRaVien.Value);
                    string ngayvao = string.Format("{0:dd/MM/yyyy}", DateTime.Parse(dr["THOIGIANDANGKY"].ToString()));
                    CheckTheBHYT(dr["BHYT"].ToString(), dr["HoTen"].ToString(), dr["NamSinh"].ToString(), dr["GT"].ToString(), dr["MaNoiCap"].ToString(), ngayra, ngayvao);
                }

                dr.Close();
                dr.Dispose();
            }
            string str = txtTenBP.Text.Trim();
            string[] strArray = new string[] { "{", "\"maCSKCB\":", "\"ngayVao\":", ",\"ngayRa\":", "\"tenBenh\":", ",\"tinhTrang\":", "\"kqDieuTri\":" };
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
            string[] kqDieuTri = new string[] { "\"tinhTrang\":" };
            string[] kqDieuTri_ct = str.Split(kqDieuTri, StringSplitOptions.RemoveEmptyEntries);

            fg_ChiPhi.Tag = "0";
            for (int i = 1; i <= MaHs_ct.Length - 1; i++)
            {

                fg_ChiPhi.Rows.Add();
                fg_ChiPhi[fg_ChiPhi.Rows.Count - 1, 0] = MaHs_ct[i].Substring(0, MaHs_ct[i].IndexOf(','));
                fg_ChiPhi[fg_ChiPhi.Rows.Count - 1, 1] = tenBenh_ct[i].Substring(0, tenBenh_ct[i].IndexOf(','));
                fg_ChiPhi[fg_ChiPhi.Rows.Count - 1, 2] = tuNgay_ct[i].Substring(0, tuNgay_ct[i].IndexOf(','));
                fg_ChiPhi[fg_ChiPhi.Rows.Count - 1, 3] = denNgay_ct[i].Substring(0, denNgay_ct[i].IndexOf(','));
                string ketqua = kqDieuTri_ct[i].Substring(0, kqDieuTri_ct[i].IndexOf(','));
                string ketqua_1 = ketqua.Replace('"', ' ');
                string ketqua_trim = ketqua_1.Trim();
                if (ketqua_trim == "1")
                {
                    fg_ChiPhi[fg_ChiPhi.Rows.Count - 1, 5] = "Ra Viện";
                }
                if (ketqua_trim == "2")
                {
                    fg_ChiPhi[fg_ChiPhi.Rows.Count - 1, 5] = "Chuyển Viện";
                }

                if (ketqua_trim == "3")
                {
                    fg_ChiPhi[fg_ChiPhi.Rows.Count - 1, 5] = "Chốn viện";
                }
                if (ketqua_trim == "4")
                {
                    fg_ChiPhi[fg_ChiPhi.Rows.Count - 1, 5] = "Xin ra viện";
                }
                string makcb = maCSKCB_ct[i].Substring(0, maCSKCB_ct[i].IndexOf(','));
                string makcb_trim = makcb.Replace('"', ' ');
                string makcb_chitiet = makcb_trim.Trim();
                fg_ChiPhi[fg_ChiPhi.Rows.Count - 1, 4] = makcb_chitiet;
                SQLCmd.CommandText = String.Format("select  Manoicap,Tennoicap from NAMDINH_SYSDB.DBO.DMNOIDKKCBBD_BHYT WHERE  Manoicap = '{0}'", makcb_chitiet);
                SqlDataReader reader = SQLCmd.ExecuteReader();
                while (reader.Read())
                {
                    fg_ChiPhi[fg_ChiPhi.Rows.Count - 1, 4] = reader["Tennoicap"];
                }
                reader.Close();
                SQLCmd.Dispose();
                fg_ChiPhi.Cols[0].Visible = false;
            }
            fg_ChiPhi[0, 0] = "MÃ HỒ SƠ";
            fg_ChiPhi[0, 1] = "MÃ ICD - CHẨN ĐOÁN";
            fg_ChiPhi[0, 2] = "TỪ NGÀY";
            fg_ChiPhi[0, 3] = "ĐẾN NGÀY";
            fg_ChiPhi[0, 4] = "CSKCB";
            fg_ChiPhi[0, 5] = "TÌNH TRẠNG RV";
            fg_ChiPhi.AutoSizeCols(0);
            fg_ChiPhi.Tag = "1";
            txtTenBP.Text = "";
            rdb_xml1.Checked = true; rdb_xml2.Checked = false; ; rdb_xml3.Checked = false; rdb_xml4.Checked = false;
        }
        private void cmdDonThuoc_Click(object sender, EventArgs e)
        {

        }

        private void txtMaICD_BenhChinh_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void txtMaICD_BenhChinh_Validated(object sender, EventArgs e)
        {
            txtMaICD_BenhChinh_KeyUp(null, null);
        }

        private void txtMaICD_BenhPhu_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void txtMaICD_BenhPhu_Validated(object sender, EventArgs e)
        {
            txtMaICD_BenhPhu_KeyUp(null, null);
        }

        private void cmdICD_KhoaDieuTri_BC_Click(object sender, EventArgs e)
        {
        }

        private void cmdICD_KhoaDieuTri_BP_Click(object sender, EventArgs e)
        {

        }

        private void btnChungNhanPT_Click(object sender, EventArgs e)
        {

        }

        private void cmdGiayHenKhamLai_Click(object sender, EventArgs e)
        {

        }

        public void lichsukhamchuabenh_chitiet(string MAHOSO)
        {
            WebClient client = new WebClient();
            NameValueCollection values = new NameValueCollection();
            byte[] bytes = client.UploadValues(string.Format("Https://egw.baohiemxahoi.gov.vn/api/egw/nhanHoSoKCBChiTiet?maHoSo={4}&username={2}&password={3}&token={0}&id_token={1}", new object[] { Access_Token, IDToken, "36001_BV", "e10adc3949ba59abbe56e057f20f883e", MAHOSO }), values);
            string str = Encoding.UTF8.GetString(bytes);
            string[] separator = new string[] { "xml1\":", "Xml2\":", "Xml3\":", "Xml4\":", "Xml5\":" };
            string[] strArray4 = str.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            string xml1 = strArray4[1].Substring(0, strArray4[1].Length - 1).Substring(1, strArray4[1].Length - 2);
            string xml2 = strArray4[2].Substring(0, strArray4[2].Length - 1).Substring(1, strArray4[2].Length - 2);
            string xml3 = strArray4[3].Substring(0, strArray4[3].Length - 1).Substring(1, strArray4[3].Length - 2);
            string[] xml2_chitiet = new string[] { "\"TenThuoc\":" };
            string[] xml2_ct = xml2.Split(xml2_chitiet, StringSplitOptions.None);
            string[] soluong = new string[] { "\"SoLuong\":" };
            string[] soluong_ct = xml2.Split(soluong, StringSplitOptions.None);
            string[] xml2_DVT = new string[] { "\"DonViTinh\":" };
            string[] xml2_DVT_ct = xml2.Split(xml2_DVT, StringSplitOptions.None);
            string[] xml2_DG = new string[] { "\"DonGia\":" };
            string[] xml2_DG_ct = xml2.Split(xml2_DG, StringSplitOptions.None);
            string[] xml2_ThanhTien = new string[] { "\"ThanhTien\":" };
            string[] xml2_ThanhTien_ct = xml2.Split(xml2_ThanhTien, StringSplitOptions.None);
            string[] xml2_NgayYl = new string[] { "\"NgayYl\":" };
            string[] xml2_NgayYl_ct = xml2.Split(xml2_NgayYl, StringSplitOptions.None);
            string[] LieuDung = new string[] { "\"LieuDung\":" };
            string[] LieuDung_ct = xml2.Split(LieuDung, StringSplitOptions.None);

            fg_ChiPhi_1[0, 0] = "Ngay Y Lệnh";
            fg_ChiPhi_1[0, 1] = "Tên Thuốc";
            fg_ChiPhi_1[0, 2] = "ĐVT";
            fg_ChiPhi_1[0, 3] = "Số Lượng";
            fg_ChiPhi_1[0, 4] = "Đơn Giá";
            fg_ChiPhi_1[0, 5] = "Thành Tiền";
            fg_ChiPhi_1[0, 6] = "Liều Dùng";
            int numRows = fg_ChiPhi_1.Rows.Count;
            for (int i = 0; i < numRows - 1; i++)
            {
                int max = fg_ChiPhi_1.Rows.Count - 1;
                fg_ChiPhi_1.Rows.Remove(fg_ChiPhi_1.Rows[max]);

            }
            for (int i = 1; i <= xml2_ct.Length - 1; i++)
            {
                fg_ChiPhi_1.Rows.Add();
                fg_ChiPhi_1[fg_ChiPhi_1.Rows.Count - 1, 0] = chuyengay(xml2_NgayYl_ct[i].Substring(0, xml2_NgayYl_ct[i].IndexOf(',')));
                fg_ChiPhi_1[fg_ChiPhi_1.Rows.Count - 1, 2] = xml2_DVT_ct[i].Substring(0, xml2_DVT_ct[i].IndexOf(','));
                fg_ChiPhi_1[fg_ChiPhi_1.Rows.Count - 1, 1] = xml2_ct[i].Substring(0, xml2_ct[i].IndexOf(','));
                fg_ChiPhi_1[fg_ChiPhi_1.Rows.Count - 1, 3] = soluong_ct[i].Substring(0, soluong_ct[i].IndexOf(','));
                fg_ChiPhi_1[fg_ChiPhi_1.Rows.Count - 1, 4] = xml2_DG_ct[i].Substring(0, xml2_DG_ct[i].IndexOf(','));
                fg_ChiPhi_1[fg_ChiPhi_1.Rows.Count - 1, 5] = xml2_ThanhTien_ct[i].Substring(0, xml2_ThanhTien_ct[i].IndexOf(','));
                fg_ChiPhi_1[fg_ChiPhi_1.Rows.Count - 1, 6] = LieuDung_ct[i].Substring(0, LieuDung_ct[i].IndexOf(','));
            }
            fg_ChiPhi_1.AutoSizeCols(0);
            fg_ChiPhi_1.Redraw = true;
         //   GroupBy("MaLK", 0);
             fg_ChiPhi_1.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictCols;
            fg_ChiPhi_1.Cols[1].AllowMerging = true;
            //for (int i = fg_ChiPhi_1.Cols.Fixed; i <= fg_ChiPhi_1.Cols.Count - 1; i++)
            //{
            //    fg_ChiPhi_1.Cols(0).AllowMerging = true;
            //}
            //fg_ChiPhi_1.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.Clear, 0, 1, 1, 0, "");
        }
        void GroupBy(string columnName, int level)
        {
            object current = null;
            for (int r = fg_ChiPhi_1.Rows.Fixed; r < fg_ChiPhi_1.Rows.Count; r++)
            {
                if (!fg_ChiPhi_1.Rows[r].IsNode)
                {
                    var value = fg_ChiPhi_1[r, columnName];
                    if (!object.Equals(value, current))
                    {
                        fg_ChiPhi_1.Rows.InsertNode(r, level);
                        fg_ChiPhi_1[r, fg_ChiPhi_1.Cols.Fixed] = value;
                        current = value;
                    }
                }
            }
        }
        public void lichsukhamchuabenh_chitiet_XML3(string MAHOSO)
        {
            WebClient client = new WebClient();
            NameValueCollection values = new NameValueCollection();
            byte[] bytes = client.UploadValues(string.Format("Https://egw.baohiemxahoi.gov.vn/api/egw/nhanHoSoKCBChiTiet?maHoSo={4}&username={2}&password={3}&token={0}&id_token={1}", new object[] { Access_Token, IDToken, "36001_BV", "e10adc3949ba59abbe56e057f20f883e", MAHOSO }), values);
            string str = Encoding.UTF8.GetString(bytes);
            string[] separator = new string[] { "xml1\":", "Xml2\":", "Xml3\":", "Xml4\":", "Xml5\":" };
            string[] strArray4 = str.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            string xml1 = strArray4[1].Substring(0, strArray4[1].Length - 1).Substring(1, strArray4[1].Length - 2);
            string xml2 = strArray4[2].Substring(0, strArray4[2].Length - 1).Substring(1, strArray4[2].Length - 2);
            string xml3 = strArray4[3].Substring(0, strArray4[3].Length - 1).Substring(1, strArray4[3].Length - 2);
            string[] xml2_chitiet = new string[] { "\"TenDichVu\":" };
            string[] xml2_ct = xml3.Split(xml2_chitiet, StringSplitOptions.None);
            string[] soluong = new string[] { "\"SoLuong\":" };
            string[] soluong_ct = xml3.Split(soluong, StringSplitOptions.None);
            string[] xml2_DVT = new string[] { "\"DonViTinh\":" };
            string[] xml2_DVT_ct = xml3.Split(xml2_DVT, StringSplitOptions.None);
            string[] xml2_DG = new string[] { "\"DonGia\":" };
            string[] xml2_DG_ct = xml3.Split(xml2_DG, StringSplitOptions.None);
            string[] xml2_ThanhTien = new string[] { "\"ThanhTien\":" };
            string[] xml2_ThanhTien_ct = xml3.Split(xml2_ThanhTien, StringSplitOptions.None);
            string[] xml2_NgayYl = new string[] { "\"NgayYl\":" };
            string[] xml2_NgayYl_ct = xml3.Split(xml2_NgayYl, StringSplitOptions.None);
            int numRows = fg_ChiPhi_1.Rows.Count;
            for (int i = 0; i < numRows - 1; i++)
            {
                int max = fg_ChiPhi_1.Rows.Count - 1;
                fg_ChiPhi_1.Rows.Remove(fg_ChiPhi_1.Rows[max]);

            }
            for (int i = 1; i <= xml2_ct.Length - 1; i++)
            {
                fg_ChiPhi_1.Rows.Add();
                fg_ChiPhi_1[fg_ChiPhi_1.Rows.Count - 1, 0] = i;
                fg_ChiPhi_1[fg_ChiPhi_1.Rows.Count - 1, 2] = xml2_DVT_ct[i].Substring(0, xml2_DVT_ct[i].IndexOf(','));
                fg_ChiPhi_1[fg_ChiPhi_1.Rows.Count - 1, 1] = xml2_ct[i].Substring(0, xml2_ct[i].IndexOf(','));
                fg_ChiPhi_1[fg_ChiPhi_1.Rows.Count - 1, 3] = soluong_ct[i].Substring(0, soluong_ct[i].IndexOf(','));
                fg_ChiPhi_1[fg_ChiPhi_1.Rows.Count - 1, 4] = xml2_DG_ct[i].Substring(0, xml2_DG_ct[i].IndexOf(','));
                fg_ChiPhi_1[fg_ChiPhi_1.Rows.Count - 1, 5] = xml2_ThanhTien_ct[i].Substring(0, xml2_ThanhTien_ct[i].IndexOf(','));
                fg_ChiPhi_1[fg_ChiPhi_1.Rows.Count - 1, 6] = chuyengay(xml2_NgayYl_ct[i].Substring(0, xml2_NgayYl_ct[i].IndexOf(',')));
            }
            fg_ChiPhi_1[0, 0] = "STT";
            fg_ChiPhi_1[0, 1] = "Tên Thuốc";
            fg_ChiPhi_1[0, 2] = "ĐVT";
            fg_ChiPhi_1[0, 3] = "Số Lượng";
            fg_ChiPhi_1[0, 4] = "Đơn Giá";
            fg_ChiPhi_1[0, 5] = "Thành Tiền";
            fg_ChiPhi_1[0, 6] = "Ngày Y Lệnh";
            fg_ChiPhi_1.AutoSizeCols(0);
            fg_ChiPhi_1.Redraw = true;
        }

        public void lichsukhamchuabenh_chitiet_XML1(string MAHOSO)
        {
            WebClient client = new WebClient();
            NameValueCollection values = new NameValueCollection();
            byte[] bytes = client.UploadValues(string.Format("Https://egw.baohiemxahoi.gov.vn/api/egw/nhanHoSoKCBChiTiet?maHoSo={4}&username={2}&password={3}&token={0}&id_token={1}", new object[] { Access_Token, IDToken, "36001_BV", "e10adc3949ba59abbe56e057f20f883e", MAHOSO }), values);
            string str = Encoding.UTF8.GetString(bytes);
            string[] separator = new string[] { "xml1\":", "Xml2\":", "Xml3\":", "Xml4\":", "Xml5\":" };
            string[] strArray4 = str.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            string xml1 = strArray4[1].Substring(0, strArray4[1].Length - 1).Substring(1, strArray4[1].Length - 2);
            string xml2 = strArray4[2].Substring(0, strArray4[2].Length - 1).Substring(1, strArray4[2].Length - 2);
            string xml3 = strArray4[3].Substring(0, strArray4[3].Length - 1).Substring(1, strArray4[3].Length - 2);
            string[] MaBn = new string[] { "\"MaBn\":" };
            string[] MaBn_ct = xml1.Split(MaBn, StringSplitOptions.None);
            string[] SoNgayDtri = new string[] { "\"SoNgayDtri\":" };
            string[] SoNgayDtri_ct = xml1.Split(SoNgayDtri, StringSplitOptions.None);
            string[] TThuoc = new string[] { "\"TThuoc\":" };
            string[] TThuoc_ct = xml1.Split(TThuoc, StringSplitOptions.None);
            string[] TVtyt = new string[] { "\"TVtyt\":" };
            string[] TVtyt_ct = xml1.Split(TVtyt, StringSplitOptions.None);
            string[] TTongchi = new string[] { "\"TTongchi\":" };
            string[] TTongchi_ct = xml1.Split(TTongchi, StringSplitOptions.None);
            string[] TBntt = new string[] { "\"TBntt\":" };
            string[] TBnttn_ct = xml1.Split(TBntt, StringSplitOptions.None);
            string[] TBhtt = new string[] { "\"TBhtt\":" };
            string[] TBhtt_ct = xml1.Split(TBhtt, StringSplitOptions.None);
            string[] Ngaythanhtoan = new string[] { "\"Ngaythanhtoan\":" };
            string[] Ngaythanhtoanl_ct = xml1.Split(Ngaythanhtoan, StringSplitOptions.None);

            string[] Ngayvao = new string[] { "\"NgayVao\":" };
            string[] Ngayvao_ct = xml1.Split(Ngayvao, StringSplitOptions.None);
            string[] NgayRa = new string[] { "\"NgayRa\":" };
            string[] NgayRa_ct = xml1.Split(NgayRa, StringSplitOptions.None);

            int numRows = fg_ChiPhi_1.Rows.Count;
            for (int i = 0; i < numRows - 1; i++)
            {
                int max = fg_ChiPhi_1.Rows.Count - 1;
                fg_ChiPhi_1.Rows.Remove(fg_ChiPhi_1.Rows[max]);

            }

            for (int i = 1; i <= MaBn_ct.Length - 1; i++)
            {
                fg_ChiPhi_1.Rows.Add();
                string ngaythanhtoan = Ngaythanhtoanl_ct[i].Substring(0, Ngaythanhtoanl_ct[i].IndexOf(','));
                string ngaythanhtoan_cu = ngaythanhtoan.Replace('"', ' ');
                string ngay = ngaythanhtoan_cu.Trim();
                fg_ChiPhi_1[fg_ChiPhi_1.Rows.Count - 1, 0] = ngay.Substring(6, 2) + "/" + ngay.Substring(4, 2) + "/" + ngay.Substring(0, 4) + "  " + ngay.Substring(8, 2) + ":" + ngay.Substring(10, 2); ;//Ngaythanhtoanl_ct[i].Substring(0, Ngaythanhtoanl_ct[i].IndexOf(','));
                fg_ChiPhi_1[fg_ChiPhi_1.Rows.Count - 1, 1] = SoNgayDtri_ct[i].Substring(0, SoNgayDtri_ct[i].IndexOf(','));
                fg_ChiPhi_1[fg_ChiPhi_1.Rows.Count - 1, 2] = TThuoc_ct[i].Substring(0, TThuoc_ct[i].IndexOf(','));
                fg_ChiPhi_1[fg_ChiPhi_1.Rows.Count - 1, 3] = TVtyt_ct[i].Substring(0, TVtyt_ct[i].IndexOf(','));
                fg_ChiPhi_1[fg_ChiPhi_1.Rows.Count - 1, 4] = TTongchi_ct[i].Substring(0, TTongchi_ct[i].IndexOf(','));
                fg_ChiPhi_1[fg_ChiPhi_1.Rows.Count - 1, 5] = TBnttn_ct[i].Substring(0, TBnttn_ct[i].IndexOf(','));
                fg_ChiPhi_1[fg_ChiPhi_1.Rows.Count - 1, 6] = TBhtt_ct[i].Substring(0, TBhtt_ct[i].IndexOf(','));
                string s = Ngayvao_ct[i].Substring(0, Ngayvao_ct[i].IndexOf(','));
                string a = s.Replace('"', ' ');
                string c = NgayRa_ct[i].Substring(0, NgayRa_ct[i].IndexOf(','));
                string d = c.Replace('"', ' ');
                string b = d.Trim();

                txtNgayVao.Text = a.Substring(6, 2) + "/" + a.Substring(4, 2) + "/" + a.Substring(0, 4) + "  " + a.Substring(8, 2) + ":" + a.Substring(10, 2);
                txtNgayRa.Text = b.Substring(6, 2) + "/" + b.Substring(4, 2) + "/" + b.Substring(0, 4) + "  " + b.Substring(8, 2) + ":" + b.Substring(10, 2);
            }
            fg_ChiPhi_1[0, 0] = "NGÀY TT";
            fg_ChiPhi_1[0, 1] = "NGÀY ĐT";
            fg_ChiPhi_1[0, 2] = "TIỀN THUỐC";
            fg_ChiPhi_1[0, 3] = "TIỀN VTYT";
            fg_ChiPhi_1[0, 4] = "THÀNH TIỀN";
            fg_ChiPhi_1[0, 5] = "TIỀN BỆNH NHÂN";
            fg_ChiPhi_1[0, 6] = "TIỀN BHXH";
            fg_ChiPhi_1.AutoSizeCols(0);
            fg_ChiPhi_1.Redraw = true;

        }
        public string Remove_Dau(string dau)
        {
            string s = dau.Replace('"', ' ');
            string b = s.Trim();
            return b;
        }

        public string chuyengay(string ngay)
        {
            string s = ngay.Replace('"', ' ');
            string b = s.Trim();
            string a = b.Substring(6, 2) + "/" + b.Substring(4, 2) + "/" + b.Substring(0, 4) + "  " + b.Substring(8, 2) + ":" + b.Substring(10, 2);
            return a;
        }
        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            lichsukhamchuabenh_chitiet_XML1("523572331");
        }


        private void frmLichSuDieuTri_Load(object sender, EventArgs e)
        {
            fg_ChiPhi_1.Cols[2].Format = "#,##0.##";
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
            cmbKhoa.Tag = "1";
            txtDKNgayRV.Tag = "0";
            txtDKNgayRV.Value = Global.NgayLV;
            txtDKNgayRV.Tag = "1";
            fgDanhSach.ClipSeparators = "|;";
            Global.SetCmb(cmbKhoa, Global.glbMaKhoaPhong);
            GlobalModuls.Global.SetCmb(cmbKhoa, Global.glbMaKhoaPhong);
            Load_DSBenhNhan();
            EnabledChuyenVien(false);
        }

        private void fg_ChiPhi_AfterRowColChange(object sender, C1.Win.C1FlexGrid.RangeEventArgs e)
        {

        }

        private void rdb_xml1_Click(object sender, EventArgs e)
        {
            if (txtMahoSo.Text == "")
            {
                MessageBox.Show("Chưa chọn hồ sơ để xem");
                return;
            }
            else
            {
                lichsukhamchuabenh_chitiet_XML1(txtMahoSo.Text);
                fg_ChiPhi_1.Redraw = true;
            }

        }


        private void rdb_xml2_Click(object sender, EventArgs e)
        {
            if (txtMahoSo.Text == "")
            {
                MessageBox.Show("Chưa chọn hồ sơ để xem");
                return;
            }
            lichsukhamchuabenh_chitiet(txtMahoSo.Text);
            fg_ChiPhi_1.Redraw = true;
        }

        private void rdb_xml3_Click(object sender, EventArgs e)
        {
            if (txtMahoSo.Text == "")
            {
                MessageBox.Show("Chưa chọn hồ sơ để xem");
                return;
            }

            lichsukhamchuabenh_chitiet_XML3(txtMahoSo.Text);
            fg_ChiPhi_1.Redraw = true;
        }

        private void rdb_xml2_CheckedChanged(object sender, EventArgs e)
        {


        }

        private void rdb_xml3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rdb_xml1_CheckedChanged(object sender, EventArgs e)
        {


        }

        private void fg_ChiPhi_Click(object sender, EventArgs e)
        {

            txtMahoSo.Text = fg_ChiPhi.GetDataDisplay(fg_ChiPhi.Row, "MaLk");
            if (txtMahoSo.Text == "")
            {
                MessageBox.Show("Chưa chọn hồ sơ để xem");
                return;
            }
            else
            {
                lichsukhamchuabenh_chitiet_XML1(txtMahoSo.Text);
                fg_ChiPhi_1.Redraw = true;
            }
            rdb_xml1.Checked = true; rdb_xml2.Checked = false; ; rdb_xml3.Checked = false; rdb_xml4.Checked = false;

        }

        private void rdChuaRV_CheckedChanged_1(object sender, EventArgs e)
        {

            if (rdChuaRV.Checked)
            {
                txtDKNgayRV.Visible = false;
            }
            else
            {
                txtDKNgayRV.Visible = true;
            }
            Load_DSBenhNhan();
        }

        public void lichsukhamchuabenh_chitiet_XML4(string MAHOSO)
        {
            WebClient client = new WebClient();
            NameValueCollection values = new NameValueCollection();
            byte[] bytes = client.UploadValues(string.Format("Https://egw.baohiemxahoi.gov.vn/api/egw/nhanHoSoKCBChiTiet?maHoSo={4}&username={2}&password={3}&token={0}&id_token={1}", new object[] { Access_Token, IDToken, "36001_BV", "e10adc3949ba59abbe56e057f20f883e", MAHOSO }), values);
            string str = Encoding.UTF8.GetString(bytes);
            string[] separator = new string[] { "xml1\":", "Xml2\":", "Xml3\":", "Xml4\":", "Xml5\":" };
            string[] strArray4 = str.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            string xml1 = strArray4[1].Substring(0, strArray4[1].Length - 1).Substring(1, strArray4[1].Length - 2);
            string xml2 = strArray4[2].Substring(0, strArray4[2].Length - 1).Substring(1, strArray4[2].Length - 2);
            string xml3 = strArray4[3].Substring(0, strArray4[3].Length - 1).Substring(1, strArray4[3].Length - 2);
            string xml4 = strArray4[4].Substring(0, strArray4[4].Length - 1).Substring(1, strArray4[4].Length - 2);
            string[] madichvu = new string[] { "\"MaDichVu\":" };
            string[] madichvu_ct = xml4.Split(madichvu, StringSplitOptions.None);
            string[] TenChiSo = new string[] { "\"TenChiSo\":" };
            string[] TenChiSo_ct = xml4.Split(TenChiSo, StringSplitOptions.None);
            string[] GiaTri = new string[] { "\"GiaTri\":" };
            string[] GiaTri_ct = xml4.Split(GiaTri, StringSplitOptions.None);
            string[] MoTa = new string[] { "\"MoTa\":" };
            string[] MoTa_ct = xml4.Split(MoTa, StringSplitOptions.None);
            string[] KetLuan = new string[] { "\"KetLuan\":" };
            string[] KetLuan_ct = xml4.Split(KetLuan, StringSplitOptions.None);
            string[] NgayKq = new string[] { "\"NgayKq\":" };
            string[] NgayKq_ct = xml4.Split(NgayKq, StringSplitOptions.None);
            int numRows = fg_ChiPhi_1.Rows.Count;
            for (int i = 0; i < numRows - 1; i++)
            {
                int max = fg_ChiPhi_1.Rows.Count - 1;
                fg_ChiPhi_1.Rows.Remove(fg_ChiPhi_1.Rows[max]);

            }
            
            for (int i = 1; i <= madichvu_ct.Length - 1; i++)
            {
                fg_ChiPhi_1.Rows.Add();
                fg_ChiPhi_1[fg_ChiPhi_1.Rows.Count - 1, 0] = i;
                fg_ChiPhi_1[fg_ChiPhi_1.Rows.Count - 1, 1] = Remove_Dau(TenChiSo_ct[i].Substring(0, TenChiSo_ct[i].IndexOf(',')));
                string s = GiaTri_ct[i];
                string[] mamay = new string[] { "\"MaMay\":" };
                string[] mamay_ct = s.Split(mamay, StringSplitOptions.None);
                fg_ChiPhi_1[fg_ChiPhi_1.Rows.Count - 1, 2] = Remove_Dau(mamay_ct[0]);

                string d = MoTa_ct[i];
                string[] d1 = new string[] { "\"KetLuan\":" };
                string[] mota_ct = d.Split(d1, StringSplitOptions.None);

                fg_ChiPhi_1[fg_ChiPhi_1.Rows.Count - 1, 3] = Remove_Dau(mota_ct[0]);//.Substring(0, MoTa_ct[i].IndexOf(','));

                fg_ChiPhi_1[fg_ChiPhi_1.Rows.Count - 1, 4] = Remove_Dau(KetLuan_ct[i].Substring(0, KetLuan_ct[i].IndexOf(',')));
                fg_ChiPhi_1[fg_ChiPhi_1.Rows.Count - 1, 6] = Remove_Dau(madichvu_ct[i].Substring(0, madichvu_ct[i].IndexOf(',')));
                fg_ChiPhi_1[fg_ChiPhi_1.Rows.Count - 1, 5] = chuyengay(NgayKq_ct[i].Substring(0, NgayKq_ct[i].IndexOf(',')));
            }
            fg_ChiPhi_1[0, 0] = "STT";
            fg_ChiPhi_1[0, 1] = "Tên Dịch Vụ";
            fg_ChiPhi_1[0, 2] = "Giá trị";
            fg_ChiPhi_1[0, 3] = "Mô Tả";
            fg_ChiPhi_1[0, 4] = "Kết LuậN";
            fg_ChiPhi_1[0, 5] = "Ngày Trả KQ";
            fg_ChiPhi_1[0, 6] = "Mã Dịch Vụ";
            fg_ChiPhi_1.AutoSizeCols(0);
            fg_ChiPhi_1.Cols[2].Format = "";
            fg_ChiPhi_1.Redraw = true;
        }

        private void rdb_xml4_Click(object sender, EventArgs e)
        {
            if (txtMahoSo.Text == "")
            {
                MessageBox.Show("Chưa chọn hồ sơ để xem");
                return;
            }
            lichsukhamchuabenh_chitiet_XML4(txtMahoSo.Text);
        }

        private void cmdGiayRaVien_Click(object sender, EventArgs e)
        {

        }
    }
}