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
using System.Collections.Specialized;
using System.Xml;
using System.Diagnostics;
using System.IO;

namespace NamDinh_QLBN.Forms.DuLieu
{
    public partial class frmBenhAn : Form
    {
        public string _MaVaoVien  = "";
        public string TenKhoa;
        public string _SoHSBA = ""; public string _SoLuuTru = "";
        string Tinh, Huyen, Xa, NgoaiKieu, In_BA, Dia_chi;
        C1.Win.C1FlexGrid.C1FlexGrid _fg;
        public frmBenhAn(string MaVaoVien, string NgayKham, string SoHSBA, string SoLuuTru, C1.Win.C1FlexGrid.C1FlexGrid fg)
        {
            InitializeComponent();
            _MaVaoVien = MaVaoVien;
            _SoHSBA = SoHSBA;
            _SoLuuTru = SoLuuTru;
            _fg = fg;
            Load_CacDM();
            fgChuyenKhoa.ClipSeparators = "|;";
            LayThonTinBenhNhan();
            LayThonTinBenhNhan_ChiTiet(_MaVaoVien);
        }
        private void Load_CacDM()
        {
            SqlCommand command = new SqlCommand();
            command.Connection = Global.ConnectSQL;
            command.CommandText = "select MaNghenghiep,TenNghenghiep from NAMDINH_SYSDB.DBO.DMNGHENGHIEP ";
            SqlDataReader reader = command.ExecuteReader();
            this.cmbHCNgheNghiep.Tag = "0";
            this.cmbHCNgheNghiep.ClearItems();
            while (reader.Read())
            {
                this.cmbHCNgheNghiep.AddItem(string.Format("{0};{1}", reader["MaNghenghiep"], reader["TenNghenghiep"]));
            }
            this.cmbHCNgheNghiep.SelectedIndex = -1;
            this.cmbHCNgheNghiep.Tag = "1";
            reader.Close();

            command.CommandText = "select ID,TenBV from NAMDINH_SYSDB.dbo.DSbenhvien ";
            reader = command.ExecuteReader();
            this.cmbBNTenNoiChuyenVien.Tag = "0";
            this.cmbBNTenNoiChuyenVien.ClearItems();
            while (reader.Read())
            {
                this.cmbBNTenNoiChuyenVien.AddItem(string.Format("{0};{1}", reader["ID"], reader["TenBV"]));
            }
            this.cmbBNTenNoiChuyenVien.SelectedIndex = -1;
            this.cmbBNTenNoiChuyenVien.Tag = "1";
            reader.Close();

            command.CommandText = "select MaDT,TenDT from NAMDINH_SYSDB.DBO.DMDANTOC ";
            reader = command.ExecuteReader();
            this.cmbHCDanToc.ClearItems();
            while (reader.Read())
            {
                this.cmbHCDanToc.AddItem(string.Format("{0};{1}", reader["MaDT"], reader["TenDT"]));
            }
            this.cmbHCDanToc.SelectedIndex = -1;
            reader.Close();

            //command.CommandText = "select MaTinh,TenTinh from NAMDINH_SYSDB.DBO.DmTinh";
            //reader = command.ExecuteReader();
            //this.cmbHCTinh.Tag = "0";
            //this.cmbHCTinh.ClearItems();
            //while (reader.Read())
            //{
            //    this.cmbHCTinh.AddItem(string.Format("{0};{1}", reader["MaTinh"], reader["TenTinh"]));
            //}
            //this.cmbHCTinh.SelectedIndex = -1;
            //this.cmbHCTinh.Tag = "0";
            //reader.Close();


            command.CommandText = "select MaKhoa,TenKhoa from NAMDINH_SYSDB.dbo.dmkhoaphong where is_KhoaDieutri=1";
            reader = command.ExecuteReader();
            this.cmbKhoa.ClearItems();
            while (reader.Read())
            {
                this.cmbKhoa.AddItem(string.Format("{0};{1}", reader["MaKhoa"], reader["TenKhoa"]));
            }
            this.cmbKhoa.SelectedIndex = -1;
            reader.Close();


            textBox3.Text = "";
            command.CommandText = string.Format("select N'+ CHẨN ĐOÁN NHẬP VIỆN: ' + '\r\n' + Chandoan + '\r\n' + '\r\n' +N'+ LÝ DO NHẬP VIỆN: '+ '\r\n' + Nhapvien_Lydo + '\r\n' + '\r\n' + N'+ BỆNH LÝ NHẬP VIỆN: '+ '\r\n' + Nhapvien_Benhly + '\r\n' + '\r\n' + N'+ TIỀN  SỬ: ' +'\r\n' + Nhapvien_TiensuTT + '\r\n' + '\r\n' + N'+ TIỀN SỬ GIA ĐÌNH'+ '\r\n' + Nhapvien_TiensuGD + '\r\n' + '\r\n' + N'+ TOÀN THÂN NV'+ '\r\n' + Nhapvien_Toanthan +'\r\n' + '\r\n' + N'+ CÁC BỘ PHẬN NV'+ '\r\n' + Nhapvien_Cacbophan + '\r\n' +'\r\n' +N'+ TT KQLS'+ '\r\n' + Nhapvien_TTKQLS + '\r\n' + '\r\n' +N'+ CHẨN ĐOÁN NHẬP VIỆN'+ '\r\n' + Nhapvien_ChandoanVV as ThongTinNhapVien from NAMDINH_KHAMBENH.dbo.tblKHAMBENH_KQDVKHAM a inner join NAMDINH_QLBN.dbo.BENHNHAN_CHITIET b on a.MaKhambenh = b.MaKhamBenh where b.MaVaoVien = '{0}' and huonggq = 5 and DaNhapVien =1  and TuChoiTiepNhan in (0,2) ", _MaVaoVien);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                textBox3.Text = reader["ThongTinNhapVien"].ToString();
            }
            reader.Close();
                  
            textBox1.Text = "";
            command.CommandText = string.Format("select N'+ TÓM TẮT: ' + '\r\n' + TomTat + '\r\n'+ '\r\n' +N'+ KẾT LUẬN: '+'\r\n' +  KetLuan + '\r\n'+'\r\n'+N'+ HƯỚNG ĐIỀU TRỊ'+ '\r\n' +HuongDT as HoiChan from NAMDINH_QLBN.dbo.BENHNHAN_HOICHAN where  MaVaoVien = '{0}'", _MaVaoVien);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                textBox1.Text = reader["HoiChan"].ToString();
            }
            reader.Close();

            textBox2.Text = "";
            command.CommandText = string.Format("select N'+ CHẨN ĐOÁN TRƯỚC PT: '+ '\r\n' +ChanDoan_TruocPT + '\r\n' + '\r\n' + N'+ CHẨN ĐOÁN SAU PT' + '\r\n' + ChanDoan_SauPT + '\r\n'+'\r\n'+N'+ PHƯƠNG PHÁP: '+'\r\n' +PhuongPhapPT_Text + '' +''+N'+ THỜI GIAN BẮT ĐẦU'+ '\r\n' + FORMAT(ThoiGianBD,'dd/MM/yyyy HH:mm') + '\r\n'+'\r\n'+N'+ THỜI GIAN KẾT THÚC'+'\r\n' + FORMAT(ThoiGianKT,'dd/MM/yyyy HH:mm') +'\r\n'+'\r\n'+N'+ MÔ TẢ KT'+'\r\n' +MoTaKT +'\r\n'+'\r\n'+N'+ TRÌNH TỰ PT'+ '\r\n' +TrinhTuPT as PhauThuat  from NAMDINH_QLBN.dbo.BENHNHAN_PHAUTHUAT where MaVaoVien = '{0}'", _MaVaoVien);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                textBox2.Text = reader["PhauThuat"].ToString();
            }
            reader.Close();


            command.CommandText = "select MaNuocNgoai,TenNuocNgoai from NAMDINH_SYSDB.DBO.DmNuocNgoai WHERE SUDUNG = 1 ORDER BY MaNuocNgoai";
            reader = command.ExecuteReader();
            this.txtHNgoaiKieu.ClearItems();
            while (reader.Read())
            {
                this.txtHNgoaiKieu.AddItem(string.Format("{0};{1}", reader["MaNuocNgoai"], reader["TenNuocNgoai"]));
            }
            this.txtHNgoaiKieu.SelectedIndex = 1;
            reader.Close();

            this.cmbHCDoiTuong.AddItem("0;BHYT");
            this.cmbHCDoiTuong.AddItem("1;Thu phí");
            this.cmbHCDoiTuong.AddItem("2;Miễn");
            this.cmbHCDoiTuong.AddItem("3;Khác");
            this.cmbHCDoiTuong.SelectedIndex = -1;

            this.cmbBNNoiGioiThieu.AddItem("1;Cơ quan y tế");
            this.cmbBNNoiGioiThieu.AddItem("2;Tự đến");
            this.cmbBNNoiGioiThieu.AddItem("3;Khác");
            cmbBNNoiGioiThieu.SelectedIndex = -1;

            this.cmbBNTrucTiepVao.AddItem("1;Cấp cứu");
            this.cmbBNTrucTiepVao.AddItem("2;KKB");
            this.cmbBNTrucTiepVao.AddItem("3;Khoa điều trị");
            cmbBNTrucTiepVao.SelectedIndex = -1;

            this.cmbBNChuyenVien.AddItem("1;Tuyến trên");
            this.cmbBNChuyenVien.AddItem("2;Tuyến dưới");
            this.cmbBNChuyenVien.AddItem("3;CK");
            cmbBNChuyenVien.SelectedIndex = -1;

            this.cmbBNNoiRaVien.AddItem("1;RaViện");
            this.cmbBNNoiRaVien.AddItem("2;Xin về");
            this.cmbBNNoiRaVien.AddItem("3;Bỏ về");
            this.cmbBNNoiRaVien.AddItem("4;Đưa về");

            this.cmbRaVienKetQuaDT.AddItem("1;Khỏi");
            this.cmbRaVienKetQuaDT.AddItem("2;Đỡ, giảm");
            this.cmbRaVienKetQuaDT.AddItem("3;Không thay đổi");
            this.cmbRaVienKetQuaDT.AddItem("4;Nặng hơn");
            this.cmbRaVienKetQuaDT.AddItem("5;Tử vong");
            cmbRaVienKetQuaDT.SelectedIndex = -1;

            this.cmbRaVienGiaiPhauBenh.AddItem("0;Lành tính");
            this.cmbRaVienGiaiPhauBenh.AddItem("1;Nghi ngờ");
            this.cmbRaVienGiaiPhauBenh.AddItem("2;Ác tính");
            cmbRaVienGiaiPhauBenh.SelectedIndex = -1;

            this.cmbRaVienLoaiTuVong.AddItem("0;Do bệnh");
            this.cmbRaVienLoaiTuVong.AddItem("1;Do tai biến điều trị");
            this.cmbRaVienLoaiTuVong.AddItem("2;Khác");
            cmbRaVienLoaiTuVong.SelectedIndex = -1;


            this.cmbKhamBenhCoQuan.AddItem("0;Chọn loại bệnh án");
            this.cmbKhamBenhCoQuan.AddItem("1;Ung Bướu");
            this.cmbKhamBenhCoQuan.AddItem("2;Nội Khoa");
            this.cmbKhamBenhCoQuan.AddItem("3;Ngoại Khoa");
            this.cmbKhamBenhCoQuan.AddItem("4;Truyền nhiễm");
            this.cmbKhamBenhCoQuan.AddItem("5;Tai Mũi Họng");
            this.cmbKhamBenhCoQuan.AddItem("6;Mắt");
            this.cmbKhamBenhCoQuan.AddItem("7;Răng Hàm Mặt");
            cmbKhamBenhCoQuan.SelectedIndex = -1;

            //this.cmbBNNoiGioiThieu.AddItem("2;Tự đến");
            //this.cmbBNNoiGioiThieu.AddItem("3;Khác");


            this.cmbPhuongPhapDieuTri.AddItem("0;Điều trị triệt để");
            this.cmbPhuongPhapDieuTri.AddItem("1;Điều trị triệu chứng");
            cmbPhuongPhapDieuTri.SelectedIndex = -1;


            this.cmbDapUng.AddItem("0;Không đáp ứng");
            this.cmbDapUng.AddItem("1;Bán phần");
            this.cmbDapUng.AddItem("2;Hoàn toàn");
            cmbDapUng.SelectedIndex = -1;

         
            this.cmbDieuTriNgoaiKhoa.AddItem("0;Phẫu Thuật");
            this.cmbDieuTriNgoaiKhoa.AddItem("1;Thủ Thuật");
            cmbDieuTriNgoaiKhoa.SelectedIndex = -1;
            command.Dispose();
            groupBox8.Enabled = true;
            cmbDieuTriNgoaiKhoa.Visible = false;
            txtPhuongPhapDieuTriNgoaiKhoa.Visible = false;
        }
        private void cmbHCTinh_TextChanged(object sender, EventArgs e)
        {
            if (cmbHCTinh.Tag.ToString() == "0")  return; 
            if (cmbHCTinh.SelectedIndex == -1) { cmbHCHuyen.ClearItems(); return; }
            //if (cmbHCHuyen.SelectedIndex == -1) { txtHCXaPhuong.ClearItems(); return; }
            cmbHCHuyen.SelectedIndex = -1;
            cmbHCHuyen.ClearItems();
            SqlCommand command = new SqlCommand();
                command.Connection = Global.ConnectSQL;
                command.CommandText = string.Format("select SUBSTRING(MaQuanHuyen,4,6) as MaQuanHuyen,TenQuanHuyen  from NAMDINH_SYSDB.dbo.DmQuanHuyen where SUBSTRING(MaQuanHuyen,1,3) = '{0}'", Global.GetCode(cmbHCTinh));
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    this.cmbHCHuyen.AddItem(string.Format("{0};{1}", reader["MaQuanHuyen"], reader["TenQuanHuyen"]));
                }
                cmbHCHuyen.SelectedIndex = -1;
                cmbHCHuyen.Tag = 0;
                reader.Close();
                command.Dispose();
        }
        private void LayThonTinBenhNhan()
        {
            cmbHCTinh.SelectedIndex = -1;
            cmbHCHuyen.SelectedIndex = -1;
            SqlCommand command = new SqlCommand();
            command.Connection = Global.ConnectSQL;

            command.CommandText = string.Format("select a.MaVaoVien,UPPER(c.TenBenhnhan) as TenBenhnhan,c.NgaySinh,c.ThangSinh,c.Namsinh,YEAR(b.ThoigianDangky) - c.Namsinh as Tuoi, "
                                                + " case when c.Gioitinh = 0 then N'Nữ' else N'Nam' end as Gioitinh,A.NgheNghiep, isnull(d.MaDanToc,0) as MaDanToc, A.MaNuocNgoai as MaNgoaiKieu, a.DiaChi, a.XaPhuong as XaPhuong,a.Ma_huyen as Huyen, MaTinh_TP as Tinh, A.NoiCongTac as NoiLamViec,"
                                                + " case when b.Doituong = 1 then 0 when b.Doituong = 3 then 1 when b.Doituong = 5 then 3 end DoiTuong, b.HantheBHYT_Den, UPPER(B.Doituongthe)+b.SotheBHYT as SoTheBHYT, a.LienHe as NguoiNha, SoDienThoai as SoDienThoai, b.ThoiGianDangKy as NgayVaoVien,"
                                                + " A.TrucTiepVao as NoiVaoVien,  A.NoiGioiThieu as NoiGioiThieu, A.VaoVienLan as LanVaoVien, f.MaKhoa,ISNULL(e.NgayChuyenDau,'') as NgayVaoKhoa, '' as ChuyenVien, a.ChuyenVien_ChuyenDenBV, isnull(a.NgayRaVien,'') NgayRaVien,'' as NoiRaVien,"
                                                + " DATEDIFF(day, a.ngayVaoVien, isnull(a.NgayRaVien, getdate())) + 1 as TongSoNgayDT, a.ChanDoan_NoiChuyenDen, '' as ICDChanDoan_NoiChuyenDen, a.ChanDoan_KKB, a.ICD_KKB, e.chandoan as ChanDoan_KhoaDT, e.MaICD_BC+':'+e.MaICD_BP_1 as ICDChanDoan_KhoaDT,"
                                                + " a.ChanDoanRaVien, e.MaICD_BC as ICDBenhChinh_RaVien, '' as BenhPhu, e.MAICD_BP_1 as ICDBenhPhuRaVien, '' as ChanDoanTruocPT, ''As ChanDoanSauPT, '' as TaiBien, '' as BienChung, '' as DoPhauThua, '' As DoGayMe, '' as DoNhiemKhuan, '' as DoKhac,"
                                                + " '' as TongSongayPhauThau, '' as TongSoLanPhauThuat, case when a.KetQuaDT in(5,6) then 5 else A.KetQuaDT end as KetQuaDT, '' as GiaiPhauBenh,case when a.KetQuaDT in (5,6) then a.NgayRaVien else '01/01/1900 00:00' end as NgayTuVong, '' as TVDoBenh,'' as TVDoTaiBien,'' as TVDoKhac,'' as TV24gioDau,'' as TV24gioSau,'' as NguyenNhanTV,'' as KhamNGhiemTV, '' as ChanDoanGPTV, '' as LoaiTuVong,g.TenKhoa,ChuyenVien_ChuyenDenBV, MaBV, a.SoNha, a.ThonPho, a.In_BenhAn"
                                                    + " from NAMDINH_QLBN.dbo.BENHNHAN_CHITIET A INNER JOIN NAMDINH_KHAMBENH.DBO.tblKHAMBENH B ON A.MaKhamBenh = B.MaKhambenh"
                                                + " INNER JOIN NAMDINH_KHAMBENH.DBO.tblbenhnhan C ON C.MaBenhnhan = B.MaBenhnhan"
                                                + " inner join NAMDINH_QLBN.DBO.BENHNHAN d on d.MaBenhNhan = a.MaBenhNhan"
                                                + " inner join NAMDINH_QLBN.dbo.ViewKHOAHIENTAI e on e.MaVaoVien = a.MaVaoVien"
                                                + " inner join NAMDINH_QLBN.dbo.BENHNHAN_KHOA f on f.MaVaoVien = e.MaVaoVien and f.LanChuyenKhoa = 0"
                                                + " inner join NAMDINH_QLBN.dbo.dmkhoaphong g on g.MaKhoa = f.MaKhoa"
                                                + " WHERE A.MaVaoVien = '{0}'", _MaVaoVien);
            SqlDataReader reader = command.ExecuteReader();
            //this.cmbHCNgheNghiep.Tag = "0";
            //this.cmbHCNgheNghiep.ClearItems();
           
            while (reader.Read())
            {
                lblHoTen.Text = reader["TenBenhnhan"].ToString();
                lblSinhNgay.Text = reader["NgaySinh"].ToString()+"/"+ reader["ThangSinh"].ToString() + "/" + reader["Namsinh"].ToString();
                lblTuoi.Text = reader["Tuoi"].ToString();
                lblGioiTinh.Text = reader["GioiTinh"].ToString();
                cmbHCNgheNghiep.SelectedIndex = cmbHCNgheNghiep.FindStringExact(reader["Nghenghiep"].ToString(), 0, 0);
                //cmbHCNgheNghiep.SelectedIndex = cmbHCNgheNghiep.FindStringExact(reader["Nghenghiep"].ToString(), 0, 0);
                cmbHCDanToc.SelectedIndex = cmbHCDanToc.FindStringExact(reader["MaDanToc"].ToString(), 0, 0);
                txtHNgoaiKieu.SelectedIndex = txtHNgoaiKieu.FindStringExact(reader["MaNgoaiKieu"].ToString(), 0, 0);
                cmbHCTinh.SelectedIndex = cmbHCTinh.FindStringExact(reader["Tinh"].ToString(), 0, 0);
                cmbHCHuyen.SelectedIndex = cmbHCHuyen.FindStringExact(reader["Huyen"].ToString(), 0, 0);
                In_BA = reader["In_BenhAn"].ToString();
                 Xa = reader["XaPhuong"].ToString();
                 Dia_chi = reader["DiaChi"].ToString(); 
                txtHCSoNha.Text = reader["SoNha"].ToString();
                txtHCThonPho.Text = reader["ThonPho"].ToString();
                txtHCNoiLamViec.Text = reader["NoiLamViec"].ToString();
                cmbHCDoiTuong.SelectedIndex = cmbHCDoiTuong.FindStringExact(reader["Doituong"].ToString(), 0, 0);
                txtHCHanTheBHYT.Value = string.Format("{0:dd/MM/yyyy}", reader["HantheBHYT_Den"].ToString());
                txtHCSoTheBHYT.Text = reader["SoTheBHYT"].ToString();
                txtHCHoTenNguoiNha.Text = reader["NguoiNha"].ToString();
                txtHCSoDienThoai.Text = reader["SoDienThoai"].ToString();
                txtBNNgayVaoVien.Value = string.Format("{0:dd/MM/yyyy HH:mm}",reader["NgayVaoVien"].ToString()); 
                cmbBNTrucTiepVao.SelectedIndex = cmbBNTrucTiepVao.FindStringExact(reader["NoiVaoVien"].ToString(), 0, 0);
                cmbBNNoiGioiThieu.SelectedIndex = cmbBNNoiGioiThieu.FindStringExact(reader["NoiGioiThieu"].ToString(), 0, 0);
                numBNLanVaoVien.Value = decimal.Parse(reader["LanVaoVien"].ToString());
                txtBNNgayVaoKhoa.Value = string.Format("{0:dd/MM/yyyy HH:mm}", reader["NgayVaoKhoa"].ToString());
                cmbKhoa.SelectedIndex = cmbKhoa.FindStringExact(reader["MaKhoa"].ToString(), 0, 0);
                cmbBNChuyenVien.SelectedIndex = cmbBNChuyenVien.FindStringExact(reader["ChuyenVien"].ToString(), 0, 0);
                cmbBNTenNoiChuyenVien.SelectedIndex = cmbBNTenNoiChuyenVien.FindStringExact(reader["ChuyenVien_ChuyenDenBV"].ToString(), 0, 0);
                txtBNNgayRaVien.Value = string.Format("{0:dd/MM/yyyy HH:mm}", reader["NgayRaVien"].ToString());
                cmbBNNoiRaVien.SelectedIndex = cmbBNChuyenVien.FindStringExact(reader["NoiRaVien"].ToString(), 0, 0);
                numBNTongNgayDT.Value = decimal.Parse(reader["TongSoNgayDT"].ToString());
                txtChanDoanNoiChuyenDen.Text = reader["ChanDoan_NoiChuyenDen"].ToString();
                txtChanDoanKKB.Text  = reader["ChanDoan_KKB"].ToString();
                txtChanDoanICDKBB.Text = reader["ICD_KKB"].ToString();
                txtChanDoanKhoaDieuTri.Text = reader["ChanDoan_KhoaDT"].ToString();
                txtChanDoanICDKhoaDieuTri.Text = reader["ICDChanDoan_KhoaDT"].ToString();
                txtChanDoanBenhChinh.Text = reader["ChanDoanRaVien"].ToString();
                txtChanDoanICDBenhChinh.Text = reader["ICDBenhChinh_RaVien"].ToString();
                txtChanDoanBenhKemTheo.Text = reader["BenhPhu"].ToString();
                txtChanDoanICDBenhPhu.Text = reader["ICDBenhPhuRaVien"].ToString();
                txtChanDoanTruocPt.Text = reader["ChanDoanTruocPT"].ToString();
                txtChanDoanSauPT.Text = reader["ChanDoanSauPT"].ToString();
                cmbRaVienKetQuaDT.SelectedIndex = cmbRaVienKetQuaDT.FindStringExact(reader["KetQuaDT"].ToString(), 0, 0);
                cmbRaVienGiaiPhauBenh.SelectedIndex = cmbRaVienGiaiPhauBenh.FindStringExact(reader["GiaiPhauBenh"].ToString(), 0, 0);
                txtRaVienNgayTuVong.Value =  string.Format("{0:dd/MM/yyyy HH:mm}", reader["NgayTuVong"].ToString());
                cmbRaVienLoaiTuVong.SelectedIndex = cmbRaVienLoaiTuVong.FindStringExact(reader["LoaiTuVong"].ToString(), 0, 0);
                txtRaVienNguyenNhanTuVong.Text = reader["NguyenNhanTV"].ToString();
                txtRaVienChanDoanGPTT.Text = reader["ChanDoanGPTV"].ToString();
                txtBenhChinhKhiVaoKhoa.Text = reader["ChanDoan_KhoaDT"].ToString();
                txtBenhPhuKhiVaoKhoa.Text = reader["BenhPhu"].ToString();
                TenKhoa = reader["TenKhoa"].ToString();
                cmbBNTenNoiChuyenVien.SelectedIndex = cmbBNTenNoiChuyenVien.FindStringExact(reader["MaBV"].ToString(), 0, 0);
                Tinh = reader["Tinh"].ToString();
                Huyen = reader["Huyen"].ToString();
                NgoaiKieu = reader["MaNgoaiKieu"].ToString();

            }
            reader.Close();

            command.CommandText = string.Format("select b.TenKhoa,NgayChuyen,GETDATE() as NgayHienTai from NAMDINH_QLBN.dbo.BENHNHAN_KHOA a inner join NAMDINH_QLBN.dbo.DMKHOAPHONG b  on a.MaKhoa = b.MaKhoa "
                                                + " where a.MaVaoVien = '{0}'and lanchuyenkhoa !=0"
                                                + " order by LanChuyenKhoa ", _MaVaoVien);
            reader = command.ExecuteReader();
            fgChuyenKhoa.Rows.Count = 1;
            while (reader.Read())
            {
                  fgChuyenKhoa.AddItem(string.Format("{0}|{1}|{2:dd/MM/yyyy HH:mm}|{3}|", fgChuyenKhoa.Rows.Count, reader["TenKhoa"], reader["NgayChuyen"], ""));
            }
            reader.Close();


            command.CommandText = string.Format("select case when( c.TenTat = '' or c.TenTat is NULL) then  c.TenDichvu   else TenTat   end  as TenDichVu , SUM(b.SoLuong) as SL, c.LoaiDichvu from NAMDINH_QLBN.dbo.BENHNHAN_PHIEUDIEUTRI a inner join NAMDINH_QLBN.dbo.PHIEUDIEUTRI_CHITIET b on a.SoPhieu = b.SoPhieu"
                                                + " inner join NAMDINH_SYSDB.dbo.DMDICHVU c on b.MaDichVu = c.MaDichvu"
                                                + " where a.MaVaoVien = '{0}' and b.LoaiDichVu"
                                                + " in ('C50', 'C51', 'C52', 'C53', 'C54', 'C55', 'C56', 'C57', 'C58', 'C59', 'C60', 'C61', 'C62', 'C63') group by TenTat,TenDichvu,c.LoaiDichvu order by c.LoaiDichvu, TenDichvu ", _MaVaoVien);
            reader = command.ExecuteReader();
            String XetNghiem = "";
            while (reader.Read())
            {
                XetNghiem = XetNghiem + ";" + reader["TenDichVu"];
            }
            txtKhamBenhXetNghiem.Text = XetNghiem;
            reader.Close();

            command.CommandText = "select MaTinh,TenTinh from NAMDINH_SYSDB.DBO.DmTinh";
            reader = command.ExecuteReader();
            this.cmbHCTinh.Tag = "0";
            this.cmbHCTinh.ClearItems();
            while (reader.Read())
            {
                this.cmbHCTinh.AddItem(string.Format("{0};{1}", reader["MaTinh"], reader["TenTinh"]));
            }
            this.cmbHCTinh.SelectedIndex = -1;
            this.cmbHCTinh.Tag = "1";
            cmbHCHuyen.ClearItems();
            cmbHCHuyen.Tag = "0";
            reader.Close();

            Global.SetCmb(cmbHCTinh, Tinh);
            Global.SetCmb(cmbHCHuyen, Huyen);
            Global.SetCmb(txtHNgoaiKieu, NgoaiKieu);
            if (In_BA == "1")
            {
                txtHCXaPhuong.Text = Xa;
            }
            else
                txtHCXaPhuong.Text = Dia_chi;
        }

        private void LayThonTinBenhNhan_ChiTiet(string MaVaoVien)
        {

            SqlCommand command = new SqlCommand();
            command.Connection = Global.ConnectSQL;

            command.CommandText = string.Format("select * from NAMDINH_QLBN.dbo.BenhAn_QuanLyNguoiBenh A INNER JOIN NAMDINH_QLBN.dbo.BenhAn_ChiTiet B ON A.MaVaoVien= B.MaVaoVien"
                                                    + " INNER JOIN NAMDINH_QLBN.dbo.BenhAn_ChanDoan C ON C.MaVaoVien = A.MaVaoVien"
                                                    + " INNER JOIN NAMDINH_QLBN.dbo.BenhAn_RaVien D ON D.MaVaoVien = A.MaVaoVien"
                                                    + " INNER JOIN NAMDINH_QLBN.dbo.BenhAn_TongKet E ON E.MaVaoVien = A.MaVaoVien"
                                                    + " WHERE a.Mavaovien = '{0}' ", MaVaoVien);
            SqlDataReader reader = command.ExecuteReader();
            //this.cmbHCNgheNghiep.Tag = "0";
            //this.cmbHCNgheNghiep.ClearItems();

            while (reader.Read())
            {
                txtBNNgayVaoVien.Value = string.Format("{0:dd/MM/yyyy HH:mm}",reader["NgayVaoVien"]);
                cmbBNTrucTiepVao.Text = reader["TrucTiepVao"].ToString();
                cmbBNNoiGioiThieu.Text = reader["NoiGioiThieu"].ToString();
                numBNLanVaoVien.Value = int.Parse(reader["LanNhapVien"].ToString());
                cmbKhoa.Text = reader["KhoaNhapVien"].ToString();
                txtBNNgayVaoKhoa.Value = string.Format("{0:dd/MM/yyyy HH:mm}", reader["NgayNhapVien"]);
                cmbBNChuyenVien.Text = reader["ChuyenVien"].ToString();
                cmbBNTenNoiChuyenVien.Text = reader["NoiChuyenVien"].ToString();
                txtBNNgayRaVien.Value = string.Format("{0:dd/MM/yyyy HH:mm}", reader["NgayRaVien"]);
                cmbBNNoiRaVien.Text = reader["NoiRaVien"].ToString();
                numBNTongNgayDT.Value = int.Parse(reader["SoNgayDieuTri"].ToString());
                numBNNgayDT.Value= int.Parse(reader["SoNgayDTKhoa"].ToString());
                txtBNTongNgayChu.Text = reader["TonSoNgayDT_Text"].ToString();
                txtChanDoanNoiChuyenDen.Text = reader["ChanDoan_NoiChuyenDen"].ToString();
                txtChanDoanKKB.Text = reader["ChanDoan_KKB"].ToString();
                txtChanDoanKhoaDieuTri.Text = reader["ChanDoan_KhoaDieuTri"].ToString();
                txtChanDoanICDNoiChuyenDen.Text = reader["MaBenhICD_NoiChuyenDen"].ToString();
                txtChanDoanICDKBB.Text = reader["MaBenhICD_KKB"].ToString();
                txtChanDoanICDKhoaDieuTri.Text = reader["MaBenhICD_KhoaDieuTri"].ToString();
                if (reader["ChanDoan_TaiBien"].ToString() == "1") { ckChanDoanTaiBien.Checked = true; } else ckChanDoanTaiBien.Checked = false;
                if (reader["ChanDoan_BienChung"].ToString() == "1") { ckChanDoanBienChung.Checked = true; } else ckChanDoanBienChung.Checked = false;
                if (reader["ChanDoan_DoGayMe"].ToString() == "1") { ckChanDoanDoGayMe.Checked = true; } else ckChanDoanDoGayMe.Checked = false;
                if (reader["ChanDoan_DoPhauThuat"].ToString() == "1") { ckChanDoanDoPhauThuat.Checked = true; } else ckChanDoanDoPhauThuat.Checked = false;
                if (reader["ChanDoan_DoNhiemKhuan"].ToString() == "1") { ckChanDoanDoNhiemKhuan.Checked = true; } else ckChanDoanDoNhiemKhuan.Checked = false;
                numChanDoanTongNgaySauPT.Value = int.Parse(reader["ChanDoan_SoNgayDieuTriSauPT"].ToString());
                numChanDoanSoLanPhauThuat.Value = int.Parse(reader["ChanDoan_SoLanPhauThuat"].ToString());
                txtChanDoanBenhChinh.Text = reader["ChanDoan_BenhChinhRaVien"].ToString();
                txtChanDoanICDBenhChinh.Text = reader["ChanDoan_ICDBenhChinhRaVien"].ToString();
                txtChanDoanBenhKemTheo.Text = reader["ChanDoan_BenhKemTheoRaVien"].ToString();
                txtChanDoanICDBenhPhu.Text = reader["ChanDoan_ICDBenhKemTheo"].ToString();
                txtChanDoanTruocPt.Text = reader["ChanDoan_TruocPhauThuat"].ToString();
                txtChanDoanICDTruocPhauThuat.Text = reader["ChanDoan_ICDTruocPhauThuat"].ToString();
                txtChanDoanSauPT.Text = reader["ChanDoan_SauPhauThuat"].ToString();
                txtChanDoanICDSauPhauThuat.Text = reader["ChanDoan_ICDSauPhauThuat"].ToString();
                cmbRaVienKetQuaDT.Text = reader["RaVien_KetQuaDieuTri"].ToString();
                cmbRaVienGiaiPhauBenh.Text= reader["RaVien_GiaiPhauBenh"].ToString();
                txtRaVienNgayTuVong.Value = string.Format("{0:dd/MM/yyyy HH:mm}", reader["RaVien_NgayTuVong"]);
                cmbRaVienLoaiTuVong.Text = reader["RaVien_LoaiTuVong"].ToString();
                if (reader["RaVien_24GioTuVong"].ToString() == "1") { ckRaVien24TV.Checked = true; } else ckRaVien24TV.Checked = false;
                txtRaVienNguyenNhanTuVong.Text = reader["RaVien_NguyeNhanTuVong"].ToString();
                txtMaNguyenNhanTV.Text = reader["RaVien_ICDNguyeNhanTuVong"].ToString();
                if (reader["RaVien_KhamTuThi"].ToString() == "1") { ckRaVienKhamNghiemTuThi.Checked = true; } else ckRaVienKhamNghiemTuThi.Checked = false;
                txtRaVienChanDoanGPTT.Text = reader["RaVien_ChanDoanGiaiPhauTuThi"].ToString();
                txtRaVienMaGPTT.Text = reader["RaVien_ICDChanDoanGiaiPhauTuThi"].ToString();
                if (reader["RaVien_Sau24GioTuVong"].ToString() == "1") { ckRaVienSau24Gio.Checked = true; } else ckRaVienSau24Gio.Checked = false;
                txtQuaTrinhBenhLyVaDienBien.Text = reader["TongKet_BenhLyDienBien"].ToString();
                txtTomtatKetQuaMau.Text = reader["TongKet_XetNghiemMau"].ToString();
                txtTomtatKetQuaTebao.Text = reader["TongKet_XetNghiemTeBao"].ToString();
                txtTomtatKetQuaBLGP.Text = reader["TongKet_XetNghiemBLGP"].ToString();
                txtTomtatKetQuaXquang.Text = reader["TongKet_XetNghiemXQuang"].ToString();
                txtTomtatKetQuaSieuAm.Text = reader["TongKet_XetNghiemSieuAm"].ToString();
                txtTomtatKetQuaXNKhac.Text = reader["TongKet_XetNghiemKhac"].ToString();
                cmbPhuongPhapDieuTri.Text = reader["TongKet_PhuongPhapDieuTri"].ToString();
                txtSoDot.Text = reader["TongKet_PhuongPhapDieuTri_SoDot"].ToString();
                cmbDapUng.Text = reader["TongKet_PhuongPhapDieuTri_DapUng"].ToString();
                txtDieuTriKhac.Text = reader["TongKet_PhuongPhapDieuTri_Khac"].ToString();
                txtTongKetTinhTrangRaVien.Text = reader["TongKet_RaVien"].ToString();
                txtTongKetHuongDieuTri.Text = reader["TongKet_RaVien_HuongDieuTriTiep"].ToString();
                txtTienPhauU.Text = reader["TongKet_PhuongPhapDieuTri_TienPhauU"].ToString();
                txtTienPhauHach.Text = reader["TongKet_PhuongPhapDieuTri_TienPhauHach"].ToString();
                txtPhauThuat.Text = reader["TongKet_PhuongPhapDieuTri_PhauThuat"].ToString();
                txtHauPhauU.Text = reader["TongKet_PhuongPhapDieuTri_HauphauU"].ToString();
                txtHauPhauHach.Text = reader["TongKet_PhuongPhapDieuTri_HauPhauHach"].ToString();
                txtHoaChat.Text = reader["TongKet_PhuongPhapDieuTri_HoaChat"].ToString();
                txtDonThuanHach.Text = reader["TongKet_PhuongPhapDieuTri_DonThuanHach"].ToString();
                txtDonThuanU.Text = reader["TongKet_PhuongPhapDieuTri_DonThuanU"].ToString();
                txtDapUngText.Text = reader["TongKet_PhuongPhapDieuTri_DapUngText"].ToString();
                txtLyDoVaoVien.Text = reader["BenhAn_LyDoVaoVien"].ToString();
                txtVaoNgayThu.Text = reader["BenhAn_NgayBenh"].ToString();
                txtQuaTrinhbenhLy.Text = reader["BenhAn_BenhLy"].ToString();
                txtTienSuBenh.Text = reader["BenhAn_TienSuBanThan"].ToString();
                txtKyHieuDiUng.Text = reader["BenhAn_TienSuDacDiemDiUng"].ToString();
                txtKyHieuMaTuy.Text = reader["BenhAn_TienSuDacDiemMaTuy"].ToString();
                txtKyHieuRuouBia.Text = reader["BenhAn_TienSuDacDiemRuouBia"].ToString();
                txtKyHieuThuocLa.Text = reader["BenhAn_TienSuDacDiemThuocLa"].ToString();
                txtKyHieuThuocLao.Text = reader["BenhAn_TienSuDacDiemThuocLao"].ToString();
                txtKyHieuKhac.Text = reader["BenhAn_TienSuDacDiemKhac"].ToString();
                txtGiaDinh.Text = reader["BenhAn_TienSuGiaDinh"].ToString();
                txtKhamBenhToanThan.Text = reader["BenhAn_KhamBenhToanThan"].ToString();
                txtKhamBenhBoPhanTonThuong.Text = reader["BenhAn_KhamBenhBoPhan"].ToString();
                txtKhamBenhVungTonThuong.Text = reader["BenhAn_KhamBenhBoMoTa"].ToString();
                txtKhamBenhMach.Text = reader["BenhAn_KhamBenhMach"].ToString();
                txtKhamBenhNhietDo.Text = reader["BenhAn_KhamBenhNhietDo"].ToString();
                txtKhamBenhHuyetAp.Text = reader["BenhAn_KhamBenhHuyetAp"].ToString();
                txtKhamBenhNhipTho.Text = reader["BenhAn_KhamBenhNhipTho"].ToString();
                txtKhamBenhCanNang.Text = reader["BenhAn_KhamBenhCanNang"].ToString();
                txtKhamBenhChieuCao.Text = reader["BenhAn_KhamBenhChieuCao"].ToString();
                txtKhamBenhXetNghiem.Text = reader["BenhAn_XetNghiemCanLam"].ToString();
                txtKhamBenhTomTatBenhAn.Text = reader["BenhAn_TomTat"].ToString();
                txtBenhChinhKhiVaoKhoa.Text = reader["BenhAn_ChanDoanBenhChinhVaoKhoa"].ToString();
                txtBenhPhuKhiVaoKhoa.Text = reader["BenhAn_ChanDoanBenhPhuVaoKhoa"].ToString();
                txtPhanBietKhiVaoKhoa.Text = reader["BenhAn_ChanDoanPhanBietVaoKhoa"].ToString();
                txtTienLuong.Text = reader["BenhAn_TienLuong"].ToString();
                txtHuongDieuTri.Text = reader["BenhAn_HuongDieuTri"].ToString();
                txtThoiGianDiUng.Text = reader["BenhAn_ThoiGianDiUng"].ToString();
                txtThoiGianMaTuy.Text = reader["BenhAn_ThoiGianMaTuy"].ToString();
                txtThoiGianRuouBia.Text = reader["BenhAn_ThoiGianRuouBia"].ToString();
                txtThoiGianThuocLa.Text = reader["BenhAn_ThoiGianThuocLa"].ToString();
                txtThoiGianThuocLao.Text = reader["BenhAn_ThoiGianThuocLao"].ToString();
                txtThoiGianKhac.Text = reader["BenhAn_ThoiGianKha"].ToString();
                cmbDieuTriNgoaiKhoa.Text = reader["TongKet_PhuongPhapDieuTri_PhauThuatNgoaiKhoa"].ToString(); 
                txtPhuongPhapDieuTriNgoaiKhoa.Text  = reader["TongKet_PhuongPhapDieuTri_NoiNgoai_Text"].ToString();
                txtKhamBenhChieuCao.Text =  reader["BenhAn_KhamBenhChieuCao"].ToString();
                txtKetQuaCLS.Text = reader["TongKet_KetQuaCLS_NoiNgoai"].ToString();
                txtMAT_ThiLucMP_KhongKinh_RaVien.Text = reader["MAT_ThiLucMP_KhongKinh_RaVien"].ToString();
                txtMAT_ThiLucMT_KhongKinh_RaVien.Text = reader["MAT_ThiLucMT_KhongKinh_RaVien"].ToString();
                txtMAT_ThiLucMP_CoKinh_RaVien.Text = reader["MAT_ThiLucMP_CoKinh_RaVien"].ToString();
                txtMAT_ThiLucMT_CoKinh_RaVien.Text = reader["MAT_ThiLucMT_CoKinh_RaVien"].ToString();
                txtMAT_NhanApMP_RaVien.Text = reader["MAT_NhanApMP_RaVien"].ToString();
                txtMAT_NhanApMT_RaVien.Text = reader["MAT_NhanApMT_RaVien"].ToString();
                txtMAT_ThiTruongMP_RaVien.Text = reader["MAT_ThiTruongMP_RaVien"].ToString();
                txtMAT_ThiTruongMT_RaVien.Text = reader["MAT_ThiTruongMT_RaVien"].ToString();
            }
            reader.Close();


        }
        private void cmbKhamBenhCoQuan_TextChanged_1(object sender, EventArgs e)
        {
            if (cmbKhamBenhCoQuan.SelectedIndex == -1|| cmbKhamBenhCoQuan.SelectedIndex == 0) {  return; }
            else
            {
                if(cmbKhamBenhCoQuan.SelectedIndex == 1 || cmbKhamBenhCoQuan.SelectedIndex == -1)
                {
                    new frmBenhAn_CacCoQuan(Global.GetCode(cmbKhamBenhCoQuan), _MaVaoVien).ShowDialog();
                    groupBox8.Enabled = true;
                    cmbDieuTriNgoaiKhoa.Visible = false;
                    txtPhuongPhapDieuTriNgoaiKhoa.Visible = false;
                    txtKetQuaCLS.Visible = false;
                }
                if (cmbKhamBenhCoQuan.SelectedIndex == 3)
                {
                    new frmBenhAn_CacCoQuan_NgoaiKhoa(Global.GetCode(cmbKhamBenhCoQuan), _MaVaoVien).ShowDialog();
                    cmbDieuTriNgoaiKhoa.Visible = true;
                    txtPhuongPhapDieuTriNgoaiKhoa.Visible = true;
                    txtKetQuaCLS.Visible = true;

                }
                if (cmbKhamBenhCoQuan.SelectedIndex == 2)
                {
                    new frmBenhAn_CacCoQuan_NoiKhoa(Global.GetCode(cmbKhamBenhCoQuan), _MaVaoVien).ShowDialog();
                    cmbDieuTriNgoaiKhoa.Visible = true;
                    txtPhuongPhapDieuTriNgoaiKhoa.Visible = true;
                    txtKetQuaCLS.Visible = true;
                }
                if (cmbKhamBenhCoQuan.SelectedIndex == 4)
                {
                    new frmBenhAn_CacCoQuan_TruyenNhiem(Global.GetCode(cmbKhamBenhCoQuan), _MaVaoVien).ShowDialog();
                    cmbDieuTriNgoaiKhoa.Visible = true;
                    txtPhuongPhapDieuTriNgoaiKhoa.Visible = true;
                    txtKetQuaCLS.Visible = true;
                }
                if (cmbKhamBenhCoQuan.SelectedIndex == 5)
                {
                    new frmBenhAn_CacCoQuan_TMH(5, _MaVaoVien).ShowDialog();
                    cmbDieuTriNgoaiKhoa.Visible = true;
                    txtPhuongPhapDieuTriNgoaiKhoa.Visible = true;
                    txtKetQuaCLS.Visible = true;
                }
                if (cmbKhamBenhCoQuan.SelectedIndex == 6)
                {
                    new frmBenhAn_CacCoQuan_Mat(Global.GetCode(cmbKhamBenhCoQuan), _MaVaoVien).ShowDialog();
                    cmbDieuTriNgoaiKhoa.Visible = true;
                    txtPhuongPhapDieuTriNgoaiKhoa.Visible = true;
                    txtKetQuaCLS.Visible = true;
                }
                if (cmbKhamBenhCoQuan.SelectedIndex == 7)
                {
                    new frmBenhAn_CacCoQuan_TMH(7, _MaVaoVien).ShowDialog();
                    cmbDieuTriNgoaiKhoa.Visible = true;
                    txtPhuongPhapDieuTriNgoaiKhoa.Visible = true;
                    txtKetQuaCLS.Visible = true;
                }
            }
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlCommand Cmd = new System.Data.SqlClient.SqlCommand("", GlobalModuls.Global.ConnectSQL);
            Cmd.CommandText = string.Format("set dateformat DMY if(exists(select * from BenhAn_QuanLyNguoiBenh where mavaovien='{0}'))"
                + " begin update BenhAn_QuanLyNguoiBenh set NgayVaoVien = '{1:dd/MM/yyyy HH:mm}', TrucTiepVao = N'{2}',NoiGioiThieu= N'{3}',LanNhapVien = '{4}',KhoaNhapVien = N'{5}',ChuyenVien = N'{6}', NoiChuyenVien = N'{7}',NgayNhapVien = '{8:dd/MM/yyyy HH:mm}',NgayRaVien = '{9:dd/MM/yyyy HH:mm}' ,NoiRaVien= N'{10}',SoNgayDieuTri = '{11}',SoNgayDTKhoa = '{12}',TonSoNgayDT_Text = N'{13}' where  mavaovien='{0}' end"
                + " else insert into BenhAn_QuanLyNguoiBenh([MaVaoVien], [NgayVaoVien], [TrucTiepVao], [NoiGioiThieu], [LanNhapVien], [KhoaNhapVien], [ChuyenVien], [NoiChuyenVien],[NgayNhapVien], [NgayRaVien], [NoiRaVien], [SoNgayDieuTri],[SoNgayDTKhoa],[TonSoNgayDT_Text],[BenhAn_InTongKet]) "
                + " values('{0}','{1:dd/MM/yyyy HH:mm}',N'{2}',N'{3}','{4}',N'{5}',N'{6}',N'{7}','{8:dd/MM/yyyy HH:mm}','{9:dd/MM/yyyy HH:mm}',N'{10}','{11}','{12}',N'{13}',1)", _MaVaoVien,txtBNNgayVaoVien.Value,cmbBNTrucTiepVao.Text,cmbBNNoiGioiThieu.Text,numBNLanVaoVien.Value,cmbKhoa.Text,cmbBNChuyenVien.Text,cmbBNTenNoiChuyenVien.Text, txtBNNgayVaoKhoa.Value, (txtBNNgayRaVien.Text == "01/01/1900 00:00") ? null : txtBNNgayRaVien.Value ,cmbBNNoiRaVien.Text,numBNTongNgayDT.Value, numBNNgayDT.Value,txtBNTongNgayChu.Text);
            Cmd.ExecuteNonQuery();

            Cmd.CommandText = string.Format("set dateformat DMY if(exists(select * from BenhAn_ChanDoan where mavaovien='{0}'))"
                + " begin update BenhAn_ChanDoan set [ChanDoan_NoiChuyenDen] = N'{1}', [ChanDoan_KKB] = N'{2}',[ChanDoan_KhoaDieuTri]= N'{3}',[MaBenhICD_NoiChuyenDen] = '{4}',[MaBenhICD_KKB] = N'{5}',[MaBenhICD_KhoaDieuTri] = N'{6}', [GhiChu_ChanDoanKhoaDieutri] = N'{7}',[ChanDoan_TaiBien] = N'{8}',[ChanDoan_BienChung] = N'{9}' ,[ChanDoan_DoPhauThuat]= N'{10}',[ChanDoan_DoGayMe] = '{11}',[ChanDoan_DoNhiemKhuan] = '{12}',[ChanDoan_Khac] = N'{13}',[ChanDoan_SoNgayDieuTriSauPT] = N'{14}',[ChanDoan_SoLanPhauThuat]= N'{15}' , [ChanDoan_BenhChinhRaVien] = N'{16}' ,[ChanDoan_ICDBenhChinhRaVien] = N'{17}' ,[ChanDoan_BenhKemTheoRaVien] = N'{18}',[ChanDoan_ICDBenhKemTheo] = N'{19}',[ChanDoan_TruocPhauThuat] = N'{20}',[ChanDoan_ICDTruocPhauThuat] = N'{21}',[ChanDoan_SauPhauThuat] = N'{22}',[ChanDoan_ICDSauPhauThuat] = N'{23}' where  mavaovien='{0}' end"
                + " else insert into BenhAn_ChanDoan([MaVaoVien], [ChanDoan_NoiChuyenDen], [ChanDoan_KKB], [ChanDoan_KhoaDieuTri], [MaBenhICD_NoiChuyenDen], [MaBenhICD_KKB], [MaBenhICD_KhoaDieuTri], [GhiChu_ChanDoanKhoaDieutri], [ChanDoan_TaiBien], [ChanDoan_BienChung], [ChanDoan_DoPhauThuat], [ChanDoan_DoGayMe], [ChanDoan_DoNhiemKhuan], [ChanDoan_Khac], [ChanDoan_SoNgayDieuTriSauPT],[ChanDoan_SoLanPhauThuat], [ChanDoan_BenhChinhRaVien], [ChanDoan_ICDBenhChinhRaVien], [ChanDoan_BenhKemTheoRaVien], [ChanDoan_ICDBenhKemTheo],[ChanDoan_TruocPhauThuat], [ChanDoan_ICDTruocPhauThuat], [ChanDoan_SauPhauThuat], [ChanDoan_ICDSauPhauThuat]) "
                + " values('{0}',N'{1}',N'{2}',N'{3}',N'{4}',N'{5}',N'{6}',N'{7}',N'{8}','{9}',N'{10}',N'{11}',N'{12}',N'{13}',N'{14}',N'{15}',N'{16}',N'{17}',N'{18}',N'{19}',N'{20}',N'{21}',N'{22}',N'{23}')", _MaVaoVien, txtChanDoanNoiChuyenDen.Text, txtChanDoanKKB.Text, txtChanDoanKhoaDieuTri.Text,txtChanDoanICDNoiChuyenDen.Text,txtChanDoanICDKBB.Text,txtChanDoanICDKhoaDieuTri.Text,"", this.ckChanDoanTaiBien.Checked ? 1 : 0 , this.ckChanDoanBienChung.Checked ? 1 : 0, this.ckChanDoanDoPhauThuat.Checked ? 1 : 0, this.ckChanDoanDoGayMe.Checked ? 1 : 0 , this.ckChanDoanDoNhiemKhuan.Checked ? 1 : 0 
                , this.ckChanDoanDoKhac.Checked ? 1 : 0 ,numChanDoanTongNgaySauPT.Value,numChanDoanSoLanPhauThuat.Value,txtChanDoanBenhChinh.Text,txtChanDoanICDBenhChinh.Text,txtChanDoanBenhKemTheo.Text,txtChanDoanICDBenhPhu.Text,txtChanDoanTruocPt.Text,txtChanDoanICDTruocPhauThuat.Text,txtChanDoanSauPT.Text,txtChanDoanICDSauPhauThuat.Text);
            Cmd.ExecuteNonQuery();

            Cmd.CommandText = string.Format("set dateformat DMY if(exists(select * from BenhAn_RaVien where mavaovien='{0}'))"
                + " begin update BenhAn_RaVien set [RaVien_KetQuaDieuTri] = N'{1}', [RaVien_GiaiPhauBenh] = N'{2}',[RaVien_NgayTuVong]= N'{3:dd/MM/yyyy HH:mm}',[RaVien_LoaiTuVong] = N'{4}',[RaVien_24GioTuVong] = N'{5}',[RaVien_NguyeNhanTuVong] = N'{6}', [RaVien_ICDNguyeNhanTuVong] = N'{7}',[RaVien_KhamTuThi] = N'{8}',[RaVien_ChanDoanGiaiPhauTuThi] = N'{9}' ,[RaVien_ICDChanDoanGiaiPhauTuThi]= N'{10}',RaVien_Sau24GioTuVong = N'{11}' where  mavaovien='{0}' end"
                + " else insert into BenhAn_RaVien([MaVaoVien], [RaVien_KetQuaDieuTri], [RaVien_GiaiPhauBenh], [RaVien_NgayTuVong], [RaVien_LoaiTuVong], [RaVien_24GioTuVong], [RaVien_NguyeNhanTuVong], [RaVien_ICDNguyeNhanTuVong], [RaVien_KhamTuThi], [RaVien_ChanDoanGiaiPhauTuThi], [RaVien_ICDChanDoanGiaiPhauTuThi],RaVien_Sau24GioTuVong) "
                + " values('{0}',N'{1}',N'{2}','{3:dd/MM/yyyy HH:mm}',N'{4}',N'{5}',N'{6}',N'{7}',N'{8}','{9}',N'{10}',N'{11}')", _MaVaoVien, cmbRaVienKetQuaDT.Text, cmbRaVienGiaiPhauBenh.Text, (txtRaVienNgayTuVong.Text == "01/01/1900 00:00" ) ? null: txtRaVienNgayTuVong.Value, cmbRaVienLoaiTuVong.Text, ckRaVien24TV.Checked? 1 : 0 , 
                    txtRaVienNguyenNhanTuVong.Text,txtMaNguyenNhanTV.Text,ckRaVienKhamNghiemTuThi.Checked ? 1:0, txtRaVienChanDoanGPTT.Text,txtRaVienMaGPTT.Text,ckRaVienSau24Gio.Checked ? 1:0);
            Cmd.ExecuteNonQuery();

            Cmd.CommandText = string.Format("set dateformat DMY if(exists(select * from BenhAn_ChiTiet where mavaovien='{0}'))"
                + " begin update BenhAn_ChiTiet set [BenhAn_LyDoVaoVien] = N'{1}', [BenhAn_NgayBenh] = N'{2}',[BenhAn_BenhLy]= N'{3}',[BenhAn_TienSuBanThan] = N'{4}',[BenhAn_TienSuDacDiemDiUng] = N'{5}',[BenhAn_TienSuDacDiemMaTuy] = N'{6}', [BenhAn_TienSuDacDiemThuocLa] = N'{7}',[BenhAn_TienSuDacDiemThuocLao] = N'{8}',[BenhAn_TienSuDacDiemKhac] = N'{9}' ,[BenhAn_TienSuGiaDinh]= N'{10}',BenhAn_KhamBenhToanThan = N'{11}',BenhAn_KhamBenhBoPhan = N'{12}' ,BenhAn_KhamBenhBoMoTa = N'{14}' ,BenhAn_KhamBenhMach = N'{15}' ,BenhAn_KhamBenhNhietDo = N'{16}' ,BenhAn_KhamBenhHuyetAp = N'{17}' ,BenhAn_KhamBenhNhipTho = N'{18}' ,BenhAn_KhamBenhCanNang = N'{19}',BenhAn_XetNghiemCanLam = N'{20}',BenhAn_TomTat = N'{21}',BenhAn_ChanDoanBenhChinhVaoKhoa = N'{22}',BenhAn_ChanDoanBenhPhuVaoKhoa = N'{23}',BenhAn_ChanDoanPhanBietVaoKhoa = N'{24}',BenhAn_TienLuong = N'{25}',BenhAn_HuongDieuTri = N'{26}',BenhAn_TienSuDacDiemRuouBia = N'{27}' ,BenhAn_ThoiGianDiUng = N'{28}' ,BenhAn_ThoiGianMaTuy = N'{29}' ,BenhAn_ThoiGianRuouBia = N'{30}' ,BenhAn_ThoiGianThuocLa = N'{31}' ,BenhAn_ThoiGianThuocLao = N'{32}' ,BenhAn_ThoiGianKha = N'{33}',BenhAn_KhamBenhChieuCao = N'{34}',[MAT_ThiLucMP_KhongKinh_RaVien] = N'{35}', [MAT_ThiLucMT_KhongKinh_RaVien]= N'{36}', [MAT_ThiLucMP_CoKinh_RaVien]= N'{37}', [MAT_ThiLucMT_CoKinh_RaVien] = N'{38}', [MAT_NhanApMP_RaVien]= N'{39}', [MAT_NhanApMT_RaVien] = N'{40}', [MAT_ThiTruongMP_RaVien] = N'{41}', [MAT_ThiTruongMT_RaVien] = N'{42}'  where  mavaovien='{0}' end"
                + " else insert into BenhAn_ChiTiet([MaVaoVien], [BenhAn_LyDoVaoVien], [BenhAn_NgayBenh], [BenhAn_BenhLy], [BenhAn_TienSuBanThan], [BenhAn_TienSuDacDiemDiUng], [BenhAn_TienSuDacDiemMaTuy], [BenhAn_TienSuDacDiemThuocLa], [BenhAn_TienSuDacDiemThuocLao], [BenhAn_TienSuDacDiemKhac], [BenhAn_TienSuGiaDinh], [BenhAn_KhamBenhToanThan], [BenhAn_KhamBenhBoPhan], [BenhAn_KhamBenhBoMoTa], [BenhAn_KhamBenhMach], [BenhAn_KhamBenhNhietDo], [BenhAn_KhamBenhHuyetAp], [BenhAn_KhamBenhNhipTho], [BenhAn_KhamBenhCanNang], [BenhAn_XetNghiemCanLam], [BenhAn_TomTat], [BenhAn_ChanDoanBenhChinhVaoKhoa], [BenhAn_ChanDoanBenhPhuVaoKhoa], [BenhAn_ChanDoanPhanBietVaoKhoa], [BenhAn_TienLuong], [BenhAn_HuongDieuTri], [BenhAn_TienSuDacDiemRuouBia],[BenhAn_ThoiGianDiUng], [BenhAn_ThoiGianMaTuy], [BenhAn_ThoiGianRuouBia], [BenhAn_ThoiGianThuocLa], [BenhAn_ThoiGianThuocLao], [BenhAn_ThoiGianKha],BenhAn_KhamBenhChieuCao,MAT_ThiLucMP_KhongKinh_RaVien, MAT_ThiLucMT_KhongKinh_RaVien, MAT_ThiLucMP_CoKinh_RaVien, MAT_ThiLucMT_CoKinh_RaVien, MAT_NhanApMP_RaVien, MAT_NhanApMT_RaVien, MAT_ThiTruongMP_RaVien, MAT_ThiTruongMT_RaVien) "
                + " values('{0}',N'{1}',N'{2}',N'{3}',N'{4}',N'{5}',N'{6}',N'{7}',N'{8}','{9}',N'{10}',N'{11}',N'{12}',N'{14}',N'{15}',N'{16}',N'{17}',N'{18}',N'{19}',N'{20}',N'{21}',N'{22}',N'{23}',N'{24}',N'{25}',N'{26}',N'{27}',N'{28}',N'{29}',N'{30}',N'{31}',N'{32}',N'{33}',N'{34}',N'{35}',N'{36}',N'{37}',N'{38}',N'{39}',N'{40}',N'{41}',N'{42}')", _MaVaoVien, txtLyDoVaoVien.Text, txtVaoNgayThu.Text, txtQuaTrinhbenhLy.Text, txtTienSuBenh.Text, txtKyHieuDiUng.Text, txtKyHieuMaTuy.Text, txtKyHieuThuocLa.Text, txtKyHieuThuocLao.Text, txtKyHieuKhac.Text, txtGiaDinh.Text, txtKhamBenhToanThan.Text, txtKhamBenhBoPhanTonThuong.Text, pctKhamBenhAnhTonThuong.Image, txtKhamBenhVungTonThuong.Text, txtKhamBenhMach.Text, txtKhamBenhNhietDo.Text, txtKhamBenhHuyetAp.Text, txtKhamBenhNhipTho.Text, txtKhamBenhCanNang.Text, txtKhamBenhXetNghiem.Text, txtKhamBenhTomTatBenhAn.Text, txtBenhChinhKhiVaoKhoa.Text, txtBenhPhuKhiVaoKhoa.Text, txtPhanBietKhiVaoKhoa.Text, txtTienLuong.Text, txtHuongDieuTri.Text, txtKyHieuRuouBia.Text, txtThoiGianDiUng.Text,txtThoiGianMaTuy.Text,txtThoiGianRuouBia.Text,txtThoiGianThuocLa.Text,txtThoiGianThuocLao.Text,txtThoiGianKhac.Text, txtKhamBenhChieuCao.Text,txtMAT_ThiLucMP_KhongKinh_RaVien.Text,txtMAT_ThiLucMT_KhongKinh_RaVien.Text,txtMAT_ThiLucMP_CoKinh_RaVien.Text,txtMAT_ThiLucMT_CoKinh_RaVien.Text,txtMAT_NhanApMP_RaVien.Text,txtMAT_NhanApMT_RaVien.Text ,txtMAT_ThiTruongMP_RaVien.Text,txtMAT_ThiTruongMT_RaVien.Text);
            Cmd.ExecuteNonQuery();

            Cmd.CommandText = string.Format("set dateformat DMY if(exists(select * from BenhAn_TongKet where mavaovien='{0}'))"
                                            + " begin update BenhAn_TongKet set [TongKet_BenhLyDienBien] = N'{1}', [TongKet_XetNghiemMau] = N'{2}',[TongKet_XetNghiemTeBao]= N'{3}',[TongKet_XetNghiemBLGP] = N'{4}',[TongKet_XetNghiemXQuang] = N'{5}',[TongKet_XetNghiemSieuAm] = N'{6}', [TongKet_XetNghiemKhac] = N'{7}', "
                                            + "[TongKet_PhuongPhapDieuTri] = N'{8}',[TongKet_PhuongPhapDieuTri_SoDot] = N'{9}' ,[TongKet_PhuongPhapDieuTri_DapUng]= N'{10}',TongKet_PhuongPhapDieuTri_Khac = N'{11}',TongKet_RaVien = N'{12}' ,TongKet_RaVien_HuongDieuTriTiep = N'{13}' ,TongKet_PhuongPhapDieuTri_TienPhauU = N'{14}' ,TongKet_PhuongPhapDieuTri_TienPhauHach = N'{15}' ,TongKet_PhuongPhapDieuTri_PhauThuat = N'{16}' ,TongKet_PhuongPhapDieuTri_HauphauU = N'{17}' ,TongKet_PhuongPhapDieuTri_HauPhauHach = N'{18}',TongKet_PhuongPhapDieuTri_Hoachat = N'{19}',TongKet_PhuongPhapDieuTri_DonThuanU= N'{20}',TongKet_PhuongPhapDieuTri_DonThuanHach= N'{21}',TongKet_PhuongPhapDieuTri_DapUngText= N'{22}',TongKet_PhuongPhapDieuTri_PhauThuatNgoaiKhoa = N'{23}',TongKet_PhuongPhapDieuTri_NoiNgoai_Text = N'{24}',TongKet_KetQuaCLS_NoiNgoai = N'{25}' where  mavaovien='{0}' end"
                                            + " else insert into BenhAn_TongKet([MaVaoVien], [TongKet_BenhLyDienBien], [TongKet_XetNghiemMau], [TongKet_XetNghiemTeBao], [TongKet_XetNghiemBLGP], [TongKet_XetNghiemXQuang], [TongKet_XetNghiemSieuAm], [TongKet_XetNghiemKhac], [TongKet_PhuongPhapDieuTri], [TongKet_PhuongPhapDieuTri_SoDot], [TongKet_PhuongPhapDieuTri_DapUng], [TongKet_PhuongPhapDieuTri_Khac], [TongKet_RaVien], [TongKet_RaVien_HuongDieuTriTiep], [TongKet_PhuongPhapDieuTri_TienPhauU], [TongKet_PhuongPhapDieuTri_TienPhauHach], [TongKet_PhuongPhapDieuTri_PhauThuat], [TongKet_PhuongPhapDieuTri_HauphauU], [TongKet_PhuongPhapDieuTri_HauPhauHach], [TongKet_PhuongPhapDieuTri_Hoachat],TongKet_PhuongPhapDieuTri_DonThuanU,TongKet_PhuongPhapDieuTri_DonThuanHach,TongKet_PhuongPhapDieuTri_DapUngText,TongKet_PhuongPhapDieuTri_PhauThuatNgoaiKhoa,TongKet_PhuongPhapDieuTri_NoiNgoai_Text,TongKet_KetQuaCLS_NoiNgoai) "
                                            + " values('{0}',N'{1}',N'{2}',N'{3}',N'{4}',N'{5}',N'{6}',N'{7}',N'{8}','{9}',N'{10}',N'{11}',N'{12}',N'{13}',N'{14}',N'{15}',N'{16}',N'{17}',N'{18}',N'{19}',N'{20}',N'{21}',N'{22}',N'{23}',N'{24}',N'{25}')", 
                                            _MaVaoVien, txtQuaTrinhBenhLyVaDienBien.Text, txtTomtatKetQuaMau.Text, txtTomtatKetQuaTebao.Text, txtTomtatKetQuaBLGP.Text, txtTomtatKetQuaXquang.Text, txtTomtatKetQuaSieuAm.Text, txtTomtatKetQuaXNKhac.Text, cmbPhuongPhapDieuTri.Text, txtSoDot.Text, cmbDapUng.Text, txtDieuTriKhac.Text, txtTongKetTinhTrangRaVien.Text, txtTongKetHuongDieuTri.Text, txtTienPhauU.Text, txtTienPhauHach.Text, txtPhauThuat.Text, txtHauPhauU.Text, txtHauPhauHach.Text,txtHoaChat.Text,txtDonThuanU.Text,txtDonThuanHach.Text,txtDapUngText.Text,cmbDieuTriNgoaiKhoa.Text,txtPhuongPhapDieuTriNgoaiKhoa.Text,txtKetQuaCLS.Text);
            Cmd.ExecuteNonQuery();

            Cmd.CommandText = string.Format("update NAMDINH_QLBN.dbo.BENHNHAN_CHITIET SET MaTinh_TP = '{1}', NoiCongTac =N'{2}',NgheNghiep= '{3}',LienHe = N'{4}',Ma_huyen = '{5}',XaPhuong = N'{6}',SoDienThoai = '{7}',SoNha = N'{8}', ThonPho = N'{9}' , In_BenhAn = 1, MaNuocNgoai = '{10}' WHERE MaVaoVien= '{0}'", _MaVaoVien, Global.GetCode(cmbHCTinh), txtHCNoiLamViec.Text, Global.GetCode(cmbHCNgheNghiep), txtHCHoTenNguoiNha.Text, Global.GetCode(cmbHCHuyen), txtHCXaPhuong.Text,txtHCSoDienThoai.Text,txtHCSoNha.Text, txtHCThonPho.Text, Global.GetCode(txtHNgoaiKieu));
            Cmd.ExecuteNonQuery();
            _fg[_fg.Row, "In_BenhAn"] = 1;
        }

        private void pctKhamBenhAnhTonThuong_Click(object sender, EventArgs e)
        {

        }

        private void frmBenhAn_Load(object sender, EventArgs e)
        {

        }

        private void tabControl1_TabIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            if (cmbKhamBenhCoQuan.SelectedIndex == -1 && tabControl1.SelectedIndex == 3)
            {
                MessageBox.Show("Chưa chọn loại bệnh án");
                tabControl1.SelectedIndex = 2;
                cmbKhamBenhCoQuan.Focus();
                return;
            }
        }

        private void cmbHCHuyen_TextChanged(object sender, EventArgs e)
        {
            //if (cmbHCHuyen.Tag.ToString() == "0") return;
            if (cmbHCHuyen.SelectedIndex == -1) { txtHCXaPhuong.ClearItems(); return; }
            SqlCommand command = new SqlCommand();
            command.Connection = Global.ConnectSQL;
            command.CommandText = string.Format("select SUBSTRING(MaXaPhuong,6,10) as MaXaPhuong,TenXaPhuog  from NAMDINH_SYSDB.dbo.DmXaPhuong where SUBSTRING(MaXaPhuong,1,3) = '{0}' and SUBSTRING(MaXaPhuong,4,2) = '{1}'", Global.GetCode(cmbHCTinh), Global.GetCode(cmbHCHuyen));
            SqlDataReader reader = command.ExecuteReader();
            txtHCXaPhuong.ClearItems();
            while (reader.Read())
            {
                this.txtHCXaPhuong.AddItem(string.Format("{0};{1}", reader["MaXaPhuong"], reader["TenXaPhuog"]));
            }
            txtHCXaPhuong.SelectedIndex = -1;
            reader.Close();
            command.Dispose();
        }

        private void cmbHCHuyen_BeforeOpen(object sender, CancelEventArgs e)
        {
            //if (cmbHCHuyen.Tag.ToString() == "0") return;
            //if (cmbHCHuyen.SelectedIndex == -1) { txtHCXaPhuong.ClearItems(); return; }
            //SqlCommand command = new SqlCommand();
            //command.Connection = Global.ConnectSQL;
            //command.CommandText = string.Format("select SUBSTRING(MaXaPhuong,6,10) as MaXaPhuong,TenXaPhuog  from NAMDINH_SYSDB.dbo.DmXaPhuong where SUBSTRING(MaXaPhuong,1,3) = '{0}' and SUBSTRING(MaXaPhuong,4,2) = '{1}'", Global.GetCode(cmbHCTinh), Global.GetCode(cmbHCHuyen));
            //SqlDataReader reader = command.ExecuteReader();
            //txtHCXaPhuong.ClearItems();
            //while (reader.Read())
            //{
            //    this.txtHCXaPhuong.AddItem(string.Format("{0};{1}", reader["MaXaPhuong"], reader["TenXaPhuog"]));
            //}
            //txtHCXaPhuong.SelectedIndex = -1;
            //reader.Close();
            //command.Dispose();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if(cmbKhamBenhCoQuan.SelectedIndex == 2)
            {
                rptBA_NoiKhoa rpt = new rptBA_NoiKhoa(_MaVaoVien, cmbKhoa.Text, txtBNNgayVaoKhoa.Text, numBNNgayDT.Value.ToString(), _SoHSBA, _SoLuuTru, cmbKhamBenhCoQuan.SelectedIndex);
                rpt.Show();
            }
            if (cmbKhamBenhCoQuan.SelectedIndex == 4)
            {
                rptBA_TruyenNhiem rpt = new rptBA_TruyenNhiem(_MaVaoVien, cmbKhoa.Text, txtBNNgayVaoKhoa.Text, numBNNgayDT.Value.ToString(), _SoHSBA, _SoLuuTru, cmbKhamBenhCoQuan.SelectedIndex);
                rpt.Show();
            }
            if (cmbKhamBenhCoQuan.SelectedIndex == 3)
            {
                rptBA_NgoaiKhoa rpt = new rptBA_NgoaiKhoa(_MaVaoVien, cmbKhoa.Text, txtBNNgayVaoKhoa.Text, numBNNgayDT.Value.ToString(), _SoHSBA, _SoLuuTru, cmbKhamBenhCoQuan.SelectedIndex);
                rpt.Show();
            }
            if (cmbKhamBenhCoQuan.SelectedIndex == 1 || cmbKhamBenhCoQuan.SelectedIndex == -1)
            {
                rptBA_UNGBUOU rpt = new rptBA_UNGBUOU(_MaVaoVien, cmbKhoa.Text, txtBNNgayVaoKhoa.Text, numBNNgayDT.Value.ToString(), _SoHSBA, _SoLuuTru, cmbKhamBenhCoQuan.SelectedIndex);
                rpt.Show();
            }
            if (cmbKhamBenhCoQuan.SelectedIndex == 5)
            {
                rptBA_TaiMuiHong rpt = new rptBA_TaiMuiHong(_MaVaoVien, cmbKhoa.Text, txtBNNgayVaoKhoa.Text, numBNNgayDT.Value.ToString(), _SoHSBA, _SoLuuTru, cmbKhamBenhCoQuan.SelectedIndex);
                rpt.Show();
            }
            if (cmbKhamBenhCoQuan.SelectedIndex == 7)
            {
                rptBA_RHM rpt = new rptBA_RHM(_MaVaoVien, cmbKhoa.Text, txtBNNgayVaoKhoa.Text, numBNNgayDT.Value.ToString(), _SoHSBA, _SoLuuTru, cmbKhamBenhCoQuan.SelectedIndex);
                rpt.Show();
            }
            if (cmbKhamBenhCoQuan.SelectedIndex == 6)
            {
                rptBA_MAT rpt = new rptBA_MAT(_MaVaoVien, cmbKhoa.Text, txtBNNgayVaoKhoa.Text, numBNNgayDT.Value.ToString(), _SoHSBA, _SoLuuTru, cmbKhamBenhCoQuan.SelectedIndex);
                rpt.Show();
            }

        }
    }
 }
