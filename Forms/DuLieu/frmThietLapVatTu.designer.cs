namespace NamDinh_QLBN.Forms.DuLieu
{
    partial class frmThietLapVatTu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThietLapVatTu));
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
            this.cmdChonVT = new DevExpress.XtraEditors.SimpleButton();
            this.cmbVatTu = new C1.Win.C1List.C1Combo();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdThoat = new DevExpress.XtraEditors.SimpleButton();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.fg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKhoa)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbVatTu)).BeginInit();
            this.groupBox2.SuspendLayout();
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
            this.fg.Location = new System.Drawing.Point(0, 80);
            this.fg.Name = "fg";
            this.fg.Rows.Count = 1;
            this.fg.Rows.MinSize = 20;
            this.fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
            this.fg.Size = new System.Drawing.Size(803, 279);
            this.fg.Styles = new C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("fg.Styles"));
            this.fg.TabIndex = 126;
            this.fg.BeforeDeleteRow += new C1.Win.C1FlexGrid.RowColEventHandler(this.fg_BeforeDeleteRow);
            this.fg.AfterEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.fg_AfterEdit);
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
            this.cmbKhoa.Location = new System.Drawing.Point(101, 20);
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
            this.label12.Location = new System.Drawing.Point(8, 22);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(43, 18);
            this.label12.TabIndex = 124;
            this.label12.Text = "Khoa";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmdChonVT);
            this.groupBox1.Controls.Add(this.cmbVatTu);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbKhoa);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(803, 80);
            this.groupBox1.TabIndex = 129;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cập nhật vật tư được sử dụng";
            // 
            // cmdChonVT
            // 
            this.cmdChonVT.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdChonVT.Image = ((System.Drawing.Image)(resources.GetObject("cmdChonVT.Image")));
            this.cmdChonVT.Location = new System.Drawing.Point(482, 42);
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
            this.cmbVatTu.AutoDropDown = true;
            this.cmbVatTu.AutoSelect = true;
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
            this.cmbVatTu.Location = new System.Drawing.Point(101, 45);
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
            this.label1.Location = new System.Drawing.Point(5, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 18);
            this.label1.TabIndex = 123;
            this.label1.Text = "Danh sách vật tư";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(3, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 16);
            this.label2.TabIndex = 145;
            this.label2.Text = "Chú ý:";
            // 
            // cmdThoat
            // 
            this.cmdThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdThoat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdThoat.Image = ((System.Drawing.Image)(resources.GetObject("cmdThoat.Image")));
            this.cmdThoat.Location = new System.Drawing.Point(704, 37);
            this.cmdThoat.Name = "cmdThoat";
            this.cmdThoat.Size = new System.Drawing.Size(87, 27);
            this.cmdThoat.TabIndex = 127;
            this.cmdThoat.Text = "Thoát";
            this.cmdThoat.Click += new System.EventHandler(this.cmdThoat_Click);
            this.cmdThoat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmVatTu_KeyDown);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(301, 13);
            this.label3.TabIndex = 146;
            this.label3.Text = "Thêm vật tư để chỉ định cho khoa: Chọn vật tư rồi ấn <Thêm>";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cmdThoat);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 359);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(803, 72);
            this.groupBox2.TabIndex = 147;
            this.groupBox2.TabStop = false;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(57, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(328, 13);
            this.label4.TabIndex = 147;
            this.label4.Text = "Sửa thứ tự nhóm in: sửa trực tiếp trên danh sách, sau đó ấn <Enter>";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(57, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(345, 13);
            this.label5.TabIndex = 148;
            this.label5.Text = "Xóa vật tư không chỉ định: chọn vật tư trong danh sách rồi ấn <Delete>";
            // 
            // frmThietLapVatTu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 431);
            this.Controls.Add(this.fg);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmThietLapVatTu";
            this.Text = "Vật tư tiêu hao";
            this.Load += new System.EventHandler(this.frmVatTu_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmVatTu_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.fg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKhoa)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmbVatTu)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton cmdThoat;
        private C1.Win.C1FlexGrid.C1FlexGrid fg;
        internal C1.Win.C1List.C1Combo cmbKhoa;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.SimpleButton cmdChonVT;
        internal C1.Win.C1List.C1Combo cmbVatTu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}