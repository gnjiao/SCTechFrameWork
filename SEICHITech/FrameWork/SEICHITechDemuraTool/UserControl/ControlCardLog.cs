using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEICHITechDemuraTool
{
    public partial class ControlCardLog : UserControl
    {
        public ControlCardLog()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.ctrcardbox.Text = string.Empty;
        }
    }
}