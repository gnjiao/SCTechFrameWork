using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using Model;
using Common;
using System.Diagnostics;

namespace SEICHITechDemuraTool
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        private static void Main()
        {
            string ConfigPath = ConfigurationManager.AppSettings["ModelConfigurationPath"];
            LoadXML(ConfigPath);
            bool CheckRunning = CheckToolProcess(Context.GetInstance().GeneralInformation.Name);
            if (!CheckRunning)
            {
                MessageBox.Show("软件已经打开请检查！", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainForm maiform = new MainForm();
            maiform.Text = Context.GetInstance().GeneralInformation.Name;
            Application.Run(maiform);
        }

        /// <summary>
        /// 加载需要的xml文档信息
        /// </summary>
        /// <param name="Path">xml文档路径</param>
        private static void LoadXML(string Path)
        {
            Context context = Context.GetInstance();
            try
            {
                ModelGeneralInformation GeneralInfomation = XMLSerializeHelper.DeserializeXML<ModelGeneralInformation>(Path);
                context.GeneralInformation = GeneralInfomation;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 判断是否存在多个执行档；
        /// </summary>
        /// <param name="ProcessName">检测tool名称</param>
        /// <returns></returns>
        private static bool CheckToolProcess(string ProcessName)
        {
            Process[] process = Process.GetProcessesByName(ProcessName);
            if (process.Length > 1)
            {
                return false;
            }
            return true;
        }
    }
}