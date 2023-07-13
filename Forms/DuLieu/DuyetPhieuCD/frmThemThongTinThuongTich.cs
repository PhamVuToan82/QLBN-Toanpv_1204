using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NamDinh_QLBN.Forms.DuLieu.DuyetPhieuCD
{
    public partial class frmThemThongTinThuongTich : Form
    {
        public string _mavaovien = "";
        public frmThemThongTinThuongTich(string MaVaovien)
        {
            InitializeComponent();
            _mavaovien = MaVaovien;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlDataReader dr;
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            SQLCmd.CommandText = string.Format("select TaiNan_Truoc,TaiNan_Sau from Benhnhan_chitiet where Mavaovien = '{0}'", _mavaovien);
            dr = SQLCmd.ExecuteReader();
            while (dr.Read())
            {
                txtThuongTich_Befor.Text = dr["TaiNan_Truoc"].ToString();
                txtThuongTich_After.Text = dr["TaiNan_Sau"].ToString();
            }
            dr.Close();
            SQLCmd.Dispose();
        }
        private void BtnGhi_Click(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            SQLCmd.CommandText = string.Format("Update Benhnhan_chitiet set TaiNan_Truoc = N'{1}',TaiNan_Sau = N'{2}'where Mavaovien = '{0}'", _mavaovien,txtThuongTich_Befor.Text,txtThuongTich_After.Text);
            SQLCmd.ExecuteNonQuery();
            SQLCmd.Dispose();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Reports.rptCNThuongTich rep = new NamDinh_QLBN.Reports.rptCNThuongTich(_mavaovien);
            rep.Show();
        }
    }
}
