namespace NamDinh_QLBN.Forms.DuLieu
{
    partial class frmChuyenKhoa_ChuyenDien
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChuyenKhoa_ChuyenDien));
            C1.Win.C1List.Style style2 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style3 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style4 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style5 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style6 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style7 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style8 = new C1.Win.C1List.Style();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdDanhSachBN = new System.Windows.Forms.Button();
            this.txtMaVaoVien = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNgayVaoVien = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtMaBenhAn = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtGioi = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTuoi = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDoiTuong = new System.Windows.Forms.TextBox();
            this.cmbKhoa = new C1.Win.C1List.C1Combo();
            this.label12 = new System.Windows.Forms.Label();
            this.fgKhoa = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.fgDoiTuong = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cmdChuyenKhoa = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKhoa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fgKhoa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fgDoiTuong)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cmdDanhSachBN);
            this.panel1.Controls.Add(this.txtMaVaoVien);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtNgayVaoVien);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.txtMaBenhAn);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.txtGioi);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtTuoi);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtHoTen);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtDoiTuong);
            this.panel1.Location = new System.Drawing.Point(3, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(428, 110);
            this.panel1.TabIndex = 130;
            // 
            // cmdDanhSachBN
            // 
            this.cmdDanhSachBN.Location = new System.Drawing.Point(187, 3);
            this.cmdDanhSachBN.Name = "cmdDanhSachBN";
            this.cmdDanhSachBN.Size = new System.Drawing.Size(134, 23);
            this.cmdDanhSachBN.TabIndex = 162;
            this.cmdDanhSachBN.Text = "Danh sách bệnh nhân";
            this.cmdDanhSachBN.UseVisualStyleBackColor = true;
            this.cmdDanhSachBN.Click += new System.EventHandler(this.cmdDanhSachBN_Click);
            // 
            // txtMaVaoVien
            // 
            this.txtMaVaoVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaVaoVien.ForeColor = System.Drawing.Color.Red;
            this.txtMaVaoVien.Location = new System.Drawing.Point(81, 5);
            this.txtMaVaoVien.Name = "txtMaVaoVien";
            this.txtMaVaoVien.Size = new System.Drawing.Size(100, 20);
            this.txtMaVaoVien.TabIndex = 161;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(2, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 15);
            this.label6.TabIndex = 160;
            this.label6.Text = "Mã vào viện";
            // 
            // txtNgayVaoVien
            // 
            this.txtNgayVaoVien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtNgayVaoVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNgayVaoVien.ForeColor = System.Drawing.Color.Navy;
            this.txtNgayVaoVien.Location = new System.Drawing.Point(291, 83);
            this.txtNgayVaoVien.Name = "txtNgayVaoVien";
            this.txtNgayVaoVien.ReadOnly = true;
            this.txtNgayVaoVien.Size = new System.Drawing.Size(79, 20);
            this.txtNgayVaoVien.TabIndex = 159;
            this.txtNgayVaoVien.TabStop = false;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(202, 86);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(83, 15);
            this.label16.TabIndex = 158;
            this.label16.Text = "Ngày vào viện";
            this.label16.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtMaBenhAn
            // 
            this.txtMaBenhAn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtMaBenhAn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaBenhAn.ForeColor = System.Drawing.Color.Navy;
            this.txtMaBenhAn.Location = new System.Drawing.Point(81, 31);
            this.txtMaBenhAn.Name = "txtMaBenhAn";
            this.txtMaBenhAn.ReadOnly = true;
            this.txtMaBenhAn.Size = new System.Drawing.Size(100, 20);
            this.txtMaBenhAn.TabIndex = 156;
            this.txtMaBenhAn.TabStop = false;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(16, 86);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(57, 15);
            this.label13.TabIndex = 154;
            this.label13.Text = "Đối tượng";
            this.label13.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtGioi
            // 
            this.txtGioi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtGioi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGioi.ForeColor = System.Drawing.Color.Navy;
            this.txtGioi.Location = new System.Drawing.Point(375, 57);
            this.txtGioi.Name = "txtGioi";
            this.txtGioi.ReadOnly = true;
            this.txtGioi.Size = new System.Drawing.Size(36, 20);
            this.txtGioi.TabIndex = 153;
            this.txtGioi.TabStop = false;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(327, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 15);
            this.label5.TabIndex = 152;
            this.label5.Text = "Giới tính";
            // 
            // txtTuoi
            // 
            this.txtTuoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtTuoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTuoi.ForeColor = System.Drawing.Color.Navy;
            this.txtTuoi.Location = new System.Drawing.Point(291, 57);
            this.txtTuoi.Name = "txtTuoi";
            this.txtTuoi.ReadOnly = true;
            this.txtTuoi.Size = new System.Drawing.Size(30, 20);
            this.txtTuoi.TabIndex = 151;
            this.txtTuoi.TabStop = false;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(255, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 15);
            this.label3.TabIndex = 150;
            this.label3.Text = "Tuổi";
            // 
            // txtHoTen
            // 
            this.txtHoTen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtHoTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHoTen.ForeColor = System.Drawing.Color.Navy;
            this.txtHoTen.Location = new System.Drawing.Point(81, 57);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.ReadOnly = true;
            this.txtHoTen.Size = new System.Drawing.Size(165, 20);
            this.txtHoTen.TabIndex = 149;
            this.txtHoTen.TabStop = false;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 15);
            this.label2.TabIndex = 148;
            this.label2.Text = "Họ và tên";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(2, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 15);
            this.label4.TabIndex = 147;
            this.label4.Text = "Mã bệnh án";
            // 
            // txtDoiTuong
            // 
            this.txtDoiTuong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtDoiTuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDoiTuong.ForeColor = System.Drawing.Color.Navy;
            this.txtDoiTuong.Location = new System.Drawing.Point(81, 83);
            this.txtDoiTuong.Name = "txtDoiTuong";
            this.txtDoiTuong.ReadOnly = true;
            this.txtDoiTuong.Size = new System.Drawing.Size(102, 20);
            this.txtDoiTuong.TabIndex = 155;
            this.txtDoiTuong.TabStop = false;
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
            this.cmbKhoa.Location = new System.Drawing.Point(87, 1);
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
            this.cmbKhoa.Size = new System.Drawing.Size(344, 20);
            this.cmbKhoa.Style = style8;
            this.cmbKhoa.TabIndex = 129;
            this.cmbKhoa.PropBag = resources.GetString("cmbKhoa.PropBag");
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(15, 5);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 18);
            this.label12.TabIndex = 128;
            this.label12.Text = "Khoa điều trị";
            // 
            // fgKhoa
            // 
            this.fgKhoa.AllowDelete = true;
            this.fgKhoa.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.fgKhoa.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
            this.fgKhoa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.fgKhoa.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Light3D;
            this.fgKhoa.ColumnInfo = resources.GetString("fgKhoa.ColumnInfo");
            this.fgKhoa.ExtendLastCol = true;
            this.fgKhoa.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid;
            this.fgKhoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fgKhoa.Location = new System.Drawing.Point(6, 6);
            this.fgKhoa.Name = "fgKhoa";
            this.fgKhoa.Rows.Count = 1;
            this.fgKhoa.Rows.MinSize = 20;
            this.fgKhoa.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox;
            this.fgKhoa.ShowCursor = true;
            this.fgKhoa.Size = new System.Drawing.Size(411, 209);
            this.fgKhoa.Styles = new C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("fgKhoa.Styles"));
            this.fgKhoa.TabIndex = 131;
            // 
            // fgDoiTuong
            // 
            this.fgDoiTuong.AllowDelete = true;
            this.fgDoiTuong.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.fgDoiTuong.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
            this.fgDoiTuong.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.fgDoiTuong.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Light3D;
            this.fgDoiTuong.ColumnInfo = resources.GetString("fgDoiTuong.ColumnInfo");
            this.fgDoiTuong.ExtendLastCol = true;
            this.fgDoiTuong.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid;
            this.fgDoiTuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fgDoiTuong.Location = new System.Drawing.Point(6, 6);
            this.fgDoiTuong.Name = "fgDoiTuong";
            this.fgDoiTuong.Rows.Count = 1;
            this.fgDoiTuong.Rows.MinSize = 20;
            this.fgDoiTuong.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox;
            this.fgDoiTuong.ShowCursor = true;
            this.fgDoiTuong.Size = new System.Drawing.Size(411, 209);
            this.fgDoiTuong.Styles = new C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("fgDoiTuong.Styles"));
            this.fgDoiTuong.TabIndex = 132;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(3, 141);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(430, 271);
            this.tabControl1.TabIndex = 133;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cmdChuyenKhoa);
            this.tabPage1.Controls.Add(this.fgKhoa);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(422, 245);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Khoa Điều trị";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cmdChuyenKhoa
            // 
            this.cmdChuyenKhoa.Image = ((System.Drawing.Image)(resources.GetObject("cmdChuyenKhoa.Image")));
            this.cmdChuyenKhoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdChuyenKhoa.Location = new System.Drawing.Point(5, 216);
            this.cmdChuyenKhoa.Name = "cmdChuyenKhoa";
            this.cmdChuyenKhoa.Size = new System.Drawing.Size(133, 26);
            this.cmdChuyenKhoa.TabIndex = 132;
            this.cmdChuyenKhoa.Text = "    Chuyển Khoa điều trị";
            this.cmdChuyenKhoa.UseVisualStyleBackColor = true;
            this.cmdChuyenKhoa.Click += new System.EventHandler(this.cmdChuyenKhoa_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.fgDoiTuong);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(422, 245);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Đối tượng";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(5, 216);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(133, 26);
            this.button1.TabIndex = 133;
            this.button1.Text = "    Chuyển Đối tượng BN";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmChuyenKhoa_ChuyenDien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 447);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cmbKhoa);
            this.Controls.Add(this.label12);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChuyenKhoa_ChuyenDien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bệnh nhân chuyển khoa, chuyển diện";
            this.Load += new System.EventHandler(this.frmChuyenKhoa_ChuyenDien_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKhoa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fgKhoa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fgDoiTuong)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button cmdDanhSachBN;
        private System.Windows.Forms.TextBox txtMaVaoVien;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNgayVaoVien;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtMaBenhAn;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtGioi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTuoi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDoiTuong;
        internal C1.Win.C1List.C1Combo cmbKhoa;
        private System.Windows.Forms.Label label12;
        private C1.Win.C1FlexGrid.C1FlexGrid fgKhoa;
        private C1.Win.C1FlexGrid.C1FlexGrid fgDoiTuong;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button cmdChuyenKhoa;
        private System.Windows.Forms.Button button1;
    }
}