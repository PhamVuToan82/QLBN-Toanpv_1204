using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using GlobalModuls;

namespace NamDinh_QLBN.Forms.DuLieu
{
    public partial class frmVatTu : Form
    {
        int btn = 0; // 0: nút sửa, 1 là nút nhập tồn đầu kỳ
        DateTime NgayChotGanNhat, NgayLimit;
        public frmVatTu()
        {
            InitializeComponent();
        }

        private void AllowEdit(bool Flag)
        {
            cmdChot.Enabled = !Flag;
            cmdGhi.Visible = Flag;
            btnXoaTonDauKy.Visible = Flag;
            cmbKhongGhi.Visible = Flag;
            cmdSua.Visible = !Flag;
            cmdChonVT.Enabled = Flag;
            cmdThoat.Visible = !Flag;
            fg.AllowDelete = Flag;
            fg.AllowEditing = Flag;
            cmbVatTu.Enabled = Flag;
            cmdInPhieuLinh.Enabled = !Flag;
            cmdInPhieuLinh.Enabled = !Flag;
        }

        private void LoatDanhMuc()
        {
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            SQLCmd.CommandTimeout = 0;
            try
            {
                SQLCmd.CommandText = "SELECT * FROM DMKHOAPHONG WHERE MaKhoa IN " + Global.glbKhoa_CapNhat;
                dr = SQLCmd.ExecuteReader();
                cmbKhoa.Tag = "0";
                cmbKhoa.ClearItems();
                while (dr.Read())
                {
                    cmbKhoa.AddItem(string.Format("{0};{1}", dr["MaKhoa"], dr["TenKhoa"]));
                }
                cmbKhoa.SelectedIndex = 0;
                dr.Close();
                cmbKhoa.Tag = "1";
                //SQLCmd.CommandText = "select * from dmdichvu where loaidichvu in ('D02','D06') order by tendichvu";
                SQLCmd.CommandText = "select * from DMLENCHIPHI_BYKHOID where loaidichvu in ('D02','D06') order by tendichvu";
                dr = SQLCmd.ExecuteReader();
                cmbVatTu.AddItemSeparator = '|';
                while (dr.Read())
                {
                    cmbVatTu.AddItem(String.Format("{0}|{1}|{2}|{3}",
                         dr["TenDichVu"],
                         dr["DVT"],
                         dr["MaDichVu"],
                         dr["LoaiDichVu"]));
                }
                dr.Close();
                string strcmb = "0-In trên sổ y lệnh|1-Không in";
                fg.Cols["isVatTu"].ComboList = strcmb;
                
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
            String Str = "";
            NgayLimit = GlobalModuls.Global.NgayLV.AddMonths(-2);
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            try
            {
                txtNgayChot.ReadOnly = false;
                cmdChot.Text = "Chốt";
                cmdPrint.Enabled = false;
                string str = string.Format("set dateformat dmy Select isnull(max(NgayChot),'1-1-2000') as NgayChot from VetVatTu where makhoa ='{0}'",
                    Global.GetCode(cmbKhoa));
                SQLCmd.CommandText = str;
                dr = SQLCmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        if (dr["NgayChot"].ToString() == "") NgayChotGanNhat = DateTime.Parse("01/01/2000");
                        else NgayChotGanNhat = DateTime.Parse(dr["NgayChot"].ToString());
                        lblChotSoGanNhat.Text = string.Format("Lần chốt sổ gần nhất:{0:dd/MM/yyyy}", NgayChotGanNhat);
                    }
                }
                dr.Close();
                DateTime NgayChot1 = DateTime.Parse(txtNgayChot.Value.ToString());
                System.TimeSpan NgayDT = NgayChotGanNhat - NgayChot1;
                if (NgayDT.Days >= 0)
                {
                    //txtNgayChot.Value = NgayChotGanNhat;
                    //txtNgayChot.ReadOnly = true;
                    cmdChot.Text = "Hủy chốt";
                    cmdPrint.Enabled = true;
                }
                else
                {
                    cmdChot.Text = "Chốt";
                    cmdPrint.Enabled = false;
                }
                fg.Redraw = false;
                Str = string.Format("set dateformat mdy SELECT MACHIPHI,MAKHOA,SUM(SOLUONGDK) AS SOLUONGDK, "
                     + " SUM(SOLUONGTK)  AS SOLUONGTK,sum(SoluongDSD)AS SoluongDSD,sum(SoLuongDC) as SoLuongDC,tendichvu,dvt,IsVatTu,Nhom"
                     + " From("
                     +" SELECT VATTU.MACHIPHI,VATTU.MAKHOA,SOLUONGDK, 0 as SOLUONGTK,0 AS SoluongDSD,CASE "
                     +" WHEN VATTU.ISVATTU = 0 THEN N'0-In trên sổ y lệnh' ELSE N'1-Không in' "
                     +" END AS ISVATTU, SoLuongDC, Nhom FROM VATTU "
                     +" WHERE VATTU.MAKHOA ='{0}' "
                     +" UNION ALL"
                     +" SELECT VATTU.MACHIPHI,VATTU.MAKHOA,0 AS SOLUONGDK, SoLuongYC  AS SOLUONGTK,0 AS SoLuongDSD,CASE "
                     +" WHEN VATTU.ISVATTU = 0 THEN N'0-In trên sổ y lệnh' ELSE N'1-Không in' "
                     +" END AS ISVATTU, 0 as SoLuongDC, VatTu.Nhom"
                     + " FROM VATTU INNER JOIN DuTruVatTu dt ON VatTu.MACHIPHI = dt.MACHIPHI and VatTu.MaKhoa=dt.MaKhoa"
                     + " WHERE VatTu.MAKHOA='{0}' AND DATEDIFF(DD,dt.Ngay,'{1:MM/dd/yyyy}') >= 0 and DATEDIFF(DD,dt.Ngay,'{2:MM/dd/yyyy}') <= 0",Global.GetCode(cmbKhoa), txtNgayChot.Value,NgayChotGanNhat);
                if(Global.GetCode(cmbKhoa)=="NV1103") // khoa phau thuat
                    Str += string.Format(" UNION ALL"
                     + " SELECT VATTU.MACHIPHI,VATTU.MAKHOA,0 AS SOLUONGDK, 0  AS SOLUONGTK,SoLuong AS SoLuongDSD,CASE "
                     + " WHEN VATTU.ISVATTU = 0 THEN N'0-In trên sổ y lệnh' ELSE N'1-Không in' "
                     + " END AS ISVATTU,0 as SoLuongDC, VatTu.Nhom"
                     + " FROM VATTU INNER JOIN BENHNHAN_PT_CHIPHI pt ON VatTu.MACHIPHI = pt.MaDichVu"
                     + " WHERE VatTu.MAKHOA='{0}' AND DATEDIFF(DD,NGAYCHIDINH,'{1:MM/dd/yyyy}') >= 0 AND pt.Chot =0"
                     + " ) BB INNER JOIN dmdichvu A ON A.madichvu = BB.MACHIPHI ", Global.GetCode(cmbKhoa), txtNgayChot.Value);
                else // khoa dieu tri
                    Str+= string.Format(" UNION ALL"
                     +" SELECT VATTU.MACHIPHI,VATTU.MAKHOA,0 AS SOLUONGDK, 0  AS SOLUONGTK,SoLuong AS SoLuongDSD,CASE "
                     +" WHEN VATTU.ISVATTU = 0 THEN N'0-In trên sổ y lệnh' ELSE N'1-Không in' "
                     + " END AS ISVATTU,0 as SoLuongDC, VatTu.Nhom"
                     +" FROM VATTU INNER JOIN PHIEUDIEUTRI_CHITIET pc ON VatTu.MACHIPHI = pc.MaDichVu"
                     +" INNER JOIN BENHNHAN_PHIEUDIEUTRI bp ON bp.SoPhieu = pc.SoPhieu AND VatTu.MAKHOA =bp.MaKhoa"
                     + " WHERE VatTu.MAKHOA='{0}' AND DATEDIFF(DD,NGAYCHIDINH,'{1:MM/dd/yyyy}') >= 0 AND pc.Chot =0"
                     + " ) BB INNER JOIN dmdichvu A ON A.madichvu = BB.MACHIPHI and A.KhongSuDung=0",Global.GetCode(cmbKhoa), txtNgayChot.Value);
                Str+=" GROUP BY MAKHOA,MACHIPHI,tendichvu,DVT,ISVATTU,Nhom order by TenDichVu";
                SQLCmd.CommandText = Str;
                SQLCmd.CommandTimeout = 0;
                dr = SQLCmd.ExecuteReader();
                fg.Rows.Fixed = 0;
                fg.Rows.Count = 1;
                fg.Rows.Fixed = 1;
                while (dr.Read())
                {
                    fg.Rows.Add();
                    fg[fg.Rows.Count - 1, "STT"] = fg.Rows.Count-1;
                    fg[fg.Rows.Count - 1, "MaVT"] = dr["MaChiPhi"];
                    fg[fg.Rows.Count - 1, "TenVT"] = dr["Tendichvu"];
                    fg[fg.Rows.Count - 1, "DVT"] = dr["dvt"];
                    fg[fg.Rows.Count - 1, "SoLuongDK"] = dr["SoLuongDK"];
                    fg[fg.Rows.Count - 1, "SoLuongTK"] = dr["SoLuongTK"];
                    fg[fg.Rows.Count - 1, "SoLuongDC"] = dr["SoLuongDC"];
                    fg[fg.Rows.Count - 1, "TongSL"] = decimal.Parse(dr["SoLuongDK"].ToString()) + decimal.Parse(dr["SoLuongTK"].ToString()) - decimal.Parse(dr["SoLuongDSD"].ToString()) - decimal.Parse(dr["SoLuongDC"].ToString());
                    fg[fg.Rows.Count - 1, "SoLuongDSD"] = dr["SoLuongDSD"];
                    fg[fg.Rows.Count - 1, "IsVatTu"] = dr["IsVatTu"];
                    fg[fg.Rows.Count - 1, "Nhom"] = dr["Nhom"];
                }
                dr.Close();
            }
            catch(Exception e)
            {
                MessageBox.Show("Lỗi: " + e.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                fg.Redraw = true;
                SQLCmd.Dispose();
            }
        }

        private void frmVatTu_Load(object sender, EventArgs e)
        {
            Global.wait("Đang tổng hợp dữ liệu.");
            fg.Tag = 0;
            LoatDanhMuc();
            fg.Cols["MaVT"].AllowEditing = fg.Cols["TenVT"].AllowEditing = fg.Cols["DVT"].AllowEditing =
                fg.Cols["TongSL"].AllowEditing = fg.Cols["SoLuongTK"].AllowEditing =  false;
            fg.Cols["SoLuongDSD"].AllowEditing = false;
            txtNgayChot.Value = Global.NgayLV;
            LoatData();
            fg.Tag = 1;
            AllowEdit(false);
            Global.nowait();
        }

        private void cmdThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (cmbVatTu.SelectedIndex == -1)
            {
                MessageBox.Show("Chọn vật tư.", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbVatTu.Focus();
                return;
            }
            for (int i = 1; i < fg.Rows.Count; i++)
            {
                if (cmbVatTu.Columns[2].CellText(cmbVatTu.SelectedIndex) == fg.GetDataDisplay(i, "MaVT"))
                {
                    MessageBox.Show("Vật tư này đã có.", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            fg.Tag = 0;
            fg.Rows.Add();
            fg[fg.Rows.Count - 1, "MaVT"] = cmbVatTu.Columns[2].CellValue(cmbVatTu.SelectedIndex);
            fg[fg.Rows.Count - 1, "TenVT"] = cmbVatTu.Columns[0].CellValue(cmbVatTu.SelectedIndex);
            fg[fg.Rows.Count - 1, "DVT"] = cmbVatTu.Columns[1].CellValue(cmbVatTu.SelectedIndex);
            fg[fg.Rows.Count - 1, "SoLuongTK"] = 0;
            fg[fg.Rows.Count - 1, "SoLuongDK"] = 0;
            fg[fg.Rows.Count - 1, "SoLuongTK"] = 0;
            fg[fg.Rows.Count - 1, "SoLuongDSD"] = 0;
            fg[fg.Rows.Count - 1, "TongSL"] = 0;
            fg[fg.Rows.Count - 1, "Nhom"] = 0;
            fg.Tag = 1;
        }

        private void cmdGhi_Click(object sender, EventArgs e)
        {
            String Str = "";
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            try
            {
                Global.wait("Đang tổng hợp dữ liệu");
                Str = String.Format(" DELETE FROM VATTU WHERE MAKHOA='{0}'", Global.GetCode(cmbKhoa));
                for (int i = 1; i < fg.Rows.Count; i++)
                {
                    Str += String.Format(" INSERT INTO VATTU(MAKHOA,SOLUONGDK,SOLUONGDC,MACHIPHI,NGAYCHOT,ISVATTU,Nhom) "
                        + " VALUES('{1}',{2},{3},'{0}','{4:MM/dd/yyyy}',{5},{6})",
                        fg.GetDataDisplay(i, "MaVT"),
                        Global.GetCode(cmbKhoa),
                        (fg.GetDataDisplay(i, "SoLuongDK") == "") ? ("0") : (fg.GetData(i, "SoLuongDK").ToString().Replace(",", ".")),
                        (fg.GetDataDisplay(i, "SoLuongDC") == "") ? ("0") : (fg.GetData(i, "SoLuongDC").ToString().Replace(".", "").Replace(",", ".")),
                        txtNgayChot.Value,
                        fg.GetDataDisplay(i, "IsVatTu") == "" ? "1" : fg.GetDataDisplay(i, "IsVatTu").Substring(0, 1), fg.GetDataDisplay(i, "Nhom"));
                }
                if (Str == "") return;
                SQLCmd.CommandText = Str;
                SQLCmd.ExecuteNonQuery();
                //fg.Tag = 0;
                //LoatData();
                //fg.Tag = 1;
                AllowEdit(false);
                Global.nowait();
            }
            catch (Exception ex)
            {
                Global.nowait();
                MessageBox.Show("Lỗi: " + ex.ToString(), "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SQLCmd.Dispose();
            }
        }

        private void cmdChot_Click(object sender, EventArgs e)
        {
            String Str = "";
            SqlDataReader dr;
            System.Data.SqlClient.SqlTransaction tr;
            tr = Global.ConnectSQL.BeginTransaction();
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            SQLCmd.Transaction = tr;
            DateTime NgayChot1 = DateTime.Parse(DateTime.Parse(txtNgayChot.Value.ToString()).ToShortDateString());
            System.TimeSpan NgayDT = NgayChotGanNhat - NgayChot1;
            try
            {
                if (fg.Rows.Count <= 1) return;
                if (cmdChot.Text == "Chốt")
                {
                    if (NgayDT.Days > 0)
                    {
                        MessageBox.Show("Ngày chọn phải sau ngày chốt gần nhất!");
                        return;
                    }
                    for (int i = 1; i < fg.Rows.Count; i++)
                    {
                        Str += String.Format(" UPDATE VATTU SET SOLUONGDK = {0},SOLUONGDC = 0,NGAYCHOT='{3:MM/dd/yyyy}' WHERE MAKHOA ='{1}' AND MACHIPHI ='{2}' ",
                            fg.GetDataDisplay(i, "TongSL").ToString().Replace(",",".") == "0" ? "0" : fg.GetData(i, "TongSL").ToString().Replace(",","."),
                            Global.GetCode(cmbKhoa),
                            fg.GetDataDisplay(i, "MaVT"),
                            txtNgayChot.Value);

                        Str += String.Format(" INSERT INTO VETVATTU(MAKHOA,SOLUONGDK,SOLUONGTK,MACHIPHI,NGAYCHOT,SOLUONGDSD,SOLUONGDC)"
                            + " VALUES('{0}',{1},{2},'{3}','{4:MM/dd/yyyy}',{5},{6})",
                            Global.GetCode(cmbKhoa),
                            fg.GetDataDisplay(i, "SoLuongDK").Replace(",", ".") == "0" ? "0" : fg.GetData(i, "SoLuongDK").ToString().Replace(",", "."),
                            fg.GetDataDisplay(i, "SoLuongTK").Replace(",", ".") == "0" ? "0" : fg.GetData(i, "SoLuongTK").ToString().Replace(",", "."),
                            fg.GetDataDisplay(i, "MaVT"),
                            txtNgayChot.Value,
                            fg.GetDataDisplay(i, "SoLuongDSD").Replace(",", ".") == "0" ? "0" : fg.GetData(i, "SoLuongDSD").ToString().Replace(",", "."),
                            fg.GetDataDisplay(i, "SoLuongDC").Replace(",", ".") == "0" ? "0" : fg.GetData(i, "SoLuongDC").ToString().Replace(",", "."));
                    }
                    if (Global.GetCode(cmbKhoa) == "NV1103")
                    {
                        Str += String.Format(" UPDATE BENHNHAN_PT_CHIPHI SET CHOT = 1,NGAYCHOT ='{0:MM/dd/yyyy}' WHERE LOAICHIPHI IN ('D02','D06') AND Chot = 0 And "
                        + " datediff(dd,NgayChiDinh,'{0:MM/dd/yyyy}') >= 0 ", txtNgayChot.Value);
                    }
                    else
                    {
                        Str += String.Format(" UPDATE PHIEUDIEUTRI_CHITIET SET CHOT = 1,NGAYCHOT ='{1:MM/dd/yyyy}' WHERE LOAIDICHVU IN ('D02','D06') AND Chot = 0 And "
                            + " SOPHIEU IN (SELECT SOPHIEU FROM "
                            + " (SELECT * FROM BENHNHAN_CHITIET ) AA "
                            + " INNER JOIN BENHNHAN_PHIEUDIEUTRI ON BENHNHAN_PHIEUDIEUTRI.MAVAOVIEN = AA.MAVAOVIEN "
                            + " WHERE MAKHOA ='{0}' and datediff(dd,NgayChiDinh,'{1:MM/dd/yyyy}') >= 0 )",
                            Global.GetCode(cmbKhoa),txtNgayChot.Value);
                        Str += String.Format(" Update CHIPHI_THUTHUAT Set Chot = 1,DaThucHien = 1,NgayChot='{0:MM/dd/yyyy}' "
                            + " Where LoaiDichVu IN ('D02','D06') and Chot = 0 And MaKhoa='{1}' and datediff(dd,NgayThucHien,'{0:MM/dd/yyyy}') >= 0",
                            txtNgayChot.Value, Global.GetCode(cmbKhoa));
                        Str += String.Format(" Update DuTruVatTu Set DaChot = 1,NgayChot='{0:MM/dd/yyyy}' "
                            + " Where MaKhoa='{1}' and datediff(dd,Ngay,'{0:MM/dd/yyyy}') >= 0",
                            txtNgayChot.Value, Global.GetCode(cmbKhoa));
                    }
                }
                else
                {
                    //Huy chot
                    if (NgayDT.Days != 0)
                    {
                        MessageBox.Show("Ngày chọn phải là ngày chốt gần nhất!");
                        return;
                    }
                    Str += String.Format(" DELETE FROM VATTU WHERE MAKHOA ='{0}'"
                        + " INSERT INTO VATTU(MAKHOA,SOLUONGDK,SOLUONGDC,MACHIPHI,NGAYCHOT,IsVatTu)"
                        + " SELECT MAKHOA,SOLUONGDK,SOLUONGDC,MACHIPHI,NGAYCHOT,1 FROM VETVATTU WHERE MAKHOA ='{0}' AND DATEDIFF(DD,NGAYCHOT,'{1:MM/dd/yyyy}') = 0 ",
                            Global.GetCode(cmbKhoa),
                            txtNgayChot.Value);

                    Str += String.Format(" DELETE FROM VETVATTU WHERE MAKHOA ='{0}' AND DATEDIFF(DD,NGAYCHOT,'{1:MM/dd/yyyy}') = 0 ",
                        Global.GetCode(cmbKhoa),
                        txtNgayChot.Value);
                    Str += String.Format(" Update VatTu set NgayChot=(select Max(NgayChot) FROM VETVATTU WHERE MAKHOA ='{0}' AND DATEDIFF(DD,NGAYCHOT,'{1:MM/dd/yyyy}') > 0) where MaKhoa='{0}'",
                        Global.GetCode(cmbKhoa),
                        txtNgayChot.Value);
                    if (Global.GetCode(cmbKhoa) == "NV1103")
                    {
                        Str += String.Format(" UPDATE BENHNHAN_PT_CHIPHI SET CHOT = 0,NGAYCHOT = NULL,DATHUCHIEN = 0 WHERE LOAICHIPHI IN ('D02','D06') AND DATEDIFF(DD,NGAYCHOT,'{0:MM/dd/yyyy}') = 0",
                        txtNgayChot.Value);
                    }
                    else
                    {
                        Str += String.Format(" UPDATE PHIEUDIEUTRI_CHITIET SET CHOT = 0,NGAYCHOT = NULL WHERE LOAIDICHVU IN ('D02','D06') AND DATEDIFF(DD,PHIEUDIEUTRI_CHITIET.NGAYCHOT,'{1:MM/dd/yyyy}') = 0 AND "
                            + " SOPHIEU IN (SELECT SOPHIEU FROM "
                            + " (SELECT * FROM BENHNHAN_CHITIET ) AA "
                            + " INNER JOIN BENHNHAN_PHIEUDIEUTRI ON BENHNHAN_PHIEUDIEUTRI.MAVAOVIEN = AA.MAVAOVIEN "
                            + " WHERE MAKHOA ='{0}')",
                            Global.GetCode(cmbKhoa),
                            txtNgayChot.Value);
                        Str += String.Format(" Update CHIPHI_THUTHUAT Set Chot = 0,NgayChot= NULL Where LoaiDichVu IN ('D02','D06') and Chot = 1 And MaKhoa='{1}' AND DATEDIFF(DD,NGAYCHOT,'{0:MM/dd/yyyy}') = 0",
                           txtNgayChot.Value, Global.GetCode(cmbKhoa));
                        Str += String.Format(" Update DuTruVatTu Set DaChot = 0,NgayChot=null"
                            + " Where MaKhoa='{1}' and datediff(dd,NgayChot,'{0:MM/dd/yyyy}') = 0",
                            txtNgayChot.Value, Global.GetCode(cmbKhoa));
                    }
                }
                if (Str == "") return;
                SQLCmd.CommandText = Str;
                SQLCmd.CommandTimeout = 0;
                SQLCmd.ExecuteNonQuery();
                tr.Commit();
                //Str = string.Format("Select max(NgayChot) as NgayChot from VetVatTu where makhoa ='{0}'",
                //    Global.GetCode(cmbKhoa));
                //SQLCmd.CommandText = Str;
                //dr = SQLCmd.ExecuteReader();
                //if (dr.HasRows)
                //{
                //    while (dr.Read())
                //    {
                //        if (dr["NgayChot"].ToString() == "") NgayChotGanNhat = DateTime.Parse("01/01/2000");
                //        else NgayChotGanNhat = DateTime.Parse(dr["NgayChot"].ToString());
                //        lblChotSoGanNhat.Text = string.Format("Lần chốt sổ gần nhất:{0:dd/MM/yyyy}", NgayChotGanNhat);
                //    }
                //}
                //dr.Close();
                fg.Tag = 0;
                LoatData();
                fg.Tag = 1;
            }
            catch(Exception ex)
            {
                tr.Rollback();
                MessageBox.Show("Lỗi: " + ex.ToString(), "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                tr.Dispose();
                SQLCmd.Dispose();
            }
        }

        private void fg_AfterEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            if (fg.Tag.ToString() == "0") return;
            fg[e.Row, "TongSL"] = decimal.Parse(fg.GetDataDisplay(e.Row, "SoLuongDK")) + decimal.Parse(fg.GetDataDisplay(e.Row, "SoLuongTK")) - decimal.Parse(fg.GetDataDisplay(e.Row, "SoLuongDSD")) - decimal.Parse(fg.GetDataDisplay(e.Row, "SoLuongDC"));
        }

        private void fg_AfterRowColChange(object sender, C1.Win.C1FlexGrid.RangeEventArgs e)
        {
            if (fg.Tag.ToString() == "0") return;
            if (cmdGhi.Visible == true) return;
            if(e.OldRange.c2 != fg.Cols["SoLuongTK"].Index) return;
            if (decimal.Parse(fg.GetDataDisplay(e.OldRange.r2, "SoLuongTK")) < 0)
            {
                MessageBox.Show("Số lượng không lợp lệ.", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                fg.Select(e.OldRange.r2, e.OldRange.c2);
                e.Cancel = true;
            }
        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Reports.repKiemKeVT rpt = new NamDinh_QLBN.Reports.repKiemKeVT(cmbKhoa.Text, Global.GetCode(cmbKhoa), txtNgayChot.Value);
            rpt.Show();
        }

        private void fg_BeforeDeleteRow(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            fg.Redraw = true;
            if (cmdChot.Text == "Hũy chốt")
            {
                MessageBox.Show("đã chốt bạn không được xóa.", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                fg.Tag = 1;
                e.Cancel = true;
            }
            if (MessageBox.Show("Bạn có muốn xóa không.", "Thông báo.", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                fg.Tag = 0;
            }
            else
            {
                fg.Tag = 1;
                e.Cancel = true;
            }
        }

        private void cmdSua_Click(object sender, EventArgs e)
        {
            AllowEdit(true);
            btn = 0;
        }

        private void cmdInPhieuLinh_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.DuLieu.frmDuTruVatTu frm = new frmDuTruVatTu();
            frm.Show();
            frm.MdiParent = this.MdiParent;
            frm.WindowState = FormWindowState.Maximized;
        }

        private void txtNgayChot_ValueChanged(object sender, EventArgs e)
        {
            if (fg.Tag.ToString() == "0") return;
            String Str = "";
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            Global.wait("Đang tổng hợp dữ liệu ...!");
            try
            {
                txtNgayChot.ReadOnly = false;
                cmdChot.Text = "Chốt";
                cmdPrint.Enabled = false;
                DateTime NgayChot1 = DateTime.Parse(txtNgayChot.Value.ToString());
                System.TimeSpan NgayDT = NgayChotGanNhat - NgayChot1;
                if (NgayDT.Days >= 0)
                {
                    //txtNgayChot.Value = NgayChotGanNhat;
                    //txtNgayChot.ReadOnly = true;
                    cmdChot.Text = "Hủy chốt";
                    cmdPrint.Enabled = true;
                }
                else {
                    cmdChot.Text = "Chốt";
                    cmdPrint.Enabled = false;
                }
                fg.Tag = 0;
                LoatData();
                fg.Tag = 1;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                Global.nowait();
                SQLCmd.Dispose();
            }
        }

        private void frmVatTu_KeyDown(object sender, KeyEventArgs e)
        {
            if (cmbVatTu.Enabled == false) return;
            if (e.KeyCode == Keys.F5)
            {
                simpleButton1_Click(sender, e);
            }
        }

        private void cmbKhongGhi_Click(object sender, EventArgs e)
        {
            LoatData();
            AllowEdit(false);
        }

        private void btnXoaTonDauKy_Click(object sender, EventArgs e)
        {
            AllowEdit(true);
            for (int i = 1; i < fg.Rows.Count; i++)
            {
                fg.SetData(i, "SoLuongDK", 0);
                fg[i, "TongSL"] = decimal.Parse(fg.GetDataDisplay(i, "SoLuongDK")) + decimal.Parse(fg.GetDataDisplay(i, "SoLuongTK")) - decimal.Parse(fg.GetDataDisplay(i, "SoLuongDSD"));
            }
        }
    }
}