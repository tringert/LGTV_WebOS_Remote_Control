using Newtonsoft.Json;

namespace LgTvController
{
    internal class CallFunctionRequest
    {
        private string id;
        private string type;
        private string uri;

        public CallFunctionRequest() { }

        public CallFunctionRequest(string id, string type, string uri)
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

    internal class SubscribeWsEvent : CallFunctionRequest { }

    internal class CallFunctionRequestWithPayload
    {
        private string id;
        private string type;
        private string uri;
        private object payload;

        public CallFunctionRequestWithPayload() { }

        public CallFunctionRequestWithPayload(string id, string type, string uri, object payload)
        {
            this.id = id;
            this.type = type;
            this.uri = uri;
            this.payload = payload;
        }

        [JsonProperty(PropertyName = "id")]
        public string Id { get => id; set => id = value; }
        [JsonProperty(PropertyName = "type")]
        public string Type { get => type; set => type = value; }
        [JsonProperty(PropertyName = "uri")]
        public string Uri { get => uri; set => uri = value; }
        [JsonProperty(PropertyName = "payload")]
        public object Payload { get => payload; set => payload = value; }
    }

    internal class CallFunctionResponse
    {
        private string type;
        private string id;
        private CallFunctionResponsePayload payload;

        public CallFunctionResponse(string type, string id, CallFunctionResponsePayload payload)
        {
            this.type = type;
            this.id = id;
            this.payload = payload;
        }

        public string Type { get => type; set => type = value; }
        public string Id { get => id; set => id = value; }
        internal CallFunctionResponsePayload Payload { get => payload; set => payload = value; }

        internal class CallFunctionResponsePayload
        {
            [JsonProperty(PropertyName = "returnValue")]
            public bool ReturnValue { get; set; }
        }
    }
}
