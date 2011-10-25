using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InstaSharp.Model.Responses;

namespace InstaSharp.Endpoints.Comments {
    public class Authenticated : InstagramAPI {

        readonly Unauthenticated _unauthenticated;

        public Authenticated(InstagramConfig config, AuthInfo authInfo) :
            base(config, authInfo, "/media/") {
            _unauthenticated = new Unauthenticated(config);
        }

        public CommentsResponse Get(string mediaId) {
            return _unauthenticated.Get(mediaId);
        }

        public string GetJson(string mediaId) {
            return _unauthenticated.GetJson(mediaId);
        }

        public CommentsResponse Post(string mediaId, string comment) {
            return (CommentsResponse)Json.Map<CommentsResponse>(PostJson(mediaId, comment));
        }

        public string PostJson(string mediaId, string comment) {
            var args = new Dictionary<string, string>();
            args.Add("text", comment);

            string uri = string.Format(base.Uri + "{0}/comments?access_token={1}", mediaId, AuthInfo.Access_Token);

            return HttpClient.POST(uri, args);
        }

        public CommentsResponse Delete(string mediaId, int commentId) {
            return (CommentsResponse)Json.Map<CommentsResponse>(DeleteJson(mediaId, commentId));
        }
    
        public string DeleteJson(string mediaId, int commentId) {
            string uri = string.Format(base.Uri + "{0}/comments/{1}?access_token={2}", mediaId, commentId, AuthInfo.Access_Token);
            return HttpClient.DELETE(uri);
        }
    }

}
