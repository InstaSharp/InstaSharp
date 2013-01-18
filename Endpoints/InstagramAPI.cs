using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstaSharp.Endpoints {
    public class InstagramAPI {

        public InstagramConfig InstagramConfig { get; private set; }
        public AuthInfo AuthInfo { get; private set; }
        public string Uri { get; set; }

        public InstagramAPI(string endpoint, InstagramConfig instagramConfig, AuthInfo authInfo = null) {
            InstagramConfig = instagramConfig;
            AuthInfo = authInfo ?? null;
            Uri = InstagramConfig.APIURI + endpoint;
        }

        internal StringBuilder FormatUri(string substitution = null) {
            var uri = new StringBuilder(Uri);
            
            if (substitution != null) {
                uri.Append(substitution);
            }

            string client_or_token = AuthInfo == null ? "?client_id=" + InstagramConfig.ClientId : "?access_token=" + AuthInfo.Access_Token;

            return uri.Append(client_or_token);
        }
    }
}
