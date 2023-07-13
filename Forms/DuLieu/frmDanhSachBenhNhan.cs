using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GlobalModuls;
namespace NamDinh_QLBN.Forms.DuLieu
{
    public partial class frmDanhSachBenhNhan : Form
    {
        public frmDanhSachBenhNhan()
        {
            InitializeComponent();
        }

        private void frmDanhSachBenhNhan_Load(object sender, EventArgs e)
        {
            fgDanhSach.ClipSeparators = "|;";
            txtTuNgay.Value = DateTime.Now;
            txtDenNgay.Value = DateTime.Now;
            Load_CacDM();       
        }
        private void Load_CacDM()
        {
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            SQLCmd.CommandText = "SELECT * FROM DMKHOAPHONG WHERE MaKhoa IN " + Global.glbKhoa_CapNhat;
            dr = SQLCmd.ExecuteReader();
            cmbKhoa.Tag = "0";
            cmbKhoa.ClearItems();
            while (dr.Read())
            {
                cmbKhoa.AddItem(string.Format("{0};{1}", dr["MaKhoa"], dr["TenKhoa"]));
            }
            cmbKhoa.SelectedIndex = -1;
            cmbKhoa.Tag = "1";
            if (cmbKhoa.ListCount > 0) cmbKhoa.SelectedIndex = 0;
            dr.Close();
            SQLCmd.Dispose();
            cmbDanhSach.Tag = "0";
            cmbDanhSach.AddItem("1;Bệnh nhân đang điều trị");
            cmbDanhSach.AddItem("2;Bệnh nhân vào Khoa điều trị");
            cmbDanhSach.AddItem("3;Bệnh nhân chuyển đến Khoa");
            cmbDanhSach.AddItem("4;Bệnh nhân chuyển Khoa");
            cmbDanhSach.AddItem("5;Bệnh nhân đã ra viện");
            cmbDanhSach.SelectedIndex = -1;
            cmbDanhSach.Tag = "1";
        }
        private void LoadDSBN(int LoaiDanhSach)
        {
            string FieldName="";
            string DKNgay = "";
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
            

            switch (LoaiDanhSach)
            {
                case 0: //Benh nhan dang dieu tri
                    SQLCmd.CommandText = "SELECT a.MaBenhNhan,b.MaVaoVien,a.HoTen As [Họ tên],Year(Getdate())-NamSinh AS [Tuổi],CASE GioiTinh WHEN 1 THEN 'Nam' ELSE N'Nữ' END As [Giới tính],TenDT As [Đối tượng],"
                                + " NgayVaoVien As [Ngày vào viện], c.NgayChuyen As [Ngày vào khoa],ChanDoan_KhoaDT as [Chẩn đoán] FROM "
                                + " (((BENHNHAN a INNER JOIN BENHNHAN_CHITIET b ON a.MaBenhNhan=b.MaBenhNhan)"
                                + " INNER JOIN ViewKHOAHIENTAI c ON b.MaVaoVien=c.MaVaoVien)"
                                + " INNER JOIN ViewDOITUONGHIENTAI d ON b.MaVaoVien=d.MaVaoVien)"
                                + " INNER JOIN DMDOITUONGBN e ON d.DoiTuong=e.MaDT"
                                + " WHERE c.vDaRaVien=0 AND TrangThai=1";        
                    
                    break;
                case 1: //Benh nhan vao Khoa
                    SQLCmd.CommandText = "SELECT a.MaBenhNhan,b.MaVaoVien,a.HoTen As [Họ tên],Year(Getdate())-NamSinh AS [Tuổi],CASE GioiTinh WHEN 1 THEN 'Nam' ELSE N'Nữ' END As [Giới tính],TenDT As [Đối tượng],"
                                + " NgayVaoVien As [Ngày vào viện], c.NgayChuyen As [Ngày vào khoa],ChanDoan_KhoaDT as [Chẩn đoán],"
                                + " CASE c.VDaRaVien WHEN 0 THEN N'Đang điều trị' ELSE N'Đã ra viện' END As [Trạng thái] FROM "
                                + " (((BENHNHAN a INNER JOIN BENHNHAN_CHITIET b ON a.MaBenhNhan=b.MaBenhNhan)"
                                + " INNER JOIN ViewKHOAHIENTAI c ON b.MaVaoVien=c.MaVaoVien)"
                                + " INNER JOIN ViewDOITUONGHIENTAI d ON b.MaVaoVien=d.MaVaoVien)"
                                + " INNER JOIN DMDOITUONGBN e ON d.DoiTuong=e.MaDT"
                                + " WHERE TrangThai=1";        
                                FieldName = " c.NgayChuyen";
                    break;
                case 3: //Benh nhan chuyen den Khoa
                    SQLCmd.CommandText = "SELECT a.MaBenhNhan,b.MaVaoVien,a.HoTen As [Họ tên],Year(Getdate())-NamSinh AS [Tuổi],CASE GioiTinh WHEN 1 THEN 'Nam' ELSE N'Nữ' END As [Giới tính],TenDT As [Đối tượng],"
                                + " NgayVaoVien As [Ngày vào viện], c.NgayChuyen As [Ngày chuyển khoa],ChanDoan_KhoaDT as [Chẩn đoán],"
                                + " FROM "
                                + " (((BENHNHAN a INNER JOIN BENHNHAN_CHITIET b ON a.MaBenhNhan=b.MaBenhNhan)"
                                + " INNER JOIN ViewKHOAHIENTAI c ON b.MaVaoVien=c.MaVaoVien)"
                                + " INNER JOIN ViewDOITUONGHIENTAI d ON b.MaVaoVien=d.MaVaoVien)"
                                + " INNER JOIN DMDOITUONGBN e ON d.DoiTuong=e.MaDT"
                                + " WHERE TrangThai=2";
                    FieldName = " c.NgayChuyen";
                    break;
                case 4: //Benh nhan ra Vien
                    SQLCmd.CommandText = "SELECT a.MaBenhNhan,b.MaVaoVien,a.HoTen As [Họ tên],Year(Getdate())-NamSinh AS [Tuổi],CASE GioiTinh WHEN 1 THEN 'Nam' ELSE N'Nữ' END As [Giới tính],TenDT As [Đối tượng],"
                                + " NgayVaoVien As [Ngày vào viện], NgayraVien As [Ngày ra viện],ChanDoan_KhoaDT as [Chẩn đoán] "
                                + " FROM "
                                + " (((BENHNHAN a INNER JOIN BENHNHAN_CHITIET b ON a.MaBenhNhan=b.MaBenhNhan)"
                                + " INNER JOIN ViewKHOAHIENTAI c ON b.MaVaoVien=c.MaVaoVien)"
                                + " INNER JOIN ViewDOITUONGHIENTAI d ON b.MaVaoVien=d.MaVaoVien)"
                                + " INNER JOIN DMDOITUONGBN e ON d.DoiTuong=e.MaDT"
                                + " WHERE c.vDaRaVien=1 AND TrangThai=1 ";
                    FieldName = " NgayRaVien";
                    break;
            }
            if (SQLCmd.CommandText.Length > 0)
            {
                if (cmbKhoa.SelectedIndex > -1)
                {
                    SQLCmd.CommandText += " AND c.MaKhoa='" + Global.GetCode(cmbKhoa) + "'";
                }
                if (!txtTuNgay.ValueIsDbNull && !txtDenNgay.ValueIsDbNull && FieldName !="")
                {
                    DKNgay = string.Format(" AND {0} BETWEEN '{1:MM/dd/yyyy} 00:00' AND '{2:MM/dd/yyyy} 23:59' ", FieldName, txtTuNgay.Value, txtDenNgay.Value);
                }
                SQLCmd.CommandText += DKNgay;
                System.Data.SqlClient.SqlDataReader dr = SQLCmd.ExecuteReader();
                fgDanhSach.Tag = "0";
                Global.BindDataReaderToFlex(dr, fgDanhSach);
                fgDanhSach.Tag = "1";
                dr.Close();
            }
            SQLCmd.Dispose();
        }

        private void cmbDanhSach_TextChanged(object sender, EventArgs e)
        {
            if (cmbDanhSach.Tag.ToString() == "0"||cmbDanhSach.SelectedIndex ==-1) return;
            int LoaiDanhSach = cmbDanhSach.SelectedIndex;
            txtTuNgay.Enabled = txtDenNgay.Enabled = true;
            switch (LoaiDanhSach)
            {
                case 0:
                    txtTuNgay.Enabled = txtDenNgay.Enabled = false ;
                    txtTuNgay.Value = null;
                    txtDenNgay.Value = null;
                    break;
                case 1:
                    break;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (cmbDanhSach.SelectedIndex == -1 || cmbKhoa.SelectedIndex ==-1) return;
            int LoaiDanhSach = cmbDanhSach.SelectedIndex; 
            LoadDSBN(LoaiDanhSach);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (fgDanhSach.Row < 1) return;
            string MaVaoVien = fgDanhSach[fgDanhSach.Row, "MaVaoVien"].ToString();
            NamDinh_QLBN.Reports.rptGiayRaVien rpt = new NamDinh_QLBN.Reports.rptGiayRaVien(MaVaoVien);
            rpt.Show();
        }
    }
}