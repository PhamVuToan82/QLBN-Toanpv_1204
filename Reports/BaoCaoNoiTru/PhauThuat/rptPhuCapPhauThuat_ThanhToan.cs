using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace NamDinh_QLBN.Reports.BaoCaoNoiTru.PhauThuat
{
    /// <summary>
    /// Summary description for rptChiNganSach.
    /// </summary>
    public partial class rptPhuCapPhauThuat_ThanhToan : DataDynamics.ActiveReports.ActiveReport3
    {
        private object _ThangBC;
        private object _TuNgay;
        private object _DenNgay;
        private string _Makhoa;
        private string _Tenkhoa;
        string temp_khoa = "";
        public rptPhuCapPhauThuat_ThanhToan(object ThangBaoCao, string Makhoa, string Tenkhoa, object Tu, object Den)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            _ThangBC = ThangBaoCao;
            _TuNgay = Tu;
            _DenNgay = Den;
            _Makhoa = Makhoa;
            _Tenkhoa = Tenkhoa;
            //lblThangBC.Text = String.Format("THÁNG {0:MM} NĂM {0:yyyy}", ThangBaoCao);
            lblThangBC.Text = String.Format("Thời gian thanh toán Từ {0:dd/MM/yyyy} đến {1:dd/MM/yyyy}", Tu, Den);
            lbKhoa.Text = _Tenkhoa.ToUpper();

            if (_Makhoa != "")
            {
                temp_khoa = " and B.Makhoa = '" + _Makhoa + "'";
            }
        }
        private void rptPhuCapPhauThuat_ThanhToan_ReportStart(object sender, EventArgs e)
        {
            this.PageSettings.Orientation = PageOrientation.Landscape;
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.PageSettings.Margins.Left = (float)0.4;
            this.PageSettings.Margins.Right = (float)0.0;
            this.PageSettings.Margins.Top = (float)0.7;
            this.PageSettings.Margins.Bottom = (float)0.7;                        
        }

        private void rptPhuCapPhauThuat_ThanhToan_DataInitialize(object sender, EventArgs e)
        {
            DataDynamics.ActiveReports.DataSources.SqlDBDataSource _ds = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            _ds.ConnectionString = GlobalModuls.Global.glbConnectionString;
            _ds.SQL = String.Format("SET dateformat DMY SELECT DMPHAUTHUAT.LOAIPHAUTHUAT,DMPHAUTHUAT.KYTHUATCAO,B.VITRI,DMBACSY.MABS,DMBACSY.MAKHOA,DMKHOAPHONG.Tentat as TenKhoa, Upper(DMBACSY.TENBS) AS TENBS"
                                    +" FROM(BENHNHAN_PHAUTHUAT A INNER JOIN BENHNHAN_PT_KIPMO B ON A.MAVAOVIEN = B.MAVAOVIEN AND A.SOPHIEUCD = B.SOPHIEUCD AND A.LOAIDICHVU = B.LOAIDICHVU AND A.MAPT = B.MAPT)"
                                    + " INNER JOIN NAMDINH_QLBN.DBO.BENHNHAN_CHITIET CHITIET ON CHITIET.MAVAOVIEN = A.MAVAOVIEN"
                                    + " INNER JOIN PHIEUDIEUTRI_CHITIET P ON P.SOPHIEU = A.SOPHIEUCD AND P.MADICHVU = A.MaPT And P.LOAIDICHVU = A.LOAIDICHVU"
                                    + " INNER JOIN DMPHAUTHUAT ON DMPHAUTHUAT.MADICHVU = A.MAPT AND DMPHAUTHUAT.LOAIDICHVU = A.LOAIDICHVU"
                                    + " INNER JOIN DMBACSY ON DMBACSY.MABS = B.MABS AND DMBACSY.MAKHOA = B.MAKHOA"
                                    + " INNER JOIN DMKHOAPHONG ON DMBACSY.MAKHOA = DMKHOAPHONG.MAKHOA"
                                    + " INNER JOIN DMDICHVU_KHOA ON DMDICHVU_KHOA.MaDichvu = P.MaDichVu"
                                    + " inner join NAMDINH_QLBN.DBO.THONGTIN_PHAUTHUAT on THONGTIN_PHAUTHUAT.MaVaoVien = a.MaVaoVien"
                                    + " WHERE THONGTIN_PHAUTHUAT.NgayMo >= '01/05/2022 00:00:01' and CHITIET.thoigianthanhtoan >= '{1:dd/MM/yyyy 00:00:01}' and CHITIET.thoigianthanhtoan <= '{2:dd/MM/yyyy 23:59:59}'   and DMPHAUTHUAT.LoaiPhauThuat in (11, 21, 3, 4) AND DMDICHVU_KHOA.MaKhoa = '{3}'"
                                    + " ORDER BY DMKHOAPHONG.TENKHOA, DMBACSY.MaBS", _ThangBC,_TuNgay,_DenNgay,_Makhoa);
            this.DataSource = _ds;
            foreach (DataDynamics.ActiveReports.TextBox txt in groupHeader1.Controls)
                if (!Fields.Contains(Fields[txt.DataField]))
                    Fields.Add(txt.DataField);
        }

        private void rptPhuCapPhauThuat_ThanhToan_FetchData(object sender, FetchEventArgs eArgs)
        {
            if (eArgs.EOF)
            {
            }
            else
            {
                Fields["C_DB"].Value = (Fields["VITRI"].Value.ToString() == "1" || Fields["VITRI"].Value.ToString() == "3") && Fields["LOAIPHAUTHUAT"].Value.ToString() == "4" ? 1 : 0;
                Fields["C_LOAI1"].Value = (Fields["VITRI"].Value.ToString() == "1" || Fields["VITRI"].Value.ToString() == "3") && Fields["LOAIPHAUTHUAT"].Value.ToString().Substring(0,1) == "1" ? 1 : 0;
                Fields["C_LOAI2"].Value = (Fields["VITRI"].Value.ToString() == "1" || Fields["VITRI"].Value.ToString() == "3") && Fields["LOAIPHAUTHUAT"].Value.ToString().Substring(0, 1) == "2" ? 1 : 0;
                Fields["C_LOAI3"].Value = (Fields["VITRI"].Value.ToString() == "1" || Fields["VITRI"].Value.ToString() == "3") && Fields["LOAIPHAUTHUAT"].Value.ToString() == "3" ? 1 : 0;

                Fields["P_DB"].Value = (Fields["VITRI"].Value.ToString() == "2" || Fields["VITRI"].Value.ToString() == "4") && Fields["LOAIPHAUTHUAT"].Value.ToString() == "4" ? 1 : 0;
                Fields["P_LOAI1"].Value = (Fields["VITRI"].Value.ToString() == "2" || Fields["VITRI"].Value.ToString() == "4") && Fields["LOAIPHAUTHUAT"].Value.ToString().Substring(0, 1) == "1" ? 1 : 0;
                Fields["P_LOAI2"].Value = (Fields["VITRI"].Value.ToString() == "2" || Fields["VITRI"].Value.ToString() == "4") && Fields["LOAIPHAUTHUAT"].Value.ToString().Substring(0, 1) == "2" ? 1 : 0;
                Fields["P_LOAI3"].Value = (Fields["VITRI"].Value.ToString() == "2" || Fields["VITRI"].Value.ToString() == "4") && Fields["LOAIPHAUTHUAT"].Value.ToString() == "3" ? 1 : 0;

                Fields["GV_DB"].Value = (Fields["VITRI"].Value.ToString() == "5" || Fields["VITRI"].Value.ToString() == "6" || Fields["VITRI"].Value.ToString() == "7") && Fields["LOAIPHAUTHUAT"].Value.ToString() == "4" ? 1 : 0;
                Fields["GV_LOAI1"].Value = (Fields["VITRI"].Value.ToString() == "5" || Fields["VITRI"].Value.ToString() == "6" || Fields["VITRI"].Value.ToString() == "7") && Fields["LOAIPHAUTHUAT"].Value.ToString().Substring(0, 1) == "1" ? 1 : 0;
                Fields["GV_LOAI2"].Value = (Fields["VITRI"].Value.ToString() == "5" || Fields["VITRI"].Value.ToString() == "6" || Fields["VITRI"].Value.ToString() == "7") && Fields["LOAIPHAUTHUAT"].Value.ToString().Substring(0, 1) == "2" ? 1 : 0;
                Fields["GV_LOAI3"].Value = (Fields["VITRI"].Value.ToString() == "5" || Fields["VITRI"].Value.ToString() == "6" || Fields["VITRI"].Value.ToString() == "7") && Fields["LOAIPHAUTHUAT"].Value.ToString() == "3" ? 1 : 0;
            }
        }

        private void groupHeader1_BeforePrint(object sender, EventArgs e)
        {
        //    foreach (TextBox txt in groupHeader1.Controls)
        //        txt.Height = detail.Height;
        }

        private void groupHeader1_Format(object sender, EventArgs e)
        {
            STT.Text = string.Format("{0}", int.Parse(STT.Text) + 1);
        }
    }
}
