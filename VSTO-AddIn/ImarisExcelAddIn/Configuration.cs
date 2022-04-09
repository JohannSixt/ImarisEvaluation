using ExcelAddIn1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImarisAddIn
{
    public partial class DlgSettings : Form
    {
        public DlgSettings()
        {
            InitializeComponent();

            this.Left = (int)((Globals.ThisAddIn.Application.Left - Globals.ThisAddIn.Application.Width) / 2 - this.Width / 2);
            Debug.Print(Globals.ThisAddIn.Application.Left + "/" + Globals.ThisAddIn.Application.Width);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
