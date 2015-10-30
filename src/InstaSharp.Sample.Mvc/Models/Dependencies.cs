using Microsoft.AspNet.WebHooks;
using System.Web.Http;

namespace InstaSharp.Sample.Mvc.Models
{
    public static class Dependencies
    {
        private static InstagramWebHookClient _client;


        public static void Initialize(HttpConfiguration config)
        {
            _client = new InstagramWebHookClient(config);
        }


        public static InstagramWebHookClient Client
        {
            get { return _client; }
        }
    }
}