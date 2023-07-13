using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GlobalModuls;
namespace NamDinh_QLBN.Forms.In.ChiPhi_BNDDT
{
    public partial class frmTongHopVatTu_BNDDT : Form
    {
        public frmTongHopVatTu_BNDDT()
        {
            InitializeComponent();
        }

        private void LoatData()
        {
            try
            {
                Global.wait("Đang tổng hợp dữ liệu ...");
                String Str = "",MaVaoVien = "",DieuKien="",LoaiDichVu = "";
                int STT = 0, STT1 = 0;
                LoaiDichVu = "('D02','D06')";

                if (raNhomToanKhoa.Checked)
                {
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
                        + " (SELECT a.MaDichVu,c.TenDichVu, c.DVT,Sum(SoLuong * b.SoThang)AS SoLuong,A.DaThucHien,"
                        + " case when isnull(a.LuotIn,0) = 0 then N'Chưa chọn để in ' else N'Lượt in ' + Convert(nvarchar(5),a.LuotIn) end as GhiChu  "
                        + " FROM (PHIEUDIEUTRI_CHITIET a INNER JOIN BENHNHAN_PHIEUDIEUTRI b ON a. SoPhieu=b.SoPhieu) "
                        + " INNER JOIN DMDICHVU c ON a.MaDichVu=c.MaDichVu "
                        + " WHERE b.MaKhoa = '{0}' AND a.LoaiDichVu in " + LoaiDichVu + " AND DateDiff(dd,b.NgayChiDinh,convert(datetime,'{1:MM/dd/yyyy}',101)) <= 0 and DateDiff(dd,b.NgayChiDinh,convert(datetime,'{2:MM/dd/yyyy}',101)) >= 0 " + DieuKien + (Global.GetCode(cmbNhomLenThuoc) == "0" ? " " : " AND A.MANHOM= " + Global.GetCode(cmbNhomLenThuoc))
                        + " GROUP BY c.TenDichVu,c.DVT,a.MaDichVu,A.DaThucHien,a.LuotIn) aa"
                        + " Union ALL"
                        + " Select * from"
                        + " (Select dmDichVu.MaDichVu,TenDichVu,DVT,sum(SoLuong) as SoLuong,DaThucHien,"
                        + " case when bb.LuotIn = 0 then N'Chưa chọn để in ' else N'Lượt in ' + Convert(nvarchar(5),bb.LuotIn) end as GhiChu from"
                        + " (Select * from chiphi_thuthuat b Where b.MaKhoa = '{0}' AND b.LoaiDichVu in " + LoaiDichVu + " " + DieuKien + (Global.GetCode(cmbNhomLenThuoc) == "0" ? " " : " AND B.MANHOM= " + Global.GetCode(cmbNhomLenThuoc))
                        + " AND DateDiff(dd,b.NgayThucHien,convert(datetime,'{1:MM/dd/yyyy}',101)) <= 0 and DateDiff(dd,b.NgayThucHien,convert(datetime,'{2:MM/dd/yyyy}',101)) >= 0) BB"
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
                           + " FROM (SELECT CC.*,PH.LOAIDICHVU,PH.MADICHVU,PH.SOLUONG * cc.SoThang as SoLuong,PH.DONGIA,PH.GHICHU,PH.DOITUONGBN,PH.DATHUCHIEN,PH.LuotIn,PH.NgayIn"
                           + " FROM (SELECT BB.*,BENHNHAN_PHIEUDIEUTRI.SOPHIEU,BENHNHAN_PHIEUDIEUTRI.NGAYCHIDINH,BENHNHAN_PHIEUDIEUTRI.LOAIDT, "
                           + " BENHNHAN_PHIEUDIEUTRI.BACSYDT, BENHNHAN_PHIEUDIEUTRI.DIENBIENBENH,BENHNHAN_PHIEUDIEUTRI.YLENH,"
                           + " BENHNHAN_PHIEUDIEUTRI.CDCHAMSOC, BENHNHAN_PHIEUDIEUTRI.CDDINHDUONG,BENHNHAN_PHIEUDIEUTRI.MAKHOA,"
                           + " BENHNHAN_PHIEUDIEUTRI.NHOM,benhnhan_phieudieutri.SoThang FROM (SELECT AA.*,BENHNHAN_CHITIET.MAVAOVIEN "
                           + " FROM (SELECT * FROM BENHNHAN) AA  INNER JOIN BENHNHAN_CHITIET ON BENHNHAN_CHITIET.MABENHNHAN = AA.MABENHNHAN) BB "
                           + " INNER JOIN BENHNHAN_PHIEUDIEUTRI ON BENHNHAN_PHIEUDIEUTRI.MAVAOVIEN = BB.MAVAOVIEN "
                           + " WHERE BENHNHAN_PHIEUDIEUTRI.MAKHOA = '{0}') CC "
                           + " INNER JOIN PHIEUDIEUTRI_CHITIET PH ON PH.SOPHIEU = CC.SOPHIEU"
                           + " WHERE  ", GlobalModuls.Global.GetCode(cmbKhoa));
                    Str += String.Format("  PH.LOAIDICHVU in " + LoaiDichVu + (Global.GetCode(cmbNhomLenThuoc) == "0" ? " " : " AND PH.MANHOM= " + Global.GetCode(cmbNhomLenThuoc)) + " ) DD"
                        + " INNER JOIN DMDICHVU ON DMDICHVU.MADICHVU = DD.MADICHVU"
                        + " WHERE DATEDIFF(DD,DD.NGAYCHIDINH,convert(datetime,'{0:MM/dd/yyyy} 00:00:00',101)) <= 0 and DATEDIFF(DD,DD.NGAYCHIDINH,convert(datetime,'{1:MM/dd/yyyy} 00:00:00',101)) >= 0",
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
                           + " (Select * from chiphi_thuthuat where loaidichvu in " + LoaiDichVu + " and makhoa='{0}' and DATEDIFF(DD,NgayThucHien,convert(datetime,'{1:MM/dd/yyyy}',101)) <= 0 and DATEDIFF(DD,NgayThucHien,convert(datetime,'{2:MM/dd/yyyy}',101)) >= 0",
                           GlobalModuls.Global.GetCode(cmbKhoa),
                           txtTNgay.Value,txtDNgay.Value);
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
                    Str += Global.GetCode(cmbNhomLenThuoc) == "0" ? " " : " AND MANHOM= " + Global.GetCode(cmbNhomLenThuoc);
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
                SQLCmd.CommandTimeout = 0;
                System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(SQLCmd);
                System.Data.DataSet ds = new DataSet();
                ds.Clear();
                da.Fill(ds);
                fgDanhSach.ClipSeparators = "|;";
                fgDanhSach.Rows.Count = 1;
                if (raNhomToanKhoa.Checked)
                {
                    fgDanhSach.Cols[4].DataType = typeof(Decimal);
                    fgDanhSach.Cols[4].Format = "#,##0.##";
                    fgDanhSach.Cols[6].DataType = typeof(object);
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
                    fgDanhSach.Cols[6].Visible = fgDanhSach.Cols[2].Visible = fgDanhSach.Cols[7].Visible = fgDanhSach.Cols[8].Visible = false;
                    fgDanhSach.Cols[3].Visible = fgDanhSach.Cols[4].Visible = true;
                }
                else
                {
                    fgDanhSach.Cols[6].DataType = typeof(Decimal);
                    fgDanhSach.Cols[6].Format = "#,##0.##";
                    fgDanhSach.Cols[4].DataType = typeof(object);
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
                        fgDanhSach.Cols[8].Visible = fgDanhSach.Cols[2].Visible = fgDanhSach.Cols[3].Visible = fgDanhSach.Cols[4].Visible = false;
                        fgDanhSach.Cols[6].Visible = true;
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
                        fgDanhSach.Cols[2].Visible = fgDanhSach.Cols[3].Visible = fgDanhSach.Cols[9].Visible = false;
                        fgDanhSach.Cols[6].Visible = true;
                        STT = 0;
                        MaVaoVien = "";
                        STT1 = 1;
                    }

                    fgDanhSach.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.Sum, 0, 3, 6, "{0}");
                }
                fgDanhSach.AutoSizeCols(1, fgDanhSach.Cols.Count - 1, 1);
                SQLCmd.Dispose();
                
            }
            catch (System.Data.SqlClient.SqlException ex){
                MessageBox.Show(ex.Message);
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
            cmbKhoa.SelectedIndex = 0;
            cmbKhoa.Tag = 1;
            SQLCmd.CommandText = "SELECT * FROM KHOA_NHOM WHERE MaKhoa IN " + Global.glbKhoa_CapNhat;
            dr = SQLCmd.ExecuteReader();
            cmbNhomLenThuoc.Tag = "0";
            cmbNhomLenThuoc.ClearItems();
            cmbNhomLenThuoc.AddItem("0;--------- TẤT CẢ ---------");
            while (dr.Read())
            {
                cmbNhomLenThuoc.AddItem(string.Format("{0};{1}", dr["MaNhom"], dr["TenNhom"]));
            }
            dr.Close();
            cmbNhomLenThuoc.SelectedIndex = 0;

            SQLCmd.Dispose();
            if (cmbKhoa.ListCount == 1) cmbKhoa.SelectedIndex = 0;
            txtTNgay.Value =  txtDNgay.Value = GlobalModuls.Global.NgayLV;
            cmbNhom.AddItem("--------- Tất cả---------");
            cmbNhom.AddItem("Chi phí trong ngày");
            cmbNhom.AddItem("Chi phí bất thường");
            cmbNhom.SelectedIndex = 0;
            C1.Win.C1FlexGrid.CellStyle cs = fgDanhSach.Styles[C1.Win.C1FlexGrid.CellStyleEnum.Subtotal0];
            cs.BackColor = Color.LightBlue;
            cs.ForeColor = Color.DarkBlue;
            cmbKhoa.Tag = 1;
            txtTNgay.Tag = txtDNgay.Tag = 1;
            raNhomTBN.Tag = raNhomTheoCP.Tag = raNhomToanKhoa.Tag = 1;
            cmbNhom.Tag = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
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
            //Son them vao
            string DieuKien = "";
            if (cmbNhom.SelectedIndex == 1)
            {
                DieuKien += " and A.Nhom = 0 ";
            }
            else
            {
                if (cmbNhom.SelectedIndex == 2)
                {
                    DieuKien += " AND A.Nhom = 1 ";
                }
            }
            // Het
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

            Str = String.Format("SELECT TENDICHVU,DVT,ROUND(SUM(SOLUONG),0) AS SOLUONG,KHOID,TENKHO FROM"
                + " ("
                + " SELECT DMDICHVU.TENDICHVU,DMDICHVU.DVT,SUM(B.SOLUONG) AS SOLUONG,KHO.KHOID,KHO.TENKHO FROM"
                + " (BENHNHAN_PHIEUDIEUTRI A INNER JOIN PHIEUDIEUTRI_CHITIET B ON A.SOPHIEU = B.SOPHIEU)"
                + " INNER JOIN DMDICHVU ON DMDICHVU.MADICHVU = B.MADICHVU"
                + " LEFT JOIN NAMDINH_DUOC.DBO.DANHMUCKHO KHO ON KHO.KHOID = B.KHOID"
                + " WHERE B.LOAIDICHVU IN('D02','D06') AND A.MAKHOA ='{0}' AND DATEDIFF(DD,A.NGAYCHIDINH,convert(datetime,'{1:MM/dd/yyyy}',101)) <= 0 " + DieuKien
                + " AND DATEDIFF(DD,A.NGAYCHIDINH,convert(datetime,'{2:MM/dd/yyyy}',101)) >= 0 " + (Global.GetCode(cmbNhomLenThuoc) == "0" ? " " : " AND B.MANHOM= " + Global.GetCode(cmbNhomLenThuoc) )
                + " GROUP BY DMDICHVU.TENDICHVU,DMDICHVU.DVT,KHO.KHOID,KHO.TENKHO"
                + " UNION ALL"
                + " SELECT B.TENDICHVU,B.DVT,SUM(A.SOLUONG) AS SOLUONG,KHO.KHOID,KHO.TENKHO FROM"
                + " (CHIPHI_THUTHUAT A INNER JOIN DMDICHVU B ON B.MADICHVU = A.MACHIPHI) "
                + " LEFT JOIN NAMDINH_DUOC.DBO.DANHMUCKHO KHO ON KHO.KHOID = A.KHOID"
                + " WHERE A.LOAIDICHVU IN ('D02','D06') AND A.MAKHOA ='{0}' AND DATEDIFF(DD,A.NGAYTHUCHIEN,convert(datetime,'{1:MM/dd/yyyy}',101)) <= 0 " + DieuKien
                + " AND DATEDIFF(DD,A.NGAYTHUCHIEN,convert(datetime,'{2:MM/dd/yyyy}',101)) >= 0 " + (Global.GetCode(cmbNhomLenThuoc) == "0" ? " " : " AND A.MANHOM= " + Global.GetCode(cmbNhomLenThuoc) )
                + " GROUP BY B.TENDICHVU,B.DVT,KHO.KHOID,KHO.TENKHO"
                + " ) BB"
                + " GROUP BY TENDICHVU,DVT,KHOID,TENKHO"
                + " ORDER BY TENKHO,TENDICHVU",
                Global.GetCode(cmbKhoa),
                txtTNgay.Value,
                txtDNgay.Value);
            SQLCmd.CommandText = Str;
            SQLCmd.CommandTimeout = 0;
            System.Data.SqlClient.SqlDataReader dr = SQLCmd.ExecuteReader();
            NamDinh_QLBN.Reports.BaoCaoVeThuoc.rptPhieuLinhThuoc rpt = new NamDinh_QLBN.Reports.BaoCaoVeThuoc.rptPhieuLinhThuoc(cmbKhoa.Text, "");
            rpt.DataSource = dr;
            rpt.Show();
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
            if (raNhomToanKhoa.Checked)
            cmdTongHop_Click(sender, e);
        }

        private void txtTNgay_ValueChanged(object sender, EventArgs e)
        {
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
            if(raNhomTheoCP.Checked) 
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
            if(raNhomTBN.Checked)
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

        private void cmbLoaiDichVu_TextChanged(object sender, EventArgs e)
        {
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            string TenFile;
            System.Windows.Forms.SaveFileDialog  dg  = new SaveFileDialog();
			dg.Filter = "Xuất số liệu ra file Excel (*.xls)|*.xls";
			dg.FilterIndex=0; 
			dg.CheckFileExists = false;
			dg.Title = "Nhập tên file để kết xuất số liệu.";
			if(dg.ShowDialog()== DialogResult.OK)
				TenFile = dg.FileName;
			else
				return;
			if(TenFile.Split(".".ToCharArray()).Length < 2)
				TenFile = TenFile + ".xls";
            fgDanhSach.SaveExcel(TenFile);
            MessageBox.Show("Bạn đã lưu thành công file " + TenFile+ " !");
        }
    }
}