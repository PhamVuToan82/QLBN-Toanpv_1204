namespace NamDinh_QLBN.Forms.Tien_ich
{
    partial class frmDatChiPhi_Khoa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDatChiPhi_Khoa));
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cmdGhiLoaiDichVu = new System.Windows.Forms.Button();
            this.fgLoaiDichVu = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.cmbLoaiDichVu = new C1.Win.C1List.C1Combo();
            this.label15 = new System.Windows.Forms.Label();
            this.fgDichVu = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.cmbKhoa = new C1.Win.C1List.C1Combo();
            this.label12 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fgLoaiDichVu)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLoaiDichVu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fgDichVu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKhoa)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 37);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(763, 422);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cmdGhiLoaiDichVu);
            this.tabPage1.Controls.Add(this.fgLoaiDichVu);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(755, 396);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Nhóm dịch vụ chỉ định";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cmdGhiLoaiDichVu
            // 
            this.cmdGhiLoaiDichVu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdGhiLoaiDichVu.Image = ((System.Drawing.Image)(resources.GetObject("cmdGhiLoaiDichVu.Image")));
            this.cmdGhiLoaiDichVu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdGhiLoaiDichVu.Location = new System.Drawing.Point(657, 364);
            this.cmdGhiLoaiDichVu.Name = "cmdGhiLoaiDichVu";
            this.cmdGhiLoaiDichVu.Size = new System.Drawing.Size(91, 29);
            this.cmdGhiLoaiDichVu.TabIndex = 5;
            this.cmdGhiLoaiDichVu.Text = "   Ghi dữ liệu";
            this.cmdGhiLoaiDichVu.UseVisualStyleBackColor = true;
            this.cmdGhiLoaiDichVu.Click += new System.EventHandler(this.cmdGhiLoaiDichVu_Click);
            // 
            // fgLoaiDichVu
            // 
            this.fgLoaiDichVu.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.fgLoaiDichVu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.fgLoaiDichVu.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Light3D;
            this.fgLoaiDichVu.ColumnInfo = resources.GetString("fgLoaiDichVu.ColumnInfo");
            this.fgLoaiDichVu.Cursor = System.Windows.Forms.Cursors.Default;
            this.fgLoaiDichVu.ExtendLastCol = true;
            this.fgLoaiDichVu.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None;
            this.fgLoaiDichVu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fgLoaiDichVu.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.fgLoaiDichVu.Location = new System.Drawing.Point(7, 30);
            this.fgLoaiDichVu.Name = "fgLoaiDichVu";
            this.fgLoaiDichVu.Rows.Count = 1;
            this.fgLoaiDichVu.Rows.MinSize = 20;
            this.fgLoaiDichVu.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox;
            this.fgLoaiDichVu.ShowCursor = true;
            this.fgLoaiDichVu.Size = new System.Drawing.Size(745, 331);
            this.fgLoaiDichVu.Styles = new C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("fgLoaiDichVu.Styles"));
            this.fgLoaiDichVu.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(288, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chọn các nhóm dịch vụ có thể chỉ định khi điều trị tại Khoa";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.cmbLoaiDichVu);
            this.tabPage2.Controls.Add(this.label15);
            this.tabPage2.Controls.Add(this.fgDichVu);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(755, 396);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Các dịch vụ chỉ định tại Khoa";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(657, 361);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 29);
            this.button1.TabIndex = 145;
            this.button1.Text = "   Ghi dữ liệu";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmbLoaiDichVu
            // 
            this.cmbLoaiDichVu.AddItemSeparator = ';';
            this.cmbLoaiDichVu.AllowColMove = false;
            this.cmbLoaiDichVu.AllowRowSizing = C1.Win.C1List.RowSizingEnum.AllRows;
            this.cmbLoaiDichVu.AutoCompletion = true;
            this.cmbLoaiDichVu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cmbLoaiDichVu.Caption = "";
            this.cmbLoaiDichVu.CaptionHeight = 17;
            this.cmbLoaiDichVu.CaptionStyle = style1;
            this.cmbLoaiDichVu.CaptionVisible = false;
            this.cmbLoaiDichVu.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cmbLoaiDichVu.ColumnCaptionHeight = 17;
            this.cmbLoaiDichVu.ColumnFooterHeight = 17;
            this.cmbLoaiDichVu.ColumnHeaders = false;
            this.cmbLoaiDichVu.ContentHeight = 16;
            this.cmbLoaiDichVu.DataMode = C1.Win.C1List.DataModeEnum.AddItem;
            this.cmbLoaiDichVu.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cmbLoaiDichVu.DefColWidth = 30;
            this.cmbLoaiDichVu.DisplayMember = "Danh mục";
            this.cmbLoaiDichVu.EditorBackColor = System.Drawing.Color.White;
            this.cmbLoaiDichVu.EditorFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLoaiDichVu.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbLoaiDichVu.EditorHeight = 16;
            this.cmbLoaiDichVu.EvenRowStyle = style2;
            this.cmbLoaiDichVu.ExtendRightColumn = true;
            this.cmbLoaiDichVu.FlatStyle = C1.Win.C1List.FlatModeEnum.Popup;
            this.cmbLoaiDichVu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLoaiDichVu.FooterStyle = style3;
            this.cmbLoaiDichVu.GapHeight = 2;
            this.cmbLoaiDichVu.HeadingStyle = style4;
            this.cmbLoaiDichVu.HighLightRowStyle = style5;
            this.cmbLoaiDichVu.ItemHeight = 15;
            this.cmbLoaiDichVu.Location = new System.Drawing.Point(123, 6);
            this.cmbLoaiDichVu.MatchCol = C1.Win.C1List.MatchColEnum.AllCols;
            this.cmbLoaiDichVu.MatchEntryTimeout = ((long)(2000));
            this.cmbLoaiDichVu.MaxDropDownItems = ((short)(10));
            this.cmbLoaiDichVu.MaxLength = 32767;
            this.cmbLoaiDichVu.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cmbLoaiDichVu.Name = "cmbLoaiDichVu";
            this.cmbLoaiDichVu.OddRowStyle = style6;
            this.cmbLoaiDichVu.PartialRightColumn = false;
            this.cmbLoaiDichVu.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.cmbLoaiDichVu.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.cmbLoaiDichVu.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cmbLoaiDichVu.SelectedStyle = style7;
            this.cmbLoaiDichVu.Size = new System.Drawing.Size(315, 20);
            this.cmbLoaiDichVu.Style = style8;
            this.cmbLoaiDichVu.TabIndex = 143;
            this.cmbLoaiDichVu.TextChanged += new System.EventHandler(this.cmbLoaiDichVu_TextChanged);
            this.cmbLoaiDichVu.PropBag = resources.GetString("cmbLoaiDichVu.PropBag");
            // 
            // label15
            // 
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label15.Location = new System.Drawing.Point(7, 6);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(118, 20);
            this.label15.TabIndex = 144;
            this.label15.Text = "*Loại dịch vụ";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // fgDichVu
            // 
            this.fgDichVu.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.fgDichVu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.fgDichVu.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Light3D;
            this.fgDichVu.ColumnInfo = resources.GetString("fgDichVu.ColumnInfo");
            this.fgDichVu.Cursor = System.Windows.Forms.Cursors.Default;
            this.fgDichVu.ExtendLastCol = true;
            this.fgDichVu.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None;
            this.fgDichVu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fgDichVu.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.fgDichVu.Location = new System.Drawing.Point(7, 29);
            this.fgDichVu.Name = "fgDichVu";
            this.fgDichVu.Rows.Count = 1;
            this.fgDichVu.Rows.MinSize = 20;
            this.fgDichVu.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox;
            this.fgDichVu.ShowCursor = true;
            this.fgDichVu.Size = new System.Drawing.Size(745, 330);
            this.fgDichVu.Styles = new C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("fgDichVu.Styles"));
            this.fgDichVu.TabIndex = 6;
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
            this.cmbKhoa.ContentHeight = 16;
            this.cmbKhoa.DataMode = C1.Win.C1List.DataModeEnum.AddItem;
            this.cmbKhoa.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cmbKhoa.DefColWidth = 30;
            this.cmbKhoa.DisplayMember = "Danh mục";
            this.cmbKhoa.EditorBackColor = System.Drawing.Color.White;
            this.cmbKhoa.EditorFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbKhoa.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbKhoa.EditorHeight = 16;
            this.cmbKhoa.EvenRowStyle = style10;
            this.cmbKhoa.ExtendRightColumn = true;
            this.cmbKhoa.FlatStyle = C1.Win.C1List.FlatModeEnum.Popup;
            this.cmbKhoa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbKhoa.FooterStyle = style11;
            this.cmbKhoa.GapHeight = 2;
            this.cmbKhoa.HeadingStyle = style12;
            this.cmbKhoa.HighLightRowStyle = style13;
            this.cmbKhoa.ItemHeight = 15;
            this.cmbKhoa.Location = new System.Drawing.Point(84, 2);
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
            this.cmbKhoa.Size = new System.Drawing.Size(333, 20);
            this.cmbKhoa.Style = style16;
            this.cmbKhoa.TabIndex = 124;
            this.cmbKhoa.TextChanged += new System.EventHandler(this.cmbKhoa_TextChanged);
            this.cmbKhoa.PropBag = resources.GetString("cmbKhoa.PropBag");
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(12, 6);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 18);
            this.label12.TabIndex = 123;
            this.label12.Text = "Khoa điều trị";
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(661, 461);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(91, 29);
            this.button2.TabIndex = 125;
            this.button2.Text = "Thoát";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // frmDatChiPhi_Khoa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 491);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.cmbKhoa);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDatChiPhi_Khoa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Đặt các dịch vụ y tế theo Khoa";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmDatChiPhi_Khoa_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fgLoaiDichVu)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmbLoaiDichVu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fgDichVu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKhoa)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private C1.Win.C1FlexGrid.C1FlexGrid fgLoaiDichVu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        internal C1.Win.C1List.C1Combo cmbLoaiDichVu;
        private System.Windows.Forms.Label label15;
        private C1.Win.C1FlexGrid.C1FlexGrid fgDichVu;
        internal C1.Win.C1List.C1Combo cmbKhoa;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button cmdGhiLoaiDichVu;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}