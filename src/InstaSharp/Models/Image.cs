using Newtonsoft.Json;

namespace InstaSharp.Models {
    /// <summary>
    /// The Image
    /// </summary>
    public class Image {

        /// <summary>
        /// Gets or sets the low resolution.
        /// </summary>
        /// <value>
        /// The low resolution.
        /// </value>
        [JsonProperty("low_resolution")]
        public Resolution LowResolution { get; set; }

        /// <summary>
        /// Gets or sets the thumbnail.
        /// </summary>
        /// <value>
        /// The thumbnail.
        /// </value>
        public Resolution Thumbnail { get; set; }

        /// <summary>
        /// Gets or sets the standard resolution.
        /// </summary>
        /// <value>
        /// The standard resolution.
        /// </value>
        [JsonProperty("standard_resolution")]
        public Resolution StandardResolution { get; set; }
    }
}
