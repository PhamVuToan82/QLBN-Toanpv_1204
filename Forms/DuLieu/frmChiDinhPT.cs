using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NamDinh_QLBN.Forms.DuLieu
{
    public partial class frmChiDinhPT : Form
    {
        private byte LanPhauThuat = 0;
        private Object  NgayChiDinh = null;
        private string LoaiPT = "";
        private string YeuCauPT = "";
        public frmChiDinhPT(string MaBN,string TenBN, string LanVaoVien,string GT,string DoiTuong,string NgayVaoVien,byte _LanPT,Object _NgayChiDinh,string _LoaiPT,string _YeuCauPT)
        {
            InitializeComponent();
            lblMaBN.Text = MaBN;
            lblTenBN.Text = TenBN;
            lblLanVV.Text = LanVaoVien;
            lblGT.Text = GT;
            lblDoiTuong.Text = DoiTuong;
            lblNgayVaoVien.Text = NgayVaoVien;
            LanPhauThuat = _LanPT;
            NgayChiDinh = _NgayChiDinh;
            LoaiPT = _LoaiPT;
            YeuCauPT = _YeuCauPT;
        }

        private void frmChiDinhPT_Load(object sender, EventArgs e)
        {
            fg.ClipSeparators = "|;";
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            SQLCmd.CommandText = "SELECT * FROM DMLOAIHINHDT WHERE MaLH>2 ORDER BY MaLH";
            dr = SQLCmd.ExecuteReader();
            cmbLoaiDT.Tag = "0";
            cmbLoaiDT.ClearItems();
            while (dr.Read())
            {
                cmbLoaiDT.AddItem(string.Format("{0};{1}", dr["MaLH"], dr["TenLH"]));
            }
            dr.Close();            
            cmbLoaiDT.Tag = "1";
            dr.Close();
            SQLCmd.CommandText = "SELECT * FROM DMVITRI_PT WHERE B5=0";
            dr = SQLCmd.ExecuteReader();
            string tmps = "";
            while (dr.Read())
            {
                tmps += dr["TenVT"].ToString() + "|";
            }
            fg.Cols[2].ComboList = tmps;
            dr.Close();
            if (LanPhauThuat == 0)
            {
                txtNgayCD.Value = GlobalModuls.Global.NgayLV;
                txtNgayPT.Value = GlobalModuls.Global.NgayLV;
                cmbLoaiDT.SelectedIndex = -1;
            }
            else
            {
                txtNgayCD.Value = NgayChiDinh;
                GlobalModuls.Global.SetCmb(cmbLoaiDT, LoaiPT);
                GlobalModuls.Global.SetCmb(cmbYeuCauPT,YeuCauPT);
                SQLCmd.CommandText =string.Format("SELECT * FROM BENHNHAN_PHAUTHUAT WHERE MaBEnhNhan='{0}' AND LanVaoVien={1} AND lanPT={2}",lblMaBN.Text,lblLanVV.Text,LanPhauThuat);
                dr = SQLCmd.ExecuteReader();
                while (dr.Read())
                {
                    txtNgayPT.Value = dr["NgayPhauThuat"];
                }
                dr.Close();
                SQLCmd.CommandText = string.Format("SELECT * FROM BENHNHAN_PT_KIPMO WHERE MaBenhNhan='{0}' AND LanVaoVien={1} AND lanPT={2} ORDER BY SoTTBS", lblMaBN.Text, lblLanVV.Text, LanPhauThuat);
                dr = SQLCmd.ExecuteReader();
                fg.ClipSeparators = "|;";
                fg.Rows.Count = 1;
                while (dr.Read())
                {
                    fg.AddItem(string.Format("{0}|{1}|{2}",dr["SoTTBS"],dr["TenBacSy"],dr["ViTri"]));
                }
                dr.Close();
            }
            SQLCmd.Dispose();
        }

        private void cmbLoaiDT_TextChanged(object sender, EventArgs e)
        {
            if (cmbLoaiDT.Tag.ToString() == "0") { return; }
            string MaLH = GlobalModuls.Global.GetCode(cmbLoaiDT);
            if (MaLH == null) { return; }
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;            
            SQLCmd.CommandText = "SELECT * FROM dmphuongphapdieutri WHERE MaPP IN (SELECT MaPP FROM PHUONGPHAPDT_LOAIHINHDT WHERE MaLoaiHinh=" + MaLH + ")";
            dr = SQLCmd.ExecuteReader();
            cmbYeuCauPT.ClearItems();
            while (dr.Read())
            {
                cmbYeuCauPT.AddItem(string.Format("{0};{1}", dr["MaPP"], dr["TenPP"]));
            }
            dr.Close();
            SQLCmd.Dispose();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Dispose();
        }

        private void cmdGhiChiTiet_Click(object sender, EventArgs e)
        {
            if (txtNgayCD.ValueIsDbNull)
            {
                MessageBox.Show("Chưa nhập ngày yêu cầu phẫu thuật, thủ thuật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNgayCD.Focus();
                return;
            }
            if (GlobalModuls.Global.GetCode(cmbLoaiDT) == null)
            {
                MessageBox.Show("Chưa chọn loại hình phẫu thuật, thủ thuật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbLoaiDT.Focus();
                return;
            }
            if (GlobalModuls.Global.GetCode(cmbYeuCauPT) == null)
            {
                MessageBox.Show("Chưa chọn yêu cầu phẫu thuật, thủ thuật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbYeuCauPT.Focus();
                return;
            }
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            int SoTT_BS = 1;
            string StrSQL = "";
            System.Data.SqlClient.SqlTransaction trn;
            trn = GlobalModuls.Global.ConnectSQL.BeginTransaction();
            SQLCmd.Transaction = trn;
            try
            {
                if (LanPhauThuat == 0) //chi dinh moi
                {
                    System.Data.SqlClient.SqlDataReader dr;
                    SQLCmd.CommandText = "SELECT Max(LanPT) as MaxPT FROM BENHNHAN_PHAUTHUAT WHERE MaBenhNhan='" + lblMaBN.Text + "' AND LanVaoVien=" + lblLanVV.Text;
                    dr = SQLCmd.ExecuteReader();
                    dr.Read();
                    if (dr["maxPT"].ToString() == "")
                    {
                        LanPhauThuat = 1;
                    }
                    else
                    {
                        LanPhauThuat = byte.Parse(dr["MaxPT"].ToString());// +(byte)1;
                        LanPhauThuat++;
                    }
                    dr.Close();
                    SQLCmd.CommandText = string.Format("INSERT INTO BENHNHAN_PHAUTHUAT (MaBenhNhan,LanVaoVien,LanPT,NgayYeuCau,YeuCauPhauThuat,LoaiHinhPhauThuat,MaKhoa,NgayPhauThuat)"
                                                    + " VALUES ('{0}',{1},{2},'{3:MM/dd/yyyy}','{4}',{5},'{6}','{7:MM/dd/yyyy}')",
                                                    lblMaBN.Text,
                                                    lblLanVV.Text,
                                                    LanPhauThuat,
                                                    txtNgayCD.Value,
                                                    GlobalModuls.Global.GetCode(cmbYeuCauPT),
                                                    GlobalModuls.Global.GetCode(cmbLoaiDT),
                                                    GlobalModuls.Global.glbMaKhoaPhong, txtNgayPT.Value);
                }
                else
                {
                    SQLCmd.CommandText = string.Format("UPDATE BENHNHAN_PHAUTHUAT SET NgayYeuCau='{3:MM/dd/yyyy}',YeuCauPhauThuat='{4}',LoaiHinhPhauThuat={5},MaKhoa='{6}',NgayPhauThuat='{7:MM/dd/yyyy}' "
                                    + " WHERE MaBenhNhan='{0}' AND LanVaoVien={1} AND LanPT ={2}",
                                    lblMaBN.Text,
                                    lblLanVV.Text,
                                    LanPhauThuat,
                                    txtNgayCD.Value,
                                    GlobalModuls.Global.GetCode(cmbYeuCauPT),
                                    GlobalModuls.Global.GetCode(cmbLoaiDT),
                                    GlobalModuls.Global.glbMaKhoaPhong,txtNgayPT.Value);
                }
                SQLCmd.ExecuteNonQuery();
                SQLCmd.CommandText = string.Format("DELETE FROM BENHNHAN_PT_KIPMO WHERE MaBenhNhan='{0}' AND LanVaoVien={1} AND LanPT = {2}", lblMaBN.Text, lblLanVV.Text, LanPhauThuat);
                SQLCmd.ExecuteNonQuery();
                for (int i = 1; i < fg.Rows.Count; i++)
                {
                    if (fg.GetDataDisplay(i, 1) != "" && fg.GetDataDisplay(i, 2) != "")
                    {
                        StrSQL = string.Format("INSERT INTO BENHNHAN_PT_KIPMO (MaBenhNhan,LanVaoVien,LanPT,SoTTBS,TenBacSy,ViTri) VALUES ('{0}',{1},{2},{3},N'{4}',N'{5}')",
                            lblMaBN.Text,
                            lblLanVV.Text,
                            LanPhauThuat,
                            SoTT_BS,
                            fg.GetDataDisplay(i, 1),
                            fg.GetDataDisplay(i, 2));
                        SQLCmd.CommandText = StrSQL;
                        SQLCmd.ExecuteNonQuery();
                        SoTT_BS += 1;
                    }
                }
                trn.Commit();
                this.DialogResult = DialogResult.OK;
                this.Dispose();
            }
            catch (Exception ex)
            {
                trn.Rollback();
                MessageBox.Show("Có lỗi khi ghi dữ liệu!\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                SQLCmd.Dispose();
                trn.Dispose();
            }
            
        }

        private void cmdThem_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.DuLieu.frmCapNhatKipMo fr = new frmCapNhatKipMo(fg, "0");
            fr.ShowDialog();
        }
    }
}