namespace NamDinh_QLBN.Forms.Tien_ich
{
    partial class frmTNgayDNgay_Vai
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
            C1.Win.C1List.Style style1 = new C1.Win.C1List.Style();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTNgayDNgay_Vai));
            C1.Win.C1List.Style style2 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style3 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style4 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style5 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style6 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style7 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style8 = new C1.Win.C1List.Style();
            this.txtTNgay = new C1.Win.C1Input.C1DateEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbKhoa = new C1.Win.C1List.C1Combo();
            this.label12 = new System.Windows.Forms.Label();
            this.txtDNgay = new C1.Win.C1Input.C1DateEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.rd_muonvai = new System.Windows.Forms.RadioButton();
            this.rd_doivai = new System.Windows.Forms.RadioButton();
            this.rd_datravai = new System.Windows.Forms.RadioButton();
            this.btn_BcTongHop = new DevExpress.XtraEditors.SimpleButton();
            this.cmbKhongGhi = new DevExpress.XtraEditors.SimpleButton();
            this.cmdThoat = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtTNgay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKhoa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDNgay)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTNgay
            // 
            this.txtTNgay.Culture = 1066;
            this.txtTNgay.CustomFormat = "dd/MM/yyyy HH:mm";
            this.txtTNgay.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
            this.txtTNgay.Location = new System.Drawing.Point(66, 44);
            this.txtTNgay.Name = "txtTNgay";
            this.txtTNgay.Size = new System.Drawing.Size(129, 20);
            this.txtTNgay.TabIndex = 146;
            this.txtTNgay.Tag = null;
            this.txtTNgay.Value = new System.DateTime(2008, 9, 5, 14, 35, 26, 218);
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(19, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 19);
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
            this.cmbKhoa.CaptionStyle = style1;
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
            this.cmbKhoa.EvenRowStyle = style2;
            this.cmbKhoa.ExtendRightColumn = true;
            this.cmbKhoa.FlatStyle = C1.Win.C1List.FlatModeEnum.Popup;
            this.cmbKhoa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbKhoa.FooterStyle = style3;
            this.cmbKhoa.GapHeight = 2;
            this.cmbKhoa.HeadingStyle = style4;
            this.cmbKhoa.HighLightRowStyle = style5;
            this.cmbKhoa.ItemHeight = 15;
            this.cmbKhoa.Location = new System.Drawing.Point(68, 12);
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
            this.cmbKhoa.Size = new System.Drawing.Size(314, 20);
            this.cmbKhoa.Style = style8;
            this.cmbKhoa.TabIndex = 144;
            this.cmbKhoa.PropBag = resources.GetString("cmbKhoa.PropBag");
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(33, 13);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(32, 18);
            this.label12.TabIndex = 143;
            this.label12.Text = "Khoa";
            // 
            // txtDNgay
            // 
            this.txtDNgay.Culture = 1066;
            this.txtDNgay.CustomFormat = "dd/MM/yyyy HH:mm";
            this.txtDNgay.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
            this.txtDNgay.Location = new System.Drawing.Point(252, 45);
            this.txtDNgay.Name = "txtDNgay";
            this.txtDNgay.Size = new System.Drawing.Size(130, 20);
            this.txtDNgay.TabIndex = 148;
            this.txtDNgay.Tag = null;
            this.txtDNgay.Value = new System.DateTime(2008, 9, 5, 14, 35, 26, 218);
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(197, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 19);
            this.label1.TabIndex = 147;
            this.label1.Text = "Đến ngày";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rd_muonvai
            // 
            this.rd_muonvai.AutoSize = true;
            this.rd_muonvai.Location = new System.Drawing.Point(83, 79);
            this.rd_muonvai.Name = "rd_muonvai";
            this.rd_muonvai.Size = new System.Drawing.Size(70, 17);
            this.rd_muonvai.TabIndex = 151;
            this.rd_muonvai.TabStop = true;
            this.rd_muonvai.Text = "Mượn Vải";
            this.rd_muonvai.UseVisualStyleBackColor = true;
            // 
            // rd_doivai
            // 
            this.rd_doivai.AutoSize = true;
            this.rd_doivai.Location = new System.Drawing.Point(196, 79);
            this.rd_doivai.Name = "rd_doivai";
            this.rd_doivai.Size = new System.Drawing.Size(59, 17);
            this.rd_doivai.TabIndex = 152;
            this.rd_doivai.TabStop = true;
            this.rd_doivai.Text = "Đổi Vải";
            this.rd_doivai.UseVisualStyleBackColor = true;
            // 
            // rd_datravai
            // 
            this.rd_datravai.AutoSize = true;
            this.rd_datravai.Location = new System.Drawing.Point(287, 79);
            this.rd_datravai.Name = "rd_datravai";
            this.rd_datravai.Size = new System.Drawing.Size(76, 17);
            this.rd_datravai.TabIndex = 153;
            this.rd_datravai.TabStop = true;
            this.rd_datravai.Text = "Đã Trả Vải";
            this.rd_datravai.UseVisualStyleBackColor = true;
            // 
            // btn_BcTongHop
            // 
            this.btn_BcTongHop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_BcTongHop.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_BcTongHop.Image = global::NamDinh_QLBN.Properties.Resources._1221111212;
            this.btn_BcTongHop.Location = new System.Drawing.Point(165, 104);
            this.btn_BcTongHop.Name = "btn_BcTongHop";
            this.btn_BcTongHop.Size = new System.Drawing.Size(118, 43);
            this.btn_BcTongHop.TabIndex = 154;
            this.btn_BcTongHop.Text = "BC Tổng Hợp";
            this.btn_BcTongHop.Click += new System.EventHandler(this.btn_BcTongHop_Click);
            // 
            // cmbKhongGhi
            // 
            this.cmbKhongGhi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbKhongGhi.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmbKhongGhi.Image = global::NamDinh_QLBN.Properties.Resources._1221111212;
            this.cmbKhongGhi.Location = new System.Drawing.Point(59, 104);
            this.cmbKhongGhi.Name = "cmbKhongGhi";
            this.cmbKhongGhi.Size = new System.Drawing.Size(100, 43);
            this.cmbKhongGhi.TabIndex = 150;
            this.cmbKhongGhi.Text = "BC Chi Tiết";
            this.cmbKhongGhi.Click += new System.EventHandler(this.cmbKhongGhi_Click);
            // 
            // cmdThoat
            // 
            this.cmdThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdThoat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdThoat.Image = ((System.Drawing.Image)(resources.GetObject("cmdThoat.Image")));
            this.cmdThoat.Location = new System.Drawing.Point(297, 104);
            this.cmdThoat.Name = "cmdThoat";
            this.cmdThoat.Size = new System.Drawing.Size(82, 43);
            this.cmdThoat.TabIndex = 149;
            this.cmdThoat.Text = "Thoát";
            this.cmdThoat.Click += new System.EventHandler(this.cmdThoat_Click);
            // 
            // frmTNgayDNgay_Vai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 159);
            this.Controls.Add(this.btn_BcTongHop);
            this.Controls.Add(this.rd_datravai);
            this.Controls.Add(this.rd_doivai);
            this.Controls.Add(this.rd_muonvai);
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
            this.Name = "frmTNgayDNgay_Vai";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Từ ngày đến ngày";
            this.Load += new System.EventHandler(this.frmTNgayDNgay_Vai_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtTNgay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKhoa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDNgay)).EndInit();
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
        private System.Windows.Forms.RadioButton rd_muonvai;
        private System.Windows.Forms.RadioButton rd_doivai;
        private System.Windows.Forms.RadioButton rd_datravai;
        private DevExpress.XtraEditors.SimpleButton btn_BcTongHop;
    }
}