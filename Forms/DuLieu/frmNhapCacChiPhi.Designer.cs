namespace NamDinh_QLBN.Forms.DuLieu
{
    partial class frmNhapCacChiPhi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNhapCacChiPhi));
            C1.Win.C1List.Style style2 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style3 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style4 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style5 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style6 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style7 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style8 = new C1.Win.C1List.Style();
            this.cmbLoaiCP = new C1.Win.C1List.C1Combo();
            this.label17 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.fgDanhMuc = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.txtTenChiPhi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.treeCLS = new System.Windows.Forms.TreeView();
            this.lblTen = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSL = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLoaiCP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fgDanhMuc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSL)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbLoaiCP
            // 
            this.cmbLoaiCP.AddItemSeparator = ';';
            this.cmbLoaiCP.AllowColMove = false;
            this.cmbLoaiCP.AllowRowSizing = C1.Win.C1List.RowSizingEnum.AllRows;
            this.cmbLoaiCP.AutoCompletion = true;
            this.cmbLoaiCP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cmbLoaiCP.Caption = "";
            this.cmbLoaiCP.CaptionHeight = 17;
            this.cmbLoaiCP.CaptionStyle = style1;
            this.cmbLoaiCP.CaptionVisible = false;
            this.cmbLoaiCP.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cmbLoaiCP.ColumnCaptionHeight = 17;
            this.cmbLoaiCP.ColumnFooterHeight = 17;
            this.cmbLoaiCP.ColumnHeaders = false;
            this.cmbLoaiCP.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList;
            this.cmbLoaiCP.ContentHeight = 16;
            this.cmbLoaiCP.DataMode = C1.Win.C1List.DataModeEnum.AddItem;
            this.cmbLoaiCP.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cmbLoaiCP.DefColWidth = 1;
            this.cmbLoaiCP.DisplayMember = "Danh mục";
            this.cmbLoaiCP.EditorBackColor = System.Drawing.Color.White;
            this.cmbLoaiCP.EditorFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLoaiCP.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbLoaiCP.EditorHeight = 16;
            this.cmbLoaiCP.EvenRowStyle = style2;
            this.cmbLoaiCP.ExtendRightColumn = true;
            this.cmbLoaiCP.FlatStyle = C1.Win.C1List.FlatModeEnum.Popup;
            this.cmbLoaiCP.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLoaiCP.FooterStyle = style3;
            this.cmbLoaiCP.GapHeight = 2;
            this.cmbLoaiCP.HeadingStyle = style4;
            this.cmbLoaiCP.HighLightRowStyle = style5;
            this.cmbLoaiCP.ItemHeight = 15;
            this.cmbLoaiCP.Location = new System.Drawing.Point(50, 2);
            this.cmbLoaiCP.MatchCol = C1.Win.C1List.MatchColEnum.AllCols;
            this.cmbLoaiCP.MatchEntryTimeout = ((long)(2000));
            this.cmbLoaiCP.MaxDropDownItems = ((short)(10));
            this.cmbLoaiCP.MaxLength = 32767;
            this.cmbLoaiCP.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cmbLoaiCP.Name = "cmbLoaiCP";
            this.cmbLoaiCP.OddRowStyle = style6;
            this.cmbLoaiCP.PartialRightColumn = false;
            this.cmbLoaiCP.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.cmbLoaiCP.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.cmbLoaiCP.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cmbLoaiCP.SelectedStyle = style7;
            this.cmbLoaiCP.Size = new System.Drawing.Size(259, 20);
            this.cmbLoaiCP.Style = style8;
            this.cmbLoaiCP.TabIndex = 1;
            this.cmbLoaiCP.TextChanged += new System.EventHandler(this.cmbLoaiCP_TextChanged);
            this.cmbLoaiCP.PropBag = resources.GetString("cmbLoaiCP.PropBag");
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(1, 5);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(72, 15);
            this.label17.TabIndex = 1;
            this.label17.Text = "&Loại CP";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "&Tên CP";
            // 
            // fgDanhMuc
            // 
            this.fgDanhMuc.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.fgDanhMuc.AllowEditing = false;
            this.fgDanhMuc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.fgDanhMuc.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Light3D;
            this.fgDanhMuc.ColumnInfo = resources.GetString("fgDanhMuc.ColumnInfo");
            this.fgDanhMuc.ExtendLastCol = true;
            this.fgDanhMuc.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None;
            this.fgDanhMuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fgDanhMuc.HighLight = C1.Win.C1FlexGrid.HighLightEnum.WithFocus;
            this.fgDanhMuc.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.fgDanhMuc.Location = new System.Drawing.Point(1, 49);
            this.fgDanhMuc.Name = "fgDanhMuc";
            this.fgDanhMuc.Rows.Count = 1;
            this.fgDanhMuc.Rows.MinSize = 20;
            this.fgDanhMuc.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox;
            this.fgDanhMuc.ShowCursor = true;
            this.fgDanhMuc.Size = new System.Drawing.Size(310, 367);
            this.fgDanhMuc.Styles = new C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("fgDanhMuc.Styles"));
            this.fgDanhMuc.TabIndex = 3;
            this.fgDanhMuc.AfterSelChange += new C1.Win.C1FlexGrid.RangeEventHandler(this.fgDanhMuc_AfterSelChange);
            this.fgDanhMuc.Enter += new System.EventHandler(this.fgDanhMuc_Enter);
            this.fgDanhMuc.DoubleClick += new System.EventHandler(this.fgDanhMuc_DoubleClick);
            this.fgDanhMuc.KeyUp += new System.Windows.Forms.KeyEventHandler(this.fgDanhMuc_KeyUp_1);
            // 
            // txtTenChiPhi
            // 
            this.txtTenChiPhi.Location = new System.Drawing.Point(50, 24);
            this.txtTenChiPhi.Name = "txtTenChiPhi";
            this.txtTenChiPhi.Size = new System.Drawing.Size(184, 20);
            this.txtTenChiPhi.TabIndex = 2;
            this.txtTenChiPhi.TextChanged += new System.EventHandler(this.txtTenChiPhi_TextChanged);
            this.txtTenChiPhi.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtTenChiPhi_KeyUp);
            this.txtTenChiPhi.Enter += new System.EventHandler(this.txtTenChiPhi_Enter);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label2.Location = new System.Drawing.Point(-2, 439);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(311, 26);
            this.label2.TabIndex = 118;
            this.label2.Text = "Chọn chi phí rồi nhấn <ENTER> để thêm vào danh sách - <ESC>  để đóng cửa sổ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // treeCLS
            // 
            this.treeCLS.HotTracking = true;
            this.treeCLS.Location = new System.Drawing.Point(2, 23);
            this.treeCLS.Name = "treeCLS";
            this.treeCLS.Size = new System.Drawing.Size(307, 393);
            this.treeCLS.TabIndex = 4;
            this.treeCLS.Visible = false;
            this.treeCLS.DoubleClick += new System.EventHandler(this.treeCLS_DoubleClick);
            this.treeCLS.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeCLS_AfterSelect);
            this.treeCLS.KeyUp += new System.Windows.Forms.KeyEventHandler(this.treeCLS_KeyUp);
            // 
            // lblTen
            // 
            this.lblTen.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTen.Location = new System.Drawing.Point(2, 418);
            this.lblTen.Name = "lblTen";
            this.lblTen.Size = new System.Drawing.Size(307, 21);
            this.lblTen.TabIndex = 119;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(237, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 120;
            this.label3.Text = "SL";
            // 
            // txtSL
            // 
            this.txtSL.Location = new System.Drawing.Point(263, 24);
            this.txtSL.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.txtSL.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtSL.Name = "txtSL";
            this.txtSL.Size = new System.Drawing.Size(46, 20);
            this.txtSL.TabIndex = 5;
            this.txtSL.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtSL.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSL_KeyUp);
            this.txtSL.Enter += new System.EventHandler(this.txtSL_Enter);
            // 
            // frmNhapCacChiPhi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 465);
            this.Controls.Add(this.txtSL);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblTen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbLoaiCP);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTenChiPhi);
            this.Controls.Add(this.fgDanhMuc);
            this.Controls.Add(this.treeCLS);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNhapCacChiPhi";
            this.Text = "Cập nhật chi phí điều trị";
            this.Load += new System.EventHandler(this.frmNhapCacChiPhi_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmNhapCacChiPhi_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.cmbLoaiCP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fgDanhMuc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSL)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal C1.Win.C1List.C1Combo cmbLoaiCP;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label1;
        private C1.Win.C1FlexGrid.C1FlexGrid fgDanhMuc;
        private System.Windows.Forms.TextBox txtTenChiPhi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TreeView treeCLS;
        private System.Windows.Forms.Label lblTen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown txtSL;
    }
}