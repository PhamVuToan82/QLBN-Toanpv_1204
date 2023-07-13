namespace NamDinh_QLBN.Forms.DuLieu
{
    partial class frmThongTinKQ
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThongTinKQ));
            this.fgKyQuy = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.label25 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.fgDaSuDung = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.button1 = new System.Windows.Forms.Button();
            this.lbTongKQ = new System.Windows.Forms.Label();
            this.lbTongDSD = new System.Windows.Forms.Label();
            this.lbConLai = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.fgKyQuy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fgDaSuDung)).BeginInit();
            this.SuspendLayout();
            // 
            // fgKyQuy
            // 
            this.fgKyQuy.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.fgKyQuy.AllowEditing = false;
            this.fgKyQuy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.fgKyQuy.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Light3D;
            this.fgKyQuy.ColumnInfo = resources.GetString("fgKyQuy.ColumnInfo");
            this.fgKyQuy.ExtendLastCol = true;
            this.fgKyQuy.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid;
            this.fgKyQuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fgKyQuy.HighLight = C1.Win.C1FlexGrid.HighLightEnum.WithFocus;
            this.fgKyQuy.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.fgKyQuy.Location = new System.Drawing.Point(1, 25);
            this.fgKyQuy.Name = "fgKyQuy";
            this.fgKyQuy.Rows.Count = 1;
            this.fgKyQuy.Rows.MinSize = 20;
            this.fgKyQuy.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
            this.fgKyQuy.ShowCursor = true;
            this.fgKyQuy.Size = new System.Drawing.Size(453, 236);
            this.fgKyQuy.Styles = new C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("fgKyQuy.Styles"));
            this.fgKyQuy.TabIndex = 121;
            // 
            // label25
            // 
            this.label25.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label25.BackColor = System.Drawing.Color.MediumAquamarine;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label25.Location = new System.Drawing.Point(-2, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(457, 24);
            this.label25.TabIndex = 334;
            this.label25.Text = "THÔNG TIN KÝ quỹ";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.MediumAquamarine;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(-1, 288);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(457, 23);
            this.label1.TabIndex = 335;
            this.label1.Text = "DỊCH VỤ ĐÃ SỬ DỤNG";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // fgDaSuDung
            // 
            this.fgDaSuDung.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.fgDaSuDung.AllowEditing = false;
            this.fgDaSuDung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.fgDaSuDung.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Light3D;
            this.fgDaSuDung.ColumnInfo = resources.GetString("fgDaSuDung.ColumnInfo");
            this.fgDaSuDung.ExtendLastCol = true;
            this.fgDaSuDung.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid;
            this.fgDaSuDung.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fgDaSuDung.HighLight = C1.Win.C1FlexGrid.HighLightEnum.WithFocus;
            this.fgDaSuDung.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.fgDaSuDung.Location = new System.Drawing.Point(1, 313);
            this.fgDaSuDung.Name = "fgDaSuDung";
            this.fgDaSuDung.Rows.Count = 1;
            this.fgDaSuDung.Rows.MinSize = 20;
            this.fgDaSuDung.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
            this.fgDaSuDung.ShowCursor = true;
            this.fgDaSuDung.Size = new System.Drawing.Size(453, 193);
            this.fgDaSuDung.Styles = new C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("fgDaSuDung.Styles"));
            this.fgDaSuDung.TabIndex = 336;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(362, 531);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 26);
            this.button1.TabIndex = 337;
            this.button1.Text = "Thoát";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbTongKQ
            // 
            this.lbTongKQ.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTongKQ.ForeColor = System.Drawing.Color.Blue;
            this.lbTongKQ.Location = new System.Drawing.Point(20, 263);
            this.lbTongKQ.Name = "lbTongKQ";
            this.lbTongKQ.Size = new System.Drawing.Size(422, 23);
            this.lbTongKQ.TabIndex = 338;
            this.lbTongKQ.Text = "Tổng:";
            // 
            // lbTongDSD
            // 
            this.lbTongDSD.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTongDSD.ForeColor = System.Drawing.Color.Blue;
            this.lbTongDSD.Location = new System.Drawing.Point(20, 509);
            this.lbTongDSD.Name = "lbTongDSD";
            this.lbTongDSD.Size = new System.Drawing.Size(422, 18);
            this.lbTongDSD.TabIndex = 339;
            this.lbTongDSD.Text = "Tổng:";
            // 
            // lbConLai
            // 
            this.lbConLai.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbConLai.ForeColor = System.Drawing.Color.Blue;
            this.lbConLai.Location = new System.Drawing.Point(20, 527);
            this.lbConLai.Name = "lbConLai";
            this.lbConLai.Size = new System.Drawing.Size(335, 18);
            this.lbConLai.TabIndex = 340;
            this.lbConLai.Text = "Tổng:";
            // 
            // frmThongTinKQ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button1;
            this.ClientSize = new System.Drawing.Size(454, 562);
            this.Controls.Add(this.lbConLai);
            this.Controls.Add(this.lbTongDSD);
            this.Controls.Add(this.lbTongKQ);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.fgDaSuDung);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.fgKyQuy);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmThongTinKQ";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông tin ký quỹ";
            this.Load += new System.EventHandler(this.frmThongTinKQ_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fgKyQuy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fgDaSuDung)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private C1.Win.C1FlexGrid.C1FlexGrid fgKyQuy;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label1;
        private C1.Win.C1FlexGrid.C1FlexGrid fgDaSuDung;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbTongKQ;
        private System.Windows.Forms.Label lbTongDSD;
        private System.Windows.Forms.Label lbConLai;
    }
}