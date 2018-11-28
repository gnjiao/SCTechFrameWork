using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
using Common;
using System.Reflection;
using SEICHITechDemuraTool.Properties;
using HardWareInterFaces;

namespace SEICHITechDemuraTool
{
    public partial class CustomModel : UserControl, IlogPrinter
    {
        public DelegateShowLog ShowLog { get; set; }

        private int FunctionCount;
        private FunctionModules FucModel;
        public Dictionary<Panel, string> CustomPanelInfoDic = new Dictionary<Panel, string>();

        public CustomModel()
        {
            InitializeComponent();
            FucModel = XMLSerializeHelper.DeserializeXML<FunctionModules>("./Configurations/ManualModelFunctionConfig.xml");
            FunctionCount = FucModel.SingleFunctionModule.Length;
        }

        private void SplitModel(int PanelCount)
        {
            for (int i = 0; i < FucModel.SingleFunctionModule.Length; i++)
            {
                Panel panel = new Panel();
                panel.BorderStyle = BorderStyle.None;

                Label panellab = new Label();
                panellab.Font = new Font("楷体", 15);
                panellab.ForeColor = Color.Black;
                panellab.Dock = DockStyle.Fill;
                panellab.TextAlign = ContentAlignment.MiddleCenter;
                panellab.Text = FucModel.SingleFunctionModule[i].Name;
                panellab.Click += (sender, e) =>
                {
                    Control ctrl = panellab.Parent;
                    Btn_ClickEvent(ctrl, e);
                };

                CustomPanelInfoDic[panel] = FucModel.SingleFunctionModule[i].LoadingPanel;
                panel.Controls.Add(panellab);
                panel.Click += new System.EventHandler(this.Btn_ClickEvent);

                flowLayoutPanel1.Controls.Add(panel);
                panellab.Dock = DockStyle.Fill;
            }
        }

        private void ScDemuraModel_Load(object sender, EventArgs e)
        {
            SplitModel(FunctionCount);
            foreach (Panel lab in CustomPanelInfoDic.Keys)
            {
                if (lab.Controls[0].Text == "操作界面")
                {
                    Btn_ClickEvent(lab, null);
                }
            }
        }

        private void Btn_ClickEvent(object sender, EventArgs e)
        {
            try
            {
                foreach (Panel SinglePanel in CustomPanelInfoDic.Keys)
                {
                    SinglePanel.BackColor = flowLayoutPanel1.BackColor;
                    SinglePanel.BorderStyle = BorderStyle.None;
                }
                this.splitContainer1.Panel2.Controls.Clear();
                Panel panelinfo = (Panel)sender;
                panelinfo.BackColor = Color.GreenYellow;
                panelinfo.BorderStyle = BorderStyle.Fixed3D;
                string PanelInfo = CustomPanelInfoDic[panelinfo];

                Assembly NewMenuMember = Assembly.GetExecutingAssembly();
                Type NewmenuTp = NewMenuMember.GetType(PanelInfo);
                object[] Paremter = new object[1];
                Paremter[0] = ShowLog;
                Control NewMenuAdd = (Control)Activator.CreateInstance(NewmenuTp, Paremter);

                this.splitContainer1.Panel2.Controls.Add(NewMenuAdd);
                NewMenuAdd.Dock = DockStyle.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}