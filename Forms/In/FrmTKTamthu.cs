using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace NamDinh_QLBN.Forms.In
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class FrmTKTamthu : System.Windows.Forms.Form
	{		
		private System.Windows.Forms.Label label4;
		private DevExpress.XtraEditors.SimpleButton cmdIn;
		private DevExpress.XtraEditors.SimpleButton simpleButton2;
		private C1.Win.C1Input.C1DateEdit txttuNgay;
		private C1.Win.C1Input.C1DateEdit txtToingay;
		private System.Windows.Forms.Label label1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FrmTKTamthu()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FrmTKTamthu));
			this.txttuNgay = new C1.Win.C1Input.C1DateEdit();
			this.label4 = new System.Windows.Forms.Label();
			this.cmdIn = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
			this.txtToingay = new C1.Win.C1Input.C1DateEdit();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.txttuNgay)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtToingay)).BeginInit();
			this.SuspendLayout();
			// 
			// txttuNgay
			// 
			this.txttuNgay.Culture = 1066;
			this.txttuNgay.CustomFormat = "dd/MM/yyyy";
			this.txttuNgay.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
			this.txttuNgay.Location = new System.Drawing.Point(117, 12);
			this.txttuNgay.Name = "txttuNgay";
			this.txttuNgay.Size = new System.Drawing.Size(135, 20);
			this.txttuNgay.TabIndex = 119;
			this.txttuNgay.Tag = null;
			// 
			// label4
			// 
			this.label4.BackColor = System.Drawing.Color.Transparent;
			this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label4.Location = new System.Drawing.Point(18, 15);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(69, 18);
			this.label4.TabIndex = 118;
			this.label4.Text = "Từ ngày";
			this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// cmdIn
			// 
			this.cmdIn.Image = ((System.Drawing.Image)(resources.GetObject("cmdIn.Image")));
			this.cmdIn.Location = new System.Drawing.Point(321, 12);
			this.cmdIn.Name = "cmdIn";
			this.cmdIn.Size = new System.Drawing.Size(93, 27);
			this.cmdIn.TabIndex = 122;
			this.cmdIn.Text = "Tổng hợp";
			this.cmdIn.Click += new System.EventHandler(this.cmdIn_Click);
			// 
			// simpleButton2
			// 
			this.simpleButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.simpleButton2.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton2.Image")));
			this.simpleButton2.Location = new System.Drawing.Point(321, 42);
			this.simpleButton2.Name = "simpleButton2";
			this.simpleButton2.Size = new System.Drawing.Size(93, 27);
			this.simpleButton2.TabIndex = 123;
			this.simpleButton2.Text = "Thoát";
			this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
			// 
			// txtToingay
			// 
			this.txtToingay.Culture = 1066;
			this.txtToingay.CustomFormat = "dd/MM/yyyy";
			this.txtToingay.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
			this.txtToingay.Location = new System.Drawing.Point(117, 51);
			this.txtToingay.Name = "txtToingay";
			this.txtToingay.Size = new System.Drawing.Size(135, 20);
			this.txtToingay.TabIndex = 125;
			this.txtToingay.Tag = null;
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label1.Location = new System.Drawing.Point(18, 54);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(69, 18);
			this.label1.TabIndex = 124;
			this.label1.Text = "Đến ngày";
			this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// FrmTKTamthu
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(433, 77);
			this.Controls.Add(this.txtToingay);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.simpleButton2);
			this.Controls.Add(this.cmdIn);
			this.Controls.Add(this.txttuNgay);
			this.Controls.Add(this.label4);
			this.Name = "FrmTKTamthu";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Báo cáo tổng hợp tiền tạm thu";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.txttuNgay)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtToingay)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void simpleButton2_Click(object sender, System.EventArgs e)
		{
			this.Dispose();
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			this.txttuNgay.Value = GlobalModuls.Global.NgayLV;
			this.txtToingay.Value= GlobalModuls.Global.NgayLV;
															//			System.Data.SqlClient.SqlDataReader dr;
															//			System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
															//			SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
															//			CmbKhoa.Tag ="0";
															//			CmbKhoa.ClearItems();
															//			SQLCmd.CommandText = "SELECT * FROM DMKHOAPHONG WHERE MaKhoa IN " + GlobalModuls.Global.glbKhoa_CapNhat + " and (len(Makhoa)=3) ORDER BY MaKhoa";
															//			dr=SQLCmd.ExecuteReader();
															//			while (dr.Read())
															//			{
															//				CmbKhoa.AddItem(string.Format("{0};{1}",dr["MaKhoa"],dr["TenKhoa"]));
															//			}
															//			CmbKhoa.SelectedIndex =0;
															//			CmbKhoa.Tag ="1";
															//			dr.Close();
															//			SQLCmd.Dispose();
		}

		private void cmdIn_Click(object sender, System.EventArgs e)
		{
			System.Data.SqlClient.SqlDataReader dr;
			System.Data.SqlClient.SqlCommand SQLCmd= new System.Data.SqlClient.SqlCommand();
			SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
			string SQL;
			SQL = string.Format("Select Hoten,BenhNhan_KyQuy.NgayKQ,SoBLKQ,Sotien from BENHNHAN, BenhNhan_KyQuy where BENHNHAN.SoHSBA=BenhNhan_KyQuy.SoHSBA and NgayKQ between '{0:MM/dd/yyyy}'and '{1:MM/dd/yyyy}' ORDER BY BENHNHAN_KYQUY.SoHSBA",this.txttuNgay.Value,this.txtToingay.Value);
				
			SQLCmd.CommandText  =SQL;
			dr=SQLCmd.ExecuteReader();
			//NamDinh_QLBN.Reports.rptTamThu rpt = new NamDinh_QLBN.Reports.rptTamThu(this.txttuNgay.Text,this.txtToingay.Text);
            //rpt.DataSource = dr;
            //rpt.Run();
            //NamDinh_QLBN.Forms.PreviewForm  fr = new PreviewForm(rpt.Document,this.MdiParent);
            //fr.Show();			
			dr.Close();
			SQLCmd.Dispose();
			this.Dispose();
		}
	}
}
