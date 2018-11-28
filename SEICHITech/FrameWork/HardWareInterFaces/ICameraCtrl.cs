using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardWareInterFaces
{
    public interface ICameraCtrl
    {
        int Init(int camIndex);

        int StartCameraShow(IntPtr Handle);

        int Captrue(string fileName = "");
    }
}