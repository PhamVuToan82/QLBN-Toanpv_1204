using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using System.Data;
using System.Data.SqlClient;
using GlobalModuls;

namespace NamDinh_QLBN.Reports
{
    /// <summary>
    /// Summary description for repSoLenThuoc.
    /// </summary>
    public partial class repSoLenThuoc_SuaKhoaDongY : DataDynamics.ActiveReports.ActiveReport3
    {
        private String _MaKhoa,_TenKhoa;
        private object _Ngay;
        private int _NhomThuoc;
        private int Page = 0;
        private String _LuotIn;
        System.Data.DataTable Table = new DataTable();

        public repSoLenThuoc_SuaKhoaDongY(String MaKhoa, int NhomThuoc, object Ngay, String TenKhoa, String MaPhieuDuyet)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            _MaKhoa = MaKhoa;
            _NhomThuoc = NhomThuoc;
            _Ngay = Ngay;
            _TenKhoa = TenKhoa;
            _LuotIn = MaPhieuDuyet;
            barcode1.Text = MaPhieuDuyet;
        }

        private void repSoLenThuoc_ReportStart(object sender, EventArgs e)
        {
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.PageSettings.Orientation = PageOrientation.Landscape;

            this.PageSettings.Margins.Left = (float)0.2;
            this.PageSettings.Margins.Right = (float)0.0;
            this.PageSettings.Margins.Top = (float)0.2;
            this.PageSettings.Margins.Bottom = (float)0.2;
            txtInNgay.Text = String.Format("In ngày {0:dd} tháng {0:MM} năm {0:yyyy}", Global.NgayLV);
            lblNgayThang.Text = String.Format("Thực hiện ngày {0:dd} tháng {0:MM} năm {0:yyyy}", _Ngay);
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
                SQLCmd.CommandText = String.Format("set dateformat mdy SELECT * FROM [" + Global.glbDuoc + "].DBO.DANHMUCTHUOC A"
                    + " INNER JOIN SACLAPPHIEU ON SACLAPPHIEU.LOAITHUOC = A.LOAITHUOC  "
                    + " inner join  "
                    + " (select * from"
                    + " (Select ct.MaDichVU from  (select SoPhieu from benhnhan_phieudieutri where makhoa = '{0}' and datediff(dd,NgayChiDinh,'{1:MM/dd/yyyy}') = 0) aa "
                    + " inner join phieudieutri_chitiet ct on  ct.SoPhieu = aa.SoPhieu  "
                    + " where ct.LoaiDichVu in  ('D01','D05') and CT.MaPhieuDuyet= '" + _LuotIn + "'"
                    + " union all "
                    + " select machiphi as Madichvu from chiphi_thuthuat where datediff(dd,NgayThucHien,'{1:MM/dd/yyyy}') = 0 and loaidichvu in ('D01','D05') and makhoa='{0}' and MaPhieuDuyet ='" + _LuotIn + "'"
                    + " ) bb group by MaDichvu) cc on cc.madichvu = A.ThuocID "
                    + " WHERE SACLAPPHIEU.MaKhoa='{0}' "
                    + " order by A.TenThuoc", _MaKhoa, _Ngay);
            }
            else
            {
                SQLCmd.CommandText = String.Format("set dateformat mdy SELECT * FROM   [" + Global.glbDuoc +"].DBO.DANHMUCTHUOC A  "
                    + " INNER JOIN SACLAPPHIEU ON SACLAPPHIEU.LOAITHUOC = A.LOAITHUOC  "
                    + " inner join  "
                    + " (select * from"
                    + " (Select ct.MaDichVU from  (select SoPhieu from benhnhan_phieudieutri where makhoa = '{0}' and datediff(dd,NgayChiDinh,'{1:MM/dd/yyyy}') = 0) aa "
                    + " inner join phieudieutri_chitiet ct on  ct.SoPhieu = aa.SoPhieu  "
                    + " where ct.LoaiDichVu in ('D01','D05')  and CT.MaPhieuDuyet= '" + _LuotIn + "'"
                    + " union  all"
                    + " select machiphi as Madichvu from chiphi_thuthuat where datediff(dd,NgayThucHien,'{1:MM/dd/yyyy}') = 0 and loaidichvu in ('D01','D05') and makhoa='{0}' and MaPhieuDuyet ='" + _LuotIn + "'"
                    + " ) bb group by MaDichvu) cc on cc.madichvu = A.ThuocID "
                    + " WHERE SACLAPPHIEU.NhomSo = {2} and SACLAPPHIEU.MaKhoa='{0}'"
                    + " order by A.TenThuoc", _MaKhoa,_Ngay,_NhomThuoc);
            }
           
            int j = 2;
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
     
            _ds.SQL = String.Format("set dateformat mdy Select * from"
                    + " (SELECT DD.MAVAOVIEN,DD.HOTEN,DD.TUOI,DMBUONGBENH.TENBUONG,dd.nhom,CASE WHEN DD.NHOM = 0 THEN N'Thuốc trong ngày' else N'Thuốc bất thường' end as Nhom1 FROM  "
                    + " (SELECT CC.*,BN.SOPHIEU,BN.NGAYCHIDINH,BN.NHOM FROM "
                    + " (SELECT BB.MAVAOVIEN,AA.HOTEN,YEAR(GETDATE()) - NAMSINH AS TUOI,BB.BUONG FROM "
                    + " (SELECT * FROM BENHNHAN) AA INNER JOIN BENHNHAN_CHITIET BB ON BB.MABENHNHAN = AA.MABENHNHAN) CC "
                    + " INNER JOIN BENHNHAN_PHIEUDIEUTRI BN ON BN.MAVAOVIEN = CC.MAVAOVIEN "
                    + " WHERE MAKHOA ='{0}' AND DATEDIFF(DD,NGAYCHIDINH,'{1:MM/dd/yyyy}') = 0) DD "
                    + " INNER JOIN PHIEUDIEUTRI_CHITIET CT ON CT.SOPHIEU = DD.SOPHIEU  "
                    + " LEFT JOIN DMBUONGBENH ON DMBUONGBENH.ID_BUONG = DD.BUONG AND DMBUONGBENH.MAKHOA='{0}' "
                    + " WHERE CT.LOAIDICHVU in ('D01','D05') and CT.MaPhieuDuyet= '" + _LuotIn + "'"
                    + " union all"
                    + " select aa.mavaovien,hoten,year(getdate()) - NamSinh as tuoi,tenbuong,1 as Nhom,N'Chi phí bất thường' as Nhom1 from "
                    + " (select * from chiphi_thuthuat where MaPhieuDuyet ='" + _LuotIn + "' and loaidichvu in ('D01','D05') and makhoa='{0}' and datediff(dd,ngaythuchien,'{1:MM/dd/yyyy}') = 0) aa"
                    + " inner join benhnhan_chitiet ct on ct.mavaovien = aa.mavaovien"
                    + " inner join benhnhan on benhnhan.mabenhnhan = ct.mabenhnhan"
                    + " LEFT JOIN DMBUONGBENH ON DMBUONGBENH.ID_BUONG = ct.BUONG AND DMBUONGBENH.MAKHOA='{0}') cc"
                    + " GROUP BY MAVAOVIEN,HOTEN,TUOI,TENBUONG,NHOM,Nhom1 "
                    + " ORDER BY NHOM,TENBUONG ", _MaKhoa, _Ngay);
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
                //if (Nhom == "1" ||)
                //{
                //    SQLCmd.CommandText = "SELECT BB.MADICHVU,BB.TENTHUOC,SUM(BB.SOLUONG) AS SOLUONG FROM (";
                //}
                SQLCmd.CommandText = "set dateformat mdy SELECT BB.MADICHVU,BB.TENTHUOC,SUM(BB.SOLUONG) AS SOLUONG,BB.LoaiDichVu,ISNULL(BB.ISVATTU,-1) AS ISVATTU FROM (";
                if (_NhomThuoc == -1)
                {
                    SQLCmd.CommandText += String.Format(" SELECT EE.MADICHVU,EE.SOLUONG,THUOC.TENTHUOC,ee.loaidichvu,VATTU.ISVATTU FROM "
                           + " (SELECT DD.MaVaoVien,CT.MADICHVU,sum(CT.SOLUONG) as soluong,CT.LoaiDichVu FROM "
                           + " (SELECT CC.*,BN.SOPHIEU,BN.NGAYCHIDINH FROM"
                           + " (SELECT BB.MAVAOVIEN,AA.HOTEN,YEAR(GETDATE()) - NAMSINH AS TUOI FROM"
                           + " (SELECT * FROM BENHNHAN) AA"
                           + " INNER JOIN BENHNHAN_CHITIET BB ON BB.MABENHNHAN = AA.MABENHNHAN) CC"
                           + " INNER JOIN BENHNHAN_PHIEUDIEUTRI BN ON BN.MAVAOVIEN = CC.MAVAOVIEN"
                           + " WHERE MAKHOA ='{0}' AND DATEDIFF(DD,NGAYCHIDINH,'{1:MM/dd/yyyy}') = 0 and bn.nhom={3}) DD"
                           + " INNER JOIN PHIEUDIEUTRI_CHITIET CT ON CT.SOPHIEU = DD.SOPHIEU "
                           + " WHERE CT.LOAIDICHVU in ('D01','D05','D06') and ct.MaPhieuDuyet = '" + _LuotIn + "' group by DD.MaVaoVien,CT.MADICHVU,CT.LoaiDichVu) EE"
                           + " INNER JOIN [" + Global.glbDuoc + "].DBO.DANHMUCTHUOC THUOC ON THUOC.THUOCID = EE.MADICHVU "
                           + " INNER JOIN SACLAPPHIEU ON SACLAPPHIEU.LOAITHUOC = THUOC.LOAITHUOC "
                           + " LEFT JOIN VATTU ON VATTU.MACHIPHI = THUOC.THUOCID AND VATTU.MAKHOA ='{0}'"
                           + " WHERE SACLAPPHIEU.makhoa='{0}' and SACLAPPHIEU.NHOMSO <> -1 AND EE.MAVAOVIEN = '{2}'",
                          _MaKhoa,
                           _Ngay,
                           MaVaoVien, Nhom);
                }
                else
                {
                    SQLCmd.CommandText += String.Format(" SELECT EE.MADICHVU,EE.SOLUONG,THUOC.TENTHUOC,ee.LoaiDichVu,VATTU.ISVATTU FROM "
                        + " (SELECT DD.MaVaoVien,CT.MADICHVU,sum(CT.SOLUONG) as soluong,CT.LoaiDichVu FROM "
                        + " (SELECT CC.*,BN.SOPHIEU,BN.NGAYCHIDINH FROM"
                        + " (SELECT BB.MAVAOVIEN,AA.HOTEN,YEAR(GETDATE()) - NAMSINH AS TUOI FROM"
                        + " (SELECT * FROM BENHNHAN) AA"
                        + " INNER JOIN BENHNHAN_CHITIET BB ON BB.MABENHNHAN = AA.MABENHNHAN) CC"
                        + " INNER JOIN BENHNHAN_PHIEUDIEUTRI BN ON BN.MAVAOVIEN = CC.MAVAOVIEN"
                        + " WHERE MAKHOA ='{0}' AND DATEDIFF(DD,NGAYCHIDINH,'{1:MM/dd/yyyy}') = 0 and bn.nhom={3}) DD"
                        + " INNER JOIN PHIEUDIEUTRI_CHITIET CT ON CT.SOPHIEU = DD.SOPHIEU "
                        + " WHERE CT.LOAIDICHVU in ('D01','D05','D06') and ct.MaPhieuDuyet = '" + _LuotIn + "' group by DD.MaVaoVien,CT.MADICHVU,CT.LoaiDichVu ) EE"
                        + " INNER JOIN [" + Global.glbDuoc + "].DBO.DANHMUCTHUOC THUOC ON THUOC.THUOCID = EE.MADICHVU "
                        + " INNER JOIN SACLAPPHIEU ON SACLAPPHIEU.LOAITHUOC = THUOC.LOAITHUOC "
                        + " LEFT JOIN VATTU ON VATTU.MACHIPHI = THUOC.THUOCID AND VATTU.MAKHOA ='{0}'"
                        + " WHERE SACLAPPHIEU.NHOMSO = " + _NhomThuoc + " AND SACLAPPHIEU.makhoa='{0}' and SACLAPPHIEU.NHOMSO <> -1 AND EE.MAVAOVIEN = '{2}'",
                       _MaKhoa,
                        _Ngay,
                         MaVaoVien, Nhom);
                }
                if (Nhom == "1")
                {
                    SQLCmd.CommandText += String.Format("UNION ALL "
                        + " SELECT DMDICHVU.MADICHVU,SOLUONG,DMDICHVU.TENDICHVU AS TENTHUOC,dmdichvu.Loaidichvu,VATTU.ISVATTU FROM "
                        + " (SELECT MACHIPHI AS MADICHVU,SUM(SOLUONG) AS SOLUONG FROM CHIPHI_THUTHUAT WHERE LOAIDICHVU in ('D01','D05','D06') AND MAKHOA ='{0}' AND MAVAOVIEN = '{1}' "
                        + " AND DATEDIFF(DD,NGAYTHUCHIEN,'{2:MM/dd/yyyy}') = 0 AND MaPhieuDuyet = '" + _LuotIn + "' GROUP BY MACHIPHI) AA"
                        + " INNER JOIN DMDICHVU ON DMDICHVU.MADICHVU = AA.MADICHVU"
                        + " inner join saclapphieu on saclapphieu.loaithuoc = dmdichvu.loaithuoc and saclapphieu.makhoa = '{0}' and SACLAPPHIEU.NHOMSO <> -1", _MaKhoa, MaVaoVien, _Ngay);
                    if (_NhomThuoc != -1)
                    {
                        SQLCmd.CommandText += " and saclapphieu.nhomso=" + _NhomThuoc;
                    }
                    SQLCmd.CommandText += String.Format(" LEFT JOIN VATTU ON VATTU.MACHIPHI = dmdichvu.madichvu AND VATTU.MAKHOA ='{0}'", _MaKhoa);
                }
                SQLCmd.CommandText += ") BB GROUP BY MADICHVU,TENTHUOC,Loaidichvu,ISVATTU";
                dr = SQLCmd.ExecuteReader();
                bool DaCo = false;
                lblGhiChu.Text = "";
                lblThuocDY.Text = "";
                foreach (DataDynamics.ActiveReports.TextBox _lb in detail.Controls)
                {
                    if (_lb.DataField != "HoTen" && _lb.DataField != "Tuoi" && _lb.DataField != "TENBUONG")
                    {
                        Fields[_lb.DataField].Value = "";
                    }
                }
                while (dr.Read())
                {
                    if (dr["LoaiDichVu"].ToString() == "D05")
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

                    if (dr["LoaiDichVu"].ToString() == "D06")
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

                    //if (dr["LoaiDichVu"].ToString() == "D05")
                    //{
                    //    lblThuocDY.Text = "1";
                    //}
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
    }
}
