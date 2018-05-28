using Newtonsoft.Json;
using System.Collections.Generic;

namespace LgTvController
{
    internal class Input
    {
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "payload")]
        internal InputPayload Payload { get; set; }
    }

    internal class InputPayload
    {
        [JsonProperty(PropertyName = "returnValue")]
        internal bool? ReturnValue { get; set; }
        [JsonProperty(PropertyName = "devices")]
        internal List<Devices> Devices { get; set; }
    }

    internal class Devices
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "label")]
        public string Label { get; set; }
        [JsonProperty(PropertyName = "port")]
        public int Port { get; set; }
        [JsonProperty(PropertyName = "appId")]
        public string AppId { get; set; }
        [JsonProperty(PropertyName = "icon")]
        public string Icon { get; set; }
        [JsonProperty(PropertyName = "modified")]
        public bool Modified { get; set; }
        [JsonProperty(PropertyName = "lastUniqueId")]
        public int? LastUniqueId { get; set; }
        internal List<SubL> SubList { get; set; }
        [JsonProperty(PropertyName = "subCount")]
        public int SubCount { get; set; }
        [JsonProperty(PropertyName = "connected")]
        public bool Connected { get; set; }
        [JsonProperty(PropertyName = "favorite")]
        public bool Favorite { get; set; }
    }

    internal class SubL
    {
        internal IEnumerable<Item> Sub { get; set; }
    }
}
