using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NamDinh_QLBN.Forms.Tien_ich
{
    public partial class frmTNgayDNgay_Vai : Form
    {
        public DateTime _TNgay, _DNgay;
        public string _MaKhoa;
        public string _TenKhoa;
        //public bool _MuonVai = false, _DoiVai = false, _DaTraVai = false;

        public frmTNgayDNgay_Vai()
        {
            InitializeComponent();
        }

        private void cmdThoat_Click(object sender, EventArgs e)
        {
            //this.DialogResult = DialogResult.Cancel;
            this.Dispose();
        }

        private void cmbKhongGhi_Click(object sender, EventArgs e)
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
                    if(rd_muonvai.Checked == true)
                    {
                        NamDinh_QLBN.Reports.repSoLenThuoc_Vai rpt = new NamDinh_QLBN.Reports.repSoLenThuoc_Vai(_TNgay, _DNgay, _TenKhoa);
                        rpt.Show();
                    }
                    if (rd_doivai.Checked == true)
                    {
                        NamDinh_QLBN.Reports.repSoLenThuoc_DoiVai rpt = new NamDinh_QLBN.Reports.repSoLenThuoc_DoiVai(_TNgay, _DNgay, _TenKhoa);
                        rpt.Show();
                    }
                    if (rd_datravai.Checked == true)
                    {
                    NamDinh_QLBN.Reports.repSoLenThuoc_TraVai rpt = new NamDinh_QLBN.Reports.repSoLenThuoc_TraVai(_TNgay, _DNgay, _TenKhoa);
                    rpt.Show();
                    }
                    this.DialogResult = DialogResult.OK;
                 }
        }

        private void LoatDanhMuc()
        {
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            try
            {
                SQLCmd.CommandText = "SELECT * FROM DMKHOAPHONG WHERE is_KhoaDieutri = 1 ";
                dr = SQLCmd.ExecuteReader();
                cmbKhoa.Tag = "0";
                cmbKhoa.ClearItems();
                cmbKhoa.AddItem(string.Format("{0};{1}", "", "Tất Cả"));
                while (dr.Read())
                {
                    cmbKhoa.AddItem(string.Format("{0};{1}", dr["MaKhoa"], dr["TenKhoa"]));
                }
                cmbKhoa.SelectedIndex = 0;
                dr.Close();
                cmbKhoa.Tag = "1";
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

        private void btn_BcTongHop_Click(object sender, EventArgs e)
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
                if (rd_muonvai.Checked == true)
                {
                    NamDinh_QLBN.Reports.rptPhieuMuonVai rpt = new NamDinh_QLBN.Reports.rptPhieuMuonVai(_TNgay, _DNgay, _TenKhoa);
                    rpt.Show();
                }
                if (rd_doivai.Checked == true)
                {
                    NamDinh_QLBN.Reports.rptPhieuDoiVai rpt = new NamDinh_QLBN.Reports.rptPhieuDoiVai(_TNgay, _DNgay, _TenKhoa);
                    rpt.Show();
                }
                if (rd_datravai.Checked == true)
                {
                    NamDinh_QLBN.Reports.rptPhieuTraVai rpt = new NamDinh_QLBN.Reports.rptPhieuTraVai(_TNgay, _DNgay, _TenKhoa);
                    rpt.Show();
                }
                this.DialogResult = DialogResult.OK;
            }
        }
        private void frmTNgayDNgay_Vai_Load(object sender, EventArgs e)
        {
            LoatDanhMuc();
        }
    }
}