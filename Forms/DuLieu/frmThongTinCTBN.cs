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
    public partial class frmThongTinCTBN : Form
    {
        public frmThongTinCTBN()
        {
            InitializeComponent();
        }

        private void cmdThoat_Click(object sender, EventArgs e)
        {
            this.Close();
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

            cmbDoituongBN1.ClearItems();
            cmbDoituongBN1.AddItem(String.Format("{1}|{0}", "", "------ Tất cả các đối tượng ------"));
            SQLCmd.CommandText = "Select MaDT, TenDT from DMDoiTuongBN order by MaDT";
            dr = SQLCmd.ExecuteReader();
            while (dr.Read())
            {
                cmbDoituongBN1.AddItem(String.Format("{1}|{0}", dr["MaDT"], dr["TenDT"]));
            }
            dr.Close();
            cmbDoituongBN1.SelectedIndex = 0;

            cmbDTBHXH.ClearItems();
            cmbDTBHXH.AddItem(String.Format("{1}|{0}", "", "------ Tất cả các đối tượng BHXH ------"));
            SQLCmd.CommandText = "Select MaDT, MaDT + ' - ' + TenDT as TenDT from DMDTTHE_BHYT order by MaDT";
            dr = SQLCmd.ExecuteReader();
            cmbDTBHXH.Tag = "1";
            while (dr.Read())
            {
                cmbDTBHXH.AddItem(String.Format("{1}|{0}", dr["MaDT"], dr["TenDT"]));
            }
            dr.Close();
            cmbDTBHXH.SelectedIndex = 0;
            dtNgayRVDen.Value = Global.NgayLV.AddDays(1);
            dtNgayRVTu.Value = new DateTime(Global.NgayLV.Year, Global.NgayLV.Month, 1);
        }

        private void Load_DSBenhNhan()
        {
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            string MaKhoa = cmbKhoa.Columns[1].CellText(cmbKhoa.SelectedIndex);
            string MaDT = cmbDoituongBN1.Columns[1].CellText(cmbDoituongBN1.SelectedIndex);
            string MaDTBHXH = cmbDTBHXH.Columns[1].CellText(cmbDTBHXH.SelectedIndex);
            SQLCmd.CommandText = string.Format("SELECT a.MaBenhNhan,b.MaVaoVien,HoTen,Year(getDate())-NamSinh As Tuoi,case when GioiTinh = 1 "
                                        + " then N'Nam' else N'Nử' end Gioi,CASE GioiTinh WHEN 1 THEN 'Nam' ELSE N'Nữ' END As TenGT,DoiTuong,"
                                        + " TenDT,SoHSBA,NgayVaoVien,DiaChi,GtriTu,GTriDen,MaDoiTuongBHXH +' - '+ SoThe +' - '+ d.MaNoiCap as SoThe,Tennoicap as NoiGioiThieu,TenBuong, TenGiuong,NgayRaVien,ChanDoan,TenBHYTCap as NoiCapThe  "
                                        + " FROM ((((((BENHNHAN a INNER JOIN BENHNHAN_CHITIET b ON a.MaBenhNhan=b.MaBenhNhan)"
                                        + " INNER JOIN ViewKHOAHIENTAI c ON b.MaVaoVien=c.MaVaoVien)"
                                        + " INNER JOIN ViewDOITUONGHIENTAI d ON b.MaVaoVien=d.MaVaoVien)"
                                        + " LEFT JOIN DMDOITUONGBN e ON d.DoiTuong=e.MaDT)"
                                        + " LEFT JOIN DMBUONGBENH ON b.Buong=DMBUONGBENH.ID_Buong and DMBUONGBENH.MaKhoa = '" + MaKhoa + "') "
                                        + " LEFT JOIN DMGIUONGBENH ON b.Giuong=DMGIUONGBENH.ID_Giuong and DMGIUONGBENH.MaKhoa = '" + MaKhoa + "' and DMGIUONGBENH.ID_Buong = DMBUONGBENH.Id_Buong) "
                                        + " LEFT JOIN NAMDINH_SYSDB.dbo.DMNOIDKKCBBD_BHYT a1 ON d.MaNoiCap=a1.Manoicap "
                                        + " WHERE C.MaKhoa = '{0}' "
                                        + " AND B.MaBenhNhan LIKE '{1}%' AND SOHSBA LIKE '{2}%'"
                                        + " AND E.MaDT LIKE '{3}%' AND B.MaDTBHYT LIKE '{4}%'"
                                        + " AND A.HOTEN LIKE N'%{5}%' ", MaKhoa, 
                                        txtMaBNTK.Text.Replace(" ", ""), txtSoHSBA1.Text, MaDT, MaDTBHXH, txtHoTenTK.Text);
            dtNgayRVDen.ReadOnly = dtNgayRVTu.ReadOnly = false;
            if (rdTatCa.Checked)
            {
                dtNgayRVDen.ReadOnly = dtNgayRVTu.ReadOnly = true;
                SQLCmd.CommandText += string.Format(" Order by HoTen");
            }
            if (rdChuaRV.Checked)
            {
                SQLCmd.CommandText += string.Format(" AND DaRaVien=0 And c.MaKhoa = '{0}' order by HoTen", cmbKhoa.Columns[1].CellText(cmbKhoa.SelectedIndex));
            }
            if (rdDaRV.Checked)
            {
                SQLCmd.CommandText += string.Format(" AND DaRaVien=1 And c.MaKhoa = '{0}' AND NgayRaVien between '", cmbKhoa.Columns[1].CellText(cmbKhoa.SelectedIndex)) + string.Format("{0:MM/dd/yyyy}", dtNgayRVTu.Value) + "' and '" + string.Format("{0:MM/dd/yyyy}", dtNgayRVDen.Value) + "' order by HoTen";
            }

            if (raChuyenKhoa.Checked)
            {

                SQLCmd.CommandText = string.Format(" select BENHNHAN_CHITIET.MaBenhNhan,BENHNHAN_CHITIET.SoHSBA,BENHNHAN_CHITIET.MaVaoVien,BENHNHAN.HoTen , "
                                                  + " Year(GetDate())-BENHNHAN.NamSinh as Tuoi,  CASE BENHNHAN.GioiTinh WHEN '1' THEN 'Nam' "
                                                  + " ELSE N'Nử' END AS Gioi,  DMDOITUONGBN.MaDT AS MaDTBN, DMDOITUONGBN.TenDT,NgayVaoVien,"
                                                  + " TrangThai  ,SoHSBA,  BENHNHAN_CHITIET.MaDTBHYT,DMDTTHE_BHYT.TenDT as TENDTBHYT, "
                                                  + " DMDOITUONGBN.TenDT AS DOITUONG,DMKHOAPHONG.TENKHOA,DiaChi,GtriTu,GTriDen,MaDoiTuongBHXH +' - '+ SoThe +' - '+ ViewDOITUONGHIENTAI.MaNoiCap as SoThe,Tennoicap as NoiGioiThieu,TenBuong, TenGiuong,NgayRaVien,ChanDoan_KhoaDT as ChanDoan, TenBHYTCap as NoiCapThe      "
                                                  + " FROM (((((((BENHNHAN INNER JOIN BENHNHAN_CHITIET ON BENHNHAN.MaBenhNhan=BENHNHAN_CHITIET.MaBenhNhan) "
                                                  + " INNER JOIN VIEWDOITUONGHIENTAI ON BENHNHAN_CHITIET.MaVaoVien= VIEWDOITUONGHIENTAI.MaVaoVien)"
                                                  + " INNER JOIN DMDOITUONGBN ON VIEWDOITUONGHIENTAI.DoiTuong=MaDT) "
                                                  + " LEFT JOIN DMBUONGBENH ON BENHNHAN_CHITIET.Buong=DMBUONGBENH.ID_Buong and DMBUONGBENH.MaKhoa = '" + MaKhoa + "') "
                                                  + " LEFT JOIN DMGIUONGBENH ON BENHNHAN_CHITIET.Giuong=DMGIUONGBENH.ID_Giuong and DMGIUONGBENH.MaKhoa = '" + MaKhoa + "' and DMGIUONGBENH.ID_Buong = DMBUONGBENH.Id_Buong) "
                                                  + " LEFT JOIN NAMDINH_SYSDB.dbo.DMNOIDKKCBBD_BHYT a ON ViewDOITUONGHIENTAI.MaNoiCap=a.Manoicap) "
                                                  + " INNER JOIN (SELECT BENHNHAN_KHOA.MaVaoVien,Q1.MaKhoa As KhoaDi,"
                                                  + " BENHNHAN_KHOA.MaKhoa As KhoaDen,BENHNHAN_KHOA.NgayChuyen AS NgayChuyenDi FROM BENHNHAN_KHOA "
                                                  + " INNER JOIN  (SELECT BENHNHAN_KHOA.* FROM BENHNHAN_KHOA)Q1  ON BENHNHAN_KHOA.MaVaoVien=Q1.MaVaoVien "
                                                  + " AND  BENHNHAN_KHOA.LanChuyenKhoa=Q1.LanChuyenKhoa+1) Q2 "
                                                  + " ON BENHNHAN_CHITIET.MaVaoVien=Q2.MaVaoVien  LEFT JOIN DMDTTHE_BHYT ON BENHNHAN_CHITIET.MaDTBHYT=DMDTTHE_BHYT.MaDT) "
                                                  + " INNER JOIN DMKHOAPHONG ON Q2.KhoaDen=DMKHOAPHONG.MaKhoa "
                                                  + " WHERE Q2.KHoaDi='{0}' AND Q2.NgayChuyenDi BETWEEN '{1:MM/dd/yyyy}' AND '{2:MM/dd/yyyy}' "
                                                  + " AND BENHNHAN_CHITIET.MaBenhNhan LIKE '{3}%' AND SOHSBA LIKE '{4}%' AND DMDOITUONGBN.MaDT LIKE '{5}%'  "
                                                  + " AND BENHNHAN_CHITIET.MaDTBHYT LIKE '{6}%' AND BENHNHAN.HOTEN LIKE N'%{7}%' order by HoTen", cmbKhoa.Columns[1].CellText(cmbKhoa.SelectedIndex), dtNgayRVTu.Value, dtNgayRVDen.Value, txtMaBNTK.Text.Replace(" ", ""),
                                                  txtSoHSBA1.Text, MaDT, MaDTBHXH, txtHoTenTK.Text);
            }
            dr = SQLCmd.ExecuteReader();
            fgDanhSach.Tag = "0";
            fgDanhSach.Rows.Count = 1;
            fgDanhSach.ClipSeparators = "|;";
            fgDanhSach.Redraw = false;
            while (dr.Read())
            {
                fgDanhSach.AddItem(string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6:dd/MM/yyyy HH:mm}|{7}|{8:dd/MM/yyyy}|{9:dd/MM/yyyy}|{10}|{11}|{12}|{13}|{14:dd/MM/yyyy HH:mm}|{15}|{16}|{17}", fgDanhSach.Rows.Count,
                    dr["MaVaoVien"],
                    dr["HoTen"],
                    dr["Tuoi"],
                    dr["Gioi"].ToString(),
                    dr["TenDT"],
                    dr["NgayVaoVien"],
                    dr["DiaChi"],
                    dr["GtriTu"],
                    dr["GTriDen"],
                    dr["SoThe"],
                    dr["NoiGioiThieu"],
                    dr["Tenbuong"],
                    dr["TenGiuong"],
                    dr["NgayRaVien"],
                    dr["ChanDoan"],
                    dr["MaBenhNhan"],
                    dr["NoiCapThe"]));
            }
            dr.Close();
            fgDanhSach.AutoSizeCols();
            fgDanhSach.Redraw = true;
            fgDanhSach.Tag = "1";
            lbTong.Text = "Tổng số bệnh nhân: " + String.Format("{0}", fgDanhSach.Rows.Count - 1);
            cmbLanVaoVien.Tag = 0;
            SoLanVaoVien();
            cmbLanVaoVien.Tag = 1;
            SQLCmd.Dispose();
        }

        private void SoLanVaoVien()
        {
            if (fgDanhSach.Row < 0) return;
            if (fgDanhSach.Rows.Count <= 1) return;
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            try
            {
                SQLCmd.CommandText = String.Format("Select MaVaoVien From BenhNhan_ChiTiet Where MaBenhNhan={0}", fgDanhSach.GetDataDisplay(fgDanhSach.Row, "MaBenhNhan"));
                dr = SQLCmd.ExecuteReader();
                int i = 1;
                cmbLanVaoVien.ClearItems();
                while (dr.Read())
                {
                    cmbLanVaoVien.AddItem(String.Format("{0};{1}","Lần " + i.ToString(),dr["MaVaoVien"]));
                    i++;
                }
                dr.Close();
                cmbLanVaoVien.SelectedIndex = i - 2;
                txtMaBN.Text = cmbLanVaoVien.Columns[1].CellText(cmbLanVaoVien.SelectedIndex);
            }
            catch
            {

            }
            finally
            {
            }
        }

        private void LoatChiPhi()
        {
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            try
            {
                if (tabControl1.SelectedIndex == 0)
                {
                    //Hien thi chi phi da su dung
                    fgChiPhi.Tree.Column = 3;
                    if (raNhomTN.Checked)
                    {
                        SQLCmd.CommandText = String.Format("SELECT CC.*,DM.TENDICHVU,DM.DVT,DMLOAIDICHVU.TENLOAIDICHVU FROM"
                            + " (SELECT AA.*,CT.MADICHVU,CT.LOAIDICHVU,CT.SOLUONG,CT.TINHPHI,CT.KETQUA FROM"
                            + " (SELECT * FROM BENHNHAN_PHIEUDIEUTRI WHERE MAVAOVIEN = '{0}') AA"
                            + " INNER JOIN PHIEUDIEUTRI_CHITIET CT ON CT.SOPHIEU = AA.SOPHIEU) CC"
                            + " INNER JOIN DMDICHVU DM ON DM.MADICHVU = CC.MADICHVU"
                            + " INNER JOIN DMLOAIDICHVU ON DMLOAIDICHVU.MALOAIDICHVU = CC.LOAIDICHVU ORDER BY NGAYCHIDINH,"
                            + " TENLOAIDICHVU,TENDICHVU",txtMaBN.Text);
                    }
                    if (raTongCP.Checked)
                    {
                        SQLCmd.CommandText = String.Format("SELECT BB.*,DMLOAIDICHVU.TENLOAIDICHVU,DM.TENDICHVU,DM.DVT,'' AS NGAYCHIDINH,'' AS KETQUA FROM"
                            + " (SELECT MADICHVU,LOAIDICHVU,SUM(SOLUONG) AS SOLUONG FROM"
                            + " (SELECT * FROM BENHNHAN_PHIEUDIEUTRI WHERE MAVAOVIEN ='{0}') AA"
                            + " INNER JOIN PHIEUDIEUTRI_CHITIET CT ON CT.SOPHIEU = AA.SOPHIEU"
                            + " GROUP BY MADICHVU,MADICHVU,LOAIDICHVU) BB"
                            + " INNER JOIN DMLOAIDICHVU ON DMLOAIDICHVU.MALOAIDICHVU = BB.LOAIDICHVU"
                            + " INNER JOIN DMDICHVU DM ON DM.MADICHVU = BB.MADICHVU ORDER BY TENLOAIDICHVU,TENDICHVU", txtMaBN.Text);
                    }

                    dr = SQLCmd.ExecuteReader();
                    fgChiPhi.Rows.Fixed = 0;
                    fgChiPhi.Rows.Count = 1;
                    fgChiPhi.Rows.Fixed = 1;
                    fgChiPhi.Cols[4].DataType = typeof(Decimal);
                    fgChiPhi.Cols[4].Format = "#,##0.##";
                    while (dr.Read())
                    {
                        fgChiPhi.Rows.Add();
                        fgChiPhi[fgChiPhi.Rows.Count - 1, 0] = fgChiPhi.Rows.Count;
                        fgChiPhi[fgChiPhi.Rows.Count - 1, 1] = String.Format("{0:dd/MM/yyyy}", dr["NgayChiDinh"]);
                        fgChiPhi[fgChiPhi.Rows.Count - 1, 2] = dr["TenLoaiDichVu"];
                        fgChiPhi[fgChiPhi.Rows.Count - 1, 3] = dr["TenDichVu"];
                        fgChiPhi[fgChiPhi.Rows.Count - 1, 4] = dr["SoLuong"];
                        fgChiPhi[fgChiPhi.Rows.Count - 1, 5] = dr["DVT"];
                        fgChiPhi[fgChiPhi.Rows.Count - 1, 6] = dr["KetQua"];
                    }
                    dr.Close();
                    fgChiPhi.Cols[1].Visible = fgChiPhi.Cols[2].Visible = false;
                    fgChiPhi[0, 0] = "STT";
                    fgChiPhi[0, 1] = "Ngày chỉ định";
                    fgChiPhi[0, 2] = "Tên loại dịch vụ";
                    fgChiPhi[0, 3] = "Tên dịch vụ";
                    fgChiPhi[0, 4] = "Số lượng";
                    fgChiPhi[0, 5] = "Đơn vị tính";
                    fgChiPhi.AutoSizeCols(0);
                    if (raNhomTN.Checked)
                    {

                        fgChiPhi.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.None, 0, 1, 0, "{0}");
                        fgChiPhi.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.None, 1, 2, -1, "{0}");
                    }
                    else
                    {
                        fgChiPhi.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.None, 0, 2, -1, "{0}");
                    }
                }
                if (tabControl1.SelectedIndex == 1)
                {
                    //Hien thi thong tin hành chính,vao và ra viện
                    EmptyCtr();
                    SQLCmd.CommandText = String.Format("SELECT CC.*,CASE WHEN GIOITINH = 0 THEN N'Nữ' ELSE N'Nam' END AS GIOI,"
                        + " VIEWKHOAHIENTAI.CHANDOAN AS CHANDOANKHOACHUYENDEN,DMDANTOC.TENDT,DMDOITUONGBN.TENDT,DMTRUCTIEPVAO.TENTTV FROM"
                        + " (SELECT BB.*,V.DOITUONG,V.GTRITU,V.GTRIDEN,V.SOTHE,V.MADOITUONGBHXH,"
                        + " V.MANOICAP,DMDANTOC.TENDT,VV.MAKHOA,VV.CHANDOAN AS CHANDOANKHOADIEUTRI,VV.MAXLAN AS KHOAHIENTAI FROM"
                        + " (SELECT B.*,AA.MAVAOVIEN,AA.DIACHI,AA.LIENHE,AA.NGHENGHIEP,AA.NGAYRAVIEN,AA.BENHCHINH_RAVIEN,"
                        + " AA.BENHPHU_RAVIEN,AA.LOIDAN_RAVIEN,AA.GHICHU,AA.SoHSBA,AA.NGAYKHAM,AA.NGAYVAOVIEN,AA.TRUCTIEPVAO,AA.BUONG,AA.GIUONG FROM"
                        + " (SELECT * FROM BENHNHAN_CHITIET A WHERE MAVAOVIEN = '{0}') AA"
                        + " INNER JOIN BENHNHAN B ON B.MABENHNHAN = AA.MABENHNHAN) BB"
                        + " INNER JOIN viewDOITUONGHIENTAI V ON V.MAVAOVIEN = BB.MAVAOVIEN"
                        + " LEFT JOIN DMDANTOC ON DMDANTOC.MADT = BB.MADANTOC"
                        + " INNER JOIN VIEWKHOAHIENTAI VV ON VV.MAVAOVIEN = BB.MAVAOVIEN"
                        + " WHERE MAKHOA = '{1}') CC"
                        + " LEFT JOIN VIEWKHOAHIENTAI ON VIEWKHOAHIENTAI.MAKHOA = CC.MAKHOA AND MAXLAN = CC.KHOAHIENTAI - 1 AND "
                        + " VIEWKHOAHIENTAI.MAVAOVIEN = CC.MAVAOVIEN"
                        + " LEFT JOIN DMDANTOC ON DMDANTOC.MADT = CC.MADANTOC"
                        + " LEFT JOIN DMDOITUONGBN ON DMDOITUONGBN.MADT = CC.DOITUONG"
                        + " LEFT JOIN DMTRUCTIEPVAO ON DMTRUCTIEPVAO.MATTV = CC.TRUCTIEPVAO",txtMaBN.Text,cmbKhoa.Columns[1].CellText(cmbKhoa.SelectedIndex));
                    dr = SQLCmd.ExecuteReader();
                    while (dr.Read())
                    {
                        txt1ChanDoan_KhoaDieuTri.Text = dr["ChanDoanKhoaDieuTri"].ToString();
                        txt1ChanDoan_NoiChuyenDen.Text = dr["ChanDoanKhoaChuyenDen"].ToString();
                        txt1DiaChi.Text = dr["DiaChi"].ToString();
                        txt1DiaChiLH.Text = dr["LienHe"].ToString();
                        txt1GhiChu.Text = dr["GhiChu"].ToString();
                        txt1HanTheDen.Value = dr["GTriden"];
                        txt1HanTheTu.Value = dr["GTritu"];
                        txt1HoTen.Text = dr["HoTen"].ToString();
                        txt1LoiDan.Text = dr["LoiDan_RaVien"].ToString();
                        txt1MaBenhAn.Text = dr["SoHSBA"].ToString();
                        txt1MaDTBHYT.Text = dr["MADOITUONGBHXH"].ToString();
                        txt1MaNoiCapBHYT.Text = dr["MaNoiCap"].ToString();
                        txt1NamSinh.Value = int.Parse(dr["NamSinh"].ToString());
                        txt1NgayRaVien.Value = dr["NgayRaVien"];
                        txt1NgaySinh.Value = int.Parse(dr["NgaySinh"].ToString());
                        txt1NgayVaoKhoa.Value = dr["NgayKham"];
                        txt1NgayVaoVien.Value = dr["NgayVaoVien"];
                        txt1NgheNghiep.Text = dr["NgheNghiep"].ToString();
                        txt1SoTheBHYT.Text = dr["SoThe"].ToString();
                        txt1TenBC.Text = dr["BenhChinh_RaVien"].ToString();
                        txt1TenBP.Text = dr["BenhPhu_RaVien"].ToString();
                        txt1ThangSinh.Value = int.Parse(dr["ThangSinh"].ToString());
                        txt1GioiTinh.Text = dr["GIOI"].ToString();
                        txt1DanToc.Text = dr["TENDT"].ToString();
                        txt1DoiTuong.Text = dr["TenDT"].ToString();
                        txt1TrucTiepVao.Text = dr["TENTTV"].ToString();
                        txt1Buong.Text = dr["Buong"].ToString();
                        txt1Giuong.Text = dr["Giuong"].ToString();
                    }
                    dr.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                SQLCmd.Dispose();
            }
        }

        private void EmptyCtr()
        {
            txt1Buong.Text = txt1ChanDoan_KhoaDieuTri.Text = txt1ChanDoan_KKB.Text = txt1ChanDoan_NoiChuyenDen.Text = txt1DanToc.Text = txt1DiaChi.Text =
                txt1DiaChiLH.Text = txt1DoiTuong.Text = txt1GhiChu.Text = txt1GioiTinh.Text = txt1Giuong.Text = txt1HanTheDen.Text = txt1HanTheTu.Text =
                txt1HoTen.Text = txt1LoiDan.Text = txt1MaBenhAn.Text = txt1MaDTBHYT.Text = txt1MaNoiCapBHYT.Text = txt1NgayRaVien.Text =
                txt1NgayVaoKhoa.Text = txt1NgayVaoVien.Text = txt1NgheNghiep.Text = txt1NoiGioiThieu.Text = txt1SoTheBHYT.Text = txt1TenBC.Text =
                txt1TenBP.Text = txt1TrucTiepVao.Text = "";
            txt1NamSinh.Value = txt1ThangSinh.Value = txt1NgaySinh.Value = 0;
        }

        private void frmThongTinCTBN_Load(object sender, EventArgs e)
        {
            Global.wait("Đang tổng hợp dữ liệu");
            fgDanhSach.Tag = 0;
            fgChiPhi.Tag = 0;
            LoadDM();
            Load_DSBenhNhan();
            LoatChiPhi();
            C1.Win.C1FlexGrid.CellStyle cs = fgChiPhi.Styles[C1.Win.C1FlexGrid.CellStyleEnum.Subtotal0];
            cs.BackColor = Color.LightBlue;
            cs.ForeColor = Color.DarkBlue;
            Font f = new Font(cs.Font.FontFamily, 10, FontStyle.Bold);
            cs.Font = f;
            cs = fgChiPhi.Styles[C1.Win.C1FlexGrid.CellStyleEnum.Subtotal1];
            cs.BackColor = Color.Azure;
            cs.ForeColor = Color.DarkBlue;
            fgDanhSach.Tag = 1;
            fgChiPhi.Tag = 1;
            Global.nowait();
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

        private void rdTatCa_CheckedChanged(object sender, EventArgs e)
        {
            rdChuaRV_CheckedChanged(sender, e);
        }

        private void rdDaRV_CheckedChanged(object sender, EventArgs e)
        {
            rdChuaRV_CheckedChanged(sender, e);
        }

        private void raChuyenKhoa_CheckedChanged(object sender, EventArgs e)
        {
            rdChuaRV_CheckedChanged(sender, e);
        }

        private void cmdTimKiem_Click(object sender, EventArgs e)
        {
            Global.wait("Đang tổng hợp dữ liệu");
            Load_DSBenhNhan();
            Global.nowait();
        }

        private void fgDanhSach_AfterRowColChange(object sender, C1.Win.C1FlexGrid.RangeEventArgs e)
        {
            if (fgDanhSach.Tag.ToString() == "0") return;
            if (fgDanhSach.Rows.Count <= 1) return;
            if (fgChiPhi.Tag.ToString() == "0") return;
            txtHoTen.Text = fgDanhSach.GetDataDisplay(fgDanhSach.Row, "TenBN");
            cmbLanVaoVien.Tag = 0;
            SoLanVaoVien();
            cmbLanVaoVien.Tag = 1;
            txtTuoi.Text = fgDanhSach.GetDataDisplay(fgDanhSach.Row, "Tuoi");
            txtGioiTinh.Text = fgDanhSach.GetDataDisplay(fgDanhSach.Row, "GioiTinh");

            tabControl1_SelectedIndexChanged(sender, e);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (fgChiPhi.Tag.ToString() == "0") return;
            if (fgDanhSach.Tag.ToString() == "0") return;
            Global.wait("Đang tổng hợp chi phí");
            LoatChiPhi();
            Global.nowait();
        }

        private void raNhomTN_CheckedChanged(object sender, EventArgs e)
        {
            tabControl1_SelectedIndexChanged(sender,e);
        }

        private void cmbLanVaoVien_TextChanged(object sender, EventArgs e)
        {
            if (cmbLanVaoVien.Tag.ToString() == "0") return;
            txtMaBN.Text = cmbLanVaoVien.Columns[1].CellText(cmbLanVaoVien.SelectedIndex);
            tabControl1_SelectedIndexChanged(sender, e);
        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            if (txtMaBN.Text == "0") { return; }
            if (fgDanhSach.Rows.Count <= 1) return;
            string MaVaoVien = txtMaBN.Text;

            Global.wait("Đang chuẩn bị dữ liệu...!");
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            SQLCmd.CommandText = string.Format("SELECT a.DoiTuongBN,d.TenDT,e.MaKhoa,f.TenKhoa,a.LoaiDichVu,b.TenLoaiDichVu,a.MaDichVu,c.TenDichVu,c.DVT,Sum(SoLuong * SoThang) As SL,case when a.TinhPhi = 0 then a.DonGia else 0 end as DonGia,Sum(SoLuong * SoThang * (case when a.tinhphi = 0 then a.DonGia else 0 end)) as ThanhTien "
                                        + " FROM ((((PHIEUDIEUTRI_CHITIET a INNER JOIN DMLOAIDICHVU b ON a.LoaiDichVu=b.MaLoaiDichVu) "
                                        + " INNER JOIN DMDICHVU c ON a.MaDichVu=c.MaDichVu) "
                                        + " INNER JOIN DMDOITUONGBN d ON a.DoiTuongBN = d.MaDT) "
                                        + " INNER JOIN BENHNHAN_PHIEUDIEUTRI e ON a.SoPhieu=e.SoPhieu AND e.MaVaoVien='{0}'  ) "
                                        + " INNER JOIN DMKHOAPHONG f ON e.MaKhoa=f.MaKhoa "
                                        + " GROUP BY a.DoiTuongBN,d.TenDT,e.MaKhoa,f.tenKhoa,a.LoaiDichVu,b.TenLoaiDichVu,a.MaDichVu,c.TenDichVu,c.DVT,a.DonGia,a.tinhphi  ", MaVaoVien);
            dr = SQLCmd.ExecuteReader();
            NamDinh_QLBN.Reports.rptBenhNhan_ChiPhi rpt = new NamDinh_QLBN.Reports.rptBenhNhan_ChiPhi(MaVaoVien, fgDanhSach[fgDanhSach.Row, 2].ToString(), fgDanhSach[fgDanhSach.Row, 3].ToString(), fgDanhSach[fgDanhSach.Row,4].ToString(), fgDanhSach[fgDanhSach.Row, 5].ToString(), fgDanhSach.GetData(fgDanhSach.Row, 6), fgDanhSach[fgDanhSach.Row, "DiaChi"].ToString(), fgDanhSach[fgDanhSach.Row, "HanTheTu"].ToString(), fgDanhSach[fgDanhSach.Row, "HanTheDen"].ToString(), fgDanhSach[fgDanhSach.Row, "SoTheBHYT"].ToString(), fgDanhSach[fgDanhSach.Row, "NoiCapThe"].ToString(), fgDanhSach[fgDanhSach.Row, "Buong"].ToString(), fgDanhSach[fgDanhSach.Row, "Giuong"].ToString(), fgDanhSach.GetData(fgDanhSach.Row, "NgayRaVien"), fgDanhSach[fgDanhSach.Row, "ChanDoan"].ToString(),fgDanhSach.GetDataDisplay(fgDanhSach.Row,"NoiGioiThieu"));
            rpt.DataSource = dr;
            rpt.Show();
            dr.Close();
            SQLCmd.Dispose();
            Global.nowait();
        }

        private void txtMaBenhNhan_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void cmdGiayRaVien_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Reports.rptGiayRaVien rpt = new NamDinh_QLBN.Reports.rptGiayRaVien(txtMaBN.Text);
            rpt.Show();
        }

        private void cmdGiayChuyenVien_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Reports.repPhieuChuyenVien rep = new NamDinh_QLBN.Reports.repPhieuChuyenVien(txtMaBN.Text);
            rep.Show();
        }
    }
}