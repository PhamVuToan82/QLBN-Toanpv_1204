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
    public partial class frmThongTinMo_Kipmo : Form
    {
        private string _MaVaoVien = "";
        private string _SophieuCD = "";
        private string _LoaiDichvu = "";
        private string _MaDichvu = "";
        private string _MaKhoa = "";
        public frmThongTinMo_Kipmo(String MaVaoVien, String SophieuCD, String LoaiDichvu, String MaDichvu, String MaKhoa)
        {
            InitializeComponent();
            _MaVaoVien = MaVaoVien;
            _SophieuCD = SophieuCD;
            _LoaiDichvu = LoaiDichvu;
            _MaDichvu = MaDichvu;
            _MaKhoa = MaKhoa;
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
            SQLCmd.CommandText = "SELECT * FROM DMLOAIPHAUTHUAT where maloaiPT not in ('12','13','22','23')";
            dr = SQLCmd.ExecuteReader();
            while (dr.Read())
            {
                cmbLoai.AddItem(string.Format("{0};{1}", dr["MaLoaiPT"], dr["TenLoaiPT"]));
            }
            dr.Close();
            SQLCmd.Dispose();
            cmbLoai.SelectedIndex = -1;
        }
        private void cmdThoat_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }

        private void LoadData()
        {
            System.Data.SqlClient.SqlCommand Cmd = new System.Data.SqlClient.SqlCommand("", GlobalModuls.Global.ConnectSQL);
            System.Data.SqlClient.SqlDataReader dr;
            cmbVoCam.SelectedIndex = -1;
            fgKipMo.Rows.Count = 1;
            try
            {
                Cmd.CommandText = "Select * from thongtin_phauthuat where mavaovien='" + _MaVaoVien + "'";
                dr = Cmd.ExecuteReader();
                cmbLoai.SelectedValue = "";
                while (dr.Read())
                {
                    txtBenhLy.Text = dr["QuaTrinhBL"].ToString();
                    txtChuanBi.Text = dr["ChuanBi"].ToString();
                    txtDuTruMau.Text = dr["DuTruMau"].ToString();
                    txtKhoKhan.Text = dr["KhoKhan"].ToString();
                    txtNguoiGayMe.Text = dr["GayMe"].ToString();
                    txtNguoiPhụ.Text = dr["NguoiPhu"].ToString();
                    txtNguoiThucHien.Text = dr["NguoiThucHien"].ToString();
                    txtPhuongPhapDK.Text = dr["PhuongPhapDK"].ToString();
                    txtVoCam.Text = dr["VoCam"].ToString();
                    txtLanMo.Text = dr["LanMo"].ToString();
                    txtNgayMo.Value = dr["NgayMo"].ToString() == "" ? GlobalModuls.Global.NgayLV : dr["NgayMo"];
                    txtSoTienThu.Value = dr["SoTien"].ToString() == "" ? 0 : dr["SoTien"];
                    txtSoBL.Text = dr["SoBienlai"].ToString();
                    txtLanhDao.Text = dr["LanhDaoDuyet"].ToString();
                    //txtLoai.Text = dr["LoaiPT"].ToString();
                    Global.SetCmb_Display(cmbLoai, dr["LoaiPT"].ToString());
                    txtTPKhac.Text = dr["TPKhac"].ToString();
                }
                dr.Close();
                Cmd.CommandText = string.Format("Select PPVoCam from BENHNHAN_PHAUTHUAT WHERE MaVaoVien='{0}' AND SoPhieuCD='{1}' AND LoaiDichVu='{2}' AND MaPT='{3}'", _MaVaoVien, _SophieuCD, _LoaiDichvu, _MaDichvu);
                dr = Cmd.ExecuteReader();
                while (dr.Read())
                {
                    Global.SetCmb(cmbVoCam, dr["PPVoCam"].ToString());
                }
                dr.Close();
                //if (string.Compare(cmbLoai.Text, "") == 0)
                if (cmbLoai.SelectedValue == null)
                {
                    Cmd.CommandText = string.Format("Select MaLoaiPT,TenLoaiPT from DMPHAUTHUAT a left join DMLOAIPHAUTHUAT b on a.Loaiphauthuat = b.MaLoaiPT WHERE a.MaDichVu='{0}' AND a.LoaiDichvu='{1}' ", _MaDichvu,  _LoaiDichvu );
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
                    fgKipMo.AddItem(string.Format("{0}|{1}|{2}|{3}|{4}", dr["soTTBS"], dr["maBS1"], dr["MaKhoa"], dr["TenVT"], dr["ViTri"]));
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
                if (txtNgayMo.ValueIsDbNull)
                {
                    MessageBox.Show("Phải nhập ngày làm phẫu thuật.");
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
                            SL_Phugayme = SL_Phugayme+1;
                        }
                        if (fgKipMo.GetDataDisplay(i, 3) == "Giúp việc")
                        {
                            SL_Giupviec = SL_Giupviec + 1;
                        }

                    }
                    if(_MaKhoa== "NV1103")
                    {
                        if (SL_Mochinh < 1 || SL_Mochinh > 2 || SL_Phumo > 4 || SL_Gaymechinh != 1 || SL_Phugayme > 2 || SL_Giupviec > 1)
                        {
                            MessageBox.Show("Số lượng người tham gia kíp mổ chưa đúng.\nĐề nghị nhập lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else
                    {
                        if (SL_Mochinh < 1 || SL_Mochinh > 2 || SL_Phumo > 4 || SL_Phugayme > 2 || SL_Giupviec > 1)
                        {
                            MessageBox.Show("Số lượng người tham gia kíp mổ chưa đúng.\nĐề nghị nhập lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                    }
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
                        Mochinh =   Mochinh.Substring(0, Mochinh.Length - 2);
                    }
                    if (Phumo != "")
                    {
                        Phumo =   Phumo.Substring(0, Phumo.Length - 2);
                    }
                    if (Gaymechinh != "")
                    {
                        Gaymechinh =   Gaymechinh.Substring(0, Gaymechinh.Length - 2);
                        Gayme = Gayme + Gaymechinh;
                    }
                    if (Phugayme != "")
                    {
                        Phugayme =   Phugayme.Substring(0, Phugayme.Length - 2);
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
                        Giupviec =  Giupviec.Substring(0, Giupviec.Length - 2);
                    }
                    
                }
                Cmd.CommandText = String.Format("set dateformat mdy if(exists(select * from thongtin_phauthuat where mavaovien ='{0}'))"
                    + " begin"
                    + " update thongtin_phauthuat set QuaTrinhBL=N'{1}',PhuongPhapDK=N'{2}',NguoiThucHien=N'{3}',NguoiPhu=N'{4}',ChuanBi=N'{5}',"
                    + " VoCam=N'{6}',GayMe=N'{7}',DuTruMau=N'{8}',KhoKhan=N'{9}',LanMo=N'{10}',NgayMo='{11:MM/dd/yyyy HH:mm}'"
                    + " ,SoTien={12},SoBienlai=N'{13}',LanhDaoDuyet=N'{14}',LoaiPT=N'{15}',TPKhac = N'{16}',PhuGayMe = N'{17}' where mavaovien='{0}'"
                    + " end"
                    + " else"
                    + " begin"
                    + " insert into thongtin_phauthuat(mavaovien,quatrinhbl,phuongphapDK,nguoithuchien,NguoiPhu,ChuanBi,VoCam,GayMe,DuTruMau,KhoKhan,LanMo,"
                    + " NgayMo,SoTien,SoBienLai,LanhDaoDuyet,LoaiPT,TPKhac,PhuGayMe)"
                    + " values('{0}',N'{1}',N'{2}',N'{3}',N'{4}',N'{5}',N'{6}',N'{7}',N'{8}',N'{9}',N'{10}','{11:MM/dd/yyyy HH:mm}'"
                    + " ,{12},N'{13}',N'{14}',N'{15}',N'{16}',N'{17}')"
                    + " end", _MaVaoVien, txtBenhLy.Text.Trim(), txtPhuongPhapDK.Text.Trim(), Mochinh, Phumo,
                    txtChuanBi.Text.Trim(), cmbVoCam.Text.Trim(), Gaymechinh, txtDuTruMau.Text.Trim(), txtKhoKhan.Text.Trim(),txtLanMo.Text.Trim(),
                    txtNgayMo.Value,txtSoTienThu.Value.ToString().Replace(",","."),txtSoBL.Text.Trim(),txtLanhDao.Text.Trim(),cmbLoai.Text.Trim(),Giupviec, Phugayme);
                Cmd.ExecuteNonQuery();
                //Thêm vao bảng BENHNHAN_PHAUTHUAT
                //Cmd.CommandText = string.Format("DELETE FROM BENHNHAN_PHAUTHUAT WHERE MaVaoVien='{0}' AND SoPhieuCD='{1}' AND LoaiDichVu='{2}' AND MaPT='{3}'", _MaVaoVien, _SophieuCD, _LoaiDichvu, _MaDichvu);
                //Cmd.ExecuteNonQuery();
                Cmd.CommandText = string.Format("set dateformat mdy if(exists(select * FROM BENHNHAN_PHAUTHUAT WHERE MaVaoVien='{0}' AND SoPhieuCD='{3}' AND LoaiDichVu='{2}' AND MaPT='{1}')) "
                        + " begin"
                        + " Update BENHNHAN_PHAUTHUAT set PPVocam = {4}  WHERE MaVaoVien='{0}' AND SoPhieuCD='{3}' AND LoaiDichVu='{2}' AND MaPT='{1}'"
                        + " end"
                        + " else"
                        + " begin"
                        + " INSERT INTO BENHNHAN_PHAUTHUAT (MaVaoVien,MaPT, LoaiDichVu,SoPhieuCD, PPVocam ) "
                        + " VALUES ('{0}','{1}', '{2}','{3}',{4} )" 
                        + " end",
                        _MaVaoVien,
                        _MaDichvu,
                        _LoaiDichvu,
                        _SophieuCD, 
                        (cmbVoCam.SelectedIndex == -1) ? ("Null") : ("'" + Global.GetCode(cmbVoCam) + "'"));
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
                        StrSQL = string.Format("INSERT INTO BENHNHAN_PT_KIPMO (MaVaoVien,SoPhieuCD,LoaiDichVu,MaPT,SoTTBS,MaBS,ViTri,MaKhoa) VALUES ('{0}','{1}','{2}','{3}',{4},N'{5}',{6},'{7}')",
                            _MaVaoVien,
                            _SophieuCD, _LoaiDichvu, _MaDichvu,
                            SoTT_BS,
                            fgKipMo.GetData(i, "TenBacSy").ToString().Substring(0, 2),
                            fgKipMo.GetData(i, "MaVT"),
                            fgKipMo.GetData(i, "Khoa"));
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

        private void frmThongTinMo_Kipmo_Load(object sender, EventArgs e)
        {
            fgKipMo.ClipSeparators = "|;";
            Load_CacDM();
            LoadData();
        }

        private void fgKipMo_DoubleClick(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
            System.Data.SqlClient.SqlTransaction trn = Global.ConnectSQL.BeginTransaction();
            SQLCmd.Transaction = trn;
            string SoPhieu = _SophieuCD;
            string LoaiDichVu = _LoaiDichvu;
            string MaPT = _MaDichvu;
            SQLCmd.CommandText = string.Format("Select MaVaoVien FROM BENHNHAN_PT_CHIPHI WHERE MaVaoVien='{0}' AND SoPhieuCD='{1}' AND LoaiDichVu='{2}' AND MaPT='{3}'", _MaVaoVien, SoPhieu, LoaiDichVu, MaPT);
            System.Data.SqlClient.SqlDataReader dr = SQLCmd.ExecuteReader();
            if (dr.HasRows)
            {
                MessageBox.Show("Đã nhập chi phí trong mổ.\nKhông cho phép sửa ca kíp phẫu thuật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dr.Close();
                trn.Commit();
                return;
            }
            dr.Close();
            SQLCmd.Dispose();
            trn.Commit();
            NamDinh_QLBN.Forms.DuLieu.frmCapNhatKipMo fr = new frmCapNhatKipMo(fgKipMo, "0");
            fr.ShowDialog();
        }
    }
}