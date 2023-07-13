using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GlobalModuls;
using System.Data.SqlClient;

namespace NamDinh_QLBN.Forms.In.PhauThuat
{
    public partial class frmPhieuLinhThuoc_Sua : Form
    {
        private String MaDuyetThuoc = "";
        string TuNgay, DenNgay;
        public frmPhieuLinhThuoc_Sua()
        {
            InitializeComponent();
        }

        private void LoatData()
        {
            try
            {
                TuNgay = txtTNgay.Value.ToString();
                DenNgay = txtDNgay.Value.ToString();
                Global.wait("Đang tổng hợp dữ liệu ...");
                String Str = "", MaVaoVien = "";
                int STT = 0, STT1 = 0;
                    if (raNhomToanKhoa.Checked)
                    {
                        Str = String.Format("set dateformat dmy SELECT DMDICHVU.MADICHVU,DMDICHVU.TENDICHVU,DMDICHVU.DVT,SUM(A.SOLUONG) AS SOLUONG,A.DaThucHien,"
                            + " CASE WHEN LEN(A.MAPHIEUDUYET) > 2 THEN A.MAPHIEUDUYET ELSE '' END AS GHICHU,A.NHOMLENCHIPHI  FROM BENHNHAN_PT_CHIPHI A "
                            + " INNER JOIN DMDICHVU ON A.MADICHVU = DMDICHVU.MADICHVU"
                            + " WHERE A.LOAICHIPHI IN ('D01') AND DATEDIFF(DD,A.NGAYCHIDINH,'{0:dd/MM/yyyy}') <= 0 "
                            + " AND DATEDIFF(DD,A.NGAYCHIDINH,'{1:dd/MM/yyyy}') >= 0",
                            txtTNgay.Value,
                            txtDNgay.Value);
                        if (!chDaThucHien.Checked)
                            Str += " AND A.DATHUCHIEN = 0";
                        Str += " GROUP BY DMDICHVU.MADICHVU,DMDICHVU.TENDICHVU,DMDICHVU.DVT,A.DATHUCHIEN,A.MAPHIEUDUYET,A.NHOMLENCHIPHI";
                    }
                    else
                    {
                        Str = String.Format("set dateformat dmy SELECT C.DaThucHien,B.MAVAOVIEN,A.HOTEN,DMDICHVU.MADICHVU,DMDICHVU.TENDICHVU,DMDICHVU.DVT,ISNULL(C.MAPHIEUDUYET,'') AS GHICHU,"
                            + " 0 AS TT_HN,SUM(C.SOLUONG) AS SOLUONG,C.NHOMLENCHIPHI FROM"
                            + " (BENHNHAN A INNER JOIN BENHNHAN_CHITIET B ON A.MABENHNHAN = B.MABENHNHAN)"
                            + " INNER JOIN BENHNHAN_PT_CHIPHI C ON C.MAVAOVIEN = B.MAVAOVIEN"
                            + " INNER JOIN DMDICHVU ON DMDICHVU.MADICHVU = C.MADICHVU AND DMDICHVU.LOAIDICHVU = C.LOAICHIPHI"
                            + " WHERE C.LOAICHIPHI IN ('D01') AND DATEDIFF(DD,C.NGAYCHIDINH,'{0:dd/MM/yyyy}') <= 0 AND DATEDIFF(DD,C.NGAYCHIDINH,'{1:dd/MM/yyyy}') >= 0 ",
                            txtTNgay.Value,
                            txtDNgay.Value);
                        Str += " GROUP BY C.DATHUCHIEN,B.MAVAOVIEN,A.HOTEN,DMDICHVU.MADICHVU,DMDICHVU.TENDICHVU,DMDICHVU.DVT,C.MAPHIEUDUYET,C.NHOMLENCHIPHI";
                        if (raNhomTBN.Checked)
                        {
                            Str += " ORDER BY right(C.MAPHIEUDUYET,9) desc,C.DATHUCHIEN,B.MAVAOVIEN,A.HOTEN,DMDICHVU.TENDICHVU";
                        }
                        else
                        {
                            Str += " ORDER BY right(C.MAPHIEUDUYET,9) desc,C.DATHUCHIEN,DMDICHVU.TENDICHVU,A.HOTEN,B.MAVAOVIEN";
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
                        fgDanhSach.Cols[4].DataType = typeof(Decimal);
                        fgDanhSach.Cols[4].Format = "#,##0.###";
                        fgDanhSach.Cols[6].DataType = typeof(object);
                        foreach (System.Data.DataRow Row in ds.Tables[0].Rows)
                        {
                            fgDanhSach.AddItem(String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}",
                                fgDanhSach.Rows.Count,
                                Row["DaThucHien"],
                                Row["MaDichVu"],
                                Row["TenDichVu"],
                                Row["SoLuong"],
                                Row["DVT"],
                                Row["GhiChu"],
                                Row["NHOMLENCHIPHI"]));
                        }
                        fgDanhSach[0, 0] = "Số TT";
                        fgDanhSach[0, 1] = "Thực hiện";
                        fgDanhSach[0, 2] = "Mã thuốc";
                        fgDanhSach[0, 3] = "Tên thuốc";
                        fgDanhSach[0, 4] = "Số lượng";
                        fgDanhSach[0, 5] = "ĐVT";
                        fgDanhSach[0, 6] = "Mã phiếu lỉnh thuốc";
                        fgDanhSach[0, 7] = "Phòng Lĩnh Thuốc";
                        fgDanhSach.Cols[2].Visible = fgDanhSach.Cols[8].Visible = false;
                        fgDanhSach.Cols[3].Visible = fgDanhSach.Cols[4].Visible = true;
                    }
                    else
                    {
                        fgDanhSach.Cols[7].Visible = fgDanhSach.Cols[8].Visible = fgDanhSach.Cols[10].Visible =true;
                        fgDanhSach.Tree.Column = 5;
                        if (raNhomTBN.Checked)
                        {
                            fgDanhSach.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Free;
                            fgDanhSach.Cols[6].AllowMerging = false;
                            fgDanhSach.Cols[8].AllowMerging = true;
                            fgDanhSach.Cols[6].DataType = typeof(Decimal);
                            fgDanhSach.Cols[6].Format = "#,##0.###";
                            fgDanhSach.Cols[4].DataType = typeof(object);
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
                                fgDanhSach.AddItem(String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}",
                                    STT1.ToString(),
                                    Row["DaThucHien"],
                                    Row["MaVaoVien"],
                                    STT.ToString() + ": " + Row["HoTen"],
                                    Row["MaDichVu"],
                                    Row["TenDichVu"],
                                    Row["SoLuong"],
                                    Row["DVT"],
                                    Row["GhiChu"],
                                    Row["TT_HN"], Row["NHOMLENCHIPHI"]));
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
                            fgDanhSach[0, 10] = "NHOMLENCHIPHI";
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
                            fgDanhSach.Cols[6].DataType = typeof(Decimal);
                            fgDanhSach.Cols[6].Format = "#,##0.###";
                            fgDanhSach.Cols[4].DataType = typeof(object);
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
                                fgDanhSach.AddItem(String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}",
                                    STT1.ToString(),
                                    Row["DaThucHien"],
                                    Row["MaDichVu"],
                                    STT.ToString() + ": " + Row["TenDichVu"],
                                    Row["MaVaoVien"],
                                    Row["HoTen"],
                                    Row["SoLuong"],
                                    Row["DVT"],
                                    Row["GhiChu"],
                                    Row["TT_HN"], Row["NHOMLENCHIPHI"]));
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
                            fgDanhSach[0, 8] = "NHOMLENCHIPHI";
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
        }

        private void frmPhieuLinhThuoc_Load(object sender, EventArgs e)
        {
            cmbKhoa.Tag = 0;
            txtTNgay.Tag = txtDNgay.Tag = 0;
            raNhomTBN.Tag = raNhomTheoCP.Tag = raNhomToanKhoa.Tag = 0;
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
            if (cmbKhoa.ListCount == 1) cmbKhoa.SelectedIndex = 0;


            SQLCmd.CommandText = "SELECT MaNhom,TenNhom FROM Khoa_Nhom WHERE  MaKhoa  IN  " + Global.glbKhoa_CapNhat;
            dr = SQLCmd.ExecuteReader();
            cmbNhom.ClearItems();
            while (dr.Read())
            {
                cmbNhom.AddItem(string.Format("{0};{1}", dr["MaNhom"], dr["TenNhom"]));
            }
            dr.Close();
            cmbNhom.SelectedIndex = -1;

            SQLCmd.Dispose();
            txtTNgay.Value =  txtDNgay.Value = GlobalModuls.Global.NgayLV;
            C1.Win.C1FlexGrid.CellStyle cs = fgDanhSach.Styles[C1.Win.C1FlexGrid.CellStyleEnum.Subtotal0];
            cs.BackColor = Color.LightBlue;
            cs.ForeColor = Color.DarkBlue;
            //cmdTongHop_Click(sender, e);
            cmbKhoa.Tag = 1;
            txtTNgay.Tag = txtDNgay.Tag = 1;
            raNhomTBN.Tag = raNhomTheoCP.Tag = raNhomToanKhoa.Tag = 1;
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
            if (txtTNgay.ValueIsDbNull || txtDNgay.ValueIsDbNull)
            {
                MessageBox.Show("Chưa nhập ngày tháng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string Ngay = "";
            DateTime TNgay = DateTime.Parse(txtTNgay.Text);
            DateTime DNgay = DateTime.Parse(txtDNgay.Text);
            System.TimeSpan Ngay1 = DNgay - TNgay;
            if (Ngay1.Days == 0)
            {
                Ngay = string.Format("Ngày {0:dd} tháng {0:MM} năm {0:yyyy}", txtTNgay.Value);
            }
            else
            {
                if (Ngay1.Days == 1)
                    Ngay = string.Format("Thuốc bất thường ngày {0:dd/MM/yyyy}\n", txtTNgay.Value);
                else
                    Ngay = string.Format("Thuốc bất thường từ {0:dd/MM/yyyy} đến {1:dd/MM/yyyy}\n", txtTNgay.Value, DNgay.AddDays(-1));
                Ngay += string.Format("Thuốc trong ngày {0:dd} tháng {0:MM} năm {0:yyyy}", txtDNgay.Value);
            }

            if (MaDuyetThuoc == "")
            {
                MessageBox.Show("Chọn Mã phiếu duyệt", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
             DataDynamics.ActiveReports.DataSources.SqlDBDataSource _ds = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            _ds.ConnectionString = GlobalModuls.Global.glbConnectionString;
            try
            {
                //_ds.SQL = String.Format("SELECT CASE WHEN A.DADUYET = 1 THEN N'BẢN SAO' ELSE '' END AS BANSAO,"
                //    + " B.MADICHVU,B.TENDICHVU,B.DVT,ROUND(SUM(A.SOLUONG),0) AS SOLUONG,A.KHOID,KHO.TENKHO,A.MAPHIEUDUYET + '-' + CONVERT(NVARCHAR,A.KHOID) AS MAPHIEUDUYET FROM"
                //    + " (BENHNHAN_PT_CHIPHI A INNER JOIN DMDICHVU B ON A.MADICHVU = B.MADICHVU)"
                //    + " INNER JOIN NAMDINH_DUOC.DBO.DANHMUCKHO KHO ON KHO.KHOID = A.KHOID"
                //    + " WHERE A.MAPHIEUDUYET ='{0}' AND A.LOAICHIPHI IN ('D01') AND", MaDuyetThuoc);
                //Son Sua
                _ds.SQL = String.Format("SELECT CASE WHEN A.DADUYET = 1 THEN N'BẢN SAO' ELSE '' END AS BANSAO,"
                    + " B.MADICHVU,B.TENDICHVU,B.DVT,Ceiling(SUM(A.SOLUONG)) AS SOLUONG,A.KHOID,KHO.TENKHO,A.MAPHIEUDUYET + '-' + CONVERT(NVARCHAR,A.KHOID) AS MAPHIEUDUYET"
                    + " ,case LEFT(B.MaLoaiThuoc,2) when 'DN' then 'VI' when 'GO' then 'VI' else LEFT(B.MaLoaiThuoc,2) end as GROUPS From "
                    + " (BENHNHAN_PT_CHIPHI A INNER JOIN DMDICHVU B ON A.MADICHVU = B.MADICHVU)"
                    + " INNER JOIN NAMDINH_DUOC.DBO.DANHMUCKHO KHO ON KHO.KHOID = A.KHOID"
                    + " WHERE A.MAPHIEUDUYET ='{0}' AND A.LOAICHIPHI IN ('D01') AND", MaDuyetThuoc);
                if (raDieuTriThuong.Checked)
                {
                    _ds.SQL += " B.MaLoaiThuoc NOT LIKE 'NGHT%' ";
                }
                else
                {
                    if (raThuocGayNghien.Checked)
                    {
                        _ds.SQL += " B.MaLoaiThuoc LIKE 'NGHT%' ";
                    }
                    else
                    {
                        if (raThuocHT.Checked)
                        {
                            _ds.SQL += " B.MaLoaiThuoc LIKE 'NGHT%' ";
                        }
                    }
                }
                _ds.SQL += " GROUP BY B.MADICHVU,B.TENDICHVU,B.DVT,A.DADUYET,A.KHOID,KHO.TENKHO,A.MAPHIEUDUYET,b.MaLoaiThuoc "
                    + "Having sum(a.Soluong) >0 ORDER BY Groups,B.TENDICHVU";
                cmbNhom.Text = "";
                if (raDieuTriThuong.Checked)
                {
                    NamDinh_QLBN.Reports.rptPhieuLinhThuoc_Sua rpt = new NamDinh_QLBN.Reports.rptPhieuLinhThuoc_Sua(cmbKhoa.Text, Ngay,SoLuuTru,cmbNhom.Text);
                    rpt.DataSource = _ds;
                    rpt.Show();
                }
                else
                {
                    if (raThuocGayNghien.Checked)
                    {
                        NamDinh_QLBN.Reports.rptPhieuLinhThuocGayNghien_Sua rpt = new NamDinh_QLBN.Reports.rptPhieuLinhThuocGayNghien_Sua(cmbKhoa.Text, Ngay,SoLuuTru,cmbNhom.Text);
                        rpt.DataSource = _ds;
                        rpt.Show();
                    }
                    else
                    {
                        if (raThuocHT.Checked)
                        {
                            NamDinh_QLBN.Reports.rptPhieuLinhThuocGayNghien_Sua rpt = new NamDinh_QLBN.Reports.rptPhieuLinhThuocGayNghien_Sua(cmbKhoa.Text, Ngay,SoLuuTru,cmbNhom.Text);
                            rpt.DataSource = _ds;
                            rpt.Show();
                            //NamDinh_QLBN.Reports.rptPhieuLinhThuocHuongThan_Sua rpt = new NamDinh_QLBN.Reports.rptPhieuLinhThuocHuongThan_Sua(cmbKhoa.Text, Ngay);
                            //rpt.DataSource = _ds;
                            //rpt.Show();
                        }
                    }
                }
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
            }
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
            Str = String.Format("Select dbo.LayMaDuyetThuocOfPhongMo(Right(Convert(nvarchar(8),'{0:yyyyMMdd}',112),6)) As MaPhieuDuyet ", Global.NgayLV);
            SQLCmd.CommandText = Str;
            MaDuyetThuoc = SQLCmd.ExecuteScalar().ToString();
            Str = "";
            Str += String.Format("Declare @SoLuuTru varchar(11) exec dbo.GetNextSoLuuTruNT '{1}','{4}',@SoLuuTru output "
                       + " UPDATE BENHNHAN_PT_CHIPHI SET DATHUCHIEN = 1,NGAYIN='{0:dd/MM/yyyy}',MaPhieuDuyet='{1}'"
                       + " WHERE DATEDIFF(DD,NGAYCHIDINH,'{2:dd/MM/yyyy}') <= 0 AND DATEDIFF(DD,NGAYCHIDINH,'{3:dd/MM/yyyy}') >= 0"
                       + " AND LOAICHIPHI IN ('D01') AND DATHUCHIEN = 0",
                       GlobalModuls.Global.NgayLV,
                       MaDuyetThuoc,
                       txtTNgay.Value,
                       txtDNgay.Value,
                       Global.GetCode(this.cmbKhoa));
            SQLCmd.CommandText = Str;
            SQLCmd.ExecuteNonQuery();
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

        private void raNhomToanKhoa_CheckedChanged(object sender, EventArgs e)
        {
            if (cmbKhoa.Tag.ToString() == "0") return;
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

        private void raNhomTheoCP_CheckedChanged(object sender, EventArgs e)
        {
            if (cmbKhoa.Tag.ToString() == "0") return;
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
            System.Data.SqlClient.SqlDataReader dr;
            try
            {
                if (raNhomToanKhoa.Checked)
                {
                    SQLCmd.CommandText = String.Format("Select * from BENHNHAN_PT_CHIPHI where MaPhieuDuyet ='{0}' And DaDuyet = 1", fgDanhSach.GetDataDisplay(fgDanhSach.Row, 6));
                }
                else
                {
                    SQLCmd.CommandText = String.Format("Select * from BENHNHAN_PT_CHIPHI where MaPhieuDuyet ='{0}' And DaDuyet = 1", fgDanhSach.GetDataDisplay(fgDanhSach.Row, 8));
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
                    SQLCmd.CommandText = String.Format("Update BENHNHAN_PT_CHIPHI set dathuchien = 0,NgayIn= null ");
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
                    SQLCmd.CommandText = String.Format("Update BENHNHAN_PT_CHIPHI set dathuchien = 1,NgayIn='{0:dd/MM/yyyy}'", Global.NgayLV);
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

        private void txtTNgay_Validated(object sender, EventArgs e)
        {
            //if (cmbKhoa.Tag.ToString() == "0") return;
            //if (raNhomToanKhoa.Tag.ToString() == "0") return;
            //if (raNhomTheoCP.Tag.ToString() == "0") return;
            //if (raNhomTBN.Tag.ToString() == "0") return;
            //if (txtDNgay.Tag.ToString() == "0") return;
            //if (txtTNgay.Tag.ToString() == "0") return;
            //if (fgDanhSach.Tag.ToString() == "0") return;
            //if (cmbNhom.SelectedIndex == -1)
            //{
            //    MessageBox.Show("Chọn nhóm lên chi phí.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    cmbNhom.Focus();
            //    return;
            //}
            //if (txtTNgay.Value.ToString() != TuNgay)
            //{
            //    fgDanhSach.Tag = 0;
            //    cmdTongHop_Click(sender, e);
            //    fgDanhSach.Tag = 1;
            //}
        }

        private void cmbNhom_TextChanged_1(object sender, EventArgs e)
        {
            //if (cmbKhoa.Tag.ToString() == "0") return;
            //if (raNhomToanKhoa.Tag.ToString() == "0") return;
            //if (raNhomTheoCP.Tag.ToString() == "0") return;
            //if (raNhomTBN.Tag.ToString() == "0") return;
            //if (txtDNgay.Tag.ToString() == "0") return;
            //if (txtTNgay.Tag.ToString() == "0") return;
            ////if (fgDanhSach.Tag.ToString() == "0") return;
            //if (cmbNhom.SelectedIndex == -1)
            //{
            //    MessageBox.Show("Chọn nhóm lên chi phí.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    cmbNhom.Focus();
            //    return;
            //}
            //fgDanhSach.Tag = 0;
            //cmdTongHop_Click(sender, e);
            //fgDanhSach.Tag = 1;
        }

        private void btnInTongHop_Click(object sender, EventArgs e)
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
            if (txtTNgay.ValueIsDbNull || txtDNgay.ValueIsDbNull)
            {
                MessageBox.Show("Chưa nhập ngày tháng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string Ngay = "";
            DateTime TNgay = DateTime.Parse(txtTNgay.Text);
            DateTime DNgay = DateTime.Parse(txtDNgay.Text);
            System.TimeSpan Ngay1 = DNgay - TNgay;
            if (Ngay1.Days == 0)
            {
                Ngay = string.Format("Ngày {0:dd} tháng {0:MM} năm {0:yyyy}", txtTNgay.Value);
            }
            else
            {
                if (Ngay1.Days == 1)
                    Ngay = string.Format("Thuốc bất thường ngày {0:dd/MM/yyyy}\n", txtTNgay.Value);
                else
                    Ngay = string.Format("Thuốc bất thường từ {0:dd/MM/yyyy} đến {1:dd/MM/yyyy}\n", txtTNgay.Value, DNgay.AddDays(-1));
                Ngay += string.Format("Thuốc trong ngày {0:dd} tháng {0:MM} năm {0:yyyy}", txtDNgay.Value);
            }
            if (MaDuyetThuoc == "")
            {
                MessageBox.Show("Chọn Mã phiếu duyệt", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DataDynamics.ActiveReports.DataSources.SqlDBDataSource _ds = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            _ds.ConnectionString = GlobalModuls.Global.glbConnectionString;
            try
            {
                //_ds.SQL = String.Format("SELECT CASE WHEN A.DADUYET = 1 THEN N'BẢN SAO' ELSE '' END AS BANSAO,"
                //    + " B.MADICHVU,B.TENDICHVU,B.DVT,ROUND(SUM(A.SOLUONG),0) AS SOLUONG,A.KHOID,KHO.TENKHO,A.MAPHIEUDUYET + '-' + CONVERT(NVARCHAR,A.KHOID) AS MAPHIEUDUYET FROM"
                //    + " (BENHNHAN_PT_CHIPHI A INNER JOIN DMDICHVU B ON A.MADICHVU = B.MADICHVU)"
                //    + " INNER JOIN NAMDINH_DUOC.DBO.DANHMUCKHO KHO ON KHO.KHOID = A.KHOID"
                //    + " WHERE A.MAPHIEUDUYET ='{0}' AND A.LOAICHIPHI IN ('D01') AND", MaDuyetThuoc);
                //Son Sua
                _ds.SQL = String.Format("set dateformat dmy SELECT CASE WHEN A.DADUYET = 1 THEN N'BẢN SAO' ELSE '' END AS BANSAO,"
                    + " B.MADICHVU,B.TENDICHVU,B.DVT,Ceiling(SUM(A.SOLUONG)) AS SOLUONG,A.KHOID,KHO.TENKHO,A.MAPHIEUDUYET + '-' + CONVERT(NVARCHAR,A.KHOID) AS MAPHIEUDUYET"
                    + " ,case LEFT(B.MaLoaiThuoc,2) when 'DN' then 'VI' when 'GO' then 'VI' else LEFT(B.MaLoaiThuoc,2) end as GROUPS,A.NHOMLENCHIPHI From "
                    + " (BENHNHAN_PT_CHIPHI A INNER JOIN DMDICHVU B ON A.MADICHVU = B.MADICHVU)"
                    + " INNER JOIN NAMDINH_DUOC.DBO.DANHMUCKHO KHO ON KHO.KHOID = A.KHOID"
                    + " WHERE a.NgayChiDinh Between '{0:dd/MM/yyyy 00:00:00}' and '{1:dd/MM/yyyy 23:59:59}' AND A.LOAICHIPHI IN ('D01') AND A.MAPHIEUDUYET = '{2}' AND A.NHOMLENCHIPHI = '{3}' AND ", TNgay,DNgay,MaDuyetThuoc,Global.GetCode(cmbNhom));
                if (raDieuTriThuong.Checked)
                {
                    _ds.SQL += " B.MaLoaiThuoc NOT LIKE 'NGHT%' ";
                }
                else
                {
                    if (raThuocGayNghien.Checked)
                    {
                        _ds.SQL += " B.MaLoaiThuoc LIKE 'NGHT%' ";
                    }
                    else
                    {
                        if (raThuocHT.Checked)
                        {
                            _ds.SQL += " B.MaLoaiThuoc LIKE 'NGHT%' ";
                        }
                    }
                }
                _ds.SQL += " GROUP BY B.MADICHVU,B.TENDICHVU,B.DVT,A.DADUYET,A.KHOID,KHO.TENKHO,A.MAPHIEUDUYET,b.MaLoaiThuoc,A.NHOMLENCHIPHI "
                    + "Having sum(a.Soluong) >0 ORDER BY Groups,B.TENDICHVU";

                if (raDieuTriThuong.Checked)
                {
                    NamDinh_QLBN.Reports.rptPhieuLinhThuoc_Sua rpt = new NamDinh_QLBN.Reports.rptPhieuLinhThuoc_Sua(cmbKhoa.Text, Ngay, SoLuuTru, cmbNhom.Text);
                    rpt.DataSource = _ds;
                    rpt.Show();
                }
                else
                {
                    if (raThuocGayNghien.Checked)
                    {
                        NamDinh_QLBN.Reports.rptPhieuLinhThuocGayNghien_Sua rpt = new NamDinh_QLBN.Reports.rptPhieuLinhThuocGayNghien_Sua(cmbKhoa.Text, Ngay, SoLuuTru, cmbNhom.Text);
                        rpt.DataSource = _ds;
                        rpt.Show();
                    }
                    else
                    {
                        if (raThuocHT.Checked)
                        {
                            NamDinh_QLBN.Reports.rptPhieuLinhThuocGayNghien_Sua rpt = new NamDinh_QLBN.Reports.rptPhieuLinhThuocGayNghien_Sua(cmbKhoa.Text, Ngay, SoLuuTru, cmbNhom.Text);
                            rpt.DataSource = _ds;
                            rpt.Show();
                            //NamDinh_QLBN.Reports.rptPhieuLinhThuocHuongThan_Sua rpt = new NamDinh_QLBN.Reports.rptPhieuLinhThuocHuongThan_Sua(cmbKhoa.Text, Ngay);
                            //rpt.DataSource = _ds;
                            //rpt.Show();
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
            }
        }

        private void txtDNgay_Validated(object sender, EventArgs e)
        {
            //if (cmbKhoa.Tag.ToString() == "0") return;
            //if (raNhomToanKhoa.Tag.ToString() == "0") return;
            //if (raNhomTheoCP.Tag.ToString() == "0") return;
            //if (raNhomTBN.Tag.ToString() == "0") return;
            //if (txtDNgay.Tag.ToString() == "0") return;
            //if (txtTNgay.Tag.ToString() == "0") return;
            //if (fgDanhSach.Tag.ToString() == "0") return;
            //if (txtDNgay.Value.ToString() != DenNgay)
            //{
            //    fgDanhSach.Tag = 0;
            //    cmdTongHop_Click(sender, e);
            //    fgDanhSach.Tag = 1;
            //}
        }
    }
}