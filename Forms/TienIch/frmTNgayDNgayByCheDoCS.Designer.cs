namespace NamDinh_QLBN.Forms.Tien_ich
{
    partial class frmTNgayDNgayByCheDoCS
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
            C1.Win.C1List.Style style65 = new C1.Win.C1List.Style();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTNgayDNgayByCheDoCS));
            C1.Win.C1List.Style style66 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style67 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style68 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style69 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style70 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style71 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style72 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style73 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style74 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style75 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style76 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style77 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style78 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style79 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style80 = new C1.Win.C1List.Style();
            this.txtTNgay = new C1.Win.C1Input.C1DateEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbKhoa = new C1.Win.C1List.C1Combo();
            this.label12 = new System.Windows.Forms.Label();
            this.txtDNgay = new C1.Win.C1Input.C1DateEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbDoiTuong = new C1.Win.C1List.C1Combo();
            this.label2 = new System.Windows.Forms.Label();
            this.raDangDT = new System.Windows.Forms.RadioButton();
            this.raRaVien = new System.Windows.Forms.RadioButton();
            this.cmbKhongGhi = new DevExpress.XtraEditors.SimpleButton();
            this.cmdThoat = new DevExpress.XtraEditors.SimpleButton();
            this.raVaoVien = new System.Windows.Forms.RadioButton();
            this.raChiDinh = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtTNgay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKhoa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDNgay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDoiTuong)).BeginInit();
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
            this.cmbKhoa.CaptionStyle = style65;
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
            this.cmbKhoa.EvenRowStyle = style66;
            this.cmbKhoa.ExtendRightColumn = true;
            this.cmbKhoa.FlatStyle = C1.Win.C1List.FlatModeEnum.Popup;
            this.cmbKhoa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbKhoa.FooterStyle = style67;
            this.cmbKhoa.GapHeight = 2;
            this.cmbKhoa.HeadingStyle = style68;
            this.cmbKhoa.HighLightRowStyle = style69;
            this.cmbKhoa.ItemHeight = 15;
            this.cmbKhoa.Location = new System.Drawing.Point(65, 12);
            this.cmbKhoa.MatchCol = C1.Win.C1List.MatchColEnum.AllCols;
            this.cmbKhoa.MatchEntryTimeout = ((long)(2000));
            this.cmbKhoa.MaxDropDownItems = ((short)(10));
            this.cmbKhoa.MaxLength = 32767;
            this.cmbKhoa.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cmbKhoa.Name = "cmbKhoa";
            this.cmbKhoa.OddRowStyle = style70;
            this.cmbKhoa.PartialRightColumn = false;
            this.cmbKhoa.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.cmbKhoa.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.cmbKhoa.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cmbKhoa.SelectedStyle = style71;
            this.cmbKhoa.Size = new System.Drawing.Size(292, 20);
            this.cmbKhoa.Style = style72;
            this.cmbKhoa.TabIndex = 0;
            this.cmbKhoa.PropBag = resources.GetString("cmbKhoa.PropBag");
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(32, 13);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(34, 18);
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
            // cmbDoiTuong
            // 
            this.cmbDoiTuong.AddItemSeparator = ';';
            this.cmbDoiTuong.AllowColMove = false;
            this.cmbDoiTuong.AllowRowSizing = C1.Win.C1List.RowSizingEnum.AllRows;
            this.cmbDoiTuong.AutoCompletion = true;
            this.cmbDoiTuong.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cmbDoiTuong.Caption = "";
            this.cmbDoiTuong.CaptionHeight = 17;
            this.cmbDoiTuong.CaptionStyle = style73;
            this.cmbDoiTuong.CaptionVisible = false;
            this.cmbDoiTuong.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cmbDoiTuong.ColumnCaptionHeight = 17;
            this.cmbDoiTuong.ColumnFooterHeight = 17;
            this.cmbDoiTuong.ColumnHeaders = false;
            this.cmbDoiTuong.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList;
            this.cmbDoiTuong.ContentHeight = 18;
            this.cmbDoiTuong.DataMode = C1.Win.C1List.DataModeEnum.AddItem;
            this.cmbDoiTuong.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cmbDoiTuong.DefColWidth = 30;
            this.cmbDoiTuong.DisplayMember = "Danh mục";
            this.cmbDoiTuong.EditorBackColor = System.Drawing.Color.White;
            this.cmbDoiTuong.EditorFont = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDoiTuong.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbDoiTuong.EditorHeight = 18;
            this.cmbDoiTuong.EvenRowStyle = style74;
            this.cmbDoiTuong.ExtendRightColumn = true;
            this.cmbDoiTuong.FlatStyle = C1.Win.C1List.FlatModeEnum.Popup;
            this.cmbDoiTuong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDoiTuong.FooterStyle = style75;
            this.cmbDoiTuong.GapHeight = 2;
            this.cmbDoiTuong.HeadingStyle = style76;
            this.cmbDoiTuong.HighLightRowStyle = style77;
            this.cmbDoiTuong.ItemHeight = 15;
            this.cmbDoiTuong.Location = new System.Drawing.Point(65, 36);
            this.cmbDoiTuong.MatchCol = C1.Win.C1List.MatchColEnum.AllCols;
            this.cmbDoiTuong.MatchEntryTimeout = ((long)(2000));
            this.cmbDoiTuong.MaxDropDownItems = ((short)(10));
            this.cmbDoiTuong.MaxLength = 32767;
            this.cmbDoiTuong.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cmbDoiTuong.Name = "cmbDoiTuong";
            this.cmbDoiTuong.OddRowStyle = style78;
            this.cmbDoiTuong.PartialRightColumn = false;
            this.cmbDoiTuong.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.cmbDoiTuong.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.cmbDoiTuong.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cmbDoiTuong.SelectedStyle = style79;
            this.cmbDoiTuong.Size = new System.Drawing.Size(292, 22);
            this.cmbDoiTuong.Style = style80;
            this.cmbDoiTuong.TabIndex = 1;
            this.cmbDoiTuong.PropBag = resources.GetString("cmbDoiTuong.PropBag");
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 18);
            this.label2.TabIndex = 151;
            this.label2.Text = "Chế độ CS";
            // 
            // raDangDT
            // 
            this.raDangDT.AutoSize = true;
            this.raDangDT.Checked = true;
            this.raDangDT.Location = new System.Drawing.Point(10, 62);
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
            this.raRaVien.Location = new System.Drawing.Point(96, 62);
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
            // raVaoVien
            // 
            this.raVaoVien.AutoSize = true;
            this.raVaoVien.Location = new System.Drawing.Point(183, 62);
            this.raVaoVien.Name = "raVaoVien";
            this.raVaoVien.Size = new System.Drawing.Size(94, 17);
            this.raVaoVien.TabIndex = 152;
            this.raVaoVien.Text = "Ngày vào viện";
            this.raVaoVien.UseVisualStyleBackColor = true;
            this.raVaoVien.CheckedChanged += new System.EventHandler(this.raVaoVien_CheckedChanged);
            // 
            // raChiDinh
            // 
            this.raChiDinh.AutoSize = true;
            this.raChiDinh.Location = new System.Drawing.Point(276, 62);
            this.raChiDinh.Name = "raChiDinh";
            this.raChiDinh.Size = new System.Drawing.Size(91, 17);
            this.raChiDinh.TabIndex = 153;
            this.raChiDinh.Text = "Ngày chỉ định";
            this.raChiDinh.UseVisualStyleBackColor = true;
            this.raChiDinh.CheckedChanged += new System.EventHandler(this.raChiDinh_CheckedChanged);
            // 
            // frmTNgayDNgayByCheDoCS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 156);
            this.Controls.Add(this.raChiDinh);
            this.Controls.Add(this.raVaoVien);
            this.Controls.Add(this.raRaVien);
            this.Controls.Add(this.raDangDT);
            this.Controls.Add(this.cmbDoiTuong);
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
            this.Name = "frmTNgayDNgayByCheDoCS";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Từ ngày đến ngày";
            this.Load += new System.EventHandler(this.frmTNgayDNgay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtTNgay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKhoa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDNgay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDoiTuong)).EndInit();
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
        internal C1.Win.C1List.C1Combo cmbDoiTuong;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton raDangDT;
        private System.Windows.Forms.RadioButton raRaVien;
        private System.Windows.Forms.RadioButton raVaoVien;
        private System.Windows.Forms.RadioButton raChiDinh;
    }
}