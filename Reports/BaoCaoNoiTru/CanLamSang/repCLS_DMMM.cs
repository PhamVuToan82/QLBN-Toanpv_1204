using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace NamDinh_QLBN.Reports.BaoCaoNoiTru.CanLamSang
{
    /// <summary>
    /// Summary description for repCLS_ByBS.
    /// </summary>
    public partial class repCLS_DMMM : DataDynamics.ActiveReports.ActiveReport3
    {
        private System.DateTime _TNgay, _DNgay;
        private String _MaKhoa,_Like,_MaCLS,_MaBS;
        private bool _isTatCa = false, _isBatThuong = false, _isTrongNgay = false;
        public repCLS_DMMM(System.DateTime TNgay, System.DateTime DNgay, String MaKhoa, String TenKhoa)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent(); 
            _TNgay = TNgay;
            _DNgay = DNgay;
            _MaKhoa = MaKhoa;
            lbKhoa.Text = TenKhoa;
            System.TimeSpan Ngay1 = TNgay - DNgay;
            if (Ngay1.Days == 0)
            {
                lblNgayThang.Text = string.Format("Ngày {0:dd} tháng {0:MM} năm {0:yyyy}", TNgay);
            }
            else
            {
                lblNgayThang.Text = string.Format("Từ ngày {0:dd/MM/yyyy} đến ngày {1:dd/MM/yyyy}", TNgay, DNgay);
            }
        }

        private void repCLS_ByBS_ReportStart(object sender, EventArgs e)
        {
            this.Document.Name = "Danh sách bệnh nhân";
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.PageSettings.Orientation = PageOrientation.Portrait;

            this.PageSettings.Margins.Left = (float)0.5;
            this.PageSettings.Margins.Right = (float)0.25;
            this.PageSettings.Margins.Top = (float)0.25;
            this.PageSettings.Margins.Bottom = (float)0.2;
        }

        private void repCLS_ByBS_DataInitialize(object sender, EventArgs e)
        {
            DataDynamics.ActiveReports.DataSources.SqlDBDataSource _ds = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            _ds.ConnectionString = GlobalModuls.Global.glbConnectionString;
            _ds.SQL = String.Format("set dateformat dmy select b.mavaovien, a.HoTen,a.NamSinh,case when a.GioiTinh = 1 then N'Nam' else N'Nữ' end as GioiTinh,f.Tentat,e.TenDichvu,sum(d.soluong) as SoLuong,convert(date,c.NgayChiDinh) as NgayChiDinh"
                                    + " from NAMDINH_QLBN.dbo.BENHNHAN a inner join NAMDINH_QLBN.dbo.BENHNHAN_CHITIET b on a.mabenhnhan = b.mabenhnhan inner join NAMDINH_QLBN.dbo.benhnhan_phieudieutri c on c.MaVaoVien = b.MaVaoVien inner join NAMDINH_QLBN.dbo.PHIEUDIEUTRI_CHITIET d on d.SoPhieu = c.SoPhieu"
                                    + " inner join NAMDINH_SYSDB.dbo.DMDICHVU e on e.madichvu = d.madichvu"
                                    + " inner join namdinh_qlbn.dbo.DMKHOAPHONG f on f.MaKhoa = c.MaKhoa"
                                    + " where c.NgayChiDinh  between  '{0:dd/MM/yyyy}' and '{1:dd/MM/yyyy}' and e.madichvu = 'C50126'"
                                    + " group by b.mavaovien, a.GioiTinh, a.HoTen, a.NamSinh, f.Tentat, e.TenDichvu, convert(date,c.NgayChiDinh)"
                                    + " order by a.HoTen, NgayChiDinh", _TNgay, _DNgay, _MaKhoa);
            this.DataSource = _ds;
        }

        private void detail_BeforePrint(object sender, EventArgs e)
        {
            textBox1.Height = textBox2.Height = textBox3.Height = textBox4.Height = textBox5.Height = textBox6.Height =
                textBox7.Height = textBox9.Height = line2.Height = detail.Height;
        }

        private void detail_Format(object sender, EventArgs e)
        {
            textBox1.Text = string.Format("{0}", int.Parse(textBox1.Text) + 1);
        }

        private void pageFooter_Format(object sender, EventArgs e)
        {
            lbPage.Text = String.Format("{0}", int.Parse(lbPage.Text) + 1);
        }
    }
}
