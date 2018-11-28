namespace SEICHITechDemuraTool
{
    partial class PictureColorSetting
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
            this.Patternpanel = new System.Windows.Forms.Panel();
            this.PatternLb = new System.Windows.Forms.Label();
            this.PatternSaveBtn = new System.Windows.Forms.Button();
            this.PatternNumComb = new System.Windows.Forms.ComboBox();
            this.PicFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.Patternpanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Patternpanel
            // 
            this.Patternpanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Patternpanel.Controls.Add(this.PatternLb);
            this.Patternpanel.Controls.Add(this.PatternSaveBtn);
            this.Patternpanel.Controls.Add(this.PatternNumComb);
            this.Patternpanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Patternpanel.Location = new System.Drawing.Point(0, 555);
            this.Patternpanel.Name = "Patternpanel";
            this.Patternpanel.Size = new System.Drawing.Size(970, 77);
            this.Patternpanel.TabIndex = 2;
            // 
            // PatternLb
            // 
            this.PatternLb.AutoSize = true;
            this.PatternLb.Font = new System.Drawing.Font("楷体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PatternLb.ForeColor = System.Drawing.Color.Brown;
            this.PatternLb.Location = new System.Drawing.Point(12, 29);
            this.PatternLb.Name = "PatternLb";
            this.PatternLb.Size = new System.Drawing.Size(174, 19);
            this.PatternLb.TabIndex = 1;
            this.PatternLb.Text = "PatternNumber :";
            // 
            // PatternSaveBtn
            // 
            this.PatternSaveBtn.BackColor = System.Drawing.Color.Green;
            this.PatternSaveBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.PatternSaveBtn.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PatternSaveBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.PatternSaveBtn.Location = new System.Drawing.Point(863, 0);
            this.PatternSaveBtn.Name = "PatternSaveBtn";
            this.PatternSaveBtn.Size = new System.Drawing.Size(103, 73);
            this.PatternSaveBtn.TabIndex = 3;
            this.PatternSaveBtn.Text = "保存";
            this.PatternSaveBtn.UseVisualStyleBackColor = false;
            // 
            // PatternNumComb
            // 
            this.PatternNumComb.FormattingEnabled = true;
            this.PatternNumComb.Location = new System.Drawing.Point(192, 29);
            this.PatternNumComb.Name = "PatternNumComb";
            this.PatternNumComb.Size = new System.Drawing.Size(121, 20);
            this.PatternNumComb.TabIndex = 2;
            this.PatternNumComb.SelectedIndexChanged += new System.EventHandler(this.PatternNumComb_SelectedIndexChanged);
            // 
            // PicFlowPanel
            // 
            this.PicFlowPanel.AutoScroll = true;
            this.PicFlowPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PicFlowPanel.Location = new System.Drawing.Point(0, 0);
            this.PicFlowPanel.Name = "PicFlowPanel";
            this.PicFlowPanel.Size = new System.Drawing.Size(970, 555);
            this.PicFlowPanel.TabIndex = 3;
            // 
            // PictureColorSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PicFlowPanel);
            this.Controls.Add(this.Patternpanel);
            this.Name = "PictureColorSetting";
            this.Size = new System.Drawing.Size(970, 632);
            this.Patternpanel.ResumeLayout(false);
            this.Patternpanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Patternpanel;
        private System.Windows.Forms.Label PatternLb;
        private System.Windows.Forms.Button PatternSaveBtn;
        private System.Windows.Forms.ComboBox PatternNumComb;
        private System.Windows.Forms.FlowLayoutPanel PicFlowPanel;
    }
}
