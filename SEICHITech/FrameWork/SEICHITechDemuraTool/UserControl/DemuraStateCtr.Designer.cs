namespace SEICHITechDemuraTool
{
    partial class DemuraStateCtr
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Enable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Server_IP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Port = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Open = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PG_P = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PG_S = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastestResult = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Reconnect = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LbLogo = new System.Windows.Forms.Label();
            this.ELVSSLb = new System.Windows.Forms.Label();
            this.ELVSSCLb = new System.Windows.Forms.Label();
            this.ELVSSVLb = new System.Windows.Forms.Label();
            this.VDDIOVLb = new System.Windows.Forms.Label();
            this.AVDDLb = new System.Windows.Forms.Label();
            this.ELVDDLb = new System.Windows.Forms.Label();
            this.VDDIOCLb = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.AVDDCLb = new System.Windows.Forms.Label();
            this.AVDDVLb = new System.Windows.Forms.Label();
            this.ELVDDCLb = new System.Windows.Forms.Label();
            this.ELVDDVLb = new System.Windows.Forms.Label();
            this.VCICLb = new System.Windows.Forms.Label();
            this.VCIVLb = new System.Windows.Forms.Label();
            this.VCILb = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Size = new System.Drawing.Size(689, 264);
            this.splitContainer1.SplitterDistance = 80;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Enable,
            this.Server_IP,
            this.Port,
            this.Open,
            this.PG_P,
            this.PG_S,
            this.Status,
            this.LastestResult,
            this.Reconnect});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(689, 80);
            this.dataGridView1.TabIndex = 0;
            // 
            // Enable
            // 
            this.Enable.DataPropertyName = "Enable";
            this.Enable.HeaderText = "Enable";
            this.Enable.Name = "Enable";
            this.Enable.ReadOnly = true;
            this.Enable.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Enable.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Enable.Width = 50;
            // 
            // Server_IP
            // 
            this.Server_IP.DataPropertyName = "Server_IP";
            this.Server_IP.HeaderText = "Server_IP";
            this.Server_IP.Name = "Server_IP";
            this.Server_IP.ReadOnly = true;
            // 
            // Port
            // 
            this.Port.DataPropertyName = "Port";
            this.Port.HeaderText = "Port";
            this.Port.Name = "Port";
            this.Port.ReadOnly = true;
            this.Port.Width = 80;
            // 
            // Open
            // 
            this.Open.DataPropertyName = "Open";
            this.Open.HeaderText = "Open";
            this.Open.Name = "Open";
            this.Open.ReadOnly = true;
            this.Open.Width = 70;
            // 
            // PG_P
            // 
            this.PG_P.DataPropertyName = "PG_P";
            this.PG_P.HeaderText = "PG_P";
            this.PG_P.Name = "PG_P";
            this.PG_P.ReadOnly = true;
            this.PG_P.Width = 70;
            // 
            // PG_S
            // 
            this.PG_S.DataPropertyName = "PG_S";
            this.PG_S.HeaderText = "PG_S";
            this.PG_S.Name = "PG_S";
            this.PG_S.ReadOnly = true;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Width = 80;
            // 
            // LastestResult
            // 
            this.LastestResult.DataPropertyName = "LastestResult";
            this.LastestResult.HeaderText = "LastestResult";
            this.LastestResult.Name = "LastestResult";
            this.LastestResult.ReadOnly = true;
            this.LastestResult.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.LastestResult.Width = 140;
            // 
            // Reconnect
            // 
            this.Reconnect.DataPropertyName = "Reconnect";
            this.Reconnect.HeaderText = "Reconnect";
            this.Reconnect.Name = "Reconnect";
            this.Reconnect.ReadOnly = true;
            this.Reconnect.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Reconnect.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Reconnect.Text = "重连服务器";
            this.Reconnect.UseColumnTextForButtonValue = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LbLogo);
            this.groupBox1.Controls.Add(this.ELVSSLb);
            this.groupBox1.Controls.Add(this.ELVSSCLb);
            this.groupBox1.Controls.Add(this.ELVSSVLb);
            this.groupBox1.Controls.Add(this.VDDIOVLb);
            this.groupBox1.Controls.Add(this.AVDDLb);
            this.groupBox1.Controls.Add(this.ELVDDLb);
            this.groupBox1.Controls.Add(this.VDDIOCLb);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.AVDDCLb);
            this.groupBox1.Controls.Add(this.AVDDVLb);
            this.groupBox1.Controls.Add(this.ELVDDCLb);
            this.groupBox1.Controls.Add(this.ELVDDVLb);
            this.groupBox1.Controls.Add(this.VCICLb);
            this.groupBox1.Controls.Add(this.VCIVLb);
            this.groupBox1.Controls.Add(this.VCILb);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(689, 179);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PG_info";
            // 
            // LbLogo
            // 
            this.LbLogo.AutoSize = true;
            this.LbLogo.Font = new System.Drawing.Font("楷体", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LbLogo.ForeColor = System.Drawing.Color.DarkRed;
            this.LbLogo.Location = new System.Drawing.Point(463, 124);
            this.LbLogo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LbLogo.Name = "LbLogo";
            this.LbLogo.Size = new System.Drawing.Size(0, 25);
            this.LbLogo.TabIndex = 15;
            // 
            // ELVSSLb
            // 
            this.ELVSSLb.AutoSize = true;
            this.ELVSSLb.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ELVSSLb.Font = new System.Drawing.Font("楷体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ELVSSLb.Location = new System.Drawing.Point(355, 78);
            this.ELVSSLb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ELVSSLb.Name = "ELVSSLb";
            this.ELVSSLb.Size = new System.Drawing.Size(75, 24);
            this.ELVSSLb.TabIndex = 14;
            this.ELVSSLb.Text = "ELVSS";
            // 
            // ELVSSCLb
            // 
            this.ELVSSCLb.AutoSize = true;
            this.ELVSSCLb.BackColor = System.Drawing.Color.Chartreuse;
            this.ELVSSCLb.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ELVSSCLb.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ELVSSCLb.Location = new System.Drawing.Point(579, 81);
            this.ELVSSCLb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ELVSSCLb.Name = "ELVSSCLb";
            this.ELVSSCLb.Size = new System.Drawing.Size(79, 20);
            this.ELVSSCLb.TabIndex = 13;
            this.ELVSSCLb.Text = "Current";
            // 
            // ELVSSVLb
            // 
            this.ELVSSVLb.AutoSize = true;
            this.ELVSSVLb.BackColor = System.Drawing.Color.Yellow;
            this.ELVSSVLb.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ELVSSVLb.Location = new System.Drawing.Point(464, 81);
            this.ELVSSVLb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ELVSSVLb.Name = "ELVSSVLb";
            this.ELVSSVLb.Size = new System.Drawing.Size(79, 20);
            this.ELVSSVLb.TabIndex = 12;
            this.ELVSSVLb.Text = "Voltage";
            // 
            // VDDIOVLb
            // 
            this.VDDIOVLb.AutoSize = true;
            this.VDDIOVLb.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.VDDIOVLb.Font = new System.Drawing.Font("楷体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.VDDIOVLb.Location = new System.Drawing.Point(17, 121);
            this.VDDIOVLb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.VDDIOVLb.Name = "VDDIOVLb";
            this.VDDIOVLb.Size = new System.Drawing.Size(75, 24);
            this.VDDIOVLb.TabIndex = 11;
            this.VDDIOVLb.Text = "VDDIO";
            // 
            // AVDDLb
            // 
            this.AVDDLb.AutoSize = true;
            this.AVDDLb.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.AVDDLb.Font = new System.Drawing.Font("楷体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AVDDLb.Location = new System.Drawing.Point(17, 74);
            this.AVDDLb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.AVDDLb.Name = "AVDDLb";
            this.AVDDLb.Size = new System.Drawing.Size(75, 24);
            this.AVDDLb.TabIndex = 10;
            this.AVDDLb.Text = " AVDD";
            // 
            // ELVDDLb
            // 
            this.ELVDDLb.AutoSize = true;
            this.ELVDDLb.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ELVDDLb.Font = new System.Drawing.Font("楷体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ELVDDLb.Location = new System.Drawing.Point(355, 25);
            this.ELVDDLb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ELVDDLb.Name = "ELVDDLb";
            this.ELVDDLb.Size = new System.Drawing.Size(75, 24);
            this.ELVDDLb.TabIndex = 9;
            this.ELVDDLb.Text = "ELVDD";
            // 
            // VDDIOCLb
            // 
            this.VDDIOCLb.AutoSize = true;
            this.VDDIOCLb.BackColor = System.Drawing.Color.Chartreuse;
            this.VDDIOCLb.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.VDDIOCLb.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.VDDIOCLb.Location = new System.Drawing.Point(236, 124);
            this.VDDIOCLb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.VDDIOCLb.Name = "VDDIOCLb";
            this.VDDIOCLb.Size = new System.Drawing.Size(79, 20);
            this.VDDIOCLb.TabIndex = 8;
            this.VDDIOCLb.Text = "Current";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Yellow;
            this.label9.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(121, 121);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 20);
            this.label9.TabIndex = 7;
            this.label9.Text = "Voltage";
            // 
            // AVDDCLb
            // 
            this.AVDDCLb.AutoSize = true;
            this.AVDDCLb.BackColor = System.Drawing.Color.Chartreuse;
            this.AVDDCLb.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AVDDCLb.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.AVDDCLb.Location = new System.Drawing.Point(236, 78);
            this.AVDDCLb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.AVDDCLb.Name = "AVDDCLb";
            this.AVDDCLb.Size = new System.Drawing.Size(79, 20);
            this.AVDDCLb.TabIndex = 6;
            this.AVDDCLb.Text = "Current";
            // 
            // AVDDVLb
            // 
            this.AVDDVLb.AutoSize = true;
            this.AVDDVLb.BackColor = System.Drawing.Color.Yellow;
            this.AVDDVLb.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AVDDVLb.Location = new System.Drawing.Point(121, 75);
            this.AVDDVLb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.AVDDVLb.Name = "AVDDVLb";
            this.AVDDVLb.Size = new System.Drawing.Size(79, 20);
            this.AVDDVLb.TabIndex = 5;
            this.AVDDVLb.Text = "Voltage";
            // 
            // ELVDDCLb
            // 
            this.ELVDDCLb.AutoSize = true;
            this.ELVDDCLb.BackColor = System.Drawing.Color.Chartreuse;
            this.ELVDDCLb.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ELVDDCLb.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ELVDDCLb.Location = new System.Drawing.Point(579, 30);
            this.ELVDDCLb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ELVDDCLb.Name = "ELVDDCLb";
            this.ELVDDCLb.Size = new System.Drawing.Size(79, 20);
            this.ELVDDCLb.TabIndex = 4;
            this.ELVDDCLb.Text = "Current";
            // 
            // ELVDDVLb
            // 
            this.ELVDDVLb.AutoSize = true;
            this.ELVDDVLb.BackColor = System.Drawing.Color.Yellow;
            this.ELVDDVLb.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ELVDDVLb.Location = new System.Drawing.Point(464, 28);
            this.ELVDDVLb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ELVDDVLb.Name = "ELVDDVLb";
            this.ELVDDVLb.Size = new System.Drawing.Size(79, 20);
            this.ELVDDVLb.TabIndex = 3;
            this.ELVDDVLb.Text = "Voltage";
            // 
            // VCICLb
            // 
            this.VCICLb.AutoSize = true;
            this.VCICLb.BackColor = System.Drawing.Color.Chartreuse;
            this.VCICLb.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.VCICLb.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.VCICLb.Location = new System.Drawing.Point(236, 26);
            this.VCICLb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.VCICLb.Name = "VCICLb";
            this.VCICLb.Size = new System.Drawing.Size(79, 20);
            this.VCICLb.TabIndex = 2;
            this.VCICLb.Text = "Current";
            // 
            // VCIVLb
            // 
            this.VCIVLb.AutoSize = true;
            this.VCIVLb.BackColor = System.Drawing.Color.Yellow;
            this.VCIVLb.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.VCIVLb.Location = new System.Drawing.Point(121, 24);
            this.VCIVLb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.VCIVLb.Name = "VCIVLb";
            this.VCIVLb.Size = new System.Drawing.Size(79, 20);
            this.VCIVLb.TabIndex = 1;
            this.VCIVLb.Text = "Voltage";
            // 
            // VCILb
            // 
            this.VCILb.AutoSize = true;
            this.VCILb.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.VCILb.Font = new System.Drawing.Font("楷体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.VCILb.Location = new System.Drawing.Point(17, 24);
            this.VCILb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.VCILb.Name = "VCILb";
            this.VCILb.Size = new System.Drawing.Size(75, 24);
            this.VCILb.TabIndex = 0;
            this.VCILb.Text = " VCI ";
            // 
            // DemuraStateCtr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "DemuraStateCtr";
            this.Size = new System.Drawing.Size(689, 264);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label ELVSSLb;
        private System.Windows.Forms.Label ELVSSCLb;
        private System.Windows.Forms.Label ELVSSVLb;
        private System.Windows.Forms.Label VDDIOVLb;
        private System.Windows.Forms.Label AVDDLb;
        private System.Windows.Forms.Label ELVDDLb;
        private System.Windows.Forms.Label VDDIOCLb;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label AVDDCLb;
        private System.Windows.Forms.Label AVDDVLb;
        private System.Windows.Forms.Label ELVDDCLb;
        private System.Windows.Forms.Label ELVDDVLb;
        private System.Windows.Forms.Label VCICLb;
        private System.Windows.Forms.Label VCIVLb;
        private System.Windows.Forms.Label VCILb;
        private System.Windows.Forms.Label LbLogo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Enable;
        private System.Windows.Forms.DataGridViewTextBoxColumn Server_IP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Port;
        private System.Windows.Forms.DataGridViewTextBoxColumn Open;
        private System.Windows.Forms.DataGridViewTextBoxColumn PG_P;
        private System.Windows.Forms.DataGridViewTextBoxColumn PG_S;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastestResult;
        private System.Windows.Forms.DataGridViewButtonColumn Reconnect;
    }
}
