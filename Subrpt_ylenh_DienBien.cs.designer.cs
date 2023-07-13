namespace NamDinh_QLBN.Reports
{
    /// <summary>
    /// Summary description for rptChiPhiPT.
    /// </summary>
    partial class Subrpt_ylenh_dieutri
    {
        private DataDynamics.ActiveReports.PageHeader pageHeader;
        private DataDynamics.ActiveReports.Detail detail;
        private DataDynamics.ActiveReports.PageFooter pageFooter;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region ActiveReport Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Subrpt_ylenh_dieutri));
            this.pageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.textBox11 = new DataDynamics.ActiveReports.TextBox();
            this.detail = new DataDynamics.ActiveReports.Detail();
            this.line9 = new DataDynamics.ActiveReports.Line();
            this.subReport2 = new DataDynamics.ActiveReports.SubReport();
            this.richTextBox1 = new DataDynamics.ActiveReports.RichTextBox();
            this.richTextBox2 = new DataDynamics.ActiveReports.RichTextBox();
            this.pageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.reportHeader1 = new DataDynamics.ActiveReports.ReportHeader();
            this.label1 = new DataDynamics.ActiveReports.Label();
            this.reportFooter1 = new DataDynamics.ActiveReports.ReportFooter();
            this.groupHeader1 = new DataDynamics.ActiveReports.GroupHeader();
            this.groupFooter1 = new DataDynamics.ActiveReports.GroupFooter();
            this.groupHeader2 = new DataDynamics.ActiveReports.GroupHeader();
            this.groupFooter2 = new DataDynamics.ActiveReports.GroupFooter();
            ((System.ComponentModel.ISupportInitialize)(this.textBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            // 
            // pageHeader
            // 
            this.pageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox11});
            this.pageHeader.Height = 0F;
            this.pageHeader.Name = "pageHeader";
            // 
            // textBox11
            // 
            this.textBox11.Alignment = DataDynamics.ActiveReports.TextAlignment.Center;
            this.textBox11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.textBox11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.textBox11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.textBox11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.textBox11.DistinctField = null;
            this.textBox11.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox11.Location = ((System.Drawing.PointF)(resources.GetObject("textBox11.Location")));
            this.textBox11.MultiLine = false;
            this.textBox11.Name = "textBox11";
            this.textBox11.OutputFormat = null;
            this.textBox11.Size = new System.Drawing.SizeF(3.4375F, 0.3125F);
            this.textBox11.Text = "Y LỆNH";
            this.textBox11.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle;
            // 
            // detail
            // 
            this.detail.CanShrink = true;
            this.detail.ColumnSpacing = 0F;
            this.detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.line9,
            this.subReport2,
            this.richTextBox1,
            this.richTextBox2});
            this.detail.Height = 0.25F;
            this.detail.KeepTogether = true;
            this.detail.Name = "detail";
            this.detail.Format += new System.EventHandler(this.detail_Format);
            this.detail.BeforePrint += new System.EventHandler(this.detail_BeforePrint);
            // 
            // line9
            // 
            this.line9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line9.LineWeight = 1F;
            this.line9.Name = "line9";
            this.line9.X1 = 7.625F;
            this.line9.X2 = 7.625F;
            this.line9.Y1 = 0F;
            this.line9.Y2 = 0F;
            // 
            // subReport2
            // 
            this.subReport2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subReport2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subReport2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subReport2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subReport2.CloseBorder = false;
            this.subReport2.Location = ((System.Drawing.PointF)(resources.GetObject("subReport2.Location")));
            this.subReport2.Name = "subReport2";
            this.subReport2.Report = null;
            this.subReport2.ReportName = "subReport1";
            this.subReport2.Size = new System.Drawing.SizeF(3.25F, 0.25F);
            // 
            // richTextBox1
            // 
            this.richTextBox1.AutoReplaceFields = true;
            this.richTextBox1.BackColor = System.Drawing.Color.Transparent;
            this.richTextBox1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.richTextBox1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.richTextBox1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.richTextBox1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.richTextBox1.DataField = "Ylenh";
            this.richTextBox1.Font = new System.Drawing.Font("Arial", 10F);
            this.richTextBox1.ForeColor = System.Drawing.Color.Black;
            this.richTextBox1.Location = ((System.Drawing.PointF)(resources.GetObject("richTextBox1.Location")));
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.RTF = resources.GetString("richTextBox1.RTF");
            this.richTextBox1.SelectedText = "";
            this.richTextBox1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.richTextBox1.SelectionBullet = false;
            this.richTextBox1.SelectionCharOffset = 0F;
            this.richTextBox1.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.richTextBox1.SelectionFont = new System.Drawing.Font("Arial", 10F);
            this.richTextBox1.SelectionHangingIndent = 0F;
            this.richTextBox1.SelectionIndent = 0F;
            this.richTextBox1.SelectionLength = 0;
            this.richTextBox1.SelectionRightIndent = 0F;
            this.richTextBox1.SelectionStart = 0;
            this.richTextBox1.Size = new System.Drawing.SizeF(3F, 0.25F);
            // 
            // richTextBox2
            // 
            this.richTextBox2.AutoReplaceFields = true;
            this.richTextBox2.BackColor = System.Drawing.Color.Transparent;
            this.richTextBox2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.richTextBox2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.richTextBox2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.richTextBox2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.richTextBox2.DataField = "Stt";
            this.richTextBox2.Font = new System.Drawing.Font("Arial", 10F);
            this.richTextBox2.ForeColor = System.Drawing.Color.Black;
            this.richTextBox2.Location = ((System.Drawing.PointF)(resources.GetObject("richTextBox2.Location")));
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.RTF = resources.GetString("richTextBox2.RTF");
            this.richTextBox2.SelectedText = "";
            this.richTextBox2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.richTextBox2.SelectionBullet = false;
            this.richTextBox2.SelectionCharOffset = 0F;
            this.richTextBox2.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.richTextBox2.SelectionFont = new System.Drawing.Font("Arial", 10F);
            this.richTextBox2.SelectionHangingIndent = 0F;
            this.richTextBox2.SelectionIndent = 0F;
            this.richTextBox2.SelectionLength = 0;
            this.richTextBox2.SelectionRightIndent = 0F;
            this.richTextBox2.SelectionStart = 0;
            this.richTextBox2.Size = new System.Drawing.SizeF(0.25F, 0.25F);
            // 
            // pageFooter
            // 
            this.pageFooter.Height = 0F;
            this.pageFooter.Name = "pageFooter";
            this.pageFooter.Format += new System.EventHandler(this.pageFooter_Format);
            // 
            // reportHeader1
            // 
            this.reportHeader1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.label1});
            this.reportHeader1.Height = 0.1875F;
            this.reportHeader1.Name = "reportHeader1";
            // 
            // label1
            // 
            this.label1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.label1.HyperLink = null;
            this.label1.Location = ((System.Drawing.PointF)(resources.GetObject("label1.Location")));
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.SizeF(3.1875F, 0.1875F);
            this.label1.Text = "Thuốc, Hóa chất, Máu, Oxy";
            this.label1.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle;
            // 
            // reportFooter1
            // 
            this.reportFooter1.Height = 0F;
            this.reportFooter1.Name = "reportFooter1";
            // 
            // groupHeader1
            // 
            this.groupHeader1.ColumnGroupKeepTogether = true;
            this.groupHeader1.DataField = "TenLoaiDichvu";
            this.groupHeader1.Height = 0F;
            this.groupHeader1.Name = "groupHeader1";
            this.groupHeader1.BeforePrint += new System.EventHandler(this.groupHeader1_BeforePrint);
            // 
            // groupFooter1
            // 
            this.groupFooter1.Height = 0F;
            this.groupFooter1.Name = "groupFooter1";
            // 
            // groupHeader2
            // 
            this.groupHeader2.ColumnGroupKeepTogether = true;
            this.groupHeader2.DataField = "NgayChiDinh";
            this.groupHeader2.Height = 0F;
            this.groupHeader2.Name = "groupHeader2";
            this.groupHeader2.BeforePrint += new System.EventHandler(this.groupHeader2_BeforePrint);
            // 
            // groupFooter2
            // 
            this.groupFooter2.Height = 0F;
            this.groupFooter2.KeepTogether = true;
            this.groupFooter2.Name = "groupFooter2";
            this.groupFooter2.Format += new System.EventHandler(this.groupFooter2_Format);
            this.groupFooter2.BeforePrint += new System.EventHandler(this.groupFooter2_BeforePrint);
            // 
            // Subrpt_ylenh_dieutri
            // 
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 3.297916F;
            this.Sections.Add(this.reportHeader1);
            this.Sections.Add(this.pageHeader);
            this.Sections.Add(this.groupHeader2);
            this.Sections.Add(this.groupHeader1);
            this.Sections.Add(this.detail);
            this.Sections.Add(this.groupFooter1);
            this.Sections.Add(this.groupFooter2);
            this.Sections.Add(this.pageFooter);
            this.Sections.Add(this.reportFooter1);
            this.FetchData += new DataDynamics.ActiveReports.ActiveReport3.FetchEventHandler(this.Subrpt_ylenh_dieutri_FetchData);
            this.ReportStart += new System.EventHandler(this.rptChiPhiPT_ReportStart);
            this.DataInitialize += new System.EventHandler(this.Subrpt_ylenh_dieutri_DataInitialize);
            ((System.ComponentModel.ISupportInitialize)(this.textBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();

        }
        #endregion

        private DataDynamics.ActiveReports.ReportHeader reportHeader1;
        private DataDynamics.ActiveReports.ReportFooter reportFooter1;
        private DataDynamics.ActiveReports.GroupHeader groupHeader1;
        private DataDynamics.ActiveReports.GroupFooter groupFooter1;
        private DataDynamics.ActiveReports.GroupHeader groupHeader2;
        private DataDynamics.ActiveReports.GroupFooter groupFooter2;
        private DataDynamics.ActiveReports.TextBox textBox11;
        private DataDynamics.ActiveReports.Line line9;
        private DataDynamics.ActiveReports.SubReport subReport2;
        private DataDynamics.ActiveReports.RichTextBox richTextBox1;
        private DataDynamics.ActiveReports.RichTextBox richTextBox2;
        private DataDynamics.ActiveReports.Label label1;
    }
}
