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
    public partial class Subrpt_ylenh_DienBien : DataDynamics.ActiveReports.ActiveReport3
    {
        string _MaVaoVien,_MaKhoa, _NgayChiDinh;
        DateTime _TuNgay, _DenNgay;
        bool _Chon;
        string _Ylenh = "";

        public Subrpt_ylenh_DienBien(string MaVaoVien, string MaKhoa,DateTime TuNgay, DateTime DenNgay,bool Chon)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            _MaVaoVien = MaVaoVien;
            _MaKhoa = MaKhoa;
            _TuNgay = TuNgay;
            _DenNgay = DenNgay;
            _Chon = Chon;

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

        private void Subrpt_ylenh_DienBien_FetchData(object sender, FetchEventArgs eArgs)
        {
            //if ((Fields["BatThuong"].Value.ToString()) != "BT")
            //{
            //    textBox8.OutputFormat = "dd/MM/yyyy HH:mm:ss";
            //}
            //else
            //{
            //    textBox8.OutputFormat = "dd/MM/yyyy";
            //}

        }

        private void groupHeader1_BeforePrint(object sender, EventArgs e)
        {
            //    line10.Height = line3.Height = line6.Height = groupHeader1.Height;
            //    if (textBox13.Text == "Thuốc, hóa chất, vật tư,Oxy")
            //    {
            //        textBox13.Text = "";
            //        textBox17.Text = "Thuốc, hóa chất, vật tư,Oxy";
            //    }
            //    else
            //    {
            //        textBox17.Text = "";
            //    }

        }

        private void groupHeader2_BeforePrint(object sender, EventArgs e)
        {
            //richTextBox4.Text = _Ylenh ;
            //line5.Height = line7.Height = line8.Height= richTextBox4.Height = groupFooter2.Height = richTextBox3.Height + textBox6.Height;
        }

        private void groupFooter2_BeforePrint(object sender, EventArgs e)
        {

        }

        private void groupFooter2_Format(object sender, EventArgs e)
        {
            //if(_Ylenh == "")
            //{
            //    textBox14.Text = "";
               
            //}
            //else
            //{
            //    textBox14.Text = Fields["BacSyDT"].Value.ToString(); _Ylenh = "";
            //}
        }

        private void pageFooter_Format(object sender, EventArgs e)
        {
            //label19.Text = String.Format("{0}", int.Parse(label19.Text) + 1);
        }
        private void Subrpt_ylenh_DienBien_DataInitialize(object sender, EventArgs e)
        {
            DataDynamics.ActiveReports.DataSources.SqlDBDataSource _ds = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            _ds.ConnectionString = GlobalModuls.Global.glbConnectionString;
            _ds.SQL = string.Format("set dateformat dmy HH:MM:SS: select a.MaVaoVien, b.SoPhieu, b.NgayChiDinh, (select Distinct Case when((d.LoaiDichvu Like N'C%') or(d.LoaiDichVu = 'E03')) then d.TenDichvu + ' x ( ' + CONVERT(nvarchar(50), convert(int, sum(C.SoLuong))) + ' ' + d.DVT + ' )' end as DienBienBenh) as DienBienBenh, "
                                    +" cs.TenCDChamSoc,b.BacSyDT,d.TenTat,KP.TenKhoa,BN.HoTen,BN.NAMSINH,A.DIACHI,case when bn.GioiTinh = 1 then N'Nam' else N'Nữ' end GioiTinnh, a.ChanDoan_KhoaDT,ttt.ThuTu_KeDon,ttt.HoatChat,ttt.TenThuocXml,Case when b.Nhom = 1 or b.CapCuu = 0 then 'BT' end as BatThuong,b.DienBienBenh as DienBien,loaidv.TenLoaiDichvu,d.LoaiDichvu "
                                    + " from NAMDINH_QLBN.dbo.BENHNHAN_CHITIET a inner join Namdinh_qlbn.dbo.BENHNHAN_PHIEUDIEUTRI b on a.MaVaoVien = b.MaVaoVien"
                                    + " inner join NAMDINH_QLBN.dbo.PHIEUDIEUTRI_CHITIET c on c.SoPhieu = b.SoPhieu"
                                    + " inner join NAMDINH_QLBN.DBO.INPHIEUTHANHTOAN d on d.MaDichvu = c.MaDichVu and(d.LoaiDichvu Like N'C%')"
                                    + " inner join NAMDINH_QLBN.dbo.DMCHEDOCHAMSOC cs on cs.MaCDChamSoc = b.CDChamSoc inner join NAMDINH_QLBN.DBO.BENHNHAN BN ON BN.MaBenhNhan = A.MaBenhNhan"
                                    + " INNER JOIN NAMDINH_QLBN.DBO.DMKHOAPHONG KP ON KP.MaKhoa = B.MaKhoa inner join DMLOAIDICHVU loaidv on loaidv.MaLoaiDichvu = d.LoaiDichvu"
                                    + " left join (select * from NAMDINH_QLBN.dbo.templ_phieudieutri) e  on e.sophieu = b.SoPhieu and e.madichvu = c.MaDichVu"
                                    + " left join(select distinct THuocId, HoatChat, HamLuong_NongDo, DuongDung_DangBC, MaDuongDung, GiaTTBHYT, TTThau, ThuTu_KeDon, Cong_Bo, TenThuocXml from NAMDINH_DUOC.dbo.ThongTinThuoc) ttt on ttt.ThuocID = c.MaDichVu and(c.DonGia = ttt.GiaTTBHYT or(ttt.ThuocID like N'%MAU-MA%')) and(ttt.Cong_Bo = (select Max(Cong_Bo)  from Namdinh_duoc.dbo.ThongTinThuoc where thuocid = ttt.ThuocID and GiaTTBHYT = ttt.GiaTTBHYT)) "
                                    + " WHERE A.MaVaoVien = N'{0}' and b.Makhoa = N'{1}'", _MaVaoVien, _MaKhoa);
            if(_Chon == true)
            {
                _ds.SQL += string.Format("And B.NgayChidinh between '{0:dd/MM/yyyy HH:mm:ss}' and '{1:dd/MM/yyyy HH:mm:ss}' Group by a.MaVaoVien,b.SoPhieu,b.NgayChiDinh,d.LoaiDichvu,d.TenDichvu,d.DVT, c.Ghichu,cs.TenCDChamSoc,b.BacSyDT,e.Stt,d.TenTat,KP.TenKhoa,BN.HoTen,BN.NAMSINH,A.DIACHI,GioiTinh,a.ChanDoan_KhoaDT,ttt.ThuTu_KeDon,HoatChat,DuongDung_DangBC,HamLuong_NongDo,TenThuocXml,b.Nhom,b.CapCuu,b.DienBienBenh,loaidv.TenLoaiDichvu order by NgayChiDinh,SoPhieu,ThuTu_KeDon", _TuNgay,_DenNgay);
            }
            else
            {
                _ds.SQL += string.Format(" Group by a.MaVaoVien,b.SoPhieu,b.NgayChiDinh,d.LoaiDichvu,d.TenDichvu,d.DVT, c.Ghichu,cs.TenCDChamSoc,b.BacSyDT,e.Stt,d.TenTat,KP.TenKhoa,BN.HoTen,BN.NAMSINH,A.DIACHI,GioiTinh,a.ChanDoan_KhoaDT,ttt.ThuTu_KeDon,HoatChat,DuongDung_DangBC,HamLuong_NongDo,TenThuocXml,b.Nhom,b.CapCuu,b.DienBienBenh,loaidv.TenLoaiDichvu order by NgayChiDinh,SoPhieu,ThuTu_KeDon ", _TuNgay, _DenNgay);
            }
            this.DataSource = _ds;

            //DataDynamics.ActiveReports.DataSources.SqlDBDataSource _ds1 = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            //_ds1.ConnectionString = GlobalModuls.Global.glbConnectionString;
            //_ds1.SQL = string.Format("set dateformat dmy HH:MM:SS: select * from (select a.MaVaoVien, b.SoPhieu, b.NgayChiDinh, "
            //+ " (select Distinct Case when ((d.LoaiDichvu Like N'C%') or (d.LoaiDichVu = 'E03')) then d.TenDichvu + ' x ( ' + CONVERT(nvarchar(50),convert(int,sum(C.SoLuong))) + ' '+ d.DVT + ' )'  when d.LoaiDichvu in ('D01','D03') then ttt.TenThuocXml +  ' x  ' + CONVERT(nvarchar(50),convert(int,sum(C.SoLuong))) + ' ' + d.DVT + '  ( ' + c.Ghichu + ' )' end as DienBienBenh) as DienBienBenh,  "
            //+ " e.Stt ,Case when d.LoaiDichvu in ('D01','D03') then ttt.TenThuocXml +  "
            ////+ "' ('+ ttt.HamLuong_NongDo + ',' + ttt.DuongDung_DangBC + ')' + "
            //+ "' x  ' + CONVERT(nvarchar(50),convert(int,sum(C.SoLuong))) + ' ' + d.DVT + '  ( ' + c.Ghichu + ' )' end as Ylenh, "
            //+ " cs.TenCDChamSoc,b.BacSyDT,d.TenTat,KP.TenKhoa,BN.HoTen,BN.NAMSINH,A.DIACHI,case when bn.GioiTinh = 1 then N'Nam' else N'Nữ' end GioiTinnh,a.ChanDoan_KhoaDT,ttt.ThuTu_KeDon,ttt.HoatChat,ttt.TenThuocXml,Case when b.Nhom = 1 or b.CapCuu = 0 then 'BT' end as BatThuong,b.DienBienBenh as DienBien,loaidv.TenLoaiDichvu,d.LoaiDichvu from NAMDINH_QLBN.dbo.BENHNHAN_CHITIET a"
            //+ " inner join Namdinh_qlbn.dbo.BENHNHAN_PHIEUDIEUTRI b on a.MaVaoVien = b.MaVaoVien"
            //+ " inner join NAMDINH_QLBN.dbo.PHIEUDIEUTRI_CHITIET c on c.SoPhieu = b.SoPhieu"
            //+ " inner join NAMDINH_QLBN.DBO.INPHIEUTHANHTOAN d on d.MaDichvu = c.MaDichVu and ((d.LoaiDichvu in ('D01','D03','E03') and d.MaDichvu not in ('MAU-MA-0065','MAU-MA-0075','MAU-MA-0076','MAU-MA-0099'))  or d.LoaiDichvu Like N'C%') "
            //+ " inner join NAMDINH_QLBN.dbo.DMCHEDOCHAMSOC cs on cs.MaCDChamSoc = b.CDChamSoc"
            //+ " inner join NAMDINH_QLBN.DBO.BENHNHAN BN ON BN.MaBenhNhan  = A.MaBenhNhan"
            //+ " INNER JOIN NAMDINH_QLBN.DBO.DMKHOAPHONG KP ON KP.MaKhoa = B.MaKhoa"
            //+ " inner join DMLOAIDICHVU loaidv on loaidv.MaLoaiDichvu = d.LoaiDichvu"
            //+ " left join (select * from NAMDINH_QLBN.dbo.templ_phieudieutri) e  on e.sophieu = b.SoPhieu and e.madichvu = c.MaDichVu"
            //+ " left join (select distinct THuocId,HoatChat,HamLuong_NongDo,DuongDung_DangBC,MaDuongDung,GiaTTBHYT,TTThau,ThuTu_KeDon,Cong_Bo,TenThuocXml from NAMDINH_DUOC.dbo.ThongTinThuoc) ttt on ttt.ThuocID= c.MaDichVu and (c.DonGia = ttt.GiaTTBHYT or (ttt.ThuocID like N'%MAU-MA%')) and (ttt.Cong_Bo = (select Max(Cong_Bo)  from Namdinh_duoc.dbo.ThongTinThuoc where thuocid = ttt.ThuocID and GiaTTBHYT = ttt.GiaTTBHYT))"
            //+ " WHERE A.MaVaoVien = '{0}' and b.Makhoa = '{1}'", _MaVaoVien, _MaKhoa);
            //if (_Chon == true)
            //{
            //    _ds1.SQL += string.Format("And B.NgayChidinh between '{0:dd/MM/yyyy HH:mm:ss}' and '{1:dd/MM/yyyy HH:mm:ss}' Group by a.MaVaoVien,b.SoPhieu,b.NgayChiDinh,d.LoaiDichvu,d.TenDichvu,d.DVT, c.Ghichu,cs.TenCDChamSoc,b.BacSyDT,e.Stt,d.TenTat,KP.TenKhoa,BN.HoTen,BN.NAMSINH,A.DIACHI,GioiTinh,a.ChanDoan_KhoaDT,ttt.ThuTu_KeDon,HoatChat,DuongDung_DangBC,HamLuong_NongDo,TenThuocXml,b.Nhom,b.CapCuu,b.DienBienBenh,loaidv.TenLoaiDichvu) X order by NgayChiDinh,SoPhieu,ThuTu_KeDon,TenThuocXml ", _TuNgay, _DenNgay);
            //}
            //else
            //{
            //    _ds1.SQL += string.Format(" Group by a.MaVaoVien,b.SoPhieu,b.NgayChiDinh,d.LoaiDichvu,d.TenDichvu,d.DVT, c.Ghichu,cs.TenCDChamSoc,b.BacSyDT,e.Stt,d.TenTat,KP.TenKhoa,BN.HoTen,BN.NAMSINH,A.DIACHI,GioiTinh,a.ChanDoan_KhoaDT,ttt.ThuTu_KeDon,HoatChat,DuongDung_DangBC,HamLuong_NongDo,TenThuocXml,b.Nhom,b.CapCuu,b.DienBienBenh,loaidv.TenLoaiDichvu) X order by NgayChiDinh,SoPhieu,ThuTu_KeDon,TenThuocXml ", _TuNgay, _DenNgay);
            //}
            //this.DataSource = _ds1;
        }
    }
}
