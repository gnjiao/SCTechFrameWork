namespace SEICHITechDemuraTool
{
    partial class PatternCfg
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
            this.ColorGrb = new System.Windows.Forms.GroupBox();
            this.ColorPBox = new System.Windows.Forms.PictureBox();
            this.BluetxtBox = new System.Windows.Forms.TextBox();
            this.GreentxtBox = new System.Windows.Forms.TextBox();
            this.RedtxtBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ColorGrb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ColorPBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ColorGrb
            // 
            this.ColorGrb.Controls.Add(this.ColorPBox);
            this.ColorGrb.Controls.Add(this.BluetxtBox);
            this.ColorGrb.Controls.Add(this.GreentxtBox);
            this.ColorGrb.Controls.Add(this.RedtxtBox);
            this.ColorGrb.Controls.Add(this.label3);
            this.ColorGrb.Controls.Add(this.label2);
            this.ColorGrb.Controls.Add(this.label1);
            this.ColorGrb.Location = new System.Drawing.Point(11, 5);
            this.ColorGrb.Name = "ColorGrb";
            this.ColorGrb.Size = new System.Drawing.Size(223, 207);
            this.ColorGrb.TabIndex = 0;
            this.ColorGrb.TabStop = false;
            this.ColorGrb.Text = "Color Setting";
            // 
            // ColorPBox
            // 
            this.ColorPBox.Location = new System.Drawing.Point(23, 149);
            this.ColorPBox.Name = "ColorPBox";
            this.ColorPBox.Size = new System.Drawing.Size(184, 29);
            this.ColorPBox.TabIndex = 6;
            this.ColorPBox.TabStop = false;
            // 
            // BluetxtBox
            // 
            this.BluetxtBox.Location = new System.Drawing.Point(107, 112);
            this.BluetxtBox.Name = "BluetxtBox";
            this.BluetxtBox.Size = new System.Drawing.Size(100, 21);
            this.BluetxtBox.TabIndex = 5;
            // 
            // GreentxtBox
            // 
            this.GreentxtBox.Location = new System.Drawing.Point(107, 72);
            this.GreentxtBox.Name = "GreentxtBox";
            this.GreentxtBox.Size = new System.Drawing.Size(100, 21);
            this.GreentxtBox.TabIndex = 4;
            // 
            // RedtxtBox
            // 
            this.RedtxtBox.Location = new System.Drawing.Point(107, 32);
            this.RedtxtBox.Name = "RedtxtBox";
            this.RedtxtBox.Size = new System.Drawing.Size(100, 21);
            this.RedtxtBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(20, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 22);
            this.label3.TabIndex = 2;
            this.label3.Text = "Blue :";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(20, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "Green :";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(20, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Red :";
            // 
            // PatternCfg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ColorGrb);
            this.Name = "PatternCfg";
            this.Size = new System.Drawing.Size(245, 227);
            this.Load += new System.EventHandler(this.PatternCfg_Load);
            this.ColorGrb.ResumeLayout(false);
            this.ColorGrb.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ColorPBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox ColorGrb;
        private System.Windows.Forms.TextBox BluetxtBox;
        private System.Windows.Forms.TextBox GreentxtBox;
        private System.Windows.Forms.TextBox RedtxtBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox ColorPBox;
    }
}
