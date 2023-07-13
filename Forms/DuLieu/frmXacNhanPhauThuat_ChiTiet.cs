using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace NamDinh_QLBN.Forms.DuLieu
{
	/// <summary>
	/// Summary description for frmXacNhanPhauThuat_ChiTiet.
	/// </summary>
	public class frmXacNhanPhauThuat_ChiTiet : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label lblGioiTinh;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label lblTuoi;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label lblNgayVaoVien;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label lblHoTen;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label lblSoHSBA;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
		private C1.Win.C1Input.C1DateEdit txtNgayPT;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtGhiChu;
		private System.Windows.Forms.Label lblPhauThuat;
		private DevExpress.XtraEditors.SimpleButton cmdEdit;
		private DevExpress.XtraEditors.SimpleButton cmdThoat;
		public string GhiChu="";
		public DateTime NgayPT=GlobalModuls.Global.NgayLV;
		public bool DaPT=false;
		private byte LanPT=0;
		private byte LanVaoVien=0;
		private string MaBenhNhan="";
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		internal C1.Win.C1List.C1Combo cmbTinhChatPT;
		internal C1.Win.C1List.C1Combo cmbVoCam;
		internal C1.Win.C1List.C1Combo cmbSoSanh;
		internal C1.Win.C1List.C1Combo cmbTaiBien;
		internal C1.Win.C1List.C1Combo cmbLoaiPT;
		private C1.Win.C1FlexGrid.C1FlexGrid fg;
		private DevExpress.XtraEditors.SimpleButton cmdThem;
		private System.Windows.Forms.Label label13;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label14;
        internal C1.Win.C1List.C1Combo cmbPhuongPhapPT;
        private CheckBox chkDaPT;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmXacNhanPhauThuat_ChiTiet(string _MaBenhNhan,byte _LanPT,byte _LanVaoVien)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			MaBenhNhan = _MaBenhNhan;
			lblSoHSBA.Text = MaBenhNhan;
			LanPT = _LanPT;
			LanVaoVien=_LanVaoVien;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmXacNhanPhauThuat_ChiTiet));
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
            this.lblGioiTinh = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblTuoi = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblNgayVaoVien = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSoHSBA = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblPhauThuat = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtNgayPT = new C1.Win.C1Input.C1DateEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.cmdEdit = new DevExpress.XtraEditors.SimpleButton();
            this.cmdThoat = new DevExpress.XtraEditors.SimpleButton();
            this.label17 = new System.Windows.Forms.Label();
            this.cmbTinhChatPT = new C1.Win.C1List.C1Combo();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbVoCam = new C1.Win.C1List.C1Combo();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbSoSanh = new C1.Win.C1List.C1Combo();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbTaiBien = new C1.Win.C1List.C1Combo();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbLoaiPT = new C1.Win.C1List.C1Combo();
            this.fg = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.cmdThem = new DevExpress.XtraEditors.SimpleButton();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkDaPT = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cmbPhuongPhapPT = new C1.Win.C1List.C1Combo();
            ((System.ComponentModel.ISupportInitialize)(this.txtNgayPT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTinhChatPT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbVoCam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSoSanh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTaiBien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLoaiPT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fg)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPhuongPhapPT)).BeginInit();
            this.SuspendLayout();
            // 
            // lblGioiTinh
            // 
            this.lblGioiTinh.BackColor = System.Drawing.Color.White;
            this.lblGioiTinh.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblGioiTinh.Location = new System.Drawing.Point(461, 48);
            this.lblGioiTinh.Name = "lblGioiTinh";
            this.lblGioiTinh.Size = new System.Drawing.Size(36, 18);
            this.lblGioiTinh.TabIndex = 126;
            this.lblGioiTinh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(407, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 18);
            this.label7.TabIndex = 125;
            this.label7.Text = "Giới tính";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTuoi
            // 
            this.lblTuoi.BackColor = System.Drawing.Color.White;
            this.lblTuoi.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTuoi.Location = new System.Drawing.Point(363, 48);
            this.lblTuoi.Name = "lblTuoi";
            this.lblTuoi.Size = new System.Drawing.Size(30, 18);
            this.lblTuoi.TabIndex = 124;
            this.lblTuoi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(321, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 18);
            this.label5.TabIndex = 123;
            this.label5.Text = "Tuổi";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblNgayVaoVien
            // 
            this.lblNgayVaoVien.BackColor = System.Drawing.Color.White;
            this.lblNgayVaoVien.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNgayVaoVien.Location = new System.Drawing.Point(114, 69);
            this.lblNgayVaoVien.Name = "lblNgayVaoVien";
            this.lblNgayVaoVien.Size = new System.Drawing.Size(96, 18);
            this.lblNgayVaoVien.TabIndex = 122;
            this.lblNgayVaoVien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(6, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 18);
            this.label4.TabIndex = 121;
            this.label4.Text = "Ngày vào viện";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblHoTen
            // 
            this.lblHoTen.BackColor = System.Drawing.Color.White;
            this.lblHoTen.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblHoTen.Location = new System.Drawing.Point(114, 48);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(204, 18);
            this.lblHoTen.TabIndex = 120;
            this.lblHoTen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(6, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 18);
            this.label3.TabIndex = 119;
            this.label3.Text = "Họ và tên BN";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSoHSBA
            // 
            this.lblSoHSBA.BackColor = System.Drawing.Color.White;
            this.lblSoHSBA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSoHSBA.Location = new System.Drawing.Point(114, 27);
            this.lblSoHSBA.Name = "lblSoHSBA";
            this.lblSoHSBA.Size = new System.Drawing.Size(81, 18);
            this.lblSoHSBA.TabIndex = 118;
            this.lblSoHSBA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 18);
            this.label1.TabIndex = 117;
            this.label1.Text = "Mã bệnh nhân";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(6, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 18);
            this.label6.TabIndex = 1;
            this.label6.Text = "Ngày phẫu thuật";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPhauThuat
            // 
            this.lblPhauThuat.BackColor = System.Drawing.Color.White;
            this.lblPhauThuat.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPhauThuat.Location = new System.Drawing.Point(114, 16);
            this.lblPhauThuat.Name = "lblPhauThuat";
            this.lblPhauThuat.Size = new System.Drawing.Size(357, 18);
            this.lblPhauThuat.TabIndex = 130;
            this.lblPhauThuat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(6, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(105, 18);
            this.label9.TabIndex = 129;
            this.label9.Text = "Yêu cầu phẫu thuật";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNgayPT
            // 
            this.txtNgayPT.Culture = 1066;
            this.txtNgayPT.CustomFormat = "dd/MM/yyyy";
            this.txtNgayPT.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
            this.txtNgayPT.Location = new System.Drawing.Point(114, 37);
            this.txtNgayPT.Name = "txtNgayPT";
            this.txtNgayPT.Size = new System.Drawing.Size(135, 20);
            this.txtNgayPT.TabIndex = 2;
            this.txtNgayPT.Tag = null;
            this.txtNgayPT.Value = new System.DateTime(((long)(0)));
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(9, 318);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 18);
            this.label2.TabIndex = 18;
            this.label2.Text = "Ghi chú";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(114, 318);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(382, 45);
            this.txtGhiChu.TabIndex = 19;
            // 
            // cmdEdit
            // 
            this.cmdEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdEdit.Image = ((System.Drawing.Image)(resources.GetObject("cmdEdit.Image")));
            this.cmdEdit.Location = new System.Drawing.Point(369, 479);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(69, 27);
            this.cmdEdit.TabIndex = 21;
            this.cmdEdit.Text = "Ghi";
            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
            // 
            // cmdThoat
            // 
            this.cmdThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdThoat.Image = ((System.Drawing.Image)(resources.GetObject("cmdThoat.Image")));
            this.cmdThoat.Location = new System.Drawing.Point(438, 479);
            this.cmdThoat.Name = "cmdThoat";
            this.cmdThoat.Size = new System.Drawing.Size(69, 27);
            this.cmdThoat.TabIndex = 22;
            this.cmdThoat.Text = "Thoát";
            this.cmdThoat.Click += new System.EventHandler(this.cmdThoat_Click);
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(9, 61);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(102, 15);
            this.label17.TabIndex = 3;
            this.label17.Text = "Nhóm phẫu thuật";
            this.label17.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cmbTinhChatPT
            // 
            this.cmbTinhChatPT.AddItemSeparator = ';';
            this.cmbTinhChatPT.AllowColMove = false;
            this.cmbTinhChatPT.AllowRowSizing = C1.Win.C1List.RowSizingEnum.AllRows;
            this.cmbTinhChatPT.AutoCompletion = true;
            this.cmbTinhChatPT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cmbTinhChatPT.Caption = "";
            this.cmbTinhChatPT.CaptionHeight = 17;
            this.cmbTinhChatPT.CaptionStyle = style1;
            this.cmbTinhChatPT.CaptionVisible = false;
            this.cmbTinhChatPT.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cmbTinhChatPT.ColumnCaptionHeight = 17;
            this.cmbTinhChatPT.ColumnFooterHeight = 17;
            this.cmbTinhChatPT.ColumnHeaders = false;
            this.cmbTinhChatPT.ContentHeight = 16;
            this.cmbTinhChatPT.DataMode = C1.Win.C1List.DataModeEnum.AddItem;
            this.cmbTinhChatPT.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cmbTinhChatPT.DefColWidth = 1;
            this.cmbTinhChatPT.DisplayMember = "Danh mục";
            this.cmbTinhChatPT.EditorBackColor = System.Drawing.Color.White;
            this.cmbTinhChatPT.EditorFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTinhChatPT.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbTinhChatPT.EditorHeight = 16;
            this.cmbTinhChatPT.EvenRowStyle = style2;
            this.cmbTinhChatPT.ExtendRightColumn = true;
            this.cmbTinhChatPT.FlatStyle = C1.Win.C1List.FlatModeEnum.Popup;
            this.cmbTinhChatPT.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTinhChatPT.FooterStyle = style3;
            this.cmbTinhChatPT.GapHeight = 2;
            this.cmbTinhChatPT.HeadingStyle = style4;
            this.cmbTinhChatPT.HighLightRowStyle = style5;
            this.cmbTinhChatPT.ItemHeight = 15;
            this.cmbTinhChatPT.Location = new System.Drawing.Point(114, 79);
            this.cmbTinhChatPT.MatchCol = C1.Win.C1List.MatchColEnum.AllCols;
            this.cmbTinhChatPT.MatchEntryTimeout = ((long)(2000));
            this.cmbTinhChatPT.MaxDropDownItems = ((short)(10));
            this.cmbTinhChatPT.MaxLength = 32767;
            this.cmbTinhChatPT.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cmbTinhChatPT.Name = "cmbTinhChatPT";
            this.cmbTinhChatPT.OddRowStyle = style6;
            this.cmbTinhChatPT.PartialRightColumn = false;
            this.cmbTinhChatPT.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.cmbTinhChatPT.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.cmbTinhChatPT.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cmbTinhChatPT.SelectedStyle = style7;
            this.cmbTinhChatPT.Size = new System.Drawing.Size(207, 20);
            this.cmbTinhChatPT.Style = style8;
            this.cmbTinhChatPT.TabIndex = 6;
            this.cmbTinhChatPT.PropBag = resources.GetString("cmbTinhChatPT.PropBag");
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(9, 82);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 15);
            this.label8.TabIndex = 5;
            this.label8.Text = "Tính chất mổ";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cmbVoCam
            // 
            this.cmbVoCam.AddItemSeparator = ';';
            this.cmbVoCam.AllowColMove = false;
            this.cmbVoCam.AllowRowSizing = C1.Win.C1List.RowSizingEnum.AllRows;
            this.cmbVoCam.AutoCompletion = true;
            this.cmbVoCam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cmbVoCam.Caption = "";
            this.cmbVoCam.CaptionHeight = 17;
            this.cmbVoCam.CaptionStyle = style9;
            this.cmbVoCam.CaptionVisible = false;
            this.cmbVoCam.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cmbVoCam.ColumnCaptionHeight = 17;
            this.cmbVoCam.ColumnFooterHeight = 17;
            this.cmbVoCam.ColumnHeaders = false;
            this.cmbVoCam.ContentHeight = 16;
            this.cmbVoCam.DataMode = C1.Win.C1List.DataModeEnum.AddItem;
            this.cmbVoCam.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cmbVoCam.DefColWidth = 1;
            this.cmbVoCam.DisplayMember = "Danh mục";
            this.cmbVoCam.EditorBackColor = System.Drawing.Color.White;
            this.cmbVoCam.EditorFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbVoCam.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbVoCam.EditorHeight = 16;
            this.cmbVoCam.EvenRowStyle = style10;
            this.cmbVoCam.ExtendRightColumn = true;
            this.cmbVoCam.FlatStyle = C1.Win.C1List.FlatModeEnum.Popup;
            this.cmbVoCam.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbVoCam.FooterStyle = style11;
            this.cmbVoCam.GapHeight = 2;
            this.cmbVoCam.HeadingStyle = style12;
            this.cmbVoCam.HighLightRowStyle = style13;
            this.cmbVoCam.ItemHeight = 15;
            this.cmbVoCam.Location = new System.Drawing.Point(114, 121);
            this.cmbVoCam.MatchCol = C1.Win.C1List.MatchColEnum.AllCols;
            this.cmbVoCam.MatchEntryTimeout = ((long)(2000));
            this.cmbVoCam.MaxDropDownItems = ((short)(10));
            this.cmbVoCam.MaxLength = 32767;
            this.cmbVoCam.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cmbVoCam.Name = "cmbVoCam";
            this.cmbVoCam.OddRowStyle = style14;
            this.cmbVoCam.PartialRightColumn = false;
            this.cmbVoCam.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.cmbVoCam.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.cmbVoCam.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cmbVoCam.SelectedStyle = style15;
            this.cmbVoCam.Size = new System.Drawing.Size(207, 20);
            this.cmbVoCam.Style = style16;
            this.cmbVoCam.TabIndex = 10;
            this.cmbVoCam.PropBag = resources.GetString("cmbVoCam.PropBag");
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(9, 124);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(102, 15);
            this.label10.TabIndex = 9;
            this.label10.Text = "P.Pháp vô cảm";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cmbSoSanh
            // 
            this.cmbSoSanh.AddItemSeparator = ';';
            this.cmbSoSanh.AllowColMove = false;
            this.cmbSoSanh.AllowRowSizing = C1.Win.C1List.RowSizingEnum.AllRows;
            this.cmbSoSanh.AutoCompletion = true;
            this.cmbSoSanh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cmbSoSanh.Caption = "";
            this.cmbSoSanh.CaptionHeight = 17;
            this.cmbSoSanh.CaptionStyle = style17;
            this.cmbSoSanh.CaptionVisible = false;
            this.cmbSoSanh.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cmbSoSanh.ColumnCaptionHeight = 17;
            this.cmbSoSanh.ColumnFooterHeight = 17;
            this.cmbSoSanh.ColumnHeaders = false;
            this.cmbSoSanh.ContentHeight = 16;
            this.cmbSoSanh.DataMode = C1.Win.C1List.DataModeEnum.AddItem;
            this.cmbSoSanh.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cmbSoSanh.DefColWidth = 1;
            this.cmbSoSanh.DisplayMember = "Danh mục";
            this.cmbSoSanh.EditorBackColor = System.Drawing.Color.White;
            this.cmbSoSanh.EditorFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSoSanh.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbSoSanh.EditorHeight = 16;
            this.cmbSoSanh.EvenRowStyle = style18;
            this.cmbSoSanh.ExtendRightColumn = true;
            this.cmbSoSanh.FlatStyle = C1.Win.C1List.FlatModeEnum.Popup;
            this.cmbSoSanh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSoSanh.FooterStyle = style19;
            this.cmbSoSanh.GapHeight = 2;
            this.cmbSoSanh.HeadingStyle = style20;
            this.cmbSoSanh.HighLightRowStyle = style21;
            this.cmbSoSanh.ItemHeight = 15;
            this.cmbSoSanh.Location = new System.Drawing.Point(114, 142);
            this.cmbSoSanh.MatchCol = C1.Win.C1List.MatchColEnum.AllCols;
            this.cmbSoSanh.MatchEntryTimeout = ((long)(2000));
            this.cmbSoSanh.MaxDropDownItems = ((short)(10));
            this.cmbSoSanh.MaxLength = 32767;
            this.cmbSoSanh.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cmbSoSanh.Name = "cmbSoSanh";
            this.cmbSoSanh.OddRowStyle = style22;
            this.cmbSoSanh.PartialRightColumn = false;
            this.cmbSoSanh.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.cmbSoSanh.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.cmbSoSanh.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cmbSoSanh.SelectedStyle = style23;
            this.cmbSoSanh.Size = new System.Drawing.Size(249, 20);
            this.cmbSoSanh.Style = style24;
            this.cmbSoSanh.TabIndex = 12;
            this.cmbSoSanh.PropBag = resources.GetString("cmbSoSanh.PropBag");
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(9, 145);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(102, 15);
            this.label11.TabIndex = 11;
            this.label11.Text = "So sánh CĐ";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cmbTaiBien
            // 
            this.cmbTaiBien.AddItemSeparator = ';';
            this.cmbTaiBien.AllowColMove = false;
            this.cmbTaiBien.AllowRowSizing = C1.Win.C1List.RowSizingEnum.AllRows;
            this.cmbTaiBien.AutoCompletion = true;
            this.cmbTaiBien.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cmbTaiBien.Caption = "";
            this.cmbTaiBien.CaptionHeight = 17;
            this.cmbTaiBien.CaptionStyle = style25;
            this.cmbTaiBien.CaptionVisible = false;
            this.cmbTaiBien.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cmbTaiBien.ColumnCaptionHeight = 17;
            this.cmbTaiBien.ColumnFooterHeight = 17;
            this.cmbTaiBien.ColumnHeaders = false;
            this.cmbTaiBien.ContentHeight = 16;
            this.cmbTaiBien.DataMode = C1.Win.C1List.DataModeEnum.AddItem;
            this.cmbTaiBien.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cmbTaiBien.DefColWidth = 1;
            this.cmbTaiBien.DisplayMember = "Danh mục";
            this.cmbTaiBien.EditorBackColor = System.Drawing.Color.White;
            this.cmbTaiBien.EditorFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTaiBien.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbTaiBien.EditorHeight = 16;
            this.cmbTaiBien.EvenRowStyle = style26;
            this.cmbTaiBien.ExtendRightColumn = true;
            this.cmbTaiBien.FlatStyle = C1.Win.C1List.FlatModeEnum.Popup;
            this.cmbTaiBien.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTaiBien.FooterStyle = style27;
            this.cmbTaiBien.GapHeight = 2;
            this.cmbTaiBien.HeadingStyle = style28;
            this.cmbTaiBien.HighLightRowStyle = style29;
            this.cmbTaiBien.ItemHeight = 15;
            this.cmbTaiBien.Location = new System.Drawing.Point(114, 163);
            this.cmbTaiBien.MatchCol = C1.Win.C1List.MatchColEnum.AllCols;
            this.cmbTaiBien.MatchEntryTimeout = ((long)(2000));
            this.cmbTaiBien.MaxDropDownItems = ((short)(10));
            this.cmbTaiBien.MaxLength = 32767;
            this.cmbTaiBien.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cmbTaiBien.Name = "cmbTaiBien";
            this.cmbTaiBien.OddRowStyle = style30;
            this.cmbTaiBien.PartialRightColumn = false;
            this.cmbTaiBien.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.cmbTaiBien.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.cmbTaiBien.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cmbTaiBien.SelectedStyle = style31;
            this.cmbTaiBien.Size = new System.Drawing.Size(249, 20);
            this.cmbTaiBien.Style = style32;
            this.cmbTaiBien.TabIndex = 14;
            this.cmbTaiBien.PropBag = resources.GetString("cmbTaiBien.PropBag");
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(9, 166);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(102, 15);
            this.label12.TabIndex = 13;
            this.label12.Text = "Tai biến";
            this.label12.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cmbLoaiPT
            // 
            this.cmbLoaiPT.AddItemSeparator = ';';
            this.cmbLoaiPT.AllowColMove = false;
            this.cmbLoaiPT.AllowRowSizing = C1.Win.C1List.RowSizingEnum.AllRows;
            this.cmbLoaiPT.AutoCompletion = true;
            this.cmbLoaiPT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cmbLoaiPT.Caption = "";
            this.cmbLoaiPT.CaptionHeight = 17;
            this.cmbLoaiPT.CaptionStyle = style33;
            this.cmbLoaiPT.CaptionVisible = false;
            this.cmbLoaiPT.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cmbLoaiPT.ColumnCaptionHeight = 17;
            this.cmbLoaiPT.ColumnFooterHeight = 17;
            this.cmbLoaiPT.ColumnHeaders = false;
            this.cmbLoaiPT.ContentHeight = 16;
            this.cmbLoaiPT.DataMode = C1.Win.C1List.DataModeEnum.AddItem;
            this.cmbLoaiPT.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cmbLoaiPT.DefColWidth = 1;
            this.cmbLoaiPT.DisplayMember = "Danh mục";
            this.cmbLoaiPT.EditorBackColor = System.Drawing.Color.White;
            this.cmbLoaiPT.EditorFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLoaiPT.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbLoaiPT.EditorHeight = 16;
            this.cmbLoaiPT.EvenRowStyle = style34;
            this.cmbLoaiPT.ExtendRightColumn = true;
            this.cmbLoaiPT.FlatStyle = C1.Win.C1List.FlatModeEnum.Popup;
            this.cmbLoaiPT.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLoaiPT.FooterStyle = style35;
            this.cmbLoaiPT.GapHeight = 2;
            this.cmbLoaiPT.HeadingStyle = style36;
            this.cmbLoaiPT.HighLightRowStyle = style37;
            this.cmbLoaiPT.ItemHeight = 15;
            this.cmbLoaiPT.Location = new System.Drawing.Point(114, 58);
            this.cmbLoaiPT.MatchCol = C1.Win.C1List.MatchColEnum.AllCols;
            this.cmbLoaiPT.MatchEntryTimeout = ((long)(2000));
            this.cmbLoaiPT.MaxDropDownItems = ((short)(10));
            this.cmbLoaiPT.MaxLength = 32767;
            this.cmbLoaiPT.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cmbLoaiPT.Name = "cmbLoaiPT";
            this.cmbLoaiPT.OddRowStyle = style38;
            this.cmbLoaiPT.PartialRightColumn = false;
            this.cmbLoaiPT.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.cmbLoaiPT.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.cmbLoaiPT.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cmbLoaiPT.SelectedStyle = style39;
            this.cmbLoaiPT.Size = new System.Drawing.Size(303, 20);
            this.cmbLoaiPT.Style = style40;
            this.cmbLoaiPT.TabIndex = 4;
            this.cmbLoaiPT.PropBag = resources.GetString("cmbLoaiPT.PropBag");
            // 
            // fg
            // 
            this.fg.AllowDelete = true;
            this.fg.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Light3D;
            this.fg.ColumnInfo = resources.GetString("fg.ColumnInfo");
            this.fg.ExtendLastCol = true;
            this.fg.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid;
            this.fg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fg.Location = new System.Drawing.Point(114, 187);
            this.fg.Name = "fg";
            this.fg.Rows.Count = 1;
            this.fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox;
            this.fg.ShowCursor = true;
            this.fg.Size = new System.Drawing.Size(382, 99);
            this.fg.Styles = new C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("fg.Styles"));
            this.fg.TabIndex = 16;
            // 
            // cmdThem
            // 
            this.cmdThem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdThem.Image = ((System.Drawing.Image)(resources.GetObject("cmdThem.Image")));
            this.cmdThem.Location = new System.Drawing.Point(224, 288);
            this.cmdThem.Name = "cmdThem";
            this.cmdThem.Size = new System.Drawing.Size(132, 27);
            this.cmdThem.TabIndex = 17;
            this.cmdThem.Text = "Cập nhật kíp mổ";
            this.cmdThem.Click += new System.EventHandler(this.cmdThem_Click);
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(9, 190);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(102, 15);
            this.label13.TabIndex = 15;
            this.label13.Text = "Kíp mổ";
            this.label13.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.PowderBlue;
            this.groupBox1.Controls.Add(this.lblHoTen);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblSoHSBA);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblNgayVaoVien);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lblTuoi);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.lblGioiTinh);
            this.groupBox1.Location = new System.Drawing.Point(4, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(502, 99);
            this.groupBox1.TabIndex = 151;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "THÔNG TIN BỆNH NHÂN";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.PowderBlue;
            this.groupBox2.Controls.Add(this.chkDaPT);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.cmbPhuongPhapPT);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.cmdThem);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.lblPhauThuat);
            this.groupBox2.Controls.Add(this.fg);
            this.groupBox2.Controls.Add(this.txtNgayPT);
            this.groupBox2.Controls.Add(this.txtGhiChu);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cmbLoaiPT);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.cmbTaiBien);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.cmbTinhChatPT);
            this.groupBox2.Controls.Add(this.cmbSoSanh);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.cmbVoCam);
            this.groupBox2.Location = new System.Drawing.Point(4, 106);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(502, 369);
            this.groupBox2.TabIndex = 152;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "THÔNG TIN VỀ LẦN PHẪU THUẬT";
            // 
            // chkDaPT
            // 
            this.chkDaPT.AutoSize = true;
            this.chkDaPT.Enabled = false;
            this.chkDaPT.Location = new System.Drawing.Point(255, 39);
            this.chkDaPT.Name = "chkDaPT";
            this.chkDaPT.Size = new System.Drawing.Size(94, 17);
            this.chkDaPT.TabIndex = 131;
            this.chkDaPT.Text = "Đã phẫu thuật";
            this.chkDaPT.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(9, 103);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(102, 15);
            this.label14.TabIndex = 7;
            this.label14.Text = "Phương pháp mổ";
            this.label14.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cmbPhuongPhapPT
            // 
            this.cmbPhuongPhapPT.AddItemSeparator = ';';
            this.cmbPhuongPhapPT.AllowColMove = false;
            this.cmbPhuongPhapPT.AllowRowSizing = C1.Win.C1List.RowSizingEnum.AllRows;
            this.cmbPhuongPhapPT.AutoCompletion = true;
            this.cmbPhuongPhapPT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cmbPhuongPhapPT.Caption = "";
            this.cmbPhuongPhapPT.CaptionHeight = 17;
            this.cmbPhuongPhapPT.CaptionStyle = style41;
            this.cmbPhuongPhapPT.CaptionVisible = false;
            this.cmbPhuongPhapPT.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cmbPhuongPhapPT.ColumnCaptionHeight = 17;
            this.cmbPhuongPhapPT.ColumnFooterHeight = 17;
            this.cmbPhuongPhapPT.ColumnHeaders = false;
            this.cmbPhuongPhapPT.ContentHeight = 16;
            this.cmbPhuongPhapPT.DataMode = C1.Win.C1List.DataModeEnum.AddItem;
            this.cmbPhuongPhapPT.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cmbPhuongPhapPT.DefColWidth = 1;
            this.cmbPhuongPhapPT.DisplayMember = "Danh mục";
            this.cmbPhuongPhapPT.EditorBackColor = System.Drawing.Color.White;
            this.cmbPhuongPhapPT.EditorFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPhuongPhapPT.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbPhuongPhapPT.EditorHeight = 16;
            this.cmbPhuongPhapPT.EvenRowStyle = style42;
            this.cmbPhuongPhapPT.ExtendRightColumn = true;
            this.cmbPhuongPhapPT.FlatStyle = C1.Win.C1List.FlatModeEnum.Popup;
            this.cmbPhuongPhapPT.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPhuongPhapPT.FooterStyle = style43;
            this.cmbPhuongPhapPT.GapHeight = 2;
            this.cmbPhuongPhapPT.HeadingStyle = style44;
            this.cmbPhuongPhapPT.HighLightRowStyle = style45;
            this.cmbPhuongPhapPT.ItemHeight = 15;
            this.cmbPhuongPhapPT.Location = new System.Drawing.Point(114, 100);
            this.cmbPhuongPhapPT.MatchCol = C1.Win.C1List.MatchColEnum.AllCols;
            this.cmbPhuongPhapPT.MatchEntryTimeout = ((long)(2000));
            this.cmbPhuongPhapPT.MaxDropDownItems = ((short)(10));
            this.cmbPhuongPhapPT.MaxLength = 32767;
            this.cmbPhuongPhapPT.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cmbPhuongPhapPT.Name = "cmbPhuongPhapPT";
            this.cmbPhuongPhapPT.OddRowStyle = style46;
            this.cmbPhuongPhapPT.PartialRightColumn = false;
            this.cmbPhuongPhapPT.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.cmbPhuongPhapPT.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.cmbPhuongPhapPT.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cmbPhuongPhapPT.SelectedStyle = style47;
            this.cmbPhuongPhapPT.Size = new System.Drawing.Size(207, 20);
            this.cmbPhuongPhapPT.Style = style48;
            this.cmbPhuongPhapPT.TabIndex = 8;
            this.cmbPhuongPhapPT.PropBag = resources.GetString("cmbPhuongPhapPT.PropBag");
            // 
            // frmXacNhanPhauThuat_ChiTiet
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(509, 509);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmdEdit);
            this.Controls.Add(this.cmdThoat);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmXacNhanPhauThuat_ChiTiet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tổng kết phẫu thuật";
            this.Load += new System.EventHandler(this.frmXacNhanPhauThuat_ChiTiet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtNgayPT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTinhChatPT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbVoCam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSoSanh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTaiBien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLoaiPT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fg)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPhuongPhapPT)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void cmdThoat_Click(object sender, System.EventArgs e)
		{
			this.Dispose();
		}

		private void cmdEdit_Click(object sender, System.EventArgs e)
		{
			//byte DaPT=0;
			
			string StrSQL = string.Format("UPDATE BENHNHAN_PHAUTHUAT SET GhiChu=N'{0}',NgayPhauThuat='{1:MM/dd/yyyy}',DaPhauThuat={2},LoaiPT={3},TinhChatpt={4},vOcAM={5},SoSanh={6},TaiBien={7},PhuongPhapPT={11} WHERE MaBenhNhan='{8}' AND LanPT={9} AND LanVaoVien={10}",
				txtGhiChu.Text,
				txtNgayPT.Value,
				(chkDaPT.Checked)?(1):(0),
				(GlobalModuls.Global.GetCode(cmbLoaiPT)=="")?("Null"):("'" + GlobalModuls.Global.GetCode(cmbLoaiPT) + "'"),
				(GlobalModuls.Global.GetCode(cmbTinhChatPT)=="")?("Null"):("'" + GlobalModuls.Global.GetCode(cmbTinhChatPT) + "'"),
				(GlobalModuls.Global.GetCode(cmbVoCam)=="")?("Null"):("'" + GlobalModuls.Global.GetCode(cmbVoCam) + "'"),
				(GlobalModuls.Global.GetCode(cmbSoSanh)=="")?("Null"):("'" + GlobalModuls.Global.GetCode(cmbSoSanh) + "'"),
				(GlobalModuls.Global.GetCode(cmbTaiBien)=="")?("Null"):("'" + GlobalModuls.Global.GetCode(cmbTaiBien) + "'"),
				lblSoHSBA.Text,LanPT,LanVaoVien,
                (GlobalModuls.Global.GetCode(cmbPhuongPhapPT) == "") ? ("Null") : ("'" + GlobalModuls.Global.GetCode(cmbPhuongPhapPT) + "'"));
			System.Data.SqlClient.SqlCommand SQLCmd=new System.Data.SqlClient.SqlCommand(StrSQL,GlobalModuls.Global.ConnectSQL);
			SQLCmd.ExecuteNonQuery();
			
			NgayPT=DateTime.Parse(txtNgayPT.Value.ToString()).Date;
			GhiChu=txtGhiChu.Text;
			DaPT = chkDaPT.Checked;
			int SoTT_BS=1;
			System.Data.SqlClient.SqlTransaction trn;
			trn=GlobalModuls.Global.ConnectSQL.BeginTransaction();
			SQLCmd.Transaction =trn;
			try
			{
				SQLCmd.CommandText =string.Format("DELETE FROM BENHNHAN_PT_KIPMO WHERE MaBenhNhan='{0}' AND LanVaoVien={1} AND LanPT = {2}",lblSoHSBA.Text,LanVaoVien,LanPT);
				SQLCmd.ExecuteNonQuery();
				for (int i=1;i<fg.Rows.Count;i++)
				{
					if (fg.GetDataDisplay(i,1) !="" && fg.GetDataDisplay(i,2) !="")
					{
						StrSQL = string.Format("INSERT INTO BENHNHAN_PT_KIPMO (MaBenhNhan,LanVaoVien,LanPT,SoTTBS,TenBacSy,ViTri) VALUES ('{0}',{1},{2},{3},N'{4}',N'{5}')",
							lblSoHSBA.Text,
							LanVaoVien,
							LanPT,
							SoTT_BS,
							fg.GetDataDisplay(i,1),
							fg.GetDataDisplay(i,2));
						SQLCmd.CommandText = StrSQL;
						SQLCmd.ExecuteNonQuery();
						SoTT_BS +=1;
					}
				}
			}
			catch (Exception ex)
			{
				trn.Rollback();
				MessageBox.Show("Có lỗi khi ghi dữ liệu!\n" + ex.Message,"Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
				SQLCmd.Dispose();
				return;
			}
			trn.Commit();
			SQLCmd.Dispose();
			trn.Dispose();
			this.Dispose();
		}

		private void frmXacNhanPhauThuat_ChiTiet_Load(object sender, System.EventArgs e)
		{
			LoadDM();
			LoadPT();
		}
		private void LoadDM()
		{
			System.Data.SqlClient.SqlDataReader dr;
			System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
			cmd.Connection = GlobalModuls.Global.ConnectSQL;
			cmbSoSanh.AddItem("1;Đúng");
			cmbSoSanh.AddItem("2;Sai một phần");
			cmbSoSanh.AddItem("3;Sai hoàn toàn");
			cmd.CommandText = "SELECT * FROM DMLOAIPT";
			dr=cmd.ExecuteReader();
			cmbLoaiPT.ClearItems();
			while (dr.Read())
			{
				cmbLoaiPT.AddItem(string.Format("{0};{1}",dr["MaLoaiPT"],dr["TenLoaiPT"]));
			}
			dr.Close();
			cmd.CommandText = "SELECT * FROM DMTINHCHATMO";
			dr=cmd.ExecuteReader();
			cmbTinhChatPT.ClearItems();
			while (dr.Read())
			{
				cmbTinhChatPT.AddItem(string.Format("{0};{1}",dr["MaTCPT"],dr["TenTCPT"]));
			}
            dr.Close();
            cmd.CommandText = "SELECT * FROM DMPHUONGPHAPPT";
            dr = cmd.ExecuteReader();
            cmbPhuongPhapPT.ClearItems();
            while (dr.Read())
            {
                cmbPhuongPhapPT.AddItem(string.Format("{0};{1}", dr["MaPPPT"], dr["TenPPPT"]));
            }
			dr.Close();
			cmd.CommandText = "SELECT * FROM DMVOCAM";
			dr=cmd.ExecuteReader();
			cmbVoCam.ClearItems();
			while (dr.Read())
			{
				cmbVoCam.AddItem(string.Format("{0};{1}",dr["MaVoCam"],dr["TenVoCam"]));
			}
			dr.Close();
			cmd.CommandText = "SELECT * FROM DMTAIBIEN";
			dr=cmd.ExecuteReader();
			cmbTaiBien.ClearItems();
			while (dr.Read())
			{
				cmbTaiBien.AddItem(string.Format("{0};{1}",dr["MaTaiBien"],dr["TenTaiBien"]));
			}
			dr.Close();
			cmd.CommandText ="SELECT * FROM DMVITRI_PT";
			dr=cmd.ExecuteReader();
			string tmps="";
			while (dr.Read())
			{
				tmps += dr["TenVT"].ToString()+"|";
			}
			fg.Cols[2].ComboList = tmps;
			dr.Close();
			cmd.Dispose();
		}
		private void LoadPT()
		{
			System.Data.SqlClient.SqlDataReader dr;
			System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
			cmd.Connection = GlobalModuls.Global.ConnectSQL;
			cmd.CommandText = "SELECT *,Year(GetDate())-NamSinh As Tuoi FROM BENHNHAN INNER JOIN BENHNHAN_CHITIET ON BENHNHAN.MaBenhNhan=BENHNHAN_CHITIET.MaBenhNhan WHERE BENHNHAN_CHITIET.MaBenhNhan='" + MaBenhNhan + "' AND LanVaoVien=" + LanVaoVien;
			dr=cmd.ExecuteReader();			
			while (dr.Read())
			{
				lblTuoi.Text = dr["Tuoi"].ToString();
				lblHoTen.Text = dr["HoTen"].ToString();
				lblGioiTinh.Text =(dr["GioiTinh"].ToString()=="1")?("Nam"):("Nữ");
				lblNgayVaoVien.Text  = string.Format("{0:dd/MM/yyyy}",dr["NgayVaoVien"]);
			}
			dr.Close();
			cmd.CommandText =string.Format("SELECT BENHNHAN_PHAUTHUAT.*,TenPP FROM BENHNHAN_PHAUTHUAT INNER JOIN DMPHUONGPHAPDIEUTRI ON BENHNHAN_PHAUTHUAT.YeuCauPhauThuat=MaPP WHERE MaBenhNhan='{0}' AND LanVaoVien={1} AND LanPT={2}",MaBenhNhan,LanVaoVien,LanPT);
			dr=cmd.ExecuteReader();
			while (dr.Read())
			{
				lblPhauThuat.Text = dr["TenPP"].ToString();
				txtNgayPT.Value = string.Format("{0:dd/MM/yyyy}",dr["NgayPhauThuat"]);
				chkDaPT.Checked = (dr["DaPhauThuat"].ToString()=="1");
				GlobalModuls.Global.SetCmb(cmbLoaiPT,dr["LoaiPT"].ToString());
				GlobalModuls.Global.SetCmb(cmbTinhChatPT,dr["TinhChatPT"].ToString());
				GlobalModuls.Global.SetCmb(cmbVoCam,dr["VoCam"].ToString());
				GlobalModuls.Global.SetCmb(cmbSoSanh,dr["Sosanh"].ToString());
				GlobalModuls.Global.SetCmb(cmbTaiBien,dr["TaiBien"].ToString());
                GlobalModuls.Global.SetCmb(cmbPhuongPhapPT, dr["PhuongPhapPT"].ToString());
				txtGhiChu.Text = dr["GhiChu"].ToString();
			}
			dr.Close();
			cmd.CommandText =string.Format("SELECT * FROM BENHNHAN_PT_KIPMO WHERE MaBenhNhan='{0}' AND LanVaoVien={1} AND LanPT={2} ORDER BY SoTTBS",lblSoHSBA.Text,LanVaoVien,LanPT);
			dr=cmd.ExecuteReader();
			fg.Rows.Count =1;
			fg.ClipSeparators ="|;";
			while (dr.Read())
			{
				fg.AddItem(string.Format("{0}|{1}|{2}",dr["SoTTBS"],dr["TenBacSy"],dr["ViTri"]));
			}		
			dr.Close();
			cmd.Dispose();
		}

		private void cmdThem_Click(object sender, System.EventArgs e)
		{
			NamDinh_QLBN.Forms.DuLieu.frmCapNhatKipMo fr = new frmCapNhatKipMo(fg,"1");			
			fr.ShowDialog();
		}
	}
}
