using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using GlobalModuls;

namespace NamDinh_QLBN.Forms.DuLieu
{
	/// <summary>
	/// Summary description for frmCapNhatBenhNhan.
	/// </summary>
	public class frmCapNhatBenhNhan : System.Windows.Forms.Form
    {
		private C1.Win.C1FlexGrid.C1FlexGrid fgDanhSach;
		private DevExpress.XtraEditors.SimpleButton cmdXoa;
		private DevExpress.XtraEditors.SimpleButton cmdThoat;
        private DevExpress.XtraEditors.SimpleButton cmdGhi;
		internal C1.Win.C1List.C1Combo cmbKhoa;
		private System.Windows.Forms.Label label16;

        //private string MaBenhNhan ="";
        private System.Windows.Forms.Label lblListTitle;
		private System.Windows.Forms.RadioButton rdChuaVV;
        private System.Windows.Forms.RadioButton rdDaVV;
        private Label label22;
        internal C1.Win.C1List.C1Combo cmbGiuong;
        private Label label21;
        internal C1.Win.C1List.C1Combo cmbBuong;
        private GroupBox groupBox3;
        private Label lblICD_KhoaDT;
        private TextBox txtICD_KhoaDT;
        private Label lblICD_PK;
        private TextBox txtICD_PK;
        private Label label24;
        private Label label23;
        private GroupBox groupBox1;
        private TextBox txtSoTheBHYT;
        private Label label17;
        internal C1.Win.C1List.C1Combo cmbDoiTuong;
        private Label lblLanVV;
        private Label label15;
        private TextBox txtDiaChi;
        private TextBox txtLienHe;
        private TextBox txtChucVu;
        internal C1.Win.C1List.C1Combo cmbTinh_TP;
        private Label label18;
        private Label label11;
        private Label label8;
        private Label label5;
        private Label lblMaBN;
        private Label label14;
        internal C1.Win.C1List.C1Combo cmbDonVi;
        private TextBox txtTuoi;
        private TextBox txtHoTen;
        private Label label10;
        internal C1.Win.C1List.C1Combo cmbCapBac;
        private Label label7;
        internal C1.Win.C1List.C1Combo cmbDanToc;
        private Label label6;
        internal C1.Win.C1List.C1Combo cmbGioiTinh;
        private Label label12;
        private Label label3;
        private Label label2;
        private Label label9;
        private GroupBox groupBox2;
        private Label lblKhoa;
        private Label label13;
        private C1.Win.C1Input.C1DateEdit txtNgayVaoVien;
        private Label label19;
        internal C1.Win.C1List.C1Combo cmbHinhThucVV;
        private Label label20;
        private C1.Win.C1Input.C1DateEdit txtNgayVaoKhoa;
        private Label label1;
        internal C1.Win.C1List.C1Combo cmbMucAn;
        private Label label4;
        private Label txtSoHSBA;//ma benh nhan lay tu phong kham

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmCapNhatBenhNhan()
		{
			//
			// Required for Windows Form Designer support
			//
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
				if(components != null)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCapNhatBenhNhan));
            C1.Win.C1List.Style style1 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style2 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style3 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style4 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style5 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style6 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style7 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style8 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style9 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style10 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style11 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style12 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style13 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style14 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style15 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style16 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style17 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style18 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style19 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style20 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style21 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style22 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style23 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style24 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style25 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style26 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style27 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style28 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style29 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style30 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style31 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style32 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style33 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style34 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style35 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style36 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style37 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style38 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style39 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style40 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style41 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style42 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style43 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style44 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style45 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style46 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style47 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style48 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style49 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style50 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style51 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style52 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style53 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style54 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style55 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style56 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style57 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style58 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style59 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style60 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style61 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style62 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style63 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style64 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style65 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style66 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style67 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style68 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style69 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style70 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style71 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style72 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style73 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style74 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style75 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style76 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style77 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style78 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style79 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style80 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style81 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style82 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style83 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style84 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style85 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style86 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style87 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style88 = new C1.Win.C1List.Style();
            this.fgDanhSach = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.cmbKhoa = new C1.Win.C1List.C1Combo();
            this.label16 = new System.Windows.Forms.Label();
            this.lblListTitle = new System.Windows.Forms.Label();
            this.rdChuaVV = new System.Windows.Forms.RadioButton();
            this.rdDaVV = new System.Windows.Forms.RadioButton();
            this.label22 = new System.Windows.Forms.Label();
            this.cmbGiuong = new C1.Win.C1List.C1Combo();
            this.label21 = new System.Windows.Forms.Label();
            this.cmbBuong = new C1.Win.C1List.C1Combo();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblICD_KhoaDT = new System.Windows.Forms.Label();
            this.txtICD_KhoaDT = new System.Windows.Forms.TextBox();
            this.lblICD_PK = new System.Windows.Forms.Label();
            this.txtICD_PK = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSoHSBA = new System.Windows.Forms.Label();
            this.txtSoTheBHYT = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.cmbDoiTuong = new C1.Win.C1List.C1Combo();
            this.lblLanVV = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.txtLienHe = new System.Windows.Forms.TextBox();
            this.txtChucVu = new System.Windows.Forms.TextBox();
            this.cmbTinh_TP = new C1.Win.C1List.C1Combo();
            this.label18 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblMaBN = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.cmbDonVi = new C1.Win.C1List.C1Combo();
            this.txtTuoi = new System.Windows.Forms.TextBox();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbCapBac = new C1.Win.C1List.C1Combo();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbDanToc = new C1.Win.C1List.C1Combo();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbGioiTinh = new C1.Win.C1List.C1Combo();
            this.label12 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbMucAn = new C1.Win.C1List.C1Combo();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNgayVaoKhoa = new C1.Win.C1Input.C1DateEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.lblKhoa = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtNgayVaoVien = new C1.Win.C1Input.C1DateEdit();
            this.label19 = new System.Windows.Forms.Label();
            this.cmbHinhThucVV = new C1.Win.C1List.C1Combo();
            this.label20 = new System.Windows.Forms.Label();
            this.cmdXoa = new DevExpress.XtraEditors.SimpleButton();
            this.cmdThoat = new DevExpress.XtraEditors.SimpleButton();
            this.cmdGhi = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.fgDanhSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKhoa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbGiuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBuong)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDoiTuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTinh_TP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDonVi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCapBac)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDanToc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbGioiTinh)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMucAn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNgayVaoKhoa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNgayVaoVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbHinhThucVV)).BeginInit();
            this.SuspendLayout();
            // 
            // fgDanhSach
            // 
            this.fgDanhSach.AllowDelete = true;
            this.fgDanhSach.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.fgDanhSach.AllowEditing = false;
            this.fgDanhSach.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.fgDanhSach.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Light3D;
            this.fgDanhSach.ColumnInfo = resources.GetString("fgDanhSach.ColumnInfo");
            this.fgDanhSach.ExtendLastCol = true;
            this.fgDanhSach.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid;
            this.fgDanhSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fgDanhSach.Location = new System.Drawing.Point(3, 72);
            this.fgDanhSach.Name = "fgDanhSach";
            this.fgDanhSach.Rows.Count = 1;
            this.fgDanhSach.Rows.MinSize = 20;
            this.fgDanhSach.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
            this.fgDanhSach.ShowCursor = true;
            this.fgDanhSach.Size = new System.Drawing.Size(405, 448);
            this.fgDanhSach.Styles = new C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("fgDanhSach.Styles"));
            this.fgDanhSach.TabIndex = 2;
            this.fgDanhSach.AfterSelChange += new C1.Win.C1FlexGrid.RangeEventHandler(this.fgDanhSach_AfterSelChange);
            // 
            // cmbKhoa
            // 
            this.cmbKhoa.AddItemSeparator = ';';
            this.cmbKhoa.AllowColMove = false;
            this.cmbKhoa.AllowRowSizing = C1.Win.C1List.RowSizingEnum.AllRows;
            this.cmbKhoa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbKhoa.AutoCompletion = true;
            this.cmbKhoa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cmbKhoa.Caption = "";
            this.cmbKhoa.CaptionHeight = 17;
            this.cmbKhoa.CaptionStyle = style1;
            this.cmbKhoa.CaptionVisible = false;
            this.cmbKhoa.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cmbKhoa.ColumnCaptionHeight = 17;
            this.cmbKhoa.ColumnFooterHeight = 17;
            this.cmbKhoa.ColumnHeaders = false;
            this.cmbKhoa.ContentHeight = 16;
            this.cmbKhoa.DataMode = C1.Win.C1List.DataModeEnum.AddItem;
            this.cmbKhoa.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cmbKhoa.DefColWidth = 30;
            this.cmbKhoa.DisplayMember = "Danh mục";
            this.cmbKhoa.EditorBackColor = System.Drawing.Color.White;
            this.cmbKhoa.EditorFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbKhoa.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbKhoa.EditorHeight = 16;
            this.cmbKhoa.EvenRowStyle = style2;
            this.cmbKhoa.ExtendRightColumn = true;
            this.cmbKhoa.FlatStyle = C1.Win.C1List.FlatModeEnum.Popup;
            this.cmbKhoa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbKhoa.FooterStyle = style3;
            this.cmbKhoa.GapHeight = 2;
            this.cmbKhoa.HeadingStyle = style4;
            this.cmbKhoa.HighLightRowStyle = style5;
            this.cmbKhoa.ItemHeight = 15;
            this.cmbKhoa.Location = new System.Drawing.Point(81, 3);
            this.cmbKhoa.MatchCol = C1.Win.C1List.MatchColEnum.AllCols;
            this.cmbKhoa.MatchEntryTimeout = ((long)(2000));
            this.cmbKhoa.MaxDropDownItems = ((short)(10));
            this.cmbKhoa.MaxLength = 32767;
            this.cmbKhoa.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cmbKhoa.Name = "cmbKhoa";
            this.cmbKhoa.OddRowStyle = style6;
            this.cmbKhoa.PartialRightColumn = false;
            this.cmbKhoa.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.cmbKhoa.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.cmbKhoa.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cmbKhoa.SelectedStyle = style7;
            this.cmbKhoa.Size = new System.Drawing.Size(327, 20);
            this.cmbKhoa.Style = style8;
            this.cmbKhoa.TabIndex = 1;
            this.cmbKhoa.TextChanged += new System.EventHandler(this.cmbKhoa_TextChanged);
            this.cmbKhoa.PropBag = resources.GetString("cmbKhoa.PropBag");
            // 
            // label16
            // 
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label16.Location = new System.Drawing.Point(0, 6);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(78, 15);
            this.label16.TabIndex = 1;
            this.label16.Text = "*Vào khoa";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblListTitle
            // 
            this.lblListTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblListTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblListTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListTitle.Location = new System.Drawing.Point(3, 24);
            this.lblListTitle.Name = "lblListTitle";
            this.lblListTitle.Size = new System.Drawing.Size(405, 21);
            this.lblListTitle.TabIndex = 107;
            this.lblListTitle.Text = "DANH SÁCH BỆNH NHÂN";
            this.lblListTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rdChuaVV
            // 
            this.rdChuaVV.Checked = true;
            this.rdChuaVV.Location = new System.Drawing.Point(3, 48);
            this.rdChuaVV.Name = "rdChuaVV";
            this.rdChuaVV.Size = new System.Drawing.Size(139, 18);
            this.rdChuaVV.TabIndex = 112;
            this.rdChuaVV.TabStop = true;
            this.rdChuaVV.Text = "Đang chờ vào Khoa";
            this.rdChuaVV.CheckedChanged += new System.EventHandler(this.rdChuaVV_CheckedChanged);
            // 
            // rdDaVV
            // 
            this.rdDaVV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdDaVV.Location = new System.Drawing.Point(277, 48);
            this.rdDaVV.Name = "rdDaVV";
            this.rdDaVV.Size = new System.Drawing.Size(131, 18);
            this.rdDaVV.TabIndex = 113;
            this.rdDaVV.Text = "Đang điều trị tại khoa";
            // 
            // label22
            // 
            this.label22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label22.Location = new System.Drawing.Point(278, 85);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(99, 18);
            this.label22.TabIndex = 23;
            this.label22.Text = "*Giường";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbGiuong
            // 
            this.cmbGiuong.AddItemSeparator = ';';
            this.cmbGiuong.AllowColMove = false;
            this.cmbGiuong.AllowRowSizing = C1.Win.C1List.RowSizingEnum.AllRows;
            this.cmbGiuong.AutoCompletion = true;
            this.cmbGiuong.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cmbGiuong.Caption = "";
            this.cmbGiuong.CaptionHeight = 17;
            this.cmbGiuong.CaptionStyle = style9;
            this.cmbGiuong.CaptionVisible = false;
            this.cmbGiuong.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cmbGiuong.ColumnCaptionHeight = 17;
            this.cmbGiuong.ColumnFooterHeight = 17;
            this.cmbGiuong.ColumnHeaders = false;
            this.cmbGiuong.ContentHeight = 16;
            this.cmbGiuong.DataMode = C1.Win.C1List.DataModeEnum.AddItem;
            this.cmbGiuong.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cmbGiuong.DefColWidth = 1;
            this.cmbGiuong.DisplayMember = "Danh mục";
            this.cmbGiuong.EditorBackColor = System.Drawing.Color.White;
            this.cmbGiuong.EditorFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbGiuong.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbGiuong.EditorHeight = 16;
            this.cmbGiuong.EvenRowStyle = style10;
            this.cmbGiuong.ExtendRightColumn = true;
            this.cmbGiuong.FlatStyle = C1.Win.C1List.FlatModeEnum.Popup;
            this.cmbGiuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbGiuong.FooterStyle = style11;
            this.cmbGiuong.GapHeight = 2;
            this.cmbGiuong.HeadingStyle = style12;
            this.cmbGiuong.HighLightRowStyle = style13;
            this.cmbGiuong.ItemHeight = 15;
            this.cmbGiuong.Location = new System.Drawing.Point(388, 83);
            this.cmbGiuong.MatchCol = C1.Win.C1List.MatchColEnum.AllCols;
            this.cmbGiuong.MatchEntryTimeout = ((long)(2000));
            this.cmbGiuong.MaxDropDownItems = ((short)(10));
            this.cmbGiuong.MaxLength = 32767;
            this.cmbGiuong.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cmbGiuong.Name = "cmbGiuong";
            this.cmbGiuong.OddRowStyle = style14;
            this.cmbGiuong.PartialRightColumn = false;
            this.cmbGiuong.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.cmbGiuong.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.cmbGiuong.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cmbGiuong.SelectedStyle = style15;
            this.cmbGiuong.Size = new System.Drawing.Size(104, 20);
            this.cmbGiuong.Style = style16;
            this.cmbGiuong.TabIndex = 23;
            this.cmbGiuong.PropBag = resources.GetString("cmbGiuong.PropBag");
            // 
            // label21
            // 
            this.label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label21.Location = new System.Drawing.Point(16, 85);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(99, 18);
            this.label21.TabIndex = 22;
            this.label21.Text = "*Buồng";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbBuong
            // 
            this.cmbBuong.AddItemSeparator = ';';
            this.cmbBuong.AllowColMove = false;
            this.cmbBuong.AllowRowSizing = C1.Win.C1List.RowSizingEnum.AllRows;
            this.cmbBuong.AutoCompletion = true;
            this.cmbBuong.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cmbBuong.Caption = "";
            this.cmbBuong.CaptionHeight = 17;
            this.cmbBuong.CaptionStyle = style17;
            this.cmbBuong.CaptionVisible = false;
            this.cmbBuong.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cmbBuong.ColumnCaptionHeight = 17;
            this.cmbBuong.ColumnFooterHeight = 17;
            this.cmbBuong.ColumnHeaders = false;
            this.cmbBuong.ContentHeight = 16;
            this.cmbBuong.DataMode = C1.Win.C1List.DataModeEnum.AddItem;
            this.cmbBuong.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cmbBuong.DefColWidth = 1;
            this.cmbBuong.DisplayMember = "Danh mục";
            this.cmbBuong.EditorBackColor = System.Drawing.Color.White;
            this.cmbBuong.EditorFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBuong.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbBuong.EditorHeight = 16;
            this.cmbBuong.EvenRowStyle = style18;
            this.cmbBuong.ExtendRightColumn = true;
            this.cmbBuong.FlatStyle = C1.Win.C1List.FlatModeEnum.Popup;
            this.cmbBuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBuong.FooterStyle = style19;
            this.cmbBuong.GapHeight = 2;
            this.cmbBuong.HeadingStyle = style20;
            this.cmbBuong.HighLightRowStyle = style21;
            this.cmbBuong.ItemHeight = 15;
            this.cmbBuong.Location = new System.Drawing.Point(118, 83);
            this.cmbBuong.MatchCol = C1.Win.C1List.MatchColEnum.AllCols;
            this.cmbBuong.MatchEntryTimeout = ((long)(2000));
            this.cmbBuong.MaxDropDownItems = ((short)(10));
            this.cmbBuong.MaxLength = 32767;
            this.cmbBuong.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cmbBuong.Name = "cmbBuong";
            this.cmbBuong.OddRowStyle = style22;
            this.cmbBuong.PartialRightColumn = false;
            this.cmbBuong.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.cmbBuong.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.cmbBuong.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cmbBuong.SelectedStyle = style23;
            this.cmbBuong.Size = new System.Drawing.Size(192, 20);
            this.cmbBuong.Style = style24;
            this.cmbBuong.TabIndex = 22;
            this.cmbBuong.TextChanged += new System.EventHandler(this.cmbBuong_TextChanged);
            this.cmbBuong.PropBag = resources.GetString("cmbBuong.PropBag");
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.BackColor = System.Drawing.Color.PowderBlue;
            this.groupBox3.Controls.Add(this.lblICD_KhoaDT);
            this.groupBox3.Controls.Add(this.txtICD_KhoaDT);
            this.groupBox3.Controls.Add(this.lblICD_PK);
            this.groupBox3.Controls.Add(this.txtICD_PK);
            this.groupBox3.Controls.Add(this.label24);
            this.groupBox3.Controls.Add(this.label23);
            this.groupBox3.Location = new System.Drawing.Point(414, 416);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(498, 69);
            this.groupBox3.TabIndex = 25;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "CHẨN ĐOÁN";
            // 
            // lblICD_KhoaDT
            // 
            this.lblICD_KhoaDT.BackColor = System.Drawing.Color.White;
            this.lblICD_KhoaDT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblICD_KhoaDT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblICD_KhoaDT.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblICD_KhoaDT.Location = new System.Drawing.Point(191, 41);
            this.lblICD_KhoaDT.Name = "lblICD_KhoaDT";
            this.lblICD_KhoaDT.Size = new System.Drawing.Size(299, 20);
            this.lblICD_KhoaDT.TabIndex = 136;
            this.lblICD_KhoaDT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtICD_KhoaDT
            // 
            this.txtICD_KhoaDT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtICD_KhoaDT.Location = new System.Drawing.Point(118, 41);
            this.txtICD_KhoaDT.Name = "txtICD_KhoaDT";
            this.txtICD_KhoaDT.Size = new System.Drawing.Size(70, 20);
            this.txtICD_KhoaDT.TabIndex = 27;
            this.txtICD_KhoaDT.Validating += new System.ComponentModel.CancelEventHandler(this.txtICD_KhoaDT_Validating);
            // 
            // lblICD_PK
            // 
            this.lblICD_PK.BackColor = System.Drawing.Color.White;
            this.lblICD_PK.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblICD_PK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblICD_PK.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblICD_PK.Location = new System.Drawing.Point(191, 19);
            this.lblICD_PK.Name = "lblICD_PK";
            this.lblICD_PK.Size = new System.Drawing.Size(299, 20);
            this.lblICD_PK.TabIndex = 134;
            this.lblICD_PK.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtICD_PK
            // 
            this.txtICD_PK.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtICD_PK.Location = new System.Drawing.Point(118, 19);
            this.txtICD_PK.Name = "txtICD_PK";
            this.txtICD_PK.ReadOnly = true;
            this.txtICD_PK.Size = new System.Drawing.Size(70, 20);
            this.txtICD_PK.TabIndex = 26;
            // 
            // label24
            // 
            this.label24.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label24.Location = new System.Drawing.Point(6, 19);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(106, 19);
            this.label24.TabIndex = 26;
            this.label24.Text = "KKB, Cấp cứu";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label23
            // 
            this.label23.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label23.Location = new System.Drawing.Point(6, 45);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(106, 19);
            this.label23.TabIndex = 27;
            this.label23.Text = "Khoa điều trị";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.PowderBlue;
            this.groupBox1.Controls.Add(this.txtSoHSBA);
            this.groupBox1.Controls.Add(this.txtSoTheBHYT);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.cmbDoiTuong);
            this.groupBox1.Controls.Add(this.lblLanVV);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.txtDiaChi);
            this.groupBox1.Controls.Add(this.txtLienHe);
            this.groupBox1.Controls.Add(this.txtChucVu);
            this.groupBox1.Controls.Add(this.cmbTinh_TP);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lblMaBN);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.cmbDonVi);
            this.groupBox1.Controls.Add(this.txtTuoi);
            this.groupBox1.Controls.Add(this.txtHoTen);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.cmbCapBac);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cmbDanToc);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cmbGioiTinh);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Location = new System.Drawing.Point(414, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(498, 260);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "HÀNH CHÍNH";
            // 
            // txtSoHSBA
            // 
            this.txtSoHSBA.BackColor = System.Drawing.Color.White;
            this.txtSoHSBA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtSoHSBA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoHSBA.ForeColor = System.Drawing.Color.Red;
            this.txtSoHSBA.Location = new System.Drawing.Point(354, 13);
            this.txtSoHSBA.Name = "txtSoHSBA";
            this.txtSoHSBA.Size = new System.Drawing.Size(97, 21);
            this.txtSoHSBA.TabIndex = 125;
            this.txtSoHSBA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSoTheBHYT
            // 
            this.txtSoTheBHYT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSoTheBHYT.Location = new System.Drawing.Point(118, 212);
            this.txtSoTheBHYT.Name = "txtSoTheBHYT";
            this.txtSoTheBHYT.Size = new System.Drawing.Size(179, 20);
            this.txtSoTheBHYT.TabIndex = 15;
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(19, 217);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(93, 15);
            this.label17.TabIndex = 15;
            this.label17.Text = "Số thẻ BHYT";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbDoiTuong
            // 
            this.cmbDoiTuong.AddItemSeparator = ';';
            this.cmbDoiTuong.AllowColMove = false;
            this.cmbDoiTuong.AllowRowSizing = C1.Win.C1List.RowSizingEnum.AllRows;
            this.cmbDoiTuong.AutoCompletion = true;
            this.cmbDoiTuong.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cmbDoiTuong.Caption = "";
            this.cmbDoiTuong.CaptionHeight = 17;
            this.cmbDoiTuong.CaptionStyle = style25;
            this.cmbDoiTuong.CaptionVisible = false;
            this.cmbDoiTuong.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cmbDoiTuong.ColumnCaptionHeight = 17;
            this.cmbDoiTuong.ColumnFooterHeight = 17;
            this.cmbDoiTuong.ColumnHeaders = false;
            this.cmbDoiTuong.ContentHeight = 16;
            this.cmbDoiTuong.DataMode = C1.Win.C1List.DataModeEnum.AddItem;
            this.cmbDoiTuong.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cmbDoiTuong.DefColWidth = 30;
            this.cmbDoiTuong.DisplayMember = "Danh mục";
            this.cmbDoiTuong.EditorBackColor = System.Drawing.Color.White;
            this.cmbDoiTuong.EditorFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDoiTuong.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbDoiTuong.EditorHeight = 16;
            this.cmbDoiTuong.EvenRowStyle = style26;
            this.cmbDoiTuong.ExtendRightColumn = true;
            this.cmbDoiTuong.FlatStyle = C1.Win.C1List.FlatModeEnum.Popup;
            this.cmbDoiTuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDoiTuong.FooterStyle = style27;
            this.cmbDoiTuong.GapHeight = 2;
            this.cmbDoiTuong.HeadingStyle = style28;
            this.cmbDoiTuong.HighLightRowStyle = style29;
            this.cmbDoiTuong.ItemHeight = 15;
            this.cmbDoiTuong.Location = new System.Drawing.Point(118, 191);
            this.cmbDoiTuong.MatchCol = C1.Win.C1List.MatchColEnum.AllCols;
            this.cmbDoiTuong.MatchEntryTimeout = ((long)(2000));
            this.cmbDoiTuong.MaxDropDownItems = ((short)(10));
            this.cmbDoiTuong.MaxLength = 32767;
            this.cmbDoiTuong.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cmbDoiTuong.Name = "cmbDoiTuong";
            this.cmbDoiTuong.OddRowStyle = style30;
            this.cmbDoiTuong.PartialRightColumn = false;
            this.cmbDoiTuong.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.cmbDoiTuong.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.cmbDoiTuong.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cmbDoiTuong.SelectedStyle = style31;
            this.cmbDoiTuong.Size = new System.Drawing.Size(179, 20);
            this.cmbDoiTuong.Style = style32;
            this.cmbDoiTuong.TabIndex = 14;
            this.cmbDoiTuong.PropBag = resources.GetString("cmbDoiTuong.PropBag");
            // 
            // lblLanVV
            // 
            this.lblLanVV.BackColor = System.Drawing.Color.White;
            this.lblLanVV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLanVV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLanVV.ForeColor = System.Drawing.Color.Red;
            this.lblLanVV.Location = new System.Drawing.Point(457, 14);
            this.lblLanVV.Name = "lblLanVV";
            this.lblLanVV.Size = new System.Drawing.Size(30, 21);
            this.lblLanVV.TabIndex = 120;
            this.lblLanVV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblLanVV.Visible = false;
            // 
            // label15
            // 
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label15.Location = new System.Drawing.Point(19, 191);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(93, 20);
            this.label15.TabIndex = 14;
            this.label15.Text = "*Đối tượng";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDiaChi.Location = new System.Drawing.Point(118, 148);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(372, 20);
            this.txtDiaChi.TabIndex = 12;
            // 
            // txtLienHe
            // 
            this.txtLienHe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLienHe.Location = new System.Drawing.Point(118, 234);
            this.txtLienHe.Name = "txtLienHe";
            this.txtLienHe.Size = new System.Drawing.Size(372, 20);
            this.txtLienHe.TabIndex = 16;
            // 
            // txtChucVu
            // 
            this.txtChucVu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtChucVu.Location = new System.Drawing.Point(118, 105);
            this.txtChucVu.Name = "txtChucVu";
            this.txtChucVu.Size = new System.Drawing.Size(234, 20);
            this.txtChucVu.TabIndex = 10;
            // 
            // cmbTinh_TP
            // 
            this.cmbTinh_TP.AddItemSeparator = ';';
            this.cmbTinh_TP.AllowColMove = false;
            this.cmbTinh_TP.AllowRowSizing = C1.Win.C1List.RowSizingEnum.AllRows;
            this.cmbTinh_TP.AutoCompletion = true;
            this.cmbTinh_TP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cmbTinh_TP.Caption = "";
            this.cmbTinh_TP.CaptionHeight = 17;
            this.cmbTinh_TP.CaptionStyle = style33;
            this.cmbTinh_TP.CaptionVisible = false;
            this.cmbTinh_TP.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cmbTinh_TP.ColumnCaptionHeight = 17;
            this.cmbTinh_TP.ColumnFooterHeight = 17;
            this.cmbTinh_TP.ColumnHeaders = false;
            this.cmbTinh_TP.ContentHeight = 16;
            this.cmbTinh_TP.DataMode = C1.Win.C1List.DataModeEnum.AddItem;
            this.cmbTinh_TP.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cmbTinh_TP.DefColWidth = 30;
            this.cmbTinh_TP.DisplayMember = "Danh mục";
            this.cmbTinh_TP.EditorBackColor = System.Drawing.Color.White;
            this.cmbTinh_TP.EditorFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTinh_TP.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbTinh_TP.EditorHeight = 16;
            this.cmbTinh_TP.EvenRowStyle = style34;
            this.cmbTinh_TP.ExtendRightColumn = true;
            this.cmbTinh_TP.FlatStyle = C1.Win.C1List.FlatModeEnum.Popup;
            this.cmbTinh_TP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTinh_TP.FooterStyle = style35;
            this.cmbTinh_TP.GapHeight = 2;
            this.cmbTinh_TP.HeadingStyle = style36;
            this.cmbTinh_TP.HighLightRowStyle = style37;
            this.cmbTinh_TP.ItemHeight = 15;
            this.cmbTinh_TP.Location = new System.Drawing.Point(118, 170);
            this.cmbTinh_TP.MatchCol = C1.Win.C1List.MatchColEnum.AllCols;
            this.cmbTinh_TP.MatchEntryTimeout = ((long)(2000));
            this.cmbTinh_TP.MaxDropDownItems = ((short)(10));
            this.cmbTinh_TP.MaxLength = 32767;
            this.cmbTinh_TP.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cmbTinh_TP.Name = "cmbTinh_TP";
            this.cmbTinh_TP.OddRowStyle = style38;
            this.cmbTinh_TP.PartialRightColumn = false;
            this.cmbTinh_TP.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.cmbTinh_TP.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.cmbTinh_TP.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cmbTinh_TP.SelectedStyle = style39;
            this.cmbTinh_TP.Size = new System.Drawing.Size(150, 20);
            this.cmbTinh_TP.Style = style40;
            this.cmbTinh_TP.TabIndex = 13;
            this.cmbTinh_TP.PropBag = resources.GetString("cmbTinh_TP.PropBag");
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(19, 170);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(93, 20);
            this.label18.TabIndex = 13;
            this.label18.Text = "Tỉnh, thành phố";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(19, 148);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(93, 20);
            this.label11.TabIndex = 12;
            this.label11.Text = "Địa chỉ";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(19, 234);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 20);
            this.label8.TabIndex = 16;
            this.label8.Text = "Địa chỉ liên hệ";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(19, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Chức vụ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMaBN
            // 
            this.lblMaBN.BackColor = System.Drawing.Color.White;
            this.lblMaBN.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMaBN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaBN.ForeColor = System.Drawing.Color.Red;
            this.lblMaBN.Location = new System.Drawing.Point(118, 13);
            this.lblMaBN.Name = "lblMaBN";
            this.lblMaBN.Size = new System.Drawing.Size(123, 21);
            this.lblMaBN.TabIndex = 4;
            this.lblMaBN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label14.Location = new System.Drawing.Point(16, 16);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(96, 21);
            this.label14.TabIndex = 4;
            this.label14.Text = "*Mã bệnh nhân";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbDonVi
            // 
            this.cmbDonVi.AddItemSeparator = ';';
            this.cmbDonVi.AllowColMove = false;
            this.cmbDonVi.AllowRowSizing = C1.Win.C1List.RowSizingEnum.AllRows;
            this.cmbDonVi.AutoCompletion = true;
            this.cmbDonVi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cmbDonVi.Caption = "";
            this.cmbDonVi.CaptionHeight = 17;
            this.cmbDonVi.CaptionStyle = style41;
            this.cmbDonVi.CaptionVisible = false;
            this.cmbDonVi.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cmbDonVi.ColumnCaptionHeight = 17;
            this.cmbDonVi.ColumnFooterHeight = 17;
            this.cmbDonVi.ColumnHeaders = false;
            this.cmbDonVi.ContentHeight = 16;
            this.cmbDonVi.DataMode = C1.Win.C1List.DataModeEnum.AddItem;
            this.cmbDonVi.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cmbDonVi.DefColWidth = 30;
            this.cmbDonVi.DisplayMember = "Danh mục";
            this.cmbDonVi.EditorBackColor = System.Drawing.Color.White;
            this.cmbDonVi.EditorFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDonVi.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbDonVi.EditorHeight = 16;
            this.cmbDonVi.EvenRowStyle = style42;
            this.cmbDonVi.ExtendRightColumn = true;
            this.cmbDonVi.FlatStyle = C1.Win.C1List.FlatModeEnum.Popup;
            this.cmbDonVi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDonVi.FooterStyle = style43;
            this.cmbDonVi.GapHeight = 2;
            this.cmbDonVi.HeadingStyle = style44;
            this.cmbDonVi.HighLightRowStyle = style45;
            this.cmbDonVi.ItemHeight = 15;
            this.cmbDonVi.Location = new System.Drawing.Point(118, 127);
            this.cmbDonVi.MatchCol = C1.Win.C1List.MatchColEnum.AllCols;
            this.cmbDonVi.MatchEntryTimeout = ((long)(2000));
            this.cmbDonVi.MaxDropDownItems = ((short)(10));
            this.cmbDonVi.MaxLength = 32767;
            this.cmbDonVi.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cmbDonVi.Name = "cmbDonVi";
            this.cmbDonVi.OddRowStyle = style46;
            this.cmbDonVi.PartialRightColumn = false;
            this.cmbDonVi.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.cmbDonVi.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.cmbDonVi.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cmbDonVi.SelectedStyle = style47;
            this.cmbDonVi.Size = new System.Drawing.Size(372, 20);
            this.cmbDonVi.Style = style48;
            this.cmbDonVi.TabIndex = 11;
            this.cmbDonVi.PropBag = resources.GetString("cmbDonVi.PropBag");
            // 
            // txtTuoi
            // 
            this.txtTuoi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTuoi.Location = new System.Drawing.Point(354, 39);
            this.txtTuoi.Name = "txtTuoi";
            this.txtTuoi.Size = new System.Drawing.Size(30, 20);
            this.txtTuoi.TabIndex = 6;
            // 
            // txtHoTen
            // 
            this.txtHoTen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHoTen.Location = new System.Drawing.Point(118, 40);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(195, 20);
            this.txtHoTen.TabIndex = 5;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(25, 127);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(87, 20);
            this.label10.TabIndex = 11;
            this.label10.Text = "Đơn vị";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbCapBac
            // 
            this.cmbCapBac.AddItemSeparator = ';';
            this.cmbCapBac.AllowColMove = false;
            this.cmbCapBac.AllowRowSizing = C1.Win.C1List.RowSizingEnum.AllRows;
            this.cmbCapBac.AutoCompletion = true;
            this.cmbCapBac.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cmbCapBac.Caption = "";
            this.cmbCapBac.CaptionHeight = 17;
            this.cmbCapBac.CaptionStyle = style49;
            this.cmbCapBac.CaptionVisible = false;
            this.cmbCapBac.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cmbCapBac.ColumnCaptionHeight = 17;
            this.cmbCapBac.ColumnFooterHeight = 17;
            this.cmbCapBac.ColumnHeaders = false;
            this.cmbCapBac.ContentHeight = 16;
            this.cmbCapBac.DataMode = C1.Win.C1List.DataModeEnum.AddItem;
            this.cmbCapBac.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cmbCapBac.DefColWidth = 30;
            this.cmbCapBac.DisplayMember = "Danh mục";
            this.cmbCapBac.EditorBackColor = System.Drawing.Color.White;
            this.cmbCapBac.EditorFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCapBac.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbCapBac.EditorHeight = 16;
            this.cmbCapBac.EvenRowStyle = style50;
            this.cmbCapBac.ExtendRightColumn = true;
            this.cmbCapBac.FlatStyle = C1.Win.C1List.FlatModeEnum.Popup;
            this.cmbCapBac.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCapBac.FooterStyle = style51;
            this.cmbCapBac.GapHeight = 2;
            this.cmbCapBac.HeadingStyle = style52;
            this.cmbCapBac.HighLightRowStyle = style53;
            this.cmbCapBac.ItemHeight = 15;
            this.cmbCapBac.Location = new System.Drawing.Point(118, 84);
            this.cmbCapBac.MatchCol = C1.Win.C1List.MatchColEnum.AllCols;
            this.cmbCapBac.MatchEntryTimeout = ((long)(2000));
            this.cmbCapBac.MaxDropDownItems = ((short)(10));
            this.cmbCapBac.MaxLength = 32767;
            this.cmbCapBac.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cmbCapBac.Name = "cmbCapBac";
            this.cmbCapBac.OddRowStyle = style54;
            this.cmbCapBac.PartialRightColumn = false;
            this.cmbCapBac.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.cmbCapBac.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.cmbCapBac.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cmbCapBac.SelectedStyle = style55;
            this.cmbCapBac.Size = new System.Drawing.Size(179, 20);
            this.cmbCapBac.Style = style56;
            this.cmbCapBac.TabIndex = 9;
            this.cmbCapBac.PropBag = resources.GetString("cmbCapBac.PropBag");
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(16, 84);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 15);
            this.label7.TabIndex = 9;
            this.label7.Text = "Quân hàm";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbDanToc
            // 
            this.cmbDanToc.AddItemSeparator = ';';
            this.cmbDanToc.AllowColMove = false;
            this.cmbDanToc.AllowRowSizing = C1.Win.C1List.RowSizingEnum.AllRows;
            this.cmbDanToc.AutoCompletion = true;
            this.cmbDanToc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cmbDanToc.Caption = "";
            this.cmbDanToc.CaptionHeight = 17;
            this.cmbDanToc.CaptionStyle = style57;
            this.cmbDanToc.CaptionVisible = false;
            this.cmbDanToc.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cmbDanToc.ColumnCaptionHeight = 17;
            this.cmbDanToc.ColumnFooterHeight = 17;
            this.cmbDanToc.ColumnHeaders = false;
            this.cmbDanToc.ContentHeight = 16;
            this.cmbDanToc.DataMode = C1.Win.C1List.DataModeEnum.AddItem;
            this.cmbDanToc.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cmbDanToc.DefColWidth = 30;
            this.cmbDanToc.DisplayMember = "Danh mục";
            this.cmbDanToc.EditorBackColor = System.Drawing.Color.White;
            this.cmbDanToc.EditorFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDanToc.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbDanToc.EditorHeight = 16;
            this.cmbDanToc.EvenRowStyle = style58;
            this.cmbDanToc.ExtendRightColumn = true;
            this.cmbDanToc.FlatStyle = C1.Win.C1List.FlatModeEnum.Popup;
            this.cmbDanToc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDanToc.FooterStyle = style59;
            this.cmbDanToc.GapHeight = 2;
            this.cmbDanToc.HeadingStyle = style60;
            this.cmbDanToc.HighLightRowStyle = style61;
            this.cmbDanToc.ItemHeight = 15;
            this.cmbDanToc.Location = new System.Drawing.Point(354, 61);
            this.cmbDanToc.MatchCol = C1.Win.C1List.MatchColEnum.AllCols;
            this.cmbDanToc.MatchEntryTimeout = ((long)(2000));
            this.cmbDanToc.MaxDropDownItems = ((short)(10));
            this.cmbDanToc.MaxLength = 32767;
            this.cmbDanToc.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cmbDanToc.Name = "cmbDanToc";
            this.cmbDanToc.OddRowStyle = style62;
            this.cmbDanToc.PartialRightColumn = false;
            this.cmbDanToc.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.cmbDanToc.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.cmbDanToc.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cmbDanToc.SelectedStyle = style63;
            this.cmbDanToc.Size = new System.Drawing.Size(135, 20);
            this.cmbDanToc.Style = style64;
            this.cmbDanToc.TabIndex = 8;
            this.cmbDanToc.PropBag = resources.GetString("cmbDanToc.PropBag");
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(250, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 15);
            this.label6.TabIndex = 8;
            this.label6.Text = "Dân tộc";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbGioiTinh
            // 
            this.cmbGioiTinh.AddItemSeparator = ';';
            this.cmbGioiTinh.AllowColMove = false;
            this.cmbGioiTinh.AllowRowSizing = C1.Win.C1List.RowSizingEnum.AllRows;
            this.cmbGioiTinh.AutoCompletion = true;
            this.cmbGioiTinh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cmbGioiTinh.Caption = "";
            this.cmbGioiTinh.CaptionHeight = 17;
            this.cmbGioiTinh.CaptionStyle = style65;
            this.cmbGioiTinh.CaptionVisible = false;
            this.cmbGioiTinh.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cmbGioiTinh.ColumnCaptionHeight = 17;
            this.cmbGioiTinh.ColumnFooterHeight = 17;
            this.cmbGioiTinh.ColumnHeaders = false;
            this.cmbGioiTinh.ContentHeight = 16;
            this.cmbGioiTinh.DataMode = C1.Win.C1List.DataModeEnum.AddItem;
            this.cmbGioiTinh.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cmbGioiTinh.DefColWidth = 30;
            this.cmbGioiTinh.DisplayMember = "Danh mục";
            this.cmbGioiTinh.EditorBackColor = System.Drawing.Color.White;
            this.cmbGioiTinh.EditorFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbGioiTinh.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbGioiTinh.EditorHeight = 16;
            this.cmbGioiTinh.EvenRowStyle = style66;
            this.cmbGioiTinh.ExtendRightColumn = true;
            this.cmbGioiTinh.FlatStyle = C1.Win.C1List.FlatModeEnum.Popup;
            this.cmbGioiTinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbGioiTinh.FooterStyle = style67;
            this.cmbGioiTinh.GapHeight = 2;
            this.cmbGioiTinh.HeadingStyle = style68;
            this.cmbGioiTinh.HighLightRowStyle = style69;
            this.cmbGioiTinh.ItemHeight = 15;
            this.cmbGioiTinh.Location = new System.Drawing.Point(118, 62);
            this.cmbGioiTinh.MatchCol = C1.Win.C1List.MatchColEnum.AllCols;
            this.cmbGioiTinh.MatchEntryTimeout = ((long)(2000));
            this.cmbGioiTinh.MaxDropDownItems = ((short)(10));
            this.cmbGioiTinh.MaxLength = 32767;
            this.cmbGioiTinh.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cmbGioiTinh.Name = "cmbGioiTinh";
            this.cmbGioiTinh.OddRowStyle = style70;
            this.cmbGioiTinh.PartialRightColumn = false;
            this.cmbGioiTinh.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.cmbGioiTinh.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.cmbGioiTinh.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cmbGioiTinh.SelectedStyle = style71;
            this.cmbGioiTinh.Size = new System.Drawing.Size(117, 20);
            this.cmbGioiTinh.Style = style72;
            this.cmbGioiTinh.TabIndex = 7;
            this.cmbGioiTinh.PropBag = resources.GetString("cmbGioiTinh.PropBag");
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(16, 66);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(96, 15);
            this.label12.TabIndex = 7;
            this.label12.Text = "Giới tính";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(319, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Tuổi";
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(16, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "*Họ tên BN";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label9.Location = new System.Drawing.Point(247, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(102, 15);
            this.label9.TabIndex = 124;
            this.label9.Text = "*Số HSBA";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.BackColor = System.Drawing.Color.PowderBlue;
            this.groupBox2.Controls.Add(this.cmbMucAn);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtNgayVaoKhoa);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.lblKhoa);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.cmbGiuong);
            this.groupBox2.Controls.Add(this.txtNgayVaoVien);
            this.groupBox2.Controls.Add(this.cmbBuong);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.cmbHinhThucVV);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Location = new System.Drawing.Point(414, 269);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(498, 141);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "QUẢN LÝ NGƯỜI BỆNH";
            // 
            // cmbMucAn
            // 
            this.cmbMucAn.AddItemSeparator = ';';
            this.cmbMucAn.AllowColMove = false;
            this.cmbMucAn.AllowRowSizing = C1.Win.C1List.RowSizingEnum.AllRows;
            this.cmbMucAn.AutoCompletion = true;
            this.cmbMucAn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cmbMucAn.Caption = "";
            this.cmbMucAn.CaptionHeight = 17;
            this.cmbMucAn.CaptionStyle = style73;
            this.cmbMucAn.CaptionVisible = false;
            this.cmbMucAn.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cmbMucAn.ColumnCaptionHeight = 17;
            this.cmbMucAn.ColumnFooterHeight = 17;
            this.cmbMucAn.ColumnHeaders = false;
            this.cmbMucAn.ContentHeight = 16;
            this.cmbMucAn.DataMode = C1.Win.C1List.DataModeEnum.AddItem;
            this.cmbMucAn.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cmbMucAn.DefColWidth = 1;
            this.cmbMucAn.DisplayMember = "Danh mục";
            this.cmbMucAn.EditorBackColor = System.Drawing.Color.White;
            this.cmbMucAn.EditorFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMucAn.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbMucAn.EditorHeight = 16;
            this.cmbMucAn.EvenRowStyle = style74;
            this.cmbMucAn.ExtendRightColumn = true;
            this.cmbMucAn.FlatStyle = C1.Win.C1List.FlatModeEnum.Popup;
            this.cmbMucAn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMucAn.FooterStyle = style75;
            this.cmbMucAn.GapHeight = 2;
            this.cmbMucAn.HeadingStyle = style76;
            this.cmbMucAn.HighLightRowStyle = style77;
            this.cmbMucAn.ItemHeight = 15;
            this.cmbMucAn.Location = new System.Drawing.Point(118, 106);
            this.cmbMucAn.MatchCol = C1.Win.C1List.MatchColEnum.AllCols;
            this.cmbMucAn.MatchEntryTimeout = ((long)(2000));
            this.cmbMucAn.MaxDropDownItems = ((short)(10));
            this.cmbMucAn.MaxLength = 32767;
            this.cmbMucAn.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cmbMucAn.Name = "cmbMucAn";
            this.cmbMucAn.OddRowStyle = style78;
            this.cmbMucAn.PartialRightColumn = false;
            this.cmbMucAn.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.cmbMucAn.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.cmbMucAn.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cmbMucAn.SelectedStyle = style79;
            this.cmbMucAn.Size = new System.Drawing.Size(218, 20);
            this.cmbMucAn.Style = style80;
            this.cmbMucAn.TabIndex = 24;
            this.cmbMucAn.PropBag = resources.GetString("cmbMucAn.PropBag");
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(16, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 18);
            this.label4.TabIndex = 24;
            this.label4.Text = "*Mức ăn";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNgayVaoKhoa
            // 
            this.txtNgayVaoKhoa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNgayVaoKhoa.Culture = 1066;
            this.txtNgayVaoKhoa.CustomFormat = "dd/MM/yyyy HH:mm";
            this.txtNgayVaoKhoa.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
            this.txtNgayVaoKhoa.Location = new System.Drawing.Point(359, 62);
            this.txtNgayVaoKhoa.Name = "txtNgayVaoKhoa";
            this.txtNgayVaoKhoa.Size = new System.Drawing.Size(133, 18);
            this.txtNgayVaoKhoa.TabIndex = 21;
            this.txtNgayVaoKhoa.Tag = null;
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(247, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 19);
            this.label1.TabIndex = 21;
            this.label1.Text = "*Ngày, giờ vào khoa";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblKhoa
            // 
            this.lblKhoa.BackColor = System.Drawing.Color.White;
            this.lblKhoa.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblKhoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKhoa.ForeColor = System.Drawing.Color.Red;
            this.lblKhoa.Location = new System.Drawing.Point(118, 61);
            this.lblKhoa.Name = "lblKhoa";
            this.lblKhoa.Size = new System.Drawing.Size(133, 19);
            this.lblKhoa.TabIndex = 20;
            this.lblKhoa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label13.Location = new System.Drawing.Point(6, 61);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(106, 19);
            this.label13.TabIndex = 20;
            this.label13.Text = "Vào khoa";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNgayVaoVien
            // 
            this.txtNgayVaoVien.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNgayVaoVien.Culture = 1066;
            this.txtNgayVaoVien.CustomFormat = "dd/MM/yyyy HH:mm";
            this.txtNgayVaoVien.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
            this.txtNgayVaoVien.Location = new System.Drawing.Point(118, 19);
            this.txtNgayVaoVien.Name = "txtNgayVaoVien";
            this.txtNgayVaoVien.ReadOnly = true;
            this.txtNgayVaoVien.Size = new System.Drawing.Size(133, 18);
            this.txtNgayVaoVien.TabIndex = 18;
            this.txtNgayVaoVien.Tag = null;
            // 
            // label19
            // 
            this.label19.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label19.Location = new System.Drawing.Point(6, 19);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(106, 19);
            this.label19.TabIndex = 18;
            this.label19.Text = "Ngày, giờ vào viện";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbHinhThucVV
            // 
            this.cmbHinhThucVV.AddItemSeparator = ';';
            this.cmbHinhThucVV.AllowColMove = false;
            this.cmbHinhThucVV.AllowRowSizing = C1.Win.C1List.RowSizingEnum.AllRows;
            this.cmbHinhThucVV.AutoCompletion = true;
            this.cmbHinhThucVV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cmbHinhThucVV.Caption = "";
            this.cmbHinhThucVV.CaptionHeight = 17;
            this.cmbHinhThucVV.CaptionStyle = style81;
            this.cmbHinhThucVV.CaptionVisible = false;
            this.cmbHinhThucVV.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cmbHinhThucVV.ColumnCaptionHeight = 17;
            this.cmbHinhThucVV.ColumnFooterHeight = 17;
            this.cmbHinhThucVV.ColumnHeaders = false;
            this.cmbHinhThucVV.ContentHeight = 16;
            this.cmbHinhThucVV.DataMode = C1.Win.C1List.DataModeEnum.AddItem;
            this.cmbHinhThucVV.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cmbHinhThucVV.DefColWidth = 30;
            this.cmbHinhThucVV.DisplayMember = "Danh mục";
            this.cmbHinhThucVV.EditorBackColor = System.Drawing.Color.White;
            this.cmbHinhThucVV.EditorFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbHinhThucVV.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbHinhThucVV.EditorHeight = 16;
            this.cmbHinhThucVV.EvenRowStyle = style82;
            this.cmbHinhThucVV.ExtendRightColumn = true;
            this.cmbHinhThucVV.FlatStyle = C1.Win.C1List.FlatModeEnum.Popup;
            this.cmbHinhThucVV.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbHinhThucVV.FooterStyle = style83;
            this.cmbHinhThucVV.GapHeight = 2;
            this.cmbHinhThucVV.HeadingStyle = style84;
            this.cmbHinhThucVV.HighLightRowStyle = style85;
            this.cmbHinhThucVV.ItemHeight = 15;
            this.cmbHinhThucVV.Location = new System.Drawing.Point(118, 39);
            this.cmbHinhThucVV.MatchCol = C1.Win.C1List.MatchColEnum.AllCols;
            this.cmbHinhThucVV.MatchEntryTimeout = ((long)(2000));
            this.cmbHinhThucVV.MaxDropDownItems = ((short)(10));
            this.cmbHinhThucVV.MaxLength = 32767;
            this.cmbHinhThucVV.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cmbHinhThucVV.Name = "cmbHinhThucVV";
            this.cmbHinhThucVV.OddRowStyle = style86;
            this.cmbHinhThucVV.PartialRightColumn = false;
            this.cmbHinhThucVV.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.cmbHinhThucVV.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.cmbHinhThucVV.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cmbHinhThucVV.SelectedStyle = style87;
            this.cmbHinhThucVV.Size = new System.Drawing.Size(266, 20);
            this.cmbHinhThucVV.Style = style88;
            this.cmbHinhThucVV.TabIndex = 19;
            this.cmbHinhThucVV.PropBag = resources.GetString("cmbHinhThucVV.PropBag");
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(6, 39);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(106, 19);
            this.label20.TabIndex = 19;
            this.label20.Text = "Hình thức vào viện";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmdXoa
            // 
            this.cmdXoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdXoa.Image = ((System.Drawing.Image)(resources.GetObject("cmdXoa.Image")));
            this.cmdXoa.Location = new System.Drawing.Point(522, 491);
            this.cmdXoa.Name = "cmdXoa";
            this.cmdXoa.Size = new System.Drawing.Size(102, 26);
            this.cmdXoa.TabIndex = 29;
            this.cmdXoa.Text = "Xóa bệnh nhân";
            this.cmdXoa.Click += new System.EventHandler(this.cmdXoa_Click);
            // 
            // cmdThoat
            // 
            this.cmdThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdThoat.Image = ((System.Drawing.Image)(resources.GetObject("cmdThoat.Image")));
            this.cmdThoat.Location = new System.Drawing.Point(810, 491);
            this.cmdThoat.Name = "cmdThoat";
            this.cmdThoat.Size = new System.Drawing.Size(102, 26);
            this.cmdThoat.TabIndex = 30;
            this.cmdThoat.Text = "Thoát";
            this.cmdThoat.Click += new System.EventHandler(this.cmdThoat_Click);
            // 
            // cmdGhi
            // 
            this.cmdGhi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdGhi.Image = ((System.Drawing.Image)(resources.GetObject("cmdGhi.Image")));
            this.cmdGhi.Location = new System.Drawing.Point(414, 491);
            this.cmdGhi.Name = "cmdGhi";
            this.cmdGhi.Size = new System.Drawing.Size(102, 26);
            this.cmdGhi.TabIndex = 28;
            this.cmdGhi.Text = "Ghi dữ liệu";
            this.cmdGhi.Click += new System.EventHandler(this.cmdGhi_Click);
            // 
            // frmCapNhatBenhNhan
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(916, 521);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.rdDaVV);
            this.Controls.Add(this.rdChuaVV);
            this.Controls.Add(this.fgDanhSach);
            this.Controls.Add(this.lblListTitle);
            this.Controls.Add(this.cmbKhoa);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.cmdXoa);
            this.Controls.Add(this.cmdThoat);
            this.Controls.Add(this.cmdGhi);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmCapNhatBenhNhan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cập nhật thông tin hành chính của bệnh nhân";
            this.Load += new System.EventHandler(this.frmCapNhatBenhNhan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fgDanhSach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKhoa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbGiuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBuong)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDoiTuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTinh_TP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDonVi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCapBac)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDanToc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbGioiTinh)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmbMucAn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNgayVaoKhoa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNgayVaoVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbHinhThucVV)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void frmCapNhatBenhNhan_Load(object sender, System.EventArgs e)
		{
			fgDanhSach.ClipSeparators ="|;";
            fgDanhSach.Cols[1].Visible = false;
            fgDanhSach.Cols[7].Visible = false;
			Load_DM();
			LockEdit(true);
			txtNgayVaoVien.Value = Global.NgayLV;
            Global.SetCmb(cmbKhoa, Global.glbMaKhoaPhong);
			//this.WindowState = FormWindowState.Maximized;
		}
		private void Load_DM()
		{
			System.Data.SqlClient.SqlDataReader dr;
			System.Data.SqlClient.SqlCommand SQLCmd= new System.Data.SqlClient.SqlCommand();
			SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
			SQLCmd.CommandText  = "SELECT * FROM DMKHOAPHONG WHERE MaKhoa IN" + Global.glbKhoa_CapNhat;
			dr=SQLCmd.ExecuteReader();
			cmbKhoa.Tag ="0";
			cmbKhoa.ClearItems();
			while (dr.Read())
			{
				cmbKhoa.AddItem(string.Format("{0};{1}",dr["MaKhoa"],dr["TenKhoa"]));
			}
			cmbKhoa.SelectedIndex =-1;
			cmbKhoa.Tag ="1";
			dr.Close();
			SQLCmd.CommandText  = "SELECT * FROM DMDANTOC";
			dr=SQLCmd.ExecuteReader();
			while (dr.Read())
			{
				cmbDanToc.AddItem(string.Format("{0};{1}",dr["MaDT"],dr["TenDT"]));
			}
			dr.Close();
			SQLCmd.CommandText  = "SELECT * FROM DMQUANHAM";
			dr=SQLCmd.ExecuteReader();
			while (dr.Read())
			{
				cmbCapBac.AddItem(string.Format("{0};{1}",dr["MaQH"],dr["TenQH"]));
			}
			dr.Close();
			SQLCmd.CommandText = "SELECT * FROM DMDOITUONGBN";
			dr=SQLCmd.ExecuteReader();
			while (dr.Read())
			{
				cmbDoiTuong.AddItem(string.Format("{0};{1}",dr["MaDT"],dr["TenDT"]));
			}
			dr.Close();
			SQLCmd.CommandText = "SELECT * FROM DMDONVI";
			dr=SQLCmd.ExecuteReader();
			while (dr.Read())
			{
				cmbDonVi.AddItem(string.Format("{0};{1}",dr["MaDonVi"],dr["TenDonVi"]));
			}
			dr.Close();
			SQLCmd.CommandText = "SELECT * FROM DMTINH_TP";
			dr=SQLCmd.ExecuteReader();
			while (dr.Read())
			{
				cmbTinh_TP.AddItem(string.Format("{0};{1}",dr["MaTinh"],dr["TenTinh"]));
			}
			dr.Close();
            SQLCmd.CommandText = "SELECT * FROM ViewDMCHIPHI WHERE LoaiCP=5";
            dr = SQLCmd.ExecuteReader();
            while (dr.Read())
            {
                cmbMucAn.AddItem(string.Format("{0};{1}", dr["MaCP"], dr["TenCP"]));
            }
            dr.Close();
			SQLCmd.Dispose();

			cmbGioiTinh.AddItem("1;Nam");
			cmbGioiTinh.AddItem("0;Nữ");
			cmbHinhThucVV.AddItem("1;Tự đến");
			cmbHinhThucVV.AddItem("2;Cấp cứu");
			cmbHinhThucVV.AddItem("3;Tuyến trước chuyển đến");
			cmbHinhThucVV.AddItem("4;Bệnh viện khác chuyển đến");
			cmbHinhThucVV.AddItem("5;Khác");
		}
		private void LockEdit(bool IsLocked)
		{
//			cmdXoa.Visible = IsLocked;
//			cmdThoat.Visible = IsLocked;
//		
//
//			cmdGhi.Visible = !IsLocked;
//			fgDanhSach.Enabled = IsLocked;			
//			
//			cmbGioiTinh.ReadOnly = IsLocked;
//			cmbDanToc.ReadOnly = IsLocked;
//			cmbCapBac.ReadOnly = IsLocked;
//
//			txtSoHSBA.ReadOnly = IsLocked;
//			cmbKhoa.ReadOnly = !IsLocked;
		}
		private void Load_DSBenhNhan()
		{
			System.Data.SqlClient.SqlDataReader dr;
			System.Data.SqlClient.SqlCommand SQLCmd= new System.Data.SqlClient.SqlCommand();
			SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
			string MaKhoa=Global.GetCode(cmbKhoa);
			if (rdChuaVV.Checked)
			{
                fgDanhSach[0, 6] = "Ngày vào viện";
                //SQLCmd.CommandText = "select BENHNHAN.MaBenhNhan,BENHNHAN.HoTen As TenBenhNhan,Year(GetDate())-NamSinh as Tuoi,GioiTinh,TenDT,NgayVaoVien As NgayKham,BENHNHAN_CHITIET.LanVaoVien,TrangThai "
                //                + " FROM ((BENHNHAN INNER JOIN BENHNHAN_CHITIET ON BENHNHAN.MaBenhNhan=BENHNHAN_CHITIET.MaBenhNhan)"
                //                + " INNER JOIN DMDOITUONGBN ON BENHNHAN_CHITIET.DoiTuong=DMDOITUONGBN.MaDT)"
                //                + " INNER JOIN ViewKHOAHIENTAI ON BENHNHAN_CHITIET.MaBenhNhan=ViewKHOAHIENTAI.MaBenhNhan AND BENHNHAN_CHITIET.LanVaoVien=ViewKHOAHIENTAI.LanVaoVien"
                //                + " WHERE MaKhoa ='" + MaKhoa + "' AND DaRaVien=0 AND TrangThai>1 ";
                SQLCmd.CommandText = string.Format("select BENHNHAN.MaBenhNhan,BENHNHAN.HoTen As TenBenhNhan,Year(ViewKHOAHIENTAI.NgayChuyen)-NamSinh as Tuoi,GioiTinh,TenDT,NgayVaoVien As NgayKham,BENHNHAN_CHITIET.LanVaoVien,TrangThai,Q1.TenTat "
                                        + " FROM (((BENHNHAN INNER JOIN BENHNHAN_CHITIET ON BENHNHAN.MaBenhNhan=BENHNHAN_CHITIET.MaBenhNhan)"
                                        + " INNER JOIN DMDOITUONGBN ON BENHNHAN_CHITIET.DoiTuong=DMDOITUONGBN.MaDT)"
                                        + " INNER JOIN ViewKHOAHIENTAI ON BENHNHAN_CHITIET.MaBenhNhan=ViewKHOAHIENTAI.MaBenhNhan AND BENHNHAN_CHITIET.LanVaoVien=ViewKHOAHIENTAI.LanVaoVien)"
                                        + " LEFT JOIN (select ViewKHOAHIENTAI.MaBenhNhan,ViewKHOAHIENTAI.LanVaoVien,MaxLan,TenTat "
                                                + " FROM (ViewKHOAHIENTAI INNER JOIN BENHNHAN_KHOA ON ViewKHOAHIENTAI.MaBenhNhan=BENHNHAN_KHOA.MaBenhNhan "
                                                + " AND ViewKHOAHIENTAI.LanVaoVien=BENHNHAN_KHOA.LanVaoVien AND BENHNHAN_KHOA.LanChuyenKhoa=ViewKHOAHIENTAI.MaxLan-1) "
                                                + " INNER JOIN DMKHOAPHONG ON BENHNHAN_KHOA.MaKhoa=DMKHOAPHONG.MaKhoa "
                                                + " WHERE ViewKHOAHIENTAI.vDaRaVien=0 AND ViewKHOAHIENTAI.MaKhoa='{0}') Q1 "
                                        + " ON BENHNHAN_CHITIET.MaBenhNhan=Q1.MaBenhNhan AND BENHNHAN_CHITIET.LanVaoVien=Q1.LanVaoVien "
                                        + " WHERE MaKhoa ='{0}' AND DaRaVien=0 AND TrangThai>1 ",MaKhoa);

			}
			else
			{
				fgDanhSach[0,6]="Ngày vào viện";
                SQLCmd.CommandText = "select BENHNHAN.MaBenhNhan,BENHNHAN.HoTen As TenBenhNhan,Year(ViewKHOAHIENTAI.NgayChuyen)-NamSinh as Tuoi,GioiTinh,TenDT,NgayVaoVien As NgayKham,BENHNHAN_CHITIET.LanVaoVien,'' As TenTat "
								+ " FROM ((BENHNHAN INNER JOIN BENHNHAN_CHITIET ON BENHNHAN.MaBenhNhan=BENHNHAN_CHITIET.MaBenhNhan)"
								+ " INNER JOIN DMDOITUONGBN ON BENHNHAN_CHITIET.DoiTuong=DMDOITUONGBN.MaDT)"
                                + " INNER JOIN ViewKHOAHIENTAI ON BENHNHAN_CHITIET.MaBenhNhan=ViewKHOAHIENTAI.MaBenhNhan AND BENHNHAN_CHITIET.LanVaoVien=ViewKHOAHIENTAI.LanVaoVien"
								+ " WHERE MaKhoa ='" +MaKhoa + "' AND DaRaVien=0 AND TrangThai=1";

				cmdXoa.Visible = true;				
			}
			
			dr=SQLCmd.ExecuteReader();
			fgDanhSach.Tag ="0";
            fgDanhSach.Redraw = false;
			fgDanhSach.Rows.Count =1;
			while (dr.Read())
			{
				fgDanhSach.AddItem(string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6:dd/MM/yyyy}|{7}|{8}",fgDanhSach.Rows.Count,
					dr["MaBenhNhan"],
					dr["TenBenhNhan"],
					dr["Tuoi"],
					(dr["GioiTinh"].ToString()=="1")?("Nam"):("Nữ"),
					dr["TenDT"],
					dr["NgayKham"],dr["LanVaoVien"],(dr["TenTat"].ToString()=="")?("Phòng khám"):(dr["TenTat"])));
                //switch (dr["TrangThai"].ToString())
                //{
                //    case "2":
                //        fgDanhSach[fgDanhSach.Rows.Count - 1, 8] = "Khoa khác";
                //        break;
                //    case "3":
                //        fgDanhSach[fgDanhSach.Rows.Count - 1, 8] = "Phòng khám";
                //        break;
                //}
			}
			dr.Close();
			fgDanhSach.AutoSizeCols();
            fgDanhSach.Redraw = true;
			fgDanhSach.Tag ="1";
            SQLCmd.CommandText = "SELECT * FROM DMBUONGBENH WHERE MaKhoa='" + MaKhoa + "'";
            cmbBuong.Tag = "0";
            cmbBuong.ClearItems();
            dr = SQLCmd.ExecuteReader();
            while (dr.Read())
            {
                cmbBuong.AddItem(string.Format("{0};{1}",dr["ID_Buong"],dr["TenBuong"]));
            }
            dr.Close();
			SQLCmd.Dispose();
			Clear_Data();
            cmbBuong.Tag = "1";
		}
				
		private void cmdThoat_Click(object sender, System.EventArgs e)
		{
			this.Dispose();
		}

		private void cmdGhi_Click(object sender, System.EventArgs e)
		{
			if (lblMaBN.Text =="") {return;}
			if (txtNgayVaoVien.ValueIsDbNull)
			{
				MessageBox.Show("Chưa nhập ngày vào viện!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
				txtNgayVaoVien.Focus();
				return;
			}
            if (txtNgayVaoKhoa.ValueIsDbNull)
            {
                MessageBox.Show("Chưa nhập ngày giờ vào Khoa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNgayVaoKhoa.Focus();
                return;
            }
			if (txtSoHSBA.Text.Trim()=="")
			{
				MessageBox.Show("Chưa nhập số hồ sơ bệnh án!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
				txtSoHSBA.Focus();
				return;
			}
			if (Global.GetCode(cmbDoiTuong)==null)
			{
				MessageBox.Show("Chưa nhập đối tượng bệnh nhân!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
				cmbDoiTuong.Focus();
				return;
			}
			if (txtHoTen.Text.Trim()=="")
			{
				MessageBox.Show("Chưa nhập tên bệnh nhân!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
				txtHoTen.Focus();
				return;
			}
			if (cmbKhoa.SelectedIndex ==-1)
			{
				MessageBox.Show("Chưa nhập khoa điều trị!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
				cmbKhoa.Focus();
				return;
			}
            if (cmbGiuong.SelectedIndex == -1)
            {
                MessageBox.Show("Chưa nhập giường điều trị của bệnh nhân!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbGiuong.Focus();
                return;
            }

			if (GhiDuLieuBenhAn(rdChuaVV.Checked)==1) {MessageBox.Show("Đã cập nhật xong bệnh án của bệnh nhân","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);}
		}
		
		private void Load_BenhNhan(string MaBenhNhan,string LanVaoVien)
		{
			System.Data.SqlClient.SqlDataReader dr;
			System.Data.SqlClient.SqlCommand SQLCmd= new System.Data.SqlClient.SqlCommand();
			SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            string  Buong = "", Giuong = "";
            //if (rdChuaVV.Checked)
            //{				
            //    SQLCmd.CommandText = "select [KHAMBENH103].DBO.tblBENHNHAN.*,KetLuan,MaKhoaDieuTri,MaBenhChinh,TenBenh,TenDT,NgayKham,year(GetDate())-NamSinh As Tuoi,'' As SoHSBA,'' As HinhThucVV,0 As LanVaoVien,null As NgayVaoVien,Null as HinhThuc_VV,Null As Buong, Null As Giuong "
            //        + " from (([KHAMBENH103].DBO.tblBENHNHAN "
            //        + " INNER JOIN [KHAMBENH103].DBO.tblKHAMBENH ON [KHAMBENH103].DBO.tblBENHNHAN.MaBenhNhan= [KHAMBENH103].DBO.tblKHAMBENH.MabenhNhan)"
            //        + " LEFT JOIN DMBENH ON MaBenhChinh=MaBenh)"
            //        + " INNER JOIN DMDOITUONGBN ON MaDoiTuong=MaDT"
            //        + " WHERE [KHAMBENH103].DBO.tblKHAMBENH.MaBenhNhan='" + MaBenhNhan + "' AND HuongGQ=4 AND IsNull(SoBenhAn,'')=''"
            //        + " ORDER BY [KHAMBENH103].DBO.tblBENHNHAN.MaBenhNhan, thuTuKham";
            //}
            //else
            //{
            SQLCmd.CommandText = string.Format("SELECT BENHNHAN.MaBenhNhan,HoTen as TenBenhNhan,Year(ViewKHOAHIENTAI.NgayChuyen)-NamSinh As Tuoi,GioiTinh,MaDanToc,NgayVaoVien,BENHNHAN_CHITIET.*,TrieuChung_VV As KetLuan,ChanDoan_PK_BenhChinh As MaBenhChinh,TenBenh,DoiTuong As MaDoiTuong,CapBac As MaCapBac,DonVi as MaDonVi,NgayChuyen"
										+ " FROM ((BENHNHAN INNER JOIN BENHNHAN_CHITIET ON BENHNHAN.MabenhNhan=BENHNHAN_CHITIET.MaBenhNhan) "
                                        + " INNER JOIN ViewKHOAHIENTAI ON BENHNHAN_CHITIET.MaBenhNhan=ViewKHOAHIENTAI.MaBenhNhan AND BENHNHAN_CHITIET.LanVaoVien=ViewKHOAHIENTAI.LanVaoVien) "
										+ " LEFT JOIN DMBENH ON ChanDoan_PK_BenhChinh=MaBenh"
										+ " where benhnhan.mabenhnhan='{0}' "
										+ " AND BENHNHAN_CHITIET.LanVaoVien={1}",MaBenhNhan,LanVaoVien);
            //}
			
			dr=SQLCmd.ExecuteReader();
			if (dr.HasRows)
			{
				dr.Read();
				lblMaBN.Text = MaBenhNhan;
				lblLanVV.Text = dr["LanVaoVien"].ToString();
				txtSoHSBA.Text= dr["SoHSBA"].ToString();
				txtNgayVaoVien.Value = dr["NgayVaoVien"];
				//txtNgayGioVV.Value =DateTime.FromOADate((double)dr["NgayVaoVien"]);
				txtHoTen.Text = dr["TenBenhNhan"].ToString();
				txtTuoi.Text = dr["Tuoi"].ToString();
				Global.SetCmb(cmbDoiTuong,dr["MaDoiTuong"].ToString());
				Global.SetCmb(cmbHinhThucVV,dr["HinhThuc_VV"].ToString());
                Buong = dr["Buong"].ToString();
                Giuong = dr["Giuong"].ToString();                
				txtSoTheBHYT.Text = dr["SoTheBHYT"].ToString();
				Global.SetCmb(cmbGioiTinh,dr["GioiTinh"].ToString());
				Global.SetCmb(cmbDanToc,dr["MaDanToc"].ToString());
				Global.SetCmb(cmbCapBac,dr["MaCapBac"].ToString());				
				Global.SetCmb(cmbDonVi,dr["MaDonVi"].ToString());
                Global.SetCmb(cmbMucAn, dr["MucAn"].ToString());
				txtLienHe.Text = dr["LienHe"].ToString();
				txtDiaChi.Text = dr["NoiO"].ToString();
                Global.SetCmb(cmbTinh_TP, dr["MaTinh_TP"].ToString());
                txtICD_PK.Text = dr["MaBenhChinh"].ToString();
				txtICD_PK.Tag = dr["MabenhChinh"].ToString();
                lblICD_PK.Text = dr["tenBenh"].ToString();
                if (rdChuaVV.Checked)
                {
                    txtNgayVaoKhoa.Value = null;
                }
                else
                {
                    txtNgayVaoKhoa.Value = dr["NgayChuyen"];
                }
                Global.SetCmb(cmbMucAn, dr["MucAn"].ToString());
			}
            lblKhoa.Text = cmbKhoa.Text;
            lblKhoa.Tag = Global.GetCode(cmbKhoa);
			dr.Close();			
			SQLCmd.Dispose();
            Global.SetCmb(cmbBuong, Buong );
            Global.SetCmb(cmbGiuong, Giuong);
		}

		private void fgDanhSach_AfterSelChange(object sender, C1.Win.C1FlexGrid.RangeEventArgs e)
		{
			if (fgDanhSach.Tag.ToString() =="0" || fgDanhSach.Row<1) {return;}
            Load_BenhNhan(fgDanhSach.GetDataDisplay(fgDanhSach.Row, 1), fgDanhSach.GetDataDisplay(fgDanhSach.Row, 7));
		}

		private void Clear_Data()
		{
			lblMaBN.Text ="";
			lblLanVV.Text ="";
			txtSoHSBA.Text = "";
			txtHoTen.Text ="";
            cmbBuong.SelectedIndex = -1;
            cmbGiuong.ClearItems();
			txtTuoi.Text ="";
			cmbGioiTinh.SelectedIndex =-1;
			cmbDanToc.SelectedIndex =-1;
			cmbCapBac.SelectedIndex=-1;
			cmbDonVi.SelectedIndex=-1;
			txtChucVu.Text = "";			
			txtLienHe.Text ="";
			txtDiaChi.Text ="";
			txtNgayVaoVien.Value =null;
			cmbDoiTuong.SelectedIndex=-1;
			cmbHinhThucVV.SelectedIndex =-1;			
			txtICD_PK.Text ="";
			txtICD_PK.Tag ="";
            lblICD_PK.Text = "";
            txtICD_KhoaDT.Text = "";
            txtICD_PK.Tag = "";
            lblICD_PK.Text = "";
			cmbTinh_TP.SelectedIndex = -1;
		}

		private void cmdXoa_Click(object sender, System.EventArgs e)
		{
			if (txtSoHSBA.Text.Trim()=="")
			{
				MessageBox.Show("Chưa chọn bệnh nhân để xóa!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return;
			}
			if (MessageBox.Show("Bạn có chắc muốn xóa bệnh nhân này không?","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.No) {return;}
			System.Data.SqlClient.SqlDataReader dr;
			System.Data.SqlClient.SqlCommand SQLCmd= new System.Data.SqlClient.SqlCommand();
			SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
			SQLCmd.CommandText  = "SELECT * FROM BENHNHAN_CHIPHI WHERE MaBenhNhan='" + lblMaBN.Text  +"' AND LanvaoVien=" + lblLanVV.Text ;
			dr=SQLCmd.ExecuteReader();
			if (dr.HasRows)
			{
				MessageBox.Show("Đã cập nhật chi phí của bệnh nhân, không thể xóa được bệnh nhân này!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
				dr.Close();
				SQLCmd.Dispose();
				return;
			}
			dr.Close();
            SQLCmd.CommandText = "DELETE FROM BENHNHAN_CHITIET WHERE MaBenhNhan='" + lblMaBN.Text  + "' AND LanVaoVien=" + lblLanVV.Text ;
            SQLCmd.ExecuteNonQuery();			
			fgDanhSach.RemoveItem(fgDanhSach.Row);
			SQLCmd.Dispose();
			if (fgDanhSach.Rows.Count ==1) {Clear_Data();}
		}
	
		private void cmbKhoa_TextChanged(object sender, System.EventArgs e)
		{
			if (cmbKhoa.Tag.ToString()=="0") {return;}
			Clear_Data();
			Load_DSBenhNhan();
		}
		
		private string SinhSHSBA(string MaKhoa)
		{
			string HeaderBA = string.Format("{0}{1}",Global.NgayLV.Year.ToString().Substring(2) ,MaKhoa);
			string SoHSBA="";
			System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("SELECT Max(SoHSBA) As MaxHSBA FROM BENHNHAN WHERE SoHSBA LIKE '" + HeaderBA + "%'",Global.ConnectSQL);
			System.Data.SqlClient.SqlDataReader dr = cmd.ExecuteReader();
			dr.Read();
			if (dr["MaxHSBA"].ToString()=="")
			{	
				SoHSBA = HeaderBA + "00001";
			}
			else
			{				
				SoHSBA = string.Format("{0}{1:00000}",HeaderBA,long.Parse(dr["MaxHSBA"].ToString().Substring(5))+1);
			}
			dr.Close();
			cmd.Dispose();
			return SoHSBA;
		}

		private void txtICD_PK_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{

		}
		private int GhiDuLieuBenhAn(Boolean ChuaVaoVien)
		{
			System.Data.SqlClient.SqlTransaction trsBN;
			System.Data.SqlClient.SqlCommand SQLCmd= new System.Data.SqlClient.SqlCommand();			
			SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
			trsBN = Global.ConnectSQL.BeginTransaction();
            try
            {
                SQLCmd.Transaction = trsBN;
                SQLCmd.CommandText = string.Format("UPDATE BENHNHAN SET HoTen=N'{0}',NamSinh={1},GioiTinh={2},MaDanToc='{3}' WHERE MaBenhNhan='{4}'", txtHoTen.Text, Global.NgayLV.Year - int.Parse(txtTuoi.Text), Global.GetCode(cmbGioiTinh), Global.GetCode(cmbDanToc), lblMaBN.Text);
                SQLCmd.ExecuteNonQuery();
                SQLCmd.CommandText = string.Format("UPDATE BENHNHAN_CHITIET Set SoHSBA='{0}',SoTheBHYT='{1}',DoiTuong='{2}',Capbac={3},NoiO=N'{4}',DonVi={5},MaTinh_TP={6},"
                                + "LienHe=N'{7}',NgayVaoVien='{8:MM/dd/yyyy HH:mm}',ChanDoan_PK_BenhChinh='{9}',HinhThuc_VV={10},Buong={11},Giuong={12},TrangThai=1,MucAn={15} WHERE MaBenhNhan='{13}' AND LanVaoVien='{14}'",
                                txtSoHSBA.Text,
                                txtSoTheBHYT.Text,
                                Global.GetCode(cmbDoiTuong),
                                (Global.GetCode(cmbCapBac) == null) ? ("Null") : ("'" + Global.GetCode(cmbCapBac) + "'"),
                                txtDiaChi.Text,
                                (Global.GetCode(cmbDonVi) == null) ? ("Null") : ("'" + Global.GetCode(cmbDonVi) + "'"),
                                (Global.GetCode(cmbTinh_TP) == null) ? ("Null") : ("'" + Global.GetCode(cmbTinh_TP) + "'"),
                                txtLienHe.Text,
                                txtNgayVaoVien.Value,                               
                                txtICD_PK.Text,
                                (Global.GetCode(cmbHinhThucVV) == null) ? ("Null") : ("'" + Global.GetCode(cmbHinhThucVV) + "'"),                                
                                (Global.GetCode(cmbBuong) == null) ? ("Null") : (Global.GetCode(cmbBuong)),
                                (Global.GetCode(cmbGiuong) == null) ? ("Null") : (Global.GetCode(cmbGiuong)),
                                lblMaBN.Text,
                                lblLanVV.Text,
                                (Global.GetCode(cmbMucAn) == null) ? ("Null") : ("'" + Global.GetCode(cmbMucAn) + "'"));
                SQLCmd.ExecuteNonQuery();
                SQLCmd.CommandText = string.Format("update ViewKHOAHIENTAI SET NgayChuyen='{0:MM/dd/yyyy HH:mm}'"
                                                    + " where mabenhnhan='{1}' AND LanVaoVien={2} ", txtNgayVaoKhoa.Value, lblMaBN.Text, lblLanVV.Text);
                SQLCmd.ExecuteNonQuery();
                trsBN.Commit();                
                return 1;
            }
            catch (Exception ex)
            {
                trsBN.Rollback();
                MessageBox.Show("Có lỗi khi ghi dữ liệu\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);                                
                return -1;
            }
            finally
            {
                SQLCmd.Dispose();                
                trsBN.Dispose();
            }
		}

		private void rdChuaVV_CheckedChanged(object sender, System.EventArgs e)
		{
            if (rdChuaVV.Checked) { fgDanhSach.Cols[8].Visible = true; } else { fgDanhSach.Cols[8].Visible = false;}
			Load_DSBenhNhan();
        }

        private void cmbBuong_TextChanged(object sender, EventArgs e)
        {
            if (cmbBuong.SelectedIndex == -1) { cmbGiuong.ClearItems(); return; }
            if (cmbKhoa.SelectedIndex == -1 ||cmbKhoa.Tag.ToString()=="0" ||cmbBuong.Tag.ToString()=="0") { return; }
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlDataReader dr;
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            SQLCmd.CommandText = "SELECT * FROM DMGIUONGBENH WHERE maKhoa='" + Global.GetCode(cmbKhoa) +"' AND ID_Buong="+Global.GetCode(cmbBuong);
            dr = SQLCmd.ExecuteReader();
            cmbGiuong.ClearItems();
            while (dr.Read())
            {
                cmbGiuong.AddItem(string.Format("{0};{1}", dr["ID_Giuong"], dr["TenGiuong"]));
            }
            dr.Close();
            SQLCmd.Dispose();
        }

        private void txtICD_KhoaDT_Validating(object sender, CancelEventArgs e)
        {
            if (txtICD_KhoaDT.Text != "")
            {
                NamDinh_QLBN.Forms.DanhMuc.frmShowICD10 fr = new NamDinh_QLBN.Forms.DanhMuc.frmShowICD10(txtICD_KhoaDT.Text, txtICD_KhoaDT, 2);
                fr.ShowDialog();
                string TextReturn = fr.TextReturn;
                lblICD_KhoaDT.Text = TextReturn.Substring(TextReturn.IndexOf("|") + 1);
            }
        }
	}
}

