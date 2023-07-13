using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
//using System.IO.IsolatedStorage;
using GlobalModuls;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using NamDinh_QLBN.Forms.Tien_ich;
using C1.Win.C1FlexGrid;
using System.Net.NetworkInformation;
using System.Data.SqlClient;

namespace NamDinh_QLBN
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class frmMain : System.Windows.Forms.Form
	{
		private System.Drawing.Color		_backColor1		= System.Drawing.Color.White;
		private System.Drawing.Color		_backColor2		= System.Drawing.Color.CornflowerBlue;
        //private int _angle = 0;
        private System.Windows.Forms.SaveFileDialog dlgSave;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem mnuHeThong;
        private ToolStripMenuItem mnuDL;
        private ToolStripMenuItem mnuTK;
        private ToolStripMenuItem mnuIn;
        private ToolStripMenuItem trợGiúpToolStripMenuItem;
        private ToolStripMenuItem mnuChangePass;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem mnuLogOn;
        private ToolStripMenuItem mnuLogOff;
        private ToolStripSeparator toolStripMenuItem2;
        private ToolStripMenuItem mnuThoat;
        private ToolStripMenuItem bệnhNhânVàoViệnToolStripMenuItem;
        private ToolStripMenuItem cậpNhậtThôngTinĐiềuTrịToolStripMenuItem;
        private ToolStripMenuItem bệnhNhânRaViệnToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem4;
        private ToolStripSeparator toolStripMenuItem5;
        private ToolStripSeparator toolStripMenuItem3;
        private ToolStripMenuItem danhMụcToolStripMenuItem;
        private ToolStripMenuItem danhMụcBuồngGiườngToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem6;
        private ToolStripMenuItem thốngKêHiệnTrạngBuồngGiườngĐiềutToolStripMenuItem;
        private ToolStripMenuItem chiPhíĐiềuTrịNộiTrúToolStripMenuItem;
        private ToolStripMenuItem danhSáchBệnhNhânTạiCácKhoaToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem7;
        private ToolStripMenuItem tùyChọnToolStripMenuItem;
        private ToolStripMenuItem danhSáchBệnhNhânVàoViệnToolStripMenuItem;
		private System.ComponentModel.IContainer components=null;
        private ToolStripMenuItem thiếtLậpDịchVụYTếTheoKhoaToolStripMenuItem;
        private ToolStripMenuItem danhSáchBệnhNhânToolStripMenuItem;
        private ToolStripMenuItem phiếuLĩnhThuốcToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem8;
        private ToolStripMenuItem toolStripMenuItem9;
        private ToolStripMenuItem toolStripMenuItem10;
        private ToolStripMenuItem thiếtLậpPhiếuInToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem11;
        private ToolStripSeparator toolStripMenuItem12;
        private ToolStripMenuItem cậpNhậtVậtTưTiêuHaoToolStripMenuItem;
        private ToolStripMenuItem thiếtLậpChỉSốSỗLĩnhThuốcToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem13;
        private ToolStripMenuItem toolStripMenuItem14;
        private ToolStripMenuItem thiếtLậpDanhSáchThuốcTrảVõToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem15;
        private ToolStripMenuItem toolStripMenuItem16;
        private ToolStripMenuItem thiếtLậpDanhSáchThủThậtToolStripMenuItem;
        private ToolStripMenuItem danhMụcPhẩuThuậtToolStripMenuItem;
        private ToolStripMenuItem danhMụcBácSỹToolStripMenuItem;
        private ToolStripMenuItem cácBáoCáoCủaKhoaPhâuThuậtToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem17;
        private ToolStripMenuItem thiếtLậpThứTựChọnDịchVụToolStripMenuItem;
        private ToolStripMenuItem sổTayĐơnThuốcToolStripMenuItem;
        private ToolStripMenuItem sổTayToolStripMenuItem;
        private ToolStripSeparator tìmKiếmBệnhNhânToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem18;
        private ToolStripMenuItem tổngHợpChiPhíĐiềuTrịToolStripMenuItem;
        private ToolStripMenuItem danhMụcNhómToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem19;
        private ToolStripSeparator toolStripSeparator5;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel txtNgayLV;
        private ToolStripStatusLabel txtNguoiDung;
        private ToolStripMenuItem toolStripMenuItem20;
        private ToolStripButton toolStripButton1;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton toolStripButton2;
        private ToolStripButton toolStripButton3;
        private ToolStripButton toolStripButton4;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripLabel toolStripLabel1;
        private ToolStripTextBox toolTimBN;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripButton toolStripButton5;
        private ToolStrip toolStrip1;
        private ToolStripMenuItem toolStripMenuItem21;
        private ToolStripMenuItem toolStripMenuItem22;
        private ToolStripMenuItem thôngKêTheoĐốiTượngBệnhNhânToolStripMenuItem;
        private ToolStripMenuItem thôngKêChiTiếtTheoĐốiTượngToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator8;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripMenuItem thốngKêChỉĐịnhCậnLâmSàngToolStripMenuItem;
        private ToolStripMenuItem tổngHợpLượngChỉĐịnhTheoBácSỹToolStripMenuItem;
        private ToolStripMenuItem thôngKêChiTiếtCLSTheoKhoaThựcHiệnToolStripMenuItem;
        private ToolStripMenuItem tổngHợpSốLượtChỉĐịnhCLSToolStripMenuItem;
        private ToolStripMenuItem tổngHợpSốLượtChỉĐịnhCLSTheoKhoaToolStripMenuItem;
        private ToolStripMenuItem tổngHợpChỉĐinhMáuToolStripMenuItem;
        private ToolStripMenuItem thốngToolStripMenuItem;
        private ToolStripMenuItem tổngHợpSốLượtTruyềnMáuToolStripMenuItem;
        private ToolStripMenuItem tổngHợpChếĐộChămSócBệnhNhânToolStripMenuItem;
        private ToolStripMenuItem thôngKêChếChiTiếtĐọChămSócToolStripMenuItem;
        private ToolStripMenuItem tổngHợpToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem23;
        private ToolStripMenuItem tổngHợpBệnhNhânChuyểnViệnToolStripMenuItem;
        private ToolStripMenuItem thôngKêDanhSáchBệnhNhânChuyểnViệnToolStripMenuItem;
        private ToolStripMenuItem thôngKêDanhSáchBệnhNhânTheoBVChuyểnĐếnToolStripMenuItem;
        private ToolStripMenuItem thốngKêDanhSáchBệnhNhânTheoBSChỉĐịnhToolStripMenuItem;
        private ToolStripMenuItem tổngHợpSốLượngChuyểnViệnTheoBVChuyểnĐếnToolStripMenuItem;
        private ToolStripMenuItem tổngHợpSốLượngChuyểnViệnTheoBSChỉĐịnhToolStripMenuItem;
        private ToolStripMenuItem tổngHợpBệnhNhânTheoNơiKhámChữaBệnhBanĐầuToolStripMenuItem;
        private ToolStripMenuItem thôngKêDanhSáchBệnhNhânTheoNơiKCBBanĐầuToolStripMenuItem;
        private ToolStripMenuItem thôngKêDanhSáchBNToolStripMenuItem;
        private ToolStripMenuItem ngàyĐiềuTrịTrungBinhToolStripMenuItem;
        private ToolStripMenuItem tổngHợpBệnhNhânTheoBuồngGiươngToolStripMenuItem;
        private ToolStripMenuItem thôngKêDanhSáchBệnhNhânTheoBuồngToolStripMenuItem;
        private ToolStripMenuItem tổngHợpSốLượtBệnhNhânTheoBuồngToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem26;
        private ToolStripMenuItem tổngHợpBệnhNhânLàmThủThuậtToolStripMenuItem;
        private ToolStripMenuItem thôngKêDanhSáchBệnhNhânToolStripMenuItem;
        private ToolStripMenuItem tổngHợpSốLượngBệnhNhânLàmThủThuậtToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem27;
        private ToolStripMenuItem thốngKêDanhSáchBệnhNhânTheoBSChỉĐịnhToolStripMenuItem1;
        private ToolStripMenuItem tổngHợpSốLượtBệnhNhânTheoBSChỉĐịnhToolStripMenuItem;
        private ToolStripMenuItem tổngHợpBệnhNhânLàmPhẩuThToolStripMenuItem;
        private ToolStripMenuItem thốngKêDanhSáchBệnhNhânLàmPhẩuThuậtToolStripMenuItem;
        private ToolStripMenuItem tổngHợpSốLượtBệnhNhânLàmPhẩuThuậtToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem28;
        private ToolStripMenuItem thổngKêDanhSáchBệnhNhânLàmPTTheoBSChỉĐịnhToolStripMenuItem;
        private ToolStripMenuItem tổngHợpSốLượngBệnhNhânToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem31;
        private ToolStripMenuItem tổngHợpLoạiBệnhÁnToolStripMenuItem;
        private ToolStripMenuItem thốngKêDanhSáchBNTheoLoạiBệnhÁnToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator11;
        private ToolStripSeparator toolStripSeparator12;
        private ToolStripMenuItem toolStripMenuItem32;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripSeparator toolStripMenuItem33;
        private ToolStripMenuItem sổTổngHợpDuyệtPhiếuChỉĐịnhToolStripMenuItem;
        private ToolStripMenuItem tổngHợpSửDụngThuốcVậtTưThoànKhoaToolStripMenuItem;
        private ToolStripMenuItem tổngHơpSưToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem34;
        private ToolStripMenuItem thôngKêThuốcVậtTưTheoBệnhNhânToànKhoaToolStripMenuItem;
        private ToolStripMenuItem thôngKêThuốcVậtTưTheoBệnhNhânBệnhNhânĐangĐiềuTrịToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator14;
        private ToolStripSeparator toolStripSeparator13;
        private ToolStripMenuItem tổngHợpSốLượtTruyềnMáuTheoToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator15;
        private ToolStripMenuItem tổngHợpSốLượngMáuTruyềnTheoLọaMáuToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator16;
        private ToolStripMenuItem toolStripMenuItem29;
        private ToolStripMenuItem inSổTổngHợpThuốcHàngNgàyToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem30;
        private ToolStripMenuItem tổngHợpToolStripMenuItem1;
        private ToolStripSeparator toolStripMenuItem35;
        private ToolStripMenuItem thốngKêChiTiếtChụpCRThToolStripMenuItem;
        private ToolStripMenuItem tổngHợpToolStripMenuItem2;
        private ToolStripMenuItem toolStripMenuItem24;
        private ToolStripMenuItem danhSáchBệnhNhânTưVongToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator9;
        private ToolStripMenuItem tổngHợpBệnhNhânTheoKếtQuảĐiềuTrịToolStripMenuItem;
        private ToolStripMenuItem phiếuLĩnhThuốcToolStripMenuItem1;
        private ToolStripMenuItem cậpNhậtBệnhNhânPhẩuThuậtToolStripMenuItem1;
        private ToolStripSeparator toolStripSeparator20;
        private ToolStripSeparator toolStripMenuItem37;
        private ToolStripMenuItem cậpNhậtVậtTưỞPhòngMỗToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem36;
        private ToolStripMenuItem toolStripMenuItem38;
        private ToolStripMenuItem báoCáoThanhToánThuốcToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem39;
        private ToolStripSeparator toolStripSeparator10;
        private ToolStripMenuItem toolStripMenuItem40;
        private ToolStripMenuItem mnuChotSoSach;
        private ToolStripMenuItem mnuThietLapNhomInVTTH;
        private ToolStripMenuItem mnuBCSuDungTaiKhoa;
        private ToolStripMenuItem hướngDẫnDựTrùVậtTưTiêuHaoToolStripMenuItem;
        private ToolStripMenuItem hướngDẫnXemBáoCáoTổngHợpVTTHToolStripMenuItem;
        private ToolStripMenuItem báoCáoSửDụngChiTiếtVậtTưTạiKhoaToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem41;
        private ToolStripMenuItem mnuPhieuLinhVTTH;
        private ToolStripMenuItem mnuPhieuHoanVTTH;
        private ToolStripMenuItem mnuPhieuLinh_VTTH;
        private ToolStripMenuItem mnuThietLapNhomVTTH;
        private ToolStripMenuItem mnuNgayGiuongBenh;
        private ToolStripMenuItem giaoBanBệnhViệnToolStripMenuItem;
        private ToolStripMenuItem DSVOCAM;
        private ToolStripMenuItem tổngHợpICD10ToolStripMenuItem;
        private ToolStripMenuItem danhSáchBệnhNhânToolStripMenuItem1;
        private ToolStripMenuItem tổngHợpTheoMãBệnhICD10ToolStripMenuItem;
        private ToolStripMenuItem báoCáoỨngToolStripMenuItem;
        private ToolStripButton toolStripButton7;
        private ToolStripButton toolStripButton8;
        private ToolStripMenuItem danToolStripMenuItem;
        private ToolStripMenuItem danhMụcĐồVảiToolStripMenuItem;
        private ToolStripMenuItem quảnLýĐồVảiToolStripMenuItem;
        private ToolStripStatusLabel txtPhienBan;
        private Timer timer1;
        private ToolStripMenuItem mnuInSoTHVTTH;
        private ToolStripSeparator toolStripSeparator17;
        private ToolStripMenuItem thốngKêDanhSáchBệnhNhânTheoKhoaThựcHiệnToolStripMenuItem;
        private ToolStripMenuItem tổngHợpSốLượngBNTheoKhoaThựcHiệnToolStripMenuItem;
        private ToolStripMenuItem quảnLýVTTHToolStripMenuItem;
        private ToolStripMenuItem nhậpTồnĐầuKỳToolStripMenuItem;
        private ToolStripMenuItem nhậnVTTHTừPhòngVậtTưToolStripMenuItem;
        private ToolStripMenuItem xácNhậnSửDụngTạiKhoaToolStripMenuItem;
        private ToolStripMenuItem danhSáchPhiếuNhậnPhiếuSửDụngToolStripMenuItem;
        private ToolStripMenuItem vTTHTrongChỉĐịnhToolStripMenuItem;
        private ToolStripMenuItem vTTHDùngChungToolStripMenuItem;
        private ToolStripMenuItem báoCáoSửDụngTạiKhoaToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem42;
        private ToolStripMenuItem nhậpTừPhiếuXuấtCủaPhòngVTDượcToolStripMenuItem;
        private ToolStripMenuItem nhậpTạmKhiChưaCóPhiếuXuấtToolStripMenuItem;
        private ToolStripMenuItem mnuChuyenDoiVTTH;
        private ToolStripMenuItem báoCáoSửDụngTạiKhoaToolStripMenuItem1;
        private ToolStripMenuItem theoiDõiVTTHToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem43;
        private ToolStripMenuItem danhSáchBệnhNhânToolStripMenuItem2;
        private ToolStripMenuItem thốngKêTổngHợpXuấtĂnToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem44;
        private ToolStripMenuItem thốngKêTổngHợpXuấtĂnBNĐangĐiềuTrịToolStripMenuItem;
        private ToolStripMenuItem danhSáchBệnhNhânPhẫuThuậtToolStripMenuItem;
        private ToolStripMenuItem danhSáchBệnhNhânThủThuậtToolStripMenuItem;
        private ToolStripMenuItem bảngKêSốCaLàmThủThuậtTheoThờiGianThanhToánToolStripMenuItem;
        private ToolStripMenuItem bảngThanhToánTiềnThủThuậtTheoThờiGianThanhToánToolStripMenuItem;
        private ToolStripMenuItem bảngKêSốCaLàmPhẫuThuậtTheoThờiGianThanhToánToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem45;
        private ToolStripMenuItem thốngKêChiPhíCLSTheoKhoaThựcHiệnToolStripMenuItem;
        private ToolStripMenuItem tổngHợpChiPhíCLSTheoKhoaThựcHiệnToolStripMenuItem;
        private ToolStripMenuItem chiTiêtBênhNhânTheoGiươngBênhToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator19;
        private ToolStripSeparator toolStripSeparator18;
        private ToolStripMenuItem toolStripMenuItem46;
        private ToolStripMenuItem toolStripMenuItem47;
        private ToolStripMenuItem toolStripMenuItem25;
		public frmMain()
		{
			//
			// Required for Windows Form Designer support
			//
			//this._angle = 235;
			//SetStyle(System.Windows.Forms.ControlStyles.DoubleBuffer, true);
			//			SetStyle(System.Windows.Forms.ControlStyles.AllPaintingInWmPaint, true);
			//SetStyle(System.Windows.Forms.ControlStyles.ResizeRedraw, true);
			//SetStyle(System.Windows.Forms.ControlStyles.UserPaint, true);
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.dlgSave = new System.Windows.Forms.SaveFileDialog();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuHeThong = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuChangePass = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuLogOn = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLogOff = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuThoat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDL = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem32 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem25 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.bệnhNhânVàoViệnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem15 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.cậpNhậtThôngTinĐiềuTrịToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem18 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem19 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem42 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem16 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.bệnhNhânRaViệnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.danhSáchBệnhNhânToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripSeparator();
            this.phiếuLĩnhThuốcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem14 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem13 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem12 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem20 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem21 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator19 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem47 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem46 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.cậpNhậtVậtTưTiêuHaoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPhieuLinhVTTH = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInSoTHVTTH = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPhieuHoanVTTH = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNgayGiuongBenh = new System.Windows.Forms.ToolStripMenuItem();
            this.giaoBanBệnhViệnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýĐồVảiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator18 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem29 = new System.Windows.Forms.ToolStripMenuItem();
            this.cậpNhậtBệnhNhânPhẩuThuậtToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator20 = new System.Windows.Forms.ToolStripSeparator();
            this.phiếuLĩnhThuốcToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.inSổTổngHợpThuốcHàngNgàyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem37 = new System.Windows.Forms.ToolStripSeparator();
            this.cậpNhậtVậtTưỞPhòngMỗToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPhieuLinh_VTTH = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTK = new System.Windows.Forms.ToolStripMenuItem();
            this.tìmKiếmBệnhNhânToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.thốngKêHiệnTrạngBuồngGiườngĐiềutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.tùyChọnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thiếtLậpDịchVụYTếTheoKhoaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thiếtLậpPhiếuInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thiếtLậpChỉSốSỗLĩnhThuốcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thiếtLậpDanhSáchThuốcTrảVõToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thiếtLậpDanhSáchThủThậtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem17 = new System.Windows.Forms.ToolStripSeparator();
            this.thiếtLậpThứTựChọnDịchVụToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sổTayĐơnThuốcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sổTayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThietLapNhomVTTH = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuIn = new System.Windows.Forms.ToolStripMenuItem();
            this.chiPhíĐiềuTrịNộiTrúToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tổngHợpChiPhíĐiềuTrịToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tổngHợpSửDụngThuốcVậtTưThoànKhoaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tổngHơpSưToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem34 = new System.Windows.Forms.ToolStripSeparator();
            this.thôngKêThuốcVậtTưTheoBệnhNhânToànKhoaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngKêThuốcVậtTưTheoBệnhNhânBệnhNhânĐangĐiềuTrịToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem30 = new System.Windows.Forms.ToolStripSeparator();
            this.tổngHợpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.báoCáoSửDụngChiTiếtVậtTưTạiKhoaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBCSuDungTaiKhoa = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem41 = new System.Windows.Forms.ToolStripSeparator();
            this.báoCáoThanhToánThuốcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.danhSáchBệnhNhânVàoViệnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.danhSáchBệnhNhânTạiCácKhoaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem22 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem23 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.cácBáoCáoCủaKhoaPhâuThuậtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem36 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem38 = new System.Windows.Forms.ToolStripMenuItem();
            this.DSVOCAM = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.thôngKêTheoĐốiTượngBệnhNhânToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngKêChiTiếtTheoĐốiTượngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thốngKêChỉĐịnhCậnLâmSàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tổngHợpLượngChỉĐịnhTheoBácSỹToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngKêChiTiếtCLSTheoKhoaThựcHiệnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.tổngHợpSốLượtChỉĐịnhCLSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tổngHợpSốLượtChỉĐịnhCLSTheoKhoaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem35 = new System.Windows.Forms.ToolStripSeparator();
            this.thốngKêChiTiếtChụpCRThToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tổngHợpToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.danToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thốngKêChiPhíCLSTheoKhoaThựcHiệnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tổngHợpChiPhíCLSTheoKhoaThựcHiệnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tổngHợpChỉĐinhMáuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thốngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.tổngHợpSốLượtTruyềnMáuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tổngHợpSốLượtTruyềnMáuTheoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
            this.tổngHợpSốLượngMáuTruyềnTheoLọaMáuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tổngHợpChếĐộChămSócBệnhNhânToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngKêChếChiTiếtĐọChămSócToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tổngHợpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tổngHợpBệnhNhânChuyểnViệnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngKêDanhSáchBệnhNhânChuyểnViệnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngKêDanhSáchBệnhNhânTheoBVChuyểnĐếnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thốngKêDanhSáchBệnhNhânTheoBSChỉĐịnhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator16 = new System.Windows.Forms.ToolStripSeparator();
            this.tổngHợpSốLượngChuyểnViệnTheoBVChuyểnĐếnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tổngHợpSốLượngChuyểnViệnTheoBSChỉĐịnhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tổngHợpBệnhNhânTheoNơiKhámChữaBệnhBanĐầuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngKêDanhSáchBệnhNhânTheoNơiKCBBanĐầuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngKêDanhSáchBNToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ngàyĐiềuTrịTrungBinhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tổngHợpBệnhNhânTheoBuồngGiươngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngKêDanhSáchBệnhNhânTheoBuồngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tổngHợpSốLượtBệnhNhânTheoBuồngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chiTiêtBênhNhânTheoGiươngBênhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tổngHợpICD10ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.danhSáchBệnhNhânToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tổngHợpTheoMãBệnhICD10ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem43 = new System.Windows.Forms.ToolStripMenuItem();
            this.danhSáchBệnhNhânToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.thốngKêTổngHợpXuấtĂnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem44 = new System.Windows.Forms.ToolStripMenuItem();
            this.thốngKêTổngHợpXuấtĂnBNĐangĐiềuTrịToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem24 = new System.Windows.Forms.ToolStripMenuItem();
            this.danhSáchBệnhNhânTưVongToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.tổngHợpBệnhNhânTheoKếtQuảĐiềuTrịToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem26 = new System.Windows.Forms.ToolStripSeparator();
            this.tổngHợpBệnhNhânLàmThủThuậtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngKêDanhSáchBệnhNhânToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tổngHợpSốLượngBệnhNhânLàmThủThuậtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem27 = new System.Windows.Forms.ToolStripSeparator();
            this.thốngKêDanhSáchBệnhNhânTheoBSChỉĐịnhToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tổngHợpSốLượtBệnhNhânTheoBSChỉĐịnhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem40 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem39 = new System.Windows.Forms.ToolStripMenuItem();
            this.danhSáchBệnhNhânThủThuậtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bảngKêSốCaLàmThủThuậtTheoThờiGianThanhToánToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bảngThanhToánTiềnThủThuậtTheoThờiGianThanhToánToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tổngHợpBệnhNhânLàmPhẩuThToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thốngKêDanhSáchBệnhNhânLàmPhẩuThuậtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tổngHợpSốLượtBệnhNhânLàmPhẩuThuậtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator17 = new System.Windows.Forms.ToolStripSeparator();
            this.thổngKêDanhSáchBệnhNhânLàmPTTheoBSChỉĐịnhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tổngHợpSốLượngBệnhNhânToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem28 = new System.Windows.Forms.ToolStripSeparator();
            this.thốngKêDanhSáchBệnhNhânTheoKhoaThựcHiệnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tổngHợpSốLượngBNTheoKhoaThựcHiệnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.danhSáchBệnhNhânPhẫuThuậtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bảngKêSốCaLàmPhẫuThuậtTheoThờiGianThanhToánToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem45 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem31 = new System.Windows.Forms.ToolStripSeparator();
            this.tổngHợpLoạiBệnhÁnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thốngKêDanhSáchBNTheoLoạiBệnhÁnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem33 = new System.Windows.Forms.ToolStripSeparator();
            this.sổTổngHợpDuyệtPhiếuChỉĐịnhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.danhMụcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.danhMụcBuồngGiườngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.danhMụcPhẩuThuậtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.danhMụcBácSỹToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.danhMụcNhómToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.danhMụcĐồVảiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýVTTHToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nhậpTồnĐầuKỳToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nhậnVTTHTừPhòngVậtTưToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nhậpTừPhiếuXuấtCủaPhòngVTDượcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nhậpTạmKhiChưaCóPhiếuXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuChuyenDoiVTTH = new System.Windows.Forms.ToolStripMenuItem();
            this.xácNhậnSửDụngTạiKhoaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vTTHTrongChỉĐịnhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vTTHDùngChungToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.danhSáchPhiếuNhậnPhiếuSửDụngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.báoCáoSửDụngTạiKhoaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.báoCáoSửDụngTạiKhoaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.theoiDõiVTTHToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trợGiúpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hướngDẫnDựTrùVậtTưTiêuHaoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuChotSoSach = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThietLapNhomInVTTH = new System.Windows.Forms.ToolStripMenuItem();
            this.hướngDẫnXemBáoCáoTổngHợpVTTHToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.báoCáoỨngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.txtNgayLV = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtNguoiDung = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtPhienBan = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolTimBN = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton8 = new System.Windows.Forms.ToolStripButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dlgSave
            // 
            this.dlgSave.Filter = "File dữ liệu Access|*.MDB";
            this.dlgSave.Title = "Lưu file";
            this.dlgSave.FileOk += new System.ComponentModel.CancelEventHandler(this.dlgSave_FileOk);
            // 
            // helpProvider1
            // 
            this.helpProvider1.HelpNamespace = "D:\\Programs\\KhamChuaBenh\\SoftWare\\NamDinh_QLBN_Up\\HDSD.chm";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHeThong,
            this.mnuDL,
            this.toolStripMenuItem29,
            this.mnuTK,
            this.mnuIn,
            this.danhMụcToolStripMenuItem,
            this.quảnLýVTTHToolStripMenuItem,
            this.trợGiúpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(913, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuHeThong
            // 
            this.mnuHeThong.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuChangePass,
            this.toolStripMenuItem1,
            this.mnuLogOn,
            this.mnuLogOff,
            this.toolStripMenuItem2,
            this.mnuThoat});
            this.mnuHeThong.Name = "mnuHeThong";
            this.mnuHeThong.Size = new System.Drawing.Size(69, 20);
            this.mnuHeThong.Text = "Hệ thống";
            // 
            // mnuChangePass
            // 
            this.mnuChangePass.Image = ((System.Drawing.Image)(resources.GetObject("mnuChangePass.Image")));
            this.mnuChangePass.Name = "mnuChangePass";
            this.mnuChangePass.Size = new System.Drawing.Size(232, 22);
            this.mnuChangePass.Text = "Thay đổi mật khẩu truy cập";
            this.mnuChangePass.Click += new System.EventHandler(this.mnuChangePass_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(229, 6);
            // 
            // mnuLogOn
            // 
            this.mnuLogOn.Name = "mnuLogOn";
            this.mnuLogOn.Size = new System.Drawing.Size(232, 22);
            this.mnuLogOn.Text = "Kết nối đến cơ sở dữ liệu";
            this.mnuLogOn.Click += new System.EventHandler(this.mnuLogOn_Click);
            // 
            // mnuLogOff
            // 
            this.mnuLogOff.Name = "mnuLogOff";
            this.mnuLogOff.Size = new System.Drawing.Size(232, 22);
            this.mnuLogOff.Text = "Ngắt kết nối đến cơ sở dữ liệu";
            this.mnuLogOff.Click += new System.EventHandler(this.mnuLogOff_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(229, 6);
            // 
            // mnuThoat
            // 
            this.mnuThoat.Image = ((System.Drawing.Image)(resources.GetObject("mnuThoat.Image")));
            this.mnuThoat.Name = "mnuThoat";
            this.mnuThoat.Size = new System.Drawing.Size(232, 22);
            this.mnuThoat.Text = "Thoát khỏi chương trình";
            this.mnuThoat.Click += new System.EventHandler(this.mnuThoat_Click);
            // 
            // mnuDL
            // 
            this.mnuDL.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem32,
            this.toolStripMenuItem25,
            this.toolStripSeparator4,
            this.bệnhNhânVàoViệnToolStripMenuItem,
            this.toolStripMenuItem4,
            this.toolStripMenuItem15,
            this.toolStripSeparator11,
            this.cậpNhậtThôngTinĐiềuTrịToolStripMenuItem,
            this.toolStripMenuItem18,
            this.toolStripMenuItem19,
            this.toolStripMenuItem42,
            this.toolStripSeparator12,
            this.toolStripMenuItem16,
            this.toolStripMenuItem5,
            this.toolStripMenuItem10,
            this.toolStripMenuItem9,
            this.toolStripMenuItem3,
            this.bệnhNhânRaViệnToolStripMenuItem,
            this.danhSáchBệnhNhânToolStripMenuItem,
            this.toolStripMenuItem8,
            this.phiếuLĩnhThuốcToolStripMenuItem,
            this.toolStripMenuItem11,
            this.toolStripMenuItem14,
            this.toolStripMenuItem13,
            this.toolStripMenuItem12,
            this.toolStripMenuItem20,
            this.toolStripMenuItem21,
            this.toolStripSeparator19,
            this.toolStripMenuItem46,
            this.toolStripMenuItem47,
            this.toolStripSeparator5,
            this.cậpNhậtVậtTưTiêuHaoToolStripMenuItem,
            this.mnuPhieuLinhVTTH,
            this.mnuInSoTHVTTH,
            this.mnuPhieuHoanVTTH,
            this.mnuNgayGiuongBenh,
            this.giaoBanBệnhViệnToolStripMenuItem,
            this.quảnLýĐồVảiToolStripMenuItem,
            this.toolStripSeparator18});
            this.mnuDL.Name = "mnuDL";
            this.mnuDL.Size = new System.Drawing.Size(56, 20);
            this.mnuDL.Text = "Dữ liệu";
            // 
            // toolStripMenuItem32
            // 
            this.toolStripMenuItem32.Name = "toolStripMenuItem32";
            this.toolStripMenuItem32.Size = new System.Drawing.Size(350, 22);
            this.toolStripMenuItem32.Text = "Duyệt phiếu chỉ định";
            this.toolStripMenuItem32.Click += new System.EventHandler(this.toolStripMenuItem32_Click);
            // 
            // toolStripMenuItem25
            // 
            this.toolStripMenuItem25.Name = "toolStripMenuItem25";
            this.toolStripMenuItem25.Size = new System.Drawing.Size(350, 22);
            this.toolStripMenuItem25.Text = "Nhập số lưu trữ";
            this.toolStripMenuItem25.Click += new System.EventHandler(this.toolStripMenuItem25_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(347, 6);
            // 
            // bệnhNhânVàoViệnToolStripMenuItem
            // 
            this.bệnhNhânVàoViệnToolStripMenuItem.Name = "bệnhNhânVàoViệnToolStripMenuItem";
            this.bệnhNhânVàoViệnToolStripMenuItem.Size = new System.Drawing.Size(350, 22);
            this.bệnhNhânVàoViệnToolStripMenuItem.Text = "Tiếp nhận bệnh nhân vào Khoa";
            this.bệnhNhânVàoViệnToolStripMenuItem.Click += new System.EventHandler(this.bệnhNhânVàoViệnToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(347, 6);
            // 
            // toolStripMenuItem15
            // 
            this.toolStripMenuItem15.Name = "toolStripMenuItem15";
            this.toolStripMenuItem15.Size = new System.Drawing.Size(350, 22);
            this.toolStripMenuItem15.Text = "Lịch sử khám bệnh của bệnh nhân";
            this.toolStripMenuItem15.Click += new System.EventHandler(this.toolStripMenuItem15_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(347, 6);
            // 
            // cậpNhậtThôngTinĐiềuTrịToolStripMenuItem
            // 
            this.cậpNhậtThôngTinĐiềuTrịToolStripMenuItem.Name = "cậpNhậtThôngTinĐiềuTrịToolStripMenuItem";
            this.cậpNhậtThôngTinĐiềuTrịToolStripMenuItem.Size = new System.Drawing.Size(350, 22);
            this.cậpNhậtThôngTinĐiềuTrịToolStripMenuItem.Text = "Cập nhật thông tin điều trị";
            this.cậpNhậtThôngTinĐiềuTrịToolStripMenuItem.Click += new System.EventHandler(this.cậpNhậtThôngTinĐiềuTrịToolStripMenuItem_Click);
            // 
            // toolStripMenuItem18
            // 
            this.toolStripMenuItem18.Name = "toolStripMenuItem18";
            this.toolStripMenuItem18.Size = new System.Drawing.Size(350, 22);
            this.toolStripMenuItem18.Text = "Cập nhật thông tin điều trị tại khoa đông y";
            this.toolStripMenuItem18.Click += new System.EventHandler(this.toolStripMenuItem18_Click);
            // 
            // toolStripMenuItem19
            // 
            this.toolStripMenuItem19.Name = "toolStripMenuItem19";
            this.toolStripMenuItem19.Size = new System.Drawing.Size(350, 22);
            this.toolStripMenuItem19.Text = "Cập nhật thông tin điều trị tại khoa CC";
            this.toolStripMenuItem19.Click += new System.EventHandler(this.toolStripMenuItem19_Click);
            // 
            // toolStripMenuItem42
            // 
            this.toolStripMenuItem42.Name = "toolStripMenuItem42";
            this.toolStripMenuItem42.Size = new System.Drawing.Size(350, 22);
            this.toolStripMenuItem42.Text = "Cập nhật thông tin điều trị bệnh nhân (SARS-CoV-2)";
            this.toolStripMenuItem42.Click += new System.EventHandler(this.toolStripMenuItem42_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(347, 6);
            // 
            // toolStripMenuItem16
            // 
            this.toolStripMenuItem16.Name = "toolStripMenuItem16";
            this.toolStripMenuItem16.Size = new System.Drawing.Size(350, 22);
            this.toolStripMenuItem16.Text = "Cập nhật thông tin thủ thuật";
            this.toolStripMenuItem16.Click += new System.EventHandler(this.toolStripMenuItem16_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(347, 6);
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(350, 22);
            this.toolStripMenuItem10.Text = "Bệnh nhân chuyển khoa";
            this.toolStripMenuItem10.Click += new System.EventHandler(this.toolStripMenuItem10_Click);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(350, 22);
            this.toolStripMenuItem9.Text = "Chuyển đối tượng bệnh nhân";
            this.toolStripMenuItem9.Click += new System.EventHandler(this.toolStripMenuItem9_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(347, 6);
            // 
            // bệnhNhânRaViệnToolStripMenuItem
            // 
            this.bệnhNhânRaViệnToolStripMenuItem.Name = "bệnhNhânRaViệnToolStripMenuItem";
            this.bệnhNhânRaViệnToolStripMenuItem.Size = new System.Drawing.Size(350, 22);
            this.bệnhNhânRaViệnToolStripMenuItem.Text = "Tổng kết ra viện";
            this.bệnhNhânRaViệnToolStripMenuItem.Click += new System.EventHandler(this.bệnhNhânRaViệnToolStripMenuItem_Click);
            // 
            // danhSáchBệnhNhânToolStripMenuItem
            // 
            this.danhSáchBệnhNhânToolStripMenuItem.Name = "danhSáchBệnhNhânToolStripMenuItem";
            this.danhSáchBệnhNhânToolStripMenuItem.Size = new System.Drawing.Size(350, 22);
            this.danhSáchBệnhNhânToolStripMenuItem.Text = "Danh sách bệnh nhân";
            this.danhSáchBệnhNhânToolStripMenuItem.Visible = false;
            this.danhSáchBệnhNhânToolStripMenuItem.Click += new System.EventHandler(this.danhSáchBệnhNhânToolStripMenuItem_Click);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(347, 6);
            // 
            // phiếuLĩnhThuốcToolStripMenuItem
            // 
            this.phiếuLĩnhThuốcToolStripMenuItem.Name = "phiếuLĩnhThuốcToolStripMenuItem";
            this.phiếuLĩnhThuốcToolStripMenuItem.Size = new System.Drawing.Size(350, 22);
            this.phiếuLĩnhThuốcToolStripMenuItem.Text = "Phiếu lỉnh thuốc của Khoa";
            this.phiếuLĩnhThuốcToolStripMenuItem.Click += new System.EventHandler(this.phiếuLĩnhThuốcToolStripMenuItem_Click);
            // 
            // toolStripMenuItem11
            // 
            this.toolStripMenuItem11.Name = "toolStripMenuItem11";
            this.toolStripMenuItem11.Size = new System.Drawing.Size(350, 22);
            this.toolStripMenuItem11.Text = "Phiếu hoàn trả thuốc của khoa";
            this.toolStripMenuItem11.Click += new System.EventHandler(this.toolStripMenuItem11_Click);
            // 
            // toolStripMenuItem14
            // 
            this.toolStripMenuItem14.Name = "toolStripMenuItem14";
            this.toolStripMenuItem14.Size = new System.Drawing.Size(350, 22);
            this.toolStripMenuItem14.Text = "In phiếu trả vỏ";
            this.toolStripMenuItem14.Click += new System.EventHandler(this.toolStripMenuItem14_Click);
            // 
            // toolStripMenuItem13
            // 
            this.toolStripMenuItem13.Name = "toolStripMenuItem13";
            this.toolStripMenuItem13.Size = new System.Drawing.Size(350, 22);
            this.toolStripMenuItem13.Text = "In sổ tổng hợp thuốc hàng ngày";
            this.toolStripMenuItem13.Click += new System.EventHandler(this.toolStripMenuItem13_Click);
            // 
            // toolStripMenuItem12
            // 
            this.toolStripMenuItem12.Name = "toolStripMenuItem12";
            this.toolStripMenuItem12.Size = new System.Drawing.Size(347, 6);
            this.toolStripMenuItem12.Click += new System.EventHandler(this.toolStripMenuItem12_Click);
            // 
            // toolStripMenuItem20
            // 
            this.toolStripMenuItem20.Name = "toolStripMenuItem20";
            this.toolStripMenuItem20.Size = new System.Drawing.Size(350, 22);
            this.toolStripMenuItem20.Text = "Phiếu lỉnh thuốc ở khoa CC";
            this.toolStripMenuItem20.Click += new System.EventHandler(this.toolStripMenuItem20_Click);
            // 
            // toolStripMenuItem21
            // 
            this.toolStripMenuItem21.Name = "toolStripMenuItem21";
            this.toolStripMenuItem21.Size = new System.Drawing.Size(350, 22);
            this.toolStripMenuItem21.Text = "In sổ tổng hợp thuốc ở khoa CC";
            this.toolStripMenuItem21.Click += new System.EventHandler(this.toolStripMenuItem21_Click);
            // 
            // toolStripSeparator19
            // 
            this.toolStripSeparator19.Name = "toolStripSeparator19";
            this.toolStripSeparator19.Size = new System.Drawing.Size(347, 6);
            // 
            // toolStripMenuItem47
            // 
            this.toolStripMenuItem47.Name = "toolStripMenuItem47";
            this.toolStripMenuItem47.Size = new System.Drawing.Size(350, 22);
            this.toolStripMenuItem47.Text = "In sổ tổng hợp thuốc khoa Đông Y";
            this.toolStripMenuItem47.Click += new System.EventHandler(this.toolStripMenuItem47_Click);
            // 
            // toolStripMenuItem46
            // 
            this.toolStripMenuItem46.Name = "toolStripMenuItem46";
            this.toolStripMenuItem46.Size = new System.Drawing.Size(350, 22);
            this.toolStripMenuItem46.Text = "Phiếu lĩnh thuốc khoa Đông Y";
            this.toolStripMenuItem46.Click += new System.EventHandler(this.toolStripMenuItem46_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(347, 6);
            // 
            // cậpNhậtVậtTưTiêuHaoToolStripMenuItem
            // 
            this.cậpNhậtVậtTưTiêuHaoToolStripMenuItem.Name = "cậpNhậtVậtTưTiêuHaoToolStripMenuItem";
            this.cậpNhậtVậtTưTiêuHaoToolStripMenuItem.Size = new System.Drawing.Size(350, 22);
            this.cậpNhậtVậtTưTiêuHaoToolStripMenuItem.Text = "Cập nhật vật tư tiêu hao";
            this.cậpNhậtVậtTưTiêuHaoToolStripMenuItem.Click += new System.EventHandler(this.cậpNhậtVậtTưTiêuHaoToolStripMenuItem_Click);
            // 
            // mnuPhieuLinhVTTH
            // 
            this.mnuPhieuLinhVTTH.Name = "mnuPhieuLinhVTTH";
            this.mnuPhieuLinhVTTH.Size = new System.Drawing.Size(350, 22);
            this.mnuPhieuLinhVTTH.Text = "Phiếu lĩnh VTTH của khoa";
            this.mnuPhieuLinhVTTH.Click += new System.EventHandler(this.mnuPhieuLinhVTTH_Click);
            // 
            // mnuInSoTHVTTH
            // 
            this.mnuInSoTHVTTH.Name = "mnuInSoTHVTTH";
            this.mnuInSoTHVTTH.Size = new System.Drawing.Size(350, 22);
            this.mnuInSoTHVTTH.Text = "In sổ tổng hợp VTTH hàng ngày";
            this.mnuInSoTHVTTH.Click += new System.EventHandler(this.mnuInSoTHVTTH_Click);
            // 
            // mnuPhieuHoanVTTH
            // 
            this.mnuPhieuHoanVTTH.Name = "mnuPhieuHoanVTTH";
            this.mnuPhieuHoanVTTH.Size = new System.Drawing.Size(350, 22);
            this.mnuPhieuHoanVTTH.Text = "Phiếu hoàn trả VTTH";
            this.mnuPhieuHoanVTTH.Click += new System.EventHandler(this.mnuPhieuHoanVTTH_Click);
            // 
            // mnuNgayGiuongBenh
            // 
            this.mnuNgayGiuongBenh.Name = "mnuNgayGiuongBenh";
            this.mnuNgayGiuongBenh.Size = new System.Drawing.Size(350, 22);
            this.mnuNgayGiuongBenh.Text = "Quản lý Ngày Giường Bệnh";
            this.mnuNgayGiuongBenh.Click += new System.EventHandler(this.mnuNgayGiuongBenh_Click);
            // 
            // giaoBanBệnhViệnToolStripMenuItem
            // 
            this.giaoBanBệnhViệnToolStripMenuItem.Name = "giaoBanBệnhViệnToolStripMenuItem";
            this.giaoBanBệnhViệnToolStripMenuItem.Size = new System.Drawing.Size(350, 22);
            this.giaoBanBệnhViệnToolStripMenuItem.Text = "Giao ban bệnh Viện";
            this.giaoBanBệnhViệnToolStripMenuItem.Click += new System.EventHandler(this.giaoBanBệnhViệnToolStripMenuItem_Click);
            // 
            // quảnLýĐồVảiToolStripMenuItem
            // 
            this.quảnLýĐồVảiToolStripMenuItem.Name = "quảnLýĐồVảiToolStripMenuItem";
            this.quảnLýĐồVảiToolStripMenuItem.Size = new System.Drawing.Size(350, 22);
            this.quảnLýĐồVảiToolStripMenuItem.Text = "Quản lý đồ vải";
            this.quảnLýĐồVảiToolStripMenuItem.Click += new System.EventHandler(this.quảnLýĐồVảiToolStripMenuItem_Click);
            // 
            // toolStripSeparator18
            // 
            this.toolStripSeparator18.Name = "toolStripSeparator18";
            this.toolStripSeparator18.Size = new System.Drawing.Size(347, 6);
            // 
            // toolStripMenuItem29
            // 
            this.toolStripMenuItem29.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cậpNhậtBệnhNhânPhẩuThuậtToolStripMenuItem1,
            this.toolStripSeparator20,
            this.phiếuLĩnhThuốcToolStripMenuItem1,
            this.inSổTổngHợpThuốcHàngNgàyToolStripMenuItem,
            this.toolStripMenuItem37,
            this.cậpNhậtVậtTưỞPhòngMỗToolStripMenuItem,
            this.mnuPhieuLinh_VTTH});
            this.toolStripMenuItem29.Name = "toolStripMenuItem29";
            this.toolStripMenuItem29.Size = new System.Drawing.Size(75, 20);
            this.toolStripMenuItem29.Text = "Phòng mổ";
            // 
            // cậpNhậtBệnhNhânPhẩuThuậtToolStripMenuItem1
            // 
            this.cậpNhậtBệnhNhânPhẩuThuậtToolStripMenuItem1.Name = "cậpNhậtBệnhNhânPhẩuThuậtToolStripMenuItem1";
            this.cậpNhậtBệnhNhânPhẩuThuậtToolStripMenuItem1.Size = new System.Drawing.Size(243, 22);
            this.cậpNhậtBệnhNhânPhẩuThuậtToolStripMenuItem1.Text = "Cập nhật bệnh nhân phẫu thuật";
            this.cậpNhậtBệnhNhânPhẩuThuậtToolStripMenuItem1.Click += new System.EventHandler(this.cậpNhậtBệnhNhânPhẩuThuậtToolStripMenuItem1_Click);
            // 
            // toolStripSeparator20
            // 
            this.toolStripSeparator20.Name = "toolStripSeparator20";
            this.toolStripSeparator20.Size = new System.Drawing.Size(240, 6);
            // 
            // phiếuLĩnhThuốcToolStripMenuItem1
            // 
            this.phiếuLĩnhThuốcToolStripMenuItem1.Name = "phiếuLĩnhThuốcToolStripMenuItem1";
            this.phiếuLĩnhThuốcToolStripMenuItem1.Size = new System.Drawing.Size(243, 22);
            this.phiếuLĩnhThuốcToolStripMenuItem1.Text = "Phiếu lỉnh thuốc";
            this.phiếuLĩnhThuốcToolStripMenuItem1.Click += new System.EventHandler(this.phiếuLĩnhThuốcToolStripMenuItem1_Click);
            // 
            // inSổTổngHợpThuốcHàngNgàyToolStripMenuItem
            // 
            this.inSổTổngHợpThuốcHàngNgàyToolStripMenuItem.Name = "inSổTổngHợpThuốcHàngNgàyToolStripMenuItem";
            this.inSổTổngHợpThuốcHàngNgàyToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.inSổTổngHợpThuốcHàngNgàyToolStripMenuItem.Text = "In sổ tổng hợp thuốc";
            this.inSổTổngHợpThuốcHàngNgàyToolStripMenuItem.Click += new System.EventHandler(this.inSổTổngHợpThuốcHàngNgàyToolStripMenuItem_Click);
            // 
            // toolStripMenuItem37
            // 
            this.toolStripMenuItem37.Name = "toolStripMenuItem37";
            this.toolStripMenuItem37.Size = new System.Drawing.Size(240, 6);
            // 
            // cậpNhậtVậtTưỞPhòngMỗToolStripMenuItem
            // 
            this.cậpNhậtVậtTưỞPhòngMỗToolStripMenuItem.Name = "cậpNhậtVậtTưỞPhòngMỗToolStripMenuItem";
            this.cậpNhậtVậtTưỞPhòngMỗToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.cậpNhậtVậtTưỞPhòngMỗToolStripMenuItem.Text = "Cập nhật vật tư ở phòng mổ";
            this.cậpNhậtVậtTưỞPhòngMỗToolStripMenuItem.Click += new System.EventHandler(this.cậpNhậtVậtTưỞPhòngMỗToolStripMenuItem_Click);
            // 
            // mnuPhieuLinh_VTTH
            // 
            this.mnuPhieuLinh_VTTH.Name = "mnuPhieuLinh_VTTH";
            this.mnuPhieuLinh_VTTH.Size = new System.Drawing.Size(243, 22);
            this.mnuPhieuLinh_VTTH.Text = "Phiếu lĩnh VTTH";
            this.mnuPhieuLinh_VTTH.Click += new System.EventHandler(this.mnuPhieuLinh_VTTH_Click);
            // 
            // mnuTK
            // 
            this.mnuTK.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tìmKiếmBệnhNhânToolStripMenuItem,
            this.toolStripMenuItem6,
            this.thốngKêHiệnTrạngBuồngGiườngĐiềutToolStripMenuItem,
            this.toolStripMenuItem7,
            this.tùyChọnToolStripMenuItem,
            this.thiếtLậpDịchVụYTếTheoKhoaToolStripMenuItem,
            this.thiếtLậpPhiếuInToolStripMenuItem,
            this.thiếtLậpChỉSốSỗLĩnhThuốcToolStripMenuItem,
            this.thiếtLậpDanhSáchThuốcTrảVõToolStripMenuItem,
            this.thiếtLậpDanhSáchThủThậtToolStripMenuItem,
            this.toolStripMenuItem17,
            this.thiếtLậpThứTựChọnDịchVụToolStripMenuItem,
            this.sổTayĐơnThuốcToolStripMenuItem,
            this.sổTayToolStripMenuItem,
            this.mnuThietLapNhomVTTH});
            this.mnuTK.Name = "mnuTK";
            this.mnuTK.Size = new System.Drawing.Size(60, 20);
            this.mnuTK.Text = "Tiện ích";
            // 
            // tìmKiếmBệnhNhânToolStripMenuItem
            // 
            this.tìmKiếmBệnhNhânToolStripMenuItem.Name = "tìmKiếmBệnhNhânToolStripMenuItem";
            this.tìmKiếmBệnhNhânToolStripMenuItem.Size = new System.Drawing.Size(310, 6);
            this.tìmKiếmBệnhNhânToolStripMenuItem.Visible = false;
            this.tìmKiếmBệnhNhânToolStripMenuItem.Click += new System.EventHandler(this.tìmKiếmBệnhNhânToolStripMenuItem_Click_1);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(310, 6);
            // 
            // thốngKêHiệnTrạngBuồngGiườngĐiềutToolStripMenuItem
            // 
            this.thốngKêHiệnTrạngBuồngGiườngĐiềutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("thốngKêHiệnTrạngBuồngGiườngĐiềutToolStripMenuItem.Image")));
            this.thốngKêHiệnTrạngBuồngGiườngĐiềutToolStripMenuItem.Name = "thốngKêHiệnTrạngBuồngGiườngĐiềutToolStripMenuItem";
            this.thốngKêHiệnTrạngBuồngGiườngĐiềutToolStripMenuItem.Size = new System.Drawing.Size(313, 22);
            this.thốngKêHiệnTrạngBuồngGiườngĐiềutToolStripMenuItem.Text = "Thống kê hiện trạng buồng, giường";
            this.thốngKêHiệnTrạngBuồngGiườngĐiềutToolStripMenuItem.Click += new System.EventHandler(this.thốngKêHiệnTrạngBuồngGiườngĐiềutToolStripMenuItem_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(310, 6);
            // 
            // tùyChọnToolStripMenuItem
            // 
            this.tùyChọnToolStripMenuItem.Name = "tùyChọnToolStripMenuItem";
            this.tùyChọnToolStripMenuItem.Size = new System.Drawing.Size(313, 22);
            this.tùyChọnToolStripMenuItem.Text = "Tùy chọn";
            this.tùyChọnToolStripMenuItem.Click += new System.EventHandler(this.tùyChọnToolStripMenuItem_Click);
            // 
            // thiếtLậpDịchVụYTếTheoKhoaToolStripMenuItem
            // 
            this.thiếtLậpDịchVụYTếTheoKhoaToolStripMenuItem.Name = "thiếtLậpDịchVụYTếTheoKhoaToolStripMenuItem";
            this.thiếtLậpDịchVụYTếTheoKhoaToolStripMenuItem.Size = new System.Drawing.Size(313, 22);
            this.thiếtLậpDịchVụYTếTheoKhoaToolStripMenuItem.Text = "Thiết lập dịch vụ y tế theo Khoa";
            this.thiếtLậpDịchVụYTếTheoKhoaToolStripMenuItem.Visible = false;
            this.thiếtLậpDịchVụYTếTheoKhoaToolStripMenuItem.Click += new System.EventHandler(this.thiếtLậpDịchVụYTếTheoKhoaToolStripMenuItem_Click);
            // 
            // thiếtLậpPhiếuInToolStripMenuItem
            // 
            this.thiếtLậpPhiếuInToolStripMenuItem.Name = "thiếtLậpPhiếuInToolStripMenuItem";
            this.thiếtLậpPhiếuInToolStripMenuItem.Size = new System.Drawing.Size(313, 22);
            this.thiếtLậpPhiếuInToolStripMenuItem.Text = "Thiết lập thông số";
            this.thiếtLậpPhiếuInToolStripMenuItem.Click += new System.EventHandler(this.thiếtLậpPhiếuInToolStripMenuItem_Click);
            // 
            // thiếtLậpChỉSốSỗLĩnhThuốcToolStripMenuItem
            // 
            this.thiếtLậpChỉSốSỗLĩnhThuốcToolStripMenuItem.Name = "thiếtLậpChỉSốSỗLĩnhThuốcToolStripMenuItem";
            this.thiếtLậpChỉSốSỗLĩnhThuốcToolStripMenuItem.Size = new System.Drawing.Size(313, 22);
            this.thiếtLậpChỉSốSỗLĩnhThuốcToolStripMenuItem.Text = "Thiết lập chỉ số sổ tổng hợp thuốc hàng ngày";
            this.thiếtLậpChỉSốSỗLĩnhThuốcToolStripMenuItem.Click += new System.EventHandler(this.thiếtLậpChỉSốSỗLĩnhThuốcToolStripMenuItem_Click);
            // 
            // thiếtLậpDanhSáchThuốcTrảVõToolStripMenuItem
            // 
            this.thiếtLậpDanhSáchThuốcTrảVõToolStripMenuItem.Name = "thiếtLậpDanhSáchThuốcTrảVõToolStripMenuItem";
            this.thiếtLậpDanhSáchThuốcTrảVõToolStripMenuItem.Size = new System.Drawing.Size(313, 22);
            this.thiếtLậpDanhSáchThuốcTrảVõToolStripMenuItem.Text = "Thiết lập danh sách thuốc trả vỏ";
            this.thiếtLậpDanhSáchThuốcTrảVõToolStripMenuItem.Click += new System.EventHandler(this.thiếtLậpDanhSáchThuốcTrảVõToolStripMenuItem_Click);
            // 
            // thiếtLậpDanhSáchThủThậtToolStripMenuItem
            // 
            this.thiếtLậpDanhSáchThủThậtToolStripMenuItem.Name = "thiếtLậpDanhSáchThủThậtToolStripMenuItem";
            this.thiếtLậpDanhSáchThủThậtToolStripMenuItem.Size = new System.Drawing.Size(313, 22);
            this.thiếtLậpDanhSáchThủThậtToolStripMenuItem.Text = "Thiết lập danh sách thủ thật";
            this.thiếtLậpDanhSáchThủThậtToolStripMenuItem.Click += new System.EventHandler(this.thiếtLậpDanhSáchThủThậtToolStripMenuItem_Click);
            // 
            // toolStripMenuItem17
            // 
            this.toolStripMenuItem17.Name = "toolStripMenuItem17";
            this.toolStripMenuItem17.Size = new System.Drawing.Size(310, 6);
            // 
            // thiếtLậpThứTựChọnDịchVụToolStripMenuItem
            // 
            this.thiếtLậpThứTựChọnDịchVụToolStripMenuItem.Name = "thiếtLậpThứTựChọnDịchVụToolStripMenuItem";
            this.thiếtLậpThứTựChọnDịchVụToolStripMenuItem.Size = new System.Drawing.Size(313, 22);
            this.thiếtLậpThứTựChọnDịchVụToolStripMenuItem.Text = "Thiết lập thứ tự chọn dịch vụ";
            this.thiếtLậpThứTựChọnDịchVụToolStripMenuItem.Click += new System.EventHandler(this.thiếtLậpThứTựChọnDịchVụToolStripMenuItem_Click);
            // 
            // sổTayĐơnThuốcToolStripMenuItem
            // 
            this.sổTayĐơnThuốcToolStripMenuItem.Name = "sổTayĐơnThuốcToolStripMenuItem";
            this.sổTayĐơnThuốcToolStripMenuItem.Size = new System.Drawing.Size(313, 22);
            this.sổTayĐơnThuốcToolStripMenuItem.Text = "Sổ tay đơn thuốc";
            this.sổTayĐơnThuốcToolStripMenuItem.Click += new System.EventHandler(this.sổTayĐơnThuốcToolStripMenuItem_Click);
            // 
            // sổTayToolStripMenuItem
            // 
            this.sổTayToolStripMenuItem.Name = "sổTayToolStripMenuItem";
            this.sổTayToolStripMenuItem.Size = new System.Drawing.Size(313, 22);
            this.sổTayToolStripMenuItem.Text = "Sổ tay chỉ định dịch vụ";
            this.sổTayToolStripMenuItem.Click += new System.EventHandler(this.sổTayToolStripMenuItem_Click);
            // 
            // mnuThietLapNhomVTTH
            // 
            this.mnuThietLapNhomVTTH.Name = "mnuThietLapNhomVTTH";
            this.mnuThietLapNhomVTTH.Size = new System.Drawing.Size(313, 22);
            this.mnuThietLapNhomVTTH.Text = "Thiết lập nhóm in VTTH";
            this.mnuThietLapNhomVTTH.Click += new System.EventHandler(this.mnuThietLapNhomVTTH_Click);
            // 
            // mnuIn
            // 
            this.mnuIn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chiPhíĐiềuTrịNộiTrúToolStripMenuItem,
            this.tổngHợpChiPhíĐiềuTrịToolStripMenuItem,
            this.toolStripSeparator7,
            this.danhSáchBệnhNhânVàoViệnToolStripMenuItem,
            this.danhSáchBệnhNhânTạiCácKhoaToolStripMenuItem,
            this.toolStripMenuItem22,
            this.toolStripMenuItem23,
            this.toolStripSeparator8,
            this.cácBáoCáoCủaKhoaPhâuThuậtToolStripMenuItem,
            this.toolStripMenuItem36,
            this.toolStripMenuItem38,
            this.DSVOCAM,
            this.toolStripSeparator6,
            this.thôngKêTheoĐốiTượngBệnhNhânToolStripMenuItem,
            this.thốngKêChỉĐịnhCậnLâmSàngToolStripMenuItem,
            this.tổngHợpChỉĐinhMáuToolStripMenuItem,
            this.tổngHợpChếĐộChămSócBệnhNhânToolStripMenuItem,
            this.tổngHợpBệnhNhânChuyểnViệnToolStripMenuItem,
            this.tổngHợpBệnhNhânTheoNơiKhámChữaBệnhBanĐầuToolStripMenuItem,
            this.ngàyĐiềuTrịTrungBinhToolStripMenuItem,
            this.tổngHợpBệnhNhânTheoBuồngGiươngToolStripMenuItem,
            this.tổngHợpICD10ToolStripMenuItem,
            this.toolStripMenuItem43,
            this.toolStripMenuItem24,
            this.toolStripMenuItem26,
            this.tổngHợpBệnhNhânLàmThủThuậtToolStripMenuItem,
            this.tổngHợpBệnhNhânLàmPhẩuThToolStripMenuItem,
            this.toolStripMenuItem31,
            this.tổngHợpLoạiBệnhÁnToolStripMenuItem,
            this.toolStripMenuItem33,
            this.sổTổngHợpDuyệtPhiếuChỉĐịnhToolStripMenuItem});
            this.mnuIn.Name = "mnuIn";
            this.mnuIn.Size = new System.Drawing.Size(61, 20);
            this.mnuIn.Text = "Báo cáo";
            // 
            // chiPhíĐiềuTrịNộiTrúToolStripMenuItem
            // 
            this.chiPhíĐiềuTrịNộiTrúToolStripMenuItem.Name = "chiPhíĐiềuTrịNộiTrúToolStripMenuItem";
            this.chiPhíĐiềuTrịNộiTrúToolStripMenuItem.Size = new System.Drawing.Size(351, 22);
            this.chiPhíĐiềuTrịNộiTrúToolStripMenuItem.Text = "Phiếu tổng hợp chi phí điều trị";
            this.chiPhíĐiềuTrịNộiTrúToolStripMenuItem.Click += new System.EventHandler(this.chiPhíĐiềuTrịNộiTrúToolStripMenuItem_Click_1);
            // 
            // tổngHợpChiPhíĐiềuTrịToolStripMenuItem
            // 
            this.tổngHợpChiPhíĐiềuTrịToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tổngHợpSửDụngThuốcVậtTưThoànKhoaToolStripMenuItem,
            this.tổngHơpSưToolStripMenuItem,
            this.toolStripMenuItem34,
            this.thôngKêThuốcVậtTưTheoBệnhNhânToànKhoaToolStripMenuItem,
            this.thôngKêThuốcVậtTưTheoBệnhNhânBệnhNhânĐangĐiềuTrịToolStripMenuItem,
            this.toolStripMenuItem30,
            this.tổngHợpToolStripMenuItem1,
            this.báoCáoSửDụngChiTiếtVậtTưTạiKhoaToolStripMenuItem,
            this.mnuBCSuDungTaiKhoa,
            this.toolStripMenuItem41,
            this.báoCáoThanhToánThuốcToolStripMenuItem});
            this.tổngHợpChiPhíĐiềuTrịToolStripMenuItem.Name = "tổngHợpChiPhíĐiềuTrịToolStripMenuItem";
            this.tổngHợpChiPhíĐiềuTrịToolStripMenuItem.Size = new System.Drawing.Size(351, 22);
            this.tổngHợpChiPhíĐiềuTrịToolStripMenuItem.Text = "Tổng hợp sử dụng thuốc - vật tư tại khoa";
            this.tổngHợpChiPhíĐiềuTrịToolStripMenuItem.Click += new System.EventHandler(this.tổngHợpChiPhíĐiềuTrịToolStripMenuItem_Click);
            // 
            // tổngHợpSửDụngThuốcVậtTưThoànKhoaToolStripMenuItem
            // 
            this.tổngHợpSửDụngThuốcVậtTưThoànKhoaToolStripMenuItem.Name = "tổngHợpSửDụngThuốcVậtTưThoànKhoaToolStripMenuItem";
            this.tổngHợpSửDụngThuốcVậtTưThoànKhoaToolStripMenuItem.Size = new System.Drawing.Size(382, 22);
            this.tổngHợpSửDụngThuốcVậtTưThoànKhoaToolStripMenuItem.Text = "Tổng hợp thuốc toàn khoa";
            this.tổngHợpSửDụngThuốcVậtTưThoànKhoaToolStripMenuItem.Click += new System.EventHandler(this.tổngHợpSửDụngThuốcVậtTưThoànKhoaToolStripMenuItem_Click);
            // 
            // tổngHơpSưToolStripMenuItem
            // 
            this.tổngHơpSưToolStripMenuItem.Name = "tổngHơpSưToolStripMenuItem";
            this.tổngHơpSưToolStripMenuItem.Size = new System.Drawing.Size(382, 22);
            this.tổngHơpSưToolStripMenuItem.Text = "Tổng hơp thuốc toàn khoa ( Bệnh nhân đang điều trị)";
            this.tổngHơpSưToolStripMenuItem.Click += new System.EventHandler(this.tổngHơpSưToolStripMenuItem_Click);
            // 
            // toolStripMenuItem34
            // 
            this.toolStripMenuItem34.Name = "toolStripMenuItem34";
            this.toolStripMenuItem34.Size = new System.Drawing.Size(379, 6);
            // 
            // thôngKêThuốcVậtTưTheoBệnhNhânToànKhoaToolStripMenuItem
            // 
            this.thôngKêThuốcVậtTưTheoBệnhNhânToànKhoaToolStripMenuItem.Name = "thôngKêThuốcVậtTưTheoBệnhNhânToànKhoaToolStripMenuItem";
            this.thôngKêThuốcVậtTưTheoBệnhNhânToànKhoaToolStripMenuItem.Size = new System.Drawing.Size(382, 22);
            this.thôngKêThuốcVậtTưTheoBệnhNhânToànKhoaToolStripMenuItem.Text = "Thông kê thuốc theo bệnh nhân toàn khoa";
            this.thôngKêThuốcVậtTưTheoBệnhNhânToànKhoaToolStripMenuItem.Click += new System.EventHandler(this.thôngKêThuốcVậtTưTheoBệnhNhânToànKhoaToolStripMenuItem_Click);
            // 
            // thôngKêThuốcVậtTưTheoBệnhNhânBệnhNhânĐangĐiềuTrịToolStripMenuItem
            // 
            this.thôngKêThuốcVậtTưTheoBệnhNhânBệnhNhânĐangĐiềuTrịToolStripMenuItem.Name = "thôngKêThuốcVậtTưTheoBệnhNhânBệnhNhânĐangĐiềuTrịToolStripMenuItem";
            this.thôngKêThuốcVậtTưTheoBệnhNhânBệnhNhânĐangĐiềuTrịToolStripMenuItem.Size = new System.Drawing.Size(382, 22);
            this.thôngKêThuốcVậtTưTheoBệnhNhânBệnhNhânĐangĐiềuTrịToolStripMenuItem.Text = "Thông kê thuốc theo bệnh nhân (Bệnh nhân đang điều trị)";
            this.thôngKêThuốcVậtTưTheoBệnhNhânBệnhNhânĐangĐiềuTrịToolStripMenuItem.Click += new System.EventHandler(this.thôngKêThuốcVậtTưTheoBệnhNhânBệnhNhânĐangĐiềuTrịToolStripMenuItem_Click);
            // 
            // toolStripMenuItem30
            // 
            this.toolStripMenuItem30.Name = "toolStripMenuItem30";
            this.toolStripMenuItem30.Size = new System.Drawing.Size(379, 6);
            // 
            // tổngHợpToolStripMenuItem1
            // 
            this.tổngHợpToolStripMenuItem1.Name = "tổngHợpToolStripMenuItem1";
            this.tổngHợpToolStripMenuItem1.Size = new System.Drawing.Size(382, 22);
            this.tổngHợpToolStripMenuItem1.Text = "Theo dõi xuât, nhập tồn vật tư tại khoa";
            this.tổngHợpToolStripMenuItem1.Click += new System.EventHandler(this.tổngHợpToolStripMenuItem1_Click);
            // 
            // báoCáoSửDụngChiTiếtVậtTưTạiKhoaToolStripMenuItem
            // 
            this.báoCáoSửDụngChiTiếtVậtTưTạiKhoaToolStripMenuItem.Name = "báoCáoSửDụngChiTiếtVậtTưTạiKhoaToolStripMenuItem";
            this.báoCáoSửDụngChiTiếtVậtTưTạiKhoaToolStripMenuItem.Size = new System.Drawing.Size(382, 22);
            this.báoCáoSửDụngChiTiếtVậtTưTạiKhoaToolStripMenuItem.Text = "Báo cáo sử dụng chi tiết vật tư tại khoa";
            this.báoCáoSửDụngChiTiếtVậtTưTạiKhoaToolStripMenuItem.Click += new System.EventHandler(this.báoCáoSửDụngChiTiếtVậtTưTạiKhoaToolStripMenuItem_Click);
            // 
            // mnuBCSuDungTaiKhoa
            // 
            this.mnuBCSuDungTaiKhoa.Name = "mnuBCSuDungTaiKhoa";
            this.mnuBCSuDungTaiKhoa.Size = new System.Drawing.Size(382, 22);
            this.mnuBCSuDungTaiKhoa.Text = "Báo cáo sử dụng vật tư tại khoa";
            this.mnuBCSuDungTaiKhoa.Click += new System.EventHandler(this.mnuBCSuDungTaiKhoa_Click);
            // 
            // toolStripMenuItem41
            // 
            this.toolStripMenuItem41.Name = "toolStripMenuItem41";
            this.toolStripMenuItem41.Size = new System.Drawing.Size(379, 6);
            // 
            // báoCáoThanhToánThuốcToolStripMenuItem
            // 
            this.báoCáoThanhToánThuốcToolStripMenuItem.Name = "báoCáoThanhToánThuốcToolStripMenuItem";
            this.báoCáoThanhToánThuốcToolStripMenuItem.Size = new System.Drawing.Size(382, 22);
            this.báoCáoThanhToánThuốcToolStripMenuItem.Text = "Báo cáo thanh toán thuốc";
            this.báoCáoThanhToánThuốcToolStripMenuItem.Click += new System.EventHandler(this.báoCáoThanhToánThuốcToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(348, 6);
            // 
            // danhSáchBệnhNhânVàoViệnToolStripMenuItem
            // 
            this.danhSáchBệnhNhânVàoViệnToolStripMenuItem.Name = "danhSáchBệnhNhânVàoViệnToolStripMenuItem";
            this.danhSáchBệnhNhânVàoViệnToolStripMenuItem.Size = new System.Drawing.Size(351, 22);
            this.danhSáchBệnhNhânVàoViệnToolStripMenuItem.Text = "Danh sách bệnh nhân vào viện";
            this.danhSáchBệnhNhânVàoViệnToolStripMenuItem.Click += new System.EventHandler(this.danhSáchBệnhNhânVàoViệnToolStripMenuItem_Click);
            // 
            // danhSáchBệnhNhânTạiCácKhoaToolStripMenuItem
            // 
            this.danhSáchBệnhNhânTạiCácKhoaToolStripMenuItem.Name = "danhSáchBệnhNhânTạiCácKhoaToolStripMenuItem";
            this.danhSáchBệnhNhânTạiCácKhoaToolStripMenuItem.Size = new System.Drawing.Size(351, 22);
            this.danhSáchBệnhNhânTạiCácKhoaToolStripMenuItem.Text = "Danh sách bệnh nhân ra viện";
            this.danhSáchBệnhNhânTạiCácKhoaToolStripMenuItem.Click += new System.EventHandler(this.danhSáchBệnhNhânTạiCácKhoaToolStripMenuItem_Click_1);
            // 
            // toolStripMenuItem22
            // 
            this.toolStripMenuItem22.Name = "toolStripMenuItem22";
            this.toolStripMenuItem22.Size = new System.Drawing.Size(351, 22);
            this.toolStripMenuItem22.Text = "Danh sách bệnh nhân từ khoa khác chuyển đến";
            this.toolStripMenuItem22.Click += new System.EventHandler(this.toolStripMenuItem22_Click);
            // 
            // toolStripMenuItem23
            // 
            this.toolStripMenuItem23.Name = "toolStripMenuItem23";
            this.toolStripMenuItem23.Size = new System.Drawing.Size(351, 22);
            this.toolStripMenuItem23.Text = "Danh sách bệnh nhân chuyển đi khoa khác";
            this.toolStripMenuItem23.Click += new System.EventHandler(this.toolStripMenuItem23_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(348, 6);
            // 
            // cácBáoCáoCủaKhoaPhâuThuậtToolStripMenuItem
            // 
            this.cácBáoCáoCủaKhoaPhâuThuậtToolStripMenuItem.Name = "cácBáoCáoCủaKhoaPhâuThuậtToolStripMenuItem";
            this.cácBáoCáoCủaKhoaPhâuThuậtToolStripMenuItem.Size = new System.Drawing.Size(351, 22);
            this.cácBáoCáoCủaKhoaPhâuThuậtToolStripMenuItem.Text = "Các báo cáo của khoa phẫu thuật";
            this.cácBáoCáoCủaKhoaPhâuThuậtToolStripMenuItem.Click += new System.EventHandler(this.cácBáoCáoCủaKhoaPhâuThuậtToolStripMenuItem_Click);
            // 
            // toolStripMenuItem36
            // 
            this.toolStripMenuItem36.Name = "toolStripMenuItem36";
            this.toolStripMenuItem36.Size = new System.Drawing.Size(351, 22);
            this.toolStripMenuItem36.Text = "Tổng hợp sử dụng vật tư ở phòng mổ";
            this.toolStripMenuItem36.Click += new System.EventHandler(this.toolStripMenuItem36_Click_1);
            // 
            // toolStripMenuItem38
            // 
            this.toolStripMenuItem38.Name = "toolStripMenuItem38";
            this.toolStripMenuItem38.Size = new System.Drawing.Size(351, 22);
            this.toolStripMenuItem38.Text = "Tổng hợp sử dụng thuốc ở phòng mổ";
            this.toolStripMenuItem38.Click += new System.EventHandler(this.toolStripMenuItem38_Click);
            // 
            // DSVOCAM
            // 
            this.DSVOCAM.Name = "DSVOCAM";
            this.DSVOCAM.Size = new System.Drawing.Size(351, 22);
            this.DSVOCAM.Text = "Danh sách bệnh nhân vô cảm";
            this.DSVOCAM.Click += new System.EventHandler(this.DSVOCAM_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(348, 6);
            // 
            // thôngKêTheoĐốiTượngBệnhNhânToolStripMenuItem
            // 
            this.thôngKêTheoĐốiTượngBệnhNhânToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thôngKêChiTiếtTheoĐốiTượngToolStripMenuItem});
            this.thôngKêTheoĐốiTượngBệnhNhânToolStripMenuItem.Name = "thôngKêTheoĐốiTượngBệnhNhânToolStripMenuItem";
            this.thôngKêTheoĐốiTượngBệnhNhânToolStripMenuItem.Size = new System.Drawing.Size(351, 22);
            this.thôngKêTheoĐốiTượngBệnhNhânToolStripMenuItem.Text = "Tổng hợp đối tượng bệnh nhân";
            // 
            // thôngKêChiTiếtTheoĐốiTượngToolStripMenuItem
            // 
            this.thôngKêChiTiếtTheoĐốiTượngToolStripMenuItem.Name = "thôngKêChiTiếtTheoĐốiTượngToolStripMenuItem";
            this.thôngKêChiTiếtTheoĐốiTượngToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.thôngKêChiTiếtTheoĐốiTượngToolStripMenuItem.Text = "Danh sách đối tượng bệnh nhân";
            this.thôngKêChiTiếtTheoĐốiTượngToolStripMenuItem.Click += new System.EventHandler(this.thôngKêChiTiếtTheoĐốiTượngToolStripMenuItem_Click);
            // 
            // thốngKêChỉĐịnhCậnLâmSàngToolStripMenuItem
            // 
            this.thốngKêChỉĐịnhCậnLâmSàngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tổngHợpLượngChỉĐịnhTheoBácSỹToolStripMenuItem,
            this.thôngKêChiTiếtCLSTheoKhoaThựcHiệnToolStripMenuItem,
            this.toolStripSeparator14,
            this.tổngHợpSốLượtChỉĐịnhCLSToolStripMenuItem,
            this.tổngHợpSốLượtChỉĐịnhCLSTheoKhoaToolStripMenuItem,
            this.toolStripMenuItem35,
            this.thốngKêChiTiếtChụpCRThToolStripMenuItem,
            this.tổngHợpToolStripMenuItem2,
            this.danToolStripMenuItem,
            this.thốngKêChiPhíCLSTheoKhoaThựcHiệnToolStripMenuItem,
            this.tổngHợpChiPhíCLSTheoKhoaThựcHiệnToolStripMenuItem});
            this.thốngKêChỉĐịnhCậnLâmSàngToolStripMenuItem.Name = "thốngKêChỉĐịnhCậnLâmSàngToolStripMenuItem";
            this.thốngKêChỉĐịnhCậnLâmSàngToolStripMenuItem.Size = new System.Drawing.Size(351, 22);
            this.thốngKêChỉĐịnhCậnLâmSàngToolStripMenuItem.Text = "Tổng hợp chỉ định cận lâm sàng";
            // 
            // tổngHợpLượngChỉĐịnhTheoBácSỹToolStripMenuItem
            // 
            this.tổngHợpLượngChỉĐịnhTheoBácSỹToolStripMenuItem.Name = "tổngHợpLượngChỉĐịnhTheoBácSỹToolStripMenuItem";
            this.tổngHợpLượngChỉĐịnhTheoBácSỹToolStripMenuItem.Size = new System.Drawing.Size(316, 22);
            this.tổngHợpLượngChỉĐịnhTheoBácSỹToolStripMenuItem.Text = "Thông kê chi tiết CLS theo bác sĩ chỉ định";
            this.tổngHợpLượngChỉĐịnhTheoBácSỹToolStripMenuItem.Click += new System.EventHandler(this.tổngHợpLượngChỉĐịnhTheoBácSỹToolStripMenuItem_Click);
            // 
            // thôngKêChiTiếtCLSTheoKhoaThựcHiệnToolStripMenuItem
            // 
            this.thôngKêChiTiếtCLSTheoKhoaThựcHiệnToolStripMenuItem.Name = "thôngKêChiTiếtCLSTheoKhoaThựcHiệnToolStripMenuItem";
            this.thôngKêChiTiếtCLSTheoKhoaThựcHiệnToolStripMenuItem.Size = new System.Drawing.Size(316, 22);
            this.thôngKêChiTiếtCLSTheoKhoaThựcHiệnToolStripMenuItem.Text = "Thông kê chi tiết theo chi phí CLS";
            this.thôngKêChiTiếtCLSTheoKhoaThựcHiệnToolStripMenuItem.Click += new System.EventHandler(this.thôngKêChiTiếtCLSTheoKhoaThựcHiệnToolStripMenuItem_Click);
            // 
            // toolStripSeparator14
            // 
            this.toolStripSeparator14.Name = "toolStripSeparator14";
            this.toolStripSeparator14.Size = new System.Drawing.Size(313, 6);
            // 
            // tổngHợpSốLượtChỉĐịnhCLSToolStripMenuItem
            // 
            this.tổngHợpSốLượtChỉĐịnhCLSToolStripMenuItem.Name = "tổngHợpSốLượtChỉĐịnhCLSToolStripMenuItem";
            this.tổngHợpSốLượtChỉĐịnhCLSToolStripMenuItem.Size = new System.Drawing.Size(316, 22);
            this.tổngHợpSốLượtChỉĐịnhCLSToolStripMenuItem.Text = "Tổng hợp số lượt chỉ định CLS theo bác sĩ";
            this.tổngHợpSốLượtChỉĐịnhCLSToolStripMenuItem.Click += new System.EventHandler(this.tổngHợpSốLượtChỉĐịnhCLSToolStripMenuItem_Click);
            // 
            // tổngHợpSốLượtChỉĐịnhCLSTheoKhoaToolStripMenuItem
            // 
            this.tổngHợpSốLượtChỉĐịnhCLSTheoKhoaToolStripMenuItem.Name = "tổngHợpSốLượtChỉĐịnhCLSTheoKhoaToolStripMenuItem";
            this.tổngHợpSốLượtChỉĐịnhCLSTheoKhoaToolStripMenuItem.Size = new System.Drawing.Size(316, 22);
            this.tổngHợpSốLượtChỉĐịnhCLSTheoKhoaToolStripMenuItem.Text = "Tổng hợp số lượt chỉ định CLS";
            this.tổngHợpSốLượtChỉĐịnhCLSTheoKhoaToolStripMenuItem.Click += new System.EventHandler(this.tổngHợpSốLượtChỉĐịnhCLSTheoKhoaToolStripMenuItem_Click);
            // 
            // toolStripMenuItem35
            // 
            this.toolStripMenuItem35.Name = "toolStripMenuItem35";
            this.toolStripMenuItem35.Size = new System.Drawing.Size(313, 6);
            // 
            // thốngKêChiTiếtChụpCRThToolStripMenuItem
            // 
            this.thốngKêChiTiếtChụpCRThToolStripMenuItem.Name = "thốngKêChiTiếtChụpCRThToolStripMenuItem";
            this.thốngKêChiTiếtChụpCRThToolStripMenuItem.Size = new System.Drawing.Size(316, 22);
            this.thốngKêChiTiếtChụpCRThToolStripMenuItem.Text = "Thống kê chi tiết chụp CR theo bác sĩ chỉ định";
            this.thốngKêChiTiếtChụpCRThToolStripMenuItem.Click += new System.EventHandler(this.thốngKêChiTiếtChụpCRThToolStripMenuItem_Click);
            // 
            // tổngHợpToolStripMenuItem2
            // 
            this.tổngHợpToolStripMenuItem2.Name = "tổngHợpToolStripMenuItem2";
            this.tổngHợpToolStripMenuItem2.Size = new System.Drawing.Size(316, 22);
            this.tổngHợpToolStripMenuItem2.Text = "Tổng hợp số lượt chỉ định chụp CR ";
            this.tổngHợpToolStripMenuItem2.Click += new System.EventHandler(this.tổngHợpToolStripMenuItem2_Click);
            // 
            // danToolStripMenuItem
            // 
            this.danToolStripMenuItem.Name = "danToolStripMenuItem";
            this.danToolStripMenuItem.Size = new System.Drawing.Size(316, 22);
            this.danToolStripMenuItem.Text = "Danh sách BN xét chỉ định ĐMMM (Nội 4)";
            this.danToolStripMenuItem.Click += new System.EventHandler(this.danToolStripMenuItem_Click);
            // 
            // thốngKêChiPhíCLSTheoKhoaThựcHiệnToolStripMenuItem
            // 
            this.thốngKêChiPhíCLSTheoKhoaThựcHiệnToolStripMenuItem.Name = "thốngKêChiPhíCLSTheoKhoaThựcHiệnToolStripMenuItem";
            this.thốngKêChiPhíCLSTheoKhoaThựcHiệnToolStripMenuItem.Size = new System.Drawing.Size(316, 22);
            this.thốngKêChiPhíCLSTheoKhoaThựcHiệnToolStripMenuItem.Text = "Thống kê chi phí CLS theo khoa thực hiện";
            this.thốngKêChiPhíCLSTheoKhoaThựcHiệnToolStripMenuItem.Click += new System.EventHandler(this.thốngKêChiPhíCLSTheoKhoaThựcHiệnToolStripMenuItem_Click);
            // 
            // tổngHợpChiPhíCLSTheoKhoaThựcHiệnToolStripMenuItem
            // 
            this.tổngHợpChiPhíCLSTheoKhoaThựcHiệnToolStripMenuItem.Name = "tổngHợpChiPhíCLSTheoKhoaThựcHiệnToolStripMenuItem";
            this.tổngHợpChiPhíCLSTheoKhoaThựcHiệnToolStripMenuItem.Size = new System.Drawing.Size(316, 22);
            this.tổngHợpChiPhíCLSTheoKhoaThựcHiệnToolStripMenuItem.Text = "Tổng hợp chi phí CLS theo khoa thực hiện";
            this.tổngHợpChiPhíCLSTheoKhoaThựcHiệnToolStripMenuItem.Click += new System.EventHandler(this.tổngHợpChiPhíCLSTheoKhoaThựcHiệnToolStripMenuItem_Click);
            // 
            // tổngHợpChỉĐinhMáuToolStripMenuItem
            // 
            this.tổngHợpChỉĐinhMáuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thốngToolStripMenuItem,
            this.toolStripSeparator13,
            this.tổngHợpSốLượtTruyềnMáuToolStripMenuItem,
            this.tổngHợpSốLượtTruyềnMáuTheoToolStripMenuItem,
            this.toolStripSeparator15,
            this.tổngHợpSốLượngMáuTruyềnTheoLọaMáuToolStripMenuItem});
            this.tổngHợpChỉĐinhMáuToolStripMenuItem.Name = "tổngHợpChỉĐinhMáuToolStripMenuItem";
            this.tổngHợpChỉĐinhMáuToolStripMenuItem.Size = new System.Drawing.Size(351, 22);
            this.tổngHợpChỉĐinhMáuToolStripMenuItem.Text = "Tổng hợp chỉ định truyền máu";
            // 
            // thốngToolStripMenuItem
            // 
            this.thốngToolStripMenuItem.Name = "thốngToolStripMenuItem";
            this.thốngToolStripMenuItem.Size = new System.Drawing.Size(363, 22);
            this.thốngToolStripMenuItem.Text = "Thông kê chi tiết truyền máu theo BS chỉ định";
            this.thốngToolStripMenuItem.Click += new System.EventHandler(this.thốngToolStripMenuItem_Click);
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(360, 6);
            // 
            // tổngHợpSốLượtTruyềnMáuToolStripMenuItem
            // 
            this.tổngHợpSốLượtTruyềnMáuToolStripMenuItem.Name = "tổngHợpSốLượtTruyềnMáuToolStripMenuItem";
            this.tổngHợpSốLượtTruyềnMáuToolStripMenuItem.Size = new System.Drawing.Size(363, 22);
            this.tổngHợpSốLượtTruyềnMáuToolStripMenuItem.Text = "Tổng hợp số lượt chỉ định truyền máu theo BS chỉ định";
            this.tổngHợpSốLượtTruyềnMáuToolStripMenuItem.Click += new System.EventHandler(this.tổngHợpSốLượtTruyềnMáuToolStripMenuItem_Click);
            // 
            // tổngHợpSốLượtTruyềnMáuTheoToolStripMenuItem
            // 
            this.tổngHợpSốLượtTruyềnMáuTheoToolStripMenuItem.Name = "tổngHợpSốLượtTruyềnMáuTheoToolStripMenuItem";
            this.tổngHợpSốLượtTruyềnMáuTheoToolStripMenuItem.Size = new System.Drawing.Size(363, 22);
            this.tổngHợpSốLượtTruyềnMáuTheoToolStripMenuItem.Text = "Tổng hợp số lượt chỉ định truyền máu theo loại máu";
            this.tổngHợpSốLượtTruyềnMáuTheoToolStripMenuItem.Click += new System.EventHandler(this.tổngHợpSốLượtTruyềnMáuTheoToolStripMenuItem_Click);
            // 
            // toolStripSeparator15
            // 
            this.toolStripSeparator15.Name = "toolStripSeparator15";
            this.toolStripSeparator15.Size = new System.Drawing.Size(360, 6);
            // 
            // tổngHợpSốLượngMáuTruyềnTheoLọaMáuToolStripMenuItem
            // 
            this.tổngHợpSốLượngMáuTruyềnTheoLọaMáuToolStripMenuItem.Name = "tổngHợpSốLượngMáuTruyềnTheoLọaMáuToolStripMenuItem";
            this.tổngHợpSốLượngMáuTruyềnTheoLọaMáuToolStripMenuItem.Size = new System.Drawing.Size(363, 22);
            this.tổngHợpSốLượngMáuTruyềnTheoLọaMáuToolStripMenuItem.Text = "Tổng hợp số lượng máu truyền theo loại máu";
            this.tổngHợpSốLượngMáuTruyềnTheoLọaMáuToolStripMenuItem.Click += new System.EventHandler(this.tổngHợpSốLượngMáuTruyềnTheoLọaMáuToolStripMenuItem_Click);
            // 
            // tổngHợpChếĐộChămSócBệnhNhânToolStripMenuItem
            // 
            this.tổngHợpChếĐộChămSócBệnhNhânToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thôngKêChếChiTiếtĐọChămSócToolStripMenuItem,
            this.tổngHợpToolStripMenuItem});
            this.tổngHợpChếĐộChămSócBệnhNhânToolStripMenuItem.Name = "tổngHợpChếĐộChămSócBệnhNhânToolStripMenuItem";
            this.tổngHợpChếĐộChămSócBệnhNhânToolStripMenuItem.Size = new System.Drawing.Size(351, 22);
            this.tổngHợpChếĐộChămSócBệnhNhânToolStripMenuItem.Text = "Tổng hợp chế độ chăm sóc bệnh nhân";
            // 
            // thôngKêChếChiTiếtĐọChămSócToolStripMenuItem
            // 
            this.thôngKêChếChiTiếtĐọChămSócToolStripMenuItem.Name = "thôngKêChếChiTiếtĐọChămSócToolStripMenuItem";
            this.thôngKêChếChiTiếtĐọChămSócToolStripMenuItem.Size = new System.Drawing.Size(284, 22);
            this.thôngKêChếChiTiếtĐọChămSócToolStripMenuItem.Text = "Thông kê chi tiết theo chế độ chăm sóc";
            this.thôngKêChếChiTiếtĐọChămSócToolStripMenuItem.Click += new System.EventHandler(this.thôngKêChếChiTiếtĐọChămSócToolStripMenuItem_Click);
            // 
            // tổngHợpToolStripMenuItem
            // 
            this.tổngHợpToolStripMenuItem.Name = "tổngHợpToolStripMenuItem";
            this.tổngHợpToolStripMenuItem.Size = new System.Drawing.Size(284, 22);
            this.tổngHợpToolStripMenuItem.Text = "Tổng hợp số lượt theo chế độ chăm sóc";
            this.tổngHợpToolStripMenuItem.Click += new System.EventHandler(this.tổngHợpToolStripMenuItem_Click);
            // 
            // tổngHợpBệnhNhânChuyểnViệnToolStripMenuItem
            // 
            this.tổngHợpBệnhNhânChuyểnViệnToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thôngKêDanhSáchBệnhNhânChuyểnViệnToolStripMenuItem,
            this.thôngKêDanhSáchBệnhNhânTheoBVChuyểnĐếnToolStripMenuItem,
            this.thốngKêDanhSáchBệnhNhânTheoBSChỉĐịnhToolStripMenuItem,
            this.toolStripSeparator16,
            this.tổngHợpSốLượngChuyểnViệnTheoBVChuyểnĐếnToolStripMenuItem,
            this.tổngHợpSốLượngChuyểnViệnTheoBSChỉĐịnhToolStripMenuItem});
            this.tổngHợpBệnhNhânChuyểnViệnToolStripMenuItem.Name = "tổngHợpBệnhNhânChuyểnViệnToolStripMenuItem";
            this.tổngHợpBệnhNhânChuyểnViệnToolStripMenuItem.Size = new System.Drawing.Size(351, 22);
            this.tổngHợpBệnhNhânChuyểnViệnToolStripMenuItem.Text = "Tổng hợp bệnh nhân chuyển viện";
            // 
            // thôngKêDanhSáchBệnhNhânChuyểnViệnToolStripMenuItem
            // 
            this.thôngKêDanhSáchBệnhNhânChuyểnViệnToolStripMenuItem.Name = "thôngKêDanhSáchBệnhNhânChuyểnViệnToolStripMenuItem";
            this.thôngKêDanhSáchBệnhNhânChuyểnViệnToolStripMenuItem.Size = new System.Drawing.Size(405, 22);
            this.thôngKêDanhSáchBệnhNhânChuyểnViệnToolStripMenuItem.Text = "Thông kê danh sách bệnh nhân chuyển viện";
            this.thôngKêDanhSáchBệnhNhânChuyểnViệnToolStripMenuItem.Click += new System.EventHandler(this.thôngKêDanhSáchBệnhNhânChuyểnViệnToolStripMenuItem_Click);
            // 
            // thôngKêDanhSáchBệnhNhânTheoBVChuyểnĐếnToolStripMenuItem
            // 
            this.thôngKêDanhSáchBệnhNhânTheoBVChuyểnĐếnToolStripMenuItem.Name = "thôngKêDanhSáchBệnhNhânTheoBVChuyểnĐếnToolStripMenuItem";
            this.thôngKêDanhSáchBệnhNhânTheoBVChuyểnĐếnToolStripMenuItem.Size = new System.Drawing.Size(405, 22);
            this.thôngKêDanhSáchBệnhNhânTheoBVChuyểnĐếnToolStripMenuItem.Text = "Thông kê danh sách bệnh nhân theo BV chuyển đến";
            this.thôngKêDanhSáchBệnhNhânTheoBVChuyểnĐếnToolStripMenuItem.Click += new System.EventHandler(this.thôngKêDanhSáchBệnhNhânTheoBVChuyểnĐếnToolStripMenuItem_Click);
            // 
            // thốngKêDanhSáchBệnhNhânTheoBSChỉĐịnhToolStripMenuItem
            // 
            this.thốngKêDanhSáchBệnhNhânTheoBSChỉĐịnhToolStripMenuItem.Name = "thốngKêDanhSáchBệnhNhânTheoBSChỉĐịnhToolStripMenuItem";
            this.thốngKêDanhSáchBệnhNhânTheoBSChỉĐịnhToolStripMenuItem.Size = new System.Drawing.Size(405, 22);
            this.thốngKêDanhSáchBệnhNhânTheoBSChỉĐịnhToolStripMenuItem.Text = "Thống kê danh sách bệnh nhân theo BS chỉ định";
            this.thốngKêDanhSáchBệnhNhânTheoBSChỉĐịnhToolStripMenuItem.Click += new System.EventHandler(this.thốngKêDanhSáchBệnhNhânTheoBSChỉĐịnhToolStripMenuItem_Click);
            // 
            // toolStripSeparator16
            // 
            this.toolStripSeparator16.Name = "toolStripSeparator16";
            this.toolStripSeparator16.Size = new System.Drawing.Size(402, 6);
            // 
            // tổngHợpSốLượngChuyểnViệnTheoBVChuyểnĐếnToolStripMenuItem
            // 
            this.tổngHợpSốLượngChuyểnViệnTheoBVChuyểnĐếnToolStripMenuItem.Name = "tổngHợpSốLượngChuyểnViệnTheoBVChuyểnĐếnToolStripMenuItem";
            this.tổngHợpSốLượngChuyểnViệnTheoBVChuyểnĐếnToolStripMenuItem.Size = new System.Drawing.Size(405, 22);
            this.tổngHợpSốLượngChuyểnViệnTheoBVChuyểnĐếnToolStripMenuItem.Text = "Tổng hợp số lượng chuyển viện theo BV (BV được chuyển đến)";
            this.tổngHợpSốLượngChuyểnViệnTheoBVChuyểnĐếnToolStripMenuItem.Click += new System.EventHandler(this.tổngHợpSốLượngChuyểnViệnTheoBVChuyểnĐếnToolStripMenuItem_Click);
            // 
            // tổngHợpSốLượngChuyểnViệnTheoBSChỉĐịnhToolStripMenuItem
            // 
            this.tổngHợpSốLượngChuyểnViệnTheoBSChỉĐịnhToolStripMenuItem.Name = "tổngHợpSốLượngChuyểnViệnTheoBSChỉĐịnhToolStripMenuItem";
            this.tổngHợpSốLượngChuyểnViệnTheoBSChỉĐịnhToolStripMenuItem.Size = new System.Drawing.Size(405, 22);
            this.tổngHợpSốLượngChuyểnViệnTheoBSChỉĐịnhToolStripMenuItem.Text = "Tổng hợp số lượng chuyển viện theo BS chỉ định";
            this.tổngHợpSốLượngChuyểnViệnTheoBSChỉĐịnhToolStripMenuItem.Click += new System.EventHandler(this.tổngHợpSốLượngChuyểnViệnTheoBSChỉĐịnhToolStripMenuItem_Click);
            // 
            // tổngHợpBệnhNhânTheoNơiKhámChữaBệnhBanĐầuToolStripMenuItem
            // 
            this.tổngHợpBệnhNhânTheoNơiKhámChữaBệnhBanĐầuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thôngKêDanhSáchBệnhNhânTheoNơiKCBBanĐầuToolStripMenuItem,
            this.thôngKêDanhSáchBNToolStripMenuItem});
            this.tổngHợpBệnhNhânTheoNơiKhámChữaBệnhBanĐầuToolStripMenuItem.Name = "tổngHợpBệnhNhânTheoNơiKhámChữaBệnhBanĐầuToolStripMenuItem";
            this.tổngHợpBệnhNhânTheoNơiKhámChữaBệnhBanĐầuToolStripMenuItem.Size = new System.Drawing.Size(351, 22);
            this.tổngHợpBệnhNhânTheoNơiKhámChữaBệnhBanĐầuToolStripMenuItem.Text = "Tổng hợp bệnh nhân theo nơi KCB ban đầu";
            // 
            // thôngKêDanhSáchBệnhNhânTheoNơiKCBBanĐầuToolStripMenuItem
            // 
            this.thôngKêDanhSáchBệnhNhânTheoNơiKCBBanĐầuToolStripMenuItem.Name = "thôngKêDanhSáchBệnhNhânTheoNơiKCBBanĐầuToolStripMenuItem";
            this.thôngKêDanhSáchBệnhNhânTheoNơiKCBBanĐầuToolStripMenuItem.Size = new System.Drawing.Size(383, 22);
            this.thôngKêDanhSáchBệnhNhânTheoNơiKCBBanĐầuToolStripMenuItem.Text = "Thông kê danh sách BN theo nơi KCB ban đầu";
            this.thôngKêDanhSáchBệnhNhânTheoNơiKCBBanĐầuToolStripMenuItem.Click += new System.EventHandler(this.thôngKêDanhSáchBệnhNhânTheoNơiKCBBanĐầuToolStripMenuItem_Click);
            // 
            // thôngKêDanhSáchBNToolStripMenuItem
            // 
            this.thôngKêDanhSáchBNToolStripMenuItem.Name = "thôngKêDanhSáchBNToolStripMenuItem";
            this.thôngKêDanhSáchBNToolStripMenuItem.Size = new System.Drawing.Size(383, 22);
            this.thôngKêDanhSáchBNToolStripMenuItem.Text = "Thông kê danh sách BN chuyển viện theo noi KCB ban đầu";
            this.thôngKêDanhSáchBNToolStripMenuItem.Click += new System.EventHandler(this.thôngKêDanhSáchBNToolStripMenuItem_Click);
            // 
            // ngàyĐiềuTrịTrungBinhToolStripMenuItem
            // 
            this.ngàyĐiềuTrịTrungBinhToolStripMenuItem.Name = "ngàyĐiềuTrịTrungBinhToolStripMenuItem";
            this.ngàyĐiềuTrịTrungBinhToolStripMenuItem.Size = new System.Drawing.Size(351, 22);
            this.ngàyĐiềuTrịTrungBinhToolStripMenuItem.Text = "Tổng hợp tình hình hoạt động";
            this.ngàyĐiềuTrịTrungBinhToolStripMenuItem.Click += new System.EventHandler(this.ngàyĐiềuTrịTrungBinhToolStripMenuItem_Click);
            // 
            // tổngHợpBệnhNhânTheoBuồngGiươngToolStripMenuItem
            // 
            this.tổngHợpBệnhNhânTheoBuồngGiươngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thôngKêDanhSáchBệnhNhânTheoBuồngToolStripMenuItem,
            this.tổngHợpSốLượtBệnhNhânTheoBuồngToolStripMenuItem,
            this.chiTiêtBênhNhânTheoGiươngBênhToolStripMenuItem});
            this.tổngHợpBệnhNhânTheoBuồngGiươngToolStripMenuItem.Name = "tổngHợpBệnhNhânTheoBuồngGiươngToolStripMenuItem";
            this.tổngHợpBệnhNhânTheoBuồngGiươngToolStripMenuItem.Size = new System.Drawing.Size(351, 22);
            this.tổngHợpBệnhNhânTheoBuồngGiươngToolStripMenuItem.Text = "Tổng hợp bệnh nhân theo buồng-giường";
            // 
            // thôngKêDanhSáchBệnhNhânTheoBuồngToolStripMenuItem
            // 
            this.thôngKêDanhSáchBệnhNhânTheoBuồngToolStripMenuItem.Name = "thôngKêDanhSáchBệnhNhânTheoBuồngToolStripMenuItem";
            this.thôngKêDanhSáchBệnhNhânTheoBuồngToolStripMenuItem.Size = new System.Drawing.Size(346, 22);
            this.thôngKêDanhSáchBệnhNhânTheoBuồngToolStripMenuItem.Text = "Thông kê danh sách bệnh nhân theo buồng giường";
            this.thôngKêDanhSáchBệnhNhânTheoBuồngToolStripMenuItem.Click += new System.EventHandler(this.thôngKêDanhSáchBệnhNhânTheoBuồngToolStripMenuItem_Click);
            // 
            // tổngHợpSốLượtBệnhNhânTheoBuồngToolStripMenuItem
            // 
            this.tổngHợpSốLượtBệnhNhânTheoBuồngToolStripMenuItem.Name = "tổngHợpSốLượtBệnhNhânTheoBuồngToolStripMenuItem";
            this.tổngHợpSốLượtBệnhNhânTheoBuồngToolStripMenuItem.Size = new System.Drawing.Size(346, 22);
            this.tổngHợpSốLượtBệnhNhânTheoBuồngToolStripMenuItem.Text = "Tổng hợp số lượt bệnh nhân theo buồng giường";
            this.tổngHợpSốLượtBệnhNhânTheoBuồngToolStripMenuItem.Click += new System.EventHandler(this.tổngHợpSốLượtBệnhNhânTheoBuồngToolStripMenuItem_Click);
            // 
            // chiTiêtBênhNhânTheoGiươngBênhToolStripMenuItem
            // 
            this.chiTiêtBênhNhânTheoGiươngBênhToolStripMenuItem.Name = "chiTiêtBênhNhânTheoGiươngBênhToolStripMenuItem";
            this.chiTiêtBênhNhânTheoGiươngBênhToolStripMenuItem.Size = new System.Drawing.Size(346, 22);
            this.chiTiêtBênhNhânTheoGiươngBênhToolStripMenuItem.Text = "Chi tiết bệnh nhân theo giường bệnh";
            this.chiTiêtBênhNhânTheoGiươngBênhToolStripMenuItem.Click += new System.EventHandler(this.chiTiêtBênhNhânTheoGiươngBênhToolStripMenuItem_Click);
            // 
            // tổngHợpICD10ToolStripMenuItem
            // 
            this.tổngHợpICD10ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.danhSáchBệnhNhânToolStripMenuItem1,
            this.tổngHợpTheoMãBệnhICD10ToolStripMenuItem});
            this.tổngHợpICD10ToolStripMenuItem.Name = "tổngHợpICD10ToolStripMenuItem";
            this.tổngHợpICD10ToolStripMenuItem.Size = new System.Drawing.Size(351, 22);
            this.tổngHợpICD10ToolStripMenuItem.Text = "Tổng hợp ICD10";
            this.tổngHợpICD10ToolStripMenuItem.Click += new System.EventHandler(this.tổngHợpICD10ToolStripMenuItem_Click);
            // 
            // danhSáchBệnhNhânToolStripMenuItem1
            // 
            this.danhSáchBệnhNhânToolStripMenuItem1.Name = "danhSáchBệnhNhânToolStripMenuItem1";
            this.danhSáchBệnhNhânToolStripMenuItem1.Size = new System.Drawing.Size(250, 22);
            this.danhSáchBệnhNhânToolStripMenuItem1.Text = "Danh sách bệnh nhân theo ICD10";
            this.danhSáchBệnhNhânToolStripMenuItem1.Click += new System.EventHandler(this.danhSáchBệnhNhânToolStripMenuItem1_Click);
            // 
            // tổngHợpTheoMãBệnhICD10ToolStripMenuItem
            // 
            this.tổngHợpTheoMãBệnhICD10ToolStripMenuItem.Name = "tổngHợpTheoMãBệnhICD10ToolStripMenuItem";
            this.tổngHợpTheoMãBệnhICD10ToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.tổngHợpTheoMãBệnhICD10ToolStripMenuItem.Text = "Tổng hợp theo mã bệnh ICD10";
            this.tổngHợpTheoMãBệnhICD10ToolStripMenuItem.Click += new System.EventHandler(this.tổngHợpTheoMãBệnhICD10ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem43
            // 
            this.toolStripMenuItem43.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.danhSáchBệnhNhânToolStripMenuItem2,
            this.thốngKêTổngHợpXuấtĂnToolStripMenuItem,
            this.toolStripMenuItem44,
            this.thốngKêTổngHợpXuấtĂnBNĐangĐiềuTrịToolStripMenuItem});
            this.toolStripMenuItem43.Name = "toolStripMenuItem43";
            this.toolStripMenuItem43.Size = new System.Drawing.Size(351, 22);
            this.toolStripMenuItem43.Text = "Tổng hợp xuất ăn";
            this.toolStripMenuItem43.Click += new System.EventHandler(this.toolStripMenuItem43_Click);
            // 
            // danhSáchBệnhNhânToolStripMenuItem2
            // 
            this.danhSáchBệnhNhânToolStripMenuItem2.Name = "danhSáchBệnhNhânToolStripMenuItem2";
            this.danhSáchBệnhNhânToolStripMenuItem2.Size = new System.Drawing.Size(315, 22);
            this.danhSáchBệnhNhânToolStripMenuItem2.Text = "Thống kê Danh sách xuất ăn BN ra viện";
            this.danhSáchBệnhNhânToolStripMenuItem2.Click += new System.EventHandler(this.danhSáchBệnhNhânToolStripMenuItem2_Click);
            // 
            // thốngKêTổngHợpXuấtĂnToolStripMenuItem
            // 
            this.thốngKêTổngHợpXuấtĂnToolStripMenuItem.Name = "thốngKêTổngHợpXuấtĂnToolStripMenuItem";
            this.thốngKêTổngHợpXuấtĂnToolStripMenuItem.Size = new System.Drawing.Size(315, 22);
            this.thốngKêTổngHợpXuấtĂnToolStripMenuItem.Text = "Thống kê tổng hợp xuất ăn BN ra viện";
            this.thốngKêTổngHợpXuấtĂnToolStripMenuItem.Click += new System.EventHandler(this.thốngKêTổngHợpXuấtĂnToolStripMenuItem_Click);
            // 
            // toolStripMenuItem44
            // 
            this.toolStripMenuItem44.Name = "toolStripMenuItem44";
            this.toolStripMenuItem44.Size = new System.Drawing.Size(315, 22);
            this.toolStripMenuItem44.Text = "Thống kê Danh sách xuất ăn BN đang điều trị ";
            this.toolStripMenuItem44.Click += new System.EventHandler(this.toolStripMenuItem44_Click);
            // 
            // thốngKêTổngHợpXuấtĂnBNĐangĐiềuTrịToolStripMenuItem
            // 
            this.thốngKêTổngHợpXuấtĂnBNĐangĐiềuTrịToolStripMenuItem.Name = "thốngKêTổngHợpXuấtĂnBNĐangĐiềuTrịToolStripMenuItem";
            this.thốngKêTổngHợpXuấtĂnBNĐangĐiềuTrịToolStripMenuItem.Size = new System.Drawing.Size(315, 22);
            this.thốngKêTổngHợpXuấtĂnBNĐangĐiềuTrịToolStripMenuItem.Text = "Thống kê tổng hợp xuất ăn BN đang điều trị";
            this.thốngKêTổngHợpXuấtĂnBNĐangĐiềuTrịToolStripMenuItem.Click += new System.EventHandler(this.thốngKêTổngHợpXuấtĂnBNĐangĐiềuTrịToolStripMenuItem_Click);
            // 
            // toolStripMenuItem24
            // 
            this.toolStripMenuItem24.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.danhSáchBệnhNhânTưVongToolStripMenuItem,
            this.toolStripSeparator9,
            this.tổngHợpBệnhNhânTheoKếtQuảĐiềuTrịToolStripMenuItem});
            this.toolStripMenuItem24.Name = "toolStripMenuItem24";
            this.toolStripMenuItem24.Size = new System.Drawing.Size(351, 22);
            this.toolStripMenuItem24.Text = "Tổng hợp danh sách bệnh nhân theo kết quả điều trị";
            // 
            // danhSáchBệnhNhânTưVongToolStripMenuItem
            // 
            this.danhSáchBệnhNhânTưVongToolStripMenuItem.Name = "danhSáchBệnhNhânTưVongToolStripMenuItem";
            this.danhSáchBệnhNhânTưVongToolStripMenuItem.Size = new System.Drawing.Size(294, 22);
            this.danhSáchBệnhNhânTưVongToolStripMenuItem.Text = "Thống kê danh sách bệnh nhân";
            this.danhSáchBệnhNhânTưVongToolStripMenuItem.Click += new System.EventHandler(this.danhSáchBệnhNhânTưVongToolStripMenuItem_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(291, 6);
            // 
            // tổngHợpBệnhNhânTheoKếtQuảĐiềuTrịToolStripMenuItem
            // 
            this.tổngHợpBệnhNhânTheoKếtQuảĐiềuTrịToolStripMenuItem.Name = "tổngHợpBệnhNhânTheoKếtQuảĐiềuTrịToolStripMenuItem";
            this.tổngHợpBệnhNhânTheoKếtQuảĐiềuTrịToolStripMenuItem.Size = new System.Drawing.Size(294, 22);
            this.tổngHợpBệnhNhânTheoKếtQuảĐiềuTrịToolStripMenuItem.Text = "Tổng hợp bệnh nhân theo kết quả điều trị";
            this.tổngHợpBệnhNhânTheoKếtQuảĐiềuTrịToolStripMenuItem.Click += new System.EventHandler(this.tổngHợpBệnhNhânTheoKếtQuảĐiềuTrịToolStripMenuItem_Click);
            // 
            // toolStripMenuItem26
            // 
            this.toolStripMenuItem26.Name = "toolStripMenuItem26";
            this.toolStripMenuItem26.Size = new System.Drawing.Size(348, 6);
            // 
            // tổngHợpBệnhNhânLàmThủThuậtToolStripMenuItem
            // 
            this.tổngHợpBệnhNhânLàmThủThuậtToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thôngKêDanhSáchBệnhNhânToolStripMenuItem,
            this.tổngHợpSốLượngBệnhNhânLàmThủThuậtToolStripMenuItem,
            this.toolStripMenuItem27,
            this.thốngKêDanhSáchBệnhNhânTheoBSChỉĐịnhToolStripMenuItem1,
            this.tổngHợpSốLượtBệnhNhânTheoBSChỉĐịnhToolStripMenuItem,
            this.toolStripSeparator10,
            this.toolStripMenuItem40,
            this.toolStripMenuItem39,
            this.danhSáchBệnhNhânThủThuậtToolStripMenuItem,
            this.bảngKêSốCaLàmThủThuậtTheoThờiGianThanhToánToolStripMenuItem,
            this.bảngThanhToánTiềnThủThuậtTheoThờiGianThanhToánToolStripMenuItem});
            this.tổngHợpBệnhNhânLàmThủThuậtToolStripMenuItem.Name = "tổngHợpBệnhNhânLàmThủThuậtToolStripMenuItem";
            this.tổngHợpBệnhNhânLàmThủThuậtToolStripMenuItem.Size = new System.Drawing.Size(351, 22);
            this.tổngHợpBệnhNhânLàmThủThuậtToolStripMenuItem.Text = "Tổng hợp bệnh nhân làm thủ thuật";
            // 
            // thôngKêDanhSáchBệnhNhânToolStripMenuItem
            // 
            this.thôngKêDanhSáchBệnhNhânToolStripMenuItem.Name = "thôngKêDanhSáchBệnhNhânToolStripMenuItem";
            this.thôngKêDanhSáchBệnhNhânToolStripMenuItem.Size = new System.Drawing.Size(416, 22);
            this.thôngKêDanhSáchBệnhNhânToolStripMenuItem.Text = "Thông kê danh sách bệnh nhân làm thủ thuật theo loại thủ thuật";
            this.thôngKêDanhSáchBệnhNhânToolStripMenuItem.Click += new System.EventHandler(this.thôngKêDanhSáchBệnhNhânToolStripMenuItem_Click);
            // 
            // tổngHợpSốLượngBệnhNhânLàmThủThuậtToolStripMenuItem
            // 
            this.tổngHợpSốLượngBệnhNhânLàmThủThuậtToolStripMenuItem.Name = "tổngHợpSốLượngBệnhNhânLàmThủThuậtToolStripMenuItem";
            this.tổngHợpSốLượngBệnhNhânLàmThủThuậtToolStripMenuItem.Size = new System.Drawing.Size(416, 22);
            this.tổngHợpSốLượngBệnhNhânLàmThủThuậtToolStripMenuItem.Text = "Tổng hợp số lượt bệnh nhân làm thủ thuật theo loại thủ thuật";
            this.tổngHợpSốLượngBệnhNhânLàmThủThuậtToolStripMenuItem.Click += new System.EventHandler(this.tổngHợpSốLượngBệnhNhânLàmThủThuậtToolStripMenuItem_Click);
            // 
            // toolStripMenuItem27
            // 
            this.toolStripMenuItem27.Name = "toolStripMenuItem27";
            this.toolStripMenuItem27.Size = new System.Drawing.Size(413, 6);
            // 
            // thốngKêDanhSáchBệnhNhânTheoBSChỉĐịnhToolStripMenuItem1
            // 
            this.thốngKêDanhSáchBệnhNhânTheoBSChỉĐịnhToolStripMenuItem1.Name = "thốngKêDanhSáchBệnhNhânTheoBSChỉĐịnhToolStripMenuItem1";
            this.thốngKêDanhSáchBệnhNhânTheoBSChỉĐịnhToolStripMenuItem1.Size = new System.Drawing.Size(416, 22);
            this.thốngKêDanhSáchBệnhNhânTheoBSChỉĐịnhToolStripMenuItem1.Text = "Thống kê danh sách bệnh nhân theo BS chỉ định";
            this.thốngKêDanhSáchBệnhNhânTheoBSChỉĐịnhToolStripMenuItem1.Click += new System.EventHandler(this.thốngKêDanhSáchBệnhNhânTheoBSChỉĐịnhToolStripMenuItem1_Click);
            // 
            // tổngHợpSốLượtBệnhNhânTheoBSChỉĐịnhToolStripMenuItem
            // 
            this.tổngHợpSốLượtBệnhNhânTheoBSChỉĐịnhToolStripMenuItem.Name = "tổngHợpSốLượtBệnhNhânTheoBSChỉĐịnhToolStripMenuItem";
            this.tổngHợpSốLượtBệnhNhânTheoBSChỉĐịnhToolStripMenuItem.Size = new System.Drawing.Size(416, 22);
            this.tổngHợpSốLượtBệnhNhânTheoBSChỉĐịnhToolStripMenuItem.Text = "Tổng hợp số lượt bệnh nhân theo BS chỉ định";
            this.tổngHợpSốLượtBệnhNhânTheoBSChỉĐịnhToolStripMenuItem.Click += new System.EventHandler(this.tổngHợpSốLượtBệnhNhânTheoBSChỉĐịnhToolStripMenuItem_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(413, 6);
            // 
            // toolStripMenuItem40
            // 
            this.toolStripMenuItem40.Name = "toolStripMenuItem40";
            this.toolStripMenuItem40.Size = new System.Drawing.Size(416, 22);
            this.toolStripMenuItem40.Text = "Bảng kê số ca làm thủ thuật";
            this.toolStripMenuItem40.Click += new System.EventHandler(this.toolStripMenuItem40_Click);
            // 
            // toolStripMenuItem39
            // 
            this.toolStripMenuItem39.Name = "toolStripMenuItem39";
            this.toolStripMenuItem39.Size = new System.Drawing.Size(416, 22);
            this.toolStripMenuItem39.Text = "Bảng thanh toán tiền thủ thuật";
            this.toolStripMenuItem39.Click += new System.EventHandler(this.toolStripMenuItem39_Click);
            // 
            // danhSáchBệnhNhânThủThuậtToolStripMenuItem
            // 
            this.danhSáchBệnhNhânThủThuậtToolStripMenuItem.Name = "danhSáchBệnhNhânThủThuậtToolStripMenuItem";
            this.danhSáchBệnhNhânThủThuậtToolStripMenuItem.Size = new System.Drawing.Size(416, 22);
            this.danhSáchBệnhNhânThủThuậtToolStripMenuItem.Text = "Danh sách bệnh nhân thủ thuật";
            this.danhSáchBệnhNhânThủThuậtToolStripMenuItem.Click += new System.EventHandler(this.danhSáchBệnhNhânThủThuậtToolStripMenuItem_Click);
            // 
            // bảngKêSốCaLàmThủThuậtTheoThờiGianThanhToánToolStripMenuItem
            // 
            this.bảngKêSốCaLàmThủThuậtTheoThờiGianThanhToánToolStripMenuItem.Name = "bảngKêSốCaLàmThủThuậtTheoThờiGianThanhToánToolStripMenuItem";
            this.bảngKêSốCaLàmThủThuậtTheoThờiGianThanhToánToolStripMenuItem.Size = new System.Drawing.Size(416, 22);
            this.bảngKêSốCaLàmThủThuậtTheoThờiGianThanhToánToolStripMenuItem.Text = "Bảng kê số ca làm thủ thuật (Theo thời gian thanh toán)";
            this.bảngKêSốCaLàmThủThuậtTheoThờiGianThanhToánToolStripMenuItem.Click += new System.EventHandler(this.bảngKêSốCaLàmThủThuậtTheoThờiGianThanhToánToolStripMenuItem_Click);
            // 
            // bảngThanhToánTiềnThủThuậtTheoThờiGianThanhToánToolStripMenuItem
            // 
            this.bảngThanhToánTiềnThủThuậtTheoThờiGianThanhToánToolStripMenuItem.Name = "bảngThanhToánTiềnThủThuậtTheoThờiGianThanhToánToolStripMenuItem";
            this.bảngThanhToánTiềnThủThuậtTheoThờiGianThanhToánToolStripMenuItem.Size = new System.Drawing.Size(416, 22);
            this.bảngThanhToánTiềnThủThuậtTheoThờiGianThanhToánToolStripMenuItem.Text = "Bảng thanh toán tiền thủ thuật(Theo thời gian thanh toán)";
            this.bảngThanhToánTiềnThủThuậtTheoThờiGianThanhToánToolStripMenuItem.Click += new System.EventHandler(this.bảngThanhToánTiềnThủThuậtTheoThờiGianThanhToánToolStripMenuItem_Click);
            // 
            // tổngHợpBệnhNhânLàmPhẩuThToolStripMenuItem
            // 
            this.tổngHợpBệnhNhânLàmPhẩuThToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thốngKêDanhSáchBệnhNhânLàmPhẩuThuậtToolStripMenuItem,
            this.tổngHợpSốLượtBệnhNhânLàmPhẩuThuậtToolStripMenuItem,
            this.toolStripSeparator17,
            this.thổngKêDanhSáchBệnhNhânLàmPTTheoBSChỉĐịnhToolStripMenuItem,
            this.tổngHợpSốLượngBệnhNhânToolStripMenuItem,
            this.toolStripMenuItem28,
            this.thốngKêDanhSáchBệnhNhânTheoKhoaThựcHiệnToolStripMenuItem,
            this.tổngHợpSốLượngBNTheoKhoaThựcHiệnToolStripMenuItem,
            this.danhSáchBệnhNhânPhẫuThuậtToolStripMenuItem,
            this.bảngKêSốCaLàmPhẫuThuậtTheoThờiGianThanhToánToolStripMenuItem,
            this.toolStripMenuItem45});
            this.tổngHợpBệnhNhânLàmPhẩuThToolStripMenuItem.Name = "tổngHợpBệnhNhânLàmPhẩuThToolStripMenuItem";
            this.tổngHợpBệnhNhânLàmPhẩuThToolStripMenuItem.Size = new System.Drawing.Size(351, 22);
            this.tổngHợpBệnhNhânLàmPhẩuThToolStripMenuItem.Text = "Tổng hợp bệnh nhân làm phẫu thuật";
            // 
            // thốngKêDanhSáchBệnhNhânLàmPhẩuThuậtToolStripMenuItem
            // 
            this.thốngKêDanhSáchBệnhNhânLàmPhẩuThuậtToolStripMenuItem.Name = "thốngKêDanhSáchBệnhNhânLàmPhẩuThuậtToolStripMenuItem";
            this.thốngKêDanhSáchBệnhNhânLàmPhẩuThuậtToolStripMenuItem.Size = new System.Drawing.Size(434, 22);
            this.thốngKêDanhSáchBệnhNhânLàmPhẩuThuậtToolStripMenuItem.Text = "Thống kê danh sách bệnh nhân làm phẫu thuật theo loại phẫu thuật";
            this.thốngKêDanhSáchBệnhNhânLàmPhẩuThuậtToolStripMenuItem.Click += new System.EventHandler(this.thốngKêDanhSáchBệnhNhânLàmPhẩuThuậtToolStripMenuItem_Click);
            // 
            // tổngHợpSốLượtBệnhNhânLàmPhẩuThuậtToolStripMenuItem
            // 
            this.tổngHợpSốLượtBệnhNhânLàmPhẩuThuậtToolStripMenuItem.Name = "tổngHợpSốLượtBệnhNhânLàmPhẩuThuậtToolStripMenuItem";
            this.tổngHợpSốLượtBệnhNhânLàmPhẩuThuậtToolStripMenuItem.Size = new System.Drawing.Size(434, 22);
            this.tổngHợpSốLượtBệnhNhânLàmPhẩuThuậtToolStripMenuItem.Text = "Tổng hợp số lượt bệnh nhân làm phẫu thuật theo loại phẫu thuật";
            this.tổngHợpSốLượtBệnhNhânLàmPhẩuThuậtToolStripMenuItem.Click += new System.EventHandler(this.tổngHợpSốLượtBệnhNhânLàmPhẩuThuậtToolStripMenuItem_Click);
            // 
            // toolStripSeparator17
            // 
            this.toolStripSeparator17.Name = "toolStripSeparator17";
            this.toolStripSeparator17.Size = new System.Drawing.Size(431, 6);
            // 
            // thổngKêDanhSáchBệnhNhânLàmPTTheoBSChỉĐịnhToolStripMenuItem
            // 
            this.thổngKêDanhSáchBệnhNhânLàmPTTheoBSChỉĐịnhToolStripMenuItem.Name = "thổngKêDanhSáchBệnhNhânLàmPTTheoBSChỉĐịnhToolStripMenuItem";
            this.thổngKêDanhSáchBệnhNhânLàmPTTheoBSChỉĐịnhToolStripMenuItem.Size = new System.Drawing.Size(434, 22);
            this.thổngKêDanhSáchBệnhNhânLàmPTTheoBSChỉĐịnhToolStripMenuItem.Text = "Thổng kê danh sách bệnh nhân làm PT theo BS chỉ định";
            this.thổngKêDanhSáchBệnhNhânLàmPTTheoBSChỉĐịnhToolStripMenuItem.Click += new System.EventHandler(this.thổngKêDanhSáchBệnhNhânLàmPTTheoBSChỉĐịnhToolStripMenuItem_Click);
            // 
            // tổngHợpSốLượngBệnhNhânToolStripMenuItem
            // 
            this.tổngHợpSốLượngBệnhNhânToolStripMenuItem.Name = "tổngHợpSốLượngBệnhNhânToolStripMenuItem";
            this.tổngHợpSốLượngBệnhNhânToolStripMenuItem.Size = new System.Drawing.Size(434, 22);
            this.tổngHợpSốLượngBệnhNhânToolStripMenuItem.Text = "Tổng hợp số lượng BN theo BS chỉ định ";
            this.tổngHợpSốLượngBệnhNhânToolStripMenuItem.Click += new System.EventHandler(this.tổngHợpSốLượngBệnhNhânToolStripMenuItem_Click);
            // 
            // toolStripMenuItem28
            // 
            this.toolStripMenuItem28.Name = "toolStripMenuItem28";
            this.toolStripMenuItem28.Size = new System.Drawing.Size(431, 6);
            // 
            // thốngKêDanhSáchBệnhNhânTheoKhoaThựcHiệnToolStripMenuItem
            // 
            this.thốngKêDanhSáchBệnhNhânTheoKhoaThựcHiệnToolStripMenuItem.Name = "thốngKêDanhSáchBệnhNhânTheoKhoaThựcHiệnToolStripMenuItem";
            this.thốngKêDanhSáchBệnhNhânTheoKhoaThựcHiệnToolStripMenuItem.Size = new System.Drawing.Size(434, 22);
            this.thốngKêDanhSáchBệnhNhânTheoKhoaThựcHiệnToolStripMenuItem.Text = "Thống kê danh sách bệnh nhân theo khoa thực hiện";
            this.thốngKêDanhSáchBệnhNhânTheoKhoaThựcHiệnToolStripMenuItem.Click += new System.EventHandler(this.thốngKêDanhSáchBệnhNhânTheoKhoaThựcHiệnToolStripMenuItem_Click);
            // 
            // tổngHợpSốLượngBNTheoKhoaThựcHiệnToolStripMenuItem
            // 
            this.tổngHợpSốLượngBNTheoKhoaThựcHiệnToolStripMenuItem.Name = "tổngHợpSốLượngBNTheoKhoaThựcHiệnToolStripMenuItem";
            this.tổngHợpSốLượngBNTheoKhoaThựcHiệnToolStripMenuItem.Size = new System.Drawing.Size(434, 22);
            this.tổngHợpSốLượngBNTheoKhoaThựcHiệnToolStripMenuItem.Text = "Tổng hợp số lượng BN theo khoa thực hiện";
            this.tổngHợpSốLượngBNTheoKhoaThựcHiệnToolStripMenuItem.Click += new System.EventHandler(this.tổngHợpSốLượngBNTheoKhoaThựcHiệnToolStripMenuItem_Click);
            // 
            // danhSáchBệnhNhânPhẫuThuậtToolStripMenuItem
            // 
            this.danhSáchBệnhNhânPhẫuThuậtToolStripMenuItem.Name = "danhSáchBệnhNhânPhẫuThuậtToolStripMenuItem";
            this.danhSáchBệnhNhânPhẫuThuậtToolStripMenuItem.Size = new System.Drawing.Size(434, 22);
            this.danhSáchBệnhNhânPhẫuThuậtToolStripMenuItem.Text = "Danh sách bệnh nhân phẫu thuật";
            this.danhSáchBệnhNhânPhẫuThuậtToolStripMenuItem.Click += new System.EventHandler(this.danhSáchBệnhNhânPhẫuThuậtToolStripMenuItem_Click);
            // 
            // bảngKêSốCaLàmPhẫuThuậtTheoThờiGianThanhToánToolStripMenuItem
            // 
            this.bảngKêSốCaLàmPhẫuThuậtTheoThờiGianThanhToánToolStripMenuItem.Name = "bảngKêSốCaLàmPhẫuThuậtTheoThờiGianThanhToánToolStripMenuItem";
            this.bảngKêSốCaLàmPhẫuThuậtTheoThờiGianThanhToánToolStripMenuItem.Size = new System.Drawing.Size(434, 22);
            this.bảngKêSốCaLàmPhẫuThuậtTheoThờiGianThanhToánToolStripMenuItem.Text = "Bảng kê số ca làm Phẫu  thuật (Theo thời gian thanh toán)";
            this.bảngKêSốCaLàmPhẫuThuậtTheoThờiGianThanhToánToolStripMenuItem.Click += new System.EventHandler(this.bảngKêSốCaLàmPhẫuThuậtTheoThờiGianThanhToánToolStripMenuItem_Click);
            // 
            // toolStripMenuItem45
            // 
            this.toolStripMenuItem45.Name = "toolStripMenuItem45";
            this.toolStripMenuItem45.Size = new System.Drawing.Size(434, 22);
            this.toolStripMenuItem45.Text = "Bảng thanh toán tiền Phẫu thuật (Theo thời gian thanh toán)";
            this.toolStripMenuItem45.Click += new System.EventHandler(this.toolStripMenuItem45_Click);
            // 
            // toolStripMenuItem31
            // 
            this.toolStripMenuItem31.Name = "toolStripMenuItem31";
            this.toolStripMenuItem31.Size = new System.Drawing.Size(348, 6);
            // 
            // tổngHợpLoạiBệnhÁnToolStripMenuItem
            // 
            this.tổngHợpLoạiBệnhÁnToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thốngKêDanhSáchBNTheoLoạiBệnhÁnToolStripMenuItem});
            this.tổngHợpLoạiBệnhÁnToolStripMenuItem.Name = "tổngHợpLoạiBệnhÁnToolStripMenuItem";
            this.tổngHợpLoạiBệnhÁnToolStripMenuItem.Size = new System.Drawing.Size(351, 22);
            this.tổngHợpLoạiBệnhÁnToolStripMenuItem.Text = "Tổng hợp loại bệnh án";
            // 
            // thốngKêDanhSáchBNTheoLoạiBệnhÁnToolStripMenuItem
            // 
            this.thốngKêDanhSáchBNTheoLoạiBệnhÁnToolStripMenuItem.Name = "thốngKêDanhSáchBNTheoLoạiBệnhÁnToolStripMenuItem";
            this.thốngKêDanhSáchBNTheoLoạiBệnhÁnToolStripMenuItem.Size = new System.Drawing.Size(294, 22);
            this.thốngKêDanhSáchBNTheoLoạiBệnhÁnToolStripMenuItem.Text = "Thống kê danh sách BN theo loại bệnh án";
            this.thốngKêDanhSáchBNTheoLoạiBệnhÁnToolStripMenuItem.Click += new System.EventHandler(this.thốngKêDanhSáchBNTheoLoạiBệnhÁnToolStripMenuItem_Click);
            // 
            // toolStripMenuItem33
            // 
            this.toolStripMenuItem33.Name = "toolStripMenuItem33";
            this.toolStripMenuItem33.Size = new System.Drawing.Size(348, 6);
            // 
            // sổTổngHợpDuyệtPhiếuChỉĐịnhToolStripMenuItem
            // 
            this.sổTổngHợpDuyệtPhiếuChỉĐịnhToolStripMenuItem.Name = "sổTổngHợpDuyệtPhiếuChỉĐịnhToolStripMenuItem";
            this.sổTổngHợpDuyệtPhiếuChỉĐịnhToolStripMenuItem.Size = new System.Drawing.Size(351, 22);
            this.sổTổngHợpDuyệtPhiếuChỉĐịnhToolStripMenuItem.Text = "Sổ tổng hợp duyệt phiếu chỉ định";
            this.sổTổngHợpDuyệtPhiếuChỉĐịnhToolStripMenuItem.Click += new System.EventHandler(this.sổTổngHợpDuyệtPhiếuChỉĐịnhToolStripMenuItem_Click);
            // 
            // danhMụcToolStripMenuItem
            // 
            this.danhMụcToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.danhMụcBuồngGiườngToolStripMenuItem,
            this.danhMụcPhẩuThuậtToolStripMenuItem,
            this.danhMụcBácSỹToolStripMenuItem,
            this.danhMụcNhómToolStripMenuItem,
            this.danhMụcĐồVảiToolStripMenuItem});
            this.danhMụcToolStripMenuItem.Name = "danhMụcToolStripMenuItem";
            this.danhMụcToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.danhMụcToolStripMenuItem.Text = "Danh mục";
            // 
            // danhMụcBuồngGiườngToolStripMenuItem
            // 
            this.danhMụcBuồngGiườngToolStripMenuItem.Name = "danhMụcBuồngGiườngToolStripMenuItem";
            this.danhMụcBuồngGiườngToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.danhMụcBuồngGiườngToolStripMenuItem.Text = "Danh mục buồng, giường";
            this.danhMụcBuồngGiườngToolStripMenuItem.Click += new System.EventHandler(this.danhMụcBuồngGiườngToolStripMenuItem_Click);
            // 
            // danhMụcPhẩuThuậtToolStripMenuItem
            // 
            this.danhMụcPhẩuThuậtToolStripMenuItem.Name = "danhMụcPhẩuThuậtToolStripMenuItem";
            this.danhMụcPhẩuThuậtToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.danhMụcPhẩuThuậtToolStripMenuItem.Text = "Danh mục phẫu thuật";
            this.danhMụcPhẩuThuậtToolStripMenuItem.Click += new System.EventHandler(this.danhMụcPhẩuThuậtToolStripMenuItem_Click);
            // 
            // danhMụcBácSỹToolStripMenuItem
            // 
            this.danhMụcBácSỹToolStripMenuItem.Name = "danhMụcBácSỹToolStripMenuItem";
            this.danhMụcBácSỹToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.danhMụcBácSỹToolStripMenuItem.Text = "Danh mục nhân viên";
            this.danhMụcBácSỹToolStripMenuItem.Click += new System.EventHandler(this.danhMụcBácSỹToolStripMenuItem_Click);
            // 
            // danhMụcNhómToolStripMenuItem
            // 
            this.danhMụcNhómToolStripMenuItem.Name = "danhMụcNhómToolStripMenuItem";
            this.danhMụcNhómToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.danhMụcNhómToolStripMenuItem.Text = "Danh mục nhóm";
            this.danhMụcNhómToolStripMenuItem.Click += new System.EventHandler(this.danhMụcNhómToolStripMenuItem_Click);
            // 
            // danhMụcĐồVảiToolStripMenuItem
            // 
            this.danhMụcĐồVảiToolStripMenuItem.Name = "danhMụcĐồVảiToolStripMenuItem";
            this.danhMụcĐồVảiToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.danhMụcĐồVảiToolStripMenuItem.Text = "Danh mục đồ vải";
            this.danhMụcĐồVảiToolStripMenuItem.Click += new System.EventHandler(this.danhMụcĐồVảiToolStripMenuItem_Click);
            // 
            // quảnLýVTTHToolStripMenuItem
            // 
            this.quảnLýVTTHToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nhậpTồnĐầuKỳToolStripMenuItem,
            this.nhậnVTTHTừPhòngVậtTưToolStripMenuItem,
            this.xácNhậnSửDụngTạiKhoaToolStripMenuItem,
            this.danhSáchPhiếuNhậnPhiếuSửDụngToolStripMenuItem,
            this.báoCáoSửDụngTạiKhoaToolStripMenuItem});
            this.quảnLýVTTHToolStripMenuItem.Name = "quảnLýVTTHToolStripMenuItem";
            this.quảnLýVTTHToolStripMenuItem.Size = new System.Drawing.Size(91, 20);
            this.quảnLýVTTHToolStripMenuItem.Text = "Quản lý VTTH";
            // 
            // nhậpTồnĐầuKỳToolStripMenuItem
            // 
            this.nhậpTồnĐầuKỳToolStripMenuItem.Name = "nhậpTồnĐầuKỳToolStripMenuItem";
            this.nhậpTồnĐầuKỳToolStripMenuItem.Size = new System.Drawing.Size(274, 22);
            this.nhậpTồnĐầuKỳToolStripMenuItem.Text = "Nhập tồn đầu kỳ";
            this.nhậpTồnĐầuKỳToolStripMenuItem.Click += new System.EventHandler(this.nhậpTồnĐầuKỳToolStripMenuItem_Click);
            // 
            // nhậnVTTHTừPhòngVậtTưToolStripMenuItem
            // 
            this.nhậnVTTHTừPhòngVậtTưToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nhậpTừPhiếuXuấtCủaPhòngVTDượcToolStripMenuItem,
            this.nhậpTạmKhiChưaCóPhiếuXuấtToolStripMenuItem,
            this.mnuChuyenDoiVTTH});
            this.nhậnVTTHTừPhòngVậtTưToolStripMenuItem.Name = "nhậnVTTHTừPhòngVậtTưToolStripMenuItem";
            this.nhậnVTTHTừPhòngVậtTưToolStripMenuItem.Size = new System.Drawing.Size(274, 22);
            this.nhậnVTTHTừPhòngVậtTưToolStripMenuItem.Text = "Nhận VTTH về khoa";
            this.nhậnVTTHTừPhòngVậtTưToolStripMenuItem.Click += new System.EventHandler(this.nhậnVTTHTừPhòngVậtTưToolStripMenuItem_Click);
            // 
            // nhậpTừPhiếuXuấtCủaPhòngVTDượcToolStripMenuItem
            // 
            this.nhậpTừPhiếuXuấtCủaPhòngVTDượcToolStripMenuItem.Name = "nhậpTừPhiếuXuấtCủaPhòngVTDượcToolStripMenuItem";
            this.nhậpTừPhiếuXuấtCủaPhòngVTDượcToolStripMenuItem.Size = new System.Drawing.Size(286, 22);
            this.nhậpTừPhiếuXuấtCủaPhòngVTDượcToolStripMenuItem.Text = "Nhập từ phiếu xuất của phòng VT, Dược";
            this.nhậpTừPhiếuXuấtCủaPhòngVTDượcToolStripMenuItem.Click += new System.EventHandler(this.nhậpTừPhiếuXuấtCủaPhòngVTDượcToolStripMenuItem_Click);
            // 
            // nhậpTạmKhiChưaCóPhiếuXuấtToolStripMenuItem
            // 
            this.nhậpTạmKhiChưaCóPhiếuXuấtToolStripMenuItem.Name = "nhậpTạmKhiChưaCóPhiếuXuấtToolStripMenuItem";
            this.nhậpTạmKhiChưaCóPhiếuXuấtToolStripMenuItem.Size = new System.Drawing.Size(286, 22);
            this.nhậpTạmKhiChưaCóPhiếuXuấtToolStripMenuItem.Text = "Nhập tạm khi chưa có phiếu xuất";
            this.nhậpTạmKhiChưaCóPhiếuXuấtToolStripMenuItem.Click += new System.EventHandler(this.nhậpTạmKhiChưaCóPhiếuXuấtToolStripMenuItem_Click);
            // 
            // mnuChuyenDoiVTTH
            // 
            this.mnuChuyenDoiVTTH.Name = "mnuChuyenDoiVTTH";
            this.mnuChuyenDoiVTTH.Size = new System.Drawing.Size(286, 22);
            this.mnuChuyenDoiVTTH.Text = "Chuyển đổi VTTH";
            this.mnuChuyenDoiVTTH.Click += new System.EventHandler(this.mnuChuyenDoiVTTH_Click);
            // 
            // xácNhậnSửDụngTạiKhoaToolStripMenuItem
            // 
            this.xácNhậnSửDụngTạiKhoaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vTTHTrongChỉĐịnhToolStripMenuItem,
            this.vTTHDùngChungToolStripMenuItem});
            this.xácNhậnSửDụngTạiKhoaToolStripMenuItem.Name = "xácNhậnSửDụngTạiKhoaToolStripMenuItem";
            this.xácNhậnSửDụngTạiKhoaToolStripMenuItem.Size = new System.Drawing.Size(274, 22);
            this.xácNhậnSửDụngTạiKhoaToolStripMenuItem.Text = "Sử dụng tại khoa";
            // 
            // vTTHTrongChỉĐịnhToolStripMenuItem
            // 
            this.vTTHTrongChỉĐịnhToolStripMenuItem.Name = "vTTHTrongChỉĐịnhToolStripMenuItem";
            this.vTTHTrongChỉĐịnhToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.vTTHTrongChỉĐịnhToolStripMenuItem.Text = "VTTH trong chỉ định";
            this.vTTHTrongChỉĐịnhToolStripMenuItem.Click += new System.EventHandler(this.vTTHTrongChỉĐịnhToolStripMenuItem_Click);
            // 
            // vTTHDùngChungToolStripMenuItem
            // 
            this.vTTHDùngChungToolStripMenuItem.Name = "vTTHDùngChungToolStripMenuItem";
            this.vTTHDùngChungToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.vTTHDùngChungToolStripMenuItem.Text = "VTTH dùng chung";
            this.vTTHDùngChungToolStripMenuItem.Click += new System.EventHandler(this.vTTHDùngChungToolStripMenuItem_Click);
            // 
            // danhSáchPhiếuNhậnPhiếuSửDụngToolStripMenuItem
            // 
            this.danhSáchPhiếuNhậnPhiếuSửDụngToolStripMenuItem.Name = "danhSáchPhiếuNhậnPhiếuSửDụngToolStripMenuItem";
            this.danhSáchPhiếuNhậnPhiếuSửDụngToolStripMenuItem.Size = new System.Drawing.Size(274, 22);
            this.danhSáchPhiếuNhậnPhiếuSửDụngToolStripMenuItem.Text = "Danh sách phiếu nhận, phiếu sử dụng";
            this.danhSáchPhiếuNhậnPhiếuSửDụngToolStripMenuItem.Click += new System.EventHandler(this.danhSáchPhiếuNhậnPhiếuSửDụngToolStripMenuItem_Click);
            // 
            // báoCáoSửDụngTạiKhoaToolStripMenuItem
            // 
            this.báoCáoSửDụngTạiKhoaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.báoCáoSửDụngTạiKhoaToolStripMenuItem1,
            this.theoiDõiVTTHToolStripMenuItem});
            this.báoCáoSửDụngTạiKhoaToolStripMenuItem.Name = "báoCáoSửDụngTạiKhoaToolStripMenuItem";
            this.báoCáoSửDụngTạiKhoaToolStripMenuItem.Size = new System.Drawing.Size(274, 22);
            this.báoCáoSửDụngTạiKhoaToolStripMenuItem.Text = "Báo cáo";
            this.báoCáoSửDụngTạiKhoaToolStripMenuItem.Click += new System.EventHandler(this.báoCáoSửDụngTạiKhoaToolStripMenuItem_Click);
            // 
            // báoCáoSửDụngTạiKhoaToolStripMenuItem1
            // 
            this.báoCáoSửDụngTạiKhoaToolStripMenuItem1.Name = "báoCáoSửDụngTạiKhoaToolStripMenuItem1";
            this.báoCáoSửDụngTạiKhoaToolStripMenuItem1.Size = new System.Drawing.Size(207, 22);
            this.báoCáoSửDụngTạiKhoaToolStripMenuItem1.Text = "Báo cáo sử dụng tại khoa";
            this.báoCáoSửDụngTạiKhoaToolStripMenuItem1.Click += new System.EventHandler(this.báoCáoSửDụngTạiKhoaToolStripMenuItem1_Click);
            // 
            // theoiDõiVTTHToolStripMenuItem
            // 
            this.theoiDõiVTTHToolStripMenuItem.Name = "theoiDõiVTTHToolStripMenuItem";
            this.theoiDõiVTTHToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.theoiDõiVTTHToolStripMenuItem.Text = "Theoi dõi VTTH";
            this.theoiDõiVTTHToolStripMenuItem.Click += new System.EventHandler(this.theoiDõiVTTHToolStripMenuItem_Click);
            // 
            // trợGiúpToolStripMenuItem
            // 
            this.trợGiúpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hướngDẫnDựTrùVậtTưTiêuHaoToolStripMenuItem,
            this.mnuChotSoSach,
            this.mnuThietLapNhomInVTTH,
            this.hướngDẫnXemBáoCáoTổngHợpVTTHToolStripMenuItem,
            this.báoCáoỨngToolStripMenuItem});
            this.trợGiúpToolStripMenuItem.Name = "trợGiúpToolStripMenuItem";
            this.trợGiúpToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.trợGiúpToolStripMenuItem.Tag = "1";
            this.trợGiúpToolStripMenuItem.Text = "Trợ giúp";
            // 
            // hướngDẫnDựTrùVậtTưTiêuHaoToolStripMenuItem
            // 
            this.hướngDẫnDựTrùVậtTưTiêuHaoToolStripMenuItem.Name = "hướngDẫnDựTrùVậtTưTiêuHaoToolStripMenuItem";
            this.hướngDẫnDựTrùVậtTưTiêuHaoToolStripMenuItem.Size = new System.Drawing.Size(288, 22);
            this.hướngDẫnDựTrùVậtTưTiêuHaoToolStripMenuItem.Tag = "1";
            this.hướngDẫnDựTrùVậtTưTiêuHaoToolStripMenuItem.Text = "Hướng dẫn dự trù VTTH";
            this.hướngDẫnDựTrùVậtTưTiêuHaoToolStripMenuItem.Click += new System.EventHandler(this.hướngDẫnDựTrùVậtTưTiêuHaoToolStripMenuItem_Click);
            // 
            // mnuChotSoSach
            // 
            this.mnuChotSoSach.Name = "mnuChotSoSach";
            this.mnuChotSoSach.Size = new System.Drawing.Size(288, 22);
            this.mnuChotSoSach.Tag = "1";
            this.mnuChotSoSach.Text = "Chức năng chốt VTTH";
            this.mnuChotSoSach.Click += new System.EventHandler(this.mnuChotSoSach_Click);
            // 
            // mnuThietLapNhomInVTTH
            // 
            this.mnuThietLapNhomInVTTH.Name = "mnuThietLapNhomInVTTH";
            this.mnuThietLapNhomInVTTH.Size = new System.Drawing.Size(288, 22);
            this.mnuThietLapNhomInVTTH.Tag = "1";
            this.mnuThietLapNhomInVTTH.Text = "Thiết lập nhóm in trong phiếu lĩnh VTTH";
            this.mnuThietLapNhomInVTTH.Click += new System.EventHandler(this.mnuThietLapNhomInVTTH_Click);
            // 
            // hướngDẫnXemBáoCáoTổngHợpVTTHToolStripMenuItem
            // 
            this.hướngDẫnXemBáoCáoTổngHợpVTTHToolStripMenuItem.Name = "hướngDẫnXemBáoCáoTổngHợpVTTHToolStripMenuItem";
            this.hướngDẫnXemBáoCáoTổngHợpVTTHToolStripMenuItem.Size = new System.Drawing.Size(288, 22);
            this.hướngDẫnXemBáoCáoTổngHợpVTTHToolStripMenuItem.Tag = "1";
            this.hướngDẫnXemBáoCáoTổngHợpVTTHToolStripMenuItem.Text = "Hướng dẫn xem báo cáo tổng hợp VTTH";
            this.hướngDẫnXemBáoCáoTổngHợpVTTHToolStripMenuItem.Click += new System.EventHandler(this.hướngDẫnXemBáoCáoTổngHợpVTTHToolStripMenuItem_Click);
            // 
            // báoCáoỨngToolStripMenuItem
            // 
            this.báoCáoỨngToolStripMenuItem.Name = "báoCáoỨngToolStripMenuItem";
            this.báoCáoỨngToolStripMenuItem.Size = new System.Drawing.Size(288, 22);
            this.báoCáoỨngToolStripMenuItem.Text = "Đánh giá ứng dụng CNTT ";
            this.báoCáoỨngToolStripMenuItem.Click += new System.EventHandler(this.báoCáoỨngToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txtNgayLV,
            this.txtNguoiDung,
            this.txtPhienBan});
            this.statusStrip1.Location = new System.Drawing.Point(0, 663);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(913, 22);
            this.statusStrip1.TabIndex = 13;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // txtNgayLV
            // 
            this.txtNgayLV.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.txtNgayLV.Name = "txtNgayLV";
            this.txtNgayLV.Size = new System.Drawing.Size(0, 17);
            // 
            // txtNguoiDung
            // 
            this.txtNguoiDung.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedOuter;
            this.txtNguoiDung.Name = "txtNguoiDung";
            this.txtNguoiDung.Size = new System.Drawing.Size(0, 17);
            // 
            // txtPhienBan
            // 
            this.txtPhienBan.Name = "txtPhienBan";
            this.txtPhienBan.Size = new System.Drawing.Size(118, 17);
            this.txtPhienBan.Text = "toolStripStatusLabel3";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(77, 36);
            this.toolStripLabel1.Text = "Họ và tên BN";
            // 
            // toolTimBN
            // 
            this.toolTimBN.Name = "toolTimBN";
            this.toolTimBN.Size = new System.Drawing.Size(170, 39);
            this.toolTimBN.KeyUp += new System.Windows.Forms.KeyEventHandler(this.toolTimBN_KeyUp);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripSeparator1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripSeparator2,
            this.toolStripLabel1,
            this.toolTimBN,
            this.toolStripSeparator3,
            this.toolStripButton5,
            this.toolStripButton7,
            this.toolStripButton8});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(913, 39);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton1.Text = "Thoát khỏi chương trình";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton2.Text = "Thông tin bệnh nhân";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton3.Text = "Thông tin điều trị";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton4.Text = "Bệnh nhân ra viện";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton5.Text = "Tìm bệnh nhân";
            this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton7.Image")));
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(137, 36);
            this.toolStripButton7.Text = "Lịch Sử KCB BHYT";
            // 
            // toolStripButton8
            // 
            this.toolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton8.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton8.Image")));
            this.toolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton8.Name = "toolStripButton8";
            this.toolStripButton8.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton8.Text = "TT54";
            this.toolStripButton8.Click += new System.EventHandler(this.toolStripButton8_Click_1);
            // 
            // timer1
            // 
            this.timer1.Interval = 120000;
            // 
            // frmMain
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(913, 685);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HelpButton = true;
            this.helpProvider1.SetHelpKeyword(this, "Main");
            this.helpProvider1.SetHelpString(this, "Main");
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.helpProvider1.SetShowHelp(this, true);
            this.Text = "Quản lý bệnh nhân nội trú";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Closed += new System.EventHandler(this.frmMain_Closed);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
        {           
            string[] SwitchKeys ={ "/srv", "/usr", "/pas", "/day" };
            string[] CommandLines = System.Environment.CommandLine.Split(SwitchKeys, StringSplitOptions.None);
            if (CommandLines.Length < 5)
            {
                MessageBox.Show("Sai tham số khởi tạo chương trình", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //MessageBox.Show(CommandLines[0].ToString() + "\n" + CommandLines[1].ToString() + "\n" + CommandLines[2].ToString() + "\n" + CommandLines[3].ToString() + "\n" + CommandLines[4].ToString());
            Application.EnableVisualStyles();
            Application.CurrentCulture = new System.Globalization.CultureInfo("vi-VN", false);
            Global.glbServerName = CommandLines[1].Trim();
            Global.glbUName = CommandLines[2].Trim();
            //password = CommandLines[3];
            Global.NgayLV = DateTime.Parse(CommandLines[4]);
            Application.Run(new frmMain());
		}

		private void frmMain_Load(object sender, System.EventArgs e)
		{
			foreach (System.Windows.Forms.ToolStripMenuItem mnu in this.menuStrip1.Items)
			{
                foreach (object FuncItem in mnu.DropDownItems)
                {
                    if (FuncItem.GetType() != typeof(ToolStripSeparator) )
                    {
                        if(((ToolStripMenuItem)FuncItem).Tag != null && ((ToolStripMenuItem)FuncItem).Tag.ToString() == "1")
                        ((ToolStripMenuItem)FuncItem).Enabled = true;
                    else ((ToolStripMenuItem)FuncItem).Enabled = false;
                    }
                     
                }
			}
            //Dim sL
            //MessageBox.Show("MAU_0001".Contains("MAU_0001g").ToString());
            Init_Application();
            Global.pWork = new NamDinh_QLBN.Forms.Tien_ich.WorkSpace(this);
            Global.pWork.Show();
            //this.helpProvider1.HelpNamespace = Application.StartupPath + "\\HDSD.CHM";
            Global.NgayLV = Global.GetNgayLV();
		}

        		
		private void dlgSave_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
		{			
			Application.DoEvents();
			System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
			string BKFileName =dlgSave.FileName;
			if (BKFileName != "")
			{
				try
				{    
					Global.wait("Đang sao lưu dữ liệu.... File " + BKFileName);
					
					cmd.Connection = Global.ConnectSQL;
					cmd.CommandText = "BACKUP DATABASE [NamDinh_QLBN] " 
									+ " TO DISK = '" + BKFileName + "' WITH INIT," 
									+ "RETAINDAYS=7";
					cmd.ExecuteNonQuery();
					Global.nowait();
					MessageBox.Show("Sao lưu dữ liệu thành công!", "Sao l­u d÷ liÖu",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);					
					cmd.Dispose();
				}
				catch (Exception er)
				{
					MessageBox.Show("Có lỗi khi sao lưu file dữ liệu\n" + er.Message ,"Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
				}			
			}
		}

		

		private void ToolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			if (e.Equals(null)) {return;}
			switch (e.Button.Tag.ToString())
			{
				case "Q":
				{
					Application.Exit();
					break;
				}
				case "N":
				{					
					break;
				}
				case "I":
				{ 					
					break;
				}
				case "C":
				{					
					break;
				}
			}
		}
		

		private void frmMain_Closed(object sender, System.EventArgs e)
		{
			try
			{
				GlobalModuls.Global.ConnectSQL.Close();
				GlobalModuls.Global.ConnectSQL.Dispose();				
			}
			catch 
			{

			}

		}

		private void mnuBackup_Click(object sender, System.EventArgs e)
		{
			dlgSave.Filter = "Backup file|*.BAK";
			dlgSave.ShowDialog();
		}
        

		private void mnuLogOff_Click(object sender, System.EventArgs e)
		{
			if (Global.ConnectSQL.State ==System.Data.ConnectionState.Open)
			{
				Global.ConnectSQL.Close();				
			}			
            foreach (System.Windows.Forms.ToolStripMenuItem mnu in this.menuStrip1.Items)
            {
                foreach (object FuncItem in mnu.DropDownItems)
                {
                    if (FuncItem.GetType() != typeof(ToolStripSeparator)) { ((ToolStripMenuItem)FuncItem).Enabled = false; }
                }
            }
			mnuLogOff.Enabled  = true;
			mnuLogOn.Enabled =true;		
			mnuLogOff.Visible =false;
			mnuLogOn.Visible=true;
			mnuThoat.Enabled = true;
		}

		private void mnuLogOn_Click(object sender, System.EventArgs e)
		{
			Forms.frmLogIn fr;			
			fr=new Forms.frmLogIn(this);			
			fr.mnuLogOn = mnuLogOn;
			fr.mnuLogOff = mnuLogOff;
			fr.mnuThoat = mnuThoat;
			fr.Menus = this.menuStrip1;
            fr.stripLabel1 = this.txtNgayLV;
            fr.stripLabel2 = this.txtNguoiDung;
			fr.Show();
            DaleteFrom(fr);
		}

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        private void bệnhNhânVàoViệnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.DuLieu.frmTiepNhanBenhNhan fr = new NamDinh_QLBN.Forms.DuLieu.frmTiepNhanBenhNhan();
            fr.MdiParent = this;
            fr.Show();
            fr.WindowState = FormWindowState.Maximized;
            DaleteFrom(fr);
        }
        private void DaleteFrom(Form frm)
        {
            foreach (Form f in this.MdiChildren)
            {
                if(f != frm && f != Global.pWork)
                {
                    f.Close();
                }
            }
        }
        private void DeleteChildFrom()
        {
            foreach (Form f in this.MdiChildren)
            {
                f.Close();
            }
        }
        private void cậpNhậtThôngTinĐiềuTrịToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //NamDinh_QLBN.Forms.DuLieu.frmBenhNhanNoiTru fr = new NamDinh_QLBN.Forms.DuLieu.frmBenhNhanNoiTru("","");
            NamDinh_QLBN.Forms.DuLieu.frmChiDinhDieuTri fr = new NamDinh_QLBN.Forms.DuLieu.frmChiDinhDieuTri();
            fr.MdiParent = this;
            fr.Show();
            fr.WindowState = FormWindowState.Maximized;
            DaleteFrom(fr);
        }

        private void bệnhNhânRaViệnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.DuLieu.frmBenhNhanRaVien fr = new NamDinh_QLBN.Forms.DuLieu.frmBenhNhanRaVien();
            fr.MdiParent = this;
            fr.Show();
            fr.WindowState = FormWindowState.Maximized;
            DaleteFrom(fr);
        }

        private void tìmKiếmBệnhNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.DuLieu.frmTimKiem fr = new NamDinh_QLBN.Forms.DuLieu.frmTimKiem("");            
            fr.MdiParent = this;            
            fr.Show();
            DaleteFrom(fr);
            //fr.WindowState = FormWindowState.Maximized;
        }

        private void danhMụcBuồngGiườngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.DanhMuc.frmDanhMucBuong_Giuong fr = new NamDinh_QLBN.Forms.DanhMuc.frmDanhMucBuong_Giuong();
            fr.MdiParent = this;
            fr.Show();
            DaleteFrom(fr);
        }

        private void thốngKêHiệnTrạngBuồngGiườngĐiềutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.Tien_ich.frmQuanLy_BuongGiuong fr = new NamDinh_QLBN.Forms.Tien_ich.frmQuanLy_BuongGiuong();
            fr.MdiParent = this;
            fr.Show();
            fr.WindowState = FormWindowState.Maximized;
        }

        private void bệnhNhânChuyểnKhoaChuyểnDiệnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.DuLieu.frmXacNhanPhauThuat fr = new NamDinh_QLBN.Forms.DuLieu.frmXacNhanPhauThuat();
            fr.MdiParent = this;
            fr.Show();
        }

        private void chiPhíĐiềuTrịNộiTrúToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.In.frmPhieuTT_DTNT fr = new NamDinh_QLBN.Forms.In.frmPhieuTT_DTNT();
            fr.MdiParent = this;
            fr.WindowState = FormWindowState.Maximized;
            fr.Show();
        }

        private void danhSáchBệnhNhânTạiCácKhoaToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (Global.ConnectSQL==null || Global.ConnectSQL.State != ConnectionState.Open)
            {
                MessageBox.Show("Chưa kết nối cơ sở dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            NamDinh_QLBN.Forms.DuLieu.frmTiepNhanBenhNhan fr = new NamDinh_QLBN.Forms.DuLieu.frmTiepNhanBenhNhan();
            fr.MdiParent = this;
            fr.Show();
            fr.WindowState = FormWindowState.Maximized;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (Global.ConnectSQL == null || Global.ConnectSQL.State != ConnectionState.Open)
            {
                MessageBox.Show("Chưa kết nối cơ sở dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            NamDinh_QLBN.Forms.DuLieu.frmChiDinhDieuTri fr = new NamDinh_QLBN.Forms.DuLieu.frmChiDinhDieuTri();
            fr.MdiParent = this;
            fr.Show();
            fr.WindowState = FormWindowState.Maximized;
        }

        private void toolTimBN_KeyUp(object sender, KeyEventArgs e)
        {
            if (Global.ConnectSQL == null || Global.ConnectSQL.State != ConnectionState.Open)
            {
                MessageBox.Show("Chưa kết nối cơ sở dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (e.KeyCode == Keys.Enter)
            {
                System.Data.SqlClient.SqlDataReader dr;
                System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
                SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
                SQLCmd.CommandText = "SELECT BENHNHAN_CHITIET.MaBenhNhan,BENHNHAN_CHITIET.LanVaoVien FROM BENHNHAN_CHITIET INNER JOIN BENHNHAN ON BENHNHAN_CHITIET.MaBenhNhan=BENHNHAN.MaBenhNhan WHERE DaRaVien=0 AND HoTen Like N'%" + toolTimBN.Text + "%'";
                dr = SQLCmd.ExecuteReader();
                string MaBenhNhan = "";
                string LanVaoVien = "";
                while (dr.Read())
                {
                    MaBenhNhan = dr["MaBenhNhan"].ToString();
                    LanVaoVien = dr["LanVaoVien"].ToString();
                }
                dr.Close();
                SQLCmd.Dispose();
                if (MaBenhNhan == "")
                {
                    MessageBox.Show("Không tìm thấy bệnh nhân!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                NamDinh_QLBN.Forms.DuLieu.frmBenhNhanNoiTru fr = new NamDinh_QLBN.Forms.DuLieu.frmBenhNhanNoiTru(MaBenhNhan,LanVaoVien);
                fr.MdiParent = this;
                fr.Show();
                fr.WindowState = FormWindowState.Maximized;
            }
        }

        private void lậpHồSơBệnhÁnCủaBệnhNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ////NamDinh_QLBN.Forms.DuLieu.frmLapHSBA fr = new NamDinh_QLBN.Forms.DuLieu.frmLapHSBA();
            //NamDinh_QLBN.Forms.DuLieu.frmNhapChiDinhChiPhi fr = new NamDinh_QLBN.Forms.DuLieu.frmNhapChiDinhChiPhi();
            //fr.MdiParent = this;
            //fr.Show();
        }

        private void tùyChọnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //NamDinh_QLBN.Forms.Tien_ich.frmConfig fr = new NamDinh_QLBN.Forms.Tien_ich.frmConfig();
            //fr.MdiParent = this;
            //fr.Show();
            NamDinh_QLBN.Forms.Tien_ich.frmDatChiPhi_Khoa fr = new NamDinh_QLBN.Forms.Tien_ich.frmDatChiPhi_Khoa();
            fr.MdiParent = this;
            fr.Show();
        }
        private void mnuChangePass_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.HeThong.frmChangePass fr = new NamDinh_QLBN.Forms.HeThong.frmChangePass();
            fr.ShowDialog();
        }

        private void danhSáchBệnhNhânVàoViệnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.Tien_ich.frmTNgayDNgay frm = new NamDinh_QLBN.Forms.Tien_ich.frmTNgayDNgay();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                NamDinh_QLBN.Reports.BaoCaoNoiTru.repDSBNNhapVien rep = new NamDinh_QLBN.Reports.BaoCaoNoiTru.repDSBNNhapVien(frm._TNgay, frm._DNgay, frm._MaKhoa,frm._TenKhoa);
                rep.Show();
                return;
            }
        }
        private int   Init_Application()
        {
            try
            {
                //MessageBox.Show( string.Format("{0:#,#}", 123334));
                Global.ConnectSQL = new System.Data.SqlClient.SqlConnection();
                //Global.ConnectSQL.ConnectionString = string.Format("Data Source={0};Initial Catalog=NamDinh_QLBN; User ID=sa; Password=vcntt@2007", Global.glbServerName);//
                //Global.ConnectSQL.ConnectionString = string.Format("Data Source={0};Initial Catalog=NamDinh_QLBN; User ID=sa; Password=vcntt@2007", Global.glbServerName);
                Global.glbConnectionString = string.Format("Data Source={0};Initial Catalog=NamDinh_QLBN; User ID=Admin_HIS; Password=vcntt@2020", Global.glbServerName);
                Global.ConnectSQL.ConnectionString = GlobalModuls.Global.glbConnectionString;
                Global.ConnectSQL.Open();
                System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
                SQLCmd.Connection = Global.ConnectSQL;
                SQLCmd.CommandText = string.Format("SELECT SYSUSER.*,TenKhoa,TenTat,Khoi FROM SYSUSER INNER JOIN DMKHOAPHONG ON MaKhoa=KhoaPhong WHERE UName='{0}'", Global.glbUName);
                System.Data.SqlClient.SqlDataReader dr = SQLCmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    Global.glbMaKhoaPhong = dr["KhoaPhong"].ToString();
                    Global.glbTenKhoaPhong = dr["TenKhoa"].ToString();
                    Global.glbTenTatKhoaPhong = dr["TenTat"].ToString();
                    Global.glbNhom = byte.Parse(dr["Quyen"].ToString());
                    Global.gblNoiNgoai = dr["Khoi"].ToString();

                    this.txtNgayLV.Text = string.Format("Ngày làm việc: {0:dd/MM/yyyy}", Global.NgayLV);
                    this.txtNguoiDung.Text = string.Format("Người sử dụng: {0} - Khoa, Phòng: {1}", Global.glbUName, Global.glbTenTatKhoaPhong);
                }
                dr.Close();
                //
                SQLCmd.CommandText = "select FileVersion from NamDinh_Sysdb.dbo.APPLICATION_FILES where FileName='NamDinh_QLBN.exe' ";
                dr = SQLCmd.ExecuteReader();
                if (dr.Read())
                {
                    this.txtPhienBan.Text = string.Format("Version máy chủ: {0} - Máy trạm: {1}", dr["FileVersion"], System.Reflection.Assembly.GetExecutingAssembly().GetName().Version);
                    this.Tag = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
                    timer1.Start();
                }
                dr.Close();
                //
                SQLCmd.CommandText = "Select TenBS from DMBACSY where MaKhoa = '" + GlobalModuls.Global.glbMaKhoaPhong + "' and MaChucVu = '3' and Khongsudung = 0 ";
                dr = SQLCmd.ExecuteReader();
                if (dr.Read())
                {
                    Global.glbTenTruongKhoa = dr["TenBS"].ToString();
                }
                dr.Close();
                SQLCmd.CommandText = "SELECT * FROM USER_KHOA WHERE UName='" + Global.glbUName + "'";
                dr = SQLCmd.ExecuteReader();
                Global.glbKhoa_CapNhat = "";
                while (dr.Read())
                {
                    Global.glbKhoa_CapNhat += ",'" + dr["MaKhoa"] + "'";
                }
                dr.Close();
                Global.glbKhoa_CapNhat = "(" + Global.glbKhoa_CapNhat.Substring(1) + ")";
                SQLCmd.CommandText = "SELECT USER_FUNCTION.*,FuncText FROM USER_FUNCTION INNER JOIN FUNCTIONS ON USER_FUNCTION.FuncID=FUNCTIONS.FuncID AND USER_FUNCTION.MaCT=FUNCTIONS.MaCT WHERE UName='" + Global.glbUName + "' AND USER_FUNCTION.MaCT='01'";
                dr = SQLCmd.ExecuteReader();
                while (dr.Read())
                {
                    foreach (System.Windows.Forms.ToolStripMenuItem mnu in this.menuStrip1.Items)
                    {
                        foreach (object FuncItem in mnu.DropDownItems)
                        {
                            if (FuncItem.GetType() != typeof(ToolStripSeparator))
                            {
                                if (dr["FuncText"].ToString() == ((ToolStripMenuItem)FuncItem).Text) { ((ToolStripMenuItem)FuncItem).Enabled = true; }
                            }
                        }
                    }
                }
                dr.Close();

                //==================Đoạn này để cập nhật bảng FUNCTIONS trong database==========================================
                //SQLCmd.CommandText = "DELETE FROM NAMDINH_SYSDB.DBO.FUNCTIONS WHERE MaCT='01'";
                //SQLCmd.ExecuteNonQuery();
                //byte MaNhom = 0;
                //byte MaChucNang = 0;
                //foreach (System.Windows.Forms.ToolStripMenuItem mnu in menuStrip1.Items)
                //{
                //    SQLCmd.CommandText = string.Format("INSERT INTO NAMDINH_SYSDB.DBO.FUNCTIONS (FuncID,FuncText,MaCT) VALUES ('{0}{1:00}',N'{2}','01')", MaNhom, MaChucNang, mnu.Text);
                //    SQLCmd.ExecuteNonQuery();
                //    foreach (object FuncItem in mnu.DropDownItems)
                //    {
                //        if (FuncItem.GetType() != typeof(ToolStripSeparator))
                //        {
                //            MaChucNang += 1;
                //            SQLCmd.CommandText = string.Format("INSERT INTO NAMDINH_SYSDB.DBO.FUNCTIONS (FuncID,FuncText,MaCT) VALUES ('{0}{1:00}',N'{2}','01')", MaNhom, MaChucNang, ((ToolStripMenuItem)FuncItem).Text);
                //            SQLCmd.ExecuteNonQuery();
                //        }
                //    }
                //    MaNhom += 1;
                //    MaChucNang = 0;
                //}
                //==============================================================================================================
                SQLCmd.Dispose();

                this.mnuLogOff.Enabled = true;
                this.mnuLogOn.Enabled = true;
                this.mnuLogOff.Visible = true;
                this.mnuLogOn.Visible = false;
                this.mnuThoat.Enabled = true;
                Global.InitApplication(Global.glbUName);
                return 0;
            }
            catch (Exception ex)
            {
                Global.nowait();
                MessageBox.Show(ex.Message, "Lỗi truy cập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Global.ConnectSQL.State == ConnectionState.Closed) return;
            Global.UpdateFile("LoginTHBC.EXE", Global.ConnectSQL);
            if (Global.ConnectSQL.State == ConnectionState.Open) Global.ConnectSQL.Close();
            Global.ConnectSQL.Dispose();
        }

        private void tìmKiếmBệnhNhânToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void thiếtLậpDịchVụYTếTheoKhoaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.Tien_ich.frmDatChiPhi_Khoa fr = new NamDinh_QLBN.Forms.Tien_ich.frmDatChiPhi_Khoa();
            fr.Show();
        }

        private void chiPhíĐiềuTrịNộiTrúToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.In.frmPhieuTT_DTNT frm = new NamDinh_QLBN.Forms.In.frmPhieuTT_DTNT();
            frm.MdiParent = this;
            frm.Show();
            DaleteFrom(frm);
        }

        private void danhSáchBệnhNhânTạiCácKhoaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.Tien_ich.frmTNgayDNgay frm = new NamDinh_QLBN.Forms.Tien_ich.frmTNgayDNgay();
            NamDinh_QLBN.Forms.In.PreviewForm frmBC;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                NamDinh_QLBN.Reports.BaoCaoNoiTru.repDSBNNhapRaVien rep = new NamDinh_QLBN.Reports.BaoCaoNoiTru.repDSBNNhapRaVien(frm._TNgay, frm._DNgay, frm._MaKhoa, frm._TenKhoa);
                rep.Run();
                frmBC = new NamDinh_QLBN.Forms.In.PreviewForm(rep.Document,this);
                frmBC.Show();
                //rep.Show();
                return;
            }
        }

        private void bệnhNhânChuyểnKhoaChuyểnDiệnToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.DuLieu.frmChuyenKhoa_ChuyenDien frm = new NamDinh_QLBN.Forms.DuLieu.frmChuyenKhoa_ChuyenDien();
            frm.MdiParent = this;
            frm.Show();
            frm.WindowState = FormWindowState.Normal;
            DaleteFrom(frm);
        }

        private void danhSáchBệnhNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.DuLieu.frmDanhSachBenhNhan frm = new NamDinh_QLBN.Forms.DuLieu.frmDanhSachBenhNhan();
            frm.MdiParent = this;
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
            DaleteFrom(frm);

        }

        private void phiếuLĩnhThuốcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.In.frmPhieuLinhThuoc_Sua fr = new NamDinh_QLBN.Forms.In.frmPhieuLinhThuoc_Sua();
            fr.MdiParent = this;
            fr.Show();
            DaleteFrom(fr);
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            String Str = "";
            Str = String.Format("select UPPER(UName), b.TenKhoa from NAMDINH_SYSDB.dbo.SYSUSER a inner join NAMDINH_SYSDB.dbo.DMKHOAPHONG b on a.KhoaPhong = b.MaKhoa where b.is_Phongkham = 1 and MaKhoa = 'NV13' and UName = '{0}'", Global.glbUName.ToUpper());
            SQLCmd.CommandText = Str;
            dr = SQLCmd.ExecuteReader();
            dr.Read();
            if (!dr.HasRows)
            {
                MessageBox.Show("KHÔNG ĐĂNG NHẬP ĐƯỢC CHỨC NĂNG NÀY!.", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dr.Close();
                return;
            }
            else
            {
                dr.Close();
                NamDinh_QLBN.Forms.DuLieu.frmChuyenDien fr = new NamDinh_QLBN.Forms.DuLieu.frmChuyenDien();
                fr.MdiParent = this;
                fr.Show();
                
            }


            //    string DanhSachMAC = "";
            //NetworkInterface[] DanhSachCardMang = NetworkInterface.GetAllNetworkInterfaces();
            //string diachi = "";
            //for (int i = 0; i < DanhSachCardMang.Length; i++)
            //{
            //    if(DanhSachCardMang[i].NetworkInterfaceType.ToString() == "Ethernet")
            //    {
            //        PhysicalAddress DiaChiMAC = DanhSachCardMang[i].GetPhysicalAddress();
            //        // DanhSachMAC += DanhSachCardMang[i].Name + " : ";
            //        byte[] ByteDiaChi = DiaChiMAC.GetAddressBytes();
            //        for (int j = 0; j < ByteDiaChi.Length; j++)
            //        {
            //            DanhSachMAC += ByteDiaChi[j].ToString("X2");
            //            if (j != ByteDiaChi.Length - 1)
            //            {
            //                DanhSachMAC += "-";
            //            }
            //        }
            //    }
            //    diachi = DanhSachMAC;
            //}
        }

        private void thiếtLậpPhiếuInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.DuLieu.frmChonKho fr = new NamDinh_QLBN.Forms.DuLieu.frmChonKho();
            fr.MdiParent = this;
            fr.Show();
            DaleteFrom(fr);
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.In.frmInPhieuHoanTra fr = new NamDinh_QLBN.Forms.In.frmInPhieuHoanTra();
            fr.MdiParent = this;
            fr.Show();
            DaleteFrom(fr);
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {

        }

        private void cậpNhậtVậtTưTiêuHaoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.DuLieu.frmDuTruVatTu frm = new NamDinh_QLBN.Forms.DuLieu.frmDuTruVatTu();
            frm.Show();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            DaleteFrom(frm);
        }

        private void thiếtLậpChỉSốSỗLĩnhThuốcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.DuLieu.frmChiSoSoThuoc_sua fr = new NamDinh_QLBN.Forms.DuLieu.frmChiSoSoThuoc_sua();
            fr.MdiParent = this;
            fr.Show();
            DaleteFrom(fr);
        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.In.frmInSoLinhThuoc_Sua fr = new NamDinh_QLBN.Forms.In.frmInSoLinhThuoc_Sua();
            fr.MdiParent = this;
            fr.Show();
            DaleteFrom(fr);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.DuLieu.frmBenhNhanRaVien fr = new NamDinh_QLBN.Forms.DuLieu.frmBenhNhanRaVien();
            fr.MdiParent = this;
            fr.Show();
            fr.WindowState = FormWindowState.Maximized;
            DaleteFrom(fr);
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem14_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.DuLieu.frmTraVo fr = new NamDinh_QLBN.Forms.DuLieu.frmTraVo();
            fr.MdiParent = this;
            fr.Show();
            fr.WindowState = FormWindowState.Maximized;
            DaleteFrom(fr);
        }

        private void thiếtLậpDanhSáchThuốcTrảVõToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.DuLieu.frmDanhSachTV fr = new NamDinh_QLBN.Forms.DuLieu.frmDanhSachTV();
            fr.MdiParent = this;
            fr.Show();
            DaleteFrom(fr);
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.DuLieu.frmChuyenKhoa fr = new NamDinh_QLBN.Forms.DuLieu.frmChuyenKhoa();
            fr.MdiParent = this;
            fr.Show();
            DaleteFrom(fr);
        }

        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.DuLieu.frmThongTinCTBN fr = new NamDinh_QLBN.Forms.DuLieu.frmThongTinCTBN();
            fr.MdiParent = this;
            fr.Show();
            DaleteFrom(fr);
        }

        private void toolStripMenuItem16_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.DuLieu.frmThongTinThuThuat fr = new NamDinh_QLBN.Forms.DuLieu.frmThongTinThuThuat(); 
            fr.MdiParent = this;
            fr.Show();
            DaleteFrom(fr);
        }

        private void thiếtLậpDanhSáchThủThậtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.DuLieu.frmThuThuatKhoa fr = new NamDinh_QLBN.Forms.DuLieu.frmThuThuatKhoa();
            fr.MdiParent = this;
            fr.Show();
            DaleteFrom(fr);
        }

        private void cậpNhậtBệnhNhânPhẩuThuậtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void danhMụcPhẩuThuậtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.DanhMuc.frmDanhMucDichVu fr = new NamDinh_QLBN.Forms.DanhMuc.frmDanhMucDichVu();
            fr.MdiParent = this;
            fr.Show();
            DaleteFrom(fr);
        }

        private void danhMụcBácSỹToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.DanhMuc.frmDMBacSyPT fr = new NamDinh_QLBN.Forms.DanhMuc.frmDMBacSyPT();
            fr.MdiParent = this;
            fr.Show();
            DaleteFrom(fr);
        }

        private void cácBáoCáoCủaKhoaPhâuThuậtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.In.PhauThuat.frmBaoCao fr = new NamDinh_QLBN.Forms.In.PhauThuat.frmBaoCao();
            fr.MdiParent = this;
            fr.Show();
            DaleteFrom(fr);

        }

        private void thiếtLậpThứTựChọnDịchVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.DuLieu.frmCanLanSang fr = new NamDinh_QLBN.Forms.DuLieu.frmCanLanSang();
            fr.MdiParent = this;
            fr.Show();
            DaleteFrom(fr);
        }

        private void sổTayĐơnThuốcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.DanhMuc.frmSoTayDonThuoc fr = new NamDinh_QLBN.Forms.DanhMuc.frmSoTayDonThuoc();
            fr.MdiParent = this;
            fr.Show();
            DaleteFrom(fr);
        }

        private void sổTayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.DanhMuc.frmSoTayDichVu fr = new NamDinh_QLBN.Forms.DanhMuc.frmSoTayDichVu();
            fr.MdiParent = this;
            fr.Show();
            DaleteFrom(fr);
        }

        private void phânQuyềnNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.Tien_ich.frmPhanQuyen fr = new NamDinh_QLBN.Forms.Tien_ich.frmPhanQuyen();
            fr.MdiParent = this;
            fr.Show();
            DaleteFrom(fr);
        }

        private void toolStripMenuItem18_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.DuLieu.frmLenThuocDongY fr = new NamDinh_QLBN.Forms.DuLieu.frmLenThuocDongY();
            fr.MdiParent = this;
            fr.Show();
            DaleteFrom(fr);
        }

        private void tổngHợpChiPhíĐiềuTrịToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void danhMụcNhómToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.DanhMuc.frmNhom fr = new NamDinh_QLBN.Forms.DanhMuc.frmNhom();
            fr.MdiParent = this;
            fr.Show();
            DaleteFrom(fr);
        }

        private void toolStripMenuItem19_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.DuLieu.frmLenChiPhiKhoaCC fr = new NamDinh_QLBN.Forms.DuLieu.frmLenChiPhiKhoaCC();
            fr.MdiParent = this;
            fr.Show();
            DaleteFrom(fr);
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripMenuItem20_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.In.frmPhieuLinhThuoc_SuaOKhoaCC fr = new NamDinh_QLBN.Forms.In.frmPhieuLinhThuoc_SuaOKhoaCC();
            fr.MdiParent = this;
            DaleteFrom(fr);
            fr.Show();
            DaleteFrom(fr);
        }

        private void toolStripMenuItem21_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.In.frmInSoLinhThuoc_SuaOKhoaCC fr = new NamDinh_QLBN.Forms.In.frmInSoLinhThuoc_SuaOKhoaCC();
            fr.MdiParent = this;
            fr.Show();
            DaleteFrom(fr);
        }

        private void MnuSoDongY_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.In.frmInSoLinhThuoc_SuaOKhoaDongY fr = new NamDinh_QLBN.Forms.In.frmInSoLinhThuoc_SuaOKhoaDongY();
            fr.MdiParent = this;
            fr.Show();
            DaleteFrom(fr);
        }

        private void toolStripMenuItem22_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.Tien_ich.frmTNgayDNgay frm = new NamDinh_QLBN.Forms.Tien_ich.frmTNgayDNgay();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                NamDinh_QLBN.Reports.BaoCaoNoiTru.repDSBNNhanTuKhoaKhacChuyenDen rep = new NamDinh_QLBN.Reports.BaoCaoNoiTru.repDSBNNhanTuKhoaKhacChuyenDen(frm._TNgay, frm._DNgay, frm._MaKhoa, frm._TenKhoa);
                rep.Show();
                return;
            }
        }

        private void toolStripMenuItem23_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.Tien_ich.frmTNgayDNgay frm = new NamDinh_QLBN.Forms.Tien_ich.frmTNgayDNgay();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                NamDinh_QLBN.Reports.BaoCaoNoiTru.repDSBNNhanChuyenDiKhoaKhac rep = new NamDinh_QLBN.Reports.BaoCaoNoiTru.repDSBNNhanChuyenDiKhoaKhac(frm._TNgay, frm._DNgay, frm._MaKhoa, frm._TenKhoa);
                rep.Show();
                return;
            }
        }

        private void thôngKêChiTiếtTheoĐốiTượngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.Tien_ich.frmTNgayDNgayByDoiTuong frm = new NamDinh_QLBN.Forms.Tien_ich.frmTNgayDNgayByDoiTuong();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                NamDinh_QLBN.Reports.BaoCaoNoiTru.DoiTuongBN.repDanhSachBNByDoiTuong rep = new NamDinh_QLBN.Reports.BaoCaoNoiTru.DoiTuongBN.repDanhSachBNByDoiTuong(frm._TNgay, frm._DNgay, frm._MaKhoa, frm._TenKhoa,frm._isDaRaVien,frm._isDangDT,frm._MaDT);
                rep.Show();
                return;
            }
        }

        private void tổngHợpLượngChỉĐịnhTheoBácSỹToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.Tien_ich.frmTNgayDNgayByLoaiDV frm = new NamDinh_QLBN.Forms.Tien_ich.frmTNgayDNgayByLoaiDV("C5%");
            if (frm.ShowDialog() == DialogResult.OK)
            {
                NamDinh_QLBN.Reports.BaoCaoNoiTru.CanLamSang.repCLS_ByBS rep = new NamDinh_QLBN.Reports.BaoCaoNoiTru.CanLamSang.repCLS_ByBS(frm._TNgay,frm._DNgay,frm._MaKhoa,frm._TenKhoa,frm._isTatCa,frm._isBatThuong,frm._isTrongNgay,frm._Like,frm._MaLoaiCLS,frm._MaBS);
                rep.Show();
                return;
            }
        }

        private void thôngKêChiTiếtCLSTheoKhoaThựcHiệnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.Tien_ich.frmTNgayDNgayByLoaiDV frm = new NamDinh_QLBN.Forms.Tien_ich.frmTNgayDNgayByLoaiDV("C5%");
            if (frm.ShowDialog() == DialogResult.OK)
            {
                NamDinh_QLBN.Reports.BaoCaoNoiTru.CanLamSang.repCLS_ByLoaiCLS rep = new NamDinh_QLBN.Reports.BaoCaoNoiTru.CanLamSang.repCLS_ByLoaiCLS(frm._TNgay, frm._DNgay, frm._MaKhoa, frm._TenKhoa, frm._isTatCa, frm._isBatThuong, frm._isTrongNgay, frm._Like, frm._MaLoaiCLS, frm._MaBS);
                rep.Show();
                return;
            }
        }

        private void toolStripMenuItem32_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.DuLieu.DuyetPhieuCD.FrmDuyetPhieuCD frm = new NamDinh_QLBN.Forms.DuLieu.DuyetPhieuCD.FrmDuyetPhieuCD();
            frm.MdiParent = this;
            frm.Show();
            DaleteFrom(frm);
        }

        private void sổTổngHợpDuyệtPhiếuChỉĐịnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.DuLieu.DuyetPhieuCD.FrmTKDuyetXN frm = new NamDinh_QLBN.Forms.DuLieu.DuyetPhieuCD.FrmTKDuyetXN();
            frm.ShowDialog();
        }

        private void tổngHợpSốLượtChỉĐịnhCLSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.Tien_ich.frmTNgayDNgayByLoaiDV frm = new NamDinh_QLBN.Forms.Tien_ich.frmTNgayDNgayByLoaiDV("C5%");
            if (frm.ShowDialog() == DialogResult.OK)
            {
                NamDinh_QLBN.Reports.BaoCaoNoiTru.CanLamSang.repCLS_TongHopByBS rep = new NamDinh_QLBN.Reports.BaoCaoNoiTru.CanLamSang.repCLS_TongHopByBS(frm._TNgay, frm._DNgay, frm._MaKhoa, frm._TenKhoa, frm._isTatCa, frm._isBatThuong, frm._isTrongNgay, frm._Like, frm._MaLoaiCLS, frm._MaBS);
                rep.Show();
                return;
            }
        }

        private void tổngHợpSửDụngThuốcVậtTưThoànKhoaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.In.frmTongHopChiPhiDieuTri fr = new NamDinh_QLBN.Forms.In.frmTongHopChiPhiDieuTri();
            fr.MdiParent = this;
            fr.Show();
            DaleteFrom(fr);
        }

        private void thôngKêThuốcVậtTưTheoBệnhNhânToànKhoaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.Tien_ich.frmTNgayDNgayByThuocVTofSoPhieu frm = new NamDinh_QLBN.Forms.Tien_ich.frmTNgayDNgayByThuocVTofSoPhieu();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                NamDinh_QLBN.Reports.BaoCaoVeThuoc.repChiPhi_DDTByBenhNhan rep = new NamDinh_QLBN.Reports.BaoCaoVeThuoc.repChiPhi_DDTByBenhNhan(frm._MaKhoa, frm._LoaiSo, frm._SoPhieuTu, frm._SoPhieuDen, frm._TenKhoa,frm._MaNhom);
                rep.Show();
                return;
            }
        }

        private void tổngHợpSốLượtChỉĐịnhCLSTheoKhoaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.Tien_ich.frmTNgayDNgayByLoaiDV frm = new NamDinh_QLBN.Forms.Tien_ich.frmTNgayDNgayByLoaiDV("C5%");
            if (frm.ShowDialog() == DialogResult.OK)
            {
                NamDinh_QLBN.Reports.BaoCaoNoiTru.CanLamSang.repCLS_TongHopByLoaiCLS rep = new NamDinh_QLBN.Reports.BaoCaoNoiTru.CanLamSang.repCLS_TongHopByLoaiCLS(frm._TNgay, frm._DNgay, frm._MaKhoa, frm._TenKhoa, frm._isTatCa, frm._isBatThuong, frm._isTrongNgay, frm._Like, frm._MaLoaiCLS, frm._MaBS);
                rep.Show();
                return;
            }
        }

        private void thốngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.Tien_ich.frmTNgayDNgayByLoaiDV frm = new NamDinh_QLBN.Forms.Tien_ich.frmTNgayDNgayByLoaiDV("D03");
            if (frm.ShowDialog() == DialogResult.OK)
            {
                NamDinh_QLBN.Reports.BaoCaoNoiTru.Mau.repMau_ByBS rep = new NamDinh_QLBN.Reports.BaoCaoNoiTru.Mau.repMau_ByBS(frm._TNgay, frm._DNgay, frm._MaKhoa, frm._TenKhoa, frm._isTatCa, frm._isBatThuong, frm._isTrongNgay, frm._Like, frm._MaLoaiCLS, frm._MaBS);
                rep.Show();
                return;
            }
        }

        private void toolStripMenuItem36_Click(object sender, EventArgs e)
        {

        }

        private void tổngHợpSốLượtTruyềnMáuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.Tien_ich.frmTNgayDNgayByLoaiDV frm = new NamDinh_QLBN.Forms.Tien_ich.frmTNgayDNgayByLoaiDV("D03");
            if (frm.ShowDialog() == DialogResult.OK)
            {
                NamDinh_QLBN.Reports.BaoCaoNoiTru.Mau.repMau_TongHopByBS rep = new NamDinh_QLBN.Reports.BaoCaoNoiTru.Mau.repMau_TongHopByBS(frm._TNgay, frm._DNgay, frm._MaKhoa, frm._TenKhoa, frm._isTatCa, frm._isBatThuong, frm._isTrongNgay, frm._Like, frm._MaLoaiCLS, frm._MaBS);
                rep.Show();
                return;
            }
        }

        private void tổngHợpSốLượtTruyềnMáuTheoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.Tien_ich.frmTNgayDNgayByLoaiDV frm = new NamDinh_QLBN.Forms.Tien_ich.frmTNgayDNgayByLoaiDV("D03");
            if (frm.ShowDialog() == DialogResult.OK)
            {
                NamDinh_QLBN.Reports.BaoCaoNoiTru.Mau.repMau_TongHopByLoaiMau rep = new NamDinh_QLBN.Reports.BaoCaoNoiTru.Mau.repMau_TongHopByLoaiMau(frm._TNgay, frm._DNgay, frm._MaKhoa, frm._TenKhoa, frm._isTatCa, frm._isBatThuong, frm._isTrongNgay, frm._Like, frm._MaLoaiCLS, frm._MaBS);
                rep.Show();
                return;
            }
        }

        private void toolStripMenuItem35_Click(object sender, EventArgs e)
        {

        }

        private void tổngHợpSốLượngMáuTruyềnTheoLọaMáuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.Tien_ich.frmTNgayDNgayByLoaiDV frm = new NamDinh_QLBN.Forms.Tien_ich.frmTNgayDNgayByLoaiDV("D03");
            if (frm.ShowDialog() == DialogResult.OK)
            {
                NamDinh_QLBN.Reports.BaoCaoNoiTru.Mau.repMau_TongHopByLoaiMauSoLuong rep = new NamDinh_QLBN.Reports.BaoCaoNoiTru.Mau.repMau_TongHopByLoaiMauSoLuong(frm._TNgay, frm._DNgay, frm._MaKhoa, frm._TenKhoa, frm._isTatCa, frm._isBatThuong, frm._isTrongNgay, frm._Like, frm._MaLoaiCLS, frm._MaBS);
                rep.Show();
                return;
            }
        }

        private void thôngKêDanhSáchBệnhNhânChuyểnViệnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.Tien_ich.frmTNgayDNgay frm = new NamDinh_QLBN.Forms.Tien_ich.frmTNgayDNgay();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                NamDinh_QLBN.Reports.BaoCaoNoiTru.ChuyenVien.repDanhSachBNChuyenVien rep = new NamDinh_QLBN.Reports.BaoCaoNoiTru.ChuyenVien.repDanhSachBNChuyenVien(frm._TNgay, frm._DNgay, frm._MaKhoa, frm._TenKhoa);
                rep.Show();
                return;
            }
        }

        private void thôngKêDanhSáchBệnhNhânTheoBVChuyểnĐếnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.Tien_ich.frmTNgayDNgayByBV frm = new NamDinh_QLBN.Forms.Tien_ich.frmTNgayDNgayByBV();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                NamDinh_QLBN.Reports.BaoCaoNoiTru.ChuyenVien.repTK_DanhSachBNChuyenVienByBVChuyenDen rep = new NamDinh_QLBN.Reports.BaoCaoNoiTru.ChuyenVien.repTK_DanhSachBNChuyenVienByBVChuyenDen(frm._TNgay, frm._DNgay, frm._MaKhoa, frm._TenKhoa, frm._MaBV);
                rep.Show();
                return;
            }
        }

        private void thốngKêDanhSáchBệnhNhânTheoBSChỉĐịnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.Tien_ich.frmTNgayDNgayByBVAndBS frm = new NamDinh_QLBN.Forms.Tien_ich.frmTNgayDNgayByBVAndBS();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                NamDinh_QLBN.Reports.BaoCaoNoiTru.ChuyenVien.repTK_DanhSachBNChuyenVienByBS rep = new NamDinh_QLBN.Reports.BaoCaoNoiTru.ChuyenVien.repTK_DanhSachBNChuyenVienByBS(frm._TNgay, frm._DNgay, frm._MaKhoa, frm._TenKhoa, frm._MaBV,frm._MaBS);
                rep.Show();
                return;
            }
        }

        private void tổngHợpSốLượngChuyểnViệnTheoBSChỉĐịnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.Tien_ich.frmTNgayDNgayByBVAndBS frm = new NamDinh_QLBN.Forms.Tien_ich.frmTNgayDNgayByBVAndBS();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                NamDinh_QLBN.Reports.BaoCaoNoiTru.ChuyenVien.repTH_ChuyenVienByBS rep = new NamDinh_QLBN.Reports.BaoCaoNoiTru.ChuyenVien.repTH_ChuyenVienByBS(frm._TNgay, frm._DNgay, frm._MaKhoa, frm._TenKhoa, frm._MaBS, frm._MaBV);
                rep.Show();
                return;
            }
        }

        private void tổngHợpSốLượngChuyểnViệnTheoBVChuyểnĐếnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.Tien_ich.frmTNgayDNgayByBVAndBS frm = new NamDinh_QLBN.Forms.Tien_ich.frmTNgayDNgayByBVAndBS();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                NamDinh_QLBN.Reports.BaoCaoNoiTru.ChuyenVien.repTH_ChuyenVienByBV rep = new NamDinh_QLBN.Reports.BaoCaoNoiTru.ChuyenVien.repTH_ChuyenVienByBV(frm._TNgay, frm._DNgay, frm._MaKhoa, frm._TenKhoa, frm._MaBS, frm._MaBV);
                rep.Show();
                return;
            }
        }

        private void thốngKêDanhSáchBệnhNhânLàmPhẩuThuậtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.Tien_ich.frmTKPhauThuat_ByBS frm = new NamDinh_QLBN.Forms.Tien_ich.frmTKPhauThuat_ByBS();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                NamDinh_QLBN.Reports.BaoCaoNoiTru.PhauThuat.repTKPhauThuat_ByLoaiPT rep = new NamDinh_QLBN.Reports.BaoCaoNoiTru.PhauThuat.repTKPhauThuat_ByLoaiPT(frm._TNgay, frm._DNgay, frm._MaKhoa, frm._TenKhoa, frm._isTatCa, frm._isBatThuong, frm._isTrongNgay, frm._MaLoaiPT, frm._MaBS);
                rep.Show();
                return;
            }   
        }

        private void thổngKêDanhSáchBệnhNhânLàmPTTheoBSChỉĐịnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.Tien_ich.frmTKPhauThuat_ByBS frm = new NamDinh_QLBN.Forms.Tien_ich.frmTKPhauThuat_ByBS();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                NamDinh_QLBN.Reports.BaoCaoNoiTru.PhauThuat.repPhauThuat_ByBS rep = new NamDinh_QLBN.Reports.BaoCaoNoiTru.PhauThuat.repPhauThuat_ByBS(frm._TNgay, frm._DNgay, frm._MaKhoa, frm._TenKhoa, frm._isTatCa, frm._isBatThuong, frm._isTrongNgay, frm._MaLoaiPT, frm._MaBS);
                rep.Show();
                return;
            }   
        }

        private void tổngHợpSốLượngBệnhNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.Tien_ich.frmTKPhauThuat_ByBS frm = new NamDinh_QLBN.Forms.Tien_ich.frmTKPhauThuat_ByBS();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                NamDinh_QLBN.Reports.BaoCaoNoiTru.PhauThuat.repTHPhauThuat_ByBS rep = new NamDinh_QLBN.Reports.BaoCaoNoiTru.PhauThuat.repTHPhauThuat_ByBS(frm._TNgay, frm._DNgay, frm._MaKhoa, frm._TenKhoa, frm._isTatCa, frm._isBatThuong, frm._isTrongNgay, frm._MaLoaiPT, frm._MaBS);
                rep.Show();
                return;
            }   
        }

        private void tổngHợpSốLượtBệnhNhânLàmPhẩuThuậtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.Tien_ich.frmTKPhauThuat_ByBS frm = new NamDinh_QLBN.Forms.Tien_ich.frmTKPhauThuat_ByBS();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                NamDinh_QLBN.Reports.BaoCaoNoiTru.PhauThuat.repPhauThuat_TongHopByLoaiPT rep = new NamDinh_QLBN.Reports.BaoCaoNoiTru.PhauThuat.repPhauThuat_TongHopByLoaiPT(frm._TNgay, frm._DNgay, frm._MaKhoa, frm._TenKhoa, frm._isTatCa, frm._isBatThuong, frm._isTrongNgay, frm._MaLoaiPT, frm._MaBS);
                rep.Show();
                return;
            }   
        }

        private void thôngKêDanhSáchBệnhNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.Tien_ich.frmTKPhauThuat_ByBS frm = new NamDinh_QLBN.Forms.Tien_ich.frmTKPhauThuat_ByBS();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                NamDinh_QLBN.Reports.BaoCaoNoiTru.ThuThuat.repTKThuThuat_ByLoaiTT rep = new NamDinh_QLBN.Reports.BaoCaoNoiTru.ThuThuat.repTKThuThuat_ByLoaiTT(frm._TNgay, frm._DNgay, frm._MaKhoa, frm._TenKhoa, frm._isTatCa, frm._isBatThuong, frm._isTrongNgay, frm._MaLoaiPT, frm._MaBS);
                rep.Show();
                return;
            }   
        }

        private void tổngHợpSốLượngBệnhNhânLàmThủThuậtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.Tien_ich.frmTKPhauThuat_ByBS frm = new NamDinh_QLBN.Forms.Tien_ich.frmTKPhauThuat_ByBS();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                NamDinh_QLBN.Reports.BaoCaoNoiTru.ThuThuat.repThuThuat_TongHopByLoaiTT rep = new NamDinh_QLBN.Reports.BaoCaoNoiTru.ThuThuat.repThuThuat_TongHopByLoaiTT(frm._TNgay, frm._DNgay, frm._MaKhoa, frm._TenKhoa, frm._isTatCa, frm._isBatThuong, frm._isTrongNgay, frm._MaLoaiPT, frm._MaBS);
                rep.Show();
                return;
            }  
        }

        private void thốngKêDanhSáchBệnhNhânTheoBSChỉĐịnhToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.Tien_ich.frmTKPhauThuat_ByBS frm = new NamDinh_QLBN.Forms.Tien_ich.frmTKPhauThuat_ByBS();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                NamDinh_QLBN.Reports.BaoCaoNoiTru.ThuThuat.repThuThuat_ByBS rep = new NamDinh_QLBN.Reports.BaoCaoNoiTru.ThuThuat.repThuThuat_ByBS(frm._TNgay, frm._DNgay, frm._MaKhoa, frm._TenKhoa, frm._isTatCa, frm._isBatThuong, frm._isTrongNgay, frm._MaLoaiPT, frm._MaBS);
                rep.Show();
                return;
            }  
        }

        private void tổngHợpSốLượtBệnhNhânTheoBSChỉĐịnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.Tien_ich.frmTKPhauThuat_ByBS frm = new NamDinh_QLBN.Forms.Tien_ich.frmTKPhauThuat_ByBS();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                NamDinh_QLBN.Reports.BaoCaoNoiTru.ThuThuat.repTHThuThuat_ByBS rep = new NamDinh_QLBN.Reports.BaoCaoNoiTru.ThuThuat.repTHThuThuat_ByBS(frm._TNgay, frm._DNgay, frm._MaKhoa, frm._TenKhoa, frm._isTatCa, frm._isBatThuong, frm._isTrongNgay, frm._MaLoaiPT, frm._MaBS);
                rep.Show();
                return;
            }  
        }

        private void cậpNhậtBệnhNhânPhẩuThuậtToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.DuLieu.PhongMo.frmBenhNhan_PhauThuat fr = new NamDinh_QLBN.Forms.DuLieu.PhongMo.frmBenhNhan_PhauThuat();
            fr.MdiParent = this;
            fr.Show();
            DaleteFrom(fr);
        }

        private void phiếuLĩnhThuốcToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.In.PhauThuat.frmPhieuLinhThuoc_Sua frm = new NamDinh_QLBN.Forms.In.PhauThuat.frmPhieuLinhThuoc_Sua();
            frm.MdiParent = this;
            frm.Show();
            DaleteFrom(frm);
        }

        private void inSổTổngHợpThuốcHàngNgàyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.In.PhauThuat.frmInSoLinhThuoc_Sua frm = new NamDinh_QLBN.Forms.In.PhauThuat.frmInSoLinhThuoc_Sua();
            frm.MdiParent = this;
            frm.Show();
            DaleteFrom(frm);
        }

        private void tổngHơpSưToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.In.ChiPhi_BNDDT.frmTongHopChiPhi_BNDDT fr = new NamDinh_QLBN.Forms.In.ChiPhi_BNDDT.frmTongHopChiPhi_BNDDT();
            fr.MdiParent = this;
            fr.Show();
        }

        private void thôngKêThuốcVậtTưTheoBệnhNhânBệnhNhânĐangĐiềuTrịToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.Tien_ich.frmDangDTByThuoc frm = new NamDinh_QLBN.Forms.Tien_ich.frmDangDTByThuoc();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                NamDinh_QLBN.Reports.BaoCaoVeThuoc.repChiPhi_DDTByBenhNhanDangDT rep = new NamDinh_QLBN.Reports.BaoCaoVeThuoc.repChiPhi_DDTByBenhNhanDangDT(frm._MaKhoa, frm._LoaiSo, frm._TenKhoa, frm._MaNhom,frm._NgayChiDinh,frm.isngay);
                rep.Show();
                return;
            }
        }        

        private void tổngHợpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.In.ChiPhi_BNDDT.frmBaoCaoVatTu fr = new NamDinh_QLBN.Forms.In.ChiPhi_BNDDT.frmBaoCaoVatTu();
            fr.MdiParent = this;
            fr.Show();
        }

        private void thốngKêChiTiếtChụpCRThToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.Tien_ich.frmTNgayDNgayByLoaiDV frm = new NamDinh_QLBN.Forms.Tien_ich.frmTNgayDNgayByLoaiDV("C54%");
            if (frm.ShowDialog() == DialogResult.OK)
            {
                NamDinh_QLBN.Reports.BaoCaoNoiTru.CanLamSang.repCLS_CR_ByBS rep = new NamDinh_QLBN.Reports.BaoCaoNoiTru.CanLamSang.repCLS_CR_ByBS(frm._TNgay, frm._DNgay, frm._MaKhoa, frm._TenKhoa, frm._isTatCa, frm._isBatThuong, frm._isTrongNgay, frm._Like, frm._MaLoaiCLS, frm._MaBS);
                rep.Show();
                return;
            }
        }

        private void thôngKêChếChiTiếtĐọChămSócToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.Tien_ich.frmTNgayDNgayByCheDoCS frm = new NamDinh_QLBN.Forms.Tien_ich.frmTNgayDNgayByCheDoCS();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                NamDinh_QLBN.Reports.BaoCaoNoiTru.CheDoChamSoc.repCS_DanhSachBN rep = new NamDinh_QLBN.Reports.BaoCaoNoiTru.CheDoChamSoc.repCS_DanhSachBN(frm._TNgay, frm._DNgay, frm._MaKhoa, frm._TenKhoa,frm._isCheDoChamSoc,frm._isNgayChiDinh,frm._isNgayVaoVien,frm._isNgayRaVien,frm._isDangDieuTri);
                rep.Show();
                return;
            }
        }

        private void tổngHợpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.Tien_ich.frmTNgayDNgayByCheDoCS frm = new NamDinh_QLBN.Forms.Tien_ich.frmTNgayDNgayByCheDoCS();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                NamDinh_QLBN.Reports.BaoCaoNoiTru.CheDoChamSoc.repCS_TongHopByDoiTuongBN rep = new NamDinh_QLBN.Reports.BaoCaoNoiTru.CheDoChamSoc.repCS_TongHopByDoiTuongBN(frm._TNgay, frm._DNgay, frm._MaKhoa, frm._TenKhoa, frm._isCheDoChamSoc, frm._isNgayChiDinh, frm._isNgayVaoVien, frm._isNgayRaVien, frm._isDangDieuTri);
                rep.Show();
                return;
            }
        }

        private void tổngHợpToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.Tien_ich.frmTNgayDNgayByLoaiDV frm = new NamDinh_QLBN.Forms.Tien_ich.frmTNgayDNgayByLoaiDV("C54%");
            if (frm.ShowDialog() == DialogResult.OK)
            {
                NamDinh_QLBN.Reports.BaoCaoNoiTru.CanLamSang.repCLS_CR_TongHopByBS rep = new NamDinh_QLBN.Reports.BaoCaoNoiTru.CanLamSang.repCLS_CR_TongHopByBS(frm._TNgay, frm._DNgay, frm._MaKhoa, frm._TenKhoa, frm._isTatCa, frm._isBatThuong, frm._isTrongNgay, frm._Like, frm._MaLoaiCLS, frm._MaBS);
                rep.Show();
                return;
            }
        }

        private void thôngKêDanhSáchBệnhNhânTheoNơiKCBBanĐầuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.Tien_ich.frmTNgayDNgayByNoiKCBBD frm = new NamDinh_QLBN.Forms.Tien_ich.frmTNgayDNgayByNoiKCBBD();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                NamDinh_QLBN.Reports.BaoCaoNoiTru.NoiDKKCB_BanDau.repDS_BN_DKKCBBD_ByNoiDK rep = new NamDinh_QLBN.Reports.BaoCaoNoiTru.NoiDKKCB_BanDau.repDS_BN_DKKCBBD_ByNoiDK(frm._TNgay, frm._DNgay, frm._MaKhoa, frm._TenKhoa, frm._isMaTu, frm._isMaDen, frm._isNgayVaoVien, frm._isNgayRaVien, frm._isDangDieuTri, frm._isTatCa);
                rep.Show();
                return;
            }
        }

        private void thôngKêDanhSáchBNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.Tien_ich.frmTNgayDNgayByNoiKCBBDAndChuyenBV frm = new NamDinh_QLBN.Forms.Tien_ich.frmTNgayDNgayByNoiKCBBDAndChuyenBV();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                NamDinh_QLBN.Reports.BaoCaoNoiTru.NoiDKKCB_BanDau.repDS_BN_DKKCBBD_ByNoiDKAndChuyenVien rep = new NamDinh_QLBN.Reports.BaoCaoNoiTru.NoiDKKCB_BanDau.repDS_BN_DKKCBBD_ByNoiDKAndChuyenVien(frm._TNgay, frm._DNgay, frm._MaKhoa, frm._TenKhoa, frm._isMaTu, frm._isMaDen, frm._MaBV, frm._isNgayVaoVien, frm._isNgayRaVien, frm._isTatCa);
                rep.Show();
                return;
            }
        }

        private void ngàyĐiềuTrịTrungBinhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.Tien_ich.frmTNgayDNgay frm = new NamDinh_QLBN.Forms.Tien_ich.frmTNgayDNgay();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                NamDinh_QLBN.Reports.BaoCaoNoiTru.HoatDongChuyenMon.repHoatDongChuyenMon rep = new NamDinh_QLBN.Reports.BaoCaoNoiTru.HoatDongChuyenMon.repHoatDongChuyenMon(frm._TNgay, frm._DNgay, frm._MaKhoa, frm._TenKhoa);
                rep.Show();
                return;
            }
        }

        private void thôngKêDanhSáchBệnhNhânTheoBuồngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.Tien_ich.frmTNgayDNgayByGiuongAndBuong frm = new NamDinh_QLBN.Forms.Tien_ich.frmTNgayDNgayByGiuongAndBuong();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                NamDinh_QLBN.Reports.BaoCaoNoiTru.BuongGiuong.repBuongGiuong_DanhSachBN rep = new NamDinh_QLBN.Reports.BaoCaoNoiTru.BuongGiuong.repBuongGiuong_DanhSachBN(frm._TNgay, frm._DNgay, frm._MaKhoa, frm._TenKhoa, frm._isID_Buong, frm._isID_Giuong, frm._isNgayVaoVien, frm._isNgayRaVien, frm._isDangDieuTri);
                rep.Show();
                return;
            }
        }

        private void tổngHợpSốLượtBệnhNhânTheoBuồngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.Tien_ich.frmTNgayDNgayByGiuongAndBuong frm = new NamDinh_QLBN.Forms.Tien_ich.frmTNgayDNgayByGiuongAndBuong();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                NamDinh_QLBN.Reports.BaoCaoNoiTru.BuongGiuong.repBuongGiuong_TongHop rep = new NamDinh_QLBN.Reports.BaoCaoNoiTru.BuongGiuong.repBuongGiuong_TongHop(frm._TNgay, frm._DNgay, frm._MaKhoa, frm._TenKhoa, frm._isID_Buong, frm._isID_Giuong, frm._isNgayVaoVien, frm._isNgayRaVien, frm._isDangDieuTri);
                rep.Show();
                return;
            }
        }

        private void thốngKêDanhSáchBNTheoLoạiBệnhÁnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.Tien_ich.frmTNgayDNgayByLoaiBA frm = new NamDinh_QLBN.Forms.Tien_ich.frmTNgayDNgayByLoaiBA();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                NamDinh_QLBN.Reports.BaoCaoNoiTru.BenhAnNoiNgoai.repBA_DanhSachBN rep = new NamDinh_QLBN.Reports.BaoCaoNoiTru.BenhAnNoiNgoai.repBA_DanhSachBN(frm._TNgay, frm._DNgay, frm._MaKhoa, frm._TenKhoa, frm._MaBA, frm._isNgayVV, frm._isRaVien, frm._isDangDT);
                rep.Show();
                return;
            }
        }

        private void danhSáchBệnhNhânTưVongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.Tien_ich.frmTNgayDNgayByKetQuaDT frm = new NamDinh_QLBN.Forms.Tien_ich.frmTNgayDNgayByKetQuaDT();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                NamDinh_QLBN.Reports.BaoCaoNoiTru.BenhNhanKetQDT.repTV_DanhSachBN rep = new NamDinh_QLBN.Reports.BaoCaoNoiTru.BenhNhanKetQDT.repTV_DanhSachBN(frm._TNgay, frm._DNgay, frm._MaKhoa, frm._TenKhoa, frm._KetQDT, frm._isNgayVV, frm._isRaVien);
                rep.Show();
                return;
            }
        }

        private void tổngHợpBệnhNhânTheoKếtQuảĐiềuTrịToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.Tien_ich.frmTNgayDNgayByKetQuaDT frm = new NamDinh_QLBN.Forms.Tien_ich.frmTNgayDNgayByKetQuaDT();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                NamDinh_QLBN.Reports.BaoCaoNoiTru.BenhNhanKetQDT.repKQDT_TongHop rep = new NamDinh_QLBN.Reports.BaoCaoNoiTru.BenhNhanKetQDT.repKQDT_TongHop(frm._TNgay, frm._DNgay, frm._MaKhoa, frm._TenKhoa, frm._KetQDT, frm._isNgayVV, frm._isRaVien);
                rep.Show();
                return;
            }
        }

        private void toolStripMenuItem25_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.DuLieu.DuyetPhieuCD.frmNhapSoLuuTru frm = new NamDinh_QLBN.Forms.DuLieu.DuyetPhieuCD.frmNhapSoLuuTru();
            //frm.MdiParent = this;
            frm.Show(this);
        }

        private void cậpNhậtVậtTưỞPhòngMỗToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.DuLieu.frmDuTruVatTu frm = new NamDinh_QLBN.Forms.DuLieu.frmDuTruVatTu();
            frm.Show();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            DaleteFrom(frm);
            //NamDinh_QLBN.Forms.DuLieu.frmVatTu fr = new NamDinh_QLBN.Forms.DuLieu.frmVatTu();
            //fr.MdiParent = this;
            //fr.Show();
            //DaleteFrom(fr);
            //NamDinh_QLBN.Forms.DuLieu.PhongMo.frmVatTuOfPhongMo frm = new NamDinh_QLBN.Forms.DuLieu.PhongMo.frmVatTuOfPhongMo();
            //frm.MdiParent = this;
            //frm.Show();
            //frm.WindowState = FormWindowState.Maximized;
            //DaleteFrom(frm);
        }

        private void toolStripMenuItem36_Click_1(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.Tien_ich.frmTNgayDNgayByNhom frm = new NamDinh_QLBN.Forms.Tien_ich.frmTNgayDNgayByNhom();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                NamDinh_QLBN.Reports.PhauThuat.rptTongKetVT rep = new NamDinh_QLBN.Reports.PhauThuat.rptTongKetVT(frm._TNgay, frm._DNgay,frm._MaNhom,frm._TenNhom,frm._NhomThuocVatTu);
                rep.Show();
            }
        }

        private void toolStripMenuItem38_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.Tien_ich.frmTNgayDNgayBySoPhieu frm = new NamDinh_QLBN.Forms.Tien_ich.frmTNgayDNgayBySoPhieu();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                NamDinh_QLBN.Reports.PhauThuat.rptTongKetThuoc rep = new NamDinh_QLBN.Reports.PhauThuat.rptTongKetThuoc(frm._SoPhieuTu, frm._SoPhieuDen);
                rep.Show();
            }
        }

        private void báoCáoThanhToánThuốcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //NamDinh_QLBN.Forms.In.frmBaoCaoThanhQuyetToan frm = new NamDinh_QLBN.Forms.In.frmBaoCaoThanhQuyetToan();
            NamDinh_QLBN.Forms.In.frmBCSDTaiPK frm = new Forms.In.frmBCSDTaiPK();
            frm.MdiParent = this;
            frm.Show();
        }

        private void toolStripMenuItem39_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.DuLieu.frmPhuCapThuThuat frm = new NamDinh_QLBN.Forms.DuLieu.frmPhuCapThuThuat();
            frm.MdiParent = this;
            frm.Show();
        }

        private void toolStripMenuItem40_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.DuLieu.frmBangKeSoCaThuThuat frm = new NamDinh_QLBN.Forms.DuLieu.frmBangKeSoCaThuThuat();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuChotSoSach_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.frmHelp frm = new NamDinh_QLBN.frmHelp("ChotSoSach.doc");
            frm.Show();
        }

        private void mnuThietLapNhomInVTTH_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.frmHelp frm = new NamDinh_QLBN.frmHelp("ThietLapInVTTH.doc");
            frm.Show();
        }

        private void mnuBCSuDungTaiKhoa_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.In.ChiPhi_BNDDT.frmTongHopVatTu_BNDDT fr = new NamDinh_QLBN.Forms.In.ChiPhi_BNDDT.frmTongHopVatTu_BNDDT();
            fr.MdiParent = this;
            fr.Show();
        }

        private void hướngDẫnDựTrùVậtTưTiêuHaoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.frmHelp frm = new NamDinh_QLBN.frmHelp("DuTruVatTu.doc");
            frm.Show();
        }

        private void hướngDẫnXemBáoCáoTổngHợpVTTHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.frmHelp frm = new NamDinh_QLBN.frmHelp("HDSDBaoCaoVTTH.doc");
            frm.Show();
        }

        private void báoCáoSửDụngChiTiếtVậtTưTạiKhoaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.In.ChiPhi_BNDDT.frmDSBNSDVTTH fr = new NamDinh_QLBN.Forms.In.ChiPhi_BNDDT.frmDSBNSDVTTH();
            fr.MdiParent = this;
            fr.Show();
        }

        private void mnuPhieuLinhVTTH_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.In.frmPhieuLinhVTTH fr = new NamDinh_QLBN.Forms.In.frmPhieuLinhVTTH();
            fr.MdiParent = this;
            fr.Show();
            DaleteFrom(fr);
        }

        private void mnuPhieuHoanVTTH_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.In.frmInPhieuHoanVTTH fr = new NamDinh_QLBN.Forms.In.frmInPhieuHoanVTTH();
            fr.MdiParent = this;
            fr.Show();
            DaleteFrom(fr);
        }

        private void mnuPhieuLinh_VTTH_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.In.frmPhieuLinhVTTH fr = new NamDinh_QLBN.Forms.In.frmPhieuLinhVTTH();
            fr.MdiParent = this;
            fr.Show();
            DaleteFrom(fr);
        }

        private void mnuThietLapNhomVTTH_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.DuLieu.frmThietLapVatTu fr = new NamDinh_QLBN.Forms.DuLieu.frmThietLapVatTu();
            fr.MdiParent = this;
            fr.Show();
            DaleteFrom(fr);
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.DuLieu.frmLichSuDieuTri fr = new NamDinh_QLBN.Forms.DuLieu.frmLichSuDieuTri();
            fr.MdiParent = this;
            fr.Show();
            fr.WindowState = FormWindowState.Maximized;
        }

        private void mnuNgayGiuongBenh_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.DuLieu.frmNgayGiuongBenh fr = new NamDinh_QLBN.Forms.DuLieu.frmNgayGiuongBenh();
            fr.MdiParent = this;
            fr.Show();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.DuLieu.frmNgayGiuongBenh fr = new NamDinh_QLBN.Forms.DuLieu.frmNgayGiuongBenh();
            fr.MdiParent = this;
            fr.Show();
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {

        }

        private void giaoBanBệnhViệnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.DuLieu.frmImagesStore fr = new NamDinh_QLBN.Forms.DuLieu.frmImagesStore(Global.glbUName);
            fr.Show();
        }

        private void DSVOCAM_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.Tien_ich.frmTNgayDNgay_excel frm = new NamDinh_QLBN.Forms.Tien_ich.frmTNgayDNgay_excel();
            frm.Show();
            //if (frm.ShowDialog() == DialogResult.OK)
            //{
                //    //NamDinh_QLBN.Reports.PhauThuat.repTKPT_TT_ByVoCam rep = new NamDinh_QLBN.Reports.PhauThuat.repTKPT_TT_ByVoCam(frm._TNgay, frm._DNgay);
                //    //rep.Show();
                //    //NamDinh_QLBN.Forms.Tien_ich.ExportForm frm1 = new NamDinh_QLBN.Forms.Tien_ich.ExportForm(rep.Document);
                //    //frm1.ShowDialog();
            //}

        }

        private void danhSáchBệnhNhânToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.Tien_ich.frmTNgayDNgay frm = new NamDinh_QLBN.Forms.Tien_ich.frmTNgayDNgay();
            NamDinh_QLBN.Forms.In.PreviewForm frmBC;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                NamDinh_QLBN.Reports.BaoCaoNoiTru.repDSBNNhapRaVien_ICD rep = new NamDinh_QLBN.Reports.BaoCaoNoiTru.repDSBNNhapRaVien_ICD(frm._TNgay, frm._DNgay, frm._MaKhoa, frm._TenKhoa);
                rep.Run();
                frmBC = new NamDinh_QLBN.Forms.In.PreviewForm(rep.Document, this);
                frmBC.Show();
                //rep.Show();
                return;
            }
        }

        private void tổngHợpICD10ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tổngHợpTheoMãBệnhICD10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.Tien_ich.frmTNgayDNgay frm = new NamDinh_QLBN.Forms.Tien_ich.frmTNgayDNgay();
            NamDinh_QLBN.Forms.In.PreviewForm frmBC;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                NamDinh_QLBN.Reports.BaoCaoNoiTru.repDSBNNhapRaVien_ICDTonghop rep = new NamDinh_QLBN.Reports.BaoCaoNoiTru.repDSBNNhapRaVien_ICDTonghop(frm._TNgay, frm._DNgay, frm._MaKhoa, frm._TenKhoa);
                rep.Run();
                frmBC = new NamDinh_QLBN.Forms.In.PreviewForm(rep.Document, this);
                frmBC.Show();
                //rep.Show();
                return;
            }
        }

        private void báoCáoỨngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton8_Click_1(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.Tien_ich.frmTT54 frm = new frmTT54();
            frm.Show();
        }

        private void danToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.Tien_ich.frmTNgayDNgay frm = new NamDinh_QLBN.Forms.Tien_ich.frmTNgayDNgay();
            NamDinh_QLBN.Forms.In.PreviewForm frmBC;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                NamDinh_QLBN.Reports.BaoCaoNoiTru.CanLamSang.repCLS_DMMM rep = new NamDinh_QLBN.Reports.BaoCaoNoiTru.CanLamSang.repCLS_DMMM(frm._TNgay, frm._DNgay, frm._MaKhoa, frm._TenKhoa);
                rep.Run();
                frmBC = new NamDinh_QLBN.Forms.In.PreviewForm(rep.Document, this);
                frmBC.Show();
                //rep.Show();
                return;
            }
        }
        private void quảnLýĐồVảiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.DuLieu.frmBenhnhan_Dovai fr = new NamDinh_QLBN.Forms.DuLieu.frmBenhnhan_Dovai();
            fr.MdiParent = this;
            fr.Show();
            DaleteFrom(fr);
        }

        private void danhMụcĐồVảiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.DanhMuc.frmDMdovai fr = new NamDinh_QLBN.Forms.DanhMuc.frmDMdovai();
            fr.MdiParent = this;
            fr.Show();
            DaleteFrom(fr);
        }

        private void mnuInSoTHVTTH_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.In.frmInSoLinhVTTH fr = new NamDinh_QLBN.Forms.In.frmInSoLinhVTTH();
            fr.MdiParent = this;
            fr.Show();
            DaleteFrom(fr);
        }

        private void thốngKêDanhSáchBệnhNhânTheoKhoaThựcHiệnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.Tien_ich.frmTKPhauThuat_ByBS frm = new NamDinh_QLBN.Forms.Tien_ich.frmTKPhauThuat_ByBS();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                NamDinh_QLBN.Reports.BaoCaoNoiTru.PhauThuat.repPhauThuat_ByBS_KhoaThucHien rep = new NamDinh_QLBN.Reports.BaoCaoNoiTru.PhauThuat.repPhauThuat_ByBS_KhoaThucHien(frm._TNgay, frm._DNgay, frm._MaKhoa, frm._TenKhoa, frm._isTatCa, frm._isBatThuong, frm._isTrongNgay, frm._MaLoaiPT, frm._MaBS);
                rep.Show();
                return;
            }
        }

        private void tổngHợpSốLượngBNTheoKhoaThựcHiệnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.Tien_ich.frmTKPhauThuat_ByBS frm = new NamDinh_QLBN.Forms.Tien_ich.frmTKPhauThuat_ByBS();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                NamDinh_QLBN.Reports.BaoCaoNoiTru.PhauThuat.repTHPhauThuat_ByBS_KhoaThucHien rep = new NamDinh_QLBN.Reports.BaoCaoNoiTru.PhauThuat.repTHPhauThuat_ByBS_KhoaThucHien(frm._TNgay, frm._DNgay, frm._MaKhoa, frm._TenKhoa, frm._isTatCa, frm._isBatThuong, frm._isTrongNgay, frm._MaLoaiPT, frm._MaBS);
                rep.Show();
                return;
            }
        }

        private void nhậpTồnĐầuKỳToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteChildFrom();
            db.Views.VTTH.clsNhapTDK_KhoaView cls = new db.Views.VTTH.clsNhapTDK_KhoaView(this, GlobalModuls.Global.ConnectSQL,GlobalModuls.Global.glbUName);
        }

        private void nhậnVTTHTừPhòngVậtTưToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void vTTHTrongChỉĐịnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteChildFrom();
            db.Views.VTTH.clsBNSuDungView cls = new db.Views.VTTH.clsBNSuDungView(this, Global.ConnectSQL, Global.glbUName);
        }

        private void vTTHDùngChungToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteChildFrom();
            db.Views.VTTH.clsXuatSDTaiKhoaView cls = new db.Views.VTTH.clsXuatSDTaiKhoaView(this, Global.ConnectSQL, Global.glbUName);
        }

        private void danhSáchPhiếuNhậnPhiếuSửDụngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteChildFrom();
            db.Views.VTTH.clsDanhSachChungTuView cls = new db.Views.VTTH.clsDanhSachChungTuView(this, Global.ConnectSQL, Global.glbUName);
        }

        private void báoCáoSửDụngTạiKhoaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripMenuItem42_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.DuLieu.frmChiDinhDieuTri_BNSars fr = new NamDinh_QLBN.Forms.DuLieu.frmChiDinhDieuTri_BNSars();
            fr.MdiParent = this;
            fr.Show();
            fr.WindowState = FormWindowState.Maximized;
            DaleteFrom(fr);
        }

        private void nhậpTừPhiếuXuấtCủaPhòngVTDượcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteChildFrom();
            db.Views.VTTH.clsNhapVTTHTuPhongVTView cls = new db.Views.VTTH.clsNhapVTTHTuPhongVTView(this, Global.ConnectSQL, Global.glbUName);
        }

        private void nhậpTạmKhiChưaCóPhiếuXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteChildFrom();
            db.Views.VTTH.clsNhapVTTHView cls = new db.Views.VTTH.clsNhapVTTHView(this, Global.ConnectSQL, Global.glbUName);
        }

        private void mnuChuyenDoiVTTH_Click(object sender, EventArgs e)
        {
            DeleteChildFrom();
            db.Views.VTTH.clsChuyenVTView cls = new db.Views.VTTH.clsChuyenVTView(this, Global.ConnectSQL, Global.glbUName);
        }

        private void báoCáoSửDụngTạiKhoaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DeleteChildFrom();
            db.Views.VTTH.clsBaoCaoXNTTaiKhoaView cls = new db.Views.VTTH.clsBaoCaoXNTTaiKhoaView(this, Global.ConnectSQL, Global.glbUName);
        }

        private void theoiDõiVTTHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteChildFrom();
            db.Views.VTTH.clsBaoCaoTheKhoView cls = new db.Views.VTTH.clsBaoCaoTheKhoView(this, Global.ConnectSQL, Global.glbUName);
        }

        private void toolStripMenuItem43_Click(object sender, EventArgs e)
        {

        }

        private void danhSáchBệnhNhânToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.Tien_ich.frmTNgayDNgay frm = new NamDinh_QLBN.Forms.Tien_ich.frmTNgayDNgay();
            NamDinh_QLBN.Forms.In.PreviewForm frmBC;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                NamDinh_QLBN.Reports.BaoCaoNoiTru.repDSBNNhapRaVien_XuatAn rep = new NamDinh_QLBN.Reports.BaoCaoNoiTru.repDSBNNhapRaVien_XuatAn(frm._TNgay, frm._DNgay, frm._MaKhoa, frm._TenKhoa);
                rep.Run();
                frmBC = new NamDinh_QLBN.Forms.In.PreviewForm(rep.Document, this);
                frmBC.Show();
                //rep.Show();
                return;
            }
        }

        private void thốngKêTổngHợpXuấtĂnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.Tien_ich.frmTNgayDNgay frm = new NamDinh_QLBN.Forms.Tien_ich.frmTNgayDNgay();
            NamDinh_QLBN.Forms.In.PreviewForm frmBC;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                NamDinh_QLBN.Reports.BaoCaoNoiTru.repSoLenThuoc_XuatAn rep = new NamDinh_QLBN.Reports.BaoCaoNoiTru.repSoLenThuoc_XuatAn( frm._TNgay, frm._DNgay, frm._MaKhoa, frm._TenKhoa);
                rep.Run();
                frmBC = new NamDinh_QLBN.Forms.In.PreviewForm(rep.Document, this);
                frmBC.Show();
                //rep.Show();
                return;
            }
        }

        private void toolStripMenuItem44_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.Tien_ich.frmTNgayDNgay frm = new NamDinh_QLBN.Forms.Tien_ich.frmTNgayDNgay();
            NamDinh_QLBN.Forms.In.PreviewForm frmBC;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                NamDinh_QLBN.Reports.BaoCaoNoiTru.repDSBNNhapDangDieuTri_XuatAn rep = new NamDinh_QLBN.Reports.BaoCaoNoiTru.repDSBNNhapDangDieuTri_XuatAn(frm._MaKhoa, frm._TenKhoa);
                rep.Run();
                frmBC = new NamDinh_QLBN.Forms.In.PreviewForm(rep.Document, this);
                frmBC.Show();
                //rep.Show();
                return;
            }
        }

        private void thốngKêTổngHợpXuấtĂnBNĐangĐiềuTrịToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.Tien_ich.frmTNgayDNgay frm = new NamDinh_QLBN.Forms.Tien_ich.frmTNgayDNgay();
            NamDinh_QLBN.Forms.In.PreviewForm frmBC;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                NamDinh_QLBN.Reports.BaoCaoNoiTru.repSoLenThuocDangDieuTri_XuatAn rep = new NamDinh_QLBN.Reports.BaoCaoNoiTru.repSoLenThuocDangDieuTri_XuatAn(frm._MaKhoa, frm._TenKhoa);
                rep.Run();
                frmBC = new NamDinh_QLBN.Forms.In.PreviewForm(rep.Document, this);
                frmBC.Show();
                //rep.Show();
                return;
            }
        }

        private void danhSáchBệnhNhânPhẫuThuậtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.Tien_ich.frmTNgayDNgay frm = new NamDinh_QLBN.Forms.Tien_ich.frmTNgayDNgay();
            NamDinh_QLBN.Forms.In.PreviewForm frmBC;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                NamDinh_QLBN.Reports.PhauThuat.rptCaPhauThuat_byKhoa rep = new NamDinh_QLBN.Reports.PhauThuat.rptCaPhauThuat_byKhoa(frm._TNgay, frm._DNgay,frm._MaKhoa, frm._TenKhoa);
                rep.Run();
                frmBC = new NamDinh_QLBN.Forms.In.PreviewForm(rep.Document, this);
                frmBC.Show();
                //rep.Show();
                return;
            }
        }

        private void danhSáchBệnhNhânThủThuậtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.Tien_ich.frmTNgayDNgay frm = new NamDinh_QLBN.Forms.Tien_ich.frmTNgayDNgay();
            NamDinh_QLBN.Forms.In.PreviewForm frmBC;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                NamDinh_QLBN.Reports.PhauThuat.rptCaThuThuat_byKhoa rep = new NamDinh_QLBN.Reports.PhauThuat.rptCaThuThuat_byKhoa(frm._TNgay, frm._DNgay, frm._MaKhoa, frm._TenKhoa);
                rep.Run();
                frmBC = new NamDinh_QLBN.Forms.In.PreviewForm(rep.Document, this);
                frmBC.Show();
                return;
            }
        }

        private void bảngKêSốCaLàmThủThuậtTheoThờiGianThanhToánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.DuLieu.frmBangKeSoCaThuThuat_Thanhtoan frm = new NamDinh_QLBN.Forms.DuLieu.frmBangKeSoCaThuThuat_Thanhtoan();
            frm.MdiParent = this;
            frm.Show();
        }

        private void bảngThanhToánTiềnThủThuậtTheoThờiGianThanhToánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.DuLieu.frmPhuCapThuThuat_ThanhToan frm = new NamDinh_QLBN.Forms.DuLieu.frmPhuCapThuThuat_ThanhToan();
            frm.MdiParent = this;
            frm.Show();
        }

        private void bảngKêSốCaLàmPhẫuThuậtTheoThờiGianThanhToánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.DuLieu.frmBangKeSoCaPhauThuat_Thanhtoan frm = new NamDinh_QLBN.Forms.DuLieu.frmBangKeSoCaPhauThuat_Thanhtoan();
            frm.MdiParent = this;
            frm.Show();
        }

        private void toolStripMenuItem45_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.DuLieu.frmPhuCapPhauThuat_ThanhToan frm = new NamDinh_QLBN.Forms.DuLieu.frmPhuCapPhauThuat_ThanhToan();
            frm.MdiParent = this;
            frm.Show();
        }

        private void thốngKêChiPhíCLSTheoKhoaThựcHiệnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.Tien_ich.frmTNgayDNgayByLoaiDV frm = new NamDinh_QLBN.Forms.Tien_ich.frmTNgayDNgayByLoaiDV("C5%");
            if (frm.ShowDialog() == DialogResult.OK)
            {
                NamDinh_QLBN.Reports.BaoCaoNoiTru.CanLamSang.repCLS_ByKhoaThucHien rep = new NamDinh_QLBN.Reports.BaoCaoNoiTru.CanLamSang.repCLS_ByKhoaThucHien(frm._TNgay, frm._DNgay, frm._MaKhoa, frm._TenKhoa, frm._isTatCa, frm._isBatThuong, frm._isTrongNgay, frm._Like, frm._MaLoaiCLS, frm._MaBS);
                rep.Show();
                return;
            }
        }

        private void tổngHợpChiPhíCLSTheoKhoaThựcHiệnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.Tien_ich.frmTNgayDNgayByLoaiDV frm = new NamDinh_QLBN.Forms.Tien_ich.frmTNgayDNgayByLoaiDV("C5%");
            if (frm.ShowDialog() == DialogResult.OK)
            {
                NamDinh_QLBN.Reports.BaoCaoNoiTru.CanLamSang.repCLS_TongHopByKhoaThucHien rep = new NamDinh_QLBN.Reports.BaoCaoNoiTru.CanLamSang.repCLS_TongHopByKhoaThucHien(frm._TNgay, frm._DNgay, frm._MaKhoa, frm._TenKhoa, frm._isTatCa, frm._isBatThuong, frm._isTrongNgay, frm._Like, frm._MaLoaiCLS, frm._MaBS);
                rep.Show();
                return;
            }
        }

        private void chiTiêtBênhNhânTheoGiươngBênhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.DuLieu.frmSoDoGiuongBenh frm = new NamDinh_QLBN.Forms.DuLieu.frmSoDoGiuongBenh();
            frm.Show();
        }

        private void toolStripMenuItem46_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.In.frmPhieuLinhThuoc_SuaDongY fr = new NamDinh_QLBN.Forms.In.frmPhieuLinhThuoc_SuaDongY();
            fr.MdiParent = this;
            DaleteFrom(fr);
            fr.Show();
            DaleteFrom(fr);
        }

        private void toolStripMenuItem47_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.In.frmInSoLinhThuoc_SuaOKhoaDongY fr = new NamDinh_QLBN.Forms.In.frmInSoLinhThuoc_SuaOKhoaDongY();
            fr.MdiParent = this;
            fr.Show();
            DaleteFrom(fr);
        }

        //private void timer1_Tick(object sender, EventArgs e)
        //{
        //    string s = "";
        //    System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
        //    SQLCmd.Connection = Global.ConnectSQL;
        //    SQLCmd.CommandText = "select FileVersion from NamDinh_Sysdb.dbo.APPLICATION_FILES where FileName='NamDinh_QLBN.exe' ";
        //    s=SQLCmd.ExecuteScalar().ToString();
        //    if(this.Tag.ToString()!= s)
        //    {
        //        if (MessageBox.Show("Có phiên bản mới, bạn có thoát ra để cập nhật phần mềm không?", "Thông báo",  MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        //            this.Close();
        //    }
        //}
    }
}
