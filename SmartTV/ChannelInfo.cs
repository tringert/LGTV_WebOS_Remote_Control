using Newtonsoft.Json;

namespace LgTvController
{
    internal class ChannelInfo
    {
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "payload")]
        internal ChannelInfoPayload Payload { get; set; }
 
        internal class ChannelInfoPayload
        {
            [JsonProperty(PropertyName = "returnValue")]
            internal bool ReturnValue { get; set; }
            [JsonProperty(PropertyName = "channelId")]
            internal string ChannelId { get; set; }
            [JsonProperty(PropertyName = "physicalNumber")]
            internal int PhysicalNumber { get; set; }
            [JsonProperty(PropertyName = "isScrambled")]
            internal bool IsScrambled { get; set; }
            [JsonProperty(PropertyName = "channelTypeName")]
            internal string ChannelTypeName { get; set; }
            [JsonProperty(PropertyName = "isLocked")]
            internal bool IsLocked { get; set; }
            internal DualChannel dualChannel { get; set; }

            internal class DualChannel
            {
                [JsonProperty(PropertyName = "dualChannelId")]
                public int dualChannelId { get; set; }
                [JsonProperty(PropertyName = "dualChannelTypeName")]
                public string dualChannelTypeName { get; set; }
                [JsonProperty(PropertyName = "dualChannelTypeId")]
                public int dualChannelTypeId { get; set; }
                [JsonProperty(PropertyName = "dualChannelNumber")]
                public int dualChannelNumber { get; set; }
            }

            [JsonProperty(PropertyName = "isChannelChanged")]
            internal bool IsChannelChanged { get; set; }
            [JsonProperty(PropertyName = "channelModeName")]
            internal string ChannelModeName { get; set; }
            [JsonProperty(PropertyName = "channelNumber")]
            internal string ChannelNumber { get; set; }
            [JsonProperty(PropertyName = "isFineTuned")]
            internal bool IsFineTuned { get; set; }
            [JsonProperty(PropertyName = "channelTypeId")]
            internal int ChannelTypeId { get; set; }
            [JsonProperty(PropertyName = "isDescrambled")]
            internal bool IsDescrambled { get; set; }
            [JsonProperty(PropertyName = "isSkipped")]
            internal bool IsSkipped { get; set; }
            [JsonProperty(PropertyName = "isHEVCChannel")]
            internal bool IsHEVCChannel { get; set; }
            [JsonProperty(PropertyName = "hybridtvType")]
            internal string HybridtvType { get; set; }
            [JsonProperty(PropertyName = "isInvisible")]
            internal bool IsInvisible { get; set; }
            [JsonProperty(PropertyName = "favoriteGroup")]
            internal string FavoriteGroup { get; set; }
            [JsonProperty(PropertyName = "channelName")]
            internal string ChannelName { get; set; }
            [JsonProperty(PropertyName = "channelModeId")]
            internal int ChannelModeId { get; set; }
            [JsonProperty(PropertyName = "signalChannelId")]
            internal string SignalChannelId { get; set; }
            
        }
    }
}
