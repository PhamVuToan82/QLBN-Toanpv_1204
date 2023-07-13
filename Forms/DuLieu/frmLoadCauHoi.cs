using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using GlobalModuls;

namespace NamDinh_QLBN.Forms.DuLieu
{
	/// <summary>
	/// Summary description for frmLoadCauHoi.
	/// </summary>
	public class frmLoadCauHoi : System.Windows.Forms.Form
	{
		private C1.Win.C1FlexGrid.C1FlexGrid fg;
		private DevExpress.XtraEditors.SimpleButton cmdThoat;
		private DevExpress.XtraEditors.SimpleButton simpleButton1;
		private DevExpress.XtraEditors.SimpleButton simpleButton2;
		public string DK_Loaded="";
		public int iTableName = 1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmLoadCauHoi()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmLoadCauHoi));
			this.fg = new C1.Win.C1FlexGrid.C1FlexGrid();
			this.cmdThoat = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
			((System.ComponentModel.ISupportInitialize)(this.fg)).BeginInit();
			this.SuspendLayout();
			// 
			// fg
			// 
			this.fg.ColumnInfo = "5,1,0,0,0,85,Columns:0{Width:35;Caption:\"STT\";}\t1{Caption:\"Mô tả\";}\t2{Caption:\"ID" +
				"\";}\t3{Caption:\"DK\";}\t";
			this.fg.ExtendLastCol = true;
			this.fg.Location = new System.Drawing.Point(3, 3);
			this.fg.Name = "fg";
			this.fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
			this.fg.Size = new System.Drawing.Size(270, 336);
			this.fg.Styles = new C1.Win.C1FlexGrid.CellStyleCollection(@"Normal{Font:Microsoft Sans Serif, 8.25pt;}	Fixed{BackColor:Control;ForeColor:ControlText;Border:Flat,1,ControlDark,Both;}	Highlight{BackColor:Highlight;ForeColor:HighlightText;}	Search{BackColor:Highlight;ForeColor:HighlightText;}	Frozen{BackColor:Beige;}	EmptyArea{BackColor:AppWorkspace;Border:Flat,1,ControlDarkDark,Both;}	GrandTotal{BackColor:Black;ForeColor:White;}	Subtotal0{BackColor:ControlDarkDark;ForeColor:White;}	Subtotal1{BackColor:ControlDarkDark;ForeColor:White;}	Subtotal2{BackColor:ControlDarkDark;ForeColor:White;}	Subtotal3{BackColor:ControlDarkDark;ForeColor:White;}	Subtotal4{BackColor:ControlDarkDark;ForeColor:White;}	Subtotal5{BackColor:ControlDarkDark;ForeColor:White;}	");
			this.fg.TabIndex = 0;
			this.fg.AfterEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.fg_AfterEdit);
			// 
			// cmdThoat
			// 
			this.cmdThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdThoat.Image = ((System.Drawing.Image)(resources.GetObject("cmdThoat.Image")));
			this.cmdThoat.Location = new System.Drawing.Point(192, 342);
			this.cmdThoat.Name = "cmdThoat";
			this.cmdThoat.Size = new System.Drawing.Size(78, 28);
			this.cmdThoat.TabIndex = 51;
			this.cmdThoat.Text = "Thoát";
			this.cmdThoat.Click += new System.EventHandler(this.cmdThoat_Click);
			// 
			// simpleButton1
			// 
			this.simpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.simpleButton1.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.Image")));
			this.simpleButton1.Location = new System.Drawing.Point(111, 342);
			this.simpleButton1.Name = "simpleButton1";
			this.simpleButton1.Size = new System.Drawing.Size(78, 28);
			this.simpleButton1.TabIndex = 52;
			this.simpleButton1.Text = "Chọn";
			this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
			// 
			// simpleButton2
			// 
			this.simpleButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.simpleButton2.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton2.Image")));
			this.simpleButton2.Location = new System.Drawing.Point(3, 342);
			this.simpleButton2.Name = "simpleButton2";
			this.simpleButton2.Size = new System.Drawing.Size(78, 28);
			this.simpleButton2.TabIndex = 53;
			this.simpleButton2.Text = "Xóa";
			this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
			// 
			// frmLoadCauHoi
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(274, 372);
			this.Controls.Add(this.simpleButton2);
			this.Controls.Add(this.simpleButton1);
			this.Controls.Add(this.cmdThoat);
			this.Controls.Add(this.fg);
			this.Name = "frmLoadCauHoi";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Mở các câu hỏi tìm kiếm đã lưu";
			this.Load += new System.EventHandler(this.frmLoadCauHoi_Load);
			((System.ComponentModel.ISupportInitialize)(this.fg)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void frmLoadCauHoi_Load(object sender, System.EventArgs e)
		{
			System.Data.SqlClient.SqlDataReader dr;
			System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("SELECT Mota,ID,DKAo,TableName FROM tblCAUHOI ORDER BY [ID]",Global.ConnectSQL);
			dr = cmd.ExecuteReader();
			fg.Rows.Count=1;
			fg.ClipSeparators ="#;";
			while (dr.Read())
			{
				fg.AddItem(string.Format("{0}#{1}#{2}#{3}#{4}",fg.Rows.Count,dr.GetValue(0),dr.GetValue(1),dr.GetValue(2),dr.GetValue(3)));
				fg.Rows[fg.Rows.Count-1].UserData = dr.GetValue(2);
			}
			dr.Close();
			cmd.Dispose();
			fg.Cols[2].Visible=false;
			fg.Cols[3].Visible=false;
			fg.Cols[4].Visible=false;
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			this.Dispose();
		}

		private void cmdOK_Click(object sender, System.EventArgs e)
		{
			if (fg.Row<1) {return;}			
			NamDinh_QLBN.Forms.DuLieu.frmTimKiem fr = new frmTimKiem(fg.Rows[fg.Row].UserData.ToString());
			fr.Show();
			this.Dispose();
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			if (fg.Row<1) {return;}
			System.Windows.Forms.DialogResult rs = 
			MessageBox.Show("Bạn có chắc muốn xóa câu hỏi này không?","Xác nhận xóa",
				System.Windows.Forms.MessageBoxButtons.YesNo,
				System.Windows.Forms.MessageBoxIcon.Question);
			if (rs == System.Windows.Forms.DialogResult.No) {return;}
			System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("DELETE FROM tblCAUHOI WHERE ID=" + fg.GetDataDisplay(fg.Row,2),Global.ConnectSQL);
			cmd.ExecuteNonQuery();
			cmd.Dispose();
			fg.RemoveItem(fg.Row);
		}

		private void fg_AfterEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
		{
			System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("UPDATE tblCAUHOI SET MoTa = N'" + fg.GetDataDisplay(fg.Row,1).Replace("'","") + "' WHERE ID=" + fg.GetDataDisplay(fg.Row,2),Global.ConnectSQL);
			cmd.ExecuteNonQuery();
			cmd.Dispose();			
		}

		private void cmdThoat_Click(object sender, System.EventArgs e)
		{
			this.Dispose();
		}

		private void simpleButton1_Click(object sender, System.EventArgs e)
		{
			if (fg.Row<1) {return;}			
			DK_Loaded=fg.Rows[fg.Row].UserData.ToString();
			iTableName = System.Convert.ToInt16(fg.GetDataDisplay(fg.Row,4));
//			FDI.Forms.DuAn.frmTimKiem fr = new frmTimKiem(fg.Rows[fg.Row].UserData.ToString());
//			fr.Show();
			this.Dispose();
		}

		private void simpleButton2_Click(object sender, System.EventArgs e)
		{
			if (fg.Row<1) {return;}
			System.Windows.Forms.DialogResult rs = 
				MessageBox.Show("Bạn có chắc muốn xóa câu hỏi này không?","Xác nhận xóa",
				System.Windows.Forms.MessageBoxButtons.YesNo,
				System.Windows.Forms.MessageBoxIcon.Question);
			if (rs == System.Windows.Forms.DialogResult.No) {return;}
			System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("DELETE FROM tblCAUHOI WHERE ID=" + fg.GetDataDisplay(fg.Row,2),Global.ConnectSQL);
			cmd.ExecuteNonQuery();
			cmd.Dispose();
			fg.RemoveItem(fg.Row);
		}
	}
}
