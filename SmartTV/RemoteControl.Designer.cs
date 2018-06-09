namespace LgTvController
{
    partial class RemoteControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RemoteControl));
            this.txtResponse = new System.Windows.Forms.TextBox();
            this.btVolPlus = new System.Windows.Forms.Button();
            this.btVolMinus = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.chanMinus = new System.Windows.Forms.Button();
            this.chanPlus = new System.Windows.Forms.Button();
            this.btnTurnOn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnTurnOff = new System.Windows.Forms.Button();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDevManager = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemPairDevice = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemShowLog = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btVol = new System.Windows.Forms.Button();
            this.btChan = new System.Windows.Forms.Button();
            this.btChList = new System.Windows.Forms.Button();
            this.btMessage = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnMute = new System.Windows.Forms.Button();
            this.cbSavedDevices = new System.Windows.Forms.ComboBox();
            this.lbCurrentDevice = new System.Windows.Forms.Label();
            this.btnInput = new System.Windows.Forms.Button();
            this.btSwInfo = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.menuStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtResponse
            // 
            this.txtResponse.Location = new System.Drawing.Point(326, 51);
            this.txtResponse.Multiline = true;
            this.txtResponse.Name = "txtResponse";
            this.txtResponse.ReadOnly = true;
            this.txtResponse.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResponse.Size = new System.Drawing.Size(546, 398);
            this.txtResponse.TabIndex = 0;
            // 
            // btVolPlus
            // 
            this.btVolPlus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btVolPlus.Location = new System.Drawing.Point(30, 182);
            this.btVolPlus.Name = "btVolPlus";
            this.btVolPlus.Size = new System.Drawing.Size(47, 36);
            this.btVolPlus.TabIndex = 25;
            this.btVolPlus.Text = "+";
            this.btVolPlus.UseVisualStyleBackColor = true;
            this.btVolPlus.Click += new System.EventHandler(this.BtVolPlus_Click);
            // 
            // btVolMinus
            // 
            this.btVolMinus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btVolMinus.Location = new System.Drawing.Point(30, 224);
            this.btVolMinus.Name = "btVolMinus";
            this.btVolMinus.Size = new System.Drawing.Size(47, 36);
            this.btVolMinus.TabIndex = 45;
            this.btVolMinus.Text = "-";
            this.btVolMinus.UseVisualStyleBackColor = true;
            this.btVolMinus.Click += new System.EventHandler(this.BtVolMinus_Click);
            // 
            // button3
            // 
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button3.Enabled = false;
            this.button3.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(86, 267);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(47, 36);
            this.button3.TabIndex = 50;
            this.button3.Text = "▲";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button4.Enabled = false;
            this.button4.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(86, 350);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(47, 36);
            this.button4.TabIndex = 80;
            this.button4.Text = "▼";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button5.Enabled = false;
            this.button5.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(30, 308);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(47, 36);
            this.button5.TabIndex = 60;
            this.button5.Text = "◄";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button6.Enabled = false;
            this.button6.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Location = new System.Drawing.Point(140, 308);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(47, 36);
            this.button6.TabIndex = 70;
            this.button6.Text = "►";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button7.Enabled = false;
            this.button7.Location = new System.Drawing.Point(86, 308);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(47, 36);
            this.button7.TabIndex = 65;
            this.button7.Text = "OK";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Volume";
            // 
            // button8
            // 
            this.button8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button8.Enabled = false;
            this.button8.Location = new System.Drawing.Point(30, 351);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(47, 36);
            this.button8.TabIndex = 75;
            this.button8.Text = "Menu";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button9.Enabled = false;
            this.button9.Location = new System.Drawing.Point(140, 266);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(47, 36);
            this.button9.TabIndex = 30;
            this.button9.Text = "Exit";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            this.button10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button10.Enabled = false;
            this.button10.Location = new System.Drawing.Point(30, 267);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(47, 36);
            this.button10.TabIndex = 85;
            this.button10.Text = "Back";
            this.button10.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(139, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Channel";
            // 
            // chanMinus
            // 
            this.chanMinus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chanMinus.Location = new System.Drawing.Point(140, 224);
            this.chanMinus.Name = "chanMinus";
            this.chanMinus.Size = new System.Drawing.Size(47, 36);
            this.chanMinus.TabIndex = 55;
            this.chanMinus.Text = "-";
            this.chanMinus.UseVisualStyleBackColor = true;
            this.chanMinus.Click += new System.EventHandler(this.ChanMinus_Click);
            // 
            // chanPlus
            // 
            this.chanPlus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chanPlus.Location = new System.Drawing.Point(140, 182);
            this.chanPlus.Name = "chanPlus";
            this.chanPlus.Size = new System.Drawing.Size(47, 36);
            this.chanPlus.TabIndex = 40;
            this.chanPlus.Text = "+";
            this.chanPlus.UseVisualStyleBackColor = true;
            this.chanPlus.Click += new System.EventHandler(this.ChanPlus_Click);
            // 
            // btnTurnOn
            // 
            this.btnTurnOn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnTurnOn.Location = new System.Drawing.Point(30, 393);
            this.btnTurnOn.Name = "btnTurnOn";
            this.btnTurnOn.Size = new System.Drawing.Size(157, 23);
            this.btnTurnOn.TabIndex = 90;
            this.btnTurnOn.Text = "Turn on";
            this.btnTurnOn.UseVisualStyleBackColor = true;
            this.btnTurnOn.Click += new System.EventHandler(this.BtnTurnOn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(323, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Log:";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(17, 84);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(89, 23);
            this.btnConnect.TabIndex = 5;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.BtnConnect_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(112, 84);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(87, 23);
            this.btnDisconnect.TabIndex = 6;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = false;
            this.btnDisconnect.Click += new System.EventHandler(this.BtnDisconnect_Click);
            // 
            // btnTurnOff
            // 
            this.btnTurnOff.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnTurnOff.Location = new System.Drawing.Point(30, 422);
            this.btnTurnOff.Name = "btnTurnOff";
            this.btnTurnOff.Size = new System.Drawing.Size(157, 23);
            this.btnTurnOff.TabIndex = 95;
            this.btnTurnOff.Text = "Turn off";
            this.btnTurnOff.UseVisualStyleBackColor = true;
            this.btnTurnOff.Click += new System.EventHandler(this.BtnTurnOff_Click);
            // 
            // menuStripMain
            // 
            this.menuStripMain.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuSetting,
            this.helpToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(2, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(113, 24);
            this.menuStripMain.TabIndex = 96;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // toolStripMenuSetting
            // 
            this.toolStripMenuSetting.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemDevManager,
            this.toolStripMenuItemPairDevice,
            this.toolStripMenuItemShowLog});
            this.toolStripMenuSetting.MergeAction = System.Windows.Forms.MergeAction.Remove;
            this.toolStripMenuSetting.Name = "toolStripMenuSetting";
            this.toolStripMenuSetting.Size = new System.Drawing.Size(61, 20);
            this.toolStripMenuSetting.Text = "Settings";
            // 
            // toolStripMenuItemDevManager
            // 
            this.toolStripMenuItemDevManager.Name = "toolStripMenuItemDevManager";
            this.toolStripMenuItemDevManager.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItemDevManager.Text = "Device manager";
            this.toolStripMenuItemDevManager.Click += new System.EventHandler(this.ToolStripMenuItemDevManager_Click);
            // 
            // toolStripMenuItemPairDevice
            // 
            this.toolStripMenuItemPairDevice.Name = "toolStripMenuItemPairDevice";
            this.toolStripMenuItemPairDevice.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItemPairDevice.Text = "Pair new device";
            this.toolStripMenuItemPairDevice.Click += new System.EventHandler(this.PairDeviceToolStripMenuItem_Click);
            // 
            // toolStripMenuItemShowLog
            // 
            this.toolStripMenuItemShowLog.Name = "toolStripMenuItemShowLog";
            this.toolStripMenuItemShowLog.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItemShowLog.Text = "Show log";
            this.toolStripMenuItemShowLog.Click += new System.EventHandler(this.ShowLogToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem1,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.helpToolStripMenuItem1.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // btVol
            // 
            this.btVol.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btVol.Location = new System.Drawing.Point(30, 140);
            this.btVol.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.btVol.Name = "btVol";
            this.btVol.Size = new System.Drawing.Size(76, 36);
            this.btVol.TabIndex = 99;
            this.btVol.UseVisualStyleBackColor = true;
            this.btVol.Click += new System.EventHandler(this.BtVol_Click);
            // 
            // btChan
            // 
            this.btChan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btChan.Location = new System.Drawing.Point(111, 140);
            this.btChan.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.btChan.Name = "btChan";
            this.btChan.Size = new System.Drawing.Size(76, 36);
            this.btChan.TabIndex = 101;
            this.btChan.UseVisualStyleBackColor = true;
            this.btChan.Click += new System.EventHandler(this.BtChan_Click);
            // 
            // btChList
            // 
            this.btChList.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btChList.Location = new System.Drawing.Point(85, 182);
            this.btChList.Name = "btChList";
            this.btChList.Size = new System.Drawing.Size(47, 36);
            this.btChList.TabIndex = 102;
            this.btChList.Text = "Ch. list";
            this.btChList.UseVisualStyleBackColor = true;
            this.btChList.Click += new System.EventHandler(this.BtChList_Click);
            // 
            // btMessage
            // 
            this.btMessage.Location = new System.Drawing.Point(205, 84);
            this.btMessage.Name = "btMessage";
            this.btMessage.Size = new System.Drawing.Size(86, 23);
            this.btMessage.TabIndex = 103;
            this.btMessage.Text = "Message";
            this.btMessage.UseVisualStyleBackColor = true;
            this.btMessage.Click += new System.EventHandler(this.BtMessage_Click);
            // 
            // button11
            // 
            this.button11.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button11.Image = ((System.Drawing.Image)(resources.GetObject("button11.Image")));
            this.button11.Location = new System.Drawing.Point(251, 110);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(40, 40);
            this.button11.TabIndex = 104;
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.Button11_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(842, 18);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 30);
            this.button1.TabIndex = 100;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // btnMute
            // 
            this.btnMute.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnMute.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnMute.Image = ((System.Drawing.Image)(resources.GetObject("btnMute.Image")));
            this.btnMute.Location = new System.Drawing.Point(85, 224);
            this.btnMute.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.btnMute.Name = "btnMute";
            this.btnMute.Size = new System.Drawing.Size(47, 36);
            this.btnMute.TabIndex = 20;
            this.btnMute.UseVisualStyleBackColor = true;
            this.btnMute.Click += new System.EventHandler(this.BtnMute_Click);
            // 
            // cbSavedDevices
            // 
            this.cbSavedDevices.FormattingEnabled = true;
            this.cbSavedDevices.Location = new System.Drawing.Point(17, 57);
            this.cbSavedDevices.Name = "cbSavedDevices";
            this.cbSavedDevices.Size = new System.Drawing.Size(182, 21);
            this.cbSavedDevices.TabIndex = 105;
            this.cbSavedDevices.SelectionChangeCommitted += new System.EventHandler(this.CbSavedDevices_SelectionChangeCommitted);
            // 
            // lbCurrentDevice
            // 
            this.lbCurrentDevice.AutoSize = true;
            this.lbCurrentDevice.Location = new System.Drawing.Point(14, 41);
            this.lbCurrentDevice.Name = "lbCurrentDevice";
            this.lbCurrentDevice.Size = new System.Drawing.Size(44, 13);
            this.lbCurrentDevice.TabIndex = 107;
            this.lbCurrentDevice.Text = "Device:";
            // 
            // btnInput
            // 
            this.btnInput.Location = new System.Drawing.Point(205, 57);
            this.btnInput.Name = "btnInput";
            this.btnInput.Size = new System.Drawing.Size(86, 23);
            this.btnInput.TabIndex = 109;
            this.btnInput.Text = "Inputs";
            this.btnInput.UseVisualStyleBackColor = true;
            this.btnInput.Click += new System.EventHandler(this.BtnInput_Click);
            // 
            // btSwInfo
            // 
            this.btSwInfo.Image = global::LgTvController.Properties.Resources.youtube_icon_35x35px;
            this.btSwInfo.Location = new System.Drawing.Point(205, 110);
            this.btSwInfo.Name = "btSwInfo";
            this.btSwInfo.Size = new System.Drawing.Size(40, 40);
            this.btSwInfo.TabIndex = 110;
            this.btSwInfo.UseVisualStyleBackColor = true;
            this.btSwInfo.Click += new System.EventHandler(this.BtYoutube_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(205, 156);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(86, 23);
            this.button2.TabIndex = 111;
            this.button2.Text = "test";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.TestButton_Click);
            // 
            // RemoteControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 461);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btSwInfo);
            this.Controls.Add(this.btnInput);
            this.Controls.Add(this.lbCurrentDevice);
            this.Controls.Add(this.cbSavedDevices);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.btMessage);
            this.Controls.Add(this.btChList);
            this.Controls.Add(this.btChan);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btVol);
            this.Controls.Add(this.btnTurnOff);
            this.Controls.Add(this.btnMute);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnTurnOn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chanMinus);
            this.Controls.Add(this.chanPlus);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btVolMinus);
            this.Controls.Add(this.btVolPlus);
            this.Controls.Add(this.txtResponse);
            this.Controls.Add(this.menuStripMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStripMain;
            this.MaximumSize = new System.Drawing.Size(900, 500);
            this.MinimumSize = new System.Drawing.Size(750, 500);
            this.Name = "RemoteControl";
            this.Text = "LG WebOs Remote Control";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RemoteControl_FormClosed);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtResponse;
        private System.Windows.Forms.Button btVolPlus;
        private System.Windows.Forms.Button btVolMinus;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button chanMinus;
        private System.Windows.Forms.Button chanPlus;
        private System.Windows.Forms.Button btnTurnOn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnMute;
        private System.Windows.Forms.Button btnTurnOff;
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuSetting;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDevManager;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Button btVol;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btChan;
        private System.Windows.Forms.Button btChList;
        private System.Windows.Forms.Button btMessage;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.ComboBox cbSavedDevices;
        private System.Windows.Forms.Label lbCurrentDevice;
        private System.Windows.Forms.Button btnInput;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemPairDevice;
        private System.Windows.Forms.Button btSwInfo;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemShowLog;
    }
}

