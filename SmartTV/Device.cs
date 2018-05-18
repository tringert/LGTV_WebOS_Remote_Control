using Newtonsoft.Json;
using System;

namespace LgTvController
{
    internal class Device
    {
        [JsonProperty(PropertyName = "FriendlyName")]
        internal string FriendlyName { get; set; }
        [JsonProperty(PropertyName = "Location")]
        internal Location Location { get; set; }
        [JsonProperty(PropertyName = "Server")]
        internal string Server { get; set; }
        [JsonProperty(PropertyName = "Uuid")]
        internal Guid? Uuid { get; set; }
        [JsonProperty(PropertyName = "Usn")]
        internal string Usn { get; set; }
        [JsonProperty(PropertyName = "Saved")]
        internal bool Saved { get; set; } = false;
    }

    internal class Location
    {
        [JsonProperty(PropertyName = "Ip")]
        internal string Ip { get; set; }
        [JsonProperty(PropertyName = "Port")]
        internal string Port { get; set; }
    }
}
