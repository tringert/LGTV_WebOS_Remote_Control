using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace LgTvController
{
    public partial class ChannelListWindow : Form
    {
        internal List<Channel> channels;
        internal ChannelInfo ci;

        public ChannelListWindow()
        {
            InitializeComponent();
        }

        private void ChannelListWindow_Load(object sender, System.EventArgs e)
        {
            var result = channels.Select(r => new
            {
                r.ChannelNumber,
                r.ChannelName,
                r.ChannelType,
                r.ChannelId
            }).ToList();

            channelListTable.DataSource = result;
            channelListTable.AutoGenerateColumns = false;
            channelListTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            channelListTable.MultiSelect = false;
            channelListTable.Columns["ChannelNumber"].HeaderText = "Channel Number";
            channelListTable.Columns["ChannelNumber"].Width = 50;
            channelListTable.Columns["ChannelName"].HeaderText = "Channel_Name";
            channelListTable.Columns["ChannelName"].Width = 150;
            channelListTable.Columns["ChannelType"].HeaderText = "Channel Type";
            channelListTable.Columns["ChannelType"].Width = 100;
            channelListTable.Columns["ChannelId"].Visible = false;
            lbTotalNoChannels.Text = "Total no. of channels: " + result.Count;
            lbRows.Text = "Rows: " + channelListTable.Rows.Count;

            foreach (DataGridViewRow row in channelListTable.Rows)
            {
                if (row.Cells["ChannelId"].Value.ToString() == ci.Payload.ChannelId)
                    row.Selected = true;
            }

            channelListTable.FirstDisplayedScrollingRowIndex = channelListTable.SelectedRows[0].Index;
        }
        
        private void TbSearch_TextChanged(object sender, System.EventArgs e)
        {
            var result = channels.Select(r => new
            {
                r.ChannelNumber,
                r.ChannelName,
                r.ChannelType,
                r.ChannelId
            }).Where(x => x.ChannelName.ToLower().Contains(tbSearch.Text.ToLower())).ToList();

            channelListTable.DataSource = result;
        }

        private void ChannelListTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string chanId = channelListTable.Rows[e.RowIndex].Cells["ChannelId"].Value.ToString();
            var payload = JsonConvert.SerializeObject(new { channelId = chanId });
            (Application.OpenForms["RemoteControl"] as RemoteControl).CallFunctionWithPayload("openchannel_1", "ssap://tv/openChannel", "Open channel request sent.", payload);
        }

        private void ChannelListWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            (Application.OpenForms["RemoteControl"] as RemoteControl).GetCurrentChannel();
        }
    }
}
