using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;
using GlobalModuls;
using C1.Win.C1FlexGrid;

namespace NamDinh_QLBN.Forms.Tien_ich
{
    public partial class frmQuanLy_BuongGiuong : Form
    {
        public frmQuanLy_BuongGiuong()
        {
            InitializeComponent();
        }

        private void frmQuanLy_BuongGiuong_Load(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            SQLCmd.CommandText = "SELECT * FROM DMKHOAPHONG WHERE MaKhoa IN" + Global.glbKhoa_CapNhat;
            dr = SQLCmd.ExecuteReader();
            cmbKhoa.Tag = "0";
            cmbKhoa.ClearItems();
            while (dr.Read())
            {
                cmbKhoa.AddItem(string.Format("{0};{1}", dr["MaKhoa"], dr["TenKhoa"]));
            }
            cmbKhoa.SelectedIndex = -1;
            cmbKhoa.Tag = "1";
            dr.Close();
            SQLCmd.Dispose();
            fgDanhSach.ClipSeparators = "|;";
            fgDanhSach.Cols[0].Visible = false;
            fgDanhSach.Cols[1].Visible = false;
            fgDanhSach.Cols[2].Visible = false;
            CellStyle s = fgDanhSach.Styles["Vang"];
            if (s == null)
            {
                s = fgDanhSach.Styles.Add("Vang");
                s.ForeColor = Color.DarkOrange;
            }
            s = fgDanhSach.Styles["Xanh"];
            if (s == null)
            {
                s = fgDanhSach.Styles.Add("Xanh");
                s.ForeColor  = Color.Green;
            }
            s = fgDanhSach.Styles["Do"];
            if (s == null)
            {
                s = fgDanhSach.Styles.Add("Do");
                s.ForeColor  = Color.Red;                
            }
            Global.SetCmb(cmbKhoa, Global.glbMaKhoaPhong);
        }

        private void cmbKhoa_TextChanged(object sender, EventArgs e)
        {
            if (cmbKhoa.Tag.ToString() == "0") { return; }
                        System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlDataReader dr;
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            SQLCmd.CommandText = string.Format("SELECT DMGIUONGBENH.*,TenBuong,TenKhoa,TenDichVu "
                                                + " FROM ((DMGIUONGBENH LEFT JOIN DMDICHVU ON DMGIUONGBENH.LoaiGiuong=DMDICHVU.MaDichVu AND LoaiDichVu='B01' AND DMGIUONGBENH.MaKhoa='{0}') "
                                                + " INNER JOIN DMBUONGBENH ON DMGIUONGBENH.ID_Buong=DMBUONGBENH.ID_Buong AND DMGIUONGBENH.MaKhoa=DMBUONGBENH.MaKhoa AND DMGIUONGBENH.MaKhoa='{0}') "
                                                + " INNER JOIN DMKHOAPHONG ON DMGIUONGBENH.MaKhoa=DMKHOAPHONG.MaKhoa AND DMGIUONGBENH.MaKhoa='{0}'"
                                                + " WHERE DMGIUONGBENH.MaKhoa='{0}' ORDER BY DMBUONGBENH.ID_Buong", Global.GetCode(cmbKhoa));
            dr = SQLCmd.ExecuteReader();
            fgDanhSach.Rows.Count = 1;
            fgDanhSach.Redraw = false;
            while (dr.Read())
            {
                fgDanhSach.AddItem(string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|Còn trống",dr["MaKhoa"],dr["ID_Buong"],dr["ID_Giuong"],dr["TenKhoa"],dr["TenBuong"],dr["TenGiuong"],dr["TenDichVu"]));
            }
            dr.Close();
            if (fgDanhSach.Rows.Count == 1) { SQLCmd.Dispose(); return; }
            CellRange rg = fgDanhSach.GetCellRange(1,7,fgDanhSach.Rows.Count-1,7);
            rg.Style = fgDanhSach.Styles["Xanh"];
            SQLCmd.CommandText = string.Format("SELECT Buong,Giuong,Count(BENHNHAN_CHITIET.MaVaoVien) AS SL FROM BENHNHAN_CHITIET INNER JOIN ViewKhoaHienTai "
                                                + " ON BENHNHAN_CHITIET.MaVaoVien=ViewKHOAHIENTAI.MaVaoVien "  
                                                + " WHERE MaKhoa='{0}' AND TrangThai=1 AND vDaRaVien=0"
                                                + " GROUP BY Buong,Giuong ",Global.GetCode(cmbKhoa));
            dr = SQLCmd.ExecuteReader();            
            while (dr.Read())
            {
                for (int i =1;i<fgDanhSach.Rows.Count;i++)
                    if (fgDanhSach[i, 1].ToString() == dr["Buong"].ToString() && fgDanhSach[i, 2].ToString() == dr["Giuong"].ToString())
                    {
                        fgDanhSach[i, 7] = string.Format("Có {0} bệnh nhân", dr["SL"]);
                        rg = fgDanhSach.GetCellRange(i, 7, i, 7);
                        if (int.Parse(dr["SL"].ToString()) > 1)
                        {
                            rg.Style = fgDanhSach.Styles["Do"];
                        }
                        else
                        {
                            rg.Style = fgDanhSach.Styles["Vang"];
                        }
                    }
            }
            dr.Close();
            fgDanhSach.AutoSizeCols();
            fgDanhSach.Redraw = true;
            SQLCmd.Dispose();
            fgDanhSach.Cols[3].AllowMerging = true;
            fgDanhSach.Cols[4].AllowMerging = true;
        }

        private void fgDanhSach_OwnerDrawCell(object sender, C1.Win.C1FlexGrid.OwnerDrawCellEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.Red , e.Bounds);
            e.DrawCell(DrawCellFlags.Border | DrawCellFlags.Content);
        }

        private void cmdXoa_Click(object sender, EventArgs e)
        {
            PrintDocument pd = fgDanhSach.PrintParameters.PrintDocument;
            pd.DefaultPageSettings.Landscape = true;
            Margins m = pd.DefaultPageSettings.Margins;
            m.Left = 25;
            m.Right = 25;
            m.Top = 25;
            m.Bottom = 25;
            fgDanhSach.PrintGrid("Tinh hinh buong, giường",
                PrintGridFlags.ShowPreviewDialog |
                PrintGridFlags.FitToPageWidth);
        }

        private void cmdThoat_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void fgDanhSach_DoubleClick(object sender, EventArgs e)
        {
            if (fgDanhSach.Col !=7 || fgDanhSach.Row<1) {return;}
            string MaKhoa = fgDanhSach[fgDanhSach.Row, 0].ToString();
            string MaBuong = fgDanhSach[fgDanhSach.Row, 1].ToString();
            string MaGiuong = fgDanhSach[fgDanhSach.Row, 2].ToString();
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            SQLCmd.CommandText = string.Format("SELECT * FROM (((BENHNHAN_CHITIET INNER JOIN BENHNHAN ON BENHNHAN_CHITIET.MaBenhNhan=BENHNHAN.MaBenhNhan) INNER JOIN ViewKHOAHIENTAI ON BENHNHAN_CHITIET.MaVaoVien=ViewKHOAHIENTAI.MaVaoVien) " 
                                + " INNER JOIN ViewDOITUONGHIENTAI ON BENHNHAN_CHITIET.MaVaoVien=ViewDOITUONGHIENTAI.MaVaoVien)"
                                + " INNER JOIN DMDOITUONGBN ON DMDOITUONGBN.MaDT=ViewDOITUONGHIENTAI.DoiTuong "
                                + " WHERE MaKhoa='{0}' AND Buong={1} AND Giuong={2} AND TrangThai=1 AND DaRaVien=0",MaKhoa,MaBuong,MaGiuong );
            dr = SQLCmd.ExecuteReader();
            byte SoBenhNhan = 1;
            string strOUT = string.Format("Khoa {0}:\n  {1}, {2}:\n", fgDanhSach[fgDanhSach.Row, 3].ToString(), fgDanhSach[fgDanhSach.Row, 4].ToString(), fgDanhSach[fgDanhSach.Row, 5].ToString());
            while (dr.Read())
            {
                strOUT += string.Format("{0}.Bệnh nhân: {1} - Đối tượng: {2}\n", SoBenhNhan, dr["HoTen"], dr["TenDT"]);
                SoBenhNhan++;
            }
            dr.Close();
            SQLCmd.Dispose();
            MessageBox.Show(strOUT,"Thông tin bệnh nhân",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}