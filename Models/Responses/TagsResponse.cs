using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstaSharp.Models.Responses {
    public class TagsResponse : IResponse {

        public string Json { get; set; }

        [JsonMapping("meta", JsonMapping.MappingType.Class)]
        public Models.Meta Meta { get; set; }

        [JsonMapping("data", JsonMapping.MappingType.Collection)]
        public IList<Tag> Data { get; set; }
    }
}
