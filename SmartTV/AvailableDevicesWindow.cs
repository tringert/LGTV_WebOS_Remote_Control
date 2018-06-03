using System;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;

namespace LgTvController
{
    public partial class AvailableDevicesWindow : Form
    {
        private BindingSource bindingSource;
        private System.Threading.Timer timer;

        public AvailableDevicesWindow()
        {
            InitializeComponent();
            (Application.OpenForms["RemoteControl"] as RemoteControl).availableDeviceList.PropertyChanged += AvailableDevicesWindow_PropertyChanged;

            var animationThread = new Thread(new ParameterizedThreadStart(param => { SearchingAnimation(); }));
            animationThread.SetApartmentState(ApartmentState.STA);
            animationThread.Start();
        }

        private void SearchingAnimation()
        {
            TimerCallback cb = new TimerCallback((state) =>
            {
                try
                {
                    if (lbAnimatedDots.IsHandleCreated)
                    {
                        lbAnimatedDots.Invoke((Action)delegate
                        {
                            SetLabelText();
                        });
                    }
                }
                catch (Exception)
                {
                    return;
                }
            });

            timer = new System.Threading.Timer(cb, null, 0, 1000);
        }

        private void SetLabelText()
        {
            if (lbAnimatedDots.Text.Length == 3)
            {
                lbAnimatedDots.Text = "";
            }
            else
            {
                lbAnimatedDots.Text += ".";
            }

            lbAnimatedDots.Refresh();
        }

        private void AvailableDevicesWindow_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            dgvAvailableDevices.Invoke((Action)delegate
            {
                SetGrid();
            });
        }

        private void AvailableDevicesWindow_Load(object sender, EventArgs e)
        {
            SetGrid();
        }

        private void SetGrid()
        {
            bindingSource = new BindingSource();
            dgvAvailableDevices.DataSource = null;
            bindingSource.DataSource = (Application.OpenForms["RemoteControl"] as RemoteControl).availableDeviceList.availableDevList;
            dgvAvailableDevices.DataSource = bindingSource;

            dgvAvailableDevices.Columns["Server"].HeaderText = "Name";
            dgvAvailableDevices.Columns["Server"].Width = 140;
            dgvAvailableDevices.Columns["Server"].DisplayIndex = 0;
            dgvAvailableDevices.Columns["Ip"].Width = 100;
            dgvAvailableDevices.Columns["Ip"].DisplayIndex = 1;
            dgvAvailableDevices.Columns["ServicePort"].Width = 80;
            dgvAvailableDevices.Columns["ServicePort"].DisplayIndex = 2;
            dgvAvailableDevices.Columns["Mac"].Width = 97;
            dgvAvailableDevices.Columns["Mac"].DisplayIndex = 3;
            dgvAvailableDevices.Columns["Uuid"].Width = 220;
            dgvAvailableDevices.Columns["Uuid"].DisplayIndex = 4;
            dgvAvailableDevices.Columns["Usn"].Width = 450;
            dgvAvailableDevices.Columns["Usn"].DisplayIndex = 5;
            dgvAvailableDevices.Columns["Port"].Visible = false;

            dgvAvailableDevices.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAvailableDevices.RowHeadersVisible = false;
            dgvAvailableDevices.AllowUserToAddRows = false;
            dgvAvailableDevices.AllowUserToDeleteRows = false;
        }

        private void AvailableDevicesWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Dispose();
        }

        private void DgvAvailableDevices_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Guid uuid = (Guid)dgvAvailableDevices.Rows[e.RowIndex].Cells["Uuid"].Value;
            string mac = dgvAvailableDevices.Rows[e.RowIndex].Cells["Mac"].Value.ToString();
            List<Device> savedDeviceList = (Application.OpenForms["RemoteControl"] as RemoteControl).deviceListFromConfig;
            var isAlreadySaved = savedDeviceList.Exists(x => x.Uuid == uuid || x.MacAddress == mac);

            if (isAlreadySaved)
            {
                if (ConfirmRePair())
                {
                    (Application.OpenForms["RemoteControl"] as RemoteControl).deviceListFromConfig.RemoveAll(x => x.Uuid == uuid || x.MacAddress == mac);
                }
                else
                {
                    return;
                }
            }

            string name = default;

            while (String.IsNullOrEmpty(name))
            {
                name = GetTextInputDialog.ShowDialog("Add a name before pairing:", "");
            }

            (Application.OpenForms["RemoteControl"] as RemoteControl).StartPairNewDevice(uuid, name);
            Close();
        }

        private bool ConfirmRePair()
        {
            DialogResult confirmResult = MessageBox.Show("You already paired this device.\n" +
                            "If you choose Yes, the saved pairing will be deleted and new pair will be requested.",
                            "Confirm re-pair",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning);

            return confirmResult == DialogResult.Yes ? true : false;
        }
    }
}
