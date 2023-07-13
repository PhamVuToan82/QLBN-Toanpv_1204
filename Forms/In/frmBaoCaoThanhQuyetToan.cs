using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GlobalModuls;
using C1.C1Excel;
using System.Data.SqlClient;
namespace NamDinh_QLBN.Forms.In
{
    public partial class frmBaoCaoThanhQuyetToan : Form
    {
        private DateTime _TuNgay, _DenNgay;
        public frmBaoCaoThanhQuyetToan()
        {
            InitializeComponent();
        }
        private void LoatData()
        {
            try
            {
                Global.wait("Đang tổng hợp dữ liệu ...");
                System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
                SQLCmd.CommandType = CommandType.StoredProcedure;
                if (rdBCQT1.Checked) SQLCmd.CommandText = "GetBaoCaoQuyetToanKhoa"; // báo cáo thuốc
                else if (rdBCQT2.Checked) SQLCmd.CommandText = "GetBaoCaoQuyetToanKhoaTheoGT";
                else if (rdBNSDThanhToan.Checked) SQLCmd.CommandText = "GetDSBNSuDungThuocTTRaVien";
                else if (rdTongHopLinhThuoc.Checked) SQLCmd.CommandText = "GetTongHopLinhThuoc";
                SQLCmd.CommandTimeout = 0;
                System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(SQLCmd);
                System.Data.DataSet ds = new DataSet();
                SqlParameter TuNgay = new SqlParameter("@TuNgay", SqlDbType.DateTime);
                TuNgay.Value = _TuNgay;
                SQLCmd.Parameters.Add(TuNgay);
                SqlParameter DenNgay = new SqlParameter("@DenNgay", SqlDbType.DateTime);
                DenNgay.Value = _DenNgay;
                SQLCmd.Parameters.Add(DenNgay);
                SqlParameter PhongKhoa = new SqlParameter("@MaKhoa", SqlDbType.VarChar, 10);
                PhongKhoa.Value = GlobalModuls.Global.GetCode(cmbKhoa);
                SQLCmd.Parameters.Add(PhongKhoa);
                ds.Clear();
                da.Fill(ds);
                SQLCmd.Dispose();
                //if (rdBNSDThanhToan.Checked || rdTongHopLinhThuoc.Checked)
                //{
                //    fgDanhSach.Styles.Fixed.TextDirection = C1.Win.C1FlexGrid.TextDirectionEnum.Up;
                //}
                //else fgDanhSach.Styles.Fixed.TextDirection = C1.Win.C1FlexGrid.TextDirectionEnum.Normal;
                fgDanhSach.DataSource = ds.Tables[0];
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Global.nowait();
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdTongHop_Click(object sender, EventArgs e)
        {
            if (cmbKhoa.SelectedIndex == -1)
            {
                MessageBox.Show("Chưa chọn Khoa điều trị!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cmbKhoa.Focus();
                return;
            }
            _TuNgay = DateTime.Parse(DateTime.Parse(txtTNgay.Value.ToString()).ToShortDateString());
            _DenNgay = DateTime.Parse(DateTime.Parse(txtDNgay.Value.ToString()).ToShortDateString());
            fgDanhSach.Tag = 0;
            LoatData();
            fgDanhSach.Tag = 1;
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            string TenFile;
            System.Windows.Forms.SaveFileDialog dg = new SaveFileDialog();
            dg.Filter = "Xuất số liệu ra file Excel (*.xls)|*.xls";
            dg.FilterIndex = 0;
            dg.CheckFileExists = false;
            dg.Title = "Nhập tên file để kết xuất số liệu.";
            if (dg.ShowDialog() == DialogResult.OK)
                TenFile = dg.FileName;
            else
                return;
            if (TenFile.Split(".".ToCharArray()).Length < 2)
                TenFile = TenFile + ".xls";
            fgDanhSach.SaveExcel(TenFile, "BaoCao", C1.Win.C1FlexGrid.FileFlags.IncludeFixedCells);
            MessageBox.Show("Bạn đã lưu thành công file " + TenFile + " !");
        }

        private void frmBaoCaoThanhQuyetToan_Load(object sender, EventArgs e)
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
            SQLCmd.Dispose();
        }
    }
}