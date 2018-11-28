using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;
using Model;

namespace WorkAction
{
    public interface IAction
    {
        DelegateShowLog PrinterLog { get; set; }
        bool InitialHardWare();
        bool PreAction();
        void FixtureReset(AxisCard[] axisinfo);
        bool PostAction();
    }
}
