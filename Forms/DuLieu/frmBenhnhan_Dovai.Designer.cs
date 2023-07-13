namespace NamDinh_QLBN.Forms.DuLieu
{
    partial class frmBenhnhan_Dovai
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBenhnhan_Dovai));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.DateNgayKham = new C1.Win.C1Input.C1DateEdit();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDenNgay = new C1.Win.C1Input.C1DateEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTuNgay = new C1.Win.C1Input.C1DateEdit();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.fgDanhSach = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.txtNguoiNha = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.dateThoiGiangDangKy = new C1.Win.C1Input.C1DateEdit();
            this.btnTim = new System.Windows.Forms.Button();
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
            this.txtMaKhamBenh = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.fgDichVu = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnSoTongHop = new System.Windows.Forms.Button();
            this.btn_In = new System.Windows.Forms.Button();
            this.btnHoanTien = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtkyquy = new System.Windows.Forms.TextBox();
            this.btn_sua = new System.Windows.Forms.Button();
            this.btnGhi = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnThemMoi = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DateNgayKham)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDenNgay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTuNgay)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fgDanhSach)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateThoiGiangDangKy)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fgDichVu)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(430, 564);
            this.panel1.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label9);
            this.panel5.Controls.Add(this.DateNgayKham);
            this.panel5.Controls.Add(this.button1);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.txtDenNgay);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.txtTuNgay);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(430, 55);
            this.panel5.TabIndex = 146;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(184, 7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 18);
            this.label9.TabIndex = 152;
            this.label9.Text = "Ngày Khám";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // DateNgayKham
            // 
            this.DateNgayKham.BackColor = System.Drawing.Color.White;
            this.DateNgayKham.Culture = 1066;
            this.DateNgayKham.CustomFormat = "dd/MM/yyyy";
            this.DateNgayKham.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
            this.DateNgayKham.Location = new System.Drawing.Point(257, 6);
            this.DateNgayKham.Name = "DateNgayKham";
            this.DateNgayKham.Size = new System.Drawing.Size(156, 20);
            this.DateNgayKham.TabIndex = 151;
            this.DateNgayKham.Tag = null;
            this.DateNgayKham.ValueChanged += new System.EventHandler(this.DateNgayKham_ValueChanged);
            this.DateNgayKham.TextChanged += new System.EventHandler(this.DateNgayKham_TextChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.button1.Location = new System.Drawing.Point(187, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(226, 25);
            this.button1.TabIndex = 150;
            this.button1.Text = "Danh Sách";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 18);
            this.label3.TabIndex = 149;
            this.label3.Text = "Đến ngày";
            // 
            // txtDenNgay
            // 
            this.txtDenNgay.BackColor = System.Drawing.Color.White;
            this.txtDenNgay.Culture = 1066;
            this.txtDenNgay.CustomFormat = "dd/MM/yyyy";
            this.txtDenNgay.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
            this.txtDenNgay.Location = new System.Drawing.Point(57, 31);
            this.txtDenNgay.Name = "txtDenNgay";
            this.txtDenNgay.Size = new System.Drawing.Size(126, 20);
            this.txtDenNgay.TabIndex = 148;
            this.txtDenNgay.Tag = null;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(10, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 18);
            this.label2.TabIndex = 147;
            this.label2.Text = "Từ ngày";
            // 
            // txtTuNgay
            // 
            this.txtTuNgay.BackColor = System.Drawing.Color.White;
            this.txtTuNgay.Culture = 1066;
            this.txtTuNgay.CustomFormat = "dd/MM/yyyy";
            this.txtTuNgay.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
            this.txtTuNgay.Location = new System.Drawing.Point(57, 6);
            this.txtTuNgay.Name = "txtTuNgay";
            this.txtTuNgay.Size = new System.Drawing.Size(126, 20);
            this.txtTuNgay.TabIndex = 146;
            this.txtTuNgay.Tag = null;
            this.txtTuNgay.Value = new System.DateTime(((long)(0)));
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.fgDanhSach);
            this.groupBox1.Location = new System.Drawing.Point(0, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(430, 506);
            this.groupBox1.TabIndex = 143;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách bệnh nhân";
            // 
            // fgDanhSach
            // 
            this.fgDanhSach.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.fgDanhSach.AllowEditing = false;
            this.fgDanhSach.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.MultiColumn;
            this.fgDanhSach.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Light3D;
            this.fgDanhSach.ColumnInfo = resources.GetString("fgDanhSach.ColumnInfo");
            this.fgDanhSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fgDanhSach.ExtendLastCol = true;
            this.fgDanhSach.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid;
            this.fgDanhSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fgDanhSach.Location = new System.Drawing.Point(3, 16);
            this.fgDanhSach.Name = "fgDanhSach";
            this.fgDanhSach.Rows.Count = 1;
            this.fgDanhSach.Rows.MinSize = 20;
            this.fgDanhSach.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
            this.fgDanhSach.ShowCursor = true;
            this.fgDanhSach.Size = new System.Drawing.Size(424, 487);
            this.fgDanhSach.Styles = new C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("fgDanhSach.Styles"));
            this.fgDanhSach.TabIndex = 133;
            this.fgDanhSach.AfterEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.fgDanhSach_AfterEdit);
            this.fgDanhSach.ChangeEdit += new System.EventHandler(this.fgDanhSach_ChangeEdit);
            this.fgDanhSach.Click += new System.EventHandler(this.fgDanhSach_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.txtNguoiNha);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.dateThoiGiangDangKy);
            this.panel2.Controls.Add(this.btnTim);
            this.panel2.Controls.Add(this.txtKhoa);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.txtDiaChi);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.txtGioi);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtTuoi);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtHoTen);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtMaKhamBenh);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(430, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(927, 75);
            this.panel2.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(542, 33);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 15);
            this.label12.TabIndex = 156;
            this.label12.Text = "TG Đăng Ký";
            // 
            // txtNguoiNha
            // 
            this.txtNguoiNha.Location = new System.Drawing.Point(628, 50);
            this.txtNguoiNha.Name = "txtNguoiNha";
            this.txtNguoiNha.Size = new System.Drawing.Size(189, 20);
            this.txtNguoiNha.TabIndex = 155;
            this.txtNguoiNha.TabStop = false;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(543, 53);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 15);
            this.label11.TabIndex = 154;
            this.label11.Text = "Người Ký Qũy";
            // 
            // dateThoiGiangDangKy
            // 
            this.dateThoiGiangDangKy.BackColor = System.Drawing.Color.White;
            this.dateThoiGiangDangKy.Culture = 1066;
            this.dateThoiGiangDangKy.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dateThoiGiangDangKy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.dateThoiGiangDangKy.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
            this.dateThoiGiangDangKy.Location = new System.Drawing.Point(628, 26);
            this.dateThoiGiangDangKy.Name = "dateThoiGiangDangKy";
            this.dateThoiGiangDangKy.Size = new System.Drawing.Size(189, 23);
            this.dateThoiGiangDangKy.TabIndex = 153;
            this.dateThoiGiangDangKy.Tag = null;
            // 
            // btnTim
            // 
            this.btnTim.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.btnTim.Image = global::NamDinh_QLBN.Properties.Resources.Soi16;
            this.btnTim.Location = new System.Drawing.Point(18, 31);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(180, 37);
            this.btnTim.TabIndex = 108;
            this.btnTim.Text = "Tìm Bệnh Nhân";
            this.btnTim.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // txtKhoa
            // 
            this.txtKhoa.Location = new System.Drawing.Point(263, 50);
            this.txtKhoa.Name = "txtKhoa";
            this.txtKhoa.ReadOnly = true;
            this.txtKhoa.Size = new System.Drawing.Size(278, 20);
            this.txtKhoa.TabIndex = 107;
            this.txtKhoa.TabStop = false;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(206, 53);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 15);
            this.label8.TabIndex = 106;
            this.label8.Text = "Khoa";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(263, 28);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.ReadOnly = true;
            this.txtDiaChi.Size = new System.Drawing.Size(278, 20);
            this.txtDiaChi.TabIndex = 105;
            this.txtDiaChi.TabStop = false;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(206, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 15);
            this.label7.TabIndex = 104;
            this.label7.Text = "Địa Chỉ";
            // 
            // txtGioi
            // 
            this.txtGioi.Location = new System.Drawing.Point(771, 4);
            this.txtGioi.Name = "txtGioi";
            this.txtGioi.ReadOnly = true;
            this.txtGioi.Size = new System.Drawing.Size(46, 20);
            this.txtGioi.TabIndex = 103;
            this.txtGioi.TabStop = false;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(717, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 15);
            this.label5.TabIndex = 102;
            this.label5.Text = "Giới tính";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTuoi
            // 
            this.txtTuoi.Location = new System.Drawing.Point(628, 4);
            this.txtTuoi.Name = "txtTuoi";
            this.txtTuoi.ReadOnly = true;
            this.txtTuoi.Size = new System.Drawing.Size(83, 20);
            this.txtTuoi.TabIndex = 101;
            this.txtTuoi.TabStop = false;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(543, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 15);
            this.label4.TabIndex = 100;
            this.label4.Text = "Năm sinh";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(263, 6);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.ReadOnly = true;
            this.txtHoTen.Size = new System.Drawing.Size(278, 20);
            this.txtHoTen.TabIndex = 99;
            this.txtHoTen.TabStop = false;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(206, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 15);
            this.label6.TabIndex = 98;
            this.label6.Text = "Họ và tên";
            // 
            // txtMaKhamBenh
            // 
            this.txtMaKhamBenh.Location = new System.Drawing.Point(99, 5);
            this.txtMaKhamBenh.Name = "txtMaKhamBenh";
            this.txtMaKhamBenh.Size = new System.Drawing.Size(101, 20);
            this.txtMaKhamBenh.TabIndex = 97;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(15, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 15);
            this.label1.TabIndex = 96;
            this.label1.Text = "Mã Khám Bệnh";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.fgDichVu);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(430, 75);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(927, 435);
            this.panel3.TabIndex = 2;
            // 
            // fgDichVu
            // 
            this.fgDichVu.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.fgDichVu.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.MultiColumn;
            this.fgDichVu.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Light3D;
            this.fgDichVu.ColumnInfo = resources.GetString("fgDichVu.ColumnInfo");
            this.fgDichVu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fgDichVu.ExtendLastCol = true;
            this.fgDichVu.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid;
            this.fgDichVu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fgDichVu.Location = new System.Drawing.Point(0, 0);
            this.fgDichVu.Name = "fgDichVu";
            this.fgDichVu.Rows.Count = 1;
            this.fgDichVu.Rows.MinSize = 20;
            this.fgDichVu.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
            this.fgDichVu.Size = new System.Drawing.Size(927, 435);
            this.fgDichVu.Styles = new C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("fgDichVu.Styles"));
            this.fgDichVu.TabIndex = 134;
            this.fgDichVu.AfterEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.fgDichVu_AfterEdit);
            this.fgDichVu.BeforeDeleteRow += new C1.Win.C1FlexGrid.RowColEventHandler(this.fgDichVu_BeforeDeleteRow);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnSoTongHop);
            this.panel4.Controls.Add(this.btn_In);
            this.panel4.Controls.Add(this.btnHoanTien);
            this.panel4.Controls.Add(this.checkBox1);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.txtkyquy);
            this.panel4.Controls.Add(this.btn_sua);
            this.panel4.Controls.Add(this.btnGhi);
            this.panel4.Controls.Add(this.button2);
            this.panel4.Controls.Add(this.btnThemMoi);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(430, 510);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(927, 54);
            this.panel4.TabIndex = 3;
            // 
            // btnSoTongHop
            // 
            this.btnSoTongHop.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.btnSoTongHop.Image = global::NamDinh_QLBN.Properties.Resources.Print16;
            this.btnSoTongHop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSoTongHop.Location = new System.Drawing.Point(822, 6);
            this.btnSoTongHop.Name = "btnSoTongHop";
            this.btnSoTongHop.Size = new System.Drawing.Size(93, 44);
            this.btnSoTongHop.TabIndex = 157;
            this.btnSoTongHop.Text = "Báo Cáo";
            this.btnSoTongHop.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSoTongHop.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSoTongHop.UseVisualStyleBackColor = true;
            this.btnSoTongHop.Click += new System.EventHandler(this.btnSoTongHop_Click);
            // 
            // btn_In
            // 
            this.btn_In.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.btn_In.Image = global::NamDinh_QLBN.Properties.Resources.Print16;
            this.btn_In.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_In.Location = new System.Drawing.Point(606, 6);
            this.btn_In.Name = "btn_In";
            this.btn_In.Size = new System.Drawing.Size(87, 44);
            this.btn_In.TabIndex = 8;
            this.btn_In.Text = "In Phiếu";
            this.btn_In.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_In.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_In.UseVisualStyleBackColor = true;
            this.btn_In.Click += new System.EventHandler(this.btn_In_Click);
            // 
            // btnHoanTien
            // 
            this.btnHoanTien.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.btnHoanTien.Image = global::NamDinh_QLBN.Properties.Resources.Xoa;
            this.btnHoanTien.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHoanTien.Location = new System.Drawing.Point(699, 6);
            this.btnHoanTien.Name = "btnHoanTien";
            this.btnHoanTien.Size = new System.Drawing.Size(104, 44);
            this.btnHoanTien.TabIndex = 7;
            this.btnHoanTien.Text = "Hoàn Tiền";
            this.btnHoanTien.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHoanTien.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHoanTien.UseVisualStyleBackColor = true;
            this.btnHoanTien.Click += new System.EventHandler(this.btnHoanTien_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.checkBox1.Location = new System.Drawing.Point(297, 19);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(89, 23);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "Chọn KQ";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.label10.Location = new System.Drawing.Point(123, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 25);
            this.label10.TabIndex = 5;
            this.label10.Text = "Ký Quỹ";
            // 
            // txtkyquy
            // 
            this.txtkyquy.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.txtkyquy.Location = new System.Drawing.Point(209, 13);
            this.txtkyquy.Name = "txtkyquy";
            this.txtkyquy.Size = new System.Drawing.Size(82, 32);
            this.txtkyquy.TabIndex = 4;
            this.txtkyquy.Text = "200000";
            // 
            // btn_sua
            // 
            this.btn_sua.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.btn_sua.Image = global::NamDinh_QLBN.Properties.Resources.Sua;
            this.btn_sua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_sua.Location = new System.Drawing.Point(473, 6);
            this.btn_sua.Name = "btn_sua";
            this.btn_sua.Size = new System.Drawing.Size(63, 44);
            this.btn_sua.TabIndex = 3;
            this.btn_sua.Text = "Sửa";
            this.btn_sua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_sua.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_sua.UseVisualStyleBackColor = true;
            this.btn_sua.Click += new System.EventHandler(this.btn_sua_Click);
            // 
            // btnGhi
            // 
            this.btnGhi.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.btnGhi.Image = global::NamDinh_QLBN.Properties.Resources._1221111212;
            this.btnGhi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGhi.Location = new System.Drawing.Point(538, 6);
            this.btnGhi.Name = "btnGhi";
            this.btnGhi.Size = new System.Drawing.Size(65, 44);
            this.btnGhi.TabIndex = 2;
            this.btnGhi.Text = "Ghi";
            this.btnGhi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGhi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGhi.UseVisualStyleBackColor = true;
            this.btnGhi.Click += new System.EventHandler(this.btnGhi_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.button2.Image = global::NamDinh_QLBN.Properties.Resources.Refresh;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(392, 7);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(80, 44);
            this.button2.TabIndex = 1;
            this.button2.Text = "Đổi Vải";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnThemMoi
            // 
            this.btnThemMoi.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.btnThemMoi.Image = global::NamDinh_QLBN.Properties.Resources.Them;
            this.btnThemMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThemMoi.Location = new System.Drawing.Point(18, 7);
            this.btnThemMoi.Name = "btnThemMoi";
            this.btnThemMoi.Size = new System.Drawing.Size(102, 43);
            this.btnThemMoi.TabIndex = 0;
            this.btnThemMoi.Text = "Mượn Vải";
            this.btnThemMoi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThemMoi.UseVisualStyleBackColor = true;
            this.btnThemMoi.Click += new System.EventHandler(this.btnThemMoi_Click);
            // 
            // frmBenhnhan_Dovai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1357, 564);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmBenhnhan_Dovai";
            this.Text = "frmBenhnhan_Dovai";
            this.Load += new System.EventHandler(this.frmBenhnhan_Dovai_Load);
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DateNgayKham)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDenNgay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTuNgay)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fgDanhSach)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateThoiGiangDangKy)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fgDichVu)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.GroupBox groupBox1;
        private C1.Win.C1FlexGrid.C1FlexGrid fgDanhSach;
        private System.Windows.Forms.TextBox txtMaKhamBenh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtGioi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTuoi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.TextBox txtKhoa;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label label7;
        private C1.Win.C1FlexGrid.C1FlexGrid fgDichVu;
        private C1.Win.C1Input.C1DateEdit txtTuNgay;
        private System.Windows.Forms.Label label2;
        private C1.Win.C1Input.C1DateEdit txtDenNgay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private C1.Win.C1Input.C1DateEdit DateNgayKham;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnThemMoi;
        private System.Windows.Forms.Button btnGhi;
        private C1.Win.C1Input.C1DateEdit dateThoiGiangDangKy;
        private System.Windows.Forms.Button btn_sua;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtkyquy;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button btnHoanTien;
        private System.Windows.Forms.Button btn_In;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtNguoiNha;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnSoTongHop;
    }
}