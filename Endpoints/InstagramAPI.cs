using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstaSharp.Endpoints {
    public class InstagramAPI {

        public InstagramConfig InstagramConfig { get; private set; }
        public AuthInfo AuthInfo { get; private set; }
        public StringBuilder Uri { get; set; }

        public InstagramAPI(string endpoint, InstagramConfig instagramConfig, AuthInfo authInfo = null) {
            InstagramConfig = instagramConfig;
            AuthInfo = authInfo ?? null;
            Uri = new StringBuilder(InstagramConfig.APIURI + endpoint);
        }

        internal void FormatUri(string substitution = null) {
            if (substitution != null) {
                Uri.Append(substitution);
            }
            
            Uri.Append(AuthInfo == null ? "?client_id=" + InstagramConfig.ClientId : "?access_token=" + AuthInfo.Access_Token);
        }
    }
}
