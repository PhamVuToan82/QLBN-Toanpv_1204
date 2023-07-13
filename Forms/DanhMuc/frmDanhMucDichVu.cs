using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GlobalModuls;

namespace NamDinh_QLBN.Forms.DanhMuc
{
    public partial class frmDanhMucDichVu : Form
    {
        private bool IsAddNew = false;
        public frmDanhMucDichVu()
        {
            InitializeComponent();
        }

        private void frmDanhMucDichVu_Load(object sender, EventArgs e)
        {
            fg.Tag = "1";
            cmbLoaiDichVu.Tag = "1";
            fg.ClipSeparators = "|;";
            C1.Win.C1FlexGrid.CellStyle cs = fg.Styles["EmptyArea"];
            cs.BackColor = Color.FromArgb(156, 186, 239);            
            Load_CacDanhMuc();
            Lock_Edit(true);
        }
        private void Load_CacDanhMuc()
        {
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
            SQLCmd.CommandText = "SELECT * FROM DMLOAIDICHVU WHERE MaLoaiDichVu BETWEEN 'C01' AND 'C999' OR MaLoaiDichVu = 'E04'";
            System.Data.SqlClient.SqlDataReader dr = SQLCmd.ExecuteReader();
            cmbLoaiDichVu.Tag = "0";
            while (dr.Read())
            {
                cmbLoaiDichVu.AddItem(string.Format("{0};{1}", dr["MaLoaiDichVu"], dr["TenLoaiDichVu"]));
            }
            dr.Close();            
            cmbLoaiDichVu.SelectedIndex = -1;
            cmbLoaiDichVu.Tag = "1";
            SQLCmd.CommandText = "SELECT * FROM DMNHOMDICHVU_BHYT";
            dr = SQLCmd.ExecuteReader();            
            while (dr.Read())
            {
                cmbNhomBHYT.AddItem(string.Format("{0};{1}", dr["MaNhom"], dr["TenNhom"]));
            }
            dr.Close();
            SQLCmd.CommandText = "SELECT * FROM DMLOAIPHAUTHUAT where maloaiPT not in ('12','13','22','23')";
            dr = SQLCmd.ExecuteReader();
            while (dr.Read())
            {
                cmbLoaiPT.AddItem(string.Format("{0};{1}", dr["MaLoaiPT"], dr["TenLoaiPT"]));
            }
            dr.Close();
            //SQLCmd.CommandText = "SELECT MaKhoa,TenKhoa,0 As ThucHien FROM DMKHOAPHONG";
            //dr = SQLCmd.ExecuteReader();
            //Global.BindDatareaderToGrid(fgKhoa, dr);
            //dr.Close();
            
            //SQLCmd.CommandText = "SELECT MaDT,TenDT,0 As Chon FROM DMDOITUONGBN WHERE Len(MaDT)=1 ORDER BY MaDT";
            //dr = SQLCmd.ExecuteReader();
            //Global.BindDatareaderToGrid(fgDoiTuong, dr);
            //dr.Close();
            SQLCmd.Dispose();
        }
        private void cmbLoaiDichVu_TextChanged(object sender, EventArgs e)
        {
            
            if (cmbLoaiDichVu.Tag.ToString() == "0" || cmbLoaiDichVu.SelectedIndex == -1) return;
            string MaLoaiDichVu = GlobalModuls.Global.GetCode(cmbLoaiDichVu);
            if (MaLoaiDichVu =="D01") //thuoc
            {
                txtMaDichVu.Mask = "000000000000";                
            }
            else
            {
                txtMaDichVu.Mask =string.Format("[\\{0}\\{1}\\{2}]-000",MaLoaiDichVu.Substring(0,1),MaLoaiDichVu.Substring(1,1),MaLoaiDichVu.Substring(2,1));
            }
            
            Load_DichVu(MaLoaiDichVu);
        }
        private void Load_DichVu(string MaLoaiDichVu)
        {
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
            SQLCmd.CommandText =string.Format("SELECT a.MaDichVu,TenDichVu,DVT,DonGia,DonGiaBHYT,KhongSuDung,DoiTuong,LoaiPhauThuat,KyThuatcao,LaPhauThuat "
                                        + " FROM DMDICHVU a LEFT JOIN DMPHAUTHUAT b ON a.MaDichVu=b.MaDichVu AND a.LoaiDichVu=b.LoaiDichVu "
                                        + " WHERE a.LoaiDichVu='{0}' ORDER BY TenDichVu", MaLoaiDichVu);
            System.Data.SqlClient.SqlDataReader dr = SQLCmd.ExecuteReader();
            //Global.BindDatareaderToGrid(fg, dr);
            fg.Redraw = false;
            
            fg.Tag = "0";
            fg.Rows.Count = 1;
            while (dr.Read())
            {
                fg.Rows.Add();
                for (int i = 1; i < fg.Cols.Count; i++)
                    fg[fg.Rows.Count - 1, i] = dr.GetValue(i - 1);
            }
            SetEmpty();
            fg.Tag = "1";
            fg.AutoSizeCols();
            fg.Redraw = true;
            dr.Close();
            SQLCmd.Dispose();
        }
        private void Load_DichVu_ChiTiet(string MaDichVu)
        {
            string DoiTuongBN = "";
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
            SQLCmd.CommandText =string.Format("SELECT * FROM DMDICHVU WHERE MaDichVu='{0}'",MaDichVu);
            System.Data.SqlClient.SqlDataReader dr = SQLCmd.ExecuteReader();
            if (dr.Read())
            {
                txtMaDichVu.Text = MaDichVu.Substring(3);
                txtTenDichVu.Text = dr["TenDichVu"].ToString();
                txtDVT.Text = dr["DVT"].ToString();
                Global.SetCmb(cmbNhomBHYT, dr["NhomBhYT"].ToString());
                chkNoiTru.Checked = (dr["NoiTru_NgoaiTru"].ToString() == "1" || dr["NoiTru_NgoaiTru"].ToString() == "3");
                chkNgoaiTru.Checked = (dr["NoiTru_NgoaiTru"].ToString() == "2" || dr["NoiTru_NgoaiTru"].ToString() == "3");
                decimal DonGia = 0;
                bool bParse = decimal.TryParse(dr["DonGia"].ToString(), out DonGia);
                txtDonGia.Value = DonGia;
                bParse = decimal.TryParse(dr["DonGiaBHYT"].ToString(), out DonGia);
                txtDonGiaBHYT.Value = DonGia;
                txtTentat.Text = dr["Tentat"].ToString();
                txtGhiChu.Text = dr["GhiChu"].ToString();                
                DoiTuongBN = dr["DoiTUong"].ToString();
            }
            else
            {
                SetEmpty();
            }
            if (fg.Row > 0)
            {
                //Global.SetCmb(cmbLoaiPT, fg[fg.Row, "LoaiPhauThuat"].ToString());
                Global.SetCmb(cmbLoaiPT, fg.GetDataDisplay(fg.Row,"LoaiPhauThuat"));
                chkKyThuatCao.Checked = (fg.GetCellCheck(fg.Row,fg.Cols["KyThuatCao"].Index)==C1.Win.C1FlexGrid.CheckEnum.Checked);
                chkPhauThuat.Checked = chkThuThuat.Checked = false;
                int LaPhauThuat=0;
                if (fg[fg.Row,"LaPhauThuat"].ToString()!="")
                {
                    LaPhauThuat = int.Parse(fg[fg.Row,"LaPhauThuat"].ToString());
                    if ((LaPhauThuat & 1) == 1) chkPhauThuat.Checked = true;
                    if ((LaPhauThuat & 2) == 2) chkThuThuat.Checked = true;
                }
            }
            dr.Close();            
            SQLCmd.Dispose();
        }

        private void fg_Click(object sender, EventArgs e)
        {
            
        }
        private void SetEmpty()
        {
            txtMaDichVu.Text = "";
            txtTenDichVu.Text = "";
            txtDVT.Text = "";
            cmbNhomBHYT.SelectedIndex = -1;
            chkNgoaiTru.Checked = chkNoiTru.Checked = false;
            txtDonGia.Value = txtDonGiaBHYT.Value = 0;
            txtGhiChu.Text = "";
            txtTentat.Text = "";            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void Lock_Edit(bool isLocked)
        {
            cmbLoaiDichVu.ReadOnly = !isLocked;
            fg.Enabled = isLocked;

            txtMaDichVu.ReadOnly = txtTenDichVu.ReadOnly = cmbNhomBHYT.ReadOnly =txtTentat.ReadOnly = txtGhiChu.ReadOnly =txtDVT.ReadOnly = isLocked;
            chkNoiTru.Enabled = chkNgoaiTru.Enabled = !isLocked;
            txtDonGia.ReadOnly = txtDonGiaBHYT.ReadOnly = isLocked;
        }

        private void cmdSua_Click(object sender, EventArgs e)
        {
            if (fg.Row < 1)
            {
                MessageBox.Show("Chưa chọn dịch vụ để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            IsAddNew = false;
            Lock_Edit(false);
            txtMaDichVu.ReadOnly = true;
            txtTenDichVu.Focus();
        }
        private string LayMaDichVuMoi(string LoaiDichVu)
        {
            string StrMaMoi = "";
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
            SQLCmd.CommandText = "SELECT max(maDichVu) as maxMa from DMDICHVU WHERE LoaiDichVu ='" + LoaiDichVu + "'";
            System.Data.SqlClient.SqlDataReader dr = SQLCmd.ExecuteReader();
            dr.Read();
            if (dr["maxMa"].ToString() == "")
            {
                StrMaMoi = LoaiDichVu + "0001";
            }
            else
            {
                StrMaMoi = dr["maxMa"].ToString().Substring(3);
                StrMaMoi = string.Format("{0:0000}", int.Parse(StrMaMoi) + 3);
                StrMaMoi = LoaiDichVu + StrMaMoi;
            }
            dr.Close();
            SQLCmd.Dispose();
            return StrMaMoi;
        }

        private void cmdThem_Click(object sender, EventArgs e)
        {
            if (cmbLoaiDichVu.SelectedIndex==-1)
            {
                MessageBox.Show("Chưa chọn nhóm dịch vụ để thêm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            IsAddNew = true;
            Lock_Edit(false);
            SetEmpty();
            txtMaDichVu.Text  = LayMaDichVuMoi(Global.GetCode(cmbLoaiDichVu)).Substring(3);
            txtTenDichVu.Focus();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Lock_Edit(true);
            if (fg.Row > 0) Load_DichVu_ChiTiet(fg[fg.Row, "MaDichVu"].ToString());
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (cmbLoaiPT.SelectedIndex == -1 && chkPhauThuat.Checked)
            {
                MessageBox.Show("Phải chọn loại phẫu thuật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbLoaiPT.Focus();
                return;
            }
            if (fg.Rows.Count <= 1) return;
            string MaDichVu;
            string LoaiDichVu = Global.GetCode(cmbLoaiDichVu);
            string LoaiPhauThuat=Global.GetCode(cmbLoaiPT);            
            int KyThuatCao=(chkKyThuatCao.Checked)?(1):(0);
            int LaPhauThuat = 0;
            if (chkPhauThuat.Checked) LaPhauThuat = LaPhauThuat | 1;
            if (chkThuThuat.Checked) LaPhauThuat = LaPhauThuat | 2;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
            System.Data.SqlClient.SqlTransaction trn = Global.ConnectSQL.BeginTransaction();
            SQLCmd.Transaction = trn;
            try
            {
                C1.Win.C1FlexGrid.CellRange Cell = new C1.Win.C1FlexGrid.CellRange();
                Cell = fg.Selection;
                for (int i = Cell.r1; i <= Cell.r2; i++)
                {
                    MaDichVu = fg[i, "MaDichVu"].ToString();
                    if (chkPhauThuat.Checked == true || chkKyThuatCao.Checked == true)
                    {
                        SQLCmd.CommandText = string.Format("IF NOT EXISTS(SELECT * FROM NAMDINH_SYSDB.DBO.DMDICHVU_KHOA WHERE MADICHVU ='{0}' AND MAKHOA ='{1}')"
                            + " BEGIN"
                            + " 	INSERT INTO NAMDINH_SYSDB.DBO.DMDICHVU_KHOA (MADICHVU,MAKHOA)"
                            + " 	VALUES('{0}','{1}')"
                            + " END", MaDichVu, Global.glbMaKhoaPhong);
                        SQLCmd.ExecuteNonQuery();
                    }
                    else
                    {
                        SQLCmd.CommandText = string.Format("IF EXISTS(SELECT * FROM NAMDINH_SYSDB.DBO.DMDICHVU_KHOA WHERE MADICHVU ='{0}' AND MAKHOA ='{1}')"
                            + " BEGIN"
                            + " 	DELETE FROM NAMDINH_SYSDB.DBO.DMDICHVU_KHOA WHERE MADICHVU = '{0}' AND MAKHOA ='{1}'"
                            + " END", MaDichVu, Global.glbMaKhoaPhong);
                        SQLCmd.ExecuteNonQuery();
                    }
                    SQLCmd.CommandText = string.Format("DELETE FROM DMPHAUTHUAT WHERE MaDichVu='{0}' AND LoaiDichVu='{1}'", MaDichVu, LoaiDichVu);
                    SQLCmd.ExecuteNonQuery();
                    SQLCmd.CommandText = string.Format("INSERT INTO DMPHAUTHUAT (MaDichVu,LoaiDichVu,LoaiPhauThuat,KyThuatCao,LaPhauThuat) VALUES ('{0}','{1}','{2}',{3},{4})", MaDichVu, LoaiDichVu, LoaiPhauThuat, KyThuatCao, LaPhauThuat);
                    SQLCmd.ExecuteNonQuery();
                    fg[i, "LoaiPhauThuat"] = LoaiPhauThuat;
                    fg[i, "KyThuatcao"] = KyThuatCao;
                    fg[i, "LaPhauThuat"] = LaPhauThuat;
                }
                trn.Commit();
                MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                trn.Rollback();
                MessageBox.Show("Có lỗi khi ghi dữ liệu!\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SQLCmd.Dispose();
                trn.Dispose();
            }
        }

        private void fg_AfterRowColChange(object sender, C1.Win.C1FlexGrid.RangeEventArgs e)
        {
            if (fg.Tag.ToString() == "0" || fg.Row < 1) return;
            Load_DichVu_ChiTiet(fg[fg.Row, "MaDichVu"].ToString());
        }
    }
}