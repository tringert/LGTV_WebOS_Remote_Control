using LgTvController.Properties;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LgTvController
{
    public partial class SavedDeviceListWindow : Form
    {
        public List<Device> DevList { get; set; }

        public SavedDeviceListWindow()
        {
            InitializeComponent();
            //DevList = new List<Device>();
        }

        private void DeviceListWindow_Load(object sender, EventArgs e)
        {
            SetGrid();
        }

        private void SetGrid()
        {
            dgvDevices.DataSource = DevList;

            dgvDevices.Columns.Add("FriendlyName", "Name");
            dgvDevices.Columns["FriendlyName"].Width = 100;
            dgvDevices.Columns["FriendlyName"].DisplayIndex = 0;

            dgvDevices.Columns.Add("Ip", "Ip");
            dgvDevices.Columns["Ip"].Width = 100;
            dgvDevices.Columns["Ip"].DisplayIndex = 1;

            dgvDevices.Columns.Add("Port", "Port");
            dgvDevices.Columns["Port"].Width = 50;
            dgvDevices.Columns["Port"].DisplayIndex = 2;

            dgvDevices.Columns.Add("ApiKey", "ApiKey");
            dgvDevices.Columns["ApiKey"].Width = 220;
            dgvDevices.Columns["ApiKey"].DisplayIndex = 3;

            dgvDevices.Columns.Add("MacAddress", "Mac address");
            dgvDevices.Columns["MacAddress"].Width = 97;
            dgvDevices.Columns["MacAddress"].DisplayIndex = 4;

            dgvDevices.Columns.Add("Server", "Server");
            dgvDevices.Columns["Server"].Width = 100;
            dgvDevices.Columns["Server"].DisplayIndex = 5;

            dgvDevices.Columns.Add("Uuid", "Uuid");
            dgvDevices.Columns["Uuid"].Width = 220;
            dgvDevices.Columns["Uuid"].DisplayIndex = 6;

            dgvDevices.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDevices.ReadOnly = true;
        }

        private void DgvDevices_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            SaveDevices();
        }

        private void SaveDevices()
        {
            Settings.Default.savedDeviceList = JsonConvert.SerializeObject(DevList);
            Settings.Default.Save();
        }

        private void TbName_Leave(object sender, EventArgs e)
        {
            if (DevList == null)
                return;

            bool notUnique = DevList.Any(x => x.FriendlyName == tbName.Text);

            if (notUnique)
            {
                tbName.BackColor = Color.Red;
                MessageBox.Show("The name must be unique!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                tbName.BackColor = Color.White;
            }
        }

        private void TbIP_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tbIP.Text))
            {
                tbIP.BackColor = Color.White;
                return;
            }

            if ((Application.OpenForms["RemoteControl"] as RemoteControl).ValidateIPv4(tbIP.Text))
            {
                tbIP.BackColor = Color.White;
            }
            else
            {
                tbIP.BackColor = Color.Red;
            }
        }

        private void TbPort_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tbPort.Text))
            {
                tbIP.BackColor = Color.White;
                return;
            }

            if (!UInt32.TryParse(tbPort.Text, out uint port) || port > 65535)
            {
                tbPort.BackColor = Color.Red;
            }
            else
            {
                tbPort.BackColor = Color.White;
            }
        }

        private void TbMac_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tbMac.Text))
            {
                tbMac.BackColor = Color.White;
                return;
            }

            if ((Application.OpenForms["RemoteControl"] as RemoteControl).ValidateMac(tbMac.Text))
            {
                tbMac.BackColor = Color.White;
            }
            else
            {
                tbMac.BackColor = Color.Red;
            }
        }

        private void TbUuid_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tbUuid.Text))
            {
                tbUuid.BackColor = Color.White;
                return;
            }

            if (!Guid.TryParse(tbUuid.Text, out Guid guid))
            {
                tbUuid.BackColor = Color.Red;
            }
            else
            {
                tbUuid.BackColor = Color.White;
            }
        }

        private void BtAdd_Click(object sender, EventArgs e)
        {
            bool name = default,
                 ip = default,
                 port = default,
                 apiKey = default,
                 error = default;

            foreach (TextBox tb in Controls.OfType<TextBox>())
            {
                if (tb.BackColor == Color.Red)
                    error = true;
            }

            name = !String.IsNullOrEmpty(tbName.Text) ? true : false;
            ip = !String.IsNullOrEmpty(tbIP.Text) ? true : false;
            port = !String.IsNullOrEmpty(tbPort.Text) ? true : false;
            apiKey = !String.IsNullOrEmpty(tbApiKey.Text) ? true : false;

            if (name && ip && port && apiKey && !error)
            {
                Device d = new Device()
                {
                    FriendlyName = tbName.Text,
                    Ip = tbIP.Text,
                    MacAddress = tbMac.Text,
                    Port = tbPort.Text,
                    Server = tbServer.Text,
                    ApiKey = tbApiKey.Text,
                    Uuid = tbUuid.Text == "" ? (Guid?)null : Guid.Parse(tbUuid.Text)
                };

                DevList.Add(d);
                RefreshGrid();
                SaveDevices();
                (Application.OpenForms["RemoteControl"] as RemoteControl).RefreshDeviceListComboBoxDelegate();
                (Application.OpenForms["RemoteControl"] as RemoteControl).SetActiveDevice(d.FriendlyName);

                foreach (TextBox tb in Controls.OfType<TextBox>())
                {
                    tb.Text = "";
                }

                if (dgvDevices.RowCount == 1)
                {
                    dgvDevices.Rows[0].Selected = true;
                }
                else if (dgvDevices.RowCount > 1)
                {
                    dgvDevices.Rows[dgvDevices.RowCount - 1].Selected = true;
                }
                
                dgvDevices.FirstDisplayedScrollingRowIndex = dgvDevices.SelectedRows[0].Index;

            }
            else
            {
                return;
            }
        }

        private void RefreshGrid()
        {
            dgvDevices.DataSource = null;
            SetGrid();
        }

        private void AddRowHeaderText()
        {
            foreach (DataGridViewRow row in dgvDevices.Rows)
            {
                row.HeaderCell.Value = String.Format("{0}", row.Index + 1);
            }
        }

        private void BtRemove_Click(object sender, EventArgs e)
        {
            if (DevList == null)
                return;

            if (dgvDevices.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a row first!", "Nothing selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string itemName = default;

            int index = 0;

            foreach (DataGridViewRow row in dgvDevices.SelectedRows)
            {
                itemName = row.Cells[0].Value.ToString();
                index = row.Index;
            }
            
            DialogResult confirmResult = MessageBox.Show("Are you sure you want to delete \"" + itemName + "\"?",
                                     "Confirm delete",
                                     MessageBoxButtons.YesNo,
                                     MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                DevList.RemoveAt(index);
                SaveDevices();
                (Application.OpenForms["RemoteControl"] as RemoteControl).RefreshDeviceListComboBoxDelegate();
                RefreshGrid();
                
                dgvDevices.ClearSelection();
            }
            else
            {
                return;
            }
        }

        private void DgvDevices_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            AddRowHeaderText();
        }
    }
}
