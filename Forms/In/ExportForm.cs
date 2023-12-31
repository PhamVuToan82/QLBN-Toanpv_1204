using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Export;
using DataDynamics.ActiveReports.Export.Html;
using DataDynamics.ActiveReports.Export.Pdf;
using DataDynamics.ActiveReports.Export.Rtf;
using DataDynamics.ActiveReports.Export.Text;
using DataDynamics.ActiveReports.Export.Tiff;
using DataDynamics.ActiveReports.Export.Xls;

namespace NamDinh_QLBN.Forms.In
{
	/// <summary>
	/// ExportForm - used to export a report object to a selected format (PDF, HTML, XLS, TIFF, RTF, Text)
	/// </summary>
	public class ExportForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel pnlTop;
		private System.Windows.Forms.Panel pnlBottom;
		private System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.Label lblSubTitle;
		private System.Windows.Forms.Panel pnlFill;
		private System.Windows.Forms.ComboBox cboExportFormat;
		private System.Windows.Forms.Label lblExportFormat;
		private System.Windows.Forms.Label lblFilename;
		private System.Windows.Forms.TextBox txtFilename;
		private System.Windows.Forms.Button btnSaveFile;

		private DataDynamics.ActiveReports.Document.Document doc;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Panel pnlOptions;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.PropertyGrid PropertyGridExport;

		object export=null;

		public ExportForm(DataDynamics.ActiveReports.Document.Document doc)
		{
			InitializeComponent();

			this.doc = doc;
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
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblSubTitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.pnlFill = new System.Windows.Forms.Panel();
            this.pnlOptions = new System.Windows.Forms.Panel();
            this.PropertyGridExport = new System.Windows.Forms.PropertyGrid();
            this.btnSaveFile = new System.Windows.Forms.Button();
            this.txtFilename = new System.Windows.Forms.TextBox();
            this.lblFilename = new System.Windows.Forms.Label();
            this.lblExportFormat = new System.Windows.Forms.Label();
            this.cboExportFormat = new System.Windows.Forms.ComboBox();
            this.pnlTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlFill.SuspendLayout();
            this.pnlOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.SystemColors.Window;
            this.pnlTop.Controls.Add(this.lblSubTitle);
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(458, 48);
            this.pnlTop.TabIndex = 0;
            // 
            // lblSubTitle
            // 
            this.lblSubTitle.Location = new System.Drawing.Point(16, 24);
            this.lblSubTitle.Name = "lblSubTitle";
            this.lblSubTitle.Size = new System.Drawing.Size(360, 16);
            this.lblSubTitle.TabIndex = 1;
            this.lblSubTitle.Text = "Select the export format and set export options.";
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(240, 20);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Export Report Document";
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnCancel);
            this.pnlBottom.Controls.Add(this.btnOk);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 200);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(458, 40);
            this.pnlBottom.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(360, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 24);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(264, 8);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(80, 24);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "&OK";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // pnlFill
            // 
            this.pnlFill.Controls.Add(this.pnlOptions);
            this.pnlFill.Controls.Add(this.btnSaveFile);
            this.pnlFill.Controls.Add(this.txtFilename);
            this.pnlFill.Controls.Add(this.lblFilename);
            this.pnlFill.Controls.Add(this.lblExportFormat);
            this.pnlFill.Controls.Add(this.cboExportFormat);
            this.pnlFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFill.Location = new System.Drawing.Point(0, 48);
            this.pnlFill.Name = "pnlFill";
            this.pnlFill.Size = new System.Drawing.Size(458, 152);
            this.pnlFill.TabIndex = 2;
            // 
            // pnlOptions
            // 
            this.pnlOptions.Controls.Add(this.PropertyGridExport);
            this.pnlOptions.Location = new System.Drawing.Point(8, 56);
            this.pnlOptions.Name = "pnlOptions";
            this.pnlOptions.Size = new System.Drawing.Size(440, 88);
            this.pnlOptions.TabIndex = 5;
            // 
            // PropertyGridExport
            // 
            this.PropertyGridExport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PropertyGridExport.HelpVisible = false;
            this.PropertyGridExport.LineColor = System.Drawing.SystemColors.ScrollBar;
            this.PropertyGridExport.Location = new System.Drawing.Point(0, 0);
            this.PropertyGridExport.Name = "PropertyGridExport";
            this.PropertyGridExport.PropertySort = System.Windows.Forms.PropertySort.NoSort;
            this.PropertyGridExport.Size = new System.Drawing.Size(440, 88);
            this.PropertyGridExport.TabIndex = 0;
            this.PropertyGridExport.ToolbarVisible = false;
            this.PropertyGridExport.Visible = false;
            // 
            // btnSaveFile
            // 
            this.btnSaveFile.Location = new System.Drawing.Point(416, 32);
            this.btnSaveFile.Name = "btnSaveFile";
            this.btnSaveFile.Size = new System.Drawing.Size(32, 20);
            this.btnSaveFile.TabIndex = 4;
            this.btnSaveFile.Text = "...";
            this.btnSaveFile.Click += new System.EventHandler(this.btnSaveFile_Click);
            // 
            // txtFilename
            // 
            this.txtFilename.Location = new System.Drawing.Point(96, 32);
            this.txtFilename.Name = "txtFilename";
            this.txtFilename.Size = new System.Drawing.Size(320, 20);
            this.txtFilename.TabIndex = 3;
            // 
            // lblFilename
            // 
            this.lblFilename.Location = new System.Drawing.Point(8, 34);
            this.lblFilename.Name = "lblFilename";
            this.lblFilename.Size = new System.Drawing.Size(80, 16);
            this.lblFilename.TabIndex = 2;
            this.lblFilename.Text = "Filename:";
            // 
            // lblExportFormat
            // 
            this.lblExportFormat.Location = new System.Drawing.Point(8, 10);
            this.lblExportFormat.Name = "lblExportFormat";
            this.lblExportFormat.Size = new System.Drawing.Size(80, 16);
            this.lblExportFormat.TabIndex = 1;
            this.lblExportFormat.Text = "Export Format:";
            // 
            // cboExportFormat
            // 
            this.cboExportFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboExportFormat.Items.AddRange(new object[] {
            "HTML Format (HTM)",
            "Portable Document Format (PDF)",
            "Rich Text Format (RTF)",
            "TIFF Format (TIF)",
            "Text Format (TXT)",
            "Microsoft Excel (XLS)"});
            this.cboExportFormat.Location = new System.Drawing.Point(96, 8);
            this.cboExportFormat.Name = "cboExportFormat";
            this.cboExportFormat.Size = new System.Drawing.Size(352, 21);
            this.cboExportFormat.TabIndex = 0;
            this.cboExportFormat.SelectedIndexChanged += new System.EventHandler(this.cboExportFormat_SelectedIndexChanged);
            // 
            // ExportForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(458, 240);
            this.Controls.Add(this.pnlFill);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExportForm";
            this.ShowInTaskbar = false;
            this.Text = "Export Report Document";
            this.Load += new System.EventHandler(this.ExportForm_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlFill.ResumeLayout(false);
            this.pnlFill.PerformLayout();
            this.pnlOptions.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void cboExportFormat_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			txtFilename.Text = "";
			this.export = null;
			PropertyGridExport.SelectedObject = null;

			//Change export format type
			switch (cboExportFormat.SelectedIndex)
			{
				case 0: // html
					this.export = new HtmlExport();
					break;
				case 1: // pdf
					this.export = new PdfExport();
					PropertyGridExport.SelectedObject = this.export;
					break;
				case 2: // rtf
					this.export = new RtfExport();
					break;
				case 3: // tiff
					this.export = new TiffExport();
					PropertyGridExport.SelectedObject = this.export;
					break;
				case 4: // txt
					this.export = new TextExport();
					break;
				case 5: // xls
					this.export = new XlsExport();
					PropertyGridExport.SelectedObject = this.export;
					break;
				default:
					this.export = null;
					break;
			}
			//Update PropertyGrid
			PropertyGridExport.SelectedObject = this.export;
		}

		private void ExportForm_Load(object sender, System.EventArgs e)
		{
			cboExportFormat.SelectedIndex = 1; // Set to pdf export
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void btnOk_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (txtFilename.Text.Length == 0)
				{
					return;
				}
				if (File.Exists(txtFilename.Text))
				{
					if (MessageBox.Show(this, "Overwrite Existing File?", "Overwrite File", MessageBoxButtons.YesNo) == DialogResult.No)
					{
						return;
					}
				}

				//Export report based on export type to selected filename
				switch(cboExportFormat.SelectedIndex)
				{
					case 0:
						((HtmlExport) export).Export(this.doc, this.txtFilename.Text);
						break;
					case 1:
						((PdfExport) export).Export(this.doc, this.txtFilename.Text);
						break;
					case 2:
						((RtfExport) export).Export(this.doc, this.txtFilename.Text);
						break;
					case 3:
						((TiffExport) export).Export(this.doc, this.txtFilename.Text);
						break;
					case 4:
						((TextExport) export).Export(this.doc, this.txtFilename.Text);
						break;
					case 5:
						((XlsExport) export).Export(this.doc, this.txtFilename.Text);
						break;
				}
				this.Close();
			}
			catch(System.IO.IOException exp)
			{
				MessageBox.Show(this, exp.ToString());
			}
			return;

		}

		/// <summary>
		/// btnSaveFile_Click - selects filename to use to save the exported report
		/// </summary>
		private void btnSaveFile_Click(object sender, System.EventArgs e)
		{
			SaveFileDialog _dlgSaveFile = new SaveFileDialog();
			_dlgSaveFile.Title = "Export Report Document";
			_dlgSaveFile.AddExtension = true;

			//Set filters based on export type
			switch(cboExportFormat.SelectedIndex)
			{
				case 0:
					_dlgSaveFile.DefaultExt = "htm";
					_dlgSaveFile.Filter = "HTML Files (*.htm;*.html)|*.htm;*.htm";
					break;
				case 1:
					_dlgSaveFile.DefaultExt = "htm";
					_dlgSaveFile.Filter = "PDF Files (*.pdf)|*.pdf";
					break;
				case 2:
					_dlgSaveFile.DefaultExt = "rtf";
					_dlgSaveFile.Filter = "Rich Text Files (*.rtf)|*.rtf";
					break;
				case 3:
					_dlgSaveFile.DefaultExt = "tif";
					_dlgSaveFile.Filter = "Tiff Image Files (*.tif)|*.tif";
					break;
				case 4:
					_dlgSaveFile.DefaultExt = "txt";
					_dlgSaveFile.Filter = "Text Files (*.txt)|*.txt";
					break;
				case 5:
					_dlgSaveFile.DefaultExt = "xls";
					_dlgSaveFile.Filter = "Microsoft Excel Files (*.xls)|*.xls";
					break;
			}
			if (_dlgSaveFile.ShowDialog() == DialogResult.OK)
			{
				txtFilename.Text = _dlgSaveFile.FileName;
			}
		}
	}
}
