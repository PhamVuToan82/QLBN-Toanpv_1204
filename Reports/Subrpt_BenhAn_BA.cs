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
    public partial class Subrpt_BenhAn_BA : DataDynamics.ActiveReports.ActiveReport3
    {
        string _MaVaoVien;
        int _LoaiBenhAn;
        public Subrpt_BenhAn_BA(string MaVaoVien, int LoaiBenhAn)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            _MaVaoVien = MaVaoVien;
            _LoaiBenhAn = LoaiBenhAn;
            if (_LoaiBenhAn == 3)
            {
                label15.Text = "2. Bệnh Ngoại Khoa";
                label23.Visible = false;
                label63.Visible = true;
            }
            else
            {
                label15.Text = "2. Bộ phận tổn thương";
                label23.Visible = true;
                label63.Visible = false;
            }
        }

        private void rptChiPhiPT_ReportStart(object sender, EventArgs e)
        {
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.PageSettings.Margins.Top = (float)0.5;
            this.PageSettings.Margins.Left = (float)0.4;
            this.PageSettings.Margins.Right = (float)0.1;
            this.PageSettings.Margins.Bottom = (float)0.5;
            this.Document.Name = "Y lệnh";
        }

        private void detail_Format(object sender, EventArgs e)
        {
         
        }

        private void detail_BeforePrint(object sender, EventArgs e)
        {
        }

        private void Subrpt_ylenh_dieutri_FetchData(object sender, FetchEventArgs eArgs)
        {
          
            
            //if ((Fields["ChanDoan_TaiBien"].Value.ToString()) == "1")
            //{
            //    textBox12.Text = "X";
            //} else textBox12.Text = "";
            //if ((Fields["ChanDoan_BienChung"].Value.ToString()) == "1")
            //{
            //    textBox13.Text = "X";
            //}else textBox13.Text = "";
            //if ((Fields["ChanDoan_DoPhauThuat"].Value.ToString()) == "1")
            //{
            //    textBox15.Text = "X";
            //}
            //else textBox15.Text = "";
            //if ((Fields["ChanDoan_DoGayMe"].Value.ToString()) == "1")
            //{
            //    textBox14.Text = "X";
            //}
            //else textBox14.Text = "";
            //if ((Fields["ChanDoan_DoNhiemKhuan"].Value.ToString()) == "1")
            //{
            //    textBox16.Text = "X";
            //}
            //else textBox16.Text = "";
            //if ((Fields["ChanDoan_Khac"].Value.ToString()) == "1")
            //{
            //    textBox17.Text = "X";
            //}
            //else textBox17.Text = "";
        }

        private void groupHeader1_BeforePrint(object sender, EventArgs e)
        {
         
        }

        private void groupHeader2_BeforePrint(object sender, EventArgs e)
        {
            
        }

        private void groupFooter2_BeforePrint(object sender, EventArgs e)
        {

        }

        private void groupFooter2_Format(object sender, EventArgs e)
        {

        }

        private void pageFooter_Format(object sender, EventArgs e)
        {
          
        }
        private void Subrpt_ylenh_dieutri_DataInitialize(object sender, EventArgs e)
        {
            DataDynamics.ActiveReports.DataSources.SqlDBDataSource _ds = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            _ds.ConnectionString = GlobalModuls.Global.glbConnectionString;
            _ds.SQL = string.Format("select [MaVaoVien], [BenhAn_LyDoVaoVien], [BenhAn_NgayBenh], [BenhAn_BenhLy], [BenhAn_TienSuBanThan], [BenhAn_TienSuDacDiemDiUng], [BenhAn_TienSuDacDiemMaTuy], [BenhAn_TienSuDacDiemRuouBia], [BenhAn_TienSuDacDiemThuocLa], [BenhAn_TienSuDacDiemThuocLao], [BenhAn_TienSuDacDiemKhac], [BenhAn_TienSuGiaDinh], [BenhAn_KhamBenhToanThan], [BenhAn_KhamBenhBoPhan], [BenhAn_KhamBenhBoPhanAnh], [BenhAn_KhamBenhBoMoTa], [BenhAn_KhamBenhMach], [BenhAn_KhamBenhNhietDo], [BenhAn_KhamBenhHuyetAp], [BenhAn_KhamBenhNhipTho], [BenhAn_KhamBenhCanNang], [BenhAn_CoQuanThanKinh], [BenhAn_CoQuanTuanHoan], [BenhAn_CoQuanHoHap], [BenhAn_CoQuanTieuHoa], [BenhAn_CoQuanCoXuongKhop], [BenhAn_CoQuanTietNieu], [BenhAn_CoQuanSinhDuc], [BenhAn_CoQuanKhac], [BenhAn_XetNghiemCanLam], [BenhAn_TomTat], [BenhAn_ChanDoanBenhChinhVaoKhoa], [BenhAn_ChanDoanBenhPhuVaoKhoa], [BenhAn_ChanDoanPhanBietVaoKhoa], [BenhAn_TienLuong], [BenhAn_HuongDieuTri], [BenhAn_ThoiGianDiUng], [BenhAn_ThoiGianMaTuy], [BenhAn_ThoiGianRuouBia], [BenhAn_ThoiGianThuocLa], [BenhAn_ThoiGianThuocLao], [BenhAn_ThoiGianKha],BenhAn_KhamBenhChieuCao,BenhAn_BenhNgoaiKhoa from NAMDINH_QLBN.dbo.BenhAn_ChiTiet where Mavaovien =  '{0}'", _MaVaoVien);
            this.DataSource = _ds;     
        }

        private void groupHeader1_Format(object sender, EventArgs e)
        {
            if(_LoaiBenhAn == 2|| _LoaiBenhAn == 3)
            {
                Subrpt_BenhAn_BA_CoQuan_NoiNgoai rtpcoquan = new Subrpt_BenhAn_BA_CoQuan_NoiNgoai(_MaVaoVien);
                subReport2.Report = rtpcoquan;
            }
            else
            {
                Subrpt_BenhAn_BA_CoQuan rtpcoquan = new Subrpt_BenhAn_BA_CoQuan(_MaVaoVien);
                subReport2.Report = rtpcoquan;
            }

        }
    }
}
