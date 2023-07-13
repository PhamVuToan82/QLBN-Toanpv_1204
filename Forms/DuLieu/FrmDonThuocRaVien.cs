using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NamDinh_QLBN.Forms.DuLieu
{
    public partial class FrmDonThuocRaVien : Form
    {
        Boolean booThemdon = false;// Đánh dấu tình trạng thêm, sửa đơn
        Boolean  booSuadon = false;
        string Madonthuoc_Sua; // Mã đơn thuóc cần sửa thông tin
        string MaVaoVien = "";
        public FrmDonThuocRaVien( string MaVV)
        {
            InitializeComponent();
            MaVaoVien = MaVV;
        }

        private void FrmDonThuocRaVien_Load(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            SQLCmd.CommandText = String.Format("Select MaBS,TenBS from DMBacsy where  Khongsudung = 0 and MaKhoa = '" + GlobalModuls.Global.glbMaKhoaPhong + "'");
            dr = SQLCmd.ExecuteReader();
            cmbBacSi.Tag = "0";
            cmbBacSi.ClearItems();
            while (dr.Read())
            {
                cmbBacSi.AddItem(string.Format("{0};{1}", dr["MaBS"], dr["TenBS"]));
            }
            dr.Close();
            if (cmbBacSi.ListCount > 0) cmbBacSi.SelectedIndex = 0;
            cmbBacSi.Tag = "1";
            LoadDSDonThuoc();
            LoadSoTay();
            
        }
        public void LoadSoTay()
        {
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            SQLCmd.CommandText = String.Format("Select ID_SoTayDonThuoc,MatBenh from tblSoTayDonThuoc where MaKhoa = '"+ GlobalModuls.Global.glbMaKhoaPhong +"'");
            dr = SQLCmd.ExecuteReader();
            cmbMatBenh.Tag = "0";
            cmbMatBenh.ClearItems();
            while (dr.Read())
            {
                cmbMatBenh.AddItem(string.Format("{0};{1}", dr["ID_SoTayDonThuoc"], dr["MatBenh"]));
            }
            dr.Close();
            //if (cmbMatBenh.ListCount > 0) cmbMatBenh.SelectedIndex = 0;
            cmbMatBenh.Tag = "1";
        }
        private void Lock_Ctr_Kedon(bool DK)
        {
            cmdThemdon.Enabled = !DK;
            cmdSuadon.Enabled = !DK;
            cmdXoadon.Enabled = !DK;
            cmdLuu_XemDonthuoc.Enabled = !DK;
            cmdClosepanDonthuoc.Enabled = !DK;
            grdDSDonthuoc.Enabled = !DK;
            txtNgayChiDinh.Enabled = DK;
            txtLoidan.Enabled = DK;
            cmdLuuDonthuoc.Enabled = DK;
            cmdKhongLuuDonthuoc.Enabled = DK;
            cmbBacSi.Enabled = DK;
            cmdThem_Thuoc.Enabled = DK;
            //cmbMatBenh.Enabled = DK;
            chkSoTay.Enabled = DK;
            grdSoanDonthuoc.AllowEditing = DK;
        }

        private void cmdClosepanDonthuoc_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void cmdThemdon_Click(object sender, EventArgs e)
        {
            Lock_Ctr_Kedon(true);
            booThemdon = true;
            grdSoanDonthuoc.Rows.Count = 1;
            Madonthuoc_Sua = "";
            txtNgayChiDinh.Value = GlobalModuls.Global.GetNgayLV();
            txtLoidan.Text = "";
            txtThuoc.Focus();
        }
        
        private void cmdSuadon_Click(object sender, EventArgs e)
        {
            if (grdDSDonthuoc.Row <1)
            {
                MessageBox.Show("Chưa chọn đơn thuốc để sửa!!", "Thông báo");
                return;
                
            }
            else
            {
                Madonthuoc_Sua = grdDSDonthuoc.GetDataDisplay(grdDSDonthuoc.Row,1);
            }
            Lock_Ctr_Kedon(true);
            booSuadon = true;
        }
        public void LoadDSDonThuoc()
        {
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            SQLCmd.CommandText = String.Format("Select MaDT,Bacsy, ThoiGian,MaVaoVien,LoiDan,TenBS from tblDonThuocRV a inner join DMBACSY b on a.Bacsy = b.MaBs where MaVaoVien = '"+ MaVaoVien +"' and b.MaKhoa = '"+ GlobalModuls.Global.glbMaKhoaPhong +"'");
            dr = SQLCmd.ExecuteReader();
            grdDSDonthuoc.Tag = "0";
            grdDSDonthuoc.Rows.Count = 1;
            grdDSDonthuoc.ClipSeparators = "|;";
            while (dr.Read())
            {
                grdDSDonthuoc.AddItem(string.Format("{0}|{1}|{2}|{3}|{4}|{5}", grdDSDonthuoc.Rows.Count,
                    dr["MaDT"],
                    dr["BacSy"],
                    dr["TenBs"],
                    dr["ThoiGian"],
                    dr["LoiDan"]));
            }
            grdDSDonthuoc.Tag = "1";
            dr.Close();
            if (grdDSDonthuoc.Row > 0)
            {
                //grdDSDonthuoc.Row = 1;
                grdDSDonthuoc_Click(null, null);
            }
        }
        public void LoadDonThuocCT(string MaDon)
        {
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            SQLCmd.CommandText = String.Format("Select MaThuoc,TenThuoc,TenGoc,DVT,HamLuong,SoLuong,CachDung from tblDonThuocRV_ChiTiet where MaDon = '"+ MaDon +"'");
            dr = SQLCmd.ExecuteReader();
            grdSoanDonthuoc.Rows.Count = 1;
            grdSoanDonthuoc.ClipSeparators = "|;";
            while(dr.Read())
            {
                grdSoanDonthuoc.AddItem(string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}", grdSoanDonthuoc.Rows.Count, dr["MaThuoc"], dr["TenThuoc"], dr["TenGoc"], dr["HamLuong"], dr["DVT"], dr["SoLuong"], dr["CachDung"]));
            }
            dr.Close();
            
        }

        private void txtThuoc_TextChanged(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            try
            {
                if (txtThuoc.Text.Trim() == "") grdDMThuoc.Visible = false;
                string SQL = "Select b.ThuocID, b.Tenthuoc, b.Tengoc, '' as Hamluong, isnull(b.DonViTinh,'') as DonViTinh, "
                            + " 1 as Soluong, isnull(b.Xuatxu,'') as Noisanxuat from    "
                            + " NAMDINH_DUOC.dbo.DanhmucThuoc b  "
                            + " WHERE   b.Tenthuoc like N'"+ txtThuoc.Text +"%'  "
                            + " order by  Tenthuoc";
                SQLCmd.CommandText = SQL;
                dr = SQLCmd.ExecuteReader();
                if (!dr.HasRows)
                {
                    grdDMThuoc.Visible = false;
                    dr.Close();
                    return;
                }
                grdDMThuoc.Visible = true;
                grdDMThuoc.Rows.Count = 1;
                grdDMThuoc.Redraw = false;
                grdDMThuoc.Cols.Count = 6;
                grdDMThuoc.Rows.Fixed = 1;
                grdDMThuoc.ClipSeparators = "|;";
                grdDMThuoc[0, 0] = "Mã thuốc";
                grdDMThuoc[0, 1] = "Tên thuốc";
                grdDMThuoc[0, 2] = "Tên gốc";
                grdDMThuoc[0, 3] = "Hàm lượng";
                grdDMThuoc[0, 4] = "Nơi sản xuất";
                grdDMThuoc[0, 5] = "ĐVT";
                grdDMThuoc.Cols[0].Visible = false;
                while (dr.Read())
                {
                    grdDMThuoc.AddItem(string.Format("{0}|{1}|{2}|{3}|{4}|{5}",
                    dr["ThuocID"],
                    dr["TenThuoc"],
                    dr["TenGoc"],
                    dr["HamLuong"],
                    dr["NoiSanXuat"],
                    dr["DonViTinh"]));
                }
                grdDMThuoc.Redraw = true;
                grdDMThuoc.AutoSizeCols();
                grdDMThuoc.ExtendLastCol = true;
                //grdDMThuoc.Focus();
                dr.Close();
                SQLCmd.Dispose();
            }
            catch(Exception ex)
            {
                //dr.Close();
            }
        }

        private void grdDMThuoc_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtThuoc.Tag = grdDMThuoc.GetDataDisplay(grdDMThuoc.Row, 0);
                txtThuoc.Text = grdDMThuoc.GetDataDisplay(grdDMThuoc.Row, 1);
                txtTengoc.Text = grdDMThuoc.GetDataDisplay(grdDMThuoc.Row, 2);
                txtHamluong.Text = grdDMThuoc.GetDataDisplay(grdDMThuoc.Row, 3);
                txtDVT_Thuoc.Text = grdDMThuoc.GetDataDisplay(grdDMThuoc.Row, 5);
                grdDMThuoc.Visible =false;
                txtSoluong_Thuoc.Focus();
            }
        }

        private void grdDMThuoc_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                txtThuoc.Tag = grdDMThuoc.GetDataDisplay(grdDMThuoc.Row, 0);
                txtThuoc.Text = grdDMThuoc.GetDataDisplay(grdDMThuoc.Row, 1);
                txtTengoc.Text = grdDMThuoc.GetDataDisplay(grdDMThuoc.Row, 2);
                txtHamluong.Text = grdDMThuoc.GetDataDisplay(grdDMThuoc.Row, 3);
                txtDVT_Thuoc.Text = grdDMThuoc.GetDataDisplay(grdDMThuoc.Row, 5);
                grdDMThuoc.Visible = false;
                txtSoluong_Thuoc.Focus();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtThuoc_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down && grdSoanDonthuoc.Visible)
            {
                grdDMThuoc.Focus();
            }
        }
        private void txtThuoc_LostFocus(object sender, KeyEventArgs e)
        {
            
        }

        private void txtThuoc_Validated(object sender, EventArgs e)
        {
       
        }

        private void grdDMThuoc_Validated(object sender, EventArgs e)
        {
           
        }

        private void grdDMThuoc_Leave(object sender, EventArgs e)
        {
            try
            {
                if (grdDMThuoc.Row > 0)
                {
                    txtThuoc.Tag = grdDMThuoc.GetDataDisplay(grdDMThuoc.Row, 0);
                    txtThuoc.Text = grdDMThuoc.GetDataDisplay(grdDMThuoc.Row, 1);
                    txtTengoc.Text = grdDMThuoc.GetDataDisplay(grdDMThuoc.Row, 2);
                    txtHamluong.Text = grdDMThuoc.GetDataDisplay(grdDMThuoc.Row, 3);
                    txtDVT_Thuoc.Text = grdDMThuoc.GetDataDisplay(grdDMThuoc.Row, 5);
                }
            }
            catch
            {

            }
            txtSoluong_Thuoc.Focus();
            grdDMThuoc.Visible = false;
        }

        private void txtThuoc_Leave(object sender, EventArgs e)
        {
            if (grdDMThuoc.Visible == false)
            {
                txtThuoc.Tag = "";
                txtTengoc.Focus();

            }
            else
            {
                if (!grdDMThuoc.Focus())
                {
                    grdDMThuoc.Visible = false;
                }
            }
        }

        private void cmdThem_Thuoc_Click(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            if (txtThuoc.Text.Trim() == "") return;
            for(int i=1;i<grdSoanDonthuoc.Rows.Count;i++)
            {
                if (txtThuoc.Text.Trim() ==grdSoanDonthuoc.GetDataDisplay(i,2).Trim())
                {
                    MessageBox.Show("Thuốc đã có trong đơn!!", "Thông báo");
                    txtThuoc.Text = "";
                    txtThuoc.Tag = "";
                    txtDVT_Thuoc.Text = "";
                    txtSoluong_Thuoc.ValueIsDbNull = true;
                    txtCachdung_Thuoc.Text = "";
                    txtThuoc.Focus();
                    grdDMThuoc.Visible = false;
                    return;
                }
            }
            if (txtSoluong_Thuoc.Text =="")
            {
                MessageBox.Show("Số lượng chưa đúng!!", "Thông báo");
                return;
            }
            if (int.Parse(txtSoluong_Thuoc.Value.ToString()) <=0)
            {
                MessageBox.Show("Số lượng chưa đúng!!", "Thông báo");
                return;
            }
            if (txtThuoc.Tag.ToString()=="")
            {
                if(MessageBox.Show("Thuốc chưa có trong danh mục của bệnh viện. Bạn có thêm mới không?","Thông báo",MessageBoxButtons.YesNo)== DialogResult.Yes)
                {
                    SQLCmd.CommandText = string.Format("Execute spd_SaveThuocngoai '{0}','{1}','{2}'", txtThuoc.Text, txtTengoc.Text, txtDVT_Thuoc.Text);
                    txtThuoc.Tag = SQLCmd.ExecuteScalar();
                }
            }
            if (txtThuoc.Tag.ToString() == "") return;
            grdSoanDonthuoc.ClipSeparators = "|;";
            grdSoanDonthuoc.AddItem(grdSoanDonthuoc.Rows.Count + "|" + txtThuoc.Tag.ToString() + "|" + txtThuoc.Text + "|" + txtTengoc.Text + "|" + txtHamluong.Text + "|" + txtDVT_Thuoc.Text + "|" + txtSoluong_Thuoc.Text + "|" + txtCachdung_Thuoc.Text);
            grdSoanDonthuoc.AutoSizeCols();
            txtThuoc.Text = "";
            txtThuoc.Tag = "";
            txtDVT_Thuoc.Text = "";
            txtSoluong_Thuoc.ValueIsDbNull = true;
            txtCachdung_Thuoc.Text = "";
            txtThuoc.Focus();
            grdDMThuoc.Visible = false;
        }

        private void cmdKhongLuuDonthuoc_Click(object sender, EventArgs e)
        {
            Lock_Ctr_Kedon(false);
            if(booThemdon)grdSoanDonthuoc.Rows.Count = 1;
            if (booSuadon)LoadDonThuocCT(grdDSDonthuoc.GetDataDisplay(grdDSDonthuoc.Row, 1));
            booThemdon = false;
            booSuadon = false;
            cmbMatBenh.Enabled = false;
        }

        private void cmdLuuDonthuoc_Click(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", GlobalModuls.Global.ConnectSQL);
            System.Data.SqlClient.SqlTransaction trn = GlobalModuls.Global.ConnectSQL.BeginTransaction();
            SQLCmd.Transaction = trn;
            try
            {
                if (booThemdon == true)
                {
                    SQLCmd.CommandText = string.Format("set dateformat mdy Insert into tblDonThuocRV(Bacsy,ThoiGian,MaVaoVien,LoiDan) values('{0}','{1:MM/dd/yyyy HH:mm}','{2}',N'{3}') Select @@IDENTITY", GlobalModuls.Global.GetCode(cmbBacSi), txtNgayChiDinh.Value, MaVaoVien, txtLoidan.Text.Trim());
                    int MaDonMoi = int.Parse(SQLCmd.ExecuteScalar().ToString());
                    for (int i = 1;i<grdSoanDonthuoc.Rows.Count;i++)
                    {
                        SQLCmd.CommandText =string.Format("Insert into tblDonThuocRV_ChiTiet(MaDon,MaThuoc,TenThuoc,TenGoc,DVT,HamLuong,SoLuong,CachDung) Values('{0}','{1}',N'{2}',N'{3}',N'{4}',N'{5}',{6},N'{7}')"
                                                         , MaDonMoi, grdSoanDonthuoc.GetDataDisplay(i, 1), grdSoanDonthuoc.GetDataDisplay(i, 2), grdSoanDonthuoc.GetDataDisplay(i, 3), grdSoanDonthuoc.GetDataDisplay(i, 5)
                                                         , grdSoanDonthuoc.GetDataDisplay(i, 4), grdSoanDonthuoc.GetDataDisplay(i, 6), grdSoanDonthuoc.GetDataDisplay(i, 7));
                        SQLCmd.ExecuteNonQuery();
                            
                    }
                    
                }
                else
                {
                    if (booSuadon == true)
                    {
                        SQLCmd.CommandText = string.Format("set dateformat mdy Update tblDonThuocRV set Bacsy ='{0}' ,ThoiGian ='{1:MM/dd/yyyy HH:mm}' ,LoiDan =N'{2}' where MaDT ='{3}' ", GlobalModuls.Global.GetCode(cmbBacSi), txtNgayChiDinh.Value, txtLoidan.Text.Trim(),grdDSDonthuoc.GetDataDisplay(grdDSDonthuoc.Row,1));
                        SQLCmd.ExecuteNonQuery();
                        SQLCmd.CommandText = "Delete from tblDonThuocRV_ChiTiet where MaDon = '"+ grdDSDonthuoc.GetDataDisplay(grdDSDonthuoc.Row,1) +"'";
                        SQLCmd.ExecuteNonQuery();
                        for (int i = 1; i < grdSoanDonthuoc.Rows.Count; i++)
                        {
                            SQLCmd.CommandText = string.Format("Insert into tblDonThuocRV_ChiTiet(MaDon,MaThuoc,TenThuoc,TenGoc,DVT,HamLuong,SoLuong,CachDung) Values('{0}','{1}',N'{2}',N'{3}',N'{4}',N'{5}',{6},N'{7}')"
                                                             , grdDSDonthuoc.GetDataDisplay(grdDSDonthuoc.Row,1), grdSoanDonthuoc.GetDataDisplay(i, 1), grdSoanDonthuoc.GetDataDisplay(i, 2), grdSoanDonthuoc.GetDataDisplay(i, 3), grdSoanDonthuoc.GetDataDisplay(i, 5)
                                                             , grdSoanDonthuoc.GetDataDisplay(i, 4), grdSoanDonthuoc.GetDataDisplay(i, 6), grdSoanDonthuoc.GetDataDisplay(i, 7));
                            SQLCmd.ExecuteNonQuery();

                        }
                    }
                    
                }
                trn.Commit();
            }
            catch(Exception ex)
            {
                trn.Rollback();
                MessageBox.Show("Có lỗi khi ghi dữ liệu\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SQLCmd.Dispose();
                trn.Dispose();
            }
            booSuadon = false;
            booThemdon = false;
            LoadDSDonThuoc();
            Lock_Ctr_Kedon(false);
            cmbMatBenh.Enabled = false;
        }

        private void grdDSDonthuoc_Click(object sender, EventArgs e)
        {
            if (grdDSDonthuoc.Row > 0)
            {
                LoadDonThuocCT(grdDSDonthuoc.GetDataDisplay(grdDSDonthuoc.Row,1));
                GlobalModuls.Global.SetCmb(cmbBacSi,grdDSDonthuoc.GetDataDisplay(grdDSDonthuoc.Row,2));
                txtNgayChiDinh.Value = grdDSDonthuoc[grdDSDonthuoc.Row, 4];
                txtLoidan.Text = grdDSDonthuoc.GetDataDisplay(grdDSDonthuoc.Row, 5);
            }
        }

        private void grdSoanDonthuoc_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                  if (e.KeyCode == Keys.Delete && booSuadon)	
                  {
                      if (grdSoanDonthuoc.Row > 0 && MessageBox.Show("Bạn có chắc chắn xóa thuốc này không?","Thông báo",MessageBoxButtons.YesNo) == DialogResult.Yes)
                      {
                          grdSoanDonthuoc.RemoveItem(grdSoanDonthuoc.Row);
                      }
                      for (int i= 1;i<grdSoanDonthuoc.Rows.Count;i++)
                      {
                          grdSoanDonthuoc[i,0]=i;
                      }
                  }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void cmdXoadon_Click(object sender, EventArgs e)
        {

            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", GlobalModuls.Global.ConnectSQL);
            if (grdDSDonthuoc.Row <1)
            {
                MessageBox.Show("Chưa chọn đơn thuốc để xóa", "Thông báo",MessageBoxButtons.OK);
                return;
            }
            if (MessageBox.Show("Bạn có chắc chắn xóa đơn thuốc này không?" ,"Thông báo",MessageBoxButtons.YesNo)== DialogResult.Yes)
            {
                SQLCmd.CommandText = "Delete from tblDonThuocRV where MaDT = '" + grdDSDonthuoc.GetDataDisplay(grdDSDonthuoc.Row, 1) + "'";
                SQLCmd.CommandText += "  Delete from tblDonThuocRV_ChiTiet where MaDon = '" + grdDSDonthuoc.GetDataDisplay(grdDSDonthuoc.Row, 1) + "'";
                SQLCmd.ExecuteNonQuery();
            }
            LoadDSDonThuoc();
        }

        private void cmdLuu_XemDonthuoc_Click(object sender, EventArgs e)
        {
            if (grdDSDonthuoc.Row < 1) return;
            NamDinh_QLBN.Reports.rptDonThuocRV rpt = new NamDinh_QLBN.Reports.rptDonThuocRV(grdDSDonthuoc[grdDSDonthuoc.Row, 4], cmbBacSi.Text, grdDSDonthuoc[grdDSDonthuoc.Row, 5].ToString());
            DataDynamics.ActiveReports.DataSources.SqlDBDataSource _ds = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            _ds.ConnectionString = GlobalModuls.Global.glbConnectionString;
            _ds.SQL = " Select benhnhan.hoten,year(getdate()) - benhnhan.namsinh as tuoi,"
                     +" case when benhnhan.gioitinh = 0 then N'Giới tinh: Nữ' else N'Giới tinh: Nam' end as GioiTinh,"
                     +" N'Đối tượng: ' + dmdoituongbn.tendt + N'. Số thẻ: ' + viewdoituonghientai.SoThe as DoiTuong1,benhnhan_chitiet.diachi,viewdoituonghientai.GtriTu,viewdoituonghientai.GtriDen,"
                     + " viewdoituonghientai.SoThe,RV_CT.MaThuoc,RV_CT.TenThuoc,RV_CT.soluong,RV_CT.dvt,RV_CT.CachDung,RV.LoiDan,RV.BacSy,CASE isnull(benhnhan_chitiet.ChanDoanRaVien,'') when '' then benhnhan_chitiet.ChanDoan_KhoaDT else benhnhan_chitiet.ChanDoanRaVien end as ChanDoan"
                     +" FROM ((((tblDonThuocRV RV INNER JOIN tblDonThuocRV_ChiTiet RV_CT ON RV.MaDT = RV_CT.MaDon)"
                     +" inner join benhnhan_chitiet on benhnhan_chitiet.mavaovien =  RV.mavaovien)"
                     +" inner join benhnhan on benhnhan.mabenhnhan = benhnhan_chitiet.mabenhnhan)"
                     +" left join viewdoituonghientai on viewdoituonghientai.mavaovien = RV.mavaovien)"
                     +" left join dmdoituongbn on dmdoituongbn.madt = viewdoituonghientai.doituong"
                     +" WHERE RV.MaDT = '"+ grdDSDonthuoc.GetDataDisplay(grdDSDonthuoc.Row,1) +"' ";
            rpt.DataSource = _ds;
            rpt.Show();
        }

        private void chkSoTay_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSoTay.Checked==true)
            {
                cmbMatBenh.Enabled = true;
            }
            else
            {
                cmbMatBenh.Enabled = false;
            }
        }

        private void cmbMatBenh_TextChanged(object sender, EventArgs e)
        {
            if (cmbMatBenh.Tag.ToString() == "0" || (booSuadon == false && booThemdon == false)) return;
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            if (grdSoanDonthuoc.Rows.Count>1)
            {
                if (MessageBox.Show("Thuốc cũ trong danh sách sẽ bị xóa, Bạn có muốn tiếp tục không? ","Thông báo",MessageBoxButtons.YesNo)==DialogResult.Yes)
                {
                    SQLCmd.CommandText = String.Format("Select MaThuoc,TenThuoc,TenGoc,DonViTinh AS DVT,'' AS HamLuong,SoLuong,'' AS CachDung from tblSoTayDonThuoc_CT a inner join NamDinh_Duoc.dbo.DanhMucThuoc b ON a.MaThuoc = b.ThuocID where id_SoTayDonThuoc = '"+ GlobalModuls.Global.GetCode(cmbMatBenh) +"'");
                    dr = SQLCmd.ExecuteReader();
                    grdSoanDonthuoc.Rows.Count = 1;
                    grdSoanDonthuoc.ClipSeparators = "|;";
                    while (dr.Read())
                    {
                        grdSoanDonthuoc.AddItem(string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}", grdSoanDonthuoc.Rows.Count, dr["MaThuoc"], dr["TenThuoc"], dr["TenGoc"], dr["HamLuong"], dr["DVT"], dr["SoLuong"], dr["CachDung"]));
                    }
                    dr.Close();
                }
            }
            else
            {
                SQLCmd.CommandText = String.Format("Select MaThuoc,TenThuoc,TenGoc,DonViTinh AS DVT,'' AS HamLuong,SoLuong,'' AS CachDung from tblSoTayDonThuoc_CT a inner join NamDinh_Duoc.dbo.DanhMucThuoc b ON a.MaThuoc = b.ThuocID where id_SoTayDonThuoc = '" + GlobalModuls.Global.GetCode(cmbMatBenh) + "'");
                dr = SQLCmd.ExecuteReader();
                grdSoanDonthuoc.Rows.Count = 1;
                grdSoanDonthuoc.ClipSeparators = "|;";
                while (dr.Read())
                {
                    grdSoanDonthuoc.AddItem(string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}", grdSoanDonthuoc.Rows.Count, dr["MaThuoc"], dr["TenThuoc"], dr["TenGoc"], dr["HamLuong"], dr["DVT"], dr["SoLuong"], dr["CachDung"]));
                }
                dr.Close();
            }

        }
    }
}