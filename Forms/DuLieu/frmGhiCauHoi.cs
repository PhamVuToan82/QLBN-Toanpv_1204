using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace NamDinh_QLBN.Forms.DuLieu
{
	/// <summary>
	/// Summary description for frmGhiCauHoi.
	/// </summary>
	public class frmGhiCauHoi : System.Windows.Forms.Form
	{		
		private string DKAo ="";
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lblND;
		private System.Windows.Forms.TextBox txtMota;
		private DevExpress.XtraEditors.SimpleButton simpleButton1;
		private DevExpress.XtraEditors.SimpleButton simpleButton2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		public byte iTableName;

		public frmGhiCauHoi(string _DKAo,string HienThi)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lblND.Text = HienThi;
			DKAo = _DKAo;			
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmGhiCauHoi));
			this.label1 = new System.Windows.Forms.Label();
			this.txtMota = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.lblND = new System.Windows.Forms.Label();
			this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(6, 6);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(45, 15);
			this.label1.TabIndex = 0;
			this.label1.Text = "Mô tả";
			// 
			// txtMota
			// 
			this.txtMota.Location = new System.Drawing.Point(48, 3);
			this.txtMota.Name = "txtMota";
			this.txtMota.Size = new System.Drawing.Size(300, 20);
			this.txtMota.TabIndex = 1;
			this.txtMota.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(3, 30);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(75, 18);
			this.label2.TabIndex = 2;
			this.label2.Text = "Nội dung";
			// 
			// lblND
			// 
			this.lblND.BackColor = System.Drawing.Color.White;
			this.lblND.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblND.Location = new System.Drawing.Point(3, 48);
			this.lblND.Name = "lblND";
			this.lblND.Size = new System.Drawing.Size(345, 111);
			this.lblND.TabIndex = 3;
			// 
			// simpleButton1
			// 
			this.simpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.simpleButton1.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.Image")));
			this.simpleButton1.Location = new System.Drawing.Point(243, 162);
			this.simpleButton1.Name = "simpleButton1";
			this.simpleButton1.Size = new System.Drawing.Size(105, 28);
			this.simpleButton1.TabIndex = 52;
			this.simpleButton1.Text = "Thoát";
			this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
			// 
			// simpleButton2
			// 
			this.simpleButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.simpleButton2.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton2.Image")));
			this.simpleButton2.Location = new System.Drawing.Point(135, 162);
			this.simpleButton2.Name = "simpleButton2";
			this.simpleButton2.Size = new System.Drawing.Size(105, 28);
			this.simpleButton2.TabIndex = 53;
			this.simpleButton2.Text = "Ghi câu hỏi";
			this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
			// 
			// frmGhiCauHoi
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(352, 192);
			this.Controls.Add(this.simpleButton2);
			this.Controls.Add(this.simpleButton1);
			this.Controls.Add(this.lblND);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtMota);
			this.Controls.Add(this.label1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmGhiCauHoi";
			this.Text = "Ghi lại câu hỏi tìm kiếm";
			this.ResumeLayout(false);

		}
		#endregion

		private void cmdThoat_Click(object sender, System.EventArgs e)
		{
			this.Dispose();
		}

		private void simpleButton1_Click(object sender, System.EventArgs e)
		{
			this.Dispose();
		}

		private void simpleButton2_Click(object sender, System.EventArgs e)
		{
			string strSQL;
			System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
			cmd.Connection = GlobalModuls.Global.ConnectSQL;
			strSQL = "INSERT INTO tblCAUHOI (MoTa,DKAo,TableName) VALUES (N'" + txtMota.Text.Replace("'","") + "',";
			strSQL += "N'" + DKAo.Replace("'","") + "'," + iTableName + ")";
			cmd.CommandText = strSQL;
			cmd.ExecuteNonQuery();
			cmd.Dispose();
			MessageBox.Show("Đã lưu câu hỏi tìm kiếm vào CSDL","Thông báo",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
		}
	}
}
