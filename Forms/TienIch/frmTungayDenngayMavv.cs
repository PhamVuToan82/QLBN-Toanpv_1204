using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NamDinh_QLBN.Forms.Tien_ich
{
    public partial class frmTungayDenngayMavv : Form
    {
        public DateTime _TNgay, _DNgay;
        public string _MaKhoa;
        public string _TenKhoa;
        public bool _Chon;
        public frmTungayDenngayMavv()
        {
            InitializeComponent();
        }

        private void cmdThoat_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void cmbKhongGhi_Click_1(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
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
                    if (checkBox1.Checked)
                    {
                        _Chon = true;
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        _Chon = false;
                    }
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
                txtTNgay.Value = txtDNgay.Value = GlobalModuls.Global.GetNgayLV();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                SQLCmd.Dispose();
            }
        }
        private void frmTungayDenngayMavv_Load(object sender, EventArgs e)
        {
            LoatDanhMuc();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.fgDichVu.Redraw = false;
            fgDichVu.ClipSeparators = "|;";
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            SQLCmd.CommandText = "exec NAMDINH_QLBN.dbo.Get_ToDieuTri";
            dr = SQLCmd.ExecuteReader();
            while (dr.Read())
            {
                this.fgDichVu.AddItem(string.Format("{0}|{1}|{2}", new object[]
               { dr["NgayChiDinh"], dr["OSTag1"].ToString(), dr["OSTag2"].ToString()}));
            }
            fgDichVu.AutoSizeRows();
            dr.Close();
            this.fgDichVu.Redraw = true;
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtDNgay.Enabled = true;
                txtTNgay.Enabled = true;
            }
            else
            {
                txtDNgay.Enabled = false;
                txtTNgay.Enabled = false;
            }
        }
    }
}
