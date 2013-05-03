using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstaSharp.Models.Responses {
    public class TagsResponse : IResponse {
        public Models.Meta Meta { get; set; }
        public IList<Tag> Data { get; set; }
    }
}
