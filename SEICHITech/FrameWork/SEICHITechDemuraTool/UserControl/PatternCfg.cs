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
    public partial class PatternCfg : UserControl
    {
        public static int RedColor = 0;
        public static int GreenColor = 0;
        public static int BlueColor = 0;

        public PatternCfg(string Value)
        {
            InitializeComponent();
            SetGroupBoxText(Value);
        }

        private void PatternCfg_Load(object sender, EventArgs e)
        {
            this.RedtxtBox.TextChanged += (Sender, b) =>
            {
                Control ctrl = (Control)Sender;
                ShowColor(ctrl, b);
            };
            this.GreentxtBox.TextChanged += (Sender, b) =>
            {
                Control ctrl = (Control)Sender;
                ShowColor(ctrl, b);
            };
            this.BluetxtBox.TextChanged += (Sender, b) =>
            {
                Control ctrl = (Control)Sender;
                ShowColor(ctrl, b);
            };
        }

        private void SetGroupBoxText(string Context)
        {
            this.ColorGrb.Text = Context;
        }

        private void ShowColor(object sender, EventArgs e)
        {
            Control ctrlinfo = (Control)sender;

            if (ctrlinfo.Name.Contains("Red"))
            {
                RedColor = Convert.ToInt32(ctrlinfo.Text);
            }
            else if (ctrlinfo.Name.Contains("Green"))
            {
                GreenColor = Convert.ToInt32(ctrlinfo.Text);
            }
            else
            {
                BlueColor = Convert.ToInt32(ctrlinfo.Text);
            }
            Color color = Color.FromArgb(RedColor, GreenColor, BlueColor);
            this.ColorPBox.BackColor = color;
        }
    }
}