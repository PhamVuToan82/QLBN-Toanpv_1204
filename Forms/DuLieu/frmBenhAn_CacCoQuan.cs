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
    public partial class frmBenhAn_CacCoQuan : Form
    {
        private string _MauBenhAn,_MaVaoVien;
        public frmBenhAn_CacCoQuan(string MauBenhAn, string MaVaoVien)
        {
            InitializeComponent();
            _MaVaoVien = MaVaoVien;
            MauBenhAn = _MauBenhAn;
            LayThongTin(_MaVaoVien);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlCommand Cmd = new System.Data.SqlClient.SqlCommand("", GlobalModuls.Global.ConnectSQL);
            Cmd.CommandText = string.Format("set dateformat DMY if(exists(select * from BenhAn_ChiTiet where mavaovien='{0}'))"
                                            + " begin update BenhAn_ChiTiet set [BenhAn_CoQuanThanKinh] = N'{1}', [BenhAn_CoQuanTuanHoan] = N'{2}',[BenhAn_CoQuanHoHap]= N'{3}',[BenhAn_CoQuanTieuHoa] = N'{4}',[BenhAn_CoQuanCoXuongKhop] = N'{5}',[BenhAn_CoQuanTietNieu] = N'{6}', [BenhAn_CoQuanSinhDuc] = N'{7}',[BenhAn_CoQuanKhac] = N'{8}' where  mavaovien='{0}' end"
                                            + " else insert into BenhAn_ChiTiet(MaVaoVien,BenhAn_CoQuanThanKinh,BenhAn_CoQuanTuanHoan,BenhAn_CoQuanHoHap,BenhAn_CoQuanTieuHoa,BenhAn_CoQuanCoXuongKhop,BenhAn_CoQuanTietNieu,BenhAn_CoQuanSinhDuc,BenhAn_CoQuanKhac) "
                                            + " values('{0}',N'{1}',N'{2}',N'{3}',N'{4}',N'{5}',N'{6}',N'{7}',N'{8}')", _MaVaoVien, txtCoQuanThanKinh.Text, txtCoQuanTuanHoan.Text, txtCoQuanHoHap.Text, txtCoQuanTieuHoa.Text, txtCoQuanCoXuongKhop.Text, txtCoQuanTietNieu.Text, txtCoQuanSinhDuc.Text, txtCoQuanKhac.Text);
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
            Cmd.CommandText = string.Format("select BenhAn_CoQuanThanKinh, BenhAn_CoQuanTuanHoan, BenhAn_CoQuanHoHap, BenhAn_CoQuanTieuHoa, BenhAn_CoQuanCoXuongKhop, BenhAn_CoQuanTietNieu, BenhAn_CoQuanSinhDuc, BenhAn_CoQuanKhac from BenhAn_ChiTiet where Mavaovien = '{0}'", MaVaoVien);
            SqlDataReader reader = Cmd.ExecuteReader();
            while (reader.Read())
            {
                txtCoQuanThanKinh.Text = reader["BenhAn_CoQuanThanKinh"].ToString();
                txtCoQuanTuanHoan.Text = reader["BenhAn_CoQuanTuanHoan"].ToString();
                txtCoQuanHoHap.Text = reader["BenhAn_CoQuanHoHap"].ToString();
                txtCoQuanTieuHoa.Text = reader["BenhAn_CoQuanTieuHoa"].ToString();
                txtCoQuanCoXuongKhop.Text = reader["BenhAn_CoQuanCoXuongKhop"].ToString();
                txtCoQuanTietNieu.Text = reader["BenhAn_CoQuanTietNieu"].ToString();
                txtCoQuanSinhDuc.Text = reader["BenhAn_CoQuanSinhDuc"].ToString();
                txtCoQuanKhac.Text = reader["BenhAn_CoQuanKhac"].ToString();
            }
            reader.Close();
            Cmd.Dispose();
        }
    }
}
