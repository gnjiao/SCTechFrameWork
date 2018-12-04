using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Model;

namespace HardWareInterFaces
{
    public interface IAxisCard
    {
        DelegateShowLog ShowLog { get; set; }

        /// <summary>
        /// 设定指定轴卡的配置信息;
        /// </summary>
        /// <param name="AxisNo"></param>
        bool InitialAxisConfig(AxisCard axisinfo, ProFileType profiletype);

        /// <summary>
        /// 初始化轴卡;
        /// </summary>
        /// <returns></returns>
        bool InitialAxisCard();

        /// <summary>
        /// 轴卡停止运动;
        /// </summary>
        /// <returns></returns>
        int AxisStop(AxisCard axisinfo, AxisStopType StopType);

        /// <summary>
        /// 回原运动
        /// </summary>
        /// <returns></returns>
        int HomeMove(AxisCard axisinfo, int BackCondition = 0);

        /// <summary>
        /// 获取当前位置的脉冲数;
        /// </summary>
        /// <returns></returns>
        int GetPosition(AxisCard axisinfo);

        /// <summary>
        /// 定长运动;
        /// </summary>
        /// <returns></returns>
        int PMove(AxisCard axisinfo, int MovePulse, ProFileType MoveStyle);

        /// <summary>
        /// 检测轴卡状态,运动或静止状态;
        /// </summary>
        /// <returns></returns>
        int CheckAxisStatus(AxisCard axisinfo);

        /// <summary>
        /// 检查IO状态；
        /// </summary>
        /// <param name="AxisNo"></param>
        /// <returns></returns>
        uint CheckIOStatus(AxisCard axisinfo);

        /// <summary>
        /// 读取轴卡I/O指定输入端口的电平状态;
        /// </summary>
        /// <param name="AxisNo">轴卡编号</param>
        /// <param name="BitNo">端口号</param>
        /// <returns>-1：动作失败，0：低电平，1：高电平</returns>
        int AxisCard_ReadInBit(int CardNo, int BitNo);

        /// <summary>
        /// 写入轴卡I/O指定的输出端口的电平
        /// </summary>
        /// <param name="AxisNo">轴卡编号</param>
        /// <param name="BitNo">端口号</param>
        /// <returns></returns>
        int AxisCard_WriteOutBit(int CardNo, int BitNo, uint Data);
    }

    public enum AxisStopType
    {
        //所有轴卡急停
        EmgStop = 0,

        //指定轴卡减速停止
        DecelStop,

        //指定轴卡立即停止;
        ImdStop,

        //所有轴同时停止
        SimultaneousStop
    }

    public enum ProFileType
    {
        S_Profile = 0,
        T_Profile
    }
}