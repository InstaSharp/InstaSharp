using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InstaSharp.Models;
using RestSharp;

namespace InstaSharp.Endpoints
{
    public class Realtime
    {
        private InstagramConfig _config;
        private RestClient _client;

        public Realtime(InstagramConfig config)
        {
            _config = config;
            _client = new RestClient(config.RealTimeAPI);
        }

        public void Subscribe(Models.Subscription.Object type, Models.Subscription.Aspect aspect)  {

            // create a new guid that uniquely identifies this subscription request
            var verifyToken = Guid.NewGuid().ToString();
            var request = new RestRequest(Method.POST);
            
            request.AddParameter("client_id", _config.ClientId);
            request.AddParameter("client_secret", _config.ClientSecret);
            request.AddParameter("object", type.ToString().ToLower());
            request.AddParameter("aspect", aspect.ToString().ToLower());
            request.AddParameter("verify_token", verifyToken);
            request.AddParameter("callback_url", _config.CallbackURI);

            _client.Equals(request);
        }

    }
}
