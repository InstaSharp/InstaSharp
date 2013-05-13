using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InstaSharp.Models;
using RestSharp;
using InstaSharp.Models.Responses;

namespace InstaSharp.Endpoints
{
    public class Subscription
    {
        public enum Object {
            User,
            Tag,
            Location,
            Geography
        }

        public enum Aspect {
            Media
        }

        private InstagramConfig _config;
        private RestClient _client;
        private string _verifyToken;

        public Subscription(InstagramConfig config)
        {
            _config = config;
            _client = new RestClient(config.RealTimeAPI);
        }

        public IRestResponse<SubscriptionsResponse> Create(Object type, Aspect aspect)  {

            // create a new guid that uniquely identifies this subscription request
            var _verifyToken = Guid.NewGuid().ToString();
            var request = new RestRequest(Method.POST);
            
            request.AddParameter("client_id", _config.ClientId);
            request.AddParameter("client_secret", _config.ClientSecret);
            request.AddParameter("object", type.ToString().ToLower());
            request.AddParameter("aspect", aspect.ToString().ToLower());
            request.AddParameter("verify_token", _verifyToken);
            request.AddParameter("callback_url", _config.CallbackURI);

            return _client.Execute<SubscriptionsResponse>(request);
        }
    }
}
