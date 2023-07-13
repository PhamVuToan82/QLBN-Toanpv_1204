using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using GlobalModuls;

namespace NamDinh_QLBN.Forms.In
{
    public partial class frmInSoLinhThuoc_SuaOKhoaDongY : Form
    {
        public frmInSoLinhThuoc_SuaOKhoaDongY()
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
                //SQLCmd.CommandText = String.Format("set dateformat dmy SELECT * FROM SOTHUOC "
                //    + " INNER JOIN [" + Global.glbDuoc + "].DBO.DANHMUCTHUOC A ON A.THUOCID = SOTHUOC.MATHUOC "
                //    + " INNER JOIN SACLAPPHIEU ON SACLAPPHIEU.LOAITHUOC = SOTHUOC.LOAITHUOC "
                //    + " inner join  "
                //    + " (select * from"
                //    + " (Select ct.MaDichVU from  (select SoPhieu from benhnhan_phieudieutri where makhoa = '{0}' and datediff(dd,NgayChiDinh,'{1:dd/MM/yyyy}') = 0) aa "
                //    + " inner join phieudieutri_chitiet ct on  ct.SoPhieu = aa.SoPhieu  "
                //    + " where ct.LoaiDichVu in ('D01','D05')  and ct.MaNhom= " + Global.GetCode(cmbNhomLenCP)
                //    + " union  all"
                //    + " select machiphi as Madichvu from chiphi_thuthuat where datediff(dd,NgayThucHien,'{1:dd/MM/yyyy}') = 0 and loaidichvu  in ('D01','D05')  and makhoa='{0}' and MaNhom = " + Global.GetCode(cmbNhomLenCP) + ") bb"
                //    + " group by MaDichvu) cc on cc.madichvu = SoThuoc.MaThuoc "
                //    + " WHERE ",Global.GetCode(cmbKhoa),txtNgayChiDinh.Value);
                //SQLCmd.CommandText += String.Format(" SACLAPPHIEU.makhoa = '{0}' and SoThuoc.MaKHoa ='{0}'  ", Global.GetCode(cmbKhoa));
                  SQLCmd.CommandText = String.Format("set dateformat dmy SELECT * FROM  "
                        + " [" + Global.glbDuoc + "].DBO.DANHMUCTHUOC A  "
                        + " INNER JOIN SACLAPPHIEU ON SACLAPPHIEU.LOAITHUOC = a.LOAITHUOC"
                        + " inner join  "
                        + " (select * from"
                        + " (Select ct.MaDichVU from  (select SoPhieu from benhnhan_phieudieutri where makhoa = '{0}' and datediff(dd,NgayChiDinh,'{1:dd/MM/yyyy}') = 0) aa "
                        + " inner join phieudieutri_chitiet ct on  ct.SoPhieu = aa.SoPhieu  "
                        + " where ct.LoaiDichVu in ('D05')  and ct.MaNhom= " + Global.GetCode(cmbNhomLenCP)
                        + " union  all"
                        + " select machiphi as Madichvu from chiphi_thuthuat where datediff(dd,NgayThucHien,'{1:dd/MM/yyyy}') = 0 and loaidichvu  in ('D05')  and makhoa='{0}' and MaNhom = " + Global.GetCode(cmbNhomLenCP) + ") bb"
                        + " group by MaDichvu) cc on cc.madichvu = a.ThuocID "
                        + " WHERE ", Global.GetCode(cmbKhoa), txtNgayChiDinh.Value);
                SQLCmd.CommandText += String.Format(" SACLAPPHIEU.makhoa = '{0}' ", Global.GetCode(cmbKhoa));
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
                SQLCmd.CommandText += " order by A.TenThuoc";
                

                dr = SQLCmd.ExecuteReader();
                fgDanhSach.Cols.Count = 8;
                fgDanhSach.Rows.Count = 1;
                for (int i = fgDanhSach.Cols["ThuocDY"].Index + 1; i <= 40; i++)
                {
                    fgDanhSach.Cols.Add();
                    fgDanhSach.Cols[fgDanhSach.Cols.Count - 1].Width = 10;
                }
                fgDanhSach.Cols.Add();
                fgDanhSach.Cols[fgDanhSach.Cols.Count - 1].Name = "GhiChu";
                fgDanhSach[0, "GhiChu"] = "Ghi chú";
                int j = fgDanhSach.Cols["ThuocDY"].Index + 1;
                while (dr.Read())
                {
                    if (j == 41) break;
                    fgDanhSach.Cols[j].Name = dr["ThuocID"].ToString();
                    fgDanhSach[0, j] = dr["TenThuoc"];
                    j++;
                }
                dr.Close();
                C1.Win.C1FlexGrid.CellStyle cs = fgDanhSach.Styles[C1.Win.C1FlexGrid.CellStyleEnum.Subtotal0];
                cs.BackColor = Color.LightBlue;
                cs.ForeColor = Color.DarkBlue;
                fgDanhSach.Tree.Column = fgDanhSach.Cols["TenBenhNhan"].Index;
                SQLCmd.CommandText = String.Format("set dateformat dmy  Select * from"
                    + " (SELECT ct.MaPhieuDuyet,DD.MAVAOVIEN,DD.HOTEN,DD.TUOI,DMBUONGBENH.TENBUONG,dd.nhom,CASE WHEN DD.NHOM = 0 THEN N'Chi phí trong ngày' else N'Chi phí bất thường' end as Nhom1 FROM  "
                    + " (SELECT CC.*,BN.SOPHIEU,BN.NGAYCHIDINH,BN.NHOM FROM "
                    + " (SELECT BB.MAVAOVIEN,AA.HOTEN,YEAR(GETDATE()) - NAMSINH AS TUOI,BB.BUONG FROM "
                    + " (SELECT * FROM BENHNHAN) AA INNER JOIN BENHNHAN_CHITIET BB ON BB.MABENHNHAN = AA.MABENHNHAN) CC "
                    + " INNER JOIN BENHNHAN_PHIEUDIEUTRI BN ON BN.MAVAOVIEN = CC.MAVAOVIEN "
                    + " WHERE MAKHOA ='{0}' AND DATEDIFF(DD,NGAYCHIDINH,'{1:dd/MM/yyyy}') = 0) DD "
                    + " INNER JOIN PHIEUDIEUTRI_CHITIET CT ON CT.SOPHIEU = DD.SOPHIEU  "
                    + " LEFT JOIN DMBUONGBENH ON DMBUONGBENH.ID_BUONG = DD.BUONG AND DMBUONGBENH.MAKHOA='{0}' "
                    + " WHERE CT.LOAIDICHVU in ('D05') and ct.MaNhom= " + Global.GetCode(cmbNhomLenCP) + " "
                    + " union all"
                    + " select aa.MaPhieuDuyet,aa.mavaovien,hoten,year(getdate()) - NamSinh as tuoi,tenbuong,1 as Nhom,N'Chi phí bất thường' as Nhom1 from "
                    + " (select * from chiphi_thuthuat where MaNhom = " + Global.GetCode(cmbNhomLenCP) + " and loaidichvu in ('D05') and makhoa='{0}' and datediff(dd,ngaythuchien,'{1:dd/MM/yyyy}') = 0) aa"
                    + " inner join benhnhan_chitiet ct on ct.mavaovien = aa.mavaovien"
                    + " inner join benhnhan on benhnhan.mabenhnhan = ct.mabenhnhan"
                    + " LEFT JOIN DMBUONGBENH ON DMBUONGBENH.ID_BUONG = ct.BUONG AND DMBUONGBENH.MAKHOA='{0}') cc"
                    + " GROUP BY MAVAOVIEN,HOTEN,TUOI,TENBUONG,NHOM,Nhom1,cc.MaPhieuDuyet "
                    + " ORDER BY right(cc.MaPhieuDuyet,3) desc,NHOM,TENBUONG ",Global.GetCode(cmbKhoa), txtNgayChiDinh.Value);
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
                SQLCmd.CommandText = String.Format("set dateformat dmy SELECT MAVAOVIEN,MADICHVU,SUM(SOLUONG) AS SOLUONG,NHOM,TENTHUOC,loaidichvu,MAPHIEUDUYET FROM "
                    + " ( SELECT EE.*,THUOC.TENTHUOC FROM "
                    + " (SELECT DD.MaVaoVien,CT.MADICHVU,sum(CT.SOLUONG) as SoLuong,DD.NHOM,Ct.LoaiDichVu,CT.MAPHIEUDUYET FROM "
                    + " (SELECT CC.*,BN.SOPHIEU,BN.NGAYCHIDINH,BN.NHOM FROM"
                    + " (SELECT BB.MAVAOVIEN,AA.HOTEN,YEAR(GETDATE()) - NAMSINH AS TUOI FROM"
                    + " (SELECT * FROM BENHNHAN) AA"
                    + " INNER JOIN BENHNHAN_CHITIET BB ON BB.MABENHNHAN = AA.MABENHNHAN) CC"
                    + " INNER JOIN BENHNHAN_PHIEUDIEUTRI BN ON BN.MAVAOVIEN = CC.MAVAOVIEN"
                    + " WHERE MAKHOA ='{0}' AND DATEDIFF(DD,NGAYCHIDINH,'{1:dd/MM/yyyy}') = 0) DD"
                    + " INNER JOIN PHIEUDIEUTRI_CHITIET CT ON CT.SOPHIEU = DD.SOPHIEU "
                    + " WHERE CT.LOAIDICHVU in ('D05') and ct.MaNhom= " + Global.GetCode(cmbNhomLenCP) + " group by DD.MaVaoVien,CT.MADICHVU,DD.NHOM,ct.loaidichvu,ct.maphieuduyet) EE"
                    + " INNER JOIN "+ Global.glbDuoc +".DBO.DANHMUCTHUOC THUOC ON THUOC.THUOCID = EE.MADICHVU "
                    + " INNER JOIN SACLAPPHIEU ON SACLAPPHIEU.LOAITHUOC = THUOC.LOAITHUOC ",
                    Global.GetCode(cmbKhoa),
                    txtNgayChiDinh.Value);
                if (raTaCa.Checked)
                {
                    SQLCmd.CommandText += String.Format(" WHERE SACLAPPHIEU.NHOMSO <> -1 AND SACLAPPHIEU.MAKHOA='{0}'", Global.GetCode(cmbKhoa));
                }
                else
                {
                    if (raThuocOng.Checked)
                    {
                        SQLCmd.CommandText += String.Format(" WHERE SACLAPPHIEU.NHOMSO = 0 AND  SACLAPPHIEU.NHOMSO <> -1 AND SACLAPPHIEU.MAKHOA='{0}'", Global.GetCode(cmbKhoa));
                    }
                    else
                    {
                        SQLCmd.CommandText += String.Format(" WHERE SACLAPPHIEU.NHOMSO = 1 AND  SACLAPPHIEU.NHOMSO <> -1 AND SACLAPPHIEU.MAKHOA='{0}'", Global.GetCode(cmbKhoa));
                    }
                }
                SQLCmd.CommandText += String.Format(" UNION ALL"
                    + " SELECT AA.*,DMDICHVU.TENDICHVU FROM "
                    + " (SELECT MAVAOVIEN,MACHIPHI AS MADICHVU,SUM(SOLUONG) AS SOLUONG,1 AS NHOM,loaidichvu,MAPHIEUDUYET FROM CHIPHI_THUTHUAT WHERE MAKHOA ='{0}' AND DATEDIFF(DD,NGAYTHUCHIEN,'{1:dd/MM/yyyy}') = 0"
                    + " AND LOAIDICHVU in ('D05') and MaNhom= " + Global.GetCode(cmbNhomLenCP) + " GROUP BY MAVAOVIEN,MACHIPHI,loaidichvu,MaPhieuDuyet) AA"
                    + " INNER JOIN DMDICHVU ON DMDICHVU.MADICHVU = AA.MADICHVU"
                    + " INNER JOIN SACLAPPHIEU ON SACLAPPHIEU.LOAITHUOC = DMDICHVU.LOAITHUOC",
                    Global.GetCode(cmbKhoa),
                    txtNgayChiDinh.Value);
                if (raTaCa.Checked)
                {
                    SQLCmd.CommandText += String.Format(" WHERE SACLAPPHIEU.NHOMSO <> -1 AND SACLAPPHIEU.MAKHOA='{0}') BB", Global.GetCode(cmbKhoa));
                }
                else
                {
                    if (raThuocOng.Checked)
                    {
                        SQLCmd.CommandText += String.Format(" WHERE SACLAPPHIEU.NHOMSO = 0 AND  SACLAPPHIEU.NHOMSO <> -1 AND SACLAPPHIEU.MAKHOA='{0}') BB", Global.GetCode(cmbKhoa));
                    }
                    else
                    {
                        SQLCmd.CommandText += String.Format(" WHERE SACLAPPHIEU.NHOMSO = 1 AND  SACLAPPHIEU.NHOMSO <> -1 AND SACLAPPHIEU.MAKHOA='{0}') BB", Global.GetCode(cmbKhoa));
                    }
                }
                SQLCmd.CommandText += " GROUP BY MAVAOVIEN,MADICHVU,NHOM,TENTHUOC,loaidichvu,MAPHIEUDUYET";

                dr = SQLCmd.ExecuteReader();
                bool DaCo = false;
                while (dr.Read())
                {
                    for (int i = 1; i < fgDanhSach.Rows.Count; i++)
                    {
                        if (fgDanhSach.GetDataDisplay(i, "MaVaoVien") == dr["MaVaoVien"].ToString() && fgDanhSach.GetDataDisplay(i, "Nhom") == dr["Nhom"].ToString() && fgDanhSach.GetDataDisplay(i,"MaPhieuDuyet") == dr["MaPhieuDuyet"].ToString())
                        {
                            if (dr["LoaiDichVu"].ToString() == "D05")
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
                            //if(dr["LoaiDichVU"].ToString() == "D05")
                            //{
                            //    fgDanhSach[i,"ThuocDY"] = 1;
                            //}
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
                                fgDanhSach[fgDanhSach.Rows.Count - 1, _Col] = decimal.Parse(fgDanhSach[_Row, _Col].ToString()) + decimal.Parse(fgDanhSach[_Row, _Col].ToString());
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
                NamDinh_QLBN.Reports.repSoLenThuoc_SuaKhoaDongY rpt = new NamDinh_QLBN.Reports.repSoLenThuoc_SuaKhoaDongY(Global.GetCode(cmbKhoa),
                       -1, txtNgayChiDinh.Value, cmbKhoa.Text, fgDanhSach.GetDataDisplay(fgDanhSach.Row, "MaPhieuDuyet"));
                rpt.Show();
            }
            else
            {
                if (raDongY.Checked)
                {
                    NamDinh_QLBN.Reports.repSoLenThuoc_SuaKhoaDongYByLoaiDichVu rpt = new NamDinh_QLBN.Reports.repSoLenThuoc_SuaKhoaDongYByLoaiDichVu(Global.GetCode(cmbKhoa),
                        raThuocOng.Checked == true ? 0 : 1, txtNgayChiDinh.Value, cmbKhoa.Text, fgDanhSach.GetDataDisplay(fgDanhSach.Row, "MaPhieuDuyet"));
                    rpt.Show();
                }
                else
                {
                    NamDinh_QLBN.Reports.repSoLenThuoc_SuaKhoaDongY rpt = new NamDinh_QLBN.Reports.repSoLenThuoc_SuaKhoaDongY(Global.GetCode(cmbKhoa),
                        raThuocOng.Checked == true ? 0 : 1, txtNgayChiDinh.Value, cmbKhoa.Text, fgDanhSach.GetDataDisplay(fgDanhSach.Row, "MaPhieuDuyet"));
                    rpt.Show();
                }
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
    }
}