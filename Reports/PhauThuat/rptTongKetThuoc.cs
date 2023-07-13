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
    public partial class  rptTongKetThuoc : DataDynamics.ActiveReports.ActiveReport3
    {
        int page = 0;
        String _SoPhieuTu,_SoPhieuDen;
        public rptTongKetThuoc(String Tu, String Den)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            _SoPhieuTu = Tu;
            _SoPhieuDen = Den;
            //lblNgayBC.Text = String.Format("Từ ngày {0:dd/MM/yyyy} đến ngày {1:dd/MM/yyyy}", _SoPhieuTu,_SoPhieuDen);
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
            STT.Height = textBox1.Height = textBox2.Height = textBox3.Height = textBox4.Height = textBox5.Height = this.detail.Height;
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
            _ds.SQL = String.Format("DECLARE @MaPhieuDuyet nVarChar(10)"
                            + " DECLARE @SoLuongMaPhieuDuyet nVarChar(800)"
                            + " DECLARE Cur CURSOR "
                            + " FOR"
                            + " 	SELECT B.MAPHIEUDUYET FROM"
                            + " 	BENHNHAN_PT_CHIPHI B "
                            + " 	WHERE MaPhieuDuyet <> 'null' and cast(RIGHT(B.MAPHIEUDUYET,9) as bigint) >= {0} AND cast(RIGHT(B.MAPHIEUDUYET,9)as bigint) <= {1}"
                            + " 	GROUP BY B.MAPHIEUDUYET ORDER BY RIGHT(B.MAPHIEUDUYET,9)"
                            + " OPEN Cur"
                            + " FETCH NEXT FROM Cur  INTO @MaPhieuDuyet"
                            + " WHILE @@FETCH_STATUS = 0"
                            + " BEGIN"
                            + " 	IF @SoLuongMaPhieuDuyet IS NULL "
                            + " 		SET @SoLuongMaPhieuDuyet = ISNULL(@MaPhieuDuyet,'') "
                            + " 	ELSE"
                            + " 		SET @SoLuongMaPhieuDuyet = ISNULL(@SoLuongMaPhieuDuyet,'') + ',' + ISNULL(@MaPhieuDuyet,'') "
                            + " 	FETCH NEXT FROM Cur  INTO @MaPhieuDuyet"
                            + " END"
                            + " DEALLOCATE  Cur"
                          + " SELECT @SoLuongMaPhieuDuyet AS SOLUONGPHIEU,A.KHOID,DMDICHVU.TENDICHVU,DMDICHVU.DVT,SUM(SOLUONG) AS SOLUONG FROM"
                + " (BENHNHAN_PT_CHIPHI A INNER JOIN DMDICHVU ON A.MADICHVU = DMDICHVU.MADICHVU)"
                + " WHERE MaPhieuDuyet <> 'null' and A.LOAICHIPHI IN ('D01') AND A.DATHUCHIEN = 1 AND RIGHT(MAPHIEUDUYET,9) >= {0} and RIGHT(MAPHIEUDUYET,9) <= {1}"
                + " GROUP BY A.KHOID,DMDICHVU.TENDICHVU,DMDICHVU.DVT"
                + " ORDER BY A.KHOID,DMDICHVU.TENDICHVU", _SoPhieuTu,_SoPhieuDen);
            this.DataSource = _ds;
        }
    }
}
