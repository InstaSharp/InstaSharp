using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstaSharp.Models.Responses {
    public class CommentsResponse : IResponse {
        public Models.Meta Meta { get; set; }
        public IList<Models.Comments> Data { get; set; }
    }
}
