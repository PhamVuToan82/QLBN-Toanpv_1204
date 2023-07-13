using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace NamDinh_QLBN.Reports.PhauThuat
{
    /// <summary>
    /// Summary description for repGiayXinMau.
    /// </summary>
    public partial class repGiayXinMauOfPhongMo : DataDynamics.ActiveReports.ActiveReport3
    {
        private string _MaVaoVien, _SoPhieu;
        public repGiayXinMauOfPhongMo(String MaVaoVien, String SoPhieu)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            _MaVaoVien = MaVaoVien;
            _SoPhieu = SoPhieu;
        }

        private void repGiayXinMau_ReportStart(object sender, EventArgs e)
        {
            this.PageSettings.Orientation = PageOrientation.Landscape;
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A5;
            this.PageSettings.Margins.Top = (float)0.4;
            this.PageSettings.Margins.Left = (float)0.5;
            this.PageSettings.Margins.Right = (float)0.4;
            this.PageSettings.Margins.Bottom = (float)0.5;
            lblNgayThang.Text = String.Format("{0:HH} giờ {0:mm} - Ngày {0:dd} tháng {0:MM} năm {0:yyyy}", GlobalModuls.Global.GetNgayLV());
        }

        private void repGiayXinMau_DataInitialize(object sender, EventArgs e)
        {
             DataDynamics.ActiveReports.DataSources.SqlDBDataSource _ds = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            _ds.ConnectionString = GlobalModuls.Global.glbConnectionString;
            _ds.SQL = string.Format("SELECT A.HOTEN,N'Số vào viện: '+B.MaVaoVien as SoVaoVien,N'Tuổi: ' + Convert(char,year(D.NGAYCHIDINH) - A.NamSinh) as Tuoi,"
                + " CASE WHEN A.GIOITINH = 0 THEN N'Giới tính: Nữ' ELSE N'Giới tính: Nam' END AS GIOITINH,"
                + " N'Số bệnh án: ' + B.SOHSBA AS SOHSBA,N'Chẩn doán:' + C.CHANDOAN_TRUOCPT AS CHANDOAN,"
                + " E.LUONGMAU,CASE E.NHOMMAU WHEN  0 THEN '' WHEN 1 THEN 'A' WHEN 2 THEN 'AB' WHEN 3 THEN 'B' WHEN 4 THEN '0' END AS NHOMMAU,"
                + " E.TRUYENLAN,DATRUYEN,N'Cấp hoặc tự túc: ' + Case E.CAP_TUTUC when 0 then N'Cấp' else N'Tự túc' end AS CapHoacTT,E.LYDO  FROM "
                + " (BENHNHAN A INNER JOIN BENHNHAN_CHITIET B ON A.MABENHNHAN = B.MABENHNHAN)"
                + " INNER JOIN BENHNHAN_PHAUTHUAT C ON C.MAVAOVIEN = B.MAVAOVIEN"
                + " INNER JOIN BENHNHAN_PT_CHIPHI D ON D.MAVAOVIEN = B.MAVAOVIEN AND D.SOPHIEUCD = C.SOPHIEUCD"
                + " INNER JOIN DMDICHVU DD ON DD.MADICHVU = D.MADICHVU AND DD.LOAIDICHVU ='D03'"
                + " INNER JOIN BENHNHAN_PT_MAU E ON E.MAVAOVIEN = B.MAVAOVIEN AND E.SOPHIEUCD = C.SOPHIEUCD"
                + " WHERE B.MAVAOVIEN ='{0}' AND C.SOPHIEUCD ='{1}'", _MaVaoVien, _SoPhieu);
            this.DataSource = _ds;
        }
    }
}
