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
    public partial class repSoLenThuoc_SuaKhoaDongYByLoaiDichVu : DataDynamics.ActiveReports.ActiveReport3
    {
        private String _MaKhoa,_TenKhoa;
        private object _Ngay;
        private int _NhomThuoc;
        private int Page = 0;
        private String _LuotIn;
        System.Data.DataTable Table = new DataTable();

        public repSoLenThuoc_SuaKhoaDongYByLoaiDichVu(String MaKhoa, int NhomThuoc, object Ngay, String TenKhoa, String MaPhieuDuyet)
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
            lbSoYLenh.Text = "SỔ THỰC HIỆN Y LỆNH Ở KHOA ĐÔNG Y";
        }

        private void repSoLenThuoc_DataInitialize(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            SQLCmd.CommandText = String.Format("set dateformat mdy SELECT DMDICHVU.TENDICHVU AS TENTHUOC,DMDICHVU.MADICHVU AS MATHUOC FROM"
                + " (BENHNHAN_PHIEUDIEUTRI A INNER JOIN PHIEUDIEUTRI_CHITIET B ON A.SOPHIEU = B.SOPHIEU)"
                + " INNER JOIN DMDICHVU ON DMDICHVU.MADICHVU = B.MADICHVU AND DMDICHVU.LOAIDICHVU = B.LOAIDICHVU"
                + " WHERE B.LOAIDICHVU IN ('C02') AND DATEDIFF(DD,A.NGAYCHIDINH,'{0:MM/dd/yyyy}') = 0"
                + " GROUP BY DMDICHVU.TENDICHVU,DMDICHVU.MADICHVU ORDER BY DMDICHVU.TENDICHVU",_Ngay);
            int j = 2;
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
     
            _ds.SQL = String.Format("set dateformat mdy Select * from"
                    + " (SELECT DD.MAVAOVIEN,DD.HOTEN,DD.TUOI,DMBUONGBENH.TENBUONG,dd.nhom,CASE WHEN DD.NHOM = 0 THEN N'Thuốc trong ngày' else N'Thuốc bất thường' end as Nhom1 FROM  "
                    + " (SELECT CC.*,BN.SOPHIEU,BN.NGAYCHIDINH,BN.NHOM FROM "
                    + " (SELECT BB.MAVAOVIEN,AA.HOTEN,YEAR(GETDATE()) - NAMSINH AS TUOI,BB.BUONG FROM "
                    + " (SELECT * FROM BENHNHAN) AA INNER JOIN BENHNHAN_CHITIET BB ON BB.MABENHNHAN = AA.MABENHNHAN) CC "
                    + " INNER JOIN BENHNHAN_PHIEUDIEUTRI BN ON BN.MAVAOVIEN = CC.MAVAOVIEN "
                    + " WHERE MAKHOA ='{0}' AND DATEDIFF(DD,NGAYCHIDINH,'{1:MM/dd/yyyy}') = 0) DD "
                    + " INNER JOIN PHIEUDIEUTRI_CHITIET CT ON CT.SOPHIEU = DD.SOPHIEU  "
                    + " LEFT JOIN DMBUONGBENH ON DMBUONGBENH.ID_BUONG = DD.BUONG AND DMBUONGBENH.MAKHOA='{0}' "
                    + " WHERE CT.LOAIDICHVU IN ('D05','C02')"
                    + " union all"
                    + " select aa.mavaovien,hoten,year(getdate()) - NamSinh as tuoi,tenbuong,1 as Nhom,N'Chi phí bất thường' as Nhom1 from "
                    + " (select * from chiphi_thuthuat where makhoa='{0}' and datediff(dd,ngaythuchien,'{1:MM/dd/yyyy}') = 0 and loaidichvu in ('D05','C02')) aa"
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
                SQLCmd.CommandText = string.Format("set dateformat mdy SELECT A.MAVAOVIEN,B.MADICHVU,B.LOAIDICHVU FROM"
                    + " (BENHNHAN_PHIEUDIEUTRI A INNER JOIN PHIEUDIEUTRI_CHITIET B ON A.SOPHIEU = B.SOPHIEU)"
                    + " WHERE B.LOAIDICHVU IN ('D05','C02') AND A.MAKHOA ='{0}' AND DATEDIFF(DD,A.NGAYCHIDINH,'{1:MM/dd/yyyy}') = 0 AND A.MAVAOVIEN ='{2}'"
                    + " GROUP BY A.MAVAOVIEN,B.MADICHVU,B.LOAIDICHVU", _MaKhoa, _Ngay, MaVaoVien);
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
                    if (dr["LoaiDichVu"].ToString() == "C02")
                    {
                        DaCo = false;
                        foreach (DataDynamics.ActiveReports.TextBox _lb in detail.Controls)
                        {
                            if (_lb.Name == dr["MaDichVu"].ToString())
                            {
                                Fields[dr["MaDichVu"].ToString()].Value = "X";
                                DaCo = true;
                            }
                        }
                        if (!DaCo)
                        {
                            if (lblGhiChu.Text == "")
                            {
                                lblGhiChu.Text += dr["TenThuoc"].ToString() + "-X";
                            }
                            else
                            {
                                lblGhiChu.Text += "\n " + dr["TenThuoc"].ToString() + "-X";
                            }
                        }
                    }
                    if (dr["LoaiDichVu"].ToString() == "D05")
                    {
                        lblThuocDY.Text = "1";
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
    }
}
