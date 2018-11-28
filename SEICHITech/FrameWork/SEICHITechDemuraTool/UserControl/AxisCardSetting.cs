using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using Model;
using HardWareInterFaces;
using Common;

namespace SEICHITechDemuraTool
{
    public partial class AxisCardSetting : UserControl, IlogPrinter
    {
        private static XmlDocument xmldoc;
        private static string Strselectitem;
        private string AxisXmlPath;
        private List<XmlElement> AxisNodeLs = new List<XmlElement>();

        public DelegateShowLog ShowLog { get; set; }

        public AxisCardSetting(DelegateShowLog LogPrinter)
        {
            InitializeComponent();
            this.ShowLog = LogPrinter;
            AxisXmlPath = Path.GetFullPath("./Configurations/" + Context.GetInstance().GeneralInformation.ControlCardFileName);
            GetXmlInformation(AxisXmlPath, "ControlCards", "AxisCard");
            foreach (var axisinfoNode in AxisNodeLs)
            {
                this.AxisComBox.Items.Add(axisinfoNode.Attributes["Name"].Value);
            }
        }

        private void GetXmlInformation(string Path, string RootElement, string NodeName)
        {
            try
            {
                xmldoc = new XmlDocument();
                xmldoc.Load(Path);
                XmlNode xmlroot = xmldoc.SelectSingleNode(RootElement);
                XmlNodeList xmlNodLs = xmlroot.ChildNodes;
                foreach (XmlNode XNode in xmlNodLs)
                {
                    XmlElement XmlEle = (XmlElement)XNode;
                    if (XmlEle.LocalName == NodeName)
                    {
                        AxisNodeLs.Add(XmlEle);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void ShowAxisInfoInForm(string SelectAxisName)
        {
            this.AxisCfgGp.Controls.Clear();
            int Height = 35;
            for (int i = 0; i < AxisNodeLs.Count; i++)
            {
                XmlNodeList xmlnodls = AxisNodeLs[i].ChildNodes;

                if (AxisNodeLs[i].GetAttribute("Name") == SelectAxisName)
                {
                    foreach (XmlNode item in xmlnodls)
                    {
                        Label lab = new Label();
                        lab.Size = new Size(100, 30);
                        lab.Location = new Point(40, Height);
                        lab.Text = item.LocalName + ":";
                        TextBox txtbox = new TextBox();
                        txtbox.Name = item.LocalName;
                        txtbox.Location = new Point(200, Height);
                        txtbox.Size = new Size(120, 25);
                        txtbox.Text = item.InnerText;
                        this.AxisCfgGp.Controls.Add(lab);
                        this.AxisCfgGp.Controls.Add(txtbox);
                        Height += 30;
                    }
                }
            }
        }

        private void AxisComBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Strselectitem = this.AxisComBox.SelectedItem.ToString();
            ShowAxisInfoInForm(Strselectitem);
        }

        private void SvAxisCfgBtn_Click(object sender, EventArgs e)
        {
            if (xmldoc == null)
            {
                GetXmlInformation(AxisXmlPath, "ControlCards", "AxisCard");
            }
            foreach (Control Ctrl in this.AxisCfgGp.Controls)
            {
                if (Ctrl is TextBox)
                {
                    foreach (XmlNode Axisinfo in AxisNodeLs)
                    {
                        XmlElement axisinfoma = (XmlElement)Axisinfo;
                        if (axisinfoma.GetAttribute("Name") != Strselectitem)
                            continue;
                        XmlNodeList xmlls = Axisinfo.ChildNodes;
                        foreach (XmlNode Node in xmlls)
                        {
                            if (Ctrl.Name != Node.Name)
                                continue;
                            Node.InnerText = Ctrl.Text;
                            break;
                        }
                    }
                }
            }
            xmldoc.Save(AxisXmlPath);
        }

        private void RestoreBtn_Click(object sender, EventArgs e)
        {
            if (xmldoc == null)
            {
                GetXmlInformation(AxisXmlPath, "ControlCards", "AxisCard");
            }
            ShowAxisInfoInForm(Strselectitem);
        }
    }
}