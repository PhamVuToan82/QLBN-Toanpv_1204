namespace NamDinh_QLBN.Forms.DuLieu.DuyetPhieuCD
{
    partial class frmThemThongTinThuongTich
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtThuongTich_Befor = new System.Windows.Forms.TextBox();
            this.txtThuongTich_After = new System.Windows.Forms.TextBox();
            this.BtnGhi = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tình trạng thương tích khi vào viện:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tình trạng thương tích khi ra viện:";
            // 
            // txtThuongTich_Befor
            // 
            this.txtThuongTich_Befor.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtThuongTich_Befor.Location = new System.Drawing.Point(28, 30);
            this.txtThuongTich_Befor.Multiline = true;
            this.txtThuongTich_Befor.Name = "txtThuongTich_Befor";
            this.txtThuongTich_Befor.Size = new System.Drawing.Size(508, 103);
            this.txtThuongTich_Befor.TabIndex = 2;
            // 
            // txtThuongTich_After
            // 
            this.txtThuongTich_After.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txtThuongTich_After.Location = new System.Drawing.Point(27, 153);
            this.txtThuongTich_After.Multiline = true;
            this.txtThuongTich_After.Name = "txtThuongTich_After";
            this.txtThuongTich_After.Size = new System.Drawing.Size(508, 103);
            this.txtThuongTich_After.TabIndex = 3;
            // 
            // BtnGhi
            // 
            this.BtnGhi.Location = new System.Drawing.Point(361, 260);
            this.BtnGhi.Name = "BtnGhi";
            this.BtnGhi.Size = new System.Drawing.Size(75, 32);
            this.BtnGhi.TabIndex = 4;
            this.BtnGhi.Text = "Ghi";
            this.BtnGhi.UseVisualStyleBackColor = true;
            this.BtnGhi.Click += new System.EventHandler(this.BtnGhi_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(455, 260);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(79, 32);
            this.button2.TabIndex = 5;
            this.button2.Text = "IN";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // frmThemThongTinThuongTich
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 296);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.BtnGhi);
            this.Controls.Add(this.txtThuongTich_After);
            this.Controls.Add(this.txtThuongTich_Befor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmThemThongTinThuongTich";
            this.Text = "Cập Nhật Tình Trạng Thương Tích";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtThuongTich_Befor;
        private System.Windows.Forms.TextBox txtThuongTich_After;
        private System.Windows.Forms.Button BtnGhi;
        private System.Windows.Forms.Button button2;
    }
}