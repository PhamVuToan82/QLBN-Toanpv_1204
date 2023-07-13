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
    public partial class repChiPhi_DDTByBenhNhanDangDT : DataDynamics.ActiveReports.ActiveReport3
    {
        private String _MaKhoa, _TenKhoa, _LoaiDichVu, _SoPhieuTu, _SoPhieuDen, _MaNhom;
        private DateTime _ngaychidinh;
        private bool _isngay;
            
        private int _NhomThuoc;
        private int Page = 0;
        System.Data.DataTable Table = new DataTable();

        public repChiPhi_DDTByBenhNhanDangDT(String MaKhoa, int NhomThuoc, String TenKhoa, String MaNhom,DateTime NgayChiDinh, bool isngay)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            _MaKhoa = MaKhoa;
            _NhomThuoc = NhomThuoc;
            _TenKhoa = TenKhoa;
            _MaNhom = MaNhom;
            _ngaychidinh = NgayChiDinh;_isngay = isngay;
            _LoaiDichVu = "D01";
        }

        private void repSoLenThuoc_ReportStart(object sender, EventArgs e)
        {
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.PageSettings.Orientation = PageOrientation.Landscape;

            this.PageSettings.Margins.Left = (float)0.2;
            this.PageSettings.Margins.Right = (float)0.0;
            this.PageSettings.Margins.Top = (float)0.2;
            this.PageSettings.Margins.Bottom = (float)0.2;
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
            //if (_NhomThuoc == -1)
            //{
            //    SQLCmd.CommandText = String.Format("SELECT A.THUOCID,A.TENTHUOC FROM SOTHUOC  INNER JOIN [" + Global.glbDuoc + "].DBO.DANHMUCTHUOC A ON A.THUOCID = SOTHUOC.MATHUOC  "
            //        + " INNER JOIN SACLAPPHIEU ON SACLAPPHIEU.LOAITHUOC = SOTHUOC.LOAITHUOC  "
            //        + " inner join  "
            //        + " (select * from"
            //        + " (Select ct.MaDichVU from  (select SoPhieu from benhnhan_phieudieutri "
            //        + " INNER JOIN VIEWKHOAHIENTAI V ON V.MAVAOVIEN = benhnhan_phieudieutri.MAVAOVIEN AND V.VTRANGTHAI = 1 AND V.VDARAVIEN = 0 AND V.MAKHOA = benhnhan_phieudieutri.MAKHOA"
            //        + " where benhnhan_phieudieutri.makhoa = '{0}') aa "
            //        + " inner join phieudieutri_chitiet ct on  ct.SoPhieu = aa.SoPhieu  "
            //        + " where ct.LoaiDichVu ='{1}'"
            //        + " union all "
            //        + " select machiphi as Madichvu from chiphi_thuthuat "
            //        + " INNER JOIN VIEWKHOAHIENTAI V ON V.MAKHOA = chiphi_thuthuat.MAKHOA AND V.MAVAOVIEN = chiphi_thuthuat.MAVAOVIEN AND V.VTRANGTHAI = 1 AND V.VDARAVIEN = 0"
            //        + " where loaidichvu ='{1}' and chiphi_thuthuat.makhoa='{0}'"
            //        + ") bb"
            //        + " group by MaDichvu) cc on cc.madichvu = SoThuoc.MaThuoc "
            //        + " WHERE SACLAPPHIEU.MaKhoa='{0}' and SoThuoc.MaKhoa ='{0}' "
            //        + " order by STT", _MaKhoa, _LoaiDichVu);
            //}
            //else
            //{
            //    SQLCmd.CommandText = String.Format("SELECT A.THUOCID,A.TENTHUOC FROM SOTHUOC  INNER JOIN [" + Global.glbDuoc + "].DBO.DANHMUCTHUOC A ON A.THUOCID = SOTHUOC.MATHUOC  "
            //        + " INNER JOIN SACLAPPHIEU ON SACLAPPHIEU.LOAITHUOC = SOTHUOC.LOAITHUOC  "
            //        + " inner join  "
            //        + " (select * from"
            //        + " (Select ct.MaDichVU from  (select SoPhieu from benhnhan_phieudieutri "
            //        + " INNER JOIN VIEWKHOAHIENTAI V ON V.MAKHOA = benhnhan_phieudieutri.MAKHOA AND V.MAVAOVIEN = benhnhan_phieudieutri.MAVAOVIEN AND V.VTRANGTHAI = 1 AND V.VDARAVIEN = 0"
            //        + " where benhnhan_phieudieutri.makhoa = '{0}') aa "
            //        + " inner join phieudieutri_chitiet ct on  ct.SoPhieu = aa.SoPhieu  "
            //        + " where ct.LoaiDichVu ='{1}'"
            //        + " union  all"
            //        + " select machiphi as Madichvu from chiphi_thuthuat "
            //        + " INNER JOIN VIEWKHOAHIENTAI V ON V.MAVAOVIEN = chiphi_thuthuat.MAVAOVIEN AND V.MAKHOA = chiphi_thuthuat.MAKHOA AND V.VDARAVIEN = 0 AND V.VTRANGTHAI = 1"
            //        + " where loaidichvu ='{1}' and chiphi_thuthuat.Makhoa='{0}'"
            //        + " ) bb"
            //        + " group by MaDichvu) cc on cc.madichvu = SoThuoc.MaThuoc "
            //        + " WHERE SACLAPPHIEU.NhomSo = {2} and SACLAPPHIEU.MaKhoa='{0}' and SoThuoc.MaKHoa ='{0}' "
            //        + " order by STT", _MaKhoa, _LoaiDichVu, _NhomThuoc);
            //}

            if (_isngay == false)
            {
                if (_NhomThuoc == -1)
                {
                    SQLCmd.CommandText = String.Format("set dateformat DMY HH:mm: SELECT DISTINCT A.THUOCID,A.TENTHUOC FROM[NamDinh_Duoc].DBO.DANHMUCTHUOC A"
                                                       + "  INNER join(Select distinct ct.MaDichVU, MaKhoa "
                                                       + "  FROM  (select SoPhieu, v.MaKhoa from benhnhan_phieudieutri  INNER JOIN VIEWKHOAHIENTAI V ON V.MAVAOVIEN = benhnhan_phieudieutri.MAVAOVIEN AND V.VTRANGTHAI = 1 AND V.VDARAVIEN = 0 AND V.MAKHOA = benhnhan_phieudieutri.MAKHOA where benhnhan_phieudieutri.makhoa = '{0}') aa"
                                                       + "  INNER join phieudieutri_chitiet ct on  ct.SoPhieu = aa.SoPhieu"
                                                       + "  WHERE(ct.LoaiDichVu = 'D01') AND aa.MaKhoa = '{0}'"
                                                       + "  UNION all"
                                                       + "  SELECT machiphi as Madichvu,v.MaKhoa from chiphi_thuthuat"
                                                       + "  INNER JOIN VIEWKHOAHIENTAI V ON V.MAKHOA = chiphi_thuthuat.MAKHOA AND V.MAVAOVIEN = chiphi_thuthuat.MAVAOVIEN AND V.VTRANGTHAI = 1 AND V.VDARAVIEN = 0"
                                                       + "  WHERE(loaidichvu = 'D01') and chiphi_thuthuat.makhoa = '{0}') bb ON bb.MaDichVu = a.ThuocID", _MaKhoa, _LoaiDichVu, _NhomThuoc);
                }
                else
                {
                    SQLCmd.CommandText = String.Format("set dateformat DMY HH:mm: SELECT A.THUOCID,A.TENTHUOC FROM[NamDinh_Duoc].DBO.DANHMUCTHUOC A"
                                                        + " INNER JOIN SACLAPPHIEU ON SACLAPPHIEU.LOAITHUOC = a.LOAITHUOC"
                                                        + " INNER join"
                                                        + " (SELECT DISTINCT DichVu.MaDichVu, MAKHOA FROM (Select pdtct.MaDichVu, pdt.MaKhoa from benhnhan_phieudieutri pdt INNER JOIN VIEWKHOAHIENTAI V ON V.MAKHOA = pdt.MAKHOA AND V.MAVAOVIEN = pdt.MAVAOVIEN AND V.VTRANGTHAI = 1 AND V.VDARAVIEN = 0"
                                                        + " INNER join phieudieutri_chitiet pdtct on pdtct.SoPhieu = pdt.SoPhieu"
                                                        + " WHERE pdt.makhoa = '{0}' and pdtct.LoaiDichVu = 'D01'"
                                                        + " UNION all"
                                                        + " SELECT DISTINCT machiphi as Madichvu,CHIPHI_THUTHUAT.MaKhoa from chiphi_thuthuat INNER JOIN VIEWKHOAHIENTAI V ON V.MAVAOVIEN = chiphi_thuthuat.MAVAOVIEN AND V.MAKHOA = chiphi_thuthuat.MAKHOA AND V.VDARAVIEN = 0 AND V.VTRANGTHAI = 1"
                                                        + " WHERE loaidichvu = 'D01' and chiphi_thuthuat.Makhoa = '{0}' )DichVu) yy ON YY.MaKhoa = dbo.SacLapPhieu.MaKhoa AND A.ThuocID = YY.MaDichVu"
                                                        + " WHERE SACLAPPHIEU.NhomSo = {2} and SACLAPPHIEU.MaKhoa = '{0}' ORDER by a.TenThuoc", _MaKhoa, _LoaiDichVu, _NhomThuoc);
                }
            }
            else
            {
                if (_NhomThuoc == -1)
                {
                    SQLCmd.CommandText = String.Format("set dateformat DMY HH:mm: SELECT DISTINCT A.THUOCID,A.TENTHUOC FROM[NamDinh_Duoc].DBO.DANHMUCTHUOC A"
                                                       + "  INNER join(Select distinct ct.MaDichVU, MaKhoa "
                                                       + "  FROM  (select SoPhieu, v.MaKhoa from benhnhan_phieudieutri  INNER JOIN VIEWKHOAHIENTAI V ON V.MAVAOVIEN = benhnhan_phieudieutri.MAVAOVIEN AND V.VTRANGTHAI = 1 AND V.VDARAVIEN = 0 AND V.MAKHOA = benhnhan_phieudieutri.MAKHOA where benhnhan_phieudieutri.makhoa = '{0}'  and NgayChiDinh<='{3:dd/MM/yyyy HH:mm}') aa"
                                                       + "  INNER join phieudieutri_chitiet ct on  ct.SoPhieu = aa.SoPhieu"
                                                       + "  WHERE(ct.LoaiDichVu = 'D01') AND aa.MaKhoa = '{0}'"
                                                       + "  UNION all"
                                                       + "  SELECT machiphi as Madichvu,v.MaKhoa from chiphi_thuthuat"
                                                       + "  INNER JOIN VIEWKHOAHIENTAI V ON V.MAKHOA = chiphi_thuthuat.MAKHOA AND V.MAVAOVIEN = chiphi_thuthuat.MAVAOVIEN AND V.VTRANGTHAI = 1 AND V.VDARAVIEN = 0"
                                                       + "  WHERE(loaidichvu = 'D01') and chiphi_thuthuat.makhoa = '{0}') bb ON bb.MaDichVu = a.ThuocID", _MaKhoa, _LoaiDichVu, _NhomThuoc, _ngaychidinh);
                }
                else
                {
                    SQLCmd.CommandText = String.Format(" set dateformat DMY HH:mm: SELECT A.THUOCID,A.TENTHUOC FROM[NamDinh_Duoc].DBO.DANHMUCTHUOC A"
                                                        + " INNER JOIN SACLAPPHIEU ON SACLAPPHIEU.LOAITHUOC = a.LOAITHUOC"
                                                        + " INNER join"
                                                        + " (SELECT DISTINCT DichVu.MaDichVu, MAKHOA FROM (Select pdtct.MaDichVu, pdt.MaKhoa from benhnhan_phieudieutri pdt INNER JOIN VIEWKHOAHIENTAI V ON V.MAKHOA = pdt.MAKHOA AND V.MAVAOVIEN = pdt.MAVAOVIEN AND V.VTRANGTHAI = 1 AND V.VDARAVIEN = 0"
                                                        + " INNER join phieudieutri_chitiet pdtct on pdtct.SoPhieu = pdt.SoPhieu"
                                                        + " WHERE pdt.makhoa = '{0}' and pdtct.LoaiDichVu = 'D01' and NgayChiDinh<='{3:dd/MM/yyyy HH:mm}'"
                                                        + " UNION all"
                                                        + " SELECT DISTINCT machiphi as Madichvu,CHIPHI_THUTHUAT.MaKhoa from chiphi_thuthuat INNER JOIN VIEWKHOAHIENTAI V ON V.MAVAOVIEN = chiphi_thuthuat.MAVAOVIEN AND V.MAKHOA = chiphi_thuthuat.MAKHOA AND V.VDARAVIEN = 0 AND V.VTRANGTHAI = 1"
                                                        + " WHERE loaidichvu = 'D01' and chiphi_thuthuat.Makhoa = '{0}' )DichVu) yy ON YY.MaKhoa = dbo.SacLapPhieu.MaKhoa AND A.ThuocID = YY.MaDichVu"
                                                        + " WHERE SACLAPPHIEU.NhomSo = {2} and SACLAPPHIEU.MaKhoa = '{0}' ORDER by a.TenThuoc", _MaKhoa, _LoaiDichVu, _NhomThuoc, _ngaychidinh);
                }
            }

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
            if (_isngay == false)
            {
                _ds.SQL = String.Format(" set dateformat DMY HH:mm: Select * from"
                  + " (SELECT DD.MAVAOVIEN,DD.HOTEN,DD.TUOI,DMBUONGBENH.TENBUONG,dd.nhom,CASE WHEN DD.NHOM = 0 THEN N'Thuốc trong ngày' else N'Thuốc bất thường' end as Nhom1 FROM  "
                  + " (SELECT CC.*,BN.SOPHIEU,BN.NGAYCHIDINH,BN.NHOM FROM "
                  + " (SELECT BB.MAVAOVIEN,AA.HOTEN,YEAR(GETDATE()) - NAMSINH AS TUOI,BB.BUONG FROM "
                  + " (SELECT * FROM BENHNHAN) AA INNER JOIN BENHNHAN_CHITIET BB ON BB.MABENHNHAN = AA.MABENHNHAN) CC "
                  + " INNER JOIN BENHNHAN_PHIEUDIEUTRI BN ON BN.MAVAOVIEN = CC.MAVAOVIEN "
                  + " INNER JOIN VIEWKHOAHIENTAI V ON V.MAVAOVIEN = BN.MAVAOVIEN AND V.MAKHOA = '{0}' AND V.VTRANGTHAI = 1 AND V.VDARAVIEN = 0"
                  + " WHERE BN.MAKHOA ='{0}') DD "
                  + " INNER JOIN PHIEUDIEUTRI_CHITIET CT ON CT.SOPHIEU = DD.SOPHIEU  "
                  + " LEFT JOIN DMBUONGBENH ON DMBUONGBENH.ID_BUONG = DD.BUONG AND DMBUONGBENH.MAKHOA='{0}' "
                  + " WHERE CT.LOAIDICHVU = '{1}'" + (_MaNhom == "0" ? "" : " AND CT.MANHOM= " + _MaNhom)
                  + " union all"
                  + " select aa.mavaovien,hoten,year(getdate()) - NamSinh as tuoi,tenbuong,1 as Nhom,N'Chi phí bất thường' as Nhom1 from "
                  + " (select chiphi_thuthuat.* from chiphi_thuthuat "
                  + " INNER JOIN VIEWKHOAHIENTAI V ON V.MAVAOVIEN = chiphi_thuthuat.MAVAOVIEN AND V.MAKHOA ='{0}' AND V.VTRANGTHAI = 1 AND V.VDARAVIEN = 0"
                  + " where Loaidichvu ='{1}' and chiphi_thuthuat.makhoa='{0}'" + (_MaNhom == "0" ? "" : " AND chiphi_thuthuat.MANHOM= " + _MaNhom)
                  + " ) aa"
                  + " inner join benhnhan_chitiet ct on ct.mavaovien = aa.mavaovien"
                  + " inner join benhnhan on benhnhan.mabenhnhan = ct.mabenhnhan"
                  + " LEFT JOIN DMBUONGBENH ON DMBUONGBENH.ID_BUONG = ct.BUONG AND DMBUONGBENH.MAKHOA='{0}') cc"
                  + " GROUP BY MAVAOVIEN,HOTEN,TUOI,TENBUONG,NHOM,Nhom1 "
                  + " ORDER BY NHOM,TENBUONG ", _MaKhoa, _LoaiDichVu);
            }
            else
            {
                _ds.SQL = String.Format(" set dateformat DMY HH:mm:  Select * from"
                  + " (SELECT DD.MAVAOVIEN,DD.HOTEN,DD.TUOI,DMBUONGBENH.TENBUONG,dd.nhom,CASE WHEN DD.NHOM = 0 THEN N'Thuốc trong ngày' else N'Thuốc bất thường' end as Nhom1 FROM  "
                  + " (SELECT CC.*,BN.SOPHIEU,BN.NGAYCHIDINH,BN.NHOM FROM "
                  + " (SELECT BB.MAVAOVIEN,AA.HOTEN,YEAR(GETDATE()) - NAMSINH AS TUOI,BB.BUONG FROM "
                  + " (SELECT * FROM BENHNHAN) AA INNER JOIN BENHNHAN_CHITIET BB ON BB.MABENHNHAN = AA.MABENHNHAN) CC "
                  + " INNER JOIN BENHNHAN_PHIEUDIEUTRI BN ON BN.MAVAOVIEN = CC.MAVAOVIEN AND BN.NgayChiDinh<='{2:dd/MM/yyyy HH:mm}' "
                  + " INNER JOIN VIEWKHOAHIENTAI V ON V.MAVAOVIEN = BN.MAVAOVIEN AND V.MAKHOA = '{0}' AND V.VTRANGTHAI = 1 AND V.VDARAVIEN = 0"
                  + " WHERE BN.MAKHOA ='{0}') DD "
                  + " INNER JOIN PHIEUDIEUTRI_CHITIET CT ON CT.SOPHIEU = DD.SOPHIEU  "
                  + " LEFT JOIN DMBUONGBENH ON DMBUONGBENH.ID_BUONG = DD.BUONG AND DMBUONGBENH.MAKHOA='{0}' "
                  + " WHERE CT.LOAIDICHVU = '{1}'" + (_MaNhom == "0" ? "" : " AND CT.MANHOM= " + _MaNhom)
                  + " union all"
                  + " select aa.mavaovien,hoten,year(getdate()) - NamSinh as tuoi,tenbuong,1 as Nhom,N'Chi phí bất thường' as Nhom1 from "
                  + " (select chiphi_thuthuat.* from chiphi_thuthuat "
                  + " INNER JOIN VIEWKHOAHIENTAI V ON V.MAVAOVIEN = chiphi_thuthuat.MAVAOVIEN AND V.MAKHOA ='{0}' AND V.VTRANGTHAI = 1 AND V.VDARAVIEN = 0"
                  + " where Loaidichvu ='{1}' and chiphi_thuthuat.makhoa='{0}'" + (_MaNhom == "0" ? "" : " AND chiphi_thuthuat.MANHOM= " + _MaNhom)
                  + " ) aa"
                  + " inner join benhnhan_chitiet ct on ct.mavaovien = aa.mavaovien"
                  + " inner join benhnhan on benhnhan.mabenhnhan = ct.mabenhnhan"
                  + " LEFT JOIN DMBUONGBENH ON DMBUONGBENH.ID_BUONG = ct.BUONG AND DMBUONGBENH.MAKHOA='{0}') cc"
                  + " GROUP BY MAVAOVIEN,HOTEN,TUOI,TENBUONG,NHOM,Nhom1 "
                  + " ORDER BY NHOM,TENBUONG ", _MaKhoa, _LoaiDichVu, _ngaychidinh);
            }

            _ds.CommandTimeout = 0;
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
                SQLCmd.CommandText = "set dateformat DMY HH:mm: SELECT BB.MADICHVU,BB.TENTHUOC,SUM(BB.SOLUONG) AS SOLUONG FROM (";
                if(_isngay == false)
                {
                    if (_NhomThuoc == -1)
                    {
                        SQLCmd.CommandText += String.Format(" SELECT EE.MADICHVU,EE.SOLUONG,THUOC.TENTHUOC FROM "
                               + " (SELECT DD.MaVaoVien,CT.MADICHVU,sum(CT.SOLUONG) as soluong FROM "
                               + " (SELECT CC.*,BN.SOPHIEU,BN.NGAYCHIDINH FROM"
                               + " (SELECT BB.MAVAOVIEN,AA.HOTEN,YEAR(GETDATE()) - NAMSINH AS TUOI FROM"
                               + " (SELECT * FROM BENHNHAN) AA"
                               + " INNER JOIN BENHNHAN_CHITIET BB ON BB.MABENHNHAN = AA.MABENHNHAN) CC"
                               + " INNER JOIN BENHNHAN_PHIEUDIEUTRI BN ON BN.MAVAOVIEN = CC.MAVAOVIEN"
                               + " INNER JOIN VIEWKHOAHIENTAI V ON V.MAVAOVIEN = BN.MAVAOVIEN AND V.MAKHOA= BN.MAKHOA AND V.VTRANGTHAI = 1 AND V.VDARAVIEN = 0"
                               + " WHERE BN.MAKHOA ='{0}' and bn.nhom={2}) DD"
                               + " INNER JOIN PHIEUDIEUTRI_CHITIET CT ON CT.SOPHIEU = DD.SOPHIEU "
                               + " WHERE CT.LOAIDICHVU = '{3}' " + (_MaNhom == "0" ? "" : " AND CT.MANHOM= " + _MaNhom)
                               + " group by DD.MaVaoVien,CT.MADICHVU) EE"
                               + " INNER JOIN [" + Global.glbDuoc + "].DBO.DANHMUCTHUOC THUOC ON THUOC.THUOCID = EE.MADICHVU "
                               + " INNER JOIN SACLAPPHIEU ON SACLAPPHIEU.LOAITHUOC = THUOC.LOAITHUOC "
                               + " WHERE SACLAPPHIEU.makhoa='{0}' and SACLAPPHIEU.NHOMSO <> -1 AND EE.MAVAOVIEN = '{1}'",
                              _MaKhoa,
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
                            + " INNER JOIN VIEWKHOAHIENTAI V ON V.MAVAOVIEN = BN.MAVAOVIEN AND V.MAKHOA ='{0}' AND V.VTRANGTHAI = 1 AND V.VDARAVIEN = 0"
                            + " WHERE BN.MAKHOA ='{0}' and bn.nhom={2}) DD"
                            + " INNER JOIN PHIEUDIEUTRI_CHITIET CT ON CT.SOPHIEU = DD.SOPHIEU "
                            + " WHERE CT.LOAIDICHVU = '{3}' " + (_MaNhom == "0" ? "" : " AND CT.MANHOM= " + _MaNhom)
                            + " group by DD.MaVaoVien,CT.MADICHVU ) EE"
                            + " INNER JOIN [" + Global.glbDuoc + "].DBO.DANHMUCTHUOC THUOC ON THUOC.THUOCID = EE.MADICHVU "
                            + " INNER JOIN SACLAPPHIEU ON SACLAPPHIEU.LOAITHUOC = THUOC.LOAITHUOC "
                            + " WHERE SACLAPPHIEU.NHOMSO = " + _NhomThuoc + " AND SACLAPPHIEU.makhoa='{0}' and SACLAPPHIEU.NHOMSO <> -1 AND EE.MAVAOVIEN = '{1}'",
                           _MaKhoa,
                             MaVaoVien, Nhom, _LoaiDichVu);
                    }
                    if (Nhom == "1")
                    {
                        SQLCmd.CommandText += String.Format("UNION ALL "
                            + " SELECT DMDICHVU.MADICHVU,SOLUONG,DMDICHVU.TENDICHVU AS TENTHUOC FROM "
                            + " (SELECT MACHIPHI AS MADICHVU,SUM(SOLUONG) AS SOLUONG  FROM CHIPHI_THUTHUAT "
                            + " INNER JOIN VIEWKHOAHIENTAI V ON V.MAVAOVIEN = CHIPHI_THUTHUAT.MAVAOVIEN AND V.MAKHOA = CHIPHI_THUTHUAT.MAKHOA AND V.VTRANGTHAI = 1 AND V.VDARAVIEN = 0"
                            + " WHERE CHIPHI_THUTHUAT.LOAIDICHVU ='{2}' AND CHIPHI_THUTHUAT.MAKHOA ='{0}' AND CHIPHI_THUTHUAT.MAVAOVIEN = '{1}' " + (_MaNhom == "0" ? "" : " AND CHIPHI_THUTHUAT.MANHOM= " + _MaNhom)
                            + " GROUP BY MACHIPHI) AA"
                            + " INNER JOIN DMDICHVU ON DMDICHVU.MADICHVU = AA.MADICHVU"
                            + " inner join saclapphieu on saclapphieu.loaithuoc = dmdichvu.loaithuoc and saclapphieu.makhoa = '{0}' and SACLAPPHIEU.NHOMSO <> -1",
                            _MaKhoa,
                            MaVaoVien,
                            _LoaiDichVu);
                        if (_NhomThuoc != -1)
                        {
                            SQLCmd.CommandText += " and saclapphieu.nhomso=" + _NhomThuoc;
                        }
                    }
                }
                else
                {
                    if (_NhomThuoc == -1)
                    {
                        SQLCmd.CommandText += String.Format(" SELECT EE.MADICHVU,EE.SOLUONG,THUOC.TENTHUOC FROM "
                               + " (SELECT DD.MaVaoVien,CT.MADICHVU,sum(CT.SOLUONG) as soluong FROM "
                               + " (SELECT CC.*,BN.SOPHIEU,BN.NGAYCHIDINH FROM"
                               + " (SELECT BB.MAVAOVIEN,AA.HOTEN,YEAR(GETDATE()) - NAMSINH AS TUOI FROM"
                               + " (SELECT * FROM BENHNHAN) AA"
                               + " INNER JOIN BENHNHAN_CHITIET BB ON BB.MABENHNHAN = AA.MABENHNHAN) CC"
                               + " INNER JOIN BENHNHAN_PHIEUDIEUTRI BN ON BN.MAVAOVIEN = CC.MAVAOVIEN AND BN.NgayChiDinh<='{4:dd/MM/yyyy HH:mm}'"
                               + " INNER JOIN VIEWKHOAHIENTAI V ON V.MAVAOVIEN = BN.MAVAOVIEN AND V.MAKHOA= BN.MAKHOA AND V.VTRANGTHAI = 1 AND V.VDARAVIEN = 0"
                               + " WHERE BN.MAKHOA ='{0}' and bn.nhom={2}) DD"
                               + " INNER JOIN PHIEUDIEUTRI_CHITIET CT ON CT.SOPHIEU = DD.SOPHIEU "
                               + " WHERE CT.LOAIDICHVU = '{3}' " + (_MaNhom == "0" ? "" : " AND CT.MANHOM= " + _MaNhom)
                               + " group by DD.MaVaoVien,CT.MADICHVU) EE"
                               + " INNER JOIN [" + Global.glbDuoc + "].DBO.DANHMUCTHUOC THUOC ON THUOC.THUOCID = EE.MADICHVU "
                               + " INNER JOIN SACLAPPHIEU ON SACLAPPHIEU.LOAITHUOC = THUOC.LOAITHUOC "
                               + " WHERE SACLAPPHIEU.makhoa='{0}' and SACLAPPHIEU.NHOMSO <> -1 AND EE.MAVAOVIEN = '{1}'",
                              _MaKhoa,
                               MaVaoVien,
                               Nhom,
                               _LoaiDichVu, _ngaychidinh);
                    }
                    else
                    {
                        SQLCmd.CommandText += String.Format(" SELECT EE.MADICHVU,EE.SOLUONG,THUOC.TENTHUOC FROM "
                            + " (SELECT DD.MaVaoVien,CT.MADICHVU,sum(CT.SOLUONG) as soluong FROM "
                            + " (SELECT CC.*,BN.SOPHIEU,BN.NGAYCHIDINH FROM"
                            + " (SELECT BB.MAVAOVIEN,AA.HOTEN,YEAR(GETDATE()) - NAMSINH AS TUOI FROM"
                            + " (SELECT * FROM BENHNHAN) AA"
                            + " INNER JOIN BENHNHAN_CHITIET BB ON BB.MABENHNHAN = AA.MABENHNHAN) CC"
                            + " INNER JOIN BENHNHAN_PHIEUDIEUTRI BN ON BN.MAVAOVIEN = CC.MAVAOVIEN AND BN.NgayChiDinh<='{4:dd/MM/yyyy HH:mm}'"
                            + " INNER JOIN VIEWKHOAHIENTAI V ON V.MAVAOVIEN = BN.MAVAOVIEN AND V.MAKHOA ='{0}' AND V.VTRANGTHAI = 1 AND V.VDARAVIEN = 0"
                            + " WHERE BN.MAKHOA ='{0}' and bn.nhom={2}) DD"
                            + " INNER JOIN PHIEUDIEUTRI_CHITIET CT ON CT.SOPHIEU = DD.SOPHIEU "
                            + " WHERE CT.LOAIDICHVU = '{3}' " + (_MaNhom == "0" ? "" : " AND CT.MANHOM= " + _MaNhom)
                            + " group by DD.MaVaoVien,CT.MADICHVU ) EE"
                            + " INNER JOIN [" + Global.glbDuoc + "].DBO.DANHMUCTHUOC THUOC ON THUOC.THUOCID = EE.MADICHVU "
                            + " INNER JOIN SACLAPPHIEU ON SACLAPPHIEU.LOAITHUOC = THUOC.LOAITHUOC "
                            + " WHERE SACLAPPHIEU.NHOMSO = " + _NhomThuoc + " AND SACLAPPHIEU.makhoa='{0}' and SACLAPPHIEU.NHOMSO <> -1 AND EE.MAVAOVIEN = '{1}'",
                           _MaKhoa,
                             MaVaoVien, Nhom, _LoaiDichVu, _ngaychidinh);
                    }
                    if (Nhom == "1")
                    {
                        SQLCmd.CommandText += String.Format("UNION ALL "
                            + " SELECT DMDICHVU.MADICHVU,SOLUONG,DMDICHVU.TENDICHVU AS TENTHUOC FROM "
                            + " (SELECT MACHIPHI AS MADICHVU,SUM(SOLUONG) AS SOLUONG  FROM CHIPHI_THUTHUAT "
                            + " INNER JOIN VIEWKHOAHIENTAI V ON V.MAVAOVIEN = CHIPHI_THUTHUAT.MAVAOVIEN AND V.MAKHOA = CHIPHI_THUTHUAT.MAKHOA AND V.VTRANGTHAI = 1 AND V.VDARAVIEN = 0"
                            + " WHERE CHIPHI_THUTHUAT.LOAIDICHVU ='{2}' AND CHIPHI_THUTHUAT.MAKHOA ='{0}' AND CHIPHI_THUTHUAT.MAVAOVIEN = '{1}' " + (_MaNhom == "0" ? "" : " AND CHIPHI_THUTHUAT.MANHOM= " + _MaNhom)
                            + " GROUP BY MACHIPHI) AA"
                            + " INNER JOIN DMDICHVU ON DMDICHVU.MADICHVU = AA.MADICHVU"
                            + " inner join saclapphieu on saclapphieu.loaithuoc = dmdichvu.loaithuoc and saclapphieu.makhoa = '{0}' and SACLAPPHIEU.NHOMSO <> -1",
                            _MaKhoa,
                            MaVaoVien,
                            _LoaiDichVu, _ngaychidinh);
                        if (_NhomThuoc != -1)
                        {
                            SQLCmd.CommandText += " and saclapphieu.nhomso=" + _NhomThuoc;
                        }
                    }
                }
                
                SQLCmd.CommandText += ") BB GROUP BY MADICHVU,TENTHUOC";
                SQLCmd.CommandTimeout = 0;
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
            catch (Exception ex)
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
