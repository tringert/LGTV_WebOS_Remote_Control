using Newtonsoft.Json;
using System.Collections.Generic;

namespace LgTvController
{
    internal class ChannelListPayload
    {
        [JsonProperty(PropertyName = "returnValue")]
        internal bool ReturnValue { get; set; }
        [JsonProperty(PropertyName = "valueList")]
        internal string ValueList { get; set; }
        [JsonProperty(PropertyName = "dataSource")]
        internal int DataSource { get; set; }
        [JsonProperty(PropertyName = "dataType")]
        internal int DataType { get; set; }
        [JsonProperty(PropertyName = "cableAnalogSkipped")]
        internal bool CableAnalogSkipped { get; set; }
        [JsonProperty(PropertyName = "scannedChannelCount")]
        internal ScannedChannelCount ScannedChannelCount { get; set; }
        [JsonProperty(PropertyName = "deviceSourceIndex")]
        internal int DeviceSourceIndex { get; set; }
        [JsonProperty(PropertyName = "channelListCount")]
        internal int ChannelListCount { get; set; }
        [JsonProperty(PropertyName = "channelLogoServerUrl")]
        internal string ChannelLogoServerUrl { get; set; }
        [JsonProperty(PropertyName = "ipChanInteractiveUrl")]
        internal string IpChanInteractiveUrl { get; set; }
        [JsonProperty(PropertyName = "ChannelList")]
        internal List<Channel> ChannelList { get; set; }
    }
}
