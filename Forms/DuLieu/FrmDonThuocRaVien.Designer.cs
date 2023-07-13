namespace NamDinh_QLBN.Forms.DuLieu
{
    partial class FrmDonThuocRaVien
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDonThuocRaVien));
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
            this.grdDMThuoc = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.lblChitiet_Donthuoc = new System.Windows.Forms.Label();
            this.txtLoidan = new System.Windows.Forms.TextBox();
            this.Label77 = new System.Windows.Forms.Label();
            this.txtHamluong = new System.Windows.Forms.TextBox();
            this.Label33 = new System.Windows.Forms.Label();
            this.Label80 = new System.Windows.Forms.Label();
            this.txtThuoc = new System.Windows.Forms.TextBox();
            this.Label81 = new System.Windows.Forms.Label();
            this.grdSoanDonthuoc = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.txtCachdung_Thuoc = new System.Windows.Forms.TextBox();
            this.txtDVT_Thuoc = new System.Windows.Forms.TextBox();
            this.Label85 = new System.Windows.Forms.Label();
            this.cmdXoadon = new System.Windows.Forms.Button();
            this.cmdSuadon = new System.Windows.Forms.Button();
            this.cmdThemdon = new System.Windows.Forms.Button();
            this.Label90 = new System.Windows.Forms.Label();
            this.grdDSDonthuoc = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.cmdKhongLuuDonthuoc = new System.Windows.Forms.Button();
            this.cmdClosepanDonthuoc = new System.Windows.Forms.Button();
            this.cmdLuu_XemDonthuoc = new System.Windows.Forms.Button();
            this.cmdLuuDonthuoc = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNgayChiDinh = new C1.Win.C1Input.C1DateEdit();
            this.cmbBacSi = new C1.Win.C1List.C1Combo();
            this.cmdThem_Thuoc = new System.Windows.Forms.Button();
            this.txtTengoc = new System.Windows.Forms.TextBox();
            this.txtSoluong_Thuoc = new C1.Win.C1Input.C1NumericEdit();
            this.Label84 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbMatBenh = new C1.Win.C1List.C1Combo();
            this.chkSoTay = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdDMThuoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSoanDonthuoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDSDonthuoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNgayChiDinh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBacSi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoluong_Thuoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMatBenh)).BeginInit();
            this.SuspendLayout();
            // 
            // grdDMThuoc
            // 
            this.grdDMThuoc.AllowEditing = false;
            this.grdDMThuoc.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle;
            this.grdDMThuoc.ColumnInfo = "0,0,0,0,0,85,Columns:";
            this.grdDMThuoc.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdDMThuoc.Location = new System.Drawing.Point(324, 73);
            this.grdDMThuoc.Name = "grdDMThuoc";
            this.grdDMThuoc.Rows.Count = 0;
            this.grdDMThuoc.Rows.Fixed = 0;
            this.grdDMThuoc.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
            this.grdDMThuoc.Size = new System.Drawing.Size(368, 288);
            this.grdDMThuoc.Styles = new C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("grdDMThuoc.Styles"));
            this.grdDMThuoc.TabIndex = 210;
            this.grdDMThuoc.Visible = false;
            this.grdDMThuoc.DoubleClick += new System.EventHandler(this.grdDMThuoc_DoubleClick);
            this.grdDMThuoc.KeyUp += new System.Windows.Forms.KeyEventHandler(this.grdDMThuoc_KeyUp);
            this.grdDMThuoc.Leave += new System.EventHandler(this.grdDMThuoc_Leave);
            this.grdDMThuoc.Validated += new System.EventHandler(this.grdDMThuoc_Validated);
            // 
            // lblChitiet_Donthuoc
            // 
            this.lblChitiet_Donthuoc.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.lblChitiet_Donthuoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChitiet_Donthuoc.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblChitiet_Donthuoc.Location = new System.Drawing.Point(260, 103);
            this.lblChitiet_Donthuoc.Name = "lblChitiet_Donthuoc";
            this.lblChitiet_Donthuoc.Size = new System.Drawing.Size(271, 17);
            this.lblChitiet_Donthuoc.TabIndex = 219;
            this.lblChitiet_Donthuoc.Text = "Danh sách thuốc kê trong đơn";
            // 
            // txtLoidan
            // 
            this.txtLoidan.Enabled = false;
            this.txtLoidan.Location = new System.Drawing.Point(260, 461);
            this.txtLoidan.Multiline = true;
            this.txtLoidan.Name = "txtLoidan";
            this.txtLoidan.Size = new System.Drawing.Size(638, 43);
            this.txtLoidan.TabIndex = 215;
            // 
            // Label77
            // 
            this.Label77.AutoSize = true;
            this.Label77.Location = new System.Drawing.Point(260, 444);
            this.Label77.Name = "Label77";
            this.Label77.Size = new System.Drawing.Size(100, 13);
            this.Label77.TabIndex = 216;
            this.Label77.Text = "Lời dặn của bác sĩ:";
            // 
            // txtHamluong
            // 
            this.txtHamluong.Location = new System.Drawing.Point(556, 53);
            this.txtHamluong.Name = "txtHamluong";
            this.txtHamluong.Size = new System.Drawing.Size(96, 20);
            this.txtHamluong.TabIndex = 205;
            // 
            // Label33
            // 
            this.Label33.AutoSize = true;
            this.Label33.Location = new System.Drawing.Point(500, 56);
            this.Label33.Name = "Label33";
            this.Label33.Size = new System.Drawing.Size(61, 13);
            this.Label33.TabIndex = 212;
            this.Label33.Text = "Hàm lượng:";
            // 
            // Label80
            // 
            this.Label80.AutoSize = true;
            this.Label80.Location = new System.Drawing.Point(260, 83);
            this.Label80.Name = "Label80";
            this.Label80.Size = new System.Drawing.Size(62, 13);
            this.Label80.TabIndex = 208;
            this.Label80.Text = "Cách dùng:";
            // 
            // txtThuoc
            // 
            this.txtThuoc.Location = new System.Drawing.Point(324, 53);
            this.txtThuoc.Name = "txtThuoc";
            this.txtThuoc.Size = new System.Drawing.Size(176, 20);
            this.txtThuoc.TabIndex = 204;
            this.txtThuoc.TextChanged += new System.EventHandler(this.txtThuoc_TextChanged);
            this.txtThuoc.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtThuoc_KeyUp);
            this.txtThuoc.Leave += new System.EventHandler(this.txtThuoc_Leave);
            this.txtThuoc.Validated += new System.EventHandler(this.txtThuoc_Validated);
            // 
            // Label81
            // 
            this.Label81.AutoSize = true;
            this.Label81.Location = new System.Drawing.Point(260, 56);
            this.Label81.Name = "Label81";
            this.Label81.Size = new System.Drawing.Size(59, 13);
            this.Label81.TabIndex = 205;
            this.Label81.Text = "Tên thuốc:";
            // 
            // grdSoanDonthuoc
            // 
            this.grdSoanDonthuoc.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle;
            this.grdSoanDonthuoc.ColumnInfo = resources.GetString("grdSoanDonthuoc.ColumnInfo");
            this.grdSoanDonthuoc.ExtendLastCol = true;
            this.grdSoanDonthuoc.Location = new System.Drawing.Point(260, 120);
            this.grdSoanDonthuoc.Name = "grdSoanDonthuoc";
            this.grdSoanDonthuoc.Rows.Count = 12;
            this.grdSoanDonthuoc.Size = new System.Drawing.Size(641, 316);
            this.grdSoanDonthuoc.Styles = new C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("grdSoanDonthuoc.Styles"));
            this.grdSoanDonthuoc.TabIndex = 203;
            this.grdSoanDonthuoc.KeyUp += new System.Windows.Forms.KeyEventHandler(this.grdSoanDonthuoc_KeyUp);
            // 
            // txtCachdung_Thuoc
            // 
            this.txtCachdung_Thuoc.Location = new System.Drawing.Point(324, 80);
            this.txtCachdung_Thuoc.Multiline = true;
            this.txtCachdung_Thuoc.Name = "txtCachdung_Thuoc";
            this.txtCachdung_Thuoc.Size = new System.Drawing.Size(504, 20);
            this.txtCachdung_Thuoc.TabIndex = 208;
            // 
            // txtDVT_Thuoc
            // 
            this.txtDVT_Thuoc.Location = new System.Drawing.Point(688, 53);
            this.txtDVT_Thuoc.Name = "txtDVT_Thuoc";
            this.txtDVT_Thuoc.Size = new System.Drawing.Size(72, 20);
            this.txtDVT_Thuoc.TabIndex = 206;
            // 
            // Label85
            // 
            this.Label85.AutoSize = true;
            this.Label85.Location = new System.Drawing.Point(660, 56);
            this.Label85.Name = "Label85";
            this.Label85.Size = new System.Drawing.Size(32, 13);
            this.Label85.TabIndex = 207;
            this.Label85.Text = "ĐVT:";
            // 
            // cmdXoadon
            // 
            this.cmdXoadon.BackColor = System.Drawing.Color.Transparent;
            this.cmdXoadon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdXoadon.Image = ((System.Drawing.Image)(resources.GetObject("cmdXoadon.Image")));
            this.cmdXoadon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdXoadon.Location = new System.Drawing.Point(177, 510);
            this.cmdXoadon.Name = "cmdXoadon";
            this.cmdXoadon.Size = new System.Drawing.Size(80, 30);
            this.cmdXoadon.TabIndex = 224;
            this.cmdXoadon.Text = "     &Xóa đơn";
            this.cmdXoadon.UseVisualStyleBackColor = false;
            this.cmdXoadon.Click += new System.EventHandler(this.cmdXoadon_Click);
            // 
            // cmdSuadon
            // 
            this.cmdSuadon.BackColor = System.Drawing.Color.Transparent;
            this.cmdSuadon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSuadon.Image = ((System.Drawing.Image)(resources.GetObject("cmdSuadon.Image")));
            this.cmdSuadon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSuadon.Location = new System.Drawing.Point(89, 510);
            this.cmdSuadon.Name = "cmdSuadon";
            this.cmdSuadon.Size = new System.Drawing.Size(80, 30);
            this.cmdSuadon.TabIndex = 223;
            this.cmdSuadon.Text = "     &Sửa đơn";
            this.cmdSuadon.UseVisualStyleBackColor = false;
            this.cmdSuadon.Click += new System.EventHandler(this.cmdSuadon_Click);
            // 
            // cmdThemdon
            // 
            this.cmdThemdon.BackColor = System.Drawing.Color.Transparent;
            this.cmdThemdon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdThemdon.Image = ((System.Drawing.Image)(resources.GetObject("cmdThemdon.Image")));
            this.cmdThemdon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdThemdon.Location = new System.Drawing.Point(1, 510);
            this.cmdThemdon.Name = "cmdThemdon";
            this.cmdThemdon.Size = new System.Drawing.Size(80, 30);
            this.cmdThemdon.TabIndex = 222;
            this.cmdThemdon.Text = "    &Thêm đơn";
            this.cmdThemdon.UseVisualStyleBackColor = false;
            this.cmdThemdon.Click += new System.EventHandler(this.cmdThemdon_Click);
            // 
            // Label90
            // 
            this.Label90.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Label90.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label90.ForeColor = System.Drawing.Color.Blue;
            this.Label90.Location = new System.Drawing.Point(1, 2);
            this.Label90.Name = "Label90";
            this.Label90.Size = new System.Drawing.Size(256, 21);
            this.Label90.TabIndex = 221;
            this.Label90.Text = "Danh sách các đơn thuốc đã kê";
            this.Label90.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grdDSDonthuoc
            // 
            this.grdDSDonthuoc.AllowEditing = false;
            this.grdDSDonthuoc.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle;
            this.grdDSDonthuoc.ColumnInfo = resources.GetString("grdDSDonthuoc.ColumnInfo");
            this.grdDSDonthuoc.ExtendLastCol = true;
            this.grdDSDonthuoc.Location = new System.Drawing.Point(1, 25);
            this.grdDSDonthuoc.Name = "grdDSDonthuoc";
            this.grdDSDonthuoc.Rows.Count = 1;
            this.grdDSDonthuoc.Size = new System.Drawing.Size(256, 479);
            this.grdDSDonthuoc.Styles = new C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("grdDSDonthuoc.Styles"));
            this.grdDSDonthuoc.TabIndex = 220;
            this.grdDSDonthuoc.Click += new System.EventHandler(this.grdDSDonthuoc_Click);
            // 
            // cmdKhongLuuDonthuoc
            // 
            this.cmdKhongLuuDonthuoc.BackColor = System.Drawing.Color.Transparent;
            this.cmdKhongLuuDonthuoc.Enabled = false;
            this.cmdKhongLuuDonthuoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdKhongLuuDonthuoc.Image = ((System.Drawing.Image)(resources.GetObject("cmdKhongLuuDonthuoc.Image")));
            this.cmdKhongLuuDonthuoc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdKhongLuuDonthuoc.Location = new System.Drawing.Point(746, 510);
            this.cmdKhongLuuDonthuoc.Name = "cmdKhongLuuDonthuoc";
            this.cmdKhongLuuDonthuoc.Size = new System.Drawing.Size(80, 30);
            this.cmdKhongLuuDonthuoc.TabIndex = 228;
            this.cmdKhongLuuDonthuoc.Text = "&Không ghi";
            this.cmdKhongLuuDonthuoc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdKhongLuuDonthuoc.UseVisualStyleBackColor = false;
            this.cmdKhongLuuDonthuoc.Click += new System.EventHandler(this.cmdKhongLuuDonthuoc_Click);
            // 
            // cmdClosepanDonthuoc
            // 
            this.cmdClosepanDonthuoc.BackColor = System.Drawing.Color.Transparent;
            this.cmdClosepanDonthuoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdClosepanDonthuoc.Image = ((System.Drawing.Image)(resources.GetObject("cmdClosepanDonthuoc.Image")));
            this.cmdClosepanDonthuoc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClosepanDonthuoc.Location = new System.Drawing.Point(834, 510);
            this.cmdClosepanDonthuoc.Name = "cmdClosepanDonthuoc";
            this.cmdClosepanDonthuoc.Size = new System.Drawing.Size(64, 30);
            this.cmdClosepanDonthuoc.TabIndex = 227;
            this.cmdClosepanDonthuoc.Text = "Đóng";
            this.cmdClosepanDonthuoc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdClosepanDonthuoc.UseVisualStyleBackColor = false;
            this.cmdClosepanDonthuoc.Click += new System.EventHandler(this.cmdClosepanDonthuoc_Click);
            // 
            // cmdLuu_XemDonthuoc
            // 
            this.cmdLuu_XemDonthuoc.BackColor = System.Drawing.Color.Transparent;
            this.cmdLuu_XemDonthuoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdLuu_XemDonthuoc.Image = ((System.Drawing.Image)(resources.GetObject("cmdLuu_XemDonthuoc.Image")));
            this.cmdLuu_XemDonthuoc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdLuu_XemDonthuoc.Location = new System.Drawing.Point(260, 510);
            this.cmdLuu_XemDonthuoc.Name = "cmdLuu_XemDonthuoc";
            this.cmdLuu_XemDonthuoc.Size = new System.Drawing.Size(96, 30);
            this.cmdLuu_XemDonthuoc.TabIndex = 226;
            this.cmdLuu_XemDonthuoc.Text = "&In đơn thuốc";
            this.cmdLuu_XemDonthuoc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdLuu_XemDonthuoc.UseVisualStyleBackColor = false;
            this.cmdLuu_XemDonthuoc.Click += new System.EventHandler(this.cmdLuu_XemDonthuoc_Click);
            // 
            // cmdLuuDonthuoc
            // 
            this.cmdLuuDonthuoc.BackColor = System.Drawing.Color.Transparent;
            this.cmdLuuDonthuoc.Enabled = false;
            this.cmdLuuDonthuoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdLuuDonthuoc.Image = ((System.Drawing.Image)(resources.GetObject("cmdLuuDonthuoc.Image")));
            this.cmdLuuDonthuoc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdLuuDonthuoc.Location = new System.Drawing.Point(658, 510);
            this.cmdLuuDonthuoc.Name = "cmdLuuDonthuoc";
            this.cmdLuuDonthuoc.Size = new System.Drawing.Size(80, 30);
            this.cmdLuuDonthuoc.TabIndex = 225;
            this.cmdLuuDonthuoc.Text = "   &Ghi lại";
            this.cmdLuuDonthuoc.UseVisualStyleBackColor = false;
            this.cmdLuuDonthuoc.Click += new System.EventHandler(this.cmdLuuDonthuoc_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(260, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 230;
            this.label1.Text = "Bác sĩ:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(641, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 231;
            this.label2.Text = "Thời gian kê:";
            // 
            // txtNgayChiDinh
            // 
            this.txtNgayChiDinh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNgayChiDinh.Culture = 1066;
            this.txtNgayChiDinh.CustomFormat = "dd/MM/yyyy HH:mm";
            this.txtNgayChiDinh.Enabled = false;
            this.txtNgayChiDinh.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
            this.txtNgayChiDinh.Location = new System.Drawing.Point(716, 5);
            this.txtNgayChiDinh.Name = "txtNgayChiDinh";
            this.txtNgayChiDinh.Size = new System.Drawing.Size(133, 18);
            this.txtNgayChiDinh.TabIndex = 232;
            this.txtNgayChiDinh.Tag = null;
            // 
            // cmbBacSi
            // 
            this.cmbBacSi.AddItemSeparator = ';';
            this.cmbBacSi.AllowColMove = false;
            this.cmbBacSi.AllowRowSizing = C1.Win.C1List.RowSizingEnum.AllRows;
            this.cmbBacSi.AutoCompletion = true;
            this.cmbBacSi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cmbBacSi.Caption = "";
            this.cmbBacSi.CaptionHeight = 17;
            this.cmbBacSi.CaptionStyle = style1;
            this.cmbBacSi.CaptionVisible = false;
            this.cmbBacSi.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cmbBacSi.ColumnCaptionHeight = 17;
            this.cmbBacSi.ColumnFooterHeight = 17;
            this.cmbBacSi.ColumnHeaders = false;
            this.cmbBacSi.ContentHeight = 16;
            this.cmbBacSi.DataMode = C1.Win.C1List.DataModeEnum.AddItem;
            this.cmbBacSi.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cmbBacSi.DefColWidth = 30;
            this.cmbBacSi.DisplayMember = "Danh mục";
            this.cmbBacSi.EditorBackColor = System.Drawing.Color.White;
            this.cmbBacSi.EditorFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBacSi.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbBacSi.EditorHeight = 16;
            this.cmbBacSi.Enabled = false;
            this.cmbBacSi.EvenRowStyle = style2;
            this.cmbBacSi.ExtendRightColumn = true;
            this.cmbBacSi.FlatStyle = C1.Win.C1List.FlatModeEnum.Popup;
            this.cmbBacSi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBacSi.FooterStyle = style3;
            this.cmbBacSi.GapHeight = 2;
            this.cmbBacSi.HeadingStyle = style4;
            this.cmbBacSi.HighLightRowStyle = style5;
            this.cmbBacSi.ItemHeight = 15;
            this.cmbBacSi.Location = new System.Drawing.Point(324, 4);
            this.cmbBacSi.MatchCol = C1.Win.C1List.MatchColEnum.AllCols;
            this.cmbBacSi.MatchEntryTimeout = ((long)(2000));
            this.cmbBacSi.MaxDropDownItems = ((short)(10));
            this.cmbBacSi.MaxLength = 32767;
            this.cmbBacSi.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cmbBacSi.Name = "cmbBacSi";
            this.cmbBacSi.OddRowStyle = style6;
            this.cmbBacSi.PartialRightColumn = false;
            this.cmbBacSi.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.cmbBacSi.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.cmbBacSi.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cmbBacSi.SelectedStyle = style7;
            this.cmbBacSi.Size = new System.Drawing.Size(201, 20);
            this.cmbBacSi.Style = style8;
            this.cmbBacSi.TabIndex = 233;
            this.cmbBacSi.PropBag = resources.GetString("cmbBacSi.PropBag");
            // 
            // cmdThem_Thuoc
            // 
            this.cmdThem_Thuoc.BackColor = System.Drawing.Color.Transparent;
            this.cmdThem_Thuoc.Enabled = false;
            this.cmdThem_Thuoc.Image = ((System.Drawing.Image)(resources.GetObject("cmdThem_Thuoc.Image")));
            this.cmdThem_Thuoc.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdThem_Thuoc.Location = new System.Drawing.Point(829, 76);
            this.cmdThem_Thuoc.Name = "cmdThem_Thuoc";
            this.cmdThem_Thuoc.Size = new System.Drawing.Size(72, 44);
            this.cmdThem_Thuoc.TabIndex = 209;
            this.cmdThem_Thuoc.Text = "Thêm thuốc\r\n   \r\n";
            this.cmdThem_Thuoc.UseVisualStyleBackColor = false;
            this.cmdThem_Thuoc.Click += new System.EventHandler(this.cmdThem_Thuoc_Click);
            // 
            // txtTengoc
            // 
            this.txtTengoc.Location = new System.Drawing.Point(59, 234);
            this.txtTengoc.Name = "txtTengoc";
            this.txtTengoc.Size = new System.Drawing.Size(176, 20);
            this.txtTengoc.TabIndex = 235;
            this.txtTengoc.Visible = false;
            // 
            // txtSoluong_Thuoc
            // 
            this.txtSoluong_Thuoc.DataType = typeof(double);
            this.txtSoluong_Thuoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoluong_Thuoc.Location = new System.Drawing.Point(818, 51);
            this.txtSoluong_Thuoc.Name = "txtSoluong_Thuoc";
            this.txtSoluong_Thuoc.Size = new System.Drawing.Size(80, 22);
            this.txtSoluong_Thuoc.TabIndex = 207;
            this.txtSoluong_Thuoc.Tag = null;
            // 
            // Label84
            // 
            this.Label84.AutoSize = true;
            this.Label84.Location = new System.Drawing.Point(762, 54);
            this.Label84.Name = "Label84";
            this.Label84.Size = new System.Drawing.Size(52, 13);
            this.Label84.TabIndex = 237;
            this.Label84.Text = "Số lượng:";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(557, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(271, 17);
            this.label3.TabIndex = 238;
            this.label3.Text = "Nhấn phím Delete để xóa thuốc";
            // 
            // cmbMatBenh
            // 
            this.cmbMatBenh.AddItemSeparator = ';';
            this.cmbMatBenh.AllowColMove = false;
            this.cmbMatBenh.AllowRowSizing = C1.Win.C1List.RowSizingEnum.AllRows;
            this.cmbMatBenh.AutoCompletion = true;
            this.cmbMatBenh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cmbMatBenh.Caption = "";
            this.cmbMatBenh.CaptionHeight = 17;
            this.cmbMatBenh.CaptionStyle = style9;
            this.cmbMatBenh.CaptionVisible = false;
            this.cmbMatBenh.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cmbMatBenh.ColumnCaptionHeight = 17;
            this.cmbMatBenh.ColumnFooterHeight = 17;
            this.cmbMatBenh.ColumnHeaders = false;
            this.cmbMatBenh.ContentHeight = 16;
            this.cmbMatBenh.DataMode = C1.Win.C1List.DataModeEnum.AddItem;
            this.cmbMatBenh.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cmbMatBenh.DefColWidth = 30;
            this.cmbMatBenh.DisplayMember = "Danh mục";
            this.cmbMatBenh.EditorBackColor = System.Drawing.Color.White;
            this.cmbMatBenh.EditorFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMatBenh.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbMatBenh.EditorHeight = 16;
            this.cmbMatBenh.Enabled = false;
            this.cmbMatBenh.EvenRowStyle = style10;
            this.cmbMatBenh.ExtendRightColumn = true;
            this.cmbMatBenh.FlatStyle = C1.Win.C1List.FlatModeEnum.Popup;
            this.cmbMatBenh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMatBenh.FooterStyle = style11;
            this.cmbMatBenh.GapHeight = 2;
            this.cmbMatBenh.HeadingStyle = style12;
            this.cmbMatBenh.HighLightRowStyle = style13;
            this.cmbMatBenh.ItemHeight = 15;
            this.cmbMatBenh.Location = new System.Drawing.Point(324, 28);
            this.cmbMatBenh.MatchCol = C1.Win.C1List.MatchColEnum.AllCols;
            this.cmbMatBenh.MatchEntryTimeout = ((long)(2000));
            this.cmbMatBenh.MaxDropDownItems = ((short)(10));
            this.cmbMatBenh.MaxLength = 32767;
            this.cmbMatBenh.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cmbMatBenh.Name = "cmbMatBenh";
            this.cmbMatBenh.OddRowStyle = style14;
            this.cmbMatBenh.PartialRightColumn = false;
            this.cmbMatBenh.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.cmbMatBenh.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.cmbMatBenh.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cmbMatBenh.SelectedStyle = style15;
            this.cmbMatBenh.Size = new System.Drawing.Size(328, 20);
            this.cmbMatBenh.Style = style16;
            this.cmbMatBenh.TabIndex = 239;
            this.cmbMatBenh.TextChanged += new System.EventHandler(this.cmbMatBenh_TextChanged);
            this.cmbMatBenh.PropBag = resources.GetString("cmbMatBenh.PropBag");
            // 
            // chkSoTay
            // 
            this.chkSoTay.AutoSize = true;
            this.chkSoTay.Enabled = false;
            this.chkSoTay.Location = new System.Drawing.Point(263, 31);
            this.chkSoTay.Name = "chkSoTay";
            this.chkSoTay.Size = new System.Drawing.Size(56, 17);
            this.chkSoTay.TabIndex = 240;
            this.chkSoTay.Text = "Sổ tay";
            this.chkSoTay.UseVisualStyleBackColor = true;
            this.chkSoTay.CheckedChanged += new System.EventHandler(this.chkSoTay_CheckedChanged);
            // 
            // FrmDonThuocRaVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 554);
            this.Controls.Add(this.chkSoTay);
            this.Controls.Add(this.cmbMatBenh);
            this.Controls.Add(this.txtSoluong_Thuoc);
            this.Controls.Add(this.Label84);
            this.Controls.Add(this.txtTengoc);
            this.Controls.Add(this.cmdThem_Thuoc);
            this.Controls.Add(this.cmbBacSi);
            this.Controls.Add(this.txtNgayChiDinh);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdKhongLuuDonthuoc);
            this.Controls.Add(this.cmdClosepanDonthuoc);
            this.Controls.Add(this.cmdLuu_XemDonthuoc);
            this.Controls.Add(this.cmdLuuDonthuoc);
            this.Controls.Add(this.cmdXoadon);
            this.Controls.Add(this.cmdSuadon);
            this.Controls.Add(this.cmdThemdon);
            this.Controls.Add(this.Label90);
            this.Controls.Add(this.grdDSDonthuoc);
            this.Controls.Add(this.grdDMThuoc);
            this.Controls.Add(this.lblChitiet_Donthuoc);
            this.Controls.Add(this.txtLoidan);
            this.Controls.Add(this.Label77);
            this.Controls.Add(this.txtHamluong);
            this.Controls.Add(this.Label33);
            this.Controls.Add(this.Label80);
            this.Controls.Add(this.txtThuoc);
            this.Controls.Add(this.Label81);
            this.Controls.Add(this.grdSoanDonthuoc);
            this.Controls.Add(this.txtCachdung_Thuoc);
            this.Controls.Add(this.txtDVT_Thuoc);
            this.Controls.Add(this.Label85);
            this.Controls.Add(this.label3);
            this.Name = "FrmDonThuocRaVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đơn thuốc ra viện";
            this.Load += new System.EventHandler(this.FrmDonThuocRaVien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdDMThuoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSoanDonthuoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDSDonthuoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNgayChiDinh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBacSi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoluong_Thuoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMatBenh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal C1.Win.C1FlexGrid.C1FlexGrid grdDMThuoc;
        internal System.Windows.Forms.Label lblChitiet_Donthuoc;
        internal System.Windows.Forms.TextBox txtLoidan;
        internal System.Windows.Forms.Label Label77;
        internal System.Windows.Forms.TextBox txtHamluong;
        internal System.Windows.Forms.Label Label33;
        internal System.Windows.Forms.Label Label80;
        internal System.Windows.Forms.TextBox txtThuoc;
        internal System.Windows.Forms.Label Label81;
        internal C1.Win.C1FlexGrid.C1FlexGrid grdSoanDonthuoc;
        internal System.Windows.Forms.TextBox txtCachdung_Thuoc;
        internal System.Windows.Forms.TextBox txtDVT_Thuoc;
        internal System.Windows.Forms.Label Label85;
        internal System.Windows.Forms.Button cmdXoadon;
        internal System.Windows.Forms.Button cmdSuadon;
        internal System.Windows.Forms.Button cmdThemdon;
        internal System.Windows.Forms.Label Label90;
        internal C1.Win.C1FlexGrid.C1FlexGrid grdDSDonthuoc;
        internal System.Windows.Forms.Button cmdKhongLuuDonthuoc;
        internal System.Windows.Forms.Button cmdClosepanDonthuoc;
        internal System.Windows.Forms.Button cmdLuu_XemDonthuoc;
        internal System.Windows.Forms.Button cmdLuuDonthuoc;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label label2;
        private C1.Win.C1Input.C1DateEdit txtNgayChiDinh;
        internal C1.Win.C1List.C1Combo cmbBacSi;
        internal System.Windows.Forms.Button cmdThem_Thuoc;
        internal System.Windows.Forms.TextBox txtTengoc;
        internal C1.Win.C1Input.C1NumericEdit txtSoluong_Thuoc;
        internal System.Windows.Forms.Label Label84;
        internal System.Windows.Forms.Label label3;
        internal C1.Win.C1List.C1Combo cmbMatBenh;
        private System.Windows.Forms.CheckBox chkSoTay;
    }
}