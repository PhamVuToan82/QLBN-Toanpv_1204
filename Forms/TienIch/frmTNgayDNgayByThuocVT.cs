﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NamDinh_QLBN.Forms.Tien_ich
{
    public partial class  frmTNgayDNgayByThuocVT : Form
    {
        public DateTime _TNgay, _DNgay;
        public string _MaKhoa;
        public string _TenKhoa;
        public bool _isVatTu = false, _isThuoc = false;
        public int _LoaiSo;

        public frmTNgayDNgayByThuocVT()
        {
            InitializeComponent();
        }

        private void cmdThoat_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
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
                    _isThuoc = raThuoc.Checked;
                    _isVatTu = raVatTu.Checked;
                    _MaKhoa = GlobalModuls.Global.GetCode(cmbKhoa);
                    _TenKhoa = cmbKhoa.Text;
                    if (raTatCa.Checked)
                        _LoaiSo = -1;
                    else
                        if (raThuocOng.Checked)
                            _LoaiSo = 0;
                        else _LoaiSo = 1;
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

        private void frmTNgayDNgay_Load(object sender, EventArgs e)
        {
            LoatDanhMuc();
        }
    }
}