using System.Collections.Generic;

namespace InstaSharp.Models.Responses {
    public class CommentsResponse : IResponse {
        public Models.Meta Meta { get; set; }
        public List<Comment> Data { get; set; }
    }
}
