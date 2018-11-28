namespace SEICHITechDemuraTool
{
    partial class ModelRecipeSetting
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.RecDataView = new System.Windows.Forms.DataGridView();
            this.RecipeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModuleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TriggerWidth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TriggerDelay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Width = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Height = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PositionZ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeletRecBtn = new System.Windows.Forms.Button();
            this.ModifyRecBtn = new System.Windows.Forms.Button();
            this.AddRecBtn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.PatternDataView = new System.Windows.Forms.DataGridView();
            this.Color = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExposureTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PatternSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Threshold1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Threshold2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Threshold3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Threshold4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OffsetH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OffsetW = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Scale = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SetInBtn = new System.Windows.Forms.Button();
            this.AddPatBtn = new System.Windows.Forms.Button();
            this.DeletPatBtn = new System.Windows.Forms.Button();
            this.ModifyPatBtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RecDataView)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PatternDataView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1200, 245);
            this.panel1.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.RecDataView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.DeletRecBtn);
            this.splitContainer1.Panel2.Controls.Add(this.ModifyRecBtn);
            this.splitContainer1.Panel2.Controls.Add(this.AddRecBtn);
            this.splitContainer1.Size = new System.Drawing.Size(1200, 245);
            this.splitContainer1.SplitterDistance = 1067;
            this.splitContainer1.TabIndex = 0;
            // 
            // RecDataView
            // 
            this.RecDataView.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.RecDataView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.RecDataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RecDataView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RecipeName,
            this.ModuleName,
            this.TriggerWidth,
            this.TriggerDelay,
            this.Width,
            this.Height,
            this.PositionZ,
            this.Count});
            this.RecDataView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RecDataView.Location = new System.Drawing.Point(0, 0);
            this.RecDataView.Name = "RecDataView";
            this.RecDataView.RowTemplate.Height = 23;
            this.RecDataView.Size = new System.Drawing.Size(1067, 245);
            this.RecDataView.TabIndex = 4;
            this.RecDataView.SelectionChanged += new System.EventHandler(this.RecDataView_SelectionChanged_1);
            // 
            // RecipeName
            // 
            this.RecipeName.HeaderText = "Name";
            this.RecipeName.Name = "RecipeName";
            this.RecipeName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.RecipeName.Width = 140;
            // 
            // ModuleName
            // 
            this.ModuleName.HeaderText = "ModuleName";
            this.ModuleName.Name = "ModuleName";
            this.ModuleName.Width = 140;
            // 
            // TriggerWidth
            // 
            this.TriggerWidth.HeaderText = "TriggerWidth";
            this.TriggerWidth.Name = "TriggerWidth";
            this.TriggerWidth.Width = 120;
            // 
            // TriggerDelay
            // 
            this.TriggerDelay.HeaderText = "TriggerDelay";
            this.TriggerDelay.Name = "TriggerDelay";
            this.TriggerDelay.Width = 120;
            // 
            // Width
            // 
            this.Width.HeaderText = "Width";
            this.Width.Name = "Width";
            this.Width.Width = 120;
            // 
            // Height
            // 
            this.Height.HeaderText = "Height";
            this.Height.Name = "Height";
            this.Height.Width = 120;
            // 
            // PositionZ
            // 
            this.PositionZ.HeaderText = "PositionZ";
            this.PositionZ.Name = "PositionZ";
            this.PositionZ.Width = 120;
            // 
            // Count
            // 
            this.Count.HeaderText = "Count";
            this.Count.Name = "Count";
            this.Count.Width = 160;
            // 
            // DeletRecBtn
            // 
            this.DeletRecBtn.Location = new System.Drawing.Point(17, 164);
            this.DeletRecBtn.Name = "DeletRecBtn";
            this.DeletRecBtn.Size = new System.Drawing.Size(94, 23);
            this.DeletRecBtn.TabIndex = 6;
            this.DeletRecBtn.Text = "删除Recipe";
            this.DeletRecBtn.UseVisualStyleBackColor = true;
            this.DeletRecBtn.Click += new System.EventHandler(this.DeletRecBtn_Click);
            // 
            // ModifyRecBtn
            // 
            this.ModifyRecBtn.Location = new System.Drawing.Point(17, 103);
            this.ModifyRecBtn.Name = "ModifyRecBtn";
            this.ModifyRecBtn.Size = new System.Drawing.Size(94, 23);
            this.ModifyRecBtn.TabIndex = 5;
            this.ModifyRecBtn.Text = "修改Recipe";
            this.ModifyRecBtn.UseVisualStyleBackColor = true;
            this.ModifyRecBtn.Click += new System.EventHandler(this.ModifyRecBtn_Click);
            // 
            // AddRecBtn
            // 
            this.AddRecBtn.Location = new System.Drawing.Point(17, 53);
            this.AddRecBtn.Name = "AddRecBtn";
            this.AddRecBtn.Size = new System.Drawing.Size(94, 23);
            this.AddRecBtn.TabIndex = 3;
            this.AddRecBtn.Text = "新增Recipe";
            this.AddRecBtn.UseVisualStyleBackColor = true;
            this.AddRecBtn.Click += new System.EventHandler(this.AddRecBtn_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.splitContainer2);
            this.panel2.Location = new System.Drawing.Point(3, 250);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1197, 390);
            this.panel2.TabIndex = 2;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.PatternDataView);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.SetInBtn);
            this.splitContainer2.Panel2.Controls.Add(this.AddPatBtn);
            this.splitContainer2.Panel2.Controls.Add(this.DeletPatBtn);
            this.splitContainer2.Panel2.Controls.Add(this.ModifyPatBtn);
            this.splitContainer2.Size = new System.Drawing.Size(1197, 390);
            this.splitContainer2.SplitterDistance = 1065;
            this.splitContainer2.TabIndex = 0;
            // 
            // PatternDataView
            // 
            this.PatternDataView.AllowUserToAddRows = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.PatternDataView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.PatternDataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PatternDataView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Color,
            this.Gary,
            this.ExposureTime,
            this.PatternSize,
            this.Threshold1,
            this.Threshold2,
            this.Threshold3,
            this.Threshold4,
            this.OffsetH,
            this.OffsetW,
            this.Scale});
            this.PatternDataView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PatternDataView.Location = new System.Drawing.Point(0, 0);
            this.PatternDataView.Name = "PatternDataView";
            this.PatternDataView.RowTemplate.Height = 23;
            this.PatternDataView.Size = new System.Drawing.Size(1065, 390);
            this.PatternDataView.TabIndex = 3;
            // 
            // Color
            // 
            this.Color.HeaderText = "Color";
            this.Color.Name = "Color";
            // 
            // Gary
            // 
            this.Gary.HeaderText = "Gary";
            this.Gary.Name = "Gary";
            // 
            // ExposureTime
            // 
            this.ExposureTime.HeaderText = "ExposureTime";
            this.ExposureTime.Name = "ExposureTime";
            // 
            // PatternSize
            // 
            this.PatternSize.HeaderText = "Size";
            this.PatternSize.Name = "PatternSize";
            // 
            // Threshold1
            // 
            this.Threshold1.HeaderText = "Threshold1";
            this.Threshold1.Name = "Threshold1";
            // 
            // Threshold2
            // 
            this.Threshold2.HeaderText = "Threshold2";
            this.Threshold2.Name = "Threshold2";
            // 
            // Threshold3
            // 
            this.Threshold3.HeaderText = "Threshold3";
            this.Threshold3.Name = "Threshold3";
            // 
            // Threshold4
            // 
            this.Threshold4.HeaderText = "Threshold4";
            this.Threshold4.Name = "Threshold4";
            // 
            // OffsetH
            // 
            this.OffsetH.HeaderText = "OffsetH";
            this.OffsetH.Name = "OffsetH";
            // 
            // OffsetW
            // 
            this.OffsetW.HeaderText = "OffsetW";
            this.OffsetW.Name = "OffsetW";
            // 
            // Scale
            // 
            this.Scale.HeaderText = "Scale";
            this.Scale.Name = "Scale";
            // 
            // SetInBtn
            // 
            this.SetInBtn.Location = new System.Drawing.Point(19, 271);
            this.SetInBtn.Name = "SetInBtn";
            this.SetInBtn.Size = new System.Drawing.Size(94, 23);
            this.SetInBtn.TabIndex = 7;
            this.SetInBtn.Text = "导入xml";
            this.SetInBtn.UseVisualStyleBackColor = true;
            this.SetInBtn.Click += new System.EventHandler(this.SetInBtn_Click);
            // 
            // AddPatBtn
            // 
            this.AddPatBtn.Location = new System.Drawing.Point(15, 58);
            this.AddPatBtn.Name = "AddPatBtn";
            this.AddPatBtn.Size = new System.Drawing.Size(94, 23);
            this.AddPatBtn.TabIndex = 4;
            this.AddPatBtn.Text = "新增Pattern";
            this.AddPatBtn.UseVisualStyleBackColor = true;
            this.AddPatBtn.Click += new System.EventHandler(this.AddPatBtn_Click);
            // 
            // DeletPatBtn
            // 
            this.DeletPatBtn.Location = new System.Drawing.Point(15, 199);
            this.DeletPatBtn.Name = "DeletPatBtn";
            this.DeletPatBtn.Size = new System.Drawing.Size(94, 23);
            this.DeletPatBtn.TabIndex = 6;
            this.DeletPatBtn.Text = "删除 Pattern";
            this.DeletPatBtn.UseVisualStyleBackColor = true;
            this.DeletPatBtn.Click += new System.EventHandler(this.DeletPatBtn_Click);
            // 
            // ModifyPatBtn
            // 
            this.ModifyPatBtn.Location = new System.Drawing.Point(15, 128);
            this.ModifyPatBtn.Name = "ModifyPatBtn";
            this.ModifyPatBtn.Size = new System.Drawing.Size(94, 23);
            this.ModifyPatBtn.TabIndex = 5;
            this.ModifyPatBtn.Text = "修改Pattern";
            this.ModifyPatBtn.UseVisualStyleBackColor = true;
            this.ModifyPatBtn.Click += new System.EventHandler(this.ModifyPatBtn_Click);
            // 
            // ModelRecipeSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Beige;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ModelRecipeSetting";
            this.Size = new System.Drawing.Size(1203, 644);
            this.Load += new System.EventHandler(this.ModelRecipeSetting_Load);
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RecDataView)).EndInit();
            this.panel2.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PatternDataView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridViewTextBoxColumn nSize;
        private System.Windows.Forms.DataGridView RecDataView;
        private System.Windows.Forms.DataGridViewTextBoxColumn RecipeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModuleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TriggerWidth;
        private System.Windows.Forms.DataGridViewTextBoxColumn TriggerDelay;
        private System.Windows.Forms.DataGridViewTextBoxColumn Width;
        private System.Windows.Forms.DataGridViewTextBoxColumn Height;
        private System.Windows.Forms.DataGridViewTextBoxColumn PositionZ;
        private System.Windows.Forms.DataGridViewTextBoxColumn Count;
        private System.Windows.Forms.Button DeletRecBtn;
        private System.Windows.Forms.Button ModifyRecBtn;
        private System.Windows.Forms.Button AddRecBtn;
        private System.Windows.Forms.DataGridView PatternDataView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Color;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gary;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExposureTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn PatternSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn Threshold1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Threshold2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Threshold3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Threshold4;
        private System.Windows.Forms.DataGridViewTextBoxColumn OffsetH;
        private System.Windows.Forms.DataGridViewTextBoxColumn OffsetW;
        private System.Windows.Forms.DataGridViewTextBoxColumn Scale;
        private System.Windows.Forms.Button SetInBtn;
        private System.Windows.Forms.Button AddPatBtn;
        private System.Windows.Forms.Button DeletPatBtn;
        private System.Windows.Forms.Button ModifyPatBtn;
    }
}
