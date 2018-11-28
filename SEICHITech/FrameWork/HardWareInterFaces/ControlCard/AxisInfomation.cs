using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardWareInterFaces
{
    public class AxisInfomation
    {
        /// <summary>
        /// 指定IO端口号；
        /// </summary>
        public int BitNo { get; set; }

        /// <summary>
        /// 控制卡的卡号
        /// </summary>
        public int CardID { get; set; }

        /// <summary>
        /// 对应轴卡的名称;
        /// </summary>
        public string AxisName { get; set; }

        /// <summary>
        /// 轴卡的编号;
        /// </summary>
        public int AxisNumber { get; set; }

        /// <summary>
        /// 初始速度;
        /// </summary>
        public double MinSpeed { get; set; }

        /// <summary>
        /// 最大速度;
        /// </summary>
        public double MaxSpeed { get; set; }

        /// <summary>
        /// 加速度;
        /// </summary>
        public double AccSpeed { get; set; }

        /// <summary>
        /// 减速度;
        /// </summary>
        public double DecSpeed { get; set; }

        /// <summary>
        /// 运动的脉冲数;
        /// </summary>
        public int MoveDistance { get; set; }

        /// <summary>
        /// 回原速度；
        /// </summary>
        public int HomeMoveSpeed { get; set; }

        /// <summary>
        /// 点位运动方式；0-相对，1-绝对；
        /// </summary>
        public int PMoveStyle { get; set; }

    }
}