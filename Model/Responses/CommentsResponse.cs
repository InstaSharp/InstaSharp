using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstaSharp.Model.Responses {
    public class CommentsResponse {
        [JsonMapping("meta", JsonMapping.MappingType.Class)]
        public Model.Meta Meta { get; set; }
        [JsonMapping("data", JsonMapping.MappingType.Collection)]
        public IList<Model.Comments> Comments { get; set; }
    }
}
