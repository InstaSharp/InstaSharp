using InstaSharp.Extensions;
using InstaSharp.Models.Responses;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace InstaSharp
{
    /// <summary>
    /// 
    /// </summary>
    public class OAuth
    {
        private readonly InstagramConfig config;

        /// <summary>
        /// Response Type
        /// </summary>
        public enum ResponseType
        {
            /// <summary>
            /// The code
            /// </summary>
            Code,
            /// <summary>
            /// The token
            /// </summary>
            Token
        }

        /// <summary>
        /// Scope
        /// </summary>
        public enum Scope
        {
            /// <summary>
            /// The basic
            /// </summary>
            Basic,
            /// <summary>
            /// The comments
            /// </summary>
            Comments,
            /// <summary>
            /// The relationships
            /// </summary>
            Relationships,
            /// <summary>
            /// The likes
            /// </summary>
            Likes
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OAuth"/> class.
        /// </summary>
        /// <param name="config">The configuration.</param>
        public OAuth(InstagramConfig config)
        {
            this.config = config;
        }

        /// <summary>
        /// Authentications the link.
        /// </summary>
        /// <param name="instagramOAuthUri">The instagram o authentication URI.</param>
        /// <param name="clientId">The client identifier.</param>
        /// <param name="callbackUri">The callback URI.</param>
        /// <param name="scopes">The scopes.</param>
        /// <param name="responseType">Type of the response.</param>
        /// <returns></returns>
        public static string AuthLink(string instagramOAuthUri, string clientId, string callbackUri, List<Scope> scopes, ResponseType responseType = ResponseType.Token)
        {
            var scope = new StringBuilder();

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

        /// <summary>
        /// Requests the token.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        public Task<OAuthResponse> RequestToken(string code)
        {
            var client = new HttpClient { BaseAddress = new Uri(config.OAuthUri) };
            var request = new HttpRequestMessage(HttpMethod.Post, new Uri(client.BaseAddress, "access_token"));
            //HttpClient client = new HttpClient();
            //var request = new HttpRequestMessage(HttpMethod.Post, "https://api.instagram.com/oauth/access_token");
            var myParameters = string.Format("client_id={0}&client_secret={1}&grant_type={2}&redirect_uri={3}&code={4}",
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
