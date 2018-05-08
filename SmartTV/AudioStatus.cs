using Newtonsoft.Json;

namespace LgTvController
{
    internal class AudioStatusRequest
    {
        private string id;
        private string type;
        private string uri;

        public AudioStatusRequest() { }
        
        public AudioStatusRequest(string id, string type, string uri)
        {
            this.id = id;
            this.type = type;
            this.uri = uri;
        }

        [JsonProperty(PropertyName = "id")]
        public string Id { get => id; set => id = value; }
        [JsonProperty(PropertyName = "type")]
        public string Type { get => type; set => type = value; }
        [JsonProperty(PropertyName = "uri")]
        public string Uri { get => uri; set => uri = value; }
    }

    internal class AudioStatusResponse
    {
        private string type;
        private string id;
        private AudioPayload payload;
        
        public AudioStatusResponse(string type, string id, AudioPayload payload)
        {
            this.type = type;
            this.id = id;
            this.payload = payload;
        }

        public string Type { get => type; set => type = value; }
        public string Id { get => id; set => id = value; }
        internal AudioPayload Payload { get => payload; set => payload = value; }

        internal class AudioPayload
        {
            [JsonProperty(PropertyName = "returnValue")]
            public bool returnValue { get; set; }
            [JsonProperty(PropertyName = "scenario")]
            public string scenario { get; set; }
            [JsonProperty(PropertyName = "volume")]
            public int volume { get; set; }
            [JsonProperty(PropertyName = "volumeMax")]
            public int volumeMax { get; set; }
            [JsonProperty(PropertyName = "mute")]
            public bool mute { get; set; }

            public AudioPayload(bool returnValue, string scenario, int volume, int volumeMax, bool mute)
            {
                this.returnValue = returnValue;
                this.scenario = scenario;
                this.volume = volume;
                this.volumeMax = volumeMax;
                this.mute = mute;
            }
        }

        public override string ToString()
        {
            return System.String.Format("Scenario: {0}, volume: {1}/{2}, mute: {3}", payload.scenario, payload.volume, payload.volumeMax, payload.mute.ToString());
        }
    }
}