using System;
using System.Collections.Generic;
using System.Text;

namespace SingleDemura
{
    /// <summary>
    /// 轴控工厂
    /// </summary>
    sealed public class AxisFactory
    {
        static private AxisBase abrBase;
        static private object objLock = new object();
        static private AxisType axType = AxisType.PCI9014;
        /// <summary>
        /// 创建一个运动控制卡
        /// </summary>
        /// <param name="axisType">控制卡类型</param>
        private static AxisBase CreateAxis(AxisType axisType)
        {
            switch (axisType)
            {
                case AxisType.PCI9014:
                    return new PCI9014Board();
                default:
                    throw new Exception("没有此类型!!!");
            }
        }
        /// <summary>
        /// 获取一个轴卡实例
        /// </summary>
        /// <returns></returns>
        static public AxisBase GetIntance()
        {
           return GetIntance(axType);
        }
        static public AxisBase GetIntance(AxisType axisType)
        {
            if (abrBase == null)
            {
                lock (objLock)
                {
                    if (abrBase == null)
                    {
                        abrBase = CreateAxis(axType);
                    }
                }
            }
            return abrBase;
        }
    }
}
