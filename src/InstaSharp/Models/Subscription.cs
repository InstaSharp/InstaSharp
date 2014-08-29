using Newtonsoft.Json;

namespace InstaSharp.Models
{
    /// <summary>
    /// The Subscription
    /// </summary>
    public class Subscription
    {

        /// <summary>
        /// The newly created subscriptionId
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Should be "subscription"
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        ///   <see cref="Endpoints.Subscription.Object" />
        /// </summary>
        /// <value>
        /// The object.
        /// </value>
        public Endpoints.Subscription.Object Object { get; set; }

        /// <summary>
        ///   <see cref="InstaSharp.Endpoints.Subscription.Aspect" />
        /// </summary>
        /// <value>
        /// The aspect.
        /// </value>
        public Endpoints.Subscription.Aspect Aspect { get; set; }

        /// <summary>
        /// Gets or sets the callback URL.
        /// </summary>
        /// <value>
        /// The callback URL.
        /// </value>
        [JsonProperty("Callback_Url")]
        public string CallbackUrl { get; set; }

        /// <summary>
        /// The search term 
        /// </summary>
        [JsonProperty("Object_Id")]
        public string ObjectId { get; set; }

    }
}
