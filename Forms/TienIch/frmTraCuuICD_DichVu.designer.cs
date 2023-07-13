namespace NamDinh_QLBN.Forms.Tien_ich
{
    partial class frmTraCuuICD_DichVu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTraCuuICD_DichVu));
            this.fgICD = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.txtTenICD = new System.Windows.Forms.TextBox();
            this.cmdChon = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtMaICD = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdFind = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.fgICD)).BeginInit();
            this.SuspendLayout();
            // 
            // fgICD
            // 
            this.fgICD.AllowDelete = true;
            this.fgICD.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.fgICD.AllowEditing = false;
            this.fgICD.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fgICD.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Light3D;
            this.fgICD.ColumnInfo = resources.GetString("fgICD.ColumnInfo");
            this.fgICD.ExtendLastCol = true;
            this.fgICD.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid;
            this.fgICD.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fgICD.HighLight = C1.Win.C1FlexGrid.HighLightEnum.WithFocus;
            this.fgICD.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.fgICD.Location = new System.Drawing.Point(2, 78);
            this.fgICD.Name = "fgICD";
            this.fgICD.Rows.Count = 1;
            this.fgICD.Rows.MinSize = 20;
            this.fgICD.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
            this.fgICD.ShowCursor = true;
            this.fgICD.Size = new System.Drawing.Size(453, 475);
            this.fgICD.Styles = new C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("fgICD.Styles"));
            this.fgICD.TabIndex = 146;
            this.fgICD.AfterSelChange += new C1.Win.C1FlexGrid.RangeEventHandler(this.fgICD_AfterSelChange);
            this.fgICD.DoubleClick += new System.EventHandler(this.fgICD_DoubleClick);
            // 
            // txtTenICD
            // 
            this.txtTenICD.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenICD.Location = new System.Drawing.Point(70, 30);
            this.txtTenICD.Name = "txtTenICD";
            this.txtTenICD.Size = new System.Drawing.Size(347, 24);
            this.txtTenICD.TabIndex = 147;
            this.txtTenICD.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtTenICD_KeyUp);
            // 
            // cmdChon
            // 
            this.cmdChon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdChon.Image = ((System.Drawing.Image)(resources.GetObject("cmdChon.Image")));
            this.cmdChon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdChon.Location = new System.Drawing.Point(250, 558);
            this.cmdChon.Name = "cmdChon";
            this.cmdChon.Size = new System.Drawing.Size(81, 26);
            this.cmdChon.TabIndex = 148;
            this.cmdChon.Text = "Chọn";
            this.cmdChon.UseVisualStyleBackColor = true;
            this.cmdChon.Click += new System.EventHandler(this.cmdChon_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(363, 558);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(81, 26);
            this.button1.TabIndex = 149;
            this.button1.Text = "Thoát";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtMaICD
            // 
            this.txtMaICD.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaICD.Location = new System.Drawing.Point(5, 30);
            this.txtMaICD.Name = "txtMaICD";
            this.txtMaICD.Size = new System.Drawing.Size(59, 24);
            this.txtMaICD.TabIndex = 150;
            this.txtMaICD.TextChanged += new System.EventHandler(this.txtMaICD_TextChanged);
            this.txtMaICD.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtMaICD_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MediumBlue;
            this.label1.Location = new System.Drawing.Point(5, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 21);
            this.label1.TabIndex = 151;
            this.label1.Text = "Tìm kiếm";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(5, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 17);
            this.label2.TabIndex = 152;
            this.label2.Text = "Danh sách ICD";
            // 
            // cmdFind
            // 
            this.cmdFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdFind.Image = global::NamDinh_QLBN.Properties.Resources.Soi16;
            this.cmdFind.Location = new System.Drawing.Point(422, 30);
            this.cmdFind.Name = "cmdFind";
            this.cmdFind.Size = new System.Drawing.Size(30, 26);
            this.cmdFind.TabIndex = 153;
            this.cmdFind.UseVisualStyleBackColor = true;
            this.cmdFind.Click += new System.EventHandler(this.cmdFind_Click);
            // 
            // frmTraCuuICD_DichVu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 589);
            this.ControlBox = false;
            this.Controls.Add(this.cmdFind);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMaICD);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmdChon);
            this.Controls.Add(this.txtTenICD);
            this.Controls.Add(this.fgICD);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmTraCuuICD_DichVu";
            this.ShowInTaskbar = false;
            this.Text = "Tra cứu Mã ICD";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.fgICD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtTenICD;
        private System.Windows.Forms.Button cmdChon;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtMaICD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdFind;
        private C1.Win.C1FlexGrid.C1FlexGrid fgICD;
    }
}