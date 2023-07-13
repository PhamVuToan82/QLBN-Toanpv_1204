using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GlobalModuls;
using System.IO;
using C1.C1Excel;
using System.Data.SqlClient;
using System.Xml;
namespace NamDinh_QLBN.Forms.In.ChiPhi_BNDDT
{
    public partial class frmDSBNSDVTTH : Form
    {
        public C1.C1Excel.C1XLBook _book;
        public DataSet dsKQ;
        DateTime NgayChotGanNhat, NgayChotTiepTheo;
        public frmDSBNSDVTTH()
        {
            InitializeComponent();
        }

        private void LoatData()
        {
            try
            {
                System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
                SQLCmd.CommandType = CommandType.StoredProcedure;
                if (cmbLoaiBC.SelectedIndex == 0) SQLCmd.CommandText = "GetDSBNSuDungVTTH";// đã thanh toán
                else SQLCmd.CommandText = "GetDSBNSuDungVTTH_Kho"; // đã chỉ định
                System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(SQLCmd);
                SQLCmd.CommandTimeout = 0;
                SqlParameter TuNgay = new SqlParameter("@TuNgay", SqlDbType.DateTime);
                TuNgay.Value = DateTime.Parse(DateTime.Parse(txtTNgay.Value.ToString()).ToShortDateString());
                SQLCmd.Parameters.Add(TuNgay);
                SqlParameter DenNgay = new SqlParameter("@DenNgay", SqlDbType.DateTime);
                DenNgay.Value = DateTime.Parse(DateTime.Parse(txtDNgay.Value.ToString()).ToShortDateString());
                SQLCmd.Parameters.Add(DenNgay);
                SqlParameter PhongKhoa = new SqlParameter("@MaKhoa", SqlDbType.VarChar, 10);
                PhongKhoa.Value = GlobalModuls.Global.GetCode(cmbKhoa);
                SQLCmd.Parameters.Add(PhongKhoa);
                SqlParameter TinhPhi = new SqlParameter("@TinhPhi", SqlDbType.TinyInt);
                if (rdKhongTT.Checked) TinhPhi.Value = 1;
                else TinhPhi.Value = 0;
                SQLCmd.Parameters.Add(TinhPhi);
                SqlParameter Loai = new SqlParameter("@Loai", SqlDbType.TinyInt);
                if (!chVatTu.Checked && !chkThuoc.Checked) Loai.Value = 0; // ko load du lieu
                if (chVatTu.Checked && !chkThuoc.Checked) Loai.Value = 1; // xem vtth
                if (!chVatTu.Checked && chkThuoc.Checked) Loai.Value = 2; // xem thuoc dung chung
                if (chVatTu.Checked && chkThuoc.Checked) Loai.Value = 3; //xem cả 2
                SQLCmd.Parameters.Add(Loai);
                dsKQ = new DataSet();
                dsKQ.Clear();
                da.Fill(dsKQ);
                SQLCmd.Dispose();
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Global.nowait();
            }
        }


        private void frmBaoCaoVatTu_Load(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            SQLCmd.CommandText = "SELECT * FROM DMKHOAPHONG WHERE Len(MaKHoa)>1 AND MaKhoa IN " + Global.glbKhoa_CapNhat;
            dr = SQLCmd.ExecuteReader();
            cmbKhoa.Tag = "0";
            cmbKhoa.ClearItems();
            while (dr.Read())
            {
                cmbKhoa.AddItem(string.Format("{0};{1}", dr["MaKhoa"], dr["TenKhoa"]));
            }
            dr.Close();
            cmbKhoa.SelectedIndex = 0;
            txtTNgay.Value = txtDNgay.Value = DateTime.Now;
            cmbKhoa.Tag = "1";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            fgDanhSach.Redraw = false;
            reload();
            LoatData();
            Build_Data();
            fgDanhSach.Redraw = true;
        }
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Build_Data()
        {
            int MaxCol = 50, MaxRow = 10000;
            for (int i = 0; i < MaxCol; i++) fgDanhSach.Cols.Add();
            for (int i = 0; i < MaxRow; i++) fgDanhSach.Rows.Add();
            fgDanhSach.Rows[0][0] = "STT"; //fgDanhSach.Cols[0].Width = 5;
            fgDanhSach.Rows[0][1] = "Họ tên BN"; //fgDanhSach.Cols[1].Width = 100;
            fgDanhSach.Rows[0][2] = "Số HSBA"; //fgDanhSach.Cols[2].Width = 20;
            fgDanhSach.Rows[0][3] = "Ngày ra viện"; //fgDanhSach.Cols[3].Width = 20;
            //for (int i = 0; i < 4; i++)
            //{
            //    fgDanhSach.Cols[i].AllowMerging = true;
            //}
            string tenvt = "";
            int cot = 4, hang = 1;
            for (int i = 0; i < dsKQ.Tables[0].Rows.Count;i++ )
            {
                tenvt = dsKQ.Tables[0].Rows[i]["TenThuoc"].ToString();
                int co = 0;
                for (int j = 4; j < MaxCol; j++)
                {
                    if (fgDanhSach.GetDataDisplay(0, j) == tenvt)
                    {
                        co = 1;
                        break;
                    }
                }
                if (co == 0)
                { 
                    fgDanhSach.Rows[0][cot] = tenvt;
                    cot++;
                }
            }
            for (int j = 4; j < MaxCol; j++)
            {
                if (fgDanhSach.GetDataDisplay(0, j) == "")
                {
                    fgDanhSach.Cols.Count = j;
                    break;
                }
            }
            int stt = 1;
            for (int i = 0; i < dsKQ.Tables[0].Rows.Count; i++)
            {
                tenvt = dsKQ.Tables[0].Rows[i]["SoHSBA"].ToString();
                int co = 0;
                for (int j = 1; j < MaxRow; j++)
                {
                    if (fgDanhSach.GetDataDisplay(j, 2) == tenvt)
                    {
                        co = 1;
                        break;
                    }
                }
                if (co == 0)
                {
                    fgDanhSach.Rows[hang][0] = stt;
                    fgDanhSach.Rows[hang][1] = dsKQ.Tables[0].Rows[i]["HoTen"].ToString();
                    fgDanhSach.Rows[hang][2] = dsKQ.Tables[0].Rows[i]["SoHSBA"].ToString();
                    fgDanhSach.Rows[hang][3] = string.Format("{0:dd/MM/yyyy}",dsKQ.Tables[0].Rows[i]["NgayRaVien"]);
                    hang++;
                    stt++;
                }
            }
            for (int j = 4; j < MaxRow; j++)
            {
                if (fgDanhSach.GetDataDisplay(j, 1) == "")
                {
                    fgDanhSach.Rows.Count = j;
                    break;
                }
            }
            for (int i = 0; i < dsKQ.Tables[0].Rows.Count; i++)
            {
                for (int j = 1; j < fgDanhSach.Rows.Count; j++)
                {
                    string hsba = fgDanhSach.GetDataDisplay(j, 2);
                    for (int k = 4; k < fgDanhSach.Cols.Count; k++)
                    {
                        string tenthuoc = fgDanhSach.GetDataDisplay(0, k);
                        if (dsKQ.Tables[0].Rows[i]["SoHSBA"].ToString() == hsba && dsKQ.Tables[0].Rows[i]["TenThuoc"].ToString() == tenthuoc)
                        {
                            fgDanhSach.Rows[j][k] = dsKQ.Tables[0].Rows[i]["SoLuong"];
                        }
                    }
                }
            }
        }
        //private void btnExcel_Click(object sender, EventArgs e)
        //{
        //    string TenFile;
        //    System.Windows.Forms.SaveFileDialog dg = new SaveFileDialog();
        //    dg.Filter = "Xuất số liệu ra file Excel (*.xls)|*.xls";
        //    dg.FilterIndex = 0;
        //    dg.CheckFileExists = false;
        //    dg.Title = "Nhập tên file để kết xuất số liệu.";
        //    if (dg.ShowDialog() == DialogResult.OK)
        //        TenFile = dg.FileName;
        //    else
        //        return;
        //    if (TenFile.Split(".".ToCharArray()).Length < 2)
        //        TenFile = TenFile + ".xls";
        //    fgDanhSach.SaveExcel(TenFile, "Sheet1", C1.Win.C1FlexGrid.FileFlags.IncludeFixedCells);
        //    MessageBox.Show("Bạn đã lưu thành công file " + TenFile + " !");
        //}
        private void btnExcel_Click(object sender, EventArgs e)
        {
            _book = new C1.C1Excel.C1XLBook();
            string Tenfile = "";
            _book.Clear();
            _book.Sheets.Clear();
            _book = new C1XLBook();
            System.Windows.Forms.SaveFileDialog dg = new SaveFileDialog();
            dg.Filter = "Xuất số liệu ra file Excel (*.xls)|*.xls";
            dg.FilterIndex = 0;
            dg.CheckFileExists = false;
            dg.Title = "Nhập tên file để kết xuất số liệu.";
            if (dg.ShowDialog() == DialogResult.OK)
                Tenfile = dg.FileName;
            else
                return;
            if (Tenfile.Split(".".ToCharArray()).Length < 2)
                Tenfile = Tenfile + ".xls";
            string str = "";
            str = System.Windows.Forms.Application.StartupPath + "\\DSBNSuDungVTTH.xls";
            File.Copy(str, Tenfile, true);
            _book.Load(Tenfile, true);
            XLSheet sheet;
            sheet = _book.Sheets[0];
            sheet[1, 0].Value = String.Format("{0}", cmbKhoa.Text.ToUpper());
            if (rdTT.Checked) sheet[3, 0].Value = String.Format("{0}", "DANH SÁCH NB SỬ DỤNG VTTH ĐƯỢC THANH TOÁN");
            if (rdKhongTT.Checked) sheet[3, 0].Value = String.Format("{0}", "DANH SÁCH NB SỬ DỤNG VTTH KHÔNG ĐƯỢC THANH TOÁN");
            sheet[4, 0].Value = String.Format("Từ ngày {0:dd/MM/yyyy} đến ngày {1:dd/MM/yyyy}", txtTNgay.Value, txtDNgay.Value);
            XLStyle xsSo = new XLStyle(_book);
            XLStyle xsTien = new XLStyle(_book);
            XLStyle xsChu = new XLStyle(_book);
            XLStyle xsConerRight = new XLStyle(_book);
            XLStyle xsConerTop = new XLStyle(_book);
            XLStyle xsBottom = new XLStyle(_book);
            XLStyle xsRight = new XLStyle(_book);
            //số
            xsSo.AlignHorz = XLAlignHorzEnum.Right;
            xsSo.BorderRight = xsSo.BorderLeft = XLLineStyleEnum.Thin;
            xsSo.BorderBottom = XLLineStyleEnum.Dotted;
            xsSo.AlignHorz = XLAlignHorzEnum.Right;
            //xsSo.Format = "#,##,#";
            // tiền
            xsTien.BorderLeft = XLLineStyleEnum.Thin;
            xsTien.BorderLeft = xsTien.BorderRight = XLLineStyleEnum.Thin;
            xsTien.BorderBottom = XLLineStyleEnum.Dotted;
            xsTien.AlignHorz = XLAlignHorzEnum.Right;
            xsTien.Format = "#,##.#";
            // ô góc cùng bên phải
            xsConerRight.BorderTop = xsConerRight.BorderBottom = xsConerRight.BorderRight = XLLineStyleEnum.Thin;
            // ô bên phải
            xsRight.BorderLeft = xsRight.BorderRight = XLLineStyleEnum.Thin;
            // góc trên bên phải
            xsConerTop.BorderTop = xsConerTop.BorderLeft = xsConerTop.BorderBottom = xsConerTop.BorderRight = XLLineStyleEnum.Thin;
            xsConerTop.Rotation = 90;
            // ô dòng cuối
            xsBottom.BorderBottom = XLLineStyleEnum.Thin;
            // chữ
            xsChu.BorderLeft = XLLineStyleEnum.Thin;
            xsChu.BorderRight = XLLineStyleEnum.Thin;
            xsRight.Font = xsChu.Font = xsTien.Font = xsSo.Font = xsChu.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            xsBottom.Font = xsConerTop.Font = xsConerRight.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            xsRight.ForeColor = xsBottom.ForeColor = xsTien.ForeColor = xsConerTop.ForeColor = xsConerRight.ForeColor = xsSo.ForeColor = xsChu.ForeColor = System.Drawing.Color.Black;
            int h = 9;
            XLCellRange _ColRange = new C1.C1Excel.XLCellRange(h-2,h-2,4,fgDanhSach.Cols.Count-1);
            _book.Sheets[0].MergedCells.Add(_ColRange);
            //sheet[h - 2, 4].Style = xsConerRight;
            for (int i = 4; i < fgDanhSach.Cols.Count; i++)
            {
                sheet[h - 2, i].Style = xsConerRight;
                sheet[h - 1, i].Value = fgDanhSach.GetDataDisplay(0, i);
                sheet[h - 1, i].Style = xsConerTop;
                if (i == fgDanhSach.Cols.Count) sheet[h, i].Style = xsConerRight;
                else sheet[h, i].Style = xsBottom;
            }
            for (int i = 1; i < fgDanhSach.Rows.Count; i++)
            {
                sheet.Rows.Insert(h);
                for (int j = 0; j < fgDanhSach.Cols.Count; j++)
                {
                    if (j <= 3) sheet[h, j].Value = fgDanhSach.GetDataDisplay(i, j);
                    else
                    {
                        try
                        {
                            sheet[h, j].Value = double.Parse(fgDanhSach.GetDataDisplay(i, j));
                        }
                        catch { }
                    }
                    if (j == 1 || j == 2 || j == 3) sheet[h, j].Style = xsChu;
                    else if (j == fgDanhSach.Cols.Count) sheet[h, j].Style = xsRight;
                    else sheet[h, j].Style = xsSo;
                }
                h++;
            }
            _book.Save(Tenfile);
            System.Diagnostics.Process.Start(Tenfile);
        }


        private void rdTT_CheckedChanged(object sender, EventArgs e)
        {
            fgDanhSach.Redraw = false;
            reload();
            fgDanhSach.Redraw = true;
        }
        private void reload()
        {
            for (int i = fgDanhSach.Cols.Count - 1; i >= 0; i--)
            {
                fgDanhSach.Cols.Remove(i);
            }
            for (int j = fgDanhSach.Rows.Count - 1; j > 0; j--)
            {
                fgDanhSach.Rows.Remove(j);
            }
            fgDanhSach.Rows.Fixed = 1;
            //fgDanhSach.Styles.Fixed.TextDirection =C1.Win.C1FlexGrid.TextDirectionEnum.Up;
            //fgDanhSach.Rows[0].Height = 50;
        }
    }
}