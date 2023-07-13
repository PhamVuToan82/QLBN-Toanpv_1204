using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using GlobalModuls;

namespace NamDinh_QLBN.Forms.DuLieu
{
	/// <summary>
	/// Summary description for frmLapHSBA.
	/// </summary>
	public class frmLapHSBA : System.Windows.Forms.Form
    {
        struct ThanhPhan
        {
            public string MaThanhPhan,TenThanhPhan,MaDoiTuongBN;           
        }
        private ThanhPhan tp;
        private ThanhPhan[] arrThanhPhan;
        private C1.Win.C1FlexGrid.C1FlexGrid fgDanhSach;
		private DevExpress.XtraEditors.SimpleButton cmdThoat;
        private DevExpress.XtraEditors.SimpleButton cmdGhi;

        //private string MaBenhNhan ="";
        private System.Windows.Forms.Label lblLanVV;
        private Label label21;
        private Label label20;
        private GroupBox groupBox1;
        private Label lblMaBN;
        private Label label14;
        internal C1.Win.C1List.C1Combo cmbDonVi;
        private TextBox txtTuoi;
        private TextBox txtHoTen;
        private TextBox txtSoHSBA;
        private Label label10;
        internal C1.Win.C1List.C1Combo cmbCapBac;
        private Label label7;
        internal C1.Win.C1List.C1Combo cmbDanToc;
        private Label label6;
        internal C1.Win.C1List.C1Combo cmbGioiTinh;
        private Label label12;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txtDiaChi;
        private TextBox txtLienHe;
        private TextBox txtChucVu;
        internal C1.Win.C1List.C1Combo cmbTinh_TP;
        private Label label18;
        private Label label11;
        private Label label8;
        private Label label5;
        internal C1.Win.C1List.C1Combo cmbDoiTuong;
        private Label label15;
        private GroupBox groupBox2;
        private TextBox txtSoTheBHYT;
        private Label label17;
        internal C1.Win.C1List.C1Combo cmbHinhThucVV;
        private Label label19;
        private C1.Win.C1Input.C1DateEdit txtNgayVaoVien;
        private Label label13;
        private Label label16;
        private Label lblKhoa;
        private GroupBox groupBox3;
        private Label label23;
        private Label label24;
        private TextBox txtICD_PK;
        private Label lblICD_PK;
        private Label lblICD_NoiChuyen;
        private TextBox txtICD_NoiChuyen;
        private TextBox txtChanDoan_PK;
        private Label label4;
        private Label lblBacSy;
        private Label label22;
        private Label lblNgayKham;
        private Label label26;
        private Label label9;
        private Button button1;
        private TextBox txtMaBN;//ma benh nhan lay tu phong kham
        private int FoundedRow = 0;
        private Button button2;
        private TextBox txtTimTen;
        private Label label25;
        private GroupBox groupBox4;
        private RadioButton rdChualamBA;
        private RadioButton radioButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        internal C1.Win.C1List.C1Combo cmbMucAn;
        private Label label27;
        private DevExpress.XtraEditors.SimpleButton cmdPrint;
        private CheckBox chkInKhiGhi;
        private C1.Win.C1Input.C1DateEdit txtLocNgay;
        private Button button3;
        private Label label28;
        private TextBox txtDonVi_ChiTiet;
        private TextBox txtMaNoiCapBHYT;
        private TextBox txtMaDTBHYT;
        internal C1.Win.C1List.C1Combo cmbThanhPhan;
        private Label label29;
        private Label label30;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmLapHSBA()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLapHSBA));
            C1.Win.C1List.Style style73 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style74 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style75 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style76 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style77 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style78 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style79 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style80 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style81 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style82 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style83 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style84 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style85 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style86 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style87 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style88 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style89 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style90 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style91 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style92 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style93 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style94 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style95 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style96 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style97 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style98 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style99 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style100 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style101 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style102 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style103 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style104 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style105 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style106 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style107 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style108 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style109 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style110 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style111 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style112 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style113 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style114 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style115 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style116 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style117 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style118 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style119 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style120 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style121 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style122 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style123 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style124 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style125 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style126 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style127 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style128 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style129 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style130 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style131 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style132 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style133 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style134 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style135 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style136 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style137 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style138 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style139 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style140 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style141 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style142 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style143 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style144 = new C1.Win.C1List.Style();
            this.fgDanhSach = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.lblLanVV = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbThanhPhan = new C1.Win.C1List.C1Combo();
            this.label29 = new System.Windows.Forms.Label();
            this.txtMaNoiCapBHYT = new System.Windows.Forms.TextBox();
            this.txtMaDTBHYT = new System.Windows.Forms.TextBox();
            this.txtDonVi_ChiTiet = new System.Windows.Forms.TextBox();
            this.txtSoTheBHYT = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.cmbDoiTuong = new C1.Win.C1List.C1Combo();
            this.label15 = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.txtLienHe = new System.Windows.Forms.TextBox();
            this.txtChucVu = new System.Windows.Forms.TextBox();
            this.cmbTinh_TP = new C1.Win.C1List.C1Combo();
            this.label18 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblMaBN = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.cmbDonVi = new C1.Win.C1List.C1Combo();
            this.txtTuoi = new System.Windows.Forms.TextBox();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.txtSoHSBA = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbCapBac = new C1.Win.C1List.C1Combo();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbDanToc = new C1.Win.C1List.C1Combo();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbGioiTinh = new C1.Win.C1List.C1Combo();
            this.label12 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbMucAn = new C1.Win.C1List.C1Combo();
            this.label27 = new System.Windows.Forms.Label();
            this.lblKhoa = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtNgayVaoVien = new C1.Win.C1Input.C1DateEdit();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbHinhThucVV = new C1.Win.C1List.C1Combo();
            this.label19 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblNgayKham = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.lblBacSy = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.txtChanDoan_PK = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblICD_NoiChuyen = new System.Windows.Forms.Label();
            this.txtICD_NoiChuyen = new System.Windows.Forms.TextBox();
            this.lblICD_PK = new System.Windows.Forms.Label();
            this.txtICD_PK = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtMaBN = new System.Windows.Forms.TextBox();
            this.txtTimTen = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label28 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.txtLocNgay = new C1.Win.C1Input.C1DateEdit();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.rdChualamBA = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.cmdThoat = new DevExpress.XtraEditors.SimpleButton();
            this.cmdGhi = new DevExpress.XtraEditors.SimpleButton();
            this.cmdPrint = new DevExpress.XtraEditors.SimpleButton();
            this.chkInKhiGhi = new System.Windows.Forms.CheckBox();
            this.label30 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.fgDanhSach)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbThanhPhan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDoiTuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTinh_TP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDonVi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCapBac)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDanToc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbGioiTinh)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMucAn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNgayVaoVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbHinhThucVV)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLocNgay)).BeginInit();
            this.SuspendLayout();
            // 
            // fgDanhSach
            // 
            this.fgDanhSach.AllowDelete = true;
            this.fgDanhSach.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.fgDanhSach.AllowEditing = false;
            this.fgDanhSach.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.fgDanhSach.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Light3D;
            this.fgDanhSach.ColumnInfo = resources.GetString("fgDanhSach.ColumnInfo");
            this.fgDanhSach.ExtendLastCol = true;
            this.fgDanhSach.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid;
            this.fgDanhSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fgDanhSach.HighLight = C1.Win.C1FlexGrid.HighLightEnum.WithFocus;
            this.fgDanhSach.Location = new System.Drawing.Point(3, 114);
            this.fgDanhSach.Name = "fgDanhSach";
            this.fgDanhSach.Rows.Count = 1;
            this.fgDanhSach.Rows.MinSize = 20;
            this.fgDanhSach.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
            this.fgDanhSach.ShowCursor = true;
            this.fgDanhSach.Size = new System.Drawing.Size(478, 456);
            this.fgDanhSach.Styles = new C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("fgDanhSach.Styles"));
            this.fgDanhSach.TabIndex = 24;
            this.fgDanhSach.AfterSelChange += new C1.Win.C1FlexGrid.RangeEventHandler(this.fgDanhSach_AfterSelChange);
            // 
            // lblLanVV
            // 
            this.lblLanVV.BackColor = System.Drawing.Color.White;
            this.lblLanVV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLanVV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLanVV.ForeColor = System.Drawing.Color.Red;
            this.lblLanVV.Location = new System.Drawing.Point(247, 14);
            this.lblLanVV.Name = "lblLanVV";
            this.lblLanVV.Size = new System.Drawing.Size(30, 21);
            this.lblLanVV.TabIndex = 120;
            this.lblLanVV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblLanVV.Visible = false;
            // 
            // label21
            // 
            this.label21.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label21.BackColor = System.Drawing.Color.Teal;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.Yellow;
            this.label21.Location = new System.Drawing.Point(3, 3);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(478, 21);
            this.label21.TabIndex = 121;
            this.label21.Text = "DANH SÁCH BỆNH NHÂN";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label20.BackColor = System.Drawing.Color.Teal;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.Yellow;
            this.label20.Location = new System.Drawing.Point(487, 3);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(444, 21);
            this.label20.TabIndex = 122;
            this.label20.Text = "BỆNH ÁN";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.PowderBlue;
            this.groupBox1.Controls.Add(this.cmbThanhPhan);
            this.groupBox1.Controls.Add(this.label29);
            this.groupBox1.Controls.Add(this.txtMaNoiCapBHYT);
            this.groupBox1.Controls.Add(this.txtMaDTBHYT);
            this.groupBox1.Controls.Add(this.txtDonVi_ChiTiet);
            this.groupBox1.Controls.Add(this.txtSoTheBHYT);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.cmbDoiTuong);
            this.groupBox1.Controls.Add(this.lblLanVV);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.txtDiaChi);
            this.groupBox1.Controls.Add(this.txtLienHe);
            this.groupBox1.Controls.Add(this.txtChucVu);
            this.groupBox1.Controls.Add(this.cmbTinh_TP);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lblMaBN);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.cmbDonVi);
            this.groupBox1.Controls.Add(this.txtTuoi);
            this.groupBox1.Controls.Add(this.txtHoTen);
            this.groupBox1.Controls.Add(this.txtSoHSBA);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.cmbCapBac);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cmbDanToc);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cmbGioiTinh);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(487, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(444, 304);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "HÀNH CHÍNH";
            // 
            // cmbThanhPhan
            // 
            this.cmbThanhPhan.AddItemSeparator = ';';
            this.cmbThanhPhan.AllowColMove = false;
            this.cmbThanhPhan.AllowRowSizing = C1.Win.C1List.RowSizingEnum.AllRows;
            this.cmbThanhPhan.AutoCompletion = true;
            this.cmbThanhPhan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cmbThanhPhan.Caption = "";
            this.cmbThanhPhan.CaptionHeight = 17;
            this.cmbThanhPhan.CaptionStyle = style73;
            this.cmbThanhPhan.CaptionVisible = false;
            this.cmbThanhPhan.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cmbThanhPhan.ColumnCaptionHeight = 17;
            this.cmbThanhPhan.ColumnFooterHeight = 17;
            this.cmbThanhPhan.ColumnHeaders = false;
            this.cmbThanhPhan.ContentHeight = 16;
            this.cmbThanhPhan.DataMode = C1.Win.C1List.DataModeEnum.AddItem;
            this.cmbThanhPhan.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cmbThanhPhan.DefColWidth = 30;
            this.cmbThanhPhan.DisplayMember = "Danh mục";
            this.cmbThanhPhan.EditorBackColor = System.Drawing.Color.White;
            this.cmbThanhPhan.EditorFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbThanhPhan.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbThanhPhan.EditorHeight = 16;
            this.cmbThanhPhan.EvenRowStyle = style74;
            this.cmbThanhPhan.ExtendRightColumn = true;
            this.cmbThanhPhan.FlatStyle = C1.Win.C1List.FlatModeEnum.Popup;
            this.cmbThanhPhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbThanhPhan.FooterStyle = style75;
            this.cmbThanhPhan.GapHeight = 2;
            this.cmbThanhPhan.HeadingStyle = style76;
            this.cmbThanhPhan.HighLightRowStyle = style77;
            this.cmbThanhPhan.ItemHeight = 15;
            this.cmbThanhPhan.Location = new System.Drawing.Point(118, 234);
            this.cmbThanhPhan.MatchCol = C1.Win.C1List.MatchColEnum.AllCols;
            this.cmbThanhPhan.MatchEntryTimeout = ((long)(2000));
            this.cmbThanhPhan.MaxDropDownItems = ((short)(10));
            this.cmbThanhPhan.MaxLength = 32767;
            this.cmbThanhPhan.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cmbThanhPhan.Name = "cmbThanhPhan";
            this.cmbThanhPhan.OddRowStyle = style78;
            this.cmbThanhPhan.PartialRightColumn = false;
            this.cmbThanhPhan.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.cmbThanhPhan.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.cmbThanhPhan.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cmbThanhPhan.SelectedStyle = style79;
            this.cmbThanhPhan.Size = new System.Drawing.Size(195, 20);
            this.cmbThanhPhan.Style = style80;
            this.cmbThanhPhan.TabIndex = 36;
            this.cmbThanhPhan.PropBag = resources.GetString("cmbThanhPhan.PropBag");
            // 
            // label29
            // 
            this.label29.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label29.Location = new System.Drawing.Point(19, 234);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(93, 20);
            this.label29.TabIndex = 36;
            this.label29.Text = "*Thành phần";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMaNoiCapBHYT
            // 
            this.txtMaNoiCapBHYT.Location = new System.Drawing.Point(253, 256);
            this.txtMaNoiCapBHYT.Name = "txtMaNoiCapBHYT";
            this.txtMaNoiCapBHYT.Size = new System.Drawing.Size(60, 20);
            this.txtMaNoiCapBHYT.TabIndex = 36;
            // 
            // txtMaDTBHYT
            // 
            this.txtMaDTBHYT.Location = new System.Drawing.Point(223, 256);
            this.txtMaDTBHYT.Name = "txtMaDTBHYT";
            this.txtMaDTBHYT.Size = new System.Drawing.Size(28, 20);
            this.txtMaDTBHYT.TabIndex = 36;
            // 
            // txtDonVi_ChiTiet
            // 
            this.txtDonVi_ChiTiet.Location = new System.Drawing.Point(118, 128);
            this.txtDonVi_ChiTiet.Name = "txtDonVi_ChiTiet";
            this.txtDonVi_ChiTiet.Size = new System.Drawing.Size(318, 20);
            this.txtDonVi_ChiTiet.TabIndex = 32;
            // 
            // txtSoTheBHYT
            // 
            this.txtSoTheBHYT.Location = new System.Drawing.Point(118, 256);
            this.txtSoTheBHYT.Name = "txtSoTheBHYT";
            this.txtSoTheBHYT.Size = new System.Drawing.Size(103, 20);
            this.txtSoTheBHYT.TabIndex = 36;
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(19, 261);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(93, 15);
            this.label17.TabIndex = 36;
            this.label17.Text = "Số thẻ BHYT";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.cmbDoiTuong.CaptionStyle = style81;
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
            this.cmbDoiTuong.EvenRowStyle = style82;
            this.cmbDoiTuong.ExtendRightColumn = true;
            this.cmbDoiTuong.FlatStyle = C1.Win.C1List.FlatModeEnum.Popup;
            this.cmbDoiTuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDoiTuong.FooterStyle = style83;
            this.cmbDoiTuong.GapHeight = 2;
            this.cmbDoiTuong.HeadingStyle = style84;
            this.cmbDoiTuong.HighLightRowStyle = style85;
            this.cmbDoiTuong.ItemHeight = 15;
            this.cmbDoiTuong.Location = new System.Drawing.Point(118, 213);
            this.cmbDoiTuong.MatchCol = C1.Win.C1List.MatchColEnum.AllCols;
            this.cmbDoiTuong.MatchEntryTimeout = ((long)(2000));
            this.cmbDoiTuong.MaxDropDownItems = ((short)(10));
            this.cmbDoiTuong.MaxLength = 32767;
            this.cmbDoiTuong.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cmbDoiTuong.Name = "cmbDoiTuong";
            this.cmbDoiTuong.OddRowStyle = style86;
            this.cmbDoiTuong.PartialRightColumn = false;
            this.cmbDoiTuong.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.cmbDoiTuong.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.cmbDoiTuong.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cmbDoiTuong.SelectedStyle = style87;
            this.cmbDoiTuong.Size = new System.Drawing.Size(195, 20);
            this.cmbDoiTuong.Style = style88;
            this.cmbDoiTuong.TabIndex = 35;
            this.cmbDoiTuong.TextChanged += new System.EventHandler(this.cmbDoiTuong_TextChanged);
            this.cmbDoiTuong.PropBag = resources.GetString("cmbDoiTuong.PropBag");
            // 
            // label15
            // 
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label15.Location = new System.Drawing.Point(19, 213);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(93, 20);
            this.label15.TabIndex = 35;
            this.label15.Text = "*Đối tượng";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(118, 170);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(318, 20);
            this.txtDiaChi.TabIndex = 33;
            // 
            // txtLienHe
            // 
            this.txtLienHe.Location = new System.Drawing.Point(118, 278);
            this.txtLienHe.Name = "txtLienHe";
            this.txtLienHe.Size = new System.Drawing.Size(318, 20);
            this.txtLienHe.TabIndex = 37;
            // 
            // txtChucVu
            // 
            this.txtChucVu.Location = new System.Drawing.Point(118, 106);
            this.txtChucVu.Name = "txtChucVu";
            this.txtChucVu.Size = new System.Drawing.Size(318, 20);
            this.txtChucVu.TabIndex = 31;
            // 
            // cmbTinh_TP
            // 
            this.cmbTinh_TP.AddItemSeparator = ';';
            this.cmbTinh_TP.AllowColMove = false;
            this.cmbTinh_TP.AllowRowSizing = C1.Win.C1List.RowSizingEnum.AllRows;
            this.cmbTinh_TP.AutoCompletion = true;
            this.cmbTinh_TP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cmbTinh_TP.Caption = "";
            this.cmbTinh_TP.CaptionHeight = 17;
            this.cmbTinh_TP.CaptionStyle = style89;
            this.cmbTinh_TP.CaptionVisible = false;
            this.cmbTinh_TP.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cmbTinh_TP.ColumnCaptionHeight = 17;
            this.cmbTinh_TP.ColumnFooterHeight = 17;
            this.cmbTinh_TP.ColumnHeaders = false;
            this.cmbTinh_TP.ContentHeight = 16;
            this.cmbTinh_TP.DataMode = C1.Win.C1List.DataModeEnum.AddItem;
            this.cmbTinh_TP.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cmbTinh_TP.DefColWidth = 30;
            this.cmbTinh_TP.DisplayMember = "Danh mục";
            this.cmbTinh_TP.EditorBackColor = System.Drawing.Color.White;
            this.cmbTinh_TP.EditorFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTinh_TP.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbTinh_TP.EditorHeight = 16;
            this.cmbTinh_TP.EvenRowStyle = style90;
            this.cmbTinh_TP.ExtendRightColumn = true;
            this.cmbTinh_TP.FlatStyle = C1.Win.C1List.FlatModeEnum.Popup;
            this.cmbTinh_TP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTinh_TP.FooterStyle = style91;
            this.cmbTinh_TP.GapHeight = 2;
            this.cmbTinh_TP.HeadingStyle = style92;
            this.cmbTinh_TP.HighLightRowStyle = style93;
            this.cmbTinh_TP.ItemHeight = 15;
            this.cmbTinh_TP.Location = new System.Drawing.Point(118, 192);
            this.cmbTinh_TP.MatchCol = C1.Win.C1List.MatchColEnum.AllCols;
            this.cmbTinh_TP.MatchEntryTimeout = ((long)(2000));
            this.cmbTinh_TP.MaxDropDownItems = ((short)(10));
            this.cmbTinh_TP.MaxLength = 32767;
            this.cmbTinh_TP.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cmbTinh_TP.Name = "cmbTinh_TP";
            this.cmbTinh_TP.OddRowStyle = style94;
            this.cmbTinh_TP.PartialRightColumn = false;
            this.cmbTinh_TP.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.cmbTinh_TP.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.cmbTinh_TP.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cmbTinh_TP.SelectedStyle = style95;
            this.cmbTinh_TP.Size = new System.Drawing.Size(195, 20);
            this.cmbTinh_TP.Style = style96;
            this.cmbTinh_TP.TabIndex = 34;
            this.cmbTinh_TP.PropBag = resources.GetString("cmbTinh_TP.PropBag");
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(19, 192);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(93, 20);
            this.label18.TabIndex = 34;
            this.label18.Text = "Tỉnh, thành phố";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(19, 170);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(93, 20);
            this.label11.TabIndex = 33;
            this.label11.Text = "Địa chỉ";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(19, 278);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 20);
            this.label8.TabIndex = 37;
            this.label8.Text = "Địa chỉ liên hệ";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(19, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 20);
            this.label5.TabIndex = 31;
            this.label5.Text = "Chức vụ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMaBN
            // 
            this.lblMaBN.BackColor = System.Drawing.Color.White;
            this.lblMaBN.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMaBN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaBN.ForeColor = System.Drawing.Color.Red;
            this.lblMaBN.Location = new System.Drawing.Point(118, 14);
            this.lblMaBN.Name = "lblMaBN";
            this.lblMaBN.Size = new System.Drawing.Size(123, 21);
            this.lblMaBN.TabIndex = 25;
            this.lblMaBN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label14.Location = new System.Drawing.Point(16, 16);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(96, 21);
            this.label14.TabIndex = 25;
            this.label14.Text = "*Mã bệnh nhân";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbDonVi
            // 
            this.cmbDonVi.AddItemSeparator = ';';
            this.cmbDonVi.AllowColMove = false;
            this.cmbDonVi.AllowRowSizing = C1.Win.C1List.RowSizingEnum.AllRows;
            this.cmbDonVi.AutoCompletion = true;
            this.cmbDonVi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cmbDonVi.Caption = "";
            this.cmbDonVi.CaptionHeight = 17;
            this.cmbDonVi.CaptionStyle = style97;
            this.cmbDonVi.CaptionVisible = false;
            this.cmbDonVi.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cmbDonVi.ColumnCaptionHeight = 17;
            this.cmbDonVi.ColumnFooterHeight = 17;
            this.cmbDonVi.ColumnHeaders = false;
            this.cmbDonVi.ContentHeight = 16;
            this.cmbDonVi.DataMode = C1.Win.C1List.DataModeEnum.AddItem;
            this.cmbDonVi.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cmbDonVi.DefColWidth = 30;
            this.cmbDonVi.DisplayMember = "Danh mục";
            this.cmbDonVi.EditorBackColor = System.Drawing.Color.White;
            this.cmbDonVi.EditorFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDonVi.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbDonVi.EditorHeight = 16;
            this.cmbDonVi.EvenRowStyle = style98;
            this.cmbDonVi.ExtendRightColumn = true;
            this.cmbDonVi.FlatStyle = C1.Win.C1List.FlatModeEnum.Popup;
            this.cmbDonVi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDonVi.FooterStyle = style99;
            this.cmbDonVi.GapHeight = 2;
            this.cmbDonVi.HeadingStyle = style100;
            this.cmbDonVi.HighLightRowStyle = style101;
            this.cmbDonVi.ItemHeight = 15;
            this.cmbDonVi.Location = new System.Drawing.Point(118, 149);
            this.cmbDonVi.MatchCol = C1.Win.C1List.MatchColEnum.AllCols;
            this.cmbDonVi.MatchEntryTimeout = ((long)(2000));
            this.cmbDonVi.MaxDropDownItems = ((short)(10));
            this.cmbDonVi.MaxLength = 32767;
            this.cmbDonVi.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cmbDonVi.Name = "cmbDonVi";
            this.cmbDonVi.OddRowStyle = style102;
            this.cmbDonVi.PartialRightColumn = false;
            this.cmbDonVi.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.cmbDonVi.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.cmbDonVi.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cmbDonVi.SelectedStyle = style103;
            this.cmbDonVi.Size = new System.Drawing.Size(318, 20);
            this.cmbDonVi.Style = style104;
            this.cmbDonVi.TabIndex = 32;
            this.cmbDonVi.PropBag = resources.GetString("cmbDonVi.PropBag");
            // 
            // txtTuoi
            // 
            this.txtTuoi.Location = new System.Drawing.Point(355, 39);
            this.txtTuoi.Name = "txtTuoi";
            this.txtTuoi.Size = new System.Drawing.Size(30, 20);
            this.txtTuoi.TabIndex = 27;
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(118, 40);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(195, 20);
            this.txtHoTen.TabIndex = 26;
            // 
            // txtSoHSBA
            // 
            this.txtSoHSBA.Location = new System.Drawing.Point(355, 14);
            this.txtSoHSBA.Name = "txtSoHSBA";
            this.txtSoHSBA.Size = new System.Drawing.Size(81, 20);
            this.txtSoHSBA.TabIndex = 25;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(25, 128);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(87, 20);
            this.label10.TabIndex = 32;
            this.label10.Text = "Đơn vị";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbCapBac
            // 
            this.cmbCapBac.AddItemSeparator = ';';
            this.cmbCapBac.AllowColMove = false;
            this.cmbCapBac.AllowRowSizing = C1.Win.C1List.RowSizingEnum.AllRows;
            this.cmbCapBac.AutoCompletion = true;
            this.cmbCapBac.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cmbCapBac.Caption = "";
            this.cmbCapBac.CaptionHeight = 17;
            this.cmbCapBac.CaptionStyle = style105;
            this.cmbCapBac.CaptionVisible = false;
            this.cmbCapBac.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cmbCapBac.ColumnCaptionHeight = 17;
            this.cmbCapBac.ColumnFooterHeight = 17;
            this.cmbCapBac.ColumnHeaders = false;
            this.cmbCapBac.ContentHeight = 16;
            this.cmbCapBac.DataMode = C1.Win.C1List.DataModeEnum.AddItem;
            this.cmbCapBac.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cmbCapBac.DefColWidth = 30;
            this.cmbCapBac.DisplayMember = "Danh mục";
            this.cmbCapBac.EditorBackColor = System.Drawing.Color.White;
            this.cmbCapBac.EditorFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCapBac.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbCapBac.EditorHeight = 16;
            this.cmbCapBac.EvenRowStyle = style106;
            this.cmbCapBac.ExtendRightColumn = true;
            this.cmbCapBac.FlatStyle = C1.Win.C1List.FlatModeEnum.Popup;
            this.cmbCapBac.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCapBac.FooterStyle = style107;
            this.cmbCapBac.GapHeight = 2;
            this.cmbCapBac.HeadingStyle = style108;
            this.cmbCapBac.HighLightRowStyle = style109;
            this.cmbCapBac.ItemHeight = 15;
            this.cmbCapBac.Location = new System.Drawing.Point(118, 84);
            this.cmbCapBac.MatchCol = C1.Win.C1List.MatchColEnum.AllCols;
            this.cmbCapBac.MatchEntryTimeout = ((long)(2000));
            this.cmbCapBac.MaxDropDownItems = ((short)(10));
            this.cmbCapBac.MaxLength = 32767;
            this.cmbCapBac.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cmbCapBac.Name = "cmbCapBac";
            this.cmbCapBac.OddRowStyle = style110;
            this.cmbCapBac.PartialRightColumn = false;
            this.cmbCapBac.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.cmbCapBac.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.cmbCapBac.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cmbCapBac.SelectedStyle = style111;
            this.cmbCapBac.Size = new System.Drawing.Size(126, 20);
            this.cmbCapBac.Style = style112;
            this.cmbCapBac.TabIndex = 30;
            this.cmbCapBac.PropBag = resources.GetString("cmbCapBac.PropBag");
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(16, 84);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 15);
            this.label7.TabIndex = 30;
            this.label7.Text = "Quân hàm";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbDanToc
            // 
            this.cmbDanToc.AddItemSeparator = ';';
            this.cmbDanToc.AllowColMove = false;
            this.cmbDanToc.AllowRowSizing = C1.Win.C1List.RowSizingEnum.AllRows;
            this.cmbDanToc.AutoCompletion = true;
            this.cmbDanToc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cmbDanToc.Caption = "";
            this.cmbDanToc.CaptionHeight = 17;
            this.cmbDanToc.CaptionStyle = style113;
            this.cmbDanToc.CaptionVisible = false;
            this.cmbDanToc.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cmbDanToc.ColumnCaptionHeight = 17;
            this.cmbDanToc.ColumnFooterHeight = 17;
            this.cmbDanToc.ColumnHeaders = false;
            this.cmbDanToc.ContentHeight = 16;
            this.cmbDanToc.DataMode = C1.Win.C1List.DataModeEnum.AddItem;
            this.cmbDanToc.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cmbDanToc.DefColWidth = 30;
            this.cmbDanToc.DisplayMember = "Danh mục";
            this.cmbDanToc.EditorBackColor = System.Drawing.Color.White;
            this.cmbDanToc.EditorFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDanToc.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbDanToc.EditorHeight = 16;
            this.cmbDanToc.EvenRowStyle = style114;
            this.cmbDanToc.ExtendRightColumn = true;
            this.cmbDanToc.FlatStyle = C1.Win.C1List.FlatModeEnum.Popup;
            this.cmbDanToc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDanToc.FooterStyle = style115;
            this.cmbDanToc.GapHeight = 2;
            this.cmbDanToc.HeadingStyle = style116;
            this.cmbDanToc.HighLightRowStyle = style117;
            this.cmbDanToc.ItemHeight = 15;
            this.cmbDanToc.Location = new System.Drawing.Point(355, 61);
            this.cmbDanToc.MatchCol = C1.Win.C1List.MatchColEnum.AllCols;
            this.cmbDanToc.MatchEntryTimeout = ((long)(2000));
            this.cmbDanToc.MaxDropDownItems = ((short)(10));
            this.cmbDanToc.MaxLength = 32767;
            this.cmbDanToc.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cmbDanToc.Name = "cmbDanToc";
            this.cmbDanToc.OddRowStyle = style118;
            this.cmbDanToc.PartialRightColumn = false;
            this.cmbDanToc.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.cmbDanToc.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.cmbDanToc.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cmbDanToc.SelectedStyle = style119;
            this.cmbDanToc.Size = new System.Drawing.Size(81, 20);
            this.cmbDanToc.Style = style120;
            this.cmbDanToc.TabIndex = 29;
            this.cmbDanToc.PropBag = resources.GetString("cmbDanToc.PropBag");
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(250, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 15);
            this.label6.TabIndex = 29;
            this.label6.Text = "Dân tộc";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbGioiTinh
            // 
            this.cmbGioiTinh.AddItemSeparator = ';';
            this.cmbGioiTinh.AllowColMove = false;
            this.cmbGioiTinh.AllowRowSizing = C1.Win.C1List.RowSizingEnum.AllRows;
            this.cmbGioiTinh.AutoCompletion = true;
            this.cmbGioiTinh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cmbGioiTinh.Caption = "";
            this.cmbGioiTinh.CaptionHeight = 17;
            this.cmbGioiTinh.CaptionStyle = style121;
            this.cmbGioiTinh.CaptionVisible = false;
            this.cmbGioiTinh.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cmbGioiTinh.ColumnCaptionHeight = 17;
            this.cmbGioiTinh.ColumnFooterHeight = 17;
            this.cmbGioiTinh.ColumnHeaders = false;
            this.cmbGioiTinh.ContentHeight = 16;
            this.cmbGioiTinh.DataMode = C1.Win.C1List.DataModeEnum.AddItem;
            this.cmbGioiTinh.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cmbGioiTinh.DefColWidth = 30;
            this.cmbGioiTinh.DisplayMember = "Danh mục";
            this.cmbGioiTinh.EditorBackColor = System.Drawing.Color.White;
            this.cmbGioiTinh.EditorFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbGioiTinh.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbGioiTinh.EditorHeight = 16;
            this.cmbGioiTinh.EvenRowStyle = style122;
            this.cmbGioiTinh.ExtendRightColumn = true;
            this.cmbGioiTinh.FlatStyle = C1.Win.C1List.FlatModeEnum.Popup;
            this.cmbGioiTinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbGioiTinh.FooterStyle = style123;
            this.cmbGioiTinh.GapHeight = 2;
            this.cmbGioiTinh.HeadingStyle = style124;
            this.cmbGioiTinh.HighLightRowStyle = style125;
            this.cmbGioiTinh.ItemHeight = 15;
            this.cmbGioiTinh.Location = new System.Drawing.Point(118, 62);
            this.cmbGioiTinh.MatchCol = C1.Win.C1List.MatchColEnum.AllCols;
            this.cmbGioiTinh.MatchEntryTimeout = ((long)(2000));
            this.cmbGioiTinh.MaxDropDownItems = ((short)(10));
            this.cmbGioiTinh.MaxLength = 32767;
            this.cmbGioiTinh.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cmbGioiTinh.Name = "cmbGioiTinh";
            this.cmbGioiTinh.OddRowStyle = style126;
            this.cmbGioiTinh.PartialRightColumn = false;
            this.cmbGioiTinh.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.cmbGioiTinh.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.cmbGioiTinh.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cmbGioiTinh.SelectedStyle = style127;
            this.cmbGioiTinh.Size = new System.Drawing.Size(126, 20);
            this.cmbGioiTinh.Style = style128;
            this.cmbGioiTinh.TabIndex = 28;
            this.cmbGioiTinh.PropBag = resources.GetString("cmbGioiTinh.PropBag");
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(16, 64);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(96, 15);
            this.label12.TabIndex = 28;
            this.label12.Text = "Giới tính";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(319, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 15);
            this.label3.TabIndex = 126;
            this.label3.Text = "Tuổi";
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(16, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 15);
            this.label2.TabIndex = 26;
            this.label2.Text = "*Họ tên BN";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(247, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 15);
            this.label1.TabIndex = 25;
            this.label1.Text = "*Số HSBA";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.BackColor = System.Drawing.Color.PowderBlue;
            this.groupBox2.Controls.Add(this.cmbMucAn);
            this.groupBox2.Controls.Add(this.label27);
            this.groupBox2.Controls.Add(this.lblKhoa);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.txtNgayVaoVien);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.cmbHinhThucVV);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Location = new System.Drawing.Point(487, 334);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(444, 109);
            this.groupBox2.TabIndex = 38;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "QUẢN LÝ NGƯỜI BỆNH";
            // 
            // cmbMucAn
            // 
            this.cmbMucAn.AddItemSeparator = ';';
            this.cmbMucAn.AllowColMove = false;
            this.cmbMucAn.AllowRowSizing = C1.Win.C1List.RowSizingEnum.AllRows;
            this.cmbMucAn.AutoCompletion = true;
            this.cmbMucAn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cmbMucAn.Caption = "";
            this.cmbMucAn.CaptionHeight = 17;
            this.cmbMucAn.CaptionStyle = style129;
            this.cmbMucAn.CaptionVisible = false;
            this.cmbMucAn.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cmbMucAn.ColumnCaptionHeight = 17;
            this.cmbMucAn.ColumnFooterHeight = 17;
            this.cmbMucAn.ColumnHeaders = false;
            this.cmbMucAn.ContentHeight = 16;
            this.cmbMucAn.DataMode = C1.Win.C1List.DataModeEnum.AddItem;
            this.cmbMucAn.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cmbMucAn.DefColWidth = 1;
            this.cmbMucAn.DisplayMember = "Danh mục";
            this.cmbMucAn.EditorBackColor = System.Drawing.Color.White;
            this.cmbMucAn.EditorFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMucAn.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbMucAn.EditorHeight = 16;
            this.cmbMucAn.EvenRowStyle = style130;
            this.cmbMucAn.ExtendRightColumn = true;
            this.cmbMucAn.FlatStyle = C1.Win.C1List.FlatModeEnum.Popup;
            this.cmbMucAn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMucAn.FooterStyle = style131;
            this.cmbMucAn.GapHeight = 2;
            this.cmbMucAn.HeadingStyle = style132;
            this.cmbMucAn.HighLightRowStyle = style133;
            this.cmbMucAn.ItemHeight = 15;
            this.cmbMucAn.Location = new System.Drawing.Point(118, 61);
            this.cmbMucAn.MatchCol = C1.Win.C1List.MatchColEnum.AllCols;
            this.cmbMucAn.MatchEntryTimeout = ((long)(2000));
            this.cmbMucAn.MaxDropDownItems = ((short)(10));
            this.cmbMucAn.MaxLength = 32767;
            this.cmbMucAn.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cmbMucAn.Name = "cmbMucAn";
            this.cmbMucAn.OddRowStyle = style134;
            this.cmbMucAn.PartialRightColumn = false;
            this.cmbMucAn.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.cmbMucAn.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.cmbMucAn.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cmbMucAn.SelectedStyle = style135;
            this.cmbMucAn.Size = new System.Drawing.Size(195, 20);
            this.cmbMucAn.Style = style136;
            this.cmbMucAn.TabIndex = 40;
            this.cmbMucAn.PropBag = resources.GetString("cmbMucAn.PropBag");
            // 
            // label27
            // 
            this.label27.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label27.Location = new System.Drawing.Point(16, 63);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(99, 18);
            this.label27.TabIndex = 40;
            this.label27.Text = "*Mức ăn";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblKhoa
            // 
            this.lblKhoa.BackColor = System.Drawing.Color.White;
            this.lblKhoa.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblKhoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKhoa.ForeColor = System.Drawing.Color.Red;
            this.lblKhoa.Location = new System.Drawing.Point(118, 83);
            this.lblKhoa.Name = "lblKhoa";
            this.lblKhoa.Size = new System.Drawing.Size(318, 19);
            this.lblKhoa.TabIndex = 133;
            this.lblKhoa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label16
            // 
            this.label16.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label16.Location = new System.Drawing.Point(6, 83);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(106, 19);
            this.label16.TabIndex = 123;
            this.label16.Text = "Chỉ định vào khoa";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNgayVaoVien
            // 
            this.txtNgayVaoVien.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNgayVaoVien.Culture = 1066;
            this.txtNgayVaoVien.CustomFormat = "dd/MM/yyyy HH:mm";
            this.txtNgayVaoVien.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
            this.txtNgayVaoVien.Location = new System.Drawing.Point(118, 19);
            this.txtNgayVaoVien.Name = "txtNgayVaoVien";
            this.txtNgayVaoVien.Size = new System.Drawing.Size(133, 18);
            this.txtNgayVaoVien.TabIndex = 38;
            this.txtNgayVaoVien.Tag = null;
            // 
            // label13
            // 
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label13.Location = new System.Drawing.Point(6, 19);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(106, 19);
            this.label13.TabIndex = 38;
            this.label13.Text = "*Ngày, giờ vào viện";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbHinhThucVV
            // 
            this.cmbHinhThucVV.AddItemSeparator = ';';
            this.cmbHinhThucVV.AllowColMove = false;
            this.cmbHinhThucVV.AllowRowSizing = C1.Win.C1List.RowSizingEnum.AllRows;
            this.cmbHinhThucVV.AutoCompletion = true;
            this.cmbHinhThucVV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cmbHinhThucVV.Caption = "";
            this.cmbHinhThucVV.CaptionHeight = 17;
            this.cmbHinhThucVV.CaptionStyle = style137;
            this.cmbHinhThucVV.CaptionVisible = false;
            this.cmbHinhThucVV.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cmbHinhThucVV.ColumnCaptionHeight = 17;
            this.cmbHinhThucVV.ColumnFooterHeight = 17;
            this.cmbHinhThucVV.ColumnHeaders = false;
            this.cmbHinhThucVV.ContentHeight = 16;
            this.cmbHinhThucVV.DataMode = C1.Win.C1List.DataModeEnum.AddItem;
            this.cmbHinhThucVV.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cmbHinhThucVV.DefColWidth = 30;
            this.cmbHinhThucVV.DisplayMember = "Danh mục";
            this.cmbHinhThucVV.EditorBackColor = System.Drawing.Color.White;
            this.cmbHinhThucVV.EditorFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbHinhThucVV.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbHinhThucVV.EditorHeight = 16;
            this.cmbHinhThucVV.EvenRowStyle = style138;
            this.cmbHinhThucVV.ExtendRightColumn = true;
            this.cmbHinhThucVV.FlatStyle = C1.Win.C1List.FlatModeEnum.Popup;
            this.cmbHinhThucVV.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbHinhThucVV.FooterStyle = style139;
            this.cmbHinhThucVV.GapHeight = 2;
            this.cmbHinhThucVV.HeadingStyle = style140;
            this.cmbHinhThucVV.HighLightRowStyle = style141;
            this.cmbHinhThucVV.ItemHeight = 15;
            this.cmbHinhThucVV.Location = new System.Drawing.Point(118, 39);
            this.cmbHinhThucVV.MatchCol = C1.Win.C1List.MatchColEnum.AllCols;
            this.cmbHinhThucVV.MatchEntryTimeout = ((long)(2000));
            this.cmbHinhThucVV.MaxDropDownItems = ((short)(10));
            this.cmbHinhThucVV.MaxLength = 32767;
            this.cmbHinhThucVV.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cmbHinhThucVV.Name = "cmbHinhThucVV";
            this.cmbHinhThucVV.OddRowStyle = style142;
            this.cmbHinhThucVV.PartialRightColumn = false;
            this.cmbHinhThucVV.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.cmbHinhThucVV.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.cmbHinhThucVV.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cmbHinhThucVV.SelectedStyle = style143;
            this.cmbHinhThucVV.Size = new System.Drawing.Size(195, 20);
            this.cmbHinhThucVV.Style = style144;
            this.cmbHinhThucVV.TabIndex = 39;
            this.cmbHinhThucVV.PropBag = resources.GetString("cmbHinhThucVV.PropBag");
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(6, 39);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(106, 19);
            this.label19.TabIndex = 39;
            this.label19.Text = "Hình thức vào viện";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.BackColor = System.Drawing.Color.PowderBlue;
            this.groupBox3.Controls.Add(this.lblNgayKham);
            this.groupBox3.Controls.Add(this.label26);
            this.groupBox3.Controls.Add(this.lblBacSy);
            this.groupBox3.Controls.Add(this.label22);
            this.groupBox3.Controls.Add(this.txtChanDoan_PK);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.lblICD_NoiChuyen);
            this.groupBox3.Controls.Add(this.txtICD_NoiChuyen);
            this.groupBox3.Controls.Add(this.lblICD_PK);
            this.groupBox3.Controls.Add(this.txtICD_PK);
            this.groupBox3.Controls.Add(this.label24);
            this.groupBox3.Controls.Add(this.label23);
            this.groupBox3.Location = new System.Drawing.Point(487, 446);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(444, 106);
            this.groupBox3.TabIndex = 41;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "CHẨN ĐOÁN";
            // 
            // lblNgayKham
            // 
            this.lblNgayKham.BackColor = System.Drawing.Color.White;
            this.lblNgayKham.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNgayKham.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayKham.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblNgayKham.Location = new System.Drawing.Point(355, 79);
            this.lblNgayKham.Name = "lblNgayKham";
            this.lblNgayKham.Size = new System.Drawing.Size(81, 20);
            this.lblNgayKham.TabIndex = 142;
            this.lblNgayKham.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label26
            // 
            this.label26.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label26.Location = new System.Drawing.Point(315, 80);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(37, 19);
            this.label26.TabIndex = 141;
            this.label26.Text = "Ngày";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblBacSy
            // 
            this.lblBacSy.BackColor = System.Drawing.Color.White;
            this.lblBacSy.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblBacSy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBacSy.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblBacSy.Location = new System.Drawing.Point(191, 79);
            this.lblBacSy.Name = "lblBacSy";
            this.lblBacSy.Size = new System.Drawing.Size(122, 20);
            this.lblBacSy.TabIndex = 140;
            this.lblBacSy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label22
            // 
            this.label22.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label22.Location = new System.Drawing.Point(46, 81);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(142, 19);
            this.label22.TabIndex = 139;
            this.label22.Text = "Bác sỹ";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtChanDoan_PK
            // 
            this.txtChanDoan_PK.Location = new System.Drawing.Point(118, 34);
            this.txtChanDoan_PK.Name = "txtChanDoan_PK";
            this.txtChanDoan_PK.Size = new System.Drawing.Size(318, 20);
            this.txtChanDoan_PK.TabIndex = 42;
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(6, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 19);
            this.label4.TabIndex = 42;
            this.label4.Text = "Triệu chứng";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblICD_NoiChuyen
            // 
            this.lblICD_NoiChuyen.BackColor = System.Drawing.Color.White;
            this.lblICD_NoiChuyen.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblICD_NoiChuyen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblICD_NoiChuyen.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblICD_NoiChuyen.Location = new System.Drawing.Point(191, 12);
            this.lblICD_NoiChuyen.Name = "lblICD_NoiChuyen";
            this.lblICD_NoiChuyen.Size = new System.Drawing.Size(245, 20);
            this.lblICD_NoiChuyen.TabIndex = 136;
            this.lblICD_NoiChuyen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtICD_NoiChuyen
            // 
            this.txtICD_NoiChuyen.Location = new System.Drawing.Point(118, 12);
            this.txtICD_NoiChuyen.Name = "txtICD_NoiChuyen";
            this.txtICD_NoiChuyen.Size = new System.Drawing.Size(70, 20);
            this.txtICD_NoiChuyen.TabIndex = 41;
            this.txtICD_NoiChuyen.Validating += new System.ComponentModel.CancelEventHandler(this.txtICD_NoiChuyen_Validating);
            // 
            // lblICD_PK
            // 
            this.lblICD_PK.BackColor = System.Drawing.Color.White;
            this.lblICD_PK.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblICD_PK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblICD_PK.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblICD_PK.Location = new System.Drawing.Point(191, 56);
            this.lblICD_PK.Name = "lblICD_PK";
            this.lblICD_PK.Size = new System.Drawing.Size(245, 20);
            this.lblICD_PK.TabIndex = 134;
            this.lblICD_PK.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtICD_PK
            // 
            this.txtICD_PK.Location = new System.Drawing.Point(118, 56);
            this.txtICD_PK.Name = "txtICD_PK";
            this.txtICD_PK.Size = new System.Drawing.Size(70, 20);
            this.txtICD_PK.TabIndex = 43;
            this.txtICD_PK.Validating += new System.ComponentModel.CancelEventHandler(this.txtICD_PK_Validating);
            // 
            // label24
            // 
            this.label24.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label24.Location = new System.Drawing.Point(6, 56);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(106, 19);
            this.label24.TabIndex = 43;
            this.label24.Text = "Vào viện";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label23
            // 
            this.label23.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label23.Location = new System.Drawing.Point(6, 16);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(106, 19);
            this.label23.TabIndex = 41;
            this.label23.Text = "Nơi chuyển đến";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(7, 14);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 19);
            this.label9.TabIndex = 19;
            this.label9.Text = "Mã BN";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMaBN
            // 
            this.txtMaBN.Location = new System.Drawing.Point(56, 14);
            this.txtMaBN.Name = "txtMaBN";
            this.txtMaBN.Size = new System.Drawing.Size(90, 20);
            this.txtMaBN.TabIndex = 19;
            this.txtMaBN.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtMaBN_KeyUp);
            // 
            // txtTimTen
            // 
            this.txtTimTen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTimTen.Location = new System.Drawing.Point(226, 14);
            this.txtTimTen.Name = "txtTimTen";
            this.txtTimTen.Size = new System.Drawing.Size(218, 20);
            this.txtTimTen.TabIndex = 22;
            this.txtTimTen.TextChanged += new System.EventHandler(this.txtTimTen_TextChanged);
            this.txtTimTen.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtTimTen_KeyUp);
            // 
            // label25
            // 
            this.label25.Location = new System.Drawing.Point(176, 14);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(44, 19);
            this.label25.TabIndex = 21;
            this.label25.Text = "Tên BN";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.label28);
            this.groupBox4.Controls.Add(this.button3);
            this.groupBox4.Controls.Add(this.txtLocNgay);
            this.groupBox4.Controls.Add(this.button2);
            this.groupBox4.Controls.Add(this.txtTimTen);
            this.groupBox4.Controls.Add(this.label25);
            this.groupBox4.Controls.Add(this.button1);
            this.groupBox4.Controls.Add(this.txtMaBN);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Location = new System.Drawing.Point(3, 48);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(478, 62);
            this.groupBox4.TabIndex = 123;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Tìm kiếm";
            // 
            // label28
            // 
            this.label28.Location = new System.Drawing.Point(147, 37);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(73, 19);
            this.label28.TabIndex = 41;
            this.label28.Text = "Ngày hẹn";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(361, 36);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(83, 22);
            this.button3.TabIndex = 40;
            this.button3.Text = "Đọc lại DS";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // txtLocNgay
            // 
            this.txtLocNgay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLocNgay.Culture = 1066;
            this.txtLocNgay.CustomFormat = "dd/MM/yyyy";
            this.txtLocNgay.DisableOnNoData = false;
            this.txtLocNgay.EmptyAsNull = true;
            this.txtLocNgay.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
            this.txtLocNgay.Location = new System.Drawing.Point(226, 38);
            this.txtLocNgay.Name = "txtLocNgay";
            this.txtLocNgay.Size = new System.Drawing.Size(133, 18);
            this.txtLocNgay.TabIndex = 39;
            this.txtLocNgay.Tag = null;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            //this.button2.Image = global::NamDinh_QLBN.Properties.Resources.Soi16;
            this.button2.Location = new System.Drawing.Point(445, 13);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(23, 22);
            this.button2.TabIndex = 23;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(147, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(23, 22);
            this.button1.TabIndex = 20;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // rdChualamBA
            // 
            this.rdChualamBA.AutoSize = true;
            this.rdChualamBA.Checked = true;
            this.rdChualamBA.Location = new System.Drawing.Point(13, 29);
            this.rdChualamBA.Name = "rdChualamBA";
            this.rdChualamBA.Size = new System.Drawing.Size(111, 17);
            this.rdChualamBA.TabIndex = 124;
            this.rdChualamBA.TabStop = true;
            this.rdChualamBA.Text = "Chưa làm bệnh án";
            this.rdChualamBA.UseVisualStyleBackColor = true;
            this.rdChualamBA.CheckedChanged += new System.EventHandler(this.rdChualamBA_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(229, 29);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(178, 17);
            this.radioButton1.TabIndex = 125;
            this.radioButton1.Text = "Đã làm bệnh án, chưa vào khoa";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton1.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(595, 574);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(102, 26);
            this.simpleButton1.TabIndex = 45;
            this.simpleButton1.Text = "Xóa bệnh án";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // cmdThoat
            // 
            this.cmdThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdThoat.Image = ((System.Drawing.Image)(resources.GetObject("cmdThoat.Image")));
            this.cmdThoat.Location = new System.Drawing.Point(829, 574);
            this.cmdThoat.Name = "cmdThoat";
            this.cmdThoat.Size = new System.Drawing.Size(102, 26);
            this.cmdThoat.TabIndex = 44;
            this.cmdThoat.Text = "Thoát";
            this.cmdThoat.Click += new System.EventHandler(this.cmdThoat_Click);
            // 
            // cmdGhi
            // 
            this.cmdGhi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdGhi.Image = ((System.Drawing.Image)(resources.GetObject("cmdGhi.Image")));
            this.cmdGhi.Location = new System.Drawing.Point(487, 574);
            this.cmdGhi.Name = "cmdGhi";
            this.cmdGhi.Size = new System.Drawing.Size(102, 26);
            this.cmdGhi.TabIndex = 44;
            this.cmdGhi.Text = "Ghi bệnh án";
            this.cmdGhi.Click += new System.EventHandler(this.cmdGhi_Click);
            // 
            // cmdPrint
            // 
            this.cmdPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdPrint.Location = new System.Drawing.Point(721, 574);
            this.cmdPrint.Name = "cmdPrint";
            this.cmdPrint.Size = new System.Drawing.Size(102, 26);
            this.cmdPrint.TabIndex = 126;
            this.cmdPrint.Text = "In bệnh án";
            this.cmdPrint.Click += new System.EventHandler(this.cmdPrint_Click);
            // 
            // chkInKhiGhi
            // 
            this.chkInKhiGhi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkInKhiGhi.AutoSize = true;
            this.chkInKhiGhi.BackColor = System.Drawing.Color.PowderBlue;
            this.chkInKhiGhi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkInKhiGhi.Location = new System.Drawing.Point(777, 553);
            this.chkInKhiGhi.Name = "chkInKhiGhi";
            this.chkInKhiGhi.Size = new System.Drawing.Size(153, 17);
            this.chkInKhiGhi.TabIndex = 127;
            this.chkInKhiGhi.Text = "In sau khi ghi bệnh án";
            this.chkInKhiGhi.UseVisualStyleBackColor = false;
            // 
            // label30
            // 
            this.label30.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label30.AutoSize = true;
            this.label30.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label30.Location = new System.Drawing.Point(6, 577);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(283, 13);
            this.label30.TabIndex = 128;
            this.label30.Text = "Bấm vào đây để thay đổi hướng giải quyết của bệnh nhân";
            this.label30.Click += new System.EventHandler(this.label30_Click);
            // 
            // frmLapHSBA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(932, 604);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.chkInKhiGhi);
            this.Controls.Add(this.cmdPrint);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.rdChualamBA);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.fgDanhSach);
            this.Controls.Add(this.cmdThoat);
            this.Controls.Add(this.cmdGhi);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "frmLapHSBA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lập hồ sơ bệnh án cho bệnh nhân vào viện";
            this.Load += new System.EventHandler(this.frmLapHSBA_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fgDanhSach)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbThanhPhan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDoiTuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTinh_TP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDonVi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCapBac)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDanToc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbGioiTinh)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmbMucAn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNgayVaoVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbHinhThucVV)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLocNgay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmLapHSBA_Load(object sender, System.EventArgs e)
		{
			fgDanhSach.ClipSeparators ="|;";
			Load_DM();
			LockEdit(true);
			txtNgayVaoVien.Value = Global.NgayLV;
            txtLocNgay.Value = Global.NgayLV;
            fgDanhSach.Cols[1].Visible = false;
            fgDanhSach.Cols[8].Visible = false;
            Clear_Data();
            Load_DSBenhNhan(rdChualamBA.Checked);
            this.WindowState = FormWindowState.Maximized;
            Global.SetGridStyles(fgDanhSach);
            simpleButton1.Visible = false;
            
		}
        private void SetOptionHSBA(string DoiTuong)
        {
            for (int i = 0; i < this.groupBox1.Controls.Count; i++)
            {
                this.groupBox1.Controls[i].Enabled = true;
            }
            for (int i = 0; i < this.groupBox2.Controls.Count; i++)
            {
                this.groupBox2.Controls[i].Enabled = true;
            }
            for (int i = 0; i < this.groupBox3.Controls.Count; i++)
            {
                this.groupBox3.Controls[i].Enabled = true;
            }
            //for (int i = 0; i < this.groupBox3.Controls.Count; i++)
            //{
            //    this.groupBox3.Controls[i].Enabled = true;
            //}
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            SQLCmd.CommandText = "SELECT * FROM CONFIGS WHERE UName='" + Global.glbUName + "' AND ConfigName='NhapHSBA' AND GhiChu='" + DoiTuong + "' AND Chon=0";
            dr = SQLCmd.ExecuteReader();            
            while (dr.Read())
            {                
                for (int i = 0; i < this.groupBox1.Controls.Count; i++)
                {
                    if (this.groupBox1.Controls[i].Name.ToUpper() == dr["ConfigValue"].ToString().ToUpper())
                    {this.groupBox1.Controls[i].Enabled = false;}
                }
                for (int i = 0; i < this.groupBox2.Controls.Count; i++)
                {
                    if (this.groupBox2.Controls[i].Name.ToUpper() == dr["ConfigValue"].ToString().ToUpper())
                    { this.groupBox2.Controls[i].Enabled = false; }
                }
                for (int i = 0; i < this.groupBox3.Controls.Count; i++)
                {
                    if (this.groupBox3.Controls[i].Name.ToUpper() == dr["ConfigValue"].ToString().ToUpper())
                    { this.groupBox3.Controls[i].Enabled = false; }
                }
                //for (int i = 0; i < this.groupBox3.Controls.Count; i++)
                //{
                //    if (this.groupBox3.Controls[i].Name.ToUpper() == dr["ConfigValue"].ToString().ToUpper())
                //    { this.groupBox3.Controls[i].Enabled = false; }
                //}
            }
            dr.Close();
        }
		private void Load_DM()
		{
			System.Data.SqlClient.SqlDataReader dr;
			System.Data.SqlClient.SqlCommand SQLCmd= new System.Data.SqlClient.SqlCommand();
			SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
			SQLCmd.CommandText  = "SELECT * FROM DMDANTOC";
			dr=SQLCmd.ExecuteReader();
			while (dr.Read())
			{
				cmbDanToc.AddItem(string.Format("{0};{1}",dr["MaDT"],dr["TenDT"]));
			}
			dr.Close();
			SQLCmd.CommandText  = "SELECT * FROM DMQUANHAM";
			dr=SQLCmd.ExecuteReader();
			while (dr.Read())
			{
				cmbCapBac.AddItem(string.Format("{0};{1}",dr["MaQH"],dr["TenQH"]));
			}
			dr.Close();
			SQLCmd.CommandText = "SELECT * FROM DMDOITUONGBN";
			dr=SQLCmd.ExecuteReader();
            cmbDoiTuong.Tag = "0";
			while (dr.Read())
			{
				cmbDoiTuong.AddItem(string.Format("{0};{1}",dr["MaDT"],dr["TenDT"]));
			}
			dr.Close();
            cmbDoiTuong.Tag = "1";
			SQLCmd.CommandText = "SELECT * FROM DMDONVI";
			dr=SQLCmd.ExecuteReader();
			while (dr.Read())
			{
				cmbDonVi.AddItem(string.Format("{0};{1}",dr["MaDonVi"],dr["TenDonVi"]));
			}
			dr.Close();
			SQLCmd.CommandText = "SELECT * FROM DMTINH_TP";
			dr=SQLCmd.ExecuteReader();
			while (dr.Read())
			{
				cmbTinh_TP.AddItem(string.Format("{0};{1}",dr["MaTinh"],dr["TenTinh"]));
			}
			dr.Close();
            SQLCmd.CommandText = "SELECT * FROM ViewDMCHIPHI WHERE LoaiCP=5";
            dr = SQLCmd.ExecuteReader();
            while (dr.Read())
            {
                cmbMucAn.AddItem(string.Format("{0};{1}", dr["MaCP"], dr["TenCP"]));
            }
            dr.Close();
            //SQLCmd.CommandText = "SELECT * FROM DMTHANHPHAN";
            //dr = SQLCmd.ExecuteReader();
            
            //arrThanhPhan = new ThanhPhan[0];
            //int STT = 1;
            //while (dr.Read())
            //{                
            //    Array.Resize(ref arrThanhPhan,STT);
            //    arrThanhPhan[STT - 1].MaDoiTuongBN = dr["MaDoiTuongBN"].ToString();
            //    arrThanhPhan[STT - 1].MaThanhPhan = dr["MaThanhPhan"].ToString();
            //    arrThanhPhan[STT - 1].TenThanhPhan = dr["TenThanhPhan"].ToString();                
            //    STT++;
            //}
            //dr.Close();
			SQLCmd.Dispose();

			cmbGioiTinh.AddItem("1;Nam");
			cmbGioiTinh.AddItem("0;Nữ");
			cmbHinhThucVV.AddItem("1;Tự đến");
			cmbHinhThucVV.AddItem("2;Cấp cứu");
			cmbHinhThucVV.AddItem("3;Tuyến trước chuyển đến");
			cmbHinhThucVV.AddItem("4;Bệnh viện khác chuyển đến");
			cmbHinhThucVV.AddItem("5;Khác");
		}
		private void LockEdit(bool IsLocked)
		{
//			cmdXoa.Visible = IsLocked;
//			cmdThoat.Visible = IsLocked;
//		
//
//			cmdGhi.Visible = !IsLocked;
//			fgDanhSach.Enabled = IsLocked;			
//			
//			cmbGioiTinh.ReadOnly = IsLocked;
//			cmbDanToc.ReadOnly = IsLocked;
//			cmbCapBac.ReadOnly = IsLocked;
//
//			txtSoHSBA.ReadOnly = IsLocked;
//			cmbKhoa.ReadOnly = !IsLocked;
		}
		private void Load_DSBenhNhan(bool ChuaLamBenhAn)
		{
            //if (txtLocNgay.ValueIsDbNull)
            //{
            //    MessageBox.Show("Chưa nhập ngày tháng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    txtLocNgay.Focus();
            //    return;
            //}
			System.Data.SqlClient.SqlDataReader dr;
			System.Data.SqlClient.SqlCommand SQLCmd= new System.Data.SqlClient.SqlCommand();
			SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
			//string MaKhoa=Global.GetCode(cmbKhoa);
            string MaKhoa = lblKhoa.Tag.ToString();
            if (ChuaLamBenhAn)
            {
                fgDanhSach[0, 6] = "Ngày khám";
                fgDanhSach.Cols[7].Visible = true;
                SQLCmd.CommandText ="select [KHAMBENH103].DBO.tblBENHNHAN.*,KetLuan,MaKhoaDieuTri,MaBenhChinh,TenBenh,TenDT,NgayKham,year(GetDate())-NamSinh As Tuoi,0 As LanVaoVien,TenTat As TenKhoa,TenPhongKham,NgayHenNV from (((([KHAMBENH103].DBO.tblBENHNHAN "
                                + " INNER JOIN [KHAMBENH103].DBO.tblKHAMBENH ON [KHAMBENH103].DBO.tblBENHNHAN.MaBenhNhan= [KHAMBENH103].DBO.tblKHAMBENH.MabenhNhan)"
                                + " LEFT JOIN DMKHOAPHONG ON MaKhoaDieuTri=MaKhoa)"
                                + " LEFT JOIN DMBENH ON MaBenhChinh=MaBenh)"
                                + " INNER JOIN DMDOITUONGBN ON MaDoiTuong=MaDT)"
                                + " INNER JOIN (SELECT MaKhoa,TenKhoa As TenPhongKham FROM [KHAMBENH103].DBO.DMKHOAPHONG WHERE MaKhoa like 'K%') Q1 "
                                + " ON [KHAMBENH103].DBO.tblKHAMBENH.MaPK = Q1.MaKhoa "
                                + " WHERE HuongGQ=4 AND IsNull(SoBenhAn,'')='' " 
                                +((txtLocNgay.ValueIsDbNull)?(""):(string.Format(" AND DateDiff(Day,NgayHenNV,'{0:MM/dd/yyyy}')=0",txtLocNgay.Value)))
                                + " ORDER BY [KHAMBENH103].DBO.tblBENHNHAN.MaBenhNhan, thuTuKham";
            }
            else
            {
                fgDanhSach[0, 6] = "Ngày lập BA";
                fgDanhSach.Cols[7].Visible = false;
                SQLCmd.CommandText ="select BENHNHAN.MaBenhNhan,BENHNHAN.HoTen As TenBenhNhan,Year(GetDate())-NamSinh as Tuoi,GioiTinh,TenDT,'' As NgayHenNV,NgayVaoVien As NgayKham,BENHNHAN_CHITIET.LanVaoVien,TenTat As TenKhoa,'' As TenPhongKham "
                                + " FROM (((BENHNHAN INNER JOIN BENHNHAN_CHITIET ON BENHNHAN.MaBenhNhan=BENHNHAN_CHITIET.MaBenhNhan)"
                                + " INNER JOIN DMDOITUONGBN ON BENHNHAN_CHITIET.DoiTuong=DMDOITUONGBN.MaDT)"
                                + " INNER JOIN ViewKHOAHIENTAI ON BENHNHAN_CHITIET.MaBenhNhan=ViewKHOAHIENTAI.MaBenhNhan AND BENHNHAN_CHITIET.LanVaoVien=ViewKHOAHIENTAI.LanVaoVien)"
                                + " INNER JOIN DMKHOAPHONG ON ViewKHOAHIENTAI.MaKhoa=DMKHOAPHONG.MaKhoa "
                                + " WHERE TrangThai>1 "
                                +((txtLocNgay.ValueIsDbNull)?(""):(string.Format(" AND DateDiff(Day,NgayVaoVien,'{0:MM/dd/yyyy}')=0",txtLocNgay.Value)));
            }
			dr=SQLCmd.ExecuteReader();
			fgDanhSach.Tag ="0";
            fgDanhSach.Redraw = false;
			fgDanhSach.Rows.Count =1;
			while (dr.Read())
			{
                fgDanhSach.AddItem(string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6:dd/MM/yyyy}|{7:dd/MM/yyyy}|{8}|{9}|{10}", fgDanhSach.Rows.Count,
					dr["MaBenhNhan"],
					dr["TenBenhNhan"],
					dr["Tuoi"],
					(dr["GioiTinh"].ToString()=="1")?("Nam"):("Nữ"),
					dr["TenDT"],
					dr["NgayKham"],dr["NgayHenNV"],dr["LanVaoVien"],dr["TenKhoa"],dr["TenPhongKham"]));
			}
			dr.Close();
			fgDanhSach.AutoSizeCols();
			fgDanhSach.Tag ="1";
            fgDanhSach.Redraw = true;
			SQLCmd.Dispose();
			Clear_Data();
		}
				
		private void cmdThoat_Click(object sender, System.EventArgs e)
		{
			this.Dispose();
		}

		private void cmdGhi_Click(object sender, System.EventArgs e)
		{
			if (lblMaBN.Text =="") {return;}
			if (txtNgayVaoVien.ValueIsDbNull)
			{
				MessageBox.Show("Chưa nhập ngày vào viện!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
				txtNgayVaoVien.Focus();
				return;
			}
			if (txtSoHSBA.Text.Trim()=="")
			{
				MessageBox.Show("Chưa nhập số hồ sơ bệnh án!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
				txtSoHSBA.Focus();
				return;
			}
			if (Global.GetCode(cmbDoiTuong)==null)
			{
				MessageBox.Show("Chưa nhập đối tượng bệnh nhân!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
				cmbDoiTuong.Focus();
				return;
			}
            if (Global.GetCode(cmbThanhPhan) == null)
            {
                MessageBox.Show("Chưa nhập thành phần bệnh nhân!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbThanhPhan.Focus();
                return;
            }
			if (txtHoTen.Text.Trim()=="")
			{
				MessageBox.Show("Chưa nhập tên bệnh nhân!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
				txtHoTen.Focus();
				return;
			}
            string MaBenhNhan = "", LanVaoVien = "", TenTatKhoa = "";
            if (GhiDuLieuBenhAn(rdChualamBA.Checked,out MaBenhNhan,out LanVaoVien,out TenTatKhoa) == 1) 
            {
                //fgDanhSach.RemoveItem(fgDanhSach.Row);
                MessageBox.Show("Đã cập nhật xong bệnh án của bệnh nhân","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                //cmdGhi_Click();
                if (chkInKhiGhi.Checked==true)
                {
                    InBenhAn(MaBenhNhan, LanVaoVien, TenTatKhoa);
                }
            }
		}
		
		private void Load_BenhNhan(string MaBenhNhan,string LanVaoVien)
		{
			System.Data.SqlClient.SqlDataReader dr;
			System.Data.SqlClient.SqlCommand SQLCmd= new System.Data.SqlClient.SqlCommand();
			SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            if (LanVaoVien == "0")
            {
                SQLCmd.CommandText = "select [KHAMBENH103].DBO.tblBENHNHAN.*,NoiO+TenTinh_TP As NoiODu,KetLuan,MaKhoaDieuTri,MaBenhChinh,TenBenh,TenDT,NgayKham,year(GetDate())-NamSinh As Tuoi,'' As SoHSBA,'' As HinhThucVV,0 As LanVaoVien,null As NgayVaoVien,Null as HinhThuc_VV,Null As Buong, Null As Giuong,TenKhoa,MaBS,'' As MucAn,MaNoiCapBHYT,MaDTBHYT,TenDonVi As DonVi_ChiTiet,MaThanhPhan "
                    + " from ((([KHAMBENH103].DBO.tblBENHNHAN "
                    + " INNER JOIN [KHAMBENH103].DBO.tblKHAMBENH ON [KHAMBENH103].DBO.tblBENHNHAN.MaBenhNhan= [KHAMBENH103].DBO.tblKHAMBENH.MabenhNhan)"
                    + " LEFT JOIN DMBENH ON MaBenhChinh=MaBenh)"
                    + " LEFT JOIN DMKHOAPHONG ON MaKhoaDieuTri=MaKhoa)"
                    + " INNER JOIN DMDOITUONGBN ON MaDoiTuong=MaDT"
                    + " WHERE [KHAMBENH103].DBO.tblKHAMBENH.MaBenhNhan='" + MaBenhNhan + "' AND HuongGQ=4 AND IsNull(SoBenhAn,'')=''"
                    + " ORDER BY [KHAMBENH103].DBO.tblBENHNHAN.MaBenhNhan, thuTuKham";
            }
            else
            {
                SQLCmd.CommandText = string.Format("SELECT BENHNHAN.MaBenhNhan,HoTen as TenBenhNhan,Year(GetDate())-NamSinh As Tuoi,GioiTinh,MaDanToc,NgayVaoVien,BENHNHAN_CHITIET.*,TrieuChung_VV As KetLuan,ChanDoan_PK_BenhChinh As MaBenhChinh,TenBenh,DoiTuong As MaDoiTuong,CapBac As MaCapBac,DonVi as MaDonVi,TenKhoa,ViewKHOAHIENTAI.MaKhoa as MaKhoaDieuTri,BacSyKham As maBS,NgayKham,MaNoiCapBHYT,MaDTBHYT,DonVi_ChiTiet,MaThanhPhan,NoiO as NoiODu "
                        + " FROM (((BENHNHAN INNER JOIN BENHNHAN_CHITIET ON BENHNHAN.MabenhNhan=BENHNHAN_CHITIET.MaBenhNhan) "
                        + " LEFT JOIN DMBENH ON ChanDoan_PK_BenhChinh=MaBenh)"
                        + " INNER JOIN ViewKHOAHIENTAI ON BENHNHAN_CHITIET.MaBenhNhan=ViewKHOAHIENTAI.MaBenhNhan AND BENHNHAN_CHITIET.LanVaoVien=ViewKHOAHIENTAI.LanVaoVien) "
                        + " INNER JOIN DMKHOAPHONG ON ViewKHOAHIENTAI.MaKhoa=DMKHOAPHONG.MaKhoa "
                        + " where benhnhan.mabenhnhan='{0}' "
                        + " AND BENHNHAN_CHITIET.LanVaoVien={1}", MaBenhNhan, LanVaoVien);

            }
			dr=SQLCmd.ExecuteReader();
			if (dr.HasRows)
			{
				dr.Read();
				lblMaBN.Text = MaBenhNhan;
				lblLanVV.Text = dr["LanVaoVien"].ToString();
				txtSoHSBA.Text= dr["SoHSBA"].ToString();
				txtNgayVaoVien.Value = dr["NgayVaoVien"];
				//txtNgayGioVV.Value =DateTime.FromOADate((double)dr["NgayVaoVien"]);
				txtHoTen.Text = dr["TenBenhNhan"].ToString();
				txtTuoi.Text = dr["Tuoi"].ToString();
                Global.SetCmb(cmbHinhThucVV, dr["HinhThuc_VV"].ToString());
                Global.SetCmb(cmbMucAn, dr["MucAn"].ToString());
				txtSoTheBHYT.Text = dr["SoTheBHYT"].ToString();
                txtMaNoiCapBHYT.Text = dr["MaNoiCapBHYT"].ToString();
                txtMaDTBHYT.Text = dr["MaDTBHYT"].ToString();
				Global.SetCmb(cmbGioiTinh,dr["GioiTinh"].ToString());
				Global.SetCmb(cmbDanToc,dr["MaDanToc"].ToString());
				Global.SetCmb(cmbCapBac,dr["MaCapBac"].ToString());				
				Global.SetCmb(cmbDonVi,dr["MaDonVi"].ToString());
                Global.SetCmb(cmbDoiTuong, dr["MaDoiTuong"].ToString());
                Global.SetCmb(cmbThanhPhan, dr["MaThanhPhan"].ToString());
                txtDonVi_ChiTiet.Text = dr["DonVi_ChiTiet"].ToString();
				txtLienHe.Text = dr["LienHe"].ToString();
                if (dr["MaDoiTuong"].ToString().Trim() == "2") // Doi tuong Quan
                {
                    txtDonVi_ChiTiet.Text = dr["NoiO"].ToString();
                    txtDiaChi.Text = "";
                }
                else
                {
                    txtDonVi_ChiTiet.Text = "";
                    txtDiaChi.Text = dr["NoiODu"].ToString();
                }
				Global.SetCmb(cmbTinh_TP,dr["MaTinh_TP"].ToString());	
				txtChanDoan_PK.Text= dr["KetLuan"].ToString();
                txtICD_PK.Text = dr["MaBenhChinh"].ToString();
                lblICD_PK.Text = dr["tenBenh"].ToString();
				txtICD_PK.Tag = dr["MabenhChinh"].ToString();
                lblKhoa.Tag = dr["MaKhoaDieuTri"];
                lblKhoa.Text = dr["TenKhoa"].ToString();
                lblBacSy.Text = dr["maBS"].ToString();
                lblNgayKham.Text = string.Format("{0:dd/MM/yyyy}", dr["NgayKham"]);
                lblNgayKham.Tag = dr["NgayKham"];                
			}
			dr.Close();
            if (LanVaoVien == "0")
            {
                string SoHSBA = lblKhoa.Tag.ToString() + string.Format("-{0:yy}-", GlobalModuls.Global.NgayLV);
                SQLCmd.CommandText = "SELECT Max(SoHSBA) As MaxHSBA FROM BENHNHAN_CHITIET WHERE SoHSBA Like '" + SoHSBA + "%'";
                dr = SQLCmd.ExecuteReader();
                dr.Read();
                if (dr["MaxHSBA"].ToString() == "") { SoHSBA += "0001"; }
                else
                {
                    SoHSBA += string.Format("{0:0000}", int.Parse(dr["maxHSBA"].ToString().Substring(dr["maxHSBA"].ToString().LastIndexOf("-") + 1)) + 1);
                }
                txtSoHSBA.Text = SoHSBA;
                dr.Close();
                txtNgayVaoVien.Value = DateTime.Now;
            }
			SQLCmd.Dispose();
            SetOptionHSBA(Global.GetCode(cmbDoiTuong));
            cmbHinhThucVV.SelectedIndex = cmbMucAn.SelectedIndex = 0;
            lblMaBN.Text = MaBenhNhan;
            lblLanVV.Text = LanVaoVien;
		}

		private void fgDanhSach_AfterSelChange(object sender, C1.Win.C1FlexGrid.RangeEventArgs e)
		{
			if (fgDanhSach.Tag.ToString() =="0" || fgDanhSach.Row<1) {return;}
            Load_BenhNhan(fgDanhSach.GetDataDisplay(fgDanhSach.Row, 1), fgDanhSach.GetDataDisplay(fgDanhSach.Row, "LanVaoVien"));
		}

		private void Clear_Data()
		{
			lblMaBN.Text ="";
			lblLanVV.Text ="";
			txtSoHSBA.Text = "";
			txtHoTen.Text ="";
			txtTuoi.Text ="";
			cmbGioiTinh.SelectedIndex =-1;
			cmbDanToc.SelectedIndex =-1;
			cmbCapBac.SelectedIndex=-1;
			cmbDonVi.SelectedIndex=-1;
            txtDonVi_ChiTiet.Text = "";
            txtMaNoiCapBHYT.Text = "";
            txtMaDTBHYT.Text = "";
			txtChucVu.Text = "";			
			txtLienHe.Text ="";
			txtDiaChi.Text ="";
			txtNgayVaoVien.Value =null;
			cmbDoiTuong.SelectedIndex=-1;
			cmbHinhThucVV.SelectedIndex =-1;
			
			txtICD_PK.Text ="";
			txtICD_PK.Tag ="";
            lblICD_PK.Text = "";
            txtICD_NoiChuyen.Text = "";
            txtICD_NoiChuyen.Tag = "";
            lblICD_NoiChuyen.Text = "";
			cmbTinh_TP.SelectedIndex = -1;
            lblKhoa.Tag = "";
            lblKhoa.Text = "";
		}

		private void cmdXoa_Click(object sender, System.EventArgs e)
		{
			if (txtSoHSBA.Text.Trim()=="")
			{
				MessageBox.Show("Chưa chọn bệnh nhân để xóa!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return;
			}
			if (MessageBox.Show("Bạn có chắc muốn xóa bệnh nhân này không?","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.No) {return;}
			System.Data.SqlClient.SqlDataReader dr;
			System.Data.SqlClient.SqlCommand SQLCmd= new System.Data.SqlClient.SqlCommand();
			SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
			SQLCmd.CommandText  = "SELECT * FROM BENHNHAN_CHIPHI WHERE MaBenhNhan='" + lblMaBN.Text  +"' AND LanvaoVien=" + lblLanVV.Text ;
			dr=SQLCmd.ExecuteReader();
			if (dr.HasRows)
			{
				MessageBox.Show("Đã cập nhật chi phí của bệnh nhân, không thể xóa được bệnh nhân này!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
				dr.Close();
				SQLCmd.Dispose();
				return;
			}
			dr.Close();
            System.Data.SqlClient.SqlTransaction trn = Global.ConnectSQL.BeginTransaction();
            SQLCmd.Transaction = trn;
            try
            {
                SQLCmd.CommandText = "DELETE FROM BENHNHAN_CHITIET WHERE MaBenhNhan='" + lblMaBN.Text + "' AND LanVaoVien=" + lblLanVV.Text;
                SQLCmd.ExecuteNonQuery();
                if (lblLanVV.Text == "1")
                {
                    SQLCmd.CommandText = "DELETE FROM BENHNHAN WHERE MaBenhNhan='" + lblMaBN.Text + "'";
                    SQLCmd.ExecuteNonQuery();
                    SQLCmd.CommandText = "UPDATE KHAMBENH103.DBO.tblKhamBenh SET SoHSBA=null WHERE MaBenhNhan='" + lblMaBN.Text + "'";
                    SQLCmd.ExecuteNonQuery();
                }
                trn.Commit();
                fgDanhSach.RemoveItem(fgDanhSach.Row);
                if (fgDanhSach.Rows.Count == 1) { Clear_Data(); }
            }
            catch (Exception ex)
            {
                trn.Rollback();
            }
            finally
            {
                SQLCmd.Dispose();
                trn.Dispose();
            }
			
        }
		
		private string SinhSHSBA(string MaKhoa)
		{
			string HeaderBA = string.Format("{0}{1}",Global.NgayLV.Year.ToString().Substring(2) ,MaKhoa);
			string SoHSBA="";
			System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("SELECT Max(SoHSBA) As MaxHSBA FROM BENHNHAN WHERE SoHSBA LIKE '" + HeaderBA + "%'",Global.ConnectSQL);
			System.Data.SqlClient.SqlDataReader dr = cmd.ExecuteReader();
			dr.Read();
			if (dr["MaxHSBA"].ToString()=="")
			{	
				SoHSBA = HeaderBA + "00001";
			}
			else
			{				
				SoHSBA = string.Format("{0}{1:00000}",HeaderBA,long.Parse(dr["MaxHSBA"].ToString().Substring(5))+1);
			}
			dr.Close();
			cmd.Dispose();
			return SoHSBA;
		}

		private void txtICD_PK_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (txtICD_PK.Text !="")
			{
				NamDinh_QLBN.Forms.DanhMuc.frmShowICD10 fr = new NamDinh_QLBN.Forms.DanhMuc.frmShowICD10(txtICD_PK.Text,txtICD_PK,2);
                fr.ShowDialog();
                string TextReturn = fr.TextReturn;
                lblICD_PK.Text = TextReturn.Substring(TextReturn.IndexOf("|") + 1);
			}
		}
		private int GhiDuLieuBenhAn(Boolean ChuaVaoVien,out String MaBenhNhan,out string _LanVaoVien,out string TenTatKhoa)
		{
			System.Data.SqlClient.SqlDataReader dr;
			System.Data.SqlClient.SqlTransaction trsBN;
			System.Data.SqlClient.SqlCommand SQLCmd= new System.Data.SqlClient.SqlCommand();			
			SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
			int LanVaoVien=1;
#region Nếu là bệnh nhân chưa làm bệnh án            
            if (ChuaVaoVien)
            {
                SQLCmd.CommandText = "select MaBenhNhan,Max(LanVaoVien) as MaxLan FROM BENHNHAN_CHITIET"
                                    + " WHERE MaBenhNhan='" + lblMaBN.Text + "'"
                                    + " GROUP BY MaBenhNhan";
                dr = SQLCmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    LanVaoVien = int.Parse(dr["MaxLan"].ToString()) + 1;
                }
                dr.Close();
                trsBN = Global.ConnectSQL.BeginTransaction();
                try
                {
                    SQLCmd.Transaction = trsBN;
                    SQLCmd.CommandText = string.Format("UPDATE [KHAMBENH103].DBO.tblKHAMBENH SET SoBenhAn='{0}', NgayVaoVien='{1:MM/dd/yyyy HH:mm}' WHERE MaBenhNhan='{2}' AND HuongGQ=4 AND IsNull(SoBenhAn,'')=''", txtSoHSBA.Text, txtNgayVaoVien.Value, lblMaBN.Text);
                    SQLCmd.ExecuteNonQuery();
                    if (LanVaoVien == 1) //Chua co du lieu benh nhan
                    {
                        SQLCmd.CommandText = string.Format("INSERT INTO BENHNHAN (MaBenhNhan,HoTen,NamSinh,GioiTinh,MaDanToc) VALUES ('{0}',N'{1}',{2},{3},{4})", lblMaBN.Text, txtHoTen.Text, Global.NgayLV.Year - int.Parse(txtTuoi.Text), Global.GetCode(cmbGioiTinh), (Global.GetCode(cmbDanToc) == null) ? ("Null") : ("'" + Global.GetCode(cmbDanToc) + "'"));
                        SQLCmd.ExecuteNonQuery();
                    }
                    SQLCmd.CommandText = string.Format("INSERT INTO BENHNHAN_CHITIET (MaBenhNhan,LanVaoVien,SoHSBA,SoTheBHYT,DoiTuong,Capbac,NoiO,DonVi,MaTinh_TP,LienHe,NgayVaoVien,TrieuChung_VV,ChanDoan_PK_BenhChinh,HinhThuc_VV,TrangThai,BacSyKham,NgayKham,DonVi_ChiTiet,MaNoiCapBHYT,MaDTBHYT,MaThanhPhan) VALUES "
                                                + "('{0}',{1},'{2}','{3}',{4},{5},N'{6}',{7},{8},N'{9}','{10:MM/dd/yyyy HH:mm}',N'{11}','{12}',{13},3,N'{14}',{15},N'{16}','{17}','{18}',{19})",
                                                lblMaBN.Text,
                                                LanVaoVien,
                                                txtSoHSBA.Text,
                                                txtSoTheBHYT.Text,
                                                Global.GetCode(cmbDoiTuong),
                                                (Global.GetCode(cmbCapBac) == null) ? ("Null") : ("'" + Global.GetCode(cmbCapBac) + "'"),
                                                txtDiaChi.Text,
                                                (Global.GetCode(cmbDonVi) == null) ? ("Null") : ("'" + Global.GetCode(cmbDonVi) + "'"),
                                                (Global.GetCode(cmbTinh_TP) == null) ? ("Null") : ("'" + Global.GetCode(cmbTinh_TP) + "'"),
                                                txtLienHe.Text,
                                                txtNgayVaoVien.Value,
                                                txtChanDoan_PK.Text,
                                                txtICD_PK.Text,
                                                (Global.GetCode(cmbHinhThucVV) == null) ? ("Null") : ("'" + Global.GetCode(cmbHinhThucVV) + "'"),
                                                lblBacSy.Text, (lblNgayKham.Text == "") ? ("Null") : (string.Format("'{0:MM/dd/yyyy}'", lblNgayKham.Tag)),txtDonVi_ChiTiet.Text,txtMaNoiCapBHYT.Text,txtMaDTBHYT.Text,
                                                (Global.GetCode(cmbThanhPhan) == null) ? ("Null") : ("'" + Global.GetCode(cmbThanhPhan) + "'"));
                    SQLCmd.ExecuteNonQuery();
                    SQLCmd.CommandText = string.Format("INSERT INTO BENHNHAN_DOITUONG (MaBenhNhan,LanVaoVien,LanChuyenDT,NgayChuyen,DoiTuong) VALUES ('{0}',{1},{2},'{3:MM/dd/yyyy}',{4})",
                                                lblMaBN.Text,
                                                LanVaoVien,
                                                0,
                                                txtNgayVaoVien.Value,
                                                Global.GetCode(cmbDoiTuong));
                    SQLCmd.ExecuteNonQuery();
                    SQLCmd.CommandText = string.Format("INSERT INTO BENHNHAN_KHOA (MaBenhNhan,LanVaoVien,LanChuyenKhoa,NgayChuyen,MaKhoa) VALUES ('{0}',{1},{2},'{3:MM/dd/yyyy}','{4}')",
                                                lblMaBN.Text,
                                                LanVaoVien,
                                                0,
                                                txtNgayVaoVien.Value,
                                                lblKhoa.Tag);
                    SQLCmd.ExecuteNonQuery();
                    trsBN.Commit();
                    trsBN.Dispose();
                    TenTatKhoa = fgDanhSach[fgDanhSach.Row, "MaKhoa"].ToString();
                    _LanVaoVien = LanVaoVien.ToString();
                    MaBenhNhan = lblMaBN.Text;
                    fgDanhSach.RemoveItem(fgDanhSach.Row);
                    lblMaBN.Text = "";
                    return 1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi khi ghi dữ liệu\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    trsBN.Rollback();
                    trsBN.Dispose();
                    SQLCmd.Dispose();
                    MaBenhNhan = "";
                    _LanVaoVien = "";
                    TenTatKhoa = "";
                    return -1;
                }
            }
#endregion
            else
            {
                trsBN = Global.ConnectSQL.BeginTransaction();
                try
                {
                    SQLCmd.Transaction = trsBN;
                    SQLCmd.CommandText = string.Format("UPDATE BENHNHAN SET HoTen=N'{0}',NamSinh={1},GioiTinh={2},MaDanToc='{3}' WHERE MaBenhNhan='{4}'", txtHoTen.Text, Global.NgayLV.Year - int.Parse(txtTuoi.Text), Global.GetCode(cmbGioiTinh), Global.GetCode(cmbDanToc), lblMaBN.Text);
                    SQLCmd.ExecuteNonQuery();
                    SQLCmd.CommandText = string.Format("UPDATE BENHNHAN_CHITIET Set SoHSBA='{0}',SoTheBHYT='{1}',DoiTuong='{2}',Capbac={3},NoiO=N'{4}',DonVi={5},MaTinh_TP={6},"
                                    + "LienHe=N'{7}',NgayVaoVien='{8:MM/dd/yyyy HH:mm}',ChanDoan_PK_BenhChinh='{9}',HinhThuc_VV={10},MucAn={13},DonVi_ChiTiet=N'{14}',MaNoiCapBHYT='{15}',MaDTBHYT='{16}',MaThanhPhan={17} WHERE MaBenhNhan='{11}' AND LanVaoVien='{12}'",
                                    txtSoHSBA.Text,
                                    txtSoTheBHYT.Text,
                                    Global.GetCode(cmbDoiTuong),
                                    (Global.GetCode(cmbCapBac) == null) ? ("Null") : ("'" + Global.GetCode(cmbCapBac) + "'"),
                                    txtDiaChi.Text,
                                    (Global.GetCode(cmbDonVi) == null) ? ("Null") : ("'" + Global.GetCode(cmbDonVi) + "'"),
                                    (Global.GetCode(cmbTinh_TP) == null) ? ("Null") : ("'" + Global.GetCode(cmbTinh_TP) + "'"),
                                    txtLienHe.Text,
                                    txtNgayVaoVien.Value,
                                    txtICD_PK.Text,
                                    (Global.GetCode(cmbHinhThucVV) == null) ? ("Null") : ("'" + Global.GetCode(cmbHinhThucVV) + "'"),                                    
                                    lblMaBN.Text,
                                    lblLanVV.Text,
                                    (Global.GetCode(cmbMucAn) == null) ? ("Null") : ("'" + Global.GetCode(cmbMucAn) + "'"), txtDonVi_ChiTiet.Text,txtMaNoiCapBHYT.Text ,txtMaDTBHYT.Text,
                                    (Global.GetCode(cmbThanhPhan) == null) ? ("Null") : ("'" + Global.GetCode(cmbThanhPhan) + "'"));
                    SQLCmd.ExecuteNonQuery();
                    
                    SQLCmd.CommandText = string.Format("UPDATE BENHNHAN_DOITUONG SET DoiTuong={2} WHERE MaBenhNhan='{0}' AND LanVaoVien={1} AND LanChuyenDT=0",
                                               lblMaBN.Text,
                                               LanVaoVien,                                               
                                               Global.GetCode(cmbDoiTuong));
                    SQLCmd.ExecuteNonQuery();
                    
                    trsBN.Commit();
                    TenTatKhoa = fgDanhSach[fgDanhSach.Row, "MaKhoa"].ToString();
                    _LanVaoVien = LanVaoVien.ToString();
                    MaBenhNhan = lblMaBN.Text;
                    return 1;
                }
                catch (Exception ex)
                {
                    trsBN.Rollback();
                    MessageBox.Show("Có lỗi khi ghi dữ liệu\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TenTatKhoa = "";
                    _LanVaoVien = "";
                    MaBenhNhan = "";
                    return -1;
                }
            }
        }

        private void txtICD_NoiChuyen_Validating(object sender, CancelEventArgs e)
        {
            if (txtICD_NoiChuyen.Text != "")
            {
                NamDinh_QLBN.Forms.DanhMuc.frmShowICD10 fr = new NamDinh_QLBN.Forms.DanhMuc.frmShowICD10(txtICD_NoiChuyen.Text, txtICD_NoiChuyen, 2);
                fr.ShowDialog();
                string TextReturn = fr.TextReturn;
                lblICD_NoiChuyen.Text = TextReturn.Substring(TextReturn.IndexOf("|") + 1);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            //string MaKhoa=Global.GetCode(cmbKhoa);
            string MaKhoa = lblKhoa.Tag.ToString();
            if (txtMaBN.Text.Length == 3) txtMaBN.Text = string.Format("{0:yyMMdd}",txtLocNgay.Value) + txtMaBN.Text;
            if (rdChualamBA.Checked)
            {
                fgDanhSach[0, 6] = "Ngày khám";
                fgDanhSach.Cols[7].Visible = true;
                SQLCmd.CommandText = "select [KHAMBENH103].DBO.tblBENHNHAN.*,KetLuan,MaKhoaDieuTri,MaBenhChinh,TenBenh,TenDT,NgayKham,year(GetDate())-NamSinh As Tuoi,0 As LanVaoVien,TenTat As TenKhoa,TenPhongKham,NgayHenNV from (((([KHAMBENH103].DBO.tblBENHNHAN "
                                + " INNER JOIN [KHAMBENH103].DBO.tblKHAMBENH ON [KHAMBENH103].DBO.tblBENHNHAN.MaBenhNhan= [KHAMBENH103].DBO.tblKHAMBENH.MabenhNhan)"
                                + " LEFT JOIN DMKHOAPHONG ON MaKhoaDieuTri=MaKhoa)"
                                + " LEFT JOIN DMBENH ON MaBenhChinh=MaBenh)"
                                + " INNER JOIN DMDOITUONGBN ON MaDoiTuong=MaDT)"
                                + " INNER JOIN (SELECT MaKhoa,TenKhoa As TenPhongKham FROM [KHAMBENH103].DBO.DMKHOAPHONG WHERE MaKhoa like 'K%') Q1 "
                                + " ON [KHAMBENH103].DBO.tblKHAMBENH.MaPK = Q1.MaKhoa "
                                + " WHERE HuongGQ=4 AND IsNull(SoBenhAn,'')='' "
                                + string.Format(" AND [KHAMBENH103].DBO.tblBENHNHAN.MaBenhNhan='{0}'", txtMaBN.Text)
                                + " ORDER BY [KHAMBENH103].DBO.tblBENHNHAN.MaBenhNhan, thuTuKham";
            }
            else
            {
                fgDanhSach[0, 6] = "Ngày lập BA";
                fgDanhSach.Cols[7].Visible = false;
                SQLCmd.CommandText = "select BENHNHAN.MaBenhNhan,BENHNHAN.HoTen As TenBenhNhan,Year(GetDate())-NamSinh as Tuoi,GioiTinh,TenDT,'' As NgayHenNV,NgayVaoVien As NgayKham,BENHNHAN_CHITIET.LanVaoVien,TenTat As TenKhoa,'' As TenPhongKham "
                                + " FROM (((BENHNHAN INNER JOIN BENHNHAN_CHITIET ON BENHNHAN.MaBenhNhan=BENHNHAN_CHITIET.MaBenhNhan)"
                                + " INNER JOIN DMDOITUONGBN ON BENHNHAN_CHITIET.DoiTuong=DMDOITUONGBN.MaDT)"
                                + " INNER JOIN ViewKHOAHIENTAI ON BENHNHAN_CHITIET.MaBenhNhan=ViewKHOAHIENTAI.MaBenhNhan AND BENHNHAN_CHITIET.LanVaoVien=ViewKHOAHIENTAI.LanVaoVien)"
                                + " INNER JOIN DMKHOAPHONG ON ViewKHOAHIENTAI.MaKhoa=DMKHOAPHONG.MaKhoa "
                                + " WHERE TrangThai>1 "
                                + string.Format(" AND BENHNHAN.MaBenhNhan='{0}'", txtMaBN.Text);
            }
            dr = SQLCmd.ExecuteReader();
            fgDanhSach.Tag = "0";
            fgDanhSach.Redraw = false;
            fgDanhSach.Rows.Count = 1;
            while (dr.Read())
            {
                fgDanhSach.AddItem(string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6:dd/MM/yyyy}|{7:dd/MM/yyyy}|{8}|{9}|{10}", fgDanhSach.Rows.Count,
                    dr["MaBenhNhan"],
                    dr["TenBenhNhan"],
                    dr["Tuoi"],
                    (dr["GioiTinh"].ToString() == "1") ? ("Nam") : ("Nữ"),
                    dr["TenDT"],
                    dr["NgayKham"], dr["NgayHenNV"], dr["LanVaoVien"], dr["TenKhoa"], dr["TenPhongKham"]));
            }
            dr.Close();
            fgDanhSach.AutoSizeCols();
            fgDanhSach.Tag = "1";
            fgDanhSach.Redraw = true;
            SQLCmd.Dispose();
            fgDanhSach.Row = -1;
            Clear_Data();
            
            if (fgDanhSach.Rows.Count > 1) fgDanhSach.Row = 1;
        }

        private void txtMaBN_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                //for (int i = 1; i < fgDanhSach.Rows.Count; i++)
                //{
                //    if (fgDanhSach.GetDataDisplay(i, 1) == txtMaBN.Text)
                //    {
                //        fgDanhSach.Row = i;
                //        fgDanhSach.TopRow = i;
                //        break;
                //    }
                //}
                button1_Click(null, null);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool found = false;
            for (int i = FoundedRow + 1; i < fgDanhSach.Rows.Count; i++)
            {
                if (fgDanhSach.GetDataDisplay(i, 2).IndexOf(txtTimTen.Text,StringComparison.OrdinalIgnoreCase)>-1)
                {
                    fgDanhSach.Row = i;
                    fgDanhSach.TopRow = i;
                    FoundedRow = i;
                    found = true;
                    break;
                }
            }
            if (!found) { FoundedRow = 0; }
        }

        private void txtTimTen_TextChanged(object sender, EventArgs e)
        {
            FoundedRow = 0;
        }

        private void txtTimTen_KeyUp(object sender, KeyEventArgs e)
        {
            bool found = false;
            if (e.KeyCode == Keys.Enter)
            {
                for (int i = FoundedRow + 1; i < fgDanhSach.Rows.Count; i++)
                {
                    if (fgDanhSach.GetDataDisplay(i, 2).IndexOf(txtTimTen.Text, StringComparison.OrdinalIgnoreCase) > -1)
                    {
                        fgDanhSach.Row = i;
                        fgDanhSach.TopRow = i;
                        FoundedRow = i;
                        found = true;
                        break;
                    }
                }
            }
            if (!found) { FoundedRow = 0; }
        }

        private void rdChualamBA_CheckedChanged(object sender, EventArgs e)
        {
            Load_DSBenhNhan(rdChualamBA.Checked);
            if (rdChualamBA.Checked)
            {
                label28.Text = " Ngày hẹn";
            }
            else
            {
                label28.Text = " Ngày làm BA";
            }
            simpleButton1.Visible = !rdChualamBA.Checked;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc muốn xóa dữ liệu của bệnh nhân này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question,MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            if (XoaDuLieu(lblMaBN.Text, lblLanVV.Text) == 0)
            {
                MessageBox.Show("Đã xóa bệnh án của bệnh nhân!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                Load_DSBenhNhan(false);
            }
        }
        private int XoaDuLieu(string MaBenhNhan, string LanVaoVien)
        {
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlTransaction trn;
            SQLCmd.Connection = Global.ConnectSQL;
            trn = Global.ConnectSQL.BeginTransaction();            
            SQLCmd.Transaction = trn;
            int k = 0;
            try
            {
                //Xoa o benhnhan_chitiet voi lanVV = LanVaoVien
                SQLCmd.CommandText = string.Format("Delete from BENHNHAN_CHITIET where MaBenhNhan = '"+ MaBenhNhan +"' and LanVaoVien ='"+ LanVaoVien +"'");
                SQLCmd.ExecuteNonQuery();
                //Xoa o benhnhan neu lanVV =1
                if (LanVaoVien =="1")
                {
                    SQLCmd.CommandText = string.Format("Delete from BENHNHAN where MaBenhNhan = '" + MaBenhNhan + "'");
                    SQLCmd.ExecuteNonQuery();
                }
                //Xoa o benh nhan_khoa voi 2 dieu kien tren
                SQLCmd.CommandText = string.Format("Delete from BENHNHAN_KHOA where MaBenhNhan = '" + MaBenhNhan + "' and LanVaoVien ='" + LanVaoVien + "'");
                SQLCmd.ExecuteNonQuery();
                // Xoa o benhnhan_doituong voi 2 DK
                SQLCmd.CommandText = string.Format("Delete from BENHNHAN_DOITUONG where MaBenhNhan = '" + MaBenhNhan + "' and LanVaoVien ='" + LanVaoVien + "'");
                SQLCmd.ExecuteNonQuery();
                //Update lai truong NgayVaoVien = null,SOHSBA = null o bang BenhNhan DataBase KhamBenh103 = 0
                SQLCmd.CommandText = string.Format("UPDATE [KHAMBENH103].DBO.tblKHAMBENH SET SoBenhAn=null, NgayVaoVien=null WHERE MaBenhNhan='{0}' ", MaBenhNhan);
                SQLCmd.ExecuteNonQuery();
                trn.Commit();
            }
            catch (Exception ex)
            {
                trn.Rollback();
                MessageBox.Show("Có lỗi khi xóa dữ liệu\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                k = -1;
            }
            finally
            {
                SQLCmd.Dispose();
                trn.Dispose();
                //return -1;
            }
            return (k);
        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            if (lblMaBN.Text == "") return;
            string TenTatKhoa = fgDanhSach[fgDanhSach.Row, "MaKhoa"].ToString();
            string LanVaoVien = lblLanVV.Text;
            InBenhAn(lblMaBN.Text, LanVaoVien, TenTatKhoa);
        }
        private void InBenhAn(string MaBenhNhan,string LanVaoVien,string TenTatKhoa)
        {
            
            DataDynamics.ActiveReports.ActiveReport3 rpt = null;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            System.Data.SqlClient.SqlDataReader dr;
            SQLCmd.CommandText = string.Format("SELECT * FROM KHOA_BENHAN  WHERE MaKhoa='{0}'", lblKhoa.Tag);//KHOA_BENHAN
            dr = SQLCmd.ExecuteReader();
            ArrayList ar = new ArrayList();
            while (dr.Read())
            {
                ar.Add(dr["MaBenhAn"]);//MaBenhAn
            }
            dr.Close();
            SQLCmd.Dispose();
            for (int i = 0; i < ar.Count; i++)
            {
                switch (ar[i].ToString())
                {
                    case "1":
                        rpt = new NamDinh_QLBN.Reports.rptBenhAnNgoai(MaBenhNhan,LanVaoVien,TenTatKhoa);
                        rpt.Run();
                        rpt.Show();
                        break;
                    case "2":
                        rpt = new NamDinh_QLBN.Reports.rptBenhAnNoi(MaBenhNhan, LanVaoVien, TenTatKhoa);
                        rpt.Run();
                        rpt.Show();
                        break;
                    case "3":
                        rpt = new NamDinh_QLBN.Reports.rptBenhAnThanKinh(MaBenhNhan, LanVaoVien, TenTatKhoa);
                        rpt.Run();
                        rpt.Show();
                        break;
                    case "4":
                        rpt = new NamDinh_QLBN.Reports.rptBenhAnSan(MaBenhNhan, LanVaoVien, TenTatKhoa);
                        rpt.Run();
                        rpt.Show();
                        break;
                    case "5":
                        rpt = new NamDinh_QLBN.Reports.rptBenhAnSoSinh(MaBenhNhan, LanVaoVien, TenTatKhoa);
                        rpt.Run();
                        rpt.Show();
                        break;
                    case "6":
                        rpt = new NamDinh_QLBN.Reports.rptBenhAnYHCT(MaBenhNhan, LanVaoVien, TenTatKhoa);
                        rpt.Run();
                        rpt.Show();
                        break;
                    case "7":
                        rpt = new NamDinh_QLBN.Reports.rptBenhAnMat(MaBenhNhan, LanVaoVien, TenTatKhoa);
                        rpt.Run();
                        rpt.Show();
                        break;
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Load_DSBenhNhan(rdChualamBA.Checked);
        }

        private void cmbDoiTuong_TextChanged(object sender, EventArgs e)
        {
            if (cmbDoiTuong.Tag.ToString() == "0" || cmbDoiTuong.SelectedIndex ==-1) return;
            string MaDT = Global.GetCode(cmbDoiTuong);
            cmbThanhPhan.ClearItems();            
            for (int i = 0; i < arrThanhPhan.GetUpperBound(0);i++ )
            {
                if (arrThanhPhan[i].MaDoiTuongBN == MaDT.Substring(0,1))
                    cmbThanhPhan.AddItem(string.Format("{0};{1}", arrThanhPhan[i].MaThanhPhan, arrThanhPhan[i].TenThanhPhan));
            }            
        }

        private void label30_Click(object sender, EventArgs e)
        {
            NamDinh_QLBN.Forms.DuLieu.frmThongTinBN_PK frm = new frmThongTinBN_PK();
            //frm.MdiParent = this.MdiParent;
            frm.TopMost = true;            
            frm.Show();            
        }
    }
}
