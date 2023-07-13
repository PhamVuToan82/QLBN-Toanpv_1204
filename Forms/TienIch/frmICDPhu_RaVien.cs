using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GlobalModuls;


namespace NamDinh_QLBN.Forms.TienIch
{
    
    public partial class frmICDPhu_RaVien : Form
    {
        public string benhphu;
        public frmICDPhu_RaVien(string _benhphu)
        {
            InitializeComponent();
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
            SQLCmd.CommandText = "SELECT CICD10 as [Mã ICD],VViet as [Tên ICD] FROM DMICD10 WHERE CICD10 in ('" + _benhphu.Replace(";", "','") + "')";
            System.Data.SqlClient.SqlDataReader dr = SQLCmd.ExecuteReader();
            fgICD.Tag = "0";
            Global.BindDataReaderToFlex(dr, fgICD);
            fgICD.Tag = "1";
            dr.Close();
            SQLCmd.Dispose();
            for (int i = 1; i < fgICD.Rows.Count; i++)
                fgICD[i, "STT"] = i.ToString();

        }

        private void btn_ghi_Click(object sender, EventArgs e)
        {
            string benhphu_khoa = "";
            for (int num = 1; num < this.fgICD.Rows.Count; num++)
            {
                benhphu_khoa += fgICD[num, 1].ToString() + ";" ;
            }
            if (!String.IsNullOrEmpty(benhphu_khoa))
            {
                benhphu_khoa  = benhphu_khoa.Substring(0, benhphu_khoa.Length - 1);
            }
            else
            {
                benhphu_khoa = "";
            }
            benhphu = benhphu_khoa;
            this.DialogResult = DialogResult.OK;
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
