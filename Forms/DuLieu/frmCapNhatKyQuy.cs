using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using GlobalModuls;

namespace NamDinh_QLBN.Forms.DuLieu
{
	/// <summary>
	/// Summary description for frmCapNhatKyQuy.
	/// </summary>
	public class frmCapNhatKyQuy : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox txtDoiTuong;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox txtGioi;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtTuoi;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtHoTen;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtSoHSBA;
		private System.Windows.Forms.Label label1;
		private C1.Win.C1FlexGrid.C1FlexGrid fg;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtLanKQ;
		private C1.Win.C1Input.C1DateEdit txtNgayKQ;
		private System.Windows.Forms.Label label13;
		private C1.Win.C1Input.C1NumericEdit txtSoTien;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private long TongKyQuy=0;
		private long TongTT =0;
		private long TongCP=0;
		private bool isAddNew = false;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox txtKyQuy;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox txtTongChiPhi;
		private System.Windows.Forms.TextBox txtTongTT;
		private System.Windows.Forms.Label label11;
		private DevExpress.XtraEditors.SimpleButton cmdBrowse;
		private System.Windows.Forms.TextBox txtThuaThieu;
		private System.Windows.Forms.Label lblThuaThieu;
		private DevExpress.XtraEditors.SimpleButton cmdXoa;
		private DevExpress.XtraEditors.SimpleButton cmdIn;
		private DevExpress.XtraEditors.SimpleButton cmdThoat;
		private DevExpress.XtraEditors.SimpleButton cmdHuy;
		private DevExpress.XtraEditors.SimpleButton cmdGhi;
		private DevExpress.XtraEditors.SimpleButton cmdSua;
		private DevExpress.XtraEditors.SimpleButton cmdThem;
		private System.Windows.Forms.TextBox txtGhiChu;
		internal C1.Win.C1List.C1Combo cmbKhoa;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.TextBox txtSoBL;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.TextBox txtLanVV;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmCapNhatKyQuy()
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
            C1.Win.C1List.Style style1 = new C1.Win.C1List.Style();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCapNhatKyQuy));
            C1.Win.C1List.Style style2 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style3 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style4 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style5 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style6 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style7 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style8 = new C1.Win.C1List.Style();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtLanVV = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cmbKhoa = new C1.Win.C1List.C1Combo();
            this.label12 = new System.Windows.Forms.Label();
            this.cmdBrowse = new DevExpress.XtraEditors.SimpleButton();
            this.txtDoiTuong = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtGioi = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTuoi = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSoHSBA = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.fg = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtSoBL = new System.Windows.Forms.TextBox();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSoTien = new C1.Win.C1Input.C1NumericEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNgayKQ = new C1.Win.C1Input.C1DateEdit();
            this.label13 = new System.Windows.Forms.Label();
            this.txtLanKQ = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTongChiPhi = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtKyQuy = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtTongTT = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtThuaThieu = new System.Windows.Forms.TextBox();
            this.lblThuaThieu = new System.Windows.Forms.Label();
            this.cmdXoa = new DevExpress.XtraEditors.SimpleButton();
            this.cmdIn = new DevExpress.XtraEditors.SimpleButton();
            this.cmdThoat = new DevExpress.XtraEditors.SimpleButton();
            this.cmdHuy = new DevExpress.XtraEditors.SimpleButton();
            this.cmdGhi = new DevExpress.XtraEditors.SimpleButton();
            this.cmdSua = new DevExpress.XtraEditors.SimpleButton();
            this.cmdThem = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKhoa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fg)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoTien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNgayKQ)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtLanVV);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.cmbKhoa);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.cmdBrowse);
            this.groupBox1.Controls.Add(this.txtDoiTuong);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtGioi);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtTuoi);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtHoTen);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtSoHSBA);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(603, 84);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // txtLanVV
            // 
            this.txtLanVV.Location = new System.Drawing.Point(555, 57);
            this.txtLanVV.Name = "txtLanVV";
            this.txtLanVV.ReadOnly = true;
            this.txtLanVV.Size = new System.Drawing.Size(30, 20);
            this.txtLanVV.TabIndex = 108;
            this.txtLanVV.TabStop = false;
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(483, 60);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(69, 15);
            this.label15.TabIndex = 107;
            this.label15.Text = "Lần vào viện";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbKhoa
            // 
            this.cmbKhoa.AddItemSeparator = ';';
            this.cmbKhoa.AllowColMove = false;
            this.cmbKhoa.AllowRowSizing = C1.Win.C1List.RowSizingEnum.AllRows;
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
            this.cmbKhoa.Location = new System.Drawing.Point(78, 12);
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
            this.cmbKhoa.Size = new System.Drawing.Size(330, 20);
            this.cmbKhoa.Style = style8;
            this.cmbKhoa.TabIndex = 106;
            this.cmbKhoa.PropBag = resources.GetString("cmbKhoa.PropBag");
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(6, 15);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(72, 15);
            this.label12.TabIndex = 105;
            this.label12.Text = "Khoa, Phòng";
            // 
            // cmdBrowse
            // 
            this.cmdBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdBrowse.Location = new System.Drawing.Point(153, 33);
            this.cmdBrowse.Name = "cmdBrowse";
            this.cmdBrowse.Size = new System.Drawing.Size(30, 21);
            this.cmdBrowse.TabIndex = 95;
            this.cmdBrowse.Text = "...";
            this.cmdBrowse.Click += new System.EventHandler(this.cmdBrowse_Click);
            // 
            // txtDoiTuong
            // 
            this.txtDoiTuong.Location = new System.Drawing.Point(246, 57);
            this.txtDoiTuong.Name = "txtDoiTuong";
            this.txtDoiTuong.ReadOnly = true;
            this.txtDoiTuong.Size = new System.Drawing.Size(189, 20);
            this.txtDoiTuong.TabIndex = 10;
            this.txtDoiTuong.TabStop = false;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(189, 60);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 15);
            this.label8.TabIndex = 9;
            this.label8.Text = "Đối tượng";
            // 
            // txtGioi
            // 
            this.txtGioi.Location = new System.Drawing.Point(555, 33);
            this.txtGioi.Name = "txtGioi";
            this.txtGioi.ReadOnly = true;
            this.txtGioi.Size = new System.Drawing.Size(42, 20);
            this.txtGioi.TabIndex = 8;
            this.txtGioi.TabStop = false;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(501, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "Giới tính";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTuoi
            // 
            this.txtTuoi.Location = new System.Drawing.Point(471, 33);
            this.txtTuoi.Name = "txtTuoi";
            this.txtTuoi.ReadOnly = true;
            this.txtTuoi.Size = new System.Drawing.Size(30, 20);
            this.txtTuoi.TabIndex = 6;
            this.txtTuoi.TabStop = false;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(438, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tuổi";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(246, 33);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.ReadOnly = true;
            this.txtHoTen.Size = new System.Drawing.Size(189, 20);
            this.txtHoTen.TabIndex = 4;
            this.txtHoTen.TabStop = false;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(189, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Họ và tên";
            // 
            // txtSoHSBA
            // 
            this.txtSoHSBA.Location = new System.Drawing.Point(78, 33);
            this.txtSoHSBA.Name = "txtSoHSBA";
            this.txtSoHSBA.Size = new System.Drawing.Size(72, 20);
            this.txtSoHSBA.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(21, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Số HSBA";
            // 
            // fg
            // 
            this.fg.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.fg.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
            this.fg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Light3D;
            this.fg.ColumnInfo = resources.GetString("fg.ColumnInfo");
            this.fg.ExtendLastCol = true;
            this.fg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fg.HighLight = C1.Win.C1FlexGrid.HighLightEnum.WithFocus;
            this.fg.Location = new System.Drawing.Point(3, 93);
            this.fg.Name = "fg";
            this.fg.Rows.Count = 1;
            this.fg.Rows.MinSize = 20;
            this.fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
            this.fg.ShowCursor = true;
            this.fg.Size = new System.Drawing.Size(318, 232);
            this.fg.Styles = new C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("fg.Styles"));
            this.fg.TabIndex = 20;
            this.fg.AfterSelChange += new C1.Win.C1FlexGrid.RangeEventHandler(this.fg_AfterSelChange);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.txtSoBL);
            this.groupBox2.Controls.Add(this.txtGhiChu);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtSoTien);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtNgayKQ);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.txtLanKQ);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(327, 87);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(276, 153);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chi tiết";
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label14.Location = new System.Drawing.Point(6, 60);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(87, 15);
            this.label14.TabIndex = 95;
            this.label14.Text = "Số biên lai";
            // 
            // txtSoBL
            // 
            this.txtSoBL.Location = new System.Drawing.Point(96, 57);
            this.txtSoBL.Name = "txtSoBL";
            this.txtSoBL.Size = new System.Drawing.Size(108, 20);
            this.txtSoBL.TabIndex = 3;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.BackColor = System.Drawing.Color.White;
            this.txtGhiChu.Location = new System.Drawing.Point(96, 99);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(174, 45);
            this.txtGhiChu.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(6, 102);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 18);
            this.label7.TabIndex = 92;
            this.label7.Text = "Ghi chú";
            // 
            // txtSoTien
            // 
            this.txtSoTien.BackColor = System.Drawing.Color.White;
            this.txtSoTien.CustomFormat = "##,###,###";
            this.txtSoTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoTien.ForeColor = System.Drawing.Color.Black;
            this.txtSoTien.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
            this.txtSoTien.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.txtSoTien.Location = new System.Drawing.Point(96, 78);
            this.txtSoTien.Name = "txtSoTien";
            this.txtSoTien.Size = new System.Drawing.Size(111, 20);
            this.txtSoTien.TabIndex = 4;
            this.txtSoTien.Tag = null;
            this.txtSoTien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSoTien.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.UpDown;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(6, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 15);
            this.label6.TabIndex = 90;
            this.label6.Text = "Số tiền";
            // 
            // txtNgayKQ
            // 
            this.txtNgayKQ.BackColor = System.Drawing.Color.White;
            this.txtNgayKQ.Culture = 1066;
            this.txtNgayKQ.CustomFormat = "dd/MM/yyyy";
            this.txtNgayKQ.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
            this.txtNgayKQ.Location = new System.Drawing.Point(96, 36);
            this.txtNgayKQ.Name = "txtNgayKQ";
            this.txtNgayKQ.Size = new System.Drawing.Size(110, 20);
            this.txtNgayKQ.TabIndex = 2;
            this.txtNgayKQ.Tag = null;
            // 
            // label13
            // 
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label13.Location = new System.Drawing.Point(6, 39);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(87, 15);
            this.label13.TabIndex = 88;
            this.label13.Text = "Ngày tạm thu";
            // 
            // txtLanKQ
            // 
            this.txtLanKQ.BackColor = System.Drawing.Color.White;
            this.txtLanKQ.Location = new System.Drawing.Point(96, 15);
            this.txtLanKQ.Name = "txtLanKQ";
            this.txtLanKQ.ReadOnly = true;
            this.txtLanKQ.Size = new System.Drawing.Size(51, 20);
            this.txtLanKQ.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(6, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 18);
            this.label4.TabIndex = 0;
            this.label4.Text = "Lần tạm thu";
            // 
            // txtTongChiPhi
            // 
            this.txtTongChiPhi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtTongChiPhi.Location = new System.Drawing.Point(498, 243);
            this.txtTongChiPhi.Name = "txtTongChiPhi";
            this.txtTongChiPhi.ReadOnly = true;
            this.txtTongChiPhi.Size = new System.Drawing.Size(99, 20);
            this.txtTongChiPhi.TabIndex = 23;
            this.txtTongChiPhi.TabStop = false;
            this.txtTongChiPhi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(387, 246);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(105, 18);
            this.label9.TabIndex = 22;
            this.label9.Text = "Chi phí đã sử dụng";
            // 
            // txtKyQuy
            // 
            this.txtKyQuy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtKyQuy.Location = new System.Drawing.Point(498, 261);
            this.txtKyQuy.Name = "txtKyQuy";
            this.txtKyQuy.ReadOnly = true;
            this.txtKyQuy.Size = new System.Drawing.Size(99, 20);
            this.txtKyQuy.TabIndex = 25;
            this.txtKyQuy.TabStop = false;
            this.txtKyQuy.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(387, 264);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(105, 18);
            this.label10.TabIndex = 24;
            this.label10.Text = "Tổng ký quỹ";
            // 
            // txtTongTT
            // 
            this.txtTongTT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtTongTT.Location = new System.Drawing.Point(498, 279);
            this.txtTongTT.Name = "txtTongTT";
            this.txtTongTT.ReadOnly = true;
            this.txtTongTT.Size = new System.Drawing.Size(99, 20);
            this.txtTongTT.TabIndex = 27;
            this.txtTongTT.TabStop = false;
            this.txtTongTT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(387, 282);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(105, 18);
            this.label11.TabIndex = 26;
            this.label11.Text = "Đã thanh toán";
            // 
            // txtThuaThieu
            // 
            this.txtThuaThieu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtThuaThieu.Location = new System.Drawing.Point(498, 300);
            this.txtThuaThieu.Name = "txtThuaThieu";
            this.txtThuaThieu.ReadOnly = true;
            this.txtThuaThieu.Size = new System.Drawing.Size(99, 20);
            this.txtThuaThieu.TabIndex = 29;
            this.txtThuaThieu.TabStop = false;
            this.txtThuaThieu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblThuaThieu
            // 
            this.lblThuaThieu.Location = new System.Drawing.Point(387, 303);
            this.lblThuaThieu.Name = "lblThuaThieu";
            this.lblThuaThieu.Size = new System.Drawing.Size(105, 18);
            this.lblThuaThieu.TabIndex = 28;
            this.lblThuaThieu.Text = "Thừa, thiếu";
            // 
            // cmdXoa
            // 
            this.cmdXoa.Image = ((System.Drawing.Image)(resources.GetObject("cmdXoa.Image")));
            this.cmdXoa.Location = new System.Drawing.Point(171, 328);
            this.cmdXoa.Name = "cmdXoa";
            this.cmdXoa.Size = new System.Drawing.Size(69, 27);
            this.cmdXoa.TabIndex = 100;
            this.cmdXoa.Text = "Xóa";
            this.cmdXoa.Click += new System.EventHandler(this.cmdXoa_Click);
            // 
            // cmdIn
            // 
            this.cmdIn.Image = ((System.Drawing.Image)(resources.GetObject("cmdIn.Image")));
            this.cmdIn.Location = new System.Drawing.Point(408, 328);
            this.cmdIn.Name = "cmdIn";
            this.cmdIn.Size = new System.Drawing.Size(69, 27);
            this.cmdIn.TabIndex = 102;
            this.cmdIn.Text = "In";
            // 
            // cmdThoat
            // 
            this.cmdThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdThoat.Image = ((System.Drawing.Image)(resources.GetObject("cmdThoat.Image")));
            this.cmdThoat.Location = new System.Drawing.Point(534, 328);
            this.cmdThoat.Name = "cmdThoat";
            this.cmdThoat.Size = new System.Drawing.Size(69, 27);
            this.cmdThoat.TabIndex = 101;
            this.cmdThoat.Text = "Thoát";
            this.cmdThoat.Click += new System.EventHandler(this.cmdThoat_Click);
            // 
            // cmdHuy
            // 
            this.cmdHuy.Image = ((System.Drawing.Image)(resources.GetObject("cmdHuy.Image")));
            this.cmdHuy.Location = new System.Drawing.Point(339, 328);
            this.cmdHuy.Name = "cmdHuy";
            this.cmdHuy.Size = new System.Drawing.Size(69, 27);
            this.cmdHuy.TabIndex = 97;
            this.cmdHuy.Text = "Hủy";
            this.cmdHuy.Click += new System.EventHandler(this.cmdHuy_Click);
            // 
            // cmdGhi
            // 
            this.cmdGhi.Image = ((System.Drawing.Image)(resources.GetObject("cmdGhi.Image")));
            this.cmdGhi.Location = new System.Drawing.Point(270, 328);
            this.cmdGhi.Name = "cmdGhi";
            this.cmdGhi.Size = new System.Drawing.Size(69, 27);
            this.cmdGhi.TabIndex = 96;
            this.cmdGhi.Text = "Ghi";
            this.cmdGhi.Click += new System.EventHandler(this.cmdGhi_Click);
            // 
            // cmdSua
            // 
            this.cmdSua.Image = ((System.Drawing.Image)(resources.GetObject("cmdSua.Image")));
            this.cmdSua.Location = new System.Drawing.Point(72, 328);
            this.cmdSua.Name = "cmdSua";
            this.cmdSua.Size = new System.Drawing.Size(69, 27);
            this.cmdSua.TabIndex = 99;
            this.cmdSua.Text = "Sửa";
            this.cmdSua.Click += new System.EventHandler(this.cmdSua_Click);
            // 
            // cmdThem
            // 
            this.cmdThem.Image = ((System.Drawing.Image)(resources.GetObject("cmdThem.Image")));
            this.cmdThem.Location = new System.Drawing.Point(3, 328);
            this.cmdThem.Name = "cmdThem";
            this.cmdThem.Size = new System.Drawing.Size(69, 27);
            this.cmdThem.TabIndex = 98;
            this.cmdThem.Text = "Thêm";
            this.cmdThem.Click += new System.EventHandler(this.cmdThem_Click);
            // 
            // frmCapNhatKyQuy
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(607, 357);
            this.Controls.Add(this.cmdXoa);
            this.Controls.Add(this.cmdIn);
            this.Controls.Add(this.cmdThoat);
            this.Controls.Add(this.cmdHuy);
            this.Controls.Add(this.cmdGhi);
            this.Controls.Add(this.cmdSua);
            this.Controls.Add(this.cmdThem);
            this.Controls.Add(this.txtThuaThieu);
            this.Controls.Add(this.txtTongTT);
            this.Controls.Add(this.txtKyQuy);
            this.Controls.Add(this.txtTongChiPhi);
            this.Controls.Add(this.fg);
            this.Controls.Add(this.lblThuaThieu);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmCapNhatKyQuy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cập nhật ký quỹ của bệnh nhân";
            this.Load += new System.EventHandler(this.frmCapNhatKyQuy_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKhoa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fg)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoTien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNgayKQ)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void cmdBrowse_Click(object sender, System.EventArgs e)
		{			
            //NamDinh_QLBN.Forms.DuLieu.frmShowDSBenhNhan fr = new frmShowDSBenhNhan(txtSoHSBA.Text,GlobalModuls.Global.GetCode(cmbKhoa),cmbKhoa.Text);
            //fr.ShowDialog();
            //if (fr.SoHSBAReturn =="") {return;}
            //byte LanVaoVien=0;
            //txtSoHSBA.Text = fr.SoHSBAReturn;
            //txtHoTen.Text = fr.HoTenReturn;
            //txtTuoi.Text = fr.TuoiReturn;
            //txtGioi.Text = fr.GioiReturn;			
            //txtDoiTuong.Text = fr.DoiTuongReturn;
            //LanVaoVien = fr.LanVaoVienReturn;
            //txtLanVV.Text = LanVaoVien.ToString();
            //TongKyQuy = fr.KyQuy;
            //txtKyQuy.Text = string.Format("{0:#,###}",TongKyQuy);
            //System.Data.SqlClient.SqlDataReader dr;
            //System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            //SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            //SQLCmd.CommandText ="SELECT * FROM BENHNHAN_KYQUY WHERE MaBenhNhan='" + txtSoHSBA.Text + "' AND LanVaoVien =" + txtLanVV.Text + " ORDER BY LanKQ";
            //dr=SQLCmd.ExecuteReader();
            //fg.Tag ="0";
            //fg.Rows.Count =1;
            //while (dr.Read())
            //{
            //    fg.AddItem(string.Format("{0}|{1:dd/MM/yyyy}|{2}|{3:#,###}|{4}",dr["LanKQ"],dr["NgayKQ"],dr["SoBLKQ"],dr["SoTien"],dr["GhiChu"]));
            //}
			
            //dr.Close();
            //fg.Tag="1";
            //fg.Row=0;
            //if (fg.Rows.Count>1) {fg.Row =1;}
            //SQLCmd.CommandText="SELECT Sum(SoLuong*DonGia) As TongCP FROM BENHNHAN_CHIPHI WHERE MaBenhNhan='" + txtSoHSBA.Text +"' AND LanVaoVien =" + txtLanVV.Text + " AND DaThucHien=1";
            //dr=SQLCmd.ExecuteReader();
            //dr.Read();
            //if (dr["TongCP"]!=System.DBNull.Value){TongCP = long.Parse(string.Format("{0:0}", dr["TongCP"]));}
            //txtTongChiPhi.Text = string.Format("{0:#,###}",TongCP);
            //dr.Close();											
            //SQLCmd.CommandText="SELECT Sum(TienTT) As TongTT FROM BENHNHAN_THANHTOAN WHERE MaBenhNhan='" + txtSoHSBA.Text +"' AND LanVaoVien =" + txtLanVV.Text + "";
            //dr=SQLCmd.ExecuteReader();
            //dr.Read();
			
            //if (dr["TongTT"] != System.DBNull.Value){TongTT = long.Parse(string.Format("{0:0}", dr["TongTT"]));}	
            //dr.Close();
            //txtTongTT.Text= string.Format("{0:#,###}",TongTT);
            //long ThuaThieu = TongKyQuy + TongTT - TongCP;
            //if (ThuaThieu<0) {lblThuaThieu.Text = "Thiếu";} else {lblThuaThieu.Text = "Thừa";}
            //txtThuaThieu.Text = string.Format("{0:#,###}",Math.Abs(ThuaThieu));
            //SQLCmd.Dispose();
		}

		private void frmCapNhatKyQuy_Load(object sender, System.EventArgs e)
		{
			fg.ClipSeparators = "|;";
			System.Data.SqlClient.SqlDataReader dr;
			System.Data.SqlClient.SqlCommand SQLCmd= new System.Data.SqlClient.SqlCommand();
			SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
			SQLCmd.CommandText  = "SELECT * FROM DMKHOAPHONG WHERE MaKhoa IN " + GlobalModuls.Global.glbKhoa_CapNhat;
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
			SQLCmd.Dispose();
			LockEdit(true);
		}		
		private void LockEdit(bool IsLocked)
		{
			cmdThem.Visible = IsLocked;
			cmdSua.Visible = IsLocked;
			cmdXoa.Visible = IsLocked;
			cmdThoat.Visible = IsLocked;
			cmdIn.Visible = IsLocked;

			cmdGhi.Visible = !IsLocked;
			cmdHuy.Visible = !IsLocked;
			cmdBrowse.Enabled =IsLocked;

			fg.Enabled = IsLocked;			
			
			//txtLanKQ.ReadOnly = IsLocked;
			txtNgayKQ.ReadOnly = IsLocked;
			txtSoTien.ReadOnly = IsLocked;
			txtGhiChu.ReadOnly = IsLocked;

			txtSoHSBA.ReadOnly = !IsLocked;
		}

		private void cmdThoat_Click(object sender, System.EventArgs e)
		{
			this.Dispose();
		}

		private void fg_AfterSelChange(object sender, C1.Win.C1FlexGrid.RangeEventArgs e)
		{
			if (fg.Tag.ToString()=="0" || fg.Row<1) {return;}
			txtLanKQ.Text  = fg.GetDataDisplay(fg.Row,0);
			txtNgayKQ.Value  = (fg.GetDataDisplay(fg.Row,1)=="")?(null):(fg.GetDataDisplay(fg.Row,1));
			txtSoBL.Text =fg.GetDataDisplay(fg.Row,2);
			txtSoTien.Value =(fg.GetDataDisplay(fg.Row,3)=="")?(0):(decimal.Parse(fg.GetData(fg.Row,3).ToString()));
			txtGhiChu.Text =fg.GetDataDisplay(fg.Row,4);
		}

		private void cmdSua_Click(object sender, System.EventArgs e)
		{
			if (txtLanKQ.Text =="") {return;}
			isAddNew = false;
			LockEdit(false);
		}

		private void cmdHuy_Click(object sender, System.EventArgs e)
		{
			if (fg.Row>0)
			{
				txtLanKQ.Text  = fg.GetDataDisplay(fg.Row,0);
				txtNgayKQ.Value  = (fg.GetDataDisplay(fg.Row,1)=="")?(null):(fg.GetDataDisplay(fg.Row,1));
				txtSoTien.Value =(fg.GetDataDisplay(fg.Row,2)=="")?(0):(decimal.Parse(fg.GetData(fg.Row,2).ToString()));
				txtGhiChu.Text =fg.GetDataDisplay(fg.Row,3);
			}
			LockEdit(true);
		}

		private void cmdThem_Click(object sender, System.EventArgs e)
		{
			if (txtHoTen.Text=="") {return;}
			if (fg.Rows.Count ==1)
			{
				txtLanKQ.Text ="1";
			}
			else
			{
				txtLanKQ.Text =string.Format("{0}", int.Parse(fg.GetDataDisplay(fg.Row,0))+1);
			}
			LockEdit(false);
			txtNgayKQ.Value = GlobalModuls.Global.NgayLV;
			isAddNew = true;
			txtSoTien.Focus();
		}

		private void cmdGhi_Click(object sender, System.EventArgs e)
		{
			if (txtLanKQ.Text == ""){return;}
			if (txtNgayKQ.ValueIsDbNull)
			{
				MessageBox.Show("Chưa nhập ngày tạm thu, đề nghị kiểm tra lại!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
				txtNgayKQ.Focus();
				return;
			}
			if (txtSoTien.ValueIsDbNull)
			{
				MessageBox.Show("Chưa nhập số tiền tạm thu, đề nghị kiểm tra lại!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
				txtSoTien.Focus();
				return;
			}
			if (txtSoBL.Text.Trim()=="")
			{
				MessageBox.Show("Chưa nhập số biên lai tạm thu, đề nghị kiểm tra lại!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
				txtSoBL.Focus();
				return;
			}
			string SQLStr ="";
			if (isAddNew)
			{
				SQLStr = string.Format("INSERT INTO BENHNHAN_KYQUY (MaBenhNhan,LanKQ,NgayKQ,SoTien,GhiChu,SoBLKQ,LanVaoVien) VALUES ('{0}',{1},'{2:MM/dd/yyyy}',{3},'{4}','{5}',{6})",txtSoHSBA.Text, txtLanKQ.Text,txtNgayKQ.Value,txtSoTien.Value,txtGhiChu.Text,txtSoBL.Text.Replace("'","''"),txtLanVV.Text );
			}
			else
			{
				SQLStr = string.Format("UPDATE BENHNHAN_KYQUY SET NgayKQ='{0:MM/dd/yyyy}',SoTien={1},GhiChu='{2}',SoBLKQ='{3}' WHERE MaBenhNhan='{4}' AND LanVaoVien={6} AND LanKQ={5}",txtNgayKQ.Value,txtSoTien.Value,txtGhiChu.Text,txtSoBL.Text.Replace("'","''"),txtSoHSBA.Text, txtLanKQ.Text,txtLanVV.Text );
			}
			System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand(SQLStr,GlobalModuls.Global.ConnectSQL);
			try
			{
				SQLCmd.ExecuteNonQuery();
				if (isAddNew)
				{
					fg.AddItem(string.Format("{0}|{1:dd/MM/yyyy}|{2}|{3}|{4}",txtLanKQ.Text,txtNgayKQ.Value,txtSoBL.Text, txtSoTien.Value,txtGhiChu.Text));
				}
				else
				{
					fg[fg.Row,1]=string.Format("{0:dd/MM/yyyy}", txtNgayKQ.Value);
					fg[fg.Row,2]=txtSoBL.Text;
					fg[fg.Row,3]=txtSoTien.Value;
					fg[fg.Row,4]=txtGhiChu.Text;
				}
				TinhTien();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Có lỗi khi ghi dữ liệu\n" + ex.Message,"Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return;
			}
			finally
			{
				SQLCmd.Dispose();				
			}
			LockEdit(true);
		}

		private void cmdXoa_Click(object sender, System.EventArgs e)
		{
			if (txtLanKQ.Text =="")
			{
				MessageBox.Show("Chưa chọn bệnh nhân (hoặc lần tạm thu) để xóa, đề nghị chọn lại!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return;
			}
			if (MessageBox.Show("Bạn có chắc muốn xóa lần tạm thu này của bệnh nhân?","Xác nhận xóa",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.No) {return;}
			string SQLStr ="DELETE FROM BENHNHAN_KYQUY WHERE SoHSBA='" +txtSoHSBA.Text +"' AND lanKQ="+txtLanKQ.Text;
			System.Data.SqlClient.SqlCommand  SQLCmd = new System.Data.SqlClient.SqlCommand(SQLStr,GlobalModuls.Global.ConnectSQL);
			if (txtLanKQ.Text =="1")
			{
				SQLCmd.CommandText ="UPDATE BENHNHAN_KYQUY Set NgayKQ=null,Sotien=Null,GhiChu=null WHERE SoHSBA='" +txtSoHSBA.Text +"' AND lanKQ="+txtLanKQ.Text;
			}
			try
			{
				SQLCmd.ExecuteNonQuery();
				fg.RemoveItem(fg.Row);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Có lỗi khi xóa dữ liệu\n,"+ex.Message,"Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
			finally
			{
				SQLCmd.Dispose();
			}
		}
		private void TinhTien()
		{
			int i=0;
			TongKyQuy =0;
			for (i=1;i<fg.Rows.Count;i++)
			{
				TongKyQuy+=long.Parse(fg.GetData(i,3).ToString());
			}
			txtKyQuy.Text= string.Format("{0:#,###}",TongKyQuy);
			long ThuaThieu = TongKyQuy + TongTT - TongCP;
			if (ThuaThieu<0) {lblThuaThieu.Text = "Thiếu";} 
			else {lblThuaThieu.Text = "Thừa";}
			txtThuaThieu.Text = string.Format("{0:#,###}",Math.Abs(ThuaThieu));
		}

	}
}
