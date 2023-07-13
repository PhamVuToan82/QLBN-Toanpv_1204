using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NamDinh_QLBN.Forms.DuLieu
{
    public partial class frmSoKet15 : Form
    {
        Boolean booThemdon = false;// Đánh dấu tình trạng thêm, sửa đơn
        Boolean booSuadon = false;
        string Madonthuoc_Sua; // Mã đơn thuóc cần sửa thông tin
        private String _MaVaoVien = "";
        public frmSoKet15(String MaVaoVien)
        {
            InitializeComponent();
            _MaVaoVien = MaVaoVien;
        }

        private void LoadDSLanSoKet()
        {
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            SQLCmd.CommandText = String.Format("Select  LanSoKet, TuNgay, DenNgay, DienBien, XetNghiem, QuaTrinhDT, KetQua, HuongDT, NgaySoKet,MaBacSi,TenBacSi from tblSOKET15NGAY where MaVaoVien = '"+ _MaVaoVien +"' and MaKHoa = '"+ GlobalModuls.Global.glbMaKhoaPhong +"' ");
            dr = SQLCmd.ExecuteReader();
            grdDSDonthuoc.Tag = "0";
            grdDSDonthuoc.Rows.Count = 1;
            grdDSDonthuoc.ClipSeparators = "|;";
            while (dr.Read())
            {
                grdDSDonthuoc.AddItem(string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}", grdDSDonthuoc.Rows.Count,
                    dr["MaBacSi"],
                    dr["TenBacSi"],
                    dr["NgaySoket"],
                    dr["LanSoKet"],
                    dr["TuNgay"],
                    dr["DenNgay"],
                    dr["DienBien"],
                    dr["XetNghiem"],
                    dr["QuaTrinhDT"],
                    dr["KetQua"],
                    dr["HuongDT"]));
            }
            grdDSDonthuoc.Tag = "1";
            dr.Close();
            if (grdDSDonthuoc.Row > 0)
            {
                grdDSDonthuoc_AfterSelChange(null, null);
            }
        }
        private void Lock_Ctr_Kedon(bool DK)
        {
            cmdThemdon.Enabled = !DK;
            cmdSuadon.Enabled = !DK;
            cmdXoadon.Enabled = !DK;
            cmdLuu_XemDonthuoc.Enabled = !DK;
            cmdClosepanDonthuoc.Enabled = !DK;
            grdDSDonthuoc.Enabled = !DK;
            cmdLuuDonthuoc.Enabled = DK;
            cmdKhongLuuDonthuoc.Enabled = DK;
            cmbBacsi.Enabled = DK;
            txtDenNgay.Enabled = DK;
            txtDienBien.Enabled = DK;
            txtHuongDT.Enabled = DK;
            txtKetLuan.Enabled = DK;
            txtXetNghiem.Enabled = DK;
            txtTuNgay.Enabled = DK;
            txtNgaySoKet.Enabled = DK;
            txtQuaTrinhDT.Enabled = DK;
        }
        private void cmdThoat_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }

        private void cmdGhi_Click(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlCommand Cmd = new System.Data.SqlClient.SqlCommand("", GlobalModuls.Global.ConnectSQL);
            try
            {
                Cmd.CommandText = "";
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

        private void frmHoiChan_Load(object sender, EventArgs e)
        {
            
            System.Data.SqlClient.SqlCommand Cmd = new System.Data.SqlClient.SqlCommand("", GlobalModuls.Global.ConnectSQL);
            System.Data.SqlClient.SqlDataReader dr;
            Cmd.CommandText = String.Format("select * from dmbacsy where Khongsudung = 0  and makhoa in {0}", GlobalModuls.Global.glbKhoa_CapNhat);
            dr = Cmd.ExecuteReader();
            cmbBacsi.Tag = "0";
            cmbBacsi.ClearItems();
            while (dr.Read())
            {
                cmbBacsi.AddItem(String.Format("{0};{1}", dr["MaBS"], dr["TenBS"]));
            }
            dr.Close();
            if (cmbBacsi.ListCount > 0) cmbBacsi.SelectedIndex = 0;
            cmbBacsi.Tag = "1";
            LoadDSLanSoKet();
        }

        private void grdDSDonthuoc_AfterSelChange(object sender, C1.Win.C1FlexGrid.RangeEventArgs e)
        {
            if (grdDSDonthuoc.Row < 1 || grdDSDonthuoc.Tag.ToString() == "0") return;
            txtNgaySoKet.Value = grdDSDonthuoc[grdDSDonthuoc.Row, "NgaySoKet"];
            txtDenNgay.Value = grdDSDonthuoc[grdDSDonthuoc.Row, "DenNgay"];
            txtDienBien.Text = grdDSDonthuoc[grdDSDonthuoc.Row, "DienBien"].ToString();
            txtHuongDT.Text = grdDSDonthuoc[grdDSDonthuoc.Row, "HuongDT"].ToString();
            txtKetLuan.Text = grdDSDonthuoc[grdDSDonthuoc.Row, "KetQua"].ToString();
            txtXetNghiem.Text = grdDSDonthuoc[grdDSDonthuoc.Row, "XetNghiem"].ToString();
            txtQuaTrinhDT.Text = grdDSDonthuoc[grdDSDonthuoc.Row, "QuaTrinhDT"].ToString();
            txtTuNgay.Value = grdDSDonthuoc[grdDSDonthuoc.Row, "TuNgay"];

        }

        private void cmdThemdon_Click(object sender, EventArgs e)
        {
            Lock_Ctr_Kedon(true);
            booThemdon = true;
            txtNgaySoKet.Value = GlobalModuls.Global.GetNgayLV();
            txtDenNgay.Value = GlobalModuls.Global.GetNgayLV();
            txtDienBien.Text = "";
            txtHuongDT.Text = "";
            txtKetLuan.Text = "";
            txtXetNghiem.Text = "";
            txtQuaTrinhDT.Text = "";
            txtTuNgay.Value = GlobalModuls.Global.GetNgayLV();
            cmbBacsi.SelectedIndex = 0;
            cmbBacsi.Focus();
        }

        private void cmdSuadon_Click(object sender, EventArgs e)
        {
            if (grdDSDonthuoc.Row < 1)
            {
                MessageBox.Show("Chưa chọn lần sơ kết để sửa!!", "Thông báo");
                return;

            }
            else
            {
                Madonthuoc_Sua = grdDSDonthuoc.GetDataDisplay(grdDSDonthuoc.Row, 1);
            }
            Lock_Ctr_Kedon(true);
            booSuadon = true;
        }

        private void cmdXoadon_Click(object sender, EventArgs e)
        {

            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", GlobalModuls.Global.ConnectSQL);
            if (grdDSDonthuoc.Row < 1)
            {
                MessageBox.Show("Chưa chọn lần sơ kết để xóa", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            if (MessageBox.Show("Bạn có chắc chắn xóa lần sơ kết này không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SQLCmd.CommandText = "Delete from tblSOKET15NGAY where MaKhoa = '" + GlobalModuls.Global.glbMaKhoaPhong + "' and LanSoKet = '" + grdDSDonthuoc.GetDataDisplay(grdDSDonthuoc.Row, "LanSoKet") + "' and MaVaoVien = '"+ _MaVaoVien +"'";
                SQLCmd.ExecuteNonQuery();
            }
            LoadDSLanSoKet();
        }

        private void cmdLuuDonthuoc_Click(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", GlobalModuls.Global.ConnectSQL);
            if (booThemdon == true)
             {
                 int LanSKMoi = NewLanSoKet();
                 SQLCmd.CommandText = string.Format("set dateformat mdy Insert into tblSoKet15Ngay (MaVaoVien, MaKhoa , LanSoKet, TuNgay, DenNgay, XetNghiem, DienBien, QuaTrinhDT, KetQua, HuongDT, NgaySoKet, MaBacSi, TenBacSi)"
                                                   + " Values ('{0}','{1}',{2},'{3:MM/dd/yyyy}','{4:MM/dd/yyyy}',N'{5}',N'{6}',N'{7}',N'{8}',N'{9}','{10:MM/dd/yyyy}',N'{11}',N'{12}')",
                                                    _MaVaoVien,GlobalModuls.Global.glbMaKhoaPhong,LanSKMoi,txtTuNgay.Value,txtDenNgay.Value,txtXetNghiem.Text,txtDienBien.Text,txtQuaTrinhDT.Text,txtKetLuan.Text,txtHuongDT.Text,txtNgaySoKet.Value,
                                                    GlobalModuls.Global.GetCode(cmbBacsi),cmbBacsi.Text);
                 SQLCmd.ExecuteNonQuery();
             }
            else
            {
                if (booSuadon == true)
                {
                    SQLCmd.CommandText = string.Format("set dateformat mdy Update tblSoKet15Ngay set TuNgay ='{3:MM/dd/yyyy}',DenNgay='{4:MM/dd/yyyy}',XetNghiem = N'{5}', DienBien = N'{6}',QuaTrinhDT= N'{7}',KetQua = N'{8}',HuongDT = N'{9}',NgaySoKet = '{10:MM/dd/yyyy}',MaBacSi = N'{11}',TenBacSi = N'{12}' where  MaVaoVien = '{0}'and MaKhoa = '{1}' and LanSoKet = {2} ",
                                                    _MaVaoVien, GlobalModuls.Global.glbMaKhoaPhong, grdDSDonthuoc.GetDataDisplay(grdDSDonthuoc.Row, "LanSoKet"), txtTuNgay.Value, txtDenNgay.Value, txtXetNghiem.Text, txtDienBien.Text, txtQuaTrinhDT.Text, txtKetLuan.Text, txtHuongDT.Text, txtNgaySoKet.Value,
                                                    GlobalModuls.Global.GetCode(cmbBacsi), cmbBacsi.Text);
                    SQLCmd.ExecuteNonQuery();
                }
            }
            booSuadon = false;
            booThemdon = false;
            LoadDSLanSoKet();
            Lock_Ctr_Kedon(false);
        }
        private int NewLanSoKet()
        {
            int LanMoi = 0;
            System.Data.SqlClient.SqlCommand Cmd = new System.Data.SqlClient.SqlCommand("", GlobalModuls.Global.ConnectSQL);
            System.Data.SqlClient.SqlDataReader dr;
            Cmd.CommandText = String.Format("Select isnull(Max(LanSoKet),0)+1 as NewLan from tblSoKet15Ngay where MaVaoVien = '"+ _MaVaoVien +"' and MaKhoa = '"+ GlobalModuls.Global.glbMaKhoaPhong +"'  ");
            dr = Cmd.ExecuteReader();
            if (dr.Read())
            {
                LanMoi = int.Parse(dr["NewLan"].ToString());
                dr.Close();
            }
            else
            {
                LanMoi = 1;
            }
            return LanMoi;
        }

        private void cmdKhongLuuDonthuoc_Click(object sender, EventArgs e)
        {
            Lock_Ctr_Kedon(false);
            booThemdon = false;
            booSuadon = false;
            
        }

        private void cmdClosepanDonthuoc_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void cmdLuu_XemDonthuoc_Click(object sender, EventArgs e)
        {
            if (grdDSDonthuoc.Row < 1) return;
            NamDinh_QLBN.Reports.rptSoKet15 rpt = new NamDinh_QLBN.Reports.rptSoKet15();
            DataDynamics.ActiveReports.DataSources.SqlDBDataSource _ds = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            _ds.ConnectionString = GlobalModuls.Global.glbConnectionString;
            _ds.SQL = "set dateformat mdy  SELECT a.*,HoTen,year(getdate()) - b.namsinh as tuoi,"
                     + " GT= case when b.gioitinh = 0 then N'Giới tinh: Nữ' else N'Giới tinh: Nam' end ,N'- Địa chỉ: '+ bc.DiaChi as DiaChi,"
                     + " N'- Số giường: '+ d1.TenGiuong + N'     Buồng: '+ d.Tenbuong + N'     Khoa: '+ N'" + GlobalModuls.Global.glbTenKhoaPhong + "' AS So,N'- Chẩn đoán: '+ bc.ChanDoan_KhoaDT AS ChanDoan"
                     + " ,d2.TenBS AS TenTK,N'ĐƠN VỊ: ' + N'" + GlobalModuls.Global.glbTenKhoaPhong.ToUpper() + "' as TenKhoa,N'Từ ngày '+ Convert(char(10),TuNgay,103) +N' đến ngày '+ Convert(char(10),DenNgay,103) as ThoiGian,N'Ngày '+ ltrim(str(day(a.NgaySoKet))) + N' tháng ' + ltrim(str(month(a.NgaySoKet))) +N' năm '+ ltrim(str(year(a.NgaySoKet))) as NgaySK"
                     +" FROM ((((tblSOKET15NGAY a "
                     +" INNER JOIN BENHNHAN_CHITIET bc ON a.MaVaoVien = bc.MaVaoVien)"
                     +" INNER JOIN BENHNHAN b ON b.MaBenhNhan = bc.MaBenhNhan)"
                     +" INNER JOIN DMBUONGBENH d ON d.MaKhoa = '"+ GlobalModuls.Global.glbMaKhoaPhong +"' AND d.ID_Buong = bc.Buong)"
                     + " LEFT JOIN DMGIUONGBENH d1 ON d1.MaKhoa = '" + GlobalModuls.Global.glbMaKhoaPhong + "' AND d1.ID_Buong = d.ID_buong AND d1.ID_Giuong = bc.Giuong)"
                     + " LEFT JOIN DMBACSY d2 ON d2.MaKhoa = '" + GlobalModuls.Global.glbMaKhoaPhong + "' AND d2.MaChucVu = '3'  where a.MaVaoVien = '" + _MaVaoVien + "' and a.MaKhoa = '" + GlobalModuls.Global.glbMaKhoaPhong + "' and LanSoket = '" + grdDSDonthuoc.GetDataDisplay(grdDSDonthuoc.Row, "LanSoKet") + "'";
            rpt.DataSource = _ds;
            rpt.Show();
        }
    }
}