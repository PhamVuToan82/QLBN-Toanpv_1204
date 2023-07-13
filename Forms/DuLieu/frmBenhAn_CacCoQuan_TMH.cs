using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GlobalModuls;
using System.Data.SqlClient;
namespace NamDinh_QLBN.Forms.DuLieu
{
    public partial class frmBenhAn_CacCoQuan_TMH : Form
    {
        private string  _MaVaoVien;
        private int _MauBenhAn = 0;
        public frmBenhAn_CacCoQuan_TMH(int MauBenhAn, string MaVaoVien)
        {
            InitializeComponent();
            _MaVaoVien = MaVaoVien;
            _MauBenhAn = MauBenhAn;
            LayThongTin(_MaVaoVien);
            if (_MauBenhAn == 5)
            {
                this.Text = "Cơ Quan Tai Mũi Họng";
                label6.Visible = true;
                label9.Visible = true;
                label11.Visible = true;
                label12.Visible = true;
                txtMangNhi.Visible = true;
                txtMui.Visible = true;
                txtThanhquanHong.Visible = true;
                txtCo.Visible = true;
                txtBenhChuyenKhoa.Width = 891;
                txtBenhChuyenKhoa.Height = 117;
            }
            if (_MauBenhAn == 7)
            {
                this.Text = "Cơ Quan Răng Hàm Mặt";
                txtBenhChuyenKhoa.Width = 893;
                txtBenhChuyenKhoa.Height = 182;
                label6.Visible = false;
                label9.Visible = false;
                label11.Visible = false;
                label12.Visible = false;
                txtMangNhi.Visible = false;
                txtMui.Visible = false;
                txtThanhquanHong.Visible = false;
                txtCo.Visible = false;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlCommand Cmd = new System.Data.SqlClient.SqlCommand("", GlobalModuls.Global.ConnectSQL);
            Cmd.CommandText = string.Format("set dateformat DMY if(exists(select * from BenhAn_ChiTiet where mavaovien='{0}'))"
                                            + " begin update BenhAn_ChiTiet set [BenhAn_CoQuanThanKinh] = N'{1}', [BenhAn_CoQuanTuanHoan] = N'{2}',[BenhAn_CoQuanHoHap]= N'{3}',[BenhAn_CoQuanTieuHoa] = N'{4}',[BenhAn_CoQuanCoXuongKhop] = N'{5}',[BenhAn_ThanTietNieuSinhDuc] = N'{6}', [BenhAn_DaVaMoDuoiDa] = N'{7}',[BenhAn_CoQuanKhac] = N'{8}' where  mavaovien='{0}' end"
                                            + " else insert into BenhAn_ChiTiet(MaVaoVien,BenhAn_CoQuanThanKinh,BenhAn_CoQuanTuanHoan,BenhAn_CoQuanHoHap,BenhAn_CoQuanTieuHoa,BenhAn_CoQuanCoXuongKhop,BenhAn_ThanTietNieuSinhDuc,BenhAn_DaVaMoDuoiDa,BenhAn_CoQuanKhac) "
                                            + " values('{0}',N'{1}',N'{2}',N'{3}',N'{4}',N'{5}',N'{6}',N'{7}',N'{8}')", _MaVaoVien, txtCoQuanThanKinh.Text, txtCoQuanTuanHoan.Text, txtCoQuanHoHap.Text, txtCoQuanTieuHoa.Text, txtCoQuanCoXuongKhop.Text, txtCoQuanThanTietNieuSinhDuc.Text, txtCoQuan_DaVaMoDuoiDa.Text, txtCoQuanKhac.Text);
            Cmd.ExecuteNonQuery();

            Cmd.CommandText = string.Format(" set dateformat DMY if(exists(select * from BenhAn_ChuyenKhoa where mavaovien='{0}'))"
                                 + " begin update BenhAn_ChuyenKhoa set [TMH_MangNhi] = N'{1}', [TMH_Mui] = N'{2}',[TMH_ThanhQuanHong]= N'{3}',[TMH_Co] = N'{4}',[Benh_ChuyenKhoa] = N'{5}' where  mavaovien='{0}' end"
                                 + " else insert into BenhAn_ChuyenKhoa(MaVaoVien,TMH_MangNhi,TMH_Mui,TMH_ThanhQuanHong,TMH_Co,Benh_ChuyenKhoa) "
                                 + " values('{0}',N'{1}',N'{2}',N'{3}',N'{4}',N'{5}')", _MaVaoVien, txtMangNhi.Text, txtMui.Text, txtThanhquanHong.Text, txtCo.Text,txtBenhChuyenKhoa.Text);
            Cmd.ExecuteNonQuery();

            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void LayThongTin(string MaVaoVien)
        {
            System.Data.SqlClient.SqlCommand Cmd = new System.Data.SqlClient.SqlCommand("", GlobalModuls.Global.ConnectSQL);
            Cmd.CommandText = string.Format("select BenhAn_CoQuanThanKinh,BenhAn_CoQuanTuanHoan,BenhAn_CoQuanHoHap,BenhAn_CoQuanTieuHoa,BenhAn_CoQuanCoXuongKhop,BenhAn_ThanTietNieuSinhDuc,BenhAn_DaVaMoDuoiDa,BenhAn_CoQuanKhac,TMH_MangNhi,TMH_Mui,TMH_ThanhQuanHong,TMH_Co,Benh_ChuyenKhoa from BenhAn_ChiTiet  A inner join BenhAn_ChuyenKhoa B ON A.MAVAOVIEN = B.MAVAOVIEN where A.Mavaovien = '{0}'", MaVaoVien);
            SqlDataReader reader = Cmd.ExecuteReader();
            while (reader.Read())
            {
                txtCoQuanThanKinh.Text = reader["BenhAn_CoQuanThanKinh"].ToString();
                txtCoQuanTuanHoan.Text = reader["BenhAn_CoQuanTuanHoan"].ToString();
                txtCoQuanHoHap.Text = reader["BenhAn_CoQuanHoHap"].ToString();
                txtCoQuanTieuHoa.Text = reader["BenhAn_CoQuanTieuHoa"].ToString();
                txtCoQuanCoXuongKhop.Text = reader["BenhAn_CoQuanCoXuongKhop"].ToString();
                txtCoQuanThanTietNieuSinhDuc.Text = reader["BenhAn_ThanTietNieuSinhDuc"].ToString();
                txtCoQuan_DaVaMoDuoiDa.Text = reader["BenhAn_DaVaMoDuoiDa"].ToString();
                txtCoQuanKhac.Text = reader["BenhAn_CoQuanKhac"].ToString();
                txtMangNhi.Text = reader["TMH_MangNhi"].ToString();
                txtMui.Text = reader["TMH_Mui"].ToString();
                txtThanhquanHong.Text = reader["TMH_ThanhQuanHong"].ToString();
                txtCo.Text = reader["TMH_Co"].ToString();
                txtBenhChuyenKhoa.Text = reader["Benh_ChuyenKhoa"].ToString();
            }
            reader.Close();
            Cmd.Dispose();
        }

        private void frmBenhAn_CacCoQuan_TMH_Load(object sender, EventArgs e)
        {
            //if (_MauBenhAn == 5)
            //{
            //    frmBenhAn_CacCoQuan_TMH tmh = new frmBenhAn_CacCoQuan_TMH(_MauBenhAn, _MaVaoVien);
            //    tmh.
            //    tmh.Text = "Cơ Quan Tai Mũi Họng";
            //}
            //if (_MauBenhAn == 7)
            //{
            //    frmBenhAn_CacCoQuan_TMH tmh = new frmBenhAn_CacCoQuan_TMH(_MauBenhAn, _MaVaoVien);
            //    tmh.Text = "Cơ Quan Răng Hàm Mặt";
            //}
        }
    }
}
