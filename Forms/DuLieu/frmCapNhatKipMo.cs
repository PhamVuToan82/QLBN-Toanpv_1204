using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace NamDinh_QLBN.Forms.DuLieu
{
	/// <summary>
	/// Summary description for frmCapNhatKipMo.
	/// </summary>
	public class frmCapNhatKipMo : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label1;
		private DevExpress.XtraEditors.SimpleButton cmdEdit;
		private DevExpress.XtraEditors.SimpleButton cmdThoat;
		internal C1.Win.C1List.C1Combo cmbViTri;
        private C1.Win.C1FlexGrid.C1FlexGrid fg = null;
        private Label label2;
        internal C1.Win.C1List.C1Combo cmbKhoa;
        internal C1.Win.C1List.C1Combo cmbBacSy;
        private string B5ChiDinh;
        private DateTime timeBatDau, timeKetThuc;
        private C1.Win.C1FlexGrid.C1FlexGrid fgKipMo;

        public frmCapNhatKipMo(C1.Win.C1FlexGrid.C1FlexGrid  _fg,string _B5ChiDinh)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			fg=_fg;
            B5ChiDinh = _B5ChiDinh;
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
            C1.Win.C1List.Style style25 = new C1.Win.C1List.Style();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCapNhatKipMo));
            C1.Win.C1List.Style style26 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style27 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style28 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style29 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style30 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style31 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style32 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style33 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style34 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style35 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style36 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style37 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style38 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style39 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style40 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style41 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style42 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style43 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style44 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style45 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style46 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style47 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style48 = new C1.Win.C1List.Style();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbKhoa = new C1.Win.C1List.C1Combo();
            this.cmbBacSy = new C1.Win.C1List.C1Combo();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbViTri = new C1.Win.C1List.C1Combo();
            this.label1 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.fgKipMo = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.cmdEdit = new DevExpress.XtraEditors.SimpleButton();
            this.cmdThoat = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKhoa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBacSy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbViTri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fgKipMo)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbKhoa);
            this.groupBox1.Controls.Add(this.cmbBacSy);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbViTri);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Location = new System.Drawing.Point(3, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(463, 94);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
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
            this.cmbKhoa.CaptionStyle = style25;
            this.cmbKhoa.CaptionVisible = false;
            this.cmbKhoa.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cmbKhoa.ColumnCaptionHeight = 17;
            this.cmbKhoa.ColumnFooterHeight = 17;
            this.cmbKhoa.ColumnHeaders = false;
            this.cmbKhoa.ContentHeight = 16;
            this.cmbKhoa.DataMode = C1.Win.C1List.DataModeEnum.AddItem;
            this.cmbKhoa.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cmbKhoa.DefColWidth = 1;
            this.cmbKhoa.DisplayMember = "Danh mục";
            this.cmbKhoa.EditorBackColor = System.Drawing.Color.White;
            this.cmbKhoa.EditorFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbKhoa.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbKhoa.EditorHeight = 16;
            this.cmbKhoa.EvenRowStyle = style26;
            this.cmbKhoa.ExtendRightColumn = true;
            this.cmbKhoa.FlatStyle = C1.Win.C1List.FlatModeEnum.Popup;
            this.cmbKhoa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbKhoa.FooterStyle = style27;
            this.cmbKhoa.GapHeight = 2;
            this.cmbKhoa.HeadingStyle = style28;
            this.cmbKhoa.HighLightRowStyle = style29;
            this.cmbKhoa.ItemHeight = 15;
            this.cmbKhoa.Location = new System.Drawing.Point(85, 19);
            this.cmbKhoa.MatchCol = C1.Win.C1List.MatchColEnum.AllCols;
            this.cmbKhoa.MatchEntryTimeout = ((long)(2000));
            this.cmbKhoa.MaxDropDownItems = ((short)(10));
            this.cmbKhoa.MaxLength = 32767;
            this.cmbKhoa.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cmbKhoa.Name = "cmbKhoa";
            this.cmbKhoa.OddRowStyle = style30;
            this.cmbKhoa.PartialRightColumn = false;
            this.cmbKhoa.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.cmbKhoa.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.cmbKhoa.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cmbKhoa.SelectedStyle = style31;
            this.cmbKhoa.Size = new System.Drawing.Size(372, 20);
            this.cmbKhoa.Style = style32;
            this.cmbKhoa.TabIndex = 1;
            this.cmbKhoa.TextChanged += new System.EventHandler(this.cmbKhoa_TextChanged);
            this.cmbKhoa.PropBag = resources.GetString("cmbKhoa.PropBag");
            // 
            // cmbBacSy
            // 
            this.cmbBacSy.AddItemSeparator = ';';
            this.cmbBacSy.AllowColMove = false;
            this.cmbBacSy.AllowRowSizing = C1.Win.C1List.RowSizingEnum.AllRows;
            this.cmbBacSy.AutoCompletion = true;
            this.cmbBacSy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cmbBacSy.Caption = "";
            this.cmbBacSy.CaptionHeight = 17;
            this.cmbBacSy.CaptionStyle = style33;
            this.cmbBacSy.CaptionVisible = false;
            this.cmbBacSy.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cmbBacSy.ColumnCaptionHeight = 17;
            this.cmbBacSy.ColumnFooterHeight = 17;
            this.cmbBacSy.ColumnHeaders = false;
            this.cmbBacSy.ContentHeight = 16;
            this.cmbBacSy.DataMode = C1.Win.C1List.DataModeEnum.AddItem;
            this.cmbBacSy.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cmbBacSy.DefColWidth = 200;
            this.cmbBacSy.DisplayMember = "Danh mục";
            this.cmbBacSy.EditorBackColor = System.Drawing.Color.White;
            this.cmbBacSy.EditorFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBacSy.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbBacSy.EditorHeight = 16;
            this.cmbBacSy.EvenRowStyle = style34;
            this.cmbBacSy.ExtendRightColumn = true;
            this.cmbBacSy.FlatStyle = C1.Win.C1List.FlatModeEnum.Popup;
            this.cmbBacSy.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBacSy.FooterStyle = style35;
            this.cmbBacSy.GapHeight = 2;
            this.cmbBacSy.HeadingStyle = style36;
            this.cmbBacSy.HighLightRowStyle = style37;
            this.cmbBacSy.ItemHeight = 15;
            this.cmbBacSy.Location = new System.Drawing.Point(85, 43);
            this.cmbBacSy.MatchCol = C1.Win.C1List.MatchColEnum.AllCols;
            this.cmbBacSy.MatchEntryTimeout = ((long)(2000));
            this.cmbBacSy.MaxDropDownItems = ((short)(10));
            this.cmbBacSy.MaxLength = 32767;
            this.cmbBacSy.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cmbBacSy.Name = "cmbBacSy";
            this.cmbBacSy.OddRowStyle = style38;
            this.cmbBacSy.PartialRightColumn = false;
            this.cmbBacSy.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.cmbBacSy.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.cmbBacSy.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cmbBacSy.SelectedStyle = style39;
            this.cmbBacSy.Size = new System.Drawing.Size(372, 20);
            this.cmbBacSy.Style = style40;
            this.cmbBacSy.TabIndex = 2;
            this.cmbBacSy.TextChanged += new System.EventHandler(this.cmbBacSy_TextChanged);
            this.cmbBacSy.PropBag = resources.GetString("cmbBacSy.PropBag");
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(4, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 15);
            this.label2.TabIndex = 146;
            this.label2.Text = "Đơn vị";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cmbViTri
            // 
            this.cmbViTri.AddItemSeparator = ';';
            this.cmbViTri.AllowColMove = false;
            this.cmbViTri.AllowRowSizing = C1.Win.C1List.RowSizingEnum.AllRows;
            this.cmbViTri.AutoCompletion = true;
            this.cmbViTri.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cmbViTri.Caption = "";
            this.cmbViTri.CaptionHeight = 17;
            this.cmbViTri.CaptionStyle = style41;
            this.cmbViTri.CaptionVisible = false;
            this.cmbViTri.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cmbViTri.ColumnCaptionHeight = 17;
            this.cmbViTri.ColumnFooterHeight = 17;
            this.cmbViTri.ColumnHeaders = false;
            this.cmbViTri.ContentHeight = 16;
            this.cmbViTri.DataMode = C1.Win.C1List.DataModeEnum.AddItem;
            this.cmbViTri.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cmbViTri.DefColWidth = 1;
            this.cmbViTri.DisplayMember = "Danh mục";
            this.cmbViTri.EditorBackColor = System.Drawing.Color.White;
            this.cmbViTri.EditorFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbViTri.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbViTri.EditorHeight = 16;
            this.cmbViTri.EvenRowStyle = style42;
            this.cmbViTri.ExtendRightColumn = true;
            this.cmbViTri.FlatStyle = C1.Win.C1List.FlatModeEnum.Popup;
            this.cmbViTri.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbViTri.FooterStyle = style43;
            this.cmbViTri.GapHeight = 2;
            this.cmbViTri.HeadingStyle = style44;
            this.cmbViTri.HighLightRowStyle = style45;
            this.cmbViTri.ItemHeight = 15;
            this.cmbViTri.Location = new System.Drawing.Point(85, 66);
            this.cmbViTri.MatchCol = C1.Win.C1List.MatchColEnum.AllCols;
            this.cmbViTri.MatchEntryTimeout = ((long)(2000));
            this.cmbViTri.MaxDropDownItems = ((short)(10));
            this.cmbViTri.MaxLength = 32767;
            this.cmbViTri.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cmbViTri.Name = "cmbViTri";
            this.cmbViTri.OddRowStyle = style46;
            this.cmbViTri.PartialRightColumn = false;
            this.cmbViTri.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.cmbViTri.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.cmbViTri.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cmbViTri.SelectedStyle = style47;
            this.cmbViTri.Size = new System.Drawing.Size(141, 20);
            this.cmbViTri.Style = style48;
            this.cmbViTri.TabIndex = 3;
            this.cmbViTri.PropBag = resources.GetString("cmbViTri.PropBag");
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Vị trí";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(4, 45);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(78, 15);
            this.label17.TabIndex = 1;
            this.label17.Text = "Tên BS /  KTV";
            this.label17.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // fgKipMo
            // 
            this.fgKipMo.AllowDelete = true;
            this.fgKipMo.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.fgKipMo.AllowEditing = false;
            this.fgKipMo.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
            this.fgKipMo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fgKipMo.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Light3D;
            this.fgKipMo.ColumnInfo = resources.GetString("fgKipMo.ColumnInfo");
            this.fgKipMo.ExtendLastCol = true;
            this.fgKipMo.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid;
            this.fgKipMo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fgKipMo.HighLight = C1.Win.C1FlexGrid.HighLightEnum.WithFocus;
            this.fgKipMo.Location = new System.Drawing.Point(3, 100);
            this.fgKipMo.Name = "fgKipMo";
            this.fgKipMo.Rows.Count = 1;
            this.fgKipMo.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
            this.fgKipMo.ShowCursor = true;
            this.fgKipMo.Size = new System.Drawing.Size(463, 99);
            this.fgKipMo.Styles = new C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("fgKipMo.Styles"));
            this.fgKipMo.TabIndex = 38;
            // 
            // cmdEdit
            // 
            this.cmdEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdEdit.Image = ((System.Drawing.Image)(resources.GetObject("cmdEdit.Image")));
            this.cmdEdit.Location = new System.Drawing.Point(3, 205);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(69, 27);
            this.cmdEdit.TabIndex = 4;
            this.cmdEdit.Text = "Thêm";
            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
            // 
            // cmdThoat
            // 
            this.cmdThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdThoat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdThoat.Image = ((System.Drawing.Image)(resources.GetObject("cmdThoat.Image")));
            this.cmdThoat.Location = new System.Drawing.Point(397, 205);
            this.cmdThoat.Name = "cmdThoat";
            this.cmdThoat.Size = new System.Drawing.Size(69, 27);
            this.cmdThoat.TabIndex = 5;
            this.cmdThoat.Text = "Thoát";
            this.cmdThoat.Click += new System.EventHandler(this.cmdThoat_Click);
            // 
            // frmCapNhatKipMo
            // 
            this.AcceptButton = this.cmdEdit;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.cmdThoat;
            this.ClientSize = new System.Drawing.Size(475, 245);
            this.Controls.Add(this.fgKipMo);
            this.Controls.Add(this.cmdEdit);
            this.Controls.Add(this.cmdThoat);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmCapNhatKipMo";
            this.Text = "Cập nhật kíp mổ";
            this.Load += new System.EventHandler(this.frmCapNhatKipMo_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmbKhoa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBacSy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbViTri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fgKipMo)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void frmCapNhatKipMo_Load(object sender, System.EventArgs e)
		{
			System.Data.SqlClient.SqlCommand SQLCmd=new System.Data.SqlClient.SqlCommand();
			System.Data.SqlClient.SqlDataReader dr;
			SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
			SQLCmd.CommandText =" SELECT * FROM DMVITRI_PT where MaVT < '6' ORDER BY MaVT ";
			dr=SQLCmd.ExecuteReader();
			while (dr.Read())
			{
				cmbViTri.AddItem(dr["MaVT"].ToString() + ";" + dr["TenVT"].ToString());
			}
			dr.Close();
			SQLCmd.CommandText = "SELECT * FROM DMKHOAPHONG WHERE IS_KHOADIEUTRI = 1";
			dr=SQLCmd.ExecuteReader();
            cmbKhoa.Tag = "0";
            cmbKhoa.ClearItems();
			while (dr.Read())
			{
				cmbKhoa.AddItem(string.Format("{0};{1}",dr["MaKhoa"],dr["TenKhoa"]));
			}
			dr.Close();
            cmbKhoa.Tag = "1";
            if (cmbKhoa.ListCount > 0)
            {
                GlobalModuls.Global.SetCmb(cmbKhoa, GlobalModuls.Global.glbMaKhoaPhong);
                Load_BacSy(GlobalModuls.Global.GetCode(cmbKhoa));
            }
			SQLCmd.Dispose();
		}
        private void Load_BacSy(string MaKhoa)
        {
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlDataReader dr;
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            SQLCmd.CommandText = string.Format(" SELECT * FROM DMBACSY WHERE MaKhoa='{0}'  and Khongsudung = 0 order by Thutu", MaKhoa);
            dr = SQLCmd.ExecuteReader();
            cmbBacSy.ClearItems();
            while (dr.Read())
            {
                cmbBacSy.AddItem(dr["MaBS"].ToString() + ";" + dr["TenBS"].ToString() + ";" + dr["MA_BHXH"].ToString());
            }
            dr.Close();
            SQLCmd.Dispose();

        }
		private void cmdEdit_Click(object sender, System.EventArgs e)
		{
			if (cmbBacSy.SelectedIndex==-1)
			{
				MessageBox.Show("Chưa chọn bác sỹ / kỹ thuật viên trong kíp mổ!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
				cmbBacSy.Focus();
				return;
			}
            if (GlobalModuls.Global.GetCode(cmbViTri) == null)
            {
                MessageBox.Show("Chưa nhập vị trí của bác sỹ / kỹ thuật viên trong kíp mổ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbViTri.Focus();
                return;
            }
			for (int i=1;i<fg.Rows.Count;i++)
			{
                //if (cmbBacSy.Text == fg.GetDataDisplay(i, 1))
                //{
                //    MessageBox.Show("Đã có bác sỹ / kỹ thuật viên " + cmbBacSy.Text + " trong kíp mổ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    cmbBacSy.Focus();
                //    return;
                //}
                string ma = (string)fg.GetData(i, 1);
                if (string.Compare(GlobalModuls.Global.GetCode(cmbBacSy) + GlobalModuls.Global.GetCode(cmbKhoa), ma) == 0)
                {
                    MessageBox.Show("Đã có bác sỹ / kỹ thuật viên " + cmbBacSy.Text + " trong kíp mổ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbBacSy.Focus();
                    return;
                }
            }
            string s = cmbBacSy.GetItemText(cmbBacSy.Row, "MA_BHXH").ToString();
            string MaBS = GlobalModuls.Global.GetCode(cmbBacSy)+ GlobalModuls.Global.GetCode(cmbKhoa);
            fg.AddItem(string.Format("{0}|{1}|{2}|{3}|{4}|{5}",fg.Rows.Count,MaBS,GlobalModuls.Global.GetCode(cmbKhoa), cmbViTri.Text,GlobalModuls.Global.GetCode(cmbViTri), cmbBacSy.Columns[2].CellText(cmbBacSy.SelectedIndex)));
		}

		private void cmdThoat_Click(object sender, System.EventArgs e)
		{
			this.Dispose();
		}

        private void cmbBacSy_TextChanged(object sender, EventArgs e)
        {
            //fgKipMo.Rows.Count = 1;
            //System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            //System.Data.SqlClient.SqlDataReader dr;
            //SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            //SQLCmd.CommandText = string.Format("set dateformat dmy select E.HoTen,a.ThoiGianBD as TgBatDau, a.ThoiGianKT as TgKetThuc from NAMDINH_QLBN.dbo.BENHNHAN_PHAUTHUAT a inner join NAMDINH_QLBN.dbo.BENHNHAN_PT_KIPMO b on a.SoPhieuCD = b.SoPhieuCD and a.MaVaoVien = b.MaVaoVien and a.MaPT = b.MaPT inner join NAMDINH_QLBN.dbo.DMBACSY c on c.MaBS = b.MaBS and c.MaKhoa = b.MaKhoa inner join NAMDINH_QLBN.dbo.BENHNHAN_CHITIET  d on d.MaVaoVien = a.MaVaoVien inner join NAMDINH_QLBN.dbo.BENHNHAN E ON e.MaBenhNhan = d.MaBenhNhan where c.MaKhoa = '{0}' and c.MaBS = '{1}' and ThoiGianKT between '{2:dd/MM/yyyy HH:mm}' and '{3:dd/MM/yyyy HH:mm}' order by ThoiGianKT", cmbKhoa.SelectedValue, cmbBacSy.SelectedValue,timeBatDau,timeKetThuc);
            //dr = SQLCmd.ExecuteReader();
            // while (dr.Read())
            //{
            //    fg.AddItem(string.Format("{0}|{1}|{2}|{3}", fg.Rows.Count, dr["HoTen"], dr["TgBatDau"], dr["TgKetThuc"]));
            //}
            //dr.Close();
            //SQLCmd.Dispose();
        }

        private void cmbKhoa_TextChanged(object sender, EventArgs e)
        {
            if (cmbKhoa.Tag.ToString() == "0" || cmbKhoa.SelectedIndex == -1) return;
            Load_BacSy(GlobalModuls.Global.GetCode(cmbKhoa));
        }
	}
}
