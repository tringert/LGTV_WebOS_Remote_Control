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
            this.tbApiKey = new System.Windows.Forms.TextBox();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.tbIP = new System.Windows.Forms.TextBox();
            this.tbUuid = new System.Windows.Forms.TextBox();
            this.lbName = new System.Windows.Forms.Label();
            this.lbIP = new System.Windows.Forms.Label();
            this.lbPort = new System.Windows.Forms.Label();
            this.lbUuid = new System.Windows.Forms.Label();
            this.lbApiKey = new System.Windows.Forms.Label();
            this.tbMac = new System.Windows.Forms.TextBox();
            this.lbMac = new System.Windows.Forms.Label();
            this.btAdd = new System.Windows.Forms.Button();
            this.lbServer = new System.Windows.Forms.Label();
            this.tbServer = new System.Windows.Forms.TextBox();
            this.btRemove = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevices)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDevices
            // 
            this.dgvDevices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDevices.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvDevices.Location = new System.Drawing.Point(12, 92);
            this.dgvDevices.MultiSelect = false;
            this.dgvDevices.Name = "dgvDevices";
            this.dgvDevices.RowHeadersWidth = 40;
            this.dgvDevices.Size = new System.Drawing.Size(635, 218);
            this.dgvDevices.TabIndex = 9;
            this.dgvDevices.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvDevices_CellValueChanged);
            this.dgvDevices.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DgvDevices_DataBindingComplete);
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(12, 27);
            this.tbName.MaxLength = 15;
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(155, 20);
            this.tbName.TabIndex = 1;
            this.tbName.Leave += new System.EventHandler(this.TbName_Leave);
            // 
            // tbApiKey
            // 
            this.tbApiKey.Location = new System.Drawing.Point(12, 66);
            this.tbApiKey.MaxLength = 50;
            this.tbApiKey.Name = "tbApiKey";
            this.tbApiKey.Size = new System.Drawing.Size(230, 20);
            this.tbApiKey.TabIndex = 6;
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(279, 27);
            this.tbPort.MaxLength = 5;
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(100, 20);
            this.tbPort.TabIndex = 3;
            this.tbPort.Leave += new System.EventHandler(this.TbPort_Leave);
            // 
            // tbIP
            // 
            this.tbIP.Location = new System.Drawing.Point(173, 27);
            this.tbIP.MaxLength = 16;
            this.tbIP.Name = "tbIP";
            this.tbIP.Size = new System.Drawing.Size(100, 20);
            this.tbIP.TabIndex = 2;
            this.tbIP.Leave += new System.EventHandler(this.TbIP_Leave);
            // 
            // tbUuid
            // 
            this.tbUuid.Location = new System.Drawing.Point(248, 66);
            this.tbUuid.MaxLength = 36;
            this.tbUuid.Name = "tbUuid";
            this.tbUuid.Size = new System.Drawing.Size(237, 20);
            this.tbUuid.TabIndex = 7;
            this.tbUuid.Leave += new System.EventHandler(this.TbUuid_Leave);
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(9, 11);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(39, 13);
            this.lbName.TabIndex = 6;
            this.lbName.Text = "Name*";
            // 
            // lbIP
            // 
            this.lbIP.AutoSize = true;
            this.lbIP.Location = new System.Drawing.Point(170, 11);
            this.lbIP.Name = "lbIP";
            this.lbIP.Size = new System.Drawing.Size(21, 13);
            this.lbIP.TabIndex = 7;
            this.lbIP.Text = "IP*";
            // 
            // lbPort
            // 
            this.lbPort.AutoSize = true;
            this.lbPort.Location = new System.Drawing.Point(276, 11);
            this.lbPort.Name = "lbPort";
            this.lbPort.Size = new System.Drawing.Size(30, 13);
            this.lbPort.TabIndex = 8;
            this.lbPort.Text = "Port*";
            // 
            // lbUuid
            // 
            this.lbUuid.AutoSize = true;
            this.lbUuid.Location = new System.Drawing.Point(245, 50);
            this.lbUuid.Name = "lbUuid";
            this.lbUuid.Size = new System.Drawing.Size(34, 13);
            this.lbUuid.TabIndex = 9;
            this.lbUuid.Text = "UUID";
            // 
            // lbApiKey
            // 
            this.lbApiKey.AutoSize = true;
            this.lbApiKey.Location = new System.Drawing.Point(12, 50);
            this.lbApiKey.Name = "lbApiKey";
            this.lbApiKey.Size = new System.Drawing.Size(44, 13);
            this.lbApiKey.TabIndex = 10;
            this.lbApiKey.Text = "ApiKey*";
            // 
            // tbMac
            // 
            this.tbMac.Location = new System.Drawing.Point(385, 27);
            this.tbMac.MaxLength = 12;
            this.tbMac.Name = "tbMac";
            this.tbMac.Size = new System.Drawing.Size(100, 20);
            this.tbMac.TabIndex = 4;
            this.tbMac.Leave += new System.EventHandler(this.TbMac_Leave);
            // 
            // lbMac
            // 
            this.lbMac.AutoSize = true;
            this.lbMac.Location = new System.Drawing.Point(382, 11);
            this.lbMac.Name = "lbMac";
            this.lbMac.Size = new System.Drawing.Size(69, 13);
            this.lbMac.TabIndex = 12;
            this.lbMac.Text = "Mac Address";
            // 
            // btAdd
            // 
            this.btAdd.Location = new System.Drawing.Point(491, 66);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(75, 20);
            this.btAdd.TabIndex = 8;
            this.btAdd.Text = "Add";
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.BtAdd_Click);
            // 
            // lbServer
            // 
            this.lbServer.AutoSize = true;
            this.lbServer.Location = new System.Drawing.Point(488, 11);
            this.lbServer.Name = "lbServer";
            this.lbServer.Size = new System.Drawing.Size(38, 13);
            this.lbServer.TabIndex = 15;
            this.lbServer.Text = "Server";
            // 
            // tbServer
            // 
            this.tbServer.Location = new System.Drawing.Point(491, 27);
            this.tbServer.MaxLength = 30;
            this.tbServer.Name = "tbServer";
            this.tbServer.Size = new System.Drawing.Size(156, 20);
            this.tbServer.TabIndex = 5;
            // 
            // btRemove
            // 
            this.btRemove.Location = new System.Drawing.Point(572, 66);
            this.btRemove.Name = "btRemove";
            this.btRemove.Size = new System.Drawing.Size(75, 20);
            this.btRemove.TabIndex = 16;
            this.btRemove.Text = "Remove";
            this.btRemove.UseVisualStyleBackColor = true;
            this.btRemove.Click += new System.EventHandler(this.BtRemove_Click);
            // 
            // SavedDeviceListWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 324);
            this.Controls.Add(this.btRemove);
            this.Controls.Add(this.lbServer);
            this.Controls.Add(this.tbServer);
            this.Controls.Add(this.btAdd);
            this.Controls.Add(this.lbMac);
            this.Controls.Add(this.tbMac);
            this.Controls.Add(this.lbApiKey);
            this.Controls.Add(this.lbUuid);
            this.Controls.Add(this.lbPort);
            this.Controls.Add(this.lbIP);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.tbUuid);
            this.Controls.Add(this.tbIP);
            this.Controls.Add(this.tbPort);
            this.Controls.Add(this.tbApiKey);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.dgvDevices);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SavedDeviceListWindow";
            this.Text = "Paired device manager";
            this.Load += new System.EventHandler(this.DeviceListWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevices)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDevices;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbApiKey;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.TextBox tbIP;
        private System.Windows.Forms.TextBox tbUuid;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbIP;
        private System.Windows.Forms.Label lbPort;
        private System.Windows.Forms.Label lbUuid;
        private System.Windows.Forms.Label lbApiKey;
        private System.Windows.Forms.TextBox tbMac;
        private System.Windows.Forms.Label lbMac;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.Label lbServer;
        private System.Windows.Forms.TextBox tbServer;
        private System.Windows.Forms.Button btRemove;
    }
}