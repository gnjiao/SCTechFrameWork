using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardWareInterFaces
{
    public interface IPGCtrl
    {
        /// <summary>
        /// 连接PG要做的初始化动作
        /// </summary>
        /// <returns>ErrorCode</returns>
        bool Init();

        /// <summary>
        /// 断开PG连接
        /// </summary>
        /// <returns>ErrorCode</returns>
        int Exit();

        /// <summary>
        /// 控制PG给连接的屏幕上下点动作
        /// </summary>
        /// <returns>ErrorCode</returns>
        int PowerOn();

        /// <summary>
        /// 控制PG给连接的屏幕下电
        /// </summary>
        /// <returns>ErrorCode</returns>
        int PowerOff();

        /// <summary>
        /// 显示预存在PG里的对应序号的图片
        /// </summary>
        /// <param name="index">图片的序号</param>
        /// <returns>ErrorCode</returns>
        int SetPattern(int index);

        /// <summary>
        /// 在屏幕上打印字体
        /// </summary>
        /// <param name="posX">字体的x坐标</param>
        /// <param name="posY">字体的y坐标</param>
        /// <param name="font">字体规范</param>
        /// <returns>ErrorCode</returns>
        int ShowText(int posX, int posY, int FontSize, string Msg, Color color);

        /// <summary>
        /// 读取PG的电压电流信息
        /// </summary>
        /// <param name="channelIndex">PG的第几输出通道</param>
        /// <param name="voltageInfo">电压信息数组</param>
        /// <param name="currentInfo">电流信息数组</param>
        /// <returns>ErrorCode</returns>
        int GetPowerInfo(int channelIndex, out float[][] voltageInfo, out float[][] currentInfo);

        /// <summary>
        /// 屏幕显示设定的RGB
        /// </summary>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        int SetRaster(byte r, byte g, byte b);

        /// <summary>
        /// 获取设定的屏幕分辨率
        /// </summary>
        /// <param name="width">屏幕宽度</param>
        /// <param name="height">屏幕长度</param>
        /// <returns></returns>
        int GetResolution(ref int width, ref int height);

        /// <summary>
        /// 读取屏幕IC的寄存器值
        /// </summary>
        /// <param name="regAddr">要获取寄存器值的地址数组</param>
        /// <param name="regVal">存放寄存器值</param>
        /// <returns></returns>
        int ReadICRegVal(int nAddre, int nLen, out byte[] regVal);

        /// <summary>
        /// 往IC寄存器中写入值
        /// </summary>
        /// <param name="regAddr">要写入值的寄存器位置数组</param>
        /// <param name="regVal">要写入的寄存器值，与地址一一对应</param>
        /// <returns></returns>
        int WriteICRegValue(byte[] regAddr, byte[] regVal);

        /// <summary>
        /// 往PG Ram中传输补偿数据；
        /// </summary>
        /// <param name="bOn"></param>
        /// <returns></returns>
        int DmrEffectCtrl(bool bOn);
    }

    public interface IPGDeMura
    {
        /// <summary>
        /// 执行DeMuraOTP，一般只在第一次执行OTP，DeMuraOTP可以执行两次，客户需要保留一次
        /// </summary>
        /// <param name="flag">当前已执行OTP的次数</param>
        /// <returns></returns>
        int DeMuraOTP(int flag);

        /// <summary>
        /// 打开关闭DeMura效果，用于做完DeMura之后观察前后效果
        /// </summary>
        /// <param name="bOn">true开启DeMura效果</param>
        /// <returns></returns>
        int DeMuraFunctionSwitch(bool bOn);

        /// <summary>
        /// 烧写DeMura生成的bin文件
        /// </summary>
        /// <returns></returns>
        int DeMuraFlashWrite();

        /// <summary>
        /// 读取屏幕的FlahID
        /// </summary>
        /// <param name="flashID"></param>
        /// <returns></returns>
        int ReadFlashID(out int flashID);
    }

    public interface IPGGamma
    {
        int GammaOTP(int flag);

        int WriteGammaData(byte btRgb, byte index, byte[] data);//Gamma

        int ReadGammaData(out byte[] gamaData);//Gamma
    }

    public interface ISZPG : IPGCtrl, IPGDeMura
    {
        /// <summary>
        /// 要控制PG的IP地址
        /// </summary>
        string IP { set; get; }

        /// <summary>
        /// 要控制PG的端口号
        /// </summary>
        int Port { set; get; }

        /// <summary>
        /// 通过FTP将文件发送给PG
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        int SendFileByFtp(string fileName);

        /// <summary>
        /// 读取PG寄存器的值
        /// </summary>
        /// <param name="addr">要读取寄存器值的起始地址</param>
        /// <param name="offset">地址偏移位</param>
        /// <param name="length">读取寄存器的长度</param>
        /// <param name="data">返回寄存器值的数组</param>
        /// <returns></returns>
        int ReadPGRegValue(int addr, int offset, int length, out int[] data);

        /// <summary>
        /// 写入PG寄存器的值
        /// </summary>
        /// <param name="addr">要写入寄存器值的起始地址</param>
        /// <param name="offset">地址偏移量</param>
        /// <param name="data">要写入的寄存器值</param>
        /// <returns></returns>
        int WritePGRegValue(int addr, int offset, int length, int[] data);

        int ChangeModule(string Filename, int nLen);

        int ReadCheckSum(ref ushort nCheckSum);
    }
}