using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NamDinh_QLBN.Forms.Tien_ich
{
    public partial class  frmTNgayDNgayByGiuongAndBuong : Form
    {
        public DateTime _TNgay, _DNgay;
        public string _MaKhoa;
        public string _TenKhoa;
        public int _isID_Buong,_isID_Giuong;
        public bool _isNgayVaoVien, _isNgayRaVien, _isDangDieuTri;

        public frmTNgayDNgayByGiuongAndBuong()
        {
            InitializeComponent();
        }

        private void cmdThoat_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void cmbKhongGhi_Click(object sender, EventArgs e)
        {
            if (cmbKhoa.SelectedIndex == -1)
            {
                MessageBox.Show("Chọn khoa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbKhoa.Focus();
                this.DialogResult = DialogResult.Retry;
            }
            else
            {
                if (txtDNgay.ValueIsDbNull == true || txtTNgay.ValueIsDbNull == true)
                {
                    MessageBox.Show("Chọn ngày", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.Retry;
                }
                else
                {
                    _TNgay = (DateTime)txtTNgay.Value;
                    _DNgay = (DateTime)txtDNgay.Value;
                    _MaKhoa = GlobalModuls.Global.GetCode(cmbKhoa);
                    _TenKhoa = cmbKhoa.Text;
                    _isID_Giuong = int.Parse(GlobalModuls.Global.GetCode(cmbGiuong));
                    _isID_Buong = int.Parse(GlobalModuls.Global.GetCode(cmbBuong));
                    _isDangDieuTri = raDangDT.Checked;
                    _isNgayRaVien = raRaVien.Checked;
                    _isNgayVaoVien = raVaoVien.Checked;
                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        private void LoatDanhMuc()
        {
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            try
            {
                SQLCmd.CommandText = "SELECT * FROM DMKHOAPHONG WHERE MaKhoa IN " + GlobalModuls.Global.glbKhoa_CapNhat;
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
                cmbBuong.Tag = "0";
                SQLCmd.CommandText = String.Format("SELECT * FROM DMBUONGBENH WHERE MAKHOA='{0}'",GlobalModuls.Global.GetCode(cmbKhoa));
                dr = SQLCmd.ExecuteReader();
                cmbBuong.ClearItems();
                cmbBuong.AddItem("0;---------------- TẤT CẢ ----------------");
                while(dr.Read())
                {
                    cmbBuong.AddItem(string.Format("{0};{1}",dr["ID_BUONG"],dr["TENBUONG"]));
                }
                cmbBuong.SelectedIndex = 0;
                dr.Close();
                cmbBuong.Tag = "1";
                txtTNgay.Value = txtDNgay.Value = GlobalModuls.Global.GetNgayLV();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                SQLCmd.Dispose();
            }
        }

        private void frmTNgayDNgay_Load(object sender, EventArgs e)
        {
            LoatDanhMuc();
            raDangDT_CheckedChanged(null, null);
        }

        private void raDangDT_CheckedChanged(object sender, EventArgs e)
        {
            txtDNgay.Enabled = txtTNgay.Enabled = !raDangDT.Checked;
        }

        private void raRaVien_CheckedChanged(object sender, EventArgs e)
        {
            raDangDT_CheckedChanged(null, null);
        }

        private void raVaoVien_CheckedChanged(object sender, EventArgs e)
        {
            raDangDT_CheckedChanged(null, null);
        }

        private void raChiDinh_CheckedChanged(object sender, EventArgs e)
        {
            raDangDT_CheckedChanged(null, null);
        }

        private void cmbBuong_TextChanged(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            try
            {
                if (cmbBuong.SelectedIndex != 0)
                {
                    SQLCmd.CommandText = String.Format("SELECT * FROM DMGIUONGBENH WHERE MAKHOA='{0}' AND ID_BUONG ={1}", GlobalModuls.Global.GetCode(cmbKhoa), GlobalModuls.Global.GetCode(cmbBuong));
                    dr = SQLCmd.ExecuteReader();
                    cmbGiuong.ClearItems();
                    cmbGiuong.AddItem("0;---------------- TẤT CẢ ----------------");
                    while (dr.Read())
                    {
                        cmbGiuong.AddItem(string.Format("{0};{1}", dr["ID_GIUONG"], dr["TENGIUONG"]));
                    }
                    cmbGiuong.SelectedIndex = 0;
                    dr.Close();
                }
                else
                {
                    cmbGiuong.ClearItems();
                    cmbGiuong.AddItem("0;---------------- TẤT CẢ ----------------");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                SQLCmd.Dispose();
            }
        }
    }
}