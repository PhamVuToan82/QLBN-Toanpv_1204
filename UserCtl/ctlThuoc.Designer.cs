namespace NamDinh_QLBN.UserCtl
{
    partial class CtlThuoc
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlThuoc));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.fg = new C1.Win.C1FlexGrid.C1FlexGrid();
            ((System.ComponentModel.ISupportInitialize)(this.fg)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(31, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(268, 20);
            this.textBox1.TabIndex = 0;
            // 
            // fg
            // 
            this.fg.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.fg.AllowEditing = false;
            this.fg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Light3D;
            this.fg.ColumnInfo = "3,1,1,0,0,90,Columns:0{Width:73;Caption:\"Mã thuốc\";Format:\"00\";TextAlignFixed:Cen" +
                "terCenter;}\t1{Width:201;Caption:\"Tên thuốc\";TextAlignFixed:CenterCenter;}\t2{Widt" +
                "h:47;Caption:\"ĐV Tính\";}\t";
            this.fg.ExtendLastCol = true;
            this.fg.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid;
            this.fg.HighLight = C1.Win.C1FlexGrid.HighLightEnum.WithFocus;
            this.fg.Location = new System.Drawing.Point(31, 29);
            this.fg.Name = "fg";
            this.fg.Rows.Count = 1;
            this.fg.Rows.MinSize = 20;
            this.fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
            this.fg.ShowCursor = true;
            this.fg.Size = new System.Drawing.Size(268, 342);
            this.fg.Styles = new C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("fg.Styles"));
            this.fg.TabIndex = 19;
            // 
            // CtlThuoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.fg);
            this.Controls.Add(this.textBox1);
            this.Name = "CtlThuoc";
            this.Size = new System.Drawing.Size(302, 374);
            ((System.ComponentModel.ISupportInitialize)(this.fg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private C1.Win.C1FlexGrid.C1FlexGrid fg;
    }
}
