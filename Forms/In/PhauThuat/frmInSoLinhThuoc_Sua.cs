using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using GlobalModuls;

namespace NamDinh_QLBN.Forms.In.PhauThuat
{
    public partial class frmInSoLinhThuoc_Sua : Form
    {
        public frmInSoLinhThuoc_Sua()
        {
            InitializeComponent();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormatGrid()
        {
            Global.wait("Đang cập nhật dữ liệu");
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            try
            {
                SQLCmd.CommandText = String.Format("set dateformat dmy SELECT * FROM SOTHUOC "
                    + " INNER JOIN [" + Global.glbDuoc + "].DBO.DANHMUCTHUOC A ON A.THUOCID = SOTHUOC.MATHUOC "
                    + " INNER JOIN SACLAPPHIEU ON SACLAPPHIEU.LOAITHUOC = SOTHUOC.LOAITHUOC "
                    + " inner join  "
                    + " (SELECT * FROM BENHNHAN_PT_CHIPHI WHERE DATEDIFF(DD,NGAYCHIDINH,'{0:dd/MM/yyyy}') = 0) CC ON CC.MaDichVu = SoThuoc.MaThuoc "
                    + " WHERE ",txtNgayChiDinh.Value);
                SQLCmd.CommandText += String.Format(" SACLAPPHIEU.MaKhoa = '{0}' and SoThuoc.MaKhoa ='{0}'  ", Global.GetCode(cmbKhoa));
                if (raTaCa.Checked)
                {
                }
                else
                {
                    if (raThuocOng.Checked)
                    {
                        SQLCmd.CommandText += " and SACLAPPHIEU.NhomSO = 0 ";
                    }
                    else
                    {
                        SQLCmd.CommandText += " and SACLAPPHIEU.NhomSO = 1 ";
                    }
                }
                SQLCmd.CommandText += " Order by STT";
                

                dr = SQLCmd.ExecuteReader();
                fgDanhSach.Cols.Count = 7;
                fgDanhSach.Rows.Count = 1;
                for (int i = fgDanhSach.Cols["Tuoi"].Index + 1; i <= 40; i++)
                {
                    fgDanhSach.Cols.Add();
                    fgDanhSach.Cols[fgDanhSach.Cols.Count - 1].Width = 10;
                }
                fgDanhSach.Cols.Add();
                fgDanhSach.Cols[fgDanhSach.Cols.Count - 1].Name = "GhiChu";
                fgDanhSach[0, "GhiChu"] = "Ghi chú";
                int j = fgDanhSach.Cols["Tuoi"].Index + 1;
                while (dr.Read())
                {
                    if (j == 41) break;
                    fgDanhSach.Cols[j].Name = dr["MaThuoc"].ToString();
                    fgDanhSach[0, j] = dr["TenThuoc"];
                    j++;
                }
                dr.Close();
                C1.Win.C1FlexGrid.CellStyle cs = fgDanhSach.Styles[C1.Win.C1FlexGrid.CellStyleEnum.Subtotal0];
                cs.BackColor = Color.LightBlue;
                cs.ForeColor = Color.DarkBlue;
                fgDanhSach.Tree.Column = fgDanhSach.Cols["TenBenhNhan"].Index;
                SQLCmd.CommandText = String.Format("set dateformat dmy  SELECT ISNULL(C.MAPHIEUDUYET,'') AS MAPHIEUDUYET,N'Chi phí bất thường' AS NHOM1,1 AS NHOM,B.MAVAOVIEN,A.HOTEN,YEAR(C.NGAYCHIDINH) - A.NAMSINH AS TUOI FROM"
                    + " (BENHNHAN A INNER JOIN BENHNHAN_CHITIET B ON A.MABENHNHAN = B.MABENHNHAN)"
                    + " INNER JOIN BENHNHAN_PT_CHIPHI C ON C.MAVAOVIEN = B.MAVAOVIEN"
                    + " WHERE DATEDIFF(DD,C.NGAYCHIDINH,'{0:dd/MM/yyyy}') = 0"
                    + " GROUP BY C.MAPHIEUDUYET,B.MAVAOVIEN,A.HOTEN,C.NGAYCHIDINH,A.NAMSINH"
                    + " ORDER BY RIGHT(C.MAPHIEUDUYET,3) DESC ",txtNgayChiDinh.Value);
                dr = SQLCmd.ExecuteReader();
                while (dr.Read())
                {
                    fgDanhSach.Rows.Add();
                    fgDanhSach[fgDanhSach.Rows.Count - 1, "MaPhieuDuyet"] = dr["MaPhieuDuyet"];
                    fgDanhSach[fgDanhSach.Rows.Count - 1, "Nhom"] = dr["Nhom"];
                    fgDanhSach[fgDanhSach.Rows.Count - 1, "Nhom1"] = dr["Nhom1"];
                    fgDanhSach[fgDanhSach.Rows.Count - 1, "STT"] = fgDanhSach.Rows.Count - 1;
                    fgDanhSach[fgDanhSach.Rows.Count - 1, "MaVaoVien"] = dr["MaVaoVien"];
                    fgDanhSach[fgDanhSach.Rows.Count - 1, "TenBenhNhan"] = dr["HoTen"];
                    fgDanhSach[fgDanhSach.Rows.Count - 1, "Tuoi"] = dr["Tuoi"];
                }
                fgDanhSach.AutoResize = true;
                fgDanhSach.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.Clear, 0, 0, 0);
                fgDanhSach.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.None, 0, 1, 1, "{0}");
                fgDanhSach.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.None, 1, 3, 1, "{0}");
                dr.Close();
                Global.nowait();
            }
            catch (Exception ex)
            {
                Global.nowait();
                MessageBox.Show("Lỗi: " + ex.ToString(), "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                SQLCmd.Dispose();
            }
        }

        private void GetData()
        {
            Global.wait("Đang cập nhật dữ liệu");
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            try
            {
                SQLCmd.CommandText = String.Format("set dateformat dmy SELECT C.MAVAOVIEN,ISNULL(C.MAPHIEUDUYET,'') AS MAPHIEUDUYET,DMDICHVU.MADICHVU,SUM(C.SOLUONG) AS SOLUONG,1 AS NHOM,DMDICHVU.TENDICHVU AS TENTHUOC FROM"
                    + " (BENHNHAN A INNER JOIN BENHNHAN_CHITIET B ON A.MABENHNHAN = B.MABENHNHAN)"
                    + " INNER JOIN BENHNHAN_PT_CHIPHI C ON C.MAVAOVIEN = B.MAVAOVIEN"
                    + " INNER JOIN DMDICHVU ON DMDICHVU.MADICHVU = C.MADICHVU"
                    + " INNER JOIN SACLAPPHIEU ON SACLAPPHIEU.LOAITHUOC = DMDICHVU.LOAITHUOC"
                    + " WHERE DATEDIFF(DD,C.NGAYCHIDINH,'{0:dd/MM/yyyy}') = 0 AND C.LOAICHIPHI IN ('D01')",
                    txtNgayChiDinh.Value);
                if (raTaCa.Checked)
                {
                    SQLCmd.CommandText += String.Format(" AND SACLAPPHIEU.NHOMSO <> -1 AND SACLAPPHIEU.MAKHOA='{0}'", Global.GetCode(cmbKhoa));
                }
                else
                {
                    if (raThuocOng.Checked)
                    {
                        SQLCmd.CommandText += String.Format(" AND SACLAPPHIEU.NHOMSO = 0 AND  SACLAPPHIEU.NHOMSO <> -1 AND SACLAPPHIEU.MAKHOA='{0}'", Global.GetCode(cmbKhoa));
                    }
                    else
                    {
                        SQLCmd.CommandText += String.Format(" AND SACLAPPHIEU.NHOMSO = 1 AND  SACLAPPHIEU.NHOMSO <> -1 AND SACLAPPHIEU.MAKHOA='{0}'", Global.GetCode(cmbKhoa));
                    }
                }
                SQLCmd.CommandText += " GROUP BY C.MAPHIEUDUYET,B.MAVAOVIEN,C.NGAYCHIDINH,DMDICHVU.TENDICHVU,DMDICHVU.MADICHVU,C.MAVAOVIEN";

                dr = SQLCmd.ExecuteReader();
                bool DaCo = false;
                while (dr.Read())
                {
                    for (int i = 1; i < fgDanhSach.Rows.Count; i++)
                    {
                        if (fgDanhSach.GetDataDisplay(i, "MaVaoVien") == dr["MaVaoVien"].ToString() && fgDanhSach.GetDataDisplay(i, "Nhom") == dr["Nhom"].ToString() && fgDanhSach.GetDataDisplay(i, "MAPHIEUDUYET") == dr["MAPHIEUDUYET"].ToString())
                        {
                            for (int j = fgDanhSach.Cols["Tuoi"].Index + 1; j < fgDanhSach.Cols["GhiChu"].Index; j++)
                            {
                                if (fgDanhSach.Cols[j].Name == dr["MaDichVu"].ToString())
                                {
                                    fgDanhSach[i, j] = String.Format("{0:#,##0.##}", dr["SoLuong"]);
                                    DaCo = true;
                                    break;
                                }
                            }
                            if (!DaCo)
                            {
                                if (fgDanhSach[i, "GhiChu"] == null)
                                {
                                    fgDanhSach[i, "GhiChu"] = (object)(dr["TenThuoc"] + ": " + String.Format("{0:#,##0.##}", dr["SoLuong"])); 
                                }
                                else
                                {
                                    fgDanhSach[i, "GhiChu"] = (object)(fgDanhSach[i, "GhiChu"].ToString() + ". " + dr["TenThuoc"] + ": " + String.Format("{0:#,##0.##}", dr["SoLuong"])); 
                                }
                            }
                            DaCo = false;
                            break;
                        }
                    }
                }
                dr.Close();
                fgDanhSach.AutoSizeCols(1, fgDanhSach.Cols.Count - 1, 0);
                fgDanhSach.Rows.Add();
                fgDanhSach.Rows[fgDanhSach.Rows.Count - 1].StyleNew.BackColor = System.Drawing.Color.Bisque;
                fgDanhSach[fgDanhSach.Rows.Count - 1, "TenBenhNhan"] = "TỔNG";
                for (int _Col = fgDanhSach.Cols["Tuoi"].Index + 1; _Col < fgDanhSach.Cols["GhiChu"].Index; _Col++)
                {
                    for (int _Row = 1; _Row < fgDanhSach.Rows.Count -1; _Row++)
                    {
                        if (fgDanhSach.Rows[_Row].IsNode) continue;
                        if (fgDanhSach.GetDataDisplay(_Row, _Col) != "")
                        {
                            if (fgDanhSach.GetDataDisplay(fgDanhSach.Rows.Count - 1, _Col) == "")
                            {
                                fgDanhSach[fgDanhSach.Rows.Count - 1, _Col] = decimal.Parse(fgDanhSach[_Row, _Col].ToString());
                            }
                            else
                            {
                                fgDanhSach[fgDanhSach.Rows.Count - 1, _Col] = decimal.Parse(fgDanhSach[fgDanhSach.Rows.Count - 1, _Col].ToString()) + Decimal.Parse(fgDanhSach[_Row, _Col].ToString());
                            }
                        }
                    }
                }
                Global.nowait();
            }
            catch (Exception ex)
            {
                Global.nowait();
                MessageBox.Show("Lỗi: " + ex.ToString(), "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                SQLCmd.Dispose();
            }
        }
        private void frmInSoLinhThuoc_Load(object sender, EventArgs e)
        {
            fgDanhSach.Tag = 0;
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            SQLCmd.CommandText = "SELECT * FROM DMKHOAPHONG WHERE Len(MaKHoa)>1 AND MaKhoa IN " + Global.glbKhoa_CapNhat;
            dr = SQLCmd.ExecuteReader();
            cmbKhoa.Tag = 0;
            cmbKhoa.ClearItems();
            while (dr.Read())
            {
                cmbKhoa.AddItem(string.Format("{0};{1}", dr["MaKhoa"], dr["TenKhoa"]));
            }
            cmbKhoa.SelectedIndex = 0;
            dr.Close();

            SQLCmd.CommandText = "SELECT MaNhom,TenNhom FROM NAMDINH_QLBN.dbo.Khoa_Nhom where MaKhoa = 'NV1103'";
            dr = SQLCmd.ExecuteReader();
            cmbNhom_Khoa.Tag = 0;
            cmbNhom_Khoa.ClearItems();
            while (dr.Read())
            {
                cmbNhom_Khoa.AddItem(string.Format("{0};{1}", dr["MaNhom"], dr["TenNhom"]));
            }
            cmbNhom_Khoa.SelectedIndex = -1;
            dr.Close();

            SQLCmd.Dispose();
            txtNgayChiDinh.Value = Global.NgayLV;
            FormatGrid();
            GetData();
            fgDanhSach.Tag = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (fgDanhSach.Rows.Count <= 1) return;
            if (fgDanhSach.GetDataDisplay(fgDanhSach.Row, "MaPhieuDuyet") == "")
            {
                MessageBox.Show("Chọn một bệnh nhân trong sổ cần in", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (raTaCa.Checked)
            {
                NamDinh_QLBN.Reports.PhauThuat.repSoLenThuoc_Sua rpt = new NamDinh_QLBN.Reports.PhauThuat.repSoLenThuoc_Sua(Global.GetCode(cmbKhoa),
                       -1, txtNgayChiDinh.Value, cmbKhoa.Text, fgDanhSach.GetDataDisplay(fgDanhSach.Row, "MaPhieuDuyet"));
                rpt.Show();
            }
            else
            {
                NamDinh_QLBN.Reports.PhauThuat.repSoLenThuoc_Sua rpt = new NamDinh_QLBN.Reports.PhauThuat.repSoLenThuoc_Sua(Global.GetCode(cmbKhoa),
                    raThuocOng.Checked == true ? 0 : 1, txtNgayChiDinh.Value, cmbKhoa.Text, fgDanhSach.GetDataDisplay(fgDanhSach.Row, "MaPhieuDuyet"));
                rpt.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void raThuocVien_CheckedChanged(object sender, EventArgs e)
        {
            fgDanhSach.Tag = 0;
            FormatGrid();
            GetData();
            fgDanhSach.Tag = 1;
        }

        private void txtNgayChiDinh_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNgayChiDinh_ValueChanged(object sender, EventArgs e)
        {
            if (fgDanhSach.Tag.ToString() == "0") return;
            fgDanhSach.Tag = 0;
            FormatGrid();
            GetData();
            fgDanhSach.Tag = 1;
        }

        private void raThuocOng_CheckedChanged(object sender, EventArgs e)
        {
            fgDanhSach.Tag = 0;
            FormatGrid();
            GetData();
            fgDanhSach.Tag = 1;
        }

        private void raTaCa_CheckedChanged(object sender, EventArgs e)
        {
            fgDanhSach.Tag = 0;
            FormatGrid();
            GetData();
            fgDanhSach.Tag = 1;
        }

        private void txtNgayChiDinh_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void cmbNhomLenCP_TextChanged(object sender, EventArgs e)
        {
            if (fgDanhSach.Tag.ToString() == "0") return;
            fgDanhSach.Tag = 0;
            FormatGrid();
            GetData();
            fgDanhSach.Tag = 1;
        }

        private void btnNhom_khoa_Click(object sender, EventArgs e)
        {
            if (fgDanhSach.Rows.Count <= 1) return;
            if (fgDanhSach.GetDataDisplay(fgDanhSach.Row, "MaPhieuDuyet") == "")
            {
                MessageBox.Show("Chọn một bệnh nhân trong sổ cần in", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (raTaCa.Checked)
            {
                NamDinh_QLBN.Reports.PhauThuat.repSoLenThuoc_ByKhoa rpt = new NamDinh_QLBN.Reports.PhauThuat.repSoLenThuoc_ByKhoa(Global.GetCode(cmbKhoa),
                       -1, txtNgayChiDinh.Value, cmbKhoa.Text, fgDanhSach.GetDataDisplay(fgDanhSach.Row, "MaPhieuDuyet"), Global.GetCode(cmbNhom_Khoa),cmbNhom_Khoa.Text);
                rpt.Show();
            }
            else
            {
                NamDinh_QLBN.Reports.PhauThuat.repSoLenThuoc_ByKhoa rpt = new NamDinh_QLBN.Reports.PhauThuat.repSoLenThuoc_ByKhoa(Global.GetCode(cmbKhoa),
                    raThuocOng.Checked == true ? 0 : 1, txtNgayChiDinh.Value, cmbKhoa.Text, fgDanhSach.GetDataDisplay(fgDanhSach.Row, "MaPhieuDuyet"), Global.GetCode(cmbNhom_Khoa), cmbNhom_Khoa.Text);
                rpt.Show();
            }
        }
    }
}