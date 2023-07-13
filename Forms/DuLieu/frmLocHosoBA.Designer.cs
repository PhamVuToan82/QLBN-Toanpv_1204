namespace NamDinh_QLBN.Forms.DuLieu
{
    partial class frmLocHosoBA
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLocHosoBA));
            C1.Win.C1List.Style style9 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style10 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style11 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style12 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style13 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style14 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style15 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style16 = new C1.Win.C1List.Style();
            this.txtNgayChiDinh = new C1.Win.C1Input.C1DateEdit();
            this.label19 = new System.Windows.Forms.Label();
            this.btn_ChonNgay = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.fgDanhSach = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.fgDichVu = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.cmbLoaiDV = new C1.Win.C1List.C1Combo();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_ = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.chk_Ngay = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtNgayChiDinh)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fgDanhSach)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fgDichVu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLoaiDV)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNgayChiDinh
            // 
            this.txtNgayChiDinh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNgayChiDinh.Culture = 1066;
            this.txtNgayChiDinh.CustomFormat = "dd/MM/yyyy";
            this.txtNgayChiDinh.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
            this.txtNgayChiDinh.Location = new System.Drawing.Point(6, 29);
            this.txtNgayChiDinh.Name = "txtNgayChiDinh";
            this.txtNgayChiDinh.Size = new System.Drawing.Size(133, 18);
            this.txtNgayChiDinh.TabIndex = 154;
            this.txtNgayChiDinh.Tag = null;
            // 
            // label19
            // 
            this.label19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label19.Location = new System.Drawing.Point(3, 4);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(106, 19);
            this.label19.TabIndex = 155;
            this.label19.Text = "*Ngày, giờ chỉ định";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_ChonNgay
            // 
            this.btn_ChonNgay.Location = new System.Drawing.Point(166, 25);
            this.btn_ChonNgay.Name = "btn_ChonNgay";
            this.btn_ChonNgay.Size = new System.Drawing.Size(75, 23);
            this.btn_ChonNgay.TabIndex = 296;
            this.btn_ChonNgay.Text = "Chọn Ngày";
            this.btn_ChonNgay.UseVisualStyleBackColor = true;
            this.btn_ChonNgay.Click += new System.EventHandler(this.btn_ChonNgay_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(342, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(169, 20);
            this.textBox1.TabIndex = 297;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 525);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(71, 63);
            this.button1.TabIndex = 298;
            this.button1.Text = "TỔNG HỢP";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.fgDanhSach);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(362, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(745, 591);
            this.panel2.TabIndex = 300;
            // 
            // fgDanhSach
            // 
            this.fgDanhSach.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.fgDanhSach.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Light3D;
            this.fgDanhSach.ColumnInfo = resources.GetString("fgDanhSach.ColumnInfo");
            this.fgDanhSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fgDanhSach.ExtendLastCol = true;
            this.fgDanhSach.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid;
            this.fgDanhSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fgDanhSach.Location = new System.Drawing.Point(0, 0);
            this.fgDanhSach.Name = "fgDanhSach";
            this.fgDanhSach.Rows.Count = 1;
            this.fgDanhSach.Rows.MinSize = 20;
            this.fgDanhSach.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox;
            this.fgDanhSach.ShowCursor = true;
            this.fgDanhSach.Size = new System.Drawing.Size(745, 591);
            this.fgDanhSach.Styles = new C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("fgDanhSach.Styles"));
            this.fgDanhSach.TabIndex = 299;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(3, 53);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(353, 62);
            this.textBox2.TabIndex = 300;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chk_Ngay);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.fgDichVu);
            this.panel1.Controls.Add(this.cmbLoaiDV);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btn_);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.txtNgayChiDinh);
            this.panel1.Controls.Add(this.btn_ChonNgay);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(362, 591);
            this.panel1.TabIndex = 299;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(156, 525);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(61, 63);
            this.button5.TabIndex = 312;
            this.button5.Text = "IMPORT EXEL";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(281, 24);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 311;
            this.button4.Text = "Xóa Dịch Vụ";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // fgDichVu
            // 
            this.fgDichVu.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.fgDichVu.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Light3D;
            this.fgDichVu.ColumnInfo = resources.GetString("fgDichVu.ColumnInfo");
            this.fgDichVu.ExtendLastCol = true;
            this.fgDichVu.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid;
            this.fgDichVu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fgDichVu.Location = new System.Drawing.Point(6, 145);
            this.fgDichVu.Name = "fgDichVu";
            this.fgDichVu.Rows.Count = 1;
            this.fgDichVu.Rows.MinSize = 20;
            this.fgDichVu.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox;
            this.fgDichVu.ShowCursor = true;
            this.fgDichVu.Size = new System.Drawing.Size(350, 374);
            this.fgDichVu.Styles = new C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("fgDichVu.Styles"));
            this.fgDichVu.TabIndex = 310;
            this.fgDichVu.AfterEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.fgDichVu_AfterEdit);
            this.fgDichVu.Click += new System.EventHandler(this.fgDichVu_Click);
            // 
            // cmbLoaiDV
            // 
            this.cmbLoaiDV.AddItemSeparator = ';';
            this.cmbLoaiDV.AllowColMove = false;
            this.cmbLoaiDV.AllowRowSizing = C1.Win.C1List.RowSizingEnum.AllRows;
            this.cmbLoaiDV.AutoCompletion = true;
            this.cmbLoaiDV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cmbLoaiDV.Caption = "";
            this.cmbLoaiDV.CaptionHeight = 17;
            this.cmbLoaiDV.CaptionStyle = style9;
            this.cmbLoaiDV.CaptionVisible = false;
            this.cmbLoaiDV.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cmbLoaiDV.ColumnCaptionHeight = 17;
            this.cmbLoaiDV.ColumnFooterHeight = 17;
            this.cmbLoaiDV.ColumnHeaders = false;
            this.cmbLoaiDV.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList;
            this.cmbLoaiDV.ContentHeight = 16;
            this.cmbLoaiDV.DataMode = C1.Win.C1List.DataModeEnum.AddItem;
            this.cmbLoaiDV.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cmbLoaiDV.DefColWidth = 30;
            this.cmbLoaiDV.DisplayMember = "Danh mục";
            this.cmbLoaiDV.EditorBackColor = System.Drawing.Color.White;
            this.cmbLoaiDV.EditorFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLoaiDV.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbLoaiDV.EditorHeight = 16;
            this.cmbLoaiDV.EvenRowStyle = style10;
            this.cmbLoaiDV.ExtendRightColumn = true;
            this.cmbLoaiDV.FlatStyle = C1.Win.C1List.FlatModeEnum.Popup;
            this.cmbLoaiDV.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLoaiDV.FooterStyle = style11;
            this.cmbLoaiDV.GapHeight = 2;
            this.cmbLoaiDV.HeadingStyle = style12;
            this.cmbLoaiDV.HighLightRowStyle = style13;
            this.cmbLoaiDV.ItemHeight = 15;
            this.cmbLoaiDV.Location = new System.Drawing.Point(74, 119);
            this.cmbLoaiDV.MatchCol = C1.Win.C1List.MatchColEnum.AllCols;
            this.cmbLoaiDV.MatchEntryTimeout = ((long)(2000));
            this.cmbLoaiDV.MaxDropDownItems = ((short)(10));
            this.cmbLoaiDV.MaxLength = 32767;
            this.cmbLoaiDV.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cmbLoaiDV.Name = "cmbLoaiDV";
            this.cmbLoaiDV.OddRowStyle = style14;
            this.cmbLoaiDV.PartialRightColumn = false;
            this.cmbLoaiDV.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.cmbLoaiDV.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.cmbLoaiDV.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cmbLoaiDV.SelectedStyle = style15;
            this.cmbLoaiDV.Size = new System.Drawing.Size(282, 20);
            this.cmbLoaiDV.Style = style16;
            this.cmbLoaiDV.TabIndex = 309;
            this.cmbLoaiDV.TextChanged += new System.EventHandler(this.cmbLoaiDV_TextChanged);
            this.cmbLoaiDV.PropBag = resources.GetString("cmbLoaiDV.PropBag");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 306;
            this.label1.Text = "Loại Dịch Vụ";
            // 
            // btn_
            // 
            this.btn_.Location = new System.Drawing.Point(80, 525);
            this.btn_.Name = "btn_";
            this.btn_.Size = new System.Drawing.Size(73, 63);
            this.btn_.TabIndex = 303;
            this.btn_.Text = "TỔNG HỢP THEO DỊCH VỤ";
            this.btn_.UseVisualStyleBackColor = true;
            this.btn_.Click += new System.EventHandler(this.btn_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(282, 525);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(74, 63);
            this.button3.TabIndex = 302;
            this.button3.Text = "IN";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(219, 525);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(60, 63);
            this.button2.TabIndex = 301;
            this.button2.Text = "EXPORT EXEL";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // chk_Ngay
            // 
            this.chk_Ngay.AutoSize = true;
            this.chk_Ngay.Location = new System.Drawing.Point(145, 31);
            this.chk_Ngay.Name = "chk_Ngay";
            this.chk_Ngay.Size = new System.Drawing.Size(15, 14);
            this.chk_Ngay.TabIndex = 313;
            this.chk_Ngay.UseVisualStyleBackColor = true;
            // 
            // frmLocHosoBA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1107, 591);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBox1);
            this.Name = "frmLocHosoBA";
            this.Text = "frmLocHosoBA";
            this.Load += new System.EventHandler(this.frmLocHosoBA_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtNgayChiDinh)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fgDanhSach)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fgDichVu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLoaiDV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private C1.Win.C1Input.C1DateEdit txtNgayChiDinh;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button btn_ChonNgay;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel2;
        private C1.Win.C1FlexGrid.C1FlexGrid fgDanhSach;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        internal C1.Win.C1List.C1Combo cmbLoaiDV;
        private C1.Win.C1FlexGrid.C1FlexGrid fgDichVu;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.CheckBox chk_Ngay;
    }
}