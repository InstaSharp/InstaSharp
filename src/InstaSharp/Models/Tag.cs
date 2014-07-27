using Newtonsoft.Json;

namespace InstaSharp.Models {
    public class Tag {
        [JsonProperty("media_count")]
        public int MediaCount { get; set; }
        public string Name { get; set; }
    }
}
