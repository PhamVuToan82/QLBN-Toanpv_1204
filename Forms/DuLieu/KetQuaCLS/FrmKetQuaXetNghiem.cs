using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace NamDinh_QLBN.Forms.DuLieu.KetQuaCLS
{
    public partial class FrmKetQuaXetNghiem : Form
    {
        public string MaPhieuCD;
        public FrmKetQuaXetNghiem(string MaCD)
        {
            InitializeComponent();
            MaPhieuCD = MaCD;
        }

        private void cmdThoat_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void FrmKetQuaXetNghiem_Load(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("", GlobalModuls.Global.ConnectSQL);
            System.Data.SqlClient.SqlDataReader dr;
            cmd.CommandText = String.Format("EXECUTE SpdKetQuaXN '{0}'", MaPhieuCD);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                fgChiTiet.AddItem("");
                int row = fgChiTiet.Rows.Count - 1;
                for (int i  = 0;i< dr.FieldCount ;i++)
                {
                    fgChiTiet[row, dr.GetName(i)] = dr[i];
                }
            }
            dr.Close();
            cmd.Dispose();
            
            fgChiTiet.AutoSizeCols(0, fgChiTiet.Cols.Count - 1, 1);
            fgChiTiet.AutoSizeRows(0, 0, fgChiTiet.Rows.Count - 1, fgChiTiet.Cols.Count - 1, 1, C1.Win.C1FlexGrid.AutoSizeFlags.None);
            fgChiTiet.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.None, 0, 2, 0, "{0}");
            int STT = 0;
            for (int i = 1; i < fgChiTiet.Rows.Count; i++)
            {
                if (fgChiTiet.GetDataDisplay(i, 1) == "")
                {
                    STT = 0;
                }
                else
                {
                    STT += 1;
                    fgChiTiet[i, 0] = STT;
                }
            }
        }
        private void label2_Click(object sender, EventArgs e)
        {
            Process.Start("chrome.exe", "http://172.16.2.2/Launch_Viewer.html?AccessionNumber=" + MaPhieuCD);
        }
    }
}