using System;
using System.Windows.Forms;
using Newtonsoft.Json;

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
            string text = tbMessage.Text.Replace("\r\n", "<br>").Replace("\"", "\\\"");
            var payload = new { message = text };
            (Application.OpenForms["RemoteControl"] as RemoteControl).CallFunctionWithPayload("toast_1", "ssap://system.notifications/createToast", "Toast message request sent.", payload);
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
