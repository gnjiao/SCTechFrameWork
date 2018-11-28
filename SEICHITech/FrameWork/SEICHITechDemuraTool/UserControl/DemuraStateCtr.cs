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
    public partial class DemuraStateCtr : UserControl
    {
        private int PanelNo;

        public DemuraStateCtr(int PanelNum)
        {
            InitializeComponent();
            this.PanelNo = PanelNum;
            this.LbLogo.Text = $"Panel {PanelNum}";
        }
    }
}