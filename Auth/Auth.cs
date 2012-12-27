using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

namespace InstaSharp {
    public class Auth {

        InstagramConfig _config;

        JavaScriptSerializer _serializer;

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

        public Auth(InstagramConfig config) {
            _config = config;
        }

        public static string AuthLink(string instagramOAuthURI, string clientId, string callbackURI, List<Scope> scopes, ResponseType responseType = ResponseType.Code) {
            StringBuilder scope = new StringBuilder();
            scopes.ForEach(s => {
                if (scope.Length > 0) scope.Append("+");
                scope.Append(s);
            });

            return string.Format("{0}/authorize/?client_id={1}&redirect_uri={2}&response_type={3}code&scope={4}", new object[] {
                instagramOAuthURI,
                clientId, 
                callbackURI, 
                responseType,
                scope.ToString()
            });
        }

        public AuthInfo RequestToken(string code) {
            
            _serializer = new JavaScriptSerializer();
           
            var parameters = new Dictionary<string, string>();
            parameters.Add("client_id", _config.ClientId);
            parameters.Add("client_secret", _config.ClientSecret);
            parameters.Add("grant_type", "authorization_code");
            parameters.Add("redirect_uri", _config.RedirectURI);
            parameters.Add("code", code);

            var result = HttpClient.POST(_config.OAuthURI + "/access_token", parameters);

            return (AuthInfo)_serializer.Deserialize<AuthInfo>(result);
        }
    }
}
