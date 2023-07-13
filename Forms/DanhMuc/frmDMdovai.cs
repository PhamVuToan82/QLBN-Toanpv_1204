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
	public class frmDMdovai : System.Windows.Forms.Form
    {
		private C1.Win.C1FlexGrid.C1FlexGrid fg;
		private System.Windows.Forms.Button cmdOK;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtMa;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button cmdXoa;
		private System.Windows.Forms.Button cmdThem;
		private System.Windows.Forms.Button cmdCancel;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button cmdSua;
        private Label lblKhoa;
        internal C1.Win.C1List.C1Combo cmbLoaiDoVai;
        private TextBox txtTen;
        private Label label5;
        private TextBox txtThutu;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public frmDMdovai()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDMdovai));
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
            this.txtThutu = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMa = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblKhoa = new System.Windows.Forms.Label();
            this.cmbLoaiDoVai = new C1.Win.C1List.C1Combo();
            this.cmdXoa = new System.Windows.Forms.Button();
            this.cmdThem = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cmdSua = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.fg)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLoaiDoVai)).BeginInit();
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
            this.fg.Location = new System.Drawing.Point(2, 106);
            this.fg.Name = "fg";
            this.fg.Rows.Count = 1;
            this.fg.Rows.MinSize = 20;
            this.fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
            this.fg.ShowCursor = true;
            this.fg.Size = new System.Drawing.Size(492, 399);
            this.fg.Styles = new C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("fg.Styles"));
            this.fg.TabIndex = 69;
            this.fg.AfterSelChange += new C1.Win.C1FlexGrid.RangeEventHandler(this.fg_AfterSelChange);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtThutu);
            this.groupBox1.Controls.Add(this.label5);
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
            // txtThutu
            // 
            this.txtThutu.Location = new System.Drawing.Point(69, 55);
            this.txtThutu.MaxLength = 3;
            this.txtThutu.Name = "txtThutu";
            this.txtThutu.Size = new System.Drawing.Size(169, 20);
            this.txtThutu.TabIndex = 121;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(3, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 18);
            this.label5.TabIndex = 120;
            this.label5.Text = "Ghi chú";
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(68, 33);
            this.txtTen.MaxLength = 50;
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(420, 20);
            this.txtTen.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(5, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tên Vải";
            // 
            // txtMa
            // 
            this.txtMa.Location = new System.Drawing.Point(68, 12);
            this.txtMa.MaxLength = 2;
            this.txtMa.Name = "txtMa";
            this.txtMa.Size = new System.Drawing.Size(169, 20);
            this.txtMa.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(5, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã Vải";
            // 
            // lblKhoa
            // 
            this.lblKhoa.Location = new System.Drawing.Point(6, 8);
            this.lblKhoa.Name = "lblKhoa";
            this.lblKhoa.Size = new System.Drawing.Size(46, 18);
            this.lblKhoa.TabIndex = 77;
            this.lblKhoa.Text = "Loại Vải";
            // 
            // cmbLoaiDoVai
            // 
            this.cmbLoaiDoVai.AddItemSeparator = ';';
            this.cmbLoaiDoVai.AllowColMove = false;
            this.cmbLoaiDoVai.AllowRowSizing = C1.Win.C1List.RowSizingEnum.AllRows;
            this.cmbLoaiDoVai.AutoCompletion = true;
            this.cmbLoaiDoVai.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cmbLoaiDoVai.Caption = "";
            this.cmbLoaiDoVai.CaptionHeight = 17;
            this.cmbLoaiDoVai.CaptionStyle = style9;
            this.cmbLoaiDoVai.CaptionVisible = false;
            this.cmbLoaiDoVai.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cmbLoaiDoVai.ColumnCaptionHeight = 17;
            this.cmbLoaiDoVai.ColumnFooterHeight = 17;
            this.cmbLoaiDoVai.ColumnHeaders = false;
            this.cmbLoaiDoVai.ContentHeight = 16;
            this.cmbLoaiDoVai.DataMode = C1.Win.C1List.DataModeEnum.AddItem;
            this.cmbLoaiDoVai.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cmbLoaiDoVai.DefColWidth = 30;
            this.cmbLoaiDoVai.DisplayMember = "Danh mục";
            this.cmbLoaiDoVai.EditorBackColor = System.Drawing.Color.White;
            this.cmbLoaiDoVai.EditorFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLoaiDoVai.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbLoaiDoVai.EditorHeight = 16;
            this.cmbLoaiDoVai.EvenRowStyle = style10;
            this.cmbLoaiDoVai.ExtendRightColumn = true;
            this.cmbLoaiDoVai.FlatStyle = C1.Win.C1List.FlatModeEnum.Popup;
            this.cmbLoaiDoVai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLoaiDoVai.FooterStyle = style11;
            this.cmbLoaiDoVai.GapHeight = 2;
            this.cmbLoaiDoVai.HeadingStyle = style12;
            this.cmbLoaiDoVai.HighLightRowStyle = style13;
            this.cmbLoaiDoVai.ItemHeight = 15;
            this.cmbLoaiDoVai.Location = new System.Drawing.Point(70, 6);
            this.cmbLoaiDoVai.MatchCol = C1.Win.C1List.MatchColEnum.AllCols;
            this.cmbLoaiDoVai.MatchEntryTimeout = ((long)(2000));
            this.cmbLoaiDoVai.MaxDropDownItems = ((short)(10));
            this.cmbLoaiDoVai.MaxLength = 32767;
            this.cmbLoaiDoVai.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cmbLoaiDoVai.Name = "cmbLoaiDoVai";
            this.cmbLoaiDoVai.OddRowStyle = style14;
            this.cmbLoaiDoVai.PartialRightColumn = false;
            this.cmbLoaiDoVai.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.cmbLoaiDoVai.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.cmbLoaiDoVai.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cmbLoaiDoVai.SelectedStyle = style15;
            this.cmbLoaiDoVai.Size = new System.Drawing.Size(420, 20);
            this.cmbLoaiDoVai.Style = style16;
            this.cmbLoaiDoVai.TabIndex = 118;
            this.cmbLoaiDoVai.TextChanged += new System.EventHandler(this.cmbLoaiDoVai_TextChanged);
            this.cmbLoaiDoVai.PropBag = resources.GetString("cmbLoaiDoVai.PropBag");
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
            // frmDMdovai
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(499, 543);
            this.Controls.Add(this.cmbLoaiDoVai);
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
            this.Name = "frmDMdovai";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh mục đồ vải";
            this.Load += new System.EventHandler(this.frmDMdovai_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fg)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLoaiDoVai)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void Load_DM()
		{
			System.Data.SqlClient.SqlDataReader dr;
			System.Data.SqlClient.SqlCommand SQLCmd= new System.Data.SqlClient.SqlCommand();
			SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            SQLCmd.CommandText = "SELECT * FROM tblDMLoaiDoVai ";
            dr = SQLCmd.ExecuteReader();
            cmbLoaiDoVai.Tag = "0";
            cmbLoaiDoVai.ClearItems();
            while (dr.Read())
            {
                cmbLoaiDoVai.AddItem(string.Format("{0};{1}", dr["MaLoaiDoVai"], dr["TenLoaiDoVai"]));
            }
            dr.Close();
            SQLCmd.Dispose();
            cmbLoaiDoVai.SelectedIndex = -1;
            cmbLoaiDoVai.Tag = "1";
            if (cmbLoaiDoVai.ListCount > 0) cmbLoaiDoVai.SelectedIndex = 0;
            dr.Close();
            SQLCmd.Dispose();
		}
        private void Load_frmDMdovai(string MaLoaiDoVai)
        {
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;            
            SQLCmd.CommandText = string.Format("SELECT * FROM tblDoVai WHERE MaLoaiDoVai='{0}' order by MaLoaiDoVai", MaLoaiDoVai);
            dr = SQLCmd.ExecuteReader();
            fg.Tag = "0";
            fg.Rows.Count = 1;
            while (dr.Read())
            {
                fg.AddItem(string.Format("{0}|{1}|{2}|{3}|{4}|", fg.Rows.Count, dr["MaDoVai"], dr["TenDoVai"], dr["GhiChu"], dr["MaLoaiDoVai"]));
            }
            dr.Close();
            SQLCmd.Dispose();
            fg.Tag = "1";
            Clear_Data();
        }
        private void Clear_Data()
        {
            txtMa.Text = txtTen.Text;
        }
		private void LockEdit(bool IsLock)
		{
            txtMa.ReadOnly = IsLock;
			txtTen.ReadOnly = IsLock;
            txtThutu.ReadOnly = IsLock;
			fg.Enabled = IsLock;
			cmdThem.Visible = IsLock;
			cmdSua.Visible=IsLock;
			cmdXoa.Visible=IsLock;
			button1.Visible = IsLock;			
			cmdOK.Visible =!IsLock;
			cmdCancel.Visible = !IsLock;
		}
		
		private void cmdOK_Click(object sender, System.EventArgs e)
		{
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
                cmd.CommandText = string.Format("UPDATE tblDoVai SET TenDoVai =N'{1}',GhiChu =N'{2}',MaLoaiDoVai='{3}' WHERE MaDoVai='{0}'", txtMa.Text, txtTen.Text, txtThutu.Text, GlobalModuls.Global.GetCode(cmbLoaiDoVai));
			}
			else
			{
				cmd.CommandText =string.Format("SELECT * FROM tblDoVai WHERE TenDoVai=N'{0}' AND MaDoVai='{1}'", txtTen.Text,GlobalModuls.Global.GetCode(cmbLoaiDoVai));
				dr=cmd.ExecuteReader();
				if (dr.HasRows)
				{
					dr.Close();
					MessageBox.Show("Tên đã có trong danh mục, đề nghị kiểm tra lại!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
					cmd.Dispose();
					return;
				}
				dr.Close();
                cmd.CommandText = string.Format("INSERT INTO tblDoVai (MaDoVai,TenDoVai,GhiChu,MaLoaiDoVai) VALUES ('{0}',N'{1}',N'{2}',N'{3}')", txtMa.Text, txtTen.Text, txtThutu.Text, GlobalModuls.Global.GetCode(cmbLoaiDoVai));
			}
			try
			{
				cmd.ExecuteNonQuery();
				if (txtMa.ReadOnly)
				{
                    fg[fg.Row,2] = txtTen.Text;
                    fg[fg.Row, 3] = txtThutu.Text;
                    fg[fg.Row, 4] = GlobalModuls.Global.GetCode(cmbLoaiDoVai);
                }
				else
				{
                    fg.AddItem(string.Format("{0}|{1}|{2}|{3}|{4}|", fg.Rows.Count, txtMa.Text, txtTen.Text, txtThutu.Text, GlobalModuls.Global.GetCode(cmbLoaiDoVai)));
				}
				LockEdit(true);
                if (cmbLoaiDoVai.Tag.ToString() == "0" || cmbLoaiDoVai.SelectedIndex == -1) return;
                Load_frmDMdovai(GlobalModuls.Global.GetCode(cmbLoaiDoVai));
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
                txtThutu.Text = fg[fg.Row, 3].ToString();
                GlobalModuls.Global.SetCmb(cmbLoaiDoVai, fg[fg.Row, "MaLoaiDoVai"].ToString());
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
                txtThutu.Text = fg[fg.Row, 3].ToString();
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
            txtThutu.Text = "";
			txtTen.Focus();
		}

		private void frmDMdovai_Load(object sender, System.EventArgs e)
		{
			fg.ClipSeparators ="|;";
            Load_DM();
			LockEdit(true);
		}

        private void cmbLoaiDoVai_TextChanged(object sender, EventArgs e)
        {
            if (cmbLoaiDoVai.Tag.ToString()=="0" || cmbLoaiDoVai.SelectedIndex==-1) return;
            Load_frmDMdovai(GlobalModuls.Global.GetCode(cmbLoaiDoVai));
        }

        private void cmdXoa_Click(object sender, EventArgs e)
        {
            if (txtMa.Text == "") return;
            if (MessageBox.Show("Bạn có chắc muốn xóa bác sỹ trong danh mục không?","Xác nhận xóa",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.No) return;
        }
	}
}
