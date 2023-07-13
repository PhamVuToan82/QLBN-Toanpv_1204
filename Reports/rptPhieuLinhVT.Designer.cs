namespace NamDinh_QLBN.Reports
{
    /// <summary>
    /// Summary description for rptPhieuLinhThuoc.
    /// </summary>
    partial class rptPhieuLinhVT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rptPhieuLinhVT));
            this.pageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.detail = new DataDynamics.ActiveReports.Detail();
            this.STT = new DataDynamics.ActiveReports.TextBox();
            this.textBox1 = new DataDynamics.ActiveReports.TextBox();
            this.textBox2 = new DataDynamics.ActiveReports.TextBox();
            this.textBox3 = new DataDynamics.ActiveReports.TextBox();
            this.textBox4 = new DataDynamics.ActiveReports.TextBox();
            this.textBox5 = new DataDynamics.ActiveReports.TextBox();
            this.textBox12 = new DataDynamics.ActiveReports.TextBox();
            this.pageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.reportHeader1 = new DataDynamics.ActiveReports.ReportHeader();
            this.reportFooter1 = new DataDynamics.ActiveReports.ReportFooter();
            this.groupHeader1 = new DataDynamics.ActiveReports.GroupHeader();
            this.lblNgayThang = new DataDynamics.ActiveReports.Label();
            this.label1 = new DataDynamics.ActiveReports.Label();
            this.label2 = new DataDynamics.ActiveReports.Label();
            this.label4 = new DataDynamics.ActiveReports.Label();
            this.label5 = new DataDynamics.ActiveReports.Label();
            this.label3 = new DataDynamics.ActiveReports.Label();
            this.label6 = new DataDynamics.ActiveReports.Label();
            this.label7 = new DataDynamics.ActiveReports.Label();
            this.label9 = new DataDynamics.ActiveReports.Label();
            this.label8 = new DataDynamics.ActiveReports.Label();
            this.lblKhoa = new DataDynamics.ActiveReports.Label();
            this.line1 = new DataDynamics.ActiveReports.Line();
            this.label10 = new DataDynamics.ActiveReports.Label();
            this.label15 = new DataDynamics.ActiveReports.Label();
            this.lblMaPhieu = new DataDynamics.ActiveReports.Label();
            this.lbNgay = new DataDynamics.ActiveReports.Label();
            this.lblLoaiDV = new DataDynamics.ActiveReports.Label();
            this.lblHinhThuc = new DataDynamics.ActiveReports.Label();
            this.groupFooter1 = new DataDynamics.ActiveReports.GroupFooter();
            this.lblKhoaKho = new DataDynamics.ActiveReports.Label();
            this.label12 = new DataDynamics.ActiveReports.Label();
            this.label13 = new DataDynamics.ActiveReports.Label();
            this.label14 = new DataDynamics.ActiveReports.Label();
            this.lblNgayIn = new DataDynamics.ActiveReports.Label();
            this.groupHeader2 = new DataDynamics.ActiveReports.GroupHeader();
            this.groupFooter2 = new DataDynamics.ActiveReports.GroupFooter();
            ((System.ComponentModel.ISupportInitialize)(this.STT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNgayThang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKhoa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMaPhieu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbNgay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLoaiDV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHinhThuc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKhoaKho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNgayIn)).BeginInit();
            // 
            // pageHeader
            // 
            this.pageHeader.Height = 0F;
            this.pageHeader.Name = "pageHeader";
            // 
            // detail
            // 
            this.detail.ColumnSpacing = 0F;
            this.detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.STT,
            this.textBox1,
            this.textBox2,
            this.textBox3,
            this.textBox4,
            this.textBox5,
            this.textBox12});
            this.detail.Height = 0.2604167F;
            this.detail.Name = "detail";
            this.detail.Format += new System.EventHandler(this.detail_Format);
            this.detail.BeforePrint += new System.EventHandler(this.detail_BeforePrint);
            // 
            // STT
            // 
            this.STT.Alignment = DataDynamics.ActiveReports.TextAlignment.Center;
            this.STT.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Dot;
            this.STT.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.STT.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.STT.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.STT.DistinctField = null;
            this.STT.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.STT.Location = ((System.Drawing.PointF)(resources.GetObject("STT.Location")));
            this.STT.Name = "STT";
            this.STT.OutputFormat = null;
            this.STT.Size = new System.Drawing.SizeF(0.375F, 0.25F);
            this.STT.Text = "0";
            this.STT.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle;
            // 
            // textBox1
            // 
            this.textBox1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Dot;
            this.textBox1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.textBox1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox1.DataField = "TenDichVu";
            this.textBox1.DistinctField = null;
            this.textBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = ((System.Drawing.PointF)(resources.GetObject("textBox1.Location")));
            this.textBox1.Name = "textBox1";
            this.textBox1.OutputFormat = null;
            this.textBox1.Size = new System.Drawing.SizeF(3.3125F, 0.25F);
            this.textBox1.Text = "0";
            this.textBox1.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle;
            // 
            // textBox2
            // 
            this.textBox2.Alignment = DataDynamics.ActiveReports.TextAlignment.Center;
            this.textBox2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Dot;
            this.textBox2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.textBox2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox2.DataField = "DVT";
            this.textBox2.DistinctField = null;
            this.textBox2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = ((System.Drawing.PointF)(resources.GetObject("textBox2.Location")));
            this.textBox2.Name = "textBox2";
            this.textBox2.OutputFormat = null;
            this.textBox2.Size = new System.Drawing.SizeF(0.75F, 0.25F);
            this.textBox2.Text = "0";
            this.textBox2.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle;
            // 
            // textBox3
            // 
            this.textBox3.Alignment = DataDynamics.ActiveReports.TextAlignment.Right;
            this.textBox3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Dot;
            this.textBox3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox3.DataField = "SoLuongYC";
            this.textBox3.DistinctField = null;
            this.textBox3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = ((System.Drawing.PointF)(resources.GetObject("textBox3.Location")));
            this.textBox3.Name = "textBox3";
            this.textBox3.OutputFormat = "0#.##";
            this.textBox3.Size = new System.Drawing.SizeF(0.875F, 0.25F);
            this.textBox3.Text = "0";
            this.textBox3.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle;
            // 
            // textBox4
            // 
            this.textBox4.Alignment = DataDynamics.ActiveReports.TextAlignment.Right;
            this.textBox4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Dot;
            this.textBox4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.textBox4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox4.DistinctField = null;
            this.textBox4.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.textBox4.Location = ((System.Drawing.PointF)(resources.GetObject("textBox4.Location")));
            this.textBox4.Name = "textBox4";
            this.textBox4.OutputFormat = null;
            this.textBox4.Size = new System.Drawing.SizeF(0.75F, 0.25F);
            this.textBox4.Text = null;
            this.textBox4.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Bottom;
            // 
            // textBox5
            // 
            this.textBox5.Alignment = DataDynamics.ActiveReports.TextAlignment.Right;
            this.textBox5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Dot;
            this.textBox5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.textBox5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox5.DistinctField = null;
            this.textBox5.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.textBox5.Location = ((System.Drawing.PointF)(resources.GetObject("textBox5.Location")));
            this.textBox5.Name = "textBox5";
            this.textBox5.OutputFormat = null;
            this.textBox5.Size = new System.Drawing.SizeF(1F, 0.25F);
            this.textBox5.Text = null;
            this.textBox5.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Bottom;
            // 
            // textBox12
            // 
            this.textBox12.Alignment = DataDynamics.ActiveReports.TextAlignment.Right;
            this.textBox12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Dot;
            this.textBox12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.textBox12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox12.DistinctField = null;
            this.textBox12.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.textBox12.Location = ((System.Drawing.PointF)(resources.GetObject("textBox12.Location")));
            this.textBox12.Name = "textBox12";
            this.textBox12.OutputFormat = null;
            this.textBox12.Size = new System.Drawing.SizeF(0.25F, 0.25F);
            this.textBox12.Text = null;
            this.textBox12.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Bottom;
            // 
            // pageFooter
            // 
            this.pageFooter.Height = 0F;
            this.pageFooter.Name = "pageFooter";
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
            this.reportFooter1.Format += new System.EventHandler(this.reportFooter1_Format);
            // 
            // groupHeader1
            // 
            this.groupHeader1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.lblNgayThang,
            this.label1,
            this.label2,
            this.label4,
            this.label5,
            this.label3,
            this.label6,
            this.label7,
            this.label9,
            this.label8,
            this.lblKhoa,
            this.line1,
            this.label10,
            this.label15,
            this.lblMaPhieu,
            this.lbNgay,
            this.lblLoaiDV,
            this.lblHinhThuc});
            this.groupHeader1.DataField = "KhoID";
            this.groupHeader1.Height = 1.75F;
            this.groupHeader1.Name = "groupHeader1";
            this.groupHeader1.NewPage = DataDynamics.ActiveReports.NewPage.Before;
            this.groupHeader1.Format += new System.EventHandler(this.groupHeader1_Format);
            // 
            // lblNgayThang
            // 
            this.lblNgayThang.Alignment = DataDynamics.ActiveReports.TextAlignment.Center;
            this.lblNgayThang.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblNgayThang.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblNgayThang.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblNgayThang.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblNgayThang.DataField = "TenKho";
            this.lblNgayThang.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayThang.HyperLink = null;
            this.lblNgayThang.Location = ((System.Drawing.PointF)(resources.GetObject("lblNgayThang.Location")));
            this.lblNgayThang.Name = "lblNgayThang";
            this.lblNgayThang.Size = new System.Drawing.SizeF(3.8125F, 0.25F);
            this.lblNgayThang.Text = "";
            this.lblNgayThang.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle;
            // 
            // label1
            // 
            this.label1.Alignment = DataDynamics.ActiveReports.TextAlignment.Center;
            this.label1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.label1.HyperLink = null;
            this.label1.Location = ((System.Drawing.PointF)(resources.GetObject("label1.Location")));
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.SizeF(0.375F, 0.625F);
            this.label1.Text = "STT";
            this.label1.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle;
            // 
            // label2
            // 
            this.label2.Alignment = DataDynamics.ActiveReports.TextAlignment.Center;
            this.label2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.label2.HyperLink = null;
            this.label2.Location = ((System.Drawing.PointF)(resources.GetObject("label2.Location")));
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.SizeF(3.3125F, 0.625F);
            this.label2.Text = "TÊN VẬT TƯ";
            this.label2.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle;
            // 
            // label4
            // 
            this.label4.Alignment = DataDynamics.ActiveReports.TextAlignment.Center;
            this.label4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.label4.HyperLink = null;
            this.label4.Location = ((System.Drawing.PointF)(resources.GetObject("label4.Location")));
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.SizeF(0.75F, 0.625F);
            this.label4.Text = "ĐƠN VỊ";
            this.label4.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle;
            // 
            // label5
            // 
            this.label5.Alignment = DataDynamics.ActiveReports.TextAlignment.Center;
            this.label5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.label5.HyperLink = null;
            this.label5.Location = ((System.Drawing.PointF)(resources.GetObject("label5.Location")));
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.SizeF(1.875F, 0.3125F);
            this.label5.Text = "SỐ LƯỢNG";
            this.label5.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle;
            // 
            // label3
            // 
            this.label3.Alignment = DataDynamics.ActiveReports.TextAlignment.Center;
            this.label3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.label3.HyperLink = null;
            this.label3.Location = ((System.Drawing.PointF)(resources.GetObject("label3.Location")));
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.SizeF(1F, 0.625F);
            this.label3.Text = "GHI CHÚ";
            this.label3.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle;
            // 
            // label6
            // 
            this.label6.Alignment = DataDynamics.ActiveReports.TextAlignment.Center;
            this.label6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label6.HyperLink = null;
            this.label6.Location = ((System.Drawing.PointF)(resources.GetObject("label6.Location")));
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.SizeF(1.125F, 0.3125F);
            this.label6.Text = "YÊU CẦU";
            this.label6.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle;
            // 
            // label7
            // 
            this.label7.Alignment = DataDynamics.ActiveReports.TextAlignment.Center;
            this.label7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label7.HyperLink = null;
            this.label7.Location = ((System.Drawing.PointF)(resources.GetObject("label7.Location")));
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.SizeF(0.75F, 0.3125F);
            this.label7.Text = "PHÁT";
            this.label7.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle;
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
            // lblKhoa
            // 
            this.lblKhoa.Alignment = DataDynamics.ActiveReports.TextAlignment.Center;
            this.lblKhoa.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblKhoa.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblKhoa.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblKhoa.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblKhoa.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKhoa.HyperLink = null;
            this.lblKhoa.Location = ((System.Drawing.PointF)(resources.GetObject("lblKhoa.Location")));
            this.lblKhoa.Name = "lblKhoa";
            this.lblKhoa.Size = new System.Drawing.SizeF(2.5F, 0.25F);
            this.lblKhoa.Text = "Khoa:";
            this.lblKhoa.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle;
            // 
            // line1
            // 
            this.line1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line1.LineWeight = 1F;
            this.line1.Name = "line1";
            this.line1.X1 = 0.4375F;
            this.line1.X2 = 1.875F;
            this.line1.Y1 = 0.5F;
            this.line1.Y2 = 0.5F;
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
            this.label10.Size = new System.Drawing.SizeF(3.375F, 0.3125F);
            this.label10.Text = "PHIẾU LĨNH VẬT TƯ TIÊU HAO";
            this.label10.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle;
            // 
            // label15
            // 
            this.label15.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label15.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label15.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label15.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label15.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.label15.HyperLink = null;
            this.label15.Location = ((System.Drawing.PointF)(resources.GetObject("label15.Location")));
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.SizeF(1.125F, 0.25F);
            this.label15.Text = "MS: 01D/BV-01";
            this.label15.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle;
            // 
            // lblMaPhieu
            // 
            this.lblMaPhieu.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblMaPhieu.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblMaPhieu.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblMaPhieu.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblMaPhieu.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.lblMaPhieu.HyperLink = null;
            this.lblMaPhieu.Location = ((System.Drawing.PointF)(resources.GetObject("lblMaPhieu.Location")));
            this.lblMaPhieu.Name = "lblMaPhieu";
            this.lblMaPhieu.Size = new System.Drawing.SizeF(1.375F, 0.25F);
            this.lblMaPhieu.Text = "Số: .....................";
            this.lblMaPhieu.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle;
            // 
            // lbNgay
            // 
            this.lbNgay.Alignment = DataDynamics.ActiveReports.TextAlignment.Center;
            this.lbNgay.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbNgay.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbNgay.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbNgay.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbNgay.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNgay.HyperLink = null;
            this.lbNgay.Location = ((System.Drawing.PointF)(resources.GetObject("lbNgay.Location")));
            this.lbNgay.Name = "lbNgay";
            this.lbNgay.Size = new System.Drawing.SizeF(2F, 0.25F);
            this.lbNgay.Text = "Ngày";
            this.lbNgay.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle;
            // 
            // lblLoaiDV
            // 
            this.lblLoaiDV.Alignment = DataDynamics.ActiveReports.TextAlignment.Center;
            this.lblLoaiDV.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblLoaiDV.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblLoaiDV.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblLoaiDV.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblLoaiDV.DataField = "LoaiDichVu";
            this.lblLoaiDV.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoaiDV.HyperLink = null;
            this.lblLoaiDV.Location = ((System.Drawing.PointF)(resources.GetObject("lblLoaiDV.Location")));
            this.lblLoaiDV.Name = "lblLoaiDV";
            this.lblLoaiDV.Size = new System.Drawing.SizeF(0.625F, 0.25F);
            this.lblLoaiDV.Text = "LoaiDV";
            this.lblLoaiDV.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle;
            this.lblLoaiDV.Visible = false;
            // 
            // lblHinhThuc
            // 
            this.lblHinhThuc.Alignment = DataDynamics.ActiveReports.TextAlignment.Center;
            this.lblHinhThuc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblHinhThuc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblHinhThuc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblHinhThuc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblHinhThuc.DataField = "HinhThuc";
            this.lblHinhThuc.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHinhThuc.HyperLink = null;
            this.lblHinhThuc.Location = ((System.Drawing.PointF)(resources.GetObject("lblHinhThuc.Location")));
            this.lblHinhThuc.Name = "lblHinhThuc";
            this.lblHinhThuc.Size = new System.Drawing.SizeF(1.5F, 0.25F);
            this.lblHinhThuc.Text = "Hình thức";
            this.lblHinhThuc.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle;
            // 
            // groupFooter1
            // 
            this.groupFooter1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.lblKhoaKho,
            this.label12,
            this.label13,
            this.label14,
            this.lblNgayIn});
            this.groupFooter1.Height = 1.5F;
            this.groupFooter1.Name = "groupFooter1";
            // 
            // lblKhoaKho
            // 
            this.lblKhoaKho.Alignment = DataDynamics.ActiveReports.TextAlignment.Center;
            this.lblKhoaKho.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblKhoaKho.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblKhoaKho.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblKhoaKho.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblKhoaKho.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.lblKhoaKho.HyperLink = null;
            this.lblKhoaKho.Location = ((System.Drawing.PointF)(resources.GetObject("lblKhoaKho.Location")));
            this.lblKhoaKho.Name = "lblKhoaKho";
            this.lblKhoaKho.Size = new System.Drawing.SizeF(2F, 0.25F);
            this.lblKhoaKho.Text = "TRƯỞNG KHOA DƯỢC";
            this.lblKhoaKho.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle;
            // 
            // label12
            // 
            this.label12.Alignment = DataDynamics.ActiveReports.TextAlignment.Center;
            this.label12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.label12.HyperLink = null;
            this.label12.Location = ((System.Drawing.PointF)(resources.GetObject("label12.Location")));
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.SizeF(1.5F, 0.25F);
            this.label12.Text = "NGƯỜI PHÁT";
            this.label12.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle;
            // 
            // label13
            // 
            this.label13.Alignment = DataDynamics.ActiveReports.TextAlignment.Center;
            this.label13.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label13.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label13.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label13.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label13.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.label13.HyperLink = null;
            this.label13.Location = ((System.Drawing.PointF)(resources.GetObject("label13.Location")));
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.SizeF(1.4375F, 0.25F);
            this.label13.Text = "NGƯỜI LĨNH";
            this.label13.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle;
            // 
            // label14
            // 
            this.label14.Alignment = DataDynamics.ActiveReports.TextAlignment.Center;
            this.label14.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label14.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label14.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label14.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label14.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.label14.HyperLink = null;
            this.label14.Location = ((System.Drawing.PointF)(resources.GetObject("label14.Location")));
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.SizeF(1.5F, 0.4375F);
            this.label14.Text = "TRƯỞNG KHOA";
            // 
            // lblNgayIn
            // 
            this.lblNgayIn.Alignment = DataDynamics.ActiveReports.TextAlignment.Right;
            this.lblNgayIn.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblNgayIn.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblNgayIn.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblNgayIn.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblNgayIn.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic);
            this.lblNgayIn.HyperLink = null;
            this.lblNgayIn.Location = ((System.Drawing.PointF)(resources.GetObject("lblNgayIn.Location")));
            this.lblNgayIn.Name = "lblNgayIn";
            this.lblNgayIn.Size = new System.Drawing.SizeF(3.625F, 0.25F);
            this.lblNgayIn.Text = "Khoa:";
            this.lblNgayIn.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle;
            // 
            // groupHeader2
            // 
            this.groupHeader2.DataField = "Nhom";
            this.groupHeader2.Height = 0F;
            this.groupHeader2.Name = "groupHeader2";
            this.groupHeader2.NewPage = DataDynamics.ActiveReports.NewPage.Before;
            // 
            // groupFooter2
            // 
            this.groupFooter2.Height = 0F;
            this.groupFooter2.Name = "groupFooter2";
            // 
            // rptPhieuLinhVT
            // 
            this.PageSettings.Margins.Bottom = 0.4F;
            this.PageSettings.Margins.Left = 0.5F;
            this.PageSettings.Margins.Right = 0.2F;
            this.PageSettings.Margins.Top = 0.4F;
            this.PageSettings.PaperHeight = 11.69F;
            this.PageSettings.PaperWidth = 8.27F;
            this.PrintWidth = 7.395833F;
            this.Sections.Add(this.reportHeader1);
            this.Sections.Add(this.pageHeader);
            this.Sections.Add(this.groupHeader2);
            this.Sections.Add(this.groupHeader1);
            this.Sections.Add(this.detail);
            this.Sections.Add(this.groupFooter1);
            this.Sections.Add(this.groupFooter2);
            this.Sections.Add(this.pageFooter);
            this.Sections.Add(this.reportFooter1);
            this.ReportStart += new System.EventHandler(this.rptPhieuLinhVT_ReportStart);
            this.DataInitialize += new System.EventHandler(this.rptPhieulinhThuoc_DataInitialize);
            ((System.ComponentModel.ISupportInitialize)(this.STT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNgayThang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKhoa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMaPhieu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbNgay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLoaiDV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHinhThuc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKhoaKho)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNgayIn)).EndInit();

        }
        #endregion

        private DataDynamics.ActiveReports.ReportHeader reportHeader1;
        private DataDynamics.ActiveReports.ReportFooter reportFooter1;
        private DataDynamics.ActiveReports.GroupHeader groupHeader1;
        private DataDynamics.ActiveReports.GroupFooter groupFooter1;
        private DataDynamics.ActiveReports.Label lblKhoaKho;
        private DataDynamics.ActiveReports.Label label12;
        private DataDynamics.ActiveReports.Label label13;
        private DataDynamics.ActiveReports.Label label14;
        private DataDynamics.ActiveReports.Label lblNgayIn;
        private DataDynamics.ActiveReports.Label lblNgayThang;
        private DataDynamics.ActiveReports.Label label1;
        private DataDynamics.ActiveReports.Label label2;
        private DataDynamics.ActiveReports.Label label4;
        private DataDynamics.ActiveReports.Label label5;
        private DataDynamics.ActiveReports.Label label3;
        private DataDynamics.ActiveReports.Label label6;
        private DataDynamics.ActiveReports.Label label7;
        private DataDynamics.ActiveReports.Label label9;
        private DataDynamics.ActiveReports.Label label8;
        private DataDynamics.ActiveReports.Label lblKhoa;
        private DataDynamics.ActiveReports.Line line1;
        private DataDynamics.ActiveReports.Label label10;
        private DataDynamics.ActiveReports.Label label15;
        private DataDynamics.ActiveReports.Label lblMaPhieu;
        private DataDynamics.ActiveReports.Label lbNgay;
        private DataDynamics.ActiveReports.TextBox STT;
        private DataDynamics.ActiveReports.TextBox textBox1;
        private DataDynamics.ActiveReports.TextBox textBox2;
        private DataDynamics.ActiveReports.TextBox textBox3;
        private DataDynamics.ActiveReports.TextBox textBox4;
        private DataDynamics.ActiveReports.TextBox textBox5;
        private DataDynamics.ActiveReports.TextBox textBox12;
        private DataDynamics.ActiveReports.GroupHeader groupHeader2;
        private DataDynamics.ActiveReports.GroupFooter groupFooter2;
        private DataDynamics.ActiveReports.Label lblLoaiDV;
        private DataDynamics.ActiveReports.Label lblHinhThuc;
    }
}
