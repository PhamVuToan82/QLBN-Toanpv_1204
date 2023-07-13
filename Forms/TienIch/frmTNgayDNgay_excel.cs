using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NamDinh_QLBN.Forms.Tien_ich
{
    public partial class frmTNgayDNgay_excel : Form
    {
        public DateTime _TNgay, _DNgay;
        public string _MaKhoa;
        public string _TenKhoa;

        public frmTNgayDNgay_excel()
        {
            InitializeComponent();
        }

        private void cmdThoat_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void cmbKhongGhi_Click(object sender, EventArgs e)
        {
            if (cmbKhoa.SelectedIndex == -1)
            {
                MessageBox.Show("Chọn khoa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbKhoa.Focus();
                this.DialogResult = DialogResult.Retry;
            }
            else
            {
                if (txtDNgay.ValueIsDbNull == true || txtTNgay.ValueIsDbNull == true)
                {
                    MessageBox.Show("Chọn ngày", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.Retry;
                }
                else
                {
                    _TNgay = (DateTime)txtTNgay.Value;
                    _DNgay = (DateTime)txtDNgay.Value;
                    _MaKhoa = GlobalModuls.Global.GetCode(cmbKhoa);
                    _TenKhoa = cmbKhoa.Text;
                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        private void LoatDanhMuc()
        {
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            try
            {
                SQLCmd.CommandText = "SELECT * FROM DMKHOAPHONG WHERE MaKhoa IN " + GlobalModuls.Global.glbKhoa_CapNhat;
                dr = SQLCmd.ExecuteReader();
                cmbKhoa.Tag = "0";
                cmbKhoa.ClearItems();
                while (dr.Read())
                {
                    cmbKhoa.AddItem(string.Format("{0};{1}", dr["MaKhoa"], dr["TenKhoa"]));
                }
                cmbKhoa.SelectedIndex = 0;
                dr.Close();
                cmbKhoa.Tag = "1";
                txtTNgay.Value = txtDNgay.Value = GlobalModuls.Global.GetNgayLV();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                SQLCmd.Dispose();
            }
        }

        private void Excel_Click(object sender, EventArgs e)
        {
            string TenFile;
            System.Windows.Forms.SaveFileDialog dg = new SaveFileDialog();
            dg.Filter = "Xuất số liệu ra file Excel (*.xls)|*.xls";
            dg.FilterIndex = 0;
            dg.CheckFileExists = false;
            dg.Title = "Nhập tên file để kết xuất số liệu.";
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            SQLCmd.CommandText = string.Format("set dateformat dmy select  a.MaKhambenh as 'MA_LK', a.HoTen as 'HO_TEN', '0101' + convert(nvarchar,a.Namsinh) as NGAY_SINH , a.MaDTThe + a.SotheBHYT as MA_THE, replace(replace(replace(CONVERT ( nchar(16) , a.NgayKham, 120),'-',''),' ',''),':','') as NGAY_VAO, replace(replace(replace(CONVERT ( nchar(16) , a.Ngayra, 120),'-',''),' ',''),':','')   as NGAY_RA,REPLACE(dv.masobyt,'.',',') as MA_DICH_VU, dv.TenXML as TEN_DICH_VU, convert (numeric(18,2),b.Soluong ) as SO_LUONG, cast(b.DongiaBHYT as int)  AS DON_GIA, b.TyLe, b.TyLeBH, convert(numeric(18,0), b.Thanhtien) AS THANH_TIEN,D.TenVoCam as PP_VO_CAM , khoa.MaKhoaBYT AS MA_KHOA,loaipt.TenLoaiPT  as TEN_LOAI_PT,YEAR(a.ThoigianThanhtoan) as NAM_QT,MONTH(a.ThoigianThanhtoan) as THANG_QT,case when a.Gioitinh = 0 then 2 else 1 end as GIOI_TINH,3 as MA_LOAI_KCB, case when a.MaNoiDKKCBBD = '36001' then 1 when a.MaNoiDKKCBBD != '36001' and a.MaNoiDKKCBBD like N'%36%%' then 2 when a.MaNoiDKKCBBD not like N'%36%%' then 3 end as LOAI_BN,a.ICDKhoaDT as MA_BENH, case  a.Tuyen  when 0 then 1 when 1 then 2 when 2 then 3  when 3 then 2 end MA_LYDO_VVIEN,100-PhantramCCT as MUC_HUONG,8 as MA_NHOM, convert(numeric(18,0),b.BHYTChitra) as T_BHTT from NAMDINH_VIENPHI.dbo.tblTHANHTOANBHYT a inner join NAMDINH_VIENPHI.dbo.tblTHANHTOANBHYT_CT b on a.Id = b.ID inner join NAMDINH_QLBN.dbo.BENHNHAN_PHAUTHUAT c on c.MaVaoVien = a.MaKhambenh and c.MaPT = b.MaDichvu and c.SoPhieuCD = b.MaPhieuCD inner join NAMDINH_SYSDB.dbo.DMDICHVU dv on dv.MaDichvu = b.MaDichvu inner join NAMDINH_SYSDB.dbo.DMKHOAPHONG khoa on khoa.MaKhoa = b.Makhoa left join NAMDINH_QLBN.dbo.DMVOCAM d on d.MaVoCam = c.PPVoCam left join NAMDINH_QLBN.dbo.DMPHUONGPHAPPT pppt on pppt.MaPPPT = c.PhuongPhapPT_Ma  left join NAMDINH_QLBN.dbo.DMPHAUTHUAT  pt on pt.MaDichVu = b.MaDichvu left join NAMDINH_QLBN.dbo.DMLOAIPHAUTHUAT loaipt on loaipt.MaLoaiPT = pt.LoaiPhauThuat where a.ThoigianThanhtoan between '{0:dd/MM/yyyy}' and '{1:dd/MM/yyyy}'  and a.Phieuhuy = 0 and b.Ischenh = 0 order by TenVoCam,MaKhoaBYT,HoTen", txtTNgay.Value,txtDNgay.Value);
            dr = SQLCmd.ExecuteReader();
            fgDanhSach.Tag = "0";
            fgDanhSach.Rows.Count = 1;
            fgDanhSach.ClipSeparators = "|;";
            while (dr.Read())
            {
                fgDanhSach.AddItem(string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}|{12}|{13}|{14}|{15}|{16}|{17}|{18}|{19}|{20}|{21}|{22}|{23}|{24}|{25}|{26}", fgDanhSach.Rows.Count,
                    dr["MA_LK"],
                    dr["HO_TEN"],
                    dr["NGAY_SINH"],
                    dr["MA_THE"],
                    dr["NGAY_VAO"],
                    dr["NGAY_RA"],
                    dr["MA_DICH_VU"],
                    dr["TEN_DICH_VU"],
                    dr["SO_LUONG"],
                    dr["DON_GIA"],
                    dr["TyLe"],
                    dr["TyLeBH"],
                    dr["THANH_TIEN"],
                    dr["PP_VO_CAM"],
                    dr["MA_KHOA"],
                    dr["TEN_LOAI_PT"],
                    dr["NAM_QT"],
                    dr["THANG_QT"],
                    dr["GIOI_TINH"], dr["MA_LOAI_KCB"], dr["LOAI_BN"], dr["MA_BENH"], dr["MA_LYDO_VVIEN"], dr["MUC_HUONG"], dr["MA_NHOM"], dr["T_BHTT"]));
            }
            dr.Close();
            fgDanhSach.AutoSizeCols();
            fgDanhSach.Tag = "1";
            SQLCmd.Dispose();
            if (dg.ShowDialog() == DialogResult.OK)
                TenFile = dg.FileName;
            else
                return;
            if (TenFile.Split(".".ToCharArray()).Length < 2)
                TenFile = TenFile + ".xls";
            fgDanhSach.SaveExcel(TenFile, "BaoCao", C1.Win.C1FlexGrid.FileFlags.IncludeFixedCells);
            MessageBox.Show("Bạn đã lưu thành công file " + TenFile + " !");
        }

        private void frmTNgayDNgay_excel_Load(object sender, EventArgs e)
        {
            LoatDanhMuc();
        }
    }
}