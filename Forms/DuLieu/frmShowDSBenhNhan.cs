using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace NamDinh_QLBN.Forms.DuLieu
{
	/// <summary>
	/// Summary description for frmShowDSBenhNhan.
	/// </summary>
	public class frmShowDSBenhNhan : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button cmdOK;
		private System.Windows.Forms.Button cmdCancel;
		private C1.Win.C1FlexGrid.C1FlexGrid fg;
        private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Button cmdTim;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
        private string TrangThaiBN = "";
		private string MaBenhNhan="";
		private string MaKhoa="";
        public string MaVaoVienReturn="";
		public string SoHSBAReturn="";
		public string HoTenReturn="";
		public string GioiReturn="";
		public string TuoiReturn="";
		public long KyQuy=0;
		public byte MucGiaReturn=0;
		public string MaDoiTuongReturn="";
        public string TenDoiTuongReturn = "";
        public string NgayVaoVienReturn = "";
		public byte LanVaoVienReturn=0;
        public string TenBuongReturn = "";
        public string TenGiuongReturn = "";
        public string MaGiuongYTReturn = "";
        public string MaICDBCReturn = "";
        public string MAICDBP_1Return = "";
        public String MaNhom = "";
        public String TenNhom = "";
        public string is_covidReturn = "";

        public string MabacSY = "";

		private string tblname="";
        private Label label1;
        private TextBox txtSHSBA;
        private RadioButton raDangDT;
        private RadioButton raDaRV;
        private C1.Win.C1Input.C1DateEdit txtTuNgay;
        private Label label4;
        private C1.Win.C1Input.C1DateEdit txtDenNgay;
        private Label label3;
        private RadioButton raChuyenKhoa;
        private GroupBox groupBox1;
        internal C1.Win.C1List.C1Combo cmbNhom;
        private Label label14;
        private byte vDaRaVien = 0;
        public string DaTinhPhiReturn = "";
        public string ChanDoanReturn = "";
        public byte DaRaVienReturn ;
        public DateTime NgayKhamReturn;
        int covid;

        public frmShowDSBenhNhan(string _MaBenhNhan,string _MaKhoa,string _TenKhoa,int _TrangThai,byte _vDaRaVien,String MaNhom1,int _covid)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			MaBenhNhan = _MaBenhNhan;
            TrangThaiBN = _TrangThai.ToString();
            vDaRaVien = _vDaRaVien;
            DaRaVienReturn = _vDaRaVien;
            covid = _covid;
            //DaTinhPhiReturn = _DaTinhPhi;
            if (_MaKhoa !=null)
			{
				this.Text +=" - " + _TenKhoa;
				MaKhoa=_MaKhoa;
			}
            MaNhom = MaNhom1;
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}
		public frmShowDSBenhNhan(string _MaBenhNhan,string _MaKhoa,string _TenKhoa,string _TblName,String MaNhom1,string  _DaTinhPhi)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			MaBenhNhan = _MaBenhNhan;
			if (_MaKhoa !=null)
			{
				this.Text +=" - " + _TenKhoa;
				MaKhoa=_MaKhoa;
			}
			tblname = _TblName;
            MaNhom = MaNhom1;
            DaTinhPhiReturn = _DaTinhPhi;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShowDSBenhNhan));
            C1.Win.C1List.Style style1 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style2 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style3 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style4 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style5 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style6 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style7 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style8 = new C1.Win.C1List.Style();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.fg = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdTim = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSHSBA = new System.Windows.Forms.TextBox();
            this.raDangDT = new System.Windows.Forms.RadioButton();
            this.raDaRV = new System.Windows.Forms.RadioButton();
            this.txtTuNgay = new C1.Win.C1Input.C1DateEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDenNgay = new C1.Win.C1Input.C1DateEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.raChuyenKhoa = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbNhom = new C1.Win.C1List.C1Combo();
            this.label14 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.fg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTuNgay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDenNgay)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbNhom)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdOK
            // 
            this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdOK.Image = ((System.Drawing.Image)(resources.GetObject("cmdOK.Image")));
            this.cmdOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdOK.Location = new System.Drawing.Point(295, 598);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(85, 27);
            this.cmdOK.TabIndex = 15;
            this.cmdOK.Text = "  Chọn [F5]";
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Image = ((System.Drawing.Image)(resources.GetObject("cmdCancel.Image")));
            this.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancel.Location = new System.Drawing.Point(397, 598);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(85, 27);
            this.cmdCancel.TabIndex = 16;
            this.cmdCancel.Text = " Thoát [F4]";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // fg
            // 
            this.fg.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.fg.AllowEditing = false;
            this.fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Light3D;
            this.fg.ColumnInfo = resources.GetString("fg.ColumnInfo");
            this.fg.ExtendLastCol = true;
            this.fg.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid;
            this.fg.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fg.HighLight = C1.Win.C1FlexGrid.HighLightEnum.WithFocus;
            this.fg.Location = new System.Drawing.Point(3, 102);
            this.fg.Name = "fg";
            this.fg.Rows.Count = 1;
            this.fg.Rows.MinSize = 20;
            this.fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
            this.fg.ShowCursor = true;
            this.fg.Size = new System.Drawing.Size(485, 493);
            this.fg.Styles = new C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("fg.Styles"));
            this.fg.TabIndex = 48;
            this.fg.DoubleClick += new System.EventHandler(this.cmdOK_Click);
            this.fg.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmShowDSBenhNhan_KeyDown);
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(192, 5);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(192, 20);
            this.txtHoTen.TabIndex = 52;
            this.txtHoTen.TabStop = false;
            this.txtHoTen.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmShowDSBenhNhan_KeyDown);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(132, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 15);
            this.label2.TabIndex = 51;
            this.label2.Text = "Họ và tên";
            // 
            // cmdTim
            // 
            this.cmdTim.Image = ((System.Drawing.Image)(resources.GetObject("cmdTim.Image")));
            this.cmdTim.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdTim.Location = new System.Drawing.Point(390, 4);
            this.cmdTim.Name = "cmdTim";
            this.cmdTim.Size = new System.Drawing.Size(98, 44);
            this.cmdTim.TabIndex = 53;
            this.cmdTim.Text = "Tìm";
            this.cmdTim.Click += new System.EventHandler(this.cmdTim_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 15);
            this.label1.TabIndex = 54;
            this.label1.Text = "Số HSBA";
            // 
            // txtSHSBA
            // 
            this.txtSHSBA.Location = new System.Drawing.Point(63, 5);
            this.txtSHSBA.Name = "txtSHSBA";
            this.txtSHSBA.Size = new System.Drawing.Size(67, 20);
            this.txtSHSBA.TabIndex = 55;
            this.txtSHSBA.TabStop = false;
            this.txtSHSBA.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmShowDSBenhNhan_KeyDown);
            // 
            // raDangDT
            // 
            this.raDangDT.AutoSize = true;
            this.raDangDT.Checked = true;
            this.raDangDT.Location = new System.Drawing.Point(46, 10);
            this.raDangDT.Name = "raDangDT";
            this.raDangDT.Size = new System.Drawing.Size(86, 17);
            this.raDangDT.TabIndex = 56;
            this.raDangDT.TabStop = true;
            this.raDangDT.Text = "Đang điều trị";
            this.raDangDT.UseVisualStyleBackColor = true;
            this.raDangDT.CheckedChanged += new System.EventHandler(this.raDangDT_CheckedChanged);
            this.raDangDT.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmShowDSBenhNhan_KeyDown);
            // 
            // raDaRV
            // 
            this.raDaRV.AutoSize = true;
            this.raDaRV.Location = new System.Drawing.Point(176, 10);
            this.raDaRV.Name = "raDaRV";
            this.raDaRV.Size = new System.Drawing.Size(74, 17);
            this.raDaRV.TabIndex = 57;
            this.raDaRV.Text = "Đã ra viện";
            this.raDaRV.UseVisualStyleBackColor = true;
            this.raDaRV.CheckedChanged += new System.EventHandler(this.raDaRV_CheckedChanged);
            this.raDaRV.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmShowDSBenhNhan_KeyDown);
            // 
            // txtTuNgay
            // 
            this.txtTuNgay.Culture = 1066;
            this.txtTuNgay.CustomFormat = "dd/MM/yyyy";
            this.txtTuNgay.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
            this.txtTuNgay.Location = new System.Drawing.Point(126, 31);
            this.txtTuNgay.Name = "txtTuNgay";
            this.txtTuNgay.Size = new System.Drawing.Size(103, 20);
            this.txtTuNgay.TabIndex = 135;
            this.txtTuNgay.Tag = null;
            this.txtTuNgay.Value = new System.DateTime(2009, 9, 5, 0, 0, 0, 0);
            this.txtTuNgay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmShowDSBenhNhan_KeyDown);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(103, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 134;
            this.label4.Text = "Từ";
            // 
            // txtDenNgay
            // 
            this.txtDenNgay.Culture = 1066;
            this.txtDenNgay.CustomFormat = "dd/MM/yyyy";
            this.txtDenNgay.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
            this.txtDenNgay.Location = new System.Drawing.Point(257, 31);
            this.txtDenNgay.Name = "txtDenNgay";
            this.txtDenNgay.Size = new System.Drawing.Size(103, 20);
            this.txtDenNgay.TabIndex = 137;
            this.txtDenNgay.Tag = null;
            this.txtDenNgay.Value = new System.DateTime(2009, 9, 5, 0, 0, 0, 0);
            this.txtDenNgay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmShowDSBenhNhan_KeyDown);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(230, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 136;
            this.label3.Text = "Đến";
            // 
            // raChuyenKhoa
            // 
            this.raChuyenKhoa.AutoSize = true;
            this.raChuyenKhoa.Location = new System.Drawing.Point(320, 10);
            this.raChuyenKhoa.Name = "raChuyenKhoa";
            this.raChuyenKhoa.Size = new System.Drawing.Size(88, 17);
            this.raChuyenKhoa.TabIndex = 139;
            this.raChuyenKhoa.Text = "Chuyển khoa";
            this.raChuyenKhoa.UseVisualStyleBackColor = true;
            this.raChuyenKhoa.CheckedChanged += new System.EventHandler(this.raTaCa_CheckedChanged);
            this.raChuyenKhoa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmShowDSBenhNhan_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDenNgay);
            this.groupBox1.Controls.Add(this.raChuyenKhoa);
            this.groupBox1.Controls.Add(this.raDangDT);
            this.groupBox1.Controls.Add(this.raDaRV);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtTuNgay);
            this.groupBox1.Location = new System.Drawing.Point(3, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(485, 54);
            this.groupBox1.TabIndex = 140;
            this.groupBox1.TabStop = false;
            // 
            // cmbNhom
            // 
            this.cmbNhom.AddItemSeparator = ';';
            this.cmbNhom.AllowColMove = false;
            this.cmbNhom.AllowRowSizing = C1.Win.C1List.RowSizingEnum.AllRows;
            this.cmbNhom.AutoCompletion = true;
            this.cmbNhom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cmbNhom.Caption = "";
            this.cmbNhom.CaptionHeight = 17;
            this.cmbNhom.CaptionStyle = style1;
            this.cmbNhom.CaptionVisible = false;
            this.cmbNhom.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cmbNhom.ColumnCaptionHeight = 17;
            this.cmbNhom.ColumnFooterHeight = 17;
            this.cmbNhom.ColumnHeaders = false;
            this.cmbNhom.ContentHeight = 16;
            this.cmbNhom.DataMode = C1.Win.C1List.DataModeEnum.AddItem;
            this.cmbNhom.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cmbNhom.DefColWidth = 1;
            this.cmbNhom.DisplayMember = "Danh mục";
            this.cmbNhom.EditorBackColor = System.Drawing.Color.White;
            this.cmbNhom.EditorFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbNhom.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbNhom.EditorHeight = 16;
            this.cmbNhom.EvenRowStyle = style2;
            this.cmbNhom.ExtendRightColumn = true;
            this.cmbNhom.FlatStyle = C1.Win.C1List.FlatModeEnum.Popup;
            this.cmbNhom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbNhom.FooterStyle = style3;
            this.cmbNhom.GapHeight = 2;
            this.cmbNhom.HeadingStyle = style4;
            this.cmbNhom.HighLightRowStyle = style5;
            this.cmbNhom.ItemHeight = 15;
            this.cmbNhom.Location = new System.Drawing.Point(83, 28);
            this.cmbNhom.MatchCol = C1.Win.C1List.MatchColEnum.AllCols;
            this.cmbNhom.MatchEntryTimeout = ((long)(2000));
            this.cmbNhom.MaxDropDownItems = ((short)(10));
            this.cmbNhom.MaxLength = 32767;
            this.cmbNhom.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cmbNhom.Name = "cmbNhom";
            this.cmbNhom.OddRowStyle = style6;
            this.cmbNhom.PartialRightColumn = false;
            this.cmbNhom.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.cmbNhom.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.cmbNhom.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cmbNhom.SelectedStyle = style7;
            this.cmbNhom.Size = new System.Drawing.Size(301, 20);
            this.cmbNhom.Style = style8;
            this.cmbNhom.TabIndex = 198;
            this.cmbNhom.TextChanged += new System.EventHandler(this.cmbNhom_TextChanged);
            this.cmbNhom.PropBag = resources.GetString("cmbNhom.PropBag");
            // 
            // label14
            // 
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(3, 29);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(81, 18);
            this.label14.TabIndex = 197;
            this.label14.Text = "Tên nhóm CĐ:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmShowDSBenhNhan
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(488, 633);
            this.Controls.Add(this.cmdTim);
            this.Controls.Add(this.cmbNhom);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.fg);
            this.Controls.Add(this.txtSHSBA);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtHoTen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.cmdCancel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmShowDSBenhNhan";
            this.Text = "Danh sách bệnh nhân";
            this.Load += new System.EventHandler(this.frmShowDSBenhNhan_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmShowDSBenhNhan_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.fg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTuNgay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDenNgay)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbNhom)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmShowDSBenhNhan_Load(object sender, System.EventArgs e)
		{
			System.Data.SqlClient.SqlDataReader dr;
			System.Data.SqlClient.SqlCommand SQLCmd= new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            SQLCmd.CommandText = "SELECT * FROM Khoa_Nhom where MaKhoa='" + MaKhoa + "' ORDER BY TenNhom";
            dr = SQLCmd.ExecuteReader();
            cmbNhom.Tag = "0";
            cmbNhom.ClearItems();
            while (dr.Read())
            {
                cmbNhom.AddItem(string.Format("{0};{1}", dr["MANhom"], dr["TenNhom"]));
            }
            cmbNhom.SelectedIndex = 0;
            cmbNhom.Tag = "1";
            dr.Close();
            if (MaNhom != "")
                cmbNhom.SelectedIndex = cmbNhom.FindStringExact(MaNhom, 0, 0);
            if(covid == 0)
            {
                if (tblname == "")
                {
                    SQLCmd.CommandText = string.Format("SELECT a.MaBenhNhan,b.MaVaoVien,HoTen,Year(getDate())-NamSinh As Tuoi,GioiTinh,CASE GioiTinh WHEN 1 THEN 'Nam' ELSE N'Nữ' END As TenGT,DoiTuong,TenDT,SoHSBA,NgayVaoVien,dmgiuongbenh.mabs,B.DaTinhPhi,B.DaRaVien,b.NgayKham,DMBUONGBENH.TenBuong,DMGIUONGBENH.TenGiuong,c.MAICD_BC,C.MAICD_BP_1,b.Is_Covid,dmgiuongbenh.MaGiuongYT,c.ChanDoan"
                                            + " FROM (((BENHNHAN a INNER JOIN BENHNHAN_CHITIET b ON a.MaBenhNhan=b.MaBenhNhan and b.is_covid != 1)"
                                            + " INNER JOIN ViewKHOAHIENTAI c ON b.MaVaoVien=c.MaVaoVien)"
                                            + " INNER JOIN ViewDOITUONGHIENTAI d ON b.MaVaoVien=d.MaVaoVien)"
                                            + " INNER JOIN DMDOITUONGBN e ON d.DoiTuong=e.MaDT");
                    if (MaKhoa != "")
                    { SQLCmd.CommandText += " AND MaKhoa ='" + MaKhoa + "' AND TrangThai=" + TrangThaiBN + " AND c.vDaraVien=" + vDaRaVien.ToString(); }
                    cmdTim.Enabled = true;
                }
                else
                {
                    SQLCmd.CommandText = string.Format("SELECT MaBenhNhan As MaBenhNhan,TenBenhNhan As HoTen,GioiTinh,year(getdate()) - NamSinh as Tuoi,0 as KyQuy,'' as tenDT,0 As MucGia FROM KHAMBENH103.DBO.tblBENHNHAN_NHAPVIEN WHERE DaCapNhat=0 AND MaKhoaDieuTri='" + MaKhoa + "'");
                    cmdTim.Enabled = false;
                    this.Text = "Danh sách bệnh nhân vào khoa ";
                }
                SQLCmd.CommandText += String.Format(" left join dmgiuongbenh on dmgiuongbenh.makhoa ='{0}' and b.giuong = dmgiuongbenh.id_giuong and"
                    + " b.buong = dmgiuongbenh.id_buong left join DMBUONGBENH on DMBUONGBENH.ID_Buong = b.Buong and DMBUONGBENH.MaKhoa = '" + MaKhoa + "'"
                    + " where b.MaNhom ={1} order by HoTen", MaKhoa, GlobalModuls.Global.GetCode(cmbNhom));
                dr = SQLCmd.ExecuteReader();
                fg.ClipSeparators = "|;";
                fg.Cols["MaBenhNhan"].Visible = fg.Cols["GioiTinh"].Visible = fg.Cols["DoiTuong"].Visible = false;
                fg.Redraw = false;
                fg.Rows.Count = 1;

            }
            else
            {
                if (tblname == "")
                {
                    SQLCmd.CommandText = string.Format("SELECT a.MaBenhNhan,b.MaVaoVien,HoTen,Year(getDate())-NamSinh As Tuoi,GioiTinh,CASE GioiTinh WHEN 1 THEN 'Nam' ELSE N'Nữ' END As TenGT,DoiTuong,TenDT,SoHSBA,NgayVaoVien,dmgiuongbenh.mabs,B.DaTinhPhi,B.DaRaVien,b.NgayKham,DMBUONGBENH.TenBuong,DMGIUONGBENH.TenGiuong,c.MAICD_BC,C.MAICD_BP_1,b.Is_Covid,dmgiuongbenh.MaGiuongYT,c.ChanDoan"
                                            + " FROM (((BENHNHAN a INNER JOIN BENHNHAN_CHITIET b ON a.MaBenhNhan=b.MaBenhNhan and b.is_covid = 1)"
                                            + " INNER JOIN ViewKHOAHIENTAI c ON b.MaVaoVien=c.MaVaoVien)"
                                            + " INNER JOIN ViewDOITUONGHIENTAI d ON b.MaVaoVien=d.MaVaoVien)"
                                            + " INNER JOIN DMDOITUONGBN e ON d.DoiTuong=e.MaDT");
                    if (MaKhoa != "")
                    { SQLCmd.CommandText += " AND MaKhoa ='" + MaKhoa + "' AND TrangThai=" + TrangThaiBN + " AND c.vDaraVien=" + vDaRaVien.ToString(); }
                    cmdTim.Enabled = true;
                }
                else
                {
                    SQLCmd.CommandText = string.Format("SELECT MaBenhNhan As MaBenhNhan,TenBenhNhan As HoTen,GioiTinh,year(getdate()) - NamSinh as Tuoi,0 as KyQuy,'' as tenDT,0 As MucGia FROM KHAMBENH103.DBO.tblBENHNHAN_NHAPVIEN WHERE DaCapNhat=0 AND MaKhoaDieuTri='" + MaKhoa + "'");
                    cmdTim.Enabled = false;
                    this.Text = "Danh sách bệnh nhân vào khoa ";
                }
                SQLCmd.CommandText += String.Format(" left join dmgiuongbenh on dmgiuongbenh.makhoa ='{0}' and b.giuong = dmgiuongbenh.id_giuong and"
                    + " b.buong = dmgiuongbenh.id_buong left join DMBUONGBENH on DMBUONGBENH.ID_Buong = b.Buong and DMBUONGBENH.MaKhoa = '" + MaKhoa + "'"
                    + " where b.MaNhom ={1} order by HoTen", MaKhoa, GlobalModuls.Global.GetCode(cmbNhom));
                dr = SQLCmd.ExecuteReader();
                fg.ClipSeparators = "|;";
                fg.Cols["MaBenhNhan"].Visible = fg.Cols["GioiTinh"].Visible = fg.Cols["DoiTuong"].Visible = false;
                fg.Redraw = false;
                fg.Rows.Count = 1;
            }
			
			while (dr.Read())
			{
                fg.AddItem(string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10:dd/MM/yyyy}|{11}|{12}|{13}|{14:dd/MM/yyyy HH:mm:ss}|{15}|{16}|{17}|{18}|{19}|{20}|{21}", 
                    fg.Rows.Count, dr["MaBenhNhan"], dr["MaVaoVien"], 
                    dr["HoTen"], dr["Tuoi"], dr["GioiTinh"], 
                    dr["TenGT"], dr["DoiTuong"], 
                    dr["TenDT"],dr["SoHSBA"],
                    dr["NgayVaoVien"],dr["MaBS"],dr["DaTinhPhi"], dr["DaRaVien"], dr["NgayKham"],dr["TenBuong"],dr["TenGiuong"], dr["MAICD_BC"], dr["MAICD_BP_1"], dr["Is_Covid"], dr["MaGiuongYT"], dr["ChanDoan"]));
			}
			dr.Close();
			SQLCmd.Dispose();
            fg.Redraw = true;
            fg.AutoSizeCols();
            txtTuNgay.Value = txtDenNgay.Value = GlobalModuls.Global.NgayLV;
            raDangDT_CheckedChanged(sender, e);
		}

		private void cmdTim_Click(object sender, System.EventArgs e)
		{
            if (cmbNhom.SelectedIndex == -1)
            {
                MessageBox.Show("Chọn nhóm lên chi phí.", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbNhom.Focus();
                return;
            }
			if (tblname !="") {return;}
			string DKTim="",Str = "";

            if(covid == 0)
            {
                //Str = "set dateformat dmy Select *,Year(Getdate()) - NamSinh as tuoi,'' as TenGT,dmgiuongbenh.mabs,BenhNhan_chiTiet.DaTinhPhi,BenhNhan_chiTiet.DaRaVien,BenhNhan_chiTiet.NgayKham,DMBUONGBENH.TenBuong,DMGIUONGBENH.TenGiuong,ViewKhoaHienTai.MAICD_BC,ViewKhoaHienTai.MAICD_BP_1 from"
                Str = "set dateformat dmy Select BenhNhan.MaBenhNhan,BenhNhan_chiTiet.Mavaovien,BENHNHAN.HoTen,Year(Getdate()) - NamSinh as tuoi,'' as TenGT,BENHNHAN.GioiTinh,ViewDoiTuongHienTai.DoiTuong,case when ViewDoiTuongHienTai.DoiTuong = 1 then N'Bảo hiểm y tế' else N'Viện phí' end as TenDT,SoHSBA,NGAYVAOVIEN, '' as mabs,BenhNhan_chiTiet.DaTinhPhi,BenhNhan_chiTiet.DaRaVien,BenhNhan_chiTiet.NgayKham,DMBUONGBENH.TenBuong,DMGIUONGBENH.TenGiuong,ViewKhoaHienTai.MAICD_BC,ViewKhoaHienTai.MAICD_BP_1,BenhNhan_chiTiet.Is_Covid,dmgiuongbenh.MaGiuongYT,ViewKhoaHienTai.ChanDoan  from"
                    + " (((BenhNhan inner join BenhNhan_chiTiet on BenhNhan.MaBenhNhan = BenhNhan_ChiTiet.MaBenhNhan and BenhNhan_chiTiet.is_covid != 1)"
                    + " Inner Join ViewDoiTuongHienTai on ViewDoiTuongHienTai.MaVaoVien = BenhNhan_ChiTiet.MaVaoVien)"
                    //+ " Inner Join DmDoiTuongBN on DoiTuong = MaDT)"
                    + " Inner Join ViewKhoaHienTai on BenhNhan_ChiTiet.MaVaoVien = ViewKhoaHienTai.MaVaoVien)";
                Str += String.Format(" left join dmgiuongbenh on dmgiuongbenh.makhoa ='{0}' and benhnhan_chitiet.giuong = dmgiuongbenh.id_giuong and"
                    + " benhnhan_chitiet.buong = dmgiuongbenh.id_buong  left join DMBUONGBENH on DMBUONGBENH.ID_Buong = BenhNhan_chiTiet.Buong and DMBUONGBENH.MaKhoa = '{0}'", MaKhoa);
                if (MaKhoa != "")
                {
                    DKTim = " WHERE ViewKhoaHienTai.MaKhoa = '" + MaKhoa + "' ";
                }
                if (txtSHSBA.Text != "")
                {
                    DKTim += (DKTim == "") ? (" WHERE BENHNHAN.MaBenhNhan Like '" + txtSHSBA.Text + "%'") : (" AND BENHNHAN.MaBenhNhan Like '" + txtSHSBA.Text + "%' ");
                }
                if (txtHoTen.Text != "")
                {
                    DKTim += (DKTim == "") ? (" WHERE Hoten Like N'%" + txtHoTen.Text + "%'") : (" AND Hoten Like N'%" + txtHoTen.Text + "%' ");
                }
                if (raDangDT.Checked)
                {
                    DKTim += (DKTim == "") ? (" WHERE DaraVien = 0 ") : (" AND DaraVien = 0 ");

                }
                if (raDaRV.Checked)
                {
                    DKTim += (DKTim == "") ? String.Format((" WHERE DaraVien = 1 And DateDiff(dd,NgayRaVien,'{0:dd/MM/yyyy 00:00:00}') <= 0 and DateDiff(dd,NgayRaVien,'{1:dd/MM/yyyy 00:00:00}') >= 0 "), txtTuNgay.Value, txtDenNgay.Value) :
                                        String.Format((" And DaraVien = 1 And  NgayRaVien >= '{0:dd/MM/yyyy 00:00:00}'  and  NgayRaVien <= '{1:dd/MM/yyyy 23:59:59}' "), txtTuNgay.Value, txtDenNgay.Value);
                    //DKTim += " AND BenhNhan_chiTiet.D != 1";
                }


                DKTim += (DKTim == "") ? " where BenhNhan_ChiTiet.MaNhom=" + GlobalModuls.Global.GetCode(cmbNhom) : " and BenhNhan_ChiTiet.MaNhom=" + GlobalModuls.Global.GetCode(cmbNhom);
                Str += DKTim;
                if (raChuyenKhoa.Checked)
                {
                    Str = string.Format(" set dateformat dmy SELECT A.MABENHNHAN,B.MAVAOVIEN,A.HOTEN,YEAR(GETDATE()) - A.NAMSINH AS TUOI,A.GIOITINH,BENHNHAN_KHOA.NGAYCHUYEN AS NGAYVAOVIEN,"
                        + " B.DIACHI,V.DOITUONG,V.SoThe,TENDT,B.DaRaVien,B.SoHSBA,'' AS MABS,CHUYENDI.NGAYCHUYEN AS NGAYVAOVIEN,B.datinhphi,B.DaRaVien,B.NgayKham,DMBUONGBENH.TenBuong,DMGIUONGBENH.TenGiuong,BENHNHAN_KHOA.MAICD_BC,BENHNHAN_KHOA.MAICD_BP_1,B.Is_Covid,dmgiuongbenh.MaGiuongYT, B.ChanDoan_KhoaDT as ChanDoan FROM"
                        + " (BENHNHAN A INNER JOIN BENHNHAN_CHITIET B ON A.MABENHNHAN = B.MABENHNHAN and b.Is_covid != 1)"
                        + " INNER JOIN BENHNHAN_KHOA CHUYENDI ON CHUYENDI.MAKHOA = '{0}' AND CHUYENDI.MAVAOVIEN = B.MAVAOVIEN"
                        + " INNER JOIN BENHNHAN_KHOA CHUYENDEN ON CHUYENDEN.MAVAOVIEN = B.MAVAOVIEN AND CHUYENDEN.LANCHUYENKHOA = CHUYENDI.LANCHUYENKHOA +1"
                        + " INNER JOIN BENHNHAN_KHOA ON BENHNHAN_KHOA.MAVAOVIEN = B.MAVAOVIEN AND BENHNHAN_KHOA.LANCHUYENKHOA = 0"
                        + " INNER JOIN VIEWDOITUONGHIENTAI V ON V.MAVAOVIEN = B.MAVAOVIEN"
                        + " LEFT JOIN DMBUONGBENH ON DMBUONGBENH.ID_BUONG = CHUYENDI.IDBuong_Khoa AND DMBUONGBENH.MAKHOA = '{0}'"
                        + " LEFT JOIN DMGIUONGBENH ON DMGIUONGBENH.ID_GIUONG = CHUYENDI.IDGiuong_Khoa AND DMGIUONGBENH.ID_BUONG = CHUYENDI.IDBuong_Khoa AND DMGIUONGBENH.MAKHOA ='{0}'"
                        + " LEFT JOIN NAMDINH_SYSDB.dbo.DMNOIDKKCBBD_BHYT AA ON V.MaNoiCap=AA.MANOICAP"
                        + " LEFT JOIN DMDOITUONGBN ON DMDOITUONGBN.MADT = V.DOITUONG"
                        + " WHERE  CHUYENDEN.NGAYCHUYEN >='{1:dd/MM/yyyy 00:00:01}' AND CHUYENDEN.NGAYCHUYEN <= '{2:dd/MM/yyyy 23:59:59}' ",
                        MaKhoa, txtTuNgay.Value, txtDenNgay.Value);
                }
                Str += " order by HoTen";
            }
            else
            {
                //Str = "set dateformat dmy Select *,Year(Getdate()) - NamSinh as tuoi,'' as TenGT,dmgiuongbenh.mabs,BenhNhan_chiTiet.DaTinhPhi,BenhNhan_chiTiet.DaRaVien,BenhNhan_chiTiet.NgayKham,DMBUONGBENH.TenBuong,DMGIUONGBENH.TenGiuong,ViewKhoaHienTai.MAICD_BC,ViewKhoaHienTai.MAICD_BP_1 from"
                Str = "set dateformat dmy Select BenhNhan.MaBenhNhan,BenhNhan_chiTiet.Mavaovien,BENHNHAN.HoTen,Year(Getdate()) - NamSinh as tuoi,'' as TenGT,BENHNHAN.GioiTinh,ViewDoiTuongHienTai.DoiTuong,case when ViewDoiTuongHienTai.DoiTuong = 1 then N'Bảo hiểm y tế' else N'Viện phí' end as TenDT,SoHSBA,NGAYVAOVIEN, '' as mabs,BenhNhan_chiTiet.DaTinhPhi,BenhNhan_chiTiet.DaRaVien,BenhNhan_chiTiet.NgayKham,DMBUONGBENH.TenBuong,DMGIUONGBENH.TenGiuong,ViewKhoaHienTai.MAICD_BC,ViewKhoaHienTai.MAICD_BP_1,BenhNhan_chiTiet.Is_Covid,dmgiuongbenh.MaGiuongYT,ViewKhoaHienTai.ChanDoan from"
                    + " (((BenhNhan inner join BenhNhan_chiTiet on BenhNhan.MaBenhNhan = BenhNhan_ChiTiet.MaBenhNhan and BenhNhan_ChiTiet.is_covid = 1 )"
                    + " Inner Join ViewDoiTuongHienTai on ViewDoiTuongHienTai.MaVaoVien = BenhNhan_ChiTiet.MaVaoVien)"
                    //+ " Inner Join DmDoiTuongBN on DoiTuong = MaDT)"
                    + " Inner Join ViewKhoaHienTai on BenhNhan_ChiTiet.MaVaoVien = ViewKhoaHienTai.MaVaoVien)";
                Str += String.Format(" left join dmgiuongbenh on dmgiuongbenh.makhoa ='{0}' and benhnhan_chitiet.giuong = dmgiuongbenh.id_giuong and"
                    + " benhnhan_chitiet.buong = dmgiuongbenh.id_buong  left join DMBUONGBENH on DMBUONGBENH.ID_Buong = BenhNhan_chiTiet.Buong and DMBUONGBENH.MaKhoa = '{0}'", MaKhoa);
                if (MaKhoa != "")
                {
                    DKTim = " WHERE ViewKhoaHienTai.MaKhoa = '" + MaKhoa + "' ";
                }
                if (txtSHSBA.Text != "")
                {
                    DKTim += (DKTim == "") ? (" WHERE BENHNHAN.MaBenhNhan Like '" + txtSHSBA.Text + "%'") : (" AND BENHNHAN.MaBenhNhan Like '" + txtSHSBA.Text + "%' ");
                }
                if (txtHoTen.Text != "")
                {
                    DKTim += (DKTim == "") ? (" WHERE Hoten Like N'%" + txtHoTen.Text + "%'") : (" AND Hoten Like N'%" + txtHoTen.Text + "%' ");
                }
                if (raDangDT.Checked)
                {
                    DKTim += (DKTim == "") ? (" WHERE DaraVien = 0 ") : (" AND DaraVien = 0 ");

                }
                if (raDaRV.Checked)
                {
                    DKTim += (DKTim == "") ? String.Format((" WHERE DaraVien = 1 And DateDiff(dd,NgayRaVien,'{0:dd/MM/yyyy 00:00:00}') <= 0 and DateDiff(dd,NgayRaVien,'{1:dd/MM/yyyy 00:00:00}') >= 0 "), txtTuNgay.Value, txtDenNgay.Value) :
                                        String.Format((" And DaraVien = 1 And  NgayRaVien >= '{0:dd/MM/yyyy 00:00:00}'  and  NgayRaVien <= '{1:dd/MM/yyyy 23:59:59}' "), txtTuNgay.Value, txtDenNgay.Value);
                    //DKTim += " AND BenhNhan_chiTiet.D != 1";
                }


                DKTim += (DKTim == "") ? " where BenhNhan_ChiTiet.MaNhom=" + GlobalModuls.Global.GetCode(cmbNhom) : " and BenhNhan_ChiTiet.MaNhom=" + GlobalModuls.Global.GetCode(cmbNhom);
                Str += DKTim;
                if (raChuyenKhoa.Checked)
                {
                    Str = string.Format(" set dateformat dmy SELECT A.MABENHNHAN,B.MAVAOVIEN,A.HOTEN,YEAR(GETDATE()) - A.NAMSINH AS TUOI,A.GIOITINH,BENHNHAN_KHOA.NGAYCHUYEN AS NGAYVAOVIEN,"
                        + " B.DIACHI,V.DOITUONG,V.SoThe,TENDT,B.DaRaVien,B.SoHSBA,'' AS MABS,CHUYENDI.NGAYCHUYEN AS NGAYVAOVIEN,B.datinhphi,B.DaRaVien,B.NgayKham,DMBUONGBENH.TenBuong,DMGIUONGBENH.TenGiuong,BENHNHAN_KHOA.MAICD_BC,BENHNHAN_KHOA.MAICD_BP_1,B.Is_Covid,dmgiuongbenh.MaGiuongYT,B.ChanDoan_KhoaDT as ChanDoan FROM"
                        + " (BENHNHAN A INNER JOIN BENHNHAN_CHITIET B ON A.MABENHNHAN = B.MABENHNHAN and b.is_covid = 1)"
                        + " INNER JOIN BENHNHAN_KHOA CHUYENDI ON CHUYENDI.MAKHOA = '{0}' AND CHUYENDI.MAVAOVIEN = B.MAVAOVIEN"
                        + " INNER JOIN BENHNHAN_KHOA CHUYENDEN ON CHUYENDEN.MAVAOVIEN = B.MAVAOVIEN AND CHUYENDEN.LANCHUYENKHOA = CHUYENDI.LANCHUYENKHOA +1"
                        + " INNER JOIN BENHNHAN_KHOA ON BENHNHAN_KHOA.MAVAOVIEN = B.MAVAOVIEN AND BENHNHAN_KHOA.LANCHUYENKHOA = 0"
                        + " INNER JOIN VIEWDOITUONGHIENTAI V ON V.MAVAOVIEN = B.MAVAOVIEN"
                        + " LEFT JOIN DMBUONGBENH ON DMBUONGBENH.ID_BUONG = CHUYENDI.IDBuong_Khoa AND DMBUONGBENH.MAKHOA = '{0}'"
                        + " LEFT JOIN DMGIUONGBENH ON DMGIUONGBENH.ID_GIUONG = CHUYENDI.IDGIUONG_KHOA AND DMGIUONGBENH.ID_BUONG = CHUYENDI.IDBUONG_KHOA AND DMGIUONGBENH.MAKHOA ='{0}'"
                        + " LEFT JOIN NAMDINH_SYSDB.dbo.DMNOIDKKCBBD_BHYT AA ON V.MaNoiCap=AA.MANOICAP"
                        + " LEFT JOIN DMDOITUONGBN ON DMDOITUONGBN.MADT = V.DOITUONG"
                        + " WHERE  CHUYENDEN.NGAYCHUYEN >='{1:dd/MM/yyyy 00:00:01}' AND CHUYENDEN.NGAYCHUYEN <= '{2:dd/MM/yyyy 23:59:59}' ",
                        MaKhoa, txtTuNgay.Value, txtDenNgay.Value);
                }
                Str += " order by HoTen";
            }
			System.Data.SqlClient.SqlDataReader dr;
			System.Data.SqlClient.SqlCommand SQLCmd= new System.Data.SqlClient.SqlCommand();
			SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            SQLCmd.CommandText = Str;
			dr=SQLCmd.ExecuteReader();
			fg.ClipSeparators ="|;";
			fg.Rows.Count =1;
			while (dr.Read())
			{
                fg.AddItem(string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10:dd/MM/yyyy}|{11}|{12}|{13}|{14:dd/MM/yyyy HH:mm:ss}|{15}|{16}|{17}|{18}|{19}|{20}|{21}", 
                    fg.Rows.Count, 
                    dr["MaBenhNhan"], 
                    dr["MaVaoVien"], 
                    dr["HoTen"], 
                    dr["Tuoi"],
                    "",
                    (dr["GioiTinh"].ToString() == "1") ? ("Nam") : ("Nữ"),
                    dr["DoiTuong"], 
                    dr["TenDT"], 
                    dr["SoHSBA"], 
                    DateTime.Parse(dr["NgayVaoVien"].ToString()),
                    dr["MaBS"],dr["DaTinhPhi"], dr["DaRaVien"], dr["NgayKham"], dr["TenBuong"], dr["TenGiuong"], dr["MAICD_BC"], dr["MAICD_BP_1"], dr["Is_Covid"], dr["MaGiuongYT"],dr["ChanDoan"]));
			}
			dr.Close();
			SQLCmd.Dispose();
		}

		private void cmdOK_Click(object sender, System.EventArgs e)
		{
			if (fg.Row<1) {return;}
			SoHSBAReturn = fg.GetDataDisplay(fg.Row,"SoHSBA");
			HoTenReturn  = fg.GetDataDisplay(fg.Row,"HoTen");
			GioiReturn = fg.GetDataDisplay(fg.Row,"TenGT");
			TuoiReturn = fg.GetDataDisplay(fg.Row,"Tuoi");			
			MaDoiTuongReturn = fg.GetDataDisplay(fg.Row,"DoiTuong");
            TenDoiTuongReturn = fg.GetDataDisplay(fg.Row, "TenDT");
            NgayVaoVienReturn = fg.GetDataDisplay(fg.Row, "NgayVaoVien");
            MaVaoVienReturn = fg.GetDataDisplay(fg.Row, "MaVaoVien");
            MabacSY = fg.GetDataDisplay(fg.Row, "MaBS");
            MaNhom = GlobalModuls.Global.GetCode(cmbNhom);
            TenNhom = cmbNhom.Text.Trim();
            DaTinhPhiReturn = fg.GetDataDisplay(fg.Row, "DaTinhPhi");
            DaRaVienReturn = byte.Parse(fg.GetDataDisplay(fg.Row, "DaRaVien"));
            NgayKhamReturn = DateTime.Parse(fg.GetDataDisplay(fg.Row, "NgayKham"));
            TenBuongReturn = fg.GetDataDisplay(fg.Row, "TenBuong");
            TenGiuongReturn = fg.GetDataDisplay(fg.Row, "TenGiuong");
            MaICDBCReturn = fg.GetDataDisplay(fg.Row, "MAICD_BC");
            MAICDBP_1Return = fg.GetDataDisplay(fg.Row, "MAICD_BP_1");
            is_covidReturn = fg.GetDataDisplay(fg.Row, "Is_Covid");
            MaGiuongYTReturn = fg.GetDataDisplay(fg.Row, "MaGiuongYT");
            ChanDoanReturn = fg.GetDataDisplay(fg.Row, "ChanDoan");
            //frmChuyenDien frm = new frmChuyenDien();
            //int s = int.Parse(DateTime.Parse(fg.GetDataDisplay(fg.Row, "NgayVaoVien").ToString()).Year.ToString()) - int.Parse(fg.GetDataDisplay(fg.Row, "Tuoi"));
            //frm.CheckTheBHYT("", fg.GetDataDisplay(fg.Row, "HoTen"), s.ToString());
            this.DialogResult = DialogResult.OK;
			this.Dispose();

		}

		private void cmdCancel_Click(object sender, System.EventArgs e)
		{
			SoHSBAReturn = "";
			this.Dispose();
		}
             
        private void raDangDT_CheckedChanged(object sender, EventArgs e)
        {
            if (raDangDT.Checked)
            {
                txtTuNgay.Enabled = txtDenNgay.Enabled = false;
            }
            else
            {
                txtTuNgay.Enabled = txtDenNgay.Enabled = true;
            }
        }
         
        private void raDaRV_CheckedChanged(object sender, EventArgs e)
        {
            raDangDT_CheckedChanged(sender, e);
        }

        private void raTaCa_CheckedChanged(object sender, EventArgs e)
        {
            raDangDT_CheckedChanged(sender, e);
        }

        private void frmShowDSBenhNhan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                if (fg.Row < 1) { return; }
                SoHSBAReturn = fg.GetDataDisplay(fg.Row, "SoHSBA");
                HoTenReturn = fg.GetDataDisplay(fg.Row, "HoTen");
                GioiReturn = fg.GetDataDisplay(fg.Row, "TenGT");
                TuoiReturn = fg.GetDataDisplay(fg.Row, "Tuoi");
                MaDoiTuongReturn = fg.GetDataDisplay(fg.Row, "DoiTuong");
                TenDoiTuongReturn = fg.GetDataDisplay(fg.Row, "TenDT");
                NgayVaoVienReturn = fg.GetDataDisplay(fg.Row, "NgayVaoVien");
                MaVaoVienReturn = fg.GetDataDisplay(fg.Row, "MaVaoVien");
                DaTinhPhiReturn = fg.GetDataDisplay(fg.Row, "DaTinhPhi");
                DaRaVienReturn = byte.Parse(fg.GetDataDisplay(fg.Row, "DaRaVien"));
                NgayKhamReturn = DateTime.Parse(fg.GetDataDisplay(fg.Row, "NgayKham"));
                TenBuongReturn = fg.GetDataDisplay(fg.Row, "TenBuong");
                TenGiuongReturn = fg.GetDataDisplay(fg.Row, "TenGiuong");
                MaICDBCReturn = fg.GetDataDisplay(fg.Row, "MAICD_BC");
                MAICDBP_1Return = fg.GetDataDisplay(fg.Row, "MAICD_BP_1");
                is_covidReturn = fg.GetDataDisplay(fg.Row, "Is_Covid");
                MaGiuongYTReturn = fg.GetDataDisplay(fg.Row, "MaGiuongYT");
                ChanDoanReturn = fg.GetDataDisplay(fg.Row, "ChanDoan");
                this.DialogResult = DialogResult.OK;
                this.Dispose();
            }
            if (e.KeyCode == Keys.F4)
            {
                this.Dispose();
            }
        }

        private void cmbNhom_TextChanged(object sender, EventArgs e)
        {
            if (cmbNhom.Tag.ToString() == "0") return;
            cmbNhom.Tag = 0;
            cmdTim_Click(sender, e);
            cmbNhom.Tag = 1;
            fg.AutoSizeCols();
        }
	}
}
