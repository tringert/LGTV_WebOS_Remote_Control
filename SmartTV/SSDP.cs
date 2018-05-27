﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;

namespace LgTvController
{
    internal static class SSDP
    {
        private static readonly string[] stringSeparator = new string[] { "\r\n" };
        private const string searchRequest = "M-SEARCH * HTTP/1.1\r\nHOST: 239.255.255.250:1900\r\nMAN: \"ssdp:discover\"\r\nMX: 4\r\nST: urn:lge-com:service:webos-second-screen:1\r\n\r\n";
        private const int MaxResultSize = 1024;
        private static Socket socket;
        internal static List<SSDPResponse> availableDevices = new List<SSDPResponse>();
        private static SocketAsyncEventArgs sendEvent;
        private static SSDPResponse ssdr = new SSDPResponse();
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
            //Console.WriteLine("Packet sent.");
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
        
        private static string GetMacAddress(string ipAddress)
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "arp",
                Arguments = "-a",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };
            process.StartInfo = startInfo;

            process.Start();
            String strData = process.StandardOutput.ReadToEnd();
            string[] arpTable = strData.Split(stringSeparator, StringSplitOptions.RemoveEmptyEntries)
                .Select(o => o.Trim()).ToArray();

            string[] arpEntry = default;
            foreach (var item in arpTable)
            {
                if (item.Contains(ipAddress))
                {
                    arpEntry = Regex.Split(item, @"\s{2,}").Select(o => o.Trim()).ToArray();
                    break;
                }
            }

            return arpEntry[1].Replace("-", "");
        }

        private static void AddDeviceToList()
        {
            foreach (SSDPResponse item in availableDevices)
            {
                // Debug
                //Console.WriteLine("Devices: {0}", availableDevices.Count);
                if (ssdr.Location.Ip == item.Location.Ip &&
                    ssdr.Location.Port == item.Location.Port)
                {
                    return;
                }
            }

            ssdr.Mac = GetMacAddress(ssdr.Location.Ip);
            availableDevices.Add(ssdr);
        }

        private static bool ParseResponse(string response)
        {
            string ip = "";
            string port = "";
            string server = "";
            string usn = "";
            Guid uuid = Guid.Empty;
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

                ssdr = new SSDPResponse
                {
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

    internal class SSDPResponse
    {
        internal Location Location { get; set; }
        internal string Server { get; set; }
        internal Guid? Uuid { get; set; }
        internal string Usn { get; set; }
        internal string Mac { get; set; }
    }

    internal class Location
    {
        internal string Ip { get; set; }
        internal string Port { get; set; }
    }
}