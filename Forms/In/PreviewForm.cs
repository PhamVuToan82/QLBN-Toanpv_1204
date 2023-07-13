using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using NamDinh_QLBN.Forms.In;


namespace NamDinh_QLBN.Forms.In
{
	/// <summary>
	/// PreviewForm - child MDI form that loads up the ActiveReports Viewer to view a report
	/// and provides options to export, save and print the generated report
	/// </summary>
	public class PreviewForm : System.Windows.Forms.Form
	{
        private DataDynamics.ActiveReports.Viewer.Viewer arvMain;
        private System.Windows.Forms.PrintDialog dlgPrint;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem kếtXuấtDữLiệuToolStripMenuItem;
        private ToolStripMenuItem lưuBáoCáoToolStripMenuItem;
        private ToolStripMenuItem thiếtLậpTrangInToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem đóngBáoCáoToolStripMenuItem;
        private IContainer components=null;

		public PreviewForm(DataDynamics.ActiveReports.Document.Document doc, Form parentForm)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			
			this.MdiParent = parentForm;

			arvMain.Document = doc;
			this.Text = doc.Name;
		}
        public PreviewForm(DataDynamics.ActiveReports.Document.Document doc)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //this.MdiParent = parentForm;

            arvMain.Document = doc;
            //this.Text = doc.Name;
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
            this.arvMain = new DataDynamics.ActiveReports.Viewer.Viewer();
            this.dlgPrint = new System.Windows.Forms.PrintDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kếtXuấtDữLiệuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lưuBáoCáoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thiếtLậpTrangInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.đóngBáoCáoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // arvMain
            // 
            this.arvMain.BackColor = System.Drawing.SystemColors.Control;
            this.arvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.arvMain.Document = new DataDynamics.ActiveReports.Document.Document("");
            this.arvMain.Location = new System.Drawing.Point(0, 24);
            this.arvMain.Name = "arvMain";
            this.arvMain.ReportViewer.BackColor = System.Drawing.SystemColors.Control;
            this.arvMain.ReportViewer.CurrentPage = 0;
            this.arvMain.ReportViewer.MultiplePageCols = 3;
            this.arvMain.ReportViewer.MultiplePageRows = 2;
            this.arvMain.ReportViewer.ViewType = DataDynamics.ActiveReports.Viewer.ViewType.Normal;
            this.arvMain.Size = new System.Drawing.Size(782, 637);
            this.arvMain.TabIndex = 0;
            this.arvMain.TableOfContents.Text = "Contents";
            this.arvMain.TableOfContents.Width = 200;
            this.arvMain.TabTitleLength = 35;
            this.arvMain.Toolbar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.arvMain.ToolClick += new DataDynamics.ActiveReports.Toolbar.ToolClickEventHandler(this.arViewer_ToolClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(782, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kếtXuấtDữLiệuToolStripMenuItem,
            this.lưuBáoCáoToolStripMenuItem,
            this.thiếtLậpTrangInToolStripMenuItem,
            this.toolStripMenuItem1,
            this.đóngBáoCáoToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // kếtXuấtDữLiệuToolStripMenuItem
            // 
            this.kếtXuấtDữLiệuToolStripMenuItem.Name = "kếtXuấtDữLiệuToolStripMenuItem";
            this.kếtXuấtDữLiệuToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.kếtXuấtDữLiệuToolStripMenuItem.Text = "Kết xuất dữ liệu";
            this.kếtXuấtDữLiệuToolStripMenuItem.Click += new System.EventHandler(this.kếtXuấtDữLiệuToolStripMenuItem_Click);
            // 
            // lưuBáoCáoToolStripMenuItem
            // 
            this.lưuBáoCáoToolStripMenuItem.Name = "lưuBáoCáoToolStripMenuItem";
            this.lưuBáoCáoToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.lưuBáoCáoToolStripMenuItem.Text = "Lưu báo cáo";
            this.lưuBáoCáoToolStripMenuItem.Click += new System.EventHandler(this.lưuBáoCáoToolStripMenuItem_Click);
            // 
            // thiếtLậpTrangInToolStripMenuItem
            // 
            this.thiếtLậpTrangInToolStripMenuItem.Name = "thiếtLậpTrangInToolStripMenuItem";
            this.thiếtLậpTrangInToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.thiếtLậpTrangInToolStripMenuItem.Text = "Thiết lập trang in";
            this.thiếtLậpTrangInToolStripMenuItem.Click += new System.EventHandler(this.thiếtLậpTrangInToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(163, 6);
            // 
            // đóngBáoCáoToolStripMenuItem
            // 
            this.đóngBáoCáoToolStripMenuItem.Name = "đóngBáoCáoToolStripMenuItem";
            this.đóngBáoCáoToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.đóngBáoCáoToolStripMenuItem.Text = "Đóng báo cáo";
            this.đóngBáoCáoToolStripMenuItem.Click += new System.EventHandler(this.đóngBáoCáoToolStripMenuItem_Click);
            // 
            // PreviewForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(782, 661);
            this.Controls.Add(this.arvMain);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "PreviewForm";
            this.Text = "ActiveReports for .NET 3.0 Custom Preview Sample";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PreviewForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void PreviewForm_Load(object sender, System.EventArgs e)
		{
			// add custom buttons to the viewer's toolbar
            //Icon _ico = new Icon(GetType().Module.Assembly.GetManifestResourceStream("Save16x16.ico"));
            //arvMain.Toolbar.Images.Images.Add(_ico);
            //_ico = new Icon(GetType().Module.Assembly.GetManifestResourceStream("Export16x16.ico"));
            //arvMain.Toolbar.Images.Images.Add(_ico);

            //Add Save button to the toolbar
            //DataDynamics.ActiveReports.Toolbar.Button _btn = new DataDynamics.ActiveReports.Toolbar.Button();
            ////_btn.ImageIndex = 14;	// new images were added to Toolbar.Images 
            //_btn.ButtonStyle = DataDynamics.ActiveReports.Toolbar.ButtonStyle.Icon;
            //_btn.Caption = "Save";
            //_btn.Id = 5001;	// unique identifier for the new tool
            //_btn.ToolTip = "Save Report Document";
            //arvMain.Toolbar.Tools.Insert(1, (DataDynamics.ActiveReports.Toolbar.Tool)_btn);
			
            ////Add Export button to the toolbar
            //_btn = new DataDynamics.ActiveReports.Toolbar.Button();
            ////_btn.ImageIndex = 15;
            //_btn.Id = 5002;
            //_btn.ButtonStyle = DataDynamics.ActiveReports.Toolbar.ButtonStyle.Icon;
            //_btn.Caption = "Export";
            //_btn.ToolTip = "Export Report Document";
            //arvMain.Toolbar.Tools.Insert(2, (DataDynamics.ActiveReports.Toolbar.Tool) _btn);

            //
            DataDynamics.ActiveReports.Toolbar.Button btn = new DataDynamics.ActiveReports.Toolbar.Button();
            btn.ButtonStyle = DataDynamics.ActiveReports.Toolbar.ButtonStyle.TextAndIcon;
            btn.Id = 5003;
            btn.Caption = "Thoát";
            btn.ToolTip = "Ðóng báo cáo";
            arvMain.Toolbar.Tools.Insert(arvMain.Toolbar.Tools.Count, (DataDynamics.ActiveReports.Toolbar.Tool)btn);

            btn = new DataDynamics.ActiveReports.Toolbar.Button();
            btn.ButtonStyle = DataDynamics.ActiveReports.Toolbar.ButtonStyle.TextAndIcon;
            btn.Caption = "Kết xuất";
            btn.Id = 5001;	// unique identifier for the new tool
            btn.ToolTip = "Kết xuất báo cáo ra các định dạng khác";
            arvMain.Toolbar.Tools.Insert(arvMain.Toolbar.Tools.Count, (DataDynamics.ActiveReports.Toolbar.Tool)btn);
        }

		private void arViewer_ToolClick(object sender, DataDynamics.ActiveReports.Toolbar.ToolClickEventArgs e)
		{
			//Add code to run when new buttons are clicked
			try
			{
				switch(e.Tool.Id)
				{
					case 5002: //Save button
						this.SaveDocument();
						break;
					case 5001: //Export button
						this.ExportDocument();
						break;
                    case 5003:
                        this.Dispose();
                        break;
				}
			}
			catch(System.IO.IOException exp)
			{
				MessageBox.Show(exp.ToString());
			}
		}
		
		/// <summary>
		/// Saves out an existing report document to the RDF format.
		/// </summary>
		private void SaveDocument()
		{
			SaveFileDialog _dlgSave = new SaveFileDialog();
			_dlgSave.Title = "Save Report Document";
			_dlgSave.Filter = "Report Document Files (*.rdf)|*.rdf";
			_dlgSave.DefaultExt = "rdf";
			_dlgSave.AddExtension = true;
			if (_dlgSave.ShowDialog(this) == DialogResult.OK)
			{
				if (File.Exists(_dlgSave.FileName))
				{
					if (MessageBox.Show(this, "Overwrite Existing File?", "Overwrite", MessageBoxButtons.YesNo) != DialogResult.Yes)
					{
						return;
					}
				}
				arvMain.Document.Save(_dlgSave.FileName);
			}
		}

		/// <summary>
		/// Opens the export form to export out the current report document
		/// </summary>
		private void ExportDocument()
		{
			ExportForm _exportForm = new ExportForm(arvMain.Document);
			_exportForm.ShowDialog(this);
		}

		/// <summary>
		/// mnuExport_Click - called the ExportDocument() call to export out the
		/// current report document
		/// </summary>
		private void mnuExport_Click(object sender, System.EventArgs e)
		{
			this.ExportDocument();
		}

		/// <summary>
		/// mnuSaveDocument_Click - called the SaveDocument() call to save the 
		/// current report document to the RDF format.
		/// </summary>
		private void mnuSaveDocument_Click(object sender, System.EventArgs e)
		{
			this.SaveDocument();
		}

		/// <summary>
		/// mnuPrinterSetup_Click - opens the Printer Dialog box to assist in
		/// printer setup.
		/// </summary>
		private void mnuPrinterSetup_Click(object sender, System.EventArgs e)
		{
			if (this.arvMain.Document != null)
			{
				this.dlgPrint.Document = this.arvMain.Document.Printer;
				dlgPrint.ShowDialog(this);
			
			}		
		}

        private void kếtXuấtDữLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ExportDocument();
        }

        private void lưuBáoCáoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SaveDocument();
        }

        private void thiếtLậpTrangInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.arvMain.Document != null)
            {
                this.dlgPrint.Document = this.arvMain.Document.Printer;
                dlgPrint.ShowDialog(this);
            }
        }

        private void đóngBáoCáoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
	}
}
