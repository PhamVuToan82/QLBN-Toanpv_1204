namespace NamDinh_QLBN.Forms.In
{
    partial class frmHuyLanGui
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHuyLanGui));
            this.lbChuDai = new System.Windows.Forms.Label();
            this.lbThongBao = new System.Windows.Forms.Label();
            this.cmbLanGui = new System.Windows.Forms.ComboBox();
            this.cmdOk = new DevExpress.XtraEditors.SimpleButton();
            this.cmdNo = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // lbChuDai
            // 
            this.lbChuDai.AutoSize = true;
            this.lbChuDai.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbChuDai.Location = new System.Drawing.Point(39, 46);
            this.lbChuDai.Name = "lbChuDai";
            this.lbChuDai.Size = new System.Drawing.Size(160, 16);
            this.lbChuDai.TabIndex = 132;
            this.lbChuDai.Text = "Bạn muốn hủy gửi lần nào";
            this.lbChuDai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbThongBao
            // 
            this.lbThongBao.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbThongBao.ForeColor = System.Drawing.Color.Crimson;
            this.lbThongBao.Location = new System.Drawing.Point(3, 11);
            this.lbThongBao.Name = "lbThongBao";
            this.lbThongBao.Size = new System.Drawing.Size(332, 18);
            this.lbThongBao.TabIndex = 131;
            this.lbThongBao.Text = "fds";
            this.lbThongBao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbThongBao.Click += new System.EventHandler(this.lbThongBao_Click);
            // 
            // cmbLanGui
            // 
            this.cmbLanGui.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLanGui.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLanGui.FormattingEnabled = true;
            this.cmbLanGui.Location = new System.Drawing.Point(206, 44);
            this.cmbLanGui.Name = "cmbLanGui";
            this.cmbLanGui.Size = new System.Drawing.Size(106, 21);
            this.cmbLanGui.TabIndex = 133;
            // 
            // cmdOk
            // 
            this.cmdOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOk.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.cmdOk.Image = ((System.Drawing.Image)(resources.GetObject("cmdOk.Image")));
            this.cmdOk.Location = new System.Drawing.Point(62, 90);
            this.cmdOk.Name = "cmdOk";
            this.cmdOk.Size = new System.Drawing.Size(100, 24);
            this.cmdOk.Style = new DevExpress.Utils.ViewStyle("ControlStyle", null, new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))), "", DevExpress.Utils.StyleOptions.StyleEnabled, true, false, false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.AntiqueWhite, System.Drawing.SystemColors.ControlText);
            this.cmdOk.TabIndex = 129;
            this.cmdOk.Text = "Đồng ý";
            this.cmdOk.Click += new System.EventHandler(this.cmdOk_Click);
            // 
            // cmdNo
            // 
            this.cmdNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdNo.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.cmdNo.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdNo.Image = ((System.Drawing.Image)(resources.GetObject("cmdNo.Image")));
            this.cmdNo.Location = new System.Drawing.Point(169, 90);
            this.cmdNo.Name = "cmdNo";
            this.cmdNo.Size = new System.Drawing.Size(100, 24);
            this.cmdNo.Style = new DevExpress.Utils.ViewStyle("ControlStyle", null, new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))), "", DevExpress.Utils.StyleOptions.StyleEnabled, true, false, false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.AntiqueWhite, System.Drawing.SystemColors.ControlText);
            this.cmdNo.TabIndex = 130;
            this.cmdNo.Text = "Thoát";
            this.cmdNo.Click += new System.EventHandler(this.cmdNo_Click);
            // 
            // frmHuyLanGui
            // 
            this.AcceptButton = this.cmdOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 138);
            this.Controls.Add(this.cmbLanGui);
            this.Controls.Add(this.lbChuDai);
            this.Controls.Add(this.lbThongBao);
            this.Controls.Add(this.cmdNo);
            this.Controls.Add(this.cmdOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmHuyLanGui";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hủy gửi chi phí";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton cmdNo;
        private DevExpress.XtraEditors.SimpleButton cmdOk;
        public System.Windows.Forms.Label lbThongBao;
        public System.Windows.Forms.ComboBox cmbLanGui;
        public System.Windows.Forms.Label lbChuDai;
    }
}