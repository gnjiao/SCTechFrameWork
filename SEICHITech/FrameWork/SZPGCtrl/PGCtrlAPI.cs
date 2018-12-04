using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PGCtrlLib

{
    public enum eOTPResult
    {
        eOTP_Fail = 0X0000,
        eOTP_No_GM_Count = 0X0001,
        eOTP_No_W_Count = 0X0002,
        eOTP_GM_Error = 0X0003,
        eOTP_W_Error = 0X0004,
        eOTP_GM_OK_1 = 0X0101,
        eOTP_GM_OK_2 = 0X0102,
        eOTP_GM_OK_3 = 0X0103,
        eOTP_GM_OK_4 = 0X0104,
        eOTP_GM_OK_5 = 0X0105,
        eOTP_GM_OK_6 = 0X0106,
        eOTP_SET_VOLT_Error = 0X1001,
        eOTP_RESET_Error = 0X1002,
    }

    public enum eErrorCode
    {
        eErrorCode_OK = 0,
        eErrorCode_Ptr_Null,
        eErrorCode_PG_Comm_Err,
    };

    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public struct TagOTPTimes
    {
        /// BYTE->unsigned char
        public byte wIDTimes;

        /// BYTE->unsigned char
        public byte wPowerTimes;

        /// BYTE->unsigned char
        public byte wGOATimes;

        /// BYTE->unsigned char
        public byte wGammaTimes;

        /// BYTE->unsigned char
        public byte wSPRTimes;

        /// BYTE->unsigned char
        public byte wP3;

        /// BYTE->unsigned char
        public byte wP6;

        /// BYTE->unsigned char
        public byte wP7;

        /// BYTE->unsigned char
        public byte wPE;

        /// BYTE->unsigned char
        public byte wANA;
    }

    public struct TagPortVoltCurr
    {
        public float wVCh1;
        public float wVCh2;
        public float wVCh3;
        public float wVCh4;
        public float wVCh5;
        public float wVCh6;
        public float wVCh7;
        public float wVCh8;

        public float wCCh1;
        public float wCCh2;
        public float wCCh3;
        public float wCCh4;
        public float wCCh5;
        public float wCCh6;
        public float wCCh7;
        public float wCCh8;
    }

    public struct TagPGVCParam
    {
        public byte wValid;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public TagPortVoltCurr[] wData;
    }

    public struct SMRegData
    {
        public byte wValid;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public SRegData[] wData;
    }

    public struct SRegData
    {
        public int wAddr;

        public byte wDataSize;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 260)]
        public byte[] wRegData;
    }

    public class PGCtrlAPI
    {
        /// <summary>
        /// 初始化模块，并设置与PG通信的参数
        /// </summary>
        /// <param name="lppComm"></param>
        /// <param name="pszIP"></param>
        /// <param name="nPort"></param>
        /// <param name="nTimeout"></param>
        /// <returns></returns>
        [DllImport("SCPGComm_x64.dll", EntryPoint = "SCPGCommInit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public extern static bool SCPGCommInit(ref IntPtr lppComm, string pszIP, UInt32 nPort = 1600, UInt32 nTimeout = 1000);

        /// <summary>
        ///  退出PG通信
        /// </summary>
        /// <param name="lppComm"></param>
        [DllImport("SCPGComm_x64.dll", EntryPoint = "SCPGCommExit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public extern static void SCPGCommExit(IntPtr lppComm);

        /// <summary>
        /// 修改通信参数，设置成另一台PG的IP后，可以直接控制对应IP的PG
        /// </summary>
        /// <param name="lpComm"></param>
        /// <param name="pszIP"></param>
        /// <param name="nPort"></param>
        /// <returns></returns>
        [DllImport("SCPGComm_x64.dll", EntryPoint = "SCPGCommSetPGIP", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public extern static bool SCPGCommSetPGIP(IntPtr lpComm, string pszIP, UInt32 nPort = 1600);

        /// <summary>
        /// 读取寄存器值，判断是否可以对Flash进行操作
        /// </summary>
        /// <param name="lppComm"></param>
        /// <returns></returns>
        [DllImport("SCPGComm_x64.dll", EntryPoint = "SCPGCommCheckFlash", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public extern static bool SCPGCommCheckFlash(IntPtr lppComm);

        /// <summary>
        ///  Demura OTP 前需先重新上电，防止将Demura Function off状态烧录到IC中
        /// </summary>
        /// <param name="lppComm"></param>
        /// <param name="bOnce"></param>
        /// <returns></returns>
        [DllImport("SCPGComm_x64.dll", EntryPoint = "SCPGCommDemuraOTP", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public extern static eErrorCode SCPGCommDemuraOTP(IntPtr lppComm, bool bOnce);

        /// <summary>
        /// 在当前显示的图片上显示字符，字模大小为8*12，根据屏幕的分辨率计算文字显示的位置和大小
        /// </summary>
        /// <param name="lpComm"></param>
        /// <param name="nPosX"></param>
        /// <param name="nPosY"></param>
        /// <param name="nTextSize"></param>
        /// <param name="pszText"></param>
        /// <param name="nLen"></param>
        /// <param name="nColor"></param>
        /// <returns></returns>
        [DllImport("SCPGComm_x64.dll", EntryPoint = "SCPGCommShowText", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public extern static int SCPGCommShowText(IntPtr lpComm, int nPosX, int nPosY, int nTextSize, string pszText, int nLen, uint nColor = 0X000000);

        /// <summary>
        /// 此接口读取到的OTP次数中将wPowerTimes作为Demura OTP次数
        /// </summary>
        /// <param name="lpComm"></param>
        /// <param name="otpTimes"></param>
        /// <returns></returns>
        [DllImport("SCPGComm_x64.dll", EntryPoint = "SCPGCommReadOTPTimes", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public extern static eErrorCode SCPGCommReadOTPTimes(IntPtr lpComm, ref TagOTPTimes otpTimes);

        /// <summary>
        /// 读Flash ID
        /// </summary>
        /// <param name="lpComm"></param>
        /// <param name="flashID"></param>
        /// <returns></returns>
        [DllImport("SCPGComm_x64.dll", EntryPoint = "SCPGCommReadFlashID", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public extern static eErrorCode SCPGCommReadFlashID(IntPtr lpComm, ref int flashID);

        /// <summary>
        /// 回读Demura OTP数据
        /// </summary>
        /// <param name="lpComm"></param>
        /// <param name="buffer"></param>
        /// <param name="bufferLength"></param>
        /// <returns></returns>
        [DllImport("SCPGComm_x64.dll", EntryPoint = "SCPGCommReadDemuraOTPData", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public extern static int SCPGCommReadDemuraOTPData(IntPtr lpComm, IntPtr buffer, int bufferLength);

        /// <summary>
        /// 读取PG电压电流值，电压单位为V,电流单位为mA
        /// </summary>
        /// <param name="lpComm"></param>
        /// <param name="pgVCParam"></param>
        /// <returns></returns>
        [DllImport("SCPGComm_x64.dll", EntryPoint = "SCPGCommReadVCParam", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public extern static int SCPGCommReadVCParam(IntPtr lpComm, out TagPGVCParam pgVCParam);

        /// <summary>
        /// 设置RGB逻辑画面
        /// </summary>
        /// <param name="lpComm"></param>
        /// <param name="btR"></param>
        /// <param name="btG"></param>
        /// <param name="btB"></param>
        /// <returns></returns>
        [DllImport("SCPGComm_x64.dll", EntryPoint = "SCPGCommSetLevel", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public extern static eErrorCode SCPGCommSetLevel(IntPtr lpComm, byte btR, byte btG, byte btB);

        /// <summary>
        ///  上电
        /// </summary>
        /// <param name="lpComm"></param>
        /// <returns></returns>
        [DllImport("SCPGComm_x64.dll", EntryPoint = "SCPGCommPowerOn", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public extern static eErrorCode SCPGCommPowerOn(IntPtr lpComm);

        /// <summary>
        /// 下电
        /// </summary>
        /// <param name="lpComm"></param>
        /// <returns></returns>
        [DllImport("SCPGComm_x64.dll", EntryPoint = "SCPGCommPowerOff", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public extern static eErrorCode SCPGCommPowerOff(IntPtr lpComm);

        /// <summary>
        /// 显示预存在PG里的对应序号的图片
        /// </summary>
        /// <param name="lpComm"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        [DllImport("SCPGComm_x64.dll", EntryPoint = "SCPGCommSetPattern", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public extern static eErrorCode SCPGCommSetPattern(IntPtr lpComm, byte index);

        /// <summary>
        /// 读配置文件中配置好的屏幕分辨率
        /// </summary>
        /// <param name="lpComm"></param>
        /// <param name="nH"></param>
        /// <param name="nW"></param>
        /// <returns></returns>
        [DllImport("SCPGComm_x64.dll", EntryPoint = "SCPGCommReadPixel", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public extern static eErrorCode SCPGCommReadPixel(IntPtr lpComm, ref int nH, ref int nW);

        /// <summary>
        /// 读IC寄存器的数据
        /// </summary>
        /// <param name="lpComm"></param>
        /// <param name="nAdder"></param>
        /// <param name="pData"></param>
        /// <param name="Length"></param>
        /// <returns></returns>
        [DllImport("SCPGComm_x64.dll", EntryPoint = "SCPGCommReadRegData", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public extern static int SCPGCommReadRegData(IntPtr lpComm, int nAdder, out byte[] pData, int Length);

        /// <summary>
        /// 读取PG寄存器值
        /// </summary>
        /// <param name="lpComm"></param>
        /// <param name="nBaseAddr"></param>
        /// <param name="nOffset"></param>
        /// <param name="pData"></param>
        /// <param name="nLength"></param>
        /// <returns></returns>
        [DllImport("SCPGComm_x64.dll", EntryPoint = "SCPGCommReadPGRegData", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public extern static int SCPGCommReadPGRegData(IntPtr lpComm, short nBaseAddr, short nOffset, ref int[] pData, int nLength);

        /// <summary>
        ///  写入PG寄存器值
        /// </summary>
        /// <param name="lpComm"></param>
        /// <param name="nBaseAddr"></param>
        /// <param name="nOffset"></param>
        /// <param name="pData"></param>
        /// <param name="nLength"></param>
        /// <returns></returns>
        [DllImport("SCPGComm_x64.dll", EntryPoint = "SCPGCommWritePGRegData", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public extern static int SCPGCommWritePGRegData(IntPtr lpComm, short nBaseAddr, short nOffset, ref int[] pData, int nLength);

        /// <summary>
        /// Demura Function On/Off
        /// </summary>
        /// <param name="lpComm"></param>
        /// <param name="bOn"></param>
        /// <returns></returns>
        [DllImport("SCPGComm_x64.dll", EntryPoint = "SCPGCommDemuraFunctionCtrl", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public extern static eErrorCode SCPGCommDemuraFunctionCtrl(IntPtr lpComm, bool bOn);

        /// <summary>
        /// 切换点屏的配置
        /// </summary>
        /// <param name="lpComm"></param>
        /// <param name="pszName"></param>
        /// <param name="nLen"></param>
        /// <returns></returns>
        [DllImport("SCPGComm_x64.dll", EntryPoint = "SCPGCommChangeModule", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public extern static eErrorCode SCPGCommChangeModule(IntPtr lpComm, string pszName, int nLen);

        /// <summary>
        /// 写IC寄存器值，单Byte数据
        /// </summary>
        /// <param name="lpComm"></param>
        /// <param name="nAddr"></param>
        /// <param name="btData"></param>
        /// <returns></returns>
        [DllImport("SCPGComm_x64.dll", EntryPoint = "SCPGCommSetByteRegData", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public extern static eErrorCode SCPGCommSetByteRegData(IntPtr lpComm, int nAddr, byte btData);

        /// <summary>
        /// 写IC寄存器值，单寄存器多个数据
        /// </summary>
        /// <param name="lpComm"></param>
        /// <param name="nAddr"></param>
        /// <param name="pData"></param>
        /// <param name="nCnt"></param>
        /// <returns></returns>
        [DllImport("SCPGComm_x64.dll", EntryPoint = "SCPGCommSetRegData", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public extern static eErrorCode SCPGCommSetRegData(IntPtr lpComm, int nAddr, byte[] pData, int nCnt);

        /// <summary>
        /// 写IC寄存器值，多寄存器，多个数据
        /// </summary>
        /// <param name="lpComm"></param>
        /// <param name="pData"></param>
        /// <returns></returns>
        [DllImport("SCPGComm_x64.dll", EntryPoint = "SCPGCommSetMulitRegData", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public extern static eErrorCode SCPGCommSetMulitRegData(IntPtr lpComm, SMRegData[] pData);

        /// <summary>
        ///  文件传输，使用FTP协议将本地文件传输到PG中
        ///  可用于：发送配置文件、发送图片、发送demura补偿数据
        ///  最好放到PG的RAM中，放在SD卡中读入需要时间，比较慢
        /// </summary>
        /// <param name="lpComm"></param>
        /// <param name="pszSrcFile"></param>
        /// <param name="pszPGFile"></param>
        /// <returns></returns>
        [DllImport("SCPGComm_x64.dll", EntryPoint = "SCPGCommSetFileToPG", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public extern static eErrorCode SCPGCommSetFileToPG(IntPtr lpComm, string pszSrcFile, string pszPGFile);

        /// <summary>
        /// 将PG中的图片或demura补偿数据发送到IC RAM中，使用nDataType参数控制发送数据的类型
        /// 显示图片时，直接调用此函数即可；
        /// 需根据IC的流程先设置好对应IC寄存器值再调用，完成后将demura RAM切换回display RAM
        /// </summary>
        /// <param name="lpComm"></param>
        /// <param name="pszPGFile"></param>
        /// <param name="nDataType"></param>
        /// <returns></returns>
        [DllImport("SCPGComm_x64.dll", EntryPoint = "SCPGCommSetPGDataToICRAM", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public extern static eErrorCode SCPGCommSetPGDataToICRAM(IntPtr lpComm, string pszPGFile, int nDataType);

        /// <summary>
        ///  读取Gamma数据
        /// </summary>
        /// <param name="lpComm"></param>
        /// <param name="pData"></param>
        /// <param name="nDataLen"></param>
        /// <returns></returns>
        [DllImport("SCPGComm_x64.dll", EntryPoint = "SCPGCommReadGammaData", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public extern static int SCPGCommReadGammaData(IntPtr lpComm, byte[] pData, int nDataLen);

        /// <summary>
        /// 写入Gamma数据
        /// </summary>
        /// <param name="lpComm"></param>
        /// <param name="btRGB"></param>
        /// <param name="btIndex"></param>
        /// <param name="pData"></param>
        /// <param name="nDataLen"></param>
        /// <returns></returns>
        [DllImport("SCPGComm_x64.dll", EntryPoint = "SCPGCommWrtieGammaData", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public extern static eErrorCode SCPGCommWrtieGammaData(IntPtr lpComm, byte btRGB, byte btIndex, byte[] pData, int nDataLen);

        /// <summary>
        ///
        /// </summary>
        /// <param name="lpComm"></param>
        /// <param name="nOTPFlag"></param>
        /// <returns></returns>
        [DllImport("SCPGComm_x64.dll", EntryPoint = "SCPGCommWriteOTP", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public extern static eErrorCode SCPGCommWriteOTP(IntPtr lpComm, UInt32 nOTPFlag);

        /// <summary>
        /// 擦除Flash
        /// </summary>
        /// <param name="lpComm"></param>
        /// <returns></returns>
        [DllImport("SCPGComm_x64.dll", EntryPoint = "SCPGCommEraseFlash", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public extern static eErrorCode SCPGCommEraseFlash(IntPtr lpComm);

        /// <summary>
        /// 往PG Ram中传输补偿数据
        /// </summary>
        /// <param name="lpComm"></param>
        /// <param name="pszDataPath"></param>
        /// <returns></returns>
        [DllImport("SCPGComm_x64.dll", EntryPoint = "SCPGCommDemuraDataTransfer", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public extern static eErrorCode SCPGCommDemuraDataTransfer(IntPtr lpComm, string pszDataPath);

        /// <summary>
        /// Demura补偿数据烧录
        /// 烧录前需要进行Flash擦除操作
        /// 烧录完成后需要调用读取Checksum接口，判断是否烧录成功
        /// </summary>
        /// <param name="lpComm"></param>
        /// <returns></returns>
        [DllImport("SCPGComm_x64.dll", EntryPoint = "SCPGCommDemuraProgram", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public extern static eErrorCode SCPGCommDemuraProgram(IntPtr lpComm);

        /// <summary>
        /// 回读Flash Checksum
        /// </summary>
        /// <param name="lpComm"></param>
        /// <param name="nChecksum"></param>
        /// <returns></returns>
        [DllImport("SCPGComm_x64.dll", EntryPoint = "SCPGCommReadFlashChecksum", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public extern static eErrorCode SCPGCommReadFlashChecksum(IntPtr lpComm, ref ushort nChecksum);

        /// <summary>
        /// 设置同步信号的宽度，单位us
        /// </summary>
        /// <param name="lpComm"></param>
        /// <param name="nWidth"></param>
        /// <returns></returns>
        [DllImport("SCPGComm_x64.dll", EntryPoint = "SCPGCommSetTriggerWidth", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public extern static bool SCPGCommSetTriggerWidth(IntPtr lpComm, int nWidth);

        /// <summary>
        ///  设置同步信号相对于 V-Sync 的延时，单位us
        /// </summary>
        /// <param name="lpComm"></param>
        /// <param name="nDelay"></param>
        /// <returns></returns>
        [DllImport("SCPGComm_x64.dll", EntryPoint = "SCPGCommSetTriggerDelay", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public extern static bool SCPGCommSetTriggerDelay(IntPtr lpComm, int nDelay);

        /// <summary>
        /// 产生触发信号
        /// </summary>
        /// <param name="lpComm"></param>
        /// <returns></returns>
        [DllImport("SCPGComm_x64.dll", EntryPoint = "SCPGCommTrigger", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public extern static bool SCPGCommTrigger(IntPtr lpComm);
    }
}