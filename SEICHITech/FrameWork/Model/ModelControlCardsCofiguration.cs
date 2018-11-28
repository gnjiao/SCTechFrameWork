using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class ControlCards
    {
        /// <remarks/>
        public string ModuleInformation { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AxisCard")]
        public AxisCard[] AxisCard { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Type { get; set; }

    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class AxisCard
    {
        [System.Xml.Serialization.XmlElementAttribute("WorkPosition")]
        public int[] WorkPosition { get; set; }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int Num { get; set; }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name { get; set; }

        public int HomeModel { get; set; }
        
        public double PreMMPulse { get; set; }
        
        public double MinSpeed { get; set; }
        
        public double MaxSpeed { get; set; }
        
        public double DecSpeed { get; set; }
        
        public double AccSpeed { get; set; }

        public int MoveStyle { get; set; }

        public int HomeBackDis { get; set; }

    }
}