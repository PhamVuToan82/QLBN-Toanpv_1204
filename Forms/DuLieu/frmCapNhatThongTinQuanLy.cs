using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace NamDinh_QLBN.Forms.DuLieu
{
	/// <summary>
	/// Summary description for frmcapjNhatThongTinQuanLy.
	/// </summary>
	public class frmCapNhatThongTinQuanLy : System.Windows.Forms.Form
	{
		private C1.Win.C1Input.C1DateEdit txtNgayThayDoi;
		private System.Windows.Forms.Label lblNgayThayDoi;
		private System.Windows.Forms.Label lblHoTen;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label lblMaVaoVien;
		private System.Windows.Forms.Label label1;
		internal C1.Win.C1List.C1Combo cmbNDThayDoi;
		private System.Windows.Forms.Label lblNDThayDoi;
		        
		private byte LoaiThayDoi=0;
		private string MaCu="";
		private byte LanThayDoi=0;
		private DevExpress.XtraEditors.SimpleButton cmdThoat;
        private DevExpress.XtraEditors.SimpleButton cmdGhi;
        private Panel panel1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmCapNhatThongTinQuanLy(string MaVaoVien,string _HoTen,byte _LoaiTD,string _MaCu,string _LanThayDoi)
		{
			//LoaiTD=1: Thay doi doi tuong
			//LoaiTD=2: Thay doi khoa
			//LoaiTD=3: Yeu cau phau thuat
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			LoaiThayDoi =_LoaiTD;
			
			MaCu = _MaCu;
			lblHoTen.Text = _HoTen;
			lblMaVaoVien.Text =MaVaoVien;			
            
			LanThayDoi =byte.Parse(_LanThayDoi);
			
			LanThayDoi +=1;
			switch (LoaiThayDoi)
			{
				case 1:
					this.Text = "Cập nhật thay đổi đối tượng bệnh nhân";
					lblNgayThayDoi.Text = "Ngày thay đổi";
					lblNDThayDoi.Text="Đối tượng";
					break;
				case 2:
					this.Text = "Cập nhật thay đổi Khoa điều trị";
					lblNgayThayDoi.Text = "Ngày thay đổi";
					lblNDThayDoi.Text="Khoa điều trị";
					break;
				case 3:
					this.Text = "Cập nhật yêu cầu phẫu thuật";
					lblNgayThayDoi.Text = "Ngày phẫu thuật";
					lblNDThayDoi.Text="Yêu cầu phẫu thuật";
					break;
			}
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCapNhatThongTinQuanLy));
            C1.Win.C1List.Style style2 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style3 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style4 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style5 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style6 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style7 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style8 = new C1.Win.C1List.Style();
            this.txtNgayThayDoi = new C1.Win.C1Input.C1DateEdit();
            this.lblNgayThayDoi = new System.Windows.Forms.Label();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblMaVaoVien = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbNDThayDoi = new C1.Win.C1List.C1Combo();
            this.lblNDThayDoi = new System.Windows.Forms.Label();
            this.cmdThoat = new DevExpress.XtraEditors.SimpleButton();
            this.cmdGhi = new DevExpress.XtraEditors.SimpleButton();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.txtNgayThayDoi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbNDThayDoi)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNgayThayDoi
            // 
            this.txtNgayThayDoi.Culture = 1066;
            this.txtNgayThayDoi.CustomFormat = "dd/MM/yyyy HH:mm";
            this.txtNgayThayDoi.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
            this.txtNgayThayDoi.Location = new System.Drawing.Point(117, 73);
            this.txtNgayThayDoi.Name = "txtNgayThayDoi";
            this.txtNgayThayDoi.Size = new System.Drawing.Size(130, 20);
            this.txtNgayThayDoi.TabIndex = 89;
            this.txtNgayThayDoi.Tag = null;
            // 
            // lblNgayThayDoi
            // 
            this.lblNgayThayDoi.Location = new System.Drawing.Point(9, 76);
            this.lblNgayThayDoi.Name = "lblNgayThayDoi";
            this.lblNgayThayDoi.Size = new System.Drawing.Size(105, 15);
            this.lblNgayThayDoi.TabIndex = 88;
            this.lblNgayThayDoi.Text = "Ngày vào viện";
            this.lblNgayThayDoi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblHoTen
            // 
            this.lblHoTen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblHoTen.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblHoTen.Location = new System.Drawing.Point(114, 28);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(210, 18);
            this.lblHoTen.TabIndex = 114;
            this.lblHoTen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(6, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 18);
            this.label3.TabIndex = 113;
            this.label3.Text = "Họ và tên BN";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMaVaoVien
            // 
            this.lblMaVaoVien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblMaVaoVien.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMaVaoVien.Location = new System.Drawing.Point(114, 7);
            this.lblMaVaoVien.Name = "lblMaVaoVien";
            this.lblMaVaoVien.Size = new System.Drawing.Size(81, 18);
            this.lblMaVaoVien.TabIndex = 112;
            this.lblMaVaoVien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(6, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 18);
            this.label1.TabIndex = 111;
            this.label1.Text = "Mã vào viện";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbNDThayDoi
            // 
            this.cmbNDThayDoi.AddItemSeparator = ';';
            this.cmbNDThayDoi.AllowColMove = false;
            this.cmbNDThayDoi.AllowRowSizing = C1.Win.C1List.RowSizingEnum.AllRows;
            this.cmbNDThayDoi.AutoCompletion = true;
            this.cmbNDThayDoi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cmbNDThayDoi.Caption = "";
            this.cmbNDThayDoi.CaptionHeight = 17;
            this.cmbNDThayDoi.CaptionStyle = style1;
            this.cmbNDThayDoi.CaptionVisible = false;
            this.cmbNDThayDoi.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cmbNDThayDoi.ColumnCaptionHeight = 17;
            this.cmbNDThayDoi.ColumnFooterHeight = 17;
            this.cmbNDThayDoi.ColumnHeaders = false;
            this.cmbNDThayDoi.ContentHeight = 16;
            this.cmbNDThayDoi.DataMode = C1.Win.C1List.DataModeEnum.AddItem;
            this.cmbNDThayDoi.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cmbNDThayDoi.DefColWidth = 30;
            this.cmbNDThayDoi.DisplayMember = "Danh mục";
            this.cmbNDThayDoi.EditorBackColor = System.Drawing.Color.White;
            this.cmbNDThayDoi.EditorFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbNDThayDoi.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbNDThayDoi.EditorHeight = 16;
            this.cmbNDThayDoi.EvenRowStyle = style2;
            this.cmbNDThayDoi.ExtendRightColumn = true;
            this.cmbNDThayDoi.FlatStyle = C1.Win.C1List.FlatModeEnum.Popup;
            this.cmbNDThayDoi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbNDThayDoi.FooterStyle = style3;
            this.cmbNDThayDoi.GapHeight = 2;
            this.cmbNDThayDoi.HeadingStyle = style4;
            this.cmbNDThayDoi.HighLightRowStyle = style5;
            this.cmbNDThayDoi.ItemHeight = 15;
            this.cmbNDThayDoi.Location = new System.Drawing.Point(117, 97);
            this.cmbNDThayDoi.MatchCol = C1.Win.C1List.MatchColEnum.AllCols;
            this.cmbNDThayDoi.MatchEntryTimeout = ((long)(2000));
            this.cmbNDThayDoi.MaxDropDownItems = ((short)(10));
            this.cmbNDThayDoi.MaxLength = 32767;
            this.cmbNDThayDoi.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cmbNDThayDoi.Name = "cmbNDThayDoi";
            this.cmbNDThayDoi.OddRowStyle = style6;
            this.cmbNDThayDoi.PartialRightColumn = false;
            this.cmbNDThayDoi.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.cmbNDThayDoi.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.cmbNDThayDoi.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cmbNDThayDoi.SelectedStyle = style7;
            this.cmbNDThayDoi.Size = new System.Drawing.Size(279, 20);
            this.cmbNDThayDoi.Style = style8;
            this.cmbNDThayDoi.TabIndex = 116;
            this.cmbNDThayDoi.PropBag = resources.GetString("cmbNDThayDoi.PropBag");
            // 
            // lblNDThayDoi
            // 
            this.lblNDThayDoi.Location = new System.Drawing.Point(9, 100);
            this.lblNDThayDoi.Name = "lblNDThayDoi";
            this.lblNDThayDoi.Size = new System.Drawing.Size(105, 15);
            this.lblNDThayDoi.TabIndex = 115;
            this.lblNDThayDoi.Text = "Yêu cầu phẫu thuật";
            this.lblNDThayDoi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmdThoat
            // 
            this.cmdThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdThoat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdThoat.Image = ((System.Drawing.Image)(resources.GetObject("cmdThoat.Image")));
            this.cmdThoat.Location = new System.Drawing.Point(327, 123);
            this.cmdThoat.Name = "cmdThoat";
            this.cmdThoat.Size = new System.Drawing.Size(69, 27);
            this.cmdThoat.TabIndex = 118;
            this.cmdThoat.Text = "Thoát";
            this.cmdThoat.Click += new System.EventHandler(this.cmdThoat_Click);
            // 
            // cmdGhi
            // 
            this.cmdGhi.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdGhi.Image = ((System.Drawing.Image)(resources.GetObject("cmdGhi.Image")));
            this.cmdGhi.Location = new System.Drawing.Point(258, 123);
            this.cmdGhi.Name = "cmdGhi";
            this.cmdGhi.Size = new System.Drawing.Size(69, 27);
            this.cmdGhi.TabIndex = 117;
            this.cmdGhi.Text = "Ghi";
            this.cmdGhi.Click += new System.EventHandler(this.cmdGhi_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblMaVaoVien);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lblHoTen);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(393, 55);
            this.panel1.TabIndex = 119;
            // 
            // frmCapNhatThongTinQuanLy
            // 
            this.AcceptButton = this.cmdGhi;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.cmdThoat;
            this.ClientSize = new System.Drawing.Size(400, 153);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cmdThoat);
            this.Controls.Add(this.cmdGhi);
            this.Controls.Add(this.cmbNDThayDoi);
            this.Controls.Add(this.lblNDThayDoi);
            this.Controls.Add(this.txtNgayThayDoi);
            this.Controls.Add(this.lblNgayThayDoi);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCapNhatThongTinQuanLy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cập nhật thông tin";
            this.Load += new System.EventHandler(this.frmCapNhatThongTinQuanLy_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtNgayThayDoi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbNDThayDoi)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void frmCapNhatThongTinQuanLy_Load(object sender, System.EventArgs e)
		{
			System.Data.SqlClient.SqlCommand SQLCmd=new System.Data.SqlClient.SqlCommand();
			SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
			System.Data.SqlClient.SqlDataReader dr;
			switch (LoaiThayDoi)
			{
				case 1:
					SQLCmd.CommandText ="SELECT MaDT,TenDT FROM DMDOITUONGBN WHERE MaDT <>'" + MaCu + "' ORDER BY MaDT";
					break;
				case 2:
					SQLCmd.CommandText ="SELECT MaKhoa,TenKhoa FROM DMKHOAPHONG WHERE Is_KhoaDieuTri=1 AND MaKhoa <>'" + MaCu + "' ORDER BY MaKhoa";
					break;
				case 3:
					SQLCmd.CommandText ="SELECT MaPT,TenPT FROM DMPHAUTHUAT ORDER BY MaPT";
					break;
			}
			dr=SQLCmd.ExecuteReader();
			cmbNDThayDoi.ClearItems();
			while (dr.Read())
			{
				cmbNDThayDoi.AddItem(string.Format("{0};{1}",dr[0],dr[1]));
			}
			dr.Close();
			SQLCmd.Dispose();
            txtNgayThayDoi.Value = DateTime.Now;
		}

		private void cmdThoat_Click(object sender, System.EventArgs e)
		{
            this.DialogResult = DialogResult.Cancel;
            //this.Dispose();
		}

		private void cmdGhi_Click(object sender, System.EventArgs e)
		{
			if (txtNgayThayDoi.ValueIsDbNull)
			{
				MessageBox.Show("Chưa nhập ngày tháng, đề nghị nhập lại","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
				txtNgayThayDoi.Focus();
				return;
			}
			if (GlobalModuls.Global.GetCode(cmbNDThayDoi)==null)
			{
				MessageBox.Show("Chưa nhập nội dung thay đổi, đề nghị nhập lại","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
				cmbNDThayDoi.Focus();
				return;
			}
			
			string SQLStr="";
			switch(LoaiThayDoi)
			{
				case 1:
					SQLStr = string.Format("INSERT INTO BENHNHAN_DOITUONG (MaVaoVien,LanChuyenDT,Ngaychuyen,DoiTuong) VALUES ('{0}',{1},'{2:MM/dd/yyyy HH:mm}','{3}')",lblMaVaoVien.Text,LanThayDoi,txtNgayThayDoi.Value,GlobalModuls.Global.GetCode(cmbNDThayDoi));
					break;
				case 2:
                    SQLStr = string.Format("INSERT INTO BENHNHAN_KHOA (MaVaoVien,LanChuyenKhoa,Ngaychuyen,MaKhoa) VALUES ('{0}',{1},'{2:MM/dd/yyyy HH:mm}','{3}')", lblMaVaoVien.Text, LanThayDoi, txtNgayThayDoi.Value, GlobalModuls.Global.GetCode(cmbNDThayDoi));
					break;
				case 3:
                    SQLStr = string.Format("INSERT INTO BENHNHAN_PHAUTHUAT (MaBenhNhan,LanPT,NgayPhauThuat,PhauThuat,DaPhauThuat) VALUES ('{0}',{1},'{2:MM/dd/yyyy}','{3}',0)", lblMaVaoVien.Text, LanThayDoi, txtNgayThayDoi.Value, GlobalModuls.Global.GetCode(cmbNDThayDoi));
					break;
			}		
			System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand(SQLStr,GlobalModuls.Global.ConnectSQL);
            System.Data.SqlClient.SqlTransaction trn;// = new System.Data.SqlClient.SqlTransaction();
            trn = GlobalModuls.Global.ConnectSQL.BeginTransaction();
            SQLCmd.Transaction = trn;
			try
			{
				SQLCmd.ExecuteNonQuery();
                if (LoaiThayDoi == 2) //Chuyen Khoa --> Cap nhat Trang thai benh nhan = 2 --> Dang cho vao khoa khac
                {
                    SQLStr = string.Format("UPDATE BENHNHAN_CHITIET SET TrangThai = 2 WHERE MaVaoVien='{0}'",lblMaVaoVien.Text);
                    SQLCmd.CommandText = SQLStr;
                    SQLCmd.ExecuteNonQuery();
                }                
                trn.Commit();
				//MessageBox.Show("Đã cập nhật xong thông tin bệnh nhân","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);		
                this.DialogResult = DialogResult.OK;
			}
			catch (Exception ex)
			{
                trn.Rollback();
				MessageBox.Show("Có lỗi khi ghi dữ liệu\n" + ex.Message ,"Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);				
			}
			finally
			{
				SQLCmd.Dispose();
                trn.Dispose();
			}
		}
	}
}
