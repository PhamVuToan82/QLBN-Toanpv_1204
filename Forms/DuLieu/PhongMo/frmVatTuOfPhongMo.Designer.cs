namespace NamDinh_QLBN.Forms.DuLieu.PhongMo
{
    partial class frmVatTuOfPhongMo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVatTuOfPhongMo));
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
            this.cmdGhi = new DevExpress.XtraEditors.SimpleButton();
            this.cmdThoat = new DevExpress.XtraEditors.SimpleButton();
            this.fg = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.cmbKhoa = new C1.Win.C1List.C1Combo();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmdChonVT = new DevExpress.XtraEditors.SimpleButton();
            this.cmbVatTu = new C1.Win.C1List.C1Combo();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdChot = new DevExpress.XtraEditors.SimpleButton();
            this.cmdPrint = new DevExpress.XtraEditors.SimpleButton();
            this.cmdInPhieuLinh = new DevExpress.XtraEditors.SimpleButton();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNgayChot = new C1.Win.C1Input.C1DateEdit();
            this.cmdSua = new DevExpress.XtraEditors.SimpleButton();
            this.cmbKhongGhi = new DevExpress.XtraEditors.SimpleButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.fg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKhoa)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbVatTu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNgayChot)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdGhi
            // 
            this.cmdGhi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdGhi.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdGhi.Image = ((System.Drawing.Image)(resources.GetObject("cmdGhi.Image")));
            this.cmdGhi.Location = new System.Drawing.Point(557, 307);
            this.cmdGhi.Name = "cmdGhi";
            this.cmdGhi.Size = new System.Drawing.Size(86, 27);
            this.cmdGhi.TabIndex = 128;
            this.cmdGhi.Text = "Ghi";
            this.cmdGhi.Click += new System.EventHandler(this.cmdGhi_Click);
            // 
            // cmdThoat
            // 
            this.cmdThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdThoat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdThoat.Image = ((System.Drawing.Image)(resources.GetObject("cmdThoat.Image")));
            this.cmdThoat.Location = new System.Drawing.Point(658, 307);
            this.cmdThoat.Name = "cmdThoat";
            this.cmdThoat.Size = new System.Drawing.Size(100, 27);
            this.cmdThoat.TabIndex = 127;
            this.cmdThoat.Text = "Thoát";
            this.cmdThoat.Click += new System.EventHandler(this.cmdThoat_Click);
            this.cmdThoat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmVatTu_KeyDown);
            // 
            // fg
            // 
            this.fg.AllowDelete = true;
            this.fg.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.fg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle;
            this.fg.ColumnInfo = resources.GetString("fg.ColumnInfo");
            this.fg.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Inset;
            this.fg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fg.Location = new System.Drawing.Point(4, 85);
            this.fg.Name = "fg";
            this.fg.Rows.Count = 1;
            this.fg.Rows.MinSize = 20;
            this.fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
            this.fg.Size = new System.Drawing.Size(791, 216);
            this.fg.Styles = new C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("fg.Styles"));
            this.fg.TabIndex = 126;
            this.fg.AfterRowColChange += new C1.Win.C1FlexGrid.RangeEventHandler(this.fg_AfterRowColChange);
            this.fg.AfterEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.fg_AfterEdit);
            this.fg.BeforeDeleteRow += new C1.Win.C1FlexGrid.RowColEventHandler(this.fg_BeforeDeleteRow);
            this.fg.AfterDeleteRow += new C1.Win.C1FlexGrid.RowColEventHandler(this.fg_AfterDeleteRow);
            this.fg.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmVatTu_KeyDown);
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
            this.cmbKhoa.Location = new System.Drawing.Point(43, 5);
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
            this.cmbKhoa.Size = new System.Drawing.Size(224, 20);
            this.cmbKhoa.Style = style8;
            this.cmbKhoa.TabIndex = 125;
            this.cmbKhoa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmVatTu_KeyDown);
            this.cmbKhoa.PropBag = resources.GetString("cmbKhoa.PropBag");
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(9, 6);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(60, 18);
            this.label12.TabIndex = 124;
            this.label12.Text = "Khoa";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cmdChonVT);
            this.groupBox1.Controls.Add(this.cmbVatTu);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(4, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(789, 48);
            this.groupBox1.TabIndex = 129;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cập nhật vật tư được sử dụng";
            // 
            // cmdChonVT
            // 
            this.cmdChonVT.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdChonVT.Image = ((System.Drawing.Image)(resources.GetObject("cmdChonVT.Image")));
            this.cmdChonVT.Location = new System.Drawing.Point(486, 17);
            this.cmdChonVT.Name = "cmdChonVT";
            this.cmdChonVT.Size = new System.Drawing.Size(97, 27);
            this.cmdChonVT.Style = new DevExpress.Utils.ViewStyle("ControlStyle", null, new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))), "", DevExpress.Utils.StyleOptions.StyleEnabled, true, false, false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.SystemColors.Control, System.Drawing.SystemColors.ControlText);
            this.cmdChonVT.TabIndex = 128;
            this.cmdChonVT.Text = "Chọn [F5]";
            this.cmdChonVT.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // cmbVatTu
            // 
            this.cmbVatTu.AddItemSeparator = ';';
            this.cmbVatTu.AllowColMove = false;
            this.cmbVatTu.AllowDrag = true;
            this.cmbVatTu.AllowDrop = true;
            this.cmbVatTu.AllowRowSizing = C1.Win.C1List.RowSizingEnum.AllRows;
            this.cmbVatTu.AutoCompletion = true;
            this.cmbVatTu.AutoDropDown = true;
            this.cmbVatTu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cmbVatTu.Caption = "";
            this.cmbVatTu.CaptionHeight = 17;
            this.cmbVatTu.CaptionStyle = style9;
            this.cmbVatTu.CaptionVisible = false;
            this.cmbVatTu.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cmbVatTu.ColumnCaptionHeight = 17;
            this.cmbVatTu.ColumnFooterHeight = 17;
            this.cmbVatTu.ColumnHeaders = false;
            this.cmbVatTu.ContentHeight = 16;
            this.cmbVatTu.DataMode = C1.Win.C1List.DataModeEnum.AddItem;
            this.cmbVatTu.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cmbVatTu.DefColWidth = 290;
            this.cmbVatTu.DisplayMember = "TenVT";
            this.cmbVatTu.EditorBackColor = System.Drawing.Color.White;
            this.cmbVatTu.EditorFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbVatTu.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbVatTu.EditorHeight = 16;
            this.cmbVatTu.EvenRowStyle = style10;
            this.cmbVatTu.ExtendRightColumn = true;
            this.cmbVatTu.FlatStyle = C1.Win.C1List.FlatModeEnum.Popup;
            this.cmbVatTu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbVatTu.FooterStyle = style11;
            this.cmbVatTu.GapHeight = 2;
            this.cmbVatTu.HeadingStyle = style12;
            this.cmbVatTu.HighLightRowStyle = style13;
            this.cmbVatTu.ItemHeight = 15;
            this.cmbVatTu.Location = new System.Drawing.Point(105, 20);
            this.cmbVatTu.MatchCol = C1.Win.C1List.MatchColEnum.AllCols;
            this.cmbVatTu.MatchEntryTimeout = ((long)(2000));
            this.cmbVatTu.MaxDropDownItems = ((short)(30));
            this.cmbVatTu.MaxLength = 32767;
            this.cmbVatTu.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cmbVatTu.Name = "cmbVatTu";
            this.cmbVatTu.OddRowStyle = style14;
            this.cmbVatTu.PartialRightColumn = false;
            this.cmbVatTu.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.cmbVatTu.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.cmbVatTu.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cmbVatTu.SelectedStyle = style15;
            this.cmbVatTu.Size = new System.Drawing.Size(375, 20);
            this.cmbVatTu.Style = style16;
            this.cmbVatTu.TabIndex = 124;
            this.cmbVatTu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmVatTu_KeyDown);
            this.cmbVatTu.PropBag = resources.GetString("cmbVatTu.PropBag");
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(9, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 18);
            this.label1.TabIndex = 123;
            this.label1.Text = "Danh sách vật tư";
            // 
            // cmdChot
            // 
            this.cmdChot.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.cmdChot.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdChot.Image = ((System.Drawing.Image)(resources.GetObject("cmdChot.Image")));
            this.cmdChot.Location = new System.Drawing.Point(471, 2);
            this.cmdChot.Name = "cmdChot";
            this.cmdChot.Size = new System.Drawing.Size(100, 24);
            this.cmdChot.Style = new DevExpress.Utils.ViewStyle("ControlStyle", null, new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))), "", DevExpress.Utils.StyleOptions.StyleEnabled, true, false, false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.SystemColors.Control, System.Drawing.SystemColors.ControlText);
            this.cmdChot.TabIndex = 132;
            this.cmdChot.Text = "Chốt";
            this.cmdChot.Click += new System.EventHandler(this.cmdChot_Click);
            this.cmdChot.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmVatTu_KeyDown);
            // 
            // cmdPrint
            // 
            this.cmdPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdPrint.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdPrint.Image = ((System.Drawing.Image)(resources.GetObject("cmdPrint.Image")));
            this.cmdPrint.Location = new System.Drawing.Point(22, 307);
            this.cmdPrint.Name = "cmdPrint";
            this.cmdPrint.Size = new System.Drawing.Size(115, 27);
            this.cmdPrint.TabIndex = 134;
            this.cmdPrint.Text = "In phiếu kiểm kê";
            this.cmdPrint.Click += new System.EventHandler(this.cmdPrint_Click);
            this.cmdPrint.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmVatTu_KeyDown);
            // 
            // cmdInPhieuLinh
            // 
            this.cmdInPhieuLinh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdInPhieuLinh.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdInPhieuLinh.Image = ((System.Drawing.Image)(resources.GetObject("cmdInPhieuLinh.Image")));
            this.cmdInPhieuLinh.Location = new System.Drawing.Point(152, 307);
            this.cmdInPhieuLinh.Name = "cmdInPhieuLinh";
            this.cmdInPhieuLinh.Size = new System.Drawing.Size(115, 27);
            this.cmdInPhieuLinh.TabIndex = 140;
            this.cmdInPhieuLinh.Text = "In phiếu lĩnh VT";
            this.cmdInPhieuLinh.Click += new System.EventHandler(this.cmdInPhieuLinh_Click);
            this.cmdInPhieuLinh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmVatTu_KeyDown);
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(273, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 19);
            this.label4.TabIndex = 141;
            this.label4.Text = "Ngày chốt";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNgayChot
            // 
            this.txtNgayChot.Culture = 1066;
            this.txtNgayChot.CustomFormat = "dd/MM/yyyy";
            this.txtNgayChot.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
            this.txtNgayChot.Location = new System.Drawing.Point(335, 4);
            this.txtNgayChot.Name = "txtNgayChot";
            this.txtNgayChot.Size = new System.Drawing.Size(130, 20);
            this.txtNgayChot.TabIndex = 142;
            this.txtNgayChot.Tag = null;
            this.txtNgayChot.Value = new System.DateTime(2008, 9, 5, 14, 35, 26, 218);
            this.txtNgayChot.ValueChanged += new System.EventHandler(this.txtNgayChot_ValueChanged);
            this.txtNgayChot.TextChanged += new System.EventHandler(this.txtNgayChot_TextChanged);
            // 
            // cmdSua
            // 
            this.cmdSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSua.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdSua.Image = ((System.Drawing.Image)(resources.GetObject("cmdSua.Image")));
            this.cmdSua.Location = new System.Drawing.Point(557, 307);
            this.cmdSua.Name = "cmdSua";
            this.cmdSua.Size = new System.Drawing.Size(86, 27);
            this.cmdSua.TabIndex = 143;
            this.cmdSua.Text = "Sữa";
            this.cmdSua.Click += new System.EventHandler(this.cmdSua_Click);
            this.cmdSua.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmVatTu_KeyDown);
            // 
            // cmbKhongGhi
            // 
            this.cmbKhongGhi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbKhongGhi.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmbKhongGhi.Image = ((System.Drawing.Image)(resources.GetObject("cmbKhongGhi.Image")));
            this.cmbKhongGhi.Location = new System.Drawing.Point(659, 307);
            this.cmbKhongGhi.Name = "cmbKhongGhi";
            this.cmbKhongGhi.Size = new System.Drawing.Size(86, 27);
            this.cmbKhongGhi.TabIndex = 144;
            this.cmbKhongGhi.Text = "Không ghi";
            this.cmbKhongGhi.Click += new System.EventHandler(this.cmbKhongGhi_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(315, 315);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(212, 13);
            this.label3.TabIndex = 146;
            this.label3.Text = "Nhấn nút Delete đễ xóa vật tư không đúng";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(274, 313);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 16);
            this.label2.TabIndex = 145;
            this.label2.Text = "Chú ý:";
            // 
            // frmVatTuOfPhongMo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 340);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbKhongGhi);
            this.Controls.Add(this.cmdSua);
            this.Controls.Add(this.txtNgayChot);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmdInPhieuLinh);
            this.Controls.Add(this.cmdPrint);
            this.Controls.Add(this.cmdChot);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmdGhi);
            this.Controls.Add(this.cmdThoat);
            this.Controls.Add(this.fg);
            this.Controls.Add(this.cmbKhoa);
            this.Controls.Add(this.label12);
            this.Name = "frmVatTuOfPhongMo";
            this.Text = "Vật tư tiêu hao";
            this.Load += new System.EventHandler(this.frmVatTu_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmVatTu_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.fg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKhoa)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmbVatTu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNgayChot)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton cmdGhi;
        private DevExpress.XtraEditors.SimpleButton cmdThoat;
        private C1.Win.C1FlexGrid.C1FlexGrid fg;
        internal C1.Win.C1List.C1Combo cmbKhoa;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.SimpleButton cmdChonVT;
        internal C1.Win.C1List.C1Combo cmbVatTu;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton cmdChot;
        private DevExpress.XtraEditors.SimpleButton cmdPrint;
        private DevExpress.XtraEditors.SimpleButton cmdInPhieuLinh;
        private System.Windows.Forms.Label label4;
        private C1.Win.C1Input.C1DateEdit txtNgayChot;
        private DevExpress.XtraEditors.SimpleButton cmdSua;
        private DevExpress.XtraEditors.SimpleButton cmbKhongGhi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}