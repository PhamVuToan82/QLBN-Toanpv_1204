using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NamDinh_QLBN.Forms.DuLieu
{
    public partial class frmThongTinKQ : Form
    {
        public String _MaVaoVien;
        public frmThongTinKQ()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void LoatKyQuy()
        {
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            double SoTienKQ = 0, SoTienDSD = 0;
            try
            {
                SQLCmd.CommandText = String.Format("SELECT * FROM ["+ GlobalModuls.Global.glbVienPhi +"].DBO.tblThukyquy Where MaVaoVien='{0}'",_MaVaoVien);
                dr = SQLCmd.ExecuteReader();
                fgKyQuy.Rows.Count = 1;
                while (dr.Read())
                {
                    fgKyQuy.Rows.Add();
                    fgKyQuy[fgKyQuy.Rows.Count - 1, 0] = fgKyQuy.Rows.Count -1;
                    fgKyQuy[fgKyQuy.Rows.Count - 1, 1] = "Lần " + dr["LanKQ"].ToString();
                    fgKyQuy[fgKyQuy.Rows.Count - 1, 2] = String.Format("{0:dd/MM/yyyy}", dr["NgayKQ"]);
                    fgKyQuy[fgKyQuy.Rows.Count - 1, 3] = dr["SoBLKQ"];
                    fgKyQuy[fgKyQuy.Rows.Count - 1, 4] = dr["SoTien"];
                    SoTienKQ += Double.Parse(dr["SoTien"].ToString());
                }
                dr.Close();
                fgKyQuy.AutoSizeCols(2);
                lbTongKQ.Text = String.Format("Tổng số tiền: {0:#,##0}",SoTienKQ) + " VNĐ";

                SQLCmd.CommandText = String.Format("SELECT * FROM "
                    + " (SELECT LOAIDICHVU,SUM(isnull(SOLUONG,0)) AS SOLUONG,SUM(isnull(DONGIA,0) * isnull(SOLUONG,0)) AS THANHTIEN FROM"
                    + " (SELECT SOPHIEU FROM BENHNHAN_PHIEUDIEUTRI WHERE MAVAOVIEN='{0}') AA"
                    + " INNER JOIN PHIEUDIEUTRI_CHITIET CT ON CT.SOPHIEU = AA.SOPHIEU"
                    + " GROUP BY LOAIDICHVU) BB"
                    + " INNER JOIN DMLOAIDICHVU DM ON DM.MALOAIDICHVU = BB.LOAIDICHVU", _MaVaoVien);
                dr = SQLCmd.ExecuteReader();
                fgDaSuDung.Rows.Count = 1;
                while (dr.Read())
                {
                    fgDaSuDung.Rows.Add();
                    fgDaSuDung[fgDaSuDung.Rows.Count - 1, 0] = fgDaSuDung.Rows.Count - 1;
                    fgDaSuDung[fgDaSuDung.Rows.Count - 1, 1] = dr["TenLoaiDichVu"];
                    fgDaSuDung[fgDaSuDung.Rows.Count - 1, 2] = dr["SoLuong"];
                    fgDaSuDung[fgDaSuDung.Rows.Count - 1, 3] = dr["ThanhTien"];
                    SoTienDSD += double.Parse(dr["ThanhTien"].ToString());
                }
                lbTongDSD.Text = string.Format("Tổng số tiền đã sử dụng: {0:#,##0}",SoTienDSD) + " VNĐ";
                lbConLai.Text = "Số tiền còn lại: " + String.Format("{0:#,##0}", SoTienKQ - SoTienDSD) + " VNĐ";
                dr.Close();
            }
            catch
            {
            }
            finally
            {
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmThongTinKQ_Load(object sender, EventArgs e)
        {
            fgKyQuy.Tag = 0;
            fgDaSuDung.Tag = 0;
            LoatKyQuy();
        }
    }
}