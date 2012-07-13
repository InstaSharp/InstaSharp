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

        public CommentResponse Post(string mediaId, string comment) {
            return (CommentResponse)Mapper.Map<CommentResponse>(PostJson(mediaId, comment));
        }

        private string PostJson(string mediaId, string comment) {
            var args = new Dictionary<string, string>();
            args.Add("text", comment);

            string uri = string.Format(base.Uri + "{0}/comments?access_token={1}", mediaId, AuthInfo.Access_Token);

            return HttpClient.POST(uri, args);
        }

        public CommentResponse Delete(string mediaId, string commentId) {
            return (CommentResponse)Mapper.Map<CommentResponse>(DeleteJson(mediaId, commentId));
        }
    
        private string DeleteJson(string mediaId, string commentId) {
            string uri = string.Format(base.Uri + "{0}/comments/{1}?access_token={2}", mediaId, commentId, AuthInfo.Access_Token);
            return HttpClient.DELETE(uri);
        }
    }

}
