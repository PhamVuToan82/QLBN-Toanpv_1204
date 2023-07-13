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
	public class FrmBCTHCP : System.Windows.Forms.Form
	{
		internal C1.Win.C1List.C1Combo CmbKhoa;
		private System.Windows.Forms.Label label2;
		private C1.Win.C1Input.C1DateEdit txtNgay;
		private System.Windows.Forms.Label label4;
		private DevExpress.XtraEditors.SimpleButton cmdIn;
		private DevExpress.XtraEditors.SimpleButton simpleButton2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FrmBCTHCP()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FrmBCTHCP));
			this.CmbKhoa = new C1.Win.C1List.C1Combo();
			this.label2 = new System.Windows.Forms.Label();
			this.txtNgay = new C1.Win.C1Input.C1DateEdit();
			this.label4 = new System.Windows.Forms.Label();
			this.cmdIn = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
			((System.ComponentModel.ISupportInitialize)(this.CmbKhoa)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtNgay)).BeginInit();
			this.SuspendLayout();
			// 
			// CmbKhoa
			// 
			this.CmbKhoa.AddItemSeparator = ';';
			this.CmbKhoa.AllowColMove = false;
			this.CmbKhoa.AllowRowSizing = C1.Win.C1List.RowSizingEnum.AllRows;
			this.CmbKhoa.AutoCompletion = true;
			this.CmbKhoa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.CmbKhoa.Caption = "";
			this.CmbKhoa.CaptionHeight = 17;
			this.CmbKhoa.CaptionVisible = false;
			this.CmbKhoa.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
			this.CmbKhoa.ColumnCaptionHeight = 17;
			this.CmbKhoa.ColumnFooterHeight = 17;
			this.CmbKhoa.ColumnHeaders = false;
			this.CmbKhoa.ContentHeight = 16;
			this.CmbKhoa.DataMode = C1.Win.C1List.DataModeEnum.AddItem;
			this.CmbKhoa.DeadAreaBackColor = System.Drawing.Color.Empty;
			this.CmbKhoa.DefColWidth = 30;
			this.CmbKhoa.DisplayMember = "Danh mục";
			this.CmbKhoa.EditorBackColor = System.Drawing.Color.White;
			this.CmbKhoa.EditorFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.CmbKhoa.EditorForeColor = System.Drawing.SystemColors.WindowText;
			this.CmbKhoa.EditorHeight = 16;
			this.CmbKhoa.ExtendRightColumn = true;
			this.CmbKhoa.FlatStyle = C1.Win.C1List.FlatModeEnum.Popup;
			this.CmbKhoa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.CmbKhoa.GapHeight = 2;
			this.CmbKhoa.ItemHeight = 15;
			this.CmbKhoa.Location = new System.Drawing.Point(84, 51);
			this.CmbKhoa.MatchCol = C1.Win.C1List.MatchColEnum.AllCols;
			this.CmbKhoa.MatchEntryTimeout = ((long)(2000));
			this.CmbKhoa.MaxDropDownItems = ((short)(10));
			this.CmbKhoa.MaxLength = 32767;
			this.CmbKhoa.MouseCursor = System.Windows.Forms.Cursors.Default;
			this.CmbKhoa.Name = "CmbKhoa";
			this.CmbKhoa.PartialRightColumn = false;
			this.CmbKhoa.RowDivider.Color = System.Drawing.Color.DarkGray;
			this.CmbKhoa.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
			this.CmbKhoa.RowSubDividerColor = System.Drawing.Color.DarkGray;
			this.CmbKhoa.Size = new System.Drawing.Size(204, 20);
			this.CmbKhoa.TabIndex = 121;
			this.CmbKhoa.PropBag = "<?xml version=\"1.0\"?><Blob><DataCols><C1DataColumn Level=\"0\" Caption=\"Ma\" DataFie" +
				"ld=\"\" DataWidth=\"2\"><ValueItems /></C1DataColumn><C1DataColumn Level=\"0\" Caption" +
				"=\"Danh mục\" DataField=\"\"><ValueItems /></C1DataColumn></DataCols><Styles type=\"C" +
				"1.Win.C1List.Design.ContextWrapper\"><Data>Style11{}Style12{AlignHorz:Near;}Style" +
				"13{AlignHorz:Near;}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selec" +
				"ted{ForeColor:HighlightText;BackColor:Highlight;}Heading{Wrap:True;AlignVert:Cen" +
				"ter;Border:Flat,ControlDark,0, 1, 0, 1;ForeColor:ControlText;BackColor:Control;}" +
				"Inactive{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}Footer{}Captio" +
				"n{AlignHorz:Center;}Normal{Font:Tahoma, 8.25pt, style=Bold;BackColor:White;}High" +
				"lightRow{ForeColor:HighlightText;BackColor:Highlight;}Style1{}Style23{}Style22{A" +
				"lignHorz:Near;}Style21{AlignHorz:Near;}OddRow{}RecordSelector{AlignImage:Center;" +
				"}Style9{AlignHorz:Near;}Style8{}Style3{}Style2{}Style14{}Group{BackColor:Control" +
				"Dark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Style10{}</Data></Styles><Splits>" +
				"<C1.Win.C1List.ListBoxView AllowColMove=\"False\" AllowColSelect=\"False\" Name=\"\" C" +
				"aptionHeight=\"17\" ColumnCaptionHeight=\"17\" ColumnFooterHeight=\"17\" ExtendRightCo" +
				"lumn=\"True\" VerticalScrollGroup=\"1\" HorizontalScrollGroup=\"1\"><ClientRect>0, 0, " +
				"116, 156</ClientRect><internalCols><C1DisplayColumn><HeadingStyle parent=\"Style2" +
				"\" me=\"Style12\" /><Style parent=\"Style1\" me=\"Style13\" /><FooterStyle parent=\"Styl" +
				"e3\" me=\"Style14\" /><ColumnDivider><Color>DarkGray</Color><Style>Single</Style></" +
				"ColumnDivider><Width>20</Width><Height>15</Height><DCIdx>0</DCIdx></C1DisplayCol" +
				"umn><C1DisplayColumn><HeadingStyle parent=\"Style2\" me=\"Style21\" /><Style parent=" +
				"\"Style1\" me=\"Style22\" /><FooterStyle parent=\"Style3\" me=\"Style23\" /><ColumnDivid" +
				"er><Color>DarkGray</Color><Style>Single</Style></ColumnDivider><Width>80</Width>" +
				"<Height>15</Height><DCIdx>1</DCIdx></C1DisplayColumn></internalCols><VScrollBar>" +
				"<Width>16</Width></VScrollBar><HScrollBar><Height>16</Height></HScrollBar><Capti" +
				"onStyle parent=\"Style2\" me=\"Style9\" /><EvenRowStyle parent=\"EvenRow\" me=\"Style7\"" +
				" /><FooterStyle parent=\"Footer\" me=\"Style3\" /><GroupStyle parent=\"Group\" me=\"Sty" +
				"le11\" /><HeadingStyle parent=\"Heading\" me=\"Style2\" /><HighLightRowStyle parent=\"" +
				"HighlightRow\" me=\"Style6\" /><InactiveStyle parent=\"Inactive\" me=\"Style4\" /><OddR" +
				"owStyle parent=\"OddRow\" me=\"Style8\" /><RecordSelectorStyle parent=\"RecordSelecto" +
				"r\" me=\"Style10\" /><SelectedStyle parent=\"Selected\" me=\"Style5\" /><Style parent=\"" +
				"Normal\" me=\"Style1\" /></C1.Win.C1List.ListBoxView></Splits><NamedStyles><Style p" +
				"arent=\"\" me=\"Normal\" /><Style parent=\"Normal\" me=\"Heading\" /><Style parent=\"Head" +
				"ing\" me=\"Footer\" /><Style parent=\"Heading\" me=\"Caption\" /><Style parent=\"Heading" +
				"\" me=\"Inactive\" /><Style parent=\"Normal\" me=\"Selected\" /><Style parent=\"Normal\" " +
				"me=\"HighlightRow\" /><Style parent=\"Normal\" me=\"EvenRow\" /><Style parent=\"Normal\"" +
				" me=\"OddRow\" /><Style parent=\"Heading\" me=\"RecordSelector\" /><Style parent=\"Capt" +
				"ion\" me=\"Group\" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSpl" +
				"its><Layout>Modified</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth></Blob>";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(1, 54);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(71, 15);
			this.label2.TabIndex = 120;
			this.label2.Text = "Khoa, Phòng";
			// 
			// txtNgay
			// 
			this.txtNgay.Culture = 1066;
			this.txtNgay.CustomFormat = "dd/MM/yyyy";
			this.txtNgay.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
			this.txtNgay.Location = new System.Drawing.Point(84, 15);
			this.txtNgay.Name = "txtNgay";
			this.txtNgay.Size = new System.Drawing.Size(135, 20);
			this.txtNgay.TabIndex = 119;
			this.txtNgay.Tag = null;
			// 
			// label4
			// 
			this.label4.BackColor = System.Drawing.Color.Transparent;
			this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label4.Location = new System.Drawing.Point(-15, 18);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(69, 18);
			this.label4.TabIndex = 118;
			this.label4.Text = "Ngày";
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
			// FrmBCTHCP
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(433, 77);
			this.Controls.Add(this.simpleButton2);
			this.Controls.Add(this.cmdIn);
			this.Controls.Add(this.CmbKhoa);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtNgay);
			this.Controls.Add(this.label4);
			this.Name = "FrmBCTHCP";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Báo cáo tổng hợp chi phí sử dụng";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.CmbKhoa)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtNgay)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void simpleButton2_Click(object sender, System.EventArgs e)
		{
			this.Dispose();
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			txtNgay.Value = GlobalModuls.Global.NgayLV;
			System.Data.SqlClient.SqlDataReader dr;
			System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
			SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
			CmbKhoa.Tag ="0";
			CmbKhoa.ClearItems();
			SQLCmd.CommandText = "SELECT * FROM DMKHOAPHONG WHERE MaKhoa IN " + GlobalModuls.Global.glbKhoa_CapNhat + " ORDER BY MaKhoa";
			dr=SQLCmd.ExecuteReader();
			while (dr.Read())
			{
				CmbKhoa.AddItem(string.Format("{0};{1}",dr["MaKhoa"],dr["TenKhoa"]));
			}
			CmbKhoa.SelectedIndex =0;
			CmbKhoa.Tag ="1";
			dr.Close();
			SQLCmd.Dispose();
		}

		private void cmdIn_Click(object sender, System.EventArgs e)
		{
			System.Data.SqlClient.SqlDataReader dr;
			System.Data.SqlClient.SqlCommand SQLCmd= new System.Data.SqlClient.SqlCommand();
			SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
			string SQL;
			SQL=string.Format ("SELECT HoTen,q1.ThanhTien,TamThu,ThanhToan,CPTrongNgay," +
				   "ThanhToan +TamThu-ThanhTien As Thua,"+
				   "ThanhTien -(TamThu+ThanhToan) AS Thieu " +
				   " FROM ((((BENHNHAN INNER JOIN ViewKhoaHienTai ON BENHNHAN.SoHSBA=ViewKhoaHienTai.SoHSBA) LEFT JOIN " + 
				   "(select SoHSBA, SUM(Soluong*DonGia) As ThanhTien FROM BENHNHAN_CHIPHI GROUP BY SoHSBA)Q1 ON BENHNHAN.SoHSBA=Q1.SoHSBA)" +
				   " LEFT JOIN (select SoHSBA, SUM(SoTien) As TamThu FROM BENHNHAN_KYQUY GROUP BY SoHSBA) Q2 ON BENHNHAN.SoHSBA=Q2.SoHSBA)" +
				   " LEFT JOIN (Select SoHSBA, Sum(TienTT) As ThanhToan FROM BENHNHAN_THANHTOAN GROUP BY SoHSBA)Q3 ON BENHNHAN.SoHSBA=Q3.SoHSBA)" +
				   " LEFT JOIN (select SoHSBA, SUM(Soluong*DonGia) As CPTrongNgay FROM BENHNHAN_CHIPHI WHERE NgayCP='{0:MM/dd/yyyy}' GROUP BY SoHSBA)Q4 ON BENHNHAN.SoHSBA=Q4.SoHSBA " +
				   " WHERE ViewKhoaHienTai.MaKhoa=" + GlobalModuls.Global.GetCode(CmbKhoa),this.txtNgay.Value);

			SQLCmd.CommandText  =SQL;
			dr=SQLCmd.ExecuteReader();
            //NamDinh_QLBN.Reports.rptChiphiSD rpt = new NamDinh_QLBN.Reports.rptChiphiSD(this.txtNgay.Text, this.CmbKhoa.Text);
            //rpt.DataSource = dr;
            //rpt.Run();
            //NamDinh_QLBN.Forms.PreviewForm  fr = new PreviewForm(rpt.Document,this.MdiParent);
            //fr.Show();			
			dr.Close();
			SQLCmd.Dispose();
		}
	}
}
