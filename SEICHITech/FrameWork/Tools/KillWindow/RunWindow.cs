using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Threading;
// 匯入 System.Diagnostics
using System.Diagnostics;
using System.Windows.Forms;

namespace KillWindow
{
    public static class RunWindow
    {
        //For Find Window To Kill, if you don't know what to set, try it
        public static string TEXT = "EnskyTools.KillWindow.RunWindow";

        /// <summary>
        /// When design new exe, there must define at least 1 argument for "Title" of window in the 1st parameter
        /// Here will auto set text to RunWindow.TEXT
        /// </summary>
        /// <param name="exeName">Exe file path</param>
        public static void RunProcess(string exeName)
        {
            //run an exe file in new process with TEXT
            RunProcess(exeName, TEXT);
        }

        /// <summary>
        /// When design new exe, there must define at least 1 argument for "Title" of window in the 1st parameter
        /// Here can choose a title text your self, and it will be set to the 1st argument
        /// </summary>
        /// <param name="exeName">Exe file path</param>
        /// <param name="text">Title text</param>
        public static void RunProcess(string exeName, string text)
        {
            //run an exe file in new process, with arguments
            RunProcess(exeName, text, "");
        }

        /// <summary>
        /// When design new exe, there must define at least 1 argument for "Title" of window in the 1st parameter
        /// </summary>
        /// <param name="exeName">Exe file path</param>
        /// <param name="text">Title text</param>
        /// <param name="arguments"></param>
        public static void RunProcess(string exeName, string text, string arguments)
        {
            //run an exe file in new process, with arguments
            Process.Start(exeName, text + " " + arguments);
        }

        /// <summary>
        /// Here will auto set form Text to RunWindow.TEXT
        /// </summary>
        /// <param name="form">window to show</param>
        public static void runFormDailog(Form form)
        {
            //set form title to RunWindow.TEXT
            form.Text = TEXT;
            //show in current thread
            form.ShowDialog();
        }

        /// <summary>
        /// Here will set form Text to parameter text
        /// KillWindow method will kill the window according to Text
        /// </summary>
        /// <param name="form">window to show</param>
        /// <param name="text">form text to set</param>
        public static void runFormDailog(Form form, string text)
        {
            //set form title to RunWindow.TEXT
            form.Text = text;
            //show in current thread
            form.ShowDialog();
        }

        /// <summary>
        /// Here will auto set form Text to RunWindow.TEXT
        /// KillWindow method will kill the window according to form Text
        /// </summary>
        /// <param name="form"></param>
        public static void runForm(Form form)
        {
            //set form title to RunWindow.TEXT
            form.Text = TEXT;
            //show in new thread
            form.Show();
        }

        /// <summary>
        /// Here will set form Text to parameter text
        /// KillWindow method will kill the window according to form Text
        /// </summary>
        /// <param name="form"></param>
        public static void runForm(Form form, string text)
        {
            //set form title to RunWindow.TEXT
            form.Text = text;
            //show in new thread
            form.Show();
        }
    }
}