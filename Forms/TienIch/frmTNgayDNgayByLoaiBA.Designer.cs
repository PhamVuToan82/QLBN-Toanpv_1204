namespace NamDinh_QLBN.Forms.Tien_ich
{
    partial class frmTNgayDNgayByLoaiBA
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
            C1.Win.C1List.Style style17 = new C1.Win.C1List.Style();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTNgayDNgayByLoaiBA));
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
            this.txtTNgay = new C1.Win.C1Input.C1DateEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbKhoa = new C1.Win.C1List.C1Combo();
            this.label12 = new System.Windows.Forms.Label();
            this.txtDNgay = new C1.Win.C1Input.C1DateEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbLoaiBA = new C1.Win.C1List.C1Combo();
            this.label2 = new System.Windows.Forms.Label();
            this.raDangDT = new System.Windows.Forms.RadioButton();
            this.raRaVien = new System.Windows.Forms.RadioButton();
            this.cmbKhongGhi = new DevExpress.XtraEditors.SimpleButton();
            this.cmdThoat = new DevExpress.XtraEditors.SimpleButton();
            this.raNgayVV = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtTNgay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKhoa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDNgay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLoaiBA)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTNgay
            // 
            this.txtTNgay.Culture = 1066;
            this.txtTNgay.CustomFormat = "dd/MM/yyyy";
            this.txtTNgay.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
            this.txtTNgay.Location = new System.Drawing.Point(61, 83);
            this.txtTNgay.Name = "txtTNgay";
            this.txtTNgay.Size = new System.Drawing.Size(105, 20);
            this.txtTNgay.TabIndex = 4;
            this.txtTNgay.Tag = null;
            this.txtTNgay.Value = new System.DateTime(2008, 9, 5, 14, 35, 26, 218);
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(-1, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 19);
            this.label4.TabIndex = 145;
            this.label4.Text = "Từ ngày";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.cmbKhoa.CaptionStyle = style17;
            this.cmbKhoa.CaptionVisible = false;
            this.cmbKhoa.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cmbKhoa.ColumnCaptionHeight = 17;
            this.cmbKhoa.ColumnFooterHeight = 17;
            this.cmbKhoa.ColumnHeaders = false;
            this.cmbKhoa.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList;
            this.cmbKhoa.ContentHeight = 16;
            this.cmbKhoa.DataMode = C1.Win.C1List.DataModeEnum.AddItem;
            this.cmbKhoa.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cmbKhoa.DefColWidth = 30;
            this.cmbKhoa.DisplayMember = "Danh mục";
            this.cmbKhoa.EditorBackColor = System.Drawing.Color.White;
            this.cmbKhoa.EditorFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbKhoa.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbKhoa.EditorHeight = 16;
            this.cmbKhoa.EvenRowStyle = style18;
            this.cmbKhoa.ExtendRightColumn = true;
            this.cmbKhoa.FlatStyle = C1.Win.C1List.FlatModeEnum.Popup;
            this.cmbKhoa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbKhoa.FooterStyle = style19;
            this.cmbKhoa.GapHeight = 2;
            this.cmbKhoa.HeadingStyle = style20;
            this.cmbKhoa.HighLightRowStyle = style21;
            this.cmbKhoa.ItemHeight = 15;
            this.cmbKhoa.Location = new System.Drawing.Point(73, 12);
            this.cmbKhoa.MatchCol = C1.Win.C1List.MatchColEnum.AllCols;
            this.cmbKhoa.MatchEntryTimeout = ((long)(2000));
            this.cmbKhoa.MaxDropDownItems = ((short)(10));
            this.cmbKhoa.MaxLength = 32767;
            this.cmbKhoa.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cmbKhoa.Name = "cmbKhoa";
            this.cmbKhoa.OddRowStyle = style22;
            this.cmbKhoa.PartialRightColumn = false;
            this.cmbKhoa.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.cmbKhoa.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.cmbKhoa.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cmbKhoa.SelectedStyle = style23;
            this.cmbKhoa.Size = new System.Drawing.Size(268, 20);
            this.cmbKhoa.Style = style24;
            this.cmbKhoa.TabIndex = 0;
            this.cmbKhoa.PropBag = resources.GetString("cmbKhoa.PropBag");
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(37, 13);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(32, 13);
            this.label12.TabIndex = 143;
            this.label12.Text = "Khoa";
            // 
            // txtDNgay
            // 
            this.txtDNgay.Culture = 1066;
            this.txtDNgay.CustomFormat = "dd/MM/yyyy";
            this.txtDNgay.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
            this.txtDNgay.Location = new System.Drawing.Point(238, 84);
            this.txtDNgay.Name = "txtDNgay";
            this.txtDNgay.Size = new System.Drawing.Size(105, 20);
            this.txtDNgay.TabIndex = 5;
            this.txtDNgay.Tag = null;
            this.txtDNgay.Value = new System.DateTime(2008, 9, 5, 14, 35, 26, 218);
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(176, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 19);
            this.label1.TabIndex = 147;
            this.label1.Text = "Đến ngày";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbLoaiBA
            // 
            this.cmbLoaiBA.AddItemSeparator = ';';
            this.cmbLoaiBA.AllowColMove = false;
            this.cmbLoaiBA.AllowRowSizing = C1.Win.C1List.RowSizingEnum.AllRows;
            this.cmbLoaiBA.AutoCompletion = true;
            this.cmbLoaiBA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cmbLoaiBA.Caption = "";
            this.cmbLoaiBA.CaptionHeight = 17;
            this.cmbLoaiBA.CaptionStyle = style25;
            this.cmbLoaiBA.CaptionVisible = false;
            this.cmbLoaiBA.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cmbLoaiBA.ColumnCaptionHeight = 17;
            this.cmbLoaiBA.ColumnFooterHeight = 17;
            this.cmbLoaiBA.ColumnHeaders = false;
            this.cmbLoaiBA.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList;
            this.cmbLoaiBA.ContentHeight = 18;
            this.cmbLoaiBA.DataMode = C1.Win.C1List.DataModeEnum.AddItem;
            this.cmbLoaiBA.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cmbLoaiBA.DefColWidth = 30;
            this.cmbLoaiBA.DisplayMember = "Danh mục";
            this.cmbLoaiBA.EditorBackColor = System.Drawing.Color.White;
            this.cmbLoaiBA.EditorFont = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLoaiBA.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbLoaiBA.EditorHeight = 18;
            this.cmbLoaiBA.EvenRowStyle = style26;
            this.cmbLoaiBA.ExtendRightColumn = true;
            this.cmbLoaiBA.FlatStyle = C1.Win.C1List.FlatModeEnum.Popup;
            this.cmbLoaiBA.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLoaiBA.FooterStyle = style27;
            this.cmbLoaiBA.GapHeight = 2;
            this.cmbLoaiBA.HeadingStyle = style28;
            this.cmbLoaiBA.HighLightRowStyle = style29;
            this.cmbLoaiBA.ItemHeight = 15;
            this.cmbLoaiBA.Location = new System.Drawing.Point(73, 36);
            this.cmbLoaiBA.MatchCol = C1.Win.C1List.MatchColEnum.AllCols;
            this.cmbLoaiBA.MatchEntryTimeout = ((long)(2000));
            this.cmbLoaiBA.MaxDropDownItems = ((short)(10));
            this.cmbLoaiBA.MaxLength = 32767;
            this.cmbLoaiBA.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cmbLoaiBA.Name = "cmbLoaiBA";
            this.cmbLoaiBA.OddRowStyle = style30;
            this.cmbLoaiBA.PartialRightColumn = false;
            this.cmbLoaiBA.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.cmbLoaiBA.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.cmbLoaiBA.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cmbLoaiBA.SelectedStyle = style31;
            this.cmbLoaiBA.Size = new System.Drawing.Size(268, 22);
            this.cmbLoaiBA.Style = style32;
            this.cmbLoaiBA.TabIndex = 1;
            this.cmbLoaiBA.PropBag = resources.GetString("cmbLoaiBA.PropBag");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 151;
            this.label2.Text = "Loại bệnh án";
            // 
            // raDangDT
            // 
            this.raDangDT.AutoSize = true;
            this.raDangDT.Checked = true;
            this.raDangDT.Location = new System.Drawing.Point(56, 62);
            this.raDangDT.Name = "raDangDT";
            this.raDangDT.Size = new System.Drawing.Size(86, 17);
            this.raDangDT.TabIndex = 2;
            this.raDangDT.TabStop = true;
            this.raDangDT.Text = "Đang điều trị";
            this.raDangDT.UseVisualStyleBackColor = true;
            this.raDangDT.CheckedChanged += new System.EventHandler(this.raDangDT_CheckedChanged);
            // 
            // raRaVien
            // 
            this.raRaVien.AutoSize = true;
            this.raRaVien.Location = new System.Drawing.Point(150, 62);
            this.raRaVien.Name = "raRaVien";
            this.raRaVien.Size = new System.Drawing.Size(85, 17);
            this.raRaVien.TabIndex = 3;
            this.raRaVien.Text = "Ngày ra viện";
            this.raRaVien.UseVisualStyleBackColor = true;
            this.raRaVien.CheckedChanged += new System.EventHandler(this.raRaVien_CheckedChanged);
            // 
            // cmbKhongGhi
            // 
            this.cmbKhongGhi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbKhongGhi.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmbKhongGhi.Image = global::NamDinh_QLBN.Properties.Resources._1221111212;
            this.cmbKhongGhi.Location = new System.Drawing.Point(76, 120);
            this.cmbKhongGhi.Name = "cmbKhongGhi";
            this.cmbKhongGhi.Size = new System.Drawing.Size(75, 25);
            this.cmbKhongGhi.TabIndex = 6;
            this.cmbKhongGhi.Text = "Chọn";
            this.cmbKhongGhi.Click += new System.EventHandler(this.cmbKhongGhi_Click);
            // 
            // cmdThoat
            // 
            this.cmdThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdThoat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdThoat.Image = ((System.Drawing.Image)(resources.GetObject("cmdThoat.Image")));
            this.cmdThoat.Location = new System.Drawing.Point(221, 120);
            this.cmdThoat.Name = "cmdThoat";
            this.cmdThoat.Size = new System.Drawing.Size(82, 25);
            this.cmdThoat.TabIndex = 7;
            this.cmdThoat.Text = "Thoát";
            this.cmdThoat.Click += new System.EventHandler(this.cmdThoat_Click);
            // 
            // raNgayVV
            // 
            this.raNgayVV.AutoSize = true;
            this.raNgayVV.Location = new System.Drawing.Point(244, 62);
            this.raNgayVV.Name = "raNgayVV";
            this.raNgayVV.Size = new System.Drawing.Size(94, 17);
            this.raNgayVV.TabIndex = 152;
            this.raNgayVV.Text = "Ngày vào viện";
            this.raNgayVV.UseVisualStyleBackColor = true;
            this.raNgayVV.CheckedChanged += new System.EventHandler(this.raNgayVV_CheckedChanged);
            // 
            // frmTNgayDNgayByLoaiBA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 156);
            this.Controls.Add(this.raNgayVV);
            this.Controls.Add(this.raRaVien);
            this.Controls.Add(this.raDangDT);
            this.Controls.Add(this.cmbLoaiBA);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbKhongGhi);
            this.Controls.Add(this.cmdThoat);
            this.Controls.Add(this.txtDNgay);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTNgay);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbKhoa);
            this.Controls.Add(this.label12);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTNgayDNgayByLoaiBA";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Từ ngày đến ngày";
            this.Load += new System.EventHandler(this.frmTNgayDNgay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtTNgay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKhoa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDNgay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLoaiBA)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private C1.Win.C1Input.C1DateEdit txtTNgay;
        private System.Windows.Forms.Label label4;
        internal C1.Win.C1List.C1Combo cmbKhoa;
        private System.Windows.Forms.Label label12;
        private C1.Win.C1Input.C1DateEdit txtDNgay;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton cmbKhongGhi;
        private DevExpress.XtraEditors.SimpleButton cmdThoat;
        internal C1.Win.C1List.C1Combo cmbLoaiBA;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton raDangDT;
        private System.Windows.Forms.RadioButton raRaVien;
        private System.Windows.Forms.RadioButton raNgayVV;
    }
}