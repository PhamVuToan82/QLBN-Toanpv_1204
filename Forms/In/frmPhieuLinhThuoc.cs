using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GlobalModuls;
namespace NamDinh_QLBN.Forms.In
{
    public partial class frmPhieuLinhThuoc : Form
    {
        public frmPhieuLinhThuoc()
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
                    Str = String.Format("Select MaDichVu,TenDichVu,DVT,sum(SoLuong) as SoLuong,DathucHien,GhiChu from"
                        + " (Select * from"
                        + " (SELECT a.MaDichVu,c.TenDichVu, c.DVT,Sum(SoLuong)AS SoLuong,A.DaThucHien,"
                        + " case when isnull(a.LuotIn,0) = 0 then N'Chưa chọn để in ' else N'Lượt in ' + Convert(nvarchar(5),a.LuotIn) end as GhiChu  "
                        + " FROM (PHIEUDIEUTRI_CHITIET a INNER JOIN BENHNHAN_PHIEUDIEUTRI b ON a. SoPhieu=b.SoPhieu) "
                        + " INNER JOIN DMDICHVU c ON a.MaDichVu=c.MaDichVu "
                        + " WHERE a.UserName = '"+ Global.glbUName +"' and b.MaKhoa = '{0}' AND a.LoaiDichVu in ('D01','D05') AND DateDiff(dd,b.NgayChiDinh,'{1:MM/dd/yyyy}') <= 0 and DateDiff(dd,b.NgayChiDinh,'{2:MM/dd/yyyy}') >= 0 " + DieuKien
                        + " GROUP BY c.TenDichVu,c.DVT,a.MaDichVu,A.DaThucHien,a.LuotIn) aa"
                        + " Union ALL"
                        + " Select * from"
                        + " (Select dmDichVu.MaDichVu,TenDichVu,DVT,sum(SoLuong) as SoLuong,DaThucHien,"
                        + " case when bb.LuotIn = 0 then N'Chưa chọn để in ' else N'Lượt in ' + Convert(nvarchar(5),bb.LuotIn) end as GhiChu from"
                        + " (Select * from chiphi_thuthuat b Where b.Username =N'" + Global.glbUName + "' and b.MaKhoa = '{0}' AND b.LoaiDichVu in ('D01','D05') " + DieuKien
                        + " AND DateDiff(dd,b.NgayThucHien,'{1:MM/dd/yyyy}') <= 0 and DateDiff(dd,b.NgayThucHien,'{2:MM/dd/yyyy}') >= 0) BB"
                        + " Inner join dmDichVu on dmDichVu.MaDichVu =  bb.MaChiPhi"
                        + " Group by dmDichVu.MaDichVu,TenDichVu,DVT,DaThucHien,bb.LuotIn) EE) dd"
                        + " Group by MaDichVu,TenDichVu,DVT,DathucHien,GhiChu",
                        GlobalModuls.Global.GetCode(cmbKhoa),
                        txtTNgay.Value,txtDNgay.Value);
                }
                else
                {
                    Str = String.Format("Select DaThucHien,MaVaoVien,HoTen,MaDichVu,TenDichVu,DVT,GhiChu,TT_HN,sum(SOLUONG) as SOLUONG from "
                           + " (SELECT case when IsNull(LuotIn,0) = 0 then N'Chưa chọn để in ' else N'Lượt in ' + Convert(nvarchar(5),LuotIn) end  as GhiChu,"
                           + " DaThucHien,DD.MaDichVu,TenDichVu,MaVaoVien,HoTen,DVT,SoLuong,0 as TT_HN"
                           + " FROM (SELECT CC.*,PH.LOAIDICHVU,PH.MADICHVU,PH.SOLUONG,PH.DONGIA,PH.GHICHU,PH.DOITUONGBN,PH.DATHUCHIEN,PH.LuotIn"
                           + " FROM (SELECT BB.*,BENHNHAN_PHIEUDIEUTRI.SOPHIEU,BENHNHAN_PHIEUDIEUTRI.NGAYCHIDINH,BENHNHAN_PHIEUDIEUTRI.LOAIDT, "
                           + " BENHNHAN_PHIEUDIEUTRI.BACSYDT, BENHNHAN_PHIEUDIEUTRI.DIENBIENBENH,BENHNHAN_PHIEUDIEUTRI.YLENH,"
                           + " BENHNHAN_PHIEUDIEUTRI.CDCHAMSOC, BENHNHAN_PHIEUDIEUTRI.CDDINHDUONG,BENHNHAN_PHIEUDIEUTRI.MAKHOA,"
                           + " BENHNHAN_PHIEUDIEUTRI.NHOM FROM (SELECT AA.*,BENHNHAN_CHITIET.MAVAOVIEN "
                           + " FROM (SELECT * FROM BENHNHAN) AA  INNER JOIN BENHNHAN_CHITIET ON BENHNHAN_CHITIET.MABENHNHAN = AA.MABENHNHAN) BB "
                           + " INNER JOIN BENHNHAN_PHIEUDIEUTRI ON BENHNHAN_PHIEUDIEUTRI.MAVAOVIEN = BB.MAVAOVIEN "
                           + " WHERE BENHNHAN_PHIEUDIEUTRI.MAKHOA = '{0}') CC "
                           + " INNER JOIN PHIEUDIEUTRI_CHITIET PH ON PH.SOPHIEU = CC.SOPHIEU and username=N'{1}' "
                           + " WHERE  ", GlobalModuls.Global.GetCode(cmbKhoa),Global.glbUName);
                    if (chDaThucHien.Checked)
                    {

                    }
                    else
                    {
                        Str += " PH.DATHUCHIEN = 0 AND ";
                    }
                    Str += String.Format("  PH.LOAIDICHVU in ('D01','D05')) DD"
                        + " INNER JOIN DMDICHVU ON DMDICHVU.MADICHVU = DD.MADICHVU"
                        + " WHERE DATEDIFF(DD,DD.NGAYCHIDINH,'{0:MM/dd/yyyy} 00:00:00') <= 0 and DATEDIFF(DD,DD.NGAYCHIDINH,'{1:MM/dd/yyyy} 00:00:00') >= 0",
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
                           + " Select case when IsNull(LuotIn,0) = 0 then N'Chưa chọn để in ' else N'Lượt in ' + Convert(nvarchar(5),LuotIn) end  as GhiChu,"
                           + " DaThucHien,MaDichVu,TenDichVu,MaVaoVien,HoTen,DVT,SoLuong,1 as TT_HN from"
                           + " (Select bb.*,benhnhan.hoten from"
                           + " (select aa.MaVaoVien,aa.MaChiPhi as MaDichVu,aa.SoLuong,aa.LuotIn,aa.DaThucHien,dmdichvu.TenDichVu,dmdichvu.DVT,benhnhan_chitiet.mabenhnhan from"
                           + " (Select * from chiphi_thuthuat where username=N'"+ Global.glbUName +"' and loaidichvu in ('D01','D05') and makhoa='{0}' and DATEDIFF(DD,NgayThucHien,'{1:MM/dd/yyyy}') <= 0 and DATEDIFF(DD,NgayThucHien,'{2:MM/dd/yyyy}') >= 0",
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
                    Str += " ) aa inner join dmdichvu on dmdichvu.madichvu = aa.machiphi"
                            + " inner join benhnhan_chitiet on benhnhan_chitiet.MaVaoVien = aa.MaVaoVien) bb"
                            + " inner join benhnhan on benhnhan.mabenhnhan = bb.mabenhnhan) cc) dd";
                    if (raNhomTBN.Checked)
                    {
                        Str += " Group by DaThucHien,MaVaoVien,HoTen,MaDichVu,TenDichVu,DVT,GhiChu,TT_HN"
                            + " ORDER BY DATHUCHIEN,MAVAOVIEN,HOTEN,TENDICHVU";
                    }
                    else
                    {
                        Str += " Group by DaThucHien,MaVaoVien,HoTen,MaDichVu,TenDichVu,DVT,GhiChu,TT_HN"
                            + " ORDER BY DATHUCHIEN,TENDICHVU,HOTEN,MAVAOVIEN";
                    }
                }

                System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
                SQLCmd.CommandText = Str;
                System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(SQLCmd);
                System.Data.DataSet ds = new DataSet();
                ds.Clear();
                da.Fill(ds);
                fgDanhSach.ClipSeparators = "|;";
                fgDanhSach.Rows.Count = 1;
                if (raNhomToanKhoa.Checked)
                {
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
                    fgDanhSach[0, 6] = "Ghi chú";
                    fgDanhSach.Cols[2].Visible = fgDanhSach.Cols[7].Visible = fgDanhSach.Cols[8].Visible = false;
                    fgDanhSach.Cols[3].Visible = fgDanhSach.Cols[4].Visible = true;
                }
                else
                {
                    fgDanhSach.Cols[7].Visible = fgDanhSach.Cols[8].Visible = true;
                    fgDanhSach.Tree.Column = 5;
                    if (raNhomTBN.Checked)
                    {
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
                        fgDanhSach[0, 8] = "Ghi chú";
                        fgDanhSach.Cols[2].Visible = fgDanhSach.Cols[3].Visible = fgDanhSach.Cols[4].Visible = false;
                        STT = 0;
                        MaVaoVien = "";
                        STT1 = 1;
                    }
                    else
                    {
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
                        fgDanhSach[0, 8] = "Ghi chú";
                        fgDanhSach.Cols[2].Visible = fgDanhSach.Cols[3].Visible = fgDanhSach.Cols[4].Visible = false;
                        STT = 0;
                        MaVaoVien = "";
                        STT1 = 1;
                    }

                    fgDanhSach.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.Sum, 0, 3, 6, "{0}");
                }
                fgDanhSach.AutoSizeCols(1, fgDanhSach.Cols.Count - 1, 1);
                SQLCmd.Dispose();
                
            }
            catch{
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
            cmdChonGui.Text = "Chọn tất cả";
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
            Cmd.CommandText = string.Format("SELECT isnull(SoLuuTru,'') FROM PhieuLinh_LuuTru WHERE MaPhieu='{0}' and PhongKhoaID='{1}' ", "", Global.GetCode(cmbKhoa));
            if (Cmd.ExecuteScalar() != null) SoLuuTru = Cmd.ExecuteScalar().ToString();
            else SoLuuTru = "";
            if (cmbKhoa.SelectedIndex == -1)
            {
                MessageBox.Show("Chưa chọn Khoa điều trị!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cmbKhoa.Focus();
                return;
            }
            if (txtTNgay.ValueIsDbNull )
            {
                MessageBox.Show("Chưa nhập ngày tháng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string Ngay = "",Str = "";
            DateTime TNgay = DateTime.Parse(txtTNgay.Text);
            DateTime DNgay = DateTime.Parse(txtDNgay.Text);
            System.TimeSpan Ngay1 = TNgay - DNgay;
            if (Ngay1.Days == 0)
            {
                Ngay = string.Format("Ngày {0:dd} tháng {0:MM} năm {0:yyyy}", txtTNgay.Value);
            }
            else
            {
                Ngay = string.Format("Từ ngày {0:dd/MM/yyyy} đến ngày {1:dd/MM/yyyy}", txtTNgay.Value, txtDNgay.Value);   
            }
            
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
            
            //Tinh xem co bao nhieu luot in trong ngay
            int LuotIn = 1;
            Str = String.Format("Select * from "
                + " (Select LuotIn from PhieuDieuTri_ChiTiet Where SoPhieu in  "
                + " (Select  BenhNhan_PhieuDieuTri.SoPhieu From BenhNhan_PhieuDieuTri "
                + " inner join phieudieutri_chitiet on phieudieutri_chitiet.sophieu = benhnhan_phieudieutri.sophieu and username=N'"+ Global.glbUName +"'"
                + " Where MaKhoa = '{0}' And  "
                + " DateDiff(dd,NgayChiDinh,'{1:MM/dd/yyyy}') <= 0 and DateDiff(dd,NgayChiDinh,'{2:MM/dd/yyyy}') >= 0) And LoaiDichVu in ('D01','D05') And DaThucHien = 1 "
                + " Group by LuotIn "
                + " union all"
                + " Select LuotIn from chiphi_thuthuat where MaKhoa = '{0}' and datediff(dd,ngaythuchien,'{1:MM/dd/yyyy}') <= 0"
                + " and datediff(dd,ngaythuchien,'{2:MM/dd/yyyy}') >= 0 And LoaiDichVu in ('D01','D05') And DaThucHien = 1 and username=N'" + Global.glbUName + "'"
                + " group by Luotin) aa"
                + " Group by luotin order by luotin desc",
                GlobalModuls.Global.GetCode(cmbKhoa),
                txtTNgay.Value,
                txtDNgay.Value);
            SQLCmd.CommandText = Str;
            System.Data.DataSet ds = new DataSet();
            System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(SQLCmd);
            da.Fill(ds);

            if(ds.Tables[0].Rows.Count > 1)
            {
                frmHuyLanGui frm = new frmHuyLanGui();
                frm.lbThongBao.Text = "Có " + ds.Tables[0].Rows.Count.ToString() + " lượt chưa in";
                frm.lbChuDai.Text = "Bạn chọn lượt cần in: ";
                foreach (System.Data.DataRow Row in ds.Tables[0].Rows)
                {
                    frm.cmbLanGui.Items.Add(Row["LuotIn"]);
                }
                if (frm.ShowDialog() == DialogResult.Yes)
                {
                    LuotIn = int.Parse(frm.cmbLanGui.Text);
                }
                else
                {
                    return;
                }
            }
            else
            {
                foreach (System.Data.DataRow Row in ds.Tables[0].Rows)
                {
                    LuotIn = int.Parse(Row["LuotIn"].ToString());
                }
            }


            Str = String.Format("Select Nhom,N'Nhận tại kho: ' + E.TENKHO as TENKHO,ee.MaDichVu,"
                + " ee.TenDichVu As [Tên thuốc],ee.DVT as [ĐV tính],SoLuong AS [Số lượng],'' As [Ghi chú] from "
                + " (Select MaDichVu,TenDichVu,LOWER(DVT) AS DVT,sum(SoLuong) as SoLuong,DathucHien,GhiChu from "
                + " (Select * from (SELECT a.MaDichVu,c.TenDichVu, c.DVT,Sum(SoLuong)AS SoLuong,A.DaThucHien, "
                + " case when a.LuotIn = 0 then N'Chưa chọn để in ' else N'Lượt in ' + Convert(nvarchar(5),a.LuotIn) end as GhiChu   "
                + " FROM (PHIEUDIEUTRI_CHITIET a INNER JOIN BENHNHAN_PHIEUDIEUTRI b ON a.SoPhieu=b.SoPhieu)  "
                + " INNER JOIN DMDICHVU c ON a.MaDichVu=c.MaDichVu  WHERE a.username =N'"+ Global.glbUName +"' and b.MaKhoa = '{0}' AND a.LoaiDichVu in ('D01') AND "
                + " DateDiff(dd,b.NgayChiDinh,'{1:MM/dd/yyyy}') <= 0 and DateDiff(dd,b.NgayChiDinh,'{2:MM/dd/yyyy}') >= 0 and a.Luotin= " + LuotIn
                + " GROUP BY c.TenDichVu,c.DVT,a.MaDichVu,A.DaThucHien,a.LuotIn) aa "
                + " Union ALL "
                + " Select * from (Select dmDichVu.MaDichVu,TenDichVu,DVT,sum(SoLuong) as SoLuong,DaThucHien, "
                + " case when bb.LuotIn = 0 then N'Chưa chọn để in ' else N'Lượt in ' + Convert(nvarchar(5),bb.LuotIn) end as GhiChu "
                + " from (Select * from chiphi_thuthuat Where username=N'"+ Global.glbUName +"' and MaKhoa = '{0}' AND LoaiDichVu in ('D01')  and luotIn= " + LuotIn
                + " AND DateDiff(dd,NgayThucHien,'{1:MM/dd/yyyy}') <= 0 "
                + " and DateDiff(dd,NgayThucHien,'{2:MM/dd/yyyy}') >= 0) BB Inner join dmDichVu on dmDichVu.MaDichVu =  bb.MaChiPhi "
                + " Group by dmDichVu.MaDichVu,TenDichVu,DVT,DaThucHien,bb.LuotIn) EE) dd "
                + " Group by MaDichVu,TenDichVu,DVT,DathucHien,GhiChu) ee"
                + " inner join dmdichvu on dmdichvu.madichvu = ee.madichvu"
                + " INNER JOIN SACLAPPHIEU d ON d.LOAITHUOC = dmdichvu.LOAITHUOC AND D.MAKHOA='{0}' "
                + " INNER JOIN ["+ Global.glbDuoc +"].DBO.DANHMUCKHO E ON E.KHOID = D.KHOID Where ",
                Global.GetCode(cmbKhoa),
                txtTNgay.Value,
                txtDNgay.Value);

            if (raDieuTriThuong.Checked)
            {
                Str += " ee.MADICHVU NOT LIKE 'NGHT%' ";
            }
            else
            {
                if (raThuocGayNghien.Checked)
                {
                    Str += " ee.MADICHVU LIKE 'NGHT-GN%' ";
                }
                else
                {
                    if (raThuocHT.Checked)
                    {
                        Str += " ee.MADICHVU LIKE 'NGHT-HT%' ";
                    }
                }
            }
            //if (cmbNhom.SelectedIndex == 0)
            //{
            //}
            //else
            //{
            //    if (cmbNhom.SelectedIndex == 1)
            //    {
            //        Str += " and Nhom = 0 ";
            //    }
            //    else
            //    {
            //        Str += " and Nhom = 1 ";
            //    }
            //}
            Str += " ORDER BY Nhom,ee.TenDichVu";
            //truong hop in thuoc dong y
            if (raThuocDongY.Checked)
            {
                Str = String.Format("select * from "
                    + " (select aa.*,ct.madichvu,ct.soluong,ct.soluong * aa.sothang as TongSL,ct.DonGia,benhnhan.hoten,year(getdate())- benhnhan.namsinh as tuoi,"
                    + " case when benhnhan.gioitinh = 0 then N'Giới tính: Nữ' else N'Giới tính: Nam' end as GioiTinh,N'Địa chỉ: ' + benhnhan_chitiet.diachi as diachi,"
                    + " N'Đối tượng: ' + dmdoituongbn.tendt + '. ' + N'Số thẻ: ' + v.SoThe as Doituong1,dmbuongbenh.tenbuong as buong1,"
                    + " dmgiuongbenh.tengiuong as Giuong1 from"
                    + " (select N'Chẩn đoán: ' + chandoan as chandoan,mavaovien,sophieu,ngaychidinh,bacsydt,sothang,N'Số lượng thang: ' + CONVERT(nvarchar,sothang) + ' ' + ChuThich  as SoThang1,makhoa from benhnhan_phieudieutri where makhoa ='{0}' and datediff(dd,ngaychidinh,'{1:MM/dd/yyyy}') <= 0  and datediff(dd,ngaychidinh,'{2:MM/dd/yyyy}') >= 0 ) aa"
                    + " inner join phieudieutri_chitiet ct on ct.sophieu = aa.sophieu and username=N'"+ Global.glbUName +"'"
                    + " inner join benhnhan_chitiet on benhnhan_chitiet.mavaovien = aa.mavaovien"
                    + " inner join benhnhan on benhnhan_chitiet.mabenhnhan = benhnhan.mabenhnhan"
                    + " inner join viewdoituonghientai v on v.mavaovien = aa.mavaovien "
                    + " inner join dmdoituongbn on dmdoituongbn.madt = v.doituong "
                    + " left join dmbuongbenh on dmbuongbenh.makhoa = aa.makhoa and dmbuongbenh.id_buong = benhnhan_chitiet.buong"
                    + " left join dmgiuongbenh on dmgiuongbenh.makhoa = aa.makhoa and dmgiuongbenh.id_giuong = benhnhan_chitiet.giuong and dmgiuongbenh.id_buong = benhnhan_chitiet.buong"
                    + " where ct.loaidichvu ='D05' and luotin = "+ LuotIn +") bb"
                    + " inner join dmdichvu on dmdichvu.madichvu = bb.madichvu"
                    + " inner join saclapphieu on saclapphieu.loaithuoc = dmdichvu.loaithuoc and saclapphieu.makhoa = bb.makhoa"
                    + " inner join "+ Global.glbDuoc +".dbo.DanhMucKho kho on kho.khoid = saclapphieu.khoid ",
                    Global.GetCode(cmbKhoa),
                    txtTNgay.Value,
                    txtDNgay.Value);
            }
            SQLCmd.CommandText = Str;
            System.Data.SqlClient.SqlDataReader dr = SQLCmd.ExecuteReader();
            if (raDieuTriThuong.Checked)
            {
                NamDinh_QLBN.Reports.rptPhieuLinhThuoc_Sua rpt = new NamDinh_QLBN.Reports.rptPhieuLinhThuoc_Sua(cmbKhoa.Text, Ngay,SoLuuTru,cmbNhom.Text);
                rpt.DataSource = dr;
                rpt.Show();
            }
            else
            {
                if (raThuocGayNghien.Checked)
                {
                    NamDinh_QLBN.Reports.BaoCaoVeThuoc.rptPhieuLinhThuocGayNghien rpt = new NamDinh_QLBN.Reports.BaoCaoVeThuoc.rptPhieuLinhThuocGayNghien(cmbKhoa.Text, Ngay);
                    rpt.DataSource = dr;
                    rpt.Show();
                }
                else
                {
                    if (raThuocHT.Checked)
                    {
                        NamDinh_QLBN.Reports.BaoCaoVeThuoc.rptPhieuLinhThuocHuongThan rpt = new NamDinh_QLBN.Reports.BaoCaoVeThuoc.rptPhieuLinhThuocHuongThan(cmbKhoa.Text, Ngay);
                        rpt.DataSource = dr;
                        rpt.Show();
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
            if (cmdChonGui.Text == "Chọn tất cả")
            {
                for (int i = 1; i < fgDanhSach.Rows.Count; i++)
                {
                    if ((fgDanhSach.Rows[i].IsNode) || Convert.ToBoolean(fgDanhSach.GetData(i, "ThucHien")) == true) continue;
                    fgDanhSach[i, "ThucHien"] = 1;
                    fgDanhSach.Rows[i].UserData = 1;
                }
                cmdChonGui.Text = "Hủy chọn tất cả";
                return;
            }
            if (cmdChonGui.Text == "Hủy chọn tất cả")
            {
                for (int i = 1; i < fgDanhSach.Rows.Count; i++)
                {
                    if ((fgDanhSach.Rows[i].IsNode) || fgDanhSach.Rows[i].UserData == null) continue;
                    fgDanhSach[i, "ThucHien"] = 0;
                    fgDanhSach.Rows[i].UserData = null;
                }
                cmdChonGui.Text = "Chọn tất cả";
                return;
            }
        }

        private void cmdDuyet_Click(object sender, EventArgs e)
        {
            String Str = "";
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
            try
            {
                if (cmdDuyet.Text == "Duyệt")
                {
                    Str = String.Format("select Max(LuotIn) as LuotIn from"
                        + " (Select isNull(Max(LuotIn),0) as LuotIn From PhieuDieuTri_ChiTiet "
                        + " Where LoaiDichVu in ('D01','D05') And  PhieuDieuTri_ChiTiet.SoPhieu In "
                        + " (Select BenhNhan_PhieuDieuTri.SoPhieu From BenhNhan_PhieuDieuTri  "
                        + " inner join phieudieutri_chitiet on phieudieutri_chitiet.sophieu = benhnhan_phieudieutri.sophieu  and phieudieutri_chitiet.username=N'"+ Global.glbUName +"'"
                        + " WHERE datediff(dd,NgayChiDinh,'{0:MM/dd/yyyy}') <= 0 and datediff(dd,NgayChiDinh,'{1:MM/dd/yyyy}') >= 0 AND MAKHOA = '{2}')"
                        + " Union all"
                        + " Select isNull(Max(LuotIn),0) as luotin from chiphi_thuthuat "
                        + " where datediff(dd,ngaythuchien,'{0:MM/dd/yyyy}') <= 0 and datediff(dd,ngaythuchien,'{1:MM/dd/yyyy}') >= 0 and loaidichvu in ('D01','D05') and "
                        + " makhoa ='{2}' and username=N'"+ Global.glbUName +"') bb", txtTNgay.Value, txtDNgay.Value, Global.GetCode(cmbKhoa));
                     SQLCmd.CommandText = Str;
                    int LuotIn = int.Parse(SQLCmd.ExecuteScalar().ToString());
                    //Tinh luot in
                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    if (LuotIn == 0)
                    {
                        LuotIn += 1;
                    }
                    else
                    {
                        Str = String.Format(" Select * from "
                            + " (Select LuotIn from PhieuDieuTri_ChiTiet Where SoPhieu in  "
                            + " (Select SoPhieu From BenhNhan_PhieuDieuTri "
                            + " Where MaKhoa = '{0}' And  DateDiff(dd,NgayChiDinh,'{1:MM/dd/yyyy} 00:00:00') <= 0 and "
                            + " DateDiff(dd,NgayChiDinh,'{2:MM/dd/yyyy} 00:00:00') >= 0) "
                            + " And LoaiDichVu in ('D01','D05') And DaThucHien = 1 and username=N'" + Global.glbUName + "'", Global.GetCode(cmbKhoa), txtTNgay.Value, txtDNgay.Value);
                        //if (cmbNhom.SelectedIndex == 1)
                        //{
                        //    Str += " And Nhom = 0 ";
                        //}
                        //else
                        //{
                        //    if (cmbNhom.SelectedIndex == 2)
                        //    {
                        //        Str += " And Nhom = 1 ";
                        //    }
                        //    else
                        //    {
                        //    }
                        //}
                        Str += String.Format(" Union all"
                            + " Select isnull(LuotIn,0) as luotin from chiphi_thuthuat where makhoa = '{0}' "
                            + " and DateDiff(dd,ngaythuchien,'{1:MM/dd/yyyy}') <= 0 and DateDiff(dd,ngaythuchien,'{2:MM/dd/yyyy}') >= 0 "
                            + " and LoaiDichVu in ('D01','D05') and dathuchien = 1 and username =N'"+ Global.glbUName +"'", Global.GetCode(cmbKhoa), txtTNgay.Value, txtDNgay.Value);
                        //if (cmbNhom.SelectedIndex == 1)
                        //{
                        //    Str += " And Nhom = 0 ";
                        //}
                        //else
                        //{
                        //    if (cmbNhom.SelectedIndex == 2)
                        //    {
                        //        Str += " And Nhom = 1 ";
                        //    }
                        //    else
                        //    {
                        //    }
                        //}
                        Str += ") bb"
                            + " Group by LuotIn "
                            + " Order by LuotIn Desc";

                        SQLCmd.CommandText = Str;
                        System.Data.DataSet ds = new DataSet();
                        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(SQLCmd);
                        da.Fill(ds);

                        frmHuyLanGui frm = new frmHuyLanGui();
                        frm.lbThongBao.Text = "Bạn có muốn duyệt chung đợt không ?";
                        frm.lbChuDai.Text = "Chọn lượt duyệt: ";
                        frm.cmbLanGui.Items.Add("-- Lượt mới --");
                        foreach (System.Data.DataRow Row in ds.Tables[0].Rows)
                        {
                            frm.cmbLanGui.Items.Add(Row["LuotIn"]);
                        }
                        frm.cmbLanGui.SelectedIndex = 0;
                        if (frm.ShowDialog() == DialogResult.Yes)
                        {
                            if (frm.cmbLanGui.SelectedIndex == 0)
                            {
                                LuotIn += 1;
                            }
                            else
                            {
                                LuotIn = int.Parse(frm.cmbLanGui.Text);
                            }
                        }
                        else
                        {
                            return;
                        }
                    }
                    /////////////////////////////////////////////////////////////////////////////////////////////////////
                    Str = "";
                    if (raNhomToanKhoa.Checked)
                    {
                        for (int i = 1; i < fgDanhSach.Rows.Count; i++)
                        {
                            if (fgDanhSach.Rows[i].UserData == null) continue;
                            Str += "UPDATE PHIEUDIEUTRI_CHITIET SET DATHUCHIEN = ";
                            Str += fgDanhSach.GetDataDisplay(i, "ThucHien").ToLower() == "true" ? 1 : 0;
                            Str += String.Format(",LuotIn = " + LuotIn + " WHERE LOAIDICHVU in ('D01','D05') AND DATHUCHIEN = 0 AND SOPHIEU IN (SELECT SOPHIEU FROM BENHNHAN_PHIEUDIEUTRI "
                                + " WHERE DateDiff(dd,NgayChiDinh,'{0:MM/dd/yyyy} 00:00:00') <= 0  and DateDiff(dd,NgayChiDinh,'{1:MM/dd/yyyy} 00:00:00') >= 0"
                                + "  AND MAKHOA = '{2}' and username=N'"+ Global.glbUName +"' ",
                                txtTNgay.Value, txtDNgay.Value,
                                GlobalModuls.Global.GetCode(cmbKhoa));
                            if (cmbNhom.SelectedIndex == 1)
                            {
                                Str += String.Format(" and nhom = 0) AND MADICHVU = '{0}' ", fgDanhSach.GetDataDisplay(i, 2));
                            }
                            else
                            {
                                if (cmbNhom.SelectedIndex == 2)
                                {
                                    Str += String.Format(" and nhom = 1) AND MADICHVU = '{0}' ", fgDanhSach.GetDataDisplay(i, 2));
                                }
                                else
                                {
                                    Str += String.Format(" ) AND MADICHVU = '{0}' ", fgDanhSach.GetDataDisplay(i, 2));
                                }
                            }
                            Str += " Update chiphi_thuthuat set dathuchien = ";
                            Str += fgDanhSach.GetDataDisplay(i, "ThucHien").ToLower() == "true" ? 1 : 0;
                            Str += String.Format(",LuotIn={0} Where LoaiDichVu in ('D01','D05') and dathuchien =0 and makhoa='{1}'"
                                + " and datediff(dd,NgayThucHien,'{2:MM/dd/yyyy}') <= 0 and datediff(dd,NgayThucHien,'{3:MM/dd/yyyy}') >= 0 "
                                + " and MaChiPhi='{4}' and username=N'"+ Global.glbUName +"'",
                                LuotIn,
                                Global.GetCode(cmbKhoa),
                                txtTNgay.Value,
                                txtDNgay.Value,
                                fgDanhSach.GetDataDisplay(i, 2));
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
                        }
                    }
                    else
                    {
                        if (raNhomTBN.Checked)
                        {
                            for (int i = 1; i < fgDanhSach.Rows.Count; i++)
                            {
                                if (fgDanhSach.Rows[i].UserData == null) continue;
                                if (fgDanhSach.GetDataDisplay(i, "Nhom").ToLower() == "0")
                                {
                                    Str += "UPDATE PHIEUDIEUTRI_CHITIET SET DATHUCHIEN = ";
                                    Str += fgDanhSach.GetDataDisplay(i, "ThucHien").ToLower() == "true" ? 1 : 0;
                                    Str += String.Format(",LuotIn = " + LuotIn + " WHERE LOAIDICHVU in ('D01','D05') AND DATHUCHIEN = 0 AND SOPHIEU IN (SELECT SOPHIEU FROM BENHNHAN_PHIEUDIEUTRI "
                                        + " WHERE DateDiff(dd,NgayChiDinh,'{0:MM/dd/yyyy} 00:00:00') <= 0  and DateDiff(dd,NgayChiDinh,'{1:MM/dd/yyyy} 00:00:00') >= 0"
                                        + "  AND MAKHOA = '{2}' and MaVaoVien='{3}' and username=N'"+ Global.glbUName +"'",
                                        txtTNgay.Value, txtDNgay.Value,
                                        GlobalModuls.Global.GetCode(cmbKhoa),
                                        fgDanhSach.GetDataDisplay(i, 2));
                                    if (cmbNhom.SelectedIndex == 1)
                                    {
                                        Str += String.Format(" and nhom = 0) AND MADICHVU = '{0}' ", fgDanhSach.GetDataDisplay(i, 4));
                                    }
                                    else
                                    {
                                        if (cmbNhom.SelectedIndex == 2)
                                        {
                                            Str += String.Format(" and nhom = 1) AND MADICHVU = '{0}' ", fgDanhSach.GetDataDisplay(i, 4));
                                        }
                                        else
                                        {
                                            Str += String.Format(" ) AND MADICHVU = '{0}' ", fgDanhSach.GetDataDisplay(i, 4));
                                        }
                                    }
                                }
                                if (fgDanhSach.GetDataDisplay(i, "Nhom").ToLower() == "1")
                                {
                                    Str += " Update chiphi_thuthuat set dathuchien = ";
                                    Str += fgDanhSach.GetDataDisplay(i, "ThucHien").ToLower() == "true" ? 1 : 0;
                                    Str += String.Format(",LuotIn={0} Where LoaiDichVu in ('D01','D05') and dathuchien =0 and makhoa='{1}'"
                                        + " and datediff(dd,NgayThucHien,'{2:MM/dd/yyyy}') <= 0 and datediff(dd,NgayThucHien,'{3:MM/dd/yyyy}') >= 0 "
                                        + " and MaChiPhi='{4}' and MaVaoVien='{5}' and username=N'" + Global.glbUName + "'",
                                        LuotIn,
                                        Global.GetCode(cmbKhoa),
                                        txtTNgay.Value,
                                        txtDNgay.Value,
                                        fgDanhSach.GetDataDisplay(i, 4),
                                        fgDanhSach.GetDataDisplay(i, 2));
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
                                }
                            }
                        }
                        else
                        {
                            for (int i = 1; i < fgDanhSach.Rows.Count; i++)
                            {
                                if (fgDanhSach.Rows[i].UserData == null) continue;
                                if (fgDanhSach.GetDataDisplay(i, "Nhom").ToLower() == "0")
                                {
                                    Str += "UPDATE PHIEUDIEUTRI_CHITIET SET DATHUCHIEN = ";
                                    Str += fgDanhSach.GetDataDisplay(i, "ThucHien").ToLower() == "true" ? 1 : 0;
                                    Str += String.Format(",LuotIn = " + LuotIn + " WHERE LOAIDICHVU in ('D01','D05') AND DATHUCHIEN = 0 AND SOPHIEU IN (SELECT SOPHIEU FROM BENHNHAN_PHIEUDIEUTRI "
                                        + " WHERE DateDiff(dd,NgayChiDinh,'{0:MM/dd/yyyy} 00:00:00') <= 0  and DateDiff(dd,NgayChiDinh,'{1:MM/dd/yyyy} 00:00:00') >= 0"
                                        + "  AND MAKHOA = '{2}' and MaVaoVien='{3}' and username=N'" + Global.glbUName + "'",
                                        txtTNgay.Value, txtDNgay.Value,
                                        GlobalModuls.Global.GetCode(cmbKhoa),
                                        fgDanhSach.GetDataDisplay(i, 4));
                                    if (cmbNhom.SelectedIndex == 1)
                                    {
                                        Str += String.Format(" and nhom = 0) AND MADICHVU = '{0}' ", fgDanhSach.GetDataDisplay(i, 2));
                                    }
                                    else
                                    {
                                        if (cmbNhom.SelectedIndex == 2)
                                        {
                                            Str += String.Format(" and nhom = 1) AND MADICHVU = '{0}' ", fgDanhSach.GetDataDisplay(i, 2));
                                        }
                                        else
                                        {
                                            Str += String.Format(" ) AND MADICHVU = '{0}' ", fgDanhSach.GetDataDisplay(i, 2));
                                        }
                                    }
                                }
                                if (fgDanhSach.GetDataDisplay(i, "Nhom").ToLower() == "1")
                                {
                                    Str += " Update chiphi_thuthuat set dathuchien = ";
                                    Str += fgDanhSach.GetDataDisplay(i, "ThucHien").ToLower() == "true" ? 1 : 0;
                                    Str += String.Format(",LuotIn={0} Where LoaiDichVu in ('D01','D05') and dathuchien =0 and makhoa='{1}'"
                                        + " and datediff(dd,NgayThucHien,'{2:MM/dd/yyyy}') <= 0 and datediff(dd,NgayThucHien,'{3:MM/dd/yyyy}') >= 0 "
                                        + " and MaChiPhi='{4}' and MaVaoVien='{5}' and username=N'" + Global.glbUName + "'",
                                        LuotIn,
                                        Global.GetCode(cmbKhoa),
                                        txtTNgay.Value,
                                        txtDNgay.Value,
                                        fgDanhSach.GetDataDisplay(i, 2),
                                        fgDanhSach.GetDataDisplay(i, 4));
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
                                }
                            }
                        }
                    }
                }

                // Truong hop huy duyet
                if (cmdDuyet.Text == "Hủy duyệt")
                {
                    C1.Win.C1FlexGrid.CellRange rg = fgDanhSach.Selection;
                    for (int i = rg.r1; i <= rg.r2; i++)
                    {
                        if (fgDanhSach.Rows[i].IsNode) continue;
                        if (i == 0) continue;
                        if (raNhomToanKhoa.Checked)
                        {
                            Str += "UPDATE PHIEUDIEUTRI_CHITIET SET DATHUCHIEN = 0,Luotin = null ";
                            Str += String.Format(" WHERE LOAIDICHVU in ('D01','D05') AND DATHUCHIEN = 1 AND SOPHIEU IN (SELECT SOPHIEU FROM BENHNHAN_PHIEUDIEUTRI "
                                + " WHERE DateDiff(dd,NgayChiDinh,'{0:MM/dd/yyyy} 00:00:00') <= 0  and DateDiff(dd,NgayChiDinh,'{1:MM/dd/yyyy} 00:00:00') >= 0"
                                + "  AND MAKHOA = '{2}'  and username=N'" + Global.glbUName + "'",
                                txtTNgay.Value, txtDNgay.Value,
                                GlobalModuls.Global.GetCode(cmbKhoa));
                            if (cmbNhom.SelectedIndex == 1)
                            {
                                Str += String.Format(" and nhom = 0) AND MADICHVU = '{0}' ", fgDanhSach.GetDataDisplay(i, 2));
                            }
                            else
                            {
                                if (cmbNhom.SelectedIndex == 2)
                                {
                                    Str += String.Format(" and nhom = 1) AND MADICHVU = '{0}' ", fgDanhSach.GetDataDisplay(i, 2));
                                }
                                else
                                {
                                    Str += String.Format(" ) AND MADICHVU = '{0}' ", fgDanhSach.GetDataDisplay(i, 2));
                                }
                            }
                            Str += " Update chiphi_thuthuat set dathuchien = 0";
                            Str += String.Format(",LuotIn={0} Where LoaiDichVu in ('D01','D05') and dathuchien =1 and makhoa='{1}'"
                                + " and datediff(dd,NgayThucHien,'{2:MM/dd/yyyy}') <= 0 and datediff(dd,NgayThucHien,'{3:MM/dd/yyyy}') >= 0 "
                                + " and MaChiPhi='{4}'  and username=N'" + Global.glbUName + "'",
                                "null",
                                Global.GetCode(cmbKhoa),
                                txtTNgay.Value,
                                txtDNgay.Value,
                                fgDanhSach.GetDataDisplay(i, 2));
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
                        }
                        else
                        {
                            //////////////////////////////
                            if (raNhomTBN.Checked)
                            {
                                //Nhom theo benh nhan
                                if (fgDanhSach.GetDataDisplay(i, "Nhom").ToLower() == "0")
                                {
                                    Str += "UPDATE PHIEUDIEUTRI_CHITIET SET DATHUCHIEN = 0";
                                    Str += String.Format(",LuotIn = null WHERE LOAIDICHVU in ('D01','D05') AND DATHUCHIEN = 1 AND SOPHIEU IN (SELECT SOPHIEU FROM BENHNHAN_PHIEUDIEUTRI "
                                        + " WHERE DateDiff(dd,NgayChiDinh,'{0:MM/dd/yyyy} 00:00:00') <= 0  and DateDiff(dd,NgayChiDinh,'{1:MM/dd/yyyy} 00:00:00') >= 0"
                                        + "  AND MAKHOA = '{2}' and MaVaoVien='{3}' and username=N'" + Global.glbUName + "'",
                                        txtTNgay.Value, txtDNgay.Value,
                                        GlobalModuls.Global.GetCode(cmbKhoa),
                                        fgDanhSach.GetDataDisplay(i, 2));
                                    if (cmbNhom.SelectedIndex == 1)
                                    {
                                        Str += String.Format(" and nhom = 0) AND MADICHVU = '{0}' ", fgDanhSach.GetDataDisplay(i, 4));
                                    }
                                    else
                                    {
                                        if (cmbNhom.SelectedIndex == 2)
                                        {
                                            Str += String.Format(" and nhom = 1) AND MADICHVU = '{0}' ", fgDanhSach.GetDataDisplay(i, 4));
                                        }
                                        else
                                        {
                                            Str += String.Format(" ) AND MADICHVU = '{0}' ", fgDanhSach.GetDataDisplay(i, 4));
                                        }
                                    }
                                }
                                if (fgDanhSach.GetDataDisplay(i, "Nhom").ToLower() == "1")
                                {
                                    Str += " Update chiphi_thuthuat set dathuchien = 0";
                                    Str += String.Format(",LuotIn={0} Where LoaiDichVu in ('D01','D05') and dathuchien =1 and makhoa='{1}'"
                                        + " and datediff(dd,NgayThucHien,'{2:MM/dd/yyyy}') <= 0 and datediff(dd,NgayThucHien,'{3:MM/dd/yyyy}') >= 0 "
                                        + " and MaChiPhi='{4}' and MaVaoVien='{5}' and username=N'" + Global.glbUName + "'",
                                        "null",
                                        Global.GetCode(cmbKhoa),
                                        txtTNgay.Value,
                                        txtDNgay.Value,
                                        fgDanhSach.GetDataDisplay(i, 4),
                                        fgDanhSach.GetDataDisplay(i, 2));
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
                                }
                            }
                            ///////////////////////////////
                            else
                            {
                                //Nhom the chi phi
                                if (fgDanhSach.GetDataDisplay(i, "Nhom").ToLower() == "0")
                                {
                                    Str += "UPDATE PHIEUDIEUTRI_CHITIET SET DATHUCHIEN = 0";
                                    Str += String.Format(",LuotIn = null WHERE LOAIDICHVU in ('D01','D05') AND DATHUCHIEN = 1 AND SOPHIEU IN (SELECT SOPHIEU FROM BENHNHAN_PHIEUDIEUTRI "
                                        + " WHERE DateDiff(dd,NgayChiDinh,'{0:MM/dd/yyyy} 00:00:00') <= 0  and DateDiff(dd,NgayChiDinh,'{1:MM/dd/yyyy} 00:00:00') >= 0"
                                        + "  AND MAKHOA = '{2}' and MaVaoVien='{3}' and username=N'" + Global.glbUName + "'",
                                        txtTNgay.Value, txtDNgay.Value,
                                        GlobalModuls.Global.GetCode(cmbKhoa),
                                        fgDanhSach.GetDataDisplay(i, 4));
                                    if (cmbNhom.SelectedIndex == 1)
                                    {
                                        Str += String.Format(" and nhom = 0) AND MADICHVU = '{0}' ", fgDanhSach.GetDataDisplay(i, 2));
                                    }
                                    else
                                    {
                                        if (cmbNhom.SelectedIndex == 2)
                                        {
                                            Str += String.Format(" and nhom = 1) AND MADICHVU = '{0}' ", fgDanhSach.GetDataDisplay(i, 2));
                                        }
                                        else
                                        {
                                            Str += String.Format(" ) AND MADICHVU = '{0}' ", fgDanhSach.GetDataDisplay(i, 2));
                                        }
                                    }
                                }
                                if (fgDanhSach.GetDataDisplay(i, "Nhom").ToLower() == "1")
                                {
                                    Str += " Update chiphi_thuthuat set dathuchien = 0";
                                    Str += String.Format(",LuotIn={0} Where LoaiDichVu in ('D01','D05') and dathuchien =1 and makhoa='{1}'"
                                        + " and datediff(dd,NgayThucHien,'{2:MM/dd/yyyy}') <= 0 and datediff(dd,NgayThucHien,'{3:MM/dd/yyyy}') >= 0 "
                                        + " and MaChiPhi='{4}' and MaVaoVien='{5}' and username=N'" + Global.glbUName + "'",
                                        "null",
                                        Global.GetCode(cmbKhoa),
                                        txtTNgay.Value,
                                        txtDNgay.Value,
                                        fgDanhSach.GetDataDisplay(i, 2),
                                        fgDanhSach.GetDataDisplay(i, 4));
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
                                }
                            }
                        }
                        ////////////////
                    }
                }
                if (cmdDuyet.Text == "Duyệt")
                {
                    cmdChonGui.Text = "Chọn tất cả";
                    cmdDuyet.Text = "Hủy duyệt";
                }
                else
                {
                    cmdChonGui.Text = "Chọn tất cả";
                    cmdDuyet.Text = "Duyệt";
                }
                SQLCmd.CommandText = Str;
                SQLCmd.ExecuteNonQuery();
                LoatData();
            }
            catch
            {
            }
            finally
            {
                SQLCmd.Dispose();
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
            if (fgDanhSach.Rows.Count <= 1) return;
            if (fgDanhSach.Tag.ToString() == "0") return;
            if (fgDanhSach.Rows[fgDanhSach.Row].IsNode)
            {
                cmdDuyet.Enabled = false;
            }
            else
            {
                cmdDuyet.Enabled = true;
            }
            if (fgDanhSach.GetDataDisplay(fgDanhSach.Row, "ThucHien").ToLower() == "true" && fgDanhSach.Rows[fgDanhSach.Row].UserData == null)
            {
                cmdDuyet.Text = "Hủy duyệt";
            }
            else
            {
                cmdDuyet.Text = "Duyệt";
            }
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
            cmdTongHop_Click(sender, e);
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
            cmdTongHop_Click(sender, e);
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
            cmdTongHop_Click(sender, e);
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
            cmdTongHop_Click(sender, e);
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
            cmdTongHop_Click(sender, e);
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
            cmdTongHop_Click(sender, e);
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
            cmdTongHop_Click(sender, e);
        }
    }
}