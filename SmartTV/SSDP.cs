using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;

namespace LgTvController
{
    internal static class SSDP
    {
        private const string searchRequest = "M-SEARCH * HTTP/1.1\r\nHOST: 239.255.255.250:1900\r\nMAN: \"ssdp:discover\"\r\nMX: 4\r\nST: urn:lge-com:service:webos-second-screen:1\r\n\r\n";
        private const int MaxResultSize = 1024;
        private static Socket socket;
        internal static List<Device> availableDevices = new List<Device>();
        private static SocketAsyncEventArgs sendEvent;
        private static Device ssdr = new Device();
        public static void FindDevices()
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            byte[] multiCastData = Encoding.UTF8.GetBytes(searchRequest);
            socket.SendBufferSize = multiCastData.Length;

            sendEvent = new SocketAsyncEventArgs
            {
                RemoteEndPoint = new IPEndPoint(IPAddress.Parse("239.255.255.250"), 1900)
            };

            sendEvent.SetBuffer(multiCastData, 0, multiCastData.Length);
            sendEvent.Completed += OnSocketSendEventCompleted;
            
            try
            {
                socket.SendToAsync(sendEvent);
            }
            catch (Exception)
            {
                // Debug
                Console.WriteLine("Exception");
                return;
            }
        }

        private static void OnSocketSendEventCompleted(object sender, SocketAsyncEventArgs e)
        {
            // Debug
            Console.WriteLine("Packet sent.");
            if (e.SocketError == SocketError.Success)
            {
                if (e.LastOperation == SocketAsyncOperation.SendTo)
                {
                    e.RemoteEndPoint = new IPEndPoint(IPAddress.Any, 0);
                    socket.ReceiveBufferSize = MaxResultSize;
                    byte[] receiveBuffer = new byte[MaxResultSize];
                    e.SetBuffer(receiveBuffer, 0, MaxResultSize);
                    socket.ReceiveFromAsync(e);
                }
                else if (e.LastOperation == SocketAsyncOperation.ReceiveFrom)
                {
                    string response = Encoding.UTF8.GetString(e.Buffer, 0, e.BytesTransferred);
                    if (response.StartsWith("HTTP/1.1 200 OK", StringComparison.InvariantCultureIgnoreCase) && response.Contains("urn:lge-com:service:webos-second-screen"))
                    {
                        if (ParseResponse(response)) AddDeviceToList();
                    }

                    socket.ReceiveFromAsync(e);
                }
            }
        }

        private static void AddDeviceToList()
        {
            foreach (Device item in availableDevices)
            {
                // Debug
                Console.WriteLine("Devices: {0}", availableDevices.Count);
                if (ssdr.Location.Ip == item.Location.Ip &&
                    ssdr.Location.Port == item.Location.Port)
                {
                    return;
                }
            }

            availableDevices.Add(ssdr);
        }

        private static bool ParseResponse(string response)
        {
            string friendlyName = "";
            string ip = "";
            string port = "";
            string server = "";
            string usn = "";
            Guid uuid = Guid.Empty;
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
                    var arr = usn.Split(new string[] { "::" }, StringSplitOptions.None);
                    string uuids = Regex.Replace(arr[0].ToString(), "uuid:", "", RegexOptions.IgnoreCase);
                    Guid.TryParse(uuids, out uuid);
                }
            }

            if (!String.IsNullOrEmpty(ip) &&
                !String.IsNullOrEmpty(port) &&
                !String.IsNullOrEmpty(server) &&
                !String.IsNullOrEmpty(usn))
            {

                ssdr = new Device
                {
                    FriendlyName = friendlyName,
                    Location = new Location
                    {
                        Ip = ip,
                        Port = port
                    },
                    Server = server,
                    Usn = usn,
                    Uuid = uuid
                };

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}