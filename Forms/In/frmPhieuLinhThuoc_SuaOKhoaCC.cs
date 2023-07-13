﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GlobalModuls;
namespace NamDinh_QLBN.Forms.In
{
    public partial class frmPhieuLinhThuoc_SuaOKhoaCC : Form
    {
        private String MaDuyetThuoc = "";

        public frmPhieuLinhThuoc_SuaOKhoaCC()
        {
            InitializeComponent();
        }

        private void LoatData()
        {
            try
            {
                Global.wait("Đang tổng hợp dữ liệu ...");
                String Str = "",MaVaoVien = "",DieuKien="";
                int STT = 0, STT1 = 0;
                if (raNhomToanKhoa.Checked)
                {
                    if (chDaThucHien.Checked)
                    {
                    }
                    else
                    {
                        DieuKien = " and DaThucHien = 0 ";
                    }

                    if (cmbNhom.SelectedIndex == 1)
                    {
                        DieuKien += " and b.Nhom = 0 ";
                    }
                    else
                    {
                        if (cmbNhom.SelectedIndex == 2)
                        {
                            DieuKien += " AND b.Nhom = 1 ";
                        }
                    }
                    Str = String.Format("set dateformat dmy Select MaDichVu,TenDichVu,DVT,sum(SoLuong) as SoLuong,DathucHien,isnull(GhiChu,'') as GhiChu from"
                        + " (Select * from"
                        + " (SELECT a.MaDichVu,c.TenDichVu, c.DVT,Sum(SoLuong)AS SoLuong,A.DaThucHien,"
                        + " a.MaPhieuDuyet as GhiChu  "
                        + " FROM (PHIEUDIEUTRI_CHITIET a INNER JOIN BENHNHAN_PHIEUDIEUTRI b ON a. SoPhieu=b.SoPhieu AND A.MADICHVU NOT IN ('ONG-TCQ-0005','ONG-TCQ-0006','ONG-TCQ-0003','ONG-TCQ-0004')) "
                        + " INNER JOIN DMDICHVU c ON a.MaDichVu=c.MaDichVu and c.NhomThuoc != 'TCQ'"
                        + " WHERE a.MaNhom = " + Global.GetCode(cmbNhomLenCP) + " and b.MaKhoa = '{0}' AND a.LoaiDichVu in ('D01','D05') AND DateDiff(dd,b.NgayChiDinh,'{1:dd/MM/yyyy}') <= 0 and DateDiff(dd,b.NgayChiDinh,'{2:dd/MM/yyyy}') >= 0 " + DieuKien
                        + " GROUP BY c.TenDichVu,c.DVT,a.MaDichVu,A.DaThucHien,a.MaPhieuDuyet) aa"
                        + " Union ALL"
                        + " Select * from"
                        + " (Select dmDichVu.MaDichVu,TenDichVu,DVT,sum(SoLuong) as SoLuong,DaThucHien,"
                        + " bb.MaPhieuDuyet as GhiChu from"
                        + " (Select * from chiphi_thuthuat b Where b.MaNhom =" + Global.GetCode(cmbNhomLenCP) + " and b.MaKhoa = '{0}' AND b.LoaiDichVu in ('D01','D05') " + DieuKien
                        + " AND DateDiff(dd,b.NgayThucHien,'{1:dd/MM/yyyy}') <= 0 and DateDiff(dd,b.NgayThucHien,'{2:dd/MM/yyyy}') >= 0) BB"
                        + " Inner join dmDichVu on dmDichVu.MaDichVu =  bb.MaChiPhi and c.NhomThuoc != 'TCQ'"
                        + " Group by dmDichVu.MaDichVu,TenDichVu,DVT,DaThucHien,bb.MaPhieuDuyet) EE"
                        + " Union all"
                        + " select * from"
                        + " (select dmdichvu.MaDichVu,dmdichvu.tendichvu,dmdichvu.dvt,sum(b.soluong) as soluong,b.dathuchien,b.MaPhieuDuyet as GhiChu"
                        + " from namdinh_khambenh.dbo.tblChiPhi_DichVu b"
                        + " inner join dmdichvu on dmdichvu.madichvu = b.machiphi and c.NhomThuoc != 'TCQ'"
                        + " where datediff(dd,NgayThucHien,'{1:dd/MM/yyyy}') <= 0 and datediff(dd,NgayThucHien,'{2:dd/MM/yyyy}') >= 0 "
                        + " and b.LoaiChiPhi in ('D01','D05') and b.MaKhoaThucHien in ('{0}') " + DieuKien
                        + " group by dmdichvu.MaDichVu,dmdichvu.tendichvu,dmdichvu.dvt,b.dathuchien,b.MaPhieuDuyet) ff) dd"
                        + " Group by MaDichVu,TenDichVu,DVT,DathucHien,GhiChu order by right(GhiChu,9) desc,TenDichVu",
                        GlobalModuls.Global.GetCode(cmbKhoa),
                        txtTNgay.Value,txtDNgay.Value);
                }
                else
                {
                    Str = String.Format("set dateformat dmy Select DaThucHien,MaVaoVien,HoTen,MaDichVu,TenDichVu,DVT,isnull(GhiChu,'') as GhiChu,TT_HN,sum(SOLUONG) as SOLUONG from "
                           + " (SELECT MaPhieuDuyet as GhiChu,"
                           + " DaThucHien,DD.MaDichVu,TenDichVu,MaVaoVien,HoTen,DVT,SoLuong,0 as TT_HN"
                           + " FROM (SELECT CC.*,PH.LOAIDICHVU,PH.MADICHVU,PH.SOLUONG,PH.DONGIA,PH.GHICHU,PH.DOITUONGBN,PH.DATHUCHIEN,PH.MaPhieuDuyet"
                           + " FROM (SELECT BB.*,BENHNHAN_PHIEUDIEUTRI.SOPHIEU,BENHNHAN_PHIEUDIEUTRI.NGAYCHIDINH,BENHNHAN_PHIEUDIEUTRI.LOAIDT, "
                           + " BENHNHAN_PHIEUDIEUTRI.BACSYDT, BENHNHAN_PHIEUDIEUTRI.DIENBIENBENH,BENHNHAN_PHIEUDIEUTRI.YLENH,"
                           + " BENHNHAN_PHIEUDIEUTRI.CDCHAMSOC, BENHNHAN_PHIEUDIEUTRI.CDDINHDUONG,BENHNHAN_PHIEUDIEUTRI.MAKHOA,"
                           + " BENHNHAN_PHIEUDIEUTRI.NHOM FROM (SELECT AA.*,BENHNHAN_CHITIET.MAVAOVIEN "
                           + " FROM (SELECT * FROM BENHNHAN) AA  INNER JOIN BENHNHAN_CHITIET ON BENHNHAN_CHITIET.MABENHNHAN = AA.MABENHNHAN) BB "
                           + " INNER JOIN BENHNHAN_PHIEUDIEUTRI ON BENHNHAN_PHIEUDIEUTRI.MAVAOVIEN = BB.MAVAOVIEN "
                           + " WHERE BENHNHAN_PHIEUDIEUTRI.MAKHOA = '{0}') CC "
                           + " INNER JOIN PHIEUDIEUTRI_CHITIET PH ON PH.SOPHIEU = CC.SOPHIEU and MaNhom={1} AND PH.MADICHVU NOT IN ('ONG-TCQ-0005','ONG-TCQ-0006','ONG-TCQ-0003','ONG-TCQ-0004')"
                           + " WHERE  ", GlobalModuls.Global.GetCode(cmbKhoa), Global.GetCode(cmbNhomLenCP));
                    if (chDaThucHien.Checked)
                    {

                    }
                    else
                    {
                        Str += " PH.DATHUCHIEN = 0 AND ";
                    }
                    Str += String.Format("  PH.LOAIDICHVU in ('D01','D05')) DD"
                        + " INNER JOIN DMDICHVU ON DMDICHVU.MADICHVU = DD.MADICHVU and NhomThuoc != 'TCQ'"
                        + " WHERE DATEDIFF(DD,DD.NGAYCHIDINH,'{0:dd/MM/yyyy} 00:00:00') <= 0 and DATEDIFF(DD,DD.NGAYCHIDINH,'{1:dd/MM/yyyy} 00:00:00') >= 0",
                        txtTNgay.Value,txtDNgay.Value);
                    if (cmbNhom.SelectedIndex == 1)
                    {
                        Str += " AND DD.Nhom = 0 ";
                    }
                    else
                    {
                        if (cmbNhom.SelectedIndex == 2)
                        {
                            Str += " AND DD.Nhom = 1 ";
                        }
                    }
                    Str += String.Format(" Union all"
                           + " Select MaPhieuDuyet  as GhiChu,"
                           + " DaThucHien,MaDichVu,TenDichVu,MaVaoVien,HoTen,DVT,SoLuong,1 as TT_HN from"
                           + " (Select bb.*,benhnhan.hoten from"
                           + " (select aa.MaVaoVien,aa.MaChiPhi as MaDichVu,aa.SoLuong,aa.MaPhieuDuyet,aa.DaThucHien,dmdichvu.TenDichVu,dmdichvu.DVT,benhnhan_chitiet.mabenhnhan from"
                           + " (Select * from chiphi_thuthuat where MaNhom= " + Global.GetCode(cmbNhomLenCP) + " and loaidichvu in ('D01','D05') and makhoa='{0}' and DATEDIFF(DD,NgayThucHien,'{1:dd/MM/yyyy}') <= 0 and DATEDIFF(DD,NgayThucHien,'{2:dd/MM/yyyy}') >= 0",
                           GlobalModuls.Global.GetCode(cmbKhoa),
                           txtTNgay.Value,txtDNgay.Value);
                    if (chDaThucHien.Checked)
                    {

                    }
                    else
                    {
                        Str += " and DATHUCHIEN = 0 ";
                    }
                    if (cmbNhom.SelectedIndex == 1)
                    {
                        Str += " AND Nhom = 0 ";
                    }
                    else
                    {
                        if (cmbNhom.SelectedIndex == 2)
                        {
                            Str += " AND Nhom = 1 ";
                        }
                    }
                    Str += " ) aa inner join dmdichvu on dmdichvu.madichvu = aa.machiphi and dmdichvu.NhomThuoc != 'TCQ'"
                            + " inner join benhnhan_chitiet on benhnhan_chitiet.MaVaoVien = aa.MaVaoVien) bb"
                            + " inner join benhnhan on benhnhan.mabenhnhan = bb.mabenhnhan) cc";
                    Str += String.Format(" Union all "
                        + "select b.MaPhieuDuyet as GhiChu,b.dathuchien,b.MaChiPhi as MaDichVu,dmdichvu.tendichvu,b.MaKhamBenh as MaVaoVien,BenhNhan.TenBenhNhan as HoTen,"
                        + " dmdichvu.DVT, b.soluong,2 as TT_HN"
                        + " from namdinh_khambenh.dbo.tblChiPhi_DichVu b"
                        + " inner join dmdichvu on dmdichvu.madichvu = b.machiphi and dmdichvu.Nhomthuoc != 'TCQ' "
                        + " inner join namdinh_khambenh.dbo.tblKhamBenh KhamBenh on b.MaKhamBenh = KhamBenh.MaKhamBenh"
                        + " inner join namdinh_khambenh.dbo.tblBenhNhan BenhNhan on BenhNhan.MabenhNhan = KhamBenh.MaBenhNhan"
                        + " where datediff(dd,NgayThucHien,'{0:dd/MM/yyyy}') <= 0 and datediff(dd,NgayThucHien,'{1:dd/MM/yyyy}') >= 0 "
                        + " and b.LoaiChiPhi in ('D01','D05') and b.MaKhoaThucHien in ('{2}')"
                        + " group by b.MaChiPhi,b.soluong,b.dathuchien,b.MaPhieuDuyet,b.MaKhamBenh,dmdichvu.DVT,"
                        + " dmdichvu.tendichvu,BenhNhan.TenBenhNhan) dd", txtTNgay.Value, txtDNgay.Value, Global.GetCode(cmbKhoa));
                    if (raNhomTBN.Checked)
                    {
                        Str += " Group by DaThucHien,MaVaoVien,HoTen,MaDichVu,TenDichVu,DVT,GhiChu,TT_HN"
                            + " ORDER BY right(GhiChu,9) desc,DATHUCHIEN,MAVAOVIEN,HOTEN,TENDICHVU";
                    }
                    else
                    {
                        Str += " Group by DaThucHien,MaVaoVien,HoTen,MaDichVu,TenDichVu,DVT,GhiChu,TT_HN"
                            + " ORDER BY right(GhiChu,9) desc,DATHUCHIEN,TENDICHVU,HOTEN,MAVAOVIEN";
                    }
                }

                System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
                SQLCmd.CommandText = Str;
                System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(SQLCmd);
                System.Data.DataSet ds = new DataSet();
                ds.Clear();
                da.Fill(ds);
                fgDanhSach.ClipSeparators = "|;";
                fgDanhSach.Rows.Fixed = 0;
                fgDanhSach.Rows.Count = 1;
                fgDanhSach.Rows.Fixed = 1;
                if (raNhomToanKhoa.Checked)
                {
                    fgDanhSach.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Free;
                    fgDanhSach.Cols[6].AllowMerging = true;
                    fgDanhSach.Cols[8].AllowMerging = false;
                    fgDanhSach.Cols[6].DataType = typeof(object);
                    fgDanhSach.Cols[4].DataType = typeof(Decimal);
                    fgDanhSach.Cols[4].Format = "#,##0.##";
                    foreach (System.Data.DataRow Row in ds.Tables[0].Rows)
                    {
                        fgDanhSach.AddItem(String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}",
                            fgDanhSach.Rows.Count,
                            Row["DaThucHien"],
                            Row["MaDichVu"],
                            Row["TenDichVu"],
                            Row["SoLuong"],
                            Row["DVT"],
                            Row["GhiChu"]));
                    }
                    fgDanhSach[0, 0] = "Số TT";
                    fgDanhSach[0, 1] = "Thực hiện";
                    fgDanhSach[0, 2] = "Mã thuốc";
                    fgDanhSach[0, 3] = "Tên thuốc";
                    fgDanhSach[0, 4] = "Số lượng";
                    fgDanhSach[0, 5] = "ĐVT";
                    fgDanhSach[0, 6] = "Mã phiếu lỉnh thuốc";
                    fgDanhSach.Cols[2].Visible = fgDanhSach.Cols[7].Visible = fgDanhSach.Cols[8].Visible = false;
                    fgDanhSach.Cols[3].Visible = fgDanhSach.Cols[4].Visible = true;
                }
                else
                {
                    fgDanhSach.Cols[7].Visible = fgDanhSach.Cols[8].Visible = true;
                    fgDanhSach.Tree.Column = 5;
                    if (raNhomTBN.Checked)
                    {
                        fgDanhSach.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Free; 
                        fgDanhSach.Cols[6].AllowMerging = false;
                        fgDanhSach.Cols[8].AllowMerging = true;
                        fgDanhSach.Cols[4].DataType = typeof(object);
                        fgDanhSach.Cols[6].DataType = typeof(Decimal);
                        fgDanhSach.Cols[6].Format = "#,##0.##";
                        foreach (System.Data.DataRow Row in ds.Tables[0].Rows)
                        {
                            if (Row["MaVaoVien"].ToString() != MaVaoVien)
                            {
                                MaVaoVien = Row["MaVaoVien"].ToString();
                                STT++;
                                STT1 = 1;
                            }
                            else
                            {
                                STT1++;
                            }
                            fgDanhSach.AddItem(String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}",
                                STT1.ToString(),
                                Row["DaThucHien"],
                                Row["MaVaoVien"],
                                STT.ToString() + ": " + Row["HoTen"],
                                Row["MaDichVu"],
                                Row["TenDichVu"],
                                Row["SoLuong"],
                                Row["DVT"],
                                Row["GhiChu"],
                                Row["TT_HN"]));
                        }
                        fgDanhSach[0, 0] = "Số TT";
                        fgDanhSach[0, 1] = "Thực hiện";
                        fgDanhSach[0, 2] = "Mã bệnh nhân";
                        fgDanhSach[0, 3] = "Tên bệnh nhân";
                        fgDanhSach[0, 4] = "Mã thuốc";
                        fgDanhSach[0, 5] = "Tên thuốc";
                        fgDanhSach[0, 6] = "Số lượng";
                        fgDanhSach[0, 7] = "ĐVT";
                        fgDanhSach[0, 8] = "Mã phiếu lỉnh thuốc";
                        fgDanhSach.Cols[2].Visible = fgDanhSach.Cols[3].Visible = fgDanhSach.Cols[4].Visible = false;
                        STT = 0;
                        MaVaoVien = "";
                        STT1 = 1;
                    }
                    else
                    {
                        fgDanhSach.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Free; 
                        fgDanhSach.Cols[6].AllowMerging = false;
                        fgDanhSach.Cols[8].AllowMerging = true;
                        fgDanhSach.Cols[4].DataType = typeof(object);
                        fgDanhSach.Cols[6].DataType = typeof(Decimal);
                        fgDanhSach.Cols[6].Format = "#,##0.##";
                        foreach (System.Data.DataRow Row in ds.Tables[0].Rows)
                        {
                            if (Row["MaDichVu"].ToString() != MaVaoVien)
                            {
                                MaVaoVien = Row["MaDichVu"].ToString();
                                STT++; 
                                STT1 = 1;
                            }
                            else
                            {
                                STT1++;
                            }
                            fgDanhSach.AddItem(String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}",
                                STT1.ToString(),
                                Row["DaThucHien"],
                                Row["MaDichVu"],
                                STT.ToString() + ": " + Row["TenDichVu"],
                                Row["MaVaoVien"],
                                Row["HoTen"],
                                Row["SoLuong"],
                                Row["DVT"],
                                Row["GhiChu"],
                                Row["TT_HN"]));
                        }
                        fgDanhSach[0, 0] = "Số TT";
                        fgDanhSach[0, 1] = "Thực hiện";
                        fgDanhSach[0, 2] = "Mã dịch vụ";
                        fgDanhSach[0, 3] = "Tên thuốc";
                        fgDanhSach[0, 4] = "Mã bệnh nhân";
                        fgDanhSach[0, 5] = "Tên bệnh nhân";
                        fgDanhSach[0, 6] = "Số lượng";
                        fgDanhSach[0, 7] = "ĐVT";
                        fgDanhSach[0, 8] = "Mã phiếu lỉnh thuốc";
                        fgDanhSach.Cols[2].Visible = fgDanhSach.Cols[3].Visible = fgDanhSach.Cols[4].Visible = false;
                        STT = 0;
                        MaVaoVien = "";
                        STT1 = 1;
                    }

                    fgDanhSach.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.Sum, 0, 3, 6, "{0}");
                }
                fgDanhSach.AutoSizeCols(1, fgDanhSach.Cols.Count - 1, 1);
                SQLCmd.Dispose();
                cmbHuy.Visible = cmbKhoiPhuc.Visible = false;
                for (int i = 1; i < fgDanhSach.Rows.Count; i++)
                {
                    if (fgDanhSach.Rows[i].IsNode) continue;
                    if (fgDanhSach.GetData(i, "ThucHien").ToString().ToLower() == "false")
                    {
                        cmdDuyet.Visible = true;
                        return;
                    }
                    else
                    {
                        cmdDuyet.Visible = false;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                Global.nowait();
            }
        }

        private void cmdTongHop_Click(object sender, EventArgs e)
        {
            if (cmbKhoa.SelectedIndex == -1)
            {
                MessageBox.Show("Chưa chọn Khoa điều trị!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cmbKhoa.Focus();
                return;
            }
            if (txtTNgay.ValueIsDbNull)
            {
                MessageBox.Show("Chưa nhập ngày tháng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);                
                return;
            }
            fgDanhSach.Tag = 0;
            LoatData();
            fgDanhSach.Tag = 1;
            fgDanhSach_Click(sender,e);
        }

        private void frmPhieuLinhThuoc_Load(object sender, EventArgs e)
        {
            cmbKhoa.Tag = 0;
            txtTNgay.Tag = txtDNgay.Tag = 0;
            raNhomTBN.Tag = raNhomTheoCP.Tag = raNhomToanKhoa.Tag = 0;
            cmbNhom.Tag = 0;
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            SQLCmd.CommandText = "SELECT * FROM DMKHOAPHONG WHERE Len(MaKHoa)>1 AND MaKhoa IN " + Global.glbKhoa_CapNhat;
            dr = SQLCmd.ExecuteReader();
            cmbKhoa.Tag = "0";
            cmbKhoa.ClearItems();
            while (dr.Read())
            {
                cmbKhoa.AddItem(string.Format("{0};{1}", dr["MaKhoa"], dr["TenKhoa"]));
            }
            dr.Close();
            SQLCmd.CommandText = "SELECT * FROM Khoa_Nhom where MaKhoa='" + Global.GetCode(cmbKhoa) + "' ORDER BY TenNhom";
            dr = SQLCmd.ExecuteReader();
            cmbNhomLenCP.Tag = "0";
            cmbNhomLenCP.ClearItems();
            while (dr.Read())
            {
                cmbNhomLenCP.AddItem(string.Format("{0};{1}", dr["MANhom"], dr["TenNhom"]));
            }
            cmbNhomLenCP.SelectedIndex = 0;
            cmbNhomLenCP.Tag = "1";
            dr.Close();
            SQLCmd.Dispose();
            cmbKhoa.SelectedIndex = 0;
            if (cmbKhoa.ListCount == 1) cmbKhoa.SelectedIndex = 0;
            txtTNgay.Value =  txtDNgay.Value = GlobalModuls.Global.NgayLV;
            cmbNhom.AddItem("--------- Tất cả---------");
            cmbNhom.AddItem("Chi phí trong ngày");
            cmbNhom.AddItem("Chi phí bất thường");
            cmbNhom.SelectedIndex = 0;
            C1.Win.C1FlexGrid.CellStyle cs = fgDanhSach.Styles[C1.Win.C1FlexGrid.CellStyleEnum.Subtotal0];
            cs.BackColor = Color.LightBlue;
            cs.ForeColor = Color.DarkBlue;
            cmdTongHop_Click(sender, e);
            cmbKhoa.Tag = 1;
            txtTNgay.Tag = txtDNgay.Tag = 1;
            raNhomTBN.Tag = raNhomTheoCP.Tag = raNhomToanKhoa.Tag = 1;
            cmbNhom.Tag = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string SoLuuTru = "";
            System.Data.SqlClient.SqlCommand Cmd = new System.Data.SqlClient.SqlCommand();
            Cmd.Connection = GlobalModuls.Global.ConnectSQL;
            Cmd.CommandText = string.Format("SELECT isnull(SoLuuTru,'') FROM PhieuLinh_LuuTru WHERE MaPhieu='{0}' and PhongKhoaID='{1}' ", MaDuyetThuoc, Global.GetCode(cmbKhoa));
            if (Cmd.ExecuteScalar() != null) SoLuuTru = Cmd.ExecuteScalar().ToString();
            else SoLuuTru = "";
            //Cho nay in theo the kho

            if (cmbKhoa.SelectedIndex == -1)
            {
                MessageBox.Show("Chưa chọn Khoa điều trị!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cmbKhoa.Focus();
                return;
            }
            if (txtTNgay.ValueIsDbNull)
            {
                MessageBox.Show("Chưa nhập ngày tháng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string Ngay = "", Str = "";
            DateTime TNgay = DateTime.Parse(txtTNgay.Text);
            DateTime DNgay = DateTime.Parse(txtDNgay.Text);
            System.TimeSpan Ngay1 = DNgay - TNgay;

            if (MaDuyetThuoc == "")
            {
                MessageBox.Show("Chọn Mã phiếu duyệt", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
            Str = String.Format("set dateformat mdy DECLARE @TrongNgay Nvarchar(800)"
                + " DECLARE @BatThuong Nvarchar(800)"
                + " DECLARE @Ngay datetime"
                + " DECLARE @Nhom int"
                + " SET @BatThuong =''"
                + " SET @TrongNgay = ''"
                + " DECLARE Cur CURSOR "
                + " 	FOR"
                + " 	select namdinh_duoc.dbo.Ngay(ngaychidinh),nhom from benhnhan_phieudieutri where sophieu in "
                + " 	(select sophieu from phieudieutri_chitiet where maphieuduyet ='" + MaDuyetThuoc + "' and loaidichvu in ('D01')"
                + " 	group by sophieu,loaidichvu)"
                + " 	group by namdinh_duoc.dbo.Ngay(ngaychidinh),nhom order by nhom,namdinh_duoc.dbo.Ngay(ngaychidinh)"
                + " 	OPEN Cur"
                + " FETCH NEXT FROM Cur  INTO @Ngay,@Nhom"
                + " WHILE  @@FETCH_STATUS = 0"
                + " BEGIN"
                + " 	IF @NHOM = 0 "
                + " 	BEGIN"
                + " 		SET @TrongNgay = @TrongNgay + CONVERT(nvarchar(100),@Ngay,103) + ','"
                + " 	END"
                + " 	IF @NHOM = 1"
                + " 	BEGIN"
                + " 		SET @BatThuong = @BatThuong + CONVERT(nvarchar(100),@Ngay,103) + ','"
                + " 	END"
                + " FETCH NEXT FROM Cur  INTO @Ngay,@Nhom"
                + " END"
                + " DEALLOCATE  Cur"
                + " SET @BatThuong = N'Thuốc bất thường ngày ' + @BatThuong"
                + " SET @TrongNgay = N'Thuốc trong ngày ' + @TrongNgay"
                + " SELECT '" + MaDuyetThuoc + "' AS MAPHIEUDUYET,@BatThuong + '\n' + @TrongNgay as BatThuongTrangNgay,MADICHVU,TENDICHVU,DVT,ROUND(SUM(SOLUONG),0) AS SOLUONG,AA.KHOID,KHO.TENKHO, "
                + " CASE WHEN AA.DADUYET = 1 THEN N'BẢN SAO' ELSE '' END AS BANSAO,case LEFT(aa.MaLoaiThuoc,2) when 'DN' then 'VI' when 'GO' then 'VI' else LEFT(aa.MaLoaiThuoc,2) end as GROUPS FROM"
                + " (SELECT DMDICHVU.MADICHVU,DMDICHVU.TENDICHVU,DMDICHVU.DVT,SUM(B.SOLUONG) AS SOLUONG,B.KHOID,B.DADUYET,DMDichVu.MaLoaiThuoc FROM"
                + " (BENHNHAN_PHIEUDIEUTRI A INNER JOIN PHIEUDIEUTRI_CHITIET B ON A.SOPHIEU = B.SOPHIEU and B.MADICHVU NOT IN ('ONG-TCQ-0005','ONG-TCQ-0006','ONG-TCQ-0003','ONG-TCQ-0004'))"
                + " INNER JOIN DMDICHVU ON DMDICHVU.MADICHVU = B.MADICHVU AND DMDICHVU.LOAIDICHVU = B.LOAIDICHVU and DMDICHVU.NhomThuoc != 'TCQ'"
                + " WHERE B.MANHOM = {0} AND A.MAKHOA ='{1}' AND B.LOAIDICHVU ='D01' AND B.MAPHIEUDUYET ='{2}'"
                + " GROUP BY DMDICHVU.MADICHVU,DMDICHVU.TENDICHVU,DMDICHVU.DVT,B.KHOID,B.DADUYET,DMDichVu.MaLoaiThuoc"
                + " UNION ALL " //Chi phi trong thu thuat
                + " SELECT DMDICHVU.MADICHVU,DMDICHVU.TENDICHVU,DMDICHVU.DVT,SUM(SOLUONG) AS SOLUONG,A.KHOID,A.DADUYET,DMDichVu.MaLoaiThuoc FROM CHIPHI_THUTHUAT A"
                + " INNER JOIN DMDICHVU ON A.MACHIPHI = DMDICHVU.MADICHVU AND A.LOAIDICHVU = DMDICHVU.LOAIDICHVU and DMDICHVU.NhomThuoc != 'TCQ'"
                + " WHERE A.MANHOM = {0} AND A.MAKHOA ='{1}' AND A.LOAIDICHVU ='D01' AND A.MAPHIEUDUYET ='{2}'"
                + " GROUP BY DMDICHVU.MADICHVU,DMDICHVU.TENDICHVU,DMDICHVU.DVT,A.KHOID,A.DADUYET,DMDichVu.MaLoaiThuoc"
                + " UNION ALL " // Chi phi o phong kham               
                + " SELECT DMDICHVU.MADICHVU,DMDICHVU.TENDICHVU,DMDICHVU.DVT,SUM(SOLUONG) AS SOLUONG,A.KHOID,0 AS DADUYET,DMDichVu.MaLoaiThuoc "
                + " FROM NAMDINH_KHAMBENH.DBO.TBLCHIPHI_DICHVU A "
                + " INNER JOIN DMDICHVU ON DMDICHVU.MADICHVU = A.MACHIPHI AND DMDICHVU.LOAIDICHVU = A.LOAICHIPHI"
                + " WHERE A.MANHOM = {0} AND A.MAKHOATHUCHIEN ='{1}' AND A.LOAICHIPHI ='D01' AND A.MAPHIEUDUYET ='{2}'"
                + " GROUP BY DMDICHVU.MADICHVU,DMDICHVU.TENDICHVU,DMDICHVU.DVT,A.KHOID,DMDichVu.MaLoaiThuoc) AA"
                + " LEFT JOIN NAMDINH_DUOC.DBO.DANHMUCKHO KHO ON KHO.KHOID = AA.KHOID WHERE SOLUONG > 0 AND",
                Global.GetCode(cmbNhomLenCP),
                Global.GetCode(cmbKhoa),
                MaDuyetThuoc);
            if (raDieuTriThuong.Checked)
            {
                Str += " AA.MaLoaiThuoc NOT LIKE 'NGHT%' ";
            }
            else
            {
                if (raThuocGayNghien.Checked)
                {
                    Str += " AA.MaLoaiThuoc LIKE 'NGHT%' ";
                }
                else
                {
                    if (raThuocHT.Checked)
                    {
                        Str += " AA.MaLoaiThuoc LIKE 'NGHT%' ";
                    }
                }
            }
            Str += " GROUP BY MADICHVU,TENDICHVU,DVT,AA.KHOID,KHO.TENKHO,AA.DADUYET,MaLoaiThuoc ORDER BY Groups,TENDICHVU";
            //truong hop in thuoc dong y
            if (raThuocDongY.Checked)
            {
                Str = String.Format(" select * from "
                    + " (select aa.*,ct.madichvu,ct.soluong,ct.soluong * aa.sothang as TongSL,ct.DonGia,benhnhan.hoten,year(getdate())- benhnhan.namsinh as tuoi,"
                    + " case when benhnhan.gioitinh = 0 then N'Giới tính: Nữ' else N'Giới tính: Nam' end as GioiTinh,N'Địa chỉ: ' + benhnhan_chitiet.diachi as diachi,"
                    + " N'Đối tượng: ' + dmdoituongbn.tendt + '. ' + N'Số thẻ: ' + v.SoThe as Doituong1,dmbuongbenh.tenbuong as buong1,"
                    + " dmgiuongbenh.tengiuong as Giuong1 from"
                    + " (select N'Chẩn đoán: ' + chandoan as chandoan,mavaovien,sophieu,ngaychidinh,bacsydt,sothang,N'Số lượng thang: ' + CONVERT(nvarchar,sothang) + ' ' + ChuThich  as SoThang1,makhoa from benhnhan_phieudieutri where makhoa ='{0}' and datediff(dd,ngaychidinh,'{1:dd/MM/yyyy}') <= 0  and datediff(dd,ngaychidinh,'{2:dd/MM/yyyy}') >= 0 ) aa"
                    + " inner join phieudieutri_chitiet ct on ct.sophieu = aa.sophieu and username=N'" + Global.glbUName + "'"
                    + " inner join benhnhan_chitiet on benhnhan_chitiet.mavaovien = aa.mavaovien"
                    + " inner join benhnhan on benhnhan_chitiet.mabenhnhan = benhnhan.mabenhnhan"
                    + " inner join viewdoituonghientai v on v.mavaovien = aa.mavaovien "
                    + " inner join dmdoituongbn on dmdoituongbn.madt = v.doituong "
                    + " left join dmbuongbenh on dmbuongbenh.makhoa = aa.makhoa and dmbuongbenh.id_buong = benhnhan_chitiet.buong"
                    + " left join dmgiuongbenh on dmgiuongbenh.makhoa = aa.makhoa and dmgiuongbenh.id_giuong = benhnhan_chitiet.giuong and dmgiuongbenh.id_buong = benhnhan_chitiet.buong"
                    + " where ct.loaidichvu ='D05' and DaDuyet = 0) bb"
                    + " inner join dmdichvu on dmdichvu.madichvu = bb.madichvu and DMDICHVU.NhomThuoc != 'TCQ'"
                    + " inner join saclapphieu on saclapphieu.loaithuoc = dmdichvu.loaithuoc and saclapphieu.makhoa = bb.makhoa"
                    + " inner join " + Global.glbDuoc + ".dbo.DanhMucKho kho on kho.khoid = saclapphieu.khoid ",
                    Global.GetCode(cmbKhoa),
                    txtTNgay.Value,
                    txtDNgay.Value);
            }
            SQLCmd.CommandText = Str;

            System.Data.SqlClient.SqlDataReader dr = SQLCmd.ExecuteReader();
            if (raDieuTriThuong.Checked)
            {
                NamDinh_QLBN.Reports.rptPhieuLinhThuoc_Sua rpt = new NamDinh_QLBN.Reports.rptPhieuLinhThuoc_Sua(cmbKhoa.Text, Ngay,SoLuuTru,cmbNhomLenCP.Text);
                rpt.DataSource = dr;
                rpt.Show();
            }
            else
            {
                if (raThuocGayNghien.Checked)
                {
                    NamDinh_QLBN.Reports.rptPhieuLinhThuocGayNghien_Sua rpt = new NamDinh_QLBN.Reports.rptPhieuLinhThuocGayNghien_Sua(cmbKhoa.Text, Ngay,SoLuuTru,cmbNhomLenCP.Text);
                    rpt.DataSource = dr;
                    rpt.Show();
                }
                else
                {
                    if (raThuocHT.Checked)
                    {
                        NamDinh_QLBN.Reports.rptPhieuLinhThuocGayNghien_Sua rpt = new NamDinh_QLBN.Reports.rptPhieuLinhThuocGayNghien_Sua(cmbKhoa.Text, Ngay,SoLuuTru,cmbNhomLenCP.Text);
                        rpt.DataSource = dr;
                        rpt.Show();
                        //NamDinh_QLBN.Reports.rptPhieuLinhThuocHuongThan_Sua rpt = new NamDinh_QLBN.Reports.rptPhieuLinhThuocHuongThan_Sua(cmbKhoa.Text, Ngay);
                        //rpt.DataSource = dr;
                        //rpt.Show();
                    }
                    else
                    {
                        NamDinh_QLBN.Reports.BaoCaoVeThuoc.rptPhieuLinhThuocDongY rpt = new NamDinh_QLBN.Reports.BaoCaoVeThuoc.rptPhieuLinhThuocDongY(cmbKhoa.Text, Ngay);
                        rpt.DataSource = dr;
                        rpt.Show();
                    }
                }
            }
            dr.Close();
            SQLCmd.Dispose();
        }

        private void raTaCa_CheckedChanged(object sender, EventArgs e)
        {
                    
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdChonGui_Click(object sender, EventArgs e)
        {
            
        }

        private void DuyetThuoc()
        {
            String Str = "";
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
            System.Data.SqlClient.SqlTransaction trn = Global.ConnectSQL.BeginTransaction();
            SQLCmd.Transaction = trn;
            try
            {
                //Str = String.Format("DECLARE @MAPHIEUDUYET NVARCHAR(50) "
                //    + " Select @MAPHIEUDUYET = dbo.LayMaDuyetThuoc(Right(Convert(nvarchar(8),'{0:yyyyMMdd}',112),6))  ", Global.NgayLV);
                Str = String.Format("DECLARE @MAPHIEUDUYET NVARCHAR(50),@s_ngay varchar(6),@SoLuuTru varchar(11) "
                    + " set @s_ngay= Right(Convert(nvarchar(8),'{0:yyyyMMdd}',112),6)"
                    + " exec dbo.LayMaDuyetThuoc1 @s_ngay,@MAPHIEUDUYET output "//, Global.NgayLV);
                    + " exec dbo.GetNextSoLuuTruNT @MaPhieuDuyet,'{1}',@SoLuuTru output ", Global.NgayLV, GlobalModuls.Global.GetCode(cmbKhoa));
                Str += String.Format("UPDATE PHIEUDIEUTRI_CHITIET SET DATHUCHIEN = 1,NgayIn='{0:dd/MM/yyyy}'", Global.NgayLV);
                Str += String.Format(",MaPhieuDuyet = @MAPHIEUDUYET WHERE LOAIDICHVU in ('D01','D05') AND DATHUCHIEN = 0 AND SOPHIEU IN (SELECT SOPHIEU FROM BENHNHAN_PHIEUDIEUTRI "
                    + " WHERE DateDiff(dd,NgayChiDinh,'{0:dd/MM/yyyy} 00:00:00') <= 0  and DateDiff(dd,NgayChiDinh,'{1:dd/MM/yyyy} 00:00:00') >= 0"
                    + "  AND MAKHOA = '{2}' and MaNhom= " + Global.GetCode(cmbNhomLenCP) + " ",
                    txtTNgay.Value, txtDNgay.Value,
                    GlobalModuls.Global.GetCode(cmbKhoa));
                if (cmbNhom.SelectedIndex == 1)
                {
                    Str += String.Format(" and nhom = 0)");
                }
                else
                {
                    if (cmbNhom.SelectedIndex == 2)
                    {
                        Str += String.Format(" and nhom = 1) ");
                    }
                    else
                    {
                        Str += String.Format(")");
                    }
                }

                Str += String.Format(" Update chiphi_thuthuat set dathuchien = 1,NgayIn='{0:dd/MM/yyyy}'", Global.NgayLV);
                Str += String.Format(",MaPhieuDuyet= @MAPHIEUDUYET Where LoaiDichVu in ('D01','D05') and dathuchien =0 and makhoa='{0}'"
                    + " and datediff(dd,NgayThucHien,'{1:dd/MM/yyyy}') <= 0 and datediff(dd,NgayThucHien,'{2:dd/MM/yyyy}') >= 0 "
                    + " and MaNhom= " + Global.GetCode(cmbNhomLenCP),
                    Global.GetCode(cmbKhoa),
                    txtTNgay.Value,
                    txtDNgay.Value);
                if (cmbNhom.SelectedIndex == 1)
                {
                    Str += " and nhom = 0";
                }
                else
                {
                    if (cmbNhom.SelectedIndex == 2)
                    {
                        Str += " and nhom = 1";
                    }
                    else
                    {
                    }
                }
                Str += String.Format(" Update [" + Global.glbKhamBenh + "].dbo.tblChiPhi_DichVu set DaThucHien = 1,NgayIn='{0:dd/MM/yyyy}'", Global.NgayLV); ;
                Str += String.Format(",MaPhieuDuyet= @MAPHIEUDUYET Where LoaiChiPhi in ('D01') and dathuchien = 0 and MaKhoaThucHien in ('{0}')"
                    + " and datediff(dd,NgayThucHien,'{1:dd/MM/yyyy}') <= 0 and datediff(dd,NgayThucHien,'{2:dd/MM/yyyy}') >= 0 "
                    + " and MaNhom= " + Global.GetCode(cmbNhomLenCP),
                    Global.GetCode(cmbKhoa),
                    txtTNgay.Value,
                    txtDNgay.Value);
                SQLCmd.CommandText = Str;
                SQLCmd.ExecuteNonQuery();
                trn.Commit();
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
            
            fgDanhSach.Tag = 0;
            LoatData();
            fgDanhSach.Tag = 1;
        }

        private void cmdDuyet_Click(object sender, EventArgs e)
        {
            try
            {
                DuyetThuoc();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void fgDanhSach_BeforeEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            if ((fgDanhSach.Cols[e.Col].Name != "ThucHien") || fgDanhSach.Rows[e.Row].IsNode)
            {
                e.Cancel = true;
            }
            else
            {
                if (fgDanhSach.Rows[e.Row].UserData == null && fgDanhSach.GetDataDisplay(e.Row, "ThucHien").ToLower() == "true")
                {
                    e.Cancel = true;
                }
            }
        }

        private void fgDanhSach_AfterEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            fgDanhSach.Rows[e.Row].UserData = 1;
        }

        private void fgDanhSach_Click(object sender, EventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtNgayChiDinh_TextChanged(object sender, EventArgs e)
        {

        }

        private void raNhomToanKhoa_CheckedChanged(object sender, EventArgs e)
        {
            if (cmbKhoa.Tag.ToString() == "0") return;
            if (cmbNhom.Tag.ToString() == "0") return;
            if (raNhomToanKhoa.Tag.ToString() == "0") return;
            if (raNhomTheoCP.Tag.ToString() == "0") return;
            if (raNhomTBN.Tag.ToString() == "0") return;
            if (txtDNgay.Tag.ToString() == "0") return;
            if (txtTNgay.Tag.ToString() == "0") return;
            if (fgDanhSach.Tag.ToString() == "0") return;
            fgDanhSach.Tag = 0;
            if (raNhomToanKhoa.Checked)
            cmdTongHop_Click(sender, e);
            fgDanhSach.Tag = 1;
        }

        private void txtTNgay_ValueChanged(object sender, EventArgs e)
        {
            if (cmbKhoa.Tag.ToString() == "0") return;
            if (cmbNhom.Tag.ToString() == "0") return;
            if (raNhomToanKhoa.Tag.ToString() == "0") return;
            if (raNhomTheoCP.Tag.ToString() == "0") return;
            if (raNhomTBN.Tag.ToString() == "0") return;
            if (txtDNgay.Tag.ToString() == "0") return;
            if (txtTNgay.Tag.ToString() == "0") return;
            if (fgDanhSach.Tag.ToString() == "0") return;
            fgDanhSach.Tag = 0;
            cmdTongHop_Click(sender, e);
            fgDanhSach.Tag = 1;
        }

        private void txtDNgay_ValueChanged(object sender, EventArgs e)
        {
            if (cmbKhoa.Tag.ToString() == "0") return;
            if (cmbNhom.Tag.ToString() == "0") return;
            if (raNhomToanKhoa.Tag.ToString() == "0") return;
            if (raNhomTheoCP.Tag.ToString() == "0") return;
            if (raNhomTBN.Tag.ToString() == "0") return;
            if (txtDNgay.Tag.ToString() == "0") return;
            if (txtTNgay.Tag.ToString() == "0") return;
            if (fgDanhSach.Tag.ToString() == "0") return;
            fgDanhSach.Tag = 0;
            cmdTongHop_Click(sender, e);
            fgDanhSach.Tag = 1;
        }

        private void raNhomTheoCP_CheckedChanged(object sender, EventArgs e)
        {
            if (cmbKhoa.Tag.ToString() == "0") return;
            if (cmbNhom.Tag.ToString() == "0") return;
            if (raNhomToanKhoa.Tag.ToString() == "0") return;
            if (raNhomTheoCP.Tag.ToString() == "0") return;
            if (raNhomTBN.Tag.ToString() == "0") return;
            if (txtDNgay.Tag.ToString() == "0") return;
            if (txtTNgay.Tag.ToString() == "0") return;
            if (fgDanhSach.Tag.ToString() == "0") return;
            fgDanhSach.Tag = 0;
            if(raNhomTheoCP.Checked)
            cmdTongHop_Click(sender, e);
            fgDanhSach.Tag = 1;
        }

        private void raNhomTBN_CheckedChanged(object sender, EventArgs e)
        {
            if (cmbKhoa.Tag.ToString() == "0") return;
            if (cmbNhom.Tag.ToString() == "0") return;
            if (raNhomToanKhoa.Tag.ToString() == "0") return;
            if (raNhomTheoCP.Tag.ToString() == "0") return;
            if (raNhomTBN.Tag.ToString() == "0") return;
            if (txtDNgay.Tag.ToString() == "0") return;
            if (txtTNgay.Tag.ToString() == "0") return;
            if (fgDanhSach.Tag.ToString() == "0") return;
            fgDanhSach.Tag = 0;
            if(raNhomTBN.Checked)
            cmdTongHop_Click(sender, e);
            fgDanhSach.Tag = 1;
        }

        private void cmbNhom_TextChanged(object sender, EventArgs e)
        {
            if (cmbKhoa.Tag.ToString() == "0") return;
            if (cmbNhom.Tag.ToString() == "0") return;
            if (raNhomToanKhoa.Tag.ToString() == "0") return;
            if (raNhomTheoCP.Tag.ToString() == "0") return;
            if (raNhomTBN.Tag.ToString() == "0") return;
            if (txtDNgay.Tag.ToString() == "0") return;
            if (txtTNgay.Tag.ToString() == "0") return;
            if (fgDanhSach.Tag.ToString() == "0") return;
            fgDanhSach.Tag = 0;
            cmdTongHop_Click(sender, e);
            fgDanhSach.Tag = 1;
        }

        private void chDaThucHien_CheckedChanged(object sender, EventArgs e)
        {
            if (cmbKhoa.Tag.ToString() == "0") return;
            if (cmbNhom.Tag.ToString() == "0") return;
            if (raNhomToanKhoa.Tag.ToString() == "0") return;
            if (raNhomTheoCP.Tag.ToString() == "0") return;
            if (raNhomTBN.Tag.ToString() == "0") return;
            if (txtDNgay.Tag.ToString() == "0") return;
            if (txtTNgay.Tag.ToString() == "0") return;
            if (fgDanhSach.Tag.ToString() == "0") return;
            fgDanhSach.Tag = 0;
            cmdTongHop_Click(sender, e);
            fgDanhSach.Tag = 1;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (fgDanhSach.Rows.Count <= 1) return;

            if (raNhomToanKhoa.Checked)
            {
                if (fgDanhSach.GetDataDisplay(fgDanhSach.Row, 6) == "")
                {
                    MessageBox.Show("Chọn Mã phiếu lĩnh cần hủy", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else
            {
                if (fgDanhSach.GetDataDisplay(fgDanhSach.Row, 8) == "")
                {
                    MessageBox.Show("Chọn Mã phiếu lĩnh cần hủy", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            System.Data.SqlClient.SqlTransaction tra = Global.ConnectSQL.BeginTransaction();
            SQLCmd.Transaction = tra;
            try
            {
                if (MessageBox.Show("Bạn có muốn hủy không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    SQLCmd.CommandText = String.Format("Update phieudieutri_chitiet set dathuchien = 0,NgayIn = Null");
                    if (raNhomToanKhoa.Checked)
                    {
                        SQLCmd.CommandText += " where MaPhieuDuyet='" + fgDanhSach.GetDataDisplay(fgDanhSach.Row, 6) + "'";
                    }
                    else
                    {
                        SQLCmd.CommandText += " where MaPhieuDuyet='" + fgDanhSach.GetDataDisplay(fgDanhSach.Row, 8) + "'";
                    }
                    SQLCmd.CommandText += String.Format(" Update chiphi_ThuThuat set DaThucHien = 0,NgayIn = Null ");
                    if (raNhomToanKhoa.Checked)
                    {
                        SQLCmd.CommandText += " where MaPhieuDuyet='" + fgDanhSach.GetDataDisplay(fgDanhSach.Row, 6) + "'";
                    }
                    else
                    {
                        SQLCmd.CommandText += " where MaPhieuDuyet='" + fgDanhSach.GetDataDisplay(fgDanhSach.Row, 8) + "'";
                    }
                    SQLCmd.CommandText += String.Format(" Update [" + Global.glbKhamBenh + "].dbo.tblChiPhi_DichVu set DaThucHien = 0,NgayIn = Null ");
                    if (raNhomToanKhoa.Checked)
                    {
                        SQLCmd.CommandText += " where MaPhieuDuyet='" + fgDanhSach.GetDataDisplay(fgDanhSach.Row, 6) + "'";
                    }
                    else
                    {
                        SQLCmd.CommandText += " where MaPhieuDuyet='" + fgDanhSach.GetDataDisplay(fgDanhSach.Row, 8) + "'";
                    }
                }
                SQLCmd.ExecuteNonQuery();
                tra.Commit();
                cmdTongHop_Click(sender, e);
            }
            catch(Exception ex)
            {
                tra.Rollback();
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                SQLCmd.Dispose();
            }
        }

        private void StaHuyVaKhoiPhuc()
        {
            if (fgDanhSach.Rows.Count <= 0) return;
            if (fgDanhSach.Tag.ToString() == "0") return;
            cmbHuy.Visible = false;
            cmbKhoiPhuc.Visible = false;
            if (raNhomToanKhoa.Checked)
            {
                if (fgDanhSach.GetDataDisplay(fgDanhSach.Row, 6) == "")
                {
                    cmbHuy.Visible = false;
                    return;
                }
                else
                {
                    if (fgDanhSach.GetData(fgDanhSach.Row, "ThucHien").ToString().ToLower() == "true")
                    {
                        cmbHuy.Visible = true;
                        return;
                    }
                }
                if (fgDanhSach.GetDataDisplay(fgDanhSach.Row, 6) != "" && fgDanhSach.GetData(fgDanhSach.Row, "ThucHien").ToString().ToLower() == "false")
                {
                    cmbKhoiPhuc.Visible = true;
                    return;
                }
                else
                {
                    cmbKhoiPhuc.Visible = false;
                    return;
                }
            }
            else
            {
                if (fgDanhSach.GetDataDisplay(fgDanhSach.Row, 8) == "")
                {
                    cmbHuy.Visible = false;
                    return;
                }
                else
                {
                    if (fgDanhSach.GetData(fgDanhSach.Row, "ThucHien").ToString().ToLower() == "true")
                    {
                        cmbHuy.Visible = true;
                        return;
                    }
                }
                if (fgDanhSach.GetDataDisplay(fgDanhSach.Row, 8) != "" && fgDanhSach.GetData(fgDanhSach.Row, "ThucHien").ToString().ToLower() == "false")
                {
                    cmbKhoiPhuc.Visible = true;
                    return;
                }
                else
                {
                    cmbKhoiPhuc.Visible = false;
                    return;
                }
            }
        }
        private void fgDanhSach_AfterRowColChange(object sender, C1.Win.C1FlexGrid.RangeEventArgs e)
        {
            if (fgDanhSach.Tag.ToString() == "0") return;
            StaHuyVaKhoiPhuc(); 
        }

        private void cmbKhoiPhuc_Click(object sender, EventArgs e)
        {
            if (fgDanhSach.Rows.Count <= 1) return;

            if (raNhomToanKhoa.Checked)
            {
                if (fgDanhSach.GetDataDisplay(fgDanhSach.Row, 6) == "")
                {
                    MessageBox.Show("Chọn Mã phiếu lỉnh cần hủy", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else
            {
                if (fgDanhSach.GetDataDisplay(fgDanhSach.Row, 8) == "")
                {
                    MessageBox.Show("Chọn Mã phiếu lỉnh cần hủy", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            System.Data.SqlClient.SqlTransaction tra = Global.ConnectSQL.BeginTransaction();
            SQLCmd.Transaction = tra;
            try
            {
                if (MessageBox.Show("Bạn có muốn khôi phục lần duyệt này không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    SQLCmd.CommandText = String.Format("Update phieudieutri_chitiet set dathuchien = 1,NgayIn='{0:dd/MM/yyyy}' ",Global.NgayLV);
                    if (raNhomToanKhoa.Checked)
                    {
                        SQLCmd.CommandText += " where MaPhieuDuyet='" + fgDanhSach.GetDataDisplay(fgDanhSach.Row, 6) + "'";
                    }
                    else
                    {
                        SQLCmd.CommandText += " where MaPhieuDuyet='" + fgDanhSach.GetDataDisplay(fgDanhSach.Row, 8) + "'";
                    }

                    SQLCmd.CommandText += String.Format(" Update chiphi_ThuThuat set DaThucHien = 1,NgayIn='{0:dd/MM/yyyy}' ", Global.NgayLV);
                    if (raNhomToanKhoa.Checked)
                    {
                        SQLCmd.CommandText += " where MaPhieuDuyet='" + fgDanhSach.GetDataDisplay(fgDanhSach.Row, 6) + "'";
                    }
                    else
                    {
                        SQLCmd.CommandText += " where MaPhieuDuyet='" + fgDanhSach.GetDataDisplay(fgDanhSach.Row, 8) + "'";
                    }

                    SQLCmd.CommandText += String.Format(" Update [" + Global.glbKhamBenh + "].dbo.tblChiPhi_DichVu set DaThucHien = 1,NgayIn='{0:dd/MM/yyyy}' ", Global.NgayLV);
                    if (raNhomToanKhoa.Checked)
                    {
                        SQLCmd.CommandText += " where MaPhieuDuyet='" + fgDanhSach.GetDataDisplay(fgDanhSach.Row, 6) + "'";
                    }
                    else
                    {
                        SQLCmd.CommandText += " where MaPhieuDuyet='" + fgDanhSach.GetDataDisplay(fgDanhSach.Row, 8) + "'";
                    }
                }
                SQLCmd.ExecuteNonQuery();
                tra.Commit();
                cmdTongHop_Click(sender, e);
            }
            catch (Exception ex)
            {
                tra.Rollback();
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                SQLCmd.Dispose();
            }
        }

        private void fgDanhSach_Click_1(object sender, EventArgs e)
        {
            if (fgDanhSach.Rows.Count <= 0) return;
            if (fgDanhSach.Tag.ToString() == "0") return;
            if (fgDanhSach.Row < 0) return;
            if (raNhomToanKhoa.Checked)
            {
                MaDuyetThuoc = fgDanhSach.GetDataDisplay(fgDanhSach.Row, 6);
            }
            else
            {
                MaDuyetThuoc = fgDanhSach.GetDataDisplay(fgDanhSach.Row, 8);
            }
        }

        private void cmbNhomLenCP_TextChanged(object sender, EventArgs e)
        {
            if (cmbKhoa.Tag.ToString() == "0") return;
            if (cmbNhom.Tag.ToString() == "0") return;
            if (raNhomToanKhoa.Tag.ToString() == "0") return;
            if (raNhomTheoCP.Tag.ToString() == "0") return;
            if (raNhomTBN.Tag.ToString() == "0") return;
            if (txtDNgay.Tag.ToString() == "0") return;
            if (txtTNgay.Tag.ToString() == "0") return;
            if (fgDanhSach.Tag.ToString() == "0") return;
            if (cmbNhomLenCP.SelectedIndex == -1)
            {
                MessageBox.Show("Chọn nhóm lên chi phí.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbNhomLenCP.Focus();
                return;
            }
            fgDanhSach.Tag = 0;
            cmdTongHop_Click(sender, e);
            fgDanhSach.Tag = 1;
        }
    }
}