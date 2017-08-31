namespace Opto22_IPconfig
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.PACGrid = new System.Windows.Forms.DataGridView();
            this.btnFind = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbTimeout = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnChange = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlEngineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadStrategyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopStrategyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label4 = new System.Windows.Forms.Label();
            this.lblIP = new System.Windows.Forms.Label();
            this.ipAddressControl1 = new NullFX.Controls.IPAddressControl();
            ((System.ComponentModel.ISupportInitialize)(this.PACGrid)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PACGrid
            // 
            this.PACGrid.AllowUserToAddRows = false;
            this.PACGrid.AllowUserToDeleteRows = false;
            this.PACGrid.AllowUserToResizeColumns = false;
            this.PACGrid.AllowUserToResizeRows = false;
            this.PACGrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.PACGrid.Location = new System.Drawing.Point(0, 24);
            this.PACGrid.MultiSelect = false;
            this.PACGrid.Name = "PACGrid";
            this.PACGrid.RowHeadersWidth = 75;
            this.PACGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.PACGrid.Size = new System.Drawing.Size(767, 223);
            this.PACGrid.TabIndex = 0;
            this.PACGrid.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PACGrid_MouseUp);
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(222, 389);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(141, 35);
            this.btnFind.TabIndex = 2;
            this.btnFind.Text = "Find PACs";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(146, 314);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Broadcast IP:";
            // 
            // tbTimeout
            // 
            this.tbTimeout.Location = new System.Drawing.Point(524, 311);
            this.tbTimeout.Name = "tbTimeout";
            this.tbTimeout.Size = new System.Drawing.Size(61, 20);
            this.tbTimeout.TabIndex = 3;
            this.tbTimeout.Text = "3000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(470, 314);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Timeout:";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnChange
            // 
            this.btnChange.Location = new System.Drawing.Point(417, 389);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(141, 35);
            this.btnChange.TabIndex = 2;
            this.btnChange.Text = "Change IP";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.controlEngineToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(767, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // controlEngineToolStripMenuItem
            // 
            this.controlEngineToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.downloadStrategyToolStripMenuItem,
            this.runToolStripMenuItem,
            this.stopStrategyToolStripMenuItem});
            this.controlEngineToolStripMenuItem.Name = "controlEngineToolStripMenuItem";
            this.controlEngineToolStripMenuItem.Size = new System.Drawing.Size(98, 20);
            this.controlEngineToolStripMenuItem.Text = "Control Engine";
            // 
            // downloadStrategyToolStripMenuItem
            // 
            this.downloadStrategyToolStripMenuItem.Name = "downloadStrategyToolStripMenuItem";
            this.downloadStrategyToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.downloadStrategyToolStripMenuItem.Text = "Download Strategy";
            this.downloadStrategyToolStripMenuItem.Click += new System.EventHandler(this.downloadStategyToolStripMenuItem_Click);
            // 
            // runToolStripMenuItem
            // 
            this.runToolStripMenuItem.Name = "runToolStripMenuItem";
            this.runToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.runToolStripMenuItem.Text = "Run Strategy";
            this.runToolStripMenuItem.Click += new System.EventHandler(this.runToolStripMenuItem_Click);
            // 
            // stopStrategyToolStripMenuItem
            // 
            this.stopStrategyToolStripMenuItem.Name = "stopStrategyToolStripMenuItem";
            this.stopStrategyToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.stopStrategyToolStripMenuItem.Text = "Stop Strategy";
            this.stopStrategyToolStripMenuItem.Click += new System.EventHandler(this.stopStrategyToolStripMenuItem_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 457);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Local IP:";
            // 
            // lblIP
            // 
            this.lblIP.AutoSize = true;
            this.lblIP.Location = new System.Drawing.Point(67, 457);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(40, 13);
            this.lblIP.TabIndex = 8;
            this.lblIP.Text = "0.0.0.0";
            // 
            // ipAddressControl1
            // 
            this.ipAddressControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ipAddressControl1.IPAddress = ((System.Net.IPAddress)(resources.GetObject("ipAddressControl1.IPAddress")));
            this.ipAddressControl1.Location = new System.Drawing.Point(223, 311);
            this.ipAddressControl1.Name = "ipAddressControl1";
            this.ipAddressControl1.Size = new System.Drawing.Size(100, 20);
            this.ipAddressControl1.TabIndex = 1;
            this.ipAddressControl1.Text = "0.0.0.0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 479);
            this.Controls.Add(this.lblIP);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbTimeout);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnChange);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.ipAddressControl1);
            this.Controls.Add(this.PACGrid);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PACGrid)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private NullFX.Controls.IPAddressControl ipAddressControl1;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbTimeout;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.DataGridView PACGrid;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem controlEngineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downloadStrategyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopStrategyToolStripMenuItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblIP;
    }
}

