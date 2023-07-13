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
    public partial class frmChiPhiTheoMatBenh : Form
    {
        public int id_SoTayDonThuoc;
        private C1.Win.C1FlexGrid.C1FlexGrid fgDichVu = null;
        private string DoituongBN = "";
        private string MaKhoa = "";
        private DateTime NgayVV;
        private string TenThuoc = "";
        private string DonViTinh = "", DonGiaCQ = "", MaThuocCanQuang = "", covid;
        public frmChiPhiTheoMatBenh(C1.Win.C1FlexGrid.C1FlexGrid _fg, string _DoiTuongBN, string maKhoa,DateTime _NgayVV,string _covid)
        {
            InitializeComponent();
            fgDichVu = _fg;
            DoituongBN = _DoiTuongBN;
            NgayVV = _NgayVV;
            MaKhoa = maKhoa;
            covid = _covid;
        }

        private void LoatDanhMuc()
        {
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            try
            {
                SQLCmd.CommandText = "SELECT * FROM DMKHOAPHONG WHERE MaKhoa IN " + Global.glbKhoa_CapNhat;
                dr = SQLCmd.ExecuteReader();
                cmbKhoa.Tag = "0";
                cmbKhoa.ClearItems();
                while (dr.Read())
                {
                    cmbKhoa.AddItem(string.Format("{0};{1}", dr["MaKhoa"], dr["TenKhoa"]));
                }
                cmbKhoa.SelectedIndex = 0;
                dr.Close();
                cmbKhoa.Tag = "1";
            }
            catch
            {
            }
            finally
            {
                SQLCmd.Dispose();
            }
        }

        private void Format_Grid()
        {
            fgDichVu.Redraw = false;
            fgDichVu.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.Clear, 0, 0, 0);
            fgDichVu.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.Sum, 0, 2, fgDichVu.Cols["ThanhTien"].Index, "{0}");
            int TT = 1;
            for (int i = 1; i < fgDichVu.Rows.Count; i++)
            {
                if (fgDichVu.Rows[i].IsNode) TT = 1;
                else
                {
                    fgDichVu[i, 0] = TT;
                    TT++;
                }
            }
            fgDichVu.AutoSizeCols();
            fgDichVu.Redraw = true;
            if (fgDichVu.Rows.Count <= 1) return;
            fgDichVu.Row = fgDichVu.Rows.Count - 1;
        }

        private void LoatMatBenh()
        {
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            try
            {
                if (raThuoc.Checked)
                {
                    SQLCmd.CommandText = String.Format("Select * from tblSoTayDonThuoc where makhoa ='{0}'", Global.GetCode(cmbKhoa));
                }
                else
                {
                    SQLCmd.CommandText = String.Format("Select id_sotaydichvu as id_SoTayDonThuoc,matbenh from tblSoTayDichVu where makhoa ='{0}'", Global.GetCode(cmbKhoa));
                }
                dr = SQLCmd.ExecuteReader();
                //if (Global.GetCode(cmbMatBenh) != null)
                //{
                //    cmbMatBenh.ClearItems();
                //}
                cmbMatBenh.ClearItems();
                while (dr.Read())
                {
                    cmbMatBenh.AddItem(String.Format("{0};{1}", dr["id_SoTayDonThuoc"], dr["MatBenh"]));
                }
                cmbMatBenh.SelectedIndex = -1;
                dr.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                SQLCmd.Dispose();
            }
        }

        private void LoatChiPhiMatBenh()
        {
            C1.Win.C1FlexGrid.CellStyle cs = fg.Styles[C1.Win.C1FlexGrid.CellStyleEnum.Subtotal0];
            cs.BackColor = Color.LightBlue;
            cs.ForeColor = Color.DarkBlue;
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            try
            {
                fg.Redraw = false;
                String Str = "";
                if (NgayVV < DateTime.Parse("01/01/2020"))
                {
                    if (DoituongBN == "1")
                    {
                        Str = ",isnull(dmdichvu.DonGiaBHYT,0) as DG";
                    }
                    else if (DoituongBN == "3")
                    {
                        Str = ",isnull(dmdichvu.GiaVienPhi01010220,0) as DG";
                    }
                    else if (DoituongBN == "4")
                    {
                        Str = ",isnull(dmdichvu.Dongiatunguyen,0) as DG";
                    }
                }
                else
                {
                    if (DoituongBN == "1")
                    {
                        Str = ",isnull(dmdichvu.DonGiaBHYT,0) as DG";
                    }
                    else if (DoituongBN == "3")
                    {
                        Str = ",isnull(dmdichvu.DonGia,0) as DG";
                    }
                    else if (DoituongBN == "4")
                    {
                        Str = ",isnull(dmdichvu.Dongiatunguyen,0) as DG";
                    }
                }
                if (Global.GetCode(cmbMatBenh) == null)
                {
                    return;
                }
                id_SoTayDonThuoc = int.Parse(Global.GetCode(cmbMatBenh));
                fg.Tree.Column = fg.Cols["TenDichVu"].Index;
                if (raThuoc.Checked)
                {
                    SQLCmd.CommandText = String.Format("Select  distinct dmloaidichvu.MaLoaiDichVu,TenLoaiDichvu,dmDichVu.MaDichvu,dmDichVu.TenDichvu,dmDichVu.DVT,convert(int,aa.SoLuong) as soluong,dmdichvu.TyLe" + Str + ",dmDichVu.KhoID, dmDichVu.Is_tinhphi,dmDichVu.TyleBHYT as TyleBH,dmDichVu.MaThuocCanQuang,dmDichVu.ThongTinThau,dmDichVu.DonGia as GiaVP, dmDichVu.DonGiaBHYT as GiaBHYT from "// toan sua
                    + " (Select * from tblSoTayDonThuoc_CT where id_sotaydonthuoc = {0}) aa"
                    + " inner join DMLENCHIPHI_BYKHOID dmDichVu on dmDichVu.madichvu = aa.mathuoc  and dmDichVu.khongsudung = 0 "
                    + " inner join dmloaidichvu on dmloaidichvu.maloaidichvu = dmDichVu.loaidichvu", Global.GetCode(cmbMatBenh), GlobalModuls.Global.gblNoiNgoai);
                }
                else
                {
                    SQLCmd.CommandText = String.Format("Select distinct dmloaidichvu.MaLoaiDichVu,TenLoaiDichvu,dmDichVu.MaDichvu,dmDichVu.TenDichvu,dmDichVu.DVT,convert(int,aa.SoLuong) as soluong,dmdichvu.TyLe" + Str + ",dmDichVu.KhoID, dmDichVu.Is_tinhphi,dmDichVu.TyleBHYT as TyleBH,dmDichVu.MaThuocCanQuang,dmDichVu.ThongTinThau,dmDichVu.DonGia as GiaVP, dmDichVu.DonGiaBHYT as GiaBHYT from "
                    + " (Select * from tblSoTayDichvu_CT where id_sotaydichvu = {0}) aa"
                    + " inner join DMLENCHIPHI_BYKHOID dmDichVu on dmdichvu.madichvu = aa.madichvu  and dmDichVu.khongsudung = 0 and (dmDichVu.MaThuocCanQuang is null or dmDichVu.MaThuocCanQuang = '')"
                    + " inner join dmloaidichvu on dmloaidichvu.maloaidichvu = dmdichvu.loaidichvu"
                    + " where DBO.SearchDoiTuong({1},dmdichvu.DOITUONG) = 1", Global.GetCode(cmbMatBenh), DoituongBN);
                }
                
                dr = SQLCmd.ExecuteReader();
                fg.Rows.Count = 1;
                fg.ClipSeparators = "|;";
                while (dr.Read())
                {
                    fg.AddItem(String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}|{12}|{13}|{14}|{15}|{16}|", fg.Rows.Count,
                        dr["MaLoaiDichVu"],
                        dr["TenLoaiDichVu"],
                        dr["madichvu"],
                        1,
                        dr["tendichvu"],
                        dr["dvt"],
                        dr["soluong"],
                        dr["dg"],
                        dr["TyLe"],
                        dr["KhoID"],
                        dr["Is_tinhphi"],
                        dr["TyleBH"],
                        dr["MaThuocCanQuang"], dr["ThongTinThau"], dr["GiaVP"], dr["GiaBHYT"]));
                }
                dr.Close();
                fg.Redraw = true;
                fg.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.Clear, 0, 0, 0);
                fg.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.None, 0, fg.Cols["TenLoaiDichVu"].Index, 0, "{0}");
                fg.AutoSizeCols(0);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                SQLCmd.Dispose();
            }
        }

        private void cmdHuy_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void cmdGhi_Click(object sender, EventArgs e)
        {
            for (int i = 1; i < fg.Rows.Count; i++)
            {
                if (fg.GetCellCheck(i, fg.Cols["Chon"].Index) == C1.Win.C1FlexGrid.CheckEnum.Checked)
                {
                    string MaLoaiDichVu = fg[i, "MaLoaiDichVu"].ToString();
                    string TenLoaiDichVu = fg[i, "TenLoaiDichVu"].ToString();
                    string MaCP = fg[i,"MaDichVu"].ToString();
                    string TenCP = fg[i, "TenDichVu"].ToString();
                    string DVTinh = fg[i, "DVT"].ToString();
                    string KhoID = fg[i, "KhoID"].ToString();
                    int SoLuong = int.Parse(fg[i, "SoLuong"].ToString());
                    float DonGia = float.Parse(fg[i, "DonGia"].ToString());
                    decimal GiaVP = decimal.Parse(fg[i, "GiaVP"].ToString());
                    decimal GiaBHYT = decimal.Parse(fg[i, "GiaBHYT"].ToString());
                    float TyLe = float.Parse(fg[i, "TyLe"].ToString());
                    int Is_tinhphi = int.Parse(fg[i, fg.Cols["Is_tinhphi"].Index].ToString());
                    bool DaCoCP = false;
                    string TyleBH = fg[i, "TyleBH"].ToString();
                    string MaThuocCanQuang = fg[i, "MaThuocCanQuang"].ToString();
                    string ThongTinThau = fg[i, "ThongTinThau"].ToString();
                    System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
                    SQLCmd.CommandText = "select ThuocID,TenThuoc,DonViTinh,DonGia,DonGiaBHYT,DonGiaDV from NAMDINH_DUOC.dbo.DanhMucThuoc WHERE ThuocID = '" + MaThuocCanQuang + "'";
                    System.Data.SqlClient.SqlDataReader dr = SQLCmd.ExecuteReader();
                    while (dr.Read())
                    {
                        TenThuoc = dr["TenThuoc"].ToString();
                        DonViTinh = dr["DonViTinh"].ToString();
                        if (DoituongBN == "1")
                        {
                            DonGiaCQ = dr["DonGiaBHYT"].ToString();
                        }
                        else
                        {
                            DonGiaCQ = dr["DonGiaDV"].ToString();
                        }
                    }
                    dr.Close();
                    for (int j = 1; j < fgDichVu.Rows.Count; j++)
                    {
                        if (!fgDichVu.Rows[j].IsNode && fgDichVu[j, "MaDichVu"].ToString() == MaCP)
                        {
                            DaCoCP = true;
                            break;
                        }
                    }
                    if (!DaCoCP)
                    {
                        if (covid == "1")
                        {
                            this.fgDichVu.AddItem(string.Format("|{0}|{1}|{2}|{3}|{4}|{5:#,##0.##}|{6:#,##0.##}|{7}|{8:#,##0.##}|{9}|{12}|0||{10}|{11}|||||||||||{15}|{14}|||||||{16}|{17}|", new object[]
                            { MaLoaiDichVu,
                          TenLoaiDichVu,
                          MaCP,
                          TenCP,
                          DVTinh,
                          SoLuong,
                          DonGia,
                          TyLe,
                          SoLuong * DonGia * TyLe / 100,
                          "",
                          0, KhoID, 1 - Is_tinhphi, MaThuocCanQuang, TyleBH, ThongTinThau,GiaVP,GiaBHYT }));
                        }
                         else
                        {
                          fgDichVu.AddItem(string.Format("|{0}|{1}|{2}|{3}|{4}|{5:#,##0.##}|{6:#,##0.##}|{7}|{8:#,##0.##}|{9}|{12}|0||{10}|{11}|||||||||||{15}|{14}|",
                          MaLoaiDichVu,
                          TenLoaiDichVu,
                          MaCP,
                          TenCP,
                          DVTinh,
                          SoLuong,
                          DonGia,
                          TyLe,
                          SoLuong* DonGia *TyLe / 100,
                          "",
                          0, KhoID, 1 - Is_tinhphi, MaThuocCanQuang, TyleBH,ThongTinThau));
                         }
                    }
                    
                }

            }
            Format_Grid();
        }

        private void frmChiPhiTheoMatBenh_Load(object sender, EventArgs e)
        {
            fg.Tag = 0;
            cmbKhoa.Tag = 0;
            cmbMatBenh.Tag = 0;
            LoatDanhMuc();
            LoatMatBenh();
            cmbMatBenh.Tag = 1;
            cmbKhoa.Tag = 1;
            fg.Tag = 1; 
            LoatChiPhiMatBenh();
        }

        private void cmbKhoa_TextChanged(object sender, EventArgs e)
        {
            if (cmbKhoa.Tag.ToString() == "0") return;
            cmbKhoa.Tag = 0;
            LoatMatBenh();
            cmbKhoa.Tag = 1;
        }

        private void cmbMatBenh_TextChanged(object sender, EventArgs e)
        {
            if (cmbMatBenh.Tag.ToString() == "0") return;
            LoatChiPhiMatBenh();
        }

        private void frmChiPhiTheoMatBenh_KeyDown(object sender, KeyEventArgs e)
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

        private void raThuoc_CheckedChanged(object sender, EventArgs e)
        {
            fg.Tag = 0;
            cmbMatBenh.Tag = 0;
            LoatMatBenh();
            LoatChiPhiMatBenh();
            fg.Tag = 1;
            cmbMatBenh.Tag = 1;
        }

        private void raXetNghiem_CheckedChanged(object sender, EventArgs e)
        {
            //fg.Tag = 0;
            //cmbMatBenh.Tag = 0;
            //LoatMatBenh();
            //LoatChiPhiMatBenh();
            //fg.Tag = 1;
            //cmbMatBenh.Tag = 1;
        }
    }
}