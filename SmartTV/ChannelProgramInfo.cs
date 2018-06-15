using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace LgTvController
{
    internal class ChannelProgramInfo
    {
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "payload")]
        internal ProgramInfoPayload Payload { get; set; }
    }

    internal class ProgramInfoPayload
    {
        [JsonProperty(PropertyName = "returnValue")]
        internal bool ReturnValue { get; set; }
        [JsonProperty(PropertyName = "channel")]
        internal Channel Channel { get; set; }
        [JsonProperty(PropertyName = "programList")]
        internal List<ProgramListItem> ProgramList { get; set; }
    }

    public class ProgramListItem
    {
        [JsonProperty(PropertyName = "channelId")]
        public string ChannelId { get; set; }
        [JsonProperty(PropertyName = "duration")]
        public int Duration { get; set; }
        [JsonProperty(PropertyName = "endTime")]
        [JsonConverter(typeof(StringDateTimeConverter))]
        public DateTime EndDateTime { get; set; }
        [JsonConverter(typeof(StringDateTimeConverter))]
        [JsonProperty(PropertyName = "localEndTime")]
        public DateTime LocalEndDateTime { get; set; }
        [JsonConverter(typeof(StringDateTimeConverter))]
        [JsonProperty(PropertyName = "localStartTime")]
        public DateTime LocalStartDateTime { get; set; }
        [JsonProperty(PropertyName = "genre")]
        public string Genre { get; set; }
        [JsonProperty(PropertyName = "programId")]
        public string ProgramId { get; set; }
        [JsonProperty(PropertyName = "programName")]
        public string ProgramName { get; set; }
        [JsonProperty(PropertyName = "rating")]
        public List<Rating> Ratings { get; set; }
        [JsonProperty(PropertyName = "signalChannelId")]
        public string SignalChannelId { get; set; }
        [JsonConverter(typeof(StringDateTimeConverter))]
        [JsonProperty(PropertyName = "startTime")]
        public DateTime StartDateTime { get; set; }
        [JsonProperty(PropertyName = "tableId")]
        public int TableId { get; set; }

        public ushort Percent { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int DurationMin { get; set; }
    }

    public class Rating
    {
        [JsonProperty(PropertyName = "ratingString")]
        internal string RatingString { get; set; }
        [JsonProperty(PropertyName = "ratingValue")]
        internal int RatingValue { get; set; }
        [JsonProperty(PropertyName = "region")]
        internal int Region { get; set; }
        [JsonProperty(PropertyName = "_id")]
        internal string _id { get; set; }
    }

    public class StringDateTimeConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var dateAndTime = DateTime.ParseExact(value.ToString(), "yyyy,MM,dd,HH,mm,ss", CultureInfo.CurrentCulture);
            writer.WriteValue(dateAndTime);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return DateTime.ParseExact(reader.Value.ToString(), "yyyy,MM,dd,HH,mm,ss", CultureInfo.InvariantCulture);
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTime);
        }
    }
}