﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GlobalModuls;
using System.Data.SqlClient;
using C1.Win.C1FlexGrid;
using NamDinh_QLBN.Reports.PhieuHoanThuoc;

namespace NamDinh_QLBN.Forms.In
{
    public partial class frmInPhieuHoanVTTH : Form
    {
        bool SuaChua = false;
        public frmInPhieuHoanVTTH()
        {
            InitializeComponent();
            this.fgDanhSach.Cols["SoLuongBD"].Visible = false;
            //this.fgDanhSach.Cols["DuyetHoan"].Visible = false;
            this.fgDanhSach.Cols["DaTinhPhi"].Visible = false;
            //this.fgDanhSach.Cols["MaPhieuHoan"].Visible=false;
        }
        private string MaPhieuHoan;
        private string DuyetHoan;
        private int mRow;
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoatDanhMuc()
        {
            SqlCommand command = new SqlCommand();
            command.Connection = Global.ConnectSQL;
            command.CommandText = "SELECT * FROM DMKHOAPHONG WHERE Len(MaKHoa)>1 AND MaKhoa IN " + Global.glbKhoa_CapNhat;
            SqlDataReader reader = command.ExecuteReader();
            this.cmbKhoa.ClearItems();
            while (reader.Read())
            {
                this.cmbKhoa.AddItem(string.Format("{0};{1}", reader["MaKhoa"], reader["TenKhoa"]));
            }
            reader.Close();
            command.Dispose();
            this.cmbKhoa.SelectedIndex = 0;
            command.CommandText = "SELECT * FROM KHOA_NHOM WHERE MaKhoa IN " + Global.glbKhoa_CapNhat;
            reader = command.ExecuteReader();
            this.cmbNhomLenThuoc.ClearItems();
            this.cmbNhomLenThuoc.AddItem("0;--------- TẤT CẢ---------");
            while (reader.Read())
            {
                this.cmbNhomLenThuoc.AddItem(string.Format("{0};{1}", reader["MANHOM"], reader["TENNHOM"]));
            }
            reader.Close();
            command.Dispose();
            this.cmbNhomLenThuoc.SelectedIndex = 0;
            if (this.cmbKhoa.ListCount == 1)
            {
                this.cmbKhoa.SelectedIndex = 0;
            }
            this.txtNgayChiDinh.Value = Global.NgayLV;
            this.cmbNhom.AddItem("--------- Tất cả---------");
            this.cmbNhom.AddItem("Chi phí trong ngày");
            this.cmbNhom.AddItem("Chi phí trong trực");
            this.cmbNhom.SelectedIndex = 1;
            CellStyle style = this.fgDanhSach.Styles[CellStyleEnum.Subtotal0];
            style.BackColor = Color.LightBlue;
            style.ForeColor = Color.DarkBlue;
            this.fgDanhSach.Rows.Count = 1;
            this.txtNgayChiDinh.Value = Global.NgayLV;
            for (int i = 1; i < this.fgDanhSach.Cols.Count; i++)
            {
                if (i < 5)
                {
                    this.fgDanhSach.Cols[i].Visible = false;
                }
                else if ((this.fgDanhSach.Cols["SoLuongHT"].Index == i) || (this.fgDanhSach.Cols["LyDo"].Index == i))
                {
                    this.fgDanhSach.Cols[i].AllowEditing = true;
                }
                else
                {
                    this.fgDanhSach.Cols[i].AllowEditing = false;
                }
            }
        }

        private void LoatData()
        {
            if (!SuaChua) return;
            //for (int i = fgDanhSach.Rows.Count-1; i>0 ;i--)
            //    fgDanhSach.Rows.Remove(i);
            fgDanhSach.Redraw = false;
            fgDanhSach.Rows.Count = 1;
            SqlCommand command = new SqlCommand();
            command.Connection = Global.ConnectSQL;
            this.fgDanhSach.Tree.Column = fgDanhSach.Cols["TenThuoc"].Index;
            string str = string.Format("set dateformat dmy SELECT D.*,E.MADICHVU,E.SOLUONG,E.SOLUONGHT,DMDICHVU.TENDICHVU,DMDICHVU.DVT,DMDICHVU.LOAITHUOC,E.LYDO,MaPhieuHoan,isnull(DuyetHoan,0) as DuyetHoan,DaTinhPhi FROM "
                + "(SELECT A.*,B.DaTinhPhi,B.MAVAOVIEN,C.SOPHIEU,C.NGAYCHIDINH,C.MAKHOA,C.NHOM FROM ((BENHNHAN A INNER JOIN BENHNHAN_CHITIET B ON A.MABENHNHAN = B.MABENHNHAN)"
                + " INNER JOIN BENHNHAN_PHIEUDIEUTRI C ON C.MAVAOVIEN = B.MAVAOVIEN) WHERE DATEDIFF(DD,C.NGAYCHIDINH,'{0:dd/MM/yyyy}') = 0 AND C.MAKHOA = '{1}' "
                    , this.txtNgayChiDinh.Value, Global.GetCode(this.cmbKhoa));
            if (this.cmbNhom.SelectedIndex == 0)
            {
                str = str + ")D";
            }
            else if (this.cmbNhom.SelectedIndex == 1)
            {
                str = str + " AND C.NHOM = 0 )D";
            }
            else
            {
                str = str + " AND C.NHOM = 1 )D";
            }
            str = str + " INNER JOIN PHIEUDIEUTRI_CHITIET E ON E.SOPHIEU = D.SOPHIEU INNER JOIN DMDICHVU ON DMDICHVU.MADICHVU = E.MADICHVU WHERE  E.LOAIDICHVU in ('D02','D06') AND E.DATHUCHIEN = 1";
            if (Global.GetCode(this.cmbNhomLenThuoc) != "0")
            {
                str = str + string.Format(" AND E.MANHOM ={0}", Global.GetCode(this.cmbNhomLenThuoc));
            }
            str = str + " order by hoten,tendichvu";
            command.CommandText = str;
            command.CommandTimeout = 0;
            SqlDataReader reader = command.ExecuteReader();
            fgDanhSach.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Free;
            fgDanhSach.Cols["MaPhieuHoan"].AllowMerging = true;
            while (reader.Read())
            {
                this.fgDanhSach.Rows.Add();
                this.fgDanhSach[this.fgDanhSach.Rows.Count - 1, "STT"] = this.fgDanhSach.Rows.Count;
                this.fgDanhSach[this.fgDanhSach.Rows.Count - 1, "MaBenhNhan"] = reader["MaVaoVien"];
                this.fgDanhSach[this.fgDanhSach.Rows.Count - 1, "TenBenhNhan"] = reader["HoTen"];
                this.fgDanhSach[this.fgDanhSach.Rows.Count - 1, "SoPhieu"] = reader["SoPhieu"];
                this.fgDanhSach[this.fgDanhSach.Rows.Count - 1, "MaThuoc"] = reader["MaDichVu"];
                this.fgDanhSach[this.fgDanhSach.Rows.Count - 1, "TenThuoc"] = reader["TenDichVu"];
                this.fgDanhSach[this.fgDanhSach.Rows.Count - 1, "DVT"] = reader["DVT"];
                this.fgDanhSach[this.fgDanhSach.Rows.Count - 1, "SoLuongNhan"] = decimal.Parse(reader["SoLuong"].ToString());
                this.fgDanhSach[this.fgDanhSach.Rows.Count - 1, "SoLuongHT"] = reader["SoLuongHT"];
                this.fgDanhSach[this.fgDanhSach.Rows.Count - 1, "SoLuongBD"] = decimal.Parse(reader["SoLuong"].ToString()) + decimal.Parse(reader["SoLuongHT"].ToString());
                if (this.fgDanhSach.GetDataDisplay(this.fgDanhSach.Rows.Count - 1, "SoLuongHT") != "0") this.fgDanhSach[this.fgDanhSach.Rows.Count - 1, "MaPhieuHoan"] = reader["MaPhieuHoan"];
                else this.fgDanhSach[this.fgDanhSach.Rows.Count - 1, "MaPhieuHoan"] = "";
                this.fgDanhSach[this.fgDanhSach.Rows.Count - 1, "LyDo"] = reader["LyDo"];
                this.fgDanhSach[this.fgDanhSach.Rows.Count - 1, "DuyetHoan"] = reader["DuyetHoan"];
                this.fgDanhSach[this.fgDanhSach.Rows.Count - 1, "SoLuongCL"] = decimal.Parse(reader["SoLuong"].ToString());
                this.fgDanhSach[this.fgDanhSach.Rows.Count - 1, "DaTinhPhi"] = decimal.Parse(reader["DaTinhPhi"].ToString());
            }
            reader.Close();
            this.fgDanhSach.Subtotal(AggregateEnum.None, 0, fgDanhSach.Cols["TenBenhNhan"].Index, fgDanhSach.Cols["TenThuoc"].Index, "{0}");
            this.fgDanhSach.AutoResize = true;
            fgDanhSach.Redraw = true;
            command.Dispose();
        }
        private void frmInPhieuHoanTra_Load(object sender, EventArgs e)
        {
            SuaChua = false;
            this.LoatDanhMuc();
            SuaChua = true;
            this.LoatData();
        }
        private void txtNgayChiDinh_Validateed(object sender, EventArgs e)
        {
            LoatData();
            fgDanhSach.Focus();
        }

        private void cmbNhom_TextChanged(object sender, EventArgs e)
        {
            LoatData();
        }
        private void cmbNhomLenThuoc_TextChanged(object sender, EventArgs e)
        {
            LoatData();
        }

        private void fgDanhSach_BeforeEdit(object sender, RowColEventArgs e)
        {
            if (this.fgDanhSach.Rows[e.Row].IsNode || this.fgDanhSach.GetData(e.Row, "DaTinhPhi").ToString().ToLower() == "true")
            {
                e.Cancel = true;
            }
        }
        private void fgDanhSach_AfterEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            if (!this.fgDanhSach.Rows[e.Row].IsNode && e.Col == fgDanhSach.Cols["SoLuongHT"].Index)
            {
                if (this.fgDanhSach.GetData(e.Row, "DuyetHoan").ToString().ToLower() == "true")
                {
                    MessageBox.Show("Không thể sửa số lượng hoàn khi phòng vật tư đã duyệt hoàn");
                    return;
                }
                if (Convert.ToDecimal(this.fgDanhSach.GetData(e.Row, "SoLuongBD")) < Convert.ToDecimal(this.fgDanhSach.GetData(e.Row, "SoLuongHT")))
                {
                    MessageBox.Show("Xem lại số lượng ho\x00e0n trả.", "Th\x00f4ng b\x00e1o.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    this.fgDanhSach[e.Row, "SoLuongHT"] = 0;
                    this.fgDanhSach[e.Row, "SoLuongNhan"] = fgDanhSach.GetData(e.Row, "SoLuongBD");
                    this.fgDanhSach[e.Row, "SoLuongCL"] = fgDanhSach.GetData(e.Row, "SoLuongNhan");
                }
                this.fgDanhSach[e.Row, "SoLuongCL"] = Convert.ToDecimal(this.fgDanhSach.GetData(e.Row, "SoLuongBD")) - Convert.ToDecimal(this.fgDanhSach.GetData(e.Row, "SoLuongHT"));
            }
        }

       
        private void LayMaPhieuHoan()
        { 
            String Str = "";
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
            //System.Data.SqlClient.SqlTransaction trn = Global.ConnectSQL.BeginTransaction();
            //SQLCmd.Transaction = trn;
            try
            {
                Str = String.Format("DECLARE @s_ngay varchar(6),@SoLuuTru varchar(11) "
                    + " set @s_ngay= Right(Convert(nvarchar(8),'{0:yyyyMMdd}',112),6)"
                    + " exec dbo.LayMaPhieuHoan @s_ngay,@MAPHIEUHOAN output "//
                    + " exec dbo.GetNextSoLuuTruNT @MAPHIEUHOAN,'{1}',@SoLuuTru output ", Global.NgayLV, Global.GetCode(this.cmbKhoa));
                SqlParameter MAPHIEUHOAN = new SqlParameter("@MAPHIEUHOAN", SqlDbType.VarChar, 11);
                MAPHIEUHOAN.Direction = ParameterDirection.Output;
                SQLCmd.Parameters.Add(MAPHIEUHOAN);
                SQLCmd.CommandText = Str;
                SQLCmd.CommandTimeout = 0;
                SQLCmd.ExecuteNonQuery();
                MaPhieuHoan = MAPHIEUHOAN.Value.ToString();
                //trn.Commit();
            }
            catch (Exception ex)
            {
                //trn.Rollback();
                MaPhieuHoan = "";
            }
            finally
            {
                SQLCmd.Dispose();
                //trn.Dispose();
            }
        }
        private void btnGhi_Click(object sender, EventArgs e)
        {
            LayMaPhieuHoan();
            if (MaPhieuHoan==null || MaPhieuHoan == "")
            {
                MessageBox.Show("Ghi dữ liệu không thành công do không lấy được mã phiếu hoàn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            SqlCommand command = new SqlCommand();
            command.Connection = Global.ConnectSQL;
            SqlTransaction transaction = Global.ConnectSQL.BeginTransaction();
            command.Transaction = transaction;
            try
            {
                string str = "";
                for (int i = 1; i < this.fgDanhSach.Rows.Count; i++)
                {
                    if (!this.fgDanhSach.Rows[i].IsNode)
                    {
                        if (fgDanhSach.GetData(i, "MaPhieuHoan").ToString() == "")
                        {
                            double slht = double.Parse(fgDanhSach.GetData(i, "SoLuongHT").ToString().Replace(".", "").Replace(",", "."));
                            if (slht > 0)
                            {
                                str = str + string.Format(" UPDATE PHIEUDIEUTRI_CHITIET SET SOLUONG={0},SOLUONGHT={1},LYDO=N'{2}',MaPhieuHoan='{3}'  WHERE SOPHIEU ='{4}' AND LOAIDICHVU in ({5}) AND MADICHVU ='{6}' and {1}>0 ", //--and (MaPhieuHoan is null or MaPhieuHoan = '')
                                    new object[] { this.fgDanhSach.GetData(i, "SoLuongCL").ToString().Replace(".", "").Replace(",", "."), this.fgDanhSach.GetData(i, "SoLuongHT").ToString().Replace(".", "").Replace(",", "."), this.fgDanhSach.GetDataDisplay(i, "LyDo"),MaPhieuHoan,
                                this.fgDanhSach.GetDataDisplay(i, "SoPhieu"), "'D02','D06'", this.fgDanhSach.GetDataDisplay(i, "MaThuoc") });
                            }
                            else if (slht == 0) str = str + string.Format(" UPDATE PHIEUDIEUTRI_CHITIET SET SOLUONG={0},SOLUONGHT={1},LYDO=N'{2}',MaPhieuHoan='' WHERE SOPHIEU ='{4}' AND LOAIDICHVU in ({5}) AND MADICHVU ='{6}' and {1}=0",
                                        new object[] { this.fgDanhSach.GetData(i, "SoLuongCL").ToString().Replace(".", "").Replace(",", "."), this.fgDanhSach.GetData(i, "SoLuongHT").ToString().Replace(".", "").Replace(",", "."), this.fgDanhSach.GetDataDisplay(i, "LyDo"),MaPhieuHoan,
                                this.fgDanhSach.GetDataDisplay(i, "SoPhieu"), "'D02','D06'", this.fgDanhSach.GetDataDisplay(i, "MaThuoc") });
                        }
                    }
                }
                if (str != "")
                {
                    command.CommandText = str;
                    command.CommandTimeout = 0;
                    command.ExecuteNonQuery();
                    transaction.Commit();
                    MessageBox.Show("Ghi dữ liệu th\x00e0nh c\x00f4ng.", "Th\x00f4ng b\x00e1o.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch
            {
                transaction.Rollback();
                MessageBox.Show("Chưa thực hiện được.", "Th\x00f4ng b\x00e1o.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            finally
            {
                command.Dispose();
                transaction.Dispose();
                LoatData();
            }
        }

        private void btnInPhieu_Click(object sender, EventArgs e)
        {
            if (MaPhieuHoan == "")
            {
                MessageBox.Show("Chọn Mã phiếu hoàn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string SoLuuTru = "";
            System.Data.SqlClient.SqlCommand Cmd = new System.Data.SqlClient.SqlCommand();
            Cmd.Connection = GlobalModuls.Global.ConnectSQL;
            Cmd.CommandText = string.Format("SELECT isnull(SoLuuTru,'') FROM PhieuLinh_LuuTru WHERE MaPhieu='{0}' and PhongKhoaID='{1}' ", MaPhieuHoan, Global.GetCode(cmbKhoa));
            if (Cmd.ExecuteScalar() != null) SoLuuTru = Cmd.ExecuteScalar().ToString();
            else SoLuuTru = "";
            string title = "", dk = "", str = "";
            if (rdVTTH.Checked)
            {
                title = "PHIẾU HOÀN VẬT TƯ";
                dk = " and b.loaidichvu ='D02'";
            }
            else
            {
                title = "PHIẾU HOÀN THUỐC D.CHUNG";
                dk = " and b.loaidichvu ='D06'";
            }
            SqlCommand command = new SqlCommand();
            command.Connection = Global.ConnectSQL;
            try
            {
                str = "SELECT MaPhieuHoan+' - '+B.KhoID as MaPhieuHoan,dm.TENDICHVU,dm.DVT,SUM(B.SOLUONGHT) AS SOLUONG,b.DonGia,"
                    + " sum(B.SoLuongHT*B.DonGia) as ThanhTien,B.KHOID,KHO.TENKHO "
                    + " ,'' as GROUPS"
                    + " FROM (BENHNHAN_PHIEUDIEUTRI A INNER JOIN PHIEUDIEUTRI_CHITIET B ON A.SOPHIEU = B.SOPHIEU)"
                    + " INNER JOIN DMDICHVU DM ON DM.MADICHVU = B.MADICHVU AND DM.LOAIDICHVU = B.LOAIDICHVU";
                if (this.rdVTTH.Checked)
                {
                    str +=" INNER JOIN NAMDINH_QLVTTH.DBO.DANHMUCKHO KHO ON KHO.KHOID = B.KHOID";
                }
                else
                {
                    str +=" INNER JOIN NAMDINH_DUOC.DBO.DANHMUCKHO KHO ON KHO.KHOID = B.KHOID";
                }
                str+=String.Format(" WHERE B.DATHUCHIEN = 1 AND B.SOLUONGHT <> 0 "+dk
                    + " AND DATEDIFF(DD,A.NGAYCHIDINH,'{1:dd/MM/yyyy}') = 0 AND A.MAKHOA ='{0}'", 
                    Global.GetCode(this.cmbKhoa), this.txtNgayChiDinh.Value);
                if (this.cmbNhom.SelectedIndex != 0)
                {
                    if (this.cmbNhom.SelectedIndex == 1)
                    {
                        str = str + " and A.Nhom = 0 ";
                    }
                    else
                    {
                        str = str + " and A.Nhom = 1 ";
                    }
                }
                if (Global.GetCode(this.cmbNhomLenThuoc) != "0")
                {
                    str = str + string.Format(" And B.MaNhom={0}", Global.GetCode(this.cmbNhomLenThuoc));
                }
                str = str + " and MaPhieuHoan='" + MaPhieuHoan + "' GROUP BY MaPhieuHoan,b.MaDichVu,"
                    + "dm.TENDICHVU,dm.DVT,b.DonGia,B.KHOID,KHO.TENKHO ORDER BY Groups,dm.TENDICHVU";
                command.CommandText = str;
                command.CommandTimeout = 0;
                SqlDataReader reader = command.ExecuteReader();
                string ngay = string.Format("Ngày {0:dd} tháng {0:MM} năm {0:yyyy}", this.txtNgayChiDinh.Value);
                rptPhieuHoanVTTH thuoc = new rptPhieuHoanVTTH(this.cmbKhoa.Text, ngay, SoLuuTru, title);
                thuoc.DataSource = reader;
                thuoc.Show();
                reader.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
            finally
            {
                command.Dispose();
            }
        }

        private void fgDanhSach_Click(object sender, EventArgs e)
        {
            if (fgDanhSach.Rows.Count <= 0) return;
            if (fgDanhSach.Row < 0) return;
            if (this.fgDanhSach.Rows[fgDanhSach.Row].IsNode) 
            {
                MaPhieuHoan = "";
                return;
            }
            MaPhieuHoan = fgDanhSach.GetDataDisplay(fgDanhSach.Row, "MaPhieuHoan");
            DuyetHoan = this.fgDanhSach.GetData(fgDanhSach.Row, "DuyetHoan").ToString().ToLower();
        }

        private void cmbHuy_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Phần mềm xóa mã cũ ! Bạn có tiếp tục?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            if (MaPhieuHoan == "")
            {
                MessageBox.Show("Bạn phải chọn phiếu để hủy hoàn vật tư!");
                return;
            }
            else if (DuyetHoan == "true")
            {
                MessageBox.Show("Phiếu này đã được duyệt trên phòng vật tư! Không thể hủy");
                return;
            }
            SqlCommand command = new SqlCommand();
            command.Connection = Global.ConnectSQL;
            SqlTransaction transaction = Global.ConnectSQL.BeginTransaction();
            command.Transaction = transaction;
            try
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "HuyPhieuHoanVTTH";
                SqlParameter pr1 = new SqlParameter("@MaPhieuHoan", SqlDbType.VarChar, 11);
                pr1.Value = MaPhieuHoan;
                command.Parameters.Add(pr1);
                SqlParameter pr2 = new SqlParameter("@MaKhoa", SqlDbType.VarChar, 20);
                pr2.Value = Global.glbKhoa_CapNhat;
                command.Parameters.Add(pr2);
                command.CommandTimeout = 0;
                command.ExecuteNonQuery();
                transaction.Commit();
                MessageBox.Show("Hủy phiếu hoàn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch(Exception ex)
            {
                transaction.Rollback();
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            finally
            {
                command.Dispose();
                transaction.Dispose();
                LoatData();
            }
        }
    }
}