using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NamDinh_QLBN.Forms.DuLieu
{
    public partial class frmHoiChan : Form
    {
        private String _MaVaoVien = "";
        public frmHoiChan(String MaVaoVien)
        {
            InitializeComponent();
            _MaVaoVien = MaVaoVien;
            cmbLoai.AddItem(String.Format("{0};{1}", 1, "Hội chẩn khoa"));
            cmbLoai.AddItem(String.Format("{0};{1}", 2, "Hội chẩn liên khoa"));
            cmbLoai.AddItem(String.Format("{0};{1}", 3, "Hội chẩn toàn viện"));
            cmbLoai.AddItem(String.Format("{0};{1}", 4, "Hội chẩn liên bệnh viện"));
            cmbLoai.SelectedValue = "1";
        }

        private void LoatDanhMuc()
        {
            System.Data.SqlClient.SqlCommand Cmd = new System.Data.SqlClient.SqlCommand("", GlobalModuls.Global.ConnectSQL);
            System.Data.SqlClient.SqlDataReader dr;
            try
            {
                //Cmd.CommandText = String.Format("select * from dmbacsy where makhoa in {0}", GlobalModuls.Global.glbKhoa_CapNhat);
                //dr = Cmd.ExecuteReader();
                //while (dr.Read())
                //{
                //    cmbChuToa.AddItem(String.Format("{0};{1}", dr["MaBS"], dr["TenBS"]));
                //    cmbThuKi.AddItem(String.Format("{0};{1}", dr["MaBS"], dr["TenBS"]));
                //}
                //dr.Close();
                Cmd.CommandText = String.Format("if(exists(select mavaovien from benhnhan_hoichan where mavaovien='{0}' and Loai={1}))"
                    + " begin"
                    + " select Loai,BienBanHC,DieuTriTNgay,DieuTriDNgay,ChanDoan,NgayHoiChan,ChuToa,ThuKy,ThanhVienTG,TomTat,KetLuan,HuongDT "
                    + " ,ChamSoc,TinhTrangVV,TieuSuBenh,ChanDoanKL,DiaDiem,BacSyDeXuat,ThanhVienTG2"
                    + " from benhnhan_hoichan where mavaovien='{0}' and Loai={1} "
                    + " end"
                    + " else"
                    + " begin"
                    + " select 1 as Loai,'' as BienBanHC,getdate() as DieuTriTNgay,getdate() as DieuTriDNgay,getdate() as NgayHoiChan,ChanDoan,'' as ChuToa,"
                    + " '' as ThuKy,'' as ThanhVienTG,'' as TomTat,'' as KetLuan,'' as HuongDT ,'' as ChamSoc,'' as TinhTrangVV,'' as TieuSuBenh,'' as ChanDoanKL,'' as DiaDiem"
                    + " ,'' as BacSyDeXuat,'' as ThanhVienTG2 from ViewKhoaHienTai where mavaovien='{0}'"
                    + " end", _MaVaoVien,cmbLoai.SelectedValue);
                dr = Cmd.ExecuteReader();
                while (dr.Read())
                {
                    //cmbLoai.SelectedValue = dr["Loai"].ToString();
                    txtBienBan.Text = dr["BienBanHC"].ToString();
                    txtChanDoan.Text = dr["ChanDoan"].ToString();
                    txtDenNgay.Value = dr["DieuTriDNgay"];
                    txtHuongDT.Text = dr["HuongDT"].ToString();
                    txtKetLuan.Text = dr["KetLuan"].ToString();
                    txtThanhVienTG.Text = dr["ThanhVienTG"].ToString() + dr["ThanhVienTG2"].ToString();
                    txtThoiGianHoiChan.Value = dr["NgayHoiChan"];
                    txtTomTat.Text = dr["TomTat"].ToString();
                    txtTuNgay.Value = dr["DieuTriTNgay"];
                    txtChuToa.Text = dr["ChuToa"].ToString();
                    txtThuKy.Text = dr["ThuKy"].ToString();
                    txtChamSoc.Text = dr["ChamSoc"].ToString();
                    txtTinhTrangVV.Text = dr["TinhTrangVV"].ToString();
                    txtKLChanDoan.Text = dr["ChanDoanKL"].ToString();
                    txtTieuSuBenh.Text = dr["TieuSuBenh"].ToString();
                    txtDiaDiem.Text = dr["DiaDiem"].ToString();
                    txtBacSyDeXuat.Text = dr["BacSyDeXuat"].ToString();
                }
                dr.Close();
            }
            catch
            {
            }
            finally
            {
                Cmd.Dispose();
            }
        }

        private void cmdThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
        void SaveData()
        {
            string ThanhVienTG="",ThanhVienTG2="";
            string[] s = txtThanhVienTG.Text.Split('\n');
            for (int i = 0; i < s.Length; i++)
            {
                string s1 = s[i];
                if (i < 5) ThanhVienTG += s[i] + "\n";
                else ThanhVienTG2 +=s[i] + "\n";
            }
            System.Data.SqlClient.SqlCommand Cmd = new System.Data.SqlClient.SqlCommand("", GlobalModuls.Global.ConnectSQL);
            try
            {
                Cmd.CommandText = String.Format("set dateformat mdy if(exists(select * from benhnhan_hoichan where mavaovien='{12}' and Loai='{11}'))"
                    + " begin"
                    + " update benhnhan_hoichan set BienBanHC=N'{0}',DieuTriTNgay='{1:MM/dd/yyyy}',DieuTriDNgay='{2:MM/dd/yyyy}',"
                    + " ChanDoan=N'{3}',NgayHoiChan='{4:MM/dd/yyyy HH:mm}',ChuToa=N'{5}',ThuKy=N'{6}',ThanhVienTG=N'{7}',TomTat=N'{8}',"
                    + " KetLuan=N'{9}',HuongDT=N'{10}',TieuSuBenh=N'{13}',TinhTrangVV=N'{14}',ChanDoanKL=N'{15}',ChamSoc=N'{16}',DiaDiem=N'{17}',BacSyDeXuat=N'{18}',ThanhVienTG2=N'{19}'"
                    + " where MaVaoVien='{12}' and Loai='{11}'"
                    + " end"
                    + " else"
                    + " begin"
                    + " insert into benhnhan_hoichan(BienBanHC,DieuTriTNgay,DieuTriDNgay,ChanDoan,NgayHoiChan,ChuToa,ThuKy,ThanhVienTG,TomTat,KetLuan,HuongDT"
                    + " ,TieuSuBenh,TinhTrangVV,ChanDoanKL,ChamSoc,DiaDiem,BacSyDeXuat,ThanhVienTG2,MaVaoVien,Loai)"
                    + " values(N'{0}','{1:MM/dd/yyyy}','{2:MM/dd/yyyy}',N'{3}','{4:MM/dd/yyyy HH:mm}',N'{5}',N'{6}',N'{7}',N'{8}',N'{9}',N'{10}',N'{13}',N'{14}',N'{15}',N'{16}',N'{17}',N'{18}',N'{19}','{12}','{11}')"
                    + " end", txtBienBan.Text.Trim(), txtTuNgay.Value, txtDenNgay.Value, txtChanDoan.Text.Trim(), txtThoiGianHoiChan.Value, txtChuToa.Text.Trim(), txtThuKy.Text.Trim(),
                    ThanhVienTG, txtTomTat.Text.Trim(), txtKetLuan.Text.Trim(), txtHuongDT.Text.Trim(), cmbLoai.SelectedValue, _MaVaoVien, txtTieuSuBenh.Text,
                    txtTinhTrangVV.Text, txtKLChanDoan.Text, txtChamSoc.Text, txtDiaDiem.Text,txtBacSyDeXuat.Text,ThanhVienTG2);
                Cmd.ExecuteNonQuery();
                this.DialogResult = DialogResult.Yes;
            }
            catch
            {
                this.DialogResult = DialogResult.No;
            }
            finally
            {
                Cmd.Dispose();
            }
        }
        private void cmdGhi_Click(object sender, EventArgs e)
        {
            SaveData();
            NamDinh_QLBN.Reports.repHoiChan rep = new NamDinh_QLBN.Reports.repHoiChan(_MaVaoVien,cmbLoai.SelectedValue.ToString());
            rep.Show();
        }

        private void frmHoiChan_Load(object sender, EventArgs e)
        {
            LoatDanhMuc();
        }

        private void cmbLoai_TextChanged(object sender, EventArgs e)
        {
            LoatDanhMuc();
        }

        private void btnPhieuHoiChan_Click(object sender, EventArgs e)
        {
            SaveData();
            NamDinh_QLBN.Reports.repPhieuHoiChan rep = new NamDinh_QLBN.Reports.repPhieuHoiChan(_MaVaoVien,cmbLoai.SelectedValue.ToString());
            rep.Show();
        }
    }
}