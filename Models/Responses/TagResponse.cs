using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstaSharp.Models.Responses {
    public class TagResponse : IResponse {

        public string Json { get; set; }

        [JsonMapping("meta", JsonMapping.MappingType.Class)]
        public Models.Meta Meta { get; set; }

         [JsonMapping("data", JsonMapping.MappingType.Class)]
        public Models.Tag Data { get; set; }
    }
}
