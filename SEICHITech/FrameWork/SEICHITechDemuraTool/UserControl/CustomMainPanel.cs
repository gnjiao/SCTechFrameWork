#define Debug

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
using HardWareInterFaces;
using Common;
using System.Reflection;
using System.Threading;

namespace SEICHITechDemuraTool
{
    public partial class CustomMainPanel : UserControl, IlogPrinter
    {
        public Dictionary<string, string> PGInfoDic;
        public static Recipe SelectModelRecipe = null;
        public string SelectPGIP;
        public string SelectCamIP;
        public int SelectCamPort;
        public ISZPG ManualPgObj;
        public IAxisCard ControlCardObj;
        public Context context;
        public AxisCard SelectAxis;
        public DelegateShowLog ShowLog { get; set; }

        public CustomMainPanel(DelegateShowLog printlog)
        {
            InitializeComponent();
            this.ShowLog = printlog;
            context = Context.GetInstance();
        }

        public void ManualMoveAction(int Distance)
        {
            if (this.MoveDistxtBox.Text == null)
            {
                MessageBox.Show("请输入有效运动脉冲数！");
                return;
            }
            int MoveDis = Math.Abs(Convert.ToInt32(this.MoveDistxtBox.Text)) * -1;
            ControlCardObj.PMove(SelectAxis, MoveDis, ProFileType.T_Profile);
            this.Invoke(new Action(delegate { this.CurPulstxtbox.Text = ControlCardObj.GetPosition(SelectAxis).ToString(); }));
            uint Iostatus = ControlCardObj.CheckIOStatus(SelectAxis);

            if ((Iostatus & (0x01)) == 1)
            {
                MessageBox.Show($"{SelectAxis.Name}-已经到达正极限！");
                this.Invoke(new Action(delegate { this.UpMoveBtn.Enabled = false; }));
            }
            else if ((Iostatus & (0x01 << 1)) == 1)
            {
                MessageBox.Show($"{SelectAxis.Name}-已经到达负极限！");
                this.Invoke(new Action(delegate { this.DownMoveBtn.Enabled = false; }));
            }
            else
            {
                this.Invoke(new Action(delegate { this.UpMoveBtn.Enabled = true; }));
                this.Invoke(new Action(delegate { this.DownMoveBtn.Enabled = true; }));
            }
            UpdataAxisData();
        }

        public void UpdataAxisData()
        {
            int Post = ControlCardObj.GetPosition(SelectAxis);
            double PreMM = Post / SelectAxis.PreMMPulse;
            this.Invoke(new Action(delegate { this.CurDistxtBox.Text = PreMM + "/mm"; }));
            this.Invoke(new Action(delegate { this.CurPulstxtbox.Text = Post + "/Pulse"; }));
        }

        private void CustomMainPanel_Load(object sender, EventArgs e)
        {
            PGInfoDic = new Dictionary<string, string>();

            #region PG

            foreach (CameraConfig SingleCamCfg in Context.GetInstance().SlaveServerConfig.CameraConfig)
            {
                string KeyName = SingleCamCfg.Name;

                string KeyNamePGP = KeyName + "_PG_P";
                PGInfoDic[KeyNamePGP] = SingleCamCfg.CameraIP + "|" + SingleCamCfg.PG_P_IP + "|" + SingleCamCfg.CameraPort;
                this.pgcomBox.Items.Add(KeyNamePGP);

                string KeyNamePGS = KeyName + "_PG_S";
                PGInfoDic[KeyNamePGS] = SingleCamCfg.CameraIP + "|" + SingleCamCfg.PG_P_IP + "|" + SingleCamCfg.CameraPort;
                this.pgcomBox.Items.Add(KeyNamePGS);
            }
            this.pgcomBox.SelectedIndex = 0;

            #endregion PG

            #region Recipe

            foreach (Recipe recipe in Context.GetInstance().ModuleRecipe)
            {
                this.RecipeCombox.Items.Add(recipe.Name);
            }
            this.RecipeCombox.SelectedIndex = 0;

            #endregion Recipe

            #region Axis Info

            foreach (AxisCard item in context.ControlCard.AxisCard)
            {
                this.AxisInfoCombox.Items.Add(item.Name);
            }
            this.AxisInfoCombox.SelectedIndex = 0;

            #endregion Axis Info

            #region PG Model

            string FtpIP = @"ftp://" + SelectPGIP + "/";
            string FilePath = IniHelper.GetIniString("PGFTP", "FilePath", "./Config.ini");
            string UserName = IniHelper.GetIniString("PGFTP", "UserName", "./Config.ini");
            string PassWord = IniHelper.GetIniString("PGFTP", "PassWord", "./Config.ini");
            List<string> PgInfoLs = FTPDataHelper.GetFileNameFromFtp(FtpIP, FilePath, UserName, PassWord, ".lua", 47);
            foreach (var item in PgInfoLs)
            {
                this.PGModelComBox.Items.Add(item);
            }
            this.PGModelComBox.SelectedIndex = 0;

            #endregion PG Model
        }

        private void pgcomBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string[] CmbInfomation = PGInfoDic[this.pgcomBox.SelectedItem.ToString()].Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                SelectCamIP = CmbInfomation[0];
                SelectPGIP = CmbInfomation[1];
                SelectCamPort = Convert.ToInt32(CmbInfomation[2]);
                this.camIpLb.Text = $"Camare: {SelectCamIP}";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void PGCntBtn_Click(object sender, EventArgs e)
        {
            if (ManualPgObj == null)
            {
                string[] RefeClassInfo = context.SlaveServerConfig.MethodInfo.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                object[] Paramter = new object[2];
                Paramter[0] = SelectPGIP;
                Paramter[1] = 1600;

                Assembly Assemb = Assembly.LoadFrom(RefeClassInfo[0]);
                Type AssembTp = Assemb.GetType(RefeClassInfo[1]);

                ManualPgObj = (ISZPG)Activator.CreateInstance(AssembTp, Paramter[0], Paramter[1]);
            }
            if (this.PGCntBtn.Text == "连接")
            {
                this.PGCntBtn.Text = "断开";
                if (ManualPgObj.Init())
                {
                    ShowLog($"{SelectPGIP}手动初始化成功！", WriteLogType.Action);
                }
                else
                {
                    ShowLog($"{SelectPGIP}手动初始化失败！", WriteLogType.Error);
                }
            }
            else
            {
                this.PGCntBtn.Text = "连接";
                if (ManualPgObj.Exit() == 0)
                {
                    ShowLog($"{SelectPGIP}手动退出成功！", WriteLogType.Action);
                }
                else
                {
                    ShowLog($"{SelectPGIP}手动退出失败！", WriteLogType.Error);
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectItem = this.RecipeCombox.SelectedItem.ToString();
            Recipe[] ModelRecipe = Context.GetInstance().ModuleRecipe.Where(t => t.Name == selectItem).ToArray();
            SelectModelRecipe = ModelRecipe[0];
        }

        private void CamOpenBtn_Click(object sender, EventArgs e)
        {
        }

        private void PGModelComBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string SelectPgCode = this.PGModelComBox.SelectedItem.ToString();
                Task.Run(() =>
                {
                    ManualPgObj.PowerOff();
                    Thread.Sleep(500);
                    ManualPgObj.PowerOn();
                    Thread.Sleep(200);
                    ManualPgObj.ChangeModule(SelectPgCode, SelectPgCode.Length);
                });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void AxisInfoCombox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string SelectAxis = this.AxisInfoCombox.SelectedItem.ToString();
            foreach (AxisCard selecAixs in context.ControlCard.AxisCard)
            {
                if (selecAixs.Name == SelectAxis)
                {
                    this.SelectAxis = selecAixs;
                    break;
                }
            }
#if Debug

#endif
        }

        private void UpMoveBtn_Click(object sender, EventArgs e)
        {
            int MoveDis = Math.Abs(Convert.ToInt32(this.MoveDistxtBox.Text));
            Task.Run(() => { ManualMoveAction(MoveDis); });
        }

        private void DownMoveBtn_Click(object sender, EventArgs e)
        {
            int MoveDis = Math.Abs(Convert.ToInt32(this.MoveDistxtBox.Text)) * -1;
            Task.Run(() => { ManualMoveAction(MoveDis); });
        }

        private void HomeBackBtn_Click(object sender, EventArgs e)
        {
            int FindCondition = 0;
            int LocalPosition = ControlCardObj.GetPosition(SelectAxis);
            if (LocalPosition == 0)
            {
                MessageBox.Show($"{SelectAxis.Name}-已在原点位置！");
                return;
            }
            if (LocalPosition < 0)
            {
                FindCondition = 1;
            }
            Task.Run(() =>
            {
                ControlCardObj.HomeMove(SelectAxis, FindCondition);
                UpdataAxisData();
            });
        }

        private void AxisStopBtn_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                ControlCardObj.AxisStop(SelectAxis, AxisStopType.EmgStop);
                UpdataAxisData();
            });
        }

        private void PowerOnBtn_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                int Res = ManualPgObj.PowerOn();
                if (Res != 0)
                {
                    ShowLog("上电失败！", WriteLogType.Error);
                }
                else
                {
                    ShowLog("上电成功！", WriteLogType.Action);
                }
            });
        }

        private void PowerOffBtn_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                int Res = ManualPgObj.PowerOff();
                if (Res != 0)
                {
                    ShowLog("下电失败！", WriteLogType.Error);
                }
                else
                {
                    ShowLog("下电成功！", WriteLogType.Action);
                }
            });
        }

        private void ReadFlsIDBtn_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                int Flashid = 0;
                int Res = ManualPgObj.ReadFlashID(out Flashid);
                if (Res != 0)
                {
                    ShowLog("读取到的Flash ID 失败！", WriteLogType.Error);
                }
                ShowLog($"读取到的Flash ID:{Flashid}", WriteLogType.Action);
            });
        }

        private void DMRFuncBtn_Click(object sender, EventArgs e)
        {
            int Res;
            if (this.DMRFuncBtn.Text.Contains("On"))
            {
                this.DMRFuncBtn.Text = "Demura Off";
                Task.Run(() =>
                {
                    Res = ManualPgObj.DeMuraFunctionSwitch(true);
                    if (Res == 0)
                    {
                        ShowLog("Demura效果已开启！", WriteLogType.Action);
                    }
                });
            }
            else
            {
                this.DMRFuncBtn.Text = "Demura On";
                Task.Run(() =>
                {
                    Res = ManualPgObj.DeMuraFunctionSwitch(false);
                    if (Res == 0)
                    {
                        ShowLog("Demura效果已关闭！", WriteLogType.Action);
                    }
                });
            }
        }

        private void ReadCheckSumBtn_Click(object sender, EventArgs e)
        {
            int Res;
            ushort nCheckSumVa = 0;
            Task.Run(() =>
            {
                Res = ManualPgObj.ReadCheckSum(ref nCheckSumVa);
                if (Res == 0)
                {
                    ShowLog($"获取到CheckSum :{nCheckSumVa}!", WriteLogType.Action);
                }
                else
                {
                    ShowLog($"获取CheckSum值失败！", WriteLogType.Error);
                }
            });
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
            });
        }
    }
}