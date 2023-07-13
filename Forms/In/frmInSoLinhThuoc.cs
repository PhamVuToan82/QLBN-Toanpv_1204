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
    public partial class frmInSoLinhThuoc : Form
    {
        public frmInSoLinhThuoc()
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
                SQLCmd.CommandText = String.Format("SELECT * FROM SOTHUOC "
                    + " INNER JOIN [" + Global.glbDuoc + "].DBO.DANHMUCTHUOC A ON A.THUOCID = SOTHUOC.MATHUOC "
                    + " INNER JOIN SACLAPPHIEU ON SACLAPPHIEU.LOAITHUOC = SOTHUOC.LOAITHUOC "
                    + " inner join  "
                    + " (select * from"
                    + " (Select ct.MaDichVU from  (select SoPhieu from benhnhan_phieudieutri where makhoa = '{0}' and datediff(dd,NgayChiDinh,'{1:MM/dd/yyyy}') = 0) aa "
                    + " inner join phieudieutri_chitiet ct on  ct.SoPhieu = aa.SoPhieu  "
                    + " where ct.LoaiDichVu ='D01' and ct.username=N'" + Global.glbUName + "'"
                    + " union  all"
                    + " select machiphi as Madichvu from chiphi_thuthuat where datediff(dd,NgayThucHien,'{1:MM/dd/yyyy}') = 0 and loaidichvu ='D01' and makhoa='{0}' and username =N'" + Global.glbUName + "') bb"
                    + " group by MaDichvu) cc on cc.madichvu = SoThuoc.MaThuoc "
                    + " WHERE ",Global.GetCode(cmbKhoa),txtNgayChiDinh.Value);
                SQLCmd.CommandText += String.Format(" SACLAPPHIEU.makhoa = '{0}' and SoThuoc.MaKHoa ='{0}'  ", Global.GetCode(cmbKhoa));
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
                SQLCmd.CommandText += " order by STT";
                

                dr = SQLCmd.ExecuteReader();
                fgDanhSach.Cols.Count = 6;
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
                //SQLCmd.CommandText = String.Format("SELECT DD.MAVAOVIEN,DD.HOTEN,DD.TUOI FROM "
                //    + " (SELECT CC.*,BN.SOPHIEU,BN.NGAYCHIDINH FROM"
                //    + " (SELECT BB.MAVAOVIEN,AA.HOTEN,YEAR(GETDATE()) - NAMSINH AS TUOI FROM"
                //    + " (SELECT * FROM BENHNHAN) AA"
                //    + " INNER JOIN BENHNHAN_CHITIET BB ON BB.MABENHNHAN = AA.MABENHNHAN) CC"
                //    + " INNER JOIN BENHNHAN_PHIEUDIEUTRI BN ON BN.MAVAOVIEN = CC.MAVAOVIEN"
                //    + " WHERE MAKHOA ='{0}' AND DATEDIFF(DD,NGAYCHIDINH,'{1:MM/dd/yyyy}') = 0) DD"
                //    + " INNER JOIN PHIEUDIEUTRI_CHITIET CT ON CT.SOPHIEU = DD.SOPHIEU "
                //    + " WHERE CT.LOAIDICHVU = 'D01' and ct.username=N'"+ Global.glbUName +"'"
                //    + " GROUP BY DD.MAVAOVIEN,DD.HOTEN,DD.TUOI", Global.GetCode(cmbKhoa), txtNgayChiDinh.Value);
                SQLCmd.CommandText = String.Format("Select * from"
                    + " (SELECT DD.MAVAOVIEN,DD.HOTEN,DD.TUOI,DMBUONGBENH.TENBUONG,dd.nhom,CASE WHEN DD.NHOM = 0 THEN N'Chi phí trong ngày' else N'Chi phí bất thường' end as Nhom1 FROM  "
                    + " (SELECT CC.*,BN.SOPHIEU,BN.NGAYCHIDINH,BN.NHOM FROM "
                    + " (SELECT BB.MAVAOVIEN,AA.HOTEN,YEAR(GETDATE()) - NAMSINH AS TUOI,BB.BUONG FROM "
                    + " (SELECT * FROM BENHNHAN) AA INNER JOIN BENHNHAN_CHITIET BB ON BB.MABENHNHAN = AA.MABENHNHAN) CC "
                    + " INNER JOIN BENHNHAN_PHIEUDIEUTRI BN ON BN.MAVAOVIEN = CC.MAVAOVIEN "
                    + " WHERE MAKHOA ='{0}' AND DATEDIFF(DD,NGAYCHIDINH,'{1:MM/dd/yyyy}') = 0) DD "
                    + " INNER JOIN PHIEUDIEUTRI_CHITIET CT ON CT.SOPHIEU = DD.SOPHIEU  "
                    + " LEFT JOIN DMBUONGBENH ON DMBUONGBENH.ID_BUONG = DD.BUONG AND DMBUONGBENH.MAKHOA='{0}' "
                    + " WHERE CT.LOAIDICHVU = 'D01' and ct.username=N'" + Global.glbUName + "' "
                    + " union all"
                    + " select aa.mavaovien,hoten,year(getdate()) - NamSinh as tuoi,tenbuong,1 as Nhom,N'Chi phí bất thường' as Nhom1 from "
                    + " (select * from chiphi_thuthuat where username =N'" + Global.glbUName + "' and loaidichvu ='D01' and makhoa='{0}' and datediff(dd,ngaythuchien,'{1:MM/dd/yyyy}') = 0) aa"
                    + " inner join benhnhan_chitiet ct on ct.mavaovien = aa.mavaovien"
                    + " inner join benhnhan on benhnhan.mabenhnhan = ct.mabenhnhan"
                    + " LEFT JOIN DMBUONGBENH ON DMBUONGBENH.ID_BUONG = ct.BUONG AND DMBUONGBENH.MAKHOA='{0}') cc"
                    + " GROUP BY MAVAOVIEN,HOTEN,TUOI,TENBUONG,NHOM,Nhom1 "
                    + " ORDER BY NHOM,TENBUONG ",Global.GetCode(cmbKhoa), txtNgayChiDinh.Value);
                dr = SQLCmd.ExecuteReader();
                while (dr.Read())
                {
                    fgDanhSach.Rows.Add();
                    fgDanhSach[fgDanhSach.Rows.Count - 1, "Nhom"] = dr["Nhom"];
                    fgDanhSach[fgDanhSach.Rows.Count - 1, "Nhom1"] = dr["Nhom1"];
                    fgDanhSach[fgDanhSach.Rows.Count - 1, "STT"] = fgDanhSach.Rows.Count - 1;
                    fgDanhSach[fgDanhSach.Rows.Count - 1, "MaVaoVien"] = dr["MaVaoVien"];
                    fgDanhSach[fgDanhSach.Rows.Count - 1, "TenBenhNhan"] = dr["HoTen"];
                    fgDanhSach[fgDanhSach.Rows.Count - 1, "Tuoi"] = dr["Tuoi"];
                }
                fgDanhSach.AutoResize = true;
                fgDanhSach.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.Clear, 0, 0, 0);
                fgDanhSach.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.None, 0, 2, 1, "{0}");
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
                SQLCmd.CommandText = String.Format("SELECT MAVAOVIEN,MADICHVU,SUM(SOLUONG) AS SOLUONG,NHOM,TENTHUOC FROM "
                    + " ( SELECT EE.*,THUOC.TENTHUOC FROM "
                    + " (SELECT DD.MaVaoVien,CT.MADICHVU,sum(CT.SOLUONG) as SoLuong,DD.NHOM FROM "
                    + " (SELECT CC.*,BN.SOPHIEU,BN.NGAYCHIDINH,BN.NHOM FROM"
                    + " (SELECT BB.MAVAOVIEN,AA.HOTEN,YEAR(GETDATE()) - NAMSINH AS TUOI FROM"
                    + " (SELECT * FROM BENHNHAN) AA"
                    + " INNER JOIN BENHNHAN_CHITIET BB ON BB.MABENHNHAN = AA.MABENHNHAN) CC"
                    + " INNER JOIN BENHNHAN_PHIEUDIEUTRI BN ON BN.MAVAOVIEN = CC.MAVAOVIEN"
                    + " WHERE MAKHOA ='{0}' AND DATEDIFF(DD,NGAYCHIDINH,'{1:MM/dd/yyyy}') = 0) DD"
                    + " INNER JOIN PHIEUDIEUTRI_CHITIET CT ON CT.SOPHIEU = DD.SOPHIEU "
                    + " WHERE CT.LOAIDICHVU = 'D01' and ct.username=N'" + Global.glbUName + "' group by DD.MaVaoVien,CT.MADICHVU,DD.NHOM) EE"
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
                    + " (SELECT MAVAOVIEN,MACHIPHI AS MADICHVU,SUM(SOLUONG) AS SOLUONG,1 AS NHOM FROM CHIPHI_THUTHUAT WHERE MAKHOA ='{0}' AND DATEDIFF(DD,NGAYTHUCHIEN,'{1:MM/dd/yyyy}') = 0"
                    + " AND LOAIDICHVU = 'D01' and username=N'"+ Global.glbUName +"' GROUP BY MAVAOVIEN,MACHIPHI) AA"
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
                SQLCmd.CommandText += " GROUP BY MAVAOVIEN,MADICHVU,NHOM,TENTHUOC";

                dr = SQLCmd.ExecuteReader();
                bool DaCo = false;
                while (dr.Read())
                {
                    for (int i = 1; i < fgDanhSach.Rows.Count; i++)
                    {
                        if (fgDanhSach.GetDataDisplay(i, "MaVaoVien") == dr["MaVaoVien"].ToString() && fgDanhSach.GetDataDisplay(i, "Nhom") == dr["Nhom"].ToString())
                        {
                            for (int j = fgDanhSach.Cols["Tuoi"].Index + 1; j < fgDanhSach.Cols["GhiChu"].Index; j++)
                            {
                                if (fgDanhSach.Cols[j].Name == dr["MaDichVu"].ToString())
                                {
                                    fgDanhSach[i, j] = dr["SoLuong"];
                                    DaCo = true;
                                    break;
                                }
                            }
                            if (!DaCo)
                            {
                                if (fgDanhSach[i, "GhiChu"] == null)
                                {
                                    fgDanhSach[i, "GhiChu"] = (object)(dr["TenThuoc"] + ": " + dr["SoLuong"].ToString()); 
                                }
                                else
                                {
                                    fgDanhSach[i, "GhiChu"] = (object)(fgDanhSach[i, "GhiChu"].ToString() + ". " + dr["TenThuoc"] + ": " + dr["SoLuong"].ToString()); 
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
                                fgDanhSach[fgDanhSach.Rows.Count - 1, _Col] = int.Parse(fgDanhSach[_Row, _Col].ToString());
                            }
                            else
                            {
                                fgDanhSach[fgDanhSach.Rows.Count - 1, _Col] = int.Parse(fgDanhSach[fgDanhSach.Rows.Count - 1, _Col].ToString()) + int.Parse(fgDanhSach[_Row, _Col].ToString());
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
            SQLCmd.Dispose();
            txtNgayChiDinh.Value = Global.NgayLV;
            FormatGrid();
            GetData();
            fgDanhSach.Tag = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (fgDanhSach.Rows.Count <= 1) return;
            System.Data.SqlClient.SqlCommand SQLCmd = new SqlCommand("", GlobalModuls.Global.ConnectSQL);
            String Str = "";
            //Tinh xem co bao nhieu luot in trong ngay
            int LuotIn = 1;
            Str = String.Format("Select * from "
                + " (Select LuotIn from PhieuDieuTri_ChiTiet Where SoPhieu in  "
                + " (Select  BenhNhan_PhieuDieuTri.SoPhieu From BenhNhan_PhieuDieuTri "
                + " inner join phieudieutri_chitiet on phieudieutri_chitiet.sophieu = benhnhan_phieudieutri.sophieu and username=N'" + Global.glbUName + "'"
                + " Where MaKhoa = '{0}' And  "
                + " DateDiff(dd,NgayChiDinh,'{1:MM/dd/yyyy}') = 0) And LoaiDichVu in ('D01','D05') And DaThucHien = 1 "
                + " Group by LuotIn "
                + " union all"
                + " Select LuotIn from chiphi_thuthuat where MaKhoa = '{0}' and datediff(dd,ngaythuchien,'{1:MM/dd/yyyy}') = 0"
                + " And LoaiDichVu in ('D01','D05') And DaThucHien = 1 and username=N'" + Global.glbUName + "'"
                + " group by Luotin) aa"
                + " Group by luotin order by luotin desc",
                GlobalModuls.Global.GetCode(cmbKhoa),
                txtNgayChiDinh.Value);
            SQLCmd.CommandText = Str;
            System.Data.DataSet ds = new DataSet();
            System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(SQLCmd);
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 1)
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

            if (raTaCa.Checked)
            {
                NamDinh_QLBN.Reports.repSoLenThuoc rpt = new NamDinh_QLBN.Reports.repSoLenThuoc(Global.GetCode(cmbKhoa),
                       -1, txtNgayChiDinh.Value, cmbKhoa.Text,LuotIn);
                rpt.Show();
            }
            else
            {
                NamDinh_QLBN.Reports.repSoLenThuoc rpt = new NamDinh_QLBN.Reports.repSoLenThuoc(Global.GetCode(cmbKhoa),
                    raThuocOng.Checked == true ? 0 : 1, txtNgayChiDinh.Value, cmbKhoa.Text,LuotIn);
                rpt.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void raThuocVien_CheckedChanged(object sender, EventArgs e)
        {
            FormatGrid();
            GetData();
        }

        private void txtNgayChiDinh_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNgayChiDinh_ValueChanged(object sender, EventArgs e)
        {
            if (fgDanhSach.Tag.ToString() == "0") return;
            FormatGrid();
            GetData();
        }

        private void raThuocOng_CheckedChanged(object sender, EventArgs e)
        {
            FormatGrid();
            GetData();
        }

        private void raTaCa_CheckedChanged(object sender, EventArgs e)
        {
            FormatGrid();
            GetData();
        }
    }
}