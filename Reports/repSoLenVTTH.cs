using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using System.Data;
using System.Data.SqlClient;
using GlobalModuls;

namespace NamDinh_QLBN.Reports
{
    /// <summary>
    /// Summary description for repSoLenThuoc.
    /// </summary>
    public partial class repSoLenVTTH : DataDynamics.ActiveReports.ActiveReport3
    {
        private String _MaKhoa,_TenKhoa;
        private object _Ngay;
        private int _NhomThuoc;
        private int Page = 0;
        System.Data.DataTable Table = new DataTable();
        string _MaPhieuDuyet,_MaNhomLenCP;
        public repSoLenVTTH(String MaKhoa, int NhomThuoc, object Ngay, String TenKhoa, String MaPhieuDuyet,string MaNhomLenCP,string TenNhomLenCP)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            _MaKhoa = MaKhoa;
            _NhomThuoc = NhomThuoc;
            _Ngay = Ngay;
            _TenKhoa = TenKhoa+ " - " +TenNhomLenCP;
            _MaPhieuDuyet = MaPhieuDuyet;
            _MaNhomLenCP = MaNhomLenCP;
            barcode1.Text = MaPhieuDuyet;
        }

        private void repSoLenThuoc_ReportStart(object sender, EventArgs e)
        {
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.PageSettings.Orientation = PageOrientation.Landscape;

            this.PageSettings.Margins.Left = (float)0.2;
            this.PageSettings.Margins.Right = (float)0.0;
            this.PageSettings.Margins.Top = (float)0.2;
            this.PageSettings.Margins.Bottom = (float)0.2;
            txtInNgay.Text = String.Format("In ngày {0:dd} tháng {0:MM} năm {0:yyyy}", Global.NgayLV);
            lblNgayThang.Text = String.Format("Thực hiện ngày {0:dd} tháng {0:MM} năm {0:yyyy}", _Ngay);
            lblKhoa.Text = _TenKhoa;
            if (_NhomThuoc == 0)
            {
                lbSoYLenh.Text = "SỔ THUỐC DÙNG CHUNG";
            }
            else
            {
                lbSoYLenh.Text = "SỔ VẬT TƯ TIÊU HAO";
            }
        }

        private void repSoLenThuoc_DataInitialize(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            SQLCmd.CommandText = String.Format("set dateformat mdy SELECT * FROM "
                     + " DMDICHVU A inner join  "
                     + " (select MaDichVu from"
                     + " (Select ct.MaDichVu from benhnhan_phieudieutri pdt inner join phieudieutri_chitiet ct on  ct.SoPhieu = pdt.SoPhieu"
                     + " where makhoa = '{0}' and datediff(dd,NgayChiDinh,'{1:MM/dd/yyyy}') = 0 "
                     + " and ct.LoaiDichVu ='{2}' and ct.MaNhom= " + _MaNhomLenCP + " and ct.MaPhieuDuyet='" + _MaPhieuDuyet + "'"
                     + " Union all"
                     + " SELECT MADICHVU FROM BENHNHAN_PT_CHIPHI "
                     + " WHERE LOAICHIPHI ='{2}'"
                     + " AND DATEDIFF(DD,NGAYCHIDINH,'{1:MM/dd/yyyy}') = 0 and '{0}'='NV1103'" + " and MaPhieuDuyet='" + _MaPhieuDuyet + "'  and NhomLenChiPhi =  '" + _MaNhomLenCP + "'"
                     + " union  all"
                     + " select machiphi as Madichvu from NAMDINH_KHAMBENH.DBO.TBLCHIPHI_DICHVU where datediff(dd,NgayThucHien,'{1:MM/dd/yyyy}') = 0 and "
                     + " LoaiChiPhi ='{2}' and MAKHOATHUCHIEN='{0}' and MaNhom = " + _MaNhomLenCP + " and MaPhieuDuyet='" + _MaPhieuDuyet + "'" + ") b"
                     + " group by MaDichvu) c on c.madichvu = a.MADICHVU  order by a.TenDichVu"
                     , _MaKhoa, _Ngay, _NhomThuoc == 0 ? "D06" : "D02");
            int j = 1;
            dr = SQLCmd.ExecuteReader();
            while (dr.Read())
            {
                if (j >= 41) break;
                foreach (DataDynamics.ActiveReports.Label lb in pageHeader.Controls)
                {
                    if (lb.Name == ("lb" + j.ToString()))
                    {
                        lb.Text = dr["TenDichVu"].ToString();
                        lb.Name = dr["MaDichVu"].ToString();
                        break;
                    }
                }
                foreach (DataDynamics.ActiveReports.TextBox _lb in detail.Controls)
                {
                    if (_lb.Name == ("lbl" + j.ToString()))
                    {
                        _lb.Name = dr["MaDichVu"].ToString();
                        _lb.DataField = dr["MaDichVu"].ToString();
                        break;
                    }
                }
                foreach (DataDynamics.ActiveReports.TextBox _lb in reportFooter1.Controls)
                {
                    if (_lb.Name == ("txt" + j.ToString()))
                    {
                        _lb.Name = dr["MaDichVu"].ToString();
                        break;
                    }
                }
                j++;
            }
            dr.Close();
            SQLCmd.Dispose();
            DataDynamics.ActiveReports.DataSources.SqlDBDataSource _ds = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            _ds.ConnectionString = GlobalModuls.Global.glbConnectionString;
            _ds.SQL = string.Format("set dateformat mdy Select MaPhieuDuyet,MaVaoVien,HoTen,Tuoi,TenBuong,Nhom,Nhom1 from ("
                             + " Select pdtct.MaPhieuDuyet,pdt.MaVaoVien,bn.HoTen,year(getdate())-bn.NamSinh as Tuoi,bb.TenBuong,pdt.Nhom, "
                             + " CASE WHEN pdt.NHOM = 0 THEN N'Chi phí trong ngày' else N'Chi phí bất thường' end as Nhom1 "
                             + " from NamDinh_QLBN.dbo.BenhNhan_PhieuDieuTri pdt inner join NamDinh_QLBN.dbo.PhieuDieuTri_ChiTiet pdtct on pdt.SoPhieu=pdtct.SoPhieu "
                             + " inner join NamDinh_QLBN.dbo.BenhNhan_ChiTiet bnct on pdt.MaVaoVien=bnct.MaVaoVien inner join NamDinh_QLBN.dbo.BenhNhan bn on bn.MaBenhNhan=bnct.MaBenhNhan "
                             + " left join NamDinh_QLBN.dbo.DMBuongBenh bb on bb.ID_Buong=bnct.Buong and bb.MaKhoa='{0}'"
                             + " where pdt.MaKhoa='{0}' and pdtct.MaNhom={1} and datediff(dd,pdt.NgayChiDinh,'{2:MM/dd/yyyy}')=0 "
                             + " and pdtct.LoaiDichVu='{3}' and pdtct.MaPhieuDuyet='"+_MaPhieuDuyet+"'"
                             + " Union all"
                             + " Select pt.MaPhieuDuyet,pt.MaVaoVien,bn.HoTen,year(getdate())-bn.NamSinh as Tuoi,bb.TenBuong,1 as Nhom, "
                             + " N'Chi phí bất thường' as Nhom1 "
                             + " from NamDinh_QLBN.dbo.BENHNHAN_PT_CHIPHI pt inner join NamDinh_QLBN.dbo.BenhNhan_ChiTiet bnct on pt.MaVaoVien=bnct.MaVaoVien "
                             + " inner join NamDinh_QLBN.dbo.BenhNhan bn on bn.MaBenhNhan=bnct.MaBenhNhan "
                             + " left join NamDinh_QLBN.dbo.DMBuongBenh bb on bb.ID_Buong=bnct.Buong and bb.MaKhoa='{0}'"
                             + " where '{0}'='NV1103' and pt.NhomLenChiPhi = {1} and datediff(dd,pt.NgayChiDinh,'{2:MM/dd/yyyy}')=0 and pt.LoaiChiPhi='{3}' and pt.MaPhieuDuyet='" + _MaPhieuDuyet + "'"
                             + " Union all Select cpdv.MaPhieuDuyet,kb.MaKhamBenh as MaVaoVien,bn.TenBenhNhan as HoTen,year(getdate()) - bn.NamSinh as Tuoi,'' as TenBuong, 0 as Nhom, "
                             + " N'Chi phí trong ngày' as Nhom1 "
                             + " from NamDinh_KhamBenh.dbo.tblChiPhi_DichVu cpdv inner join NamDinh_KhamBenh.dbo.tblKhamBenh kb on cpdv.MaKhamBenh=kb.MaKhamBenh"
                             + " inner join NamDinh_KhamBenh.dbo.tblBenhNhan bn on bn.MaBenhNhan=kb.MaBenhNhan"
                             + " where MaKhoaThucHien='{0}' and MaNhom={1} and datediff(dd,NgayThucHien,'{2:MM/dd/yyyy}')=0 and cpdv.LoaiChiPhi='{3}' and cpdv.MaPhieuDuyet='" + _MaPhieuDuyet + "')x "
                             + " group by MaPhieuDuyet,MaVaoVien,HoTen,Tuoi,TenBuong,Nhom,Nhom1 ORDER BY right(MaPhieuDuyet,3) desc,Nhom,TenBuong"
                             , _MaKhoa, _MaNhomLenCP, _Ngay, _NhomThuoc ==0 ? "D06" : "D02");
            this.DataSource = _ds;
            foreach (DataDynamics.ActiveReports.TextBox _lb in detail.Controls)
            {
                if (!Fields.Contains(Fields[_lb.DataField]))
                    Fields.Add(_lb.DataField);
            }
        }

        private void repSoLenThuoc_FetchData(object sender, FetchEventArgs eArgs)
        {
            try
            {
                System.Data.SqlClient.SqlDataReader dr;
                System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
                SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
                String MaVaoVien, Nhom;
                MaVaoVien = Fields["MaVaoVien"].Value.ToString();
                Nhom = Fields["Nhom"].Value.ToString();
                if (Nhom == "") return;
                SQLCmd.CommandText = string.Format("set dateformat mdy Select MaPhieuDuyet,dv.MaDichVu,SoLuong,dsVT.Nhom,MaVaoVien,TenDichVu from DMDichVu dv "
                     + " inner join ( Select MaPhieuDuyet,MaDichVu,sum(SoLuong) as SoLuong,Nhom,MaVaoVien from ("
                     + " Select pdtct.MaPhieuDuyet,pdtct.MaDichVu,pdtct.SoLuong+pdtct.SoLuongHT as SoLuong,pdt.Nhom,pdt.MaVaoVien from NamDinh_QLBN.dbo.BenhNhan_PhieuDieuTri pdt inner join NamDinh_QLBN.dbo.PhieuDieuTri_ChiTiet pdtct on pdt.SoPhieu=pdtct.SoPhieu "
                     + " where pdt.MaKhoa='{0}' and pdtct.MaNhom={2} and datediff(dd,pdt.NgayChiDinh,'{1:MM/dd/yyyy}')=0 and pdtct.LoaiDichVu='{3}' and pdt.MaVaoVien='" + MaVaoVien + "'"
                     + " Union all"
                     + " Select MaPhieuDuyet,MaDichVu,SoLuong,1 as Nhom,MaVaoVien from NamDinh_QLBN.dbo.BENHNHAN_PT_CHIPHI "
                     + " where '{0}'='NV1103' and NhomLenChiPhi = {2} and datediff(dd,NgayChiDinh,'{1:MM/dd/yyyy}')=0 and LoaiChiPhi='{3}' and MaVaoVien='" + MaVaoVien + "'"
                     + " Union all Select MaPhieuDuyet,MaChiPhi as MaDichVu,SoLuong,0 as Nhom,MaKhamBenh as MaVaoVien from NamDinh_KhamBenh.dbo.tblChiPhi_DichVu "
                     + " where MaKhoaThucHien='{0}' and MaNhom={2} and datediff(dd,NgayThucHien,'{1:MM/dd/yyyy}')=0 and LoaiChiPhi='{3}' and MaKhamBenh='" + MaVaoVien + "')x "
                     + " GROUP BY MAVAOVIEN,MADICHVU,NHOM,MAPHIEUDUYET) dsVT "
                     + " on dv.MaDichVu=dsVT.MaDichVu", _MaKhoa, _Ngay, _MaNhomLenCP, _NhomThuoc == 0 ? "D06" : "D02");
                dr = SQLCmd.ExecuteReader();
                bool DaCo = false;
                lblGhiChu.Text = "";
                foreach (DataDynamics.ActiveReports.TextBox _lb in detail.Controls)
                {
                    if (_lb.DataField != "HoTen" && _lb.DataField != "Tuoi" && _lb.DataField != "TENBUONG")
                    {
                        Fields[_lb.DataField].Value = "";
                    }
                }
                while (dr.Read())
                {
                    DaCo = false;
                    foreach (DataDynamics.ActiveReports.TextBox _lb in detail.Controls)
                    {
                        if (_lb.Name == dr["MaDichVu"].ToString())
                        {
                            Fields[dr["MaDichVu"].ToString()].Value = String.Format("{0:#,##0.##}", decimal.Parse(dr["SoLuong"].ToString()));
                            DaCo = true;
                        }
                    }
                    if (!DaCo)
                    {
                        if (lblGhiChu.Text == "")
                            lblGhiChu.Text += dr["TenDichVu"].ToString() + "- " + String.Format("{0:#,##0.##}", decimal.Parse(dr["SoLuong"].ToString()));
                        else
                            lblGhiChu.Text += "\n " + dr["TenDichVu"].ToString() + "- " + String.Format("{0:#,##0.##}", decimal.Parse(dr["SoLuong"].ToString()));
                    }
                    foreach (DataDynamics.ActiveReports.TextBox _txt in reportFooter1.Controls)
                    {
                        if (_txt.Name == dr["MaDichVu"].ToString())
                        {
                            if (_txt.Value == null)
                            {
                                _txt.Value = decimal.Parse(String.Format("{0:#,##0.##}", decimal.Parse(dr["SoLuong"].ToString())));
                            }
                            else
                            {
                                _txt.Value = (decimal)_txt.Value + decimal.Parse(String.Format("{0:#,##0.##}", decimal.Parse(dr["SoLuong"].ToString())));
                            }
                            break;
                        }
                    }
                }
                dr.Close();
            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
        }

        private void detail_BeforePrint(object sender, EventArgs e)
        {
            foreach (TextBox txt in detail.Controls)
            {
                txt.Height = detail.Height;
            }
        }

        private void reportFooter1_Format(object sender, EventArgs e)
        {
            
        }

        private void repSoLenThuoc_PageStart(object sender, EventArgs e)
        {
            Page++;
            txtPage.Text = "Trang: " + Page.ToString();
        }
    }
}
