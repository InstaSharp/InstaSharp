using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstaSharp {
    [Serializable]
    public class InstagramConfig {
        public string APIURI { get; set; }
        public string OAuthURI { get; set; }
        public string RealTimeAPI { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string RedirectURI { get; set; }
        public string CallbackURI { get; set; }

        public InstagramConfig(string clientId, string clientSecret, string redirectURI, string callbackURI,
            string apiURI = "https://api.instagram.com/v1/", string oauthURI = "https://api.instagram.com/oauth/",
            string realTimeAPI = "https://api.instagram.com/v1/subscriptions/") {
            APIURI = apiURI;
            OAuthURI = oauthURI;
            ClientId = clientId;
            ClientSecret = clientSecret;
            RedirectURI = redirectURI;
            RealTimeAPI = realTimeAPI;
            CallbackURI = callbackURI;
        }

        public InstagramConfig(string apiURI = "https://api.instagram.com/v1/", 
            string oauthURI = "https://api.instagram.com/oauth/", string realTimeAPI = "https://api.instagram.com/v1/subscriptions/")
        {
            APIURI = apiURI;
            OAuthURI = oauthURI;
            RealTimeAPI = realTimeAPI;
        }

        public InstagramConfig()
        {
            APIURI = "https://api.instagram.com/v1/";
        }
    }
}
