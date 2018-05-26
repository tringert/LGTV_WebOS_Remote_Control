namespace LgTvController
{
    partial class SavedDeviceListWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SavedDeviceListWindow));
            this.dgvDevices = new System.Windows.Forms.DataGridView();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbUuid = new System.Windows.Forms.TextBox();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.tbIP = new System.Windows.Forms.TextBox();
            this.tbApiKey = new System.Windows.Forms.TextBox();
            this.lbName = new System.Windows.Forms.Label();
            this.lbIP = new System.Windows.Forms.Label();
            this.lbPort = new System.Windows.Forms.Label();
            this.lbUuid = new System.Windows.Forms.Label();
            this.lbApiKey = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevices)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDevices
            // 
            this.dgvDevices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDevices.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvDevices.Location = new System.Drawing.Point(12, 92);
            this.dgvDevices.Name = "dgvDevices";
            this.dgvDevices.Size = new System.Drawing.Size(713, 218);
            this.dgvDevices.TabIndex = 0;
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(12, 27);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(155, 20);
            this.tbName.TabIndex = 1;
            // 
            // tbUuid
            // 
            this.tbUuid.Location = new System.Drawing.Point(12, 66);
            this.tbUuid.Name = "tbUuid";
            this.tbUuid.Size = new System.Drawing.Size(175, 20);
            this.tbUuid.TabIndex = 2;
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(279, 27);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(100, 20);
            this.tbPort.TabIndex = 3;
            // 
            // tbIP
            // 
            this.tbIP.Location = new System.Drawing.Point(173, 27);
            this.tbIP.Name = "tbIP";
            this.tbIP.Size = new System.Drawing.Size(100, 20);
            this.tbIP.TabIndex = 4;
            // 
            // tbApiKey
            // 
            this.tbApiKey.Location = new System.Drawing.Point(193, 66);
            this.tbApiKey.Name = "tbApiKey";
            this.tbApiKey.Size = new System.Drawing.Size(186, 20);
            this.tbApiKey.TabIndex = 5;
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(9, 11);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(35, 13);
            this.lbName.TabIndex = 6;
            this.lbName.Text = "Name";
            // 
            // lbIP
            // 
            this.lbIP.AutoSize = true;
            this.lbIP.Location = new System.Drawing.Point(170, 11);
            this.lbIP.Name = "lbIP";
            this.lbIP.Size = new System.Drawing.Size(17, 13);
            this.lbIP.TabIndex = 7;
            this.lbIP.Text = "IP";
            // 
            // lbPort
            // 
            this.lbPort.AutoSize = true;
            this.lbPort.Location = new System.Drawing.Point(276, 11);
            this.lbPort.Name = "lbPort";
            this.lbPort.Size = new System.Drawing.Size(26, 13);
            this.lbPort.TabIndex = 8;
            this.lbPort.Text = "Port";
            // 
            // lbUuid
            // 
            this.lbUuid.AutoSize = true;
            this.lbUuid.Location = new System.Drawing.Point(9, 50);
            this.lbUuid.Name = "lbUuid";
            this.lbUuid.Size = new System.Drawing.Size(34, 13);
            this.lbUuid.TabIndex = 9;
            this.lbUuid.Text = "UUID";
            // 
            // lbApiKey
            // 
            this.lbApiKey.AutoSize = true;
            this.lbApiKey.Location = new System.Drawing.Point(190, 50);
            this.lbApiKey.Name = "lbApiKey";
            this.lbApiKey.Size = new System.Drawing.Size(40, 13);
            this.lbApiKey.TabIndex = 10;
            this.lbApiKey.Text = "ApiKey";
            // 
            // SavedDeviceListWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 324);
            this.Controls.Add(this.lbApiKey);
            this.Controls.Add(this.lbUuid);
            this.Controls.Add(this.lbPort);
            this.Controls.Add(this.lbIP);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.tbApiKey);
            this.Controls.Add(this.tbIP);
            this.Controls.Add(this.tbPort);
            this.Controls.Add(this.tbUuid);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.dgvDevices);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SavedDeviceListWindow";
            this.Text = "DeviceList";
            this.Load += new System.EventHandler(this.DeviceListWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevices)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDevices;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbUuid;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.TextBox tbIP;
        private System.Windows.Forms.TextBox tbApiKey;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbIP;
        private System.Windows.Forms.Label lbPort;
        private System.Windows.Forms.Label lbUuid;
        private System.Windows.Forms.Label lbApiKey;
    }
}