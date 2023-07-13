namespace NamDinh_QLBN.Forms.DuLieu
{
    partial class FrmHoanTien
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmHoanTien));
            this.fgDichVu = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.label1 = new System.Windows.Forms.Label();
            this.txtKhoa = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtGioi = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTuoi = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTienHoan = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnHoanTien = new System.Windows.Forms.Button();
            this.DateNgayHoan = new C1.Win.C1Input.C1DateEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.btnthoat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.fgDichVu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateNgayHoan)).BeginInit();
            this.SuspendLayout();
            // 
            // fgDichVu
            // 
            this.fgDichVu.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.fgDichVu.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.MultiColumn;
            this.fgDichVu.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Light3D;
            this.fgDichVu.ColumnInfo = resources.GetString("fgDichVu.ColumnInfo");
            this.fgDichVu.ExtendLastCol = true;
            this.fgDichVu.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid;
            this.fgDichVu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fgDichVu.Location = new System.Drawing.Point(-1, 3);
            this.fgDichVu.Name = "fgDichVu";
            this.fgDichVu.Rows.Count = 1;
            this.fgDichVu.Rows.MinSize = 20;
            this.fgDichVu.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox;
            this.fgDichVu.ShowCursor = true;
            this.fgDichVu.Size = new System.Drawing.Size(525, 254);
            this.fgDichVu.Styles = new C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("fgDichVu.Styles"));
            this.fgDichVu.TabIndex = 135;
            this.fgDichVu.AfterEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.fgDichVu_AfterEdit);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(530, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 15);
            this.label1.TabIndex = 136;
            // 
            // txtKhoa
            // 
            this.txtKhoa.Location = new System.Drawing.Point(588, 50);
            this.txtKhoa.Name = "txtKhoa";
            this.txtKhoa.ReadOnly = true;
            this.txtKhoa.Size = new System.Drawing.Size(359, 20);
            this.txtKhoa.TabIndex = 163;
            this.txtKhoa.TabStop = false;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(531, 53);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 15);
            this.label8.TabIndex = 162;
            this.label8.Text = "Khoa";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(588, 28);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.ReadOnly = true;
            this.txtDiaChi.Size = new System.Drawing.Size(357, 20);
            this.txtDiaChi.TabIndex = 161;
            this.txtDiaChi.TabStop = false;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(531, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 15);
            this.label7.TabIndex = 160;
            this.label7.Text = "Địa Chỉ";
            // 
            // txtGioi
            // 
            this.txtGioi.Location = new System.Drawing.Point(914, 5);
            this.txtGioi.Name = "txtGioi";
            this.txtGioi.ReadOnly = true;
            this.txtGioi.Size = new System.Drawing.Size(30, 20);
            this.txtGioi.TabIndex = 159;
            this.txtGioi.TabStop = false;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(860, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 15);
            this.label5.TabIndex = 158;
            this.label5.Text = "Giới tính";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTuoi
            // 
            this.txtTuoi.Location = new System.Drawing.Point(810, 5);
            this.txtTuoi.Name = "txtTuoi";
            this.txtTuoi.ReadOnly = true;
            this.txtTuoi.Size = new System.Drawing.Size(47, 20);
            this.txtTuoi.TabIndex = 157;
            this.txtTuoi.TabStop = false;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(786, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 15);
            this.label4.TabIndex = 156;
            this.label4.Text = "NS";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(588, 6);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.ReadOnly = true;
            this.txtHoTen.Size = new System.Drawing.Size(189, 20);
            this.txtHoTen.TabIndex = 155;
            this.txtHoTen.TabStop = false;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(531, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 15);
            this.label6.TabIndex = 154;
            this.label6.Text = "Họ và tên";
            // 
            // txtTienHoan
            // 
            this.txtTienHoan.Location = new System.Drawing.Point(587, 100);
            this.txtTienHoan.Name = "txtTienHoan";
            this.txtTienHoan.ReadOnly = true;
            this.txtTienHoan.Size = new System.Drawing.Size(141, 20);
            this.txtTienHoan.TabIndex = 166;
            this.txtTienHoan.TabStop = false;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(530, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 15);
            this.label2.TabIndex = 165;
            this.label2.Text = "Tiền Hoàn";
            // 
            // btnHoanTien
            // 
            this.btnHoanTien.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.btnHoanTien.Location = new System.Drawing.Point(587, 126);
            this.btnHoanTien.Name = "btnHoanTien";
            this.btnHoanTien.Size = new System.Drawing.Size(87, 44);
            this.btnHoanTien.TabIndex = 167;
            this.btnHoanTien.Text = "Xác Nhận";
            this.btnHoanTien.UseVisualStyleBackColor = true;
            this.btnHoanTien.Click += new System.EventHandler(this.btnHoanTien_Click);
            // 
            // DateNgayHoan
            // 
            this.DateNgayHoan.BackColor = System.Drawing.Color.White;
            this.DateNgayHoan.Culture = 1066;
            this.DateNgayHoan.CustomFormat = "dd/MM/yyyy HH:mm";
            this.DateNgayHoan.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
            this.DateNgayHoan.Location = new System.Drawing.Point(810, 100);
            this.DateNgayHoan.Name = "DateNgayHoan";
            this.DateNgayHoan.Size = new System.Drawing.Size(134, 20);
            this.DateNgayHoan.TabIndex = 168;
            this.DateNgayHoan.Tag = null;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(744, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 15);
            this.label3.TabIndex = 169;
            this.label3.Text = "Ngày Hoàn";
            // 
            // btnthoat
            // 
            this.btnthoat.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.btnthoat.Location = new System.Drawing.Point(690, 126);
            this.btnthoat.Name = "btnthoat";
            this.btnthoat.Size = new System.Drawing.Size(87, 44);
            this.btnthoat.TabIndex = 170;
            this.btnthoat.Text = "Thoát";
            this.btnthoat.UseVisualStyleBackColor = true;
            this.btnthoat.Click += new System.EventHandler(this.btnthoat_Click);
            // 
            // FrmHoanTien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 264);
            this.Controls.Add(this.btnthoat);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DateNgayHoan);
            this.Controls.Add(this.btnHoanTien);
            this.Controls.Add(this.txtTienHoan);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtKhoa);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtDiaChi);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtGioi);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTuoi);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtHoTen);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fgDichVu);
            this.Name = "FrmHoanTien";
            this.Text = "FrmHoanTien";
            this.Load += new System.EventHandler(this.FrmHoanTien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fgDichVu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateNgayHoan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private C1.Win.C1FlexGrid.C1FlexGrid fgDichVu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtKhoa;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtGioi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTuoi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTienHoan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnHoanTien;
        private C1.Win.C1Input.C1DateEdit DateNgayHoan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnthoat;
    }
}