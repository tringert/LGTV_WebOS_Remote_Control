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
            [JsonProperty(PropertyName = "returnValue")]
            internal bool returnValue { get; set; }
            [JsonProperty(PropertyName = "scenario")]
            internal string scenario { get; set; }
            [JsonProperty(PropertyName = "volume")]
            internal int volume { get; set; }
            [JsonProperty(PropertyName = "volumeMax")]
            internal int volumeMax { get; set; }
            [JsonProperty(PropertyName = "mute")]
            internal bool mute { get; set; }
        }

        public override string ToString()
        {
            return System.String.Format("Scenario: {0}, volume: {1}/{2}, mute: {3}", Payload.scenario, Payload.volume, Payload.volumeMax, Payload.mute.ToString());
        }
    }
}