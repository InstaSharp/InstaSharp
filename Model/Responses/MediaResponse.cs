using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstaSharp.Model.Responses {
    public class MediaResponse : IResponse {

        public string Json { get; set; }

        [JsonMapping("pagination", JsonMapping.MappingType.Class)]
        public Pagination Pagination { get; set; }

        [JsonMapping("meta", JsonMapping.MappingType.Class)]
        public Meta Meta { get; set; }
        
        [JsonMapping("data", JsonMapping.MappingType.Class)]
        public Media Data { get; set; }
    }
}
