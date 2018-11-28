using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public enum WriteLogType
    {
        Normal,
        Action,
        Warning,
        Error
    }

    public delegate void DelegateShowLog(string msg, WriteLogType LogType, Exception ex = null);
}