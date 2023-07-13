using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NamDinh_QLBN.Forms.DuLieu
{
    public partial class frmThongTinMo : Form
    {
        private string _MaVaoVien = "";
        public frmThongTinMo(String MaVaoVien)
        {
            InitializeComponent();
            _MaVaoVien = MaVaoVien;
        }

        private void cmdThoat_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }

        private void LoadData()
        {
            System.Data.SqlClient.SqlCommand Cmd = new System.Data.SqlClient.SqlCommand("", GlobalModuls.Global.ConnectSQL);
            System.Data.SqlClient.SqlDataReader dr;
            try
            {
                Cmd.CommandText = "Select * from thongtin_phauthuat where mavaovien='" + _MaVaoVien + "'";
                dr = Cmd.ExecuteReader();
                while (dr.Read())
                {
                    txtBenhLy.Text = dr["QuaTrinhBL"].ToString();
                    txtChuanBi.Text = dr["ChuanBi"].ToString();
                    txtDuTruMau.Text = dr["DuTruMau"].ToString();
                    txtKhoKhan.Text = dr["KhoKhan"].ToString();
                    txtNguoiGayMe.Text = dr["GayMe"].ToString();
                    txtNguoiPhụ.Text = dr["NguoiPhu"].ToString();
                    txtNguoiThucHien.Text = dr["NguoiThucHien"].ToString();
                    txtPhuongPhapDK.Text = dr["PhuongPhapDK"].ToString();
                    txtVoCam.Text = dr["VoCam"].ToString();
                    txtLanMo.Text = dr["LanMo"].ToString();
                    txtNgayMo.Value = dr["NgayMo"].ToString() == "" ? GlobalModuls.Global.NgayLV : dr["NgayMo"];
                    txtSoTienThu.Value = dr["SoTien"].ToString() == "" ? 0 : dr["SoTien"];
                    txtSoBL.Text = dr["SoBienlai"].ToString();
                    txtLanhDao.Text = dr["LanhDaoDuyet"].ToString();
                    txtLoai.Text = dr["LoaiPT"].ToString();
                    txtTPKhac.Text = dr["TPKhac"].ToString();
                }
                dr.Close();
            }
            catch
            {
            }
            finally
            {
            }
        }

        private void cmdGhi_Click(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlCommand Cmd = new System.Data.SqlClient.SqlCommand("", GlobalModuls.Global.ConnectSQL);
            try
            {
                Cmd.CommandText = String.Format("if(exists(select * from thongtin_phauthuat where mavaovien ='{0}'))"
                    + " begin"
                    + " update thongtin_phauthuat set QuaTrinhBL=N'{1}',PhuongPhapDK=N'{2}',NguoiThucHien=N'{3}',NguoiPhu=N'{4}',ChuanBi=N'{5}',"
                    + " VoCam=N'{6}',GayMe=N'{7}',DuTruMau=N'{8}',KhoKhan=N'{9}',LanMo=N'{10}',NgayMo='{11:MM/dd/yyyy HH:mm}'"
                    + " ,SoTien={12},SoBienlai=N'{13}',LanhDaoDuyet=N'{14}',LoaiPT=N'{15}',TPKhac = N'{16}' where mavaovien='{0}'"
                    + " end"
                    + " else"
                    + " begin"
                    + " insert into thongtin_phauthuat(mavaovien,quatrinhbl,phuongphapDK,nguoithuchien,NguoiPhu,ChuanBi,VoCam,GayMe,DuTruMau,KhoKhan,LanMo,"
                    + " NgayMo,SoTien,SoBienLai,LanhDaoDuyet,LoaiPT,TPKhac)"
                    + " values('{0}',N'{1}',N'{2}',N'{3}',N'{4}',N'{5}',N'{6}',N'{7}',N'{8}',N'{9}',N'{10}','{11:MM/dd/yyyy HH:mm}'"
                    + " ,{12},N'{13}',N'{14}',N'{15}',N'{16}')"
                    + " end", _MaVaoVien, txtBenhLy.Text.Trim(), txtPhuongPhapDK.Text.Trim(), txtNguoiThucHien.Text.Trim(), txtNguoiPhụ.Text.Trim(),
                    txtChuanBi.Text.Trim(), txtVoCam.Text.Trim(), txtNguoiGayMe.Text.Trim(), txtDuTruMau.Text.Trim(), txtKhoKhan.Text.Trim(),txtLanMo.Text.Trim(),
                    txtNgayMo.Value,txtSoTienThu.Value.ToString().Replace(",","."),txtSoBL.Text.Trim(),txtLanhDao.Text.Trim(),txtLoai.Text.Trim(),txtTPKhac.Text.Trim());
                Cmd.ExecuteNonQuery();
                this.DialogResult = DialogResult.Yes;
            }
            catch(Exception ex)
            {
                this.DialogResult = DialogResult.No;
                MessageBox.Show(ex.ToString());
            }
            finally
            {
            }
        }

        private void frmThongTinMo_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}