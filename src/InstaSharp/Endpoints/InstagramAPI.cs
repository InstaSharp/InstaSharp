using InstaSharp.Extensions;
using InstaSharp.Models.Responses;
using System;
using System.Net;
using System.Net.Http;

namespace InstaSharp.Endpoints
{
    public class InstagramApi
    {
        public InstagramConfig InstagramConfig { get; private set; }

        public OAuthResponse OAuthResponse { get; private set; }

        internal HttpClient Client { get; private set; }

        public InstagramApi(string endpoint, InstagramConfig instagramConfig) : this(endpoint, instagramConfig, null)
        {
            
        }

        public InstagramApi(string endpoint, InstagramConfig instagramConfig, OAuthResponse oauthResponse)
        {
            InstagramConfig = instagramConfig;
            OAuthResponse = oauthResponse;

            var handler = new HttpClientHandler();
            if (handler.SupportsAutomaticDecompression)
            {
                handler.AutomaticDecompression = DecompressionMethods.GZip |
                                                 DecompressionMethods.Deflate;
            }

            Client = new HttpClient(handler) { BaseAddress = new Uri(new Uri(InstagramConfig.ApiUri), endpoint) };
        }

        protected void AssertIsAuthenticated()
        {
            if (OAuthResponse == null || OAuthResponse.User == null)
            {
                throw new InvalidOperationException("You are not authenticated");
            }
        }

        internal HttpRequestMessage Request(string fragment, HttpMethod method)
        {
            var request = new HttpRequestMessage(method, new Uri(Client.BaseAddress, fragment));
            return AddAuth(request);
        }

        internal HttpRequestMessage Request(string fragment)
        {
            return Request(fragment, HttpMethod.Get);
        }

        protected virtual HttpRequestMessage AddAuth(HttpRequestMessage request)
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
