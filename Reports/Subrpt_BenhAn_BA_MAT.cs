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
    public partial class Subrpt_BenhAn_BA_MAT : DataDynamics.ActiveReports.ActiveReport3
    {
        string _MaVaoVien;
        int _LoaiBenhAn;
        public Subrpt_BenhAn_BA_MAT(string MaVaoVien, int LoaiBenhAn)
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
                if(_LoaiBenhAn == 5|| _LoaiBenhAn == 6|| _LoaiBenhAn == 7)
                {
                    label15.Text = "2. Bệnh chuyên khoa";
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
        private void Subrpt_ylenh_dieutri_DataInitialize(object sender, EventArgs e)
        {
            DataDynamics.ActiveReports.DataSources.SqlDBDataSource _ds = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            _ds.ConnectionString = GlobalModuls.Global.glbConnectionString;
            _ds.SQL = string.Format("select A.MaVaoVien, [BenhAn_LyDoVaoVien], [BenhAn_NgayBenh], [BenhAn_BenhLy], [BenhAn_TienSuBanThan], [BenhAn_TienSuDacDiemDiUng], [BenhAn_TienSuDacDiemMaTuy], [BenhAn_TienSuDacDiemRuouBia], [BenhAn_TienSuDacDiemThuocLa], [BenhAn_TienSuDacDiemThuocLao], [BenhAn_TienSuDacDiemKhac], [BenhAn_TienSuGiaDinh], [BenhAn_KhamBenhToanThan], [BenhAn_KhamBenhBoPhan], [BenhAn_KhamBenhBoPhanAnh], [BenhAn_KhamBenhBoMoTa], [BenhAn_KhamBenhMach], [BenhAn_KhamBenhNhietDo], [BenhAn_KhamBenhHuyetAp], [BenhAn_KhamBenhNhipTho], [BenhAn_KhamBenhCanNang], [BenhAn_CoQuanThanKinh], [BenhAn_CoQuanTuanHoan], [BenhAn_CoQuanHoHap], [BenhAn_CoQuanTieuHoa], [BenhAn_CoQuanCoXuongKhop], [BenhAn_CoQuanTietNieu], [BenhAn_CoQuanSinhDuc], [BenhAn_CoQuanKhac], [BenhAn_XetNghiemCanLam], [BenhAn_TomTat], [BenhAn_ChanDoanBenhChinhVaoKhoa], [BenhAn_ChanDoanBenhPhuVaoKhoa], [BenhAn_ChanDoanPhanBietVaoKhoa], [BenhAn_TienLuong], [BenhAn_HuongDieuTri], [BenhAn_ThoiGianDiUng], [BenhAn_ThoiGianMaTuy], [BenhAn_ThoiGianRuouBia], [BenhAn_ThoiGianThuocLa], [BenhAn_ThoiGianThuocLao], [BenhAn_ThoiGianKha],BenhAn_KhamBenhChieuCao,BenhAn_BenhNgoaiKhoa,[MAT_ThiLucMP_KhongKinh], [MAT_ThiLucMT_KhongKinh], [MAT_ThiLucMP_CoKinh], [MAT_ThiLucMT_CoKinh], [MAT_NhanApMP], [MAT_NhanApMT], [MAT_ThiTruongMP], [MAT_ThiTruongMT], [MAT_LeDaoMP], [MAT_LeDaoMT], [MAT_MongMatMP], [MAT_MongMatMT], [MAT_DTPXMP], [MAT_DTPXMT], [MAT_ThuyTinhTheMP], [MAT_ThuyTinhTheMT], [MAT_ThuyTinhDichMP], [MAT_ThuyTinhDichMT], [MAT_SoiAnhDTMP], [MAT_SoiAnhDTMT], [MAT_NhanCauMP], [MAT_NhanCauMT], [MAT_HocMatMP], [MAT_HocMatMT], [MAT_DayMatMP], [MAT_DayMatMT], [Benh_ChuyenKhoa], [MAT_MiMatMP], [MAT_MiMatMT], [MAT_KetMacMP], [MAT_KetMacMT], [MAT_MatHotMP], [MAT_MatHotMT], [MAT_GiaMacMP], [MAT_GiaMacMT], [MAT_CungMacMP], [MAT_CungMacMT], [MAT_TienPhongMP], [MAT_TienPhongMT] from NAMDINH_QLBN.dbo.BenhAn_ChiTiet A INNER JOIN  BenhAn_ChuyenKhoa B ON A.MAVAOVIEN = B.MAVAOVIEN  where A.Mavaovien =  '{0}'", _MaVaoVien);
            this.DataSource = _ds;     
        }

        private void groupHeader1_Format(object sender, EventArgs e)
        {
            //if (_LoaiBenhAn == 2 || _LoaiBenhAn == 3)
            //{
            //    Subrpt_BenhAn_BA_MAT_CoQuan_NoiNgoai rtpcoquan = new Subrpt_BenhAn_BA_MAT_CoQuan_NoiNgoai(_MaVaoVien);
            //    subReport2.Report = rtpcoquan;
            //}
            //else
            //{
            Subrpt_BenhAn_BA_CoQuan_MAT rtpcoquan = new Subrpt_BenhAn_BA_CoQuan_MAT(_MaVaoVien);
            subReport2.Report = rtpcoquan;
            //}
        }
    }
}
