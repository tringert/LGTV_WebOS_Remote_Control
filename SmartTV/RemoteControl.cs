using System;
using System.Net;
using System.Globalization;
using System.Windows.Forms;
using WebSocketSharp;
using LgTvController.Properties;
using System.Linq;
using Newtonsoft.Json;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using SmartTV.Properties;

namespace LgTvController
{
    public partial class RemoteControl : Form
    {
        private WebSocket ws;
        private ChannelListResponse clr;
        internal ChannelInfo ci;
        private static ChannelListWindow chWindow;
        private static InputListWindow inputWindow;
        internal List<Device> deviceList;
        private static DisplayMessage msgWindow;
        private static SavedDeviceListWindow deviceListWindow;
        private static System.Threading.Timer timer;
        private string apiKey = Settings.Default.apiKey;
        private string mac = Settings.Default.macAddr;
        private string ip = Settings.Default.ip;
        ushort retry = 0;

        public RemoteControl()
        {
            InitializeComponent();

            // Load the saved devices from App.Config
            deviceList = new List<Device>();
            deviceList = LoadSavedDeviceList();

            // Start the device discovery
            TimerCallback cb = new TimerCallback((state) =>
            {
                SSDP.FindDevices();
            });
            timer = new System.Threading.Timer(cb, null, 0, 5000);

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

        private void SaveDeviceList(List<Device> deviceList)
        {
            Settings.Default.savedDeviceList = JsonConvert.SerializeObject(deviceList);
            Settings.Default.Save();
        }

        private List<Device> LoadSavedDeviceList()
        {
            return JsonConvert.DeserializeObject<List<Device>>(Settings.Default.savedDeviceList);
        }

        private void Connect()
        {
            string host = "ws://" + ip + ":3000/";
            ws = new WebSocket(host);
            
            string hs = "{\"type\":\"register\",\"id\":\"register_0\",\"payload\":{\"forcePairing\":false,\"pairingType\":\"PROMPT\",\"client-key\":\"" + apiKey + "\",\"manifest\":{\"manifestVersion\":1,\"appVersion\":\"1.1\",\"signed\":{\"created\":\"20140509\",\"appId\":\"com.lge.test\",\"vendorId\":\"com.lge\",\"localizedAppNames\":{\"\":\"LGRemoteApp\",\"hu-HU\":\"RemoteApp\",\"zxx-XX\":\"LGRemoteApp\"},\"localizedVendorNames\":{\"\":\"LGElectronics\"},\"permissions\":[\"TEST_SECURE\",\"CONTROL_INPUT_TEXT\",\"CONTROL_MOUSE_AND_KEYBOARD\",\"READ_INSTALLED_APPS\",\"READ_LGE_SDX\",\"READ_NOTIFICATIONS\",\"SEARCH\",\"WRITE_SETTINGS\",\"WRITE_NOTIFICATION_ALERT\",\"CONTROL_POWER\",\"READ_CURRENT_CHANNEL\",\"READ_RUNNING_APPS\",\"READ_UPDATE_INFO\",\"UPDATE_FROM_REMOTE_APP\",\"READ_LGE_TV_INPUT_EVENTS\",\"READ_TV_CURRENT_TIME\"],\"serial\":\"2f930e2d2cfe083771f68e4fe7bb07\"},\"permissions\":[\"LAUNCH\",\"LAUNCH_WEBAPP\",\"APP_TO_APP\",\"CLOSE\",\"TEST_OPEN\",\"TEST_PROTECTED\",\"CONTROL_AUDIO\",\"CONTROL_DISPLAY\",\"CONTROL_INPUT_JOYSTICK\",\"CONTROL_INPUT_MEDIA_RECORDING\",\"CONTROL_INPUT_MEDIA_PLAYBACK\",\"CONTROL_INPUT_TV\",\"CONTROL_POWER\",\"READ_APP_STATUS\",\"READ_CURRENT_CHANNEL\",\"READ_INPUT_DEVICE_LIST\",\"READ_NETWORK_STATE\",\"READ_RUNNING_APPS\",\"READ_TV_CHANNEL_LIST\",\"WRITE_NOTIFICATION_TOAST\",\"READ_POWER_STATE\",\"READ_COUNTRY_INFO\"],\"signatures\":[{\"signatureVersion\":1,\"signature\":\"eyJhbGdvcml0aG0iOiJSU0EtU0hBMjU2Iiwia2V5SWQiOiJ0ZXN0LXNpZ25pbmctY2VydCIsInNpZ25hdHVyZVZlcnNpb24iOjF9.hrVRgjCwXVvE2OOSpDZ58hR+59aFNwYDyjQgKk3auukd7pcegmE2CzPCa0bJ0ZsRAcKkCTJrWo5iDzNhMBWRyaMOv5zWSrthlf7G128qvIlpMT0YNY+n/FaOHE73uLrS/g7swl3/qH/BGFG2Hu4RlL48eb3lLKqTt2xKHdCs6Cd4RMfJPYnzgvI4BNrFUKsjkcu+WD4OO2A27Pq1n50cMchmcaXadJhGrOqH5YmHdOCj5NSHzJYrsW0HPlpuAx/ECMeIZYDh6RMqaFM2DXzdKX9NmmyqzJ3o/0lkk/N97gfVRLW5hA29yeAwaCViZNCP8iC9aO0q9fQojoa7NQnAtw==\"}]}}}";

            // WebSocket event subscriptions
            ws.OnMessage += Ws_OnMessage;
            ws.OnOpen += Ws_OnOpen;
            ws.OnClose += Ws_OnClose;
            ws.OnError += (sender, e) => Console.WriteLine("Error: " + e.Message);

            // Debug
            Logger log = ws.Log;
            log.Level = LogLevel.Debug;
            Console.WriteLine("\n" + log.Output);

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
                string msg = "<unhandled message>";

                // Response for handshake
                if (e.Data.Contains("register_0"))
                {
                    RegisterResponse rr = JsonConvert.DeserializeObject<RegisterResponse>(e.Data);
                    msg = "Handshake successful." + Environment.NewLine + rr.ToString();
                  
                    // Subscribe to volume change
                    ws.Send("{ \"id\":\"volume_sub\",\"type\":\"subscribe\",\"uri\":\"ssap://audio/getVolume\"}");
                    // Subscribe to channel change
                    ws.Send("{ \"id\":\"channel_sub\",\"type\":\"subscribe\",\"uri\":\"ssap://tv/getCurrentChannel\"}");
                    // Subscribe to program info
                    //ws.Send("{ \"id\":\"volumesub\",\"type\":\"subscribe\",\"uri\":\"ssap://tv/getChannelProgramInfo\"}");
                }
                // Response for audio status request
                else if (e.Data.Contains("volume_sub"))
                {
                    AudioStatusResponse asr = JsonConvert.DeserializeObject<AudioStatusResponse>(e.Data);
                    msg = "Audio status received." + Environment.NewLine + asr.ToString();
                    Global._globalVolume = asr.Payload.Volume;

                    // Displaying the volume level
                    string txt = Global._globalVolume + "/" + asr.Payload.VolumeMax;
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

                    if (cfr.Payload.returnValue)
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
                    if (cfr.Payload.returnValue)
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
                    if (cfr.Payload.returnValue)
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
                    if (cfr.Payload.returnValue)
                    {
                        GetCurrentChannel();
                        msg = cfr.Id == "channelup_1" ? "Channel up success." : "Channel down success.";
                    }
                }
                // Response for get channels list request
                else if (e.Data.Contains("getchannels_1"))
                {
                    if (e.Data.Contains("\"returnValue\":true"))
                    {
                        clr = JsonConvert.DeserializeObject<ChannelListResponse>(e.Data);

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
                            inputList = response.Payload.Devices
                        };
                        inputWindow.ShowDialog();
                    }
                }
                // Response for displaying toast message on the screen request
                else if (e.Data.Contains("toast_1"))
                {
                    CallFunctionResponse cfr = JsonConvert.DeserializeObject<CallFunctionResponse>(e.Data);
                    if (cfr.Payload.returnValue)
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
                else
                {
                    msg = e.Data;
                }

                DisplayMessage(msg); 
            }
        }

        // Display a log message when the connection closes
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

        // When the connection opens
        private void Ws_OnOpen(object sender, EventArgs e)
        {
            retry = 0;
            DisplayMessage("Connection established.");
            SendHandshake();
        }

        // Sending handshake request when the device is paired with client
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

        // Displaying messages in the log window
        private void DisplayMessage(string message)
        {
            string msg = String.Format(new string('-', 60) + Environment.NewLine + DateTime.Now.ToString("HH:mm:ss.fff") + " ");
            msg += message + Environment.NewLine;
            txtResponse.Invoke(new Action(() => { txtResponse.AppendText(msg); }));
        }

        // Turn off button
        private void BtnTurnOff_Click(object sender, EventArgs e)
        {
            if (!CheckIsAlive())
            {
                ConnectionLostDialog();
                return;
            }

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

        private bool CheckIsAlive()
        {
            if (ws == null) return false;
            return ws.IsAlive;
        }

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            Connect();
        }

        private void BtnDisconnect_Click(object sender, EventArgs e)
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

        private void BtnMute_Click(object sender, EventArgs e)
        {
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
            Settings.Default.ip = tbIP.Text;
            Settings.Default.macAddr = tbMac.Text;
            Settings.Default.apiKey = tbApiKey.Text;
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

        // Saving the IP field's value when leaving the cell
        private void TbIP_Leave(object sender, EventArgs e)
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

        // Saving the API key field's value when leaving the cell
        private void TbApiKey_Leave(object sender, EventArgs e)
        {
            Settings.Default.apiKey = tbApiKey.Text;
            Settings.Default.Save();
        }

        // Saving the MAC address field's value when leaving the cell
        private void TbMac_Leave(object sender, EventArgs e)
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

        public bool ValidateMac(string mac)
        {
            var regex = "[0-9A-F]{12}";
            var match = Regex.Match(mac, regex, RegexOptions.IgnoreCase);
            return match.Success;
        }

        private void BtVol_Click(object sender, EventArgs e)
        {
            GetAudioStatus();
        }

        private void BtVolPlus_Click(object sender, EventArgs e)
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

        private void BtVolMinus_Click(object sender, EventArgs e)
        {
            CallFunction("volumedown_1", "ssap://audio/volumeDown", "Volume down request sent.");
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            txtResponse.Invoke(new Action(() => { txtResponse.Text = ""; }));
        }

        private void BtChan_Click(object sender, EventArgs e)
        {
            GetCurrentChannel();
        }

        internal void GetCurrentChannel()
        {
            CallFunction("channelinfo_1", "ssap://tv/getCurrentChannel", "Channel info request sent.");
        }

        private void ChanPlus_Click(object sender, EventArgs e)
        {
            CallFunction("channelup_1", "ssap://tv/channelUp", "Channel up request sent.");
        }

        private void ChanMinus_Click(object sender, EventArgs e)
        {
            CallFunction("channeldown_1", "ssap://tv/channelDown", "Channel down request sent.");
        }

        private void BtChList_Click(object sender, EventArgs e)
        {
            CallFunction("getchannels_1", "ssap://tv/getChannelList", "Channel list request sent.");
        }

        private void BtMessage_Click(object sender, EventArgs e)
        {
            if (msgWindow != null) return;
            msgWindow = new DisplayMessage();
            msgWindow.FormClosing += MsgWindow_FormClosing;
            msgWindow.Show();
        }

        public void MsgWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            msgWindow = null;
        }

        // TODO: finish this
        private void Button11_Click(object sender, EventArgs e)
        {
            CallFunction("getchannelprograminfo_1", "ssap://tv/getChannelProgramInfo", "Channel programinfo request sent.");
        }

        private void DeviceListButton_Click(object sender, EventArgs e)
        {
            if (deviceListWindow != null) return;
            deviceListWindow = new SavedDeviceListWindow();
            deviceListWindow.FormClosing += DeviceListWindow_FormClosing;
            deviceListWindow.DevList = deviceList;

            var thread = new Thread(new ParameterizedThreadStart(param => { deviceListWindow.ShowDialog(); }));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        private void DeviceListWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            deviceListWindow = null;
        }

        private void BtnInput_Click(object sender, EventArgs e)
        {
            CallFunction("get_inputlist", "ssap://tv/getExternalInputList", "Input list request sent.");
        }

        private void Button12_Click(object sender, EventArgs e)
        {
            var payload = JsonConvert.SerializeObject(new { id = "com.webos.app.livetv" });
            CallFunctionWithPayload("change_input", "ssap://system.launcher/launch", "LiveTv_input_change_request_sent.", payload);
        }
    }
}
