using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using System.Drawing.Printing;

namespace NamDinh_QLBN.Reports
{
    /// <summary>
    /// Summary description for repToDieuTri.
    /// </summary>
    public partial class repToDieuTri : DataDynamics.ActiveReports.ActiveReport3
    {
        private String _MaVaoVien, _MaKhoa;
        private int page = 0;
        public bool dautrang;
        public int cuoitrang;
        public int luutrang;
        public float x = (float)0.0;
        public float y = (float)0.0;
        public repToDieuTri(String MaVaoVien, String MaKhoa)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            _MaVaoVien = MaVaoVien;
            _MaKhoa = MaKhoa;
        }

        private void repToDieuTri_ReportStart(object sender, EventArgs e)
        {
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.PageSettings.Orientation = PageOrientation.Portrait;
            this.PageSettings.Margins.Top = (float)0.5;
            this.PageSettings.Margins.Left = (float)0.5;
            this.PageSettings.Margins.Right = (float)0.4;
            //this.PageSettings.PaperHeight = (float)10.5;
            this.PageSettings.Margins.Bottom = (float)0.1;
        }

        //private int RowNumber;  // Counts records to output
        private void detail_Format(object sender, EventArgs e)
        {

        }
        private void repToDieuTri_DataInitialize(object sender, EventArgs e)
        {
            DataDynamics.ActiveReports.DataSources.SqlDBDataSource _ds = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            System.Data.SqlClient.SqlCommand Cmd = new System.Data.SqlClient.SqlCommand();
            Cmd.Connection = GlobalModuls.Global.ConnectSQL;
            //_ds.ConnectionString = GlobalModuls.Global.glbConnectionString;
            Cmd.CommandText = String.Format("if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Thuoc]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)"
                    + " drop table [dbo].[Thuoc]"
                    + " CREATE TABLE dbo.Thuoc ("
                    + "     YLenh nvarchar (Max),"
                    + " 	NgayChiDinh datetime,"
                    + " 	MaKhoa nvarchar(50),"
                    + "     DienBienBenh nvarchar (Max), loaidichvu nvarchar(50),BacSyDT nvarchar(50)"
                    + " ) "
                    + " declare @TenDichVu nvarchar(Max) declare @CSDD nvarchar(20)      declare @YLenh nvarchar(Max)     declare @SoLuong nvarchar(2)     declare @NgayChiDinh datetime   declare @NgayChiDinh1 datetime	declare @NgayChiDinh2 date declare @madichvu nvarchar(50) declare @madichvu1 nvarchar(50) declare @sl2_thuoc nvarchar(2) declare @MaKhoa nvarchar(50)     declare @DienBienBenh nvarchar(Max)     declare @YLenh1 nvarchar(Max)     declare @YLenh2 nvarchar(Max)     declare @DienBienBenh1 nvarchar(Max)     declare @DienBienBenh2 nvarchar(Max)     declare @LoaiDichvu nvarchar(50)     declare @LoaiDichvu1 nvarchar(50)    declare @BacSyDT nvarchar(50)    declare @BacSyDT1 nvarchar(50)    declare @STT int  "
                    + " declare Cur Cursor"
                    + " for "
                    + " Select thuoc as tendichvu, '' as SL,  NGAYCHIDINH, Makhoa, DienBienBenh,'' as YLenh, Loaidichvu, BacSyDT, 0 as Stt, MaDichVu,CSDD"
                    + " from(select B.SOHSBA, A.HoTen, A.NamSinh, B.Buong, B.Giuong, KHOA.ChanDoan, Convert(datetime,C.NGAYCHIDINH) as NGAYCHIDINH, C.DienBienBenh, Ylenh, case e.TenTat when '' then  Tendichvu else e.TenTat  end as Thuoc, D.SoLuong as sl1,"
                    + " e.DVT as DVT_Thuoc, d.ghichu, khoa.makhoa, e.LoaiDichvu, '' as BacSyDT, d.MaDichVu,'' as CSDD"
                    + " from NAMDINH_QLBN.DBO.BENHNHAN A INNER JOIN NAMDINH_QLBN.DBO.BENHNHAN_CHITIET B ON A.MaBenhNhan = B.MaBenhNhan"
                    + " INNER JOIN NAMDINH_QLBN.DBO.ViewKHOAHIENTAI KHOA ON KHOA.MaVaoVien = B.MAVAOVIEN and KHOA.makhoa='{1}'"
                    + " INNER JOIN NAMDINH_QLBN.DBO.BENHNHAN_PHIEUDIEUTRI C ON C.MaVaoVien = B.MAVAOVIEN AND C.MAKHOA = KHOA.MaKhoa"
                    + " INNER JOIN NAMDINH_QLBN.DBO.PHIEUDIEUTRI_CHITIET D ON D.SOPHIEU = C.SOPHIEU"
                    + " INNER JOIN NAMDINH_SYSDB.DBO.dmdichvu E ON e.loaidichvu = d.loaidichvu and E.MaDichvu = d.MaDichVu and((e.LoaiDichvu like N'C%'))"
                    + " where b.MaVaoVien = {0})X "
                    + " Union all"
                    + " Select Thuoc"
                    + " + ' x ' + Convert(Nvarchar(5),convert (int,sl1)) + ' ' + DVT_Thuoc + ' ' + char(13) + CHAR(10) + '               '+ GhiChu + char(13) + CHAR(10) as tendichvu, '' as SL,"
                    + "        NGAYCHIDINH, Makhoa, DienBienBenh, YLenh, Loaidichvu, 'BS: ' + BacSyDT, STT, MaDichVu, chamsoc + ',' + DinhDuong as CSDD"
                    + "        from(select Convert(datetime,C.NGAYCHIDINH) as NGAYCHIDINH,DMCHEDOCHAMSOC.TenCDChamSoc as ChamSoc,isnull(DMCHEDODINHDUONG.TenCDDinhDuong,'') As DinhDuong, C.DienBienBenh, Ylenh, e.TenThuocXML as Thuoc,"
                    + "        D.SoLuong as sl1, f.DVT DVT_Thuoc, d.ghichu, khoa.makhoa, d.LoaiDichvu, c.BacSyDT as BacSyDT, e.STT, d.MaDichVu"
                    + "        from NAMDINH_QLBN.DBO.BENHNHAN A INNER JOIN NAMDINH_QLBN.DBO.BENHNHAN_CHITIET B ON A.MaBenhNhan = B.MaBenhNhan"
                    + "        INNER JOIN NAMDINH_QLBN.DBO.ViewKHOAHIENTAI KHOA ON KHOA.MaVaoVien = B.MAVAOVIEN and KHOA.makhoa='{1}'"
                    + "        INNER JOIN NAMDINH_QLBN.DBO.BENHNHAN_PHIEUDIEUTRI C ON C.MaVaoVien = B.MAVAOVIEN AND C.MAKHOA = KHOA.MaKhoa"
                    + "        INNER JOIN NAMDINH_QLBN.DBO.PHIEUDIEUTRI_CHITIET D ON D.SOPHIEU = C.SOPHIEU"
                    + "        INNER JOIN NAMDINH_DUOC.DBO.ttt_2709_01 E ON E.ThuocID = d.MaDichVu and e.GiaTTBHYT = d.DonGia "
                    + "        INNER JOIN NAMDINH_QLBN.DBO.DMDICHVU F ON f.loaidichvu = D.loaidichvu and f.MaDichvu = E.ThuocID and f.DongiaBHYT = e.GiaTTBHYT left JOIN     DMCHEDOCHAMSOC ON DMCHEDOCHAMSOC.MaCDChamSoc=C.CDChamSoc left JOIN DMCHEDODINHDUONG ON DMCHEDODINHDUONG.MaCDDinhDuong=C.CDDinhDuong"
                    + "    where b.MaVaoVien = {0} and (d.LoaiDichVu in('D01') or (f.loaidichvu = 'D03' and f.madichvu not in('MAU-MA-0065','MAU-MA-0075','MAU-MA-0076'))))Y"
                    + "    order by ngaychidinh,Stt  DESC"
                    + "    open Cur fetch next from Cur into @TenDichVu, @SoLuong, @NgayChiDinh, @MaKhoa, @DienBienBenh1, @YLenh1, @LoaiDichvu,@BacsyDT,@STT,@madichvu,@CSDD"
                    + "    WHILE @@FETCH_STATUS = 0 "
                    + "     begin "
                    + "        if (@NgayChiDinh = @NgayChiDinh1) "
                    + "                    begin "
                    + "            if (@LoaiDichvu = 'D01')  Begin  set @madichvu1 = @madichvu			  declare Cur1 Cursor for select  NGAYCHIDINH from(select distinct Convert(date,C.NGAYCHIDINH) as NGAYCHIDINH,dmthuoc.NhomThuoc,d.madichvu from NAMDINH_QLBN.DBO.BENHNHAN A INNER JOIN NAMDINH_QLBN.DBO.BENHNHAN_CHITIET B ON A.MaBenhNhan = B.MaBenhNhan    			  INNER JOIN NAMDINH_QLBN.DBO.ViewKHOAHIENTAI KHOA ON KHOA.MaVaoVien = B.MAVAOVIEN    			  INNER JOIN NAMDINH_QLBN.DBO.BENHNHAN_PHIEUDIEUTRI C ON C.MaVaoVien = B.MAVAOVIEN AND C.MAKHOA = KHOA.MaKhoa    			  INNER JOIN NAMDINH_QLBN.DBO.PHIEUDIEUTRI_CHITIET D ON D.SOPHIEU = C.SOPHIEU    			  INNER JOIN NAMDINH_DUOC.DBO.ttt_2709_01 E ON E.ThuocID = d.MaDichVu and e.GiaTTBHYT = d.DonGia and d.LoaiDichVu in('D01')  INNER JOIN NAMDINH_QLBN.DBO.DMDICHVU F ON f.loaidichvu = D.loaidichvu and f.MaDichvu = E.ThuocID and f.DongiaBHYT = e.GiaTTBHYT   INNER JOIN NAMDINH_DUOC.DBO.DANHMUCTHUOC DMTHUOC ON DMTHUOC.THUOCID = E.THUOCID AND DMTHUOC.NHOMTHUOC IN('GN','CT','KS','HT') where b.MaVaoVien = {0} and d.MaDichVu = @madichvu1)Y  order by NGAYCHIDINH DESC			open Cur1 fetch next from Cur1 into   @ngaychidinh2 			set @sl2_thuoc = '' 			WHILE @@FETCH_STATUS = 0			begin		 if(@ngaychidinh2 = convert(date,@ngaychidinh1)) begin set @sl2_thuoc = 1 end			 if(@ngaychidinh2 < convert(date,@ngaychidinh1)) begin set @sl2_thuoc = @sl2_thuoc+1 end			 fetch next from Cur1 into  @ngaychidinh2			end			close Cur1    DEALLOCATE Cur1"
                    + "                    Set @YLenh = Isnull(@sl2_thuoc,'     ') + '     '+ @TenDichVu + @YLenh "
                    + "                     Set @DienBienBenh = @DienBienBenh1  end"
                    + "            else "
                    + "                    Set @DienBienBenh =  @DienBienBenh +  @TenDichVu + Convert(nvarchar, @SoLuong) "
                    + "                     SET @CSDD = ''"
                    + "            end "
                    + "        else   "
                    + "              begin "
                    + "              if (@NgayChiDinh1 is not null)    "
                    + "                      begin "
                    + "                      Set @YLenh = @YLenh + isnull(@YLenh2, '     ') "
                    + "                      Set @DienBienBenh = @DienBienBenh + isnull(@DienBienBenh2, '') "
                    + "                      insert into thuoc(YLenh, NgayChiDinh, MaKhoa, DienBienBenh, loaidichvu,BacsyDT) values(@YLenh + Char(10)+ '                     ' +@CSDD+Char(10)+ Char(10)+Char(10) + '                                 '+ @BacsyDT1 , @NgayChiDinh1, @MaKhoa, @DienBienBenh, @LoaiDichvu1,@BacsyDT1)"
                    + "                      end "
                    + "               Set @YLenh = '     '"
                    + "               Set @YLenh2 = @YLenh1  "
                    + "               Set @DienBienBenh = '' "
                    + "               Set @DienBienBenh2 = @DienBienBenh1 "
                    + "              begin "
                    + "            if (@LoaiDichvu = 'D01' or @LoaiDichvu = 'D03')  Begin"
                    + "                    Set @YLenh = @YLenh  + @TenDichVu  + Convert(nvarchar, @SoLuong) "
                    + "                     Set @DienBienBenh = @DienBienBenh1  end"
                    + "             else "
                    + "              Set @DienBienBenh = @TenDichVu + Convert(nvarchar, @SoLuong)"
                    + "                     SET @CSDD = ''"
                    + "             end "
                    + "             Set @NgayChiDinh1 = @NgayChiDinh "
                    + "             set @LoaiDichvu1 = @LoaiDichvu "
                    + "             set @BacSyDT1 = @BacSyDT"
                    + "             end "
                    + "              fetch next from Cur into @TenDichVu, @SoLuong, @NgayChiDinh, @MaKhoa, @DienBienBenh1, @YLenh1, @LoaiDichvu,@BacsyDT,@STT,@madichvu,@CSDD "
                    + "    end "
                    + "              Set @YLenh = @YLenh + isnull(@YLenh2, '    ') "
                     + "              Set @DienBienBenh = @DienBienBenh  + isnull(@DienBienBenh2, '') "
                    + "             insert into thuoc(YLenh, NgayChiDinh, MaKhoa, DienBienBenh,loaidichvu,BacSyDT) "
                    + "             values( Char(13) + @YLenh, @NgayChiDinh1, @MaKhoa, @DienBienBenh, @LoaiDichvu,@BacSyDT1)"
                    + "              close Cur "
                    + "              DEALLOCATE Cur "
                    + " select Hoten,Tuoi,GioiTinh,DiaChi,chandoan,case when xx.loaidichvu like N'C%' then '' else YLenh end as Ylenh, NgayChiDinh,DienBienBenh,SoHSBA,TenKhoa from ("
                    + " Select benhnhan.Hoten,N'Tuổi: ' + convert(nvarchar,year(getdate()) - benhnhan.NamSinh) as Tuoi,  case when GioiTinh=0 then N'Giới tính: Nữ'  else N'Giới tính: Nam' end as GioiTinh,N'Ðịa chỉ: ' + isnull(DiaChi,'') as DiaChi,  N'Chẩn đoán: ' + viewkhoahientai.chandoan as chandoan, thuoc.YLenh,thuoc.NgayChiDinh,thuoc.DienBienBenh,N'Số vào viện: ' + aa.SoHSBA as SoHSBA,khoa.TenKhoa,Thuoc.loaidichvu"
                    + "  from ((select * from benhnhan_chitiet where mavaovien ='{0}') aa "
                    + " inner join benhnhan on benhnhan.mabenhnhan = aa.mabenhnhan "
                    + " inner join viewkhoahientai on viewkhoahientai.mavaovien = aa.mavaovien "
                    + " inner join DMkhoaphong khoa on Khoa.MaKhoa = viewkhoahientai.MaKhoa "
                    + " left join thuoc on thuoc.makhoa='{1}')) XX"
                    //+ " inner join (select distinct pdt.NgayChiDinh,pdt.Nhom  from  BENHNHAN_PHIEUDIEUTRI pdt where MaVaoVien  = '{0}' ) YY on xx.NgayChiDinh = yy.NgayChiDinh"
                    + "  order by XX.NgayChiDinh"

                    //+ " Select benhnhan.Hoten,N'Tuổi: ' + convert(nvarchar,year(getdate()) - benhnhan.NamSinh) as Tuoi,case when GioiTinh=0 then N'Giới tính: Nữ' "
                    //+ " else N'Giới tính: Nam' end as GioiTinh,N'Ðịa chỉ: ' + isnull(DiaChi,'') as DiaChi,"
                    //+ " N'Chẩn đoán: ' + viewkhoahientai.chandoan as chandoan,thuoc.YLenh,thuoc.NgayChiDinh,thuoc.DienBienBenh,N'Số vào viện: ' + aa.SoHSBA as SoHSBA,khoa.TenKhoa from"
                    //+ " (select * from benhnhan_chitiet where mavaovien ='{0}') aa"
                    //+ " inner join benhnhan on benhnhan.mabenhnhan = aa.mabenhnhan"
                    //+ " inner join viewkhoahientai on viewkhoahientai.mavaovien = aa.mavaovien"
                    // + " inner join DMkhoaphong khoa on Khoa.MaKhoa = viewkhoahientai.MaKhoa"
                    //+ " left join thuoc on thuoc.makhoa='{1}' order by thuoc.NgayChiDinh"
                    + " drop table dbo.Thuoc", _MaVaoVien, _MaKhoa);
                System.Data.SqlClient.SqlDataReader dr = Cmd.ExecuteReader();
                this.DataSource = dr;
                //while (dr.Read())
                //{
                //    textBox3.Text = dr["YLenh"].ToString();
                //}
                //dr.Close();
                Cmd.Dispose();
        }
        private void detail_BeforePrint(object sender, EventArgs e)
        {
            foreach (TextBox txt in detail.Controls)
            {
                txt.Height = detail.Height;
                y = txt.Height + y;
                //bool x = true;
            }
            //if (page % 2 == 0)
            //{
            //    if (y < PageSettings.PaperHeight - PageSettings.Margins.Top - PageSettings.Margins.Bottom- pageHeader.Height)
            //    {
            //        this.detail.NewPage = NewPage.None;
            //        y = (float)0.0;

            //    }
            //    else
            //    {
            //        this.detail.NewPage = NewPage.After;
            //        y = (float)0.0;
                    
            //    }
            //}
            //else
            //if (y < PageSettings.PaperHeight - PageSettings.Margins.Top - PageSettings.Margins.Bottom- pageHeader.Height)
            //{
            //    this.detail.NewPage = NewPage.None;
            //    y = (float)0.0;
            //}
            //else
            //{
            //    this.detail.NewPage = NewPage.After;
            //    y = (float)0.0;
            //}

        }

        private void repToDieuTri_FetchData(object sender, FetchEventArgs eArgs)
        {

        }

        private void reportFooter1_BeforePrint(object sender, EventArgs e)
        {
            //headerpager = page;
        }

        private void reportHeader1_BeforePrint(object sender, EventArgs e)
        {
            //page += 1;
            //txtPage.Text = "Trang " + page.ToString();
            
        }
        private void repToDieuTri_PageStart(object sender, EventArgs e)
        {
            page += 1;
            txtPage.Text = "Trang " + page.ToString();
            if (page % 2 == 0)
            {
                pageHeader.Visible = false;
            }
            else
            {
                pageHeader.Visible = true;
            }
        }

        private void reportFooter1_Format(object sender, EventArgs e)
        {
            //foterpager = page;
        }

        private void reportFooter1_AfterPrint(object sender, EventArgs e)
        {
            //foterpager = page;
        }

        private void reportHeader1_AfterPrint(object sender, EventArgs e)
        {
      
            
            //headerpager = page;
        }

        private void pageHeader_Format(object sender, EventArgs e)
        {
         

        }

        private void pageFooter_BeforePrint(object sender, EventArgs e)
        {
       
        }

        private void reportHeader1_Format(object sender, EventArgs e)
        {
            //if (page == 3)
            //{
            //    reportHeader1.Visible = true;
            //}
        }
    }
}
