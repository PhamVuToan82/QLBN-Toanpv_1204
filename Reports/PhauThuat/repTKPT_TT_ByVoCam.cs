using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace NamDinh_QLBN.Reports.PhauThuat
{
    /// <summary>
    /// Summary description for repCLS_ByBS.
    /// </summary>
    public partial class  repTKPT_TT_ByVoCam : DataDynamics.ActiveReports.ActiveReport3
    {
        private System.DateTime _TNgay, _DNgay;
        private String _MaKhoa,_MaLoaiTT,_MaBS;
        private bool _isTatCa = false, _isBatThuong = false, _isTrongNgay = false;
        public repTKPT_TT_ByVoCam(System.DateTime TNgay, System.DateTime DNgay)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent(); 
            _TNgay = TNgay;
            _DNgay = DNgay;
            //_MaKhoa = MaKhoa;
            //_MaLoaiTT = MaLoaiTT;
            //_isBatThuong = isBatThuong;
            //_isTatCa = isTatCa;
            //_isTrongNgay = isTrongNgay;
            //lbKhoa.Text = TenKhoa;
            //_MaBS = MaBS;
            System.TimeSpan Ngay1 = TNgay - DNgay;
            if (Ngay1.Days == 0)
            {
                label39.Text = string.Format("Thanh Toán từ Ngày {0:dd} tháng {0:MM} năm {0:yyyy}", TNgay);
            }
            else
            {
                label39.Text = string.Format("Thanh Toán từ ngày {0:dd/MM/yyyy} đến ngày {1:dd/MM/yyyy}", TNgay, DNgay);
            }
        }

        private void repCLS_ByBS_ReportStart(object sender, EventArgs e)
        {
            this.Document.Name = "Danh sách bệnh nhân";
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.PageSettings.Orientation = PageOrientation.Landscape;

            this.PageSettings.Margins.Left = (float)0.2;
            this.PageSettings.Margins.Right = (float)0.0;
            this.PageSettings.Margins.Top = (float)0.25;
            this.PageSettings.Margins.Bottom = (float)0.2;
        }

        private void repCLS_ByBS_DataInitialize(object sender, EventArgs e)
        {
            DataDynamics.ActiveReports.DataSources.SqlDBDataSource _ds = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            _ds.ConnectionString = GlobalModuls.Global.glbConnectionString;
            _ds.SQL = String.Format("set dateformat dmy select a.MaKhambenh, a.HoTen, a.Namsinh, a.MaDTThe + a.SotheBHYT as Sothe, a.NgayKham, a.Ngayra, b.MaPhieuCD,REPLACE(dv.masobyt,'.',',') as MasoBYT, dv.TenXML, b.Soluong, b.DongiaBHYT, b.TyLe, b.TyLeBH, b.Thanhtien, khoa.TenKhoa, d.TenVoCam, pppt.TenPPPT,loaipt.TenLoaiPT from NAMDINH_VIENPHI.dbo.tblTHANHTOANBHYT a inner join NAMDINH_VIENPHI.dbo.tblTHANHTOANBHYT_CT b on a.Id = b.ID "
                                   + "inner join NAMDINH_QLBN.dbo.BENHNHAN_PHAUTHUAT c on c.MaVaoVien = a.MaKhambenh and c.MaPT = b.MaDichvu and c.SoPhieuCD = b.MaPhieuCD "
                                   + "inner join NAMDINH_SYSDB.dbo.DMDICHVU dv on dv.MaDichvu = b.MaDichvu "
                                   + "inner join NAMDINH_SYSDB.dbo.DMKHOAPHONG khoa on khoa.MaKhoa = b.Makhoa "
                                   + "left join NAMDINH_QLBN.dbo.DMVOCAM d on d.MaVoCam = c.PPVoCam "
                                   + "left join NAMDINH_QLBN.dbo.DMPHUONGPHAPPT pppt on pppt.MaPPPT = c.PhuongPhapPT_Ma "
                                   + " left join NAMDINH_QLBN.dbo.DMPHAUTHUAT  pt on pt.MaDichVu = b.MaDichvu"
                                   + " left join NAMDINH_QLBN.dbo.DMLOAIPHAUTHUAT loaipt on loaipt.MaLoaiPT = pt.LoaiPhauThuat"
                                   + " where a.ThoigianThanhtoan between '{0:dd/MM/yyyy}' and '{1:dd/MM/yyyy}'  and a.Phieuhuy = 0 and b.Ischenh = 0 order by TenVoCam,TenKhoa,HoTen", _TNgay, _DNgay);
            this.DataSource = _ds;
        }

        private void detail_BeforePrint(object sender, EventArgs e)
        {
            textBox1.Height = textBox10.Height = textBox2.Height = textBox3.Height = textBox4.Height = textBox5.Height = textBox6.Height =
                textBox7.Height = textBox8.Height = textBox9.Height = textBox9.Height = textBox10.Height = textBox11.Height = textBox12.Height = textBox13.Height
                = textBox14.Height = textBox15.Height = textBox16.Height = textBox17.Height = textBox18.Height = textBox19.Height = detail.Height;
        }

        private void detail_Format(object sender, EventArgs e)
        {
            textBox1.Text = string.Format("{0}", int.Parse(textBox1.Text) + 1);
        }
    }
}
