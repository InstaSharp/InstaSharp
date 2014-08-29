using Newtonsoft.Json;

namespace InstaSharp.Models
{
    /// <summary>
    /// An object returned from a live subscription
    /// </summary>
    public class RealtimeUpdateItem
    {
        /// <summary>
        /// Gets or sets the sub scription identifier.
        /// </summary>
        /// <value>
        /// The sub scription identifier.
        /// </value>
        [JsonProperty("SubScription_ID")]
        public int SubScriptionId { get; set; }

        /// <summary>
        /// Gets or sets the object.
        /// </summary>
        /// <value>
        /// The object.
        /// </value>
        public string Object { get; set; }

        /// <summary>
        /// Gets or sets the object identifier.
        /// </summary>
        /// <value>
        /// The object identifier.
        /// </value>
        [JsonProperty("Object_ID")]
        public string ObjectId { get; set; }

        /// <summary>
        /// Gets or sets the changed aspect.
        /// </summary>
        /// <value>
        /// The changed aspect.
        /// </value>
        [JsonProperty("Changed_Aspect")]
        public string ChangedAspect { get; set; }

        /// <summary>
        /// Gets or sets the time.
        /// </summary>
        /// <value>
        /// The time.
        /// </value>
        public string Time { get; set; }
    }
}
