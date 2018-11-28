using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEICHITechDemuraTool
{
    public partial class DmrInfoForm : Form
    {
        private DemuraStateCtr DmrChildPanel;

        public DmrInfoForm()
        {
            InitializeComponent();
        }

        private void DmrInfoForm_Load(object sender, EventArgs e)
        {
            int PanelCount = Convert.ToInt32(Context.GetInstance().GeneralInformation.PanelStationCount);
            AutoSplitContainer autospliter = new AutoSplitContainer(PanelCount);
            this.Controls.Add(autospliter);
            autospliter.Dock = DockStyle.Fill;
            for (int i = 0; i < PanelCount; i++)
            {
                DmrChildPanel = new DemuraStateCtr(i + 1);
                autospliter.LsSplitChildPanel[i].Controls.Add(DmrChildPanel);
                DmrChildPanel.Dock = DockStyle.Fill;
            }
        }
    }
}