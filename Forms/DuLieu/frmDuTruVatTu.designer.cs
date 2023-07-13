namespace NamDinh_QLBN.Forms.DuLieu
{
    partial class frmDuTruVatTu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDuTruVatTu));
            C1.Win.C1List.Style style1 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style2 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style3 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style4 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style5 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style6 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style7 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style8 = new C1.Win.C1List.Style();
            this.fg = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.cmbKhoa = new C1.Win.C1List.C1Combo();
            this.label12 = new System.Windows.Forms.Label();
            this.grTimKiem = new System.Windows.Forms.GroupBox();
            this.lblChotSoGanNhat = new System.Windows.Forms.Label();
            this.txtDenNgay = new C1.Win.C1Input.C1DateEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.fgDSPhieu = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.cmdTim = new DevExpress.XtraEditors.SimpleButton();
            this.txtTuNgay = new C1.Win.C1Input.C1DateEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cmbHinhThuc = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnTongHop = new DevExpress.XtraEditors.SimpleButton();
            this.txtNgayDuTru = new C1.Win.C1Input.C1DateEdit();
            this.lblNgayDuTru = new System.Windows.Forms.Label();
            this.btnThem = new DevExpress.XtraEditors.SimpleButton();
            this.btnSua = new DevExpress.XtraEditors.SimpleButton();
            this.btnGhi = new DevExpress.XtraEditors.SimpleButton();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.btnHuy = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.fg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKhoa)).BeginInit();
            this.grTimKiem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDenNgay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fgDSPhieu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTuNgay)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNgayDuTru)).BeginInit();
            this.SuspendLayout();
            // 
            // fg
            // 
            this.fg.AllowDelete = true;
            this.fg.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle;
            this.fg.ColumnInfo = resources.GetString("fg.ColumnInfo");
            this.fg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fg.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Inset;
            this.fg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fg.Location = new System.Drawing.Point(0, 117);
            this.fg.Name = "fg";
            this.fg.Rows.Count = 1;
            this.fg.Rows.MinSize = 20;
            this.fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
            this.fg.Size = new System.Drawing.Size(803, 273);
            this.fg.Styles = new C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("fg.Styles"));
            this.fg.TabIndex = 126;
            this.fg.BeforeDeleteRow += new C1.Win.C1FlexGrid.RowColEventHandler(this.fg_BeforeDeleteRow);
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
            this.cmbKhoa.Location = new System.Drawing.Point(85, 19);
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
            this.cmbKhoa.PropBag = resources.GetString("cmbKhoa.PropBag");
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(12, 19);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(52, 18);
            this.label12.TabIndex = 124;
            this.label12.Text = "Khoa";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grTimKiem
            // 
            this.grTimKiem.Controls.Add(this.label12);
            this.grTimKiem.Controls.Add(this.lblChotSoGanNhat);
            this.grTimKiem.Controls.Add(this.cmbKhoa);
            this.grTimKiem.Controls.Add(this.txtDenNgay);
            this.grTimKiem.Controls.Add(this.label1);
            this.grTimKiem.Controls.Add(this.fgDSPhieu);
            this.grTimKiem.Controls.Add(this.cmdTim);
            this.grTimKiem.Controls.Add(this.txtTuNgay);
            this.grTimKiem.Controls.Add(this.label4);
            this.grTimKiem.Dock = System.Windows.Forms.DockStyle.Top;
            this.grTimKiem.Location = new System.Drawing.Point(0, 0);
            this.grTimKiem.Name = "grTimKiem";
            this.grTimKiem.Size = new System.Drawing.Size(803, 117);
            this.grTimKiem.TabIndex = 129;
            this.grTimKiem.TabStop = false;
            this.grTimKiem.Text = "Cập nhật vật tư được sử dụng";
            // 
            // lblChotSoGanNhat
            // 
            this.lblChotSoGanNhat.ForeColor = System.Drawing.Color.Blue;
            this.lblChotSoGanNhat.Location = new System.Drawing.Point(12, 93);
            this.lblChotSoGanNhat.Name = "lblChotSoGanNhat";
            this.lblChotSoGanNhat.Size = new System.Drawing.Size(209, 18);
            this.lblChotSoGanNhat.TabIndex = 148;
            this.lblChotSoGanNhat.Text = "Ngày chốt sổ gần nhất là:";
            // 
            // txtDenNgay
            // 
            this.txtDenNgay.Culture = 1066;
            this.txtDenNgay.CustomFormat = "dd/MM/yyyy";
            this.txtDenNgay.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
            this.txtDenNgay.Location = new System.Drawing.Point(85, 67);
            this.txtDenNgay.Name = "txtDenNgay";
            this.txtDenNgay.Size = new System.Drawing.Size(130, 20);
            this.txtDenNgay.TabIndex = 144;
            this.txtDenNgay.Tag = null;
            this.txtDenNgay.Value = new System.DateTime(((long)(0)));
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 19);
            this.label1.TabIndex = 143;
            this.label1.Text = "Đến ngày";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // fgDSPhieu
            // 
            this.fgDSPhieu.AllowDelete = true;
            this.fgDSPhieu.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.fgDSPhieu.AllowEditing = false;
            this.fgDSPhieu.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle;
            this.fgDSPhieu.ColumnInfo = resources.GetString("fgDSPhieu.ColumnInfo");
            this.fgDSPhieu.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Inset;
            this.fgDSPhieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fgDSPhieu.Location = new System.Drawing.Point(348, 16);
            this.fgDSPhieu.Name = "fgDSPhieu";
            this.fgDSPhieu.Rows.Count = 1;
            this.fgDSPhieu.Rows.MinSize = 20;
            this.fgDSPhieu.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
            this.fgDSPhieu.Size = new System.Drawing.Size(452, 98);
            this.fgDSPhieu.Styles = new C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("fgDSPhieu.Styles"));
            this.fgDSPhieu.TabIndex = 127;
            this.fgDSPhieu.BeforeDeleteRow += new C1.Win.C1FlexGrid.RowColEventHandler(this.fgDSPhieu_BeforeDeleteRow);
            this.fgDSPhieu.Click += new System.EventHandler(this.fgDSPhieu_Click);
            // 
            // cmdTim
            // 
            this.cmdTim.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.cmdTim.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdTim.Image = global::NamDinh_QLBN.Properties.Resources.Soi16;
            this.cmdTim.Location = new System.Drawing.Point(230, 43);
            this.cmdTim.Name = "cmdTim";
            this.cmdTim.Size = new System.Drawing.Size(79, 43);
            this.cmdTim.Style = new DevExpress.Utils.ViewStyle("ControlStyle", null, new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))), "", DevExpress.Utils.StyleOptions.StyleEnabled, true, false, false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.SystemColors.Control, System.Drawing.SystemColors.ControlText);
            this.cmdTim.TabIndex = 132;
            this.cmdTim.Text = "Tìm";
            this.cmdTim.Click += new System.EventHandler(this.cmdTim_Click);
            // 
            // txtTuNgay
            // 
            this.txtTuNgay.Culture = 1066;
            this.txtTuNgay.CustomFormat = "dd/MM/yyyy";
            this.txtTuNgay.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
            this.txtTuNgay.Location = new System.Drawing.Point(85, 41);
            this.txtTuNgay.Name = "txtTuNgay";
            this.txtTuNgay.Size = new System.Drawing.Size(130, 20);
            this.txtTuNgay.TabIndex = 142;
            this.txtTuNgay.Tag = null;
            this.txtTuNgay.Value = new System.DateTime(((long)(0)));
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(12, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 19);
            this.label4.TabIndex = 141;
            this.label4.Text = "Từ ngày";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cmbHinhThuc);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.btnTongHop);
            this.groupBox3.Controls.Add(this.txtNgayDuTru);
            this.groupBox3.Controls.Add(this.lblNgayDuTru);
            this.groupBox3.Controls.Add(this.btnThem);
            this.groupBox3.Controls.Add(this.btnSua);
            this.groupBox3.Controls.Add(this.btnGhi);
            this.groupBox3.Controls.Add(this.btnThoat);
            this.groupBox3.Controls.Add(this.btnHuy);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(0, 390);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(803, 41);
            this.groupBox3.TabIndex = 130;
            this.groupBox3.TabStop = false;
            // 
            // cmbHinhThuc
            // 
            this.cmbHinhThuc.FormattingEnabled = true;
            this.cmbHinhThuc.Items.AddRange(new object[] {
            "Lĩnh",
            "Đổi"});
            this.cmbHinhThuc.Location = new System.Drawing.Point(266, 12);
            this.cmbHinhThuc.Name = "cmbHinhThuc";
            this.cmbHinhThuc.Size = new System.Drawing.Size(109, 21);
            this.cmbHinhThuc.TabIndex = 131;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(213, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 18);
            this.label2.TabIndex = 146;
            this.label2.Text = "Hình thức";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnTongHop
            // 
            this.btnTongHop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTongHop.Image = global::NamDinh_QLBN.Properties.Resources.DanhSach;
            this.btnTongHop.Location = new System.Drawing.Point(684, 8);
            this.btnTongHop.Name = "btnTongHop";
            this.btnTongHop.Size = new System.Drawing.Size(113, 27);
            this.btnTongHop.TabIndex = 145;
            this.btnTongHop.Text = "Xem tổng hợp";
            this.btnTongHop.Click += new System.EventHandler(this.btnTongHop_Click);
            // 
            // txtNgayDuTru
            // 
            this.txtNgayDuTru.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtNgayDuTru.Culture = 1066;
            this.txtNgayDuTru.CustomFormat = "dd/MM/yyyy";
            this.txtNgayDuTru.Enabled = false;
            this.txtNgayDuTru.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
            this.txtNgayDuTru.Location = new System.Drawing.Point(77, 10);
            this.txtNgayDuTru.Name = "txtNgayDuTru";
            this.txtNgayDuTru.Size = new System.Drawing.Size(130, 20);
            this.txtNgayDuTru.TabIndex = 144;
            this.txtNgayDuTru.Tag = null;
            this.txtNgayDuTru.Value = new System.DateTime(((long)(0)));
            // 
            // lblNgayDuTru
            // 
            this.lblNgayDuTru.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNgayDuTru.ForeColor = System.Drawing.Color.Black;
            this.lblNgayDuTru.Location = new System.Drawing.Point(17, 11);
            this.lblNgayDuTru.Name = "lblNgayDuTru";
            this.lblNgayDuTru.Size = new System.Drawing.Size(54, 19);
            this.lblNgayDuTru.TabIndex = 143;
            this.lblNgayDuTru.Text = "Ngày lập";
            this.lblNgayDuTru.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnThem
            // 
            this.btnThem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnThem.Image = global::NamDinh_QLBN.Properties.Resources.Them;
            this.btnThem.Location = new System.Drawing.Point(381, 8);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(86, 27);
            this.btnThem.TabIndex = 129;
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSua.Image = global::NamDinh_QLBN.Properties.Resources.Sua;
            this.btnSua.Location = new System.Drawing.Point(474, 8);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(86, 27);
            this.btnSua.TabIndex = 128;
            this.btnSua.Text = "Sửa";
            this.btnSua.Click += new System.EventHandler(this.cmdSua_Click);
            // 
            // btnGhi
            // 
            this.btnGhi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGhi.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnGhi.Image = ((System.Drawing.Image)(resources.GetObject("btnGhi.Image")));
            this.btnGhi.Location = new System.Drawing.Point(381, 8);
            this.btnGhi.Name = "btnGhi";
            this.btnGhi.Size = new System.Drawing.Size(86, 27);
            this.btnGhi.TabIndex = 131;
            this.btnGhi.Text = "Ghi";
            this.btnGhi.Click += new System.EventHandler(this.btnGhi_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnThoat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnThoat.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.Image")));
            this.btnThoat.Location = new System.Drawing.Point(582, 8);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(87, 27);
            this.btnThoat.TabIndex = 127;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.cmdThoat_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnHuy.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnHuy.Location = new System.Drawing.Point(473, 8);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(87, 27);
            this.btnHuy.TabIndex = 132;
            this.btnHuy.Text = "Không ghi";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // frmDuTruVatTu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 431);
            this.Controls.Add(this.fg);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.grTimKiem);
            this.Name = "frmDuTruVatTu";
            this.Text = "Dự trù vật tư tiêu hao";
            this.Load += new System.EventHandler(this.frmVatTu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKhoa)).EndInit();
            this.grTimKiem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtDenNgay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fgDSPhieu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTuNgay)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtNgayDuTru)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnSua;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private C1.Win.C1FlexGrid.C1FlexGrid fg;
        internal C1.Win.C1List.C1Combo cmbKhoa;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox grTimKiem;
        private DevExpress.XtraEditors.SimpleButton cmdTim;
        private System.Windows.Forms.Label label4;
        private C1.Win.C1Input.C1DateEdit txtTuNgay;
        private System.Windows.Forms.Label lblChotSoGanNhat;
        private System.Windows.Forms.GroupBox groupBox3;
        private DevExpress.XtraEditors.SimpleButton btnThem;
        private C1.Win.C1FlexGrid.C1FlexGrid fgDSPhieu;
        private C1.Win.C1Input.C1DateEdit txtDenNgay;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton btnGhi;
        private DevExpress.XtraEditors.SimpleButton btnHuy;
        private C1.Win.C1Input.C1DateEdit txtNgayDuTru;
        private System.Windows.Forms.Label lblNgayDuTru;
        private DevExpress.XtraEditors.SimpleButton btnTongHop;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox cmbHinhThuc;
    }
}