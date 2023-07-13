namespace NamDinh_QLBN.Forms.DuLieu
{
    partial class frmChuanDoan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChuanDoan));
            this.cmdGhi = new DevExpress.XtraEditors.SimpleButton();
            this.txtICD_KhoaDT = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmdGhi
            // 
            this.cmdGhi.Image = ((System.Drawing.Image)(resources.GetObject("cmdGhi.Image")));
            this.cmdGhi.Location = new System.Drawing.Point(155, 63);
            this.cmdGhi.Name = "cmdGhi";
            this.cmdGhi.Size = new System.Drawing.Size(89, 24);
            this.cmdGhi.TabIndex = 124;
            this.cmdGhi.Text = "Ghi dữ liệu";
            this.cmdGhi.Click += new System.EventHandler(this.cmdGhi_Click);
            // 
            // txtICD_KhoaDT
            // 
            this.txtICD_KhoaDT.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtICD_KhoaDT.Location = new System.Drawing.Point(73, 26);
            this.txtICD_KhoaDT.Name = "txtICD_KhoaDT";
            this.txtICD_KhoaDT.Size = new System.Drawing.Size(316, 20);
            this.txtICD_KhoaDT.TabIndex = 0;
            // 
            // label23
            // 
            this.label23.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label23.Location = new System.Drawing.Point(1, 27);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(68, 19);
            this.label23.TabIndex = 125;
            this.label23.Text = "Chẩn đoán";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmChuanDoan
            // 
            this.AcceptButton = this.cmdGhi;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 96);
            this.Controls.Add(this.txtICD_KhoaDT);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.cmdGhi);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChuanDoan";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chẩn đoán";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmChuanDoan_FormClosing);
            this.Load += new System.EventHandler(this.frmChuanDoan_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton cmdGhi;
        private System.Windows.Forms.Label label23;
        public System.Windows.Forms.TextBox txtICD_KhoaDT;
    }
}