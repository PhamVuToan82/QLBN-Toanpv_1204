using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using System.Data;
using System.Data.SqlClient;
using GlobalModuls;

namespace NamDinh_QLBN.Reports.BaoCaoVeThuoc
{
    /// <summary>
    /// Summary description for repSoLenThuoc.
    /// </summary>
    public partial class repChiPhi_DDTByBenhNhan : DataDynamics.ActiveReports.ActiveReport3
    {
        private String _MaKhoa,_TenKhoa,_LoaiDichVu,_MaNhom;
        long _SoPhieuTu, _SoPhieuDen;
        private int _NhomThuoc;
        private int Page = 0;
        System.Data.DataTable Table = new DataTable();

        public repChiPhi_DDTByBenhNhan(String MaKhoa, int NhomThuoc, long SoPhieuTu, long SoPhieuDen, String TenKhoa,String MaNhom)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            _MaKhoa = MaKhoa;
            _NhomThuoc = NhomThuoc;
            _TenKhoa = TenKhoa;
            _LoaiDichVu = "D01";
            _SoPhieuTu = SoPhieuTu;
            _SoPhieuDen = SoPhieuDen;
            _MaNhom = MaNhom;
        }

        private void repSoLenThuoc_ReportStart(object sender, EventArgs e)
        {
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.PageSettings.Orientation = PageOrientation.Landscape;

            this.PageSettings.Margins.Left = (float)0.2;
            this.PageSettings.Margins.Right = (float)0.0;
            this.PageSettings.Margins.Top = (float)0.2;
            this.PageSettings.Margins.Bottom = (float)0.2;
            //txtInNgay.Text = String.Format("In ngày {0:dd} tháng {0:MM} năm {0:yyyy}", Global.NgayLV);
            //lblNgayThang.Text = String.Format("Thực hiện ngày {0:dd} tháng {0:MM} năm {0:yyyy}", _TNgay);
            lblKhoa.Text = _TenKhoa;
            if (_NhomThuoc == -1)
            {
                lbSoYLenh.Text = "SỔ TỔNG HỢP THUỐC";
            }
            else
            {
                if (_NhomThuoc == 0)
                {
                    lbSoYLenh.Text = "SỔ THUỐC ỐNG";
                }
                else
                {
                    lbSoYLenh.Text = "SỔ THUỐC VIÊN";
                }
            }
        }

        private void repSoLenThuoc_DataInitialize(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            if (_NhomThuoc == -1)
            {
                SQLCmd.CommandText = String.Format("SELECT A.THUOCID,A.TENTHUOC FROM SOTHUOC  INNER JOIN [" + Global.glbDuoc + "].DBO.DANHMUCTHUOC A ON A.THUOCID = SOTHUOC.MATHUOC  "
                    + " INNER JOIN SACLAPPHIEU ON SACLAPPHIEU.LOAITHUOC = SOTHUOC.LOAITHUOC  "
                    + " inner join  "
                    + " (select * from"
                    + " (Select ct.MaDichVU from  (select SoPhieu from benhnhan_phieudieutri where makhoa = '{0}') aa "
                    + " inner join phieudieutri_chitiet ct on  ct.SoPhieu = aa.SoPhieu  "
                    + " where ct.LoaiDichVu ='{3}' and cast(RIGHT(MAPHIEUDUYET,9) as bigint) >= {1} AND cast(RIGHT(MAPHIEUDUYET,9)as bigint) <= {2} "
                    + " union all "
                    + " select machiphi as Madichvu from chiphi_thuthuat where cast(RIGHT(MAPHIEUDUYET,9) as bigint) >= {1} AND cast(RIGHT(MAPHIEUDUYET,9)as bigint) <= {2} and loaidichvu ='{3}' and makhoa='{0}'"
                    + " union all "
                    + " select MaChiPhi as MaDichVu from [" + Global.glbKhamBenh + "].dbo.tblChiPhi_DichVu where "
                    + " cast(RIGHT(MAPHIEUDUYET,9) as bigint) >= {1} AND cast(RIGHT(MAPHIEUDUYET,9)as bigint) <= {2} and loaiChiPhi ='{3}' and MakhoaThucHien in ('{0}')) bb"
                    + " group by MaDichvu) cc on cc.madichvu = SoThuoc.MaThuoc "
                    + " WHERE SACLAPPHIEU.MaKhoa='{0}' and SoThuoc.MaKhoa ='{0}' "
                    + " order by STT", _MaKhoa, _SoPhieuTu, _SoPhieuDen, _LoaiDichVu);
            }
            else
            {
                SQLCmd.CommandText = String.Format("SELECT A.THUOCID,A.TENTHUOC FROM SOTHUOC  INNER JOIN [" + Global.glbDuoc + "].DBO.DANHMUCTHUOC A ON A.THUOCID = SOTHUOC.MATHUOC  "
                    + " INNER JOIN SACLAPPHIEU ON SACLAPPHIEU.LOAITHUOC = SOTHUOC.LOAITHUOC  "
                    + " inner join  "
                    + " (select * from"
                    + " (Select ct.MaDichVU from  (select SoPhieu from benhnhan_phieudieutri where makhoa = '{0}') aa "
                    + " inner join phieudieutri_chitiet ct on  ct.SoPhieu = aa.SoPhieu  "
                    + " where ct.LoaiDichVu ='{3}'  and cast(RIGHT(MAPHIEUDUYET,9) as bigint) >= {1} AND cast(RIGHT(MAPHIEUDUYET,9)as bigint) <= {2}"
                    + " union  all"
                    + " select machiphi as Madichvu from chiphi_thuthuat where cast(RIGHT(MAPHIEUDUYET,9) as bigint) >= {1} AND cast(RIGHT(MAPHIEUDUYET,9)as bigint) <= {2} and loaidichvu ='{3}' and Makhoa='{0}'"
                    + " union all "
                    + " select MaChiPhi as MaDichVu from [" + Global.glbKhamBenh + "].dbo.tblChiPhi_DichVu where "
                    + " cast(RIGHT(MAPHIEUDUYET,9) as bigint) >= {1} AND cast(RIGHT(MAPHIEUDUYET,9)as bigint) <= {2} and loaiChiPhi ='{3}' and MakhoaThucHien in ('{0}')) bb"
                    + " group by MaDichvu) cc on cc.madichvu = SoThuoc.MaThuoc "
                    + " WHERE SACLAPPHIEU.NhomSo = {4} and SACLAPPHIEU.MaKhoa='{0}' and SoThuoc.MaKHoa ='{0}' "
                    + " order by STT", _MaKhoa, _SoPhieuTu, _SoPhieuDen, _LoaiDichVu, _NhomThuoc);
            }
            //if (_isVatTu)
            //{
            //    SQLCmd.CommandText = String.Format("SELECT A.THUOCID,A.TENTHUOC FROM VATTU  INNER JOIN [" + Global.glbDuoc + "].DBO.DANHMUCTHUOC A ON A.THUOCID = VATTU.MACHIPHI  "
            //        + " inner join  "
            //        + " (select * from"
            //        + " (Select ct.MaDichVU from  (select SoPhieu from benhnhan_phieudieutri where makhoa = '{0}' and datediff(dd,NgayChiDinh,'{1:MM/dd/yyyy}') <= 0 and datediff(dd,NgayChiDinh,'{2:MM/dd/yyyy}') >= 0) aa "
            //        + " inner join phieudieutri_chitiet ct on  ct.SoPhieu = aa.SoPhieu  "
            //        + " where ct.LoaiDichVu ='{3}'"
            //        + " union all "
            //        + " select machiphi as Madichvu from chiphi_thuthuat where datediff(dd,NgayThucHien,'{1:MM/dd/yyyy}') <= 0 and datediff(dd,NgayThucHien,'{2:MM/dd/yyyy}') >= 0 and loaidichvu ='{3}' and makhoa='{0}'"
            //        + " union all "
            //        + " select MaChiPhi as MaDichVu from [" + Global.glbKhamBenh + "].dbo.tblChiPhi_DichVu where "
            //        + " datediff(dd,NgayThucHien,'{1:MM/dd/yyyy}') <= 0 and datediff(dd,NgayThucHien,'{2:MM/dd/yyyy}') >= 0 and loaiChiPhi ='{3}' and MakhoaThucHien in ('{0}')) bb"
            //        + " group by MaDichvu) cc on cc.madichvu = VatTu.MaChiPhi "
            //        + " WHERE VATTU.MaKhoa ='{0}' "
            //        + " order by A.TENTHUOC", _MaKhoa, _TNgay, _DNgay, _LoaiDichVu);
            //}
           
            int j = 1;
            SQLCmd.CommandTimeout = 0;
            dr = SQLCmd.ExecuteReader();
            while (dr.Read())
            {
                foreach (DataDynamics.ActiveReports.Label lb in pageHeader.Controls)
                {
                    if (lb.Name == ("lb" + j.ToString()))
                    {
                        lb.Text = dr["TenThuoc"].ToString();
                        lb.Name = dr["ThuocID"].ToString();
                        break;
                    }
                }
                foreach (DataDynamics.ActiveReports.TextBox _lb in detail.Controls)
                {
                    if (_lb.Name == ("lbl" + j.ToString()))
                    {
                        _lb.Name = dr["ThuocID"].ToString();
                        _lb.DataField = dr["ThuocID"].ToString();
                        break;
                    }
                }
                foreach (DataDynamics.ActiveReports.TextBox _lb in reportFooter1.Controls)
                {
                    if (_lb.Name == ("txt" + j.ToString()))
                    {
                        _lb.Name = dr["ThuocID"].ToString();
                        break;
                    }
                }
                j++;
            }
            dr.Close();
            SQLCmd.Dispose();

            
            DataDynamics.ActiveReports.DataSources.SqlDBDataSource _ds = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();

            _ds.ConnectionString = GlobalModuls.Global.glbConnectionString;

            _ds.SQL = String.Format("Select * from"
                     + " (SELECT DD.MAVAOVIEN,DD.HOTEN,DD.TUOI,DMBUONGBENH.TENBUONG,dd.nhom,CASE WHEN DD.NHOM = 0 THEN N'Thuốc trong ngày' else N'Thuốc bất thường' end as Nhom1 FROM  "
                     + " (SELECT CC.*,BN.SOPHIEU,BN.NGAYCHIDINH,BN.NHOM FROM "
                     + " (SELECT BB.MAVAOVIEN,AA.HOTEN,YEAR(GETDATE()) - NAMSINH AS TUOI,BB.BUONG FROM "
                     + " (SELECT * FROM BENHNHAN) AA INNER JOIN BENHNHAN_CHITIET BB ON BB.MABENHNHAN = AA.MABENHNHAN) CC "
                     + " INNER JOIN BENHNHAN_PHIEUDIEUTRI BN ON BN.MAVAOVIEN = CC.MAVAOVIEN "
                     + " WHERE MAKHOA ='{0}') DD "
                     + " INNER JOIN PHIEUDIEUTRI_CHITIET CT ON CT.SOPHIEU = DD.SOPHIEU  "
                     + " LEFT JOIN DMBUONGBENH ON DMBUONGBENH.ID_BUONG = DD.BUONG AND DMBUONGBENH.MAKHOA='{0}' "
                     + " WHERE CT.LOAIDICHVU = '{3}' AND cast(RIGHT(MAPHIEUDUYET,9) as bigint) >= {1} AND cast(RIGHT(MAPHIEUDUYET,9)as bigint) <= {2}" + (_MaNhom == "0" ? "" : " AND CT.MANHOM = " + _MaNhom)
                     + " union all"
                     + " select aa.mavaovien,hoten,year(getdate()) - NamSinh as tuoi,tenbuong,1 as Nhom,N'Chi phí bất thường' as Nhom1 from "
                     + " (select * from chiphi_thuthuat where Loaidichvu ='{3}' and makhoa='{0}' and cast(RIGHT(MAPHIEUDUYET,9) as bigint) >= {1} AND cast(RIGHT(MAPHIEUDUYET,9)as bigint) <= {2}" + (_MaNhom == "0" ? "" : " AND MANHOM = " + _MaNhom)
                     + " ) aa"
                     + " inner join benhnhan_chitiet ct on ct.mavaovien = aa.mavaovien"
                     + " inner join benhnhan on benhnhan.mabenhnhan = ct.mabenhnhan"
                     + " LEFT JOIN DMBUONGBENH ON DMBUONGBENH.ID_BUONG = ct.BUONG AND DMBUONGBENH.MAKHOA='{0}'"
                     + " union all"
                     + " Select b.MaKhambenh as MaVaoVien,BenhNhan.TenBenhNhan as HoTen,Year(Getdate()) - BenhNhan.NamSinh as Tuoi,"
                     + " '' as TenBuong,0 as Nhom,N'Thuốc trong ngày' as Nhom1 from [" + Global.glbKhamBenh + "].dbo.tblChiPhi_DichVu b"
                     + " inner join [" + Global.glbKhamBenh + "].dbo.tblKhamBenh KhamBenh on KhamBenh.MaKhambenh = b.MaKhamBenh"
                     + " inner join [" + Global.glbKhamBenh + "].dbo.tblBenhNhan BenhNhan on BenhNhan.MaBenhNhan = Khambenh.MaBenhNhan"
                     + " where loaiChiPhi ='{3}' and makhoathuchien in ('{0}') "
                     + " and cast(RIGHT(MAPHIEUDUYET,9) as bigint) >= {1} AND cast(RIGHT(MAPHIEUDUYET,9)as bigint) <= {2}" + (_MaNhom == "0" ? "" : " AND B.MANHOM = " + _MaNhom)
                     + " ) cc"
                     + " GROUP BY MAVAOVIEN,HOTEN,TUOI,TENBUONG,NHOM,Nhom1 "
                     + " ORDER BY NHOM,TENBUONG ", _MaKhoa, _SoPhieuTu,_SoPhieuDen,_LoaiDichVu);
            this.DataSource = _ds;
            foreach (DataDynamics.ActiveReports.TextBox _lb in detail.Controls)
            {
                if (!Fields.Contains(Fields[_lb.DataField]))
                    Fields.Add(_lb.DataField);
            }
        }

        private void repSoLenThuoc_FetchData(object sender, FetchEventArgs eArgs)
        {
            try
            {
                System.Data.SqlClient.SqlDataReader dr;
                System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
                SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
                String MaVaoVien, Nhom;
                MaVaoVien = Fields["MaVaoVien"].Value.ToString();
                Nhom = Fields["Nhom"].Value.ToString();
                if (Nhom == "") return;
                SQLCmd.CommandText = "SELECT BB.MADICHVU,BB.TENTHUOC,SUM(BB.SOLUONG) AS SOLUONG FROM (";
                if (_NhomThuoc == -1)
                {
                    SQLCmd.CommandText += String.Format(" SELECT EE.MADICHVU,EE.SOLUONG,THUOC.TENTHUOC FROM "
                           + " (SELECT DD.MaVaoVien,CT.MADICHVU,sum(CT.SOLUONG) as soluong FROM "
                           + " (SELECT CC.*,BN.SOPHIEU,BN.NGAYCHIDINH FROM"
                           + " (SELECT BB.MAVAOVIEN,AA.HOTEN,YEAR(GETDATE()) - NAMSINH AS TUOI FROM"
                           + " (SELECT * FROM BENHNHAN) AA"
                           + " INNER JOIN BENHNHAN_CHITIET BB ON BB.MABENHNHAN = AA.MABENHNHAN) CC"
                           + " INNER JOIN BENHNHAN_PHIEUDIEUTRI BN ON BN.MAVAOVIEN = CC.MAVAOVIEN"
                           + " WHERE MAKHOA ='{0}' and bn.nhom={4}) DD"
                           + " INNER JOIN PHIEUDIEUTRI_CHITIET CT ON CT.SOPHIEU = DD.SOPHIEU "
                           + " WHERE CT.LOAIDICHVU = '{5}' AND cast(RIGHT(MAPHIEUDUYET,9) as bigint) >= {1} AND cast(RIGHT(MAPHIEUDUYET,9)as bigint) <= {2} " + (_MaNhom == "0" ? "" : " AND CT.MANHOM = " + _MaNhom)
                           + " group by DD.MaVaoVien,CT.MADICHVU) EE"
                           + " INNER JOIN [" + Global.glbDuoc + "].DBO.DANHMUCTHUOC THUOC ON THUOC.THUOCID = EE.MADICHVU "
                           + " INNER JOIN SACLAPPHIEU ON SACLAPPHIEU.LOAITHUOC = THUOC.LOAITHUOC "
                           + " WHERE SACLAPPHIEU.makhoa='{0}' and SACLAPPHIEU.NHOMSO <> -1 AND EE.MAVAOVIEN = '{3}'",
                          _MaKhoa,
                           _SoPhieuTu,
                           _SoPhieuDen,
                           MaVaoVien, 
                           Nhom, 
                           _LoaiDichVu);
                }
                else
                {
                    SQLCmd.CommandText += String.Format(" SELECT EE.MADICHVU,EE.SOLUONG,THUOC.TENTHUOC FROM "
                        + " (SELECT DD.MaVaoVien,CT.MADICHVU,sum(CT.SOLUONG) as soluong FROM "
                        + " (SELECT CC.*,BN.SOPHIEU,BN.NGAYCHIDINH FROM"
                        + " (SELECT BB.MAVAOVIEN,AA.HOTEN,YEAR(GETDATE()) - NAMSINH AS TUOI FROM"
                        + " (SELECT * FROM BENHNHAN) AA"
                        + " INNER JOIN BENHNHAN_CHITIET BB ON BB.MABENHNHAN = AA.MABENHNHAN) CC"
                        + " INNER JOIN BENHNHAN_PHIEUDIEUTRI BN ON BN.MAVAOVIEN = CC.MAVAOVIEN"
                        + " WHERE MAKHOA ='{0}' and bn.nhom={4}) DD"
                        + " INNER JOIN PHIEUDIEUTRI_CHITIET CT ON CT.SOPHIEU = DD.SOPHIEU "
                        + " WHERE CT.LOAIDICHVU = '{5}' AND cast(RIGHT(MAPHIEUDUYET,9) as bigint) >= {1} AND cast(RIGHT(MAPHIEUDUYET,9)as bigint) <= {2} " + (_MaNhom == "0" ? "" : " AND CT.MANHOM = " + _MaNhom)
                        + " group by DD.MaVaoVien,CT.MADICHVU ) EE"
                        + " INNER JOIN [" + Global.glbDuoc + "].DBO.DANHMUCTHUOC THUOC ON THUOC.THUOCID = EE.MADICHVU "
                        + " INNER JOIN SACLAPPHIEU ON SACLAPPHIEU.LOAITHUOC = THUOC.LOAITHUOC "
                        + " WHERE SACLAPPHIEU.NHOMSO = " + _NhomThuoc + " AND SACLAPPHIEU.makhoa='{0}' and SACLAPPHIEU.NHOMSO <> -1 AND EE.MAVAOVIEN = '{3}'",
                       _MaKhoa,
                        _SoPhieuTu,
                        _SoPhieuDen,
                         MaVaoVien, Nhom,_LoaiDichVu);
                }
                if (Nhom == "1")
                {
                    SQLCmd.CommandText += String.Format("UNION ALL "
                        + " SELECT DMDICHVU.MADICHVU,SOLUONG,DMDICHVU.TENDICHVU AS TENTHUOC FROM "
                        + " (SELECT MACHIPHI AS MADICHVU,SUM(SOLUONG) AS SOLUONG  FROM CHIPHI_THUTHUAT WHERE LOAIDICHVU ='{4}' AND MAKHOA ='{0}' AND MAVAOVIEN = '{3}' "
                        + " AND cast(RIGHT(MAPHIEUDUYET,9) as bigint) >= {1} AND cast(RIGHT(MAPHIEUDUYET,9)as bigint) <= {2}" + (_MaNhom == "0" ? "" : " AND CHIPHI_THUTHUAT.MANHOM = " + _MaNhom)
                        + " GROUP BY MACHIPHI) AA"
                        + " INNER JOIN DMDICHVU ON DMDICHVU.MADICHVU = AA.MADICHVU"
                        + " inner join saclapphieu on saclapphieu.loaithuoc = dmdichvu.loaithuoc and saclapphieu.makhoa = '{0}' and SACLAPPHIEU.NHOMSO <> -1", 
                        _MaKhoa,
                        _SoPhieuTu,
                        _SoPhieuDen, 
                        MaVaoVien,
                        _LoaiDichVu);
                    if (_NhomThuoc != -1)
                    {
                        SQLCmd.CommandText += " and saclapphieu.nhomso=" + _NhomThuoc;
                    }
                }
                if (Nhom == "0")
                {
                    SQLCmd.CommandText += String.Format("UNION ALL "
                        + " SELECT DMDICHVU.MADICHVU,SOLUONG,DMDICHVU.TENDICHVU AS TENTHUOC FROM "
                        + " (SELECT MACHIPHI AS MADICHVU,SUM(SOLUONG) AS SOLUONG  FROM [" + Global.glbKhamBenh + "].dbo.tblChiPhi_DichVu "
                        + " WHERE LOAIChiPhi ='{4}' AND MAKHOAThucHien in ('{0}') AND MaKhambenh = '{3}' "
                        + " AND cast(RIGHT(MAPHIEUDUYET,9) as bigint) >= {1} AND cast(RIGHT(MAPHIEUDUYET,9)as bigint) <= {2} " + (_MaNhom == "0" ? "" : " AND MANHOM = " + _MaNhom)
                        + " GROUP BY MACHIPHI) AA"
                        + " INNER JOIN DMDICHVU ON DMDICHVU.MADICHVU = AA.MADICHVU"
                        + " inner join saclapphieu on saclapphieu.loaithuoc = dmdichvu.loaithuoc and saclapphieu.makhoa = '{0}' and SACLAPPHIEU.NHOMSO <> -1", 
                        _MaKhoa, 
                        _SoPhieuTu,
                        _SoPhieuDen,
                        MaVaoVien,
                        _LoaiDichVu);
                    if (_NhomThuoc != -1)
                    {
                        SQLCmd.CommandText += " and saclapphieu.nhomso=" + _NhomThuoc;
                    }
                }
                SQLCmd.CommandText += ") BB GROUP BY MADICHVU,TENTHUOC";
                    
                dr = SQLCmd.ExecuteReader();
                bool DaCo = false;
                lblGhiChu.Text = "";
                foreach (DataDynamics.ActiveReports.TextBox _lb in detail.Controls)
                {
                    if (_lb.DataField != "HoTen" && _lb.DataField != "Tuoi" && _lb.DataField != "TENBUONG")
                    {
                        Fields[_lb.DataField].Value = "";
                    }
                }
                while (dr.Read())
                {

                    DaCo = false;
                    foreach (DataDynamics.ActiveReports.TextBox _lb in detail.Controls)
                    {
                        if (_lb.Name == dr["MaDichVu"].ToString())
                        {
                            Fields[dr["MaDichVu"].ToString()].Value = String.Format("{0:#,##0.##}", decimal.Parse(dr["SoLuong"].ToString()));
                            DaCo = true;
                        }
                    }
                    if (!DaCo)
                    {
                        if (lblGhiChu.Text == "")
                        {
                            lblGhiChu.Text += dr["TenThuoc"].ToString() + "- " + String.Format("{0:#,##0.##}", decimal.Parse(dr["SoLuong"].ToString()));
                        }
                        else
                        {
                            lblGhiChu.Text += "\n " + dr["TenThuoc"].ToString() + "- " + String.Format("{0:#,##0.##}", decimal.Parse(dr["SoLuong"].ToString()));
                        }
                    }
                    foreach (DataDynamics.ActiveReports.TextBox _txt in reportFooter1.Controls)
                    {
                        if (_txt.Name == dr["MaDichVu"].ToString())
                        {
                            if (_txt.Value == null)
                            {
                                _txt.Value = decimal.Parse(String.Format("{0:#,##0.##}", decimal.Parse(dr["SoLuong"].ToString())));
                            }
                            else
                            {
                                _txt.Value = (decimal)_txt.Value + decimal.Parse(String.Format("{0:#,##0.##}", decimal.Parse(dr["SoLuong"].ToString())));
                            }
                            break;
                        }
                    }
                }
                dr.Close();
            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
        }

        private void detail_BeforePrint(object sender, EventArgs e)
        {
            foreach (TextBox txt in detail.Controls)
            {
                txt.Height = detail.Height;
            }
        }

        private void reportFooter1_Format(object sender, EventArgs e)
        {
            
        }

        private void repSoLenThuoc_PageStart(object sender, EventArgs e)
        {
            Page++;
            txtPage.Text = "Trang: " + Page.ToString();
        }

        private void groupHeader2_Format(object sender, EventArgs e)
        {

        }
    }
}
