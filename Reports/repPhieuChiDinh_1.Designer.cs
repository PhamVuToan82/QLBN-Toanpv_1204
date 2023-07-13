namespace NamDinh_QLBN.Reports
{
    /// <summary>
    /// Summary description for repPhieuChiDinh.
    /// </summary>
    partial class repPhieuChiDinh
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(repPhieuChiDinh));
            this.pageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.lblNoiChiDinh = new DataDynamics.ActiveReports.Label();
            this.Barcode1 = new DataDynamics.ActiveReports.Barcode();
            this.Label8 = new DataDynamics.ActiveReports.Label();
            this.lblTenBN = new DataDynamics.ActiveReports.Label();
            this.lblTuoi = new DataDynamics.ActiveReports.Label();
            this.lblGioi = new DataDynamics.ActiveReports.Label();
            this.Line2 = new DataDynamics.ActiveReports.Line();
            this.Line3 = new DataDynamics.ActiveReports.Line();
            this.Line4 = new DataDynamics.ActiveReports.Line();
            this.Line6 = new DataDynamics.ActiveReports.Line();
            this.lblChanDoan = new DataDynamics.ActiveReports.Label();
            this.Line8 = new DataDynamics.ActiveReports.Line();
            this.Label14 = new DataDynamics.ActiveReports.Label();
            this.detail = new DataDynamics.ActiveReports.Detail();
            this.TextBox1 = new DataDynamics.ActiveReports.TextBox();
            this.textBox4 = new DataDynamics.ActiveReports.TextBox();
            this.textBox2 = new DataDynamics.ActiveReports.TextBox();
            this.line12 = new DataDynamics.ActiveReports.Line();
            this.pageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.reportHeader1 = new DataDynamics.ActiveReports.ReportHeader();
            this.Line10 = new DataDynamics.ActiveReports.Line();
            this.reportFooter1 = new DataDynamics.ActiveReports.ReportFooter();
            this.groupHeader1 = new DataDynamics.ActiveReports.GroupHeader();
            this.label2 = new DataDynamics.ActiveReports.Label();
            this.label4 = new DataDynamics.ActiveReports.Label();
            this.label5 = new DataDynamics.ActiveReports.Label();
            this.line11 = new DataDynamics.ActiveReports.Line();
            this.groupFooter1 = new DataDynamics.ActiveReports.GroupFooter();
            ((System.ComponentModel.ISupportInitialize)(this.lblNoiChiDinh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTenBN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTuoi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGioi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblChanDoan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).BeginInit();
            // 
            // pageHeader
            // 
            this.pageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.lblNoiChiDinh,
            this.Barcode1,
            this.Label8,
            this.lblTenBN,
            this.lblTuoi,
            this.lblGioi,
            this.Line2,
            this.Line3,
            this.Line4,
            this.Line6,
            this.lblChanDoan,
            this.Line8,
            this.Label14});
            this.pageHeader.Height = 1.625F;
            this.pageHeader.Name = "pageHeader";
            this.pageHeader.Format += new System.EventHandler(this.pageHeader_Format);
            // 
            // lblNoiChiDinh
            // 
            this.lblNoiChiDinh.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblNoiChiDinh.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblNoiChiDinh.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblNoiChiDinh.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblNoiChiDinh.Font = new System.Drawing.Font("Arial", 11F);
            this.lblNoiChiDinh.HyperLink = null;
            this.lblNoiChiDinh.Location = ((System.Drawing.PointF)(resources.GetObject("lblNoiChiDinh.Location")));
            this.lblNoiChiDinh.Name = "lblNoiChiDinh";
            this.lblNoiChiDinh.Size = new System.Drawing.SizeF(7.25F, 0.1875F);
            this.lblNoiChiDinh.Text = "Nơi chỉ định:";
            // 
            // Barcode1
            // 
            this.Barcode1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Barcode1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Barcode1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Barcode1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Barcode1.CaptionPosition = DataDynamics.ActiveReports.BarCodeCaptionPosition.Below;
            this.Barcode1.DataField = "MaVaoVien";
            this.Barcode1.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Barcode1.Location = ((System.Drawing.PointF)(resources.GetObject("Barcode1.Location")));
            this.Barcode1.Name = "Barcode1";
            this.Barcode1.Size = new System.Drawing.SizeF(1.625F, 0.5625F);
            this.Barcode1.Text = "432432432";
            // 
            // Label8
            // 
            this.Label8.Alignment = DataDynamics.ActiveReports.TextAlignment.Center;
            this.Label8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label8.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.Label8.HyperLink = null;
            this.Label8.Location = ((System.Drawing.PointF)(resources.GetObject("Label8.Location")));
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.SizeF(3.25F, 0.375F);
            this.Label8.Text = "PHIẾU THEO DÕI ĐIỀU TRỊ";
            this.Label8.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle;
            // 
            // lblTenBN
            // 
            this.lblTenBN.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTenBN.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTenBN.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTenBN.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTenBN.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenBN.HyperLink = null;
            this.lblTenBN.Location = ((System.Drawing.PointF)(resources.GetObject("lblTenBN.Location")));
            this.lblTenBN.Name = "lblTenBN";
            this.lblTenBN.Size = new System.Drawing.SizeF(3.770833F, 0.1875F);
            this.lblTenBN.Text = "Họ tên BN:";
            // 
            // lblTuoi
            // 
            this.lblTuoi.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTuoi.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTuoi.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTuoi.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTuoi.Font = new System.Drawing.Font("Arial", 11F);
            this.lblTuoi.HyperLink = null;
            this.lblTuoi.Location = ((System.Drawing.PointF)(resources.GetObject("lblTuoi.Location")));
            this.lblTuoi.Name = "lblTuoi";
            this.lblTuoi.Size = new System.Drawing.SizeF(1.125F, 0.1875F);
            this.lblTuoi.Text = "Tuổi:";
            // 
            // lblGioi
            // 
            this.lblGioi.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblGioi.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblGioi.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblGioi.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblGioi.Font = new System.Drawing.Font("Arial", 11F);
            this.lblGioi.HyperLink = null;
            this.lblGioi.Location = ((System.Drawing.PointF)(resources.GetObject("lblGioi.Location")));
            this.lblGioi.Name = "lblGioi";
            this.lblGioi.Size = new System.Drawing.SizeF(1.25F, 0.1875F);
            this.lblGioi.Text = "Giới tính:";
            // 
            // Line2
            // 
            this.Line2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line2.LineStyle = DataDynamics.ActiveReports.LineStyle.Dot;
            this.Line2.LineWeight = 1F;
            this.Line2.Name = "Line2";
            this.Line2.X1 = 1F;
            this.Line2.X2 = 4.625F;
            this.Line2.Y1 = 1F;
            this.Line2.Y2 = 1F;
            // 
            // Line3
            // 
            this.Line3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line3.LineStyle = DataDynamics.ActiveReports.LineStyle.Dot;
            this.Line3.LineWeight = 1F;
            this.Line3.Name = "Line3";
            this.Line3.X1 = 5.25F;
            this.Line3.X2 = 6F;
            this.Line3.Y1 = 1F;
            this.Line3.Y2 = 1F;
            // 
            // Line4
            // 
            this.Line4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line4.LineStyle = DataDynamics.ActiveReports.LineStyle.Dot;
            this.Line4.LineWeight = 1F;
            this.Line4.Name = "Line4";
            this.Line4.X1 = 6.6875F;
            this.Line4.X2 = 7.3125F;
            this.Line4.Y1 = 1F;
            this.Line4.Y2 = 1F;
            // 
            // Line6
            // 
            this.Line6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line6.LineStyle = DataDynamics.ActiveReports.LineStyle.Dot;
            this.Line6.LineWeight = 1F;
            this.Line6.Name = "Line6";
            this.Line6.X1 = 1F;
            this.Line6.X2 = 7.25F;
            this.Line6.Y1 = 1.5625F;
            this.Line6.Y2 = 1.5625F;
            // 
            // lblChanDoan
            // 
            this.lblChanDoan.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblChanDoan.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblChanDoan.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblChanDoan.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblChanDoan.Font = new System.Drawing.Font("Arial", 11F);
            this.lblChanDoan.HyperLink = null;
            this.lblChanDoan.Location = ((System.Drawing.PointF)(resources.GetObject("lblChanDoan.Location")));
            this.lblChanDoan.Name = "lblChanDoan";
            this.lblChanDoan.Size = new System.Drawing.SizeF(7.25F, 0.1875F);
            this.lblChanDoan.Text = "ChanDoan";
            // 
            // Line8
            // 
            this.Line8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line8.LineStyle = DataDynamics.ActiveReports.LineStyle.Dot;
            this.Line8.LineWeight = 1F;
            this.Line8.Name = "Line8";
            this.Line8.X1 = 1F;
            this.Line8.X2 = 7.25F;
            this.Line8.Y1 = 1.25F;
            this.Line8.Y2 = 1.25F;
            // 
            // Label14
            // 
            this.Label14.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label14.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label14.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label14.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label14.Font = new System.Drawing.Font("Arial", 11F);
            this.Label14.HyperLink = null;
            this.Label14.Location = ((System.Drawing.PointF)(resources.GetObject("Label14.Location")));
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.SizeF(0.8125F, 0.1875F);
            this.Label14.Text = "Họ tên BN:";
            // 
            // detail
            // 
            this.detail.ColumnSpacing = 0F;
            this.detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.TextBox1,
            this.textBox4,
            this.textBox2,
            this.line12});
            this.detail.Height = 0.2604167F;
            this.detail.Name = "detail";
            this.detail.BeforePrint += new System.EventHandler(this.detail_BeforePrint);
            // 
            // TextBox1
            // 
            this.TextBox1.Border.BottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.TextBox1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Dot;
            this.TextBox1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.TextBox1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox1.DataField = "TenDichVu";
            this.TextBox1.DistinctField = null;
            this.TextBox1.Font = new System.Drawing.Font("Arial", 11F);
            this.TextBox1.Location = ((System.Drawing.PointF)(resources.GetObject("TextBox1.Location")));
            this.TextBox1.MultiLine = false;
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.OutputFormat = null;
            this.TextBox1.Size = new System.Drawing.SizeF(2.875F, 0.25F);
            this.TextBox1.Text = "0";
            this.TextBox1.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Bottom;
            // 
            // textBox4
            // 
            this.textBox4.Border.BottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.textBox4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Dot;
            this.textBox4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.textBox4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox4.DataField = "TenThuoc";
            this.textBox4.DistinctField = null;
            this.textBox4.Font = new System.Drawing.Font("Arial", 11F);
            this.textBox4.Location = ((System.Drawing.PointF)(resources.GetObject("textBox4.Location")));
            this.textBox4.MultiLine = false;
            this.textBox4.Name = "textBox4";
            this.textBox4.OutputFormat = null;
            this.textBox4.Size = new System.Drawing.SizeF(3.3125F, 0.25F);
            this.textBox4.Text = "0";
            this.textBox4.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Bottom;
            // 
            // textBox2
            // 
            this.textBox2.Border.BottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.textBox2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Dot;
            this.textBox2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.textBox2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox2.DataField = "NGAYCHIDINH";
            this.textBox2.DistinctField = null;
            this.textBox2.Font = new System.Drawing.Font("Arial", 11F);
            this.textBox2.Location = ((System.Drawing.PointF)(resources.GetObject("textBox2.Location")));
            this.textBox2.Name = "textBox2";
            this.textBox2.OutputFormat = "dd/MM/yyyy";
            this.textBox2.Size = new System.Drawing.SizeF(1.125F, 0.25F);
            this.textBox2.SummaryGroup = "groupHeader1";
            this.textBox2.Text = "0";
            this.textBox2.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Bottom;
            // 
            // line12
            // 
            this.line12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line12.LineWeight = 1F;
            this.line12.Name = "line12";
            this.line12.X1 = 0F;
            this.line12.X2 = 7.3125F;
            this.line12.Y1 = 0F;
            this.line12.Y2 = 0F;
            // 
            // pageFooter
            // 
            this.pageFooter.Height = 0F;
            this.pageFooter.Name = "pageFooter";
            // 
            // reportHeader1
            // 
            this.reportHeader1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Line10});
            this.reportHeader1.Height = 0F;
            this.reportHeader1.Name = "reportHeader1";
            // 
            // Line10
            // 
            this.Line10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line10.LineStyle = DataDynamics.ActiveReports.LineStyle.Dot;
            this.Line10.LineWeight = 1F;
            this.Line10.Name = "Line10";
            this.Line10.X1 = 0.6875F;
            this.Line10.X2 = 7.270833F;
            this.Line10.Y1 = 2.4375F;
            this.Line10.Y2 = 2.4375F;
            // 
            // reportFooter1
            // 
            this.reportFooter1.Height = 0F;
            this.reportFooter1.Name = "reportFooter1";
            // 
            // groupHeader1
            // 
            this.groupHeader1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.label2,
            this.label4,
            this.label5,
            this.line11});
            this.groupHeader1.DataField = "NGAYCHIDINH";
            this.groupHeader1.Height = 0.2604167F;
            this.groupHeader1.Name = "groupHeader1";
            this.groupHeader1.NewPage = DataDynamics.ActiveReports.NewPage.Before;
            this.groupHeader1.Format += new System.EventHandler(this.groupHeader1_Format);
            // 
            // label2
            // 
            this.label2.Alignment = DataDynamics.ActiveReports.TextAlignment.Center;
            this.label2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.HyperLink = null;
            this.label2.Location = ((System.Drawing.PointF)(resources.GetObject("label2.Location")));
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.SizeF(2.875F, 0.25F);
            this.label2.Text = "THEO DÕI DIỄN BIẾN BỆNH";
            this.label2.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle;
            // 
            // label4
            // 
            this.label4.Alignment = DataDynamics.ActiveReports.TextAlignment.Center;
            this.label4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.HyperLink = null;
            this.label4.Location = ((System.Drawing.PointF)(resources.GetObject("label4.Location")));
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.SizeF(1.125F, 0.25F);
            this.label4.Text = "Ngày CĐ";
            this.label4.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle;
            // 
            // label5
            // 
            this.label5.Alignment = DataDynamics.ActiveReports.TextAlignment.Center;
            this.label5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.HyperLink = null;
            this.label5.Location = ((System.Drawing.PointF)(resources.GetObject("label5.Location")));
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.SizeF(3.3125F, 0.25F);
            this.label5.Text = "ĐIỀU TRỊ";
            this.label5.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle;
            // 
            // line11
            // 
            this.line11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line11.LineWeight = 1F;
            this.line11.Name = "line11";
            this.line11.X1 = 7.3125F;
            this.line11.X2 = 7.3125F;
            this.line11.Y1 = 0F;
            this.line11.Y2 = 0.25F;
            // 
            // groupFooter1
            // 
            this.groupFooter1.Height = 0F;
            this.groupFooter1.Name = "groupFooter1";
            // 
            // repPhieuChiDinh
            // 
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 7.479167F;
            this.Sections.Add(this.reportHeader1);
            this.Sections.Add(this.pageHeader);
            this.Sections.Add(this.groupHeader1);
            this.Sections.Add(this.detail);
            this.Sections.Add(this.groupFooter1);
            this.Sections.Add(this.pageFooter);
            this.Sections.Add(this.reportFooter1);
            this.ReportStart += new System.EventHandler(this.repPhieuChiDinh_ReportStart);
            this.DataInitialize += new System.EventHandler(this.repPhieuChiDinh_DataInitialize);
            ((System.ComponentModel.ISupportInitialize)(this.lblNoiChiDinh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTenBN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTuoi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGioi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblChanDoan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).EndInit();

        }
        #endregion

        private DataDynamics.ActiveReports.ReportHeader reportHeader1;
        private DataDynamics.ActiveReports.ReportFooter reportFooter1;
        internal DataDynamics.ActiveReports.Line Line10;
        internal DataDynamics.ActiveReports.TextBox TextBox1;
        private DataDynamics.ActiveReports.GroupHeader groupHeader1;
        private DataDynamics.ActiveReports.GroupFooter groupFooter1;
        internal DataDynamics.ActiveReports.Label lblNoiChiDinh;
        internal DataDynamics.ActiveReports.Barcode Barcode1;
        internal DataDynamics.ActiveReports.Label Label8;
        internal DataDynamics.ActiveReports.Label lblTenBN;
        internal DataDynamics.ActiveReports.Label lblTuoi;
        internal DataDynamics.ActiveReports.Label lblGioi;
        internal DataDynamics.ActiveReports.Line Line2;
        internal DataDynamics.ActiveReports.Line Line3;
        internal DataDynamics.ActiveReports.Line Line4;
        internal DataDynamics.ActiveReports.Line Line6;
        internal DataDynamics.ActiveReports.Label lblChanDoan;
        internal DataDynamics.ActiveReports.Line Line8;
        internal DataDynamics.ActiveReports.Label Label14;
        private DataDynamics.ActiveReports.TextBox textBox4;
        private DataDynamics.ActiveReports.Line line12;
        private DataDynamics.ActiveReports.Label label2;
        private DataDynamics.ActiveReports.Label label4;
        private DataDynamics.ActiveReports.Label label5;
        private DataDynamics.ActiveReports.Line line11;
        private DataDynamics.ActiveReports.TextBox textBox2;
    }
}
