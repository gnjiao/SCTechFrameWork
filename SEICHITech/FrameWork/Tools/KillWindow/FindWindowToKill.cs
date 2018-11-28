using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KillWindow
{
    public static class FindWindowToKill
    {
        [DllImport("user32.dll", EntryPoint = "FindWindow", CharSet = CharSet.Auto)]
        public extern static IntPtr FindWindow(string className, string captionName);
        [DllImport("user32.dll", EntryPoint = "SendMessage", CharSet = CharSet.Auto)]
        public extern static int SendMessage(IntPtr hwd, int wMsg, int wParam, int lParam);

        /// <summary>
        /// Kill window in background after wait a while
        /// </summary>
        /// <param name="FormTitle">form title(Form.Text) to kill</param>
        /// <param name="waitTime">set second delay than to kill</param>
        public static void killWindowInBackground(string FormTitle, int waitTime)
        {
            //packet method "findWindowToKill" to delegate ParameterizedThreadStart
            ParameterizedThreadStart method = new ParameterizedThreadStart(WaitOrTimerCallback);

            //Initial a Thread for method
            Thread killWindowThread = new Thread(method);

            //start method on background
            killWindowThread.Start(new object[] { FormTitle, waitTime });
        }

        /// <summary>
        /// Wait a second to invoke callback function
        /// </summary>
        /// <param name="obj">array, [0]: string Form.Text, [1]: int for wait seconds</param>
        private static void WaitOrTimerCallback(object obj)
        {
            object[] objArray;
            if (!(obj is Array)) return;
            objArray = (object[])obj;

            if (!(objArray[0] is string) ||!(objArray[1] is int)) return;

            string text = (string)objArray[0];
            int s = (int)objArray[1];

            Thread.Sleep(s * 1000);

            killWindowInBackground(text);
        }

        /// <summary>
        /// kill window in background immediately
        /// </summary>
        /// <param name="FormTitle">Form Text to kill</param>
        public static void killWindowInBackground(string FormTitle)
        {
            //packet method "findWindowToKill" to delegate ParameterizedThreadStart
            ParameterizedThreadStart method = new ParameterizedThreadStart(findWindowToKill);

            //Initial a Thread for method
            Thread killWindowThread = new Thread(method);

            //start method on background
            killWindowThread.Start(FormTitle);
        }

        /// <summary>
        /// Overload findWindowToKill Method for Thread using
        /// </summary>
        /// <param name="FormTitle">string: Form Text to kill</param>
        private static void findWindowToKill(object FormTitle)
        {
            //Ensure the parameter FormTitle is a string instance
            if (FormTitle is string)
                findWindowToKill(FormTitle.ToString());
        }

        /// <summary>
        /// Find window by Form.Text than kill it
        /// </summary>
        /// <param name="FormTitle">Form Text to kill</param>
        public static void findWindowToKill(string FormTitle)
        {
            int times = 5; //retry times

            IntPtr WinHandle;
            while (times > 0) 
            {
                times--; //count killwindow times

                Thread.Sleep(1000); //Wait a while
                WinHandle = FindWindow(null, FormTitle); //Find Window By Form Text

                if (WinHandle == IntPtr.Zero) continue; //if find nothing

                SendMessage(WinHandle, 0x10, 0, 0); //Kill the target window, than break
                break;
            }
        }
    }
}
