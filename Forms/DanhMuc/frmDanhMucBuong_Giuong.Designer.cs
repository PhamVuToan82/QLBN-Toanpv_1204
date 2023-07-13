namespace NamDinh_QLBN.Forms.DanhMuc
{
    partial class frmDanhMucBuong_Giuong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDanhMucBuong_Giuong));
            C1.Win.C1List.Style style1 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style2 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style3 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style4 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style5 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style6 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style7 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style8 = new C1.Win.C1List.Style();
            this.fgDanhSach = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.cmbKhoa = new C1.Win.C1List.C1Combo();
            this.label16 = new System.Windows.Forms.Label();
            this.cmdThemBuong = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cmdXoaBuong = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.fgGiuong = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.lblGiuong = new System.Windows.Forms.Label();
            this.cmbThemGiuong = new System.Windows.Forms.Button();
            this.cmdXoaGiuong = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.fgDanhSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKhoa)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fgGiuong)).BeginInit();
            this.SuspendLayout();
            // 
            // fgDanhSach
            // 
            this.fgDanhSach.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.fgDanhSach.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.fgDanhSach.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Light3D;
            this.fgDanhSach.ColumnInfo = resources.GetString("fgDanhSach.ColumnInfo");
            this.fgDanhSach.ExtendLastCol = true;
            this.fgDanhSach.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Inset;
            this.fgDanhSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fgDanhSach.Location = new System.Drawing.Point(2, 26);
            this.fgDanhSach.Name = "fgDanhSach";
            this.fgDanhSach.Rows.Count = 1;
            this.fgDanhSach.Rows.MinSize = 20;
            this.fgDanhSach.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox;
            this.fgDanhSach.ShowCursor = true;
            this.fgDanhSach.Size = new System.Drawing.Size(306, 372);
            this.fgDanhSach.Styles = new C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("fgDanhSach.Styles"));
            this.fgDanhSach.TabIndex = 118;
            this.fgDanhSach.RowColChange += new System.EventHandler(this.fgDanhSach_RowColChange);
            this.fgDanhSach.AfterEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.fgDanhSach_AfterEdit);
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
            this.cmbKhoa.Location = new System.Drawing.Point(80, 3);
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
            this.cmbKhoa.Size = new System.Drawing.Size(228, 20);
            this.cmbKhoa.Style = style8;
            this.cmbKhoa.TabIndex = 117;
            this.cmbKhoa.TextChanged += new System.EventHandler(this.cmbKhoa_TextChanged);
            this.cmbKhoa.PropBag = resources.GetString("cmbKhoa.PropBag");
            // 
            // label16
            // 
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label16.Location = new System.Drawing.Point(2, 6);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(75, 17);
            this.label16.TabIndex = 119;
            this.label16.Text = "Khoa điều trị";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmdThemBuong
            // 
            this.cmdThemBuong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdThemBuong.Image = ((System.Drawing.Image)(resources.GetObject("cmdThemBuong.Image")));
            this.cmdThemBuong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdThemBuong.Location = new System.Drawing.Point(12, 399);
            this.cmdThemBuong.Name = "cmdThemBuong";
            this.cmdThemBuong.Size = new System.Drawing.Size(96, 27);
            this.cmdThemBuong.TabIndex = 120;
            this.cmdThemBuong.Text = "   Thêm buồng";
            this.cmdThemBuong.Click += new System.EventHandler(this.cmdThemBuong_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(709, 399);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(81, 27);
            this.button1.TabIndex = 121;
            this.button1.Text = " Thoát";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmdXoaBuong
            // 
            this.cmdXoaBuong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdXoaBuong.Enabled = false;
            this.cmdXoaBuong.Image = ((System.Drawing.Image)(resources.GetObject("cmdXoaBuong.Image")));
            this.cmdXoaBuong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdXoaBuong.Location = new System.Drawing.Point(212, 399);
            this.cmdXoaBuong.Name = "cmdXoaBuong";
            this.cmdXoaBuong.Size = new System.Drawing.Size(96, 27);
            this.cmdXoaBuong.TabIndex = 122;
            this.cmdXoaBuong.Text = "Xóa buồng";
            this.cmdXoaBuong.Click += new System.EventHandler(this.cmdXoaBuong_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.fgGiuong);
            this.groupBox1.Controls.Add(this.lblGiuong);
            this.groupBox1.Controls.Add(this.cmbThemGiuong);
            this.groupBox1.Controls.Add(this.cmdXoaGiuong);
            this.groupBox1.Location = new System.Drawing.Point(314, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(476, 395);
            this.groupBox1.TabIndex = 123;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Các giường điều trị";
            // 
            // fgGiuong
            // 
            this.fgGiuong.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.fgGiuong.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fgGiuong.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Light3D;
            this.fgGiuong.ColumnInfo = resources.GetString("fgGiuong.ColumnInfo");
            this.fgGiuong.ExtendLastCol = true;
            this.fgGiuong.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid;
            this.fgGiuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fgGiuong.Location = new System.Drawing.Point(0, 15);
            this.fgGiuong.Name = "fgGiuong";
            this.fgGiuong.Rows.Count = 1;
            this.fgGiuong.Rows.MinSize = 20;
            this.fgGiuong.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox;
            this.fgGiuong.ShowCursor = true;
            this.fgGiuong.Size = new System.Drawing.Size(474, 344);
            this.fgGiuong.Styles = new C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("fgGiuong.Styles"));
            this.fgGiuong.TabIndex = 119;
            this.fgGiuong.AfterEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.fgGiuong_AfterEdit);
            // 
            // lblGiuong
            // 
            this.lblGiuong.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGiuong.BackColor = System.Drawing.Color.Teal;
            this.lblGiuong.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblGiuong.ForeColor = System.Drawing.Color.White;
            this.lblGiuong.Location = new System.Drawing.Point(0, 16);
            this.lblGiuong.Name = "lblGiuong";
            this.lblGiuong.Size = new System.Drawing.Size(476, 19);
            this.lblGiuong.TabIndex = 0;
            this.lblGiuong.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbThemGiuong
            // 
            this.cmbThemGiuong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbThemGiuong.Image = ((System.Drawing.Image)(resources.GetObject("cmbThemGiuong.Image")));
            this.cmbThemGiuong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmbThemGiuong.Location = new System.Drawing.Point(6, 363);
            this.cmbThemGiuong.Name = "cmbThemGiuong";
            this.cmbThemGiuong.Size = new System.Drawing.Size(96, 27);
            this.cmbThemGiuong.TabIndex = 123;
            this.cmbThemGiuong.Text = "   Thêm giường";
            this.cmbThemGiuong.Click += new System.EventHandler(this.cmbThemGiuong_Click);
            // 
            // cmdXoaGiuong
            // 
            this.cmdXoaGiuong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdXoaGiuong.Enabled = false;
            this.cmdXoaGiuong.Image = ((System.Drawing.Image)(resources.GetObject("cmdXoaGiuong.Image")));
            this.cmdXoaGiuong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdXoaGiuong.Location = new System.Drawing.Point(374, 363);
            this.cmdXoaGiuong.Name = "cmdXoaGiuong";
            this.cmdXoaGiuong.Size = new System.Drawing.Size(96, 27);
            this.cmdXoaGiuong.TabIndex = 124;
            this.cmdXoaGiuong.Text = "Xóa giường";
            this.cmdXoaGiuong.Click += new System.EventHandler(this.cmdXoaGiuong_Click);
            // 
            // frmDanhMucBuong_Giuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 428);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.fgDanhSach);
            this.Controls.Add(this.cmbKhoa);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.cmdXoaBuong);
            this.Controls.Add(this.cmdThemBuong);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDanhMucBuong_Giuong";
            this.Text = "Danh mục buồng, giường bệnh";
            this.Load += new System.EventHandler(this.frmDanhMucBuong_Giuong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fgDanhSach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKhoa)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fgGiuong)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private C1.Win.C1FlexGrid.C1FlexGrid fgDanhSach;
        internal C1.Win.C1List.C1Combo cmbKhoa;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button cmdThemBuong;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button cmdXoaBuong;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblGiuong;
        private C1.Win.C1FlexGrid.C1FlexGrid fgGiuong;
        private System.Windows.Forms.Button cmdXoaGiuong;
        private System.Windows.Forms.Button cmbThemGiuong;
    }
}