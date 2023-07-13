namespace NamDinh_QLBN.Forms.DuLieu
{
    partial class frmDanhSachTV
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDanhSachTV));
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.cmbThuoc = new C1.Win.C1List.C1Combo();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdGhi = new DevExpress.XtraEditors.SimpleButton();
            this.cmdThoat = new DevExpress.XtraEditors.SimpleButton();
            this.fg = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.cmbKhoa = new C1.Win.C1List.C1Combo();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbThuoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKhoa)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.Location = new System.Drawing.Point(74, 348);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(284, 19);
            this.label3.TabIndex = 139;
            this.label3.Text = "Nhấn nút Delete đễ xóa thuốc không đúng";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(26, 346);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 16);
            this.label2.TabIndex = 138;
            this.label2.Text = "Chú ý:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.simpleButton1);
            this.groupBox1.Controls.Add(this.cmbThuoc);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(5, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(725, 48);
            this.groupBox1.TabIndex = 137;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cập nhật danh sách thuốc";
            // 
            // simpleButton1
            // 
            this.simpleButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.simpleButton1.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(486, 17);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(100, 27);
            this.simpleButton1.Style = new DevExpress.Utils.ViewStyle("ControlStyle", null, new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))), "", DevExpress.Utils.StyleOptions.StyleEnabled, true, false, false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.SystemColors.Control, System.Drawing.SystemColors.ControlText);
            this.simpleButton1.TabIndex = 128;
            this.simpleButton1.Text = "Chọn [F5]";
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
            this.cmbThuoc.CaptionStyle = style17;
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
            this.cmbThuoc.EvenRowStyle = style18;
            this.cmbThuoc.ExtendRightColumn = true;
            this.cmbThuoc.FlatStyle = C1.Win.C1List.FlatModeEnum.Popup;
            this.cmbThuoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbThuoc.FooterStyle = style19;
            this.cmbThuoc.GapHeight = 2;
            this.cmbThuoc.HeadingStyle = style20;
            this.cmbThuoc.HighLightRowStyle = style21;
            this.cmbThuoc.ItemHeight = 15;
            this.cmbThuoc.Location = new System.Drawing.Point(105, 20);
            this.cmbThuoc.MatchCol = C1.Win.C1List.MatchColEnum.AllCols;
            this.cmbThuoc.MatchEntryTimeout = ((long)(2000));
            this.cmbThuoc.MaxDropDownItems = ((short)(30));
            this.cmbThuoc.MaxLength = 32767;
            this.cmbThuoc.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cmbThuoc.Name = "cmbThuoc";
            this.cmbThuoc.OddRowStyle = style22;
            this.cmbThuoc.PartialRightColumn = false;
            this.cmbThuoc.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.cmbThuoc.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.cmbThuoc.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cmbThuoc.SelectedStyle = style23;
            this.cmbThuoc.Size = new System.Drawing.Size(375, 20);
            this.cmbThuoc.Style = style24;
            this.cmbThuoc.TabIndex = 124;
            this.cmbThuoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmDanhSachTV_KeyDown);
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
            this.cmdGhi.Location = new System.Drawing.Point(493, 340);
            this.cmdGhi.Name = "cmdGhi";
            this.cmdGhi.Size = new System.Drawing.Size(86, 28);
            this.cmdGhi.TabIndex = 136;
            this.cmdGhi.Text = "Ghi";
            this.cmdGhi.Click += new System.EventHandler(this.cmdGhi_Click);
            this.cmdGhi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmDanhSachTV_KeyDown);
            // 
            // cmdThoat
            // 
            this.cmdThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdThoat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdThoat.Image = ((System.Drawing.Image)(resources.GetObject("cmdThoat.Image")));
            this.cmdThoat.Location = new System.Drawing.Point(594, 340);
            this.cmdThoat.Name = "cmdThoat";
            this.cmdThoat.Size = new System.Drawing.Size(100, 28);
            this.cmdThoat.TabIndex = 135;
            this.cmdThoat.Text = "Thoát";
            this.cmdThoat.Click += new System.EventHandler(this.cmdThoat_Click);
            this.cmdThoat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmDanhSachTV_KeyDown);
            // 
            // fg
            // 
            this.fg.AllowDelete = true;
            this.fg.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.fg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Light3D;
            this.fg.ColumnInfo = resources.GetString("fg.ColumnInfo");
            this.fg.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Inset;
            this.fg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fg.HighLight = C1.Win.C1FlexGrid.HighLightEnum.WithFocus;
            this.fg.Location = new System.Drawing.Point(5, 88);
            this.fg.Name = "fg";
            this.fg.Rows.Count = 1;
            this.fg.Rows.MinSize = 20;
            this.fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
            this.fg.ShowCursor = true;
            this.fg.Size = new System.Drawing.Size(727, 246);
            this.fg.Styles = new C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("fg.Styles"));
            this.fg.TabIndex = 134;
            this.fg.BeforeDeleteRow += new C1.Win.C1FlexGrid.RowColEventHandler(this.fg_BeforeDeleteRow);
            this.fg.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmDanhSachTV_KeyDown);
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
            this.cmbKhoa.CaptionStyle = style25;
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
            this.cmbKhoa.EvenRowStyle = style26;
            this.cmbKhoa.ExtendRightColumn = true;
            this.cmbKhoa.FlatStyle = C1.Win.C1List.FlatModeEnum.Popup;
            this.cmbKhoa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbKhoa.FooterStyle = style27;
            this.cmbKhoa.GapHeight = 2;
            this.cmbKhoa.HeadingStyle = style28;
            this.cmbKhoa.HighLightRowStyle = style29;
            this.cmbKhoa.ItemHeight = 15;
            this.cmbKhoa.Location = new System.Drawing.Point(44, 8);
            this.cmbKhoa.MatchCol = C1.Win.C1List.MatchColEnum.AllCols;
            this.cmbKhoa.MatchEntryTimeout = ((long)(2000));
            this.cmbKhoa.MaxDropDownItems = ((short)(10));
            this.cmbKhoa.MaxLength = 32767;
            this.cmbKhoa.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cmbKhoa.Name = "cmbKhoa";
            this.cmbKhoa.OddRowStyle = style30;
            this.cmbKhoa.PartialRightColumn = false;
            this.cmbKhoa.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.cmbKhoa.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.cmbKhoa.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cmbKhoa.SelectedStyle = style31;
            this.cmbKhoa.Size = new System.Drawing.Size(224, 20);
            this.cmbKhoa.Style = style32;
            this.cmbKhoa.TabIndex = 133;
            this.cmbKhoa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmDanhSachTV_KeyDown);
            this.cmbKhoa.PropBag = resources.GetString("cmbKhoa.PropBag");
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(10, 9);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(60, 18);
            this.label12.TabIndex = 132;
            this.label12.Text = "Khoa";
            // 
            // frmDanhSachTV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 380);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmdGhi);
            this.Controls.Add(this.cmdThoat);
            this.Controls.Add(this.fg);
            this.Controls.Add(this.cmbKhoa);
            this.Controls.Add(this.label12);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDanhSachTV";
            this.Text = "Danh sách thuốc trả vỏ";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmDanhSachTV_KeyDown);
            this.Load += new System.EventHandler(this.frmDanhSachTV_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmbThuoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKhoa)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        internal C1.Win.C1List.C1Combo cmbThuoc;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton cmdGhi;
        private DevExpress.XtraEditors.SimpleButton cmdThoat;
        private C1.Win.C1FlexGrid.C1FlexGrid fg;
        internal C1.Win.C1List.C1Combo cmbKhoa;
        private System.Windows.Forms.Label label12;
    }
}