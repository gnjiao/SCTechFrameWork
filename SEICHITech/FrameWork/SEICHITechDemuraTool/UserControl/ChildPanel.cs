using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;
using Model;

namespace SEICHITechDemuraTool
{
    public partial class ChildPanel : UserControl
    {
        #region Test for Processbar

        private MyProgressBar cp;
        private Label l;
        private int panelindex;

        #endregion Test for Processbar

        private ShowLog showlog;
        private DelegateShowLog OutPutLog;

        public ChildPanel(int Num)
        {
            InitializeComponent();

            panelindex = Num;
            showlog = new ShowLog(this.LogrichTextBox);
            OutPutLog = showlog.OutputLog;
            string StartModel = Context.GetInstance().GeneralInformation.TestStartModel;
            StartModelType modeltype = (StartModelType)(Enum.Parse(typeof(StartModelType), StartModel));
            UpdataPanelInfo(modeltype);


        }

        private void UpdataPanelInfo(StartModelType ModelType)
        {
            switch (ModelType)
            {
                case StartModelType.AutoWithoutRead:
                    this.SNtxtBox.Visible = false;
                    this.StartBtn.Visible = false;
                    this.LocationLb.TextAlign = ContentAlignment.MiddleCenter;
                    this.LocationLb.Text = $"Station [{panelindex}]:Auto Test No PanelID";
                    break;

                case StartModelType.AutoReadByScan:
                    this.SNtxtBox.Visible = true;
                    this.StartBtn.Visible = true;
                    break;

                default:
                    break;
            }
        }

        private void EndLogPrint()
        {
            string LogfileName = Context.GetInstance().GeneralInformation.Name + "_" + panelindex + "_" + Context.GetInstance().GeneralInformation.StationName + "_Pass_";
            ToolLogWrite caseLogWrite = new ToolLogWrite(true, LogfileName);
            StringBuilder strbuild = new StringBuilder();
            strbuild.AppendLine(this.LogrichTextBox.Text);
            caseLogWrite.WriteLog(strbuild.ToString());
            caseLogWrite.CloseLogFile();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string data = DateTime.Now.ToString();
            if (this.StartBtn.Text == "开始")
            {
                this.StartBtn.Text = "停止";

                //TestAction();

                OutPutLog($"[{data}]:开始测试！", WriteLogType.Normal);
                //this.timer1.Enabled = true;
            }
            else
            {
                this.StartBtn.Text = "开始";
                //this.timer1.Enabled = false;
                OutPutLog($"[{data}]:结束测试！", WriteLogType.Normal);
            }
            System.Threading.Thread.Sleep(1000);
            EndLogPrint();
        }

        //private void timer1_Tick(object sender, EventArgs e)
        //{
        //    if (cp.Value < cp.Maximum)
        //    {
        //        cp.Value++;
        //        l.Text = cp.Value.ToString() + "%";
        //    }
        //    else
        //    {
        //        this.timer1.Enabled = false;
        //    }
        //}

        //private void TestAction()
        //{
        //    cp = new MyProgressBar();
        //    cp.Parent = this.ChildpgrBar;
        //    cp.Value = 0;
        //    cp.Minimum = 0;
        //    cp.Maximum = 100;
        //    cp.Width = ChildpgrBar.Width;
        //    cp.Height = ChildpgrBar.Height;
        //    cp.BackColor = Color.Gray;
        //    l = new Label();
        //    l.Parent = cp;
        //    l.Font = new Font("Consolas", (float)10, FontStyle.Regular);
        //    l.BackColor = Color.Transparent;
        //    l.ForeColor = Color.Black;
        //    l.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        //    l.Width = cp.Width;
        //    l.Height = cp.Height;
        //}
    }

    public class MyProgressBar : ProgressBar
    {
        public MyProgressBar()
        {
            base.SetStyle(ControlStyles.UserPaint, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            SolidBrush brush = null;
            Rectangle bounds = new Rectangle(0, 0, base.Width, base.Height);
            bounds.Height -= 4;
            bounds.Width = ((int)(bounds.Width * (((double)base.Value) / ((double)base.Maximum)))) - 4;
            brush = new SolidBrush(Color.Green);
            e.Graphics.FillRectangle(brush, 2, 2, bounds.Width, bounds.Height);
            base.OnPaint(e);
        }
    }
}