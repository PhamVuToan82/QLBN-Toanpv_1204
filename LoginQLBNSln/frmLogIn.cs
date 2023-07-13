using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.IO.IsolatedStorage;

namespace AutoUpdate.Forms
{
	/// <summary>
	/// Summary description for frmLogIn.
	/// </summary>
	public class frmLogIn : System.Windows.Forms.Form
	{
		public System.Windows.Forms.MenuItem mnuDL,mnuDM,mnuIn,mnuGetID,mnuBackUp,mnuChangeP,mnuQT,mnuSetID,mnuTheKSD,mnuTK;
		public System.Windows.Forms.ToolBarButton tbCapID;
		
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
		
		private string glbUName = "";
		private DateTime NgayLV =DateTime.Parse("01/01/1900");
		private string glbFullName="";
		private C1.Win.C1Input.C1DateEdit txtNgayLV;
		private int UserGroupID=0;
        private string[] ListFileUpdate = new string[1] { "QLBN103.exe"};
        private Button cmdCancel;
        private Button cmdOK;
        private Button btnThamSo;
		private string TabName="APPLICATION_FILES";
        private string ExeFileName = "QLBN103.EXE";

		public frmLogIn()
		{
			//
			// Required for Windows Form Designer support
			//
			
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
            this.label4 = new System.Windows.Forms.Label();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.txtUName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtServerName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNgayLV = new C1.Win.C1Input.C1DateEdit();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.btnThamSo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.txtNgayLV)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.Navy;
            this.label4.Location = new System.Drawing.Point(89, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 18);
            this.label4.TabIndex = 14;
            this.label4.Text = "Ngày làm việc";
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(176, 100);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(130, 21);
            this.txtPass.TabIndex = 11;
            // 
            // txtUName
            // 
            this.txtUName.Location = new System.Drawing.Point(176, 76);
            this.txtUName.Name = "txtUName";
            this.txtUName.Size = new System.Drawing.Size(130, 21);
            this.txtUName.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(89, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 18);
            this.label2.TabIndex = 9;
            this.label2.Text = "Tên đăng ký";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(89, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 18);
            this.label1.TabIndex = 8;
            this.label1.Text = "Mật khẩu";
            // 
            // txtServerName
            // 
            this.txtServerName.Location = new System.Drawing.Point(176, 228);
            this.txtServerName.Name = "txtServerName";
            this.txtServerName.Size = new System.Drawing.Size(130, 21);
            this.txtServerName.TabIndex = 17;
            this.txtServerName.Text = "TOMTOM";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.Navy;
            this.label5.Location = new System.Drawing.Point(89, 230);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 18);
            this.label5.TabIndex = 16;
            this.label5.Text = "Tên máy chủ";
            // 
            // txtNgayLV
            // 
            this.txtNgayLV.Culture = 1066;
            this.txtNgayLV.CustomFormat = "dd/MM/yyyy";
            this.txtNgayLV.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
            this.txtNgayLV.Location = new System.Drawing.Point(176, 124);
            this.txtNgayLV.Name = "txtNgayLV";
            this.txtNgayLV.Size = new System.Drawing.Size(110, 21);
            this.txtNgayLV.TabIndex = 23;
            this.txtNgayLV.Tag = null;
            // 
            // cmdCancel
            // 
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Image = ((System.Drawing.Image)(resources.GetObject("cmdCancel.Image")));
            this.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancel.Location = new System.Drawing.Point(243, 176);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(71, 26);
            this.cmdCancel.TabIndex = 25;
            this.cmdCancel.Text = "   Cancel";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdOK
            // 
            this.cmdOK.Image = ((System.Drawing.Image)(resources.GetObject("cmdOK.Image")));
            this.cmdOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdOK.Location = new System.Drawing.Point(169, 176);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(71, 26);
            this.cmdOK.TabIndex = 24;
            this.cmdOK.Text = "   OK";
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // btnThamSo
            // 
            this.btnThamSo.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnThamSo.Image = ((System.Drawing.Image)(resources.GetObject("btnThamSo.Image")));
            this.btnThamSo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThamSo.Location = new System.Drawing.Point(12, 176);
            this.btnThamSo.Name = "btnThamSo";
            this.btnThamSo.Size = new System.Drawing.Size(71, 26);
            this.btnThamSo.TabIndex = 26;
            this.btnThamSo.Text = "    Tham số";
            this.btnThamSo.Click += new System.EventHandler(this.btnThamSo_Click);
            // 
            // frmLogIn
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(318, 208);
            this.ControlBox = false;
            this.Controls.Add(this.btnThamSo);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.txtNgayLV);
            this.Controls.Add(this.txtServerName);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.txtUName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLogIn";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Truy cập cơ sở dữ liệu";
            this.Load += new System.EventHandler(this.frmLogIn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtNgayLV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		[STAThread]
		static void Main() 
		{
			Application.Run(new frmLogIn());
		}

		private void frmLogIn_Load(object sender, System.EventArgs e)
		{

			glbUName = "";
			FileInfo m_FileInfo = new FileInfo(Application.StartupPath + "\\QLBN103.ini");
			
			
			if (!m_FileInfo.Exists ) 
			{
				m_FileInfo.Create();				
			}
			else
			{				
				StreamReader m_FileStream = m_FileInfo.OpenText();
				txtServerName.Text = m_FileStream.ReadLine();
                txtUName.Text = m_FileStream.ReadLine();				
				m_FileStream.Close();
			}
			txtNgayLV.Value=DateTime.Now;
		}	

		private void cmdOK_Click(object sender, System.EventArgs e)
		{
			System.Data.SqlClient.SqlConnection ConnectSQL = null;
			try 
			{
				ConnectSQL=new System.Data.SqlClient.SqlConnection(); 				
				ConnectSQL.ConnectionString = string.Format("Data Source='{0}';Initial Catalog={1}; User ID='103_Admin'; Password='vcntt2007'",txtServerName.Text,"SYSDB103" );
				ConnectSQL.Open();
                System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
                SQLCmd.CommandText = string.Format("SELECT SYSUSER.*,TenKhoa FROM SYSUSER INNER JOIN DMKHOAPHONG ON MaKhoa=KhoaPhong WHERE UName='{0}'", txtUName.Text);
                SQLCmd.Connection = ConnectSQL;
                System.Data.SqlClient.SqlDataReader dr = SQLCmd.ExecuteReader();
                if (!dr.HasRows)
                {
                    dr.Close();
                    SQLCmd.Dispose();
                    ConnectSQL.Close();
                    ConnectSQL.Dispose();
                    MessageBox.Show("Sai tên đăng ký, đề nghị kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                dr.Read();
                if (dr["Pass"].ToString() != txtPass.Text)
                {
                    dr.Close();
                    SQLCmd.Dispose();
                    ConnectSQL.Close();
                    ConnectSQL.Dispose();
                    MessageBox.Show("Sai mật khẩu, đề nghị kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
				
				NgayLV =DateTime.Parse(txtNgayLV.Value.ToString()).Date;
				FileInfo m_FileInfo = new FileInfo(Application.StartupPath + "\\QLBN103.ini");
				//Khoi tao file log
				FileInfo LogFile=new FileInfo(Application.StartupPath + "\\LogFile.log");
				if (!LogFile.Exists ) 
				{
					LogFile.Create();				
				}

				StreamWriter m_FileWrite=m_FileInfo.CreateText();
				m_FileWrite.WriteLine(txtServerName.Text);
				m_FileWrite.WriteLine(txtUName.Text);				
				m_FileWrite.Close();
				glbUName = txtUName.Text;				

				//Kiem tra version cac file xem co can update hay khong?

				dr.Close();			
				for (int i=0;i<=ListFileUpdate.GetUpperBound(0);i++)
				{
					UpdateFile(ListFileUpdate[i].ToUpper(),ConnectSQL);
				}					
				SQLCmd.Dispose();
				ConnectSQL.Close();
				ConnectSQL.Dispose();
				this.Dispose(); 
			}
			catch (Exception ex)
			{				
				MessageBox.Show("Không thể truy cập đến máy chủ cơ sở dữ liệu\n" + ex.Message ,"Lỗi truy cập",MessageBoxButtons.OK,MessageBoxIcon.Error );				
			}
            Exec_Application(ExeFileName);
			Application.Exit();
		}

		private void cmdCancel_Click(object sender, System.EventArgs e)
		{
			glbUName = "";
			Application.Exit();
		}

		private void btnThamSo_Click(object sender, System.EventArgs e)
		{
			if (this.Height==294) {this.Height=232;}
			else {this.Height=294;}
			
		}
		private bool UpdateFile(string FileName,System.Data.SqlClient.SqlConnection ConnectSQL)
		{
			
			string DBFileVersion="";           
			System.Data.SqlClient.SqlCommand cmd=null;
			try
			{
				if (!File.Exists(Application.StartupPath + @"\" + FileName))
				{					
					MessageBox.Show("Khong tim thay file " + FileName,"Thong bao");
					return false;
				}
				string FileVersion = System.Diagnostics.FileVersionInfo.GetVersionInfo(Application.StartupPath + @"\" + FileName).FileVersion;
				System.Data.SqlClient.SqlDataReader dr;
				cmd = new System.Data.SqlClient.SqlCommand();
				cmd.Connection = ConnectSQL;
				cmd.CommandText ="SELECT FileVersion FROM " + TabName + " WHERE UPPER(FileName)='" + FileName + "'";
				dr=cmd.ExecuteReader();
				if (dr.Read())
				{
					DBFileVersion = dr["FileVersion"].ToString();
				}
				dr.Close();
				if (string.Compare(FileVersion,DBFileVersion)<0)
				{
					cmd.CommandText = "SELECT FileData FROM " + TabName + " WHERE UPPER(Filename)='" + FileName + "'";				
					byte[] buffer = (byte[]) cmd.ExecuteScalar ();							
					Stream OutputStream = File.OpenWrite(Application.StartupPath + @"\tmpFileUpdate");
					OutputStream.Write(buffer,0,buffer.Length);
					OutputStream.Close();		
					File.Copy(Application.StartupPath + @"\" + FileName,Application.StartupPath + @"\BackupOf" + FileName,true);
					File.Copy(Application.StartupPath + @"\tmpFileUpdate",Application.StartupPath + @"\" + FileName,true);
					File.Delete(Application.StartupPath + @"\tmpFileUpdate");
				}				
			}
			catch (Exception ex)
			{
				MessageBox.Show("An error occured\n"+ex.Message,"Error");
			}
			finally
			{
				if (cmd != null) {cmd.Dispose();}				
			}
			return true;
		}
        private void Exec_Application(string ExeFileName)
        {
            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo();
            if (!File.Exists(Application.StartupPath + @"\" + ExeFileName))
            {
                MessageBox.Show("Khong tim thay file " + ExeFileName, "Thong bao");                
                return;
            }
            psi.FileName = ExeFileName;
            psi.Arguments = string.Format("/srv {0} /usr {1} /pas {2} /day {3:dd/MM/yyyy}", txtServerName.Text, glbUName, txtPass.Text, txtNgayLV.Value);
            System.Diagnostics.Process.Start(psi);
        }

	}
}
