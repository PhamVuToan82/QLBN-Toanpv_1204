using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NamDinh_QLBN.Forms.Tien_ich
{
    public partial class frmTKPhauThuat_ByBS : Form
    {
        public DateTime _TNgay, _DNgay;
        public string _MaKhoa,_TenKhoa,_MaBS,_TenBS,_MaLoaiPT,_TenLoaiPT;
        public bool _isTatCa = false, _isBatThuong = false, _isTrongNgay = false;
        public frmTKPhauThuat_ByBS()
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
                    _MaLoaiPT = GlobalModuls.Global.GetCode(cmbLoaiCLS);
                    _TenLoaiPT = cmbLoaiCLS.Text;
                    _MaBS = GlobalModuls.Global.GetCode(cmbBacSi);
                    _TenBS = cmbBacSi.Text.Trim();
                    _isBatThuong = raBatThuong.Checked;
                    _isTatCa = raTatCa.Checked;
                    _isTrongNgay = raTrongNgay.Checked;
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
                //SQLCmd.CommandText = "SELECT * FROM DMKHOAPHONG WHERE MaKhoa IN " + GlobalModuls.Global.glbKhoa_CapNhat;
                //dr = SQLCmd.ExecuteReader();
                //cmbKhoa.Tag = "0";
                //cmbKhoa.ClearItems();
                //while (dr.Read())
                //{
                //    cmbKhoa.AddItem(string.Format("{0};{1}", dr["MaKhoa"], dr["TenKhoa"]));
                //}
                //cmbKhoa.SelectedIndex = 0;
                //dr.Close();
                //cmbKhoa.Tag = "1";


                SQLCmd.CommandText = "SELECT * FROM DMKHOAPHONG WHERE IS_KHOADIEUTRI = 1";
                dr = SQLCmd.ExecuteReader();
                cmbKhoa.Tag = "0";
                cmbKhoa.ClearItems();
                while (dr.Read())
                {
                    cmbKhoa.AddItem(string.Format("{0};{1}", dr["MaKhoa"], dr["TenKhoa"]));
                }
                dr.Close();
                cmbKhoa.Tag = "1";
                if (cmbKhoa.ListCount > 0)
                {
                    GlobalModuls.Global.SetCmb(cmbKhoa, GlobalModuls.Global.glbMaKhoaPhong);
                }
                cmbLoaiCLS.Tag = "0";
                SQLCmd.CommandText = string.Format("SELECT * FROM DMLOAIPHAUTHUAT WHERE LEFT(MALOAIPT,1) <>'5' ORDER BY MaLoaiPT");
                dr = SQLCmd.ExecuteReader();
                cmbLoaiCLS.ClearItems();
                cmbLoaiCLS.AddItem("0;---------------- TẤT CẢ ----------------");
                while(dr.Read())
                {
                    cmbLoaiCLS.AddItem(string.Format("{0};{1}",dr["MaLoaiPT"],dr["TenLoaiPT"]));
                }
                cmbLoaiCLS.SelectedIndex = 0;
                dr.Close();

                cmbBacSi.Tag = "1";
                cmbBacSi.Tag = "0";
                SQLCmd.CommandText = string.Format("SELECT * FROM DMBACSY WHERE MAKHOA in {0} and Khongsudung = 0 ORDER BY TENBS", GlobalModuls.Global.glbKhoa_CapNhat);
                dr = SQLCmd.ExecuteReader();
                cmbBacSi.ClearItems();
                cmbBacSi.AddItem("0;---------------- TẤT CẢ ----------------");
                while (dr.Read())
                {
                    cmbBacSi.AddItem(string.Format("{0};{1}", dr["MaBS"], dr["TenBS"]));
                }
                cmbBacSi.SelectedIndex = 0;
                dr.Close();
                cmbBacSi.Tag = "1";
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
        }
    }
}