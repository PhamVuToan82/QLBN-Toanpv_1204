using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System;
using System.Windows.Forms;
using NamDinh_QLBN.Forms;
using System.Text;
using System.Drawing;
using System.IO;
using System.Net;
using System.Collections.Specialized;
//using System.Threading.Tasks;

namespace GlobalModuls
{
	/// <summary>
	/// Summary description for Global.
	/// </summary>
	
	public class Global
	{
		public static System.Data.SqlClient.SqlConnection ConnectSQL;	
		//public static System.Data.SqlClient.SqlConnection ConnectDanhMuc;
        public static string glbConnectionString;
		public static string MaDVSD;
		public static string glbServerName;
		public static string glbUName;
		public static string glbMaKhoaPhong;
		public static string glbTenKhoaPhong;
        public static string glbTenTatKhoaPhong;
		public static string glbKhoa_CapNhat;
        public static string gblNoiNgoai;
		public static byte glbNhom;
		public static Boolean LogInSuccess;
		public static DateTime NgayLV;
        public static string glbTenTruongKhoa;
		public static NamDinh_QLBN.Forms.frmWait fWait;
        public static C1.Win.C1FlexGrid.CellStyle gStyleFixed=null;
        public static C1.Win.C1FlexGrid.CellStyle gStyleSubtotal1;
        public static C1.Win.C1FlexGrid.CellStyle gStyleSubtotal2;
        public static C1.Win.C1FlexGrid.CellStyle gStyleSubtotal3;
        public static Form pWork;
        public static String glbDuoc = "NamDinh_Duoc";
        public static String glbNoiTru = "NamDinh_QLBN";
        public static String glbKhamBenh= "NamDinh_KhamBenh";
        public static String glbSysDB = "NamDinh_SysDB";
        public static String glbCLS = "NamDinh_CLS";
        public static String glbVienPhi = "NamDinh_VienPhi";
        public const double LuongCB = 1490000;//1210000;
        public static string Access_Token;
        public static string IDToken;
        public static string MaKetQua;
        public static string Mes;
        public static object password;
        public const string username = "36001_BV";
        public static DateTime GetNgayLV()
        {
            DateTime Ngay;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            if (GlobalModuls.Global.ConnectSQL.State == System.Data.ConnectionState.Closed)
            {
                GlobalModuls.Global.ConnectSQL.Open();
            }
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            SQLCmd.CommandText = "set dateformat dmy Select GetDate()";
            Ngay = (DateTime.Parse(SQLCmd.ExecuteScalar().ToString()));
            //GlobalModuls.Global.ConnectSQL.Close();
            return Ngay;
            //dr.Close();
        }
		public static string InputBox(string caption, string m,string defaultvalue)
		{
			NamDinh_QLBN.Forms.frmInput fr = new NamDinh_QLBN.Forms.frmInput();
			fr.Text=caption;
			fr.Mes=m; 
			fr.defaultValue=defaultvalue;
			fr.ShowDialog();
			return(fr.TextReturn);
		}
		public static void SetCmb(C1.Win.C1List.C1Combo cmb,string itemvalue)
		{		
			cmb.SelectedIndex  = cmb.FindStringExact(itemvalue, 0, 0);	
		}
        public static void SetCmb_Display(C1.Win.C1List.C1Combo cmb, string itemvalue)
        {
            cmb.SelectedIndex = cmb.FindStringExact(itemvalue, 0, 1);
        }

		public static string UpperFirstChar(string strIn)
		{
			int i=0;
			string tmpStr="";
			if (strIn.Length==0) {return "";}
			Boolean IsBlank=false;			
			tmpStr=strIn[0].ToString().ToUpper();
			for (i=1;i<strIn.Length;i++)
			{
				if (IsBlank)
				{
					tmpStr=tmpStr + strIn[i].ToString().ToUpper();
					IsBlank=false;
				}
				else
				{
					tmpStr=tmpStr + strIn[i].ToString().ToLower();
				}
				if (strIn[i].ToString() == " " | strIn[i].ToString() == "\n" | strIn[i].ToString() == ".") 
				{IsBlank=true;}
			}
			return tmpStr;
		}
		public static string ConvertDate(string dateIn)
		{
			string tmp="";
			switch (dateIn.Substring(3,2))
			{
				case "01": 
					tmp="Jan";
					break;
				case "02": 
					tmp="Feb";
					break;
				case "03": 
					tmp="Mar";
					break;
				case "04": 
					tmp="Apr";
					break;
				case "05": 
					tmp="May";
					break;
				case "06": 
					tmp="Jun";
					break;
				case "07": 
					tmp="Jul";
					break;
				case "08": 
					tmp="Aug";
					break;
				case "09": 
					tmp="Sep";
					break;
				case "10": 
					tmp="Oct";
					break;
				case "11":
					tmp="Nov";
					break;
				case "12": 
					tmp="Dec";
					break;
				default:
					return "";
			}
			if ((Int16.Parse(dateIn.Substring(0,2)) <1) | ( Int16.Parse(dateIn.Substring(0,2)) > DateTime.DaysInMonth( Int16.Parse(dateIn.Substring(6)),Int16.Parse(dateIn.Substring(3,2)))))
			{
				return "";
			}
			tmp = string.Format("{0}/{1}/{2}",tmp,dateIn.Substring(0,2),dateIn.Substring(6));			
			return tmp;
		}
		public static string GetCode(C1.Win.C1List.C1Combo cmb)
		{
			string tmp;
			tmp=cmb.Columns[0].CellText(cmb.SelectedIndex);
			if (tmp == "")
			{tmp=null;}
			return tmp;
		}
        //public static void ShowReport(DataDynamics.ActiveReports.ActiveReport3 rpt,System.Data.DataSet ds,System.Data.DataTable dt,Form mform)
        //{
        //    try
        //    {
        //        // Make the sure the connection string point to the correct file location.               
               
        //        rpt.DataMember=dt.TableName;				
        //        rpt.Run();
        //        // Create a new instance of the viewer form, pass document and parent form:
        //        NamDinh_QLBN.Forms.PreviewForm viewerForm = new PreviewForm (rpt.Document, mform);
        //        viewerForm.Show();

        //        //rpt.Run(true);
        //    }
        //    catch(System.Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //    finally
        //    {
		
        //    }
        //}
		
		public static void wait(string msg)
		{
			if (fWait != null)
			{
				fWait.Dispose();
			}
			fWait = new NamDinh_QLBN.Forms.frmWait(msg);			
			fWait.Show();			
			fWait.Refresh();
			Application.DoEvents();
		}
		public static void nowait()
		{
			if (fWait != null)
			{
				fWait.Dispose();
			}
		}
		public static string EncryptPass(string pass)
		{
			string tmpS="";
			if (pass == "")
			{
				tmpS = "0" + char.GetNumericValue(string.Format("{0}"," "),0);				
			}
			else
			{
			}
			return tmpS;
		}
        public static int GetIDComboList(string[] arCmb, string item)
        {
            int i = 0;
            for (i = 1; i < arCmb.GetLength(0); i++)
            {
                if (arCmb[i] == item) return i;
            }
            return 0;
        }        
		public static string WriteNum(Int64 num)
		{
			byte i;
			long sochia,T1,T2,T3;
			long luu;
			string st="";
			string[] hang;
			string[] donvi; 
			hang = new string[10];
			hang[0] = "";
			hang[1] = " một";
			hang[2] = " hai";
			hang[3] = " ba";
			hang[4] = " bốn";
			hang[5] = " năm";
			hang[6] = " sáu";
			hang[7] = " bảy";
			hang[8] = " tám";
			hang[9] = " chín";
			donvi = new string[4];			
			donvi[0]=" tỉ";
			donvi[1]=" triệu";
			donvi[2]=" nghìn";			
			donvi[3]="";
			sochia = 1000000000;
			
			for (i=0;i<4;i++)
			{
				luu = num;
				luu = luu / sochia % 1000;
				T1 = luu / 100;
				T2 = luu / 10 % 10;
				T3 = luu % 10;
				if (T1==0 && T2==0 && T3==0)
				{
					sochia=sochia / 1000;
				}
				else
				{
					if (T1 == 0 && st != "") {st = st + " không";}
					st = st + hang[T1];
					if (st != "") {st = st + " trăm";}
					if (T2 != 0)
					{
						if (T2 == 1)
						{
							st = st + " mười";
							if (T3 != 5) {st = st + hang[T3];}
							if (T3 == 5) {st = st + " lăm";}
						}
						else
						{
							st = st + hang[T2] + " mươi";
							if (T3 != 1 && T3 != 5) {st = st + hang[T3];}
							if (T3 == 1 && T2 > 1) {st = st + " mốt";}
							if (T3 == 5) {st = st + " lăm";}
						}
					}
					else
					{
						if (T3 != 0 && st != "") {st = st + " linh";}
						st = st + hang[T3];
					}
					
					if (st != "") {st = st + donvi[i];}
					sochia=sochia / 1000;
				}
			}
            st = st.Trim();
             string Kytudau = st.Substring(0, 1).ToUpper();
             string CacKytusau = st.Substring(1 );
             //st = Kytudau + CacKytusau+".";
             st = Kytudau + CacKytusau; 
			return st;
		}
		public static void Set_Combo_Fileds(C1.Win.C1List.C1Combo cmb,string TabName,string F1Name,string F2Name)
		{
			System.Data.SqlClient.SqlDataReader dr;
			System.Data.SqlClient.SqlCommand SQLCmd= new System.Data.SqlClient.SqlCommand();
			SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
			SQLCmd.CommandText  = string.Format("SELECT {0},{1} FROM {2}",F1Name,F2Name,TabName);
			dr=SQLCmd.ExecuteReader();
			cmb.Tag ="0";
			cmb.ClearItems();
			while (dr.Read())
			{
				cmb.AddItem(string.Format("{0};{1}",dr[F1Name],dr[F2Name]));
			}
			dr.Close();
			cmb.SelectedIndex = -1;
			cmb.Tag ="1";			
			SQLCmd.Dispose();
		}
        public static int GetLanChuyenDTHT(string MaVaoVien)
        {
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            SQLCmd.CommandText = string.Format("Select MaxLan as LanChuyenDT From ViewDOITUONGHIENTAI where MaVaoVien ='{0}'",MaVaoVien);
            dr = SQLCmd.ExecuteReader();
            int LanChuyen = 0;
            if (dr.Read())
            {
                LanChuyen = int.Parse(dr["LanChuyenDT"].ToString());
            }
            dr.Close();
            return LanChuyen;
        }

        public static int GetLanChuyenKhoaHT(string MaVaoVien)
        {
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            SQLCmd.CommandText = string.Format("SELECT MaxLan FROM ViewKHOAHIENTAI vk where MaVaoVien ='{0}' and MaKhoa = '"+ GlobalModuls.Global.glbMaKhoaPhong +"'", MaVaoVien);
            dr = SQLCmd.ExecuteReader();
            int LanChuyen = 0;
            if (dr.Read())
            {
                LanChuyen = int.Parse(dr["MaxLan"].ToString());
            }
            dr.Close();
            return LanChuyen;
        }

        public static int GetLanChuyenKhoaHT_BC(string MaVaoVien,string Makhoa)
        {
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            SQLCmd.CommandText = string.Format("SELECT Max(lanchuyenkhoa) as lanchuyenkhoa FROM BENHNHAN_KHOA vk where MaVaoVien ='{0}' and MaKhoa = '" + Makhoa + "'", MaVaoVien);
            dr = SQLCmd.ExecuteReader();
            int LanChuyen = 0;
            if (dr.Read())
            {
                LanChuyen = int.Parse(dr["lanchuyenkhoa"].ToString());
            }
            dr.Close();
            return LanChuyen;
        }
        public static long IsNumeric(string Num)
		{
			try
			{
				return(long.Parse(Num));
			}
			catch
			{
				return(-1);
			}
		}
        public static  void SetGridStyles(C1.Win.C1FlexGrid.C1FlexGrid fg)
        {
            C1.Win.C1FlexGrid.CellStyle s = fg.Styles.Fixed;
            s.BackColor = gStyleFixed.BackColor;
            s.Font = gStyleFixed.Font;
            s.ForeColor = gStyleFixed.ForeColor;
            s=fg.Styles["Subtotal1"];
            s.BackColor = gStyleSubtotal1.BackColor ;
            s.Font = gStyleSubtotal1.Font;
            s.ForeColor = gStyleSubtotal1.ForeColor;
            s=fg.Styles["Subtotal2"];
            s.BackColor = gStyleSubtotal2.BackColor ;
            s.Font = gStyleSubtotal2.Font;
            s.ForeColor = gStyleSubtotal2.ForeColor;
            s=fg.Styles["Subtotal3"];
            s.BackColor = gStyleSubtotal3.BackColor ;
            s.Font = gStyleSubtotal3.Font;
            s.ForeColor = gStyleSubtotal3.ForeColor;
        }
        public static void DefaultGridStyle()
        {
            C1.Win.C1FlexGrid.C1FlexGrid fg = new C1.Win.C1FlexGrid.C1FlexGrid();
            C1.Win.C1FlexGrid.CellStyle s = fg.Styles.Fixed;
            s.BackColor = System.Drawing.Color.LemonChiffon;
            s.ForeColor = System.Drawing.Color.Black;
            gStyleFixed = s;
            s = fg.Styles["SubTotal1"];
            s.BackColor = System.Drawing.Color.LightSkyBlue;
            gStyleSubtotal1 = s;
            s = fg.Styles["SubTotal2"];
            s.BackColor = System.Drawing.Color.LightCyan;
            gStyleSubtotal2 = s;
            s = fg.Styles["SubTotal3"];
            s.BackColor = System.Drawing.Color.White;
            gStyleSubtotal3 = s;
            fg.Dispose();
        }
        public static void InitApplication(string UName)
        {
            if (Load_GridConfig(UName) == -1)
            { Global.DefaultGridStyle(); }            
        }
        public static int Load_GridConfig(string Uname)
        {
            if (gStyleFixed == null) { DefaultGridStyle(); }
            System.Data.SqlClient.SqlDataReader dr;
            System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();
            SQLCmd.Connection = GlobalModuls.Global.ConnectSQL;
            SQLCmd.CommandText = "SELECT * FROM CONFIGS WHERE UName='" + Uname + "' AND ConfigName IN ('Fixed','Subtotal1','Subtotal2','Subtotal3') ORDER BY IDs";
            dr = SQLCmd.ExecuteReader();
            try
            {
                Font f = null;
                string FontFamily = "";
                float FontSize = 9;
                bool FontBold = false;
                if (dr.HasRows)
                {
                    //Fixed style
                    dr.Read();
                    Global.gStyleFixed.BackColor = Color.FromArgb(int.Parse(dr["ConfigValue"].ToString()));
                    dr.Read();
                    Global.gStyleFixed.ForeColor = Color.FromArgb(int.Parse(dr["ConfigValue"].ToString()));
                    dr.Read();
                    FontFamily = dr["ConfigValue"].ToString();
                    dr.Read();
                    FontSize = float.Parse(dr["ConfigValue"].ToString());
                    dr.Read();
                    FontBold = bool.Parse(dr["ConfigValue"].ToString());
                    f = new Font(FontFamily, FontSize, (FontBold) ? (FontStyle.Bold) : (FontStyle.Regular));
                    Global.gStyleFixed.Font = f;
                    //Subtotal1 style
                    dr.Read();
                    Global.gStyleSubtotal1.BackColor = Color.FromArgb(int.Parse(dr["ConfigValue"].ToString()));
                    dr.Read();
                    Global.gStyleSubtotal1.ForeColor = Color.FromArgb(int.Parse(dr["ConfigValue"].ToString()));
                    dr.Read();
                    FontFamily = dr["ConfigValue"].ToString();
                    dr.Read();
                    FontSize = float.Parse(dr["ConfigValue"].ToString());
                    dr.Read();
                    FontBold = bool.Parse(dr["ConfigValue"].ToString());
                    f = new Font(FontFamily, FontSize, (FontBold) ? (FontStyle.Bold) : (FontStyle.Regular));
                    Global.gStyleSubtotal1.Font = f;
                    //Subtotal2 style
                    dr.Read();
                    Global.gStyleSubtotal2.BackColor = Color.FromArgb(int.Parse(dr["ConfigValue"].ToString()));
                    dr.Read();
                    Global.gStyleSubtotal2.ForeColor = Color.FromArgb(int.Parse(dr["ConfigValue"].ToString()));
                    dr.Read();
                    FontFamily = dr["ConfigValue"].ToString();
                    dr.Read();
                    FontSize = float.Parse(dr["ConfigValue"].ToString());
                    dr.Read();
                    FontBold = bool.Parse(dr["ConfigValue"].ToString());
                    f = new Font(FontFamily, FontSize, (FontBold) ? (FontStyle.Bold) : (FontStyle.Regular));
                    Global.gStyleSubtotal2.Font = f;
                    //Subtotal3 style
                    dr.Read();
                    Global.gStyleSubtotal3.BackColor = Color.FromArgb(int.Parse(dr["ConfigValue"].ToString()));
                    dr.Read();
                    Global.gStyleSubtotal3.ForeColor = Color.FromArgb(int.Parse(dr["ConfigValue"].ToString()));
                    dr.Read();
                    FontFamily = dr["ConfigValue"].ToString();
                    dr.Read();
                    FontSize = float.Parse(dr["ConfigValue"].ToString());
                    dr.Read();
                    FontBold = bool.Parse(dr["ConfigValue"].ToString());
                    f = new Font(FontFamily, FontSize, (FontBold) ? (FontStyle.Bold) : (FontStyle.Regular));
                    Global.gStyleSubtotal3.Font = f;
                    return (1);
                }
                else
                {
                    return (-1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không đọc được cấu hình grid!\n" + ex.Message + " Bạn hãy vào chức năng [Công cụ]/[Tùy chọn]/[Hiển thị] để thiết lập cấu hình grid", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return (-1);
            }
            finally
            {
                dr.Close();
                SQLCmd.Dispose();
            }
        }
        public static string  UpperFirstChar1(string s)
        {
            if (s.Trim().Length < 1) return s;
            return s.Trim().Substring(0, 1).ToUpper() + s.Trim().Substring(1, s.Trim().Length - 1);

        }
        public static bool UpdateFile(string FileName, System.Data.SqlClient.SqlConnection ConnectSQL)
        {
            string TabName = "[NAMDINH_SYSDB].DBO.APPLICATION_FILES";
            bool FileExists = true;
            string DBFileVersion = "";
            System.Data.SqlClient.SqlCommand cmd = null;
            try
            {
                if (!File.Exists(Application.StartupPath + @"\" + FileName))
                {
                    MessageBox.Show("Khong tim thay file " + FileName, "Thong bao");
                    FileExists = false;
                }
                string FileVersion = "";
                if (FileExists)
                {
                    FileVersion = System.Diagnostics.FileVersionInfo.GetVersionInfo(Application.StartupPath + @"\" + FileName).FileVersion;
                }
                System.Data.SqlClient.SqlDataReader dr;
                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.Connection = ConnectSQL;
                cmd.CommandText = "SELECT FileVersion FROM " + TabName + " WHERE UPPER(FileName)='" + FileName + "'";
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    DBFileVersion = dr["FileVersion"].ToString();
                }
                dr.Close();
                if (string.Compare(FileVersion, DBFileVersion) < 0)
                {
                    cmd.CommandText = "SELECT FileData FROM " + TabName + " WHERE UPPER(Filename)='" + FileName + "'";
                    byte[] buffer = (byte[])cmd.ExecuteScalar();
                    Stream OutputStream = File.OpenWrite(Application.StartupPath + @"\tmpFileUpdate");
                    OutputStream.Write(buffer, 0, buffer.Length);
                    OutputStream.Close();
                    if (FileExists) File.Copy(Application.StartupPath + @"\" + FileName, Application.StartupPath + @"\BackupOf" + FileName, true);
                    File.Copy(Application.StartupPath + @"\tmpFileUpdate", Application.StartupPath + @"\" + FileName, true);
                    File.Delete(Application.StartupPath + @"\tmpFileUpdate");
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("An error occured\n" + ex.Message, "Error");
            }
            finally
            {
                if (cmd != null) { cmd.Dispose(); }
            }
            return true;
        }
        public static void BindDataReaderToFlex(System.Data.SqlClient.SqlDataReader myReader, C1.Win.C1FlexGrid.C1FlexGrid _flex)
        {
            try
            {
                System.Data.DataTable dt = myReader.GetSchemaTable();
                _flex.Cols.Count = _flex.Cols.Fixed;
                foreach (System.Data.DataRow dr in dt.Rows)
                {
                    C1.Win.C1FlexGrid.Column c = _flex.Cols.Add();
                    c.Caption = c.Name = (string)dr["ColumnName"];
                    c.DataType = (Type)dr["DataType"];
                    switch (c.DataType.Name)
                    {
                        case "DateTime":
                            c.Format = "dd/MM/yyyy";
                            break;
                        case "Int32":
                        case "Double":
                        case "Numeric":
                            c.Format = "#,##0";
                            break;
                        case "Decimal":
                            c.Format = "#,##0.##";
                            break;
                    }
                }

                // populate grid
                _flex.DataSource = null;
                _flex.Rows.Count = 1;
                int row = 1;
                _flex.Redraw = false;

                // method 1
                while (myReader.Read())
                {
                    _flex.Rows.Add();
                    for (int i = 0; i < myReader.FieldCount; i++)
                        _flex[row, i + 1] = myReader.GetValue(i);
                    row++;
                }
                _flex.AutoSizeCols(0, _flex.Cols.Count - 1, 1);
                _flex.Redraw = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static void GetSession()
        {
                WebClient client = new WebClient();
                NameValueCollection values = new NameValueCollection();
                values.Add("username", "36001_BV");
                values.Add("password", "e10adc3949ba59abbe56e057f20f883e");

                byte[] bytes = client.UploadValues("https://egw.baohiemxahoi.gov.vn/api/token/take", values);
                string str = Encoding.UTF8.GetString(bytes);
                string[] separator = new string[] { "\"maKetQua\"", "\"APIKey\"", "\"access_token\"", "\"id_token\"", "\"token_type\"" };
                string[] strArray2 = str.Split(separator, StringSplitOptions.None);
                MaKetQua = strArray2[1].Substring(2, 3);
                if (MaKetQua == "200")
                {
                    Access_Token = strArray2[3].Substring(0, strArray2[3].Length - 2).Substring(2, strArray2[3].Length - 4);
                    IDToken = strArray2[4].Substring(0, strArray2[4].Length - 2).Substring(2, strArray2[4].Length - 4);
                    //ses = true;
                }
        }
        public string ConvertHexStrToUnicode(string hexString)
        {
            int length = hexString.Length;
            byte[] bytes = new byte[length / 2];

            for (int i = 0; i < length; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hexString.Substring(i, 2), 16);
            }
            return Encoding.UTF8.GetString(bytes);
        }

    }
}
