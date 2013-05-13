using InstaSharp.Models.Responses;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstaSharp.Endpoints {
    public class InstagramAPI {

        public InstagramConfig InstagramConfig { get; private set; }
        public OAuthResponse OAuthResponse { get; private set; }
        public string Uri { get; set; }
        public RestSharp.RestClient Client { get; set; }

        public InstagramAPI(string endpoint, InstagramConfig instagramConfig, OAuthResponse oauthResponse = null) {
            InstagramConfig = instagramConfig;
            OAuthResponse = oauthResponse ?? null;
            Uri = InstagramConfig.APIURI + endpoint;
            Client = new RestSharp.RestClient(InstagramConfig.APIURI + "/" + endpoint);
        }

        internal Request Request(string fragment, Method method = Method.GET) {
            var request = new Request(fragment, method);
            return AddAuth(request);
        }

        internal Request Request(Method method = Method.GET) {
            return AddAuth(new Request(method));
        }

        internal Request AddAuth(Request request) {
            if (OAuthResponse == null) {
                request.AddParameter("client_id", InstagramConfig.ClientId);
            } else {
                request.AddParameter("access_token", OAuthResponse.Access_Token);
            }

            return request;
        }
    }
}
