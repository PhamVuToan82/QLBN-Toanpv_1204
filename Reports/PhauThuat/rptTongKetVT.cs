using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace NamDinh_QLBN.Reports.PhauThuat
{
    /// <summary>
    /// Summary description for rptPhieuLinhThuoc.
    /// </summary>
    public partial class rptTongKetVT : DataDynamics.ActiveReports.ActiveReport3
    {
        int page = 0;
        DateTime _TNgay,_DNgay;
        string _MaNhom, _TenNhom;
        int _NhomThuocVatTu;
        public rptTongKetVT(DateTime TNgay,DateTime DNgay, string MaNhom, string TenNhom, int NhomThuocVatTu)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            _TNgay = TNgay;
            _DNgay = DNgay;
            _MaNhom = MaNhom;
            _TenNhom = TenNhom;
            _NhomThuocVatTu = NhomThuocVatTu;
            lblNgayBC.Text = String.Format("{2} \n Từ ngày {0:dd/MM/yyyy} đến ngày {1:dd/MM/yyyy}", _TNgay,_DNgay,_TenNhom);
        }

        private void rptPhieuLinhThuoc_ReportStart(object sender, EventArgs e)
        {
            this.Document.Name = "Phiếu tổng kết vật tư";
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.PageSettings.Orientation = PageOrientation.Portrait;

            this.PageSettings.Margins.Left = (float)0.4;
            this.PageSettings.Margins.Right = (float)0.25;
            this.PageSettings.Margins.Top = (float)1;
            this.PageSettings.Margins.Bottom = (float)0.10;

            lblNgayIn.Text = string.Format("In ngày {0:dd} tháng {0:MM} năm {0:yyyy}", GlobalModuls.Global.NgayLV);
        }

        private void detail_Format(object sender, EventArgs e)
        {
            STT.Text =string.Format("{0}", int.Parse(STT.Text) + 1);
        }

        private void detail_BeforePrint(object sender, EventArgs e)
        {
            STT.Height = textBox2.Height = textBox3.Height = textBox4.Height = textBox5.Height = this.detail.Height = textBox12.Height = textBox1.Height;
        }

        private void reportFooter1_Format(object sender, EventArgs e)
        {
        }

        private void groupHeader1_Format(object sender, EventArgs e)
        {
            STT.Text = "0";
        }

        private void rptPhieulinhThuoc_PageStart(object sender, EventArgs e)
        {
            page += 1;
            txtPage.Text = "Trang " + page.ToString();
        }

        private void rptTongKetVT_DataInitialize(object sender, EventArgs e)
        {
            DataDynamics.ActiveReports.DataSources.SqlDBDataSource _ds = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            _ds.ConnectionString = GlobalModuls.Global.glbConnectionString;
            if (_MaNhom == "0")
            {
                _ds.SQL = String.Format("SELECT A.LOAICHIPHI,DMDICHVU.TENDICHVU,DMDICHVU.DVT,SUM(SOLUONG) AS SOLUONG,'0' as NhomLenChiPhi FROM"
                    + " (BENHNHAN_PT_CHIPHI A INNER JOIN DMDICHVU ON A.MADICHVU = DMDICHVU.MADICHVU)"
                    + " WHERE  DATEDIFF(DD,A.NGAYCHIDINH,'{0:MM/dd/yyyy}') <= 0 AND DATEDIFF(DD,A.NGAYCHIDINH,'{1:MM/dd/yyyy}') >= 0 AND", _TNgay, _DNgay);
                if (_NhomThuocVatTu == 0)
                {
                    _ds.SQL += " A.LOAICHIPHI IN ('D02')";
                }
                if (_NhomThuocVatTu == 1)
                {
                    _ds.SQL += " A.LOAICHIPHI IN ('D06')";
                }

                _ds.SQL += " GROUP BY A.LOAICHIPHI ,DMDICHVU.TENDICHVU,DMDICHVU.DVT"
                + " ORDER BY A.LOAICHIPHI ,DMDICHVU.TENDICHVU";
                this.DataSource = _ds;
            }
            else
            {
                _ds.SQL = String.Format("SELECT A.LOAICHIPHI,DMDICHVU.TENDICHVU,DMDICHVU.DVT,SUM(SOLUONG) AS SOLUONG,a.NhomLenChiPhi FROM"
            + " (BENHNHAN_PT_CHIPHI A INNER JOIN DMDICHVU ON A.MADICHVU = DMDICHVU.MADICHVU)"
            + " WHERE  DATEDIFF(DD,A.NGAYCHIDINH,'{0:MM/dd/yyyy}') <= 0 AND DATEDIFF(DD,A.NGAYCHIDINH,'{1:MM/dd/yyyy}') >= 0 AND", _TNgay, _DNgay);
                if (_MaNhom == "0")
                {

                }
                else
                {
                    _ds.SQL += String.Format("  A.NhomLenChiPhi = '{0}' AND", _MaNhom);
                }
                if (_NhomThuocVatTu == 0)
                {
                    _ds.SQL += " A.LOAICHIPHI IN ('D02')";
                }
                if (_NhomThuocVatTu == 1)
                {
                    _ds.SQL += " A.LOAICHIPHI IN ('D06')";
                }

                _ds.SQL += " GROUP BY A.LOAICHIPHI ,DMDICHVU.TENDICHVU,DMDICHVU.DVT,a.NhomLenChiPhi"
                + " ORDER BY A.LOAICHIPHI ,DMDICHVU.TENDICHVU";
                this.DataSource = _ds;
            }
        }
    }
}
