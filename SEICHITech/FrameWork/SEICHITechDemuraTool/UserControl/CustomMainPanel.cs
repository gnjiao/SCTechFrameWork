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
using System.IO;
using AlgoriCtrlLib;
using RaydiumCtrlLib;
using CamerCtrlLib;

namespace SEICHITechDemuraTool
{
    public partial class CustomMainPanel : UserControl, IlogPrinter
    {
        public Dictionary<string, string> PGInfoDic;
        public const string DataPath = "./Data/";
        public static Recipe SelectModelRecipe = null;
        public static ViewWorksVA47M Camera;
        public static int PicIndex = 0;
        public string SelectPGIP;
        public string SelectCamIP;
        public int SelectCamPort;
        public ISZPG ManualPgObj;
        public IAxisCard ControlCardObj;
        public HighPassStyle SelectHighPass;
        public Context context;
        public AxisCard SelectAxis;

        public int RedColor;
        public int GreenColor;
        public int BlueColor;

        public DelegateShowLog ShowLog { get; set; }

        public CustomMainPanel(DelegateShowLog printlog)
        {
            InitializeComponent();
            this.ShowLog = printlog;
            context = Context.GetInstance();
        }

        #region 方法

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

        public void ShowPanelAction(object Sender, EventArgs e)
        {
            TrackBar ctrlinfo = Sender as TrackBar;

            if (ctrlinfo.Name.Contains("Red"))
            {
                RedColor = Convert.ToInt32(ctrlinfo.Value);
            }
            else if (ctrlinfo.Name.Contains("Green"))
            {
                GreenColor = Convert.ToInt32(ctrlinfo.Value);
            }
            else
            {
                BlueColor = Convert.ToInt32(ctrlinfo.Value);
            }
            Color color = Color.FromArgb(RedColor, GreenColor, BlueColor);
            this.ShowPanel.BackColor = color;
        }

        public void BindShowEvent()
        {
            this.RedTrbar.ValueChanged += (sender, e) =>
             {
                 Control ctrl = sender as Control;
                 ShowPanelAction(ctrl, e);
             };
            this.GreenTrbar.ValueChanged += (sender, e) =>
            {
                Control ctrl = sender as Control;
                ShowPanelAction(ctrl, e);
            };
            this.BlueTrbar.ValueChanged += (sender, e) =>
            {
                Control ctrl = sender as Control;
                ShowPanelAction(ctrl, e);
            };
            this.SyCheckBox.Checked = true;
        }

        public void SetPatternPic(object sender, int index)
        {
            Task.Run(() =>
            {
                Button btn = sender as Button;
                try
                {
                    this.Invoke(new Action(() => { btn.Enabled = false; }));
                    int Res = ManualPgObj.SetPattern(index);
                    if (Res == 0)
                    {
                        ShowLog($"图片序号：{index}-设置成功！", WriteLogType.Action);
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    this.Invoke(new Action(() => { btn.Enabled = true; }));
                }
            });
        }

        public string FileDialog(string Context)
        {
            string FilePath = "";
            OpenFileDialog filediag = new OpenFileDialog();
            filediag.Filter = Context;
            filediag.ValidateNames = true;
            filediag.CheckPathExists = true;
            filediag.CheckFileExists = true;
            if (filediag.ShowDialog() == DialogResult.OK)
            {
                FilePath = Path.GetFullPath(filediag.FileName);
            }
            else
            {
                FilePath = "";
            }
            return FilePath;
        }

        #endregion 方法

        #region 事件

        private void CustomMainPanel_Load(object sender, EventArgs e)
        {
            PGInfoDic = new Dictionary<string, string>();

            if (!Directory.Exists(DataPath))
            {
                Directory.CreateDirectory(DataPath);
            }

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

            //string FtpIP = @"ftp://" + SelectPGIP + "/";
            //string FilePath = IniHelper.GetIniString("PGFTP", "FilePath", "./Config.ini");
            //string UserName = IniHelper.GetIniString("PGFTP", "UserName", "./Config.ini");
            //string PassWord = IniHelper.GetIniString("PGFTP", "PassWord", "./Config.ini");
            //List<string> PgInfoLs = FTPDataHelper.GetFileNameFromFtp(FtpIP, FilePath, UserName, PassWord, ".lua", 47);
            //if (PgInfoLs.Count > 0)
            //{
            //    foreach (var item in PgInfoLs)
            //    {
            //        this.PGModelComBox.Items.Add(item);
            //    }
            //    this.PGModelComBox.SelectedIndex = 0;
            //}

            #endregion PG Model

            BindShowEvent();
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
                Button btn = sender as Button;
                try
                {
                    btn.Invoke(new Action(() => { btn.Enabled = false; }));
                    int Res = ManualPgObj.PowerOn();
                    if (Res != 0)
                    {
                        ShowLog("上电失败！", WriteLogType.Error);
                    }
                    else
                    {
                        ShowLog("上电成功！", WriteLogType.Action);
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    btn.Invoke(new Action(() => { btn.Enabled = true; }));
                }
            });
        }

        private void PowerOffBtn_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                Button btn = sender as Button;
                try
                {
                    btn.Invoke(new Action(() => { btn.Enabled = false; }));
                    int Res = ManualPgObj.PowerOff();
                    if (Res != 0)
                    {
                        ShowLog("下电失败！", WriteLogType.Error);
                    }
                    else
                    {
                        ShowLog("下电成功！", WriteLogType.Action);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    btn.Invoke(new Action(() => { btn.Enabled = true; }));
                }
            });
        }

        private void ReadFlsIDBtn_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                Button btn = sender as Button;
                try
                {
                    btn.Invoke(new Action(() => { btn.Enabled = false; }));
                    int Flashid = 0;
                    int Res = ManualPgObj.ReadFlashID(out Flashid);
                    if (Res != 0)
                    {
                        ShowLog("读取到的Flash ID 失败！", WriteLogType.Error);
                    }
                    else
                    {
                        ShowLog($"读取到的Flash ID:{Flashid}", WriteLogType.Action);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    btn.Invoke(new Action(() => { btn.Enabled = true; }));
                }
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
                Button btn = sender as Button;
                try
                {
                    btn.Invoke(new Action(() => { btn.Enabled = false; }));
                    Res = ManualPgObj.ReadCheckSum(ref nCheckSumVa);
                    if (Res == 0)
                    {
                        ShowLog($"获取到CheckSum :{nCheckSumVa}!", WriteLogType.Action);
                    }
                    else
                    {
                        ShowLog($"获取CheckSum值失败！", WriteLogType.Error);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    btn.Invoke(new Action(() => { btn.Enabled = true; }));
                }
            });
        }

        private void EraseFlsBtn_Click(object sender, EventArgs e)
        {
            int Res;
            var Result = MessageBox.Show("确定要擦除IC中的Flash?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (Result != DialogResult.OK) return;

            Task.Run(() =>
            {
                Button btn = sender as Button;
                try
                {
                    btn.Invoke(new Action(() => { btn.Enabled = false; }));
                    Res = ManualPgObj.EraseFlash();
                    if (Res != 0)
                    {
                        ShowLog($"擦除Flash完成！", WriteLogType.Action);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    btn.Invoke(new Action(() => { btn.Enabled = true; }));
                }
            });
        }

        private void WriteFlashbtn_Click(object sender, EventArgs e)
        {
            string FilePath = "";
            int Res = 0;
            FilePath = FileDialog("Hex文件|*.hex|所有文件|*.*");
            if (FilePath == "") return;
            Task.Run(() =>
            {
                Button btn = sender as Button;
                try
                {
                    btn.Invoke(new Action(() => { btn.Enabled = false; }));
                    Res = ManualPgObj.WriteFlash(FilePath);
                    if (Res == 0)
                    {
                        ShowLog($"数据{FilePath}写入成功", WriteLogType.Action);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    btn.Invoke(new Action(() => { btn.Enabled = true; }));
                }
            });
        }

        private void SyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.RedTrbar.DataBindings.Clear();
            this.GreenTrbar.DataBindings.Clear();
            this.BlueTrbar.DataBindings.Clear();
            this.RedNumeric.DataBindings.Clear();
            this.GreenNumeric.DataBindings.Clear();
            this.BlueNumeric.DataBindings.Clear();

            if (this.SyCheckBox.Checked)
            {
                this.RedTrbar.DataBindings.Add(new Binding("Value", this.RedNumeric, "Value"));
                this.RedNumeric.DataBindings.Add(new Binding("Value", this.GreenTrbar, "Value"));

                this.GreenTrbar.DataBindings.Add(new Binding("Value", this.GreenNumeric, "Value"));
                this.GreenNumeric.DataBindings.Add(new Binding("Value", this.BlueTrbar, "Value"));

                this.BlueTrbar.DataBindings.Add(new Binding("Value", this.BlueNumeric, "Value"));
                this.BlueNumeric.DataBindings.Add(new Binding("Value", this.RedTrbar, "Value"));
            }
            else
            {
                this.RedTrbar.DataBindings.Add(new Binding("Value", this.RedNumeric, "Value"));
                this.RedNumeric.DataBindings.Add(new Binding("Value", this.RedTrbar, "Value"));

                this.GreenTrbar.DataBindings.Add(new Binding("Value", this.GreenNumeric, "Value"));
                this.GreenNumeric.DataBindings.Add(new Binding("Value", this.GreenTrbar, "Value"));

                this.BlueTrbar.DataBindings.Add(new Binding("Value", this.BlueNumeric, "Value"));
                this.BlueNumeric.DataBindings.Add(new Binding("Value", this.BlueTrbar, "Value"));
            }
        }

        private void ShowRGBBtn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Task.Run(() =>
            {
                try
                {
                    btn.Invoke(new Action(() => { btn.Enabled = false; }));
                    int Res = ManualPgObj.SetRaster((byte)RedColor, (byte)GreenColor, (byte)BlueColor);
                    if (Res == 0)
                    {
                        ShowLog($"R:{RedColor} G:{GreenColor} B:{BlueColor}", WriteLogType.Action);
                    }
                    else
                    {
                        ShowLog("设置RGB颜色失败！！", WriteLogType.Error);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    btn.Invoke(new Action(() => { btn.Enabled = true; }));
                }
            });
        }

        private void BeforePicBtn_Click(object sender, EventArgs e)
        {
            if (PicIndex >= 0) PicIndex--;
            SetPatternPic(sender, PicIndex);
        }

        private void AfterPicBtn_Click(object sender, EventArgs e)
        {
            PicIndex++;
            SetPatternPic(sender, PicIndex);
        }

        private void CreatePicBtn_Click(object sender, EventArgs e)
        {
            Pattern SelectPicInfo = null;
            string FilePath = FileDialog("图片|*.bmp|所有文件|*.*");
            if (FilePath == "") return;
            string FileName = Path.GetFileName(FilePath);
            foreach (Pattern patnInfo in SelectModelRecipe.PatternArray)
            {
                if (FileName.Contains(patnInfo.Color) && FileName.Contains(patnInfo.Gary.ToString()))
                {
                    SelectPicInfo = patnInfo;
                    break;
                }
            }
            string ErrorMessage = "";
            StringBuilder sbPicPath = new StringBuilder(FilePath);
            StringBuilder CsvPicPath = new StringBuilder(FilePath.Replace(".bmp", ".csv"));
            if (this.shold1txtBox.Text == "" || this.shold2txtBox.Text == "" || this.shold3txtBox.Text == "")
            {
                MessageBox.Show("输入的数据不能为空！！");
                return;
            }
            int Threshold1 = Convert.ToInt32(this.shold1txtBox.Text);
            int Threshold2 = Convert.ToInt32(this.shold2txtBox.Text);
            int Threshold3 = Convert.ToInt32(this.shold3txtBox.Text);
            double t1 = 0, t2 = 0, t3 = 0;
            float muraNum = 0;
            float mThreshold1 = 0.4F;
            float mThreshold2 = 0.05F;
            Task.Run(() =>
            {
                Button btn = sender as Button;
                try
                {
                    btn.Invoke(new Action(() => { btn.Enabled = false; }));
                    int Res = ImgProc.ImageProc(sbPicPath, CsvPicPath, SelectPicInfo.Size, Threshold1, Threshold2,
                                    Threshold3, SelectPicInfo.Threshold4, SelectModelRecipe.Width, SelectModelRecipe.Height,
                                    SelectPicInfo.OffsetH, SelectPicInfo.OffsetW, SelectPicInfo.Scale, true, true, true, ref t1,
                                    ref t2, ref t3, 100, ref muraNum, mThreshold1, mThreshold2);
                    ErrorMessage = ImgProc.GetErrorInfo((ImgProErrorCode)Res);
                    MessageBox.Show(ErrorMessage);
                    if (Res != (int)ImgProErrorCode.ImageError_Success)
                    {
                        ShowLog(ErrorMessage, WriteLogType.Error);
                    }
                    else
                    {
                        ShowLog(ErrorMessage, WriteLogType.Action);
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
                finally
                {
                    btn.Invoke(new Action(() => { btn.Enabled = true; }));
                }
            });
        }

        private void CreateCSVBtn_Click(object sender, EventArgs e)
        {
            //部分变量暂时是通过写死的方式；
            Button btn = sender as Button;
            try
            {
                int Threshold1 = 40;
                int Threshold2 = 100;
                int Threshold3 = 50;
                string FilePath = "";
                string Sufix = "";
                btn.Enabled = false;
                eRadErr RadRes = eRadErr.OK;
                if (this.murasholdbox1.Text == "" || this.murasholdbox2.Text == "")
                {
                    MessageBox.Show("请设置MuraThreshold参数！");
                    return;
                }
                if (SelectHighPass == null)
                {
                    MessageBox.Show("请选择高通滤波数据生成方式！");
                    return;
                }
                float mThreshold1 = Convert.ToSingle(this.murasholdbox1.Text);
                float mThreshold2 = Convert.ToSingle(this.murasholdbox2.Text);

                List<Task> Taskls = new List<Task>();
                FolderBrowserDialog folder = new FolderBrowserDialog();
                folder.Description = "选择所有文件存放的目录";
                if (folder.ShowDialog() == DialogResult.OK)
                {
                    FilePath = folder.SelectedPath;
                }
                foreach (Pattern patinfo in SelectModelRecipe.PatternArray)
                {
                    string ImgPath = "";
                    double t1 = 0, t2 = 0, t3 = 0;
                    float muraNum = 0;
                    switch (patinfo.Color)
                    {
                        case "R":
                            ImgPath = $"{FilePath}\\Red{patinfo.Gary}.bmp";
                            break;

                        case "B":
                            ImgPath = $"{FilePath}\\blue{patinfo.Gary}.bmp";
                            break;

                        case "G":
                            ImgPath = $"{FilePath}\\Green{patinfo.Gary}.bmp";
                            break;

                        default:
                            break;
                    }
                    if (!File.Exists(ImgPath))
                    {
                        MessageBox.Show(ImgPath);
                        return;
                    }
                    StringBuilder SbImgPath = new StringBuilder(ImgPath);
                    StringBuilder SbCsvPath = new StringBuilder(ImgPath.Replace(".bmp", ".csv").Trim());
                    Taskls.Add(Task.Factory.StartNew(() =>
                    {
                        int Res = ImgProc.ImageProc(SbImgPath, SbCsvPath, patinfo.Size, Threshold1, Threshold2, Threshold3,
                                                patinfo.Threshold4, SelectModelRecipe.Width, SelectModelRecipe.Height,
                                                patinfo.OffsetH, patinfo.OffsetW, patinfo.Scale, true, true, true, ref t1,
                                                ref t2, ref t3, 100, ref muraNum, mThreshold1, mThreshold2);
                        string ResMsg = ImgProc.GetErrorInfo((ImgProErrorCode)Res);
                        if (Res == (int)ImgProErrorCode.ImageError_Success)
                        {
                            ShowLog($"{Path.GetFileName(ImgPath)} Result:{ResMsg}", WriteLogType.Action);
                        }
                        else
                        {
                            ShowLog($"{Path.GetFileName(ImgPath)} Result:{ResMsg}", WriteLogType.Error);
                        }
                    }));
                }

                Task.WaitAll(Taskls.ToArray());

                switch (SelectHighPass)
                {
                    case HighPassStyle.Open:
                        Sufix = $"_HighPass_{50}";
                        RadRes = RaydiumAPI.DoCreateBin(FilePath, "./DMR_CFG.rad", Sufix);
                        break;

                    case HighPassStyle.Close:
                        Sufix = "";
                        RadRes = RaydiumAPI.DoCreateBin(FilePath, "./DMR_CFG.rad", Sufix);
                        break;

                    case HighPassStyle.ClsAndSaveOpData:
                        Sufix = "";
                        RadRes = RaydiumAPI.DoCreateBin(FilePath, "./DMR_CFG.rad", Sufix);
                        Sufix = $"_HighPass_{50}";
                        RaydiumAPI.DoCreateBin(FilePath, "./DMR_CFG.rad", Sufix);
                        break;

                    case HighPassStyle.OpAndSaveClsData:
                        Sufix = $"_HighPass_{50}";
                        RadRes = RaydiumAPI.DoCreateBin(FilePath, "./DMR_CFG.rad", Sufix);
                        Sufix = "";
                        RaydiumAPI.DoCreateBin(FilePath, "./DMR_CFG.rad", Sufix);
                        break;

                    default:
                        break;
                }
                if (RadRes != eRadErr.OK)
                {
                    MessageBox.Show($"补偿数据生成失败！ErrorCode:{RadRes}");
                    return;
                }
                MessageBox.Show("Finished！");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                btn.Enabled = true;
            }
        }

        private void HighPassComBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Index = this.HighPassComBox.SelectedIndex;
            SelectHighPass = (HighPassStyle)Index;
        }

        private void CreateRaybtn_Click(object sender, EventArgs e)
        {
            string DataNow = DateTime.Now.ToString("yyyyMMddhhmmss");
            string PanelID = $"SCDESAM{DataNow}";
            Task.Run(() =>
            {
                Button btn = sender as Button;
                try
                {
                    this.Invoke(new Action(() => { btn.Enabled = false; }));
                    RaydiumAPI.SetCSVDataPath(DataPath);
                    RaydiumAPI.SetPanelID(PanelID);
                    eRadErr RayErr = RaydiumAPI.DoCreateBin();
                    RayErr = RaydiumAPI.DoCreateBin(true);
                    if (RayErr != eRadErr.OK)
                    {
                        string msg = RaydiumAPI.GetErrorStr(RayErr);
                        MessageBox.Show(msg);
                        ShowLog(msg, WriteLogType.Error);
                        return;
                    }
                    int CheckSum = RaydiumAPI.ReadFileChecksum(PanelID);
                    ShowLog($"生成补偿数据，CheckSum:{CheckSum}", WriteLogType.Normal);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    this.Invoke(new Action(() => { btn.Enabled = true; }));
                }
            });
        }

        private void CreateBmpbtn_Click(object sender, EventArgs e)
        {
            string FileContext = "";
            float Scale = 1f;
            int CSVValue = 0;
            Button btn = sender as Button;
            Task.Run(() =>
            {
                try
                {
                    btn.Invoke(new Action(() => { btn.Enabled = false; }));
                    string FilePath = FileDialog("CSV文件|*.csv|所有文件|*.*");
                    string FileName = Path.GetFileName(FilePath);
                    string SavePath = FilePath.Replace(".csv", "") + DateTime.Now.ToString("yyyyMMddhhmm") + ".bmp";
                    if (!FilePath.EndsWith(".csv"))
                    {
                        MessageBox.Show("选择的文件的格式不符合要求！！");
                        return;
                    }
                    foreach (Pattern item in SelectModelRecipe.PatternArray)
                    {
                        if (FileName.Contains(item.Color) && FileName.Contains(item.Gary))
                        {
                            Scale = Convert.ToSingle(item.Scale);
                        }
                    }
                    using (StreamReader SR = new StreamReader(FilePath, Encoding.Default))
                    {
                        FileContext = SR.ReadToEnd();
                    }
                    string[] CsvData = FileContext.Split(new char[] { '\r', '\n', ',' }, StringSplitOptions.RemoveEmptyEntries);
                    byte[] DataBy = new byte[CsvData.Length];
                    for (int i = 0; i < CsvData.Length; i++)
                    {
                        CSVValue = Convert.ToInt32((Convert.ToSingle(CsvData[i]) / Scale) * 255);
                        DataBy[i] = BitConverter.GetBytes(CSVValue)[0];
                    }
                    Camera.GenerateGrayBmpFromData(SelectModelRecipe.Width, SelectModelRecipe.Height, DataBy, SavePath);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    btn.Invoke(new Action(() => { btn.Enabled = true; }));
                }
            });
        }

        #endregion 事件
    }

    public enum HighPassStyle
    {
        Open = 0,
        Close = 1,
        ClsAndSaveOpData,
        OpAndSaveClsData
    }
}