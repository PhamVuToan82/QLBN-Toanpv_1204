namespace NamDinh_QLBN.Forms.DuLieu
{
    partial class frmSoDoGiuongBenh
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSoDoGiuongBenh));
            this.fgDanhSach = new C1.Win.C1FlexGrid.C1FlexGrid();
            ((System.ComponentModel.ISupportInitialize)(this.fgDanhSach)).BeginInit();
            this.SuspendLayout();
            // 
            // fgDanhSach
            // 
            this.fgDanhSach.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.fgDanhSach.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Light3D;
            this.fgDanhSach.ColumnInfo = "0,0,0,0,0,95,Columns:";
            this.fgDanhSach.ExtendLastCol = true;
            this.fgDanhSach.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid;
            this.fgDanhSach.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fgDanhSach.HighLight = C1.Win.C1FlexGrid.HighLightEnum.WithFocus;
            this.fgDanhSach.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.fgDanhSach.Location = new System.Drawing.Point(2, 12);
            this.fgDanhSach.Name = "fgDanhSach";
            this.fgDanhSach.Rows.Count = 1;
            this.fgDanhSach.Rows.MinSize = 20;
            this.fgDanhSach.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
            this.fgDanhSach.ShowCursor = true;
            this.fgDanhSach.Size = new System.Drawing.Size(802, 426);
            this.fgDanhSach.Styles = new C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("fgDanhSach.Styles"));
            this.fgDanhSach.TabIndex = 247;
            // 
            // frmSoDoGiuongBenh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.fgDanhSach);
            this.Name = "frmSoDoGiuongBenh";
            this.Text = "frmSoDoGiuongBenh";
            this.Load += new System.EventHandler(this.frmSoDoGiuongBenh_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fgDanhSach)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private C1.Win.C1FlexGrid.C1FlexGrid fgDanhSach;
    }
}