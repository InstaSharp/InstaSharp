using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstaSharp.Models.Responses {
    public class CommentResponse : IResponse {
        public Models.Meta Meta { get; set; }
        public string Data { get; set; }
    }
}
