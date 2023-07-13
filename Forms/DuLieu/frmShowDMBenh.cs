using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using GlobalModuls;

namespace NamDinh_QLBN.Forms.DuLieu
{
	/// <summary>
	/// Summary description for frmShowDMBenh.
	/// </summary>
	public class frmShowDMBenh : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TreeView TreeHC;
		private System.Windows.Forms.Button cmdOK;
		private System.Windows.Forms.Button cmdCancel;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		public string TextReturn="";
		private C1.Win.C1FlexGrid.C1FlexGrid fg=null;
		public frmShowDMBenh(C1.Win.C1FlexGrid.C1FlexGrid _fg)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			fg= _fg;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmShowDMBenh));
			this.TreeHC = new System.Windows.Forms.TreeView();
			this.cmdOK = new System.Windows.Forms.Button();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// TreeHC
			// 
			this.TreeHC.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.TreeHC.FullRowSelect = true;
			this.TreeHC.HideSelection = false;
			this.TreeHC.HotTracking = true;
			this.TreeHC.ImageIndex = -1;
			this.TreeHC.Location = new System.Drawing.Point(0, 0);
			this.TreeHC.Name = "TreeHC";
			this.TreeHC.SelectedImageIndex = -1;
			this.TreeHC.Size = new System.Drawing.Size(291, 333);
			this.TreeHC.TabIndex = 12;
			this.TreeHC.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeHC_AfterSelect);
			// 
			// cmdOK
			// 
			this.cmdOK.Enabled = false;
			this.cmdOK.Image = ((System.Drawing.Image)(resources.GetObject("cmdOK.Image")));
			this.cmdOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.cmdOK.Location = new System.Drawing.Point(147, 336);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.Size = new System.Drawing.Size(69, 27);
			this.cmdOK.TabIndex = 13;
			this.cmdOK.Text = "  Chọn";
			this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
			// 
			// cmdCancel
			// 
			this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancel.Image = ((System.Drawing.Image)(resources.GetObject("cmdCancel.Image")));
			this.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.cmdCancel.Location = new System.Drawing.Point(219, 336);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.Size = new System.Drawing.Size(69, 27);
			this.cmdCancel.TabIndex = 14;
			this.cmdCancel.Text = " Thoát";
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
			// 
			// frmShowDMBenh
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 366);
			this.Controls.Add(this.cmdOK);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.TreeHC);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmShowDMBenh";
			this.Text = "Danh mục bệnh";
			this.Load += new System.EventHandler(this.frmShowDMBenh_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmShowDMBenh_Load(object sender, System.EventArgs e)
		{
			System.Data.SqlClient.SqlDataReader dr;			
			System.Data.SqlClient.SqlCommand SQLCmd = new System.Data.SqlClient.SqlCommand();

			TreeNode mnode,ParentNode = new TreeNode(),ParentNode1 = new TreeNode();
			TreeHC.Tag ="0";
			SQLCmd.Connection=Global.ConnectSQL; 
			TreeHC.Nodes.Clear();		
			
			SQLCmd.CommandText = "SELECT MaBenh,TenBenh FROM DMBENH";
			dr = SQLCmd.ExecuteReader();
				
			while (dr.Read())
			{
				mnode = new TreeNode(string.Format ("[{0}]-{1}", dr.GetString(0), dr.GetString(1)));
				mnode.Tag  = dr.GetString(0);
				switch (dr.GetString(0).Length)
				{
					case 2:
						mnode.ForeColor=System.Drawing.Color.Blue;
						ParentNode=mnode;
						TreeHC.Nodes.Add(mnode);
						break;
					case 4:
						ParentNode.Nodes.Add(mnode);
						ParentNode1=mnode;
						break;
					case 6:
						ParentNode1.Nodes.Add(mnode);						
						break;				
				}				
			}
			dr.Close();
			TreeHC.Tag ="1";
			SQLCmd.Dispose();
		}

		private void TreeHC_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			if (TreeHC.SelectedNode.Tag.ToString().Length != 6) 
			{cmdOK.Enabled = false;}
			else
			{cmdOK.Enabled = true;}
		}

		private void cmdCancel_Click(object sender, System.EventArgs e)
		{
			TextReturn="";
			this.Dispose();
		}

		private void cmdOK_Click(object sender, System.EventArgs e)
		{
			//TextReturn = TreeHC.SelectedNode.Tag.ToString() + "|" + TreeHC.SelectedNode.Text;
			//this.Dispose();
			for (int i=1;i<fg.Rows.Count;i++)
			{
				if (TreeHC.SelectedNode.Tag.ToString() == fg.GetDataDisplay(i,1))
				{
					return;
				}
			}
			fg.AddItem(string.Format("{0}|{1}|{2}",fg.Rows.Count,TreeHC.SelectedNode.Tag.ToString(),TreeHC.SelectedNode.Text.Substring(TreeHC.SelectedNode.Text.IndexOf("]-")+1)));
		}
	}
}
