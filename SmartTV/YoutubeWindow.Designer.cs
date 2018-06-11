namespace LgTvController
{
    partial class YoutubeWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(YoutubeWindow));
            this.lbUrl = new System.Windows.Forms.Label();
            this.tbUrl = new System.Windows.Forms.TextBox();
            this.btOpenVideo = new System.Windows.Forms.Button();
            this.btFastForward = new System.Windows.Forms.Button();
            this.btRewind = new System.Windows.Forms.Button();
            this.btStop = new System.Windows.Forms.Button();
            this.btPause = new System.Windows.Forms.Button();
            this.btPlay = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbUrl
            // 
            this.lbUrl.AutoSize = true;
            this.lbUrl.Location = new System.Drawing.Point(116, 32);
            this.lbUrl.Name = "lbUrl";
            this.lbUrl.Size = new System.Drawing.Size(32, 13);
            this.lbUrl.TabIndex = 0;
            this.lbUrl.Text = "URL:";
            // 
            // tbUrl
            // 
            this.tbUrl.Location = new System.Drawing.Point(149, 29);
            this.tbUrl.Name = "tbUrl";
            this.tbUrl.Size = new System.Drawing.Size(247, 20);
            this.tbUrl.TabIndex = 1;
            // 
            // btOpenVideo
            // 
            this.btOpenVideo.Location = new System.Drawing.Point(402, 27);
            this.btOpenVideo.Name = "btOpenVideo";
            this.btOpenVideo.Size = new System.Drawing.Size(75, 23);
            this.btOpenVideo.TabIndex = 2;
            this.btOpenVideo.Text = "Open video";
            this.btOpenVideo.UseVisualStyleBackColor = true;
            this.btOpenVideo.Click += new System.EventHandler(this.BtOpenVideo_Click);
            // 
            // btFastForward
            // 
            this.btFastForward.Image = global::LgTvController.Properties.Resources.fastforward_icon_20x20px;
            this.btFastForward.Location = new System.Drawing.Point(330, 60);
            this.btFastForward.Name = "btFastForward";
            this.btFastForward.Size = new System.Drawing.Size(30, 30);
            this.btFastForward.TabIndex = 8;
            this.btFastForward.UseVisualStyleBackColor = true;
            this.btFastForward.Click += new System.EventHandler(this.FastForwardButton_Click);
            // 
            // btRewind
            // 
            this.btRewind.Image = global::LgTvController.Properties.Resources.rewind_icon_20x20px;
            this.btRewind.Location = new System.Drawing.Point(186, 60);
            this.btRewind.Name = "btRewind";
            this.btRewind.Size = new System.Drawing.Size(30, 30);
            this.btRewind.TabIndex = 7;
            this.btRewind.UseVisualStyleBackColor = true;
            this.btRewind.Click += new System.EventHandler(this.RewindButton_Click);
            // 
            // btStop
            // 
            this.btStop.Image = global::LgTvController.Properties.Resources.stop_icon_20x20px;
            this.btStop.Location = new System.Drawing.Point(294, 60);
            this.btStop.Name = "btStop";
            this.btStop.Size = new System.Drawing.Size(30, 30);
            this.btStop.TabIndex = 6;
            this.btStop.UseVisualStyleBackColor = true;
            this.btStop.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // btPause
            // 
            this.btPause.Image = global::LgTvController.Properties.Resources.pause_icon_20x20px;
            this.btPause.Location = new System.Drawing.Point(258, 60);
            this.btPause.Name = "btPause";
            this.btPause.Size = new System.Drawing.Size(30, 30);
            this.btPause.TabIndex = 5;
            this.btPause.UseVisualStyleBackColor = true;
            this.btPause.Click += new System.EventHandler(this.PauseButton_Click);
            // 
            // btPlay
            // 
            this.btPlay.Image = global::LgTvController.Properties.Resources.play_icon_20x20px;
            this.btPlay.Location = new System.Drawing.Point(222, 60);
            this.btPlay.Name = "btPlay";
            this.btPlay.Size = new System.Drawing.Size(30, 30);
            this.btPlay.TabIndex = 4;
            this.btPlay.UseVisualStyleBackColor = true;
            this.btPlay.Click += new System.EventHandler(this.PlayButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::LgTvController.Properties.Resources.Youtube_icon_red;
            this.pictureBox1.Location = new System.Drawing.Point(12, 29);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(402, 64);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Close app";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // YoutubeWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 109);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btFastForward);
            this.Controls.Add(this.btRewind);
            this.Controls.Add(this.btStop);
            this.Controls.Add(this.btPause);
            this.Controls.Add(this.btPlay);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btOpenVideo);
            this.Controls.Add(this.tbUrl);
            this.Controls.Add(this.lbUrl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(509, 148);
            this.Name = "YoutubeWindow";
            this.Text = "Youtube app controller";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbUrl;
        private System.Windows.Forms.TextBox tbUrl;
        private System.Windows.Forms.Button btOpenVideo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btPlay;
        private System.Windows.Forms.Button btPause;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.Button btRewind;
        private System.Windows.Forms.Button btFastForward;
        private System.Windows.Forms.Button button1;
    }
}