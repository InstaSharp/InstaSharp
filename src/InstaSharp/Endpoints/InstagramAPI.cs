using System.Net.Http;
using InstaSharp.Models.Responses;
using PortableRest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstaSharp.Endpoints
{
    public class InstagramAPI
    {

        public InstagramConfig InstagramConfig { get; private set; }
        public OAuthResponse OAuthResponse { get; private set; }
        public string Uri { get; set; }
        public RestClient Client { get; set; }

        public InstagramAPI(string endpoint, InstagramConfig instagramConfig, OAuthResponse oauthResponse = null)
        {
            InstagramConfig = instagramConfig;
            OAuthResponse = oauthResponse ?? null;
            Uri = InstagramConfig.APIURI + endpoint;
            Client = new RestClient() { BaseUrl = InstagramConfig.APIURI + "/" + endpoint };
        }

        //TODO refactor overloads
        internal Request Request(string fragment, HttpMethod method)
        {
            var request = new Request(fragment, method);
            return AddAuth(request);
        }

        internal Request Request(HttpMethod method)
        {
            return AddAuth(new Request(method));
        }

        internal Request Request(string fragment)
        {
            var request = new Request(fragment, HttpMethod.Get);
            return AddAuth(request);
        }

        internal Request Request()
        {
            return AddAuth(new Request());
        }

        internal Request AddAuth(Request request)
        {
            if (OAuthResponse == null)
            {
                request.AddParameter("client_id", InstagramConfig.ClientId);
            }
            else
            {
                request.AddParameter("access_token", OAuthResponse.Access_Token);
            }

            return request;
        }
    }
}
