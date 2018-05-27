using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LgTvController
{
    public partial class SavedDeviceListWindow : Form
    {
        internal List<Device> devList;

        public SavedDeviceListWindow()
        {
            InitializeComponent();
        }

        private void DeviceListWindow_Load(object sender, EventArgs e)
        {
            var columns = from d in devList
                          orderby d.FriendlyName
                          select new
                          {
                              FriendlyName = d.FriendlyName,
                              Ip = d.Ip,
                              Port = d.Port,
                              Uuid = d.Uuid,
                              ApiKey = d.ApiKey,
                              MacAddress = d.MacAddress
                          };

            dgvDevices.DataSource = columns.ToList();
            dgvDevices.Columns["FriendlyName"].Width = 80;
            dgvDevices.Columns["Ip"].Width = 80;
            dgvDevices.Columns["Port"].Width = 40;
            dgvDevices.Columns["Uuid"].Width = 220;
            dgvDevices.Columns["ApiKey"].Width = 220;
            dgvDevices.Columns["MacAddress"].Width = 80;

            //dgvDevices.DataSource = result;
            //DataGridViewColumn col1 = new DataGridViewTextBoxColumn();
            //dgvDevices.AutoGenerateColumns = false;
            //dgvDevices.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //dgvDevices.MultiSelect = false;
            //dgvDevices.Columns["FriendlyName"].HeaderText = "Name";
            //dgvDevices.Columns["FriendlyName"].Width = 80;
            //dgvDevices.Columns["Ip"].HeaderText = "Ip";
            //dgvDevices.Columns["Ip"].Width = 80;
            //dgvDevices.Columns["Port"].HeaderText = "Port";
            //dgvDevices.Columns["Port"].Width = 30;
            //dgvDevices.Columns["Uuid"].HeaderText = "Uuid";
            //dgvDevices.Columns["Uuid"].Width = 100;
            //dgvDevices.Columns["ApiKey"].HeaderText = "Api Key";
            //dgvDevices.Columns["ApiKey"].Width = 100;

        }
    }
}
