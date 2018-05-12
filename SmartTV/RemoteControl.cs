using System;
using System.Net;
using System.Globalization;
using System.Windows.Forms;
using WebSocketSharp;
using SmartTV.Properties;
using System.Linq;
using Newtonsoft.Json;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Threading;

namespace LgTvController
{
    public partial class RemoteControl : Form
    {
        WebSocket ws;
        ChannelListWindow chWindow;
        DisplayMessage msgWindow;
        ChannelListResponse clr;
        private string apiKey = Settings.Default.apiKey;
        private string mac = Settings.Default.macAddr;
        private string ip = Settings.Default.ip;
        ushort retry = 0;

        public RemoteControl()
        {
            InitializeComponent();

            if (!String.IsNullOrEmpty(ip))
            {
                tbIP.Text = ip;
            }

            if (!String.IsNullOrEmpty(apiKey))
            {
                tbApiKey.Text = apiKey;
            }

            Connect();
        }

        private void Connect()
        {
            string host = "ws://" + ip + ":3000/";
            ws = new WebSocket(host);
            
            string hs = "{\"type\":\"register\",\"id\":\"register_0\",\"payload\":{\"forcePairing\":false,\"pairingType\":\"PROMPT\",\"client-key\":\"" + apiKey + "\",\"manifest\":{\"manifestVersion\":1,\"appVersion\":\"1.1\",\"signed\":{\"created\":\"20140509\",\"appId\":\"com.lge.test\",\"vendorId\":\"com.lge\",\"localizedAppNames\":{\"\":\"LGRemoteApp\",\"hu-HU\":\"RemoteApp\",\"zxx-XX\":\"LGRemoteApp\"},\"localizedVendorNames\":{\"\":\"LGElectronics\"},\"permissions\":[\"TEST_SECURE\",\"CONTROL_INPUT_TEXT\",\"CONTROL_MOUSE_AND_KEYBOARD\",\"READ_INSTALLED_APPS\",\"READ_LGE_SDX\",\"READ_NOTIFICATIONS\",\"SEARCH\",\"WRITE_SETTINGS\",\"WRITE_NOTIFICATION_ALERT\",\"CONTROL_POWER\",\"READ_CURRENT_CHANNEL\",\"READ_RUNNING_APPS\",\"READ_UPDATE_INFO\",\"UPDATE_FROM_REMOTE_APP\",\"READ_LGE_TV_INPUT_EVENTS\",\"READ_TV_CURRENT_TIME\"],\"serial\":\"2f930e2d2cfe083771f68e4fe7bb07\"},\"permissions\":[\"LAUNCH\",\"LAUNCH_WEBAPP\",\"APP_TO_APP\",\"CLOSE\",\"TEST_OPEN\",\"TEST_PROTECTED\",\"CONTROL_AUDIO\",\"CONTROL_DISPLAY\",\"CONTROL_INPUT_JOYSTICK\",\"CONTROL_INPUT_MEDIA_RECORDING\",\"CONTROL_INPUT_MEDIA_PLAYBACK\",\"CONTROL_INPUT_TV\",\"CONTROL_POWER\",\"READ_APP_STATUS\",\"READ_CURRENT_CHANNEL\",\"READ_INPUT_DEVICE_LIST\",\"READ_NETWORK_STATE\",\"READ_RUNNING_APPS\",\"READ_TV_CHANNEL_LIST\",\"WRITE_NOTIFICATION_TOAST\",\"READ_POWER_STATE\",\"READ_COUNTRY_INFO\"],\"signatures\":[{\"signatureVersion\":1,\"signature\":\"eyJhbGdvcml0aG0iOiJSU0EtU0hBMjU2Iiwia2V5SWQiOiJ0ZXN0LXNpZ25pbmctY2VydCIsInNpZ25hdHVyZVZlcnNpb24iOjF9.hrVRgjCwXVvE2OOSpDZ58hR+59aFNwYDyjQgKk3auukd7pcegmE2CzPCa0bJ0ZsRAcKkCTJrWo5iDzNhMBWRyaMOv5zWSrthlf7G128qvIlpMT0YNY+n/FaOHE73uLrS/g7swl3/qH/BGFG2Hu4RlL48eb3lLKqTt2xKHdCs6Cd4RMfJPYnzgvI4BNrFUKsjkcu+WD4OO2A27Pq1n50cMchmcaXadJhGrOqH5YmHdOCj5NSHzJYrsW0HPlpuAx/ECMeIZYDh6RMqaFM2DXzdKX9NmmyqzJ3o/0lkk/N97gfVRLW5hA29yeAwaCViZNCP8iC9aO0q9fQojoa7NQnAtw==\"}]}}}";

            ws.OnMessage += Ws_OnMessage;
            ws.OnOpen += Ws_OnOpen;
            ws.OnClose += Ws_OnClose;
            ws.OnError += (sender, e) => Console.WriteLine("Error: " + e.Message);

            Logger log = ws.Log;
            log.Level = LogLevel.Debug;
            Console.WriteLine("\n" + log.Output);

            ws.EmitOnPing = true;
            ws.ConnectAsync();
        }

        private void Ws_OnMessage(object sender, MessageEventArgs e)
        {
            if (e.Data != String.Empty)
            {
                string msg = "<unhandled message>";
                bool getAudioStatus = default;

                if (e.Data.Contains("register_0"))
                {
                    RegisterResponse rr = JsonConvert.DeserializeObject<RegisterResponse>(e.Data);
                    msg = "Handshake successful." + Environment.NewLine + rr.ToString();
                    getAudioStatus = true;
                    GetCurrentChannel();
                }
                else if (e.Data.Contains("status_1"))
                {
                    AudioStatusResponse asr = JsonConvert.DeserializeObject<AudioStatusResponse>(e.Data);
                    msg = "Audio status received." + Environment.NewLine + asr.ToString();
                    Global._globalVolume = asr.Payload.volume;
                    string txt = Global._globalVolume + "/" + asr.Payload.volumeMax;
                    btVol.Invoke(new Action(() => { btVol.Text = txt; }));

                    if (asr.Payload.mute)
                    {
                        btnMute.Invoke(new Action(() => { btnMute.Image = Resources.Speaker_off; }));
                        Global._isMuted = true;
                    }
                    else
                    {
                        btnMute.Invoke(new Action(() => { btnMute.Image = Resources.Speaker_on; }));
                        Global._isMuted = false;
                    }
                }
                else if (e.Data.Contains("volumeup_1"))
                {
                    CallFunctionResponse cfr = JsonConvert.DeserializeObject<CallFunctionResponse>(e.Data);

                    if (cfr.Payload.returnValue)
                    {
                        getAudioStatus = true;
                        msg = "Volume up acknowledged.";
                    }
                    else
                    {
                        msg = "Volume up request rejected.";
                    }
                }
                else if (e.Data.Contains("volumedown_1"))
                {
                    CallFunctionResponse cfr = JsonConvert.DeserializeObject<CallFunctionResponse>(e.Data);
                    if (cfr.Payload.returnValue)
                    {
                        getAudioStatus = true;
                        msg = "Volume down acknowledged.";
                    }
                    else
                    {
                        msg = "Volume down request rejected.";
                    }
                }
                else if (e.Data.Contains("toggle_mute"))
                {
                    CallFunctionResponse cfr = JsonConvert.DeserializeObject<CallFunctionResponse>(e.Data);
                    if (cfr.Payload.returnValue)
                    {
                        getAudioStatus = true;
                        msg = "Toggle mute acknowledged.";
                    }
                    else
                    {
                        msg = "Toggle mute request rejected.";
                    }
                }
                else if (e.Data.Contains("channelinfo_1"))
                {
                    ChannelInfo ci = JsonConvert.DeserializeObject<ChannelInfo>(e.Data);
                    string chan = String.Format("({0}) {1}", ci.Payload.ChannelNumber, ci.Payload.ChannelName);
                    btVol.Invoke(new Action(() => { btChan.Text = chan; }));
                    msg = "Current channel info arrived.";
                }
                else if (e.Data.Contains("channelup_1") || e.Data.Contains("channeldown_1"))
                {
                    CallFunctionResponse cfr = JsonConvert.DeserializeObject<CallFunctionResponse>(e.Data);
                    if (cfr.Payload.returnValue)
                    {
                        GetCurrentChannel();
                        msg = cfr.Id == "channelup_1" ? "Channel up success." : "Channel down success.";
                    }
                }
                else if (e.Data.Contains("getchannels_1") || e.Data.Contains("getchannels_2"))
                {
                    ChannelListResponse clr = JsonConvert.DeserializeObject<ChannelListResponse>(e.Data);
                    chWindow = new ChannelListWindow();
                    chWindow.channels = clr.Payload.ChannelList;
                    chWindow.ShowDialog();
                }
                else if (e.Data.Contains("toast_1"))
                {
                    Console.WriteLine(e.Data);
                }
                else
                {
                    msg = e.Data;
                }

                DisplayMessage(msg);

                if (getAudioStatus) GetAudioStatus(); 
            }
        }

        private void Ws_OnClose(object sender, CloseEventArgs e)
        {
            string message = String.Format("{0}" + Environment.NewLine +
                                           "{1} Connection closed. | Reason: {2} | WasClean: {3} | Close status code: {4}",
                                           new string('-', 60), DateTime.Now.ToString("HH:mm:ss.fff"), String.IsNullOrEmpty(e.Reason) ? "-": e.Reason, e.WasClean,
                                           e.Code);
            DisplayMessage(message);
        }

        private void Reconnect()
        {
            if (retry < 5)
            {
                retry++;
                Thread.Sleep(5000);
                DisplayMessage("Reconnecting...");
                ws.ConnectAsync();
            }
            else
            {
                DisplayMessage("The reconnecting has failed.");
            }
        }

        private void Ws_OnOpen(object sender, EventArgs e)
        {
            retry = 0;
            DisplayMessage("Connection established.");
            SendHandshake();
        }

        private void SendHandshake()
        {
            string hs = "{\"type\":\"register\",\"id\":\"register_0\",\"payload\":{\"forcePairing\":false,\"pairingType\":\"PROMPT\",\"client-key\":\"" + apiKey + "\",\"manifest\":{\"manifestVersion\":1,\"appVersion\":\"1.1\",\"signed\":{\"created\":\"20140509\",\"appId\":\"com.lge.test\",\"vendorId\":\"com.lge\",\"localizedAppNames\":{\"\":\"LGRemoteApp\",\"en-EN\":\"RemoteApp\",\"zxx-XX\":\"LGRemoteApp\"},\"localizedVendorNames\":{\"\":\"LGElectronics\"},\"permissions\":[\"TEST_SECURE\",\"CONTROL_INPUT_TEXT\",\"CONTROL_MOUSE_AND_KEYBOARD\",\"READ_INSTALLED_APPS\",\"READ_LGE_SDX\",\"READ_NOTIFICATIONS\",\"SEARCH\",\"WRITE_SETTINGS\",\"WRITE_NOTIFICATION_ALERT\",\"CONTROL_POWER\",\"READ_CURRENT_CHANNEL\",\"READ_RUNNING_APPS\",\"READ_UPDATE_INFO\",\"UPDATE_FROM_REMOTE_APP\",\"READ_LGE_TV_INPUT_EVENTS\",\"READ_TV_CURRENT_TIME\"],\"serial\":\"2f930e2d2cfe083771f68e4fe7bb07\"},\"permissions\":[\"LAUNCH\",\"LAUNCH_WEBAPP\",\"APP_TO_APP\",\"CLOSE\",\"TEST_OPEN\",\"TEST_PROTECTED\",\"CONTROL_AUDIO\",\"CONTROL_DISPLAY\",\"CONTROL_INPUT_JOYSTICK\",\"CONTROL_INPUT_MEDIA_RECORDING\",\"CONTROL_INPUT_MEDIA_PLAYBACK\",\"CONTROL_INPUT_TV\",\"CONTROL_POWER\",\"READ_APP_STATUS\",\"READ_CURRENT_CHANNEL\",\"READ_INPUT_DEVICE_LIST\",\"READ_NETWORK_STATE\",\"READ_RUNNING_APPS\",\"READ_TV_CHANNEL_LIST\",\"WRITE_NOTIFICATION_TOAST\",\"READ_POWER_STATE\",\"READ_COUNTRY_INFO\"],\"signatures\":[{\"signatureVersion\":1,\"signature\":\"eyJhbGdvcml0aG0iOiJSU0EtU0hBMjU2Iiwia2V5SWQiOiJ0ZXN0LXNpZ25pbmctY2VydCIsInNpZ25hdHVyZVZlcnNpb24iOjF9.hrVRgjCwXVvE2OOSpDZ58hR+59aFNwYDyjQgKk3auukd7pcegmE2CzPCa0bJ0ZsRAcKkCTJrWo5iDzNhMBWRyaMOv5zWSrthlf7G128qvIlpMT0YNY+n/FaOHE73uLrS/g7swl3/qH/BGFG2Hu4RlL48eb3lLKqTt2xKHdCs6Cd4RMfJPYnzgvI4BNrFUKsjkcu+WD4OO2A27Pq1n50cMchmcaXadJhGrOqH5YmHdOCj5NSHzJYrsW0HPlpuAx/ECMeIZYDh6RMqaFM2DXzdKX9NmmyqzJ3o/0lkk/N97gfVRLW5hA29yeAwaCViZNCP8iC9aO0q9fQojoa7NQnAtw==\"}]}}}";
            string message = default;
            try
            {
                ws.Send(hs);
                message = "Handshake request sent.";
            }
            catch (Exception e)
            {
                message = String.Format("{0}" + Environment.NewLine +
                                        "{1} Exception occured: {2}", new string('-', 60), DateTime.Now.ToString("HH:mm:ss.fff"), e.Data);
                return;
            }
            finally
            {
                DisplayMessage(message);
            }
            
        }

        private void DisplayMessage(string message)
        {
            string msg = String.Format(new string('-', 60) + Environment.NewLine + DateTime.Now.ToString("HH:mm:ss.fff") + " ");
            msg += message + Environment.NewLine;
            txtResponse.Invoke(new Action(() => { txtResponse.AppendText(msg); }));
        }

        private void btnTurnOff_Click(object sender, EventArgs e)
        {
            if (!CheckIsAlive())
            {
                ConnectionLostDialog();
                return;
            }

            string turnOff = "{ \"id\":\"1\",\"type\":\"request\",\"uri\":\"ssap://system/turnOff\"}";
            ws.Send(turnOff);
            DisplayMessage("Turn off signal sent.");
        }

        private void ConnectionLostDialog()
        {
            MessageBox.Show("The connection is lost." + Environment.NewLine + "Please connect first!",
                            "No connection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return;
        }

        private bool CheckIsAlive()
        {
            if (ws == null) return false;
            return ws.IsAlive;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            Connect();
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            if (!CheckIsAlive())
            {
                ConnectionLostDialog();
                return;
            }

            Disconnect();
        }

        private void Disconnect()
        {
            if (ws.IsAlive)
            {
                ws.Close();
                ws = null;
            }
        }

        private void GetAudioStatus()
        {
            AudioStatusRequest asrq = new AudioStatusRequest { Id = "status_1", Type = "request", Uri = "ssap://audio/getStatus"};

            ws.Send(JsonConvert.SerializeObject(asrq));
            DisplayMessage("GetAudioStatus request sent.");
        }

        private void btnMute_Click(object sender, EventArgs e)
        {
            if (!CheckIsAlive())
            {
                ConnectionLostDialog();
                return;
            }
            bool mute = !Global._isMuted;
            string message = "{\"id\":\"toggle_mute\",\"type\":\"request\",\"uri\":\"ssap://audio/setMute\",\"payload\":{\"mute\":" + mute.ToString().ToLower() + "}}";
            ws.Send(message);
            DisplayMessage("Toggle mute sent.");
        }

        private void btnTurnOn_Click(object sender, EventArgs e)
        {
            WakeUp(mac);
        }

        private void WakeUp(string MAC_ADDRESS)
        {
            WOLClass client = new WOLClass();

            // Creating broadcast address from IP
            string[] ipArray = ip.Split('.');
            ipArray[3] = "255";
            string broadcastIp = String.Join(".", ipArray);

            client.Connect(IPAddress.Parse(broadcastIp), 0x7);

            // Buffer to be send
            byte[] bytes = new byte[102];

            int counter = 0;
            for (int y = 0; y < 6; y++)
            {
                // First 6 bytes should be 0xFF
                bytes[counter++] = 0xFF;
            }

            // Repeat MAC address 16 times
            for (int y = 0; y < 16; y++)
            {
                int i = 0;
                for (int z = 0; z < 6; z++)
                {
                    bytes[counter++] =
                        byte.Parse(MAC_ADDRESS.Substring(i, 2),
                        NumberStyles.HexNumber);
                    i += 2;
                }
            }

            // Send magic packet
            client.Send(bytes, bytes.Length);
            DisplayMessage("Magic packet sent.");
        }

        private void RemoteControl_FormClosed(object sender, FormClosedEventArgs e)
        {
            Settings.Default.ip = tbIP.Text;
            Settings.Default.macAddr = tbMac.Text;
            Settings.Default.apiKey = tbApiKey.Text;
            Settings.Default.Save();
        }

        public bool ValidateIPv4(string ipString)
        {
            if (String.IsNullOrWhiteSpace(ipString))
            {
                return false;
            }

            string[] splitValues = ipString.Split('.');
            if (splitValues.Length != 4)
            {
                return false;
            }

            byte tempForParsing;

            return splitValues.All(r => byte.TryParse(r, out tempForParsing));
        }

        private void tbIP_Leave(object sender, EventArgs e)
        {
            if (!ValidateIPv4(tbIP.Text))
            {
                tbIP.ForeColor = Color.Red;
            }
            else
            {
                tbIP.ForeColor = Color.Black;
                Settings.Default.ip = tbIP.Text;
                Settings.Default.Save();
            }
        }

        private void tbApiKey_Leave(object sender, EventArgs e)
        {
            Settings.Default.apiKey = tbApiKey.Text;
            Settings.Default.Save();
        }

        private void tbMac_Leave(object sender, EventArgs e)
        {
            if (!ValidateMac(tbMac.Text))
            {
                tbMac.ForeColor = Color.Red;
            }
            else
            {
                tbMac.ForeColor = Color.Black;
                Settings.Default.macAddr = tbMac.Text;
                Settings.Default.Save();
            }
        }

        private bool ValidateMac(string mac)
        {
            var regex = "[0-9A-F]{12}";
            var match = Regex.Match(mac, regex, RegexOptions.IgnoreCase);
            return match.Success;
        }

        private void btVol_Click(object sender, EventArgs e)
        {
            GetAudioStatus();
        }

        private void btVolPlus_Click(object sender, EventArgs e)
        {
            CallFunction("volumeup_1", "ssap://audio/volumeUp", "Volume up request sent.");
        }

        private void CallFunction(string id, string ep, string message)
        {
            CallFunctionRequest cfr = new CallFunctionRequest { Id = id, Type = "request", Uri = ep };
            ws.Send(JsonConvert.SerializeObject(cfr));
            DisplayMessage(message);
        }

        internal void CallFunctionWithPayload(string id, string ep, string message, string payload)
        {
            CallFunctionRequestWithPayload cfr = new CallFunctionRequestWithPayload { Id = id, Type = "request", Uri = ep, Payload = payload };
            ws.Send(JsonConvert.SerializeObject(cfr));
            DisplayMessage(message);
        }

        private void btVolMinus_Click(object sender, EventArgs e)
        {
            CallFunction("volumedown_1", "ssap://audio/volumeDown", "Volume down request sent.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtResponse.Invoke(new Action(() => { txtResponse.Text = ""; }));
        }

        private void btChan_Click(object sender, EventArgs e)
        {
            GetCurrentChannel();
        }

        private void GetCurrentChannel()
        {
            CallFunction("channelinfo_1", "ssap://tv/getCurrentChannel", "Channel info request sent.");
        }

        private void chanPlus_Click(object sender, EventArgs e)
        {
            CallFunction("channelup_1", "ssap://tv/channelUp", "Channel up request sent.");
        }

        private void chanMinus_Click(object sender, EventArgs e)
        {
            CallFunction("channeldown_1", "ssap://tv/channelDown", "Channel down request sent.");
        }

        private void btChList_Click(object sender, EventArgs e)
        {
            CallFunction("getchannels_1", "ssap://tv/getChannelList", "Channel list request sent.");
            
            // TODO: implement
            //CallFunction("getchannels_2", "ssap://tv/getChannelProgramInfo", "Channel list request sent.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            msgWindow = new DisplayMessage();
            msgWindow.Show();
            //CallFunction("toast_1", "ssap://system.notifications/createToast", "Channel list request sent.", "{\"message\": \"MSG\"}");
        }
    }
}
