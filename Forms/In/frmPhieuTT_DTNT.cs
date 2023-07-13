using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GlobalModuls;
using C1.Win.C1FlexGrid;
using DataDynamics.ActiveReports.Toolbar;
using DataDynamics.ActiveReports.Viewer;
using System.Data.SqlClient;
using NamDinh_QLBN.Reports;

namespace NamDinh_QLBN.Forms.In
{
    public partial class frmPhieuTT_DTNT : Form
    {
        public frmPhieuTT_DTNT()
        {
            InitializeComponent();
        }

        private void frmPhieuTT_DTNT_Load(object sender, EventArgs e)
        {
            this.cmbKhoa.Tag = "0";
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
            reader.Close();
            command.Dispose();
            this.cmbKhoa.SelectedIndex = -1;
            this.cmbKhoa.Tag = "1";
            this.txtDNgay.Tag = "0";
            this.txtTNgay.Tag = "0";
            this.txtDNgay.Value = this.txtTNgay.Value = Global.NgayLV;
            this.txtTNgay.Tag = "1";
            this.txtDNgay.Tag = "1";
            this.fgDanhSach.ClipSeparators = "|;";
            DataDynamics.ActiveReports.Toolbar.Button button = new DataDynamics.ActiveReports.Toolbar.Button();
            Global.SetCmb(this.cmbKhoa, Global.glbMaKhoaPhong);
            button.Id = 0x138bL;
            button.ButtonStyle = ButtonStyle.Text;
            button.Caption = "Đ\x00f3ng";
            button.ToolTip = "Đ\x00f3ng b\x00e1o c\x00e1o";
            this.arvMain.Toolbar.Tools.Insert(0x18, button);
        }

        private void rdChuaRV_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdChuaRV.Checked)
            {
                this.txtDNgay.Enabled = this.txtTNgay.Enabled = false;
                this.Load_DSBenhNhan();
            }
            else
            {
                this.txtDNgay.Enabled = this.txtTNgay.Enabled = true;
                if (this.rdDaRV.Checked)
                {
                    this.Load_DSBenhNhan();
                }
                else
                {
                    this.Load_DSBenhNhan();
                }
            }
            arvMain.Document.Dispose();
        }

        private void Load_DSBenhNhan()
        {
            if ((this.cmbKhoa.SelectedIndex != -1) && !(this.cmbKhoa.Tag.ToString() == "0"))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = Global.ConnectSQL;
                string code = Global.GetCode(this.cmbKhoa);
                command.CommandText = "set dateformat mdy select BENHNHAN_CHITIET.MaVaoVien,BENHNHAN_CHITIET.BA_NOINGOAI,BENHNHAN.HoTen As TenBenhNhan,Year(GetDate())-NamSinh as Tuoi, GioiTinh,TenDT,KHOA.NGAYCHUYEN as NgayVaoVien,DiaChi,GtriTu,GTriDen,MaDoiTuongBHXH  + SoThe + ViewDOITUONGHIENTAI.MaNoiCap as SoThe, ViewDOITUONGHIENTAI.Tuyen, Tennoicap as NoiGioiThieu,TenBHYTCap as NoiCapThe,TenBuong, TenGiuong,CASE WHEN ViewKHOAHIENTAI.VDARAVIEN = 0 THEN GETDATE() ELSE NgayRaVien END AS NgayRaVien,CASE WHEN ChanDoanRaVien IS NULL THEN ViewKHOAHIENTAI.CHANDOAN ELSE ChanDoanRaVien END as ChanDoan,BENHNHAN_CHITIET.DaRaVien,BENHNHAN_CHITIET.SoHSBA, ViewDOITUONGHIENTAI.CapCuu, BENHNHAN_CHITIET.NGAYKHAM,BENHNHAN_CHITIET.Is_Covid FROM ((((((BENHNHAN INNER JOIN BENHNHAN_CHITIET ON BENHNHAN.MaBenhNhan=BENHNHAN_CHITIET.MaBenhNhan) INNER JOIN ViewDOITUONGHIENTAI ON BENHNHAN_CHITIET.MaVaoVien=ViewDOITUONGHIENTAI.MaVaoVien) INNER JOIN DMDOITUONGBN ON ViewDOITUONGHIENTAI.DoiTuong=DMDOITUONGBN.MaDT) INNER JOIN ViewKHOAHIENTAI ON BENHNHAN_CHITIET.MaVaoVien=ViewKHOAHIENTAI.MaVaoVien)  LEFT JOIN DMBUONGBENH ON BENHNHAN_CHITIET.Buong=DMBUONGBENH.ID_Buong and DMBUONGBENH.MaKhoa = '" + code + "')  LEFT JOIN DMGIUONGBENH ON BENHNHAN_CHITIET.Giuong=DMGIUONGBENH.ID_Giuong and DMGIUONGBENH.MaKhoa = '" + code + "' and DMGIUONGBENH.ID_Buong = DMBUONGBENH.Id_Buong)  LEFT JOIN NAMDINH_SYSDB.dbo.DMNOIDKKCBBD_BHYT a ON ViewDOITUONGHIENTAI.MaNoiCap=a.Manoicap  Left JOIN BENHNHAN_KHOA KHOA ON KHOA.MaVaoVien = BENHNHAN_CHITIET.MaVaoVien AND KHOA.LanChuyenKhoa =0 WHERE ViewKHOAHIENTAI.MaKhoa ='" + code + "'  AND TrangThai=1 ";
                if (this.rdChuaRV.Checked)
                {
                    command.CommandText = command.CommandText + " AND ViewKHOAHIENTAI.vDaRaVien=0";
                }
                if (this.rdDaRV.Checked)
                {
                    command.CommandText = command.CommandText + " AND ViewKHOAHIENTAI.vDaRaVien=1";
                    command.CommandText = command.CommandText + string.Format(" AND  NgayRaVien >= '{0:MM/dd/yyyy 00:00:01}' and NgayRaVien <= '{1:MM/dd/yyyy 23:59:59}'", this.txtTNgay.Value, this.txtDNgay.Value);
                }
                if (this.rdChuyenKhoa.Checked)
                {
                    command.CommandText = string.Format("SELECT B.MAVAOVIEN,b.BA_NOINGOAI,A.HOTEN AS TENBENHNHAN,YEAR(GETDATE()) - A.NAMSINH AS TUOI,A.GIOITINH,BENHNHAN_KHOA.NGAYCHUYEN AS NGAYVAOVIEN, B.DIACHI,V.GTRIDEN,V.GTRITU,V.MaDoiTuongBHXH  + V.SoThe + V.MaNoiCap as SoThe, V.Tuyen, AA.TENNOICAP AS NOIGIOITHIEU,DMGIUONGBENH.TENGIUONG,DMBUONGBENH.TENBUONG,CHUYENDEN.NGAYCHUYEN AS NGAYRAVIEN,CASE WHEN B.CHANDOANRAVIEN IS NULL THEN CHUYENDI.CHANDOAN ELSE B.CHANDOANRAVIEN END AS CHANDOAN,V.TENBHYTCAP AS NOICAPTHE,TENDT,B.DaRaVien,B.SoHSBA,V.CapCuu,B.NGAYKHAM,B.Is_covid FROM (BENHNHAN A INNER JOIN BENHNHAN_CHITIET B ON A.MABENHNHAN = B.MABENHNHAN) INNER JOIN BENHNHAN_KHOA CHUYENDI ON CHUYENDI.MAKHOA = '{0}' AND CHUYENDI.MAVAOVIEN = B.MAVAOVIEN INNER JOIN BENHNHAN_KHOA CHUYENDEN ON CHUYENDEN.MAVAOVIEN = B.MAVAOVIEN AND CHUYENDEN.LANCHUYENKHOA = CHUYENDI.LANCHUYENKHOA +1 INNER JOIN BENHNHAN_KHOA ON BENHNHAN_KHOA.MAVAOVIEN = B.MAVAOVIEN AND BENHNHAN_KHOA.LANCHUYENKHOA = 0 INNER JOIN VIEWDOITUONGHIENTAI V ON V.MAVAOVIEN = B.MAVAOVIEN LEFT JOIN DMBUONGBENH ON DMBUONGBENH.ID_BUONG = B.BUONG AND DMBUONGBENH.MAKHOA = '{0}' LEFT JOIN DMGIUONGBENH ON DMGIUONGBENH.ID_GIUONG = B.GIUONG AND DMGIUONGBENH.ID_BUONG = B.BUONG AND DMGIUONGBENH.MAKHOA ='{0}' LEFT JOIN NAMDINH_SYSDB.dbo.DMNOIDKKCBBD_BHYT AA ON V.MaNoiCap=AA.MANOICAP LEFT JOIN DMDOITUONGBN ON DMDOITUONGBN.MADT = V.DOITUONG WHERE DATEDIFF(DD,CHUYENDEN.NGAYCHUYEN,'{1:MM/dd/yyyy}') <= 0 AND  DATEDIFF(DD,CHUYENDEN.NGAYCHUYEN,'{2:MM/dd/yyyy}') >= 0 ", code, this.txtTNgay.Value, this.txtDNgay.Value);
                }
                command.CommandText = command.CommandText + " order by TenBenhNhan";
                command.CommandTimeout = 0;
                SqlDataReader reader = command.ExecuteReader();
                this.fgDanhSach.Tag = "0";
                this.fgDanhSach.Rows.Count = 1;
                while (reader.Read())
                {
                    this.fgDanhSach.AddItem(string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6:dd/MM/yyyy HH:mm}|{7}|{8:dd/MM/yyyy}|{9:dd/MM/yyyy}|{10}|{11}|{12}|{13}|{14:dd/MM/yyyy HH:mm}|{15}|{16}|{17}|{18}|{19}|{20}|{21}|{22:dd/MM/yyyy HH:mm}|{23}|", new object[] {
                this.fgDanhSach.Rows.Count, reader["MaVaoVien"], reader["TenBenhNhan"], reader["Tuoi"], (reader["GioiTinh"].ToString() == "1") ? "Nam" : "Nữ", reader["TenDT"], reader["NgayVaoVien"], reader["DiaChi"], reader["GtriTu"], reader["GTriDen"], reader["SoThe"], reader["NoiGioiThieu"], reader["Tenbuong"], reader["TenGiuong"], reader["NgayRaVien"], reader["ChanDoan"],
                reader["NoiCapThe"], reader["DaRaVien"], reader["SoHSBA"], reader["BA_NOINGOAI"], reader["Tuyen"],reader["CapCuu"],reader["NGAYKHAM"], reader["Is_Covid"]}));
                }
                reader.Close();
                this.fgDanhSach.AutoSizeCols();
                this.fgDanhSach.Tag = "1";
                command.Dispose();
                this.Clear_Data();
            }
        }

        private void Clear_Data()
        {
            arvMain.Document.Dispose();
        }

        private void cmbKhoa_TextChanged(object sender, EventArgs e)
        {
            Load_DSBenhNhan();
        }

        private void fgDanhSach_AfterRowColChange(object sender, RangeEventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                if ((this.fgDanhSach.Row >= 1) && (this.fgDanhSach.Tag.ToString() != "0"))
                {
                    DateTime ngayLV;
                    string maVaoVien = this.fgDanhSach[this.fgDanhSach.Row, 1].ToString();
                    string code = Global.GetCode(this.cmbKhoa);
                    Global.wait("Đang chuẩn bị dữ liệu...!");
                    SqlCommand selectCommand = new SqlCommand();
                    selectCommand.Connection = Global.ConnectSQL;
                    DateTime data = (DateTime)this.fgDanhSach.GetData(this.fgDanhSach.Row, "NgayVaoVien");
                    if (this.fgDanhSach.GetDataDisplay(this.fgDanhSach.Row, "DaRaVien") == "0")
                    {
                        ngayLV = Global.GetNgayLV();
                    }
                    if (this.fgDanhSach.GetDataDisplay(this.fgDanhSach.Row, "Tuyen") == "1" && this.fgDanhSach.GetDataDisplay(this.fgDanhSach.Row, "DoiTuong") == "Bảo hiểm y tế")
                    {
                        MessageBox.Show("TUYẾN CỦA BỆNH NHÂN CHƯA ĐÚNG", "Cảnh báo!",MessageBoxButtons.RetryCancel,MessageBoxIcon.Asterisk);
                        return;
                    }
                    else
                    {
                        ngayLV = (DateTime)this.fgDanhSach.GetData(this.fgDanhSach.Row, "NgayRaVien");
                    }
                    int lanChuyenKhoaHT = Global.GetLanChuyenKhoaHT_BC(maVaoVien, Global.GetCode(cmbKhoa));
                    DateTime time3 = ngayLV;
                    int num2 = lanChuyenKhoaHT;
                    selectCommand.CommandText = string.Concat(new object[] { "Select * from BENHNHAN_KHOA where MaVaoVien = '", maVaoVien, "' and LanChuyenKhoa =", num2 });
                    SqlDataReader reader = selectCommand.ExecuteReader();
                    if (reader.Read())
                    {
                        time3 = (DateTime)reader["NgayChuyen"];
                    }
                    reader.Close();
                    if (time3.Hour == 0)
                    {
                        time3 = time3.AddHours(16.0);
                    }
                    selectCommand.CommandText = string.Format("SELECT LANINTT FROM BENHNHAN_PHIEUDIEUTRI A  INNER JOIN PHIEUDIEUTRI_CHITIET B ON A.SOPHIEU = B.SOPHIEU WHERE A.MAVAOVIEN ='{0}' AND B.DATHANHTOAN = 1 GROUP BY LANINTT", this.fgDanhSach.GetDataDisplay(this.fgDanhSach.Row, 1));
                    selectCommand.CommandTimeout = 0;
                    reader = selectCommand.ExecuteReader();
                    this.cmbLanIn.Tag = "0";
                    this.cmbLanIn.ClearItems();
                    this.cmbLanIn.AddItem("0; ----- Chưa thanh to\x00e1n -------");
                    while (reader.Read())
                    {
                        this.cmbLanIn.AddItem(string.Format("{0};Thanh to\x00e1n lần: {1}", reader["lanintt"], reader["lanintt"]));
                    }
                    reader.Close();
                    // Kiểm tra chú nào chưa thực hiện thì báo
                    selectCommand.CommandText = string.Format("select tendichvu from PHIEUDIEUTRI_CHITIET CT inner join BENHNHAN_PHIEUDIEUTRI PDT on CT.Sophieu = pdt.Sophieu  inner join DMDICHVU DV on CT.Madichvu = DV.Madichvu "
                     + " where PDT.MAVAOVIEN  = '{0}'  and CT.dathuchien = 0 and CT.Loaidichvu >'B99'  and CT.Loaidichvu <'D'", this.fgDanhSach.GetDataDisplay(this.fgDanhSach.Row, 1));
                    selectCommand.CommandTimeout = 0;
                    reader = selectCommand.ExecuteReader();
                    string ChuaThucHien = "";
                    while (reader.Read())
                    {
                        ChuaThucHien = ChuaThucHien + Environment.NewLine + "     - " + reader["tendichvu"];
                    }
                    reader.Close();
                    if (ChuaThucHien != "")
                    {
                        //ChuaThucHien = ChuaThucHien.Substring(0, ChuaThucHien.Length - 2);
                        MessageBox.Show("Dịch vụ: " + ChuaThucHien + Environment.NewLine + "chưa thực hiện, đề nghị bạn kiểm tra lại.", "Cảnh báo!");
                    }
                    //-----------------------------------------
                    this.cmbLanIn.Tag = "1";
                    selectCommand.CommandText = string.Format(string.Concat(new object[] { " DECLARE @SoLuong_BH int DECLARE @SoLuong_VP int DECLARE @SoLuong_Khac int DECLARE @LanChuyenKhoa int "
                    +" SELECT @SoLuong_BH = SUM(B.SOLUONG) FROM  (BENHNHAN_PHIEUDIEUTRI A INNER JOIN PHIEUDIEUTRI_CHITIET B ON A.SOPHIEU = B.SOPHIEU AND B.TINHPHI = 0 AND B.DOITUONGBN = 1 AND B.DATHANHTOAN = 0)"
                    +" INNER JOIN DMDONGIA ON DMDONGIA.MADICHVU = B.MADICHVU AND DMDONGIA.MAKHOA = A.MAKHOA WHERE A.MAVAOVIEN = '{0}' AND A.MAKHOA ='{1}' GROUP BY B.MADICHVU"
                    +" SELECT @SoLuong_VP = SUM(B.SOLUONG) FROM  (BENHNHAN_PHIEUDIEUTRI A INNER JOIN PHIEUDIEUTRI_CHITIET B ON A.SOPHIEU = B.SOPHIEU AND B.TINHPHI = 0 AND B.DOITUONGBN = 3 AND B.DATHANHTOAN = 0)"
                    +" INNER JOIN DMDONGIA ON DMDONGIA.MADICHVU = B.MADICHVU AND DMDONGIA.MAKHOA = A.MAKHOA WHERE A.MAVAOVIEN = '{0}' AND A.MAKHOA ='{1}' GROUP BY B.MADICHVU"
                    +" SELECT @SoLuong_Khac = SUM(B.SOLUONG) FROM (BENHNHAN_PHIEUDIEUTRI A INNER JOIN PHIEUDIEUTRI_CHITIET B ON A.SOPHIEU = B.SOPHIEU AND B.TINHPHI = 0 AND B.DOITUONGBN NOT IN (1,3) AND B.DATHANHTOAN = 0)"
                    +" INNER JOIN DMDONGIA ON DMDONGIA.MADICHVU = B.MADICHVU AND DMDONGIA.MAKHOA = A.MAKHOA WHERE A.MAVAOVIEN = '{0}' AND A.MAKHOA ='{1}' GROUP BY B.MADICHVU"
                    +" SELECT AA.BANSAO, m.TenKhoa,m.GTriTu,m.GTriDen,m.TenBHYTCap,m.MaKhoa as MaKhoa_Khac,m.TenNoiCap, CASE WHEN AA.DOITUONGBN IS NULL THEN M.DOITUONGBN ELSE AA.DOITUONGBN END AS DOITUONGBN,"
                    +" AA.TENDT,AA.MAKHOA, CASE WHEN AA.LANCHUYENDT IS NULL THEN M.LANCHUYENDT ELSE AA.LANCHUYENDT END AS LANCHUYENDT, case when AA.TUYEN is null then m.tuyen else aa.tuyen end as Tuyen,"
                    +" AA.LOAIDICHVU,AA.TENLOAIDICHVU,AA.MADICHVU,AA.TENDICHVU, CASE WHEN AA.MALOAITHUOC_BHYT IS NULL THEN 'TDM_BHYT' ELSE AA.MALOAITHUOC_BHYT END AS MALOAITHUOC_BHYT,"
                    +" CASE WHEN AA.TENLOAITHUOC_BHYT IS NULL THEN N'Trong danh mục BHYT' ELSE AA.TENLOAITHUOC_BHYT END TENLOAITHUOC_BHYT, AA.THUTUIN_THUOC, CASE WHEN AA.LANCHUYENKHOA IS NULL THEN M.LANCHUYENKHOA ELSE AA.LANCHUYENKHOA END AS LANCHUYENKHOA,"
                    +" AA.TUNGAY,AA.HANTHE,AA.TENNOICAP,AA.DENNGAY,AA.DVT,AA.SL,AA.DONGIA, AA.THANHTIEN * AA.TyLe/100 as THANHTIEN,"
                    +" (CASE WHEN aa.DoiTuongBN = 1 THEN CASE WHEN AA.TUYEN = 0  THEN CASE AA.MaDichVu  WHEN 'E01000' THEN AA.THANHTIEN  ELSE  F.PhantramDuocHuong  * AA.THANHTIEN / 100  END ELSE 0.6 * F.PhantramDuocHuong * AA.THANHTIEN / 100  END  ELSE 0 END) * AA.TyLe/100 AS TienBH,"
                    +" (CASE WHEN aa.DoiTuongBN = 1 THEN CASE WHEN AA.TUYEN = 0 THEN CASE AA.MaDichVu WHEN 'E01000' THEN 0 ELSE AA.THANHTIEN - F.PhantramDuocHuong * AA.THANHTIEN / 100 END ELSE AA.THANHTIEN - 0.6 * F.PhantramDuocHuong * AA.THANHTIEN / 100 END ELSE AA.THANHTIEN END) * AA.TyLe/100 AS TienBN,"
                    +" m.ThuTuIn AS ThuTuIn_DichVu,m.TenLoaiDichVu_BHYT,m.MALOAIDICHVU_BHYT,m.SoThe,m.MaNoiCap,m.MAICD_BC FROM ( SELECT CASE WHEN '{1}' = E.MAKHOA OR LEFT(E.MAKHOA,4) = 'NV13' THEN '' ELSE N'BẢN SAO' END AS BANSAO,"
                    +" a.DoiTuongBN,UPPER(N'(Đối tượng thanh to\x00e1n: ' + d.TenDT + N')') as TenDT,BENHNHAN_DOITUONG.LanChuyenDT,BENHNHAN_DOITUONG.Tuyen, a.LoaiDichVu,b.TenLoaiDichVu,a.MaDichVu,c.TenDichVu, c.MaLoaiDichVu_BHYT,"
                    +" c.MaLoaiThuoc_BHYT,c.TenLoaiThuoc_BHYT,c.ThuTuIn_Thuoc, E.MaKhoa, Case LEFT(E.MAKHOA,4) when 'NV13' then ", lanChuyenKhoaHT, " else  BK.LANCHUYENKHOA end As LanChuyenKhoa,"
                    +" Case LEFT(E.MAKHOA,4) when 'NV13' then KD.TenKhoa else F.TenKhoa end as TenKhoa,KHOA_DAU.NGAYCHUYEN AS TUNGAY,"
                    +" CASE WHEN A.DOITUONGBN = 1 THEN N'- Số thẻ: ' + BENHNHAN_DOITUONG.MADOITUONGBHXH + BENHNHAN_DOITUONG.SOTHE + BENHNHAN_DOITUONG.MANOICAP ELSE '' END AS SOTHE1,"
                    +" CASE WHEN A.DOITUONGBN = 1 THEN N'- C\x00f3 gi\x00e1 trị từ ' + CONVERT(NVARCHAR(50),BENHNHAN_DOITUONG.GTRITU,103) + N' đến ' + CONVERT(NVARCHAR(50),BENHNHAN_DOITUONG.GTRIDEN,103) ELSE '' END AS HANTHE,N'Nơi cấp BHYT: ' + ISNULL(BENHNHAN_DOITUONG.TenBHYTCap,'') AS TenNoiCap, '",
                    string.Format("{0:MM/dd/yyyy HH:mm}", time3), "' as DenNgay, "
                    +" CASE WHEN F.KHOI = 0 THEN CASE WHEN F.KHOI = 0 AND (DMDONGIA.MADICHVU IS NULL OR A.TINHPHI = 1) THEN C.DVT ELSE Case when DMDONGIA.MADICHVU IS NULL then C.DVT else CONVERT(NVARCHAR(50),"
                    +" CASE WHEN A.DOITUONGBN = 1 THEN @SoLuong_BH ELSE CASE WHEN A.DOITUONGBN = 3 THEN @SoLuong_VP ELSE @SoLuong_Khac END END) + ' ' + C.DVT end END ELSE CASE WHEN F.KHOI = 1 AND (DMDONGIA.MADICHVU IS NULL OR A.TINHPHI = 1) THEN C.DVT ELSE Case when DMDONGIA.MADICHVU IS NULL then C.DVT else CONVERT(NVARCHAR(50),"
                    +" CASE WHEN A.DOITUONGBN = 1 THEN @SoLuong_BH ELSE CASE WHEN A.DOITUONGBN = 3 THEN @SoLuong_VP ELSE @SoLuong_Khac END END) + ' ' + C.DVT end END END AS DVT, "
                    +" CASE WHEN F.KHOI = 0 THEN CASE WHEN F.KHOI = 0 AND (DMDONGIA.MADICHVU IS NULL OR A.TINHPHI = 1) THEN  \t\tSum(SoLuong * SoThang) \tELSE  \t\t1 \tEND ELSE CASE WHEN F.KHOI = 1 AND (DMDONGIA.MADICHVU IS NULL OR A.TINHPHI = 1) THEN  \t\tSum(SoLuong * SoThang) \tELSE  \t\t1 \tEND END AS SL, "
                    +" CASE WHEN F.KHOI = 0 THEN  \tCASE WHEN F.KHOI = 0 AND (DMDONGIA.MADICHVU IS NULL OR A.TINHPHI = 1) THEN  \t\tcase when a.tinhphi = 0 then a.DonGia else 0 end  \tELSE  \t\tCASE WHEN DMDONGIA.is_CoDonGiaDB = 1 THEN  \t\t\tCASE WHEN CASE WHEN A.DOITUONGBN = 1 THEN @SoLuong_BH ELSE CASE WHEN A.DOITUONGBN = 3 THEN @SoLuong_VP ELSE @SoLuong_Khac END END <= 5 THEN  \t\t\t\tDMDONGIA.DG_15 \t\t\tELSE \t\t\t\tCASE WHEN CASE WHEN A.DOITUONGBN = 1 THEN @SoLuong_BH ELSE CASE WHEN A.DOITUONGBN = 3 THEN @SoLuong_VP ELSE @SoLuong_Khac END END >= 6 AND CASE WHEN A.DOITUONGBN = 1 THEN @SoLuong_BH ELSE CASE WHEN A.DOITUONGBN = 3 THEN @SoLuong_VP ELSE @SoLuong_Khac END END <= 10 THEN  \t\t\t\t\tDMDONGIA.DG_610 \t\t\t\tELSE \t\t\t\t\tCASE WHEN CASE WHEN A.DOITUONGBN = 1 THEN @SoLuong_BH ELSE CASE WHEN A.DOITUONGBN = 3 THEN @SoLuong_VP ELSE @SoLuong_Khac END END > 10 THEN  \t\t\t\t\t\tDMDONGIA.DG_T10 \t\t\t\t\tEND \t\t\t\tEND \t\t\tEND \t\tELSE  \t\t\tCASE WHEN CASE WHEN A.DOITUONGBN = 1 THEN @SoLuong_BH ELSE CASE WHEN A.DOITUONGBN = 3 THEN @SoLuong_VP ELSE @SoLuong_Khac END END <= 5 THEN  \t\t\t\tDMDONGIA.DG_15 \t\t\tELSE \t\t\t\tCASE WHEN CASE WHEN A.DOITUONGBN = 1 THEN @SoLuong_BH ELSE CASE WHEN A.DOITUONGBN = 3 THEN @SoLuong_VP ELSE @SoLuong_Khac END END >= 6 AND CASE WHEN A.DOITUONGBN = 1 THEN @SoLuong_BH ELSE CASE WHEN A.DOITUONGBN = 3 THEN @SoLuong_VP ELSE @SoLuong_Khac END END <= 10 THEN  \t\t\t\t\tDMDONGIA.DG_610 \t\t\t\tELSE \t\t\t\t\tCASE WHEN CASE WHEN A.DOITUONGBN = 1 THEN @SoLuong_BH ELSE CASE WHEN A.DOITUONGBN = 3 THEN @SoLuong_VP ELSE @SoLuong_Khac END END > 10 AND CASE WHEN A.DOITUONGBN = 1 THEN @SoLuong_BH ELSE CASE WHEN A.DOITUONGBN = 3 THEN @SoLuong_VP ELSE @SoLuong_Khac END END <= 20 THEN  \t\t\t\t\t\tDMDONGIA.DG_1020 \t\t\t\t\tELSE \t\t\t\t\t\tCASE WHEN CASE WHEN A.DOITUONGBN = 1 THEN @SoLuong_BH ELSE CASE WHEN A.DOITUONGBN = 3 THEN @SoLuong_VP ELSE @SoLuong_Khac END END > 20 AND CASE WHEN A.DOITUONGBN = 1 THEN @SoLuong_BH ELSE CASE WHEN A.DOITUONGBN = 3 THEN @SoLuong_VP ELSE @SoLuong_Khac END END <= 30 THEN  \t\t\t\t\t\t\tDMDONGIA.DG_T20 \t\t\t\t\t\tELSE \t\t\t\t\t\t\tDMDONGIA.DG_T1T \t\t\t\t\t\tEND \t\t\t\t\tEND \t\t\t\tEND \t\t\tEND \t\tEND \tEND ELSE  \tCASE WHEN F.KHOI = 1 AND (DMDONGIA.MADICHVU IS NULL OR A.TINHPHI = 1) THEN  \t\tcase when a.tinhphi = 0 then a.DonGia else 0 end  \tELSE  \t\tCASE WHEN DMDONGIA.is_CoDonGiaDB = 1 THEN  \t\t\tCASE WHEN CASE WHEN A.DOITUONGBN = 1 THEN @SoLuong_BH ELSE CASE WHEN A.DOITUONGBN = 3 THEN @SoLuong_VP ELSE @SoLuong_Khac END END <= 5 THEN  \t\t\t\tDMDONGIA.DG_15 \t\t\tELSE \t\t\t\tCASE WHEN CASE WHEN A.DOITUONGBN = 1 THEN @SoLuong_BH ELSE CASE WHEN A.DOITUONGBN = 3 THEN @SoLuong_VP ELSE @SoLuong_Khac END END >= 6 AND CASE WHEN A.DOITUONGBN = 1 THEN @SoLuong_BH ELSE CASE WHEN A.DOITUONGBN = 3 THEN @SoLuong_VP ELSE @SoLuong_Khac END END < 10 THEN  \t\t\t\t\tDMDONGIA.DG_610 \t\t\t\tELSE \t\t\t\t\tCASE WHEN CASE WHEN A.DOITUONGBN = 1 THEN @SoLuong_BH ELSE CASE WHEN A.DOITUONGBN = 3 THEN @SoLuong_VP ELSE @SoLuong_Khac END END >= 10 THEN  \t\t\t\t\t\tDMDONGIA.DG_T10 \t\t\t\t\tEND \t\t\t\tEND \t\t\tEND \t\tELSE  \t\t\tCASE WHEN CASE WHEN A.DOITUONGBN = 1 THEN @SoLuong_BH ELSE CASE WHEN A.DOITUONGBN = 3 THEN @SoLuong_VP ELSE @SoLuong_Khac END END <= 5 THEN  \t\t\t\tDMDONGIA.DG_15 \t\t\tELSE \t\t\t\tCASE WHEN CASE WHEN A.DOITUONGBN = 1 THEN @SoLuong_BH ELSE CASE WHEN A.DOITUONGBN = 3 THEN @SoLuong_VP ELSE @SoLuong_Khac END END >= 6 AND CASE WHEN A.DOITUONGBN = 1 THEN @SoLuong_BH ELSE CASE WHEN A.DOITUONGBN = 3 THEN @SoLuong_VP ELSE @SoLuong_Khac END END < 10 THEN  \t\t\t\t\tDMDONGIA.DG_610 \t\t\t\tELSE \t\t\t\t\tCASE WHEN CASE WHEN A.DOITUONGBN = 1 THEN @SoLuong_BH ELSE CASE WHEN A.DOITUONGBN = 3 THEN @SoLuong_VP ELSE @SoLuong_Khac END END >= 10 AND CASE WHEN A.DOITUONGBN = 1 THEN @SoLuong_BH ELSE CASE WHEN A.DOITUONGBN = 3 THEN @SoLuong_VP ELSE @SoLuong_Khac END END < 20 THEN  \t\t\t\t\t\tDMDONGIA.DG_1020 \t\t\t\t\tELSE \t\t\t\t\t\tCASE WHEN CASE WHEN A.DOITUONGBN = 1 THEN @SoLuong_BH ELSE CASE WHEN A.DOITUONGBN = 3 THEN @SoLuong_VP ELSE @SoLuong_Khac END END >= 20 AND CASE WHEN A.DOITUONGBN = 1 THEN @SoLuong_BH ELSE CASE WHEN A.DOITUONGBN = 3 THEN @SoLuong_VP ELSE @SoLuong_Khac END END < 30 THEN  \t\t\t\t\t\t\tDMDONGIA.DG_T20 \t\t\t\t\t\tELSE \t\t\t\t\t\t\tDMDONGIA.DG_T1T \t\t\t\t\t\tEND \t\t\t\t\tEND \t\t\t\tEND \t\t\tEND \t\tEND \tEND END as DonGia, CASE WHEN F.KHOI = 0 THEN \tCASE WHEN F.KHOI = 0 AND (DMDONGIA.MADICHVU IS NULL OR A.TINHPHI = 1) THEN  \t\tSum(SoLuong * SoThang * (case when a.tinhphi = 0 then a.DonGia else 0 end)) \tELSE  \t\tCASE WHEN DMDONGIA.is_CoDonGiaDB = 1 THEN \t\t\tCASE WHEN CASE WHEN A.DOITUONGBN = 1 THEN @SoLuong_BH ELSE CASE WHEN A.DOITUONGBN = 3 THEN @SoLuong_VP ELSE @SoLuong_Khac END END <= 5 THEN  \t\t\t\tDMDONGIA.DG_15 \t\t\tELSE \t\t\t\tCASE WHEN CASE WHEN A.DOITUONGBN = 1 THEN @SoLuong_BH ELSE CASE WHEN A.DOITUONGBN = 3 THEN @SoLuong_VP ELSE @SoLuong_Khac END END >= 6 AND CASE WHEN A.DOITUONGBN = 1 THEN @SoLuong_BH ELSE CASE WHEN A.DOITUONGBN = 3 THEN @SoLuong_VP ELSE @SoLuong_Khac END END <= 10 THEN  \t\t\t\t\tDMDONGIA.DG_610 \t\t\t\tELSE \t\t\t\t\tCASE WHEN CASE WHEN A.DOITUONGBN = 1 THEN @SoLuong_BH ELSE CASE WHEN A.DOITUONGBN = 3 THEN @SoLuong_VP ELSE @SoLuong_Khac END END > 10 THEN  \t\t\t\t\t\tDMDONGIA.DG_T10 \t\t\t\t\tEND \t\t\t\tEND \t\t\tEND\t\tELSE  \t\t\tCASE WHEN CASE WHEN A.DOITUONGBN = 1 THEN @SoLuong_BH ELSE CASE WHEN A.DOITUONGBN = 3 THEN @SoLuong_VP ELSE @SoLuong_Khac END END <= 5 THEN  \t\t\t\tDMDONGIA.DG_15 \t\t\tELSE \t\t\t\tCASE WHEN CASE WHEN A.DOITUONGBN = 1 THEN @SoLuong_BH ELSE CASE WHEN A.DOITUONGBN = 3 THEN @SoLuong_VP ELSE @SoLuong_Khac END END >= 6 AND CASE WHEN A.DOITUONGBN = 1 THEN @SoLuong_BH ELSE CASE WHEN A.DOITUONGBN = 3 THEN @SoLuong_VP ELSE @SoLuong_Khac END END <= 10 THEN  \t\t\t\t\tDMDONGIA.DG_610 \t\t\t\tELSE \t\t\t\t\tCASE WHEN CASE WHEN A.DOITUONGBN = 1 THEN @SoLuong_BH ELSE CASE WHEN A.DOITUONGBN = 3 THEN @SoLuong_VP ELSE @SoLuong_Khac END END > 10 AND CASE WHEN A.DOITUONGBN = 1 THEN @SoLuong_BH ELSE CASE WHEN A.DOITUONGBN = 3 THEN @SoLuong_VP ELSE @SoLuong_Khac END END <= 20 THEN  \t\t\t\t\t\tDMDONGIA.DG_1020 \t\t\t\t\tELSE \t\t\t\t\t\tCASE WHEN CASE WHEN A.DOITUONGBN = 1 THEN @SoLuong_BH ELSE CASE WHEN A.DOITUONGBN = 3 THEN @SoLuong_VP ELSE @SoLuong_Khac END END > 20 AND CASE WHEN A.DOITUONGBN = 1 THEN @SoLuong_BH ELSE CASE WHEN A.DOITUONGBN = 3 THEN @SoLuong_VP ELSE @SoLuong_Khac END END <= 30 THEN  \t\t\t\t\t\t\tDMDONGIA.DG_T20 \t\t\t\t\t\tELSE \t\t\t\t\t\t\tDMDONGIA.DG_T1T \t\t\t\t\t\tEND \t\t\t\t\tEND \t\t\t\tEND \t\t\tEND \t\tEND \tEND  ELSE \tCASE WHEN F.KHOI = 1 AND (DMDONGIA.MADICHVU IS NULL OR A.TINHPHI = 1) THEN  \t\tSum(SoLuong * SoThang * (case when a.tinhphi = 0 then a.DonGia else 0 end)) \tELSE  \t\tCASE WHEN DMDONGIA.is_CoDonGiaDB = 1 THEN \t\t\tCASE WHEN CASE WHEN A.DOITUONGBN = 1 THEN @SoLuong_BH ELSE CASE WHEN A.DOITUONGBN = 3 THEN @SoLuong_VP ELSE @SoLuong_Khac END END <= 5 THEN  \t\t\t\tDMDONGIA.DG_15 \t\t\tELSE \t\t\t\tCASE WHEN CASE WHEN A.DOITUONGBN = 1 THEN @SoLuong_BH ELSE CASE WHEN A.DOITUONGBN = 3 THEN @SoLuong_VP ELSE @SoLuong_Khac END END >= 6 AND CASE WHEN A.DOITUONGBN = 1 THEN @SoLuong_BH ELSE CASE WHEN A.DOITUONGBN = 3 THEN @SoLuong_VP ELSE @SoLuong_Khac END END <= 10 THEN  \t\t\t\t\tDMDONGIA.DG_610 \t\t\t\tELSE \t\t\t\t\tCASE WHEN CASE WHEN A.DOITUONGBN = 1 THEN @SoLuong_BH ELSE CASE WHEN A.DOITUONGBN = 3 THEN @SoLuong_VP ELSE @SoLuong_Khac END END > 10 THEN  \t\t\t\t\t\tDMDONGIA.DG_T10 \t\t\t\t\tEND \t\t\t\tEND \t\t\tEND\t\tELSE  \t\t\tCASE WHEN CASE WHEN A.DOITUONGBN = 1 THEN @SoLuong_BH ELSE CASE WHEN A.DOITUONGBN = 3 THEN @SoLuong_VP ELSE @SoLuong_Khac END END <= 5 THEN  \t\t\t\tDMDONGIA.DG_15 \t\t\tELSE \t\t\t\tCASE WHEN CASE WHEN A.DOITUONGBN = 1 THEN @SoLuong_BH ELSE CASE WHEN A.DOITUONGBN = 3 THEN @SoLuong_VP ELSE @SoLuong_Khac END END >= 6 AND CASE WHEN A.DOITUONGBN = 1 THEN @SoLuong_BH ELSE CASE WHEN A.DOITUONGBN = 3 THEN @SoLuong_VP ELSE @SoLuong_Khac END END <= 10 THEN  \t\t\t\t\tDMDONGIA.DG_610 \t\t\t\tELSE \t\t\t\t\tCASE WHEN CASE WHEN A.DOITUONGBN = 1 THEN @SoLuong_BH ELSE CASE WHEN A.DOITUONGBN = 3 THEN @SoLuong_VP ELSE @SoLuong_Khac END END > 10 AND CASE WHEN A.DOITUONGBN = 1 THEN @SoLuong_BH ELSE CASE WHEN A.DOITUONGBN = 3 THEN @SoLuong_VP ELSE @SoLuong_Khac END END <= 20 THEN  \t\t\t\t\t\tDMDONGIA.DG_1020 \t\t\t\t\tELSE \t\t\t\t\t\tCASE WHEN CASE WHEN A.DOITUONGBN = 1 THEN @SoLuong_BH ELSE CASE WHEN A.DOITUONGBN = 3 THEN @SoLuong_VP ELSE @SoLuong_Khac END END > 20 AND CASE WHEN A.DOITUONGBN = 1 THEN @SoLuong_BH ELSE CASE WHEN A.DOITUONGBN = 3 THEN @SoLuong_VP ELSE @SoLuong_Khac END END <= 30 THEN  \t\t\t\t\t\t\tDMDONGIA.DG_T20 \t\t\t\t\t\tELSE \t\t\t\t\t\t\tDMDONGIA.DG_T1T \t\t\t\t\t\tEND \t\t\t\t\tEND \t\t\t\tEND \t\t\tEND \t\tEND \tEND  END  as ThanhTien, a.TyLe "
                    +" FROM (((((PHIEUDIEUTRI_CHITIET a INNER JOIN INPHIEUTHANHTOAN c  ON c.MaDichVu=a.MaDichVu)   "
                    +" INNER JOIN DMLOAIDICHVU b ON b.MaLoaiDichVu= a.LoaiDichVu)  "
                    +" INNER JOIN DMDOITUONGBN d ON a.DoiTuongBN = d.MaDT)   "
                    +" INNER JOIN BENHNHAN_PHIEUDIEUTRI e ON a.SoPhieu=e.SoPhieu AND e.MaVaoVien='{0}')  "
                    +" INNER JOIN BENHNHAN_KHOA bk ON bk.MaVaoVien = e.MaVaoVien and BK.LANCHUYENKHOA = (SELECT MAX(LANCHUYENKHOA) FROM BENHNHAN_KHOA WHERE (BENHNHAN_KHOA.MAVAOVIEN = E.MAVAOVIEN) AND (BENHNHAN_KHOA.MAKHOA = E.MAKHOA or LEFT(e.SoPhieu,2)='CD' or LEFT(e.SoPhieu,2)='DT' or LEFT(e.SoPhieu,2)='PK' ) ) )"
                    +" LEFT JOIN DMKHOAPHONG f ON e.MaKhoa= f.MaKhoa   "
                    +" LEFT JOIN BENHNHAN_DOITUONG ON BENHNHAN_DOITUONG.DOITUONG = A.DOITUONGBN AND BENHNHAN_DOITUONG.MAVAOVIEN = '{0}' AND BENHNHAN_DOITUONG.LANCHUYENDT = A.LanChuyenDT "
                    +" INNER JOIN BENHNHAN_CHITIET ON BENHNHAN_CHITIET.MAVAOVIEN = E.MAVAOVIEN "
                    +" INNER JOIN BENHNHAN_KHOA KHOA_DAU ON KHOA_DAU.MAVAOVIEN = E.MAVAOVIEN AND KHOA_DAU.LANCHUYENKHOA = 0 "
                    +" LEFT JOIN DMKHOAPHONG KD ON KHOA_DAU.MaKhoa = KD.MaKHoa "
                    +" LEFT JOIN DMDONGIA ON DMDONGIA.MAKHOA = E.MAKHOA AND DMDONGIA.MADICHVU = A.MADICHVU "
                    +" ",(this.fgDanhSach.GetData(this.fgDanhSach.Row, "DoiTuong").ToString() == "Bảo hiểm y tế")? " INNER JOIN (Select madichvu from DMDICHVU where is_chenh = 0 or is_Chenh is null or (is_chenh = 1 and DongiaBHYT <> 0)) DMDVKHONGCHENH ON DMDVKHONGCHENH.madichvu = a.madichvu " : " INNER JOIN (Select madichvu from DMDICHVU) DMDVKHONGCHENH ON DMDVKHONGCHENH.madichvu = a.madichvu "," "
                    +" WHERE ", this.raChiPhiChuaThu.Checked ? " A.DATHANHTOAN = 0 AND " : " ((A.DATHANHTOAN = 0) OR (A.DATHANHTOAN = 1 AND A.LANINTT IS NULL )) AND", " a.LoaiDichVu <> 'E02' and ((LEFT(a.SoPhieu,2) <> 'CD'  AND e.MaKhoa = '{1}') or  "
                    +" (LEFT(a.SoPhieu ,2) ='CD' AND KHoa_Dau.MaKhoa = '{1}') or (LEFT(a.SoPhieu ,2) ='DT' AND KHoa_Dau.MaKhoa = '{1}') or (LEFT(a.SoPhieu ,2) ='PK' AND KHoa_Dau.MaKhoa = '{1}' and e.MaVaoVien > '1603')) GROUP BY BENHNHAN_DOITUONG.LanChuyenDT,BENHNHAN_DOITUONG.Tuyen, a.DoiTuongBN,d.TenDT,a.LoaiDichVu,b.TenLoaiDichVu,a.MaDichVu,c.TenDichVu,c.DVT,a.DonGia,a.tinhphi,f.Khoi, BENHNHAN_CHITIET.DARAVIEN,DMDONGIA.MADICHVU,DMDONGIA.DG_15,DMDONGIA.DG_610,DMDONGIA.DG_1020,DMDONGIA.DG_T20, DMDONGIA.DG_T1T,DMDONGIA.DG_T10,DMDONGIA.is_CoDonGiaDB, BK.LANCHUYENKHOA,F.TENKHOA,BK.NGAYCHUYEN,BENHNHAN_CHITIET.NGAYRAVIEN,KD.TENKHOA,A.DATHANHTOAN,e.MaKhoa,KHOA_DAU.NGAYCHUYEN,BENHNHAN_DOITUONG.SOTHE,BENHNHAN_DOITUONG.MADOITUONGBHXH, BENHNHAN_DOITUONG.MANOICAP,BENHNHAN_DOITUONG.GtriTu,BENHNHAN_DOITUONG.GTriDen,BENHNHAN_DOITUONG.TenBHYTCap, c.MaLoaiDichVu_BHYT,c.MaLoaiThuoc_BHYT,c.TenLoaiThuoc_BHYT,c.ThuTuIn_Thuoc, a.TyLe) AA RIGHT JOIN ( SELECT a.*,b.MaVaoVien,b.LanChuyenKhoa,b.MAICD_BC,C.LanChuyenDT,C.DoiTuong AS DOITUONGBN,c.tuyen,C.MADOITUONGBHXH,  CASE WHEN c.DoiTuong = 1 THEN c.MADOITUONGBHXH + c.SOTHE ELSE '' END AS SOTHE,c.MaNoiCap,E.Tennoicap, CASE WHEN c.DoiTuong = 1 THEN c.GTriTu ELSE null END AS GTriTu, CASE WHEN c.DoiTuong = 1 and kb.MienChiTraTrongNam !=1 THEN dbo.GetMaQuyenLoi(C.MADOITUONGBHXH,C.SOTHE,case when (C.Ngaychuyen >= '01/01/2015' and C.Ngaychuyen < '02/02/2015' ) then C.GtriTu else C.Ngaychuyen end) when kb.MienChiTraTrongNam =1 and kb.ThoiDiemMienChiTraTrongNam is not null then 1 else  0 END AS MaQuyenLoi, CASE WHEN c.DoiTuong = 1 THEN c.GTriDen ELSE null END AS GTriDen, c.TenBHYTCap, DMKHOAPHONG.TenKhoa,b.MaKhoa FROM NAMDINH_SYSDB.dbo.DMLOAIDICHVU_BHYT a INNER JOIN dbo.BENHNHAN_KHOA b ON 1= 1 AND B.MAVAOVIEN='{0}' INNER JOIN dbo.BENHNHAN_DOITUONG C ON b.MaVaoVien = C.MaVaoVien  inner join dbo.BENHNHAN_CHITIET ct on ct.MaVaoVien = c.MaVaoVien inner join NAMDINH_KHAMBENH.dbo.tblKHAMBENH kb on kb.MaKhambenh = ct.MaKhamBenh LEFT JOIN DMKHOAPHONG ON DMKHOAPHONG.MAKHOA = B.MAKHOA LEFT JOIN NAMDINH_SYSDB.DBO.DMNOIDKKCBBD_BHYT E ON E.Manoicap = C.MaNoiCap WHERE A.LOAI IN (0,2) and b.LanChuyenKhoa = ", lanChuyenKhoaHT, " AND ((B.MAKHOA = 'NV1212') OR (B.MAKHOA <>'NV1212'  )) ) m ON m.MaLoaiDichVu_BHYT = AA.MaLoaiDichVu_BHYT AND M.LANCHUYENKHOA = AA.LANCHUYENKHOA AND M.LANCHUYENDT = AA.LANCHUYENDT LEFT JOIN NAMDINH_SYSDB.DBO.DMQUYENLOI F ON F.MaQuyenLoi = m.MaQuyenLoi  ORDER BY LanChuyenKhoa,LanChuyenDT,M.ThuTuIn,aa.ThuTuIn_Thuoc" }), new object[] { maVaoVien, code, data, ngayLV });

                    rptTongKetChiPhi_NhomTheoLoaiBHYT ibhyt = new rptTongKetChiPhi_NhomTheoLoaiBHYT(maVaoVien, this.fgDanhSach[this.fgDanhSach.Row, 2].ToString(), this.fgDanhSach[this.fgDanhSach.Row, 3].ToString(), this.fgDanhSach[this.fgDanhSach.Row, 4].ToString(), this.fgDanhSach[this.fgDanhSach.Row, 5].ToString(), this.fgDanhSach.GetData(this.fgDanhSach.Row, 6), this.fgDanhSach[this.fgDanhSach.Row, "DiaChi"].ToString(), this.fgDanhSach[this.fgDanhSach.Row, "HanTheTu"].ToString(), this.fgDanhSach[this.fgDanhSach.Row, "HanTheDen"].ToString(), this.fgDanhSach[this.fgDanhSach.Row, "SoTheBHYT"].ToString(), this.fgDanhSach[this.fgDanhSach.Row, "NoiCapThe"].ToString(), this.fgDanhSach[this.fgDanhSach.Row, "Buong"].ToString(), this.fgDanhSach[this.fgDanhSach.Row, "Giuong"].ToString(), this.fgDanhSach.GetData(this.fgDanhSach.Row, "NgayRaVien"), this.fgDanhSach[this.fgDanhSach.Row, "ChanDoan"].ToString(), this.fgDanhSach.GetDataDisplay(this.fgDanhSach.Row, "NoiGioiThieu"), this.fgDanhSach.GetDataDisplay(this.fgDanhSach.Row, "SoHSBA"), code, this.fgDanhSach.GetDataDisplay(this.fgDanhSach.Row, "BA_NOINGOAI"), this.fgDanhSach.GetDataDisplay(this.fgDanhSach.Row, "CapCuu").ToString());
                    SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
                    DataTable dataTable = new DataTable("BaoCao");
                    DataTable table2 = new DataTable("Res");
                    selectCommand.CommandTimeout = 0;
                    adapter.Fill(dataTable);
                    table2 = dataTable.Copy();
                    int num3 = -1;
                    int num4 = -1;
                    foreach (DataRow row in dataTable.Rows)
                    {
                        if ((num3 != int.Parse(row["LanChuyenDT"].ToString())) || (num4 != int.Parse(row["LanChuyenKhoa"].ToString())))
                        {
                            DataRow row2;
                            num3 = int.Parse(row["LanChuyenDT"].ToString());
                            num4 = int.Parse(row["LanChuyenKhoa"].ToString());
                            DataSet set = new DataSet();
                            set.Merge(dataTable.Select(string.Format("LanChuyenDT={0} And LanChuyenKhoa = {1} And MALOAITHUOC_BHYT = '{2}' And MALOAIDICHVU_BHYT = 'THUOC'", num3, num4, "NGDM_BHYT")));
                            if (((set.Tables.Count <= 0) || ((set.Tables.Count > 0) && (set.Tables[0].Rows.Count <= 0))) && (row["DoiTuongBN"].ToString() == "1"))
                            {
                                row2 = table2.NewRow();
                                row2["LanChuyenDT"] = num3;
                                row2["LanChuyenKhoa"] = num4;
                                row2["MaLoaiDichVu_BHYT"] = "THUOC";
                                row2["TenLoaiDichVu_BHYT"] = "Thuốc, dịch truyền";
                                row2["MALOAITHUOC_BHYT"] = "NGDM_BHYT";
                                row2["DOITUONGBN"] = row["DOITUONGBN"].ToString();
                                row2["ThuTuIn_Thuoc"] = "2";
                                row2["ThuTuIn_DichVu"] = "8";
                                row2["TENLOAITHUOC_BHYT"] = "Ngo\x00e0i danh mục BHYT";
                                table2.Rows.InsertAt(row2, 0);
                            }
                            set.Clear();
                            set.Merge(dataTable.Select(string.Format("LanChuyenDT={0} And LanChuyenKhoa = {1} And MALOAITHUOC_BHYT = '{2}' And MALOAIDICHVU_BHYT = 'THUOC'", num3, num4, "TDM_BHYT")));
                            if (((set.Tables.Count <= 0) || ((set.Tables.Count > 0) && (set.Tables[0].Rows.Count <= 0))) && (row["DoiTuongBN"].ToString() == "1"))
                            {
                                row2 = table2.NewRow();
                                row2["LanChuyenDT"] = num3;
                                row2["LanChuyenKhoa"] = num4;
                                row2["MaLoaiDichVu_BHYT"] = "THUOC";
                                row2["TenLoaiDichVu_BHYT"] = "Thuốc, dịch truyền";
                                row2["MALOAITHUOC_BHYT"] = "TDM_BHYT";
                                row2["DOITUONGBN"] = row["DOITUONGBN"].ToString();
                                row2["ThuTuIn_Thuoc"] = "1";
                                row2["ThuTuIn_DichVu"] = "8";
                                row2["TENLOAITHUOC_BHYT"] = "Trong danh mục BHYT";
                                table2.Rows.InsertAt(row2, 0);
                            }
                            set.Clear();
                            set.Merge(dataTable.Select(string.Format("LanChuyenDT={0} And LanChuyenKhoa = {1} And MALOAITHUOC_BHYT = '{2}' And MALOAIDICHVU_BHYT = 'THUOC'", num3, num4, "UTNG_BHYT")));
                            if (((set.Tables.Count <= 0) || ((set.Tables.Count > 0) && (set.Tables[0].Rows.Count <= 0))) && (row["DoiTuongBN"].ToString() == "1"))
                            {
                                row2 = table2.NewRow();
                                row2["LanChuyenDT"] = num3;
                                row2["LanChuyenKhoa"] = num4;
                                row2["MaLoaiDichVu_BHYT"] = "THUOC";
                                row2["TenLoaiDichVu_BHYT"] = "Thuốc, dịch truyền";
                                row2["MALOAITHUOC_BHYT"] = "UTNG_BHYT";
                                row2["DOITUONGBN"] = row["DOITUONGBN"].ToString();
                                row2["ThuTuIn_Thuoc"] = "3";
                                row2["ThuTuIn_DichVu"] = "8";
                                row2["TENLOAITHUOC_BHYT"] = "Thuốc điều trị ung thư, chống thải gh\x00e9p ngo\x00e0i danh mục BHYT";
                                table2.Rows.InsertAt(row2, 0);
                            }
                            set.Clear();
                            set.Merge(dataTable.Select(string.Format("LanChuyenDT={0} And LanChuyenKhoa = {1} And MALOAITHUOC_BHYT = '{2}' And MALOAIDICHVU_BHYT = 'VATTU'", num3, num4, "NGDM_BHYT")));
                            if (((set.Tables.Count <= 0) || ((set.Tables.Count > 0) && (set.Tables[0].Rows.Count <= 0))) && (row["DoiTuongBN"].ToString() == "1"))
                            {
                                row2 = table2.NewRow();
                                row2["LanChuyenDT"] = num3;
                                row2["LanChuyenKhoa"] = num4;
                                row2["MaLoaiDichVu_BHYT"] = "VATTU";
                                row2["TenLoaiDichVu_BHYT"] = "Vật tư y tế";
                                row2["MALOAITHUOC_BHYT"] = "NGDM_BHYT";
                                row2["DOITUONGBN"] = row["DOITUONGBN"].ToString();
                                row2["ThuTuIn_Thuoc"] = "2";
                                row2["ThuTuIn_DichVu"] = "9";
                                row2["TENLOAITHUOC_BHYT"] = "Ngo\x00e0i danh mục BHYT";
                                table2.Rows.InsertAt(row2, 0);
                            }
                            set.Clear();
                            set.Merge(dataTable.Select(string.Format("LanChuyenDT={0} And LanChuyenKhoa = {1} And MALOAITHUOC_BHYT = '{2}' And MALOAIDICHVU_BHYT = 'VATTU'", num3, num4, "TDM_BHYT")));
                            if (((set.Tables.Count <= 0) || ((set.Tables.Count > 0) && (set.Tables[0].Rows.Count <= 0))) && (row["DoiTuongBN"].ToString() == "1"))
                            {
                                row2 = table2.NewRow();
                                row2["LanChuyenDT"] = num3;
                                row2["LanChuyenKhoa"] = num4;
                                row2["MaLoaiDichVu_BHYT"] = "VATTU";
                                row2["TenLoaiDichVu_BHYT"] = "Vật tư y tế";
                                row2["MALOAITHUOC_BHYT"] = "TDM_BHYT";
                                row2["DOITUONGBN"] = row["DOITUONGBN"].ToString();
                                row2["ThuTuIn_Thuoc"] = "1";
                                row2["ThuTuIn_DichVu"] = "9";
                                row2["TENLOAITHUOC_BHYT"] = "Trong danh mục BHYT";
                                table2.Rows.InsertAt(row2, 0);
                            }
                        }
                    }
                    DataSet set2 = new DataSet();
                    //set2.Merge(table2.Select("(MADICHVU NOT IN ('B01042','B01043','B01004','B01049','C51015','C51018','C51063','C50081','VT-VATU-0526','C57263','C57264') OR MADICHVU IS NULL)"));
                    set2.Merge(table2.Select("(MADICHVU NOT IS NULL)"));
                    if (set2.Tables.Count > 0)
                    {
                        DataView defaultView = set2.Tables[0].DefaultView;
                        defaultView.Sort = "LanChuyenKhoa,LanChuyenDT,ThuTuIn_DichVu,ThuTuIn_Thuoc";
                        DataTable table3 = defaultView.ToTable();
                        ibhyt.DataSource = table3;
                        ibhyt.Run();
                    }
                    this.arvMain.Document = ibhyt.Document;
                    selectCommand.Dispose();
                    Global.nowait();
                    DataTable table4 = new DataTable("Copy");
                    table4 = table2.Copy();
                    DataSet set3 = new DataSet();
                    if (this.fgDanhSach.GetData(this.fgDanhSach.Row, "DoiTuong").ToString() == "Bảo hiểm y tế")
                    {
                        rptTongKetChiPhi_Mau02 phi = new rptTongKetChiPhi_Mau02(maVaoVien, this.fgDanhSach[this.fgDanhSach.Row, 2].ToString(), this.fgDanhSach[this.fgDanhSach.Row, 3].ToString(), this.fgDanhSach[this.fgDanhSach.Row, 4].ToString(), this.fgDanhSach[this.fgDanhSach.Row, 5].ToString(), this.fgDanhSach.GetData(this.fgDanhSach.Row, 6), this.fgDanhSach[this.fgDanhSach.Row, "DiaChi"].ToString(), this.fgDanhSach[this.fgDanhSach.Row, "HanTheTu"].ToString(), this.fgDanhSach[this.fgDanhSach.Row, "HanTheDen"].ToString(), this.fgDanhSach[this.fgDanhSach.Row, "SoTheBHYT"].ToString(), this.fgDanhSach[this.fgDanhSach.Row, "NoiCapThe"].ToString(), this.fgDanhSach[this.fgDanhSach.Row, "Buong"].ToString(), this.fgDanhSach[this.fgDanhSach.Row, "Giuong"].ToString(), this.fgDanhSach.GetData(this.fgDanhSach.Row, "NgayRaVien"), this.fgDanhSach[this.fgDanhSach.Row, "ChanDoan"].ToString(), this.fgDanhSach.GetDataDisplay(this.fgDanhSach.Row, "NoiGioiThieu"), this.fgDanhSach.GetDataDisplay(this.fgDanhSach.Row, "SoHSBA"), code, this.fgDanhSach.GetDataDisplay(this.fgDanhSach.Row, "BA_NOINGOAI"), this.fgDanhSach.GetDataDisplay(this.fgDanhSach.Row, "Tuyen"));
                        //set3.Merge(table4.Select("MADICHVU = 'B01042' Or MADICHVU = 'B01043' or MADICHVU = 'B01004' or MaDichVu='B01049' or MaDichVu='C51015' or MaDichVu = 'C50081' or MaDichVu='C51018' or MaDichVu='C51063' or MADICHVU = 'VT-VATU-0526' or MADICHVU = 'C57263' or MADICHVU = 'C57264'"));
                        //set3.Merge(table4.Select(" Madichvu in (Select Madichvu From DMDICHVU where is_chenh = 1) or Madichvu = 'B01042' or Madichvu = 'B01043' or Madichvu = 'B01004' or Madichvu = 'B01049'"));

                        selectCommand.CommandText = "exec Fill_ChiPhi_ChenhLech @Mavaovien, @Makhoa, @lanChuyenKhoaHT, @NgayChuyen";
                        selectCommand.Parameters.Clear();
                        selectCommand.Parameters.AddWithValue("@Mavaovien", maVaoVien);
                        selectCommand.Parameters.AddWithValue("@Makhoa", code);
                        selectCommand.Parameters.AddWithValue("@lanChuyenKhoaHT", lanChuyenKhoaHT);
                        selectCommand.Parameters.AddWithValue("@NgayChuyen", time3);
                        SqlDataAdapter adap = new SqlDataAdapter(selectCommand);
                        adap.Fill(set3);
                        if (set3.Tables.Count > 0)
                        {
                            if (set3.Tables[0].Rows.Count > 0)
                            {
                                phi.DataSource = set3.Tables[0];
                                phi.Show();
                            }
                        }
                    }
                    reader.Close();
                }
            }
            else
            {
                if ((this.fgDanhSach.Row >= 1) && (this.fgDanhSach.Tag.ToString() != "0"))
                {
                    if (this.fgDanhSach.GetDataDisplay(this.fgDanhSach.Row, "Tuyen") == "1" && this.fgDanhSach.GetDataDisplay(this.fgDanhSach.Row, "DoiTuong") == "Bảo hiểm y tế")
                    {
                        MessageBox.Show("TUYẾN CỦA BỆNH NHÂN CHƯA ĐÚNG", "Cảnh báo!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Asterisk);
                        return;
                    }
                    DateTime ngayLV;
                    string maVaoVien = this.fgDanhSach[this.fgDanhSach.Row, 1].ToString();
                    string code = Global.GetCode(this.cmbKhoa);
                    //Global.wait("Đang chuẩn bị dữ liệu...!");
                    SqlCommand selectCommand = new SqlCommand();
                    selectCommand.Connection = Global.ConnectSQL;

                    fgDoiTuong.ClipSeparators = "|;";
                    fgDoiTuong.Rows.Count = 1;
                    selectCommand.CommandText = string.Format("select a.LanChuyenDT,a.NgayChuyen,a.DoiTuong,a.SoThe,a.MaNoiCap,a.GtriTu,a.GtriDen,a.Tuyen,a.CapCuu,b.DaTinhPhi from NAMDINH_QLBN.dbo.BENHNHAN_DOITUONG a inner join NAMDINH_QLBN.dbo.BENHNHAN_CHITIET b on a.MaVaoVien = b.MaVaoVien  where b.MaVaoVien = '{0}'", maVaoVien);
                    SqlDataReader dr = selectCommand.ExecuteReader();
                    while(dr.Read())
                    {
                        fgDoiTuong.AddItem(String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}",
                        dr["LanChuyenDT"],
                        dr["NgayChuyen"],
                        dr["DoiTuong"],
                        dr["SoThe"],
                        dr["MaNoiCap"],
                        dr["GtriTu"].ToString() == "" ? "'" : dr["GtriTu"],
                        dr["GtriDen"].ToString() == "" ? "'" : dr["GtriDen"],
                        dr["Tuyen"], dr["CapCuu"],dr["DaTinhPhi"]));
                    }
                    dr.Close();
                    //Lương note: Nếu bệnh nhân 2 đối tượng mới chạy đoạn lệnh này
                    /* Chuyển lại chi phí cho bệnh nhân------------------------------------------------------------------ */

                    //if (fgDanhSach[fgDanhSach.Row, "Is_Covid"].ToString() == "1")
                    //{
                    //    string Str = "";
                    //    for (int i = 1; i <= fgDoiTuong.Rows.Count - 1; i++)
                    //    {
                    //        if(i<2 && fgDoiTuong[i, "DoiTuong"].ToString() =="3" ) // benh nhan covid vien phi
                    //        {
                    //            Str = String.Format("update PHIEUDIEUTRI_CHITIET set DoiTuongBN = DT.DoiTuong,LanChuyenDT = DT.Maxlan,Dongia =  case when DT.DoiTuong = 3 THEN  z.Dongia WHEN DT.DoiTuong = 1 THEN z.DongiaBHYT END from NAMDINH_QLBN.dbo.PHIEUDIEUTRI_CHITIET x inner join NAMDINH_QLBN.dbo.BENHNHAN_PHIEUDIEUTRI y on x.SoPhieu = y.SoPhieu inner join NAMDINH_QLBN.dbo.DMLENCHIPHI_BYKHOID z on z.MaDichvu = x.MaDichVu  inner join NAMDINH_QLBN.dbo.ViewDOITUONGHIENTAI DT ON DT.MaVaoVien = y.MaVaoVien where y.MaVaoVien = '{0}'and x.TyLeBHYT = 100 AND x.LoaiDichvu != 'A01'", maVaoVien);
                    //                                                    selectCommand.CommandText = Str;
                    //            selectCommand.ExecuteNonQuery();
                    //        }
                    //    }

                    //}
                        string doituong1, lanchuyen1;
                        DateTime ngaychuyen1;
                        string Str;
                        for (int i = 1; i <= fgDoiTuong.Rows.Count - 1; i++)
                        {
                            if (fgDoiTuong[i, "DaTinhPhi"].ToString() == "0")
                            {
                                if(fgDanhSach[fgDanhSach.Row, "Is_Covid"].ToString() != "1")
                                {
                                    if (i < 2)
                                    {
                                        doituong1 = fgDoiTuong[i, "DoiTuong"].ToString();
                                        ngaychuyen1 = DateTime.Parse(fgDoiTuong[i, "NgayChuyen"].ToString());
                                        lanchuyen1 = fgDoiTuong[i, "LanChuyenDT"].ToString();
                                        //chuyển chi phí nội trú PHIEUDIEUTRI_CHITIET
                                        Str = "";
                                        Str = String.Format("set dateformat dmy UPDATE PHIEUDIEUTRI_CHITIET set DonGia = ");
                                        if (doituong1 == "1")
                                        { Str += String.Format(" CASE when (d.DongiaBHYT is NULL and c.LoaiDichVu Not in('D01','D02','D06','D05')) then 0.00 when (d.MaDichvu is NULL and c.LoaiDichVu in('D01','D02','D06','D05')) then c.DonGia else  d.DongiaBHYT end ,DoiTuongBN = 1,LanChuyenDT = {0}", lanchuyen1); };
                                        if (doituong1 == "3")
                                        {
                                            Str += String.Format(" CASE when (d.Dongia is NULL and  c.LoaiDichVu Not in('D01','D02','D06','D05')) then 0.00 when (d.MaDichvu is NULL and c.LoaiDichVu in('D01','D02','D06','D05')) then c.DonGia else  d.Dongia end, DoiTuongBN = 3,LanChuyenDT = {0}", lanchuyen1);
                                        };
                                        Str += String.Format(" from NAMDINH_QLBN.dbo.BENHNHAN_CHITIET a inner join NAMDINH_QLBN.dbo.BENHNHAN_PHIEUDIEUTRI b on a.MaVaoVien = b.MaVaoVien inner join NAMDINH_QLBN.dbo.PHIEUDIEUTRI_CHITIET c on c.SoPhieu = b.SoPhieu left join NAMDINH_QLBN.dbo.DMLENCHIPHI_BYKHOID d on d.MaDichvu = c.MaDichVu where a.MaVaoVien = '{0}'", maVaoVien, ngaychuyen1, lanchuyen1);
                                        selectCommand.CommandText = Str;
                                        selectCommand.ExecuteNonQuery();

                                        // chuyển chi phí phòng mổ
                                        Str = "";
                                        Str += String.Format("set dateformat dmy UPDATE BENHNHAN_PT_CHIPHI set DonGia = ");
                                        if (doituong1 == "1")
                                        { Str += String.Format("CASE when (d.DongiaBHYT is NULL and a.LoaiChiPhi Not in('D01','D02','D06','D05'))  then 0.00  when (d.MaDichvu is NULL and a.LoaiChiPhi in('D01','D02','D06','D05')) then a.DonGia else  d.DongiaBHYT end ,MaDTBN = 1,LanChuyenDT = {0}", lanchuyen1); };
                                        if (doituong1 == "3")
                                        {
                                            Str += String.Format(" CASE when (d.Dongia is NULL and a.LoaiChiPhi Not in('D01','D02','D06','D05'))  then 0.00 when (d.MaDichvu is NULL and a.LoaiChiPhi in('D01','D02','D06','D05')) then a.DonGia else  d.Dongia end, MaDTBN = 3,LanChuyenDT = {0}", lanchuyen1);
                                        };
                                        Str += String.Format(" from NAMDINH_QLBN.dbo.BENHNHAN_PT_CHIPHI a inner join NAMDINH_QLBN.dbo.BENHNHAN_PHIEUDIEUTRI b on a.MaVaoVien = b.MaVaoVien and a.SoPhieuCD = b.SoPhieu  left join NAMDINH_QLBN.dbo.DMLENCHIPHI_BYKHOID d on d.MaDichvu = a.MaDichVu where a.MaVaoVien = '{0}' and a.TinhPhi = 1", maVaoVien, ngaychuyen1, lanchuyen1);
                                        selectCommand.CommandText = Str;
                                        selectCommand.ExecuteNonQuery();

                                        // chuyển chi phí phòng khám

                                        Str = "";
                                        Str += String.Format("set dateformat dmy UPDATE NAMDINH_KHAMBENH.dbo.tblCHIPHI_DICHVU set DonGia = ");
                                        if (doituong1 == "1")
                                        { Str += String.Format(" CASE when (d.DongiaBHYT is NULL and a.LoaiChiPhi Not in('D01','D02','D06','D05')) then 0.00 when (d.MaDichvu is NULL and a.LoaiChiPhi in('D01','D02','D06','D05')) then a.DonGia else  d.DongiaBHYT end "); };
                                        if (doituong1 == "3")
                                        {
                                            Str += String.Format("CASE when (d.Dongia is NULL and a.LoaiChiPhi Not in('D01','D02','D06','D05')) then 0.00 when (d.MaDichvu is NULL and a.LoaiChiPhi in('D01','D02','D06','D05')) then a.DonGia  else  d.Dongia end ");
                                        };
                                        Str += String.Format(" from NAMDINH_KHAMBENH.dbo.tblCHIPHI_DICHVU a inner join namdinh_qlbn.dbo.BENHNHAN_CHITIET b on a.makhambenh = b.makhambenh  left join NAMDINH_QLBN.dbo.DMLENCHIPHI_BYKHOID d on d.MaDichvu = a.MaChiPhi where b.MaVaoVien = '{0}' and a.TinhPhi = 1 and d.madichvu != 'C52197' ", maVaoVien, ngaychuyen1, lanchuyen1);
                                        selectCommand.CommandText = Str;
                                        selectCommand.ExecuteNonQuery();

                                        // chuyen tuyen phong kham
                                        Str = "";
                                        if (fgDoiTuong[i, "CapCuu"].ToString() == "1")
                                        {
                                            Str += String.Format("set dateformat dmy update NAMDINH_KHAMBENH.DBO.tblKHAMBENH SET Tuyen = '2' "
                                               + "FROM NAMDINH_KHAMBENH.DBO.tblKHAMBENH A INNER Join  BENHNHAN_CHITIET b on a.MaKhambenh = b.MaKhamBenh  where  b.MaVaoVien ='{0}' "
                                               , maVaoVien, fgDoiTuong[i, "Tuyen"].ToString());
                                        }
                                        else
                                        {
                                            Str += String.Format("set dateformat dmy update NAMDINH_KHAMBENH.DBO.tblKHAMBENH SET Tuyen = '{1}' "
                                                + "FROM NAMDINH_KHAMBENH.DBO.tblKHAMBENH A INNER Join  BENHNHAN_CHITIET b on a.MaKhambenh = b.MaKhamBenh  where  b.MaVaoVien ='{0}' "
                                                , maVaoVien, fgDoiTuong[i, "Tuyen"].ToString());
                                        }
                                        selectCommand.CommandText = Str;
                                        selectCommand.ExecuteNonQuery();
                                    }
                                    else
                                    {
                                        doituong1 = fgDoiTuong[i, "DoiTuong"].ToString();
                                        ngaychuyen1 = DateTime.Parse(fgDoiTuong[i, "NgayChuyen"].ToString());
                                        lanchuyen1 = fgDoiTuong[i, "LanChuyenDT"].ToString();

                                        //chuyển chi phí nội trú PHIEUDIEUTRI_CHITIET
                                        Str = "";
                                        Str = String.Format("set dateformat dmy UPDATE PHIEUDIEUTRI_CHITIET set DonGia = ");
                                        if (doituong1 == "1")
                                        { Str += String.Format(" CASE when (d.DongiaBHYT is NULL and c.LoaiDichVu Not in('D01','D02','D06','D05')) then 0.00 when (d.MaDichvu is NULL and c.LoaiDichVu in('D01','D02','D06','D05')) then c.DonGia else  d.DongiaBHYT end ,DoiTuongBN = 1,LanChuyenDT = {0}", lanchuyen1); };
                                        if (doituong1 == "3")
                                        {
                                            Str += String.Format(" CASE when (d.Dongia is NULL and c.LoaiDichVu Not in('D01','D02','D06','D05')) then 0.00   when (d.MaDichvu is NULL and c.LoaiDichVu in('D01','D02','D06','D05')) then c.DonGia else  d.Dongia end, DoiTuongBN = 3,LanChuyenDT = {0}", lanchuyen1);
                                        };
                                        Str += String.Format(" from NAMDINH_QLBN.dbo.BENHNHAN_CHITIET a inner join NAMDINH_QLBN.dbo.BENHNHAN_PHIEUDIEUTRI b on a.MaVaoVien = b.MaVaoVien inner join NAMDINH_QLBN.dbo.PHIEUDIEUTRI_CHITIET c on c.SoPhieu = b.SoPhieu left join NAMDINH_QLBN.dbo.DMLENCHIPHI_BYKHOID d on d.MaDichvu = c.MaDichVu where a.MaVaoVien = '{0}' and b.NgayChiDinh >= '{1:dd/MM/yyyy HH:mm}'", maVaoVien, ngaychuyen1, lanchuyen1);
                                        selectCommand.CommandText = Str;
                                        selectCommand.ExecuteNonQuery();

                                        // chuyển chi phí phòng mổ
                                        Str = "";
                                        Str += String.Format("set dateformat dmy UPDATE BENHNHAN_PT_CHIPHI set DonGia = ");
                                        if (doituong1 == "1")
                                        { Str += String.Format("  CASE when (d.DongiaBHYT is NULL and a.LoaiChiPhi Not in('D01','D02','D06','D05'))  then 0.00  when (d.MaDichvu is NULL and a.LoaiChiPhi in('D01','D02','D06','D05')) then a.DonGia else  d.DongiaBHYT end ,MaDTBN = 1,LanChuyenDT = {0}", lanchuyen1); };
                                        if (doituong1 == "3")
                                        {
                                            Str += String.Format(" CASE when (d.Dongia is NULL and a.LoaiChiPhi Not in('D01','D02','D06','D05'))  then 0.00 when (d.MaDichvu is NULL and a.LoaiChiPhi in('D01','D02','D06','D05')) then a.DonGia else  d.Dongia end, MaDTBN = 3,LanChuyenDT = {0}", lanchuyen1);
                                        };
                                        Str += String.Format(" from NAMDINH_QLBN.dbo.BENHNHAN_PT_CHIPHI a inner join NAMDINH_QLBN.dbo.BENHNHAN_PHIEUDIEUTRI b on a.MaVaoVien = b.MaVaoVien and a.SoPhieuCD = b.SoPhieu  left join NAMDINH_QLBN.dbo.DMLENCHIPHI_BYKHOID d on d.MaDichvu = a.MaDichVu where a.MaVaoVien = '{0}' and a.TinhPhi = 1 and b.NgayChiDinh >= '{1:dd/MM/yyyy HH:mm}'", maVaoVien, ngaychuyen1, lanchuyen1);
                                        selectCommand.CommandText = Str;
                                        selectCommand.ExecuteNonQuery();
                                    }
                                    Str = "";
                                    Str = String.Format("set dateformat dmy update NAMDINH_QLBN.dbo.PHIEUDIEUTRI_CHITIET set DonGia = case when a.NgayChiDinh < '10/11/2021' then 734000 else 685200 end "
                                                         + " from NAMDINH_QLBN.dbo.BENHNHAN_PHIEUDIEUTRI a inner "
                                                         + " join NAMDINH_QLBN.dbo.PHIEUDIEUTRI_CHITIET b on a.SoPhieu = b.SoPhieu "
                                                        + " where Mavaovien = '{0}' and MaDichVu = 'C52200'", maVaoVien);
                                    selectCommand.CommandText = Str;
                                    selectCommand.ExecuteNonQuery();
                                }
                            else
                                {
                                    if (i < 2)
                                    {
                                        doituong1 = fgDoiTuong[i, "DoiTuong"].ToString();
                                        ngaychuyen1 = DateTime.Parse(fgDoiTuong[i, "NgayChuyen"].ToString());
                                        lanchuyen1 = fgDoiTuong[i, "LanChuyenDT"].ToString();
                                        //chuyển chi phí nội trú PHIEUDIEUTRI_CHITIET
                                        Str = "";
                                        Str = String.Format("set dateformat dmy UPDATE PHIEUDIEUTRI_CHITIET set DonGia = ");
                                        if (doituong1 == "1")
                                        { Str += String.Format(" case when isnull(c.isPhieudieutri_chitiet_covid,0) = 1 then d.Dongia else d.DongiaBHYT  end ,DoiTuongBN = 1,LanChuyenDT = {0}", lanchuyen1); };
                                        if (doituong1 == "3")
                                        {
                                            Str += String.Format(" case when isnull(c.isPhieudieutri_chitiet_covid,0) = 1 then d.Dongia else d.Dongia end , DoiTuongBN = 3,LanChuyenDT = {0}", lanchuyen1);
                                        };
                                        Str += String.Format(" from NAMDINH_QLBN.dbo.BENHNHAN_CHITIET a inner join NAMDINH_QLBN.dbo.BENHNHAN_PHIEUDIEUTRI b on a.MaVaoVien = b.MaVaoVien inner join NAMDINH_QLBN.dbo.PHIEUDIEUTRI_CHITIET c on c.SoPhieu = b.SoPhieu  inner join NAMDINH_SYSDB.dbo.DMDICHVU d on d.MaDichvu = c.MaDichVu where a.MaVaoVien = '{0}'", maVaoVien, ngaychuyen1, lanchuyen1);
                                        selectCommand.CommandText = Str;
                                        selectCommand.ExecuteNonQuery();

                                        // chuyển chi phí phòng mổ
                                        Str = "";
                                        Str += String.Format("set dateformat dmy UPDATE BENHNHAN_PT_CHIPHI set DonGia = ");
                                        if (doituong1 == "1")
                                        { Str += String.Format(" case when isnull(a.IsChiphiPT_Covid,0) = 1 then d.Dongia else d.DongiaBHYT  end ,MaDTBN = 1,LanChuyenDT = {0}", lanchuyen1); };
                                        if (doituong1 == "3")
                                        {
                                            Str += String.Format(" case when isnull(a.IsChiphiPT_Covid,0) = 1 then d.Dongia else d.Dongia end , MaDTBN = 3,LanChuyenDT = {0}", lanchuyen1);
                                        };
                                        Str += String.Format(" from NAMDINH_QLBN.dbo.BENHNHAN_PT_CHIPHI a inner join NAMDINH_QLBN.dbo.BENHNHAN_PHIEUDIEUTRI b on a.MaVaoVien = b.MaVaoVien and a.SoPhieuCD = b.SoPhieu   inner join NAMDINH_SYSDB.dbo.DMDICHVU d on d.MaDichvu = a.MaDichVu where a.MaVaoVien = '{0}' and a.TinhPhi = 1", maVaoVien, ngaychuyen1, lanchuyen1);
                                        selectCommand.CommandText = Str;
                                        selectCommand.ExecuteNonQuery();

                                        // chuyển chi phí phòng khám

                                        Str = "";
                                        Str += String.Format("set dateformat dmy UPDATE NAMDINH_KHAMBENH.dbo.tblCHIPHI_DICHVU set DonGia = ");
                                        if (doituong1 == "1")
                                        { Str += String.Format(" case when isnull(a.ischiphiphongkham_covid,0) = 1 then d.Dongia else d.DongiaBHYT  end  "); };
                                        if (doituong1 == "3")
                                        {
                                            Str += String.Format(" case when isnull(a.ischiphiphongkham_covid,0) = 1 then d.Dongia else d.Dongia end ");
                                        };
                                        Str += String.Format(" from NAMDINH_KHAMBENH.dbo.tblCHIPHI_DICHVU a inner join namdinh_qlbn.dbo.BENHNHAN_CHITIET b on a.makhambenh = b.makhambenh   inner join NAMDINH_SYSDB.dbo.DMDICHVU d on d.MaDichvu = a.MaChiPhi where b.MaVaoVien = '{0}' and a.TinhPhi = 1 and d.madichvu != 'C52197' ", maVaoVien, ngaychuyen1, lanchuyen1);
                                        selectCommand.CommandText = Str;
                                        selectCommand.ExecuteNonQuery();

                                        // chuyen tuyen phong kham
                                        Str = "";
                                        if (fgDoiTuong[i, "CapCuu"].ToString() == "1")
                                        {
                                            Str += String.Format("set dateformat dmy update NAMDINH_KHAMBENH.DBO.tblKHAMBENH SET Tuyen = '2' "
                                               + "FROM NAMDINH_KHAMBENH.DBO.tblKHAMBENH A INNER Join  BENHNHAN_CHITIET b on a.MaKhambenh = b.MaKhamBenh  where  b.MaVaoVien ='{0}' "
                                               , maVaoVien, fgDoiTuong[i, "Tuyen"].ToString());
                                        }
                                        else
                                        {
                                            Str += String.Format("set dateformat dmy update NAMDINH_KHAMBENH.DBO.tblKHAMBENH SET Tuyen = '{1}' "
                                                + "FROM NAMDINH_KHAMBENH.DBO.tblKHAMBENH A INNER Join  BENHNHAN_CHITIET b on a.MaKhambenh = b.MaKhamBenh  where  b.MaVaoVien ='{0}' "
                                                , maVaoVien, fgDoiTuong[i, "Tuyen"].ToString());
                                        }
                                        selectCommand.CommandText = Str;
                                        selectCommand.ExecuteNonQuery();
                                    }
                                    else
                                    {
                                        doituong1 = fgDoiTuong[i, "DoiTuong"].ToString();
                                        ngaychuyen1 = DateTime.Parse(fgDoiTuong[i, "NgayChuyen"].ToString());
                                        lanchuyen1 = fgDoiTuong[i, "LanChuyenDT"].ToString();

                                        //chuyển chi phí nội trú PHIEUDIEUTRI_CHITIET
                                        Str = "";
                                        Str = String.Format("set dateformat dmy UPDATE PHIEUDIEUTRI_CHITIET set DonGia = ");
                                        if (doituong1 == "1")
                                        { Str += String.Format(" case when isnull(c.isPhieudieutri_chitiet_covid,0) = 1 then d.Dongia else d.DongiaBHYT  end ,DoiTuongBN = 1,LanChuyenDT = {0}", lanchuyen1); };
                                        if (doituong1 == "3")
                                        {
                                            Str += String.Format(" case when isnull(c.isPhieudieutri_chitiet_covid,0) = 1 then d.Dongia else d.Dongia end, DoiTuongBN = 3,LanChuyenDT = {0}", lanchuyen1);
                                        };
                                        Str += String.Format(" from NAMDINH_QLBN.dbo.BENHNHAN_CHITIET a inner join NAMDINH_QLBN.dbo.BENHNHAN_PHIEUDIEUTRI b on a.MaVaoVien = b.MaVaoVien inner join NAMDINH_QLBN.dbo.PHIEUDIEUTRI_CHITIET c on c.SoPhieu = b.SoPhieu  inner join NAMDINH_SYSDB.dbo.DMDICHVU d on d.MaDichvu = c.MaDichVu where a.MaVaoVien = '{0}' and b.NgayChiDinh >= '{1:dd/MM/yyyy HH:mm}'", maVaoVien, ngaychuyen1, lanchuyen1);
                                        selectCommand.CommandText = Str;
                                        selectCommand.ExecuteNonQuery();

                                        // chuyển chi phí phòng mổ
                                        Str = "";
                                        Str += String.Format("set dateformat dmy UPDATE BENHNHAN_PT_CHIPHI set DonGia = ");
                                        if (doituong1 == "1")
                                        { Str += String.Format("  case when isnull(a.IsChiphiPT_Covid,0) = 1 then d.Dongia else d.DongiaBHYT  end ,MaDTBN = 1,LanChuyenDT = {0}", lanchuyen1); };
                                        if (doituong1 == "3")
                                        {
                                            Str += String.Format(" case when isnull(a.IsChiphiPT_Covid,0) = 1 then d.Dongia else d.Dongia end, MaDTBN = 3,LanChuyenDT = {0}", lanchuyen1);
                                        };
                                        Str += String.Format(" from NAMDINH_QLBN.dbo.BENHNHAN_PT_CHIPHI a inner join NAMDINH_QLBN.dbo.BENHNHAN_PHIEUDIEUTRI b on a.MaVaoVien = b.MaVaoVien and a.SoPhieuCD = b.SoPhieu   inner join NAMDINH_SYSDB.dbo.DMDICHVU d on d.MaDichvu = a.MaDichVu where a.MaVaoVien = '{0}' and a.TinhPhi = 1 and b.NgayChiDinh >= '{1:dd/MM/yyyy HH:mm}'", maVaoVien, ngaychuyen1, lanchuyen1);
                                        selectCommand.CommandText = Str;
                                        selectCommand.ExecuteNonQuery();
                                    }
                                    Str = "";
                                    Str = String.Format("set dateformat dmy update NAMDINH_QLBN.dbo.PHIEUDIEUTRI_CHITIET set DonGia = case when a.NgayChiDinh < '10/11/2021' then 734000 else 685200 end "
                                                         + " from NAMDINH_QLBN.dbo.BENHNHAN_PHIEUDIEUTRI a inner "
                                                         + " join NAMDINH_QLBN.dbo.PHIEUDIEUTRI_CHITIET b on a.SoPhieu = b.SoPhieu "
                                                        + " where Mavaovien = '{0}' and MaDichVu = 'C52200'", maVaoVien);
                                    selectCommand.CommandText = Str;
                                    selectCommand.ExecuteNonQuery();
                                }
                            }
                        }
                    /*-----------------------------------------------------------Hết---------------------------*/
                    DateTime data = (DateTime)this.fgDanhSach.GetData(this.fgDanhSach.Row, "NgayVaoVien");
                    if (this.fgDanhSach.GetDataDisplay(this.fgDanhSach.Row, "DaRaVien") == "0")
                    {
                        ngayLV = Global.GetNgayLV();
                    }
                    else
                    {
                        ngayLV = (DateTime)this.fgDanhSach.GetData(this.fgDanhSach.Row, "NgayRaVien");
                    }
                    int lanChuyenKhoaHT = Global.GetLanChuyenKhoaHT_BC(maVaoVien, Global.GetCode(cmbKhoa));
                    DateTime time3 = ngayLV;
                    int num2 = lanChuyenKhoaHT;
                    selectCommand.CommandText = string.Concat(new object[] { "Select * from BENHNHAN_KHOA where MaVaoVien = '", maVaoVien, "' and LanChuyenKhoa =", num2 });
                    SqlDataReader reader = selectCommand.ExecuteReader();
                    if (reader.Read())
                    {
                        time3 = (DateTime)reader["NgayChuyen"];
                    }
                    reader.Close();
                    if (time3.Hour == 0)
                    {
                        time3 = time3.AddHours(16.0);
                    }
                    selectCommand.CommandText = string.Format("SELECT LANINTT FROM BENHNHAN_PHIEUDIEUTRI A  INNER JOIN PHIEUDIEUTRI_CHITIET B ON A.SOPHIEU = B.SOPHIEU WHERE A.MAVAOVIEN ='{0}' AND B.DATHANHTOAN = 1 GROUP BY LANINTT", this.fgDanhSach.GetDataDisplay(this.fgDanhSach.Row, 1));
                    selectCommand.CommandTimeout = 0;
                    reader = selectCommand.ExecuteReader();
                    this.cmbLanIn.Tag = "0";
                    this.cmbLanIn.ClearItems();
                    this.cmbLanIn.AddItem("0; ----- Chưa thanh to\x00e1n -------");
                    while (reader.Read())
                    {
                        this.cmbLanIn.AddItem(string.Format("{0};Thanh to\x00e1n lần: {1}", reader["lanintt"], reader["lanintt"]));
                    }
                    reader.Close();
                    // Kiểm tra chú nào chưa thực hiện thì báo
                    selectCommand.CommandText = string.Format("select tendichvu from PHIEUDIEUTRI_CHITIET CT inner join BENHNHAN_PHIEUDIEUTRI PDT on CT.Sophieu = pdt.Sophieu  inner join DMDICHVU DV on CT.Madichvu = DV.Madichvu "
                     + " where PDT.MAVAOVIEN  = '{0}'  and CT.dathuchien = 0 and CT.Loaidichvu >'B99'  and CT.Loaidichvu <'D'", this.fgDanhSach.GetDataDisplay(this.fgDanhSach.Row, 1));
                    selectCommand.CommandTimeout = 0;
                    reader = selectCommand.ExecuteReader();
                    string ChuaThucHien = "";
                    while (reader.Read())
                    {
                        ChuaThucHien = ChuaThucHien + Environment.NewLine + "     - " + reader["tendichvu"];
                    }
                    reader.Close();
                    if (ChuaThucHien != "")
                    {
                        //ChuaThucHien = ChuaThucHien.Substring(0, ChuaThucHien.Length - 2);
                        MessageBox.Show("Dịch vụ: " + ChuaThucHien + Environment.NewLine + "chưa thực hiện, đề nghị bạn kiểm tra lại.", "Cảnh báo!");
                    }

                    if (fgDanhSach[fgDanhSach.Row, "Is_Covid"].ToString() != "1")
                    {
                        SqlCommand command = new SqlCommand();
                        command.Connection = Global.ConnectSQL;
                        command.CommandText = string.Format("DECLARE @LanIn Int SET @LanIn = 0 SELECT @LanIn = ISNULL(PHIEUDIEUTRI_CHITIET.LanInTT,0) FROM BENHNHAN_PHIEUDIEUTRI  INNER JOIN PHIEUDIEUTRI_CHITIET ON PHIEUDIEUTRI_CHITIET.SOPHIEU = BENHNHAN_PHIEUDIEUTRI.SOPHIEU  WHERE BENHNHAN_PHIEUDIEUTRI.MAVAOVIEN ='{0}' AND PHIEUDIEUTRI_CHITIET.DATHANHTOAN = 1 SET @LANIN = @LANIN +1 UPDATE PHIEUDIEUTRI_CHITIET SET LANINTT = @LANIN WHERE SOPHIEU IN( SELECT SOPHIEU FROM BENHNHAN_PHIEUDIEUTRI WHERE MAVAOVIEN ='{0}' AND PHIEUDIEUTRI_CHITIET.DATHANHTOAN = 0)", this.fgDanhSach[this.fgDanhSach.Row, 1].ToString());
                        command.ExecuteNonQuery();
                        DataDynamics.ActiveReports.DataSources.SqlDBDataSource _ds = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
                        _ds.ConnectionString = GlobalModuls.Global.glbConnectionString;
                        _ds.SQL = string.Format(" select A.MaVaoVien, a.TenDichvu, a.MaDichVu, a.SoLuong, a.DVT,"
                                + " case when a.DoiTuongBN = 1 and(a.Tuyen = 0 or a.tuyen = 2 or a.tuyen = 3) and ThoiDiemMienChiTraTrongNam is null then ct_MuHuong when a.DoiTuongBN = 1 and a.Tuyen = 1 then ct_MuHuong * 0.6 when MienChiTraTrongNam = 1 and Convert(date, ThoiDiemMienChiTraTrongNam) < Convert(date, getdate())  then 100  else 100 end as ct_MuHuong,"
                                + " a.ct_TyLeBHYT, a.ct_DonGiaBHYT, a.ct_tinhphi, a.TyLe, a.ct_dongia, a.ct_ThanhTienBV, a.ct_ThanhTienBHYT,"
                                + " CONVERT(decimal(18, 2), CONVERT(decimal(18, 2), (case when a.DoiTuongBN = 1 and(a.Tuyen = 0 or a.tuyen = 2 or a.tuyen = 3) and ThoiDiemMienChiTraTrongNam is null then ct_MuHuong when a.DoiTuongBN = 1 and a.Tuyen = 1 then ct_MuHuong * 0.6 when MienChiTraTrongNam = 1 and Convert(date, ThoiDiemMienChiTraTrongNam) < Convert(date, getdate())  then 100  else 100 end / 100)) * a.ct_BHYTChitra) as ct_BHYTChitra,"
                                + " CONVERT(decimal(18, 2), (CONVERT(decimal(18, 2), (100 - (case when a.DoiTuongBN = 1 and(a.Tuyen = 0 or a.tuyen = 2 or a.tuyen = 3) and ThoiDiemMienChiTraTrongNam is null then ct_MuHuong when a.DoiTuongBN = 1 and a.Tuyen = 1 then ct_MuHuong * 0.6 when MienChiTraTrongNam = 1 and Convert(date, ThoiDiemMienChiTraTrongNam) < Convert(date, getdate())  then 100  else 100 end))) / 100) *a.ct_NBChitra) as ct_NBChitra, "
                                + " a.ct_NBTutra,a.MaLoaiDichVu_BHYT,a.TenLoaiDichVu_BHYT,a.ThuTuIn_DichVu,a.DoiTuongBN,a.TenLoaiDichvu,a.LoaiDichVu,a.TenKhoa,a.MaKhoa ,c.MaKhoaBYT ,c.TenKhoa as TenKhoaRaVien,B.MAICD_BC ,B.MAICD_BP_1,ct.ChuyenVien_ChuyenDenBV as NoiChuyenDi,kb.NoiGioiThieu as NoiKhamBenh, case when ct.NoiRaVien in (4,5) then 2  when ct.KetQuaDT in(4,5,6,7) then 2 else 1 end as TinhTrangRaVien,kb.TgDu5Nam,kb.MienChiTraTrongNam,A.Tuyen,A.LanChuyenDT,A.TheBHYT,A.GtriTu,A.GtriDen,kb.ThoiDiemMienChiTraTrongNam"
                                + " from (select MaVaoVien, TenDichvu, MaDichVu, SUm(SoLuong) as SoLuong, DVT, ct_MuHuong, ct_TyLeBHYT, ct_DonGiaBHYT, ct_tinhphi, TyLe, ct_dongia,"
                                + " sum(ct_ThanhTienBV) as ct_ThanhTienBV, sum(ct_ThanhTienBHYT) as ct_ThanhTienBHYT, Sum(ct_BHYTChitra) as ct_BHYTChitra, Sum(ct_NBChitra) as ct_NBChitra, sum(ct_ThanhTienBV) - sum(ct_ThanhTienBHYT) as ct_NBTutra,"
                                + " MaLoaiDichVu_BHYT, TenLoaiDichVu_BHYT, ThuTuIn_DichVu, DoiTuongBN, TenLoaiDichvu, LoaiDichVu, TenKhoa, MaKhoa, Tuyen, LanChuyenDT, TheBHYT, GtriTu, GtriDen from("
                                + " SELECT  MaVaoVien, SoPhieuCD, TenDichvu, MaDichVu, SoLuong, DVT, ct_MuHuong, ct_TyLeBHYT, isnull(ct_DonGiaBHYT, 0.00) as ct_DonGiaBHYT, ISNULL(ct_dongia, 0.00) AS ct_dongia,"
                                + " ISNULL(CONVERT(decimal(18, 2), SoLuong * ct_dongia * ct_tinhphi * (CONVERT(decimal(18, 2), TyLe) / 100)), 0.00) AS ct_ThanhTienBV,"
                                + " CONVERT(decimal(18, 2), ((SoLuong * ct_DonGiaBHYT) * (CONVERT(decimal(18, 2), ct_TyLeBHYT) / 100)) * (CONVERT(decimal(18, 2), TyLe) / 100) * ct_tinhphi)  AS ct_ThanhTienBHYT,"
                                + " CONVERT(decimal(18, 2), (((SoLuong * ct_DonGiaBHYT) * (CONVERT(decimal(18, 2), ct_TyLeBHYT) / 100)) * (CONVERT(decimal(18, 2), TyLe) / 100)) * ct_tinhphi) AS ct_BHYTChitra,"
                                + " CONVERT(decimal(18, 2), (((SoLuong * ct_DonGiaBHYT) * (CONVERT(decimal(18, 2), ct_TyLeBHYT) / 100)) * (CONVERT(decimal(18, 2), TyLe) / 100)) * ct_tinhphi) AS ct_NBChitra,"
                                + " ct_tienchenh as ct_NBTutra,"
                                + " ct_tinhphi, TyLe, MaLoaiDichVu_BHYT, TenLoaiDichVu_BHYT, ThuTuIn_DichVu, DoiTuongBN, TenLoaiDichvu, LoaiDichVu, TenKhoa, Makhoa, Tuyen, LanChuyenDT, TheBHYT, GtriTu, GtriDen"
                                + " From("
                                + " select pdt.MaVaoVien, pdt_ct.SoPhieu as SoPhieuCD, pdt_ct.MaDichVu, Inphieu.TenDichvu, pdt_ct.SoLuong, pdt_ct.tyle, CASE WHEN b.DoiTuong = 1 THEN a.PhantramDuocHuong ELSE 100 END AS ct_MuHuong,"
                                + " ISNULL(pdt_ct.TyLeBHYT, Inphieu.TyLeBHYT) AS ct_TyLeBHYT,"
                                + " CASE WHEN b.DoiTuong = 1 THEN pdt_ct.DonGia WHEN b.DoiTuong = 3 THEN 0.00 END AS ct_DonGiaBHYT, Case when b.DoiTuong = 1 and Inphieu.is_chenh = 1 then Inphieu.DonGiaChenh + pdt_ct.DonGia else pdt_ct.DonGia  end AS ct_dongia,"
                                + " CASE WHEN is_chenh = 1   THEN CONVERT(decimal(18, 2), (SoLuong * ((case when pdt_ct.DoiTuongBN = 1 then Inphieu.DonGiaChenh else pdt_ct.DonGia end)))) end AS ct_tienchenh, "
                                + " case when pdt_ct.Tinhphi = 0 then 1 else 0 end AS ct_tinhphi,Inphieu.DVT,Inphieu.MaLoaiDichVu_BHYT,Inphieu.TenLoaiDichVu_BHYT,Inphieu.ThuTuIn_DichVu,pdt_ct.DoiTuongBN,loaidv.TenLoaiDichvu,pdt_ct.LoaiDichVu,Khoaphong.TenKhoa,Khoaphong.MAKHOA,b.Tuyen,B.LanChuyenDT,b.maDoiTuongBHXH + b.SoThe as TheBHYT,B.GtriTu,B.GtriDen"
                                  + " FROM  dbo.BENHNHAN_DOITUONG AS b INNER JOIN"
                                  + " BENHNHAN_PHIEUDIEUTRI pdt on b.mavaovien = pdt.MaVaoVien"
                                + " inner join dbo.PHIEUDIEUTRI_CHITIET AS pdt_ct ON b.DoiTuong = pdt_ct.DoiTuongBN and pdt.SoPhieu = pdt_ct.SoPhieu and pdt_ct.LanChuyenDT = b.LanChuyenDT"
                                + " inner join NAMDINH_QLBN.dbo.INPHIEUTHANHTOAN Inphieu on Inphieu.MaDichvu = pdt_ct.MaDichvu"
                                + " inner join NAMDINH_SYSDB.dbo.DMLOAIDICHVU loaidv on loaidv.MaLoaiDichvu = pdt_ct.LoaiDichVu"
                                + " inner join NAMDINH_SYSDB.dbo.DMKHOAPHONG Khoaphong on Khoaphong.MAKHOA = pdt.MaKhoa"
                                + " LEFT  JOIN NAMDINH_VIENPHI.dbo.DMQUYENLOI AS a ON a.MaQuyenLoi = LEFT(b.SoThe, 1)"
                                + " where b.MaVaoVien = N'{0}'  ) X)Y"
                                + " Group by MaVaoVien, TenDichvu, MaDichVu, DVT, ct_MuHuong, ct_TyLeBHYT, ct_DonGiaBHYT, ct_tinhphi, TyLe, ct_dongia, MaLoaiDichVu_BHYT, TenLoaiDichVu_BHYT, ThuTuIn_DichVu, DoiTuongBN, TenLoaiDichvu, LoaiDichVu, TenKhoa, MaKhoa, Tuyen, LanChuyenDT, TheBHYT, GtriTu, GtriDen"
                                + " Union all"
                                + " select MaVaoVien, Tendichvu, MaDichVu, SoLuong, DVT, ct_MuHuong, ct_TyLeBHYT, ct_DonGiaBHYT, ct_tinhphi, TyLe, ct_dongia, sum(ct_ThanhTienBV) as ct_ThanhTienBV, sum(ct_ThanhTienBHYT) as ct_ThanhTienBHYT, Sum(ct_BHYTChitra) as ct_BHYTChitra, Sum(ct_NBChitra) as ct_NBChitra, sum(ct_ThanhTienBV) - sum(ct_ThanhTienBHYT) as ct_NBTutra,"
                                + " 'VATTU_MO' as MaLoaiDichVu_BHYT, N'Gói vật tư y tế' as TenLoaiDichVu_BHYT, ThuTuIn_DichVu, DoiTuongBN, TenLoaiDichvu, LoaiDichVu, N'Khoa gây mê hồi sức' as TenKhoa, 'NV1103' as MAKHOA, Tuyen, LanChuyenDT, TheBHYT, GtriTu, GtriDen"
                                + " from(SELECT  MaVaoVien, SoPhieuCD, MaDichVu, SoLuong, DVT, ct_MuHuong, ct_TyLeBHYT, isnull(ct_DonGiaBHYT, 0.00) as ct_DonGiaBHYT, ISNULL(ct_dongia, 0.00) AS ct_dongia,"
                                + " ISNULL(CONVERT(decimal(18, 2), SoLuong * ct_dongia * ct_tinhphi * (CONVERT(decimal(18, 2), TyLe) / 100)), 0.00) AS ct_ThanhTienBV,"
                                + " CONVERT(decimal(18, 2), ((SoLuong * ct_DonGiaBHYT) * (CONVERT(decimal(18, 2), ct_TyLeBHYT) / 100)) * (CONVERT(decimal(18, 2), TyLe) / 100) * ct_tinhphi)  AS ct_ThanhTienBHYT,"
                                + " CONVERT(decimal(18, 2), (((SoLuong * ct_DonGiaBHYT) * (CONVERT(decimal(18, 2), ct_TyLeBHYT) / 100)) * (CONVERT(decimal(18, 2), TyLe) / 100)) * ct_tinhphi) AS ct_BHYTChitra,"
                                + " CONVERT(decimal(18, 2), (((SoLuong * ct_DonGiaBHYT) * (CONVERT(decimal(18, 2), ct_TyLeBHYT) / 100)) * (CONVERT(decimal(18, 2), TyLe) / 100)) * ct_tinhphi) AS ct_NBChitra,"
                                + " ct_tienchenh as ct_NBTutra, ct_tinhphi, TyLe, ThuTuIn_DichVu, DoiTuongBN, TenLoaiDichvu, LoaiDichVu, TenDichvu, Tuyen, LanChuyenDT, TheBHYT, GtriTu, GtriDen"
                                + " From(select pdt_ct.MaVaoVien, pdt_ct.SoPhieuCD, pdt_ct.MaDichVu, pdt_ct.SoLuong, pdt_ct.tyle, a.PhantramDuocHuong AS ct_MuHuong, ISNULL(pdt_ct.TyLeBHYT, KHO.TyLeBHYT) AS ct_TyLeBHYT, CASE WHEN b.DoiTuong = 1 THEN pdt_ct.DonGia  WHEN b.DoiTuong = 3 THEN 0.00  ELSE pdt_ct.DonGia END AS ct_DonGiaBHYT, case when b.DoiTuong = 1 and kho.is_chenh = 1 then pdt_ct.DonGia + kho.DonGiaChenh  else pdt_ct.dongia end as ct_dongia, CASE WHEN is_chenh = 1 THEN CONVERT(decimal(18, 2), SoLuong * (case when b.DoiTuong = 1 then Kho.DonGiaChenh else pdt_ct.DonGia end)) end AS ct_tienchenh, pdt_ct.Tinhphi AS ct_tinhphi, KHO.DVT, 10 as ThuTuIn_DichVu, b.DoiTuong as DoiTuongBN, pdt_ct.LoaiDichVu, (select TenDichvu from INPHIEUTHANHTOAN where madichvu = pdt_ct.MaPT) as TenLoaiDichvu, kho.TenDichvu, b.Tuyen, B.LanChuyenDT, b.maDoiTuongBHXH + b.SoThe as TheBHYT, B.GtriTu, B.GtriDen"
                                + " FROM  dbo.BENHNHAN_DOITUONG AS b INNER JOIN dbo.BENHNHAN_PT_CHIPHI AS pdt_ct ON b.MaVaoVien = pdt_ct.MaVaoVien"
                                + " INNER JOIN dbo.INPHIEUTHANHTOAN AS KHO ON KHO.MaDichvu = pdt_ct.MaDichVu"
                                + " inner join(SELECT sophieu, LanChuyenDT, MaDichVu from NAMDINH_QLBN.DBO.PHIEUDIEUTRI_CHITIET) CT ON CT.SoPhieu = pdt_ct.SoPhieuCD  AND CT.MaDichVu = PDT_CT.MaPT and ct.LanChuyenDT = b.LanChuyenDT"
                                + " inner join NAMDINH_SYSDB.dbo.DMLOAIDICHVU loai on loai.MaLoaiDichvu = KHO.LoaiDichvu LEFT JOIN"
                                + " NAMDINH_VIENPHI.dbo.DMQUYENLOI AS a ON a.MaQuyenLoi = LEFT(b.SoThe, 1)"
                                + " where b.MaVaoVien = N'{0}') X)Y where ct_tinhphi = 1"
                                + " Group by  MaVaoVien,SoPhieuCD,MaDichVu,SoLuong,DVT, ct_MuHuong, ct_TyLeBHYT, ct_DonGiaBHYT,ct_tinhphi, TyLe,ct_dongia,ThuTuIn_DichVu,DoiTuongBN,TenLoaiDichvu ,LoaiDichVu,TenDichvu,Tuyen,LanChuyenDT,TheBHYT,GtriTu,GtriDen"
                                + " Union all"
                                + " select MaVaoVien,TenDichvu, MaDichVu,SUm(SoLuong) as SoLuong, DVT, isnull(ct_MuHuong, 100) as ct_MuHuong, ct_TyLeBHYT, ct_DonGiaBHYT, ct_tinhphi, TyLe, ct_dongia, sum(ct_ThanhTienBV) as ct_ThanhTienBV,sum(ct_ThanhTienBHYT) as ct_ThanhTienBHYT,Sum(ct_BHYTChitra) as ct_BHYTChitra,Sum(ct_NBChitra) as ct_NBChitra,sum(ct_ThanhTienBV) - sum(ct_ThanhTienBHYT) as ct_NBTutra, MaLoaiDichVu_BHYT,TenLoaiDichVu_BHYT,ThuTuIn_DichVu,DoiTuongBN,TenLoaiDichvu,LoaiDichVu,TenKhoa,MaKhoa,Tuyen,LanChuyenDT,TheBHYT,GtriTu,GtriDen"
                                + " from(SELECT MaVaoVien, SoPhieuCD, TenDichvu, MaDichVu, SoLuong, DVT, ct_MuHuong, ct_TyLeBHYT, isnull(ct_DonGiaBHYT, 0.00) as ct_DonGiaBHYT, ISNULL(ct_dongia, 0.00) AS ct_dongia, ISNULL(CONVERT(decimal(18, 2), SoLuong * ct_dongia * ct_tinhphi * (CONVERT(decimal(18, 2), TyLe) / 100)), 0.00) AS ct_ThanhTienBV, CONVERT(decimal(18, 2), ((SoLuong * ct_DonGiaBHYT) * (CONVERT(decimal(18, 2), ct_TyLeBHYT) / 100)) * (CONVERT(decimal(18, 2), TyLe) / 100) * ct_tinhphi)  AS ct_ThanhTienBHYT, CONVERT(decimal(18, 2), (((SoLuong * ct_DonGiaBHYT) * (CONVERT(decimal(18, 2), ct_TyLeBHYT) / 100)) * (CONVERT(decimal(18, 2), TyLe) / 100)) * ct_tinhphi) AS ct_BHYTChitra, CONVERT(decimal(18, 2), (((SoLuong * ct_DonGiaBHYT) * (CONVERT(decimal(18, 2), ct_TyLeBHYT) / 100)) * (CONVERT(decimal(18, 2), TyLe) / 100)) * ct_tinhphi) AS ct_NBChitra, ct_tienchenh as ct_NBTutra, ct_tinhphi, TyLe,MaLoaiDichVu_BHYT,TenLoaiDichVu_BHYT,ThuTuIn_DichVu,DoiTuongBN,TenLoaiDichvu,LoaiDichVu,TenKhoa,Makhoa,Tuyen,LanChuyenDT,TheBHYT,GtriTu,GtriDen"
                                  + " From(select b.MaVaoVien, pdt_ct.MaPhieuCD as SoPhieuCD, pdt_ct.MaChiPhi as MaDichVu, Inphieu.TenDichvu, pdt_ct.SoLuong, pdt_ct.tyle,"
                                  + " CASE WHEN kb.DoiTuong = 1 THEN a.PhantramDuocHuong ELSE 100 END AS ct_MuHuong, ISNULL(pdt_ct.TyLeBH, Inphieu.TyLeBHYT) AS ct_TyLeBHYT,"
                                  + " CASE WHEN kb.DoiTuong = 1 THEN pdt_ct.DonGia WHEN kb.DoiTuong = 3 THEN 0.00 END AS ct_DonGiaBHYT,"
                                  + " Case when kb.DoiTuong = 1 and Inphieu.is_chenh = 1 then Inphieu.DonGiaChenh + pdt_ct.DonGia else pdt_ct.DonGia  end AS ct_dongia,"
                                  + " CASE WHEN is_chenh = 1   THEN CONVERT(decimal(18, 2), (SoLuong * ((case when DT.DoiTuong = 1 then Inphieu.DonGiaChenh else pdt_ct.DonGia end)))) end AS ct_tienchenh,   "
                                + " pdt_ct.Tinhphi as ct_tinhphi,Inphieu.DVT,Inphieu.MaLoaiDichVu_BHYT,Inphieu.TenLoaiDichVu_BHYT,Inphieu.ThuTuIn_DichVu,kb.DoiTuong as DoiTuongBN,loaidv.TenLoaiDichvu,pdt_ct.LoaiChiPhi as LoaiDichVu,Khoaphong.TenKhoa,Khoaphong.MAKHOA,case when convert(date, kb.ThoigianDangky) >= CONVERT(date, '01/01/2021') and kb.Tuyen = 1 then 3 else  kb.Tuyen end as Tuyen, 0 as LanChuyenDT, kb.doituongthe + kb.SoTheBHYT as TheBHYT, kb.HantheBHYT_Tu as GtriTu, kb.HantheBHYT_den as GtriDen"
                              + " FROM  dbo.BENHNHAN_CHITIET AS b INNER JOIN NAMDINH_KHAMBENH.dbo.tblKHAMBENH kb on b.MaKhamBenh = kb.MaKhambenh"
                              + " INNER JOIN ViewDOITUONGHIENTAI DT ON DT.MAVAOVIEN = B.MAVAOVIEN"
                              + " inner join NAMDINH_KHAMBENH.dbo.tblCHIPHI_DICHVU AS pdt_ct ON pdt_ct.MaKhamBenh = kb.MaKhambenh"
                              + " inner join NAMDINH_QLBN.dbo.INPHIEUTHANHTOAN Inphieu on Inphieu.MaDichvu = pdt_ct.MaChiPhi"
                              + " inner join NAMDINH_SYSDB.dbo.DMLOAIDICHVU loaidv on loaidv.MaLoaiDichvu = pdt_ct.LoaiChiPhi"
                              + " inner join NAMDINH_SYSDB.dbo.DMKHOAPHONG Khoaphong on Khoaphong.MAKHOA = pdt_ct.MaKhoaThucHien"
                              + " LEFT JOIN NAMDINH_VIENPHI.dbo.DMQUYENLOI AS a ON a.MaQuyenLoi = LEFT(kb.SoTheBHYT, 1) where b.MaVaoVien = N'{0}' and pdt_ct.TinhPhi = 1  ) X)Y"
                               + " Group by MaVaoVien, TenDichvu, MaDichVu, DVT, ct_MuHuong, ct_TyLeBHYT, ct_DonGiaBHYT, ct_tinhphi, TyLe, ct_dongia, MaLoaiDichVu_BHYT,"
                               + " TenLoaiDichVu_BHYT, ThuTuIn_DichVu, DoiTuongBN, TenLoaiDichvu, LoaiDichVu, TenKhoa, MaKhoa, Tuyen, LanChuyenDT, TheBHYT, GtriTu, GtriDen"
                                + " ) A"
                                + " inner join NAMDINH_QLBN.dbo.ViewKHOAHIENTAI b on b.MaVaoVien = a.MaVaoVien"
                                + " inner join NAMDINH_SYSDB.dbo.DMKHOAPHONG c on c.MaKhoa = b.MaKhoa"
                                + " inner join NAMDINH_QLBN.dbo.BENHNHAN_CHITIET ct on ct.MaVaoVien = a.MaVaoVien"
                                + " inner join NAMDINH_KHAMBENH.dbo.tblKHAMBENH as kb on kb.MaKhambenh = ct.MaKhamBenh where ct. MaVaoVien = '{0}'"
                                + " order by LanChuyenDT, TenKhoa, ThuTuIn_DichVu, LoaiDichVu, maVaoVien", maVaoVien);
                        _ds.CommandTimeout = 0;
                        //_ds.SQL = string.Format("set dateformat dmy IF EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name like 'ttt_bn') DROP TABLE Namdinh_qlbn.dbo.ttt_bn  "
                        //    + " select A.MaVaoVien,a.TenDichvu,a.MaDichVu,a.SoLuong,a.DVT, "
                        //    + " case when a.DoiTuongBN =1 and (a.Tuyen  = 0 or a.tuyen = 2 or a.tuyen = 3) and ThoiDiemMienChiTraTrongNam is null then ct_MuHuong when a.DoiTuongBN = 1 and a.Tuyen = 1 then ct_MuHuong*0.6 when MienChiTraTrongNam =1 and Convert(date,ThoiDiemMienChiTraTrongNam) < Convert(date,getdate())  then 100  else 100 end as ct_MuHuong, "
                        //    + " a.ct_TyLeBHYT,a.ct_DonGiaBHYT,a.ct_tinhphi,a.TyLe,a.ct_dongia,a.ct_ThanhTienBV,a.ct_ThanhTienBHYT, "
                        //    + " CONVERT(decimal(18, 2),CONVERT(decimal(18, 2), (case when a.DoiTuongBN =1 and (a.Tuyen  = 0 or a.tuyen = 2 or a.tuyen = 3) and ThoiDiemMienChiTraTrongNam is null then ct_MuHuong when a.DoiTuongBN = 1 and a.Tuyen = 1 then ct_MuHuong*0.6 when MienChiTraTrongNam =1 and Convert(date,ThoiDiemMienChiTraTrongNam) < Convert(date,getdate())  then 100  else 100 end/ 100)) * a.ct_BHYTChitra) as ct_BHYTChitra, "
                        //    + " CONVERT(decimal(18, 2),(CONVERT(decimal(18, 2), (100 - (case when a.DoiTuongBN =1 and (a.Tuyen  = 0 or a.tuyen = 2 or a.tuyen = 3) and ThoiDiemMienChiTraTrongNam is null then ct_MuHuong when a.DoiTuongBN = 1 and a.Tuyen = 1 then ct_MuHuong*0.6 when MienChiTraTrongNam =1 and Convert(date,ThoiDiemMienChiTraTrongNam) < Convert(date,getdate())  then 100  else 100 end))) / 100) * a.ct_NBChitra) as ct_NBChitra, "
                        //    + " a.ct_NBTutra,a.MaLoaiDichVu_BHYT,a.TenLoaiDichVu_BHYT,a.ThuTuIn_DichVu,a.DoiTuongBN,a.TenLoaiDichvu,a.LoaiDichVu,a.TenKhoa,a.MaKhoa ,c.MaKhoaBYT ,c.TenKhoa as TenKhoaRaVien,B.MAICD_BC ,B.MAICD_BP_1,ct.ChuyenVien_ChuyenDenBV as NoiChuyenDi,kb.NoiGioiThieu as NoiKhamBenh, case when ct.NoiRaVien in (4,5) then 2  when ct.KetQuaDT in(4,5,6,7) then 2 else 1 end as TinhTrangRaVien,kb.TgDu5Nam,kb.MienChiTraTrongNam,A.Tuyen,A.LanChuyenDT,A.TheBHYT,A.GtriTu,A.GtriDen,kb.ThoiDiemMienChiTraTrongNam  into ttt_bn "
                        //    + " from (select MaVaoVien,TenDichvu, MaDichVu,SUm(SoLuong) as SoLuong, DVT, ct_MuHuong, ct_TyLeBHYT, ct_DonGiaBHYT, ct_tinhphi, TyLe, ct_dongia,"
                        //    + " sum(ct_ThanhTienBV) as ct_ThanhTienBV,sum(ct_ThanhTienBHYT) as ct_ThanhTienBHYT,Sum(ct_BHYTChitra) as ct_BHYTChitra,Sum(ct_NBChitra) as ct_NBChitra,sum(ct_ThanhTienBV) - sum(ct_ThanhTienBHYT)  as ct_NBTutra,"
                        //        + " MaLoaiDichVu_BHYT,TenLoaiDichVu_BHYT,ThuTuIn_DichVu,DoiTuongBN,TenLoaiDichvu,LoaiDichVu,TenKhoa,MaKhoa,Tuyen,LanChuyenDT,TheBHYT,GtriTu,GtriDen from("
                        //        + " SELECT  MaVaoVien, SoPhieuCD, TenDichvu,MaDichVu, SoLuong, DVT, ct_MuHuong, ct_TyLeBHYT, isnull(ct_DonGiaBHYT, 0.00) as ct_DonGiaBHYT, ISNULL(ct_dongia, 0.00) AS ct_dongia,"
                        //        + " ISNULL(CONVERT(decimal(18, 2), SoLuong * ct_dongia * ct_tinhphi*(CONVERT(decimal(18, 2), TyLe) / 100)), 0.00) AS ct_ThanhTienBV,"
                        //        + " CONVERT(decimal(18, 2), ((SoLuong * ct_DonGiaBHYT) * (CONVERT(decimal(18, 2), ct_TyLeBHYT) / 100)) * (CONVERT(decimal(18, 2), TyLe) / 100) * ct_tinhphi)  AS ct_ThanhTienBHYT,"
                        //        + " CONVERT(decimal(18, 2), (((SoLuong * ct_DonGiaBHYT) * (CONVERT(decimal(18, 2), ct_TyLeBHYT) / 100)) * (CONVERT(decimal(18, 2), TyLe) / 100))* ct_tinhphi) AS ct_BHYTChitra,"
                        //        + " CONVERT(decimal(18, 2), (((SoLuong * ct_DonGiaBHYT) * (CONVERT(decimal(18, 2), ct_TyLeBHYT) / 100)) * (CONVERT(decimal(18, 2), TyLe) / 100)) * ct_tinhphi) AS ct_NBChitra,"
                        //        + " ct_tienchenh as ct_NBTutra,"
                        //        + " ct_tinhphi, TyLe,MaLoaiDichVu_BHYT,TenLoaiDichVu_BHYT,ThuTuIn_DichVu,DoiTuongBN,TenLoaiDichvu,LoaiDichVu,TenKhoa,Makhoa,Tuyen,LanChuyenDT,TheBHYT,GtriTu,GtriDen"
                        //        + " From("
                        //        + " select distinct pdt.MaVaoVien, pdt_ct.SoPhieu as SoPhieuCD, pdt_ct.MaDichVu,Kho.TenDichvu, pdt_ct.SoLuong, pdt_ct.tyle, CASE WHEN b.DoiTuong = 1 THEN a.PhantramDuocHuong ELSE 100 END AS ct_MuHuong, "
                        //        + " ISNULL(pdt_ct.TyLeBHYT,KHO.TyLeBHYT) AS ct_TyLeBHYT, "
                        //        + " CASE WHEN b.DoiTuong = 1 THEN pdt_ct.DonGia WHEN b.DoiTuong = 3 THEN 0.00 END AS ct_DonGiaBHYT, Case when b.DoiTuong = 1 and kho.is_chenh = 1 then kho.DonGiaChenh + pdt_ct.DonGia else pdt_ct.DonGia  end AS ct_dongia,"
                        //        + " CASE WHEN is_chenh = 1   THEN CONVERT(decimal(18, 2), (SoLuong * ((case when pdt_ct.DoiTuongBN = 1 then KHO.DonGiaChenh else pdt_ct.DonGia end)))) end AS ct_tienchenh, "
                        //        + " case when pdt_ct.Tinhphi = 0 then 1 else 0 end AS ct_tinhphi,KHO.DVT,Inphieu.MaLoaiDichVu_BHYT,Inphieu.TenLoaiDichVu_BHYT,Inphieu.ThuTuIn_DichVu,pdt_ct.DoiTuongBN,loaidv.TenLoaiDichvu,pdt_ct.LoaiDichVu,Khoaphong.TenKhoa,Khoaphong.MAKHOA,b.Tuyen,B.LanChuyenDT,b.maDoiTuongBHXH+b.SoThe as TheBHYT,B.GtriTu,B.GtriDen "
                        //        + " FROM  dbo.BENHNHAN_DOITUONG AS b INNER JOIN"
                        //        + " BENHNHAN_PHIEUDIEUTRI pdt on b.mavaovien = pdt.MaVaoVien"
                        //        + " inner join dbo.PHIEUDIEUTRI_CHITIET AS pdt_ct ON b.DoiTuong = pdt_ct.DoiTuongBN and pdt.SoPhieu = pdt_ct.SoPhieu and pdt_ct.LanChuyenDT = b.LanChuyenDT "
                        //        + " inner JOIN  dbo.DM_INPHIEUTHANHTOAN AS KHO ON KHO.MaDichvu = pdt_ct.MaDichVu"
                        //        + " inner join NAMDINH_QLBN.dbo.INPHIEUTHANHTOAN Inphieu on Inphieu.MaDichvu = KHO.MaDichvu"
                        //        + " inner join NAMDINH_SYSDB.dbo.DMLOAIDICHVU loaidv on loaidv.MaLoaiDichvu = pdt_ct.LoaiDichVu"
                        //        + " inner join NAMDINH_SYSDB.dbo.DMKHOAPHONG Khoaphong on Khoaphong.MAKHOA = pdt.MaKhoa"
                        //        + " LEFT OUTER JOIN NAMDINH_VIENPHI.dbo.DMQUYENLOI AS a ON a.MaQuyenLoi = LEFT(b.SoThe, 1)"
                        //        + " where b.MaVaoVien = N'{0}'  ) X)Y"
                        //        + " Group by MaVaoVien,TenDichvu,MaDichVu, DVT, ct_MuHuong, ct_TyLeBHYT, ct_DonGiaBHYT, ct_tinhphi, TyLe, ct_dongia,MaLoaiDichVu_BHYT,TenLoaiDichVu_BHYT,ThuTuIn_DichVu,DoiTuongBN,TenLoaiDichvu,LoaiDichVu,TenKhoa,MaKhoa,Tuyen,LanChuyenDT,TheBHYT,GtriTu,GtriDen "
                        //        + " Union all"
                        //        + " select MaVaoVien,Tendichvu,MaDichVu,SoLuong,DVT, ct_MuHuong, ct_TyLeBHYT, ct_DonGiaBHYT,ct_tinhphi,TyLe,ct_dongia,sum(ct_ThanhTienBV)as ct_ThanhTienBV,sum(ct_ThanhTienBHYT)  as ct_ThanhTienBHYT,Sum(ct_BHYTChitra)  as ct_BHYTChitra,Sum(ct_NBChitra) as ct_NBChitra, sum(ct_ThanhTienBV) -  sum(ct_ThanhTienBHYT) as ct_NBTutra, "
                        //        + " 'VATTU_MO' as MaLoaiDichVu_BHYT,N'Gói vật tư y tế' as TenLoaiDichVu_BHYT,ThuTuIn_DichVu,DoiTuongBN,TenLoaiDichvu ,LoaiDichVu,N'Khoa gây mê hồi sức' as TenKhoa,'NV1103' as MAKHOA,Tuyen,LanChuyenDT,TheBHYT,GtriTu,GtriDen  "
                        //        + " from(SELECT  MaVaoVien, SoPhieuCD, MaDichVu, SoLuong, DVT, ct_MuHuong, ct_TyLeBHYT, isnull(ct_DonGiaBHYT, 0.00) as ct_DonGiaBHYT, ISNULL(ct_dongia, 0.00) AS ct_dongia,"
                        //        + " ISNULL(CONVERT(decimal(18, 2), SoLuong * ct_dongia * ct_tinhphi*(CONVERT(decimal(18, 2), TyLe) / 100)), 0.00) AS ct_ThanhTienBV,"
                        //        + " CONVERT(decimal(18, 2), ((SoLuong * ct_DonGiaBHYT) * (CONVERT(decimal(18, 2), ct_TyLeBHYT) / 100)) * (CONVERT(decimal(18, 2), TyLe) / 100) * ct_tinhphi)  AS ct_ThanhTienBHYT,"
                        //        + " CONVERT(decimal(18, 2), (((SoLuong * ct_DonGiaBHYT) * (CONVERT(decimal(18, 2), ct_TyLeBHYT) / 100)) * (CONVERT(decimal(18, 2), TyLe) / 100))  * ct_tinhphi) AS ct_BHYTChitra,"
                        //        + " CONVERT(decimal(18, 2), (((SoLuong * ct_DonGiaBHYT) * (CONVERT(decimal(18, 2), ct_TyLeBHYT) / 100)) * (CONVERT(decimal(18, 2), TyLe) / 100)) *  ct_tinhphi) AS ct_NBChitra,"
                        //        + " ct_tienchenh as ct_NBTutra, ct_tinhphi, TyLe, ThuTuIn_DichVu, DoiTuongBN, TenLoaiDichvu, LoaiDichVu, TenDichvu,Tuyen,LanChuyenDT,TheBHYT,GtriTu,GtriDen"
                        //        + " From(select distinct pdt_ct.MaVaoVien, pdt_ct.SoPhieuCD, pdt_ct.MaDichVu, pdt_ct.SoLuong, pdt_ct.tyle,a.PhantramDuocHuong AS ct_MuHuong, ISNULL(pdt_ct.TyLeBHYT,KHO.TyLeBHYT) AS ct_TyLeBHYT, CASE WHEN b.DoiTuong = 1 THEN pdt_ct.DonGia  WHEN b.DoiTuong = 3 THEN 0.00  ELSE pdt_ct.DonGia END AS ct_DonGiaBHYT, case when b.DoiTuong = 1 and kho.is_chenh =1 then pdt_ct.DonGia + kho.DonGiaChenh  else pdt_ct.dongia end as ct_dongia, CASE WHEN is_chenh = 1 THEN CONVERT(decimal(18, 2), SoLuong *  (case when b.DoiTuong = 1 then Kho.DonGiaChenh else pdt_ct.DonGia end )) end AS ct_tienchenh, pdt_ct.Tinhphi AS ct_tinhphi,KHO.DVT,10 as ThuTuIn_DichVu,b.DoiTuong as DoiTuongBN,pdt_ct.LoaiDichVu,(select TenDichvu from DM_INPHIEUTHANHTOAN where madichvu = pdt_ct.MaPT) as TenLoaiDichvu,kho.TenDichvu,b.Tuyen,B.LanChuyenDT,b.maDoiTuongBHXH+b.SoThe as TheBHYT,B.GtriTu,B.GtriDen"
                        //        + " FROM  dbo.BENHNHAN_DOITUONG AS b INNER JOIN dbo.BENHNHAN_PT_CHIPHI AS pdt_ct ON b.MaVaoVien = pdt_ct.MaVaoVien INNER JOIN dbo.DM_INPHIEUTHANHTOAN AS KHO ON KHO.MaDichvu = pdt_ct.MaDichVu"
                        //        + " inner join (SELECT sophieu,LanChuyenDT,MaDichVu from NAMDINH_QLBN.DBO.PHIEUDIEUTRI_CHITIET) CT ON CT.SoPhieu = pdt_ct.SoPhieuCD  AND CT.MaDichVu = PDT_CT.MaPT and ct.LanChuyenDT = b.LanChuyenDT"
                        //        + " inner join NAMDINH_SYSDB.dbo.DMLOAIDICHVU loai on loai.MaLoaiDichvu = KHO.LoaiDichvu LEFT OUTER JOIN"
                        //        + " NAMDINH_VIENPHI.dbo.DMQUYENLOI AS a ON a.MaQuyenLoi = LEFT(b.SoThe, 1)"
                        //        + " where b.MaVaoVien = N'{0}') X)Y where ct_tinhphi = 1"
                        //        + " Group by  MaVaoVien,SoPhieuCD,MaDichVu,SoLuong,DVT, ct_MuHuong, ct_TyLeBHYT, ct_DonGiaBHYT,ct_tinhphi, TyLe,ct_dongia,ThuTuIn_DichVu,DoiTuongBN,TenLoaiDichvu ,LoaiDichVu,TenDichvu,Tuyen,LanChuyenDT,TheBHYT,GtriTu,GtriDen"
                        //        + " Union all"
                        //        + " select MaVaoVien,TenDichvu, MaDichVu,SUm(SoLuong) as SoLuong, DVT, isnull(ct_MuHuong,100) as ct_MuHuong, ct_TyLeBHYT, ct_DonGiaBHYT, ct_tinhphi, TyLe, ct_dongia, sum(ct_ThanhTienBV) as ct_ThanhTienBV,sum(ct_ThanhTienBHYT) as ct_ThanhTienBHYT,Sum(ct_BHYTChitra) as ct_BHYTChitra,Sum(ct_NBChitra) as ct_NBChitra,sum(ct_ThanhTienBV) - sum(ct_ThanhTienBHYT)  as ct_NBTutra, MaLoaiDichVu_BHYT,TenLoaiDichVu_BHYT,ThuTuIn_DichVu,DoiTuongBN,TenLoaiDichvu,LoaiDichVu,TenKhoa,MaKhoa,Tuyen,LanChuyenDT,TheBHYT,GtriTu,GtriDen "
                        //        + " from( SELECT  MaVaoVien, SoPhieuCD, TenDichvu,MaDichVu, SoLuong, DVT, ct_MuHuong, ct_TyLeBHYT, isnull(ct_DonGiaBHYT, 0.00) as ct_DonGiaBHYT, ISNULL(ct_dongia, 0.00) AS ct_dongia, ISNULL(CONVERT(decimal(18, 2), SoLuong * ct_dongia * ct_tinhphi*(CONVERT(decimal(18, 2), TyLe) / 100)), 0.00) AS ct_ThanhTienBV, CONVERT(decimal(18, 2), ((SoLuong * ct_DonGiaBHYT) * (CONVERT(decimal(18, 2), ct_TyLeBHYT) / 100)) * (CONVERT(decimal(18, 2), TyLe) / 100) * ct_tinhphi)  AS ct_ThanhTienBHYT, CONVERT(decimal(18, 2), (((SoLuong * ct_DonGiaBHYT) * (CONVERT(decimal(18, 2), ct_TyLeBHYT) / 100)) * (CONVERT(decimal(18, 2), TyLe) / 100))* ct_tinhphi) AS ct_BHYTChitra, CONVERT(decimal(18, 2), (((SoLuong * ct_DonGiaBHYT) * (CONVERT(decimal(18, 2), ct_TyLeBHYT) / 100)) * (CONVERT(decimal(18, 2), TyLe) / 100)) * ct_tinhphi) AS ct_NBChitra, ct_tienchenh as ct_NBTutra, ct_tinhphi, TyLe,MaLoaiDichVu_BHYT,TenLoaiDichVu_BHYT,ThuTuIn_DichVu,DoiTuongBN,TenLoaiDichvu,LoaiDichVu,TenKhoa,Makhoa,Tuyen,LanChuyenDT,TheBHYT,GtriTu,GtriDen"
                        //        + " From( select distinct b.MaVaoVien, pdt_ct.MaPhieuCD as SoPhieuCD, pdt_ct.MaChiPhi as MaDichVu,Kho.TenDichvu, pdt_ct.SoLuong, pdt_ct.tyle,  "
                        //        + " CASE WHEN kb.DoiTuong = 1 THEN a.PhantramDuocHuong ELSE 100 END AS ct_MuHuong, ISNULL(pdt_ct.TyLeBH,KHO.TyLeBHYT) AS ct_TyLeBHYT,  "
                        //        + " CASE WHEN kb.DoiTuong = 1 THEN pdt_ct.DonGia WHEN kb.DoiTuong = 3 THEN 0.00 END AS ct_DonGiaBHYT,  "
                        //        + " Case when kb.DoiTuong = 1 and kho.is_chenh = 1 then kho.DonGiaChenh + pdt_ct.DonGia else pdt_ct.DonGia  end AS ct_dongia,  "
                        //        + " CASE WHEN is_chenh = 1   THEN CONVERT(decimal(18, 2), (SoLuong * ((case when DT.DoiTuong = 1 then KHO.DonGiaChenh else pdt_ct.DonGia end)))) end AS ct_tienchenh,   "
                        //        + " pdt_ct.Tinhphi   as ct_tinhphi,KHO.DVT,Inphieu.MaLoaiDichVu_BHYT,Inphieu.TenLoaiDichVu_BHYT,Inphieu.ThuTuIn_DichVu,kb.DoiTuong as DoiTuongBN,loaidv.TenLoaiDichvu,pdt_ct.LoaiChiPhi as LoaiDichVu,Khoaphong.TenKhoa,Khoaphong.MAKHOA,case when convert(date,kb.ThoigianDangky) >= CONVERT(date,'01/01/2021') and kb.Tuyen =1 then 3 else  kb.Tuyen end   as Tuyen,0 as LanChuyenDT,kb.doituongthe+kb.SoTheBHYT as TheBHYT,kb.HantheBHYT_Tu as GtriTu,kb.HantheBHYT_den as GtriDen "
                        //        + " FROM  dbo.BENHNHAN_CHITIET AS b INNER JOIN NAMDINH_KHAMBENH.dbo.tblKHAMBENH kb on b.MaKhamBenh = kb.MaKhambenh "
                        //        + " INNER JOIN ViewDOITUONGHIENTAI DT ON DT.MAVAOVIEN = B.MAVAOVIEN "
                        //        + " inner join NAMDINH_KHAMBENH.dbo.tblCHIPHI_DICHVU AS pdt_ct ON pdt_ct.MaKhamBenh = kb.MaKhambenh "
                        //        + " inner JOIN  dbo.DM_INPHIEUTHANHTOAN AS KHO ON KHO.MaDichvu = pdt_ct.MaChiPhi  "
                        //        + " inner join NAMDINH_QLBN.dbo.INPHIEUTHANHTOAN Inphieu on Inphieu.MaDichvu = KHO.MaDichvu  "
                        //        + " inner join NAMDINH_SYSDB.dbo.DMLOAIDICHVU loaidv on loaidv.MaLoaiDichvu = pdt_ct.LoaiChiPhi  "
                        //        + " inner join NAMDINH_SYSDB.dbo.DMKHOAPHONG Khoaphong on Khoaphong.MAKHOA = pdt_ct.MaKhoaThucHien  "
                        //        + " LEFT OUTER JOIN NAMDINH_VIENPHI.dbo.DMQUYENLOI AS a ON a.MaQuyenLoi = LEFT(kb.SoTheBHYT, 1) where b.MaVaoVien =N'{0}' and pdt_ct.TinhPhi = 1  ) X)Y  "
                        //        + " Group by MaVaoVien,TenDichvu,MaDichVu, DVT, ct_MuHuong, ct_TyLeBHYT, ct_DonGiaBHYT, ct_tinhphi, TyLe, ct_dongia,MaLoaiDichVu_BHYT, "
                        //        + " TenLoaiDichVu_BHYT,ThuTuIn_DichVu,DoiTuongBN,TenLoaiDichvu,LoaiDichVu,TenKhoa,MaKhoa,Tuyen,LanChuyenDT,TheBHYT,GtriTu,GtriDen "
                        //        + " ) A inner join NAMDINH_QLBN.dbo.ViewKHOAHIENTAI b on b.MaVaoVien = a.MaVaoVien inner join NAMDINH_SYSDB.dbo.DMKHOAPHONG c on c.MaKhoa = b.MaKhoa inner join NAMDINH_QLBN.dbo.BENHNHAN_CHITIET ct on ct.MaVaoVien = a.MaVaoVien inner join NAMDINH_KHAMBENH.dbo.tblKHAMBENH as kb on kb.MaKhambenh = ct.MaKhamBenh "
                        //        + " select MaVaoVien, TenDichvu, MaDichVu,  sum(SoLuong) as SoLuong, DVT, "
                        //        + " case when (select Sum(ct_ThanhTienBHYT) from ttt_bn group by Mavaovien) <= (select top 1  Luongcoban * 0.15 from NAMDINH_VIENPHI.dbo.tblLuongcoban) and doituongBN = 1 and Tuyen =1 then 60 when (select Sum(ct_ThanhTienBHYT) from ttt_bn group by Mavaovien) <= (select top 1  Luongcoban * 0.15 from NAMDINH_VIENPHI.dbo.tblLuongcoban) and doituongBN = 1 and Tuyen !=1 then 100 else ct_MuHuong end ct_MuHuong, ct_TyLeBHYT, ct_DonGiaBHYT, ct_tinhphi, TyLe, ct_dongia, Sum(ct_ThanhTienBV) as ct_ThanhTienBV , sum(ct_ThanhTienBHYT) as ct_ThanhTienBHYT ,  "
                        //        + " case when(select Sum(ct_ThanhTienBHYT) from ttt_bn group by Mavaovien) <= (select top 1  Luongcoban * 0.15 from NAMDINH_VIENPHI.dbo.tblLuongcoban) and doituongBN = 1 and Tuyen =1 then ct_ThanhTienBHYT*0.6 when(select Sum(ct_ThanhTienBHYT) from ttt_bn group by Mavaovien) <= (select top 1  Luongcoban * 0.15 from NAMDINH_VIENPHI.dbo.tblLuongcoban) and doituongBN = 1 and Tuyen !=1 then sum(ct_ThanhTienBHYT) else sum(ct_BHYTChitra)  end ct_BHYTChitra, "
                        //        + " case when(select Sum(ct_ThanhTienBHYT) from ttt_bn group by Mavaovien) <= (select top 1  Luongcoban * 0.15 from NAMDINH_VIENPHI.dbo.tblLuongcoban) and doituongBN = 1 and Tuyen =1 then ct_ThanhTienBHYT*0.4 when(select Sum(ct_ThanhTienBHYT) from ttt_bn group by Mavaovien) <= (select top 1  Luongcoban * 0.15 from NAMDINH_VIENPHI.dbo.tblLuongcoban) and doituongBN = 1 and Tuyen ! =1 then 0.00  else sum(ct_NBChitra) end ct_NBChitra, sum(ct_NBTutra) as ct_NBTutra, MaLoaiDichVu_BHYT, TenLoaiDichVu_BHYT, ThuTuIn_DichVu, DoiTuongBN, TenLoaiDichvu, LoaiDichVu, TenKhoa, MaKhoa, MaKhoaBYT, TenKhoaRaVien, MAICD_BC, MAICD_BP_1, NoiChuyenDi, NoiKhamBenh, TinhTrangRaVien, TgDu5Nam, MienChiTraTrongNam, Tuyen, LanChuyenDT, TheBHYT, GtriTu, GtriDen,ThoiDiemMienChiTraTrongNam from ttt_bn "
                        //        + " group by MaVaoVien, TenDichvu, MaDichVu, SoLuong, DVT, ct_MuHuong, ct_TyLeBHYT, ct_DonGiaBHYT, ct_tinhphi, TyLe, ct_dongia, ct_ThanhTienBV, ct_ThanhTienBHYT, ct_BHYTChitra, ct_NBChitra, ct_NBTutra, MaLoaiDichVu_BHYT, TenLoaiDichVu_BHYT, ThuTuIn_DichVu, DoiTuongBN, TenLoaiDichvu, LoaiDichVu, TenKhoa, MaKhoa, MaKhoaBYT, TenKhoaRaVien, MAICD_BC, MAICD_BP_1, NoiChuyenDi, NoiKhamBenh, TinhTrangRaVien, TgDu5Nam, MienChiTraTrongNam, Tuyen, LanChuyenDT, TheBHYT, GtriTu, GtriDen,ThoiDiemMienChiTraTrongNam"
                        //        + " order by LanChuyenDT,TenKhoa,ThuTuIn_DichVu,LoaiDichVu", maVaoVien, string.Format("{0:dd/MM/yyyy}", this.fgDanhSach.GetData(this.fgDanhSach.Row, 6)));
                        int s = DateTime.Parse(this.fgDanhSach.GetData(this.fgDanhSach.Row, "NgayRaVien").ToString()).Year - int.Parse(this.fgDanhSach[this.fgDanhSach.Row, 3].ToString());
                        string s1 = fgDanhSach.GetDataDisplay(this.fgDanhSach.Row, "CapCuu").ToString();
                        rptTongKetChiPhi_NhomTheoLoaiBHYT_6556 ibhyt = new rptTongKetChiPhi_NhomTheoLoaiBHYT_6556(maVaoVien, this.fgDanhSach[this.fgDanhSach.Row, 2].ToString(), string.Format("{0}", s), this.fgDanhSach[this.fgDanhSach.Row, 4].ToString(), this.fgDanhSach[this.fgDanhSach.Row, 5].ToString(), this.fgDanhSach.GetData(this.fgDanhSach.Row, 6), this.fgDanhSach[this.fgDanhSach.Row, "DiaChi"].ToString(), this.fgDanhSach[this.fgDanhSach.Row, "HanTheTu"].ToString(), this.fgDanhSach[this.fgDanhSach.Row, "HanTheDen"].ToString(), this.fgDanhSach[this.fgDanhSach.Row, "SoTheBHYT"].ToString(), this.fgDanhSach[this.fgDanhSach.Row, "NoiCapThe"].ToString(), this.fgDanhSach[this.fgDanhSach.Row, "Buong"].ToString(), this.fgDanhSach[this.fgDanhSach.Row, "Giuong"].ToString(), DateTime.Parse(this.fgDanhSach.GetData(this.fgDanhSach.Row, "NgayRaVien").ToString()), this.fgDanhSach[this.fgDanhSach.Row, "ChanDoan"].ToString(), this.fgDanhSach.GetDataDisplay(this.fgDanhSach.Row, "NoiGioiThieu"), this.fgDanhSach.GetDataDisplay(this.fgDanhSach.Row, "SoHSBA"), code, this.fgDanhSach.GetDataDisplay(this.fgDanhSach.Row, "BA_NOINGOAI"), this.fgDanhSach.GetDataDisplay(this.fgDanhSach.Row, "CapCuu").ToString(), DateTime.Parse(this.fgDanhSach.GetDataDisplay(this.fgDanhSach.Row, "NGAYKHAM")));
                        ibhyt.DataSource = _ds;
                        ibhyt.Run();
                        this.arvMain.Document = ibhyt.Document;
                        this.arvMain.Document.Name = "Bảng kê chi phí";
                        reader.Close();
                    }
                    else
                    {
                        SqlCommand command = new SqlCommand();
                        command.Connection = Global.ConnectSQL;
                        command.CommandText = string.Format("DECLARE @LanIn Int SET @LanIn = 0 SELECT @LanIn = ISNULL(PHIEUDIEUTRI_CHITIET.LanInTT,0) FROM BENHNHAN_PHIEUDIEUTRI  INNER JOIN PHIEUDIEUTRI_CHITIET ON PHIEUDIEUTRI_CHITIET.SOPHIEU = BENHNHAN_PHIEUDIEUTRI.SOPHIEU  WHERE BENHNHAN_PHIEUDIEUTRI.MAVAOVIEN ='{0}' AND PHIEUDIEUTRI_CHITIET.DATHANHTOAN = 1 SET @LANIN = @LANIN +1 UPDATE PHIEUDIEUTRI_CHITIET SET LANINTT = @LANIN WHERE SOPHIEU IN( SELECT SOPHIEU FROM BENHNHAN_PHIEUDIEUTRI WHERE MAVAOVIEN ='{0}' AND PHIEUDIEUTRI_CHITIET.DATHANHTOAN = 0)", this.fgDanhSach[this.fgDanhSach.Row, 1].ToString());
                        command.ExecuteNonQuery();
                        DataDynamics.ActiveReports.DataSources.SqlDBDataSource _ds = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
                        _ds.ConnectionString = GlobalModuls.Global.glbConnectionString;
                        _ds.SQL = string.Format(" select A.MaVaoVien, a.TenDichvu, a.MaDichVu, a.SoLuong, a.DVT,"
                                   + " case when a.DoiTuongBN = 1 and(a.Tuyen = 0 or a.tuyen = 2 or a.tuyen = 3) and ThoiDiemMienChiTraTrongNam is null then ct_MuHuong when a.DoiTuongBN = 1 and a.Tuyen = 1 then ct_MuHuong * 0.6 when MienChiTraTrongNam = 1 and Convert(date, ThoiDiemMienChiTraTrongNam) < Convert(date, getdate())  then 100  else 100 end as ct_MuHuong,"
                                   + " a.ct_TyLeBHYT, a.ct_DonGiaBHYT, a.ct_tinhphi, a.TyLe, a.ct_dongia, a.ct_ThanhTienBV, a.ct_ThanhTienBHYT,"
                                   + " CONVERT(decimal(18, 2), CONVERT(decimal(18, 2), (case when a.DoiTuongBN = 1 and(a.Tuyen = 0 or a.tuyen = 2 or a.tuyen = 3) and ThoiDiemMienChiTraTrongNam is null then ct_MuHuong when a.DoiTuongBN = 1 and a.Tuyen = 1 then ct_MuHuong * 0.6 when MienChiTraTrongNam = 1 and Convert(date, ThoiDiemMienChiTraTrongNam) < Convert(date, getdate())  then 100  else 100 end / 100)) * a.ct_BHYTChitra) as ct_BHYTChitra,"
                                   + " CONVERT(decimal(18, 2), (CONVERT(decimal(18, 2), (100 - (case when a.DoiTuongBN = 1 and(a.Tuyen = 0 or a.tuyen = 2 or a.tuyen = 3) and ThoiDiemMienChiTraTrongNam is null then ct_MuHuong when a.DoiTuongBN = 1 and a.Tuyen = 1 then ct_MuHuong * 0.6 when MienChiTraTrongNam = 1 and Convert(date, ThoiDiemMienChiTraTrongNam) < Convert(date, getdate())  then 100  else 100 end))) / 100) *a.ct_NBChitra) as ct_NBChitra, "
                                   + " case  when isnull(a.isPhieudieutri_chitiet_covid, 0) != 1 then a.ct_NBTutra else 0 end ct_NBTutra, a.MaLoaiDichVu_BHYT,a.TenLoaiDichVu_BHYT,a.ThuTuIn_DichVu,a.DoiTuongBN,a.TenLoaiDichvu,a.LoaiDichVu,a.TenKhoa,a.MaKhoa ,c.MaKhoaBYT ,c.TenKhoa as TenKhoaRaVien,B.MAICD_BC ,B.MAICD_BP_1,ct.ChuyenVien_ChuyenDenBV as NoiChuyenDi,kb.NoiGioiThieu as NoiKhamBenh, case when ct.NoiRaVien in (4,5) then 2  when ct.KetQuaDT in(4,5,6,7) then 2 else 1 end as TinhTrangRaVien,kb.TgDu5Nam,kb.MienChiTraTrongNam,A.Tuyen,A.LanChuyenDT,A.TheBHYT,A.GtriTu,A.GtriDen,kb.ThoiDiemMienChiTraTrongNam,a.isPhieudieutri_chitiet_covid,case  when isnull(a.isPhieudieutri_chitiet_covid, 0) = 1 then a.ct_NBTutra else 0 end ct_Khac"
                               + " from(select MaVaoVien, TenDichvu, MaDichVu, SUm(SoLuong) as SoLuong, DVT, ct_MuHuong, ct_TyLeBHYT, ct_DonGiaBHYT, ct_tinhphi, TyLe, ct_dongia,"
                               + " sum(ct_ThanhTienBV) as ct_ThanhTienBV, sum(ct_ThanhTienBHYT) as ct_ThanhTienBHYT, Sum(ct_BHYTChitra) as ct_BHYTChitra, Sum(ct_NBChitra) as ct_NBChitra,"
                               + "  + case when DoiTuongBN = 3 or isnull(isPhieudieutri_chitiet_covid, 0) = 1  then sum(ct_ThanhTienBV) when DoiTuongBN = 1 and is_chenh = 1 then  sum(ct_ThanhTienBV) - sum(ct_ThanhTienBHYT)  when DoiTuongBN = 1 and is_chenh = 0 and isnull(isPhieudieutri_chitiet_covid, 0) = 1 then  0  when DoiTuongBN = 1 and is_chenh = 0 and isnull(isPhieudieutri_chitiet_covid, 0) = 0 and LoaiDichVu not in ('C50','C62') then  sum(ct_ThanhTienBV) - sum(ct_ThanhTienBHYT) end as ct_NBTutra,"
                               + " MaLoaiDichVu_BHYT, TenLoaiDichVu_BHYT, ThuTuIn_DichVu, DoiTuongBN, TenLoaiDichvu, LoaiDichVu, TenKhoa, MaKhoa, Tuyen, LanChuyenDT, TheBHYT, GtriTu, GtriDen, isPhieudieutri_chitiet_covid from("
                               + " SELECT  MaVaoVien, SoPhieuCD, TenDichvu, MaDichVu, SoLuong, DVT, ct_MuHuong, ct_TyLeBHYT, isnull(ct_DonGiaBHYT, 0.00) as ct_DonGiaBHYT, ISNULL(ct_dongia, 0.00) AS ct_dongia,"
                               + " ISNULL(CONVERT(decimal(18, 2), SoLuong * ct_dongia * ct_tinhphi * (CONVERT(decimal(18, 2), TyLe) / 100)), 0.00) AS ct_ThanhTienBV,"
                               + " CONVERT(decimal(18, 2), ((SoLuong * ct_DonGiaBHYT) * (CONVERT(decimal(18, 2), ct_TyLeBHYT) / 100)) * (CONVERT(decimal(18, 2), TyLe) / 100) * ct_tinhphi)  AS ct_ThanhTienBHYT,"
                               + " CONVERT(decimal(18, 2), (((SoLuong * ct_DonGiaBHYT) * (CONVERT(decimal(18, 2), ct_TyLeBHYT) / 100)) * (CONVERT(decimal(18, 2), TyLe) / 100)) * ct_tinhphi) AS ct_BHYTChitra,"
                               + " CONVERT(decimal(18, 2), (((SoLuong * ct_DonGiaBHYT) * (CONVERT(decimal(18, 2), ct_TyLeBHYT) / 100)) * (CONVERT(decimal(18, 2), TyLe) / 100)) * ct_tinhphi) AS ct_NBChitra,"
                               + " ct_tienchenh as ct_NBTutra,"
                               + " ct_tinhphi, TyLe, MaLoaiDichVu_BHYT, TenLoaiDichVu_BHYT, ThuTuIn_DichVu, DoiTuongBN, TenLoaiDichvu, LoaiDichVu, TenKhoa, Makhoa, Tuyen, LanChuyenDT, TheBHYT, GtriTu, GtriDen, isPhieudieutri_chitiet_covid, is_chenh"
                               + " From("
                               + " select distinct pdt.MaVaoVien, pdt_ct.SoPhieu as SoPhieuCD, pdt_ct.MaDichVu, Inphieu.TenDichvu, pdt_ct.SoLuong, pdt_ct.tyle, CASE WHEN b.DoiTuong = 1 THEN a.PhantramDuocHuong ELSE 100 END AS ct_MuHuong,"
                               + " ISNULL(pdt_ct.TyLeBHYT, Inphieu.TyLeBHYT) AS ct_TyLeBHYT,"
                               + " CASE WHEN b.DoiTuong = 1 THEN Inphieu.DongiaBHYT WHEN b.DoiTuong = 3 THEN 0.00 END AS ct_DonGiaBHYT, Case when b.DoiTuong = 1 and Inphieu.is_chenh = 1 then Inphieu.DonGiaChenh + Inphieu.DongiaBHYT else Inphieu.Dongia  end AS ct_dongia, CASE WHEN is_chenh = 1   THEN CONVERT(decimal(18, 2), (SoLuong * ((case when pdt_ct.DoiTuongBN = 1 then Inphieu.DonGiaChenh else Inphieu.DonGia end)))) end AS ct_tienchenh, "
                               + " case when pdt_ct.Tinhphi = 0 then 1 else 0 end AS ct_tinhphi,Inphieu.DVT,Inphieu.MaLoaiDichVu_BHYT,Inphieu.TenLoaiDichVu_BHYT,Inphieu.ThuTuIn_DichVu,pdt_ct.DoiTuongBN,loaidv.TenLoaiDichvu,pdt_ct.LoaiDichVu,Khoaphong.TenKhoa,Khoaphong.MAKHOA,b.Tuyen,B.LanChuyenDT,b.maDoiTuongBHXH + b.SoThe as TheBHYT,B.GtriTu,B.GtriDen,pdt_ct.isPhieudieutri_chitiet_covid,is_chenh"
                                 + " FROM  dbo.BENHNHAN_DOITUONG AS b INNER JOIN"
                                 + " BENHNHAN_PHIEUDIEUTRI pdt on b.mavaovien = pdt.MaVaoVien"
                               + " inner join dbo.PHIEUDIEUTRI_CHITIET AS pdt_ct ON b.DoiTuong = pdt_ct.DoiTuongBN and pdt.SoPhieu = pdt_ct.SoPhieu and pdt_ct.LanChuyenDT = b.LanChuyenDT"
                               + " inner join NAMDINH_QLBN.dbo.INPHIEUTHANHTOAN Inphieu on Inphieu.MaDichvu = pdt_ct.MaDichvu"
                               + " inner join NAMDINH_SYSDB.dbo.DMLOAIDICHVU loaidv on loaidv.MaLoaiDichvu = pdt_ct.LoaiDichVu"
                               + " inner join NAMDINH_SYSDB.dbo.DMKHOAPHONG Khoaphong on Khoaphong.MAKHOA = pdt.MaKhoa"
                               + " LEFT join NAMDINH_VIENPHI.dbo.DMQUYENLOI AS a ON a.MaQuyenLoi = LEFT(b.SoThe, 1)"
                               + " where b.MaVaoVien = '{0}'  ) X)Y"
                               + " Group by MaVaoVien, TenDichvu, MaDichVu, DVT, ct_MuHuong, ct_TyLeBHYT, ct_DonGiaBHYT, ct_tinhphi, TyLe, ct_dongia, MaLoaiDichVu_BHYT, TenLoaiDichVu_BHYT, ThuTuIn_DichVu, DoiTuongBN, TenLoaiDichvu, LoaiDichVu, TenKhoa, MaKhoa, Tuyen, LanChuyenDT, TheBHYT, GtriTu, GtriDen, isPhieudieutri_chitiet_covid, is_chenh"
                               + " Union all"
                               + " select MaVaoVien, Tendichvu, MaDichVu, SoLuong, DVT, ct_MuHuong, ct_TyLeBHYT, ct_DonGiaBHYT, ct_tinhphi, TyLe, ct_dongia, sum(ct_ThanhTienBV) as ct_ThanhTienBV, sum(ct_ThanhTienBHYT) as ct_ThanhTienBHYT, Sum(ct_BHYTChitra) as ct_BHYTChitra, Sum(ct_NBChitra) as ct_NBChitra, sum(ct_ThanhTienBV) - sum(ct_ThanhTienBHYT) as ct_NBTutra,"
                               + " 'VATTU_MO' as MaLoaiDichVu_BHYT, N'Gói vật tư y tế' as TenLoaiDichVu_BHYT, ThuTuIn_DichVu, DoiTuongBN, TenLoaiDichvu, LoaiDichVu, N'Khoa gây mê hồi sức' as TenKhoa, 'NV1103' as MAKHOA, Tuyen, LanChuyenDT, TheBHYT, GtriTu, GtriDen, isPhieudieutri_chitiet_covid"
                               + " from(SELECT  MaVaoVien, SoPhieuCD, MaDichVu, SoLuong, DVT, ct_MuHuong, ct_TyLeBHYT, isnull(ct_DonGiaBHYT, 0.00) as ct_DonGiaBHYT, ISNULL(ct_dongia, 0.00) AS ct_dongia,"
                               + " ISNULL(CONVERT(decimal(18, 2), SoLuong * ct_dongia * ct_tinhphi * (CONVERT(decimal(18, 2), TyLe) / 100)), 0.00) AS ct_ThanhTienBV,"
                               + " CONVERT(decimal(18, 2), ((SoLuong * ct_DonGiaBHYT) * (CONVERT(decimal(18, 2), ct_TyLeBHYT) / 100)) * (CONVERT(decimal(18, 2), TyLe) / 100) * ct_tinhphi)  AS ct_ThanhTienBHYT,"
                               + " CONVERT(decimal(18, 2), (((SoLuong * ct_DonGiaBHYT) * (CONVERT(decimal(18, 2), ct_TyLeBHYT) / 100)) * (CONVERT(decimal(18, 2), TyLe) / 100)) * ct_tinhphi) AS ct_BHYTChitra,"
                               + " CONVERT(decimal(18, 2), (((SoLuong * ct_DonGiaBHYT) * (CONVERT(decimal(18, 2), ct_TyLeBHYT) / 100)) * (CONVERT(decimal(18, 2), TyLe) / 100)) * ct_tinhphi) AS ct_NBChitra,"
                               + " ct_tienchenh as ct_NBTutra, ct_tinhphi, TyLe, ThuTuIn_DichVu, DoiTuongBN, TenLoaiDichvu, LoaiDichVu, TenDichvu, Tuyen, LanChuyenDT, TheBHYT, GtriTu, GtriDen, isPhieudieutri_chitiet_covid"
                               + " From(select distinct pdt_ct.MaVaoVien, pdt_ct.SoPhieuCD, pdt_ct.MaDichVu, pdt_ct.SoLuong, pdt_ct.tyle, a.PhantramDuocHuong AS ct_MuHuong, ISNULL(pdt_ct.TyLeBHYT, KHO.TyLeBHYT) AS ct_TyLeBHYT, CASE WHEN b.DoiTuong = 1 THEN KHO.DongiaBHYT WHEN b.DoiTuong = 3 THEN 0.00 END AS ct_DonGiaBHYT, Case when b.DoiTuong = 1 and kho.is_chenh = 1 then kho.DonGiaChenh + KHO.DongiaBHYT else KHO.Dongia  end AS ct_dongia, CASE WHEN is_chenh = 1   THEN CONVERT(decimal(18, 2), (SoLuong * ((case when b.DoiTuong = 1 then KHO.DonGiaChenh else KHO.DonGia end)))) end AS ct_tienchenh, pdt_ct.Tinhphi AS ct_tinhphi,KHO.DVT,10 as ThuTuIn_DichVu,b.DoiTuong as DoiTuongBN,pdt_ct.LoaiDichVu,(select TenDichvu from INPHIEUTHANHTOAN where madichvu = pdt_ct.MaPT) as TenLoaiDichvu,kho.TenDichvu,b.Tuyen,B.LanChuyenDT,b.maDoiTuongBHXH + b.SoThe as TheBHYT,B.GtriTu,B.GtriDen,CT.isPhieudieutri_chitiet_covid"
                                    + " FROM  dbo.BENHNHAN_DOITUONG AS b INNER JOIN dbo.BENHNHAN_PT_CHIPHI AS pdt_ct ON b.MaVaoVien = pdt_ct.MaVaoVien"
                               + " INNER JOIN dbo.INPHIEUTHANHTOAN AS KHO ON KHO.MaDichvu = pdt_ct.MaDichVu"
                               + " inner join (SELECT sophieu, LanChuyenDT, MaDichVu, isPhieudieutri_chitiet_covid from NAMDINH_QLBN.DBO.PHIEUDIEUTRI_CHITIET) CT ON CT.SoPhieu = pdt_ct.SoPhieuCD  AND CT.MaDichVu = PDT_CT.MaPT and ct.LanChuyenDT = b.LanChuyenDT"
                               + " inner join NAMDINH_SYSDB.dbo.DMLOAIDICHVU loai on loai.MaLoaiDichvu = KHO.LoaiDichvu LEFT JOIN"
                               + " NAMDINH_VIENPHI.dbo.DMQUYENLOI AS a ON a.MaQuyenLoi = LEFT(b.SoThe, 1)"
                               + " where b.MaVaoVien = '{0}') X)Y where ct_tinhphi = 1"
                               + " Group by  MaVaoVien,SoPhieuCD,MaDichVu,SoLuong,DVT, ct_MuHuong, ct_TyLeBHYT, ct_DonGiaBHYT,ct_tinhphi, TyLe,ct_dongia,ThuTuIn_DichVu,DoiTuongBN,TenLoaiDichvu ,LoaiDichVu,TenDichvu,Tuyen,LanChuyenDT,TheBHYT,GtriTu,GtriDen,isPhieudieutri_chitiet_covid"
                               + " Union all"
                               + " select MaVaoVien,TenDichvu, MaDichVu,SUm(SoLuong) as SoLuong, DVT, isnull(ct_MuHuong, 100) as ct_MuHuong, ct_TyLeBHYT, ct_DonGiaBHYT, ct_tinhphi, TyLe, ct_dongia, sum(ct_ThanhTienBV) as ct_ThanhTienBV,sum(ct_ThanhTienBHYT) as ct_ThanhTienBHYT,Sum(ct_BHYTChitra) as ct_BHYTChitra,Sum(ct_NBChitra) as ct_NBChitra,"
                               + " case when DoiTuongBN = 3 or isnull(isPhieudieutri_chitiet_covid,0) = 1  then sum(ct_ThanhTienBV)when DoiTuongBN = 1 and is_chenh = 1 then  sum(ct_ThanhTienBV) - sum(ct_ThanhTienBHYT)  when DoiTuongBN = 1 and is_chenh = 0 and isnull(isPhieudieutri_chitiet_covid, 0) = 1 then  0  when DoiTuongBN = 1 and is_chenh = 0 and isnull(isPhieudieutri_chitiet_covid, 0) = 0 and LoaiDichVu not in ('C50','C62') then  sum(ct_ThanhTienBV) - sum(ct_ThanhTienBHYT) end as ct_NBTutra,"
                               + " MaLoaiDichVu_BHYT, TenLoaiDichVu_BHYT, ThuTuIn_DichVu, DoiTuongBN, TenLoaiDichvu, LoaiDichVu, TenKhoa, MaKhoa, Tuyen, LanChuyenDT, TheBHYT, GtriTu, GtriDen, isPhieudieutri_chitiet_covid"
                               + " from(SELECT  MaVaoVien, SoPhieuCD, TenDichvu, MaDichVu, SoLuong, DVT, ct_MuHuong, ct_TyLeBHYT, isnull(ct_DonGiaBHYT, 0.00) as ct_DonGiaBHYT, ISNULL(ct_dongia, 0.00) AS ct_dongia, ISNULL(CONVERT(decimal(18, 2), SoLuong * ct_dongia * ct_tinhphi * (CONVERT(decimal(18, 2), TyLe) / 100)), 0.00) AS ct_ThanhTienBV, CONVERT(decimal(18, 2), ((SoLuong * ct_DonGiaBHYT) * (CONVERT(decimal(18, 2), ct_TyLeBHYT) / 100)) * (CONVERT(decimal(18, 2), TyLe) / 100) * ct_tinhphi)  AS ct_ThanhTienBHYT, CONVERT(decimal(18, 2), (((SoLuong * ct_DonGiaBHYT) * (CONVERT(decimal(18, 2), ct_TyLeBHYT) / 100)) * (CONVERT(decimal(18, 2), TyLe) / 100)) * ct_tinhphi) AS ct_BHYTChitra, CONVERT(decimal(18, 2), (((SoLuong * ct_DonGiaBHYT) * (CONVERT(decimal(18, 2), ct_TyLeBHYT) / 100)) * (CONVERT(decimal(18, 2), TyLe) / 100)) * ct_tinhphi) AS ct_NBChitra,"
                               + " ct_tienchenh as ct_NBTutra,"
                               + " ct_tinhphi, TyLe, MaLoaiDichVu_BHYT, TenLoaiDichVu_BHYT, ThuTuIn_DichVu, DoiTuongBN, TenLoaiDichvu, LoaiDichVu, TenKhoa, Makhoa, Tuyen, LanChuyenDT, TheBHYT, GtriTu, GtriDen, isPhieudieutri_chitiet_covid, is_chenh"
                               + " From(select distinct b.MaVaoVien, pdt_ct.MaPhieuCD as SoPhieuCD, pdt_ct.MaChiPhi as MaDichVu, Inphieu.TenDichvu, pdt_ct.SoLuong, pdt_ct.tyle,"
                               + " CASE WHEN kb.DoiTuong = 1 THEN a.PhantramDuocHuong ELSE 100 END AS ct_MuHuong, ISNULL(pdt_ct.TyLeBH, Inphieu.TyLeBHYT) AS ct_TyLeBHYT,"
                               + " CASE WHEN kb.DoiTuong = 1 THEN Inphieu.DongiaBHYT WHEN kb.DoiTuong = 3 THEN 0.00 END AS ct_DonGiaBHYT, Case when kb.DoiTuong = 1 and Inphieu.is_chenh = 1 then Inphieu.DonGiaChenh + Inphieu.DongiaBHYT else pdt_ct.DonGia  end AS ct_dongia, CASE WHEN is_chenh = 1   THEN CONVERT(decimal(18, 2), (SoLuong * ((case when DT.DoiTuong = 1 then Inphieu.DonGiaChenh else Inphieu.Dongia end)))) end AS ct_tienchenh,"
                               + " pdt_ct.Tinhphi as ct_tinhphi,Inphieu.DVT,Inphieu.MaLoaiDichVu_BHYT,Inphieu.TenLoaiDichVu_BHYT,Inphieu.ThuTuIn_DichVu,kb.DoiTuong as DoiTuongBN,loaidv.TenLoaiDichvu,pdt_ct.LoaiChiPhi as LoaiDichVu,Khoaphong.TenKhoa,Khoaphong.MAKHOA,case when convert(date, kb.ThoigianDangky) >= CONVERT(date, '01/01/2021') and kb.Tuyen = 1 then 3 else  kb.Tuyen end as Tuyen, 0 as LanChuyenDT, kb.doituongthe + kb.SoTheBHYT as TheBHYT, kb.HantheBHYT_Tu as GtriTu, kb.HantheBHYT_den as GtriDen, case when isnull(ischiphiphongkham_covid, 0) = 0 then 0 else 1 end as isPhieudieutri_chitiet_covid, is_chenh"
                              + " FROM  dbo.BENHNHAN_CHITIET AS b INNER JOIN NAMDINH_KHAMBENH.dbo.tblKHAMBENH kb on b.MaKhamBenh = kb.MaKhambenh"
                              + " INNER JOIN ViewDOITUONGHIENTAI DT ON DT.MAVAOVIEN = B.MAVAOVIEN"
                              + " inner join NAMDINH_KHAMBENH.dbo.tblCHIPHI_DICHVU AS pdt_ct ON pdt_ct.MaKhamBenh = kb.MaKhambenh"
                              + " inner join NAMDINH_QLBN.dbo.INPHIEUTHANHTOAN Inphieu on Inphieu.MaDichvu = pdt_ct.MaChiPhi"
                              + " inner join NAMDINH_SYSDB.dbo.DMLOAIDICHVU loaidv on loaidv.MaLoaiDichvu = pdt_ct.LoaiChiPhi"
                              + " inner join NAMDINH_SYSDB.dbo.DMKHOAPHONG Khoaphong on Khoaphong.MAKHOA = pdt_ct.MaKhoaThucHien"
                              + " LEFT JOIN NAMDINH_VIENPHI.dbo.DMQUYENLOI AS a ON a.MaQuyenLoi = LEFT(kb.SoTheBHYT, 1) where b.MaVaoVien = '{0}' and pdt_ct.TinhPhi = 1  ) X)Y"
                              + " Group by MaVaoVien, TenDichvu, MaDichVu, DVT, ct_MuHuong, ct_TyLeBHYT, ct_DonGiaBHYT, ct_tinhphi, TyLe, ct_dongia, MaLoaiDichVu_BHYT,"
                               + " TenLoaiDichVu_BHYT, ThuTuIn_DichVu, DoiTuongBN, TenLoaiDichvu, LoaiDichVu, TenKhoa, MaKhoa, Tuyen, LanChuyenDT, TheBHYT, GtriTu, GtriDen, isPhieudieutri_chitiet_covid, is_chenh"
                               + " ) A inner join NAMDINH_QLBN.dbo.ViewKHOAHIENTAI b on b.MaVaoVien = a.MaVaoVien"
                               + " inner join NAMDINH_SYSDB.dbo.DMKHOAPHONG c on c.MaKhoa = b.MaKhoa inner join NAMDINH_QLBN.dbo.BENHNHAN_CHITIET ct on ct.MaVaoVien = a.MaVaoVien"
                               + " inner join NAMDINH_KHAMBENH.dbo.tblKHAMBENH as kb on kb.MaKhambenh = ct.MaKhamBenh where ct.MaVaoVien = '{0}'"
                               + " order by LanChuyenDT,TenKhoa,ThuTuIn_DichVu,LoaiDichVu ", maVaoVien, string.Format("{0:dd/MM/yyyy}", this.fgDanhSach.GetData(this.fgDanhSach.Row, 6)));
                        _ds.CommandTimeout = 0;
                        int s = DateTime.Parse(this.fgDanhSach.GetData(this.fgDanhSach.Row, "NgayRaVien").ToString()).Year - int.Parse(this.fgDanhSach[this.fgDanhSach.Row, 3].ToString());
                        string s1 = fgDanhSach.GetDataDisplay(this.fgDanhSach.Row, "CapCuu").ToString();
                        rptTongKetChiPhi_NhomTheoLoaiBHYT_6556_Covid ibhyt = new rptTongKetChiPhi_NhomTheoLoaiBHYT_6556_Covid(maVaoVien, this.fgDanhSach[this.fgDanhSach.Row, 2].ToString(), string.Format("{0}", s), this.fgDanhSach[this.fgDanhSach.Row, 4].ToString(), this.fgDanhSach[this.fgDanhSach.Row, 5].ToString(), this.fgDanhSach.GetData(this.fgDanhSach.Row, 6), this.fgDanhSach[this.fgDanhSach.Row, "DiaChi"].ToString(), this.fgDanhSach[this.fgDanhSach.Row, "HanTheTu"].ToString(), this.fgDanhSach[this.fgDanhSach.Row, "HanTheDen"].ToString(), this.fgDanhSach[this.fgDanhSach.Row, "SoTheBHYT"].ToString(), this.fgDanhSach[this.fgDanhSach.Row, "NoiCapThe"].ToString(), this.fgDanhSach[this.fgDanhSach.Row, "Buong"].ToString(), this.fgDanhSach[this.fgDanhSach.Row, "Giuong"].ToString(), DateTime.Parse(this.fgDanhSach.GetData(this.fgDanhSach.Row, "NgayRaVien").ToString()), this.fgDanhSach[this.fgDanhSach.Row, "ChanDoan"].ToString(), this.fgDanhSach.GetDataDisplay(this.fgDanhSach.Row, "NoiGioiThieu"), this.fgDanhSach.GetDataDisplay(this.fgDanhSach.Row, "SoHSBA"), code, this.fgDanhSach.GetDataDisplay(this.fgDanhSach.Row, "BA_NOINGOAI"), this.fgDanhSach.GetDataDisplay(this.fgDanhSach.Row, "CapCuu").ToString(), DateTime.Parse(this.fgDanhSach.GetDataDisplay(this.fgDanhSach.Row, "NGAYKHAM")));
                        ibhyt.DataSource = _ds;
                        ibhyt.Run();
                        this.arvMain.Document = ibhyt.Document;
                        this.arvMain.Document.Name = "Bảng kê chi phí";
                        reader.Close();
                    }
                }
            }
            }
            private void txtDKNgayRV_ValueChanged(object sender, EventArgs e)
        {
            if (txtTNgay.Tag.ToString() == "0") { return; }
            Load_DSBenhNhan();
        }

        private void arvMain_ToolClick(object sender, ToolClickEventArgs e)
        {
            //if (rdChuaRV.Checked)
            //{
            //    MessageBox.Show("Không cho phép in phơi khi chưa tổng kết ra viện:", "Thông báo!", MessageBoxButtons.OK);
            //    return;         
                
            //}
 
        }

        private void rdChuyenKhoa_CheckedChanged(object sender, EventArgs e)
        {
       
            rdChuaRV_CheckedChanged(null, null);
           
        }

        private void rdDaRV_CheckedChanged(object sender, EventArgs e)
        {
  
            rdChuaRV_CheckedChanged(null, null);
        }

        private void txtDNgay_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTNgay_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDNgay_ValueChanged(object sender, EventArgs e)
        {
            if (txtDNgay.Tag.ToString() == "0") { return; }
            Load_DSBenhNhan();
        }

        private void raChiPhiChuaThu_CheckedChanged(object sender, EventArgs e)
        {
            fgDanhSach_AfterRowColChange(null, null);
        }

        private void cmdTongHop_Click(object sender, EventArgs e)
        {
            if ((this.fgDanhSach.Row >= 1) && (this.fgDanhSach.Tag.ToString() != "0"))
            {
                DateTime ngayLV;
                string maVaoVien = this.fgDanhSach[this.fgDanhSach.Row, 1].ToString();
                string code = Global.GetCode(this.cmbKhoa);
                Global.wait("Đang chuẩn bị dữ liệu...!");
                SqlCommand selectCommand = new SqlCommand();
                selectCommand.Connection = Global.ConnectSQL;
                DateTime data = (DateTime)this.fgDanhSach.GetData(this.fgDanhSach.Row, "NgayVaoVien");
                if (this.fgDanhSach.GetDataDisplay(this.fgDanhSach.Row, "DaRaVien") == "0")
                {
                    ngayLV = Global.GetNgayLV();
                }
                else
                {
                    ngayLV = (DateTime)this.fgDanhSach.GetData(this.fgDanhSach.Row, "NgayRaVien");
                }
                string str3 = "";
                if (this.cmbLanIn.SelectedIndex == 0)
                {
                    str3 = this.raChiPhiChuaThu.Checked ? " A.DATHANHTOAN = 0 AND " : " ((A.DATHANHTOAN = 0) OR (A.DATHANHTOAN = 1 AND A.LANINTT IS NULL )) AND";
                }
                else
                {
                    str3 = string.Format(" a.LanInTT='{0}' and", Global.GetCode(this.cmbLanIn));
                }
                int lanChuyenKhoaHT = Global.GetLanChuyenKhoaHT_BC(maVaoVien,Global.GetCode(cmbKhoa));
                DateTime time3 = ngayLV;
                int num2 = lanChuyenKhoaHT;
                selectCommand.CommandText = string.Concat(new object[] { "Select * from BENHNHAN_KHOA where MaVaoVien = '", maVaoVien, "' and LanChuyenKhoa =", num2 });
                SqlDataReader reader = selectCommand.ExecuteReader();
                if (reader.Read())
                {
                    time3 = (DateTime)reader["NgayChuyen"];
                }
                reader.Close();
                if (time3.Hour == 0)
                {
                    time3 = time3.AddHours(16.0);
                }
                selectCommand.CommandText = string.Format(string.Concat(new object[] { " DECLARE @SoLuong_BH int DECLARE @SoLuong_VP int DECLARE @SoLuong_Khac int DECLARE @LanChuyenKhoa int SELECT @SoLuong_BH = SUM(B.SOLUONG) FROM  (BENHNHAN_PHIEUDIEUTRI A INNER JOIN PHIEUDIEUTRI_CHITIET B ON A.SOPHIEU = B.SOPHIEU AND B.TINHPHI = 0 AND B.DOITUONGBN = 1 AND B.DATHANHTOAN = 0) INNER JOIN DMDONGIA ON DMDONGIA.MADICHVU = B.MADICHVU AND DMDONGIA.MAKHOA = A.MAKHOA WHERE A.MAVAOVIEN = '{0}' AND A.MAKHOA ='{1}' GROUP BY B.MADICHVU SELECT @SoLuong_VP = SUM(B.SOLUONG) FROM  (BENHNHAN_PHIEUDIEUTRI A INNER JOIN PHIEUDIEUTRI_CHITIET B ON A.SOPHIEU = B.SOPHIEU AND B.TINHPHI = 0 AND B.DOITUONGBN = 3 AND B.DATHANHTOAN = 0) INNER JOIN DMDONGIA ON DMDONGIA.MADICHVU = B.MADICHVU AND DMDONGIA.MAKHOA = A.MAKHOA WHERE A.MAVAOVIEN = '{0}' AND A.MAKHOA ='{1}' GROUP BY B.MADICHVU SELECT @SoLuong_Khac = SUM(B.SOLUONG) FROM  (BENHNHAN_PHIEUDIEUTRI A INNER JOIN PHIEUDIEUTRI_CHITIET B ON A.SOPHIEU = B.SOPHIEU AND B.TINHPHI = 0 AND B.DOITUONGBN NOT IN (1,3) AND B.DATHANHTOAN = 0) INNER JOIN DMDONGIA ON DMDONGIA.MADICHVU = B.MADICHVU AND DMDONGIA.MAKHOA = A.MAKHOA WHERE A.MAVAOVIEN = '{0}' AND A.MAKHOA ='{1}' GROUP BY B.MADICHVU SELECT AA.BANSAO, m.TenKhoa,m.GTriTu,m.GTriDen,m.TenBHYTCap,m.MaKhoa as MaKhoa_Khac, CASE WHEN AA.DOITUONGBN IS NULL THEN M.DOITUONGBN ELSE AA.DOITUONGBN END AS DOITUONGBN, AA.TENDT,AA.MAKHOA, CASE WHEN AA.LANCHUYENDT IS NULL THEN M.LANCHUYENDT ELSE AA.LANCHUYENDT END AS LANCHUYENDT, case when AA.TUYEN is null then m.tuyen else aa.tuyen end as Tuyen, AA.LOAIDICHVU,AA.TENLOAIDICHVU,AA.MADICHVU,AA.TENDICHVU, CASE WHEN AA.MALOAITHUOC_BHYT IS NULL THEN 'TDM_BHYT' ELSE AA.MALOAITHUOC_BHYT END AS MALOAITHUOC_BHYT, CASE WHEN AA.TENLOAITHUOC_BHYT IS NULL THEN N'Trong danh mục BHYT' ELSE AA.TENLOAITHUOC_BHYT END TENLOAITHUOC_BHYT, AA.THUTUIN_THUOC, CASE WHEN AA.LANCHUYENKHOA IS NULL THEN M.LANCHUYENKHOA ELSE AA.LANCHUYENKHOA END AS LANCHUYENKHOA, AA.TUNGAY,AA.HANTHE,AA.TENNOICAP,AA.DENNGAY,AA.DVT,AA.SL,AA.DONGIA, "
                + " AA.THANHTIEN* AA.TyLe/100 as THANHTIEN,"
                + " (CASE WHEN aa.DoiTuongBN = 1 THEN CASE WHEN AA.TUYEN = 0 THEN CASE AA.MaDichVu  WHEN 'E01000' THEN AA.THANHTIEN  ELSE  F.PhantramDuocHuong  * AA.THANHTIEN / 100  END ELSE 0.6 * F.PhantramDuocHuong * AA.THANHTIEN / 100  END  ELSE 0 END)* AA.TyLe/100  AS TienBH, "
                + " (CASE WHEN aa.DoiTuongBN = 1 THEN CASE WHEN AA.TUYEN = 0 THEN CASE AA.MaDichVu WHEN 'E01000' THEN 0 ELSE AA.THANHTIEN - F.PhantramDuocHuong * AA.THANHTIEN / 100 END ELSE AA.THANHTIEN - 0.6 * F.PhantramDuocHuong * AA.THANHTIEN / 100 END ELSE AA.THANHTIEN END)* AA.TyLe/100 AS TienBN, "
                + " m.ThuTuIn AS ThuTuIn_DichVu,m.TenLoaiDichVu_BHYT,m.MALOAIDICHVU_BHYT,m.SoThe,m.MaNoiCap,m.MAICD_BC FROM ( SELECT CASE WHEN '{1}' = E.MAKHOA OR LEFT(E.MAKHOA,4) = 'NV13' THEN '' ELSE N'BẢN SAO' END AS BANSAO,a.DoiTuongBN,UPPER(N'(Đối tượng thanh to\x00e1n: ' + d.TenDT + N')') as TenDT,BENHNHAN_DOITUONG.LanChuyenDT,BENHNHAN_DOITUONG.Tuyen, a.LoaiDichVu,b.TenLoaiDichVu,a.MaDichVu,c.TenDichVu, c.MaLoaiDichVu_BHYT,c.MaLoaiThuoc_BHYT,c.TenLoaiThuoc_BHYT,c.ThuTuIn_Thuoc, E.MaKhoa, Case LEFT(E.MAKHOA,4) when 'NV13' then ", lanChuyenKhoaHT, " else  BK.LANCHUYENKHOA end As LanChuyenKhoa,Case LEFT(E.MAKHOA,4) when 'NV13' then KD.TenKhoa else F.TenKhoa end as TenKhoa,KHOA_DAU.NGAYCHUYEN AS TUNGAY,CASE WHEN A.DOITUONGBN = 1 THEN N'- Số thẻ: ' + BENHNHAN_DOITUONG.MADOITUONGBHXH + BENHNHAN_DOITUONG.SOTHE + BENHNHAN_DOITUONG.MANOICAP ELSE '' END AS SOTHE1, CASE WHEN A.DOITUONGBN = 1 THEN N'- C\x00f3 gi\x00e1 trị từ ' + CONVERT(NVARCHAR(50),BENHNHAN_DOITUONG.GTRITU,103) + N' đến ' + CONVERT(NVARCHAR(50),BENHNHAN_DOITUONG.GTRIDEN,103) ELSE '' END AS HANTHE,N'Nơi cấp BHYT: ' + ISNULL(BENHNHAN_DOITUONG.TenBHYTCap,'') AS TenNoiCap, '", string.Format("{0:MM/dd/yyyy HH:mm}", time3), "' as DenNgay, CASE WHEN F.KHOI = 0 THEN      CASE WHEN F.KHOI = 0 AND (DMDONGIA.MADICHVU IS NULL OR A.TINHPHI = 1) THEN          C.DVT     ELSE         Case when DMDONGIA.MADICHVU IS NULL then C.DVT else CONVERT(NVARCHAR(50),CASE WHEN A.DOITUONGBN = 1 THEN @SoLuong_BH ELSE CASE WHEN A.DOITUONGBN = 3 THEN @SoLuong_VP ELSE @SoLuong_Khac END END) + ' ' + C.DVT end     END ELSE     CASE WHEN F.KHOI = 1 AND (DMDONGIA.MADICHVU IS NULL OR A.TINHPHI = 1) THEN          C.DVT     ELSE         Case when DMDONGIA.MADICHVU IS NULL then C.DVT else CONVERT(NVARCHAR(50),CASE WHEN A.DOITUONGBN = 1 THEN @SoLuong_BH ELSE CASE WHEN A.DOITUONGBN = 3 THEN @SoLuong_VP ELSE @SoLuong_Khac END END) + ' ' + C.DVT end     END END AS DVT, CASE WHEN F.KHOI = 0 THEN     CASE WHEN F.KHOI = 0 AND (DMDONGIA.MADICHVU IS NULL OR A.TINHPHI = 1) THEN  \t\tSum(SoLuong * SoThang) \tELSE  \t\t1 \tEND ELSE     CASE WHEN F.KHOI = 1 AND (DMDONGIA.MADICHVU IS NULL OR A.TINHPHI = 1) THEN  \t\tSum(SoLuong * SoThang) \tELSE  \t\t1 \tEND END AS SL, CASE WHEN F.KHOI = 0 THEN  \tCASE WHEN F.KHOI = 0 AND (DMDONGIA.MADICHVU IS NULL OR A.TINHPHI = 1) THEN  \t\tcase when a.tinhphi = 0 then a.DonGia else 0 end  \tELSE  \t\tCASE WHEN DMDONGIA.is_CoDonGiaDB = 1 THEN  \t\t\tCASE WHEN CASE WHEN A.DOITUONGBN = 1 THEN @SoLuong_BH ELSE CASE WHEN A.DOITUONGBN = 3 THEN @SoLuong_VP ELSE @SoLuong_Khac END END <= 5 THEN  \t\t\t\tDMDONGIA.DG_15 \t\t\tELSE \t\t\t\tCASE WHEN CASE WHEN A.DOITUONGBN = 1 THEN @SoLuong_BH ELSE CASE WHEN A.DOITUONGBN = 3 THEN @SoLuong_VP ELSE @SoLuong_Khac END END >= 6 AND CASE WHEN A.DOITUONGBN = 1 THEN @SoLuong_BH ELSE CASE WHEN A.DOITUONGBN = 3 THEN @SoLuong_VP ELSE @SoLuong_Khac END END <= 10 THEN  \t\t\t\t\tDMDONGIA.DG_610 \t\t\t\tELSE \t\t\t\t\tCASE WHEN CASE WHEN A.DOITUONGBN = 1 THEN @SoLuong_BH ELSE CASE WHEN A.DOITUONGBN = 3 THEN @SoLuong_VP ELSE @SoLuong_Khac END END > 10 THEN  \t\t\t\t\t\tDMDONGIA.DG_T10 \t\t\t\t\tEND \t\t\t\tEND \t\t\tEND \t\tELSE  \t\t\tCASE WHEN CASE WHEN A.DOITUONGBN = 1 THEN @SoLuong_BH ELSE CASE WHEN A.DOITUONGBN = 3 THEN @SoLuong_VP ELSE @SoLuong_Khac END END <= 5 THEN  \t\t\t\tDMDONGIA.DG_15 \t\t\tELSE \t\t\t\tCASE WHEN CASE WHEN A.DOITUONGBN = 1 THEN @SoLuong_BH ELSE CASE WHEN A.DOITUONGBN = 3 THEN @SoLuong_VP ELSE @SoLuong_Khac END END >= 6 AND CASE WHEN A.DOITUONGBN = 1 THEN @SoLuong_BH ELSE CASE WHEN A.DOITUONGBN = 3 THEN @SoLuong_VP ELSE @SoLuong_Khac END END <= 10 THEN  \t\t\t\t\tDMDONGIA.DG_610 \t\t\t\tELSE \t\t\t\t\tCASE WHEN CASE WHEN A.DOITUONGBN = 1 THEN @SoLuong_BH ELSE CASE WHEN A.DOITUONGBN = 3 THEN @SoLuong_VP ELSE @SoLuong_Khac END END > 10 AND CASE WHEN A.DOITUONGBN = 1 THEN @SoLuong_BH ELSE CASE WHEN A.DOITUONGBN = 3 THEN @SoLuong_VP ELSE @SoLuong_Khac END END <= 20 THEN  \t\t\t\t\t\tDMDONGIA.DG_1020 \t\t\t\t\tELSE \t\t\t\t\t\tCASE WHEN CASE WHEN A.DOITUONGBN = 1 THEN @SoLuong_BH ELSE CASE WHEN A.DOITUONGBN = 3 THEN @SoLuong_VP ELSE @SoLuong_Khac END END > 20 AND CASE WHEN A.DOITUONGBN = 1 THEN @SoLuong_BH ELSE CASE WHEN A.DOITUONGBN = 3 THEN @SoLuong_VP ELSE @SoLuong_Khac END END <= 30 THEN  \t\t\t\t\t\t\tDMDONGIA.DG_T20 \t\t\t\t\t\tELSE \t\t\t\t\t\t\tDMDONGIA.DG_T1T \t\t\t\t\t\tEND \t\t\t\t\tEND \t\t\t\tEND \t\t\tEND \t\tEND \tEND ELSE  \tCASE WHEN F.KHOI = 1 AND (DMDONGIA.MADICHVU IS NULL OR A.TINHPHI = 1) THEN  \t\tcase when a.tinhphi = 0 then a.DonGia else 0 end  \tELSE  \t\tCASE WHEN DMDONGIA.is_CoDonGiaDB = 1 THEN  \t\t\tCASE WHEN CASE WHEN A.DOITUONGBN = 1 THEN @SoLuong_BH ELSE CASE WHEN A.DOITUONGBN = 3 THEN @SoLuong_VP ELSE @SoLuong_Khac END END <= 5 THEN  \t\t\t\tDMDONGIA.DG_15 \t\t\tELSE \t\t\t\tCASE WHEN CASE WHEN A.DOITUONGBN = 1 THEN @SoLuong_BH ELSE CASE WHEN A.DOITUONGBN = 3 THEN @SoLuong_VP ELSE @SoLuong_Khac END END >= 6 AND CASE WHEN A.DOITUONGBN = 1 THEN @SoLuong_BH ELSE CASE WHEN A.DOITUONGBN = 3 THEN @SoLuong_VP ELSE @SoLuong_Khac END END < 10 THEN  \t\t\t\t\tDMDONGIA.DG_610 \t\t\t\tELSE \t\t\t\t\tCASE WHEN CASE WHEN A.DOITUONGBN = 1 THEN @SoLuong_BH ELSE CASE WHEN A.DOITUONGBN = 3 THEN @SoLuong_VP ELSE @SoLuong_Khac END END >= 10 THEN  \t\t\t\t\t\tDMDONGIA.DG_T10 \t\t\t\t\tEND \t\t\t\tEND \t\t\tEND \t\tELSE  \t\t\tCASE WHEN CASE WHEN A.DOITUONGBN = 1 THEN @SoLuong_BH ELSE CASE WHEN A.DOITUONGBN = 3 THEN @SoLuong_VP ELSE @SoLuong_Khac END END <= 5 THEN  \t\t\t\tDMDONGIA.DG_15 \t\t\tELSE \t\t\t\tCASE WHEN CASE WHEN A.DOITUONGBN = 1 THEN @SoLuong_BH ELSE CASE WHEN A.DOITUONGBN = 3 THEN @SoLuong_VP ELSE @SoLuong_Khac END END >= 6 AND CASE WHEN A.DOITUONGBN = 1 THEN @SoLuong_BH ELSE CASE WHEN A.DOITUONGBN = 3 THEN @SoLuong_VP ELSE @SoLuong_Khac END END < 10 THEN  \t\t\t\t\tDMDONGIA.DG_610 \t\t\t\tELSE \t\t\t\t\tCASE WHEN CASE WHEN A.DOITUONGBN = 1 THEN @SoLuong_BH ELSE CASE WHEN A.DOITUONGBN = 3 THEN @SoLuong_VP ELSE @SoLuong_Khac END END >= 10 AND CASE WHEN A.DOITUONGBN = 1 THEN @SoLuong_BH ELSE CASE WHEN A.DOITUONGBN = 3 THEN @SoLuong_VP ELSE @SoLuong_Khac END END < 20 THEN  \t\t\t\t\t\tDMDONGIA.DG_1020 \t\t\t\t\tELSE \t\t\t\t\t\tCASE WHEN CASE WHEN A.DOITUONGBN = 1 THEN @SoLuong_BH ELSE CASE WHEN A.DOITUONGBN = 3 THEN @SoLuong_VP ELSE @SoLuong_Khac END END >= 20 AND CASE WHEN A.DOITUONGBN = 1 THEN @SoLuong_BH ELSE CASE WHEN A.DOITUONGBN = 3 THEN @SoLuong_VP ELSE @SoLuong_Khac END END < 30 THEN  \t\t\t\t\t\t\tDMDONGIA.DG_T20 \t\t\t\t\t\tELSE \t\t\t\t\t\t\tDMDONGIA.DG_T1T \t\t\t\t\t\tEND \t\t\t\t\tEND \t\t\t\tEND \t\t\tEND \t\tEND \tEND END as DonGia, CASE WHEN F.KHOI = 0 THEN \tCASE WHEN F.KHOI = 0 AND (DMDONGIA.MADICHVU IS NULL OR A.TINHPHI = 1) THEN  \t\tSum(SoLuong * SoThang * (case when a.tinhphi = 0 then a.DonGia else 0 end)) \tELSE  \t\tCASE WHEN DMDONGIA.is_CoDonGiaDB = 1 THEN \t\t\tCASE WHEN CASE WHEN A.DOITUONGBN = 1 THEN @SoLuong_BH ELSE CASE WHEN A.DOITUONGBN = 3 THEN @SoLuong_VP ELSE @SoLuong_Khac END END <= 5 THEN  \t\t\t\tDMDONGIA.DG_15 \t\t\tELSE \t\t\t\tCASE WHEN CASE WHEN A.DOITUONGBN = 1 THEN @SoLuong_BH ELSE CASE WHEN A.DOITUONGBN = 3 THEN @SoLuong_VP ELSE @SoLuong_Khac END END >= 6 AND CASE WHEN A.DOITUONGBN = 1 THEN @SoLuong_BH ELSE CASE WHEN A.DOITUONGBN = 3 THEN @SoLuong_VP ELSE @SoLuong_Khac END END <= 10 THEN  \t\t\t\t\tDMDONGIA.DG_610 \t\t\t\tELSE \t\t\t\t\tCASE WHEN CASE WHEN A.DOITUONGBN = 1 THEN @SoLuong_BH ELSE CASE WHEN A.DOITUONGBN = 3 THEN @SoLuong_VP ELSE @SoLuong_Khac END END > 10 THEN  \t\t\t\t\t\tDMDONGIA.DG_T10 \t\t\t\t\tEND \t\t\t\tEND \t\t\tEND\t\tELSE  \t\t\tCASE WHEN CASE WHEN A.DOITUONGBN = 1 THEN @SoLuong_BH ELSE CASE WHEN A.DOITUONGBN = 3 THEN @SoLuong_VP ELSE @SoLuong_Khac END END <= 5 THEN  \t\t\t\tDMDONGIA.DG_15 \t\t\tELSE \t\t\t\tCASE WHEN CASE WHEN A.DOITUONGBN = 1 THEN @SoLuong_BH ELSE CASE WHEN A.DOITUONGBN = 3 THEN @SoLuong_VP ELSE @SoLuong_Khac END END >= 6 AND CASE WHEN A.DOITUONGBN = 1 THEN @SoLuong_BH ELSE CASE WHEN A.DOITUONGBN = 3 THEN @SoLuong_VP ELSE @SoLuong_Khac END END <= 10 THEN  \t\t\t\t\tDMDONGIA.DG_610 \t\t\t\tELSE \t\t\t\t\tCASE WHEN CASE WHEN A.DOITUONGBN = 1 THEN @SoLuong_BH ELSE CASE WHEN A.DOITUONGBN = 3 THEN @SoLuong_VP ELSE @SoLuong_Khac END END > 10 AND CASE WHEN A.DOITUONGBN = 1 THEN @SoLuong_BH ELSE CASE WHEN A.DOITUONGBN = 3 THEN @SoLuong_VP ELSE @SoLuong_Khac END END <= 20 THEN  \t\t\t\t\t\tDMDONGIA.DG_1020 \t\t\t\t\tELSE \t\t\t\t\t\tCASE WHEN CASE WHEN A.DOITUONGBN = 1 THEN @SoLuong_BH ELSE CASE WHEN A.DOITUONGBN = 3 THEN @SoLuong_VP ELSE @SoLuong_Khac END END > 20 AND CASE WHEN A.DOITUONGBN = 1 THEN @SoLuong_BH ELSE CASE WHEN A.DOITUONGBN = 3 THEN @SoLuong_VP ELSE @SoLuong_Khac END END <= 30 THEN  \t\t\t\t\t\t\tDMDONGIA.DG_T20 \t\t\t\t\t\tELSE \t\t\t\t\t\t\tDMDONGIA.DG_T1T \t\t\t\t\t\tEND \t\t\t\t\tEND \t\t\t\tEND \t\t\tEND \t\tEND \tEND  ELSE \tCASE WHEN F.KHOI = 1 AND (DMDONGIA.MADICHVU IS NULL OR A.TINHPHI = 1) THEN  \t\tSum(SoLuong * SoThang * (case when a.tinhphi = 0 then a.DonGia else 0 end)) \tELSE  \t\tCASE WHEN DMDONGIA.is_CoDonGiaDB = 1 THEN \t\t\tCASE WHEN CASE WHEN A.DOITUONGBN = 1 THEN @SoLuong_BH ELSE CASE WHEN A.DOITUONGBN = 3 THEN @SoLuong_VP ELSE @SoLuong_Khac END END <= 5 THEN  \t\t\t\tDMDONGIA.DG_15 \t\t\tELSE \t\t\t\tCASE WHEN CASE WHEN A.DOITUONGBN = 1 THEN @SoLuong_BH ELSE CASE WHEN A.DOITUONGBN = 3 THEN @SoLuong_VP ELSE @SoLuong_Khac END END >= 6 AND CASE WHEN A.DOITUONGBN = 1 THEN @SoLuong_BH ELSE CASE WHEN A.DOITUONGBN = 3 THEN @SoLuong_VP ELSE @SoLuong_Khac END END <= 10 THEN  \t\t\t\t\tDMDONGIA.DG_610 \t\t\t\tELSE \t\t\t\t\tCASE WHEN CASE WHEN A.DOITUONGBN = 1 THEN @SoLuong_BH ELSE CASE WHEN A.DOITUONGBN = 3 THEN @SoLuong_VP ELSE @SoLuong_Khac END END > 10 THEN  \t\t\t\t\t\tDMDONGIA.DG_T10 \t\t\t\t\tEND \t\t\t\tEND \t\t\tEND\t\tELSE  \t\t\tCASE WHEN CASE WHEN A.DOITUONGBN = 1 THEN @SoLuong_BH ELSE CASE WHEN A.DOITUONGBN = 3 THEN @SoLuong_VP ELSE @SoLuong_Khac END END <= 5 THEN  \t\t\t\tDMDONGIA.DG_15 \t\t\tELSE \t\t\t\tCASE WHEN CASE WHEN A.DOITUONGBN = 1 THEN @SoLuong_BH ELSE CASE WHEN A.DOITUONGBN = 3 THEN @SoLuong_VP ELSE @SoLuong_Khac END END >= 6 AND CASE WHEN A.DOITUONGBN = 1 THEN @SoLuong_BH ELSE CASE WHEN A.DOITUONGBN = 3 THEN @SoLuong_VP ELSE @SoLuong_Khac END END <= 10 THEN  \t\t\t\t\tDMDONGIA.DG_610 \t\t\t\tELSE \t\t\t\t\tCASE WHEN CASE WHEN A.DOITUONGBN = 1 THEN @SoLuong_BH ELSE CASE WHEN A.DOITUONGBN = 3 THEN @SoLuong_VP ELSE @SoLuong_Khac END END > 10 AND CASE WHEN A.DOITUONGBN = 1 THEN @SoLuong_BH ELSE CASE WHEN A.DOITUONGBN = 3 THEN @SoLuong_VP ELSE @SoLuong_Khac END END <= 20 THEN  \t\t\t\t\t\tDMDONGIA.DG_1020 \t\t\t\t\tELSE \t\t\t\t\t\tCASE WHEN CASE WHEN A.DOITUONGBN = 1 THEN @SoLuong_BH ELSE CASE WHEN A.DOITUONGBN = 3 THEN @SoLuong_VP ELSE @SoLuong_Khac END END > 20 AND CASE WHEN A.DOITUONGBN = 1 THEN @SoLuong_BH ELSE CASE WHEN A.DOITUONGBN = 3 THEN @SoLuong_VP ELSE @SoLuong_Khac END END <= 30 THEN  \t\t\t\t\t\t\tDMDONGIA.DG_T20 \t\t\t\t\t\tELSE \t\t\t\t\t\t\tDMDONGIA.DG_T1T \t\t\t\t\t\tEND \t\t\t\t\tEND \t\t\t\tEND \t\t\tEND \t\tEND \tEND  END  as ThanhTien, a.TyLe FROM "
                +" (((((PHIEUDIEUTRI_CHITIET a INNER JOIN INPHIEUTHANHTOAN c  ON c.MaDichVu=a.MaDichVu )   "
                +" INNER JOIN DMLOAIDICHVU b ON b.MaLoaiDichVu= a.LoaiDichVu)  "
                +" INNER JOIN DMDOITUONGBN d ON a.DoiTuongBN = d.MaDT)   "
                +" INNER JOIN BENHNHAN_PHIEUDIEUTRI e ON a.SoPhieu=e.SoPhieu AND e.MaVaoVien='{0}')  "
                +" INNER JOIN BENHNHAN_KHOA bk ON bk.MaVaoVien = e.MaVaoVien and BK.LANCHUYENKHOA = (SELECT MAX(LANCHUYENKHOA) FROM BENHNHAN_KHOA WHERE (BENHNHAN_KHOA.MAVAOVIEN = E.MAVAOVIEN) AND (BENHNHAN_KHOA.MAKHOA = E.MAKHOA or LEFT(e.SoPhieu,2)='CD'  or LEFT(e.SoPhieu,2)='DT' or LEFT(e.SoPhieu,2)='PK') ) )"
                +" ",(this.fgDanhSach.GetData(this.fgDanhSach.Row, "DoiTuong").ToString() == "Bảo hiểm y tế")? " INNER JOIN (Select madichvu from DMDICHVU where is_chenh = 0 or is_Chenh is null   or (is_chenh = 1 and DongiaBHYT <> 0)) DMDVKHONGCHENH ON DMDVKHONGCHENH.madichvu = a.madichvu " : " INNER JOIN (Select madichvu from DMDICHVU) DMDVKHONGCHENH ON DMDVKHONGCHENH.madichvu = a.madichvu "," "
                +" LEFT JOIN DMKHOAPHONG f ON e.MaKhoa= f.MaKhoa   "
                +" LEFT JOIN BENHNHAN_DOITUONG ON BENHNHAN_DOITUONG.DOITUONG = A.DOITUONGBN AND BENHNHAN_DOITUONG.MAVAOVIEN = '{0}' AND BENHNHAN_DOITUONG.LANCHUYENDT = A.LanChuyenDT "
                +" INNER JOIN BENHNHAN_CHITIET ON BENHNHAN_CHITIET.MAVAOVIEN = E.MAVAOVIEN "
                +" INNER JOIN BENHNHAN_KHOA KHOA_DAU ON KHOA_DAU.MAVAOVIEN = E.MAVAOVIEN AND KHOA_DAU.LANCHUYENKHOA = 0 "
                +" LEFT JOIN DMKHOAPHONG KD ON KHOA_DAU.MaKhoa = KD.MaKHoa "
                +" LEFT JOIN DMDONGIA ON DMDONGIA.MAKHOA = E.MAKHOA AND DMDONGIA.MADICHVU = A.MADICHVU WHERE ", str3, "  a.LoaiDichVu <> 'E02' and ((LEFT(a.SoPhieu,2) <> 'CD'  AND e.MaKhoa = '{1}') or (LEFT(a.SoPhieu ,2) ='CD' AND KHoa_Dau.MaKhoa = '{1}') or (LEFT(a.SoPhieu ,2) ='DT' AND KHoa_Dau.MaKhoa = '{1}') or (LEFT(a.SoPhieu ,2) ='PK' AND KHoa_Dau.MaKhoa = '{1}' and e.MaVaoVien > '1603'))   "
                +" GROUP BY BENHNHAN_DOITUONG.LanChuyenDT,BENHNHAN_DOITUONG.Tuyen, a.DoiTuongBN,d.TenDT,a.LoaiDichVu,b.TenLoaiDichVu,a.MaDichVu,"
                +" c.TenDichVu,c.DVT,a.DonGia,a.tinhphi,f.Khoi, BENHNHAN_CHITIET.DARAVIEN,DMDONGIA.MADICHVU,DMDONGIA.DG_15,DMDONGIA.DG_610,"
                +" DMDONGIA.DG_1020,DMDONGIA.DG_T20, DMDONGIA.DG_T1T,DMDONGIA.DG_T10,DMDONGIA.is_CoDonGiaDB, BK.LANCHUYENKHOA,F.TENKHOA,BK.NGAYCHUYEN,"
                +" BENHNHAN_CHITIET.NGAYRAVIEN,KD.TENKHOA,A.DATHANHTOAN,e.MaKhoa,KHOA_DAU.NGAYCHUYEN,BENHNHAN_DOITUONG.SOTHE,BENHNHAN_DOITUONG.MADOITUONGBHXH,"
                +" BENHNHAN_DOITUONG.MANOICAP,BENHNHAN_DOITUONG.GtriTu,BENHNHAN_DOITUONG.GTriDen,BENHNHAN_DOITUONG.TenBHYTCap, c.MaLoaiDichVu_BHYT,"
                +" c.MaLoaiThuoc_BHYT,c.TenLoaiThuoc_BHYT,c.ThuTuIn_Thuoc, a.TyLe) AA "
                +" RIGHT JOIN ( SELECT a.*,b.MaVaoVien,b.LanChuyenKhoa,b.MAICD_BC,C.LanChuyenDT,C.DoiTuong AS DOITUONGBN,c.tuyen,C.MADOITUONGBHXH,  "
                +" CASE WHEN c.DoiTuong = 1 THEN c.MADOITUONGBHXH + c.SOTHE ELSE '' END AS SOTHE,c.MaNoiCap, CASE WHEN c.DoiTuong = 1 "
                +" THEN c.GTriTu ELSE null END AS GTriTu," 
                +" CASE WHEN c.DoiTuong = 1 and kb.MienChiTraTrongNam !=1 THEN dbo.GetMaQuyenLoi(C.MADOITUONGBHXH,C.SOTHE,case when (C.Ngaychuyen >= '01/01/2015' and C.Ngaychuyen < '02/02/2015' ) then C.GtriTu else C.Ngaychuyen end) when kb.MienChiTraTrongNam =1 and kb.ThoiDiemMienChiTraTrongNam is not null then 1 else  0  END AS MaQuyenLoi,  "
                +" CASE WHEN c.DoiTuong = 1 THEN c.GTriDen ELSE null END AS GTriDen, "
                +" c.TenBHYTCap, DMKHOAPHONG.TenKhoa,b.MaKhoa FROM NAMDINH_SYSDB.dbo.DMLOAIDICHVU_BHYT a "
                +" INNER JOIN dbo.BENHNHAN_KHOA b ON 1= 1 AND B.MAVAOVIEN='{0}' "
                +" INNER JOIN dbo.BENHNHAN_DOITUONG C ON b.MaVaoVien = C.MaVaoVien  "
                +" inner join dbo.BENHNHAN_CHITIET ct on ct.MaVaoVien = c.MaVaoVien"
                +" inner join NAMDINH_KHAMBENH.dbo.tblKHAMBENH kb on kb.MaKhambenh = ct.MaKhamBenh"
                +" LEFT JOIN DMKHOAPHONG ON DMKHOAPHONG.MAKHOA = B.MAKHOA "
                +" WHERE A.LOAI IN (0,2) and b.LanChuyenKhoa = ", lanChuyenKhoaHT, " AND ((B.MAKHOA = 'NV1212') OR (B.MAKHOA <>'NV1212' )) ) m "
                +" ON m.MaLoaiDichVu_BHYT = AA.MaLoaiDichVu_BHYT AND M.LANCHUYENKHOA = AA.LANCHUYENKHOA AND M.LANCHUYENDT = AA.LANCHUYENDT "
                +" LEFT JOIN NAMDINH_SYSDB.DBO.DMQUYENLOI F ON F.MaQuyenLoi = m.MaQuyenLoi  "
                +" ORDER BY LanChuyenKhoa,LanChuyenDT,M.ThuTuIn,aa.ThuTuIn_Thuoc" }), new object[] { maVaoVien, code, data, ngayLV });
                rptTongKetChiPhi_NhomTheoLoaiBHYT ibhyt = new rptTongKetChiPhi_NhomTheoLoaiBHYT(maVaoVien, this.fgDanhSach[this.fgDanhSach.Row, 2].ToString(), this.fgDanhSach[this.fgDanhSach.Row, 3].ToString(), this.fgDanhSach[this.fgDanhSach.Row, 4].ToString(), this.fgDanhSach[this.fgDanhSach.Row, 5].ToString(), this.fgDanhSach.GetData(this.fgDanhSach.Row, 6), this.fgDanhSach[this.fgDanhSach.Row, "DiaChi"].ToString(), this.fgDanhSach[this.fgDanhSach.Row, "HanTheTu"].ToString(), this.fgDanhSach[this.fgDanhSach.Row, "HanTheDen"].ToString(), this.fgDanhSach[this.fgDanhSach.Row, "SoTheBHYT"].ToString(), this.fgDanhSach[this.fgDanhSach.Row, "NoiCapThe"].ToString(), this.fgDanhSach[this.fgDanhSach.Row, "Buong"].ToString(), this.fgDanhSach[this.fgDanhSach.Row, "Giuong"].ToString(), this.fgDanhSach.GetData(this.fgDanhSach.Row, "NgayRaVien"), this.fgDanhSach[this.fgDanhSach.Row, "ChanDoan"].ToString(), this.fgDanhSach.GetDataDisplay(this.fgDanhSach.Row, "NoiGioiThieu"), this.fgDanhSach.GetDataDisplay(this.fgDanhSach.Row, "SoHSBA"), code, this.fgDanhSach.GetDataDisplay(this.fgDanhSach.Row, "BA_NOINGOAI"), this.fgDanhSach.GetDataDisplay(this.fgDanhSach.Row, "CapCuu"));
                SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
                DataTable dataTable = new DataTable("BaoCao");
                DataTable table2 = new DataTable("Res");
                adapter.Fill(dataTable);
                table2 = dataTable.Copy();
                int num3 = -1;
                int num4 = -1;
                foreach (DataRow row in dataTable.Rows)
                {
                    if ((num3 != int.Parse(row["LanChuyenDT"].ToString())) || (num4 != int.Parse(row["LanChuyenKhoa"].ToString())))
                    {
                        DataRow row2;
                        num3 = int.Parse(row["LanChuyenDT"].ToString());
                        num4 = int.Parse(row["LanChuyenKhoa"].ToString());
                        DataSet set = new DataSet();
                        set.Merge(dataTable.Select(string.Format("LanChuyenDT={0} And LanChuyenKhoa = {1} And MALOAITHUOC_BHYT = '{2}' And MALOAIDICHVU_BHYT = 'THUOC'", num3, num4, "NGDM_BHYT")));
                        if (((set.Tables.Count <= 0) || ((set.Tables.Count > 0) && (set.Tables[0].Rows.Count <= 0))) && (row["DoiTuongBN"].ToString() == "1"))
                        {
                            row2 = table2.NewRow();
                            row2["LanChuyenDT"] = num3;
                            row2["LanChuyenKhoa"] = num4;
                            row2["MaLoaiDichVu_BHYT"] = "THUOC";
                            row2["TenLoaiDichVu_BHYT"] = "Thuốc, dịch truyền";
                            row2["MALOAITHUOC_BHYT"] = "NGDM_BHYT";
                            row2["DOITUONGBN"] = row["DOITUONGBN"].ToString();
                            row2["ThuTuIn_Thuoc"] = "2";
                            row2["ThuTuIn_DichVu"] = "8";
                            row2["TENLOAITHUOC_BHYT"] = "Ngo\x00e0i danh mục BHYT";
                            table2.Rows.InsertAt(row2, 0);
                        }
                        set.Clear();
                        set.Merge(dataTable.Select(string.Format("LanChuyenDT={0} And LanChuyenKhoa = {1} And MALOAITHUOC_BHYT = '{2}' And MALOAIDICHVU_BHYT = 'THUOC'", num3, num4, "TDM_BHYT")));
                        if (((set.Tables.Count <= 0) || ((set.Tables.Count > 0) && (set.Tables[0].Rows.Count <= 0))) && (row["DoiTuongBN"].ToString() == "1"))
                        {
                            row2 = table2.NewRow();
                            row2["LanChuyenDT"] = num3;
                            row2["LanChuyenKhoa"] = num4;
                            row2["MaLoaiDichVu_BHYT"] = "THUOC";
                            row2["TenLoaiDichVu_BHYT"] = "Thuốc, dịch truyền";
                            row2["MALOAITHUOC_BHYT"] = "TDM_BHYT";
                            row2["DOITUONGBN"] = row["DOITUONGBN"].ToString();
                            row2["ThuTuIn_Thuoc"] = "1";
                            row2["ThuTuIn_DichVu"] = "8";
                            row2["TENLOAITHUOC_BHYT"] = "Trong danh mục BHYT";
                            table2.Rows.InsertAt(row2, 0);
                        }
                        set.Clear();
                        set.Merge(dataTable.Select(string.Format("LanChuyenDT={0} And LanChuyenKhoa = {1} And MALOAITHUOC_BHYT = '{2}' And MALOAIDICHVU_BHYT = 'THUOC'", num3, num4, "UTNG_BHYT")));
                        if (((set.Tables.Count <= 0) || ((set.Tables.Count > 0) && (set.Tables[0].Rows.Count <= 0))) && (row["DoiTuongBN"].ToString() == "1"))
                        {
                            row2 = table2.NewRow();
                            row2["LanChuyenDT"] = num3;
                            row2["LanChuyenKhoa"] = num4;
                            row2["MaLoaiDichVu_BHYT"] = "THUOC";
                            row2["TenLoaiDichVu_BHYT"] = "Thuốc, dịch truyền";
                            row2["MALOAITHUOC_BHYT"] = "UTNG_BHYT";
                            row2["DOITUONGBN"] = row["DOITUONGBN"].ToString();
                            row2["ThuTuIn_Thuoc"] = "3";
                            row2["ThuTuIn_DichVu"] = "8";
                            row2["TENLOAITHUOC_BHYT"] = "Thuốc điều trị ung thư, chống thải gh\x00e9p ngo\x00e0i danh mục BHYT";
                            table2.Rows.InsertAt(row2, 0);
                        }
                        set.Clear();
                        set.Merge(dataTable.Select(string.Format("LanChuyenDT={0} And LanChuyenKhoa = {1} And MALOAITHUOC_BHYT = '{2}' And MALOAIDICHVU_BHYT = 'VATTU'", num3, num4, "NGDM_BHYT")));
                        if (((set.Tables.Count <= 0) || ((set.Tables.Count > 0) && (set.Tables[0].Rows.Count <= 0))) && (row["DoiTuongBN"].ToString() == "1"))
                        {
                            row2 = table2.NewRow();
                            row2["LanChuyenDT"] = num3;
                            row2["LanChuyenKhoa"] = num4;
                            row2["MaLoaiDichVu_BHYT"] = "VATTU";
                            row2["TenLoaiDichVu_BHYT"] = "Vật tư y tế";
                            row2["MALOAITHUOC_BHYT"] = "NGDM_BHYT";
                            row2["DOITUONGBN"] = row["DOITUONGBN"].ToString();
                            row2["ThuTuIn_Thuoc"] = "2";
                            row2["ThuTuIn_DichVu"] = "9";
                            row2["TENLOAITHUOC_BHYT"] = "Ngo\x00e0i danh mục BHYT";
                            table2.Rows.InsertAt(row2, 0);
                        }
                        set.Clear();
                        set.Merge(dataTable.Select(string.Format("LanChuyenDT={0} And LanChuyenKhoa = {1} And MALOAITHUOC_BHYT = '{2}' And MALOAIDICHVU_BHYT = 'VATTU'", num3, num4, "TDM_BHYT")));
                        if (((set.Tables.Count <= 0) || ((set.Tables.Count > 0) && (set.Tables[0].Rows.Count <= 0))) && (row["DoiTuongBN"].ToString() == "1"))
                        {
                            row2 = table2.NewRow();
                            row2["LanChuyenDT"] = num3;
                            row2["LanChuyenKhoa"] = num4;
                            row2["MaLoaiDichVu_BHYT"] = "VATTU";
                            row2["TenLoaiDichVu_BHYT"] = "Vật tư y tế";
                            row2["MALOAITHUOC_BHYT"] = "TDM_BHYT";
                            row2["DOITUONGBN"] = row["DOITUONGBN"].ToString();
                            row2["ThuTuIn_Thuoc"] = "1";
                            row2["ThuTuIn_DichVu"] = "9";
                            row2["TENLOAITHUOC_BHYT"] = "Trong danh mục BHYT";
                            table2.Rows.InsertAt(row2, 0);
                        }
                    }
                }
                DataSet set2 = new DataSet();
                //set2.Merge(table2.Select("MADICHVU NOT IN ('B01042','B01043') OR MADICHVU IS NULL"));
                //set2.Merge(table2.Select("MADICHVU NOT IN ('B01042','B01043','B01004','B01049','C51015','C50081','C51018','C51063','VT-VATU-0526','C57263','C57264') OR MADICHVU IS NULL"));
                //set2.Merge(table2.Select("MADICHVU NOT IN ('B01042','B01043','B01004','B01049') OR MADICHVU IS NULL"));
                set2.Merge(table2.Select("(MADICHVU NOT IS NULL)"));
                if (set2.Tables.Count > 0)
                {
                    DataView defaultView = set2.Tables[0].DefaultView;
                    defaultView.Sort = "LanChuyenKhoa,LanChuyenDT,ThuTuIn_DichVu,ThuTuIn_Thuoc";
                    DataTable table3 = defaultView.ToTable();
                    ibhyt.DataSource = table3;
                    ibhyt.Run();
                }
                this.arvMain.Document = ibhyt.Document;
                selectCommand.Dispose();
                Global.nowait();
                DataTable table4 = new DataTable("Copy");
                table4 = table2.Copy();
                DataSet set3 = new DataSet();
                if (this.fgDanhSach.GetData(this.fgDanhSach.Row, "DoiTuong").ToString() == "Bảo hiểm y tế")
                {
                    //rptTongKetChiPhi phi = new rptTongKetChiPhi(maVaoVien, this.fgDanhSach[this.fgDanhSach.Row, 2].ToString(), this.fgDanhSach[this.fgDanhSach.Row, 3].ToString(), this.fgDanhSach[this.fgDanhSach.Row, 4].ToString(), this.fgDanhSach[this.fgDanhSach.Row, 5].ToString(), this.fgDanhSach.GetData(this.fgDanhSach.Row, 6), this.fgDanhSach[this.fgDanhSach.Row, "DiaChi"].ToString(), this.fgDanhSach[this.fgDanhSach.Row, "HanTheTu"].ToString(), this.fgDanhSach[this.fgDanhSach.Row, "HanTheDen"].ToString(), this.fgDanhSach[this.fgDanhSach.Row, "SoTheBHYT"].ToString(), this.fgDanhSach[this.fgDanhSach.Row, "NoiCapThe"].ToString(), this.fgDanhSach[this.fgDanhSach.Row, "Buong"].ToString(), this.fgDanhSach[this.fgDanhSach.Row, "Giuong"].ToString(), this.fgDanhSach.GetData(this.fgDanhSach.Row, "NgayRaVien"), this.fgDanhSach[this.fgDanhSach.Row, "ChanDoan"].ToString(), this.fgDanhSach.GetDataDisplay(this.fgDanhSach.Row, "NoiGioiThieu"), this.fgDanhSach.GetDataDisplay(this.fgDanhSach.Row, "SoHSBA"));
                    rptTongKetChiPhi_Mau02 phi = new rptTongKetChiPhi_Mau02(maVaoVien, this.fgDanhSach[this.fgDanhSach.Row, 2].ToString(), this.fgDanhSach[this.fgDanhSach.Row, 3].ToString(), this.fgDanhSach[this.fgDanhSach.Row, 4].ToString(), this.fgDanhSach[this.fgDanhSach.Row, 5].ToString(), this.fgDanhSach.GetData(this.fgDanhSach.Row, 6), this.fgDanhSach[this.fgDanhSach.Row, "DiaChi"].ToString(), this.fgDanhSach[this.fgDanhSach.Row, "HanTheTu"].ToString(), this.fgDanhSach[this.fgDanhSach.Row, "HanTheDen"].ToString(), this.fgDanhSach[this.fgDanhSach.Row, "SoTheBHYT"].ToString(), this.fgDanhSach[this.fgDanhSach.Row, "NoiCapThe"].ToString(), this.fgDanhSach[this.fgDanhSach.Row, "Buong"].ToString(), this.fgDanhSach[this.fgDanhSach.Row, "Giuong"].ToString(), this.fgDanhSach.GetData(this.fgDanhSach.Row, "NgayRaVien"), this.fgDanhSach[this.fgDanhSach.Row, "ChanDoan"].ToString(), this.fgDanhSach.GetDataDisplay(this.fgDanhSach.Row, "NoiGioiThieu"), this.fgDanhSach.GetDataDisplay(this.fgDanhSach.Row, "SoHSBA"), code, this.fgDanhSach.GetDataDisplay(this.fgDanhSach.Row, "BA_NOINGOAI"), this.fgDanhSach.GetDataDisplay(this.fgDanhSach.Row, "Tuyen"));
                    //set3.Merge(table4.Select("MADICHVU = 'B01042' Or MADICHVU = 'B01043'  Or MADICHVU = 'B01004' Or MADICHVU = 'B01049' Or MADICHVU = 'C51015' Or MADICHVU = 'C50081' Or MADICHVU = 'C51018' Or MADICHVU = 'C51063' or MADICHVU = 'VT-VATU-0526' or MADICHVU = 'C57263' or MADICHVU = 'C57264'"));
                    //set3.Merge(table4.Select(" Madichvu in (Select Madichvu From DMDICHVU where is_chenh = 1) or Madichvu = 'B01042' or Madichvu = 'B01043' or Madichvu = 'B01004' or Madichvu = 'B01049'"));
                    selectCommand.CommandText = "exec Fill_ChiPhi_ChenhLech @Mavaovien, @Makhoa, @lanChuyenKhoaHT  ,@NgayChuyen  ";
                    selectCommand.Parameters.Clear();
                    selectCommand.Parameters.AddWithValue("@Mavaovien", maVaoVien);
                    selectCommand.Parameters.AddWithValue("@Makhoa", code);
                    selectCommand.Parameters.AddWithValue("@lanChuyenKhoaHT", lanChuyenKhoaHT);
                    selectCommand.Parameters.AddWithValue("@NgayChuyen", time3);
                    SqlDataAdapter adap = new SqlDataAdapter(selectCommand);
                    adap.Fill(set3);
                    if (set3.Tables.Count > 0)
                    {
                        if (set3.Tables[0].Rows.Count > 0)
                        {
                            phi.DataSource = set3.Tables[0];
                            phi.Show();
                        }
                    }
                }
                reader.Close();
                Global.nowait();
            }
        }

        private void fgDanhSach_AfterDragColumn(object sender, C1.Win.C1FlexGrid.DragRowColEventArgs e)
        {

        }
    }
}