using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InstaSharp.Model.Responses;

namespace InstaSharp.Endpoints.Likes {
    public class Unauthenticated : InstagramAPI {

        public Unauthenticated(InstagramConfig config)
            : base(config, "/media/") { }

        public UsersResponse Get(string mediaId) {
            return (UsersResponse)Mapper.Map<UsersResponse>(GetJson(mediaId));
        }

        public string GetJson(string mediaId) {
            string uri = string.Format(base.Uri + "{0}/likes?client_id={1}", mediaId, InstagramConfig.ClientId);
            return HttpClient.GET(uri);
        }
    }
}
