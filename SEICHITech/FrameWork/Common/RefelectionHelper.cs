using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class RefelectionHelper
    {
        public static T CreatRefelectObj<T>(string DllFileName, string ClassFileName)
        {
            T obj = default(T);
            string DllFilePath = "";
            try
            {
                if (!File.Exists(DllFileName))
                    throw new Exception();

                DllFilePath = Path.GetFullPath(DllFileName);

                Assembly ObjAss = Assembly.LoadFrom(DllFilePath);

                if (ObjAss == null)
                    throw new Exception();

                Type ClassObj = ObjAss.GetType(ClassFileName);
                obj = (T)Activator.CreateInstance(ClassObj);

                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}