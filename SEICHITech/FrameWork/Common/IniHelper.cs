using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Common
{
    public class IniHelper
    {
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string AppName, string KeyName, string Vaule, string filePath);

        [DllImport("kernel32")]
        public static extern int GetPrivateProfileString(string AppName, string KeyName, string defaultString, StringBuilder ret, int size, string filename);

        /// <summary>
        /// 获取INI文件中字符串
        /// </summary>
        /// <param name="AppName">段名</param>
        /// <param name="KeyName">键名</param>
        /// <param name="filepath">ini文件路径</param>
        /// <returns></returns>
        public static string GetIniString(string AppName, string KeyName, string filepath)
        {
            StringBuilder strb = new StringBuilder();
            int Value = GetPrivateProfileString(AppName, KeyName, "", strb, 255, filepath);
            return strb.ToString();
        }

        /// <summary>
        /// 写入字符串到ini文件
        /// </summary>
        /// <param name="AppName">段名</param>
        /// <param name="KeyName">键名</param>
        /// <param name="Value">写入的字符串</param>
        /// <param name="filepath">路径</param>
        public static void WriteIniString(string AppName, string KeyName, string Value, string filepath)
        {
            long Res = WritePrivateProfileString(AppName, KeyName, Value, filepath);
            if (Res == 0)
            {
                MessageBox.Show($"{filepath}--写入{Value}失败！！");
            }
        }
    }
}