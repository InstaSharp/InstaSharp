using System;
using Newtonsoft.Json;

namespace InstaSharp.Models {
    public class Subscription {

        /// <summary>
        /// The newly created subscriptionId
        /// </summary>
        public String Id { get; set; }

        /// <summary>
        /// Should be "subscription"
        /// </summary>
        public String Type { get; set; }

        /// <summary>
        /// <see cref="Endpoints.Subscription.Object"/>
        /// </summary>
        public Endpoints.Subscription.Object Object { get; set; }
        /// <summary>
        /// <see cref="InstaSharp.Endpoints.Subscription.Aspect"/>
        /// </summary>
        public Endpoints.Subscription.Aspect Aspect { get; set; }

        [JsonProperty("Callback_Url")]
        public string CallbackUrl { get; set; }
 
        /// <summary>
        /// The search term 
        /// </summary>
        [JsonProperty("Object_Id")]
        public String ObjectId { get; set; }

    }
}
