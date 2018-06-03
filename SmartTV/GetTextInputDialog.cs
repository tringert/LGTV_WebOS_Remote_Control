using System.Windows.Forms;

namespace LgTvController
{
    public static class GetTextInputDialog
    {
        private static TextBox textBox;
        private static Form inputWindow;

        public static string ShowDialog(string question, string caption)
        {
            inputWindow = new Form()
            {
                Width = 265,
                Height = 145,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterParent,
                ControlBox = false,
                Icon = null
            };

            Label lbText = new Label() { Left = 20,
                                         Top = 20,
                                         Height = 23,
                                         Width = 200,
                                         AutoSize = false,
                                         Text = question };

            textBox = new TextBox() { Left = 20,
                                      Top = 51,
                                      Width = 210,
                                      Height = 23,
                                      MaxLength = 15,
                                      TabStop = true,
                                      TabIndex = 0 };

            Button saveBtn = new Button() { Text = "Ok",
                                                 Left = 155,
                                                 Height = 23,
                                                 Width = 75,
                                                 Top = 94,
                                                 DialogResult = DialogResult.OK,
                                                 TabStop = true,
                                                 TabIndex = 1 };

            //confirmation.Click += (sender, e) => { inputWindow.Close(); };
            saveBtn.Click += Confirmation_Click;
            inputWindow.Controls.Add(textBox);
            inputWindow.Controls.Add(saveBtn);
            inputWindow.Controls.Add(lbText);
            inputWindow.AcceptButton = saveBtn;

            return inputWindow.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }

        private static void Confirmation_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox.Text))
            {
                
            }
            else
            {
                inputWindow.Close();
            }
        }
    }
}
