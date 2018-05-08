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
            this.txtResponse = new System.Windows.Forms.TextBox();
            this.btnRequestParing = new System.Windows.Forms.Button();
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
            this.button12 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.btnTurnOn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnMute = new System.Windows.Forms.Button();
            this.btnTurnOff = new System.Windows.Forms.Button();
            this.lblMacAddr = new System.Windows.Forms.Label();
            this.tbMac = new System.Windows.Forms.TextBox();
            this.tbIP = new System.Windows.Forms.TextBox();
            this.tbApiKey = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemMac = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btVol = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtResponse
            // 
            this.txtResponse.Location = new System.Drawing.Point(12, 136);
            this.txtResponse.Multiline = true;
            this.txtResponse.Name = "txtResponse";
            this.txtResponse.ReadOnly = true;
            this.txtResponse.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResponse.Size = new System.Drawing.Size(546, 313);
            this.txtResponse.TabIndex = 0;
            // 
            // btnRequestParing
            // 
            this.btnRequestParing.Location = new System.Drawing.Point(287, 41);
            this.btnRequestParing.Name = "btnRequestParing";
            this.btnRequestParing.Size = new System.Drawing.Size(156, 23);
            this.btnRequestParing.TabIndex = 4;
            this.btnRequestParing.Text = "Request pairing";
            this.btnRequestParing.UseVisualStyleBackColor = true;
            // 
            // btVolPlus
            // 
            this.btVolPlus.Location = new System.Drawing.Point(569, 95);
            this.btVolPlus.Name = "btVolPlus";
            this.btVolPlus.Size = new System.Drawing.Size(47, 31);
            this.btVolPlus.TabIndex = 25;
            this.btVolPlus.Text = "+";
            this.btVolPlus.UseVisualStyleBackColor = true;
            this.btVolPlus.Click += new System.EventHandler(this.btVolPlus_Click);
            // 
            // btVolMinus
            // 
            this.btVolMinus.Location = new System.Drawing.Point(569, 132);
            this.btVolMinus.Name = "btVolMinus";
            this.btVolMinus.Size = new System.Drawing.Size(47, 31);
            this.btVolMinus.TabIndex = 45;
            this.btVolMinus.Text = "-";
            this.btVolMinus.UseVisualStyleBackColor = true;
            this.btVolMinus.Click += new System.EventHandler(this.btVolMinus_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(625, 132);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(47, 35);
            this.button3.TabIndex = 50;
            this.button3.Text = "▲";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(625, 215);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(47, 36);
            this.button4.TabIndex = 80;
            this.button4.Text = "▼";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(569, 173);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(47, 36);
            this.button5.TabIndex = 60;
            this.button5.Text = "◄";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Location = new System.Drawing.Point(679, 172);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(47, 36);
            this.button6.TabIndex = 70;
            this.button6.Text = "►";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(625, 173);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(47, 36);
            this.button7.TabIndex = 65;
            this.button7.Text = "OK";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(570, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Volume";
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(569, 215);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(47, 36);
            this.button8.TabIndex = 75;
            this.button8.Text = "Menu";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(625, 95);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(47, 31);
            this.button9.TabIndex = 30;
            this.button9.Text = "Exit";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(679, 214);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(47, 37);
            this.button10.TabIndex = 85;
            this.button10.Text = "Back";
            this.button10.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(678, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Channel";
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(678, 132);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(48, 35);
            this.button12.TabIndex = 55;
            this.button12.Text = "-";
            this.button12.UseVisualStyleBackColor = true;
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(678, 95);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(48, 31);
            this.button13.TabIndex = 40;
            this.button13.Text = "+";
            this.button13.UseVisualStyleBackColor = true;
            // 
            // btnTurnOn
            // 
            this.btnTurnOn.Location = new System.Drawing.Point(569, 257);
            this.btnTurnOn.Name = "btnTurnOn";
            this.btnTurnOn.Size = new System.Drawing.Size(157, 23);
            this.btnTurnOn.TabIndex = 90;
            this.btnTurnOn.Text = "Turn on";
            this.btnTurnOn.UseVisualStyleBackColor = true;
            this.btnTurnOn.Click += new System.EventHandler(this.btnTurnOn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "IP:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Key:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Log:";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(287, 69);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 45);
            this.btnConnect.TabIndex = 5;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(368, 69);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(75, 45);
            this.btnDisconnect.TabIndex = 6;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = false;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // btnMute
            // 
            this.btnMute.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnMute.Location = new System.Drawing.Point(628, 58);
            this.btnMute.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.btnMute.Name = "btnMute";
            this.btnMute.Size = new System.Drawing.Size(39, 31);
            this.btnMute.TabIndex = 20;
            this.btnMute.Text = "Mute";
            this.btnMute.UseVisualStyleBackColor = true;
            this.btnMute.Click += new System.EventHandler(this.btnMute_Click);
            // 
            // btnTurnOff
            // 
            this.btnTurnOff.Location = new System.Drawing.Point(569, 286);
            this.btnTurnOff.Name = "btnTurnOff";
            this.btnTurnOff.Size = new System.Drawing.Size(157, 23);
            this.btnTurnOff.TabIndex = 95;
            this.btnTurnOff.Text = "Turn off";
            this.btnTurnOff.UseVisualStyleBackColor = true;
            this.btnTurnOff.Click += new System.EventHandler(this.btnTurnOff_Click);
            // 
            // lblMacAddr
            // 
            this.lblMacAddr.AutoSize = true;
            this.lblMacAddr.Location = new System.Drawing.Point(12, 97);
            this.lblMacAddr.Name = "lblMacAddr";
            this.lblMacAddr.Size = new System.Drawing.Size(57, 13);
            this.lblMacAddr.TabIndex = 0;
            this.lblMacAddr.Text = "MAC addr:";
            // 
            // tbMac
            // 
            this.tbMac.Location = new System.Drawing.Point(71, 94);
            this.tbMac.Name = "tbMac";
            this.tbMac.Size = new System.Drawing.Size(210, 20);
            this.tbMac.TabIndex = 3;
            this.tbMac.Text = global::SmartTV.Properties.Settings.Default.macAddr;
            this.tbMac.Leave += new System.EventHandler(this.tbMac_Leave);
            // 
            // tbIP
            // 
            this.tbIP.Location = new System.Drawing.Point(71, 43);
            this.tbIP.Name = "tbIP";
            this.tbIP.Size = new System.Drawing.Size(210, 20);
            this.tbIP.TabIndex = 1;
            this.tbIP.Text = global::SmartTV.Properties.Settings.Default.ip;
            this.tbIP.Leave += new System.EventHandler(this.tbIP_Leave);
            // 
            // tbApiKey
            // 
            this.tbApiKey.Location = new System.Drawing.Point(71, 69);
            this.tbApiKey.Name = "tbApiKey";
            this.tbApiKey.Size = new System.Drawing.Size(210, 20);
            this.tbApiKey.TabIndex = 2;
            this.tbApiKey.Text = global::SmartTV.Properties.Settings.Default.apiKey;
            this.tbApiKey.Leave += new System.EventHandler(this.tbApiKey_Leave);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuSetting,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(734, 24);
            this.menuStrip1.TabIndex = 96;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuSetting
            // 
            this.toolStripMenuSetting.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemMac});
            this.toolStripMenuSetting.MergeAction = System.Windows.Forms.MergeAction.Remove;
            this.toolStripMenuSetting.Name = "toolStripMenuSetting";
            this.toolStripMenuSetting.Size = new System.Drawing.Size(61, 20);
            this.toolStripMenuSetting.Text = "Settings";
            // 
            // toolStripMenuItemMac
            // 
            this.toolStripMenuItemMac.Name = "toolStripMenuItemMac";
            this.toolStripMenuItemMac.Size = new System.Drawing.Size(144, 22);
            this.toolStripMenuItemMac.Text = "MAC address";
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
            this.btVol.Location = new System.Drawing.Point(569, 58);
            this.btVol.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.btVol.Name = "btVol";
            this.btVol.Size = new System.Drawing.Size(56, 31);
            this.btVol.TabIndex = 99;
            this.btVol.UseVisualStyleBackColor = true;
            this.btVol.Click += new System.EventHandler(this.btVol_Click);
            // 
            // RemoteControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 461);
            this.Controls.Add(this.btVol);
            this.Controls.Add(this.tbMac);
            this.Controls.Add(this.lblMacAddr);
            this.Controls.Add(this.btnTurnOff);
            this.Controls.Add(this.btnMute);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbIP);
            this.Controls.Add(this.btnTurnOn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.button13);
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
            this.Controls.Add(this.btnRequestParing);
            this.Controls.Add(this.tbApiKey);
            this.Controls.Add(this.txtResponse);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(750, 500);
            this.MinimumSize = new System.Drawing.Size(750, 500);
            this.Name = "RemoteControl";
            this.Text = "LG WebOs Remote Control";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RemoteControl_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtResponse;
        private System.Windows.Forms.TextBox tbApiKey;
        private System.Windows.Forms.Button btnRequestParing;
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
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button btnTurnOn;
        private System.Windows.Forms.TextBox tbIP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnMute;
        private System.Windows.Forms.Button btnTurnOff;
        private System.Windows.Forms.Label lblMacAddr;
        private System.Windows.Forms.TextBox tbMac;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuSetting;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemMac;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Button btVol;
    }
}

