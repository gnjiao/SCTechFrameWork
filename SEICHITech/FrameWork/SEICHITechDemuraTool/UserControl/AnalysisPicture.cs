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
    public partial class AnalysisPicture : UserControl, IlogPrinter
    {
        public Form PhotoForm;
        public DelegateShowLog ShowLog { get; set; }

        public AnalysisPicture(DelegateShowLog printerLog)
        {
            InitializeComponent();
            this.ShowLog = printerLog;
        }

        private void AnalysisPicture_Load(object sender, EventArgs e)
        {
            PhotoForm = new Form();
            PhotoForm.ControlBox = false;
            PhotoForm.TopLevel = false;
            PhotoForm.FormBorderStyle = FormBorderStyle.None;
            PhotoForm.Parent = this.splitContainer1.Panel2;
            this.splitContainer1.Panel2.Controls.Add(PhotoForm);
            PhotoForm.Dock = DockStyle.Fill;
            PhotoForm.Show();
        }
    }
}