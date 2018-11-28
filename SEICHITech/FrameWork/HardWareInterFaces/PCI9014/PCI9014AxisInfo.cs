using System;
using System.Collections.Generic;
using System.Text;

namespace SingleDemura
{

    public enum MoveDirection
    {
        ciControlMoveLeft,
        ciControlMoveRight,
        ciControlMoveUp,
        ciControlMoveDown,
        ciControlMoveLTrun,
        ciControlMoveRTrun,
        ciControlMoveZUp,
        ciControlMoveZDown
    }



    /// <summary>
    /// 轴控信息
    /// </summary>
    public class PCI9014AxisInfo
    {
        public string AxisName;
        /// <summary>
        /// 轴转一圈的物理距离；
        /// </summary>
        public double Lead;
        /// <summary>
        ///轴转一周的总脉冲数； 
        /// </summary>
        public double Step;
        /// 物理极限，单位mm或者度
        /// </summary>
        //public double MaxLimitMM;
        /// <summary>
        /// 正极限
        /// </summary>
        public bool fLimit;
        /// <summary>
        /// 负极限
        /// </summary>
        public bool rLimit;
        /// <summary>
        /// 原点
        /// </summary>
        public bool oRG;
        /// <summary>
        /// IO状态
        /// </summary>
        public uint IOstate;
        /// <summary>
        /// 是否运动
        /// </summary>
        public uint isBusy;
        /// <summary>
        /// 当前速度
        /// </summary>
        public double curSpeed;
        /// <summary>
        /// 急停
        /// </summary>
        public bool eMG;
        /// <summary>
        /// 当前运动方向
        /// </summary>
        public int dir;
        /// <summary>
        /// 轴编号
        /// </summary>
        public int No;
        /// <summary>
        /// 当前位置
        /// </summary>
        public int curPos;
        /// <summary>
        /// 启动速度
        /// </summary>
        public int startSpeed;
        /// <summary>
        /// 最高速度
        /// </summary>
        public int maxSpeed;
        /// <summary>
        /// 加速时间
        /// </summary>
        public int AccTime;
        /// <summary>
        /// 减速时间
        /// </summary>
        public int DecTime;
        /// <summary>
        /// 指定位置
        /// </summary>
        public int cmdPos;
        /// </summary>
        /// 移动每一mm所发送的脉冲数
        /// </summary>
        public int StepPerMM;
        /// <summary>
        /// 移动方向
        /// </summary>
        public MoveDirection moveDirection;
        /// <summary>
        /// 移动距离，单位mm或度
        /// </summary>
        //public double MoveDistance;
        /// <summary>
        /// 工作位置1，单位mm或度
        /// </summary>
        public int WorkPosition1;
        /// <summary>
        /// 工作位置2，单位mm或度
        /// </summary>
        public int WorkPosition2;
        /// <summary>
        /// 开始回原点的运动距离；
        /// </summary>
        public int StartBackHomeDis;
        /// <summary>
        /// 设置回原点速度；
        /// </summary>
        public int HomeBackSpeed;

    }
}
