using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace NamDinh_QLBN.Reports.BaoCaoNoiTru.PhauThuat
{
    /// <summary>
    /// Summary description for repCLS_ByBS.
    /// </summary>
    public partial class repPhauThuat_ByBS : DataDynamics.ActiveReports.ActiveReport3
    {
        private System.DateTime _TNgay, _DNgay;
        private String _MaKhoa,_MaLoaiPT,_MaBS;
        private bool _isTatCa = false, _isBatThuong = false, _isTrongNgay = false;
        public repPhauThuat_ByBS(System.DateTime TNgay, System.DateTime DNgay, String MaKhoa, String TenKhoa, bool isTatCa,
            bool isBatThuong,bool isTrongNgay,string MaLoaiPT,string MaBS)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent(); 
            _TNgay = TNgay;
            _DNgay = DNgay;
            _MaKhoa = MaKhoa;
            _MaLoaiPT = MaLoaiPT;
            _isBatThuong = isBatThuong;
            _isTatCa = isTatCa;
            _isTrongNgay = isTrongNgay;
            lbKhoa.Text = TenKhoa;
            _MaBS = MaBS;
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
            _ds.SQL = String.Format("SELECT B.SOHSBA,A.HOTEN,YEAR(C.NGAYCHIDINH) - A.NAMSINH AS TUOI,CASE WHEN A.GIOITINH = 0 THEN N'Nữ' ELSE N'Nam' END AS GIOITINH,"
                + " F.TENDT,C.NGAYCHIDINH,DMDICHVU.TENDICHVU,D.SOLUONG,DMDICHVU.DVT,DMBACSY.MABS,DMBACSY.TENBS,DMLOAIPHAUTHUAT.MALOAIPT,DMLOAIPHAUTHUAT.TENLOAIPT FROM"
                + " (BENHNHAN A INNER JOIN BENHNHAN_CHITIET B ON A.MABENHNHAN = B.MABENHNHAN)"
                + " INNER JOIN BENHNHAN_PHIEUDIEUTRI C ON C.MAVAOVIEN = B.MAVAOVIEN"
                + " INNER JOIN PHIEUDIEUTRI_CHITIET D ON D.SOPHIEU = C.SOPHIEU"
                + " INNER JOIN VIEWDOITUONGHIENTAI E ON E.MAVAOVIEN = B.MAVAOVIEN"
                + " INNER JOIN DMDOITUONGBN F ON F.MADT = E.DOITUONG"
                + " INNER JOIN DMPHAUTHUAT ON DMPHAUTHUAT.MADICHVU = D.MADICHVU AND DMPHAUTHUAT.LOAIDICHVU = D.LOAIDICHVU AND (DMPHAUTHUAT.LAPHAUTHUAT = 1 OR DMPHAUTHUAT.LAPHAUTHUAT = 3)"
                + " INNER JOIN DMDICHVU ON DMDICHVU.MADICHVU = DMPHAUTHUAT.MADICHVU"
                + " INNER JOIN DMLOAIPHAUTHUAT ON DMLOAIPHAUTHUAT.MALOAIPT = DMPHAUTHUAT.LOAIPHAUTHUAT AND LEFT(DMLOAIPHAUTHUAT.MALOAIPT,1) <>'5'"
                + " LEFT JOIN DMBACSY ON DMBACSY.MABS = C.MABS AND DMBACSY.MAKHOA = C.MAKHOA"
                + " WHERE C.MAKHOA ='{0}' AND DATEDIFF(DD,C.NGAYCHIDINH,'{1:MM/dd/yyyy}') <= 0 AND DATEDIFF(DD,C.NGAYCHIDINH,'{2:MM/dd/yyyy}') >= 0 ", _MaKhoa, _TNgay, _DNgay);
            if (_isTrongNgay)
            {
                _ds.SQL += " AND C.NHOM = 0";
            }
            if (_isBatThuong)
            {
                _ds.SQL += " AND C.NHOM = 1";
            }
            if (_MaLoaiPT == "0")
            {
               // _ds.SQL += string.Format(" AND D.LoaiDichVu LIKE '{0}' AND D.LoaiDichVu Not like '{1}'", _Like,_NotLike);
            }
            else
            {
                _ds.SQL += string.Format(" AND DMLOAIPHAUTHUAT.MALOAIPT LIKE '{0}'", _MaLoaiPT);
            }
            if (_MaBS != "0")
            {
                _ds.SQL += string.Format(" AND C.MABS = {0}", _MaBS);
            }
            _ds.SQL += " ORDER BY DMBACSY.TENBS,DMLOAIPHAUTHUAT.TENLOAIPT,A.HOTEN,DMDICHVU.TENDICHVU";
            this.DataSource = _ds;
        }

        private void detail_BeforePrint(object sender, EventArgs e)
        {
            textBox1.Height = textBox10.Height = textBox2.Height = textBox3.Height = textBox4.Height = textBox5.Height = textBox6.Height =
                textBox7.Height = textBox8.Height = textBox9.Height = detail.Height;
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
