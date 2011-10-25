using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstaSharp.Model.Responses {
    public class TagsResponse {

        public string Json { get; set; }

        [JsonMapping("data", JsonMapping.MappingType.Collection)]
        public IList<Tag> Tags { get; set; }
    }
}
