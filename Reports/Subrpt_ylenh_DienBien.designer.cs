namespace NamDinh_QLBN.Reports
{
    /// <summary>
    /// Summary description for rptChiPhiPT.
    /// </summary>
    partial class Subrpt_ylenh_DienBien
    {
        private DataDynamics.ActiveReports.PageHeader pageHeader;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Subrpt_ylenh_DienBien));
            this.pageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.textBox11 = new DataDynamics.ActiveReports.TextBox();
            this.detail = new DataDynamics.ActiveReports.Detail();
            this.line9 = new DataDynamics.ActiveReports.Line();
            this.textBox1 = new DataDynamics.ActiveReports.TextBox();
            this.pageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.reportHeader1 = new DataDynamics.ActiveReports.ReportHeader();
            this.reportFooter1 = new DataDynamics.ActiveReports.ReportFooter();
            this.groupHeader1 = new DataDynamics.ActiveReports.GroupHeader();
            this.textBox2 = new DataDynamics.ActiveReports.TextBox();
            this.groupFooter1 = new DataDynamics.ActiveReports.GroupFooter();
            this.groupHeader2 = new DataDynamics.ActiveReports.GroupHeader();
            this.textBox3 = new DataDynamics.ActiveReports.TextBox();
            this.groupFooter2 = new DataDynamics.ActiveReports.GroupFooter();
            this.richTextBox1 = new DataDynamics.ActiveReports.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.textBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).BeginInit();
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
            this.detail.ColumnSpacing = 0F;
            this.detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.line9,
            this.textBox1});
            this.detail.Height = 0.2291667F;
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
            // textBox1
            // 
            this.textBox1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox1.DataField = "DienBienBenh";
            this.textBox1.DistinctField = null;
            this.textBox1.Font = new System.Drawing.Font("Arial", 10F);
            this.textBox1.Location = ((System.Drawing.PointF)(resources.GetObject("textBox1.Location")));
            this.textBox1.Name = "textBox1";
            this.textBox1.OutputFormat = null;
            this.textBox1.Size = new System.Drawing.SizeF(3.125F, 0.25F);
            this.textBox1.SummaryGroup = "groupHeader2";
            this.textBox1.Text = null;
            // 
            // pageFooter
            // 
            this.pageFooter.Height = 0F;
            this.pageFooter.Name = "pageFooter";
            this.pageFooter.Format += new System.EventHandler(this.pageFooter_Format);
            // 
            // reportHeader1
            // 
            this.reportHeader1.Height = 0F;
            this.reportHeader1.Name = "reportHeader1";
            // 
            // reportFooter1
            // 
            this.reportFooter1.Height = 0F;
            this.reportFooter1.Name = "reportFooter1";
            // 
            // groupHeader1
            // 
            this.groupHeader1.ColumnGroupKeepTogether = true;
            this.groupHeader1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox2});
            this.groupHeader1.DataField = "TenLoaiDichvu";
            this.groupHeader1.Height = 0.25F;
            this.groupHeader1.Name = "groupHeader1";
            this.groupHeader1.BeforePrint += new System.EventHandler(this.groupHeader1_BeforePrint);
            // 
            // textBox2
            // 
            this.textBox2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox2.DataField = "TenLoaiDichvu";
            this.textBox2.DistinctField = null;
            this.textBox2.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.textBox2.Location = ((System.Drawing.PointF)(resources.GetObject("textBox2.Location")));
            this.textBox2.Name = "textBox2";
            this.textBox2.OutputFormat = null;
            this.textBox2.Size = new System.Drawing.SizeF(3.125F, 0.25F);
            this.textBox2.SummaryGroup = "groupHeader2";
            this.textBox2.Text = null;
            // 
            // groupFooter1
            // 
            this.groupFooter1.Height = 0F;
            this.groupFooter1.Name = "groupFooter1";
            // 
            // groupHeader2
            // 
            this.groupHeader2.ColumnGroupKeepTogether = true;
            this.groupHeader2.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox3,
            this.richTextBox1});
            this.groupHeader2.DataField = "NgayChiDinh";
            this.groupHeader2.Height = 0.5F;
            this.groupHeader2.Name = "groupHeader2";
            this.groupHeader2.BeforePrint += new System.EventHandler(this.groupHeader2_BeforePrint);
            // 
            // textBox3
            // 
            this.textBox3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox3.DataField = "NgayChiDinh";
            this.textBox3.DistinctField = null;
            this.textBox3.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.textBox3.Location = ((System.Drawing.PointF)(resources.GetObject("textBox3.Location")));
            this.textBox3.Name = "textBox3";
            this.textBox3.OutputFormat = null;
            this.textBox3.Size = new System.Drawing.SizeF(3.125F, 0.25F);
            this.textBox3.SummaryGroup = "groupHeader2";
            this.textBox3.Text = null;
            // 
            // groupFooter2
            // 
            this.groupFooter2.Height = 0F;
            this.groupFooter2.KeepTogether = true;
            this.groupFooter2.Name = "groupFooter2";
            this.groupFooter2.Format += new System.EventHandler(this.groupFooter2_Format);
            this.groupFooter2.BeforePrint += new System.EventHandler(this.groupFooter2_BeforePrint);
            // 
            // richTextBox1
            // 
            this.richTextBox1.AutoReplaceFields = true;
            this.richTextBox1.BackColor = System.Drawing.Color.Transparent;
            this.richTextBox1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.richTextBox1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.richTextBox1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.richTextBox1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.richTextBox1.DataField = "DienBien";
            this.richTextBox1.Font = new System.Drawing.Font("Arial", 10F);
            this.richTextBox1.ForeColor = System.Drawing.Color.Black;
            this.richTextBox1.Location = ((System.Drawing.PointF)(resources.GetObject("richTextBox1.Location")));
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.RTF = resources.GetString("richTextBox1.RTF");
            this.richTextBox1.SelectedText = "";
            this.richTextBox1.SelectionBackColor = System.Drawing.Color.Empty;
            this.richTextBox1.SelectionBullet = false;
            this.richTextBox1.SelectionCharOffset = 0F;
            this.richTextBox1.SelectionColor = System.Drawing.Color.Empty;
            this.richTextBox1.SelectionFont = new System.Drawing.Font("Arial", 10F);
            this.richTextBox1.SelectionHangingIndent = 0F;
            this.richTextBox1.SelectionIndent = 0F;
            this.richTextBox1.SelectionLength = 0;
            this.richTextBox1.SelectionRightIndent = 0F;
            this.richTextBox1.SelectionStart = 0;
            this.richTextBox1.Size = new System.Drawing.SizeF(3.125F, 0.25F);
            // 
            // Subrpt_ylenh_DienBien
            // 
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 3.224999F;
            this.Sections.Add(this.reportHeader1);
            this.Sections.Add(this.pageHeader);
            this.Sections.Add(this.groupHeader2);
            this.Sections.Add(this.groupHeader1);
            this.Sections.Add(this.detail);
            this.Sections.Add(this.groupFooter1);
            this.Sections.Add(this.groupFooter2);
            this.Sections.Add(this.pageFooter);
            this.Sections.Add(this.reportFooter1);
            this.FetchData += new DataDynamics.ActiveReports.ActiveReport3.FetchEventHandler(this.Subrpt_ylenh_DienBien_FetchData);
            this.ReportStart += new System.EventHandler(this.rptChiPhiPT_ReportStart);
            this.DataInitialize += new System.EventHandler(this.Subrpt_ylenh_DienBien_DataInitialize);
            ((System.ComponentModel.ISupportInitialize)(this.textBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).EndInit();

        }
        #endregion

        private DataDynamics.ActiveReports.ReportHeader reportHeader1;
        private DataDynamics.ActiveReports.ReportFooter reportFooter1;
        private DataDynamics.ActiveReports.GroupFooter groupFooter1;
        private DataDynamics.ActiveReports.GroupFooter groupFooter2;
        private DataDynamics.ActiveReports.TextBox textBox11;
        private DataDynamics.ActiveReports.Line line9;
        private DataDynamics.ActiveReports.TextBox textBox1;
        private DataDynamics.ActiveReports.TextBox textBox2;
        private DataDynamics.ActiveReports.TextBox textBox3;
        public DataDynamics.ActiveReports.GroupHeader groupHeader2;
        public DataDynamics.ActiveReports.GroupHeader groupHeader1;
        public DataDynamics.ActiveReports.Detail detail;
        private DataDynamics.ActiveReports.RichTextBox richTextBox1;
    }
}
