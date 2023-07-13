namespace NamDinh_QLBN.Forms.In.PhauThuat
{
    partial class frmBaoCao
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaoCao));
            this.tabBaoCao = new System.Windows.Forms.TabControl();
            this.fg = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.txtTuNgay = new C1.Win.C1Input.C1DateEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdXuatFile = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.fg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTuNgay)).BeginInit();
            this.SuspendLayout();
            // 
            // tabBaoCao
            // 
            this.tabBaoCao.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabBaoCao.Location = new System.Drawing.Point(264, 1);
            this.tabBaoCao.Name = "tabBaoCao";
            this.tabBaoCao.SelectedIndex = 0;
            this.tabBaoCao.Size = new System.Drawing.Size(676, 521);
            this.tabBaoCao.TabIndex = 0;
            // 
            // fg
            // 
            this.fg.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.fg.AllowEditing = false;
            this.fg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Light3D;
            this.fg.ColumnInfo = resources.GetString("fg.ColumnInfo");
            this.fg.ExtendLastCol = true;
            this.fg.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid;
            this.fg.HighLight = C1.Win.C1FlexGrid.HighLightEnum.WithFocus;
            this.fg.Location = new System.Drawing.Point(3, 27);
            this.fg.Name = "fg";
            this.fg.Rows.Count = 1;
            this.fg.Rows.MinSize = 20;
            this.fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
            this.fg.ShowCursor = true;
            this.fg.Size = new System.Drawing.Size(258, 495);
            this.fg.Styles = new C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("fg.Styles"));
            this.fg.TabIndex = 58;
            this.fg.AfterSelChange += new C1.Win.C1FlexGrid.RangeEventHandler(this.fg_AfterSelChange);
            // 
            // txtTuNgay
            // 
            this.txtTuNgay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTuNgay.Culture = 1066;
            this.txtTuNgay.CustomFormat = "MM/yyyy";
            this.txtTuNgay.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
            this.txtTuNgay.Location = new System.Drawing.Point(71, 5);
            this.txtTuNgay.Name = "txtTuNgay";
            this.txtTuNgay.Size = new System.Drawing.Size(125, 18);
            this.txtTuNgay.TabIndex = 141;
            this.txtTuNgay.Tag = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 143;
            this.label1.Text = "Tháng";
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdOK.Image = ((System.Drawing.Image)(resources.GetObject("cmdOK.Image")));
            this.cmdOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdOK.Location = new System.Drawing.Point(225, 523);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(166, 27);
            this.cmdOK.TabIndex = 145;
            this.cmdOK.Text = "Tổng hợp số liệu";
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Image = ((System.Drawing.Image)(resources.GetObject("cmdCancel.Image")));
            this.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancel.Location = new System.Drawing.Point(871, 523);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(69, 27);
            this.cmdCancel.TabIndex = 146;
            this.cmdCancel.Text = " Thoát";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdXuatFile
            // 
            this.cmdXuatFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdXuatFile.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdXuatFile.Image = ((System.Drawing.Image)(resources.GetObject("cmdXuatFile.Image")));
            this.cmdXuatFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdXuatFile.Location = new System.Drawing.Point(30, 523);
            this.cmdXuatFile.Name = "cmdXuatFile";
            this.cmdXuatFile.Size = new System.Drawing.Size(166, 27);
            this.cmdXuatFile.TabIndex = 147;
            this.cmdXuatFile.Text = "Xuất file";
            this.cmdXuatFile.Click += new System.EventHandler(this.cmdXuatFile_Click);
            // 
            // frmBaoCao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 554);
            this.Controls.Add(this.cmdXuatFile);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTuNgay);
            this.Controls.Add(this.fg);
            this.Controls.Add(this.tabBaoCao);
            this.Name = "frmBaoCao";
            this.Text = "Báo cáo tổng hợp tình hình phẫu thuật";
            this.Load += new System.EventHandler(this.frmBaoCao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTuNgay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabBaoCao;
        private C1.Win.C1FlexGrid.C1FlexGrid fg;
        private C1.Win.C1Input.C1DateEdit txtTuNgay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdXuatFile;

    }
}