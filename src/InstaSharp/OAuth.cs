using InstaSharp.Extensions;
using InstaSharp.Models.Responses;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace InstaSharp
{
    public class OAuth
    {
        private readonly InstagramConfig config;

        public enum ResponseType
        {
            Code,
            Token
        }

        public enum Scope
        {
            Basic,
            Comments,
            Relationships,
            Likes
        }

        public OAuth(InstagramConfig config)
        {
            this.config = config;
        }

        public static string AuthLink(string instagramOAuthUri, string clientId, string callbackUri, List<Scope> scopes, ResponseType responseType = ResponseType.Token)
        {
            StringBuilder scope = new StringBuilder();

            foreach (var s in scopes)
            {
                if (scope.Length > 0)
                {
                    scope.Append("+");
                }
                scope.Append(s);
            }

            return string.Format("{0}?client_id={1}&redirect_uri={2}&response_type={3}&scope={4}", new object[] {
                instagramOAuthUri.ToLower(),
                clientId.ToLower(), 
                callbackUri.ToLower(), 
                responseType,
                scope.ToString().ToLower()
            });
        }

        public Task<OAuthResponse> RequestToken(string code)
        {
            HttpClient client = new HttpClient { BaseAddress = new Uri(config.OAuthUri) };
            var request = new HttpRequestMessage(HttpMethod.Post, new Uri(client.BaseAddress, "access_token"));
            //HttpClient client = new HttpClient();
            //var request = new HttpRequestMessage(HttpMethod.Post, "https://api.instagram.com/oauth/access_token");
            string myParameters = string.Format("client_id={0}&client_secret={1}&grant_type={2}&redirect_uri={3}&code={4}",
                config.ClientId.UrlEncode(),
                config.ClientSecret.UrlEncode(), 
                "authorization_code".UrlEncode(),
                config.RedirectUri.UrlEncode(), 
                code.UrlEncode());

            request.Content = new StringContent(myParameters);

            return client.ExecuteAsync<OAuthResponse>(request);

        }
    }
}
