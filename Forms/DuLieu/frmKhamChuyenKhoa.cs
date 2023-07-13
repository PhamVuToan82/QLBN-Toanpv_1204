using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using GlobalModuls;
using NamDinh_QLBN.Reports;
namespace NamDinh_QLBN.Forms.DuLieu
{
    public partial class frmKhamChuyenKhoa : Form
    {
        private String _MaKhoa = "",_MaVaoVien ;

        public frmKhamChuyenKhoa(String MaKhoa,String MaVaoVien)
        {
            InitializeComponent();
            _MaKhoa = MaKhoa;
            _MaVaoVien = MaVaoVien;
        }

        private void cmdThoat_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void Load_CacDM()
        {
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;

            SQLCmd.CommandText = "Select * from dmbacsy where  Khongsudung = 0 and makhoa  in " + Global.glbKhoa_CapNhat;
            dr = SQLCmd.ExecuteReader();
            cmbBacSyDT.ClearItems();
            while (dr.Read())
            {
                cmbBacSyDT.AddItem(String.Format("{0};{1}", dr["MaBS"], dr["TenBS"]));
            }
            dr.Close();
            SQLCmd.Dispose();
            txtNgayIn.Value = Global.NgayLV;
        }

        private void Getdata()
        {
            SqlCommand SQLCmd = new SqlCommand("", GlobalModuls.Global.ConnectSQL);
            SqlDataReader dr;
            try
            {
                SQLCmd.CommandText = String.Format("Select * from benhnhan_khamck where mavaovien='{0}' and makhoa='{1}' and lankham= (select max(lankham) from "
                    + " benhnhan_khamck where mavaovien='{0}' and makhoa='{1}')", _MaVaoVien, _MaKhoa);
                dr = SQLCmd.ExecuteReader();
                while (dr.Read())
                {
                    cmbBacSyDT.SelectedIndex = cmbBacSyDT.FindStringExact(dr["BacSiYeuCau"].ToString(), 0, 1);
                    txtChanDoan.Text = dr["ChanDoan"].ToString();
                    txtKinhGui.Text = dr["KinhGui"].ToString();
                    txtYeuCauKham.Text = dr["YeuCauKham"].ToString();
                }
                dr.Close();
            }
            catch
            {
            }
            finally
            {
                SQLCmd.Dispose();
            }
        }

        private void cmdGhi_Click(object sender, EventArgs e)
        {
            SqlCommand SQLCmd = new SqlCommand("", GlobalModuls.Global.ConnectSQL);
            try
            {
                SQLCmd.CommandText = String.Format("insert into BenhNhan_KhamCK(MaKhoa,MaVaoVien,KinhGui,ChanDoan,YeuCauKham,BacSiYeuCau) Values('{0}','{1}',N'{2}',N'{3}',N'{4}',N'{5}')",
                    _MaKhoa,_MaVaoVien,txtKinhGui.Text.Trim(),txtChanDoan.Text.Trim(),txtYeuCauKham.Text.Trim(),cmbBacSyDT.Text.Trim(),txtNgayIn.Text);
                SQLCmd.ExecuteNonQuery();
                rptPhieuKhamChuyenKhoa khoa2 = new rptPhieuKhamChuyenKhoa(_MaVaoVien, _MaKhoa, txtNgayIn.Text);
                khoa2.Run();
                khoa2.Show();

            }
            catch
            {
                this.DialogResult = DialogResult.No;
            }
            finally
            {
                SQLCmd.Dispose();
            }
        }

        private void frmKhamChuyenKhoa_Load(object sender, EventArgs e)
        {
            Load_CacDM();
            Getdata();
        }
    }
}