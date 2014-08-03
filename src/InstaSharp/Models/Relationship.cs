using Newtonsoft.Json;

namespace InstaSharp.Models
{
    /// <summary>
    /// Relationship
    /// </summary>
    public class Relationship
    {
        /// <summary>
        /// Gets or sets the outgoing status.
        /// </summary>
        /// <value>
        /// The outgoing status.
        /// </value>
        [JsonProperty("outgoing_status")]
        public string OutgoingStatus { get; set; }

        /// <summary>
        /// Gets or sets the incoming status.
        /// </summary>
        /// <value>
        /// The incoming status.
        /// </value>
        [JsonProperty("incoming_status")]
        public string IncomingStatus { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [target user is private].
        /// </summary>
        /// <value>
        /// <c>true</c> if [target user is private]; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty("target_user_is_private")]
        public bool TargetUserIsPrivate { get; set; }
    }

}
