using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardWareInterFaces
{
    public interface ICameraCtrl
    {
        /// <summary>
        /// 相机画幅宽度
        /// </summary>
        int Width {   get; }
        /// <summary>
        /// 相机画幅高度
        /// </summary>
        int Height {   get; }

        /// <summary>
        /// 相机初始化方法
        /// </summary>
        /// <param name="camIndex"></param>
        /// <returns></returns>
        int Init(int camIndex=0);
        /// <summary>
        /// 相机开始显示方法
        /// </summary>
        /// <param name="Handle">相机画面显示到控件的句柄</param>
        /// <returns></returns>
        int StartCameraShow(IntPtr Handle);
        /// <summary>
        /// 相机拍照
        /// </summary>
        /// <param name="fileName">拍照文件保存路径</param>
        /// <returns></returns>
        int Grab(string fileName = "");

    }
}