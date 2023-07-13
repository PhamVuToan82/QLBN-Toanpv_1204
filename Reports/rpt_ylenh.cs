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
    public partial class rpt_ylenh : DataDynamics.ActiveReports.ActiveReport3
    {
        string _MaVaoVien, _MaKhoa,_TenBuong,_TenGiuong, _SoHSBA;
        DateTime _TuNgay, _DenNgay, _NgayChiDinh;
        bool _Chon;
        string _Ylenh = "";
        //Subrpt_ylenh_DienBien rpt;
        public rpt_ylenh(string MaVaoVien, string MaKhoa,DateTime TuNgay, DateTime DenNgay,bool Chon,string HoTen,string Khoa, string gioi, string chandoan, string tuoi, string TenBuong, string TenGiuong, string SoHSBA)
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
            _SoHSBA = SoHSBA;
            _TenBuong = TenBuong;
            _TenGiuong = TenGiuong;
            textBox4.Text = Khoa;
            label13.Text = _SoHSBA;
            textBox1.Text = HoTen;
            textBox2.Text = tuoi;
            textBox10.Text = gioi;
            textBox5.Text = chandoan;
            textBox13.Text = TenBuong;
            textBox14.Text = TenGiuong;
            //_NgayChiDinh = NgayChiDinh;
        }

        private void rpt_ylenh_ReportStart(object sender, EventArgs e)
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
            
            if (Fields["Nhom"].Value.ToString() == "0" || Fields["nhom"].Value.ToString() == "0")
            {
                textBox7.Text = string.Format("{0:dd/MM/yyyy}", textBox7.Text);
            }
            else
            {
                textBox7.Text = string.Format("{0:dd/MM/yyyy HH:mm}", textBox7.Text);
            }
        }

        private void detail_BeforePrint(object sender, EventArgs e)
        {
            //textBox6.Style = "font-weight: bold; font-size: 15.75pt;";
            if (textBox8.Text == "0")
            {
                textBox7.Value = string.Format("{0:dd/MM/yyyy}", textBox7.Value);
            }
            else
            {
                textBox7.Value = string.Format("{0:dd/MM/yyyy HH:mm}", textBox7.Value);
            }

            textBox6.Height = textBox3.Height = textBox7.Height = detail.Height;


        }

        private void rpt_ylenh_FetchData(object sender, FetchEventArgs eArgs)
        {
            if (Fields["Nhom"].Value.ToString() == "0" || Fields["nhom"].Value.ToString() == "0")
            {
                textBox8.Text = "0";
            }
            else
            {
                textBox8.Text = "1";
            }
            //if(Fields["phanloai"].Value.ToString() == "YLenh")
            //{
            //    textBox3.Text = Fields["OSTag"].Value.ToString();
            //    textBox6.Text = "";
            //}
            //else
            //{
            //    textBox6.Text = Fields["OSTag"].Value.ToString();
            //    textBox3.Text = "";
            //}
            //string s = "";
            //string soluong = "";
            //if (Fields["NhomThuoc"].Value.ToString() == "GN"|| Fields["NhomThuoc"].Value.ToString() == "HT")
            //{
            //     s = GlobalModuls.Global.UpperFirstChar1(GlobalModuls.Global.WriteNum((long)Decimal.Parse(Fields["soluong"].Value.ToString())));
            //    textBox19.Text = Fields["TenDichvu"].Value.ToString() + s + Fields["ylenh"].Value.ToString();
            //}
            //else
            //    if(Fields["soluong"].Value.ToString().Length ==1)
            //{
            //    soluong = "0" + Fields["soluong"].Value.ToString();
            //    textBox19.Text = Fields["TenDichvu"].Value.ToString() + soluong + Fields["ylenh"].Value.ToString();
            //}else  textBox19.Text = Fields["TenDichvu"].Value.ToString() +  Fields["soluong"].Value.ToString() + Fields["ylenh"].Value.ToString();

            //textBox13.Text = Fields["dienbienbenh"].Value.ToString();
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

        private void pageHeader_BeforePrint(object sender, EventArgs e)
        {
            //textBox18.Text = "Số " + label19.Text;
        }

        private void pageHeader_Format(object sender, EventArgs e)
        {

        }

        private void groupFooter2_AfterPrint(object sender, EventArgs e)
        {

        }

        private void groupHeader2_Format(object sender, EventArgs e)
        {

            
        }

        private void groupFooter2_Format(object sender, EventArgs e)
        {
  
        }

        private void pageFooter_Format(object sender, EventArgs e)
        {
            label19.Text = String.Format("{0}", int.Parse(label19.Text) + 1);
        }
        private void rpt_ylenh_DataInitialize(object sender, EventArgs e)
        {
            //DataDynamics.ActiveReports.DataSources.SqlDBDataSource _ds = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            //_ds.ConnectionString = GlobalModuls.Global.glbConnectionString;
            //_ds.SQL = string.Format("set dateformat dmy HH:MM:SS: select * from (select a.MaVaoVien, b.SoPhieu, b.NgayChiDinh, "
            //+ " (select Distinct Case when ((d.LoaiDichvu Like N'C%') or (d.LoaiDichVu = 'E03')) then d.TenDichvu + ' x ( ' + CONVERT(nvarchar(50),convert(int,sum(C.SoLuong))) + ' '+ d.DVT + ' )' end as DienBienBenh) as DienBienBenh,  "
            //+ " e.Stt ,Case when d.LoaiDichvu in ('D01','D03') then ttt.TenThuocXml +  "
            ////+ "' ('+ ttt.HamLuong_NongDo + ',' + ttt.DuongDung_DangBC + ')' + "
            //+ "' x  ' + CONVERT(nvarchar(50),convert(int,sum(C.SoLuong))) + ' ' + d.DVT + '  ( ' + c.Ghichu + ' )' end as Ylenh, "
            //+ " cs.TenCDChamSoc,b.BacSyDT,d.TenTat,KP.TenKhoa,BN.HoTen,BN.NAMSINH,A.DIACHI,case when bn.GioiTinh = 1 then N'Nam' else N'Nữ' end GioiTinnh,a.ChanDoan_KhoaDT,ttt.ThuTu_KeDon,ttt.HoatChat,ttt.TenThuocXml,Case when b.Nhom = 1 or b.CapCuu = 0 then 'BT' end as BatThuong,b.DienBienBenh as DienBien,loaidv.TenLoaiDichvu,d.LoaiDichvu,b.YLenh as Ylenh_Boxung  from NAMDINH_QLBN.dbo.BENHNHAN_CHITIET a"
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
            //    _ds.SQL += string.Format("And B.NgayChidinh between '{0:dd/MM/yyyy HH:mm:ss}' and '{1:dd/MM/yyyy HH:mm:ss}' Group by a.MaVaoVien,b.SoPhieu,b.NgayChiDinh,d.LoaiDichvu,d.TenDichvu,d.DVT, c.Ghichu,cs.TenCDChamSoc,b.BacSyDT,e.Stt,d.TenTat,KP.TenKhoa,BN.HoTen,BN.NAMSINH,A.DIACHI,GioiTinh,a.ChanDoan_KhoaDT,ttt.ThuTu_KeDon,HoatChat,DuongDung_DangBC,HamLuong_NongDo,TenThuocXml,b.Nhom,b.CapCuu,b.DienBienBenh,loaidv.TenLoaiDichvu,b.YLenh) X order by NgayChiDinh,SoPhieu,ThuTu_KeDon,TenThuocXml ", _TuNgay, _DenNgay);
            //}
            //else
            //{
            //    _ds.SQL += string.Format(" Group by a.MaVaoVien,b.SoPhieu,b.NgayChiDinh,d.LoaiDichvu,d.TenDichvu,d.DVT, c.Ghichu,cs.TenCDChamSoc,b.BacSyDT,e.Stt,d.TenTat,KP.TenKhoa,BN.HoTen,BN.NAMSINH,A.DIACHI,GioiTinh,a.ChanDoan_KhoaDT,ttt.ThuTu_KeDon,HoatChat,DuongDung_DangBC,HamLuong_NongDo,TenThuocXml,b.Nhom,b.CapCuu,b.DienBienBenh,loaidv.TenLoaiDichvu,b.YLenh) X order by NgayChiDinh,SoPhieu,ThuTu_KeDon,TenThuocXml ", _TuNgay, _DenNgay);
            //}
            //this.DataSource = _ds;

            //DataDynamics.ActiveReports.DataSources.SqlDBDataSource _ds = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            //DataDynamics.ActiveReports.DataSources.SqlDBDataSource _ds2 = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            //_ds.ConnectionString = GlobalModuls.Global.glbConnectionString;
            //_ds.SQL = string.Format("select Madichvu as Ma1 from NAMDINH_QLBN.dbo.xxxx");
            //this.DataSource = _ds;
            //DataDynamics.ActiveReports.DataSources.SqlDBDataSource _ds1 = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            //_ds1.ConnectionString = GlobalModuls.Global.glbConnectionString;
            //_ds1.SQL = string.Format("select Madichvu as Ma2 from Namdinh_qlbn.dbo.yyyy");
            //this.DataSource = _ds1;
            DataDynamics.ActiveReports.DataSources.SqlDBDataSource _ds = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            _ds.ConnectionString = GlobalModuls.Global.glbConnectionString;
            //_ds.SQL = string.Format("select pdt.Ngaychidinh,bs.TenBS as BacSyDT,cs.TenCDChamSoc as TenCDChamSoc, pdt.YLenh as Ylenh_boxung ,pdt.DienBienBenh as  DienBien,x.* from NAMDINH_QLBN.dbo.benhnhan_phieudieutri pdt left join (select  distinct isnull(a.sophieu, b.sophieu) sophieucd, isnull(a.sothutu, b.sothutu) as sothutu, a.stt, a.ylenh, b.dienbienbenh, isnull(a.ngaychidinh, b.ngaychidinh) as Ngaycd,b.TenLoaiDichvu as TenLoaiDichVu,tendichvu,soluong,NhomThuoc,isnull(a.MaVaoVien,b.Mavaovien) as Mavaovien,a.ThuTu_KeDon from Ylenh_templ a full outer join dienbien_templ b on a.sothutu = b.sothutu and a.NgayChiDinh = b.NgayChiDinh) X  on pdt.MaVaoVien = X.MaVaoVien and x.sophieucd = pdt.SoPhieu inner join NAMDINH_QLBN.dbo.DMBACSY bs on bs.MaBS = pdt.mabs and bs.MaKhoa = pdt.MaKhoa inner join NAMDINH_QLBN.dbo.DMCHEDOCHAMSOC cs on cs.MaCDChamSoc = pdt.CDChamSoc where pdt.MaVaoVien = N'{0}' and pdt.MaKhoa = N'{1}' order by Ngaychidinh,ThuTu_KeDon, sothutu", _MaVaoVien, _MaKhoa);
            _ds.SQL = string.Format("exec NAMDINH_QLBN.dbo.Get_ToDieuTri");
            this.DataSource = _ds;
        }
    }
}
