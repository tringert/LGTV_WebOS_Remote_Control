namespace LgTvController
{
    partial class ChannelDetailsWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChannelDetailsWindow));
            this.tbChannelDetails = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbChannelDetails
            // 
            this.tbChannelDetails.Location = new System.Drawing.Point(12, 12);
            this.tbChannelDetails.Multiline = true;
            this.tbChannelDetails.Name = "tbChannelDetails";
            this.tbChannelDetails.ReadOnly = true;
            this.tbChannelDetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbChannelDetails.Size = new System.Drawing.Size(341, 349);
            this.tbChannelDetails.TabIndex = 0;
            // 
            // ChannelDetailsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 373);
            this.Controls.Add(this.tbChannelDetails);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(381, 412);
            this.MinimumSize = new System.Drawing.Size(381, 412);
            this.Name = "ChannelDetailsWindow";
            this.Text = "Channel details";
            this.Load += new System.EventHandler(this.ChannelDetailsWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbChannelDetails;
    }
}