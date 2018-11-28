using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class ModelGeneralInformation
    {
        public string Name { get; set; }
        public string Version { get; set; }
        public string StationName { get; set; }
        public string TestFileName { get; set; }
        public string ControlCardFileName { get; set; }
        public string IOCardFileName { get; set; }
        public string PanelStationCount { get; set; }
        public string LoopTest { get; set; }
        public string IsStartButtonVisiable { get; set; }
        public string FormSkin { get; set; }
        public string TestStartModel { get; set; }
        public string ActionFileName { get; set; }
        public string CameraConfigFileName { get; set; }
        public string AddNewModules { get; set; }
        public string ModelRecipeFileName { get; set; }
    }

    public enum StartModelType
    {
        AutoWithoutRead,
        AutoReadByScan,
        AutoReadByReceiver,
        ManualRead
    }
}