namespace NamDinh_QLBN.Reports
{
    /// <summary>
    /// Summary description for rptBenhNhanRaVien.
    /// </summary>
    partial class rptBenhNhanRaVien
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rptBenhNhanRaVien));
            this.pageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.label3 = new DataDynamics.ActiveReports.Label();
            this.label2 = new DataDynamics.ActiveReports.Label();
            this.label1 = new DataDynamics.ActiveReports.Label();
            this.label4 = new DataDynamics.ActiveReports.Label();
            this.label5 = new DataDynamics.ActiveReports.Label();
            this.label7 = new DataDynamics.ActiveReports.Label();
            this.label6 = new DataDynamics.ActiveReports.Label();
            this.detail = new DataDynamics.ActiveReports.Detail();
            this.txtSTT = new DataDynamics.ActiveReports.TextBox();
            this.textBox1 = new DataDynamics.ActiveReports.TextBox();
            this.textBox2 = new DataDynamics.ActiveReports.TextBox();
            this.textBox3 = new DataDynamics.ActiveReports.TextBox();
            this.textBox4 = new DataDynamics.ActiveReports.TextBox();
            this.textBox5 = new DataDynamics.ActiveReports.TextBox();
            this.textBox6 = new DataDynamics.ActiveReports.TextBox();
            this.pageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.reportHeader1 = new DataDynamics.ActiveReports.ReportHeader();
            this.lblNgayThang = new DataDynamics.ActiveReports.Label();
            this.label12 = new DataDynamics.ActiveReports.Label();
            this.label11 = new DataDynamics.ActiveReports.Label();
            this.line1 = new DataDynamics.ActiveReports.Line();
            this.lblTenKhoa = new DataDynamics.ActiveReports.Label();
            this.reportFooter1 = new DataDynamics.ActiveReports.ReportFooter();
            ((System.ComponentModel.ISupportInitialize)(this.label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSTT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNgayThang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTenKhoa)).BeginInit();
            // 
            // pageHeader
            // 
            this.pageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.label3,
            this.label2,
            this.label1,
            this.label4,
            this.label5,
            this.label7,
            this.label6});
            this.pageHeader.Height = 0.25F;
            this.pageHeader.Name = "pageHeader";
            // 
            // label3
            // 
            this.label3.Alignment = DataDynamics.ActiveReports.TextAlignment.Center;
            this.label3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.label3.HyperLink = null;
            this.label3.Location = ((System.Drawing.PointF)(resources.GetObject("label3.Location")));
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.SizeF(2.4375F, 0.25F);
            this.label3.Text = "HỌ VÀ TÊN";
            this.label3.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Bottom;
            // 
            // label2
            // 
            this.label2.Alignment = DataDynamics.ActiveReports.TextAlignment.Center;
            this.label2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.label2.HyperLink = null;
            this.label2.Location = ((System.Drawing.PointF)(resources.GetObject("label2.Location")));
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.SizeF(1F, 0.25F);
            this.label2.Text = "NGÀY VÀO";
            this.label2.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Bottom;
            // 
            // label1
            // 
            this.label1.Alignment = DataDynamics.ActiveReports.TextAlignment.Center;
            this.label1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.label1.HyperLink = null;
            this.label1.Location = ((System.Drawing.PointF)(resources.GetObject("label1.Location")));
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.SizeF(0.4375F, 0.25F);
            this.label1.Text = "STT";
            this.label1.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Bottom;
            // 
            // label4
            // 
            this.label4.Alignment = DataDynamics.ActiveReports.TextAlignment.Center;
            this.label4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.label4.HyperLink = null;
            this.label4.Location = ((System.Drawing.PointF)(resources.GetObject("label4.Location")));
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.SizeF(0.5625F, 0.25F);
            this.label4.Text = "GIỚI";
            this.label4.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Bottom;
            // 
            // label5
            // 
            this.label5.Alignment = DataDynamics.ActiveReports.TextAlignment.Center;
            this.label5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.label5.HyperLink = null;
            this.label5.Location = ((System.Drawing.PointF)(resources.GetObject("label5.Location")));
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.SizeF(0.4375F, 0.25F);
            this.label5.Text = "TUỔI";
            this.label5.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Bottom;
            // 
            // label7
            // 
            this.label7.Alignment = DataDynamics.ActiveReports.TextAlignment.Center;
            this.label7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.label7.HyperLink = null;
            this.label7.Location = ((System.Drawing.PointF)(resources.GetObject("label7.Location")));
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.SizeF(1.0625F, 0.25F);
            this.label7.Text = "NGÀY RA";
            this.label7.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Bottom;
            // 
            // label6
            // 
            this.label6.Alignment = DataDynamics.ActiveReports.TextAlignment.Center;
            this.label6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.label6.HyperLink = null;
            this.label6.Location = ((System.Drawing.PointF)(resources.GetObject("label6.Location")));
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.SizeF(1.125F, 0.25F);
            this.label6.Text = "ĐỐI TƯỢNG";
            this.label6.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Bottom;
            // 
            // detail
            // 
            this.detail.ColumnSpacing = 0F;
            this.detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.txtSTT,
            this.textBox1,
            this.textBox2,
            this.textBox3,
            this.textBox4,
            this.textBox5,
            this.textBox6});
            this.detail.Height = 0.2604167F;
            this.detail.Name = "detail";
            this.detail.Format += new System.EventHandler(this.detail_Format);
            // 
            // txtSTT
            // 
            this.txtSTT.Alignment = DataDynamics.ActiveReports.TextAlignment.Right;
            this.txtSTT.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Dot;
            this.txtSTT.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.txtSTT.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSTT.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.txtSTT.DistinctField = null;
            this.txtSTT.Font = new System.Drawing.Font("Arial", 11F);
            this.txtSTT.Location = ((System.Drawing.PointF)(resources.GetObject("txtSTT.Location")));
            this.txtSTT.Name = "txtSTT";
            this.txtSTT.OutputFormat = null;
            this.txtSTT.Size = new System.Drawing.SizeF(0.4375F, 0.25F);
            this.txtSTT.Text = "0";
            this.txtSTT.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Bottom;
            // 
            // textBox1
            // 
            this.textBox1.Alignment = DataDynamics.ActiveReports.TextAlignment.Center;
            this.textBox1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Dot;
            this.textBox1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.textBox1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.textBox1.DataField = "NgayVaoVien";
            this.textBox1.DistinctField = null;
            this.textBox1.Font = new System.Drawing.Font("Arial", 11F);
            this.textBox1.Location = ((System.Drawing.PointF)(resources.GetObject("textBox1.Location")));
            this.textBox1.Name = "textBox1";
            this.textBox1.OutputFormat = "dd/MM/yyyy";
            this.textBox1.Size = new System.Drawing.SizeF(1F, 0.25F);
            this.textBox1.Text = "0";
            this.textBox1.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Bottom;
            // 
            // textBox2
            // 
            this.textBox2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Dot;
            this.textBox2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.textBox2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.textBox2.DataField = "TenBenhNhan";
            this.textBox2.DistinctField = null;
            this.textBox2.Font = new System.Drawing.Font("Arial", 11F);
            this.textBox2.Location = ((System.Drawing.PointF)(resources.GetObject("textBox2.Location")));
            this.textBox2.Name = "textBox2";
            this.textBox2.OutputFormat = null;
            this.textBox2.Size = new System.Drawing.SizeF(2.4375F, 0.25F);
            this.textBox2.Text = "0";
            this.textBox2.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Bottom;
            // 
            // textBox3
            // 
            this.textBox3.Alignment = DataDynamics.ActiveReports.TextAlignment.Right;
            this.textBox3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Dot;
            this.textBox3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.textBox3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.textBox3.DataField = "Tuoi";
            this.textBox3.DistinctField = null;
            this.textBox3.Font = new System.Drawing.Font("Arial", 11F);
            this.textBox3.Location = ((System.Drawing.PointF)(resources.GetObject("textBox3.Location")));
            this.textBox3.Name = "textBox3";
            this.textBox3.OutputFormat = null;
            this.textBox3.Size = new System.Drawing.SizeF(0.4375F, 0.25F);
            this.textBox3.Text = "0";
            this.textBox3.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Bottom;
            // 
            // textBox4
            // 
            this.textBox4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Dot;
            this.textBox4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.textBox4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.textBox4.DataField = "GioiTinh";
            this.textBox4.DistinctField = null;
            this.textBox4.Font = new System.Drawing.Font("Arial", 11F);
            this.textBox4.Location = ((System.Drawing.PointF)(resources.GetObject("textBox4.Location")));
            this.textBox4.Name = "textBox4";
            this.textBox4.OutputFormat = null;
            this.textBox4.Size = new System.Drawing.SizeF(0.5625F, 0.25F);
            this.textBox4.Text = "0";
            this.textBox4.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Bottom;
            // 
            // textBox5
            // 
            this.textBox5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Dot;
            this.textBox5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.textBox5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.textBox5.DataField = "TenDT";
            this.textBox5.DistinctField = null;
            this.textBox5.Font = new System.Drawing.Font("Arial", 11F);
            this.textBox5.Location = ((System.Drawing.PointF)(resources.GetObject("textBox5.Location")));
            this.textBox5.Name = "textBox5";
            this.textBox5.OutputFormat = null;
            this.textBox5.Size = new System.Drawing.SizeF(1.125F, 0.25F);
            this.textBox5.Text = "0";
            this.textBox5.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Bottom;
            // 
            // textBox6
            // 
            this.textBox6.Alignment = DataDynamics.ActiveReports.TextAlignment.Center;
            this.textBox6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Dot;
            this.textBox6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.textBox6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.textBox6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.textBox6.DataField = "NgayRaVien";
            this.textBox6.DistinctField = null;
            this.textBox6.Font = new System.Drawing.Font("Arial", 11F);
            this.textBox6.Location = ((System.Drawing.PointF)(resources.GetObject("textBox6.Location")));
            this.textBox6.Name = "textBox6";
            this.textBox6.OutputFormat = "dd/MM/yyyy";
            this.textBox6.Size = new System.Drawing.SizeF(1.0625F, 0.25F);
            this.textBox6.Text = "0";
            this.textBox6.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Bottom;
            // 
            // pageFooter
            // 
            this.pageFooter.Height = 0.03125F;
            this.pageFooter.Name = "pageFooter";
            // 
            // reportHeader1
            // 
            this.reportHeader1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.lblNgayThang,
            this.label12,
            this.label11,
            this.line1,
            this.lblTenKhoa});
            this.reportHeader1.Height = 1.322917F;
            this.reportHeader1.Name = "reportHeader1";
            // 
            // lblNgayThang
            // 
            this.lblNgayThang.Alignment = DataDynamics.ActiveReports.TextAlignment.Center;
            this.lblNgayThang.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblNgayThang.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblNgayThang.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblNgayThang.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblNgayThang.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblNgayThang.HyperLink = null;
            this.lblNgayThang.Location = ((System.Drawing.PointF)(resources.GetObject("lblNgayThang.Location")));
            this.lblNgayThang.Name = "lblNgayThang";
            this.lblNgayThang.Size = new System.Drawing.SizeF(7.0625F, 0.25F);
            this.lblNgayThang.Text = "";
            // 
            // label12
            // 
            this.label12.Alignment = DataDynamics.ActiveReports.TextAlignment.Center;
            this.label12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            this.label12.HyperLink = null;
            this.label12.Location = ((System.Drawing.PointF)(resources.GetObject("label12.Location")));
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.SizeF(7.0625F, 0.25F);
            this.label12.Text = "DANH SÁCH BỆNH NHÂN RA VIỆN";
            // 
            // label11
            // 
            this.label11.Alignment = DataDynamics.ActiveReports.TextAlignment.Center;
            this.label11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.label11.HyperLink = null;
            this.label11.Location = ((System.Drawing.PointF)(resources.GetObject("label11.Location")));
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.SizeF(1.875F, 0.4375F);
            this.label11.Text = "BỆNH VIỆN ĐA KHOA TỈNH NAM ĐỊNH";
            // 
            // line1
            // 
            this.line1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line1.LineWeight = 1F;
            this.line1.Name = "line1";
            this.line1.X1 = 0.25F;
            this.line1.X2 = 1.5625F;
            this.line1.Y1 = 0.4375F;
            this.line1.Y2 = 0.4375F;
            // 
            // lblTenKhoa
            // 
            this.lblTenKhoa.Alignment = DataDynamics.ActiveReports.TextAlignment.Center;
            this.lblTenKhoa.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTenKhoa.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTenKhoa.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTenKhoa.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTenKhoa.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.lblTenKhoa.HyperLink = null;
            this.lblTenKhoa.Location = ((System.Drawing.PointF)(resources.GetObject("lblTenKhoa.Location")));
            this.lblTenKhoa.Name = "lblTenKhoa";
            this.lblTenKhoa.Size = new System.Drawing.SizeF(7.0625F, 0.25F);
            this.lblTenKhoa.Text = "";
            // 
            // reportFooter1
            // 
            this.reportFooter1.Height = 0.25F;
            this.reportFooter1.Name = "reportFooter1";
            // 
            // rptBenhNhanRaVien
            // 
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 7.072917F;
            this.Sections.Add(this.reportHeader1);
            this.Sections.Add(this.pageHeader);
            this.Sections.Add(this.detail);
            this.Sections.Add(this.pageFooter);
            this.Sections.Add(this.reportFooter1);
            this.ReportStart += new System.EventHandler(this.rptBenhNhanRaVien_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSTT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNgayThang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTenKhoa)).EndInit();

        }
        #endregion

        private DataDynamics.ActiveReports.Label label3;
        private DataDynamics.ActiveReports.Label label2;
        private DataDynamics.ActiveReports.Label label1;
        private DataDynamics.ActiveReports.Label label4;
        private DataDynamics.ActiveReports.Label label5;
        private DataDynamics.ActiveReports.Label label7;
        private DataDynamics.ActiveReports.Label label6;
        private DataDynamics.ActiveReports.ReportHeader reportHeader1;
        private DataDynamics.ActiveReports.Label lblNgayThang;
        private DataDynamics.ActiveReports.Label label12;
        private DataDynamics.ActiveReports.Label label11;
        private DataDynamics.ActiveReports.Line line1;
        private DataDynamics.ActiveReports.Label lblTenKhoa;
        private DataDynamics.ActiveReports.ReportFooter reportFooter1;
        private DataDynamics.ActiveReports.TextBox txtSTT;
        private DataDynamics.ActiveReports.TextBox textBox1;
        private DataDynamics.ActiveReports.TextBox textBox2;
        private DataDynamics.ActiveReports.TextBox textBox3;
        private DataDynamics.ActiveReports.TextBox textBox4;
        private DataDynamics.ActiveReports.TextBox textBox5;
        private DataDynamics.ActiveReports.TextBox textBox6;
    }
}
