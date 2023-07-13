using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using GlobalModuls;




namespace NamDinh_QLBN.Forms.HeThong
{
	/// <summary>
	/// Summary description for frmChangePass.
	/// </summary>
	public class frmChangePass : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button cmdOK;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblUName;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtOldPass;
		private System.Windows.Forms.TextBox txtNewPass;
		private System.Windows.Forms.Label label3;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmChangePass()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChangePass));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtNewPass = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtOldPass = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblUName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.txtNewPass);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtOldPass);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblUName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(262, 102);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // txtNewPass
            // 
            this.txtNewPass.Location = new System.Drawing.Point(98, 68);
            this.txtNewPass.Name = "txtNewPass";
            this.txtNewPass.PasswordChar = '*';
            this.txtNewPass.Size = new System.Drawing.Size(152, 21);
            this.txtNewPass.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(10, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Mật khẩu mới";
            // 
            // txtOldPass
            // 
            this.txtOldPass.Location = new System.Drawing.Point(98, 44);
            this.txtOldPass.Name = "txtOldPass";
            this.txtOldPass.PasswordChar = '*';
            this.txtOldPass.Size = new System.Drawing.Size(152, 21);
            this.txtOldPass.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(10, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mật khẩu cũ";
            // 
            // lblUName
            // 
            this.lblUName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblUName.Location = new System.Drawing.Point(98, 20);
            this.lblUName.Name = "lblUName";
            this.lblUName.Size = new System.Drawing.Size(152, 18);
            this.lblUName.TabIndex = 1;
            this.lblUName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(10, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên đăng ký";
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(182, 108);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(81, 27);
            this.button1.TabIndex = 47;
            this.button1.Text = "   Thoát";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmdOK
            // 
            this.cmdOK.Image = ((System.Drawing.Image)(resources.GetObject("cmdOK.Image")));
            this.cmdOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdOK.Location = new System.Drawing.Point(98, 108);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(81, 27);
            this.cmdOK.TabIndex = 46;
            this.cmdOK.Text = "    Chấp nhận";
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // frmChangePass
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
            this.ClientSize = new System.Drawing.Size(266, 137);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmChangePass";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thay đổi mật khẩu truy cập";
            this.Load += new System.EventHandler(this.frmChangePass_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		private void button1_Click(object sender, System.EventArgs e)
		{
			this.Dispose();
		}

		private void frmChangePass_Load(object sender, System.EventArgs e)
		{
			lblUName.Text = Global.glbUName;
		}

		private void cmdOK_Click(object sender, System.EventArgs e)
		{
			System.Data.SqlClient.SqlCommand Cmd = new System.Data.SqlClient.SqlCommand("SELECT UName,Pass FROM SYSUSER WHERE Uname='" + lblUName.Text + "'",Global.ConnectSQL);
			System.Data.SqlClient.SqlDataReader dr = Cmd.ExecuteReader();
			dr.Read();
			if (dr.GetValue(1).ToString() != GlobalModuls.HashMD5.getMd5Hash(txtOldPass.Text))
			{
				MessageBox.Show("Mật khẩu truy cập cũ không đúng!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
				dr.Close();
				Cmd.Dispose();
				return;
			}
			dr.Close();
			Cmd.CommandText = "UPDATE SYSUSER Set Pass ='" + GlobalModuls.HashMD5.getMd5Hash(txtNewPass.Text) + "' WHERE UName ='" + lblUName.Text + "'";
			Cmd.ExecuteNonQuery();
			Cmd.Dispose();
			MessageBox.Show("Thay đổi mật khẩu thành công, đừng bao giờ quên mật khẩu của bạn!");
			this.Dispose();
		}
	}
}
