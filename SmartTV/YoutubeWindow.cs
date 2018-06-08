using System;
using System.Windows.Forms;

namespace LgTvController
{
    public partial class YoutubeWindow : Form
    {
        public YoutubeWindow()
        {
            InitializeComponent();
        }

        private void BtPlay_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tbUrl.Text))
                return;

            string videoId = GetVideoIdFromUrl();

            if (String.IsNullOrEmpty(videoId))
            {
                MessageBox.Show("The inserted Url is not valid!", "URL format error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CallFunctionRequestWithPayload request = new CallFunctionRequestWithPayload
            {
                Id = "you_1",
                Type = "request",
                Uri = "ssap://system.launcher/launch",
                Payload = new
                {
                    id = "youtube.leanback.v4",
                    contentId = videoId
                }
            };

            (Application.OpenForms["RemoteControl"] as RemoteControl).CallFunctionWithPayload(request, "Youtube open request sent.");

        }

        private string GetVideoIdFromUrl()
        {
            string videoId = tbUrl.Text.Split(new string[] { "v=" }, StringSplitOptions.None)[1].ToString();

            if (videoId.Contains("&"))
            {
                videoId.Split('&')[0].ToString();
            }

            return videoId;
        }
    }
}
