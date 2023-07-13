namespace NamDinh_QLBN.Forms.DuLieu
{
    partial class frmKhamChuyenKhoa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKhamChuyenKhoa));
            C1.Win.C1List.Style style9 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style10 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style11 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style12 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style13 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style14 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style15 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style16 = new C1.Win.C1List.Style();
            this.label1 = new System.Windows.Forms.Label();
            this.txtChanDoan = new System.Windows.Forms.TextBox();
            this.txtKinhGui = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtYeuCauKham = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdThoat = new System.Windows.Forms.Button();
            this.cmdGhi = new System.Windows.Forms.Button();
            this.cmbBacSyDT = new C1.Win.C1List.C1Combo();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNgayIn = new C1.Win.C1Input.C1DateEdit();
            this.label19 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBacSyDT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNgayIn)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 176;
            this.label1.Text = "Chẩn đoán:";
            // 
            // txtChanDoan
            // 
            this.txtChanDoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChanDoan.Location = new System.Drawing.Point(83, 85);
            this.txtChanDoan.Multiline = true;
            this.txtChanDoan.Name = "txtChanDoan";
            this.txtChanDoan.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtChanDoan.Size = new System.Drawing.Size(435, 36);
            this.txtChanDoan.TabIndex = 2;
            // 
            // txtKinhGui
            // 
            this.txtKinhGui.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKinhGui.Location = new System.Drawing.Point(83, 40);
            this.txtKinhGui.Multiline = true;
            this.txtKinhGui.Name = "txtKinhGui";
            this.txtKinhGui.Size = new System.Drawing.Size(435, 22);
            this.txtKinhGui.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 178;
            this.label2.Text = "Kính gửi:";
            // 
            // txtYeuCauKham
            // 
            this.txtYeuCauKham.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtYeuCauKham.Location = new System.Drawing.Point(83, 124);
            this.txtYeuCauKham.Multiline = true;
            this.txtYeuCauKham.Name = "txtYeuCauKham";
            this.txtYeuCauKham.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtYeuCauKham.Size = new System.Drawing.Size(435, 123);
            this.txtYeuCauKham.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 180;
            this.label3.Text = "Yêu cầu khám:";
            // 
            // cmdThoat
            // 
            this.cmdThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdThoat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdThoat.Image = ((System.Drawing.Image)(resources.GetObject("cmdThoat.Image")));
            this.cmdThoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdThoat.Location = new System.Drawing.Point(426, 253);
            this.cmdThoat.Name = "cmdThoat";
            this.cmdThoat.Size = new System.Drawing.Size(88, 27);
            this.cmdThoat.TabIndex = 5;
            this.cmdThoat.Text = "Thoát";
            this.cmdThoat.UseVisualStyleBackColor = true;
            this.cmdThoat.Click += new System.EventHandler(this.cmdThoat_Click);
            // 
            // cmdGhi
            // 
            this.cmdGhi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdGhi.Image = ((System.Drawing.Image)(resources.GetObject("cmdGhi.Image")));
            this.cmdGhi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdGhi.Location = new System.Drawing.Point(332, 253);
            this.cmdGhi.Name = "cmdGhi";
            this.cmdGhi.Size = new System.Drawing.Size(88, 27);
            this.cmdGhi.TabIndex = 4;
            this.cmdGhi.Text = "&Ghi";
            this.cmdGhi.UseVisualStyleBackColor = true;
            this.cmdGhi.Click += new System.EventHandler(this.cmdGhi_Click);
            // 
            // cmbBacSyDT
            // 
            this.cmbBacSyDT.AddItemSeparator = ';';
            this.cmbBacSyDT.AllowColMove = false;
            this.cmbBacSyDT.AllowRowSizing = C1.Win.C1List.RowSizingEnum.AllRows;
            this.cmbBacSyDT.AutoCompletion = true;
            this.cmbBacSyDT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cmbBacSyDT.Caption = "";
            this.cmbBacSyDT.CaptionHeight = 17;
            this.cmbBacSyDT.CaptionStyle = style9;
            this.cmbBacSyDT.CaptionVisible = false;
            this.cmbBacSyDT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cmbBacSyDT.ColumnCaptionHeight = 17;
            this.cmbBacSyDT.ColumnFooterHeight = 17;
            this.cmbBacSyDT.ColumnHeaders = false;
            this.cmbBacSyDT.ContentHeight = 17;
            this.cmbBacSyDT.DataMode = C1.Win.C1List.DataModeEnum.AddItem;
            this.cmbBacSyDT.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cmbBacSyDT.DefColWidth = 1;
            this.cmbBacSyDT.DisplayMember = "Danh mục";
            this.cmbBacSyDT.EditorBackColor = System.Drawing.Color.White;
            this.cmbBacSyDT.EditorFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBacSyDT.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbBacSyDT.EditorHeight = 17;
            this.cmbBacSyDT.EvenRowStyle = style10;
            this.cmbBacSyDT.ExtendRightColumn = true;
            this.cmbBacSyDT.FlatStyle = C1.Win.C1List.FlatModeEnum.Popup;
            this.cmbBacSyDT.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBacSyDT.FooterStyle = style11;
            this.cmbBacSyDT.GapHeight = 2;
            this.cmbBacSyDT.HeadingStyle = style12;
            this.cmbBacSyDT.HighLightRowStyle = style13;
            this.cmbBacSyDT.ItemHeight = 15;
            this.cmbBacSyDT.Location = new System.Drawing.Point(83, 63);
            this.cmbBacSyDT.MatchCol = C1.Win.C1List.MatchColEnum.AllCols;
            this.cmbBacSyDT.MatchEntryTimeout = ((long)(2000));
            this.cmbBacSyDT.MaxDropDownItems = ((short)(30));
            this.cmbBacSyDT.MaxLength = 32767;
            this.cmbBacSyDT.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cmbBacSyDT.Name = "cmbBacSyDT";
            this.cmbBacSyDT.OddRowStyle = style14;
            this.cmbBacSyDT.PartialRightColumn = false;
            this.cmbBacSyDT.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.cmbBacSyDT.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.cmbBacSyDT.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cmbBacSyDT.SelectedStyle = style15;
            this.cmbBacSyDT.Size = new System.Drawing.Size(187, 21);
            this.cmbBacSyDT.Style = style16;
            this.cmbBacSyDT.TabIndex = 1;
            this.cmbBacSyDT.PropBag = resources.GetString("cmbBacSyDT.PropBag");
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(6, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 15);
            this.label5.TabIndex = 193;
            this.label5.Text = "Bác sĩ ĐT";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNgayIn
            // 
            this.txtNgayIn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNgayIn.Culture = 1066;
            this.txtNgayIn.CustomFormat = "dd/MM/yyyy";
            this.txtNgayIn.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
            this.txtNgayIn.Location = new System.Drawing.Point(385, 65);
            this.txtNgayIn.Name = "txtNgayIn";
            this.txtNgayIn.Size = new System.Drawing.Size(133, 18);
            this.txtNgayIn.TabIndex = 195;
            this.txtNgayIn.Tag = null;
            this.txtNgayIn.Value = new System.DateTime(((long)(0)));
            // 
            // label19
            // 
            this.label19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label19.Location = new System.Drawing.Point(335, 64);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(44, 19);
            this.label19.TabIndex = 194;
            this.label19.Text = "Ngày In";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.BackColor = System.Drawing.Color.LightCyan;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(-1, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(529, 30);
            this.label4.TabIndex = 182;
            this.label4.Text = "Cập nhật thông tin";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmKhamChuyenKhoa
            // 
            this.AcceptButton = this.cmdGhi;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdThoat;
            this.ClientSize = new System.Drawing.Size(526, 292);
            this.Controls.Add(this.txtNgayIn);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.cmbBacSyDT);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtYeuCauKham);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtKinhGui);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtChanDoan);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdThoat);
            this.Controls.Add(this.cmdGhi);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmKhamChuyenKhoa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phiếu khám chuyên khoa";
            this.Load += new System.EventHandler(this.frmKhamChuyenKhoa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cmbBacSyDT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNgayIn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdThoat;
        private System.Windows.Forms.Button cmdGhi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtChanDoan;
        private System.Windows.Forms.TextBox txtKinhGui;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtYeuCauKham;
        private System.Windows.Forms.Label label3;
        internal C1.Win.C1List.C1Combo cmbBacSyDT;
        private System.Windows.Forms.Label label5;
        private C1.Win.C1Input.C1DateEdit txtNgayIn;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label4;
    }
}