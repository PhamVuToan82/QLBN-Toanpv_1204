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
    public partial class Subrpt_BenhAn_BA_TruyenNhiem : DataDynamics.ActiveReports.ActiveReport3
    {
        string _MaVaoVien;
        int _LoaiBenhAn;
        public Subrpt_BenhAn_BA_TruyenNhiem(string MaVaoVien, int LoaiBenhAn)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            _MaVaoVien = MaVaoVien;
            _LoaiBenhAn = LoaiBenhAn;
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
            _ds.SQL = string.Format("select [MaVaoVien], [BenhAn_LyDoVaoVien], [BenhAn_NgayBenh], [BenhAn_BenhLy], [BenhAn_TienSuBanThan], [BenhAn_TienSuDacDiemDiUng], [BenhAn_TienSuDacDiemMaTuy], [BenhAn_TienSuDacDiemRuouBia], [BenhAn_TienSuDacDiemThuocLa], [BenhAn_TienSuDacDiemThuocLao], [BenhAn_TienSuDacDiemKhac], [BenhAn_TienSuGiaDinh], [BenhAn_KhamBenhToanThan], [BenhAn_KhamBenhBoPhan], [BenhAn_KhamBenhBoPhanAnh], [BenhAn_KhamBenhBoMoTa], [BenhAn_KhamBenhMach], [BenhAn_KhamBenhNhietDo], [BenhAn_KhamBenhHuyetAp], [BenhAn_KhamBenhNhipTho], [BenhAn_KhamBenhCanNang], [BenhAn_CoQuanThanKinh], [BenhAn_CoQuanTuanHoan], [BenhAn_CoQuanHoHap], [BenhAn_CoQuanTieuHoa], [BenhAn_CoQuanCoXuongKhop], [BenhAn_CoQuanTietNieu], [BenhAn_CoQuanSinhDuc], [BenhAn_CoQuanKhac], [BenhAn_XetNghiemCanLam], [BenhAn_TomTat], [BenhAn_ChanDoanBenhChinhVaoKhoa], [BenhAn_ChanDoanBenhPhuVaoKhoa], [BenhAn_ChanDoanPhanBietVaoKhoa], [BenhAn_TienLuong], [BenhAn_HuongDieuTri], [BenhAn_ThoiGianDiUng], [BenhAn_ThoiGianMaTuy], [BenhAn_ThoiGianRuouBia], [BenhAn_ThoiGianThuocLa], [BenhAn_ThoiGianThuocLao], [BenhAn_ThoiGianKha],BenhAn_KhamBenhChieuCao,BenhAn_BenhNgoaiKhoa,DichTeLuuHanh,DichTeNoiSong,DichTeMoiSinh,DichTeThoiGian from NAMDINH_QLBN.dbo.BenhAn_ChiTiet where Mavaovien =  '{0}'", _MaVaoVien);
            this.DataSource = _ds;     
        }

        private void groupHeader1_Format(object sender, EventArgs e)
        {
            if(_LoaiBenhAn == 4)
            {
                Subrpt_BenhAn_BA_CoQuan_TruyenNhiem rtpcoquan = new Subrpt_BenhAn_BA_CoQuan_TruyenNhiem(_MaVaoVien);
                subReport2.Report = rtpcoquan;
            }
        }
    }
}
