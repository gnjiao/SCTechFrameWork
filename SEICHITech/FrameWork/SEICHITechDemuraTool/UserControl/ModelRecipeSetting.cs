using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
using System.Xml;
using System.Xml.Linq;
using System.Reflection;
using HardWareInterFaces;
using Common;

namespace SEICHITechDemuraTool
{
    public partial class ModelRecipeSetting : UserControl, IlogPrinter
    {
        public static bool bFirstTime = false;
        public Context context;
        public int RecIndex;
        public int PatIndex;

        public DelegateShowLog ShowLog { get; set; }

        public ModelRecipeSetting(DelegateShowLog LogPrinter)
        {
            InitializeComponent();
            this.ShowLog = LogPrinter;
            context = Context.GetInstance();
        }

        private void ModelRecipeSetting_Load(object sender, EventArgs e)
        {
            ShowRecipeData(context.ModuleRecipe);
        }

        private void ShowRecipeData(Recipe[] Modelrecipe)
        {
            RecIndex = 0;
            foreach (var item in Modelrecipe)
            {
                RecIndex = this.RecDataView.Rows.Add();
                this.RecDataView.Rows[RecIndex].Cells[0].Value = item.Name;
                this.RecDataView.Rows[RecIndex].Cells[1].Value = item.ModuleName;
                this.RecDataView.Rows[RecIndex].Cells[2].Value = item.TriggerWidth;
                this.RecDataView.Rows[RecIndex].Cells[3].Value = item.TriggerDelay;
                this.RecDataView.Rows[RecIndex].Cells[4].Value = item.Width;
                this.RecDataView.Rows[RecIndex].Cells[5].Value = item.Height;
                this.RecDataView.Rows[RecIndex].Cells[6].Value = item.PositionZ;
                this.RecDataView.Rows[RecIndex].Cells[7].Value = item.Count;
            }
            this.RecDataView.Refresh();
        }

        private void ShowPatternData(Pattern[] modelPattern)
        {
            if (PatIndex > 0)
            {
                CleanAllRows(DataViewType.Pattern);
            }
            PatIndex = 0;
            foreach (Pattern item in modelPattern)
            {
                PatIndex = this.PatternDataView.Rows.Add();
                this.PatternDataView.Rows[PatIndex].Cells[0].Value = item.Color;
                this.PatternDataView.Rows[PatIndex].Cells[1].Value = item.Gary;
                this.PatternDataView.Rows[PatIndex].Cells[2].Value = item.ExposureTime;
                this.PatternDataView.Rows[PatIndex].Cells[3].Value = item.Size;
                this.PatternDataView.Rows[PatIndex].Cells[4].Value = item.Threshold1;
                this.PatternDataView.Rows[PatIndex].Cells[5].Value = item.Threshold2;
                this.PatternDataView.Rows[PatIndex].Cells[6].Value = item.Threshold3;
                this.PatternDataView.Rows[PatIndex].Cells[7].Value = item.Threshold4;
                this.PatternDataView.Rows[PatIndex].Cells[8].Value = item.OffsetH;
                this.PatternDataView.Rows[PatIndex].Cells[9].Value = item.OffsetW;
                this.PatternDataView.Rows[PatIndex].Cells[10].Value = item.Scale;
            }
            this.PatternDataView.Refresh();
        }

        private void CleanAllRows(DataViewType CleanView)
        {
            int i = 0;
            if (CleanView == DataViewType.Pattern)
            {
                while (i >= 0)
                {
                    i = this.PatternDataView.RowCount - 1;
                    this.PatternDataView.Rows.Remove(this.PatternDataView.Rows[i]);
                    i--;
                }
            }
            else
            {
                while (i >= 0)
                {
                    i = this.RecDataView.RowCount - 1;
                    this.RecDataView.Rows.Remove(this.PatternDataView.Rows[i]);
                    i--;
                }
            }
        }

        private void RecDataView_SelectionChanged_1(object sender, EventArgs e)
        {
            int CurrentIndex = this.RecDataView.CurrentRow.Index;
            if (context.ModuleRecipe.Length <= CurrentIndex) return;
            ShowPatternData(context.ModuleRecipe[CurrentIndex].PatternArray);
        }

        private void AddRecBtn_Click(object sender, EventArgs e)
        {
            RecIndex = this.RecDataView.Rows.Add();
            bFirstTime = true;
        }

        private void DeletRecBtn_Click(object sender, EventArgs e)
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load("./Configurations/Recipe.xml");
            int selectrow = this.RecDataView.CurrentRow.Index;
            XmlNodeList xmlnode = xmldoc.SelectSingleNode("Recipes").ChildNodes;
            foreach (XmlNode xmlno in xmlnode)
            {
                XmlElement xmlele = (XmlElement)xmlno;
                if (xmlele.GetAttribute("Name") == this.RecDataView.Rows[selectrow].Cells[0].Value.ToString())
                {
                    xmlele.RemoveAll();
                    break;
                }
            }

            xmldoc.Save("./Configurations/Recipe1.xml");
            this.RecDataView.Rows.Remove(this.RecDataView.Rows[selectrow]);
        }

        private void AddPatBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (bFirstTime)
                {
                    CleanAllRows(DataViewType.Pattern);
                    PatIndex = 0;
                    bFirstTime = false;
                }
                if (this.RecDataView.Rows[RecIndex].Cells["Count"].Value != null)
                {
                    int Count = Convert.ToInt32(this.RecDataView.Rows[RecIndex].Cells["Count"].Value);

                    if (Count > PatIndex)
                    {
                        int i = PatIndex + 1;
                        for (; i < Count; i++)
                        {
                            PatIndex = this.PatternDataView.Rows.Add();
                        }
                    }
                    else
                    {
                        while (Count != (PatIndex + 1))
                        {
                            this.PatternDataView.Rows.Remove(this.PatternDataView.Rows[PatIndex]);
                            PatIndex--;
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void SetInBtn_Click(object sender, EventArgs e)
        {
            AddElement("Recipes", "Recipe", "Pattern");
        }

        private void AddElement(string RootElement, string AddElement, string ChildElement)
        {
            try
            {
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load("./Configurations/Recipe.xml");
                XmlNode root = xmldoc.SelectSingleNode(RootElement);
                XmlElement xmlelem = xmldoc.CreateElement(AddElement);

                for (int i = 0; i < this.RecDataView.Columns.Count; i++)
                {
                    string ElemAttribute = this.RecDataView.Columns[i].HeaderText;
                    string AttValue = this.RecDataView.Rows[RecIndex].Cells[i].Value.ToString();
                    xmlelem.SetAttribute(ElemAttribute, AttValue);
                }
                if (this.PatternDataView.Rows.Count > 0)
                {
                    for (int j = 0; j < this.PatternDataView.Rows.Count; j++)
                    {
                        XmlElement xmlchildElem = xmldoc.CreateElement(ChildElement);
                        for (int n = 0; n < 4; n++)
                        {
                            string childElemAttr = this.PatternDataView.Columns[n].HeaderText;
                            string ChildAttrValue = this.PatternDataView.Rows[j].Cells[n].Value.ToString();
                            xmlchildElem.SetAttribute(childElemAttr, ChildAttrValue);
                        }
                        for (int i = 4; i < this.PatternDataView.Columns.Count; i++)
                        {
                            string ChildElem = this.PatternDataView.Columns[i].HeaderText;
                            string ChildElemValue = this.PatternDataView.Rows[PatIndex].Cells[i].Value.ToString();
                            AddChildElement(xmldoc, xmlchildElem, ChildElem, ChildElemValue);
                        }
                        xmlelem.AppendChild(xmlchildElem);
                    }
                }
                root.AppendChild(xmlelem);
                xmldoc.Save("./Configurations/Recipe1.xml");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void AddChildElement(XmlDocument xmldoc, XmlElement xmlelem, string ChildElement, string Value)
        {
            XmlElement xmlchildElem = xmldoc.CreateElement(ChildElement);
            xmlchildElem.InnerText = Value;
            xmlelem.AppendChild(xmlchildElem);
        }

        private void ModifyRecBtn_Click(object sender, EventArgs e)
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load("./Configurations/Recipe.xml");
            XmlNodeList xmlelem = xmldoc.SelectSingleNode("Recipes").ChildNodes;

            int SelectIndex = this.RecDataView.CurrentRow.Index;
            Recipe ModifyItem = context.ModuleRecipe[SelectIndex];
            Type itemTp = ModifyItem.GetType();
            for (int i = 0; i < this.RecDataView.Columns.Count; i++)
            {
                foreach (PropertyInfo pro in itemTp.GetProperties())
                {
                    string HeadText = this.RecDataView.Columns[i].HeaderText;
                    string CellValue = this.RecDataView.Rows[SelectIndex].Cells[i].Value.ToString();
                    string provalue = pro.GetValue(ModifyItem, null).ToString();
                    if (pro.Name == HeadText && provalue != CellValue)
                    {
                        ModifyElementValue(xmlelem, HeadText, provalue, CellValue);
                    }
                }
            }
            xmldoc.Save("./Configurations/Recipe1.xml");
        }

        private void ModifyElementValue(XmlNodeList xmlEle, string ModifyName, string OldValue, string NewValue)
        {
            foreach (XmlNode xl in xmlEle)
            {
                XmlElement item = (XmlElement)xl;
                if (item.GetAttribute(ModifyName) == OldValue)
                {
                    item.SetAttribute(ModifyName, NewValue);
                }
            }
        }

        private void ModifyPatBtn_Click(object sender, EventArgs e)
        {
            string HeaderText = "";
            string CellValue = "";
            string ProValue = "";
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load("./Configurations/Recipe.xml");
            XmlNodeList xmlelem = xmldoc.SelectSingleNode("Recipes").ChildNodes;
            //XmlNode xmlelems = (XmlNode)xmldoc.SelectSingleNode("//Recipe");
            int ChooseIndex = this.RecDataView.CurrentRow.Index;
            int Count = this.PatternDataView.Rows.Count;
            //foreach (Pattern SinglePatt in context.ModuleRecipe[ChooseIndex].PatternArray)
            //{
            //}
            for (int i = 0; i < Count; i++)
            {
                Pattern SinglePattern = context.ModuleRecipe[ChooseIndex].PatternArray[i];
                Type PatternTp = SinglePattern.GetType();
                foreach (PropertyInfo Pro in PatternTp.GetProperties())
                {
                    for (int j = 0; j < 4; j++)
                    {
                        HeaderText = this.PatternDataView.Columns[j].HeaderText;
                        CellValue = this.PatternDataView.Rows[i].Cells[j].Value.ToString();
                        ProValue = Pro.GetValue(SinglePattern, null).ToString();
                        if (Pro.Name == HeaderText && ProValue != CellValue)
                        {
                            //ModifyElementValue(xmlelem, HeaderText, ProValue, CellValue);

                            foreach (XmlNode xl in xmlelem)
                            {
                                XmlNodeList xmllist = xl.ChildNodes;
                                foreach (XmlNode single in xl.ChildNodes)
                                {
                                    XmlElement item = (XmlElement)single;
                                    if (item.GetAttribute(HeaderText) == ProValue)
                                    {
                                        item.SetAttribute(HeaderText, CellValue);
                                    }
                                }
                            }
                        }
                    }
                    for (int n = 4; n < this.PatternDataView.Columns.Count; n++)
                    {
                        HeaderText = this.PatternDataView.Columns[n].HeaderText;
                        CellValue = this.PatternDataView.Rows[i].Cells[n].Value.ToString();
                        ProValue = Pro.GetValue(SinglePattern, null).ToString();
                        if (Pro.Name == HeaderText && ProValue != CellValue)
                        {
                            foreach (XmlNode xl in xmlelem)
                            {
                                XmlNodeList xmllist = xl.ChildNodes;
                                foreach (XmlNode single in xl.ChildNodes)
                                {
                                    foreach (XmlNode item in single.ChildNodes)
                                    {
                                        XmlElement value = (XmlElement)item;
                                        if (value.Name == HeaderText)
                                        {
                                            item.InnerText = CellValue;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            xmldoc.Save("./Configurations/Recipe1.xml");
        }

        private void DeletPatBtn_Click(object sender, EventArgs e)
        {
            int index = this.PatternDataView.CurrentRow.Index;

            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load("./Configurations/Recipe.xml");
            XmlNodeList xmlnodls = xmldoc.SelectSingleNode("Recipes").ChildNodes;
            foreach (XmlNode xmlnode in xmlnodls)
            {
                foreach (XmlNode xmlno in xmlnode.ChildNodes)
                {
                    foreach (XmlNode item in xmlno.ChildNodes)
                    {
                        XmlElement xmlel = (XmlElement)item;
                        if (xmlel.LastChild.Value == this.PatternDataView.Rows[index].Cells[10].Value.ToString())
                        {
                            xmlno.RemoveAll();
                            break;
                        }
                    }
                }
            }
            xmldoc.Save("./Configurations/Recipe1.xml");
            this.PatternDataView.Rows.Remove(this.PatternDataView.Rows[index]);
        }
    }

    public enum DataViewType
    {
        Recipe,
        Pattern
    }
}