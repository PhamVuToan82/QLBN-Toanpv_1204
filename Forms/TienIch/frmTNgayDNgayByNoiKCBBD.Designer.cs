namespace NamDinh_QLBN.Forms.Tien_ich
{
    partial class frmTNgayDNgayByNoiKCBBD
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
            C1.Win.C1List.Style style9 = new C1.Win.C1List.Style();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTNgayDNgayByNoiKCBBD));
            C1.Win.C1List.Style style10 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style11 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style12 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style13 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style14 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style15 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style16 = new C1.Win.C1List.Style();
            this.txtTNgay = new C1.Win.C1Input.C1DateEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbKhoa = new C1.Win.C1List.C1Combo();
            this.label12 = new System.Windows.Forms.Label();
            this.txtDNgay = new C1.Win.C1Input.C1DateEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.raDangDT = new System.Windows.Forms.RadioButton();
            this.raRaVien = new System.Windows.Forms.RadioButton();
            this.cmbKhongGhi = new DevExpress.XtraEditors.SimpleButton();
            this.cmdThoat = new DevExpress.XtraEditors.SimpleButton();
            this.raVaoVien = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDen = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTu = new System.Windows.Forms.MaskedTextBox();
            this.raTatCa = new System.Windows.Forms.RadioButton();
            this.raTrongKhoang = new System.Windows.Forms.RadioButton();
            this.raTrongHuyen = new System.Windows.Forms.RadioButton();
            this.raBVTinh = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtTNgay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKhoa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDNgay)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTNgay
            // 
            this.txtTNgay.Culture = 1066;
            this.txtTNgay.CustomFormat = "dd/MM/yyyy";
            this.txtTNgay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTNgay.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
            this.txtTNgay.Location = new System.Drawing.Point(64, 137);
            this.txtTNgay.Name = "txtTNgay";
            this.txtTNgay.Size = new System.Drawing.Size(105, 22);
            this.txtTNgay.TabIndex = 4;
            this.txtTNgay.Tag = null;
            this.txtTNgay.Value = new System.DateTime(2008, 9, 5, 14, 35, 26, 218);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(2, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 16);
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
            this.cmbKhoa.CaptionStyle = style9;
            this.cmbKhoa.CaptionVisible = false;
            this.cmbKhoa.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cmbKhoa.ColumnCaptionHeight = 17;
            this.cmbKhoa.ColumnFooterHeight = 17;
            this.cmbKhoa.ColumnHeaders = false;
            this.cmbKhoa.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList;
            this.cmbKhoa.ContentHeight = 18;
            this.cmbKhoa.DataMode = C1.Win.C1List.DataModeEnum.AddItem;
            this.cmbKhoa.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cmbKhoa.DefColWidth = 30;
            this.cmbKhoa.DisplayMember = "Danh mục";
            this.cmbKhoa.EditorBackColor = System.Drawing.Color.White;
            this.cmbKhoa.EditorFont = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbKhoa.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbKhoa.EditorHeight = 18;
            this.cmbKhoa.EvenRowStyle = style10;
            this.cmbKhoa.ExtendRightColumn = true;
            this.cmbKhoa.FlatStyle = C1.Win.C1List.FlatModeEnum.Popup;
            this.cmbKhoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbKhoa.FooterStyle = style11;
            this.cmbKhoa.GapHeight = 2;
            this.cmbKhoa.HeadingStyle = style12;
            this.cmbKhoa.HighLightRowStyle = style13;
            this.cmbKhoa.ItemHeight = 15;
            this.cmbKhoa.Location = new System.Drawing.Point(61, 9);
            this.cmbKhoa.MatchCol = C1.Win.C1List.MatchColEnum.AllCols;
            this.cmbKhoa.MatchEntryTimeout = ((long)(2000));
            this.cmbKhoa.MaxDropDownItems = ((short)(10));
            this.cmbKhoa.MaxLength = 32767;
            this.cmbKhoa.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cmbKhoa.Name = "cmbKhoa";
            this.cmbKhoa.OddRowStyle = style14;
            this.cmbKhoa.PartialRightColumn = false;
            this.cmbKhoa.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.cmbKhoa.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.cmbKhoa.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cmbKhoa.SelectedStyle = style15;
            this.cmbKhoa.Size = new System.Drawing.Size(292, 22);
            this.cmbKhoa.Style = style16;
            this.cmbKhoa.TabIndex = 0;
            this.cmbKhoa.PropBag = resources.GetString("cmbKhoa.PropBag");
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(10, 10);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 20);
            this.label12.TabIndex = 143;
            this.label12.Text = "Khoa";
            // 
            // txtDNgay
            // 
            this.txtDNgay.Culture = 1066;
            this.txtDNgay.CustomFormat = "dd/MM/yyyy";
            this.txtDNgay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDNgay.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
            this.txtDNgay.Location = new System.Drawing.Point(241, 137);
            this.txtDNgay.Name = "txtDNgay";
            this.txtDNgay.Size = new System.Drawing.Size(105, 22);
            this.txtDNgay.TabIndex = 5;
            this.txtDNgay.Tag = null;
            this.txtDNgay.Value = new System.DateTime(2008, 9, 5, 14, 35, 26, 218);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(177, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 16);
            this.label1.TabIndex = 147;
            this.label1.Text = "Đến ngày";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // raDangDT
            // 
            this.raDangDT.AutoSize = true;
            this.raDangDT.Checked = true;
            this.raDangDT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.raDangDT.Location = new System.Drawing.Point(9, 109);
            this.raDangDT.Name = "raDangDT";
            this.raDangDT.Size = new System.Drawing.Size(100, 20);
            this.raDangDT.TabIndex = 2;
            this.raDangDT.TabStop = true;
            this.raDangDT.Text = "Đang điều trị";
            this.raDangDT.UseVisualStyleBackColor = true;
            this.raDangDT.CheckedChanged += new System.EventHandler(this.raDangDT_CheckedChanged);
            // 
            // raRaVien
            // 
            this.raRaVien.AutoSize = true;
            this.raRaVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.raRaVien.Location = new System.Drawing.Point(131, 109);
            this.raRaVien.Name = "raRaVien";
            this.raRaVien.Size = new System.Drawing.Size(102, 20);
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
            this.cmbKhongGhi.Location = new System.Drawing.Point(79, 165);
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
            this.cmdThoat.Location = new System.Drawing.Point(224, 165);
            this.cmdThoat.Name = "cmdThoat";
            this.cmdThoat.Size = new System.Drawing.Size(82, 25);
            this.cmdThoat.TabIndex = 7;
            this.cmdThoat.Text = "Thoát";
            this.cmdThoat.Click += new System.EventHandler(this.cmdThoat_Click);
            // 
            // raVaoVien
            // 
            this.raVaoVien.AutoSize = true;
            this.raVaoVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.raVaoVien.Location = new System.Drawing.Point(251, 109);
            this.raVaoVien.Name = "raVaoVien";
            this.raVaoVien.Size = new System.Drawing.Size(113, 20);
            this.raVaoVien.TabIndex = 152;
            this.raVaoVien.Text = "Ngày vào viện";
            this.raVaoVien.UseVisualStyleBackColor = true;
            this.raVaoVien.CheckedChanged += new System.EventHandler(this.raVaoVien_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDen);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtTu);
            this.groupBox1.Controls.Add(this.raTatCa);
            this.groupBox1.Controls.Add(this.raTrongKhoang);
            this.groupBox1.Controls.Add(this.raTrongHuyen);
            this.groupBox1.Controls.Add(this.raBVTinh);
            this.groupBox1.Location = new System.Drawing.Point(3, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(363, 69);
            this.groupBox1.TabIndex = 154;
            this.groupBox1.TabStop = false;
            // 
            // txtDen
            // 
            this.txtDen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDen.Location = new System.Drawing.Point(232, 41);
            this.txtDen.Mask = "## ###";
            this.txtDen.Name = "txtDen";
            this.txtDen.Size = new System.Drawing.Size(53, 22);
            this.txtDen.TabIndex = 4;
            this.txtDen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(197, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 16);
            this.label5.TabIndex = 154;
            this.label5.Text = "Đến";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(20, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 16);
            this.label3.TabIndex = 152;
            this.label3.Text = "Mã nơi cấp từ";
            // 
            // txtTu
            // 
            this.txtTu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTu.Location = new System.Drawing.Point(110, 42);
            this.txtTu.Mask = "## ###";
            this.txtTu.Name = "txtTu";
            this.txtTu.Size = new System.Drawing.Size(53, 22);
            this.txtTu.TabIndex = 4;
            this.txtTu.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // raTatCa
            // 
            this.raTatCa.AutoSize = true;
            this.raTatCa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.raTatCa.Location = new System.Drawing.Point(297, 14);
            this.raTatCa.Name = "raTatCa";
            this.raTatCa.Size = new System.Drawing.Size(64, 20);
            this.raTatCa.TabIndex = 3;
            this.raTatCa.Text = "Tất cả";
            this.raTatCa.UseVisualStyleBackColor = true;
            this.raTatCa.CheckedChanged += new System.EventHandler(this.raTatCa_CheckedChanged);
            // 
            // raTrongKhoang
            // 
            this.raTrongKhoang.AutoSize = true;
            this.raTrongKhoang.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.raTrongKhoang.Location = new System.Drawing.Point(192, 14);
            this.raTrongKhoang.Name = "raTrongKhoang";
            this.raTrongKhoang.Size = new System.Drawing.Size(110, 20);
            this.raTrongKhoang.TabIndex = 2;
            this.raTrongKhoang.Text = "Trong khoảng";
            this.raTrongKhoang.UseVisualStyleBackColor = true;
            this.raTrongKhoang.CheckedChanged += new System.EventHandler(this.raTrongKhoang_CheckedChanged);
            // 
            // raTrongHuyen
            // 
            this.raTrongHuyen.AutoSize = true;
            this.raTrongHuyen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.raTrongHuyen.Location = new System.Drawing.Point(111, 14);
            this.raTrongHuyen.Name = "raTrongHuyen";
            this.raTrongHuyen.Size = new System.Drawing.Size(85, 20);
            this.raTrongHuyen.TabIndex = 1;
            this.raTrongHuyen.Text = "Trong tỉnh";
            this.raTrongHuyen.UseVisualStyleBackColor = true;
            this.raTrongHuyen.CheckedChanged += new System.EventHandler(this.raTrongHuyen_CheckedChanged);
            // 
            // raBVTinh
            // 
            this.raBVTinh.AutoSize = true;
            this.raBVTinh.Checked = true;
            this.raBVTinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.raBVTinh.Location = new System.Drawing.Point(5, 14);
            this.raBVTinh.Name = "raBVTinh";
            this.raBVTinh.Size = new System.Drawing.Size(108, 20);
            this.raBVTinh.TabIndex = 0;
            this.raBVTinh.TabStop = true;
            this.raBVTinh.Text = "Bệnh viện tỉnh";
            this.raBVTinh.UseVisualStyleBackColor = true;
            this.raBVTinh.CheckedChanged += new System.EventHandler(this.raBVTinh_CheckedChanged);
            // 
            // frmTNgayDNgayByNoiKCBBD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 201);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.raVaoVien);
            this.Controls.Add(this.raRaVien);
            this.Controls.Add(this.raDangDT);
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
            this.Name = "frmTNgayDNgayByNoiKCBBD";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Từ ngày đến ngày";
            this.Load += new System.EventHandler(this.frmTNgayDNgay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtTNgay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKhoa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDNgay)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.RadioButton raDangDT;
        private System.Windows.Forms.RadioButton raRaVien;
        private System.Windows.Forms.RadioButton raVaoVien;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton raTrongKhoang;
        private System.Windows.Forms.RadioButton raTrongHuyen;
        private System.Windows.Forms.RadioButton raBVTinh;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox txtTu;
        private System.Windows.Forms.RadioButton raTatCa;
        private System.Windows.Forms.MaskedTextBox txtDen;
    }
}