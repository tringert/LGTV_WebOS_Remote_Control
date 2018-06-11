using Newtonsoft.Json;
using System;
using System.Threading;
using System.Windows.Forms;

namespace LgTvController
{
    public partial class YoutubeWindow : Form
    {
        RemoteControl rc = (Application.OpenForms["RemoteControl"] as RemoteControl);
        public string sessionId = default;
        internal AppSession.AppInfoResponse youtubeInfo = new AppSession.AppInfoResponse();

        public YoutubeWindow()
        {
            InitializeComponent();
            OpenYoutubeApp();
        }

        private void OpenYoutubeApp()
        {
            CallFunctionRequestWithPayload request = new CallFunctionRequestWithPayload
            {
                Id = "youtube_open",
                Type = "request",
                Uri = "ssap://system.launcher/launch",
                Payload = new
                {
                    id = "youtube.leanback.v4",
                }
            };

            rc.CallFunctionWithPayload(request, "Youtube open request sent.");
        }

        private void BtOpenVideo_Click(object sender, EventArgs e)
        {
            if (rc.ws == null)
                return;

            if (String.IsNullOrEmpty(tbUrl.Text))
                return;

            string videoId = GetVideoIdFromUrl();

            if (String.IsNullOrEmpty(videoId))
            {
                MessageBox.Show("The inserted Url is not valid!", "URL format error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //CallFunctionRequestWithPayload request = new CallFunctionRequestWithPayload
            //{
            //    Id = "youtube_open",
            //    Type = "request",
            //    Uri = "ssap://system.launcher/launch",
            //    Payload = new
            //    {
            //        id = "youtube.leanback.v4",
            //        contentId = videoId
            //    }
            //};

            //(Application.OpenForms["RemoteControl"] as RemoteControl).CallFunctionWithPayload(request, "Youtube open request sent.");
            OpenYoutubeApp();
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

        private void PlayButton_Click(object sender, EventArgs e)
        {
            if (rc.ws == null)
                return;
            (Application.OpenForms["RemoteControl"] as RemoteControl).Play();
        }

        private void PauseButton_Click(object sender, EventArgs e)
        {
            if (rc.ws == null)
                return;
            (Application.OpenForms["RemoteControl"] as RemoteControl).Pause();
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            if (rc.ws == null)
                return;
            (Application.OpenForms["RemoteControl"] as RemoteControl).Stop();
        }

        private void RewindButton_Click(object sender, EventArgs e)
        {
            if (rc.ws == null)
                return;
            (Application.OpenForms["RemoteControl"] as RemoteControl).ReWind();
        }

        private void FastForwardButton_Click(object sender, EventArgs e)
        {
            if (rc.ws == null)
                return;
            (Application.OpenForms["RemoteControl"] as RemoteControl).FastForward();
        }

        public void ClearUrlField()
        {
            if (rc.ws == null)
                return;
            tbUrl.Invoke((Action)delegate { tbUrl.Clear(); });
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            if (rc.ws == null)
                return;

            (Application.OpenForms["RemoteControl"] as RemoteControl).CloseApp("youtube_close", "ssap://system.launcher/close", "youtube.leanback.v4", sessionId);
        }
    }
}
