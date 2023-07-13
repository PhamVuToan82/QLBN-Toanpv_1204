namespace NamDinh_QLBN.Forms.Tien_ich
{
    partial class frmTNgayDNgay_excel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTNgayDNgay_excel));
            C1.Win.C1List.Style style18 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style19 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style20 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style21 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style22 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style23 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style24 = new C1.Win.C1List.Style();
            this.txtTNgay = new C1.Win.C1Input.C1DateEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbKhoa = new C1.Win.C1List.C1Combo();
            this.label12 = new System.Windows.Forms.Label();
            this.txtDNgay = new C1.Win.C1Input.C1DateEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbKhongGhi = new DevExpress.XtraEditors.SimpleButton();
            this.cmdThoat = new DevExpress.XtraEditors.SimpleButton();
            this.fgDanhSach = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.Excel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtTNgay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKhoa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDNgay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fgDanhSach)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTNgay
            // 
            this.txtTNgay.Culture = 1066;
            this.txtTNgay.CustomFormat = "dd/MM/yyyy";
            this.txtTNgay.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
            this.txtTNgay.Location = new System.Drawing.Point(61, 40);
            this.txtTNgay.Name = "txtTNgay";
            this.txtTNgay.Size = new System.Drawing.Size(105, 20);
            this.txtTNgay.TabIndex = 146;
            this.txtTNgay.Tag = null;
            this.txtTNgay.Value = new System.DateTime(2008, 9, 5, 14, 35, 26, 218);
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(-1, 41);
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
            this.cmbKhoa.Location = new System.Drawing.Point(61, 12);
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
            this.cmbKhoa.Size = new System.Drawing.Size(284, 20);
            this.cmbKhoa.Style = style24;
            this.cmbKhoa.TabIndex = 144;
            this.cmbKhoa.PropBag = resources.GetString("cmbKhoa.PropBag");
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(12, 14);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(60, 18);
            this.label12.TabIndex = 143;
            this.label12.Text = "Khoa";
            // 
            // txtDNgay
            // 
            this.txtDNgay.Culture = 1066;
            this.txtDNgay.CustomFormat = "dd/MM/yyyy";
            this.txtDNgay.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
            this.txtDNgay.Location = new System.Drawing.Point(238, 41);
            this.txtDNgay.Name = "txtDNgay";
            this.txtDNgay.Size = new System.Drawing.Size(105, 20);
            this.txtDNgay.TabIndex = 148;
            this.txtDNgay.Tag = null;
            this.txtDNgay.Value = new System.DateTime(2008, 9, 5, 14, 35, 26, 218);
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(176, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 19);
            this.label1.TabIndex = 147;
            this.label1.Text = "Đến ngày";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbKhongGhi
            // 
            this.cmbKhongGhi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbKhongGhi.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmbKhongGhi.Image = global::NamDinh_QLBN.Properties.Resources._1221111212;
            this.cmbKhongGhi.Location = new System.Drawing.Point(184, 83);
            this.cmbKhongGhi.Name = "cmbKhongGhi";
            this.cmbKhongGhi.Size = new System.Drawing.Size(68, 25);
            this.cmbKhongGhi.TabIndex = 150;
            this.cmbKhongGhi.Text = "Chọn";
            this.cmbKhongGhi.Click += new System.EventHandler(this.cmbKhongGhi_Click);
            // 
            // cmdThoat
            // 
            this.cmdThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdThoat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdThoat.Image = ((System.Drawing.Image)(resources.GetObject("cmdThoat.Image")));
            this.cmdThoat.Location = new System.Drawing.Point(258, 83);
            this.cmdThoat.Name = "cmdThoat";
            this.cmdThoat.Size = new System.Drawing.Size(82, 25);
            this.cmdThoat.TabIndex = 149;
            this.cmdThoat.Text = "Thoát";
            this.cmdThoat.Click += new System.EventHandler(this.cmdThoat_Click);
            // 
            // fgDanhSach
            // 
            this.fgDanhSach.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.fgDanhSach.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Light3D;
            this.fgDanhSach.ColumnInfo = resources.GetString("fgDanhSach.ColumnInfo");
            this.fgDanhSach.ExtendLastCol = true;
            this.fgDanhSach.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid;
            this.fgDanhSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fgDanhSach.Location = new System.Drawing.Point(12, 67);
            this.fgDanhSach.Name = "fgDanhSach";
            this.fgDanhSach.Rows.Count = 1;
            this.fgDanhSach.Rows.MinSize = 20;
            this.fgDanhSach.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox;
            this.fgDanhSach.ShowCursor = true;
            this.fgDanhSach.Size = new System.Drawing.Size(28, 16);
            this.fgDanhSach.Styles = new C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("fgDanhSach.Styles"));
            this.fgDanhSach.TabIndex = 300;
            // 
            // Excel
            // 
            this.Excel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Excel.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Excel.Image = global::NamDinh_QLBN.Properties.Resources.Excel;
            this.Excel.Location = new System.Drawing.Point(61, 83);
            this.Excel.Name = "Excel";
            this.Excel.Size = new System.Drawing.Size(117, 25);
            this.Excel.TabIndex = 301;
            this.Excel.Text = "Export Excel";
            this.Excel.Click += new System.EventHandler(this.Excel_Click);
            // 
            // frmTNgayDNgay_excel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 111);
            this.Controls.Add(this.Excel);
            this.Controls.Add(this.fgDanhSach);
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
            this.Name = "frmTNgayDNgay_excel";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Từ ngày đến ngày";
            this.Load += new System.EventHandler(this.frmTNgayDNgay_excel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtTNgay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKhoa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDNgay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fgDanhSach)).EndInit();
            this.ResumeLayout(false);

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
        private C1.Win.C1FlexGrid.C1FlexGrid fgDanhSach;
        private DevExpress.XtraEditors.SimpleButton Excel;
    }
}