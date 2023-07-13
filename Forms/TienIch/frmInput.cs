using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace NamDinh_QLBN.Forms
{
	/// <summary>
	/// Summary description for frmInput.
	/// </summary>
	public class frmInput : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtInPut;

		public string TextReturn;
		public string Mes;
		public string defaultValue;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmInput()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmInput));
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtInPut = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// button2
			// 
			this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
			this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button2.Location = new System.Drawing.Point(218, 60);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(69, 27);
			this.button2.TabIndex = 1;
			this.button2.Text = "  Chọn";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
			this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button1.Location = new System.Drawing.Point(290, 60);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(69, 27);
			this.button1.TabIndex = 2;
			this.button1.Text = " Thoát";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(2, 2);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(20, 18);
			this.pictureBox1.TabIndex = 5;
			this.pictureBox1.TabStop = false;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(24, 2);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(332, 18);
			this.label1.TabIndex = 6;
			this.label1.Text = "label1";
			// 
			// txtInPut
			// 
			this.txtInPut.Location = new System.Drawing.Point(16, 28);
			this.txtInPut.Name = "txtInPut";
			this.txtInPut.Size = new System.Drawing.Size(332, 21);
			this.txtInPut.TabIndex = 0;
			this.txtInPut.Text = "";
			// 
			// frmInput
			// 
			this.AcceptButton = this.button2;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.CancelButton = this.button1;
			this.ClientSize = new System.Drawing.Size(360, 87);
			this.ControlBox = false;
			this.Controls.Add(this.txtInPut);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "frmInput";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frmInput";
			this.Load += new System.EventHandler(this.frmInput_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void button2_Click(object sender, System.EventArgs e)
		{
			TextReturn=txtInPut.Text;			
			this.Dispose();
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			TextReturn="";		
			this.Dispose();
		}

		private void frmInput_Load(object sender, System.EventArgs e)
		{
			label1.Text=Mes;
			txtInPut.Text=defaultValue;
		}
	}
}
