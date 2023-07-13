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
    public partial class frmDuTruVatTu : Form
    {
        int btn = 0; // 0: them, 1 sua
        DateTime NgayChotGanNhat;
        string MaPhieuDuTru = "";
        public frmDuTruVatTu()
        {
            InitializeComponent();
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
                string strcmb = "0-In trên sổ y lệnh|1-Không in";
                fg.Cols["isVatTu"].ComboList = strcmb;
                string str = string.Format("set dateformat dmy Select max(NgayChot) as NgayChot from VetVatTu where makhoa ='{0}'",
                    Global.GetCode(cmbKhoa));
                SQLCmd.CommandText = str;
                dr = SQLCmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        if (dr["NgayChot"].ToString() == "") NgayChotGanNhat=DateTime.Parse("01/01/2000");
                        else NgayChotGanNhat = DateTime.Parse(dr["NgayChot"].ToString());
                        lblChotSoGanNhat.Text = string.Format("Lần chốt sổ gần nhất:{0:dd/MM/yyyy}", NgayChotGanNhat);
                    }
                }
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
            String Str = "";
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            try
            {
                fg.Redraw = false;
                Str = string.Format("set dateformat dmy SELECT VATTU.MACHIPHI,VATTU.MAKHOA,sum(isnull(SoLuong,0)) AS SoLuongDSD,A.tendichvu,A.dvt,CASE  WHEN VATTU.ISVATTU = 0 THEN N'0-In trên sổ y lệnh' ELSE N'1-Không in'  END AS ISVATTU,x.KhoID,a.LoaiDichVu"
                      + " FROM VATTU inner join DMKHOAPHONG pk on vattu.MaKhoa=pk.MaKhoa left JOIN (select pc.*,bp.MaKhoa from PHIEUDIEUTRI_CHITIET pc inner JOIN BENHNHAN_PHIEUDIEUTRI bp ON bp.SoPhieu = pc.SoPhieu "
                      + " WHERE bp.MaKhoa='{0}' AND DATEDIFF(DD,NGAYCHIDINH,'{1:dd/MM/yyyy}') <= 0 AND pc.Chot =0) x "
                      + " on vattu.MaChiPhi=x.MaDichVu AND VatTu.MAKHOA =x.MaKhoa INNER JOIN DMDichVu A ON A.madichvu = VATTU.MACHIPHI"
                      + " WHERE VatTu.MAKHOA='{0}' and A.KhongSuDung=0 and (pk.IsLinhVT=1 and A.LoaiDichVu='D02' or A.LoaiDichVu='D06' or pk.IsLinhVT=0)"
                      + " GROUP BY vattu.MAKHOA,vattu.MACHIPHI,tendichvu,DVT,ISVATTU,x.KhoID,a.LoaiDichVu order by TenDichVu", Global.GetCode(cmbKhoa), NgayChotGanNhat);
                SQLCmd.CommandText = Str;
                SQLCmd.CommandTimeout = 0;
                dr = SQLCmd.ExecuteReader();
                fg.Rows.Fixed = 1;
                fg.Rows.Count = 1;
                while (dr.Read())
                {
                    fg.Rows.Add();
                    fg[fg.Rows.Count - 1, "STT"] = fg.Rows.Count-1;
                    fg[fg.Rows.Count - 1, "MaVT"] = dr["MaChiPhi"];
                    fg[fg.Rows.Count - 1, "TenVT"] = dr["Tendichvu"];
                    fg[fg.Rows.Count - 1, "DVT"] = dr["dvt"];
                    fg[fg.Rows.Count - 1, "SLDuTru"] = 0;
                    fg[fg.Rows.Count - 1, "SoLuongDSD"] = dr["SoLuongDSD"];
                    fg[fg.Rows.Count - 1, "IsVatTu"] = dr["IsVatTu"];
                    fg[fg.Rows.Count - 1, "KhoID"] = dr["KhoID"];
                    fg[fg.Rows.Count - 1, "LoaiDichVu"] = dr["LoaiDichVu"];
                }
                dr.Close();
            }
            catch(Exception e)
            {
                MessageBox.Show("Lỗi: " + e.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                fg.Redraw = true;
                SQLCmd.Dispose();
            }
        }
        private void LoadPhieuDuTru(string MaPhieu)
        {
            String Str = "";
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            try
            {
                fgDSPhieu.Redraw = false;
                Str = string.Format(" SELECT dt.Ngay,dt.HinhThuc, dt.MaChiPhi,SoLuongYC as SLDuTru,A.tendichvu,A.dvt,CASE "
                     + " WHEN VATTU.ISVATTU = 0 THEN N'0-In trên sổ y lệnh' ELSE N'1-Không in' END AS ISVATTU,dt.KhoID,dt.LoaiDichVu"
                     + " FROM VATTU left JOIN DuTruVatTu dt ON VatTu.MACHIPHI = dt.MACHIPHI and VatTu.MaKhoa=dt.MaKhoa"
                     + " INNER JOIN dmdichvu A ON A.madichvu = VATTU.MACHIPHI "
                     + " WHERE MaPhieuDuTru='{0}'"
                     + " order by TenDichVu", MaPhieu);
                SQLCmd.CommandText = Str;
                SQLCmd.CommandTimeout = 0;
                dr = SQLCmd.ExecuteReader();
                fg.Rows.Count = 1;
                fg.Rows.Fixed = 1;
                while (dr.Read())
                {
                    txtNgayDuTru.Value = DateTime.Parse(dr["Ngay"].ToString());
                    fg.Rows.Add();
                    fg[fg.Rows.Count - 1, "STT"] = fg.Rows.Count - 1;
                    fg[fg.Rows.Count - 1, "MaVT"] = dr["MaChiPhi"];
                    fg[fg.Rows.Count - 1, "TenVT"] = dr["Tendichvu"];
                    fg[fg.Rows.Count - 1, "DVT"] = dr["dvt"];
                    fg[fg.Rows.Count - 1, "SLDuTru"] = dr["SLDuTru"];
                    fg[fg.Rows.Count - 1, "IsVatTu"] = dr["IsVatTu"];
                    fg[fg.Rows.Count - 1, "KhoID"] = dr["KhoID"];
                    fg[fg.Rows.Count - 1, "LoaiDichVu"] = dr["LoaiDichVu"];
                    cmbHinhThuc.SelectedIndex = int.Parse(dr["HinhThuc"].ToString());
                }
                dr.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi: " + e.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                fgDSPhieu.Redraw = true;
                SQLCmd.Dispose();
            }
        }
        private void DeltePhieuDuTru(string MaPhieu)
        {
            String Str = "";
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            try
            {
                fgDSPhieu.Redraw = false;
                Str = string.Format(" Delete FROM DuTruVatTu WHERE MaPhieuDuTru='{0}'", MaPhieu);
                SQLCmd.CommandText = Str;
                SQLCmd.CommandTimeout = 0;
                SQLCmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi: " + e.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                fgDSPhieu.Redraw = true;
                SQLCmd.Dispose();
            }
        }
        private void frmVatTu_Load(object sender, EventArgs e)
        {
            Global.wait("Đang tổng hợp dữ liệu.");
            fg.Tag = 0;
            cmbHinhThuc.SelectedIndex = 0;
            cmbHinhThuc.Enabled = false;
            LoatDanhMuc();
            fg.Cols["MaVT"].AllowEditing = fg.Cols["TenVT"].AllowEditing = fg.Cols["DVT"].AllowEditing =
                fg.Cols["SoLuongDSD"].AllowEditing = false;
            fg.Cols["SLDuTru"].AllowEditing = true;
            fg.Cols["KhoID"].Visible = false;
            txtTuNgay.Value = Global.NgayLV;
            txtDenNgay.Value = Global.NgayLV;
            txtNgayDuTru.Value = Global.NgayLV;
            LoatData();
            fg.Tag = 1;
            Global.nowait();
        }

        private void cmdThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string LayMaDuTru()
        {
            String Str = "";
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
            try
            {
                Str = " exec NamDinh_Duoc.dbo.GetNextChungTuID 'DT',@s output";
                SqlParameter s = new SqlParameter("@s", SqlDbType.VarChar, 11);
                s.Direction = ParameterDirection.Output;
                SQLCmd.Parameters.Add(s);
                SQLCmd.CommandText = Str;
                SQLCmd.CommandTimeout = 0;
                SQLCmd.ExecuteNonQuery();
                return s.Value.ToString();
                //trn.Commit();
            }
            catch (Exception ex)
            {
                //trn.Rollback();
                return "";
            }
            finally
            {
                SQLCmd.Dispose();
                //trn.Dispose();
            }
        }
        private bool Check_Valid()
        {
            if (fgDSPhieu.Rows.Count == 1)
            {
                MessageBox.Show("Bạn phải tìm kiếm phiếu rồi mới có thể sửa!");
                return false;
            }
            if (fgDSPhieu.GetCellCheck(fgDSPhieu.Row,fgDSPhieu.Cols["DaDuyet"].Index) == C1.Win.C1FlexGrid.CheckEnum.Checked)
            {
                MessageBox.Show("Phiếu này đã được phòng vật tư duyệt, không thể sửa, xóa!");
                return false;
            }
            return true;
        }
        private void cmdSua_Click(object sender, EventArgs e)
        {
            btn = 1;
            //grTimKiem.Enabled = true;
            btnThem.Visible = false;
            btnSua.Visible = false;
            btnThoat.Visible = false;
            btnGhi.Visible = true;
            btnHuy.Visible = true;
            txtNgayDuTru.Enabled = true;
            fg.Cols["SoLuongDSD"].Visible = false;
        }

        private void cmdTim_Click(object sender, EventArgs e)
        {
            String Str = "";
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            try
            {
                fgDSPhieu.Redraw = false;
                Str = string.Format("set dateformat dmy SELECT distinct MaPhieuDuTru,Ngay,DaDuyet,DaChot from DuTruVatTu where MaKhoa='{0}' and DATEDIFF(DD,Ngay,'{1:dd/MM/yyyy}') >= 0 "
                     + " and DATEDIFF(DD,Ngay,'{2:dd/MM/yyyy}') <= 0 ",Global.GetCode(cmbKhoa), txtDenNgay.Value, txtTuNgay.Value);
                SQLCmd.CommandText = Str;
                SQLCmd.CommandTimeout = 0;
                dr = SQLCmd.ExecuteReader();
                fgDSPhieu.Rows.Fixed = 1;
                fgDSPhieu.Rows.Count = 1;
                while (dr.Read())
                {
                    fgDSPhieu.Rows.Add();
                    fgDSPhieu[fgDSPhieu.Rows.Count - 1, "STT"] = fgDSPhieu.Rows.Count - 1;
                    fgDSPhieu[fgDSPhieu.Rows.Count - 1, "MaPhieuDuTru"] = dr["MaPhieuDuTru"].ToString();
                    fgDSPhieu[fgDSPhieu.Rows.Count - 1, "Ngay"] = dr["Ngay"].ToString();
                    if (dr["DaDuyet"].ToString() == "1") fgDSPhieu.SetCellCheck(fgDSPhieu.Rows.Count - 1, fgDSPhieu.Cols["DaDuyet"].Index, C1.Win.C1FlexGrid.CheckEnum.Checked);
                    else fgDSPhieu.SetCellCheck(fgDSPhieu.Rows.Count-1, fgDSPhieu.Cols["DaDuyet"].Index, C1.Win.C1FlexGrid.CheckEnum.Unchecked);
                    if (dr["DaChot"].ToString() == "1") fgDSPhieu.SetCellCheck(fgDSPhieu.Rows.Count - 1, fgDSPhieu.Cols["DaChot"].Index, C1.Win.C1FlexGrid.CheckEnum.Checked);
                    else fgDSPhieu.SetCellCheck(fgDSPhieu.Rows.Count - 1, fgDSPhieu.Cols["DaChot"].Index, C1.Win.C1FlexGrid.CheckEnum.Unchecked);
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                fgDSPhieu.Redraw = true;
                SQLCmd.Dispose();
            }
        }


        private void fg_BeforeDeleteRow(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            fg.Redraw = true;
            if (cmdTim.Text == "Hũy chốt")
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


        private void btnThem_Click(object sender, EventArgs e)
        {
            btn = 0;
            //grTimKiem.Enabled = false;
            btnThem.Visible = false;
            btnSua.Visible = false;
            btnGhi.Visible = true;
            btnHuy.Visible = true;
            btnThoat.Visible = false;
            txtNgayDuTru.Enabled = true;
            //reload
            fg.Cols["SoLuongDSD"].Visible = true;
            LoatData();
        }

        private void fgDSPhieu_Click(object sender, EventArgs e)
        {
            MaPhieuDuTru = fgDSPhieu.GetData(fgDSPhieu.Row, "MaPhieuDuTru").ToString();
            LoadPhieuDuTru(MaPhieuDuTru);
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            if (btn == 0)//them moi
            {
                MaPhieuDuTru = LayMaDuTru();
                System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand(); 
                try
                {
                    Global.wait("Đang tổng hợp dữ liệu");
                    for (int i = 1; i < fg.Rows.Count; i++)
                    {
                        if (fg.GetData(i, "SLDuTru").ToString() == "0") continue;
                        SQLCmd = new System.Data.SqlClient.SqlCommand();
                        SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
                        SQLCmd.CommandType = CommandType.StoredProcedure;
                        SQLCmd.CommandText = "AddDuTruVatTu";
                        SQLCmd.CommandTimeout = 0;
                        SqlParameter param0 = new SqlParameter("@MaPhieuDuTru", SqlDbType.VarChar, 11);
                        param0.Value = MaPhieuDuTru;
                        SQLCmd.Parameters.Add(param0);
                        SqlParameter param1 = new SqlParameter("@PhongKhoaID", SqlDbType.VarChar, 10);
                        param1.Value = Global.GetCode(cmbKhoa);
                        SQLCmd.Parameters.Add(param1);
                        SqlParameter param2 = new SqlParameter("@Ngay", SqlDbType.DateTime);
                        param2.Value = DateTime.Parse(DateTime.Parse(txtNgayDuTru.Value.ToString()).ToShortDateString());
                        SQLCmd.Parameters.Add(param2);
                        SqlParameter param3 = new SqlParameter("@LoaiDichVu", SqlDbType.VarChar,5);
                        param3.Value = fg.GetData(i, "LoaiDichVu");
                        SQLCmd.Parameters.Add(param3);
                        SqlParameter param4 = new SqlParameter("@SLDuTru", SqlDbType.Int);
                        param4.Value = fg.GetData(i, "SLDuTru");
                        SQLCmd.Parameters.Add(param4);
                        SqlParameter param5 = new SqlParameter("@MaVatTu", SqlDbType.VarChar,15);
                        param5.Value = fg.GetData(i, "MaVT");
                        SQLCmd.Parameters.Add(param5);
                        SqlParameter param6 = new SqlParameter("@HinhThuc", SqlDbType.Int);
                        param6.Value = cmbHinhThuc.SelectedIndex;
                        SQLCmd.Parameters.Add(param6);
                        SQLCmd.ExecuteNonQuery();
                    }
                    Global.nowait();
                }
                catch (Exception ex)
                {
                    Global.nowait();
                    MessageBox.Show("Lỗi: " + ex.Message, "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    SQLCmd.Dispose();
                    //in phieu
                    NamDinh_QLBN.Reports.rptPhieuLinhVT rpt = new NamDinh_QLBN.Reports.rptPhieuLinhVT(cmbKhoa.Text, Global.GetCode(cmbKhoa), MaPhieuDuTru, DateTime.Parse(txtNgayDuTru.Value.ToString()).ToShortDateString());
                    rpt.Show();
                }
            }
            else
            {
                if (!Check_Valid()) return;
                String Str = "";
                System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
                SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
                try
                {
                    Global.wait("Đang tổng hợp dữ liệu");
                    for (int i = 1; i < fg.Rows.Count; i++)
                    {
                        Str += String.Format(" Update DuTruVatTu set SoLuongYC={0:#},Ngay='{3:dd/MM/yyyy}' where MaPhieuDuTru='{1}' and MaChiPhi='{2}'", fg.GetData(i, "SLDuTru"), MaPhieuDuTru, fg.GetData(i, "MaVT"),txtNgayDuTru.Value);
                    }
                    if (Str == "") return;
                    SQLCmd.CommandText = Str;
                    SQLCmd.ExecuteNonQuery();
                    Global.nowait();
                }
                catch (Exception ex)
                {
                    Global.nowait();
                    MessageBox.Show("Lỗi: " + ex.Message, "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    SQLCmd.Dispose();
                    //in phieu
                    NamDinh_QLBN.Reports.rptPhieuLinhVT rpt = new NamDinh_QLBN.Reports.rptPhieuLinhVT(cmbKhoa.Text, Global.GetCode(cmbKhoa), MaPhieuDuTru, DateTime.Parse(txtNgayDuTru.Value.ToString()).ToShortDateString());
                    rpt.Show();
                }
            }
            btnThem.Visible = true;
            btnSua.Visible = true;
            btnGhi.Visible = false;
            btnHuy.Visible = false;
            btnThoat.Visible = true;
            //grTimKiem.Enabled = true;
            txtNgayDuTru.Enabled = false;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            btnThem.Visible = true;
            btnSua.Visible = true;
            btnThoat.Visible = true;
            btnGhi.Visible = false;
            btnHuy.Visible = false;
            //grTimKiem.Enabled = true;
            txtNgayDuTru.Enabled = false;
        }

        private void fgDSPhieu_BeforeDeleteRow(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            if (fgDSPhieu.GetCellCheck(fgDSPhieu.Row, fgDSPhieu.Cols["DaDuyet"].Index) == C1.Win.C1FlexGrid.CheckEnum.Checked)
            {
                MessageBox.Show("Phiếu này đã được phòng vật tư duyệt, không thể sửa, xóa");
                return;
            }
            if (MessageBox.Show("Bạn có chắc chắn xóa phiếu dự trù này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DeltePhieuDuTru(fgDSPhieu.GetDataDisplay(fgDSPhieu.Row,"MaPhieuDuTru"));
                fg.Rows.Count = 1;
            }
        }

        private void btnTongHop_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.DuLieu.frmVatTu fr = new NamDinh_QLBN.Forms.DuLieu.frmVatTu();
            fr.MdiParent = this.MdiParent;
            fr.Show();
            fr.WindowState = FormWindowState.Maximized;
            DaleteFrom(fr);
        }
        private void DaleteFrom(Form frm)
        {
            foreach (Form f in this.MdiParent.MdiChildren)
            {
                if (f != frm && f != Global.pWork)
                {
                    f.Close();
                }
            }
        }

    }
}