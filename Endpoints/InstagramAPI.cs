using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstaSharp.Endpoints {
    public class InstagramAPI {

        public InstagramConfig InstagramConfig { get; private set; }
        public AuthInfo AuthInfo { get; private set; }
        public string Uri { get; set; }

        public InstagramAPI(InstagramConfig instagramConfig, string endpoint) : this(instagramConfig, new AuthInfo(), endpoint) { }

        public InstagramAPI(InstagramConfig instagramConfig, AuthInfo authInfo, string endpoint) {
            InstagramConfig = instagramConfig;
            AuthInfo = authInfo;
            Uri = InstagramConfig.APIURI + endpoint;
        }
    }
}
