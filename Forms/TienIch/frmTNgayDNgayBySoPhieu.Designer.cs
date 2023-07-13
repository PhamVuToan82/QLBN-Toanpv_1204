namespace NamDinh_QLBN.Forms.Tien_ich
{
    partial class frmTNgayDNgayBySoPhieu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTNgayDNgayBySoPhieu));
            C1.Win.C1List.Style style2 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style3 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style4 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style5 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style6 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style7 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style8 = new C1.Win.C1List.Style();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbKhoa = new C1.Win.C1List.C1Combo();
            this.label12 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbKhongGhi = new DevExpress.XtraEditors.SimpleButton();
            this.cmdThoat = new DevExpress.XtraEditors.SimpleButton();
            this.txtSoPhieuTu = new System.Windows.Forms.MaskedTextBox();
            this.txtSoPhieuDen = new System.Windows.Forms.MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKhoa)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(7, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 16);
            this.label4.TabIndex = 145;
            this.label4.Text = "Số phiếu từ";
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
            this.cmbKhoa.Location = new System.Drawing.Point(65, 12);
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
            this.cmbKhoa.Size = new System.Drawing.Size(268, 20);
            this.cmbKhoa.Style = style8;
            this.cmbKhoa.TabIndex = 144;
            this.cmbKhoa.PropBag = resources.GetString("cmbKhoa.PropBag");
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(31, 13);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(32, 13);
            this.label12.TabIndex = 143;
            this.label12.Text = "Khoa";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(198, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 16);
            this.label1.TabIndex = 147;
            this.label1.Text = "đến";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbKhongGhi
            // 
            this.cmbKhongGhi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbKhongGhi.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmbKhongGhi.Image = global::NamDinh_QLBN.Properties.Resources._1221111212;
            this.cmbKhongGhi.Location = new System.Drawing.Point(57, 70);
            this.cmbKhongGhi.Name = "cmbKhongGhi";
            this.cmbKhongGhi.Size = new System.Drawing.Size(68, 25);
            this.cmbKhongGhi.TabIndex = 7;
            this.cmbKhongGhi.Text = "Chọn";
            this.cmbKhongGhi.Click += new System.EventHandler(this.cmbKhongGhi_Click);
            // 
            // cmdThoat
            // 
            this.cmdThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdThoat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdThoat.Image = ((System.Drawing.Image)(resources.GetObject("cmdThoat.Image")));
            this.cmdThoat.Location = new System.Drawing.Point(216, 70);
            this.cmdThoat.Name = "cmdThoat";
            this.cmdThoat.Size = new System.Drawing.Size(82, 25);
            this.cmdThoat.TabIndex = 8;
            this.cmdThoat.Text = "Thoát";
            this.cmdThoat.Click += new System.EventHandler(this.cmdThoat_Click);
            // 
            // txtSoPhieuTu
            // 
            this.txtSoPhieuTu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtSoPhieuTu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoPhieuTu.Location = new System.Drawing.Point(79, 40);
            this.txtSoPhieuTu.Mask = "P##/##/##/###";
            this.txtSoPhieuTu.Name = "txtSoPhieuTu";
            this.txtSoPhieuTu.Size = new System.Drawing.Size(118, 22);
            this.txtSoPhieuTu.TabIndex = 149;
            this.txtSoPhieuTu.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSoPhieuDen
            // 
            this.txtSoPhieuDen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtSoPhieuDen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoPhieuDen.Location = new System.Drawing.Point(228, 40);
            this.txtSoPhieuDen.Mask = "P##/##/##/###";
            this.txtSoPhieuDen.Name = "txtSoPhieuDen";
            this.txtSoPhieuDen.Size = new System.Drawing.Size(116, 22);
            this.txtSoPhieuDen.TabIndex = 150;
            this.txtSoPhieuDen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // frmTNgayDNgayBySoPhieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 107);
            this.Controls.Add(this.txtSoPhieuDen);
            this.Controls.Add(this.txtSoPhieuTu);
            this.Controls.Add(this.cmbKhongGhi);
            this.Controls.Add(this.cmdThoat);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbKhoa);
            this.Controls.Add(this.label12);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTNgayDNgayBySoPhieu";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Từ ngày đến ngày thuốc - vật tư";
            this.Load += new System.EventHandler(this.frmTNgayDNgay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cmbKhoa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        internal C1.Win.C1List.C1Combo cmbKhoa;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton cmbKhongGhi;
        private DevExpress.XtraEditors.SimpleButton cmdThoat;
        private System.Windows.Forms.MaskedTextBox txtSoPhieuTu;
        private System.Windows.Forms.MaskedTextBox txtSoPhieuDen;
    }
}