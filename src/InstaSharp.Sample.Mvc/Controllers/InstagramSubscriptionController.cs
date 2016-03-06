using InstaSharp.Endpoints;
using InstaSharp.Sample.Mvc.Models;
using Microsoft.AspNet.WebHooks;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace InstaSharp.Sample.Mvc.Controllers
{
    [RoutePrefix("api/instagram")]
    public class InstagramSubscriptionController : ApiController
    {
        static string clientId = ConfigurationManager.AppSettings["MS_WebHookReceiverSecret_InstagramId"];
        static string clientSecret = ConfigurationManager.AppSettings["MS_WebHookReceiverSecret_Instagram"];
        static string redirectUri = ConfigurationManager.AppSettings["redirectUri"];
        static string callbackUri = ConfigurationManager.AppSettings["callbackUri"];

        InstagramConfig config = new InstagramConfig(clientId, clientSecret, redirectUri, callbackUri);

        [Route("subscribe")]
        public async Task<IHttpActionResult> PostSubscribe()
        {
            // Get our WebHook Client
            InstagramWebHookClient client = Dependencies.Client;

            // Subscribe to a geo location, in this case within 5000 meters of Times Square in NY
            var sub = await client.SubscribeAsync(string.Empty, Url, 40.757626, -73.985794, 5000);

            return Ok(sub);
        }

        [Route("unsubscribe")]
        public async Task PostUnsubscribeAll()
        {
            // Get our WebHook Client
            InstagramWebHookClient client = Dependencies.Client;

            // Unsubscribe from all subscriptions for the client configuration with id="".
            await client.UnsubscribeAsync("");
        }

        [Route("unsubscribe/{subId}")]
        public async Task PostUnsubscribe(string subId)
        {
            // Get our WebHook Client
            InstagramWebHookClient client = Dependencies.Client;

            // Unsubscribe from the given subscription using client configuration with id="".
            await client.UnsubscribeAsync("", subId);
        }
    }
}
