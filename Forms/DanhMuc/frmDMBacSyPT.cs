using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace NamDinh_QLBN.Forms.DanhMuc
{
	/// <summary>
	/// Summary description for frmDMLoaiChiPhi.
	/// </summary>
	public class frmDMBacSyPT : System.Windows.Forms.Form
    {
		private C1.Win.C1FlexGrid.C1FlexGrid fg;
		private System.Windows.Forms.Button cmdOK;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox txtTen;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtMa;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button cmdXoa;
		private System.Windows.Forms.Button cmdThem;
		private System.Windows.Forms.Button cmdCancel;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button cmdSua;
        private TextBox txtTentat;
        private Label label1;
        private Label lblKhoa;
        internal C1.Win.C1List.C1Combo cmbKhoa;
        internal C1.Win.C1List.C1Combo cmbChucVu;
        private Label label4;
        private TextBox txtThutu;
        private Label label5;
        private CheckBox chkKhongsudung;
        private TextBox TxtCCHN;
        private Label label6;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public frmDMBacSyPT()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDMBacSyPT));
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
            this.fg = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TxtCCHN = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chkKhongsudung = new System.Windows.Forms.CheckBox();
            this.txtThutu = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbChucVu = new C1.Win.C1List.C1Combo();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTentat = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMa = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblKhoa = new System.Windows.Forms.Label();
            this.cmbKhoa = new C1.Win.C1List.C1Combo();
            this.cmdXoa = new System.Windows.Forms.Button();
            this.cmdThem = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cmdSua = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.fg)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbChucVu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKhoa)).BeginInit();
            this.SuspendLayout();
            // 
            // fg
            // 
            this.fg.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.fg.AllowEditing = false;
            this.fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Light3D;
            this.fg.ColumnInfo = resources.GetString("fg.ColumnInfo");
            this.fg.ExtendLastCol = true;
            this.fg.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid;
            this.fg.HighLight = C1.Win.C1FlexGrid.HighLightEnum.WithFocus;
            this.fg.Location = new System.Drawing.Point(2, 161);
            this.fg.Name = "fg";
            this.fg.Rows.Count = 1;
            this.fg.Rows.MinSize = 20;
            this.fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
            this.fg.ShowCursor = true;
            this.fg.Size = new System.Drawing.Size(492, 344);
            this.fg.Styles = new C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("fg.Styles"));
            this.fg.TabIndex = 69;
            this.fg.AfterSelChange += new C1.Win.C1FlexGrid.RangeEventHandler(this.fg_AfterSelChange);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TxtCCHN);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.chkKhongsudung);
            this.groupBox1.Controls.Add(this.txtThutu);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cmbChucVu);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtTentat);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtTen);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtMa);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(2, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(492, 131);
            this.groupBox1.TabIndex = 70;
            this.groupBox1.TabStop = false;
            // 
            // TxtCCHN
            // 
            this.TxtCCHN.Location = new System.Drawing.Point(307, 11);
            this.TxtCCHN.MaxLength = 50;
            this.TxtCCHN.Name = "TxtCCHN";
            this.TxtCCHN.Size = new System.Drawing.Size(178, 20);
            this.TxtCCHN.TabIndex = 123;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(247, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 18);
            this.label6.TabIndex = 124;
            this.label6.Text = "Số CCHN";
            // 
            // chkKhongsudung
            // 
            this.chkKhongsudung.AutoSize = true;
            this.chkKhongsudung.Location = new System.Drawing.Point(329, 103);
            this.chkKhongsudung.Name = "chkKhongsudung";
            this.chkKhongsudung.Size = new System.Drawing.Size(98, 17);
            this.chkKhongsudung.TabIndex = 122;
            this.chkKhongsudung.Text = "Không sử dụng";
            this.chkKhongsudung.UseVisualStyleBackColor = true;
            // 
            // txtThutu
            // 
            this.txtThutu.Location = new System.Drawing.Point(72, 99);
            this.txtThutu.MaxLength = 3;
            this.txtThutu.Name = "txtThutu";
            this.txtThutu.Size = new System.Drawing.Size(169, 20);
            this.txtThutu.TabIndex = 121;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(13, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 18);
            this.label5.TabIndex = 120;
            this.label5.Text = "Thứ tự";
            // 
            // cmbChucVu
            // 
            this.cmbChucVu.AddItemSeparator = ';';
            this.cmbChucVu.AllowColMove = false;
            this.cmbChucVu.AllowRowSizing = C1.Win.C1List.RowSizingEnum.AllRows;
            this.cmbChucVu.AutoCompletion = true;
            this.cmbChucVu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cmbChucVu.Caption = "";
            this.cmbChucVu.CaptionHeight = 17;
            this.cmbChucVu.CaptionStyle = style1;
            this.cmbChucVu.CaptionVisible = false;
            this.cmbChucVu.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cmbChucVu.ColumnCaptionHeight = 17;
            this.cmbChucVu.ColumnFooterHeight = 17;
            this.cmbChucVu.ColumnHeaders = false;
            this.cmbChucVu.ContentHeight = 16;
            this.cmbChucVu.DataMode = C1.Win.C1List.DataModeEnum.AddItem;
            this.cmbChucVu.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cmbChucVu.DefColWidth = 30;
            this.cmbChucVu.DisplayMember = "Danh mục";
            this.cmbChucVu.EditorBackColor = System.Drawing.Color.White;
            this.cmbChucVu.EditorFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbChucVu.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbChucVu.EditorHeight = 16;
            this.cmbChucVu.EvenRowStyle = style2;
            this.cmbChucVu.ExtendRightColumn = true;
            this.cmbChucVu.FlatStyle = C1.Win.C1List.FlatModeEnum.Popup;
            this.cmbChucVu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbChucVu.FooterStyle = style3;
            this.cmbChucVu.GapHeight = 2;
            this.cmbChucVu.HeadingStyle = style4;
            this.cmbChucVu.HighLightRowStyle = style5;
            this.cmbChucVu.ItemHeight = 15;
            this.cmbChucVu.Location = new System.Drawing.Point(72, 76);
            this.cmbChucVu.MatchCol = C1.Win.C1List.MatchColEnum.AllCols;
            this.cmbChucVu.MatchEntryTimeout = ((long)(2000));
            this.cmbChucVu.MaxDropDownItems = ((short)(10));
            this.cmbChucVu.MaxLength = 32767;
            this.cmbChucVu.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cmbChucVu.Name = "cmbChucVu";
            this.cmbChucVu.OddRowStyle = style6;
            this.cmbChucVu.PartialRightColumn = false;
            this.cmbChucVu.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.cmbChucVu.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.cmbChucVu.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cmbChucVu.SelectedStyle = style7;
            this.cmbChucVu.Size = new System.Drawing.Size(414, 20);
            this.cmbChucVu.Style = style8;
            this.cmbChucVu.TabIndex = 5;
            this.cmbChucVu.PropBag = resources.GetString("cmbChucVu.PropBag");
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(12, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 18);
            this.label4.TabIndex = 119;
            this.label4.Text = "Chức vụ";
            // 
            // txtTentat
            // 
            this.txtTentat.Location = new System.Drawing.Point(72, 54);
            this.txtTentat.MaxLength = 20;
            this.txtTentat.Name = "txtTentat";
            this.txtTentat.Size = new System.Drawing.Size(295, 20);
            this.txtTentat.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "Tên tắt";
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(72, 33);
            this.txtTen.MaxLength = 50;
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(414, 20);
            this.txtTen.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tên BS";
            // 
            // txtMa
            // 
            this.txtMa.Location = new System.Drawing.Point(72, 12);
            this.txtMa.MaxLength = 2;
            this.txtMa.Name = "txtMa";
            this.txtMa.Size = new System.Drawing.Size(169, 20);
            this.txtMa.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã";
            // 
            // lblKhoa
            // 
            this.lblKhoa.Location = new System.Drawing.Point(14, 8);
            this.lblKhoa.Name = "lblKhoa";
            this.lblKhoa.Size = new System.Drawing.Size(39, 18);
            this.lblKhoa.TabIndex = 77;
            this.lblKhoa.Text = "Khoa:";
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
            this.cmbKhoa.Location = new System.Drawing.Point(74, 6);
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
            this.cmbKhoa.Size = new System.Drawing.Size(420, 20);
            this.cmbKhoa.Style = style16;
            this.cmbKhoa.TabIndex = 118;
            this.cmbKhoa.TextChanged += new System.EventHandler(this.cmbKhoa_TextChanged);
            this.cmbKhoa.PropBag = resources.GetString("cmbKhoa.PropBag");
            // 
            // cmdXoa
            // 
            this.cmdXoa.Image = ((System.Drawing.Image)(resources.GetObject("cmdXoa.Image")));
            this.cmdXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdXoa.Location = new System.Drawing.Point(158, 512);
            this.cmdXoa.Name = "cmdXoa";
            this.cmdXoa.Size = new System.Drawing.Size(69, 27);
            this.cmdXoa.TabIndex = 74;
            this.cmdXoa.Text = "  Xóa";
            this.cmdXoa.Click += new System.EventHandler(this.cmdXoa_Click);
            // 
            // cmdThem
            // 
            this.cmdThem.Image = ((System.Drawing.Image)(resources.GetObject("cmdThem.Image")));
            this.cmdThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdThem.Location = new System.Drawing.Point(-4, 512);
            this.cmdThem.Name = "cmdThem";
            this.cmdThem.Size = new System.Drawing.Size(69, 27);
            this.cmdThem.TabIndex = 73;
            this.cmdThem.Text = "  Thêm";
            this.cmdThem.Click += new System.EventHandler(this.cmdThem_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Image = ((System.Drawing.Image)(resources.GetObject("cmdCancel.Image")));
            this.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancel.Location = new System.Drawing.Point(194, 512);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(81, 27);
            this.cmdCancel.TabIndex = 76;
            this.cmdCancel.Text = "     Không ghi";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(298, 512);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(69, 27);
            this.button1.TabIndex = 71;
            this.button1.Text = " Thoát";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmdSua
            // 
            this.cmdSua.Image = ((System.Drawing.Image)(resources.GetObject("cmdSua.Image")));
            this.cmdSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSua.Location = new System.Drawing.Point(68, 512);
            this.cmdSua.Name = "cmdSua";
            this.cmdSua.Size = new System.Drawing.Size(69, 27);
            this.cmdSua.TabIndex = 72;
            this.cmdSua.Text = "  Sửa";
            this.cmdSua.Click += new System.EventHandler(this.cmdSua_Click);
            // 
            // cmdOK
            // 
            this.cmdOK.Image = ((System.Drawing.Image)(resources.GetObject("cmdOK.Image")));
            this.cmdOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdOK.Location = new System.Drawing.Point(107, 512);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(81, 27);
            this.cmdOK.TabIndex = 75;
            this.cmdOK.Text = "  Ghi lại";
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // frmDMBacSyPT
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(499, 543);
            this.Controls.Add(this.cmbKhoa);
            this.Controls.Add(this.lblKhoa);
            this.Controls.Add(this.fg);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmdXoa);
            this.Controls.Add(this.cmdThem);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmdSua);
            this.Controls.Add(this.cmdOK);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDMBacSyPT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh mục bác sỹ";
            this.Load += new System.EventHandler(this.frmDMLoaiChiPhi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fg)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbChucVu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKhoa)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void Load_DM()
		{
			System.Data.SqlClient.SqlDataReader dr;
			System.Data.SqlClient.SqlCommand SQLCmd= new System.Data.SqlClient.SqlCommand();
			SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            SQLCmd.CommandText = "SELECT * FROM DMKHOAPHONG WHERE MaKhoa IN " + GlobalModuls.Global.glbKhoa_CapNhat;
            dr = SQLCmd.ExecuteReader();
            cmbKhoa.Tag = "0";
            cmbKhoa.ClearItems();
            while (dr.Read())
            {
                cmbKhoa.AddItem(string.Format("{0};{1}", dr["MaKhoa"], dr["TenKhoa"]));
            }
            dr.Close();
            SQLCmd.Dispose();
            cmbKhoa.SelectedIndex = -1;
            cmbKhoa.Tag = "1";
            if (cmbKhoa.ListCount > 0) cmbKhoa.SelectedIndex = 0;
            SQLCmd.CommandText = "SELECT * FROM DMCHUCVU";
            dr = SQLCmd.ExecuteReader();
            cmbChucVu.ClearItems();
            while (dr.Read())
            {
                cmbChucVu.AddItem(string.Format("{0};{1}", dr["MaChucVu"], dr["TenChucVu"]));
            }
            dr.Close();
            SQLCmd.Dispose();
            cmbChucVu.SelectedIndex = -1;
		}
        private void Load_DSBacSy(string MaKhoa)
        {
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;            
            SQLCmd.CommandText = string.Format("SELECT * FROM DMBACSY WHERE MaKhoa='{0}' order by Thutu", MaKhoa);
            dr = SQLCmd.ExecuteReader();
            fg.Tag = "0";
            fg.Rows.Count = 1;
            while (dr.Read())
            {
                fg.AddItem(string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}", fg.Rows.Count, dr["MaBS"], dr["TenBS"], dr["TenTat"], dr["MaChucVu"], dr["Thutu"],(dr["Khongsudung"].ToString() == "1") ? (true) : (false),dr["SoChungChiHanhNghe"]));
            }
            dr.Close();
            SQLCmd.Dispose();
            fg.Tag = "1";
            Clear_Data();
        }
        private void Clear_Data()
        {
            txtMa.Text = txtTen.Text = txtTentat.Text = "";
            cmbChucVu.SelectedIndex = -1;
        }
		private void LockEdit(bool IsLock)
		{
            txtMa.ReadOnly = IsLock;
			txtTen.ReadOnly = IsLock;
            txtTentat.ReadOnly = IsLock;
            txtThutu.ReadOnly = IsLock;
            cmbChucVu.ReadOnly = IsLock;
			fg.Enabled = IsLock;
            chkKhongsudung.Enabled = !IsLock;
			cmdThem.Visible = IsLock;
			cmdSua.Visible=IsLock;
			cmdXoa.Visible=IsLock;
			button1.Visible = IsLock;			
			cmdOK.Visible =!IsLock;
			cmdCancel.Visible = !IsLock;
		}
		
		private void cmdOK_Click(object sender, System.EventArgs e)
		{
            int Khongsudung = (chkKhongsudung.Checked) ? (1) : (0);
			if (txtMa.Text.Length != 2)
			{
				MessageBox.Show("Độ dài của Mã là 2 ký tự! Đề nghị nhập lại","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return;
			}
			if (txtTen.Text.Trim() == "")
			{
				MessageBox.Show("Tên không được để trống! Đề nghị nhập lại","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return;
			}
			System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();			 
			cmd.Connection = GlobalModuls.Global.ConnectSQL;
			System.Data.SqlClient.SqlDataReader dr;
			
			if (txtMa.ReadOnly) //Sua
			{
                cmd.CommandText = string.Format("UPDATE DMBACSY SET TenBS=N'{0}',TenTat=N'{1}',MaChucVu={4},Thutu={5}, Khongsudung = {6},SoChungChiHanhNghe = N'{7}' WHERE MaBS='{2}' AND MaKhoa='{3}'", txtTen.Text, txtTentat.Text, txtMa.Text, GlobalModuls.Global.GetCode(cmbKhoa),
                    (GlobalModuls.Global.GetCode(cmbChucVu) == null) ? ("Null") : ("'" + GlobalModuls.Global.GetCode(cmbChucVu) + "'"), txtThutu.Text, Khongsudung,TxtCCHN.Text);
			}
			else
			{
				cmd.CommandText =string.Format("SELECT * FROM DMBACSY WHERE TenBS=N'{0}' AND MaKhoa='{1}'",txtTen.Text,GlobalModuls.Global.GetCode(cmbKhoa));
				dr=cmd.ExecuteReader();
				if (dr.HasRows)
				{
					dr.Close();
					MessageBox.Show("Tên đã có trong danh mục, đề nghị kiểm tra lại!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
					cmd.Dispose();
					return;
				}
				dr.Close();
                cmd.CommandText = string.Format("INSERT INTO DMBACSY (maBS,TenBS,TenTat,MaKhoa,MaChucVu, Thutu, Khongsudung,SoChungChiHanhNghe) VALUES ('{0}',N'{1}',N'{2}',N'{3}',{4},{5}, {6},N'{7}')", txtMa.Text, txtTen.Text, txtTentat.Text, GlobalModuls.Global.GetCode(cmbKhoa),
                    (GlobalModuls.Global.GetCode(cmbChucVu) == null) ? ("Null") : ("'" + GlobalModuls.Global.GetCode(cmbChucVu) + "'"), txtThutu.Text, Khongsudung, TxtCCHN.Text);
			}
			try
			{
				cmd.ExecuteNonQuery();
				if (txtMa.ReadOnly)
				{
                    fg[fg.Row,2] = txtTen.Text;
                    fg[fg.Row, 3] = txtTentat.Text;
                    fg[fg.Row, 4] = GlobalModuls.Global.GetCode(cmbChucVu);
                }
				else
				{
                    fg.AddItem(string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}", fg.Rows.Count, txtMa.Text, txtTen.Text, txtTentat.Text, GlobalModuls.Global.GetCode(cmbChucVu), txtThutu.Text, (Khongsudung == 1) ? (true) : (false),TxtCCHN.Text));
				}
				LockEdit(true);
                if (cmbKhoa.Tag.ToString() == "0" || cmbKhoa.SelectedIndex == -1) return;
                Load_DSBacSy(GlobalModuls.Global.GetCode(cmbKhoa));
			}
			catch (Exception ex)
			{
				MessageBox.Show("Có lỗi trong khi ghi dữ liệu!\n"+ex.Message);
			}
			finally
			{
				cmd.Dispose();
			}
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			this.Dispose();
		}

		private void fg_AfterSelChange(object sender, C1.Win.C1FlexGrid.RangeEventArgs e)
		{
            //if (fg.Tag.ToString() == "0") return;
			try
			{
				if (fg.Row<1 || fg.Tag.ToString() =="0") {return;}
				txtMa.Text = fg[fg.Row,1].ToString();
				txtTen.Text = fg[fg.Row,2].ToString();
                txtTentat.Text = fg[fg.Row, 3].ToString();
                txtThutu.Text = fg[fg.Row, "Thutu"].ToString();
                chkKhongsudung.Checked = (fg[fg.Row, "Khongsudung"].ToString() == "True") ? (true) : (false);
                GlobalModuls.Global.SetCmb(cmbChucVu, fg[fg.Row, "MaChucVu"].ToString());
                TxtCCHN.Text = fg[fg.Row, 7].ToString();
            }
			catch
			{
			}
		}

		private void cmdCancel_Click(object sender, System.EventArgs e)
		{
            if (fg.Row > 0)
            {
                txtMa.Text = fg[fg.Row, 1].ToString();
                txtTen.Text = fg[fg.Row, 2].ToString();
                txtTentat.Text = fg[fg.Row, 3].ToString();
            }
            else
            { Clear_Data(); }
			LockEdit(true);
		}

		private void cmdSua_Click(object sender, System.EventArgs e)
		{
			if (fg.Row <1)
			{
				MessageBox.Show("Chưa chọn danh mục để sửa, đề nghị làm lại!","Thông báo");
				return;
			}
			LockEdit(false);
			txtMa.ReadOnly = true;
			txtTen.Focus();
		}

		private void cmdThem_Click(object sender, System.EventArgs e)
		{			
			if (fg.Rows.Count ==1)
			{ 
				txtMa.Text ="01";
			}
			else
			{
				txtMa.Text=string.Format("{0:00}",int.Parse(fg[fg.Rows.Count -1,1].ToString())+1);
			}
			LockEdit(false);
			txtTen.Text ="";
            txtTentat.Text = "";
			txtTen.Focus();
		}

		private void frmDMLoaiChiPhi_Load(object sender, System.EventArgs e)
		{
            
			fg.ClipSeparators ="|;";
            Load_DM();
			LockEdit(true);
		}

        private void cmbKhoa_TextChanged(object sender, EventArgs e)
        {
            if (cmbKhoa.Tag.ToString()=="0" || cmbKhoa.SelectedIndex==-1) return;
            Load_DSBacSy(GlobalModuls.Global.GetCode(cmbKhoa));
        }

        private void cmdXoa_Click(object sender, EventArgs e)
        {
            if (txtMa.Text == "") return;
            if (MessageBox.Show("Bạn có chắc muốn xóa bác sỹ trong danh mục không?","Xác nhận xóa",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.No) return;
        }
	}
}
