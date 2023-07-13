namespace NamDinh_QLBN.Forms.DanhMuc
{
    partial class frmSoTayDichVu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSoTayDichVu));
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
            this.label1 = new System.Windows.Forms.Label();
            this.fgDonThuoc = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmdXoa = new System.Windows.Forms.Button();
            this.cmdThem = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cmdSua = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.txtTenDonThuoc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblIs_tinhphi = new System.Windows.Forms.Label();
            this.cmbLoaiDichVu = new C1.Win.C1List.C1Combo();
            this.label6 = new System.Windows.Forms.Label();
            this.LblLoaiDichVu = new System.Windows.Forms.Label();
            this.txtTenDV = new System.Windows.Forms.TextBox();
            this.fgdmThuoc = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.lblMadichvu = new System.Windows.Forms.Label();
            this.cmdChon = new DevExpress.XtraEditors.SimpleButton();
            this.S = new System.Windows.Forms.Label();
            this.txtSoLuong = new C1.Win.C1Input.C1NumericEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.fgThuoc = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.cmbKhoa = new C1.Win.C1List.C1Combo();
            this.label12 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.fgDonThuoc)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLoaiDichVu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fgdmThuoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fgThuoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKhoa)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.LightBlue;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(-2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(976, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "SỔ TAY XÉT NGHIỆM";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fgDonThuoc
            // 
            this.fgDonThuoc.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.fgDonThuoc.AllowEditing = false;
            this.fgDonThuoc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.fgDonThuoc.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Light3D;
            this.fgDonThuoc.ColumnInfo = resources.GetString("fgDonThuoc.ColumnInfo");
            this.fgDonThuoc.ExtendLastCol = true;
            this.fgDonThuoc.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid;
            this.fgDonThuoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fgDonThuoc.HighLight = C1.Win.C1FlexGrid.HighLightEnum.WithFocus;
            this.fgDonThuoc.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.fgDonThuoc.Location = new System.Drawing.Point(4, 17);
            this.fgDonThuoc.Name = "fgDonThuoc";
            this.fgDonThuoc.Rows.Count = 1;
            this.fgDonThuoc.Rows.MinSize = 20;
            this.fgDonThuoc.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
            this.fgDonThuoc.ShowCursor = true;
            this.fgDonThuoc.Size = new System.Drawing.Size(385, 399);
            this.fgDonThuoc.Styles = new C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("fgDonThuoc.Styles"));
            this.fgDonThuoc.TabIndex = 121;
            this.fgDonThuoc.AfterRowColChange += new C1.Win.C1FlexGrid.RangeEventHandler(this.fgDonThuoc_AfterRowColChange);
            this.fgDonThuoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSoTayDonThuoc_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmdXoa);
            this.groupBox1.Controls.Add(this.cmdThem);
            this.groupBox1.Controls.Add(this.cmdCancel);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.cmdSua);
            this.groupBox1.Controls.Add(this.cmdOK);
            this.groupBox1.Controls.Add(this.txtTenDonThuoc);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.fgDonThuoc);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(392, 490);
            this.groupBox1.TabIndex = 122;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách mặt bệnh";
            // 
            // cmdXoa
            // 
            this.cmdXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdXoa.Image = ((System.Drawing.Image)(resources.GetObject("cmdXoa.Image")));
            this.cmdXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdXoa.Location = new System.Drawing.Point(163, 458);
            this.cmdXoa.Name = "cmdXoa";
            this.cmdXoa.Size = new System.Drawing.Size(69, 27);
            this.cmdXoa.TabIndex = 127;
            this.cmdXoa.Text = "  Xóa";
            this.cmdXoa.Click += new System.EventHandler(this.cmdXoa_Click);
            // 
            // cmdThem
            // 
            this.cmdThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdThem.Image = ((System.Drawing.Image)(resources.GetObject("cmdThem.Image")));
            this.cmdThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdThem.Location = new System.Drawing.Point(1, 458);
            this.cmdThem.Name = "cmdThem";
            this.cmdThem.Size = new System.Drawing.Size(69, 27);
            this.cmdThem.TabIndex = 126;
            this.cmdThem.Text = "  Thêm";
            this.cmdThem.Click += new System.EventHandler(this.cmdThem_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCancel.Image = ((System.Drawing.Image)(resources.GetObject("cmdCancel.Image")));
            this.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancel.Location = new System.Drawing.Point(199, 458);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(86, 27);
            this.cmdCancel.TabIndex = 129;
            this.cmdCancel.Text = "     Không ghi";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(313, 458);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(69, 27);
            this.button1.TabIndex = 124;
            this.button1.Text = " Thoát";
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // cmdSua
            // 
            this.cmdSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSua.Image = ((System.Drawing.Image)(resources.GetObject("cmdSua.Image")));
            this.cmdSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSua.Location = new System.Drawing.Point(73, 458);
            this.cmdSua.Name = "cmdSua";
            this.cmdSua.Size = new System.Drawing.Size(69, 27);
            this.cmdSua.TabIndex = 125;
            this.cmdSua.Text = "  Sửa";
            this.cmdSua.Click += new System.EventHandler(this.cmdSua_Click);
            // 
            // cmdOK
            // 
            this.cmdOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdOK.Image = ((System.Drawing.Image)(resources.GetObject("cmdOK.Image")));
            this.cmdOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdOK.Location = new System.Drawing.Point(112, 458);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(81, 27);
            this.cmdOK.TabIndex = 128;
            this.cmdOK.Text = "  Ghi lại";
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // txtTenDonThuoc
            // 
            this.txtTenDonThuoc.Location = new System.Drawing.Point(93, 425);
            this.txtTenDonThuoc.MaxLength = 50;
            this.txtTenDonThuoc.Name = "txtTenDonThuoc";
            this.txtTenDonThuoc.Size = new System.Drawing.Size(294, 22);
            this.txtTenDonThuoc.TabIndex = 123;
            this.txtTenDonThuoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSoTayDonThuoc_KeyDown);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(5, 428);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 18);
            this.label3.TabIndex = 122;
            this.label3.Text = "Tên mẩu đơn";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblIs_tinhphi);
            this.groupBox2.Controls.Add(this.cmbLoaiDichVu);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.LblLoaiDichVu);
            this.groupBox2.Controls.Add(this.txtTenDV);
            this.groupBox2.Controls.Add(this.fgdmThuoc);
            this.groupBox2.Controls.Add(this.lblMadichvu);
            this.groupBox2.Controls.Add(this.cmdChon);
            this.groupBox2.Controls.Add(this.S);
            this.groupBox2.Controls.Add(this.txtSoLuong);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.fgThuoc);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(398, 42);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(576, 488);
            this.groupBox2.TabIndex = 123;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh xét nghiệm";
            // 
            // lblIs_tinhphi
            // 
            this.lblIs_tinhphi.AutoSize = true;
            this.lblIs_tinhphi.Enabled = false;
            this.lblIs_tinhphi.Location = new System.Drawing.Point(522, -4);
            this.lblIs_tinhphi.Name = "lblIs_tinhphi";
            this.lblIs_tinhphi.Size = new System.Drawing.Size(45, 16);
            this.lblIs_tinhphi.TabIndex = 149;
            this.lblIs_tinhphi.Text = "label9";
            this.lblIs_tinhphi.Visible = false;
            // 
            // cmbLoaiDichVu
            // 
            this.cmbLoaiDichVu.AddItemSeparator = ';';
            this.cmbLoaiDichVu.AllowColMove = false;
            this.cmbLoaiDichVu.AllowRowSizing = C1.Win.C1List.RowSizingEnum.AllRows;
            this.cmbLoaiDichVu.AutoCompletion = true;
            this.cmbLoaiDichVu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cmbLoaiDichVu.Caption = "";
            this.cmbLoaiDichVu.CaptionHeight = 17;
            this.cmbLoaiDichVu.CaptionStyle = style17;
            this.cmbLoaiDichVu.CaptionVisible = false;
            this.cmbLoaiDichVu.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cmbLoaiDichVu.ColumnCaptionHeight = 17;
            this.cmbLoaiDichVu.ColumnFooterHeight = 17;
            this.cmbLoaiDichVu.ColumnHeaders = false;
            this.cmbLoaiDichVu.ContentHeight = 16;
            this.cmbLoaiDichVu.DataMode = C1.Win.C1List.DataModeEnum.AddItem;
            this.cmbLoaiDichVu.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cmbLoaiDichVu.DefColWidth = 30;
            this.cmbLoaiDichVu.DisplayMember = "Danh mục";
            this.cmbLoaiDichVu.EditorBackColor = System.Drawing.Color.White;
            this.cmbLoaiDichVu.EditorFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLoaiDichVu.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbLoaiDichVu.EditorHeight = 16;
            this.cmbLoaiDichVu.EvenRowStyle = style18;
            this.cmbLoaiDichVu.ExtendRightColumn = true;
            this.cmbLoaiDichVu.FlatStyle = C1.Win.C1List.FlatModeEnum.Popup;
            this.cmbLoaiDichVu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLoaiDichVu.FooterStyle = style19;
            this.cmbLoaiDichVu.GapHeight = 2;
            this.cmbLoaiDichVu.HeadingStyle = style20;
            this.cmbLoaiDichVu.HighLightRowStyle = style21;
            this.cmbLoaiDichVu.ItemHeight = 15;
            this.cmbLoaiDichVu.Location = new System.Drawing.Point(57, 21);
            this.cmbLoaiDichVu.MatchCol = C1.Win.C1List.MatchColEnum.AllCols;
            this.cmbLoaiDichVu.MatchEntryTimeout = ((long)(2000));
            this.cmbLoaiDichVu.MaxDropDownItems = ((short)(10));
            this.cmbLoaiDichVu.MaxLength = 32767;
            this.cmbLoaiDichVu.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cmbLoaiDichVu.Name = "cmbLoaiDichVu";
            this.cmbLoaiDichVu.OddRowStyle = style22;
            this.cmbLoaiDichVu.PartialRightColumn = false;
            this.cmbLoaiDichVu.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.cmbLoaiDichVu.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.cmbLoaiDichVu.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cmbLoaiDichVu.SelectedStyle = style23;
            this.cmbLoaiDichVu.Size = new System.Drawing.Size(317, 20);
            this.cmbLoaiDichVu.Style = style24;
            this.cmbLoaiDichVu.TabIndex = 146;
            this.cmbLoaiDichVu.PropBag = resources.GetString("cmbLoaiDichVu.PropBag");
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(3, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 18);
            this.label6.TabIndex = 145;
            this.label6.Text = "Loại DV";
            // 
            // LblLoaiDichVu
            // 
            this.LblLoaiDichVu.AutoSize = true;
            this.LblLoaiDichVu.Enabled = false;
            this.LblLoaiDichVu.Location = new System.Drawing.Point(471, -3);
            this.LblLoaiDichVu.Name = "LblLoaiDichVu";
            this.LblLoaiDichVu.Size = new System.Drawing.Size(45, 16);
            this.LblLoaiDichVu.TabIndex = 148;
            this.LblLoaiDichVu.Text = "label8";
            this.LblLoaiDichVu.Visible = false;
            // 
            // txtTenDV
            // 
            this.txtTenDV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTenDV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenDV.Location = new System.Drawing.Point(57, 44);
            this.txtTenDV.Name = "txtTenDV";
            this.txtTenDV.Size = new System.Drawing.Size(513, 22);
            this.txtTenDV.TabIndex = 144;
            this.txtTenDV.TextChanged += new System.EventHandler(this.txtTenDV_TextChanged);
            this.txtTenDV.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTenDV_KeyDown);
            // 
            // fgdmThuoc
            // 
            this.fgdmThuoc.AllowEditing = false;
            this.fgdmThuoc.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle;
            this.fgdmThuoc.ColumnInfo = resources.GetString("fgdmThuoc.ColumnInfo");
            this.fgdmThuoc.ExtendLastCol = true;
            this.fgdmThuoc.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.fgdmThuoc.Location = new System.Drawing.Point(57, 68);
            this.fgdmThuoc.Name = "fgdmThuoc";
            this.fgdmThuoc.Rows.Count = 1;
            this.fgdmThuoc.Rows.MinSize = 20;
            this.fgdmThuoc.Size = new System.Drawing.Size(513, 326);
            this.fgdmThuoc.Styles = new C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("fgdmThuoc.Styles"));
            this.fgdmThuoc.TabIndex = 143;
            this.fgdmThuoc.Visible = false;
            this.fgdmThuoc.AfterRowColChange += new C1.Win.C1FlexGrid.RangeEventHandler(this.fgdmThuoc_AfterRowColChange);
            this.fgdmThuoc.DoubleClick += new System.EventHandler(this.fgdmThuoc_DoubleClick);
            this.fgdmThuoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fgdmThuoc_KeyDown);
            // 
            // lblMadichvu
            // 
            this.lblMadichvu.AutoSize = true;
            this.lblMadichvu.Enabled = false;
            this.lblMadichvu.Location = new System.Drawing.Point(421, -2);
            this.lblMadichvu.Name = "lblMadichvu";
            this.lblMadichvu.Size = new System.Drawing.Size(45, 16);
            this.lblMadichvu.TabIndex = 147;
            this.lblMadichvu.Text = "label7";
            this.lblMadichvu.Visible = false;
            // 
            // cmdChon
            // 
            this.cmdChon.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdChon.Image = ((System.Drawing.Image)(resources.GetObject("cmdChon.Image")));
            this.cmdChon.Location = new System.Drawing.Point(505, 17);
            this.cmdChon.Name = "cmdChon";
            this.cmdChon.Size = new System.Drawing.Size(65, 26);
            this.cmdChon.Style = new DevExpress.Utils.ViewStyle("ControlStyle", null, new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))), "", DevExpress.Utils.StyleOptions.StyleEnabled, true, false, false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.SystemColors.Control, System.Drawing.SystemColors.ControlText);
            this.cmdChon.TabIndex = 129;
            this.cmdChon.Text = " [F5]";
            this.cmdChon.Visible = false;
            this.cmdChon.Click += new System.EventHandler(this.cmdChon_Click);
            // 
            // S
            // 
            this.S.Location = new System.Drawing.Point(421, 22);
            this.S.Name = "S";
            this.S.Size = new System.Drawing.Size(26, 18);
            this.S.TabIndex = 128;
            this.S.Text = "SL";
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(450, 20);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(51, 22);
            this.txtSoLuong.TabIndex = 127;
            this.txtSoLuong.Tag = null;
            this.txtSoLuong.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtSoLuong.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.UpDown;
            this.txtSoLuong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSoTayDonThuoc_KeyDown);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 18);
            this.label2.TabIndex = 125;
            this.label2.Text = "Tên CP";
            // 
            // fgThuoc
            // 
            this.fgThuoc.AllowDelete = true;
            this.fgThuoc.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.fgThuoc.AllowEditing = false;
            this.fgThuoc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.fgThuoc.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Light3D;
            this.fgThuoc.ColumnInfo = resources.GetString("fgThuoc.ColumnInfo");
            this.fgThuoc.ExtendLastCol = true;
            this.fgThuoc.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid;
            this.fgThuoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fgThuoc.HighLight = C1.Win.C1FlexGrid.HighLightEnum.WithFocus;
            this.fgThuoc.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.fgThuoc.Location = new System.Drawing.Point(4, 68);
            this.fgThuoc.Name = "fgThuoc";
            this.fgThuoc.Rows.Count = 1;
            this.fgThuoc.Rows.MinSize = 20;
            this.fgThuoc.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
            this.fgThuoc.ShowCursor = true;
            this.fgThuoc.Size = new System.Drawing.Size(571, 416);
            this.fgThuoc.Styles = new C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("fgThuoc.Styles"));
            this.fgThuoc.TabIndex = 121;
            this.fgThuoc.BeforeDeleteRow += new C1.Win.C1FlexGrid.RowColEventHandler(this.fgThuoc_BeforeDeleteRow);
            this.fgThuoc.AfterDeleteRow += new C1.Win.C1FlexGrid.RowColEventHandler(this.fgThuoc_AfterDeleteRow);
            this.fgThuoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSoTayDonThuoc_KeyDown);
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
            this.cmbKhoa.Location = new System.Drawing.Point(45, 41);
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
            this.cmbKhoa.Size = new System.Drawing.Size(346, 20);
            this.cmbKhoa.Style = style32;
            this.cmbKhoa.TabIndex = 127;
            this.cmbKhoa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSoTayDonThuoc_KeyDown);
            this.cmbKhoa.PropBag = resources.GetString("cmbKhoa.PropBag");
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(7, 42);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(60, 18);
            this.label12.TabIndex = 126;
            this.label12.Text = "Khoa";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(753, 539);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(212, 13);
            this.label4.TabIndex = 148;
            this.label4.Text = "Nhấn nút Delete đễ xóa vật tư không đúng";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(712, 537);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 16);
            this.label5.TabIndex = 147;
            this.label5.Text = "Chú ý:";
            // 
            // frmSoTayDichVu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 559);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbKhoa);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "frmSoTayDichVu";
            this.Text = "Sổ tay xét nghiệm";
            this.Load += new System.EventHandler(this.frmSoTayDonThuoc_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSoTayDonThuoc_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.fgDonThuoc)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLoaiDichVu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fgdmThuoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fgThuoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKhoa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private C1.Win.C1FlexGrid.C1FlexGrid fgDonThuoc;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private C1.Win.C1FlexGrid.C1FlexGrid fgThuoc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTenDonThuoc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cmdXoa;
        private System.Windows.Forms.Button cmdThem;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button cmdSua;
        private System.Windows.Forms.Button cmdOK;
        private C1.Win.C1Input.C1NumericEdit txtSoLuong;
        private System.Windows.Forms.Label S;
        private DevExpress.XtraEditors.SimpleButton cmdChon;
        internal C1.Win.C1List.C1Combo cmbKhoa;
        private System.Windows.Forms.Label label12;
        internal C1.Win.C1FlexGrid.C1FlexGrid fgdmThuoc;
        private System.Windows.Forms.TextBox txtTenDV;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        internal C1.Win.C1List.C1Combo cmbLoaiDichVu;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblIs_tinhphi;
        private System.Windows.Forms.Label LblLoaiDichVu;
        private System.Windows.Forms.Label lblMadichvu;
    }
}