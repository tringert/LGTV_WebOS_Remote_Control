using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LgTvController
{
    public partial class ChannelDetailsWindow : Form
    {
        internal string InfoString { get; set; }

        public ChannelDetailsWindow()
        {
            InitializeComponent();
        }

        private void ChannelDetailsWindow_Load(object sender, EventArgs e)
        {
            tbChannelDetails.Text = InfoString;
            tbChannelDetails.Select(0, 0);
            tbChannelDetails.ScrollToCaret();
        }
    }
}
