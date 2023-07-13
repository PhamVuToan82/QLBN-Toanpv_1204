using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
namespace NamDinh_QLBN.Forms.DuLieu
{
    class ketnoi
    {
        public static string stringcon = "Data Source=172.16.2.3;Initial Catalog=NAMDINH_QLBN;User ID=Admin_HIS;Password=vcntt@2020";
        public static string stringcon_1 = "Data Source=172.16.2.3;Initial Catalog=ImagesDB_Data;User ID=Admin_HIS;Password=vcntt@2020";
        DataTable dt;
        SqlDataAdapter da;
        SqlCommand cmd;
        // DataSet ds;
        SqlConnection con;
        SqlConnection con1;
        public SqlConnection open()
        {
            con = new SqlConnection(stringcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            con1 = new SqlConnection(stringcon_1);
            if (con1.State == ConnectionState.Closed)
                con1.Open();
            return con;
        }

        public SqlConnection close()
        {
            con = new SqlConnection(stringcon);
            if (con.State == ConnectionState.Open)
                con.Close();
            con1 = new SqlConnection(stringcon_1);
            if (con1.State == ConnectionState.Open)
                con1.Close();
            return con;
        }
        public DataTable select_proc(string ten_proc)
        {
            open();
            dt = new DataTable();
            cmd = new SqlCommand(ten_proc, con);
            cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            close();
            return dt;
        }

        public SqlCommand sp_update(string MaVaoVien, string LanChuyenDT, string NgayChuyen, string DoiTuong, string SoThe, string maDoiTuongBHXH, string MaNoiCap, string TenNoiCap,string GtriTu, string GtriDen, string TenBHYTCap, string Tuyen)
        {
            open();
            cmd = new SqlCommand("sp_update", con);
            cmd.Parameters.Add("@MaVaoVien", SqlDbType.NVarChar).Value = MaVaoVien;
            cmd.Parameters.Add("@LanChuyenDT", SqlDbType.TinyInt).Value = LanChuyenDT;
            cmd.Parameters.Add("@NgayChuyen", SqlDbType.SmallDateTime).Value = NgayChuyen;
            cmd.Parameters.Add("@DoiTuong", SqlDbType.NVarChar).Value = DoiTuong;
            cmd.Parameters.Add("@SoThe", SqlDbType.NVarChar).Value = SoThe;
            cmd.Parameters.Add("@maDoiTuongBHXH", SqlDbType.NVarChar).Value = maDoiTuongBHXH;
            cmd.Parameters.Add("@MaNoiCap", SqlDbType.NVarChar).Value = MaNoiCap;
            cmd.Parameters.Add("@TenNoiCap", SqlDbType.NVarChar).Value = TenNoiCap;
            cmd.Parameters.Add("@GtriTu", SqlDbType.DateTime).Value = GtriTu ;
            cmd.Parameters.Add("@GtriDen", SqlDbType.DateTime).Value = GtriDen;
            cmd.Parameters.Add("@TenBHYTCap", SqlDbType.NVarChar).Value = TenBHYTCap;
            cmd.Parameters.Add("@Tuyen", SqlDbType.NVarChar).Value = Tuyen;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            close();
            return cmd;
        }

        public DataTable sp_timkiem(string MaVaoVien, string Uname)
        {
            dt = new DataTable();
            open();
            cmd = new SqlCommand("sp_timkiem", con);
            cmd.Parameters.Add("@MaVaoVien", SqlDbType.NVarChar).Value = MaVaoVien;
            cmd.Parameters.Add("@Uname", SqlDbType.NVarChar).Value = Uname;
            cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            close();
            return dt;
        }

        public DataTable sp_timkiem_all(string MaVaoVien)
        {
            dt = new DataTable();
            open();
            cmd = new SqlCommand("sp_timkiem_all", con);
            cmd.Parameters.Add("@MaVaoVien", SqlDbType.NVarChar).Value = MaVaoVien;
         //   cmd.Parameters.Add("@Uname", SqlDbType.NVarChar).Value = Uname;
            cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            close();
            return dt;
        }

        public DataTable sp_1(string Uname)
        {
            dt = new DataTable();
            open();
            cmd = new SqlCommand("sp_1", con);
            cmd.Parameters.Add("@Uname", SqlDbType.NVarChar).Value = Uname;
            cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            close();
            return dt;
        }

        public DataTable sp_log_mac()
        {
            dt = new DataTable();
            open();
            cmd = new SqlCommand("sp_log_mac", con);
        //    cmd.Parameters.Add("@Uname", SqlDbType.NVarChar).Value = Uname;
            cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            close();
            return dt;
        }

        public DataTable sp_2(string Uname)
        {
            dt = new DataTable();
            open();
            cmd = new SqlCommand("sp_2", con);
            cmd.Parameters.Add("@Uname", SqlDbType.NVarChar).Value = Uname;
            cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            close();
            return dt;
        }
        public DataTable sp_3(string Uname, DateTime  TuNgay, DateTime DenNgay)
        {
            dt = new DataTable();
            open();
            cmd = new SqlCommand("sp_3", con);
            cmd.Parameters.Add("@Uname", SqlDbType.NVarChar).Value = Uname;
            cmd.Parameters.Add("@TuNgay", SqlDbType.DateTime).Value = TuNgay;
            cmd.Parameters.Add("@DenNgay", SqlDbType.DateTime).Value = DenNgay;
            cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            close();
            return dt;
        }
        public SqlCommand sp_chuyendoituong_benhnhan(string MaVaoVien)
        {
            open();
            cmd = new SqlCommand("sp_chuyendoituong_benhnhan", con);
            cmd.Parameters.Add("@MaVaoVien", SqlDbType.NVarChar).Value = MaVaoVien;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            close();
            return cmd;
        }


        public DataTable fill_sp_chuyendoituong_dichvu(string MaVaoVien)
        {
           // open();
           // cmd = new SqlCommand("fill_sp_chuyendoituong_dichvu", con);
           // cmd.Parameters.Add("@mavaovien", SqlDbType.NVarChar).Value = MaVaoVien;
           ////// cmd.Parameters.Add("@tt37", SqlDbType.NVarChar).Value = tt37;
           //// cmd.CommandType = CommandType.StoredProcedure;
           //// cmd.ExecuteNonQuery();
           //// close();
           //// return dt;
            dt = new DataTable();
            open();
            cmd = new SqlCommand("fill_sp_chuyendoituong_dichvu", con);
            cmd.Parameters.Add("@mavaovien", SqlDbType.NVarChar).Value = MaVaoVien;
            cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            close();
            return dt;
        }

        public DataTable delete_fill_sp_chuyendoituong_dichvu(string sophieu,string madichvu)
        {
            // open();
            // cmd = new SqlCommand("fill_sp_chuyendoituong_dichvu", con);
            // cmd.Parameters.Add("@mavaovien", SqlDbType.NVarChar).Value = MaVaoVien;
            ////// cmd.Parameters.Add("@tt37", SqlDbType.NVarChar).Value = tt37;
            //// cmd.CommandType = CommandType.StoredProcedure;
            //// cmd.ExecuteNonQuery();
            //// close();
            //// return dt;
            dt = new DataTable();
            open();
            cmd = new SqlCommand("delete_fill_sp_chuyendoituong_dichvu", con);
            cmd.Parameters.Add("@sophieu", SqlDbType.NVarChar).Value = sophieu;
            cmd.Parameters.Add("@madichvu", SqlDbType.NVarChar).Value = madichvu;
            cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            close();
            return dt;
        }
        public DataTable sp_update_1(string manoicap)
        {
            SqlConnection conn;
            string stringconn = "Data Source=172.16.2.3;Initial Catalog=NAMDINH_QLBN;User ID=Admin_HIS;Password=vcntt@2020";
            conn = new SqlConnection(stringconn);
            dt = new DataTable();
            cmd = new SqlCommand("sp_update_1", conn);
            cmd.Parameters.Add("@manoicap", SqlDbType.NVarChar).Value = manoicap;
            cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        public SqlCommand sp_xoa_khambenh(string MaVaoVien)
        {
            open();
            cmd = new SqlCommand("sp_xoa_khambenh", con);
            cmd.Parameters.Add("@MaVaoVien", SqlDbType.NVarChar).Value = MaVaoVien;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            close();
            return cmd;
        }

        public DataTable sp_log(string Uname)
        {
            dt = new DataTable();
            open();
            cmd = new SqlCommand("sp_log", con);
            cmd.Parameters.Add("@Uname", SqlDbType.NVarChar).Value = Uname;
            cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            close();
            return dt;
        }
        public DataTable sp_log_khambenh(string Uname)
        {
            dt = new DataTable();
            open();
            cmd = new SqlCommand("sp_log_khambenh", con);
            cmd.Parameters.Add("@Uname", SqlDbType.NVarChar).Value = Uname;
            cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            close();
            return dt;
        }
        public DataTable Spd_select_benhnhan(string mavaovien)
        {
            dt = new DataTable();
            open();
            cmd = new SqlCommand("Spd_select_benhnhan", con1);
            cmd.Parameters.Add("@mavaovien", SqlDbType.NVarChar).Value = mavaovien;
            cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            close();
            return dt;
        }

        public DataTable danhsach_benhnhan(string Uname)
        {
            dt = new DataTable();
            open();
            cmd = new SqlCommand("danhsach_benhnhan", con1);
            cmd.Parameters.Add("@Uname", SqlDbType.NVarChar).Value = Uname;
            cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            close();
            return dt;
        }

        public DataTable danhsach_benhnhan_ketqua(string mavaovien)
        {
            dt = new DataTable();
            open();
            cmd = new SqlCommand("danhsach_benhnhan_ketqua", con1);
            cmd.Parameters.Add("@mavaovien", SqlDbType.NVarChar).Value = mavaovien;
            cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            close();
            return dt;
        }

        public DataTable danhsach_benhnhan_ketqua_hh(string mavaovien)
        {
            dt = new DataTable();
            open();
            cmd = new SqlCommand("danhsach_benhnhan_ketqua_hh", con1);
            cmd.Parameters.Add("@mavaovien", SqlDbType.NVarChar).Value = mavaovien;
            cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            close();
            return dt;
        }


        public DataTable img_benhnhan(string makhambenh)
        {
            dt = new DataTable();
            open();
            cmd = new SqlCommand("img_benhnhan", con1);
            cmd.Parameters.Add("@makhambenh", SqlDbType.NVarChar).Value = makhambenh;
            //   cmd.Parameters.Add("@mabenhnhan", SqlDbType.NVarChar).Value = mabenhnhan;
            cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            close();
            return dt;
        }

        public DataTable xoa_anh(string ImageId)
        {
            dt = new DataTable();
            open();
            cmd = new SqlCommand("xoa_anh", con1);
            cmd.Parameters.Add("@ImageId", SqlDbType.NVarChar).Value = ImageId;
            //   cmd.Parameters.Add("@mabenhnhan", SqlDbType.NVarChar).Value = mabenhnhan;
            cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            close();
            return dt;
        }

        public DataTable mabenhnhan()
        {
            dt = new DataTable();
            open();
            cmd = new SqlCommand("mabenhnhan", con1);
           // cmd.Parameters.Add("@ImageId", SqlDbType.NVarChar).Value = ImageId;
            //   cmd.Parameters.Add("@mabenhnhan", SqlDbType.NVarChar).Value = mabenhnhan;
            cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            close();
            return dt;
        }

        public DataTable danhsach_benhnhan_gb_khoa(string tungay, string denngay, string uname)
        {
            dt = new DataTable();
            open();
            cmd = new SqlCommand("danhsach_benhnhan_gb_khoa", con1);
            cmd.Parameters.Add("@tungay", SqlDbType.NVarChar).Value = tungay;
            cmd.Parameters.Add("@denngay", SqlDbType.NVarChar).Value = denngay;
             cmd.Parameters.Add("@uname", SqlDbType.NVarChar).Value = uname;
            cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            close();
            return dt;
        }

        public DataTable danhsach_benhnhan_gb_khoa_color( string uname)
        {
            dt = new DataTable();
            open();
            cmd = new SqlCommand("danhsach_benhnhan_gb_khoa_color", con1);
            cmd.Parameters.Add("@uname", SqlDbType.NVarChar).Value = uname;
            cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            close();
            return dt;
        }
        public DataTable sp_delete_BENHNHAN(string makhambenh)
        {
      
            dt = new DataTable();
            cmd = new SqlCommand("sp_delete_BENHNHAN", con1);
            cmd.Parameters.Add("@makhambenh", SqlDbType.NVarChar).Value = makhambenh;
            cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        public DataTable bc_gb_khoacc(string tungay, string denngay)
        {
            dt = new DataTable();
            open();
            cmd = new SqlCommand("bc_gb_khoacc", con1);
            cmd.Parameters.Add("@tungay", SqlDbType.NVarChar).Value = tungay;
            cmd.Parameters.Add("@denngay", SqlDbType.NVarChar).Value = denngay;
            cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            close();
            return dt;
        }
        public DataTable bc_gb_phongkhamcc(string tungay, string denngay)
        {
            dt = new DataTable();
            open();
            cmd = new SqlCommand("bc_gb_phongkhamcc", con1);
            cmd.Parameters.Add("@tungay", SqlDbType.NVarChar).Value = tungay;
            cmd.Parameters.Add("@denngay", SqlDbType.NVarChar).Value = denngay;
            cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            close();
            return dt;
        }

        public DataTable Spd_add_capcuu(string ngaygiaoban, string bscapcuu, string bschanthuong
            , string khamcapcu, string tongso)
        {
            dt = new DataTable();
            open();
            cmd = new SqlCommand("Spd_add_capcuu", con1);
            cmd.Parameters.Add("@ngaygiaoban", SqlDbType.NVarChar).Value = ngaygiaoban;
            cmd.Parameters.Add("@bscapcuu", SqlDbType.NVarChar).Value = bscapcuu;
            cmd.Parameters.Add("@bschanthuong", SqlDbType.NVarChar).Value = bschanthuong;
            cmd.Parameters.Add("@khamcapcuu", SqlDbType.NVarChar).Value = khamcapcu;
            cmd.Parameters.Add("@tongso", SqlDbType.NVarChar).Value = tongso;
           
            cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            close();
            return dt;
        }

        public DataTable Spd_update_capcuu(string ngaygiaoban, string bscapcuu, string bschanthuong, 
            string khamcapcu, string tongso)
        {
            dt = new DataTable();
            open();
            cmd = new SqlCommand("Spd_update_capcuu", con1);
            cmd.Parameters.Add("@ngaygiaoban", SqlDbType.NVarChar).Value = ngaygiaoban;
            cmd.Parameters.Add("@bscapcuu", SqlDbType.NVarChar).Value = bscapcuu;
            cmd.Parameters.Add("@bschanthuong", SqlDbType.NVarChar).Value = bschanthuong;
            cmd.Parameters.Add("@khamcapcuu", SqlDbType.NVarChar).Value = khamcapcu;
            cmd.Parameters.Add("@tongso", SqlDbType.NVarChar).Value = tongso;
            cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            close();
            return dt;
        }

        public DataTable Spd_update_capcuu_1(string khamcapcu, string tongso)
        {
            dt = new DataTable();
            open();
            cmd = new SqlCommand("Spd_update_capcuu_1", con1);
            cmd.Parameters.Add("@khamcapcuu", SqlDbType.NVarChar).Value = khamcapcu;
            cmd.Parameters.Add("@tongso", SqlDbType.NVarChar).Value = tongso;
            cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            close();
            return dt;
        }
        public DataTable sp_chuyendichvu_vienphi(string mavaovien, string madichvu, string madichvu_moi)
        {
            dt = new DataTable();
            open();
            cmd = new SqlCommand("sp_chuyendichvu_vienphi", con);
            cmd.Parameters.Add("@madichvu", SqlDbType.NVarChar).Value = madichvu;
            cmd.Parameters.Add("@mavaovien", SqlDbType.NVarChar).Value = mavaovien;
            cmd.Parameters.Add("@madichvu_moi", SqlDbType.NVarChar).Value = madichvu_moi;
 //           cmd.Parameters.Add("@dongia_moi", SqlDbType.NVarChar).Value = dongia_moi;
            cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            close();
            return dt;
        }
        public DataTable select_sp_chuyen_dichvu(string loaidichvu)
        {
            dt = new DataTable();
            open();
            cmd = new SqlCommand("select_sp_chuyen_dichvu", con);
            cmd.Parameters.Add("@loaidichvu", SqlDbType.NVarChar).Value = loaidichvu;
            cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            close();
            return dt;
        }
        public DataTable sp_madichvu(string MaDichvu)
        {
            dt = new DataTable();
            open();
            cmd = new SqlCommand("sp_madichvu", con);
            cmd.Parameters.Add("@MaDichvu", SqlDbType.NVarChar).Value = @MaDichvu;
            cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            close();
            return dt;
        }

        public DataTable sp_vatuchuthanhtoan(string Uname)
        {
            dt = new DataTable();
            open();
            cmd = new SqlCommand("sp_vatuchuthanhtoan", con);
            cmd.Parameters.Add("@Uname", SqlDbType.NVarChar).Value = Uname;
            cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            close();
            return dt;
        }
        public DataTable sp_vatu_daravien(string Uname, string tungay, string denngay)
        {
            dt = new DataTable();
            open();
            cmd = new SqlCommand("[sp_vatu_daravien]", con);
            cmd.Parameters.Add("@Uname", SqlDbType.NVarChar).Value = Uname;
            cmd.Parameters.Add("@tungay", SqlDbType.NVarChar).Value = tungay;
            cmd.Parameters.Add("@denngay", SqlDbType.NVarChar).Value = denngay;
            cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            close();
            return dt;
        }

        public DataTable sp_insert_doituong(string MaVaoVien, string LanChuyenDT, string NgayChuyen, string DoiTuong, string SoThe, string maDoiTuongBHXH, string MaNoiCap, string TenNoiCap, string GtriTu, string GtriDen, string TenBHYTCap, string Tuyen, string CapCuu)
        {
            DataTable dt = new DataTable();
            open();
            cmd = new SqlCommand("sp_insert_doituong", con);
            cmd.Parameters.Add("@MaVaoVien", SqlDbType.NVarChar).Value = MaVaoVien;
            cmd.Parameters.Add("@LanChuyenDT", SqlDbType.TinyInt).Value = LanChuyenDT;
            cmd.Parameters.Add("@NgayChuyen", SqlDbType.SmallDateTime).Value = NgayChuyen;
            cmd.Parameters.Add("@DoiTuong", SqlDbType.NVarChar).Value = DoiTuong;
            cmd.Parameters.Add("@SoThe", SqlDbType.NVarChar).Value = SoThe;
            cmd.Parameters.Add("@maDoiTuongBHXH", SqlDbType.NVarChar).Value = maDoiTuongBHXH;
            cmd.Parameters.Add("@MaNoiCap", SqlDbType.NVarChar).Value = MaNoiCap;
            cmd.Parameters.Add("@TenNoiCap", SqlDbType.NVarChar).Value = TenNoiCap;
            cmd.Parameters.Add("@GtriTu", SqlDbType.DateTime).Value = GtriTu;
            cmd.Parameters.Add("@GtriDen", SqlDbType.DateTime).Value = GtriDen;
            cmd.Parameters.Add("@TenBHYTCap", SqlDbType.NVarChar).Value = TenBHYTCap;
            cmd.Parameters.Add("@Tuyen", SqlDbType.NVarChar).Value = Tuyen;
            cmd.Parameters.Add("@CapCuu", SqlDbType.NVarChar).Value = CapCuu;
            cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
        public DataTable sp_update_chuyendt(string MaVaoVien,string LanChuyenDT,string NgayChuyen, string DoiTuong, string SoThe, string maDoiTuongBHXH, string MaNoiCap, string TenNoiCap, string GtriTu, string GtriDen, string TenBHYTCap, string Tuyen, string CapCuu)
        {
            DataTable dt = new DataTable();
            open();
            cmd = new SqlCommand("sp_update_chuyendt", con);
            cmd.Parameters.Add("@MaVaoVien", SqlDbType.NVarChar).Value = MaVaoVien;
            cmd.Parameters.Add("@lanchuyendt", SqlDbType.TinyInt).Value = LanChuyenDT;
            cmd.Parameters.Add("@NgayChuyen", SqlDbType.SmallDateTime).Value = NgayChuyen;
            cmd.Parameters.Add("@DoiTuong", SqlDbType.NVarChar).Value = DoiTuong;
            cmd.Parameters.Add("@SoThe", SqlDbType.NVarChar).Value = SoThe;
            cmd.Parameters.Add("@maDoiTuongBHXH", SqlDbType.NVarChar).Value = maDoiTuongBHXH;
            cmd.Parameters.Add("@MaNoiCap", SqlDbType.NVarChar).Value = MaNoiCap;
            cmd.Parameters.Add("@TenNoiCap", SqlDbType.NVarChar).Value = TenNoiCap;
            cmd.Parameters.Add("@GtriTu", SqlDbType.DateTime).Value = GtriTu;
            cmd.Parameters.Add("@GtriDen", SqlDbType.DateTime).Value = GtriDen;
            cmd.Parameters.Add("@TenBHYTCap", SqlDbType.NVarChar).Value = TenBHYTCap;
            cmd.Parameters.Add("@Tuyen", SqlDbType.NVarChar).Value = Tuyen;
            cmd.Parameters.Add("@CapCuu", SqlDbType.NVarChar).Value = CapCuu;
            cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        public DataTable sp_chuyendoituong_benhnhan_vienphi(string mavaovien, string doituongbn, string lanchuyendt)
        {
            dt = new DataTable();
            open();
            cmd = new SqlCommand("sp_chuyendoituong_benhnhan_vienphi", con);
            cmd.Parameters.Add("@mavaovien", SqlDbType.NVarChar).Value = mavaovien;
            cmd.Parameters.Add("@doituongbn", SqlDbType.NVarChar).Value = doituongbn;
            cmd.Parameters.Add("@lanchuyendt", SqlDbType.NVarChar).Value = lanchuyendt;
            //cmd.Parameters.Add("@ngaychuyen", SqlDbType.NVarChar).Value = ngaychuyen;
 //           cmd.Parameters.Add("@dongia", SqlDbType.NVarChar).Value = dongia;
            cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            close();
            return dt;
        }
        public DataTable sp_chuyendoituong_benhnhan_bhyt(string mavaovien, string doituongbn, string lanchuyendt)
        {
            dt = new DataTable();
            open();
            cmd = new SqlCommand("sp_chuyendoituong_benhnhan_bhyt", con);
            cmd.Parameters.Add("@mavaovien", SqlDbType.NVarChar).Value = mavaovien;
            cmd.Parameters.Add("@doituongbn", SqlDbType.NVarChar).Value = doituongbn;
            cmd.Parameters.Add("@lanchuyendt", SqlDbType.NVarChar).Value = lanchuyendt;
            //cmd.Parameters.Add("@ngaychuyen", SqlDbType.NVarChar).Value = ngaychuyen;
//            cmd.Parameters.Add("@dongia", SqlDbType.NVarChar).Value = dongia;
            cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            close();
            return dt;
        }
        public SqlCommand sp_chuyendoituong_benhnhan_giathang3(string MaVaoVien)
        {
            open();
            cmd = new SqlCommand("sp_chuyendoituong_benhnhan_giathang3", con);
            cmd.Parameters.Add("@MaVaoVien", SqlDbType.NVarChar).Value = MaVaoVien;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            close();
            return cmd;
        }
        public DataTable sp_chuyendoituong_benhnhan_bhyt_giathang3(string mavaovien, string doituongbn, string lanchuyendt)
        {
            dt = new DataTable();
            open();
            cmd = new SqlCommand("sp_chuyendoituong_benhnhan_bhyt_giathang3", con);
            cmd.Parameters.Add("@mavaovien", SqlDbType.NVarChar).Value = mavaovien;
            cmd.Parameters.Add("@doituongbn", SqlDbType.NVarChar).Value = doituongbn;
            cmd.Parameters.Add("@lanchuyendt", SqlDbType.NVarChar).Value = lanchuyendt;
           // cmd.Parameters.Add("@ngaychuyen", SqlDbType.NVarChar).Value = ngaychuyen;
            //            cmd.Parameters.Add("@dongia", SqlDbType.NVarChar).Value = dongia;
            cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            close();
            return dt;
        }

        public DataTable sp_chuyendoituong_benhnhan_vienphi_giathang3(string mavaovien, string doituongbn, string lanchuyendt)
        {
            dt = new DataTable();
            open();
            cmd = new SqlCommand("sp_chuyendoituong_benhnhan_vienphi_giathang3", con);
            cmd.Parameters.Add("@mavaovien", SqlDbType.NVarChar).Value = mavaovien;
            cmd.Parameters.Add("@doituongbn", SqlDbType.NVarChar).Value = doituongbn;
            cmd.Parameters.Add("@lanchuyendt", SqlDbType.NVarChar).Value = lanchuyendt;
            //cmd.Parameters.Add("@ngaychuyen", SqlDbType.NVarChar).Value = ngaychuyen;
            //            cmd.Parameters.Add("@dongia", SqlDbType.NVarChar).Value = dongia;
            cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            close();
            return dt;
        }

        public DataTable Sp_cdt_BHYT_truoc(string mavaovien, string doituongbn, string lanchuyendt, string ngaychuyen)
        {
            dt = new DataTable();
            open();
            cmd = new SqlCommand("Sp_cdt_BHYT_truoc", con);
            cmd.Parameters.Add("@mavaovien", SqlDbType.NVarChar).Value = mavaovien;
            cmd.Parameters.Add("@doituongbn", SqlDbType.NVarChar).Value = doituongbn;
            cmd.Parameters.Add("@lanchuyendt", SqlDbType.NVarChar).Value = lanchuyendt;
            cmd.Parameters.Add("@ngaychuyen", SqlDbType.NVarChar).Value = ngaychuyen;
            cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            close();
            return dt;
        }
        public DataTable Sp_cdt_BHYT_truoc_15072018(string mavaovien, string doituongbn, string lanchuyendt, string ngaychuyen)
        {
            dt = new DataTable();
            open();
            cmd = new SqlCommand("Sp_cdt_BHYT_truoc", con);
            cmd.Parameters.Add("@mavaovien", SqlDbType.NVarChar).Value = mavaovien;
            cmd.Parameters.Add("@doituongbn", SqlDbType.NVarChar).Value = doituongbn;
            cmd.Parameters.Add("@lanchuyendt", SqlDbType.NVarChar).Value = lanchuyendt;
            cmd.Parameters.Add("@ngaychuyen", SqlDbType.NVarChar).Value = ngaychuyen;
            cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            close();
            return dt;
        }
        public DataTable Sp_cdt_vienphi_sau(string mavaovien, string doituongbn, string lanchuyendt, string ngaychuyen)
        {
            dt = new DataTable();
            open();
            cmd = new SqlCommand("Sp_cdt_vienphi_sau", con);
            cmd.Parameters.Add("@mavaovien", SqlDbType.NVarChar).Value = mavaovien;
            cmd.Parameters.Add("@doituongbn", SqlDbType.NVarChar).Value = doituongbn;
            cmd.Parameters.Add("@lanchuyendt", SqlDbType.NVarChar).Value = lanchuyendt;
            cmd.Parameters.Add("@ngaychuyen", SqlDbType.NVarChar).Value = ngaychuyen;
            cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            close();
            return dt;
        }
        public DataTable Sp_cdt_vienphi_sau_0112(string mavaovien, string doituongbn, string lanchuyendt, string ngaychuyen)
        {
            dt = new DataTable();
            open();
            cmd = new SqlCommand("Sp_cdt_vienphi_sau_0112", con);
            cmd.Parameters.Add("@mavaovien", SqlDbType.NVarChar).Value = mavaovien;
            cmd.Parameters.Add("@doituongbn", SqlDbType.NVarChar).Value = doituongbn;
            cmd.Parameters.Add("@lanchuyendt", SqlDbType.NVarChar).Value = lanchuyendt;
            cmd.Parameters.Add("@ngaychuyen", SqlDbType.NVarChar).Value = ngaychuyen;
            cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            close();
            return dt;
        }

    }



}
