using Newtonsoft.Json;

namespace LgTvController
{
    internal class ScannedChannelCount
    {
        [JsonProperty(PropertyName = "terrestrialAnalogCount")]
        internal int TerrestrialAnalogCount { get; set; }
        [JsonProperty(PropertyName = "terrestrialDigitalCount")]
        internal int TerrestrialDigitalCount { get; set; }
        [JsonProperty(PropertyName = "cableAnalogCount")]
        internal int CableAnalogCount { get; set; }
        [JsonProperty(PropertyName = "cableDigitalCount")]
        internal int cableDigitalCount { get; set; }
        [JsonProperty(PropertyName = "satelliteDigitalCount")]
        internal int SatelliteDigitalCount { get; set; }
    }
}
