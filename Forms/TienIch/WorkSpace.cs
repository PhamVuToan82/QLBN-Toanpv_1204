using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GlobalModuls;

namespace NamDinh_QLBN.Forms.Tien_ich
{
    public partial class WorkSpace : Form
    {
        public WorkSpace(Form pForm)
        {
            this.MdiParent = pForm;
            InitializeComponent();
            
        }

        private void WorkSpace_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            fgThongBao.ClipSeparators = "|;";
            Lich.SetDate(Global.NgayLV);
            LayNgayGio();
            fgThongBao.Rows.Count = 1;
            //fgThongBao.AddItem("24/09/2013|Trịnh Tiến Lương - Viện CNTT |Phần mềm có vấn đề gì xin gọi theo số: 098 883 9935");
        }
        private void LayNgayGio()
        {
            lblNgay.Text = string.Format("{0:dd - MM - yyyy}", DateTime.Now);
            lblGio.Text = string.Format("{0:hh:mm}", DateTime.Now);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            LayNgayGio();
        }

        //private void Load_DuLieu(Object Ngay)
        //{
        //    lblLichCongTac.Text = string.Format("Lịch công tác - Ngày: {0:dd/MM/yyyy}", Lich.SelectionRange.End.Date);
        //    lblThongBao.Text = string.Format("Thông báo - Ngày: {0:dd/MM/yyyy}", Lich.SelectionRange.End.Date);

        //    System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand("", Global.ConnectSQL);
        //    System.Data.SqlClient.SqlDataReader dr;
        //    SQLCmd.CommandText = string.Format("SELECT * FROM [NAMDINH_SYSDB].DBO.LICHCONGTAC WHERE (DATEDIFF(day, TuGio, '{0:MM/dd/yyyy}')>=0) AND (DATEDIFF(day, DenGio, '{0:MM/dd/yyyy}')<=0)", Ngay);
        //    fgLichCongtac.Cols[0].AllowMerging = true;//AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Free 
        //    try
        //    {
        //        fgLichCongtac.Redraw = false;
        //        fgThongBao.Redraw = false;
        //        dr = SQLCmd.ExecuteReader();
        //        fgLichCongtac.Rows.Count = 1;
        //        while (dr.Read())
        //        {
        //            fgLichCongtac.AddItem(string.Format("{0:dd/MM/yyyy HH:mm}|{1:dd/MM/yyyy HH:mm}|{2}|{3}|{4}", dr["TuGio"], dr["DenGio"], dr["NoiDung"], dr["DiaDiem"], dr["HoTen"]));
        //        }
        //        dr.Close();
        //        fgLichCongtac.AutoSizeCols(0, fgLichCongtac.Cols.Count - 1, 1);
        //        SQLCmd.CommandText = string.Format("SELECT * FROM [NAMDINH_SYSDB].DBO.THONGBAO WHERE DATEDIFF(day,GioGui, '{0:MM/dd/yyyy}')=0 AND (NguoiNhan Is Null OR NguoiNhan='{1}')", Ngay, Global.glbUName);
        //        dr = SQLCmd.ExecuteReader();
        //        fgThongBao.Rows.Count = 1;
        //        while (dr.Read())
        //        {
        //            fgThongBao.AddItem(string.Format("{0:dd/MM/yyyy HH:mm}|{1}|{2}|{3}", dr["GioGui"], dr["NguoiGui"], dr["NoiDung"], dr["SmsID"]));
        //        }
        //        dr.Close();
        //        int cuchuoi = 15 - fgThongBao.Rows.Count;
        //        for (int i = 0; i < cuchuoi; i++)
        //        {
        //            fgThongBao.AddItem("");
        //        }
        //        fgThongBao.AutoSizeCols(0, fgLichCongtac.Cols.Count - 1, 1);
        //        fgLichCongtac.Redraw = true;
        //        fgThongBao.Redraw = true;
        //    }
        //    catch
        //    {
        //    }
        //    finally
        //    {
        //        SQLCmd.Dispose();
        //    }
        //}

        private void WorkSpace_Resize(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        
    }
}