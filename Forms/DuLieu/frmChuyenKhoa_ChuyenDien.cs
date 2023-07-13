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
    public partial class frmChuyenKhoa_ChuyenDien : Form
    {
        public frmChuyenKhoa_ChuyenDien()
        {
            InitializeComponent();
        }

        private void frmChuyenKhoa_ChuyenDien_Load(object sender, EventArgs e)
        {
            fgKhoa.ClipSeparators = "|;";
            fgKhoa.Cols["MaKhoa"].Visible = false;
            fgDoiTuong.ClipSeparators = "|;";
            fgDoiTuong.Cols["MaDoiTuong"].Visible = false;
            Load_CacDM();            
        }
        private void Load_CacDM()
        {
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            SQLCmd.CommandText = "SELECT * FROM DMKHOAPHONG WHERE MaKhoa IN " + Global.glbKhoa_CapNhat;
            dr = SQLCmd.ExecuteReader();
            cmbKhoa.Tag = "0";
            cmbKhoa.ClearItems();
            while (dr.Read())
            {
                cmbKhoa.AddItem(string.Format("{0};{1}", dr["MaKhoa"], dr["TenKhoa"]));
            }
            cmbKhoa.SelectedIndex = -1;
            cmbKhoa.Tag = "1";
            if (cmbKhoa.ListCount > 0) cmbKhoa.SelectedIndex = 0;
            dr.Close();           
            SQLCmd.Dispose();
        }

        private void cmdDanhSachBN_Click(object sender, EventArgs e)
        {
            int covid = 0;
            if (cmbKhoa.SelectedIndex == -1)
            {
                MessageBox.Show("Chưa chọn khoa điều trị!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbKhoa.Focus();
                return;
            }
            NamDinh_QLBN.Forms.DuLieu.frmShowDSBenhNhan fr = new frmShowDSBenhNhan("", Global.GetCode(cmbKhoa), "",1,0,"0",covid);
            fr.ShowDialog();
            if (fr.DialogResult == DialogResult.OK)
            {
                txtMaBenhAn.Text = fr.SoHSBAReturn;
                txtMaVaoVien.Text = fr.MaVaoVienReturn;
                txtHoTen.Text = fr.HoTenReturn;
                txtTuoi.Text = fr.TuoiReturn;
                txtGioi.Text = fr.GioiReturn;
                txtDoiTuong.Text = fr.TenDoiTuongReturn;
                txtNgayVaoVien.Text = fr.NgayVaoVienReturn;                
                Load_ThongTinBenhNhan(txtMaVaoVien.Text);
            }
        }
        private void Load_ThongTinBenhNhan(string MaVaoVien)
        {
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
            SQLCmd.CommandText = "SELECT a.*,TenKhoa FROM BENHNHAN_KHOA a INNER JOIN DMKHOAPHONG b ON a.maKhoa=b.MaKhoa WHERE MaVaoVien='" + MaVaoVien + "'  ORDER BY lanChuyenKhoa";
            System.Data.SqlClient.SqlDataReader dr = SQLCmd.ExecuteReader();
            fgKhoa.Rows.Count = 1;
            while (dr.Read())
            {
                fgKhoa.AddItem(string.Format("{0}|{1:dd/MM/yyyy HH:mm}|{2}|{3}", dr["LanChuyenKhoa"], dr["NgayChuyen"], dr["TenKhoa"], dr["MaKhoa"]));
            }
            dr.Close();
            fgKhoa.AutoSizeCols();
            SQLCmd.CommandText = "SELECT a.*,TenDT FROM BENHNHAN_DOITUONG a INNER JOIN DMDOITUONGBN b ON a.DoiTuong=b.MaDT WHERE MaVaoVien='" + MaVaoVien + "' ORDER BY lanChuyenDT";
            dr = SQLCmd.ExecuteReader();
            fgDoiTuong.Rows.Count = 1;
            while (dr.Read())
            {
                fgDoiTuong.AddItem(string.Format("{0}|{1:dd/MM/yyyy HH:mm}|{2}|{3}", dr["LanChuyenDT"], dr["NgayChuyen"], dr["TenDT"], dr["DoiTuong"]));
            }
            dr.Close();
            fgDoiTuong.AutoSizeCols();
            SQLCmd.Dispose();
        }
        private void Empty_Data()
        {
            txtMaBenhAn.Text = "";
            txtMaVaoVien.Text = "";
            txtHoTen.Text = "";
            txtTuoi.Text = "";
            txtGioi.Text = "";
            txtDoiTuong.Text = "";
            txtNgayVaoVien.Text = "";
            fgKhoa.Rows.Count = 1;
            fgDoiTuong.Rows.Count = 1;
        }

        private void cmdChuyenKhoa_Click(object sender, EventArgs e)
        {
            if (txtMaVaoVien.Text == "") return;
            NamDinh_QLBN.Forms.DuLieu.frmCapNhatThongTinQuanLy fr = new frmCapNhatThongTinQuanLy(txtMaVaoVien.Text, txtHoTen.Text, 2, fgKhoa[fgKhoa.Rows.Count - 1, "MaKhoa"].ToString(), fgKhoa[fgKhoa.Rows.Count - 1, "lanChuyen"].ToString());           
            if (fr.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Đã chuyển Khoa cho bệnh nhân!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Empty_Data();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtMaVaoVien.Text == "") return;
            NamDinh_QLBN.Forms.DuLieu.frmCapNhatThongTinQuanLy fr = new frmCapNhatThongTinQuanLy(txtMaVaoVien.Text, txtHoTen.Text, 1, fgDoiTuong[fgDoiTuong.Rows.Count - 1, "MaDoiTuong"].ToString(), fgDoiTuong[fgDoiTuong.Rows.Count - 1, "lanChuyen"].ToString());
            if (fr.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Đã chuyển Đối tượng cho bệnh nhân!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);                
            }
        }
    }
}