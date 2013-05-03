using InstaSharp.Models.Responses;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

namespace InstaSharp {
    public class OAuth {

        InstagramConfig _config;

        public enum ResponseType {
            Code,
            Token
        }

        public enum Scope {
            Basic,
            Comments,
            Relationships,
            Likes
        }

        public OAuth(InstagramConfig config) {
            _config = config;
        }

        public static string AuthLink(string instagramOAuthURI, string clientId, string callbackURI, List<Scope> scopes, ResponseType responseType = ResponseType.Token) {
            StringBuilder scope = new StringBuilder();
            scopes.ForEach(s => {
                if (scope.Length > 0) scope.Append("+");
                scope.Append(s);
            });

            return string.Format("{0}?client_id={1}&redirect_uri={2}&response_type={3}&scope={4}", new object[] {
                instagramOAuthURI.ToLower(),
                clientId.ToLower(), 
                callbackURI.ToLower(), 
                responseType,
                scope.ToString().ToLower()
            });
        }

        public IRestResponse<OAuthResponse> RequestToken(string code) {

            RestClient client = new RestClient(_config.OAuthURI);
            RestRequest request = new RestRequest("/access_token", Method.POST);

            request.AddParameter("client_id", _config.ClientId);
            request.AddParameter("client_secret", _config.ClientSecret);
            request.AddParameter("grant_type", "authorization_code");
            request.AddParameter("redirect_uri", _config.RedirectURI);
            request.AddParameter("code", code);

            return client.Execute<OAuthResponse>(request);
        }
    }
}
