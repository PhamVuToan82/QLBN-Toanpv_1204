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
namespace NamDinh_QLBN.Forms.DuLieu
{
    public partial class frmSoDoGiuongBenh : Form
    {
        public frmSoDoGiuongBenh()
        {
            InitializeComponent();
        }
        private void FormatGrid()
        {
            Global.wait("Đang cập nhật dữ liệu");
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            try
            {
                SQLCmd.CommandText = String.Format("select * from NAMDINH_QLBN.dbo.DMGIUONGBENH a inner join NAMDINH_QLBN.dbo.DMBUONGBENH b on a.MaKhoa = b.MaKhoa and a.ID_Buong = b.ID_Buong  where a.MaKhoa = 'NV1101' and SunDung = 1 and b.SuDung = 1  order by MaGiuongYT");
                //    + " NamDinh_Duoc.DBO.DANHMUCTHUOC A left join NamDinh_Duoc.dbo.DMDuongDung dd on a.MaDuongDung=dd.MaDuongDung"
                //    + " INNER JOIN SACLAPPHIEU ON SACLAPPHIEU.LOAITHUOC = A.LOAITHUOC "
                //    + " inner join  "
                //    + " (select * from"
                //    + " (Select ct.MaDichVU from  (select SoPhieu from benhnhan_phieudieutri where makhoa = '{0}' and datediff(dd,NgayChiDinh,'{1:MM/dd/yyyy}') = 0) aa "
                //    + " inner join phieudieutri_chitiet ct on  ct.SoPhieu = aa.SoPhieu  "
                //    + " where (ct.LoaiDichVu ='D01') and ct.MaNhom= " + Global.GetCode(cmbNhomLenCP)
                //    + " union  all"
                //    + " select machiphi as Madichvu from chiphi_thuthuat where datediff(dd,NgayThucHien,'{1:MM/dd/yyyy}') = 0 and loaidichvu ='D01' and makhoa='{0}' and MaNhom = " + Global.GetCode(cmbNhomLenCP) + ") bb"
                //    + " group by MaDichvu) cc on cc.madichvu = a.ThuocID and a.ThuocID !='DN-KH-0001'"
                //    + " WHERE ", Global.GetCode(cmbKhoa), txtNgayChiDinh.Value);
                //SQLCmd.CommandText += String.Format(" SACLAPPHIEU.makhoa = '{0}' ", Global.GetCode(cmbKhoa));
                //if (raTaCa.Checked)
                //{
                //}
                //else
                //{
                //    if (raThuocOng.Checked)
                //    {
                //        SQLCmd.CommandText += " and SACLAPPHIEU.NhomSO = 0 ";
                //    }
                //    else
                //    {
                //        SQLCmd.CommandText += " and SACLAPPHIEU.NhomSO = 1 ";
                //    }
                //}
                //SQLCmd.CommandText += " order by dd.STTIn,a.TenThuocYLenh";
                dr = SQLCmd.ExecuteReader();
                fgDanhSach.Rows.Count = 1;
                for (int i = 0 ; i <= 7; i++)
                {
                    fgDanhSach.Cols.Add();
                    fgDanhSach.Cols[fgDanhSach.Cols.Count - 1].Width = 30;

                }
                for (int k = 0; k <= 3; k++)
                {
                    fgDanhSach.Rows.Add();
                    fgDanhSach[0, k] = k;
                }
                //int j = 0;
                //while (dr.Read())
                //{
                //    if (j == 7) break;
                //    fgDanhSach.Cols[j].Name = dr["MaGiuongYT"].ToString();
                //    fgDanhSach[0, j] = dr["TenGiuong"];
                //    j++;
                //}

                //dr.Close();
                //C1.Win.C1FlexGrid.CellStyle cs = fgDanhSach.Styles[C1.Win.C1FlexGrid.CellStyleEnum.Subtotal0];
                //cs.BackColor = Color.LightBlue;
                //cs.ForeColor = Color.DarkBlue;
                //fgDanhSach.Tree.Column = fgDanhSach.Cols["TenBenhNhan"].Index;
                //SQLCmd.CommandText = String.Format("set dateformat mdy Select * from"
                //    + " (SELECT ct.MaPhieuDuyet,DD.MAVAOVIEN,DD.HOTEN,DD.TUOI,DMBUONGBENH.TENBUONG,dd.nhom,CASE WHEN DD.NHOM = 0 THEN N'Chi phí trong ngày' else N'Chi phí bất thường' end as Nhom1 FROM  "
                //    + " (SELECT CC.*,BN.SOPHIEU,BN.NGAYCHIDINH,BN.NHOM FROM "
                //    + " (SELECT BB.MAVAOVIEN,AA.HOTEN,YEAR(GETDATE()) - NAMSINH AS TUOI,BB.BUONG FROM "
                //    + " (SELECT * FROM BENHNHAN) AA INNER JOIN BENHNHAN_CHITIET BB ON BB.MABENHNHAN = AA.MABENHNHAN) CC "
                //    + " INNER JOIN BENHNHAN_PHIEUDIEUTRI BN ON BN.MAVAOVIEN = CC.MAVAOVIEN "
                //    + " WHERE MAKHOA ='{0}' AND DATEDIFF(DD,NGAYCHIDINH,'{1:MM/dd/yyyy}') = 0) DD "
                //    + " INNER JOIN PHIEUDIEUTRI_CHITIET CT ON CT.SOPHIEU = DD.SOPHIEU  "
                //    + " LEFT JOIN DMBUONGBENH ON DMBUONGBENH.ID_BUONG = DD.BUONG AND DMBUONGBENH.MAKHOA='{0}' "
                //    //+ " WHERE (CT.LOAIDICHVU = 'D01' or (CT.LOAIDICHVU = 'D06' AND EXISTS(SELECT * FROM VATTU WHERE VATTU.MACHIPHI = CT.MADICHVU AND VATTU.MAKHOA ='{0}' AND VATTU.ISVATTU = 0))) and ct.MaNhom= " + Global.GetCode(cmbNhomLenCP) + " "
                //    + " WHERE (CT.LOAIDICHVU = 'D01') and ct.MaNhom= " + Global.GetCode(cmbNhomLenCP) + " "
                //    + " union all"
                //    + " select aa.MaPhieuDuyet,aa.mavaovien,hoten,year(getdate()) - NamSinh as tuoi,tenbuong,1 as Nhom,N'Chi phí bất thường' as Nhom1 from "
                //    //+ " (select * from chiphi_thuthuat where MaNhom = " + Global.GetCode(cmbNhomLenCP) + " and (loaidichvu ='D01' OR (LOAIDICHVU='D06' AND EXISTS(SELECT * FROM VATTU WHERE VATTU.MACHIPHI = chiphi_thuthuat.MACHIPHI AND VATTU.MAKHOA ='{0}' AND VATTU.ISVATTU = 0))) and makhoa='{0}' and datediff(dd,ngaythuchien,'{1:MM/dd/yyyy}') = 0) aa"
                //    + " (select * from chiphi_thuthuat where MaNhom = " + Global.GetCode(cmbNhomLenCP) + " and loaidichvu ='D01' and makhoa='{0}' and datediff(dd,ngaythuchien,'{1:MM/dd/yyyy}') = 0) aa"
                //    + " inner join benhnhan_chitiet ct on ct.mavaovien = aa.mavaovien"
                //    + " inner join benhnhan on benhnhan.mabenhnhan = ct.mabenhnhan"
                //    + " LEFT JOIN DMBUONGBENH ON DMBUONGBENH.ID_BUONG = ct.BUONG AND DMBUONGBENH.MAKHOA='{0}') cc"
                //    + " GROUP BY MAVAOVIEN,HOTEN,TUOI,TENBUONG,NHOM,Nhom1,cc.MaPhieuDuyet "
                //    + " ORDER BY right(cc.MaPhieuDuyet,3) desc,NHOM,TENBUONG ", Global.GetCode(cmbKhoa), txtNgayChiDinh.Value);
                //dr = SQLCmd.ExecuteReader();
                //while (dr.Read())
                //{
                //    fgDanhSach.Rows.Add();
                //    fgDanhSach[fgDanhSach.Rows.Count - 1, "MaPhieuDuyet"] = dr["MaPhieuDuyet"];
                //    fgDanhSach[fgDanhSach.Rows.Count - 1, "Nhom"] = dr["Nhom"];
                //    fgDanhSach[fgDanhSach.Rows.Count - 1, "Nhom1"] = dr["Nhom1"];
                //    fgDanhSach[fgDanhSach.Rows.Count - 1, "STT"] = fgDanhSach.Rows.Count - 1;
                //    fgDanhSach[fgDanhSach.Rows.Count - 1, "MaVaoVien"] = dr["MaVaoVien"];
                //    fgDanhSach[fgDanhSach.Rows.Count - 1, "TenBenhNhan"] = dr["HoTen"];
                //    fgDanhSach[fgDanhSach.Rows.Count - 1, "Tuoi"] = dr["Tuoi"];
                //}
                //fgDanhSach.AutoResize = true;
                //fgDanhSach.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.Clear, 0, 0, 0);
                //fgDanhSach.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.None, 0, 1, 1, "{0}");
                //fgDanhSach.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.None, 1, 3, 1, "{0}");
                ////fgDanhSach.AutoSizeRow(0) = true;
                //fgDanhSach.AutoSizeRows(0, 0, 0, fgDanhSach.Cols.Count - 1, 1, AutoSizeFlags.None);
                //dr.Close();
                //Global.nowait();
            }
            catch (Exception ex)
            {
                //Global.nowait();
                MessageBox.Show("Lỗi: " + ex.ToString(), "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                SQLCmd.Dispose();
            }
        }

        private void frmSoDoGiuongBenh_Load(object sender, EventArgs e)
        {
            FormatGrid();
        }
    }
}
