namespace Opto22_IPconfig
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.ipIPAddress = new NullFX.Controls.IPAddressControl();
            this.label1 = new System.Windows.Forms.Label();
            this.ipSubnetMask = new NullFX.Controls.IPAddressControl();
            this.label2 = new System.Windows.Forms.Label();
            this.ipGateway = new NullFX.Controls.IPAddressControl();
            this.label3 = new System.Windows.Forms.Label();
            this.ipDns = new NullFX.Controls.IPAddressControl();
            this.label4 = new System.Windows.Forms.Label();
            this.btnChange = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ipIPAddress
            // 
            this.ipIPAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ipIPAddress.IPAddress = ((System.Net.IPAddress)(resources.GetObject("ipIPAddress.IPAddress")));
            this.ipIPAddress.Location = new System.Drawing.Point(183, 66);
            this.ipIPAddress.Name = "ipIPAddress";
            this.ipIPAddress.Size = new System.Drawing.Size(100, 20);
            this.ipIPAddress.TabIndex = 0;
            this.ipIPAddress.Text = "0.0.0.0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "IP Address:";
            // 
            // ipSubnetMask
            // 
            this.ipSubnetMask.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ipSubnetMask.IPAddress = ((System.Net.IPAddress)(resources.GetObject("ipSubnetMask.IPAddress")));
            this.ipSubnetMask.Location = new System.Drawing.Point(127, 29);
            this.ipSubnetMask.Name = "ipSubnetMask";
            this.ipSubnetMask.Size = new System.Drawing.Size(100, 20);
            this.ipSubnetMask.TabIndex = 0;
            this.ipSubnetMask.Text = "0.0.0.0";
            this.ipSubnetMask.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ipSubnetMask_MouseDoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Subnet Mask:";
            // 
            // ipGateway
            // 
            this.ipGateway.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ipGateway.IPAddress = ((System.Net.IPAddress)(resources.GetObject("ipGateway.IPAddress")));
            this.ipGateway.Location = new System.Drawing.Point(127, 80);
            this.ipGateway.Name = "ipGateway";
            this.ipGateway.Size = new System.Drawing.Size(100, 20);
            this.ipGateway.TabIndex = 0;
            this.ipGateway.Text = "0.0.0.0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Gateway:";
            // 
            // ipDns
            // 
            this.ipDns.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ipDns.IPAddress = ((System.Net.IPAddress)(resources.GetObject("ipDns.IPAddress")));
            this.ipDns.Location = new System.Drawing.Point(127, 131);
            this.ipDns.Name = "ipDns";
            this.ipDns.Size = new System.Drawing.Size(100, 20);
            this.ipDns.TabIndex = 0;
            this.ipDns.Text = "0.0.0.0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Dns:";
            // 
            // btnChange
            // 
            this.btnChange.Location = new System.Drawing.Point(99, 398);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(75, 23);
            this.btnChange.TabIndex = 2;
            this.btnChange.Text = "Change";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(202, 398);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.tbPort);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.ipDns);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.ipGateway);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.ipSubnetMask);
            this.groupBox1.Location = new System.Drawing.Point(60, 138);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(264, 233);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(60, 115);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(114, 17);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "Advanced Options";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 185);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Port:";
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(127, 182);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(59, 20);
            this.tbPort.TabIndex = 3;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 473);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnChange);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ipIPAddress);
            this.Name = "Form2";
            this.Text = "Form2";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NullFX.Controls.IPAddressControl ipIPAddress;
        private System.Windows.Forms.Label label1;
        private NullFX.Controls.IPAddressControl ipSubnetMask;
        private System.Windows.Forms.Label label2;
        private NullFX.Controls.IPAddressControl ipGateway;
        private System.Windows.Forms.Label label3;
        private NullFX.Controls.IPAddressControl ipDns;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.Label label5;
    }
}