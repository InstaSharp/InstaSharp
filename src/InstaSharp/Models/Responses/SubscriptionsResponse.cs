using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstaSharp.Models.Responses {
    public class SubscriptionsResponse : IResponse {

        public Meta Meta { get; set; }
        public List<Subscription> Data { get; set; }
    }
}
