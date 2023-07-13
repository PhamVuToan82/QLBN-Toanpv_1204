using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WinWordControl;

namespace NamDinh_QLBN
{
    public partial class frmHelp : Form
    {
        private string filename;
        public frmHelp(string FileName)
        {
            InitializeComponent();
            filename = FileName;
        }

        private void frmHelp_Shown(object sender, EventArgs e)
        {
            winWordControl1.LoadDocument(String.Format(@"{0}\{1}", Application.StartupPath, filename));
        }

        private void frmHelp_FormClosing(object sender, FormClosingEventArgs e)
        {
            winWordControl1.RestoreWord();
        }
    }
}