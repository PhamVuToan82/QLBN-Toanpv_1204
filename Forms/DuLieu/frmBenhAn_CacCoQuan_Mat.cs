using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GlobalModuls;
using System.Data.SqlClient;
namespace NamDinh_QLBN.Forms.DuLieu
{
    public partial class frmBenhAn_CacCoQuan_Mat : Form
    {
        private string _MauBenhAn,_MaVaoVien;
        public frmBenhAn_CacCoQuan_Mat(string MauBenhAn, string MaVaoVien)
        {
            InitializeComponent();
            _MaVaoVien = MaVaoVien;
            MauBenhAn = _MauBenhAn;
            LayThongTin(_MaVaoVien);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlCommand Cmd = new System.Data.SqlClient.SqlCommand("", GlobalModuls.Global.ConnectSQL);
            Cmd.CommandText = string.Format("set dateformat DMY if(exists(select * from BenhAn_ChiTiet where mavaovien='{0}'))"
                                            + " begin update BenhAn_ChiTiet set [BenhAn_CoQuanThanKinh] = N'{1}', [BenhAn_CoQuanTuanHoan] = N'{2}',[BenhAn_CoQuanHoHap]= N'{3}',[BenhAn_CoQuanTieuHoa] = N'{4}',[BenhAn_CoQuanCoXuongKhop] = N'{5}',[BenhAn_ThanTietNieuSinhDuc] = N'{6}',[BenhAn_CoQuanNoiTiet] = N'{7}' ,[BenhAn_CoQuanKhac] = N'{8}' where  mavaovien='{0}' end"
                                            + " else insert into BenhAn_ChiTiet(MaVaoVien,BenhAn_CoQuanThanKinh,BenhAn_CoQuanTuanHoan,BenhAn_CoQuanHoHap,BenhAn_CoQuanTieuHoa,BenhAn_CoQuanCoXuongKhop,BenhAn_ThanTietNieuSinhDuc,BenhAn_CoQuanKhac,BenhAn_CoQuanNoiTiet) "
                                            + " values('{0}',N'{1}',N'{2}',N'{3}',N'{4}',N'{5}',N'{6}',N'{7}',N'{8}')", _MaVaoVien, txtCoQuanThanKinh.Text, txtCoQuanTuanHoan.Text, txtCoQuanHoHap.Text, txtCoQuanTieuHoa.Text, txtCoQuanCoXuongKhop.Text, txtCoQuanThanTietNieuSinhDuc.Text, txtCoQuanNoiTiet.Text, txtCoQuanKhac.Text);
            Cmd.ExecuteNonQuery();


            Cmd.CommandText = string.Format("set dateformat DMY if(exists(select * from BenhAn_ChuyenKhoa where mavaovien='{0}'))"
                                 + " begin update BenhAn_ChuyenKhoa set [MAT_ThiLucMP_KhongKinh] = N'{1}', [MAT_ThiLucMT_KhongKinh] = N'{2}',[MAT_ThiLucMP_CoKinh]= N'{3}',[MAT_NhanApMP] = N'{4}',[MAT_NhanApMT] = N'{5}',[MAT_ThiTruongMP] = N'{6}',[MAT_ThiTruongMT] = N'{7}',[MAT_LeDaoMP] = N'{8}',[MAT_LeDaoMT] = N'{9}',[MAT_MongMatMP] = N'{10}',[MAT_MongMatMT] = N'{11}',[MAT_DTPXMP] = N'{12}',[MAT_DTPXMT] = N'{13}',[MAT_ThuyTinhTheMP] = N'{14}',[MAT_ThuyTinhTheMT] = N'{15}',[MAT_ThuyTinhDichMP] = N'{16}',[MAT_ThuyTinhDichMT] = N'{17}',[MAT_SoiAnhDTMP] = N'{18}',[MAT_SoiAnhDTMT] = N'{19}',[MAT_NhanCauMP] = N'{20}',[MAT_NhanCauMT] = N'{21}',[MAT_HocMatMP] = N'{22}',[MAT_HocMatMT] = N'{23}',[MAT_DayMatMP] = N'{24}',[MAT_DayMatMT] = N'{25}',[Benh_ChuyenKhoa] = N'{26}'," +
                                 "[MAT_ThiLucMT_CoKinh]= N'{27}', [MAT_MiMatMP] = N'{28}', [MAT_MiMatMT]= N'{29}', [MAT_KetMacMP]= N'{30}', [MAT_KetMacMT]= N'{31}', [MAT_MatHotMP]= N'{31}', [MAT_MatHotMT]= N'{33}', [MAT_GiaMacMP]= N'{34}', [MAT_GiaMacMT]= N'{35}', [MAT_CungMacMP]= N'{36}', [MAT_CungMacMT] = N'{37}', [MAT_TienPhongMP] = N'{38}', [MAT_TienPhongMT]= N'{39}'where  mavaovien='{0}' end"
                                 + " else insert into BenhAn_ChuyenKhoa(MaVaoVien,MAT_ThiLucMP_KhongKinh, MAT_ThiLucMT_KhongKinh,MAT_ThiLucMP_CoKinh, MAT_NhanApMP, MAT_NhanApMT, MAT_ThiTruongMP, MAT_ThiTruongMT, MAT_LeDaoMP, MAT_LeDaoMT, MAT_MongMatMP, MAT_MongMatMT, MAT_DTPXMP, MAT_DTPXMT, MAT_ThuyTinhTheMP, MAT_ThuyTinhTheMT, MAT_ThuyTinhDichMP, MAT_ThuyTinhDichMT, MAT_SoiAnhDTMP, MAT_SoiAnhDTMT, MAT_NhanCauMP, MAT_NhanCauMT, MAT_HocMatMP, MAT_HocMatMT, MAT_DayMatMP, MAT_DayMatMT, Benh_ChuyenKhoa,MAT_ThiLucMT_CoKinh," +
                                 "[MAT_MiMatMP], [MAT_MiMatMT], [MAT_KetMacMP], [MAT_KetMacMT], [MAT_MatHotMP], [MAT_MatHotMT], [MAT_GiaMacMP], [MAT_GiaMacMT], [MAT_CungMacMP], [MAT_CungMacMT], [MAT_TienPhongMP], [MAT_TienPhongMT]) "
                                 + " values('{0}',N'{1}',N'{2}',N'{3}',N'{4}',N'{5}',N'{6}',N'{7}',N'{8}',N'{9}',N'{10}',N'{11}',N'{12}',N'{13}',N'{14}',N'{15}',N'{16}',N'{17}',N'{18}',N'{19}',N'{20}',N'{21}',N'{22}',N'{23}',N'{24}',N'{25}',N'{26}',N'{27}',N'{28}',N'{29}',N'{30}',N'{31}',N'{32}',N'{33}',N'{34}',N'{35}',N'{36}',N'{36}',N'{38}',N'{39}')", _MaVaoVien, txthiluckhongkinhMP.Text, txthiluckhongkinhMt.Text, txthiluccokinhMP.Text, txtnhanapMP.Text,txtnhanapMT.Text,txtthitruongMP.Text,txtthitruongMT.Text,txtLeDaoMP.Text,txtLeDaoMT.Text,txtMongMatMP.Text,txtMongMatMT.Text,txtDTPXMP.Text,txtDTPXMT.Text,txtThuyTinhTheMP.Text,txtThuyTinhTheMT.Text,txtThuyTinhDichMP.Text,txtThuyTinhDichMT.Text,txtSoiAnhDTMP.Text,txtSoiAnhDTMT.Text,txtNhanMP.Text,txtNhanMT.Text,txtHocMatMP.Text,txtHocMatMT.Text,txtDayMatMP.Text,txtDayMatMT.Text,txtBenhChuyenKhoa.Text, txthiluccokinhMT.Text
                                 ,txtMiMatMP.Text,txtMiMatMT.Text,txtKetMacMP.Text,txtKetMacMT.Text,txtMatHotMP.Text,txtMatHotMT.Text,txtGiacMacMP.Text,txtGiacMacMT.Text,txtCungMacMP.Text,txtCungMacMT.Text,txtTienPhongMP.Text,txtTienPhongMT.Text);
            Cmd.ExecuteNonQuery();
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void LayThongTin(string MaVaoVien)
        {
            System.Data.SqlClient.SqlCommand Cmd = new System.Data.SqlClient.SqlCommand("", GlobalModuls.Global.ConnectSQL);
            Cmd.CommandText = string.Format("select  BenhAn_CoQuanNoiTiet,BenhAn_CoQuanThanKinh,BenhAn_CoQuanTuanHoan,BenhAn_CoQuanHoHap,BenhAn_CoQuanTieuHoa,BenhAn_CoQuanCoXuongKhop,BenhAn_ThanTietNieuSinhDuc,BenhAn_CoQuanKhac," +
                "MAT_ThiLucMP_KhongKinh, MAT_ThiLucMT_KhongKinh,MAT_ThiLucMP_CoKinh, MAT_NhanApMP, MAT_NhanApMT, MAT_ThiTruongMP, MAT_ThiTruongMT, " +
                "MAT_LeDaoMP, MAT_LeDaoMT, MAT_MongMatMP, MAT_MongMatMT, MAT_DTPXMP, MAT_DTPXMT, MAT_ThuyTinhTheMP, MAT_ThuyTinhTheMT, MAT_ThuyTinhDichMP, " +
                "MAT_ThuyTinhDichMT, MAT_SoiAnhDTMP, MAT_SoiAnhDTMT, MAT_NhanCauMP, MAT_NhanCauMT, MAT_HocMatMP, MAT_HocMatMT, MAT_DayMatMP, MAT_DayMatMT, Benh_ChuyenKhoa,MAT_ThiLucMT_CoKinh, " +
                "MAT_MiMatMP, MAT_MiMatMT, MAT_KetMacMP, MAT_KetMacMT, MAT_MatHotMP, MAT_MatHotMT, MAT_GiaMacMP, MAT_GiaMacMT, MAT_CungMacMP, MAT_CungMacMT, MAT_TienPhongMP, MAT_TienPhongMT "+
                "from BenhAn_ChiTiet A INNER JOIN  BenhAn_ChuyenKhoa B ON A.MAVAOVIEN = B.MAVAOVIEN where a.Mavaovien = '{0}'", MaVaoVien);
            SqlDataReader reader = Cmd.ExecuteReader();
            while (reader.Read())
            {
                txtCoQuanNoiTiet.Text = reader["BenhAn_CoQuanNoiTiet"].ToString();
                txtCoQuanThanKinh.Text = reader["BenhAn_CoQuanThanKinh"].ToString();
                txtCoQuanTuanHoan.Text = reader["BenhAn_CoQuanTuanHoan"].ToString();
                txtCoQuanHoHap.Text = reader["BenhAn_CoQuanHoHap"].ToString();
                txtCoQuanTieuHoa.Text = reader["BenhAn_CoQuanTieuHoa"].ToString();
                txtCoQuanCoXuongKhop.Text = reader["BenhAn_CoQuanCoXuongKhop"].ToString();
                txtCoQuanThanTietNieuSinhDuc.Text = reader["BenhAn_ThanTietNieuSinhDuc"].ToString();
                txtCoQuanKhac.Text = reader["BenhAn_CoQuanKhac"].ToString();
                txthiluckhongkinhMP.Text =  reader["MAT_ThiLucMP_KhongKinh"].ToString();
                txthiluckhongkinhMt.Text = reader["MAT_ThiLucMT_KhongKinh"].ToString();
                txthiluccokinhMP.Text = reader["MAT_ThiLucMP_CoKinh"].ToString();
                txtnhanapMP.Text = reader["MAT_NhanApMP"].ToString();
                txtnhanapMT.Text = reader["MAT_NhanApMT"].ToString();
                txtthitruongMP.Text = reader["MAT_ThiTruongMP"].ToString();
                txtthitruongMT.Text = reader["MAT_ThiTruongMT"].ToString();
                txtLeDaoMP.Text = reader["MAT_LeDaoMP"].ToString();
                txtLeDaoMT.Text = reader["MAT_LeDaoMT"].ToString();
                txtMongMatMP.Text = reader["MAT_MongMatMP"].ToString();
                txtMongMatMT.Text = reader["MAT_MongMatMT"].ToString();
                txtDTPXMP.Text = reader["MAT_DTPXMP"].ToString();
                txtDTPXMT.Text = reader["MAT_DTPXMT"].ToString();
                txtThuyTinhTheMP.Text = reader["MAT_ThuyTinhTheMP"].ToString();
                txtThuyTinhTheMT.Text = reader["MAT_ThuyTinhTheMT"].ToString();
                txtThuyTinhDichMP.Text = reader["MAT_ThuyTinhDichMP"].ToString();
                txtThuyTinhDichMT.Text = reader["MAT_ThuyTinhDichMT"].ToString();
                txtSoiAnhDTMP.Text = reader["MAT_SoiAnhDTMP"].ToString();
                txtSoiAnhDTMT.Text = reader["MAT_SoiAnhDTMT"].ToString();
                txtNhanMP.Text = reader["MAT_NhanCauMP"].ToString();
                txtNhanMT.Text = reader["MAT_NhanCauMT"].ToString();
                txtHocMatMP.Text = reader["MAT_HocMatMP"].ToString();
                txtHocMatMT.Text = reader["MAT_HocMatMT"].ToString();
                txtDayMatMP.Text = reader["MAT_DayMatMP"].ToString();
                txtDayMatMT.Text = reader["MAT_DayMatMT"].ToString();
                txtBenhChuyenKhoa.Text = reader["Benh_ChuyenKhoa"].ToString();
                txthiluccokinhMT.Text = reader["MAT_ThiLucMT_CoKinh"].ToString();
                txtMiMatMP.Text =  reader["MAT_MiMatMP"].ToString(); 
                txtMiMatMT.Text = reader["MAT_MiMatMT"].ToString();
                txtKetMacMP.Text = reader["MAT_KetMacMP"].ToString();
                txtKetMacMT.Text = reader["MAT_KetMacMT"].ToString();
                txtMatHotMP.Text = reader["MAT_MatHotMP"].ToString();
                txtMatHotMT.Text = reader["MAT_MatHotMT"].ToString();
                txtGiacMacMP.Text = reader["MAT_GiaMacMP"].ToString();
                txtGiacMacMT.Text = reader["MAT_GiaMacMT"].ToString();
                txtCungMacMP.Text = reader["MAT_CungMacMP"].ToString();
                txtCungMacMT.Text = reader["MAT_CungMacMT"].ToString();
                txtTienPhongMP.Text = reader["MAT_TienPhongMP"].ToString();
                txtTienPhongMT.Text = reader["MAT_TienPhongMT"].ToString();

            }
            reader.Close();
            Cmd.Dispose();
        }
    }
}
