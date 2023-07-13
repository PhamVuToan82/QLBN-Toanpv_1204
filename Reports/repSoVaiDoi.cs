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
    public partial class repSoVaiDoi : DataDynamics.ActiveReports.ActiveReport3
    {
        //private String _MaKhoa,_TenKhoa;
        //private object _Ngay;
        //private int _NhomThuoc;
        private int Page = 0;
        private int stt = 0;
        private decimal tongtien;
        private String _MaKhoa, _TenKhoa;
        bool _MuonVai;
        DateTime _TuNgay, _DenNgay;
        //private String _LuotIn;
        //System.Data.DataTable Table = new DataTable();

        public repSoVaiDoi(DateTime TuNgay, DateTime DenNgay, string TenKhoa)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            _TuNgay = TuNgay;
            _DenNgay = DenNgay;
            _TenKhoa = TenKhoa;
            //_MaKhoa = MaKhoa;
            //_NhomThuoc = NhomThuoc;
            //_Ngay = Ngay;
            //_TenKhoa = TenKhoa+ " - " +TenNhomLenCP;
            //_LuotIn = MaPhieuDuyet;
            //barcode1.Text = MaPhieuDuyet;
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
            //lblNgayThang.Text = String.Format("Thực hiện ngày {0:dd} tháng {0:MM} năm {0:yyyy}", _Ngay);
            //lblKhoa.Text = _TenKhoa;
            //if (_NhomThuoc == -1)
            //{
            //    lbSoYLenh.Text = "SỔ TỔNG HỢP THUỐC";
            //}
            //else
            //{
            //    if (_NhomThuoc == 0)
            //    {
            //        lbSoYLenh.Text = "SỔ THUỐC ỐNG";
            //    }
            //    else
            //    {
            //        lbSoYLenh.Text = "SỔ THUỐC VIÊN";
            //    }
            //}
        }

        private void repSoLenThuoc_DataInitialize(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            SQLCmd.CommandText = String.Format("select MaDoVai, TenDoVai from tblDoVai");
            int j = 1;
            //int k = 5;
            dr = SQLCmd.ExecuteReader();
            while (dr.Read())
            {
                foreach (DataDynamics.ActiveReports.Label lb in pageHeader.Controls)
                {
                    if (lb.Name == ("lb" + j.ToString()))
                    {
                        lb.Text = dr["TenDoVai"].ToString();
                        lb.Name = dr["MaDoVai"].ToString();
                        break;
                    }
                }
                foreach (DataDynamics.ActiveReports.Label _lb in detail.Controls)
                {
                    if (_lb.Name == ("lbl" + j.ToString()))
                    {
                        _lb.Name = dr["MaDoVai"].ToString();
                        _lb.DataField = dr["MaDoVai"].ToString();
                        break;
                    }
                }
                foreach (DataDynamics.ActiveReports.Label _lbl in reportFooter1.Controls)
                {
                    if (_lbl.Name == ("txt" + j.ToString()))
                    {
                        _lbl.Name = dr["MaDoVai"].ToString();
                        //_lbl.DataField = dr["MaDoVai"].ToString();
                        break;
                    }
                }
                j++;
            }
            dr.Close();
            SQLCmd.Dispose();
            DataDynamics.ActiveReports.DataSources.SqlDBDataSource _ds = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            _ds.ConnectionString = GlobalModuls.Global.glbConnectionString;
            _ds.SQL = String.Format("set dateformat dmy select a.MaKhamBenh as MaVaoVien,TenBenhNhan as HoTen, NamSinh as Tuoi,TenKhoa,ThoigianDangky,isnull(SUM(b.kyquy),0) as KyQuy  from NAMDINH_QLBN.dbo.tblbenhnhan_muonvai  a left join  NAMDINH_QLBN.dbo.tblbenhnhan_Vai_KyQuy b on a.MaKhambenh = b.MaKhamBenh ");
            if (_TenKhoa != "Tất Cả")
            {
                _ds.SQL = _ds.SQL + string.Format(" where a.ThoiGianDangKy between '{0:dd/MM/yyyy HH:mm}' and  '{1:dd/MM/yyyy HH:mm}' and a.TenKhoa = N'{2}'", _TuNgay, _DenNgay,_TenKhoa);
            }
            else
            {
                _ds.SQL = _ds.SQL + string.Format(" where a.ThoiGianDangKy between '{0:dd/MM/yyyy HH:mm}' and  '{1:dd/MM/yyyy HH:mm}'", _TuNgay, _DenNgay);
            }
            _ds.SQL = _ds.SQL + string.Format(" group by a.MaKhamBenh ,TenBenhNhan , NamSinh,TenKhoa,ThoigianDangky  order by TenKhoa,ThoigianDangky");
            this.DataSource = _ds;
            foreach (DataDynamics.ActiveReports.Label _lb in detail.Controls)
            {
                if (!Fields.Contains(Fields[_lb.DataField]))
                    Fields.Add(_lb.DataField);
            }
            foreach (DataDynamics.ActiveReports.Label _lbl in reportFooter1.Controls)
            {
                if (!Fields.Contains(Fields[_lbl.DataField]))
                    Fields.Add(_lbl.DataField);
            }
        }
        private void repSoLenThuoc_FetchData(object sender, FetchEventArgs eArgs)
        {
            try
            {
                System.Data.SqlClient.SqlDataReader dr;
                System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
                SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
                String MaVaoVien;
                MaVaoVien = Fields["MaVaoVien"].Value.ToString();
                SQLCmd.CommandText = string.Format(" select MaDoVai,TenDoVai,SUM(Soluong_doi) as SOLUONG,b.TenKhoa  from NAMDINH_QLBN.dbo.tblPhieuDoi_Vai a INNER join NAMDINH_QLBN.dbo.tblbenhnhan_muonvai b on a.MaKhamBenh = b.MaKhambenh where b.makhambenh = '{0}'"
                    + " GROUP BY b.TenKhoa,MaDoVai,TenDoVai order by MaDoVai", MaVaoVien);
                dr = SQLCmd.ExecuteReader();
                //bool DaCo = false;
                foreach (DataDynamics.ActiveReports.Label _lb in detail.Controls)
                {
                    if (_lb.DataField != "HoTen" && _lb.DataField != "Tuoi" && _lb.DataField != "ThoiGianDangKy" && _lb.DataField != "KyQuy")
                    {
                        Fields[_lb.DataField].Value = "";
                        break;
                    }
                }
                foreach (DataDynamics.ActiveReports.Label _lbl in reportFooter1.Controls)
                {
                    if (_lbl.DataField != "textBox2" && _lbl.DataField != "textBox43")
                    {
                        Fields[_lbl.DataField].Value = "";
                        break;
                    }
                }
                while (dr.Read())
                {
                    foreach (DataDynamics.ActiveReports.Label _lb in detail.Controls)
                    {
                        if (_lb.Name == dr["MaDoVai"].ToString())
                        {
                            Fields[dr["MaDoVai"].ToString()].Value = String.Format("{0:#,##0.##}", decimal.Parse(dr["SOLUONG"].ToString()));
                        }
                    }
                    foreach (DataDynamics.ActiveReports.Label _lbl in reportFooter1.Controls)
                        {
                            if (_lbl.Name == dr["MaDoVai"].ToString())
                            {
                            if (_lbl.Value == null)
                            {
                                //decimal.Parse(String.Format("{0:#,##0.##}", decimal.Parse(dr["SOLUONG"].ToString())));
                                _lbl.Value = decimal.Parse(String.Format("{0:#,##0.##}", decimal.Parse(dr["SOLUONG"].ToString())));
                                //_lbl.Value = (decimal)Fields[dr["MaDoVai"].ToString()].Value;
                                //_lbl.Value = (decimal)_lbl.Value + decimal.Parse(String.Format("{0:#,##0.##}", decimal.Parse(dr["SOLUONG"].ToString())));
                                //break;
                            }
                            else
                            {
                                //Fields[dr["MaDoVai"].ToString()].Value = (decimal)(Fields[dr["MaDoVai"].ToString()].Value) + decimal.Parse(String.Format("{0:#,##0.##}", decimal.Parse(dr["SOLUONG"].ToString())));
                                //_lbl.Value = (decimal)_lbl.Value + (decimal)(Fields[dr["MaDoVai"].ToString()].Value);
                                _lbl.Value = (decimal)_lbl.Value + decimal.Parse(String.Format("{0:#,##0.##}", decimal.Parse(dr["SOLUONG"].ToString())));
                                //break;
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
            stt = stt + 1;
            foreach (TextBox txt in detail.Controls)
            {
                lblGhiChu.Height = txt.Height = detail.Height; 
                
            }
            if(lblGhiChu.Text == "0")
            {
                lblGhiChu.Text = "";
            }
            else
            {
                tongtien = tongtien + decimal.Parse(String.Format("{0:#,##0.##}", decimal.Parse(lblGhiChu.Text)));
            }
            lblSTT.Value = stt;
        }

        private void reportFooter1_Format(object sender, EventArgs e)
        {
            textBox43.Text = tongtien.ToString();

        }

        private void repSoLenThuoc_PageStart(object sender, EventArgs e)
        {
            Page++;
            txtPage.Text = "Trang: " + Page.ToString();
        }
    }
}
