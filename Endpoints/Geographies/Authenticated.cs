using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InstaSharp.Model.Responses;

namespace InstaSharp.Endpoints.Geographies {
    public class Authenticated : InstagramAPI {
        
        readonly Unauthenticated _unauthenicated;

        public Authenticated(InstagramConfig config, AuthInfo auth)
            : base(config, auth, "/geographies/") {
                _unauthenicated = new Unauthenticated(config);
        }

        public MediaResponse Get(string mediaId, int? count, string min_id) {
            return _unauthenicated.Get(mediaId, count, min_id);
        }

        public string GetJson(string mediaId, int? count, string min_id) {
            return _unauthenicated.GetJson(mediaId, count, min_id);
        }
    }
}
