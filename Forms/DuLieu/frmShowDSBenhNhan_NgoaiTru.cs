using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace NamDinh_QLBN.Forms.DuLieu
{
	/// <summary>
	/// Summary description for frmShowDSBenhNhan_NgoaiTru.
	/// </summary>
	public class frmShowDSBenhNhan_NgoaiTru : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button cmdOK;
		private System.Windows.Forms.Button cmdCancel;
		private C1.Win.C1FlexGrid.C1FlexGrid fg;
        private System.Windows.Forms.Button cmdTim;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
        public string MaKhambenhReturn = "";
		public string TenBenhnhanReturn = "";
		public string NamsinhReturn = "";
		public string GioiTinhReturn = "";
		public string DiachiReturn = "";
		public string Chuyenvien_ChandoanReturn = "";
		public string TenBVReturn = "";
		public string TenDuReturn = "";
        public string Chuyenvien_ThoigianReturn;
        public string thoigiandangkyReturn;
        public string KhoathuchienReturn = "";
        public string tenkhoaReturn = "";
        public string HanhChinhReturn = "";
        private string tblname="";
        private C1.Win.C1Input.C1DateEdit txtDenNgay;
        private Label label3;
        private GroupBox groupBox1;
        internal C1.Win.C1List.C1Combo cmbPhongKham;
        private Label label14;
        private byte vDaRaVien = 0;
        public string DaTinhPhiReturn = "";
        public byte DaRaVienReturn ;
        public DateTime NgayKhamReturn;
        int covid;

        public frmShowDSBenhNhan_NgoaiTru()
		{

			InitializeComponent();
		}
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShowDSBenhNhan_NgoaiTru));
            C1.Win.C1List.Style style57 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style58 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style59 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style60 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style61 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style62 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style63 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style64 = new C1.Win.C1List.Style();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.fg = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.cmdTim = new System.Windows.Forms.Button();
            this.txtDenNgay = new C1.Win.C1Input.C1DateEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cmbPhongKham = new C1.Win.C1List.C1Combo();
            ((System.ComponentModel.ISupportInitialize)(this.fg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDenNgay)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPhongKham)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdOK
            // 
            this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdOK.Image = ((System.Drawing.Image)(resources.GetObject("cmdOK.Image")));
            this.cmdOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdOK.Location = new System.Drawing.Point(703, 601);
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
            this.cmdCancel.Location = new System.Drawing.Point(805, 601);
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
            this.fg.Location = new System.Drawing.Point(3, 72);
            this.fg.Name = "fg";
            this.fg.Rows.Count = 1;
            this.fg.Rows.MinSize = 20;
            this.fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
            this.fg.ShowCursor = true;
            this.fg.Size = new System.Drawing.Size(884, 523);
            this.fg.Styles = new C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("fg.Styles"));
            this.fg.TabIndex = 48;
            this.fg.DoubleClick += new System.EventHandler(this.cmdOK_Click);
            this.fg.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmShowDSBenhNhan_NgoaiTru_KeyDown);
            // 
            // cmdTim
            // 
            this.cmdTim.Image = ((System.Drawing.Image)(resources.GetObject("cmdTim.Image")));
            this.cmdTim.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdTim.Location = new System.Drawing.Point(780, 9);
            this.cmdTim.Name = "cmdTim";
            this.cmdTim.Size = new System.Drawing.Size(98, 43);
            this.cmdTim.TabIndex = 53;
            this.cmdTim.Text = "Tìm";
            this.cmdTim.Click += new System.EventHandler(this.cmdTim_Click);
            // 
            // txtDenNgay
            // 
            this.txtDenNgay.Culture = 1066;
            this.txtDenNgay.CustomFormat = "dd/MM/yyyy";
            this.txtDenNgay.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
            this.txtDenNgay.Location = new System.Drawing.Point(76, 11);
            this.txtDenNgay.Name = "txtDenNgay";
            this.txtDenNgay.Size = new System.Drawing.Size(103, 20);
            this.txtDenNgay.TabIndex = 137;
            this.txtDenNgay.Tag = null;
            this.txtDenNgay.Value = new System.DateTime(2009, 9, 5, 0, 0, 0, 0);
            this.txtDenNgay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmShowDSBenhNhan_NgoaiTru_KeyDown);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(9, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 20);
            this.label3.TabIndex = 136;
            this.label3.Text = "Ngày khám";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmdTim);
            this.groupBox1.Controls.Add(this.txtDenNgay);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.cmbPhongKham);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(3, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(884, 71);
            this.groupBox1.TabIndex = 140;
            this.groupBox1.TabStop = false;
            // 
            // label14
            // 
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(9, 34);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(67, 18);
            this.label14.TabIndex = 197;
            this.label14.Text = "Phòng khám";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbPhongKham
            // 
            this.cmbPhongKham.AddItemSeparator = ';';
            this.cmbPhongKham.AllowColMove = false;
            this.cmbPhongKham.AllowRowSizing = C1.Win.C1List.RowSizingEnum.AllRows;
            this.cmbPhongKham.AutoCompletion = true;
            this.cmbPhongKham.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cmbPhongKham.Caption = "";
            this.cmbPhongKham.CaptionHeight = 17;
            this.cmbPhongKham.CaptionStyle = style57;
            this.cmbPhongKham.CaptionVisible = false;
            this.cmbPhongKham.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cmbPhongKham.ColumnCaptionHeight = 17;
            this.cmbPhongKham.ColumnFooterHeight = 17;
            this.cmbPhongKham.ColumnHeaders = false;
            this.cmbPhongKham.ContentHeight = 16;
            this.cmbPhongKham.DataMode = C1.Win.C1List.DataModeEnum.AddItem;
            this.cmbPhongKham.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cmbPhongKham.DefColWidth = 1;
            this.cmbPhongKham.DisplayMember = "Danh mục";
            this.cmbPhongKham.EditorBackColor = System.Drawing.Color.White;
            this.cmbPhongKham.EditorFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPhongKham.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbPhongKham.EditorHeight = 16;
            this.cmbPhongKham.EvenRowStyle = style58;
            this.cmbPhongKham.ExtendRightColumn = true;
            this.cmbPhongKham.FlatStyle = C1.Win.C1List.FlatModeEnum.Popup;
            this.cmbPhongKham.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPhongKham.FooterStyle = style59;
            this.cmbPhongKham.GapHeight = 2;
            this.cmbPhongKham.HeadingStyle = style60;
            this.cmbPhongKham.HighLightRowStyle = style61;
            this.cmbPhongKham.ItemHeight = 15;
            this.cmbPhongKham.Location = new System.Drawing.Point(76, 34);
            this.cmbPhongKham.MatchCol = C1.Win.C1List.MatchColEnum.AllCols;
            this.cmbPhongKham.MatchEntryTimeout = ((long)(2000));
            this.cmbPhongKham.MaxDropDownItems = ((short)(10));
            this.cmbPhongKham.MaxLength = 32767;
            this.cmbPhongKham.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cmbPhongKham.Name = "cmbPhongKham";
            this.cmbPhongKham.OddRowStyle = style62;
            this.cmbPhongKham.PartialRightColumn = false;
            this.cmbPhongKham.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.cmbPhongKham.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.cmbPhongKham.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cmbPhongKham.SelectedStyle = style63;
            this.cmbPhongKham.Size = new System.Drawing.Size(311, 20);
            this.cmbPhongKham.Style = style64;
            this.cmbPhongKham.TabIndex = 198;
            this.cmbPhongKham.TextChanged += new System.EventHandler(this.cmbNhom_TextChanged);
            this.cmbPhongKham.PropBag = resources.GetString("cmbPhongKham.PropBag");
            // 
            // frmShowDSBenhNhan_NgoaiTru
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(899, 633);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.fg);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.cmdCancel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmShowDSBenhNhan_NgoaiTru";
            this.Text = "Danh sách bệnh nhân ngoại trú";
            this.Load += new System.EventHandler(this.frmShowDSBenhNhan_NgoaiTru_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmShowDSBenhNhan_NgoaiTru_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.fg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDenNgay)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmbPhongKham)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void frmShowDSBenhNhan_NgoaiTru_Load(object sender, System.EventArgs e)
		{
			System.Data.SqlClient.SqlDataReader dr;
			System.Data.SqlClient.SqlCommand SQLCmd= new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            SQLCmd.CommandText = "select MaKhoa, TenKhoa from NAMDINH_SYSDB.DBO.DMKHOAPHONG WHERE is_Phongkham = 1";
            dr = SQLCmd.ExecuteReader();
            cmbPhongKham.Tag = "0";
            cmbPhongKham.ClearItems();
            while (dr.Read())
            {
                cmbPhongKham.AddItem(string.Format("{0};{1}", dr["MaKhoa"], dr["TenKhoa"]));
            }
            cmbPhongKham.SelectedIndex = 0;
            cmbPhongKham.Tag = "1";
            dr.Close();
            txtDenNgay.Value = GlobalModuls.Global.GetNgayLV();
		}

		private void cmdTim_Click(object sender, System.EventArgs e)
		{
            if (cmbPhongKham.SelectedIndex == -1)
            {
                MessageBox.Show("Chọn tên phòng khám", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbPhongKham.Focus();
                return;
            }
			if (tblname !="") {return;}
			string DKTim="",Str = "";
			System.Data.SqlClient.SqlDataReader dr;
			System.Data.SqlClient.SqlCommand SQLCmd= new System.Data.SqlClient.SqlCommand();
			SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            SQLCmd.CommandText = string.Format("select b.MaKhambenh,a.TenBenhnhan,a.Namsinh,case when a.Gioitinh = 0 then N'NỮ' else N'NAM' END AS GioiTinh,b.Diachi,Chuyenvien_Chandoan,TenBV,TenDu,Chuyenvien_Thoigian,Khoathuchien, kp.tenkhoa,thoigiandangky," +
                                                    "N'Dấu hiệu lâm sàng: \r\n' + c.Chuyenvien_DauhieuLS  + '\r\n' + N'Xét nghiệm: \r\n' + c.Chuyenvien_CacXN + '\r\n' + N'Xử trí:  \r\n'  +  Chuyenvien_Thuoc   +'\r\n' +  N'Tình trạng khi chuyển viện: \r\n'   + Chuyenvien_TinhtrangBN as thongtinhc"
                                                + " from NAMDINH_KHAMBENH.dbo.tblbenhnhan a inner join NAMDINH_KHAMBENH.dbo.tblKHAMBENH b on a.MaBenhnhan  = b.MaBenhnhan"
                                                + " inner join NAMDINH_KHAMBENH.dbo.tblKHAMBENH_KQDVKHAM c on c.MaKhambenh = b.MaKhambenh"
                                                + " inner join NAMDINH_SYSDB.dbo.SYSUSER d on UPPER(d.UName) = uppER(c.UName_Update)"
                                                + " inner join NAMDINH_KHAMBENH.DBO.DMTenBV E ON E.ID = C.Chuyenvien_Benhvien"
                                                + " INNER JOIN NAMDINH_SYSDB.DBO.DMKHOAPHONG KP ON KP.MAKHOA = c.khoathuchien"
                                                + " where datediff(day, b.ThoigianDangky, '{1:dd/MM/yyyy}') = 0 and HuongGQ in (6, 7, 8, 9)"
                                                + " and Khoathuchien = '{0}'", GlobalModuls.Global.GetCode(cmbPhongKham),txtDenNgay.Value);
			dr=SQLCmd.ExecuteReader();
			fg.ClipSeparators ="|;";
			fg.Rows.Count =1;
			while (dr.Read())
			{
                fg.AddItem(string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9:dd/MM/yyyy HH:mm:ss tt}|{10}|{11}|{12}|{13:dd/MM/yyyy HH:mm:ss tt}", 
                    fg.Rows.Count, 
                    dr["MaKhambenh"], 
                    dr["TenBenhnhan"], 
                    dr["Namsinh"], 
                    dr["GioiTinh"],
                    dr["Diachi"], 
                    dr["Chuyenvien_Chandoan"], 
                    dr["TenBV"],
                    dr["TenDu"],
                    dr["Chuyenvien_Thoigian"],
                    dr["Khoathuchien"],
                    dr["thongtinhc"],
                    dr["tenkhoa"],
                    dr["thoigiandangky"]
                    ));
			}
			dr.Close();
			SQLCmd.Dispose();
            fg.AutoSizeCols();
		}

		private void cmdOK_Click(object sender, System.EventArgs e)
		{
			if (fg.Row<1) {return;}
            MaKhambenhReturn = fg.GetDataDisplay(fg.Row, "MaKhambenh");
            TenBenhnhanReturn = fg.GetDataDisplay(fg.Row, "TenBenhnhan");
			NamsinhReturn = fg.GetDataDisplay(fg.Row, "Namsinh");
			GioiTinhReturn = fg.GetDataDisplay(fg.Row, "GioiTinh");			
			DiachiReturn = fg.GetDataDisplay(fg.Row, "Diachi");
            Chuyenvien_ChandoanReturn = fg.GetDataDisplay(fg.Row, "Chuyenvien_Chandoan");
            TenBVReturn = fg.GetDataDisplay(fg.Row, "TenBV");
            TenDuReturn = fg.GetDataDisplay(fg.Row, "TenDu");
            Chuyenvien_ThoigianReturn =  string.Format("{0:dd/MM/yyyy HH:mm:ss tt}", fg.GetDataDisplay(fg.Row, "Chuyenvien_Thoigian"));
            thoigiandangkyReturn = string.Format("{0:dd/MM/yyyy HH:mm:ss tt}", fg.GetDataDisplay(fg.Row, "thoigiandangky"));
            KhoathuchienReturn = fg.GetDataDisplay(fg.Row, "Khoathuchien");
            tenkhoaReturn = fg.GetDataDisplay(fg.Row, "tenkhoa");
            HanhChinhReturn = fg.GetDataDisplay(fg.Row, "thongtinhc");
            this.DialogResult = DialogResult.OK;
			this.Dispose();

		}

		private void cmdCancel_Click(object sender, System.EventArgs e)
		{
            MaKhambenhReturn = "";
			this.Dispose();
		}
             
        private void raDangDT_CheckedChanged(object sender, EventArgs e)
        {
            //if (raDangDT.Checked)
            //{
            //    txtTuNgay.Enabled = txtDenNgay.Enabled = false;
            //}
            //else
            //{
            //    txtTuNgay.Enabled = txtDenNgay.Enabled = true;
            //}
        }
         
        private void raDaRV_CheckedChanged(object sender, EventArgs e)
        {
            raDangDT_CheckedChanged(sender, e);
        }

        private void raTaCa_CheckedChanged(object sender, EventArgs e)
        {
            raDangDT_CheckedChanged(sender, e);
        }

        private void frmShowDSBenhNhan_NgoaiTru_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                if (fg.Row < 1) { return; }
                MaKhambenhReturn = fg.GetDataDisplay(fg.Row, "MaKhambenh");
                TenBenhnhanReturn = fg.GetDataDisplay(fg.Row, "TenBenhnhan");
                NamsinhReturn = fg.GetDataDisplay(fg.Row, "Namsinh");
                GioiTinhReturn = fg.GetDataDisplay(fg.Row, "GioiTinh");
                DiachiReturn = fg.GetDataDisplay(fg.Row, "Diachi");
                Chuyenvien_ChandoanReturn = fg.GetDataDisplay(fg.Row, "Chuyenvien_Chandoan");
                TenBVReturn = fg.GetDataDisplay(fg.Row, "TenBV");
                TenDuReturn = fg.GetDataDisplay(fg.Row, "TenDu");
                Chuyenvien_ThoigianReturn = string.Format("{0:dd/MM/yyyy HH:mm:ss tt}", fg.GetDataDisplay(fg.Row, "Chuyenvien_Thoigian"));
                thoigiandangkyReturn = string.Format("{0:dd/MM/yyyy HH:mm:ss tt}", fg.GetDataDisplay(fg.Row, "thoigiandangky"));
                KhoathuchienReturn = fg.GetDataDisplay(fg.Row, "Khoathuchien");
                tenkhoaReturn =  fg.GetDataDisplay(fg.Row, "tenkhoa");
                HanhChinhReturn = fg.GetDataDisplay(fg.Row, "thongtinhc");
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
            if (cmbPhongKham.Tag.ToString() == "0") return;
            cmbPhongKham.Tag = 0;
            cmdTim_Click(sender, e);
            cmbPhongKham.Tag = 1;
            fg.AutoSizeCols();
        }
	}
}
