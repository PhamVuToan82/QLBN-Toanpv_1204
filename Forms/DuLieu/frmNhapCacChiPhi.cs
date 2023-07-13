using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using C1.Win.C1FlexGrid;
using GlobalModuls;

namespace NamDinh_QLBN.Forms.DuLieu
{
    public partial class frmNhapCacChiPhi : Form
    {
        public C1.Win.C1FlexGrid.C1FlexGrid fg;
        public int MucGiaApDung=0;
        public string MaKhoaNhapLieu = "";
        public string TenPhuongPhapDT = "";
        public string MaLoaiDT = "";
        public string MaPPDT = "";
        public frmNhapCacChiPhi()
        {
            InitializeComponent();
        }

        private void frmNhapCacChiPhi_Load(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            SQLCmd.CommandText = "SELECT * FROM DMLOAICHIPHI ORDER BY MaLoai";
            dr = SQLCmd.ExecuteReader();
            while (dr.Read())
            {
                cmbLoaiCP.AddItem(string.Format("{0};{1}",dr["MaLoai"],dr["TenLoai"]));
            }
            dr.Close();
            SQLCmd.Dispose();
            Load_DMCLS();
            txtTenChiPhi.Tag = "1";
        }

        private void txtTenChiPhi_TextChanged(object sender, EventArgs e)
        {
            if (txtTenChiPhi.Tag.ToString() == "0") return;
            if (txtTenChiPhi.Text.Length == 0)
            {
                fgDanhMuc.Rows.Count = 1;
                return;
            }

            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            switch (GlobalModuls.Global.GetCode(cmbLoaiCP))
            {
                case "1":
                    SQLCmd.CommandText = string.Format("select ThuocID as [Mã thuốc],TenThuoc as [Tên thuốc],DonViTinh as [ĐVT],MaNuoc as [Nước SX] FROM DMTHUOC WHERE TenThuoc Like N'{0}%' ORDER BY TenThuoc", txtTenChiPhi.Text);
                    break;
                case "2":
                    SQLCmd.CommandText = string.Format("SELECT maCLS as [Mã CLS],TenCLS as [Tên CLS], DVT As [ĐVT],'' FROM DMCANLAMSANG WHERE TenCLS Like N'%{0}%' AND LoaiXN=1 ORDER BY TenCLS", txtTenChiPhi.Text);
                    break;
                case "3":
                    SQLCmd.CommandText = string.Format("select ThuocID as [Mã VTTH],TenThuoc as [Tên VTTH],DonViTinh as [ĐVT],MaNuoc as [Nước SX] FROM DMVATTUTIEUHAO WHERE TenThuoc Like N'{0}%' ORDER BY TenThuoc", txtTenChiPhi.Text);
                    break;
                default:
                    SQLCmd.CommandText = string.Format("select MaCP as [Mã CP],TenCP as [Tên CP],DVTinh as [ĐVT],'' FROM ViewDMCHIPHI WHERE TenCP Like N'{0}%' AND LoaiCP ={1} ORDER BY TenCP", txtTenChiPhi.Text,Global.GetCode(cmbLoaiCP));
                    break;
            }

            dr = SQLCmd.ExecuteReader();
            fgDanhMuc.Redraw = false;
            fgDanhMuc.Tag = "0";
            fgDanhMuc.Rows.Count = 1;
            fgDanhMuc.Cols.Count = dr.FieldCount + 1;
            fgDanhMuc[0, 0] = "STT";
            for (int i = 0; i < dr.FieldCount; i++)
            {
                fgDanhMuc[0, i + 1] = dr.GetName(i);
            }
            while (dr.Read())
            {
                fgDanhMuc.AddItem("");
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    fgDanhMuc[fgDanhMuc.Rows.Count - 1, i + 1] = dr[i].ToString();
                }
            }
            fgDanhMuc.Redraw = true;
            fgDanhMuc.Tag = "1";
            if (fgDanhMuc.Rows.Count > 1) 
            {
                int OldLength = txtTenChiPhi.Text.Length;
                fgDanhMuc.Row = 1;
                txtTenChiPhi.Tag = "0";
                txtTenChiPhi.Text = fgDanhMuc.GetDataDisplay(1, 2);
                txtTenChiPhi.Select(OldLength, txtTenChiPhi.Text.Length-OldLength);
                txtTenChiPhi.Tag = "1";
                lblTen.Text = fgDanhMuc.GetDataDisplay(fgDanhMuc.Row, 2);
                lblTen.Tag = fgDanhMuc.GetDataDisplay(fgDanhMuc.Row, 1);
            }
            dr.Close();
            SQLCmd.Dispose();
        }
        private void AddItemToGrid(string MaCP,byte LoaiCP)
        {
            string TenLoai = "";           
            fg.Tag = "0";
            decimal SoLuong = txtSL.Value;
            for (int i = 1; i < fg.Rows.Count; i++)
            {
                if ((fg.GetDataDisplay(i, "TenPPDT") == TenPhuongPhapDT && fg.GetDataDisplay(i, "MaCP") == MaCP && byte.Parse(fg.GetDataDisplay(i, "LoaiCP"))==LoaiCP) && LoaiCP != 2)
                {
                    MessageBox.Show("Đã có chi phí trong danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            int LanChiDinh = 0;
            for (int i = 1; i < fg.Rows.Count; i++)
            {
                if (fg.GetDataDisplay(i, "MaCP") == MaCP && LoaiCP ==2)
                {
                    if (LanChiDinh < int.Parse(fg.GetDataDisplay(i, "LanChiDinh")))
                    {
                        LanChiDinh = int.Parse(fg.GetDataDisplay(i, "LanChiDinh"));
                    }
                }
            }
            LanChiDinh += 1;
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;

            SQLCmd.CommandText = "SELECT TenLoai,ViewDMCHIPHI.MaCP,TenCP,DVTinh,DonGia,DonGia_QT,ViewDMCHIPHI.LoaiCP "
                                + " FROM (ViewDMCHIPHI LEFT JOIN (SELECT LoaiCP,MaCP,DonGia,DonGia_QT FROM DMCHIPHI_GIA WHERE LoaiCP=" + LoaiCP + " AND MaCP='" + MaCP + "' AND MucGia=" + MucGiaApDung + ")Q1 "
                                + " ON ViewDMCHIPHI.MaCP = Q1.MaCP AND ViewDMCHIPHI.LoaiCP = Q1.LoaiCP) "
                                + " INNER JOIN DMLOAICHIPHI ON ViewDMCHIPHI.LoaiCP=DMLOAICHIPHI.MaLoai"
                                + " WHERE ViewDMCHIPHI.LoaiCP=" + LoaiCP + " AND ViewDMCHIPHI.MaCP='" + MaCP + "'";
            dr = SQLCmd.ExecuteReader();
            string strAddItem = "";
            while (dr.Read())
            {
                strAddItem = string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7:#,###}|{8:#,###}|{9:#,###}|{10:#,###}|{11}|{12}|{13}|{14}|{15}|{16}|{17}|{18}",
                            TenPhuongPhapDT,dr["TenLoai"], 1, dr["maCP"], dr["tenCP"], dr["DVTinh"],
                            SoLuong, dr["DonGia"], dr["DonGia_QT"], dr["DonGia"], dr["DonGia_QT"], LoaiCP, (LoaiCP <=3) ? (0) : (1), (LoaiCP == 2) ? ("Lần " + LanChiDinh + string.Format(" ({0:HH:mm})", DateTime.Now)) : (""), LanChiDinh, MaLoaiDT, MaPPDT,Global.glbTenTatKhoaPhong,Global.glbMaKhoaPhong);
                TenLoai = dr["TenLoai"].ToString();
            }
            dr.Close();
            
            SQLCmd.Dispose();
            bool DaCo = false;
            int j = 0;
            for (int t = 2; t < fg.Rows.Count; t++)
            {
                if (fg.GetDataDisplay(t, "TenPPDT") == TenPhuongPhapDT)
                {
                    for (int i = t; i < fg.Rows.Count; i++)
                    {
                        if (fg.GetDataDisplay(i, "TenLoai") == TenLoai)
                        {
                            for (j = i; j < fg.Rows.Count; j++)
                            {
                                if (fg.GetDataDisplay(j, "TenLoai") != TenLoai)
                                {
                                    fg.AddItem(strAddItem, j);
                                    fg[j, "STT"] = j - i + 1;
                                    DaCo = true;
                                    break;
                                }
                            }
                            if (!DaCo)
                            {
                                fg.AddItem(strAddItem, j);
                                fg[j, "STT"] = j - i + 1;
                                DaCo = true;
                            }
                            break;
                        }
                    }
                    break;
                }
            }
            fg.Redraw = false;
            if (!DaCo)
            {            
                fg.AddItem(strAddItem);
            }
            fg.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.Clear);
            fg.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.Sum, 0, 0, 9, "{0}");
            fg.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.Sum, 1, 1, 9, "{0}");
            fg.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.Sum, 0, 0, 8, "{0}");
            fg.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.Sum, 1, 1, 8, "{0}");
            fg.Redraw = true;
            fg.Tag = "1";
        }

        private void cmdXoa_Click(object sender, EventArgs e)
        {
            fg.Focus();
            this.Dispose();
        }

        private void cmbLoaiCP_TextChanged(object sender, EventArgs e)
        {
            txtTenChiPhi.Text = "";
            treeCLS.Visible = false;
            fgDanhMuc.Visible = true;
            label1.Visible = true;
            txtTenChiPhi.Visible = true;
            txtSL.Visible  = true;
            label3.Visible = true;
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            switch (Global.GetCode(cmbLoaiCP))
            {
                case "1":
                case "3":
                    fgDanhMuc.Rows.Count = 1;
                    break;
                case "2":
                    txtSL.Value = 1;                   
                    treeCLS.Visible = true;
                    fgDanhMuc.Visible = false;
                    label1.Visible = false;
                    txtTenChiPhi.Visible = false;
                    label3.Visible = false;
                    txtSL.Visible = false;
                    break;
                case "4":
                    SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
                    SQLCmd.CommandText = string.Format("select MaCP as [Mã CP],TenCP as [Tên CP],DVTinh as [ĐVT],'' FROM ViewDMCHIPHI INNER JOIN DMGIUONG_KHOA ON ViewDMCHIPHI.MaCP=DMGIUONG_KHOA.MaGiuong AND DMGIUONG_KHOA.MaKhoa ='{0}' WHERE LoaiCP ={1} ORDER BY TenCP", MaKhoaNhapLieu, Global.GetCode(cmbLoaiCP));
                    dr = SQLCmd.ExecuteReader();
                    fgDanhMuc.Redraw = false;
                    fgDanhMuc.Tag = "0";
                    fgDanhMuc.Rows.Count = 1;
                    fgDanhMuc.Cols.Count = dr.FieldCount + 1;
                    fgDanhMuc[0, 0] = "STT";
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        fgDanhMuc[0, i + 1] = dr.GetName(i);
                    }
                    while (dr.Read())
                    {
                        fgDanhMuc.AddItem("");
                        for (int i = 0; i < dr.FieldCount; i++)
                        {
                            fgDanhMuc[fgDanhMuc.Rows.Count - 1, i + 1] = dr[i].ToString();
                        }
                    }
                    fgDanhMuc.Redraw = true;
                    fgDanhMuc.Tag = "1";
                    if (fgDanhMuc.Rows.Count > 1) { fgDanhMuc.Row = 1; }
                    dr.Close();
                    break;
                default:
                    SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
                    SQLCmd.CommandText = string.Format("select MaCP as [Mã CP],TenCP as [Tên CP],DVTinh as [ĐVT],'' FROM ViewDMCHIPHI WHERE LoaiCP ={0} ORDER BY TenCP", Global.GetCode(cmbLoaiCP));
                    dr = SQLCmd.ExecuteReader();
                    fgDanhMuc.Redraw = false;
                    fgDanhMuc.Tag = "0";
                    fgDanhMuc.Rows.Count = 1;
                    fgDanhMuc.Cols.Count = dr.FieldCount + 1;
                    fgDanhMuc[0, 0] = "STT";
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        fgDanhMuc[0, i + 1] = dr.GetName(i);
                    }
                    while (dr.Read())
                    {
                        fgDanhMuc.AddItem("");
                        for (int i = 0; i < dr.FieldCount; i++)
                        {
                            fgDanhMuc[fgDanhMuc.Rows.Count - 1, i + 1] = dr[i].ToString();
                        }
                    }
                    fgDanhMuc.Redraw = true;
                    fgDanhMuc.Tag = "1";
                    if (fgDanhMuc.Rows.Count > 1) { fgDanhMuc.Row = 1; }
                    dr.Close();
                    break;                    
            }
            SQLCmd.Dispose();      
        }

        private void fgDanhMuc_KeyUp(object sender, KeyEventArgs e)
        {            

        }
        private void Load_DMCLS()
        {
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlDataReader dr;
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            SQLCmd.CommandText = "SELECT * FROM DMCANLAMSANG ORDER BY MaCLS";
            dr = SQLCmd.ExecuteReader();
            TreeNode cNode = null, pNode = null;
            int NodeLevel = 0;
            cNode = new TreeNode();
            cNode.Name = "root";
            cNode.Text = "Danh mục xét nghiệm";
            cNode.ForeColor = Color.Blue;
            treeCLS.Nodes.Add(cNode);
            while (dr.Read())
            {
                pNode = treeCLS.Nodes["root"];
                NodeLevel = dr["MaCLS"].ToString().Length / 2;
                for (int i = 1; i < NodeLevel; i++)
                {
                    pNode = pNode.Nodes[dr["MaCLS"].ToString().Substring(0, i * 2)];
                }
                cNode = new TreeNode();
                cNode.Name = dr["MaCLS"].ToString();
                cNode.Text = dr["TenCLS"].ToString();
                if (dr["LoaiXN"].ToString() == "False")
                {
                    cNode.ForeColor = Color.Blue;
                }
                else
                {
                    cNode.ForeColor = Color.Black;
                }
                pNode.Nodes.Add(cNode);
            }
            dr.Close();
            SQLCmd.Dispose();
        }

        private void fgDanhMuc_DoubleClick(object sender, EventArgs e)
        {
            if (fgDanhMuc.Row < 1) { return; }
            txtSL.Focus();
        }

        private void treeCLS_DoubleClick(object sender, EventArgs e)
        {
            if (treeCLS.SelectedNode == null || treeCLS.SelectedNode.ForeColor == Color.Blue) { return; }
            AddItemToGrid(treeCLS.SelectedNode.Name, 2); 

        }

        private void treeCLS_KeyUp(object sender, KeyEventArgs e)
        {
            if (treeCLS.SelectedNode == null || treeCLS.SelectedNode.ForeColor == Color.Blue || e.KeyCode != Keys.Enter) { return; }
            AddItemToGrid(treeCLS.SelectedNode.Name, 2);             
        }

        private void fgDanhMuc_AfterSelChange(object sender, C1.Win.C1FlexGrid.RangeEventArgs e)
        {
            if (fgDanhMuc.Tag.ToString() == "0" || fgDanhMuc.Row<1) { return; }
            lblTen.Text = fgDanhMuc[fgDanhMuc.Row, 2].ToString();
            lblTen.Tag = fgDanhMuc.GetDataDisplay(fgDanhMuc.Row, 1);
        }

        private void txtSL_KeyUp(object sender, KeyEventArgs e)
        {
            if (lblTen.Text != "" && e.KeyCode == Keys.Enter)
            {               
                AddItemToGrid(lblTen.Tag.ToString(), byte.Parse(GlobalModuls.Global.GetCode(cmbLoaiCP)));
                if (Global.GetCode(cmbLoaiCP) == "2")
                {
                    treeCLS.Focus();
                }
                else
                {
                    txtTenChiPhi.Focus();                   
                }
            }
        }

        private void treeCLS_AfterSelect(object sender, TreeViewEventArgs e)
        {
            lblTen.Text = treeCLS.SelectedNode.Text;
            lblTen.Tag = treeCLS.SelectedNode.Tag;
        }

        private void txtSL_Enter(object sender, EventArgs e)
        {
            txtSL.Select(0, txtSL.Text.Length);
        }

        private void txtTenChiPhi_Enter(object sender, EventArgs e)
        {
            txtTenChiPhi.Select(0, txtTenChiPhi.Text.Length);
        }

        private void frmNhapCacChiPhi_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) 
            {               
                this.Dispose();
            }
        }

        private void txtTenChiPhi_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                //case Keys.Up:                  
                //    cmbLoaiCP.Focus();                    
                //    break;
                case Keys.Down:                  
                    if (fgDanhMuc.Rows.Count>1) fgDanhMuc.Focus();
                    break;
                case Keys.Enter:
                    txtSL.Focus();
                    break;
            }
        }

        private void fgDanhMuc_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void fgDanhMuc_KeyUp_1(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    if (fgDanhMuc.Row == 1) { e.SuppressKeyPress = false; txtTenChiPhi.Focus(); }
                    break;
                case Keys.Enter:
                    txtSL.Focus();
                    //AddItemToGrid(fgDanhMuc.GetDataDisplay(fgDanhMuc.Row, 1), byte.Parse(GlobalModuls.Global.GetCode(cmbLoaiCP))); 
                    break;
            }
        }

        private void fgDanhMuc_Enter(object sender, EventArgs e)
        {
            if (fgDanhMuc.Tag.ToString() == "0" || fgDanhMuc.Rows.Count < 2) { return; }
            lblTen.Text = fgDanhMuc[1, 2].ToString();
            lblTen.Tag = fgDanhMuc.GetDataDisplay(1, 1);
        }
    }
}