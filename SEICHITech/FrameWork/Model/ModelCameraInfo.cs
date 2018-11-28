using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class SlaveServers
    {
        /// <remarks/>
        public string MethodInfo { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("CameraConfig")]
        public CameraConfig[] CameraConfig { get; set; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class CameraConfig
    {
        /// <remarks/>
        public bool Enable { get; set; }

        /// <remarks/>
        public string CameraIP { get; set; }

        /// <remarks/>
        public ushort CameraPort { get; set; }

        /// <remarks/>
        public string PG_P_IP { get; set; }

        /// <remarks/>
        public string PG_S_IP { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Position { get; set; }
    }


}
