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

        InstagramConfig _config;

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
            _config = config;
        }

        public static string AuthLink(string instagramOAuthURI, string clientId, string callbackURI, List<Scope> scopes, ResponseType responseType = ResponseType.Token)
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
                instagramOAuthURI.ToLower(),
                clientId.ToLower(), 
                callbackURI.ToLower(), 
                responseType,
                scope.ToString().ToLower()
            });
        }

        public Task<OAuthResponse> RequestToken(string code)
        {
            HttpClient client = new HttpClient { BaseAddress = new Uri(_config.OAuthURI) };
            var request = new HttpRequestMessage(HttpMethod.Post, "access_token");

            request.AddParameter("client_id", _config.ClientId);
            request.AddParameter("client_secret", _config.ClientSecret);
            request.AddParameter("grant_type", "authorization_code");
            request.AddParameter("redirect_uri", _config.RedirectURI);
            request.AddParameter("code", code);

            return client.ExecuteAsync<OAuthResponse>(request);
        }
    }
}
