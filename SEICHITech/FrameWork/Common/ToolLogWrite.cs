using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class ToolLogWrite
    {
        private StreamWriter strWrite;
        private const string CaseLogFolder = "Case_Log/";
        private const string ErrorLogFoler = "ErrorCode_Log/";

        public ToolLogWrite(bool bPass, string LogFileFolderPath)
        {
            try
            {
                string FilePath = "";
                string filename = DateTime.Now.ToString("yyyyMMdd_HHmm") + ".txt";
                if (bPass)
                {
                    if (!Directory.Exists(CaseLogFolder))
                    {
                        Directory.CreateDirectory(CaseLogFolder);
                    }
                    FilePath = CaseLogFolder + LogFileFolderPath + filename;
                }
                else
                {
                    if (!Directory.Exists(ErrorLogFoler))
                    {
                        Directory.CreateDirectory(ErrorLogFoler);
                    }
                    FilePath = ErrorLogFoler + LogFileFolderPath + filename;
                }
                FileStream filestr = new FileStream(FilePath, FileMode.Create);
                strWrite = new StreamWriter(filestr, Encoding.UTF8);
                strWrite.AutoFlush = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void WriteLog(string LogContext)
        {
            strWrite.Write(LogContext);
        }

        public void CloseLogFile()
        {
            strWrite.Close();
        }
    }
}