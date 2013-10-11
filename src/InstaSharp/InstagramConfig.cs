using System;

namespace InstaSharp
{
    public class InstagramConfig
    {
        private const string ApiUriDefault = "https://api.instagram.com/v1/";
        private const string OAuthUriDefault = "https://api.instagram.com/oauth/";
        private const string RealTimeApiDefault = "https://api.instagram.com/v1/subscriptions/";
        public string ApiUri { get; set; }
        public string OAuthUri { get; set; }
        public string RealTimeApi { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string RedirectUri { get; set; }
        public string CallbackUri { get; set; }


        public InstagramConfig()
            : this(null, null, null, null, ApiUriDefault, OAuthUriDefault, RealTimeApiDefault)
        {
        }

        public InstagramConfig(string clientId, string clientSecret)
            : this(clientId, clientSecret, null, null, ApiUriDefault, OAuthUriDefault, RealTimeApiDefault)
        {
        }

        public InstagramConfig(string clientId, string clientSecret, string redirectUri, string callbackUri, string apiUri, string oauthUri, string realTimeApi)
        {
            ApiUri = apiUri;
            OAuthUri = oauthUri;
            ClientId = clientId;
            ClientSecret = clientSecret;
            RedirectUri = redirectUri;
            RealTimeApi = realTimeApi;
            CallbackUri = callbackUri;
        }
    }
}
