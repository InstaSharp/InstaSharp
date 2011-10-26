using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InstaSharp.Model.Responses;

namespace InstaSharp.Endpoints.Comments {
    public class Unauthenticated : InstagramAPI {

        public Unauthenticated(InstagramConfig config)
            : base(config, "/media/") { }

        public CommentsResponse Get(string mediaId) {
            return (CommentsResponse)Mapper.Map<CommentsResponse>(GetJson(mediaId));
        }

        public string GetJson(string mediaId) {
            string uri = string.Format(base.Uri + "{0}/comments?client_id={1}", mediaId, InstagramConfig.ClientId);
            return HttpClient.GET(uri);
        }
    }
}
