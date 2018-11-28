using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEICHITechDemuraTool
{
    public partial class AutoSplitContainer : UserControl
    {
        private List<SplitterPanel> LsSplitPanelCols = new List<SplitterPanel>();
        public List<SplitterPanel> LsSplitChildPanel = new List<SplitterPanel>();

        private int PanelRows;
        private int PanelCols;
        private int PanelHeight;
        private int PanelWidth;

        public AutoSplitContainer(int PanelCount)
        {
            InitializeComponent();
            int Rows = 0;
            int Cols = 0;
            int SqrtNum = (int)Math.Sqrt(PanelCount);
            if (Math.Abs(SqrtNum * SqrtNum - PanelCount) > Math.Abs((SqrtNum + 1) * (SqrtNum + 1) - PanelCount))
            {
                SqrtNum = SqrtNum + 1;
            }
            Rows = SqrtNum;
            Cols = PanelCount / Rows;
            while (Rows * Cols - PanelCount < 0)
            {
                Cols++;
            }
            InitalPanelPar(Rows, Cols);
            SplitContainerColCut();
        }

        public AutoSplitContainer(int PanelCount, CutStyle SplitStyle)
        {
            InitializeComponent();
            if (SplitStyle == CutStyle.RowCut)
            {
                PanelHeight = this.Height / PanelCount;
                PanelRows = PanelCount;
            }
            else
            {
                PanelWidth = this.Width / PanelCount;
                PanelCols = PanelCount;
            }
            SingleConditionCut(SplitStyle, PanelCount);
        }

        public void InitalPanelPar(int rows, int cols)
        {
            PanelRows = rows;
            PanelCols = cols;
            PanelHeight = this.Height / rows;
            PanelWidth = this.Width / cols;
        }

        public void SplitContainerColCut()
        {
            //动态生成splitcontainer 控件，且对panel2进行切割；将panel1保存在List中；
            SplitContainer PanelSpliter = new SplitContainer();
            this.Controls.Add(PanelSpliter);
            PanelCols--;
            PanelSpliter.Dock = DockStyle.Fill;
            PanelSpliter.Orientation = Orientation.Vertical;
            PanelSpliter.SplitterDistance = PanelWidth;

            LsSplitPanelCols.Add(PanelSpliter.Panel1);

            PanelColsCut(PanelSpliter.Panel2);

            SplitContainerRowCut();
        }

        public void PanelColsCut(SplitterPanel PanelCol)
        {
            //将Panel2再次切割；
            if (PanelCols <= 1)
            {
                LsSplitPanelCols.Add(PanelCol);
                return;
            }
            SplitContainer SplitPanelCol = new SplitContainer();
            PanelCol.Controls.Add(SplitPanelCol);
            SplitPanelCol.Dock = DockStyle.Fill;
            SplitPanelCol.Orientation = Orientation.Vertical;
            SplitPanelCol.SplitterDistance = PanelWidth;
            PanelCols--;

            LsSplitPanelCols.Add(SplitPanelCol.Panel1);

            PanelColsCut(SplitPanelCol.Panel2);
        }

        public void SplitContainerRowCut()
        {
            if (LsSplitPanelCols.Count <= 0)
            {
                return;
            }
            foreach (var SingleSplitPanel in LsSplitPanelCols)
            {
                PanelRowsCut(SingleSplitPanel, PanelRows);
            }
        }

        public void PanelRowsCut(SplitterPanel PanelRow, int LeftRowCount)
        {
            if (LeftRowCount <= 1)
            {
                LsSplitChildPanel.Add(PanelRow);
                return;
            }
            SplitContainer SplitPanelRow = new SplitContainer();
            PanelRow.Controls.Add(SplitPanelRow);
            SplitPanelRow.Dock = DockStyle.Fill;
            SplitPanelRow.Orientation = Orientation.Horizontal;
            SplitPanelRow.SplitterDistance = PanelHeight;
            LeftRowCount--;

            LsSplitChildPanel.Add(SplitPanelRow.Panel1);

            PanelRowsCut(SplitPanelRow.Panel2, LeftRowCount);
        }

        public void SingleConditionCut(CutStyle style, int CutCount)
        {
            switch (style)
            {
                case CutStyle.ColumnCut:
                    SplitContainer Colsplitter = new SplitContainer();
                    this.Controls.Add(Colsplitter);
                    Colsplitter.Dock = DockStyle.Fill;
                    Colsplitter.Orientation = Orientation.Vertical;
                    Colsplitter.SplitterDistance = PanelWidth;
                    LsSplitChildPanel.Add(Colsplitter.Panel1);
                    PanelCols--;
                    PanelColsCut(Colsplitter.Panel2);
                    break;

                case CutStyle.RowCut:
                    SplitContainer Rowsplitter = new SplitContainer();
                    this.Controls.Add(Rowsplitter);
                    Rowsplitter.Dock = DockStyle.Fill;
                    Rowsplitter.Orientation = Orientation.Horizontal;
                    Rowsplitter.SplitterDistance = PanelHeight;
                    LsSplitChildPanel.Add(Rowsplitter.Panel1);
                    CutCount--;
                    PanelRowsCut(Rowsplitter.Panel2, CutCount);
                    break;

                default:
                    break;
            }
        }
    }

    public enum CutStyle
    {
        ColumnCut,
        RowCut
    }
}