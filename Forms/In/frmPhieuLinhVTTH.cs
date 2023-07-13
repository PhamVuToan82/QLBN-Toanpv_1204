using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GlobalModuls;
using System.Data.SqlClient;

namespace NamDinh_QLBN.Forms.In
{
    public partial class frmPhieuLinhVTTH : Form
    {
        string TuNgay, DenNgay;
        private String MaDuyetThuoc = "";

        public frmPhieuLinhVTTH()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            try
            {
                TuNgay = txtTNgay.Value.ToString();
                DenNgay = txtDNgay.Value.ToString();
                Global.wait("Đang tổng hợp dữ liệu ...");
                String Str = "", MaVaoVien = "", DieuKien = "", DieuKien2 = "";
                int STT = 0, STT1 = 0;
                if (raNhomToanKhoa.Checked)
                {
                    if (!chDaThucHien.Checked)
                    {
                        DieuKien = " and DaThucHien = 0 ";
                        DieuKien2 = " and DaThucHien = 0 ";
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
                    Str = String.Format("set dateformat dmy Select MaDichVu,TenDichVu,DVT,sum(SoLuong) as SoLuong,DathucHien,MaPhieuDuyet,Loai from"
                        + " (SELECT a.MaDichVu,c.TenDichVu, c.DVT,SoLuong,A.DaThucHien,a.MaPhieuDuyet,'NT' as Loai "
                        + " FROM PHIEUDIEUTRI_CHITIET a INNER JOIN BENHNHAN_PHIEUDIEUTRI b ON a. SoPhieu=b.SoPhieu "
                        + " INNER JOIN DMDICHVU c ON a.MaDichVu=c.MaDichVu "
                        + " WHERE b.MaKhoa = '{0}' AND a.LoaiDichVu in ('D02','D06') AND DateDiff(dd,b.NgayChiDinh,'{1:dd/MM/yyyy}') <= 0 and DateDiff(dd,b.NgayChiDinh,'{2:dd/MM/yyyy}') >= 0 and (a.MaNhom = {3} or {3}=0) " + DieuKien
                        + " Union all"
                        + " SELECT dm.MADICHVU,dm.TENDICHVU,dm.DVT,A.SOLUONG,A.DaThucHien,A.MaPhieuDuyet,'PT' as Loai"
                        + " FROM BENHNHAN_PT_CHIPHI A INNER JOIN DMDICHVU dm ON A.MADICHVU = dm.MADICHVU"
                        + " WHERE A.LOAICHIPHI IN ('D02','D06') AND DATEDIFF(DD,A.NGAYCHIDINH,'{1:dd/MM/yyyy}') <= 0 "
                        + " AND DATEDIFF(DD,A.NGAYCHIDINH,'{2:dd/MM/yyyy}') >= 0 and '{0}'='NV1103'" + DieuKien2
                        + " Union all"
                        + " select dmdichvu.MaDichVu,dmdichvu.tendichvu,dmdichvu.dvt,soluong,b.dathuchien,b.MaPhieuDuyet,'KB' as Loai"
                        + " from namdinh_khambenh.dbo.tblChiPhi_DichVu b"
                        + " inner join dmdichvu on dmdichvu.madichvu = b.machiphi"
                        + " where datediff(dd,NgayThucHien,'{1:dd/MM/yyyy}') <= 0 and datediff(dd,NgayThucHien,'{2:dd/MM/yyyy}') >= 0 "
                        + " and b.LoaiChiPhi in ('D02','D06') and b.MaKhoaThucHien in ('{0}') " + DieuKien2 + ") dd "
                        + " Group by MaDichVu,TenDichVu,DVT,DathucHien,MaPhieuDuyet,Loai order by MaPhieuDuyet desc,TenDichVu",
                        GlobalModuls.Global.GetCode(cmbKhoa), txtTNgay.Value, txtDNgay.Value, Global.GetCode(cmbNhomLenCP));
                }
                else
                {
                    Str = String.Format("set dateformat dmy Select DaThucHien,MaVaoVien,HoTen,MaDichVu,DVT,TenDichVu,MaPhieuDuyet,sum(SoLuong) as SoLuong,Loai"
                        + " from ("
                        + " SELECT pdtct.DaThucHien,pdt.MaVaoVien,bn.HoTen,pdtct.MaDichVu,dm.DVT,dm.TenDichvu,pdtct.MaPhieuDuyet,pdtct.SoLuong,'NT' as Loai"
                        + " FROM BENHNHAN bn  INNER JOIN BENHNHAN_CHITIET bnct ON bnct.MABENHNHAN = bn.MABENHNHAN"
                        + " INNER JOIN BENHNHAN_PHIEUDIEUTRI pdt ON pdt.MAVAOVIEN = bnct.MAVAOVIEN "
                        + " INNER JOIN PHIEUDIEUTRI_CHITIET pdtct ON pdt.SOPHIEU = pdtct.SOPHIEU "
                        + " INNER JOIN DMDICHVU dm ON dm.MADICHVU = pdtct.MADICHVU "
                        + " WHERE pdt.MaKhoa='{0}' and pdtct.LoaiDichVu in ('D02','D06') and (pdtct.MaNhom={3} or {3}=0) "
                        + " and DATEDIFF(DD,pdt.NGAYCHIDINH,'{1:dd/MM/yyyy} 00:00:00') <= 0 and DATEDIFF(DD,pdt.NGAYCHIDINH,'{2:dd/MM/yyyy} 00:00:00') >= 0"
                            , GlobalModuls.Global.GetCode(cmbKhoa), txtTNgay.Value, txtDNgay.Value, Global.GetCode(cmbNhomLenCP));
                    if (!chDaThucHien.Checked)
                    {
                        Str += " and pdtct.DATHUCHIEN = 0 ";
                    }
                    if (cmbNhom.SelectedIndex == 1)
                    {
                        Str += " AND pdt.Nhom = 0 ";
                    }
                    else
                    {
                        if (cmbNhom.SelectedIndex == 2)
                        {
                            Str += " AND pdt.Nhom = 1 ";
                        }
                    }
                    Str += String.Format("Union all"
                        + " SELECT C.DaThucHien,B.MAVAOVIEN,A.HOTEN,dm.MADICHVU,dm.TENDICHVU,dm.DVT,C.MAPHIEUDUYET,C.SOLUONG,'PT' as Loai FROM"
                        + " (BENHNHAN A INNER JOIN BENHNHAN_CHITIET B ON A.MABENHNHAN = B.MABENHNHAN)"
                        + " INNER JOIN BENHNHAN_PT_CHIPHI C ON C.MAVAOVIEN = B.MAVAOVIEN"
                        + " INNER JOIN DMDICHVU dm ON dm.MADICHVU = C.MADICHVU AND dm.LOAIDICHVU = C.LOAICHIPHI"
                        + " WHERE C.LOAICHIPHI IN ('D02','D06') AND DATEDIFF(DD,C.NGAYCHIDINH,'{0:dd/MM/yyyy}') <= 0 AND DATEDIFF(DD,C.NGAYCHIDINH,'{1:dd/MM/yyyy}') >= 0 and '{2}'='NV1103'",
                        txtTNgay.Value,
                        txtDNgay.Value, GlobalModuls.Global.GetCode(cmbKhoa));
                    if (!chDaThucHien.Checked)
                    {
                        Str += " and c.DATHUCHIEN = 0 ";
                    }
                    Str += String.Format(" Union all"
                        + " select b.dathuchien,b.MaKhamBenh as MaVaoVien,bn.TenBenhNhan as HoTen,b.MaChiPhi as MaDichVu,dm.DVT,dm.tendichvu,b.MaPhieuDuyet,b.soluong,'KB' as Loai"
                        + " from namdinh_khambenh.dbo.tblChiPhi_DichVu b"
                        + " inner join dmdichvu dm on dm.madichvu = b.machiphi"
                        + " inner join namdinh_khambenh.dbo.tblKhamBenh kb on b.MaKhamBenh = kb.MaKhamBenh"
                        + " inner join namdinh_khambenh.dbo.tblBenhNhan bn on bn.MabenhNhan = kb.MaBenhNhan"
                        + " where datediff(dd,NgayThucHien,'{1:dd/MM/yyyy}') <= 0 and datediff(dd,NgayThucHien,'{2:dd/MM/yyyy}') >= 0 "
                        + " and b.LoaiChiPhi in ('D02','D06') and b.MaKhoaThucHien = '{0}'", GlobalModuls.Global.GetCode(cmbKhoa), txtTNgay.Value, txtDNgay.Value);
                    if (!chDaThucHien.Checked)
                    {
                        Str += " and b.DATHUCHIEN = 0 ";
                    }

                    if (raNhomTBN.Checked)
                    {
                        Str += " ) dd Group by DaThucHien,MaVaoVien,HoTen,MaDichVu,DVT,MaPhieuDuyet,TenDichvu,Loai"
                            + " order by MaPhieuDuyet desc,DATHUCHIEN,MAVAOVIEN,HOTEN,TenDichvu";
                    }
                    else
                    {
                        Str += " ) dd Group by DaThucHien,MaVaoVien,HoTen,MaDichVu,DVT,MaPhieuDuyet,TenDichvu,Loai"
                            + " ORDER BY MaPhieuDuyet desc,DATHUCHIEN,TENDICHVU,HOTEN,MAVAOVIEN";
                    }
                }
                System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
                SQLCmd.CommandText = Str;
                System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(SQLCmd);
                System.Data.DataSet ds = new DataSet();
                ds.Clear();
                da.Fill(ds);
                fgDanhSach.Redraw = false;
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
                        fgDanhSach.AddItem(String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}",
                            fgDanhSach.Rows.Count, Row["DaThucHien"], Row["MaDichVu"],
                            Row["TenDichVu"], Row["SoLuong"], Row["DVT"], Row["MaPhieuDuyet"], Row["Loai"]));
                    }
                    fgDanhSach[0, 0] = "Số TT";
                    fgDanhSach[0, 1] = "Thực hiện";
                    fgDanhSach[0, 2] = "Mã thuốc";
                    fgDanhSach[0, 3] = "Tên thuốc";
                    fgDanhSach[0, 4] = "Số lượng";
                    fgDanhSach[0, 5] = "ĐVT";
                    fgDanhSach[0, 6] = "Mã phiếu lỉnh";
                    fgDanhSach[0, 7] = "Loại phiếu";
                    fgDanhSach.Cols[2].Visible = fgDanhSach.Cols[7].Visible = fgDanhSach.Cols[8].Visible = false;
                    fgDanhSach.Cols[3].Visible = fgDanhSach.Cols[4].Visible = true;
                }
                else
                {
                    fgDanhSach.Cols[7].Visible = fgDanhSach.Cols[8].Visible = true;
                    fgDanhSach.Tree.Column = 5;
                    fgDanhSach.Cols[4].DataType = typeof(object);
                    fgDanhSach.Cols[6].DataType = typeof(Decimal);
                    fgDanhSach.Cols[6].Format = "#,##0.##";
                    if (raNhomTBN.Checked)
                    {
                        fgDanhSach.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Free;
                        fgDanhSach.Cols[6].AllowMerging = false;
                        fgDanhSach.Cols[8].AllowMerging = true;
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
                                STT1.ToString(), Row["DaThucHien"], Row["MaVaoVien"], STT.ToString() + ": " + Row["HoTen"],
                                Row["MaDichVu"], Row["TenDichVu"], Row["SoLuong"], Row["DVT"], Row["MaPhieuDuyet"], Row["Loai"]));
                        }
                        fgDanhSach[0, 0] = "Số TT";
                        fgDanhSach[0, 1] = "Thực hiện";
                        fgDanhSach[0, 2] = "Mã bệnh nhân";
                        fgDanhSach[0, 3] = "Tên bệnh nhân";
                        fgDanhSach[0, 4] = "Mã thuốc";
                        fgDanhSach[0, 5] = "Tên thuốc";
                        fgDanhSach[0, 6] = "Số lượng";
                        fgDanhSach[0, 7] = "ĐVT";
                        fgDanhSach[0, 8] = "Mã phiếu lỉnh";
                        fgDanhSach[0, 9] = "Loại phiếu";
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
                                STT1.ToString(), Row["DaThucHien"], Row["MaDichVu"], STT.ToString() + ": " + Row["TenDichVu"],
                                Row["MaVaoVien"], Row["HoTen"], Row["SoLuong"], Row["DVT"], Row["MaPhieuDuyet"], Row["Loai"]));
                        }
                        fgDanhSach[0, 0] = "Số TT";
                        fgDanhSach[0, 1] = "Thực hiện";
                        fgDanhSach[0, 2] = "Mã dịch vụ";
                        fgDanhSach[0, 3] = "Tên thuốc";
                        fgDanhSach[0, 4] = "Mã bệnh nhân";
                        fgDanhSach[0, 5] = "Tên bệnh nhân";
                        fgDanhSach[0, 6] = "Số lượng";
                        fgDanhSach[0, 7] = "ĐVT";
                        fgDanhSach[0, 8] = "Mã phiếu lỉnh";
                        fgDanhSach[0, 9] = "Loại phiếu";
                        fgDanhSach.Cols[2].Visible = fgDanhSach.Cols[3].Visible = fgDanhSach.Cols[4].Visible = false;
                        STT = 0;
                        MaVaoVien = "";
                        STT1 = 1;
                    }

                    fgDanhSach.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.Sum, 0, 3, 6, "{0}");
                }
                fgDanhSach.AutoSizeCols(1, fgDanhSach.Cols.Count - 1, 1);
                fgDanhSach.Redraw = true;
                SQLCmd.Dispose();
                cmbHuy.Visible = cmbKhoiPhuc.Visible = false;
                /*
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
                */
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                Global.nowait();
            }
        }

        private void Refresh()
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
            LoadData();
            fgDanhSach.Tag = 1;
            fgDanhSach_Click(null, null);
        }

        private void frmPhieuLinhVTTH_Load(object sender, EventArgs e)
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
            cmbNhomLenCP.AddItem(string.Format("{0};{1}",0, "Tất cả"));
            while (dr.Read())
            {
                cmbNhomLenCP.AddItem(string.Format("{0};{1}", dr["MaNhom"], dr["TenNhom"]));
            }
            cmbNhomLenCP.SelectedIndex = 0;
            cmbNhomLenCP.Tag = "1";
            dr.Close();
            SQLCmd.Dispose();
            cmbKhoa.SelectedIndex = 0;
            if (cmbKhoa.ListCount == 1) cmbKhoa.SelectedIndex = 0;
            txtTNgay.Value = txtDNgay.Value = GlobalModuls.Global.NgayLV;
            cmbNhom.AddItem("--------- Tất cả---------");
            cmbNhom.AddItem("Chi phí trong ngày");
            cmbNhom.AddItem("Chi phí bất thường");
            cmbNhom.SelectedIndex = 0;
            C1.Win.C1FlexGrid.CellStyle cs = fgDanhSach.Styles[C1.Win.C1FlexGrid.CellStyleEnum.Subtotal0];
            cs.BackColor = Color.LightBlue;
            cs.ForeColor = Color.DarkBlue;
            Refresh();
            cmbKhoa.Tag = 1;
            txtTNgay.Tag = txtDNgay.Tag = 1;
            raNhomTBN.Tag = raNhomTheoCP.Tag = raNhomToanKhoa.Tag = 1;
            cmbNhom.Tag = 1;
        }

        private void DuyetThuoc()
        {
            String Str = "";
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
            System.Data.SqlClient.SqlTransaction trn = Global.ConnectSQL.BeginTransaction();
            SQLCmd.Transaction = trn;
            try
            {
                Str = String.Format("set dateformat dmy DECLARE @MAPHIEUDUYET NVARCHAR(50),@s_ngay varchar(6),@SoLuuTru varchar(11) "
                    + " set @s_ngay= Right(Convert(nvarchar(8),'{0:yyyyMMdd}',112),6)", Global.NgayLV);
                if (GlobalModuls.Global.GetCode(cmbKhoa) == "NV1103")
                {
                    Str += " exec dbo.LayMaDuyetThuoc_PM @s_ngay,@MAPHIEUDUYET output ";
                }
                else Str += " exec dbo.LayMaDuyetThuoc1 @s_ngay,@MAPHIEUDUYET output ";
                Str += String.Format(" exec dbo.GetNextSoLuuTruVTNT @MaPhieuDuyet,'{1}',@SoLuuTru output ", Global.NgayLV, GlobalModuls.Global.GetCode(cmbKhoa));
                if (GlobalModuls.Global.GetCode(cmbKhoa) != "NV1103")
                {
                    Str += String.Format("UPDATE PHIEUDIEUTRI_CHITIET SET DATHUCHIEN = 1,NgayIn='{0:dd/MM/yyyy}'", Global.NgayLV);
                    Str += String.Format(",MaPhieuDuyet = @MAPHIEUDUYET WHERE (MaPhieuDuyet ='' or MaPhieuDuyet is null) and LOAIDICHVU in ('D02','D06') AND DATHUCHIEN = 0 AND SOPHIEU IN (SELECT SOPHIEU FROM BENHNHAN_PHIEUDIEUTRI "
                        + " WHERE DateDiff(dd,NgayChiDinh,'{0:dd/MM/yyyy} 00:00:00') <= 0  and DateDiff(dd,NgayChiDinh,'{1:dd/MM/yyyy} 00:00:00') >= 0 "
                        + "  AND MAKHOA = '{2}' and (MaNhom={3} or {3}=0) ",
                        txtTNgay.Value, txtDNgay.Value, GlobalModuls.Global.GetCode(cmbKhoa), GlobalModuls.Global.GetCode(cmbNhomLenCP));
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
                    Str += String.Format(" Update [" + Global.glbKhamBenh + "].dbo.tblChiPhi_DichVu set DaThucHien = 1,NgayIn='{0:dd/MM/yyyy}'", Global.NgayLV);
                    Str += String.Format(",MaPhieuDuyet= @MAPHIEUDUYET Where (MaPhieuDuyet ='' or MaPhieuDuyet ='null') and LoaiChiPhi in ('D02','D06') and dathuchien = 0 and MaKhoaThucHien in ('{0}')"
                        + " and datediff(dd,NgayThucHien,'{1:dd/MM/yyyy}') <= 0 and datediff(dd,NgayThucHien,'{2:dd/MM/yyyy}') >= 0 ", Global.GetCode(cmbKhoa), txtTNgay.Value, txtDNgay.Value);
                }
                else Str += String.Format("UPDATE BENHNHAN_PT_CHIPHI SET DATHUCHIEN = 1,NGAYIN='{0:dd/MM/yyyy}',MaPhieuDuyet=@MAPHIEUDUYET"
                       + " WHERE (MaPhieuDuyet ='' or MaPhieuDuyet ='null') and DATEDIFF(DD,NGAYCHIDINH,'{2:dd/MM/yyyy}') <= 0 AND DATEDIFF(DD,NGAYCHIDINH,'{3:dd/MM/yyyy}') >= 0"
                       + " AND LOAICHIPHI IN ('D02','D06') AND DATHUCHIEN = 0",
                       GlobalModuls.Global.NgayLV,
                       MaDuyetThuoc,
                       txtTNgay.Value,
                       txtDNgay.Value,
                       Global.GetCode(this.cmbKhoa));

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
            LoadData();
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
                Refresh();
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
            if (raNhomTheoCP.Checked)
                Refresh();
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
            if (raNhomTBN.Checked)
                Refresh();
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
            Refresh();
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
            Refresh();
            fgDanhSach.Tag = 1;
        }

        private void cmbHuy_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn sẽ không thê khôi phục lại mã phiếu này nữa! Tiếp tục ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.No)
                return;
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
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlTransaction tra = Global.ConnectSQL.BeginTransaction();
            SQLCmd.Transaction = tra;
            try
            {
                //Kiem tra xem da duoc duyet hay chua
                if (raNhomToanKhoa.Checked)
                {
                    SQLCmd.CommandText = String.Format("Select * from phieudieutri_chitiet where MaPhieuDuyet ='{0}' And DaDuyet = 1", fgDanhSach.GetDataDisplay(fgDanhSach.Row, 6));
                }
                else
                {
                    SQLCmd.CommandText = String.Format("Select * from phieudieutri_chitiet where MaPhieuDuyet ='{0}' And DaDuyet = 1", fgDanhSach.GetDataDisplay(fgDanhSach.Row, 8));
                }
                dr = SQLCmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MessageBox.Show("Khoa dược đã duyệt. Không thể hủy", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dr.Close();
                    tra.Dispose();
                    return;
                }
                dr.Close();
                if (MessageBox.Show("Bạn có muốn hủy không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    SQLCmd.CommandText = String.Format("Update phieudieutri_chitiet set dathuchien = 0,NgayIn= null,MaPhieuDuyet='' ");
                    if (raNhomToanKhoa.Checked)
                    {
                        SQLCmd.CommandText += " where MaPhieuDuyet='" + fgDanhSach.GetDataDisplay(fgDanhSach.Row, 6) + "'";
                    }
                    else
                    {
                        SQLCmd.CommandText += " where MaPhieuDuyet='" + fgDanhSach.GetDataDisplay(fgDanhSach.Row, 8) + "'";
                    }
                    SQLCmd.CommandText += String.Format("Update BENHNHAN_PT_CHIPHI set dathuchien = 0,NgayIn= null,MaPhieuDuyet='' ");
                    if (raNhomToanKhoa.Checked)
                    {
                        SQLCmd.CommandText += " where MaPhieuDuyet='" + fgDanhSach.GetDataDisplay(fgDanhSach.Row, 6) + "'";
                    }
                    else
                    {
                        SQLCmd.CommandText += " where MaPhieuDuyet='" + fgDanhSach.GetDataDisplay(fgDanhSach.Row, 8) + "'";
                    }
                    SQLCmd.CommandText += String.Format(" Update [" + Global.glbKhamBenh + "].dbo.tblChiPhi_DichVu set DaThucHien = 0,NgayIn=Null,MaPhieuDuyet='' ");
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
                Refresh();
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
            MessageBox.Show("Tạm khóa chức năng nă !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
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
                    SQLCmd.CommandText = String.Format("Update phieudieutri_chitiet set dathuchien = 1,NgayIn='{0:dd/MM/yyyy}' ", Global.NgayLV);
                    if (raNhomToanKhoa.Checked)
                    {
                        SQLCmd.CommandText += " where MaPhieuDuyet='" + fgDanhSach.GetDataDisplay(fgDanhSach.Row, 6) + "'";
                    }
                    else
                    {
                        SQLCmd.CommandText += " where MaPhieuDuyet='" + fgDanhSach.GetDataDisplay(fgDanhSach.Row, 8) + "'";
                    }
                    SQLCmd.CommandText += String.Format("Update BENHNHAN_PT_CHIPHI set dathuchien = 1,NgayIn='{0:dd/MM/yyyy}' ", Global.NgayLV);
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
                Refresh();
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

        private void fgDanhSach_Click(object sender, EventArgs e)
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
            Refresh();
            fgDanhSach.Tag = 1;
        }

        private void txtTNgay_Validated(object sender, EventArgs e)
        {
            if (cmbKhoa.Tag.ToString() == "0") return;
            if (cmbNhom.Tag.ToString() == "0") return;
            if (raNhomToanKhoa.Tag.ToString() == "0") return;
            if (raNhomTheoCP.Tag.ToString() == "0") return;
            if (raNhomTBN.Tag.ToString() == "0") return;
            if (txtDNgay.Tag.ToString() == "0") return;
            if (txtTNgay.Tag.ToString() == "0") return;
            if (fgDanhSach.Tag.ToString() == "0") return;
            if (txtTNgay.Value.ToString() != TuNgay)
            {
                fgDanhSach.Tag = 0;
                Refresh();
                fgDanhSach.Tag = 1;
            }
        }

        private void txtDNgay_Validated(object sender, EventArgs e)
        {
            if (cmbKhoa.Tag.ToString() == "0") return;
            if (cmbNhom.Tag.ToString() == "0") return;
            if (raNhomToanKhoa.Tag.ToString() == "0") return;
            if (raNhomTheoCP.Tag.ToString() == "0") return;
            if (raNhomTBN.Tag.ToString() == "0") return;
            if (txtDNgay.Tag.ToString() == "0") return;
            if (txtTNgay.Tag.ToString() == "0") return;
            if (fgDanhSach.Tag.ToString() == "0") return;
            if (txtDNgay.Value.ToString() != DenNgay)
            {
                fgDanhSach.Tag = 0;
                Refresh();
                fgDanhSach.Tag = 1;
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInPhieu_Click(object sender, EventArgs e)
        {
            string SoLuuTru = "", _LoaiDichVu = "", _TenNhom = "";
            System.Data.SqlClient.SqlCommand Cmd = new System.Data.SqlClient.SqlCommand();
            Cmd.Connection = GlobalModuls.Global.ConnectSQL;
            Cmd.CommandText = string.Format("SELECT isnull(SoLuuTru,'') FROM PhieuLinhVT_LuuTru WHERE MaPhieu='{0}' and PhongKhoaID='{1}' ", MaDuyetThuoc, Global.GetCode(cmbKhoa));
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
            string title = "";
            if (MaDuyetThuoc == "")
            {
                MessageBox.Show("Chọn Mã phiếu duyệt", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
            SQLCmd.CommandType = CommandType.StoredProcedure;
            if (rdVTTH.Checked)
            {
                title = "PHIẾU LĨNH VẬT TƯ";
                _LoaiDichVu = "D02";
            }
            else
            {
                title = "PHIẾU LĨNH THUỐC D.CHUNG";
                _LoaiDichVu = "D06";
            }
            _TenNhom = GlobalModuls.Global.GetCode(cmbNhomLenCP);
            SQLCmd.CommandText = "InPhieuLinhVTTH";
            SQLCmd.CommandTimeout = 0;
            System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(SQLCmd);
            System.Data.DataSet ds = new DataSet();
            SqlParameter LoaiDV = new SqlParameter("@LoaiDichVu", SqlDbType.VarChar, 3);
            LoaiDV.Value = _LoaiDichVu;
            SQLCmd.Parameters.Add(LoaiDV);
            SqlParameter _MaPhieuDuyet = new SqlParameter("@MaPhieuDuyet", SqlDbType.VarChar, 10);
            _MaPhieuDuyet.Value = MaDuyetThuoc;
            SQLCmd.Parameters.Add(_MaPhieuDuyet);
            SqlParameter NhomCP = new SqlParameter("@NhomLenCP", SqlDbType.TinyInt);
            NhomCP.Value = Global.GetCode(cmbNhomLenCP);
            _TenNhom =  cmbNhomLenCP.Text;
            SQLCmd.Parameters.Add(NhomCP);
            SqlParameter MaKhoa = new SqlParameter("@MaKhoa", SqlDbType.VarChar, 10);
            MaKhoa.Value = Global.GetCode(cmbKhoa);
            SQLCmd.Parameters.Add(MaKhoa);
            da.SelectCommand = SQLCmd;
            ds.Clear();
            da.Fill(ds);
            NamDinh_QLBN.Reports.rptPhieuLinhVatTu rpt = new NamDinh_QLBN.Reports.rptPhieuLinhVatTu(cmbKhoa.Text, SoLuuTru, title, _TenNhom);
            rpt.DataSource = ds.Tables[0];
            rpt.Show();
            SQLCmd.Dispose();
        }
    }
}