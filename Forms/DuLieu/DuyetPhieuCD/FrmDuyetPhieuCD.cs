using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NamDinh_QLBN.Forms.DuLieu.DuyetPhieuCD
{
    public partial class FrmDuyetPhieuCD : Form
    {
        public FrmDuyetPhieuCD()
        {
            InitializeComponent();
        }

        private void FrmDuyetPhieuCD_Load(object sender, EventArgs e)
        {
            txtThoigianChidinh.Value = GlobalModuls.Global.GetNgayLV();
            txtNgayDuyet.Value = GlobalModuls.Global.GetNgayLV();
            txtSoPhieuCD.Focus();
            fg.ClipSeparators = "|;";
            fg.Tree.Column = 5;
            fg.Rows.Count = 1;
            fg.Cols["MaKhoa"].Visible = false;
            fg.Cols["TenKhoa"].Visible = false;
            fg.Cols["LoaiDichVu"].Visible = false;
            fg.Cols["MaDichVu"].Visible = false;
            fgPhieuCD.Tag = "0";
            fgPhieuCD.Rows.Count = 1;
            fgPhieuCD.Tag = "1";
            LoadPhanCD();
            LoadDSPhieuCD(DateTime.Parse(txtThoigianChidinh.Value.ToString()),txtCoDinh.Text + txtSoPhieuCD.Text);
            
        }
        public void LoadPhanCD()
        {
            txtCoDinh.Text = "NT" + string.Format("{0:yyMMdd}", txtThoigianChidinh.Value);
        }
        public void LoadDSPhieuCD(DateTime ThoiGianCD,string SoPhieu)
        {
            if (txtSoPhieuCD.Text.Trim() == "") return;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", GlobalModuls.Global.ConnectSQL);
            SQLCmd.CommandText = " SELECT a.MaKhoa,b.TenKhoa,a.MaVaoVien,b2.HoTen AS TenBenhNhan,a.SoPhieu,a.NgayChiDinh,dmbacsy.tenbs AS BacSiCD,b2.NamSinh "
                                +" ,CASE GioiTInh WHEN 1 THEN N'Nữ' ELSE 'Nam' END AS GioiTinh,bc.DiaChi,"
                                +" d3.TenDT,(vd.maDoiTuongBHXH + '-' + vd.Sothe + '-' + vd.MaNoiCap)AS SoTheBHYT,"
                                + " case when a.chandoan <> '' then a.chandoan else  viewkhoahientai.ChanDoan end ChanDoan,SoHSBA"
                                +" FROM BENHNHAN_PHIEUDIEUTRI a INNER JOIN DMKHOAPHONG b ON a.MaKhoa=b.MaKhoa  "
                                +" inner join viewkhoahientai on viewkhoahientai.mavaovien = a.mavaovien  "
                                + " inner JOIN ViewDOITUONGHIENTAI vd on vd.mavaovien = a.mavaovien  And a.SoPhieu = '" + SoPhieu + "'" 
                                +" INNER JOIN DMDOITUONGBN d3 ON vd.DoiTuong = d3.MaDT"
                                +" INNER JOIN BENHNHAN_CHITIET bc ON a.MaVaoVien = bc.MaVaoVien"
                                +" INNER JOIN BENHNHAN b2 ON b2.MaBenhNhan = bc.MaBenhNhan"
                               // + " INNER JOIN (select Distinct(SoPhieu) from PHIEUDIEUTRI_CHITIET pk where LoaiDichVu like 'C5%'And SoPhieu like '%" + SoPhieu + "%' )B1 on B1.SoPhieu = a.SoPhieu "
                                +" left join dmbacsy on dmbacsy.makhoa = a.makhoa and dmbacsy.mabs = a.mabs "
                                + " WHERE datediff(DAY ,NgayChiDinh,'" + String.Format("{0:MM/dd/yyyy}", ThoiGianCD) + "')=0 AND a.SoPhieu ='" + SoPhieu + "' ";
            //if (SoPhieu != "")
            //{
            //    SQLCmd.CommandText += " And a.SoPhieu like '%" + SoPhieu + "%'";	
            //}
            SQLCmd.CommandText += " ORDER BY a.MaKhoa,a.MaVaoVien,HoTen,a.SoPhieu";
            System.Data.SqlClient.SqlDataReader dr = SQLCmd.ExecuteReader();
            fgPhieuCD.Tag = "0";
            fgPhieuCD.Redraw = false;
            fgPhieuCD.Rows.Count = 1;
            int row = 1;
            while (dr.Read())
            {
                fgPhieuCD.Rows.Add();
                int i = 0;
                for (i = 0; i <= dr.FieldCount - 1; i++)
                {
                    fgPhieuCD[row, i + 1] = dr.GetValue(i);
                }
                row = row + 1;
            }
            dr.Close();
            SQLCmd.Dispose();
            fgPhieuCD.Styles.Normal.Font = new Font("Tahoma", 8, FontStyle.Regular);
            fgPhieuCD.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.None, 0, 2, 2, -1, "{0}");
            fgPhieuCD.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.None, 1, 4, 4, -1, "{0}");
            fgPhieuCD.AutoSizeCols(0, fgPhieuCD.Cols.Count - 1, 1);
            fgPhieuCD.Redraw = true;
            int j = 0;
            int STT = 0;
            for (j = 1; j <= fgPhieuCD.Rows.Count - 1; j++)
            {
                if (fgPhieuCD.Rows[j].IsNode)
                {
                    STT = 0;
                    fgPhieuCD[j, "STT"] = "";
                }
                else
                {
                    STT = STT + 1;
                    fgPhieuCD[j, "STT"] = STT.ToString();
                }
            }
            if (fgPhieuCD.Rows.Count > 3)
            {

                fgPhieuCD.Row = 3;
            }
            fgPhieuCD.Tag = "1";
            LoadPhieuCD_CT();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //LoadDSPhieuCD(DateTime.Parse(txtThoigianChidinh.Value.ToString()), "");
        }

        private void cmdThoat_Tab1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void cmdTimkiem_Click(object sender, EventArgs e)
        {
            LoadDSPhieuCD(DateTime.Parse(txtThoigianChidinh.Value.ToString()),txtCoDinh.Text + txtSoPhieuCD.Text);
        }

        private void txtSoPhieuCD_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtSoPhieuCD.Text.Trim() == "") return;
            if (e.KeyCode == Keys.Enter)
            {
                LoadDSPhieuCD(DateTime.Parse(txtThoigianChidinh.Value.ToString()), txtCoDinh.Text + txtSoPhieuCD.Text);
                txtSoHSBA.Focus();
            }
        }

        private void fgPhieuCD_AfterSelChange(object sender, C1.Win.C1FlexGrid.RangeEventArgs e)
        {
            LoadPhieuCD_CT();
        }
        public void LoadPhieuCD_CT()
        {
            if (fgPhieuCD.Tag.ToString() == "0" || fgPhieuCD.Rows.Count < 2 || fgPhieuCD.GetDataDisplay(fgPhieuCD.Row,"SoPhieu")=="") return;
            txtTenbenhnhan.Text = fgPhieuCD.GetDataDisplay(fgPhieuCD.Row, "TenBenhNhan");
            txtTuoi.Value = fgPhieuCD[fgPhieuCD.Row, "NamSinh"];
            cmbGioitinh.Text = fgPhieuCD.GetDataDisplay(fgPhieuCD.Row, "GioiTinh");
            txtDiachi.Text = fgPhieuCD.GetDataDisplay(fgPhieuCD.Row, "DiaChi");
            cmbDoituong.Text = fgPhieuCD.GetDataDisplay(fgPhieuCD.Row, "DoiTuong");
            lblSotheBHYT.Text = fgPhieuCD.GetDataDisplay(fgPhieuCD.Row, "SoTheBHYT");
            txtChandoanNGT.Text = fgPhieuCD.GetDataDisplay(fgPhieuCD.Row, "ChanDoan");
            txtSoHSBA.Text = fgPhieuCD.GetDataDisplay(fgPhieuCD.Row, "SoHSBA");
            lblSoPhieuCD.Text = "SỐ PHIẾU CĐ: " + fgPhieuCD.GetDataDisplay(fgPhieuCD.Row, "SoPhieu");
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", GlobalModuls.Global.ConnectSQL);
            SQLCmd.CommandText = " SELECT dk.MaKhoa,TenKhoa,a.LoaiDichVu,a.MaDichVu"
                                +" ,TenDichVu,DVT,SoLuong,a.DonGia,SoLuong*a.DonGia as ThanhTien,"
                                +" a.DuyetBHYT, a.UseDuyetBHYT"
                                +" FROM  (((PHIEUDIEUTRI_CHITIET a INNER JOIN DMLOAIDICHVU b ON a.LoaiDichVu=b.MaLoaiDichVu)  "
                                +" INNER JOIN DMDICHVU c ON a.LoaiDichVu=c.LoaiDichVu AND a.MaDichVu=c.MaDichVu )"
                                +" INNER JOIN NAMDINH_SYSDB.dbo.DMDICHVU_KHOA dk ON dk.MaDichvu = a.MaDichVu)"
                                +" INNER JOIN DMKHOAPHONG d ON d.MaKhoa = dk.MaKhoa"
                                +" WHERE SoPhieu='" + fgPhieuCD.GetDataDisplay(fgPhieuCD.Row, "SoPhieu") + "' Order By dk.MaKhoa,a.LoaiDichVu";
            
            System.Data.SqlClient.SqlDataReader dr = SQLCmd.ExecuteReader();
            fg.Tag = "0";
            fg.Redraw = false;
            fg.Rows.Count = 1;
            int row = 1;
            while (dr.Read())
            {
                fg.Rows.Add();
                int i = 0;
                for (i = 0; i <= dr.FieldCount - 1; i++)
                {
                    fg[row, i + 1] = dr.GetValue(i);
                }
                row = row + 1;
            }
            dr.Close();
            SQLCmd.Dispose();
            fg.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.Clear, 0, 2, 0, "{0}");
            fg.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.Sum, 0, 2, fg.Cols["ThanhTien"].Index, "{0}");
            //fg.AutoSizeCols(0, fg.Cols.Count - 1, 1);
            fg.Redraw = true;
            int j = 0;
            int STT = 0;
            for (j = 1; j <= fg.Rows.Count - 1; j++)
            {
                if (fg.Rows[j].IsNode)
                {
                    STT = 0;
                    fg[j, "STT"] = "";
                }
                else
                {
                    STT = STT + 1;
                    fg[j, "STT"] = STT.ToString();
                }
            }
           
            fg.Tag = "1";
        }

        private void FrmDuyetPhieuCD_KeyUp(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.F5)
            {
                for (int i = 1; i < fg.Rows.Count; i++)
                {
                    if (fg.GetDataDisplay(i, "UseDuyetBHYT").ToLower() != GlobalModuls.Global.glbUName.ToLower() && fg.GetDataDisplay(i, "UseDuyetBHYT").Trim() != "")
                    {
                        MessageBox.Show("Phiếu chỉ định này đã được duyệt bởi người khác. Bạn không được duyệt lại!!", "Thông báo", MessageBoxButtons.OK);
                        txtNgayDuyet.Focus();
                        return;
                    }
                }
                for (int i=1;i<fg.Rows.Count;i++)
                {
                    if (fg.GetDataDisplay(i,"MaDichVu") !="")
                    {
                        fg.SetCellCheck(i, fg.Cols["DuyetBHYT"].Index, C1.Win.C1FlexGrid.CheckEnum.Checked);
                    }
                }
            }
            if (e.KeyCode == Keys.F6)
            {
                for (int i = 1; i < fg.Rows.Count; i++)
                {
                    if (fg.GetDataDisplay(i, "UseDuyetBHYT").ToLower() != GlobalModuls.Global.glbUName.ToLower() && fg.GetDataDisplay(i, "UseDuyetBHYT").Trim() != "")
                    {
                        MessageBox.Show("Phiếu chỉ định này đã được duyệt bởi người khác. Bạn không được duyệt lại!!", "Thông báo", MessageBoxButtons.OK);
                        txtNgayDuyet.Focus();
                        return;
                    }
                }
                for (int i = 1; i < fg.Rows.Count; i++)
                {
                    if (fg.GetDataDisplay(i, "MaDichVu") != "")
                    {
                        fg.SetCellCheck(i, fg.Cols["DuyetBHYT"].Index, C1.Win.C1FlexGrid.CheckEnum.Unchecked);
                    }
                }
            }
            if (e.KeyCode ==Keys.F9)
            {
                cmdGhi_Click(null, null);
                txtSoPhieuCD.Text = "";
                txtSoPhieuCD.Focus();
            }
        }

        private void cmdGhi_Click(object sender, EventArgs e)
        {
            if (txtSoHSBA.Text.Trim() =="")
            {
                MessageBox.Show("Chưa nhập số Hồ sơ bệnh án cho bệnh nhân!!", "Thông báo",MessageBoxButtons.OK);
                txtSoHSBA.Focus();
                return;
            }
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", GlobalModuls.Global.ConnectSQL);
            for (int i = 1; i < fg.Rows.Count; i++)
            {
                if (fg.GetDataDisplay(i, "UseDuyetBHYT").ToLower() != GlobalModuls.Global.glbUName.ToLower() && fg.GetDataDisplay(i, "UseDuyetBHYT").Trim() !="")
                {
                    MessageBox.Show("Phiếu chỉ định này đã được duyệt bởi người khác. Bạn không được duyệt lại!!", "Thông báo",MessageBoxButtons.OK);
                    return;
                }
            }
            //SQLCmd.CommandText = "Update BENHNHAN_CHITIET set SoHSBA = " + txtSoHSBA.Text + " where MaVaoVien = '" + fgPhieuCD.GetDataDisplay(fgPhieuCD.Row,"MaVaoVien") + "' ";
            //SQLCmd.ExecuteNonQuery();
            System.Data.SqlClient.SqlDataReader dr;
            for (int i=1;i<fg.Rows.Count;i++)
            {
                if (fg.GetDataDisplay(i,"MaDichVu") !="")
                {
                    int DaDuyet = 0;
                    if (fg.GetCellCheck(i,fg.Cols["DuyetBHYT"].Index)==C1.Win.C1FlexGrid.CheckEnum.Checked)
                    {
                        DaDuyet = 1;
                    }
                    else
                    {
                        DaDuyet = 0;
                    }
                    string TenDuyetBHYT = "";
                    SQLCmd.CommandText = "Select isnull(TenDu,'') as TenDayDu from SysUser where Uname = '"+ GlobalModuls.Global.glbUName +"'";
                    dr = SQLCmd.ExecuteReader();
                    if (dr.Read())
                    {
                        TenDuyetBHYT = dr["TenDayDu"].ToString();
                    }
                    dr.Close();
                    SQLCmd.CommandText = "Update PhieuDieuTri_ChiTiet set DuyetBHYT = "+ DaDuyet +", UseDuyetBHYT = '"+ GlobalModuls.Global.glbUName +"',NgayDuyetBHYT = '"+ string.Format("{0:MM/dd/yyyy}", txtNgayDuyet.Value) +"'where SoPhieu = '"+fgPhieuCD.GetDataDisplay(fgPhieuCD.Row,"SoPhieu")+"' and MaDichvu = '"+ fg.GetDataDisplay(i,"MaDichVu") +"' ";
                    SQLCmd.ExecuteNonQuery();
                }
            }
            for (int i = 1; i < fgPhieuCD.Rows.Count; i++)
            {
                if (fgPhieuCD.GetDataDisplay(i,"MaVaoVien") ==fgPhieuCD.GetDataDisplay(fgPhieuCD.Row,"MaVaoVien"))
                {
                    fgPhieuCD[i, "SoHSBA"] = txtSoHSBA.Text;
                }
            }
                
            MessageBox.Show("Cập nhật thành công!!", "Thông báo",MessageBoxButtons.OK);
            // Load Tich Ke
            //string XetNghiem = "";
            //string SoTheBHYT = "";
            //decimal TongTien=0;
            //SQLCmd = new System.Data.SqlClient.SqlCommand();
            //SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            //SQLCmd.CommandText = "SELECT TenDichVu,isnull(pc.SoLuong,0)* isnull(pc.DonGia,0) as ThanhTien FROM "
            //                    + " ((((PHIEUDIEUTRI_CHITIET pc INNER JOIN DMDICHVU d ON d.MaDichVu = pc.MaDichVu )"
            //                    + " INNER JOIN NAMDINH_CLS.dbo.DMDICHVU_CHISO dc ON dc.MaDichVu = d.MaDichVu)"
            //                    + " INNER JOIN NAMDINH_CLS.dbo.DMCHISO d1 ON d1.MaChiSo=dc.MaChiSo)"
            //                    + " INNER JOIN BENHNHAN_PHIEUDIEUTRI bp ON bp.SoPhieu = pc.SoPhieu)"
            //                    + " WHERE pc.SoPhieu ='" + fgPhieuCD.GetDataDisplay(fgPhieuCD.Row, "SoPhieu") + "' AND (d1.MaMay = 2 OR d1.MaMay = 4) and DaDuyet =1";
            //dr = SQLCmd.ExecuteReader();
            //while (dr.Read())
            //{
            //    XetNghiem += dr["TenDichVu"].ToString() + ", ";
            //    try
            //    {
            //        TongTien += decimal.Parse(dr["ThanhTien"].ToString());
            //    }
            //    catch { }
            //}
            //dr.Close();
            //SoTheBHYT = lblSotheBHYT.Text;
            //if (XetNghiem.Trim() == "")
            //{
            //    MessageBox.Show("Số phiếu này không có dịch vụ phải duyệt!!", "Thông báo", MessageBoxButtons.OK);
            //    txtSoPhieuCD.Focus();
                
            //    return;
            //}
            //XetNghiem = XetNghiem.Substring(0, XetNghiem.Length - 2);
            //NamDinh_QLBN.Reports.rptTichKeXN rpt = new NamDinh_QLBN.Reports.rptTichKeXN();
            //rpt.Barcode1.Text = fgPhieuCD.GetDataDisplay(fgPhieuCD.Row, "SoPhieu");
            //rpt.lblTenBN.Text = txtTenbenhnhan.Text.ToUpper();
            //rpt.lblTenKhoa.Text = GlobalModuls.Global.glbTenKhoaPhong;
            //rpt.lblSoThe.Text = SoTheBHYT;
            //rpt.lblXetNghiem.Text = XetNghiem;
            //rpt.txtTongTien.Value = TongTien;
            //rpt.lblBacSiCD.Text = fgPhieuCD.GetDataDisplay(fgPhieuCD.Row, "BacsiCD");
            //rpt.lblNgayThang.Text = string.Format("{0:HH} giờ {0:mm} - Ngày {0:dd} tháng {0:MM} năm {0:yyyy}", fgPhieuCD[fgPhieuCD.Row, "NgayChiDinh"]);
            //rpt.Show();
        }
        private void fg_BeforeEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {

            if (fg.GetDataDisplay(fg.Row, "UseDuyetBHYT").ToLower() != GlobalModuls.Global.glbUName.ToLower() && fg.GetDataDisplay(fg.Row, "UseDuyetBHYT").Trim() != "")
            {
                MessageBox.Show("Phiếu chỉ định này đã được duyệt bởi người khác. Bạn không được duyệt lại!!", "Thông báo", MessageBoxButtons.OK);
                e.Cancel = true;
                txtNgayDuyet.Focus();
                return;
            }
            
        }

        private void Label28_Leave(object sender, EventArgs e)
        {
            txtSoPhieuCD.Focus();
        }

        private void txtThoigianChidinh_ValueChanged(object sender, EventArgs e)
        {
            LoadPhanCD();
        }
    }
}