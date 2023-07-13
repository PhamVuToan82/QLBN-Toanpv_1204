using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace NamDinh_QLBN.Reports
{
    /// <summary>
    /// Summary description for rptPhieuLinh.
    /// </summary>
    public partial class rptPhieuLinhThuocGayNghien_Sua : DataDynamics.ActiveReports.ActiveReport3
    {
        private int STT = 0;
        private int page = 0;
        public string TruongKhoa;
        public string TruongKho;
        public string NguoiLinh;
        public string NguoiPhat;
        public string KhoThuoc;
        public string So;
        public object _NgaySD;
        public rptPhieuLinhThuocGayNghien_Sua(string Khoa, String Ngay, string SoLuuTru,string Nhom)
        {
            //
            // Required for Windows Form Designer support
            //
            //DateTime NgayHT = Global.GlobalModules.GetNgayLV();
            InitializeComponent();
            lblKhoa.Text = "KHOA/PHÒNG: " + Khoa.ToUpper() ;
            txtNgaySD.Text = Ngay;
            lblSo.Text = "Số: " + SoLuuTru;
            label7.Text = Nhom;
            if (Khoa == "Trung tâm Ung bướu")
            {
                label2.Text = "Giám đốc trung tâm";
            }
            //txtNgay1.Text = "Ngày " + Ngay.Day.ToString() + " /" + Ngay.Month.ToString() + " /" + Ngay.Year.ToString();            
        }

        private void rptPhieuLinh_ReportStart(object sender, EventArgs e)
        {
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.PageSettings.Orientation = PageOrientation.Portrait;

            this.PageSettings.Margins.Left = (float)0.80;
            this.PageSettings.Margins.Right = (float)0.50;
            this.PageSettings.Margins.Top = (float)1;
            this.PageSettings.Margins.Bottom = (float)0.50;
            lblTruongKho.Text = TruongKho;
            lblTruongKhoa.Text = TruongKhoa;
            lblNguoiPhat.Text = NguoiPhat;
            lblNguoiLinh.Text = NguoiLinh;
            //txtNgaySD.Text = String.Format("Ngày {0:dd} tháng {0:MM} năm {0:yyyy}", _NgaySD);
            txtNgay1.Text = "In ngày " + GlobalModuls.Global.NgayLV.Day.ToString() + " /" + GlobalModuls.Global.NgayLV.Month.ToString() + " /" + GlobalModuls.Global.NgayLV.Year.ToString();   
            //txtSo.Text = So;            
        }

        private void detail_Format(object sender, EventArgs e)
        {
            STT++;
            textBox3.Text = STT.ToString();
            
        }

        private void detail_BeforePrint(object sender, EventArgs e)
        {
            textBox3.Height = textBox4.Height=textBox6.Height = textBox7.Height = textBox8.Height = textBox10.Height = detail.Height;
        }        

        private void reportFooter1_Format(object sender, EventArgs e)
        {
            label5.Text = "Tổng số: " + STT.ToString() + " khoản";
        }

        private void rptPhieuLinh_PageStart(object sender, EventArgs e)
        {
            page += 1;
            txtPage.Text = "Trang " + page.ToString() ;
        }

        private void groupHeader1_Format(object sender, EventArgs e)
        {

        }

        private void rptPhieuLinhThuocGayNghien_Sua_FetchData(object sender, FetchEventArgs eArgs)
        {
            if (eArgs.EOF)
            {
            }
            else
            {
                if (Fields["Soluong"].Value.ToString() != "0")
                    Fields["SoLuongChu"].Value = GlobalModuls.Global.UpperFirstChar1(GlobalModuls.Global.WriteNum((long)Decimal.Parse(Fields["Soluong"].Value.ToString())));
                else Fields["SoLuongChu"].Value = "Không";
                //if (Fields["TenDichVu"].Value.ToString().ToUpper().Contains("MOCPHIN") || Fields["TenDichVu"].Value.ToString().ToUpper().Contains("DOLCONTRAL") || Fields["TenDichVu"].Value.ToString().ToUpper().Contains("FENTANYL"))
                //{
                //    Fields["SoLuongChu"].Value = GlobalModuls.Global.UpperFirstChar1(GlobalModuls.Global.WriteNum((long)Decimal.Parse(Fields["Soluong"].Value.ToString())));
                //}
                //else
                //{

                    //    Fields["SoLuongChu"].Value = Fields["Soluong"].Value;

                    //}

            }
        }

        private void rptPhieuLinhThuocGayNghien_Sua_DataInitialize(object sender, EventArgs e)
        {
            foreach (DataDynamics.ActiveReports.TextBox _lb in detail.Controls)
            {
                if (!Fields.Contains(Fields[_lb.DataField]))
                    Fields.Add(_lb.DataField);
            }
        }
    }
}
