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
    public partial class frmTongHopChiPhiDieuTri : Form
    {
        private long _SoPhieuTu, _SoPhieuDen;
        public frmTongHopChiPhiDieuTri()
        {
            InitializeComponent();
        }

        private void LoatData()
        {
            try
            {
                Global.wait("Đang tổng hợp dữ liệu ...");
                String Str = "", MaVaoVien = "", DieuKien = "", LoaiDichVu = "", MaNhom = "";
                int STT = 0, STT1 = 0;
                if (cmbLoaiDichVu.SelectedIndex == -1)
                {
                    MessageBox.Show("Chọn loại dịch vụ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (cmbLoaiDichVu.SelectedIndex == 0)
                {
                    LoaiDichVu = "('D01')";
                }
                else
                {
                    if (cmbLoaiDichVu.SelectedIndex == 1)
                    {
                        LoaiDichVu = "('D02')";
                    }
                    else
                    {
                        LoaiDichVu = "('D05')";
                    }
                }

                if (cmbNhom.SelectedIndex == 0)
                {
                    DieuKien = "(0,1)";
                }
                else
                {
                    if (cmbNhom.SelectedIndex == 1)
                    {
                        DieuKien += "(0)";
                    }
                    else
                    {
                        if (cmbNhom.SelectedIndex == 2)
                        {
                            DieuKien += "(1)";
                        }
                    }
                }

                if (Global.GetCode(cmbNhomLenThuoc) != "0")
                    MaNhom = String.Format(" AND MANHOM = {0} ", Global.GetCode(cmbNhomLenThuoc));

                if (raNhomToanKhoa.Checked)
                {
                    //Truong hop in thuoc thi in theo ngay in
                    //Con truong hop  vat tu thi in theo ngay chi dinh
                    if (cmbLoaiDichVu.SelectedIndex == 1) // Truong hop vat tu
                    {
                        Str = String.Format("SELECT DATHUCHIEN,MADICHVU,TENDICHVU,DVT,SUM(SOLUONG) AS SOLUONG,MAKHOA,LOAIDICHVU,GHICHU FROM"
                            + " (SELECT B.DATHUCHIEN,B.MADICHVU,DMDICHVU.TENDICHVU,DMDICHVU.DVT,SUM(B.SOLUONG) AS SOLUONG,A.MAKHOA,DMDICHVU.LOAIDICHVU,case TinhPhi when 1 then N'Không tính phí' else '' end AS GHICHU FROM"
                            + " (BENHNHAN_PHIEUDIEUTRI A INNER JOIN PHIEUDIEUTRI_CHITIET B ON A.SOPHIEU = B.SOPHIEU)"
                            + " INNER JOIN DMDICHVU ON DMDICHVU.MADICHVU = B.MADICHVU AND DMDICHVU.LOAIDICHVU = B.LOAIDICHVU"
                            + " WHERE cast(RIGHT(B.MAPHIEUDUYET,9) as bigint) >= {1} AND cast(RIGHT(B.MAPHIEUDUYET,9)as bigint) <= {2} AND A.MAKHOA ='{0}' AND DMDICHVU.LOAIDICHVU IN {3} AND A.NHOM IN {4} {5}"
                            + " GROUP BY TinhPhi,B.DATHUCHIEN,B.MADICHVU,DMDICHVU.TENDICHVU,DMDICHVU.DVT,A.MAKHOA,DMDICHVU.LOAIDICHVU"
                            + " UNION ALL " //TRUONG HOP O PHONG KHAM
                            + " SELECT A.DATHUCHIEN,DMDICHVU.MADICHVU,DMDICHVU.TENDICHVU,DMDICHVU.DVT,SUM(A.SOLUONG) AS SOLUONG,A.MAKHOATHUCHIEN AS MAKHOA,DMDICHVU.LOAIDICHVU,case TinhPhi when 1 then N'Không tính phí' else '' end AS GHICHU"
                            + " FROM"
                            + " (NAMDINH_KHAMBENH.DBO.tblCHIPHI_DICHVU A INNER JOIN DMDICHVU ON A.MACHIPHI = DMDICHVU.MADICHVU AND A.LOAICHIPHI = DMDICHVU.LOAIDICHVU)"
                            + " WHERE cast(RIGHT(A.MAPHIEUDUYET,9) as bigint) >= {1} AND cast(RIGHT(A.MAPHIEUDUYET,9)as bigint) <= {2} AND A.MAKHOATHUCHIEN ='{0}' AND DMDICHVU.LOAIDICHVU IN {3} {5}"
                            + " GROUP BY TinhPhi,A.DATHUCHIEN,DMDICHVU.MADICHVU,DMDICHVU.TENDICHVU,DMDICHVU.DVT,A.MAKHOATHUCHIEN,DMDICHVU.LOAIDICHVU"
                            + " UNION ALL" //TRUONG HOP THU THUAT
                            + " SELECT A.DATHUCHIEN,DMDICHVU.MADICHVU,DMDICHVU.TENDICHVU,DMDICHVU.DVT,SUM(A.SOLUONG) AS SOLUONG,A.MAKHOA,DMDICHVU.LOAIDICHVU,case TinhPhi when 1 then N'Không tính phí' else '' end  AS GHICHU FROM"
                            + " (CHIPHI_THUTHUAT A INNER JOIN DMDICHVU ON A.MACHIPHI = DMDICHVU.MADICHVU AND A.LOAIDICHVU = DMDICHVU.LOAIDICHVU)"
                            + " WHERE cast(RIGHT(A.MAPHIEUDUYET,9) as bigint) >= {1} AND cast(RIGHT(A.MAPHIEUDUYET,9)as bigint) <= {2} AND A.MAKHOA ='{0}' AND DMDICHVU.LOAIDICHVU IN {3} AND A.NHOM IN {4} {5}"
                            + " GROUP BY TinhPhi,A.DATHUCHIEN,DMDICHVU.MADICHVU,DMDICHVU.TENDICHVU,DMDICHVU.DVT,A.MAKHOA,DMDICHVU.LOAIDICHVU"
                            + " ) AA"
                            + " GROUP BY DATHUCHIEN,MADICHVU,TENDICHVU,DVT,MAKHOA,LOAIDICHVU ORDER BY TENDICHVU",
                            GlobalModuls.Global.GetCode(cmbKhoa),
                            _SoPhieuTu, _SoPhieuDen, LoaiDichVu, DieuKien, MaNhom);
                    }
                    else
                    {
                        Str = String.Format("SELECT DATHUCHIEN,MADICHVU,TENDICHVU,DVT,SUM(SOLUONG) AS SOLUONG,MAKHOA,LOAIDICHVU,GHICHU FROM"
                           + " (SELECT B.DATHUCHIEN,B.MADICHVU,DMDICHVU.TENDICHVU,DMDICHVU.DVT,SUM(B.SOLUONG) AS SOLUONG,A.MAKHOA,DMDICHVU.LOAIDICHVU,case TinhPhi when 1 then N'Không tính phí' else '' end  AS GHICHU FROM"
                           + " (BENHNHAN_PHIEUDIEUTRI A INNER JOIN PHIEUDIEUTRI_CHITIET B ON A.SOPHIEU = B.SOPHIEU)"
                           + " INNER JOIN DMDICHVU ON DMDICHVU.MADICHVU = B.MADICHVU AND DMDICHVU.LOAIDICHVU = B.LOAIDICHVU"
                           + " WHERE cast(RIGHT(B.MAPHIEUDUYET,9) as bigint) >= {1} AND cast(RIGHT(B.MAPHIEUDUYET,9)as bigint) <= {2} AND A.MAKHOA ='{0}' AND DMDICHVU.LOAIDICHVU IN {3} AND A.NHOM IN {4} {5}"
                           + " GROUP BY TinhPhi,B.DATHUCHIEN,B.MADICHVU,DMDICHVU.TENDICHVU,DMDICHVU.DVT,A.MAKHOA,DMDICHVU.LOAIDICHVU"
                           + " UNION ALL " //TRUONG HOP O PHONG KHAM
                           + " SELECT A.DATHUCHIEN,DMDICHVU.MADICHVU,DMDICHVU.TENDICHVU,DMDICHVU.DVT,SUM(A.SOLUONG) AS SOLUONG,A.MAKHOATHUCHIEN AS MAKHOA,DMDICHVU.LOAIDICHVU,case TinhPhi when 1 then N'Không tính phí' else '' end AS GHICHU"
                           + " FROM"
                           + " (NAMDINH_KHAMBENH.DBO.tblCHIPHI_DICHVU A INNER JOIN DMDICHVU ON A.MACHIPHI = DMDICHVU.MADICHVU AND A.LOAICHIPHI = DMDICHVU.LOAIDICHVU)"
                           + " WHERE cast(RIGHT(A.MAPHIEUDUYET,9) as bigint) >= {1} AND cast(RIGHT(A.MAPHIEUDUYET,9)as bigint) <= {2} AND A.MAKHOATHUCHIEN ='{0}' AND DMDICHVU.LOAIDICHVU IN {3} {5}"
                           + " GROUP BY TinhPhi,A.DATHUCHIEN,DMDICHVU.MADICHVU,DMDICHVU.TENDICHVU,DMDICHVU.DVT,A.MAKHOATHUCHIEN,DMDICHVU.LOAIDICHVU"
                           + " UNION ALL" //TRUONG HOP THU THUAT
                           + " SELECT A.DATHUCHIEN,DMDICHVU.MADICHVU,DMDICHVU.TENDICHVU,DMDICHVU.DVT,SUM(A.SOLUONG) AS SOLUONG,A.MAKHOA,DMDICHVU.LOAIDICHVU,case TinhPhi when 1 then N'Không tính phí' else '' end AS GHICHU FROM"
                           + " (CHIPHI_THUTHUAT A INNER JOIN DMDICHVU ON A.MACHIPHI = DMDICHVU.MADICHVU AND A.LOAIDICHVU = DMDICHVU.LOAIDICHVU)"
                           + " WHERE cast(RIGHT(A.MAPHIEUDUYET,9) as bigint) >= {1} AND cast(RIGHT(A.MAPHIEUDUYET,9)as bigint) <= {2} AND A.MAKHOA ='{0}' AND DMDICHVU.LOAIDICHVU IN {3} AND A.NHOM IN {4} {5}"
                           + " GROUP BY TinhPhi,A.DATHUCHIEN,DMDICHVU.MADICHVU,DMDICHVU.TENDICHVU,DMDICHVU.DVT,A.MAKHOA,DMDICHVU.LOAIDICHVU"
                           + " ) AA"
                           + " GROUP BY DATHUCHIEN,MADICHVU,TENDICHVU,DVT,MAKHOA,LOAIDICHVU,GhiChu ORDER BY TENDICHVU",
                           GlobalModuls.Global.GetCode(cmbKhoa),
                           _SoPhieuTu, _SoPhieuDen, LoaiDichVu, DieuKien, MaNhom);
                    }
                }
                else
                {
                    Str = string.Format("SELECT DATHUCHIEN,MAVAOVIEN,HOTEN,AA.MADICHVU,AA.LOAIDICHVU,SUM(SOLUONG) AS SOLUONG,DMDICHVU.TENDICHVU,DMDICHVU.DVT,AA.GHICHU,NHOM AS TT_HN FROM"
                            + " ("  //NOI CAC UNION LAI
                            + " SELECT D.DATHUCHIEN,B.MAVAOVIEN,A.HOTEN,D.MADICHVU,D.LOAIDICHVU,D.SOLUONG,C.NGAYCHIDINH,C.MAKHOA,C.NHOM ,case TinhPhi when 1 then N'Không tính phí' else '' end as GhiChu FROM"
                            + " (BENHNHAN A INNER JOIN BENHNHAN_CHITIET B ON A.MABENHNHAN = B.MABENHNHAN)"
                            + " INNER JOIN BENHNHAN_PHIEUDIEUTRI C ON C.MAVAOVIEN = B.MAVAOVIEN"
                            + " INNER JOIN PHIEUDIEUTRI_CHITIET D ON D.SOPHIEU = C.SOPHIEU"
                            + " WHERE cast(RIGHT(D.MAPHIEUDUYET,9) as bigint) >= {1} AND cast(RIGHT(D.MAPHIEUDUYET,9)as bigint) <= {2} " + (MaNhom == "" ? "" : " AND D.MANHOM= " + Global.GetCode(cmbNhomLenThuoc))
                            + " UNION ALL" //O THU THUAT
                            + " SELECT C.DATHUCHIEN,B.MAVAOVIEN,A.HOTEN,C.MACHIPHI,C.LOAIDICHVU,C.SOLUONG,C.NGAYTHUCHIEN,C.MAKHOA,C.NHOM,case TinhPhi when 1 then N'Không tính phí' else '' end as GhiChu "
                            + " FROM (BENHNHAN A INNER JOIN BENHNHAN_CHITIET B ON A.MABENHNHAN = B.MABENHNHAN)"
                            + " INNER JOIN CHIPHI_THUTHUAT C ON C.MAVAOVIEN = B.MAVAOVIEN"
                            + " WHERE cast(RIGHT(C.MAPHIEUDUYET,9) as bigint) >= {1} AND cast(RIGHT(C.MAPHIEUDUYET,9)as bigint) <= {2} " + (MaNhom == "" ? "" : " AND C.MANHOM= " + Global.GetCode(cmbNhomLenThuoc))
                            + " UNION ALL"// O BANG NAMDINH_KHAMBENH
                            + " SELECT C.DATHUCHIEN,B.MAKHAMBENH,A.TENBENHNHAN,C.MACHIPHI,C.LOAICHIPHI,C.SOLUONG,C.NGAYTHUCHIEN,C.MAKHOATHUCHIEN,1 AS NHOM,case TinhPhi when 1 then N'Không tính phí' else '' end as GhiChu "
                            + " FROM (NAMDINH_KHAMBENH.DBO.TBLBENHNHAN A INNER JOIN NAMDINH_KHAMBENH.DBO.TBLKHAMBENH B ON A.MABENHNHAN = B.MABENHNHAN)"
                            + " INNER JOIN NAMDINH_KHAMBENH.DBO.TBLCHIPHI_DICHVU C ON C.MAKHAMBENH = B.MAKHAMBENH"
                            + " WHERE cast(RIGHT(C.MAPHIEUDUYET,9) as bigint) >= {1} AND cast(RIGHT(C.MAPHIEUDUYET,9)as bigint) <= {2} " + (MaNhom == "" ? "" : " AND C.MANHOM= " + Global.GetCode(cmbNhomLenThuoc))
                            + " ) AA"
                            + " INNER JOIN DMDICHVU ON DMDICHVU.MADICHVU = AA.MADICHVU AND DMDICHVU.LOAIDICHVU = AA.LOAIDICHVU"
                            + " WHERE MAKHOA ='{0}' AND AA.NHOM IN {3} AND AA.LOAIDICHVU IN {4}",
                            GlobalModuls.Global.GetCode(cmbKhoa), _SoPhieuTu, _SoPhieuDen, DieuKien, LoaiDichVu);
                    Str += " GROUP BY AA.GhiChu,DATHUCHIEN,MAVAOVIEN,HOTEN,AA.MADICHVU,AA.LOAIDICHVU,DMDICHVU.TENDICHVU,DMDICHVU.DVT,AA.NHOM";
                    if (raNhomTBN.Checked)
                    {
                        Str += " ORDER BY HOTEN,MAVAOVIEN,DMDICHVU.TENDICHVU";
                    }
                    else
                    {
                        Str += " ORDER BY DMDICHVU.TENDICHVU,HOTEN,MAVAOVIEN";
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
                            Row["DATHUCHIEN"],
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
                    fgDanhSach.Cols[2].Visible = fgDanhSach.Cols[7].Visible = fgDanhSach.Cols[8].Visible = false;//fgDanhSach.Cols[6].Visible = 
                    fgDanhSach.Cols[3].Visible = fgDanhSach.Cols[4].Visible = true;
                }
                else
                {
                    fgDanhSach.Cols[7].Visible = fgDanhSach.Cols[8].Visible = true;
                    fgDanhSach.Tree.Column = 5;
                    fgDanhSach.Cols[6].DataType = typeof(Decimal);
                    fgDanhSach.Cols[6].Format = "#,##0.##";
                    fgDanhSach.Cols[4].DataType = typeof(object);
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
                                Row["DATHUCHIEN"],
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
                        fgDanhSach.Cols[2].Visible = fgDanhSach.Cols[3].Visible = fgDanhSach.Cols[4].Visible = false;//fgDanhSach.Cols[8].Visible = 
                        fgDanhSach.Cols[6].Visible = true;
                        STT = 0;
                        MaVaoVien = "";
                        STT1 = 1;
                    }
                    else
                    {
                        fgDanhSach.Cols[6].DataType = typeof(Decimal);
                        fgDanhSach.Cols[6].Format = "#,##0.##";
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
                            fgDanhSach.AddItem(String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}",
                                STT1.ToString(),
                                Row["DATHUCHIEN"],
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                Global.nowait();
            }
        }


        private void frmPhieuLinhThuoc_Load(object sender, EventArgs e)
        {
            cmbKhoa.Tag = 0;
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

            SQLCmd.CommandText = "SELECT * FROM KHOA_NHOM WHERE MaKhoa IN " + Global.glbKhoa_CapNhat;
            dr = SQLCmd.ExecuteReader();
            cmbNhomLenThuoc.Tag = "0";
            cmbNhomLenThuoc.ClearItems();
            cmbNhomLenThuoc.AddItem("0;--------- Tất cả---------");
            while (dr.Read())
            {
                cmbNhomLenThuoc.AddItem(string.Format("{0};{1}", dr["Manhom"], dr["TenNhom"]));
            }
            dr.Close();
            cmbNhomLenThuoc.SelectedIndex = 0;


            if (cmbKhoa.ListCount == 1) cmbKhoa.SelectedIndex = 0;
            cmbNhom.AddItem("--------- Tất cả---------");
            cmbNhom.AddItem("Chi phí trong ngày");
            cmbNhom.AddItem("Chi phí bất thường");
            cmbNhom.SelectedIndex = 0;
            cmbLoaiDichVu.AddItem("Thuốc, hóa chất");
            cmbLoaiDichVu.AddItem("Vật tư tiêu hao");
            cmbLoaiDichVu.AddItem("Thuốc đông y");
            cmbLoaiDichVu.SelectedIndex = 0;
            C1.Win.C1FlexGrid.CellStyle cs = fgDanhSach.Styles[C1.Win.C1FlexGrid.CellStyleEnum.Subtotal0];
            cs.BackColor = Color.LightBlue;
            cs.ForeColor = Color.DarkBlue;
            cmbKhoa.Tag = 1;
            raNhomTBN.Tag = raNhomTheoCP.Tag = raNhomToanKhoa.Tag = 1;
            cmbNhom.Tag = 1;

            SQLCmd.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cmbKhoa.SelectedIndex == -1)
            {
                MessageBox.Show("Chưa chọn Khoa điều trị!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cmbKhoa.Focus();
                return;
            }

            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
            String Str;
            Str = String.Format("DECLARE @MaPhieuDuyet nVarChar(10)"
                            + " DECLARE @SoLuongMaPhieuDuyet nVarChar(800)"
                            + " DECLARE Cur CURSOR "
                            + " FOR"
                            + " 	SELECT B.MAPHIEUDUYET FROM"
                            + " 	(BENHNHAN_PHIEUDIEUTRI A INNER JOIN PHIEUDIEUTRI_CHITIET B ON A.SOPHIEU = B.SOPHIEU) "
                            + " 	WHERE cast(RIGHT(B.MAPHIEUDUYET,9) as bigint) >= {1} AND cast(RIGHT(B.MAPHIEUDUYET,9)as bigint) <= {2} AND A.MAKHOA ='{0}'"
                            + " 	GROUP BY B.MAPHIEUDUYET ORDER BY RIGHT(B.MAPHIEUDUYET,9)"
                            + " OPEN Cur"
                            + " FETCH NEXT FROM Cur  INTO @MaPhieuDuyet"
                            + " WHILE @@FETCH_STATUS = 0"
                            + " BEGIN"
                            + " 	IF @SoLuongMaPhieuDuyet IS NULL "
                            + " 		SET @SoLuongMaPhieuDuyet = ISNULL(@MaPhieuDuyet,'') "
                            + " 	ELSE"
                            + " 		SET @SoLuongMaPhieuDuyet = ISNULL(@SoLuongMaPhieuDuyet,'') + ',' + ISNULL(@MaPhieuDuyet,'') "
                            + " 	FETCH NEXT FROM Cur  INTO @MaPhieuDuyet"
                            + " END"
                            + " DEALLOCATE  Cur"
                          + " SELECT @SoLuongMaPhieuDuyet AS SOLUONGPHIEU,MADICHVU,TENDICHVU,DVT,ROUND(SUM(SOLUONG),0) AS SOLUONG,MAKHOA,LOAIDICHVU,'' AS GHICHU,KHOID,"
                          + " case LEFT(aa.MADICHVU,2) when 'DN' then 'VI' when 'GO' then 'VI' else LEFT(aa.MADICHVU,2) end as GROUPS FROM"
                          + " (SELECT B.MADICHVU,DMDICHVU.TENDICHVU,DMDICHVU.DVT,SUM(B.SOLUONG) AS SOLUONG,A.MAKHOA,DMDICHVU.LOAIDICHVU,'' AS GHICHU,B.KHOID FROM"
                          + " (BENHNHAN_PHIEUDIEUTRI A INNER JOIN PHIEUDIEUTRI_CHITIET B ON A.SOPHIEU = B.SOPHIEU)"
                          + " INNER JOIN DMDICHVU ON DMDICHVU.MADICHVU = B.MADICHVU AND DMDICHVU.LOAIDICHVU = B.LOAIDICHVU"
                          + " WHERE cast(RIGHT(B.MAPHIEUDUYET,9) as bigint) >= {1} AND cast(RIGHT(B.MAPHIEUDUYET,9)as bigint) <= {2} AND A.MAKHOA ='{0}'" + (Global.GetCode(cmbNhomLenThuoc) == "0" ? "" : " AND B.MANHOM = " + Global.GetCode(cmbNhomLenThuoc))
                          + " GROUP BY B.MADICHVU,DMDICHVU.TENDICHVU,DMDICHVU.DVT,A.MAKHOA,DMDICHVU.LOAIDICHVU,B.KHOID"
                          + " UNION ALL " //TRUONG HOP O PHONG KHAM
                          + " SELECT DMDICHVU.MADICHVU,DMDICHVU.TENDICHVU,DMDICHVU.DVT,SUM(A.SOLUONG) AS SOLUONG,A.MAKHOATHUCHIEN AS MAKHOA,DMDICHVU.LOAIDICHVU,'' AS GHICHU,A.KHOID"
                          + " FROM"
                          + " (NAMDINH_KHAMBENH.DBO.tblCHIPHI_DICHVU A INNER JOIN DMDICHVU ON A.MACHIPHI = DMDICHVU.MADICHVU AND A.LOAICHIPHI = DMDICHVU.LOAIDICHVU)"
                          + " WHERE cast(RIGHT(A.MAPHIEUDUYET,9) as bigint) >= {1} AND cast(RIGHT(A.MAPHIEUDUYET,9)as bigint) <= {2} AND A.MAKHOATHUCHIEN ='{0}'" + (Global.GetCode(cmbNhomLenThuoc) == "0" ? "" : " AND A.MANHOM = " + Global.GetCode(cmbNhomLenThuoc))
                          + " GROUP BY DMDICHVU.MADICHVU,DMDICHVU.TENDICHVU,DMDICHVU.DVT,A.MAKHOATHUCHIEN,DMDICHVU.LOAIDICHVU,A.KHOID"
                          + " UNION ALL" //TRUONG HOP THU THUAT
                          + " SELECT DMDICHVU.MADICHVU,DMDICHVU.TENDICHVU,DMDICHVU.DVT,SUM(A.SOLUONG) AS SOLUONG,A.MAKHOA,DMDICHVU.LOAIDICHVU,'' AS GHICHU,A.KHOID FROM"
                          + " (CHIPHI_THUTHUAT A INNER JOIN DMDICHVU ON A.MACHIPHI = DMDICHVU.MADICHVU AND A.LOAIDICHVU = DMDICHVU.LOAIDICHVU)"
                          + " WHERE cast(RIGHT(A.MAPHIEUDUYET,9) as bigint) >= {1} AND cast(RIGHT(A.MAPHIEUDUYET,9)as bigint) <= {2} AND A.MAKHOA ='{0}'" + (Global.GetCode(cmbNhomLenThuoc) == "0" ? "" : " AND A.MANHOM = " + Global.GetCode(cmbNhomLenThuoc))
                          + " GROUP BY DMDICHVU.MADICHVU,DMDICHVU.TENDICHVU,DMDICHVU.DVT,A.MAKHOA,DMDICHVU.LOAIDICHVU,A.KHOID"
                          + " ) AA",
                          GlobalModuls.Global.GetCode(cmbKhoa),
                          _SoPhieuTu, _SoPhieuDen);
            if (raDieuTriThuong.Checked)
            {
                Str += " WHERE AA.MADICHVU NOT LIKE 'NGHT%' AND AA.MADICHVU NOT LIKE 'DY-DY' AND AA.MADICHVU NOT LIKE 'VT-VA%' GROUP BY MADICHVU,TENDICHVU,DVT,MAKHOA,LOAIDICHVU,KHOID ORDER BY Groups,TENDICHVU";
            }
            else if (raThuocHT.Checked)
            {
                Str += " WHERE AA.MADICHVU LIKE 'NGHT%' GROUP BY MADICHVU,TENDICHVU,DVT,MAKHOA,LOAIDICHVU,KHOID ORDER BY Groups,TENDICHVU";
            }
            else if (raThuocDongY.Checked)
            {
                Str += " WHERE AA.MADICHVU LIKE 'DY-DY%' GROUP BY MADICHVU,TENDICHVU,DVT,MAKHOA,LOAIDICHVU,KHOID ORDER BY KHOID,TENDICHVU";
            }
            else
            {
                Str = String.Format("SELECT DATHUCHIEN,MADICHVU,TENDICHVU,DVT,SUM(SOLUONG) AS SOLUONG,MAKHOA,LOAIDICHVU,'' AS GHICHU FROM"
                + " (SELECT B.DATHUCHIEN,B.MADICHVU,DMDICHVU.TENDICHVU,DMDICHVU.DVT,SUM(B.SOLUONG) AS SOLUONG,A.MAKHOA,DMDICHVU.LOAIDICHVU,'' AS GHICHU FROM"
                + " (BENHNHAN_PHIEUDIEUTRI A INNER JOIN PHIEUDIEUTRI_CHITIET B ON A.SOPHIEU = B.SOPHIEU)"
                + " INNER JOIN DMDICHVU ON DMDICHVU.MADICHVU = B.MADICHVU AND DMDICHVU.LOAIDICHVU = B.LOAIDICHVU"
                + " WHERE cast(RIGHT(B.MAPHIEUDUYET,9) as bigint) >= {1} AND cast(RIGHT(B.MAPHIEUDUYET,9)as bigint) <= {2} AND A.MAKHOA ='{0}'"
                + " GROUP BY B.DATHUCHIEN,B.MADICHVU,DMDICHVU.TENDICHVU,DMDICHVU.DVT,A.MAKHOA,DMDICHVU.LOAIDICHVU"
                + " UNION ALL " //TRUONG HOP O PHONG KHAM
                + " SELECT A.DATHUCHIEN,DMDICHVU.MADICHVU,DMDICHVU.TENDICHVU,DMDICHVU.DVT,SUM(A.SOLUONG) AS SOLUONG,A.MAKHOATHUCHIEN AS MAKHOA,DMDICHVU.LOAIDICHVU,'' AS GHICHU"
                + " FROM"
                + " (NAMDINH_KHAMBENH.DBO.tblCHIPHI_DICHVU A INNER JOIN DMDICHVU ON A.MACHIPHI = DMDICHVU.MADICHVU AND A.LOAICHIPHI = DMDICHVU.LOAIDICHVU)"
                + " WHERE RIGHT(A.MAPHIEUDUYET,9) >= {1} AND RIGHT(A.MAPHIEUDUYET,9) <= {2} AND A.MAKHOATHUCHIEN ='{0}'"
                + " GROUP BY A.DATHUCHIEN,DMDICHVU.MADICHVU,DMDICHVU.TENDICHVU,DMDICHVU.DVT,A.MAKHOATHUCHIEN,DMDICHVU.LOAIDICHVU"
                + " UNION ALL" //TRUONG HOP THU THUAT
                + " SELECT A.DATHUCHIEN,DMDICHVU.MADICHVU,DMDICHVU.TENDICHVU,DMDICHVU.DVT,SUM(A.SOLUONG) AS SOLUONG,A.MAKHOA,DMDICHVU.LOAIDICHVU,'' AS GHICHU FROM"
                + " (CHIPHI_THUTHUAT A INNER JOIN DMDICHVU ON A.MACHIPHI = DMDICHVU.MADICHVU AND A.LOAIDICHVU = DMDICHVU.LOAIDICHVU)"
                + " WHERE cast(RIGHT(A.MAPHIEUDUYET,9) as bigint) >= {1} AND cast(RIGHT(A.MAPHIEUDUYET,9)as bigint) <= {2} AND A.MAKHOA ='{0}'"
                + " GROUP BY A.DATHUCHIEN,DMDICHVU.MADICHVU,DMDICHVU.TENDICHVU,DMDICHVU.DVT,A.MAKHOA,DMDICHVU.LOAIDICHVU"
                + " ) AA WHERE AA.MADICHVU LIKE 'VT-VA%'"
                + " GROUP BY DATHUCHIEN,MADICHVU,TENDICHVU,DVT,MAKHOA,LOAIDICHVU ORDER BY TENDICHVU",
                GlobalModuls.Global.GetCode(cmbKhoa),
                _SoPhieuTu, _SoPhieuDen);
            }
            SQLCmd.CommandText = Str;
            System.Data.SqlClient.SqlDataReader dr = SQLCmd.ExecuteReader();
            if (raDieuTriThuong.Checked)
            {
                NamDinh_QLBN.Reports.BaoCaoVeThuoc.rptPhieuLinhThuoc rpt = new NamDinh_QLBN.Reports.BaoCaoVeThuoc.rptPhieuLinhThuoc(cmbKhoa.Text, "");
                rpt.DataSource = dr;
                rpt.Show();
            }
            else
            {
                if (raThuocGayNghien.Checked)
                {
                    NamDinh_QLBN.Reports.BaoCaoVeThuoc.rptPhieuLinhThuocGayNghien rpt = new NamDinh_QLBN.Reports.BaoCaoVeThuoc.rptPhieuLinhThuocGayNghien(cmbKhoa.Text, "");
                    rpt.DataSource = dr;
                    rpt.Show();
                }
                else
                {
                    if (raThuocHT.Checked)
                    {
                        NamDinh_QLBN.Reports.BaoCaoVeThuoc.rptPhieuLinhThuocHuongThan rpt = new NamDinh_QLBN.Reports.BaoCaoVeThuoc.rptPhieuLinhThuocHuongThan(cmbKhoa.Text, "");
                        rpt.DataSource = dr;
                        rpt.Show();
                    }
                    else
                    {
                        NamDinh_QLBN.Reports.BaoCaoVeThuoc.rptPhieuLinhThuoc rpt = new NamDinh_QLBN.Reports.BaoCaoVeThuoc.rptPhieuLinhThuoc(cmbKhoa.Text, "");
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

        private void cmdDuyet_Click(object sender, EventArgs e)
        {

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
            if (raNhomToanKhoa.Checked)
                cmdTongHop_Click(sender, e);
        }

        private void txtTNgay_ValueChanged(object sender, EventArgs e)
        {
            if (cmbKhoa.Tag.ToString() == "0") return;
            if (cmbNhom.Tag.ToString() == "0") return;
            if (raNhomToanKhoa.Tag.ToString() == "0") return;
            if (raNhomTheoCP.Tag.ToString() == "0") return;
            if (raNhomTBN.Tag.ToString() == "0") return;
            cmdTongHop_Click(sender, e);
        }

        private void txtDNgay_ValueChanged(object sender, EventArgs e)
        {
            if (cmbKhoa.Tag.ToString() == "0") return;
            if (cmbNhom.Tag.ToString() == "0") return;
            if (raNhomToanKhoa.Tag.ToString() == "0") return;
            if (raNhomTheoCP.Tag.ToString() == "0") return;
            if (raNhomTBN.Tag.ToString() == "0") return;
            cmdTongHop_Click(sender, e);
        }

        private void raNhomTheoCP_CheckedChanged(object sender, EventArgs e)
        {
            if (cmbKhoa.Tag.ToString() == "0") return;
            if (cmbNhom.Tag.ToString() == "0") return;
            if (raNhomToanKhoa.Tag.ToString() == "0") return;
            if (raNhomTheoCP.Tag.ToString() == "0") return;
            if (raNhomTBN.Tag.ToString() == "0") return;
            if (raNhomTheoCP.Checked)
                cmdTongHop_Click(sender, e);
        }

        private void raNhomTBN_CheckedChanged(object sender, EventArgs e)
        {
            if (cmbKhoa.Tag.ToString() == "0") return;
            if (cmbNhom.Tag.ToString() == "0") return;
            if (raNhomToanKhoa.Tag.ToString() == "0") return;
            if (raNhomTheoCP.Tag.ToString() == "0") return;
            if (raNhomTBN.Tag.ToString() == "0") return;
            if (raNhomTBN.Checked)
                cmdTongHop_Click(sender, e);
        }

        private void cmbNhom_TextChanged(object sender, EventArgs e)
        {
            if (cmbKhoa.Tag.ToString() == "0") return;
            if (cmbNhom.Tag.ToString() == "0") return;
            if (raNhomToanKhoa.Tag.ToString() == "0") return;
            if (raNhomTheoCP.Tag.ToString() == "0") return;
            if (raNhomTBN.Tag.ToString() == "0") return;
            cmdTongHop_Click(sender, e);
        }

        private void chDaThucHien_CheckedChanged(object sender, EventArgs e)
        {
            if (cmbKhoa.Tag.ToString() == "0") return;
            if (cmbNhom.Tag.ToString() == "0") return;
            if (raNhomToanKhoa.Tag.ToString() == "0") return;
            if (raNhomTheoCP.Tag.ToString() == "0") return;
            if (raNhomTBN.Tag.ToString() == "0") return;
            cmdTongHop_Click(sender, e);
        }

        private void cmbLoaiDichVu_TextChanged(object sender, EventArgs e)
        {
            if (cmbKhoa.Tag.ToString() == "0") return;
            if (cmbNhom.Tag.ToString() == "0") return;
            if (raNhomToanKhoa.Tag.ToString() == "0") return;
            if (raNhomTheoCP.Tag.ToString() == "0") return;
            if (raNhomTBN.Tag.ToString() == "0") return;
            cmdTongHop_Click(sender, e);
        }

        private void cmdTongHop_Click(object sender, EventArgs e)
        {
            if (cmbKhoa.SelectedIndex == -1)
            {
                MessageBox.Show("Chưa chọn Khoa điều trị!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cmbKhoa.Focus();
                return;
            }
            if ((txtSoPhieuTu.Text.Replace("/", "").Trim().Length < 10) || (txtSoPhieuDen.Text.Replace("/", "").Trim().Length < 10))
            {
                MessageBox.Show("Xem lại Mã phiếu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            _SoPhieuTu = long.Parse(txtSoPhieuTu.Text.Replace("/", "").Trim().Substring(1, txtSoPhieuTu.Text.Replace("/", "").Trim().Length - 1));
            _SoPhieuDen = long.Parse(txtSoPhieuDen.Text.Replace("/", "").Trim().Substring(1, txtSoPhieuDen.Text.Replace("/", "").Trim().Length - 1));
            fgDanhSach.Tag = 0;
            LoatData();
            fgDanhSach.Tag = 1;
            fgDanhSach_Click(sender, e);
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            string TenFile;
            System.Windows.Forms.SaveFileDialog dg = new SaveFileDialog();
            dg.Filter = "Xuất số liệu ra file Excel (*.xls)|*.xls";
            dg.FilterIndex = 0;
            dg.CheckFileExists = false;
            dg.Title = "Nhập tên file để kết xuất số liệu.";
            if (dg.ShowDialog() == DialogResult.OK)
                TenFile = dg.FileName;
            else
                return;
            if (TenFile.Split(".".ToCharArray()).Length < 2)
                TenFile = TenFile + ".xls";
            fgDanhSach.SaveExcel(TenFile);
            MessageBox.Show("Bạn đã lưu thành công file " + TenFile + " !");
        }
    }
}