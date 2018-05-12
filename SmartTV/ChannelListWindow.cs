using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.ComponentModel;

namespace LgTvController
{
    public partial class ChannelListWindow : Form
    {
        public ChannelListWindow()
        {
            InitializeComponent();
        }

        internal List<Channel> channels;

        private void ChannelListWindow_Load(object sender, System.EventArgs e)
        {
            var result = channels.Select(r => new
            {
                r.ChannelName,
                r.ChannelNumber
            }).ToList();

            dataGridView1.DataSource = result;
            DataGridViewColumn col1 = new DataGridViewTextBoxColumn();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns["ChannelName"].HeaderText = "Channel Name";
            dataGridView1.Columns["ChannelNumber"].HeaderText = "Channel Number";

        }
    }
}
