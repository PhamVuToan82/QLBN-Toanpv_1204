using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using System.Data;
using System.Data.SqlClient;
using GlobalModuls;

namespace NamDinh_QLBN.Reports.BaoCaoNoiTru
{
    /// <summary>
    /// Summary description for repSoLenThuoc.
    /// </summary>
    public partial class repSoLenThuocDangDieuTri_XuatAn : DataDynamics.ActiveReports.ActiveReport3
    {
        private String _TenKhoa, _MaKhoa;
        private int Page = 0;
        private int stt = 0;
        private decimal tongtien;
        System.Data.DataTable Table = new DataTable();

        public repSoLenThuocDangDieuTri_XuatAn(string MaKhoa, string TenKhoa)
        {
            InitializeComponent();
            _TenKhoa = TenKhoa;
            _MaKhoa = MaKhoa;
        }

        private void repSoLenThuoc_ReportStart(object sender, EventArgs e)
        {
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.PageSettings.Orientation = PageOrientation.Landscape;
            this.PageSettings.Margins.Left = (float)0.2;
            this.PageSettings.Margins.Right = (float)0.0;
            this.PageSettings.Margins.Top = (float)0.2;
            this.PageSettings.Margins.Bottom = (float)0.2;
            textBox4.Text = String.Format("In ngày {0:dd} tháng {0:MM} năm {0:yyyy}", Global.NgayLV);
            //lblNgayThang.Text = String.Format("Thực hiện ngày {0:dd} tháng {0:MM} năm {0:yyyy}", _Ngay);
            lbSoYLenh.Text = String.Format("XUẤT ĂN BỆNH NHÂN ĐANG ĐIỀU TRỊ");
            lblKhoa.Text = _TenKhoa;
            label6.Text = _TenKhoa;
        }

        private void repSoLenThuoc_DataInitialize(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            SQLCmd.CommandText = String.Format("select MaDichVu as MaThuoc , TenDichVu as TenThuoc from namdinh_sysdb.dbo.dmdichvu where loaidichvu = 'AN0'");
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
            _ds.SQL = String.Format("set dateformat dmy select distinct a.MaVaoVien,d.HoTen,d.NamSinh as Tuoi,a.NgayRaVien, case when a.datinhphi = 1 then N'X' else '' end as KyQuy from NAMDINH_QLBN.dbo.BENHNHAN_CHITIET a inner join NAMDINH_QLBN.dbo.BENHNHAN_PHIEUDIEUTRI b on a.MaVaoVien = b.MaVaoVien inner jOIN NAMDINH_QLBN.dbo.PHIEUDIEUTRI_CHITIET c on c.SoPhieu = b.SoPhieu inner join NAMDINH_QLBN.dbo.BENHNHAN d on d.MaBenhNhan = a.MaBenhNhan inner join NAMDINH_SYSDB.dbo.DMDICHVU e on e.MaDichvu = c.MaDichVu "
                                        + " where a.daravien = 0 and e.LoaiDichvu = 'AN0' and b.MaKhoa = '{0}'"
                                        + " order by a.MaVaoVien", _MaKhoa);
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
                String MaVaoVien;
                MaVaoVien = Fields["MaVaoVien"].Value.ToString();
                if (MaVaoVien == "") return;
                SQLCmd.CommandText = string.Format(" select  e.MaDichVu,e.TenDichvu as TENTHUOC,SUM(c.soluong) as SOLUONG  from NAMDINH_QLBN.dbo.BENHNHAN_CHITIET a inner join NAMDINH_QLBN.dbo.BENHNHAN_PHIEUDIEUTRI b on a.MaVaoVien = b.MaVaoVien inner jOIN NAMDINH_QLBN.dbo.PHIEUDIEUTRI_CHITIET c on c.SoPhieu = b.SoPhieu inner join NAMDINH_QLBN.dbo.BENHNHAN d on d.MaBenhNhan = a.MaBenhNhan inner join NAMDINH_SYSDB.dbo.DMDICHVU e on e.MaDichvu = c.MaDichVu "
                                                   + "    where  a.Mavaovien = '{0}' and c.LoaiDichvu = 'AN0'"
                                                    + "    group by e.MaDichvu, e.TenDichvu", MaVaoVien);
                dr = SQLCmd.ExecuteReader();
                bool DaCo = false;
                foreach (DataDynamics.ActiveReports.TextBox _lb in detail.Controls)
                {
                    if (_lb.DataField != "HoTen" && _lb.DataField != "Tuoi" && _lb.DataField != "KyQuy" && _lb.DataField != "NgayRaVien")
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
                return;

            }
          
        }

        private void detail_BeforePrint(object sender, EventArgs e)
        {
            stt = stt + 1;
            lblSTT.Value = stt;
        }

        private void reportFooter1_Format(object sender, EventArgs e)
        {
            //textBox43.Text = tongtien.ToString();
        }

        private void repSoLenThuoc_PageStart(object sender, EventArgs e)
        {
            Page++;
            txtPage.Text = "Trang: " + Page.ToString();
        }
    }
}
