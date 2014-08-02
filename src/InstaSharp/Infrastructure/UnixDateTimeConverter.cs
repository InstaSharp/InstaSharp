using InstaSharp.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace InstaSharp.Infrastructure
{
    internal class UnixDateTimeConverter : DateTimeConverterBase
    {
        /// <summary>
        /// Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The <see cref="T:Newtonsoft.Json.JsonWriter"/> to write to.</param><param name="value">The value.</param><param name="serializer">The calling serializer.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            long val;
            if (value is DateTime)
            {
                val = ((DateTime)value).ToUnixTimestamp();
            }
            else
            {
                throw new Exception("Expected date object value.");
            }
            writer.WriteValue(val);
        }

        /// <summary>
        ///   Reads the JSON representation of the object.
        /// </summary>
        /// <param name = "reader">The <see cref = "JsonReader" /> to read from.</param>
        /// <param name = "objectType">Type of the object.</param>
        /// <param name = "existingValue">The existing value of object being read.</param>
        /// <param name = "serializer">The calling serializer.</param>
        /// <returns>The object value.</returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            long ticks;
            if (reader.TokenType == JsonToken.Integer)
            {
                ticks = (long)reader.Value;
            }
            else if (reader.TokenType == JsonToken.String)
            {
                ticks = long.Parse((string) reader.Value);
            }
            else
            {
                throw new Exception("Wrong Token Type");
            }
                
            return ticks.ToDateTimeFromUnix();
        }
    }
}
