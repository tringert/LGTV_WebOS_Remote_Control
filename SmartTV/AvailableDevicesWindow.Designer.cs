namespace LgTvController
{
    partial class AvailableDevicesWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AvailableDevicesWindow));
            this.dgvAvailableDevices = new System.Windows.Forms.DataGridView();
            this.lbAnimatedDots = new System.Windows.Forms.Label();
            this.lbSearching = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvailableDevices)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAvailableDevices
            // 
            this.dgvAvailableDevices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAvailableDevices.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvAvailableDevices.Location = new System.Drawing.Point(10, 44);
            this.dgvAvailableDevices.Name = "dgvAvailableDevices";
            this.dgvAvailableDevices.Size = new System.Drawing.Size(448, 120);
            this.dgvAvailableDevices.TabIndex = 0;
            this.dgvAvailableDevices.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvAvailableDevices_CellContentDoubleClick);
            // 
            // lbAnimatedDots
            // 
            this.lbAnimatedDots.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbAnimatedDots.Location = new System.Drawing.Point(57, 24);
            this.lbAnimatedDots.Margin = new System.Windows.Forms.Padding(0);
            this.lbAnimatedDots.Name = "lbAnimatedDots";
            this.lbAnimatedDots.Size = new System.Drawing.Size(30, 15);
            this.lbAnimatedDots.TabIndex = 1;
            this.lbAnimatedDots.Text = "...";
            // 
            // lbSearching
            // 
            this.lbSearching.Location = new System.Drawing.Point(7, 26);
            this.lbSearching.Margin = new System.Windows.Forms.Padding(0);
            this.lbSearching.Name = "lbSearching";
            this.lbSearching.Size = new System.Drawing.Size(55, 15);
            this.lbSearching.TabIndex = 2;
            this.lbSearching.Text = "Searching";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(325, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Double click to pair device";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // AvailableDevicesWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 175);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbSearching);
            this.Controls.Add(this.lbAnimatedDots);
            this.Controls.Add(this.dgvAvailableDevices);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(673, 303);
            this.Name = "AvailableDevicesWindow";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "AvailableDevicesWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AvailableDevicesWindow_FormClosing);
            this.Load += new System.EventHandler(this.AvailableDevicesWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvailableDevices)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAvailableDevices;
        private System.Windows.Forms.Label lbAnimatedDots;
        private System.Windows.Forms.Label lbSearching;
        private System.Windows.Forms.Label label1;
    }
}