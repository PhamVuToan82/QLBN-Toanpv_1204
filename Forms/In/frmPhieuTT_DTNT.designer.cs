namespace NamDinh_QLBN.Forms.In
{
    partial class frmPhieuTT_DTNT
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPhieuTT_DTNT));
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
            this.txtTNgay = new C1.Win.C1Input.C1DateEdit();
            this.rdDaRV = new System.Windows.Forms.RadioButton();
            this.rdChuaRV = new System.Windows.Forms.RadioButton();
            this.fgDanhSach = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.lblListTitle = new System.Windows.Forms.Label();
            this.cmbKhoa = new C1.Win.C1List.C1Combo();
            this.label16 = new System.Windows.Forms.Label();
            this.arvMain = new DataDynamics.ActiveReports.Viewer.Viewer();
            this.rdChuyenKhoa = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDNgay = new C1.Win.C1Input.C1DateEdit();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.fgDoiTuong = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.cmdTongHop = new System.Windows.Forms.Button();
            this.cmbLanIn = new C1.Win.C1List.C1Combo();
            this.label10 = new System.Windows.Forms.Label();
            this.raTatCa = new System.Windows.Forms.RadioButton();
            this.raChiPhiChuaThu = new System.Windows.Forms.RadioButton();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtTNgay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fgDanhSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKhoa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDNgay)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fgDoiTuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLanIn)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTNgay
            // 
            this.txtTNgay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTNgay.Culture = 1066;
            this.txtTNgay.CustomFormat = "dd/MM/yyyy";
            this.txtTNgay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTNgay.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
            this.txtTNgay.Location = new System.Drawing.Point(40, 63);
            this.txtTNgay.Name = "txtTNgay";
            this.txtTNgay.Size = new System.Drawing.Size(110, 20);
            this.txtTNgay.TabIndex = 129;
            this.txtTNgay.Tag = null;
            this.txtTNgay.ValueChanged += new System.EventHandler(this.txtDKNgayRV_ValueChanged);
            this.txtTNgay.TextChanged += new System.EventHandler(this.txtTNgay_TextChanged);
            // 
            // rdDaRV
            // 
            this.rdDaRV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdDaRV.Location = new System.Drawing.Point(225, 43);
            this.rdDaRV.Name = "rdDaRV";
            this.rdDaRV.Size = new System.Drawing.Size(91, 18);
            this.rdDaRV.TabIndex = 128;
            this.rdDaRV.Text = "Đã ra viện ";
            this.rdDaRV.CheckedChanged += new System.EventHandler(this.rdDaRV_CheckedChanged);
            // 
            // rdChuaRV
            // 
            this.rdChuaRV.Checked = true;
            this.rdChuaRV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdChuaRV.Location = new System.Drawing.Point(3, 42);
            this.rdChuaRV.Name = "rdChuaRV";
            this.rdChuaRV.Size = new System.Drawing.Size(105, 18);
            this.rdChuaRV.TabIndex = 127;
            this.rdChuaRV.TabStop = true;
            this.rdChuaRV.Text = "Đang điều trị";
            this.rdChuaRV.CheckedChanged += new System.EventHandler(this.rdChuaRV_CheckedChanged);
            // 
            // fgDanhSach
            // 
            this.fgDanhSach.AllowDelete = true;
            this.fgDanhSach.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.fgDanhSach.AllowEditing = false;
            this.fgDanhSach.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.fgDanhSach.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Light3D;
            this.fgDanhSach.ColumnInfo = resources.GetString("fgDanhSach.ColumnInfo");
            this.fgDanhSach.ExtendLastCol = true;
            this.fgDanhSach.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid;
            this.fgDanhSach.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fgDanhSach.Location = new System.Drawing.Point(0, 85);
            this.fgDanhSach.Name = "fgDanhSach";
            this.fgDanhSach.Rows.Count = 1;
            this.fgDanhSach.Rows.MinSize = 20;
            this.fgDanhSach.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox;
            this.fgDanhSach.ShowCursor = true;
            this.fgDanhSach.Size = new System.Drawing.Size(344, 645);
            this.fgDanhSach.Styles = new C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("fgDanhSach.Styles"));
            this.fgDanhSach.TabIndex = 124;
            this.fgDanhSach.AfterDragColumn += new C1.Win.C1FlexGrid.DragRowColEventHandler(this.fgDanhSach_AfterDragColumn);
            this.fgDanhSach.AfterRowColChange += new C1.Win.C1FlexGrid.RangeEventHandler(this.fgDanhSach_AfterRowColChange);
            // 
            // lblListTitle
            // 
            this.lblListTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblListTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListTitle.Location = new System.Drawing.Point(0, 23);
            this.lblListTitle.Name = "lblListTitle";
            this.lblListTitle.Size = new System.Drawing.Size(344, 21);
            this.lblListTitle.TabIndex = 126;
            this.lblListTitle.Text = "DANH SÁCH BỆNH NHÂN";
            this.lblListTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.cmbKhoa.Location = new System.Drawing.Point(78, 2);
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
            this.cmbKhoa.Size = new System.Drawing.Size(266, 20);
            this.cmbKhoa.Style = style8;
            this.cmbKhoa.TabIndex = 123;
            this.cmbKhoa.TextChanged += new System.EventHandler(this.cmbKhoa_TextChanged);
            this.cmbKhoa.PropBag = resources.GetString("cmbKhoa.PropBag");
            // 
            // label16
            // 
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label16.Location = new System.Drawing.Point(0, 5);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(75, 17);
            this.label16.TabIndex = 125;
            this.label16.Text = "Khoa điều trị";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // arvMain
            // 
            this.arvMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.arvMain.BackColor = System.Drawing.SystemColors.Control;
            this.arvMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.arvMain.Document = new DataDynamics.ActiveReports.Document.Document("");
            this.arvMain.Location = new System.Drawing.Point(347, 32);
            this.arvMain.Name = "arvMain";
            this.arvMain.ReportViewer.BackColor = System.Drawing.SystemColors.Control;
            this.arvMain.ReportViewer.CurrentPage = 0;
            this.arvMain.ReportViewer.MultiplePageCols = 3;
            this.arvMain.ReportViewer.MultiplePageRows = 2;
            this.arvMain.ReportViewer.ViewType = DataDynamics.ActiveReports.Viewer.ViewType.Normal;
            this.arvMain.Size = new System.Drawing.Size(849, 698);
            this.arvMain.TabIndex = 130;
            this.arvMain.TableOfContents.Text = "Contents";
            this.arvMain.TableOfContents.Width = 200;
            this.arvMain.TabTitleLength = 35;
            this.arvMain.Toolbar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.arvMain.ToolClick += new DataDynamics.ActiveReports.Toolbar.ToolClickEventHandler(this.arvMain_ToolClick);
            // 
            // rdChuyenKhoa
            // 
            this.rdChuyenKhoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdChuyenKhoa.Location = new System.Drawing.Point(102, 42);
            this.rdChuyenKhoa.Name = "rdChuyenKhoa";
            this.rdChuyenKhoa.Size = new System.Drawing.Size(104, 18);
            this.rdChuyenKhoa.TabIndex = 132;
            this.rdChuyenKhoa.Text = "Chuyển khoa";
            this.rdChuyenKhoa.CheckedChanged += new System.EventHandler(this.rdChuyenKhoa_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 16);
            this.label1.TabIndex = 133;
            this.label1.Text = "Từ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(157, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 16);
            this.label2.TabIndex = 135;
            this.label2.Text = "đến";
            // 
            // txtDNgay
            // 
            this.txtDNgay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDNgay.Culture = 1066;
            this.txtDNgay.CustomFormat = "dd/MM/yyyy";
            this.txtDNgay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDNgay.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
            this.txtDNgay.Location = new System.Drawing.Point(195, 63);
            this.txtDNgay.Name = "txtDNgay";
            this.txtDNgay.Size = new System.Drawing.Size(110, 20);
            this.txtDNgay.TabIndex = 134;
            this.txtDNgay.Tag = null;
            this.txtDNgay.ValueChanged += new System.EventHandler(this.txtDNgay_ValueChanged);
            this.txtDNgay.TextChanged += new System.EventHandler(this.txtDNgay_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.fgDoiTuong);
            this.groupBox1.Controls.Add(this.cmdTongHop);
            this.groupBox1.Controls.Add(this.cmbLanIn);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.raTatCa);
            this.groupBox1.Controls.Add(this.raChiPhiChuaThu);
            this.groupBox1.Location = new System.Drawing.Point(350, -8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(846, 34);
            this.groupBox1.TabIndex = 138;
            this.groupBox1.TabStop = false;
            // 
            // fgDoiTuong
            // 
            this.fgDoiTuong.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.fgDoiTuong.AllowEditing = false;
            this.fgDoiTuong.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
            this.fgDoiTuong.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.fgDoiTuong.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle;
            this.fgDoiTuong.ColumnInfo = resources.GetString("fgDoiTuong.ColumnInfo");
            this.fgDoiTuong.ExtendLastCol = true;
            this.fgDoiTuong.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid;
            this.fgDoiTuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fgDoiTuong.Location = new System.Drawing.Point(830, 18);
            this.fgDoiTuong.Name = "fgDoiTuong";
            this.fgDoiTuong.Rows.Count = 1;
            this.fgDoiTuong.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox;
            this.fgDoiTuong.ShowCursor = true;
            this.fgDoiTuong.Size = new System.Drawing.Size(10, 10);
            this.fgDoiTuong.Styles = new C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("fgDoiTuong.Styles"));
            this.fgDoiTuong.TabIndex = 140;
            // 
            // cmdTongHop
            // 
            this.cmdTongHop.Enabled = false;
            this.cmdTongHop.Location = new System.Drawing.Point(265, 8);
            this.cmdTongHop.Name = "cmdTongHop";
            this.cmdTongHop.Size = new System.Drawing.Size(64, 24);
            this.cmdTongHop.TabIndex = 164;
            this.cmdTongHop.Text = "Tổng hợp";
            this.cmdTongHop.UseVisualStyleBackColor = true;
            this.cmdTongHop.Click += new System.EventHandler(this.cmdTongHop_Click);
            // 
            // cmbLanIn
            // 
            this.cmbLanIn.AddItemSeparator = ';';
            this.cmbLanIn.AllowColMove = false;
            this.cmbLanIn.AllowRowSizing = C1.Win.C1List.RowSizingEnum.AllRows;
            this.cmbLanIn.AutoCompletion = true;
            this.cmbLanIn.AutoDropDown = true;
            this.cmbLanIn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cmbLanIn.Caption = "";
            this.cmbLanIn.CaptionHeight = 17;
            this.cmbLanIn.CaptionStyle = style9;
            this.cmbLanIn.CaptionVisible = false;
            this.cmbLanIn.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cmbLanIn.ColumnCaptionHeight = 17;
            this.cmbLanIn.ColumnFooterHeight = 17;
            this.cmbLanIn.ColumnHeaders = false;
            this.cmbLanIn.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList;
            this.cmbLanIn.ContentHeight = 16;
            this.cmbLanIn.DataMode = C1.Win.C1List.DataModeEnum.AddItem;
            this.cmbLanIn.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cmbLanIn.DefColWidth = 1;
            this.cmbLanIn.DisplayMember = "Danh mục";
            this.cmbLanIn.EditorBackColor = System.Drawing.Color.White;
            this.cmbLanIn.EditorFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLanIn.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbLanIn.EditorHeight = 16;
            this.cmbLanIn.Enabled = false;
            this.cmbLanIn.EvenRowStyle = style10;
            this.cmbLanIn.ExtendRightColumn = true;
            this.cmbLanIn.FlatStyle = C1.Win.C1List.FlatModeEnum.Popup;
            this.cmbLanIn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLanIn.FooterStyle = style11;
            this.cmbLanIn.GapHeight = 2;
            this.cmbLanIn.HeadingStyle = style12;
            this.cmbLanIn.HighLightRowStyle = style13;
            this.cmbLanIn.ItemHeight = 15;
            this.cmbLanIn.Location = new System.Drawing.Point(102, 10);
            this.cmbLanIn.MatchCol = C1.Win.C1List.MatchColEnum.AllCols;
            this.cmbLanIn.MatchEntryTimeout = ((long)(2000));
            this.cmbLanIn.MaxDropDownItems = ((short)(10));
            this.cmbLanIn.MaxLength = 32767;
            this.cmbLanIn.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cmbLanIn.Name = "cmbLanIn";
            this.cmbLanIn.OddRowStyle = style14;
            this.cmbLanIn.PartialRightColumn = false;
            this.cmbLanIn.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.cmbLanIn.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.cmbLanIn.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cmbLanIn.SelectedStyle = style15;
            this.cmbLanIn.Size = new System.Drawing.Size(161, 20);
            this.cmbLanIn.Style = style16;
            this.cmbLanIn.TabIndex = 162;
            this.cmbLanIn.PropBag = resources.GetString("cmbLanIn.PropBag");
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Enabled = false;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(5, 12);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(94, 16);
            this.label10.TabIndex = 163;
            this.label10.Text = "Lần thanh toán";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // raTatCa
            // 
            this.raTatCa.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.raTatCa.AutoSize = true;
            this.raTatCa.Enabled = false;
            this.raTatCa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.raTatCa.ForeColor = System.Drawing.Color.Blue;
            this.raTatCa.Location = new System.Drawing.Point(654, 10);
            this.raTatCa.Name = "raTatCa";
            this.raTatCa.Size = new System.Drawing.Size(64, 20);
            this.raTatCa.TabIndex = 139;
            this.raTatCa.Text = "Tất cả";
            // 
            // raChiPhiChuaThu
            // 
            this.raChiPhiChuaThu.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.raChiPhiChuaThu.AutoSize = true;
            this.raChiPhiChuaThu.Checked = true;
            this.raChiPhiChuaThu.Enabled = false;
            this.raChiPhiChuaThu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.raChiPhiChuaThu.ForeColor = System.Drawing.Color.Blue;
            this.raChiPhiChuaThu.Location = new System.Drawing.Point(445, 10);
            this.raChiPhiChuaThu.Name = "raChiPhiChuaThu";
            this.raChiPhiChuaThu.Size = new System.Drawing.Size(206, 20);
            this.raChiPhiChuaThu.TabIndex = 138;
            this.raChiPhiChuaThu.TabStop = true;
            this.raChiPhiChuaThu.Text = "Những dịch vụ chưa thanh toán";
            this.raChiPhiChuaThu.CheckedChanged += new System.EventHandler(this.raChiPhiChuaThu_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(322, 47);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 139;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // frmPhieuTT_DTNT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1199, 733);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDNgay);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rdChuyenKhoa);
            this.Controls.Add(this.arvMain);
            this.Controls.Add(this.txtTNgay);
            this.Controls.Add(this.rdDaRV);
            this.Controls.Add(this.rdChuaRV);
            this.Controls.Add(this.fgDanhSach);
            this.Controls.Add(this.lblListTitle);
            this.Controls.Add(this.cmbKhoa);
            this.Controls.Add(this.label16);
            this.Name = "frmPhieuTT_DTNT";
            this.Text = "Phiếu thanh toán điều trị nội trú";
            this.Load += new System.EventHandler(this.frmPhieuTT_DTNT_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtTNgay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fgDanhSach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKhoa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDNgay)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fgDoiTuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLanIn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private C1.Win.C1Input.C1DateEdit txtTNgay;
        private System.Windows.Forms.RadioButton rdDaRV;
        private System.Windows.Forms.RadioButton rdChuaRV;
        private C1.Win.C1FlexGrid.C1FlexGrid fgDanhSach;
        private System.Windows.Forms.Label lblListTitle;
        internal C1.Win.C1List.C1Combo cmbKhoa;
        private System.Windows.Forms.Label label16;
        private DataDynamics.ActiveReports.Viewer.Viewer arvMain;
        private System.Windows.Forms.RadioButton rdChuyenKhoa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private C1.Win.C1Input.C1DateEdit txtDNgay;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton raTatCa;
        private System.Windows.Forms.RadioButton raChiPhiChuaThu;
        internal C1.Win.C1List.C1Combo cmbLanIn;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button cmdTongHop;
        private System.Windows.Forms.CheckBox checkBox1;
        private C1.Win.C1FlexGrid.C1FlexGrid fgDoiTuong;
    }
}