namespace NamDinh_QLBN.Forms.DuLieu.KetQuaCLS
{
    partial class FrmKetQuaXetNghiem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmKetQuaXetNghiem));
            this.cmdThoat = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.fgChiTiet = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.fgChiTiet)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdThoat
            // 
            this.cmdThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdThoat.Image = ((System.Drawing.Image)(resources.GetObject("cmdThoat.Image")));
            this.cmdThoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdThoat.Location = new System.Drawing.Point(702, 481);
            this.cmdThoat.Name = "cmdThoat";
            this.cmdThoat.Size = new System.Drawing.Size(96, 30);
            this.cmdThoat.TabIndex = 104;
            this.cmdThoat.Text = "     T&hoát";
            this.cmdThoat.UseVisualStyleBackColor = true;
            this.cmdThoat.Click += new System.EventHandler(this.cmdThoat_Click);
            // 
            // Label1
            // 
            this.Label1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(-1, 1);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(532, 41);
            this.Label1.TabIndex = 103;
            this.Label1.Text = "KẾT QUẢ XÉT NGHIỆM";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fgChiTiet
            // 
            this.fgChiTiet.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.fgChiTiet.AllowEditing = false;
            this.fgChiTiet.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Free;
            this.fgChiTiet.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Light3D;
            this.fgChiTiet.ColumnInfo = resources.GetString("fgChiTiet.ColumnInfo");
            this.fgChiTiet.ExtendLastCol = true;
            this.fgChiTiet.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid;
            this.fgChiTiet.HighLight = C1.Win.C1FlexGrid.HighLightEnum.WithFocus;
            this.fgChiTiet.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.fgChiTiet.Location = new System.Drawing.Point(1, 44);
            this.fgChiTiet.Name = "fgChiTiet";
            this.fgChiTiet.Rows.Count = 1;
            this.fgChiTiet.Rows.MinSize = 30;
            this.fgChiTiet.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
            this.fgChiTiet.ShowCursor = true;
            this.fgChiTiet.Size = new System.Drawing.Size(797, 426);
            this.fgChiTiet.Styles = new C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("fgChiTiet.Styles"));
            this.fgChiTiet.TabIndex = 102;
            this.fgChiTiet.Tree.Column = 4;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(534, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(263, 41);
            this.label2.TabIndex = 105;
            this.label2.Text = "BẤM VÀO XEM HÌNH ẢNH PACS";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // FrmKetQuaXetNghiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 523);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmdThoat);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.fgChiTiet);
            this.Name = "FrmKetQuaXetNghiem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xem kết quả xết nghiệm";
            this.Load += new System.EventHandler(this.FrmKetQuaXetNghiem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fgChiTiet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button cmdThoat;
        internal System.Windows.Forms.Label Label1;
        private C1.Win.C1FlexGrid.C1FlexGrid fgChiTiet;
        internal System.Windows.Forms.Label label2;
    }
}