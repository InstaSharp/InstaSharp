using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InstaSharp.Models;

namespace InstaSharp.Endpoints
{
    public class Realtime
    {
        private InstagramConfig _config;

        public Realtime(InstagramConfig config)
        {
            _config = config;
        }

        public void Subscribe(Models.Subscription.Object type, Models.Subscription.Aspect aspect)  {

            // create a new guid that uniquely identifies this subscription request
            var verifyToken = Guid.NewGuid().ToString();

            var parms = new Dictionary<string, string>();
            
            parms.Add("client_id", _config.ClientId);
            parms.Add("client_secret", _config.ClientSecret);
            parms.Add("object", type.ToString().ToLower());
            parms.Add("aspect", aspect.ToString().ToLower());
            parms.Add("verify_token", verifyToken);
            parms.Add("callback_url", _config.CallbackURI);

            HttpClient.POST(_config.RealTimeAPI, parms);

        }

    }
}
