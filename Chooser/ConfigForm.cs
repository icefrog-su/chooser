using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Chooser
{
    public partial class ConfigForm : Form
    {
        public ConfigForm()
        {
            InitializeComponent();
        }

        private void ConfigForm_Load(object sender, EventArgs e)
        {
            for (double d = 0.01; d < 1; d += 0.02)
            {
                System.Threading.Thread.Sleep(1);
                Application.DoEvents();
                this.Opacity = d;
                this.Refresh();
            }
        }
    }
}
