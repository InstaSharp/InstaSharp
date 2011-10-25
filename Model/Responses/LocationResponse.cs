using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstaSharp.Model.Responses {
    public class LocationResponse {

        public string Json { get; set; }

        [JsonMapping("meta", JsonMapping.MappingType.Class)]
        public Model.Meta Meta { get; set; }
        [JsonMapping("data", JsonMapping.MappingType.Class)]
        public Location Location { get; set; }
    }
}
