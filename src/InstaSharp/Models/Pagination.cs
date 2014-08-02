using Newtonsoft.Json;

namespace InstaSharp.Models {
    /// <summary>
    /// Pagination
    /// </summary>
    public class Pagination {
        /// <summary>
        /// Gets or sets the next URL.
        /// </summary>
        /// <value>
        /// The next URL.
        /// </value>
        [JsonProperty("next_url")]
        public string NextUrl { get; set; }
        /// <summary>
        /// Gets or sets the next cursor.
        /// </summary>
        /// <value>
        /// The next cursor.
        /// </value>
        [JsonProperty("next_cursor")]
        public string NextCursor { get; set; }
        /// <summary>
        /// Gets or sets the next maximum identifier.
        /// </summary>
        /// <value>
        /// The next maximum identifier.
        /// </value>
        [JsonProperty("next_max_id")]
        public string NextMaxId { get; set; }
        /// <summary>
        /// Gets or sets the next minimum identifier.
        /// </summary>
        /// <value>
        /// The next minimum identifier.
        /// </value>
        [JsonProperty("next_min_id")]
        public string NextMinId { get; set; }
    }
}
