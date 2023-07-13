using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using System.Data;
using GlobalModuls;

namespace NamDinh_QLBN.Reports.PhauThuat
{
    /// <summary>
    /// Summary description for repPhieuPT_TT.
    /// </summary>
    public partial class repPhieuPT_TT : DataDynamics.ActiveReports.ActiveReport3
    {
        private String _SoPhieu,_MaVaoVien,_LoaiDichVu,_MaPT;
        public repPhieuPT_TT(String SoPhieu,String MaVaoVien,String LoaiDichVu,string MaPT)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            _SoPhieu = SoPhieu;
            _MaVaoVien = MaVaoVien;
            _LoaiDichVu = LoaiDichVu;
            _MaPT = MaPT;
            lblbNgayTN.Text = String.Format("Ngày {0:dd} tháng {0:MM} năm {0:yyyy}", GlobalModuls.Global.GetNgayLV());
        }

        private void repPhieuPT_TT_DataInitialize(object sender, EventArgs e)
        {
            DataDynamics.ActiveReports.DataSources.SqlDBDataSource _ds = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();

            _ds.ConnectionString = GlobalModuls.Global.glbConnectionString;

            _ds.SQL = String.Format("SELECT "
                + " B.MAVAOVIEN,A.HOTEN,YEAR(GETDATE()) - ISNULL(A.NAMSINH,0) AS TUOI,N'Số HSBA: ' + ISNULL(B.SOHSBA,'') AS SOHSBA,"
                + " CASE WHEN A.GIOITINH = 0 THEN N'Nữ' ELSE N'Nam' END AS GIOITINH,"
                + " DMKHOAPHONG.TENKHOA,DMBUONGBENH.TENBUONG,DMGIUONGBENH.TENGIUONG,"
                + " KHOA.NGAYCHUYEN AS NGAYVAOVIEN,E.THOIGIANBD AS THOIGIANPT,"
                + " E.CHANDOAN_TRUOCPT,E.CHANDOAN_SAUPT,E.PHUONGPHAPPT_TEXT,"
                + " DMLOAIPHAUTHUAT.TENLOAIPT,DMVOCAM.TENVOCAM,E.KQGIAIPHAUBENH AS DANLUU,E.THOIGIANRUTDANLUU,E.THOIGIANCATCHI,E.MOTAKT,"
                + " C.SOPHIEU AS SoPhieuCD,E.LOAIDICHVU,E.MAPT,E.TrinhTuPT "
                + " FROM"
                + " (BENHNHAN A INNER JOIN BENHNHAN_CHITIET B ON A.MABENHNHAN  = B.MABENHNHAN)"
                + " INNER JOIN BENHNHAN_PHIEUDIEUTRI C ON C.MAVAOVIEN = B.MAVAOVIEN"
                + " INNER JOIN PHIEUDIEUTRI_CHITIET D ON D.SOPHIEU = C.SOPHIEU"
                + " INNER JOIN BENHNHAN_PHAUTHUAT E ON E.MAVAOVIEN = B.MAVAOVIEN AND E.SOPHIEUCD = C.SOPHIEU AND D.LOAIDICHVU = E.LOAIDICHVU"
                + " 	AND E.MAPT = D.MADICHVU"
                + " INNER JOIN DMDICHVU ON DMDICHVU.MADICHVU = E.MAPT AND DMDICHVU.LOAIDICHVU = E.LOAIDICHVU"
                + " INNER JOIN BENHNHAN_KHOA KHOA ON KHOA.MAVAOVIEN = B.MAVAOVIEN AND KHOA.LANCHUYENKHOA = 0"
                + " LEFT JOIN DMBUONGBENH ON DMBUONGBENH.MAKHOA = C.MAKHOA AND DMBUONGBENH.ID_BUONG = B.BUONG"
                + " LEFT JOIN DMGIUONGBENH ON DMGIUONGBENH.MAKHOA = C.MAKHOA AND DMGIUONGBENH.ID_BUONG = B.BUONG AND DMGIUONGBENH.ID_GIUONG = B.GIUONG"
                + " LEFT JOIN DMKHOAPHONG ON DMKHOAPHONG.MAKHOA = C.MAKHOA"
                + " LEFT JOIN DMPHAUTHUAT ON DMPHAUTHUAT.MADICHVU = E.MAPT AND DMPHAUTHUAT.LOAIDICHVU = E.LOAIDICHVU"
                + " LEFT JOIN DMLOAIPHAUTHUAT ON DMLOAIPHAUTHUAT.MALOAIPT = DMPHAUTHUAT.LOAIPHAUTHUAT"
                + " LEFT JOIN DMVOCAM ON DMVOCAM.MAVOCAM = E.PPVOCAM"
                + " WHERE C.SOPHIEU ='{0}' AND B.MAVAOVIEN ='{1}' AND D.LOAIDICHVU ='{2}' AND D.MADICHVU='{3}'", _SoPhieu,_MaVaoVien,_LoaiDichVu,_MaPT);
            this.DataSource = _ds;
            foreach (DataDynamics.ActiveReports.TextBox _lb in detail.Controls)
            {
                if (!Fields.Contains(Fields[_lb.DataField]))
                    Fields.Add(_lb.DataField);
            }
            lblMavaovien.Text = "Số vào viện: " + _MaVaoVien;
        }

        private void repPhieuPT_TT_FetchData(object sender, FetchEventArgs eArgs)
        {
            if (eArgs.EOF)
            {
            }
            else
            {
                String MoChinh = "", PhuMo = "", GMChinh = "", PhuGM = "", GiupViec1 = "", GiupViec2 = "", GiupViec3 = "";
                System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
                SQLCmd.CommandText = string.Format("SELECT TenTat,ViTri FROM BENHNHAN_PT_KIPMO a INNER JOIN DMBACSY b ON a.MaBS=b.MaBS and a.MaKhoa = B.MaKhoa "
                    + " WHERE MaVaoVien='{0}' AND SoPhieuCD='{1}' AND LoaiDichVu='{2}' AND maPT='{3}'",
                    Fields["MaVaoVien"].Value.ToString(),
                    Fields["SoPhieuCD"].Value.ToString(),
                    Fields["LoaiDichVu"].Value.ToString(),
                    Fields["MaPT"].Value.ToString());
                System.Data.SqlClient.SqlDataReader dr = SQLCmd.ExecuteReader();
                if (eArgs.EOF)
                {
                }
                else
                {
                    while (dr.Read())
                    {
                        switch (dr["ViTri"].ToString())
                        {
                            case "1":
                                MoChinh += dr["Tentat"].ToString() + ", " ; break;
                            case "2":
                                PhuMo += dr["Tentat"].ToString() + ", "; break;
                            case "3":
                                GMChinh += dr["Tentat"].ToString() + ", "; break;
                            case "4":
                                PhuGM += dr["Tentat"].ToString() + ", "; break;
                            case "5":
                                GiupViec1 += dr["Tentat"].ToString() + ", "; break;
                            case "6":
                                GiupViec2 += dr["Tentat"].ToString() + ", "; break;
                            case "7":
                                GiupViec3 += dr["Tentat"].ToString() + ", "; break;
                        }
                    }
                    dr.Close();
                    SQLCmd.Dispose();
                    lblMoChinh.Text = "- PTV chính: " + MoChinh;
                    lblPhuMo.Text = "- Phụ mổ: " + PhuMo;
                    lblGayMe.Text = "- Gây mê chính: " + GMChinh;
                    lblPhuGayMe.Text = "- Phụ gây mê: " + PhuGM;
                    lblGiupViec.Text = "- Giúp việc: " + GiupViec1 +  GiupViec2  + GiupViec3;

                    //Fields["PhuMo"].Value = PhuMo;
                    //Fields["PhuGM"].Value = PhuGM;
                    //Fields["GiupViec1"].Value = GiupViec1;
                    //Fields["GiupViec2"].Value = GiupViec2;
                    //Fields["GiupViec3"].Value = GiupViec3;
                }
            }
        }
    }
}
