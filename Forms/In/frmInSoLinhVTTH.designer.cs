namespace NamDinh_QLBN.Forms.In
{
    partial class frmInSoLinhVTTH
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInSoLinhVTTH));
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
            this.rdVTTH = new System.Windows.Forms.RadioButton();
            this.raThuocDungChung = new System.Windows.Forms.RadioButton();
            this.fgDanhSach = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.txtNgayChiDinh = new C1.Win.C1Input.C1DateEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbKhoa = new C1.Win.C1List.C1Combo();
            this.label12 = new System.Windows.Forms.Label();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.mcdInSo = new System.Windows.Forms.Button();
            this.cmbNhomLenCP = new C1.Win.C1List.C1Combo();
            this.label14 = new System.Windows.Forms.Label();
            this.btnInNhom = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.fgDanhSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNgayChiDinh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKhoa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbNhomLenCP)).BeginInit();
            this.SuspendLayout();
            // 
            // rdVTTH
            // 
            this.rdVTTH.AutoSize = true;
            this.rdVTTH.Checked = true;
            this.rdVTTH.Location = new System.Drawing.Point(494, 5);
            this.rdVTTH.Name = "rdVTTH";
            this.rdVTTH.Size = new System.Drawing.Size(94, 17);
            this.rdVTTH.TabIndex = 146;
            this.rdVTTH.TabStop = true;
            this.rdVTTH.Text = "Vật tư tiêu hao";
            this.rdVTTH.UseVisualStyleBackColor = true;
            this.rdVTTH.CheckedChanged += new System.EventHandler(this.rdVTTH_CheckedChanged);
            // 
            // raThuocDungChung
            // 
            this.raThuocDungChung.AutoSize = true;
            this.raThuocDungChung.Location = new System.Drawing.Point(494, 29);
            this.raThuocDungChung.Name = "raThuocDungChung";
            this.raThuocDungChung.Size = new System.Drawing.Size(116, 17);
            this.raThuocDungChung.TabIndex = 144;
            this.raThuocDungChung.Text = "Thuốc dùng chung";
            this.raThuocDungChung.UseVisualStyleBackColor = true;
            this.raThuocDungChung.CheckedChanged += new System.EventHandler(this.raThuocDungChung_CheckedChanged);
            // 
            // fgDanhSach
            // 
            this.fgDanhSach.AllowEditing = false;
            this.fgDanhSach.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fgDanhSach.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Light3D;
            this.fgDanhSach.ColumnInfo = resources.GetString("fgDanhSach.ColumnInfo");
            this.fgDanhSach.ExtendLastCol = true;
            this.fgDanhSach.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid;
            this.fgDanhSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fgDanhSach.Location = new System.Drawing.Point(5, 53);
            this.fgDanhSach.Name = "fgDanhSach";
            this.fgDanhSach.Rows.Count = 1;
            this.fgDanhSach.Rows.MinSize = 20;
            this.fgDanhSach.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
            this.fgDanhSach.ShowCursor = true;
            this.fgDanhSach.Size = new System.Drawing.Size(1206, 211);
            this.fgDanhSach.Styles = new C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("fgDanhSach.Styles"));
            this.fgDanhSach.TabIndex = 153;
            // 
            // txtNgayChiDinh
            // 
            this.txtNgayChiDinh.Culture = 1066;
            this.txtNgayChiDinh.CustomFormat = "dd/MM/yyyy";
            this.txtNgayChiDinh.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
            this.txtNgayChiDinh.Location = new System.Drawing.Point(88, 27);
            this.txtNgayChiDinh.Name = "txtNgayChiDinh";
            this.txtNgayChiDinh.Size = new System.Drawing.Size(113, 20);
            this.txtNgayChiDinh.TabIndex = 152;
            this.txtNgayChiDinh.Tag = null;
            this.txtNgayChiDinh.Value = new System.DateTime(2009, 9, 5, 0, 0, 0, 0);
            this.txtNgayChiDinh.ValueChanged += new System.EventHandler(this.txtNgayChiDinh_ValueChanged);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(12, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 18);
            this.label4.TabIndex = 151;
            this.label4.Text = "Ngày chỉ định";
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
            this.cmbKhoa.Location = new System.Drawing.Point(88, 3);
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
            this.cmbKhoa.Size = new System.Drawing.Size(400, 20);
            this.cmbKhoa.Style = style8;
            this.cmbKhoa.TabIndex = 150;
            this.cmbKhoa.PropBag = resources.GetString("cmbKhoa.PropBag");
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(12, 7);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(75, 18);
            this.label12.TabIndex = 149;
            this.label12.Text = "Khoa điều trị";
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Image = ((System.Drawing.Image)(resources.GetObject("cmdCancel.Image")));
            this.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancel.Location = new System.Drawing.Point(1124, 270);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(77, 23);
            this.cmdCancel.TabIndex = 155;
            this.cmdCancel.Text = " Thoát";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // mcdInSo
            // 
            this.mcdInSo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mcdInSo.Image = ((System.Drawing.Image)(resources.GetObject("mcdInSo.Image")));
            this.mcdInSo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mcdInSo.Location = new System.Drawing.Point(616, 2);
            this.mcdInSo.Name = "mcdInSo";
            this.mcdInSo.Size = new System.Drawing.Size(139, 44);
            this.mcdInSo.TabIndex = 156;
            this.mcdInSo.Text = "    In sổ (Tổng hợp  toàn khoa)";
            this.mcdInSo.UseVisualStyleBackColor = true;
            this.mcdInSo.Click += new System.EventHandler(this.btnInSo_Click);
            // 
            // cmbNhomLenCP
            // 
            this.cmbNhomLenCP.AddItemSeparator = ';';
            this.cmbNhomLenCP.AllowColMove = false;
            this.cmbNhomLenCP.AllowRowSizing = C1.Win.C1List.RowSizingEnum.AllRows;
            this.cmbNhomLenCP.AutoCompletion = true;
            this.cmbNhomLenCP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cmbNhomLenCP.Caption = "";
            this.cmbNhomLenCP.CaptionHeight = 17;
            this.cmbNhomLenCP.CaptionStyle = style9;
            this.cmbNhomLenCP.CaptionVisible = false;
            this.cmbNhomLenCP.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cmbNhomLenCP.ColumnCaptionHeight = 17;
            this.cmbNhomLenCP.ColumnFooterHeight = 17;
            this.cmbNhomLenCP.ColumnHeaders = false;
            this.cmbNhomLenCP.ContentHeight = 16;
            this.cmbNhomLenCP.DataMode = C1.Win.C1List.DataModeEnum.AddItem;
            this.cmbNhomLenCP.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cmbNhomLenCP.DefColWidth = 1;
            this.cmbNhomLenCP.DisplayMember = "Danh mục";
            this.cmbNhomLenCP.EditorBackColor = System.Drawing.Color.White;
            this.cmbNhomLenCP.EditorFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbNhomLenCP.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbNhomLenCP.EditorHeight = 16;
            this.cmbNhomLenCP.EvenRowStyle = style10;
            this.cmbNhomLenCP.ExtendRightColumn = true;
            this.cmbNhomLenCP.FlatStyle = C1.Win.C1List.FlatModeEnum.Popup;
            this.cmbNhomLenCP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbNhomLenCP.FooterStyle = style11;
            this.cmbNhomLenCP.GapHeight = 2;
            this.cmbNhomLenCP.HeadingStyle = style12;
            this.cmbNhomLenCP.HighLightRowStyle = style13;
            this.cmbNhomLenCP.ItemHeight = 15;
            this.cmbNhomLenCP.Location = new System.Drawing.Point(279, 27);
            this.cmbNhomLenCP.MatchCol = C1.Win.C1List.MatchColEnum.AllCols;
            this.cmbNhomLenCP.MatchEntryTimeout = ((long)(2000));
            this.cmbNhomLenCP.MaxDropDownItems = ((short)(10));
            this.cmbNhomLenCP.MaxLength = 32767;
            this.cmbNhomLenCP.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cmbNhomLenCP.Name = "cmbNhomLenCP";
            this.cmbNhomLenCP.OddRowStyle = style14;
            this.cmbNhomLenCP.PartialRightColumn = false;
            this.cmbNhomLenCP.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.cmbNhomLenCP.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.cmbNhomLenCP.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cmbNhomLenCP.SelectedStyle = style15;
            this.cmbNhomLenCP.Size = new System.Drawing.Size(209, 20);
            this.cmbNhomLenCP.Style = style16;
            this.cmbNhomLenCP.TabIndex = 202;
            this.cmbNhomLenCP.TextChanged += new System.EventHandler(this.cmbNhomLenCP_TextChanged);
            this.cmbNhomLenCP.PropBag = resources.GetString("cmbNhomLenCP.PropBag");
            // 
            // label14
            // 
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(203, 28);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(81, 18);
            this.label14.TabIndex = 201;
            this.label14.Text = "Tên nhóm CĐ:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnInNhom
            // 
            this.btnInNhom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInNhom.Image = ((System.Drawing.Image)(resources.GetObject("btnInNhom.Image")));
            this.btnInNhom.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInNhom.Location = new System.Drawing.Point(761, 3);
            this.btnInNhom.Name = "btnInNhom";
            this.btnInNhom.Size = new System.Drawing.Size(144, 44);
            this.btnInNhom.TabIndex = 203;
            this.btnInNhom.Text = "    In sổ (Tổng hợp  Theo Nhóm)";
            this.btnInNhom.UseVisualStyleBackColor = true;
            this.btnInNhom.Click += new System.EventHandler(this.btnInNhom_Click);
            // 
            // frmInSoLinhVTTH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1213, 297);
            this.Controls.Add(this.btnInNhom);
            this.Controls.Add(this.cmbNhomLenCP);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.mcdInSo);
            this.Controls.Add(this.rdVTTH);
            this.Controls.Add(this.raThuocDungChung);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.fgDanhSach);
            this.Controls.Add(this.txtNgayChiDinh);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbKhoa);
            this.Controls.Add(this.label12);
            this.Name = "frmInSoLinhVTTH";
            this.Text = "In sổ lĩnh VTTH";
            this.Load += new System.EventHandler(this.frmInSoLinhThuoc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fgDanhSach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNgayChiDinh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKhoa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbNhomLenCP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdVTTH;
        private System.Windows.Forms.RadioButton raThuocDungChung;
        private C1.Win.C1FlexGrid.C1FlexGrid fgDanhSach;
        private C1.Win.C1Input.C1DateEdit txtNgayChiDinh;
        private System.Windows.Forms.Label label4;
        internal C1.Win.C1List.C1Combo cmbKhoa;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button mcdInSo;
        internal C1.Win.C1List.C1Combo cmbNhomLenCP;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnInNhom;
    }
}