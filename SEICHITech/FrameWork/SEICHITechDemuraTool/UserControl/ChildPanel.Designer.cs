namespace SEICHITechDemuraTool
{
    partial class ChildPanel
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.ChildsplitContainer = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TestItemDGV = new System.Windows.Forms.DataGridView();
            this.NameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ResColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.LogrichTextBox = new System.Windows.Forms.RichTextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.SNtxtBox = new System.Windows.Forms.TextBox();
            this.StartBtn = new System.Windows.Forms.Button();
            this.LocationLb = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ChildsplitContainer)).BeginInit();
            this.ChildsplitContainer.Panel1.SuspendLayout();
            this.ChildsplitContainer.Panel2.SuspendLayout();
            this.ChildsplitContainer.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TestItemDGV)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // ChildsplitContainer
            // 
            this.ChildsplitContainer.BackColor = System.Drawing.Color.Beige;
            this.ChildsplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChildsplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.ChildsplitContainer.Location = new System.Drawing.Point(0, 0);
            this.ChildsplitContainer.Name = "ChildsplitContainer";
            // 
            // ChildsplitContainer.Panel1
            // 
            this.ChildsplitContainer.Panel1.BackColor = System.Drawing.SystemColors.Highlight;
            this.ChildsplitContainer.Panel1.Controls.Add(this.panel1);
            this.ChildsplitContainer.Panel1.Controls.Add(this.panel2);
            // 
            // ChildsplitContainer.Panel2
            // 
            this.ChildsplitContainer.Panel2.BackColor = System.Drawing.SystemColors.Highlight;
            this.ChildsplitContainer.Panel2.Controls.Add(this.panel4);
            this.ChildsplitContainer.Panel2.Controls.Add(this.panel3);
            this.ChildsplitContainer.Size = new System.Drawing.Size(708, 394);
            this.ChildsplitContainer.SplitterDistance = 295;
            this.ChildsplitContainer.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.SystemColors.Desktop;
            this.panel1.Controls.Add(this.TestItemDGV);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 56);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(295, 338);
            this.panel1.TabIndex = 4;
            // 
            // TestItemDGV
            // 
            this.TestItemDGV.AllowUserToAddRows = false;
            this.TestItemDGV.AllowUserToDeleteRows = false;
            this.TestItemDGV.AllowUserToResizeRows = false;
            this.TestItemDGV.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.TestItemDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TestItemDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NameColumn,
            this.ResColumn,
            this.StatusColumn});
            this.TestItemDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TestItemDGV.Location = new System.Drawing.Point(0, 0);
            this.TestItemDGV.MultiSelect = false;
            this.TestItemDGV.Name = "TestItemDGV";
            this.TestItemDGV.ReadOnly = true;
            this.TestItemDGV.RowHeadersVisible = false;
            this.TestItemDGV.RowTemplate.Height = 23;
            this.TestItemDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.TestItemDGV.Size = new System.Drawing.Size(295, 338);
            this.TestItemDGV.TabIndex = 3;
            // 
            // NameColumn
            // 
            this.NameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.NameColumn.Frozen = true;
            this.NameColumn.HeaderText = "Name";
            this.NameColumn.Name = "NameColumn";
            this.NameColumn.ReadOnly = true;
            this.NameColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NameColumn.Width = 150;
            // 
            // ResColumn
            // 
            this.ResColumn.HeaderText = "Result";
            this.ResColumn.Name = "ResColumn";
            this.ResColumn.ReadOnly = true;
            this.ResColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ResColumn.Width = 70;
            // 
            // StatusColumn
            // 
            this.StatusColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.StatusColumn.HeaderText = "Status";
            this.StatusColumn.Name = "StatusColumn";
            this.StatusColumn.ReadOnly = true;
            this.StatusColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(295, 56);
            this.panel2.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label3.Dock = System.Windows.Forms.DockStyle.Right;
            this.label3.Location = new System.Drawing.Point(94, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 56);
            this.label3.TabIndex = 13;
            this.label3.Text = "PG状态";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Desktop;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 56);
            this.label1.TabIndex = 10;
            this.label1.Text = "Demura状态";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.Highlight;
            this.label2.Dock = System.Windows.Forms.DockStyle.Right;
            this.label2.Location = new System.Drawing.Point(198, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 56);
            this.label2.TabIndex = 12;
            this.label2.Text = "测试结果";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel4.Controls.Add(this.LogrichTextBox);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 55);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(409, 339);
            this.panel4.TabIndex = 10;
            // 
            // LogrichTextBox
            // 
            this.LogrichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogrichTextBox.Location = new System.Drawing.Point(0, 0);
            this.LogrichTextBox.Name = "LogrichTextBox";
            this.LogrichTextBox.Size = new System.Drawing.Size(409, 339);
            this.LogrichTextBox.TabIndex = 9;
            this.LogrichTextBox.Text = "";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panel3.Controls.Add(this.SNtxtBox);
            this.panel3.Controls.Add(this.StartBtn);
            this.panel3.Controls.Add(this.LocationLb);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(409, 55);
            this.panel3.TabIndex = 6;
            // 
            // SNtxtBox
            // 
            this.SNtxtBox.Location = new System.Drawing.Point(120, 16);
            this.SNtxtBox.Name = "SNtxtBox";
            this.SNtxtBox.Size = new System.Drawing.Size(153, 21);
            this.SNtxtBox.TabIndex = 1;
            // 
            // StartBtn
            // 
            this.StartBtn.Location = new System.Drawing.Point(314, 16);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(75, 23);
            this.StartBtn.TabIndex = 2;
            this.StartBtn.Text = "开始";
            this.StartBtn.UseVisualStyleBackColor = true;
            this.StartBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // LocationLb
            // 
            this.LocationLb.Dock = System.Windows.Forms.DockStyle.Top;
            this.LocationLb.Font = new System.Drawing.Font("楷体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LocationLb.Location = new System.Drawing.Point(0, 0);
            this.LocationLb.Name = "LocationLb";
            this.LocationLb.Size = new System.Drawing.Size(409, 55);
            this.LocationLb.TabIndex = 0;
            this.LocationLb.Text = " Test Case Log：";
            this.LocationLb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ChildPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ChildsplitContainer);
            this.Name = "ChildPanel";
            this.Size = new System.Drawing.Size(708, 394);
            this.ChildsplitContainer.Panel1.ResumeLayout(false);
            this.ChildsplitContainer.Panel1.PerformLayout();
            this.ChildsplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ChildsplitContainer)).EndInit();
            this.ChildsplitContainer.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TestItemDGV)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer ChildsplitContainer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView TestItemDGV;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button StartBtn;
        private System.Windows.Forms.TextBox SNtxtBox;
        private System.Windows.Forms.Label LocationLb;
        private System.Windows.Forms.RichTextBox LogrichTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ResColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusColumn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel4;
    }
}
