using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace LgTvController
{
    internal class Channel
    {
        [JsonProperty(PropertyName = "channelId")]
        internal string ChannelId { get; set; }
        [JsonProperty(PropertyName = "programId")]
        internal string ProgramId { get; set; }
        [JsonProperty(PropertyName = "signalChannelId")]
        internal string SignalChannelId { get; set; }
        [JsonProperty(PropertyName = "chanCode")]
        internal string ChanCode { get; set; }
        [JsonProperty(PropertyName = "channelMode")]
        internal string ChannelMode { get; set; }
        [JsonProperty(PropertyName = "channelModeId")]
        internal int ChannelModeId { get; set; }
        [JsonProperty(PropertyName = "channelType")]
        internal string ChannelType { get; set; }
        [JsonProperty(PropertyName = "channelTypeId")]
        internal int ChannelTypeId { get; set; }
        [JsonProperty(PropertyName = "channelNumber")]
        internal string ChannelNumber { get; set; }
        [JsonProperty(PropertyName = "majorNumber")]
        internal int MajorNumber { get; set; }
        [JsonProperty(PropertyName = "minorNumber")]
        internal int MinorNumber { get; set; }
        [JsonProperty(PropertyName = "channelName")]
        internal string ChannelName { get; set; }
        [JsonProperty(PropertyName = "skipped")]
        internal bool Skipped { get; set; }
        [JsonProperty(PropertyName = "locked")]
        internal bool Locked { get; set; }
        [JsonProperty(PropertyName = "descrambled")]
        internal bool Descrambled { get; set; }
        [JsonProperty(PropertyName = "scrambled")]
        internal bool Scrambled { get; set; }
        [JsonProperty(PropertyName = "serviceType")]
        internal int ServiceType { get; set; }
        //[JsonProperty(PropertyName = "favoriteGroup")]
        internal List<ItemRoot> FavoriteGroup { get; set; }
        [JsonProperty(PropertyName = "imgUrl")]
        internal string ImgUrl { get; set; }
        [JsonProperty(PropertyName = "display")]
        internal int Display { get; set; }
        [JsonProperty(PropertyName = "satelliteName")]
        internal string SatelliteName { get; set; }
        [JsonProperty(PropertyName = "fineTuned")]
        internal bool FineTuned { get; set; }
        [JsonProperty(PropertyName = "Frequency")]
        internal int Frequency { get; set; }
        [JsonProperty(PropertyName = "shortCut")]
        internal int ShortCut { get; set; }
        [JsonProperty(PropertyName = "Bandwidth")]
        internal int Bandwidth { get; set; }
        [JsonProperty(PropertyName = "HDTV")]
        internal bool HDTV { get; set; }
        [JsonProperty(PropertyName = "Invisible")]
        internal bool Invisible { get; set; }
        [JsonProperty(PropertyName = "TV")]
        internal bool TV { get; set; }
        [JsonProperty(PropertyName = "DTV")]
        internal bool DTV { get; set; }
        [JsonProperty(PropertyName = "ATV")]
        internal bool ATV { get; set; }
        [JsonProperty(PropertyName = "Data")]
        internal bool Data { get; set; }
        [JsonProperty(PropertyName = "Radio")]
        internal bool Radio { get; set; }
        [JsonProperty(PropertyName = "Numeric")]
        internal bool Numeric { get; set; }
        [JsonProperty(PropertyName = "PrimaryCh")]
        internal bool PrimaryCh { get; set; }
        [JsonProperty(PropertyName = "specialService")]
        internal bool SpecialService { get; set; }
        //[JsonProperty(PropertyName = "CASystemIDList")]
        internal List<CASystemID> CASystemIDList { get; set; }
        [JsonProperty(PropertyName = "CASystemIDListCount")]
        internal int CASystemIDListCount { get; set; }
        [JsonProperty(PropertyName = "groupIdList")]
        internal List<int> GroupIdList { get; set; }
        [JsonProperty(PropertyName = "channelGenreCode")]
        internal string ChannelGenreCode { get; set; }
        [JsonProperty(PropertyName = "favoriteIdxA")]
        internal int FavoriteIdxA { get; set; }
        [JsonProperty(PropertyName = "favoriteIdxB")]
        internal int FavoriteIdxB { get; set; }
        [JsonProperty(PropertyName = "favoriteIdxC")]
        internal int FavoriteIdxC { get; set; }
        [JsonProperty(PropertyName = "favoriteIdxD")]
        internal int FavoriteIdxD { get; set; }
        [JsonProperty(PropertyName = "imgUrl2")]
        internal string ImgUrl2 { get; set; }
        [JsonProperty(PropertyName = "channelLogoSize")]
        internal string ChannelLogoSize { get; set; }
        [JsonProperty(PropertyName = "ipChanServerUrl")]
        internal string IpChanServerUrl { get; set; }
        [JsonProperty(PropertyName = "payChan")]
        internal bool PayChan { get; set; }
        [JsonProperty(PropertyName = "IPChannelCode")]
        internal string IPChannelCode { get; set; }
        [JsonProperty(PropertyName = "ipCallNumber")]
        internal string IpCallNumber { get; set; }
        [JsonProperty(PropertyName = "otuFlag")]
        internal bool OtuFlag { get; set; }
        [JsonProperty(PropertyName = "favoriteIdxE")]
        internal int FavoriteIdxE { get; set; }
        [JsonProperty(PropertyName = "favoriteIdxF")]
        internal int FavoriteIdxF { get; set; }
        [JsonProperty(PropertyName = "favoriteIdxG")]
        internal int FavoriteIdxG { get; set; }
        [JsonProperty(PropertyName = "favoriteIdxH")]
        internal int FavoriteIdxH { get; set; }
        [JsonProperty(PropertyName = "satelliteLcn")]
        internal bool SatelliteLcn { get; set; }
        [JsonProperty(PropertyName = "waterMarkUrl")]
        internal string WaterMarkUrl { get; set; }
        [JsonProperty(PropertyName = "channelNameSortKey")]
        internal string ChannelNameSortKey { get; set; }
        [JsonProperty(PropertyName = "ipChanType")]
        internal string IpChanType { get; set; }
        [JsonProperty(PropertyName = "adultFlag")]
        internal int AdultFlag { get; set; }
        [JsonProperty(PropertyName = "ipChanCategory")]
        internal string IpChanCategory { get; set; }
        [JsonProperty(PropertyName = "ipChanInteractive")]
        internal bool IpChanInteractive { get; set; }
        [JsonProperty(PropertyName = "callSign")]
        internal string CallSign { get; set; }
        [JsonProperty(PropertyName = "adFlag")]
        internal int AdFlag { get; set; }
        [JsonProperty(PropertyName = "configured")]
        internal bool Configured { get; set; }
        [JsonProperty(PropertyName = "lastUpdated")]
        internal string LastUpdated { get; set; }
        [JsonProperty(PropertyName = "ipChanCpId")]
        internal string IpChanCpId { get; set; }
        [JsonProperty(PropertyName = "isFreeviewPlay")]
        internal int IsFreeviewPlay { get; set; }
        [JsonProperty(PropertyName = "playerService")]
        internal string PlayerService { get; set; }
        [JsonProperty(PropertyName = "TSID")]
        internal int TSID { get; set; }
        [JsonProperty(PropertyName = "SVCID")]
        internal int SVCID { get; set; }

        public override string ToString()
        {
            return "Channel information" + Environment.NewLine +
                   "\tAdFlag: " + AdFlag + Environment.NewLine +
                   "\tAdult flag: " + AdultFlag + Environment.NewLine +
                   "\tATV: " + ATV + Environment.NewLine +
                   "\tBandwith: " + Bandwidth + Environment.NewLine +
                   "\tCall sign: " + CallSign + Environment.NewLine +
                   "\tCA system Id list: " + CASystemIDList + Environment.NewLine +
                   "\tCA system Id list count: " + CASystemIDListCount + Environment.NewLine +
                   "\tChancode: " + ChanCode + Environment.NewLine +
                   "\tChannel genre code: " + ChannelGenreCode + Environment.NewLine +
                   "\tChannel Id: " + ChannelId + Environment.NewLine +
                   "\tChannel logo size: " + ChannelLogoSize + Environment.NewLine +
                   "\tChannel Mode: " + ChannelMode + Environment.NewLine +
                   "\tChannel mode Id: " + ChannelModeId + Environment.NewLine +
                   "\tChannel name: " + ChannelName + Environment.NewLine +
                   "\tChannel name sort key: " + ChannelNameSortKey + Environment.NewLine +
                   "\tChannel number: " + ChannelNumber + Environment.NewLine +
                   "\tChannel type: " + ChannelType + Environment.NewLine +
                   "\tChannel type Id: " + ChannelTypeId + Environment.NewLine +
                   "\tConfigured: " + Configured + Environment.NewLine +
                   "\tData: " + Data + Environment.NewLine +
                   "\tDescrambled: " + Descrambled + Environment.NewLine +
                   "\tDisplay: " + Display + Environment.NewLine +
                   "\tDTV: " + DTV + Environment.NewLine +
                   "\tFavorite group: " + FavoriteGroup + Environment.NewLine +
                   "\tFavorite IdxA: " + FavoriteIdxA + Environment.NewLine +
                   "\tFavorite IdxB: " + FavoriteIdxB + Environment.NewLine +
                   "\tFavorite IdxC: " + FavoriteIdxC + Environment.NewLine +
                   "\tFavorite IdxD: " + FavoriteIdxD + Environment.NewLine +
                   "\tFavorite IdxE: " + FavoriteIdxE + Environment.NewLine +
                   "\tFavorite IdxF: " + FavoriteIdxF + Environment.NewLine +
                   "\tFavorite IdxG: " + FavoriteIdxG + Environment.NewLine +
                   "\tFavorite IdxH: " + FavoriteIdxH + Environment.NewLine +
                   "\tFine Tuned: " + FineTuned + Environment.NewLine +
                   "\tFrequency: " + Frequency + Environment.NewLine +
                   "\tGroup Id list: " + String.Join(",", GroupIdList) + Environment.NewLine +
                   "\tHDTV: " + HDTV + Environment.NewLine +
                   "\tImage URL: " + ImgUrl + Environment.NewLine +
                   "\tImage URL2: " + ImgUrl2 + Environment.NewLine +
                   "\tInvisible: " + Invisible + Environment.NewLine +
                   "\tIP call number: " + IpCallNumber + Environment.NewLine +
                   "\tIP channel category: " + IpChanCategory + Environment.NewLine +
                   "\tIP channel Cp Id: " + IpChanCpId + Environment.NewLine +
                   "\tIP channel interactive: " + IpChanInteractive + Environment.NewLine +
                   "\tIP channel code: " + IPChannelCode + Environment.NewLine +
                   "\tIP channel server URL: " + IpChanServerUrl + Environment.NewLine +
                   "\tIP channel type: " + IpChanType + Environment.NewLine +
                   "\tIs free view play: " + IsFreeviewPlay + Environment.NewLine +
                   "\tLast updated: " + LastUpdated + Environment.NewLine +
                   "\tLocked: " + Locked + Environment.NewLine +
                   "\tMajor number: " + MajorNumber + Environment.NewLine +
                   "\tMinor number: " + MinorNumber + Environment.NewLine +
                   "\tNumeric: " + Numeric + Environment.NewLine +
                   "\tOtu flag: " + OtuFlag + Environment.NewLine +
                   "\tPay channel: " + PayChan + Environment.NewLine +
                   "\tPlayer service: " + PlayerService + Environment.NewLine +
                   "\tPrimary channel: " + PrimaryCh + Environment.NewLine +
                   "\tProgram Id: " + ProgramId + Environment.NewLine +
                   "\tRadio: " + Radio + Environment.NewLine +
                   "\tSatellite LCN: " + SatelliteLcn + Environment.NewLine +
                   "\tSatellite name: " + SatelliteName + Environment.NewLine +
                   "\tScrambled: " + Scrambled + Environment.NewLine +
                   "\tService type: " + ServiceType + Environment.NewLine +
                   "\tShortcut: " + ShortCut + Environment.NewLine +
                   "\tSignal channel Id: " + SignalChannelId + Environment.NewLine +
                   "\tSkipped: " + Skipped + Environment.NewLine +
                   "\tSpecial service: " + SpecialService + Environment.NewLine +
                   "\tSVCID: " + SVCID + Environment.NewLine +
                   "\tTSID: " + TSID + Environment.NewLine +
                   "\tTV: " + TV + Environment.NewLine +
                   "\tWatermark URL: " + WaterMarkUrl + Environment.NewLine;
        }
    }
}