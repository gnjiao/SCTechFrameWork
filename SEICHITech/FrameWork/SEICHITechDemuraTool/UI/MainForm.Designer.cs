namespace SEICHITechDemuraTool
{
    partial class MainForm
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine();
            this.DemuraSetMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ProjSetMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ManualTestMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.MaunalModelMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AutoManualMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainsplitContainer = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnDmrSer = new System.Windows.Forms.Button();
            this.btnaxisLog = new System.Windows.Forms.Button();
            this.RatetxtBox = new System.Windows.Forms.TextBox();
            this.SignpictureBox = new System.Windows.Forms.PictureBox();
            this.RateLb = new System.Windows.Forms.Label();
            this.TotaltxtBox = new System.Windows.Forms.TextBox();
            this.TotalLb = new System.Windows.Forms.Label();
            this.FailLb = new System.Windows.Forms.Label();
            this.FailtxtBox = new System.Windows.Forms.TextBox();
            this.PasstxtBox = new System.Windows.Forms.TextBox();
            this.PassLb = new System.Windows.Forms.Label();
            this.StationNametxtBox = new System.Windows.Forms.TextBox();
            this.StationNameLb = new System.Windows.Forms.Label();
            this.VertxtBox = new System.Windows.Forms.TextBox();
            this.VerLb = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.AutoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ManualMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.MainsplitContainer)).BeginInit();
            this.MainsplitContainer.Panel1.SuspendLayout();
            this.MainsplitContainer.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SignpictureBox)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // skinEngine1
            // 
            this.skinEngine1.@__DrawButtonFocusRectangle = true;
            this.skinEngine1.DisabledButtonTextColor = System.Drawing.Color.Gray;
            this.skinEngine1.DisabledMenuFontColor = System.Drawing.SystemColors.GrayText;
            this.skinEngine1.InactiveCaptionColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.skinEngine1.SerialNumber = "";
            this.skinEngine1.SkinFile = null;
            // 
            // ManualTestMenu
            // 
            this.ManualTestMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MaunalModelMenuItem,
            this.AutoManualMenuItem});
            this.ManualTestMenu.Name = "ManualTestMenu";
            this.ManualTestMenu.Size = new System.Drawing.Size(68, 21);
            this.ManualTestMenu.Text = "测试模式";
            // 
            // MaunalModelMenuItem
            // 
            this.MaunalModelMenuItem.Name = "MaunalModelMenuItem";
            this.MaunalModelMenuItem.Size = new System.Drawing.Size(124, 22);
            this.MaunalModelMenuItem.Text = "手动模式";
            this.MaunalModelMenuItem.Click += new System.EventHandler(this.MaunalModelMenuItem_Click);
            // 
            // AutoManualMenuItem
            // 
            this.AutoManualMenuItem.Name = "AutoManualMenuItem";
            this.AutoManualMenuItem.Size = new System.Drawing.Size(124, 22);
            // 
            // MainsplitContainer
            // 
            this.MainsplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainsplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.MainsplitContainer.IsSplitterFixed = true;
            this.MainsplitContainer.Location = new System.Drawing.Point(0, 25);
            this.MainsplitContainer.Name = "MainsplitContainer";
            this.MainsplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // MainsplitContainer.Panel1
            // 
            this.MainsplitContainer.Panel1.Controls.Add(this.panel1);
            // 
            // MainsplitContainer.Panel2
            // 
            this.MainsplitContainer.Panel2.BackColor = System.Drawing.Color.Beige;
            this.MainsplitContainer.Size = new System.Drawing.Size(1452, 525);
            this.MainsplitContainer.SplitterDistance = 131;
            this.MainsplitContainer.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Beige;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.BtnDmrSer);
            this.panel1.Controls.Add(this.btnaxisLog);
            this.panel1.Controls.Add(this.RatetxtBox);
            this.panel1.Controls.Add(this.SignpictureBox);
            this.panel1.Controls.Add(this.RateLb);
            this.panel1.Controls.Add(this.TotaltxtBox);
            this.panel1.Controls.Add(this.TotalLb);
            this.panel1.Controls.Add(this.FailLb);
            this.panel1.Controls.Add(this.FailtxtBox);
            this.panel1.Controls.Add(this.PasstxtBox);
            this.panel1.Controls.Add(this.PassLb);
            this.panel1.Controls.Add(this.StationNametxtBox);
            this.panel1.Controls.Add(this.StationNameLb);
            this.panel1.Controls.Add(this.VertxtBox);
            this.panel1.Controls.Add(this.VerLb);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1452, 131);
            this.panel1.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("隶书", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(316, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 127);
            this.label1.TabIndex = 14;
            this.label1.Text = "项目名称：5.5h";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnDmrSer
            // 
            this.BtnDmrSer.AutoSize = true;
            this.BtnDmrSer.Location = new System.Drawing.Point(1216, 84);
            this.BtnDmrSer.Name = "BtnDmrSer";
            this.BtnDmrSer.Size = new System.Drawing.Size(133, 33);
            this.BtnDmrSer.TabIndex = 13;
            this.BtnDmrSer.Text = "Demura Server";
            this.BtnDmrSer.UseVisualStyleBackColor = true;
            this.BtnDmrSer.Click += new System.EventHandler(this.BtnDmrSer_Click);
            // 
            // btnaxisLog
            // 
            this.btnaxisLog.AutoSize = true;
            this.btnaxisLog.Location = new System.Drawing.Point(1216, 16);
            this.btnaxisLog.Name = "btnaxisLog";
            this.btnaxisLog.Size = new System.Drawing.Size(133, 33);
            this.btnaxisLog.TabIndex = 12;
            this.btnaxisLog.Text = "控制卡/IO卡 Log";
            this.btnaxisLog.UseVisualStyleBackColor = true;
            this.btnaxisLog.Click += new System.EventHandler(this.btnaxisLog_Click);
            // 
            // RatetxtBox
            // 
            this.RatetxtBox.Enabled = false;
            this.RatetxtBox.Location = new System.Drawing.Point(1048, 91);
            this.RatetxtBox.Name = "RatetxtBox";
            this.RatetxtBox.Size = new System.Drawing.Size(84, 21);
            this.RatetxtBox.TabIndex = 11;
            // 
            // SignpictureBox
            // 
            this.SignpictureBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.SignpictureBox.Image = ((System.Drawing.Image)(resources.GetObject("SignpictureBox.Image")));
            this.SignpictureBox.Location = new System.Drawing.Point(0, 0);
            this.SignpictureBox.Name = "SignpictureBox";
            this.SignpictureBox.Size = new System.Drawing.Size(316, 127);
            this.SignpictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.SignpictureBox.TabIndex = 4;
            this.SignpictureBox.TabStop = false;
            // 
            // RateLb
            // 
            this.RateLb.AutoSize = true;
            this.RateLb.Font = new System.Drawing.Font("楷体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RateLb.Location = new System.Drawing.Point(963, 94);
            this.RateLb.Name = "RateLb";
            this.RateLb.Size = new System.Drawing.Size(77, 14);
            this.RateLb.TabIndex = 10;
            this.RateLb.Text = "Pass Rate:";
            // 
            // TotaltxtBox
            // 
            this.TotaltxtBox.Enabled = false;
            this.TotaltxtBox.Location = new System.Drawing.Point(1048, 21);
            this.TotaltxtBox.Name = "TotaltxtBox";
            this.TotaltxtBox.Size = new System.Drawing.Size(84, 21);
            this.TotaltxtBox.TabIndex = 9;
            // 
            // TotalLb
            // 
            this.TotalLb.AutoSize = true;
            this.TotalLb.Font = new System.Drawing.Font("楷体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TotalLb.Location = new System.Drawing.Point(963, 26);
            this.TotalLb.Name = "TotalLb";
            this.TotalLb.Size = new System.Drawing.Size(77, 14);
            this.TotalLb.TabIndex = 8;
            this.TotalLb.Text = "All Count:";
            // 
            // FailLb
            // 
            this.FailLb.AutoSize = true;
            this.FailLb.Font = new System.Drawing.Font("楷体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FailLb.Location = new System.Drawing.Point(765, 94);
            this.FailLb.Name = "FailLb";
            this.FailLb.Size = new System.Drawing.Size(42, 14);
            this.FailLb.TabIndex = 7;
            this.FailLb.Text = "Fail:";
            // 
            // FailtxtBox
            // 
            this.FailtxtBox.Enabled = false;
            this.FailtxtBox.Location = new System.Drawing.Point(808, 90);
            this.FailtxtBox.Name = "FailtxtBox";
            this.FailtxtBox.Size = new System.Drawing.Size(84, 21);
            this.FailtxtBox.TabIndex = 6;
            // 
            // PasstxtBox
            // 
            this.PasstxtBox.Enabled = false;
            this.PasstxtBox.Location = new System.Drawing.Point(808, 22);
            this.PasstxtBox.Name = "PasstxtBox";
            this.PasstxtBox.Size = new System.Drawing.Size(84, 21);
            this.PasstxtBox.TabIndex = 5;
            // 
            // PassLb
            // 
            this.PassLb.AutoSize = true;
            this.PassLb.Font = new System.Drawing.Font("楷体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PassLb.Location = new System.Drawing.Point(767, 25);
            this.PassLb.Name = "PassLb";
            this.PassLb.Size = new System.Drawing.Size(42, 14);
            this.PassLb.TabIndex = 4;
            this.PassLb.Text = "Pass:";
            // 
            // StationNametxtBox
            // 
            this.StationNametxtBox.Enabled = false;
            this.StationNametxtBox.Location = new System.Drawing.Point(620, 90);
            this.StationNametxtBox.Name = "StationNametxtBox";
            this.StationNametxtBox.Size = new System.Drawing.Size(84, 21);
            this.StationNametxtBox.TabIndex = 3;
            // 
            // StationNameLb
            // 
            this.StationNameLb.AutoSize = true;
            this.StationNameLb.Font = new System.Drawing.Font("楷体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.StationNameLb.Location = new System.Drawing.Point(522, 94);
            this.StationNameLb.Name = "StationNameLb";
            this.StationNameLb.Size = new System.Drawing.Size(91, 14);
            this.StationNameLb.TabIndex = 2;
            this.StationNameLb.Text = "StationName:";
            // 
            // VertxtBox
            // 
            this.VertxtBox.Enabled = false;
            this.VertxtBox.Location = new System.Drawing.Point(620, 22);
            this.VertxtBox.Name = "VertxtBox";
            this.VertxtBox.Size = new System.Drawing.Size(84, 21);
            this.VertxtBox.TabIndex = 1;
            // 
            // VerLb
            // 
            this.VerLb.AutoSize = true;
            this.VerLb.Font = new System.Drawing.Font("楷体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.VerLb.Location = new System.Drawing.Point(522, 25);
            this.VerLb.Name = "VerLb";
            this.VerLb.Size = new System.Drawing.Size(91, 14);
            this.VerLb.TabIndex = 0;
            this.VerLb.Text = "SoftVersion:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1452, 25);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AutoMenuItem,
            this.ManualMenuItem});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(86, 21);
            this.toolStripMenuItem2.Text = "Test Model";
            // 
            // AutoMenuItem
            // 
            this.AutoMenuItem.Name = "AutoMenuItem";
            this.AutoMenuItem.Size = new System.Drawing.Size(161, 22);
            this.AutoMenuItem.Text = "Auto Model";
            this.AutoMenuItem.Click += new System.EventHandler(this.AutoMenuItem_Click);
            // 
            // ManualMenuItem
            // 
            this.ManualMenuItem.Name = "ManualMenuItem";
            this.ManualMenuItem.Size = new System.Drawing.Size(161, 22);
            this.ManualMenuItem.Text = "Manual Model";
            this.ManualMenuItem.Click += new System.EventHandler(this.ManualMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1452, 550);
            this.Controls.Add(this.MainsplitContainer);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Demura";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MainsplitContainer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainsplitContainer)).EndInit();
            this.MainsplitContainer.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SignpictureBox)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Sunisoft.IrisSkin.SkinEngine skinEngine1;
        private System.Windows.Forms.SplitContainer MainsplitContainer;
        private System.Windows.Forms.PictureBox SignpictureBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox RatetxtBox;
        private System.Windows.Forms.Label RateLb;
        private System.Windows.Forms.TextBox TotaltxtBox;
        private System.Windows.Forms.Label TotalLb;
        private System.Windows.Forms.Label FailLb;
        private System.Windows.Forms.TextBox FailtxtBox;
        private System.Windows.Forms.TextBox PasstxtBox;
        private System.Windows.Forms.Label PassLb;
        private System.Windows.Forms.TextBox StationNametxtBox;
        private System.Windows.Forms.Label StationNameLb;
        private System.Windows.Forms.TextBox VertxtBox;
        private System.Windows.Forms.Label VerLb;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem AxisConfigMenu;
        private System.Windows.Forms.ToolStripMenuItem ManualTestMenu;
        private System.Windows.Forms.ToolStripMenuItem PicSetMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DemuraSetMenu;
        private System.Windows.Forms.Button BtnDmrSer;
        private System.Windows.Forms.Button btnaxisLog;
        private System.Windows.Forms.ToolStripMenuItem MaunalModelMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AutoManualMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ProjSetMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ManualMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AutoMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
    }
}

