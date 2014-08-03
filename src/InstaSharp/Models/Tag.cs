using Newtonsoft.Json;

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
        [JsonProperty("media_count")]
        public int MediaCount { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
    }
}
