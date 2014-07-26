using System.Collections.Generic;

namespace InstaSharp.Models.Responses
{
    public class SubscriptionsResponse : Response
    {
        public List<Subscription> Data { get; set; }
    }
}
