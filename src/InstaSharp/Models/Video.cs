using Newtonsoft.Json;

namespace InstaSharp.Models {
    public class Video {

        [JsonProperty("low_resolution")]
        public Resolution LowResolution { get; set; }
        
        [JsonProperty("standard_resolution")]
        public Resolution StandardResolution { get; set; }
    }
}
