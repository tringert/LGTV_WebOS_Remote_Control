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
            this.btPlay = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbUrl
            // 
            this.lbUrl.AutoSize = true;
            this.lbUrl.Location = new System.Drawing.Point(12, 35);
            this.lbUrl.Name = "lbUrl";
            this.lbUrl.Size = new System.Drawing.Size(32, 13);
            this.lbUrl.TabIndex = 0;
            this.lbUrl.Text = "URL:";
            // 
            // tbUrl
            // 
            this.tbUrl.Location = new System.Drawing.Point(53, 32);
            this.tbUrl.Name = "tbUrl";
            this.tbUrl.Size = new System.Drawing.Size(454, 20);
            this.tbUrl.TabIndex = 1;
            // 
            // btPlay
            // 
            this.btPlay.Location = new System.Drawing.Point(513, 30);
            this.btPlay.Name = "btPlay";
            this.btPlay.Size = new System.Drawing.Size(75, 23);
            this.btPlay.TabIndex = 2;
            this.btPlay.Text = "Play";
            this.btPlay.UseVisualStyleBackColor = true;
            this.btPlay.Click += new System.EventHandler(this.BtPlay_Click);
            // 
            // YoutubeWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 121);
            this.Controls.Add(this.btPlay);
            this.Controls.Add(this.tbUrl);
            this.Controls.Add(this.lbUrl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "YoutubeWindow";
            this.Text = "YoutubeWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbUrl;
        private System.Windows.Forms.TextBox tbUrl;
        private System.Windows.Forms.Button btPlay;
    }
}