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
        internal List<Devices> InputList { get; set; }

        public InputListWindow()
        {
            InitializeComponent();
        }

        private void InputListWindow_Load(object sender, EventArgs e)
        {
            bool allFalse = !InputList.Any(x => x.Connected == true);

            Devices liveTv = new Devices { Id = "Live_TV",
                                           Label = "LiveTV",
                                           AppId = "com.webos.app.livetv",
                                           Icon = "",
                                           Connected = true};
            InputList.Add(liveTv);

            var list = InputList.Select(l => new
            {
                l.Label,
                l.Id,
                l.Connected,
                l.Port,
                l.Favorite,
                l.Modified,
                l.AppId,
                l.Icon
            }).OrderByDescending(x => x.Connected).ThenBy(y => y.Port).ToList();

            dgvInputList.DataSource = list;
            dgvInputList.Columns["Label"].Width = 90;
            dgvInputList.Columns["Label"].DisplayIndex = 0;
            dgvInputList.Columns["Id"].Width = 70;
            dgvInputList.Columns["Id"].DisplayIndex = 1;
            dgvInputList.Columns["Connected"].Width = 70;
            dgvInputList.Columns["Connected"].DisplayIndex = 2;
            dgvInputList.Columns["Port"].Width = 30;
            dgvInputList.Columns["Port"].DisplayIndex = 3;
            dgvInputList.Columns["Favorite"].Width = 50;
            dgvInputList.Columns["Favorite"].DisplayIndex = 4;
            dgvInputList.Columns["Modified"].Width = 50;
            dgvInputList.Columns["Modified"].DisplayIndex = 5;

            dgvInputList.Columns["AppId"].Visible = false;
            dgvInputList.Columns["AppId"].DisplayIndex = 6;
            dgvInputList.Columns["Icon"].Visible = false;
            
            dgvInputList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvInputList.ClearSelection();
        }

        private void DgvInputList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ChangeInput(dgvInputList.Rows[e.RowIndex].Cells["AppId"].Value.ToString());
            Close();
        }

        private void ChangeInput(string AppId)
        {
            var payload = JsonConvert.SerializeObject(new { id = AppId });

            (Application.OpenForms["RemoteControl"] as RemoteControl).CallFunctionWithPayload("change_input", "ssap://system.launcher/launch", "LiveTv_input_change_request_sent.", payload);
        }

        private void dgvInputList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ChangeInput(dgvInputList.Rows[e.RowIndex].Cells["AppId"].Value.ToString());
        }
    }
}
