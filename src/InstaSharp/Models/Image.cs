using Newtonsoft.Json;

namespace InstaSharp.Models {
    public class Image {

        [JsonProperty("low_resolution")]
        public Resolution LowResolution { get; set; }

        public Resolution Thumbnail { get; set; }
        
        [JsonProperty("standard_resolution")]
        public Resolution StandardResolution { get; set; }
    }

    public class Resolution {
        public string Url { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
