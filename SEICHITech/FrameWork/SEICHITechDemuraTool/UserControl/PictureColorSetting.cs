using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HardWareInterFaces;
using Common;

namespace SEICHITechDemuraTool
{
    public partial class PictureColorSetting : UserControl, IlogPrinter
    {
        public int PatternNum;

        public DelegateShowLog ShowLog { get; set; }

        public PictureColorSetting(DelegateShowLog LogPrinter)
        {
            InitializeComponent();
            this.ShowLog = LogPrinter;
            for (int i = 1; i <= 32; i++)
            {
                this.PatternNumComb.Items.Add(i);
            }
            this.LoadPicInfo(6);
        }

        private void LoadPicInfo(int PatternNum)
        {
            PatternCfg PaCfg = null;
            for (int i = 1; i <= PatternNum; i++)
            {
                string str = "Pattern " + i;
                PaCfg = new PatternCfg(str);

                this.PicFlowPanel.Controls.Add(PaCfg);
            }
        }

        private void PatternNumComb_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.PicFlowPanel.Controls.Clear();
            PatternNum = Convert.ToInt32(this.PatternNumComb.Text);
            LoadPicInfo(PatternNum);
        }
    }
}