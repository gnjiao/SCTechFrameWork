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
    public partial class FunctionModules
    {
        private SingleFunctionModule[] singleFunctionModuleField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SingleFunctionModule")]
        public SingleFunctionModule[] SingleFunctionModule
        {
            get
            {
                return this.singleFunctionModuleField;
            }
            set
            {
                this.singleFunctionModuleField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class SingleFunctionModule
    {
        private string loadingPanelField;

        private string nameField;

        /// <remarks/>
        public string LoadingPanel
        {
            get
            {
                return this.loadingPanelField;
            }
            set
            {
                this.loadingPanelField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
    }
}