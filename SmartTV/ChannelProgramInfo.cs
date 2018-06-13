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

        internal class ProgramInfoPayload
        {
            [JsonProperty(PropertyName = "returnValue")]
            internal bool ReturnValue { get; set; }
            [JsonProperty(PropertyName = "channel")]
            internal Channel Channel { get; set; }
            [JsonProperty(PropertyName = "programList")]
            internal List<ProgramListItem> ProgramList { get; set; }

            internal class ProgramListItem
            {
                [JsonProperty(PropertyName = "channelId")]
                internal string ChannelId { get; set; }
                [JsonProperty(PropertyName = "duration")]
                internal int Duration { get; set; }
                [JsonProperty(PropertyName = "endTime")]
                [JsonConverter(typeof(StringDateTimeConverter))]
                internal DateTime EndTime { get; set; }
                [JsonConverter(typeof(StringDateTimeConverter))]
                [JsonProperty(PropertyName = "localEndTime")]
                internal DateTime LocalEndTime { get; set; }
                [JsonConverter(typeof(StringDateTimeConverter))]
                [JsonProperty(PropertyName = "localStartTime")]
                internal DateTime LocalStartTime { get; set; }
                [JsonProperty(PropertyName = "genre")]
                internal string Genre { get; set; }
                [JsonProperty(PropertyName = "programId")]
                internal string ProgramId { get; set; }
                [JsonProperty(PropertyName = "programName")]
                internal string ProgramName { get; set; }
                [JsonProperty(PropertyName = "rating")]
                internal List<Rating> Ratings { get; set; }
                [JsonProperty(PropertyName = "signalChannelId")]
                internal string SignalChannelId { get; set; }
                [JsonConverter(typeof(StringDateTimeConverter))]
                [JsonProperty(PropertyName = "startTime")]
                internal DateTime StartTime { get; set; }
                [JsonProperty(PropertyName = "tableId")]
                internal int TableId { get; set; }

                internal class Rating
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
            }
        }
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