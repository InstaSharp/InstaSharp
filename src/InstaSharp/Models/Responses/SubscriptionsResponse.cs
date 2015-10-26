using System.Collections.Generic;
namespace InstaSharp.Models.Responses
{
    /// <summary>
    /// Subscriptions Response
    /// </summary>
    public class SubscriptionsResponse : Response
    {
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        public List<Subscription> Data { get; set; }
    }
}
