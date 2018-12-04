using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class FTPDataHelper
    {
        public static List<string> GetFileNameFromFtp(string FTPPath, string FilePath, string username, string password, string KeyWord, int CutIndex)
        {
            List<string> strs = new List<string>();
            try
            {
                string uri = FTPPath + FilePath;  //目标路径 path为服务器地址
                FtpWebRequest reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri));
                // ftp用户名和密码
                reqFTP.Credentials = new NetworkCredential(username, password);
                reqFTP.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                reqFTP.Timeout = 3000;
                WebResponse response = reqFTP.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());//中文文件名

                string line = reader.ReadLine();
                while (line != null)
                {
                    if (line.Contains(KeyWord))
                    {
                        string msg = line.Substring(CutIndex).Trim();
                        if (KeyWord == ".lua")
                        {
                            msg = msg.Replace(KeyWord, "").Trim();
                        }
                        strs.Add(msg);
                    }
                    line = reader.ReadLine();
                }
                reader.Close();
                response.Close();
                return strs;
            }
            catch (Exception ex)
            {
                Console.WriteLine("获取文件出错：" + ex.Message);
            }
            return strs;
        }
    }
}