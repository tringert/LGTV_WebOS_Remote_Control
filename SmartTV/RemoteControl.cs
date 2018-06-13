using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using WebSocketSharp;
using LgTvController.Properties;
using Newtonsoft.Json;

namespace LgTvController
{
    public partial class RemoteControl : Form
    {
        public WebSocket ws;
        private ChannelListResponse clr;
        internal ChannelInfo ci;
        private static ChannelListWindow chWindow;
        private static InputListWindow inputWindow;
        internal List<Device> deviceListFromConfig;
        public AvailableDeviceList availableDeviceList;
        private static DisplayMessage msgWindow;
        private static YoutubeWindow youtubeWindow;
        private static SavedDeviceListWindow deviceListWindow;
        private static AvailableDevicesWindow adWindow;
        private static Device selectedDevice;
        private AppSession appSession;
        private static System.Threading.Timer timer;
        private string apiKey;
        private string mac;
        private string ip;
        ushort retry = 0;

        public RemoteControl()
        {
            InitializeComponent();

            toolStripMenuItemShowLog.Checked = Settings.Default.showLog;
            SetWindowSize();

            // Load the saved devices from App.Config
            deviceListFromConfig = new List<Device>();

            if (!String.IsNullOrEmpty(Settings.Default.savedDeviceList))
            {
                deviceListFromConfig = LoadSavedDeviceList();
            }
            
            availableDeviceList = new AvailableDeviceList();
            appSession = new AppSession();

            cbSavedDevices.DataSource = deviceListFromConfig;
            cbSavedDevices.DisplayMember = "FriendlyName";

            // Start the device discovery
            TimerCallback cb = new TimerCallback((state) =>
            {
                SSDP.FindDevices();
            });
            timer = new System.Threading.Timer(cb, null, 0, 5000);

            if (cbSavedDevices.SelectedItem != null)
            {
                Connect();
            }
        }

        private void SetWindowSize()
        {
            if (Settings.Default.showLog == true)
            {
                Size = new System.Drawing.Size(900, 500);
                lbLog.Visible = true;
                btTrash.Visible = true;
                tbLog.Visible = true;
            }
            else
            {
                Size = new System.Drawing.Size(354, 500);
                lbLog.Visible = false;
                btTrash.Visible = false;
                tbLog.Visible = false;
            }
        }

        public void CloseApp(string id, string uri, string appId, string sessionId)
        {
            CallFunctionRequestWithPayload request = new CallFunctionRequestWithPayload
            {
                Id = id,
                Type = "request",
                Uri = uri,
                Payload = new
                {
                    appId,
                    sessionId
                }
            };

            // Debug
            Console.WriteLine("App close request: " + JsonConvert.SerializeObject(request));
            CallFunctionWithPayload(request, "App close request sent.");
        }

        private List<Device> LoadSavedDeviceList()
        {
            return JsonConvert.DeserializeObject<List<Device>>(Settings.Default.savedDeviceList);
        }

        private void Connect()
        {
            selectedDevice = ((Device)cbSavedDevices.SelectedItem);
            ip = selectedDevice.Ip;
            apiKey = selectedDevice.ApiKey;
            mac = selectedDevice.MacAddress;
            string host = "ws://" + ip + ":3000/";
            ws = new WebSocket(host);
            
            // WebSocket event subscriptions
            ws.OnMessage += Ws_OnMessage;
            ws.OnOpen += Ws_OnOpen;
            ws.OnClose += Ws_OnClose;
            ws.OnError += (sender, e) => Console.WriteLine("Error: " + e.Message);

            // Keep the connection alive (send back the pong)
            ws.EmitOnPing = true;

            // Connect to the websocket
            ws.ConnectAsync();
        }

        // Handling incoming messages
        private void Ws_OnMessage(object sender, MessageEventArgs e)
        {
            if (e.Data != String.Empty)
            {
                string msg = "<empty message>";

                // Response for handshake
                if (e.Data.Contains("register_0"))
                {
                    RegisterResponse rr = JsonConvert.DeserializeObject<RegisterResponse>(e.Data);
                    msg = "Handshake successful." + Environment.NewLine + rr.ToString();

                    SubscribeWebsocketEvents();

                }
                else if (e.Data.Contains("newPair"))
                {
                    CallFunctionResponse cfr = JsonConvert.DeserializeObject<CallFunctionResponse>(e.Data);

                    if (cfr.Payload.ReturnValue && cfr.Type == "response")
                    {
                        msg = "Pairing request acknowledged.";
                    }
                    else if (!cfr.Payload.ReturnValue && cfr.Type == "response")
                    {
                        msg = "Pairing request unsuccessful.";
                    }
                    else if (cfr.Type == "registered")
                    {
                        RegisterResponse rr = JsonConvert.DeserializeObject<RegisterResponse>(e.Data);

                        if (String.IsNullOrEmpty(selectedDevice.ApiKey))
                        {
                            selectedDevice.ApiKey = rr.Payload.client_key;
                        }
                        
                        SaveDeviceList();
                        SubscribeWebsocketEvents();
                    }
                }
                // Response for audio status request
                else if (e.Data.Contains("volume_sub"))
                {
                    AudioStatusResponse asr = JsonConvert.DeserializeObject<AudioStatusResponse>(e.Data);
                    msg = "Audio status received." + Environment.NewLine + asr.ToString();

                    // Displaying the volume level
                    string txt = asr.Payload.Volume + "/" + asr.Payload.VolumeMax;

                    btVol.Invoke(new Action(() => { btVol.Text = txt; }));

                    // Setting the speaker icon on mute button
                    if (asr.Payload.Mute)
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
                // Response for volume up request
                else if (e.Data.Contains("volumeup_1"))
                {
                    CallFunctionResponse cfr = JsonConvert.DeserializeObject<CallFunctionResponse>(e.Data);

                    if (cfr.Payload.ReturnValue)
                    {
                        msg = "Volume up acknowledged.";
                    }
                    else
                    {
                        msg = "Volume up request rejected.";
                    }
                }
                // Response for volume down request
                else if (e.Data.Contains("volumedown_1"))
                {
                    CallFunctionResponse cfr = JsonConvert.DeserializeObject<CallFunctionResponse>(e.Data);
                    if (cfr.Payload.ReturnValue)
                    {
                        msg = "Volume down acknowledged.";
                    }
                    else
                    {
                        msg = "Volume down request rejected.";
                    }
                }
                // Response for toggle mute request
                else if (e.Data.Contains("toggle_mute"))
                {
                    CallFunctionResponse cfr = JsonConvert.DeserializeObject<CallFunctionResponse>(e.Data);
                    if (cfr.Payload.ReturnValue)
                    {
                        msg = "Toggle mute acknowledged.";
                    }
                    else
                    {
                        msg = "Toggle mute request rejected.";
                    }
                }
                // Response for current channel info request
                else if (e.Data.Contains("channel_sub"))
                {
                    ci = JsonConvert.DeserializeObject<ChannelInfo>(e.Data);

                    // Displaying the current channel
                    string chan = String.Format("({0}) {1}", ci.Payload.ChannelNumber, ci.Payload.ChannelName);
                    btVol.Invoke(new Action(() => { btChan.Text = chan; }));
                    msg = "Current channel info arrived.";
                }
                // Response for channel up/down request
                else if (e.Data.Contains("channelup_1") || e.Data.Contains("channeldown_1"))
                {
                    CallFunctionResponse cfr = JsonConvert.DeserializeObject<CallFunctionResponse>(e.Data);
                    if (cfr.Payload.ReturnValue)
                    {
                        GetCurrentChannel();
                        msg = cfr.Id == "channelup_1" ? "Channel up success." : "Channel down success.";
                    }
                }
                // Response for get channels list request
                else if (e.Data.Contains("getchannels_1"))
                {
                    clr = JsonConvert.DeserializeObject<ChannelListResponse>(e.Data);

                    if (clr.Payload.ReturnValue == true)
                    {
                        // Opening the channel list window
                        chWindow = new ChannelListWindow
                        {
                            channels = clr.Payload.ChannelList
                        };
                        chWindow.ci = ci;
                        chWindow.ShowDialog();
                        msg = "Channel list request succeeded.";
                    }
                    else
                    {
                        msg = "Channel list request unsuccessful.";
                    }

                }
                else if (e.Data.Contains("get_inputlist"))
                {
                    if (e.Data.Contains("\"returnValue\":true"))
                    {
                        Input response = new Input();
                        response = JsonConvert.DeserializeObject<Input>(e.Data);

                        inputWindow = new InputListWindow
                        {
                            InputList = response.Payload.Devices
                        };
                        inputWindow.ShowDialog();
                    }
                }
                // Response for displaying toast message on the screen request
                else if (e.Data.Contains("toast_1"))
                {
                    CallFunctionResponse cfr = JsonConvert.DeserializeObject<CallFunctionResponse>(e.Data);
                    if (cfr.Payload.ReturnValue)
                    {
                        msg = "Toast message request succeeded.";
                    }
                    else
                    {
                        msg = "Toast message request rejected.";
                    }
                }
                else if (e.Data.Contains("openchannel_1"))
                {
                    // Missing response from WebOs!!!
                    //CallFunctionResponse cfr = JsonConvert.DeserializeObject<CallFunctionResponse>(e.Data);
                    //if (cfr.Payload.returnValue)
                    //{
                    //    msg = "Open channel request succeeded.";
                    //}
                    //else
                    //{
                    //    msg = "Open channel request rejected.";
                    //}
                }
                else if (e.Data.Contains("youtube_open"))
                {
                    AppSession.LaunchAppResponse yr = JsonConvert.DeserializeObject<AppSession.LaunchAppResponse>(e.Data);
                    if (yr.Payload.ReturnValue)
                    {
                        msg = "Youtube open video request succeeded.";
                        (Application.OpenForms["YoutubeWindow"] as YoutubeWindow).ClearUrlField();
                        (Application.OpenForms["YoutubeWindow"] as YoutubeWindow).sessionId = yr.Payload.SessionId;
                        appSession.SessionId = yr.Payload.SessionId;
                    }
                    else
                    {
                        msg = "Youtube open video request rejected.";
                    }
                }
                else if (e.Data.Contains("youtube_close"))
                {
                    CallFunctionResponse cfr = JsonConvert.DeserializeObject<CallFunctionResponse>(e.Data);

                    if (cfr.Payload.ReturnValue == true)
                    {
                        msg = "Youtube app close request succeeded.";
                        youtubeWindow.Invoke(new Action(() => { youtubeWindow.Close(); }));
                        youtubeWindow = null;
                    }
                    else
                    {
                        msg = "Youtube app close request rejected." + Environment.NewLine + e.Data;
                    }
                }
                else if (e.Data.Contains("ForeGroundAppInfo"))
                {
                    AppSession.AppInfoResponse yr = JsonConvert.DeserializeObject<AppSession.AppInfoResponse>(e.Data);
                    if (yr.Payload.ReturnValue)
                    {
                        msg = "Foreground app info request succeeded.";
                        switch (yr.Payload.AppId)
                        {
                            case "youtube.leanback.v4":
                                (Application.OpenForms["YoutubeWindow"] as YoutubeWindow).youtubeInfo = yr;
                                break;
                            case "com.webos.app.livetv":
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        msg = "Foreground app info request rejected.";
                    }
                }
                else if (e.Data.Contains("play_01"))
                {
                    CallFunctionResponse cfr = JsonConvert.DeserializeObject<CallFunctionResponse>(e.Data);
                    if (cfr.Payload.ReturnValue)
                    {
                        msg = "Play button request succeeded.";
                    }
                    else
                    {
                        msg = "Play button request rejected.";
                    }
                }
                else if (e.Data.Contains("pause"))
                {
                    CallFunctionResponse cfr = JsonConvert.DeserializeObject<CallFunctionResponse>(e.Data);
                    if (cfr.Payload.ReturnValue)
                    {
                        msg = "Pause button request succeeded.";
                    }
                    else
                    {
                        msg = "Pause button request rejected.";
                    }
                }
                else if (e.Data.Contains("getchannelprograminfo_1"))
                {
                    ChannelProgramInfo cpi = JsonConvert.DeserializeObject<ChannelProgramInfo>(e.Data);

                    if (cpi.Payload.ReturnValue)
                    {
                        msg = "Channel program info request succeeded.";
                    }
                    else
                    {
                        msg = "Channel program info request rejected.";
                    }
                }
                else
                {
                    msg = e.Data;
                }

                DisplayMessage(msg); 
            }
        }

        private void SubscribeWebsocketEvents()
        {
            SubscribeWsEvent request = new SubscribeWsEvent
            {
                Type = "subscribe"
            };

            // Subscribe to volume change
            request.Id = "volume_sub";
            request.Uri = "ssap://audio/getVolume";
            ws.Send(JsonConvert.SerializeObject(request));
            
            // Subscribe to channel change
            request.Id = "channel_sub";
            request.Uri = "ssap://tv/getCurrentChannel";
            ws.Send(JsonConvert.SerializeObject(request));

            // Subscribe to program info
            request.Id = "proginfo_sub";
            request.Uri = "ssap://tv/getChannelProgramInfo";
        }

        internal void StartPairNewDevice(Guid uuid, string name)
        {
            AvailableDevice ad = new AvailableDevice();
            ad = availableDeviceList.availableDevList.Where(s => s.Uuid == uuid).FirstOrDefault();
            selectedDevice = new Device
            {
                FriendlyName = name,
                Ip = ad.Ip,
                Port = ad.ServicePort,
                MacAddress = ad.Mac,
                Server = ad.Server,
                Uuid = ad.Uuid,
                ApiKey = ""
            };

            deviceListFromConfig.Add(selectedDevice);
            SaveDeviceList();
            RefreshDeviceListComboBoxDelegate();

            cbSavedDevices.Invoke((Action)delegate
            {
                SetActiveDevice(name);
            });
            
            cbSavedDevices.Invoke((Action)delegate
            {
                Connect();
            });
            
        }

        // Display a log message when the connection closes
        private void Ws_OnClose(object sender, CloseEventArgs e)
        {
            string message = String.Format("Connection closed. | Reason: {0} | WasClean: {1} | Close status code: {2}",
                                           String.IsNullOrEmpty(e.Reason) ? "-": e.Reason, e.WasClean, e.Code);
            DisplayMessage(message);
            Disconnect();
        }

        private void SaveDeviceList()
        {
            Settings.Default.savedDeviceList = JsonConvert.SerializeObject(deviceListFromConfig);
            Settings.Default.Save();
        }

        private void Reconnect()
        {
            if (retry < 5)
            {
                retry++;
                Thread.Sleep(2000);
                DisplayMessage("Reconnecting...");
                ws.ConnectAsync();
            }
            else
            {
                DisplayMessage("The reconnecting has failed.");
            }
        }

        // When the connection opens
        private void Ws_OnOpen(object sender, EventArgs e)
        {
            retry = 0;
            DisplayMessage("Connection established.");
            btVol.Invoke(new Action(() => { btnConnect.Enabled = false; }));
            SendHandshake();
            btVol.Invoke(new Action(() => { btnDisconnect.Enabled = true; }));
        }

        // Sending handshake request when the device is paired with client
        private void SendHandshake()
        {
            bool isPaired = selectedDevice.ApiKey == "" ? false : true;

            string hs = "{\"type\":\"register\",\"id\":";
            if (isPaired)
            {
                hs += "\"register_0\"";
            }
            else
            {
                hs += "\"newPair\"";
            }
            hs += ",\"payload\":{\"forcePairing\":false,\"pairingType\":\"PROMPT\",";
            if (isPaired)
            {
                hs += "\"client-key\":\"" + apiKey + "\",";
            }
            hs += "\"manifest\":{\"manifestVersion\":1,\"appVersion\":\"1.1\",\"signed\":{\"created\":\"20140509\",\"appId\":\"com.lge.test\",\"vendorId\":\"com.lge\",\"localizedAppNames\":{\"\":\"LGRemoteApp\",\"en-EN\":\"RemoteApp\",\"zxx-XX\":\"LGRemoteApp\"},\"localizedVendorNames\":{\"\":\"LGElectronics\"},\"permissions\":[\"TEST_SECURE\",\"CONTROL_INPUT_TEXT\",\"CONTROL_MOUSE_AND_KEYBOARD\",\"READ_INSTALLED_APPS\",\"READ_LGE_SDX\",\"READ_NOTIFICATIONS\",\"SEARCH\",\"WRITE_SETTINGS\",\"WRITE_NOTIFICATION_ALERT\",\"CONTROL_POWER\",\"READ_CURRENT_CHANNEL\",\"READ_RUNNING_APPS\",\"READ_UPDATE_INFO\",\"UPDATE_FROM_REMOTE_APP\",\"READ_LGE_TV_INPUT_EVENTS\",\"READ_TV_CURRENT_TIME\"],\"serial\":\"2f930e2d2cfe083771f68e4fe7bb07\"},\"permissions\":[\"LAUNCH\",\"LAUNCH_WEBAPP\",\"APP_TO_APP\",\"CLOSE\",\"TEST_OPEN\",\"TEST_PROTECTED\",\"CONTROL_AUDIO\",\"CONTROL_DISPLAY\",\"CONTROL_INPUT_JOYSTICK\",\"CONTROL_INPUT_MEDIA_RECORDING\",\"CONTROL_INPUT_MEDIA_PLAYBACK\",\"CONTROL_INPUT_TV\",\"CONTROL_POWER\",\"READ_APP_STATUS\",\"READ_CURRENT_CHANNEL\",\"READ_INPUT_DEVICE_LIST\",\"READ_NETWORK_STATE\",\"READ_RUNNING_APPS\",\"READ_TV_CHANNEL_LIST\",\"WRITE_NOTIFICATION_TOAST\",\"READ_POWER_STATE\",\"READ_COUNTRY_INFO\"],\"signatures\":[{\"signatureVersion\":1,\"signature\":\"eyJhbGdvcml0aG0iOiJSU0EtU0hBMjU2Iiwia2V5SWQiOiJ0ZXN0LXNpZ25pbmctY2VydCIsInNpZ25hdHVyZVZlcnNpb24iOjF9.hrVRgjCwXVvE2OOSpDZ58hR+59aFNwYDyjQgKk3auukd7pcegmE2CzPCa0bJ0ZsRAcKkCTJrWo5iDzNhMBWRyaMOv5zWSrthlf7G128qvIlpMT0YNY+n/FaOHE73uLrS/g7swl3/qH/BGFG2Hu4RlL48eb3lLKqTt2xKHdCs6Cd4RMfJPYnzgvI4BNrFUKsjkcu+WD4OO2A27Pq1n50cMchmcaXadJhGrOqH5YmHdOCj5NSHzJYrsW0HPlpuAx/ECMeIZYDh6RMqaFM2DXzdKX9NmmyqzJ3o/0lkk/N97gfVRLW5hA29yeAwaCViZNCP8iC9aO0q9fQojoa7NQnAtw==\"}]}}}";

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

        // Displaying messages in the log window
        private void DisplayMessage(string message)
        {
            string msg = String.Format(new string('-', 60) + Environment.NewLine + DateTime.Now.ToString("HH:mm:ss.fff") + " ");
            msg += message + Environment.NewLine;
            tbLog.Invoke(new Action(() => { tbLog.AppendText(msg); }));
        }

        // Turn off button
        private void BtnTurnOff_Click(object sender, EventArgs e)
        {
            if (ws == null)
                return;

            string turnOff = "{ \"id\":\"1\",\"type\":\"request\",\"uri\":\"ssap://system/turnOff\"}";
            ws.Send(turnOff);
            
            // Log window
            DisplayMessage("Turn off signal sent.");
        }

        private void ConnectionLostDialog()
        {
            MessageBox.Show("The connection is lost." + Environment.NewLine + "Please connect first!",
                            "No connection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return;
        }

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            Connect();
        }

        private void BtnDisconnect_Click(object sender, EventArgs e)
        {
            if (ws == null)
                return;

            Disconnect();
        }

        private void Disconnect()
        {
            if (ws.IsAlive)
            {
                ws.Close();
                ws = null;
            }

            btVol.Invoke(new Action(() => { btVol.Text = ""; }));
            btnMute.Invoke(new Action(() => { btnMute.Image = Resources.Speaker_on; }));
            btVol.Invoke(new Action(() => { btChan.Text = ""; }));
            btnConnect.Enabled = true;
            btnDisconnect.Enabled = false;
        }

        private void GetAudioStatus()
        {
            AudioStatusRequest asrq = new AudioStatusRequest { Id = "status_1", Type = "request", Uri = "ssap://audio/getStatus"};

            ws.Send(JsonConvert.SerializeObject(asrq));
            DisplayMessage("GetAudioStatus request sent.");
        }

        private void BtnMute_Click(object sender, EventArgs e)
        {
            if (ws == null)
                return;

            bool mute = !Global._isMuted;
            string message = "{\"id\":\"toggle_mute\",\"type\":\"request\",\"uri\":\"ssap://audio/setMute\",\"payload\":{\"mute\":" + mute.ToString().ToLower() + "}}";
            ws.Send(message);
            DisplayMessage("Toggle mute sent.");
        }

        private void BtnTurnOn_Click(object sender, EventArgs e)
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

        // When the form closes, save the settings
        private void RemoteControl_FormClosed(object sender, FormClosedEventArgs e)
        {
            Settings.Default.Save();
        }

        // Validating the user added IPv4 address
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
            
            return splitValues.All(r => byte.TryParse(r, out byte tempForParsing));
        }

        public bool ValidateMac(string mac)
        {
            var regex = "[0-9A-F]{12}";
            var match = Regex.Match(mac, regex, RegexOptions.IgnoreCase);
            return match.Success;
        }

        private void BtVol_Click(object sender, EventArgs e)
        {
            if (ws == null)
                return;

            GetAudioStatus();
        }

        private void BtVolPlus_Click(object sender, EventArgs e)
        {
            if (ws == null)
                return;

            CallFunction("volumeup_1", "ssap://audio/volumeUp", "Volume up request sent.");
        }

        public void CallFunction(string id, string ep, string message)
        {
            if (ws == null)
                return;

            CallFunctionRequest cfr = new CallFunctionRequest { Id = id, Type = "request", Uri = ep };
            ws.Send(JsonConvert.SerializeObject(cfr));
            DisplayMessage(message);
        }

        internal void CallFunctionWithPayload(string id, string ep, string message, object payload)
        {
            CallFunctionRequestWithPayload cfr = new CallFunctionRequestWithPayload { Id = id, Type = "request", Uri = ep, Payload = payload };

            //DEBUG
            DisplayMessage(JsonConvert.SerializeObject(cfr));
            ws.Send(JsonConvert.SerializeObject(cfr));
            DisplayMessage(message);
        }

        internal void CallFunctionWithPayload(CallFunctionRequestWithPayload request, string message)
        {
            //DEBUG
            DisplayMessage(JsonConvert.SerializeObject(request));
            ws.Send(JsonConvert.SerializeObject(request));
            DisplayMessage(message);
        }

        private void BtVolMinus_Click(object sender, EventArgs e)
        {
            if (ws == null)
                return;

            CallFunction("volumedown_1", "ssap://audio/volumeDown", "Volume down request sent.");
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            tbLog.Invoke(new Action(() => { tbLog.Text = ""; }));
        }

        private void BtChan_Click(object sender, EventArgs e)
        {
            if (ws == null)
                return;

            GetCurrentChannel();
        }

        internal void GetCurrentChannel()
        {
            CallFunction("channelinfo_1", "ssap://tv/getCurrentChannel", "Channel info request sent.");
        }

        private void ChanPlus_Click(object sender, EventArgs e)
        {
            if (ws == null)
                return;

            CallFunction("channelup_1", "ssap://tv/channelUp", "Channel up request sent.");
        }

        private void ChanMinus_Click(object sender, EventArgs e)
        {
            if (ws == null)
                return;

            CallFunction("channeldown_1", "ssap://tv/channelDown", "Channel down request sent.");
        }

        private void BtChList_Click(object sender, EventArgs e)
        {
            if (ws == null)
                return;

            CallFunction("getchannels_1", "ssap://tv/getChannelList", "Channel list request sent.");
        }

        private void BtMessage_Click(object sender, EventArgs e)
        {
            if (ws == null)
                return;

            if (msgWindow != null)
            {
                msgWindow.BringToFront();
                return;
            }
            msgWindow = new DisplayMessage();
            msgWindow.FormClosing += MsgWindow_FormClosing;
            msgWindow.Show();
        }

        public void MsgWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            msgWindow = null;
        }

        private void ChannelProgramInfoButton_Click(object sender, EventArgs e)
        {
            if (ws == null)
                return;

            CallFunction("getchannelprograminfo_1", "ssap://tv/getChannelProgramInfo", "Channel programinfo request sent.");
        }

        private void SavedDeviceListWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            deviceListWindow = null;
        }

        public void RefreshDeviceListComboBoxDelegate()
        {
            cbSavedDevices.Invoke((Action)delegate
            {
                RefreshDeviceListComboBox();
            });
        }

        private void RefreshDeviceListComboBox()
        {
            cbSavedDevices.DataSource = null;
            cbSavedDevices.Items.Clear();
            deviceListFromConfig = LoadSavedDeviceList();
            cbSavedDevices.DataSource = deviceListFromConfig;
            cbSavedDevices.DisplayMember = "FriendlyName";
            cbSavedDevices.Refresh();
        }

        public void SetActiveDeviceDelegate(string name)
        {
            cbSavedDevices.Invoke((Action)delegate
            {
                SetActiveDevice(name);
            });
        }

        public void SetActiveDevice(string name)
        {
            cbSavedDevices.SelectedItem = name;
            selectedDevice = (Device)cbSavedDevices.SelectedItem;
        }

        private void BtnInput_Click(object sender, EventArgs e)
        {
            CallFunction("get_inputlist", "ssap://tv/getExternalInputList", "Input list request sent.");
        }

        private void ToolStripMenuItemDevManager_Click(object sender, EventArgs e)
        {
            if (deviceListWindow != null) return;
            deviceListWindow = new SavedDeviceListWindow();
            deviceListWindow.FormClosing += SavedDeviceListWindow_FormClosing;
            deviceListWindow.DevList = deviceListFromConfig;

            var thread = new Thread(new ParameterizedThreadStart(param => { deviceListWindow.ShowDialog(); }));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }
        
        private void AdWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            adWindow = null;
        }
        
        private void PairDeviceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (adWindow != null) return;
            adWindow = new AvailableDevicesWindow();
            var thread = new Thread(new ParameterizedThreadStart(param => { adWindow.ShowDialog(); }));
            thread.SetApartmentState(ApartmentState.STA);
            adWindow.FormClosing += AdWindow_FormClosing;
            thread.Start();
        }

        private void CbSavedDevices_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Settings.Default.lastUsedDevice = ((Device)cbSavedDevices.SelectedItem).FriendlyName;
            Settings.Default.Save();

            Connect();
        }

        private void BtYoutube_Click(object sender, EventArgs e)
        {
            if (ws == null)
                return;

            if (youtubeWindow != null)
            {
                youtubeWindow.BringToFront();
                return;
            }
            youtubeWindow = new YoutubeWindow();
            youtubeWindow.FormClosing += YoutubeWindow_FormClosing;
            youtubeWindow.Show();
        }

        private void YoutubeWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            youtubeWindow = null;
        }

        private void ShowLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToggleShowMenu();
        }

        private void ToggleShowMenu()
        {
            if (Settings.Default.showLog)
            {
                Settings.Default.showLog = false;
                toolStripMenuItemShowLog.Checked = false;
            }
            else
            {
                Settings.Default.showLog = true;
                toolStripMenuItemShowLog.Checked = true;
            }

            Settings.Default.Save();
            SetWindowSize();
        }

        public void Play()
        {
            CallFunction("play_01", "ssap://media.controls/play", "Play button request sent.");
        }

        public void Pause()
        {
            CallFunction("pause", "ssap://media.controls/pause", "Pause button request sent.");
        }

        public void Stop()
        {
            CallFunction("stop", "ssap://media.controls/stop", "Stop button request sent.");
        }

        public void ReWind()
        {
            CallFunction("rewind", "ssap://media.controls/rewind", "Rewind button request sent.");
        }

        public void FastForward()
        {
            CallFunction("fastForward", "ssap://media.controls/fastForward", "FastForward button request sent.");
        }

        public void GetForegroundAppInfo(string id)
        {
            CallFunction(id, "ssap://com.webos.applicationManager/getForegroundAppInfo", "Software information request sent.");
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            GetForegroundAppInfo("appinfo_exit");
        }

        private void TestButton_Click(object sender, EventArgs e)
        {

            CallFunction("listApps", "ssap://com.webos.applicationManager/listApps", "");
            //CallFunction("get_httpHeader", "ssap://com.webos.service.sdx/getHttpHeaderForServiceRequest", "");
            //ws.Send("{\"id\":\"mouse\",\"type\":\"request\",\"uri\":\"ssap://com.webos.service.networkinput/getPointerInputSocket\"}");

            //var payload = new
            //{
            //    appId = "youtube.leanback.v4"
            //};
            //CallFunctionWithPayload("getAppState", "ssap://system.launcher/getAppState", "Get app state request sent.", payload);
            //CallFunction("swInfo", "ssap://com.webos.service.update/getCurrentSWInformation", "Software info request sent.");
            //CallFunction("listApps", "ssap://com.webos.applicationManager/listApps", "List apps request sent.");
            //ws.Send("{\"id\":\"you_1\",\"type\":\"request\",\"uri\":\"ssap://system.launcher/launch\",\"payload\":{\"id\":\"youtube.leanback.v4\",\"contentId\":\"SDAt01CuqoM\"}}");
        }


        //CallFunction("getServiceList", "ssap://api/getServiceList", "Get service list request sent.");
        // Response: {"type":"response","id":"getServiceList","payload":{"returnValue":true,"services":[{"name":"api","version":1},{"name":"audio","version":1},{"name":"config","version":1},{"name":"media.controls","version":1},{"name":"media.viewer","version":1},{"name":"pairing","version":1},{"name":"settings","version":1},{"name":"system","version":1},{"name":"system.launcher","version":1},{"name":"system.notifications","version":1},{"name":"timer","version":1},{"name":"tv","version":1},{"name":"user","version":1},{"name":"webapp","version":2}]}}
        //CallFunctionWithPayload("swInfo", "ssap://com.webos.service.update/getCurrentSWInformation", "Software info request sent.", "");

        //subscribe ssap://com.webos.service.ime/registerRemoteKeyboard
        //request ssap://com.webos.service.networkinput/getPointerInputSocket
        //
    }
}
