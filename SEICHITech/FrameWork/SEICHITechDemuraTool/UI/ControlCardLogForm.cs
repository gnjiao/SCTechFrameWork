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
    public partial class ControlCardLogForm : Form
    {
        public RichTextBox PrintLog;

        public ControlCardLogForm()
        {
            InitializeComponent();
            ControlCardLog LogPanel = new ControlCardLog();
            LogPanel.Dock = DockStyle.Fill;
            this.PrintLog = LogPanel.ctrcardbox;
            this.Controls.Add(LogPanel);
        }
    }
}