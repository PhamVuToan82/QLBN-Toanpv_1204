using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GlobalModuls;

namespace NamDinh_QLBN.Forms.DuLieu
{
    public partial class frmTongKetCP : Form
    {
        public frmTongKetCP()
        {
            InitializeComponent();
        }

        private void LoatDM()
        {
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            try
            {
                SQLCmd.CommandText = "SELECT * FROM DMKHOAPHONG WHERE MaKhoa IN " + Global.glbKhoa_CapNhat;
                dr = SQLCmd.ExecuteReader();
                cmbKhoa.Tag = "0";
                cmbKhoa.ClearItems();
                while (dr.Read())
                {
                    cmbKhoa.AddItem(string.Format("{0};{1}", dr["TenKhoa"],dr["MaKhoa"]));
                }
                cmbKhoa.SelectedIndex = 0;
                dr.Close();
            }
            catch
            {
            }
            finally
            {
                SQLCmd.Dispose();
            }
        }

        private void LoatData()
        {
            Global.wait("Đang tông hợp dữ liệu");
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            try
            {
                SQLCmd.CommandText = "";
                fgDanhSach.Rows.Fixed = 0;
                fgDanhSach.Rows.Count = 1;
                fgDanhSach.Rows.Fixed = 1;
                int STT = 0, STT1 = 0;
                if (raNhomTK.Checked)
                {
                    SQLCmd.CommandText = String.Format("Select cc.*,aa.tendichvu,aa.DVT from "
                        + " (select bb.MaDichVu,sum(SoLuong) as SoLuong,bb.DathucHien from"
                        + " (Select * from benhnhan_phieudieutri where MaKhoa ='{0}' and datediff(dd,ngaychidinh,'{1:MM/dd/yyyy}') <=0 "
                        + " and datediff(dd,ngaychidinh,'{2:MM/dd/yyyy}') >=0 )aa"
                        + " Inner join phieudieutri_chitiet bb on bb.sophieu = aa.sophieu "
                        + " Group by bb.MaDichVu,bb.DathucHien) cc "
                        + " Inner join dmdichvu aa on aa.madichvu = cc.madichvu "
                        + " inner join dstravo on dstravo.mathuoc = cc.madichvu "
                        + " where aa.loaidichvu like 'D%' ", cmbKhoa.Columns[1].CellText(cmbKhoa.SelectedIndex), txtTuNgay.Value, txtDenNgay.Value);
                   //   SQLCmd.CommandText += String.Format("  and aa.loaidichvu ='{0}'", cmbLoaiThuoc.Columns[1].CellText(cmbLoaiThuoc.SelectedIndex));
                }
                else
                {
                    SQLCmd.CommandText = String.Format("SELECT DD.*,DMDICHVU.TENDICHVU,DMDICHVU.DVT FROM "
                        + " (SELECT CC.*,CT.LOAIDICHVU,CT.MADICHVU,CT.SOLUONG,CT.DATHUCHIEN FROM"
                        + " (SELECT BB.*,BENHNHAN_PHIEUDIEUTRI.SOPHIEU,BENHNHAN_PHIEUDIEUTRI.NGAYCHIDINH FROM"
                        + " (SELECT AA.HOTEN,AA.NAMSINH,BENHNHAN_CHITIET.MAVAOVIEN FROM"
                        + " (SELECT * FROM BENHNHAN) AA"
                        + " INNER JOIN BENHNHAN_CHITIET ON BENHNHAN_CHITIET.MABENHNHAN = AA.MABENHNHAN) BB"
                        + " INNER JOIN BENHNHAN_PHIEUDIEUTRI ON BENHNHAN_PHIEUDIEUTRI.MAVAOVIEN = BB.MAVAOVIEN"
                        + " WHERE DATEDIFF(DD,BENHNHAN_PHIEUDIEUTRI.NGAYCHIDINH,'{1:MM/dd/yyyy}') <=0 AND "
                        + " DATEDIFF(DD,BENHNHAN_PHIEUDIEUTRI.NGAYCHIDINH,'{2:MM/dd/yyyy}') >=0 AND "
                        + " BENHNHAN_PHIEUDIEUTRI.MAKHOA = '{0}') CC"
                        + " INNER JOIN PHIEUDIEUTRI_CHITIET CT ON CT.SOPHIEU = CC.SOPHIEU) DD"
                        + " INNER JOIN DMDICHVU ON DMDICHVU.MADICHVU = DD.MADICHVU"
                        + " inner join dstravo on dstravo.mathuoc = dd.madichvu "
                        + " WHERE DD.LOAIDICHVU LIKE 'D%' ", cmbKhoa.Columns[1].CellText(cmbKhoa.SelectedIndex), txtTuNgay.Value, txtDenNgay.Value);

                   // if (cmbLoaiThuoc.SelectedIndex != 0)
                   //     SQLCmd.CommandText += String.Format("  AND DD.LOAIDICHVU ='{0}'", cmbLoaiThuoc.Columns[1].CellText(cmbLoaiThuoc.SelectedIndex));
                   ////
                    if (raNhomTBN.Checked)
                    {
                        SQLCmd.CommandText += " ORDER BY HOTEN,NGAYCHIDINH,DD.LOAIDICHVU,TENDICHVU";
                    }
                    else
                    {
                        SQLCmd.CommandText += " ORDER BY TENDICHVU,NGAYCHIDINH,HOTEN";
                    }
                }

                if (SQLCmd.CommandText == "")
                    return;
                dr = SQLCmd.ExecuteReader();
                if (raNhomTK.Checked)
                {

                    fgDanhSach.Cols[3].DataType = typeof(int);
                    while (dr.Read())
                    {
                        fgDanhSach.Rows.Add();
                        fgDanhSach[fgDanhSach.Rows.Count - 1, "STT"] = fgDanhSach.Rows.Count - 1;
                        fgDanhSach[fgDanhSach.Rows.Count - 1, 1] = dr["MaDichVu"];
                        fgDanhSach[fgDanhSach.Rows.Count - 1, 2] = dr["TenDichVu"];
                        fgDanhSach[fgDanhSach.Rows.Count - 1, 3] = dr["SoLuong"];
                        fgDanhSach[fgDanhSach.Rows.Count - 1, 4] = dr["DVT"];
                    }
                    fgDanhSach[0, 1] = "Mã dịch vụ";
                    fgDanhSach[0, 2] = "Tên dịch vụ";
                    fgDanhSach[0, 3] = "Số lượng lỉnh";
                    fgDanhSach[0, 4] = "Đợn vị tính";
                    fgDanhSach.Cols[1].Visible = fgDanhSach.Cols[5].Visible = fgDanhSach.Cols[6].Visible = fgDanhSach.Cols[7].Visible = false;
                    fgDanhSach.Cols[2].Visible = fgDanhSach.Cols[3].Visible = fgDanhSach.Cols[4].Visible = true;
                }
                else
                {
                    fgDanhSach.Cols[5].Visible = fgDanhSach.Cols[6].Visible = fgDanhSach.Cols[7].Visible = true;
                    fgDanhSach.Cols[1].Visible = fgDanhSach.Cols[2].Visible = fgDanhSach.Cols[3].Visible = fgDanhSach.Cols[4].Visible = false;
                    fgDanhSach.Cols[3].DataType = typeof(DateTime);
                    fgDanhSach.Tree.Column = 5;
                    if (raNhomTBN.Checked)
                    {
                        while (dr.Read())
                        {
                            if (dr["MaVaoVien"].ToString() != fgDanhSach[fgDanhSach.Rows.Count - 1, 1].ToString())
                            {
                                STT++;
                                STT1 = 0;
                            }
                            if (dr["MaDichVu"].ToString() != fgDanhSach[fgDanhSach.Rows.Count - 1, 4].ToString())
                            {
                                STT1++;
                            }
                            fgDanhSach.Rows.Add();
                            fgDanhSach[fgDanhSach.Rows.Count - 1, "STT"] = STT1.ToString();
                            fgDanhSach[fgDanhSach.Rows.Count - 1, 1] = dr["MaVaoVien"];
                            fgDanhSach[fgDanhSach.Rows.Count - 1, 2] = STT.ToString() + ": " + dr["HoTen"].ToString();
                            fgDanhSach[fgDanhSach.Rows.Count - 1, 3] = String.Format("{0:dd/MM/yyyy}", dr["NgayChiDinh"]);
                            fgDanhSach[fgDanhSach.Rows.Count - 1, 4] = dr["MaDichVu"];
                            fgDanhSach[fgDanhSach.Rows.Count - 1, 5] = dr["TenDichVu"];
                            fgDanhSach[fgDanhSach.Rows.Count - 1, 6] = dr["SoLuong"];
                            fgDanhSach[fgDanhSach.Rows.Count - 1, 7] = dr["DVT"];
                        }
                        fgDanhSach[0, 1] = "Mã bệnh nhân";
                        fgDanhSach[0, 2] = "Họ tên";
                        fgDanhSach[0, 3] = "Ngày chỉ định";
                        fgDanhSach[0, 4] = "Mã dịch vụ";
                        fgDanhSach[0, 5] = "Tên dịch vụ";
                        fgDanhSach[0, 6] = "Số lượng";
                        fgDanhSach[0, 7] = "Đơn vị tính";
                        fgDanhSach.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.None, 0, 2, 0, "{0}");
                        fgDanhSach.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.None, 1, 3, -1, "{0}");
                    }
                    else
                    {
                        while (dr.Read())
                        {
                            if (dr["MaDichVu"].ToString() != fgDanhSach[fgDanhSach.Rows.Count - 1, 1].ToString())
                            {
                                STT++;
                                STT1 = 0;
                            }
                            if (dr["MaVaoVien"].ToString() != fgDanhSach[fgDanhSach.Rows.Count - 1, 4].ToString())
                            {
                                STT1++;
                            }
                            fgDanhSach.Rows.Add();
                            fgDanhSach[fgDanhSach.Rows.Count - 1, "STT"] = STT1.ToString();
                            fgDanhSach[fgDanhSach.Rows.Count - 1, 1] = dr["MaDichVu"];
                            fgDanhSach[fgDanhSach.Rows.Count - 1, 2] = STT.ToString() + ": " + dr["TenDichVu"];
                            fgDanhSach[fgDanhSach.Rows.Count - 1, 3] = String.Format("{0:dd/MM/yyyy}", dr["NgayChiDinh"]);
                            fgDanhSach[fgDanhSach.Rows.Count - 1, 4] = dr["MaVaoVien"];
                            fgDanhSach[fgDanhSach.Rows.Count - 1, 5] = dr["HoTen"];
                            fgDanhSach[fgDanhSach.Rows.Count - 1, 6] = dr["SoLuong"];
                            fgDanhSach[fgDanhSach.Rows.Count - 1, 7] = dr["DVT"];
                        }
                        fgDanhSach[0, 1] = "Mã dịch vụ";
                        fgDanhSach[0, 2] = "Tên dịch vụ";
                        fgDanhSach[0, 3] = "Ngày chỉ định";
                        fgDanhSach[0, 4] = "Mã bệnh nhân";
                        fgDanhSach[0, 5] = "Họ tên";
                        fgDanhSach[0, 6] = "Số lượng";
                        fgDanhSach[0, 7] = "Đơn vị tính";
                        fgDanhSach.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.Sum, 0, 2, 6, "{0}");
                        fgDanhSach.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.Sum, 1, 3, 6, "{0}");
                    }
                }
                dr.Close();
                fgDanhSach.AutoSizeCols(1);
            }
            catch
            {
            }
            finally
            {
                Global.nowait();
                SQLCmd.Dispose();
            }
        }

        private void cmdThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTongKetCP_Load(object sender, EventArgs e)
        {
            fgDanhSach.Tag = 0;
            txtTuNgay.Value = txtDenNgay.Value = Global.NgayLV;
            LoatDM();
            LoatData();
            fgDanhSach.Tag = 1;
            C1.Win.C1FlexGrid.CellStyle cs = fgDanhSach.Styles[C1.Win.C1FlexGrid.CellStyleEnum.Subtotal0];
            cs.BackColor = Color.LightBlue;
            cs.ForeColor = Color.DarkBlue;
            Font f = new Font(cs.Font.FontFamily, 10, FontStyle.Bold);
            cs.Font = f;
            cs = fgDanhSach.Styles[C1.Win.C1FlexGrid.CellStyleEnum.Subtotal1];
            cs.BackColor = Color.Azure;
            cs.ForeColor = Color.DarkBlue;
        }

        private void txtTuNgay_ValueChanged(object sender, EventArgs e)
        {
            if (fgDanhSach.Tag.ToString() == "0") return;
            LoatData();
        }

        private void txtDenNgay_ValueChanged(object sender, EventArgs e)
        {
            if (fgDanhSach.Tag.ToString() == "0") return;
            LoatData();
        }

        private void cmbLoaiThuoc_TextChanged(object sender, EventArgs e)
        {
            if (fgDanhSach.Tag.ToString() == "0") return;
            LoatData();
        }

        private void raNhomTK_CheckedChanged(object sender, EventArgs e)
        {
            if (fgDanhSach.Tag.ToString() == "0") return;
            if(raNhomTK.Checked)
            LoatData();
        }

        private void raNhomTBN_CheckedChanged(object sender, EventArgs e)
        {
            if (raNhomTBN.Checked)
            {
                LoatData();
            }
        }

        private void raNhomTCP_CheckedChanged(object sender, EventArgs e)
        {
            if (raNhomTCP.Checked)
            {
                LoatData();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
               
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
            }
        }

        private void fgDanhSach_Click(object sender, EventArgs e)
        {

        }
    }
}