namespace LgTvController
{
    partial class ChannelListWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChannelListWindow));
            this.channelListTable = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.lbTotalNoChannels = new System.Windows.Forms.Label();
            this.lbRows = new System.Windows.Forms.Label();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.lbSearch = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.channelListTable)).BeginInit();
            this.SuspendLayout();
            // 
            // channelListTable
            // 
            this.channelListTable.AllowUserToAddRows = false;
            this.channelListTable.AllowUserToDeleteRows = false;
            this.channelListTable.AllowUserToResizeColumns = false;
            this.channelListTable.AllowUserToResizeRows = false;
            this.channelListTable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.channelListTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.channelListTable.Location = new System.Drawing.Point(12, 86);
            this.channelListTable.Name = "channelListTable";
            this.channelListTable.ReadOnly = true;
            this.channelListTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.channelListTable.Size = new System.Drawing.Size(360, 298);
            this.channelListTable.TabIndex = 0;
            this.channelListTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ChannelListTable_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Double click to open channel";
            // 
            // lbTotalNoChannels
            // 
            this.lbTotalNoChannels.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTotalNoChannels.AutoSize = true;
            this.lbTotalNoChannels.Location = new System.Drawing.Point(9, 9);
            this.lbTotalNoChannels.Name = "lbTotalNoChannels";
            this.lbTotalNoChannels.Size = new System.Drawing.Size(113, 13);
            this.lbTotalNoChannels.TabIndex = 2;
            this.lbTotalNoChannels.Text = "Total no. of channels: ";
            this.lbTotalNoChannels.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbRows
            // 
            this.lbRows.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbRows.Location = new System.Drawing.Point(284, 67);
            this.lbRows.Name = "lbRows";
            this.lbRows.Size = new System.Drawing.Size(88, 13);
            this.lbRows.TabIndex = 3;
            this.lbRows.Text = "Rows: ";
            this.lbRows.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbSearch
            // 
            this.tbSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSearch.Location = new System.Drawing.Point(272, 44);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(100, 20);
            this.tbSearch.TabIndex = 4;
            this.tbSearch.TextChanged += new System.EventHandler(this.TbSearch_TextChanged);
            // 
            // lbSearch
            // 
            this.lbSearch.AutoSize = true;
            this.lbSearch.Location = new System.Drawing.Point(224, 47);
            this.lbSearch.Name = "lbSearch";
            this.lbSearch.Size = new System.Drawing.Size(44, 13);
            this.lbSearch.TabIndex = 5;
            this.lbSearch.Text = "Search:";
            // 
            // ChannelListWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 396);
            this.Controls.Add(this.lbSearch);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.lbRows);
            this.Controls.Add(this.lbTotalNoChannels);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.channelListTable);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(400, 435);
            this.Name = "ChannelListWindow";
            this.Text = "Channel list";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ChannelListWindow_FormClosed);
            this.Load += new System.EventHandler(this.ChannelListWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.channelListTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView channelListTable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbTotalNoChannels;
        private System.Windows.Forms.Label lbRows;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Label lbSearch;
    }
}