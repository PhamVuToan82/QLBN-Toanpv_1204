namespace NamDinh_QLBN.Forms.DanhMuc
{
    partial class frmFindDoiTuongBHYT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFindDoiTuongBHYT));
            this.fgNoiDK = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFind = new System.Windows.Forms.TextBox();
            this.cmdFind = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cmdChon = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.fgNoiDK)).BeginInit();
            this.SuspendLayout();
            // 
            // fgNoiDK
            // 
            this.fgNoiDK.AllowDelete = true;
            this.fgNoiDK.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.fgNoiDK.AllowEditing = false;
            this.fgNoiDK.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.fgNoiDK.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle;
            this.fgNoiDK.ColumnInfo = resources.GetString("fgNoiDK.ColumnInfo");
            this.fgNoiDK.ExtendLastCol = true;
            this.fgNoiDK.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid;
            this.fgNoiDK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fgNoiDK.Location = new System.Drawing.Point(3, 76);
            this.fgNoiDK.Name = "fgNoiDK";
            this.fgNoiDK.Rows.Count = 1;
            this.fgNoiDK.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox;
            this.fgNoiDK.ShowCursor = true;
            this.fgNoiDK.Size = new System.Drawing.Size(362, 422);
            this.fgNoiDK.Styles = new C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("fgNoiDK.Styles"));
            this.fgNoiDK.TabIndex = 135;
            this.fgNoiDK.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.fgNoiDK_MouseDoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(4, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 17);
            this.label2.TabIndex = 156;
            this.label2.Text = "Danh sách";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MediumBlue;
            this.label1.Location = new System.Drawing.Point(4, -2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 21);
            this.label1.TabIndex = 155;
            this.label1.Text = "Tìm kiếm";
            // 
            // txtFind
            // 
            this.txtFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFind.Location = new System.Drawing.Point(5, 27);
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(324, 24);
            this.txtFind.TabIndex = 153;
            this.txtFind.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtFind_KeyUp);
            // 
            // cmdFind
            // 
            this.cmdFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdFind.Image = global::NamDinh_QLBN.Properties.Resources.Soi16;
            this.cmdFind.Location = new System.Drawing.Point(334, 25);
            this.cmdFind.Name = "cmdFind";
            this.cmdFind.Size = new System.Drawing.Size(30, 26);
            this.cmdFind.TabIndex = 157;
            this.cmdFind.UseVisualStyleBackColor = true;
            this.cmdFind.Click += new System.EventHandler(this.cmdFind_Click);
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(293, 501);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(69, 27);
            this.button1.TabIndex = 158;
            this.button1.Text = " Thoát";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmdChon
            // 
            this.cmdChon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdChon.Image = ((System.Drawing.Image)(resources.GetObject("cmdChon.Image")));
            this.cmdChon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdChon.Location = new System.Drawing.Point(184, 501);
            this.cmdChon.Name = "cmdChon";
            this.cmdChon.Size = new System.Drawing.Size(78, 26);
            this.cmdChon.TabIndex = 159;
            this.cmdChon.Text = "Chọn";
            this.cmdChon.UseVisualStyleBackColor = true;
            this.cmdChon.Click += new System.EventHandler(this.cmdChon_Click);
            // 
            // frmFindNoiDangKy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 530);
            this.Controls.Add(this.cmdChon);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmdFind);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFind);
            this.Controls.Add(this.fgNoiDK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFindNoiDangKy";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Tìm nơi đăng ký";
            this.Load += new System.EventHandler(this.frmFindNoiDangKy_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fgNoiDK)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private C1.Win.C1FlexGrid.C1FlexGrid fgNoiDK;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFind;
        private System.Windows.Forms.Button cmdFind;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button cmdChon;
    }
}