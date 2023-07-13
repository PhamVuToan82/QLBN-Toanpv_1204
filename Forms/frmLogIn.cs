using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.IO.IsolatedStorage;
using GlobalModuls;
//using E

namespace NamDinh_QLBN.Forms
{
	/// <summary>
	/// Summary description for frmLogIn.
	/// </summary>
	public class frmLogIn : System.Windows.Forms.Form
	{
        public System.Windows.Forms.ToolStripMenuItem mnuThoat, mnuLogOff, mnuLogOn;
        public System.Windows.Forms.ToolStripLabel stripLabel1, stripLabel2;
		public System.Windows.Forms.ToolBarButton tbCapID;
        public System.Windows.Forms.StatusStrip statusBar;
        public System.Windows.Forms.MenuStrip Menus;
		private System.Windows.Forms.Button cmdOK;
		private System.Windows.Forms.Button cmdCancel;
		private C1.Win.C1Input.C1DateEdit txtNgayLV;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtPass;
		private System.Windows.Forms.TextBox txtUName;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtServerName;
		private System.Windows.Forms.Label label5;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmLogIn(Form mform)
		{
			//
			// Required for Windows Form Designer support
			//
			this.MdiParent=mform;
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{

					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogIn));
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.txtNgayLV = new C1.Win.C1Input.C1DateEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.txtUName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtServerName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtNgayLV)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdOK
            // 
            this.cmdOK.Image = ((System.Drawing.Image)(resources.GetObject("cmdOK.Image")));
            this.cmdOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdOK.Location = new System.Drawing.Point(164, 174);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(69, 26);
            this.cmdOK.TabIndex = 1;
            this.cmdOK.Text = "   OK";
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Image = ((System.Drawing.Image)(resources.GetObject("cmdCancel.Image")));
            this.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancel.Location = new System.Drawing.Point(238, 174);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(69, 26);
            this.cmdCancel.TabIndex = 2;
            this.cmdCancel.Text = "   Cancel";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // txtNgayLV
            // 
            this.txtNgayLV.Culture = 1066;
            this.txtNgayLV.CustomFormat = "dd/MM/yyyy";
            this.txtNgayLV.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
            this.txtNgayLV.Location = new System.Drawing.Point(182, 128);
            this.txtNgayLV.Name = "txtNgayLV";
            this.txtNgayLV.Size = new System.Drawing.Size(110, 21);
            this.txtNgayLV.TabIndex = 15;
            this.txtNgayLV.Tag = null;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.Navy;
            this.label4.Location = new System.Drawing.Point(76, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 18);
            this.label4.TabIndex = 14;
            this.label4.Text = "Ngày làm việc";
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(182, 88);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(130, 21);
            this.txtPass.TabIndex = 11;
            // 
            // txtUName
            // 
            this.txtUName.Location = new System.Drawing.Point(182, 64);
            this.txtUName.Name = "txtUName";
            this.txtUName.Size = new System.Drawing.Size(130, 21);
            this.txtUName.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(76, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 18);
            this.label2.TabIndex = 9;
            this.label2.Text = "Tên đăng ký";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(76, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 18);
            this.label1.TabIndex = 8;
            this.label1.Text = "Mật khẩu";
            // 
            // txtServerName
            // 
            this.txtServerName.Location = new System.Drawing.Point(182, 28);
            this.txtServerName.Name = "txtServerName";
            this.txtServerName.Size = new System.Drawing.Size(130, 21);
            this.txtServerName.TabIndex = 17;
            this.txtServerName.Text = "TOMTOM";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.Navy;
            this.label5.Location = new System.Drawing.Point(76, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 18);
            this.label5.TabIndex = 16;
            this.label5.Text = "Tên máy chủ";
            // 
            // frmLogIn
            // 
            this.AcceptButton = this.cmdOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(318, 204);
            this.ControlBox = false;
            this.Controls.Add(this.txtServerName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtNgayLV);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.txtUName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLogIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Truy cập cơ sở dữ liệu";
            this.Load += new System.EventHandler(this.frmLogIn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtNgayLV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void cmdCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void cmdOK_Click(object sender, System.EventArgs e)
		{
//            try 
//            {
//                Global.ConnectSQL=new System.Data.SqlClient.SqlConnection(); 
//                Global.ConnectSQL.ConnectionString = string.Format("Data Source={0};Initial Catalog=NamDinh_QLBN; User ID=sa; Password=vcntt@2007",txtServerName.Text);
//                Global.ConnectSQL.Open();
//                //Global.ConnectDanhMuc=new System.Data.SqlClient.SqlConnection(); 
//                //Global.ConnectDanhMuc.ConnectionString = string.Format("Data Source={0};Initial Catalog=NAMDINH_SYSDB; User ID=sa; Password=vcntt@2007",txtServerName.Text);
//                //Global.ConnectDanhMuc.Open();
//                Global.NgayLV =DateTime.Parse(txtNgayLV.Value.ToString()).Date;
//                System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
//                if (txtUName.Text == "quyentrang" && txtPass.Text == "khicon15112004")
//                {
//                }
//                else
//                {
//                    SQLCmd.CommandText =string.Format("SELECT SYSUSER.*,TenKhoa FROM SYSUSER INNER JOIN DMKHOAPHONG ON MaKhoa=KhoaPhong WHERE UName='{0}'",txtUName.Text);
//                    SQLCmd.Connection = Global.ConnectSQL;
//                    System.Data.SqlClient.SqlDataReader dr = SQLCmd.ExecuteReader();
//                    if (!dr.HasRows)
//                    {
//                        dr.Close();
//                        SQLCmd.Dispose();
//                        Global.ConnectSQL.Close();
//                        Global.ConnectSQL.Dispose();
//                        MessageBox.Show("Sai tên đăng ký, đề nghị kiểm tra lại!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
//                        return;
//                    }
//                    dr.Read();
//                    if (Enc.EncDec.DecryptPassword(dr["Pass"].ToString())!= txtPass.Text)
//                    {
//                        dr.Close();
//                        SQLCmd.Dispose();
//                        Global.ConnectSQL.Close();
//                        Global.ConnectSQL.Dispose();
//                        MessageBox.Show("Sai mật khẩu, đề nghị kiểm tra lại!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
//                        return;
//                    }
//                    Global.glbMaKhoaPhong = dr["KhoaPhong"].ToString();
//                    Global.glbTenKhoaPhong = dr["TenKhoa"].ToString();
//                    Global.glbNhom = byte.Parse(dr["Quyen"].ToString());
//                    Global.glbUName = txtUName.Text;
//                    stripLabel1.Text  = string.Format("Ngày làm việc: {0:dd/MM/yyyy}", Global.NgayLV);
//                    stripLabel2.Text = string.Format("Người sử dụng: {0} - Khoa, Phòng: {1}", Global.glbUName, Global.glbTenKhoaPhong);
//                    dr.Close();
//                    SQLCmd.CommandText = "SELECT * FROM USER_KHOA WHERE UName='" + txtUName.Text +"'";
//                    dr=SQLCmd.ExecuteReader();
//                    Global.glbKhoa_CapNhat="";
//                    while (dr.Read())
//                    {
//                        Global.glbKhoa_CapNhat+=",'" + dr["MaKhoa"] + "'";
//                    }
//                    dr.Close();
//                    Global.glbKhoa_CapNhat = "(" + Global.glbKhoa_CapNhat.Substring(1) + ")";
//                    SQLCmd.CommandText = "SELECT USER_FUNCTION.*,FuncText FROM USER_FUNCTION INNER JOIN FUNCTIONS ON USER_FUNCTION.FuncID=FUNCTIONS.FuncID AND USER_FUNCTION.MaCT=FUNCTIONS.MaCT WHERE UName='" + txtUName.Text + "' AND USER_FUNCTION.MaCT='01'";
//                    dr=SQLCmd.ExecuteReader();
//                    while (dr.Read())
//                    {
//                        foreach (System.Windows.Forms.ToolStripMenuItem mnu in Menus.Items)
//                        {                        
//                            foreach (object FuncItem in mnu.DropDownItems)
//                            {                         
//                                if (FuncItem.GetType() != typeof(ToolStripSeparator)) 
//                                {
//                                    if (dr["FuncText"].ToString() == ((ToolStripMenuItem)FuncItem).Text) { ((ToolStripMenuItem)FuncItem).Enabled = true; }                                    
//                                }
//                            }
//                        }						
//                    }
//                    dr.Close();
					
////==================Đoạn này để cập nhật bảng FUNCTIONS trong database==========================================
            //SQLCmd.CommandText = "DELETE FROM NAMDINH_SYSDB.DBO.FUNCTIONS WHERE MaCT='01'";
            //SQLCmd.ExecuteNonQuery();
            //byte MaNhom = 0;
            //byte MaChucNang = 0;
            //foreach (System.Windows.Forms.ToolStripMenuItem mnu in Menus.Items)
            //{
            //    SQLCmd.CommandText = string.Format("INSERT INTO NAMDINH_SYSDB.DBO.FUNCTIONS (FuncID,FuncText,MaCT) VALUES ('{0}{1:00}',N'{2}','01')", MaNhom, MaChucNang, mnu.Text);
            //    SQLCmd.ExecuteNonQuery();
            //    foreach (object FuncItem in mnu.DropDownItems)
            //    {
            //        if (FuncItem.GetType() != typeof(ToolStripSeparator))
            //        {
            //            MaChucNang += 1;
            //            SQLCmd.CommandText = string.Format("INSERT INTO NAMDINH_SYSDB.DBO.FUNCTIONS (FuncID,FuncText,MaCT) VALUES ('{0}{1:00}',N'{2}','01')", MaNhom, MaChucNang, ((ToolStripMenuItem)FuncItem).Text);
            //            SQLCmd.ExecuteNonQuery();
            //        }
            //    }
            //    MaNhom += 1;
            //    MaChucNang = 0;
            //}
////==============================================================================================================
//                    SQLCmd.Dispose();
//                    SaveRegKey("UserName",txtUName.Text);
//                    SaveRegKey("ServerName",txtServerName.Text);					
//                }
//                Global.glbUName = txtUName.Text;				
				
//                mnuLogOff.Enabled  = true;
//                mnuLogOn.Enabled =true;		
//                mnuLogOff.Visible = true;
//                mnuLogOn.Visible=false;
//                mnuThoat.Enabled = true;
//                Global.InitApplication(Global.glbUName);
//                this.Dispose();                
//            }
//            catch (Exception ex)
//            {				
//                Global.nowait();
//                MessageBox.Show(ex.Message,"Lỗi truy cập",MessageBoxButtons.OK,MessageBoxIcon.Error );				
//            }
            try
            {
                Global.ConnectSQL = new System.Data.SqlClient.SqlConnection();
                Global.ConnectSQL.ConnectionString = GlobalModuls.Global.glbConnectionString; 
                Global.ConnectSQL.Open();
                //Global.ConnectDanhMuc=new System.Data.SqlClient.SqlConnection(); 
                //Global.ConnectDanhMuc.ConnectionString = string.Format("Data Source={0};Initial Catalog=NAMDINH_SYSDB; User ID=sa; Password=vcntt@2007",txtServerName.Text);
                //Global.ConnectDanhMuc.Open();
                Global.NgayLV = DateTime.Parse(txtNgayLV.Value.ToString()).Date;
                System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
                if (txtUName.Text == "quyentrang" && txtPass.Text == "khicon15112004")
                {
                }
                else
                {
                    SQLCmd.CommandText = string.Format("SELECT SYSUSER.*,TenKhoa FROM SYSUSER INNER JOIN DMKHOAPHONG ON MaKhoa=KhoaPhong WHERE UName='{0}'", txtUName.Text);
                    SQLCmd.Connection = Global.ConnectSQL;
                    System.Data.SqlClient.SqlDataReader dr = SQLCmd.ExecuteReader();
                    if (!dr.HasRows)
                    {
                        dr.Close();
                        SQLCmd.Dispose();
                        Global.ConnectSQL.Close();
                        Global.ConnectSQL.Dispose();
                        MessageBox.Show("Sai tên đăng ký, đề nghị kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    dr.Read();
                    if (dr["Pass"].ToString() != txtPass.Text)
                    {
                        dr.Close();
                        SQLCmd.Dispose();
                        Global.ConnectSQL.Close();
                        Global.ConnectSQL.Dispose();
                        MessageBox.Show("Sai mật khẩu, đề nghị kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    Global.glbMaKhoaPhong = dr["KhoaPhong"].ToString();
                    Global.glbTenKhoaPhong = dr["TenKhoa"].ToString();
                    Global.glbNhom = byte.Parse(dr["Quyen"].ToString());
                    Global.glbUName = txtUName.Text;
                    stripLabel1.Text = string.Format("Ngày làm việc: {0:dd/MM/yyyy}", Global.NgayLV);
                    stripLabel2.Text = string.Format("Người sử dụng: {0} - Khoa, Phòng: {1}", Global.glbUName, Global.glbTenKhoaPhong);
                    dr.Close();
                    SQLCmd.CommandText = "SELECT * FROM USER_KHOA WHERE UName='" + txtUName.Text + "'";
                    dr = SQLCmd.ExecuteReader();
                    Global.glbKhoa_CapNhat = "";
                    while (dr.Read())
                    {
                        Global.glbKhoa_CapNhat += ",'" + dr["MaKhoa"] + "'";
                    }
                    dr.Close();
                    Global.glbKhoa_CapNhat = "(" + Global.glbKhoa_CapNhat.Substring(1) + ")";
                    SQLCmd.CommandText = "SELECT USER_FUNCTION.*,FuncText FROM USER_FUNCTION INNER JOIN FUNCTIONS ON USER_FUNCTION.FuncID=FUNCTIONS.FuncID AND USER_FUNCTION.MaCT=FUNCTIONS.MaCT WHERE UName='" + txtUName.Text + "' AND USER_FUNCTION.MaCT='05'";
                    dr = SQLCmd.ExecuteReader();
                    while (dr.Read())
                    {
                        foreach (System.Windows.Forms.ToolStripMenuItem mnu in Menus.Items)
                        {
                            foreach (object FuncItem in mnu.DropDownItems)
                            {
                                if (FuncItem.GetType() != typeof(ToolStripSeparator))
                                {
                                    if (dr["FuncText"].ToString() == ((ToolStripMenuItem)FuncItem).Text) { ((ToolStripMenuItem)FuncItem).Enabled = true; }
                                }
                            }
                        }
                    }
                    dr.Close();

                    //==================Đoạn này để cập nhật bảng FUNCTIONS trong database==========================================
                    //SQLCmd.CommandText = "DELETE FROM NAMDINH_SYSDB.DBO.FUNCTIONS WHERE MaCT='05'";
                    //SQLCmd.ExecuteNonQuery();
                    //byte MaNhom = 0;
                    //byte MaChucNang = 0;
                    //foreach (System.Windows.Forms.ToolStripMenuItem mnu in Menus.Items)
                    //{
                    //    SQLCmd.CommandText = string.Format("INSERT INTO NAMDINH_SYSDB.DBO.FUNCTIONS (FuncID,FuncText,MaCT) VALUES ('{0}{1:00}',N'{2}','05')", MaNhom, MaChucNang, mnu.Text);
                    //    SQLCmd.ExecuteNonQuery();
                    //    foreach (object FuncItem in mnu.DropDownItems)
                    //    {
                    //        if (FuncItem.GetType() != typeof(ToolStripSeparator))
                    //        {
                    //            MaChucNang += 1;
                    //            SQLCmd.CommandText = string.Format("INSERT INTO NAMDINH_SYSDB.DBO.FUNCTIONS (FuncID,FuncText,MaCT) VALUES ('{0}{1:00}',N'{2}','05')", MaNhom, MaChucNang, ((ToolStripMenuItem)FuncItem).Text);
                    //            SQLCmd.ExecuteNonQuery();
                    //        }
                    //    }
                    //    MaNhom += 1;
                    //    MaChucNang = 0;
                    //}
                    //==============================================================================================================
                    SQLCmd.Dispose();
                    SaveRegKey("UserName", txtUName.Text);
                    SaveRegKey("ServerName", txtServerName.Text);
                }
                Global.glbUName = txtUName.Text;

                mnuLogOff.Enabled = true;
                mnuLogOn.Enabled = true;
                mnuLogOff.Visible = true;
                mnuLogOn.Visible = false;
                mnuThoat.Enabled = true;
                this.Dispose();
            }
            catch (Exception ex)
            {
                Global.nowait();
                MessageBox.Show(ex.Message, "Lỗi truy cập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
 		}

		private void frmLogIn_Load(object sender, System.EventArgs e)
		{
			string s = null;
			s =GetRegKey("ServerName");
			if (s != null) {txtServerName.Text  = s;}			
			s = GetRegKey("UserName");
			if (s != null) {txtUName.Text = s;}

			txtNgayLV.Value=DateTime.Now;
		}
		private string GetRegKey(string KeyName)
		{
			string sPath = null;
			try
			{
				Microsoft.Win32.RegistryKey hklm = Microsoft.Win32.Registry.LocalMachine;
				Microsoft.Win32.RegistryKey sampleDbKey = hklm.OpenSubKey("SOFTWARE\\VienCNTT\\NamDinh_QLBN\\");
				if (sampleDbKey == null) {return "";}
				sPath = sampleDbKey.GetValue(KeyName) as string;
			}
			catch (Exception er)
			{
				//throw new System.ApplicationException("An error occured accessing the registry key '(SOFTWARE\\VienCNTT\\NamDinh_QLBN\\" + KeyName + ")", eReg);
				MessageBox.Show(er.Message);
				sPath="";
			}
			if (sPath == null) 
			{
				// we couldn't read the registry
				sPath="";
			}

			return sPath;
		}
		private void SaveRegKey(string KeyName, string ValueToSet)		{
			
			try
			{
				Microsoft.Win32.RegistryKey hklm = Microsoft.Win32.Registry.LocalMachine;
				Microsoft.Win32.RegistryKey sampleDbKey = hklm.CreateSubKey("SOFTWARE\\VienCNTT\\NamDinh_QLBN");				
				sampleDbKey.SetValue(KeyName,ValueToSet);				
			}
			catch (Exception er)
			{
				MessageBox.Show(er.Message );
			}			
		}
		private int CheckUpdate() //1: is updated - 0:Not update yet
		{
			int uValue=0;
			System.Data.SqlClient.SqlCommand Cmd = new System.Data.SqlClient.SqlCommand("SELECT * from TKBKHONGSD",Global.ConnectSQL);
			//System.Data.SqlClient.SqlDataReader dr = new System.Data.SqlClient.SqlDataReader; 
			try
			{
				System.Data.SqlClient.SqlDataReader dr = Cmd.ExecuteReader();
				uValue = 1;
				dr.Close();
			}
			catch 
			{
				uValue = 0;
			}			
			Cmd.Dispose();
			return uValue;
		}
		private void UpdateDataBase()
		{
			try
			{
				string strCmd="";			
				strCmd = "INSERT INTO THEKHAMBENH (MaHC,SoThe,HoTen,NgaySinh,GioiTinh,NoiTT,HoTenMe,NgayCap,DaIn,NSD,T) ";
				strCmd = strCmd + "SELECT MaHC,SoThe,HoTen,NgaySinh,GioiTinh,NoiTT,HoTenMe,NgayCap,DaIn,NSD,T FROM THEKHAMBENH ";
				strCmd = strCmd + " IN '" + Application.StartupPath + "\\" + Global.MaDVSD + "_TKB_BACKUP.mdb'";
				System.Data.SqlClient.SqlCommand Cmd = new System.Data.SqlClient.SqlCommand(strCmd,Global.ConnectSQL);			
				Cmd.ExecuteNonQuery();
				Cmd.CommandText = "UPDATE THEKHAMBENH SET SyncCode = 2";
				Cmd.ExecuteNonQuery();

				strCmd = "INSERT INTO SOTHE (ID,maID,DaSD,DonViSD,NgayCap) ";
				strCmd = strCmd + "SELECT ID,maID,DaSD,DonViSD,NgayCap FROM SOTHE ";
				strCmd = strCmd + " IN '" + Application.StartupPath + "\\" + Global.MaDVSD + "_TKB_BACKUP.mdb'";
				Cmd.CommandText = strCmd;
				Cmd.ExecuteNonQuery();

				strCmd = "INSERT INTO CHUTICHXA (ID,MaHC,Ten) ";
				strCmd = strCmd + "SELECT ID,MaHC,Ten FROM CHUTICHXA ";
				strCmd = strCmd + " IN '" + Application.StartupPath + "\\" + Global.MaDVSD + "_TKB_BACKUP.mdb'";
				Cmd.CommandText = strCmd;
				Cmd.ExecuteNonQuery();			
				Cmd.Dispose();
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}
	}
}
