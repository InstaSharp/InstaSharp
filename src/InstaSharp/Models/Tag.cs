using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace InstaSharp.Models
{
    /// <summary>
    /// Tag
    /// </summary>
    public class Tag
    {
        /// <summary>
        /// Gets or sets the media count.
        /// </summary>
        /// <value>
        /// The media count.
        /// </value>
        [JsonProperty("media_count"), JsonConverter(typeof(ConverterToInt))]
        public int MediaCount { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
    }

    public class ConverterToInt : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(double) || objectType == typeof(float);
        }

        public override object ReadJson(JsonReader reader,Type objectType, object existingValue, JsonSerializer serializer)
        {
            return Convert.ToInt32(reader.Value);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
