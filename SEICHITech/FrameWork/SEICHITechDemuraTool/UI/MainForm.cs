using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Model;
using HardWareInterFaces;
using Common;
using WorkAction;
using System.Reflection;
using SEICHITechDemuraTool.Properties;

namespace SEICHITechDemuraTool
{
    public partial class MainForm : Form
    {
        private IAction LoadFormAction;
        private ControlCards ControlCardInfomation;
        private SlaveServers CameraInfomation;
        private static int PanelCount;
        private ChildPanel SinglePanel;
        private ManualChildPanel manualpanel;
        private static CustomModel NewMenuAdd;

        public ShowLog showlog;

        private bool LogState = true;
        private bool DmrState = true;
        private Context context = null;
        private static DmrInfoForm dmrform = null;
        private static ControlCardLogForm controlform = null;
        private const string XMLFolderPath = "./Configurations/";

        public MainForm()
        {
            InitializeComponent();
            context = Context.GetInstance();

            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

            //this.skinEngine1.SkinFile = context.GeneralInformation.FormSkin;

            this.UpdataFormInformation();

            LoadConfiguration(context.GeneralInformation);

            this.UpdataChildPanel();
        }

        #region 方法

        private void UpdataFormInformation()
        {
            this.StationNametxtBox.Text = context.GeneralInformation.StationName;
            this.VertxtBox.Text = context.GeneralInformation.Version;
        }

        private void UpdataChildPanel()
        {
            PanelCount = Convert.ToInt32(context.GeneralInformation.PanelStationCount);

            AutoSplitContainer atspliter = new AutoSplitContainer(PanelCount);
            this.MainsplitContainer.Panel2.Controls.Add(atspliter);
            atspliter.Dock = DockStyle.Fill;
            for (int i = 0; i < PanelCount; i++)
            {
                SinglePanel = new ChildPanel(i + 1);
                atspliter.LsSplitChildPanel[i].Controls.Add(SinglePanel);
                SinglePanel.Dock = DockStyle.Fill;
            }
        }

        private void LoadConfiguration(ModelGeneralInformation ModelConfiguration)
        {
            try
            {
                string CtrlCardPath = XMLFolderPath + ModelConfiguration.ControlCardFileName;
                ControlCardInfomation = XMLSerializeHelper.DeserializeXML<ControlCards>(CtrlCardPath);
                context.ControlCard = ControlCardInfomation;

                string CameraCfgPath = XMLFolderPath + ModelConfiguration.CameraConfigFileName;
                CameraInfomation = XMLSerializeHelper.DeserializeXML<SlaveServers>(CameraCfgPath);
                context.SlaveServerConfig = CameraInfomation;

                string RecipePath = XMLFolderPath + ModelConfiguration.ModelRecipeFileName;
                Recipes RecipeInfomation = XMLSerializeHelper.DeserializeXML<Recipes>(RecipePath);
                context.ModuleRecipe = RecipeInfomation.RecipeArray;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void LoadNewModulesToMenuItem(string ModulesInfo)
        {
            string[] RefInfo = ModulesInfo.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            ToolStripMenuItem NewMenuItem = new ToolStripMenuItem();
            NewMenuItem.Text = RefInfo[0];
            NewMenuItem.Click += this.AddNewMenu_Click;
            this.ManualTestMenu.DropDownItems.Add(NewMenuItem);
        }

        #endregion 方法

        #region 事件

        private void AddNewMenu_Click(object sender, EventArgs e)
        {
            this.MainsplitContainer.Panel2.Controls.Clear();
            if (NewMenuAdd == null)
            {
                NewMenuAdd = new CustomModel();
            }
            this.MainsplitContainer.Panel2.Controls.Add(NewMenuAdd);
            NewMenuAdd.Dock = DockStyle.Fill;
            this.Show();
        }

        private void btnaxisLog_Click(object sender, EventArgs e)
        {
            if (controlform == null)
            {
                controlform = new ControlCardLogForm();
                controlform.TopMost = true;
                controlform.Location = new Point(SystemInformation.WorkingArea.Width - controlform.Width, 0);
                controlform.StartPosition = FormStartPosition.Manual;
            }
            if (LogState)
            {
                controlform.Show();
                LogState = false;
            }
            else
            {
                //controlform.Close();
                controlform.Hide();
                LogState = true;
            }
        }

        private void BtnDmrSer_Click(object sender, EventArgs e)
        {
            if (dmrform == null)
            {
                dmrform = new DmrInfoForm();
                dmrform.TopMost = true;
            }
            if (DmrState)
            {
                dmrform.Show();
                DmrState = false;
            }
            else
            {
                dmrform.Hide();
                DmrState = true;
            }
        }

        private void MaunalModelMenuItem_Click(object sender, EventArgs e)
        {
            this.MainsplitContainer.Panel2.Controls.Clear();
            manualpanel = new ManualChildPanel();
            this.MainsplitContainer.Panel2.Controls.Add(manualpanel);
            manualpanel.Dock = DockStyle.Fill;
            this.Show();
        }

        private void AutoManualMenuItem_Click(object sender, EventArgs e)
        {
            this.MainsplitContainer.Panel2.Controls.Clear();
            this.UpdataFormInformation();
            this.UpdataChildPanel();
            this.Show();
        }

        private void ProjSetMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadNewModulesToMenuItem(context.GeneralInformation.AddNewModules);

            controlform = new ControlCardLogForm();
            showlog = new ShowLog(controlform.PrintLog);

            string[] ActionFileName = context.GeneralInformation.ActionFileName.Split('|');
            LoadFormAction = RefelectionHelper.CreatRefelectObj<IAction>(ActionFileName[0], ActionFileName[1]);

            LoadFormAction.PrinterLog = showlog.OutputLog;

            LoadFormAction.InitialHardWare();

            Task.Run(() => { LoadFormAction.FixtureReset(ControlCardInfomation.AxisCard); });
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void AutoMenuItem_Click(object sender, EventArgs e)
        {
            this.MainsplitContainer.Panel2.Controls.Clear();
            this.UpdataFormInformation();
            this.UpdataChildPanel();
            this.Show();
        }

        private void ManualMenuItem_Click(object sender, EventArgs e)
        {
            this.MainsplitContainer.Panel2.Controls.Clear();
            if (NewMenuAdd == null)
            {
                NewMenuAdd = new CustomModel();
                NewMenuAdd.ShowLog = showlog.OutputLog;
            }
            this.MainsplitContainer.Panel2.Controls.Add(NewMenuAdd);
            NewMenuAdd.Dock = DockStyle.Fill;
            this.Show();
        }

        #endregion 事件
    }
}