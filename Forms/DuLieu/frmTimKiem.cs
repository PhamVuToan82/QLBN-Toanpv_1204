using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Diagnostics;
namespace NamDinh_QLBN.Forms.DuLieu
{
	/// <summary>
	/// Summary description for frmTimKiem.
	/// </summary>
	public class frmTimKiem : System.Windows.Forms.Form
	{
		private C1.Win.C1FlexGrid.C1FlexGrid fgField;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblFName;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		internal C1.Win.C1List.C1Combo cmbDK;
        internal C1.Win.C1List.C1Combo cmbGT;
		private System.Windows.Forms.RadioButton rdbLogic;
		private System.Windows.Forms.RadioButton radioButton1;
		private C1.Win.C1FlexGrid.C1FlexGrid fg;		
		private C1.Win.C1FlexGrid.C1FlexGrid fgKQ;
		private System.Windows.Forms.Label lblKQ;	
		private System.Windows.Forms.SaveFileDialog DlgSaveFile;
		private System.Windows.Forms.Panel panChon;
		private DevExpress.XtraEditors.SimpleButton simpleButton5;
		private DevExpress.XtraEditors.SimpleButton simpleButton4;
		private DevExpress.XtraEditors.SimpleButton simpleButton3;
		private DevExpress.XtraEditors.SimpleButton simpleButton1;
		private DevExpress.XtraEditors.SimpleButton cmdTim;
		private DevExpress.XtraEditors.SimpleButton cmdExcel;
		private DevExpress.XtraEditors.SimpleButton cmdThoat;
		private System.Windows.Forms.Label label4;
		private DevExpress.XtraEditors.SimpleButton simpleButton2;
		private DevExpress.XtraEditors.SimpleButton simpleButton6;
		private DevExpress.XtraEditors.SimpleButton simpleButton7;
        private System.Windows.Forms.GroupBox groupBox1;
		private DevExpress.XtraEditors.SimpleButton cmdBrowse;
		private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ProgressBar prBar;
        private System.Windows.Forms.CheckBox chkBNChuaRV;
        private C1.Win.C1FlexGrid.C1FlexGrid fgChon;
        private CheckBox chkDaRV;
        private TextBox txtGT;
        private C1.Win.C1Input.C1DateEdit txtNgaySinh;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

        public frmTimKiem(string DK)
		{
			//
			// Required for Windows Form Designer support
			//			            
			InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            if (DK != "")
            {
                LoadCauHoi(DK);
            }					  
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTimKiem));
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
            this.fgField = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.label1 = new System.Windows.Forms.Label();
            this.lblFName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbDK = new C1.Win.C1List.C1Combo();
            this.cmbGT = new C1.Win.C1List.C1Combo();
            this.rdbLogic = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.fg = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.fgKQ = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.lblKQ = new System.Windows.Forms.Label();
            this.DlgSaveFile = new System.Windows.Forms.SaveFileDialog();
            this.panChon = new System.Windows.Forms.Panel();
            this.fgChon = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.label4 = new System.Windows.Forms.Label();
            this.simpleButton5 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkDaRV = new System.Windows.Forms.CheckBox();
            this.chkBNChuaRV = new System.Windows.Forms.CheckBox();
            this.cmdBrowse = new DevExpress.XtraEditors.SimpleButton();
            this.prBar = new System.Windows.Forms.ProgressBar();
            this.label5 = new System.Windows.Forms.Label();
            this.simpleButton7 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton6 = new DevExpress.XtraEditors.SimpleButton();
            this.cmdThoat = new DevExpress.XtraEditors.SimpleButton();
            this.cmdExcel = new DevExpress.XtraEditors.SimpleButton();
            this.cmdTim = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.txtGT = new System.Windows.Forms.TextBox();
            this.txtNgaySinh = new C1.Win.C1Input.C1DateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.fgField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbGT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fgKQ)).BeginInit();
            this.panChon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fgChon)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNgaySinh)).BeginInit();
            this.SuspendLayout();
            // 
            // fgField
            // 
            this.fgField.AllowEditing = false;
            this.fgField.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.fgField.ColumnInfo = "5,1,0,0,0,85,Columns:0{Width:30;Caption:\"STT\";}\t1{Width:102;Caption:\"Tên trường\";" +
                "}\t2{Caption:\"FieldName\";}\t3{Caption:\"FieldType\";}\t4{Width:164;Caption:\"Field in " +
                "Table name\";}\t";
            this.fgField.ExtendLastCol = true;
            this.fgField.Location = new System.Drawing.Point(3, 39);
            this.fgField.Name = "fgField";
            this.fgField.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox;
            this.fgField.Size = new System.Drawing.Size(261, 201);
            this.fgField.Styles = new C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("fgField.Styles"));
            this.fgField.TabIndex = 0;
            this.fgField.RowColChange += new System.EventHandler(this.fgField_RowColChange);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.Location = new System.Drawing.Point(3, 247);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tên trường";
            // 
            // lblFName
            // 
            this.lblFName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFName.BackColor = System.Drawing.Color.White;
            this.lblFName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFName.Location = new System.Drawing.Point(66, 243);
            this.lblFName.Name = "lblFName";
            this.lblFName.Size = new System.Drawing.Size(198, 20);
            this.lblFName.TabIndex = 2;
            this.lblFName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.Location = new System.Drawing.Point(3, 269);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Điều kiện";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.Location = new System.Drawing.Point(3, 290);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Giá trị";
            // 
            // cmbDK
            // 
            this.cmbDK.AddItemSeparator = ';';
            this.cmbDK.AllowRowSizing = C1.Win.C1List.RowSizingEnum.AllRows;
            this.cmbDK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbDK.AutoCompletion = true;
            this.cmbDK.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cmbDK.Caption = "";
            this.cmbDK.CaptionHeight = 17;
            this.cmbDK.CaptionStyle = style1;
            this.cmbDK.CaptionVisible = false;
            this.cmbDK.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cmbDK.ColumnCaptionHeight = 17;
            this.cmbDK.ColumnFooterHeight = 17;
            this.cmbDK.ColumnHeaders = false;
            this.cmbDK.ColumnWidth = 20;
            this.cmbDK.ContentHeight = 16;
            this.cmbDK.DataMode = C1.Win.C1List.DataModeEnum.AddItem;
            this.cmbDK.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cmbDK.DefColWidth = 20;
            this.cmbDK.DisplayMember = "ten";
            this.cmbDK.EditorBackColor = System.Drawing.Color.White;
            this.cmbDK.EditorFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDK.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbDK.EditorHeight = 16;
            this.cmbDK.EvenRowStyle = style2;
            this.cmbDK.ExtendRightColumn = true;
            this.cmbDK.FlatStyle = C1.Win.C1List.FlatModeEnum.Popup;
            this.cmbDK.FooterStyle = style3;
            this.cmbDK.GapHeight = 2;
            this.cmbDK.HeadingStyle = style4;
            this.cmbDK.HighLightRowStyle = style5;
            this.cmbDK.ItemHeight = 15;
            this.cmbDK.Location = new System.Drawing.Point(66, 267);
            this.cmbDK.MatchEntryTimeout = ((long)(2000));
            this.cmbDK.MaxDropDownItems = ((short)(5));
            this.cmbDK.MaxLength = 32767;
            this.cmbDK.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cmbDK.Name = "cmbDK";
            this.cmbDK.OddRowStyle = style6;
            this.cmbDK.PartialRightColumn = false;
            this.cmbDK.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.cmbDK.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.cmbDK.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cmbDK.SelectedStyle = style7;
            this.cmbDK.Size = new System.Drawing.Size(99, 20);
            this.cmbDK.Style = style8;
            this.cmbDK.TabIndex = 31;
            this.cmbDK.Text = "C1Combo2";
            this.cmbDK.PropBag = resources.GetString("cmbDK.PropBag");
            // 
            // cmbGT
            // 
            this.cmbGT.AddItemSeparator = ';';
            this.cmbGT.AllowRowSizing = C1.Win.C1List.RowSizingEnum.AllRows;
            this.cmbGT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbGT.AutoCompletion = true;
            this.cmbGT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cmbGT.Caption = "";
            this.cmbGT.CaptionHeight = 17;
            this.cmbGT.CaptionStyle = style9;
            this.cmbGT.CaptionVisible = false;
            this.cmbGT.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cmbGT.ColumnCaptionHeight = 17;
            this.cmbGT.ColumnFooterHeight = 17;
            this.cmbGT.ColumnHeaders = false;
            this.cmbGT.ColumnWidth = 20;
            this.cmbGT.ContentHeight = 16;
            this.cmbGT.DataMode = C1.Win.C1List.DataModeEnum.AddItem;
            this.cmbGT.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cmbGT.DefColWidth = 20;
            this.cmbGT.DisplayMember = "ten";
            this.cmbGT.EditorBackColor = System.Drawing.Color.White;
            this.cmbGT.EditorFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbGT.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbGT.EditorHeight = 16;
            this.cmbGT.EvenRowStyle = style10;
            this.cmbGT.ExtendRightColumn = true;
            this.cmbGT.FlatStyle = C1.Win.C1List.FlatModeEnum.Popup;
            this.cmbGT.FooterStyle = style11;
            this.cmbGT.GapHeight = 2;
            this.cmbGT.HeadingStyle = style12;
            this.cmbGT.HighLightRowStyle = style13;
            this.cmbGT.ItemHeight = 15;
            this.cmbGT.Location = new System.Drawing.Point(66, 288);
            this.cmbGT.MatchEntryTimeout = ((long)(2000));
            this.cmbGT.MaxDropDownItems = ((short)(5));
            this.cmbGT.MaxLength = 32767;
            this.cmbGT.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cmbGT.Name = "cmbGT";
            this.cmbGT.OddRowStyle = style14;
            this.cmbGT.PartialRightColumn = false;
            this.cmbGT.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.cmbGT.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.cmbGT.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cmbGT.SelectedStyle = style15;
            this.cmbGT.Size = new System.Drawing.Size(198, 20);
            this.cmbGT.Style = style16;
            this.cmbGT.TabIndex = 32;
            this.cmbGT.Text = "C1Combo2";
            this.cmbGT.PropBag = resources.GetString("cmbGT.PropBag");
            // 
            // rdbLogic
            // 
            this.rdbLogic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rdbLogic.Checked = true;
            this.rdbLogic.Location = new System.Drawing.Point(66, 315);
            this.rdbLogic.Name = "rdbLogic";
            this.rdbLogic.Size = new System.Drawing.Size(36, 18);
            this.rdbLogic.TabIndex = 35;
            this.rdbLogic.TabStop = true;
            this.rdbLogic.Text = "Và";
            // 
            // radioButton1
            // 
            this.radioButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radioButton1.Location = new System.Drawing.Point(105, 315);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(66, 18);
            this.radioButton1.TabIndex = 36;
            this.radioButton1.Text = "Hoặc";
            // 
            // fg
            // 
            this.fg.AllowDelete = true;
            this.fg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.fg.ColumnInfo = "3,0,0,0,0,85,Columns:0{Width:42;}\t1{Width:101;}\t2{Width:105;}\t";
            this.fg.Location = new System.Drawing.Point(3, 336);
            this.fg.Name = "fg";
            this.fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox;
            this.fg.Size = new System.Drawing.Size(261, 138);
            this.fg.Styles = new C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("fg.Styles"));
            this.fg.TabIndex = 38;
            this.fg.AfterDeleteRow += new C1.Win.C1FlexGrid.RowColEventHandler(this.fg_AfterDeleteRow);
            this.fg.BeforeEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.fg_BeforeEdit);
            // 
            // fgKQ
            // 
            this.fgKQ.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.fgKQ.AllowEditing = false;
            this.fgKQ.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.Both;
            this.fgKQ.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.fgKQ.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Light3D;
            this.fgKQ.ColumnInfo = resources.GetString("fgKQ.ColumnInfo");
            this.fgKQ.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid;
            this.fgKQ.HighLight = C1.Win.C1FlexGrid.HighLightEnum.WithFocus;
            this.fgKQ.Location = new System.Drawing.Point(267, 3);
            this.fgKQ.Name = "fgKQ";
            this.fgKQ.Rows.Count = 1;
            this.fgKQ.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
            this.fgKQ.ShowCursor = true;
            this.fgKQ.Size = new System.Drawing.Size(743, 447);
            this.fgKQ.Styles = new C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("fgKQ.Styles"));
            this.fgKQ.TabIndex = 40;
            this.fgKQ.DoubleClick += new System.EventHandler(this.fgKQ_DoubleClick);
            // 
            // lblKQ
            // 
            this.lblKQ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblKQ.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKQ.ForeColor = System.Drawing.Color.Navy;
            this.lblKQ.Location = new System.Drawing.Point(270, 483);
            this.lblKQ.Name = "lblKQ";
            this.lblKQ.Size = new System.Drawing.Size(386, 15);
            this.lblKQ.TabIndex = 41;
            // 
            // DlgSaveFile
            // 
            this.DlgSaveFile.DefaultExt = "xls";
            this.DlgSaveFile.Filter = "Excel file|*.xls";
            this.DlgSaveFile.Title = "Kết xuất danh sách";
            this.DlgSaveFile.FileOk += new System.ComponentModel.CancelEventHandler(this.DlgSaveFile_FileOk);
            // 
            // panChon
            // 
            this.panChon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.panChon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.panChon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panChon.Controls.Add(this.fgChon);
            this.panChon.Controls.Add(this.label4);
            this.panChon.Controls.Add(this.simpleButton5);
            this.panChon.Controls.Add(this.simpleButton4);
            this.panChon.Location = new System.Drawing.Point(267, 0);
            this.panChon.Name = "panChon";
            this.panChon.Size = new System.Drawing.Size(264, 507);
            this.panChon.TabIndex = 46;
            this.panChon.Visible = false;
            // 
            // fgChon
            // 
            this.fgChon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.fgChon.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Light3D;
            this.fgChon.ColumnInfo = resources.GetString("fgChon.ColumnInfo");
            this.fgChon.ExtendLastCol = true;
            this.fgChon.Location = new System.Drawing.Point(3, 32);
            this.fgChon.Name = "fgChon";
            this.fgChon.Size = new System.Drawing.Size(256, 444);
            this.fgChon.Styles = new C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("fgChon.Styles"));
            this.fgChon.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(4, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(255, 27);
            this.label4.TabIndex = 3;
            this.label4.Text = "Chọn tiêu chí hiển thị khi tìm kiếm";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // simpleButton5
            // 
            this.simpleButton5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.simpleButton5.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton5.Image")));
            this.simpleButton5.Location = new System.Drawing.Point(124, 479);
            this.simpleButton5.Name = "simpleButton5";
            this.simpleButton5.Size = new System.Drawing.Size(68, 24);
            this.simpleButton5.TabIndex = 2;
            this.simpleButton5.Text = "Chọn";
            this.simpleButton5.Click += new System.EventHandler(this.simpleButton5_Click);
            // 
            // simpleButton4
            // 
            this.simpleButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.simpleButton4.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton4.Image")));
            this.simpleButton4.Location = new System.Drawing.Point(192, 479);
            this.simpleButton4.Name = "simpleButton4";
            this.simpleButton4.Size = new System.Drawing.Size(68, 24);
            this.simpleButton4.TabIndex = 1;
            this.simpleButton4.Text = "Đóng";
            this.simpleButton4.Click += new System.EventHandler(this.simpleButton4_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.simpleButton2.Location = new System.Drawing.Point(6, 309);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(57, 24);
            this.simpleButton2.TabIndex = 51;
            this.simpleButton2.Text = "(...)";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkDaRV);
            this.groupBox1.Controls.Add(this.chkBNChuaRV);
            this.groupBox1.Location = new System.Drawing.Point(3, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(261, 36);
            this.groupBox1.TabIndex = 54;
            this.groupBox1.TabStop = false;
            // 
            // chkDaRV
            // 
            this.chkDaRV.Location = new System.Drawing.Point(136, 12);
            this.chkDaRV.Name = "chkDaRV";
            this.chkDaRV.Size = new System.Drawing.Size(106, 18);
            this.chkDaRV.TabIndex = 59;
            this.chkDaRV.Text = "BN đã ra viện";
            // 
            // chkBNChuaRV
            // 
            this.chkBNChuaRV.Checked = true;
            this.chkBNChuaRV.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBNChuaRV.Location = new System.Drawing.Point(9, 12);
            this.chkBNChuaRV.Name = "chkBNChuaRV";
            this.chkBNChuaRV.Size = new System.Drawing.Size(106, 18);
            this.chkBNChuaRV.TabIndex = 58;
            this.chkBNChuaRV.Text = "BN chưa ra viện";
            // 
            // cmdBrowse
            // 
            this.cmdBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdBrowse.Location = new System.Drawing.Point(240, 243);
            this.cmdBrowse.Name = "cmdBrowse";
            this.cmdBrowse.Size = new System.Drawing.Size(24, 21);
            this.cmdBrowse.TabIndex = 55;
            this.cmdBrowse.Text = "...";
            this.cmdBrowse.Visible = false;
            this.cmdBrowse.Click += new System.EventHandler(this.cmdBrowse_Click);
            // 
            // prBar
            // 
            this.prBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.prBar.Location = new System.Drawing.Point(267, 456);
            this.prBar.Name = "prBar";
            this.prBar.Size = new System.Drawing.Size(740, 18);
            this.prBar.TabIndex = 57;
            this.prBar.Visible = false;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label5.Image = ((System.Drawing.Image)(resources.GetObject("label5.Image")));
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.Location = new System.Drawing.Point(267, 453);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(767, 24);
            this.label5.TabIndex = 56;
            this.label5.Text = "         Kích đúp chuột để chọn bệnh nhân, kích vào tiêu đề cột để sắp xếp kết qu" +
                "ả tìm kiếm theo cột.";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // simpleButton7
            // 
            this.simpleButton7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton7.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton7.Image")));
            this.simpleButton7.Location = new System.Drawing.Point(659, 477);
            this.simpleButton7.Name = "simpleButton7";
            this.simpleButton7.Size = new System.Drawing.Size(90, 28);
            this.simpleButton7.TabIndex = 53;
            this.simpleButton7.Text = "Mở câu hỏi";
            this.simpleButton7.Click += new System.EventHandler(this.simpleButton7_Click);
            // 
            // simpleButton6
            // 
            this.simpleButton6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton6.Enabled = false;
            this.simpleButton6.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton6.Image")));
            this.simpleButton6.Location = new System.Drawing.Point(749, 477);
            this.simpleButton6.Name = "simpleButton6";
            this.simpleButton6.Size = new System.Drawing.Size(90, 28);
            this.simpleButton6.TabIndex = 52;
            this.simpleButton6.Text = "Ghi câu hỏi";
            this.simpleButton6.Click += new System.EventHandler(this.simpleButton6_Click);
            // 
            // cmdThoat
            // 
            this.cmdThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdThoat.Image = ((System.Drawing.Image)(resources.GetObject("cmdThoat.Image")));
            this.cmdThoat.Location = new System.Drawing.Point(938, 477);
            this.cmdThoat.Name = "cmdThoat";
            this.cmdThoat.Size = new System.Drawing.Size(72, 28);
            this.cmdThoat.TabIndex = 50;
            this.cmdThoat.Text = "Thoát";
            this.cmdThoat.Click += new System.EventHandler(this.cmdThoat_Click);
            // 
            // cmdExcel
            // 
            this.cmdExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdExcel.Image = ((System.Drawing.Image)(resources.GetObject("cmdExcel.Image")));
            this.cmdExcel.Location = new System.Drawing.Point(845, 477);
            this.cmdExcel.Name = "cmdExcel";
            this.cmdExcel.Size = new System.Drawing.Size(90, 28);
            this.cmdExcel.TabIndex = 49;
            this.cmdExcel.Text = "==> Excel";
            this.cmdExcel.Click += new System.EventHandler(this.cmdExcel_Click);
            // 
            // cmdTim
            // 
            this.cmdTim.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdTim.Image = ((System.Drawing.Image)(resources.GetObject("cmdTim.Image")));
            this.cmdTim.Location = new System.Drawing.Point(180, 477);
            this.cmdTim.Name = "cmdTim";
            this.cmdTim.Size = new System.Drawing.Size(81, 28);
            this.cmdTim.TabIndex = 48;
            this.cmdTim.Text = "&Tìm kiếm";
            this.cmdTim.Click += new System.EventHandler(this.cmdTim_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.simpleButton1.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(174, 309);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(90, 24);
            this.simpleButton1.TabIndex = 47;
            this.simpleButton1.Text = "Thêm Đ&K";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // simpleButton3
            // 
            this.simpleButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.simpleButton3.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton3.Image")));
            this.simpleButton3.Location = new System.Drawing.Point(6, 477);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(156, 28);
            this.simpleButton3.TabIndex = 45;
            this.simpleButton3.Text = "Chọn tiêu chí hiển thị";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // txtGT
            // 
            this.txtGT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtGT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGT.Location = new System.Drawing.Point(66, 288);
            this.txtGT.Name = "txtGT";
            this.txtGT.Size = new System.Drawing.Size(199, 20);
            this.txtGT.TabIndex = 58;
            // 
            // txtNgaySinh
            // 
            this.txtNgaySinh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtNgaySinh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNgaySinh.Culture = 1066;
            this.txtNgaySinh.CustomFormat = "dd/MM/yyyy";
            this.txtNgaySinh.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
            this.txtNgaySinh.Location = new System.Drawing.Point(66, 289);
            this.txtNgaySinh.Name = "txtNgaySinh";
            this.txtNgaySinh.Size = new System.Drawing.Size(125, 18);
            this.txtNgaySinh.TabIndex = 123;
            this.txtNgaySinh.Tag = null;
            this.txtNgaySinh.Visible = false;
            // 
            // frmTimKiem
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1011, 507);
            this.Controls.Add(this.txtNgaySinh);
            this.Controls.Add(this.panChon);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmdBrowse);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.simpleButton7);
            this.Controls.Add(this.simpleButton6);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.cmdThoat);
            this.Controls.Add(this.cmdExcel);
            this.Controls.Add(this.cmdTim);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.simpleButton3);
            this.Controls.Add(this.lblKQ);
            this.Controls.Add(this.fgKQ);
            this.Controls.Add(this.fgField);
            this.Controls.Add(this.fg);
            this.Controls.Add(this.rdbLogic);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.cmbGT);
            this.Controls.Add(this.cmbDK);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblFName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.prBar);
            this.Controls.Add(this.txtGT);
            this.Name = "frmTimKiem";
            this.Text = "Tra cứu dữ liệu";
            this.Resize += new System.EventHandler(this.frmTimKiem_Resize);
            this.Load += new System.EventHandler(this.frmTimKiem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fgField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbGT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fgKQ)).EndInit();
            this.panChon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fgChon)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtNgaySinh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmTimKiem_Load(object sender, System.EventArgs e)
		{
            fg.ClipSeparators = "|;";
            fg.Rows.Count = 1;
            fg.ExtendLastCol = true;

			#region Đưa các trường vào grid các trường hiển thị kết quả tìm kiếm
			fgChon.Rows.Count = 1;
			fgChon.ClipSeparators =";|";
			fgChon.AddItem("1;Tên bệnh nhân;BENHNHAN.HoTen");			
			fgChon.AddItem("1;Năm sinh;BENHNHAN.NamSinh");
			fgChon.AddItem("1;Số HSBA;BENHNHAN_CHITIET.SoHSBA");
            fgChon.AddItem("1;Đối tượng;TenDT; LEFT JOIN DMDOITUONGBN ON ViewDOITUONGHIENTAI.DoiTuong=MaDT");
            fgChon.AddItem("1;Ngày vào viện;BENHNHAN_CHITIET.NgayVaoVien");
            fgChon.AddItem("1;Đã ra viện;BENHNHAN_CHITIET.DaRaVien");
			
			#endregion
		
			LoadFields();
			
			fgField.Cols[2].Visible = false;
			fgField.Cols[3].Visible = false;
            fgField.Cols[4].Visible = false;
			fg.Cols[2].Visible = false;
			fg.Cols[0].ComboList = "|AND|OR";
			fgChon.Cols[2].Visible = false;
			fgChon.Cols[3].Visible = false;
			
			
			//fgKQ.Cols[5].Format="dd/MM/yyyy";

			
			//txtNgaySinh.Left = cmbGT.Left;
			//txtNgaySinh.Top = cmbGT.Top;
			//txtGT.Left = txtNgaySinh.Left; 
			//txtGT.Top = txtNgaySinh.Top;
			//cmdBrowse.Top = txtGT.Top;
			//cmdBrowse.Left = fgField.Left + fgField.Width - cmdBrowse.Width;
			
			txtNgaySinh.Visible = false;
			cmbGT.Visible = false;
		}

		private void fgField_RowColChange(object sender, System.EventArgs e)
		{
			if (fgField.Row < 1) {return;}
			lblFName.Text = fgField.GetDataDisplay(fgField.Row,1);
			lblFName.Tag  = fgField.GetDataDisplay(fgField.Row,2);
			cmbDK.ClearItems();
			cmbDK.AddItem("=;=");
			cmdBrowse.Visible = false;
			
			//txtGT.Width = 198;
			txtGT.ReadOnly = false;
            txtGT.Visible = false;
			txtNgaySinh.Visible =false;
			cmbGT.Visible = false;
			txtGT.Tag = fgField.GetDataDisplay(fgField.Row,3);
			switch (fgField.GetDataDisplay(fgField.Row,3))
			{				
				case "T":
					cmbDK.AddItem("LIKE;Có cụm từ");
					txtGT.Visible = true;					
					break;
				case "D":					
					cmbDK.AddItem("<;<");
					cmbDK.AddItem("<=;<=");
					cmbDK.AddItem(">;>");
					cmbDK.AddItem(">=;>=");
					txtNgaySinh.Visible = true;
					break;				
				case "N":					
					cmbDK.AddItem("<;<");
					cmbDK.AddItem("<=;<=");
					cmbDK.AddItem(">;>");
					cmbDK.AddItem(">=;>=");
					txtGT.Visible = true;
					break;
				case "B":
					cmbDK.AddItem("<>;<>");
					cmbGT.ClearItems();
					cmbGT.AddItem("1;Đúng");
					cmbGT.AddItem("0;Sai");
					cmbGT.Visible = true;
					break;
				case "L":
					cmbDK.AddItem("<>;<>");
					cmbDK.AddItem("LIKE;Thuộc");
					//txtGT.Width = 174;
					txtGT.ReadOnly = true;
					txtGT.Visible =true;
					cmdBrowse.Visible = true;
					break;
				default:
					cmbDK.AddItem("<>;<>");
					LoadDM(fgField.GetDataDisplay(fgField.Row,3));
					cmbGT.Visible = true;
					break;				
			}
		}
		private void LoadDM(string SQLstr)
		{
			if (SQLstr == "") {return;}
			System.Data.SqlClient.SqlCommand  cmd = new System.Data.SqlClient.SqlCommand();
			cmbGT.ClearItems();
			cmd.CommandText = SQLstr;
            cmd.Connection = GlobalModuls.Global.ConnectSQL;
			System.Data.SqlClient.SqlDataReader dr;
			dr = cmd.ExecuteReader();
			while (dr.Read())
			{
				cmbGT.AddItem(dr.GetValue(0) + ";" + dr.GetValue(1));
			}
			dr.Close();
		}		
		
		private void fg_AfterDeleteRow(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
		{
			if (fg.Rows.Count>1)
			{
				fg[1,0]="";				
			}
			simpleButton6.Enabled = (fg.Rows.Count>1);
		}


		private void DlgSaveFile_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
		{
			string fname;			
			fname=DlgSaveFile.FileName;
			if (fname.Trim()=="") {return;}					
			fgKQ.SaveExcel(fname,"danh sach",C1.Win.C1FlexGrid.FileFlags.IncludeFixedCells);
			MessageBox.Show(string.Format("Đã kết xuất dữ liệu sang file Excel \n{0}",fname),"Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);			
		}

		private void button4_Click(object sender, System.EventArgs e)
		{
			string ND="";			
			string DKAo ="";
			int i =0;
			for (i=1;i<fg.Rows.Count;i++)
			{
				ND += fg.GetDataDisplay(i,0) + " " + fg.GetDataDisplay(i,1) + "\n";
				DKAo += "{" + fg.GetDataDisplay(i,0) + "|" + fg.GetDataDisplay(i,1) + "|" + fg.GetDataDisplay(i,2) + "}";
			}			
			NamDinh_QLBN.Forms.DuLieu.frmGhiCauHoi fr = new NamDinh_QLBN.Forms.DuLieu.frmGhiCauHoi(DKAo,ND);			
			fr.Show();
		}
		private void LoadCauHoi(string DK)
		{
			string DK1 = "";
			string DK2 = DK;
			fg.Rows.Count = 1;
			while (DK2.Length >0)
			{
				DK1 = DK2.Substring(1,DK2.IndexOf("}")-1);
				DK2 = DK2.Substring(DK2.IndexOf("}")+1);				
				fg.AddItem(DK1);
			}
		}

		private void simpleButton1_Click(object sender, System.EventArgs e)
		{
			string DKThat = "";
			string DKAo = "";
			DKThat = lblFName.Text + " " + cmbDK.Text;
            DKAo = lblFName.Tag + " " + GlobalModuls.Global.GetCode(cmbDK);
			if (txtGT.Visible)
			{
				DKThat += " " + txtGT.Text;
                if (GlobalModuls.Global.GetCode(cmbDK) == "LIKE")
				{
					if (txtGT.ReadOnly)
					{
					{DKAo += "'" + txtGT.Tag + "%'";}
					}
					else
					{	
						DKAo += " N'%" + txtGT.Text +"%'";
					}
				}
				else
				{
					if (txtGT.ReadOnly)
					{
						{DKAo += "'" + txtGT.Tag + "'";}
					}
					else
					{
						if (txtGT.Tag.ToString() == "N")
						{DKAo += " " + txtGT.Text;}
						else
						{DKAo += " N'" + txtGT.Text +"'";}
					}
				}
				
			}
			else if (txtNgaySinh.Visible)
			{
				DKThat += txtNgaySinh.Text;
				if (txtNgaySinh.ValueIsDbNull) {return;}
                if (GlobalModuls.Global.GetCode(cmbDK).Trim() == "=")
                {
                    DKAo = string.Format("DateDiff(dd,{0},'{1:MM/dd/yyyy}')=0", lblFName.Tag.ToString(), txtNgaySinh.Value);
                }
                else
                {
                    DKAo += string.Format("'{0:MM/dd/yyyy}'", txtNgaySinh.Value);
                }
			}
			else
			{
				DKThat += cmbGT.Text;
				if (lblFName.Tag.ToString() == "GioiTinh")
				{DKAo += GlobalModuls.Global.GetCode(cmbGT);}
				else {DKAo += " '" + GlobalModuls.Global.GetCode(cmbGT) + "'";;}
				
			}
			if (fg.Rows.Count>1)
			{
				if (rdbLogic.Checked)
				{	fg.AddItem("AND |" + DKThat + "| " + DKAo + " ");}
				else
				{	fg.AddItem("OR |" + DKThat + "| " + DKAo + " ");}
			}
			else
			{
				fg.AddItem("|" + DKThat + " | " + DKAo + " ");
			}
			simpleButton6.Enabled = (fg.Rows.Count>1);
		}

		private void cmdTim_Click(object sender, System.EventArgs e)
		{
			int i = 0;			
			string DKTim="";
            string tableName = " ((BENHNHAN INNER JOIN BENHNHAN_CHITIET ON BENHNHAN.MaBenhNhan = BENHNHAN_CHITIET.MaBenhNhan) "
                                + " INNER JOIN ViewKHOAHIENTAI ON BENHNHAN_CHITIET.MaBenhNhan=ViewKhoaHIENTAI.MaBenhNhan AND BENHNHAN_CHITIET.LanVaoVien=ViewKhoaHIENTAI.LanVaoVien)"
                                + " INNER JOIN ViewDOITUONGHIENTAI ON BENHNHAN_CHITIET.MaBenhNhan=ViewDOITUONGHIENTAI.MaBenhNhan AND BENHNHAN_CHITIET.LanVaoVien=ViewDOITUONGHIENTAI.LanVaoVien";;

			for (i=1;i<fg.Rows.Count;i++)
			{
				DKTim += fg.GetDataDisplay(i,0) + fg.GetDataDisplay(i,2);
			}
            if (chkBNChuaRV.Checked)
            {
                if (!chkDaRV.Checked) { DKTim += " AND BENHNHAN_CHITIET.DaRaVien=0 "; }
            }
            else
            {
                if (chkDaRV.Checked) { DKTim += " AND BENHNHAN_CHITIET.DaRaVien=1 "; }
            }

			string strSQL ="SELECT BENHNHAN.MaBenhNhan As [Mã BN],BENHNHAN_CHITIET.LanVaoVien as [Lần VV]";

			for (i= 1; i<fgChon.Rows.Count;i++)
			{
				if (fgChon[i,0].ToString() !="False" ) 
				{
					strSQL += string.Format(",{0} AS [{1}]", fgChon[i,2],fgChon[i,1]);
					if (fgChon.GetDataDisplay(i,3)!="")
					{
						tableName = "(" + tableName + " " + fgChon.GetDataDisplay(i,3) + ")";
					}					
				}
			}			
			
			strSQL = strSQL + " FROM " + tableName;
            DKTim += " And BENHNHAN_CHITIET.TrangThai<3 and viewKhoaHienTai.MaKhoa in " + GlobalModuls.Global.glbKhoa_CapNhat;
			if (DKTim.Length>0)
			{			
			    strSQL += " WHERE " + DKTim;			
			}
			
			try
			{
				System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(strSQL,GlobalModuls.Global.ConnectSQL);			
				System.Data.DataSet ds = new System.Data.DataSet();			
				da.Fill(ds);
				
				fgKQ.DataSource = ds.Tables[0];	
				fgKQ.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.FixedOnly;
				fgKQ.Styles.Fixed.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
				fgKQ.Cols[1].Visible=false;
				fgKQ.Cols[2].Visible=false;
				lblKQ.Text =string.Format("Tìm thấy {0} bản ghi",ds.Tables[0].Rows.Count);
				for (i=1;i<fgKQ.Cols.Count;i++)
				{
					if (fgKQ[0,i].ToString().IndexOf("gày",0)>0) {fgKQ.Cols[i].Format ="dd/MM/yyyy HH:mm";}
                    if (fgKQ[0, i].ToString().IndexOf("ã ra viện", 0) > 0) 
                    { 
                        fgKQ.Cols[i].DataType = typeof(bool); 
                    }
				}
				ds.Dispose();
				da.Dispose();
				fgKQ.Rows.Fixed = 1;				
            }
			catch (Exception ex)
			{
				MessageBox.Show("Có lỗi khi thực hiện tìm kiếm! Kiểm tra lại điều kiện tìm kiếm!\n"+ex.Message,"Lỗi",MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void cmdExcel_Click(object sender, System.EventArgs e)
		{
			DlgSaveFile.Filter="File dữ liệu Excel|*.XLS";
			DlgSaveFile.OverwritePrompt=false;
			DlgSaveFile.Title="Kết xuất dữ liệu ra Excel";
			DlgSaveFile.FileName="";
			DlgSaveFile.ShowDialog(this);
//			int i = 0;
//			int j = 0;
//			GlobalModules.Global.wait("Đang thực hiện, xin chờ trong giây lát...");			
//			Excel.Application ExcelApp = new Excel.ApplicationClass();
//			ExcelApp.Visible = false;
//			prBar.Visible = true;
//			prBar.Maximum = fgKQ.Rows.Count * (fgKQ.Cols.Count-3) +2;			
//			prBar.Value =1;
//			ExcelApp.Application.Workbooks.Add(true);
//			for (i=0;i<fgKQ.Rows.Count;i++)
//			{
//				for (j=3;j<fgKQ.Cols.Count;j++)
//				{
//					if (fgKQ.GetDataDisplay(i,j).IndexOf("ngày") !=0)
//					{
//						ExcelApp.Cells[i+1,j-2] = "'" + fgKQ.GetDataDisplay(i,j);
//					}
//					else
//					{
//						ExcelApp.Cells[i+1,j-2] = fgKQ.GetDataDisplay(i,j);
//					}					
//					prBar.Value += 1;
//				}
//			}			
//			GlobalModules.Global.nowait();
//			prBar.Visible = false;
//			ExcelApp.Visible = true;
//			
//			ExcelApp = null;
//			Process[] pProcess; 
//			pProcess = System.Diagnostics.Process.GetProcessesByName("Excel");
//			pProcess[0].Kill();
		}

		private void cmdThoat_Click(object sender, System.EventArgs e)
		{
			this.Dispose();
		}

		private void simpleButton3_Click(object sender, System.EventArgs e)
		{
			panChon.Visible= true;
		}

		private void simpleButton4_Click(object sender, System.EventArgs e)
		{
			panChon.Visible = false;
		}

		private void simpleButton5_Click(object sender, System.EventArgs e)
		{
			cmdTim_Click(null,null);
			panChon.Visible = false;
		}

		private void simpleButton2_Click(object sender, System.EventArgs e)
		{
			if (fg.Selection.TopRow < 1) {return;}
			string DKAo="";
			string DKThat="";
			int i=0;

			fg[fg.Selection.TopRow,1]= " (" + fg[fg.Selection.TopRow,1].ToString();
			fg[fg.Selection.TopRow,2] = " (" +fg[fg.Selection.TopRow,2].ToString();
			fg[fg.Selection.BottomRow,1] = fg[fg.Selection.BottomRow,1].ToString() + " )";			
			fg[fg.Selection.BottomRow,2] =fg[fg.Selection.BottomRow,2].ToString() + " )";
			DKAo = fg[fg.Selection.TopRow,1].ToString();
			DKThat = fg[fg.Selection.TopRow,2].ToString();
			for (i=fg.Selection.TopRow+1;i<=fg.Selection.BottomRow;i++)
			{
				DKThat = DKThat + " " + fg[i,0].ToString() + " " + fg[i,2].ToString();
				DKAo = DKAo + " " + fg[i,0].ToString() + " " + fg[i,1].ToString();
			}
			for (i=fg.Selection.TopRow+1;i<=fg.Selection.BottomRow;i++)
			{
				fg.RemoveItem(i);
			}
			fg[fg.Selection.TopRow,1]= DKAo;
			fg[fg.Selection.TopRow,2] = DKThat;
		}

		private void fg_BeforeEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
		{
			if ((e.Col != 0) || (e.Row < 2)) 
			{
				e.Cancel = true;
				return;
			}
		}

		private void frmTimKiem_Resize(object sender, System.EventArgs e)
		{
			//txtNgaySinh.Left = cmbGT.Left;
			//txtNgaySinh.Top = cmbGT.Top;
			//txtGT.Left = txtNgaySinh.Left; 
			//txtGT.Top = txtNgaySinh.Top;
		}

		private void simpleButton6_Click(object sender, System.EventArgs e)
		{
			string ND="";			
			string DKAo ="";
			int i =0;
			for (i=1;i<fg.Rows.Count;i++)
			{
				ND += fg.GetDataDisplay(i,0) + " " + fg.GetDataDisplay(i,1) + "\n";
				DKAo += "{" + fg.GetDataDisplay(i,0) + "|" + fg.GetDataDisplay(i,1) + "|" + fg.GetDataDisplay(i,2) + "}";
			}
            NamDinh_QLBN.Forms.DuLieu.frmGhiCauHoi fr = new NamDinh_QLBN.Forms.DuLieu.frmGhiCauHoi(DKAo, ND);
			fr.Show();
		}

		private void simpleButton7_Click(object sender, System.EventArgs e)
		{
			NamDinh_QLBN.Forms.DuLieu.frmLoadCauHoi fr = new frmLoadCauHoi();
			fr.ShowDialog(this);
			if (fr.DK_Loaded != "")
			{				
				LoadCauHoi(fr.DK_Loaded);
			}
		}

		private void txtGT_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			//if ((txtGT.Tag.ToString()=="N") && (e.KeyChar)){return;}
		}
		private void LoadFields() //1: bảng Dự án; 2: Bảng doanh nghiệp
		{
			
			#region Đưa các trường vào grid các trường tìm kiếm
			fgField.Rows.Count = 1;
			fgField.ClipSeparators =";|";
            fgField.AddItem("0;Mã bệnh nhân;BENHNHAN.MaBenhNhan;T");
			fgField.AddItem("1;Tên bệnh nhân;BENHNHAN.HoTen;T");
			fgField.AddItem("2;Số HSBA;BENHNHAN_CHITIET.SoHSBA;T");			
			fgField.AddItem("3;Đối tượng;ViewDOITUONGHIENTAI.DoiTuong;SELECT MaDT,TenDT FROM DMDOITUONGBN ORDER BY MaDT");
            fgField.AddItem("4;Ngày vào viện;BENHNHAN_CHITIET.NgayVaoVien;D");
            fgField.AddItem("5;Khoa đang điều trị;ViewKHOAHIENTAI.MaKhoa;SELECT MaKhoa,TenKhoa FROM DMKHOAPHONG ORDER BY MaKhoa; INNER JOIN ViewKHOAHIENTAI ON BENHNHAN_CHITIET.MaBenhNhan=ViewKhoaHIENTAI.MaBenhNhan AND BENHNHAN_CHITIET.LanVaoVien=ViewKhoaHIENTAI.LanVaoVien");

			#endregion
			fgField.Row = 0;
			fgField.Row = 1;
		}

		private void fgKQ_DoubleClick(object sender, System.EventArgs e)
		{
			if (fgKQ.Row<1) {return;}			
			
			try
			{
                string MaBenhNhan = fgKQ[fgKQ.Row, 1].ToString();
                string LanVaoVien = fgKQ[fgKQ.Row, 2].ToString();
                NamDinh_QLBN.Forms.DuLieu.frmBenhNhanNoiTru fr = new frmBenhNhanNoiTru(MaBenhNhan, LanVaoVien);
                fr.MdiParent = this.MdiParent;
                fr.Show();
			}
			catch
			{
				MessageBox.Show("Lỗi, không truy cập được dữ liệu bệnh nhân");
			}
		}

		private void cmdBrowse_Click(object sender, System.EventArgs e)
		{

        }
	}

}
