using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace NamDinh_QLBN.Forms.DanhMuc
{
	/// <summary>
	/// Summary description for frmShowICD10.
	/// </summary>
	public class frmShowICD10 : System.Windows.Forms.Form
	{
		private string InputString="";
        public string TextReturn="";
        private byte KieuTim = 1;
		private System.Windows.Forms.TextBox txtTen;
		private C1.Win.C1FlexGrid.C1FlexGrid fg;
		private System.Windows.Forms.TextBox txt;
        private Button button1;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmShowICD10(string _Input,System.Windows.Forms.TextBox _txt)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			InputString = _Input;
			txt=_txt;
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}
        public frmShowICD10(string _Input, System.Windows.Forms.TextBox _txt,byte _KieuTim) //Kieu tim = 1: ten, 2:Ma
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            InputString = _Input;
            txt = _txt;
            KieuTim = _KieuTim;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShowICD10));
            this.fg = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.fg)).BeginInit();
            this.SuspendLayout();
            // 
            // fg
            // 
            this.fg.AllowDelete = true;
            this.fg.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.fg.AllowEditing = false;
            this.fg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Light3D;
            this.fg.ColumnInfo = resources.GetString("fg.ColumnInfo");
            this.fg.ExtendLastCol = true;
            this.fg.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid;
            this.fg.HighLight = C1.Win.C1FlexGrid.HighLightEnum.WithFocus;
            this.fg.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.fg.Location = new System.Drawing.Point(3, 24);
            this.fg.Name = "fg";
            this.fg.Rows.Count = 1;
            this.fg.Rows.MinSize = 20;
            this.fg.ScrollTips = true;
            this.fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox;
            this.fg.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.Always;
            this.fg.ShowCursor = true;
            this.fg.Size = new System.Drawing.Size(360, 447);
            this.fg.Styles = new C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("fg.Styles"));
            this.fg.TabIndex = 1;
            this.fg.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fg_KeyDown);
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(3, 3);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(332, 20);
            this.txtTen.TabIndex = 0;
            this.txtTen.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtTen_KeyUp);
            // 
            // button1
            // 
            this.button1.Image = global::NamDinh_QLBN.Properties.Resources.Soi16;
            this.button1.Location = new System.Drawing.Point(336, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(23, 22);
            this.button1.TabIndex = 2;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmShowICD10
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(364, 504);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtTen);
            this.Controls.Add(this.fg);
            this.Name = "frmShowICD10";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Danh mục ICD 10";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmShowICD10_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmShowICD10_Load(object sender, System.EventArgs e)
		{
            if (InputString == "") { return; }
            txtTen.Text = InputString;
            Load_ICD(txtTen.Text,KieuTim);
        }

		private void fg_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
                if (KieuTim == 1)
                {
                    txt.Text = fg.GetDataDisplay(fg.Row, 2).Trim();
                    txt.Tag = fg.GetDataDisplay(fg.Row, 1).Trim();
                }
                else
                {
                    txt.Text = fg.GetDataDisplay(fg.Row, 1).Trim();                    
                }
                TextReturn = fg.GetDataDisplay(fg.Row, 1).Trim() + "|" + fg.GetDataDisplay(fg.Row, 2).Trim();
				this.Dispose();
			}
		}

        private void button1_Click(object sender, EventArgs e)
        {
            Load_ICD(txtTen.Text,2);
        }
        private void Load_ICD(string InputString,byte KieuTim)
        {
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlDataReader dr;
            cmd.Connection = GlobalModuls.Global.ConnectSQL;
            if (KieuTim == 1)
            {
                cmd.CommandText = "SELECT * FROM DMBENH WHERE TenBenh like N'%" + InputString + "%'";
            }
            else
            {
                cmd.CommandText = "SELECT * FROM DMBENH WHERE MaBenh like N'" + InputString + "%'";
            }
            dr = cmd.ExecuteReader();
            fg.ClipSeparators = "|;";
            fg.Rows.Count = 1;
            fg.Redraw = false;
            while (dr.Read())
            {
                fg.AddItem(string.Format("{0}|{1}|{2}", fg.Rows.Count, dr["MaBenh"], dr["TenBenh"]));
            }
            dr.Close();
            cmd.Dispose();
            fg.Redraw = true;
        }

        private void txtTen_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    Load_ICD(txtTen.Text,1);
                    break;
                case Keys.Down:
                    fg.Focus();
                    break;
            }
        }
	}
}
