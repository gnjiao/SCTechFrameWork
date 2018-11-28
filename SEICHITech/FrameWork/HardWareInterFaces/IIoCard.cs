using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardWareInterFaces
{
    public interface IIoCard
    {
        /// <summary>
        /// 初始化IO控制卡;
        /// </summary>
        /// <returns></returns>
        int IOBoardInit();
        /// <summary>
        /// 关闭IO控制卡；
        /// </summary>
        /// <returns></returns>
        int IOBoardClose();
        /// <summary>
        /// 读取IO输入电平信号;
        /// </summary>
        /// <returns></returns>
        int IOCard_ReadInBit(int CardNo, int BitNO);
        /// <summary>
        /// 读取IO输出电平信号；
        /// </summary>
        /// <returns></returns>
        int IOCard_ReadOutBit(int CardNo, int BitNO);
        /// <summary>
        /// 写入IO输出信号;
        /// </summary>
        /// <returns></returns>
        int IOCard_WriteOutBit(int CardNo, int BitNO);
    }
}
