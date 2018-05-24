using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartTV
{
    public partial class DeviceListWindow : Form
    {
        public DeviceListWindow()
        {
            InitializeComponent();
        }

        private void DeviceListWindow_Load(object sender, EventArgs e)
        {
            DataGridViewColumn col1 = new DataGridViewTextBoxColumn();
            dgvDevices.AutoGenerateColumns = false;
            dgvDevices.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDevices.MultiSelect = false;
            dgvDevices.Columns["FriendlyName"].HeaderText = "Name";
            dgvDevices.Columns["FriendlyName"].Width = 80;
            dgvDevices.Columns["Ip"].HeaderText = "Ip";
            dgvDevices.Columns["Ip"].Width = 80;
            dgvDevices.Columns["Port"].HeaderText = "Port";
            dgvDevices.Columns["Port"].Width = 30;
            dgvDevices.Columns["Uuid"].HeaderText = "Uuid";
            dgvDevices.Columns["Uuid"].Width = 100;
            dgvDevices.Columns["ApiKey"].HeaderText = "Api Key";
            dgvDevices.Columns["ApiKey"].Width = 100;

        }
    }
}
