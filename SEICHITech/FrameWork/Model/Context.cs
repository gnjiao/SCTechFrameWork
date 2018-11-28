using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Context
    {
        private static Context Instance;
        public ModelGeneralInformation GeneralInformation { get; set; }
        public ControlCards ControlCard { get; set; }
        public SlaveServers SlaveServerConfig { get; set; }
        public Recipe[] ModuleRecipe { get; set; }

        public static Context GetInstance()
        {
            if (Instance == null)
            {
                Instance = new Context();
            }
            return Instance;
        }
    }
}