using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GlobalModuls;

namespace NamDinh_QLBN.Forms.DuLieu
{
    public partial class frmCanLanSang : Form
    {
        public frmCanLanSang()
        {
            InitializeComponent();
        }

        private void LoatDM()
        {
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            try
            {
                SQLCmd.CommandText = "SELECT * FROM DMKHOAPHONG WHERE MaKhoa IN " + Global.glbKhoa_CapNhat;
                dr = SQLCmd.ExecuteReader();
                cmbKhoa.Tag = "0";
                cmbKhoa.ClearItems();
                while (dr.Read())
                {
                    cmbKhoa.AddItem(string.Format("{0};{1}", dr["MaKhoa"], dr["TenKhoa"]));
                }
                cmbKhoa.SelectedIndex = 0;
                dr.Close();
            }
            catch
            {
            }
            finally
            {
                SQLCmd.Dispose();
            }
        }

        private void LoatData()
        {
            C1.Win.C1FlexGrid.CellStyle cs = fgPhieuChiDinh.Styles[C1.Win.C1FlexGrid.CellStyleEnum.Subtotal0];
            cs.BackColor = Color.LightBlue;
            cs.ForeColor = Color.DarkBlue;
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            try
            {
                fgPhieuChiDinh.Redraw = false;
                fgPhieuChiDinh.Tree.Column = fgPhieuChiDinh.Cols["TenDichVu"].Index;
                SQLCmd.CommandText = String.Format("Select dmloaidichvu.maloaidichvu,dmloaidichvu.tenloaidichvu,dmdichvu.madichvu,dmdichvu.tendichvu,dmdichvu.dvt,isnull(thutuchon,100) as thutuchon,isnull(nhomphieu,100) as nhomphieu from dmloaidichvu"
                    + " inner join dmdichvu on dmdichvu.loaidichvu = dmloaidichvu.maloaidichvu"
                    + " left join tblThietLapDichVu on tblThietLapDichVu.madichvu = dmdichvu.madichvu"
                    + " and tblThietLapDichVu.makhoa ='{0}' "
                    + " inner join KHOA_LOAIDICHVU on KHOA_LOAIDICHVU.makhoa='{0}' and KHOA_LOAIDICHVU.loaidichvu = dmloaidichvu.maloaidichvu order by tenloaidichvu", GlobalModuls.Global.GetCode(cmbKhoa));
                dr = SQLCmd.ExecuteReader();
                fgPhieuChiDinh.Rows.Count = 1;
                while (dr.Read())
                {
                    fgPhieuChiDinh.Rows.Add();
                    fgPhieuChiDinh[fgPhieuChiDinh.Rows.Count - 1, "MaLoaiDichVu"] = dr["MaLoaiDichVu"];
                    fgPhieuChiDinh[fgPhieuChiDinh.Rows.Count - 1, "TenLoaiDichVu"] = dr["TenLoaiDichVu"];
                    fgPhieuChiDinh[fgPhieuChiDinh.Rows.Count - 1, "MaDichVu"] = dr["MaDichVu"];
                    fgPhieuChiDinh[fgPhieuChiDinh.Rows.Count - 1, "TenDichVu"] = dr["TenDichVu"];
                    fgPhieuChiDinh[fgPhieuChiDinh.Rows.Count - 1, "DVT"] = dr["DVT"];
                    fgPhieuChiDinh[fgPhieuChiDinh.Rows.Count - 1, "ThuTuChon"] = dr["ThuTuChon"];
                    fgPhieuChiDinh[fgPhieuChiDinh.Rows.Count - 1, "NhomPhieu"] = dr["NhomPhieu"];
                }
                dr.Close();
                fgPhieuChiDinh.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.Clear, 0, 0, 0);
                fgPhieuChiDinh.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.None, 0, 2, 0, "{0}");
                fgPhieuChiDinh.AutoSizeCols(0);
                for (int i = 1; i < fgPhieuChiDinh.Rows.Count; i++)
                {
                    fgPhieuChiDinh.Rows[i].Node.Collapsed = true;
                }
            }
            catch
            {
            }
            finally
            {
                fgPhieuChiDinh.Redraw = true;
                SQLCmd.Dispose();
            }
        }

        private void cmdThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCanLanSang_Load(object sender, EventArgs e)
        {
            fgPhieuChiDinh.Tag = 0;
            LoatDM();
            LoatData();
            fgPhieuChiDinh.Tag = 1;
        }

        private void cmdGhi_Click(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            System.Data.SqlClient.SqlTransaction tra;
            tra = Global.ConnectSQL.BeginTransaction();
            SQLCmd.Transaction = tra;
            try
            {
                Global.wait("Đang tổng hợp dữ liệu ...");
                for (int i = 1; i < fgPhieuChiDinh.Rows.Count; i++)
                {
                    if(fgPhieuChiDinh.Rows[i].IsNode) continue;
                    if (fgPhieuChiDinh.Rows[i].UserData == null) continue;
                    SQLCmd.CommandText += String.Format(" if(exists(Select * from tblThietLapDichVu where makhoa='{0}' and madichvu='{1}'))"
                        + " update tblThietLapDichVu set thutuchon= {2},nhomphieu={3} where makhoa='{0}' and madichvu='{1}'"
                        + " else"
                        + " insert into tblthietlapdichvu(makhoa,madichvu,thutuchon,nhomphieu)"
                        + " values('{0}','{1}',{2},{3})", Global.GetCode(cmbKhoa),
                        fgPhieuChiDinh.GetDataDisplay(i, "MaDichVu"),
                        fgPhieuChiDinh.GetDataDisplay(i, "ThuTuChon"),
                        fgPhieuChiDinh.GetDataDisplay(i, "nhomphieu"));
                }
                SQLCmd.ExecuteNonQuery();
                tra.Commit();
                fgPhieuChiDinh.Tag = 0;
                LoatData();
                fgPhieuChiDinh.Tag = 1;
            }
            catch
            {
                tra.Rollback();
            }
            finally
            {
                Global.nowait();
                SQLCmd.Dispose();
            }
        }

        private void fgPhieuChiDinh_AfterEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            fgPhieuChiDinh.Rows[e.Row].UserData = 1;
        }

        private void cmdHuy_Click(object sender, EventArgs e)
        {
            fgPhieuChiDinh.Tag = 0;
            LoatDM();
            LoatData();
            fgPhieuChiDinh.Tag = 1;
        }
    }
}