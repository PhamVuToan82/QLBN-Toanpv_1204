namespace NamDinh_QLBN.Forms.TienIch
{
    partial class frmICDPhu_RaVien
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmICDPhu_RaVien));
            this.panel1 = new System.Windows.Forms.Panel();
            this.fgICD = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_ghi = new System.Windows.Forms.Button();
            this.btn_thoat = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fgICD)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.fgICD);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(440, 365);
            this.panel1.TabIndex = 0;
            // 
            // fgICD
            // 
            this.fgICD.AllowDelete = true;
            this.fgICD.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.fgICD.AllowEditing = false;
            this.fgICD.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Light3D;
            this.fgICD.ColumnInfo = resources.GetString("fgICD.ColumnInfo");
            this.fgICD.ExtendLastCol = true;
            this.fgICD.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid;
            this.fgICD.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fgICD.HighLight = C1.Win.C1FlexGrid.HighLightEnum.WithFocus;
            this.fgICD.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.fgICD.Location = new System.Drawing.Point(3, 36);
            this.fgICD.Name = "fgICD";
            this.fgICD.Rows.Count = 1;
            this.fgICD.Rows.MinSize = 20;
            this.fgICD.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
            this.fgICD.ShowCursor = true;
            this.fgICD.Size = new System.Drawing.Size(434, 263);
            this.fgICD.Styles = new C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("fgICD.Styles"));
            this.fgICD.TabIndex = 147;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btn_thoat);
            this.panel2.Controls.Add(this.btn_ghi);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 305);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(440, 60);
            this.panel2.TabIndex = 1;
            // 
            // btn_ghi
            // 
            this.btn_ghi.Image = global::NamDinh_QLBN.Properties.Resources._1221111212;
            this.btn_ghi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_ghi.Location = new System.Drawing.Point(254, 12);
            this.btn_ghi.Name = "btn_ghi";
            this.btn_ghi.Size = new System.Drawing.Size(75, 45);
            this.btn_ghi.TabIndex = 0;
            this.btn_ghi.Text = "Ghi";
            this.btn_ghi.UseVisualStyleBackColor = true;
            this.btn_ghi.Click += new System.EventHandler(this.btn_ghi_Click);
            // 
            // btn_thoat
            // 
            this.btn_thoat.Image = global::NamDinh_QLBN.Properties.Resources.Thoat1;
            this.btn_thoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_thoat.Location = new System.Drawing.Point(347, 12);
            this.btn_thoat.Name = "btn_thoat";
            this.btn_thoat.Size = new System.Drawing.Size(75, 45);
            this.btn_thoat.TabIndex = 1;
            this.btn_thoat.Text = "Thoát";
            this.btn_thoat.UseVisualStyleBackColor = true;
            this.btn_thoat.Click += new System.EventHandler(this.btn_thoat_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(440, 30);
            this.panel3.TabIndex = 148;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(375, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chọn dòng cẩn xóa nhấn nút (Delete) trên bàn phím";
            // 
            // frmICDPhu_RaVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 365);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmICDPhu_RaVien";
            this.Text = "frmICDPhu_RaVien";
            this.TopMost = true;
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fgICD)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private C1.Win.C1FlexGrid.C1FlexGrid fgICD;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_thoat;
        private System.Windows.Forms.Button btn_ghi;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
    }
}