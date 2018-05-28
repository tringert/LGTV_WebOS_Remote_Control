using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace LgTvController
{
    public partial class InputListWindow : Form
    {
        internal List<Devices> inputList;

        public InputListWindow()
        {
            InitializeComponent();
        }

        private void InputListWindow_Load(object sender, EventArgs e)
        {
            var result = inputList.Select(r => new
            {
                r.Id,
                r.Label,
                r.AppId,
                r.Icon,
                r.Connected
            }).ToList();

            bool allFalse = true;
            for (int i = 0; i < result.Count; i++)
            {
                if (result[i].Connected == true)
                    allFalse = false;
            }

            var liveTv = new { Id = "Live_TV",
                               Label = "LiveTV",
                               AppId = "com.webos.app.livetv",
                               Icon = "",
                               Connected = allFalse};
            result.Add(liveTv);

            dgvInputList.DataSource = result;
            dgvInputList.AutoGenerateColumns = false;
            dgvInputList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInputList.MultiSelect = false;
            dgvInputList.Columns["Id"].HeaderText = "Id";
            dgvInputList.Columns["Id"].Width = 90;
            dgvInputList.Columns["Label"].HeaderText = "Label";
            dgvInputList.Columns["Label"].Width = 90;
            dgvInputList.Columns["AppId"].HeaderText = "App Id";
            dgvInputList.Columns["AppId"].Width = 150;
            dgvInputList.Columns["AppId"].Visible = false;
            dgvInputList.Columns["Connected"].HeaderText = "App Id";
            dgvInputList.Columns["Connected"].Width = 150;
            dgvInputList.Columns["Connected"].Visible = false;
            dgvInputList.Columns["Icon"].HeaderText = "Icon";
            dgvInputList.Columns["Icon"].Width = 100;
            dgvInputList.Columns["Icon"].Visible = false;

            foreach (DataGridViewRow row in dgvInputList.Rows)
            {
                if (row.Cells["Connected"].Value.ToString() == "true")
                    row.Selected = true;
            }

            dgvInputList.Rows[0].Selected = true;
            dgvInputList.FirstDisplayedScrollingRowIndex = dgvInputList.SelectedRows[0].Index;
        }

        private void DgvInputList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string inputId = dgvInputList.Rows[e.RowIndex].Cells["AppId"].Value.ToString();
            var payload = JsonConvert.SerializeObject(new { channelId = inputId });
            (Application.OpenForms["RemoteControl"] as RemoteControl).CallFunctionWithPayload("openchannel_1", "ssap://tv/openChannel", "Open channel request sent.", payload);
        }
    }
}
