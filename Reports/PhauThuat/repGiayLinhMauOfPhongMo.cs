using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace NamDinh_QLBN.Reports.PhauThuat
{
    /// <summary>
    /// Summary description for repPhieuLinhMau.
    /// </summary>
    public partial class repGiayLinhMauOfPhongMo : DataDynamics.ActiveReports.ActiveReport3
    {
        private String _MaVaoVien, _SoPhieuCD;
        public repGiayLinhMauOfPhongMo(String NgaySD,string MaVaoVien,String SophieuCD)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            lblNgayThang.Text = String.Format("Ngày {0:dd} tháng {0:MM} năm {0:yyyy}",GlobalModuls.Global.GetNgayLV());
            txtNgaySD.Text = NgaySD;
            _MaVaoVien = MaVaoVien;
            _SoPhieuCD = SophieuCD;

        }

        private void repPhieuLinhMau_ReportStart(object sender, EventArgs e)
        {
            this.PageSettings.Margins.Top = (float)0.7;
            this.PageSettings.Margins.Left = (float)0.8;
            this.PageSettings.Margins.Right = (float)0.0;
            this.PageSettings.Margins.Bottom = (float)0.5;
        }

        private void repGiayLinhMauOfPhongMo_DataInitialize(object sender, EventArgs e)
        {
            DataDynamics.ActiveReports.DataSources.SqlDBDataSource _ds = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            _ds.ConnectionString = GlobalModuls.Global.glbConnectionString;
            _ds.SQL = string.Format("SELECT A.HOTEN,N'Số vào viện: '+ b.MaVaoVien as SoVaoVien, Convert(char,year(D.NGAYCHIDINH) - A.NamSinh) as Tuoi,"
                + " CASE WHEN A.GIOITINH = 0 THEN N'Giới tính: Nữ' ELSE N'Giới tính: Nam' END AS GIOITINH,"
                + " N'Số bệnh án: ' + B.SOHSBA AS SOHSBA,C.CHANDOAN_TRUOCPT AS CHANDOAN,"
                + " E.LUONGMAU,CASE E.NHOMMAU WHEN  0 THEN '' WHEN 1 THEN 'A' WHEN 2 THEN 'AB' WHEN 3 THEN 'B' WHEN 4 THEN '0' END AS NHOMMAU,"
                + " E.TRUYENLAN,E.DATRUYEN,N'Cấp hoặc tự túc: ' + Case E.CAP_TUTUC when 0 then N'Cấp' else N'Tự túc' end AS CapHoacTT,E.LYDO,DV.TENDICHVU,BB.TENBUONG,GG.TENGIUONG  FROM "
                + " (BENHNHAN A INNER JOIN BENHNHAN_CHITIET B ON A.MABENHNHAN = B.MABENHNHAN)"
                + " INNER JOIN BENHNHAN_PHAUTHUAT C ON C.MAVAOVIEN = B.MAVAOVIEN"
                + " INNER JOIN BENHNHAN_PT_CHIPHI D ON D.MAVAOVIEN = B.MAVAOVIEN AND D.SOPHIEUCD = C.SOPHIEUCD"
                + " INNER JOIN DMDICHVU DV ON DV.MADICHVU = D.MADICHVU and DV.LOAIDICHVU ='D03'"
                + " INNER JOIN BENHNHAN_PT_MAU E ON E.MAVAOVIEN = B.MAVAOVIEN AND E.SOPHIEUCD = C.SOPHIEUCD"
                + " LEFT JOIN DMBUONGBENH BB ON BB.ID_BUONG = B.BUONG"
                + " LEFT JOIN DMGIUONGBENH GG ON GG.ID_GIUONG = B.GIUONG"
                + " WHERE B.MAVAOVIEN ='{0}' AND C.SOPHIEUCD ='{1}'", _MaVaoVien, _SoPhieuCD);
            this.DataSource = _ds;
        }
    }
}
