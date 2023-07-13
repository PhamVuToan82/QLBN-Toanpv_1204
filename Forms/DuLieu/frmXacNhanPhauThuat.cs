using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using GlobalModuls;

namespace NamDinh_QLBN.Forms.DuLieu
{
	/// <summary>
	/// Summary description for frmXacNhanPhauThuat.
	/// </summary>
	public class frmXacNhanPhauThuat : System.Windows.Forms.Form
	{
		internal C1.Win.C1List.C1Combo cmbKhoa;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private C1.Win.C1Input.C1DateEdit txtTuNgay;
		private C1.Win.C1Input.C1DateEdit txtDenNgay;
		private System.Windows.Forms.CheckBox chkDaPT;
		private C1.Win.C1FlexGrid.C1FlexGrid fgDanhSach;
		private DevExpress.XtraEditors.SimpleButton cmdLoad;
		private DevExpress.XtraEditors.SimpleButton cmdThoat;
		private DevExpress.XtraEditors.SimpleButton cmdEdit;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmXacNhanPhauThuat()
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
            C1.Win.C1List.Style style1 = new C1.Win.C1List.Style();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmXacNhanPhauThuat));
            C1.Win.C1List.Style style2 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style3 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style4 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style5 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style6 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style7 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style8 = new C1.Win.C1List.Style();
            this.cmbKhoa = new C1.Win.C1List.C1Combo();
            this.label12 = new System.Windows.Forms.Label();
            this.txtTuNgay = new C1.Win.C1Input.C1DateEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDenNgay = new C1.Win.C1Input.C1DateEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.chkDaPT = new System.Windows.Forms.CheckBox();
            this.fgDanhSach = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.cmdLoad = new DevExpress.XtraEditors.SimpleButton();
            this.cmdThoat = new DevExpress.XtraEditors.SimpleButton();
            this.cmdEdit = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKhoa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTuNgay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDenNgay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fgDanhSach)).BeginInit();
            this.SuspendLayout();
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
            this.cmbKhoa.Location = new System.Drawing.Point(132, 21);
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
            this.cmbKhoa.Size = new System.Drawing.Size(363, 20);
            this.cmbKhoa.Style = style8;
            this.cmbKhoa.TabIndex = 106;
            this.cmbKhoa.PropBag = resources.GetString("cmbKhoa.PropBag");
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(3, 24);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(126, 15);
            this.label12.TabIndex = 105;
            this.label12.Text = "Khoa, Phòng điều trị";
            // 
            // txtTuNgay
            // 
            this.txtTuNgay.Culture = 1066;
            this.txtTuNgay.CustomFormat = "dd/MM/yyyy";
            this.txtTuNgay.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
            this.txtTuNgay.Location = new System.Drawing.Point(132, 0);
            this.txtTuNgay.Name = "txtTuNgay";
            this.txtTuNgay.Size = new System.Drawing.Size(135, 20);
            this.txtTuNgay.TabIndex = 108;
            this.txtTuNgay.Tag = null;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 18);
            this.label1.TabIndex = 107;
            this.label1.Text = "Phẫu thuật từ ngày";
            // 
            // txtDenNgay
            // 
            this.txtDenNgay.Culture = 1066;
            this.txtDenNgay.CustomFormat = "dd/MM/yyyy";
            this.txtDenNgay.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
            this.txtDenNgay.Location = new System.Drawing.Point(360, 0);
            this.txtDenNgay.Name = "txtDenNgay";
            this.txtDenNgay.Size = new System.Drawing.Size(135, 20);
            this.txtDenNgay.TabIndex = 110;
            this.txtDenNgay.Tag = null;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(300, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 18);
            this.label2.TabIndex = 109;
            this.label2.Text = "Đến ngày";
            // 
            // chkDaPT
            // 
            this.chkDaPT.Checked = true;
            this.chkDaPT.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDaPT.Location = new System.Drawing.Point(132, 45);
            this.chkDaPT.Name = "chkDaPT";
            this.chkDaPT.Size = new System.Drawing.Size(300, 18);
            this.chkDaPT.TabIndex = 111;
            this.chkDaPT.Text = "Chỉ liệt kê những bệnh nhân chưa phẫu thuật";
            // 
            // fgDanhSach
            // 
            this.fgDanhSach.AllowDelete = true;
            this.fgDanhSach.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.fgDanhSach.AllowEditing = false;
            this.fgDanhSach.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Light3D;
            this.fgDanhSach.ColumnInfo = resources.GetString("fgDanhSach.ColumnInfo");
            this.fgDanhSach.ExtendLastCol = true;
            this.fgDanhSach.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid;
            this.fgDanhSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fgDanhSach.Location = new System.Drawing.Point(0, 63);
            this.fgDanhSach.Name = "fgDanhSach";
            this.fgDanhSach.Rows.Count = 1;
            this.fgDanhSach.Rows.MinSize = 20;
            this.fgDanhSach.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox;
            this.fgDanhSach.ShowCursor = true;
            this.fgDanhSach.Size = new System.Drawing.Size(618, 285);
            this.fgDanhSach.Styles = new C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("fgDanhSach.Styles"));
            this.fgDanhSach.TabIndex = 112;
            this.fgDanhSach.DoubleClick += new System.EventHandler(this.cmdEdit_Click);
            this.fgDanhSach.Click += new System.EventHandler(this.fgDanhSach_Click);
            // 
            // cmdLoad
            // 
            this.cmdLoad.Image = ((System.Drawing.Image)(resources.GetObject("cmdLoad.Image")));
            this.cmdLoad.Location = new System.Drawing.Point(504, 3);
            this.cmdLoad.Name = "cmdLoad";
            this.cmdLoad.Size = new System.Drawing.Size(111, 54);
            this.cmdLoad.TabIndex = 127;
            this.cmdLoad.Text = "Đọc dữ liệu";
            this.cmdLoad.Click += new System.EventHandler(this.cmdLoad_Click);
            // 
            // cmdThoat
            // 
            this.cmdThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdThoat.Image = ((System.Drawing.Image)(resources.GetObject("cmdThoat.Image")));
            this.cmdThoat.Location = new System.Drawing.Point(546, 351);
            this.cmdThoat.Name = "cmdThoat";
            this.cmdThoat.Size = new System.Drawing.Size(69, 27);
            this.cmdThoat.TabIndex = 128;
            this.cmdThoat.Text = "Thoát";
            this.cmdThoat.Click += new System.EventHandler(this.cmdThoat_Click);
            // 
            // cmdEdit
            // 
            this.cmdEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdEdit.Image = ((System.Drawing.Image)(resources.GetObject("cmdEdit.Image")));
            this.cmdEdit.Location = new System.Drawing.Point(201, 351);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(186, 27);
            this.cmdEdit.TabIndex = 129;
            this.cmdEdit.Text = "Cập nhật dữ liệu";
            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
            // 
            // frmXacNhanPhauThuat
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(619, 378);
            this.Controls.Add(this.cmdEdit);
            this.Controls.Add(this.cmdThoat);
            this.Controls.Add(this.cmdLoad);
            this.Controls.Add(this.fgDanhSach);
            this.Controls.Add(this.chkDaPT);
            this.Controls.Add(this.txtDenNgay);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTuNgay);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbKhoa);
            this.Controls.Add(this.label12);
            this.Name = "frmXacNhanPhauThuat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý bệnh nhân phẫu thuật, thủ thuật";
            this.Load += new System.EventHandler(this.frmXacNhanPhauThuat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cmbKhoa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTuNgay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDenNgay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fgDanhSach)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void frmXacNhanPhauThuat_Load(object sender, System.EventArgs e)
		{
			System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
			System.Data.SqlClient.SqlDataReader dr;
			SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
			SQLCmd.CommandText  = "SELECT * FROM DMKHOAPHONG WHERE MaKhoa IN " + Global.glbKhoa_CapNhat;
			dr=SQLCmd.ExecuteReader();
			cmbKhoa.Tag ="0";
			cmbKhoa.ClearItems();
			while (dr.Read())
			{
				cmbKhoa.AddItem(string.Format("{0};{1}",dr["MaKhoa"],dr["TenKhoa"]));
			}
			cmbKhoa.SelectedIndex =-1;
			cmbKhoa.Tag ="1";
			dr.Close();
			SQLCmd.Dispose();
			txtTuNgay.Value = DateTime.Parse(string.Format("01/{0}/{1}",Global.NgayLV.Month,Global.NgayLV.Year));
			txtDenNgay.Value = Global.NgayLV;
			fgDanhSach.ClipSeparators ="|;";
		}

		private void cmdLoad_Click(object sender, System.EventArgs e)
		{
			System.Data.SqlClient.SqlDataReader dr;
			System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
			SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
			string SQLStr= string.Format("SELECT BENHNHAN.*,year(GetDate()) - NamSinh As Tuoi,ViewKHOAHIENTAI.LanVaoVien,TenPP,DaPhauThuat,NgayPhauThuat,BENHNHAN_PHAUTHUAT.GhiChu,LanPT "
											+ " FROM "
											+ " ((BENHNHAN INNER JOIN ViewKHOAHIENTAI ON BENHNHAN.MaBenhNhan=ViewKHOAHIENTAI.MaBenhNhan) "
											+ " INNER JOIN BENHNHAN_PHAUTHUAT ON BENHNHAN.MaBenhNhan=BENHNHAN_PHAUTHUAT.MaBenhNhan AND ViewKHOAHIENTAI.LanVaoVien=BENHNHAN_PHAUTHUAT.LanVaoVien) "
                                            + " INNER JOIN DMPHUONGPHAPDIEUTRI ON YeuCauPhauThuat=MaPP "
											+ " WHERE ViewKHOAHIENTAI.MaKhoa='{0}' AND vDaRaVien=0",Global.GetCode(cmbKhoa));
			if (chkDaPT.Checked) {SQLStr +=" AND DaPhauThuat=0";}
			SQLStr += string.Format(" AND NgayPhauThuat BETWEEN '{0:MM/dd/yyyy}' AND '{1:MM/dd/yyyy}'",txtTuNgay.Value,txtDenNgay.Value);
			SQLCmd.CommandText =SQLStr;
			dr=SQLCmd.ExecuteReader();
			fgDanhSach.Rows.Count = 1;
			while (dr.Read())
			{
				fgDanhSach.AddItem(string.Format("{0}|{1}|{2}|{3}|{4}|{5:dd/MM/yyyy}|{6}|{7}|{8}|{9}|{10}",
					fgDanhSach.Rows.Count,
					dr["MaBenhNhan"],
					dr["HoTen"],
					dr["Tuoi"],				
					(dr["GioiTinh"].ToString() =="1")?("Nam"):("Nữ"),
					dr["NgayPhauThuat"],
					dr["TenPP"],
					(dr["DaPhauThuat"].ToString()=="1")?("True"):("False"),					
					dr["GhiChu"],
					dr["LanPT"],
					dr["LanVaoVien"]));
			}
			dr.Close();
			SQLCmd.Dispose();
		}

		private void cmdEdit_Click(object sender, System.EventArgs e)
		{
			if (fgDanhSach.Row<1) {return;}
			int RowSelected = fgDanhSach.Row;
			NamDinh_QLBN.Forms.DuLieu.frmXacNhanPhauThuat_ChiTiet fr = new frmXacNhanPhauThuat_ChiTiet(fgDanhSach.GetDataDisplay(RowSelected,1),byte.Parse(fgDanhSach.GetDataDisplay(RowSelected,9)),byte.Parse(fgDanhSach.GetDataDisplay(RowSelected,10)));
			fr.ShowDialog();
			if (fr.GhiChu !="")
			{
				fgDanhSach[RowSelected,5]=string.Format("{0:dd/MM/yyyy}", fr.NgayPT );
				fgDanhSach[RowSelected,7]=fr.DaPT;
				fgDanhSach[RowSelected,8]=fr.GhiChu;
			}
		}

		private void cmdThoat_Click(object sender, System.EventArgs e)
		{
			this.Dispose();
		}

		private void fgDanhSach_Click(object sender, System.EventArgs e)
		{
		
		}
	}
}
