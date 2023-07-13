namespace NamDinh_QLBN.Forms.Tien_ich
{
    partial class frmConfig
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfig));
            C1.Win.C1List.Style style1 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style2 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style3 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style4 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style5 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style6 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style7 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style8 = new C1.Win.C1List.Style();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cmdGhiChiTiet = new DevExpress.XtraEditors.SimpleButton();
            this.fgDanhMuc = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cnbGhiOptionHSBA = new DevExpress.XtraEditors.SimpleButton();
            this.cmbDoiTuong = new C1.Win.C1List.C1Combo();
            this.label15 = new System.Windows.Forms.Label();
            this.fgHSBA = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.simpleButton10 = new DevExpress.XtraEditors.SimpleButton();
            this.fgPreview = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.label2 = new System.Windows.Forms.Label();
            this.lblUName = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuBackground = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuForeColor = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFont = new System.Windows.Forms.ToolStripMenuItem();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fgDanhMuc)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDoiTuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fgHSBA)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fgPreview)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(1, 26);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(637, 365);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cmdGhiChiTiet);
            this.tabPage1.Controls.Add(this.fgDanhMuc);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(629, 339);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Cập nhật chi phí";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cmdGhiChiTiet
            // 
            this.cmdGhiChiTiet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdGhiChiTiet.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdGhiChiTiet.Image = ((System.Drawing.Image)(resources.GetObject("cmdGhiChiTiet.Image")));
            this.cmdGhiChiTiet.Location = new System.Drawing.Point(534, 305);
            this.cmdGhiChiTiet.Name = "cmdGhiChiTiet";
            this.cmdGhiChiTiet.Size = new System.Drawing.Size(89, 27);
            this.cmdGhiChiTiet.TabIndex = 120;
            this.cmdGhiChiTiet.Text = "Ghi dữ liệu";
            this.cmdGhiChiTiet.Click += new System.EventHandler(this.cmdGhiChiTiet_Click);
            // 
            // fgDanhMuc
            // 
            this.fgDanhMuc.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.fgDanhMuc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.fgDanhMuc.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Light3D;
            this.fgDanhMuc.ColumnInfo = resources.GetString("fgDanhMuc.ColumnInfo");
            this.fgDanhMuc.ExtendLastCol = true;
            this.fgDanhMuc.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None;
            this.fgDanhMuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fgDanhMuc.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.fgDanhMuc.Location = new System.Drawing.Point(7, 30);
            this.fgDanhMuc.Name = "fgDanhMuc";
            this.fgDanhMuc.Rows.Count = 1;
            this.fgDanhMuc.Rows.MinSize = 20;
            this.fgDanhMuc.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox;
            this.fgDanhMuc.ShowCursor = true;
            this.fgDanhMuc.Size = new System.Drawing.Size(309, 306);
            this.fgDanhMuc.Styles = new C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("fgDanhMuc.Styles"));
            this.fgDanhMuc.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Loại chi phí copy khi nhập dữ liệu";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.cnbGhiOptionHSBA);
            this.tabPage2.Controls.Add(this.cmbDoiTuong);
            this.tabPage2.Controls.Add(this.label15);
            this.tabPage2.Controls.Add(this.fgHSBA);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(629, 339);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Cập nhật hồ sơ bệnh án";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // cnbGhiOptionHSBA
            // 
            this.cnbGhiOptionHSBA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cnbGhiOptionHSBA.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cnbGhiOptionHSBA.Image = ((System.Drawing.Image)(resources.GetObject("cnbGhiOptionHSBA.Image")));
            this.cnbGhiOptionHSBA.Location = new System.Drawing.Point(534, 306);
            this.cnbGhiOptionHSBA.Name = "cnbGhiOptionHSBA";
            this.cnbGhiOptionHSBA.Size = new System.Drawing.Size(89, 27);
            this.cnbGhiOptionHSBA.TabIndex = 145;
            this.cnbGhiOptionHSBA.Text = "Ghi dữ liệu";
            this.cnbGhiOptionHSBA.Click += new System.EventHandler(this.cnbGhiOptionHSBA_Click);
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
            this.cmbDoiTuong.CaptionStyle = style1;
            this.cmbDoiTuong.CaptionVisible = false;
            this.cmbDoiTuong.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cmbDoiTuong.ColumnCaptionHeight = 17;
            this.cmbDoiTuong.ColumnFooterHeight = 17;
            this.cmbDoiTuong.ColumnHeaders = false;
            this.cmbDoiTuong.ContentHeight = 16;
            this.cmbDoiTuong.DataMode = C1.Win.C1List.DataModeEnum.AddItem;
            this.cmbDoiTuong.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cmbDoiTuong.DefColWidth = 30;
            this.cmbDoiTuong.DisplayMember = "Danh mục";
            this.cmbDoiTuong.EditorBackColor = System.Drawing.Color.White;
            this.cmbDoiTuong.EditorFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDoiTuong.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbDoiTuong.EditorHeight = 16;
            this.cmbDoiTuong.EvenRowStyle = style2;
            this.cmbDoiTuong.ExtendRightColumn = true;
            this.cmbDoiTuong.FlatStyle = C1.Win.C1List.FlatModeEnum.Popup;
            this.cmbDoiTuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDoiTuong.FooterStyle = style3;
            this.cmbDoiTuong.GapHeight = 2;
            this.cmbDoiTuong.HeadingStyle = style4;
            this.cmbDoiTuong.HighLightRowStyle = style5;
            this.cmbDoiTuong.ItemHeight = 15;
            this.cmbDoiTuong.Location = new System.Drawing.Point(123, 30);
            this.cmbDoiTuong.MatchCol = C1.Win.C1List.MatchColEnum.AllCols;
            this.cmbDoiTuong.MatchEntryTimeout = ((long)(2000));
            this.cmbDoiTuong.MaxDropDownItems = ((short)(10));
            this.cmbDoiTuong.MaxLength = 32767;
            this.cmbDoiTuong.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cmbDoiTuong.Name = "cmbDoiTuong";
            this.cmbDoiTuong.OddRowStyle = style6;
            this.cmbDoiTuong.PartialRightColumn = false;
            this.cmbDoiTuong.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.cmbDoiTuong.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.cmbDoiTuong.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cmbDoiTuong.SelectedStyle = style7;
            this.cmbDoiTuong.Size = new System.Drawing.Size(315, 20);
            this.cmbDoiTuong.Style = style8;
            this.cmbDoiTuong.TabIndex = 143;
            this.cmbDoiTuong.TextChanged += new System.EventHandler(this.cmbDoiTuong_TextChanged);
            this.cmbDoiTuong.PropBag = resources.GetString("cmbDoiTuong.PropBag");
            // 
            // label15
            // 
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label15.Location = new System.Drawing.Point(7, 30);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(118, 20);
            this.label15.TabIndex = 144;
            this.label15.Text = "*Đối tượng bệnh nhân";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // fgHSBA
            // 
            this.fgHSBA.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.fgHSBA.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.fgHSBA.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Light3D;
            this.fgHSBA.ColumnInfo = resources.GetString("fgHSBA.ColumnInfo");
            this.fgHSBA.ExtendLastCol = true;
            this.fgHSBA.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None;
            this.fgHSBA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fgHSBA.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.fgHSBA.Location = new System.Drawing.Point(7, 51);
            this.fgHSBA.Name = "fgHSBA";
            this.fgHSBA.Rows.Count = 1;
            this.fgHSBA.Rows.MinSize = 20;
            this.fgHSBA.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox;
            this.fgHSBA.ShowCursor = true;
            this.fgHSBA.Size = new System.Drawing.Size(507, 285);
            this.fgHSBA.Styles = new C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("fgHSBA.Styles"));
            this.fgHSBA.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(392, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Chọn trường thông tin khi cập nhật hồ sơ bệnh án theo từng đối tượng bệnh nhân";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.simpleButton1);
            this.tabPage3.Controls.Add(this.simpleButton10);
            this.tabPage3.Controls.Add(this.fgPreview);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(629, 339);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Hiển thị";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // simpleButton10
            // 
            this.simpleButton10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton10.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.simpleButton10.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton10.Image")));
            this.simpleButton10.Location = new System.Drawing.Point(489, 305);
            this.simpleButton10.Name = "simpleButton10";
            this.simpleButton10.Size = new System.Drawing.Size(134, 27);
            this.simpleButton10.TabIndex = 161;
            this.simpleButton10.Text = "Ghi cấu hình";
            this.simpleButton10.Click += new System.EventHandler(this.simpleButton10_Click);
            // 
            // fgPreview
            // 
            this.fgPreview.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.fgPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.fgPreview.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Light3D;
            this.fgPreview.ColumnInfo = resources.GetString("fgPreview.ColumnInfo");
            this.fgPreview.Cursor = System.Windows.Forms.Cursors.Default;
            this.fgPreview.ExtendLastCol = true;
            this.fgPreview.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None;
            this.fgPreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fgPreview.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.fgPreview.Location = new System.Drawing.Point(4, 3);
            this.fgPreview.Name = "fgPreview";
            this.fgPreview.Rows.Count = 1;
            this.fgPreview.Rows.MinSize = 20;
            this.fgPreview.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox;
            this.fgPreview.ShowCursor = true;
            this.fgPreview.Size = new System.Drawing.Size(619, 297);
            this.fgPreview.Styles = new C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("fgPreview.Styles"));
            this.fgPreview.TabIndex = 5;
            this.fgPreview.MouseUp += new System.Windows.Forms.MouseEventHandler(this.fgPreview_MouseUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Thiết lập với người sử dụng:";
            // 
            // lblUName
            // 
            this.lblUName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblUName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblUName.Location = new System.Drawing.Point(151, 4);
            this.lblUName.Name = "lblUName";
            this.lblUName.Size = new System.Drawing.Size(100, 18);
            this.lblUName.TabIndex = 2;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuBackground,
            this.mnuForeColor,
            this.mnuFont});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(148, 70);
            // 
            // mnuBackground
            // 
            this.mnuBackground.Name = "mnuBackground";
            this.mnuBackground.Size = new System.Drawing.Size(147, 22);
            this.mnuBackground.Text = "Đặt màu nền";
            this.mnuBackground.Click += new System.EventHandler(this.mnuBackground_Click);
            // 
            // mnuForeColor
            // 
            this.mnuForeColor.Name = "mnuForeColor";
            this.mnuForeColor.Size = new System.Drawing.Size(147, 22);
            this.mnuForeColor.Text = "Đặt màu chữ";
            this.mnuForeColor.Click += new System.EventHandler(this.mnuForeColor_Click);
            // 
            // mnuFont
            // 
            this.mnuFont.Name = "mnuFont";
            this.mnuFont.Size = new System.Drawing.Size(147, 22);
            this.mnuFont.Text = "Đặt font chữ";
            this.mnuFont.Click += new System.EventHandler(this.mnuFont_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.simpleButton1.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(4, 305);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(134, 27);
            this.simpleButton1.TabIndex = 162;
            this.simpleButton1.Text = "Mặc định";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // frmConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 392);
            this.Controls.Add(this.lblUName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tùy chọn";
            this.Load += new System.EventHandler(this.frmConfig_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fgDanhMuc)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDoiTuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fgHSBA)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fgPreview)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private C1.Win.C1FlexGrid.C1FlexGrid fgDanhMuc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblUName;
        private DevExpress.XtraEditors.SimpleButton cmdGhiChiTiet;
        private C1.Win.C1FlexGrid.C1FlexGrid fgHSBA;
        private System.Windows.Forms.Label label3;
        internal C1.Win.C1List.C1Combo cmbDoiTuong;
        private System.Windows.Forms.Label label15;
        private DevExpress.XtraEditors.SimpleButton cnbGhiOptionHSBA;
        private System.Windows.Forms.TabPage tabPage3;
        private C1.Win.C1FlexGrid.C1FlexGrid fgPreview;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.FontDialog fontDialog1;
        private DevExpress.XtraEditors.SimpleButton simpleButton10;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuBackground;
        private System.Windows.Forms.ToolStripMenuItem mnuForeColor;
        private System.Windows.Forms.ToolStripMenuItem mnuFont;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}