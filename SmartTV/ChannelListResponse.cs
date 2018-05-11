using Newtonsoft.Json;

namespace LgTvController
{
    internal class ChannelListResponse
    {
        [JsonProperty(PropertyName = "type")]
        internal string Type { get; set; }
        [JsonProperty(PropertyName = "id")]
        internal string Id { get; set; }
        [JsonProperty(PropertyName = "payload")]
        internal ChannelListPayload Payload { get; set; }
    }
}
