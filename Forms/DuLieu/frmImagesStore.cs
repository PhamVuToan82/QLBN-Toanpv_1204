using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Drawing.Imaging;
using System.Reflection;
using GlobalModuls;
using NamDinh_QLBN;
namespace NamDinh_QLBN.Forms.DuLieu
{
    public partial class frmImagesStore : Form
    {
        private string _s;
        private int rowIndex = 0;
        public int chuyenvien = 0;
        public bool phongkham = false;
        public frmImagesStore()
        {
            InitializeComponent();
            // C#
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            // Display the date as "Mon 26 Feb 2001".
            dateTimePicker1.CustomFormat = " dd/MM/yyyy HH:mm:ss";
            tungay.Format = DateTimePickerFormat.Custom;
            // Display the date as "Mon 26 Feb 2001".
            tungay.CustomFormat = " dd/MM/yyyy HH:mm:ss";
            denngay.Format = DateTimePickerFormat.Custom;
            // Display the date as "Mon 26 Feb 2001".
            denngay.CustomFormat = " dd/MM/yyyy HH:mm:ss";
            button5.Visible = false;

        }
        public frmImagesStore(string s) : this()
        {
            _s = s;

            lblkhoa.Text = _s;
            if (lblkhoa.Text.ToUpper() == "KHOACC")
            {
                btn_new.Visible = true;
                button7.Visible = true;
            }
        }
        ketnoi kn = new ketnoi();
        string stringcon = "Data Source=172.16.2.3;Initial Catalog=ImagesDB_Data;User ID=Admin_HIS;Password=vcntt@2020";
        //Get table rows from sql server to be displayed in Datagrid.
        void GetImagesFromDatabase()
        {
            try
            {
                //Initialize SQL Server connection.
                SqlConnection CN = new SqlConnection(txtConnectionString.Text);

                //Initialize SQL adapter.
                SqlDataAdapter ADAP = new SqlDataAdapter("Select * from ImagesStore", CN);

                //Initialize Dataset.
                DataSet DS = new DataSet();

                //Fill dataset with ImagesStore table.
                ADAP.Fill(DS, "ImagesStore");

                //Fill Grid with dataset.
                dataGridView1.DataSource = DS.Tables["ImagesStore"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        //When user changes row selection, display image of selected row in picture box.
        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    //Get image data from gridview column.
            //    byte[] imageData = (byte[])dataGridView1.Rows[e.RowIndex].Cells["ImageData"].Value;

            //    //Initialize image variable
            //    Image newImage;
            //    //Read image data into a memory stream
            //    using (MemoryStream ms = new MemoryStream(imageData, 0, imageData.Length))
            //    {
            //        ms.Write(imageData, 0, imageData.Length);

            //        //Set image variable value using memory stream.
            //        newImage = Image.FromStream(ms, true);
            //    }

            //    //set picture
            //    pictureBox1.Image = newImage;
            //    dataGridView1.DataSource = kn.Spd_select_benhnhan(TxtMavaovien.Text);
            //}
            //catch(Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}
        }

        private void frmImagesStore_Load(object sender, EventArgs e)
        {
            dataGridView2.DataSource = kn.danhsach_benhnhan(lblkhoa.Text);
            radioButton1.Checked = true;
            // dataGridView2.DataSource = kn.danhsach_benhnhan(lblkhoa.Text.Trim());
            //dataGridView1.DataSource = kn.Spd_select_benhnhan(TxtMavaovien.Text);
            button5.Visible = false;

            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            cmbKhoa.ClearItems();
            SQLCmd.CommandText = "select * from NAMDINH_SYSDB.DBO.DMKHOAPHONG WHERE is_Phongkham = 1 ";
            dr = SQLCmd.ExecuteReader();
            cmbKhoa.Tag = "0";
            cmbKhoa.ClearItems();
            while (dr.Read())
            {
                cmbKhoa.AddItem(string.Format("{0}|{1}", dr["TenKhoa"], dr["MaKhoa"]));
            }
            dr.Close();
            cmbKhoa.SelectedIndex = 0;
            cmbKhoa.Tag = "1";

            //       dataGridView2.DataSource = kn.danhsach_benhnhan(lblkhoa.Text);
            for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
            {
                // int val = Int32.Parse(dataGridView2.Rows[i].Cells[14].Value.ToString());
                if (dataGridView2.Rows[i].Cells["ngaygiaoban"].Value.ToString() != "")
                {
                    dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.Red;

                }
            }
        }

        private void dataGridView2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

            dgv_hoasinh.Visible = false;
            dataGridView3.Visible = false;
            TxtMavaovien.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            TxtHoten.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            TxtNamsinh.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            TxtGioitinh.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            TxtDiachi.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
            txtcdsaumo.Text = dataGridView2.CurrentRow.Cells[6].Value.ToString();
            txtbacsypt.Text = dataGridView2.CurrentRow.Cells[8].Value.ToString();
            Txtngayphauthuat.Text = dataGridView2.CurrentRow.Cells[5].Value.ToString();
            txtxutri.Text = dataGridView2.CurrentRow.Cells[7].Value.ToString();
            TxtChanDoan.Text = dataGridView2.CurrentRow.Cells[9].Value.ToString();
            TxtNgayVaoVien.Text = dataGridView2.CurrentRow.Cells[10].Value.ToString();
            txttenkhoa.Text = dataGridView2.CurrentRow.Cells[11].Value.ToString();
            txtthongtinhc.Text = dataGridView2.CurrentRow.Cells[12].Value.ToString();
            txtgiaobanngay.Text = dataGridView2.CurrentRow.Cells[13].Value.ToString();
            //txtngaygiaoban.Visible = true;
            txtthongtinhc.Visible = false;
            dataGridView1.DataSource = kn.Spd_select_benhnhan(TxtMavaovien.Text);

            //}
            //}

        }

        private void cmdBrowse_Click(object sender, EventArgs e)
        {
            txtthongtinhc.Visible = false;
            btn_new.Enabled = false;
            cmdSave.Enabled = false;
            button1.Enabled = true;
            Btnthongtinh_khac.Enabled = false;
            cmdBrowse.Enabled = false;

            //Ask user to select file.
            OpenFileDialog dlg = new OpenFileDialog();
            DialogResult dlgRes = dlg.ShowDialog();
            if (dlgRes != DialogResult.Cancel)
            {
                //Set image in picture box
                pictureBox1.ImageLocation = dlg.FileName;

                //Provide file path in txtImagePath text box.
                txtImagePath.Text = dlg.FileName;
            }
            else
            {
                txtthongtinhc.Visible = true;
                btn_new.Enabled = true;
                cmdSave.Enabled = true;
                button1.Enabled = true;
                Btnthongtinh_khac.Enabled = true;
                cmdBrowse.Enabled = true;
            }
            //dataGridView1.DataSource = kn.img_benhnhan(TxtMavaovien.Text);
            //   SaveJpg(pictureBox1.Image, txtImagePath.Text, 30);
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (TxtMavaovien.Text == "")
            {
                MessageBox.Show("Chưa chọn bệnh nhân trong danh sách");
                return;
            }
            try
            {
                btn_new.Enabled = true;
                button1.Enabled = false;
                cmdBrowse.Enabled = true;
                cmdSave.Enabled = true;
                SqlConnection CN_1 = new SqlConnection(stringcon);
                string qry_1 = " Begin if NOT EXISTS (select makhambenh from benhnhan_xetnghiem where makhambenh = '" + TxtMavaovien.Text + "') BEGIN  insert into benhnhan_xetnghiem (makhambenh,tenbenhnhan,namsinh,ngaygiaoban,tenchiso,tenchiso_ct,ketqua,gioitinh,chandoantruoc,chandoansau,diachi,ngayvaovien,ngayphauthuat,xutri,bacsy,tenkhoa,thongtinhc,uname,chuyenvien) values(@makhambenh,@tenbenhnhan, @namsinh,@ngaygiaoban,'1','1','1',@gioitinh,@chandoantruoc,@chandoansau,@diachi,@ngayvaovien,@ngayphauthuat,@xutri,@bacsy,@tenkhoa,@thongtinhc,@uname,@ChuyenVien) end ";
                if(radioButton3.Checked)
                {
                    qry_1 +=  " else Begin Update benhnhan_xetnghiem set [tenbenhnhan] = @tenbenhnhan  , [namsinh] = @namsinh, [ngaygiaoban] = @ngaygiaoban, [gioitinh] = @gioitinh, [chandoantruoc] = @chandoantruoc, [chandoansau] = @chandoansau, [diachi] = @diachi, [ngayvaovien] = @ngayvaovien, [ngayphauthuat] = @ngayphauthuat, [xutri] =@xutri, [bacsy]= @bacsy, [tenkhoa] = @tenkhoa, [thongtinhc]= @thongtinhc, [uname]= @uname where makhambenh = '" + TxtMavaovien.Text + "' end end";
                }
                else
                {
                    qry_1 +=  " else Begin Update benhnhan_xetnghiem set [tenbenhnhan] = @tenbenhnhan  , [namsinh] = @namsinh, [ngaygiaoban] = @ngaygiaoban, [gioitinh] = @gioitinh, [chandoantruoc] = @chandoantruoc, [chandoansau] = @chandoansau, [diachi] = @diachi, [ngayvaovien] = @ngayvaovien, [ngayphauthuat] = @ngayphauthuat, [xutri] =@xutri, [bacsy]= @bacsy, [tenkhoa] = @tenkhoa, [thongtinhc]= @thongtinhc, [uname]= @uname, [chuyenvien] = @chuyenvien where makhambenh = '" + TxtMavaovien.Text + "' end end";
                }
                SqlCommand SqlCom_1 = new SqlCommand(qry_1, CN_1);
                SqlCom_1.Parameters.Add(new SqlParameter("@makhambenh", (object)TxtMavaovien.Text));
                SqlCom_1.Parameters.Add(new SqlParameter("@tenbenhnhan", (object)TxtHoten.Text));
                SqlCom_1.Parameters.Add(new SqlParameter("@namsinh", (object)TxtNamsinh.Text));
                SqlCom_1.Parameters.Add(new SqlParameter("@ngaygiaoban", (object)dateTimePicker1.Text));
                SqlCom_1.Parameters.Add(new SqlParameter("@gioitinh", (object)TxtGioitinh.Text));
                SqlCom_1.Parameters.Add(new SqlParameter("@chandoantruoc", (object)TxtChanDoan.Text));
                SqlCom_1.Parameters.Add(new SqlParameter("@chandoansau", (object)txtcdsaumo.Text));
                SqlCom_1.Parameters.Add(new SqlParameter("@diachi", (object)TxtDiachi.Text));
                SqlCom_1.Parameters.Add(new SqlParameter("@ngayvaovien", (object)TxtNgayVaoVien.Text));
                SqlCom_1.Parameters.Add(new SqlParameter("@ngayphauthuat", (object)Txtngayphauthuat.Text));
                SqlCom_1.Parameters.Add(new SqlParameter("@xutri", (object)txtxutri.Text));
                SqlCom_1.Parameters.Add(new SqlParameter("@bacsy", (object)txtbacsypt.Text));
                SqlCom_1.Parameters.Add(new SqlParameter("@tenkhoa", (object)txttenkhoa.Text));
                SqlCom_1.Parameters.Add(new SqlParameter("@thongtinhc", (object)txtthongtinhc.Text));
                SqlCom_1.Parameters.Add(new SqlParameter("@uname", (object)lblkhoa.Text));
                if (radioButton2.Checked || rd_NgayRaVien.Checked || phongkham == true)
                {
                    chuyenvien = 1;
                    SqlCom_1.Parameters.Add(new SqlParameter("@ChuyenVien", chuyenvien));
                }
                else
                {
                    chuyenvien = 0;
                    SqlCom_1.Parameters.Add(new SqlParameter("@ChuyenVien", chuyenvien));
                }
                //Open connection and execute insert query.
                CN_1.Open();
                SqlCom_1.ExecuteNonQuery();
                CN_1.Close();
                // this.Close();
                dataGridView1.DataSource = kn.Spd_select_benhnhan(TxtMavaovien.Text);
                if (radioButton1.Checked == true)
                {
                    dataGridView2.DataSource = kn.danhsach_benhnhan(lblkhoa.Text.Trim());
                    button5.Visible = false;
                    for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
                    {
                        // int val = Int32.Parse(dataGridView2.Rows[i].Cells[14].Value.ToString());
                        if (dataGridView2.Rows[i].Cells["ngaygiaoban"].Value.ToString() != "")
                        {
                            dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.Red;

                        }
                    }
                }
                else if (radioButton2.Checked == true)
                {
                    dataGridView2.DataSource = kn.sp_2(lblkhoa.Text.Trim());
                    button5.Visible = false;
                    for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
                    {
                        // int val = Int32.Parse(dataGridView2.Rows[i].Cells[14].Value.ToString());
                        if (dataGridView2.Rows[i].Cells["ngaygiaoban"].Value.ToString() != "")
                        {
                            dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.Green;

                        }
                    }
                }
                TxtMavaovien.Text = "";
            }
            catch
            {
                MessageBox.Show("Lỗi","Thông báo",MessageBoxButtons.RetryCancel,MessageBoxIcon.Error);
            }
            finally
            {
                MessageBox.Show("Bệnh nhân" + TxtHoten.Text + ",Đã giao giao ban ngày: " + dateTimePicker1.Text + "");
            }
        }


        byte[] ReadFile(string sPath)
        {

            //Initialize byte array with a null value initially.
            byte[] data = null;

            //Use FileInfo object to get file size.
            FileInfo fInfo = new FileInfo(sPath);
            long numBytes = fInfo.Length;

            //Open FileStream to read file
            FileStream fStream = new FileStream(sPath, FileMode.Open, FileAccess.Read);

            //Use BinaryReader to read file stream into byte array.
            BinaryReader br = new BinaryReader(fStream);

            //When you use BinaryReader, you need to supply number of bytes to read from file.
            //In this case we want to read entire file. So supplying total number of bytes.
            data = br.ReadBytes((int)numBytes);
            return data;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtthongtinhc.Visible = false;
            txtthongtinhc.Text = "";
            try
            {
                //Get image data from gridview column.
                byte[] imageData = (byte[])dataGridView1.Rows[e.RowIndex].Cells[1].Value;

                //Initialize image variable
                Image newImage;
                //Read image data into a memory stream
                using (MemoryStream ms = new MemoryStream(imageData, 0, imageData.Length))
                {
                    ms.Write(imageData, 0, imageData.Length);

                    //Set image variable value using memory stream.
                    newImage = Image.FromStream(ms, true);
                }

                //set picture
                pictureBox1.Image = newImage;
                dataGridView1.DataSource = kn.Spd_select_benhnhan(TxtMavaovien.Text);
                //pictureBox1.Height = newImage.Height;
                //pictureBox1.Width = newImage.Width;
                dgv_hoasinh.Visible = false;
                dataGridView3.Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.dataGridView1.Rows[e.RowIndex].Selected = true;
                this.rowIndex = e.RowIndex;
                this.dataGridView1.CurrentCell = this.dataGridView1.Rows[e.RowIndex].Cells[1];
                this.contextMenuStrip1.Show(this.dataGridView1, e.Location);
                contextMenuStrip1.Show(Cursor.Position);
                txtid.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            }
        }
        private void contextMenuStrip1_Click(object sender, EventArgs e)
        {
            if (!this.dataGridView1.Rows[this.rowIndex].IsNewRow)
            {

                kn.xoa_anh(txtid.Text);
                dataGridView1.DataSource = kn.Spd_select_benhnhan(TxtMavaovien.Text);
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Height += 200;
            pictureBox1.Width += 200;
        }

        private void cmdConnect_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            pictureBox1.Height -= 400;
            pictureBox1.Width -= 400;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtthongtinhc.Visible = false;
            btn_new.Enabled = false;
            cmdSave.Enabled = true;
            button1.Enabled = false;
            cmdBrowse.Enabled = true;
            Btnthongtinh_khac.Enabled = true;

            SaveJpg(pictureBox1.Image, txtImagePath.Text, 30);

            try
            {
                //Read Image Bytes into a byte array
                byte[] imageData = ReadFile(txtImagePath.Text);

                ketnoi kn = new ketnoi();
                //Initialize SQL Server Connection
                SqlConnection CN = new SqlConnection(stringcon);

                //Set insert query
                string qry = "insert into ImagesStore (mavaovien,OriginalPath,ImageData) values(@mavaovien,@OriginalPath, @ImageData)";

                //Initialize SqlCommand object for insert.
                SqlCommand SqlCom = new SqlCommand(qry, CN);

                //We are passing Original Image Path and Image byte data as sql parameters.
                SqlCom.Parameters.Add(new SqlParameter("@OriginalPath", (object)txtImagePath.Text));
                SqlCom.Parameters.Add(new SqlParameter("@ImageData", (object)imageData));
                SqlCom.Parameters.Add(new SqlParameter("@mavaovien", (object)TxtMavaovien.Text));
                //Open connection and execute insert query.
                CN.Open();
                SqlCom.ExecuteNonQuery();
                CN.Close();
                dataGridView1.DataSource = kn.Spd_select_benhnhan(TxtMavaovien.Text);
            }
            catch (Exception ex)
            {
                return;
            }
            //dgv_hoasinh.DataSource = kn.danhsach_benhnhan_ketqua(TxtMavaovien.Text);
            //dataGridView3.DataSource = kn.danhsach_benhnhan_ketqua_hh(TxtMavaovien.Text);
            //dgv_hoasinh.Visible = true;
            //dataGridView3.Visible = true;
            //txtthongtinhc.Visible = false;
            //dgv_hoasinh.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            phongkham = false;
            //tungay.Visible = false;
            //denngay.Visible = false;
            //label14.Visible = false;
            //label13.Visible = false;
            txtthongtinhc.Text = "";
            if (radioButton1.Checked == true)
            {
                tungay.Visible = false;
                denngay.Visible = false;
                label14.Visible = false;
                label13.Visible = false;
                dataGridView2.DataSource = kn.danhsach_benhnhan(lblkhoa.Text.Trim());
                //dataGridView1.DataSource = kn.Spd_select_benhnhan(TxtMavaovien.Text);
                button5.Visible = false;
                for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
                {
                    // int val = Int32.Parse(dataGridView2.Rows[i].Cells[14].Value.ToString());
                    if (dataGridView2.Rows[i].Cells["ngaygiaoban"].Value.ToString() != "")
                    {
                        dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.Red;

                    }
                }
                return;
            }
            else if (radioButton2.Checked == true)
            {
                tungay.Visible = false;
                denngay.Visible = false;
                label14.Visible = false;
                label13.Visible = false;
                dataGridView2.DataSource = kn.sp_2(lblkhoa.Text.Trim());
                button5.Visible = false;
                for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
                {
                    // int val = Int32.Parse(dataGridView2.Rows[i].Cells[14].Value.ToString());
                    if (dataGridView2.Rows[i].Cells["ngaygiaoban"].Value.ToString() != "")
                    {
                        dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                    }
                }
                return;
            }
            else if (radioButton3.Checked == true)
            {
                tungay.Visible = true;
                denngay.Visible = true;
                label14.Visible = true;
                label13.Visible = true;
                dataGridView2.DataSource = kn.danhsach_benhnhan_gb_khoa(tungay.Text, denngay.Text, lblkhoa.Text.Trim());
                button5.Visible = true;
                return;

            }
            else if (rd_NgayRaVien.Checked == true)
            {
                tungay.Visible = true;
                denngay.Visible = true;
                label14.Visible = true;
                label13.Visible = true;
                dataGridView2.DataSource = kn.sp_3(lblkhoa.Text.Trim(), tungay.Value, denngay.Value);
                button5.Visible = true;
                return;
            }
        }

        private void TxtDiachi_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void TxtNgayVaoVien_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void TxtNgayPhauThuat_TextChanged(object sender, EventArgs e)
        {

        }



        private void SaveJpg(Image image, string file_name, long compression)
        {
            try
            {
                EncoderParameters encoder_params = new EncoderParameters(1);
                encoder_params.Param[0] = new EncoderParameter(
                    System.Drawing.Imaging.Encoder.Quality, compression);

                ImageCodecInfo image_codec_info =
                    GetEncoderInfo("image/jpeg");
                File.Delete(file_name);
                image.Save(file_name, image_codec_info, encoder_params);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving file '" + file_name +
                    "'\nTry a different file name.\n" + ex.Message,
                    "Save Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Return an ImageCodecInfo object for this mime type.
        private ImageCodecInfo GetEncoderInfo(string mime_type)
        {
            ImageCodecInfo[] encoders = ImageCodecInfo.GetImageEncoders();
            for (int i = 0; i <= encoders.Length; i++)
            {
                if (encoders[i].MimeType == mime_type) return encoders[i];
            }
            return null;
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            tungay.Visible = false;
            denngay.Visible = false;
            label14.Visible = false;
            label13.Visible = false;
            dataGridView2.DataSource = kn.danhsach_benhnhan(lblkhoa.Text.Trim());
            //dataGridView1.DataSource = kn.Spd_select_benhnhan(TxtMavaovien.Text);
            button5.Visible = false;
            for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
            {
                // int val = Int32.Parse(dataGridView2.Rows[i].Cells[14].Value.ToString());
                if (dataGridView2.Rows[i].Cells["ngaygiaoban"].Value.ToString() != "")
                {
                    dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.Red;

                }
            }
        }

        private void cmdStoreNewImage_Click(object sender, EventArgs e)
        {

        }

        private void txtImagePath_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void txtngaygiaoban_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblkhoa_Click(object sender, EventArgs e)
        {

        }

        private void Btnthongtinh_khac_Click(object sender, EventArgs e)
        {
            txtthongtinhc.Visible = true;
            dgv_hoasinh.Visible = false;
            dataGridView3.Visible = false;
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            TxtHoten.Text = "";
            txtbacsypt.Text = "";
            TxtNamsinh.Text = "";
            TxtGioitinh.Text = "";
            TxtChanDoan.Text = "";
            txtcdsaumo.Text = "";
            TxtDiachi.Text = "";
            TxtNgayVaoVien.Text = "";
            Txtngayphauthuat.Text = "";
            txtxutri.Text = "";
            dataGridView4.DataSource = kn.mabenhnhan();
            TxtMavaovien.Text = dataGridView4.CurrentRow.Cells[0].Value.ToString();
            btn_new.Enabled = false;
            button1.Enabled = false;
            txtthongtinhc.Text = "";
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            label14.Visible = true;
            label13.Visible = true;
            tungay.Visible = true;
            denngay.Visible = true;

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            tungay.Visible = false;
            denngay.Visible = false;
            label14.Visible = false;
            label13.Visible = false;
            dataGridView2.DataSource = kn.sp_2(lblkhoa.Text.Trim());
            button5.Visible = false;
            for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
            {
                // int val = Int32.Parse(dataGridView2.Rows[i].Cells[14].Value.ToString());
                if (dataGridView2.Rows[i].Cells["ngaygiaoban"].Value.ToString() != "")
                {
                    dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.Green;

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = kn.sp_delete_BENHNHAN(TxtMavaovien.Text);
            MessageBox.Show("Đã xóa bệnh nhân" + TxtHoten.Text + ", giao ban ngày: " + dateTimePicker1.Text + "");
            dataGridView2.DataSource = kn.danhsach_benhnhan_gb_khoa(tungay.Text, denngay.Text, lblkhoa.Text.Trim());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = kn.bc_gb_phongkhamcc(tungay.Text, denngay.Text);

        }

        private void btnbaocao_Click(object sender, EventArgs e)
        {
            //frmkhoacc frm = new frmkhoacc(tungay.Text, denngay.Text);
            //frm.Show();
        }

        public void RowsColor()
        {
            DataTable dt = new DataTable();
            dataGridView2.DataSource = dt;
            for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
            {
                // int val = Int32.Parse(dataGridView2.Rows[i].Cells[14].Value.ToString());
                if (dataGridView2.Rows[i].Cells["ngaygiaoban"].Value.ToString() != "")
                {
                    dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.Red;

                }

                //else if (val >= 5 && val < 10)
                //{
                //    dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.Orange;
                //}
            }
        }

        private void xóaẢnhToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void rd_NgayRaVien_CheckedChanged(object sender, EventArgs e)
        {
            label14.Visible = true;
            label13.Visible = true;
            tungay.Visible = true;
            denngay.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            cmdBrowse.Enabled = true;
            pictureBox1.ImageLocation = "";
            Btnthongtinh_khac.Enabled = true;
            cmdSave.Enabled = true;
            //Provide file path in txtImagePath text box.
            txtImagePath.Text = "";
            //pictureBox1.Dispose();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            frmShowDSBenhNhan_NgoaiTru nhan = new frmShowDSBenhNhan_NgoaiTru();
            nhan.ShowDialog();
            if (nhan.DialogResult == DialogResult.OK)
            {
                TxtMavaovien.Text = nhan.MaKhambenhReturn;
                TxtHoten.Text = nhan.TenBenhnhanReturn;
                TxtNamsinh.Text = nhan.NamsinhReturn;
                TxtGioitinh.Text = nhan.GioiTinhReturn;
                TxtDiachi.Text = nhan.DiachiReturn;
                TxtChanDoan.Text = nhan.Chuyenvien_ChandoanReturn;
                txtcdsaumo.Text = "";
                txtxutri.Text = nhan.TenBVReturn;
                txtbacsypt.Text = nhan.TenDuReturn;
                Txtngayphauthuat.Text = nhan.Chuyenvien_ThoigianReturn;
                txttenkhoa.Text= nhan.tenkhoaReturn;
                txtthongtinhc.Text = nhan.HanhChinhReturn;
                //lblkhoa.Text = nhan.KhoathuchienReturn;
                lblkhoa.Text = Global.glbUName;
                TxtNgayVaoVien.Text = nhan.thoigiandangkyReturn;
                txtthongtinhc.Visible = true;
                phongkham = true ;
            }
        }
    }
}


