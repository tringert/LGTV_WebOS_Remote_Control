using Newtonsoft.Json;

namespace LgTvController
{
    internal class AudioStatusRequest
    {

        [JsonProperty(PropertyName = "id")]
        internal string Id { get; set; }
        [JsonProperty(PropertyName = "type")]
        internal string Type { get; set; }
        [JsonProperty(PropertyName = "uri")]
        internal string Uri { get; set; }
    }

    internal class AudioStatusResponse
    {
        [JsonProperty(PropertyName = "type")]
        internal string Type { get; set; }
        [JsonProperty(PropertyName = "id")]
        internal string Id { get; set; }
        [JsonProperty(PropertyName = "payload")]
        internal AudioPayload Payload { get; set; }

        internal class AudioPayload
        {
            [JsonProperty(PropertyName = "changed")]
            internal string[] Changed { get; set; }
            [JsonProperty(PropertyName = "returnValue")]
            internal bool ReturnValue { get; set; }
            [JsonProperty(PropertyName = "cause")]
            internal string Cause { get; set; }
            [JsonProperty(PropertyName = "scenario")]
            internal string Scenario { get; set; }
            [JsonProperty(PropertyName = "volume")]
            internal int Volume { get; set; }
            [JsonProperty(PropertyName = "volumeMax")]
            internal int VolumeMax { get; set; }
            [JsonProperty(PropertyName = "muted")]
            internal bool Mute { get; set; }
            [JsonProperty(PropertyName = "subscribed")]
            internal bool? Subscribed { get; set; }
        }

        public override string ToString()
        {
            return System.String.Format("Scenario: {0}, volume: {1}/{2}, muted: {3}", Payload.Scenario, Payload.Volume, Payload.VolumeMax, Payload.Mute.ToString());
        }
    }
}