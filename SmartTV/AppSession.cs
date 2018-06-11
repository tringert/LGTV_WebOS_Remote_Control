using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LgTvController
{
    internal class AppSession
    {
        internal string Name { get; set; }
        internal AppInfoResponse AppInfo { get; set; }
        internal string SessionId { get; set; }

        internal class LaunchAppResponse
        {
            private string type;
            private string id;
            private LaunchAppResponsePayload payload;

            public LaunchAppResponse(string type, string id, LaunchAppResponsePayload payload)
            {
                this.type = type;
                this.id = id;
                this.payload = payload;
            }

            public string Type { get => type; set => type = value; }
            public string Id { get => id; set => id = value; }
            internal LaunchAppResponsePayload Payload { get => payload; set => payload = value; }

            internal class LaunchAppResponsePayload
            {
                [JsonProperty(PropertyName = "returnValue")]
                public bool ReturnValue { get; set; }
                [JsonProperty(PropertyName = "id")]
                public string Id { get; set; }
                [JsonProperty(PropertyName = "sessionId")]
                public string SessionId { get; set; }
            }
        }

        internal class AppInfoResponse
        {
            private string type;
            private string id;
            private AppInfoResponsePayload payload;

            public AppInfoResponse() { }

            public AppInfoResponse(string type, string id, AppInfoResponsePayload payload)
            {
                this.type = type;
                this.id = id;
                this.payload = payload;
            }

            [JsonProperty(PropertyName = "type")]
            public string Type { get => type; set => type = value; }
            [JsonProperty(PropertyName = "id")]
            public string Id { get => id; set => id = value; }
            [JsonProperty(PropertyName = "payload")]
            internal AppInfoResponsePayload Payload { get => payload; set => payload = value; }

            internal class AppInfoResponsePayload
            {
                [JsonProperty(PropertyName = "appId")]
                public string AppId { get; set; }
                [JsonProperty(PropertyName = "returnValue")]
                public bool ReturnValue { get; set; }
                [JsonProperty(PropertyName = "windowId")]
                public string WindowId { get; set; }
            }
        }
    }
}
