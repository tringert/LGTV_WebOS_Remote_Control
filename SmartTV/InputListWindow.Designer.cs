namespace LgTvController
{
    partial class InputListWindow
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
            this.dgvInputList = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInputList)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvInputList
            // 
            this.dgvInputList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInputList.Location = new System.Drawing.Point(12, 12);
            this.dgvInputList.MultiSelect = false;
            this.dgvInputList.Name = "dgvInputList";
            this.dgvInputList.RowHeadersVisible = false;
            this.dgvInputList.Size = new System.Drawing.Size(363, 152);
            this.dgvInputList.TabIndex = 0;
            this.dgvInputList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInputList_CellClick);
            // 
            // InputListWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 182);
            this.Controls.Add(this.dgvInputList);
            this.MaximumSize = new System.Drawing.Size(403, 263);
            this.Name = "InputListWindow";
            this.Text = "InputListWindow";
            this.Load += new System.EventHandler(this.InputListWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInputList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvInputList;
    }
}