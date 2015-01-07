using Newtonsoft.Json;

namespace InstaSharp.Models
{
    /// <summary>
    /// Relationship
    /// </summary>
    public class Relationship
    {
        /// <summary>
        /// Your relationship to the user.
        /// </summary>
        /// <value>
        /// The outgoing status.
        /// </value>
        [JsonProperty("outgoing_status")]
        public OutgoingStatus OutgoingStatus { get; set; }

        /// <summary>
        /// A user's relationship to you. 
        /// </summary>
        /// <value>
        /// The incoming status.
        /// </value>
        [JsonProperty("incoming_status")]
        public IncomingStatus IncomingStatus { get; set; }

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
