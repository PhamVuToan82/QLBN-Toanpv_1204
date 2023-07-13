using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NamDinh_QLBN.Forms.DuLieu
{
    public partial class frmThongTinBN_PK : Form
    {
        private string MaDVK = "";
        private string MaPK = "";
        private DateTime NgayKham;
        public frmThongTinBN_PK()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            //string MaKhoa=Global.GetCode(cmbKhoa);
            
            if (txtMaBN.Text.Length == 3) txtMaBN.Text = string.Format("{0:yyMMdd}", GlobalModuls.Global.NgayLV) + txtMaBN.Text;

            SQLCmd.CommandText = string.Format("SELECT TenBenhNhan,Case GioiTinh WHEN 1 Then N'Nam' ELSE N'Nữ' END As GioiTinh,TenDT,NgayKham,HuongGQ,MaBS,TenKhoa,MaPK,MaDVK "
                                                + " FROM (([KHAMBENH103].DBO.tblBENHNHAN a INNER JOIN [KHAMBENH103].DBO.tblKHAMBENH b ON a.MaBenhNhan=b.MaBenhNhan) "
                                                + " INNER JOIN DMDOITUONGBN c ON a.MaDoiTuong = c.MaDT) "
                                                + " INNER JOIN DMKHOAPHONG d ON b.MaPK=d.MaKhoa "
                                                + " WHERE DaKham = 1 AND a.MaBenhNhan='{0}'",txtMaBN.Text);
           
            dr = SQLCmd.ExecuteReader();
            Clear_Data();
            if (dr.Read())
            {
                lblHoTen.Text = dr["TenBenhNhan"].ToString();
                lblDoiTuong.Text = dr["TenDT"].ToString();
                lblPhongKham.Text = dr["TenKhoa"].ToString();
                lblBacSy.Text = dr["MaBS"].ToString();
                lblNgayKham.Text = string.Format("{0:dd/MM/yyyy HH:mm}",dr["NgayKham"]);
                switch (dr["HuongGQ"].ToString())
                {
                    case "2": 
                        lblHuongGiaiQuyet.Text = "Ngoại trú";
                        break;
                    case "3": 
                        lblHuongGiaiQuyet.Text = "Chuyển viện";
                        break;
                    case "4":
                        lblHuongGiaiQuyet.Text = "Nhập viện";
                        chkVaoVien.Checked = true;
                        break;
                }
                MaPK = dr["MaPK"].ToString();
                MaDVK = dr["MaDVK"].ToString();
                NgayKham = (DateTime)dr["NgayKham"];
            }
            dr.Close();
            SQLCmd.Dispose();
        }

        private void frmThongTinBN_PK_Load(object sender, EventArgs e)
        {
            Clear_Data();
            
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("SELECT * FROM DMKHOAPHONG ",GlobalModuls.Global.ConnectSQL);
            System.Data.SqlClient.SqlDataReader dr = SQLCmd.ExecuteReader();
            cmbKhoa.ClearItems();
            while (dr.Read())
            {
                cmbKhoa.AddItem(string.Format("{0};{1}", dr["MaKhoa"], dr["TenTat"]));
            }
            dr.Close();
            SQLCmd.Dispose();
        }
        private void Clear_Data()
        {
            lblHoTen.Text = "";
            lblDoiTuong.Text = "";
            lblPhongKham.Text = "";
            lblBacSy.Text= "";
            lblNgayKham.Text = "";
            lblHuongGiaiQuyet.Text = "";
            chkVaoVien.Checked = false;
            MaDVK = "";
            MaPK = "";
            cmbKhoa.SelectedIndex = -1;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void cmdGhi_Click(object sender, EventArgs e)
        {
            if (txtMaBN.Text == "" || chkVaoVien.Checked ==false) return;
            if (cmbKhoa.SelectedIndex == -1)
            {
                MessageBox.Show("Chưa chọn khoa vào viện!", "Thông báo");
                return;
            }
            string MaKhoa = GlobalModuls.Global.GetCode(cmbKhoa);
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", GlobalModuls.Global.ConnectSQL);
            SQLCmd.CommandText = string.Format("UPDATE [KHAMBENH103].DBO.tblKhamBenh SET HuongGQ=4,MaKhoaDieuTri='" + MaKhoa + "' WHERE MaBenhNhan='{0}' AND NgayKham='{1:MM/dd/yyyy}' AND MaPK='{2}' AND MaDVK='{3}'", txtMaBN.Text, NgayKham, MaPK, MaDVK);
            try
            {
                SQLCmd.ExecuteNonQuery();
                MessageBox.Show("Đã chuyển hướng giải quyết!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                SQLCmd.Dispose();
            }

        }
    }
}