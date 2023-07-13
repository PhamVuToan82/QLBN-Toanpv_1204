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
    public partial class frmNhapChiDinhChiPhi_luu_truoc_VanChuyenmau : Form
    {
        private C1.Win.C1FlexGrid.C1FlexGrid fg = null;
        private string DoituongBN = "";
        private string MaKhoa = "";
        private DateTime NgayVV;
        public frmNhapChiDinhChiPhi_luu_truoc_VanChuyenmau(C1.Win.C1FlexGrid.C1FlexGrid _fg, string _DoiTuongBN, string maKhoa, DateTime _NgayVV)
        {
            InitializeComponent();
            fg = _fg;
            DoituongBN = _DoiTuongBN;
            MaKhoa = maKhoa;
            NgayVV = _NgayVV;
        }

        private void txtTenDV_KeyUp(object sender, KeyEventArgs e)
        {
        }

        private void frmNhapChiDinhChiPhi_Load(object sender, EventArgs e)
        {
            this.Left = 1;
            this.Top = 100;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
            SQLCmd.CommandText = "SELECT a.* FROM DMLOAIDICHVU a INNER JOIN KHOA_LOAIDICHVU b ON a.MaLoaiDichVu=b.LoaiDichVu WHERE NoiTru_NgoaiTru in (1,3)  AND b.MaKhoa='" + MaKhoa +"' order by a.thutuchonchidinh";
            System.Data.SqlClient.SqlDataReader dr = SQLCmd.ExecuteReader();
            cmbLoaiDV.Tag = "0";
            while (dr.Read())
            {
                cmbLoaiDV.AddItem(string.Format("{0};{1}", dr["MaLoaiDichVu"], dr["TenLoaiDichVu"]));
            }
            dr.Close();
            cmbLoaiDV.SelectedIndex = -1;
            cmbLoaiDV.Tag = "1";
            cmbLoaiKho.Tag = "0";
            cmbLoaiKho.ClearItems();
            cmbLoaiKho.AddItem("0;Kho khối ngoại");
            cmbLoaiKho.AddItem("1;Kho khối nội");
            cmbLoaiKho.SelectedIndex = cmbLoaiKho.FindStringExact(Global.gblNoiNgoai, 0, 0);
            cmbLoaiKho.Tag = "1";
            SQLCmd.Dispose();
            cmbLoaiKho.Enabled = false;
            fgDichVu.Cols[0].AllowEditing = fgDichVu.Cols[2].AllowEditing = fgDichVu.Cols[3].AllowEditing = fgDichVu.Cols[4].AllowEditing = false;
        }

        private void cmbLoaiDV_TextChanged(object sender, EventArgs e)
        {
            if (cmbLoaiDV.Tag.ToString() == "0" || cmbLoaiDV.SelectedIndex == -1) return;
            txtTenDV.Text = "";
            fgDichVu.Rows.Count = 1;
            Load_DMDichVu(txtTenDV.Text.Trim());
        }
        private void Load_DMDichVu(String Key)
        {
            string TT37 = "";
            if (Global.GetCode(cmbLoaiDV).ToString() == "D01")
            {
                cmbLoaiKho.Enabled = false;
            }
            else
            {
                cmbLoaiKho.Enabled = false;
            }
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
            SQLCmd.CommandText = "SELECT 0 As [Chọn], a.MaDichVu as [Mã DV],a.TenDichVu as [Tên DV],a.DVT,";
            if (Global.GetCode(cmbLoaiDV) == "D02" || Global.GetCode(cmbLoaiDV) == "D06" || Global.GetCode(cmbLoaiDV) == "D01")
            {
                SQLCmd.CommandText += "1.0 As [SL],";
            }
            else
            {
                SQLCmd.CommandText += "1 As [SL],";
            }
            //if (DoituongBN.Substring(0, 1) == "1")
            //{
            //    SQLCmd.CommandText += "isNull(a.DonGiaBHYT,0) As [Đơn giá]";
            //}
            //else
            //{
            //    if(DoituongBN.Substring(0,1) == "3")
            //        SQLCmd.CommandText += "isNull(DonGia,0) As [Đơn giá]";
            //    else
            //        if (DoituongBN.Substring(0, 1) == "4")
            //            SQLCmd.CommandText += "isNull(DonGiaTuNguyen,0) As [Đơn giá]";
            //        else
            //            SQLCmd.CommandText += "isNull(DonGia,0) As [Đơn giá]";
            //}
            TT37 = " and (a.TT37 = 0 or a.TT37 = 2)";
            //if (NgayVV < DateTime.Parse("29/02/2016 23:59:59"))
            //{
            //    if (DoituongBN.Substring(0, 1) == "1")
            //    {
            //        SQLCmd.CommandText += "isNull(a.DonGia,0) As [Đơn giá]";
            //    }
            //    else
            //    {
            //        if (DoituongBN.Substring(0, 1) == "3")
            //            SQLCmd.CommandText += "isNull(DonGia,0) As [Đơn giá]";
            //        else
            //            if (DoituongBN.Substring(0, 1) == "4")
            //                SQLCmd.CommandText += "isNull(DonGiaTuNguyen,0) As [Đơn giá]";
            //            else
            //                SQLCmd.CommandText += "isNull(DonGia,0) As [Đơn giá]";
            //    }
            //}
            //else
            //{
            //    if (DoituongBN.Substring(0, 1) == "1")
            //    {
            //        SQLCmd.CommandText += "isNull(a.DonGiaBHYT,0) As [Đơn giá]";
            //        TT37 = " and (a.TT37 = 1 or a.TT37 = 2)";
            //    }
            //    else
            //    {
            //        if (DoituongBN.Substring(0, 1) == "3")
            //            SQLCmd.CommandText += "isNull(DonGia,0) As [Đơn giá]";
            //        else
            //            if (DoituongBN.Substring(0, 1) == "4")
            //                SQLCmd.CommandText += "isNull(DonGiaTuNguyen,0) As [Đơn giá]";
            //            else
            //                SQLCmd.CommandText += "isNull(DonGia,0) As [Đơn giá]";
            //    }
            //}
            if (NgayVV < DateTime.Parse("22/04/2017 23:59:59"))
            {
                if (DoituongBN.Substring(0, 1) == "1")
                {
                    SQLCmd.CommandText += "isNull(a.GiaT3,0) As [Đơn giá]";
                    TT37 = " and (a.TT37 = 1 or a.TT37 = 2)";
                }
                else
                {
                    if (DoituongBN.Substring(0, 1) == "3")
                        SQLCmd.CommandText += "isNull(DonGia,0) As [Đơn giá]";
                    else
                        if (DoituongBN.Substring(0, 1) == "4")
                            SQLCmd.CommandText += "isNull(DonGiaTuNguyen,0) As [Đơn giá]";
                        else
                            SQLCmd.CommandText += "isNull(DonGia,0) As [Đơn giá]";
                }
            }
            else
            {
                if (DoituongBN.Substring(0, 1) == "1")
                {
                    SQLCmd.CommandText += "isNull(a.DonGiaBHYT,0) As [Đơn giá]";
                    TT37 = " and (a.TT37 = 1 or a.TT37 = 2)";
                }
                else
                {
                    if (DoituongBN.Substring(0, 1) == "3")
                        SQLCmd.CommandText += "isNull(DonGia,0) As [Đơn giá]";
                    else
                        if (DoituongBN.Substring(0, 1) == "4")
                            SQLCmd.CommandText += "isNull(DonGiaTuNguyen,0) As [Đơn giá]";
                        else
                            SQLCmd.CommandText += "isNull(DonGia,0) As [Đơn giá]";
                }
            }
            SQLCmd.CommandText += " ,isnull(tblThietLapDichVu.ThuTuChon,500) as ThuTuChon,KhoID,a.SLHienTai, a.is_tinhphi FROM DMLENCHIPHI_BYKHOID a ";
            SQLCmd.CommandText += String.Format(" left join tblThietLapDichVu on tblThietLapDichVu.madichvu = a.madichvu and "
                + " tblThietLapDichVu.makhoa ='{0}'", MaKhoa);
            // Nếu là ngày giường thì lấy theo DMDICHVU_KHOA (Huy sửa 16/10/2016)
            if (Global.GetCode(cmbLoaiDV) == "B01") 
            {
                SQLCmd.CommandText += String.Format(" inner Join DMDICHVU_KHOA DV_Khoa on a.madichvu = DV_Khoa.Madichvu and DV_Khoa.MaKhoa = '{0}'", MaKhoa);
            }
            //-------------------------------------------------------------------        
            if (Global.GetCode(cmbLoaiDV) == "D02" || Global.GetCode(cmbLoaiDV) == "D06")
            {
                SQLCmd.CommandText += String.Format(" inner join VatTu on VatTu.MaChiPhi = a.MaDichVu and VatTu.MaKhoa='{0}'" , MaKhoa);
            }

            if (checkBox1.Checked)
            {
                if (Global.GetCode(cmbLoaiDV).Substring(0,2)!="D0")
                {
                    SQLCmd.CommandText += string.Format(" INNER JOIN KHOA_DICHVU b ON a.LoaiDichVu=b.LoaiDichVu AND a.MaDichVu=b.MaDichVu and b.makhoa = '{1}' WHERE a.LoaiDichVu='{0}' and a.TenDichVu like N'%{2}%'", Global.GetCode(cmbLoaiDV), MaKhoa, Key);
                }
                else
                {
                    SQLCmd.CommandText += string.Format(" INNER JOIN KHOA_DICHVU b ON a.LoaiDichVu=b.LoaiDichVu AND a.MaDichVu=b.MaDichVu and b.makhoa = '{1}' WHERE a.LoaiDichVu='{0}' and a.TenDichVu like N'{2}%'", Global.GetCode(cmbLoaiDV), MaKhoa, Key);
                }
                
            }
            else
            {
                if (Global.GetCode(cmbLoaiDV).Substring(0, 2) != "D0")
                {
                    SQLCmd.CommandText += string.Format(" WHERE a.LoaiDichVu='{0}' and a.TenDichVu like N'%{1}%'", Global.GetCode(cmbLoaiDV), Key);
                }
                else
                {
                    SQLCmd.CommandText += string.Format(" WHERE a.LoaiDichVu='{0}' and a.TenDichVu like N'{1}%'", Global.GetCode(cmbLoaiDV), Key);
                }
                
            }

            //if (Global.GetCode(cmbLoaiDV) == "D01")
            //{
            //    SQLCmd.CommandText += String.Format(" and (a.NoiNgoai = 1 or a.NoiNgoai = 2)", Global.GetCode(cmbLoaiKho));
            //}
            SQLCmd.CommandText += string.Format(" and a.NoiTru_NgoaiTru in (1,3) and a.khongsudung = 0 AND DBO.SearchDoiTuong({0},A.DOITUONG) = 1 {1} order by tblThietLapDichVu.ThuTuChon ",DoituongBN, TT37);
            System.Data.SqlClient.SqlDataReader dr = SQLCmd.ExecuteReader();
            fgDichVu.Tag = "0";
            Global.BindDataReaderToFlex(dr, fgDichVu);
            fgDichVu.Styles.Normal.WordWrap = true;
            fgDichVu.Cols[3].Width = 350;
            fgDichVu.AutoSizeRows();
            fgDichVu.Cols[1].DataType = typeof(bool);
            fgDichVu.Cols[2].Visible = false;
            fgDichVu.Cols[3].AllowEditing = fgDichVu.Cols[4].AllowEditing =fgDichVu.Cols[6].AllowEditing = false;
            fgDichVu.Cols[fgDichVu.Cols.Count - 3].Visible = false;
            fgDichVu.Cols[fgDichVu.Cols.Count - 4].Visible = false;
            //fgDichVu.Cols[fgDichVu.Cols["is_tinhphi"].Index].Visible = false;
            fgDichVu.Cols[fgDichVu.Cols.Count - 2].Caption = "Số lượng còn lại";
            fgDichVu.Tag = "1";
            dr.Close();
            SQLCmd.Dispose();
        }
        private void cmdGhi_Click(object sender, EventArgs e)
        {
            txtTenDV.Focus();
            string[] arrayNhom = new string[13] { "C54021,C54022,C54158,C54159", 
                                                "C54045,C54046,C54377,C54378,C54050,C54187,C54182,C54183",
                                                "C54555,C54468",
                                                "C54018,C54101,C54155",
                                                "C54226,C54223,C54102",
                                                "C54104,C54105,C54224,C54225",
                                                "C54227,C54228,C54106,C54107",
                                                "C54071,C54047,C54197,C54254",
                                                "C54039,C54041,C54044,C54124,C54037,C54176,C54178,C54181,C54244,C54174",
                                                "C54133,C54253,C54602,C54578",
                                                "C54132,C54252,C54580,C54604",
                                                "C54042,C54043,C54179,C54180",
                                                "C52035,C52119"};
            for (int i = 1; i < fgDichVu.Rows.Count; i++)
            {
                if (fgDichVu.GetCellCheck(i, 1) == C1.Win.C1FlexGrid.CheckEnum.Checked)
                {
                    if (decimal.Parse(fgDichVu[i,5].ToString()) == 0)
                    {
                        MessageBox.Show("Bạn đã nhập chi phí có số lượng bằng 0, hãy kiểm tra lại!!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if ((string.Compare((string)fgDichVu[i, 2], "C50314") == 0) && (fg.Rows.Count > 1)) // Nếu là    Định lượng Ethanol (cồn) (C50314) 
                    {
                        MessageBox.Show("Bạn phải nhập Xét nghiệm: Định lượng Ethanol (cồn) trên một phiếu chỉ định riêng !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if ((string.Compare((string)fgDichVu[i, 2], "C50098") == 0) && (fg.Rows.Count > 1)) // Nếu là    Khí máu (C50098) 
                    {
                        MessageBox.Show("Bạn phải nhập Xét nghiệm: Khí máu trên một phiếu chỉ định riêng !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }
            
            for (int i = 1; i < fgDichVu.Rows.Count; i++)
            {    
                if (fgDichVu.GetCellCheck(i, 1) == C1.Win.C1FlexGrid.CheckEnum.Checked)
                {
                    string MaCP=fgDichVu[i,2].ToString();
                    string TenCP =fgDichVu[i,3].ToString();
                    string DVTinh=fgDichVu[i,4].ToString();
                    string KhoID = fgDichVu[i, "KhoID"].ToString();
                    decimal SoLuong= decimal.Parse(fgDichVu[i,5].ToString());
                    decimal DonGia = decimal.Parse(fgDichVu[i, 6].ToString());
                    int is_tinhphi = int.Parse(fgDichVu[i, fgDichVu.Cols["is_tinhphi"].Index].ToString());
                    if (MaKhoa == "NV1103") is_tinhphi = 1; //Nếu là Khoa Phẫu thuật thì mặc định là Không tính phí
                    bool DaCoCP=false;
                    int Nhom = -1;
                    for (int j = 0; j<13; j++)
                    {
                        int vitri = arrayNhom[j].IndexOf(MaCP);
                        if (vitri > -1)
                        {
                            Nhom = j;
                            break;
                        }
                    }
                    for (int j=1;j<fg.Rows.Count;j++)
                    {
                        if (!fg.Rows[j].IsNode && fg[j,"MaDichVu"].ToString()==MaCP) 
                        {
                            DaCoCP = true;
                            break;
                        }
                        if (Nhom > -1) // Nếu dịch vụ vừa chọn nằm trong 1 nhóm nào đó 
                        {
                            if (!fg.Rows[j].IsNode && arrayNhom[Nhom].IndexOf(fg[j, "MaDichVu"].ToString())>-1)//Nếu trong danh sách đã chọn có dịch vụ thuộc nhóm trùng với nhóm của dịch vụ vừa chọn
                            {
                                MessageBox.Show("Hai dịch vụ sau có cùng vị trí: " + Environment.NewLine + "   - " + TenCP + Environment.NewLine + "   - " + fg[j, "TenDichVu"].ToString() + Environment.NewLine + "Bạn phải chọn dịch vụ 2 phim hoặc 3 phim tương ứng.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            } 
                        }
                    }
                    if (!DaCoCP) fg.AddItem(string.Format("|{0}|{1}|{2}|{3}|{4}|{5:#,##0.##}|{6:#,##0.##}|{7:#,##0.##}|{11}|0|{8}||{9}|{10}",
                        Global.GetCode(cmbLoaiDV),
                        cmbLoaiDV.Text,
                        MaCP,
                        TenCP,
                        DVTinh,
                        SoLuong,
                        DonGia,
                        SoLuong * DonGia,
                        "",
                        0, KhoID,1-is_tinhphi));                              
                }
            }
            Format_Grid();
            txtTenDV.Text = "";
        }
        private void Format_Grid()
        {
            fg.Redraw = false;
            fg.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.Clear, 0, 0, 0);
            fg.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.Sum, 0, 2,fg.Cols["ThanhTien"].Index,"{0}");
            int TT = 1;
            for (int i = 1; i < fg.Rows.Count; i++)
            {
                if (fg.Rows[i].IsNode) TT = 1;
                else
                {
                    fg[i, 0] = TT;
                    TT++;
                }
            }
            fg.AutoSizeCols();
            fg.Redraw = true;
            if (fg.Rows.Count <= 1) return;
            fg.Row = fg.Rows.Count - 1;
        }
        private void cmdHuy_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (cmbLoaiDV.SelectedIndex == -1) return;
            txtTenDV.Text = "";
            fgDichVu.Rows.Count = 1;
            Load_DMDichVu(txtTenDV.Text.Trim());
        }

        private void txtTenDV_TextChanged(object sender, EventArgs e)
        {
            Load_DMDichVu(txtTenDV.Text.Trim());
        }

        private void fgDichVu_AfterEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
             
            if (e.Col == fgDichVu.Cols["Chọn"].Index)
            {
                if (Global.GetCode(cmbLoaiDV) == "D02" || Global.GetCode(cmbLoaiDV) == "D05" || Global.GetCode(cmbLoaiDV) == "D01" || Global.GetCode(cmbLoaiDV) == "B02")
                    fgDichVu.Select(e.Row, fgDichVu.Cols["SL"].Index);
            }
            if (((string.Compare((string)fgDichVu[e.Row, 2], "C51111") == 0) || (string.Compare((string)fgDichVu[e.Row, 2], "C51112") == 0) || (string.Compare((string)fgDichVu[e.Row, 2], "C51113") == 0) || (string.Compare((string)fgDichVu[e.Row, 2], "C51114") == 0)) && (1 == e.Col))
            {
                fgDichVu[e.Row, 1] = 0;
                cmdGhi_Click(sender, e);
                cmdHuy_Click(sender, e);
                return;
            }
            if (((string.Compare((string)fgDichVu[e.Row, 2], "C51115") == 0) || (string.Compare((string)fgDichVu[e.Row, 2], "C51116") == 0) || (string.Compare((string)fgDichVu[e.Row, 2], "C51117") == 0) || (string.Compare((string)fgDichVu[e.Row, 2], "C51118") == 0) || (string.Compare((string)fgDichVu[e.Row, 2], "C51125") == 0) ||(string.Compare((string)fgDichVu[e.Row, 2], "C51126") == 0) ||(string.Compare((string)fgDichVu[e.Row, 2], "C51127") == 0) ||(string.Compare((string)fgDichVu[e.Row, 2], "C51128") == 0) ||(string.Compare((string)fgDichVu[e.Row, 2], "C51129") == 0)) && (1 == e.Col))
            {
                fgDichVu[e.Row, 1] = 0;
                return;
            }
            if ((string.Compare((string)fgDichVu[e.Row, 2], "C50314") == 0) && (1 == e.Col)) //'Kiểm tra xem nếu là  Định lượng Ethanol (cồn) (C50314) 
            {
                // Cho các Chọn khác = false
                for (int i = 1; i < fgDichVu.Rows.Count; i++)
                {
                    if (i != e.Row)
                    {
                        fgDichVu[i, 1] = 0;
                    }
                }
                cmdGhi_Click(sender, e);
                cmdHuy_Click(sender, e);
                return;
            }
            if ((string.Compare((string)fgDichVu[e.Row, 2], "C50098") == 0) && (1 == e.Col)) //'Kiểm tra xem nếu là  Khí máu (C50098) 
            {
                // Cho các Chọn khác = false
                for (int i = 1; i < fgDichVu.Rows.Count; i++)
                {
                    if (i != e.Row)
                    {
                        fgDichVu[i, 1] = 0;
                    }
                }
                cmdGhi_Click(sender, e);
                cmdHuy_Click(sender, e);
                return;
            }
        }

        private void frmNhapChiDinhChiPhi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                cmdGhi_Click(null, null);
            }
            if (e.KeyCode == Keys.F4)
            {
                this.Dispose();
            }
        }

        //private void fgDichVu_StartEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        //{
        //    if (5 == e.Col)
        //    {
        //        fgDichVu[e.Row,1] = 1;
        //    }
        //    // Nếu là các dịch vụ phát máu
        //    if (((string.Compare((string)fgDichVu[e.Row, 2], "C51111") == 0) || (string.Compare((string)fgDichVu[e.Row, 2], "C51112") == 0) || (string.Compare((string)fgDichVu[e.Row, 2], "C51113") == 0) || (string.Compare((string)fgDichVu[e.Row, 2], "C51114") == 0)) && ( string.Compare(fgDichVu[e.Row, 1].ToString(),"0") == 0) && (1 == e.Col))
        //    {
        //        if (fg.Rows.Count > 1) // Kiểm tra xem đã chỉ định DV nào khác chưa, nếu có ko cho chọn DV phát máu, phải chọn chỉ định riêng 1 tờ
        //        {
        //            MessageBox.Show("Phải chỉ định dịch vụ Phát máu riêng trong 1 tờ.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            fgDichVu[e.Row, 1] = 0;
        //            return;
        //        }
        //        for (int i = 1; i < fgDichVu.Rows.Count; i++) // Đánh dấu không chọn tất cả các dv trong danh sách
        //        {
        //            fgDichVu[i, 1] = 0;
        //        }
        //        if ((string.Compare((string)fgDichVu[e.Row, 2], "C51111") == 0)) // Phát máu 1 đơn vị
        //        {
        //            for (int i = 1; i < fgDichVu.Rows.Count; i++) //  
        //            {
        //                if (string.Compare((string)fgDichVu[i, 2], "C51115") == 0) // ABO
        //                {
        //                    fgDichVu[i, 1] = 1;
        //                    fgDichVu[i, 5] = 3;
        //                }
        //                if (string.Compare((string)fgDichVu[i, 2], "C51125") == 0) // ABO trên thẻ
        //                {
        //                    fgDichVu[i, 1] = 1;
        //                    fgDichVu[i, 5] = 2;
        //                }
        //                if (string.Compare((string)fgDichVu[i, 2], "C51116") == 0) // Rh
        //                {
        //                    fgDichVu[i, 1] = 1;
        //                    fgDichVu[i, 5] = 1;
        //                }
        //                if (string.Compare((string)fgDichVu[i, 2], "C51117") == 0) // Coombs
        //                {
        //                    fgDichVu[i, 1] = 1;
        //                    fgDichVu[i, 5] = 1;
        //                }
        //                if (string.Compare((string)fgDichVu[i, 2], "C51118") == 0) // Cross
        //                {
        //                    fgDichVu[i, 1] = 1;
        //                    fgDichVu[i, 5] = 1;
        //                }
        //            }
 
        //        }
        //        if ((string.Compare((string)fgDichVu[e.Row, 2], "C51112") == 0)) // Phát máu 2 đơn vị
        //        {
        //            for (int i = 1; i < fgDichVu.Rows.Count; i++) //  
        //            {
        //                if (string.Compare((string)fgDichVu[i, 2], "C51115") == 0) // ABO
        //                {
        //                    fgDichVu[i, 1] = 1;
        //                    fgDichVu[i, 5] = 4;
        //                }
        //                if (string.Compare((string)fgDichVu[i, 2], "C51125") == 0) // ABO trên thẻ
        //                {
        //                    fgDichVu[i, 1] = 1;
        //                    fgDichVu[i, 5] = 3;
        //                }
        //                if (string.Compare((string)fgDichVu[i, 2], "C51116") == 0) // Rh
        //                {
        //                    fgDichVu[i, 1] = 1;
        //                    fgDichVu[i, 5] = 1;
        //                }
        //                if (string.Compare((string)fgDichVu[i, 2], "C51117") == 0) // Coombs
        //                {
        //                    fgDichVu[i, 1] = 1;
        //                    fgDichVu[i, 5] = 2;
        //                }
        //                if (string.Compare((string)fgDichVu[i, 2], "C51118") == 0) // Cross
        //                {
        //                    fgDichVu[i, 1] = 1;
        //                    fgDichVu[i, 5] = 2;
        //                }
        //            }

        //        }
        //        if ((string.Compare((string)fgDichVu[e.Row, 2], "C51113") == 0)) // Phát máu 3 đơn vị
        //        {
        //            for (int i = 1; i < fgDichVu.Rows.Count; i++) //  
        //            {
        //                if (string.Compare((string)fgDichVu[i, 2], "C51115") == 0) // ABO
        //                {
        //                    fgDichVu[i, 1] = 1;
        //                    fgDichVu[i, 5] = 5;
        //                }
        //                if (string.Compare((string)fgDichVu[i, 2], "C51125") == 0) // ABO trên thẻ
        //                {
        //                    fgDichVu[i, 1] = 1;
        //                    fgDichVu[i, 5] = 4;
        //                }
        //                if (string.Compare((string)fgDichVu[i, 2], "C51116") == 0) // Rh
        //                {
        //                    fgDichVu[i, 1] = 1;
        //                    fgDichVu[i, 5] = 1;
        //                }
        //                if (string.Compare((string)fgDichVu[i, 2], "C51117") == 0) // Coombs
        //                {
        //                    fgDichVu[i, 1] = 1;
        //                    fgDichVu[i, 5] = 3;
        //                }
        //                if (string.Compare((string)fgDichVu[i, 2], "C51118") == 0) // Cross
        //                {
        //                    fgDichVu[i, 1] = 1;
        //                    fgDichVu[i, 5] = 3;
        //                }
        //            }

        //        }
        //        if ((string.Compare((string)fgDichVu[e.Row, 2], "C51114") == 0)) // Phát máu 4 đơn vị
        //        {
        //            for (int i = 1; i < fgDichVu.Rows.Count; i++) //  
        //            {
        //                if (string.Compare((string)fgDichVu[i, 2], "C51115") == 0) // ABO
        //                {
        //                    fgDichVu[i, 1] = 1;
        //                    fgDichVu[i, 5] = 6;
        //                }
        //                if (string.Compare((string)fgDichVu[i, 2], "C51125") == 0) // ABO trên thẻ
        //                {
        //                    fgDichVu[i, 1] = 1;
        //                    fgDichVu[i, 5] = 5;
        //                }
        //                if (string.Compare((string)fgDichVu[i, 2], "C51116") == 0) // Rh
        //                {
        //                    fgDichVu[i, 1] = 1;
        //                    fgDichVu[i, 5] = 1;
        //                }
        //                if (string.Compare((string)fgDichVu[i, 2], "C51117") == 0) // Coombs
        //                {
        //                    fgDichVu[i, 1] = 1;
        //                    fgDichVu[i, 5] = 4;
        //                }
        //                if (string.Compare((string)fgDichVu[i, 2], "C51118") == 0) // Cross
        //                {
        //                    fgDichVu[i, 1] = 1;
        //                    fgDichVu[i, 5] = 4;
        //                }
        //            }

        //        }

                
        //    }
        //    //---------------------------
        //    //Nếu là các dịch vụ chi tiết trong phát máu thì ko cho chỉ định
        //    if (((string.Compare((string)fgDichVu[e.Row, 2], "C51115") == 0) || (string.Compare((string)fgDichVu[e.Row, 2], "C51125") == 0) || (string.Compare((string)fgDichVu[e.Row, 2], "C51116") == 0) || (string.Compare((string)fgDichVu[e.Row, 2], "C51117") == 0) || (string.Compare((string)fgDichVu[e.Row, 2], "C51118") == 0)) && (string.Compare(fgDichVu[e.Row, 1].ToString(), "0") == 0) && (1 == e.Col))
        //    {
        //        MessageBox.Show("Không được chỉ định chi tiết các dịch vụ trong Phát máu.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        fgDichVu[e.Row, 1] = 0;
        //        return;
        //    }
        //    //--------------------------------------------------------------
        //}
        //private void fgDichVu_StartEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        //{
        //    if (5 == e.Col)
        //    {
        //        fgDichVu[e.Row, 1] = 1;
        //    }
        //    // Nếu là các dịch vụ phát máu
        //    if ((DoituongBN.Substring(0, 1) != "1") || ((DoituongBN.Substring(0, 1) == "1") && (NgayVV < DateTime.Parse("29/02/2016 23:59:59")))) //Nếu là viện phí hoặc BHYT trước 1/3/2016 thì vẫn lấy 5 tên chi tiết như cũ
        //    {
        //        if (((string.Compare((string)fgDichVu[e.Row, 2], "C51111") == 0) || (string.Compare((string)fgDichVu[e.Row, 2], "C51112") == 0) || (string.Compare((string)fgDichVu[e.Row, 2], "C51113") == 0) || (string.Compare((string)fgDichVu[e.Row, 2], "C51114") == 0)) && (string.Compare(fgDichVu[e.Row, 1].ToString(), "0") == 0) && (1 == e.Col))
        //        {
        //            if (fg.Rows.Count > 1) // Kiểm tra xem đã chỉ định DV nào khác chưa, nếu có ko cho chọn DV phát máu, phải chọn chỉ định riêng 1 tờ
        //            {
        //                MessageBox.Show("Phải chỉ định dịch vụ Phát máu riêng trong 1 tờ.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //                fgDichVu[e.Row, 1] = 0;
        //                return;
        //            }
        //            for (int i = 1; i < fgDichVu.Rows.Count; i++) // Đánh dấu không chọn tất cả các dv trong danh sách
        //            {
        //                fgDichVu[i, 1] = 0;
        //            }
        //            if ((string.Compare((string)fgDichVu[e.Row, 2], "C51111") == 0)) // Phát máu 1 đơn vị
        //            {
        //                for (int i = 1; i < fgDichVu.Rows.Count; i++) //  
        //                {
        //                    if (string.Compare((string)fgDichVu[i, 2], "C51115") == 0) // ABO
        //                    {
        //                        fgDichVu[i, 1] = 1;
        //                        fgDichVu[i, 5] = 3;
        //                    }
        //                    if (string.Compare((string)fgDichVu[i, 2], "C51125") == 0) // ABO trên thẻ
        //                    {
        //                        fgDichVu[i, 1] = 1;
        //                        fgDichVu[i, 5] = 2;
        //                    }
        //                    if (string.Compare((string)fgDichVu[i, 2], "C51116") == 0) // Rh
        //                    {
        //                        fgDichVu[i, 1] = 1;
        //                        fgDichVu[i, 5] = 1;
        //                    }
        //                    if (string.Compare((string)fgDichVu[i, 2], "C51117") == 0) // Coombs
        //                    {
        //                        fgDichVu[i, 1] = 1;
        //                        fgDichVu[i, 5] = 1;
        //                    }
        //                    if (string.Compare((string)fgDichVu[i, 2], "C51118") == 0) // Cross
        //                    {
        //                        fgDichVu[i, 1] = 1;
        //                        fgDichVu[i, 5] = 1;
        //                    }
        //                }

        //            }
        //            if ((string.Compare((string)fgDichVu[e.Row, 2], "C51112") == 0)) // Phát máu 2 đơn vị
        //            {
        //                for (int i = 1; i < fgDichVu.Rows.Count; i++) //  
        //                {
        //                    if (string.Compare((string)fgDichVu[i, 2], "C51115") == 0) // ABO
        //                    {
        //                        fgDichVu[i, 1] = 1;
        //                        fgDichVu[i, 5] = 4;
        //                    }
        //                    if (string.Compare((string)fgDichVu[i, 2], "C51125") == 0) // ABO trên thẻ
        //                    {
        //                        fgDichVu[i, 1] = 1;
        //                        fgDichVu[i, 5] = 3;
        //                    }
        //                    if (string.Compare((string)fgDichVu[i, 2], "C51116") == 0) // Rh
        //                    {
        //                        fgDichVu[i, 1] = 1;
        //                        fgDichVu[i, 5] = 1;
        //                    }
        //                    if (string.Compare((string)fgDichVu[i, 2], "C51117") == 0) // Coombs
        //                    {
        //                        fgDichVu[i, 1] = 1;
        //                        fgDichVu[i, 5] = 2;
        //                    }
        //                    if (string.Compare((string)fgDichVu[i, 2], "C51118") == 0) // Cross
        //                    {
        //                        fgDichVu[i, 1] = 1;
        //                        fgDichVu[i, 5] = 2;
        //                    }
        //                }

        //            }
        //            if ((string.Compare((string)fgDichVu[e.Row, 2], "C51113") == 0)) // Phát máu 3 đơn vị
        //            {
        //                for (int i = 1; i < fgDichVu.Rows.Count; i++) //  
        //                {
        //                    if (string.Compare((string)fgDichVu[i, 2], "C51115") == 0) // ABO
        //                    {
        //                        fgDichVu[i, 1] = 1;
        //                        fgDichVu[i, 5] = 5;
        //                    }
        //                    if (string.Compare((string)fgDichVu[i, 2], "C51125") == 0) // ABO trên thẻ
        //                    {
        //                        fgDichVu[i, 1] = 1;
        //                        fgDichVu[i, 5] = 4;
        //                    }
        //                    if (string.Compare((string)fgDichVu[i, 2], "C51116") == 0) // Rh
        //                    {
        //                        fgDichVu[i, 1] = 1;
        //                        fgDichVu[i, 5] = 1;
        //                    }
        //                    if (string.Compare((string)fgDichVu[i, 2], "C51117") == 0) // Coombs
        //                    {
        //                        fgDichVu[i, 1] = 1;
        //                        fgDichVu[i, 5] = 3;
        //                    }
        //                    if (string.Compare((string)fgDichVu[i, 2], "C51118") == 0) // Cross
        //                    {
        //                        fgDichVu[i, 1] = 1;
        //                        fgDichVu[i, 5] = 3;
        //                    }
        //                }

        //            }
        //            if ((string.Compare((string)fgDichVu[e.Row, 2], "C51114") == 0)) // Phát máu 4 đơn vị
        //            {
        //                for (int i = 1; i < fgDichVu.Rows.Count; i++) //  
        //                {
        //                    if (string.Compare((string)fgDichVu[i, 2], "C51115") == 0) // ABO
        //                    {
        //                        fgDichVu[i, 1] = 1;
        //                        fgDichVu[i, 5] = 6;
        //                    }
        //                    if (string.Compare((string)fgDichVu[i, 2], "C51125") == 0) // ABO trên thẻ
        //                    {
        //                        fgDichVu[i, 1] = 1;
        //                        fgDichVu[i, 5] = 5;
        //                    }
        //                    if (string.Compare((string)fgDichVu[i, 2], "C51116") == 0) // Rh
        //                    {
        //                        fgDichVu[i, 1] = 1;
        //                        fgDichVu[i, 5] = 1;
        //                    }
        //                    if (string.Compare((string)fgDichVu[i, 2], "C51117") == 0) // Coombs
        //                    {
        //                        fgDichVu[i, 1] = 1;
        //                        fgDichVu[i, 5] = 4;
        //                    }
        //                    if (string.Compare((string)fgDichVu[i, 2], "C51118") == 0) // Cross
        //                    {
        //                        fgDichVu[i, 1] = 1;
        //                        fgDichVu[i, 5] = 4;
        //                    }
        //                }

        //            }


        //        }
        //    }
        //    else // Nếu là BHYT sau 1/3/2016 thì lấy 5 tên mới
        //    {
        //        if (((string.Compare((string)fgDichVu[e.Row, 2], "C51111") == 0) || (string.Compare((string)fgDichVu[e.Row, 2], "C51112") == 0) || (string.Compare((string)fgDichVu[e.Row, 2], "C51113") == 0) || (string.Compare((string)fgDichVu[e.Row, 2], "C51114") == 0)) && (string.Compare(fgDichVu[e.Row, 1].ToString(), "0") == 0) && (1 == e.Col))
        //        {
        //            if (fg.Rows.Count > 1) // Kiểm tra xem đã chỉ định DV nào khác chưa, nếu có ko cho chọn DV phát máu, phải chọn chỉ định riêng 1 tờ
        //            {
        //                MessageBox.Show("Phải chỉ định dịch vụ Phát máu riêng trong 1 tờ.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //                fgDichVu[e.Row, 1] = 0;
        //                return;
        //            }
        //            for (int i = 1; i < fgDichVu.Rows.Count; i++) // Đánh dấu không chọn tất cả các dv trong danh sách
        //            {
        //                fgDichVu[i, 1] = 0;
        //            }
        //            if ((string.Compare((string)fgDichVu[e.Row, 2], "C51111") == 0)) // Phát máu 1 đơn vị
        //            {
        //                for (int i = 1; i < fgDichVu.Rows.Count; i++) //  
        //                {
        //                    if (string.Compare((string)fgDichVu[i, 2], "C51115") == 0) // ABO
        //                    {
        //                        fgDichVu[i, 1] = 1;
        //                        fgDichVu[i, 5] = 3;
        //                    }
        //                    if (string.Compare((string)fgDichVu[i, 2], "C51125") == 0) // ABO trên thẻ
        //                    {
        //                        fgDichVu[i, 1] = 1;
        //                        fgDichVu[i, 5] = 2;
        //                    }
        //                    if (string.Compare((string)fgDichVu[i, 2], "C51116") == 0) // Rh
        //                    {
        //                        fgDichVu[i, 1] = 1;
        //                        fgDichVu[i, 5] = 1;
        //                    }
        //                    if (string.Compare((string)fgDichVu[i, 2], "C51126") == 0) // globulin
        //                    {
        //                        fgDichVu[i, 1] = 1;
        //                        fgDichVu[i, 5] = 1;
        //                    }
        //                    if (string.Compare((string)fgDichVu[i, 2], "C51127") == 0) // muối 22 độ
        //                    {
        //                        fgDichVu[i, 1] = 1;
        //                        fgDichVu[i, 5] = 1;
        //                    }
        //                }
        //            }
        //            if ((string.Compare((string)fgDichVu[e.Row, 2], "C51112") == 0)) // Phát máu 2 đơn vị
        //            {
        //                for (int i = 1; i < fgDichVu.Rows.Count; i++) //  
        //                {
        //                    if (string.Compare((string)fgDichVu[i, 2], "C51115") == 0) // ABO
        //                    {
        //                        fgDichVu[i, 1] = 1;
        //                        fgDichVu[i, 5] = 4;
        //                    }
        //                    if (string.Compare((string)fgDichVu[i, 2], "C51125") == 0) // ABO trên thẻ
        //                    {
        //                        fgDichVu[i, 1] = 1;
        //                        fgDichVu[i, 5] = 3;
        //                    }
        //                    if (string.Compare((string)fgDichVu[i, 2], "C51116") == 0) // Rh
        //                    {
        //                        fgDichVu[i, 1] = 1;
        //                        fgDichVu[i, 5] = 1;
        //                    }
        //                    if (string.Compare((string)fgDichVu[i, 2], "C51126") == 0) // globulin
        //                    {
        //                        fgDichVu[i, 1] = 1;
        //                        fgDichVu[i, 5] = 2;
        //                    }
        //                    if (string.Compare((string)fgDichVu[i, 2], "C51127") == 0) // muối 22 độ
        //                    {
        //                        fgDichVu[i, 1] = 1;
        //                        fgDichVu[i, 5] = 2;
        //                    }
        //                }

        //            }
        //            if ((string.Compare((string)fgDichVu[e.Row, 2], "C51113") == 0)) // Phát máu 3 đơn vị
        //            {
        //                for (int i = 1; i < fgDichVu.Rows.Count; i++) //  
        //                {
        //                    if (string.Compare((string)fgDichVu[i, 2], "C51115") == 0) // ABO
        //                    {
        //                        fgDichVu[i, 1] = 1;
        //                        fgDichVu[i, 5] = 5;
        //                    }
        //                    if (string.Compare((string)fgDichVu[i, 2], "C51125") == 0) // ABO trên thẻ
        //                    {
        //                        fgDichVu[i, 1] = 1;
        //                        fgDichVu[i, 5] = 4;
        //                    }
        //                    if (string.Compare((string)fgDichVu[i, 2], "C51116") == 0) // Rh
        //                    {
        //                        fgDichVu[i, 1] = 1;
        //                        fgDichVu[i, 5] = 1;
        //                    }
        //                    if (string.Compare((string)fgDichVu[i, 2], "C51126") == 0) // globulin
        //                    {
        //                        fgDichVu[i, 1] = 1;
        //                        fgDichVu[i, 5] = 3;
        //                    }
        //                    if (string.Compare((string)fgDichVu[i, 2], "C51127") == 0) // muối 22 độ
        //                    {
        //                        fgDichVu[i, 1] = 1;
        //                        fgDichVu[i, 5] = 3;
        //                    }
        //                }

        //            }
        //            if ((string.Compare((string)fgDichVu[e.Row, 2], "C51114") == 0)) // Phát máu 4 đơn vị
        //            {
        //                for (int i = 1; i < fgDichVu.Rows.Count; i++) //  
        //                {
        //                    if (string.Compare((string)fgDichVu[i, 2], "C51115") == 0) // ABO
        //                    {
        //                        fgDichVu[i, 1] = 1;
        //                        fgDichVu[i, 5] = 6;
        //                    }
        //                    if (string.Compare((string)fgDichVu[i, 2], "C51125") == 0) // ABO trên thẻ
        //                    {
        //                        fgDichVu[i, 1] = 1;
        //                        fgDichVu[i, 5] = 5;
        //                    }
        //                    if (string.Compare((string)fgDichVu[i, 2], "C51116") == 0) // Rh
        //                    {
        //                        fgDichVu[i, 1] = 1;
        //                        fgDichVu[i, 5] = 1;
        //                    }
        //                    if (string.Compare((string)fgDichVu[i, 2], "C51126") == 0) // globulin
        //                    {
        //                        fgDichVu[i, 1] = 1;
        //                        fgDichVu[i, 5] = 4;
        //                    }
        //                    if (string.Compare((string)fgDichVu[i, 2], "C51127") == 0) // muối 22 độ
        //                    {
        //                        fgDichVu[i, 1] = 1;
        //                        fgDichVu[i, 5] = 4;
        //                    }
        //                }

        //            }


        //        }
        //    }
        //        //---------------------------
        //        //Nếu là các dịch vụ chi tiết trong phát máu thì ko cho chỉ định
        //    if (((string.Compare((string)fgDichVu[e.Row, 2], "C51115") == 0) || (string.Compare((string)fgDichVu[e.Row, 2], "C51125") == 0) || (string.Compare((string)fgDichVu[e.Row, 2], "C51126") == 0) || (string.Compare((string)fgDichVu[e.Row, 2], "C51127") == 0) || (string.Compare((string)fgDichVu[e.Row, 2], "C51116") == 0) || (string.Compare((string)fgDichVu[e.Row, 2], "C51117") == 0) || (string.Compare((string)fgDichVu[e.Row, 2], "C51118") == 0)) && (string.Compare(fgDichVu[e.Row, 1].ToString(), "0") == 0) && (1 == e.Col))
        //        {
        //            MessageBox.Show("Không được chỉ định chi tiết các dịch vụ trong Phát máu.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            fgDichVu[e.Row, 1] = 0;
        //            return;
        //        }
        //    //--------------------------------------------------------------
        //}

        private void fgDichVu_StartEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            if (5 == e.Col)
            {
                fgDichVu[e.Row, 1] = 1;
            }
            // Nếu là các dịch vụ phát máu
            if (((string.Compare((string)fgDichVu[e.Row, 2], "C51111") == 0) || (string.Compare((string)fgDichVu[e.Row, 2], "C51112") == 0) || (string.Compare((string)fgDichVu[e.Row, 2], "C51113") == 0) || (string.Compare((string)fgDichVu[e.Row, 2], "C51114") == 0)) && (string.Compare(fgDichVu[e.Row, 1].ToString(), "0") == 0) && (1 == e.Col))
                {
                    if (fg.Rows.Count > 1) // Kiểm tra xem đã chỉ định DV nào khác chưa, nếu có ko cho chọn DV phát máu, phải chọn chỉ định riêng 1 tờ
                    {
                        MessageBox.Show("Phải chỉ định dịch vụ Phát máu riêng trong 1 tờ.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        fgDichVu[e.Row, 1] = 0;
                        return;
                    }
                    for (int i = 1; i < fgDichVu.Rows.Count; i++) // Đánh dấu không chọn tất cả các dv trong danh sách
                    {
                        fgDichVu[i, 1] = 0;
                    }
                    if ((string.Compare((string)fgDichVu[e.Row, 2], "C51111") == 0)) // Phát máu 1 đơn vị
                    {
                        for (int i = 1; i < fgDichVu.Rows.Count; i++) //  
                        {
                            if (string.Compare((string)fgDichVu[i, 2], "C51115") == 0) // ABO
                            {
                                fgDichVu[i, 1] = 1;
                                fgDichVu[i, 5] = 1;
                            }
                            if (string.Compare((string)fgDichVu[i, 2], "C51128") == 0) // Định nhóm máu hệ ABO bằng giấy định nhóm máu để truyền máu toàn phần, khối hồng cầu, khối bạch cầu
                            {
                                fgDichVu[i, 1] = 1;
                                fgDichVu[i, 5] = 1;
                            }
                            if (string.Compare((string)fgDichVu[i, 2], "C51116") == 0) // Rh
                            {
                                fgDichVu[i, 1] = 1;
                                fgDichVu[i, 5] = 1;
                            }
                            if (string.Compare((string)fgDichVu[i, 2], "C51117") == 0) // Phản ứng hoà hợp có sử dụng kháng globulin người (Kỹ thuật ống nghiệm) - Phát máu
                            {
                                fgDichVu[i, 1] = 1;
                                fgDichVu[i, 5] = 1;
                            }
                            if (string.Compare((string)fgDichVu[i, 2], "C51118") == 0) // Phản ứng hòa hợp trong môi trường nước muối ở 22 o C (kỹ thuật ống nghiệm) - Phát máu
                            {
                                fgDichVu[i, 1] = 1;
                                fgDichVu[i, 5] = 1;
                            }
                            if (string.Compare((string)fgDichVu[i, 2], "C51129") == 0) // Định nhóm máu tại giường bệnh trước truyền máu
                            {
                                fgDichVu[i, 1] = 1;
                                fgDichVu[i, 5] = 2;
                            }
                        }
                    }
                    if ((string.Compare((string)fgDichVu[e.Row, 2], "C51112") == 0)) // Phát máu 2 đơn vị
                    {
                        for (int i = 1; i < fgDichVu.Rows.Count; i++) //  
                        {
                            if (string.Compare((string)fgDichVu[i, 2], "C51115") == 0) // ABO
                            {
                                fgDichVu[i, 1] = 1;
                                fgDichVu[i, 5] = 1;
                            }
                            if (string.Compare((string)fgDichVu[i, 2], "C51128") == 0) // Định nhóm máu hệ ABO bằng giấy định nhóm máu để truyền máu toàn phần, khối hồng cầu, khối bạch cầu
                            {
                                fgDichVu[i, 1] = 1;
                                fgDichVu[i, 5] = 2;
                            }
                            if (string.Compare((string)fgDichVu[i, 2], "C51116") == 0) // Rh
                            {
                                fgDichVu[i, 1] = 1;
                                fgDichVu[i, 5] = 1;
                            }
                            if (string.Compare((string)fgDichVu[i, 2], "C51117") == 0) // Phản ứng hoà hợp có sử dụng kháng globulin người (Kỹ thuật ống nghiệm) - Phát máu
                            {
                                fgDichVu[i, 1] = 1;
                                fgDichVu[i, 5] = 2;
                            }
                            if (string.Compare((string)fgDichVu[i, 2], "C51118") == 0) // Phản ứng hòa hợp trong môi trường nước muối ở 22 o C (kỹ thuật ống nghiệm) - Phát máu
                            {
                                fgDichVu[i, 1] = 1;
                                fgDichVu[i, 5] = 2;
                            }
                            if (string.Compare((string)fgDichVu[i, 2], "C51129") == 0) // Định nhóm máu tại giường bệnh trước truyền máu
                            {
                                fgDichVu[i, 1] = 1;
                                fgDichVu[i, 5] = 3;
                            }
                        }
                    }
                    if ((string.Compare((string)fgDichVu[e.Row, 2], "C51113") == 0)) // Phát máu 3 đơn vị
                    {
                        for (int i = 1; i < fgDichVu.Rows.Count; i++) //  
                        {
                            if (string.Compare((string)fgDichVu[i, 2], "C51115") == 0) // ABO
                            {
                                fgDichVu[i, 1] = 1;
                                fgDichVu[i, 5] = 1;
                            }
                            if (string.Compare((string)fgDichVu[i, 2], "C51128") == 0) // Định nhóm máu hệ ABO bằng giấy định nhóm máu để truyền máu toàn phần, khối hồng cầu, khối bạch cầu
                            {
                                fgDichVu[i, 1] = 1;
                                fgDichVu[i, 5] = 3;
                            }
                            if (string.Compare((string)fgDichVu[i, 2], "C51116") == 0) // Rh
                            {
                                fgDichVu[i, 1] = 1;
                                fgDichVu[i, 5] = 1;
                            }
                            if (string.Compare((string)fgDichVu[i, 2], "C51117") == 0) // Phản ứng hoà hợp có sử dụng kháng globulin người (Kỹ thuật ống nghiệm) - Phát máu
                            {
                                fgDichVu[i, 1] = 1;
                                fgDichVu[i, 5] = 3;
                            }
                            if (string.Compare((string)fgDichVu[i, 2], "C51118") == 0) // Phản ứng hòa hợp trong môi trường nước muối ở 22 o C (kỹ thuật ống nghiệm) - Phát máu
                            {
                                fgDichVu[i, 1] = 1;
                                fgDichVu[i, 5] = 3;
                            }
                            if (string.Compare((string)fgDichVu[i, 2], "C51129") == 0) // Định nhóm máu tại giường bệnh trước truyền máu
                            {
                                fgDichVu[i, 1] = 1;
                                fgDichVu[i, 5] = 4;
                            }
                        }
                    }
                    if ((string.Compare((string)fgDichVu[e.Row, 2], "C51114") == 0)) // Phát máu 4 đơn vị
                    {
                        for (int i = 1; i < fgDichVu.Rows.Count; i++) //  
                        {
                            if (string.Compare((string)fgDichVu[i, 2], "C51115") == 0) // ABO
                            {
                                fgDichVu[i, 1] = 1;
                                fgDichVu[i, 5] = 1;
                            }
                            if (string.Compare((string)fgDichVu[i, 2], "C51128") == 0) // Định nhóm máu hệ ABO bằng giấy định nhóm máu để truyền máu toàn phần, khối hồng cầu, khối bạch cầu
                            {
                                fgDichVu[i, 1] = 1;
                                fgDichVu[i, 5] = 4;
                            }
                            if (string.Compare((string)fgDichVu[i, 2], "C51116") == 0) // Rh
                            {
                                fgDichVu[i, 1] = 1;
                                fgDichVu[i, 5] = 1;
                            }
                            if (string.Compare((string)fgDichVu[i, 2], "C51117") == 0) // Phản ứng hoà hợp có sử dụng kháng globulin người (Kỹ thuật ống nghiệm) - Phát máu
                            {
                                fgDichVu[i, 1] = 1;
                                fgDichVu[i, 5] = 4;
                            }
                            if (string.Compare((string)fgDichVu[i, 2], "C51118") == 0) // Phản ứng hòa hợp trong môi trường nước muối ở 22 o C (kỹ thuật ống nghiệm) - Phát máu
                            {
                                fgDichVu[i, 1] = 1;
                                fgDichVu[i, 5] = 4;
                            }
                            if (string.Compare((string)fgDichVu[i, 2], "C51129") == 0) // Định nhóm máu tại giường bệnh trước truyền máu
                            {
                                fgDichVu[i, 1] = 1;
                                fgDichVu[i, 5] = 5;
                            }
                        }
                    }



                }
            //---------------------------
            //Nếu là các dịch vụ chi tiết trong phát máu thì ko cho chỉ định
                if (((string.Compare((string)fgDichVu[e.Row, 2], "C51115") == 0) || (string.Compare((string)fgDichVu[e.Row, 2], "C51129") == 0) || (string.Compare((string)fgDichVu[e.Row, 2], "C51128") == 0) || (string.Compare((string)fgDichVu[e.Row, 2], "C51125") == 0) || (string.Compare((string)fgDichVu[e.Row, 2], "C51126") == 0) || (string.Compare((string)fgDichVu[e.Row, 2], "C51127") == 0) || (string.Compare((string)fgDichVu[e.Row, 2], "C51116") == 0) || (string.Compare((string)fgDichVu[e.Row, 2], "C51117") == 0) || (string.Compare((string)fgDichVu[e.Row, 2], "C51118") == 0)) && (string.Compare(fgDichVu[e.Row, 1].ToString(), "0") == 0) && (1 == e.Col))
            {
                MessageBox.Show("Không được chỉ định chi tiết các dịch vụ trong Phát máu.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                fgDichVu[e.Row, 1] = 0;
                return;
            }
            //--------------------------------------------------------------
            if ((Global.GetCode(cmbLoaiDV).ToString() == "C57") && (DoituongBN == "1"))
            {
                MessageBox.Show("Bạn phải giải thích cho bệnh nhân và bệnh nhân có giấy cam kết để chi trả phần chênh lệch giữa mức giá của dịch vụ CT Scanner 64 dãy và CT Scanner từ 1-32 dãy", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if ((Global.GetCode(cmbLoaiDV).ToString() == "C60") && (DoituongBN == "1"))
            {
                MessageBox.Show("BHYT chỉ thanh toán trong trường hợp sau: \n•	Chụp hệ động mạch: não, cảnh, chủ ngực / bụng, phổi, phế quản, mạc treo, thận, chậu, vành.\n•	Chụp hệ mạch tạng.\n•	Chụp đánh giá tưới máu não.\n•	Chụp hệ động mạch / tĩnh mạch chi. \n•	Chụp tim và các mạch máu lớn để đánh giá các cấu trúc tim, các mạch máu lớn liên quan.\n•	Đánh giá giai đoạn, tái phát, di căn ung thư để chỉ định phẫu thuật, xạ trị, hóa chất.\nNHỮNG TRƯỜNG HỢP KHÁC, BẠN PHẢI CHỌN PHẦN “CT SCANNER 64 DÃY THANH TOÁN VỚI MỨC CT SCANNER ≤32 DÃY”", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            //--------------------------------------------------------------
            //if (((string.Compare((string)fgDichVu[e.Row, 2], "C54002") == 0) || (string.Compare((string)fgDichVu[e.Row, 2], "C54003") == 0) || (string.Compare((string)fgDichVu[e.Row, 2], "C54059") == 0) || (string.Compare((string)fgDichVu[e.Row, 2], "C54060") == 0) || (string.Compare((string)fgDichVu[e.Row, 2], "C54061") == 0) || (string.Compare((string)fgDichVu[e.Row, 2], "C54062") == 0) || (string.Compare((string)fgDichVu[e.Row, 2], "C54063") == 0) || (string.Compare((string)fgDichVu[e.Row, 2], "C54064") == 0) || (string.Compare((string)fgDichVu[e.Row, 2], "C54065") == 0) || (string.Compare((string)fgDichVu[e.Row, 2], "C54066") == 0) || (string.Compare((string)fgDichVu[e.Row, 2], "C54067") == 0) || (string.Compare((string)fgDichVu[e.Row, 2], "C54068") == 0) || (string.Compare((string)fgDichVu[e.Row, 2], "C54069") == 0) || (string.Compare((string)fgDichVu[e.Row, 2], "C54134") == 0) || (string.Compare((string)fgDichVu[e.Row, 2], "C54135") == 0) || (string.Compare((string)fgDichVu[e.Row, 2], "C54136") == 0) || (string.Compare((string)fgDichVu[e.Row, 2], "C54137") == 0) || (string.Compare((string)fgDichVu[e.Row, 2], "C54138") == 0) || (string.Compare((string)fgDichVu[e.Row, 2], "C54139") == 0) || (string.Compare((string)fgDichVu[e.Row, 2], "C54140") == 0)) && (string.Compare(fgDichVu[e.Row, 1].ToString(), "0") == 0) && (1 == e.Col))
            //{
            //    for (int i = 1; i < fgDichVu.Rows.Count; i++) //  
            //    {
            //        if (string.Compare((string)fgDichVu[i, 2], "C57263") == 0) // 64 ko can quang
            //        {
            //            if (fgDichVu[i, 1].ToString() == "True")
            //            {
            //                fgDichVu[i, 1] = 1;
            //                fgDichVu[i, 5] = (int)fgDichVu[i, 5] +1;
            //            }
            //            else
            //            {
            //                fgDichVu[i, 1] = 1;
            //                fgDichVu[i, 5] = 1;
            //            }
                        
            //        }
            //    }
            //}

            //if (((string.Compare((string)fgDichVu[e.Row, 2], "C57142") == 0) || (string.Compare((string)fgDichVu[e.Row, 2], "C57143") == 0) || (string.Compare((string)fgDichVu[e.Row, 2], "C57144") == 0) || (string.Compare((string)fgDichVu[e.Row, 2], "C57145") == 0) || (string.Compare((string)fgDichVu[e.Row, 2], "C57146") == 0) || (string.Compare((string)fgDichVu[e.Row, 2], "C57147") == 0) || (string.Compare((string)fgDichVu[e.Row, 2], "C57148") == 0) || (string.Compare((string)fgDichVu[e.Row, 2], "C57149") == 0) || (string.Compare((string)fgDichVu[e.Row, 2], "C57150") == 0) || (string.Compare((string)fgDichVu[e.Row, 2], "C57151") == 0) || (string.Compare((string)fgDichVu[e.Row, 2], "C57152") == 0) || (string.Compare((string)fgDichVu[e.Row, 2], "C57153") == 0) || (string.Compare((string)fgDichVu[e.Row, 2], "C57154") == 0) || (string.Compare((string)fgDichVu[e.Row, 2], "C57155") == 0) || (string.Compare((string)fgDichVu[e.Row, 2], "C57156") == 0) || (string.Compare((string)fgDichVu[e.Row, 2], "C57157") == 0) || (string.Compare((string)fgDichVu[e.Row, 2], "C57158") == 0) || (string.Compare((string)fgDichVu[e.Row, 2], "C57160") == 0)) && (string.Compare(fgDichVu[e.Row, 1].ToString(), "0") == 0) && (1 == e.Col))
            //{
            //    for (int i = 1; i < fgDichVu.Rows.Count; i++) //  
            //    {
            //        if (string.Compare((string)fgDichVu[i, 2], "C57264") == 0) // 64 có can quang
            //        {
            //            if (fgDichVu[i, 1].ToString() == "True")
            //            {
            //                fgDichVu[i, 1] = 1;
            //                fgDichVu[i, 5] = (int)fgDichVu[i, 5] + 1;
            //            }
            //            else
            //            {
            //                fgDichVu[i, 1] = 1;
            //                fgDichVu[i, 5] = 1;
            //            }

            //        }
            //    }
            //}
        }

        private void cmbLoaiKho_TextChanged(object sender, EventArgs e)
        {
            if (cmbLoaiKho.Tag.ToString() == "0") return;
            Load_DMDichVu(txtTenDV.Text.Trim());
        }
    }
}