using InstaSharp.Sample.Mvc.Models;
using Microsoft.AspNet.WebHooks;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InstaSharp.Sample.Mvc.Controllers
{
    public class InstagramWebHookHandler : WebHookHandler
    {
        public InstagramWebHookHandler()
        {
            this.Receiver = "instagram";
        }

        public override async Task ExecuteAsync(string generator, WebHookHandlerContext context)
        {
            // Get the WebHook client
            InstagramWebHookClient client = Dependencies.Client;

            // Convert the incoming data to a collection of InstagramNotifications
            var notifications = context.GetDataOrDefault<IEnumerable<InstagramNotification>>();
            foreach (var notification in notifications)
            {
                // Use WebHook client to get detailed information about the posted media
                var entries = await client.GetRecentGeoMedia(context.Id, notification.ObjectId);
                foreach (JToken entry in entries)
                {
                    // Get direct links and sizes of media
                    var thumbnail = entry["images"]["thumbnail"].ToObject<InstagramMedia>();
                    var lowres = entry["images"]["low_resolution"].ToObject<InstagramMedia>();
                    var std = entry["images"]["standard_resolution"].ToObject<InstagramMedia>();
                }
            }
        }
    }
}