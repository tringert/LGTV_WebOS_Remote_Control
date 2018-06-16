namespace LgTvController
{
    partial class ProgramInfoWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProgramInfoWindow));
            this.dgvProgramList = new System.Windows.Forms.DataGridView();
            this.lbCurrentChannelName = new System.Windows.Forms.Label();
            this.lbCurrentChannelProgramName = new System.Windows.Forms.Label();
            this.lbGenre = new System.Windows.Forms.Label();
            this.pbElapsedPercentage = new System.Windows.Forms.ProgressBar();
            this.btMoreDetails = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProgramList)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvProgramList
            // 
            this.dgvProgramList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProgramList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProgramList.Location = new System.Drawing.Point(12, 95);
            this.dgvProgramList.MultiSelect = false;
            this.dgvProgramList.Name = "dgvProgramList";
            this.dgvProgramList.ReadOnly = true;
            this.dgvProgramList.RowHeadersVisible = false;
            this.dgvProgramList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvProgramList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProgramList.Size = new System.Drawing.Size(750, 343);
            this.dgvProgramList.TabIndex = 1;
            // 
            // lbCurrentChannelName
            // 
            this.lbCurrentChannelName.AutoSize = true;
            this.lbCurrentChannelName.Location = new System.Drawing.Point(13, 21);
            this.lbCurrentChannelName.MinimumSize = new System.Drawing.Size(300, 15);
            this.lbCurrentChannelName.Name = "lbCurrentChannelName";
            this.lbCurrentChannelName.Size = new System.Drawing.Size(300, 15);
            this.lbCurrentChannelName.TabIndex = 5;
            this.lbCurrentChannelName.Text = "Current channel name";
            // 
            // lbCurrentChannelProgramName
            // 
            this.lbCurrentChannelProgramName.AutoSize = true;
            this.lbCurrentChannelProgramName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbCurrentChannelProgramName.Location = new System.Drawing.Point(10, 39);
            this.lbCurrentChannelProgramName.MinimumSize = new System.Drawing.Size(750, 15);
            this.lbCurrentChannelProgramName.Name = "lbCurrentChannelProgramName";
            this.lbCurrentChannelProgramName.Size = new System.Drawing.Size(750, 20);
            this.lbCurrentChannelProgramName.TabIndex = 5;
            this.lbCurrentChannelProgramName.Text = "Current channel program name";
            // 
            // lbGenre
            // 
            this.lbGenre.AutoSize = true;
            this.lbGenre.Location = new System.Drawing.Point(13, 63);
            this.lbGenre.MinimumSize = new System.Drawing.Size(300, 15);
            this.lbGenre.Name = "lbGenre";
            this.lbGenre.Size = new System.Drawing.Size(300, 15);
            this.lbGenre.TabIndex = 5;
            this.lbGenre.Text = "Genre";
            // 
            // pbElapsedPercentage
            // 
            this.pbElapsedPercentage.BackColor = System.Drawing.SystemColors.MenuBar;
            this.pbElapsedPercentage.ForeColor = System.Drawing.Color.Lime;
            this.pbElapsedPercentage.Location = new System.Drawing.Point(536, 10);
            this.pbElapsedPercentage.Name = "pbElapsedPercentage";
            this.pbElapsedPercentage.Size = new System.Drawing.Size(224, 23);
            this.pbElapsedPercentage.Step = 100;
            this.pbElapsedPercentage.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbElapsedPercentage.TabIndex = 5;
            // 
            // btMoreDetails
            // 
            this.btMoreDetails.Location = new System.Drawing.Point(670, 66);
            this.btMoreDetails.Name = "btMoreDetails";
            this.btMoreDetails.Size = new System.Drawing.Size(90, 23);
            this.btMoreDetails.TabIndex = 2;
            this.btMoreDetails.Text = "Channel details";
            this.btMoreDetails.UseVisualStyleBackColor = true;
            this.btMoreDetails.Click += new System.EventHandler(this.BtMoreDetails_Click);
            // 
            // ProgramInfoWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 450);
            this.Controls.Add(this.btMoreDetails);
            this.Controls.Add(this.pbElapsedPercentage);
            this.Controls.Add(this.lbGenre);
            this.Controls.Add(this.lbCurrentChannelProgramName);
            this.Controls.Add(this.lbCurrentChannelName);
            this.Controls.Add(this.dgvProgramList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ProgramInfoWindow";
            this.Text = "Program and channel info";
            this.Load += new System.EventHandler(this.ProgramInfoWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProgramList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProgramList;
        private System.Windows.Forms.Label lbCurrentChannelName;
        private System.Windows.Forms.Label lbCurrentChannelProgramName;
        private System.Windows.Forms.Label lbGenre;
        private System.Windows.Forms.ProgressBar pbElapsedPercentage;
        private System.Windows.Forms.Button btMoreDetails;
    }
}