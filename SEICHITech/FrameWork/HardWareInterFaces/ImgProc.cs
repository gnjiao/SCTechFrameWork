using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HardWareInterFaces
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
}