using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InstaSharp.Model.Responses;

namespace InstaSharp.Endpoints.Likes {
    public class Authenticated : InstagramAPI {

        readonly Unauthenticated _unauthenticated;

        public Authenticated(InstagramConfig config, AuthInfo auth)
            : base(config, auth, "/media/") {
                _unauthenticated = new Unauthenticated(config);
        }

        public UsersResponse Get(string mediaId) {
            return _unauthenticated.Get(mediaId);
        }

        public string GetJson(string mediaId) {
            return _unauthenticated.GetJson(mediaId);
        }

         public LikesResponse Post(string mediaId) {
            return (LikesResponse)Mapper.Map<LikesResponse>(PostJson(mediaId));
        }

        public string PostJson(string mediaId) {
            string uri = string.Format(base.Uri + "{0}/likes?access_token={1}", mediaId, AuthInfo.Access_Token);
            return HttpClient.POST(uri);
        }

        public LikesResponse Delete(string mediaId) {
            return (LikesResponse)Mapper.Map<LikesResponse>(DeleteJson(mediaId));
        }

        public string DeleteJson(string mediaId) {
            string uri = string.Format(base.Uri + "{0}/likes?access_token={1}", mediaId, AuthInfo.Access_Token);
            return HttpClient.DELETE(uri);
        }
    }
}
