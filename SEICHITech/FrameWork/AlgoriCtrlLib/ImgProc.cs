using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AlgoriCtrlLib
{
    public class ImgProc
    {
        [DllImport("ImageProgram_x64", EntryPoint = "ImageProc")]
        public static extern int ImageProc(StringBuilder pszImagePath, StringBuilder pszCSVPath, int nSize, int nThreshold1, int nThreshold2,
        float nThreshold3, int nThreshold4, int nImageWidth, int nImageHeight, int nHeightOffset, int nWidthOffset, double nMean, bool SaveBmp,
        bool MuraProc, bool HighPass, ref double Time1, ref double Time2, ref double Time3, float fFreq, ref float muraNum, float muraThreshold1, float muraThreshold2);

        [DllImport("ImageProgram_x64", EntryPoint = "ImageProcEx")]
        public static extern int ImageProcEx(byte[] pImageData, int CameraHeight, int CameraWidth, StringBuilder pszCSVPath, int nSize, int nThreshold1,
        int nThreshold2, float nThreshold3, int nThreshold4, int nImageHeight, int nImageWidth, int nHeightOffset, int nWidthOffset, double nMean,
        bool SaveBmp, bool MuraProc, bool HighPass, float fFreq, ref float muraNum, float muraThreshold1, float muraThreshold2);

        [DllImport("ImageProgram_x64", EntryPoint = "SinglePixelFunc")]
        public static extern void SinglePixelFunc(StringBuilder pszImagePath, int threshold, int offset, int size, ref SinglePixel[,] all_pixel_data);

        [DllImport("ImageProgram_x64", EntryPoint = "ShowRGB")]
        public static extern int ShowRGB(byte[] InData, ref byte[] OutData, int CameraHeight, int CameraWidth, int nSize, int nThreshold1, int nThreshold2,
        float nThreshold3, int nThreshold4, int nImageHeight, int nImageWidth, int nHeightOffset, int nWidthOffset, ref float muraNum);

        /// <summary>
        /// 显示错误代码对应的信息；
        /// </summary>
        /// <param name="ErrorCode">错误代码</param>
        /// <returns></returns>
        public static string GetErrorInfo(ImgProErrorCode ErrorCode)
        {
            string Errormsg = "";
            switch (ErrorCode)
            {
                case ImgProErrorCode.ImageError_PtrNull:
                    Errormsg = "图像数据指针为空！";
                    break;

                case ImgProErrorCode.ImageError_LoadImg:
                    Errormsg = "图像加载失败！";
                    break;

                case ImgProErrorCode.ImageError_RowCount:
                    Errormsg = "行数计数错误！";
                    break;

                case ImgProErrorCode.ImageError_CountMore:
                    Errormsg = "统计个数大于理想值！";
                    break;

                case ImgProErrorCode.ImageError_CountLess:
                    Errormsg = "统计个数小于理想值！";
                    break;

                case ImgProErrorCode.ImageError_CsvPath:
                    Errormsg = "csv路径错误！";
                    break;

                case ImgProErrorCode.ImageError_Success:
                    Errormsg = "成功输出csv！";
                    break;

                case ImgProErrorCode.ImageError_LedCountLess:
                    Errormsg = "led定位数量远小于目标值！";
                    break;

                case ImgProErrorCode.ImageError_PosOffset:
                    Errormsg = "定点定位偏差过大！";
                    break;

                default:
                    break;
            }
            return Errormsg;
        }
    }

    public struct SinglePixel
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        public SinglePixelCoe[] coe;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        public SinglePixelNum[] num;

        public int size;

        public int x, y;
    };

    public struct SinglePixelCoe
    {
        public float Wcoe1;
        public float Wcoe2;
        public float Wcoe3;
        public float Wcoe4;
        public float Wcoe5;
    }

    public struct SinglePixelNum
    {
        public byte Wnum1;
        public byte Wnum2;
        public byte Wnum3;
        public byte Wnum4;
        public byte Wnum5;
    }

    public enum ImgProErrorCode
    {
        ImageError_PtrNull = -1,
        ImageError_None = 0,
        ImageError_LoadImg,
        ImageError_RowCount,
        ImageError_CountMore,
        ImageError_CountLess,
        ImageError_CsvPath,
        ImageError_Success,
        ImageError_LedCountLess,
        ImageError_PosOffset
    }
}