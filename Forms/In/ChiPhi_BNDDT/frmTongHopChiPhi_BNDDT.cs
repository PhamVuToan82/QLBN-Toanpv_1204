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
    public partial class frmTongHopChiPhi_BNDDT : Form
    {
       
        public frmTongHopChiPhi_BNDDT()
        {
            InitializeComponent();
        }

        private void LoatData()
        {
            try
            {
                Global.wait("Đang tổng hợp dữ liệu ...");
                String Str = "", DieuKien = "", LoaiDichVu = "";
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
                    LoaiDichVu = "('D05')";
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
                if (chkNgayChot.Checked == false)
                {
                    Str = String.Format(" SELECT 0 AS DATHUCHIEN,MADICHVU,TENDICHVU,DVT,SUM(SOLUONG) AS SOLUONG,DonGia,MAKHOA,LOAIDICHVU,'' AS GHICHU FROM"
                                           + " (SELECT B.MADICHVU,DMDICHVU.TENDICHVU,DMDICHVU.DVT,SUM(B.SOLUONG) AS SOLUONG,B.DonGia,A.MAKHOA,DMDICHVU.LOAIDICHVU,'' AS GHICHU FROM"
                                           + " (BENHNHAN_PHIEUDIEUTRI A INNER JOIN PHIEUDIEUTRI_CHITIET B ON A.SOPHIEU = B.SOPHIEU)"
                                           + " INNER JOIN DMDICHVU ON DMDICHVU.MADICHVU = B.MADICHVU AND DMDICHVU.LOAIDICHVU = B.LOAIDICHVU"
                                           + " INNER JOIN VIEWKHOAHIENTAI K ON K.MAVAOVIEN = A.MAVAOVIEN AND K.MAKHOA = A.MAKHOA"
                                           + " WHERE K.VTRANGTHAI = 1 AND K.VDARAVIEN = 0 AND A.MAKHOA ='{0}' AND DMDICHVU.LOAIDICHVU IN {1} AND A.NHOM IN {2}" + (Global.GetCode(cmbNhomLenThuoc) == "0" ? " " : " AND B.MANHOM= " + Global.GetCode(cmbNhomLenThuoc))
                                           + " GROUP BY B.DonGia,B.DATHUCHIEN,B.MADICHVU,DMDICHVU.TENDICHVU,DMDICHVU.DVT,A.MAKHOA,DMDICHVU.LOAIDICHVU"
                                           + " UNION ALL" //TRUONG HOP THU THUAT
                                           + " SELECT DMDICHVU.MADICHVU,DMDICHVU.TENDICHVU,DMDICHVU.DVT,SUM(A.SOLUONG) AS SOLUONG,A.DonGia,A.MAKHOA,DMDICHVU.LOAIDICHVU,'' AS GHICHU FROM"
                                           + " (CHIPHI_THUTHUAT A INNER JOIN DMDICHVU ON A.MACHIPHI = DMDICHVU.MADICHVU AND A.LOAIDICHVU = DMDICHVU.LOAIDICHVU)"
                                           + " INNER JOIN VIEWKHOAHIENTAI ON VIEWKHOAHIENTAI.MAVAOVIEN = A.MAVAOVIEN AND VIEWKHOAHIENTAI.MAKHOA = A.MAKHOA"
                                           + " WHERE VIEWKHOAHIENTAI.VTRANGTHAI = 1 AND VIEWKHOAHIENTAI.VDARAVIEN = 0 AND A.MAKHOA ='{0}' AND DMDICHVU.LOAIDICHVU IN {1} AND A.NHOM IN {2}" + (Global.GetCode(cmbNhomLenThuoc) == "0" ? " " : " AND A.MANHOM= " + Global.GetCode(cmbNhomLenThuoc))
                                           + " GROUP BY A.DonGia,A.DATHUCHIEN,DMDICHVU.MADICHVU,DMDICHVU.TENDICHVU,DMDICHVU.DVT,A.MAKHOA,DMDICHVU.LOAIDICHVU"
                                           + " ) AA"
                                           + " GROUP BY DonGia,MADICHVU,TENDICHVU,DVT,MAKHOA,LOAIDICHVU ORDER BY TENDICHVU",
                                           GlobalModuls.Global.GetCode(cmbKhoa), LoaiDichVu, DieuKien, txtNgay.Value);

                }
                else
                {
                    Str = String.Format(" SET DATEFORMAT DMY SELECT 0 AS DATHUCHIEN,MADICHVU,TENDICHVU,DVT,SUM(SOLUONG) AS SOLUONG,DonGia,MAKHOA,LOAIDICHVU,'' AS GHICHU FROM"
                                           + " (SELECT B.MADICHVU,DMDICHVU.TENDICHVU,DMDICHVU.DVT,SUM(B.SOLUONG) AS SOLUONG,B.DonGia,A.MAKHOA,DMDICHVU.LOAIDICHVU,'' AS GHICHU FROM"
                                           + " (BENHNHAN_PHIEUDIEUTRI A INNER JOIN PHIEUDIEUTRI_CHITIET B ON A.SOPHIEU = B.SOPHIEU)"
                                           + " INNER JOIN DMDICHVU ON DMDICHVU.MADICHVU = B.MADICHVU AND DMDICHVU.LOAIDICHVU = B.LOAIDICHVU"
                                           + " INNER JOIN VIEWKHOAHIENTAI K ON K.MAVAOVIEN = A.MAVAOVIEN AND K.MAKHOA = A.MAKHOA"
                                           + " WHERE K.VTRANGTHAI = 1 AND K.VDARAVIEN = 0 AND A.MAKHOA ='{0}' AND DMDICHVU.LOAIDICHVU IN {1} AND A.NHOM IN {2}" + (Global.GetCode(cmbNhomLenThuoc) == "0" ? " " : " AND B.MANHOM= " + Global.GetCode(cmbNhomLenThuoc))
                                           + " and a.ngaychidinh <= '{3:dd/MM/yyy HH:mm}'"
                                           + " GROUP BY B.DonGia,B.DATHUCHIEN,B.MADICHVU,DMDICHVU.TENDICHVU,DMDICHVU.DVT,A.MAKHOA,DMDICHVU.LOAIDICHVU"
                                           + " UNION ALL" //TRUONG HOP THU THUAT
                                           + " SELECT DMDICHVU.MADICHVU,DMDICHVU.TENDICHVU,DMDICHVU.DVT,SUM(A.SOLUONG) AS SOLUONG,A.DonGia,A.MAKHOA,DMDICHVU.LOAIDICHVU,'' AS GHICHU FROM"
                                           + " (CHIPHI_THUTHUAT A INNER JOIN DMDICHVU ON A.MACHIPHI = DMDICHVU.MADICHVU AND A.LOAIDICHVU = DMDICHVU.LOAIDICHVU)"
                                           + " INNER JOIN VIEWKHOAHIENTAI ON VIEWKHOAHIENTAI.MAVAOVIEN = A.MAVAOVIEN AND VIEWKHOAHIENTAI.MAKHOA = A.MAKHOA"
                                           + " WHERE VIEWKHOAHIENTAI.VTRANGTHAI = 1 AND VIEWKHOAHIENTAI.VDARAVIEN = 0 AND A.MAKHOA ='{0}' AND DMDICHVU.LOAIDICHVU IN {1} AND A.NHOM IN {2}" + (Global.GetCode(cmbNhomLenThuoc) == "0" ? " " : " AND A.MANHOM= " + Global.GetCode(cmbNhomLenThuoc))
                                           + " GROUP BY A.DonGia,A.DATHUCHIEN,DMDICHVU.MADICHVU,DMDICHVU.TENDICHVU,DMDICHVU.DVT,A.MAKHOA,DMDICHVU.LOAIDICHVU"
                                           + " ) AA"
                                           + " GROUP BY DonGia,MADICHVU,TENDICHVU,DVT,MAKHOA,LOAIDICHVU ORDER BY TENDICHVU",
                                           GlobalModuls.Global.GetCode(cmbKhoa), LoaiDichVu, DieuKien, txtNgay.Value);
                }


                // Son Sua

                //Str = String.Format("SELECT 0 AS DATHUCHIEN,MADICHVU,TENDICHVU,DVT,SUM(SOLUONG) AS SOLUONG,MAKHOA,LOAIDICHVU,'' AS GHICHU FROM"
                //       + " (SELECT B.MADICHVU,DMDICHVU.TENDICHVU,DMDICHVU.DVT,SUM(B.SOLUONG) AS SOLUONG,A.MAKHOA,DMDICHVU.LOAIDICHVU,'' AS GHICHU FROM"
                //       + " (BENHNHAN_PHIEUDIEUTRI A INNER JOIN PHIEUDIEUTRI_CHITIET B ON A.SOPHIEU = B.SOPHIEU)"
                //       + " INNER JOIN DMDICHVU ON DMDICHVU.MADICHVU = B.MADICHVU AND DMDICHVU.LOAIDICHVU = B.LOAIDICHVU"
                //       + " INNER JOIN VIEWKHOAHIENTAI K ON K.MAVAOVIEN = A.MAVAOVIEN AND K.MAKHOA = A.MAKHOA"
                //       + " WHERE K.VTRANGTHAI = 1 AND K.DATINHPHI = 0 AND A.MAKHOA ='{0}' AND DMDICHVU.LOAIDICHVU IN {1} AND A.NHOM IN {2}" + (Global.GetCode(cmbNhomLenThuoc) == "0" ? " " : " AND B.MANHOM= " + Global.GetCode(cmbNhomLenThuoc))
                //       + " GROUP BY B.DATHUCHIEN,B.MADICHVU,DMDICHVU.TENDICHVU,DMDICHVU.DVT,A.MAKHOA,DMDICHVU.LOAIDICHVU"
                //       + " UNION ALL" //TRUONG HOP THU THUAT
                //       + " SELECT DMDICHVU.MADICHVU,DMDICHVU.TENDICHVU,DMDICHVU.DVT,SUM(A.SOLUONG) AS SOLUONG,A.MAKHOA,DMDICHVU.LOAIDICHVU,'' AS GHICHU FROM"
                //       + " (CHIPHI_THUTHUAT A INNER JOIN DMDICHVU ON A.MACHIPHI = DMDICHVU.MADICHVU AND A.LOAIDICHVU = DMDICHVU.LOAIDICHVU)"
                //       + " INNER JOIN VIEWKHOAHIENTAI ON VIEWKHOAHIENTAI.MAVAOVIEN = A.MAVAOVIEN AND VIEWKHOAHIENTAI.MAKHOA = A.MAKHOA"
                //       + " WHERE VIEWKHOAHIENTAI.VTRANGTHAI = 1 AND VIEWKHOAHIENTAI.DATINHPHI = 0 AND A.MAKHOA ='{0}' AND DMDICHVU.LOAIDICHVU IN {1} AND A.NHOM IN {2}" + (Global.GetCode(cmbNhomLenThuoc) == "0" ? " " : " AND A.MANHOM= " + Global.GetCode(cmbNhomLenThuoc))
                //       + " GROUP BY A.DATHUCHIEN,DMDICHVU.MADICHVU,DMDICHVU.TENDICHVU,DMDICHVU.DVT,A.MAKHOA,DMDICHVU.LOAIDICHVU"
                //       + " ) AA"
                //       + " GROUP BY MADICHVU,TENDICHVU,DVT,MAKHOA,LOAIDICHVU ORDER BY TENDICHVU",
                //       GlobalModuls.Global.GetCode(cmbKhoa), LoaiDichVu, DieuKien, txtNgay.Value);

                // Het sua

                System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
                SQLCmd.CommandText = Str;
                SQLCmd.CommandTimeout = 0;
                System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(SQLCmd);
                System.Data.DataSet ds = new DataSet();
                ds.Clear();
                da.Fill(ds);
                fgDanhSach.ClipSeparators = "|;";
                fgDanhSach.Rows.Count = 1;
                fgDanhSach.Cols[3].DataType = typeof(decimal);
                fgDanhSach.Cols[3].Format = "#,##0.##";
                fgDanhSach.Cols[4].DataType = typeof(decimal);
                fgDanhSach.Cols[4].Format = "#,##0.##";

                foreach (System.Data.DataRow Row in ds.Tables[0].Rows)
                {
                    fgDanhSach.AddItem(String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}",
                        fgDanhSach.Rows.Count,
                        Row["MaDichVu"],
                        Row["TenDichVu"],
                        Row["SoLuong"],
                        Row["DonGia"],
                        Row["DVT"],
                        Row["GhiChu"]));
                }
                fgDanhSach[0, 0] = "Số TT";
                fgDanhSach[0, 1] = "Mã thuốc";
                fgDanhSach[0, 2] = "Tên thuốc";
                fgDanhSach[0, 3] = "Số lượng";
                fgDanhSach[0, 4] = "Đơn giá";
                fgDanhSach[0, 5] = "ĐVT";
                fgDanhSach[0, 6] = "Ghi chú";
                fgDanhSach.Cols[5].Visible = fgDanhSach.Cols[1].Visible = fgDanhSach.Cols[6].Visible = fgDanhSach.Cols[7].Visible = false;
                fgDanhSach.Cols[2].Visible = fgDanhSach.Cols[3].Visible = true;
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

            SQLCmd.Dispose();
            cmbKhoa.SelectedIndex = 0;
            if (cmbKhoa.ListCount == 1) cmbKhoa.SelectedIndex = 0;
            cmbNhom.AddItem("--------- Tất cả---------");
            cmbNhom.AddItem("Chi phí trong ngày");
            cmbNhom.AddItem("Chi phí bất thường");
            cmbNhom.SelectedIndex = 0;
            cmbLoaiDichVu.AddItem("Thuốc, hóa chất");
            cmbLoaiDichVu.AddItem("Thuốc đông y");
            cmbLoaiDichVu.SelectedIndex = 0;
            C1.Win.C1FlexGrid.CellStyle cs = fgDanhSach.Styles[C1.Win.C1FlexGrid.CellStyleEnum.Subtotal0];
            cs.BackColor = Color.LightBlue;
            cs.ForeColor = Color.DarkBlue;
            cmbKhoa.Tag = 1;
            cmbNhom.Tag = 1;
            txtNgay.Value = Global.GetNgayLV();
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
            //Str = String.Format("SELECT '' AS SOLUONGPHIEU,MADICHVU,TENDICHVU,DVT,ROUND(SUM(SOLUONG),0) AS SOLUONG,MAKHOA,LOAIDICHVU,'' AS GHICHU,KHOID FROM"
            //              + " (SELECT B.MADICHVU,DMDICHVU.TENDICHVU,DMDICHVU.DVT,SUM(B.SOLUONG) AS SOLUONG,A.MAKHOA,DMDICHVU.LOAIDICHVU,'' AS GHICHU,B.KHOID FROM"
            //              + " (BENHNHAN_PHIEUDIEUTRI A INNER JOIN PHIEUDIEUTRI_CHITIET B ON A.SOPHIEU = B.SOPHIEU)"
            //              + " INNER JOIN DMDICHVU ON DMDICHVU.MADICHVU = B.MADICHVU AND DMDICHVU.LOAIDICHVU = B.LOAIDICHVU"
            //              + " INNER JOIN VIEWKHOAHIENTAI ON VIEWKHOAHIENTAI.MAVAOVIEN = A.MAVAOVIEN AND VIEWKHOAHIENTAI.MAKHOA = A.MAKHOA"
            //              + " WHERE A.MAKHOA ='{0}' AND VIEWKHOAHIENTAI.VDARAVIEN = 0 AND VIEWKHOAHIENTAI.VTRANGTHAI = 1 AND B.LOAIDICHVU='D01'" + (Global.GetCode(cmbNhomLenThuoc) == "0" ? " " : " AND B.MANHOM= " + Global.GetCode(cmbNhomLenThuoc))
            //              + " GROUP BY B.MADICHVU,DMDICHVU.TENDICHVU,DMDICHVU.DVT,A.MAKHOA,DMDICHVU.LOAIDICHVU,B.KHOID"
            //              + " UNION ALL" //TRUONG HOP THU THUAT
            //              + " SELECT DMDICHVU.MADICHVU,DMDICHVU.TENDICHVU,DMDICHVU.DVT,SUM(A.SOLUONG) AS SOLUONG,A.MAKHOA,DMDICHVU.LOAIDICHVU,'' AS GHICHU,A.KHOID FROM"
            //              + " (CHIPHI_THUTHUAT A INNER JOIN DMDICHVU ON A.MACHIPHI = DMDICHVU.MADICHVU AND A.LOAIDICHVU = DMDICHVU.LOAIDICHVU)"
            //              + " INNER JOIN VIEWKHOAHIENTAI ON VIEWKHOAHIENTAI.MAVAOVIEN = A.MAVAOVIEN AND VIEWKHOAHIENTAI.MAKHOA = A.MAKHOA"
            //              + " WHERE VIEWKHOAHIENTAI.VDARAVIEN = 0 AND VIEWKHOAHIENTAI.VTRANGTHAI = 1 AND A.MAKHOA ='{0}' AND A.LOAIDICHVU='D01'" + (Global.GetCode(cmbNhomLenThuoc) == "0" ? " " : " AND A.MANHOM= " + Global.GetCode(cmbNhomLenThuoc))
            //              + " GROUP BY DMDICHVU.MADICHVU,DMDICHVU.TENDICHVU,DMDICHVU.DVT,A.MAKHOA,DMDICHVU.LOAIDICHVU,A.KHOID"
            //              + " ) AA",
            //              GlobalModuls.Global.GetCode(cmbKhoa),txtNgay.Value);

            // SON SUA

            if(chkNgayChot.Checked == false)
            {
                Str = String.Format("SELECT '' AS SOLUONGPHIEU,MADICHVU,TENDICHVU,DVT,SUM(SOLUONG) AS SOLUONG,MAKHOA,LOAIDICHVU,'' AS GHICHU,KHOID FROM"
                         + " (SELECT B.MADICHVU,DMDICHVU.TENDICHVU,DMDICHVU.DVT,SUM(B.SOLUONG) AS SOLUONG,A.MAKHOA,DMDICHVU.LOAIDICHVU,'' AS GHICHU,B.KHOID FROM"
                         + " (BENHNHAN_PHIEUDIEUTRI A INNER JOIN PHIEUDIEUTRI_CHITIET B ON A.SOPHIEU = B.SOPHIEU)"
                         + " INNER JOIN DMDICHVU ON DMDICHVU.MADICHVU = B.MADICHVU AND DMDICHVU.LOAIDICHVU = B.LOAIDICHVU"
                         + " INNER JOIN VIEWKHOAHIENTAI ON VIEWKHOAHIENTAI.MAVAOVIEN = A.MAVAOVIEN AND VIEWKHOAHIENTAI.MAKHOA = A.MAKHOA"
                         + " WHERE A.MAKHOA ='{0}' AND VIEWKHOAHIENTAI.VDARAVIEN = 0 AND VIEWKHOAHIENTAI.VTRANGTHAI = 1 AND B.LOAIDICHVU='D01'" + (Global.GetCode(cmbNhomLenThuoc) == "0" ? " " : " AND B.MANHOM= " + Global.GetCode(cmbNhomLenThuoc))
                         + " GROUP BY B.MADICHVU,DMDICHVU.TENDICHVU,DMDICHVU.DVT,A.MAKHOA,DMDICHVU.LOAIDICHVU,B.KHOID"
                         //+ " UNION ALL " //TRUONG HOP O PHONG KHAM
                         //+ " SELECT DMDICHVU.MADICHVU,DMDICHVU.TENDICHVU,DMDICHVU.DVT,SUM(A.SOLUONG) AS SOLUONG,A.MAKHOATHUCHIEN AS MAKHOA,DMDICHVU.LOAIDICHVU,'' AS GHICHU,A.KHOID"
                         //+ " FROM"
                         //+ " (NAMDINH_KHAMBENH.DBO.tblCHIPHI_DICHVU A INNER JOIN DMDICHVU ON A.MACHIPHI = DMDICHVU.MADICHVU AND A.LOAICHIPHI = DMDICHVU.LOAIDICHVU)"
                         //+ " WHERE cast(RIGHT(A.MAPHIEUDUYET,9) as bigint) >= {1} AND cast(RIGHT(A.MAPHIEUDUYET,9)as bigint) <= {2} AND A.MAKHOATHUCHIEN ='{0}'" + (Global.GetCode(cmbNhomLenThuoc) == "0" ? "" : " AND A.MANHOM = " + Global.GetCode(cmbNhomLenThuoc))
                         //+ " GROUP BY DMDICHVU.MADICHVU,DMDICHVU.TENDICHVU,DMDICHVU.DVT,A.MAKHOATHUCHIEN,DMDICHVU.LOAIDICHVU,A.KHOID"
                         + " UNION ALL" //TRUONG HOP THU THUAT
                         + " SELECT DMDICHVU.MADICHVU,DMDICHVU.TENDICHVU,DMDICHVU.DVT,SUM(A.SOLUONG) AS SOLUONG,A.MAKHOA,DMDICHVU.LOAIDICHVU,'' AS GHICHU,A.KHOID FROM"
                         + " (CHIPHI_THUTHUAT A INNER JOIN DMDICHVU ON A.MACHIPHI = DMDICHVU.MADICHVU AND A.LOAIDICHVU = DMDICHVU.LOAIDICHVU)"
                         + " INNER JOIN VIEWKHOAHIENTAI ON VIEWKHOAHIENTAI.MAVAOVIEN = A.MAVAOVIEN AND VIEWKHOAHIENTAI.MAKHOA = A.MAKHOA"
                         + " WHERE VIEWKHOAHIENTAI.VDARAVIEN = 0 AND VIEWKHOAHIENTAI.VTRANGTHAI = 1 AND A.MAKHOA ='{0}' AND A.LOAIDICHVU='D01'" + (Global.GetCode(cmbNhomLenThuoc) == "0" ? " " : " AND A.MANHOM= " + Global.GetCode(cmbNhomLenThuoc))
                         + " GROUP BY DMDICHVU.MADICHVU,DMDICHVU.TENDICHVU,DMDICHVU.DVT,A.MAKHOA,DMDICHVU.LOAIDICHVU,A.KHOID"
                         + " ) AA",
                         GlobalModuls.Global.GetCode(cmbKhoa), txtNgay.Value);
                // HET SUA
                if (raDieuTriThuong.Checked)
                {
                    Str += " WHERE AA.MADICHVU NOT LIKE 'NGHT%' AND AA.MADICHVU NOT LIKE 'DY-DY' AND AA.MADICHVU NOT LIKE 'VT-VA%' GROUP BY MADICHVU,TENDICHVU,DVT,MAKHOA,LOAIDICHVU,KHOID ORDER BY KHOID,TENDICHVU";
                }
                else if (raThuocHT.Checked)
                {
                    Str += " WHERE AA.MADICHVU LIKE 'NGHT%' GROUP BY MADICHVU,TENDICHVU,DVT,MAKHOA,LOAIDICHVU,KHOID ORDER BY KHOID,TENDICHVU";
                }
                else if (raThuocDongY.Checked)
                {
                    Str += " WHERE AA.MADICHVU LIKE 'DY-DY%' GROUP BY MADICHVU,TENDICHVU,DVT,MAKHOA,LOAIDICHVU,KHOID ORDER BY KHOID,TENDICHVU";
                }
            }
            else
            {
                Str = String.Format("SELECT '' AS SOLUONGPHIEU,MADICHVU,TENDICHVU,DVT,SUM(SOLUONG) AS SOLUONG,MAKHOA,LOAIDICHVU,'' AS GHICHU,KHOID FROM"
                         + " (SELECT B.MADICHVU,DMDICHVU.TENDICHVU,DMDICHVU.DVT,SUM(B.SOLUONG) AS SOLUONG,A.MAKHOA,DMDICHVU.LOAIDICHVU,'' AS GHICHU,B.KHOID FROM"
                         + " (BENHNHAN_PHIEUDIEUTRI A INNER JOIN PHIEUDIEUTRI_CHITIET B ON A.SOPHIEU = B.SOPHIEU)"
                         + " INNER JOIN DMDICHVU ON DMDICHVU.MADICHVU = B.MADICHVU AND DMDICHVU.LOAIDICHVU = B.LOAIDICHVU"
                         + " INNER JOIN VIEWKHOAHIENTAI ON VIEWKHOAHIENTAI.MAVAOVIEN = A.MAVAOVIEN AND VIEWKHOAHIENTAI.MAKHOA = A.MAKHOA"
                         + " WHERE a.ngaychidinh <= '{1:dd/MM/yyy HH:mm}' and A.MAKHOA ='{0}' AND VIEWKHOAHIENTAI.VDARAVIEN = 0 AND VIEWKHOAHIENTAI.VTRANGTHAI = 1 AND B.LOAIDICHVU='D01'" + (Global.GetCode(cmbNhomLenThuoc) == "0" ? " " : " AND B.MANHOM= " + Global.GetCode(cmbNhomLenThuoc))
                         + " GROUP BY B.MADICHVU,DMDICHVU.TENDICHVU,DMDICHVU.DVT,A.MAKHOA,DMDICHVU.LOAIDICHVU,B.KHOID"
                         //+ " UNION ALL " //TRUONG HOP O PHONG KHAM
                         //+ " SELECT DMDICHVU.MADICHVU,DMDICHVU.TENDICHVU,DMDICHVU.DVT,SUM(A.SOLUONG) AS SOLUONG,A.MAKHOATHUCHIEN AS MAKHOA,DMDICHVU.LOAIDICHVU,'' AS GHICHU,A.KHOID"
                         //+ " FROM"
                         //+ " (NAMDINH_KHAMBENH.DBO.tblCHIPHI_DICHVU A INNER JOIN DMDICHVU ON A.MACHIPHI = DMDICHVU.MADICHVU AND A.LOAICHIPHI = DMDICHVU.LOAIDICHVU)"
                         //+ " WHERE cast(RIGHT(A.MAPHIEUDUYET,9) as bigint) >= {1} AND cast(RIGHT(A.MAPHIEUDUYET,9)as bigint) <= {2} AND A.MAKHOATHUCHIEN ='{0}'" + (Global.GetCode(cmbNhomLenThuoc) == "0" ? "" : " AND A.MANHOM = " + Global.GetCode(cmbNhomLenThuoc))
                         //+ " GROUP BY DMDICHVU.MADICHVU,DMDICHVU.TENDICHVU,DMDICHVU.DVT,A.MAKHOATHUCHIEN,DMDICHVU.LOAIDICHVU,A.KHOID"
                         + " UNION ALL" //TRUONG HOP THU THUAT
                         + " SELECT DMDICHVU.MADICHVU,DMDICHVU.TENDICHVU,DMDICHVU.DVT,SUM(A.SOLUONG) AS SOLUONG,A.MAKHOA,DMDICHVU.LOAIDICHVU,'' AS GHICHU,A.KHOID FROM"
                         + " (CHIPHI_THUTHUAT A INNER JOIN DMDICHVU ON A.MACHIPHI = DMDICHVU.MADICHVU AND A.LOAIDICHVU = DMDICHVU.LOAIDICHVU)"
                         + " INNER JOIN VIEWKHOAHIENTAI ON VIEWKHOAHIENTAI.MAVAOVIEN = A.MAVAOVIEN AND VIEWKHOAHIENTAI.MAKHOA = A.MAKHOA"
                         + " WHERE VIEWKHOAHIENTAI.VDARAVIEN = 0 AND VIEWKHOAHIENTAI.VTRANGTHAI = 1 AND A.MAKHOA ='{0}' AND A.LOAIDICHVU='D01'" + (Global.GetCode(cmbNhomLenThuoc) == "0" ? " " : " AND A.MANHOM= " + Global.GetCode(cmbNhomLenThuoc))
                         + " GROUP BY DMDICHVU.MADICHVU,DMDICHVU.TENDICHVU,DMDICHVU.DVT,A.MAKHOA,DMDICHVU.LOAIDICHVU,A.KHOID"
                         + " ) AA",
                         GlobalModuls.Global.GetCode(cmbKhoa), txtNgay.Value);
                // HET SUA
                if (raDieuTriThuong.Checked)
                {
                    Str += " WHERE AA.MADICHVU NOT LIKE 'NGHT%' AND AA.MADICHVU NOT LIKE 'DY-DY' AND AA.MADICHVU NOT LIKE 'VT-VA%' GROUP BY MADICHVU,TENDICHVU,DVT,MAKHOA,LOAIDICHVU,KHOID ORDER BY KHOID,TENDICHVU";
                }
                else if (raThuocHT.Checked)
                {
                    Str += " WHERE AA.MADICHVU LIKE 'NGHT%' GROUP BY MADICHVU,TENDICHVU,DVT,MAKHOA,LOAIDICHVU,KHOID ORDER BY KHOID,TENDICHVU";
                }
                else if (raThuocDongY.Checked)
                {
                    Str += " WHERE AA.MADICHVU LIKE 'DY-DY%' GROUP BY MADICHVU,TENDICHVU,DVT,MAKHOA,LOAIDICHVU,KHOID ORDER BY KHOID,TENDICHVU";
                }
            }
            SQLCmd.CommandText = Str;
            SQLCmd.CommandTimeout = 0;
            System.Data.SqlClient.SqlDataReader dr = SQLCmd.ExecuteReader();
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
        private void cmdTongHop_Click(object sender, EventArgs e)
        {
            if (cmbKhoa.SelectedIndex == -1)
            {
                MessageBox.Show("Chưa chọn Khoa điều trị!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cmbKhoa.Focus();
                return;
            }
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

        private void chkNgayChot_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNgayChot.Checked == true)
                txtNgay.Enabled = true;
            else
                txtNgay.Enabled = false;
        }
    }
}