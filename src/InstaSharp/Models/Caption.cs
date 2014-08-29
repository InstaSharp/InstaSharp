using InstaSharp.Infrastructure;
using Newtonsoft.Json;
using System;

namespace InstaSharp.Models {
    /// <summary>
    /// The Caption Object
    /// </summary>
    public class Caption {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public string Id { get; set; }
        /// <summary>
        /// Gets or sets the created time.
        /// </summary>
        /// <value>
        /// The created time.
        /// </value>
        [JsonProperty("created_time"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime CreatedTime { get; set; }
        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>
        /// The text.
        /// </value>
        public string Text { get; set; }
        /// <summary>
        /// Gets or sets the User the caption was created by.
        /// </summary>
        /// <value>
        /// From.
        /// </value>
        public UserInfo From { get; set; }
    }
}
