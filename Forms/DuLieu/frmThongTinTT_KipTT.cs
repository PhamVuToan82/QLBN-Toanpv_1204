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
    public partial class frmThongTinTT_KipTT : Form
    {
        private string _MaVaoVien = "";
        private string _SophieuCD = "";
        private string _LoaiDichvu = "";
        private string _MaDichvu = "";
        private string _NgayChiDinh = "";
        private string _MA_BHXH = "";
        public frmThongTinTT_KipTT(String MaVaoVien, String SophieuCD, String LoaiDichvu, String MaDichvu,string NgayChiDinh)
        {
            InitializeComponent();
            _MaVaoVien = MaVaoVien;
            _SophieuCD = SophieuCD;
            _LoaiDichvu = LoaiDichvu;
            _MaDichvu = MaDichvu;
            _NgayChiDinh = NgayChiDinh;
        }
        private void Load_CacDM()
        {
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            SQLCmd.CommandText = "SELECT * FROM DMKHOAPHONG";
            dr = SQLCmd.ExecuteReader();
            System.Collections.Hashtable KhoaMap = new System.Collections.Hashtable();
            while (dr.Read())
            {
                KhoaMap.Add(dr["maKhoa"], dr["TenKhoa"]);
            }
            dr.Close();
            fgKipMo.Cols["Khoa"].DataMap = KhoaMap;
            SQLCmd.CommandText = "SELECT MaBS+MaKhoa As MaBS,Tentat as TenBS FROM DMBACSY";
            dr = SQLCmd.ExecuteReader();
            System.Collections.Hashtable BacSyMap = new System.Collections.Hashtable();
            while (dr.Read())
            {
                BacSyMap.Add(dr["MaBS"], dr["tenBS"]);
            }
            fgKipMo.Cols["TenBacSy"].DataMap = BacSyMap;
            dr.Close();
            SQLCmd.CommandText = "SELECT * FROM DMVOCAM";
            dr = SQLCmd.ExecuteReader();
            cmbVoCam.ClearItems();
            while (dr.Read())
            {
                cmbVoCam.AddItem(string.Format("{0};{1}", dr["MaVoCam"], dr["TenVoCam"]));
            }
            dr.Close();
            SQLCmd.CommandText = "SELECT * FROM DMLOAIPHAUTHUAT where left(maloaiPT,1) = '5'";
            dr = SQLCmd.ExecuteReader();
            while (dr.Read())
            {
                cmbLoai.AddItem(string.Format("{0};{1}", dr["MaLoaiPT"], dr["TenLoaiPT"]));
            }
            cmbLoai.SelectedIndex = -1;
            dr.Close();
            SQLCmd.Dispose();
        }
        private void cmdThoat_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }

        private void LoadData()
        {
            System.Data.SqlClient.SqlCommand Cmd = new System.Data.SqlClient.SqlCommand("", GlobalModuls.Global.ConnectSQL);
            System.Data.SqlClient.SqlDataReader dr;
            try
            {
                //txtNgayMo.Value = GlobalModuls.Global.GetNgayLV();
                Cmd.CommandText = "Select * from THONGTIN_THUTHUAT where mavaovien='" + _MaVaoVien + "' and MaphieuCD='" + _SophieuCD + "' and Madichvu='" + _MaDichvu + "'";
                dr = Cmd.ExecuteReader();
                while (dr.Read())
                {
                    //txtBenhLy.Text = dr["QuaTrinhBL"].ToString();
                    //txtChuanBi.Text = dr["ChuanBi"].ToString();
                    //txtDuTruMau.Text = dr["DuTruMau"].ToString();
                    //txtKhoKhan.Text = dr["KhoKhan"].ToString();
                    txtNguoiGayMe.Text = dr["GayMe"].ToString();
                    txtNguoiPhụ.Text = dr["NguoiPhu"].ToString();
                    txtNguoiThucHien.Text = dr["NguoiThucHien"].ToString();
                    txtPhuongPhapDK.Text = dr["PhuongPhapDK"].ToString();
                    txtVoCam.Text = dr["VoCam"].ToString();
                    txtLanMo.Text = dr["LanMo"].ToString();
                    txtNgayMo.Value = dr["NgayMo"].ToString() == "" ? GlobalModuls.Global.NgayLV : dr["NgayMo"];
                    txKetthuc.Value = dr["KetThuc"].ToString() == "" ? GlobalModuls.Global.NgayLV : dr["KetThuc"];
                    txtSoTienThu.Value = dr["SoTien"].ToString() == "" ? 0 : dr["SoTien"];
                    txtSoBL.Text = dr["SoBienlai"].ToString();
                    txtLanhDao.Text = dr["LanhDaoDuyet"].ToString();
                    //txtLoai.Text = dr["LoaiPT"].ToString();
                    Global.SetCmb_Display(cmbLoai, dr["LoaiPT"].ToString());
                    txtTPKhac.Text = dr["TPKhac"].ToString();
                }
                dr.Close();
                
                if (string.Compare(cmbLoai.Text, "") == 0)
                {
                    Cmd.CommandText = string.Format("Select MaLoaiPT,TenLoaiPT from DMPHAUTHUAT a left join DMLOAIPHAUTHUAT b on a.Loaiphauthuat = b.MaLoaiPT WHERE a.MaDichVu='{0}' AND a.LoaiDichvu='{1}' ", _MaDichvu, _LoaiDichvu);
                    dr = Cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        //txtLoai.Text = dr["TenLoaiPT"].ToString();
                        Global.SetCmb_Display(cmbLoai, dr["TenLoaiPT"].ToString());
                    }
                    dr.Close();
                }
                Cmd.CommandText = string.Format("SELECT MaBS+MaKhoa As MaBS1,* FROM BENHNHAN_PT_KIPMO a INNER JOIN DMVITRI_PT b ON a.Vitri=b.MaVT WHERE MaVaoVien={0} AND SoPhieuCD='{1}' AND LoaiDichVu='{2}' AND MaPT='{3}' ORDER BY SoTTBS", _MaVaoVien, _SophieuCD, _LoaiDichvu, _MaDichvu);
                dr = Cmd.ExecuteReader();
                while (dr.Read())
                {
                    fgKipMo.AddItem(string.Format("{0}|{1}|{2}|{3}|{4}|{5}", dr["soTTBS"], dr["maBS1"], dr["MaKhoa"], dr["TenVT"], dr["ViTri"], dr["MA_BHXH"]));
                }
                dr.Close();

            }
            catch
            {
            }
            finally
            {
            }
        }

        private void cmdGhi_Click(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlCommand Cmd = new System.Data.SqlClient.SqlCommand("", GlobalModuls.Global.ConnectSQL);
            try
            {
                string Mochinh = "";
                string Phumo = "";
                string Gaymechinh = "";
                string Phugayme = "";
                string Giupviec = "";
                string Gayme = ""; // = Gaymechinh + Phugayme

                int SL_Mochinh = 0;
                int SL_Phumo = 0;
                int SL_Gaymechinh = 0;
                int SL_Phugayme = 0;
                int SL_Giupviec = 0;
                string NGAYMO = string.Format("{0:dd/MM/yyyy HH:ss}",  txtNgayMo.Text);
                string KETTHUC = string.Format("{0:dd/MM/yyyy HH:ss}", txKetthuc.Text);
                string NgayChiDinh = string.Format("{0:dd/MM/yyyy HH:ss}", _NgayChiDinh);
                if(cmbLoai.SelectedIndex < 0)
                {
                    MessageBox.Show("Dịch vụ này không phải thủ thuật"); this.Close(); 
                }
                if(txtNgayMo.Text == "")
                {
                    MessageBox.Show("Thời gian bắt đầu không được để trống");
                    return;
                    
                }
                if (txKetthuc.Text == "")
                {
                    MessageBox.Show("thời gian kết thúc không được để trống");
                    return;
                }
                if ( DateTime.Compare(DateTime.Parse(NGAYMO), DateTime.Parse(KETTHUC)) >=0 || DateTime.Compare(DateTime.Parse(NGAYMO), DateTime.Parse(NgayChiDinh)) <= 0)
                {
                    MessageBox.Show("Ngày chỉ định <= Thời gian bắt đầu <= thời gian kết thúc");
                    return;
                }
                //đoạn này kiểm tra tính hợp lệ kíp mổ
                if (fgKipMo.Rows.Count > 1)
                {
                    for (int i = 1; i < fgKipMo.Rows.Count; i++)
                    {
                        if (fgKipMo.GetDataDisplay(i, 3) == "Mổ chính")
                        {
                            SL_Mochinh = SL_Mochinh + 1;
                        }
                        if (fgKipMo.GetDataDisplay(i, 3) == "Phụ mổ")
                        {
                            SL_Phumo = SL_Phumo + 1;
                        }
                        if (fgKipMo.GetDataDisplay(i, 3) == "Gây mê chính")
                        {
                            SL_Gaymechinh = SL_Gaymechinh + 1;
                        }
                        if (fgKipMo.GetDataDisplay(i, 3) == "Phụ gây mê")
                        {
                            SL_Phugayme = SL_Phugayme + 1;
                        }
                        if (fgKipMo.GetDataDisplay(i, 3) == "Giúp việc")
                        {
                            SL_Giupviec = SL_Giupviec + 1;
                        }

                    }
                    if (SL_Mochinh != 1 || SL_Phumo > 2 || SL_Gaymechinh > 1 || SL_Phugayme > 0 || SL_Giupviec > 1)
                    {
                        MessageBox.Show("Số lượng người tham gia kíp thủ thuật chưa đúng.\n\nThủ thuật viên chính: bắt buộc phải nhập, chỉ được nhập 1 người.\nPhụ: ≤ 2 người khác nhau\nGây mê chính: ≤ 1 người.\nGiúp việc: ≤ 1 người.\n\nĐề nghị nhập lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Phải nhập kíp thủ thuật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //------------------------------------
                if (fgKipMo.Rows.Count > 1)
                {
                    for (int i = 1; i < fgKipMo.Rows.Count; i++)
                    {
                        if (fgKipMo.GetDataDisplay(i, 3) == "Mổ chính")
                        {
                            Mochinh = Mochinh + fgKipMo.GetDataDisplay(i, 1) + ", ";
                        }
                        if (fgKipMo.GetDataDisplay(i, 3) == "Phụ mổ")
                        {
                            Phumo = Phumo + fgKipMo.GetDataDisplay(i, 1) + ", ";
                        }
                        if (fgKipMo.GetDataDisplay(i, 3) == "Gây mê chính")
                        {
                            Gaymechinh = Gaymechinh + fgKipMo.GetDataDisplay(i, 1) + ", ";
                        }
                        if (fgKipMo.GetDataDisplay(i, 3) == "Phụ gây mê")
                        {
                            Phugayme = Phugayme + fgKipMo.GetDataDisplay(i, 1) + ", ";
                        }
                        if (fgKipMo.GetDataDisplay(i, 3) == "Giúp việc")
                        {
                            Giupviec = Giupviec + fgKipMo.GetDataDisplay(i, 1) + ", ";
                        }

                    }
                    //if (Mochinh != "")
                    //{
                    //    Mochinh = "Mổ chính: " + Mochinh.Substring(0, Mochinh.Length - 2);
                    //}
                    //if (Phumo != "")
                    //{
                    //    Phumo = "Phụ mổ: " + Phumo.Substring(0, Phumo.Length - 2);
                    //}
                    //if (Gaymechinh != "")
                    //{
                    //    Gaymechinh = "Gây mê chính: " + Gaymechinh.Substring(0, Gaymechinh.Length - 2);
                    //}
                    //if (Phugayme != "")
                    //{
                    //    Phugayme = "Phụ gây mê: " + Phugayme.Substring(0, Phugayme.Length - 2);
                    //}
                    //if (Giupviec != "")
                    //{
                    //    Giupviec = "Giúp việc: " + Giupviec.Substring(0, Giupviec.Length - 2);
                    //}
                    if (Mochinh != "")
                    {
                        Mochinh = Mochinh.Substring(0, Mochinh.Length - 2);
                    }
                    if (Phumo != "")
                    {
                        Phumo = Phumo.Substring(0, Phumo.Length - 2);
                    }
                    if (Gaymechinh != "")
                    {
                        Gaymechinh = Gaymechinh.Substring(0, Gaymechinh.Length - 2);
                        Gayme = Gayme + Gaymechinh;
                    }
                    if (Phugayme != "")
                    {
                        Phugayme = Phugayme.Substring(0, Phugayme.Length - 2);
                        if (Gayme != "")
                        {
                            Gayme = Gayme + ", " + Phugayme;
                        }
                        else
                        {
                            Gayme = Gayme + Phugayme;
                        }

                    }
                    if (Giupviec != "")
                    {
                        Giupviec = Giupviec.Substring(0, Giupviec.Length - 2);
                    }

                }
                Cmd.CommandText = String.Format("set dateformat mdy if(exists(select * from THONGTIN_THUTHUAT where mavaovien ='{0}' and MaPhieuCD = '{13}'  and Madichvu = '{14}'))"
                    + " begin"
                    + " update THONGTIN_THUTHUAT set PhuongPhapDK=N'{1}',NguoiThucHien=N'{2}',NguoiPhu=N'{3}',"
                    + " VoCam=N'{4}',GayMe=N'{5}',LanMo=N'{6}',NgayMo='{7:MM/dd/yyyy HH:mm}'"
                    + " ,SoTien={8},SoBienlai=N'{9}',LanhDaoDuyet=N'{10}',LoaiPT=N'{11}',TPKhac = N'{12}', KhoaTH = N'{15}',KetThuc =  N'{16:MM/dd/yyyy HH:mm}' where mavaovien='{0}' and MaPhieuCD = '{13}'  and Madichvu = '{14}'"
                    + " end"
                    + " else"
                    + " begin"
                    + " insert into THONGTIN_THUTHUAT(mavaovien, phuongphapDK,nguoithuchien,NguoiPhu, VoCam,GayMe, LanMo,"
                    + " NgayMo,SoTien,SoBienLai,LanhDaoDuyet,LoaiPT,TPKhac,MaPhieuCD,Madichvu, KhoaTH,KetThuc)"
                    + " values('{0}',N'{1}',N'{2}',N'{3}',N'{4}',N'{5}',N'{6}','{7:MM/dd/yyyy HH:mm}'"
                    + " ,{8},N'{9}',N'{10}',N'{11}',N'{12}',N'{13}',N'{14}',N'{15}',N'{16:MM/dd/yyyy HH:mm}')"
                    + " end", _MaVaoVien, txtPhuongPhapDK.Text.Trim(), Mochinh, Phumo,
                    txtVoCam.Text.Trim(), Gaymechinh, txtLanMo.Text.Trim(),
                    txtNgayMo.Value, txtSoTienThu.Value.ToString().Replace(",", "."), txtSoBL.Text.Trim(), txtLanhDao.Text.Trim(), cmbLoai.Text.Trim(), Giupviec, _SophieuCD,  _MaDichvu, GlobalModuls.Global.glbMaKhoaPhong,txKetthuc.Value);
                Cmd.ExecuteNonQuery();
                //Thêm vao bảng BENHNHAN_PT_KIPMO
                Cmd.CommandText = string.Format("DELETE FROM BENHNHAN_PT_KIPMO WHERE MaVaoVien='{0}' AND SoPhieuCD='{1}' AND LoaiDichVu='{2}' AND MaPT='{3}'", _MaVaoVien, _SophieuCD, _LoaiDichvu, _MaDichvu);
                Cmd.ExecuteNonQuery();
                int SoTT_BS = 1;
                string StrSQL = "";
                for (int i = 1; i < fgKipMo.Rows.Count; i++)
                {
                    if (fgKipMo.GetDataDisplay(i, 1) != "" && fgKipMo.GetDataDisplay(i, 2) != "")
                    {
                        StrSQL = string.Format("INSERT INTO BENHNHAN_PT_KIPMO (MaVaoVien,SoPhieuCD,LoaiDichVu,MaPT,SoTTBS,MaBS,ViTri,MaKhoa,MA_BHXH) VALUES ('{0}','{1}','{2}','{3}',{4},N'{5}',{6},'{7}','{8}')",
                            _MaVaoVien,
                            _SophieuCD, _LoaiDichvu, _MaDichvu,
                            SoTT_BS,
                            fgKipMo.GetData(i, "TenBacSy").ToString().Substring(0, 2),
                            fgKipMo.GetData(i, "MaVT"),
                            fgKipMo.GetData(i, "Khoa"),
                            fgKipMo.GetData(i, "MA_BHXH")); 
                        Cmd.CommandText = StrSQL;
                        Cmd.ExecuteNonQuery();
                        SoTT_BS += 1;
                    }
                }
                this.DialogResult = DialogResult.Yes;
            }
            catch(Exception ex)
            {
                this.DialogResult = DialogResult.No;
                MessageBox.Show(ex.ToString());
            }
            finally
            {
            }
        }

        private void frmThongTinMo_Load(object sender, EventArgs e)
        {
            fgKipMo.ClipSeparators = "|;";
            Load_CacDM();
            LoadData();
        }

        private void fgKipMo_DoubleClick(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.DuLieu.frmCapNhatKipMo fr = new frmCapNhatKipMo(fgKipMo, "0");
            fr.ShowDialog();
        }
    }
}