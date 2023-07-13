using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using System.Data;
using System.Data.SqlClient;
using GlobalModuls;

namespace NamDinh_QLBN.Reports.PhauThuat
{
    /// <summary>
    /// Summary description for repSoLenThuoc.
    /// </summary>
    public partial class repSoLenThuoc_ByKhoa : DataDynamics.ActiveReports.ActiveReport3
    {
        private String _MaKhoa,_TenKhoa,_KhoaNhom, _TenNhom;
        private object _Ngay;
        private int _NhomThuoc;
        private int Page = 0;
        private String _LuotIn;
        System.Data.DataTable Table = new DataTable();

        public repSoLenThuoc_ByKhoa(String MaKhoa, int NhomThuoc, object Ngay, String TenKhoa, String MaPhieuDuyet, String KhoaNhom, String TenNhom)
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
            _KhoaNhom = KhoaNhom;
            _TenNhom = TenNhom;
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
                lbSoYLenh.Text = "SỔ TỔNG HỢP THUỐC \n" + _TenNhom ;
            }
            else
            {
                if (_NhomThuoc == 0)
                {
                    lbSoYLenh.Text = "SỔ THUỐC ỐNG \n" + _TenNhom;
                }
                else
                {
                    lbSoYLenh.Text = "SỔ THUỐC VIÊN \n" + _TenNhom;
                }
            }
        }

        private void repSoLenThuoc_DataInitialize(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            SQLCmd.CommandTimeout = 0;
            //SQLCmd.CommandText = String.Format("set dateformat dmy SELECT MATHUOC,TENTHUOC FROM SOTHUOC "
            //        + " INNER JOIN [" + Global.glbDuoc + "].DBO.DANHMUCTHUOC A ON A.THUOCID = SOTHUOC.MATHUOC "
            //        + " INNER JOIN SACLAPPHIEU ON SACLAPPHIEU.LOAITHUOC = SOTHUOC.LOAITHUOC "
            //        + " inner join  "
            //        + " (SELECT * FROM BENHNHAN_PT_CHIPHI WHERE DATEDIFF(DD,NGAYCHIDINH,'{0:dd/MM/yyyy}') = 0 and BENHNHAN_PT_CHIPHI.NhomLenChiPhi = '{1}') CC ON CC.MaDichVu = SoThuoc.MaThuoc "
            //        + " WHERE ", _Ngay,_KhoaNhom);
            //SQLCmd.CommandText += String.Format(" SACLAPPHIEU.MaKhoa = '{0}'", _MaKhoa);
            //if (_NhomThuoc == -1)//In chung mot so
            //{
            //}
            //else
            //{
            //    SQLCmd.CommandText += String.Format(" and SACLAPPHIEU.NhomSO = {0}",_NhomThuoc);
            //}
            //SQLCmd.CommandText += " GROUP BY MATHUOC,TENTHUOC,STT Order by STT";
            SQLCmd.CommandText = String.Format("set dateformat dmy SELECT  a.Thuocid as MATHUOC,a.TENTHUOC FROM "
          + "   [" + Global.glbDuoc + "].DBO.DANHMUCTHUOC A   "
          + " INNER JOIN SACLAPPHIEU ON SACLAPPHIEU.LOAITHUOC = a.LOAITHUOC "
          + " inner join  "
          + " (SELECT * FROM BENHNHAN_PT_CHIPHI WHERE DATEDIFF(DD,NGAYCHIDINH,'{0:dd/MM/yyyy}') = 0 and LOAICHIPHI IN ('D01') and BENHNHAN_PT_CHIPHI.NhomLenChiPhi = '{1}') CC ON CC.MaDichVu = A.ThuocID "
          + " WHERE ", _Ngay, _KhoaNhom);
            SQLCmd.CommandText += String.Format(" SACLAPPHIEU.MaKhoa = '{0}'", _MaKhoa);
            if (_NhomThuoc == -1)//In chung mot so
            {
            }
            else
            {
                SQLCmd.CommandText += String.Format(" and SACLAPPHIEU.NhomSO = {0}", _NhomThuoc);
            }
            SQLCmd.CommandText += " GROUP BY a.Thuocid,TENTHUOC Order by TENTHUOC";
            int j = 1;
            dr = SQLCmd.ExecuteReader();
            while (dr.Read())
            {
                foreach (DataDynamics.ActiveReports.Label lb in pageHeader.Controls)
                {
                    if (lb.Name == ("lb" + j.ToString()))
                    {
                        lb.Text = dr["TenThuoc"].ToString();
                        lb.Name = dr["MaThuoc"].ToString();
                        break;
                    }
                }
                foreach (DataDynamics.ActiveReports.TextBox _lb in detail.Controls)
                {
                    if (_lb.Name == ("lbl" + j.ToString()))
                    {
                        _lb.Name = dr["MaThuoc"].ToString();
                        _lb.DataField = dr["MaThuoc"].ToString();
                        break;
                    }
                }
                foreach (DataDynamics.ActiveReports.TextBox _lb in reportFooter1.Controls)
                {
                    if (_lb.Name == ("txt" + j.ToString()))
                    {
                        _lb.Name = dr["MaThuoc"].ToString();
                        break;
                    }
                }
                j++;
            }
            dr.Close();
            SQLCmd.Dispose();

            
            DataDynamics.ActiveReports.DataSources.SqlDBDataSource _ds = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();

            _ds.ConnectionString = GlobalModuls.Global.glbConnectionString;
            _ds.SQL = String.Format("set dateformat dmy SELECT ISNULL(C.MAPHIEUDUYET,'') AS MAPHIEUDUYET,N'Chi phí bất thường' AS NHOM1,1 AS NHOM,B.MAVAOVIEN,A.HOTEN,YEAR(C.NGAYCHIDINH) - A.NAMSINH AS TUOI,DMKHOAPHONG.TENTAT AS TENBUONG FROM"
                   + " (BENHNHAN A INNER JOIN BENHNHAN_CHITIET B ON A.MABENHNHAN = B.MABENHNHAN)"
                   + " INNER JOIN BENHNHAN_PT_CHIPHI C ON C.MAVAOVIEN = B.MAVAOVIEN"
                   + " INNER JOIN BENHNHAN_PHIEUDIEUTRI D ON D.SOPHIEU = C.SOPHIEUCD"
                   + " INNER JOIN DMKHOAPHONG ON DMKHOAPHONG.MAKHOA = D.MAKHOA"
                   + " WHERE DATEDIFF(DD,C.NGAYCHIDINH,'{0:dd/MM/yyyy}') = 0 AND C.MAPHIEUDUYET ='{1}' AND C.LOAICHIPHI IN ('D01') and C.NhomLenChiPhi = '{2}'"
                   + " GROUP BY C.MAPHIEUDUYET,B.MAVAOVIEN,A.HOTEN,C.NGAYCHIDINH,A.NAMSINH,DMKHOAPHONG.TENTAT"
                   + " ORDER BY DMKHOAPHONG.TENTAT ", _Ngay, _LuotIn,_KhoaNhom);
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
                SQLCmd.CommandTimeout = 0;
                SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
                String MaVaoVien, Nhom;
                MaVaoVien = Fields["MaVaoVien"].Value.ToString();
                Nhom = Fields["Nhom"].Value.ToString();
                if (Nhom == "") return;

                SQLCmd.CommandText = String.Format("set dateformat dmy SELECT C.MAVAOVIEN,ISNULL(C.MAPHIEUDUYET,'') AS MAPHIEUDUYET,DMDICHVU.MADICHVU,"
                    + " SUM(C.SOLUONG) AS SOLUONG,1 AS NHOM,DMDICHVU.TENDICHVU AS TENTHUOC,ISNULL(VATTU.ISVATTU,-1) AS ISVATTU  FROM"
                    + " (BENHNHAN A INNER JOIN BENHNHAN_CHITIET B ON A.MABENHNHAN = B.MABENHNHAN)"
                    + " INNER JOIN BENHNHAN_PT_CHIPHI C ON C.MAVAOVIEN = B.MAVAOVIEN"
                    + " INNER JOIN DMDICHVU ON DMDICHVU.MADICHVU = C.MADICHVU"
                    + " INNER JOIN SACLAPPHIEU ON SACLAPPHIEU.LOAITHUOC = DMDICHVU.LOAITHUOC"
                    + " LEFT JOIN VATTU ON VATTU.MACHIPHI = C.MADICHVU"
                    + " WHERE DATEDIFF(DD,C.NGAYCHIDINH,'{0:dd/MM/yyyy}') = 0 AND C.LOAICHIPHI IN ('D01') AND C.MAVAOVIEN = '{1}'",
                    _Ngay,MaVaoVien);
                if (_NhomThuoc == -1)
                {
                    SQLCmd.CommandText += String.Format(" AND SACLAPPHIEU.NHOMSO <> -1 AND SACLAPPHIEU.MAKHOA='{0}' And C.NhomLenChiPhi = '{1}'", _MaKhoa,_KhoaNhom);
                }
                else
                {
                    SQLCmd.CommandText += String.Format(" AND SACLAPPHIEU.NHOMSO = {1} AND  SACLAPPHIEU.NHOMSO <> -1 AND SACLAPPHIEU.MAKHOA='{0}' and  C.NhomLenChiPhi = '{2}'", _MaKhoa, _NhomThuoc,_KhoaNhom);
                }
                SQLCmd.CommandText += " GROUP BY C.MAPHIEUDUYET,B.MAVAOVIEN,C.NGAYCHIDINH,DMDICHVU.TENDICHVU,DMDICHVU.MADICHVU,C.MAVAOVIEN,VATTU.ISVATTU";
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
                        if (dr["isVatTu"].ToString() == "1") continue;
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
                System.Windows.Forms.MessageBox.Show("Không có chi phí của bệnh nhân nào");return;
                //System.Windows.Forms.MessageBox.Show(ex.ToString());
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
