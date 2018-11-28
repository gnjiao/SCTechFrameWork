namespace SEICHITechDemuraTool
{
    partial class AxisCardSetting
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.AxisLb = new System.Windows.Forms.Label();
            this.AxisComBox = new System.Windows.Forms.ComboBox();
            this.AxisCfgGp = new System.Windows.Forms.GroupBox();
            this.RestoreBtn = new System.Windows.Forms.Button();
            this.SvAxisCfgBtn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.AxisLb);
            this.groupBox1.Controls.Add(this.AxisComBox);
            this.groupBox1.Location = new System.Drawing.Point(44, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(367, 74);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Axis Card Chose";
            // 
            // AxisLb
            // 
            this.AxisLb.AutoSize = true;
            this.AxisLb.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AxisLb.Location = new System.Drawing.Point(32, 36);
            this.AxisLb.Name = "AxisLb";
            this.AxisLb.Size = new System.Drawing.Size(68, 16);
            this.AxisLb.TabIndex = 1;
            this.AxisLb.Text = "轴卡 ：";
            // 
            // AxisComBox
            // 
            this.AxisComBox.FormattingEnabled = true;
            this.AxisComBox.Location = new System.Drawing.Point(147, 34);
            this.AxisComBox.Name = "AxisComBox";
            this.AxisComBox.Size = new System.Drawing.Size(134, 20);
            this.AxisComBox.TabIndex = 0;
            this.AxisComBox.SelectedIndexChanged += new System.EventHandler(this.AxisComBox_SelectedIndexChanged);
            // 
            // AxisCfgGp
            // 
            this.AxisCfgGp.Location = new System.Drawing.Point(44, 124);
            this.AxisCfgGp.Name = "AxisCfgGp";
            this.AxisCfgGp.Size = new System.Drawing.Size(367, 428);
            this.AxisCfgGp.TabIndex = 2;
            this.AxisCfgGp.TabStop = false;
            this.AxisCfgGp.Text = "Axis Configuration";
            // 
            // RestoreBtn
            // 
            this.RestoreBtn.BackColor = System.Drawing.Color.Yellow;
            this.RestoreBtn.FlatAppearance.BorderSize = 0;
            this.RestoreBtn.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RestoreBtn.Location = new System.Drawing.Point(300, 589);
            this.RestoreBtn.Name = "RestoreBtn";
            this.RestoreBtn.Size = new System.Drawing.Size(111, 24);
            this.RestoreBtn.TabIndex = 5;
            this.RestoreBtn.Text = "还原";
            this.RestoreBtn.UseVisualStyleBackColor = false;
            this.RestoreBtn.Click += new System.EventHandler(this.RestoreBtn_Click);
            // 
            // SvAxisCfgBtn
            // 
            this.SvAxisCfgBtn.BackColor = System.Drawing.Color.LightGreen;
            this.SvAxisCfgBtn.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SvAxisCfgBtn.Location = new System.Drawing.Point(44, 589);
            this.SvAxisCfgBtn.Name = "SvAxisCfgBtn";
            this.SvAxisCfgBtn.Size = new System.Drawing.Size(111, 24);
            this.SvAxisCfgBtn.TabIndex = 4;
            this.SvAxisCfgBtn.Text = "保存";
            this.SvAxisCfgBtn.UseVisualStyleBackColor = false;
            this.SvAxisCfgBtn.Click += new System.EventHandler(this.SvAxisCfgBtn_Click);
            // 
            // AxisCardSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Beige;
            this.Controls.Add(this.RestoreBtn);
            this.Controls.Add(this.SvAxisCfgBtn);
            this.Controls.Add(this.AxisCfgGp);
            this.Controls.Add(this.groupBox1);
            this.Name = "AxisCardSetting";
            this.Size = new System.Drawing.Size(470, 643);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label AxisLb;
        private System.Windows.Forms.ComboBox AxisComBox;
        private System.Windows.Forms.GroupBox AxisCfgGp;
        private System.Windows.Forms.Button RestoreBtn;
        private System.Windows.Forms.Button SvAxisCfgBtn;
    }
}
