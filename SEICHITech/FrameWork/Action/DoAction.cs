using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HardWareInterFaces;
using Common;
using System.IO;
using System.Reflection;
using Model;
using System.Threading;
using GifAnimation;
using KillWindow;

namespace WorkAction
{
    public class DoAction : IAction
    {
        private IAxisCard ControlcardObj = null;
        private IPGCtrl PGObj = null;
        private IDeMura DemuraObj = null;
        private Context context;
        public DelegateShowLog PrinterLog { get; set; }

        public bool PostAction()
        {
            throw new NotImplementedException();
        }

        public bool PreAction()
        {
            throw new NotImplementedException();
        }

        public void FixtureReset(AxisCard[] axisinfo)
        {
            List<Task> TaskLs = new List<Task>();
            string[] Testls = new string[] { "Test", "AnimationGif/Test.gif", "设备重置中..." };

            Task.Factory.StartNew(() => { GifRun.Main(Testls); });

            foreach (AxisCard axis in axisinfo)
            {
                ControlcardObj.InitialAxisConfig(axis, ProFileType.T_Profile);

                TaskLs.Add(Task.Factory.StartNew(() =>
                {
                    AxisReset(axis);
                }));
            }
            Task.WaitAll(TaskLs.ToArray());
            FindWindowToKill.killWindowInBackground("Test", 10);
            PrinterLog("设备启动完毕！", WriteLogType.Action);
        }

        public bool InitialHardWare()
        {
            context = Context.GetInstance();

            string[] AxisFilePath = context.ControlCard.ModuleInformation.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

            ControlcardObj = RefelectionHelper.CreatRefelectObj<IAxisCard>(AxisFilePath[0], AxisFilePath[1]);

            ControlcardObj.ShowLog = PrinterLog;

            if (!ControlcardObj.InitialAxisCard())
            {
                PrinterLog("初始化轴卡失败!!", WriteLogType.Error);
                return false;
            }

            PrinterLog("轴卡初始化成功!!", WriteLogType.Action);

            return true;
        }

        public bool AxisReset(AxisCard axiscard)
        {
            try
            {
                int Res = 999;
                int WaitTimes = 0;
                //Thread.Sleep(2000);
                PrinterLog($"{axiscard.Name}轴开始回原点....", WriteLogType.Action);

                //Different Control Card.The HomeMode will Change PCI9014 :1/Forward,0/Opposite  DMC2C80:1/Forward 2/Opposite;
                int LocalPosition = ControlcardObj.GetPosition(axiscard);

                if (Math.Abs(LocalPosition) <= axiscard.HomeBackDis)
                {
                    if (axiscard.HomeModel == 1)
                    {
                        axiscard.HomeModel *= -1;
                    }
                    Res = ControlcardObj.PMove(axiscard, axiscard.HomeBackDis, ProFileType.T_Profile);
                    //PCI9014:0/Free 1/working     DMC2C80:0/working 1/Free;
                    while (ControlcardObj.CheckAxisStatus(axiscard) == 1)
                    {
                        WaitTimes++;
                        if (WaitTimes == 300)
                        {
                            PrinterLog($"{axiscard.Name} 运动到 [{axiscard.HomeBackDis}]超时！", WriteLogType.Error);
                            return false;
                        }
                        Thread.Sleep(100);
                    }
                    LocalPosition = ControlcardObj.GetPosition(axiscard);
                    if (LocalPosition != axiscard.HomeBackDis)
                    {
                        PrinterLog($"{axiscard.Name} 未运动到指定位置:{axiscard.HomeBackDis}！", WriteLogType.Error);
                        return false;
                    }
                }
                WaitTimes = 0;
                Res = ControlcardObj.HomeMove(axiscard);
                while (ControlcardObj.CheckAxisStatus(axiscard) == 1)
                {
                    WaitTimes++;
                    if (WaitTimes == 300)
                    {
                        PrinterLog($"{axiscard.Name} 回原运动超时！", WriteLogType.Error);
                        return false;
                    }
                    Thread.Sleep(100);
                }
                LocalPosition = ControlcardObj.GetPosition(axiscard);
                if (LocalPosition != 0 || Res != 0)
                {
                    PrinterLog($"{axiscard.Name}回原运动后未到达原点位置，轴卡现在所在位置脉冲：{LocalPosition}", WriteLogType.Error);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                PrinterLog(ex.Message, WriteLogType.Error);
                throw new Exception(ex.Message);
            }
        }
    }
}