using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace NamDinh_QLBN.Reports
{
    /// <summary>
    /// Summary description for rptChiPhiPT.
    /// </summary>
    public partial class rptBA_UNGBUOU : DataDynamics.ActiveReports.ActiveReport3
    {
        string _MaVaoVien, _TenKhoa, _NgayChuyen, _NgayDT, _Hsba, _LuuTru;
            int _LoaiBenhAn;
        public rptBA_UNGBUOU(string MaVaoVien, string TenKhoa, string NgayChuyen, string NgayDT, string hsba, string Luutru , int LoaiBenhAn)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            _MaVaoVien = MaVaoVien;
            _TenKhoa = TenKhoa;
            _NgayChuyen = NgayChuyen;
            _NgayDT = NgayDT;
            _Hsba = hsba;_LuuTru = Luutru;
            label12.Text = _Hsba;
            label15.Text = _LuuTru;
            label8.Text = _TenKhoa;
            _LoaiBenhAn = LoaiBenhAn;
        }

        private void rptChiPhiPT_ReportStart(object sender, EventArgs e)
        {
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.PageSettings.Margins.Top = (float)0.3;
            this.PageSettings.Margins.Left = (float)0.3;
            this.PageSettings.Margins.Right = (float)0.0;
            this.PageSettings.Margins.Bottom = (float)0.5;
            this.Document.Name = "Bệnh Án";
        }

        private void detail_Format(object sender, EventArgs e)
        {
            //_Ylenh = _Ylenh + Fields["Ylenh"].Value.ToString();
            //textBox3.Height = textBox15.Height = textBox16.Height = line1.Height = line2.Height = line4.Height = detail.Height;
            //if (textBox15.Text == "D01")
            //{
            //    textBox16.Text = Fields["DienBienBenh"].Value.ToString();
            //    textBox3.Text = "";
            //}
            //else
            //{
            //    textBox3.Text = Fields["DienBienBenh"].Value.ToString();
            //    textBox16.Text = "";
            //}
        }

        private void detail_BeforePrint(object sender, EventArgs e)
        {
            //textBox3.Height = textBox15.Height = textBox16.Height = line1.Height = line2.Height = line4.Height = detail.Height;
            //if (Fields["LoaiDichvu"].Value.ToString() == "D01")
            //{
            //    textBox16.Text = Fields["DienBienBenh"].Value.ToString();

            //}
            //else
            //{
            //    textBox3.Text = Fields["DienBienBenh"].Value.ToString();

            //}

        }

        private void Subrpt_ylenh_dieutri_FetchData(object sender, FetchEventArgs eArgs)
        {
            if ((Fields["GioiTinh"].Value.ToString()) == "0")
            {
                textBox2.Text = "X";
            }
            else textBox2.Text = "";
            if ((Fields["GioiTinh"].Value.ToString()) == "1")
            {
                textBox1.Text = "X";
            }
            else textBox1.Text = "";
            if ((Fields["DoiTuong"].Value.ToString()) == "1")
            {
                textBox26.Text = "X";
            }
            else textBox26.Text = "";
            if ((Fields["DoiTuong"].Value.ToString()) != "1")
            {
                textBox27.Text = "X";
            }
            else textBox27.Text = "";
            if(Fields["HanTheBHYT_Den"].Value.ToString()!="")
            {
                label50.Text = string.Format("{0:dd}" + " tháng " + "{0:MM}" + " năm " + "{0:yyyy}", DateTime.Parse(Fields["HanTheBHYT_Den"].Value.ToString()));
            }
            else
            {
                label50.Text = string.Format("    " + " tháng " + "     " + " năm " + "    ");
            }
            if (Fields["NgayRaVien"].Value.ToString() != "")
            {
                label58.Text = string.Format("Ngày " + "{0:dd}" + " tháng " + "{0:MM}" + " năm " + "{0:yyyy}", DateTime.Parse(Fields["NgayRaVien"].Value.ToString()));
            }
            else
            {
                label58.Text = string.Format("Ngày" +"......" + " tháng " + "......." + " năm " + "..............");
            }
        }

        private void groupHeader1_BeforePrint(object sender, EventArgs e)
        {
      
        }

        private void groupHeader2_BeforePrint(object sender, EventArgs e)
        {
            //richTextBox4.Text = _Ylenh ;
            //line5.Height = line7.Height = line8.Height= richTextBox4.Height = groupFooter2.Height = richTextBox3.Height + textBox6.Height;
        }

        private void groupFooter2_BeforePrint(object sender, EventArgs e)
        {

        }

        private void reportFooter1_Format(object sender, EventArgs e)
        {
            Subrpt_BenhAn_TongKet rpttongket = new Subrpt_BenhAn_TongKet(_MaVaoVien);
            subReport5.Report = rpttongket;
        }

        private void groupFooter2_Format(object sender, EventArgs e)
        {
            Subrpt_BenhAn_BA rtpBenhAn = new Subrpt_BenhAn_BA(_MaVaoVien,_LoaiBenhAn);
            subReport4.Report = rtpBenhAn;
        }

        private void pageFooter_Format(object sender, EventArgs e)
        {
            //label19.Text = String.Format("{0}", int.Parse(label19.Text) + 1);
        }
        private void Subrpt_ylenh_dieutri_DataInitialize(object sender, EventArgs e)
        {
            DataDynamics.ActiveReports.DataSources.SqlDBDataSource _ds = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            _ds.ConnectionString = GlobalModuls.Global.glbConnectionString;
            _ds.SQL = string.Format(" select UPPER(c.HoTen) AS TenBenhNhan,substring(convert(nvarchar(4), (c.Namsinh)), 1, 1) as NS1,substring(convert(nvarchar(4), (c.Namsinh)), 2, 1) as NS2,substring(convert(nvarchar(4), (c.Namsinh)), 3, 1) as NS3,substring(convert(nvarchar(4), (c.Namsinh)), 4, 1) as NS4,"
                                        + " substring(convert(nvarchar(3), (YEAR(B.NgayKham) - C.NamSinh)), 1, 1) as Tuoi1,substring(convert(nvarchar(3), (YEAR(B.NgayKham) - C.NamSinh)), 2, 1) as Tuoi2,substring(convert(nvarchar(3), (YEAR(B.NgayKham) - C.NamSinh)), 3, 1) as Tuoi3,"
                                        + " GioiTinh,substring(convert(nvarchar(3), (b.Nghenghiep)), 1, 1) as NN1,substring(convert(nvarchar(3), (b.Nghenghiep)), 2, 1) as NN2, nghe.TenNghenghiep,"
                                        + " SUBSTRING(c.MaDanToc, 1, 1) as DanToc1, SUBSTRING(c.MaDanToc, 2, 1) as DanToc2, TenDT, SUBSTRING(DmNuocNgoai.MaNuocNgoai, 1, 1) as MaNuocNgoai1,SUBSTRING(DmNuocNgoai.MaNuocNgoai, 2, 1) as MaNuocNgoai2 , DmNuocNgoai.TenNuocNgoai As NgoaiKieu, a.Diachi, '' as XaPhuong,substring(convert(nvarchar(3), (b.Ma_Huyen)), 1, 1) as Ma_Huyen1,substring(convert(nvarchar(3), (b.Ma_Huyen)), 2, 1) as Ma_Huyen2,DmQuanHuyen.TenQuanHuyen,"
                                        + " substring(convert(nvarchar(3), (b.MaTinh_TP)), 1, 1) as MaTinh_TP1,substring(convert(nvarchar(3), (b.MaTinh_TP)), 2, 1) as MaTinh_TP2,substring(convert(nvarchar(3), (b.MaTinh_TP)), 3, 1) as MaTinh_TP3,TenTinh, a.Noicongtac,case when B.SoTheBHYT != '' then 1 else 2 end as DoiTuong, b.HanTheBHYT_Den, MaDTBHYT + b.SoTheBHYT as TheBHYT,B.LienHe, b.SoDienThoai As SDT,b.NgayRaVien, b.XaPhuong, b.ThonPho, b.SoNha from NAMDINH_QLBN.dbo.BENHNHAN_CHITIET B"
                                        + " inner join NAMDINH_KHAMBENH.dbo.tblKHAMBENH a on B.MaKhamBenh = a.MaKhambenh"
                                        + " inner join NAMDINH_QLBN.dbo.BENHNHAN c on c.MaBenhNhan = a.MaBenhnhan "
                                        + " left join NAMDINH_SYSDB.dbo.DMNGHENGHIEP nghe on nghe.MaNghenghiep = B.NgheNghiep "
                                        + " left join NAMDINH_SYSDB.dbo.DmTinh on DmTinh.Matinh = B.MaTinh_TP "
                                        + " left join NAMDINH_SYSDB.dbo.DmQuanHuyen on SUBSTRING(DmQuanHuyen.MaQuanHuyen, 1, 3) = B.MaTinh_TP and SUBSTRING(DmQuanHuyen.MaQuanHuyen, 4, LEN(DmQuanHuyen.MaQuanHuyen)) = B.Ma_Huyen"
                                        + " left join NAMDINH_SYSDB.dbo.DMDANTOC ON DMDANTOC.MaDT = c.MaDanToc"
                                        + " left join NAMDINH_SYSDB.dbo.DmNuocNgoai ON DmNuocNgoai.MaNuocNgoai = B.MaNuocNgoai "
                                        + " WHERE B.MaVaoVien = '{0}'", _MaVaoVien);
            this.DataSource = _ds;
        }

        private void groupHeader1_Format(object sender, EventArgs e)
        {    
            Subrpt_BenhAn_QLNB rpt1 = new Subrpt_BenhAn_QLNB(_MaVaoVien,_TenKhoa,_NgayChuyen,_NgayDT);
            subReport1.Report = rpt1;
            Subrpt_BenhAn_KhamBenh rptchandoan = new Subrpt_BenhAn_KhamBenh(_MaVaoVien);
            subReport2.Report = rptchandoan;
            Subrpt_BenhAn_TinhTrangRaVien rtpTinhTrangRaVien = new Subrpt_BenhAn_TinhTrangRaVien(_MaVaoVien);
            subReport3.Report = rtpTinhTrangRaVien;
        }

        private void reportHeader1_Format(object sender, EventArgs e)
        {
            
        }
    }
}
