﻿namespace LgTvController
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
            this.tbLog = new System.Windows.Forms.TextBox();
            this.btVolPlus = new System.Windows.Forms.Button();
            this.btVolMinus = new System.Windows.Forms.Button();
            this.btUp = new System.Windows.Forms.Button();
            this.btDown = new System.Windows.Forms.Button();
            this.btLeft = new System.Windows.Forms.Button();
            this.btRight = new System.Windows.Forms.Button();
            this.btOk = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btMenu = new System.Windows.Forms.Button();
            this.btExit = new System.Windows.Forms.Button();
            this.btBack = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.chanMinus = new System.Windows.Forms.Button();
            this.chanPlus = new System.Windows.Forms.Button();
            this.btnTurnOn = new System.Windows.Forms.Button();
            this.lbLog = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnTurnOff = new System.Windows.Forms.Button();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDevManager = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemPairDevice = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemShowLog = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemHelpHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.btVol = new System.Windows.Forms.Button();
            this.btChan = new System.Windows.Forms.Button();
            this.btChList = new System.Windows.Forms.Button();
            this.btMessage = new System.Windows.Forms.Button();
            this.btChannelProgramInfo = new System.Windows.Forms.Button();
            this.btTrash = new System.Windows.Forms.Button();
            this.btnMute = new System.Windows.Forms.Button();
            this.cbSavedDevices = new System.Windows.Forms.ComboBox();
            this.lbCurrentDevice = new System.Windows.Forms.Label();
            this.btnInput = new System.Windows.Forms.Button();
            this.btYoutube = new System.Windows.Forms.Button();
            this.btTest = new System.Windows.Forms.Button();
            this.menuStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbLog
            // 
            this.tbLog.Location = new System.Drawing.Point(326, 51);
            this.tbLog.Multiline = true;
            this.tbLog.Name = "tbLog";
            this.tbLog.ReadOnly = true;
            this.tbLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbLog.Size = new System.Drawing.Size(546, 398);
            this.tbLog.TabIndex = 100;
            this.tbLog.TabStop = false;
            // 
            // btVolPlus
            // 
            this.btVolPlus.Location = new System.Drawing.Point(44, 182);
            this.btVolPlus.Name = "btVolPlus";
            this.btVolPlus.Size = new System.Drawing.Size(47, 36);
            this.btVolPlus.TabIndex = 8;
            this.btVolPlus.Text = "+";
            this.btVolPlus.UseVisualStyleBackColor = true;
            this.btVolPlus.Click += new System.EventHandler(this.BtVolPlus_Click);
            // 
            // btVolMinus
            // 
            this.btVolMinus.Location = new System.Drawing.Point(44, 224);
            this.btVolMinus.Name = "btVolMinus";
            this.btVolMinus.Size = new System.Drawing.Size(47, 36);
            this.btVolMinus.TabIndex = 9;
            this.btVolMinus.Text = "-";
            this.btVolMinus.UseVisualStyleBackColor = true;
            this.btVolMinus.Click += new System.EventHandler(this.BtVolMinus_Click);
            // 
            // btUp
            // 
            this.btUp.Enabled = false;
            this.btUp.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btUp.Location = new System.Drawing.Point(100, 267);
            this.btUp.Name = "btUp";
            this.btUp.Size = new System.Drawing.Size(47, 36);
            this.btUp.TabIndex = 50;
            this.btUp.Text = "▲";
            this.btUp.UseVisualStyleBackColor = true;
            // 
            // btDown
            // 
            this.btDown.Enabled = false;
            this.btDown.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDown.Location = new System.Drawing.Point(100, 350);
            this.btDown.Name = "btDown";
            this.btDown.Size = new System.Drawing.Size(47, 36);
            this.btDown.TabIndex = 80;
            this.btDown.Text = "▼";
            this.btDown.UseVisualStyleBackColor = true;
            // 
            // btLeft
            // 
            this.btLeft.Enabled = false;
            this.btLeft.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btLeft.Location = new System.Drawing.Point(44, 308);
            this.btLeft.Name = "btLeft";
            this.btLeft.Size = new System.Drawing.Size(47, 36);
            this.btLeft.TabIndex = 60;
            this.btLeft.Text = "◄";
            this.btLeft.UseVisualStyleBackColor = true;
            // 
            // btRight
            // 
            this.btRight.Enabled = false;
            this.btRight.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btRight.Location = new System.Drawing.Point(154, 308);
            this.btRight.Name = "btRight";
            this.btRight.Size = new System.Drawing.Size(47, 36);
            this.btRight.TabIndex = 70;
            this.btRight.Text = "►";
            this.btRight.UseVisualStyleBackColor = true;
            // 
            // btOk
            // 
            this.btOk.Enabled = false;
            this.btOk.Location = new System.Drawing.Point(100, 308);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(47, 36);
            this.btOk.TabIndex = 65;
            this.btOk.Text = "OK";
            this.btOk.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Volume";
            // 
            // btMenu
            // 
            this.btMenu.Enabled = false;
            this.btMenu.Location = new System.Drawing.Point(44, 351);
            this.btMenu.Name = "btMenu";
            this.btMenu.Size = new System.Drawing.Size(47, 36);
            this.btMenu.TabIndex = 75;
            this.btMenu.Text = "Menu";
            this.btMenu.UseVisualStyleBackColor = true;
            // 
            // btExit
            // 
            this.btExit.Location = new System.Drawing.Point(154, 266);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(47, 36);
            this.btExit.TabIndex = 30;
            this.btExit.Text = "Exit";
            this.btExit.UseVisualStyleBackColor = true;
            this.btExit.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // btBack
            // 
            this.btBack.Enabled = false;
            this.btBack.Location = new System.Drawing.Point(44, 267);
            this.btBack.Name = "btBack";
            this.btBack.Size = new System.Drawing.Size(47, 36);
            this.btBack.TabIndex = 85;
            this.btBack.Text = "Back";
            this.btBack.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(153, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Channel";
            // 
            // chanMinus
            // 
            this.chanMinus.Location = new System.Drawing.Point(154, 224);
            this.chanMinus.Name = "chanMinus";
            this.chanMinus.Size = new System.Drawing.Size(47, 36);
            this.chanMinus.TabIndex = 11;
            this.chanMinus.Text = "-";
            this.chanMinus.UseVisualStyleBackColor = true;
            this.chanMinus.Click += new System.EventHandler(this.ChanMinus_Click);
            // 
            // chanPlus
            // 
            this.chanPlus.Location = new System.Drawing.Point(154, 182);
            this.chanPlus.Name = "chanPlus";
            this.chanPlus.Size = new System.Drawing.Size(47, 36);
            this.chanPlus.TabIndex = 10;
            this.chanPlus.Text = "+";
            this.chanPlus.UseVisualStyleBackColor = true;
            this.chanPlus.Click += new System.EventHandler(this.ChanPlus_Click);
            // 
            // btnTurnOn
            // 
            this.btnTurnOn.Location = new System.Drawing.Point(44, 393);
            this.btnTurnOn.Name = "btnTurnOn";
            this.btnTurnOn.Size = new System.Drawing.Size(157, 23);
            this.btnTurnOn.TabIndex = 90;
            this.btnTurnOn.Text = "Turn on";
            this.btnTurnOn.UseVisualStyleBackColor = true;
            this.btnTurnOn.Click += new System.EventHandler(this.BtnTurnOn_Click);
            // 
            // lbLog
            // 
            this.lbLog.AutoSize = true;
            this.lbLog.Location = new System.Drawing.Point(323, 35);
            this.lbLog.Name = "lbLog";
            this.lbLog.Size = new System.Drawing.Size(28, 13);
            this.lbLog.TabIndex = 0;
            this.lbLog.Text = "Log:";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(31, 84);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(89, 23);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.BtnConnect_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(126, 84);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(87, 23);
            this.btnDisconnect.TabIndex = 3;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = false;
            this.btnDisconnect.Click += new System.EventHandler(this.BtnDisconnect_Click);
            // 
            // btnTurnOff
            // 
            this.btnTurnOff.Location = new System.Drawing.Point(44, 422);
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
            this.toolStripMenuItemHelp});
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
            this.toolStripMenuSetting.ShortcutKeyDisplayString = "";
            this.toolStripMenuSetting.Size = new System.Drawing.Size(61, 20);
            this.toolStripMenuSetting.Text = "Settings";
            // 
            // toolStripMenuItemDevManager
            // 
            this.toolStripMenuItemDevManager.Name = "toolStripMenuItemDevManager";
            this.toolStripMenuItemDevManager.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.toolStripMenuItemDevManager.Size = new System.Drawing.Size(201, 22);
            this.toolStripMenuItemDevManager.Text = "Device manager";
            this.toolStripMenuItemDevManager.Click += new System.EventHandler(this.ToolStripMenuItemDevManager_Click);
            // 
            // toolStripMenuItemPairDevice
            // 
            this.toolStripMenuItemPairDevice.Name = "toolStripMenuItemPairDevice";
            this.toolStripMenuItemPairDevice.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.toolStripMenuItemPairDevice.Size = new System.Drawing.Size(201, 22);
            this.toolStripMenuItemPairDevice.Text = "Pair new device";
            this.toolStripMenuItemPairDevice.Click += new System.EventHandler(this.PairDeviceToolStripMenuItem_Click);
            // 
            // toolStripMenuItemShowLog
            // 
            this.toolStripMenuItemShowLog.Name = "toolStripMenuItemShowLog";
            this.toolStripMenuItemShowLog.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.toolStripMenuItemShowLog.Size = new System.Drawing.Size(201, 22);
            this.toolStripMenuItemShowLog.Text = "Show log";
            this.toolStripMenuItemShowLog.Click += new System.EventHandler(this.ShowLogToolStripMenuItem_Click);
            // 
            // toolStripMenuItemHelp
            // 
            this.toolStripMenuItemHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemHelpHelp,
            this.toolStripMenuItemAbout});
            this.toolStripMenuItemHelp.Name = "toolStripMenuItemHelp";
            this.toolStripMenuItemHelp.Size = new System.Drawing.Size(44, 20);
            this.toolStripMenuItemHelp.Text = "Help";
            // 
            // toolStripMenuItemHelpHelp
            // 
            this.toolStripMenuItemHelpHelp.Name = "toolStripMenuItemHelpHelp";
            this.toolStripMenuItemHelpHelp.Size = new System.Drawing.Size(107, 22);
            this.toolStripMenuItemHelpHelp.Text = "Help";
            // 
            // toolStripMenuItemAbout
            // 
            this.toolStripMenuItemAbout.Name = "toolStripMenuItemAbout";
            this.toolStripMenuItemAbout.Size = new System.Drawing.Size(107, 22);
            this.toolStripMenuItemAbout.Text = "About";
            // 
            // btVol
            // 
            this.btVol.Location = new System.Drawing.Point(44, 140);
            this.btVol.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.btVol.Name = "btVol";
            this.btVol.Size = new System.Drawing.Size(76, 36);
            this.btVol.TabIndex = 99;
            this.btVol.UseVisualStyleBackColor = true;
            this.btVol.Click += new System.EventHandler(this.BtVol_Click);
            // 
            // btChan
            // 
            this.btChan.Location = new System.Drawing.Point(125, 140);
            this.btChan.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.btChan.Name = "btChan";
            this.btChan.Size = new System.Drawing.Size(76, 36);
            this.btChan.TabIndex = 101;
            this.btChan.UseVisualStyleBackColor = true;
            this.btChan.Click += new System.EventHandler(this.BtChan_Click);
            // 
            // btChList
            // 
            this.btChList.Location = new System.Drawing.Point(99, 182);
            this.btChList.Name = "btChList";
            this.btChList.Size = new System.Drawing.Size(47, 36);
            this.btChList.TabIndex = 13;
            this.btChList.Text = "Ch. list";
            this.btChList.UseVisualStyleBackColor = true;
            this.btChList.Click += new System.EventHandler(this.BtChList_Click);
            // 
            // btMessage
            // 
            this.btMessage.Location = new System.Drawing.Point(219, 84);
            this.btMessage.Name = "btMessage";
            this.btMessage.Size = new System.Drawing.Size(86, 23);
            this.btMessage.TabIndex = 5;
            this.btMessage.Text = "Message";
            this.btMessage.UseVisualStyleBackColor = true;
            this.btMessage.Click += new System.EventHandler(this.BtMessage_Click);
            // 
            // btChannelProgramInfo
            // 
            this.btChannelProgramInfo.Image = ((System.Drawing.Image)(resources.GetObject("btChannelProgramInfo.Image")));
            this.btChannelProgramInfo.Location = new System.Drawing.Point(265, 110);
            this.btChannelProgramInfo.Name = "btChannelProgramInfo";
            this.btChannelProgramInfo.Size = new System.Drawing.Size(40, 40);
            this.btChannelProgramInfo.TabIndex = 7;
            this.btChannelProgramInfo.UseVisualStyleBackColor = true;
            this.btChannelProgramInfo.Click += new System.EventHandler(this.ChannelProgramInfoButton_Click);
            // 
            // btTrash
            // 
            this.btTrash.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btTrash.Image = ((System.Drawing.Image)(resources.GetObject("btTrash.Image")));
            this.btTrash.Location = new System.Drawing.Point(842, 18);
            this.btTrash.Margin = new System.Windows.Forms.Padding(0);
            this.btTrash.Name = "btTrash";
            this.btTrash.Size = new System.Drawing.Size(30, 30);
            this.btTrash.TabIndex = 15;
            this.btTrash.UseVisualStyleBackColor = false;
            this.btTrash.Click += new System.EventHandler(this.BtTrash_Click);
            // 
            // btnMute
            // 
            this.btnMute.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnMute.Image = ((System.Drawing.Image)(resources.GetObject("btnMute.Image")));
            this.btnMute.Location = new System.Drawing.Point(99, 224);
            this.btnMute.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.btnMute.Name = "btnMute";
            this.btnMute.Size = new System.Drawing.Size(47, 36);
            this.btnMute.TabIndex = 12;
            this.btnMute.UseVisualStyleBackColor = true;
            this.btnMute.Click += new System.EventHandler(this.BtnMute_Click);
            // 
            // cbSavedDevices
            // 
            this.cbSavedDevices.FormattingEnabled = true;
            this.cbSavedDevices.Location = new System.Drawing.Point(31, 57);
            this.cbSavedDevices.Name = "cbSavedDevices";
            this.cbSavedDevices.Size = new System.Drawing.Size(182, 21);
            this.cbSavedDevices.TabIndex = 1;
            this.cbSavedDevices.SelectionChangeCommitted += new System.EventHandler(this.CbSavedDevices_SelectionChangeCommitted);
            // 
            // lbCurrentDevice
            // 
            this.lbCurrentDevice.AutoSize = true;
            this.lbCurrentDevice.Location = new System.Drawing.Point(28, 41);
            this.lbCurrentDevice.Name = "lbCurrentDevice";
            this.lbCurrentDevice.Size = new System.Drawing.Size(44, 13);
            this.lbCurrentDevice.TabIndex = 107;
            this.lbCurrentDevice.Text = "Device:";
            // 
            // btnInput
            // 
            this.btnInput.Location = new System.Drawing.Point(219, 56);
            this.btnInput.Name = "btnInput";
            this.btnInput.Size = new System.Drawing.Size(86, 23);
            this.btnInput.TabIndex = 4;
            this.btnInput.Text = "Inputs";
            this.btnInput.UseVisualStyleBackColor = true;
            this.btnInput.Click += new System.EventHandler(this.BtnInput_Click);
            // 
            // btYoutube
            // 
            this.btYoutube.Image = global::LgTvController.Properties.Resources.youtube_icon_35x35px;
            this.btYoutube.Location = new System.Drawing.Point(219, 110);
            this.btYoutube.Name = "btYoutube";
            this.btYoutube.Size = new System.Drawing.Size(40, 40);
            this.btYoutube.TabIndex = 6;
            this.btYoutube.UseVisualStyleBackColor = true;
            this.btYoutube.Click += new System.EventHandler(this.BtYoutube_Click);
            // 
            // btTest
            // 
            this.btTest.Location = new System.Drawing.Point(219, 156);
            this.btTest.Name = "btTest";
            this.btTest.Size = new System.Drawing.Size(86, 23);
            this.btTest.TabIndex = 111;
            this.btTest.Text = "test";
            this.btTest.UseVisualStyleBackColor = true;
            this.btTest.Click += new System.EventHandler(this.TestButton_Click);
            // 
            // RemoteControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 461);
            this.Controls.Add(this.btTest);
            this.Controls.Add(this.btYoutube);
            this.Controls.Add(this.btnInput);
            this.Controls.Add(this.lbCurrentDevice);
            this.Controls.Add(this.cbSavedDevices);
            this.Controls.Add(this.btChannelProgramInfo);
            this.Controls.Add(this.btMessage);
            this.Controls.Add(this.btChList);
            this.Controls.Add(this.btChan);
            this.Controls.Add(this.btTrash);
            this.Controls.Add(this.btVol);
            this.Controls.Add(this.btnTurnOff);
            this.Controls.Add(this.btnMute);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.lbLog);
            this.Controls.Add(this.btnTurnOn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chanMinus);
            this.Controls.Add(this.chanPlus);
            this.Controls.Add(this.btBack);
            this.Controls.Add(this.btExit);
            this.Controls.Add(this.btMenu);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btOk);
            this.Controls.Add(this.btRight);
            this.Controls.Add(this.btLeft);
            this.Controls.Add(this.btDown);
            this.Controls.Add(this.btUp);
            this.Controls.Add(this.btVolMinus);
            this.Controls.Add(this.btVolPlus);
            this.Controls.Add(this.tbLog);
            this.Controls.Add(this.menuStripMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStripMain;
            this.MaximumSize = new System.Drawing.Size(900, 500);
            this.MinimumSize = new System.Drawing.Size(323, 500);
            this.Name = "RemoteControl";
            this.Text = "LG TV WebOs Remote Control";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RemoteControl_FormClosed);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbLog;
        private System.Windows.Forms.Button btVolPlus;
        private System.Windows.Forms.Button btVolMinus;
        private System.Windows.Forms.Button btUp;
        private System.Windows.Forms.Button btDown;
        private System.Windows.Forms.Button btLeft;
        private System.Windows.Forms.Button btRight;
        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btMenu;
        private System.Windows.Forms.Button btExit;
        private System.Windows.Forms.Button btBack;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button chanMinus;
        private System.Windows.Forms.Button chanPlus;
        private System.Windows.Forms.Button btnTurnOn;
        private System.Windows.Forms.Label lbLog;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnMute;
        private System.Windows.Forms.Button btnTurnOff;
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuSetting;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDevManager;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemHelp;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemHelpHelp;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAbout;
        private System.Windows.Forms.Button btVol;
        private System.Windows.Forms.Button btTrash;
        private System.Windows.Forms.Button btChan;
        private System.Windows.Forms.Button btChList;
        private System.Windows.Forms.Button btMessage;
        private System.Windows.Forms.Button btChannelProgramInfo;
        private System.Windows.Forms.ComboBox cbSavedDevices;
        private System.Windows.Forms.Label lbCurrentDevice;
        private System.Windows.Forms.Button btnInput;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemPairDevice;
        private System.Windows.Forms.Button btYoutube;
        private System.Windows.Forms.Button btTest;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemShowLog;
    }
}

