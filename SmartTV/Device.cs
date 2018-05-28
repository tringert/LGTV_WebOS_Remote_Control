using Newtonsoft.Json;
using System;

namespace LgTvController
{
    public class Device
    {
        [JsonProperty(PropertyName = "FriendlyName")]
        public string FriendlyName { get; set; }
        [JsonProperty(PropertyName = "Location")]
        public string Server { get; set; }
        [JsonProperty(PropertyName = "Uuid")]
        public Guid? Uuid { get; set; }
        [JsonProperty(PropertyName = "ApiKey")]
        public string ApiKey { get; set; }
        [JsonProperty(PropertyName = "Ip")]
        public string Ip { get; set; }
        [JsonProperty(PropertyName = "Port")]
        public string Port { get; set; }
        [JsonProperty(PropertyName = "Mac")]
        public string MacAddress { get; set; }
    }
}
