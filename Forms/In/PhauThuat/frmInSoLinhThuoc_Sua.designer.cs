namespace NamDinh_QLBN.Forms.In.PhauThuat
{
    partial class frmInSoLinhThuoc_Sua
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInSoLinhThuoc_Sua));
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
            this.raThuocVien = new System.Windows.Forms.RadioButton();
            this.raThuocOng = new System.Windows.Forms.RadioButton();
            this.fgDanhSach = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.txtNgayChiDinh = new C1.Win.C1Input.C1DateEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbKhoa = new C1.Win.C1List.C1Combo();
            this.label12 = new System.Windows.Forms.Label();
            this.raTaCa = new System.Windows.Forms.RadioButton();
            this.cmbNhom_Khoa = new C1.Win.C1List.C1Combo();
            this.btnNhom_khoa = new System.Windows.Forms.Button();
            this.mcdInSo = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.fgDanhSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNgayChiDinh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKhoa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbNhom_Khoa)).BeginInit();
            this.SuspendLayout();
            // 
            // raThuocVien
            // 
            this.raThuocVien.AutoSize = true;
            this.raThuocVien.Location = new System.Drawing.Point(282, 30);
            this.raThuocVien.Name = "raThuocVien";
            this.raThuocVien.Size = new System.Drawing.Size(79, 17);
            this.raThuocVien.TabIndex = 146;
            this.raThuocVien.Text = "Thuốc viên";
            this.raThuocVien.UseVisualStyleBackColor = true;
            this.raThuocVien.CheckedChanged += new System.EventHandler(this.raThuocVien_CheckedChanged);
            // 
            // raThuocOng
            // 
            this.raThuocOng.AutoSize = true;
            this.raThuocOng.Checked = true;
            this.raThuocOng.Location = new System.Drawing.Point(204, 29);
            this.raThuocOng.Name = "raThuocOng";
            this.raThuocOng.Size = new System.Drawing.Size(77, 17);
            this.raThuocOng.TabIndex = 144;
            this.raThuocOng.TabStop = true;
            this.raThuocOng.Text = "Thuốc ống";
            this.raThuocOng.UseVisualStyleBackColor = true;
            this.raThuocOng.CheckedChanged += new System.EventHandler(this.raThuocOng_CheckedChanged);
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
            this.fgDanhSach.Size = new System.Drawing.Size(1025, 211);
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
            this.txtNgayChiDinh.TextChanged += new System.EventHandler(this.txtNgayChiDinh_TextChanged_1);
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
            // raTaCa
            // 
            this.raTaCa.AutoSize = true;
            this.raTaCa.Location = new System.Drawing.Point(366, 29);
            this.raTaCa.Name = "raTaCa";
            this.raTaCa.Size = new System.Drawing.Size(122, 17);
            this.raTaCa.TabIndex = 157;
            this.raTaCa.Text = "In chung vào một sổ";
            this.raTaCa.UseVisualStyleBackColor = true;
            this.raTaCa.CheckedChanged += new System.EventHandler(this.raTaCa_CheckedChanged);
            // 
            // cmbNhom_Khoa
            // 
            this.cmbNhom_Khoa.AddItemSeparator = ';';
            this.cmbNhom_Khoa.AllowColMove = false;
            this.cmbNhom_Khoa.AllowRowSizing = C1.Win.C1List.RowSizingEnum.AllRows;
            this.cmbNhom_Khoa.AutoCompletion = true;
            this.cmbNhom_Khoa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cmbNhom_Khoa.Caption = "";
            this.cmbNhom_Khoa.CaptionHeight = 17;
            this.cmbNhom_Khoa.CaptionStyle = style9;
            this.cmbNhom_Khoa.CaptionVisible = false;
            this.cmbNhom_Khoa.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cmbNhom_Khoa.ColumnCaptionHeight = 17;
            this.cmbNhom_Khoa.ColumnFooterHeight = 17;
            this.cmbNhom_Khoa.ColumnHeaders = false;
            this.cmbNhom_Khoa.ContentHeight = 16;
            this.cmbNhom_Khoa.DataMode = C1.Win.C1List.DataModeEnum.AddItem;
            this.cmbNhom_Khoa.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cmbNhom_Khoa.DefColWidth = 30;
            this.cmbNhom_Khoa.DisplayMember = "Danh mục";
            this.cmbNhom_Khoa.EditorBackColor = System.Drawing.Color.White;
            this.cmbNhom_Khoa.EditorFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbNhom_Khoa.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbNhom_Khoa.EditorHeight = 16;
            this.cmbNhom_Khoa.EvenRowStyle = style10;
            this.cmbNhom_Khoa.ExtendRightColumn = true;
            this.cmbNhom_Khoa.FlatStyle = C1.Win.C1List.FlatModeEnum.Popup;
            this.cmbNhom_Khoa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbNhom_Khoa.FooterStyle = style11;
            this.cmbNhom_Khoa.GapHeight = 2;
            this.cmbNhom_Khoa.HeadingStyle = style12;
            this.cmbNhom_Khoa.HighLightRowStyle = style13;
            this.cmbNhom_Khoa.ItemHeight = 15;
            this.cmbNhom_Khoa.Location = new System.Drawing.Point(588, 22);
            this.cmbNhom_Khoa.MatchCol = C1.Win.C1List.MatchColEnum.AllCols;
            this.cmbNhom_Khoa.MatchEntryTimeout = ((long)(2000));
            this.cmbNhom_Khoa.MaxDropDownItems = ((short)(10));
            this.cmbNhom_Khoa.MaxLength = 32767;
            this.cmbNhom_Khoa.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cmbNhom_Khoa.Name = "cmbNhom_Khoa";
            this.cmbNhom_Khoa.OddRowStyle = style14;
            this.cmbNhom_Khoa.PartialRightColumn = false;
            this.cmbNhom_Khoa.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.cmbNhom_Khoa.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.cmbNhom_Khoa.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cmbNhom_Khoa.SelectedStyle = style15;
            this.cmbNhom_Khoa.Size = new System.Drawing.Size(278, 20);
            this.cmbNhom_Khoa.Style = style16;
            this.cmbNhom_Khoa.TabIndex = 158;
            this.cmbNhom_Khoa.PropBag = resources.GetString("cmbNhom_Khoa.PropBag");
            // 
            // btnNhom_khoa
            // 
            this.btnNhom_khoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNhom_khoa.Image = ((System.Drawing.Image)(resources.GetObject("btnNhom_khoa.Image")));
            this.btnNhom_khoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNhom_khoa.Location = new System.Drawing.Point(872, 2);
            this.btnNhom_khoa.Name = "btnNhom_khoa";
            this.btnNhom_khoa.Size = new System.Drawing.Size(134, 44);
            this.btnNhom_khoa.TabIndex = 159;
            this.btnNhom_khoa.Text = "In Theo PM";
            this.btnNhom_khoa.UseVisualStyleBackColor = true;
            this.btnNhom_khoa.Click += new System.EventHandler(this.btnNhom_khoa_Click);
            // 
            // mcdInSo
            // 
            this.mcdInSo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mcdInSo.Image = ((System.Drawing.Image)(resources.GetObject("mcdInSo.Image")));
            this.mcdInSo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mcdInSo.Location = new System.Drawing.Point(494, 3);
            this.mcdInSo.Name = "mcdInSo";
            this.mcdInSo.Size = new System.Drawing.Size(88, 44);
            this.mcdInSo.TabIndex = 156;
            this.mcdInSo.Text = "    In sỗ";
            this.mcdInSo.UseVisualStyleBackColor = true;
            this.mcdInSo.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Image = ((System.Drawing.Image)(resources.GetObject("cmdCancel.Image")));
            this.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancel.Location = new System.Drawing.Point(919, 270);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(77, 23);
            this.cmdCancel.TabIndex = 155;
            this.cmdCancel.Text = " Thoát";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(588, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 18);
            this.label1.TabIndex = 160;
            this.label1.Text = "PHÒNG MỔ";
            // 
            // frmInSoLinhThuoc_Sua
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 297);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnNhom_khoa);
            this.Controls.Add(this.cmbNhom_Khoa);
            this.Controls.Add(this.raTaCa);
            this.Controls.Add(this.mcdInSo);
            this.Controls.Add(this.raThuocVien);
            this.Controls.Add(this.raThuocOng);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.fgDanhSach);
            this.Controls.Add(this.txtNgayChiDinh);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbKhoa);
            this.Controls.Add(this.label12);
            this.Name = "frmInSoLinhThuoc_Sua";
            this.Text = "In sổ lĩnh thuốc";
            this.Load += new System.EventHandler(this.frmInSoLinhThuoc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fgDanhSach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNgayChiDinh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKhoa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbNhom_Khoa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton raThuocVien;
        private System.Windows.Forms.RadioButton raThuocOng;
        private C1.Win.C1FlexGrid.C1FlexGrid fgDanhSach;
        private C1.Win.C1Input.C1DateEdit txtNgayChiDinh;
        private System.Windows.Forms.Label label4;
        internal C1.Win.C1List.C1Combo cmbKhoa;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button mcdInSo;
        private System.Windows.Forms.RadioButton raTaCa;
        internal C1.Win.C1List.C1Combo cmbNhom_Khoa;
        private System.Windows.Forms.Button btnNhom_khoa;
        private System.Windows.Forms.Label label1;
    }
}