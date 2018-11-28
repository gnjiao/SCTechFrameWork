using System;
using System.Collections.Generic;
using System.Text;

namespace SingleDemura
{
    /// <summary>
    /// 板卡基类
    /// </summary>
    public abstract class AxisBase
    {
        /// 控制灯亮不亮
        /// </summary>
        public bool LightON;

        /// <summary>
        /// 是否是手动模式，如果是手动模式，则门禁没关闭，也可以运动
        /// </summary>
        public bool IsDebugMode;

        /// <summary>
        /// <summary>
        /// 是否准备开始测试，当为true时，X轴转到工作位1
        /// </summary>
        //public bool TobeReadyforwork;

        /// <summary>
        /// <summary>
        /// 是否开始测试过程
        /// </summary>
        public bool DoWork;

        /// <summary>
        /// <summary>
        /// DI输入信号
        /// </summary>
        public bool[] arrayDI;

        /// <summary>
        /// DO输出信号
        /// </summary>
        public bool[] arrayDO;

        /// <summary>
        ///
        /// </summary>
        /// <param name="dex"></param>
        /// <param name="selFlg">0输入，其他输出</param>
        /// <returns></returns>
        public Boolean this[int dex, int selFlg]
        {
            get
            {
                if (0 == selFlg)
                {
                    if (arrayDI.Length < dex)
                    {
                        throw new IndexOutOfRangeException();
                    }
                    return arrayDI[dex];
                }
                else
                {
                    if (arrayDO.Length < dex)
                    {
                        throw new IndexOutOfRangeException();
                    }
                    return arrayDO[dex];
                }
            }
        }

        /// <summary>
        /// 初始化板卡
        /// </summary>
        virtual public int Init()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 关闭板卡
        /// </summary>
        virtual public int Close()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 脉冲输出模式设定
        /// </summary>
        virtual public int SetPlsOutmode(SingleDemura.PCI9014AxisInfo axinfo, int plsOutMode)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 脉冲输入模式设定
        /// </summary>
        virtual public int SetPlsInputmode(SingleDemura.PCI9014AxisInfo axinfo)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 运动 T曲线参数设定
        /// </summary>
        virtual public int SettProfile(SingleDemura.PCI9014AxisInfo axinfo)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 运动 S曲线参数设定
        /// </summary>
        virtual public int SetsProfile(SingleDemura.PCI9014AxisInfo axinfo)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 连续运动
        /// </summary>
        /// <param name="axinfo"></param>
        /// <param name="dir">1正向0反向驱动</param>
        /// <returns></returns>
        virtual public int VMove(PCI9014AxisInfo axinfo, int dir)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 点位绝对运动
        /// </summary>
        virtual public int PAbsoluteMove(SingleDemura.PCI9014AxisInfo axinfo)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 停止运动
        /// </summary>
        virtual public int Stop(SingleDemura.PCI9014AxisInfo axinfo)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 是否是负极限
        /// </summary>
        virtual public int IsMEL(SingleDemura.PCI9014AxisInfo axinfo)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 是否是正极限；
        /// </summary>
        /// <param name="axisinfo"></param>
        /// <returns></returns>
        virtual public int IsPEL(PCI9014AxisInfo axisinfo)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 是否是原点状态；
        /// </summary>
        /// <param name="axisinfo"></param>
        /// <returns></returns>
        virtual public int IsORG(PCI9014AxisInfo axisinfo)
        {
            throw new System.NotImplementedException();
        }

        virtual public uint IsMotionDone(PCI9014AxisInfo axisinfo)
        {
            throw new System.NotImplementedException();
        }

        virtual public int IsMoveSafe()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 获取当前位置
        /// </summary>
        virtual public int GetCurrentPos(SingleDemura.PCI9014AxisInfo axinfo)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 设定当前位置
        /// </summary>
        virtual public int SetCurrentPos(SingleDemura.PCI9014AxisInfo axinfo, int pos)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 原点查找动作(回原)
        /// </summary>
        /// <param name="axInfo"></param>
        /// <param name="dir">1正向0负向运动</param>
        /// <returns></returns>
        virtual public int HomeMove(PCI9014AxisInfo axInfo, int dir)
        {
            throw new System.NotImplementedException();
        }

        virtual public ErrorInfo SectionMotion(PCI9014AxisInfo axinfo, int VStart, int VMax, int MovePosition, int MovedDistance)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 设置抽不抽真空
        /// </summary>
        virtual public void ChouZhenkong(Boolean flag)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 设置输出点状态
        /// </summary>
        virtual public int SetOutBit(uint bitNo, bool flg)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 获取输出点状态
        /// </summary>
        virtual public int GetOutBit()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 获取输入点状态
        /// </summary>
        virtual public int GetAllInBit()
        {
            throw new System.NotImplementedException();
        }

        virtual public uint GetInBit(int CardNum, uint BitNum)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 点位相对运动
        /// </summary>
        virtual public int PRelativeMove(PCI9014AxisInfo Axis)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 所有轴回原点
        /// </summary>
        virtual public int HomeAllAxis(PCI9014AxisInfo SetAxis)
        {
            throw new System.NotImplementedException();
        }

        public SingleDemura.PCI9014AxisInfo axinfo()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 设置所有的输出点状态
        /// </summary>
        /// <param name="axinfo"></param>
        /// <param name="flg"></param>
        /// <returns></returns>
        virtual public int SetAllOutBit(bool flg)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 获取当前速度
        /// </summary>
        virtual public int GetCurrentSpeed(SingleDemura.PCI9014AxisInfo axinfo)
        {
            throw new System.NotImplementedException();
        }

        virtual public void GetIOState(PCI9014AxisInfo axinfo)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 回原参数设置
        /// </summary>
        virtual public int HomeMoveConfig(PCI9014AxisInfo axinfo)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 设置极限电平有效状态
        /// </summary>
        /// <param name="axinfo"></param>
        /// <param name="flg"></param>
        /// <returns></returns>
        virtual public int SetLimitLevel(PCI9014AxisInfo axinfo, int flg)
        {
            throw new System.NotImplementedException();
        }

        virtual public int SingleAxisHomeBack(PCI9014AxisInfo axisinfo, uint BitNum)
        {
            throw new System.NotImplementedException();
        }

        virtual public int SingleAxisBackWorkPos(PCI9014AxisInfo axisinfo)
        {
            throw new System.NotImplementedException();
        }
    }
}