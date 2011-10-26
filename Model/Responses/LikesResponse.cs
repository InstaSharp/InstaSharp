using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstaSharp.Model.Responses {
    public class LikesResponse : IResponse {

        public string Json { get; set; }

        [JsonMapping("meta", JsonMapping.MappingType.Class)]
        public Model.Meta Meta { get; set; }
        [JsonMapping("data", JsonMapping.MappingType.Primitive)]
        public string Data { get; set; }
    }
}
