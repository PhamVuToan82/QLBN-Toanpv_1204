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
    public partial class frmBaoCaoVatTu : Form
    {
        public C1.C1Excel.C1XLBook _book;
        public DataSet dsKQ;
        DateTime NgayChotGanNhat, NgayChotTiepTheo;
        public frmBaoCaoVatTu()
        {
            InitializeComponent();
        }

        private void LoatData()
        {
            try
            {
                System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
                SQLCmd.CommandType = CommandType.StoredProcedure;
                if (rdBCQuyetToan.Checked) SQLCmd.CommandText = "GetBaoCaoTHSuDungVTTH";
                else SQLCmd.CommandText = "GetBaoCaoTHSuDungVTTH_Kho";
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
            SQLCmd.CommandText = "select distinct ngaychot from vetvattu where MaKhoa IN " + Global.glbKhoa_CapNhat+" order by NgayChot desc";
            dr = SQLCmd.ExecuteReader();
            cmbDSNgayChot.ClearItems();
            while (dr.Read())
            {
                cmbDSNgayChot.AddItem(string.Format("{0:dd/MM/yyyy}", dr["NgayChot"]));
            }
            dr.Close();
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
            for (int i = 0; i < 15; i++) fgDanhSach.Cols.Add();
            fgDanhSach.Rows[0][0] = "STT";
            fgDanhSach.Rows[0][1]="Tên thuốc";
            fgDanhSach.Rows[0][2] = "Đơn vị tính";
            fgDanhSach.Rows[0][3] = "Đơn giá";
            for (int i = 0; i < 15; i++)
            {
                fgDanhSach.Cols[i].AllowMerging = true;
            }
            for (int i = 0; i < 4; i++)
            {
                fgDanhSach.Rows[2][i] = fgDanhSach.Rows[1][i] = fgDanhSach.Rows[0][i];
            }
            fgDanhSach.Rows[0].AllowMerging = true;
            fgDanhSach.Rows[0][5] = fgDanhSach.Rows[0][4]="Tồn đầu kỳ";
            fgDanhSach.Rows[2][5] = fgDanhSach.Rows[1][5] = "T.Tiền";
            fgDanhSach.Rows[2][4] = fgDanhSach.Rows[1][4] = "SL";
            fgDanhSach.Rows[0][7] = fgDanhSach.Rows[0][6]="Nhập trong kỳ";
            fgDanhSach.Rows[2][7] = fgDanhSach.Rows[1][7] = "T.Tiền";
            fgDanhSach.Rows[2][6] = fgDanhSach.Rows[1][6] = "SL";
            if (rdBCQuyetToan.Checked)
            {
            fgDanhSach.Rows[0][12] = fgDanhSach.Rows[0][11] = fgDanhSach.Rows[0][10] = fgDanhSach.Rows[0][9] = fgDanhSach.Rows[0][8]="Thanh toán trong kỳ";
            }
            else 
            {
                fgDanhSach.Rows[0][12] = fgDanhSach.Rows[0][11] = fgDanhSach.Rows[0][10] = fgDanhSach.Rows[0][9] = fgDanhSach.Rows[0][8]="Chỉ định trong kỳ";
            }
            fgDanhSach.Rows[1][11] = fgDanhSach.Rows[1][10] = fgDanhSach.Rows[1][9] = fgDanhSach.Rows[1][8]="SL";
            fgDanhSach.Rows[2][12] = fgDanhSach.Rows[1][12] = "T.Tiền";
            fgDanhSach.Rows[1].AllowMerging = true;
            fgDanhSach.Rows[2][8] = "Được TT";
            fgDanhSach.Rows[2][9] = "Không được TT";
            fgDanhSach.Rows[2][10] = "Dùng chung";
            fgDanhSach.Rows[2][11] = "Tổng";
            fgDanhSach.Rows[0][14] = fgDanhSach.Rows[0][13]="Tồn cuối kỳ";
            fgDanhSach.Rows[2][14] = fgDanhSach.Rows[1][14] = "T.Tiền";
            fgDanhSach.Rows[2][13] = fgDanhSach.Rows[1][13] = "SL";
            if (dsKQ == null || dsKQ.Tables.Count==0) return;
            for (int i = 0; i < dsKQ.Tables[0].Rows.Count; i++)
            {
                fgDanhSach.Rows.Add();
                fgDanhSach.Rows[i + 3][0] = dsKQ.Tables[0].Rows[i]["STT"].ToString();
                fgDanhSach.Rows[i + 3][1] = dsKQ.Tables[0].Rows[i]["TenThuoc"].ToString();
                fgDanhSach.Rows[i + 3][2] = dsKQ.Tables[0].Rows[i]["DonViTinh"].ToString();
                fgDanhSach.Rows[i + 3][3] = string.Format("{0:#,##}", dsKQ.Tables[0].Rows[i]["DonGia"]);
                fgDanhSach.Rows[i + 3][4] = string.Format("{0:#,##}", dsKQ.Tables[0].Rows[i]["SLTon"]);
                fgDanhSach.Rows[i + 3][5] = string.Format("{0:#,##}", dsKQ.Tables[0].Rows[i]["GTTon"]);
                fgDanhSach.Rows[i + 3][6] = string.Format("{0:#,##}", dsKQ.Tables[0].Rows[i]["SLNhap"]);
                fgDanhSach.Rows[i + 3][7] = string.Format("{0:#,##}", dsKQ.Tables[0].Rows[i]["GTNhap"]);
                fgDanhSach.Rows[i + 3][8] = string.Format("{0:#,##}", dsKQ.Tables[0].Rows[i]["SLDuocTT"]);
                fgDanhSach.Rows[i + 3][9] = string.Format("{0:#,##}", dsKQ.Tables[0].Rows[i]["SLKhongTT"]);
                fgDanhSach.Rows[i + 3][10] = string.Format("{0:#,##}", dsKQ.Tables[0].Rows[i]["SLDungChung"]);
                fgDanhSach.Rows[i + 3][11] = string.Format("{0:#,##}", dsKQ.Tables[0].Rows[i]["TongSD"]);
                fgDanhSach.Rows[i + 3][12] = string.Format("{0:#,##}", dsKQ.Tables[0].Rows[i]["GTSD"]);
                fgDanhSach.Rows[i + 3][13] = string.Format("{0:#,##}", dsKQ.Tables[0].Rows[i]["SLTonCuoi"]);
                fgDanhSach.Rows[i + 3][14] = string.Format("{0:#,##}", dsKQ.Tables[0].Rows[i]["GTTonCuoi"]);
            }
            for (int i = 0; i < 15; i++)
            {
                fgDanhSach.Cols[i].TextAlignFixed = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
                if (i >= 4) fgDanhSach.Cols[i].Format = "#,##.#";
            }
        }

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
            if (rdBCQuyetToan.Checked) str = System.Windows.Forms.Application.StartupPath + "\\TongHopSuDungVTTH.xls";
            else str = System.Windows.Forms.Application.StartupPath + "\\TongHopSuDungVTTH_Kho.xls";
            File.Copy(str, Tenfile, true);
            _book.Load(Tenfile, true);
            XLSheet sheet;
            sheet = _book.Sheets[0];
            sheet[1, 0].Value = String.Format("{0}", cmbKhoa.Text.ToUpper());
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
            xsSo.Format = "#,##,#";
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
            for (int i = 3; i < fgDanhSach.Rows.Count; i++)
            {
                sheet.Rows.Insert(h);
                for (int j = 0; j < fgDanhSach.Cols.Count; j++)
                {
                    if (j <= 2) sheet[h, j].Value = fgDanhSach.GetDataDisplay(i, j);
                    else
                    {
                        try
                        {
                            sheet[h, j].Value = double.Parse(fgDanhSach.GetDataDisplay(i, j));
                        }
                        catch { }
                    }
                    if (j == 1 || j == 2) sheet[h, j].Style = xsChu;
                    else if (j == fgDanhSach.Cols.Count) sheet[h, j].Style = xsConerRight;
                    else sheet[h, j].Style = xsSo;
                }
                h++;
            }
            _book.Save(Tenfile);
            System.Diagnostics.Process.Start(Tenfile);
        }

        private void txtTNgay_Validated(object sender, EventArgs e)
        {
            if (cmbKhoa.Tag == "1")
            {
                GetNgayChotGanNhat(DateTime.Parse(DateTime.Parse(txtTNgay.Value.ToString()).ToShortDateString()));
                txtTNgay.Value = NgayChotGanNhat;
                txtDNgay.Value = NgayChotTiepTheo;
            } 
        }

        private void txtDNgay_Validated(object sender, EventArgs e)
        {
            //if (rdTongHop.Checked && cmbKhoa.Tag == "1")
            //{
            //    GetNgayChotGanNhat(DateTime.Parse(DateTime.Parse(txtDNgay.Value.ToString()).ToShortDateString()));
            //    txtDNgay.Value = NgayChotGanNhat;
            //}
        }
        private void GetNgayChotGanNhat(DateTime _Ngay)
        {
            if (cmbKhoa.Tag != "1")
            {
                return;
            }
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
            SQLCmd.CommandType = CommandType.StoredProcedure;
            SQLCmd.CommandText = "GetNgayChotDauKy";
            SQLCmd.CommandTimeout = 0;
            SqlParameter Ngay = new SqlParameter("@Ngay", SqlDbType.DateTime);
            Ngay.Value = _Ngay; 
            SQLCmd.Parameters.Add(Ngay);
            SqlParameter PhongKhoa = new SqlParameter("@MaKhoa", SqlDbType.VarChar, 10);
            PhongKhoa.Value = GlobalModuls.Global.GetCode(cmbKhoa);
            SQLCmd.Parameters.Add(PhongKhoa);
            SqlParameter Ngay1 = new SqlParameter("@NgayChotGanNhat", SqlDbType.DateTime);
            Ngay1.Direction = ParameterDirection.Output;
            SQLCmd.Parameters.Add(Ngay1);
            SqlParameter Ngay2 = new SqlParameter("@NgayChotTiepTheo", SqlDbType.DateTime);
            Ngay2.Direction = ParameterDirection.Output;
            SQLCmd.Parameters.Add(Ngay2);
            try
            {
                SQLCmd.ExecuteNonQuery();
                NgayChotGanNhat = DateTime.Parse(Ngay1.Value.ToString());
                NgayChotTiepTheo = DateTime.Parse(Ngay2.Value.ToString());
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                SQLCmd.Dispose();
            }
        }

        private void rdTongHop_CheckedChanged(object sender, EventArgs e)
        {
            fgDanhSach.Redraw = false;
            reload();
            fgDanhSach.Redraw = true;
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
            for (int j = fgDanhSach.Rows.Count - 1; j > 2; j--)
            {
                fgDanhSach.Rows.Remove(j);
            }
            fgDanhSach.Rows.Fixed = 3;
        }
    }
}