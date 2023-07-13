using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using GlobalModuls;
namespace NamDinh_QLBN.Forms.DuLieu.DuyetPhieuCD
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class FrmTKDuyetXN : System.Windows.Forms.Form
	{		
		private System.Windows.Forms.Label label4;
		private DevExpress.XtraEditors.SimpleButton cmdIn;
		private DevExpress.XtraEditors.SimpleButton simpleButton2;
		private C1.Win.C1Input.C1DateEdit txttuNgay;
		private C1.Win.C1Input.C1DateEdit txtToingay;
		private System.Windows.Forms.Label label1;
        internal C1.Win.C1List.C1Combo cmbLoaiCLS;
        private Label label2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

        public FrmTKDuyetXN()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTKDuyetXN));
            C1.Win.C1List.Style style1 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style2 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style3 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style4 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style5 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style6 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style7 = new C1.Win.C1List.Style();
            C1.Win.C1List.Style style8 = new C1.Win.C1List.Style();
            this.txttuNgay = new C1.Win.C1Input.C1DateEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.cmdIn = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.txtToingay = new C1.Win.C1Input.C1DateEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbLoaiCLS = new C1.Win.C1List.C1Combo();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txttuNgay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtToingay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLoaiCLS)).BeginInit();
            this.SuspendLayout();
            // 
            // txttuNgay
            // 
            this.txttuNgay.Culture = 1066;
            this.txttuNgay.CustomFormat = "dd/MM/yyyy";
            this.txttuNgay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttuNgay.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
            this.txttuNgay.Location = new System.Drawing.Point(76, 12);
            this.txttuNgay.Name = "txttuNgay";
            this.txttuNgay.Size = new System.Drawing.Size(110, 21);
            this.txttuNgay.TabIndex = 119;
            this.txttuNgay.Tag = null;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(7, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 18);
            this.label4.TabIndex = 118;
            this.label4.Text = "Từ ngày";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cmdIn
            // 
            this.cmdIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdIn.Image = ((System.Drawing.Image)(resources.GetObject("cmdIn.Image")));
            this.cmdIn.Location = new System.Drawing.Point(76, 78);
            this.cmdIn.Name = "cmdIn";
            this.cmdIn.Size = new System.Drawing.Size(93, 27);
            this.cmdIn.TabIndex = 122;
            this.cmdIn.Text = "Tổng hợp";
            this.cmdIn.Click += new System.EventHandler(this.cmdIn_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.simpleButton2.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton2.Image")));
            this.simpleButton2.Location = new System.Drawing.Point(214, 76);
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
            this.txtToingay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtToingay.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
            this.txtToingay.Location = new System.Drawing.Point(264, 12);
            this.txtToingay.Name = "txtToingay";
            this.txtToingay.Size = new System.Drawing.Size(110, 21);
            this.txtToingay.TabIndex = 125;
            this.txtToingay.Tag = null;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(189, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 18);
            this.label1.TabIndex = 124;
            this.label1.Text = "Đến ngày";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cmbLoaiCLS
            // 
            this.cmbLoaiCLS.AddItemSeparator = ';';
            this.cmbLoaiCLS.AllowColMove = false;
            this.cmbLoaiCLS.AllowRowSizing = C1.Win.C1List.RowSizingEnum.AllRows;
            this.cmbLoaiCLS.AutoCompletion = true;
            this.cmbLoaiCLS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cmbLoaiCLS.Caption = "";
            this.cmbLoaiCLS.CaptionHeight = 17;
            this.cmbLoaiCLS.CaptionStyle = style1;
            this.cmbLoaiCLS.CaptionVisible = false;
            this.cmbLoaiCLS.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cmbLoaiCLS.ColumnCaptionHeight = 17;
            this.cmbLoaiCLS.ColumnFooterHeight = 17;
            this.cmbLoaiCLS.ColumnHeaders = false;
            this.cmbLoaiCLS.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList;
            this.cmbLoaiCLS.ContentHeight = 18;
            this.cmbLoaiCLS.DataMode = C1.Win.C1List.DataModeEnum.AddItem;
            this.cmbLoaiCLS.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cmbLoaiCLS.DefColWidth = 30;
            this.cmbLoaiCLS.DisplayMember = "Danh mục";
            this.cmbLoaiCLS.EditorBackColor = System.Drawing.Color.White;
            this.cmbLoaiCLS.EditorFont = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLoaiCLS.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbLoaiCLS.EditorHeight = 18;
            this.cmbLoaiCLS.EvenRowStyle = style2;
            this.cmbLoaiCLS.ExtendRightColumn = true;
            this.cmbLoaiCLS.FlatStyle = C1.Win.C1List.FlatModeEnum.Popup;
            this.cmbLoaiCLS.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLoaiCLS.FooterStyle = style3;
            this.cmbLoaiCLS.GapHeight = 2;
            this.cmbLoaiCLS.HeadingStyle = style4;
            this.cmbLoaiCLS.HighLightRowStyle = style5;
            this.cmbLoaiCLS.ItemHeight = 15;
            this.cmbLoaiCLS.Location = new System.Drawing.Point(76, 42);
            this.cmbLoaiCLS.MatchCol = C1.Win.C1List.MatchColEnum.AllCols;
            this.cmbLoaiCLS.MatchEntryTimeout = ((long)(2000));
            this.cmbLoaiCLS.MaxDropDownItems = ((short)(10));
            this.cmbLoaiCLS.MaxLength = 32767;
            this.cmbLoaiCLS.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cmbLoaiCLS.Name = "cmbLoaiCLS";
            this.cmbLoaiCLS.OddRowStyle = style6;
            this.cmbLoaiCLS.PartialRightColumn = false;
            this.cmbLoaiCLS.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.cmbLoaiCLS.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.cmbLoaiCLS.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cmbLoaiCLS.SelectedStyle = style7;
            this.cmbLoaiCLS.Size = new System.Drawing.Size(298, 22);
            this.cmbLoaiCLS.Style = style8;
            this.cmbLoaiCLS.TabIndex = 152;
            this.cmbLoaiCLS.PropBag = resources.GetString("cmbLoaiCLS.PropBag");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 153;
            this.label2.Text = "Loại dịch vụ";
            // 
            // FrmTKDuyetXN
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(377, 114);
            this.Controls.Add(this.cmbLoaiCLS);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtToingay);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.cmdIn);
            this.Controls.Add(this.txttuNgay);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmTKDuyetXN";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thống kê duyệt xét nghiệm - cận lâm sàng";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txttuNgay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtToingay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLoaiCLS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        private void LoatDanhMuc()
        {
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            try
            {
                cmbLoaiCLS.Tag = "0";
                SQLCmd.CommandText = string.Format("SELECT * FROM DMLOAIDICHVU WHERE MALOAIDICHVU LIKE '{0}' ORDER BY THUTUCHONCHIDINH", "C5%");
                dr = SQLCmd.ExecuteReader();
                cmbLoaiCLS.ClearItems();
                cmbLoaiCLS.AddItem("0;---------------- TẤT CẢ ----------------");
                while (dr.Read())
                {
                    cmbLoaiCLS.AddItem(string.Format("{0};{1}", dr["MaLoaiDichVu"], dr["TenLoaiDichVu"]));
                }
                cmbLoaiCLS.SelectedIndex = 0;
                cmbLoaiCLS.Tag = "1";
                dr.Close();
                txttuNgay.Value = txtToingay.Value = GlobalModuls.Global.GetNgayLV();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                SQLCmd.Dispose();
            }
        }

		private void simpleButton2_Click(object sender, System.EventArgs e)
		{
			this.Dispose();
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
            LoatDanhMuc();
		}

		private void cmdIn_Click(object sender, System.EventArgs e)
		{
            NamDinh_QLBN.Reports.DuyetPhieuCD.rptSoDuyetXN rpt = new NamDinh_QLBN.Reports.DuyetPhieuCD.rptSoDuyetXN(txttuNgay.Value, txtToingay.Value,Global.GetCode(cmbLoaiCLS));
            rpt.Show();
		}
	}
}
