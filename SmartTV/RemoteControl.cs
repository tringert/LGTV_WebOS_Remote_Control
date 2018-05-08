using System;
using System.Net;
using System.Globalization;
using System.Windows.Forms;
using WebSocketSharp;
using SmartTV;
using SmartTV.Properties;
using System.Linq;
using Newtonsoft.Json;
using System.Drawing;
using System.Text.RegularExpressions;

namespace LgTvController
{
    public partial class RemoteControl : Form
    {
        WebSocket ws;
        private string apiKey = Settings.Default.apiKey;
        private string mac = Settings.Default.macAddr;
        private string ip = Settings.Default.ip;

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
                string msg = "";
                bool getAudioStatus = default;

                if (e.Data.Contains("register_0"))
                {
                    RegisterResponse rr = JsonConvert.DeserializeObject<RegisterResponse>(e.Data);
                    msg += "Handshake successful." + Environment.NewLine + rr.ToString();
                    getAudioStatus = true;
                }
                else if (e.Data.Contains("status_1"))
                {
                    AudioStatusResponse asr = JsonConvert.DeserializeObject<AudioStatusResponse>(e.Data);
                    msg += "Audio status received." + Environment.NewLine + asr.ToString();
                    Global.GlobalVolume = asr.Payload.volume;
                    string txt = Global.GlobalVolume + "/" + asr.Payload.volumeMax;
                    btVol.Invoke(new Action(() => { btVol.Text = txt; }));

                    if (asr.Payload.mute)
                    {
                        //btnMute.Invoke(new Action(() => { btnMute.Font.Strikeout = true; }));
                    }
                }
                else if (e.Data.Contains("volumeup_1"))
                {
                    CallFunctionResponse cfr = JsonConvert.DeserializeObject<CallFunctionResponse>(e.Data);

                    if (cfr.Payload.returnValue)
                    {
                        getAudioStatus = true;
                    }
                }
                else if (e.Data.Contains("volumedown_1"))
                {
                    CallFunctionResponse cfr = JsonConvert.DeserializeObject<CallFunctionResponse>(e.Data);

                    if (cfr.Payload.returnValue)
                    {
                        getAudioStatus = true;
                    }
                }
                else
                {
                    msg += e.Data;
                }

                msg += Environment.NewLine;
                DisplayMessage(msg);

                if (getAudioStatus) GetAudioStatus(); 
            }
        }

        private void Ws_OnClose(object sender, CloseEventArgs e)
        {
            string message = String.Format("{0}" + Environment.NewLine +
                                           "{1} Connection closed. | Reason: {2} | WasClean: {3} | Code: {4}" + Environment.NewLine, new string('-', 60), DateTime.Now.ToString("HH:mm:ss.fff"), String.IsNullOrEmpty(e.Reason) ? "-": e.Reason, e.WasClean, e.Code);
            DisplayMessage(message);
        }

        private void Ws_OnOpen(object sender, EventArgs e)
        {
            string message = "Connection established." + Environment.NewLine;
            DisplayMessage(message);

            SendHandshake();
        }

        private void SendHandshake()
        {
            string hs = "{\"type\":\"register\",\"id\":\"register_0\",\"payload\":{\"forcePairing\":false,\"pairingType\":\"PROMPT\",\"client-key\":\"" + apiKey + "\",\"manifest\":{\"manifestVersion\":1,\"appVersion\":\"1.1\",\"signed\":{\"created\":\"20140509\",\"appId\":\"com.lge.test\",\"vendorId\":\"com.lge\",\"localizedAppNames\":{\"\":\"LGRemoteApp\",\"hu-HU\":\"RemoteApp\",\"zxx-XX\":\"LGRemoteApp\"},\"localizedVendorNames\":{\"\":\"LGElectronics\"},\"permissions\":[\"TEST_SECURE\",\"CONTROL_INPUT_TEXT\",\"CONTROL_MOUSE_AND_KEYBOARD\",\"READ_INSTALLED_APPS\",\"READ_LGE_SDX\",\"READ_NOTIFICATIONS\",\"SEARCH\",\"WRITE_SETTINGS\",\"WRITE_NOTIFICATION_ALERT\",\"CONTROL_POWER\",\"READ_CURRENT_CHANNEL\",\"READ_RUNNING_APPS\",\"READ_UPDATE_INFO\",\"UPDATE_FROM_REMOTE_APP\",\"READ_LGE_TV_INPUT_EVENTS\",\"READ_TV_CURRENT_TIME\"],\"serial\":\"2f930e2d2cfe083771f68e4fe7bb07\"},\"permissions\":[\"LAUNCH\",\"LAUNCH_WEBAPP\",\"APP_TO_APP\",\"CLOSE\",\"TEST_OPEN\",\"TEST_PROTECTED\",\"CONTROL_AUDIO\",\"CONTROL_DISPLAY\",\"CONTROL_INPUT_JOYSTICK\",\"CONTROL_INPUT_MEDIA_RECORDING\",\"CONTROL_INPUT_MEDIA_PLAYBACK\",\"CONTROL_INPUT_TV\",\"CONTROL_POWER\",\"READ_APP_STATUS\",\"READ_CURRENT_CHANNEL\",\"READ_INPUT_DEVICE_LIST\",\"READ_NETWORK_STATE\",\"READ_RUNNING_APPS\",\"READ_TV_CHANNEL_LIST\",\"WRITE_NOTIFICATION_TOAST\",\"READ_POWER_STATE\",\"READ_COUNTRY_INFO\"],\"signatures\":[{\"signatureVersion\":1,\"signature\":\"eyJhbGdvcml0aG0iOiJSU0EtU0hBMjU2Iiwia2V5SWQiOiJ0ZXN0LXNpZ25pbmctY2VydCIsInNpZ25hdHVyZVZlcnNpb24iOjF9.hrVRgjCwXVvE2OOSpDZ58hR+59aFNwYDyjQgKk3auukd7pcegmE2CzPCa0bJ0ZsRAcKkCTJrWo5iDzNhMBWRyaMOv5zWSrthlf7G128qvIlpMT0YNY+n/FaOHE73uLrS/g7swl3/qH/BGFG2Hu4RlL48eb3lLKqTt2xKHdCs6Cd4RMfJPYnzgvI4BNrFUKsjkcu+WD4OO2A27Pq1n50cMchmcaXadJhGrOqH5YmHdOCj5NSHzJYrsW0HPlpuAx/ECMeIZYDh6RMqaFM2DXzdKX9NmmyqzJ3o/0lkk/N97gfVRLW5hA29yeAwaCViZNCP8iC9aO0q9fQojoa7NQnAtw==\"}]}}}";
            string message = default;
            try
            {
                ws.Send(hs);
                message = "Handshake request sent." + Environment.NewLine;
            }
            catch (Exception e)
            {
                message = String.Format("{0}" + Environment.NewLine +
                                        "{1} Exception occured: {2}" + Environment.NewLine, new string('-', 60), DateTime.Now.ToString("HH:mm:ss.fff"), e.Data);
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
            msg += message;
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
            DisplayMessage("GetAudioStatus request sent." + Environment.NewLine);
        }

        private void btnMute_Click(object sender, EventArgs e)
        {
            if (!CheckIsAlive())
            {
                ConnectionLostDialog();
                return;
            }

            string message = "{\"id\":\"2\",\"type\":\"request\",\"uri\":\"ssap://audio/setMute\",\"payload\":{\"mute\":false}}";
            ws.Send(message);
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
            DisplayMessage(message + Environment.NewLine);
        }

        private void btVolMinus_Click(object sender, EventArgs e)
        {
            CallFunction("volumedown_1", "ssap://audio/volumeDown", "Volume down request sent.");
        }
    }
}
