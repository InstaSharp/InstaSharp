using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstaSharp.Model.Responses {
    public class MediasResponse : IResponse {

        public string Json { get; set; }

        [JsonMapping("pagination", JsonMapping.MappingType.Class)]
        public Pagination Pagination { get; set; }

        [JsonMapping("meta", JsonMapping.MappingType.Class)]
        public Meta Meta { get; set; }
        
        [JsonMapping("data", JsonMapping.MappingType.Collection)]
        public List<Media> Data { get; set; }
    }
}
