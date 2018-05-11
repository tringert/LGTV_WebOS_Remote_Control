using Newtonsoft.Json;

namespace LgTvController
{
    internal class RegisterRequest
    {

    }

    internal class RegisterResponse
    {
        private string type;
        private string id;
        private RegisterResponsePayload payload;

        public RegisterResponse(string type, string id, RegisterResponsePayload payload)
        {
            this.type = type;
            this.id = id;
            this.payload = payload;
        }

        public string Type { get => type; set => type = value; }
        public string Id { get => id; set => id = value; }
        internal RegisterResponsePayload Payload { get => payload; set => payload = value; }

        internal class RegisterResponsePayload
        {
            [JsonProperty(PropertyName = "client-key")]
            public string client_key { get; set; }
        }

        public override string ToString()
        {
            return System.String.Format("type: {0}, id: {1}, payload => client-key: {2}", type, id, payload.client_key);
        }
    }
}
