using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NamDinh_QLBN.Forms.In.PhauThuat
{
    public partial class frmXinMau : Form
    {
        private string _MaVaoVien, _SoPhieuCD, _NgaySD;
        public frmXinMau(String MaVaoVien,String SoPhieuCD,String NgaySD)
        {
            InitializeComponent();
            _MaVaoVien = MaVaoVien;
            _SoPhieuCD = SoPhieuCD;
            _NgaySD = NgaySD;
        }

        public void LoadDM()
        {
            cmbCapHayTT.ClearItems();
            cmbCapHayTT.AddItem(String.Format("0;Cấp"));
            cmbCapHayTT.AddItem(String.Format("1;Tự túc"));
            cmbNhomMau.ClearItems();
            cmbNhomMau.AddItem("0;Chưa xác định");
            cmbNhomMau.AddItem("1;A");
            cmbNhomMau.AddItem("2;AB");
            cmbNhomMau.AddItem("3;B");
            cmbNhomMau.AddItem("4;O");
        }

        private void frmXinMau_Load(object sender, EventArgs e)
        {
            LoadDM();
        }

        private void cmdThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdGhi_Click(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            SQLCmd.CommandText = String.Format("IF EXISTS(SELECT * FROM BENHNHAN_PT_MAU WHERE MAVAOVIEN ='{0}' AND SOPHIEUCD='{1}')"
                + " 	UPDATE BENHNHAN_PT_MAU SET LUONGMAU = {2},NHOMMAU='{3}',TRUYENLAN = {4},DATRUYEN={5},CAP_TUTUC={6},"
                + " 	LYDO = N'{7}' WHERE MAVAOVIEN ='{0}' AND SOPHIEUCD='{1}'"
                + " ELSE "
                + " 	INSERT INTO BENHNHAN_PT_MAU(MAVAOVIEN,SOPHIEUCD,LUONGMAU,NHOMMAU,TRUYENLAN,DATRUYEN,CAP_TUTUC,LYDO)"
                + " 	VALUES('{0}','{1}',{2},'{3}',{4},{5},{6},N'{7}')",
                _MaVaoVien,
                _SoPhieuCD,
                txtLuongMauXin.ValueIsDbNull == true ? "null": txtLuongMauXin.Value,
                GlobalModuls.Global.GetCode(cmbNhomMau),
                txtTruyenLan.ValueIsDbNull == true ? "null":txtTruyenLan.Value,
                txtDaTruyen.ValueIsDbNull == true ? "null" : txtDaTruyen.Value,
                GlobalModuls.Global.GetCode(cmbCapHayTT),
                txtLyDo.Text.Trim());
            dr = SQLCmd.ExecuteReader();
            dr.Close();
            NamDinh_QLBN.Reports.PhauThuat.repGiayXinMauOfPhongMo rep = new NamDinh_QLBN.Reports.PhauThuat.repGiayXinMauOfPhongMo(_MaVaoVien, _SoPhieuCD);
            rep.Show();
            NamDinh_QLBN.Reports.PhauThuat.repGiayLinhMauOfPhongMo rep1 = new NamDinh_QLBN.Reports.PhauThuat.repGiayLinhMauOfPhongMo(_NgaySD, _MaVaoVien, _SoPhieuCD);
            rep1.Show();
            this.Close();
        }
    }
}