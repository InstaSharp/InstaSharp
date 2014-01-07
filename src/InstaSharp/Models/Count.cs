using Newtonsoft.Json;

namespace InstaSharp.Models {
    public class Count {
        public int Media { get; set; }
        public int Follows { get; set; }
        [JsonProperty("followed_by")]
        public int FollowedBy { get; set; }
    }
}
