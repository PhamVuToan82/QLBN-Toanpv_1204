using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace NamDinh_QLBN.Reports.BaoCaoNoiTru.HoatDongChuyenMon
{
    /// <summary>
    /// Summary description for repDanhSachBNChuyenVien.
    /// </summary>
    public partial class repHoatDongChuyenMon : DataDynamics.ActiveReports.ActiveReport3
    {
        private System.DateTime _TNgay, _DNgay;
        private String _MaKhoa;

        public repHoatDongChuyenMon(System.DateTime TNgay, System.DateTime DNgay, String MaKhoa, String TenKhoa)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            _TNgay = TNgay;
            _DNgay = DNgay;
            _MaKhoa = MaKhoa;
            lbKhoa.Text = TenKhoa;
            System.TimeSpan Ngay1 = TNgay - DNgay;
            if (Ngay1.Days == 0)
            {
                lblNgayThang.Text = string.Format("Ngày {0:dd} tháng {0:MM} năm {0:yyyy}", TNgay);
            }
            else
            {
                lblNgayThang.Text = string.Format("Từ ngày {0:dd/MM/yyyy} đến ngày {1:dd/MM/yyyy}", TNgay, DNgay);
            }
        }

        private void detail_BeforePrint(object sender, EventArgs e)
        {
            foreach (TextBox txt in detail.Controls)
                txt.Height = detail.Height;
        }

        private void detail_Format(object sender, EventArgs e)
        {
            TT.Text = string.Format("{0}", int.Parse(TT.Text.Trim()) + 1);
        }

        private void pageFooter_Format(object sender, EventArgs e)
        {
            lbPage.Text = string.Format("{0}", int.Parse(lbPage.Text) + 1);
        }

        private void repDanhSachBNChuyenVien_DataInitialize(object sender, EventArgs e)
        {
             DataDynamics.ActiveReports.DataSources.SqlDBDataSource _ds = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            _ds.ConnectionString = GlobalModuls.Global.glbConnectionString;
            //_ds.SQL = String.Format("DECLARE @SOGIUONG INT"
            //    + " DECLARE @NgayVao Datetime"
            //    + " DECLARE @NgayRa Datetime"
            //    + " DECLARE @NgayTinh Datetime"
            //    + " DECLARE @Day Int"
            //    + " DECLARE @SOBN_DDT DECIMAL(11,0)"
            //    + " DECLARE @SOBN_RV DECIMAL(11,0)"
            //    + " DECLARE @NGAYDT_TB DECIMAL(11,2)"
            //    + " DECLARE @TONGSONGAY_DT DECIMAL(11,0)"
            //    + " DECLARE @CONGSUAT_GIUONG DECIMAL(11,2) "
            //    + " DECLARE @CHETTRUOC_24 DECIMAL(11,0)"
            //    + " DECLARE @CHETSAU_24 DECIMAL(11,0)"
            //    + " DECLARE @CHET DECIMAL(11,2)"
            //    + " DECLARE @SOLUOTDT_VP DECIMAL(11,0)"
            //    + " DECLARE @SOLUOTDT_BH DECIMAL(11,0)"
            //    + " DECLARE @SOLUOTDT_TN DECIMAL(11,0)"
            //    + " DECLARE @SOLUOTDT_K DECIMAL(11,0)"
            //    + " SET @NgayTinh = NULL"
            //    + " SET @Day = 0"
            //    + " SET @SOBN_DDT= 0"
            //    + " SET @SOBN_RV= 0"
            //    + " SET @NGAYDT_TB = 0"
            //    + " SET @TONGSONGAY_DT = 0"
            //    + " SET @CHETTRUOC_24 = 0"
            //    + " SET @CHETSAU_24 = 0"
            //    + " SET @CHET = 0"
            //    + " SET @SOLUOTDT_VP = 0"
            //    + " SET @SOLUOTDT_BH = 0"
            //    + " SET @SOLUOTDT_TN = 0"
            //    + " SET @SOLUOTDT_K = 0"
            //    + " SET @CONGSUAT_GIUONG = 0"
            //    + " SELECT @SOGIUONG = SOGIUONG  FROM"
            //    + " DMGIUONG_KH where MaKhoa = '{0}'"
            //    + " if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TEMPS]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)"
            //    + " drop table [dbo].[TEMPS]"
            //    + " CREATE TABLE [dbo].[TEMPS] ("
            //    + " 	[NGAY] [datetime] NULL ,"
            //    + " 	[DANGDT] [int] NULL ,"
            //    + " 	[RAVIEN] [int] NULL "
            //    + " ) ON [PRIMARY]"
            //    + " DECLARE Cur CURSOR "
            //    + " FOR"
            //    + " 	SELECT 	"
            //    + " 		CASE WHEN DATEDIFF(DD,B.NGAYCHUYEN,'{1:MM/dd/yyyy}') >= 0 THEN  '{1:MM/dd/yyyy}'"
            //    + " 		ELSE "
            //    + " 			B.NGAYCHUYEN"
            //    + " 		END AS NGAYVAOKHOA,"
            //    + " 		CASE WHEN C.LANCHUYENKHOA = B.LANCHUYENKHOA + 1 THEN C.NGAYCHUYEN"
            //    + " 		ELSE"
            //    + " 			CASE WHEN A.DARAVIEN = 1 THEN A.NGAYRAVIEN"
            //    + " 			ELSE"
            //    + " 				NULL"
            //    + " 			END"
            //    + " 		END AS NGAYRAKHOA"
            //    + " 	FROM "
            //    + " 	(BENHNHAN_CHITIET A INNER JOIN BENHNHAN_KHOA B ON A.MAVAOVIEN = B.MAVAOVIEN)"
            //    + " 	LEFT JOIN BENHNHAN_KHOA C ON C.MAVAOVIEN = A.MAVAOVIEN AND C.MAKHOACD = B.MAKHOA"
            //    + " 	WHERE B.MAKHOA = '{0}'"
            //    + " 		AND DATEDIFF(DD,B.NGAYCHUYEN,'{2:MM/dd/yyyy}') >= 0"
            //    + " 		AND "
            //    + " 		("
            //    + "             (A.DARAVIEN = 0 AND A.TRANGTHAI = 1 AND C.LANCHUYENKHOA IS NULL)" // DANG DIEU TRI TAI KHOA
            //    + "         	OR"
            //    + "         	(A.DARAVIEN = 1 AND C.LANCHUYENKHOA IS NULL AND DATEDIFF(DD,A.NGAYRAVIEN,'{1:MM/dd/yyyy}') <= 0)" // DA RA VIEN
            //    + "         	OR"
            //    + "         	(C.LANCHUYENKHOA = B.LANCHUYENKHOA + 1 AND DATEDIFF(DD,C.NGAYCHUYEN,'{1:MM/dd/yyyy}') <= 0)" // CHUYEN KHOA
            //    + " 		) ORDER BY NGAYRAKHOA"
            //    + " OPEN Cur"
            //    + " FETCH NEXT FROM Cur  INTO @NgayVao,@NgayRa"
            //    + " WHILE @@FETCH_STATUS = 0"
            //    + " BEGIN"
            //    + "     SET @NgayTinh = @NgayVao"
            //    + " 	WHILE DATEDIFF(DD,@NGAYTINH,'{2:MM/dd/yyyy}') >= 0"
            //    + " 	BEGIN"
            //    + " 			SELECT @SOBN_DDT = ISNULL(DANGDT,0),@SOBN_RV = ISNULL(RAVIEN,0) FROM TEMPS WHERE DATEDIFF(DD,NGAY,@NGAYTINH) = 0"
            //    + " 			IF EXISTS(SELECT * FROM TEMPS WHERE DATEDIFF(DD,NGAY,@NGAYTINH) = 0)"
            //    + " 			BEGIN"
            //    + "                 IF DATEDIFF(DD,@NgayRa,@NGAYTINH) = 0"
            //    + "                 BEGIN"
            //    + "                     SET @SOBN_RV = @SOBN_RV + 1"
            //    + "                 END"
            //    + "                 IF @NgayRa IS NULL"
            //    + "                 BEGIN"
            //    + "                     SET @SOBN_DDT = @SOBN_DDT + 1"
            //    + "                 END"
            //    + "                 ELSE"
            //    + "                 BEGIN"
            //    + "                     IF DATEDIFF(DD,@NGAYTINH,@NgayRa) >= 0"
            //    + "                     BEGIN"
            //    + "                         SET @SOBN_DDT = @SOBN_DDT + 1"
            //    + "                     END"
            //    + "                 END"
            //    + " 				UPDATE TEMPS SET DANGDT = @SOBN_DDT,RAVIEN = @SOBN_RV WHERE DATEDIFF(DD,NGAY,@NGAYTINH) = 0"
            //    + " 			END"
            //    + " 			ELSE"
            //    + " 			BEGIN"
            //    + "                 IF DATEDIFF(DD,@NgayRa,@NGAYTINH) = 0"
            //    + "                 BEGIN"
            //    + "                     SET @SOBN_RV = @SOBN_RV + 1"
            //    + "                 END"
            //    + " 				INSERT INTO TEMPS(NGAY,DANGDT,RAVIEN) VALUES(@NGAYTINH,1,@SOBN_RV)"
            //    + " 			END"
            //    + " 		SET @NgayTinh = DATEADD(DAY,1,@NgayTinh)"
            //    + "     END"
            //    + " 	FETCH NEXT FROM Cur  INTO @NgayVao,@NgayRa"
            //    + " END"
            //    + " CLOSE Cur"
            //    + " DEALLOCATE  Cur"
            //    + " SELECT @TONGSONGAY_DT = SUM(DANGDT) FROM TEMPS"
            //    + " SELECT @NGAYDT_TB = SUM(DANGDT + RAVIEN)/CASE WHEN SUM(RAVIEN) = 0 THEN 1 ELSE SUM(RAVIEN) END FROM TEMPS"
            //    + " DROP TABLE TEMPS"
            //    + " SELECT @CHETTRUOC_24 = SUM(CASE WHEN KETQUADT = 5 THEN 1 ELSE 0  END)"
            //    + " FROM BENHNHAN_CHITIET INNER JOIN VIEWKHOAHIENTAI ON VIEWKHOAHIENTAI.MAVAOVIEN = BENHNHAN_CHITIET.MAVAOVIEN WHERE KETQUADT IN (5) AND DATEDIFF(DD,NGAYRAVIEN,'{1:MM/dd/yyyy}') <= 0 AND DATEDIFF(DD,NGAYRAVIEN,'{2:MM/dd/yyyy}') >= 0 AND VIEWKHOAHIENTAI.MAKHOA='{0}'"
            //    + " GROUP BY KETQUADT"
            //    + " SELECT @CHETSAU_24 = SUM(CASE WHEN KETQUADT = 6 THEN 1 ELSE 0  END)"
            //    + " FROM BENHNHAN_CHITIET INNER JOIN VIEWKHOAHIENTAI ON VIEWKHOAHIENTAI.MAVAOVIEN = BENHNHAN_CHITIET.MAVAOVIEN WHERE KETQUADT IN (6) AND DATEDIFF(DD,NGAYRAVIEN,'{1:MM/dd/yyyy}') <= 0 AND DATEDIFF(DD,NGAYRAVIEN,'{2:MM/dd/yyyy}') >= 0 AND VIEWKHOAHIENTAI.MAKHOA='{0}'"
            //    + " GROUP BY KETQUADT"
            //    + " SET @CHET = @CHETTRUOC_24/CASE WHEN @CHETSAU_24 = 0 THEN 1 ELSE @CHETSAU_24 END"
            //    + " SELECT @SOLUOTDT_BH = SUM(SOLUOTDT_BH),@SOLUOTDT_VP = SUM(SOLUOTDT_VP),@SOLUOTDT_TN = SUM(SOLUOTDT_TN),@SOLUOTDT_K = SUM(SOLUOTDT_K) FROM"
            //    + " (SELECT CASE WHEN V.DOITUONG = 1 THEN 1 ELSE 0 END AS SOLUOTDT_BH,"
            //    + " CASE WHEN V.DOITUONG = 3 THEN 1 ELSE 0 END AS SOLUOTDT_VP,"
            //    + " CASE WHEN V.DOITUONG = 4 THEN 1 ELSE 0 END AS SOLUOTDT_TN,"
            //    + " CASE WHEN V.DOITUONG NOT IN (1,3,4) THEN 1 ELSE 0 END AS SOLUOTDT_K FROM"
            //    + " (BENHNHAN_CHITIET A INNER JOIN BENHNHAN_KHOA B ON A.MAVAOVIEN = B.MAVAOVIEN)"
            //    + " INNER JOIN VIEWDOITUONGHIENTAI V ON V.MAVAOVIEN = A.MAVAOVIEN"
            //    + " LEFT JOIN BENHNHAN_KHOA C ON C.MAKHOACD = B.MAKHOA AND C.MAVAOVIEN = A.MAVAOVIEN "
            //   + " 	WHERE B.MAKHOA = '{0}'"
            //    + " 		AND DATEDIFF(DD,B.NGAYCHUYEN,'{2:MM/dd/yyyy}') >= 0"
            //    + " 		AND "
            //    + " 		("
            //    + "             (A.DARAVIEN = 0 AND A.TRANGTHAI = 1 AND C.LANCHUYENKHOA IS NULL)" // DANG DIEU TRI TAI KHOA
            //    + "         	OR"
            //    + "         	(A.DARAVIEN = 1 AND C.LANCHUYENKHOA IS NULL AND DATEDIFF(DD,A.NGAYRAVIEN,'{1:MM/dd/yyyy}') <= 0)" // DA RA VIEN
            //    + "         	OR"
            //    + "         	(C.LANCHUYENKHOA = B.LANCHUYENKHOA + 1 AND DATEDIFF(DD,C.NGAYCHUYEN,'{1:MM/dd/yyyy}') <= 0)" // CHUYEN KHOA
            //    + " 		)"
            //    + " GROUP BY A.MAVAOVIEN,V.DOITUONG) BB"
            //    + " SET @CONGSUAT_GIUONG = @TONGSONGAY_DT/(@SOGIUONG*(DATEDIFF(DD,'{1:MM/dd/yyyy}','{2:MM/dd/yyyy}')+1))*100"
            //    + " SELECT @SOGIUONG AS SOGIUONG,@NGAYDT_TB AS NGAYDI_TB,@CHET AS TUVONG,"
            //    + " @CHETTRUOC_24 + @CHETSAU_24 AS TONGTV,@SOLUOTDT_VP AS SOLUOTDT_VP,@SOLUOTDT_BH AS SOLUOTDT_BH,@SOLUOTDT_TN AS SOLUOTDT_TN,"
            //    + " @SOLUOTDT_K AS SOLUOTDT_K,"
            //    + " @CONGSUAT_GIUONG AS CONGSUAT_GIUONG", _MaKhoa, _TNgay, _DNgay);
            // SON SUA

            _ds.SQL = String.Format("DECLARE @SOGIUONG INT"
                + " DECLARE @NgayVao Datetime"
                + " DECLARE @NgayRa Datetime"
                + " DECLARE @NgayTinh Datetime"
                + " DECLARE @Day Int"
                + " DECLARE @SOBN_DDT DECIMAL(11,0)"
                + " DECLARE @SOBN_RV DECIMAL(11,0)"
                + " DECLARE @NGAYDT_TB DECIMAL(11,2)"
                + " DECLARE @NGAYDT_TB_CT DECIMAL(11,2)"
                + " DECLARE @TONGSONGAY_DT DECIMAL(11,0)"
                + " DECLARE @CONGSUAT_GIUONG DECIMAL(11,2) "
                + " DECLARE @CHETTRUOC_24 DECIMAL(11,0)"
                + " DECLARE @CHETSAU_24 DECIMAL(11,0)"
                + " DECLARE @CHET DECIMAL(11,2)"
                + " DECLARE @SOLUOTDT_VP DECIMAL(11,0)"
                + " DECLARE @SOLUOTDT_BH DECIMAL(11,0)"
                + " DECLARE @SOLUOTDT_TN DECIMAL(11,0)"
                + " DECLARE @SOLUOTDT_K DECIMAL(11,0)"
                + " SET @NgayTinh = NULL"
                + " SET @Day = 0"
                + " SET @SOBN_DDT= 0"
                + " SET @SOBN_RV= 0"
                + " SET @NGAYDT_TB = 0"
                + " SET @NGAYDT_TB_CT = 0"
                + " SET @TONGSONGAY_DT = 0"
                + " SET @CHETTRUOC_24 = 0"
                + " SET @CHETSAU_24 = 0"
                + " SET @CHET = 0"
                + " SET @SOLUOTDT_VP = 0"
                + " SET @SOLUOTDT_BH = 0"
                + " SET @SOLUOTDT_TN = 0"
                + " SET @SOLUOTDT_K = 0"
                + " SET @CONGSUAT_GIUONG = 0"
                + " SELECT @SOGIUONG = SOGIUONG,@NGAYDT_TB_CT = SONGAYDT_TB  FROM"
                + " DMGIUONG_KH where MaKhoa = '{0}'"
                + " if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TEMPS]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)"
                + " drop table [dbo].[TEMPS]"
                + " CREATE TABLE [dbo].[TEMPS] ("
                + " 	[NGAY] [datetime] NULL ,"
                + " 	[DANGDT] [int] NULL ,"
                + " 	[RAVIEN] [int] NULL "
                + " ) ON [PRIMARY]"
                + " DECLARE Cur CURSOR "
                + " FOR"
                + " 	SELECT 	"
                + " 		CASE WHEN DATEDIFF(DD,B.NGAYCHUYEN,'{1:MM/dd/yyyy}') >= 0 THEN  '{1:MM/dd/yyyy}'"
                + " 		ELSE "
                + " 			B.NGAYCHUYEN"
                + " 		END AS NGAYVAOKHOA,"
                + " 		CASE WHEN C.LANCHUYENKHOA = B.LANCHUYENKHOA + 1 THEN C.NGAYCHUYEN"
                + " 		ELSE"
                + " 			CASE WHEN A.DARAVIEN = 1 THEN A.NGAYRAVIEN"
                + " 			ELSE"
                + " 				NULL"
                + " 			END"
                + " 		END AS NGAYRAKHOA"
                + " 	FROM "
                + " 	(BENHNHAN_CHITIET A INNER JOIN BENHNHAN_KHOA B ON A.MAVAOVIEN = B.MAVAOVIEN)"
                + " 	LEFT JOIN BENHNHAN_KHOA C ON C.MAVAOVIEN = A.MAVAOVIEN AND C.MAKHOACD = B.MAKHOA"
                + " 	WHERE B.MAKHOA = '{0}'"
                + " 		AND DATEDIFF(DD,B.NGAYCHUYEN,'{2:MM/dd/yyyy}') >= 0"
                + " 		AND "
                + " 		("
                + "             (A.DARAVIEN = 0 AND A.TRANGTHAI = 1 AND C.LANCHUYENKHOA IS NULL)" // DANG DIEU TRI TAI KHOA
                + "         	OR"
                + "         	(A.DARAVIEN = 1 AND C.LANCHUYENKHOA IS NULL AND DATEDIFF(DD,A.NGAYRAVIEN,'{1:MM/dd/yyyy}') <= 0)" // DA RA VIEN
                + "         	OR"
                + "         	(C.LANCHUYENKHOA = B.LANCHUYENKHOA + 1 AND DATEDIFF(DD,C.NGAYCHUYEN,'{1:MM/dd/yyyy}') <= 0)" // CHUYEN KHOA
                + " 		) ORDER BY NGAYRAKHOA"
                + " OPEN Cur"
                + " FETCH NEXT FROM Cur  INTO @NgayVao,@NgayRa"
                + " WHILE @@FETCH_STATUS = 0"
                + " BEGIN"
                + "     SET @NgayTinh = @NgayVao"
                + " 	WHILE DATEDIFF(DD,@NGAYTINH,'{2:MM/dd/yyyy}') >= 0"
                + " 	BEGIN"
                + " 			SELECT @SOBN_DDT = ISNULL(DANGDT,0),@SOBN_RV = ISNULL(RAVIEN,0) FROM TEMPS WHERE DATEDIFF(DD,NGAY,@NGAYTINH) = 0"
                + " 			IF EXISTS(SELECT * FROM TEMPS WHERE DATEDIFF(DD,NGAY,@NGAYTINH) = 0)"
                + " 			BEGIN"
                + "                 IF DATEDIFF(DD,@NgayRa,@NGAYTINH) = 0"
                + "                 BEGIN"
                + "                     SET @SOBN_RV = @SOBN_RV + 1"
                + "                 END"
                + "                 IF @NgayRa IS NULL"
                + "                 BEGIN"
                + "                     SET @SOBN_DDT = @SOBN_DDT + 1"
                + "                 END"
                + "                 ELSE"
                + "                 BEGIN"
                + "                     IF DATEDIFF(DD,@NGAYTINH,@NgayRa) >= 0"
                + "                     BEGIN"
                + "                         SET @SOBN_DDT = @SOBN_DDT + 1"
                + "                     END"
                + "                 END"
                + " 				UPDATE TEMPS SET DANGDT = @SOBN_DDT,RAVIEN = @SOBN_RV WHERE DATEDIFF(DD,NGAY,@NGAYTINH) = 0"
                + " 			END"
                + " 			ELSE"
                + " 			BEGIN"
                + "                 IF DATEDIFF(DD,@NgayRa,@NGAYTINH) = 0"
                + "                 BEGIN"
                + "                     SET @SOBN_RV = @SOBN_RV + 1"
                + "                 END"
                + " 				INSERT INTO TEMPS(NGAY,DANGDT,RAVIEN) VALUES(@NGAYTINH,1,@SOBN_RV)"
                + " 			END"
                + " 		SET @NgayTinh = DATEADD(DAY,1,@NgayTinh)"
                + "     END"
                + " 	FETCH NEXT FROM Cur  INTO @NgayVao,@NgayRa"
                + " END"
                + " CLOSE Cur"
                + " DEALLOCATE  Cur"
                + " SELECT @TONGSONGAY_DT = SUM(DANGDT) FROM TEMPS"
                + " SELECT @NGAYDT_TB = SUM(DANGDT + RAVIEN)/CASE WHEN SUM(RAVIEN) = 0 THEN 1 ELSE SUM(RAVIEN) END FROM TEMPS"
                + " DROP TABLE TEMPS"
                + " SELECT @CHETTRUOC_24 = SUM(CASE WHEN KETQUADT = 5 THEN 1 ELSE 0  END)"
                + " FROM BENHNHAN_CHITIET INNER JOIN VIEWKHOAHIENTAI ON VIEWKHOAHIENTAI.MAVAOVIEN = BENHNHAN_CHITIET.MAVAOVIEN WHERE KETQUADT IN (5) AND DATEDIFF(DD,NGAYRAVIEN,'{1:MM/dd/yyyy}') <= 0 AND DATEDIFF(DD,NGAYRAVIEN,'{2:MM/dd/yyyy}') >= 0 AND VIEWKHOAHIENTAI.MAKHOA='{0}'"
                + " GROUP BY KETQUADT"
                + " SELECT @CHETSAU_24 = SUM(CASE WHEN KETQUADT = 6 THEN 1 ELSE 0  END)"
                + " FROM BENHNHAN_CHITIET INNER JOIN VIEWKHOAHIENTAI ON VIEWKHOAHIENTAI.MAVAOVIEN = BENHNHAN_CHITIET.MAVAOVIEN WHERE KETQUADT IN (6) AND DATEDIFF(DD,NGAYRAVIEN,'{1:MM/dd/yyyy}') <= 0 AND DATEDIFF(DD,NGAYRAVIEN,'{2:MM/dd/yyyy}') >= 0 AND VIEWKHOAHIENTAI.MAKHOA='{0}'"
                + " GROUP BY KETQUADT"
                + " SET @CHET = @CHETTRUOC_24/CASE WHEN @CHETSAU_24 = 0 THEN 1 ELSE @CHETSAU_24 END"
                + " SELECT @SOLUOTDT_BH = SUM(SOLUOTDT_BH),@SOLUOTDT_VP = SUM(SOLUOTDT_VP),@SOLUOTDT_TN = SUM(SOLUOTDT_TN),@SOLUOTDT_K = SUM(SOLUOTDT_K) FROM"
                + " (SELECT CASE WHEN V.DOITUONG = 1 THEN 1 ELSE 0 END AS SOLUOTDT_BH,"
                + " CASE WHEN V.DOITUONG = 3 THEN 1 ELSE 0 END AS SOLUOTDT_VP,"
                + " CASE WHEN V.DOITUONG = 4 THEN 1 ELSE 0 END AS SOLUOTDT_TN,"
                + " CASE WHEN V.DOITUONG NOT IN (1,3,4) THEN 1 ELSE 0 END AS SOLUOTDT_K FROM"
                + " (BENHNHAN_CHITIET A INNER JOIN BENHNHAN_KHOA B ON A.MAVAOVIEN = B.MAVAOVIEN)"
                + " INNER JOIN VIEWDOITUONGHIENTAI V ON V.MAVAOVIEN = A.MAVAOVIEN"
                + " LEFT JOIN BENHNHAN_KHOA C ON C.MAKHOACD = B.MAKHOA AND C.MAVAOVIEN = A.MAVAOVIEN "
               + " 	WHERE B.MAKHOA = '{0}'"
                + " 		AND DATEDIFF(DD,B.NGAYCHUYEN,'{2:MM/dd/yyyy}') >= 0"
                + " 		AND "
                + " 		("
                + "             (A.DARAVIEN = 0 AND A.TRANGTHAI = 1 AND C.LANCHUYENKHOA IS NULL)" // DANG DIEU TRI TAI KHOA
                + "         	OR"
                + "         	(A.DARAVIEN = 1 AND C.LANCHUYENKHOA IS NULL AND DATEDIFF(DD,A.NGAYRAVIEN,'{1:MM/dd/yyyy}') <= 0)" // DA RA VIEN
                + "         	OR"
                + "         	(C.LANCHUYENKHOA = B.LANCHUYENKHOA + 1 AND DATEDIFF(DD,C.NGAYCHUYEN,'{1:MM/dd/yyyy}') <= 0)" // CHUYEN KHOA
                + " 		)"
                + " GROUP BY A.MAVAOVIEN,V.DOITUONG) BB"
                //+ " SET @CONGSUAT_GIUONG = @TONGSONGAY_DT/(@SOGIUONG*(DATEDIFF(DD,'{1:MM/dd/yyyy}','{2:MM/dd/yyyy}')+1))*100"
                + " SET @CONGSUAT_GIUONG = ((@SOLUOTDT_BH + @SOLUOTDT_VP+ @SOLUOTDT_TN + @SOLUOTDT_K)*@NGAYDT_TB_CT )/(@SOGIUONG*(DATEDIFF(DD,'{1:MM/dd/yyyy}','{2:MM/dd/yyyy}')+1))*100"
                + " SELECT @SOGIUONG AS SOGIUONG,@NGAYDT_TB AS NGAYDI_TB,@CHET AS TUVONG,"
                + " @CHETTRUOC_24 + @CHETSAU_24 AS TONGTV,@SOLUOTDT_VP AS SOLUOTDT_VP,@SOLUOTDT_BH AS SOLUOTDT_BH,@SOLUOTDT_TN AS SOLUOTDT_TN,"
                + " @SOLUOTDT_K AS SOLUOTDT_K,"
                + " @CONGSUAT_GIUONG AS CONGSUAT_GIUONG", _MaKhoa, _TNgay, _DNgay);
            this.DataSource = _ds;
        }

        private void repDanhSachBNChuyenVien_ReportStart(object sender, EventArgs e)
        {
            this.Document.Name = "Danh sách bệnh nhân chuyển viện";
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.PageSettings.Orientation = PageOrientation.Portrait;

            this.PageSettings.Margins.Left = (float)0.4;
            this.PageSettings.Margins.Right = (float)0.0;
            this.PageSettings.Margins.Top = (float)0.25;
            this.PageSettings.Margins.Bottom = (float)0.2;
        }

        private void reportHeader1_Format(object sender, EventArgs e)
        {

        }
    }
}
