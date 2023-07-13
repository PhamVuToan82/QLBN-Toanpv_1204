namespace NamDinh_QLBN.Forms.DuLieu
{
    partial class frmChiSoSoThuoc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChiSoSoThuoc));
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
            this.fg = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.cmbKhoa = new C1.Win.C1List.C1Combo();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.cmbThuoc = new C1.Win.C1List.C1Combo();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdGhi = new DevExpress.XtraEditors.SimpleButton();
            this.cmdThoat = new DevExpress.XtraEditors.SimpleButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdTop = new System.Windows.Forms.Button();
            this.cmdButton = new DevExpress.XtraEditors.SimpleButton();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.fg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKhoa)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbThuoc)).BeginInit();
            this.SuspendLayout();
            // 
            // fg
            // 
            this.fg.AllowDelete = true;
            this.fg.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.fg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Light3D;
            this.fg.ColumnInfo = resources.GetString("fg.ColumnInfo");
            this.fg.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid;
            this.fg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fg.HighLight = C1.Win.C1FlexGrid.HighLightEnum.WithFocus;
            this.fg.Location = new System.Drawing.Point(4, 85);
            this.fg.Name = "fg";
            this.fg.Rows.Count = 1;
            this.fg.Rows.MinSize = 20;
            this.fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox;
            this.fg.ShowCursor = true;
            this.fg.Size = new System.Drawing.Size(727, 291);
            this.fg.Styles = new C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("fg.Styles"));
            this.fg.TabIndex = 126;
            this.fg.BeforeDeleteRow += new C1.Win.C1FlexGrid.RowColEventHandler(this.fg_BeforeDeleteRow);
            this.fg.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmChiSoSoThuoc_KeyDown);
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
            this.cmbKhoa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmChiSoSoThuoc_KeyDown);
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
            this.groupBox1.Controls.Add(this.simpleButton1);
            this.groupBox1.Controls.Add(this.cmbThuoc);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(4, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(725, 48);
            this.groupBox1.TabIndex = 129;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cập nhật danh sách thuốc";
            // 
            // simpleButton1
            // 
            this.simpleButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.simpleButton1.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(486, 17);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(97, 27);
            this.simpleButton1.Style = new DevExpress.Utils.ViewStyle("ControlStyle", null, new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))), "", DevExpress.Utils.StyleOptions.StyleEnabled, true, false, false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.SystemColors.Control, System.Drawing.SystemColors.ControlText);
            this.simpleButton1.TabIndex = 128;
            this.simpleButton1.Text = "Chọn[F5]";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // cmbThuoc
            // 
            this.cmbThuoc.AddItemSeparator = ';';
            this.cmbThuoc.AllowColMove = false;
            this.cmbThuoc.AllowDrag = true;
            this.cmbThuoc.AllowDrop = true;
            this.cmbThuoc.AllowRowSizing = C1.Win.C1List.RowSizingEnum.AllRows;
            this.cmbThuoc.AutoCompletion = true;
            this.cmbThuoc.AutoDropDown = true;
            this.cmbThuoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cmbThuoc.Caption = "";
            this.cmbThuoc.CaptionHeight = 17;
            this.cmbThuoc.CaptionStyle = style9;
            this.cmbThuoc.CaptionVisible = false;
            this.cmbThuoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cmbThuoc.ColumnCaptionHeight = 17;
            this.cmbThuoc.ColumnFooterHeight = 17;
            this.cmbThuoc.ColumnHeaders = false;
            this.cmbThuoc.ContentHeight = 16;
            this.cmbThuoc.DataMode = C1.Win.C1List.DataModeEnum.AddItem;
            this.cmbThuoc.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cmbThuoc.DefColWidth = 290;
            this.cmbThuoc.DisplayMember = "TenThuoc";
            this.cmbThuoc.EditorBackColor = System.Drawing.Color.White;
            this.cmbThuoc.EditorFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbThuoc.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbThuoc.EditorHeight = 16;
            this.cmbThuoc.EvenRowStyle = style10;
            this.cmbThuoc.ExtendRightColumn = true;
            this.cmbThuoc.FlatStyle = C1.Win.C1List.FlatModeEnum.Popup;
            this.cmbThuoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbThuoc.FooterStyle = style11;
            this.cmbThuoc.GapHeight = 2;
            this.cmbThuoc.HeadingStyle = style12;
            this.cmbThuoc.HighLightRowStyle = style13;
            this.cmbThuoc.ItemHeight = 15;
            this.cmbThuoc.Location = new System.Drawing.Point(105, 20);
            this.cmbThuoc.MatchCol = C1.Win.C1List.MatchColEnum.AllCols;
            this.cmbThuoc.MatchEntryTimeout = ((long)(2000));
            this.cmbThuoc.MaxDropDownItems = ((short)(30));
            this.cmbThuoc.MaxLength = 32767;
            this.cmbThuoc.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cmbThuoc.Name = "cmbThuoc";
            this.cmbThuoc.OddRowStyle = style14;
            this.cmbThuoc.PartialRightColumn = false;
            this.cmbThuoc.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.cmbThuoc.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.cmbThuoc.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cmbThuoc.SelectedStyle = style15;
            this.cmbThuoc.Size = new System.Drawing.Size(375, 20);
            this.cmbThuoc.Style = style16;
            this.cmbThuoc.TabIndex = 124;
            this.cmbThuoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmChiSoSoThuoc_KeyDown);
            this.cmbThuoc.PropBag = resources.GetString("cmbThuoc.PropBag");
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(9, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 18);
            this.label1.TabIndex = 123;
            this.label1.Text = "Danh sách thuốc";
            // 
            // cmdGhi
            // 
            this.cmdGhi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdGhi.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdGhi.Image = ((System.Drawing.Image)(resources.GetObject("cmdGhi.Image")));
            this.cmdGhi.Location = new System.Drawing.Point(493, 383);
            this.cmdGhi.Name = "cmdGhi";
            this.cmdGhi.Size = new System.Drawing.Size(86, 27);
            this.cmdGhi.TabIndex = 128;
            this.cmdGhi.Text = "Ghi";
            this.cmdGhi.Click += new System.EventHandler(this.cmdGhi_Click);
            this.cmdGhi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmChiSoSoThuoc_KeyDown);
            // 
            // cmdThoat
            // 
            this.cmdThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdThoat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdThoat.Image = ((System.Drawing.Image)(resources.GetObject("cmdThoat.Image")));
            this.cmdThoat.Location = new System.Drawing.Point(594, 383);
            this.cmdThoat.Name = "cmdThoat";
            this.cmdThoat.Size = new System.Drawing.Size(100, 27);
            this.cmdThoat.TabIndex = 127;
            this.cmdThoat.Text = "Thoát";
            this.cmdThoat.Click += new System.EventHandler(this.cmdThoat_Click);
            this.cmdThoat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmChiSoSoThuoc_KeyDown);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(26, 389);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 15);
            this.label2.TabIndex = 130;
            this.label2.Text = "Chú ý:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.Location = new System.Drawing.Point(74, 391);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(349, 18);
            this.label3.TabIndex = 131;
            this.label3.Text = "Nhấn nút Delete đễ xóa thuốc không đúng";
            // 
            // cmdTop
            // 
            this.cmdTop.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmdTop.Image = ((System.Drawing.Image)(resources.GetObject("cmdTop.Image")));
            this.cmdTop.Location = new System.Drawing.Point(732, 121);
            this.cmdTop.Name = "cmdTop";
            this.cmdTop.Size = new System.Drawing.Size(37, 42);
            this.cmdTop.TabIndex = 132;
            this.cmdTop.UseVisualStyleBackColor = true;
            this.cmdTop.Click += new System.EventHandler(this.cmdTop_Click);
            // 
            // cmdButton
            // 
            this.cmdButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmdButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdButton.Image = ((System.Drawing.Image)(resources.GetObject("cmdButton.Image")));
            this.cmdButton.Location = new System.Drawing.Point(732, 232);
            this.cmdButton.Name = "cmdButton";
            this.cmdButton.Size = new System.Drawing.Size(37, 41);
            this.cmdButton.Style = new DevExpress.Utils.ViewStyle("ControlStyle", null, new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))), "", DevExpress.Utils.StyleOptions.StyleEnabled, true, false, false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.SystemColors.Control, System.Drawing.SystemColors.ControlText);
            this.cmdButton.TabIndex = 133;
            this.cmdButton.Click += new System.EventHandler(this.cmdButton_Click);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button1.Location = new System.Drawing.Point(732, 162);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(37, 71);
            this.button1.TabIndex = 134;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // frmChiSoSoThuoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 416);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmdButton);
            this.Controls.Add(this.cmdTop);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmdGhi);
            this.Controls.Add(this.cmdThoat);
            this.Controls.Add(this.fg);
            this.Controls.Add(this.cmbKhoa);
            this.Controls.Add(this.label12);
            this.Name = "frmChiSoSoThuoc";
            this.Text = "Vật tư tiêu hao";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmChiSoSoThuoc_KeyDown);
            this.Load += new System.EventHandler(this.frmChiSoSoThuoc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKhoa)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmbThuoc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton cmdGhi;
        private DevExpress.XtraEditors.SimpleButton cmdThoat;
        private C1.Win.C1FlexGrid.C1FlexGrid fg;
        internal C1.Win.C1List.C1Combo cmbKhoa;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        internal C1.Win.C1List.C1Combo cmbThuoc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cmdTop;
        private DevExpress.XtraEditors.SimpleButton cmdButton;
        private System.Windows.Forms.Button button1;
    }
}