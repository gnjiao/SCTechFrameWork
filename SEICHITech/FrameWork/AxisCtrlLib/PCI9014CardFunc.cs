using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;
using Model;
using System.Threading;
using HardWareInterFaces;

namespace AxisCtrlLib
{
    public class PCI9014CardFunc : IAxisCard, IlogPrinter
    {
        public DelegateShowLog ShowLog { get; set; }

        public int AxisCard_ReadInBit(int CardNo, int BitNo)
        {
            uint IOSignal = 0;
            int Res = CPci9014.p9014_get_di_bit(CardNo, (uint)BitNo, ref IOSignal);
            if (Res != 0) return -1;
            return (int)IOSignal;
        }

        public int AxisCard_WriteOutBit(int CardNo, int BitNo, uint Data)
        {
            return CPci9014.p9014_set_do_bit(CardNo, (uint)BitNo, Data);
        }

        public int AxisStop(AxisCard axisinfo, AxisStopType StopType)
        {
            return CPci9014.p9014_stop(axisinfo.Num, (int)StopType);
        }

        public int CheckAxisStatus(AxisCard axisinfo)
        {
            uint AxisStatus = 999;
            int Res = CPci9014.p9014_get_motion_status(axisinfo.Num, ref AxisStatus);
            if (Res != 0) return 2;
            return (int)AxisStatus;
        }

        public uint CheckIOStatus(AxisCard axisinfo)
        {
            uint IOStatus = 0;
            int Res = CPci9014.p9014_get_io_status(axisinfo.Num, ref IOStatus);
            if (Res != 0) return 2;
            return IOStatus;
        }

        public int GetPosition(AxisCard axisinfo)
        {
            int PositionPls = 0;
            int Res = CPci9014.p9014_get_pos(axisinfo.Num, 0, ref PositionPls);
            return PositionPls;
        }

        public int HomeMove(AxisCard axisinfo, int BackCondition = 0)
        {
            int time = 0;
            CPci9014.p9014_set_t_profile(axisinfo.Num, axisinfo.MinSpeed, axisinfo.MaxSpeed / 2, axisinfo.AccSpeed, axisinfo.DecSpeed);
            int Res = CPci9014.p9014_home_move(axisinfo.Num, BackCondition);
            if (Res != 0) return Res;
            while (time <= 100)
            {
                time++;
                if (CheckAxisStatus(axisinfo) == 0)
                {
                    break;
                }
            }
            return Res;
        }

        public bool InitialAxisCard()
        {
            try
            {
                int CardCount = 0;
                int[] Cardid = new int[16];
                int Res = CPci9014.p9014_initial(ref CardCount, Cardid);
                if (Res != 0)
                {
                    MessageBox.Show("PCI9014轴卡初始化失败！");
                    ShowLog("PCI9014控制卡初始化失败！", WriteLogType.Error);
                    return false;
                }
                if (CardCount <= 0)
                {
                    MessageBox.Show($"获取的轴卡数量为:{CardCount}！");
                    ShowLog($"获取到轴卡的数量为：{CardCount}", WriteLogType.Error);
                    return false;
                }
                ShowLog($"PCI9014控制卡初始化成功！控制卡数量：{CardCount}", WriteLogType.Normal);
                return true;
            }
            catch (Exception ex)
            {
                ShowLog(ex.Message, WriteLogType.Error);
                throw new Exception(ex.Message);
            }
        }

        public int PMove(AxisCard axisinfo, int MovePulse, ProFileType MoveStyle)
        {
            int Res = 0;
            int BefPosition = this.GetPosition(axisinfo);
            if (MoveStyle == ProFileType.T_Profile)
            {
                Res = CPci9014.p9014_set_t_profile(axisinfo.Num, axisinfo.MinSpeed, axisinfo.MaxSpeed, axisinfo.AccSpeed, axisinfo.DecSpeed);
            }
            else
            {
                Res = CPci9014.p9014_set_s_profile(axisinfo.Num, axisinfo.MinSpeed, axisinfo.MaxSpeed, axisinfo.AccSpeed, axisinfo.DecSpeed, 1);
            }
            Res = CPci9014.p9014_pmove(axisinfo.Num, MovePulse, axisinfo.MoveStyle, 2);
            if (Res != 0)
            {
                ShowLog($"{axisinfo.Name} 运动到脉冲距离:{MovePulse} 失败！", WriteLogType.Error);
                return 2;
            }
            while (true)
            {
                if (this.CheckAxisStatus(axisinfo) == 0)
                {
                    break;
                }
                Thread.Sleep(500);
            }
            int AfPosition = this.GetPosition(axisinfo);
            if (Math.Abs(AfPosition - BefPosition) - Math.Abs(MovePulse) > 1000)
            {
                ShowLog($"{axisinfo.Name}-实际运动脉冲数与目标运动脉冲数误差过大！！", WriteLogType.Error);
            }

            ShowLog($"{axisinfo.Name}-运动到脉冲距离:{MovePulse} 成功！", WriteLogType.Action);
            return Res;
        }

        public bool InitialAxisConfig(AxisCard axisinfo, ProFileType profiletype)
        {
            bool FuncResult = false;
            int Res;
            Res = CPci9014.p9014_set_alarm(axisinfo.Num, 0, 1);
            if (Res != 0)
            {
                ShowLog("设置对应 DI 为 ALARM 输入端失败！", WriteLogType.Error);
                return FuncResult;
            }
            Res = CPci9014.p9014_set_pls_outmode(axisinfo.Num, 0);
            if (Res != 0)
            {
                ShowLog("设置 OUT, DIR 引脚输出脉冲方式失败！", WriteLogType.Error);
                return FuncResult;
            }
            Res = CPci9014.p9014_set_pls_iptmode(axisinfo.Num, 0);
            if (Res != 0)
            {
                ShowLog("设置 OUT, DIR 引脚输出脉冲方式失败！", WriteLogType.Error);
                return FuncResult;
            }
            Res = CPci9014.p9014_set_el_level(axisinfo.Num, 0);
            if (Res != 0)
            {
                ShowLog("设定限位信号有效电平失败！", WriteLogType.Error);
                return FuncResult;
            }
            Res = CPci9014.p9014_home_config(axisinfo.Num, 0, 0, 0);
            if (Res != 0)
            {
                ShowLog("配置原点开关有效电平、编码器 index 信号有效电平、回零模式失败！", WriteLogType.Error);
                return FuncResult;
            }
            if (profiletype == ProFileType.T_Profile)
            {
                Res = CPci9014.p9014_set_t_profile(axisinfo.Num, axisinfo.MinSpeed, axisinfo.MaxSpeed, axisinfo.AccSpeed, axisinfo.DecSpeed);
                if (Res != 0)
                {
                    ShowLog("运动 T 曲线参数设定失败！", WriteLogType.Error);
                    return FuncResult;
                }
            }
            else
            {
                Res = CPci9014.p9014_set_s_profile(axisinfo.Num, axisinfo.MinSpeed, axisinfo.MaxSpeed, axisinfo.AccSpeed, axisinfo.DecSpeed, 1);
                if (Res != 0)
                {
                    ShowLog("运动 S 曲线参数设定失败！", WriteLogType.Error);
                    return FuncResult;
                }
            }

            FuncResult = true;
            return FuncResult;
        }
    }
}