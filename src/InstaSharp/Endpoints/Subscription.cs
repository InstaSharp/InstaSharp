using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using InstaSharp.Models;
using PortableRest;
using InstaSharp.Models.Responses;

namespace InstaSharp.Endpoints
{
    public class Subscription
    {
        public enum Object
        {
            User,
            Tag,
            Location,
            Geography
        }

        public enum Aspect
        {
            Media
        }

        private InstagramConfig _config;
        private RestClient _client;
        private string _verifyToken;

        public Subscription(InstagramConfig config)
        {
            _config = config;
            _client = new RestClient { BaseUrl = config.RealTimeAPI };
        }

        public Task<SubscriptionsResponse> Create(Object type, Aspect aspect)
        {

            // create a new guid that uniquely identifies this subscription request
            var _verifyToken = Guid.NewGuid().ToString();
            var request = new RestRequest { Method = HttpMethod.Post };

            request.AddParameter("client_id", _config.ClientId);
            request.AddParameter("client_secret", _config.ClientSecret);
            request.AddParameter("object", type.ToString().ToLower());
            request.AddParameter("aspect", aspect.ToString().ToLower());
            request.AddParameter("verify_token", _verifyToken);
            request.AddParameter("callback_url", _config.CallbackURI);

            return _client.ExecuteAsync<SubscriptionsResponse>(request);
        }
    }
}
