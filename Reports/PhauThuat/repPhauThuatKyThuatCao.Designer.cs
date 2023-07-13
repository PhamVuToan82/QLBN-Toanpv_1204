namespace NamDinh_QLBN.Reports.PhauThuat
{
    /// <summary>
    /// Summary description for repPhauThuatKyThuatCao.
    /// </summary>
    partial class repPhauThuatKyThuatCao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(repPhauThuatKyThuatCao));
            this.pageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.detail = new DataDynamics.ActiveReports.Detail();
            this.pageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.reportHeader1 = new DataDynamics.ActiveReports.ReportHeader();
            this.label10 = new DataDynamics.ActiveReports.Label();
            this.lblNgayThang = new DataDynamics.ActiveReports.Label();
            this.label8 = new DataDynamics.ActiveReports.Label();
            this.label9 = new DataDynamics.ActiveReports.Label();
            this.label4 = new DataDynamics.ActiveReports.Label();
            this.label5 = new DataDynamics.ActiveReports.Label();
            this.label6 = new DataDynamics.ActiveReports.Label();
            this.reportFooter1 = new DataDynamics.ActiveReports.ReportFooter();
            this.label13 = new DataDynamics.ActiveReports.Label();
            this.textBox3 = new DataDynamics.ActiveReports.TextBox();
            this.groupHeader1 = new DataDynamics.ActiveReports.GroupHeader();
            this.label1 = new DataDynamics.ActiveReports.Label();
            this.groupFooter1 = new DataDynamics.ActiveReports.GroupFooter();
            this.label11 = new DataDynamics.ActiveReports.Label();
            this.textBox2 = new DataDynamics.ActiveReports.TextBox();
            this.groupHeader2 = new DataDynamics.ActiveReports.GroupHeader();
            this.textBox1 = new DataDynamics.ActiveReports.TextBox();
            this.STT = new DataDynamics.ActiveReports.TextBox();
            this.textBox5 = new DataDynamics.ActiveReports.TextBox();
            this.groupFooter2 = new DataDynamics.ActiveReports.GroupFooter();
            this.label2 = new DataDynamics.ActiveReports.Label();
            ((System.ComponentModel.ISupportInitialize)(this.label10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNgayThang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.STT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).BeginInit();
            // 
            // pageHeader
            // 
            this.pageHeader.Height = 0F;
            this.pageHeader.Name = "pageHeader";
            // 
            // detail
            // 
            this.detail.ColumnSpacing = 0F;
            this.detail.Height = 0F;
            this.detail.Name = "detail";
            this.detail.Visible = false;
            // 
            // pageFooter
            // 
            this.pageFooter.Height = 0F;
            this.pageFooter.Name = "pageFooter";
            // 
            // reportHeader1
            // 
            this.reportHeader1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.label10,
            this.lblNgayThang,
            this.label8,
            this.label9,
            this.label4,
            this.label5,
            this.label6});
            this.reportHeader1.Height = 1.416667F;
            this.reportHeader1.Name = "reportHeader1";
            // 
            // label10
            // 
            this.label10.Alignment = DataDynamics.ActiveReports.TextAlignment.Center;
            this.label10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.HyperLink = null;
            this.label10.Location = ((System.Drawing.PointF)(resources.GetObject("label10.Location")));
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.SizeF(3.8125F, 0.625F);
            this.label10.Text = "BÁO CÁO TÌNH HÌNH PHẪU THUẬT KỸ THUẬT CAO";
            this.label10.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle;
            // 
            // lblNgayThang
            // 
            this.lblNgayThang.Alignment = DataDynamics.ActiveReports.TextAlignment.Center;
            this.lblNgayThang.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblNgayThang.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblNgayThang.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblNgayThang.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblNgayThang.DataField = "BatThuongTrangNgay";
            this.lblNgayThang.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayThang.HyperLink = null;
            this.lblNgayThang.Location = ((System.Drawing.PointF)(resources.GetObject("lblNgayThang.Location")));
            this.lblNgayThang.Name = "lblNgayThang";
            this.lblNgayThang.Size = new System.Drawing.SizeF(3.6875F, 0.1875F);
            this.lblNgayThang.Text = "";
            this.lblNgayThang.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle;
            // 
            // label8
            // 
            this.label8.Alignment = DataDynamics.ActiveReports.TextAlignment.Center;
            this.label8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.label8.HyperLink = null;
            this.label8.Location = ((System.Drawing.PointF)(resources.GetObject("label8.Location")));
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.SizeF(2.3125F, 0.25F);
            this.label8.Text = "SỞ Y TẾ NAM ĐỊNH";
            this.label8.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle;
            // 
            // label9
            // 
            this.label9.Alignment = DataDynamics.ActiveReports.TextAlignment.Center;
            this.label9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.label9.HyperLink = null;
            this.label9.Location = ((System.Drawing.PointF)(resources.GetObject("label9.Location")));
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.SizeF(2.3125F, 0.25F);
            this.label9.Text = "BỆNH VIỆN ĐA KHOA TỈNH";
            this.label9.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle;
            // 
            // label4
            // 
            this.label4.Alignment = DataDynamics.ActiveReports.TextAlignment.Center;
            this.label4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.label4.HyperLink = null;
            this.label4.Location = ((System.Drawing.PointF)(resources.GetObject("label4.Location")));
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.SizeF(0.4375F, 0.25F);
            this.label4.Text = "STT";
            this.label4.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle;
            // 
            // label5
            // 
            this.label5.Alignment = DataDynamics.ActiveReports.TextAlignment.Center;
            this.label5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.label5.HyperLink = null;
            this.label5.Location = ((System.Drawing.PointF)(resources.GetObject("label5.Location")));
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.SizeF(5.125F, 0.25F);
            this.label5.Text = "TÊN KHOA";
            this.label5.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle;
            // 
            // label6
            // 
            this.label6.Alignment = DataDynamics.ActiveReports.TextAlignment.Center;
            this.label6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.label6.HyperLink = null;
            this.label6.Location = ((System.Drawing.PointF)(resources.GetObject("label6.Location")));
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.SizeF(1.75F, 0.25F);
            this.label6.Text = "SỐ LƯỢNG";
            this.label6.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle;
            // 
            // reportFooter1
            // 
            this.reportFooter1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.label13,
            this.textBox3});
            this.reportFooter1.Height = 0.9375F;
            this.reportFooter1.Name = "reportFooter1";
            // 
            // label13
            // 
            this.label13.Alignment = DataDynamics.ActiveReports.TextAlignment.Right;
            this.label13.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label13.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label13.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label13.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label13.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.HyperLink = null;
            this.label13.Location = ((System.Drawing.PointF)(resources.GetObject("label13.Location")));
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.SizeF(5.5625F, 0.25F);
            this.label13.Text = "TỔNG CỘNG";
            this.label13.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle;
            // 
            // textBox3
            // 
            this.textBox3.Alignment = DataDynamics.ActiveReports.TextAlignment.Center;
            this.textBox3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.textBox3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.textBox3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.textBox3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.textBox3.DataField = "MAPT";
            this.textBox3.DistinctField = null;
            this.textBox3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = ((System.Drawing.PointF)(resources.GetObject("textBox3.Location")));
            this.textBox3.Name = "textBox3";
            this.textBox3.OutputFormat = null;
            this.textBox3.Size = new System.Drawing.SizeF(1.75F, 0.25F);
            this.textBox3.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
            this.textBox3.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox3.Text = "textBox1";
            this.textBox3.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle;
            // 
            // groupHeader1
            // 
            this.groupHeader1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.label1,
            this.label2});
            this.groupHeader1.DataField = "KHOI";
            this.groupHeader1.Height = 0.2604167F;
            this.groupHeader1.Name = "groupHeader1";
            this.groupHeader1.Format += new System.EventHandler(this.groupHeader1_Format);
            // 
            // label1
            // 
            this.label1.Alignment = DataDynamics.ActiveReports.TextAlignment.Center;
            this.label1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.label1.HyperLink = null;
            this.label1.Location = ((System.Drawing.PointF)(resources.GetObject("label1.Location")));
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.SizeF(0.4375F, 0.25F);
            this.label1.Text = "";
            this.label1.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle;
            // 
            // groupFooter1
            // 
            this.groupFooter1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.label11,
            this.textBox2});
            this.groupFooter1.Height = 0.25F;
            this.groupFooter1.Name = "groupFooter1";
            // 
            // label11
            // 
            this.label11.Alignment = DataDynamics.ActiveReports.TextAlignment.Right;
            this.label11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.HyperLink = null;
            this.label11.Location = ((System.Drawing.PointF)(resources.GetObject("label11.Location")));
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.SizeF(5.5625F, 0.25F);
            this.label11.Text = "TỔNG";
            this.label11.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle;
            // 
            // textBox2
            // 
            this.textBox2.Alignment = DataDynamics.ActiveReports.TextAlignment.Center;
            this.textBox2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.textBox2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.textBox2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.textBox2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.textBox2.DataField = "MAPT";
            this.textBox2.DistinctField = null;
            this.textBox2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = ((System.Drawing.PointF)(resources.GetObject("textBox2.Location")));
            this.textBox2.Name = "textBox2";
            this.textBox2.OutputFormat = null;
            this.textBox2.Size = new System.Drawing.SizeF(1.75F, 0.25F);
            this.textBox2.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
            this.textBox2.SummaryGroup = "groupHeader1";
            this.textBox2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox2.Text = "textBox1";
            this.textBox2.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle;
            // 
            // groupHeader2
            // 
            this.groupHeader2.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox1,
            this.STT,
            this.textBox5});
            this.groupHeader2.DataField = "MAPT";
            this.groupHeader2.Height = 0.25F;
            this.groupHeader2.Name = "groupHeader2";
            this.groupHeader2.Format += new System.EventHandler(this.groupHeader2_Format);
            // 
            // textBox1
            // 
            this.textBox1.Alignment = DataDynamics.ActiveReports.TextAlignment.Center;
            this.textBox1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.textBox1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.textBox1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.textBox1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.textBox1.DataField = "MAPT";
            this.textBox1.DistinctField = null;
            this.textBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = ((System.Drawing.PointF)(resources.GetObject("textBox1.Location")));
            this.textBox1.Name = "textBox1";
            this.textBox1.OutputFormat = null;
            this.textBox1.Size = new System.Drawing.SizeF(1.75F, 0.25F);
            this.textBox1.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
            this.textBox1.SummaryGroup = "groupHeader2";
            this.textBox1.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox1.Text = "textBox1";
            this.textBox1.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle;
            // 
            // STT
            // 
            this.STT.Alignment = DataDynamics.ActiveReports.TextAlignment.Center;
            this.STT.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.STT.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.STT.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.STT.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.STT.DistinctField = null;
            this.STT.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.STT.Location = ((System.Drawing.PointF)(resources.GetObject("STT.Location")));
            this.STT.Name = "STT";
            this.STT.OutputFormat = null;
            this.STT.Size = new System.Drawing.SizeF(0.4375F, 0.25F);
            this.STT.Text = "0";
            this.STT.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle;
            // 
            // textBox5
            // 
            this.textBox5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.textBox5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.textBox5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.textBox5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.textBox5.DataField = "TENDICHVU";
            this.textBox5.DistinctField = null;
            this.textBox5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox5.Location = ((System.Drawing.PointF)(resources.GetObject("textBox5.Location")));
            this.textBox5.Name = "textBox5";
            this.textBox5.OutputFormat = null;
            this.textBox5.Size = new System.Drawing.SizeF(5.125F, 0.25F);
            this.textBox5.Text = "textBox1";
            this.textBox5.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle;
            // 
            // groupFooter2
            // 
            this.groupFooter2.Height = 0F;
            this.groupFooter2.Name = "groupFooter2";
            // 
            // label2
            // 
            this.label2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label2.DataField = "TENKHOI";
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.label2.HyperLink = null;
            this.label2.Location = ((System.Drawing.PointF)(resources.GetObject("label2.Location")));
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.SizeF(6.875F, 0.25F);
            this.label2.Text = "";
            this.label2.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle;
            // 
            // repPhauThuatKyThuatCao
            // 
            this.PageSettings.PaperHeight = 11.69F;
            this.PageSettings.PaperWidth = 8.27F;
            this.PrintWidth = 7.40625F;
            this.Sections.Add(this.reportHeader1);
            this.Sections.Add(this.pageHeader);
            this.Sections.Add(this.groupHeader1);
            this.Sections.Add(this.groupHeader2);
            this.Sections.Add(this.detail);
            this.Sections.Add(this.groupFooter2);
            this.Sections.Add(this.groupFooter1);
            this.Sections.Add(this.pageFooter);
            this.Sections.Add(this.reportFooter1);
            this.DataInitialize += new System.EventHandler(this.repPhauThuatKyThuatCao_DataInitialize);
            ((System.ComponentModel.ISupportInitialize)(this.label10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNgayThang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.STT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).EndInit();

        }
        #endregion

        private DataDynamics.ActiveReports.ReportHeader reportHeader1;
        private DataDynamics.ActiveReports.ReportFooter reportFooter1;
        private DataDynamics.ActiveReports.Label label10;
        private DataDynamics.ActiveReports.Label lblNgayThang;
        private DataDynamics.ActiveReports.Label label8;
        private DataDynamics.ActiveReports.Label label9;
        private DataDynamics.ActiveReports.GroupHeader groupHeader1;
        private DataDynamics.ActiveReports.GroupFooter groupFooter1;
        private DataDynamics.ActiveReports.GroupHeader groupHeader2;
        private DataDynamics.ActiveReports.GroupFooter groupFooter2;
        private DataDynamics.ActiveReports.Label label1;
        private DataDynamics.ActiveReports.Label label4;
        private DataDynamics.ActiveReports.Label label5;
        private DataDynamics.ActiveReports.Label label6;
        private DataDynamics.ActiveReports.TextBox textBox1;
        private DataDynamics.ActiveReports.Label label13;
        private DataDynamics.ActiveReports.TextBox textBox3;
        private DataDynamics.ActiveReports.Label label11;
        private DataDynamics.ActiveReports.TextBox textBox2;
        private DataDynamics.ActiveReports.TextBox STT;
        private DataDynamics.ActiveReports.TextBox textBox5;
        private DataDynamics.ActiveReports.Label label2;
    }
}
