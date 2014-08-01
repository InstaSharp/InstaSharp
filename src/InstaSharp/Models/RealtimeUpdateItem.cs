using Newtonsoft.Json;

namespace InstaSharp.Models
{
    public class RealtimeUpdateItem
    {
        [JsonProperty("SubScription_ID")]
        public int SubScriptionId { get; set; }

        public string Object { get; set; }

        [JsonProperty("Object_ID")]
        public string ObjectId { get; set; }

        [JsonProperty("Changed_Aspect")]
        public string ChangedAspect { get; set; }

        public string Time { get; set; }
    }
}
