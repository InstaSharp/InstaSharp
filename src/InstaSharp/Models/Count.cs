using Newtonsoft.Json;

namespace InstaSharp.Models {
    /// <summary>
    /// Count
    /// </summary>
    public class Count {
        /// <summary>
        /// Gets or sets the media.
        /// </summary>
        /// <value>
        /// The media.
        /// </value>
        public int Media { get; set; }
        /// <summary>
        /// Gets or sets the follows.
        /// </summary>
        /// <value>
        /// The follows.
        /// </value>
        public int Follows { get; set; }
        /// <summary>
        /// Gets or sets the followed by.
        /// </summary>
        /// <value>
        /// The followed by.
        /// </value>
        [JsonProperty("followed_by")]
        public int FollowedBy { get; set; }
    }
}
