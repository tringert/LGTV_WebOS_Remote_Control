using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace LgTvController
{
    public partial class DisplayMessage : Form
    {
        public DisplayMessage()
        {
            InitializeComponent();
        }

        private void btSend_Click(object sender, EventArgs e)
        {
            string text = tbMessage.Text;
            string payload = "{\"message\": \"" + text + "\"}";
            (Application.OpenForms["RemoteControl"] as RemoteControl).CallFunctionWithPayload("toast_1", "ssap://system.notifications/createToast", "Toast message request sent.", payload);
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
