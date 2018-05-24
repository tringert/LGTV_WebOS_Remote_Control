using Newtonsoft.Json;
using System;

namespace LgTvController
{
    internal class Device
    {
        [JsonProperty(PropertyName = "FriendlyName")]
        internal string FriendlyName { get; set; }
        [JsonProperty(PropertyName = "Location")]
        internal string Server { get; set; }
        [JsonProperty(PropertyName = "Uuid")]
        internal Guid? Uuid { get; set; }
        [JsonProperty(PropertyName = "ApiKey")]
        internal bool ApiKey { get; set; } = false;
        [JsonProperty(PropertyName = "Ip")]
        internal string Ip { get; set; }
        [JsonProperty(PropertyName = "Port")]
        internal string Port { get; set; }
    }
}
