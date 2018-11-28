#define TestMode

using System;
using System.Collections.Generic;
using System.Text;
using Pci9014;
using System.Windows.Forms;
using System.Threading;

namespace SingleDemura
{
    /// <summary>
    /// 9014板卡
    /// </summary>
    ///
    public enum ErrorInfo
    {
        ErrorSucceed = 0,
        ErrorWarning,        //报警
        ErrorCmdExcuteFail,     //有指令没执行成功
        ErrorNotMoveToCorrectPos,   //运动完成误差太大
        ErrorWillOverstepBoundary,    //将会越界
    }

    public class PCI9014Board : AxisBase
    {
        /// <summary>
        /// 定义位号的属性
        /// </summary>
        public PCI9014Board()
        {
            arrayDI = new Boolean[16];
            arrayDO = new bool[16];
        }

        /// <summary>
        /// 关闭系统里面的所有的PCI9014
        /// </summary>
        /// <returns></returns>
        public override int Close()
        {
            return CPci9014.p9014_close();
        }

        /// <summary>
        /// 查找并初始化系统里面所有的 PCI-9014
        /// </summary>
        /// <returns></returns>
        public override int Init()
        {
            int rc;
            int boarkCount = 0;
            int[] card_id = new int[16];
            //初始化运动轴；
            rc = CPci9014.p9014_initial(ref boarkCount, card_id);
            if (rc != 0)
            {
                Log.GetInstance().ErrorWrite("Initialize PCI-9014 fail");

                return 1;
            }
            //PCI9014的数目；
            //boarkCount = 1;
            if (boarkCount < 1)
            {
                Log.GetInstance().ErrorWrite("Find No PCI-9014 device");
                return 1;
            }
            //获取运动轴的参数
            if (!GetParameter())
            {
                return 1;
            }
            else
            {
                Log.GetInstance().NormalWrite("获取运动轴参数成功！！");
            }
            foreach (var Axis in Global.LstAxis)
            {
                //设置运动参数
                //Alarm 0:低有效  1: 高有效
                rc &= CPci9014.p9014_set_alarm(Axis.No, 0, 1);

                //0:PULSE/DIR  1: CW/CCW
                rc &= CPci9014.p9014_set_pls_outmode(Axis.No, 0);

                //0:PULSE/DIR  1:4X AB
                rc &= CPci9014.p9014_set_pls_iptmode(Axis.No, 0);

                //EL Level 0:低有效  1: 高有效
                rc &= CPci9014.p9014_set_el_level(Axis.No, 0);

                //mode(0:ORG Only  1:ORG+EZ)
                //ORG Level(0:低有效  1: 高有效)
                //EZ  Level(0:低有效  1: 高有效)
                rc &= CPci9014.p9014_home_config(Axis.No, 0, 0, 0);

                //设置T Profile 下的速度，加速度等参数
                rc &= CPci9014.p9014_set_t_profile(Axis.No, Axis.startSpeed, Axis.maxSpeed, Axis.AccTime, Axis.DecTime);
            }
            //关闭所有输出
            SetAllOutBit(false);
            return rc;
        }

        /// <summary>
        /// 从项目设置文档中获取轴的加速度，位置等信息；
        /// </summary>
        /// <returns></returns>
        public static bool GetParameter()
        {
            try
            {
                PCI9014AxisInfo AxisInfo;
                if (Global.LstAxis.Count == 0)
                {
                    foreach (var item in Global.DictAxis)
                    {
                        AxisInfo = new PCI9014AxisInfo();
                        AxisInfo.AxisName = item.Value;
                        GetParameterFunc(AxisInfo);
                        Global.LstAxis.Add(AxisInfo);
                    }
                }
                else
                {
                    foreach (var axis in Global.LstAxis)
                    {
                        GetParameterFunc(axis);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                Log.GetInstance().ExceptionWrite(ex);
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 减少重复代码；为GetParameter()而成立；同时也为了切换项目是方便调用；
        /// </summary>
        /// <param name="Axisinfo"></param>
        /// <param name="AxisName"></param>
        public static void GetParameterFunc(PCI9014AxisInfo Axisinfo)
        {
            Axisinfo.No = int.Parse(IniFile.IniReadValue(Axisinfo.AxisName, "No", Global.ProductSettingPath));
            Axisinfo.Step = double.Parse(IniFile.IniReadValue(Axisinfo.AxisName, "Step", Global.ProductSettingPath));
            Axisinfo.Lead = int.Parse(IniFile.IniReadValue(Axisinfo.AxisName, "Lead", Global.ProductSettingPath));
            Axisinfo.startSpeed = int.Parse(IniFile.IniReadValue(Axisinfo.AxisName, "Speed", Global.ProductSettingPath));
            Axisinfo.maxSpeed = int.Parse(IniFile.IniReadValue(Axisinfo.AxisName, "MaxSpeed", Global.ProductSettingPath));
            Axisinfo.WorkPosition1 = int.Parse(IniFile.IniReadValue(Axisinfo.AxisName, "WorkPos1", Global.ProductSettingPath));
            Axisinfo.WorkPosition2 = int.Parse(IniFile.IniReadValue(Axisinfo.AxisName, "WorkPos2", Global.ProductSettingPath));
            Axisinfo.StartBackHomeDis = int.Parse(IniFile.IniReadValue(Axisinfo.AxisName, "StartMoveDis", Global.ProductSettingPath));
            Axisinfo.HomeBackSpeed = int.Parse(IniFile.IniReadValue(Axisinfo.AxisName, "HomeBackSpeed", Global.ProductSettingPath));
            Axisinfo.StepPerMM = Convert.ToInt32(Axisinfo.Step / Axisinfo.Lead);
            Axisinfo.AccTime = Axisinfo.DecTime = Axisinfo.maxSpeed * 10;
            if (Axisinfo.DecTime >= 260000000)
            {
                Axisinfo.AccTime = Axisinfo.DecTime = 260000000;
            }
        }

        /// <summary>
        /// 读取控制轴的位置计数器
        /// </summary>
        /// <param name="axinfo"></param>
        /// <returns></returns>
        public override int GetCurrentPos(SingleDemura.PCI9014AxisInfo axinfo)
        {
            return CPci9014.p9014_get_pos(axinfo.No, 0, ref axinfo.curPos);
        }

        /// <summary>
        /// 点位绝对运动（单个轴点到点的驱动，根据不同模式做出不同的加减速）
        /// </summary>
        /// <param name="axinfo"></param>
        /// <returns></returns>
        public override int PAbsoluteMove(SingleDemura.PCI9014AxisInfo axinfo)
        {
            return CPci9014.p9014_pmove(axinfo.No, axinfo.cmdPos, 1, 2);
        }

        /// <summary>
        /// 获取与驱动轴相关 I/O（如限位信号、原点信号）的状态
        /// </summary>
        /// <param name="axisinfo"></param>
        /// <returns></returns>
        public override int IsORG(PCI9014AxisInfo axisinfo)
        {
            int res = 0;
            res = CPci9014.p9014_get_io_status(axisinfo.No, ref axisinfo.IOstate);
            if (res != 0)
            {
                return 2;
            }
            if ((axisinfo.IOstate & (0x01 << 2)) != 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 是否是负极限
        /// </summary>
        /// <param name="axisinfo"></param>
        /// <returns></returns>
        public override int IsMEL(PCI9014AxisInfo axisinfo)
        {
            int res = 0;
            res = CPci9014.p9014_get_io_status(axisinfo.No, ref axisinfo.IOstate);
            if (res != 0)
            {
                return 2;
            }
            if ((axisinfo.IOstate & (0x01 << 1)) != 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public override int IsPEL(PCI9014AxisInfo axisinfo)
        {
            int res = 0;
            res = CPci9014.p9014_get_io_status(axisinfo.No, ref axisinfo.IOstate);
            if (res != 0)
            {
                return 2;
            }
            if ((axisinfo.IOstate & (0x01)) != 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 查询指定轴的状态， 是正在运动，或者运动停止，处于空闲状态。
        /// </summary>
        /// <returns></returns>
        public override uint IsMotionDone(PCI9014AxisInfo axisinfo)
        {
            int nRes = 0;
            nRes = CPci9014.p9014_get_motion_status(axisinfo.No, ref axisinfo.isBusy);
            if (nRes != 0)
            {
                return 2;
            }
            else
            {
                return axisinfo.isBusy;
            }
        }

        /// <summary>
        /// 检查移动情况
        /// </summary>
        /// <returns></returns>
        public override int IsMoveSafe()
        {
            #region useless
            //if (GetAllInBit() != 0) { return 0; }
            //if (arrayDI[9] != true || arrayDI[10] != true || arrayDI[6] != true)  //X轴Z轴伺服报警器报警，门禁打开了
            //{
            //    Log.GetInstance().ErrorWrite("请检查X轴Y轴伺服报警器有没有报警和门禁有没有关上！");
            //    return 1;
            //}
            //else
            //{
            //    //Log.GetInstance().NormalWrite("X轴Z轴安全！且门禁无报警！");
            //    return 1;
            //}
            return 1;
            #endregion
        }

        /// <summary>
        /// 回原运动
        /// </summary>
        /// <param name="axbase"></param>
        /// <returns></returns>
        public override int HomeAllAxis(PCI9014AxisInfo SetAxis)
        {
            Log.GetInstance().WarningWrite("正在回原点，请等待......");

            //当处于原点时，需要往正向移动一定距离，然后再进行复位动作，保证每次复位位置一致
            int res = 0;
            res = IsORG(SetAxis);
            if (res == 1)
            {
                Log.GetInstance().WarningWrite(string.Format("{0}--已经在原点位置无需回原运动！", SetAxis.AxisName));
                goto WorkPos;
            }
            else if (res == 2) { return (int)(ErrorInfo.ErrorCmdExcuteFail); }

            CPci9014.p9014_set_t_profile(SetAxis.No, SetAxis.startSpeed, SetAxis.maxSpeed, SetAxis.AccTime, SetAxis.DecTime);
            CPci9014.p9014_pmove(SetAxis.No, SetAxis.StartBackHomeDis, 0, 2);

            while (true)
            {
                if (IsMotionDone(SetAxis) == 0) { break; }
                Thread.Sleep(50);
            }
            //固定回原速度，起止速度相同；
            CPci9014.p9014_set_t_profile(SetAxis.No, SetAxis.HomeBackSpeed, SetAxis.HomeBackSpeed, SetAxis.AccTime, SetAxis.DecTime);
            CPci9014.p9014_home_move(SetAxis.No, 0);

            while (true)
            {
                if (IsMotionDone(SetAxis) == 0) { break; }
                Thread.Sleep(50);
            }

            Thread.Sleep(100);
            res = IsORG(SetAxis);
            if (res == 1)
            {
                Log.GetInstance().WarningWrite("回原点成功！！");
            }
            else
            {
                Log.GetInstance().ErrorWrite("回原点失败！！");
                return (int)ErrorInfo.ErrorCmdExcuteFail;
            }

            Log.GetInstance().WarningWrite(string.Format("{0}--准备运动到工作位置！", SetAxis.AxisName));

            res = Global.AxisControlCard.GetCurrentPos(SetAxis);
            if (res != 0)
            {
                Log.GetInstance().ErrorWrite("获取当前位置失败！！");
                return (int)ErrorInfo.ErrorCmdExcuteFail;
            }

            WorkPos: SetAxis.cmdPos = SetAxis.WorkPosition1 - SetAxis.curPos;

            res = Global.AxisControlCard.PRelativeMove(SetAxis);

            if (res != (int)ErrorInfo.ErrorSucceed)
            {
                Log.GetInstance().ErrorWrite(string.Format("{0}运动失败！！", SetAxis.AxisName));
                return (int)ErrorInfo.ErrorCmdExcuteFail;
            }

            return (int)ErrorInfo.ErrorSucceed;
        }

        /// <summary>
        /// 点位相对运动
        /// </summary>
        /// <param name="axinfo"></param>
        /// <returns></returns>
        public override int PRelativeMove(PCI9014AxisInfo axinfo)
        {
            int requesttimes = 0;
            ErrorInfo MoveRes;

            Log.GetInstance().WarningWrite("正在向目标位置运动，请等待......");
            
            while (GetCurrentPos(axinfo) != 0)
            {
                requesttimes++;
                if (requesttimes == 10)
                {
                    Log.GetInstance().ErrorWrite("获取当前位置失败！");
                    return (int)(ErrorInfo.ErrorCmdExcuteFail);
                }
            }

            int DistanceAdd = axinfo.curPos + axinfo.cmdPos;

            MoveRes = SectionMotion(axinfo, axinfo.startSpeed, axinfo.maxSpeed, axinfo.cmdPos, DistanceAdd);
            if (MoveRes != ErrorInfo.ErrorSucceed)
            {
                return (int)MoveRes;
            }

            Log.GetInstance().NormalWrite(string.Format("{0}--已到达目标位置", axinfo.AxisName));
            return (int)(ErrorInfo.ErrorSucceed);
        }

        /// <summary>
        /// 距离间的运动；
        /// </summary>
        /// <param name="axinfo"></param>
        /// <param name="VStart"></param>
        /// <param name="VMax"></param>
        /// <param name="MovePosition"></param>
        /// <param name="MovedDistance"></param>
        /// <returns></returns>
        public override ErrorInfo SectionMotion(PCI9014AxisInfo axinfo, int VStart, int VMax, int MovePosition, int MovedDistance)
        {
            int requesttimes = 0;
            while (CPci9014.p9014_set_t_profile(axinfo.No, VStart, VMax, axinfo.AccTime, axinfo.DecTime) != 0) { Thread.Sleep(10); }
            while (CPci9014.p9014_pmove(axinfo.No, MovePosition, 0, 2) != 0) { Thread.Sleep(10); }
            //Thread.Sleep(10);
            while (true)
            {
                if (IsMotionDone(axinfo) == 0)
                {
                    break;
                }
                Thread.Sleep(50);
            }
            while (GetCurrentPos(axinfo) != 0)
            {
                Thread.Sleep(10);
                requesttimes++;
                if (requesttimes == 100)
                {
                    Log.GetInstance().ErrorWrite("获取当前位置失败！");
                    return ErrorInfo.ErrorCmdExcuteFail;
                }
            }
            if (System.Math.Abs((double)axinfo.curPos - (double)MovedDistance) > 1000)     //实际位置和期望位置误差太大，超过了1000
            {
                Log.GetInstance().ErrorWrite("运动完成了，但实际位置和期望位置误差大于1000脉冲！");
                return ErrorInfo.ErrorNotMoveToCorrectPos;
            }
            return ErrorInfo.ErrorSucceed;
        }

        #region 单工位暂时没有这些需求

        /// <summary>
        /// 设置位置计数器
        /// </summary>
        /// <param name="axinfo"></param>
        /// <param name="pos"></param>
        /// <returns></returns>
        public override int SetCurrentPos(SingleDemura.PCI9014AxisInfo axinfo, int pos)
        {
            return CPci9014.p9014_set_pos(axinfo.No, 0, pos);
        }

        /// <summary>
        /// 抽真空
        /// </summary>
        /// <param name="flag"></param>
        public override void ChouZhenkong(Boolean flag)
        {
            if (flag)
            {
                SetOutBit(3, true);
                SetOutBit(4, false);
                Log.GetInstance().NormalWrite("抽真空已完成！");
            }
            else
            {
                SetOutBit(3, false);
                SetOutBit(4, true);
                Log.GetInstance().NormalWrite("破真空已完成！");
            }
        }

        #endregion 单工位暂时没有这些需求

        public override int SetOutBit(uint bitNO, Boolean flg)
        {
            uint data = flg ? (uint)0 : (uint)1;
            return CPci9014.p9014_set_do_bit(0, bitNO, data);
        }

        public override int SetAllOutBit(Boolean flg)
        {
            //0是导通，1是阻止；
            uint data;
            data = flg ? (uint)0 : (uint)(0xffff);
            return CPci9014.p9014_set_do(0, data);
        }

        public override int SetPlsInputmode(PCI9014AxisInfo axinfo)
        {
            return base.SetPlsInputmode(axinfo);
        }

        public override int SettProfile(SingleDemura.PCI9014AxisInfo axinfo)
        {
            return CPci9014.p9014_set_t_profile(axinfo.No, axinfo.startSpeed, axinfo.maxSpeed, axinfo.AccTime, axinfo.DecTime);
        }

        public override int Stop(SingleDemura.PCI9014AxisInfo axinfo)
        {
            return CPci9014.p9014_stop(axinfo.No, 0);
        }

        public override int VMove(SingleDemura.PCI9014AxisInfo axinfo, int dir)
        {
            return CPci9014.p9014_vmove(axinfo.No, dir, 2);
        }

        public override int HomeMove(SingleDemura.PCI9014AxisInfo axinfo, int dir)
        {
            return CPci9014.p9014_home_move(axinfo.No, dir);
        }

        public override int GetCurrentSpeed(SingleDemura.PCI9014AxisInfo axinfo)
        {
            return CPci9014.p9014_get_current_speed(axinfo.No, ref axinfo.curSpeed);
        }

        public override void GetIOState(PCI9014AxisInfo axinfo)
        {
            int cmd_pos = 0, enc_pos = 0;
            uint motion_status = 0, io_status = 0;
            double cur_vel = 0.0;

            CPci9014.p9014_get_motion_status(axinfo.No, ref motion_status);
            CPci9014.p9014_get_io_status(axinfo.No, ref io_status);
            CPci9014.p9014_get_current_speed(axinfo.No, ref cur_vel);
            CPci9014.p9014_get_pos(axinfo.No, 0, ref cmd_pos);
            //CPci9014.p9014_get_pos(axinfo.No, 1, ref enc_pos);
            axinfo.isBusy = motion_status == 1 ? (uint)1 : (uint)0;

            axinfo.fLimit = (io_status % 2) == 1 ? true : false;
            axinfo.rLimit = ((io_status >> 1) % 2) == 1 ? true : false;
            axinfo.oRG = ((io_status >> 2) % 2) == 1 ? true : false;
            //axinfo.Ez = ((io_status >> 3) % 2) == 1 ? true : false;
            axinfo.eMG = ((io_status >> 4) % 2) == 1 ? true : false;
            axinfo.dir = (int)io_status % 2 >> 5;

            axinfo.curSpeed = cur_vel;
            axinfo.curPos = cmd_pos;
            //axinfo.EncoderPos = enc_pos;
        }

        public override int HomeMoveConfig(PCI9014AxisInfo axinfo)
        {
            CPci9014.p9014_set_t_profile(axinfo.No, 5000, 20000, 1000, 1000);//固定一个回原速度
            return CPci9014.p9014_home_config(axinfo.No, 0, 1, 1);
        }

        public override int GetAllInBit()
        {
            uint inputIO = 0;
            int re = CPci9014.p9014_get_di(0, ref inputIO);
            for (int i = 0; i < arrayDI.Length; i++)
            {
                arrayDI[i] = ((inputIO >> i) & 0x0001) == 0;
            }
            return re;
        }

        public override uint GetInBit(int CardNum, uint bitNum)
        {
            uint InputIO = 0;
            int re = CPci9014.p9014_get_di_bit(CardNum, bitNum, ref InputIO);
            if (re != 0)
            {
                return 2;
            }
            else
            {
                return InputIO;
            }
        }

        public override int GetOutBit()
        {
            uint outputIO = 0;
            int re = CPci9014.p9014_get_do(0, ref outputIO);
            for (int i = 0; i < arrayDI.Length; i++)
            {
                arrayDO[i] = ((outputIO >> i) & 0x0001) == 0;
            }
            return re;
        }

        /// <summary>
        /// 设定限位信号有效电平，可以为高电平有效，也可以为低电平有效，默认为低电平有效
        /// </summary>
        /// <param name="axinfo"></param>
        /// <param name="flg"></param>
        /// <returns></returns>
        public override int SetLimitLevel(PCI9014AxisInfo axinfo, int flg)
        {
            int re = CPci9014.p9014_set_el_level(axinfo.No, flg);
            return re;
        }

        public override int SetPlsOutmode(PCI9014AxisInfo axinfo, int plsOutMode)
        {
            return CPci9014.p9014_set_pls_outmode(axinfo.No, plsOutMode); ;
        }

        /// <summary>
        /// 单轴回原点；
        /// </summary>
        /// <param name="axisinfo"></param>
        /// <param name="BitNum"></param>
        /// <returns></returns>
        public override int SingleAxisHomeBack(PCI9014AxisInfo axisinfo, uint BitNum)
        {
            int waittime = 0;
            int res = 0;
            int FindORLCondition = 0;

            res = CPci9014.p9014_set_t_profile(axisinfo.No, axisinfo.HomeBackSpeed, axisinfo.HomeBackSpeed, axisinfo.AccTime, axisinfo.DecTime);
            res = CPci9014.p9014_home_move(axisinfo.No, FindORLCondition);//设置为反向查找；
            if (res != 0)
            {
                Log.GetInstance().ErrorWrite("回原点失败！！");
                return res;
            }
            while (true)
            {
                if (waittime == 50)
                {
                    Log.GetInstance().ErrorWrite(string.Format("{0}回原点超时！！", axisinfo.AxisName));
                    Global.AxisControlCard.Stop(axisinfo);
                    return res;
                }
                waittime++;
                res = (int)Global.AxisControlCard.GetInBit(0, BitNum);
                if (res == 2)
                {
                    continue;
                }
                else if (res == 1 && axisinfo.AxisName == "检测相机")
                {
                    Log.GetInstance().ErrorWrite(string.Format("{0}-运动轴报警！！！", axisinfo.AxisName));
                    Global.AxisControlCard.Stop(axisinfo);
                    return res;
                }
                else if (res == 0 && axisinfo.AxisName == "遮光幕布")
                {
                    Log.GetInstance().ErrorWrite(string.Format("{0}-运动轴报警！！！", axisinfo.AxisName));
                    Global.AxisControlCard.Stop(axisinfo);
                    return res;
                }
                res = (int)IsMotionDone(axisinfo);
                if (res == 2)
                {
                    Log.GetInstance().ErrorWrite("获取运动状态失败！！");
                    break;
                }
                else if (res == 0)
                {
                    Log.GetInstance().NormalWrite(string.Format("{0}轴的运动状态已停止！！", axisinfo.AxisName));
                    break;
                }
                Thread.Sleep(1000);
            }
            return res;
        }

        /// <summary>
        /// 单轴回负极线位置；
        /// </summary>
        /// <param name="axisinfo"></param>
        /// <returns></returns>
        public override int SingleAxisBackWorkPos(PCI9014AxisInfo axisinfo)
        {
            int res = 0;
            if (IsORG(axisinfo) != 1)
            {
                res = CPci9014.p9014_set_t_profile(axisinfo.No, axisinfo.HomeBackSpeed, axisinfo.HomeBackSpeed, axisinfo.AccTime, axisinfo.DecTime);
                res = CPci9014.p9014_home_move(axisinfo.No, 0);//设置为反向查找；
                while (true)
                {
                    if (IsMotionDone(axisinfo) == 0) { break; }
                    Thread.Sleep(100);
                }
                if (res != 0)
                {
                    Log.GetInstance().ErrorWrite("测试完成后回原点失败！！");
                    return res;
                }
                res = IsORG(axisinfo);
                if (res != 1)
                {
                    Log.GetInstance().ErrorWrite("测试完成回后原点失败！！");
                    return res;
                }
            }

            axisinfo.cmdPos = axisinfo.WorkPosition1;
            res = CPci9014.p9014_set_t_profile(axisinfo.No, axisinfo.startSpeed, axisinfo.maxSpeed, axisinfo.AccTime, axisinfo.DecTime);
            res = CPci9014.p9014_pmove(axisinfo.No, axisinfo.cmdPos, 0, 2);
            //检查运动是否完成，且检查运动轴是否报警；

            while (true)
            {
                if (IsMotionDone(axisinfo) == 0) { break; }
                Thread.Sleep(50);
            }

            if (Global.AxisControlCard.GetCurrentPos(axisinfo) == 0)
            {
                if (System.Math.Abs(axisinfo.curPos - axisinfo.cmdPos) > 1000)
                {
                    Log.GetInstance().ErrorWrite("与目标位置相差大于1000个脉冲！！");
                    res = 2;
                }
            }
            return res;
        }
    }
}