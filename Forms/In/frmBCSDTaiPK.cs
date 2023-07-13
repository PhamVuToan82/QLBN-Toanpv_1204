using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using NamDinh_QLBN.Forms.In;
using GlobalModuls;
using System.Data;
using System.Data.SqlClient;

namespace NamDinh_QLBN.Forms.In
{
	/// <summary>
	/// PreviewForm - child MDI form that loads up the ActiveReports Viewer to view a report
	/// and provides options to export, save and print the generated report
	/// </summary>
	public class frmBCSDTaiPK : System.Windows.Forms.Form
	{
        public int TinhPhi;
        public int DaTT;
        public string KhoID;
        public string DonVi;
        public string DoiTuong = "";
        public DateTime TuNgay;
        public DateTime DenNgay;
        public string MaVaoVien;
        public string ThuocID;
        private System.Data.DataSet dsBaoCao,dsPK, dsKho,ds;
        System.Data.DataRow dr, dr1,dr2;
        private DataDynamics.ActiveReports.Viewer.Viewer arvMain;
        private System.Windows.Forms.PrintDialog dlgPrint;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem kếtXuấtDữLiệuToolStripMenuItem;
        private ToolStripMenuItem lưuBáoCáoToolStripMenuItem;
        private ToolStripMenuItem thiếtLậpTrangInToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem đóngBáoCáoToolStripMenuItem;
        private Panel panel1;
        private Label label7;
        public ComboBox cmbTinhPhi;
        private Label label6;
        public ComboBox cmbDaTT;
        public ComboBox cmbKhoaNhan;
        private Label label5;
        private Label khoxuat;
        public ComboBox cmbKhoXuat;
        private Label label3;
        public Button btnTim;
        public C1.Win.C1Input.C1DateEdit dpDenNgay;
        public C1.Win.C1Input.C1DateEdit dpTuNgay;

        //public DateTime dpDenNgay;
        //public DateTime  dpTuNgay;

        public RadioButton rdTongHop;
        public RadioButton rdChiTiet;
        private Label label2;
        private Label label1;
        private Label label4;
        private Label label8;
        internal C1.Win.C1List.C1Combo cmbThuoc;
        internal C1.Win.C1List.C1Combo cmbBenhNhan;
        private IContainer components=null;

        public frmBCSDTaiPK()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            
        }

        private void loadDM()
        {
            dpTuNgay.Value = dpDenNgay.Value =  Global.GetNgayLV();
            dsKho = getDanhMuc("NamDinh_Duoc.dbo.GetDanhMucKho", "");
            dr = dsKho.Tables[0].NewRow();
            dr["KhoID"] = "";
            dr["TenKho"] = "Tất cả";
            dsKho.Tables[0].Rows.InsertAt(dr, 0);
            cmbKhoXuat.DataSource = dsKho.Tables[0];
            cmbKhoXuat.DisplayMember = "TenKho";
            cmbKhoXuat.ValueMember = "KhoID";
            cmbKhoXuat.SelectedIndex = 0;
            dsPK = getDanhMuc("NamDinh_Duoc.dbo.GetDanhMucPhongKhoa", "PhongKhoaID IN " + Global.glbKhoa_CapNhat);
            cmbKhoaNhan.DataSource = dsPK.Tables[0];
            cmbKhoaNhan.DisplayMember = "TenPhongKhoa";
            cmbKhoaNhan.ValueMember = "PhongKhoaID";
            cmbKhoaNhan.SelectedIndex = 0;
            ds = GetDS("NamDinh_Duoc.dbo.GetDSBenhNhanNamVien");
            dr1 = ds.Tables[0].NewRow();
            dr1["MaVaoVien"] = "";
            dr1["HoTen"] = "Tất cả";
            ds.Tables[0].Rows.InsertAt(dr1, 0);
            cmbBenhNhan.DataSource = ds.Tables[0];
            cmbBenhNhan.DisplayMember = "HoTen";
            cmbBenhNhan.ValueMember = "MaVaoVien";
            cmbBenhNhan.Splits[0].DisplayColumns["SoHSBA"].Visible = false;
            cmbBenhNhan.Splits[0].DisplayColumns["MaVaoVien"].Visible = false;
            cmbBenhNhan.Splits[0].DisplayColumns["MaDTBHYT"].Visible = false;
            cmbBenhNhan.Splits[0].DisplayColumns["SoTheBHYT"].Visible = false;
            cmbBenhNhan.SelectedIndex = 0;
            ds = GetDS("NamDinh_Duoc.dbo.GetDSThuocDungChoBNNamVien");
            dr2 = ds.Tables[0].NewRow();
            dr2["ThuocID"] = "";
            dr2["TenThuoc"] = "Tất cả";
            ds.Tables[0].Rows.InsertAt(dr2, 0);
            cmbThuoc.DataSource = ds.Tables[0];
            cmbThuoc.DisplayMember = "TenThuoc";
            cmbThuoc.ValueMember = "ThuocID";
            cmbThuoc.Splits[0].DisplayColumns["DonViTinh"].Visible = false;
            cmbThuoc.Splits[0].DisplayColumns["ThuocID"].Visible = false;
            cmbThuoc.SelectedIndex = 0;
            dpTuNgay.ValueChanged += DpTuNgay_ValueChanged;
            dpDenNgay.ValueChanged += DpDenNgay_ValueChanged;
            cmbDaTT.SelectedIndex = 2;
            cmbTinhPhi.SelectedIndex = 2;
        }

        private void DpDenNgay_ValueChanged(object sender, EventArgs e)
        {
            DpTuNgay_ValueChanged(sender, e);
        }

        private void DpTuNgay_ValueChanged(object sender, EventArgs e)
        {
            ds = GetDS("NamDinh_Duoc.dbo.GetDSBenhNhanNamVien");
            dr1 = ds.Tables[0].NewRow();
            dr1["MaVaoVien"] = "";
            dr1["HoTen"] = "Tất cả";
            ds.Tables[0].Rows.InsertAt(dr1, 0);
            cmbBenhNhan.DataSource = ds.Tables[0];
            cmbBenhNhan.DisplayMember = "HoTen";
            cmbBenhNhan.ValueMember = "MaVaoVien";
            cmbBenhNhan.Splits[0].DisplayColumns["SoHSBA"].Visible = false;
            cmbBenhNhan.Splits[0].DisplayColumns["MaVaoVien"].Visible = false;
            cmbBenhNhan.Splits[0].DisplayColumns["MaDTBHYT"].Visible = false;
            cmbBenhNhan.Splits[0].DisplayColumns["SoTheBHYT"].Visible = false;
            cmbBenhNhan.SelectedIndex = 0;
            ds = GetDS("NamDinh_Duoc.dbo.GetDSThuocDungChoBNNamVien");
            dr2 = ds.Tables[0].NewRow();
            dr2["ThuocID"] = "";
            dr2["TenThuoc"] = "Tất cả";
            ds.Tables[0].Rows.InsertAt(dr2, 0);
            cmbThuoc.DataSource = ds.Tables[0];
            cmbThuoc.DisplayMember = "TenThuoc";
            cmbThuoc.ValueMember = "ThuocID";
            cmbThuoc.Splits[0].DisplayColumns["DonViTinh"].Visible = false;
            cmbThuoc.Splits[0].DisplayColumns["ThuocID"].Visible = false;
            cmbThuoc.SelectedIndex = 0;
        }

        public frmBCSDTaiPK(DataDynamics.ActiveReports.Document.Document doc, Form parentForm)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			
			this.MdiParent = parentForm;

			arvMain.Document = doc;
			this.Text = doc.Name;
		}
        public frmBCSDTaiPK(DataDynamics.ActiveReports.Document.Document doc)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //this.MdiParent = parentForm;

            arvMain.Document = doc;
            //this.Text = doc.Name;
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
            C1.Win.C1List.Style style1 = new C1.Win.C1List.Style();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBCSDTaiPK));
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
            this.arvMain = new DataDynamics.ActiveReports.Viewer.Viewer();
            this.dlgPrint = new System.Windows.Forms.PrintDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kếtXuấtDữLiệuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lưuBáoCáoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thiếtLậpTrangInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.đóngBáoCáoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbThuoc = new C1.Win.C1List.C1Combo();
            this.cmbBenhNhan = new C1.Win.C1List.C1Combo();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbTinhPhi = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbDaTT = new System.Windows.Forms.ComboBox();
            this.cmbKhoaNhan = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.khoxuat = new System.Windows.Forms.Label();
            this.cmbKhoXuat = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnTim = new System.Windows.Forms.Button();
            this.dpDenNgay = new C1.Win.C1Input.C1DateEdit();
            this.dpTuNgay = new C1.Win.C1Input.C1DateEdit();
            this.rdTongHop = new System.Windows.Forms.RadioButton();
            this.rdChiTiet = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbThuoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBenhNhan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpDenNgay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpTuNgay)).BeginInit();
            this.SuspendLayout();
            // 
            // arvMain
            // 
            this.arvMain.BackColor = System.Drawing.SystemColors.Control;
            this.arvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.arvMain.Document = new DataDynamics.ActiveReports.Document.Document("");
            this.arvMain.Location = new System.Drawing.Point(0, 133);
            this.arvMain.Name = "arvMain";
            this.arvMain.ReportViewer.BackColor = System.Drawing.SystemColors.Control;
            this.arvMain.ReportViewer.CurrentPage = 0;
            this.arvMain.ReportViewer.MultiplePageCols = 3;
            this.arvMain.ReportViewer.MultiplePageRows = 2;
            this.arvMain.ReportViewer.ViewType = DataDynamics.ActiveReports.Viewer.ViewType.Normal;
            this.arvMain.Size = new System.Drawing.Size(782, 528);
            this.arvMain.TabIndex = 0;
            this.arvMain.TableOfContents.Text = "Contents";
            this.arvMain.TableOfContents.Width = 200;
            this.arvMain.TabTitleLength = 35;
            this.arvMain.Toolbar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.arvMain.ToolClick += new DataDynamics.ActiveReports.Toolbar.ToolClickEventHandler(this.arViewer_ToolClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(782, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kếtXuấtDữLiệuToolStripMenuItem,
            this.lưuBáoCáoToolStripMenuItem,
            this.thiếtLậpTrangInToolStripMenuItem,
            this.toolStripMenuItem1,
            this.đóngBáoCáoToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // kếtXuấtDữLiệuToolStripMenuItem
            // 
            this.kếtXuấtDữLiệuToolStripMenuItem.Name = "kếtXuấtDữLiệuToolStripMenuItem";
            this.kếtXuấtDữLiệuToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.kếtXuấtDữLiệuToolStripMenuItem.Text = "Kết xuất dữ liệu";
            this.kếtXuấtDữLiệuToolStripMenuItem.Click += new System.EventHandler(this.kếtXuấtDữLiệuToolStripMenuItem_Click);
            // 
            // lưuBáoCáoToolStripMenuItem
            // 
            this.lưuBáoCáoToolStripMenuItem.Name = "lưuBáoCáoToolStripMenuItem";
            this.lưuBáoCáoToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.lưuBáoCáoToolStripMenuItem.Text = "Lưu báo cáo";
            this.lưuBáoCáoToolStripMenuItem.Click += new System.EventHandler(this.lưuBáoCáoToolStripMenuItem_Click);
            // 
            // thiếtLậpTrangInToolStripMenuItem
            // 
            this.thiếtLậpTrangInToolStripMenuItem.Name = "thiếtLậpTrangInToolStripMenuItem";
            this.thiếtLậpTrangInToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.thiếtLậpTrangInToolStripMenuItem.Text = "Thiết lập trang in";
            this.thiếtLậpTrangInToolStripMenuItem.Click += new System.EventHandler(this.thiếtLậpTrangInToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(160, 6);
            // 
            // đóngBáoCáoToolStripMenuItem
            // 
            this.đóngBáoCáoToolStripMenuItem.Name = "đóngBáoCáoToolStripMenuItem";
            this.đóngBáoCáoToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.đóngBáoCáoToolStripMenuItem.Text = "Đóng báo cáo";
            this.đóngBáoCáoToolStripMenuItem.Click += new System.EventHandler(this.đóngBáoCáoToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.cmbThuoc);
            this.panel1.Controls.Add(this.cmbBenhNhan);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.cmbTinhPhi);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.cmbDaTT);
            this.panel1.Controls.Add(this.cmbKhoaNhan);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.khoxuat);
            this.panel1.Controls.Add(this.cmbKhoXuat);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnTim);
            this.panel1.Controls.Add(this.dpDenNgay);
            this.panel1.Controls.Add(this.dpTuNgay);
            this.panel1.Controls.Add(this.rdTongHop);
            this.panel1.Controls.Add(this.rdChiTiet);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(782, 109);
            this.panel1.TabIndex = 2;
            // 
            // cmbThuoc
            // 
            this.cmbThuoc.AddItemSeparator = ';';
            this.cmbThuoc.AllowColMove = false;
            this.cmbThuoc.AllowRowSizing = C1.Win.C1List.RowSizingEnum.AllRows;
            this.cmbThuoc.AutoCompletion = true;
            this.cmbThuoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cmbThuoc.Caption = "";
            this.cmbThuoc.CaptionHeight = 17;
            this.cmbThuoc.CaptionStyle = style1;
            this.cmbThuoc.CaptionVisible = false;
            this.cmbThuoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cmbThuoc.ColumnCaptionHeight = 17;
            this.cmbThuoc.ColumnFooterHeight = 17;
            this.cmbThuoc.ColumnHeaders = false;
            this.cmbThuoc.ContentHeight = 16;
            this.cmbThuoc.DataMode = C1.Win.C1List.DataModeEnum.AddItem;
            this.cmbThuoc.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cmbThuoc.DefColWidth = 30;
            this.cmbThuoc.EditorBackColor = System.Drawing.Color.White;
            this.cmbThuoc.EditorFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbThuoc.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbThuoc.EditorHeight = 16;
            this.cmbThuoc.EvenRowStyle = style2;
            this.cmbThuoc.ExtendRightColumn = true;
            this.cmbThuoc.FlatStyle = C1.Win.C1List.FlatModeEnum.Popup;
            this.cmbThuoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbThuoc.FooterStyle = style3;
            this.cmbThuoc.GapHeight = 2;
            this.cmbThuoc.HeadingStyle = style4;
            this.cmbThuoc.HighLightRowStyle = style5;
            this.cmbThuoc.ItemHeight = 15;
            this.cmbThuoc.Location = new System.Drawing.Point(362, 80);
            this.cmbThuoc.MatchCol = C1.Win.C1List.MatchColEnum.AllCols;
            this.cmbThuoc.MatchEntryTimeout = ((long)(2000));
            this.cmbThuoc.MaxDropDownItems = ((short)(10));
            this.cmbThuoc.MaxLength = 32767;
            this.cmbThuoc.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cmbThuoc.Name = "cmbThuoc";
            this.cmbThuoc.OddRowStyle = style6;
            this.cmbThuoc.PartialRightColumn = false;
            this.cmbThuoc.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.cmbThuoc.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.cmbThuoc.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cmbThuoc.SelectedStyle = style7;
            this.cmbThuoc.Size = new System.Drawing.Size(277, 20);
            this.cmbThuoc.Style = style8;
            this.cmbThuoc.TabIndex = 204;
            this.cmbThuoc.PropBag = resources.GetString("cmbThuoc.PropBag");
            // 
            // cmbBenhNhan
            // 
            this.cmbBenhNhan.AddItemSeparator = ';';
            this.cmbBenhNhan.AllowColMove = false;
            this.cmbBenhNhan.AllowRowSizing = C1.Win.C1List.RowSizingEnum.AllRows;
            this.cmbBenhNhan.AutoCompletion = true;
            this.cmbBenhNhan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cmbBenhNhan.Caption = "";
            this.cmbBenhNhan.CaptionHeight = 17;
            this.cmbBenhNhan.CaptionStyle = style9;
            this.cmbBenhNhan.CaptionVisible = false;
            this.cmbBenhNhan.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cmbBenhNhan.ColumnCaptionHeight = 17;
            this.cmbBenhNhan.ColumnFooterHeight = 17;
            this.cmbBenhNhan.ColumnHeaders = false;
            this.cmbBenhNhan.ContentHeight = 16;
            this.cmbBenhNhan.DataMode = C1.Win.C1List.DataModeEnum.AddItem;
            this.cmbBenhNhan.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cmbBenhNhan.DefColWidth = 30;
            this.cmbBenhNhan.EditorBackColor = System.Drawing.Color.White;
            this.cmbBenhNhan.EditorFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBenhNhan.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbBenhNhan.EditorHeight = 16;
            this.cmbBenhNhan.EvenRowStyle = style10;
            this.cmbBenhNhan.ExtendRightColumn = true;
            this.cmbBenhNhan.FlatStyle = C1.Win.C1List.FlatModeEnum.Popup;
            this.cmbBenhNhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBenhNhan.FooterStyle = style11;
            this.cmbBenhNhan.GapHeight = 2;
            this.cmbBenhNhan.HeadingStyle = style12;
            this.cmbBenhNhan.HighLightRowStyle = style13;
            this.cmbBenhNhan.ItemHeight = 15;
            this.cmbBenhNhan.Location = new System.Drawing.Point(75, 78);
            this.cmbBenhNhan.MatchCol = C1.Win.C1List.MatchColEnum.AllCols;
            this.cmbBenhNhan.MatchEntryTimeout = ((long)(2000));
            this.cmbBenhNhan.MaxDropDownItems = ((short)(10));
            this.cmbBenhNhan.MaxLength = 32767;
            this.cmbBenhNhan.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cmbBenhNhan.Name = "cmbBenhNhan";
            this.cmbBenhNhan.OddRowStyle = style14;
            this.cmbBenhNhan.PartialRightColumn = false;
            this.cmbBenhNhan.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.cmbBenhNhan.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.cmbBenhNhan.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cmbBenhNhan.SelectedStyle = style15;
            this.cmbBenhNhan.Size = new System.Drawing.Size(246, 20);
            this.cmbBenhNhan.Style = style16;
            this.cmbBenhNhan.TabIndex = 203;
            this.cmbBenhNhan.PropBag = resources.GetString("cmbBenhNhan.PropBag");
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(327, 82);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 202;
            this.label8.Text = "Thuốc";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 200;
            this.label4.Text = "Bệnh nhân";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(460, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Tính phí";
            // 
            // cmbTinhPhi
            // 
            this.cmbTinhPhi.FormattingEnabled = true;
            this.cmbTinhPhi.Items.AddRange(new object[] {
            "Không tính phí",
            "Tính phí",
            "Toàn bộ"});
            this.cmbTinhPhi.Location = new System.Drawing.Point(521, 29);
            this.cmbTinhPhi.Name = "cmbTinhPhi";
            this.cmbTinhPhi.Size = new System.Drawing.Size(118, 21);
            this.cmbTinhPhi.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(258, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Đã TT";
            // 
            // cmbDaTT
            // 
            this.cmbDaTT.FormattingEnabled = true;
            this.cmbDaTT.Items.AddRange(new object[] {
            "Chưa thanh toán",
            "Đã thanh toán",
            "Toàn bộ"});
            this.cmbDaTT.Location = new System.Drawing.Point(313, 29);
            this.cmbDaTT.Name = "cmbDaTT";
            this.cmbDaTT.Size = new System.Drawing.Size(123, 21);
            this.cmbDaTT.TabIndex = 16;
            // 
            // cmbKhoaNhan
            // 
            this.cmbKhoaNhan.FormattingEnabled = true;
            this.cmbKhoaNhan.Location = new System.Drawing.Point(75, 54);
            this.cmbKhoaNhan.Name = "cmbKhoaNhan";
            this.cmbKhoaNhan.Size = new System.Drawing.Size(174, 21);
            this.cmbKhoaNhan.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Khoa";
            // 
            // khoxuat
            // 
            this.khoxuat.AutoSize = true;
            this.khoxuat.Location = new System.Drawing.Point(10, 35);
            this.khoxuat.Name = "khoxuat";
            this.khoxuat.Size = new System.Drawing.Size(26, 13);
            this.khoxuat.TabIndex = 12;
            this.khoxuat.Text = "Kho";
            // 
            // cmbKhoXuat
            // 
            this.cmbKhoXuat.FormattingEnabled = true;
            this.cmbKhoXuat.Location = new System.Drawing.Point(75, 30);
            this.cmbKhoXuat.Name = "cmbKhoXuat";
            this.cmbKhoXuat.Size = new System.Drawing.Size(174, 21);
            this.cmbKhoXuat.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(460, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "đến ngày:";
            // 
            // btnTim
            // 
            this.btnTim.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(220)))));
            this.btnTim.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTim.Location = new System.Drawing.Point(660, 29);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(101, 44);
            this.btnTim.TabIndex = 7;
            this.btnTim.Text = "Xem";
            this.btnTim.UseVisualStyleBackColor = false;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // dpDenNgay
            // 
            this.dpDenNgay.CustomFormat = "dd/MM/yyyy";
            this.dpDenNgay.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
            this.dpDenNgay.Location = new System.Drawing.Point(521, 55);
            this.dpDenNgay.Name = "dpDenNgay";
            this.dpDenNgay.Size = new System.Drawing.Size(118, 20);
            this.dpDenNgay.TabIndex = 6;
            this.dpDenNgay.Tag = null;
            // 
            // dpTuNgay
            // 
            this.dpTuNgay.CustomFormat = "dd/MM/yyyy";
            this.dpTuNgay.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
            this.dpTuNgay.Location = new System.Drawing.Point(313, 55);
            this.dpTuNgay.Name = "dpTuNgay";
            this.dpTuNgay.Size = new System.Drawing.Size(123, 20);
            this.dpTuNgay.TabIndex = 5;
            this.dpTuNgay.Tag = null;
            // 
            // rdTongHop
            // 
            this.rdTongHop.AutoSize = true;
            this.rdTongHop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.rdTongHop.Location = new System.Drawing.Point(204, 7);
            this.rdTongHop.Name = "rdTongHop";
            this.rdTongHop.Size = new System.Drawing.Size(71, 17);
            this.rdTongHop.TabIndex = 3;
            this.rdTongHop.Text = "Tổng hợp";
            this.rdTongHop.UseVisualStyleBackColor = true;
            // 
            // rdChiTiet
            // 
            this.rdChiTiet.AutoSize = true;
            this.rdChiTiet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.rdChiTiet.Checked = true;
            this.rdChiTiet.Location = new System.Drawing.Point(129, 8);
            this.rdChiTiet.Name = "rdChiTiet";
            this.rdChiTiet.Size = new System.Drawing.Size(57, 17);
            this.rdChiTiet.TabIndex = 2;
            this.rdChiTiet.TabStop = true;
            this.rdChiTiet.Text = "Chi tiết";
            this.rdChiTiet.UseVisualStyleBackColor = true;
            this.rdChiTiet.CheckedChanged += new System.EventHandler(this.raChiTiet_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(258, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Từ ngày:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Loại báo cáo";
            // 
            // frmBCSDTaiPK
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(782, 661);
            this.Controls.Add(this.arvMain);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmBCSDTaiPK";
            this.Text = "Báo cáo sử dụng thuốc tại phòng khoa";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PreviewForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbThuoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBenhNhan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpDenNgay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpTuNgay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void PreviewForm_Load(object sender, System.EventArgs e)
		{
            loadDM();
            DataDynamics.ActiveReports.Toolbar.Button btn = new DataDynamics.ActiveReports.Toolbar.Button();
            btn.ButtonStyle = DataDynamics.ActiveReports.Toolbar.ButtonStyle.TextAndIcon;
            btn.Id = 5003;
            btn.Caption = "Thoát";
            btn.ToolTip = "Ðóng báo cáo";
            arvMain.Toolbar.Tools.Insert(arvMain.Toolbar.Tools.Count, (DataDynamics.ActiveReports.Toolbar.Tool)btn);

            btn = new DataDynamics.ActiveReports.Toolbar.Button();
            btn.ButtonStyle = DataDynamics.ActiveReports.Toolbar.ButtonStyle.TextAndIcon;
            btn.Caption = "Kết xuất";
            btn.Id = 5001;	// unique identifier for the new tool
            btn.ToolTip = "Kết xuất báo cáo ra các định dạng khác";
            arvMain.Toolbar.Tools.Insert(arvMain.Toolbar.Tools.Count, (DataDynamics.ActiveReports.Toolbar.Tool)btn);
        }

		private void arViewer_ToolClick(object sender, DataDynamics.ActiveReports.Toolbar.ToolClickEventArgs e)
		{
			//Add code to run when new buttons are clicked
			try
			{
				switch(e.Tool.Id)
				{
					case 5002: //Save button
						this.SaveDocument();
						break;
					case 5001: //Export button
						this.ExportDocument();
						break;
                    case 5003:
                        this.Dispose();
                        break;
				}
			}
			catch(System.IO.IOException exp)
			{
				MessageBox.Show(exp.ToString());
			}
		}
		
		/// <summary>
		/// Saves out an existing report document to the RDF format.
		/// </summary>
		private void SaveDocument()
		{
			SaveFileDialog _dlgSave = new SaveFileDialog();
			_dlgSave.Title = "Save Report Document";
			_dlgSave.Filter = "Report Document Files (*.rdf)|*.rdf";
			_dlgSave.DefaultExt = "rdf";
			_dlgSave.AddExtension = true;
			if (_dlgSave.ShowDialog(this) == DialogResult.OK)
			{
				if (File.Exists(_dlgSave.FileName))
				{
					if (MessageBox.Show(this, "Overwrite Existing File?", "Overwrite", MessageBoxButtons.YesNo) != DialogResult.Yes)
					{
						return;
					}
				}
				arvMain.Document.Save(_dlgSave.FileName);
			}
		}

		/// <summary>
		/// Opens the export form to export out the current report document
		/// </summary>
		private void ExportDocument()
		{
			ExportForm _exportForm = new ExportForm(arvMain.Document);
			_exportForm.ShowDialog(this);
		}

		/// <summary>
		/// mnuExport_Click - called the ExportDocument() call to export out the
		/// current report document
		/// </summary>
		private void mnuExport_Click(object sender, System.EventArgs e)
		{
			this.ExportDocument();
		}

		/// <summary>
		/// mnuSaveDocument_Click - called the SaveDocument() call to save the 
		/// current report document to the RDF format.
		/// </summary>
		private void mnuSaveDocument_Click(object sender, System.EventArgs e)
		{
			this.SaveDocument();
		}

		/// <summary>
		/// mnuPrinterSetup_Click - opens the Printer Dialog box to assist in
		/// printer setup.
		/// </summary>
		private void mnuPrinterSetup_Click(object sender, System.EventArgs e)
		{
			if (this.arvMain.Document != null)
			{
				this.dlgPrint.Document = this.arvMain.Document.Printer;
				dlgPrint.ShowDialog(this);
			
			}		
		}

        private void kếtXuấtDữLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ExportDocument();
        }

        private void lưuBáoCáoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SaveDocument();
        }

        private void thiếtLậpTrangInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.arvMain.Document != null)
            {
                this.dlgPrint.Document = this.arvMain.Document.Printer;
                dlgPrint.ShowDialog(this);
            }
        }

        private void raChiTiet_CheckedChanged(object sender, EventArgs e)
        {
            if (rdChiTiet.Checked)
            {
                cmbBenhNhan.Enabled = true;
                cmbThuoc.Enabled = true;
                DpTuNgay_ValueChanged(sender, e);
            }
            else
            {
                cmbBenhNhan.Enabled = false;
                cmbThuoc.Enabled = false;
            }
        }

        private void đóngBáoCáoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private DataSet LoatData(string storename)
        {
            try
            {
                System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
                SQLCmd.CommandType = CommandType.StoredProcedure;
                SQLCmd.CommandText = storename;
                SQLCmd.CommandTimeout = 0;
                System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(SQLCmd);
                System.Data.DataSet ds = new DataSet();
                SqlParameter param0 = new SqlParameter("@KhoID", System.Data.SqlDbType.VarChar, 2);
                param0.Value = KhoID;
                SQLCmd.Parameters.Add(param0);
                SqlParameter param1 = new SqlParameter("@DoiTuong", System.Data.SqlDbType.VarChar, 2);
                param1.Value = DoiTuong;
                SQLCmd.Parameters.Add(param1);
                SqlParameter param2 = new SqlParameter("@TuNgay", System.Data.SqlDbType.SmallDateTime);
                param2.Value = TuNgay;
                SQLCmd.Parameters.Add(param2);
                SqlParameter param3 = new SqlParameter("@DenNgay", System.Data.SqlDbType.SmallDateTime);
                param3.Value = DenNgay;
                SQLCmd.Parameters.Add(param3);
                SqlParameter param4 = new SqlParameter("@DaTT", System.Data.SqlDbType.Int);
                param4.Value = DaTT;
                SQLCmd.Parameters.Add(param4);
                SqlParameter param5 = new SqlParameter("@TinhPhi", System.Data.SqlDbType.Int);
                param5.Value = DaTT;
                SQLCmd.Parameters.Add(param5);
                SqlParameter param6 = new SqlParameter("@DonVi", System.Data.SqlDbType.VarChar, 10);
                param6.Value = DonVi;
                SQLCmd.Parameters.Add(param6);
                SqlParameter param7 = new SqlParameter("@MaVaoVien", System.Data.SqlDbType.VarChar, 10);
                param7.Value = MaVaoVien;
                SQLCmd.Parameters.Add(param7);
                SqlParameter param8 = new SqlParameter("@ThuocID", System.Data.SqlDbType.VarChar, 15);
                param8.Value = ThuocID;
                SQLCmd.Parameters.Add(param8);
                ds.Clear();
                da.Fill(ds);
                return ds;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        public System.Data.DataSet getDanhMuc(string storename,string filter)
        {
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
            SQLCmd.CommandType = CommandType.StoredProcedure;
            SQLCmd.CommandText = storename;
            SQLCmd.CommandTimeout = 0;
            System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(SQLCmd);
            System.Data.DataSet ds = new DataSet();
            SqlParameter param = new SqlParameter("@filter", System.Data.SqlDbType.NVarChar, 255);
            param.Value = filter;
            SQLCmd.Parameters.Add(param);
            da.SelectCommand = SQLCmd;
            try
            {
                da.Fill(ds, storename);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            return ds;
        }
        public System.Data.DataSet GetDS(string storename) //ds benhnhan hoac ds thuoc
        {
            this.TuNgay = DateTime.Parse(DateTime.Parse(dpTuNgay.Value.ToString()).ToShortDateString());
            this.DenNgay = DateTime.Parse(DateTime.Parse(dpDenNgay.Value.ToString()).ToShortDateString());
            DonVi = cmbKhoaNhan.SelectedValue.ToString();
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
            SQLCmd.CommandType = CommandType.StoredProcedure;
            SQLCmd.CommandText = storename;
            SQLCmd.CommandTimeout = 0;
            System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(SQLCmd);
            System.Data.DataSet ds = new DataSet();
            SqlParameter param2 = new SqlParameter("@TuNgay", System.Data.SqlDbType.Date);
            param2.Value = TuNgay;
            SQLCmd.Parameters.Add(param2);
            SqlParameter param3 = new SqlParameter("@DenNgay", System.Data.SqlDbType.Date);
            param3.Value = DenNgay;
            SQLCmd.Parameters.Add(param3);
            SqlParameter param6 = new SqlParameter("@DonVi", System.Data.SqlDbType.VarChar, 10);
            param6.Value = DonVi;
            SQLCmd.Parameters.Add(param6);
            da.SelectCommand = SQLCmd;
            try
            {
                da.Fill(ds, storename);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            return ds;
        }
        private void btnTim_Click(object sender, EventArgs e)
        {
            this.TuNgay = DateTime.Parse(DateTime.Parse(dpTuNgay.Value.ToString()).ToShortDateString());
            this.DenNgay = DateTime.Parse(DateTime.Parse(dpDenNgay.Value.ToString()).ToShortDateString());
            DoiTuong = "";
            TinhPhi = cmbTinhPhi.SelectedIndex;
            DaTT = cmbDaTT.SelectedIndex;
            KhoID = cmbKhoXuat.SelectedValue.ToString();
            DonVi = cmbKhoaNhan.SelectedValue.ToString();
            MaVaoVien = cmbBenhNhan.SelectedValue.ToString();
            ThuocID = cmbThuoc.SelectedValue.ToString();
            if (rdChiTiet.Checked)
            {
                dsBaoCao = LoatData("NamDinh_Duoc.dbo.GetBaoCaoSuDungThuocTaiKhoa");
                Reports.rptBCSDTaiKhoaChiTiet rpt = new NamDinh_QLBN.Reports.rptBCSDTaiKhoaChiTiet();
                rpt.DataSource = dsBaoCao.Tables[0];
                dsBaoCao.Tables[0].Columns.Add("GTTon", typeof(Double), "SLTon * DonGia");
                dsBaoCao.Tables[0].Columns.Add("SLTLinh", typeof(Double), "SLNhan - SLHoan");
                dsBaoCao.Tables[0].Columns.Add("GTTLinh", typeof(Double), "DonGia*(SLNhan - SLHoan)");
                dsBaoCao.Tables[0].Columns.Add("GTDaTT", typeof(Double), "SLDaTT * DonGia");
                dsBaoCao.Tables[0].Columns.Add("SLTonCuoi", typeof(Double), "SLTon + SLNhan - SLHoan - SLDaTT");
                dsBaoCao.Tables[0].Columns.Add("GTTonCuoi", typeof(Double), "DonGia*(SLTon + SLNhan - SLHoan - SLDaTT)");
                arvMain.Document = rpt.Document;
                rpt.lblDoiTuong.Text = "Đối tượng:Toàn bộ";
                rpt.lblNgay.Text = string.Format("Từ ngày {0:dd/MM/yyyy} đến ngày {1:dd/MM/yyyy}", dpTuNgay.Value, dpDenNgay.Value);
                rpt.lblNgayKy.Text = string.Format("Nam Định, ngày {0:dd} tháng {0:MM} năm {0:yyyy}", Global.NgayLV);
                rpt.lblThanhToan.Text = "Thanh toán:"+cmbDaTT.Text;
                rpt.lblTinhPhi.Text = "Tính phí:" + cmbTinhPhi.Text;
                rpt.lblBenhNhan.Text = "Bệnh nhân:" + cmbBenhNhan.Text + "-" + cmbBenhNhan.Splits[0].DisplayColumns["SoHSBA"].DataColumn.Value.ToString();
                rpt.lblThuoc.Text = "Thuốc:" + cmbThuoc.Text;
                rpt.Run();
            }
            else
            {
                dsBaoCao = LoatData("NamDinh_Duoc.dbo.GetBaoCaoSuDungThuocTongHopTaiKhoa");
                Reports.rptBCSDTaiKhoaTongHop rpt = new NamDinh_QLBN.Reports.rptBCSDTaiKhoaTongHop();
                rpt.DataSource = dsBaoCao.Tables[0];
                dsBaoCao.Tables[0].Columns.Add("GTTon", typeof(Double), "SLTon * DonGia");
                dsBaoCao.Tables[0].Columns.Add("SLTLinh", typeof(Double), "SLNhan - SLHoan");
                dsBaoCao.Tables[0].Columns.Add("GTTLinh", typeof(Double), "DonGia*(SLNhan - SLHoan)");
                dsBaoCao.Tables[0].Columns.Add("GTDaTT", typeof(Double), "SLDaTT * DonGia");
                dsBaoCao.Tables[0].Columns.Add("SLTonCuoi", typeof(Double), "SLTon + SLNhan - SLHoan - SLDaTT");
                dsBaoCao.Tables[0].Columns.Add("GTTonCuoi", typeof(Double), "DonGia*(SLTon + SLNhan - SLHoan - SLDaTT)");
                arvMain.Document = rpt.Document;
                rpt.lblDoiTuong.Text = "Đối tượng:Toàn bộ";
                rpt.lblNgay.Text = string.Format("Từ ngày {0:dd/MM/yyyy} đến ngày {1:dd/MM/yyyy}", dpTuNgay.Value, dpDenNgay.Value);
                rpt.lblNgayKy.Text = string.Format("Nam Định, ngày {0:dd} tháng {0:MM} năm {0:yyyy}", Global.NgayLV);
                rpt.lblThanhToan.Text = "Thanh toán:" + cmbDaTT.Text;
                rpt.lblTinhPhi.Text = "Tính phí:" + cmbTinhPhi.Text;
                rpt.Run();
            }
        }
    }
}
