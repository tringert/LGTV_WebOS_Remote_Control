using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace LgTvController
{
    public class SSDP
    {
        private const string searchRequest = "M-SEARCH * HTTP/1.1\r\nHOST: 239.255.255.250:1900\r\nMAN: \"ssdp:discover\"\r\nMX: 5\r\nST: urn:lge-com:service:webos-second-screen:1\r\n\r\n";
        private const int MaxResultSize = 4096;
        private Socket socket;
        private Timer timer;
        private int sendCount;
        internal List<SSDPResponse> deviceList = new List<SSDPResponse>();
        private SocketAsyncEventArgs sendEvent;
        SSDPResponse ssdr = new SSDPResponse();
        private bool socketClosed;

        public void FindDevices()
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            byte[] multiCastData = Encoding.UTF8.GetBytes(searchRequest);
            socket.SendBufferSize = multiCastData.Length;
            sendEvent.SetBuffer(multiCastData, 0, multiCastData.Length);
            sendEvent.Completed += OnSocketSendEventCompleted;

            sendEvent = new SocketAsyncEventArgs
            {
                RemoteEndPoint = new IPEndPoint(IPAddress.Parse("239.255.255.250"), 1900)
            };

            TimerCallback cb = new TimerCallback((state) =>
            {
                socketClosed = true;
                socket.Close();
            });

            timer = new Timer(cb, null, TimeSpan.FromSeconds(5), new TimeSpan(-1));

            sendCount = 3;
            socketClosed = false;
            socket.SendToAsync(sendEvent);
        }

        private void OnSocketSendEventCompleted(object sender, SocketAsyncEventArgs e)
        {
            if (e.SocketError == SocketError.Success)
            {
                if (e.LastOperation == SocketAsyncOperation.SendTo)
                {
                    if (--sendCount != 0)
                    {
                        if (!socketClosed)
                        {
                            socket.SendToAsync(sendEvent);
                        }
                    }
                    else
                    {
                        e.RemoteEndPoint = new IPEndPoint(IPAddress.Any, 0);
                        socket.ReceiveBufferSize = MaxResultSize;
                        byte[] receiveBuffer = new byte[MaxResultSize];
                        e.SetBuffer(receiveBuffer, 0, MaxResultSize);
                        socket.ReceiveFromAsync(e);
                    }
                }
                else if (e.LastOperation == SocketAsyncOperation.ReceiveFrom)
                {
                    string response = Encoding.UTF8.GetString(e.Buffer, 0, e.BytesTransferred);
                    if (response.StartsWith("HTTP/1.1 200 OK", StringComparison.InvariantCultureIgnoreCase) && response.Contains("urn:lge-com:service:webos-second-screen"))
                    {
                        if (ParseResponse(response)) AddDeviceToList();
                    }
                    
                    if (!socketClosed)
                    {
                        socket.ReceiveFromAsync(e);
                    }
                }
            }
        }

        private void AddDeviceToList()
        {
            foreach (SSDPResponse item in deviceList)
            {
                if (ssdr.Location.Ip == item.Location.Ip &&
                    ssdr.Location.Port == item.Location.Port)
                {
                    return;
                }
            }

            deviceList.Add(ssdr);
        }

        private bool ParseResponse(string response)
        {
            string ip = "";
            string port = "";
            string server = "";
            string usn = ""; 
            string[] stringSeparator = new string[] { "\r\n" };
            string[] result = response.Replace("HTTP/1.1 200 OK\r\n", "").Split(stringSeparator, StringSplitOptions.RemoveEmptyEntries)
                .Select(o => o.Trim()).ToArray();
            
            ssdr = null;

            foreach (var item in result)
            {
                if (item.StartsWith("Location: ", StringComparison.InvariantCultureIgnoreCase))
                {
                    var loc = Regex.Replace(item, "Location: ", "", RegexOptions.IgnoreCase)
                        .Replace("http://", "")
                        .Replace("/", "").Split(':').ToArray();

                    ip = loc[0].ToString();
                    port = loc[1].ToString();
                }
                if (item.StartsWith("Server: "))
                {
                    server = Regex.Replace(item, "Server: ", "", RegexOptions.IgnoreCase);
                }
                if (item.StartsWith("USN: ", StringComparison.InvariantCultureIgnoreCase))
                {
                    usn = Regex.Replace(item, "USN: ", "", RegexOptions.IgnoreCase);
                }
            }

            if (!String.IsNullOrEmpty(ip) &&
                !String.IsNullOrEmpty(port) &&
                !String.IsNullOrEmpty(server) &&
                !String.IsNullOrEmpty(usn))
            {
               
                ssdr = new SSDPResponse
                {
                    Location = new Location
                    {
                        Ip = ip,
                        Port = port
                    },
                    Server = server,
                    Usn = usn
                };

                return true;
            }
            else
            {
                return false;
            }
        }

        internal class SSDPResponse
        {
            internal Location Location { get; set; }
            internal string Server { get; set; }
            internal string Usn { get; set; }
        }

        internal class Location
        {
            internal string Ip { get; set; }
            internal string Port { get; set; }
        }
    }
}