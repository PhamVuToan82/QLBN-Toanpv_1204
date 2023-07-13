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
using System.Net;
//using System.Net.Http;
using System.Collections.Specialized;
using System.Xml;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;


namespace NamDinh_QLBN.Forms.DuLieu
{
    public partial class frmChiDinhDieuTri_BNSars : Form
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
        public DateTime _NgayChiDinh;
        public string _YLenh;
        public string _TenXml;
        public string _DaTinhPhi;
        public string _DaRaVien;
        private string MaDoiTuongBN = "", BackMaDoiTuongBN = "";
        private int LanChuyenDT =0;
        private int batnhap = 0;
        private string MaNhom = "";
        private bool IsAddnew = false;
        private bool bool_SoKet15Ngay = false;
        private string str_TruyenMau = "";
        DateTime NgayKham;
        public string _TenBuong = "";
        public string _TenGiuong = "";
        public string _SoHSBA = "";
        NamDinh_QLBN.Reports.rpt_ylenh rep;
        NamDinh_QLBN.Reports.Subrpt_ylenh_DienBien rdb;
        NamDinh_QLBN.Reports.Subrpt_ylenh_dieutri rdt;
        public int PhieuCovid;
        public string Is_Covid;
        //string FontBold1 = "font-weight: bold; font-size: 15.75pt;";
        public frmChiDinhDieuTri_BNSars()
        {
            InitializeComponent();
            
        }
        public static bool GetSession()
        {
            WebClient client = new WebClient();
            NameValueCollection values = new NameValueCollection();
            values.Add("username", "36001_BV");
            values.Add("password", "e10adc3949ba59abbe56e057f20f883e");
            try
            {
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

            }
            catch
            {
                //MessageBox.Show("Lỗi khi kết nối tới cổng BHXH");
                return false;
            }
            return false;
        }

        public void CheckTheBHYT(string MaThe, string HoTen, string NgaySinh, string GioiTinh, string MaCSKCB, string NgayBD, string NgayKT)
        {
            GetSession();
            WebClient client = new WebClient();
            NameValueCollection values = new NameValueCollection();
            values.Add("maThe", MaThe);
            values.Add("hoTen", HoTen);
            values.Add("ngaySinh", NgaySinh);
            values.Add("gioiTinh", GioiTinh);
            values.Add("maCSKCB", MaCSKCB);
            values.Add("ngayBD", NgayBD);
            values.Add("ngayKT", NgayKT);
            byte[] bytes = client.UploadValues(string.Format("https://egw.baohiemxahoi.gov.vn/api/egw/KQnhanLichSuKCB595?token={0}&id_token={1}&username={2}&password={3}", new object[] { Access_Token, IDToken, "36001_BV", "e10adc3949ba59abbe56e057f20f883e" }), values);
            string str = Encoding.UTF8.GetString(bytes);
            string[] separator = new string[] { "{\"maKetQua\":", ",\"dsLichSuKCB\":" };
            string[] strArray4 = str.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            MaKetQua = strArray4[0].Substring(0, strArray4[0].Length - 1).Substring(1, strArray4[0].Length - 2);
            strArray4[1] = strArray4[1].Substring(0, strArray4[1].Length - 1).Substring(1, strArray4[1].Length - 2);
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
            //string[] strArray3 = strArray4[1].Split(strArray, StringSplitOptions.RemoveEmptyEntries);
            //const char x2 = ',';
            const char x3 = '"';
            const char x4 = '}';
            const char x5 = '{';
            //   const char x6 = '';
            char[] delimiters = new char[] { x3, x4, x5 };
            string[] strArray3 = strArray4[1].Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            for (int j = 0; j <= strArray3.Length - 1; j++)
            {
                if (strArray3[j] == "maHoSo")
                {
                    string maHoSo = strArray3[j + 1];

                }
            }
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
            {
                string t3 = "Thẻ hết giá trị sử dụng"; MessageBox.Show(t3); return;
            };
            if (str3 == "051")
            {
                string t3 = "Mã thẻ không đúng"; MessageBox.Show(t3); return;
            };
            if (str3 == "052")
            {
                string t3 = "Mã tỉnh cấp thẻ (ký tự thứ 4,5 của mã thẻ) không đúng"; MessageBox.Show(t3); return;
            };
            if (str3 == "053")
            {
                string t3 = "Mã quyền lợi thẻ(Ký tự thứ 3 của mã thẻ) không đúng"; MessageBox.Show(t3); return;
            };
            if (str3 == "050")
            {
                string t3 = "Không thấy thông tin thẻ BHYT"; MessageBox.Show(t3); return;
            };
            if (str3 == "060")
            {
                string t3 = "Thẻ sai họ tên "; MessageBox.Show(t3); return;
            };
            if (str3 == "061")
            {
                string t3 = "Thẻ sai họ tên đúng ký tự đầu"; MessageBox.Show(t3); return;
            };
            if (str3 == "070")
            {
                string t3 = "Thẻ sai ngày sinh "; MessageBox.Show(t3); return;
            };
            if (str3 == "080")
            {
                string t3 = "Thẻ sai giới tính "; MessageBox.Show(t3); return;
            };
            if (str3 == "090")
            {
                string t3 = "Thẻ sai nơi đăng ký KCBBĐ "; MessageBox.Show(t3); return;
            };
            if (str3 == "100")
            {
                string t3 = "Lỗi khi lấy dữ liệu số thẻ "; MessageBox.Show(t3); return;
            };
            if (str3 == "101")
            {
                string t3 = "Lỗi server "; MessageBox.Show(t3); return;
            };
            if (str3 == "110")
            {
                string t3 = "Thẻ đã thu hồi "; MessageBox.Show(t3); return;
            };
            if (str3 == "120")
            {
                string t3 = "Thẻ đã báo giảm "; MessageBox.Show(t3); return;
            };
            if (str3 == "121")
            {
                string t3 = "Thẻ đã báo giảm. Giảm chuyển ngoại tỉnh "; MessageBox.Show(t3); return;
            };
            if (str3 == "122")
            {
                string t3 = "Thẻ đã báo giảm. Giảm chuyển nội tỉnh "; MessageBox.Show(t3); return;
            };
            if (str3 == "123")
            {
                string t3 = "Thẻ đã báo giảm. Thu hồi do tăng lại cùng đơn vị "; MessageBox.Show(t3); return;
            };
            if (str3 == "124")
            {
                string t3 = "Thẻ đã báo giảm. Ngừng tham gia "; MessageBox.Show(t3); return;
            };
        }


        private void SoTienConLai()
        {
            SqlCommand command = new SqlCommand();
            command.Connection = Global.ConnectSQL;
            try
            {
                command.CommandText = string.Format("SELECT SUM(ISNULL(C.SOLUONG,0) * ISNULL(C.DONGIA,0)) AS SOTIENDSD,AA.SOTIEN AS SOTIENKQ, ISNULL(AA.SOTIEN,0) - SUM(ISNULL(C.SOLUONG,0) * ISNULL(C.DONGIA,0)) AS SOTIENCL FROM  (BENHNHAN_CHITIET A INNER JOIN BENHNHAN_PHIEUDIEUTRI B ON A.MAVAOVIEN = B.MAVAOVIEN) INNER JOIN PHIEUDIEUTRI_CHITIET C ON B.SOPHIEU = C.SOPHIEU LEFT JOIN  (SELECT KQ_NT.MAVAOVIEN,SUM(KQ_NT.SOTIEN) AS SOTIEN FROM [" + Global.glbVienPhi + "].DBO.TBLTHUKYQUY KQ_NT WHERE KQ_NT.MAVAOVIEN = '{0}' GROUP BY MAVAOVIEN) AA ON AA.MAVAOVIEN = A.MAVAOVIEN WHERE A.MAVAOVIEN ='{0}' GROUP BY AA.SOTIEN", this.txtMaVaoVien.Text);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    this.lbSoTienCL.Text = string.Format("Số tiền c\x00f2n lại: {0:#,##0}", reader["SoTienCL"]) + " VNĐ";
                    this.lbSoTienKQ.Text = string.Format("Số tiền k\x00fd quỹ: {0:#,##0}", reader["SoTienkQ"]) + " VNĐ";
                }
                reader.Close();
            }
            catch
            {
            }
            finally
            {
                command.Dispose();
            }
        }
       
          bool  KiemTraDaCoHbA1C()
        {
            SqlCommand command = new SqlCommand();
            command.Connection = Global.ConnectSQL;
            try
            {
                command.CommandText = string.Format("select * from PHIEUDIEUTRI_CHITIET CT inner join BENHNHAN_PHIEUDIEUTRI PDT on CT.Sophieu = pdt.Sophieu where PDT.MAVAOVIEN  = '{0}' AND (CT.Madichvu = 'C50115' or CT.Madichvu = 'C50005')", this.txtMaVaoVien.Text);
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

        private void frmChiDinhDieuTri_Load(object sender, EventArgs e)
        {
            fgPhieuChiDinh.ClipSeparators = "|;";
            fgDichVu.Tree.Column = 4;
            fgDichVu.ClipSeparators = "|;";
            fgPhieuChiDinh.Cols["LoaiDT"].Visible = fgPhieuChiDinh.Cols["MaKhoa"].Visible = false;
            fgDichVu.Cols["LoaiDichVu"].Visible = fgDichVu.Cols["MaDichVu"].Visible = fgDichVu.Cols["TenLoaiDV"].Visible = false;
            fgDichVu.Cols["SoLuong"].Format = "#,##0.##";
            fgDichVu.Cols["DonGia"].Format = "#,##0.##";
            fgDichVu.Cols["GiaVP"].Format = "#,##0.##";
            fgDichVu.Cols["GiaBHYT"].Format = "#,##0.##";
            fgDichVu.Cols["SoLuongCu"].Format = "#,##0.##";
            fgDichVu.Cols["SoLuongCu"].DataType = typeof(Decimal);
            for (int i = 0; i < fgDichVu.Cols.Count; i++)
            {
                if (fgDichVu.Cols[i].Name != "SoLuong"  && fgDichVu.Cols[i].Name != "GhiChu" && fgDichVu.Cols[i].Name != "DonGia" && fgDichVu.Cols[i].Name != "TyLe") fgDichVu.Cols[i].AllowEditing = false;
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
            fgDichVu.Cols["GiaVP"].Visible = true;
            fgDichVu.Cols["GiaBHYT"].Visible = true;
            fgDichVu.Cols["isPhieudieutri_chitiet_covid"].Visible = true;
            fgDichVu.Cols["isT_Khac_CT"].Visible = true;
            fgDichVu.Cols["NguonT_Khac_CT"].Visible = true;
            fgDichVu.Cols["isVienTro_CT"].Visible = true;

        }
        private void Load_CacDM()
        {
            SqlCommand command = new SqlCommand();
            command.Connection = Global.ConnectSQL;
            command.CommandText = "SELECT * FROM DMKHOAPHONG WHERE MaKhoa IN " + Global.glbKhoa_CapNhat;
            SqlDataReader reader = command.ExecuteReader();
            this.cmbKhoa.Tag = "0";
            this.cmbKhoa.ClearItems();
            while (reader.Read())
            {
                this.cmbKhoa.AddItem(string.Format("{0};{1}", reader["MaKhoa"], reader["TenKhoa"]));
            }
            this.cmbKhoa.SelectedIndex = 0;
            this.cmbKhoa.Tag = "1";
            if (this.cmbKhoa.ListCount > 0)
            {
                this.cmbKhoa.SelectedIndex = 0;
            }
            reader.Close();
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
            this.cmbDoiTuong.AddItem("0;----- Theo đối tượng hiện tại -----");
            while (reader.Read())
            {
                this.cmbDoiTuong.AddItem(string.Format("{0};{1}", reader["MaDT"], reader["TenDT"]));
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

            command.CommandText = "Select MaBS,TenBS,SoChungChiHanhNghe,TenBS from dmbacsy where SoChungChiHanhNghe is not null and SoChungChiHanhNghe <> '' and Khongsudung = 0 and MaChucVu <=5 and MaChucVu <> '' and makhoa  in " + Global.glbKhoa_CapNhat ;
                //command.CommandText = "Select * from dmbacsy where Khongsudung = 0 and makhoa  in " + Global.glbKhoa_CapNhat + " order by Thutu";
                reader = command.ExecuteReader();
                this.cmbBacSyDT.ClearItems();
                while (reader.Read())
                {
                    this.cmbBacSyDT.AddItem(string.Format("{0};{1};{2};{3}", reader["MaBS"], reader["TenBS"], reader["SoChungChiHanhNghe"], reader["TenBS"]));
                }
                reader.Close();
            
           

            command.CommandText = "Select * from dmbacsy where Machucvu in('6','7') and Khongsudung = 0 and makhoa  in " + Global.glbKhoa_CapNhat + " order by Thutu";
            //command.CommandText = "Select * from dmbacsy where Khongsudung = 0 and makhoa  in " + Global.glbKhoa_CapNhat + " order by Thutu";
            reader = command.ExecuteReader();
            this.cmbDieuduong.ClearItems();
            while (reader.Read())
            {
                this.cmbDieuduong.AddItem(string.Format("{0};{1}", reader["MaBS"], reader["TenBS"]));
            }
            cmbDieuduong.SelectedIndex = -1;
            reader.Close();
            command.CommandText = "select Madichvu from DMDICHVU where tendichvu like N'%Viện HHTMTW%' and DongiaBHYT > 0";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                str_TruyenMau += reader["Madichvu"] + "; ";
            }
            reader.Close();
            this.cmbNhomMau.AddItem("0;Chưa x\x00e1c định");
            this.cmbNhomMau.AddItem("1;A");
            this.cmbNhomMau.AddItem("2;AB");
            this.cmbNhomMau.AddItem("3;B");
            this.cmbNhomMau.AddItem("4;O");
            command.Dispose();
        }

        private void button1_Click(object sender, EventArgs e) // danh sach benh nhan click
        {
            int covid = 1;
            if (this.cmbKhoa.SelectedIndex == -1)
            {
                MessageBox.Show("Chưa chọn khoa điều trị!", "Th\x00f4ng b\x00e1o", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                this.cmbKhoa.Focus();
            }
            else
            {
                txtTenICD_KhoaDieuTri_BC.Text = "";
                txtTenICD_KhoaDieuTri_BP_1.Text = "";
                frmShowDSBenhNhan nhan = new frmShowDSBenhNhan("", Global.GetCode(this.cmbKhoa), "", 1, 0, this.MaNhom, covid);
                nhan.ShowDialog();
                if (nhan.DialogResult == DialogResult.OK)
                {
                    this.txtMaBenhAn.Text = nhan.SoHSBAReturn;
                    this.txtMaVaoVien.Text = nhan.MaVaoVienReturn;
                    this.txtHoTen.Text = nhan.HoTenReturn;
                    this.txtTuoi.Text = nhan.TuoiReturn;
                    this.txtGioi.Text = nhan.GioiReturn;
                    this.txtDoiTuong.Text = nhan.TenDoiTuongReturn;
                    this.txtNgayVaoVien.Text = nhan.NgayVaoVienReturn;
                    NgayKham = nhan.NgayKhamReturn;
                    _TenBuong = nhan.TenBuongReturn;
                    _TenGiuong = nhan.TenGiuongReturn;
                    _SoHSBA = nhan.SoHSBAReturn;
                    this.BackMaDoiTuongBN = this.MaDoiTuongBN = nhan.MaDoiTuongReturn;
                    this.cmbBacSyDT.SelectedIndex = this.cmbBacSyDT.FindStringExact("0" + nhan.MabacSY, 0, 0);
                    this.MaNhom = nhan.MaNhom;
                    this.lblTenNhom.Text = nhan.TenNhom;
                    this._DaTinhPhi = nhan.DaTinhPhiReturn;
                    this._DaRaVien = string.Format("{0}", nhan.DaRaVienReturn);
                    txtMaICD_BenhChinh.Text = nhan.MaICDBCReturn;
                    txtMaICD_BenhPhu_1.Text = nhan.MAICDBP_1Return;
                    this.Load_PhieuChiDinh(this.txtMaVaoVien.Text);
                    LoadDSLanSoKet(txtMaVaoVien.Text);
                    this.LanChuyenDT = Global.GetLanChuyenDTHT(this.txtMaVaoVien.Text);
                    lblcovid.Text = nhan.is_covidReturn;
                    lblBuong.Text = nhan.TenBuongReturn; lblGiuong.Text = nhan.TenGiuongReturn; lblMaGiuongYT.Text = nhan.MaGiuongYTReturn;
                }
            }
        }

        private void Load_PhieuChiDinh(string MaVaoVien)
        {
            SqlCommand command = new SqlCommand("", Global.ConnectSQL);
            command.CommandText = "SELECT [SoPhieu], a.MaVaoVien, [NgayChiDinh], [LoaiDT], isnull(BacSyDT,SYSUSER.TenDu) as BacSyDT, [DienBienBenh], [YLenh], [CDChamSoc], [CDDinhDuong], a.MaKhoa, [Nhom], a.ChanDoan, a.CapCuu, a.mabs, [NhomMau], [SoThang],[ChuThich], isnull(UserName1,SYSUSER.UName) as UserName1, a.Is_In, a.DaThucHien, a.MaPhieuCanQuang, [CCHN_NT], [isPhieudieutri_Covid] as bo,isnull(a.UserName1,cd.NhanvienCD) as UN,case when a.Nhom = 0 then N'Trong ngày' else N'Bất thường' end as Nhom1, tenKhoa,isnull(dmbacsy.tenbs,SYSUSER.TenDu) as tenbs,case when a.chandoan <> '' then a.chandoan else  viewkhoahientai.ChanDoan end Doan, a.isPhieudieutri_Covid  FROM BENHNHAN_PHIEUDIEUTRI a INNER JOIN DMKHOAPHONG b ON a.MaKhoa=b.MaKhoa  inner join viewkhoahientai on viewkhoahientai.mavaovien = a.mavaovien left join dmbacsy on dmbacsy.makhoa = a.makhoa and dmbacsy.mabs = a.mabs  left join NAMDINH_KHAMBENH.dbo.tblKHAMBENH_CHIDINH cd on cd.MaphieuCD = a.SoPhieu left join NAMDINH_SYSDB.dbo.SYSUSER on SYSUSER.KhoaPhong= cd.KhoaCD and SYSUSER.UName= cd.NhanvienCD and cd.SoCCHN= SYSUSER.CCHN WHERE a.MaVaoVien='" + MaVaoVien + "' and isDelete is null order by NgayChiDinh";
            SqlDataReader reader = command.ExecuteReader();
            this.fgPhieuChiDinh.Tag = "0";
            this.fgPhieuChiDinh.Rows.Count = 1;
            while (reader.Read())
            {
              fgPhieuChiDinh.AddItem(string.Format("{0}|{1}|{2:dd/MM/yyyy HH:mm}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}|{12}|{13}|{14}|{15}|{16}|{17}|{18}|", new object[] {
                fgPhieuChiDinh.Rows.Count, reader["SoPhieu"], reader["NgayChiDinh"], reader["LoaiDT"], reader["BacSyDT"], reader["DienBienBenh"], reader["YLenh"], reader["CDChamSoc"], reader["CDDinhDuong"], reader["MaKhoa"], reader["tenKhoa"], reader["Nhom"], reader["Doan"], reader["CapCuu"], reader["Nhom1"],
            reader["NhomMau"], reader["UN"],reader["isPhieudieutri_Covid"],reader["CCHN_NT"]
            }));
            }
            this.fgPhieuChiDinh.Row = 0;
            this.fgPhieuChiDinh.AutoSizeCols(1);
            if(_DaTinhPhi != "1")
             { this.Empty_Data();
                cmdThem.Enabled = true;
                cmdSua.Enabled = true;
                cmdXoa.Enabled = true;
            }
            if(_DaRaVien != "1")
            {
                this.Empty_Data();
                cmdThem.Enabled = true;
                cmdSua.Enabled = true;
                cmdXoa.Enabled = true;
            }
            if(_DaTinhPhi == "1" || _DaRaVien == "1")
            {
                this.Empty_Data();
                cmdThem.Enabled = false;
                cmdSua.Enabled = false;
                cmdXoa.Enabled = false;
            }
            this.fgPhieuChiDinh.AutoSizeCols();
            this.fgPhieuChiDinh.Tag = "1";
            this.fgPhieuChiDinh.AutoSizeCols();
            reader.Close();
            command.Dispose();
            this.SoTienConLai();

            for(int i = 0;i<fgPhieuChiDinh.Rows.Count; i++)
            {
                if (fgPhieuChiDinh.GetDataDisplay(i, "isPhieudieutri_Covid") == "1")
                {
                    fgPhieuChiDinh.Rows[i].StyleNew.BackColor = Color.YellowGreen;
                }
                if (fgPhieuChiDinh.GetDataDisplay(i, "isPhieudieutri_Covid") == "0")
                {
                    fgPhieuChiDinh.Rows[i].StyleNew.BackColor = Color.White;
                }
               
            }
            
        }
        private void LoadDSLanSoKet(string MaVaoVien)
        {
            bool_SoKet15Ngay = false;
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            SQLCmd.CommandText = String.Format("Select  LanSoKet from tblSOKET15NGAY where MaVaoVien = '" + MaVaoVien + "'");
            dr = SQLCmd.ExecuteReader();
            while (dr.Read())
            {
                 bool_SoKet15Ngay = true;
            }
            dr.Close();
        }
        private void cmdThoat_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
        private void Lock_Edit(bool IsLocked)
        {
            this.cmdThuThuat.Visible = this.cmdKetQuaXN.Visible = btnPrintGiaoThuoc.Visible = this.cmdTichKe.Visible = this.cmdMo.Visible = this.cmdHoiChan.Visible = this.cmdMau.Visible = this.cmdDonThuoc.Visible = this.cmdKhamChuyenKhoa.Visible = this.cmdThem.Visible = this.cmdSua.Visible = this.cmdXoa.Visible = this.cmdThoat.Visible = this.cmdInPhieu.Visible=this.button2.Visible = IsLocked;
            this.cmdChiDinhTheoMatBenh.Visible = this.cmdGhi.Visible = this.cmdHuy.Visible = this.cmdChiDinh.Visible = this.cmdCopy.Visible= cmdGhi.Enabled = !IsLocked;
            this.cmdDanhSachBN.Enabled = IsLocked;
            this.raChiPhiHN.Enabled = this.raChiPhiTT.Enabled = IsLocked;
            this.chCapCuu.Enabled = IsLocked;
            this.fgPhieuChiDinh.Enabled = IsLocked;
            this.fgDichVu.Cols["SoLuong"].AllowEditing = !IsLocked;
            //this.fgDichVu.Cols["KhongTinhPhi"].AllowEditing = !IsLocked;
            this.cmbBacSyDT.Enabled = !IsLocked;
            if (!IsLocked)
            {
                this.fgDichVu.ContextMenuStrip = this.contextMenuNhapLieu;
            }
            else
            {
                this.fgDichVu.ContextMenuStrip = null;
            }
            this.fgDichVu.AllowDelete = !IsLocked;
            this.cmbCheDoChamSoc.ReadOnly = this.cmbCheDoDinhDuong.ReadOnly = IsLocked;
            this.txtNgayChiDinh.ReadOnly = IsLocked;
            this.cmbNhomMau.ReadOnly = this.cmbBacSyDT.ReadOnly = this.txtDienBienBenh.ReadOnly = this.richTextBox1.ReadOnly = this.cmbDoiTuong.ReadOnly = this.txtChanDoan.ReadOnly = IsLocked;
        }

        private void Empty_Data()
        {
            txtNgayChiDinh.Value = null;
            cmbCheDoChamSoc.SelectedIndex = cmbCheDoDinhDuong.SelectedIndex = -1;
            txtDienBienBenh.Text = richTextBox1.Text = txtChanDoan.Text = "";
            fgDichVu.Rows.Count = 1;
            cmbDieuduong.SelectedIndex = -1;
        }
        private void cmdThem_Click(object sender, EventArgs e)
        {
            if (lblcovid.Text != "1")
            {
                MessageBox.Show("Bệnh nhân không phải covid");
                return;
            }
           
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
            System.Data.SqlClient.SqlDataReader dr1;
            if ((GetSession()))
            {
                SQLCmd.CommandText = String.Format(" SELECT DT.maDoiTuongBHXH+ DT.SoThe AS BHYT, a.HoTen, a.NamSinh,CASE a.GioiTinh WHEN  0 THEN 2 ELSE 1 END AS GT,dt.MaNoiCap,KB.THOIGIANDANGKY,B.NgayVaoVien "
                 + " FROM (BENHNHAN A INNER JOIN BENHNHAN_CHITIET B ON A.MABENHNHAN = B.MABENHNHAN) "
                 + " INNER JOIN BENHNHAN_DOITUONG DT ON dt.MaVaoVien = b.MaVaoVien and DT.DoiTuong = 1 "
                 + " INNER JOIN NAMDINH_KHAMBENH.DBO.TBLKHAMBENH KB ON KB.MAKHAMBENH = B.MAKHAMBENH "
                 + " where B.MaVaoVien = '{0}'", txtMaVaoVien.Text);
                dr1 = SQLCmd.ExecuteReader();
                if (dr1.HasRows)
                {
                    while (dr1.Read())
                    {
                        string ngayra = string.Format("{0:dd/MM/yyyy}", DateTime.Parse(dr1["NgayVaoVien"].ToString()));
                        string ngayvao = string.Format("{0:dd/MM/yyyy}", DateTime.Parse(dr1["THOIGIANDANGKY"].ToString()));
                        CheckTheBHYT(dr1["BHYT"].ToString(), dr1["HoTen"].ToString(), dr1["NamSinh"].ToString(), dr1["GT"].ToString(), dr1["MaNoiCap"].ToString(), ngayra, ngayvao);
                    }
                }
                dr1.Close();
                dr1.Dispose();
            }
            SQLCmd.CommandText = string.Format("SELECT * from NAMDINH_QLBN.dbo.BENHNHAN_CHITIET where mavaovien = '{0}' and daravien = 1", txtMaVaoVien.Text);
            dr1 = SQLCmd.ExecuteReader();
            if(dr1.HasRows)
            {
                MessageBox.Show("Bệnh nhân đã ra viện", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                dr1.Close();
                return;
            }
            dr1.Close();
            TimeSpan Time = (Global.NgayLV - DateTime.Parse(txtNgayVaoVien.Text));
            //if ((DateAndTime.DateDiff(DateInterval.Day, Global.NgayLV, DateTime.Parse(txtNgayVaoVien.Text), FirstDayOfWeek.System, FirstWeekOfYear.System) >= 15) && (bool_SoKet15Ngay == false))
            if ((Time.Days >= 15) && (bool_SoKet15Ngay == false) && (Global.GetCode(cmbKhoa)!= "NV120101"))
            {
                MessageBox.Show("Phải nhập sơ kết 15 ngày trước khi chỉ định.", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
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
            cmbBacSyDT.SelectedIndex = 0;
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
            if (chk_Covid.Checked == true)
            {
                PhieuCovid = 1;
            }
            else
            {
                PhieuCovid = 0;
            }
        }

        private void cmdHuy_Click(object sender, EventArgs e)
        {
            this.Lock_Edit(true);
            if (this.fgPhieuChiDinh.Row < 1)
            {
                this.Empty_Data();
            }
            else
            {
                this.Load_PhieuDieutri_ChiTiet(this.fgPhieuChiDinh.Row);
            }
        }


        private void cmdGhi_Click(object sender, EventArgs e)
        {
            bool SGOT_SGPT   = false;
            bool CHOTP_TRI = false;
            bool HDL_LDL = false;
            bool BILTP_BILTT = false;
            bool SinhHoaMau = false;
            bool SinhHoaNuocTieu = false;
            bool MienDich = false;
            string SoTheBHYT = "";
            string madichvu_kiemtra = "";
            string Kiemtra_ICD = "";
            string maDoiTuongBHXH = "";
            string Icd10_Chinh = txtMaICD_BenhChinh.Text;
            string Icd10_phu = txtMaICD_BenhPhu_1.Text;
            string DichVuKhongCapCuu = "C50012,C50013,C50014,C50015,C50115,C50005,C50029,C50030,C50031,C50032,C50033,C50026,C50075,C50076,C50078,C50080,C50097,C50028,C50077,C50027,C50079";
            string DichVuSinhHoaMau = "C50001,C50002,C50004,C50008,C50009,C50003,C50130,C50012,C50013,C50014,C50015,C50010,C50011,C50113,C50073,C50006,C50072,C50018,C50020,C50021,C50022,C50023,C50025,C50095,C50096,C50115,C50005,C50119,C50313,C50138,C50314,C50323";
            string DichVuSinhHoaNuocTieu = "C50042,C50081,C50082,C50085,C50088,C50089,C50090,C50091,C50092,C50098,C50052,C50064,C50065,C50069,C50070";
             
            string DichVuMienDich = "C50075,C50026,C50027,C50028,C50029,C50030,C50031,C50032,C50033,C50078,C50080,C50133,C50134,C50135,C50137,C58000,C58001,C50136";
            
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
            System.Data.SqlClient.SqlDataReader dr;
 
            if (this.cmbBacSyDT.SelectedIndex == -1 && fgPhieuChiDinh[fgPhieuChiDinh.Row,"SoPhieu"].ToString().Substring(0,2)=="NT")
            {
                MessageBox.Show("Chưa nhập bác sĩ điều trị.\nĐề nghị nhập lại!", "Th\x00f4ng b\x00e1o", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                this.cmbBacSyDT.Focus();
                return;
            }

            //if((this.cmbDoiTuong.SelectedIndex == 0))
            //{
            //    MessageBox.Show("Chưa chọn đối tượng .\nĐề nghị nhập lại!", "Th\x00f4ng b\x00e1o", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            //    this.cmbDoiTuong.Focus();
            //    return;
            //}
            cmd.CommandText = String.Format("set dateformat dmy select b.NgayChuyen as thoigiandangky,a.DaRaVien from BENHNHAN_CHITIET a inner join NAMDINH_QLBN.dbo.BENHNHAN_KHOA b on a.MaVaoVien = b.MaVaoVien"
            + " where a.mavaovien = '{0}' and b.lanchuyenkhoa = 0 ", txtMaVaoVien.Text);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                DateTime thoigiandt = DateTime.Parse(dr["ThoiGianDangKy"].ToString());
                //if (this.txtNgayChiDinh.ValueIsDbNull || DateTime.Compare((DateTime)DateTime.Parse(txtNgayChiDinh.Text), (DateTime)thoigiandt) <= 0)
                //{
                //    MessageBox.Show(string.Format("Ngày giờ chỉ định >= Thời gian nhập viện ({0:dd/MM/yyyy HH:mm}).\nĐề nghị nhập lại!", DateTime.Parse(dr["ThoiGianDangKy"].ToString())), "Th\x00f4ng b\x00e1o", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                //    txtNgayChiDinh.Focus();
                //    dr.Close();
                //    cmd.Dispose();
                //    return;
                //}
                if(dr["DaRaVien"].ToString() == "1")
                {
                    MessageBox.Show("Bệnh nhân đã ra viện không được chỉ định thêm");
                    dr.Close();
                    return;
                }
            }
            dr.Close();
            cmd.Dispose();

            cmd.CommandText = String.Format("select D.SoThe,D.maDoiTuongBHXH from BENHNHAN_CHITIET A  INNER JOIN BENHNHAN_PHIEUDIEUTRI B ON A.MAVAOVIEN = B.MAVAOVIEN  INNER JOIN PHIEUDIEUTRI_CHITIET C ON C.SoPhieu = B.SoPhieu INNER JOIN BENHNHAN_DOITUONG D ON D.MAVAOVIEN = A.MAVAOVIEN AND D.DOITUONG = 1 "
             + " where A.mavaovien = '{0}' and c.madichvu in('C50005','C50137')", txtMaVaoVien.Text);
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    SoTheBHYT = dr["SoThe"].ToString();
                    maDoiTuongBHXH = dr["maDoiTuongBHXH"].ToString();
                }
                dr.Close();
                cmd.Dispose();
                if (SoTheBHYT != "")
                {
                    cmd.CommandText = String.Format("select b.NgayChiDinh,c.MaDichvu from BENHNHAN_CHITIET A  INNER JOIN BENHNHAN_PHIEUDIEUTRI B ON A.MAVAOVIEN = B.MAVAOVIEN  INNER JOIN PHIEUDIEUTRI_CHITIET C ON C.SoPhieu = B.SoPhieu  INNER JOIN BENHNHAN_DOITUONG D ON D.MAVAOVIEN = A.MAVAOVIEN AND D.DOITUONG = 1 WHERE c.madichvu in('C50005','C50137')  and  D.SoThe = '{0}' and  D.maDoiTuongBHXH  = '{1}' and ngaychidinh = (select  Max(NgayChiDinh) from BENHNHAN_CHITIET A  INNER JOIN BENHNHAN_PHIEUDIEUTRI B ON A.MAVAOVIEN = B.MAVAOVIEN  INNER JOIN PHIEUDIEUTRI_CHITIET C ON C.SoPhieu = B.SoPhieu  INNER JOIN BENHNHAN_DOITUONG D ON D.MAVAOVIEN = A.MAVAOVIEN AND D.DOITUONG = 1 WHERE c.madichvu in('C50005','C50137') and D.SoThe = '{0}' and  D.maDoiTuongBHXH  = '{1}')", SoTheBHYT, maDoiTuongBHXH);
                    dr = cmd.ExecuteReader();
                    int num1;
                    while (dr.Read())
                    {
                        if (dr["NgayChidinh"].ToString() == "")
                        {
                            continue;
                        }
                        else
                        {
                            TimeSpan Time = (DateTime.Parse(txtNgayChiDinh.Text) - DateTime.Parse(dr["NgayChidinh"].ToString()));
                            for (num1 = 1; num1 < this.fgDichVu.Rows.Count; num1++)
                            {
                                if(IsAddnew)
                                {
                                    if ((Time.Days <= 85) && (this.fgDichVu.GetDataDisplay(num1, "MaDichVu") == "C50005") && (this.fgDichVu.GetDataDisplay(num1, "MaDichVu") == dr["MaDichVu"].ToString()))
                                    {
                                        MessageBox.Show("Bệnh nhân này đã làm xét nghiệm HbA1C trong vòng 85 ngày  " + dr["NgayChidinh"].ToString() + " , đề nghị bạn xem lại.", "Th\x00f4ng b\x00e1o", MessageBoxButtons.OK);
                                        dr.Close();
                                        cmd.Dispose();
                                        return;
                                    }
                                    if ((Time.TotalHours >= 0) && (Time.TotalHours <= 24) && (this.fgDichVu.GetDataDisplay(num1, "MaDichVu") == "C50137") && (this.fgDichVu.GetDataDisplay(num1, "MaDichVu") == dr["MaDichVu"].ToString()))
                                    {
                                        MessageBox.Show("Bệnh nhân này đã làm xét nghiệm (Định lượng Pro-calcitonin [Máu]) trong vòng 1 ngày  " + dr["NgayChidinh"].ToString() + " , đề nghị bạn xem lại.", "Th\x00f4ng b\x00e1o", MessageBoxButtons.OK);
                                        dr.Close();
                                        cmd.Dispose();
                                        return;
                                    }
                                }
                                else
                                {
                                    if(DateTime.Parse(txtNgayChiDinh.Text) != DateTime.Parse(dr["NgayChidinh"].ToString()))
                                    {
                                        if ((Time.Days <= 85) && (this.fgDichVu.GetDataDisplay(num1, "MaDichVu") == "C50005") && (this.fgDichVu.GetDataDisplay(num1, "MaDichVu") == dr["MaDichVu"].ToString()))
                                        {
                                            MessageBox.Show("Bệnh nhân này đã làm xét nghiệm HbA1C trong vòng 85 ngày  " + dr["NgayChidinh"].ToString() + " , đề nghị bạn xem lại.", "Th\x00f4ng b\x00e1o", MessageBoxButtons.OK);
                                            dr.Close();
                                            cmd.Dispose();
                                            return;
                                        }
                                        if ((Time.TotalHours >= 0) && (Time.TotalHours <= 24) && (this.fgDichVu.GetDataDisplay(num1, "MaDichVu") == "C50137") && (this.fgDichVu.GetDataDisplay(num1, "MaDichVu") == dr["MaDichVu"].ToString()))
                                        {
                                            MessageBox.Show("Bệnh nhân này đã làm xét nghiệm (Định lượng Pro-calcitonin [Máu]) trong vòng 1 ngày  " + dr["NgayChidinh"].ToString() + " , đề nghị bạn xem lại.", "Th\x00f4ng b\x00e1o", MessageBoxButtons.OK);
                                            dr.Close();
                                            cmd.Dispose();
                                            return;
                                        }
                                    }
                                }
                            }
                        };
                    }
                    dr.Close();
                    cmd.Dispose();
                }
            }
            dr.Close();
            cmd.Dispose();

            if (this.cmbDoiTuong.SelectedIndex == -1)
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

                String LoaiDichVu1 = "";
                for (num = 1; num < this.fgDichVu.Rows.Count; num++)
                {

                    String LoaiDichVu2 = "";

                    //if(this.fgDichVu.GetDataDisplay(num, "DaDuyet") == "1" && (this.fgDichVu.GetDataDisplay(num, "LoaiDichVu") == "D01"))
                    //{
                    //    MessageBox.Show("Thuốc  " + Environment.NewLine + this.fgDichVu.GetDataDisplay(num, "TenDichVu") + " Đã được duyệt!", "Th\x00f4ng b\x00e1o", MessageBoxButtons.OK);
                    //    return;
                    //}
                    //if (this.fgDichVu.GetDataDisplay(num, "DuyetHoan") == "1" && (this.fgDichVu.GetDataDisplay(num, "LoaiDichVu") == "D01"))
                    //{
                    //    MessageBox.Show("Thuốc  " + Environment.NewLine + this.fgDichVu.GetDataDisplay(num, "TenDichVu") + " Đã được hoàn!", "Th\x00f4ng b\x00e1o", MessageBoxButtons.OK);
                    //    return;
                    //}
                    //Xét nghiệm giải phẫu phải có ghi chú
                    if ((this.fgDichVu.GetDataDisplay(num, "LoaiDichVu") == "C56") && (this.fgDichVu.GetDataDisplay(num, "GhiChu").Trim() == ""))
                    {
                        MessageBox.Show("Phải nhập bộ phận cần sinh thiết v\x00e0o phần ghi ch\x00fa của chỉ định: " + Environment.NewLine + this.fgDichVu.GetDataDisplay(num, "TenDichVu"), "Th\x00f4ng b\x00e1o", MessageBoxButtons.OK);
                        return;
                    }
                    if ((this.fgDichVu.GetDataDisplay(num, "LoaiDichVu") == "C54")|| (this.fgDichVu.GetDataDisplay(num, "LoaiDichVu") == "C57") || (this.fgDichVu.GetDataDisplay(num, "LoaiDichVu") == "C59") || (this.fgDichVu.GetDataDisplay(num, "LoaiDichVu") == "C60") || (this.fgDichVu.GetDataDisplay(num, "LoaiDichVu") == "C61") || (this.fgDichVu.GetDataDisplay(num, "LoaiDichVu") == "C62"))
                    {
                        LoaiDichVu1 = fgDichVu.GetDataDisplay(num, "LoaiDichVu");
                        for (int i = num; i < this.fgDichVu.Rows.Count; i++)
                        {
                            if (fgDichVu.GetDataDisplay(i, "LoaiDichVu") != "" && ((this.fgDichVu.GetDataDisplay(i, "LoaiDichVu") == "C54") || (this.fgDichVu.GetDataDisplay(i, "LoaiDichVu") == "C57") || (this.fgDichVu.GetDataDisplay(i, "LoaiDichVu") == "C59") || (this.fgDichVu.GetDataDisplay(i, "LoaiDichVu") == "C60") || (this.fgDichVu.GetDataDisplay(i, "LoaiDichVu") == "C61") || (this.fgDichVu.GetDataDisplay(i, "LoaiDichVu") == "C62"))) 
                            {

                                LoaiDichVu2 = fgDichVu.GetDataDisplay(i, "LoaiDichVu");
                                if (LoaiDichVu1 != LoaiDichVu2)
                                {
                                    MessageBox.Show("Không được chỉ định loại dich vụ " + Environment.NewLine + fgDichVu.GetDataDisplay(num, "TenLoaiDV") + " \nChung  với loại dịch vụ: \n" + fgDichVu.GetDataDisplay(i, "TenLoaiDV"), "Th\x00f4ng b\x00e1o", MessageBoxButtons.OK);
                                    return;
                                }

                            }
                        }
                        //return;
                    }

                    if (((this.fgDichVu.GetDataDisplay(num, "Madichvu") == "C03891")|| (this.fgDichVu.GetDataDisplay(num, "Madichvu") == "C03895")||(this.fgDichVu.GetDataDisplay(num, "Madichvu") == "C03894")||(this.fgDichVu.GetDataDisplay(num, "Madichvu") == "C03893")||(this.fgDichVu.GetDataDisplay(num, "Madichvu") == "C03892")) && (this.fgDichVu.GetDataDisplay(num, "SoLuong").Trim() != "1"))
                    {
                        MessageBox.Show("Phải nhập số lượng = 1 " + Environment.NewLine + this.fgDichVu.GetDataDisplay(num, "TenDichVu"), "Th\x00f4ng b\x00e1o", MessageBoxButtons.OK);
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
                    if ((this.fgDichVu.GetDataDisplay(num, "MaDichVu") == "C50008") || (this.fgDichVu.GetDataDisplay(num, "MaDichVu") == "C50009") ) SGOT_SGPT = !SGOT_SGPT;  // Nếu có SGOT, SGPT
                    if ((this.fgDichVu.GetDataDisplay(num, "MaDichVu") == "C50012") || (this.fgDichVu.GetDataDisplay(num, "MaDichVu") == "C50013")) CHOTP_TRI = !CHOTP_TRI; //Nếu có Chole, tri
                    if ((this.fgDichVu.GetDataDisplay(num, "MaDichVu") == "C50014") || (this.fgDichVu.GetDataDisplay(num, "MaDichVu") == "C50015")) HDL_LDL = !HDL_LDL; //Nếu có HDLC, LDLC
                    if ((this.fgDichVu.GetDataDisplay(num, "MaDichVu") == "C50006") || (this.fgDichVu.GetDataDisplay(num, "MaDichVu") == "C50072")) BILTP_BILTT = !BILTP_BILTT; // Nếu có BilTP, BilTT
                    //------------------------------------------
                    //Kiểm tra các xét nghiệm có nằm trong nhóm ko dùng cho Cấp cứu không (chưa làm)
                    //if (!this.fgDichVu.Rows[num].IsNode && DichVuKhongCapCuu.IndexOf(this.fgDichVu.GetDataDisplay(num, "MaDichVu")) > -1 && chCapCuu.Checked)
                    //{
                    //    MessageBox.Show("Dịch vụ: " + this.fgDichVu.GetDataDisplay(num, "TenDichVu") + " không xét nghiệm Cấp cứu."   , "Th\x00f4ng b\x00e1o", MessageBoxButtons.OK);
                    //    return;
                    //}
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
                    MessageBox.Show("Bạn phải chỉ định cả SGOT và SGPT",   "Thông báo!");
                    return;
                }
                if (CHOTP_TRI)
                {
                    MessageBox.Show("Bạn phải chỉ định cả Cholestrol toàn phần (máu) và Triglycerid (máu) ",   "Thông báo!");
                    return;
                }
                if (HDL_LDL)
                {
                    MessageBox.Show("Bạn phải chỉ định cả HDL Cholestrol (máu) và LDL Cholestrol (máu)",   "Thông báo!");
                    return;
                }
                if (BILTP_BILTT)
                {
                    MessageBox.Show("Bạn phải chỉ định cả Bilirubin toàn phần (máu) và Bilirubin trực tiếp (máu)",   "Thông báo!");
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
                        { }
                        if (OK == 0 && fgDichVu.GetData(num, "LoaiDichVu").ToString().Substring(0, 1) == "C" && fgDichVu.GetData(num, "TenDichVu").ToString().ToLower().IndexOf("thông khí") < 0 && fgDichVu.GetData(num, "LoaiDichVu").ToString() != "C64")
                        {
                            MessageBox.Show("Số lượng dịch vụ phải là số tự nhiên >= 1!", "Thông báo!");
                            return;
                        }
                        if (OK <0)
                        {
                            MessageBox.Show("Sai số lượng!", "Thông báo!");
                            return;
                        }
                        //if (!((fgDichVu.GetDataDisplay(fgDichVu.Row, "TyleBH").ToString() == "0") || (fgDichVu.GetDataDisplay(fgDichVu.Row, "TyleBH").ToString() == "100")))
                        //{
                        //    MessageBox.Show("Tỷ lệ BHYT Sai", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //    return;
                        //}
                    }
                }

                /* Kiểm tra ma benh------------------------------------------------------------- */

                for (int num1 = 1; num1 < this.fgDichVu.Rows.Count; num1++)
                { 
                        cmd.CommandText = "";
                        madichvu_kiemtra = "";
                        batnhap = 0;
                        cmd.CommandText = String.Format("select distinct MaDichVu,KiemTra from NAMDINH_QLBN.dbo.tblICD_DichVu where MaDichVu = '{0}' and MaDichVu not like N'KT%'", this.fgDichVu.GetDataDisplay(num1, "MaDichVu"));
                        dr = cmd.ExecuteReader();
                            while (dr.Read())
                            {
                                madichvu_kiemtra = dr["MaDichVu"].ToString();
                                Kiemtra_ICD = dr["KiemTra"].ToString();
                            }
                            dr.Close();
                            cmd.Dispose();
                        cmd.CommandText = "";
                        if (madichvu_kiemtra != "")
                        {
                            cmd.CommandText = String.Format("select MaDichVu,MAVAOVIEN from NAMDINH_QLBN.dbo.tbl_MaVaoVien_Dichvu where MaDichVu = '{0}' and mavaovien = '{1}' and MaDichVu not like N'KT%'", madichvu_kiemtra, txtMaVaoVien.Text);
                            dr = cmd.ExecuteReader();
                            if (dr.HasRows)
                            {
                                
                            }
                            else
                            {
                                MessageBox.Show("Nhập Mã Bệnh cho dịch vụ: " + this.fgDichVu.GetDataDisplay(num1, "TenDichVu"));
                                dr.Close();
                                cmd.Dispose();
                                cmdICD_Dichvu(madichvu_kiemtra,Kiemtra_ICD);
                                if(batnhap==1)
                                {
                                    MessageBox.Show("Bắt buộc phải nhập ICD cho dịch vụ vui lòng thao tác lại", "Thông báo!");
                                    return;
                                    dr.Close();
                                    cmd.Dispose();
                                }
                                btnLuu_ICD_Click(null, null);
                            }
                            dr.Close();
                            cmd.Dispose();
                        }

                }
                    //}
                    //for (int num1 = 1; num1 < this.fgDichVu.Rows.Count; num1++)
                    //{
                    //    cmd.CommandText = "";
                    //    madichvu_kiemtra = "";
                    //    batnhap = 0;
                    //    cmd.CommandText = String.Format("select distinct MaDichVu,KiemTra from NAMDINH_QLBN.dbo.tblICD_DichVu where MaDichVu = '{0}' and  not like N'KT%'", this.fgDichVu.GetDataDisplay(num1, "MaDichVu"));
                    //    dr = cmd.ExecuteReader();
                    //    while (dr.Read())
                    //    {
                    //        madichvu_kiemtra = dr["MaDichVu"].ToString();
                    //        Kiemtra_ICD = dr["KiemTra"].ToString();
                    //    }
                    //    dr.Close();
                    //    cmd.Dispose();
                    //    cmd.CommandText = "";
                    //    if (madichvu_kiemtra != "")
                    //    {
                    //        cmd.CommandText = String.Format("select MaDichVu,MAVAOVIEN from NAMDINH_QLBN.dbo.tbl_MaVaoVien_Dichvu where MaDichVu = '{0}' and mavaovien = '{1}'", madichvu_kiemtra, txtMaVaoVien.Text);
                    //        dr = cmd.ExecuteReader();
                    //        if (dr.HasRows)
                    //        {

                    //        }
                    //        else
                    //        {
                    //            MessageBox.Show("Nhập Mã Bệnh cho dịch vụ: " + this.fgDichVu.GetDataDisplay(num1, "TenDichVu"));
                    //            dr.Close();
                    //            cmd.Dispose();
                    //            cmdICD_Dichvu(madichvu_kiemtra, Kiemtra_ICD);
                    //            if (batnhap == 1)
                    //            {
                    //                MessageBox.Show("Bắt buộc phải nhập ICD cho dịch vụ vui lòng thao tác lại", "Thông báo!");
                    //                return;
                    //                dr.Close();
                    //                cmd.Dispose();
                    //            }
                    //            //btnLuu_ICD_Click(null, null);
                    //        }
                    //        dr.Close();
                    //        cmd.Dispose();

                    //    }

                    /*------------------------------------------------------------------------------------------------*/
                    /* kiểm tra Số lượng tồn ------------------------------------------------------------- */
                    //for (int num1 = 2; num1 < this.fgDichVu.Rows.Count; num1++)
                    //{
                    //    if (fgDichVu.GetDataDisplay(num1, "LoaiDichVu").ToString() == "D01" && fgDichVu.GetDataDisplay(num1, "MaDichVu").ToString() != "DN-KH-0001")
                    //    {
                    //        cmd.CommandText = "";
                    //        cmd.CommandText = String.Format("select ISNULL(M1.MaDichvu,M2.madichvu) as MaDichVu,  SL1- isnull(SL2,0) as ConLai from (select MaDichVu, SUM(SLHienTai) as SL1 from NAMDINH_QLBN.dbo.DMLENCHIPHI_BYKHOID where  MaDichvu = '{0}' and LoaiDichvu = 'D01' group by MaDichvu) M1 left join NAMDINH_QLBN.dbo.View_ThuocChuaDuyet M2 on M1.MaDichvu = M2.Madichvu where M1.MADICHVU = '{0}' ", this.fgDichVu.GetDataDisplay(num1, "MaDichVu"));
                    //        dr = cmd.ExecuteReader();
                    //        if (dr.HasRows)
                    //        {
                    //            while (dr.Read())
                    //            {
                    //                if ((decimal.Parse(fgDichVu.GetDataDisplay(num1, "SoLuong")) >= decimal.Parse(dr["ConLai"].ToString())) && (fgDichVu.GetDataDisplay(num1, "LoaiDichVu") == "D01"))
                    //                {
                    //                    fgDichVu.Rows[num1].StyleNew.BackColor = Color.YellowGreen;
                    //                    MessageBox.Show("Số lượng thuốc " + this.fgDichVu.GetDataDisplay(num1, "TenDichVu") + " còn lại là: " + dr["ConLai"].ToString());
                    //                    dr.Close();
                    //                    cmd.Dispose();
                    //                    return;
                    //                }
                    //                else
                    //                {
                    //                    fgDichVu.Rows[num1].StyleNew.BackColor = Color.White;
                    //                }
                    //            }
                    //            dr.Close();
                    //            cmd.Dispose();
                    //        }
                    //        dr.Close();
                    //        cmd.Dispose();
                    //    }
                    //}
                    //---------------------------------------------------------------------------------------------
                SqlCommand command = new SqlCommand("", Global.ConnectSQL);
                SqlTransaction transaction = Global.ConnectSQL.BeginTransaction();
                command.Transaction = transaction;

                string text = this.lblSoPhieu.Text;
                lblSoPhieu.Text = "";
                int ID_Sophieu_EDIT = 0;
                try
                {
                  //      Đoạn code phục vụ khoa Hóa sinh thống kê các phiếu chỉ đinh bị sửa
                    if (!this.IsAddnew) // Nếu sửa phiếu
                    {
                        // Lưu lại phiếu cũ và chỉ định cũ
                        command.CommandText = string.Format("INSERT INTO NAMDINH_CLS.dbo.BENHNHAN_PHIEUDIEUTRI_EDIT SELECT SoPhieu, MaVaoVien, NgayChiDinh, LoaiDT, BacSyDT, DienBienBenh, YLenh, CDChamSoc, CDDinhDuong, MaKhoa, Nhom, ChanDoan, CapCuu, mabs, NhomMau, SoThang, ChuThich, UserName1, Is_In, DaThucHien FROM BENHNHAN_PHIEUDIEUTRI WHERE SoPhieu='{0}' Select @@IDENTITY", text);
                        ID_Sophieu_EDIT = (int)Convert.ChangeType(command.ExecuteScalar(), typeof(int));
                        command.CommandText = string.Format("INSERT INTO NAMDINH_CLS.dbo.PHIEUDIEUTRI_CHITIET_EDIT SELECT " + ID_Sophieu_EDIT + " as ID, a.SoPhieu, a.LoaiDichVu, a.MaDichVu, a.SoLuong, a.DonGia, a.GhiChu, a.DoiTuongBN, a.DaThucHien, a.LuotIn, a.TinhPhi, a.SoLuongHT, a.LyDo, a.Chot, a.NgayChot, a.UserName, a.KetQua, a.DaThanhToan, a.ChonDt, a.MaDichVuDuyet, a.SoLuongDuyet, a.DaDuyet, a.MaPhieuDuyet, a.MaNhom, a.KhoID, a.NgayIn, a.DuyetBHYT, a.UseDuyetBHYT, a.NgayduyetBHYT, a.SoBLTC, a.IDVIENPHI, a.LanInTT, a.LanChuyenDT, a.MaPhieuHoan, a.DuyetHoan, a.MaMay, a.SID, a.TyLe,a.TTThau FROM PHIEUDIEUTRI_CHITIET a inner join (select distinct MaDichvu from NAMDINH_QLBN.dbo.DMLENCHIPHI_BYKHOID) CHIPHI on a.MaDichVu = CHIPHI.MaDichvu WHERE SoPhieu='{0}'", text);
                        command.ExecuteNonQuery();
                        // Lưu lại phiếu chỉ định mới
                        command.CommandText = string.Format("INSERT INTO NAMDINH_CLS.dbo.BENHNHAN_PHIEUDIEUTRI_EDIT (SoPhieu,MaVaovien,NgayChiDinh,LoaiDT,bacSyDT,DienBienBenh,YLenh,CDChamSoc,CDDinhDuong,MaKhoa,Nhom,ChanDoan,CapCuu,MaBS,NhomMau,UserName1) VALUES ('{0}','{1}',getdate(),{2},N'{3}',N'{4}',N'{5}',{6},{7},'{8}',{9},N'{10}',{11},{12},{13},N'{14}') Select @@IDENTITY ", new object[] { text, this.txtMaVaoVien.Text, "null", this.cmbBacSyDT.Columns[1].CellText(this.cmbBacSyDT.SelectedIndex), this.txtDienBienBenh.Text, this.richTextBox1.Text, (this.cmbCheDoChamSoc.SelectedIndex == -1) ? "null" : Global.GetCode(this.cmbCheDoChamSoc), (this.cmbCheDoDinhDuong.SelectedIndex == -1) ? "null" : Global.GetCode(this.cmbCheDoDinhDuong), Global.GetCode(this.cmbKhoa), this.raChiPhiTT.Checked ? 1 : 0, this.txtChanDoan.Text.Trim(), this.chCapCuu.Checked ? 1 : 0, (Global.GetCode(this.cmbBacSyDT) == null) ? "null" : Global.GetCode(this.cmbBacSyDT), this.cmbNhomMau.SelectedIndex, Global.glbUName });
                        ID_Sophieu_EDIT = (int)Convert.ChangeType(command.ExecuteScalar(), typeof(int));
                        command.CommandText = "";
                        for (num = 1; num < this.fgDichVu.Rows.Count; num++)
                        {
                            if (!this.fgDichVu.Rows[num].IsNode)
                            {
                                double num4;
                                double num5;
                                int lanChuyenDT;
                                double num2 = (this.fgDichVu[num, "DonGia"].ToString() == "") ? 0.0 : double.Parse(this.fgDichVu[num, "DonGia"].ToString());
                                double num3 = double.Parse(this.fgDichVu[num, "SoLuong"].ToString());
                                if (this.fgDichVu.GetDataDisplay(num, "SoLuongHT") == "")
                                {
                                    num4 = 0.0;
                                }
                                else
                                {
                                    num4 = double.Parse(this.fgDichVu[num, "SoLuongHT"].ToString());
                                }
                                if (this.fgDichVu.GetDataDisplay(num, "SoLuongDuyet") == "")
                                {
                                    num5 = 0.0;
                                }
                                else
                                {
                                    num5 = double.Parse(this.fgDichVu[num, "SoLuongDuyet"].ToString());
                                }
                                if (this.fgDichVu.GetDataDisplay(num, "LanChuyenDT") == "")
                                {
                                    lanChuyenDT = this.LanChuyenDT;
                                }
                                else
                                {
                                    lanChuyenDT = int.Parse(this.fgDichVu[num, "LanChuyenDT"].ToString());
                                }
                                command.CommandText = command.CommandText + string.Format(" INSERT INTO NAMDINH_CLS.dbo.PHIEUDIEUTRI_CHITIET_EDIT (SoPhieu,LoaiDichVu,MaDichVu,SoLuong,DonGia,GhiChu,DoiTuongBN,DaThucHien,TinhPhi,UserName,ChonDT,DuyetBHYT,MaNhom,KhoID,MaPhieuDuyet,DaThanhToan,DaDuyet,LanInTT,Chot,NgayChot,SoLuongHT,SoLuongDuyet,LanChuyenDT, ID) VALUES ('{0}','{1}','{2}',{3},{4},N'{5}','{6}',{7},{8},N'{9}',{10},{11},{12},{13},'{14}',{15},{16},{17},{18},{19},{20},{21},{22},{23})", new object[] {
                                    text, this.fgDichVu[num, "LoaiDichVu"], this.fgDichVu[num, "MaDichVu"], num3.ToString().Replace(",", "."), num2.ToString().Replace(",", "."), this.fgDichVu[num, "GhiChu"], (this.cmbDoiTuong.SelectedIndex == 0) ? this.MaDoiTuongBN : Global.GetCode(this.cmbDoiTuong), (this.fgDichVu[num, "DaThucHien"].ToString().ToLower() == "true") ? 1 : 0, (this.fgDichVu[num, "KhongTinhPhi"].ToString().ToLower() == "true") ? 1 : 0, Global.glbUName, this.cmbDoiTuong.SelectedIndex, (this.fgDichVu.GetDataDisplay(num, "LuotIn") == "") ? "null" : this.fgDichVu[num, "Luotin"].ToString(), this.MaNhom, (this.fgDichVu[num, "KhoID"].ToString() == "") ? "null" : this.fgDichVu[num, "KhoID"].ToString(), this.fgDichVu.GetDataDisplay(num, "MaPhieuDuyet"), (this.fgDichVu.GetDataDisplay(num, "DaThanhToan").ToString() == "") ? "0" : this.fgDichVu.GetDataDisplay(num, "DaThanhToan"),
                                    (this.fgDichVu.GetDataDisplay(num, "DaDuyet").ToString() == "") ? "0" : this.fgDichVu.GetDataDisplay(num, "DaDuyet"), (this.fgDichVu.GetDataDisplay(num, "LanInTT").ToString() == "") ? "null" : this.fgDichVu.GetDataDisplay(num, "LanInTT"), (this.fgDichVu.GetDataDisplay(num, "Chot").ToString() == "") ? "0" : this.fgDichVu.GetDataDisplay(num, "Chot"),fgDichVu.GetDataDisplay(num, "NgayChot").ToString() == "" ? "null" : string.Format("'{0:dd/MM/yyyy}'", fgDichVu.GetData(num, "NgayChot")), num4.ToString().Replace(",", "."), num5.ToString().Replace(",", "."), lanChuyenDT, ID_Sophieu_EDIT});
                            }
                        }
                        if (!(command.CommandText == ""))
                        {
                            command.ExecuteNonQuery();
                        }

                    }
                    //-------------------------------------------------------------------
                    if (this.IsAddnew)
                    {
                        command.CommandText = string.Format("select dbo.LaySoPhieu(Right(Convert(nvarchar(8),'{0:yyyyMMdd}',112),6)) As SoPhieu", this.txtNgayChiDinh.Value);
                        text = command.ExecuteScalar().ToString();
                        command.CommandText = string.Format("set dateformat dmy INSERT INTO BENHNHAN_PHIEUDIEUTRI  (SoPhieu,MaVaovien,NgayChiDinh,LoaiDT,bacSyDT,DienBienBenh,YLenh,CDChamSoc,CDDinhDuong,MaKhoa,Nhom,ChanDoan,CapCuu,MaBS,NhomMau,UserName1,MaPhieuCanQuang,CCHN_NT,isPhieudieutri_Covid,MaGiuongYT) VALUES ('{0}','{1}','{2:dd/MM/yyyy HH:mm}',{3},N'{4}',N'{5}',N'{6}',{7},{8},'{9}',{10},N'{11}',{12},{13},{14},N'{15}','{0}',N'{16}',{17},N'{18}')", new object[] { text, this.txtMaVaoVien.Text, this.txtNgayChiDinh.Value, "null", this.cmbBacSyDT.Columns[1].CellText(this.cmbBacSyDT.SelectedIndex), this.txtDienBienBenh.Text, this.richTextBox1.Text, (this.cmbCheDoChamSoc.SelectedIndex == -1) ? "null" : Global.GetCode(this.cmbCheDoChamSoc), (this.cmbCheDoDinhDuong.SelectedIndex == -1) ? "null" : Global.GetCode(this.cmbCheDoDinhDuong), Global.GetCode(this.cmbKhoa), this.raChiPhiTT.Checked ? 1 : 0, this.txtChanDoan.Text.Trim().Replace("|"," "), this.chCapCuu.Checked ? 1 : 0, (Global.GetCode(this.cmbBacSyDT) == null) ? "null" : Global.GetCode(this.cmbBacSyDT), this.cmbNhomMau.SelectedIndex, Global.glbUName, this.cmbBacSyDT.Columns[2].CellText(this.cmbBacSyDT.SelectedIndex),PhieuCovid,lblMaGiuongYT.Text });
                        
                    }
                    else
                    {
                        string bacSyDT = "";
                        string MaBS = "";
                        string CCHN_NT = "";
                        string UserName1 = "";

                        if (fgPhieuChiDinh[fgPhieuChiDinh.Row, "SoPhieu"].ToString().Substring(0, 2) == "NT")
                        {
                            bacSyDT = this.cmbBacSyDT.Columns[1].CellText(this.cmbBacSyDT.SelectedIndex);
                            MaBS = Global.GetCode(this.cmbBacSyDT);
                            CCHN_NT = this.cmbBacSyDT.Columns[2].CellText(this.cmbBacSyDT.SelectedIndex);
                            UserName1 = Global.glbUName;
                        }
                        else
                        {
                            bacSyDT = fgPhieuChiDinh[fgPhieuChiDinh.Row, "BacSyDT"].ToString();
                            MaBS = null;
                            CCHN_NT = fgPhieuChiDinh[fgPhieuChiDinh.Row, "CCHN_NT"].ToString();
                            UserName1 = fgPhieuChiDinh[fgPhieuChiDinh.Row, "UN"].ToString();
                        }
                        command.CommandText = string.Format("set dateformat dmy UPDATE BENHNHAN_PHIEUDIEUTRI SET NgayChiDinh='{1:dd/MM/yyyy HH:mm}',LoaiDT={2},bacSyDT=N'{3}',DienBienBenh=N'{4}',YLenh=N'{5}',CDChamSoc={6},CDDinhDuong={7},ChanDoan=N'{8}',CapCuu ={9},MaBS='{10}',NhomMau={11},Nhom={12},MaPhieuCanQuang= '{0}',CCHN_NT=N'{13}',isPhieudieutri_Covid = '{14}', UserName1 = N'{15}', MaGiuongYT = N'{16}' WHERE SoPhieu ='{0}'", new object[] { text, this.txtNgayChiDinh.Value, "null", bacSyDT, this.txtDienBienBenh.Text, this.richTextBox1.Text, (this.cmbCheDoChamSoc.SelectedIndex == -1) ? "null" : Global.GetCode(this.cmbCheDoChamSoc), (this.cmbCheDoDinhDuong.SelectedIndex == -1) ? "null" : Global.GetCode(this.cmbCheDoDinhDuong), this.txtChanDoan.Text.Trim().Replace("|", " "), this.chCapCuu.Checked ? 1 : 0, MaBS, this.cmbNhomMau.SelectedIndex, this.raChiPhiHN.Checked ? "0" : "1", CCHN_NT,PhieuCovid,UserName1,lblMaGiuongYT.Text });
                    }
                    command.ExecuteNonQuery();
                    command.CommandText = string.Format("DELETE FROM PHIEUDIEUTRI_CHITIET WHERE SoPhieu='{0}'", text);
                    command.ExecuteNonQuery();
                    command.CommandText = "";
                    string Gioitinh = "";
                    string NhomDichVu = "";
                    string isphieudieutrichietiet_covid = "";
                    for (num = 1; num < this.fgDichVu.Rows.Count; num++)
                    {
                        if (!this.fgDichVu.Rows[num].IsNode)
                        {
                            Moduls.clsMaDichVu  clsDv = new Moduls.clsMaDichVu();
                            double SoLuongHT;
                            double SoLuongDuyet;
                            int lanChuyenDT;
                            //int isVienTro_CT, isPhieudieutri_chitiet_covid, isT_Khac_CT, NguonT_Khac_CT;
                            string MaphieuCQ = "";
                            double DonGia = (this.fgDichVu[num, "DonGia"].ToString() == "") ? 0.0 : double.Parse(this.fgDichVu[num, "DonGia"].ToString());
                            double GiaVP = (this.fgDichVu[num, "GiaVP"].ToString() == "") ? 0.0 : double.Parse(this.fgDichVu[num, "GiaVP"].ToString());
                            double GiaBHYT = (this.fgDichVu[num, "GiaBHYT"].ToString() == "") ? 0.0 : double.Parse(this.fgDichVu[num, "GiaBHYT"].ToString());
                            double SoLuong = double.Parse(this.fgDichVu[num, "SoLuong"].ToString());
                            int TyLe = int.Parse(this.fgDichVu[num, "TyLe"].ToString());
                            if (TyLe == 0) TyLe = 100;
                            if (this.fgDichVu.GetDataDisplay(num, "SoLuongHT") == "")
                            {
                                SoLuongHT = 0.0;
                            }
                            else
                            {
                                SoLuongHT = double.Parse(this.fgDichVu[num, "SoLuongHT"].ToString());
                            }
                            if (this.fgDichVu.GetDataDisplay(num, "SoLuongDuyet") == "")
                            {
                                SoLuongDuyet = 0.0;
                            }
                            else
                            {
                                SoLuongDuyet = double.Parse(this.fgDichVu[num, "SoLuongDuyet"].ToString());
                            }
                            if (this.fgDichVu.GetDataDisplay(num, "LanChuyenDT") == "")
                            {
                                lanChuyenDT = this.LanChuyenDT;
                            }
                            else
                            {
                                lanChuyenDT = int.Parse(this.fgDichVu[num, "LanChuyenDT"].ToString());
                            }
                            if (this.fgDichVu.GetDataDisplay(num, "MaDichVu") == "T00000000000013" || this.fgDichVu.GetDataDisplay(num, "MaDichVu") == "T00000000000061" || this.fgDichVu.GetDataDisplay(num, "MaDichVu") == "T00000000000359" || this.fgDichVu.GetDataDisplay(num, "MaDichVu") == "T00000000000625" || this.fgDichVu.GetDataDisplay(num, "MaDichVu") == "T00000000000730" || this.fgDichVu.GetDataDisplay(num, "MaDichVu") == "T00000000001199" || this.fgDichVu.GetDataDisplay(num, "MaDichVu").Contains("TCQ"))
                            {
                                MaphieuCQ = text;
                            }
                            if (this.fgDichVu.GetDataDisplay(num, "LoaiDichVu") == "C54" || this.fgDichVu.GetDataDisplay(num, "LoaiDichVu") == "C57" || this.fgDichVu.GetDataDisplay(num, "LoaiDichVu") == "C59" || this.fgDichVu.GetDataDisplay(num, "LoaiDichVu") == "C60" || this.fgDichVu.GetDataDisplay(num, "LoaiDichVu") == "C61" || this.fgDichVu.GetDataDisplay(num, "LoaiDichVu") == "C62")
                            {
                                if (txtGioi.Text == "Nữ")
                                { Gioitinh = "F"; }
                                else { Gioitinh = "M"; }
                                if (fgDichVu.GetDataDisplay(num, "LoaiDichVu") == "C54") NhomDichVu = "XQ";
                                if (fgDichVu.GetDataDisplay(num, "LoaiDichVu") == "C57") NhomDichVu = "CT64";
                                if (fgDichVu.GetDataDisplay(num, "LoaiDichVu") == "C59") NhomDichVu = "MR";
                                if (fgDichVu.GetDataDisplay(num, "LoaiDichVu") == "C60") NhomDichVu = "CT64";
                                if (fgDichVu.GetDataDisplay(num, "LoaiDichVu") == "C61") NhomDichVu = "CT20";
                                if (fgDichVu.GetDataDisplay(num, "LoaiDichVu") == "C62") NhomDichVu = "CT2";
                            }
                            if(this.IsAddnew)
                            {
                                if(Global.GetCode(cmbKhoa) != "NV120101" && fgDichVu.GetDataDisplay(num, "LoaiDichVu") != "AN0")
                                {
                                    fgDichVu[num, "TyleBH"] = "0";
                                }
                                else fgDichVu[num, "TyleBH"] = fgDichVu.GetDataDisplay(num, "TyleBH").ToString();
                            }
                            else
                            {
                                fgDichVu[num, "TyleBH"] = fgDichVu.GetDataDisplay(num, "TyleBH").ToString();
                            }
                            if(fgDichVu.GetDataDisplay(num, "LoaiDichVu") == "AN0")
                            {
                                DonGia = GiaVP;
                            }
                            else
                            {
                                if (MaDoiTuongBN == "1" )
                                {
                                    if(fgDichVu.GetDataDisplay(num, "TyleBH").ToString() == "0"){
                                        DonGia = GiaVP;
                                        }
                                    else
                                    {
                                        DonGia = GiaBHYT;
                                    }
                                    
                                }
                                else
                                {
                                    DonGia = GiaVP;
                                }
                            }
                            if(Global.GetCode(cmbKhoa)== "NV120101" || fgDichVu.GetDataDisplay(num, "LoaiDichVu") == "AN0")
                            {
                                isphieudieutrichietiet_covid = "0";
                            }
                            else
                            {
                                isphieudieutrichietiet_covid = (this.fgDichVu.GetDataDisplay(num, "TyleBH").ToString() == "0") ? "1" : "0";
                            }
                                command.CommandText = command.CommandText + string.Format(" INSERT INTO PHIEUDIEUTRI_CHITIET (SoPhieu,LoaiDichVu,MaDichVu,SoLuong,DonGia,GhiChu,DoiTuongBN,DaThucHien,TinhPhi,UserName,ChonDT,DuyetBHYT,MaNhom,KhoID,MaPhieuDuyet,DaThanhToan,DaDuyet,LanInTT,Chot,NgayChot,SoLuongHT,SoLuongDuyet,LanChuyenDT, TyLe,MaPhieuCanQuang,TTThau,TyLeBHYT,STT,MaPhieuHoan,DuyetHoan,MaDichVuDuyet,MaKhoaThucHien,MaMay,isPhieudieutri_chitiet_covid,GiaVP,GiaBHYT,isT_Khac_CT,NguonT_Khac_CT,isVienTro_CT) VALUES ('{0}','{1}','{2}',{3},{4},N'{5}','{6}',{7},{8},N'{9}',{10},{11},{12},{13},'{14}',{15},{16},{17},{18},{19},{20},{21},{22},{23},'{24}','{25}','{26}','{27}','{28}','{29}','{30}','{31}','{32}',{33},{34},{35},{36},{37},{38})", new object[] {
                                text, this.fgDichVu[num, "LoaiDichVu"], this.fgDichVu[num, "MaDichVu"], SoLuong.ToString().Replace(",", "."),
                                    DonGia.ToString().Replace(",", "."),
                                    this.fgDichVu[num, "GhiChu"],
                                    (this.cmbDoiTuong.SelectedIndex == 0) ? this.MaDoiTuongBN : Global.GetCode(this.cmbDoiTuong),
                                    (this.fgDichVu[num, "DaThucHien"].ToString().ToLower() == "true") ? 1 : 0, (this.fgDichVu[num, "KhongTinhPhi"].ToString().ToLower() == "true") ? 1 : 0, Global.glbUName, this.cmbDoiTuong.SelectedIndex, (this.fgDichVu.GetDataDisplay(num, "LuotIn") == "") ? "null" : this.fgDichVu[num, "Luotin"].ToString(), this.MaNhom, (this.fgDichVu[num, "KhoID"].ToString() == "") ? "null" : this.fgDichVu[num, "KhoID"].ToString(), this.fgDichVu.GetDataDisplay(num, "MaPhieuDuyet"), (this.fgDichVu.GetDataDisplay(num, "DaThanhToan").ToString() == "") ? "0" : this.fgDichVu.GetDataDisplay(num, "DaThanhToan"),
                                (this.fgDichVu.GetDataDisplay(num, "DaDuyet").ToString() == "") ? "0" : this.fgDichVu.GetDataDisplay(num, "DaDuyet"), (this.fgDichVu.GetDataDisplay(num, "LanInTT").ToString() == "") ? "null" : this.fgDichVu.GetDataDisplay(num, "LanInTT"), (this.fgDichVu.GetDataDisplay(num, "Chot").ToString() == "") ? "0" : this.fgDichVu.GetDataDisplay(num, "Chot"),fgDichVu.GetDataDisplay(num, "NgayChot").ToString() == "" ? "null" : string.Format("'{0:dd/MM/yyyy}'", fgDichVu.GetData(num, "NgayChot")), SoLuongHT.ToString().Replace(",", "."), SoLuong.ToString().Replace(",", "."),
                                   lanChuyenDT,
                                    TyLe,MaphieuCQ,fgDichVu.GetDataDisplay(num, "TTThau").ToString(),
                                   fgDichVu[num, "TyleBH"] ,
                                    fgDichVu.GetDataDisplay(num,"STT"),
                                this.fgDichVu[num, "MaPhieuHoan"],
                                (this.fgDichVu.GetDataDisplay(num, "DuyetHoan").ToString() == "") ? "0" : this.fgDichVu.GetDataDisplay(num, "DuyetHoan"),
                                this.fgDichVu[num, "MaDichVuDuyet"], this.fgDichVu[num, "MaKhoaThucHien"], this.fgDichVu[num, "MaMay"],
                                     isphieudieutrichietiet_covid,
                                    GiaVP.ToString().Replace(",", "."),GiaBHYT.ToString().Replace(",", "."),(this.fgDichVu.GetDataDisplay(num, "isT_Khac_CT").ToString() == "") ? "0" : this.fgDichVu.GetDataDisplay(num, "isT_Khac_CT"),
                                    (this.fgDichVu.GetDataDisplay(num, "NguonT_Khac_CT").ToString() == "") ? "0" : this.fgDichVu.GetDataDisplay(num, "NguonT_Khac_CT"),
                                    (this.fgDichVu.GetDataDisplay(num, "isVienTro_CT").ToString() == "") ? "0" : this.fgDichVu.GetDataDisplay(num, "isVienTro_CT")
                                    });
                                if (this.fgDichVu.GetDataDisplay(num, "LoaiDichVu") == "C54" || this.fgDichVu.GetDataDisplay(num, "LoaiDichVu") == "C57" || this.fgDichVu.GetDataDisplay(num, "LoaiDichVu") == "C59" || this.fgDichVu.GetDataDisplay(num, "LoaiDichVu") == "C60" || this.fgDichVu.GetDataDisplay(num, "LoaiDichVu") == "C61" || this.fgDichVu.GetDataDisplay(num, "LoaiDichVu") == "C62")
                                {
                                    command.CommandText = command.CommandText + string.Format(" Begin if NOT EXISTS (select  * from NAMDINH_CLS.dbo.pacstest where MaChiDinh = N'{0}' AND MADICHVU = N'{11}') BEGIN  INSERT INTO NAMDINH_CLS.dbo.pacstest(MaChiDinh, ThoiGianChiDinh, MaBenhNhan, TenBenhNhan, NgaySinh, GioiTinh, DiaChi, SDT, NoiChiDinh, MaBacSiChiDinh, TenBacSiChiDinh, MaDichVu, TenDichVu, NhomDichVu, ChanDoan, TrangThai,DaGui)VALUES (N'{0}',N'{1:yyyyMMddHHmmss}',N'{2}',N'{3}',N'{4}',N'{5}',N'{6}',N'{7}',N'{8}','{9}',N'{10}',N'{11}',N'{12}',N'{13}',N'{14}',N'{15}','{16}') End else begin update NAMDINH_CLS.dbo.pacstest set  ThoiGianChiDinh = N'{1:yyyyMMddHHmmss}', MaBacSiChiDinh = N'{9}', TenBacSiChiDinh = N'{10}', MaDichVu = N'{11}', TenDichVu = N'{12}', NhomDichVu = N'{13}' where MaChiDinh  = N'{0}' AND MaDichVu = N'{11}' END END ", new object[]
                                    { text, this.txtNgayChiDinh.Value, this.txtMaVaoVien.Text, txtHoTen.Text, DateTime.Parse(txtNgayChiDinh.Text).Year - int.Parse(txtTuoi.Text) + "0101", Gioitinh, ".", "123456789", Global.GetCode(cmbKhoa), Global.GetCode(cmbBacSyDT), cmbBacSyDT.Text, this.fgDichVu[num, "MaDichVu"], this.fgDichVu[num, "TenDichVu"],NhomDichVu, ".", "NW","0" });

                                }
                                command.CommandText = command.CommandText + string.Format(" if(exists(select * from dstravo where makhoa='{0}' and mathuoc = '{1}'))  begin if(exists(select * from benhnhan_travo inner join dstravo on dstravo.makhoa =  benhnhan_travo.makhoa and dstravo.makhoa ='{0}' where benhnhan_travo.makhoa='{0}' and benhnhan_travo.mathuoc='{1}')) begin update benhnhan_travo set soluongdsd = ", Global.GetCode(this.cmbKhoa), fgDichVu.GetDataDisplay(num, "TTThau").ToString());
                                if (this.IsAddnew)
                                {
                                    command.CommandText = command.CommandText + string.Format(" (select SoLuongDSD + {2} from benhnhan_travo where makhoa='{0}'  and mathuoc ='{1}') where makhoa='{0}'  and mathuoc ='{1}'", Global.GetCode(this.cmbKhoa), this.fgDichVu[num, "MaDichVu"], this.fgDichVu[num, "SoLuong"].ToString().Replace(",", "."));
                                }
                                else
                                {
                                    command.CommandText = command.CommandText + string.Format(" (select SoLuongDSD + {2} - {3} from benhnhan_travo where makhoa='{0}' and mathuoc ='{1}') where makhoa='{0}' and mathuoc ='{1}'", new object[] { Global.GetCode(this.cmbKhoa), this.fgDichVu[num, "MaDichVu"], this.fgDichVu[num, "SoLuong"].ToString().Replace(",", "."), this.fgDichVu[num, "SoLuongCu"].ToString().Replace(",", ".") });
                                }
                                command.CommandText = command.CommandText + string.Format(" end else begin insert into benhnhan_travo(makhoa,mathuoc,soluongdsd,soluongdt) values('{0}','{1}',{2},0) end end", Global.GetCode(this.cmbKhoa), this.fgDichVu[num, "MaDichVu"], this.fgDichVu[num, "SoLuong"].ToString().Replace(",", "."));
                                //command.CommandText = command.CommandText + string.Format(" INSERT INTO PHIEUDIEUTRI_CHITIET (SoPhieu,LoaiDichVu,MaDichVu,SoLuong,DonGia,GhiChu,DoiTuongBN,DaThucHien,TinhPhi,UserName,ChonDT,DuyetBHYT,MaNhom,KhoID,MaPhieuDuyet,DaThanhToan,DaDuyet,LanInTT,Chot,NgayChot,SoLuongHT,SoLuongDuyet,LanChuyenDT, TyLe,MaPhieuCanQuang,TTThau,TyLeBHYT,STT,MaPhieuHoan,DuyetHoan,MaDichVuDuyet,MaKhoaThucHien,MaMay,isPhieudieutri_chitiet_covid) VALUES ('{0}','{1}','{2}',{3},{4},N'{5}','{6}',{7},{8},N'{9}',{10},{11},{12},{13},'{14}',{15},{16},{17},{18},{19},{20},{21},{22},{23},'{24}','{25}','{26}','{27}','{28}','{29}','{30}','{31}','{32}',{33})", new object[] {
                                //text, this.fgDichVu[num, "LoaiDichVu"], this.fgDichVu[num, "MaDichVu"], SoLuong.ToString().Replace(",", "."), DonGia.ToString().Replace(",", "."), this.fgDichVu[num, "GhiChu"], (this.cmbDoiTuong.SelectedIndex == 0) ? this.MaDoiTuongBN : Global.GetCode(this.cmbDoiTuong), (this.fgDichVu[num, "DaThucHien"].ToString().ToLower() == "true") ? 1 : 0, (this.fgDichVu[num, "KhongTinhPhi"].ToString().ToLower() == "true") ? 1 : 0, Global.glbUName, this.cmbDoiTuong.SelectedIndex, (this.fgDichVu.GetDataDisplay(num, "LuotIn") == "") ? "null" : this.fgDichVu[num, "Luotin"].ToString(), this.MaNhom, (this.fgDichVu[num, "KhoID"].ToString() == "") ? "null" : this.fgDichVu[num, "KhoID"].ToString(), this.fgDichVu.GetDataDisplay(num, "MaPhieuDuyet"), (this.fgDichVu.GetDataDisplay(num, "DaThanhToan").ToString() == "") ? "0" : this.fgDichVu.GetDataDisplay(num, "DaThanhToan"),
                                //(this.fgDichVu.GetDataDisplay(num, "DaDuyet").ToString() == "") ? "0" : this.fgDichVu.GetDataDisplay(num, "DaDuyet"), (this.fgDichVu.GetDataDisplay(num, "LanInTT").ToString() == "") ? "null" : this.fgDichVu.GetDataDisplay(num, "LanInTT"), (this.fgDichVu.GetDataDisplay(num, "Chot").ToString() == "") ? "0" : this.fgDichVu.GetDataDisplay(num, "Chot"),fgDichVu.GetDataDisplay(num, "NgayChot").ToString() == "" ? "null" : string.Format("'{0:dd/MM/yyyy}'", fgDichVu.GetData(num, "NgayChot")), SoLuongHT.ToString().Replace(",", "."), SoLuong.ToString().Replace(",", "."), lanChuyenDT,TyLe,MaphieuCQ,fgDichVu.GetDataDisplay(num, "TTThau").ToString(),100,fgDichVu.GetDataDisplay(num,"STT"),
                                //this.fgDichVu[num, "MaPhieuHoan"],
                                //(this.fgDichVu.GetDataDisplay(num, "DuyetHoan").ToString() == "") ? "0" : this.fgDichVu.GetDataDisplay(num, "DuyetHoan"),
                                //this.fgDichVu[num, "MaDichVuDuyet"], this.fgDichVu[num, "MaKhoaThucHien"], this.fgDichVu[num, "MaMay"],  (this.fgDichVu.GetDataDisplay(num, "TyleBH").ToString()=="0") ? "1" : "0"
                                //    });
                                //if (this.fgDichVu.GetDataDisplay(num, "LoaiDichVu") == "C54" || this.fgDichVu.GetDataDisplay(num, "LoaiDichVu") == "C57" || this.fgDichVu.GetDataDisplay(num, "LoaiDichVu") == "C59" || this.fgDichVu.GetDataDisplay(num, "LoaiDichVu") == "C60" || this.fgDichVu.GetDataDisplay(num, "LoaiDichVu") == "C61" || this.fgDichVu.GetDataDisplay(num, "LoaiDichVu") == "C62")
                                //{
                                //    command.CommandText = command.CommandText + string.Format(" Begin if NOT EXISTS (select  * from NAMDINH_CLS.dbo.pacstest where MaChiDinh = N'{0}' AND MADICHVU = N'{11}') BEGIN  INSERT INTO NAMDINH_CLS.dbo.pacstest(MaChiDinh, ThoiGianChiDinh, MaBenhNhan, TenBenhNhan, NgaySinh, GioiTinh, DiaChi, SDT, NoiChiDinh, MaBacSiChiDinh, TenBacSiChiDinh, MaDichVu, TenDichVu, NhomDichVu, ChanDoan, TrangThai,DaGui)VALUES (N'{0}',N'{1:yyyyMMddHHmmss}',N'{2}',N'{3}',N'{4}',N'{5}',N'{6}',N'{7}',N'{8}','{9}',N'{10}',N'{11}',N'{12}',N'{13}',N'{14}',N'{15}','{16}') End else begin update NAMDINH_CLS.dbo.pacstest set  ThoiGianChiDinh = N'{1:yyyyMMddHHmmss}', MaBacSiChiDinh = N'{9}', TenBacSiChiDinh = N'{10}', MaDichVu = N'{11}', TenDichVu = N'{12}', NhomDichVu = N'{13}' where MaChiDinh  = N'{0}' AND MaDichVu = N'{11}' END END ", new object[]
                                //    { text, this.txtNgayChiDinh.Value, this.txtMaVaoVien.Text, txtHoTen.Text, DateTime.Parse(txtNgayChiDinh.Text).Year - int.Parse(txtTuoi.Text) + "0101", Gioitinh, ".", "123456789", Global.GetCode(cmbKhoa), Global.GetCode(cmbBacSyDT), cmbBacSyDT.Text, this.fgDichVu[num, "MaDichVu"], this.fgDichVu[num, "TenDichVu"],NhomDichVu, ".", "NW","0" });

                                //}
                                //command.CommandText = command.CommandText + string.Format(" if(exists(select * from dstravo where makhoa='{0}' and mathuoc = '{1}'))  begin if(exists(select * from benhnhan_travo inner join dstravo on dstravo.makhoa =  benhnhan_travo.makhoa and dstravo.makhoa ='{0}' where benhnhan_travo.makhoa='{0}' and benhnhan_travo.mathuoc='{1}')) begin update benhnhan_travo set soluongdsd = ", Global.GetCode(this.cmbKhoa), fgDichVu.GetDataDisplay(num, "TTThau").ToString());
                                //if (this.IsAddnew)
                                //{
                                //    command.CommandText = command.CommandText + string.Format(" (select SoLuongDSD + {2} from benhnhan_travo where makhoa='{0}'  and mathuoc ='{1}') where makhoa='{0}'  and mathuoc ='{1}'", Global.GetCode(this.cmbKhoa), this.fgDichVu[num, "MaDichVu"], this.fgDichVu[num, "SoLuong"].ToString().Replace(",", "."));
                                //}
                                //else
                                //{
                                //    command.CommandText = command.CommandText + string.Format(" (select SoLuongDSD + {2} - {3} from benhnhan_travo where makhoa='{0}' and mathuoc ='{1}') where makhoa='{0}' and mathuoc ='{1}'", new object[] { Global.GetCode(this.cmbKhoa), this.fgDichVu[num, "MaDichVu"], this.fgDichVu[num, "SoLuong"].ToString().Replace(",", "."), this.fgDichVu[num, "SoLuongCu"].ToString().Replace(",", ".") });
                                //}
                                //command.CommandText = command.CommandText + string.Format(" end else begin insert into benhnhan_travo(makhoa,mathuoc,soluongdsd,soluongdt) values('{0}','{1}',{2},0) end end", Global.GetCode(this.cmbKhoa), this.fgDichVu[num, "MaDichVu"], this.fgDichVu[num, "SoLuong"].ToString().Replace(",", "."));
                        }


                    }
                    if (!(command.CommandText == ""))
                    {
                        command.ExecuteNonQuery();
                    }
                    transaction.Commit();
                    if (this.IsAddnew)
                    {
                        this.fgPhieuChiDinh.Tag = "0";
                        this.fgPhieuChiDinh.AddItem(string.Format("|||||||||{0}|{1}", Global.GetCode(this.cmbKhoa), this.cmbKhoa.Text));
                        this.fgPhieuChiDinh.Row = this.fgPhieuChiDinh.Rows.Count - 1;
                        this.fgPhieuChiDinh.Tag = "1";
                    }
                    this.fgPhieuChiDinh[this.fgPhieuChiDinh.Row, 0] = this.fgPhieuChiDinh.Rows.Count - 1;
                    this.fgPhieuChiDinh[this.fgPhieuChiDinh.Row, 1] = text;
                    this.fgPhieuChiDinh[this.fgPhieuChiDinh.Row, 2] = string.Format("{0:dd/MM/yyyy HH:mm}", this.txtNgayChiDinh.Value);
                    this.fgPhieuChiDinh[this.fgPhieuChiDinh.Row, 3] = "";
                    if (fgPhieuChiDinh[fgPhieuChiDinh.Row, "SoPhieu"].ToString().Substring(0, 2) == "NT")
                    {
                        this.fgPhieuChiDinh[this.fgPhieuChiDinh.Row, 4] = this.cmbBacSyDT.Columns[1].CellText(this.cmbBacSyDT.SelectedIndex);
                        this.fgPhieuChiDinh[this.fgPhieuChiDinh.Row, "UN"] = Global.glbUName;
                    }
                    else
                    {
                        this.fgPhieuChiDinh[this.fgPhieuChiDinh.Row, 4] = fgPhieuChiDinh[fgPhieuChiDinh.Row, "BacSyDT"].ToString();
                        this.fgPhieuChiDinh[this.fgPhieuChiDinh.Row, "UN"] = fgPhieuChiDinh[fgPhieuChiDinh.Row, "UN"].ToString();
                    }
                    this.fgPhieuChiDinh[this.fgPhieuChiDinh.Row, 5] = this.txtDienBienBenh.Text;
                    this.fgPhieuChiDinh[this.fgPhieuChiDinh.Row, 6] = this.richTextBox1.Text;
                    this.fgPhieuChiDinh[this.fgPhieuChiDinh.Row, 7] = (this.cmbCheDoChamSoc.SelectedIndex == -1) ? "" : Global.GetCode(this.cmbCheDoChamSoc);
                    this.fgPhieuChiDinh[this.fgPhieuChiDinh.Row, 8] = (this.cmbCheDoDinhDuong.SelectedIndex == -1) ? "" : Global.GetCode(this.cmbCheDoDinhDuong);
                    this.fgPhieuChiDinh[this.fgPhieuChiDinh.Row, 11] = this.raChiPhiTT.Checked ? 1 : 0;
                    this.fgPhieuChiDinh[this.fgPhieuChiDinh.Row, 13] = this.chCapCuu.Checked ? 1 : 0;
                    this.fgPhieuChiDinh[this.fgPhieuChiDinh.Row, 14] = this.raChiPhiHN.Checked ? "Trong ng\x00e0y" : "Bất thường";
                    this.fgPhieuChiDinh[this.fgPhieuChiDinh.Row, 15] = this.chCapCuu.Checked ? 1 : 0;
                    this.fgPhieuChiDinh[this.fgPhieuChiDinh.Row, 0x10] = this.cmbNhomMau.SelectedIndex;
                    this.fgPhieuChiDinh[this.fgPhieuChiDinh.Row, "ChanDoan"] = this.txtChanDoan.Text.Trim();
                    //this.fgPhieuChiDinh[this.fgPhieuChiDinh.Row, "isPhieudieutri_Covid"] = this.chk_Covid.Checked ? 1 : 0;

                    this.Lock_Edit(true);
                    this.SoTienConLai();
                    if ((this.fgPhieuChiDinh.Rows.Count - 1) > 0)
                    {
                        this.Load_PhieuDieutri_ChiTiet(this.fgPhieuChiDinh.Row);
                    }
                }
                catch (Exception exception)
                {
                    transaction.Rollback();
                    MessageBox.Show("C\x00f3 lỗi khi ghi dữ liệu\n" + exception.Message, "Th\x00f4ng b\x00e1o", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                finally
                {
                    command.Dispose();
                    transaction.Dispose();
                }
            }
        }
        private void Load_PhieuDieutri_ChiTiet(int r)
        {
            try
            {
                string str = this.fgPhieuChiDinh[r, "SoPhieu"].ToString();
                this.lblSoPhieu.Text = str;
                string cd = lblSoPhieu.Text.Substring(0, 2);
                this.txtNgayChiDinh.Value = (this.fgPhieuChiDinh[r, "NgayChiDinh"] == null) ? "" : this.fgPhieuChiDinh[r, "NgayChiDinh"];
                this.txtDienBienBenh.Text = (this.fgPhieuChiDinh[r, "DienBienBenh"] == null) ? "" : this.fgPhieuChiDinh[r, "DienBienBenh"].ToString();
                this.txtChanDoan.Text = (this.fgPhieuChiDinh[r, "ChanDoan"] == null) ? "" : this.fgPhieuChiDinh[r, "ChanDoan"].ToString();
                this.richTextBox1.Text = (this.fgPhieuChiDinh[r, "YLenh"] == null) ? "" : this.fgPhieuChiDinh[r, "YLenh"].ToString();
                Global.SetCmb(this.cmbCheDoChamSoc, this.fgPhieuChiDinh[r, "CDChamSoc"].ToString());
                Global.SetCmb(this.cmbCheDoDinhDuong, this.fgPhieuChiDinh[r, "CDDinhDuong"].ToString());
                this.chCapCuu.Checked = this.fgPhieuChiDinh.GetDataDisplay(r, "CapCuu") != "0";
                //this.chk_Covid.Checked = this.fgPhieuChiDinh.GetDataDisplay(r, "isPhieudieutri_Covid") != "0";
                this.lblKhoa.Text = (this.fgPhieuChiDinh[r, "TenKhoa"] == null) ? "" : this.fgPhieuChiDinh[r, "TenKhoa"].ToString();
                this.cmbNhomMau.SelectedIndex = int.Parse(this.fgPhieuChiDinh[r, "NhomMau"].ToString());
                cmbBacSyDT.Text = this.fgPhieuChiDinh[r, "BacSyDT"].ToString();
                if (Global.GetCode(this.cmbKhoa) != this.fgPhieuChiDinh[r, "MaKhoa"].ToString())
                {
                   
                    //this.cmdSua.Enabled = false;
                    this.cmdXoa.Enabled = false;
                }
                else
                {
                    this.cmdSua.Enabled = true;
                    this.cmdXoa.Enabled = true;
                }
                if (Global.glbUName.ToLower() != this.fgPhieuChiDinh[r, "UN"].ToString().ToLower())
                {
                    //this.cmdSua.Enabled = false;
                    this.cmdXoa.Enabled = false;
                }
                else
                {
                    this.cmdSua.Enabled = true;
                    this.cmdXoa.Enabled = true;
                }
                //if (lblSoPhieu.Text.Substring(0, 2) == "CD")
                //{
                //    this.cmdSua.Enabled = true;
                //}
                SqlCommand command = new SqlCommand("", Global.ConnectSQL);
                //command.CommandText = string.Format("SELECT a.ChonDT,a.LoaiDichVu,TenLoaiDichVu,a.MaDichVu,TenDichVu,DVT,SoLuong,a.TyLe, SoLuongHT,SoLuongDuyet,a.DonGia,SoLuong*a.DonGia*a.TyLe/100 as ThanhTien,a.GhiChu,a.TinhPhi,a.DaThucHien,a.DuyetBHYT,a.KhoID,a.MaPhieuDuyet,a.DaDuyet,a.DaThanhToan,a.LanInTT,a.Chot,a.NgayChot,LanChuyenDT,MaPhieuCanQuang,a.TTThau,isnull(a.TyLeBHYT,c.TyLeBH) as TyLeBH FROM  (PHIEUDIEUTRI_CHITIET a INNER JOIN DMLOAIDICHVU b ON a.LoaiDichVu=b.MaLoaiDichVu)  INNER JOIN DMDICHVU c ON a.LoaiDichVu=c.LoaiDichVu AND a.MaDichVu=c.MaDichVu WHERE SoPhieu='{0}' Order By a.LoaiDichVu,TenDichVu", str);
                command.CommandText = string.Format("SELECT a.ChonDT,a.LoaiDichVu,TenLoaiDichVu,a.MaDichVu,TenDichVu,DVT,SoLuong,a.TyLe, SoLuongHT,SoLuongDuyet,a.DonGia,SoLuong*a.DonGia*a.TyLe/100 as ThanhTien,"
                    + "a.GhiChu,a.TinhPhi,a.DaThucHien,a.DuyetBHYT,a.KhoID,a.MaPhieuDuyet,a.DaDuyet,a.DaThanhToan,a.LanInTT,a.Chot,a.NgayChot,LanChuyenDT,MaPhieuCanQuang,a.TTThau,isnull(a.TyLeBHYT,c.TyLeBH) as TyLeBH,"
                    + " isnull(a.STT,thutu_kedon) as STT,MaPhieuHoan,DuyetHoan,MaDichVuDuyet,a.MaKhoaThucHien,a.MaMay,a.isPhieudieutri_chitiet_covid,c.dongia as GiaVP, c.dongiaBHYT as GiaBHYT,a.isT_Khac_CT,a.NguonT_Khac_CT,a.isVienTro_CT  "
                    + " FROM(PHIEUDIEUTRI_CHITIET a INNER JOIN DMLOAIDICHVU b ON a.LoaiDichVu = b.MaLoaiDichVu)"
                    + " INNER JOIN DMDICHVU c ON a.LoaiDichVu = c.LoaiDichVu AND a.MaDichVu = c.MaDichVu"
                    + " left join(select distinct d.thuocid,case	when d.MaDuongDung = N'2.05' then 1 when d.MaDuongDung = N'2.14' then 2"
                    + " when d.MaDuongDung = N'2.15' then 3"
                    + " when d.MaDuongDung = N'2.10' then 4"
                    + " when d.MaDuongDung = N'1.01' then 5"
                    + " when d.MaDuongDung = N'4.02' then 6"
                    + " when d.MaDuongDung = N'3.05' then 7 else 8  end as thutu_kedon"
                    + " from NAMDINH_DUOC.dbo.ThongTinThuoc d where d.NgayCongBo = (select distinct Max(e.NgayCongBo) from NAMDINH_DUOC.dbo.ThongTinThuoc e where d.ThuocID = e.ThuocID))X on x.ThuocID = c.MaDichvu"
                    + " WHERE SoPhieu = '{0}' Order By a.LoaiDichVu,STT,TenDichVu"
                , str);
                SqlDataReader reader = command.ExecuteReader();
                this.fgDichVu.Redraw = false;
                this.fgDichVu.Rows.Count = 1;
                for (int i = 1; reader.Read(); i++)
                {
                    this.fgDichVu.Rows.Add();
                    this.fgDichVu[i, "STT"] = reader["STT"];
                    this.fgDichVu[i, "LoaiDichVu"] = reader["LoaiDichVu"];
                    this.fgDichVu[i, "TenLoaiDV"] = reader["TenLoaiDichVu"];
                    this.fgDichVu[i, "MaDichVu"] = reader["MaDichVu"];
                    this.fgDichVu[i, "TenDichVu"] = reader["TenDichVu"];
                    this.fgDichVu[i, "DVTinh"] = reader["DVT"];
                    this.fgDichVu[i, "SoLuong"] = reader["SoLuong"];
                    this.fgDichVu[i, "DonGia"] = reader["DonGia"];
                    this.fgDichVu[i, "GhiChu"] = reader["GhiChu"];
                    this.fgDichVu[i, "TyLe"] = reader["TyLe"];
                    this.fgDichVu[i, "ThanhTien"] = reader["ThanhTien"];
                    this.fgDichVu[i, "DaThucHien"] = reader["DaThucHien"];
                    if (lblSoPhieu.Text.Substring(0, 2) == "CD")
                    {
                        this.cmdSua.Enabled = true;
                    }
                    this.fgDichVu[i, "KhongTinhPhi"] = reader["TinhPhi"].ToString();
                    this.fgDichVu[i, "LuotIn"] = reader["DuyetBHYT"].ToString();
                    this.fgDichVu[i, "SoLuongCu"] = reader["SoLuong"];
                    this.fgDichVu[i, "SoLuongHT"] = reader["SoLuongHT"];
                    this.fgDichVu[i, "SoLuongDuyet"] = reader["SoLuongDuyet"];
                    this.fgDichVu[i, "KhoID"] = reader["KhoID"];
                    this.fgDichVu[i, "MaPhieuDuyet"] = reader["MaPhieuDuyet"];
                    this.fgDichVu[i, "DaDuyet"] = reader["DaDuyet"];
                    this.fgDichVu[i, "DaThanhToan"] = reader["DaThanhToan"];
                    this.fgDichVu[i, "LanInTT"] = reader["LanInTT"];
                    this.fgDichVu[i, "LanChuyenDT"] = reader["LanChuyenDT"];
                    this.fgDichVu[i, "Chot"] = reader["Chot"];
                    this.fgDichVu[i, "NgayChot"] = reader["NgayChot"];
                    this.fgDichVu[i, "MaPhieuCanQuang"] = reader["MaPhieuCanQuang"];
                    this.fgDichVu[i, "TTThau"] = reader["TTThau"];
                    this.fgDichVu[i, "TyleBH"] = reader["TyleBH"];
                    this.cmbDoiTuong.SelectedIndex = this.cmbDoiTuong.FindStringExact(reader["ChonDT"].ToString(), 0, 0);
                    this.fgDichVu[i, "MaPhieuHoan"] = reader["MaPhieuHoan"];
                    this.fgDichVu[i, "DuyetHoan"] = reader["DuyetHoan"];
                    this.fgDichVu[i, "MaDichVuDuyet"] = reader["MaDichVuDuyet"];
                    this.fgDichVu[i, "MaKhoaThucHien"] = reader["MaKhoaThucHien"];
                    this.fgDichVu[i, "MaMay"] = reader["MaMay"];
                    this.fgDichVu[i, "isPhieudieutri_chitiet_covid"] = reader["isPhieudieutri_chitiet_covid"];
                    this.fgDichVu[i, "GiaVP"] = reader["GiaVP"];
                    this.fgDichVu[i, "GiaBHYT"] = reader["GiaBHYT"];
                    this.fgDichVu[i, "isT_Khac_CT"] = reader["isT_Khac_CT"];
                    this.fgDichVu[i, "NguonT_Khac_CT"] = reader["NguonT_Khac_CT"];
                    this.fgDichVu[i, "isVienTro_CT"] = reader["isVienTro_CT"];

                }
                this.Format_Grid();
              //  this.fgDichVu.Redraw = true;
                reader.Close();
                command.Dispose();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
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
            // fgDichVu.AutoSizeCols();
            // fgDichVu.Styles.Normal.WordWrap = true;
            if (fgDichVu.Cols.Count > 2)
                {
                    fgDichVu.Cols[fgDichVu.Cols["TenDichVu"].Index].Width = 300;
                    fgDichVu.AutoSizeCols( fgDichVu.Cols["GhiChu"].Index);
                }
            fgDichVu.AutoSizeRows();
            fgDichVu.Redraw = true;
            lblDichVu.Text = "Dịch vụ y tế chỉ định ( " + SoKhoan.ToString() + " ) khoản";
        }
        private void fgPhieuChiDinh_AfterSelChange(object sender, C1.Win.C1FlexGrid.RangeEventArgs e)
        {
            
        }

        private void cmdSua_Click(object sender, EventArgs e)
        {
            if (lblSoPhieu.Text == "0") return;
            if (raChiPhiHN.Checked == false && raChiPhiTT.Checked == false)
            {
                MessageBox.Show("Chọn lên chí phí trong ngày hay trong trực.", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Lock_Edit(false);
            IsAddnew = false;
            if(chk_Covid.Checked == true)
            {
                PhieuCovid = 1;
            }
            else
            {
                PhieuCovid = 0;
            }
            if (fgPhieuChiDinh.GetDataDisplay(fgPhieuChiDinh.Row, "MaKhoa") != Global.GetCode(cmbKhoa) && lblSoPhieu.Text.Substring(0, 2) == "NT")
            {
                MessageBox.Show("Phiếu này được lập bởi khoa khác.\nBạn không thể sửa.", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
            System.Data.SqlClient.SqlDataReader dr1;
            SQLCmd.CommandText = string.Format("SELECT * from NAMDINH_QLBN.dbo.BENHNHAN_CHITIET where mavaovien = '{0}' and daravien = 1", txtMaVaoVien.Text);
            dr1 = SQLCmd.ExecuteReader();
            if (dr1.HasRows)
            {
                MessageBox.Show("Bệnh nhân đã ra viện", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dr1.Close();
                return;
                
            }
            dr1.Close();
        }

        private void cmdChiDinh_Click(object sender, EventArgs e)
        {
            if(lblSoPhieu.Text.Substring(0,2)== "CD")
            {
                MessageBox.Show("Chỉ định không được thêm mới", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaVaoVien.Text == "181124045" || txtMaVaoVien.Text == "181122104" || txtMaVaoVien.Text == "181124100")
            {
                MessageBox.Show("Thẻ CT4 không còn giá trị đề nghị sửa về CT2", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            SqlCommand command = new SqlCommand("", Global.ConnectSQL);
            command.CommandText = string.Format("select MaVaoVien from tblmavaovien_0412 where MaVaoVien = '{0}'", txtMaVaoVien.Text);
            SqlDataReader reader = command.ExecuteReader();
            if(reader.HasRows == true)
            {
                MessageBox.Show("Thẻ KC2 không còn giá trị đề nghị sửa về KC4", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                reader.Close();
            }
            reader.Close();
            new frmNhapChiDinhChiPhi(this.fgDichVu, "1", Global.GetCode(this.cmbKhoa), NgayKham).ShowDialog();
        }
        private void fgDichVu_AfterDeleteRow(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            Format_Grid();
        }

        private void fgDichVu_BeforeEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            //if (fgDichVu.Tag.ToString() == "0") return;
            if (fgDichVu.Rows[e.Row].IsNode) e.Cancel = true;
            if (!AllowEditDele() && fgDichVu.Cols[fgDichVu.Col].Name.Trim().ToLower() != "ghichu")
            {
                e.Cancel = true;
            }
            // SON THEM
            if (fgDichVu.GetDataDisplay(fgDichVu.Row, "DonGia") != "0" && fgDichVu.Cols[fgDichVu.Col].Name.Trim().ToLower() == "dongia")
            {
                e.Cancel = true;
            }

            //if (decimal.Parse(fgDichVu.GetData(e.Row, "SoLuong").ToString()) < 1 && fgDichVu.GetData(e.Row, "MaDichVu").ToString().Substring(0, 1) == "C")
            //{
            //    e.Cancel = true;
            //}
        }
        private void fgDichVu_AfterEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            //Huy thêm ngày 8/5/2015: Không cho đánh dấu Không tính phí các dịch vụ không phải là: 
            SqlCommand command = new SqlCommand("", Global.ConnectSQL);
            command.CommandText = string.Format("SELECT distinct  MADICHVU,TyleBHYT FROM DM_INPHIEUTHANHTOAN WHERE MADICHVU = '{0}'", fgDichVu.GetDataDisplay(fgDichVu.Row, "MaDichVu").ToString());
            SqlDataReader reader = command.ExecuteReader();
            string TyleBHYT = "";
            while(reader.Read())
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
            decimal SL =decimal.Parse(fgDichVu.GetData(e.Row, "SoLuong").ToString());
            decimal DonGia =decimal.Parse(fgDichVu.GetData(e.Row, "DonGia").ToString());
            decimal TyLe = decimal.Parse(fgDichVu.GetData(e.Row, "TyLe").ToString());
            if (TyLe == 0) TyLe = 100;
            fgDichVu[e.Row, "ThanhTien"] = SL * DonGia * TyLe /100;
            fgDichVu.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.Clear, 0, 0, 0);
            fgDichVu.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.Sum, 0, 2, fgDichVu.Cols["ThanhTien"].Index, "{0}");
        }
        private void Copy()
        {
            bool DaCoThuoc = false;
            for (int i = 1; i < this.fgDichVu.Rows.Count; i++)
            {
                if (!(this.fgDichVu.Rows[i].IsNode || !(this.fgDichVu[i, "DaThucHien"].ToString().ToLower() == "true")))
                {
                    MessageBox.Show("đ\x00e3 c\x00f3 ch\x00ed ph\x00ed thực hiện. Bạn kh\x00f4ng thể copy đ\x00e8 l\x00ean", "X\x00e1c nhận", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
            }
            if (this.fgDichVu.Rows.Count > 1)
            {
                DaCoThuoc = true;
                if (MessageBox.Show("đ\x00e3 c\x00f3 thuốc trong Phiếu điều trị, nếu copy đơn thuốc sẽ x\x00f3a hết thuốc đ\x00e3 c\x00f3 trong phiếu.\nBạn c\x00f3 chắc muốn copy kh\x00f4ng?", "X\x00e1c nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
            }
            this.fgDichVu.Redraw = false;
            if (DaCoThuoc)
            {
                this.fgDichVu.Rows.Count = 1;
            }
            SqlCommand command = new SqlCommand("", Global.ConnectSQL);
            SqlDataReader reader;
            if (Global.GetCode(cmbKhoa) == "NV1212")
            {

                command.CommandText = "set dateformat dmy SELECT a.TyLe, a.LoaiDichVu,c.TenLoaiDichVu,a.MaDichVu,d.TenDichVu,d.DVT,a.SoLuong,a.GhiChu,a.TinhPhi,";
                if (NgayKham <= DateTime.Parse("31/12/2019 23:59:59"))
                {
                    if (this.MaDoiTuongBN == "1")
                    {
                        command.CommandText = command.CommandText + "isNull(d.DongiaBHYT,0) As DonGia,isNull(a.SoLuong*d.DongiaBHYT*a.TyLe/100,0) As ThanhTien,d.KhoID,isnull(a.TyLeBHYT,d.TyLeBHYT) as TyleBH,a.STT, a.TTThau,a.isPhieudieutri_chitiet_covid,d.dongia as GiaVP,d.dongiaBHYT as GiaBHYT,a.isT_Khac_CT,a.NguonT_Khac_CT,a.isVienTro_CT  ";
                    }
                    else
                    {
                        command.CommandText = command.CommandText + "isNull(d.GiaVienPhi01010220,0) As DonGia,isNull(a.SoLuong*d.GiaVienPhi01010220*a.TyLe/100,0) As ThanhTien,d.KhoID,isnull(a.TyLeBHYT,d.TyLeBHYT) as TyleBH, a.STT,a.TTThau,a.isPhieudieutri_chitiet_covid,d.dongia as GiaVP,d.dongiaBHYT as GiaBHYT,a.isT_Khac_CT,a.NguonT_Khac_CT,a.isVienTro_CT ";
                    }
                    command.CommandText = command.CommandText + string.Format(" FROM ((PHIEUDIEUTRI_CHITIET a INNER JOIN BENHNHAN_PHIEUDIEUTRI b ON a.SoPhieu=b.SoPhieu) INNER JOIN DMLOAIDICHVU c ON a.LoaiDichVu=c.MaLoaiDichVu) INNER JOIN DMLENCHIPHI_BYKHOID d ON a.MaDichVu=d.maDichVu and a.LoaiDichVu=d.LoaiDichVu and d.khongsudung = 0  ", Global.gblNoiNgoai);//--and (d.NoiNgoai = {0} or d.NoiNgoai = 2)
                    if (this.IsAddnew)
                    {
                        command.CommandText = command.CommandText + string.Format(" where a.sophieu = '{0}' AND a.LoaiDichVu in ('D01','D02','B01','B02','D06','C02')", this.lblSoPhieu.Text);
                    }
                    else
                    {
                        command.CommandText = command.CommandText + string.Format(" WHERE a.SoPhieu = (SELECT max(SoPhieu) FROM BENHNHAN_PHIEUDIEUTRI WHERE  MaVaoVien='{0}' and SoPhieu <> '{1}') AND a.LoaiDichVu in ('D01','D02','B01','B02','D06','C02') ", this.txtMaVaoVien.Text, this.lblSoPhieu.Text);
                    }
                    command.CommandText = command.CommandText + " Group by a.LoaiDichVu,c.TenLoaiDichVu,a.MaDIchVu,d.TenDichVu,d.DVT,a.TinhPhi, a.SoLuong,a.GhiChu,d.DonGia,d.GiaVienPhi01010220,d.DonGiaBHYT,d.KhoID, a.TyLe,a.TyLeBHYT,d.TyLeBHYT,a.STT,a.TTThau,a.isPhieudieutri_chitiet_covid,a.isT_Khac_CT,a.NguonT_Khac_CT,a.isVienTro_CT  Order By a.LoaiDichVu,a.STT,TenDichVu ";

                }
                else
                {
                    if (this.MaDoiTuongBN == "1")
                    {
                        command.CommandText = command.CommandText + "isNull(d.DonGiaBHYT,0) As DonGia,isNull(a.SoLuong*d.DonGiaBHYT*a.TyLe/100,0) As ThanhTien,d.KhoID,isnull(a.TyLeBHYT,d.TyLeBHYT) as TyleBH, a.STT, a.TTThau,a.isPhieudieutri_chitiet_covid,d.dongia as GiaVP,d.dongiaBHYT as GiaBHYT,a.isT_Khac_CT,a.NguonT_Khac_CT,a.isVienTro_CT ";
                    }
                    else
                    {
                        command.CommandText = command.CommandText + "isNull(d.DonGia,0) As DonGia,isNull(a.SoLuong*d.DonGia*a.TyLe/100,0) As ThanhTien,d.KhoID,isnull(a.TyLeBHYT,d.TyLeBHYT) as TyleBH,a.STT,a.TTThau,a.isPhieudieutri_chitiet_covid,d.dongia as GiaVP,d.dongiaBHYT as GiaBHYT,a.isT_Khac_CT,a.NguonT_Khac_CT,a.isVienTro_CT ";
                    }
                    command.CommandText = command.CommandText + string.Format(" FROM ((PHIEUDIEUTRI_CHITIET a INNER JOIN BENHNHAN_PHIEUDIEUTRI b ON a.SoPhieu=b.SoPhieu) INNER JOIN DMLOAIDICHVU c ON a.LoaiDichVu=c.MaLoaiDichVu) INNER JOIN DMLENCHIPHI_BYKHOID d ON a.MaDichVu=d.maDichVu AND a.LoaiDichVu=d.LoaiDichVu and d.khongsudung = 0 ", Global.gblNoiNgoai);//--and (d.NoiNgoai = {0} or d.NoiNgoai = 2)
                    if (this.IsAddnew)
                    {
                        command.CommandText = command.CommandText + string.Format(" where a.sophieu = '{0}' AND a.LoaiDichVu in ('D01','D02','B01','B02','D06','C02')", this.lblSoPhieu.Text);
                    }
                    else
                    {
                        command.CommandText = command.CommandText + string.Format(" WHERE a.SoPhieu = (SELECT max(SoPhieu) FROM BENHNHAN_PHIEUDIEUTRI WHERE  MaVaoVien='{0}' and SoPhieu <> '{1}') AND a.LoaiDichVu in ('D01','D02','B01','B02','D06','C02') ", this.txtMaVaoVien.Text, this.lblSoPhieu.Text);
                    }
                    command.CommandText = command.CommandText + " Group by a.LoaiDichVu,c.TenLoaiDichVu,a.MaDIchVu,d.TenDichVu,d.DVT,a.TinhPhi, a.SoLuong,a.GhiChu,d.DonGia,d.DonGiaBHYT,d.KhoID, a.TyLe,a.TyLeBHYT,d.TyLeBHYT,a.STT,a.TTThau,a.isPhieudieutri_chitiet_covid ,a.isT_Khac_CT,a.NguonT_Khac_CT,a.isVienTro_CT Order By a.LoaiDichVu,a.STT,TenDichVu";

                }
                command.CommandTimeout = 0;
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    this.fgDichVu.AddItem(string.Format("|{0}|{1}|{2}|{3}|{4}|{5:#,##0.##}|{6:#,##0.##}|{7}|{8:#,##0.##}|{9}|{10}|{11}||{12}|{13}|||||||||||{15}|{14}|{16}||||||{17}|{18}|{19}|{20}|{21}|", new object[]
                    { reader["LoaiDichVu"], reader["tenLoaiDichVu"], reader["MaDichVu"], reader["tenDichVu"], reader["DVT"], reader["SoLuong"], reader["DonGia"], reader["TyLe"], reader["ThanhTien"], reader["GhiChu"], reader["TinhPhi"], 0, 0, reader["KhoID"],reader["TyleBH"],reader["TTThau"],reader["isPhieudieutri_chitiet_covid"],reader["GiaVP"],reader["GiaBHYT"],reader["isT_Khac_CT"],reader["NguonT_Khac_CT"],reader["isVienTro_CT"]}));
                }
                this.Format_Grid();
                this.fgDichVu.Redraw = true;
                reader.Close();
                command.Dispose();

            }
            else
            {
                command.CommandText = "set dateformat dmy SELECT a.TyLe, a.LoaiDichVu,c.TenLoaiDichVu,a.MaDichVu,d.TenDichVu,d.DVT,a.SoLuong,a.GhiChu,a.TinhPhi,";
                if (NgayKham <= DateTime.Parse("31/12/2019 23:59:59"))
                {
                    if (this.MaDoiTuongBN == "1")
                    {
                        command.CommandText = command.CommandText + "isNull(d.DongiaBHYT,0) As DonGia,isNull(a.SoLuong*d.DongiaBHYT*a.TyLe/100,0) As ThanhTien,d.KhoID,isnull(a.TyLeBHYT,d.TyLeBHYT) as TyleBH,a.STT, a.TTThau,a.isPhieudieutri_chitiet_covid,d.dongia as GiaVP,d.dongiaBHYT as GiaBHYT,a.isT_Khac_CT,a.NguonT_Khac_CT,a.isVienTro_CT ";
                    }
                    else
                    {
                        command.CommandText = command.CommandText + "isNull(d.GiaVienPhi01010220,0) As DonGia,isNull(a.SoLuong*d.GiaVienPhi01010220*a.TyLe/100,0) As ThanhTien,d.KhoID,isnull(a.TyLeBHYT,d.TyLeBHYT) as TyleBH, a.STT,a.TTThau,a.isPhieudieutri_chitiet_covid,d.dongia as GiaVP,d.dongiaBHYT as GiaBHYT,a.isT_Khac_CT,a.NguonT_Khac_CT,a.isVienTro_CT";
                    }
                    command.CommandText = command.CommandText + string.Format(" FROM ((PHIEUDIEUTRI_CHITIET a INNER JOIN BENHNHAN_PHIEUDIEUTRI b ON a.SoPhieu=b.SoPhieu) INNER JOIN DMLOAIDICHVU c ON a.LoaiDichVu=c.MaLoaiDichVu) INNER JOIN DMLENCHIPHI_BYKHOID d ON a.MaDichVu=d.maDichVu AND  a.KhoID = d.KhoID and a.LoaiDichVu=d.LoaiDichVu and d.khongsudung = 0  ", Global.gblNoiNgoai);//--and (d.NoiNgoai = {0} or d.NoiNgoai = 2)
                    if (this.IsAddnew)
                    {
                        command.CommandText = command.CommandText + string.Format(" where a.sophieu = '{0}' AND a.LoaiDichVu in ('D01','D02','B01','B02','D06','C02')", this.lblSoPhieu.Text);
                    }
                    else
                    {
                        command.CommandText = command.CommandText + string.Format(" WHERE a.SoPhieu = (SELECT max(SoPhieu) FROM BENHNHAN_PHIEUDIEUTRI WHERE  MaVaoVien='{0}' and SoPhieu <> '{1}') AND a.LoaiDichVu in ('D01','D02','B01','B02','D06','C02') ", this.txtMaVaoVien.Text, this.lblSoPhieu.Text);
                    }
                    command.CommandText = command.CommandText + " Group by a.LoaiDichVu,c.TenLoaiDichVu,a.MaDIchVu,d.TenDichVu,d.DVT,a.TinhPhi, a.SoLuong,a.GhiChu,d.DonGia,d.GiaVienPhi01010220,d.DonGiaBHYT,d.KhoID, a.TyLe,a.TyLeBHYT,d.TyLeBHYT,a.STT,a.TTThau,a.isPhieudieutri_chitiet_covid,a.isT_Khac_CT,a.NguonT_Khac_CT,a.isVienTro_CT Order By a.LoaiDichVu,a.STT,TenDichVu ";

                }
                else
                {
                    if (this.MaDoiTuongBN == "1")
                    {
                        command.CommandText = command.CommandText + "isNull(d.DonGiaBHYT,0) As DonGia,isNull(a.SoLuong*d.DonGiaBHYT*a.TyLe/100,0) As ThanhTien,d.KhoID,isnull(a.TyLeBHYT,d.TyLeBHYT) as TyleBH, a.STT, a.TTThau,a.isPhieudieutri_chitiet_covid,d.dongia as GiaVP,d.dongiaBHYT as GiaBHYT,a.isT_Khac_CT,a.NguonT_Khac_CT,a.isVienTro_CT ";
                    }
                    else
                    {
                        command.CommandText = command.CommandText + "isNull(d.DonGia,0) As DonGia,isNull(a.SoLuong*d.DonGia*a.TyLe/100,0) As ThanhTien,d.KhoID,isnull(a.TyLeBHYT,d.TyLeBHYT) as TyleBH,a.STT,a.TTThau,a.isPhieudieutri_chitiet_covid,d.dongia as GiaVP,d.dongiaBHYT as GiaBHYT,a.isT_Khac_CT,a.NguonT_Khac_CT,a.isVienTro_CT ";
                    }
                    command.CommandText = command.CommandText + string.Format(" FROM ((PHIEUDIEUTRI_CHITIET a INNER JOIN BENHNHAN_PHIEUDIEUTRI b ON a.SoPhieu=b.SoPhieu) INNER JOIN DMLOAIDICHVU c ON a.LoaiDichVu=c.MaLoaiDichVu) INNER JOIN DMLENCHIPHI_BYKHOID d ON a.MaDichVu=d.maDichVu and a.KhoID = d.KhoID AND a.LoaiDichVu=d.LoaiDichVu and d.khongsudung = 0 ", Global.gblNoiNgoai);//--and (d.NoiNgoai = {0} or d.NoiNgoai = 2)
                    if (this.IsAddnew)
                    {
                        command.CommandText = command.CommandText + string.Format(" where a.sophieu = '{0}' AND a.LoaiDichVu in ('D01','D02','B01','B02','D06','C02')", this.lblSoPhieu.Text);
                    }
                    else
                    {
                        command.CommandText = command.CommandText + string.Format(" WHERE a.SoPhieu = (SELECT max(SoPhieu) FROM BENHNHAN_PHIEUDIEUTRI WHERE  MaVaoVien='{0}' and SoPhieu <> '{1}') AND a.LoaiDichVu in ('D01','D02','B01','B02','D06','C02') ", this.txtMaVaoVien.Text, this.lblSoPhieu.Text);
                    }
                    command.CommandText = command.CommandText + " Group by a.LoaiDichVu,c.TenLoaiDichVu,a.MaDIchVu,d.TenDichVu,d.DVT,a.TinhPhi, a.SoLuong,a.GhiChu,d.DonGia,d.DonGiaBHYT,d.KhoID, a.TyLe,a.TyLeBHYT,d.TyLeBHYT,a.STT,a.TTThau,a.isPhieudieutri_chitiet_covid,a.isT_Khac_CT,a.NguonT_Khac_CT,a.isVienTro_CT Order By a.LoaiDichVu,a.STT,TenDichVu";

                }
                command.CommandTimeout = 0;
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    this.fgDichVu.AddItem(string.Format("|{0}|{1}|{2}|{3}|{4}|{5:#,##0.##}|{6:#,##0.##}|{7}|{8:#,##0.##}|{9}|{10}|{11}||{12}|{13}|||||||||||{15}|{14}|{16}||||||{17}|{18}|{19}|{20}|{21}|", new object[]
                    { reader["LoaiDichVu"], reader["tenLoaiDichVu"], reader["MaDichVu"], reader["tenDichVu"], reader["DVT"], reader["SoLuong"], reader["DonGia"], reader["TyLe"], reader["ThanhTien"], reader["GhiChu"], reader["TinhPhi"], 0, 0, reader["KhoID"],reader["TyleBH"],reader["TTThau"],reader["isPhieudieutri_chitiet_covid"],reader["GiaVP"],reader["GiaBHYT"],reader["isT_Khac_CT"],reader["NguonT_Khac_CT"],reader["isVienTro_CT"]}));
                }
                this.Format_Grid();
                this.fgDichVu.Redraw = true;
                reader.Close();
                command.Dispose();
            }
         }
        private void cmdCopy_Click(object sender, EventArgs e)
        {
            if(lblSoPhieu.Text != "")
            {
                if (lblSoPhieu.Text.Substring(0, 2) == "CD")
                {
                    MessageBox.Show("Chỉ định không được thêm mới", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

            }
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
            //Kiem tra xem da in chua
            SQLCmd.CommandText = String.Format("Select Is_In from BenhNHan_PhieuDieutri where sophieu='{0}'", lblSoPhieu.Text.Trim());
            try
            {
                if (SQLCmd.ExecuteScalar().ToString() == "1")
                {
                    MessageBox.Show("Phiếu này đã được in. Bạn không thể copy đè lên!.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch { };
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
                SQLCmd.CommandText = string.Format("DELETE FROM PHIEUDIEUTRI_CHITIET WHERE SoPhieu='{0}'", fgPhieuChiDinh[fgPhieuChiDinh.Row, "SoPhieu"].ToString());
                SQLCmd.ExecuteNonQuery();
                //SQLCmd.CommandText = string.Format("DELETE FROM tbl_MaVaoVien_Dichvu WHERE  MaVaoVien='{0}'",txtMaVaoVien.Text);
                //SQLCmd.ExecuteNonQuery();
                trn.Commit();
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
            SQLCmd.CommandText = string.Format(" update  BENHNHAN_PHIEUDIEUTRI SET isDelete = 1, IsDateDelete = '{2:dd/MM/yyyy HH:mm}' WHERE SoPhieu='{0}' AND MaVaoVien='{1}'", fgPhieuChiDinh[fgPhieuChiDinh.Row, "SoPhieu"].ToString(), txtMaVaoVien.Text, Global.GetNgayLV());
            SQLCmd.ExecuteNonQuery();
            fgPhieuChiDinh.RemoveItem(fgPhieuChiDinh.Row);
            SQLCmd.Dispose();
        }
        private void TruLaiSoVo()
        {
            SqlCommand command = new SqlCommand("", Global.ConnectSQL);
            SqlTransaction transaction = Global.ConnectSQL.BeginTransaction();
            command.Transaction = transaction;
            try
            {
                if (this.fgDichVu.Rows.Count > 1)
                {
                    command.CommandText = command.CommandText + string.Format(" if(exists(select * from dstravo where makhoa='{0}' and mathuoc = '{1}'))  begin if(exists(select * from benhnhan_travo inner join dstravo on dstravo.makhoa =  benhnhan_travo.makhoa and dstravo.makhoa ='{0}' where benhnhan_travo.makhoa='{0}' and benhnhan_travo.mathuoc='{1}')) begin update benhnhan_travo set soluongdsd = ", Global.GetCode(this.cmbKhoa), this.fgDichVu[this.fgDichVu.Row, "MaDichVu"]);
                    command.CommandText = command.CommandText + string.Format(" (select SoLuongDSD - {2} from benhnhan_travo where makhoa='{0}' and mathuoc ='{1}') where makhoa='{0}' and mathuoc ='{1}'", Global.GetCode(this.cmbKhoa), this.fgDichVu[this.fgDichVu.Row, "MaDichVu"], this.fgDichVu[this.fgDichVu.Row, "SoLuongCu"].ToString().Replace(",", "."));
                    command.CommandText = command.CommandText + string.Format(" end end", new object[0]);
                    command.ExecuteNonQuery();
                    transaction.Commit();
                }
            }
            catch (Exception exception)
            {
                transaction.Rollback();
                MessageBox.Show(exception.ToString());
            }
            finally
            {
                command.Dispose();
            }
        }

        private void fgDichVu_BeforeDeleteRow(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            //System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
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
                //SQLCmd.CommandText = string.Format("delete from tbl_MaVaoVien_Dichvu where mavaovien = '{0}' and madichvu = '{1}'",txtMaVaoVien.Text, this.fgDichVu.GetDataDisplay(e.Row, "MaDichVu"));
                //SQLCmd.ExecuteNonQuery();
                //SQLCmd.Dispose();
                TruLaiSoVo();
            }
        }

        private void mnuDichVu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void mnuXoa_Click(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            if (fgDichVu.Rows.Count <= 1) return;
            //if(fgPhieuChiDinh.GetDataDisplay(fgPhieuChiDinh.Row,"SoPhieu").ToString().Substring(0,2) == "CD")
            //{
            //    MessageBox.Show("dịch vụ ngoại trú bạn không xóa được", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}

            if (!AllowEditDele())
            {
                MessageBox.Show("đã thực hiện. Không thể thay đổi.", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không.", "Thông báo.", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (fgPhieuChiDinh.GetDataDisplay(fgPhieuChiDinh.Row, "SoPhieu").ToString().Substring(0, 2) == "CD")
                {
                    SQLCmd.CommandText = string.Format("delete from namdinh_khambenh.dbo.tblkhambenh_dichvu where maphieucd  = '{0}' and madichvu = '{1}'", fgPhieuChiDinh.GetDataDisplay(fgPhieuChiDinh.Row, "SoPhieu").ToString(), fgDichVu.GetDataDisplay(fgDichVu.Row, "MaDichVu"));
                    SQLCmd.ExecuteNonQuery();
                }
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
            //string s = this.fgDichVu[this.fgDichVu.Row, "DuyetHoan"].ToString();
            //string s1 = this.fgDichVu[this.fgDichVu.Row, "DaDuyet"].ToString();
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


        private void mnuThem_Click(object sender, EventArgs e)
        {
            cmdChiDinh_Click(sender,e);
        }

        private void cmdInPhieu_Click(object sender, EventArgs e)
        {
          try
            {
                System.Data.SqlClient.SqlDataReader dr;
                System.Data.SqlClient.SqlDataReader dr1;
                new repPhieuChiDinh_ketquaA5(this.txtHoTen.Text.Trim(), int.Parse(this.txtTuoi.Text.Trim()), this.txtGioi.Text, this.txtChanDoan.Text.Trim(), this.fgPhieuChiDinh.GetDataDisplay(this.fgPhieuChiDinh.Row, "TenKhoa").ToString(), int.Parse(this.fgPhieuChiDinh.GetDataDisplay(this.fgPhieuChiDinh.Row, "Nhom")), this.lblSoPhieu.Text.Trim(), this.txtNgayChiDinh.Value, cmbDieuduong.Text).Show();
                SqlCommand command = new SqlCommand("", Global.ConnectSQL);
                //SqlCommand command1 = new SqlCommand("", Global.ConnectSQL);
                //command1.CommandText = string.Format("select * from Namdinh_cls.dbo.pacstest where DaGui != 1 and MaChiDinh = '{0}'", lblSoPhieu.Text);
                //dr1 = command1.ExecuteReader();
                //while (dr1.Read())
                //{
                //    Moduls.clsMaDichVu clsDv = new Moduls.clsMaDichVu();
                //    clsDv.MaChiDinh = dr1["MaChiDinh"].ToString().Trim();
                //    clsDv.ThoiGianChiDinh = dr1["ThoiGianChiDinh"].ToString();
                //    clsDv.MaBenhNhan = dr1["MaBenhNhan"].ToString().Trim();
                //    clsDv.TenBenhNhan = dr1["TenBenhNhan"].ToString();
                //    clsDv.NgaySinh = dr1["NgaySinh"].ToString();
                //    clsDv.GioiTinh = dr1["GioiTinh"].ToString();
                //    clsDv.DiaChi = dr1["DiaChi"].ToString();
                //    clsDv.SDT = dr1["SDT"].ToString();
                //    clsDv.NoiChiDinh = dr1["NoiChiDinh"].ToString();
                //    clsDv.MaBacSiChiDinh = dr1["MaBacSiChiDinh"].ToString().Trim();
                //    clsDv.TenBacSiChiDinh = dr1["TenBacSiChiDinh"].ToString().Trim();
                //    clsDv.MaDichVu = dr1["MaDichVu"].ToString().Trim();
                //    clsDv.TenDichVu = dr1["TenDichVu"].ToString();
                //    clsDv.NhomDichVu = dr1["NhomDichVu"].ToString().Trim();
                //    clsDv.ChanDoan = dr1["ChanDoan"].ToString();
                //    clsDv.TrangThai = dr1["TrangThai"].ToString().Trim();
                //    using (var client = new WebClient())
                //    {
                //        var dataString = JsonConvert.SerializeObject(clsDv);
                //        client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                //        client.UploadString(new Uri("http://172.16.2.8:7777"), "POST", dataString);
                //    }

                //}
                //dr1.Close();
                //command1.CommandText = "";
                //command1.CommandText = string.Format("Update NAMDINH_CLS.DBO.pacstest set DaGui = 1 where MaChiDinh ='{0}'", this.lblSoPhieu.Text);
                //command1.ExecuteNonQuery();



                command.CommandText = string.Format("Update benhnhan_phieudieutri set Is_In = 1 where sophieu ='{0}'", this.lblSoPhieu.Text);
                command.ExecuteNonQuery();
                cmdToDieuTri_Click(sender, e);
                command.Dispose();
                //command1.Dispose();
                
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
            finally
            {
            }
        }

        private void frmChiDinhDieuTri_KeyDown(object sender, KeyEventArgs e)
        {
            
            //if (e.KeyCode == Keys.F5)
            //{
            //    if (cmdDanhSachBN.Enabled == false) return;
            //    if (cmbKhoa.SelectedIndex == -1)
            //    {
            //        MessageBox.Show("Chưa chọn khoa điều trị!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        cmbKhoa.Focus();
            //        return;
            //    }
            //    NamDinh_QLBN.Forms.DuLieu.frmShowDSBenhNhan fr = new frmShowDSBenhNhan("", Global.GetCode(cmbKhoa), "", 1, 0,MaNhom);
            //    fr.ShowDialog();
            //    if (fr.DialogResult == DialogResult.OK)
            //    {
            //        txtMaBenhAn.Text = fr.SoHSBAReturn;
            //        txtMaVaoVien.Text = fr.MaVaoVienReturn;
            //        txtHoTen.Text = fr.HoTenReturn;
            //        txtTuoi.Text = fr.TuoiReturn;
            //        txtGioi.Text = fr.GioiReturn;
            //        txtDoiTuong.Text = fr.TenDoiTuongReturn;
            //        txtNgayVaoVien.Text = fr.NgayVaoVienReturn;
            //        MaDoiTuongBN = fr.MaDoiTuongReturn;
            //        Load_PhieuChiDinh(txtMaVaoVien.Text);
            //        LoadDSLanSoKet(txtMaVaoVien.Text);
            //    }
            //}
            //if (cmdChiDinh.Visible == false)
            //{
            //    return;
            //}
            //else
            //{
            //    if (e.KeyCode == Keys.F4)
            //    {
            //        if (!cmdChiDinh.Visible) return;
            //        NamDinh_QLBN.Forms.DuLieu.frmNhapChiDinhChiPhi fr = new frmNhapChiDinhChiPhi(fgDichVu, MaDoiTuongBN, Global.GetCode(cmbKhoa), DateTime.Parse(txtNgayVaoVien.Text));
            //        fr.ShowDialog();
            //    }
            //    if (e.KeyCode == Keys.F3)
            //    {
            //        if (!cmdCopy.Visible) return;
            //        Copy();
            //    }
            //    if (e.KeyCode == Keys.F6)
            //    {
            //        NamDinh_QLBN.Forms.DuLieu.frmChiPhiTheoMatBenh frm = new frmChiPhiTheoMatBenh(fgDichVu, MaDoiTuongBN, Global.GetCode(cmbKhoa),txtNgayVaoVien.Text);
            //        frm.ShowDialog();
            //    }

            //}
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            frmThongTinKQ nkq = new frmThongTinKQ();
            nkq._MaVaoVien = this.txtMaVaoVien.Text;
            nkq.ShowDialog();
        }


        private void fgPhieuChiDinh_AfterRowColChange(object sender, C1.Win.C1FlexGrid.RangeEventArgs e)
        {
            cmdThuThuat.Enabled = false;
            Global.wait("Đang tổng hợp dữ liệu ....");
            if( _DaTinhPhi != "1" ||_DaRaVien != "1")
            {
                
                
                if ((this.fgPhieuChiDinh.Tag.ToString() == "0") || (this.fgPhieuChiDinh.Row < 1))
                {
                    Global.nowait();
                }
                else
                {
                    this.Load_PhieuDieutri_ChiTiet(this.fgPhieuChiDinh.Row);
                    Global.nowait();
                }
                //this.fgDichVu.ContextMenuStrip = this.contextMenuNhapLieu;
            }
            if(_DaTinhPhi == "1")
            {
                if ((this.fgPhieuChiDinh.Tag.ToString() == "0") || (this.fgPhieuChiDinh.Row < 1))
                {
                    Global.nowait();
                }
                else
                {
                    this.Load_PhieuDieutri_ChiTiet(this.fgPhieuChiDinh.Row);
                    cmdThem.Enabled = false;
                    cmdSua.Enabled = false;
                    cmdXoa.Enabled = false;
                    Global.nowait();
                }
            }
            
            if (_DaRaVien == "1")
            {
                if ((this.fgPhieuChiDinh.Tag.ToString() == "0") || (this.fgPhieuChiDinh.Row < 1))
                {
                    Global.nowait();
                }
                else
                {
                    this.Load_PhieuDieutri_ChiTiet(this.fgPhieuChiDinh.Row);
                    cmdThem.Enabled = false;
                    cmdSua.Enabled = false;
                    cmdXoa.Enabled = false;
                    Global.nowait();
                }
            }

        }
        private void button2_Click(object sender, EventArgs e) // kham chuyen khoa click
        {
            try
            {
                if (this.txtMaVaoVien.Text.Trim() != "")
                {
                    frmKhamChuyenKhoa khoa = new frmKhamChuyenKhoa(Global.GetCode(this.cmbKhoa), this.txtMaVaoVien.Text.Trim());
                    if (khoa.ShowDialog() == DialogResult.Yes)
                    {
                        //rptPhieuKhamChuyenKhoa khoa2 = new rptPhieuKhamChuyenKhoa(this.txtMaVaoVien.Text.Trim(), Global.GetCode(this.cmbKhoa));
                        //khoa2.Run();
                        //khoa2.Show();
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
            finally
            {
            }
        }

        private void cmdChiDinhTheoMatBenh_Click(object sender, EventArgs e)
        {
            if (lblSoPhieu.Text.Substring(0, 2) == "CD")
            {
                MessageBox.Show("Chỉ định không được thêm mới", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            new frmChiPhiTheoMatBenh(this.fgDichVu, this.MaDoiTuongBN, Global.GetCode(this.cmbKhoa), NgayKham, lblcovid.Text).ShowDialog();
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
            //if (fgDichVu.Cols["STT"].Selected)
            //{
            //fgDichVu.StartEditing(fgDichVu.Row, fgDichVu.Cols["STT"].Index);
            //}
            //tạm thời chưa dùng
            //if (fgDichVu.GetDataDisplay(fgDichVu.Row, "loaidichvu").Substring(0, 1) != "D" && fgDichVu.Cols[fgDichVu.Col].Name.Trim().ToLower() == "khongtinhphi")
            //{
            //    MessageBox.Show("Chỉ được đánh dấu không tính phí đối với Thuốc và VTTH");
            //    fgDichVu[fgDichVu.Row, "KhongTinhPhi"] = false;
            //}

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!(this.txtMaVaoVien.Text.Trim() == ""))
            {
                new frmSoKet15(this.txtMaVaoVien.Text).ShowDialog();
            }
        }

 
        private void cmdMau_Click(object sender, EventArgs e)
        {
            String Khoa = cmbKhoa.Text;
            String NgayIn = String.Format("In ngày {0:dd} tháng {0:MM} năm {0:yyyy}", Global.NgayLV);
            String NgaySD = String.Format("Ngày {0:dd} tháng {0:MM} năm {0:yyyy}", txtNgayChiDinh.Value);
            NamDinh_QLBN.Reports.repGiayXinMau rep1 = new NamDinh_QLBN.Reports.repGiayXinMau(txtMaVaoVien.Text,lblSoPhieu.Text,txtNgayChiDinh.Value,Khoa);
            NamDinh_QLBN.Reports.repGiayXinMau_2 rep = new NamDinh_QLBN.Reports.repGiayXinMau_2(txtMaVaoVien.Text, lblSoPhieu.Text, txtNgayChiDinh.Value, Khoa);
            rep.Show();
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
            frm.Show();
        }

        private void cmdMo_Click(object sender, EventArgs e)
        {
            if (txtMaVaoVien.Text.Trim() == "")
            {
                MessageBox.Show("Chọn bệnh nhân.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if ((fgDichVu.GetDataDisplay(fgDichVu.Row, "LoaiDichVu").CompareTo("C01") <0) || (fgDichVu.GetDataDisplay(fgDichVu.Row, "LoaiDichVu").CompareTo("C24") > 0))
            {
                MessageBox.Show("Phải chọn dịch vụ nhóm phẫu thuật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            NamDinh_QLBN.Forms.DuLieu.frmThongTinMo_Kipmo frm = new frmThongTinMo_Kipmo(txtMaVaoVien.Text.Trim(), lblSoPhieu.Text, fgDichVu.GetDataDisplay(fgDichVu.Row, "LoaiDichVu"), fgDichVu.GetDataDisplay(fgDichVu.Row, "MaDichVu"),Global.GetCode(cmbKhoa).ToString());
            if (frm.ShowDialog() == DialogResult.Yes)
            {
                NamDinh_QLBN.Reports.repGiayDuyetMo rep = new NamDinh_QLBN.Reports.repGiayDuyetMo(txtMaVaoVien.Text.Trim(),txtNgayChiDinh.Value,lblSoPhieu.Text.Trim());
                rep.Show();
                NamDinh_QLBN.Reports.repDuyetPhauThuat repDPT = new NamDinh_QLBN.Reports.repDuyetPhauThuat(txtMaVaoVien.Text.Trim(), txtNgayChiDinh.Value, lblSoPhieu.Text.Trim(), GlobalModuls.Global.glbMaKhoaPhong, GlobalModuls.Global.glbTenKhoaPhong);
                repDPT.Show();
            }
        }

        //private void cmdToDieuTri_Click(object sender, EventArgs e)
        //{
        //    //NamDinh_QLBN.Reports.repToDieuTri rep = new NamDinh_QLBN.Reports.repToDieuTri(txtMaVaoVien.Text.Trim(),Global.GetCode(cmbKhoa));
        //    //rep.Show();
        //    //MessageBox.Show(fgDichVu.GetDataDisplay(1, 4));
        //    if ((MaDoiTuongBN != "1") && (fgDichVu.GetDataDisplay(1,4) != "Chụp CT"))
        //    {
        //        MessageBox.Show("Bệnh nhân không phải đối tượng bảo hiểm y tế!!", "Thông báo", MessageBoxButtons.OK);
        //        return;
        //    }
        //    if (fgDichVu.Rows.Count < 2)
        //    {
        //        MessageBox.Show("Chưa có dịch vụ để in tích kê!!", "Thông báo", MessageBoxButtons.OK);
        //        return;
        //    }
        //    string XetNghiem = "";
        //    string SoTheBHYT = "";
        //    decimal TongTien = 0;
        //    System.Data.SqlClient.SqlDataReader dr;
        //    System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
        //    SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
        //    SQLCmd.CommandText = "SELECT TenDichVu,vd.maDoiTuongBHXH +' - '+ SoThe + ' - ' + vd.MaNoiCap AS SoThe,isnull(pc.SoLuong,0)* isnull(pc.DonGia,0) as ThanhTien FROM "
        //                        + " ((((PHIEUDIEUTRI_CHITIET pc INNER JOIN DMDICHVU d ON d.MaDichVu = pc.MaDichVu )"
        //                        + " INNER JOIN NAMDINH_CLS.dbo.DMDICHVU_CHISO dc ON dc.MaDichVu = d.MaDichVu)"
        //                        + " INNER JOIN NAMDINH_CLS.dbo.DMCHISO d1 ON d1.MaChiSo=dc.MaChiSo)"
        //                        + " INNER JOIN BENHNHAN_PHIEUDIEUTRI bp ON bp.SoPhieu = pc.SoPhieu)"
        //                        + " INNER JOIN ViewDOITUONGHIENTAI vd ON vd.MaVaoVien = bp.MaVaoVien"
        //                        + " WHERE pc.SoPhieu ='" + fgPhieuChiDinh.GetDataDisplay(fgPhieuChiDinh.Row, "SoPhieu") + "' AND (d1.MaMay = 2 OR d1.MaMay = 4 OR (d1.MaMay = 3  and d.tendichvu like N'%CT Scanner (Liên kết%') OR (d1.MaMay = 3  and d.tendichvu like N'%64 dãy%') OR (d1.Machiso = 'C55080')  OR (d1.Machiso = 'C55081') OR (d1.Machiso = '001') OR (d1.Machiso = '001002')) ";
        //    dr = SQLCmd.ExecuteReader();
        //    while (dr.Read())
        //    {
        //        XetNghiem += dr["TenDichVu"].ToString() + ", ";
        //        SoTheBHYT = dr["SoThe"].ToString();
        //        try
        //        {
        //            TongTien += decimal.Parse(dr["ThanhTien"].ToString());
        //        }
        //        catch { }
        //    }
        //    dr.Close();
        //    // SON THEM
        //    if (XetNghiem.Length >= 2)
        //    {
        //        XetNghiem = XetNghiem.Substring(0, XetNghiem.Length - 2);
        //        NamDinh_QLBN.Reports.rptTichKeXN rpt = new NamDinh_QLBN.Reports.rptTichKeXN();
        //        rpt.Barcode1.Text = fgPhieuChiDinh.GetDataDisplay(fgPhieuChiDinh.Row, "SoPhieu");
        //        rpt.lblTenBN.Text = txtHoTen.Text.ToUpper();
        //        rpt.lblTenKhoa.Text = Global.glbTenKhoaPhong;
        //        rpt.lblDoiTuong.Text =  txtDoiTuong.Text;
        //        rpt.lblSoThe.Text = SoTheBHYT;
        //        rpt.lblXetNghiem.Text = XetNghiem;
        //        rpt.txtTongTien.Value = TongTien;
        //        rpt.lblBacSiCD.Text = fgPhieuChiDinh.GetDataDisplay(fgPhieuChiDinh.Row, "BacSyDT");
        //        rpt.lblNgayThang.Text = string.Format("{0:HH} giờ {0:mm} - Ngày {0:dd} tháng {0:MM} năm {0:yyyy}", txtNgayChiDinh.Value);
        //        rpt.Show();
        //    }
        //}
        private void cmdToDieuTri_Click(object sender, EventArgs e)
        {
            //NamDinh_QLBN.Reports.repToDieuTri rep = new NamDinh_QLBN.Reports.repToDieuTri(txtMaVaoVien.Text.Trim(),Global.GetCode(cmbKhoa));
            //rep.Show();
            //MessageBox.Show(fgDichVu.GetDataDisplay(1, 4));
            bool MienDich = false;
            string DichVuMienDich = "C50075,C50026,C50027,C50028,C50029,C50030,C50031,C50032,C50033,C50078,C50080,C50133,C50134,C50135,C50137,C58000,C58001,C50136,C50322";
            bool SinhHoaMau = false;
            string DichVuSinhHoaMau = "C50001,C50002,C50004,C50008,C50009,C50003,C50130,C50012,C50013,C50014,C50015,C50010,C50011,C50113,C50073,C50006,C50072,C50018,C50020,C50021,C50022,C50023,C50025,C50095,C50096,C50115,C50005,C50119,C50313,C50138,C50314,C50323,C50324";
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
                                        + " ((((PHIEUDIEUTRI_CHITIET pc INNER JOIN DMDICHVU d ON d.MaDichVu = pc.MaDichVu and pc.loaidichvu != 'C50')"
                                        + " INNER JOIN NAMDINH_CLS.dbo.DMDICHVU_CHISO dc ON dc.MaDichVu = d.MaDichVu)"
                                        + " INNER JOIN NAMDINH_CLS.dbo.DMCHISO d1 ON d1.MaChiSo=dc.MaChiSo and d1.MaKhoa not in ('NV2501','NV2504','NV250401'))"
                                        + " INNER JOIN BENHNHAN_PHIEUDIEUTRI bp ON bp.SoPhieu = pc.SoPhieu)"
                                        + " INNER JOIN ViewDOITUONGHIENTAI vd ON vd.MaVaoVien = bp.MaVaoVien"
                                        + " WHERE pc.SoPhieu ='" + fgPhieuChiDinh.GetDataDisplay(fgPhieuChiDinh.Row, "SoPhieu") + "' And pc.Loaidichvu = '" + fgDichVu.GetDataDisplay(Dong+1, "LoaiDichVu") + "' "
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
                        SqlCommand command = new SqlCommand("", Global.ConnectSQL);
                        command.CommandText = "exec SaveTichKe @SoTichKe, @MaphieuCD, @NoiDung, @SoTien, @SoKhoan";
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@SoTichKe", txtMaVaoVien.Text);
                        command.Parameters.AddWithValue("@MaphieuCD", fgPhieuChiDinh.GetDataDisplay(fgPhieuChiDinh.Row, "SoPhieu"));
                        command.Parameters.AddWithValue("@NoiDung", XetNghiem);
                        command.Parameters.AddWithValue("@SoTien", TongTien);
                        command.Parameters.AddWithValue("@SoKhoan", SoKhoan);
                        command.ExecuteNonQuery();
                        command.Dispose();
                    }
                }
            }
            
        }
        private void cmdKetQuaXN_Click(object sender, EventArgs e)
        {
            if ((this.fgPhieuChiDinh.Rows.Count > 0) && (this.fgPhieuChiDinh.Row >= 0))
            {
                if (lblSoPhieu.Text.Trim() == "")
                {
                    MessageBox.Show("Chọn phiếu cần xem", "Th\x00f4ng b\x00e1o", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }

                else
                {
                    new FrmKetQuaXetNghiem(lblSoPhieu.Text.Trim()).ShowDialog();
                 
                }

            }
        }

        private void cmdThuThuat_Click(object sender, EventArgs e)
        {
            if (txtMaVaoVien.Text.Trim() == "")
            {
                MessageBox.Show("Chọn bệnh nhân.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if(lblSoPhieu.Text == "")
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
            NamDinh_QLBN.Forms.DuLieu.frmThongTinTT_KipTT frm = new frmThongTinTT_KipTT(txtMaVaoVien.Text.Trim(), lblSoPhieu.Text, fgDichVu.GetDataDisplay(fgDichVu.Row, "LoaiDichVu"), fgDichVu.GetDataDisplay(fgDichVu.Row, "MaDichVu"), txtNgayChiDinh.Text);
            //NamDinh_QLBN.Forms.DuLieu.frmThongTinTT frm = new frmThongTinTT(txtMaVaoVien.Text.Trim() );
            if (frm.ShowDialog() == DialogResult.Yes)
            {
                NamDinh_QLBN.Reports.repDuyetThuThuat rep = new NamDinh_QLBN.Reports.repDuyetThuThuat(txtMaVaoVien.Text.Trim(), lblSoPhieu.Text, fgDichVu.GetDataDisplay(fgDichVu.Row, "MaDichVu"), txtNgayChiDinh.Value);
                rep.Show();
            }
        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void c1Combo1_TextChanged(object sender, EventArgs e)
        {

        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            LaySoThuTu(txtMaVaoVien.Text);
            NamDinh_QLBN.Forms.Tien_ich.frmTungayDenngayMavv frm = new NamDinh_QLBN.Forms.Tien_ich.frmTungayDenngayMavv();
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;

            if (frm.ShowDialog() == DialogResult.OK)
            {
                SQLCmd.CommandText = string.Format("IF EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name like 'Ylenh_templ') DROP TABLE Namdinh_qlbn.dbo.Ylenh_templ");
                  SQLCmd.ExecuteNonQuery();
                SQLCmd.CommandText = "";
                SQLCmd.CommandText =  string.Format("set dateformat dmy HH:MM:SS: Create table NAMDINH_QLBN.dbo.Ylenh_templ"
                + " ("
                    + " Sothutu int,"
                    + " Stt Nvarchar(10),"
                    + " MaVaoVien Nvarchar(20),"
                    + " SoPhieu Nvarchar(12),"
                    + " NgayChiDinh Datetime,"
                    + " Ylenh Nvarchar(Max),"
                    + " TenLoaiDichvu Nvarchar(Max),"
                    + " BacSyDT Nvarchar(100),"
                    + " Ylenh_boxung Nvarchar(Max),tendichvu  Nvarchar(Max),soluong int, NhomThuoc  Nvarchar(20),ThuTu_KeDon int, MaDichVu Nvarchar(20),Nhom Nvarchar(20), DVT Nvarchar(20),TenCDChamSoc Nvarchar(100), TenCDDinhDuong Nvarchar(100) "
                + " );"
                + " declare @SoPhieu1 Nvarchar(20) declare @SoPhieu2 Nvarchar(20) declare @Sothutu int declare @MaVaoVien Nvarchar(20) declare @SoPhieu Nvarchar(20) declare @Ylenh Nvarchar(Max)   declare @NgayChiDinh Datetime"
                + " declare @Ylenh_boxung Nvarchar(Max) declare @TenLoaiDichvu Nvarchar(Max) declare @stt Nvarchar(3) declare @BacSyDT Nvarchar(100) declare @NgayChiDinh1 Datetime declare @NgayChiDinh2 Datetime declare @soluong int declare @tendichvu Nvarchar(Max) declare @NhomThuoc Nvarchar(20) declare @ThuTu_KeDon int declare @MaDichVu Nvarchar(20)declare @Nhom Nvarchar(20) declare @DVT Nvarchar(20)  declare @TenCDChamSoc Nvarchar(100) declare @TenCDDinhDuong Nvarchar(100)"
                + " DECLARE MyCursor CURSOR FOR"
                + " select a.MaVaoVien, b.SoPhieu, b.NgayChiDinh,e.Stt,"
                + " '  ' + c.Ghichu  as Ylenh,"
                + " loaidv.TenLoaiDichvu,b.Ylenh as Ylenh_boxung,b.BacSyDT,"
                + " d.TenThuocYLenh  + ' x  ' as tendichvu  , CONVERT(nvarchar(50), convert(int, sum(C.SoLuong))) as soluong,d.NhomThuoc,ttt.ThuTu_KeDon,C.MaDichVu,B.Nhom,d.DVT,cs.TenCDChamSoc,DINHDUONG.TenCDDinhDuong "
                + " from NAMDINH_QLBN.dbo.BENHNHAN_CHITIET a inner"
                + " join Namdinh_qlbn.dbo.BENHNHAN_PHIEUDIEUTRI b on a.MaVaoVien = b.MaVaoVien"
                + " left join NAMDINH_QLBN.dbo.PHIEUDIEUTRI_CHITIET c on c.SoPhieu = b.SoPhieu"
                + " inner join NAMDINH_QLBN.DBO.INPHIEUTHANHTOAN d on d.MaDichvu = c.MaDichVu"
                + " and(d.LoaiDichvu in ('D01', 'D03') and d.MaDichvu not in ('MAU-MA-0065', 'MAU-MA-0075', 'MAU-MA-0076', 'MAU-MA-0099')) "
                + " inner join NAMDINH_QLBN.dbo.DMCHEDOCHAMSOC cs on cs.MaCDChamSoc = b.CDChamSoc"
                + " left join NAMDINH_QLBN.DBO.DMCHEDODINHDUONG DINHDUONG ON DINHDUONG.MaCDDinhDuong = B.CDDinhDuong"
                + " inner join NAMDINH_QLBN.DBO.BENHNHAN BN ON BN.MaBenhNhan = A.MaBenhNhan"
                + " INNER JOIN NAMDINH_QLBN.DBO.DMKHOAPHONG KP ON KP.MaKhoa = B.MaKhoa"
                + " inner join DMLOAIDICHVU loaidv on loaidv.MaLoaiDichvu = d.LoaiDichvu"
                + " left join (select * from NAMDINH_QLBN.dbo.templ_phieudieutri) e  on e.sophieu = b.SoPhieu and e.madichvu = c.MaDichVu "
                + " left join(select distinct THuocId, HoatChat, HamLuong_NongDo, DuongDung_DangBC, MaDuongDung, GiaTTBHYT, TTThau, case	when MaDuongDung = N'2.05' then 1	when MaDuongDung = N'2.14' then 2 when MaDuongDung = N'2.15' then 3 when MaDuongDung = N'2.10' then 4 when MaDuongDung = N'1.01' then 5 when MaDuongDung = N'4.02' then 6 when MaDuongDung = N'3.05' then 7 else 8  end as ThuTu_KeDon, Cong_Bo, TenThuocXml"
                + " from NAMDINH_DUOC.dbo.ThongTinThuoc) ttt on ttt.ThuocID = c.MaDichVu and(c.DonGia = ttt.GiaTTBHYT or(ttt.ThuocID like N'%MAU-MA%')) and(ttt.Cong_Bo = (select Max(Cong_Bo)  from Namdinh_duoc.dbo.ThongTinThuoc where thuocid = ttt.ThuocID and GiaTTBHYT = ttt.GiaTTBHYT))"
                + " WHERE A.MaVaoVien = N'{0}' and b.Makhoa = N'{1}'", txtMaVaoVien.Text, frm._MaKhoa);
                if (frm._Chon == true)
                {
                    SQLCmd.CommandText += string.Format("And B.NgayChidinh between '{0:dd/MM/yyyy HH:mm:ss}' and '{1:dd/MM/yyyy HH:mm:ss}' Group by a.MaVaoVien,b.SoPhieu,b.NgayChiDinh,d.LoaiDichvu,d.TenDichvu,d.DVT, c.Ghichu,cs.TenCDChamSoc,b.BacSyDT,e.Stt,d.TenTat,KP.TenKhoa,BN.HoTen,BN.NAMSINH,A.DIACHI,GioiTinh,a.ChanDoan_KhoaDT,ttt.ThuTu_KeDon,HoatChat,DuongDung_DangBC,HamLuong_NongDo,TenThuocXml,b.Nhom,b.CapCuu,b.DienBienBenh,loaidv.TenLoaiDichvu,b.Ylenh,c.stt,d.nhomthuoc,TenThuocYLenh,b.Nhom,C.MaDichVu,DINHDUONG.TenCDDinhDuong  order by NgayChiDinh,SoPhieu,isnull(c.stt,ThuTu_KeDon),TenThuocXml ", frm._TNgay, frm._DNgay);
                }
                else
                {
                    SQLCmd.CommandText += string.Format(" Group by a.MaVaoVien,b.SoPhieu,b.NgayChiDinh,d.LoaiDichvu,d.TenDichvu,d.DVT, c.Ghichu,cs.TenCDChamSoc,b.BacSyDT,e.Stt,d.TenTat,KP.TenKhoa,BN.HoTen,BN.NAMSINH,A.DIACHI,GioiTinh,a.ChanDoan_KhoaDT,ttt.ThuTu_KeDon,HoatChat,DuongDung_DangBC,HamLuong_NongDo,TenThuocXml,b.Nhom,b.CapCuu,b.DienBienBenh,loaidv.TenLoaiDichvu,b.Ylenh,c.stt,d.nhomthuoc,TenThuocYLenh,b.Nhom,C.MaDichVu,DINHDUONG.TenCDDinhDuong  order by NgayChiDinh,SoPhieu,isnull(c.stt,ThuTu_KeDon),TenThuocXml ", frm._TNgay, frm._DNgay);
                }
                SQLCmd.CommandText += string.Format(" set @Sothutu = 1"
                                                    + " open MyCursor FETCH NEXT FROM MyCursor INTO @MaVaoVien, @SoPhieu, @NgayChiDinh, @stt, @Ylenh, @TenLoaiDichvu, @Ylenh_boxung,@BacSyDT,@tendichvu,@soluong,@NhomThuoc,@ThuTu_KeDon,@MaDichVu,@Nhom,@DVT,@TenCDChamSoc,@TenCDDinhDuong"
                                                    + " while @@FETCH_STATUS = 0"
                                                    + " Begin"
                                                        + " set  @NgayChiDinh1 = @NgayChiDinh"
                                                        + " insert into Ylenh_templ(Sothutu, Stt, MaVaoVien, SoPhieu, NgayChiDinh, Ylenh, TenLoaiDichvu, Ylenh_boxung,BacSyDT,tendichvu ,soluong,NhomThuoc,ThuTu_KeDon,MaDichVu,Nhom,DVT,TenCDChamSoc,TenCDDinhDuong) values(@sothutu, @stt, @MaVaoVien, @SoPhieu, @NgayChiDinh, @Ylenh, @TenLoaiDichvu, @Ylenh_boxung,@BacSyDT,@tendichvu,@soluong,@NhomThuoc,@ThuTu_KeDon,@MaDichVu,@Nhom,@DVT,@TenCDChamSoc,@TenCDDinhDuong)"
                                                        + " FETCH NEXT FROM MyCursor INTO @MaVaoVien, @SoPhieu, @NgayChiDinh, @stt, @Ylenh, @TenLoaiDichvu, @Ylenh_boxung,@BacSyDT,@tendichvu,@soluong,@NhomThuoc,@ThuTu_KeDon,@MaDichVu,@Nhom,@DVT,@TenCDChamSoc,@TenCDDinhDuong"
                                                        + " begin"
                                                        + " set @NgayChiDinh2 = @NgayChiDinh"
                                                        + " if @NgayChiDinh1 != @NgayChiDinh2"
                                                        + " set @Sothutu = 1"
                                                        + " else set @Sothutu = @Sothutu + 1"
                                                        + " end"
                                                    + " End DEALLOCATE MyCursor");
                SQLCmd.ExecuteNonQuery();

                SQLCmd.CommandText = string.Format(" IF EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name like 'dienbien_templ') DROP TABLE NAMDINH_QLBN.dbo.dienbien_templ ");
                SQLCmd.ExecuteNonQuery();
                SQLCmd.CommandText = "";
                SQLCmd.CommandText = string.Format("set dateformat dmy HH:MM:SS: Create table NAMDINH_QLBN.dbo.dienbien_templ"
                                                    + " ("
                                                        + " Sothutu int,"
                                                        + " MaVaoVien Nvarchar(12),"
                                                        + " SoPhieu Nvarchar(12),"
                                                        + " NgayChiDinh Datetime,"
                                                        + " DienBien Nvarchar(Max),"
                                                        + " TenLoaiDichvu Nvarchar(Max),"
                                                        + " TenCDChamSoc Nvarchar(100),"
                                                        + " TenCDDinhDuong Nvarchar(100),"
                                                        + " DienBienBenh Nvarchar(Max),MaDichVu Nvarchar(12),Nhom Nvarchar(12)"
                                                    + " );"
                                        + " declare @SoPhieu1 Nvarchar(20) declare @SoPhieu2 Nvarchar(20) declare @Sothutu int declare @MaVaoVien Nvarchar(20) declare @SoPhieu Nvarchar(20) declare @DienBienBenh Nvarchar(Max)   declare @NgayChiDinh Nvarchar(20)"
                                        + " declare @DienBien Nvarchar(Max) declare @TenLoaiDichvu Nvarchar(Max) declare @TenCDChamSoc Nvarchar(100) declare @NgayChiDinh1 Nvarchar(20)declare @NgayChiDinh2 Nvarchar(20)  declare @MaDichVu Nvarchar(20)declare @Nhom Nvarchar(20) declare @TenCDDinhDuong Nvarchar(100)"
                                        + " DECLARE MyCursor CURSOR FOR"
                                        + " select a.MaVaoVien, b.SoPhieu, b.NgayChiDinh, Case when((d.LoaiDichvu Like N'C%') or(d.LoaiDichVu = 'E03')) then d.TenDichvu + ' x ( ' + CONVERT(nvarchar(50), convert(int, sum(C.SoLuong))) + ' ' + d.DVT + ' )' end as DienBienBenh,b.DienBienBenh as dienBien,loaidv.TenLoaiDichvu,cs.TenCDChamSoc,b.Nhom,C.MaDichVu,DINHDUONG.TenCDDinhDuong "
                                        + " from NAMDINH_QLBN.dbo.BENHNHAN_CHITIET a inner join Namdinh_qlbn.dbo.BENHNHAN_PHIEUDIEUTRI b on a.MaVaoVien = b.MaVaoVien"
                                        + " left join NAMDINH_QLBN.dbo.PHIEUDIEUTRI_CHITIET c on c.SoPhieu = b.SoPhieu"
                                        + " inner join NAMDINH_QLBN.DBO.INPHIEUTHANHTOAN d on d.MaDichvu = c.MaDichVu and(d.LoaiDichvu Like N'C%')"
                                        + " inner join NAMDINH_QLBN.dbo.DMCHEDOCHAMSOC cs on cs.MaCDChamSoc = b.CDChamSoc"
                                        + " left join NAMDINH_QLBN.dbo.DMCHEDODINHDUONG DINHDUONG on DINHDUONG.MaCDDinhDuong = b.CDDinhDuong"
                                        + " inner join NAMDINH_QLBN.DBO.BENHNHAN BN ON BN.MaBenhNhan = A.MaBenhNhan"
                                        + " INNER JOIN NAMDINH_QLBN.DBO.DMKHOAPHONG KP ON KP.MaKhoa = B.MaKhoa inner join DMLOAIDICHVU loaidv on loaidv.MaLoaiDichvu = d.LoaiDichvu"
                                        + " left join (select * from NAMDINH_QLBN.dbo.templ_phieudieutri) e  on e.sophieu = b.SoPhieu and e.madichvu = c.MaDichVu"
                                        + " left join(select distinct THuocId, HoatChat, HamLuong_NongDo, DuongDung_DangBC, MaDuongDung, GiaTTBHYT, TTThau, ThuTu_KeDon, Cong_Bo, TenThuocXml from NAMDINH_DUOC.dbo.ThongTinThuoc) ttt on ttt.ThuocID = c.MaDichVu and(c.DonGia = ttt.GiaTTBHYT or(ttt.ThuocID like N'%MAU-MA%')) and(ttt.Cong_Bo = (select Max(Cong_Bo)  from Namdinh_duoc.dbo.ThongTinThuoc where thuocid = ttt.ThuocID and GiaTTBHYT = ttt.GiaTTBHYT)) "
                                        + " WHERE A.MaVaoVien = N'{0}' and b.Makhoa = N'{1}'", txtMaVaoVien.Text, frm._MaKhoa);
                if (frm._Chon == true)
                {
                    SQLCmd.CommandText += string.Format("And B.NgayChidinh between '{0:dd/MM/yyyy HH:mm:ss}' and '{1:dd/MM/yyyy HH:mm:ss}' Group by a.MaVaoVien,b.SoPhieu,b.NgayChiDinh,d.LoaiDichvu,d.TenDichvu,d.DVT, c.Ghichu,cs.TenCDChamSoc,b.BacSyDT,e.Stt,d.TenTat,KP.TenKhoa,BN.HoTen,BN.NAMSINH,A.DIACHI,GioiTinh,a.ChanDoan_KhoaDT,ttt.ThuTu_KeDon,HoatChat,DuongDung_DangBC,HamLuong_NongDo,TenThuocXml,b.Nhom,b.CapCuu,b.DienBienBenh,loaidv.TenLoaiDichvu,b.Nhom,C.MaDichVu,DINHDUONG.TenCDDinhDuong  order by NgayChiDinh,SoPhieu,ThuTu_KeDon", frm._TNgay, frm._DNgay);
                }
                else
                {
                    SQLCmd.CommandText += string.Format(" Group by a.MaVaoVien,b.SoPhieu,b.NgayChiDinh,d.LoaiDichvu,d.TenDichvu,d.DVT, c.Ghichu,cs.TenCDChamSoc,b.BacSyDT,e.Stt,d.TenTat,KP.TenKhoa,BN.HoTen,BN.NAMSINH,A.DIACHI,GioiTinh,a.ChanDoan_KhoaDT,ttt.ThuTu_KeDon,HoatChat,DuongDung_DangBC,HamLuong_NongDo,TenThuocXml,b.Nhom,b.CapCuu,b.DienBienBenh,loaidv.TenLoaiDichvu,b.Nhom,C.MaDichVu,DINHDUONG.TenCDDinhDuong  order by NgayChiDinh,SoPhieu,ThuTu_KeDon ", frm._TNgay, frm._DNgay);
                }
                SQLCmd.CommandText += string.Format(" set @Sothutu = 1 "
                                                    + " open MyCursor FETCH NEXT FROM MyCursor INTO @MaVaoVien, @SoPhieu, @NgayChiDinh, @DienBienBenh, @DienBien, @TenLoaiDichvu,@TenCDChamSoc,@MaDichVu,@Nhom,@TenCDDinhDuong"
                                                    + " while @@FETCH_STATUS = 0"
                                                    + " Begin"
                                                        + " set  @NgayChiDinh1 = @NgayChiDinh"
                                                        + " insert into dienbien_templ(Sothutu, MaVaoVien, SoPhieu, NgayChiDinh, DienBienBenh, DienBien, TenLoaiDichvu,TenCDChamSoc,MaDichVu,Nhom,TenCDDinhDuong) values(@sothutu, @MaVaoVien, @SoPhieu, @NgayChiDinh, @DienBienBenh, @DienBien, @TenLoaiDichvu,@TenCDChamSoc,@MaDichVu,@Nhom,@TenCDDinhDuong)"
                                                        + " FETCH NEXT FROM MyCursor INTO @MaVaoVien, @SoPhieu, @NgayChiDinh, @DienBienBenh, @DienBien, @TenLoaiDichvu,@TenCDChamSoc,@MaDichVu,@Nhom,@TenCDDinhDuong"
                                                        + " begin"
                                                        + " set @NgayChiDinh2 = @NgayChiDinh"
                                                        + " if @NgayChiDinh1 != @NgayChiDinh2"
                                                                + " set @Sothutu = 1"
                                                        + " else set @Sothutu = @Sothutu + 1"
                                                        + " end"
                                                    + " End DEALLOCATE MyCursor");
                SQLCmd.ExecuteNonQuery();
                SQLCmd.CommandText = string.Format("IF EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name like 'tbltonghop') DROP TABLE NAMDINH_QLBN.dbo.tbltonghop");
                SQLCmd.ExecuteNonQuery();
                rep = new NamDinh_QLBN.Reports.rpt_ylenh(txtMaVaoVien.Text, frm._MaKhoa, frm._TNgay, frm._DNgay, frm._Chon, txtHoTen.Text,cmbKhoa.Text,txtGioi.Text,txtChanDoan.Text,txtTuoi.Text,_TenBuong,_TenGiuong,_SoHSBA );
                rep.Show();
                //string Ngaychidinh;
                //System.Data.SqlClient.SqlDataReader dr;
                //System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
                //SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
                //SQLCmd.CommandText = string.Format("select Sophieu, Ngaychidinh from benhnhan_phieudieutri where mavaovien ='{0}'",txtMaVaoVien.Text);
                //dr = SQLCmd.ExecuteReader();

                //while (dr.Read())
                //{
                //    Ngaychidinh = string.Format("{0:dd/MM/yyyy HH:mm:ss}", DateTime.Parse(dr["Ngaychidinh"].ToString()));
                //Subrpt_ylenh_DienBien rdb = new Subrpt_ylenh_DienBien(txtMaVaoVien.Text, frm._MaKhoa, frm._TNgay, frm._DNgay, frm._Chon);
                //rdb.Run();
                //Subrpt_ylenh_dieutri rdt = new Subrpt_ylenh_dieutri(txtMaVaoVien.Text, frm._MaKhoa, frm._TNgay, frm._DNgay, frm._Chon);
                //rdt.Run();
                //    rep.subReport1.Report = rdb;
                //    rep.subReport2.Report = rdt;
                //}

                ////rep = new NamDinh_QLBN.Reports.rpt_ylenh(txtMaVaoVien.Text,frm._MaKhoa,frm._TNgay,frm._DNgay,frm._Chon);


                //dr.Close();
                //rep.Show();
                //rep.Show();

                // rdb = new Subrpt_ylenh_DienBien(txtMaVaoVien.Text, frm._MaKhoa, frm._TNgay, frm._DNgay, frm._Chon);
                ////rdb.Run();
                //rdt = new Subrpt_ylenh_dieutri(txtMaVaoVien.Text, frm._MaKhoa, frm._TNgay, frm._DNgay, frm._Chon);
                ////rdt.Run();
                return;

            }
            

        }

        private void mnuSua_TLBH_Click(object sender, EventArgs e)
        {

        }

        private void cmbDoiTuong_TextChanged(object sender, EventArgs e)
        {
            if (this.cmbDoiTuong.SelectedIndex != 0)
            {
                this.MaDoiTuongBN = Global.GetCode(this.cmbDoiTuong);
            }
            else
            {
                this.MaDoiTuongBN = this.BackMaDoiTuongBN;
            }
        }

        private void LaySoThuTu(string MaVaoVien)
        {
                System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
                SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
                SQLCmd.CommandText = string.Format("drop Table NAMDINH_QLBN.dbo.templ_phieudieutri " 
                        +" Create table NAMDINH_QLBN.dbo.templ_phieudieutri "
                    + " ( "
                    + "    Stt int,"
                    + "    NgayChiDinh Date, "
                    + "    MaDichVu Nvarchar(20),"
                    + "    SoPhieu Nvarchar(12)"
                    + " );"
                    + " declare @Stt int = 1 declare @madichvu Nvarchar(20) declare @NgayChiDinh date  declare @madichvu1 Nvarchar(20) declare @NgayChiDinh1 Date"
                    + " declare @madichvu2 Nvarchar(20) declare @NgayChiDinh2 Date declare @sophieu Nvarchar(12) DECLARE MyCursor CURSOR FOR"
                    + " select convert(Date, b.NgayChiDinh), c.MaDichVu, b.sophieu from NAMDINH_QLBN.dbo.BENHNHAN_CHITIET a"
                    + " inner join Namdinh_qlbn.dbo.BENHNHAN_PHIEUDIEUTRI b on a.MaVaoVien = b.MaVaoVien"
                    + " inner join NAMDINH_QLBN.dbo.PHIEUDIEUTRI_CHITIET c on c.SoPhieu = b.SoPhieu and a.mavaovien = '{0}' and c.loaidichvu = 'D01'"
                    + " inner join NAMDINH_DUOC.DBO.DanhMucThuoc dmthuoc on dmthuoc.ThuocID = c.MaDichVu and dmthuoc.NhomThuoc in ('CT', 'GN', 'HT', 'KS')"
                    + " order by MaDichVu,NgayChiDinh"
                    + " open MyCursor FETCH NEXT FROM MyCursor INTO @NgayChiDinh,@madichvu,@sophieu"
                    + " while @@FETCH_STATUS = 0"
                    + " begin"
                    + "    set @NgayChiDinh1 = @NgayChiDinh"
                    + "    set @madichvu1 = @madichvu"
                    + "    insert into NAMDINH_QLBN.dbo.templ_phieudieutri values (@Stt, @NgayChiDinh1, @madichvu1, @sophieu)"
                    + "    FETCH NEXT FROM MyCursor INTO  @NgayChiDinh, @madichvu, @sophieu"
                    + "    begin"
                    + "        set @NgayChiDinh2 = @NgayChiDinh"
                    + "        set @madichvu2 = @madichvu"
                    + "        if @madichvu1 != @madichvu2 set @Stt = 1"
                    + "         else if  @NgayChiDinh1= @NgayChiDinh2 set @stt = @stt else	set @Stt = @Stt + 1"
                    + "    end"
                    + " End"
                    + " DEALLOCATE MyCursor", MaVaoVien);
            SQLCmd.ExecuteNonQuery();
        }
        private void sửaTỷLệnBHYTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fgDichVu.Rows.Count <= 1) return;
            fgDichVu.StartEditing(fgDichVu.Row, fgDichVu.Cols["TyleBH"].Index);
        }

        private void sửaThứTựToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fgDichVu.Rows.Count <= 1) return;
            fgDichVu.StartEditing(fgDichVu.Row, fgDichVu.Cols["STT"].Index);
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
                else
                {
                    if (txtMaICD_BenhChinh.Text == "")
                    {
                        MessageBox.Show("Bạn phải nhập mã ICD 4 số(Mã ICD cấp con của mã vừa nhập)", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                dr.Close();
                SQLCmd.Dispose();
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
                //else
                //{
                //    txtTenICD_KhoaDieuTri_BP_1.Text = txtMaICD_BenhPhu.Text = "";
                //    MessageBox.Show("Không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
                dr.Close();
                SQLCmd.Dispose();
            }
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

        private void cmdICD_KhoaDieuTri_BP_1_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.Tien_ich.frmTraCuuICD fr = new NamDinh_QLBN.Forms.Tien_ich.frmTraCuuICD();
            if (fr.ShowDialog() == DialogResult.OK)
            {
                if (txtMaICD_BenhChinh.Text == fr._MaICD)
                {
                    MessageBox.Show("Mã bệnh chính và bệnh phụ trùng nhau!", "Thông báo!");
                    txtMaICD_BenhPhu_1.Text = "";
                    return;
                }
                else
                {
                    string benhkhac = "";
                    benhkhac = fr._MaICD;
                    txtMaICD_BenhPhu_1.Text = benhkhac + ";" + txtMaICD_BenhPhu_1.Text;
                    //   txtMaICD_BenhPhu_1.Text = fr._MaICD;
                    txtTenICD_KhoaDieuTri_BP_1.Text = fr._TenICD;
                }
            }
        }

        private void cmdICD_Dichvu(string DichVu,string KiemTraICD)
        {
            NamDinh_QLBN.Forms.Tien_ich.frmTraCuuICD_DichVu fr = new NamDinh_QLBN.Forms.Tien_ich.frmTraCuuICD_DichVu(DichVu,KiemTraICD);
            if (fr.ShowDialog() == DialogResult.OK)
            {
                if (txtMaICD_BenhChinh.Text == fr._MaICD)
                {
                    MessageBox.Show("Mã bệnh chính và bệnh phụ trùng nhau!", "Thông báo!");
                    txtMaICD_BenhPhu_1.Text = "";
                    return ;
                }
                else
                {
                    string benhkhac = "";
                    benhkhac = fr._MaICD;
                    txtMaICD_BenhPhu_1.Text = benhkhac + ";" + txtMaICD_BenhPhu_1.Text;
                    //   txtMaICD_BenhPhu_1.Text = fr._MaICD;
                    txtTenICD_KhoaDieuTri_BP_1.Text = fr._TenICD;
                }
                if(fr._MaICD != null)
                {
                    System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
                    SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
                    SQLCmd.CommandText = string.Format("if(not exists (select * from NAMDINH_QLBN.dbo.tbl_MaVaoVien_Dichvu where MaVaoVien = '{0}' and MaDichVu = '{1}')) insert into  NAMDINH_QLBN.dbo.tbl_MaVaoVien_Dichvu(MaVaoVien,MaDichVu) values ('{0}','{1}') ", txtMaVaoVien.Text, DichVu);
                    SQLCmd.ExecuteNonQuery();
                }
            }
            if(KiemTraICD == "1" && fr._MaICD == null)
            {
                batnhap =1;
            }
        }

        private void txtMaICD_BenhChinh_Validated(object sender, EventArgs e)
        {
            txtMaICD_BenhChinh_KeyUp(null, null);
        }

        private void btnLuu_ICD_Click(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            System.Data.SqlClient.SqlDataReader dr;
            string s = txtMaICD_BenhChinh.Text;
            string benhphu1 = "";
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
            //if (txtTenICD_KhoaDieuTri_BC.Text.Trim() == "")
            //{
            //    MessageBox.Show("Nhập chẩn đoán ICD bệnh chính!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    txtMaICD_BenhChinh.Text = "";
            //    txtMaICD_BenhChinh.Focus();
            //    return;
            //}
            SQLCmd.CommandText = String.Format(" UPDATE BENHNHAN_KHOA SET MAICD_BC='{0}',MAICD_BP='{1}',MAICD_BP_1='{3}' WHERE MAVAOVIEN ='{2}' AND LANCHUYENKHOA ="
                + " (SELECT MAX(LANCHUYENKHOA) FROM BENHNHAN_KHOA WHERE BENHNHAN_KHOA.MAVAOVIEN='{2}')", txtMaICD_BenhChinh.Text.Trim(),
                "",
                txtMaVaoVien.Text, benhphu1);
            SQLCmd.ExecuteNonQuery();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
           
        }

        private void btnPrintGiaoThuoc_Click(object sender, EventArgs e)
        {
            new repPhieuGiaoThuoc(this.txtHoTen.Text.Trim(), int.Parse(this.txtTuoi.Text.Trim()), this.txtGioi.Text, this.txtChanDoan.Text.Trim(), this.cmbKhoa.Text, int.Parse(this.fgPhieuChiDinh.GetDataDisplay(this.fgPhieuChiDinh.Row, "Nhom")), this.lblSoPhieu.Text.Trim(), this.txtNgayChiDinh.Value, cmbDieuduong.Text, this.fgPhieuChiDinh.GetDataDisplay(this.fgPhieuChiDinh.Row, "BacSyDT"),txtMaBenhAn.Text,txtMaVaoVien.Text, _TenBuong,_TenGiuong).Show();
        }
        private void fgPhieuChiDinh_Click(object sender, EventArgs e)
        {
            if (fgPhieuChiDinh.Rows.Count <= 1) return;
            if (fgPhieuChiDinh.GetDataDisplay(fgPhieuChiDinh.Row, "isPhieudieutri_Covid") == "1")
            {
                chk_Covid.Checked = true;
                PhieuCovid = 1;
            }
            else
            {
                chk_Covid.Checked = false;
                PhieuCovid = 0;
            }
            if (fgPhieuChiDinh.GetDataDisplay(fgPhieuChiDinh.Row, "MaKhoa") != Global.GetCode(cmbKhoa) && fgPhieuChiDinh.GetDataDisplay(fgPhieuChiDinh.Row, "SoPhieu").Substring(0, 2) == "NT")
            {
                MessageBox.Show("Phiếu chỉ định của khoa " + fgPhieuChiDinh.GetDataDisplay(fgPhieuChiDinh.Row, "TenKhoa") + "\n Bạn không sửa được phiếu này !");
                cmdSua.Enabled = false;
            }
            else
            {
                if(_DaRaVien == "1" || _DaTinhPhi == "1")
                {
                    cmdSua.Enabled = false;
                }
                else
                {
                    cmdSua.Enabled = true;
                }
                
            }
        }

        private void fgDichVu_RowColChange(object sender, EventArgs e)
        {

        }

        private void Todieutri(string MaVaoVien)
        {
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            SQLCmd.CommandText = string.Format("drop table tbltodieutri select * into tbltodieutri from (select a.MaVaoVien, b.SoPhieu, b.NgayChiDinh, "
            + " (select Distinct Case when d.LoaiDichvu Like N'C%' then d.TenDichvu + ' X ' + CONVERT(nvarchar(50),convert(int,sum(C.SoLuong))) + ' '+ d.DVT end as DienBienBenh) as DienBienBenh, e.Stt ,"
            + " Case when d.LoaiDichvu in ('D01','D03') then ttt.HoatChat + ' ('+ ttt.HamLuong_NongDo + ',' + ttt.DuongDung_DangBC + ')' + ' X ' + CONVERT(nvarchar(50),convert(int,sum(C.SoLuong))) + ' ' + d.DVT + ' X ' + c.Ghichu end as Ylenh, "
            + " cs.TenCDChamSoc,b.BacSyDT,d.TenTat,KP.TenKhoa,BN.HoTen,BN.NAMSINH,A.DIACHI,case when bn.GioiTinh = 1 then N'Nam' else N'Nữ' end GioiTinnh,a.ChanDoan_KhoaDT,ttt.ThuTu_KeDon from NAMDINH_QLBN.dbo.BENHNHAN_CHITIET a"
            + " inner join Namdinh_qlbn.dbo.BENHNHAN_PHIEUDIEUTRI b on a.MaVaoVien = b.MaVaoVien"
            + " inner join NAMDINH_QLBN.dbo.PHIEUDIEUTRI_CHITIET c on c.SoPhieu = b.SoPhieu"
            + " inner join NAMDINH_QLBN.DBO.INPHIEUTHANHTOAN d on d.MaDichvu = c.MaDichVu and(d.LoaiDichvu in ('D01','D03') or d.LoaiDichvu Like N'C%') "
            + " inner join NAMDINH_QLBN.dbo.DMCHEDOCHAMSOC cs on cs.MaCDChamSoc = b.CDChamSoc"
            + " inner join NAMDINH_QLBN.DBO.BENHNHAN BN ON BN.MaBenhNhan  = A.MaBenhNhan"
            + " INNER JOIN NAMDINH_QLBN.DBO.DMKHOAPHONG KP ON KP.MaKhoa = B.MaKhoa"
            + " left join (select * from NAMDINH_QLBN.dbo.templ_phieudieutri) e  on e.sophieu = b.SoPhieu and e.madichvu = c.MaDichVu"
            + " left join (select distinct THuocId,HoatChat,HamLuong_NongDo,DuongDung_DangBC,MaDuongDung,GiaTTBHYT,TTThau,ThuTu_KeDon from NAMDINH_DUOC.dbo.ThongTinThuoc) ttt on ttt.ThuocID= c.MaDichVu and c.DonGia = ttt.GiaTTBHYT and ttt.TTThau = c.TTThau"
            + " WHERE A.MaVaoVien = '{0}' and b.Makhoa = '{1}'"
            + " Group by a.MaVaoVien,b.SoPhieu,b.NgayChiDinh,d.LoaiDichvu,d.TenDichvu,d.DVT, c.Ghichu,cs.TenCDChamSoc,b.BacSyDT,e.Stt,d.TenTat,KP.TenKhoa,BN.HoTen,BN.NAMSINH,A.DIACHI,GioiTinh,a.ChanDoan_KhoaDT,ttt.ThuTu_KeDon,HoatChat,DuongDung_DangBC,HamLuong_NongDo) X "
            + " order by NgayChiDinh,SoPhieu,ThuTu_KeDon", MaVaoVien, Global.GetCode(this.cmbKhoa));
            SQLCmd.ExecuteNonQuery();
        }
    }
}