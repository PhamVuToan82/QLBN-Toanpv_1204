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
    public partial class repSoLenThuoc_Vai : DataDynamics.ActiveReports.ActiveReport3
    {
        private String _TenKhoa;
        private int Page = 0;
        private int stt = 0;
        private decimal tongtien;
        DateTime _TuNgay, _DenNgay;
        System.Data.DataTable Table = new DataTable();

        public repSoLenThuoc_Vai(DateTime TuNgay, DateTime DenNgay, string TenKhoa)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            _TenKhoa = TenKhoa;
            _TuNgay = TuNgay; _DenNgay = DenNgay;
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
            txtInNgay.Text = String.Format("In ngày {0:dd} tháng {0:MM} năm {0:yyyy}", Global.NgayLV);
            //lblNgayThang.Text = String.Format("Thực hiện ngày {0:dd} tháng {0:MM} năm {0:yyyy}", _Ngay);
            lbSoYLenh.Text = String.Format("Từ ngày {0:dd} tháng {0:MM} năm {0:yyyy}\nĐến ngày {1:dd} tháng {1:MM} năm {1:yyyy}",_TuNgay,_DenNgay);
            //lblKhoa.Text = Global.glbUName;
        }

        private void repSoLenThuoc_DataInitialize(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            SQLCmd.CommandText = String.Format("select MaDoVai as MaThuoc , TenDoVai as TenThuoc from tblDoVai");
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
            _ds.SQL = String.Format("set dateformat dmy select a.MaKhamBenh as MaVaoVien,TenBenhNhan as HoTen, NamSinh as Tuoi,TenKhoa,ThoiGianDangKy,isnull(SUM(b.kyquy),0) as KyQuy  from NAMDINH_QLBN.dbo.tblbenhnhan_muonvai  a left join  NAMDINH_QLBN.dbo.tblbenhnhan_Vai_KyQuy b on a.MaKhambenh = b.MaKhamBenh ");
            if (_TenKhoa != "Tất Cả")
            {
                _ds.SQL = _ds.SQL + string.Format(" where a.ThoiGianDangKy between '{0:dd/MM/yyyy HH:mm}' and  '{1:dd/MM/yyyy HH:mm}' and a.TenKhoa = N'{2}'", _TuNgay, _DenNgay, _TenKhoa);
            }
            else
            {
                _ds.SQL = _ds.SQL + string.Format(" where a.ThoiGianDangKy between '{0:dd/MM/yyyy HH:mm}' and  '{1:dd/MM/yyyy HH:mm}'", _TuNgay, _DenNgay);
            }
            _ds.SQL = _ds.SQL + string.Format(" group by a.MaKhamBenh ,TenBenhNhan , NamSinh,TenKhoa,ThoiGianDangKy  order by TenKhoa,ThoiGianDangKy");
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
                String MaVaoVien, TenKhoa;
                MaVaoVien = Fields["MaVaoVien"].Value.ToString();
                if (MaVaoVien == "") return;
                SQLCmd.CommandText = string.Format(" select MaDoVai as MADICHVU ,TenDoVai as TENTHUOC,SUM(Soluong) as SOLUONG, '' AS GhiChu from NAMDINH_QLBN.dbo.tblPhieuMuon_Vai a INNER join NAMDINH_QLBN.dbo.tblbenhnhan_muonvai b on a.MaKhamBenh = b.MaKhambenh where a.makhambenh = '{0}'"
                                                    + " GROUP BY MaDoVai,TenDoVai ", MaVaoVien);
                dr = SQLCmd.ExecuteReader();
                bool DaCo = false;
                lblGhiChu.Text = "";
                foreach (DataDynamics.ActiveReports.TextBox _lb in detail.Controls)
                {
                    if (_lb.DataField != "HoTen" && _lb.DataField != "Tuoi" && _lb.DataField != "KyQuy" && _lb.DataField != "ThoiGianDangKy")
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
                            //if (dr["GhiChu"].ToString() != "")
                            //    Fields[dr["MaDichVu"].ToString()].Value = String.Format("{0:#,##0.##}",decimal.Parse(dr["SoLuong"].ToString())) + "\n" + dr["GhiChu"].ToString();
                            //else
                                Fields[dr["MaDichVu"].ToString()].Value = String.Format("{0:#,##0.##}", decimal.Parse(dr["SoLuong"].ToString()));
                            DaCo = true;
                        }
                    }
                    if (!DaCo)
                    {
                        //if (dr["GhiChu"].ToString() != "")
                        //{
                        //    if (lblGhiChu.Text == "")
                        //        lblGhiChu.Text += dr["TenThuoc"].ToString() + "- " + String.Format("{0:#,##0.##}", decimal.Parse(dr["SoLuong"].ToString())) + "(" + dr["GhiChu"].ToString() + ")";
                        //    else
                        //        lblGhiChu.Text += "\n " + dr["TenThuoc"].ToString() + "- " + String.Format("{0:#,##0.##}", decimal.Parse(dr["SoLuong"].ToString())) + "(" + dr["GhiChu"].ToString() + ")";
                        //}
                        //else
                        //{
                        //    if (lblGhiChu.Text == "")
                        //        lblGhiChu.Text += dr["TenThuoc"].ToString() + "- " + String.Format("{0:#,##0.##}", decimal.Parse(dr["SoLuong"].ToString()));
                        //    else
                        //        lblGhiChu.Text += "\n " + dr["TenThuoc"].ToString() + "- " + String.Format("{0:#,##0.##}", decimal.Parse(dr["SoLuong"].ToString()));
                        //}
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
                return;
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
            if (lblGhiChu.Text == "0")
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
