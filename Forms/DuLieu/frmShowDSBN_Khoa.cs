using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace NamDinh_QLBN.Forms.DuLieu
{
	/// <summary>
	/// Summary description for frmShowDSBN_Khoa.
	/// </summary>
	public class frmShowDSBN_Khoa : System.Windows.Forms.Form
	{
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.Button cmdTim;
		private System.Windows.Forms.TextBox txtHoTen;
		private System.Windows.Forms.TextBox txtSoHSBA;
		private C1.Win.C1FlexGrid.C1FlexGrid fg;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button cmdOK;
		private System.Windows.Forms.Button cmdCancel;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmShowDSBN_Khoa()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmShowDSBN_Khoa));
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.cmdTim = new System.Windows.Forms.Button();
			this.txtHoTen = new System.Windows.Forms.TextBox();
			this.txtSoHSBA = new System.Windows.Forms.TextBox();
			this.fg = new C1.Win.C1FlexGrid.C1FlexGrid();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.cmdOK = new System.Windows.Forms.Button();
			this.cmdCancel = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.fg)).BeginInit();
			this.SuspendLayout();
			// 
			// checkBox1
			// 
			this.checkBox1.Location = new System.Drawing.Point(62, 45);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(222, 18);
			this.checkBox1.TabIndex = 63;
			this.checkBox1.Text = "Liệt kê cả các bệnh nhân đã thanh toán";
			// 
			// cmdTim
			// 
			this.cmdTim.Image = ((System.Drawing.Image)(resources.GetObject("cmdTim.Image")));
			this.cmdTim.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.cmdTim.Location = new System.Drawing.Point(227, 9);
			this.cmdTim.Name = "cmdTim";
			this.cmdTim.Size = new System.Drawing.Size(57, 27);
			this.cmdTim.TabIndex = 62;
			this.cmdTim.Text = "Tìm";
			// 
			// txtHoTen
			// 
			this.txtHoTen.Location = new System.Drawing.Point(62, 24);
			this.txtHoTen.Name = "txtHoTen";
			this.txtHoTen.Size = new System.Drawing.Size(159, 20);
			this.txtHoTen.TabIndex = 61;
			this.txtHoTen.TabStop = false;
			this.txtHoTen.Text = "";
			// 
			// txtSoHSBA
			// 
			this.txtSoHSBA.Location = new System.Drawing.Point(62, 3);
			this.txtSoHSBA.Name = "txtSoHSBA";
			this.txtSoHSBA.Size = new System.Drawing.Size(72, 20);
			this.txtSoHSBA.TabIndex = 59;
			this.txtSoHSBA.Text = "";
			// 
			// fg
			// 
			this.fg.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
			this.fg.AllowEditing = false;
			this.fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Light3D;
			this.fg.ColumnInfo = @"8,1,1,0,0,90,Columns:0{Width:24;Caption:""STT"";DataType:System.Int64;TextAlign:RightCenter;TextAlignFixed:CenterCenter;}	1{Width:52;Caption:""Số HSBA"";Format:""00"";TextAlignFixed:CenterCenter;}	2{Width:139;Caption:""Họ tên"";TextAlignFixed:CenterCenter;}	3{Width:33;Caption:""Giới"";}	4{Width:26;Caption:""Tuổi"";}	5{Width:46;Caption:""Ký quỹ"";}	6{Width:67;Caption:""Đối tượng"";}	7{Caption:""Mức giá"";}	";
			this.fg.ExtendLastCol = true;
			this.fg.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid;
			this.fg.HighLight = C1.Win.C1FlexGrid.HighLightEnum.WithFocus;
			this.fg.Location = new System.Drawing.Point(2, 66);
			this.fg.Name = "fg";
			this.fg.Rows.Count = 1;
			this.fg.Rows.MinSize = 20;
			this.fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
			this.fg.ShowCursor = true;
			this.fg.Size = new System.Drawing.Size(282, 297);
			this.fg.Styles = new C1.Win.C1FlexGrid.CellStyleCollection(@"Normal{Font:Tahoma, 8.25pt;}	Fixed{BackColor:Control;ForeColor:0, 0, 192;Border:Raised,1,Black,Both;}	Highlight{BackColor:MediumBlue;ForeColor:Yellow;TextEffect:Flat;}	Search{BackColor:Highlight;ForeColor:HighlightText;}	Frozen{BackColor:Beige;}	EmptyArea{BackColor:SteelBlue;Border:Flat,1,ControlDarkDark,Both;}	GrandTotal{BackColor:Black;ForeColor:White;}	Subtotal0{BackColor:ControlDarkDark;ForeColor:White;}	Subtotal1{BackColor:ControlDarkDark;ForeColor:White;}	Subtotal2{BackColor:ControlDarkDark;ForeColor:White;}	Subtotal3{BackColor:ControlDarkDark;ForeColor:White;}	Subtotal4{BackColor:ControlDarkDark;ForeColor:White;}	Subtotal5{BackColor:ControlDarkDark;ForeColor:White;}	");
			this.fg.TabIndex = 57;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(5, 27);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(57, 15);
			this.label2.TabIndex = 60;
			this.label2.Text = "Họ và tên";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(5, 6);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(57, 15);
			this.label1.TabIndex = 58;
			this.label1.Text = "Số HSBA";
			// 
			// cmdOK
			// 
			this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.cmdOK.Image = ((System.Drawing.Image)(resources.GetObject("cmdOK.Image")));
			this.cmdOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.cmdOK.Location = new System.Drawing.Point(140, 366);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.Size = new System.Drawing.Size(69, 27);
			this.cmdOK.TabIndex = 55;
			this.cmdOK.Text = "  Chọn";
			// 
			// cmdCancel
			// 
			this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancel.Image = ((System.Drawing.Image)(resources.GetObject("cmdCancel.Image")));
			this.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.cmdCancel.Location = new System.Drawing.Point(212, 366);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.Size = new System.Drawing.Size(69, 27);
			this.cmdCancel.TabIndex = 56;
			this.cmdCancel.Text = " Thoát";
			// 
			// frmShowDSBN_Khoa
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(286, 396);
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.cmdTim);
			this.Controls.Add(this.txtHoTen);
			this.Controls.Add(this.txtSoHSBA);
			this.Controls.Add(this.fg);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cmdOK);
			this.Controls.Add(this.cmdCancel);
			this.Name = "frmShowDSBN_Khoa";
			this.Text = "Danh sách bệnh nhân";
			((System.ComponentModel.ISupportInitialize)(this.fg)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion
	}
}
