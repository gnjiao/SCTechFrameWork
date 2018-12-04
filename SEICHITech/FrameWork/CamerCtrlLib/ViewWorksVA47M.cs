using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HardWareInterFaces;
using Matrox.MatroxImagingLibrary;
using Model;

namespace CamerCtrlLib
{
    public enum CamTriggerSwitch //对应串口设置指令为 stm
    {
        Error = -1,
        OFF = 0,
        ON = 1
    }

    public enum ExposureMode   //对应串口设置指令为 ses
    {
        Error = -1,
        Timed = 0,
        TriggerWidth = 1
    }

    public enum ExposureSource  //对应串口设置指令为 sts
    {
        Error = -1,
        CCD1 = 1,
        Extern = 5
    }

    public enum ActivationMode  //对应串口设置指令为 stp
    {
        Error = -1,
        FallingEdge = 0,
        RisingEdge = 1
    }

    public class ViewWorksVA47M : ICameraCtrl
    {
        #region Properties

        private MIL_ID appID = MIL.M_NULL;
        private MIL_ID sysID = MIL.M_NULL;
        private MIL_ID digID = MIL.M_NULL;
        private MIL_ID dispID = MIL.M_NULL;
        private MIL_ID bufID = MIL.M_NULL;
        private MIL_INT imgAttribute = MIL.M_NULL;
        private MIL_ID imgID = MIL.M_NULL;
        private string dfc;

        private int width;
        private int height;
        private bool bStarted = false;
        private ComPort comport;
        private AutoResetEvent grabResetEvent = null;
        private int GrabTimeOut = 5000;

        public string DcfFile
        {
            get { return dfc; }
            set { dfc = value; }
        }

        public int Width
        {
            get { return width; }
        }

        public int Height
        {
            get { return height; }
        }

        public bool bConnected
        {
            get { return comport.IsOpen; }
        }

        #endregion Properties

        public ViewWorksVA47M(string port, int baud)
        {
            try
            {
                comport = new ComPort(port, baud);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        ~ViewWorksVA47M()
        {
            comport.Dispose();
        }

        public int Init(int camIndex = 0)
        {
            try
            {
                //1.初始化默认的appID和sysID
                MIL.MappAllocDefault(MIL.M_DEFAULT, ref appID, ref sysID, MIL.M_NULL, MIL.M_NULL, MIL.M_NULL);

                //2.初始化digID，用于CameraLink控制相机
                MIL_INT digNum = MIL.MsysInquire(sysID, MIL.M_DIGITIZER_NUM, MIL.M_NULL);//获取Cameralink数量

                if (digNum < camIndex)
                {
                    throw new Exception($"Camera {camIndex} not exits! Please check !");
                }
                MIL.MdigAlloc(sysID, camIndex, dfc, MIL.M_DEFAULT, ref digID);//从DFC文件中加载相机配置，第三个参数就是DFC文件的路径

                //3.相机配置保存在DFC文件中，现在可以从digID中获取到相机的配置
                MIL.MdigInquire(digID, MIL.M_SIZE_X, ref width); //获取相机宽度
                MIL.MdigInquire(digID, MIL.M_SIZE_Y, ref height);//获取相机高度

                //MIL.MdigInquire(digID, MIL.M_MODEL_IMAGE_ATTRIBUTE, ref imgAttribute);//用于下一步分配相机帧buffer的参数
                imgAttribute = MIL.M_GRAB | MIL.M_IMAGE | MIL.M_DISP | MIL.M_PROC;

                //4.分配buffer来存储相机帧数据
                MIL.MbufAlloc2d(sysID, width, height, 8 + MIL.M_UNSIGNED, imgAttribute, ref imgID);

                //4.初始化时,开启控制串口
                //comport.Open();
            }
            catch (Exception e)
            {
                throw e;
            }
            return 0;
        }

        public bool SetTriggerMode(CamTriggerSwitch tiggerSwitch)
        {
            string result;
            return comport.SendMessage($"stm {(int)tiggerSwitch}\r", out result, "OK", ResultCompareMode.ResultContainString, 300);
        }

        public CamTriggerSwitch GetTriggerState()
        {
            string ret = comport.SendMessage("gtm", 1000);
            if (ret == "")
            {
                return CamTriggerSwitch.Error;
            }
            return (CamTriggerSwitch)Convert.ToInt32(ret.Trim());
        }

        public bool SetExposureMode(ExposureMode exposureMode)
        {
            string result;
            return comport.SendMessage($"ses {(int)exposureMode}\r", out result, "OK", ResultCompareMode.ResultContainString, 300);
        }

        public ExposureMode GetExposureMode()
        {
            string ret = comport.SendMessage("ges", 300);
            if (ret == "")
            {
                return ExposureMode.Error;
            }
            return (ExposureMode)Convert.ToInt32(ret.Trim());
        }

        public bool SetExposureSource(ExposureSource src)
        {
            string result;
            return comport.SendMessage($"sts {(int)src}\r", out result, "OK", ResultCompareMode.ResultContainString, 300);
        }

        public ExposureSource GetExposureSource()
        {
            string ret = comport.SendMessage("gts", 300);
            if (ret == "")
            {
                return ExposureSource.Error;
            }
            return (ExposureSource)Convert.ToInt32(ret.Trim());
        }

        public bool SetActivationMode(ActivationMode activationMode)
        {
            string result;
            return comport.SendMessage($"stp {(int)activationMode}\r", out result, "OK", ResultCompareMode.ResultContainString, 300);
        }

        public ActivationMode GetActivationMode()
        {
            string ret = comport.SendMessage("gtp", 300);
            if (ret == "")
            {
                return ActivationMode.Error;
            }
            return (ActivationMode)Convert.ToInt32(ret.Trim());
        }

        public int Start()
        {
            if (appID == MIL.M_NULL || sysID == MIL.M_NULL || digID == MIL.M_NULL || imgID == MIL.M_NULL)
            {
                return -1;
            }

            MIL.MdigProcess(digID, ref imgID, 1, MIL.M_START, MIL.M_DEFAULT, FrameEvent, MIL.M_NULL);
            bStarted = true;
            return 0;
        }

        public int Stop()
        {
            if (!bStarted)
            {
                return 0;
            }

            MIL.MdigProcess(digID, ref imgID, 1, MIL.M_STOP, MIL.M_DEFAULT, FrameEvent, MIL.M_NULL);

            bStarted = false;
            return 0;
        }

        public int Grab(string fileName = "")
        {
            if (!bStarted)
            {
                throw new Exception("Need execute \"Start()\" before \"Grab\"!");
                //Start();
            }

            grabResetEvent = new AutoResetEvent(false);
            //MIL.MdigGrab(digID, imgID);
            MIL.MdigControl(digID, MIL.M_TIMER_TRIGGER_SOFTWARE + MIL.M_TIMER1, MIL.M_ACTIVATE);//触发软触发，当相机采集到图像之后会进入到Callback（FrameEvent方法）

            bool bret = grabResetEvent.WaitOne(5000);
            grabResetEvent = null;

            //Stop();

            if (!bret)
            {
                return -1;
            }
            else
            {
                byte[] byteSrc = new byte[width * height];
                MIL.MbufControl(imgID, MIL.M_LOCK, MIL.M_DEFAULT);
                MIL.MbufGet(imgID, byteSrc);
                MIL.MbufControl(imgID, MIL.M_UNLOCK, MIL.M_DEFAULT);

                if (fileName == "")
                {
                    fileName = DateTime.Now.ToString("yyyymmdd_hhMMss") + ".bmp";
                }
                GenerateGrayBmpFromData(height, width, byteSrc, fileName);
                return 0;
            }
        }

        public int StartCameraShow(IntPtr Handle)
        {
            try
            {
                //if (bStarted)
                //{
                //    Stop();
                //}
                MIL.MdispAlloc(sysID, MIL.M_DEFAULT, "M_DEFAULT", MIL.M_WINDOWED, ref dispID);
                //dispID = MIL.MdispAlloc(sysID, MIL.M_DEFAULT, "M_DEFAULT", MIL.M_DEFAULT, Handle);
                if (dispID == MIL.M_NULL)
                {
                    return -1;
                }

                MIL.MdispSelectWindow(dispID, imgID, Handle);

                MIL.MdispControl(dispID, MIL.M_MOUSE_USE, MIL.M_ENABLE);

                MIL.MdispControl(dispID, MIL.M_MOUSE_CURSOR_CHANGE, MIL.M_ENABLE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //Start();
            return 0;
        }

        private MIL_INT FrameEvent(MIL_INT HookType, MIL_ID EventId, IntPtr UserDataPtr)
        {
            if (grabResetEvent != null)
            {
                grabResetEvent.Set();
            }
            return (MIL_INT)1;
        }

        public void GenerateGrayBmpFromData(int height, int width, byte[] srcdata, string savePath)
        {
            short fiBitCount = 8;
            int iLineByteCnt = (((width * fiBitCount) + 31) >> 5) << 2;
            int dataSize = iLineByteCnt * height;

            //byte[] fsbytes = new byte[14];//文件头
            //byte[] fibytes = new byte[40];//信息头
            byte[] pbytes = new byte[256 * 4];//调色板
            byte[] bfType = new byte[2];
            bfType[0] = (int)'B';
            bfType[1] = (int)'M';
            byte[] bfSize = BitConverter.GetBytes(dataSize + 14 + 40 + 1024);
            byte[] bfReserved = new byte[4] { 0, 0, 0, 0 };
            byte[] biOffbits = BitConverter.GetBytes(1024 + 14 + 40);

            byte[] biSize = BitConverter.GetBytes(40);
            byte[] biWidth = BitConverter.GetBytes(width);
            byte[] biHeight = BitConverter.GetBytes(-1 * height);
            byte[] biPlanes = new byte[] { 0, 1 };
            byte[] biBitCount = BitConverter.GetBytes(fiBitCount);
            byte[] biCompression = new byte[] { 0, 0, 0, 0 };
            byte[] biSizeImage = new byte[] { 0, 0, 0, 0 };
            byte[] biXYPelsPerMeter = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 };
            byte[] biClrUsed = BitConverter.GetBytes(256);
            byte[] biClrImportant = BitConverter.GetBytes(256);
            //调色版
            for (int i = 0; i < 256; i++)
            {
                pbytes[i * 4] = (byte)i;
                pbytes[i * 4 + 1] = (byte)i;
                pbytes[i * 4 + 2] = (byte)i;
                pbytes[i * 4 + 3] = 255;
            }
            byte[] data = new byte[dataSize];
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    data[x + width * y] = srcdata[x + width * y];
                }
            }
            using (FileStream fileStream = File.OpenWrite(savePath))
            {
                fileStream.Write(bfType, 0, 2);
                fileStream.Write(bfSize, 0, 4);
                fileStream.Write(bfReserved, 0, 4);
                fileStream.Write(biOffbits, 0, 4);
                fileStream.Write(biSize, 0, 4);
                fileStream.Write(biWidth, 0, 4);
                fileStream.Write(biHeight, 0, 4);
                fileStream.Write(biPlanes, 0, 2);
                fileStream.Write(biBitCount, 0, 2);
                fileStream.Write(biCompression, 0, 4);
                fileStream.Write(biSizeImage, 0, 4);
                fileStream.Write(biXYPelsPerMeter, 0, 8);
                fileStream.Write(biClrUsed, 0, 4);
                fileStream.Write(biClrImportant, 0, 4);
                fileStream.Write(pbytes, 0, pbytes.Length);
                fileStream.Write(data, 0, data.Length);
                fileStream.Close();
                fileStream.Dispose();
            }
        }

        public int OverlayRectangle(int posX, int posY, int width, int height, Color color, int penWidth = 8)
        {
            if (dispID == MIL.M_NULL)
            {
                throw new Exception("Need to initial \"dispID\" first");
            }

            ////1.获取浮层操作id
            //MIL.MdispControl(dispID, MIL.M_OVERLAY, MIL.M_ENABLE);//允许浮层可操作

            //MIL_ID overlayID=new MIL_ID ();
            //MIL.MdispInquire(dispID, MIL.M_OVERLAY_ID, ref overlayID);//获取id

            ////2获取浮层的操作边界
            //MIL.MappControl(MIL.M_DEFAULT, MIL.M_ERROR, MIL.M_PRINT_DISABLE);  //禁止错误打印,如果下面的GDI对象获取失败，可以避免打印错误
            //MIL.MdispControl(overlayID, MIL.M_DC_ALLOC, MIL.M_DEFAULT);//创建用于浮层绘画的GDI对象
            //IntPtr ICustomDC=(IntPtr)MIL.MbufInquire(overlayID, MIL.M_DC_HANDLE, MIL.M_NULL);//获取GDI对象handle
            //MIL.MappControl(MIL.M_DEFAULT, MIL.M_ERROR, MIL.M_PRINT_ENABLE);  //允许错误打印

            MIL_ID defaultGraphicContext = MIL.M_DEFAULT;
            MIL_ID milOverlayImage = MIL.M_NULL;
            MIL_INT imageWidth, imageHeight;
            IntPtr hCustomDC = IntPtr.Zero;

            // Prepare overlay buffer.
            //***************************

            // Enable the display for overlay annotations.
            MIL.MdispControl(dispID, MIL.M_OVERLAY, MIL.M_ENABLE);

            // Inquire the overlay buffer associated with the display.
            MIL.MdispInquire(dispID, MIL.M_OVERLAY_ID, ref milOverlayImage);

            // Clear the overlay to transparent.
            MIL.MdispControl(dispID, MIL.M_OVERLAY_CLEAR, MIL.M_DEFAULT);

            // Disable the overlay display update to accelerate annotations.
            MIL.MdispControl(dispID, MIL.M_OVERLAY_SHOW, MIL.M_DISABLE);

            // Inquire overlay size.
            imageWidth = MIL.MbufInquire(milOverlayImage, MIL.M_SIZE_X, MIL.M_NULL);
            imageHeight = MIL.MbufInquire(milOverlayImage, MIL.M_SIZE_Y, MIL.M_NULL);

            // Draw MIL overlay annotations.
            //*********************************

            // Set the graphic text background to transparent.
            MIL.MgraControl(defaultGraphicContext, MIL.M_BACKGROUND_MODE, MIL.M_TRANSPARENT);

            // Print a white string in the overlay image buffer.
            MIL.MgraColor(defaultGraphicContext, MIL.M_COLOR_WHITE);
            MIL.MgraText(defaultGraphicContext, milOverlayImage, imageWidth / 9, imageHeight / 5, " -------------------- ");
            MIL.MgraText(defaultGraphicContext, milOverlayImage, imageWidth / 9, imageHeight / 5 + 25, " - MIL Overlay Text - ");
            MIL.MgraText(defaultGraphicContext, milOverlayImage, imageWidth / 9, imageHeight / 5 + 50, " -------------------- ");

            // Print a green string in the overlay image buffer.
            MIL.MgraColor(defaultGraphicContext, MIL.M_COLOR_GREEN);
            MIL.MgraText(defaultGraphicContext, milOverlayImage, imageWidth * 11 / 18, imageHeight / 5, " ---------------------");
            MIL.MgraText(defaultGraphicContext, milOverlayImage, imageWidth * 11 / 18, imageHeight / 5 + 25, " - MIL Overlay Text - ");
            MIL.MgraText(defaultGraphicContext, milOverlayImage, imageWidth * 11 / 18, imageHeight / 5 + 50, " ---------------------");

            // Draw GDI color overlay annotation.
            //***********************************

            // The next control might not be supported
            MIL.MappControl(MIL.M_DEFAULT, MIL.M_ERROR, MIL.M_PRINT_DISABLE);

            // Create a device context to draw in the overlay buffer with GDI.
            MIL.MbufControl(milOverlayImage, MIL.M_DC_ALLOC, MIL.M_DEFAULT);

            // Inquire the device context.
            hCustomDC = (IntPtr)MIL.MbufInquire(milOverlayImage, MIL.M_DC_HANDLE, MIL.M_NULL);

            MIL.MappControl(MIL.M_DEFAULT, MIL.M_ERROR, MIL.M_PRINT_ENABLE);

            if (hCustomDC == IntPtr.Zero)
            {
                return -1;
            }

            //3.利用Graphics对象画图
            using (Graphics g = Graphics.FromHdc(hCustomDC))
            {
                using (Pen pen = new Pen(color, penWidth))
                {
                    g.DrawRectangle(pen, posX, posY, width, height);
                }
            }

            //   // Delete device context.
            MIL.MbufControl(milOverlayImage, MIL.M_DC_FREE, MIL.M_DEFAULT);

            //   // Signal MIL that the overlay buffer was modified.
            MIL.MbufControl(milOverlayImage, MIL.M_MODIFIED, MIL.M_DEFAULT);
            return 0;
        }
    }
}