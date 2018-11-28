using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardWareInterFaces
{
    public interface IDeMura
    {
        /// <summary>
        /// 控制相机的接口对象
        /// </summary>
        ICameraCtrl CameraControl { set; get; }

        /// <summary>
        /// 控制PG的接口对象
        /// </summary>
        IPGCtrl PGControl { set; get; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <param name="dataSaveFile"></param>
        /// <returns></returns>
        int Capture(int r, int g, int b, string dataSaveFile);

        int GenerateBin(string fileName);

        int DeMuraFlashWrite(string fileName);
    }
}