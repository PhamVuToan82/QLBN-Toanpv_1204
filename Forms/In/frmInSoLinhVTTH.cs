using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using GlobalModuls;
using C1.Win.C1FlexGrid;

namespace NamDinh_QLBN.Forms.In
{
    public partial class frmInSoLinhVTTH : Form
    {
        public frmInSoLinhVTTH()
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
            fgDanhSach.Redraw = false;
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            try
            {
                SQLCmd.CommandText = String.Format("set dateformat mdy SELECT * FROM "
                    + " DMDICHVU A inner join  "
                    + " (select MaDichVu from"
                    + " (Select ct.MaDichVu from benhnhan_phieudieutri pdt inner join phieudieutri_chitiet ct on  ct.SoPhieu = pdt.SoPhieu"
                    + " where makhoa = '{0}' and datediff(dd,NgayChiDinh,'{1:MM/dd/yyyy}') = 0 "
                    + " and ct.LoaiDichVu ='{2}' and ct.MaNhom= " + Global.GetCode(cmbNhomLenCP)
                    + " Union all"
                    + " SELECT MADICHVU FROM BENHNHAN_PT_CHIPHI "
                    + " WHERE LOAICHIPHI ='{2}'"
                    + " AND DATEDIFF(DD,NGAYCHIDINH,'{1:MM/dd/yyyy}') = 0 and '{0}'='NV1103' and NhomLenChiPhi = " + Global.GetCode(cmbNhomLenCP)
                    + " union  all"
                    + " select machiphi as Madichvu from NAMDINH_KHAMBENH.DBO.TBLCHIPHI_DICHVU where datediff(dd,NgayThucHien,'{1:MM/dd/yyyy}') = 0 and "
                    + " LoaiChiPhi ='{2}' and MAKHOATHUCHIEN='{0}' and MaNhom = " + Global.GetCode(cmbNhomLenCP) + ") b"
                    + " group by MaDichvu) c on c.madichvu = a.MADICHVU"
                    , Global.GetCode(cmbKhoa), txtNgayChiDinh.Value, raThuocDungChung.Checked ? "D06" : "D02");
                SQLCmd.CommandText += " order by a.TenDichVu";
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
                    fgDanhSach.Cols[j].Name = dr["MaDichVu"].ToString();
                    fgDanhSach[0, j] = dr["TenDichVu"];
                    j++;
                }
                dr.Close();
                C1.Win.C1FlexGrid.CellStyle cs = fgDanhSach.Styles[C1.Win.C1FlexGrid.CellStyleEnum.Subtotal0];
                cs.BackColor = Color.LightBlue;
                cs.ForeColor = Color.DarkBlue;
                fgDanhSach.Tree.Column = fgDanhSach.Cols["TenBenhNhan"].Index;
                SQLCmd.CommandText = string.Format("set dateformat mdy Select MaPhieuDuyet,MaVaoVien,HoTen,Tuoi,TenBuong,Nhom,Nhom1 from ("
                      + " Select pdtct.MaPhieuDuyet,pdt.MaVaoVien,bn.HoTen,year(getdate())-bn.NamSinh as Tuoi,bb.TenBuong,pdt.Nhom, "
                      + " CASE WHEN pdt.NHOM = 0 THEN N'Chi phí trong ngày' else N'Chi phí bất thường' end as Nhom1 "
                      + " from NamDinh_QLBN.dbo.BenhNhan_PhieuDieuTri pdt inner join NamDinh_QLBN.dbo.PhieuDieuTri_ChiTiet pdtct on pdt.SoPhieu=pdtct.SoPhieu "
                      + " inner join NamDinh_QLBN.dbo.BenhNhan_ChiTiet bnct on pdt.MaVaoVien=bnct.MaVaoVien inner join NamDinh_QLBN.dbo.BenhNhan bn on bn.MaBenhNhan=bnct.MaBenhNhan "
                      + " left join NamDinh_QLBN.dbo.DMBuongBenh bb on bb.ID_Buong=bnct.Buong and bb.MaKhoa='{0}'"
                      + " where pdt.MaKhoa='{0}' and pdtct.MaNhom={1} and datediff(dd,pdt.NgayChiDinh,'{2:MM/dd/yyyy}')=0 and pdtct.LoaiDichVu='{3}' "
                      + " Union all"
                      + " Select pt.MaPhieuDuyet,pt.MaVaoVien,bn.HoTen,year(getdate())-bn.NamSinh as Tuoi,bb.TenBuong,1 as Nhom, "
                      + " N'Chi phí bất thường' as Nhom1 "
                      + " from NamDinh_QLBN.dbo.BENHNHAN_PT_CHIPHI pt inner join NamDinh_QLBN.dbo.BenhNhan_ChiTiet bnct on pt.MaVaoVien=bnct.MaVaoVien "
                      + " inner join NamDinh_QLBN.dbo.BenhNhan bn on bn.MaBenhNhan=bnct.MaBenhNhan "
                      + " left join NamDinh_QLBN.dbo.DMBuongBenh bb on bb.ID_Buong=bnct.Buong and bb.MaKhoa='{0}'"
                      + " where '{0}'='NV1103' and datediff(dd,pt.NgayChiDinh,'{2:MM/dd/yyyy}')=0 and pt.NhomLenChiPhi='{1}' and pt.LoaiChiPhi = '{3}' "
                      + " Union all Select cpdv.MaPhieuDuyet,kb.MaKhamBenh as MaVaoVien,bn.TenBenhNhan as HoTen,year(getdate()) - bn.NamSinh as Tuoi,'' as TenBuong, 0 as Nhom, "
                      + " N'Chi phí trong ngày' as Nhom1 "
                      + " from NamDinh_KhamBenh.dbo.tblChiPhi_DichVu cpdv inner join NamDinh_KhamBenh.dbo.tblKhamBenh kb on cpdv.MaKhamBenh=kb.MaKhamBenh"
                      + " inner join NamDinh_KhamBenh.dbo.tblBenhNhan bn on bn.MaBenhNhan=kb.MaBenhNhan"
                      + " where MaKhoaThucHien='{0}' and MaNhom={1} and datediff(dd,NgayThucHien,'{2:MM/dd/yyyy}')=0 and LoaiChiPhi='{3}')x "
                      + " group by MaPhieuDuyet,MaVaoVien,HoTen,Tuoi,TenBuong,Nhom,Nhom1 ORDER BY right(MaPhieuDuyet,3) desc,Nhom,TenBuong"
                      , Global.GetCode(cmbKhoa), Global.GetCode(cmbNhomLenCP),txtNgayChiDinh.Value, raThuocDungChung.Checked ? "D06" : "D02");
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
                //fgDanhSach.AutoSizeRow(0) = true;
                //fgDanhSach.AutoSizeRows(0, 0, 0, fgDanhSach.Cols.Count - 1, 1, AutoSizeFlags.None);
                fgDanhSach.Rows[0].Height = 120;
                dr.Close();
                fgDanhSach.Redraw = true;
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
            fgDanhSach.Redraw = false;
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            try
            {
                SQLCmd.CommandText = string.Format("set dateformat mdy Select MaPhieuDuyet,dv.MaDichVu,SoLuong,dsVT.Nhom,MaVaoVien,TenDichVu from DMDichVu dv "
                     + " inner join ( Select MaPhieuDuyet,MaDichVu,sum(SoLuong) as SoLuong,Nhom,MaVaoVien from ("
                     + " Select pdtct.MaPhieuDuyet,pdtct.MaDichVu,pdtct.SoLuong+pdtct.SoLuongHT as SoLuong,pdt.Nhom,pdt.MaVaoVien from NamDinh_QLBN.dbo.BenhNhan_PhieuDieuTri pdt inner join NamDinh_QLBN.dbo.PhieuDieuTri_ChiTiet pdtct on pdt.SoPhieu=pdtct.SoPhieu "
                     + " where pdt.MaKhoa='{0}' and pdtct.MaNhom='{2}' and datediff(dd,pdt.NgayChiDinh,'{1:MM/dd/yyyy}')=0 and pdtct.LoaiDichVu='{3}' "
                     + " Union all"
                     + " Select MaPhieuDuyet,MaDichVu,SoLuong,1 as Nhom,MaVaoVien from NamDinh_QLBN.dbo.BENHNHAN_PT_CHIPHI "
                     + " where '{0}'='NV1103' and datediff(dd,NgayChiDinh,'{1:MM/dd/yyyy}')=0 and NhomLenChiPhi='{2}'"
                     + " Union all Select MaPhieuDuyet,MaChiPhi as MaDichVu,SoLuong,0 as Nhom,MaKhamBenh as MaVaoVien from NamDinh_KhamBenh.dbo.tblChiPhi_DichVu "
                     + " where MaKhoaThucHien='{0}' and MaNhom='{2}' and datediff(dd,NgayThucHien,'{1:MM/dd/yyyy}')=0 and LoaiChiPhi='{3}')x "
                     + " GROUP BY MAVAOVIEN,MADICHVU,NHOM,MAPHIEUDUYET) dsVT "
                     + " on dv.MaDichVu=dsVT.MaDichVu", Global.GetCode(cmbKhoa), txtNgayChiDinh.Value, Global.GetCode(cmbNhomLenCP), raThuocDungChung.Checked ? "D06" : "D02");
                dr = SQLCmd.ExecuteReader();
                bool DaCo = false;
                while (dr.Read())
                {
                    for (int i = 1; i < fgDanhSach.Rows.Count; i++)
                    {
                        if (fgDanhSach.GetDataDisplay(i, "MaVaoVien") == dr["MaVaoVien"].ToString() && fgDanhSach.GetDataDisplay(i, "Nhom") == dr["Nhom"].ToString() && fgDanhSach.GetDataDisplay(i, "MaPhieuDuyet") == dr["MaPhieuDuyet"].ToString())
                        {
                            for (int j = fgDanhSach.Cols["Tuoi"].Index + 1; j < fgDanhSach.Cols["GhiChu"].Index; j++)
                            {
                                if (fgDanhSach.Cols[j].Name == dr["MaDichVu"].ToString())
                                {
                                    fgDanhSach[i, j] = String.Format("{0:#,##0.##}",dr["SoLuong"]);
                                    DaCo = true;
                                    break;
                                }
                            }
                            if (!DaCo)
                            {
                                if (fgDanhSach[i, "GhiChu"] == null)
                                {
                                    fgDanhSach[i, "GhiChu"] = (object)(dr["TenDichVu"] + ": " + String.Format("{0:#,##0.##}", dr["SoLuong"])); 
                                }
                                else
                                {
                                    fgDanhSach[i, "GhiChu"] = (object)(fgDanhSach[i, "GhiChu"].ToString() + ". " + dr["TenDichVu"] + ": " + String.Format("{0:#,##0.##}", dr["SoLuong"])); 
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
                fgDanhSach.Redraw = true;
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

        private void btnInSo_Click(object sender, EventArgs e)
        {
            if (fgDanhSach.Rows.Count <= 1) return;
            if (fgDanhSach.GetDataDisplay(fgDanhSach.Row, "MaPhieuDuyet") == "" || fgDanhSach.GetDataDisplay(fgDanhSach.Row, "MaPhieuDuyet") == "null")
            {
                MessageBox.Show("Chọn một mã phiếu duyệt để in", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            NamDinh_QLBN.Reports.repSoLenVTTH rpt = new NamDinh_QLBN.Reports.repSoLenVTTH(Global.GetCode(cmbKhoa),
                raThuocDungChung.Checked == true ? 0 : 1, txtNgayChiDinh.Value, cmbKhoa.Text, fgDanhSach.GetDataDisplay(fgDanhSach.Row, "MaPhieuDuyet"), Global.GetCode(cmbNhomLenCP),cmbNhomLenCP.Text);
            rpt.Show();
        }

        private void rdVTTH_CheckedChanged(object sender, EventArgs e)
        {
            fgDanhSach.Tag = 0;
            FormatGrid();
            GetData();
            fgDanhSach.Tag = 1;
        }

        private void txtNgayChiDinh_ValueChanged(object sender, EventArgs e)
        {
            if (fgDanhSach.Tag.ToString() == "0") return;
            fgDanhSach.Tag = 0;
            FormatGrid();
            GetData();
            fgDanhSach.Tag = 1;
        }

        private void raThuocDungChung_CheckedChanged(object sender, EventArgs e)
        {
            fgDanhSach.Tag = 0;
            FormatGrid();
            GetData();
            fgDanhSach.Tag = 1;
        }

        private void cmbNhomLenCP_TextChanged(object sender, EventArgs e)
        {
            if (fgDanhSach.Tag.ToString() == "0") return;
            fgDanhSach.Tag = 0;
            FormatGrid();
            GetData();
            fgDanhSach.Tag = 1;
        }

        private void btnInNhom_Click(object sender, EventArgs e)
        {
            if (fgDanhSach.Rows.Count <= 1) return;
            if (fgDanhSach.GetDataDisplay(fgDanhSach.Row, "MaPhieuDuyet") == "" || fgDanhSach.GetDataDisplay(fgDanhSach.Row, "MaPhieuDuyet") == "null")
            {
                MessageBox.Show("Chọn một mã phiếu duyệt để in", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            NamDinh_QLBN.Reports.repSoLenVTTH rpt = new NamDinh_QLBN.Reports.repSoLenVTTH(Global.GetCode(cmbKhoa),
                raThuocDungChung.Checked == true ? 0 : 1, txtNgayChiDinh.Value, cmbKhoa.Text, fgDanhSach.GetDataDisplay(fgDanhSach.Row, "MaPhieuDuyet"), Global.GetCode(cmbNhomLenCP), cmbNhomLenCP.Text);
            rpt.Show();
        }
    }
}