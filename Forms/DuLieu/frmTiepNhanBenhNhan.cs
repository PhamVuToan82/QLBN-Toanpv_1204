using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GlobalModuls;
using System.Data.SqlClient;
namespace NamDinh_QLBN.Forms.DuLieu
{
    public partial class frmTiepNhanBenhNhan : Form
    {
        string MaVaoVien;
        int tuyen;
        int CapCuu;
        private class DMBuongGiuong
        {
            int ID_Buong;
            int ID_Giuong;
            string TenBuong;
            string TenGiuong;
        }
        private DMBuongGiuong[] arrBuongGiuong;
        public frmTiepNhanBenhNhan()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void Load_CacDM()
        {
            cmbGioiTinh.AddItem("0;Nữ");
            cmbGioiTinh.AddItem("1;Nam");
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
            dr.Close();
            SQLCmd.CommandText = "SELECT * FROM DMDOITUONGBN";
            dr = SQLCmd.ExecuteReader();
            cmbDoiTuong.Tag = "0";
            cmbDoiTuong.ClearItems();
            while (dr.Read())
            {
                cmbDoiTuong.AddItem(string.Format("{0};{1}", dr["MaDT"], dr["TenDT"]));
            }
            cmbDoiTuong.SelectedIndex = -1;
            cmbDoiTuong.Tag = "1";
            dr.Close();
            SQLCmd.CommandText = "SELECT * FROM DMTRUCTIEPVAO";
            dr = SQLCmd.ExecuteReader();
            cmbTrucTiepVao.ClearItems();
            while (dr.Read())
            {
                cmbTrucTiepVao.AddItem(string.Format("{0};{1}", dr["MaTTV"], dr["TenTTV"]));
            }
            dr.Close();
            SQLCmd.CommandText = "SELECT * FROM DMNOIGIOITHIEU";
            dr = SQLCmd.ExecuteReader();
            cmbNoiGioiThieu.ClearItems();
            while (dr.Read())
            {
                cmbNoiGioiThieu.AddItem(string.Format("{0};{1}", dr["MaNoiGT"], dr["TenNoiGT"]));
            }
            dr.Close();
            SQLCmd.CommandText = "SELECT * FROM DMDANTOC ORDER BY TENDT";
            dr = SQLCmd.ExecuteReader();
            cmbDanToc.Tag = "0";
            cmbDanToc.ClearItems();
            while (dr.Read())
            {
                cmbDanToc.AddItem(string.Format("{0};{1}", dr["MADT"], dr["TenDT"]));
            }
            cmbDanToc.SelectedIndex = 25;
            cmbDanToc.SelectedIndex = cmbDanToc.FindStringExact("25", 0, 0);
            cmbDanToc.Tag = "1";
            dr.Close();
            SQLCmd.CommandText = "SELECT * FROM Khoa_Nhom where MaKhoa='" + Global.GetCode(cmbKhoa) + "' ORDER BY TenNhom";
            dr = SQLCmd.ExecuteReader();
            cmbNhom.Tag = "0";
            cmbNhom.ClearItems();
            while (dr.Read())
            {
                cmbNhom.AddItem(string.Format("{0};{1}", dr["MANhom"], dr["TenNhom"]));
            }
            if (cmbNhom.ListCount > 0) cmbNhom.SelectedIndex = 0;
            cmbNhom.Tag = "1";
            dr.Close();
            SQLCmd.CommandText = string.Format("select A.MaDichvu,A.TenDichvu,A.Dongia,A.DongiaBHYT,A.DonGiaTuNguyen,A.TT37, A.TyLe from NAMDINH_SYSDB.DBO.DMDICHVU A INNER JOIN NAMDINH_SYSDB.DBO.DMDICHVU_KHOA B ON A.MaDichvu = B.MaDichvu WHERE LoaiDichvu = 'B01' AND B.MaKhoa in {0} and DongiaBHYT != 0", Global.glbKhoa_CapNhat);
            dr = SQLCmd.ExecuteReader();
            this.cmbLoaiGiuong.ClearItems();
            while (dr.Read())
            {
                this.cmbLoaiGiuong.AddItem(string.Format("{0};{1}",
                    dr["MaDichvu"],
                    dr["TenDichvu"]));
            }
            dr.Close();
            cmbLoaiGiuong.Tag = "1";
            cmbLoaiGiuong.SelectedIndex = -1;

            SQLCmd.CommandText = "Select * from dmbacsy where SoChungChiHanhNghe is not null and SoChungChiHanhNghe <> '' and Khongsudung = 0 and MaChucVu <=5 and MaChucVu <> '' and makhoa  in " + Global.glbKhoa_CapNhat + " order by Thutu";
            dr = SQLCmd.ExecuteReader();
            this.cmbBacSyDT.ClearItems();
            while (dr.Read())
            {
                this.cmbBacSyDT.AddItem(string.Format("{0};{1}", dr["MaBS"], dr["TenBS"]));
            }
            cmbBacSyDT.SelectedIndex = -1;
            dr.Close();
            SQLCmd.Dispose();
            //Tuyen
            cmbTuyen.ClearItems();
            cmbTuyen.AddItem(String.Format("0;Đúng tuyến"));
            cmbTuyen.AddItem(String.Format("1;----------"));
            cmbTuyen.AddItem(String.Format("2;Cấp Cứu"));
            cmbTuyen.AddItem(String.Format("3;Trái tuyến"));
            //Benh an noi va ngoai tru
            cmbLoaiBA.ClearItems();
            cmbLoaiBA.AddItem(String.Format("0;Bệnh án nội trú"));
            cmbLoaiBA.AddItem(String.Format("1;Bệnh án ngoại trú"));
            cmbLoaiBA.AddItem(String.Format("2;Bệnh án nội trú ban ngày"));

        }
        private void frmTiepNhanBenhNhan_Load(object sender, EventArgs e)
        {
            fg.ClipSeparators = "|;";
            Load_CacDM();
            Clear_Data();
            cmbKhoa_TextChanged(sender, e);
            NgayGiuongBenh();

        }

        private void cmbKhoa_TextChanged(object sender, EventArgs e)
        {
            if (raChoVaoKhoa.Checked)
            {
                cmdCNTD.Visible = false;
                cmdTiepNhan.Visible = true;
            }
            else
            {
                cmdCNTD.Visible = true;
                cmdTiepNhan.Visible = false;
            }
            if (cmbKhoa.Tag.ToString() == "0") return;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
            if (raChoVaoKhoa.Checked)
            {
                SQLCmd.CommandText = String.Format("set dateformat dmy select * from("
                    + " SELECT bn.MaBenhNhan,bn.TenBenhNhan,bn.NamSinh,Case bn.GioiTinh When 0 then N'Nữ' else N'Nam' end as GioiTinh,"
                    + " KP.TENKHOA,kb.ThoigianDangky as 'NgayVaoKham',0 as NoiNgoai,kp.MaKhoa as MaKhoaCD,kb.MaKhamBenh, 0 AS Is_Covid"
                    + " FROM NamDinh_KhamBenh.DBO.tblBENHNHAN bn INNER JOIN [NamDinh_KhamBenh].DBO.TBLKHAMBENH kb ON bn.MaBenhNhan=kb.MaBenhNhan"
                    + " INNER JOIN NamDinh_KhamBenh.DBO.tblKHAMBENH_KQDVKHAM kq ON kb.MaKhamBenh=kq.MaKhamBenh "
                    + " INNER JOIN DMKHOAPHONG KP ON KP.MAKHOA = kq.KHOATHUCHIEN  LEFT JOIN DMLOAI_BA ON DMLOAI_BA.MAKHOA = '{0}' "
                    + " WHERE NhapVien_Khoa='{0}' and kq.HuongGQ=5 AND DaNhapVien=0 and kq.TuChoiTiepNhan = 0 "
                    + " UNION ALL "
                    + " SELECT bn2.MABENHNHAN,bn2.HOTEN AS TENBENHNHAN,bn2.NAMSINH,Case bn2.GioiTinh When 0 then N'Nữ' else N'Nam' end as GioiTinh,"
                    + " pk.TENKHOA,bnct.NGAYKHAM AS NGAYVAOKHAM,1 as NoiNgoai,pk.MaKhoa as MaKhoaCD,bnct.MaVaoVien as MaKhamBenh, bnct.Is_Covid"
                    + " FROM BENHNHAN bn2  INNER JOIN BENHNHAN_CHITIET bnct ON bn2.MABENHNHAN = bnct.MABENHNHAN  "
                    + " INNER JOIN VIEWKHOAHIENTAI khoaht ON khoaht.MAVAOVIEN = bnct.MAVAOVIEN "
                    + " Inner join BenhNhan_Khoa bnk on bnk.LanChuyenKhoa=khoaht.MaxLan and bnk.MaKhoa=khoaht.MaKhoa and khoaht.MaVaoVien=bnk.maVaoVien"
                    + " INNER JOIN DMKHOAPHONG pk ON pk.MAKHOA = bnk.MAKHOACD"
                    + " WHERE khoaht.MAKHOA = '{0}'  and bnct.TRANGTHAI =2"
                    + " )x order by TenBenhNhan", Global.GetCode(cmbKhoa));
            }
            else
            {
                SQLCmd.CommandText = string.Format("set dateformat dmy SELECT a.MaBenhNhan,HoTen as TenBenhNhan,NamSinh,Case a.GioiTinh When 0 then N'Nữ' else N'Nam' end as GioiTinh, "
                + " '' as TenKhoa,NgayKham as NgayVaoKham,1 as NoiNgoai,'' as MaKhoaCD,'' as MaKhamBenh,b.Is_Covid FROM BENHNHAN a INNER JOIN BENHNHAN_CHITIET b ON a.MaBenhNhan=b.MaBenhNhan "
                + " INNER JOIN ViewKHOAHIENTAI c ON b.MaVaoVien=c.MaVaoVien "
                + "  Where MaKhoa ='{0}' AND TrangThai =1 AND c.vDaraVien= 0 "
                + " order by hoten"
                , GlobalModuls.Global.GetCode(cmbKhoa));
            }
            //textBox1.Text = SQLCmd.CommandText ;
            SQLCmd.CommandTimeout = 0;
            System.Data.SqlClient.SqlDataReader dr = SQLCmd.ExecuteReader();
            fg.Tag = "0";
            Global.BindDataReaderToFlex(dr, fg);
            dr.Close();
            for (int i = 1; i < fg.Rows.Count; i++)
            {
                fg[i, 0] = i;
            }
            fg.Tag = "1";
            fg.Cols["NamSinh"].Format = "####";
            SQLCmd.CommandText = "SELECT * FROM DMBUONGBENH WHERE sudung = 1 and MaKhoa='" + Global.GetCode(cmbKhoa) + "'";
            dr = SQLCmd.ExecuteReader();

            cmbBuong.Tag = "0";
            cmbBuong.ClearItems();
            while (dr.Read())
            {
                cmbBuong.AddItem(string.Format("{0};{1}", dr["ID_Buong"], dr["TenBuong"]));
            }
            dr.Close();
            cmbBuong.Tag = "1";
            cmbBuong.SelectedIndex = -1;
            fg.Cols[1].Visible = fg.Cols[7].Visible = fg.Cols[8].Visible = fg.Cols[9].Visible = false;
            fg[0, 2] = "Họ tên";
            fg[0, 3] = "Năm sinh";
            fg[0, 4] = "Giới tính";
            fg[0, 6] = "Ngày vào khám";
            if (raChoVaoKhoa.Checked)
            {
                fg[0, 5] = "Khoa chuyển đến";
            }
            else
            {
                fg.Cols[5].Visible = false;
            }
            SQLCmd.Dispose();
            NgayGiuongBenh();
        }

        private void txtXaHuyenTinh_Enter(object sender, EventArgs e)
        {
        }

        private void txtXaHuyenTinh_TextChanged(object sender, EventArgs e)
        {

        }

        private void fgHanhChinh_Leave(object sender, EventArgs e)
        {

        }

        private void fgHanhChinh_AfterSelChange(object sender, C1.Win.C1FlexGrid.RangeEventArgs e)
        {

        }

        private void txtXaHuyenTinh_Leave(object sender, EventArgs e)
        {
        }

        private void txtXaHuyenTinh_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.Tien_ich.frmTraCuuICD fr = new NamDinh_QLBN.Forms.Tien_ich.frmTraCuuICD();
            if (fr.ShowDialog() == DialogResult.OK)
            {
                txtMaICD_BenhChinh.Text = fr._MaICD;
                txtTenICD_KhoaDieuTri_BC.Text = fr._TenICD;
            }
        }

        private void NgayGiuongBenh()
        {
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
            System.Data.SqlClient.SqlDataReader dr;
            DataTable dt = new DataTable();
            try
            {
                SQLCmd.CommandText = string.Format("SELECT A.ID_Buong, b.ID_Giuong, A.MaKhoa, a.TenBuong, b.TenGiuong, sl, b.MaGiuongYT FROM NAMDINH_QLBN.DBO.DMBUONGBENH A INNER JOIN NAMDINH_QLBN.DBO.DMGIUONGBENH B ON A.ID_Buong = B.ID_Buong AND A.MaKhoa = B.MaKhoa AND A.MaKhoa = '{0}' AND SunDung = 1 and a.SuDung = 1"
                                    + " LEFT JOIN("
                                    + " select c.ID_Buong, c.MaKhoa, d.ID_Giuong, COUNT(a.MaVaoVien) as sl from NAMDINH_QLBN.dbo.BENHNHAN_CHITIET a inner join NAMDINH_QLBN.dbo.ViewKHOAHIENTAI b on a.MaVaoVien = b.MaVaoVien"
                                    + " LEFT JOIN NAMDINH_QLBN.DBO.DMBUONGBENH C ON C.ID_Buong = A.Buong AND C.MaKhoa = B.MaKhoa and c.sudung = 1"
                                    + " LEFT JOIN NAMDINH_QLBN.DBO.DMGIUONGBENH D ON D.MaKhoa = C.MaKhoa  AND D.ID_Buong = A.Buong AND D.ID_Giuong = A.Giuong"
                                    + " where a.DaRaVien = 0  AND B.MaKhoa = '{0}' group by c.ID_Buong, c.MaKhoa, d.ID_Giuong) XX on xx.ID_Buong = a.ID_Buong and xx.ID_Giuong = b.ID_Giuong"
                                    + " and xx.MaKhoa = a.MaKhoa"
                                    + " order by TenBuong, TenGiuong", GlobalModuls.Global.GetCode(cmbKhoa));
                dt.Load(SQLCmd.ExecuteReader());
                fgBuongGiuong.DataSource = dt;
                for (int i = 0; i < 4; i++)
                {
                    fgBuongGiuong.Cols[i].Visible = false;
                }
                Format_Grid();
            }
            catch
            {
                MessageBox.Show("Xem lại danh mục buồng, giường của bệnh nhân!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Format_Grid()
        {
            fgBuongGiuong.Redraw = false;
            fgBuongGiuong.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.Clear, 0, 0, 0);
            fgBuongGiuong.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.Sum, 1, 1, fgBuongGiuong.Cols["sl"].Index, "{0}");
            fgBuongGiuong.AutoSizeRows();
            fgBuongGiuong.Redraw = true;
        }
        private void LayThongTin()
        {
            try
            {
                if (fg.Tag.ToString() == "0" || fg.Row < 1) return;
                Clear_Data();
                string buong = "", giuong = "";
                System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
                System.Data.SqlClient.SqlDataReader dr;
                if (raChoVaoKhoa.Checked)
                {
                    if (fg.GetDataDisplay(fg.Row, "NoiNgoai") == "0")
                    {
                        SQLCmd.CommandText = string.Format("set dateformat dmy SELECT bn.MaBenhNhan,bn.TenBenhNhan,bn.NamSinh,bn.NgaySinh,bn.ThangSinh,bn.GioiTinh,"
                        + " KP.TENKHOA, kb.MaKhamBenh,TenDT,kb.DoiTuong,SoTheBHYT,DoiTuongThe,NoiDangKyKCBBD, HanTheBHYT_Tu,HanTheBHYT_Den,DiaChi,"
                        + " dm.TenNgheNghiep as NgheNghiep,Lienhe,kq.ChanDoan As ChanDoan_KKB,kb.ChanDoanNGT,BenhChinhICD As ICD_KKB"
                        + " ,kb.ThoigianDangky as 'NgayVaoKham','' as NgayVaoVien,'' AS SOHSBA,'' as Buong,'' as Giuong,'' as TenTinh, '' AS MaTinh_TP,'' as ChanDoan_KhoaDT,"
                        + " 1 as MaNhom,kb.Tuyen,Case kb.DoiTuong when 1 then 'BHXH '+ kb.NoiCapTheBHYT else ''  end as NoiCapThe,"
                        + " kb.noicongtac,KP.MaKhoa as MaKhoaCD,kb.MaKhamBenh as MaKhamBenh1,"
                        + " CASE WHEN DMLOAI_BA.MAKHOA IS NULL THEN 0 ELSE 1 END AS LOAIBA,kq.BenhchinhICD AS BC, kq.BenhphuICD1 AS BP,'' AS TENBC,'' AS TENBP,BN.NgaySinh, bn.ThangSinh, CASE WHEN Tuyen = 2 THEN 1 else 0  end as CapCuu,0 as Is_Covid "
                        + " FROM NamDinh_KhamBenh.DBO.tblBENHNHAN bn INNER JOIN [NamDinh_KhamBenh].DBO.TBLKHAMBENH kb ON bn.MaBenhNhan=kb.MaBenhNhan   "
                        + " INNER JOIN NamDinh_KhamBenh.DBO.tblKHAMBENH_KQDVKHAM kq ON kb.MaKhamBenh=kq.MaKhamBenh  "
                        + " INNER JOIN DMDOITUONGBN dt ON kb.DoiTuong=dt.MaDT  left join NamDinh_SysDB.dbo.DMNGHENGHIEP dm on dm.MaNgheNghiep = NgheNghiep  "
                        + " INNER JOIN DMKHOAPHONG KP ON KP.MAKHOA = kq.KHOATHUCHIEN  LEFT JOIN DMLOAI_BA ON DMLOAI_BA.MAKHOA = 'NV1107' "
                        + " WHERE bn.MaBenhNhan='{0}' and NhapVien_Khoa='{1}' and kq.HuongGQ=5 AND DaNhapVien=0 and kq.TuChoiTiepNhan = 0 and kb.datinhphi = 0"
                        , fg[fg.Row, "MaBenhNhan"].ToString(), Global.GetCode(cmbKhoa));
                    }
                    else
                    {
                        SQLCmd.CommandText = string.Format("set dateformat dmy SELECT bn2.MABENHNHAN,bn2.HOTEN AS TENBENHNHAN,bn2.NAMSINH,bn2.GioiTinh,"
                        + " pk.TENKHOA,bnct.MAVAOVIEN AS MAKHAMBENH,DMDTTHE_BHYT.TENDT,dtht.DOITUONG,dtht.SOTHE AS SOTHEBHYT,dtht.MADOITUONGBHXH AS DOITUONGTHE,"
                        + " dtht.MANOICAP AS NOIDANGKYKCBBD, dtht.GTRITU AS HANTHEBHYT_TU,dtht.GTRIDEN AS HANTHEBHYT_DEN,bnct.DIACHI,bnct.NGHENGHIEP,"
                        + " bnct.LIENHE,bnct.CHANDOAN_KKB,bnct.ChanDoan_NoiChuyenDen as ChanDoanNGT,bnct.ICD_KKB,kb.ThoigianDangky as NgayVaoKham,bnk.NGAYCHUYEN AS NgayVaoVien, bnct.SOHSBA,'' AS BUONG,"
                        + " '' AS GIUONG,'' AS TENTINH,bnct.MATINH_TP,bnct.CHANDOAN_KHOADT,1 as MaNhom,dtht.Tuyen,dtht.TenBHYTCap as NoiCapThe,"
                        + " bnct.NOICONGTAC,pk.MAKHOA as MaKhoaCD,bnct.MAKHAMBENH AS MAKHAMBENH1,bnct.BA_NOINGOAI AS LOAIBA,bnk.MAICD_BC AS BC,bnk.MAICD_BP_1 AS BP,'' AS TENBC,'' AS TENBP,BN2.NgaySinh, bn2.ThangSinh,dtht.CapCuu,bnct.Is_Covid "
                        + " FROM BENHNHAN bn2  INNER JOIN BENHNHAN_CHITIET bnct"
                        + " ON bn2.MABENHNHAN = bnct.MABENHNHAN  INNER JOIN VIEWKHOAHIENTAI khoaht ON khoaht.MAVAOVIEN = bnct.MAVAOVIEN "
                        + " INNER JOIN BENHNHAN_KHOA bnk ON bnk.MAVAOVIEN = bnct.MAVAOVIEN AND bnk.LANCHUYENKHOA = khoaht.MAXLAN - 1 "
                        + " INNER JOIN DMKHOAPHONG pk ON pk.MAKHOA = khoaht.MAKHOA"
                        + " INNER JOIN VIEWDOITUONGHIENTAI dtht ON dtht.MAVAOVIEN = bnct.MAVAOVIEN "
                        + " INNER JOIN DMDOITUONGBN dt2 ON dt2.MADT = dtht.DOITUONG "
                        + " INNER JOIN NamDinh_KhamBenh.DBO.TBLKHAMBENH kb on kb.makhambenh = bnct.makhambenh"
                        + " left JOIN DMDTTHE_BHYT ON DMDTTHE_BHYT.MADT = dtht.MaDoituongBHXH "
                        + " WHERE bn2.MaBenhNhan='{0}' AND khoaht.MAKHOA = '{1}' and TRANGTHAI =2"
                         , fg[fg.Row, "MaBenhNhan"].ToString(), Global.GetCode(cmbKhoa));
                    }
                }
                else
                {
                    SQLCmd.CommandText = string.Format("set dateformat dmy Select a.MaBenhNhan,HoTen as TenBenhNhan,NamSinh,a.GioiTinh, b.MaVaoVien as MaKhamBenh,TenDT,d.DoiTuong,b.SoTheBHYT,MaDTBHYT as DoiTuongThe,MaNoiCapBHYT as NoiDangKyKCBBD, b.HanTheBHYT_Tu,b.HanTheBHYT_Den,b.DiaChi,b.NgheNghiep as NgheNghiep,b.Lienhe,ChanDoan_KKB,ICD_KKB,b.ChanDoan_NoiChuyenDen as ChanDoanNGT, kb.ThoigianDangky as NgayVaoKham,c.NgayChuyen as NgayVaoVien,SOHSBA,isNull(Buong,0) as Buong,isNull(Giuong,0) as Giuong, TenTinh,MaTinh_TP,c.chandoan as ChanDoan_KhoaDT,MaNhom,d.Tuyen,d.TenBHYTCap as NoiCapThe,B.NOICONGTAC,'' as MaKhamBenh1,B.BA_NOINGOAI AS LOAIBA, ICD_BC.CICD10 AS BC,MAICD_BP_1 AS BP,ICD_BC.VVIET AS TENBC,ICD_BP.VVIET AS TENBP, a.NgaySinh,a.ThangSinh,d.CapCuu, b.Is_Covid "
                                        + " FROM (((BENHNHAN a INNER JOIN BENHNHAN_CHITIET b ON a.MaBenhNhan=b.MaBenhNhan)"
                                        + " INNER JOIN ViewKHOAHIENTAI c ON b.MaVaoVien=c.MaVaoVien)"
                                        + " INNER JOIN ViewDOITUONGHIENTAI d ON b.MaVaoVien=d.MaVaoVien)"
                                        + " INNER JOIN NamDinh_KhamBenh.DBO.TBLKHAMBENH kb on kb.makhambenh = b.makhambenh"
                                        + " INNER JOIN DMDOITUONGBN e ON d.DoiTuong=e.MaDT "
                                        + " LEFT JOIN DMTINH_TP ON DMTINH_TP.MATINH = MaTinh_TP "
                                        + " LEFT JOIN DMICD10 ICD_BC ON ICD_BC.CICD10 = C.MAICD_BC"
                                        + " LEFT JOIN DMICD10 ICD_BP ON ICD_BP.CICD10 = C.MAICD_BP"
                                        + " Where a.MaBenhNhan='{0}' and MaKhoa ='{1}' AND TrangThai =1 AND c.vDaraVien= 0 order by hoten", fg[fg.Row, "MaBenhNhan"].ToString(), GlobalModuls.Global.GetCode(cmbKhoa));
                }
                SQLCmd.CommandTimeout = 0;
                dr = SQLCmd.ExecuteReader();
                //string buong = "", giuong = "";
                while (dr.Read())
                {
                    txtMaBenhNhan.Text = dr["MaBenhNhan"].ToString();
                    lblMaKhamBenh.Text = dr["MaKhamBenh"].ToString();
                    txtHoTen.Text = dr["TenBenhNhan"].ToString();
                    Global.SetCmb(cmbGioiTinh, dr["GioiTinh"].ToString());
                    txtNamSinh.Value = decimal.Parse(dr["NamSinh"].ToString());
                    Global.SetCmb(cmbDoiTuong, dr["DoiTuong"].ToString());
                    txtSoTheBHYT.Text = dr["SoTheBHYT"].ToString().Trim();
                    txtMaDTBHYT.Text = dr["DoiTuongThe"].ToString().Trim();
                    txtMaNoiCapBHYT.Text = dr["NoiDangKyKCBBD"].ToString().Trim();
                    txtHanTheTu.Value = dr["HanTheBHYT_Tu"];
                    txtHanTheDen.Value = dr["HanTheBHYT_Den"];
                    txtDiaChi.Text = dr["DiaChi"].ToString();
                    txtNgheNghiep.Text = dr["NgheNghiep"].ToString();
                    txtDiaChiLH.Text = dr["Lienhe"].ToString();
                    txtChanDoan_KKB.Text = dr["ChanDoan_KKB"].ToString();
                    txtChanDoan_NoiChuyenDen.Text = dr["ChanDoanNGT"].ToString(); // noi gioi thieu bang tblkhambenh
                    txtChanDoan_KhoaDieuTri.Text = dr["ChanDoan_KhoaDT"].ToString();
                    lblICD_KKB.Text = dr["ICD_KKB"].ToString();
                    txtMaBenhAn.Text = dr["SOHSBA"].ToString();
                    txtNoiCapBHYT.Text = dr["NoiCapThe"].ToString();
                    cmbNhom.SelectedIndex = cmbNhom.FindStringExact(dr["MaNhom"].ToString(), 0, 0);
                    //cmbTuyen.SelectedIndex = cmbTuyen.FindStringExact(dr["tuyen"].ToString(), 0, 0);
                    if (DateTime.Parse(dr["NgayVaoKham"].ToString()) >= DateTime.Parse("01/01/2021") && cmbDoiTuong.Text == "Bảo hiểm y tế")
                    {
                        if (dr["tuyen"].ToString() == "1" && dr["CapCuu"].ToString() == "0")
                        {
                            cmbTuyen.SelectedIndex = 3;
                        }
                        if (dr["CapCuu"].ToString() == "1")
                        {
                            cmbTuyen.SelectedIndex = 2;
                        }
                        if (dr["tuyen"].ToString() == "0" && dr["CapCuu"].ToString() == "0")
                        {
                            cmbTuyen.SelectedIndex = 0;
                        }
                        if (dr["tuyen"].ToString() == "3" && dr["CapCuu"].ToString() == "0")
                        {
                            cmbTuyen.SelectedIndex = 3;
                        }
                    }
                    else
                    {
                        if (dr["CapCuu"].ToString() == "1")
                        {
                            cmbTuyen.SelectedIndex = 2;
                        }
                        else
                        {
                            cmbTuyen.SelectedIndex = cmbTuyen.FindStringExact(dr["tuyen"].ToString(), 0, 0);
                        }
                    }
                    txtNoiLamViec.Text = dr["NoiCongTac"].ToString();
                    txtMaKhamBenh.Text = dr["MaKhamBenh1"].ToString();
                    cmbLoaiBA.SelectedIndex = cmbLoaiBA.FindStringExact(dr["LoaiBA"].ToString(), 0, 0);
                    lblLoaiBACU.Tag = dr["LoaiBA"].ToString();
                    txtMaICD_BenhChinh.Text = dr["BC"].ToString().ToUpper();
                    txtMaICD_BenhPhu.Text = dr["BP"].ToString().ToUpper();
                    txtTenICD_KhoaDieuTri_BC.Text = dr["TenBC"].ToString();
                    txtTenICD_KhoaDieuTri_BP.Text = dr["TenBP"].ToString();
                    lblMaKhoa.Text = cmbKhoa.Text;
                    lblMaKhoa.Tag = Global.GetCode(cmbKhoa);
                    txtNgayVaoVien.Value = dr["NgayVaoKham"];
                    if (raChoVaoKhoa.Checked)
                    {
                        txtNgayVaoKhoa.Value = Global.NgayLV;
                    }
                    else
                    {
                        txtNgayVaoKhoa.Value = dr["NgayVaoVien"];
                    }
                    cmbNoiGioiThieu.SelectedIndex = 1;
                    cmbTrucTiepVao.SelectedIndex = 1;
                    
                    buong = dr["Buong"].ToString(); giuong = dr["Giuong"].ToString();

                    if (dr["Is_Covid"].ToString() == "1")
                    {
                        chkBenhNhan_Covid.Checked = true;
                    }
                    else
                    {
                        chkBenhNhan_Covid.Checked = false;
                    }
                } // het while
                dr.Close();
                Global.SetCmb(cmbBuong, buong);
                Global.SetCmb(cmbGiuong, giuong);
            }// het try
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void LayMaVaoVien()
        {
            String Str = "";
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
            //System.Data.SqlClient.SqlTransaction trn = Global.ConnectSQL.BeginTransaction();
            //SQLCmd.Transaction = trn;
            try
            {
                Str = String.Format("DECLARE @s_ngay varchar(6) "
                    + " set @s_ngay= Right(Convert(nvarchar(8),'{0:yyyyMMdd}',112),6)"
                    + " exec dbo.LayMaVaoVien1 @s_ngay,@MaVV output ", Global.NgayLV);
                SqlParameter MaVV = new SqlParameter("@MaVV", SqlDbType.VarChar, 11);
                MaVV.Direction = ParameterDirection.Output;
                SQLCmd.Parameters.Add(MaVV);
                SQLCmd.CommandText = Str;
                SQLCmd.CommandTimeout = 0;
                SQLCmd.ExecuteNonQuery();
                MaVaoVien = MaVV.Value.ToString();
                //trn.Commit();
            }
            catch (Exception ex)
            {
                //trn.Rollback();
                MaVaoVien = "";
            }
            finally
            {
                SQLCmd.Dispose();
                //trn.Dispose();
            }
        }


        private void cmdTiepNhan_Click(object sender, EventArgs e)
        {
            if (cmbBacSyDT.SelectedIndex == -1)
            {
                MessageBox.Show("Chọn Bác sỹ Điều trị!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbBacSyDT.Focus();
                return;
            }

            if (cmbBuong.SelectedIndex == -1)
            {
                MessageBox.Show("Nhập số buồng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbBuong.Focus();
                return;
            }
            if (cmbGiuong.SelectedIndex == -1)
            {
                MessageBox.Show("Nhập số giường!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbGiuong.Focus();
                return;
            }
            for (int row = 0; row < fgBuongGiuong.Rows.Count; row++)
            {
                //if (this.fgBuongGiuong.Rows[row].IsNode) return;
                if (!this.fgBuongGiuong.Rows[row].IsNode && Global.GetCode(cmbBuong) == fgBuongGiuong[row, "ID_Buong"].ToString() && Global.GetCode(cmbGiuong) == fgBuongGiuong[row, "ID_Giuong"].ToString())
                {
                    if (fgBuongGiuong[row, "sl"].ToString()!= "")
                    MessageBox.Show("Hiện tại đã có bệnh nhân");
                }
            }

            if (cmbLoaiGiuong.SelectedIndex == -1 && Global.GetCode(cmbKhoa) != "NV120101")
            {
                MessageBox.Show("Nhập chi phí loại giường bệnh!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbLoaiGiuong.Focus();
                return;
            }

            string Benhchinh_benhphu = "";
            if (txtMaICD_BenhChinh.Text != "" && txtMaICD_BenhPhu.Text == "")
            {
                Benhchinh_benhphu = txtMaICD_BenhChinh.Text;
            }
            if (txtMaICD_BenhChinh.Text != "" && txtMaICD_BenhPhu.Text != "")
            {
                Benhchinh_benhphu = txtMaICD_BenhChinh.Text + ";" + txtMaICD_BenhPhu.Text;
            }
            if (txtMaICD_BenhChinh.Text == "" && txtMaICD_BenhPhu.Text != "")
            {
                Benhchinh_benhphu = txtMaICD_BenhPhu.Text;
            }
            if (txtMaICD_BenhChinh.Text == "" && txtMaICD_BenhPhu.Text == "")
            {
                Benhchinh_benhphu = "";
            }

            if (!Validate_BN()) return;

            if (DateTime.Parse(fg.GetDataDisplay(fg.Row, "NgayVaoKham").ToString()) >= DateTime.Parse("01/01/2021") && cmbDoiTuong.Text == "Bảo hiểm y tế")
            {
                CapCuu = 0;
                if (cmbTuyen.SelectedIndex == 1)
                {
                   tuyen = 3;
                   CapCuu = 0;

                }
                if (cmbTuyen.SelectedIndex == 3)
                {
                    tuyen = 3;
                    CapCuu = 0;
                }
                if (cmbTuyen.SelectedIndex == 2)
                {
                    tuyen = 0;
                    CapCuu = 1;
                }

                if (cmbTuyen.SelectedIndex == 0)
                {
                    tuyen = 0;
                    CapCuu = 0;
                }
            }
            else
            {
                if (cmbTuyen.SelectedIndex == 2)
                {
                    tuyen = 0;
                    CapCuu = 1;
                }
                else
                {
                    tuyen = cmbTuyen.SelectedIndex;
                    CapCuu = 0;
                }
            }
            LayMaVaoVien();
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
            System.Data.SqlClient.SqlTransaction trn = Global.ConnectSQL.BeginTransaction();
            System.Data.SqlClient.SqlDataReader dr;
            SQLCmd.Transaction = trn;
            SQLCmd.CommandTimeout = 0;
            try
            {
                SQLCmd.CommandText = string.Format("select * from benhnhan_chitiet "
                    + " inner join viewkhoahientai v on v.mavaovien = benhnhan_chitiet.mavaovien"
                    + " inner join dmkhoaphong d on d.makhoa = v.makhoa"
                    + " where mabenhnhan = '{0}' and (daravien = 0 and trangthai = 1) and v.MaKhoa <> 'NV120101'", txtMaBenhNhan.Text.Trim());
                dr = SQLCmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        MessageBox.Show("Bệnh nhân đang được điều trị trong khoa '" + dr["TenKhoa"].ToString() + "'. Xem lại", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    dr.Close();
                    return;
                }
                dr.Close();

                if (lblMaKhamBenh.Text.Length == 10)
                {
                    SQLCmd.CommandText = string.Format("select MaDichVu from NAMDINH_KHAMBENH.dbo.tblKHAMBENH_DICHVU where MaKhambenh = '{0}' and MaDichvu in ('C03891','C03892','C03893','C03894','C03895') union all select MachiPhi as MaDichVu from NAMDINH_KHAMBENH.dbo.tblCHIPHI_DICHVU where MaKhambenh = '{0}'  and MaChiPhi in ('C03891','C03892','C03893','C03894','C03895')", lblMaKhamBenh.Text.Trim());
                    dr = SQLCmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            MessageBox.Show("Bệnh nhân thực hiện dịch vụ tiêm truyền Ngoại trú không tiếp nhận được '", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        dr.Close();
                        return;
                    }
                    dr.Close();

                }
                SQLCmd.CommandText = string.Format("If EXISTS (SELECT MaBenhNhan FROM BENHNHAN WHERE MaBenhNhan='{0}') "
                                                + " UPDATE BENHNHAN SET HoTen=N'{1}',NgaySinh={2},ThangSinh={3},NamSinh={4},GioiTinh={5},MaDanToc={6} WHERE MaBenhNhan='{0}'"
                                                + " ELSE "
                                                + " INSERT INTO BENHNHAN (MaBenhNhan,HoTen,NgaySinh,ThangSinh,NamSinh,GioiTinh,MaDanToc) VALUES ('{0}',N'{1}',{2},{3},{4},{5},{6})",
                                                txtMaBenhNhan.Text, txtHoTen.Text.Replace("'", "''"),
                                                txtNgaySinh.Value, txtThangSinh.Value, txtNamSinh.Value, Global.GetCode(cmbGioiTinh),
                                                (cmbDanToc.SelectedIndex == -1) ? ("null") : ("'" + Global.GetCode(cmbDanToc) + "'"));
                SQLCmd.ExecuteNonQuery();
                String TNgay, DNgay;
                if (txtHanTheTu.ValueIsDbNull == false && txtHanTheTu.Value.ToString() == "01/01/1900")
                {
                    TNgay = DNgay = "Null";
                }
                else
                {
                    if (txtHanTheTu.ValueIsDbNull == true)
                    {
                        TNgay = DNgay = "Null";
                    }
                    else
                    {
                        TNgay = String.Format("'{0:dd/MM/yyyy}'", txtHanTheTu.Value);
                        DNgay = String.Format("'{0:dd/MM/yyyy}'", txtHanTheDen.Value);
                    }
                }
                if (fg.GetDataDisplay(fg.Row, "NoiNgoai") == "0")
                {
                    //truong hop tiep nhan tu phong kham
                    SQLCmd.CommandText = string.Format("DECLARE @MaxSoHSBA nVarChar(6)"
                        + " DECLARE @Nam int"
                        + " if '" + Global.GetCode(cmbLoaiBA) + "'='0' "
                        + " BEGIN"
                        + " SELECT @MaxSoHSBA  = SOHSBA,@Nam = Nam FROM SOHSBA"
                        + " IF @Nam <> Year(GETDATE())"
                        + " BEGIN"
                        + " UPDATE SOHSBA SET SOHSBA = '000000',NAM = YEAR(GETDATE())"
                        + " SET @MaxSoHSBA = '000000'"
                        + " END"
                        + "  	DECLARE @Ma int"
                        + "       	SET @Ma=Cast(@MaxSoHSBA  As Int)+1"
                        + "       	SET @MaxSoHSBA = Cast(@Ma as nvarChar(6))"
                        + " 	WHILE Len(@MaxSoHSBA)< 6"
                        + "     BEGIN"
                        + "              SET @MaxSoHSBA='0' +@MaxSoHSBA"
                        + " 	END"
                        + " 	UPDATE SOHSBA SET SOHSBA = @MAXSOHSBA"
                        + " END "
                        + " ELSE "
                        + " BEGIN "
                        + " SELECT @MaxSoHSBA  = SOHSBA_NGOAI,@Nam = Nam FROM SOHSBA"
                        + " IF @Nam <> Year(GETDATE())"
                        + " BEGIN"
                        + " UPDATE SOHSBA SET SOHSBA_NGOAI = '000000',NAM = YEAR(GETDATE())"
                        + " SET @MaxSoHSBA = '000000'"
                        + " END"
                        + "  	DECLARE @Ma_NGOAI int"
                        + "       	SET @Ma_NGOAI=Cast(isnull(@MaxSoHSBA,0)  As Int)+1"
                        + "       	SET @MaxSoHSBA = Cast(@Ma_NGOAI as nvarChar(6))"
                        + " 	WHILE Len(@MaxSoHSBA)< 6"
                        + "     BEGIN"
                        + "              SET @MaxSoHSBA='0' +@MaxSoHSBA"
                        + " 	END"
                        + " 	UPDATE SOHSBA SET SOHSBA_NGOAI = @MAXSOHSBA"
                        + " END "
                        + " INSERT INTO BENHNHAN_CHITIET (MaBenhNhan,MaVaoVien,SoHSBA,Buong,Giuong,SoTheBHYT,MaDTBHYT,MaNoiCapBHYT,HanTheBHYT_Tu,HanTheBHYT_Den,"
                        + "DiaChi,MaTinh_TP,NgheNghiep,LienHe,NgayVaoVien,TrucTiepVao,NoiGioiThieu,VaoVienLan,ChanDoan_NoiChuyenDen,ICD_NoiChuyenDen,ChanDoan_KKB,ICD_KKB,ChanDoan_KhoaDT,ICD_KhoaDT,MaKhamBenh,TrangThai,NgayKham,MaNhom,NoiCongTac,BA_NOINGOAI,Is_Covid) VALUES "
                        + "('{0}','{1}',@MaxSoHSBA,{2},{3},'{4}','{5}','{6}',{7},{8},N'{9}',"
                        + "'{10}',N'{11}',N'{12}','{13:dd/MM/yyyy HH:mm}',{14},{15},{16},N'{17}','{18}',N'{19}','{20}',N'{21}','{22}','{23}',1,'{24:dd/MM/yyyy HH:mm}',{25},N'{26}',{27},{28}) ",
                        txtMaBenhNhan.Text, MaVaoVien,
                        (cmbBuong.SelectedIndex == -1) ? ("null") : (Global.GetCode(cmbBuong)),
                        (cmbGiuong.SelectedIndex == -1) ? ("Null") : (Global.GetCode(cmbGiuong)),
                        txtSoTheBHYT.Text, txtMaDTBHYT.Text, txtMaNoiCapBHYT.Text, TNgay, DNgay, txtDiaChi.Text, "",
                        txtNgheNghiep.Text, txtDiaChiLH.Text, txtNgayVaoKhoa.Value,
                        (cmbTrucTiepVao.SelectedIndex == -1) ? ("null") : (Global.GetCode(cmbTrucTiepVao)),
                        (cmbNoiGioiThieu.SelectedIndex == -1) ? ("null") : (Global.GetCode(cmbNoiGioiThieu)),
                        txtLanVaoVien.Value, txtChanDoan_NoiChuyenDen.Text, lblICD_NoiChuyenDen.Text,
                        txtChanDoan_KKB.Text, lblICD_KKB.Text, txtChanDoan_KhoaDieuTri.Text, lblICD_KhoaDieuTri.Text, lblMaKhamBenh.Text, txtNgayVaoVien.Value, Global.GetCode(cmbNhom), txtNoiLamViec.Text.Trim(), Global.GetCode(cmbLoaiBA), chkBenhNhan_Covid.Checked == false ? 0 : 1);
                    SQLCmd.ExecuteNonQuery();
                    SQLCmd.CommandText = string.Format("INSERT INTO BENHNHAN_DOITUONG (MaVaoVien,LanChuyenDT,NgayChuyen,DoiTuong,"
                    + "SoThe,MaDoituongBHXH,MaNoiCap,GtriTu,GtriDen,Tuyen,TenBHYTCap,CapCuu) VALUES ('{0}',0,'{1:dd/MM/yyyy HH:mm}','{2}',"
                    + "'{3}','{4}','{5}',{6},{7},{8},N'{9}',{10})",
                    MaVaoVien,
                    txtNgayVaoKhoa.Value,
                    Global.GetCode(cmbDoiTuong),
                    txtSoTheBHYT.Text.Trim(),
                    txtMaDTBHYT.Text,
                    txtMaNoiCapBHYT.Text,
                    TNgay, DNgay,
                    tuyen,
                    //  cmbTuyen.SelectedIndex,
                    txtNoiCapBHYT.Text.Trim(), CapCuu);
                    SQLCmd.ExecuteNonQuery();
                    SQLCmd.CommandText = string.Format("INSERT INTO BENHNHAN_KHOA (MaVaoVien,LanChuyenKhoa,NgayChuyen,MaKhoa,ChanDoan,user_name,MaKhoaCD,MaICD_BC,MAICD_BP_1,IDBuong_Khoa, IDGiuong_Khoa) "
                        + " VALUES ('{0}',0,'{1:dd/MM/yyyy HH:mm}','{2}',N'{3}',N'{4}','{5}','{6}','{7}',{8},{9})",
                        MaVaoVien,
                        txtNgayVaoKhoa.Value,
                        Global.GetCode(cmbKhoa),
                        txtChanDoan_KhoaDieuTri.Text.Trim(),
                        Global.glbUName,
                        fg.GetDataDisplay(fg.Row, "MaKhoaCD"),
                        "",
                        Benhchinh_benhphu, Global.GetCode(cmbBuong), Global.GetCode(cmbGiuong));
                    SQLCmd.ExecuteNonQuery();

                    string text = "";
                    SQLCmd.CommandText = string.Format("select dbo.LaySoPhieu(Right(Convert(nvarchar(8),'{0:yyyyMMdd}',112),6)) As SoPhieu", this.txtNgayVaoVien.Value);
                    text = SQLCmd.ExecuteScalar().ToString();
                    SQLCmd.CommandText = string.Format("INSERT INTO BENHNHAN_KHOA_NGAYGIUONG_CT(MaVaoVien, LanChuyenKhoa, NgayChuyen, MaKhoa, NgayBatDau, Loaidichvu, MaDichVu, ID_Buong, ID_Giuong,Sophieu,Lan,DoiTuong,TrangThaiBN,TrangThaiGiuong,BacSyDT)"
                            + " values('{0}',{1},'{2:dd/MM/yyyy HH:mm}',{3},'{4:dd/MM/yyyy HH:mm}','{5}','{6}',{7},{8},'{9}',{10},{11},{12},{13},'{14}') ",
                             new object[] { MaVaoVien, 0, txtNgayVaoKhoa.Value, Global.glbKhoa_CapNhat, txtNgayVaoKhoa.Value, "B01", (this.cmbLoaiGiuong.SelectedIndex == -1) ? "null" : Global.GetCode(this.cmbLoaiGiuong), (this.cmbBuong.SelectedIndex == -1) ? "null" : Global.GetCode(this.cmbBuong), (this.cmbGiuong.SelectedIndex == -1) ? "null" : Global.GetCode(this.cmbGiuong), text, 0, Global.GetCode(cmbDoiTuong), 0, TxtNamGhep.Value + 1, Global.GetCode(cmbBacSyDT) });
                    SQLCmd.ExecuteNonQuery();

                    SQLCmd.CommandText = string.Format("UPDATE [" + Global.glbKhamBenh + "].DBO.tblKHAMBENH_KQDVKHAM SET DaNhapVien=1 WHERE MaKhamBenh='{0}'", lblMaKhamBenh.Text);
                    SQLCmd.ExecuteNonQuery();
                    //Lay cac chi phi da su dung ngoai phong kham vao
                    SQLCmd.CommandText = String.Format("if(exists(select * from " + Global.glbKhamBenh + ".dbo.tblkhambenh_donthuoc khambenh where khambenh.makhambenh = '{0}'))"
                    + " begin"
                    + " insert into benhnhan_phieudieutri(sophieu,mavaovien,ngaychidinh,makhoa,nhom,CCHN_NT,MaPhieuCanQuang)"
                    + " select khambenh.MaPhieuCD,'{1}',thoigiancd,khoacd,0,chidinh.SoCCHN,khambenh.MaPhieuCanQuang from " + Global.glbKhamBenh + ".dbo.tblkhambenh_donthuoc khambenh"
                    + " inner join " + Global.glbDuoc + ".dbo.danhmucthuoc thuoc on thuoc.thuocid = khambenh.mathuoc"
                    + " Inner join (select distinct MaThuocCanQuang from NAMDINH_SYSDB.dbo.DMDICHVU inner join NAMDINH_KHAMBENH.dbo.tblKHAMBENH_DICHVU on tblKHAMBENH_DICHVU.MaDichvu = DMDICHVU.MaDichvu where  makhambenh = '{0}' ) Dm on dm.MaThuocCanQuang = thuoc.ThuocID"
                    + " inner join " + Global.glbKhamBenh + ".dbo.tblKHAMBENH_CHIDINH chidinh on chidinh.makhambenh = khambenh.makhambenh and chidinh.maphieucd = khambenh.maphieucd"
                    + " where  khambenh.makhambenh ='{0}' and chidinh.isDeleted = 0 "
                    + " group by khambenh.maphieucd,thoigiancd,khoacd,chidinh.SoCCHN,khambenh.MaPhieuCanQuang "
                    + " insert into phieudieutri_chitiet(SoPhieu,Loaidichvu,madichvu,soluong,dongia,doituongbn,dathuchien,tinhphi,LanChuyenDT,MaPhieuCanQuang)"
                    + " select khambenh.MaPhieuCD,'D01',MaThuoc,soluong,Case tblKhamBenh.DoiTuong when 1 then thuoc.dongiaBHYT else thuoc.DonGiaDV end as  dongia,{2},1,isnull(tblKhamBenh.DaTinhPhi,0),0,khambenh.MaPhieuCanQuang from " + Global.glbKhamBenh + ".dbo.tblkhambenh_donthuoc khambenh"
                    + " inner join " + Global.glbKhamBenh + ".dbo.tblKhamBenh tblKhamBenh on tblKhamBenh.MaKhamBenh = KhamBenh.MaKhamBenh"
                    + " inner join " + Global.glbDuoc + ".dbo.danhmucthuoc thuoc on thuoc.thuocid = khambenh.mathuoc"
                    + " Inner join (select distinct MaThuocCanQuang from NAMDINH_SYSDB.dbo.DMDICHVU inner join NAMDINH_KHAMBENH.dbo.tblKHAMBENH_DICHVU on tblKHAMBENH_DICHVU.MaDichvu = DMDICHVU.MaDichvu where  makhambenh = '{0}') Dm on dm.MaThuocCanQuang = thuoc.ThuocID"
                    + " inner join " + Global.glbKhamBenh + ".dbo.tblKHAMBENH_CHIDINH chidinh on chidinh.makhambenh = khambenh.makhambenh and chidinh.maphieucd = khambenh.maphieucd"
                    + " where khambenh.makhambenh ='{0}' and  chidinh.isDeleted = 0"
                    + " end", fg.GetDataDisplay(fg.Row, "MaKhamBenh"), MaVaoVien, Global.GetCode(cmbDoiTuong));
                    SQLCmd.ExecuteNonQuery();
                    SQLCmd.CommandText = String.Format("if(exists(select * from " + Global.glbKhamBenh + ".dbo.tblkhambenh_dichvu dichvu where  dichvu.maphieucd like 'cd%' and dichvu.makhambenh = '{0}')) "
                        + " begin "
                        + " insert into benhnhan_phieudieutri(sophieu,mavaovien,ngaychidinh,makhoa,nhom,CCHN_NT) "
                        + " select dichvu.maphieucd,'{1}',thoigiancd,khoacd,0,chidinh.SoCCHN from " + Global.glbKhamBenh + ".dbo.tblkhambenh_dichvu dichvu "
                        + " inner join  dmdichvu on dmdichvu.madichvu = dichvu.madichvu"
                        + " inner join " + Global.glbKhamBenh + ".dbo.tblKHAMBENH_CHIDINH chidinh on chidinh.makhambenh = dichvu.makhambenh and chidinh.maphieucd = dichvu.maphieucd "
                        + " where dichvu.maphieucd like 'cd%' and dichvu.makhambenh ='{0}' and chidinh.isDeleted = 0 "
                        + " group by dichvu.maphieucd,thoigiancd,khoacd,chidinh.SoCCHN "
                        + " insert into phieudieutri_chitiet(SoPhieu,Loaidichvu,madichvu,soluong,dongia,doituongbn,dathuchien,tinhphi,LanChuyenDT,MaMay,TyLeBHYT,MaKhoaThucHien) "
                        + " select dichvu.maphieucd,dmdichvu.Loaidichvu,dmdichvu.madichvu,soluong,Case tblKhamBenh.DoiTuong when 1 then dmdichvu.dongiaBHYT else dmdichvu.dongia end,{2},dichvu.DaThucHien,isnull(tblKhamBenh.DaTinhPhi,0),0,MaMay,isnull(dichvu.TyLeBH,dmdichvu.TyleBH),dichvu.MaKhoaThucHien from " + Global.glbKhamBenh + ".dbo.tblkhambenh_dichvu dichvu "
                        + " inner join " + Global.glbKhamBenh + ".dbo.tblKhamBenh tblKhamBenh on tblKhamBenh.MaKhamBenh = dichvu.MaKhamBenh"
                        + " inner join " + Global.glbKhamBenh + ".dbo.tblKHAMBENH_CHIDINH chidinh on chidinh.makhambenh = dichvu.makhambenh and chidinh.maphieucd = dichvu.maphieucd "
                        + " inner join  dmdichvu on dmdichvu.madichvu = dichvu.madichvu"
                        + " where dichvu.maphieucd like 'cd%' and dichvu.makhambenh ='{0}' and chidinh.isDeleted = 0  "
                        + " end", fg.GetDataDisplay(fg.Row, "MaKhamBenh"), MaVaoVien, Global.GetCode(cmbDoiTuong));
                    SQLCmd.ExecuteNonQuery();

                    SQLCmd.CommandText = String.Format("if(exists(select * from " + Global.glbKhamBenh + ".dbo.tblkhambenh_dichvu dichvu"
                        + " inner join " + Global.glbKhamBenh + ".dbo.tblkhambenh khambenh on dichvu .makhambenh = khambenh.Makhambenh "
                        + " where  dichvu.maphieucd like 'PK%' and dichvu.makhambenh = '{0}' and dichvu.madichvu <> 'A01051' "
                        + " and ((khambenh.Doituong <> '1') "
                        + " or (khambenh.Doituong = '1' and  dichvu.Khoathuchien <> 'NV120101' and dichvu.Khoathuchien <> 'NV13114' and dichvu.Khoathuchien <> 'NV13PCN') or (khambenh.doituong = '1' and (dichvu.Khoathuchien = 'NV13103' or dichvu.Khoathuchien = 'NV13104' ) and khambenh.is_truc = 0)))) " //and madichvu <> 'A01051' and (Khoathuchien <> 'NV120101' or Khoathuchien <> 'NV13114') là ko phải chuyển PK, ko tiếp đón vào thận NT và phòng 112
                        + " begin "
                        + " insert into benhnhan_phieudieutri(sophieu,mavaovien,ngaychidinh,makhoa,nhom,CCHN_NT) "
                        + " select top 1 dichvu.maphieucd,'{1}',thoigiancd,khoacd,0,chidinh.SoCCHN from " + Global.glbKhamBenh + ".dbo.tblkhambenh_dichvu dichvu "
                        + " inner join  dmdichvu on dmdichvu.madichvu = dichvu.madichvu"
                        + " inner join " + Global.glbKhamBenh + ".dbo.tblKHAMBENH_CHIDINH chidinh on chidinh.makhambenh = dichvu.makhambenh and chidinh.maphieucd = dichvu.maphieucd "
                        + " where dichvu.maphieucd like 'PK%' and dichvu.makhambenh ='{0}' "
                        + " group by dichvu.maphieucd,thoigiancd,khoacd,chidinh.SoCCHN  order by dichvu.maphieucd  "
                        + " insert into phieudieutri_chitiet(SoPhieu,Loaidichvu,madichvu,soluong,dongia,doituongbn,dathuchien,tinhphi,LanChuyenDT,TyLeBHYT,MaKhoaThucHien) "
                        + " select top 1 dichvu.maphieucd,dmdichvu.Loaidichvu,dmdichvu.madichvu,soluong,Case tblKhamBenh.DoiTuong when 1 then dmdichvu.dongiaBHYT else dmdichvu.dongia end,{2},dichvu.DaThucHien,isnull(tblKhamBenh.DaTinhPhi,0),0,isnull(dichvu.TyLeBH,dmdichvu.TyLeBH),dichvu.MaKhoaThucHien from " + Global.glbKhamBenh + ".dbo.tblkhambenh_dichvu dichvu "
                        + " inner join " + Global.glbKhamBenh + ".dbo.tblKhamBenh tblKhamBenh on tblKhamBenh.MaKhamBenh = dichvu.MaKhamBenh"
                        + " inner join  dmdichvu on dmdichvu.madichvu = dichvu.madichvu"
                        + " where dichvu.maphieucd like 'PK%' and dichvu.makhambenh ='{0}' order by dichvu.maphieucd  "
                        + " end", fg.GetDataDisplay(fg.Row, "MaKhamBenh"), MaVaoVien, Global.GetCode(cmbDoiTuong));
                    SQLCmd.ExecuteNonQuery();
                    //Update lai ma vao vien
                    if (lblMaKhamBenh.Text.Length == 10)
                    {
                        SQLCmd.CommandText = String.Format("Update [" + Global.glbVienPhi + "].dbo.tblThukyquy set MaVaoVien='{0}' where MaSoKham='{1}'",
                        MaVaoVien, fg.GetDataDisplay(fg.Row, "MaKhamBenh"));
                        SQLCmd.ExecuteNonQuery();
                    }
                    else
                    {
                        SQLCmd.CommandText = String.Format("Update [" + Global.glbVienPhi + "].dbo.tblThukyquy set MaVaoVien='{1}' where MaSoKham='{1}'",
                        MaVaoVien, fg.GetDataDisplay(fg.Row, "MaKhamBenh"));
                        SQLCmd.ExecuteNonQuery();
                    }
                    SQLCmd.CommandText = String.Format("update [" + Global.glbKhamBenh + "].dbo.tblKHAMBENH_KQDVKHAM set TuChoiTiepNhan = 2 where makhambenh=N'{0}'", lblMaKhamBenh.Text);
                    SQLCmd.ExecuteNonQuery();
                    trn.Commit();
                    MessageBox.Show("Đã tiếp nhận bệnh nhân vào viện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fg.RemoveItem(fg.Row);
                    Clear_Data();
                }
                else
                {
                    if (fg.GetDataDisplay(fg.Row, "NoiNgoai") == "1")
                    {
                        //Truong hop chuyen khoa
                        SQLCmd.CommandText = String.Format("delete from benhnhan_chitiet where mavaovien='{0}'", fg.GetDataDisplay(fg.Row, "MaKhamBenh"));
                        SQLCmd.ExecuteNonQuery();
                        SQLCmd.CommandText = string.Format("INSERT INTO BENHNHAN_CHITIET (MaBenhNhan,MaVaoVien,SoHSBA,Buong,Giuong,SoTheBHYT,MaDTBHYT,MaNoiCapBHYT,HanTheBHYT_Tu,HanTheBHYT_Den,"
                                                    + "DiaChi,MaTinh_TP,NgheNghiep,LienHe,NgayVaoVien,TrucTiepVao,NoiGioiThieu,VaoVienLan,ChanDoan_NoiChuyenDen,ICD_NoiChuyenDen,ChanDoan_KKB,ICD_KKB,ChanDoan_KhoaDT,ICD_KhoaDT,TrangThai,NgayKham,MaNhom,NoiCongTac,MaKhamBenh,BA_NoiNgoai,Is_Covid) VALUES "
                                                    + "('{0}','{1}','{2}',{3},{4},'{5}','{6}','{7}',{8},{9},N'{10}',"
                                                    + "'{11}',N'{12}',N'{13}','{14:dd/MM/yyyy HH:mm}',{15},{16},{17},N'{18}','{19}',N'{20}','{21}',N'{22}','{23}',1,'{24:dd/MM/yyyy HH:mm}',{25},N'{26}','{27}',{28},{29})",
                                                    txtMaBenhNhan.Text, fg.GetDataDisplay(fg.Row, "MaKhamBenh"), txtMaBenhAn.Text,
                                                    (cmbBuong.SelectedIndex == -1) ? ("null") : (Global.GetCode(cmbBuong)),
                                                    (cmbGiuong.SelectedIndex == -1) ? ("Null") : (Global.GetCode(cmbGiuong)),
                                                    txtSoTheBHYT.Text, txtMaDTBHYT.Text, txtMaNoiCapBHYT.Text, TNgay, DNgay, txtDiaChi.Text, "",
                                                    txtNgheNghiep.Text, txtDiaChiLH.Text, txtNgayVaoKhoa.Value,
                                                    (cmbTrucTiepVao.SelectedIndex == -1) ? ("null") : (Global.GetCode(cmbTrucTiepVao)),
                                                    (cmbNoiGioiThieu.SelectedIndex == -1) ? ("null") : (Global.GetCode(cmbNoiGioiThieu)),
                                                    txtLanVaoVien.Value, txtChanDoan_NoiChuyenDen.Text, lblICD_NoiChuyenDen.Text,
                                                    txtChanDoan_KKB.Text, lblICD_KKB.Text, txtChanDoan_KhoaDieuTri.Text, lblICD_KhoaDieuTri.Text, txtNgayVaoVien.Value, Global.GetCode(cmbNhom), txtNoiLamViec.Text.Trim(), txtMaKhamBenh.Text.Trim(), Global.GetCode(cmbLoaiBA), chkBenhNhan_Covid.Checked == false ? 0 : 1);
                        SQLCmd.ExecuteNonQuery();
                        SQLCmd.CommandText = string.Format("select NgayChuyen from BENHNHAN_KHOA where MaVaoVien = '{0}' and lanchuyenkhoa = (select Min(lanchuyenkhoa) from BENHNHAN_KHOA where mavaovien = '{0}')", fg.GetDataDisplay(fg.Row, "MaKhamBenh"));
                        dr = SQLCmd.ExecuteReader();
                        while (dr.Read())
                        {
                            if (DateTime.Compare((DateTime)DateTime.Parse(dr["Ngaychuyen"].ToString()), (DateTime)txtNgayVaoKhoa.Value) > 0)
                            {
                                MessageBox.Show("Chú ý: Thời gian vào khoa phải sau " + string.Format("{0:dd/MM/yyy HH:mm}", DateTime.Parse(dr["Ngaychuyen"].ToString())), "Thông báo!");
                                txtNgayVaoKhoa.Focus();
                                dr.Close();
                                return;
                            }
                        }
                        dr.Close();
                        SQLCmd.CommandText = String.Format("Update benhnhan_khoa set ChanDoan=N'{0}',User_Name=N'{2}',MaKhoaCD='{3}',NgayChuyen='{4:dd/MM/yyy HH:mm}', IDBuong_Khoa ={5}, IDGiuong_Khoa = {6} where mavaovien='{1}' and "
                            + " lanchuyenkhoa = (select max(lanchuyenkhoa) from benhnhan_khoa where mavaovien='{1}' group by mavaovien)",
                            txtChanDoan_KhoaDieuTri.Text.Trim(),
                             fg.GetDataDisplay(fg.Row, "MaKhamBenh"),
                             Global.glbUName,
                             fg.GetDataDisplay(fg.Row, "MaKhoaCD"),
                             txtNgayVaoKhoa.Value, Global.GetCode(cmbBuong), Global.GetCode(cmbGiuong));
                        SQLCmd.ExecuteNonQuery();
                        string text = "";
                        SQLCmd.CommandText = string.Format("select dbo.LaySoPhieu(Right(Convert(nvarchar(8),'{0:yyyyMMdd}',112),6)) As SoPhieu", this.txtNgayVaoVien.Value);
                        text = SQLCmd.ExecuteScalar().ToString();
                        //SQLCmd.CommandText = string.Format(" INSERT INTO BENHNHAN_KHOA_NGAYGIUONG_CT(MaVaoVien, LanChuyenKhoa, NgayChuyen, MaKhoa, NgayBatDau, Loaidichvu, MaDichVu, ID_Buong, ID_Giuong,Sophieu,Lan,DoiTuong,TrangThaiBN,TrangThaiGiuong,BacSyDT)"
                        //        + " values('{0}',{1},'{2:dd/MM/yyyy HH:mm}',{3},'{4:dd/MM/yyyy HH:mm}','{5}','{6}',{7},{8},'{9}',{10},{11},{12},{13},'{14}') ",
                        //         new object[] { lblMaKhamBenh.Text, 0, textBox1.Value, Global.glbKhoa_CapNhat, txtNgayVaoKhoa.Value, "B01", (this.cmbLoaiGiuong.SelectedIndex == -1) ? "TNT" : Global.GetCode(this.cmbLoaiGiuong), (this.cmbBuong.SelectedIndex == -1) ? "null" : Global.GetCode(this.cmbBuong), (this.cmbGiuong.SelectedIndex == -1) ? "null" : Global.GetCode(this.cmbGiuong), text, 0, Global.GetCode(cmbDoiTuong), 1, TxtNamGhep.Value +1, Global.GetCode(cmbBacSyDT) });
                        //SQLCmd.ExecuteNonQuery();

                        SQLCmd.CommandText = string.Format("if(exists(select * from BENHNHAN_KHOA_NGAYGIUONG_CT where MaVaoVien = '{0}' and MaKhoa = {3} and madichvu = '{6}')) update BENHNHAN_KHOA_NGAYGIUONG_CT set  NgayBatDau = '{2:dd/MM/yyyy HH:mm}', NgayChuyen = '{2:dd/MM/yyyy HH:mm}' where MaVaoVien = '{0}' and MaKhoa = {3} and madichvu = '{6}' and TrangThaiBN = 0 else INSERT INTO BENHNHAN_KHOA_NGAYGIUONG_CT(MaVaoVien, LanChuyenKhoa, NgayChuyen, MaKhoa, NgayBatDau, Loaidichvu, MaDichVu, ID_Buong, ID_Giuong,Sophieu,Lan,DoiTuong,TrangThaiBN,TrangThaiGiuong,BacSyDT)"
                                 + " values('{0}',{1},'{2:dd/MM/yyyy HH:mm}',{3},'{4:dd/MM/yyyy HH:mm}','{5}','{6}',{7},{8},'{9}',{10},{11},{12},{13},'{14}') ",
                                   new object[] { lblMaKhamBenh.Text, 0, txtNgayVaoKhoa.Value, Global.glbKhoa_CapNhat, txtNgayVaoKhoa.Value, "B01", (this.cmbLoaiGiuong.SelectedIndex == -1) ? "TNT" : Global.GetCode(this.cmbLoaiGiuong), Global.GetCode(cmbBuong), Global.GetCode(cmbGiuong), text, 0, Global.GetCode(cmbDoiTuong), 1, TxtNamGhep.Value + 1, Global.GetCode(cmbBacSyDT) });
                        SQLCmd.ExecuteNonQuery();
                        if (lblMaKhamBenh.Text.Length == 10)
                        {
                            SQLCmd.CommandText = String.Format("Update [" + Global.glbVienPhi + "].dbo.tblThukyquy set MaVaoVien='{0}' where MaSoKham='{1}'",
                            MaVaoVien, fg.GetDataDisplay(fg.Row, "MaKhamBenh"));
                            SQLCmd.ExecuteNonQuery();
                        }
                        else
                        {
                            SQLCmd.CommandText = String.Format("Update [" + Global.glbVienPhi + "].dbo.tblThukyquy set MaVaoVien='{1}' where MaSoKham='{1}'",
                            MaVaoVien, fg.GetDataDisplay(fg.Row, "MaKhamBenh"));
                            SQLCmd.ExecuteNonQuery();
                        }
                        trn.Commit();
                        MessageBox.Show("Đã tiếp nhận bệnh nhân vào viện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        fg.RemoveItem(fg.Row);
                    }
                    else
                    {
                        SQLCmd.CommandText = String.Format("update benhnhan_chitiet set trangthai = 1,MaNhom={2} where mavaovien='{0}' "
                            + " update benhnhan_khoa set user_name=N'{1}',IDBuong_Khoa = {3}, IDGiuong_Khoa = {4} where mavaovien ='{0}'", lblMaKhamBenh.Text, Global.glbUName, Global.GetCode(cmbNhom),Global.GetCode(cmbBuong),Global.GetCode(cmbGiuong));
                        SQLCmd.ExecuteNonQuery();
                        trn.Commit();
                        MessageBox.Show("Đã tiếp nhận bệnh nhân vào viện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        fg.RemoveItem(fg.Row);
                        Clear_Data();
                    }
                }

                //LayThongTin();
            }
            catch (Exception ex)
            {
                trn.Rollback();
                MessageBox.Show("Có lỗi khi ghi dữ liệu!\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SQLCmd.Dispose();
                trn.Dispose();
            }
            Clear_Data();
            NgayGiuongBenh();
        }
        private bool Validate_BN()
        {
            if (txtMaBenhNhan.Text.Length != 10)
            {
                MessageBox.Show("Nhập sai Mã bệnh nhân!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return (false);
            }
            if (txtHoTen.Text.Trim() == "")
            {
                MessageBox.Show("Nhập sai tên bệnh nhân!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return (false);
            }
            if (cmbDoiTuong.SelectedIndex == -1)
            {
                MessageBox.Show("Nhập sai đối tượng của bệnh nhân!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return (false);
            }
            if (cmbLoaiBA.SelectedIndex == -1)
            {
                MessageBox.Show("Nhập loại bệnh án!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return (false);
            }
            if (txtNgayVaoVien.ValueIsDbNull)
            {
                MessageBox.Show("Nhập sai ngày vào viện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return (false);
            }
            if (txtNgayVaoKhoa.ValueIsDbNull)
            {
                MessageBox.Show("Nhập sai ngày vào Khoa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return (false);
            }
            if (((txtMaDTBHYT.Text) == "KC" && txtSoTheBHYT.Text.Substring(0, 1) == "4"))
            {
                return (true);
            }
            if (DateTime.Parse(txtNgayVaoVien.Text) >= DateTime.Parse(txtNgayVaoKhoa.Text))
            {
                MessageBox.Show("Ngày vào Khoa >= Thời Gian Đăng Ký!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNgayVaoKhoa.Focus();
                return (false);
            }
            //if (cmbTuyen.SelectedIndex == -1 ||(txtMaNoiCapBHYT.Text =="36001") && (cmbTuyen.SelectedIndex == 1|| (txtMaNoiCapBHYT.Text == "36001") && (cmbTuyen.SelectedIndex == 3)))
            //{
            //    MessageBox.Show("Chọn tuyến!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    cmbTuyen.Focus();
            //    return (false);
            //}
            if (txtChanDoan_KhoaDieuTri.Text.Trim() == "")
            {
                MessageBox.Show("Nhập chẩn đoán khoa điều trị!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtChanDoan_KhoaDieuTri.Focus();
                return (false);
            }
            if (cmbNhom.SelectedIndex == -1)
            {
                MessageBox.Show("Chọn nhóm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbNhom.Focus();
                return (false);
            }

            if (txtDiaChiLH.Text.Trim() == "")
            {
                MessageBox.Show("Nhập thông tin liên Hệ của bệnh nhân", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDiaChiLH.Focus();
                return (false);
            }
            if (txtDiaChi.Text.Trim() == "")
            {
                MessageBox.Show("Nhập Địa chỉ của bệnh nhân", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDiaChiLH.Focus();
                return (false);
            }
            if (Global.GetCode(cmbDoiTuong) != "1" && Global.GetCode(cmbDoiTuong) != "3")
            {
                MessageBox.Show("Nhập lại đối tượng cho bệnh nhân", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbDoiTuong.Focus();
                return (false);
            }
            return (true);
        }

        private void Clear_Data()
        {
            txtMaBenhNhan.Text = "";
            lblMaKhamBenh.Text = "";
            txtMaBenhAn.Text = "";
            txtHoTen.Text = "";
            cmbGioiTinh.SelectedIndex = -1;
            txtNgaySinh.Value = txtThangSinh.Value = txtNamSinh.Value = 0;
            //cmbDanToc.SelectedIndex = -1;
            cmbDoiTuong.SelectedIndex = -1;
            txtSoTheBHYT.Text = txtMaDTBHYT.Text = txtMaNoiCapBHYT.Text = "";
            txtHanTheTu.Value = txtHanTheDen.Value = null;
            txtDiaChi.Text = "";
            txtNgheNghiep.Text = "";
            txtDiaChiLH.Text = "";
            txtNoiCapBHYT.Text = "";
            txtNgayVaoVien.Value = null;
            txtLanVaoVien.Value = 1;
            cmbTrucTiepVao.SelectedIndex = -1;
            cmbNoiGioiThieu.SelectedIndex = -1;
            txtNgayVaoKhoa.Value = null;
            cmbBuong.SelectedIndex = -1;
            cmbGiuong.SelectedIndex = -1;
            cmbLoaiGiuong.SelectedIndex = -1;
            txtChanDoan_KhoaDieuTri.Text = txtChanDoan_KKB.Text = txtChanDoan_NoiChuyenDen.Text = "";
            lblICD_KhoaDieuTri.Text = lblICD_KKB.Text = lblICD_NoiChuyenDen.Text = "";
        }

        private void cmdTim_Click(object sender, EventArgs e)
        {
            for (int i = 1; i < fg.Rows.Count; i++)
            {
                if (fg[i, "MaKhamBenh"].ToString() == txtTimMaKhamBenh.Text)
                {
                    fg.Row = i;
                    return;
                }
            }
            MessageBox.Show("Không tìm thấy bệnh nhân có Mã khám bệnh [" + txtTimMaKhamBenh.Text + "]", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void raChoVaoKhoa_CheckedChanged(object sender, EventArgs e)
        {
            cmbKhoa_TextChanged(sender, e);
            if (raChoVaoKhoa.Checked)
            {
                cmdXoa.Visible = true;
                btn_XoaBN.Enabled = false;
                //cmdQuayLaiTiepDon.Visible = false;
            }
            else
            {
                cmdXoa.Visible = false;
                btn_XoaBN.Enabled = false;
                //cmdQuayLaiTiepDon.Visible = true;
            }
            Clear_Data();
        }

        private void raDangDieuTri_CheckedChanged(object sender, EventArgs e)
        {
            if (Global.glbUName == "gd.hoa" && raDangDieuTri.Checked == true)
            {
                btn_XoaBN.Enabled = true;
            }
            Clear_Data();
        }

        private void SoluongNamGhep()
        {
            string s = lblMaKhamBenh.Text;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
            System.Data.SqlClient.SqlDataReader dr;
            SQLCmd.CommandText = string.Format("SELECT COUNT(*) AS SL FROM BENHNHAN bn INNER JOIN BENHNHAN_CHITIET bnct ON bn.MABENHNHAN = bnct.MABENHNHAN "
                                            + " inner join ViewKHOAHIENTAI khoa on khoa.MaVaoVien = bnct.MaVaoVien"
                                            + " INNER JOIN NAMDINH_QLBN.DBO.DMGIUONGBENH GB ON GB.ID_Buong = bnct.Buong  and BNCT.Giuong = gb.ID_Giuong and khoa.MaKhoa = gb.MaKhoa"
                                            + " WHERE bnct.Buong = {0}  AND GB.MaKhoa = '{1}' and BNCT.Giuong = {2}  and bnct.daravien = 0", Global.GetCode(cmbBuong), Global.GetCode(cmbKhoa), Global.GetCode(cmbGiuong));
            dr = SQLCmd.ExecuteReader();
            while (dr.Read())
            {
                TxtNamGhep.Value = int.Parse(dr["SL"].ToString());
            }
            dr.Close();
            SQLCmd.Dispose();
        }
        private void cmdCNTD_Click(object sender, EventArgs e)
        {
            String Str = "";
            if (cmbBuong.SelectedIndex == -1)
            {
                MessageBox.Show("Nhập số buồng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbBuong.Focus();
                return;
            }
            if (cmbGiuong.SelectedIndex == -1)
            {
                MessageBox.Show("Nhập số giường!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbGiuong.Focus();
                return;
            }
            for (int row = 1; row < fgBuongGiuong.Rows.Count; row++)
            {
                if (!this.fgBuongGiuong.Rows[row].IsNode && Global.GetCode(cmbBuong) == fgBuongGiuong[row, "ID_Buong"].ToString() && Global.GetCode(cmbGiuong) == fgBuongGiuong[row, "ID_Giuong"].ToString())
                {
                    if ( fgBuongGiuong[row, "sl"].ToString()!= "")
                        MessageBox.Show("Hiện tại đã có bệnh nhân");
                }
            }
            if (DateTime.Parse(fg.GetDataDisplay(fg.Row, "NgayVaoKham").ToString()) >= DateTime.Parse("01/01/2021") && cmbDoiTuong.Text == "Bảo hiểm y tế")
            {
                CapCuu = 0;
                if (cmbTuyen.SelectedIndex == 3)
                {
                    tuyen = 3;
                    CapCuu = 0;
                }
                if (cmbTuyen.SelectedIndex == 2)
                {
                    tuyen = 0;
                    CapCuu = 1;
                }
                if (cmbTuyen.SelectedIndex == 1)
                {
                    tuyen = 3;
                    CapCuu = 0;
                }
                if (cmbTuyen.SelectedIndex == 0)
                {
                    tuyen = 0;
                    CapCuu = 0;
                }
            }
            else
            {
                if (cmbTuyen.SelectedIndex == 2)
                {
                    tuyen = 0;
                    CapCuu = 1;
                }
                else
                {
                    tuyen = cmbTuyen.SelectedIndex;
                    CapCuu = 0;
                }
            }
            if (!Validate_BN()) return;
            //if (cmbTuyen.SelectedIndex == 2)
            //{
            //    tuyen = 0;
            //}
            //else tuyen = cmbTuyen.SelectedIndex;
            try
            {
                System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
                System.Data.SqlClient.SqlDataReader dr;

                SQLCmd.CommandText = string.Format("set dateformat dmy select NgayChuyen from BENHNHAN_KHOA where MaVaoVien = '{0}' and lanchuyenkhoa = (select min(lanchuyenkhoa) from BENHNHAN_KHOA where mavaovien = '{0}')", fg.GetDataDisplay(fg.Row, "MaKhamBenh"));
                dr = SQLCmd.ExecuteReader();
                while (dr.Read())
                {
                    if (DateTime.Compare((DateTime)DateTime.Parse(dr["Ngaychuyen"].ToString()), (DateTime)txtNgayVaoKhoa.Value) > 0)
                    {
                        MessageBox.Show("Chú ý: Thời gian vào khoa phải sau " + string.Format("{0:dd/MM/yyy HH:mm}", DateTime.Parse(dr["Ngaychuyen"].ToString())), "Thông báo!");
                        txtNgayVaoKhoa.Focus();
                        dr.Close();
                        return;
                    }
                }
                dr.Close();
                SQLCmd.CommandText = String.Format("update NAMDINH_VIENPHI.DBO.tblThukyquy SET MaVaovien = B.MAVAOVIEN from  NAMDINH_VIENPHI.dbo.tblThukyquy a inner join NAMDINH_QLBN.dbo.BENHNHAN_CHITIET b on a.mavaovien = b.mavaovien where b.MaVaoVien = '{0}'",
                lblMaKhamBenh.Text.Trim());
                SQLCmd.ExecuteNonQuery();
                string text = "";
                SQLCmd.CommandText = string.Format("select dbo.LaySoPhieu(Right(Convert(nvarchar(8),'{0:yyyyMMdd}',112),6)) As SoPhieu", this.txtNgayVaoVien.Value);
                text = SQLCmd.ExecuteScalar().ToString();
                SQLCmd.CommandText = string.Format("if(exists(select * from BENHNHAN_KHOA_NGAYGIUONG_CT where MaVaoVien = '{0}' and MaKhoa = {3} and madichvu = '{6}')) update BENHNHAN_KHOA_NGAYGIUONG_CT set  NgayBatDau = '{2:dd/MM/yyyy HH:mm}', NgayChuyen = '{2:dd/MM/yyyy HH:mm}'  where MaVaoVien = '{0}' and MaKhoa = {3} and madichvu = '{6}' and TrangThaiBN = 0 else INSERT INTO BENHNHAN_KHOA_NGAYGIUONG_CT(MaVaoVien, LanChuyenKhoa, NgayChuyen, MaKhoa, NgayBatDau, Loaidichvu, MaDichVu, ID_Buong, ID_Giuong,Sophieu,Lan,DoiTuong,TrangThaiBN,TrangThaiGiuong,BacSyDT)"
                         + " values('{0}',{1},'{2:dd/MM/yyyy HH:mm}',{3},'{4:dd/MM/yyyy HH:mm}','{5}','{6}',{7},{8},'{9}',{10},{11},{12},{13},'{14}') ",
                           new object[] { lblMaKhamBenh.Text, 0, txtNgayVaoKhoa.Value, Global.glbKhoa_CapNhat, txtNgayVaoKhoa.Value, "B01", (this.cmbLoaiGiuong.SelectedIndex == -1) ? "TNT" : Global.GetCode(this.cmbLoaiGiuong), Global.GetCode(cmbBuong), Global.GetCode(cmbGiuong), text, 0, Global.GetCode(cmbDoiTuong), 0, TxtNamGhep.Value + 1, Global.GetCode(cmbBacSyDT) });
                SQLCmd.ExecuteNonQuery();
                SQLCmd.CommandText = string.Format("delete from BENHNHAN_KHOA_NGAYGIUONG_CT  where MaVaoVien = '{0}' and MaKhoa = {3} and madichvu = 'TNT'",
                new object[] { lblMaKhamBenh.Text, 0, txtNgayVaoKhoa.Value, Global.glbKhoa_CapNhat, txtNgayVaoKhoa.Value, "B01", (this.cmbLoaiGiuong.SelectedIndex == -1) ? "TNT" : Global.GetCode(this.cmbLoaiGiuong), Global.GetCode(cmbBuong), Global.GetCode(cmbGiuong), text, 0, Global.GetCode(cmbDoiTuong), 0, TxtNamGhep.Value + 1, Global.GetCode(cmbBacSyDT) });
                SQLCmd.ExecuteNonQuery();
                SQLCmd.Dispose();
                SQLCmd.CommandText = String.Format("UPDATE BENHNHAN SET HOTEN=N'{0}',NGAYSINH={1},THANGSINH={2},NAMSINH={3},GIOITINH={4},MADANTOC='{5}' Where MaBenhNhan = '{6}' ",
                    txtHoTen.Text, txtNgaySinh.Value, txtThangSinh.Value, txtNamSinh.Value,
                    GlobalModuls.Global.GetCode(cmbGioiTinh),
                    GlobalModuls.Global.GetCode(cmbDanToc),
                    txtMaBenhNhan.Text);
                SQLCmd.ExecuteNonQuery();
                SQLCmd.Dispose();
                SQLCmd.CommandText = String.Format("UPDATE NAMDINH_KHAMBENH.DBO.TBLBENHNHAN SET TenBenhnhan=N'{0}',NGAYSINH={1},THANGSINH={2},NAMSINH={3},GIOITINH={4} Where MaBenhNhan = '{6}' ",
                 txtHoTen.Text, txtNgaySinh.Value, txtThangSinh.Value, txtNamSinh.Value,
                 GlobalModuls.Global.GetCode(cmbGioiTinh),
                 GlobalModuls.Global.GetCode(cmbDanToc),
                 txtMaBenhNhan.Text);
                SQLCmd.ExecuteNonQuery();
                SQLCmd.Dispose();

                String TNgay, DNgay;
                if (txtHanTheTu.ValueIsDbNull == false && txtHanTheTu.Value.ToString() == "01/01/1900")
                {
                    TNgay = DNgay = "Null";
                }
                else
                {
                    TNgay = String.Format("'{0:dd/MM/yyyy}'", txtHanTheTu.Value);
                    DNgay = String.Format("'{0:dd/MM/yyyy}'", txtHanTheDen.Value);
                }
                if (GlobalModuls.Global.GetCode(cmbLoaiBA) != lblLoaiBACU.Tag.ToString())
                {
                    Str += string.Format(" DECLARE @MaxSoHSBA nVarChar(6)"
                            + " DECLARE @Nam int"
                            + " Set @MaxSoHSBA = '000000'"
                            + " if '" + Global.GetCode(cmbLoaiBA) + "'='0' "
                            + " BEGIN"
                            + " SELECT @MaxSoHSBA  = SOHSBA,@Nam = Nam FROM SOHSBA"
                            + " IF @Nam <> Year(GETDATE())"
                            + " BEGIN"
                            + " UPDATE SOHSBA SET SOHSBA = '000000',NAM = YEAR(GETDATE())"
                            + " SET @MaxSoHSBA = '000000'"
                            + " END"
                            + "  	DECLARE @Ma int"
                            + "       	SET @Ma=Cast(@MaxSoHSBA  As Int)+1"
                            + "       	SET @MaxSoHSBA = Cast(@Ma as nvarChar(6))"
                            + " 	WHILE Len(@MaxSoHSBA)< 6"
                            + "     BEGIN"
                            + "              SET @MaxSoHSBA='0' +@MaxSoHSBA"
                            + " 	END"
                            + " 	UPDATE SOHSBA SET SOHSBA = @MAXSOHSBA"
                            + " END "
                            + " ELSE "
                            + " BEGIN "
                            + " SELECT @MaxSoHSBA  = SOHSBA_NGOAI,@Nam = Nam FROM SOHSBA"
                            + " IF @Nam <> Year(GETDATE())"
                            + " BEGIN"
                            + " UPDATE SOHSBA SET SOHSBA_NGOAI = '000000',NAM = YEAR(GETDATE())"
                            + " SET @MaxSoHSBA = '000000'"
                            + " END"
                            + "  	DECLARE @Ma_NGOAI int"
                            + "       	SET @Ma_NGOAI=Cast(isnull(@MaxSoHSBA,0)  As Int)+1"
                            + "       	SET @MaxSoHSBA = Cast(@Ma_NGOAI as nvarChar(6))"
                            + " 	WHILE Len(@MaxSoHSBA)< 6"
                            + "     BEGIN"
                            + "              SET @MaxSoHSBA='0' +@MaxSoHSBA"
                            + " 	END"
                            + " 	UPDATE SOHSBA SET SOHSBA_NGOAI = @MAXSOHSBA"
                            + " END ");
                    Str += String.Format(" UPDATE BENHNHAN_CHITIET SET SOHSBA=@MaxSoHSBA,SOTHEBHYT='{0}',MADTBHYT='{1}',MANOICAPBHYT='{2}',"
                    + "HANTHEBHYT_TU={3},HANTHEBHYT_DEN={4},DIACHI=N'{5}',MATINH_TP='{6}',NGHENGHIEP=N'{7}',LIENHE=N'{8}',"
                    + "NGAYVAOVIEN='{9:dd/MM/yyyy HH:mm}',NGAYKHAM='{10:dd/MM/yyyy HH:mm}',CHANDOAN_KHOADT=N'{11}',MaNhom={12},NoiCongTac=N'{13}',BA_NOINGOAI={14},Buong = '{15}',Giuong = '{16}',Is_Covid = {17}",
                    //txtMaBenhAn.Text,
                    txtSoTheBHYT.Text,
                    txtMaDTBHYT.Text,
                    txtMaNoiCapBHYT.Text,
                    TNgay,
                    DNgay,
                    txtDiaChi.Text,
                    "",
                    txtNgheNghiep.Text,
                    txtDiaChiLH.Text,
                    txtNgayVaoKhoa.ValueIsDbNull == true ? null : txtNgayVaoKhoa.Value,
                    txtNgayVaoVien.ValueIsDbNull == true ? null : txtNgayVaoVien.Value,
                    txtChanDoan_KhoaDieuTri.Text,
                    Global.GetCode(cmbNhom),
                    txtNoiLamViec.Text.Trim(),
                    Global.GetCode(cmbLoaiBA),
                    Global.GetCode(cmbBuong),
                    Global.GetCode(cmbGiuong), chkBenhNhan_Covid.Checked == false ? 0 : 1);
                }
                else
                {
                    Str += String.Format(" UPDATE BENHNHAN_CHITIET SET SOTHEBHYT='{0}',MADTBHYT='{1}',MANOICAPBHYT='{2}',"
                    + "HANTHEBHYT_TU={3},HANTHEBHYT_DEN={4},DIACHI=N'{5}',MATINH_TP='{6}',NGHENGHIEP=N'{7}',LIENHE=N'{8}',"
                    + "NGAYVAOVIEN='{9:dd/MM/yyyy HH:mm}',NGAYKHAM='{10:dd/MM/yyyy HH:mm}',CHANDOAN_KHOADT=N'{11}',MaNhom={12},NoiCongTac=N'{13}',BA_NOINGOAI={14},Buong = '{15}',Giuong = '{16}',Is_Covid = {17}",
                    txtSoTheBHYT.Text,
                    txtMaDTBHYT.Text,
                    txtMaNoiCapBHYT.Text,
                    TNgay,
                    DNgay,
                    txtDiaChi.Text,
                    "",
                    txtNgheNghiep.Text,
                    txtDiaChiLH.Text,
                    txtNgayVaoKhoa.ValueIsDbNull == true ? null : txtNgayVaoKhoa.Value,
                    txtNgayVaoVien.ValueIsDbNull == true ? null : txtNgayVaoVien.Value,
                    txtChanDoan_KhoaDieuTri.Text,
                    Global.GetCode(cmbNhom),
                    txtNoiLamViec.Text.Trim(),
                    Global.GetCode(cmbLoaiBA),
                    Global.GetCode(cmbBuong),
                    Global.GetCode(cmbGiuong), chkBenhNhan_Covid.Checked == false ? 0 : 1);
                }
                Str += String.Format(" WHERE mavaovien ='{0}'", lblMaKhamBenh.Text);
                Str += String.Format(" Update benhnhan_khoa set ChanDoan =N'{0}',NgayChuyen='{1:dd/MM/yyyy HH:mm}', IDBuong_Khoa = {3}, IDGiuong_Khoa = {4} where mavaovien ='{2}' and "
            + " lanchuyenkhoa = (select maxlan from viewkhoahientai where mavaovien ='{2}')",
                txtChanDoan_KhoaDieuTri.Text.Trim(),
                txtNgayVaoKhoa.Value,
                lblMaKhamBenh.Text.Trim(),
                Global.GetCode(cmbBuong),
                Global.GetCode(cmbGiuong));
                SQLCmd.CommandText = Str;
                SQLCmd.ExecuteNonQuery();
                string doituongBn = Global.GetCode(cmbDoiTuong);
                SQLCmd.CommandText = String.Format(" Update Benhnhan_doituong set CapCuu = {5},Tuyen= {6} where mavaovien ='{2}'"
                    + " update NAMDINH_KHAMBENH.DBO.tblKHAMBENH set Tuyen= {8} FROM NAMDINH_KHAMBENH.DBO.tblKHAMBENH A INNER Join  BENHNHAN_CHITIET b on a.MaKhambenh = b.MaKhamBenh  where b.mavaovien = {2}",
                txtChanDoan_KhoaDieuTri.Text.Trim(),
                txtNgayVaoKhoa.Value,
                lblMaKhamBenh.Text.Trim(),
                txtMaICD_BenhChinh.Text.Trim(),
                txtMaICD_BenhPhu.Text.Trim(), CapCuu,
                tuyen, doituongBn, cmbTuyen.SelectedIndex);
                SQLCmd.ExecuteNonQuery();
                NgayGiuongBenh();
                //SoluongNamGhep();
                LayThongTin();
            }
            catch
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                MessageBox.Show("cập nhật thành công","Thông báo",MessageBoxButtons.OK);
            }
            
            
            //cmbKhoa_TextChanged(sender, e);
        }
        private void cmdXoa_Click(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
            try
            {
                C1.Win.C1FlexGrid.CellRange cell = fg.Selection;
                if (MessageBox.Show("Bạn muốn từ chối tiếp nhận bệnh nhân này.", "Thông báo.", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    for (int i = cell.r1; i <= cell.r2; i++)
                    {
                        if (fg.GetDataDisplay(i, "NoiNgoai") == "1")// benh nhan chuyen khoa
                        {
                            //SQLCmd.CommandText += String.Format(" update [" + Global.glbKhamBenh + "].dbo.tblKHAMBENH_KQDVKHAM set TuChoiTiepNhan = 1 where makhambenh in (Select MaKhamBenh from benhnhan_chitiet where mavaovien='{0}')", fg[i, "MaKhamBenh"].ToString());
                            SQLCmd.CommandText += String.Format(" update benhnhan_chitiet set TrangThai =1 where MaVaoVien=N'{0}'", fg[i, "MaKhamBenh"].ToString());
                            SQLCmd.CommandText += String.Format("Delete from benhnhan_khoa where mavaovien='{0}' and lanchuyenkhoa = (select max(lanchuyenkhoa) from benhnhan_khoa where mavaovien='{0}' group by mavaovien)", fg[i, "MaKhamBenh"].ToString());
                        }
                        if (fg.GetDataDisplay(i, "NoiNgoai") == "0")
                        {
                            SQLCmd.CommandText += String.Format(" update [" + Global.glbKhamBenh + "].dbo.tblKHAMBENH_KQDVKHAM set TuChoiTiepNhan = 1 where makhambenh ='{0}'", fg[i, "MaKhamBenh"].ToString());
                        }

                    }
                    SQLCmd.ExecuteNonQuery();
                    cmbKhoa_TextChanged(sender, e);
                    NgayGiuongBenh();
                }
            }
            catch
            {
            }
            finally
            {
            }
        }

        private void cmdQuayLaiTiepDon_Click(object sender, EventArgs e)
        {

        }


        private void fg_AfterRowColChange(object sender, C1.Win.C1FlexGrid.RangeEventArgs e)
        {
            if (fg.Tag.ToString() == "0") return;
            LayThongTin();
            if (raDangDieuTri.Checked)
            {
                //SoluongNamGhep();
            }
        }

        private void txtMaICD_BenhChinh_KeyUp(object sender, KeyEventArgs e)
        {
            if (e == null || e.KeyCode == Keys.Enter || e.KeyCode == Keys.Separator || e.KeyCode == Keys.Escape)
            {
                txtMaICD_BenhChinh.Text = txtMaICD_BenhChinh.Text.ToUpper();
                System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
                SQLCmd.CommandText = "SELECT CICD10,VViet FROM DMICD10 WHERE CICD10 = '" + txtMaICD_BenhChinh.Text + "'";
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
                    txtTenICD_KhoaDieuTri_BC.Text = txtMaICD_BenhChinh.Text = "";
                    MessageBox.Show("Không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                dr.Close();
                SQLCmd.Dispose();
            }
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
                else
                {
                    txtTenICD_KhoaDieuTri_BP.Text = txtMaICD_BenhPhu.Text = "";
                    MessageBox.Show("Không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                dr.Close();
                SQLCmd.Dispose();
            }
        }

        private void cmdICD_KhoaDieuTri_BP_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.Tien_ich.frmTraCuuICD fr = new NamDinh_QLBN.Forms.Tien_ich.frmTraCuuICD();
            if (fr.ShowDialog() == DialogResult.OK)
            {
                txtMaICD_BenhPhu.Text = fr._MaICD;
                txtTenICD_KhoaDieuTri_BP.Text = fr._TenICD;
            }

        }

        private void txtMaICD_BenhChinh_Validated(object sender, EventArgs e)
        {
            txtMaICD_BenhChinh_KeyUp(null, null);
        }

        private void cmbBuong_TextChanged(object sender, EventArgs e)
        {
            if (cmbBuong.Tag.ToString() == "0") return;
            if (cmbBuong.SelectedIndex == -1) { cmbGiuong.ClearItems(); return; }
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
            try
            {
                SQLCmd.CommandText = "SELECT * FROM DMGIUONGBENH WHERE sundung = 1 and  ID_Buong=" + Global.GetCode(cmbBuong) + " and makhoa ='" + Global.GetCode(cmbKhoa) + "'";
                System.Data.SqlClient.SqlDataReader dr = SQLCmd.ExecuteReader();
                cmbGiuong.ClearItems();
                while (dr.Read())
                {
                    cmbGiuong.AddItem(string.Format("{0};{1}", dr["ID_Giuong"], dr["TenGiuong"]));
                }
                cmbGiuong.SelectedIndex = -1;
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
        private void thaydoituyen(int tuyen)
        {

        }

        private bool ChiphiBenhNhan()
        {
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
            System.Data.SqlClient.SqlDataReader dr;
            SQLCmd.CommandText = string.Format("select top 1 1 from NAMDINH_QLBN.dbo.BENHNHAN_PHIEUDIEUTRI a inner join namdinh_qlbn.dbo.phieudieutri_chitiet b on a.sophieu = b.sophieu where Mavaovien = '{0}' and a.SoPhieu like N'%NT%'", lblMaKhamBenh.Text);
            dr = SQLCmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Close();
                return true;
            }
            else
            {
                dr.Close();
                return false;
            }
        }
        private void btn_XoaBN_Click(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
            System.Data.SqlClient.SqlDataReader dr;
            if (raDangDieuTri.Checked && Global.glbUName == "gd.hoa")
            {
                if (ChiphiBenhNhan() == true)
                {
                    MessageBox.Show("Đã có chi phí trong khoa không xóa được bệnh nhân");
                    return;
                }
                else
                {
                    try
                    {
                        if (MessageBox.Show("Bạn muốn bạn muốn xóa bệnh nhân này không", "Thông báo.", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            SQLCmd.CommandText = string.Format("update NAMDINH_KHAMBENH.dbo.tblKHAMBENH_KQDVKHAM set HuongGQ = 1, DaNhapVien =0, Tuchoitiepnhan = 0 from NAMDINH_KHAMBENH.dbo.tblKHAMBENH_KQDVKHAM a inner join NAMDINH_QLBN.dbo.BENHNHAN_CHITIET b on a.MaKhambenh = b.MaKhamBenh where b.MaVaoVien = '{0}'"
                                + " update NAMDINH_VIENPHI.dbo.tblThukyquy set MaVaovien = b.MaKhamBenh,tblThukyquy.Masokham = b.MaKhamBenh from NAMDINH_VIENPHI.dbo.tblThukyquy  a inner join NAMDINH_QLBN.dbo.BENHNHAN_CHITIET b on a.MaVaovien = b.MaVaoVien where a.MaVaovien = '{0}'"
                                + " delete from NAMDINH_QLBN.dbo.PHIEUDIEUTRI_CHITIET where sophieu in (select SoPhieu from NAMDINH_QLBN.dbo.BENHNHAN_PHIEUDIEUTRI where MaVaoVien = '{0}')"
                                + " delete from NAMDINH_QLBN.dbo.BENHNHAN_PHIEUDIEUTRI where MaVaoVien  = '{0}'"
                                + " delete from NAMDINH_QLBN.dbo.benhnhan_khoa where MaVaoVien  = '{0}'"
                                + " delete from NAMDINH_QLBN.dbo.BENHNHAN_DOITUONG where MaVaoVien  = '{0}'"
                                + " delete from NAMDINH_QLBN.dbo.BENHNHAN_CHITIET where MaVaoVien  = '{0}'"
                                + " ", lblMaKhamBenh.Text);
                            SQLCmd.ExecuteNonQuery();
                        }
                        fg.RemoveItem(fg.Row);
                    }
                    catch
                    {

                    }
                    finally { }

                }
                Clear_Data();
            }
            else
            {
                btn_XoaBN.Enabled = false;
                MessageBox.Show("Không sử dụng được chức năng này");
                return;
            }

        }

        private void tsmBenhNhan_Click(object sender, EventArgs e)
        {
            if (this.fgBuongGiuong[this.fgBuongGiuong.Row, "ID_Giuong"] == "") { MessageBox.Show("Chưa chọ giường để xem"); return; };
            string tenbenhnhan = "";
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
            System.Data.SqlClient.SqlDataReader dr;
            SQLCmd.CommandText = String.Format("select b.HoTen + N' : Sinh năm:' + convert(nvarchar(4),b.Namsinh) as TenBenhNhan from BENHNHAN_CHITIET a inner join NAMDINH_QLBN.dbo.BENHNHAN b on a.MaBenhNhan = b.MaBenhNhan "
                + "  inner join NAMDINH_QLBN.dbo.ViewKHOAHIENTAI c on c.MaVaoVien = a.MaVaoVien"
                + " where a.buong = {0} and a.giuong = {1} and c.makhoa = '{2}' and a.daravien = 0 ", this.fgBuongGiuong[this.fgBuongGiuong.Row, "ID_Buong"], this.fgBuongGiuong[this.fgBuongGiuong.Row, "ID_Giuong"], Global.GetCode(cmbKhoa));
            dr = SQLCmd.ExecuteReader();
            while (dr.Read())
            {
                tenbenhnhan = tenbenhnhan + dr["TenBenhNhan"] + "\n";
            }
            MessageBox.Show(tenbenhnhan, this.fgBuongGiuong[this.fgBuongGiuong.Row, "TenBuong"].ToString() + " " + this.fgBuongGiuong[this.fgBuongGiuong.Row, "TenGiuong"].ToString(), MessageBoxButtons.OK);
            dr.Close();
            SQLCmd.Dispose();
        }

        private void cmbGiuong_TextChanged(object sender, EventArgs e)
        {
            //try
            //{

            //}
            //catch
            //{

            //}

            //try
            //{
            //    string s = lblMaKhamBenh.Text;
            //    System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
            //    System.Data.SqlClient.SqlDataReader dr;
            //    SQLCmd.CommandText = string.Format("SELECT COUNT(*) AS SL FROM BENHNHAN bn INNER JOIN BENHNHAN_CHITIET bnct ON bn.MABENHNHAN = bnct.MABENHNHAN "
            //                                    + " inner join ViewKHOAHIENTAI khoa on khoa.MaVaoVien = bnct.MaVaoVien"
            //                                    + " INNER JOIN NAMDINH_QLBN.DBO.DMGIUONGBENH GB ON GB.ID_Buong = bnct.Buong  and BNCT.Giuong = gb.ID_Giuong and khoa.MaKhoa = gb.MaKhoa"
            //                                    + " WHERE bnct.Buong = {0}  AND GB.MaKhoa = '{1}' and BNCT.Giuong = {2}  and bnct.daravien = 0", Global.GetCode(cmbBuong), Global.GetCode(cmbKhoa), Global.GetCode(cmbGiuong));
            //    dr = SQLCmd.ExecuteReader();
            //    while (dr.Read())
            //    {
            //        TxtNamGhep.Value = int.Parse(dr["SL"].ToString());
            //    }
            //    dr.Close();
            //    SQLCmd.Dispose();
            //}
            //catch
            //{

            //}
            //finally
            //{

            //}

        }

        private void cmbGiuong_SelChange(object sender, CancelEventArgs e)
        {
            //try
            //{
            //    for (int row = 0; row < fgBuongGiuong.Rows.Count; row++)
            //    {
            //        if (Global.GetCode(cmbBuong) == fgBuongGiuong[row, "ID_Buong"].ToString() && Global.GetCode(cmbGiuong) == fgBuongGiuong[row, "ID_Giuong"].ToString())
            //        {
            //            MessageBox.Show("Hiện tại đã có bệnh nhân");
            //        }
            //    }
            //}
            //catch
            //{

            //}
        }
    }
}