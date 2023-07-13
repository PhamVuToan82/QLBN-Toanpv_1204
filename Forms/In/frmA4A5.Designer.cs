namespace NamDinh_QLBN.Forms.In
{
    partial class frmA4A5
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
            this.raA4 = new System.Windows.Forms.RadioButton();
            this.raA5 = new System.Windows.Forms.RadioButton();
            this.cmbChon = new System.Windows.Forms.Button();
            this.cmdThoat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // raA4
            // 
            this.raA4.AutoSize = true;
            this.raA4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.raA4.Location = new System.Drawing.Point(49, 23);
            this.raA4.Name = "raA4";
            this.raA4.Size = new System.Drawing.Size(50, 25);
            this.raA4.TabIndex = 0;
            this.raA4.TabStop = true;
            this.raA4.Text = "A4";
            this.raA4.UseVisualStyleBackColor = true;
            // 
            // raA5
            // 
            this.raA5.AutoSize = true;
            this.raA5.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.raA5.Location = new System.Drawing.Point(143, 23);
            this.raA5.Name = "raA5";
            this.raA5.Size = new System.Drawing.Size(50, 25);
            this.raA5.TabIndex = 1;
            this.raA5.TabStop = true;
            this.raA5.Text = "A5";
            this.raA5.UseVisualStyleBackColor = true;
            // 
            // cmbChon
            // 
            this.cmbChon.Location = new System.Drawing.Point(22, 67);
            this.cmbChon.Name = "cmbChon";
            this.cmbChon.Size = new System.Drawing.Size(75, 23);
            this.cmbChon.TabIndex = 2;
            this.cmbChon.Text = "Chọn";
            this.cmbChon.UseVisualStyleBackColor = true;
            this.cmbChon.Click += new System.EventHandler(this.cmbChon_Click);
            // 
            // cmdThoat
            // 
            this.cmdThoat.Location = new System.Drawing.Point(119, 67);
            this.cmdThoat.Name = "cmdThoat";
            this.cmdThoat.Size = new System.Drawing.Size(75, 23);
            this.cmdThoat.TabIndex = 3;
            this.cmdThoat.Text = "Thoát";
            this.cmdThoat.UseVisualStyleBackColor = true;
            this.cmdThoat.Click += new System.EventHandler(this.cmdThoat_Click);
            // 
            // frmA4A5
            // 
            this.AcceptButton = this.cmbChon;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdThoat;
            this.ClientSize = new System.Drawing.Size(212, 102);
            this.Controls.Add(this.cmdThoat);
            this.Controls.Add(this.cmbChon);
            this.Controls.Add(this.raA5);
            this.Controls.Add(this.raA4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmA4A5";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn giấy in";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton raA4;
        private System.Windows.Forms.RadioButton raA5;
        private System.Windows.Forms.Button cmbChon;
        private System.Windows.Forms.Button cmdThoat;
    }
}