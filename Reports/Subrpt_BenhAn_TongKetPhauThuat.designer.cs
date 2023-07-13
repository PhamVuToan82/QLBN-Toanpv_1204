namespace NamDinh_QLBN.Reports
{
    /// <summary>
    /// Summary description for rptChiPhiPT.
    /// </summary>
    partial class Subrpt_BenhAn_TongKetPhauThuat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Subrpt_BenhAn_TongKetPhauThuat));
            this.pageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.textBox11 = new DataDynamics.ActiveReports.TextBox();
            this.detail = new DataDynamics.ActiveReports.Detail();
            this.line9 = new DataDynamics.ActiveReports.Line();
            this.textBox5 = new DataDynamics.ActiveReports.TextBox();
            this.textBox6 = new DataDynamics.ActiveReports.TextBox();
            this.textBox7 = new DataDynamics.ActiveReports.TextBox();
            this.textBox8 = new DataDynamics.ActiveReports.TextBox();
            this.pageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.reportHeader1 = new DataDynamics.ActiveReports.ReportHeader();
            this.reportFooter1 = new DataDynamics.ActiveReports.ReportFooter();
            this.groupHeader1 = new DataDynamics.ActiveReports.GroupHeader();
            this.textBox1 = new DataDynamics.ActiveReports.TextBox();
            this.textBox2 = new DataDynamics.ActiveReports.TextBox();
            this.textBox3 = new DataDynamics.ActiveReports.TextBox();
            this.textBox4 = new DataDynamics.ActiveReports.TextBox();
            this.groupFooter1 = new DataDynamics.ActiveReports.GroupFooter();
            this.groupHeader2 = new DataDynamics.ActiveReports.GroupHeader();
            this.groupFooter2 = new DataDynamics.ActiveReports.GroupFooter();
            ((System.ComponentModel.ISupportInitialize)(this.textBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).BeginInit();
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
            this.textBox5,
            this.textBox6,
            this.textBox7,
            this.textBox8});
            this.detail.Height = 0.1770833F;
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
            // textBox5
            // 
            this.textBox5.Alignment = DataDynamics.ActiveReports.TextAlignment.Center;
            this.textBox5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.textBox5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.textBox5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.textBox5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.textBox5.DataField = "ThoiGianKT";
            this.textBox5.DistinctField = null;
            this.textBox5.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Italic);
            this.textBox5.Location = ((System.Drawing.PointF)(resources.GetObject("textBox5.Location")));
            this.textBox5.Name = "textBox5";
            this.textBox5.OutputFormat = null;
            this.textBox5.Size = new System.Drawing.SizeF(1.875F, 0.1875F);
            this.textBox5.Text = null;
            this.textBox5.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle;
            // 
            // textBox6
            // 
            this.textBox6.Alignment = DataDynamics.ActiveReports.TextAlignment.Center;
            this.textBox6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.textBox6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.textBox6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.textBox6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.textBox6.DataField = "PhuongPhapPT";
            this.textBox6.DistinctField = null;
            this.textBox6.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Italic);
            this.textBox6.Location = ((System.Drawing.PointF)(resources.GetObject("textBox6.Location")));
            this.textBox6.Name = "textBox6";
            this.textBox6.OutputFormat = null;
            this.textBox6.Size = new System.Drawing.SizeF(3.3125F, 0.1875F);
            this.textBox6.Text = null;
            this.textBox6.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle;
            // 
            // textBox7
            // 
            this.textBox7.Alignment = DataDynamics.ActiveReports.TextAlignment.Center;
            this.textBox7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.textBox7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.textBox7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.textBox7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.textBox7.DataField = "BSMo";
            this.textBox7.DistinctField = null;
            this.textBox7.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Italic);
            this.textBox7.Location = ((System.Drawing.PointF)(resources.GetObject("textBox7.Location")));
            this.textBox7.Name = "textBox7";
            this.textBox7.OutputFormat = null;
            this.textBox7.Size = new System.Drawing.SizeF(1.375F, 0.1875F);
            this.textBox7.Text = null;
            this.textBox7.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle;
            // 
            // textBox8
            // 
            this.textBox8.Alignment = DataDynamics.ActiveReports.TextAlignment.Center;
            this.textBox8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.textBox8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.textBox8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.textBox8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.textBox8.DataField = "BSGayMe";
            this.textBox8.DistinctField = null;
            this.textBox8.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Italic);
            this.textBox8.Location = ((System.Drawing.PointF)(resources.GetObject("textBox8.Location")));
            this.textBox8.Name = "textBox8";
            this.textBox8.OutputFormat = null;
            this.textBox8.Size = new System.Drawing.SizeF(1.177083F, 0.1875F);
            this.textBox8.Text = null;
            this.textBox8.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle;
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
            this.groupHeader1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox1,
            this.textBox2,
            this.textBox3,
            this.textBox4});
            this.groupHeader1.Height = 0.1875F;
            this.groupHeader1.Name = "groupHeader1";
            this.groupHeader1.BeforePrint += new System.EventHandler(this.groupHeader1_BeforePrint);
            // 
            // textBox1
            // 
            this.textBox1.Alignment = DataDynamics.ActiveReports.TextAlignment.Center;
            this.textBox1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.textBox1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.textBox1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.textBox1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.textBox1.DistinctField = null;
            this.textBox1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Italic);
            this.textBox1.Location = ((System.Drawing.PointF)(resources.GetObject("textBox1.Location")));
            this.textBox1.MultiLine = false;
            this.textBox1.Name = "textBox1";
            this.textBox1.OutputFormat = null;
            this.textBox1.Size = new System.Drawing.SizeF(1.875F, 0.1875F);
            this.textBox1.Text = "Giờ, Ngày";
            this.textBox1.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle;
            // 
            // textBox2
            // 
            this.textBox2.Alignment = DataDynamics.ActiveReports.TextAlignment.Center;
            this.textBox2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.textBox2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.textBox2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.textBox2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.textBox2.DistinctField = null;
            this.textBox2.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Italic);
            this.textBox2.Location = ((System.Drawing.PointF)(resources.GetObject("textBox2.Location")));
            this.textBox2.MultiLine = false;
            this.textBox2.Name = "textBox2";
            this.textBox2.OutputFormat = null;
            this.textBox2.Size = new System.Drawing.SizeF(3.3125F, 0.1875F);
            this.textBox2.Text = "Phương pháp phẫu thuật / Vô cảm";
            this.textBox2.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle;
            // 
            // textBox3
            // 
            this.textBox3.Alignment = DataDynamics.ActiveReports.TextAlignment.Center;
            this.textBox3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.textBox3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.textBox3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.textBox3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.textBox3.DistinctField = null;
            this.textBox3.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Italic);
            this.textBox3.Location = ((System.Drawing.PointF)(resources.GetObject("textBox3.Location")));
            this.textBox3.MultiLine = false;
            this.textBox3.Name = "textBox3";
            this.textBox3.OutputFormat = null;
            this.textBox3.Size = new System.Drawing.SizeF(1.375F, 0.1875F);
            this.textBox3.Text = "Bác sỹ phẫu thuật";
            this.textBox3.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle;
            // 
            // textBox4
            // 
            this.textBox4.Alignment = DataDynamics.ActiveReports.TextAlignment.Center;
            this.textBox4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.textBox4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.textBox4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.textBox4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.textBox4.DistinctField = null;
            this.textBox4.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Italic);
            this.textBox4.Location = ((System.Drawing.PointF)(resources.GetObject("textBox4.Location")));
            this.textBox4.MultiLine = false;
            this.textBox4.Name = "textBox4";
            this.textBox4.OutputFormat = null;
            this.textBox4.Size = new System.Drawing.SizeF(1.177083F, 0.1875F);
            this.textBox4.Text = "Bác sỹ gây mê";
            this.textBox4.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle;
            // 
            // groupFooter1
            // 
            this.groupFooter1.Height = 0F;
            this.groupFooter1.Name = "groupFooter1";
            // 
            // groupHeader2
            // 
            this.groupHeader2.Height = 0F;
            this.groupHeader2.Name = "groupHeader2";
            this.groupHeader2.BeforePrint += new System.EventHandler(this.groupHeader2_BeforePrint);
            // 
            // groupFooter2
            // 
            this.groupFooter2.Height = 0F;
            this.groupFooter2.Name = "groupFooter2";
            this.groupFooter2.Format += new System.EventHandler(this.groupFooter2_Format);
            this.groupFooter2.BeforePrint += new System.EventHandler(this.groupFooter2_BeforePrint);
            // 
            // Subrpt_BenhAn_TongKetPhauThuat
            // 
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 7.760417F;
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
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).EndInit();

        }
        #endregion

        private DataDynamics.ActiveReports.ReportHeader reportHeader1;
        private DataDynamics.ActiveReports.ReportFooter reportFooter1;
        private DataDynamics.ActiveReports.GroupFooter groupFooter1;
        private DataDynamics.ActiveReports.GroupFooter groupFooter2;
        private DataDynamics.ActiveReports.TextBox textBox11;
        private DataDynamics.ActiveReports.Line line9;
        public DataDynamics.ActiveReports.GroupHeader groupHeader2;
        public DataDynamics.ActiveReports.GroupHeader groupHeader1;
        public DataDynamics.ActiveReports.Detail detail;
        private DataDynamics.ActiveReports.TextBox textBox1;
        private DataDynamics.ActiveReports.TextBox textBox2;
        private DataDynamics.ActiveReports.TextBox textBox3;
        private DataDynamics.ActiveReports.TextBox textBox4;
        private DataDynamics.ActiveReports.TextBox textBox5;
        private DataDynamics.ActiveReports.TextBox textBox6;
        private DataDynamics.ActiveReports.TextBox textBox7;
        private DataDynamics.ActiveReports.TextBox textBox8;
    }
}
